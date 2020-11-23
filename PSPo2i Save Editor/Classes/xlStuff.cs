using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Linq;
using PSPo2i_Save_Editor;

class xlStuff
{
    public static void formatWorkSheetAsTable(MainWindow mainForm, Microsoft.Office.Interop.Excel.Worksheet sh, string reportName)
    {
        Microsoft.Office.Interop.Excel.Range r;
        string lastCol = xlStuff.lastColumn(sh, 1);
        // format table header
        mainForm.updateProgress(1, 5);
        mainForm.updateProgressLabel("Formatting Excel Table Header");
        r = sh.Range["A1:" + lastCol + "1"];
        xlStuff.shadeRange(r, MainWindow.getResourceVal(mainForm, "ColorMedium"), MainWindow.getResourceVal(mainForm, "ColorHeaderText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorInactiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorInactiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorInactiveText"));
        xlStuff.setAlignment(r, Microsoft.Office.Interop.Excel.Constants.xlLeft, Microsoft.Office.Interop.Excel.Constants.xlCenter, false, false, 1);
        sh.Rows["1:1"].RowHeight = 30;
        sh.Rows["1:1"].AutoFilter();

        // format table rows
        mainForm.updateProgress(2, 5);
        mainForm.updateProgressLabel("Formatting Excel Table Rows");
        r = sh.Range["A2:" + lastCol + xlStuff.lastRow(sh, "A")];
        xlStuff.shadeRange(r, MainWindow.getResourceVal(mainForm, "ColorDark"), MainWindow.getResourceVal(mainForm, "ColorInactiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorInactiveText"));
        xlStuff.setAlignment(r, Microsoft.Office.Interop.Excel.Constants.xlLeft, Microsoft.Office.Interop.Excel.Constants.xlCenter, false, false, 1);
        sh.Rows["1:" + xlStuff.lastRow(sh, "A")].RowHeight = 20;


        // add the report header
        mainForm.updateProgress(3, 5);
        mainForm.updateProgressLabel("Creating Report Header");
        sh.Rows["1:5"].Select();
        mainForm.xlApp.Selection.Insert(Shift: Microsoft.Office.Interop.Excel.XlDirection.xlDown, CopyOrigin: Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
        r = sh.Range["A1:" + lastCol + "5"];
        xlStuff.shadeRange(r, MainWindow.getResourceVal(mainForm, "ColorLight"), MainWindow.getResourceVal(mainForm, "ColorHeaderText"));
        r = sh.Range["A1:" + lastCol + xlStuff.lastRow(sh, "A")];
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));
        xlStuff.drawBorder(r, Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, MainWindow.getResourceVal(mainForm, "ColorActiveText"));


        sh.Range[lastCol + "2:" + lastCol + "4"].Font.Size = 10;
        xlStuff.setAlignment(sh.Range[lastCol + "2:" + lastCol + "4"], Microsoft.Office.Interop.Excel.Constants.xlLeft, Microsoft.Office.Interop.Excel.Constants.xlCenter, false, false, 0);

        sh.Range[lastCol + "2:" + lastCol + "4"].Offset[0, -1].Font.Size = 10;
        sh.Range[lastCol + "2:" + lastCol + "4"].Offset[0, -1].Font.Bold = true;
        xlStuff.setAlignment(sh.Range[lastCol + "2:" + lastCol + "4"].Offset[0, -1], Microsoft.Office.Interop.Excel.Constants.xlRight, Microsoft.Office.Interop.Excel.Constants.xlCenter, false, false, 0);

        xlStuff.setAlignment(sh.Range["A4"], Microsoft.Office.Interop.Excel.Constants.xlLeft, Microsoft.Office.Interop.Excel.Constants.xlCenter, false, false, 1);
        sh.Range["A4"].Font.Size = 14;
        sh.Range["A4"].Font.Bold = true;
        sh.Range["A4"].Value = reportName;
        sh.Rows["1:5"].RowHeight = 15;

