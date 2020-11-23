using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using PSPo2i_Save_Editor;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Input;

public class popUps
{
    public class popUpType
    {
        public popUpType(MainWindow mainForm, ref dynamic objectToShow)
        {
            bgWorkDelay = new BackgroundWorker();
            appearDelayCompleteFunctionDelegate = null;
            appearDelayCompleteFunctionParams = null;
            cancelFunctionDelegate = null;
            cancelFunctionParams = null;
            obj = objectToShow;
            mainFrm = mainForm;
            objectToShow.popUpObj = this;
            createPopUpElements();
            Objects.Add(this);
        }
        private dynamic obj;
        public object appearDelayCompleteFunctionDelegate;
        public object appearDelayCompleteFunctionParams;
        public object cancelFunctionDelegate;
        public object cancelFunctionParams;
        public MainWindow mainFrm;
        public bool IsOpen = false;

        public void appear(object delayCompleteFunctionDelegate = null, object delayCompleteFunctionParams = null)
        {
            if ((IsOpen))
            {
                if ((delayCompleteFunctionDelegate == null))
                    return;
                else
                    // Application.MyMsgBox("WARNING - Trying to run popup appear on object that is already appeared but asking for a delay function to be ran too!")
                    return;
            }
            appearDelayCompleteFunctionDelegate = delayCompleteFunctionDelegate;
            appearDelayCompleteFunctionParams = delayCompleteFunctionParams;
            bgWorkDelay.RunWorkerAsync();
        }

        public void popUpBgFade_Complete()
        {
            try
            {
                Grid.SetRow((System.Windows.UIElement)obj, 1);
                panelPopupContent.Children.Add((System.Windows.UIElement)obj);
                btnCancelPopUp.Focus();
                obj.load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error after pop up bg has faded in:\r\n\r\n" + ex.Message, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public void popUpBgFade2_Complete()
        {
            btnCancelPopUp.Focus();
        }

        private BackgroundWorker _bgWorkDelay;

        public BackgroundWorker bgWorkDelay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _bgWorkDelay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_bgWorkDelay != null)
                {
                    _bgWorkDelay.DoWork -= bgWorkDelay_DoWork;
                    _bgWorkDelay.RunWorkerCompleted -= bgWorkDelay_RunWorkerCompleted;
                }

                _bgWorkDelay = value;
                if (_bgWorkDelay != null)
                {
                    _bgWorkDelay.DoWork += bgWorkDelay_DoWork;
                    _bgWorkDelay.RunWorkerCompleted += bgWorkDelay_RunWorkerCompleted;
                }
            }
        }

