namespace apPatcherApp
{
    using System;

    public class NewVolumeEventArgs
    {
        public string VolumeName;
        public bool ContinueOperation = true;

        public NewVolumeEventArgs(string volumeName)
        {
            this.VolumeName = volumeName;
        }
    }
}

