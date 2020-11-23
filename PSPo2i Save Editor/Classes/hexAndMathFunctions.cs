using System;
using System.Globalization;
using System.Text;
using System.Windows;

namespace PSPo2i_Save_Editor
{
    public class hexAndMathFunctions
    {
        public static string stringToProper(string str)
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

        public static int getPercentage(int thisval, int targetVal) => (int)Decimal.Round((Decimal)thisval / (Decimal)targetVal * 100M, 0);

        public static string decimalByteConvert(int byte_decimal, string return_type)
        {
            string str = string.Format("{0:X}", (object)byte_decimal);
            while (str.Length < 2)
                str = "0" + str;
            int int32 = Convert.ToInt32(str, 16);
            return return_type == "hex" ? str : char.ConvertFromUtf32(int32);
        }

        public static string reversehex(string hex, int len)
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

        public static string reversestring(string str)
        {
            string str1 = "";
            for (int startIndex = str.Length - 1; startIndex >= 0; --startIndex)
                str1 += str.Substring(startIndex, 1);
            return str1;
        }

        public static string halfByteSwap(string hex)
        {
            string str = "";
            if (((Decimal)hex.Length / 2M).ToString() != (hex.Length / 2).ToString())
            {
                MessageBox.Show("Trying to halfByte swap an uneven (" + (object)hex.Length + ") amount of bytes!");
                return "";
            }
            for (int index = 0; index < hex.Length / 2; ++index)
                str = str + hex.Substring(1 + index * 2, 1) + hex.Substring(index * 2, 1);
            return str;
        }

        public static int hexToInt(string hex)
        {
            hex = reversehex(hex, hex.Length);
            return int.Parse(hex, NumberStyles.HexNumber);
        }

        public static string hex2binary(string hexvalue) => Convert.ToString(Convert.ToInt32(hexvalue, 16), 2);

        public static string stringToHexadecimal(string Data, int bytes)
        {
            string str = "";
            foreach (char ch in Data.ToCharArray())
            {
                string hex = string.Format("{0:X4}", (object)Convert.ToUInt32(ch));
                str += reversehex(hex, 4);
            }
            while (str.Length < bytes)
                str += "00";
            return str;
        }

        public static string addCommasToHex(string hex)
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

        public static string convertHexToEncryptionKey(string hex)
        {
            if (hex.Length < 16)
            {
                int num = (int)MessageBox.Show("The application encoded key is incorrect");
                Environment.Exit(0);
            }
            string str = "";
            hex = addCommasToHex(hex);
            string[] strArray = hex.Split(',');
            for (int index = 0; index < 8; ++index)
            {
                uint num = uint.Parse(strArray[index], NumberStyles.HexNumber);
                str += Encoding.UTF32.GetString(BitConverter.GetBytes(num));
            }
            return str;
        }

        public static string hexCsvToNiceDisplay(string csv, int bytesPerRow)
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
