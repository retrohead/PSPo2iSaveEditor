namespace apPatcherApp
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class OutStreamWrapper : StreamWrapper, ISequentialOutStream, IOutStream
    {
        public OutStreamWrapper(Stream baseStream) : base(baseStream)
        {
        }

        public int SetSize(long newSize)
        {
            base._BaseStream.SetLength(newSize);
            return 0;
        }

        public int Write(byte[] data, uint size, IntPtr processedSize)
        {
            base._BaseStream.Write(data, 0, (int) size);
            if (processedSize != IntPtr.Zero)
            {
                Marshal.WriteInt32(processedSize, (int) size);
            }
            return 0;
        }
    }
}

