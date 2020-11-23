using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using PSPo2i_Save_Editor;
using System.Windows.Controls.Primitives;

public class GridViewColumnData
{
    public int origindex;
    public int index;
    public GridViewColumn element;
}

public class GridViewColumnBehavior : Behavior<GridView>
{
    private object _syncLock = new object();
    protected override void OnAttached()
    {
        if (AssociatedObject != null)
        {
            if (AssociatedObject.Columns != null)
                InitializeColumns(AssociatedObject.Columns);
            base.OnAttached();
        }
    }

    public ObservableCollection<GridViewColumnData> ColumnsCollection
    {
        get
        {
            return (ObservableCollection<GridViewColumnData>)GetValue(ColumnsCollectionProperty);
        }
        set
        {
            SetValue(ColumnsCollectionProperty, value);
        }
    }

    public static readonly DependencyProperty ColumnsCollectionProperty = DependencyProperty.Register("ColumnsCollection", typeof(ObservableCollection<GridViewColumnData>), typeof(GridViewColumnBehavior), new PropertyMetadata(null, new PropertyChangedCallback(Columns_Changed)));

    private static void Columns_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var b = d as GridViewColumnBehavior;
        if (b == null)
            return;
        b.SetupColumns((ObservableCollection<GridViewColumnData>)e.NewValue);
    }


    public void InitializeColumns(ObservableCollection<GridViewColumn> oldColumns)
    {
        if (oldColumns.Count == 0)
            oldColumns.CollectionChanged += Columns_CollectionChanged;
    }

    public void SetupColumns(ObservableCollection<GridViewColumnData> oldColumns)
    {
        if (oldColumns != null)
            oldColumns.CollectionChanged -= Columns_CollectionChanged;

        if ((ColumnsCollection?.Count ?? 0) == 0)
            return;
        AssociatedObject.Columns.Clear();

        foreach (var column in ColumnsCollection.OrderBy(c => c.index))
            ColumnsCollection.Add(column);

        oldColumns.CollectionChanged += Columns_CollectionChanged;
    }

    private void Columns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        var columnList = AssociatedObject.Columns.Select((c, i) => new
        {
            Index = i,
            Element = c.Header?.ToString()
        }).ToLookup(ci => ci.Element, ci => ci.Index);

        var vtree = AssociatedObject;
        if ((e.Action == NotifyCollectionChangedAction.Add))
        {
            if ((ColumnsCollection == null))
                ColumnsCollection = new ObservableCollection<GridViewColumnData>();
            GridViewColumnData c = new GridViewColumnData();
            c.origindex = ColumnsCollection.Count;
            c.index = ColumnsCollection.Count;
            c.element = (GridViewColumn)e.NewItems[0];
            ColumnsCollection.Add(c);
        }
        foreach (GridViewColumnData c in ColumnsCollection)
            // store the users specified index in the columnList
            c.index = columnList[c.element.Header.ToString()].FirstOrDefault();
    }
}

