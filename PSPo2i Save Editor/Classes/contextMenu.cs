using PSPo2i_Save_Editor;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class contextMenuHelper
{
    public enum contextMenuItemType
    {
        item,
        item_coloured_icon,
        splitter,
        header
    }
    public class contextMenuData
    {
        public object tag;
        public string icon;
        public object content;
        public RoutedEventHandler fcn;
        public List<contextMenuData> SubItems = new List<contextMenuData>();
        public contextMenuItemType type;
        public contextMenuData(string iconPath, object contents, RoutedEventHandler routedEvent, contextMenuItemType itemType = contextMenuItemType.item, List<contextMenuData> sub_items = null)
        {
            icon = iconPath;
            content = contents;
            fcn = routedEvent;
            type = itemType;
            SubItems = sub_items;
        }
    }

    private static MainWindow mainForm;
    public static void contextMenuItemMouseOver(object sender, RoutedEventArgs e)
    {
        Grid grid = (Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0);
        int count = VisualTreeHelper.GetChildrenCount(grid);
        int i;
        ((MenuItem)sender).Foreground = (Brush)mainForm.FindResource("ControlTextActive");
        for (i = 0; i <= count - 1; i++)
        {
            Rectangle obj = (Rectangle)VisualTreeHelper.GetChild(grid, i);

            if ((obj.Name == "InnerBorder"))
                obj.Stroke = (Brush)mainForm.FindResource("ContextMenuButtonHighlightBorder");
            if ((obj.Name == "InnerBg"))
                obj.Fill = (Brush)mainForm.FindResource("ContextMenuButtonHighlightBackground");
            if ((obj.Name == "grid"))
            {
                Border objTest = (Border)VisualTreeHelper.GetChild(obj, 0);
                if ((objTest.Name == "iconPanel"))
                {
                    ContentPresenter iconContent = (ContentPresenter)VisualTreeHelper.GetChild(objTest, 0);
                    appImages.switchSpecialIcon(iconContent, true);
                }
            }
        }
    }

    public static void contextMenuItemMouseOut(object sender, RoutedEventArgs e)
    {
        Grid grid = (Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0);
        int count = VisualTreeHelper.GetChildrenCount(grid);
        int i;
        ((MenuItem)sender).Foreground = (Brush)mainForm.FindResource("ControlTextInactive");

        for (i = 0; i <= count - 1; i++)
        {
            Rectangle obj = (Rectangle) VisualTreeHelper.GetChild(grid, i);

            if ((obj.Name == "InnerBorder"))
                obj.Stroke = new SolidColorBrush(Colors.Transparent);
            if ((obj.Name == "InnerBg"))
                obj.Fill = new SolidColorBrush(Colors.Transparent);
            if ((obj.Name == "grid"))
            {
                Border objTest = (Border)VisualTreeHelper.GetChild(obj, 0);
                if ((objTest.Name == "iconPanel"))
                {
                    ContentPresenter iconContent = (ContentPresenter)VisualTreeHelper.GetChild(objTest, 0);
                    appImages.switchSpecialIcon(iconContent, false);
                }
            }
        }
    }
    public static MenuItem createContextMenuItem(MainWindow mainFrm, contextMenuData item)
    {
        mainForm = mainFrm;

        MenuItem mi = new MenuItem();
        mi.Foreground = (Brush) mainFrm.FindResource("ControlTextInactive");
        mi.FontFamily = (FontFamily)mainFrm.FindResource("VestasSans");
        mi.VerticalContentAlignment = VerticalAlignment.Center;
        if ((item.icon != ""))
        {
            if (!(item.SubItems == null))
                mi.Style = (Style)mainFrm.FindResource("ContextMenuItemWithSubItemsStyle");
            else
                mi.Style = (Style)mainFrm.FindResource("ContextMenuItemStyle");
            mi.AddHandler(MenuItem.MouseEnterEvent, new RoutedEventHandler(contextMenuItemMouseOver));
            mi.AddHandler(MenuItem.MouseLeaveEvent, new RoutedEventHandler(contextMenuItemMouseOut));
            if ((item.type == contextMenuItemType.item_coloured_icon))
                mi.Icon = appImages.createChangeableSpecialIcon(mainFrm, item.icon, 16, "ControlTextInactive");
            else
            {
                Image img = new Image();
                img.Source = BitmapFrame.Create(appImages.getImageFromResources(item.icon));
                mi.Icon = img;
            }
        }
        else if ((item.type == contextMenuItemType.header))
            mi.Style = (Style)mainFrm.FindResource("ContextMenuItemHeaderStyle");
        else
            mi.Style = (Style)mainFrm.FindResource("ContextMenuItemNoIconStyle");
        if (!(item.fcn == null))
            mi.AddHandler(MenuItem.ClickEvent, item.fcn);
        mi.Header = item.content;

        if (!(item.SubItems == null))
        {
            // add the sub items
            int i;
            for (i = 0; i <= item.SubItems.Count - 1; i++)
                mi.Items.Add(createContextMenuItem(mainFrm, item.SubItems[i]));
        }
        mi.Tag = item.tag;
        return mi;
    }
    public static ContextMenu createContextMenu(MainWindow mainFrm, List<contextMenuData> items)
    {
        ContextMenu menu = new ContextMenu();
        menu.Style = (Style)mainFrm.FindResource("ContextMenuStyle1");
        foreach (contextMenuData item in items)
        {
            if ((item.type == contextMenuItemType.item))
                menu.Items.Add(createContextMenuItem(mainFrm, item));
            else if ((item.type == contextMenuItemType.item_coloured_icon))
                menu.Items.Add(createContextMenuItem(mainFrm, item));
            else if ((item.type == contextMenuItemType.header))
                menu.Items.Add(createContextMenuItem(mainFrm, item));
            else
            {
                Separator s = new Separator();
                s.Margin = new Thickness(-30, 0, 0, 0);
                s.Height = 1;
                s.Background = (Brush)mainFrm.FindResource("ControlBorder");
                menu.Items.Add(s);
            }
        }
        menu.IsOpen = true;
        return menu;
    }
}
