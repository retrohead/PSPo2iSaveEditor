using PSPo2i_Save_Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class objectAnimations
{
    public enum animTypes
    {
        appear,
        disappear
    }
    public animTypes animType;
    public dynamic obj;
    public double opacity;
    public bool blockForm;
    public double alphaStep;
    private MainWindow mainFrm;
    private BackgroundWorker bgwrk;
    private BackgroundWorker bgwrkAppearDelay;

    public dynamic completeFunctionObj;
    public object completeFunctionDelegate;
    public object completeFunctionParams;

    public dynamic delayFunctionObj;
    public object delayFunctionDelegate;
    public object delayFunctionParams;

    public void runCompleteFunction()
    {
        if (!(completeFunctionDelegate == null))
        {
            Type t = completeFunctionObj.GetType();

            if ((completeFunctionParams == null))
                completeFunctionObj.Dispatcher.BeginInvoke(completeFunctionDelegate);
            else
                completeFunctionObj.Dispatcher.BeginInvoke(completeFunctionDelegate, completeFunctionParams);
        }
    }

    public objectAnimations(MainWindow mainForm, dynamic objToFade, animTypes animationType, double alphaPerStep, bool blockFormActions, object onCompleteFunctionObj, object onCompleteFunctionDelegate, object onCompleteFunctionParams = null)
    {
        completeFunctionObj = onCompleteFunctionObj;
        completeFunctionDelegate = onCompleteFunctionDelegate;
        completeFunctionParams = onCompleteFunctionParams;

        bgwrk.DoWork += bgwrk_DoWork;
        bgwrk.RunWorkerCompleted += bgwrk_RunWorkerCompleted;


        if ((animationType == animTypes.appear))
        {
            if ((objToFade.Opacity != 1))
            {
                opacity = 0;
                objToFade.Opacity = 0;
            }
        }
        else if ((objToFade.Opacity != 0))
        {
            objToFade.Opacity = 1;
            opacity = 1;
        }


        mainFrm = mainForm;
        animType = animationType;
        alphaStep = alphaPerStep;
        obj = objToFade;
        blockForm = blockFormActions;
        bgwrk = new BackgroundWorker();
        bgwrkAppearDelay = new BackgroundWorker();
    }

    public void run()
    {
        if ((animType == animTypes.appear))
        {
            if ((obj.Opacity == 1))
            {
                runCompleteFunction();
                return;
            }
        }
        else if ((obj.Opacity == 0))
        {
            runCompleteFunction();
            return;
        }
        obj.Opacity = opacity;
        bgwrk.RunWorkerAsync();

        if ((blockForm))
        {
            if ((popUps.IsOpen() == false))
                mainFrm.enableForm(false);
            else
                mainFrm.enablePopUp(false);
            mainFrm.updateProgressLabel("Please Wait...");
            mainFrm.panelSmallProgress.Visibility = Visibility.Visible;
        }
    }

    private void bgwrk_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        System.Threading.Thread.Sleep(1);
    }

    private void bgwrk_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        bool complete = false;
        if ((animType == animTypes.appear))
        {
            opacity = opacity + alphaStep;
            if ((opacity >= 1.0))
            {
                opacity = 1.0;
                complete = true;
            }
        }
        else
        {
            opacity = opacity - alphaStep;
            if ((opacity <= 0.0))
            {
                opacity = 0.0;
                complete = true;
                obj.Visibility = Visibility.Hidden;
            }
        }
        obj.Opacity = opacity;
        if ((complete == false))
            bgwrk.RunWorkerAsync();
        else
        {
            if ((blockForm))
            {
                mainFrm.panelSmallProgress.Visibility = Visibility.Hidden;

                if ((popUps.IsOpen() == false))
                    mainFrm.enableForm(true);
                else
                    mainFrm.enablePopUp(true);
            }
            runCompleteFunction();
        }
    }

    public static void prepareAppear(ref MainWindow mainFrm, dynamic obj, bool blockFormActions, object onCompleteFunctionObj, object onCompleteFunctionDelegate, object onCompleteFunctionParams = null)
    {
        if ((obj.Opacity != 1))
        {
            try
            {
                if ((obj.InvokeRequired))
                    obj.BeginInvoke(new MainWindow.setObjectOpacityDelegate(MainWindow.setObjectOpacity), 0);
                else
                    obj.Opacity = 0;
            }
            catch
            {
                obj.Opacity = 0;
            }
        }
        try
        {
            if ((obj.InvokeRequired))
                obj.BeginInvoke(new MainWindow.setObjectVisibilityDelegate(MainWindow.setObjectVisibility), Visibility.Visible);
            else
                obj.Visibility = Visibility.Visible;
        }
        catch
        {
            obj.Visibility = Visibility.Visible;
        }

        mainFrm.objectAnim = new objectAnimations(mainFrm, obj, animTypes.appear, 0.04, blockFormActions, onCompleteFunctionObj, onCompleteFunctionDelegate, onCompleteFunctionParams);
    }

    private void bgwrkAppearDelay_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        System.Threading.Thread.Sleep(1);
    }

    private void bgwrkAppearDelay_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        // run the function after delay
        if (!(delayFunctionDelegate == null))
        {
            Type t = delayFunctionObj.GetType();
            if ((delayFunctionParams == null))
                delayFunctionObj.Dispatcher.BeginInvoke(delayFunctionDelegate);
            else
                delayFunctionObj.Dispatcher.BeginInvoke(delayFunctionDelegate, delayFunctionParams);
        }

        // now make the item appear
        mainFrm.objectAnim.run();
    }

    public static void panelAppear(ref MainWindow mainFrm, object obj, bool blockFormActions, object onCompleteFunctionObj, object onCompleteFunctionDelegate, object onCompleteFunctionParams, object delayCompleteFunctionObj, object delayCompleteFunctionDelegate, object delayCompleteFunctionParams)
    {
        prepareAppear(ref mainFrm, obj, blockFormActions, onCompleteFunctionObj, onCompleteFunctionDelegate, onCompleteFunctionParams);

        mainFrm.objectAnim.delayFunctionObj = delayCompleteFunctionObj;
        mainFrm.objectAnim.delayFunctionDelegate = delayCompleteFunctionDelegate;
        mainFrm.objectAnim.delayFunctionParams = delayCompleteFunctionParams;

        mainFrm.objectAnim.bgwrkAppearDelay.RunWorkerAsync();
    }

    public static void makeAppear(ref MainWindow mainFrm, dynamic obj, bool blockFormActions, dynamic onCompleteFunctionObj, object onCompleteFunctionDelegate, object onCompleteFunctionParams = null)
    {
        prepareAppear(ref mainFrm, obj, blockFormActions, onCompleteFunctionObj, onCompleteFunctionDelegate, onCompleteFunctionParams);
        mainFrm.objectAnim.run();
    }
    public static void makeDisappear(MainWindow mainFrm, dynamic obj, bool blockFormActions, dynamic onCompleteFunctionObj, object onCompleteFunctionDelegate, object onCompleteFunctionParams = null)
    {
        if ((obj.Opacity == 0))
        {
            // already hidden, just run the function
            if (!(onCompleteFunctionDelegate == null))
            {
                Type t = onCompleteFunctionObj.GetType();
                if ((onCompleteFunctionParams == null))
                    onCompleteFunctionObj.Dispatcher.BeginInvoke(onCompleteFunctionDelegate);
                else
                    onCompleteFunctionObj.Dispatcher.BeginInvoke(onCompleteFunctionDelegate, onCompleteFunctionParams);
            }
            return;
        }
        obj.Opacity = 1;
        obj.Visibility = Visibility.Visible;
        mainFrm.objectAnim = new objectAnimations(mainFrm, obj, animTypes.disappear, 0.04, blockFormActions, onCompleteFunctionObj, onCompleteFunctionDelegate, onCompleteFunctionParams);
        mainFrm.objectAnim.run();
    }

}
