namespace apPatcherApp
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        public static apPatcherAppForm thisForm;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new apPatcherAppForm();
            Application.Run(form);
        }

        public static apPatcherAppForm form
        {
            get => 
                thisForm;
            set => 
                thisForm = value;
        }
    }
}

