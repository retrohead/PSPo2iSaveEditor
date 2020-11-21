namespace apPatcherApp
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, Guid("23170F69-40C1-278A-0000-000000050000"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IProgress
    {
        void SetTotal(ulong total);
        void SetCompleted([In] ref ulong completeValue);
    }
}

