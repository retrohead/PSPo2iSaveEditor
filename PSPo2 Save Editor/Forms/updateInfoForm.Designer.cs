using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class updateInfoForm : Form
    {
        private IContainer components;
        private Label txtApplicationNameNew;
        private RichTextBox txtChangelog;
        private Label txtApplicationName;
        private Label label3;
        private Button btnIgnore;
        private Button btnDownload;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(updateInfoForm));
            this.txtApplicationNameNew = new Label();
            this.txtChangelog = new RichTextBox();
            this.txtApplicationName = new Label();
            this.label3 = new Label();
            this.btnIgnore = new Button();
            this.btnDownload = new Button();
            this.SuspendLayout();
            this.txtApplicationNameNew.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.txtApplicationNameNew.Location = new Point(10, 87);
            this.txtApplicationNameNew.Name = "txtApplicationNameNew";
            this.txtApplicationNameNew.Size = new Size(513, 23);
            this.txtApplicationNameNew.TabIndex = 3;
            this.txtApplicationNameNew.Text = "XXXXXXXXXX vX.X build xxxx";
            this.txtChangelog.Location = new Point(14, 110);
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            this.txtChangelog.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.txtChangelog.Size = new Size(510, 233);
            this.txtChangelog.TabIndex = 2;
            this.txtChangelog.Text = "";
            this.txtApplicationName.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.txtApplicationName.Location = new Point(11, 23);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new Size(513, 23);
            this.txtApplicationName.TabIndex = 4;
            this.txtApplicationName.Text = "XXXXXXXXXX vX.X build xxxx";
            this.label3.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.label3.Location = new Point(10, 72);
            this.label3.Name = "label3";
            this.label3.Size = new Size(513, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Update Available";
            this.btnIgnore.Cursor = Cursors.Hand;
            this.btnIgnore.DialogResult = DialogResult.No;
            this.btnIgnore.Location = new Point(337, 349);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new Size(75, 23);
            this.btnIgnore.TabIndex = 7;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new EventHandler(this.btnIgnore_Click);
            this.btnDownload.Cursor = Cursors.Hand;
            this.btnDownload.DialogResult = DialogResult.Yes;
            this.btnDownload.Location = new Point(418, 349);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new Size(105, 23);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "Download Update";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new EventHandler(this.btnDownload_Click);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(535, 378);
            this.Controls.Add((Control)this.btnDownload);
            this.Controls.Add((Control)this.btnIgnore);
            this.Controls.Add((Control)this.label3);
            this.Controls.Add((Control)this.txtApplicationName);
            this.Controls.Add((Control)this.txtApplicationNameNew);
            this.Controls.Add((Control)this.txtChangelog);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Name = "updateInfoForm";
            this.Text = "PSPo2se Update Information";
            this.ResumeLayout(false);
        }
    }
}
