// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.updateInfoForm
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (updateInfoForm));
      this.txtApplicationNameNew = new Label();
      this.txtChangelog = new RichTextBox();
      this.txtApplicationName = new Label();
      this.label3 = new Label();
      this.btnIgnore = new Button();
      this.btnDownload = new Button();
      this.SuspendLayout();
      this.txtApplicationNameNew.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
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
      this.txtApplicationName.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtApplicationName.Location = new Point(11, 23);
      this.txtApplicationName.Name = "txtApplicationName";
      this.txtApplicationName.Size = new Size(513, 23);
      this.txtApplicationName.TabIndex = 4;
      this.txtApplicationName.Text = "XXXXXXXXXX vX.X build xxxx";
      this.label3.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
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
      this.Controls.Add((Control) this.btnDownload);
      this.Controls.Add((Control) this.btnIgnore);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.txtApplicationName);
      this.Controls.Add((Control) this.txtApplicationNameNew);
      this.Controls.Add((Control) this.txtChangelog);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (updateInfoForm);
      this.Text = "PSPo2se Update Information";
      this.ResumeLayout(false);
    }

    private void showChangeLogInfo()
    {
      string str1 = "";
      try
      {
        string str2 = "changelog.bin";
        if (Program.form.legitVersion())
          str2 = "changelog_viewer.bin";
        FileStream fs = new FileStream("data//temp/" + str2, FileMode.Open, FileAccess.Read);
        using (StreamReader streamReader = new StreamReader((Stream) this.parent.encryptor.createDecryptionReadStream(this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), fs)))
        {
          string str3;
          while ((str3 = streamReader.ReadLine()) != null)
            str1 = str1 + str3 + "\r\n";
          streamReader.Close();
        }
        fs.Close();
      }
      catch (Exception ex)
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
        int num = (int) MessageBox.Show("Failed to download the latest changelog, please check your internet connection\r\nor the site may be down!", "Change Log Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
