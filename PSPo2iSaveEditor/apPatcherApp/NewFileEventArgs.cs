namespace apPatcherApp
{
    using System;

    public class NewFileEventArgs
    {
        public RARFileInfo fileInfo;

        public NewFileEventArgs(RARFileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }
    }
}

