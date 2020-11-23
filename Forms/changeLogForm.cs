using System;
using System.IO;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class changeLogForm : Form
    {
        private pspo2seForm parent;
        private int curdbitems;


        public changeLogForm()
        {
            this.InitializeComponent();
        }
        private void showDatabaseInfo()
        {
            this.curdbitems = 0;
            pspo2seForm.updateCSVInfo[] updateCsvInfoArray = new pspo2seForm.updateCSVInfo[20];
            try
            {
                string encryptionKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)this.parent.encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string str;
                    while ((str = streamReader.ReadLine()) != null)
                    {
                        string[] strArray = str.Split('|');
                        updateCsvInfoArray[this.curdbitems] = new pspo2seForm.updateCSVInfo();
                        updateCsvInfoArray[this.curdbitems].fn = strArray[0];
                        updateCsvInfoArray[this.curdbitems].ver = strArray[1];
                        ++this.curdbitems;
                        if (this.curdbitems >= 20)
                            break;
                    }
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            switch (this.curdbitems)
            {
                case 0:
                    this.txtDatabaseCount.Text = "No Databases Installed";
                    break;
                case 1:
                    this.txtDatabaseCount.Text = "1 Database Installed";
                    break;
                default:
                    this.txtDatabaseCount.Text = this.curdbitems.ToString() + " Databases Installed";
                    break;
            }
            this.txtInstalledDbs.Text = "";
            if (this.curdbitems <= 0)
                return;
            for (int index = 0; index < this.curdbitems; ++index)
            {
                Label txtInstalledDbs = this.txtInstalledDbs;
                txtInstalledDbs.Text = txtInstalledDbs.Text + updateCsvInfoArray[index].fn + " v" + updateCsvInfoArray[index].ver + "\r\n";
            }
        }

        private void showImagePackInfo()
        {
            string str1 = "";
            try
            {
                string str2 = "image_pack_version.bin";
                string encryptionKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/" + str2, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)this.parent.encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string str3;
                    if ((str3 = streamReader.ReadLine()) != null)
                        str1 = str3;
                    streamReader.Close();
                }
                fs.Close();
            }
            catch
            {
                str1 = "No Image Pack Installed";
            }
            this.txtImagePack.Text = str1;
        }

        private void showChangeLogInfo()
        {
            string str1 = "";
            try
            {
                string str2 = "changelog.bin";
                if (Program.form.legitVersion())
                    str2 = "changelog_viewer.bin";
                FileStream fs = new FileStream("data//" + str2, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)this.parent.encryptor.createDecryptionReadStream(this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), fs)))
                {
                    string str3;
                    while ((str3 = streamReader.ReadLine()) != null)
                        str1 = str1 + str3 + "\r\n";
                    streamReader.Close();
                }
                fs.Close();
            }
            catch
            {
                str1 = str1 + "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang2057{\\fonttbl{\\f0\\fnil\\fcharset0 Verdana;}}\\r\\n" + "{\\*\\generator Msftedit 5.41.21.2509;}\\viewkind4\\uc1\\pard\\sa200\\sl276\\slmult1\\lang9\\b\\f0\\fs28 PSPo2 Save Editor Change Log\\par\\r\\n\\fs16 No changes were made since the last major release (3.0 build 1001)";
            }
            this.txtChangelog.Rtf = str1;
        }

        public void formSetup()
        {
            this.parent = Program.form;
            this.txtApplicationName.Text = "PSPo2 Save Editor";
            if (this.parent.legitVersion())
                this.txtApplicationName.Text = "PSPo2 Save Viewer";
            this.txtApplicationName.Text += " v3.0 build 1008";
            this.showDatabaseInfo();
            this.showImagePackInfo();
            this.showChangeLogInfo();
        }
    }
}
