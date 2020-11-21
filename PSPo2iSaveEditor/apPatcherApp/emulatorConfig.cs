namespace apPatcherApp
{
    using apPatcherApp.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class emulatorConfig : Form
    {
        private IContainer components;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        public TextBox txtFileLocEmu1;
        private Button btnBrowseEmu1;
        private PictureBox pictureBox2;
        private GroupBox groupBox2;
        public TextBox txtFileLocEmu0;
        private Button btnBrowseEmu0;
        private PictureBox pictureBox3;
        private GroupBox groupBox3;
        public TextBox txtFileLocEmu2;
        private Button btnBrowseEmu2;
        private Button btnClose;
        private Button btnApply;
        public RadioButton radioDefault_0;
        public RadioButton radioDefault_2;
        public RadioButton radioDefault_1;
        private Label label2;
        private Label label1;
        private Label label4;
        public TextBox txtFileLocEndrypts;
        private Button btnBrowseEndrypts;
        private Label label3;

        public emulatorConfig()
        {
            this.InitializeComponent();
        }

        private string browseForFile(string fileFilter)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = fileFilter
            };
            dialog.ShowDialog();
            return dialog.FileName;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Program.form.options.save();
            Program.form.options.load();
            this.emulatorConfig_Load(null, null);
            this.btnApply.Enabled = false;
            MessageBox.Show("Configuration Saved Successfully", "Configuration Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnBrowseEmu0_Click(object sender, EventArgs e)
        {
            string str = this.browseForFile("DeSmuME Emulator|DeSmuME.exe;DeSmuME_dev.exe;DeSmuME_x64.exe|All Files|*.*");
            if (str != "")
            {
                this.txtFileLocEmu0.Text = str;
                this.radioDefault_0.Enabled = true;
                this.radioDefault_0.Checked = true;
                this.btnApply.Enabled = true;
            }
        }

        private void btnBrowseEmu1_Click(object sender, EventArgs e)
        {
            string str = this.browseForFile("Ideas Emulator|ideas.exe");
            if (str != "")
            {
                this.txtFileLocEmu1.Text = str;
                this.btnApply.Enabled = true;
                this.radioDefault_1.Enabled = true;
                this.radioDefault_1.Checked = true;
            }
        }

        private void btnBrowseEmu2_Click(object sender, EventArgs e)
        {
            string str = this.browseForFile("NO$GBA Emulator|NO$GBA.exe;NOGBA.exe;NOCASHGBA.exe|All Files|*.*");
            if (str != "")
            {
                this.txtFileLocEmu2.Text = str;
                this.btnApply.Enabled = true;
                this.radioDefault_2.Enabled = true;
                this.radioDefault_2.Checked = true;
            }
        }

        private void btnBrowseEndrypts_Click(object sender, EventArgs e)
        {
            string str = this.browseForFile("eNDryptS Location|eNDryptS Advanced.exe;eNDryptS.exe|All Files|*.*");
            if (str != "")
            {
                this.txtFileLocEndrypts.Text = str;
                this.btnApply.Enabled = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void emulatorConfig_Load(object sender, EventArgs e)
        {
            Program.form.options.load();
            for (int i = 0; i < 3; i++)
            {
                TextBox box = null;
                RadioButton button = null;
                int num2 = i;
                switch (num2)
                {
                    case 0:
                        box = this.txtFileLocEmu0;
                        button = this.radioDefault_0;
                        break;

                    case 1:
                        box = this.txtFileLocEmu1;
                        button = this.radioDefault_1;
                        break;

                    case 2:
                        box = this.txtFileLocEmu2;
                        button = this.radioDefault_2;
                        break;

                    default:
                        MessageBox.Show("Fatal Error, emu_" + i + " not handled in switch in emulatorConfig_Load");
                        break;
                }
                if (box != null)
                {
                    box.Text = Program.form.options.getValue("emu_" + i);
                    if (box.Text != "")
                    {
                        button.Enabled = true;
                    }
                }
                if ((Program.form.options.getValue("emu_default") == Program.form.options.getValue("emu_" + i)) && (Program.form.options.getValue("emu_default") != ""))
                {
                    button.Checked = true;
                }
                this.txtFileLocEndrypts.Text = Program.form.options.getValue("endrypts");
                this.btnApply.Enabled = false;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(emulatorConfig));
            this.groupBox1 = new GroupBox();
            this.txtFileLocEmu1 = new TextBox();
            this.btnBrowseEmu1 = new Button();
            this.groupBox2 = new GroupBox();
            this.txtFileLocEmu0 = new TextBox();
            this.btnBrowseEmu0 = new Button();
            this.groupBox3 = new GroupBox();
            this.txtFileLocEmu2 = new TextBox();
            this.btnBrowseEmu2 = new Button();
            this.pictureBox3 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox1 = new PictureBox();
            this.btnClose = new Button();
            this.btnApply = new Button();
            this.radioDefault_0 = new RadioButton();
            this.radioDefault_2 = new RadioButton();
            this.radioDefault_1 = new RadioButton();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.txtFileLocEndrypts = new TextBox();
            this.btnBrowseEndrypts = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((ISupportInitialize) this.pictureBox3).BeginInit();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFileLocEmu1);
            this.groupBox1.Controls.Add(this.btnBrowseEmu1);
            this.groupBox1.Location = new Point(7, 0x83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x181, 0x52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.txtFileLocEmu1.Location = new Point(0x70, 0x23);
            this.txtFileLocEmu1.Name = "txtFileLocEmu1";
            this.txtFileLocEmu1.ReadOnly = true;
            this.txtFileLocEmu1.Size = new Size(0xe7, 20);
            this.txtFileLocEmu1.TabIndex = 0x51;
            this.btnBrowseEmu1.Cursor = Cursors.Hand;
            this.btnBrowseEmu1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseEmu1.Location = new Point(0x15a, 0x23);
            this.btnBrowseEmu1.Name = "btnBrowseEmu1";
            this.btnBrowseEmu1.Size = new Size(0x1f, 20);
            this.btnBrowseEmu1.TabIndex = 80;
            this.btnBrowseEmu1.Text = "...";
            this.btnBrowseEmu1.UseVisualStyleBackColor = true;
            this.btnBrowseEmu1.Click += new EventHandler(this.btnBrowseEmu1_Click);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtFileLocEmu0);
            this.groupBox2.Controls.Add(this.btnBrowseEmu0);
            this.groupBox2.Location = new Point(7, 0x1f);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x181, 0x52);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.txtFileLocEmu0.Location = new Point(0x70, 0x23);
            this.txtFileLocEmu0.Name = "txtFileLocEmu0";
            this.txtFileLocEmu0.ReadOnly = true;
            this.txtFileLocEmu0.Size = new Size(0xe7, 20);
            this.txtFileLocEmu0.TabIndex = 0x51;
            this.btnBrowseEmu0.Cursor = Cursors.Hand;
            this.btnBrowseEmu0.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseEmu0.Location = new Point(0x15a, 0x23);
            this.btnBrowseEmu0.Name = "btnBrowseEmu0";
            this.btnBrowseEmu0.Size = new Size(0x1f, 20);
            this.btnBrowseEmu0.TabIndex = 80;
            this.btnBrowseEmu0.Text = "...";
            this.btnBrowseEmu0.UseVisualStyleBackColor = true;
            this.btnBrowseEmu0.Click += new EventHandler(this.btnBrowseEmu0_Click);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtFileLocEndrypts);
            this.groupBox3.Controls.Add(this.btnBrowseEndrypts);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtFileLocEmu2);
            this.groupBox3.Controls.Add(this.btnBrowseEmu2);
            this.groupBox3.Location = new Point(7, 0xe7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x181, 0x60);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.txtFileLocEmu2.Location = new Point(0x70, 0x17);
            this.txtFileLocEmu2.Name = "txtFileLocEmu2";
            this.txtFileLocEmu2.ReadOnly = true;
            this.txtFileLocEmu2.Size = new Size(0xe7, 20);
            this.txtFileLocEmu2.TabIndex = 0x51;
            this.btnBrowseEmu2.Cursor = Cursors.Hand;
            this.btnBrowseEmu2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseEmu2.Location = new Point(0x15a, 0x17);
            this.btnBrowseEmu2.Name = "btnBrowseEmu2";
            this.btnBrowseEmu2.Size = new Size(0x1f, 20);
            this.btnBrowseEmu2.TabIndex = 80;
            this.btnBrowseEmu2.Text = "...";
            this.btnBrowseEmu2.UseVisualStyleBackColor = true;
            this.btnBrowseEmu2.Click += new EventHandler(this.btnBrowseEmu2_Click);
            this.pictureBox3.Image = Resources.nocashgba_logo;
            this.pictureBox3.Location = new Point(0x12, 0xde);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(100, 30);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox2.Image = Resources.desmume_icon;
            this.pictureBox2.Location = new Point(0x12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(0x30, 0x30);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox1.Image = Resources.ideas_logo;
            this.pictureBox1.Location = new Point(0x12, 0x7a);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x65, 30);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.btnClose.BackgroundImageLayout = ImageLayout.Center;
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.DialogResult = DialogResult.Cancel;
            this.btnClose.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnClose.Image = Resources.crossicon;
            this.btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnClose.Location = new Point(0x148, 0x14d);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new Padding(3, 0, 3, 0);
            this.btnClose.Size = new Size(0x40, 30);
            this.btnClose.TabIndex = 0x80;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnApply.BackgroundImageLayout = ImageLayout.Center;
            this.btnApply.Cursor = Cursors.Hand;
            this.btnApply.Enabled = false;
            this.btnApply.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnApply.Image = Resources.Checkicon;
            this.btnApply.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnApply.Location = new Point(0x106, 0x14d);
            this.btnApply.Name = "btnApply";
            this.btnApply.Padding = new Padding(3, 0, 3, 0);
            this.btnApply.Size = new Size(0x40, 30);
            this.btnApply.TabIndex = 0x81;
            this.btnApply.Text = "Apply";
            this.btnApply.TextAlign = ContentAlignment.MiddleLeft;
            this.btnApply.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new EventHandler(this.btnApply_Click);
            this.radioDefault_0.AutoSize = true;
            this.radioDefault_0.Cursor = Cursors.Hand;
            this.radioDefault_0.Enabled = false;
            this.radioDefault_0.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioDefault_0.Location = new Point(0x12b, 0x5d);
            this.radioDefault_0.Name = "radioDefault_0";
            this.radioDefault_0.Size = new Size(90, 0x10);
            this.radioDefault_0.TabIndex = 0x52;
            this.radioDefault_0.TabStop = true;
            this.radioDefault_0.Text = "Set to default";
            this.radioDefault_0.UseVisualStyleBackColor = true;
            this.radioDefault_0.CheckedChanged += new EventHandler(this.radioDefault_0_CheckedChanged);
            this.radioDefault_2.AutoSize = true;
            this.radioDefault_2.Cursor = Cursors.Hand;
            this.radioDefault_2.Enabled = false;
            this.radioDefault_2.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioDefault_2.Location = new Point(0x12b, 0x132);
            this.radioDefault_2.Name = "radioDefault_2";
            this.radioDefault_2.Size = new Size(90, 0x10);
            this.radioDefault_2.TabIndex = 130;
            this.radioDefault_2.TabStop = true;
            this.radioDefault_2.Text = "Set to default";
            this.radioDefault_2.UseVisualStyleBackColor = true;
            this.radioDefault_2.CheckedChanged += new EventHandler(this.radioDefault_2_CheckedChanged);
            this.radioDefault_1.AutoSize = true;
            this.radioDefault_1.Cursor = Cursors.Hand;
            this.radioDefault_1.Enabled = false;
            this.radioDefault_1.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioDefault_1.Location = new Point(0x12b, 0xc1);
            this.radioDefault_1.Name = "radioDefault_1";
            this.radioDefault_1.Size = new Size(90, 0x10);
            this.radioDefault_1.TabIndex = 0x83;
            this.radioDefault_1.TabStop = true;
            this.radioDefault_1.Text = "Set to default";
            this.radioDefault_1.UseVisualStyleBackColor = true;
            this.radioDefault_1.CheckedChanged += new EventHandler(this.radioDefault_1_CheckedChanged);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(13, 0x27);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x60, 12);
            this.label1.TabIndex = 0x52;
            this.label1.Text = "Emulator Location";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(14, 0x27);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x60, 12);
            this.label2.TabIndex = 0x53;
            this.label2.Text = "Emulator Location";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(13, 0x1b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x60, 12);
            this.label3.TabIndex = 0x54;
            this.label3.Text = "Emulator Location";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(13, 0x35);
            this.label4.Name = "label4";
            this.label4.Size = new Size(100, 12);
            this.label4.TabIndex = 0x57;
            this.label4.Text = "eNDryptS Location";
            this.txtFileLocEndrypts.Location = new Point(0x70, 0x31);
            this.txtFileLocEndrypts.Name = "txtFileLocEndrypts";
            this.txtFileLocEndrypts.ReadOnly = true;
            this.txtFileLocEndrypts.Size = new Size(0xe7, 20);
            this.txtFileLocEndrypts.TabIndex = 0x56;
            this.btnBrowseEndrypts.Cursor = Cursors.Hand;
            this.btnBrowseEndrypts.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseEndrypts.Location = new Point(0x15a, 0x31);
            this.btnBrowseEndrypts.Name = "btnBrowseEndrypts";
            this.btnBrowseEndrypts.Size = new Size(0x1f, 20);
            this.btnBrowseEndrypts.TabIndex = 0x55;
            this.btnBrowseEndrypts.Text = "...";
            this.btnBrowseEndrypts.UseVisualStyleBackColor = true;
            this.btnBrowseEndrypts.Click += new EventHandler(this.btnBrowseEndrypts_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x18c, 0x173);
            base.Controls.Add(this.radioDefault_1);
            base.Controls.Add(this.btnApply);
            base.Controls.Add(this.radioDefault_2);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.radioDefault_0);
            base.Controls.Add(this.pictureBox3);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.pictureBox2);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximumSize = new Size(0x196, 0x1da);
            base.Name = "emulatorConfig";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Emulator Configuration";
            base.Load += new EventHandler(this.emulatorConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((ISupportInitialize) this.pictureBox3).EndInit();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void radioDefault_0_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtFileLocEmu0.Text != "")
            {
                this.btnApply.Enabled = true;
            }
        }

        private void radioDefault_1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtFileLocEmu1.Text != "")
            {
                this.btnApply.Enabled = true;
            }
        }

        private void radioDefault_2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtFileLocEmu2.Text != "")
            {
                this.btnApply.Enabled = true;
            }
        }
    }
}