        mainForm.updateProgress(4, 5);
        mainForm.updateProgressLabel("Finishing Up");
        // insert the logo
        insertLogo(mainForm, sh, 0.78f, 10, 15);
        // make the columns fit
        sh.Columns["A:XFD"].EntireColumn.AutoFit();
        // set the cell protection
        sh.Cells.Select();
        mainForm.xlApp.Selection.Locked = false;
        sh.Range["A1:" + lastCol + "5"].Select();
        mainForm.xlApp.Selection.Locked = true;
        sh.Protect(DrawingObjects: true, Contents: true, Scenarios: false, AllowFormattingCells: true, AllowFormattingColumns: true, AllowFormattingRows: true, AllowInsertingColumns: true, AllowInsertingRows: true, AllowInsertingHyperlinks: true, AllowDeletingColumns: true, AllowDeletingRows: true, AllowSorting: true, AllowFiltering: true, AllowUsingPivotTables: true);
        sh.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlUnlockedCells;

        sh.Range["A7"].Select();
        mainForm.xlApp.ActiveWindow.FreezePanes = true;
        sh.Range["A6"].Select();
        mainForm.updateProgress(5, 5);
        mainForm.updateProgressLabel("Formatting Completed");
    }
    public static void insertLogo(MainWindow mainForm, Microsoft.Office.Interop.Excel.Worksheet sh, float scale, int leftPos, int topPos)
    {
        string tempImgPath = System.IO.Path.Combine(mainForm.appDataPath, "logo.png");
        appImages.exportResourceImageToFile("Vestas_neg.png", tempImgPath);
        sh.Pictures().Insert(tempImgPath).Name = "PicLogo";
        Microsoft.Office.Interop.Excel.ShapeRange shr = sh.Shapes.Range["PicLogo"];
        shr.Select();
        mainForm.xlApp.Selection.Placement = Microsoft.Office.Interop.Excel.XlPlacement.xlFreeFloating;
        shr.Left = leftPos;
        shr.Top = topPos;
        shr.ScaleHeight(scale, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft);
        shr.ScaleWidth(scale, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft);
    }
    public static bool workSheetExists(Microsoft.Office.Interop.Excel.Workbook wb, string name)
    {
        foreach (Microsoft.Office.Interop.Excel.Worksheet sh in wb.Sheets)
        {
            if ((sh.Name == name))
            {
                return true;
            }
        }
        return false;
    }
    public static string lastColumn(Microsoft.Office.Interop.Excel.Worksheet ws, int row)
    {
        int lastColInt;
        lastColInt = ws.Range["XFD" + row].End[Microsoft.Office.Interop.Excel.XlDirection.xlToLeft].Column;
        return ws.Cells[1, lastColInt].Address.split('$')[1];
    }
    public static string lastRow(Microsoft.Office.Interop.Excel.Worksheet ws, string column)
    {
        return ws.Range[column + "1048576"].End[Microsoft.Office.Interop.Excel.XlDirection.xlUp].Row.ToString();
    }
    public static dynamic fixBorderWeightForStyle(Microsoft.Office.Interop.Excel.XlBorderWeight weight, Microsoft.Office.Interop.Excel.XlLineStyle style)
    {
        if ((style == Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble))
            weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
        return weight;
    }
    public static void drawBorder(Microsoft.Office.Interop.Excel.Range r, Microsoft.Office.Interop.Excel.XlBordersIndex index, Microsoft.Office.Interop.Excel.XlBorderWeight weight, Microsoft.Office.Interop.Excel.XlLineStyle style, string borderColorHex)
    {
        byte[] rgb_data;
        rgb_data = hexToRGB(borderColorHex);
        if ((style != Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone))
        {
            {
                var withBlock = r.Borders[index];
                withBlock.LineStyle = style;
                withBlock.Color = Color.FromRgb(rgb_data[0], rgb_data[1], rgb_data[2]);
                withBlock.TintAndShade = 0;
                withBlock.Weight = fixBorderWeightForStyle(weight, style);
            }
        }
    }
    public static void setAlignment(Microsoft.Office.Interop.Excel.Range r, Microsoft.Office.Interop.Excel.Constants HorizontalAlignment, Microsoft.Office.Interop.Excel.Constants VerticalAlignment, bool WrapText, bool MergeCells, int IndentLevel)
    {
        bool AddIndent = false;
        if ((IndentLevel > 0))
            AddIndent = true;
        {
            var withBlock = r;
            withBlock.HorizontalAlignment = HorizontalAlignment;
            withBlock.VerticalAlignment = VerticalAlignment;
            withBlock.WrapText = WrapText;
            withBlock.Orientation = 0;
            withBlock.AddIndent = AddIndent;
            withBlock.IndentLevel = IndentLevel;
            withBlock.ShrinkToFit = false;
            withBlock.ReadingOrder = (int)Microsoft.Office.Interop.Excel.Constants.xlContext;
            withBlock.MergeCells = MergeCells;
        }
    }
    public static void shadeRange(Microsoft.Office.Interop.Excel.Range r, string interiorColorHex, string fontColorHex)
    {
        byte[] rgb_data;

        rgb_data = hexToRGB(interiorColorHex);
        r.Interior.Color = Color.FromRgb(rgb_data[0], rgb_data[1], rgb_data[2]);

        rgb_data = hexToRGB(fontColorHex);
        r.Font.Color = Color.FromRgb(rgb_data[0], rgb_data[1], rgb_data[2]);
    }
    public static byte[] hexToRGB(string hex)
    {
        // trim the leading hash off
        if (hex.StartsWith("#"))
            hex = hex.Substring(1, hex.Length - 1);

        // trim the alpha off as we can use that in excel
        if (hex.Length > 6)
            hex = hex.Substring(2, hex.Length - 2);

        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        byte[] result =
        {
            r,
            g,
            b
        };
        return result;
    }

    public static Microsoft.Office.Interop.Excel.Application getExcelinstance(bool newInstance = false)
    {
        if ((newInstance == true))
        {
            return new Microsoft.Office.Interop.Excel.Application();
        }
        Process[] ExcelInstances = Process.GetProcessesByName("EXCEL");
        if (ExcelInstances.Count() == 0)
        {
            return new Microsoft.Office.Interop.Excel.Application();
        }
        try
        {
            Microsoft.Office.Interop.Excel.Application ExcelInstance = System.Runtime.InteropServices.Marshal.GetActiveObject("Microsoft.Office.Interop.Excel.Application") as Microsoft.Office.Interop.Excel.Application;
            if (ExcelInstance == null)
                return new Microsoft.Office.Interop.Excel.Application();
            else if ((ExcelInstance.Workbooks.Count == 0))
            {
                ExcelInstance.Visible = true;
                ExcelInstance.ScreenUpdating = true;
                ExcelInstance.Quit();
                releaseExcelObject(ExcelInstance, null, null, true);
                return new Microsoft.Office.Interop.Excel.Application();
            }
            else
            {
                ExcelInstance.Visible = true;
                return ExcelInstance;
            }
        }
        catch
        {
        }
        return new Microsoft.Office.Interop.Excel.Application();
    }

    public static bool deleteWorkSheet(Microsoft.Office.Interop.Excel.Workbook wb, string name)
    {
        if ((workSheetExists(wb, name) == true))
        {
            return false;
        }
        wb.Sheets[name].Delete();
        return true;
    }

    public static void releaseCOMWs(Microsoft.Office.Interop.Excel.Worksheet o)
    {
        try
        {
            while ((System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0))
            {
            }
        }
        catch
        {
        }

        finally
        {
            o = null;
        }
    }

    public static void releaseCOMWb(Microsoft.Office.Interop.Excel.Workbook o)
    {
        try
        {
            while ((System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0))
            {
            }
        }
        catch
        {
        }

        finally
        {
            o = null/* TODO Change to default(_) if this is not a reference type */;
        }
    }

    public static void releaseCOMApp(Microsoft.Office.Interop.Excel.Application o)
    {
        try
        {
            while ((System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0))
            {
            }
        }
        catch
        {
        }

        finally
        {
            o = null;
        }
    }

    public static void releaseExcelObject(Microsoft.Office.Interop.Excel.Application xlApp, Microsoft.Office.Interop.Excel.Workbook wb, Microsoft.Office.Interop.Excel.Worksheet ws, bool closeExcel)
    {
        if ((closeExcel == true))
        {
            try
            {
                xlApp.Quit();
            }
            catch
            {
            }
        }
        releaseCOMWs(ws);
        releaseCOMWb(wb);
        releaseCOMApp(xlApp);
    }
}
