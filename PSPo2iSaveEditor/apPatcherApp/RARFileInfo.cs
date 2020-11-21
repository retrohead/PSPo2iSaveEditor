namespace apPatcherApp
{
    using System;

    public class RARFileInfo
    {
        public string FileName;
        public bool ContinuedFromPrevious;
        public bool ContinuedOnNext;
        public bool IsDirectory;
        public long PackedSize;
        public long UnpackedSize;
        public int HostOS;
        public long FileCRC;
        public DateTime FileTime;
        public int VersionToUnpack;
        public int Method;
        public int FileAttributes;
        public long BytesExtracted;

        public double PercentComplete =>
            (this.UnpackedSize == 0L) ? 0.0 : ((((double) this.BytesExtracted) / ((double) this.UnpackedSize)) * 100.0);
    }
}

