// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.changeLogForm
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (changeLogForm));
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
      this.txtApplicationName.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtApplicationName.Location = new Point(9, 9);
      this.txtApplicationName.Name = "txtApplicationName";
      this.txtApplicationName.Size = new Size(513, 23);
      this.txtApplicationName.TabIndex = 1;
      this.txtApplicationName.Text = "XXXXXXXXXX vX.X build xxxx";
      this.label2.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(285, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(179, 18);
      this.label2.TabIndex = 2;
      this.label2.Text = "Installed Image Pack ";
      this.txtDatabaseCount.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtDatabaseCount.Location = new Point(5, 16);
      this.txtDatabaseCount.Name = "txtDatabaseCount";
      this.txtDatabaseCount.Size = new Size(157, 18);
      this.txtDatabaseCount.TabIndex = 3;
      this.txtDatabaseCount.Text = "1 Database Installed ";
      this.txtInstalledDbs.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInstalledDbs.Location = new Point(5, 34);
      this.txtInstalledDbs.Name = "txtInstalledDbs";
      this.txtInstalledDbs.Size = new Size(189, 81);
      this.txtInstalledDbs.TabIndex = 4;
      this.txtInstalledDbs.Text = "Installed Database1";
      this.txtImagePack.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtImagePack.Location = new Point(285, 34);
      this.txtImagePack.Name = "txtImagePack";
      this.txtImagePack.Size = new Size(197, 18);
      this.txtImagePack.TabIndex = 5;
      this.txtImagePack.Text = "File Name.zip";
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.txtInstalledDbs);
      this.groupBox1.Controls.Add((Control) this.txtImagePack);
      this.groupBox1.Controls.Add((Control) this.txtDatabaseCount);
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
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.txtApplicationName);
      this.Controls.Add((Control) this.txtChangelog);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (changeLogForm);
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Text = "Change Log Viewer";
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void showDatabaseInfo()
    {
      this.curdbitems = 0;
      pspo2seForm.updateCSVInfo[] updateCsvInfoArray = new pspo2seForm.updateCSVInfo[20];
      try
      {
        string encryptionKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
        FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
        using (StreamReader streamReader = new StreamReader((Stream) this.parent.encryptor.createDecryptionReadStream(encryptionKey, fs)))
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
        int num = (int) MessageBox.Show(ex.Message);
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
        using (StreamReader streamReader = new StreamReader((Stream) this.parent.encryptor.createDecryptionReadStream(encryptionKey, fs)))
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

    public changeLogForm() => this.InitializeComponent();
  }
}
