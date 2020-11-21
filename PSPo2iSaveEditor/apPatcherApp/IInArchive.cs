namespace apPatcherApp
{
    using Microsoft.COM;
    using System;
    using System.Runtime.InteropServices;

    [ComImport, Guid("23170F69-40C1-278A-0000-000600600000"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInArchive
    {
        [PreserveSig]
        int Open(IInStream stream, [In] ref ulong maxCheckStartPosition, [MarshalAs(UnmanagedType.Interface)] IArchiveOpenCallback openArchiveCallback);
        [PreserveSig]
        int Close();
        uint GetNumberOfItems();
        void GetProperty(uint index, ItemPropId propID, ref PropVariant value);
        [PreserveSig]
        int Extract([MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] uint[] indices, uint numItems, int testMode, [MarshalAs(UnmanagedType.Interface)] IArchiveExtractCallback extractCallback);
        void GetArchiveProperty(uint propID, ref PropVariant value);
        uint GetNumberOfProperties();
        void GetPropertyInfo(uint index, [MarshalAs(UnmanagedType.BStr)] out string name, out ItemPropId propID, out ushort varType);
        uint GetNumberOfArchiveProperties();
        void GetArchivePropertyInfo(uint index, [MarshalAs(UnmanagedType.BStr)] string name, ref uint propID, ref ushort varType);
    }
}

