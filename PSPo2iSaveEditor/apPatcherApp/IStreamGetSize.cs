namespace apPatcherApp
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, Guid("23170F69-40C1-278A-0000-000300060000"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStreamGetSize
    {
        ulong GetSize();
    }
}

