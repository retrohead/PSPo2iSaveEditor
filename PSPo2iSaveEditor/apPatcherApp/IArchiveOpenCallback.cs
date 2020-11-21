namespace apPatcherApp
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("23170F69-40C1-278A-0000-000600100000")]
    public interface IArchiveOpenCallback
    {
        void SetTotal(IntPtr files, IntPtr bytes);
        void SetCompleted(IntPtr files, IntPtr bytes);
    }
}

