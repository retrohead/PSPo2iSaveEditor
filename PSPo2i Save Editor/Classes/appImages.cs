using PSPo2i_Save_Editor;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

public class appImages
{
    private class imgType
    {
        public BitmapImage img;
        public string path;
    }

    private static List<imgType> loadedImages = new List<imgType>();
    public static BitmapImage getImageFromResources(string resourcePath)
    {
        if ((loadedImages == null))
            loadedImages = new List<imgType>();
        else
            // see if image is loaded already
            foreach (imgType img in loadedImages)
            {
                if ((img.path == resourcePath))
                {
                    return img.img;
                }
            }

        // load a new image
        imgType i;
        i = new imgType();
        i.path = resourcePath;
        i.img = new BitmapImage(new Uri("pack://application:,,,/PSPo2i Save Editor;component/Resources/" + resourcePath));


        loadedImages.Add(i);
        return i.img;
    }

    public static bool exportResourceImageToFile(string resourcePath, string destPath)
    {
        if ((System.IO.File.Exists(destPath) == true))
            System.IO.File.Delete(destPath);

        try
        {
            using (System.IO.FileStream fileStream = new System.IO.FileStream(destPath, System.IO.FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(new Uri("pack://application:,,,/PSPo2i Save Editor;component/Resources/" + resourcePath)));
                encoder.Save(fileStream);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }


    public static Rectangle createSpecialIcon(MainWindow mainForm, string iconName, int height, string brush)
    {
        ImageSource icon;
        icon = appImages.getImageFromResources(iconName);
        Rectangle rect = new Rectangle();
        ImageBrush imgBrush = new ImageBrush();
        imgBrush.Stretch = Stretch.Uniform;
        imgBrush.ImageSource = icon;
        RenderOptions.SetBitmapScalingMode(imgBrush, BitmapScalingMode.NearestNeighbor);
        rect.OpacityMask = imgBrush;
        rect.Fill = (Brush)mainForm.FindResource(brush);
        rect.Height = height;
        return rect;
    }
    public static Grid createChangeableSpecialIcon(MainWindow mainForm, string iconName, int height, string staticIconColorBrush)
    {
        Grid g = new Grid();
        g.Children.Add(appImages.createSpecialIcon(mainForm, iconName, height, staticIconColorBrush));

        Rectangle rect = appImages.createSpecialIcon(mainForm, iconName, height, "ControlTextActive");
        rect.Visibility = Visibility.Hidden;

        g.Children.Add(rect);
        return g;
    }

    public static void switchSpecialIcon(ContentPresenter icon, bool IsMouseOver)
    {
        if ((VisualTreeHelper.GetChildrenCount(icon) == 0))
            return;
        if ((VisualTreeHelper.GetChild(icon, 0) as Grid == null))
            return;
        Grid grid = (Grid)VisualTreeHelper.GetChild(icon, 0);
        Rectangle o;
        if ((IsMouseOver))
        {
            o = (Rectangle)VisualTreeHelper.GetChild(grid, 0);
            o.Visibility = Visibility.Hidden;
            o = (Rectangle)VisualTreeHelper.GetChild(grid, 1);
            o.Visibility = Visibility.Visible;
        }
        else
        {
            o = (Rectangle)VisualTreeHelper.GetChild(grid, 1);
            o.Visibility = Visibility.Hidden;
            o = (Rectangle)VisualTreeHelper.GetChild(grid, 0);
            o.Visibility = Visibility.Visible;
        }
    }
}
