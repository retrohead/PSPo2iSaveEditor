namespace pspo2seSaveEditorProgram
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        public static pspo2seForm thisForm;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new pspo2seForm();
            Application.Run(form);
        }

        public static pspo2seForm form
        {
            get => 
                thisForm;
            set => 
                thisForm = value;
        }
    }
}

