namespace apPatcherApp
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("23170F69-40C1-278A-0000-000300040000")]
    public interface IOutStream
    {
        [PreserveSig]
        int Write([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] byte[] data, uint size, IntPtr processedSize);
        void Seek(long offset, uint seekOrigin, IntPtr newPosition);
        [PreserveSig]
        int SetSize(long newSize);
    }
}

