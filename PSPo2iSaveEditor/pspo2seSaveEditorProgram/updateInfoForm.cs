namespace PSPo2iSaveEditor
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class updateInfoForm : Form
    {
        private IContainer components;
        private Label txtApplicationNameNew;
        private RichTextBox txtChangelog;
        private Label txtApplicationName;
        private Label label3;
        private Button btnIgnore;
        private Button btnDownload;
        private pspo2seForm parent;

        public updateInfoForm()
        {
            this.InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string str = "changelog.bin";
            if (Program.form.legitVersion())
            {
                str = "changelog_viewer.bin";
            }
            File.Delete("data/" + str);
            File.Move("data/temp/" + str, "data/" + str);
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            string str = "changelog.bin";
            if (Program.form.legitVersion())
            {
                str = "changelog_viewer.bin";
            }
            File.Delete("data/temp/" + str);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void formSetup(string newVersion)
        {
            this.parent = Program.form;
            string str = "PSPo2 Save Editor";
            string str2 = "changelog.bin";
            if (this.parent.legitVersion())
            {
                str2 = "changelog_viewer.bin";
                str = "PSPo2 Save Viewer";
            }
            string url = "http://files-ds-scene.net/retrohead/pspo2se/releases/" + str2;
            if (!this.parent.downloadFile(url, "data/temp/", "Change Log", ""))
            {
                MessageBox.Show("Failed to download the latest changelog, please check your internet connection\r\nor the site may be down!", "Change Log Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.txtApplicationName.Text = str + " v3.0 build 1008";
                this.txtApplicationNameNew.Text = str + " v" + newVersion;
                this.showChangeLogInfo();
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(updateInfoForm));
            this.txtApplicationNameNew = new Label();
            this.txtChangelog = new RichTextBox();
            this.txtApplicationName = new Label();
            this.label3 = new Label();
            this.btnIgnore = new Button();
            this.btnDownload = new Button();
            base.SuspendLayout();
            this.txtApplicationNameNew.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtApplicationNameNew.Location = new Point(10, 0x57);
            this.txtApplicationNameNew.Name = "txtApplicationNameNew";
            this.txtApplicationNameNew.Size = new Size(0x201, 0x17);
            this.txtApplicationNameNew.TabIndex = 3;
            this.txtApplicationNameNew.Text = "XXXXXXXXXX vX.X build xxxx";
            this.txtChangelog.Location = new Point(14, 110);
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            this.txtChangelog.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.txtChangelog.Size = new Size(510, 0xe9);
            this.txtChangelog.TabIndex = 2;
            this.txtChangelog.Text = "";
            this.txtApplicationName.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtApplicationName.Location = new Point(11, 0x17);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new Size(0x201, 0x17);
            this.txtApplicationName.TabIndex = 4;
            this.txtApplicationName.Text = "XXXXXXXXXX vX.X build xxxx";
            this.label3.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(10, 0x48);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x201, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Update Available";
            this.btnIgnore.Cursor = Cursors.Hand;
            this.btnIgnore.DialogResult = DialogResult.No;
            this.btnIgnore.Location = new Point(0x151, 0x15d);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new Size(0x4b, 0x17);
            this.btnIgnore.TabIndex = 7;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new EventHandler(this.btnIgnore_Click);
            this.btnDownload.Cursor = Cursors.Hand;
            this.btnDownload.DialogResult = DialogResult.Yes;
            this.btnDownload.Location = new Point(0x1a2, 0x15d);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new Size(0x69, 0x17);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "Download Update";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new EventHandler(this.btnDownload_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x217, 0x17a);
            base.Controls.Add(this.btnDownload);
            base.Controls.Add(this.btnIgnore);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.txtApplicationName);
            base.Controls.Add(this.txtApplicationNameNew);
            base.Controls.Add(this.txtChangelog);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "updateInfoForm";
            this.Text = "PSPo2se Update Information";
            base.ResumeLayout(false);
        }

        private void showChangeLogInfo()
        {
            string str = "";
            try
            {
                string str2 = "changelog.bin";
                if (Program.form.legitVersion())
                {
                    str2 = "changelog_viewer.bin";
                }
                FileStream fs = new FileStream("data//temp/" + str2, FileMode.Open, FileAccess.Read);
                string sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                using (StreamReader reader = new StreamReader(this.parent.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    while (true)
                    {
                        string str4 = reader.ReadLine();
                        if (str4 == null)
                        {
                            reader.Close();
                            break;
                        }
                        str = str + str4 + "\r\n";
                    }
                }
                fs.Close();
            }
            catch (Exception)
            {
                str = str + @"{\rtf1\ansi\ansicpg1252\deff0\deflang2057{\fonttbl{\f0\fnil\fcharset0 Verdana;}}\r\n" + @"{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\b\f0\fs28 PSPo2 Save Editor Change Log\par\r\n";
            }
            this.txtChangelog.Rtf = str;
        }
    }
}

