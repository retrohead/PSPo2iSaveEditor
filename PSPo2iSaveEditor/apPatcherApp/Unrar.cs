namespace apPatcherApp
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class Unrar : IDisposable
    {
        private DataAvailableHandler DataAvailable;
        private ExtractionProgressHandler ExtractionProgress;
        private MissingVolumeHandler MissingVolume;
        private NewFileHandler NewFile;
        private NewVolumeHandler NewVolume;
        private PasswordRequiredHandler PasswordRequired;
        private string archivePathName;
        private IntPtr archiveHandle;
        private bool retrieveComment;
        private string password;
        private string comment;
        private ArchiveFlags archiveFlags;
        private RARHeaderDataEx header;
        private string destinationPath;
        private RARFileInfo currentFile;
        private UNRARCallback callback;

        public event DataAvailableHandler DataAvailable
        {
            add
            {
                DataAvailableHandler dataAvailable = this.DataAvailable;
                while (true)
                {
                    DataAvailableHandler comparand = dataAvailable;
                    DataAvailableHandler handler3 = comparand + value;
                    dataAvailable = Interlocked.CompareExchange<DataAvailableHandler>(ref this.DataAvailable, handler3, comparand);
                    if (ReferenceEquals(dataAvailable, comparand))
                    {
                        return;
                    }
                }
            }
            remove
            {
                DataAvailableHandler dataAvailable = this.DataAvailable;
                while (true)
                {
                    DataAvailableHandler comparand = dataAvailable;
                    DataAvailableHandler handler3 = comparand - value;
                    dataAvailable = Interlocked.CompareExchange<DataAvailableHandler>(ref this.DataAvailable, handler3, comparand);
                    if (ReferenceEquals(dataAvailable, comparand))
                    {
                        return;
                    }
                }
            }
        }

        public event ExtractionProgressHandler ExtractionProgress
        {
            add
            {
                ExtractionProgressHandler extractionProgress = this.ExtractionProgress;
                while (true)
                {
                    ExtractionProgressHandler comparand = extractionProgress;
                    ExtractionProgressHandler handler3 = comparand + value;
                    extractionProgress = Interlocked.CompareExchange<ExtractionProgressHandler>(ref this.ExtractionProgress, handler3, comparand);
                    if (ReferenceEquals(extractionProgress, comparand))
                    {
                        return;
                    }
                }
            }
            remove
            {
                ExtractionProgressHandler extractionProgress = this.ExtractionProgress;
                while (true)
                {
                    ExtractionProgressHandler comparand = extractionProgress;
                    ExtractionProgressHandler handler3 = comparand - value;
                    extractionProgress = Interlocked.CompareExchange<ExtractionProgressHandler>(ref this.ExtractionProgress, handler3, comparand);
                    if (ReferenceEquals(extractionProgress, comparand))
                    {
                        return;
                    }
                }
            }
        }

        public event MissingVolumeHandler MissingVolume
        {
            add
            {
                MissingVolumeHandler missingVolume = this.MissingVolume;
                while (true)
                {
                    MissingVolumeHandler comparand = missingVolume;
                    MissingVolumeHandler handler3 = comparand + value;
                    missingVolume = Interlocked.CompareExchange<MissingVolumeHandler>(ref this.MissingVolume, handler3, comparand);
                    if (ReferenceEquals(missingVolume, comparand))
                    {
                        return;
                    }
                }
            }
            remove
            {
                MissingVolumeHandler missingVolume = this.MissingVolume;
                while (true)
                {
                    MissingVolumeHandler comparand = missingVolume;
                    MissingVolumeHandler handler3 = comparand - value;
                    missingVolume = Interlocked.CompareExchange<MissingVolumeHandler>(ref this.MissingVolume, handler3, comparand);
                    if (ReferenceEquals(missingVolume, comparand))
                    {
                        return;
                    }
                }
            }
        }

        public event NewFileHandler NewFile
        {
            add
            {
                NewFileHandler newFile = this.NewFile;
                while (true)
                {
                    NewFileHandler comparand = newFile;
                    NewFileHandler handler3 = comparand + value;
                    newFile = Interlocked.CompareExchange<NewFileHandler>(ref this.NewFile, handler3, comparand);
                    if (ReferenceEquals(newFile, comparand))
                    {
                        return;
                    }
                }
            }
            remove
            {
                NewFileHandler newFile = this.NewFile;
                while (true)
                {
                    NewFileHandler comparand = newFile;
                    NewFileHandler handler3 = comparand - value;
                    newFile = Interlocked.CompareExchange<NewFileHandler>(ref this.NewFile, handler3, comparand);
                    if (ReferenceEquals(newFile, comparand))
                    {
                        return;
                    }
                }
            }
        }

        public event NewVolumeHandler NewVolume
        {
            add
            {
                NewVolumeHandler newVolume = this.NewVolume;
                while (true)
                {
                    NewVolumeHandler comparand = newVolume;
                    NewVolumeHandler handler3 = comparand + value;
                    newVolume = Interlocked.CompareExchange<NewVolumeHandler>(ref this.NewVolume, handler3, comparand);
                    if (ReferenceEquals(newVolume, comparand))
                    {
                        return;
                    }
                }
            }
            remove
            {
                NewVolumeHandler newVolume = this.NewVolume;
                while (true)
                {
                    NewVolumeHandler comparand = newVolume;
                    NewVolumeHandler handler3 = comparand - value;
                    newVolume = Interlocked.CompareExchange<NewVolumeHandler>(ref this.NewVolume, handler3, comparand);
                    if (ReferenceEquals(newVolume, comparand))
                    {
                        return;
                    }
                }
            }
        }

        public event PasswordRequiredHandler PasswordRequired
        {
            add
            {
                PasswordRequiredHandler passwordRequired = this.PasswordRequired;
                while (true)
                {
                    PasswordRequiredHandler comparand = passwordRequired;
                    PasswordRequiredHandler handler3 = comparand + value;
                    passwordRequired = Interlocked.CompareExchange<PasswordRequiredHandler>(ref this.PasswordRequired, handler3, comparand);
                    if (ReferenceEquals(passwordRequired, comparand))
                    {
                        return;
                    }
                }
            }
            remove
            {
                PasswordRequiredHandler passwordRequired = this.PasswordRequired;
                while (true)
                {
                    PasswordRequiredHandler comparand = passwordRequired;
                    PasswordRequiredHandler handler3 = comparand - value;
                    passwordRequired = Interlocked.CompareExchange<PasswordRequiredHandler>(ref this.PasswordRequired, handler3, comparand);
                    if (ReferenceEquals(passwordRequired, comparand))
                    {
                        return;
                    }
                }
            }
        }

        public Unrar()
        {
            this.archivePathName = string.Empty;
            this.archiveHandle = new IntPtr(0);
            this.retrieveComment = true;
            this.password = string.Empty;
            this.comment = string.Empty;
            this.header = new RARHeaderDataEx();
            this.destinationPath = string.Empty;
            this.callback = new UNRARCallback(this.RARCallback);
        }

        public Unrar(string archivePathName) : this()
        {
            this.archivePathName = archivePathName;
        }

        public void Close()
        {
            if (this.archiveHandle != IntPtr.Zero)
            {
                int result = RARCloseArchive(this.archiveHandle);
                if (result != 0)
                {
                    this.ProcessFileError(result);
                }
                else
                {
                    this.archiveHandle = IntPtr.Zero;
                }
            }
        }

        public void Dispose()
        {
            if (this.archiveHandle != IntPtr.Zero)
            {
                RARCloseArchive(this.archiveHandle);
                this.archiveHandle = IntPtr.Zero;
            }
        }

        public void Extract()
        {
            this.Extract(this.destinationPath, string.Empty);
        }

        public void Extract(string destinationName)
        {
            this.Extract(string.Empty, destinationName);
        }

        private void Extract(string destinationPath, string destinationName)
        {
            int result = RARProcessFile(this.archiveHandle, 2, destinationPath, destinationName);
            if (result != 0)
            {
                this.ProcessFileError(result);
            }
        }

        public void ExtractToDirectory(string destinationPath)
        {
            this.Extract(destinationPath, string.Empty);
        }

        ~Unrar()
        {
            if (this.archiveHandle != IntPtr.Zero)
            {
                RARCloseArchive(this.archiveHandle);
                this.archiveHandle = IntPtr.Zero;
            }
        }

        private DateTime FromMSDOSTime(uint dosTime)
        {
            ushort num7 = (ushort) ((dosTime & -65536) >> 0x10);
            ushort num8 = (ushort) (dosTime & 0xffff);
            return new DateTime(((num7 & 0xfe00) >> 9) + 0x7bc, (num7 & 480) >> 5, num7 & 0x1f, (num8 & 0xf800) >> 11, (num8 & 0x7e0) >> 5, (num8 & 0x1f) << 1);
        }

        public string[] ListFiles()
        {
            ArrayList list = new ArrayList();
            while (this.ReadHeader())
            {
                if (!this.currentFile.IsDirectory)
                {
                    list.Add(this.currentFile.FileName);
                }
                this.Skip();
            }
            string[] array = new string[list.Count];
            list.CopyTo(array);
            return array;
        }

        protected virtual int OnDataAvailable(IntPtr p1, int p2)
        {
            int num = 1;
            if (this.currentFile != null)
            {
                this.currentFile.BytesExtracted += p2;
            }
            if (this.DataAvailable != null)
            {
                byte[] destination = new byte[p2];
                Marshal.Copy(p1, destination, 0, p2);
                DataAvailableEventArgs e = new DataAvailableEventArgs(destination);
                this.DataAvailable(this, e);
                if (!e.ContinueOperation)
                {
                    num = -1;
                }
            }
            if ((this.ExtractionProgress != null) && (this.currentFile != null))
            {
                ExtractionProgressEventArgs e = new ExtractionProgressEventArgs {
                    FileName = this.currentFile.FileName,
                    FileSize = this.currentFile.UnpackedSize,
                    BytesExtracted = this.currentFile.BytesExtracted,
                    PercentComplete = this.currentFile.PercentComplete
                };
                this.ExtractionProgress(this, e);
                if (!e.ContinueOperation)
                {
                    num = -1;
                }
            }
            return num;
        }

        protected virtual string OnMissingVolume(string volume)
        {
            string volumeName = string.Empty;
            if (this.MissingVolume != null)
            {
                MissingVolumeEventArgs e = new MissingVolumeEventArgs(volume);
                this.MissingVolume(this, e);
                if (e.ContinueOperation)
                {
                    volumeName = e.VolumeName;
                }
            }
            return volumeName;
        }

        protected virtual void OnNewFile()
        {
            if (this.NewFile != null)
            {
                NewFileEventArgs e = new NewFileEventArgs(this.currentFile);
                this.NewFile(this, e);
            }
        }

        protected virtual int OnNewVolume(string volume)
        {
            int num = 1;
            if (this.NewVolume != null)
            {
                NewVolumeEventArgs e = new NewVolumeEventArgs(volume);
                this.NewVolume(this, e);
                if (!e.ContinueOperation)
                {
                    num = -1;
                }
            }
            return num;
        }

        protected virtual int OnPasswordRequired(IntPtr p1, int p2)
        {
            int num = -1;
            if (this.PasswordRequired == null)
            {
                throw new IOException("Password is required for extraction.");
            }
            PasswordRequiredEventArgs e = new PasswordRequiredEventArgs();
            this.PasswordRequired(this, e);
            if (e.ContinueOperation && (e.Password.Length > 0))
            {
                int ofs = 0;
                while (true)
                {
                    if ((ofs >= e.Password.Length) || (ofs >= p2))
                    {
                        Marshal.WriteByte(p1, e.Password.Length, 0);
                        num = 1;
                        break;
                    }
                    Marshal.WriteByte(p1, ofs, (byte) e.Password[ofs]);
                    ofs++;
                }
            }
            return num;
        }

        public void Open()
        {
            if (this.ArchivePathName.Length == 0)
            {
                throw new IOException("Archive name has not been set.");
            }
            this.Open(this.ArchivePathName, OpenMode.Extract);
        }

        public void Open(OpenMode openMode)
        {
            if (this.ArchivePathName.Length == 0)
            {
                throw new IOException("Archive name has not been set.");
            }
            this.Open(this.ArchivePathName, openMode);
        }

        public void Open(string archivePathName, OpenMode openMode)
        {
            IntPtr zero = IntPtr.Zero;
            if (this.archiveHandle != IntPtr.Zero)
            {
                this.Close();
            }
            this.ArchivePathName = archivePathName;
            RAROpenArchiveDataEx archiveData = new RAROpenArchiveDataEx();
            archiveData.Initialize();
            archiveData.ArcName = this.archivePathName + "\0";
            archiveData.ArcNameW = this.archivePathName + "\0";
            archiveData.OpenMode = (uint) openMode;
            if (this.retrieveComment)
            {
                archiveData.CmtBuf = new string('\0', 0x10000);
                archiveData.CmtBufSize = 0x10000;
            }
            else
            {
                archiveData.CmtBuf = null;
                archiveData.CmtBufSize = 0;
            }
            zero = RAROpenArchiveEx(ref archiveData);
            if (archiveData.OpenResult != 0)
            {
                switch (archiveData.OpenResult)
                {
                    case 11:
                        throw new OutOfMemoryException("Insufficient memory to perform operation.");

                    case 12:
                        throw new IOException("Archive header broken");

                    case 13:
                        throw new IOException("File is not a valid archive.");

                    case 15:
                        throw new IOException("File could not be opened.");

                    default:
                        break;
                }
            }
            this.archiveHandle = zero;
            this.archiveFlags = (ArchiveFlags) archiveData.Flags;
            RARSetCallback(this.archiveHandle, this.callback, this.GetHashCode());
            if (archiveData.CmtState == 1)
            {
                this.comment = archiveData.CmtBuf.ToString();
            }
            if (this.password.Length != 0)
            {
                RARSetPassword(this.archiveHandle, this.password);
            }
            this.OnNewVolume(this.archivePathName);
        }

        private void ProcessFileError(int result)
        {
            switch (result)
            {
                case 12:
                    throw new IOException("File CRC Error");

                case 13:
                    throw new IOException("File is not a valid archive.");

                case 14:
                    throw new OutOfMemoryException("Unknown archive format.");

                case 15:
                    throw new IOException("File could not be opened.");

                case 0x10:
                    throw new IOException("File could not be created.");

                case 0x11:
                    throw new IOException("File close error.");

                case 0x12:
                    throw new IOException("File read error.");

                case 0x13:
                    throw new IOException("File write error.");
            }
        }

        private int RARCallback(uint msg, int UserData, IntPtr p1, int p2)
        {
            string volume = string.Empty;
            string str2 = string.Empty;
            int num = -1;
            switch (msg)
            {
                case 0:
                    volume = Marshal.PtrToStringAnsi(p1);
                    if (p2 == 1)
                    {
                        num = this.OnNewVolume(volume);
                    }
                    else if (p2 == 0)
                    {
                        str2 = this.OnMissingVolume(volume);
                        if (str2.Length == 0)
                        {
                            num = -1;
                        }
                        else
                        {
                            if (str2 != volume)
                            {
                                int ofs = 0;
                                while (true)
                                {
                                    if (ofs >= str2.Length)
                                    {
                                        Marshal.WriteByte(p1, str2.Length, 0);
                                        break;
                                    }
                                    Marshal.WriteByte(p1, ofs, (byte) str2[ofs]);
                                    ofs++;
                                }
                            }
                            num = 1;
                        }
                    }
                    break;

                case 1:
                    num = this.OnDataAvailable(p1, p2);
                    break;

                case 2:
                    num = this.OnPasswordRequired(p1, p2);
                    break;

                default:
                    break;
            }
            return num;
        }

        [DllImport("unrar.dll")]
        private static extern int RARCloseArchive(IntPtr hArcData);
        [DllImport("unrar.dll")]
        private static extern IntPtr RAROpenArchive(ref RAROpenArchiveData archiveData);
        [DllImport("UNRAR.DLL")]
        private static extern IntPtr RAROpenArchiveEx(ref RAROpenArchiveDataEx archiveData);
        [DllImport("unrar.dll")]
        private static extern int RARProcessFile(IntPtr hArcData, int operation, [MarshalAs(UnmanagedType.LPStr)] string destPath, [MarshalAs(UnmanagedType.LPStr)] string destName);
        [DllImport("unrar.dll")]
        private static extern int RARReadHeader(IntPtr hArcData, ref RARHeaderData headerData);
        [DllImport("unrar.dll")]
        private static extern int RARReadHeaderEx(IntPtr hArcData, ref RARHeaderDataEx headerData);
        [DllImport("unrar.dll")]
        private static extern void RARSetCallback(IntPtr hArcData, UNRARCallback callback, int userData);
        [DllImport("unrar.dll")]
        private static extern void RARSetPassword(IntPtr hArcData, [MarshalAs(UnmanagedType.LPStr)] string password);
        public bool ReadHeader()
        {
            if (this.archiveHandle == IntPtr.Zero)
            {
                throw new IOException("Archive is not open.");
            }
            this.header = new RARHeaderDataEx();
            this.header.Initialize();
            this.currentFile = null;
            int num = RARReadHeaderEx(this.archiveHandle, ref this.header);
            if (num == 10)
            {
                return false;
            }
            if (num == 12)
            {
                throw new IOException("Archive data is corrupt.");
            }
            if (((this.header.Flags & 1) != 0) && (this.currentFile != null))
            {
                this.currentFile.ContinuedFromPrevious = true;
            }
            else
            {
                this.currentFile = new RARFileInfo();
                this.currentFile.FileName = this.header.FileNameW.ToString();
                if ((this.header.Flags & 2) != 0)
                {
                    this.currentFile.ContinuedOnNext = true;
                }
                this.currentFile.PackedSize = (this.header.PackSizeHigh == 0) ? ((long) this.header.PackSize) : ((this.header.PackSizeHigh * 0x100000000L) + this.header.PackSize);
                this.currentFile.UnpackedSize = (this.header.UnpSizeHigh == 0) ? ((long) this.header.UnpSize) : ((this.header.UnpSizeHigh * 0x100000000L) + this.header.UnpSize);
                this.currentFile.HostOS = (int) this.header.HostOS;
                this.currentFile.FileCRC = this.header.FileCRC;
                this.currentFile.FileTime = this.FromMSDOSTime(this.header.FileTime);
                this.currentFile.VersionToUnpack = (int) this.header.UnpVer;
                this.currentFile.Method = (int) this.header.Method;
                this.currentFile.FileAttributes = (int) this.header.FileAttr;
                this.currentFile.BytesExtracted = 0L;
                if ((this.header.Flags & 0xe0) == 0xe0)
                {
                    this.currentFile.IsDirectory = true;
                }
                this.OnNewFile();
            }
            return true;
        }

        public void Skip()
        {
            int result = RARProcessFile(this.archiveHandle, 0, string.Empty, string.Empty);
            if (result != 0)
            {
                this.ProcessFileError(result);
            }
        }

        public void Test()
        {
            int result = RARProcessFile(this.archiveHandle, 1, string.Empty, string.Empty);
            if (result != 0)
            {
                this.ProcessFileError(result);
            }
        }

        public string ArchivePathName
        {
            get => 
                this.archivePathName;
            set => 
                this.archivePathName = value;
        }

        public string Comment =>
            this.comment;

        public RARFileInfo CurrentFile =>
            this.currentFile;

        public string DestinationPath
        {
            get => 
                this.destinationPath;
            set => 
                this.destinationPath = value;
        }

        public string Password
        {
            get => 
                this.password;
            set
            {
                this.password = value;
                if (this.archiveHandle != IntPtr.Zero)
                {
                    RARSetPassword(this.archiveHandle, value);
                }
            }
        }

        [Flags]
        private enum ArchiveFlags : uint
        {
            Volume = 1,
            CommentPresent = 2,
            Lock = 4,
            SolidArchive = 8,
            NewNamingScheme = 0x10,
            AuthenticityPresent = 0x20,
            RecoveryRecordPresent = 0x40,
            EncryptedHeaders = 0x80,
            FirstVolume = 0x100
        }

        private enum CallbackMessages : uint
        {
            VolumeChange = 0,
            ProcessData = 1,
            NeedPassword = 2
        }

        public enum OpenMode
        {
            List,
            Extract
        }

        private enum Operation : uint
        {
            Skip = 0,
            Test = 1,
            Extract = 2
        }

        private enum RarError : uint
        {
            EndOfArchive = 10,
            InsufficientMemory = 11,
            BadData = 12,
            BadArchive = 13,
            UnknownFormat = 14,
            OpenError = 15,
            CreateError = 0x10,
            CloseError = 0x11,
            ReadError = 0x12,
            WriteError = 0x13,
            BufferTooSmall = 20,
            UnknownError = 0x15
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RARHeaderData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
            public string ArcName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
            public string FileName;
            public uint Flags;
            public uint PackSize;
            public uint UnpSize;
            public uint HostOS;
            public uint FileCRC;
            public uint FileTime;
            public uint UnpVer;
            public uint Method;
            public uint FileAttr;
            [MarshalAs(UnmanagedType.LPStr)]
            public string CmtBuf;
            public uint CmtBufSize;
            public uint CmtSize;
            public uint CmtState;
            public void Initialize()
            {
                this.CmtBuf = new string('\0', 0x10000);
                this.CmtBufSize = 0x10000;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
        public struct RARHeaderDataEx
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x200)]
            public string ArcName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x400)]
            public string ArcNameW;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x200)]
            public string FileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=0x400)]
            public string FileNameW;
            public uint Flags;
            public uint PackSize;
            public uint PackSizeHigh;
            public uint UnpSize;
            public uint UnpSizeHigh;
            public uint HostOS;
            public uint FileCRC;
            public uint FileTime;
            public uint UnpVer;
            public uint Method;
            public uint FileAttr;
            [MarshalAs(UnmanagedType.LPStr)]
            public string CmtBuf;
            public uint CmtBufSize;
            public uint CmtSize;
            public uint CmtState;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x400)]
            public uint[] Reserved;
            public void Initialize()
            {
                this.CmtBuf = new string('\0', 0x10000);
                this.CmtBufSize = 0x10000;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAROpenArchiveData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
            public string ArcName;
            public uint OpenMode;
            public uint OpenResult;
            [MarshalAs(UnmanagedType.LPStr)]
            public string CmtBuf;
            public uint CmtBufSize;
            public uint CmtSize;
            public uint CmtState;
            public void Initialize()
            {
                this.CmtBuf = new string('\0', 0x10000);
                this.CmtBufSize = 0x10000;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAROpenArchiveDataEx
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string ArcName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string ArcNameW;
            public uint OpenMode;
            public uint OpenResult;
            [MarshalAs(UnmanagedType.LPStr)]
            public string CmtBuf;
            public uint CmtBufSize;
            public uint CmtSize;
            public uint CmtState;
            public uint Flags;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x20)]
            public uint[] Reserved;
            public void Initialize()
            {
                this.CmtBuf = new string('\0', 0x10000);
                this.CmtBufSize = 0x10000;
                this.Reserved = new uint[0x20];
            }
        }

        private delegate int UNRARCallback(uint msg, int UserData, IntPtr p1, int p2);

        private enum VolumeMessage : uint
        {
            Ask = 0,
            Notify = 1
        }
    }
}

