namespace apPatcherApp
{
    using Microsoft.COM;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int GetHandlerProperty2Delegate(uint formatIndex, ArchivePropId propID, ref PropVariant value);
}

