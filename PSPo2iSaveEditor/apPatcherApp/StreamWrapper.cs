namespace apPatcherApp
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class StreamWrapper : IDisposable
    {
        protected Stream _BaseStream;

        protected StreamWrapper(Stream baseStream)
        {
            this._BaseStream = baseStream;
        }

        public virtual void Dispose()
        {
            this._BaseStream.Close();
        }

        public virtual void Seek(long offset, uint seekOrigin, IntPtr newPosition)
        {
            long val = (uint) this._BaseStream.Seek(offset, (SeekOrigin) seekOrigin);
            if (newPosition != IntPtr.Zero)
            {
                Marshal.WriteInt64(newPosition, val);
            }
        }

        public Stream BaseStream =>
            this._BaseStream;
    }
}

