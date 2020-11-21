namespace PSPo2iSaveEditor
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    public class hexAndMathFunctions
    {
        public string addCommasToHex(string hex)
        {
            string str = "";
            int num = 0;
            for (int i = 0; i < hex.Length; i++)
            {
                str = str + hex.Substring(i, 1);
                if ((i != (hex.Length - 1)) && ((num + 1) == 2))
                {
                    num = 0;
                    str = str + ",";
                }
            }
            return str;
        }

        public string convertHexToEncryptionKey(string hex)
        {
            if (hex.Length < 0x10)
            {
                MessageBox.Show("The application encoded key is incorrect");
                Environment.Exit(0);
            }
            string str = "";
            hex = this.addCommasToHex(hex);
            string[] strArray = hex.Split(new char[] { ',' });
            for (int i = 0; i < 8; i++)
            {
                uint num2 = uint.Parse(strArray[i], NumberStyles.HexNumber);
                str = str + Encoding.UTF32.GetString(BitConverter.GetBytes(num2));
            }
            return str;
        }

        public string decimalByteConvert(int byte_decimal, string return_type)
        {
            string str = "";
            int num = 0;
            str = $"{byte_decimal:X}";
            while (str.Length < 2)
            {
                str = "0" + str;
            }
            num = Convert.ToInt32(str, 0x10);
            return ((return_type != "hex") ? char.ConvertFromUtf32(num) : str);
        }

        public int getPercentage(int thisval, int targetVal) => 
            (int) decimal.Round((thisval / targetVal) * 100M, 0);

        public string halfByteSwap(string hex)
        {
            string str = "";
            if ((hex.Length / 2M).ToString() != (hex.Length / 2).ToString())
            {
                MessageBox.Show("Trying to halfByte swap an uneven (" + hex.Length + ") amount of bytes!");
                return "";
            }
            for (int i = 0; i < (hex.Length / 2); i++)
            {
                str = str + hex.Substring(1 + (i * 2), 1) + hex.Substring(i * 2, 1);
            }
            return str;
        }

        public string hex2binary(string hexvalue) => 
            Convert.ToString(Convert.ToInt32(hexvalue, 0x10), 2);

        public string hexCsvToNiceDisplay(string csv, int bytesPerRow)
        {
            string[] strArray = csv.Split(new char[] { ',' });
            int num = 0;
            string str = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + strArray[i];
                if ((num + 1) < bytesPerRow)
                {
                    str = str + " ";
                }
                else
                {
                    num = 0;
                    str = str + "\r\n";
                }
            }
            return str;
        }

        public int hexToInt(string hex)
        {
            hex = this.reversehex(hex, hex.Length);
            return int.Parse(hex, NumberStyles.HexNumber);
        }

        public string reversehex(string hex, int len)
        {
            string str = "";
            string str2 = "";
            if (hex == null)
            {
                str = hex;
            }
            else
            {
                while (true)
                {
                    if (hex.Length >= len)
                    {
                        for (int i = len - 2; i >= 0; i -= 2)
                        {
                            str2 = hex.Substring(i, 2);
                            str = str + str2;
                        }
                        break;
                    }
                    hex = hex + "0";
                }
            }
            while (str.Length < len)
            {
                str = str + "0";
            }
            return str;
        }

        public string reversestring(string str)
        {
            string str2 = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                str2 = str2 + str.Substring(i, 1);
            }
            return str2;
        }

        public string stringToHexadecimal(string Data, int bytes)
        {
            string str2 = "";
            foreach (char ch in Data.ToCharArray())
            {
                string hex = $"{Convert.ToUInt32(ch):X4}";
                str2 = str2 + this.reversehex(hex, 4);
            }
            while (str2.Length < bytes)
            {
                str2 = str2 + "00";
            }
            return str2;
        }

        public string stringToProper(string str)
        {
            bool flag = true;
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
            {
                string str3 = str.Substring(i, 1);
                if (!flag)
                {
                    str2 = str2 + str3;
                }
                else
                {
                    flag = false;
                    str2 = str2 + str3.ToUpper();
                }
                if (str3 == " ")
                {
                    flag = true;
                }
            }
            return str2;
        }
    }
}

