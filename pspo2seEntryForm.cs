// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.pspo2seEntryForm
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
  public class pspo2seEntryForm : Form
  {
    public string type = "";
    private IContainer components;
    private Label txtNewText;
    private Label txtCurText;
    private Label txtEntryCurrent;
    private TextBox txtEntryNew;
    private Button btnCancel;
    private Button btnOK;
    private ComboBox comboEntryNew;

    public string description
    {
      set
      {
        this.txtCurText.Text = "Current " + value;
        this.txtNewText.Text = "Please enter your new " + value;
        this.type = value;
        if (value == "element")
        {
          this.txtEntryNew.Visible = false;
          this.comboEntryNew.Items.Clear();
          for (int index = 0; index < 7; ++index)
            this.comboEntryNew.Items.Add((object) ((pspo2seForm.elementType) index).ToString());
          this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
          this.comboEntryNew.Visible = true;
        }
        else if (value == "type")
        {
          this.txtEntryNew.Visible = false;
          this.comboEntryNew.Items.Clear();
          for (int index = 0; index < 4; ++index)
            this.comboEntryNew.Items.Add((object) ((pspo2seForm.jobType) index).ToString());
          this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
          this.comboEntryNew.Visible = true;
        }
        else if (value == "class")
        {
          this.txtEntryNew.Visible = false;
          this.comboEntryNew.Items.Clear();
          for (int index = 0; index < 5; ++index)
            this.comboEntryNew.Items.Add((object) ((pspo2seForm.raceTypes) index).ToString());
          this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
          this.comboEntryNew.Visible = true;
        }
        else if (value == "sex")
        {
          this.txtEntryNew.Visible = false;
          this.comboEntryNew.Items.Clear();
          for (int index = 0; index < 2; ++index)
            this.comboEntryNew.Items.Add((object) ((pspo2seForm.sexType) index).ToString());
          this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
          this.comboEntryNew.Visible = true;
        }
        else if (value == "special effect hex mod")
        {
          this.txtEntryNew.Visible = false;
          this.comboEntryNew.Items.Clear();
          this.comboEntryNew.Items.Add((object) "No Change");
          this.comboEntryNew.Items.Add((object) "EXP | RARES | TYPE | HP");
          this.comboEntryNew.SelectedIndex = 0;
          this.comboEntryNew.Visible = true;
        }
        else if (value == "ability")
        {
          this.txtEntryNew.Visible = false;
          this.comboEntryNew.Items.Clear();
          for (int index = 0; index < 21; ++index)
            this.comboEntryNew.Items.Add((object) (pspo2seForm.abilityType) index);
          this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
          this.comboEntryNew.Visible = true;
        }
        else if (value == "TEC ability")
        {
          this.txtEntryNew.Visible = false;
          this.comboEntryNew.Items.Clear();
          for (int index = 0; index < 8; ++index)
            this.comboEntryNew.Items.Add((object) (pspo2seForm.abilityType) (index + 21));
          this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
          this.comboEntryNew.Visible = true;
        }
        else
        {
          this.txtEntryNew.Visible = true;
          this.comboEntryNew.Visible = false;
        }
      }
    }

    public string oldVal
    {
      get => this.txtEntryCurrent.Text;
      set => this.txtEntryCurrent.Text = value;
    }

    public string newVal
    {
      get => this.txtEntryNew.Text;
      set => this.txtEntryNew.Text = value;
    }

    public int maxLen
    {
      get => this.txtEntryNew.MaxLength;
      set => this.txtEntryNew.MaxLength = value;
    }

    public pspo2seEntryForm() => this.InitializeComponent();

    private void comboEntryNew_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboEntryNew.SelectedIndex == -1)
        return;
      if (this.type == "special effect hex mod")
      {
        switch (this.comboEntryNew.SelectedIndex)
        {
          case 0:
            this.txtEntryNew.Text = this.txtEntryCurrent.Text;
            break;
          case 1:
            this.txtEntryNew.Text = "60C4850F030805000000";
            break;
        }
      }
      else
        this.txtEntryNew.Text = this.comboEntryNew.SelectedIndex.ToString();
    }

    private void pspo2seEntryForm_Shown(object sender, EventArgs e)
    {
      if (this.txtEntryNew.Visible)
      {
        this.txtEntryNew.Focus();
        this.txtEntryNew.SelectAll();
      }
      else
        this.comboEntryNew.Focus();
    }

    private void entryNew_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnOK_Click(sender, (EventArgs) null);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Hide();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (pspo2seEntryForm));
      this.txtNewText = new Label();
      this.txtCurText = new Label();
      this.txtEntryCurrent = new Label();
      this.txtEntryNew = new TextBox();
      this.btnCancel = new Button();
      this.btnOK = new Button();
      this.comboEntryNew = new ComboBox();
      this.SuspendLayout();
      this.txtNewText.AutoSize = true;
      this.txtNewText.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtNewText.Location = new Point(11, 48);
      this.txtNewText.Name = "txtNewText";
      this.txtNewText.Size = new Size(195, 13);
      this.txtNewText.TabIndex = 0;
      this.txtNewText.Text = "Please enter your new text below";
      this.txtCurText.AutoSize = true;
      this.txtCurText.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtCurText.Location = new Point(12, 9);
      this.txtCurText.Name = "txtCurText";
      this.txtCurText.Size = new Size(81, 13);
      this.txtCurText.TabIndex = 1;
      this.txtCurText.Text = "Current Text:";
      this.txtEntryCurrent.AutoSize = true;
      this.txtEntryCurrent.Location = new Point(12, 25);
      this.txtEntryCurrent.Name = "txtEntryCurrent";
      this.txtEntryCurrent.Size = new Size(35, 13);
      this.txtEntryCurrent.TabIndex = 2;
      this.txtEntryCurrent.Text = "label3";
      this.txtEntryNew.Location = new Point(13, 65);
      this.txtEntryNew.Name = "txtEntryNew";
      this.txtEntryNew.Size = new Size(201, 20);
      this.txtEntryNew.TabIndex = 3;
      this.txtEntryNew.KeyDown += new KeyEventHandler(this.entryNew_KeyDown);
      this.btnCancel.Cursor = Cursors.Hand;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(348, 80);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnOK.Cursor = Cursors.Hand;
      this.btnOK.DialogResult = DialogResult.OK;
      this.btnOK.Location = new Point(267, 80);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.comboEntryNew.Cursor = Cursors.Hand;
      this.comboEntryNew.FormattingEnabled = true;
      this.comboEntryNew.Location = new Point(13, 65);
      this.comboEntryNew.Name = "comboEntryNew";
      this.comboEntryNew.Size = new Size(201, 21);
      this.comboEntryNew.TabIndex = 6;
      this.comboEntryNew.Visible = false;
      this.comboEntryNew.SelectedIndexChanged += new EventHandler(this.comboEntryNew_SelectedIndexChanged);
      this.comboEntryNew.KeyDown += new KeyEventHandler(this.entryNew_KeyDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(426, 108);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.txtEntryNew);
      this.Controls.Add((Control) this.txtEntryCurrent);
      this.Controls.Add((Control) this.txtCurText);
      this.Controls.Add((Control) this.txtNewText);
      this.Controls.Add((Control) this.comboEntryNew);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximumSize = new Size(442, 146);
      this.MinimumSize = new Size(442, 146);
      this.Name = nameof (pspo2seEntryForm);
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "PSPo2se Entry Form";
      this.Shown += new EventHandler(this.pspo2seEntryForm_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
