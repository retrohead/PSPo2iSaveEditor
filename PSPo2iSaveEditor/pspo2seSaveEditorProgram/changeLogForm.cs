namespace PSPo2iSaveEditor
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class changeLogForm : Form
    {
        private IContainer components;
        private RichTextBox txtChangelog;
        private Label txtApplicationName;
        private Label label2;
        private Label txtDatabaseCount;
        private Label txtInstalledDbs;
        private Label txtImagePack;
        private GroupBox groupBox1;
        private Button button1;
        private pspo2seForm parent;
        private int curdbitems;

        public changeLogForm()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void formSetup()
        {
            this.parent = Program.form;
            this.txtApplicationName.Text = "PSPo2 Save Editor";
            if (this.parent.legitVersion())
            {
                this.txtApplicationName.Text = "PSPo2 Save Viewer";
            }
            this.txtApplicationName.Text = this.txtApplicationName.Text + " v3.0 build 1008";
            this.showDatabaseInfo();
            this.showImagePackInfo();
            this.showChangeLogInfo();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(changeLogForm));
            this.txtChangelog = new RichTextBox();
            this.txtApplicationName = new Label();
            this.label2 = new Label();
            this.txtDatabaseCount = new Label();
            this.txtInstalledDbs = new Label();
            this.txtImagePack = new Label();
            this.groupBox1 = new GroupBox();
            this.button1 = new Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.txtChangelog.Location = new Point(12, 0x23);
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            this.txtChangelog.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.txtChangelog.Size = new Size(510, 0xe9);
            this.txtChangelog.TabIndex = 0;
            this.txtChangelog.Text = "";
            this.txtApplicationName.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtApplicationName.Location = new Point(9, 9);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new Size(0x201, 0x17);
            this.txtApplicationName.TabIndex = 1;
            this.txtApplicationName.Text = "XXXXXXXXXX vX.X build xxxx";
            this.label2.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x11d, 0x10);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xb3, 0x12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Installed Image Pack ";
            this.txtDatabaseCount.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtDatabaseCount.Location = new Point(5, 0x10);
            this.txtDatabaseCount.Name = "txtDatabaseCount";
            this.txtDatabaseCount.Size = new Size(0x9d, 0x12);
            this.txtDatabaseCount.TabIndex = 3;
            this.txtDatabaseCount.Text = "1 Database Installed ";
            this.txtInstalledDbs.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInstalledDbs.Location = new Point(5, 0x22);
            this.txtInstalledDbs.Name = "txtInstalledDbs";
            this.txtInstalledDbs.Size = new Size(0xbd, 0x51);
            this.txtInstalledDbs.TabIndex = 4;
            this.txtInstalledDbs.Text = "Installed Database1";
            this.txtImagePack.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtImagePack.Location = new Point(0x11d, 0x22);
            this.txtImagePack.Name = "txtImagePack";
            this.txtImagePack.Size = new Size(0xc5, 0x12);
            this.txtImagePack.TabIndex = 5;
            this.txtImagePack.Text = "File Name.zip";
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInstalledDbs);
            this.groupBox1.Controls.Add(this.txtImagePack);
            this.groupBox1.Controls.Add(this.txtDatabaseCount);
            this.groupBox1.Location = new Point(12, 0x112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(510, 0x79);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.button1.Cursor = Cursors.Hand;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Location = new Point(0x1bf, 0x191);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 7;
            this.button1.Text = "close";
            this.button1.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x217, 0x1aa);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.txtApplicationName);
            base.Controls.Add(this.txtChangelog);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "changeLogForm";
            base.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "Change Log Viewer";
            this.groupBox1.ResumeLayout(false);
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
                FileStream fs = new FileStream("data//" + str2, FileMode.Open, FileAccess.Read);
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
                str = str + @"{\rtf1\ansi\ansicpg1252\deff0\deflang2057{\fonttbl{\f0\fnil\fcharset0 Verdana;}}\r\n" + @"{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\b\f0\fs28 PSPo2 Save Editor Change Log\par\r\n\fs16 No changes were made since the last major release (3.0 build 1001)";
            }
            this.txtChangelog.Rtf = str;
        }

        private void showDatabaseInfo()
        {
            this.curdbitems = 0;
            pspo2seForm.updateCSVInfo[] infoArray = new pspo2seForm.updateCSVInfo[20];
            try
            {
                string sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.parent.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    string str2 = "";
                    while (true)
                    {
                        str2 = reader.ReadLine();
                        if (str2 != null)
                        {
                            char[] separator = new char[] { '|' };
                            string[] strArray = str2.Split(separator);
                            infoArray[this.curdbitems] = new pspo2seForm.updateCSVInfo();
                            infoArray[this.curdbitems].fn = strArray[0];
                            infoArray[this.curdbitems].ver = strArray[1];
                            this.curdbitems++;
                            if (this.curdbitems < 20)
                            {
                                continue;
                            }
                        }
                        reader.Close();
                        fs.Close();
                        break;
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
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
                    this.txtDatabaseCount.Text = this.curdbitems + " Databases Installed";
                    break;
            }
            this.txtInstalledDbs.Text = "";
            if (this.curdbitems > 0)
            {
                for (int i = 0; i < this.curdbitems; i++)
                {
                    string text = this.txtInstalledDbs.Text;
                    string[] strArray2 = new string[] { text, infoArray[i].fn, " v", infoArray[i].ver, "\r\n" };
                    this.txtInstalledDbs.Text = string.Concat(strArray2);
                }
            }
        }

        private void showImagePackInfo()
        {
            string str = "";
            try
            {
                string str2 = "image_pack_version.bin";
                string sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/" + str2, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.parent.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    string str4 = reader.ReadLine();
                    if (str4 != null)
                    {
                        str = str4;
                    }
                    reader.Close();
                }
                fs.Close();
            }
            catch
            {
                str = "No Image Pack Installed";
            }
            this.txtImagePack.Text = str;
        }
    }
}

