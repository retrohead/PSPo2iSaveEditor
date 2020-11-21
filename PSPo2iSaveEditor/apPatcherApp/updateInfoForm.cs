namespace apPatcherApp
{
    using apPatcherApp.Properties;
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
        private Label label3;
        private Button btnIgnore;
        private Button btnDownload;
        private RadioButton radioButtonCyclo;
        private Label label1;
        private RadioButton radioButtonEdge;
        private RadioButton radioButtonUsrcheat;
        private GroupBox groupBoxCMP;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox updateTypeIcon;
        private Label txtApplicationName;
        private apPatcherAppForm.cmpDownloadType CMPtype;
        private apPatcherAppForm parent;
        private bool close_blocked;
        private string type = "";

        public updateInfoForm()
        {
            this.InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string str = "";
            string str2 = "";
            if (this.type == "app")
            {
                str = "changelog_build_1200.bin";
                str2 = "changelog_build_1200.bin";
            }
            else if (this.type == "db")
            {
                str = "databases/changelog_db.bin";
                str2 = "changelog_db.bin";
            }
            else
            {
                str = "databases/changelog_cmp.bin";
                str2 = "changelog_cmp.bin";
                this.CMPtype = apPatcherAppForm.cmpDownloadType.none;
                if (this.radioButtonUsrcheat.Checked)
                {
                    this.CMPtype = apPatcherAppForm.cmpDownloadType.USRcheat;
                }
                if (this.radioButtonCyclo.Checked)
                {
                    this.CMPtype = apPatcherAppForm.cmpDownloadType.CycloDS;
                }
                if (this.radioButtonEdge.Checked)
                {
                    this.CMPtype = apPatcherAppForm.cmpDownloadType.EDGE;
                }
                if (this.CMPtype == apPatcherAppForm.cmpDownloadType.none)
                {
                    MessageBox.Show("You must select which type of CMP Database you wish to install", "CMP Database Type Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.close_blocked = true;
                    return;
                }
            }
            if (!System.IO.File.Exists("data/temp/" + str2))
            {
                MessageBox.Show("Error! A temporary changelog file was not found", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                System.IO.File.Delete("data/" + str);
                System.IO.File.Move("data/temp/" + str2, "data/" + str);
            }
            this.close_blocked = false;
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete("data/temp/" + ((this.type != "app") ? ((this.type != "db") ? "changelog_cmp.bin" : "changelog_db.bin") : "changelog_build_1200.bin"));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void form_FormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = this.close_blocked;
            this.close_blocked = false;
        }

        public void formSetup(string changeLogType, string newVersion)
        {
            this.close_blocked = false;
            this.CMPtype = apPatcherAppForm.cmpDownloadType.none;
            this.type = changeLogType;
            this.parent = Program.form;
            string str = "DS-Scene Rom Tool";
            string str2 = "";
            string saveas = "";
            if (this.type == "app")
            {
                str2 = "changelog_build_1200.bin";
                saveas = "changelog_build_1200.bin";
                this.groupBoxCMP.Visible = false;
            }
            else if (this.type == "db")
            {
                str2 = "databases/changelog_db.bin";
                saveas = "changelog_db.bin";
                this.groupBoxCMP.Visible = false;
            }
            else
            {
                str2 = "cmp/changelog_cmp.bin";
                saveas = "changelog_cmp.bin";
                this.groupBoxCMP.Visible = true;
                this.radioButtonCyclo.Checked = false;
                this.radioButtonEdge.Checked = false;
                this.radioButtonUsrcheat.Checked = false;
                this.radioButtonUsrcheat.Enabled = Program.form.cmpCheckFile[0].update_available;
                this.radioButtonEdge.Enabled = Program.form.cmpCheckFile[1].update_available;
                this.radioButtonCyclo.Enabled = Program.form.cmpCheckFile[2].update_available;
            }
            this.Text = "DS-Scene Rom Tool v1.0 build 1215 Update Information";
            string url = "http://files-ds-scene.net/romtool/releases/" + str2;
            if (!this.parent.downloadFile(url, "data/temp/", "Change Log", saveas, null, null))
            {
                MessageBox.Show("Failed to download the latest changelog, please check your internet connection\r\nor the site may be down!", "Change Log Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (this.type == "app")
                {
                    this.txtApplicationName.Text = str + " Update";
                    this.txtApplicationNameNew.Text = str + " v" + newVersion;
                    this.updateTypeIcon.Image = Resources.romtool;
                }
                else if (this.type == "db")
                {
                    this.txtApplicationName.Text = "AP Database Update";
                    this.txtApplicationNameNew.Text = "offsets.dsapdb v" + newVersion;
                    this.updateTypeIcon.Image = Resources.ap_icon;
                }
                else
                {
                    this.txtApplicationName.Text = "CMP Database Update";
                    this.txtApplicationNameNew.Text = "version " + newVersion;
                    this.updateTypeIcon.Image = Resources.cmp_icon;
                }
                this.showChangeLogInfo();
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(updateInfoForm));
            this.txtApplicationNameNew = new Label();
            this.txtChangelog = new RichTextBox();
            this.label3 = new Label();
            this.btnIgnore = new Button();
            this.btnDownload = new Button();
            this.radioButtonCyclo = new RadioButton();
            this.label1 = new Label();
            this.radioButtonEdge = new RadioButton();
            this.radioButtonUsrcheat = new RadioButton();
            this.groupBoxCMP = new GroupBox();
            this.pictureBox3 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox1 = new PictureBox();
            this.updateTypeIcon = new PictureBox();
            this.txtApplicationName = new Label();
            this.groupBoxCMP.SuspendLayout();
            ((ISupportInitialize) this.pictureBox3).BeginInit();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            ((ISupportInitialize) this.updateTypeIcon).BeginInit();
            base.SuspendLayout();
            this.txtApplicationNameNew.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtApplicationNameNew.ForeColor = Color.Red;
            this.txtApplicationNameNew.Location = new Point(9, 0x37);
            this.txtApplicationNameNew.Name = "txtApplicationNameNew";
            this.txtApplicationNameNew.Size = new Size(0x201, 0x17);
            this.txtApplicationNameNew.TabIndex = 3;
            this.txtApplicationNameNew.Text = "XXXXXXXXXX vX.X build xxxx";
            this.txtChangelog.Location = new Point(11, 0x4e);
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            this.txtChangelog.Size = new Size(510, 0xe9);
            this.txtChangelog.TabIndex = 2;
            this.txtChangelog.Text = "";
            this.txtChangelog.WordWrap = false;
            this.label3.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.Red;
            this.label3.Location = new Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x201, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Update Available";
            this.btnIgnore.Cursor = Cursors.Hand;
            this.btnIgnore.DialogResult = DialogResult.No;
            this.btnIgnore.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnIgnore.Image = (Image) manager.GetObject("btnIgnore.Image");
            this.btnIgnore.Location = new Point(0x11d, 0x139);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Padding = new Padding(3);
            this.btnIgnore.Size = new Size(120, 30);
            this.btnIgnore.TabIndex = 7;
            this.btnIgnore.Text = "Ignore Update";
            this.btnIgnore.TextAlign = ContentAlignment.MiddleLeft;
            this.btnIgnore.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new EventHandler(this.btnIgnore_Click);
            this.btnDownload.Cursor = Cursors.Hand;
            this.btnDownload.DialogResult = DialogResult.Yes;
            this.btnDownload.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnDownload.Image = (Image) manager.GetObject("btnDownload.Image");
            this.btnDownload.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new Point(0x196, 0x139);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Padding = new Padding(3);
            this.btnDownload.Size = new Size(0x74, 30);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "Install Update";
            this.btnDownload.TextAlign = ContentAlignment.MiddleLeft;
            this.btnDownload.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new EventHandler(this.btnDownload_Click);
            this.radioButtonCyclo.AutoSize = true;
            this.radioButtonCyclo.Cursor = Cursors.Hand;
            this.radioButtonCyclo.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioButtonCyclo.Location = new Point(0x1c, 14);
            this.radioButtonCyclo.Name = "radioButtonCyclo";
            this.radioButtonCyclo.Size = new Size(0x43, 0x10);
            this.radioButtonCyclo.TabIndex = 9;
            this.radioButtonCyclo.TabStop = true;
            this.radioButtonCyclo.Text = "CycloDS";
            this.radioButtonCyclo.UseVisualStyleBackColor = true;
            this.label1.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.ControlDarkDark;
            this.label1.Location = new Point(4, 0x22);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x109, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "CMP databases already installed are disabled";
            this.label1.TextAlign = ContentAlignment.TopCenter;
            this.radioButtonEdge.AutoSize = true;
            this.radioButtonEdge.Cursor = Cursors.Hand;
            this.radioButtonEdge.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioButtonEdge.Location = new Point(0x73, 15);
            this.radioButtonEdge.Name = "radioButtonEdge";
            this.radioButtonEdge.Size = new Size(0x35, 0x10);
            this.radioButtonEdge.TabIndex = 11;
            this.radioButtonEdge.TabStop = true;
            this.radioButtonEdge.Text = "EDGE";
            this.radioButtonEdge.UseVisualStyleBackColor = true;
            this.radioButtonUsrcheat.AutoSize = true;
            this.radioButtonUsrcheat.Cursor = Cursors.Hand;
            this.radioButtonUsrcheat.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioButtonUsrcheat.Location = new Point(0xc4, 15);
            this.radioButtonUsrcheat.Name = "radioButtonUsrcheat";
            this.radioButtonUsrcheat.Size = new Size(0x49, 0x10);
            this.radioButtonUsrcheat.TabIndex = 12;
            this.radioButtonUsrcheat.TabStop = true;
            this.radioButtonUsrcheat.Text = "USRcheat";
            this.radioButtonUsrcheat.UseVisualStyleBackColor = true;
            this.groupBoxCMP.Controls.Add(this.pictureBox3);
            this.groupBoxCMP.Controls.Add(this.pictureBox2);
            this.groupBoxCMP.Controls.Add(this.pictureBox1);
            this.groupBoxCMP.Controls.Add(this.radioButtonCyclo);
            this.groupBoxCMP.Controls.Add(this.radioButtonUsrcheat);
            this.groupBoxCMP.Controls.Add(this.label1);
            this.groupBoxCMP.Controls.Add(this.radioButtonEdge);
            this.groupBoxCMP.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.groupBoxCMP.Location = new Point(11, 0x132);
            this.groupBoxCMP.Name = "groupBoxCMP";
            this.groupBoxCMP.Size = new Size(0x110, 0x31);
            this.groupBoxCMP.TabIndex = 13;
            this.groupBoxCMP.TabStop = false;
            this.pictureBox3.Image = Resources.cyclo;
            this.pictureBox3.Location = new Point(6, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(0x12, 0x13);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            this.pictureBox2.Image = Resources.edge1;
            this.pictureBox2.Location = new Point(0x5e, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(0x12, 0x13);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox1.Image = Resources.r41;
            this.pictureBox1.Location = new Point(0xae, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x12, 0x13);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.updateTypeIcon.Image = Resources.romtool;
            this.updateTypeIcon.Location = new Point(12, 12);
            this.updateTypeIcon.Name = "updateTypeIcon";
            this.updateTypeIcon.Size = new Size(0x10, 0x10);
            this.updateTypeIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.updateTypeIcon.TabIndex = 0x58;
            this.updateTypeIcon.TabStop = false;
            this.txtApplicationName.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtApplicationName.ImageAlign = ContentAlignment.MiddleLeft;
            this.txtApplicationName.Location = new Point(0x1b, 8);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Padding = new Padding(3);
            this.txtApplicationName.Size = new Size(0x1ed, 0x17);
            this.txtApplicationName.TabIndex = 0x57;
            this.txtApplicationName.Text = "XXXXXXXXXX vX.X build xxxx";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x214, 0x166);
            base.Controls.Add(this.updateTypeIcon);
            base.Controls.Add(this.txtApplicationName);
            base.Controls.Add(this.txtChangelog);
            base.Controls.Add(this.groupBoxCMP);
            base.Controls.Add(this.btnDownload);
            base.Controls.Add(this.btnIgnore);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.txtApplicationNameNew);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "updateInfoForm";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "DS-Scene  Update Information";
            base.FormClosing += new FormClosingEventHandler(this.form_FormClosing);
            this.groupBoxCMP.ResumeLayout(false);
            this.groupBoxCMP.PerformLayout();
            ((ISupportInitialize) this.pictureBox3).EndInit();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            ((ISupportInitialize) this.updateTypeIcon).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void showChangeLogInfo()
        {
            string str = "";
            try
            {
                string str2 = "";
                str2 = (this.type != "app") ? ((this.type != "db") ? "changelog_cmp.bin" : "changelog_db.bin") : "changelog_build_1200.bin";
                FileStream fs = new FileStream("data//temp/" + str2, FileMode.Open, FileAccess.Read);
                string sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                if (this.type == "cmp")
                {
                    sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F006F003F003F001000000069003F00");
                }
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
                str = str + @"{\rtf1\ansi\ansicpg1252\deff0\deflang2057{\fonttbl{\f0\fnil\fcharset0 Verdana;}}\r\n" + @"{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\b\f0\fs28 DS-Scene Rom Tool Change Log\par\r\n";
            }
            this.txtChangelog.Rtf = str;
        }

        public apPatcherAppForm.cmpDownloadType cmptype
        {
            get => 
                this.CMPtype;
            set => 
                this.CMPtype = value;
        }
    }
}

