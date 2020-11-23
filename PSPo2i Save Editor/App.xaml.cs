using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace PSPo2i_Save_Editor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        public static string groupSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;

        public static void Thumb_DragDelta(object sender, DragCompletedEventArgs e)
        {
            GridViewColumnHeader header = (GridViewColumnHeader)((Thumb)sender).TemplatedParent;
            if ((header.Column.ActualWidth < 30))
                header.Column.Width = 30;
        }
        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
            ScrollBar.IsEnabledProperty.OverrideMetadata(typeof(ScrollBar), new UIPropertyMetadata(true, null, new CoerceValueCallback(ScrollBarForceEnabled)));
        }

        private static object ScrollBarForceEnabled(DependencyObject source, object value)
        {
            return true;
        }
        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            try
            {
                // gets the main Assembly
                var parentAssembly = Assembly.GetExecutingAssembly();
                // args.Name will be something like this
                // [ MahApps.Metro, Version=1.1.3.81, Culture=en-US, PublicKeyToken=null ]
                // so we take the name of the Assembly (MahApps.Metro) then add (.dll) to it
                var finalname = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
                // here we search the resources for our dll and get the first match
                var ResourcesList = parentAssembly.GetManifestResourceNames();
                string OurResourceName = null;
                // (you can replace this with a LINQ extension like [Find] or [First])
                for (int i = 0; i <= ResourcesList.Count() - 1; i++)
                {
                    var name = ResourcesList[i];
                    if (name.EndsWith(finalname))
                    {
                        // Get the name then close the loop to get the first occuring value
                        OurResourceName = name;
                        break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(OurResourceName))
                {
                    // get a stream representing our resource then load it as bytes
                    using (Stream stream = parentAssembly.GetManifestResourceStream(OurResourceName))
                    {
                        // in vb.net use [ New Byte(stream.Length - 1) ]
                        // in c#.net use [ new byte[stream.Length]; ]
                        byte[] block = new byte[stream.Length - 1 + 1];
                        stream.Read(block, 0, block.Length);
                        stream.Close();
                        return Assembly.Load(block);
                    }
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                if ((args.Name != "itextsharp.LicenseKey"))
                    MessageBox.Show("Failed to resolve assembly " + args.Name + "\r\n" + "\r\n" + ex.Message);
                return null;
            }
        }
    }


    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if (((int)parameter > -1))
                return ((List<listViewColumnDataType>)value)[(int)parameter].data;
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            return value.ToString();
        }
    }

    public class ListToNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if (((List<listViewColumnDataType>)value)[(int)parameter].data.Trim() == "N/A")
                return ((List<listViewColumnDataType>)value)[(int)parameter].data.Trim();
            return String.Format("{0:n0}", ((List<listViewColumnDataType>)value)[(int)parameter].data.Trim());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(App.groupSeparator, "");
            if ((newval == ""))
                newval = "0";
            return long.Parse(newval);
        }
    }

    public class ListToDecimalNumberBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if (((List<listViewColumnDataType>)value)[(int)parameter].data.Trim() == "N/A")
                return ((List<listViewColumnDataType>)value)[(int)parameter].data.Trim();
            double number = Math.Round(System.Convert.ToDouble(((List<listViewColumnDataType>)value)[(int)parameter].data.Trim()), 2);
            if ((number < 0))
                return Application.Current.MainWindow.FindResource("ControlTextNegative");
            else
                return Application.Current.MainWindow.FindResource("ControlTextPositive");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(App.groupSeparator, "");
            if ((newval == ""))
                newval = "0";
            return System.Convert.ToDouble(newval).ToString();
        }
    }

    public class ListToDecimalNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if (((List<listViewColumnDataType>)value)[(int)parameter].data.Trim() == "N/A")
                return ((List<listViewColumnDataType>)value)[(int)parameter].data.Trim();
            ((List<listViewColumnDataType>)value)[(int)parameter].data = ((List<listViewColumnDataType>)value)[(int)parameter].data.ToString().Replace(App.groupSeparator, "");
            return String.Format("{0:n2}", Math.Round(System.Convert.ToDouble(((List<listViewColumnDataType>)value)[(int)parameter].data.Trim()), 2));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(App.groupSeparator, "");
            if ((newval == ""))
                newval = "0";
            return System.Convert.ToDouble(newval).ToString();
        }
    }

    public class ListToLongDecimalNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if (((List<listViewColumnDataType>)value)[(int)parameter].data.Trim() == "N/A")
                return ((List<listViewColumnDataType>)value)[(int)parameter].data.Trim();
            ((List<listViewColumnDataType>)value)[(int)parameter].data = ((List<listViewColumnDataType>)value)[(int)parameter].data.ToString().Replace(App.groupSeparator, "");
            return String.Format("{0:n4}", decimal.Parse(((List<listViewColumnDataType>)value)[(int)parameter].data.Trim()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(App.groupSeparator, "");
            if ((newval == ""))
                newval = "0";
            return System.Convert.ToDecimal(newval).ToString();
        }
    }

    public class ListToPercentageNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((((List<listViewColumnDataType>)value)[(int)parameter].data == null) | (((List<listViewColumnDataType>)value)[(int)parameter].data.Trim() == ""))
                return "00" + App.decimalSeparator + "00%";
            string newVal = String.Format("{0:n2}%", Math.Round(System.Convert.ToDouble(((List<listViewColumnDataType>)value)[(int)parameter].data.Trim()), 2));
            return newVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(App.groupSeparator, "");
            newval = ((List<listViewColumnDataType>)value)[(int)parameter].data.Replace(App.groupSeparator, "");
            if ((newval == ""))
                newval = "0" + App.decimalSeparator + "00";
            return System.Convert.ToDouble(newval).ToString();
        }
    }

    public class ValueToWholeNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if ((value == null) | (value.ToString().Trim() == ""))
                return "0";
            try
            {
                return String.Format("{0:n0}", long.Parse(value.ToString().Trim()));
            }
            catch
            {
                return "0";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(App.groupSeparator, "");
            if ((newval == ""))
                newval = "0";
            try
            {
                return long.Parse(newval);
            }
            catch
            {
                return "0";
            }
        }
    }

    public class ValueToWholeNumberConverterNoComma : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if ((value == null) | (value.ToString().Trim() == ""))
                return "0";
            try
            {
                return String.Format("{0:n0}", value.ToString().Trim());
            }
            catch
            {
                return "0";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(" ", "");
            if ((newval == ""))
                newval = "0";
            try
            {
                return long.Parse(newval);
            }
            catch
            {
                return "0";
            }
        }
    }

    public class ValueToDecimalNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if ((value == null) | (value.ToString().Trim() == ""))
                return "0" + App.decimalSeparator + "00";
            try
            {
                return String.Format("{0:n2}", Double.Parse(value.ToString().Trim()));
            }
            catch
            {
                return "0" + App.decimalSeparator + "00";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(App.groupSeparator, "");
            if ((newval == ""))
                newval = "0";
            return System.Convert.ToDouble(newval).ToString();
        }
    }

    public class ValueToLongDecimalNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            string newVal;
            if ((value == null) | (value.ToString().Trim() == ""))
                return System.Convert.ToDouble("0" + App.decimalSeparator + "0000").ToString();

            if ((value.ToString().Contains(App.decimalSeparator)))
            {
                string[] splitval = value.ToString().Split(App.decimalSeparator[0]);

                newVal = String.Format("{0:n0}", long.Parse(splitval[0]));
                if ((newVal == ""))
                    newVal = "0";
                newVal = newVal + App.decimalSeparator + splitval[1];
            }
            else
                newVal = String.Format("{0:n4}", decimal.Parse(value.ToString().Trim()));
            return newVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(App.groupSeparator, "");
            if ((newval == ""))
                newval = "0" + App.decimalSeparator + "00";
            return System.Convert.ToDecimal(newval).ToString();
        }
    }

    public class ValueToPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Only allow conversion if the correct TargetType is passed in.
            // (This is optional)
            if ((value == null) | (value.ToString().Trim() == ""))
                return "00" + App.decimalSeparator + "00%";
            string newVal = String.Format("{0:n2}%", Math.Round(System.Convert.ToDouble(value.ToString().Trim()), 2));
            return newVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used, so throw exception if this method is called.
            string newval = value.ToString().Trim();
            newval = value.ToString().Replace(",", "");
            newval = value.ToString().Replace("%", "");
            if ((newval == ""))
                newval = "0";
            return ((System.Convert.ToDouble(newval) / 100).ToString());
        }
    }
}