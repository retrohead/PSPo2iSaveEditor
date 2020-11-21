namespace apPatcherApp
{
    using System;
    using System.IO;

    public class InStreamWrapper : StreamWrapper, ISequentialInStream, IInStream
    {
        public InStreamWrapper(Stream baseStream) : base(baseStream)
        {
        }

        public ulong GetSize() => 
            (ulong) base.BaseStream.Length;

        public uint Read(byte[] data, uint size) => 
            (uint) base._BaseStream.Read(data, 0, (int) size);
    }
}

