using PSPo2i_Save_Editor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

public class listViewColumnHeaderDataType : IComparable<listViewColumnDataType>
{
    private string _filter;
    public string filter
    {
        get
        {
            return _filter;
        }
        set
        {
            _filter = value;
        }
    }

    private bool _filterInclude;
    public bool filterInclude
    {
        get
        {
            return _filterInclude;
        }
        set
        {
            _filterInclude = value;
        }
    }

    private bool _filterExact;
    public bool filterExact
    {
        get
        {
            return _filterExact;
        }
        set
        {
            _filterExact = value;
        }
    }

    private string _data;
    public string data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
        }
    }

    public listViewColumnHeaderDataType(string dataStr)
    {
        data = dataStr;
    }

    public int CompareTo(listViewColumnDataType other)
    {
        // Compare string.
        return this.data.CompareTo(other.data);
    }
}

public class listViewColumnDataType : IComparable<listViewColumnDataType>
{
    private string _data;
    public string data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
        }
    }

    private listViewItemDataType parent;
    public listViewColumnDataType(listViewItemDataType parentData, string dataStr)
    {
        parent = parentData;
        data = dataStr;
        HasFilterResult = false;
    }

    private bool _showing = true;
    public bool HasFilterResult
    {
        get
        {
            return _showing;
        }
        set
        {
            _showing = value;
        }
    }


    public int CompareTo(listViewColumnDataType other)
    {
        if ((this.parent.columnsWithFilterResultsCount() == this.parent.columnsWithFiltersCount()))
            // compare string
            return this.data.CompareTo(other.data);
        else
            // item must be filtered out already
            return -1;
    }
}

public class listViewItemDataType
{
    public listViewDataType parent;

    private string _id;
    public string id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    private ImageSource _icon;
    public ImageSource icon
    {
        get
        {
            return _icon;
        }
        set
        {
            _icon = value;
        }
    }

    private ImageSource _icon2;
    public ImageSource icon2
    {
        get
        {
            return _icon2;
        }
        set
        {
            _icon2 = value;
        }
    }

    private string _iconColour;
    public string iconColour
    {
        get
        {
            return _iconColour;
        }
        set
        {
            _iconColour = value;
        }
    }

    private List<listViewColumnDataType> _values = new List<listViewColumnDataType>();
    public List<listViewColumnDataType> SubItems
    {
        get
        {
            return _values;
        }
        set
        {
            _values = value;
        }
    }

    public int columnsWithFilterResultsCount()
    {
        int i;
        int result = 0;
        for (i = 0; i <= SubItems.Count - 1; i++)
        {
            if ((SubItems[i].HasFilterResult == true))
                result = result + 1;
        }
        return result;
    }
    public int columnsWithFiltersCount()
    {
        int i;
        int result = 0;
        for (i = 0; i <= parent.Columns.Count - 1; i++)
        {
            if ((parent.Columns[i].filter != ""))
                result = result + 1;
        }
        return result;
    }

    public listViewItemDataType(listViewDataType parentData, string text, string value)
    {
        id = value;
        parent = parentData;
        SubItems.Add(new listViewColumnDataType(this, text));
    }
}

public interface IColumnInterface
{
    event EventHandler CollectionChanged;
}

public class listViewDataType : INotifyPropertyChanged
{
    public PSPo2i_Save_Editor.MainWindow mainWindow;
    public GridViewColumn _lastColumnHeaderClicked = null;
    public ListSortDirection _lastSortDirection = ListSortDirection.Ascending;

    public event PropertyChangedEventHandler PropertyChanged;
    private object _syncLock = new object();
    private BackgroundWorker bgWorkExportList;

