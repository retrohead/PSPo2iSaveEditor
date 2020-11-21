namespace apPatcherApp
{
    using System;

    public class PasswordRequiredEventArgs
    {
        public string Password = string.Empty;
        public bool ContinueOperation = true;
    }
}

