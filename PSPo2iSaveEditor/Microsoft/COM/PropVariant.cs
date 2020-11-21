namespace Microsoft.COM
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    [StructLayout(LayoutKind.Explicit, Size=0x10)]
    public struct PropVariant
    {
        [FieldOffset(0)]
        public ushort vt;
        [FieldOffset(8)]
        public IntPtr pointerValue;
        [FieldOffset(8)]
        public sbyte sbyteValue;
        [FieldOffset(8)]
        public byte byteValue;
        [FieldOffset(8)]
        public short shortValue;
        [FieldOffset(8)]
        public ushort ushortValue;
        [FieldOffset(8)]
        public int intValue;
        [FieldOffset(8)]
        public uint uintValue;
        [FieldOffset(8)]
        public long longValue;
        [FieldOffset(8)]
        public ulong ulongValue;
        [FieldOffset(8)]
        public float floatValue;
        [FieldOffset(8)]
        public double doubleValue;
        [FieldOffset(8)]
        public System.Runtime.InteropServices.ComTypes.FILETIME filetime;

        public void Clear()
        {
            VarEnum varType = this.VarType;
            switch (varType)
            {
                case VarEnum.VT_EMPTY:
                    return;

                case VarEnum.VT_NULL:
                case VarEnum.VT_I2:
                case VarEnum.VT_I4:
                case VarEnum.VT_R4:
                case VarEnum.VT_R8:
                case VarEnum.VT_CY:
                case VarEnum.VT_DATE:
                case VarEnum.VT_ERROR:
                case VarEnum.VT_BOOL:
                case VarEnum.VT_I1:
                case VarEnum.VT_UI1:
                case VarEnum.VT_UI2:
                case VarEnum.VT_UI4:
                case VarEnum.VT_I8:
                case VarEnum.VT_UI8:
                case VarEnum.VT_INT:
                case VarEnum.VT_UINT:
                case VarEnum.VT_HRESULT:
                    goto TR_0000;

                case VarEnum.VT_BSTR:
                    Marshal.FreeBSTR(this.pointerValue);
                    this.vt = 0;
                    return;

                case VarEnum.VT_DISPATCH:
                case VarEnum.VT_VARIANT:
                case VarEnum.VT_UNKNOWN:
                case VarEnum.VT_DECIMAL:
                case (VarEnum.VT_DECIMAL | VarEnum.VT_NULL):
                case VarEnum.VT_VOID:
                    break;

                default:
                    if (varType != VarEnum.VT_FILETIME)
                    {
                        break;
                    }
                    goto TR_0000;
            }
            PropVariantClear(ref this);
            return;
        TR_0000:
            this.vt = 0;
        }

        public object GetObject()
        {
            object objectForNativeVariant;
            VarEnum varType = this.VarType;
            if (varType == VarEnum.VT_EMPTY)
            {
                return null;
            }
            if (varType == VarEnum.VT_FILETIME)
            {
                return DateTime.FromFileTime(this.longValue);
            }
            GCHandle handle = GCHandle.Alloc(this, GCHandleType.Pinned);
            try
            {
                objectForNativeVariant = Marshal.GetObjectForNativeVariant(handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }
            return objectForNativeVariant;
        }

        [DllImport("ole32.dll")]
        private static extern int PropVariantClear(ref PropVariant pvar);
        public void SetObject(object value)
        {
            if (value == null)
            {
                this.vt = 0;
            }
            else
            {
                switch (Type.GetTypeCode(value.GetType()))
                {
                    case TypeCode.DBNull:
                        this.vt = 1;
                        return;

                    case TypeCode.Boolean:
                        this.shortValue = Convert.ToInt16(value);
                        this.vt = 11;
                        return;

                    case TypeCode.Char:
                    case TypeCode.Decimal:
                    case TypeCode.DateTime:
                    case (TypeCode.DateTime | TypeCode.Object):
                        break;

                    case TypeCode.SByte:
                        this.sbyteValue = (sbyte) value;
                        this.vt = 0x10;
                        return;

                    case TypeCode.Byte:
                        this.byteValue = (byte) value;
                        this.vt = 0x11;
                        return;

                    case TypeCode.Int16:
                        this.shortValue = (short) value;
                        this.vt = 2;
                        return;

                    case TypeCode.UInt16:
                        this.ushortValue = (ushort) value;
                        this.vt = 0x12;
                        return;

                    case TypeCode.Int32:
                        this.intValue = (int) value;
                        this.vt = 3;
                        return;

                    case TypeCode.UInt32:
                        this.uintValue = (uint) value;
                        this.vt = 0x13;
                        return;

                    case TypeCode.Int64:
                        this.longValue = (long) value;
                        this.vt = 20;
                        return;

                    case TypeCode.UInt64:
                        this.ulongValue = (ulong) value;
                        this.vt = 0x15;
                        return;

                    case TypeCode.Single:
                        this.floatValue = (float) value;
                        this.vt = 4;
                        return;

                    case TypeCode.Double:
                        this.doubleValue = (double) value;
                        this.vt = 5;
                        return;

                    case TypeCode.String:
                        this.pointerValue = Marshal.StringToBSTR((string) value);
                        this.vt = 8;
                        break;

                    default:
                        return;
                }
            }
        }

        public VarEnum VarType =>
            (VarEnum) this.vt;
    }
}