    private List<listViewColumnHeaderDataType> _columns = new List<listViewColumnHeaderDataType>();
    public List<listViewColumnHeaderDataType> Columns
    {
        get
        {
            return _columns;
        }
        set
        {
            _columns = value;
        }
    }
    public ListView listview;
    private SelectionMode selectMode;
    public listViewDataType(PSPo2i_Save_Editor.MainWindow mainWin, ref ListView list)
    {
        bgWorkExportList = new BackgroundWorker();
        bgWorkExportList.DoWork -= bgWorkExportList_DoWork;
        bgWorkExportList.RunWorkerCompleted -= bgWorkExportList_RunWorkerCompleted;

        mainWindow = mainWin;
        loadListView(ref list);
    }

    public void loadListView(ref ListView lst)
    {
        if ((lst == null))
            return;
        listview = lst;
        selectMode = listview.SelectionMode;
        GridView grid = (GridView)lst.View;
        int i;
        Columns = new List<listViewColumnHeaderDataType>();
        for (i = 0; i <= grid.Columns.Count - 1; i++)
        {
            if ((grid.Columns[i].Header.ToString() != ""))
                Columns.Add(new listViewColumnHeaderDataType(grid.Columns[i].Header.ToString()));
        }
        lst.AddHandler(Thumb.DragDeltaEvent, new DragDeltaEventHandler(gridViewHelper.GridViewColumnResized), true);
    }

    public void AddItem(listViewItemDataType item)
    {
        Items.Add(item);
        if (!(SelectedListItemHistory == null))
        {
            if ((SelectedListItemHistory.id == item.id))
                SelectedListItem = Items[Items.Count - 1];
        }
    }
    public void ApplySelectedItem()
    {
        if (!(SelectedListItemHistory == null))
        {
            foreach (listViewItemDataType item in Items)
            {
                if ((SelectedListItemHistory.id == item.id))
                {
                    SelectedListItem = item;
                    listview.ScrollIntoView(item);
                    return;
                }
            }
        }
    }

    private ObservableCollection<listViewItemDataType> _listItems;
    public ObservableCollection<listViewItemDataType> Items
    {
        get
        {
            return _listItems;
        }
        set
        {
            _listItems = value;
            BindingOperations.EnableCollectionSynchronization(Items, _syncLock);
            OnPropertyChanged(new PropertyChangedEventArgs("Items"));
        }
    }

