namespace apPatcherApp
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class InStreamTimedWrapper : StreamWrapper, ISequentialInStream, IInStream
    {
        private const int KeepAliveInterval = 0x1388;
        private string _BaseStreamFileName;
        private long BaseStreamLastPosition;
        private Timer CloseTimer;

        public InStreamTimedWrapper(Stream baseStream) : base(baseStream)
        {
            FileStream stream = base._BaseStream as FileStream;
            if ((stream != null) && (!base._BaseStream.CanWrite && base._BaseStream.CanSeek))
            {
                this._BaseStreamFileName = stream.Name;
                this.CloseTimer = new Timer(new TimerCallback(this.CloseStream), null, 0x1388, -1);
            }
        }

        private void CloseStream(object state)
        {
            if (this.CloseTimer != null)
            {
                this.CloseTimer.Dispose();
                this.CloseTimer = null;
            }
            if (base._BaseStream != null)
            {
                if (base._BaseStream.CanSeek)
                {
                    this.BaseStreamLastPosition = base._BaseStream.Position;
                }
                base._BaseStream.Close();
                base._BaseStream = null;
            }
        }

        public override void Dispose()
        {
            this.CloseStream(null);
            this._BaseStreamFileName = null;
        }

        public void Flush()
        {
            this.CloseStream(null);
        }

        public uint Read(byte[] data, uint size)
        {
            this.ReopenStream();
            return (uint) base._BaseStream.Read(data, 0, (int) size);
        }

        protected void ReopenStream()
        {
            if ((base._BaseStream != null) && base._BaseStream.CanRead)
            {
                if (this.CloseTimer != null)
                {
                    this.CloseTimer.Change(0x1388, -1);
                }
            }
            else
            {
                if (this._BaseStreamFileName == null)
                {
                    throw new ObjectDisposedException("StreamWrapper");
                }
                base._BaseStream = new FileStream(this._BaseStreamFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                base._BaseStream.Position = this.BaseStreamLastPosition;
                this.CloseTimer = new Timer(new TimerCallback(this.CloseStream), null, 0x1388, -1);
            }
        }

        public override void Seek(long offset, uint seekOrigin, IntPtr newPosition)
        {
            if ((base._BaseStream != null) || ((this._BaseStreamFileName == null) || ((offset != 0L) || (seekOrigin != 0))))
            {
                this.ReopenStream();
                base.Seek(offset, seekOrigin, newPosition);
            }
            else
            {
                this.BaseStreamLastPosition = 0L;
                if (newPosition != IntPtr.Zero)
                {
                    Marshal.WriteInt64(newPosition, this.BaseStreamLastPosition);
                }
            }
        }

        public string BaseStreamFileName =>
            this._BaseStreamFileName;
    }
}

