namespace apPatcherApp
{
    using System;

    public class MissingVolumeEventArgs
    {
        public string VolumeName;
        public bool ContinueOperation;

        public MissingVolumeEventArgs(string volumeName)
        {
            this.VolumeName = volumeName;
        }
    }
}

