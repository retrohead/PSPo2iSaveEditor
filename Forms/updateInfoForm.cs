using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class updateInfoForm : Form
    {
        private pspo2seForm parent;

        private void showChangeLogInfo()
        {
            string str1 = "";
            try
            {
                string str2 = "changelog.bin";
                if (Program.form.legitVersion())
                    str2 = "changelog_viewer.bin";
                FileStream fs = new FileStream("data//temp/" + str2, FileMode.Open, FileAccess.Read);
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
                str1 = str1 + "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang2057{\\fonttbl{\\f0\\fnil\\fcharset0 Verdana;}}\\r\\n" + "{\\*\\generator Msftedit 5.41.21.2509;}\\viewkind4\\uc1\\pard\\sa200\\sl276\\slmult1\\lang9\\b\\f0\\fs28 PSPo2 Save Editor Change Log\\par\\r\\n";
            }
            this.txtChangelog.Rtf = str1;
        }

        public void formSetup(string newVersion)
        {
            this.parent = Program.form;
            string str1 = "PSPo2 Save Editor";
            string str2 = "changelog.bin";
            if (this.parent.legitVersion())
            {
                str2 = "changelog_viewer.bin";
                str1 = "PSPo2 Save Viewer";
            }
            if (this.parent.downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str2, "data/temp/", "Change Log"))
            {
                this.txtApplicationName.Text = str1 + " v3.0 build 1008";
                this.txtApplicationNameNew.Text = str1 + " v" + newVersion;
                this.showChangeLogInfo();
            }
            else
            {
                int num = (int)MessageBox.Show("Failed to download the latest changelog, please check your internet connection\r\nor the site may be down!", "Change Log Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public updateInfoForm() => this.InitializeComponent();

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string str = "changelog.bin";
            if (Program.form.legitVersion())
                str = "changelog_viewer.bin";
            File.Delete("data/" + str);
            File.Move("data/temp/" + str, "data/" + str);
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            string str = "changelog.bin";
            if (Program.form.legitVersion())
                str = "changelog_viewer.bin";
            File.Delete("data/temp/" + str);
        }
    }
}
