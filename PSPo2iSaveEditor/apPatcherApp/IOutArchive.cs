namespace apPatcherApp
{
    using System;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("23170F69-40C1-278A-0000-000600A00000")]
    public interface IOutArchive
    {
        void UpdateItems(ISequentialOutStream outStream, int numItems, IArchiveUpdateCallback updateCallback);
        FileTimeType GetFileTimeType();
    }
}

