using System;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class pspo2seEntryForm : Form
    {
        public string type = "";
        private Label txtNewText;
        private Label txtCurText;
        private Label txtEntryCurrent;
        private TextBox txtEntryNew;
        private Button btnCancel;
        private Button btnOK;
        private ComboBox comboEntryNew;

        public void New()
        {
            this.InitializeComponent();
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
                    for (int index = 0; index < 7; ++index)
                        this.comboEntryNew.Items.Add((object)((pspo2seForm.elementType)index).ToString());
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "type")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int index = 0; index < 4; ++index)
                        this.comboEntryNew.Items.Add((object)((pspo2seForm.jobType)index).ToString());
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "class")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int index = 0; index < 5; ++index)
                        this.comboEntryNew.Items.Add((object)((pspo2seForm.raceTypes)index).ToString());
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "sex")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int index = 0; index < 2; ++index)
                        this.comboEntryNew.Items.Add((object)((pspo2seForm.sexType)index).ToString());
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "special effect hex mod")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    this.comboEntryNew.Items.Add((object)"No Change");
                    this.comboEntryNew.Items.Add((object)"EXP | RARES | TYPE | HP");
                    this.comboEntryNew.SelectedIndex = 0;
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "ability")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int index = 0; index < 21; ++index)
                        this.comboEntryNew.Items.Add((object)(pspo2seForm.abilityType)index);
                    this.comboEntryNew.SelectedIndex = int.Parse(this.newVal);
                    this.comboEntryNew.Visible = true;
                }
                else if (value == "TEC ability")
                {
                    this.txtEntryNew.Visible = false;
                    this.comboEntryNew.Items.Clear();
                    for (int index = 0; index < 8; ++index)
                        this.comboEntryNew.Items.Add((object)(pspo2seForm.abilityType)(index + 21));
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
            this.btnOK_Click(sender, (EventArgs)null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