        private void bgWorkDelay_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(5);
        }
        private void bgWorkDelay_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelPopupBoxGridWrapper.Width = panelPopupBoxGrid.ActualWidth;
                panelPopupBoxGridWrapper.Height = panelPopupBoxGrid.ActualHeight;
                Border bd = (Border)VisualTreeHelper.GetChild(panelPopupBoxGridWrapper, 0);
                bd.Width = panelPopupBoxGrid.ActualWidth;
                bd.Height = panelPopupBoxGrid.ActualHeight;
                bd.Margin = new Thickness(-15, -100, 0, 0);
                IsOpen = true;


                if (!(appearDelayCompleteFunctionDelegate == null))
                {
                    Type t = obj.GetType();

                    if ((appearDelayCompleteFunctionParams == null))
                        obj.Dispatcher.BeginInvoke(appearDelayCompleteFunctionDelegate);
                    else
                        obj.Dispatcher.BeginInvoke(appearDelayCompleteFunctionDelegate, appearDelayCompleteFunctionParams);
                }

                objectAnimations.makeAppear(ref mainFrm, panelPopupContentPanel, false, mainFrm, new MainWindow.voidDelegate(popUpBgFade2_Complete));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error after after pop up appears:\r\n\r\n" + ex.Message, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public void closePopUp(object completeFunctionDelegate, object completeFunctionParams)
        {
            appearDelayCompleteFunctionParams = completeFunctionParams;
            appearDelayCompleteFunctionDelegate = completeFunctionDelegate;
            objectAnimations.makeDisappear(mainFrm, panelPopupContentPanel, false, mainFrm, new MainWindow.voidDelegate(popUpBgFadeOut_Complete));
        }

        public void popUpBgFadeOut_Complete()
        {
            panelPopupContent.Children.RemoveRange(0, panelPopupContent.Children.Count);
            objectAnimations.makeDisappear(mainFrm, panelPopup, false, mainFrm, new MainWindow.voidDelegate(popUpBgFadeOut2_Complete));
        }

        public void popUpBgFadeOut2_Complete()
        {
            cancelFunctionDelegate = null;
            cancelFunctionParams = null;
            if ((Objects.Count > 1))
                mainFrm.enablePopUp(true);
            else
                mainFrm.enableForm(true);
            if (!(appearDelayCompleteFunctionDelegate == null))
            {
                Type t = obj.GetType();
                if ((appearDelayCompleteFunctionParams == null))
                    obj.Dispatcher.BeginInvoke(appearDelayCompleteFunctionDelegate);
                else
                    obj.Dispatcher.BeginInvoke(appearDelayCompleteFunctionDelegate, appearDelayCompleteFunctionParams);
            }
            deletePopUpElements();
            IsOpen = false;
            Objects.Remove(this);
        }

        public void cancel(object sender, RoutedEventArgs e)
        {
            if ((cancelFunctionDelegate == null))
                closePopUp(null, null);
            else
            {
                Type t = obj.GetType();

                if ((appearDelayCompleteFunctionParams == null))
                    obj.Dispatcher.BeginInvoke(cancelFunctionDelegate);
                else
                    obj.Dispatcher.BeginInvoke(cancelFunctionDelegate, cancelFunctionParams);
            }
        }

        public DockPanel panelPopup;
        public DockPanel panelPopupContentPanel;
        public Rectangle imgPopUpIcon;
        public Label lblPopUpHeader;
        public Grid panelPopupBoxGridWrapper;
        public Grid panelPopupBoxGrid;
        public Button btnCancelPopUp;
        public StackPanel panelPopupContent;

        private int defaultZindex = 2000;

        private void createPopUpBackgroundFader()
        {
            panelPopup = new DockPanel();
            panelPopup.Name = "panelPopUp_" + Objects.Count;
            panelPopup.Background = new SolidColorBrush(Color.FromArgb(50, 0, 0, 0));
            panelPopup.Opacity = 0;
            panelPopup.Visibility = Visibility.Hidden;
            var zindex = defaultZindex + Objects.Count;
            Panel.SetZIndex(panelPopup, zindex);
            Grid.SetColumn(panelPopup, 0);
            Grid.SetColumnSpan(panelPopup, 2);
            Grid.SetRow(panelPopup, 1);
            KeyboardNavigation.SetTabNavigation(panelPopup, KeyboardNavigationMode.Cycle);
            KeyboardNavigation.SetControlTabNavigation(panelPopup, KeyboardNavigationMode.Cycle);
            KeyboardNavigation.SetDirectionalNavigation(panelPopup, KeyboardNavigationMode.Cycle);

            StackPanel stackPanel = new StackPanel();
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.Height = double.NaN;
            stackPanel.Width = double.NaN;

            panelPopup.Children.Add(stackPanel);
            mainFrm.gridMain.Children.Add(panelPopup);
        }

        private void createPopUpBox()
        {
            panelPopupContentPanel = new DockPanel();
            panelPopupContentPanel.Name = "panelPopupContentPanel_" + Objects.Count;
            panelPopupContentPanel.Background = new SolidColorBrush(Color.FromArgb(50, 0, 0, 0));
            panelPopupContentPanel.Opacity = 1;
            panelPopupContentPanel.Visibility = Visibility.Hidden;
            panelPopupContentPanel.VerticalAlignment = VerticalAlignment.Stretch;
            var zindex = defaultZindex + Objects.Count + 1;
            Panel.SetZIndex(panelPopupContentPanel, zindex);
            Grid.SetColumn(panelPopupContentPanel, 0);
            Grid.SetRow(panelPopupContentPanel, 1);
            Grid.SetColumnSpan(panelPopupContentPanel, 2);
            KeyboardNavigation.SetTabNavigation(panelPopupContentPanel, KeyboardNavigationMode.Cycle);
            KeyboardNavigation.SetControlTabNavigation(panelPopupContentPanel, KeyboardNavigationMode.Cycle);
            KeyboardNavigation.SetDirectionalNavigation(panelPopupContentPanel, KeyboardNavigationMode.Cycle);


            panelPopupBoxGrid = new Grid();
            panelPopupBoxGrid.Name = "panelPopupBoxGrid_" + Objects.Count;
            panelPopupBoxGrid.Margin = new Thickness(-15, -100, 0, 0);
            panelPopupBoxGrid.Background = (Brush)mainFrm.FindResource("WindowBackgroundBrushMedium");
            panelPopupBoxGrid.VerticalAlignment = VerticalAlignment.Center;
            panelPopupBoxGrid.HorizontalAlignment = HorizontalAlignment.Stretch;

            RowDefinition rowDef = new RowDefinition();
            rowDef.Height = new GridLength(35);
            panelPopupBoxGrid.RowDefinitions.Add(rowDef);
            RowDefinition rowDef2 = new RowDefinition();
            panelPopupBoxGrid.RowDefinitions.Add(rowDef2);

            imgPopUpIcon = new Rectangle();
            imgPopUpIcon.Name = "imgPopUpIcon_" + Objects.Count;
            imgPopUpIcon.HorizontalAlignment = HorizontalAlignment.Left;
            imgPopUpIcon.VerticalAlignment = VerticalAlignment.Center;
            imgPopUpIcon.Margin = new Thickness(10, 0, 5, 0);
            imgPopUpIcon.Width = 20;
            imgPopUpIcon.Height = 20;
            imgPopUpIcon.Visibility = Visibility.Collapsed;

            Grid.SetRow(imgPopUpIcon, 0);
            panelPopupBoxGrid.Children.Add(imgPopUpIcon);

            lblPopUpHeader = new Label();
            lblPopUpHeader.Name = "lblPopUpHeader_" + Objects.Count;
            lblPopUpHeader.Content = "[No Header Loaded]";
            lblPopUpHeader.HorizontalAlignment = HorizontalAlignment.Left;
            lblPopUpHeader.VerticalAlignment = VerticalAlignment.Center;
            lblPopUpHeader.Width = 300;
            lblPopUpHeader.Height = double.NaN;
            lblPopUpHeader.Foreground = (Brush)mainFrm.FindResource("HeaderTextBrush");
            lblPopUpHeader.FontFamily = (FontFamily) mainFrm.FindResource("VestasSans");
            lblPopUpHeader.FontSize = 14;
            lblPopUpHeader.Margin = new Thickness(30, 3, 0, 0);
            Grid.SetRow(lblPopUpHeader, 0);
            panelPopupBoxGrid.Children.Add(lblPopUpHeader);

            Grid gridItem = new Grid();
            gridItem.HorizontalAlignment = HorizontalAlignment.Right;
            gridItem.VerticalAlignment = VerticalAlignment.Center;
            gridItem.Margin = new Thickness(0, 0, 5, 0);
            Grid.SetRow(gridItem, 0);

            btnCancelPopUp = new Button();
            btnCancelPopUp.Name = "btnCancelPopUp_" + Objects.Count;
            btnCancelPopUp.Width = 25;
            btnCancelPopUp.Height = 25;
            btnCancelPopUp.Cursor = Cursors.Hand;
            btnCancelPopUp.Style = (Style)mainFrm.FindResource("ButtonStyleImage");
            btnCancelPopUp.AddHandler(Button.ClickEvent, new RoutedEventHandler(cancel));

            Image btnImg = new Image();
            btnImg.VerticalAlignment = VerticalAlignment.Center;
            btnImg.HorizontalAlignment = HorizontalAlignment.Left;
            btnImg.Margin = new Thickness(0);
            btnImg.Source = appImages.getImageFromResources("cancel_round.png");
            btnImg.Width = 16;
            btnImg.Height = 16;

            btnCancelPopUp.Content = btnImg;
            btnCancelPopUp.Focus();
            gridItem.Children.Add(btnCancelPopUp);
            panelPopupBoxGrid.Children.Add(gridItem);

            panelPopupContent = new StackPanel();
            panelPopupContent.Name = "panelPopupContent_" + Objects.Count;
            panelPopupContent.VerticalAlignment = VerticalAlignment.Center;
            panelPopupContent.Width = double.NaN;
            panelPopupContent.Height = double.NaN;
            panelPopupContent.Margin = new Thickness(5, 0, 5, 5);
            panelPopupContent.Background = (Brush)mainFrm.FindResource("WindowBackgroundBrushDark");
            Panel.SetZIndex(panelPopupContent, 0);
            Grid.SetRow(panelPopupContent, 1);

            panelPopupBoxGrid.Children.Add(panelPopupContent);

            // add a drop shadow the panelPopupBoxGrid
            panelPopupBoxGridWrapper = new Grid();
            panelPopupBoxGridWrapper.VerticalAlignment = VerticalAlignment.Center;
            panelPopupBoxGridWrapper.HorizontalAlignment = HorizontalAlignment.Center;

            Border border = new Border();
            border.BorderThickness = new Thickness(1);
            border.BorderBrush = (Brush)mainFrm.FindResource("WindowBackgroundBrushDark");
            border.VerticalAlignment = VerticalAlignment.Stretch;

            System.Windows.Media.Effects.DropShadowEffect fx = new System.Windows.Media.Effects.DropShadowEffect();
            fx.Opacity = 1;
            fx.ShadowDepth = 1;
            fx.BlurRadius = 5;
            fx.Color = (Color)mainFrm.FindResource("ColorShadowAlpha");
            border.Effect = fx;

            panelPopupBoxGridWrapper.Children.Add(border);
            panelPopupBoxGridWrapper.Children.Add(panelPopupBoxGrid);
            panelPopupContentPanel.Children.Add(panelPopupBoxGridWrapper);
            mainFrm.gridMain.Children.Add(panelPopupContentPanel);
        }
        private void createPopUpElements()
        {
            createPopUpBackgroundFader();
            createPopUpBox();
        }
        private void deletePopUpElements()
        {
            mainFrm.gridMain.Children.Remove(panelPopup);
            mainFrm.gridMain.Children.Remove(panelPopupContentPanel);
        }
    }

    public static List<popUpType> Objects = new List<popUpType>();

    public static bool IsOpen()
    {
        foreach (popUpType item in Objects)
        {
            if ((item.IsOpen))
            {
                return true;
            }
        }
        return false;
    }

    public static bool Exist()
    {
        if ((Objects.Count > 0))
           return true;
        return false;
    }

    public static void loadPopUp(MainWindow mainFrm, string header, string icon, dynamic popUpWindow)
    {
        popUpType newObject = new popUpType(mainFrm, popUpWindow);
        mainFrm.enableForm(false);

        newObject.lblPopUpHeader.Content = header;

        if ((icon != ""))
        {
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = appImages.getImageFromResources(icon);
            imgBrush.Stretch = Stretch.Uniform;
            newObject.imgPopUpIcon.OpacityMask = imgBrush;
            newObject.imgPopUpIcon.Fill = (Brush)mainFrm.FindResource("HeaderTextBrush");
            newObject.imgPopUpIcon.Visibility = Visibility.Visible;
        }

        newObject.panelPopupContent.Children.RemoveRange(0, newObject.panelPopupContent.Children.Count);
        newObject.panelPopupContentPanel.Opacity = 0;
        newObject.panelPopupBoxGrid.MinWidth = popUpWindow.MinWidth + 20;
        objectAnimations.makeAppear(ref mainFrm, newObject.panelPopup, false, mainFrm, new MainWindow.voidDelegate(newObject.popUpBgFade_Complete));
    }
}
