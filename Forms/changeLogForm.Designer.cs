using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class changeLogForm : Form
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changeLogForm));
            this.txtChangelog = new RichTextBox();
            this.txtApplicationName = new Label();
            this.label2 = new Label();
            this.txtDatabaseCount = new Label();
            this.txtInstalledDbs = new Label();
            this.txtImagePack = new Label();
            this.groupBox1 = new GroupBox();
            this.button1 = new Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            this.txtChangelog.Location = new Point(12, 35);
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            this.txtChangelog.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.txtChangelog.Size = new Size(510, 233);
            this.txtChangelog.TabIndex = 0;
            this.txtChangelog.Text = "";
            this.txtApplicationName.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.txtApplicationName.Location = new Point(9, 9);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new Size(513, 23);
            this.txtApplicationName.TabIndex = 1;
            this.txtApplicationName.Text = "XXXXXXXXXX vX.X build xxxx";
            this.label2.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.label2.Location = new Point(285, 16);
            this.label2.Name = "label2";
            this.label2.Size = new Size(179, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Installed Image Pack ";
            this.txtDatabaseCount.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.txtDatabaseCount.Location = new Point(5, 16);
            this.txtDatabaseCount.Name = "txtDatabaseCount";
            this.txtDatabaseCount.Size = new Size(157, 18);
            this.txtDatabaseCount.TabIndex = 3;
            this.txtDatabaseCount.Text = "1 Database Installed ";
            this.txtInstalledDbs.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.txtInstalledDbs.Location = new Point(5, 34);
            this.txtInstalledDbs.Name = "txtInstalledDbs";
            this.txtInstalledDbs.Size = new Size(189, 81);
            this.txtInstalledDbs.TabIndex = 4;
            this.txtInstalledDbs.Text = "Installed Database1";
            this.txtImagePack.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.txtImagePack.Location = new Point(285, 34);
            this.txtImagePack.Name = "txtImagePack";
            this.txtImagePack.Size = new Size(197, 18);
            this.txtImagePack.TabIndex = 5;
            this.txtImagePack.Text = "File Name.zip";
            this.groupBox1.Controls.Add((Control)this.label2);
            this.groupBox1.Controls.Add((Control)this.txtInstalledDbs);
            this.groupBox1.Controls.Add((Control)this.txtImagePack);
            this.groupBox1.Controls.Add((Control)this.txtDatabaseCount);
            this.groupBox1.Location = new Point(12, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(510, 121);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.button1.Cursor = Cursors.Hand;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Location = new Point(447, 401);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "close";
            this.button1.UseVisualStyleBackColor = true;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(535, 426);
            this.Controls.Add((Control)this.button1);
            this.Controls.Add((Control)this.groupBox1);
            this.Controls.Add((Control)this.txtApplicationName);
            this.Controls.Add((Control)this.txtChangelog);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "changeLogForm";
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "Change Log Viewer";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
