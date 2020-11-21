namespace Blue.Private.Win32Imports
{
    using System;
    using System.Runtime.InteropServices;

    public class Win32
    {
        [DllImport("user32.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        public static extern short GetAsyncKeyState(int vKey);
        [DllImport("user32.dll", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        public static extern IntPtr GetDesktopWindow();

        public class Bit
        {
            public static int HiWord(int iValue) => 
                (iValue >> 0x10) & 0xffff;

            public static int LoWord(int iValue) => 
                iValue & 0xffff;
        }

        public class HT
        {
            public const int HTERROR = -2;
            public const int HTTRANSPARENT = -1;
            public const int HTNOWHERE = 0;
            public const int HTCLIENT = 1;
            public const int HTCAPTION = 2;
            public const int HTSYSMENU = 3;
            public const int HTGROWBOX = 4;
            public const int HTSIZE = 4;
            public const int HTMENU = 5;
            public const int HTHSCROLL = 6;
            public const int HTVSCROLL = 7;
            public const int HTMINBUTTON = 8;
            public const int HTMAXBUTTON = 9;
            public const int HTLEFT = 10;
            public const int HTRIGHT = 11;
            public const int HTTOP = 12;
            public const int HTTOPLEFT = 13;
            public const int HTTOPRIGHT = 14;
            public const int HTBOTTOM = 15;
            public const int HTBOTTOMLEFT = 0x10;
            public const int HTBOTTOMRIGHT = 0x11;
            public const int HTBORDER = 0x12;
            public const int HTREDUCE = 8;
            public const int HTZOOM = 9;
            public const int HTSIZEFIRST = 10;
            public const int HTSIZELAST = 0x11;
            public const int HTOBJECT = 0x13;
            public const int HTCLOSE = 20;
            public const int HTHELP = 0x15;
        }

        public class VK
        {
            public const int VK_SHIFT = 0x10;
            public const int VK_CONTROL = 0x11;
            public const int VK_MENU = 0x12;
            public const int VK_ESCAPE = 0x1b;

            public static bool IsKeyPressed(int KeyCode) => 
                (Win32.GetAsyncKeyState(KeyCode) & 0x800) == 0;
        }

        public class WM
        {
            public const int WM_MOUSEMOVE = 0x200;
            public const int WM_NCMOUSEMOVE = 160;
            public const int WM_NCLBUTTONDOWN = 0xa1;
            public const int WM_NCLBUTTONUP = 0xa2;
            public const int WM_NCLBUTTONDBLCLK = 0xa3;
            public const int WM_LBUTTONDOWN = 0x201;
            public const int WM_LBUTTONUP = 0x202;
            public const int WM_KEYDOWN = 0x100;
        }
    }
}

