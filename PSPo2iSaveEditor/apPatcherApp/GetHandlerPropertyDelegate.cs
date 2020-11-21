namespace apPatcherApp
{
    using Microsoft.COM;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int GetHandlerPropertyDelegate(ArchivePropId propID, ref PropVariant value);
}

