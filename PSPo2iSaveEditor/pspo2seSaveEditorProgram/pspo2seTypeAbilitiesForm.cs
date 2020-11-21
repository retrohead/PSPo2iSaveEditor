namespace PSPo2iSaveEditor
{
    using PSPo2iSaveEditor.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class pspo2seTypeAbilitiesForm : Form
    {
        private IContainer components;
        private ListView listViewAbilities;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader5;
        private Label txtAbilityName;
        private Label txtAbilityName_jp;
        private Label txtAbilityDesc;
        private Button btnSave;
        private Button btnCancel;
        private GroupBox groupBox1;
        private Label txtTypeName;
        private Label txtTypeLevel;
        private Label txtCharName;
        private PictureBox imgSlot1;
        private PictureBox imgSlot2;
        private PictureBox imgSlot4;
        private PictureBox imgSlot3;
        private PictureBox imgSlot8;
        private PictureBox imgSlot7;
        private PictureBox imgSlot6;
        private PictureBox imgSlot5;
        private PictureBox imgSlot12;
        private PictureBox imgSlot11;
        private PictureBox imgSlot10;
        private PictureBox imgSlot9;
        private Label txtUsedSlots;
        private RadioButton radioBtnFake;
        private RadioButton radioBtnReal;
        private PictureBox imgAbilityCost;
        private ImageList abilitiesImageList;
        private NotifyIcon notifyIcon1;
        private Label btnRemove;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private PictureBox pictureBox11;
        private PictureBox pictureBox12;
        private Label btnChange;
        private PictureBox pictureBox13;
        private PictureBox pictureBox14;
        private PictureBox pictureBox15;
        private PictureBox pictureBox16;
        private PictureBox pictureBox17;
        private PictureBox pictureBox18;
        private CheckBox chkListAll;
        private int usedSlots;
        private int allowedSlots;
        private viewType view;
        private bool allowEdit;
        private bool legitMode = true;
        private pspo2seForm.jobClass[] oldJobInfo = new pspo2seForm.jobClass[4];
        private pspo2seForm.jobClass newJobInfo = new pspo2seForm.jobClass();
        private pspo2seForm.jobType selected_job = pspo2seForm.jobType.None;
        private int parent_max_abilities;
        private string char_name = "";
        private pspo2seAbilityDb parentsAbilityDb;
        private abilitySlotsType[] listOfAbilities = new abilitySlotsType[0x101];
        private int listOfAbilitiesSlotCount;
        private pspo2seForm.SaveType save_type;

        public pspo2seTypeAbilitiesForm()
        {
            this.InitializeComponent();
            this.radioBtnReal.Checked = true;
            this.radioBtnFake.Checked = false;
        }

        private void addAbility(string hex)
        {
            int length = this.findAbilityPos("00");
            string str = this.newJob.attachedAbilities.Substring(0, length);
            string str2 = this.newJob.attachedAbilities.Substring(length + 2, (this.newJob.attachedAbilities.Length - str.Length) - 2);
            this.newJob.attachedAbilities = str + hex + str2;
        }

        private void allowedAbilitySlotsLogic()
        {
            this.allowedSlots = 4;
            int level = this.newJob.level;
            if (!this.legitMode)
            {
                level = (this.saveType != pspo2seForm.SaveType.PSP2I) ? 30 : 0x1f;
            }
            for (int i = 1; i <= level; i++)
            {
                int num3 = i;
                if (num3 <= 10)
                {
                    if (num3 == 5)
                    {
                        this.imgSlot5.Visible = true;
                        this.allowedSlots++;
                    }
                    else if (num3 == 10)
                    {
                        this.imgSlot6.Visible = true;
                        this.allowedSlots++;
                    }
                }
                else if (num3 == 15)
                {
                    this.imgSlot7.Visible = true;
                    this.allowedSlots++;
                }
                else if (num3 == 20)
                {
                    this.imgSlot8.Visible = true;
                    this.allowedSlots++;
                }
                else if (num3 == 0x1f)
                {
                    this.imgSlot9.Visible = true;
                    this.imgSlot10.Visible = true;
                    this.imgSlot11.Visible = true;
                    this.imgSlot12.Visible = true;
                    this.allowedSlots = 12;
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.view == viewType.equipped)
            {
                if (!this.allowEdit)
                {
                    MessageBox.Show("You must remove any unknown abilities first!\r\nPlease wait for a database update for better functionality", "Unknown ability detected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (this.usedSlots < this.allowedSlots)
                {
                    this.listAvailableTypeAbilities();
                }
                else if (Program.form.legitVersion())
                {
                    MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (this.radioBtnFake.Checked)
                {
                    MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one\r\nor you can click to fake the slots", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass class2 = this.abilityDb.findAbilityInDb(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
                if (this.legitMode)
                {
                    if ((this.usedSlots + class2.slots) <= this.allowedSlots)
                    {
                        flag = true;
                    }
                }
                else if (this.allowedSlots > this.usedSlots)
                {
                    flag = true;
                }
                if (!flag)
                {
                    MessageBox.Show("You do not have enough slots for that ability", "Mamimum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.addAbility(class2.hex);
                    this.listTypeAbilities();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.view != viewType.equipped)
            {
                this.listTypeAbilities();
            }
            else if (this.listViewAbilities.SelectedItems.Count > 0)
            {
                this.removeAbility(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
            }
            else
            {
                MessageBox.Show("Please select an ability to remove", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool canFindAbilityInAttached(string hex)
        {
            string str = "";
            for (int i = 0; i < this.max_abilities; i++)
            {
                str = this.newJob.attachedAbilities.Substring(i * 2, 2);
                if (str == hex)
                {
                    return true;
                }
            }
            return false;
        }

        private void chkListAll_CheckedChanged(object sender, EventArgs e)
        {
            this.listAvailableTypeAbilities();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private int findAbilityPos(string hex)
        {
            string str = "";
            for (int i = 0; i < this.max_abilities; i++)
            {
                str = this.newJob.attachedAbilities.Substring(i * 2, 2);
                if (str == hex)
                {
                    return (i * 2);
                }
            }
            MessageBox.Show("Fatal Error!\r\nThe selected ability " + hex + " was not found in the attached abilities\r\n" + this.newJob.attachedAbilities);
            return 0;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(pspo2seTypeAbilitiesForm));
            this.listViewAbilities = new ListView();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader11 = new ColumnHeader();
            this.columnHeader5 = new ColumnHeader();
            this.abilitiesImageList = new ImageList(this.components);
            this.txtAbilityName = new Label();
            this.txtAbilityName_jp = new Label();
            this.txtAbilityDesc = new Label();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.groupBox1 = new GroupBox();
            this.chkListAll = new CheckBox();
            this.radioBtnFake = new RadioButton();
            this.radioBtnReal = new RadioButton();
            this.txtTypeName = new Label();
            this.txtTypeLevel = new Label();
            this.txtCharName = new Label();
            this.imgSlot1 = new PictureBox();
            this.imgSlot2 = new PictureBox();
            this.imgSlot4 = new PictureBox();
            this.imgSlot3 = new PictureBox();
            this.imgSlot8 = new PictureBox();
            this.imgSlot7 = new PictureBox();
            this.imgSlot6 = new PictureBox();
            this.imgSlot5 = new PictureBox();
            this.imgSlot12 = new PictureBox();
            this.imgSlot11 = new PictureBox();
            this.imgSlot10 = new PictureBox();
            this.imgSlot9 = new PictureBox();
            this.txtUsedSlots = new Label();
            this.imgAbilityCost = new PictureBox();
            this.notifyIcon1 = new NotifyIcon(this.components);
            this.btnRemove = new Label();
            this.pictureBox7 = new PictureBox();
            this.pictureBox8 = new PictureBox();
            this.pictureBox9 = new PictureBox();
            this.pictureBox10 = new PictureBox();
            this.pictureBox11 = new PictureBox();
            this.pictureBox12 = new PictureBox();
            this.btnChange = new Label();
            this.pictureBox13 = new PictureBox();
            this.pictureBox14 = new PictureBox();
            this.pictureBox15 = new PictureBox();
            this.pictureBox16 = new PictureBox();
            this.pictureBox17 = new PictureBox();
            this.pictureBox18 = new PictureBox();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.imgSlot1).BeginInit();
            ((ISupportInitialize) this.imgSlot2).BeginInit();
            ((ISupportInitialize) this.imgSlot4).BeginInit();
            ((ISupportInitialize) this.imgSlot3).BeginInit();
            ((ISupportInitialize) this.imgSlot8).BeginInit();
            ((ISupportInitialize) this.imgSlot7).BeginInit();
            ((ISupportInitialize) this.imgSlot6).BeginInit();
            ((ISupportInitialize) this.imgSlot5).BeginInit();
            ((ISupportInitialize) this.imgSlot12).BeginInit();
            ((ISupportInitialize) this.imgSlot11).BeginInit();
            ((ISupportInitialize) this.imgSlot10).BeginInit();
            ((ISupportInitialize) this.imgSlot9).BeginInit();
            ((ISupportInitialize) this.imgAbilityCost).BeginInit();
            ((ISupportInitialize) this.pictureBox7).BeginInit();
            ((ISupportInitialize) this.pictureBox8).BeginInit();
            ((ISupportInitialize) this.pictureBox9).BeginInit();
            ((ISupportInitialize) this.pictureBox10).BeginInit();
            ((ISupportInitialize) this.pictureBox11).BeginInit();
            ((ISupportInitialize) this.pictureBox12).BeginInit();
            ((ISupportInitialize) this.pictureBox13).BeginInit();
            ((ISupportInitialize) this.pictureBox14).BeginInit();
            ((ISupportInitialize) this.pictureBox15).BeginInit();
            ((ISupportInitialize) this.pictureBox16).BeginInit();
            ((ISupportInitialize) this.pictureBox17).BeginInit();
            ((ISupportInitialize) this.pictureBox18).BeginInit();
            base.SuspendLayout();
            this.listViewAbilities.BackgroundImage = (Image) manager.GetObject("listViewAbilities.BackgroundImage");
            this.listViewAbilities.BackgroundImageTiled = true;
            this.listViewAbilities.BorderStyle = BorderStyle.None;
            ColumnHeader[] values = new ColumnHeader[] { this.columnHeader2, this.columnHeader11, this.columnHeader5 };
            this.listViewAbilities.Columns.AddRange(values);
            this.listViewAbilities.Cursor = Cursors.Hand;
            this.listViewAbilities.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.listViewAbilities.ForeColor = Color.White;
            this.listViewAbilities.FullRowSelect = true;
            this.listViewAbilities.HeaderStyle = ColumnHeaderStyle.None;
            this.listViewAbilities.HideSelection = false;
            this.listViewAbilities.LabelWrap = false;
            this.listViewAbilities.Location = new Point(10, 0x38);
            this.listViewAbilities.MultiSelect = false;
            this.listViewAbilities.Name = "listViewAbilities";
            this.listViewAbilities.Size = new Size(0xd7, 0x79);
            this.listViewAbilities.SmallImageList = this.abilitiesImageList;
            this.listViewAbilities.TabIndex = 0x7f;
            this.listViewAbilities.UseCompatibleStateImageBehavior = false;
            this.listViewAbilities.View = View.Details;
            this.listViewAbilities.SelectedIndexChanged += new EventHandler(this.listViewAbilities_SelectedIndexChanged);
            this.listViewAbilities.Click += new EventHandler(this.listViewAbilities_SelectedIndexChanged);
            this.columnHeader2.Width = 30;
            this.columnHeader11.Width = 0xa5;
            this.columnHeader5.Width = 0;
            this.abilitiesImageList.ImageStream = (ImageListStreamer) manager.GetObject("abilitiesImageList.ImageStream");
            this.abilitiesImageList.TransparentColor = Color.Transparent;
            this.abilitiesImageList.Images.SetKeyName(0, "TypeAbilitiesUsed.png");
            this.txtAbilityName.AutoSize = true;
            this.txtAbilityName.BackColor = Color.Transparent;
            this.txtAbilityName.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtAbilityName.ForeColor = Color.White;
            this.txtAbilityName.Location = new Point(8, 0xb9);
            this.txtAbilityName.Name = "txtAbilityName";
            this.txtAbilityName.Size = new Size(0x67, 0x10);
            this.txtAbilityName.TabIndex = 0x81;
            this.txtAbilityName.Text = "txtAbilityName";
            this.txtAbilityName_jp.AutoSize = true;
            this.txtAbilityName_jp.BackColor = Color.Transparent;
            this.txtAbilityName_jp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtAbilityName_jp.ForeColor = Color.Teal;
            this.txtAbilityName_jp.Location = new Point(9, 0xca);
            this.txtAbilityName_jp.Name = "txtAbilityName_jp";
            this.txtAbilityName_jp.Size = new Size(0x7e, 14);
            this.txtAbilityName_jp.TabIndex = 130;
            this.txtAbilityName_jp.Text = "txtAbilityName_jp";
            this.txtAbilityDesc.BackColor = Color.Transparent;
            this.txtAbilityDesc.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtAbilityDesc.ForeColor = Color.White;
            this.txtAbilityDesc.Location = new Point(8, 0xd9);
            this.txtAbilityDesc.MaximumSize = new Size(210, 0x2b);
            this.txtAbilityDesc.MinimumSize = new Size(210, 0x2b);
            this.txtAbilityDesc.Name = "txtAbilityDesc";
            this.txtAbilityDesc.Size = new Size(210, 0x2b);
            this.txtAbilityDesc.TabIndex = 0x83;
            this.txtAbilityDesc.Text = "txtAbilityDesc";
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.DialogResult = DialogResult.OK;
            this.btnSave.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnSave.Location = new Point(320, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x52, 0x17);
            this.btnSave.TabIndex = 0x84;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnCancel.Location = new Point(0x193, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x52, 0x17);
            this.btnCancel.TabIndex = 0x85;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.groupBox1.BackColor = SystemColors.Control;
            this.groupBox1.Controls.Add(this.chkListAll);
            this.groupBox1.Controls.Add(this.radioBtnFake);
            this.groupBox1.Controls.Add(this.radioBtnReal);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new Point(-8, 0x110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1f7, 40);
            this.groupBox1.TabIndex = 0x86;
            this.groupBox1.TabStop = false;
            this.chkListAll.AutoSize = true;
            this.chkListAll.Cursor = Cursors.Hand;
            this.chkListAll.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chkListAll.Location = new Point(0x88, 0x15);
            this.chkListAll.Name = "chkListAll";
            this.chkListAll.Size = new Size(0x69, 0x10);
            this.chkListAll.TabIndex = 0x88;
            this.chkListAll.Text = "List All Abilities";
            this.chkListAll.UseVisualStyleBackColor = true;
            this.chkListAll.Visible = false;
            this.chkListAll.CheckedChanged += new EventHandler(this.chkListAll_CheckedChanged);
            this.radioBtnFake.AutoSize = true;
            this.radioBtnFake.Cursor = Cursors.Hand;
            this.radioBtnFake.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioBtnFake.Location = new Point(0x10, 0x15);
            this.radioBtnFake.Name = "radioBtnFake";
            this.radioBtnFake.Size = new Size(0x69, 0x10);
            this.radioBtnFake.TabIndex = 0x87;
            this.radioBtnFake.Text = "Fake Slot Usage";
            this.radioBtnFake.UseVisualStyleBackColor = true;
            this.radioBtnFake.CheckedChanged += new EventHandler(this.radioBtnFake_CheckedChanged);
            this.radioBtnReal.AutoSize = true;
            this.radioBtnReal.Checked = true;
            this.radioBtnReal.Cursor = Cursors.Hand;
            this.radioBtnReal.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioBtnReal.Location = new Point(0x10, 7);
            this.radioBtnReal.Name = "radioBtnReal";
            this.radioBtnReal.Size = new Size(0x67, 0x10);
            this.radioBtnReal.TabIndex = 0x86;
            this.radioBtnReal.TabStop = true;
            this.radioBtnReal.Text = "Real Slot Usage";
            this.radioBtnReal.UseVisualStyleBackColor = true;
            this.radioBtnReal.CheckedChanged += new EventHandler(this.radioBtnReal_CheckedChanged);
            this.txtTypeName.BackColor = Color.Transparent;
            this.txtTypeName.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtTypeName.ForeColor = Color.White;
            this.txtTypeName.Location = new Point(12, 0x21);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new Size(0x53, 14);
            this.txtTypeName.TabIndex = 0x87;
            this.txtTypeName.Text = "txtTypeName";
            this.txtTypeLevel.BackColor = Color.Transparent;
            this.txtTypeLevel.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtTypeLevel.ForeColor = Color.White;
            this.txtTypeLevel.Location = new Point(0x65, 0x21);
            this.txtTypeLevel.Name = "txtTypeLevel";
            this.txtTypeLevel.Size = new Size(0x2f, 14);
            this.txtTypeLevel.TabIndex = 0x88;
            this.txtTypeLevel.Text = "txtTypeLevel";
            this.txtTypeLevel.TextAlign = ContentAlignment.TopRight;
            this.txtCharName.BackColor = Color.Transparent;
            this.txtCharName.Font = new Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtCharName.ForeColor = Color.White;
            this.txtCharName.Location = new Point(12, 11);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.Size = new Size(0xa7, 20);
            this.txtCharName.TabIndex = 0x89;
            this.txtCharName.Text = "txtCharName";
            this.imgSlot1.BackColor = Color.Transparent;
            this.imgSlot1.Image = Resources.TypeAbilitiesFree;
            this.imgSlot1.Location = new Point(0xa9, 0x23);
            this.imgSlot1.Name = "imgSlot1";
            this.imgSlot1.Size = new Size(10, 10);
            this.imgSlot1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot1.TabIndex = 0x8a;
            this.imgSlot1.TabStop = false;
            this.imgSlot2.BackColor = Color.Transparent;
            this.imgSlot2.Image = Resources.TypeAbilitiesFree;
            this.imgSlot2.Location = new Point(180, 0x23);
            this.imgSlot2.Name = "imgSlot2";
            this.imgSlot2.Size = new Size(10, 10);
            this.imgSlot2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot2.TabIndex = 0x8b;
            this.imgSlot2.TabStop = false;
            this.imgSlot4.BackColor = Color.Transparent;
            this.imgSlot4.Image = Resources.TypeAbilitiesFree;
            this.imgSlot4.Location = new Point(0xca, 0x23);
            this.imgSlot4.Name = "imgSlot4";
            this.imgSlot4.Size = new Size(10, 10);
            this.imgSlot4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot4.TabIndex = 0x8d;
            this.imgSlot4.TabStop = false;
            this.imgSlot3.BackColor = Color.Transparent;
            this.imgSlot3.Image = Resources.TypeAbilitiesFree;
            this.imgSlot3.Location = new Point(0xbf, 0x23);
            this.imgSlot3.Name = "imgSlot3";
            this.imgSlot3.Size = new Size(10, 10);
            this.imgSlot3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot3.TabIndex = 140;
            this.imgSlot3.TabStop = false;
            this.imgSlot8.BackColor = Color.Transparent;
            this.imgSlot8.Image = Resources.TypeAbilitiesFree;
            this.imgSlot8.Location = new Point(0xf6, 0x23);
            this.imgSlot8.Name = "imgSlot8";
            this.imgSlot8.Size = new Size(10, 10);
            this.imgSlot8.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot8.TabIndex = 0x91;
            this.imgSlot8.TabStop = false;
            this.imgSlot7.BackColor = Color.Transparent;
            this.imgSlot7.Image = Resources.TypeAbilitiesFree;
            this.imgSlot7.Location = new Point(0xeb, 0x23);
            this.imgSlot7.Name = "imgSlot7";
            this.imgSlot7.Size = new Size(10, 10);
            this.imgSlot7.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot7.TabIndex = 0x90;
            this.imgSlot7.TabStop = false;
            this.imgSlot6.BackColor = Color.Transparent;
            this.imgSlot6.Image = Resources.TypeAbilitiesFree;
            this.imgSlot6.Location = new Point(0xe0, 0x23);
            this.imgSlot6.Name = "imgSlot6";
            this.imgSlot6.Size = new Size(10, 10);
            this.imgSlot6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot6.TabIndex = 0x8f;
            this.imgSlot6.TabStop = false;
            this.imgSlot5.BackColor = Color.Transparent;
            this.imgSlot5.Image = Resources.TypeAbilitiesFree;
            this.imgSlot5.Location = new Point(0xd5, 0x23);
            this.imgSlot5.Name = "imgSlot5";
            this.imgSlot5.Size = new Size(10, 10);
            this.imgSlot5.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot5.TabIndex = 0x8e;
            this.imgSlot5.TabStop = false;
            this.imgSlot12.BackColor = Color.Transparent;
            this.imgSlot12.Image = Resources.TypeAbilitiesFree;
            this.imgSlot12.Location = new Point(290, 0x23);
            this.imgSlot12.Name = "imgSlot12";
            this.imgSlot12.Size = new Size(10, 10);
            this.imgSlot12.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot12.TabIndex = 0x95;
            this.imgSlot12.TabStop = false;
            this.imgSlot11.BackColor = Color.Transparent;
            this.imgSlot11.Image = Resources.TypeAbilitiesFree;
            this.imgSlot11.Location = new Point(0x117, 0x23);
            this.imgSlot11.Name = "imgSlot11";
            this.imgSlot11.Size = new Size(10, 10);
            this.imgSlot11.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot11.TabIndex = 0x94;
            this.imgSlot11.TabStop = false;
            this.imgSlot10.BackColor = Color.Transparent;
            this.imgSlot10.Image = Resources.TypeAbilitiesFree;
            this.imgSlot10.Location = new Point(0x10c, 0x23);
            this.imgSlot10.Name = "imgSlot10";
            this.imgSlot10.Size = new Size(10, 10);
            this.imgSlot10.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot10.TabIndex = 0x93;
            this.imgSlot10.TabStop = false;
            this.imgSlot9.BackColor = Color.Transparent;
            this.imgSlot9.Image = Resources.TypeAbilitiesFree;
            this.imgSlot9.Location = new Point(0x101, 0x23);
            this.imgSlot9.Name = "imgSlot9";
            this.imgSlot9.Size = new Size(10, 10);
            this.imgSlot9.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgSlot9.TabIndex = 0x92;
            this.imgSlot9.TabStop = false;
            this.txtUsedSlots.AutoSize = true;
            this.txtUsedSlots.BackColor = Color.Transparent;
            this.txtUsedSlots.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtUsedSlots.ForeColor = Color.White;
            this.txtUsedSlots.Location = new Point(0x131, 0x21);
            this.txtUsedSlots.Name = "txtUsedSlots";
            this.txtUsedSlots.Size = new Size(40, 13);
            this.txtUsedSlots.TabIndex = 150;
            this.txtUsedSlots.Text = "12/12";
            this.txtUsedSlots.TextAlign = ContentAlignment.TopRight;
            this.imgAbilityCost.BackColor = Color.Transparent;
            this.imgAbilityCost.Image = Resources.TypeAbilities_cost_4;
            this.imgAbilityCost.Location = new Point(0xb6, 0xcd);
            this.imgAbilityCost.Name = "imgAbilityCost";
            this.imgAbilityCost.Size = new Size(0x2b, 10);
            this.imgAbilityCost.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgAbilityCost.TabIndex = 0x97;
            this.imgAbilityCost.TabStop = false;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.btnRemove.BackColor = Color.FromArgb(8, 0x30, 0x40);
            this.btnRemove.Cursor = Cursors.Hand;
            this.btnRemove.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnRemove.ForeColor = Color.White;
            this.btnRemove.Location = new Point(0xef, 0xa2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new Size(0x2a, 12);
            this.btnRemove.TabIndex = 0xa5;
            this.btnRemove.Text = "remove";
            this.btnRemove.TextAlign = ContentAlignment.TopCenter;
            this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
            this.pictureBox7.BackColor = Color.Transparent;
            this.pictureBox7.BackgroundImage = Resources.group_box_btm;
            this.pictureBox7.Location = new Point(0xf2, 0xa9);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new Size(40, 10);
            this.pictureBox7.TabIndex = 0xa4;
            this.pictureBox7.TabStop = false;
            this.pictureBox8.BackColor = Color.Transparent;
            this.pictureBox8.BackgroundImage = Resources.group_box_top;
            this.pictureBox8.Location = new Point(0xf2, 160);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new Size(40, 10);
            this.pictureBox8.TabIndex = 0xa3;
            this.pictureBox8.TabStop = false;
            this.pictureBox9.BackColor = Color.Transparent;
            this.pictureBox9.Image = Resources.group_box_btm_right;
            this.pictureBox9.Location = new Point(0x116, 0xa9);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new Size(10, 10);
            this.pictureBox9.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 0xa2;
            this.pictureBox9.TabStop = false;
            this.pictureBox10.BackColor = Color.Transparent;
            this.pictureBox10.Image = Resources.group_box_top_right;
            this.pictureBox10.Location = new Point(0x116, 160);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new Size(10, 10);
            this.pictureBox10.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 0xa1;
            this.pictureBox10.TabStop = false;
            this.pictureBox11.BackColor = Color.Transparent;
            this.pictureBox11.Image = Resources.group_box_btm_left;
            this.pictureBox11.Location = new Point(0xe9, 0xa9);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new Size(10, 10);
            this.pictureBox11.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox11.TabIndex = 160;
            this.pictureBox11.TabStop = false;
            this.pictureBox12.BackColor = Color.Transparent;
            this.pictureBox12.Image = Resources.group_box_top_left;
            this.pictureBox12.Location = new Point(0xe9, 160);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new Size(10, 10);
            this.pictureBox12.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox12.TabIndex = 0x9f;
            this.pictureBox12.TabStop = false;
            this.btnChange.BackColor = Color.FromArgb(8, 0x30, 0x40);
            this.btnChange.Cursor = Cursors.Hand;
            this.btnChange.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnChange.ForeColor = Color.White;
            this.btnChange.Location = new Point(0xef, 0x8e);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new Size(0x2a, 12);
            this.btnChange.TabIndex = 0xac;
            this.btnChange.Text = "add";
            this.btnChange.TextAlign = ContentAlignment.TopCenter;
            this.btnChange.Click += new EventHandler(this.btnChange_Click);
            this.pictureBox13.BackColor = Color.Transparent;
            this.pictureBox13.BackgroundImage = Resources.group_box_btm;
            this.pictureBox13.Location = new Point(0xf2, 0x95);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new Size(40, 10);
            this.pictureBox13.TabIndex = 0xab;
            this.pictureBox13.TabStop = false;
            this.pictureBox14.BackColor = Color.Transparent;
            this.pictureBox14.BackgroundImage = Resources.group_box_top;
            this.pictureBox14.Location = new Point(0xf2, 140);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new Size(40, 10);
            this.pictureBox14.TabIndex = 170;
            this.pictureBox14.TabStop = false;
            this.pictureBox15.BackColor = Color.Transparent;
            this.pictureBox15.Image = Resources.group_box_btm_right;
            this.pictureBox15.Location = new Point(0x116, 0x95);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new Size(10, 10);
            this.pictureBox15.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox15.TabIndex = 0xa9;
            this.pictureBox15.TabStop = false;
            this.pictureBox16.BackColor = Color.Transparent;
            this.pictureBox16.Image = Resources.group_box_top_right;
            this.pictureBox16.Location = new Point(0x116, 140);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new Size(10, 10);
            this.pictureBox16.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox16.TabIndex = 0xa8;
            this.pictureBox16.TabStop = false;
            this.pictureBox17.BackColor = Color.Transparent;
            this.pictureBox17.Image = Resources.group_box_btm_left;
            this.pictureBox17.Location = new Point(0xe9, 0x95);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new Size(10, 10);
            this.pictureBox17.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox17.TabIndex = 0xa7;
            this.pictureBox17.TabStop = false;
            this.pictureBox18.BackColor = Color.Transparent;
            this.pictureBox18.Image = Resources.group_box_top_left;
            this.pictureBox18.Location = new Point(0xe9, 140);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new Size(10, 10);
            this.pictureBox18.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox18.TabIndex = 0xa6;
            this.pictureBox18.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = (Image) manager.GetObject("$this.BackgroundImage");
            this.BackgroundImageLayout = ImageLayout.None;
            base.ClientSize = new Size(480, 310);
            base.Controls.Add(this.btnChange);
            base.Controls.Add(this.pictureBox13);
            base.Controls.Add(this.pictureBox14);
            base.Controls.Add(this.pictureBox15);
            base.Controls.Add(this.pictureBox16);
            base.Controls.Add(this.pictureBox17);
            base.Controls.Add(this.pictureBox18);
            base.Controls.Add(this.btnRemove);
            base.Controls.Add(this.pictureBox7);
            base.Controls.Add(this.pictureBox8);
            base.Controls.Add(this.pictureBox9);
            base.Controls.Add(this.pictureBox10);
            base.Controls.Add(this.pictureBox11);
            base.Controls.Add(this.pictureBox12);
            base.Controls.Add(this.imgAbilityCost);
            base.Controls.Add(this.txtUsedSlots);
            base.Controls.Add(this.imgSlot12);
            base.Controls.Add(this.imgSlot11);
            base.Controls.Add(this.imgSlot10);
            base.Controls.Add(this.imgSlot9);
            base.Controls.Add(this.imgSlot8);
            base.Controls.Add(this.imgSlot7);
            base.Controls.Add(this.imgSlot6);
            base.Controls.Add(this.imgSlot5);
            base.Controls.Add(this.imgSlot4);
            base.Controls.Add(this.imgSlot3);
            base.Controls.Add(this.imgSlot2);
            base.Controls.Add(this.imgSlot1);
            base.Controls.Add(this.txtCharName);
            base.Controls.Add(this.txtTypeLevel);
            base.Controls.Add(this.txtTypeName);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.txtAbilityDesc);
            base.Controls.Add(this.txtAbilityName);
            base.Controls.Add(this.txtAbilityName_jp);
            base.Controls.Add(this.listViewAbilities);
            this.DoubleBuffered = true;
            this.ForeColor = SystemColors.ActiveCaptionText;
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            this.MaximumSize = new Size(490, 0x156);
            base.MinimizeBox = false;
            this.MinimumSize = new Size(490, 0x156);
            base.Name = "pspo2seTypeAbilitiesForm";
            base.ShowInTaskbar = false;
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "PSPo2 Type Abilities Editor";
            base.Load += new EventHandler(this.pspo2seTypeAbilitiesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize) this.imgSlot1).EndInit();
            ((ISupportInitialize) this.imgSlot2).EndInit();
            ((ISupportInitialize) this.imgSlot4).EndInit();
            ((ISupportInitialize) this.imgSlot3).EndInit();
            ((ISupportInitialize) this.imgSlot8).EndInit();
            ((ISupportInitialize) this.imgSlot7).EndInit();
            ((ISupportInitialize) this.imgSlot6).EndInit();
            ((ISupportInitialize) this.imgSlot5).EndInit();
            ((ISupportInitialize) this.imgSlot12).EndInit();
            ((ISupportInitialize) this.imgSlot11).EndInit();
            ((ISupportInitialize) this.imgSlot10).EndInit();
            ((ISupportInitialize) this.imgSlot9).EndInit();
            ((ISupportInitialize) this.imgAbilityCost).EndInit();
            ((ISupportInitialize) this.pictureBox7).EndInit();
            ((ISupportInitialize) this.pictureBox8).EndInit();
            ((ISupportInitialize) this.pictureBox9).EndInit();
            ((ISupportInitialize) this.pictureBox10).EndInit();
            ((ISupportInitialize) this.pictureBox11).EndInit();
            ((ISupportInitialize) this.pictureBox12).EndInit();
            ((ISupportInitialize) this.pictureBox13).EndInit();
            ((ISupportInitialize) this.pictureBox14).EndInit();
            ((ISupportInitialize) this.pictureBox15).EndInit();
            ((ISupportInitialize) this.pictureBox16).EndInit();
            ((ISupportInitialize) this.pictureBox17).EndInit();
            ((ISupportInitialize) this.pictureBox18).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void listAvailableTypeAbilities()
        {
            this.chkListAll.Visible = !Program.form.legitVersion();
            this.view = viewType.available;
            this.btnChange.Text = "apply";
            this.btnRemove.Text = "cancel";
            this.listViewAbilities.Items.Clear();
            this.listOfAbilitiesSlotCount = 0;
            ListViewItem item = null;
            for (int i = 0; i < this.abilityDb.ability_db_filled; i++)
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass class2 = this.abilityDb.ability_db.ability[i];
                if (this.saveType == pspo2seForm.SaveType.PSP2I)
                {
                    class2.slots = class2.slots_inf;
                    class2.hu_lvl = class2.hu_lvl_inf;
                    class2.ra_lvl = class2.ra_lvl_inf;
                    class2.fo_lvl = class2.fo_lvl_inf;
                    class2.va_lvl = class2.va_lvl_inf;
                }
                if (class2.name == "")
                {
                    class2.name = class2.name_jp;
                }
                if (class2.hex != "")
                {
                    bool flag = false;
                    if (class2.slots != 0)
                    {
                        if (!this.canFindAbilityInAttached(class2.hex))
                        {
                            if (this.chkListAll.Checked)
                            {
                                flag = true;
                            }
                            else if ((((class2.hu_lvl <= this.oldJobs[0].level) && (class2.hu_lvl > 0)) || (((class2.ra_lvl <= this.oldJobs[1].level) && (class2.ra_lvl > 0)) || (((class2.fo_lvl <= this.oldJobs[2].level) && (class2.fo_lvl > 0)) || ((class2.va_lvl <= this.oldJobs[3].level) && (class2.va_lvl > 0))))) || ((class2.hu_lvl == 0) && ((class2.ra_lvl == 0) && ((class2.fo_lvl == 0) && (class2.va_lvl == 0)))))
                            {
                                flag = true;
                            }
                        }
                        if (flag)
                        {
                            item = !this.legitMode ? new ListViewItem("1", 0) : new ListViewItem(class2.slots, 0);
                            item.SubItems.Add(class2.name);
                            item.SubItems.Add(class2.hex);
                            this.listViewAbilities.Items.Add(item);
                        }
                    }
                    this.listOfAbilities[this.listOfAbilitiesSlotCount] = new abilitySlotsType();
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].hex = class2.hex;
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].name = class2.name;
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].valid = flag;
                    this.listOfAbilitiesSlotCount++;
                }
            }
            this.txtAbilityName.Text = this.newJob.attachedAbilities;
            this.txtCharName.Text = this.character_name;
            this.showSelectedAbility();
        }

        private void listTypeAbilities()
        {
            this.chkListAll.Visible = false;
            this.view = viewType.equipped;
            this.btnChange.Text = "add";
            this.btnRemove.Text = "remove";
            this.listViewAbilities.Items.Clear();
            this.listOfAbilitiesSlotCount = 0;
            ListViewItem item = null;
            for (int i = 0; i < this.max_abilities; i++)
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass class2 = this.abilityDb.findAbilityInDb(this.newJob.attachedAbilities.Substring(i * 2, 2));
                if (class2.name == "")
                {
                    class2.name = class2.name_jp;
                }
                if (class2.hex != "")
                {
                    if (this.saveType == pspo2seForm.SaveType.PSP2I)
                    {
                        class2.slots = class2.slots_inf;
                    }
                    if (class2.slots != 0)
                    {
                        item = !this.legitMode ? new ListViewItem("1", 0) : new ListViewItem(class2.slots, 0);
                        item.SubItems.Add(class2.name);
                        item.SubItems.Add(class2.hex);
                        this.listViewAbilities.Items.Add(item);
                    }
                    this.listOfAbilities[this.listOfAbilitiesSlotCount] = new abilitySlotsType();
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].hex = class2.hex;
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].name = class2.name;
                    this.listOfAbilitiesSlotCount++;
                }
            }
            this.txtAbilityName.Text = this.newJob.attachedAbilities;
            this.txtCharName.Text = this.character_name;
            this.typeAbilitySlotLogic();
            this.showSelectedAbility();
        }

        private void listViewAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewAbilities.SelectedItems.Count > 0)
            {
                this.showSelectedAbility();
            }
        }

        public void loadCurrentTypeInformation()
        {
            if (this.oldJobs[(int) this.selected_job] == null)
            {
                MessageBox.Show("Current job information was not set");
                base.DialogResult = DialogResult.Cancel;
                base.Dispose();
            }
            else
            {
                this.newJob = this.oldJobs[(int) this.selected_job];
                this.listTypeAbilities();
                this.txtTypeName.Text = this.newJob.job.ToString();
                this.txtTypeLevel.Text = "LV" + this.newJob.level;
            }
        }

        private void pspo2seTypeAbilitiesForm_Load(object sender, EventArgs e)
        {
            if (Program.form.legitVersion())
            {
                this.radioBtnReal.Visible = false;
                this.radioBtnFake.Visible = false;
            }
            this.loadCurrentTypeInformation();
        }

        private void radioBtnFake_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioBtnFake.Checked)
            {
                this.legitMode = false;
                this.listTypeAbilities();
                this.typeAbilitySlotLogic();
            }
        }

        private void radioBtnReal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioBtnReal.Checked)
            {
                this.legitMode = true;
                this.listTypeAbilities();
                this.typeAbilitySlotLogic();
            }
        }

        private void removeAbility(string hex)
        {
            int length = this.findAbilityPos(hex);
            string str = this.newJob.attachedAbilities.Substring(0, length);
            string str2 = this.newJob.attachedAbilities.Substring(length + 2, (this.newJob.attachedAbilities.Length - str.Length) - 2);
            this.newJob.attachedAbilities = str + "00" + str2;
            this.listTypeAbilities();
        }

        private void resetTypeAbilitySlots()
        {
            this.imgSlot1.Image = Resources.TypeAbilitiesFree;
            this.imgSlot2.Image = Resources.TypeAbilitiesFree;
            this.imgSlot3.Image = Resources.TypeAbilitiesFree;
            this.imgSlot4.Image = Resources.TypeAbilitiesFree;
            this.imgSlot5.Image = Resources.TypeAbilitiesFree;
            this.imgSlot6.Image = Resources.TypeAbilitiesFree;
            this.imgSlot7.Image = Resources.TypeAbilitiesFree;
            this.imgSlot8.Image = Resources.TypeAbilitiesFree;
            this.imgSlot9.Image = Resources.TypeAbilitiesFree;
            this.imgSlot10.Image = Resources.TypeAbilitiesFree;
            this.imgSlot11.Image = Resources.TypeAbilitiesFree;
            this.imgSlot12.Image = Resources.TypeAbilitiesFree;
            this.imgSlot1.Visible = true;
            this.imgSlot2.Visible = true;
            this.imgSlot3.Visible = true;
            this.imgSlot4.Visible = true;
            this.imgSlot5.Visible = false;
            this.imgSlot6.Visible = false;
            this.imgSlot7.Visible = false;
            this.imgSlot8.Visible = false;
            this.imgSlot9.Visible = false;
            this.imgSlot10.Visible = false;
            this.imgSlot11.Visible = false;
            this.imgSlot12.Visible = false;
        }

        public void showSelectedAbility()
        {
            pspo2seAbilityDb.abilityDb_AbilitiyClass class2 = new pspo2seAbilityDb.abilityDb_AbilitiyClass();
            if (this.listViewAbilities.SelectedItems.Count != 0)
            {
                class2 = this.abilityDb.findAbilityInDb(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
            }
            else if (this.listViewAbilities.Items.Count > 0)
            {
                this.listViewAbilities.Items[0].Selected = true;
                class2 = this.abilityDb.findAbilityInDb(this.listViewAbilities.Items[0].SubItems[2].Text);
            }
            this.txtAbilityName.Text = class2.name;
            this.txtAbilityName_jp.Text = class2.name_jp;
            this.txtAbilityDesc.Text = class2.desc;
            this.imgAbilityCost.Visible = true;
            switch (class2.slots)
            {
                case 1:
                    this.imgAbilityCost.Image = Resources.TypeAbilities_cost_1;
                    return;

                case 2:
                    this.imgAbilityCost.Image = Resources.TypeAbilities_cost_2;
                    return;

                case 3:
                    this.imgAbilityCost.Image = Resources.TypeAbilities_cost_3;
                    return;

                case 4:
                    this.imgAbilityCost.Image = Resources.TypeAbilities_cost_4;
                    return;
            }
            this.imgAbilityCost.Visible = false;
        }

        private void typeAbilitySlotLogic()
        {
            this.resetTypeAbilitySlots();
            this.allowedAbilitySlotsLogic();
            this.usedSlotsLogic();
            if (!this.allowEdit)
            {
                this.txtUsedSlots.Text = "unk_/" + this.allowedSlots;
            }
            else
            {
                this.txtUsedSlots.Text = this.usedSlots + "/" + this.allowedSlots;
            }
        }

        private void usedSlotsLogic()
        {
            int num2;
            int num3;
            this.allowEdit = true;
            this.usedSlots = 0;
            if (this.legitMode)
            {
                num2 = 0;
            }
            else
            {
                this.allowedSlots = (this.saveType != pspo2seForm.SaveType.PSP2I) ? 8 : 12;
                this.usedSlots = this.allowedSlots;
                for (int i = 0; i < this.listOfAbilitiesSlotCount; i++)
                {
                    if (this.listOfAbilities[i].name == "No Ability")
                    {
                        this.usedSlots--;
                    }
                }
                goto TR_0012;
            }
            goto TR_0022;
        TR_0012:
            num3 = 1;
            while (num3 <= this.usedSlots)
            {
                int num4 = num3;
                switch (num4)
                {
                    case 1:
                        this.imgSlot1.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 2:
                        this.imgSlot2.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 3:
                        this.imgSlot3.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 4:
                        this.imgSlot4.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 5:
                        this.imgSlot5.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 6:
                        this.imgSlot6.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 7:
                        this.imgSlot7.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 8:
                        this.imgSlot8.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 9:
                        this.imgSlot9.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 10:
                        this.imgSlot10.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 11:
                        this.imgSlot11.Image = Resources.TypeAbilitiesUsed;
                        break;

                    case 12:
                        this.imgSlot12.Image = Resources.TypeAbilitiesUsed;
                        break;

                    default:
                        break;
                }
                num3++;
            }
            return;
        TR_0022:
            while (true)
            {
                if (num2 < this.listViewAbilities.Items.Count)
                {
                    pspo2seAbilityDb.abilityDb_AbilitiyClass class2 = this.abilityDb.findAbilityInDb(this.listViewAbilities.Items[num2].SubItems[2].Text);
                    if (this.saveType == pspo2seForm.SaveType.PSP2I)
                    {
                        class2.slots = class2.slots_inf;
                        class2.hu_lvl = class2.hu_lvl_inf;
                        class2.ra_lvl = class2.ra_lvl_inf;
                        class2.fo_lvl = class2.fo_lvl_inf;
                        class2.va_lvl = class2.va_lvl_inf;
                    }
                    if (class2.slots > 0)
                    {
                        this.usedSlots += class2.slots;
                        break;
                    }
                    if (class2.name == "No Ability")
                    {
                        break;
                    }
                    MessageBox.Show("You have an ability equipped with unknown slot costs\r\nYou will be unable to add abilities at the moment\r\nbut you can still remove the unknown ability.\r\n\r\nPlease wait for a future abilities database update\r\nfor full functionality\r\n\r\nThe offending ability is " + class2.name + " [" + class2.hex + "]", "Database Info Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.allowEdit = false;
                    this.usedSlots = 0;
                    goto TR_0012;
                }
                else
                {
                    goto TR_0012;
                }
                break;
            }
            num2++;
            goto TR_0022;
        }

        public pspo2seForm.jobClass[] oldJobs
        {
            get => 
                this.oldJobInfo;
            set => 
                this.oldJobInfo = value;
        }

        public pspo2seForm.jobClass newJob
        {
            get => 
                this.newJobInfo;
            set => 
                this.newJobInfo = value;
        }

        public pspo2seForm.jobType selectedJob
        {
            get => 
                this.selected_job;
            set => 
                this.selected_job = value;
        }

        public int max_abilities
        {
            get => 
                this.parent_max_abilities;
            set => 
                this.parent_max_abilities = value;
        }

        public string character_name
        {
            get => 
                this.char_name;
            set => 
                this.char_name = value;
        }

        public pspo2seAbilityDb abilityDb
        {
            get => 
                this.parentsAbilityDb;
            set => 
                this.parentsAbilityDb = value;
        }

        public pspo2seForm.SaveType saveType
        {
            get => 
                this.save_type;
            set => 
                this.save_type = value;
        }

        private class abilitySlotsType
        {
            public bool valid;
            public string hex = "";
            public string name = "";
        }

        private enum viewType
        {
            equipped,
            available
        }
    }
}

