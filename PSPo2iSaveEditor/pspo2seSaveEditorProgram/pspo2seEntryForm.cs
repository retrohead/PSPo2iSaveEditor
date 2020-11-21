namespace PSPo2iSaveEditor
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

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

        public pspo2seEntryForm()
        {
            this.InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }

        private void comboEntryNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEntryNew.SelectedIndex != -1)
            {
                if (this.type == "special effect hex mod")
                {
                    switch (this.comboEntryNew.SelectedIndex)
                    {
                        case 0:
                            this.txtEntryNew.Text = this.txtEntryCurrent.Text;
                            return;

                        case 1:
                            this.txtEntryNew.Text = "60C4850F030805000000";
                            return;
                    }
                }
                else
                {
                    this.txtEntryNew.Text = this.comboEntryNew.SelectedIndex.ToString();
                }
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

        private void entryNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK_Click(sender, null);
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(pspo2seEntryForm));
            this.txtNewText = new Label();
            this.txtCurText = new Label();
            this.txtEntryCurrent = new Label();
            this.txtEntryNew = new TextBox();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.comboEntryNew = new ComboBox();
            base.SuspendLayout();
            this.txtNewText.AutoSize = true;
            this.txtNewText.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtNewText.Location = new Point(11, 0x30);
            this.txtNewText.Name = "txtNewText";
            this.txtNewText.Size = new Size(0xc3, 13);
            this.txtNewText.TabIndex = 0;
            this.txtNewText.Text = "Please enter your new text below";
            this.txtCurText.AutoSize = true;
            this.txtCurText.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtCurText.Location = new Point(12, 9);
            this.txtCurText.Name = "txtCurText";
            this.txtCurText.Size = new Size(0x51, 13);
            this.txtCurText.TabIndex = 1;
            this.txtCurText.Text = "Current Text:";
            this.txtEntryCurrent.AutoSize = true;
            this.txtEntryCurrent.Location = new Point(12, 0x19);
            this.txtEntryCurrent.Name = "txtEntryCurrent";
            this.txtEntryCurrent.Size = new Size(0x23, 13);
            this.txtEntryCurrent.TabIndex = 2;
            this.txtEntryCurrent.Text = "label3";
            this.txtEntryNew.Location = new Point(13, 0x41);
            this.txtEntryNew.Name = "txtEntryNew";
            this.txtEntryNew.Size = new Size(0xc9, 20);
            this.txtEntryNew.TabIndex = 3;
            this.txtEntryNew.KeyDown += new KeyEventHandler(this.entryNew_KeyDown);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x15c, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOK.Cursor = Cursors.Hand;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(0x10b, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.comboEntryNew.Cursor = Cursors.Hand;
            this.comboEntryNew.FormattingEnabled = true;
            this.comboEntryNew.Location = new Point(13, 0x41);
            this.comboEntryNew.Name = "comboEntryNew";
            this.comboEntryNew.Size = new Size(0xc9, 0x15);
            this.comboEntryNew.TabIndex = 6;
            this.comboEntryNew.Visible = false;
            this.comboEntryNew.SelectedIndexChanged += new EventHandler(this.comboEntryNew_SelectedIndexChanged);
            this.comboEntryNew.KeyDown += new KeyEventHandler(this.entryNew_KeyDown);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1aa, 0x6c);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.txtEntryNew);
            base.Controls.Add(this.txtEntryCurrent);
            base.Controls.Add(this.txtCurText);
            base.Controls.Add(this.txtNewText);
            base.Controls.Add(this.comboEntryNew);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximumSize = new Size(0x1ba, 0x92);
            this.MinimumSize = new Size(0x1ba, 0x92);
            base.Name = "pspo2seEntryForm";
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "PSPo2se Entry Form";
            base.Shown += new EventHandler(this.pspo2seEntryForm_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void pspo2seEntryForm_Shown(object sender, EventArgs e)
        {
            if (!this.txtEntryNew.Visible)
            {
                this.comboEntryNew.Focus();
            }
            else
            {
                this.txtEntryNew.Focus();
                this.txtEntryNew.SelectAll();
            }
        }

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
                    for (int i = 0; i < 7; i++)
                    {
                        this.comboEntryNew.Items.Add(((pspo2seForm.elementType) i).ToString());
                    }
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "type")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int i = 0; i < 4; i++)
                    {
                        this.comboEntryNew.Items.Add(((pspo2seForm.jobType) i).ToString());
                    }
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "class")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int i = 0; i < 5; i++)
                    {
                        this.comboEntryNew.Items.Add(((pspo2seForm.raceTypes) i).ToString());
                    }
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "sex")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int i = 0; i < 2; i++)
                    {
                        this.comboEntryNew.Items.Add(((pspo2seForm.sexType) i).ToString());
                    }
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "special effect hex mod")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    this.comboEntryNew.Items.Add("No Change");
                    this.comboEntryNew.Items.Add("EXP | RARES | TYPE | HP");
                    this.comboEntryNew.SelectedIndex = 0;
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "ability")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int i = 0; i < 0x15; i++)
                    {
                        this.comboEntryNew.Items.Add((pspo2seForm.abilityType) i);
                    }
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value != "TEC ability")
                {
                    this.txtEntryNew.Visible = true;
                    this.comboEntryNew.Visible = false;
                }
                else
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int i = 0; i < 8; i++)
                    {
                        this.comboEntryNew.Items.Add((pspo2seForm.abilityType) (i + 0x15));
                    }
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
            }
        }

        public string oldVal
        {
            get => 
                this.txtEntryCurrent.Text;
            set => 
                this.txtEntryCurrent.Text = value;
        }

        public string newVal
        {
            get => 
                this.txtEntryNew.Text;
            set => 
                this.txtEntryNew.Text = value;
        }

        public int maxLen
        {
            get => 
                this.txtEntryNew.MaxLength;
            set => 
                this.txtEntryNew.MaxLength = value;
        }
    }
}