public class gridViewHelper
{
    public static GridViewColumn getColumn(string header, listViewDataType listViewData)
    {
        GridViewColumn result = null;
        GridView gridview = (GridView)listViewData.listview.View;
        int i;
        for (i = 0; i <= gridview.Columns.Count - 1; i++)
        {
            if ((gridview.Columns[i].Header.ToString() == header))
            {
                result = gridview.Columns[i];
                break;
            }
        }
        return result;
    }
    public static int getColumnID(string header, listViewDataType listViewData)
    {
        int i;
        for (i = 0; i <= listViewData.Columns.Count - 1; i++)
        {
            if ((listViewData.Columns[i].data == header))
                return i;
        }
        return -1;
    }
    public static void grid_Sorting(ListView sender, listViewDataType listViewData, ListSortDirection direction, GridViewColumnHeader headerClicked = null, GridViewColumn clm = null)
    {
        if ((clm == null))
        {
            if ((headerClicked == null))
            {
                MessageBox.Show("You must provide either a column header or a column for gridview sorting", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            clm = headerClicked.Column;
        }
        if (clm != null)
        {
            IValueConverter converter = null/* TODO Change to default(_) if this is not a reference type */;
            if (clm.DisplayMemberBinding != null)
            {
                Binding binding = clm.DisplayMemberBinding as Binding;
                if (binding.Converter != null)
                    converter = binding.Converter;
            }
            else if (!(clm.CellTemplate == null))
            {
                DataTemplate template = clm.CellTemplate;
                Grid grid = (Grid)clm.CellTemplate.LoadContent();
                TextBlock textBlock = grid.Children.OfType<TextBlock>().FirstOrDefault();
                Binding binding = BindingOperations.GetBinding(textBlock, TextBlock.TextProperty);
                if (binding.Converter != null)
                    converter = binding.Converter;
            }
            if ((clm.Header == null))
                return;
            int dataCol = getColumnID(clm.Header.ToString(), listViewData);

            if (converter != null)
            {
                ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(sender.ItemsSource);
                if (lcv != null)
                {
                    lcv.CustomSort = new ComparerWithComparer(converter, direction, dataCol);

                    if ((sender.SelectionMode == SelectionMode.Single & listViewData.SelectedListItem != null))
                        sender.ScrollIntoView(listViewData.SelectedListItem);
                }
            }
        }
    }

    public static void GridViewApplyLastSortOrder(ListView listView, listViewDataType listViewData)
    {
        if (!(listViewData._lastColumnHeaderClicked == null))
            gridViewHelper.grid_Sorting(listView, listViewData, listViewData._lastSortDirection, null/* TODO Change to default(_) if this is not a reference type */, listViewData._lastColumnHeaderClicked);
    }

    public static void updateGridViewColumnHeaderStyle(MainWindow mainForm, listViewDataType listViewData, ListSortDirection direction, GridViewColumn column)
    {
        int colId = gridViewHelper.getColumnID(column.Header.ToString(), listViewData);
        if ((colId == -1))
            return;
        string filter = listViewData.Columns[colId].filter;
        if ((filter != ""))
            filter = "Filter";

        // set the new theme
        if (direction == ListSortDirection.Ascending)
            column.HeaderContainerStyle = (Style)mainForm.FindResource("GridViewColumnHeaderStyleSortASC" + filter);
        else
            column.HeaderContainerStyle = (Style)mainForm.FindResource("GridViewColumnHeaderStyleSortDESC" + filter);

        // reset the last column
        if (listViewData._lastColumnHeaderClicked != null && listViewData._lastColumnHeaderClicked.Header != column.Header)
        {
            colId = gridViewHelper.getColumnID(listViewData._lastColumnHeaderClicked.Header.ToString(), listViewData);
            filter = listViewData.Columns[colId].filter;
            if ((filter != ""))
                filter = "Filter";
            listViewData._lastColumnHeaderClicked.HeaderContainerStyle = (Style)mainForm.FindResource("GridViewColumnHeaderStyle" + filter);
        }

        listViewData._lastColumnHeaderClicked = column;
        listViewData._lastSortDirection = direction;
    }


    public static void GridViewColumnResized(object sender, DragDeltaEventArgs e)
    {
        if ((e.OriginalSource as Thumb == null))
            return;
        if ((((Thumb)e.OriginalSource).TemplatedParent as GridViewColumnHeader == null))
            return;
        GridViewColumnHeader header = (GridViewColumnHeader)((Thumb)e.OriginalSource).TemplatedParent;
        if ((header == null))
            return;
        if ((header.Content == null))
            header.Column.Width = 30;
        else if ((header.Column.ActualWidth < 70))
            header.Column.Width = 70;
    }

    public static void GridViewColumnHeaderClicked(MainWindow mainForm, ListView listView, listViewDataType listViewData, object sender, RoutedEventArgs e)
    {
        if ((e.OriginalSource as GridViewColumnHeader == null))
            return;
        GridViewColumnHeader headerClicked = (GridViewColumnHeader)e.OriginalSource;

        if ((headerClicked.Content == null))
            return;
        ListSortDirection direction;

        if (headerClicked != null)
        {
            if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
            {
                if ((listViewData._lastColumnHeaderClicked == null))
                    direction = ListSortDirection.Ascending;
                else if ((headerClicked.Content != listViewData._lastColumnHeaderClicked.Header))
                    direction = ListSortDirection.Ascending;
                else if (listViewData._lastSortDirection == ListSortDirection.Ascending)
                    direction = ListSortDirection.Descending;
                else
                    direction = ListSortDirection.Ascending;

                var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;
                grid_Sorting(listView, listViewData, direction, (GridViewColumnHeader)e.OriginalSource);
                updateGridViewColumnHeaderStyle(mainForm, listViewData, direction, headerClicked.Column);
            }
        }
    }
}
