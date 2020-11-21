namespace apPatcherApp
{
    using System;
    using System.Drawing;
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

        public long bytesToGbit(long bytes) => 
            this.bytesToMbit(bytes) / 0x400L;

        public long bytesToMbit(long bytes) => 
            ((bytes * 8L) / 0x400L) / 0x400L;

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

        public string dateStringFormatFromUTC(string date)
        {
            string str = "";
            if ((date != null) && (date != ""))
            {
                DateTime time = new DateTime(int.Parse(date.Substring(0, 4)), int.Parse(date.Substring(4, 2)), int.Parse(date.Substring(6, 2)), int.Parse(date.Substring(8, 2)), int.Parse(date.Substring(10, 2)), int.Parse(date.Substring(12, 2)));
                DateTime utcNow = DateTime.UtcNow;
                DateTime now = DateTime.Now;
                long num7 = long.Parse(utcNow.Year.ToString("D2") + utcNow.Month.ToString("D2") + utcNow.Day.ToString("D2") + utcNow.Hour.ToString("D2") + utcNow.Minute.ToString("D2") + utcNow.Second.ToString("D2"));
                long num8 = long.Parse(now.Year.ToString("D2") + now.Month.ToString("D2") + now.Day.ToString("D2") + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2"));
                if (num7 > num8)
                {
                    time = time.Subtract(utcNow.Subtract(now));
                }
                else if (num7 < num8)
                {
                    time = time.Add(now.Subtract(utcNow));
                }
                str = time.ToString("ddd, dd MMM yyyy HH':'mm");
            }
            return str;
        }

        public long dateToLong(DateTime date)
        {
            string[] strArray = new string[] { date.Year.ToString("D2"), date.Month.ToString("D2"), date.Day.ToString("D2"), date.Hour.ToString("D2"), date.Minute.ToString("D2"), date.Second.ToString("D2") };
            return long.Parse(string.Concat(strArray));
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
            ((thisval != 0) || (targetVal != 0)) ? ((int) decimal.Round((thisval / targetVal) * 100M, 0)) : 100;

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

        public int hexToInt(string hex)
        {
            hex = this.reversehex(hex, hex.Length);
            return int.Parse(hex, NumberStyles.HexNumber);
        }

        public long hexToLong(string hex)
        {
            hex = this.reversehex(hex, hex.Length);
            return long.Parse(hex, NumberStyles.HexNumber);
        }

        public string hexToSingleCharString(string hex) => 
            ((char) Convert.ToInt32(hex, 0x10));

        public string hexToString(string hex)
        {
            int num = hex.Length / 2;
            string[] strArray = this.addCommasToHex(hex).Split(new char[] { ',' });
            string str2 = "";
            for (int i = 0; i < num; i++)
            {
                string str3 = strArray[i];
                str2 = (str3 != "00") ? (str2 + this.hexToSingleCharString(str3)) : (str2 + "\r\n");
            }
            return str2;
        }

        public string hexToUTF32String(string hex)
        {
            int num = hex.Length / 4;
            string[] strArray = this.addCommasToHex(hex).Split(new char[] { ',' });
            string str2 = "";
            for (int i = 0; i < num; i++)
            {
                string str3 = strArray[i * 2] + strArray[(i * 2) + 1];
                uint num3 = uint.Parse(this.reversehex(str3, str3.Length), NumberStyles.HexNumber);
                str2 = str2 + Encoding.UTF32.GetString(BitConverter.GetBytes(num3));
            }
            return str2;
        }

        public long mbitToBytes(long mbits) => 
            ((mbits * 0x400L) * 0x400L) / 8L;

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

        public string string_replace(string needle, string replace, string haystack)
        {
            string str = "";
            for (int i = 0; i < haystack.Length; i++)
            {
                if (((i + needle.Length) > haystack.Length) || (haystack.Substring(i, needle.Length) != needle))
                {
                    str = str + haystack.Substring(i, 1);
                }
                else
                {
                    str = str + replace;
                    i += needle.Length - 1;
                }
            }
            return str;
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

        public Color UIntToColor(uint color) => 
            Color.FromArgb((byte) (color >> 0x18), (byte) (color >> 0x10), (byte) (color >> 8), (byte) color);
    }
}

