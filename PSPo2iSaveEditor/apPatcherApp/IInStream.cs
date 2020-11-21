namespace apPatcherApp
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, Guid("23170F69-40C1-278A-0000-000300030000"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInStream
    {
        uint Read([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] byte[] data, uint size);
        void Seek(long offset, uint seekOrigin, IntPtr newPosition);
    }
}

