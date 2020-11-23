// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.hexAndMathFunctions
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
  public class hexAndMathFunctions
  {
    public string stringToProper(string str)
    {
      bool flag = true;
      string str1 = "";
      for (int startIndex = 0; startIndex < str.Length; ++startIndex)
      {
        string str2 = str.Substring(startIndex, 1);
        if (flag)
        {
          flag = false;
          str1 += str2.ToUpper();
        }
        else
          str1 += str2;
        if (str2 == " ")
          flag = true;
      }
      return str1;
    }

    public int getPercentage(int thisval, int targetVal) => (int) Decimal.Round((Decimal) thisval / (Decimal) targetVal * 100M, 0);

    public string decimalByteConvert(int byte_decimal, string return_type)
    {
      string str = string.Format("{0:X}", (object) byte_decimal);
      while (str.Length < 2)
        str = "0" + str;
      int int32 = Convert.ToInt32(str, 16);
      return return_type == "hex" ? str : char.ConvertFromUtf32(int32);
    }

    public string reversehex(string hex, int len)
    {
      string str1 = "";
      if (hex != null)
      {
        while (hex.Length < len)
          hex += "0";
        for (int startIndex = len - 2; startIndex >= 0; startIndex -= 2)
        {
          string str2 = hex.Substring(startIndex, 2);
          str1 += str2;
        }
      }
      else
        str1 = hex;
      while (str1.Length < len)
        str1 += "0";
      return str1;
    }

    public string reversestring(string str)
    {
      string str1 = "";
      for (int startIndex = str.Length - 1; startIndex >= 0; --startIndex)
        str1 += str.Substring(startIndex, 1);
      return str1;
    }

    public string halfByteSwap(string hex)
    {
      string str = "";
      if (((Decimal) hex.Length / 2M).ToString() != (hex.Length / 2).ToString())
      {
        int num = (int) MessageBox.Show("Trying to halfByte swap an uneven (" + (object) hex.Length + ") amount of bytes!");
        return "";
      }
      for (int index = 0; index < hex.Length / 2; ++index)
        str = str + hex.Substring(1 + index * 2, 1) + hex.Substring(index * 2, 1);
      return str;
    }

    public int hexToInt(string hex)
    {
      hex = this.reversehex(hex, hex.Length);
      return int.Parse(hex, NumberStyles.HexNumber);
    }

    public string hex2binary(string hexvalue) => Convert.ToString(Convert.ToInt32(hexvalue, 16), 2);

    public string stringToHexadecimal(string Data, int bytes)
    {
      string str = "";
      foreach (char ch in Data.ToCharArray())
      {
        string hex = string.Format("{0:X4}", (object) Convert.ToUInt32(ch));
        str += this.reversehex(hex, 4);
      }
      while (str.Length < bytes)
        str += "00";
      return str;
    }

    public string addCommasToHex(string hex)
    {
      string str = "";
      int num = 0;
      for (int startIndex = 0; startIndex < hex.Length; ++startIndex)
      {
        str += hex.Substring(startIndex, 1);
        if (startIndex != hex.Length - 1)
        {
          ++num;
          if (num == 2)
          {
            num = 0;
            str += ",";
          }
        }
      }
      return str;
    }

    public string convertHexToEncryptionKey(string hex)
    {
      if (hex.Length < 16)
      {
        int num = (int) MessageBox.Show("The application encoded key is incorrect");
        Environment.Exit(0);
      }
      string str = "";
      hex = this.addCommasToHex(hex);
      string[] strArray = hex.Split(',');
      for (int index = 0; index < 8; ++index)
      {
        uint num = uint.Parse(strArray[index], NumberStyles.HexNumber);
        str += Encoding.UTF32.GetString(BitConverter.GetBytes(num));
      }
      return str;
    }

    public string hexCsvToNiceDisplay(string csv, int bytesPerRow)
    {
      string[] strArray = csv.Split(',');
      int num = 0;
      string str1 = "";
      for (int index = 0; index < strArray.Length; ++index)
      {
        string str2 = str1 + strArray[index];
        ++num;
        if (num >= bytesPerRow)
        {
          num = 0;
          str1 = str2 + "\r\n";
        }
        else
          str1 = str2 + " ";
      }
      return str1;
    }
  }
}
