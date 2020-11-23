using System;
using System.Collections;

public class ComparerWithComparer : IComparer
{
    private System.Windows.Data.IValueConverter converter;
    private System.ComponentModel.ListSortDirection direction;
    private int parameter;

    public ComparerWithComparer(System.Windows.Data.IValueConverter converter, System.ComponentModel.ListSortDirection direction, int param)
    {
        this.converter = converter;
        this.direction = direction;
        this.parameter = param;
    }

    public int Compare(object x, object y)
    {
        string transx = this.converter.Convert(((listViewItemDataType)x).SubItems, typeof(string), parameter, System.Threading.Thread.CurrentThread.CurrentCulture).ToString();
        string transy = this.converter.Convert(((listViewItemDataType)y).SubItems, typeof(string), parameter, System.Threading.Thread.CurrentThread.CurrentCulture).ToString();

        DateTime dateX;
        DateTime dateY;
        if ((DateTime.TryParse(transx, out dateX) & DateTime.TryParse(transy, out dateY)))
        {
            if (direction == System.ComponentModel.ListSortDirection.Ascending)
                return Comparer.Default.Compare((DateTime)dateX, (DateTime)dateY);
            else
                return Comparer.Default.Compare((DateTime)dateX, (DateTime)dateY) * (-1);
        }

        double dblX;
        double dblY;
        if ((double.TryParse(transx, out dblX) & double.TryParse(transy, out dblY)))
        {
            if (direction == System.ComponentModel.ListSortDirection.Ascending)
                return Comparer.Default.Compare(dblX, dblY);
            else
                return Comparer.Default.Compare(dblX, dblY) * (-1);
        }

        long intX;
        long intY;
        if ((long.TryParse(transx, out intX) & long.TryParse(transy, out intY)))
        {
            if (direction == System.ComponentModel.ListSortDirection.Ascending)
                return Comparer.Default.Compare(intX, intY);
            else
                return Comparer.Default.Compare(intX, intY) * (-1);
        }
        if (direction == System.ComponentModel.ListSortDirection.Ascending)
            return Comparer.Default.Compare(transx, transy);
        else
            return Comparer.Default.Compare(transx, transy) * (-1);
    }
}