    private listViewItemDataType _selectedItem;
    public listViewItemDataType SelectedListItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
            if (!(value == null) & (selectMode == SelectionMode.Single))
                SelectedListItemHistory = value;
            OnPropertyChanged(new PropertyChangedEventArgs("SelectedListItem"));
        }
    }

    private listViewItemDataType _historicalSelectedItem;
    public listViewItemDataType SelectedListItemHistory
    {
        get
        {
            return _historicalSelectedItem;
        }
        set
        {
            _historicalSelectedItem = value;

            OnPropertyChanged(new PropertyChangedEventArgs("SelectedListItemHistory"));
        }
    }

    public void OnPropertyChanged(PropertyChangedEventArgs e)
    {
         PropertyChanged?.Invoke(this, e);
    }



    private string reportName;
    private List<int> columnsToExportId;
    private GridViewColumn columnClicked;
    private void lst_ContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
        listViewItemDataType itemClicked = null;
        if ((getItemClicked(mainWindow, ref itemClicked, sender, e) == false))
        {
            e.Handled = true;
            return;
        }
    }
    private void btnSortColumnASC_Click(object sender, RoutedEventArgs e)
    {
        gridViewHelper.grid_Sorting(listview, (listViewDataType)listview.DataContext, ListSortDirection.Ascending, null, columnClicked);
        gridViewHelper.updateGridViewColumnHeaderStyle(((listViewDataType)listview.DataContext).mainWindow, (listViewDataType)listview.DataContext, ListSortDirection.Ascending, columnClicked);
    }
    private void btnSortColumnDESC_Click(object sender, RoutedEventArgs e)
    {
        gridViewHelper.grid_Sorting(listview, (listViewDataType)listview.DataContext, ListSortDirection.Descending, null/* TODO Change to default(_) if this is not a reference type */, columnClicked);
        gridViewHelper.updateGridViewColumnHeaderStyle(((listViewDataType)listview.DataContext).mainWindow, (listViewDataType)listview.DataContext, ListSortDirection.Descending, columnClicked);
    }
    private void btnFilter_Click(object sender, RoutedEventArgs e)
    {
        listViewDataType data = (listViewDataType)listview.DataContext;
        string currentFilter = data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filter;
        if ((!data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filterInclude | !data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filterExact))
            currentFilter = "";
        //popUps.loadPopUp(data.mainWindow, "Filter - Include Value", "filter.png", new popUpChangeString(data.mainWindow, columnClicked.Header, currentFilter, data.mainWindow, data.mainWindow, new popUpChangeString.completedFunctionDelegate(btnFilter_Complete)));
    }

    public void btnFilter_Complete(object result)
    {
        if ((result == null))
            return;
        listViewDataType data = (listViewDataType)listview.DataContext;
        int colId = gridViewHelper.getColumnID(columnClicked.Header.ToString(), data);
        data.Columns[colId].filter = result.ToString();
        data.Columns[colId].filterInclude = true;
        data.Columns[colId].filterExact = false;
        ICollectionView view = CollectionViewSource.GetDefaultView(listview.ItemsSource);

        view.Filter = new Predicate<object>(ColumnFilter);
        if ((result.ToString() == ""))
            applyFilterColumnHeaderStyle((listViewDataType)listview.DataContext, false);
        else
            applyFilterColumnHeaderStyle((listViewDataType)listview.DataContext, true);
        ApplySelectedItem();
    }
    private void btnFilterExclude_Click(object sender, RoutedEventArgs e)
    {
        listViewDataType data = (listViewDataType)listview.DataContext;
        string currentFilter = data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filter;
        if ((data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filterInclude | data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filterExact))
            currentFilter = "";
        //popUps.loadPopUp(data.mainWindow, "Filter - Exclude Value", "filter.png", new popUpChangeString(data.mainWindow, columnClicked.Header, currentFilter, data.mainWindow, data.mainWindow, new popUpChangeString.completedFunctionDelegate(btnFilterExclude_Complete)));
    }

    public void btnFilterExclude_Complete(object result)
    {
        if ((result == null))
            return;
        listViewDataType data = (listViewDataType)listview.DataContext;
        int colId = gridViewHelper.getColumnID(columnClicked.Header.ToString(), data);
        data.Columns[colId].filter = result.ToString();
        data.Columns[colId].filterInclude = false;
        data.Columns[colId].filterExact = false;
        ICollectionView view = CollectionViewSource.GetDefaultView(listview.ItemsSource);

        view.Filter = new Predicate<object>(ColumnFilter);
        if ((result.ToString() == ""))
            applyFilterColumnHeaderStyle((listViewDataType)listview.DataContext, false);
        else
            applyFilterColumnHeaderStyle((listViewDataType)listview.DataContext, true);
        ApplySelectedItem();
    }

    private void btnFilterExact_Click(object sender, RoutedEventArgs e)
    {
        listViewDataType data = (listViewDataType)listview.DataContext;
        string currentFilter = data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filter;
        if ((!data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filterInclude | !data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filterExact))
            currentFilter = "";
        //popUps.loadPopUp(data.panelDb.mainForm, "Filter - Include Exact Value", "filter.png", new popUpChangeString(data.panelDb, columnClicked.Header, currentFilter, data.panelDb, data.panelDb.mainForm, new popUpChangeString.completedFunctionDelegate(btnFilterExact_Complete)));
    }

    public void btnFilterExact_Complete(object result)
    {
        if ((result == null))
            return;
        listViewDataType data = (listViewDataType)listview.DataContext;
        int colId = gridViewHelper.getColumnID(columnClicked.Header.ToString(), data);
        data.Columns[colId].filter = result.ToString();
        data.Columns[colId].filterInclude = true;
        data.Columns[colId].filterExact = true;
        ICollectionView view = CollectionViewSource.GetDefaultView(listview.ItemsSource);

        view.Filter = new Predicate<object>(ColumnFilter);
        if ((result.ToString() == ""))
            applyFilterColumnHeaderStyle((listViewDataType)listview.DataContext, false);
        else
            applyFilterColumnHeaderStyle((listViewDataType)listview.DataContext, true);
        ApplySelectedItem();
    }
    private void btnFilterExcludeExact_Click(object sender, RoutedEventArgs e)
    {
        listViewDataType data = (listViewDataType)listview.DataContext;
        string currentFilter = data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filter;
        if ((data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filterInclude | !data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filterExact))
            currentFilter = "";
        //popUps.loadPopUp(data.mainWindow, "Filter - Exclude Exact Value", "filter.png", new popUpChangeString(data.panelDb, columnClicked.Header, currentFilter, data.panelDb, data.panelDb.mainForm, new popUpChangeString.completedFunctionDelegate(btnFilterExcludeExact_Complete)));
    }

    public void btnFilterExcludeExact_Complete(object result)
    {
        if ((result == null))
            return;
        listViewDataType data = (listViewDataType)listview.DataContext;
        int colId = gridViewHelper.getColumnID(columnClicked.Header.ToString(), data);
        data.Columns[colId].filter = result.ToString();
        data.Columns[colId].filterInclude = false;
        data.Columns[colId].filterExact = true;
        ICollectionView view = CollectionViewSource.GetDefaultView(listview.ItemsSource);

        view.Filter = new Predicate<object>(ColumnFilter);
        if ((result.ToString() == ""))
            applyFilterColumnHeaderStyle((listViewDataType)listview.DataContext, false);
        else
            applyFilterColumnHeaderStyle((listViewDataType)listview.DataContext, true);
        ApplySelectedItem();
    }

    public void resetItemShowingState(int column)
    {
        int i;
        for (i = 0; i <= Items.Count - 1; i++)
            Items[i].SubItems[column].HasFilterResult = false;
    }

    public void removeColumnFilter(MainWindow mainWin, int colId)
    {
        if ((mainWin == null))
            return;
        listViewDataType data = (listViewDataType)listview.DataContext;
        columnClicked = gridViewHelper.getColumn(data.Columns[colId].data, data);

        ICollectionView view = CollectionViewSource.GetDefaultView(listview.ItemsSource);
        if ((view == null))
            return;
        view.Filter = null;
        data.Columns[colId].filter = "";
        if (!(data._lastColumnHeaderClicked == null))
        {
            if ((data._lastColumnHeaderClicked.Header == columnClicked.Header))
            {
                // we are already sorting by this column, apply the sort style
                if ((data._lastSortDirection == ListSortDirection.Ascending))
                {
                    columnClicked.HeaderContainerStyle = (Style)mainWin.FindResource("GridViewColumnHeaderStyleSortASC");
                    return;
                }
                else
                {
                    columnClicked.HeaderContainerStyle = (Style)mainWin.FindResource("GridViewColumnHeaderStyleSortDESC");
                    return;
                }
            }
        }
        if (!(columnClicked.HeaderContainerStyle == null))
            columnClicked.HeaderContainerStyle = (Style)mainWin.FindResource("GridViewColumnHeaderStyle");
    }


    public void removeColumnFilters(MainWindow mainWin, ListView list)
    {
        listViewDataType data = (listViewDataType)list.DataContext;
        int i;
        for (i = 0; i <= data.Columns.Count - 1; i++)
            removeColumnFilter(mainWin, i);
    }

    private bool ColumnFilter(object item)
    {
        listViewItemDataType data = (listViewItemDataType)item;
        int colId = gridViewHelper.getColumnID(columnClicked.Header.ToString(), data.parent);
        if ((colId == -1))
            return true;
        string filter = data.parent.Columns[colId].filter;
        if ((filter == ""))
        {
            data.SubItems[colId].HasFilterResult = false;
            if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                return true;
            else
                return false;
        }
        int stringCount = 0;

        string str = data.SubItems[colId].data;
        if ((filter == ""))
        {
            data.SubItems[colId].HasFilterResult = false;
            if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                return true;
            else
                return false;
        }
        else
            stringCount = 1;

        if ((data.parent.Columns[colId].filterExact))
        {
            if (filter.ToLower() ==str.ToLower())
            {
                data.SubItems[colId].HasFilterResult = data.parent.Columns[colId].filterInclude;
                if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                    return true;
                else
                    return false;
            }
            else
            {
                double doubleVal;
                if ((double.TryParse(filter, out doubleVal)))
                {
                    double doubleColVal;
                    if ((double.TryParse(str, out doubleColVal)))
                    {
                        if ((doubleColVal == doubleVal))
                        {
                            data.SubItems[colId].HasFilterResult = data.parent.Columns[colId].filterInclude;
                            if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            data.SubItems[colId].HasFilterResult = !data.parent.Columns[colId].filterInclude;
                            if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                                return true;
                            else
                                return false;
                        }
                    }
                }
                else
                {
                    data.SubItems[colId].HasFilterResult = !data.parent.Columns[colId].filterInclude;
                    if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                        return true;
                    else
                        return false;
                }
                data.SubItems[colId].HasFilterResult = !data.parent.Columns[colId].filterInclude;
                if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                    return true;
                else
                    return false;
            }
        }

        if ((str.ToLower().Replace(filter.ToLower(), "") != str.ToLower()))
        {
            data.SubItems[colId].HasFilterResult = data.parent.Columns[colId].filterInclude;
            if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                return true;
            else
                return false;
        }
        else if ((data.parent.Columns[colId].filterInclude == false))
        {
            data.SubItems[colId].HasFilterResult = true;
            if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                return true;
            else
                return false;
        }

        int foundCount = 0;
        if ((filter.Contains("*")))
        {
            stringCount = 0;
            string[] strings = filter.Split('*');
            foreach (var fil in strings)
            {
                if ((filter != ""))
                {
                    stringCount = stringCount + 1;
                    if ((str.ToLower().Replace(fil.ToLower(), "") != str.ToLower()))
                    {
                        foundCount = foundCount + 1;
                        if ((foundCount == strings.Length))
                        {
                            data.SubItems[colId].HasFilterResult = data.parent.Columns[colId].filterInclude;
                            if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
        }

        if ((foundCount == stringCount))
        {
            data.SubItems[colId].HasFilterResult = data.parent.Columns[colId].filterInclude;
            if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
                return true;
            else
                return false;
        }
        data.SubItems[colId].HasFilterResult = false;
        if ((data.columnsWithFilterResultsCount() == data.columnsWithFiltersCount()))
            return true;
        else
            return false;
    }

    public void applyFilterColumnHeaderStyle(listViewDataType data, bool filtered)
    {
        string filter = "";
        if ((filtered))
            filter = "Filter";
        // apply the style
        bool needDoubleStyle = false;
        if (!(data._lastColumnHeaderClicked == null))
        {
            if ((data._lastColumnHeaderClicked.Header == columnClicked.Header))
                // we are already sorting by this column, apply the sort + filter style
                needDoubleStyle = true;
        }
        if ((needDoubleStyle))
        {
            // we are not sorting by this column, just apply the filter style
            if ((data._lastSortDirection == ListSortDirection.Ascending))
                columnClicked.HeaderContainerStyle = (Style) mainWindow.FindResource("GridViewColumnHeaderStyleSortASC" + filter);
            else
                columnClicked.HeaderContainerStyle = (Style) mainWindow.FindResource("GridViewColumnHeaderStyleSortDESC" + filter);
        }
        else
            // we are not sorting by this column, just apply the filter style
            columnClicked.HeaderContainerStyle = (Style) mainWindow.FindResource("GridViewColumnHeaderStyle" + filter);
    }

    private void btnClearFilters_Click(object sender, RoutedEventArgs e)
    {
        listViewDataType data = (listViewDataType)listview.DataContext;
        int colId = gridViewHelper.getColumnID(columnClicked.Header.ToString(), data);
        Columns[colId].filter = "";
        resetItemShowingState(colId);
        ICollectionView view = CollectionViewSource.GetDefaultView(listview.ItemsSource);
        view.Filter = new Predicate<object>(ColumnFilter);
        applyFilterColumnHeaderStyle(data, false);
    }


    private void buildHeaderContextMenu(MainWindow mainWin, object sender, ContextMenuEventArgs e)
    {
        mainWindow = mainWin;
        FrameworkElement fe = (FrameworkElement)e.Source;
        fe.ContextMenu = new ContextMenu();

        columnClicked = gridViewHelper.getColumn(((TextBlock)e.OriginalSource).Text, (listViewDataType)((TextBlock)e.OriginalSource).DataContext);
        if ((columnClicked == null))
            MessageBox.Show("Could not get the column header object", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);

        if ((columnClicked.Header == null))
            return;

        List<contextMenuHelper.contextMenuData> items = new List<contextMenuHelper.contextMenuData>();
        items.Add(new contextMenuHelper.contextMenuData("", ((TextBlock)e.OriginalSource).Text, null, contextMenuHelper.contextMenuItemType.header));
        items.Add(new contextMenuHelper.contextMenuData("", "", null, contextMenuHelper.contextMenuItemType.splitter));
        items.Add(new contextMenuHelper.contextMenuData("excel_export.png", "Export List", new RoutedEventHandler(btnExportList_Click), contextMenuHelper.contextMenuItemType.item_coloured_icon));
        items.Add(new contextMenuHelper.contextMenuData("filter.png", "Filter", null, contextMenuHelper.contextMenuItemType.item_coloured_icon));
        items[items.Count - 1].SubItems = new List<contextMenuHelper.contextMenuData>();
        items[items.Count - 1].SubItems.Add(new contextMenuHelper.contextMenuData("completed.png", "Include Exact Value", new RoutedEventHandler(btnFilterExact_Click), contextMenuHelper.contextMenuItemType.item_coloured_icon));
        items[items.Count - 1].SubItems.Add(new contextMenuHelper.contextMenuData("recycle.png", "Exclude Exact Value", new RoutedEventHandler(btnFilterExcludeExact_Click), contextMenuHelper.contextMenuItemType.item_coloured_icon));
        items[items.Count - 1].SubItems.Add(new contextMenuHelper.contextMenuData("completed.png", "Include Matched Value", new RoutedEventHandler(btnFilter_Click), contextMenuHelper.contextMenuItemType.item_coloured_icon));
        items[items.Count - 1].SubItems.Add(new contextMenuHelper.contextMenuData("recycle.png", "Exclude Matched Value", new RoutedEventHandler(btnFilterExclude_Click), contextMenuHelper.contextMenuItemType.item_coloured_icon));
        listViewDataType data = this;
        if ((data.Columns[gridViewHelper.getColumnID(columnClicked.Header.ToString(), data)].filter != ""))
            items.Add(new contextMenuHelper.contextMenuData("clear_filter.png", "Clear Filter", new RoutedEventHandler(btnClearFilters_Click), contextMenuHelper.contextMenuItemType.item_coloured_icon));
        items.Add(new contextMenuHelper.contextMenuData("sort_asc.png", "Sort Ascending", new RoutedEventHandler(btnSortColumnASC_Click), contextMenuHelper.contextMenuItemType.item_coloured_icon));
        items.Add(new contextMenuHelper.contextMenuData("sort_desc.png", "Sort Descending", new RoutedEventHandler(btnSortColumnDESC_Click), contextMenuHelper.contextMenuItemType.item_coloured_icon));

        fe.ContextMenu = contextMenuHelper.createContextMenu(mainWin, items);
        fe.ContextMenu = new ContextMenu();
        fe.ContextMenu.Visibility = Visibility.Hidden;
    }

    private void btnExportList_Click(object sender, RoutedEventArgs e)
    {
        exportListViewData(listview, listview.Name);
    }

    public bool getItemClicked(MainWindow mainWin, ref listViewItemDataType itemClicked, object sender, ContextMenuEventArgs e)
    {
        
        if ((((TextBlock)e.OriginalSource).DataContext as listViewItemDataType == null))
        {
            if ((((TextBlock)e.OriginalSource).DataContext as listViewDataType == null))
            {
                e.Handled = true;
                return false;
            }
            else if (!(e.OriginalSource as TextBlock == null))
            {
                buildHeaderContextMenu(mainWin, sender, e);
                e.Handled = true;
                return false;
            }
            else
            {
                // scroll bar or something else clicked
                e.Handled = true;
                return false;
            }
        }
        itemClicked = (listViewItemDataType)((TextBlock)e.OriginalSource).DataContext;
        return true;
    }
    public static void autoResizeListBoxCols(ref ListView lst, ref listViewDataType data)
    {
        int i;
        GridView grid = (GridView)lst.View;
        double height = lst.Height;
        double maxheight = lst.MaxHeight;
        if ((double.IsNaN(lst.Height) == true))
        {
            lst.Height = 9999999999;
            lst.MaxHeight = 9999999999;
            maxheight = double.PositiveInfinity;
        }
        int colId = 0;


        try
        {
            for (i = grid.Columns.Count - data.Columns.Count; i <= grid.Columns.Count - 1; i++)
            {
                if (grid.Columns[i].Header.ToString() != "")
                {
                    if ((double.IsNaN(grid.Columns[i].Width)))
                    {
                        grid.Columns[i].Width = grid.Columns[i].ActualWidth;
                        grid.Columns[i].Width = double.NaN;
                    }
                }
                else
                    grid.Columns[i].Width = 32;
                if ((data.Columns[colId].filter != ""))
                {
                    data.columnClicked = grid.Columns[i];
                    if ((data.Columns[colId].filterExact))
                    {
                        if ((data.Columns[colId].filterInclude))
                            data.btnFilterExact_Complete(data.Columns[colId].filter);
                        else
                            data.btnFilterExcludeExact_Complete(data.Columns[colId].filter);
                    }
                    else if ((data.Columns[colId].filterInclude))
                        data.btnFilter_Complete(data.Columns[colId].filter);
                    else
                        data.btnFilterExclude_Complete(data.Columns[colId].filter);
                }
                colId = colId + 1;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fatal Error resizing columns: " + ex.Message);
        }

        if ((grid.Columns.Count - data.Columns.Count == 2))
        {
            grid.Columns[0].Width = 32;
            grid.Columns[1].Width = 28;
        }
        if ((grid.Columns.Count - data.Columns.Count == 1))
            grid.Columns[0].Width = 32;
        lst.Height = height;
        lst.MaxHeight = maxheight;

        gridViewHelper.GridViewApplyLastSortOrder(lst, data);
    }

    public void exportListViewData(ListView l, string reportHeader)
    {
        reportName = reportHeader;

        if ((l.Items.Count == 0))
        {
            MessageBox.Show("There are no items to export", "", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        GridView gridToExport = (GridView)l.View;

        columnsToExportId = new List<int>();
        int i;
        int j;
        for (i = 0; i <= gridToExport.Columns.Count - 1; i++)
        {
            if ((gridToExport.Columns[i].Header.ToString() != ""))
            {
                for (j = 0; j <= ((listViewDataType)listview.DataContext).Columns.Count; j++)
                {
                    if ((((listViewDataType)listview.DataContext).Columns[j].data == gridToExport.Columns[i].Header.ToString()))
                    {
                        columnsToExportId.Add(j);
                        break;
                    }
                }
            }
        }
        if ((popUps.IsOpen()))
            ((listViewDataType)listview.DataContext).mainWindow.enablePopUp(false);
        else
            ((listViewDataType)listview.DataContext).mainWindow.enableForm(false);
        ((listViewDataType)listview.DataContext).mainWindow.updateProgress(0, 1);
        ((listViewDataType)listview.DataContext).mainWindow.updateProgressLabel("Exporting List");
        ((listViewDataType)listview.DataContext).mainWindow.panelSmallProgress.Visibility = Visibility.Visible;
        bgWorkExportList.RunWorkerAsync();
    }

    private void bgWorkExportList_DoWork(object sender, DoWorkEventArgs e)
    {
        listViewDataType lstData;

        int i;
        int j;
        string csv = "";
        string row = "";

        lstData = this;

        if ((lstData.Items.Count > 0))
        {
            lstData.mainWindow.updateProgressLabel("Exporting Rows");
            for (i = 0; i <= lstData.Columns.Count - 1; i++)
            {
                if ((row != ""))
                    row = row + '\t';
                row = row + lstData.Columns[columnsToExportId[i]].data;
            }
            csv = csv + row;

            for (i = 0; i <= lstData.Items.Count - 1; i++)
            {
                lstData.mainWindow.updateProgressLabel("processing row " + (i + 1) + " of " + lstData.Items.Count);
                lstData.mainWindow.updateProgress(i, lstData.Items.Count);
                row = "";
                for (j = 0; j <= lstData.Columns.Count - 1; j++)
                {
                    if ((row != ""))
                        row = row + '\t';
                    row = row + lstData.Items[i].SubItems[columnsToExportId[j]].data;
                }
                csv = csv + "\r\n" + row;
            }
            lstData.mainWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                Clipboard.SetDataObject(csv);
            }));
            lstData.mainWindow.updateProgress(0, 1);
            lstData.mainWindow.updateProgressLabel("Opening Excel");
            lstData.mainWindow.xlApp = xlStuff.getExcelinstance();
            lstData.mainWindow.xlApp.Visible = false;
            lstData.mainWindow.xlApp.ScreenUpdating = false;
            Microsoft.Office.Interop.Excel.Workbook newWb;
            newWb = lstData.mainWindow.xlApp.Workbooks.Add();
            try
            {
                string sheetName = "Report";
                if ((sheetName.Length > 20))
                    sheetName = sheetName.Substring(0, 20);
                newWb.Sheets[1].Name = sheetName;
                newWb.Sheets[1].Range["A1"].Select();
                lstData.mainWindow.xlApp.ActiveSheet.Paste();

                xlStuff.formatWorkSheetAsTable(lstData.mainWindow, newWb.Sheets[1], reportName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong exporting the table to Excel: " + ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            lstData.mainWindow.updateProgressLabel("Releasing Excel");
            lstData.mainWindow.updateProgress(1, 1);
            newWb.Activate();
            lstData.mainWindow.xlApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;
            lstData.mainWindow.xlApp.ActiveWindow.Activate();
            lstData.mainWindow.xlApp.Visible = true;
            lstData.mainWindow.xlApp.ScreenUpdating = true;
            xlStuff.releaseExcelObject(lstData.mainWindow.xlApp, newWb, null/* TODO Change to default(_) if this is not a reference type */, false);
            lstData.mainWindow.xlApp = null;
        }
        else
        {
            if ((popUps.IsOpen()))
                lstData.mainWindow.enablePopUp(true);
            else
                lstData.mainWindow.enableForm(true);
            lstData.mainWindow.panelSmallProgress.Visibility = Visibility.Hidden;
            MessageBox.Show("There are no items to export", "No Items", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void bgWorkExportList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if ((popUps.IsOpen()))
            ((listViewDataType)listview.DataContext).mainWindow.enablePopUp(true);
        else
            ((listViewDataType)listview.DataContext).mainWindow.enableForm(true);
        ((listViewDataType)listview.DataContext).mainWindow.panelSmallProgress.Visibility = Visibility.Hidden;
    }
}

