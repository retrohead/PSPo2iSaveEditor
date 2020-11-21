namespace Blue.Windows
{
    using Blue.Private.Win32Imports;
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;
    using System.Windows.Forms;

    public class StickyWindow : NativeWindow
    {
        private static ArrayList GlobalStickyWindows = new ArrayList();
        private ProcessMessage MessageProcessor;
        private ProcessMessage DefaultMessageProcessor;
        private ProcessMessage MoveMessageProcessor;
        private ProcessMessage ResizeMessageProcessor;
        private bool movingForm = false;
        private Point formOffsetPoint;
        private Point offsetPoint;
        private bool resizingForm = false;
        private ResizeDir resizeDirection;
        private Rectangle formOffsetRect;
        private Point mousePoint;
        private Form originalForm;
        private Rectangle formRect;
        private Rectangle formOriginalRect;
        private static int stickGap = 20;
        private bool stickOnResize;
        private bool stickOnMove;
        private bool stickToScreen;
        private bool stickToOther;

        public StickyWindow(Form form)
        {
            this.originalForm = form;
            this.formRect = Rectangle.Empty;
            this.formOffsetRect = Rectangle.Empty;
            this.formOffsetPoint = Point.Empty;
            this.offsetPoint = Point.Empty;
            this.mousePoint = Point.Empty;
            this.stickOnMove = true;
            this.stickOnResize = true;
            this.stickToScreen = true;
            this.stickToOther = true;
            this.DefaultMessageProcessor = new ProcessMessage(this.DefaultMsgProcessor);
            this.MoveMessageProcessor = new ProcessMessage(this.MoveMsgProcessor);
            this.ResizeMessageProcessor = new ProcessMessage(this.ResizeMsgProcessor);
            this.MessageProcessor = this.DefaultMessageProcessor;
            base.AssignHandle(this.originalForm.Handle);
        }

        private void Cancel()
        {
            this.originalForm.Capture = false;
            this.movingForm = false;
            this.resizingForm = false;
            this.MessageProcessor = this.DefaultMessageProcessor;
        }

        private bool DefaultMsgProcessor(ref Message m)
        {
            if (m.Msg == 0xa1)
            {
                this.originalForm.Activate();
                this.mousePoint.X = (short) Win32.Bit.LoWord((int) m.LParam);
                this.mousePoint.Y = (short) Win32.Bit.HiWord((int) m.LParam);
                if (this.OnNCLButtonDown((int) m.WParam, this.mousePoint))
                {
                    m.Result = (this.resizingForm || this.movingForm) ? ((IntPtr) 1) : IntPtr.Zero;
                    return true;
                }
            }
            return false;
        }

        private void EndMove()
        {
            this.Cancel();
        }

        private void EndResize()
        {
            this.Cancel();
        }

        private void Move(Point p)
        {
            p = this.originalForm.PointToScreen(p);
            Screen screen = Screen.FromPoint(p);
            if (!screen.WorkingArea.Contains(p))
            {
                p.X = this.NormalizeInside(p.X, screen.WorkingArea.Left, screen.WorkingArea.Right);
                p.Y = this.NormalizeInside(p.Y, screen.WorkingArea.Top, screen.WorkingArea.Bottom);
            }
            p.Offset(-this.offsetPoint.X, -this.offsetPoint.Y);
            this.formRect.Location = p;
            this.formOffsetPoint.X = stickGap + 1;
            this.formOffsetPoint.Y = stickGap + 1;
            if (this.stickToScreen)
            {
                this.Move_Stick(screen.WorkingArea, false);
            }
            if (this.stickToOther)
            {
                foreach (Form form in GlobalStickyWindows)
                {
                    if (!ReferenceEquals(form, this.originalForm))
                    {
                        this.Move_Stick(form.Bounds, true);
                    }
                }
            }
            if (this.formOffsetPoint.X == (stickGap + 1))
            {
                this.formOffsetPoint.X = 0;
            }
            if (this.formOffsetPoint.Y == (stickGap + 1))
            {
                this.formOffsetPoint.Y = 0;
            }
            this.formRect.Offset(this.formOffsetPoint);
            this.originalForm.Bounds = this.formRect;
        }

        private void Move_Stick(Rectangle toRect, bool bInsideStick)
        {
            if ((this.formRect.Bottom >= (toRect.Top - stickGap)) && (this.formRect.Top <= (toRect.Bottom + stickGap)))
            {
                if (bInsideStick)
                {
                    if (Math.Abs((int) (this.formRect.Left - toRect.Right)) <= Math.Abs(this.formOffsetPoint.X))
                    {
                        this.formOffsetPoint.X = toRect.Right - this.formRect.Left;
                    }
                    if (Math.Abs((int) ((this.formRect.Left + this.formRect.Width) - toRect.Left)) <= Math.Abs(this.formOffsetPoint.X))
                    {
                        this.formOffsetPoint.X = (toRect.Left - this.formRect.Width) - this.formRect.Left;
                    }
                }
                if (Math.Abs((int) (this.formRect.Left - toRect.Left)) <= Math.Abs(this.formOffsetPoint.X))
                {
                    this.formOffsetPoint.X = toRect.Left - this.formRect.Left;
                }
                if (Math.Abs((int) (((this.formRect.Left + this.formRect.Width) - toRect.Left) - toRect.Width)) <= Math.Abs(this.formOffsetPoint.X))
                {
                    this.formOffsetPoint.X = ((toRect.Left + toRect.Width) - this.formRect.Width) - this.formRect.Left;
                }
            }
            if ((this.formRect.Right >= (toRect.Left - stickGap)) && (this.formRect.Left <= (toRect.Right + stickGap)))
            {
                if (bInsideStick)
                {
                    if ((Math.Abs((int) (this.formRect.Top - toRect.Bottom)) <= Math.Abs(this.formOffsetPoint.Y)) && bInsideStick)
                    {
                        this.formOffsetPoint.Y = toRect.Bottom - this.formRect.Top;
                    }
                    if ((Math.Abs((int) ((this.formRect.Top + this.formRect.Height) - toRect.Top)) <= Math.Abs(this.formOffsetPoint.Y)) && bInsideStick)
                    {
                        this.formOffsetPoint.Y = (toRect.Top - this.formRect.Height) - this.formRect.Top;
                    }
                }
                if (Math.Abs((int) (this.formRect.Top - toRect.Top)) <= Math.Abs(this.formOffsetPoint.Y))
                {
                    this.formOffsetPoint.Y = toRect.Top - this.formRect.Top;
                }
                if (Math.Abs((int) (((this.formRect.Top + this.formRect.Height) - toRect.Top) - toRect.Height)) <= Math.Abs(this.formOffsetPoint.Y))
                {
                    this.formOffsetPoint.Y = ((toRect.Top + toRect.Height) - this.formRect.Height) - this.formRect.Top;
                }
            }
        }

        private bool MoveMsgProcessor(ref Message m)
        {
            if (!this.originalForm.Capture)
            {
                this.Cancel();
                return false;
            }
            int msg = m.Msg;
            if (msg == 0x100)
            {
                if (((int) m.WParam) == 0x1b)
                {
                    this.originalForm.Bounds = this.formOriginalRect;
                    this.Cancel();
                }
            }
            else
            {
                switch (msg)
                {
                    case 0x200:
                        this.mousePoint.X = (short) Win32.Bit.LoWord((int) m.LParam);
                        this.mousePoint.Y = (short) Win32.Bit.HiWord((int) m.LParam);
                        this.Move(this.mousePoint);
                        break;

                    case 0x202:
                        this.EndMove();
                        break;

                    default:
                        break;
                }
            }
            return false;
        }

        private int NormalizeInside(int iP1, int iM1, int iM2) => 
            (iP1 > iM1) ? ((iP1 < iM2) ? iP1 : iM2) : iM1;

        [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
        protected override void OnHandleChange()
        {
            if (((int) base.Handle) != 0)
            {
                GlobalStickyWindows.Add(this.originalForm);
            }
            else
            {
                GlobalStickyWindows.Remove(this.originalForm);
            }
        }

        private bool OnNCLButtonDown(int iHitTest, Point point)
        {
            Rectangle bounds = this.originalForm.Bounds;
            this.offsetPoint = point;
            switch (iHitTest)
            {
                case 2:
                    if (!this.stickOnMove)
                    {
                        return false;
                    }
                    this.offsetPoint.Offset(-bounds.Left, -bounds.Top);
                    this.StartMove();
                    return true;

                case 10:
                    return this.StartResize(ResizeDir.Left);

                case 11:
                    return this.StartResize(ResizeDir.Right);

                case 12:
                    return this.StartResize(ResizeDir.Top);

                case 13:
                    return this.StartResize(ResizeDir.Left | ResizeDir.Top);

                case 14:
                    return this.StartResize(ResizeDir.Right | ResizeDir.Top);

                case 15:
                    return this.StartResize(ResizeDir.Bottom);

                case 0x10:
                    return this.StartResize(ResizeDir.Left | ResizeDir.Bottom);

                case 0x11:
                    return this.StartResize(ResizeDir.Right | ResizeDir.Bottom);
            }
            return false;
        }

        public static void RegisterExternalReferenceForm(Form frmExternal)
        {
            GlobalStickyWindows.Add(frmExternal);
        }

        private unsafe void Resize(Point p)
        {
            p = this.originalForm.PointToScreen(p);
            Screen screen = Screen.FromPoint(p);
            this.formRect = this.originalForm.Bounds;
            int right = this.formRect.Right;
            int bottom = this.formRect.Bottom;
            if ((this.resizeDirection & ResizeDir.Left) == ResizeDir.Left)
            {
                this.formRect.Width = (this.formRect.X - p.X) + this.formRect.Width;
                this.formRect.X = right - this.formRect.Width;
            }
            if ((this.resizeDirection & ResizeDir.Right) == ResizeDir.Right)
            {
                this.formRect.Width = p.X - this.formRect.Left;
            }
            if ((this.resizeDirection & ResizeDir.Top) == ResizeDir.Top)
            {
                this.formRect.Height = (this.formRect.Height - p.Y) + this.formRect.Top;
                this.formRect.Y = bottom - this.formRect.Height;
            }
            if ((this.resizeDirection & ResizeDir.Bottom) == ResizeDir.Bottom)
            {
                this.formRect.Height = p.Y - this.formRect.Top;
            }
            this.formOffsetRect.X = stickGap + 1;
            this.formOffsetRect.Y = stickGap + 1;
            this.formOffsetRect.Height = 0;
            this.formOffsetRect.Width = 0;
            if (this.stickToScreen)
            {
                this.Resize_Stick(screen.WorkingArea, false);
            }
            if (this.stickToOther)
            {
                foreach (Form form in GlobalStickyWindows)
                {
                    if (!ReferenceEquals(form, this.originalForm))
                    {
                        this.Resize_Stick(form.Bounds, true);
                    }
                }
            }
            if (this.formOffsetRect.X == (stickGap + 1))
            {
                this.formOffsetRect.X = 0;
            }
            if (this.formOffsetRect.Width == (stickGap + 1))
            {
                this.formOffsetRect.Width = 0;
            }
            if (this.formOffsetRect.Y == (stickGap + 1))
            {
                this.formOffsetRect.Y = 0;
            }
            if (this.formOffsetRect.Height == (stickGap + 1))
            {
                this.formOffsetRect.Height = 0;
            }
            if ((this.resizeDirection & ResizeDir.Left) != ResizeDir.Left)
            {
                Rectangle* rectanglePtr1 = &this.formRect;
                rectanglePtr1.Width += this.formOffsetRect.Width + this.formOffsetRect.X;
            }
            else
            {
                int num3 = (this.formRect.Width + this.formOffsetRect.Width) + this.formOffsetRect.X;
                if (this.originalForm.MaximumSize.Width != 0)
                {
                    num3 = Math.Min(num3, this.originalForm.MaximumSize.Width);
                }
                num3 = Math.Max(Math.Max(Math.Min(num3, SystemInformation.MaxWindowTrackSize.Width), this.originalForm.MinimumSize.Width), SystemInformation.MinWindowTrackSize.Width);
                this.formRect.X = right - num3;
                this.formRect.Width = num3;
            }
            if ((this.resizeDirection & ResizeDir.Top) != ResizeDir.Top)
            {
                Rectangle* rectanglePtr2 = &this.formRect;
                rectanglePtr2.Height += this.formOffsetRect.Height + this.formOffsetRect.Y;
            }
            else
            {
                int num4 = (this.formRect.Height + this.formOffsetRect.Height) + this.formOffsetRect.Y;
                if (this.originalForm.MaximumSize.Height != 0)
                {
                    num4 = Math.Min(num4, this.originalForm.MaximumSize.Height);
                }
                num4 = Math.Max(Math.Max(Math.Min(num4, SystemInformation.MaxWindowTrackSize.Height), this.originalForm.MinimumSize.Height), SystemInformation.MinWindowTrackSize.Height);
                this.formRect.Y = bottom - num4;
                this.formRect.Height = num4;
            }
            this.originalForm.Bounds = this.formRect;
        }

        private void Resize_Stick(Rectangle toRect, bool bInsideStick)
        {
            if ((this.formRect.Right >= (toRect.Left - stickGap)) && (this.formRect.Left <= (toRect.Right + stickGap)))
            {
                if ((this.resizeDirection & ResizeDir.Top) == ResizeDir.Top)
                {
                    if ((Math.Abs((int) (this.formRect.Top - toRect.Bottom)) <= Math.Abs(this.formOffsetRect.Top)) && bInsideStick)
                    {
                        this.formOffsetRect.Y = this.formRect.Top - toRect.Bottom;
                    }
                    else if (Math.Abs((int) (this.formRect.Top - toRect.Top)) <= Math.Abs(this.formOffsetRect.Top))
                    {
                        this.formOffsetRect.Y = this.formRect.Top - toRect.Top;
                    }
                }
                if ((this.resizeDirection & ResizeDir.Bottom) == ResizeDir.Bottom)
                {
                    if ((Math.Abs((int) (this.formRect.Bottom - toRect.Top)) <= Math.Abs(this.formOffsetRect.Bottom)) && bInsideStick)
                    {
                        this.formOffsetRect.Height = toRect.Top - this.formRect.Bottom;
                    }
                    else if (Math.Abs((int) (this.formRect.Bottom - toRect.Bottom)) <= Math.Abs(this.formOffsetRect.Bottom))
                    {
                        this.formOffsetRect.Height = toRect.Bottom - this.formRect.Bottom;
                    }
                }
            }
            if ((this.formRect.Bottom >= (toRect.Top - stickGap)) && (this.formRect.Top <= (toRect.Bottom + stickGap)))
            {
                if ((this.resizeDirection & ResizeDir.Right) == ResizeDir.Right)
                {
                    if ((Math.Abs((int) (this.formRect.Right - toRect.Left)) <= Math.Abs(this.formOffsetRect.Right)) && bInsideStick)
                    {
                        this.formOffsetRect.Width = toRect.Left - this.formRect.Right;
                    }
                    else if (Math.Abs((int) (this.formRect.Right - toRect.Right)) <= Math.Abs(this.formOffsetRect.Right))
                    {
                        this.formOffsetRect.Width = toRect.Right - this.formRect.Right;
                    }
                }
                if ((this.resizeDirection & ResizeDir.Left) == ResizeDir.Left)
                {
                    if ((Math.Abs((int) (this.formRect.Left - toRect.Right)) <= Math.Abs(this.formOffsetRect.Left)) && bInsideStick)
                    {
                        this.formOffsetRect.X = this.formRect.Left - toRect.Right;
                    }
                    else if (Math.Abs((int) (this.formRect.Left - toRect.Left)) <= Math.Abs(this.formOffsetRect.Left))
                    {
                        this.formOffsetRect.X = this.formRect.Left - toRect.Left;
                    }
                }
            }
        }

        private bool ResizeMsgProcessor(ref Message m)
        {
            if (!this.originalForm.Capture)
            {
                this.Cancel();
                return false;
            }
            int msg = m.Msg;
            if (msg == 0x100)
            {
                if (((int) m.WParam) == 0x1b)
                {
                    this.originalForm.Bounds = this.formOriginalRect;
                    this.Cancel();
                }
            }
            else
            {
                switch (msg)
                {
                    case 0x200:
                        this.mousePoint.X = (short) Win32.Bit.LoWord((int) m.LParam);
                        this.mousePoint.Y = (short) Win32.Bit.HiWord((int) m.LParam);
                        this.Resize(this.mousePoint);
                        break;

                    case 0x202:
                        this.EndResize();
                        break;

                    default:
                        break;
                }
            }
            return false;
        }

        private void StartMove()
        {
            this.formRect = this.originalForm.Bounds;
            this.formOriginalRect = this.originalForm.Bounds;
            if (!this.originalForm.Capture)
            {
                this.originalForm.Capture = true;
            }
            this.MessageProcessor = this.MoveMessageProcessor;
        }

        private bool StartResize(ResizeDir resDir)
        {
            if (!this.stickOnResize)
            {
                return false;
            }
            this.resizeDirection = resDir;
            this.formRect = this.originalForm.Bounds;
            this.formOriginalRect = this.originalForm.Bounds;
            if (!this.originalForm.Capture)
            {
                this.originalForm.Capture = true;
            }
            this.MessageProcessor = this.ResizeMessageProcessor;
            return true;
        }

        public static void UnregisterExternalReferenceForm(Form frmExternal)
        {
            GlobalStickyWindows.Remove(frmExternal);
        }

        [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
        protected override void WndProc(ref Message m)
        {
            if (!this.MessageProcessor(ref m))
            {
                base.WndProc(ref m);
            }
        }

        public int StickGap
        {
            get => 
                stickGap;
            set => 
                stickGap = value;
        }

        public bool StickOnResize
        {
            get => 
                this.stickOnResize;
            set => 
                this.stickOnResize = value;
        }

        public bool StickOnMove
        {
            get => 
                this.stickOnMove;
            set => 
                this.stickOnMove = value;
        }

        public bool StickToScreen
        {
            get => 
                this.stickToScreen;
            set => 
                this.stickToScreen = value;
        }

        public bool StickToOther
        {
            get => 
                this.stickToOther;
            set => 
                this.stickToOther = value;
        }

        private delegate bool ProcessMessage(ref Message m);

        private enum ResizeDir
        {
            Top = 2,
            Bottom = 4,
            Left = 8,
            Right = 0x10
        }
    }
}

