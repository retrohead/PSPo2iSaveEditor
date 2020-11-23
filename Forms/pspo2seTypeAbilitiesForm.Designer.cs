using pspo2seSaveEditorProgram.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class pspo2seTypeAbilitiesForm : Form
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pspo2seTypeAbilitiesForm));
            this.listViewAbilities = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.abilitiesImageList = new System.Windows.Forms.ImageList(this.components);
            this.txtAbilityName = new System.Windows.Forms.Label();
            this.txtAbilityName_jp = new System.Windows.Forms.Label();
            this.txtAbilityDesc = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkListAll = new System.Windows.Forms.CheckBox();
            this.radioBtnFake = new System.Windows.Forms.RadioButton();
            this.radioBtnReal = new System.Windows.Forms.RadioButton();
            this.txtTypeName = new System.Windows.Forms.Label();
            this.txtTypeLevel = new System.Windows.Forms.Label();
            this.txtCharName = new System.Windows.Forms.Label();
            this.imgSlot1 = new System.Windows.Forms.PictureBox();
            this.imgSlot2 = new System.Windows.Forms.PictureBox();
            this.imgSlot4 = new System.Windows.Forms.PictureBox();
            this.imgSlot3 = new System.Windows.Forms.PictureBox();
            this.imgSlot8 = new System.Windows.Forms.PictureBox();
            this.imgSlot7 = new System.Windows.Forms.PictureBox();
            this.imgSlot6 = new System.Windows.Forms.PictureBox();
            this.imgSlot5 = new System.Windows.Forms.PictureBox();
            this.imgSlot12 = new System.Windows.Forms.PictureBox();
            this.imgSlot11 = new System.Windows.Forms.PictureBox();
            this.imgSlot10 = new System.Windows.Forms.PictureBox();
            this.imgSlot9 = new System.Windows.Forms.PictureBox();
            this.txtUsedSlots = new System.Windows.Forms.Label();
            this.imgAbilityCost = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnRemove = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.btnChange = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAbilityCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewAbilities
            // 
            this.listViewAbilities.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listViewAbilities.BackgroundImage")));
            this.listViewAbilities.BackgroundImageTiled = true;
            this.listViewAbilities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAbilities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader11,
            this.columnHeader5});
            this.listViewAbilities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listViewAbilities.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewAbilities.ForeColor = System.Drawing.Color.White;
            this.listViewAbilities.FullRowSelect = true;
            this.listViewAbilities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewAbilities.HideSelection = false;
            this.listViewAbilities.LabelWrap = false;
            this.listViewAbilities.Location = new System.Drawing.Point(10, 56);
            this.listViewAbilities.MultiSelect = false;
            this.listViewAbilities.Name = "listViewAbilities";
            this.listViewAbilities.Size = new System.Drawing.Size(215, 121);
            this.listViewAbilities.SmallImageList = this.abilitiesImageList;
            this.listViewAbilities.TabIndex = 127;
            this.listViewAbilities.UseCompatibleStateImageBehavior = false;
            this.listViewAbilities.View = System.Windows.Forms.View.Details;
            this.listViewAbilities.SelectedIndexChanged += new System.EventHandler(this.listViewAbilities_SelectedIndexChanged);
            this.listViewAbilities.Click += new System.EventHandler(this.listViewAbilities_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 30;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 165;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // abilitiesImageList
            // 
            this.abilitiesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("abilitiesImageList.ImageStream")));
            this.abilitiesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.abilitiesImageList.Images.SetKeyName(0, "TypeAbilitiesUsed.png");
            // 
            // txtAbilityName
            // 
            this.txtAbilityName.AutoSize = true;
            this.txtAbilityName.BackColor = System.Drawing.Color.Transparent;
            this.txtAbilityName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbilityName.ForeColor = System.Drawing.Color.White;
            this.txtAbilityName.Location = new System.Drawing.Point(8, 185);
            this.txtAbilityName.Name = "txtAbilityName";
            this.txtAbilityName.Size = new System.Drawing.Size(103, 16);
            this.txtAbilityName.TabIndex = 129;
            this.txtAbilityName.Text = "txtAbilityName";
            // 
            // txtAbilityName_jp
            // 
            this.txtAbilityName_jp.AutoSize = true;
            this.txtAbilityName_jp.BackColor = System.Drawing.Color.Transparent;
            this.txtAbilityName_jp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbilityName_jp.ForeColor = System.Drawing.Color.Teal;
            this.txtAbilityName_jp.Location = new System.Drawing.Point(9, 202);
            this.txtAbilityName_jp.Name = "txtAbilityName_jp";
            this.txtAbilityName_jp.Size = new System.Drawing.Size(126, 14);
            this.txtAbilityName_jp.TabIndex = 130;
            this.txtAbilityName_jp.Text = "txtAbilityName_jp";
            // 
            // txtAbilityDesc
            // 
            this.txtAbilityDesc.BackColor = System.Drawing.Color.Transparent;
            this.txtAbilityDesc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbilityDesc.ForeColor = System.Drawing.Color.White;
            this.txtAbilityDesc.Location = new System.Drawing.Point(8, 217);
            this.txtAbilityDesc.MaximumSize = new System.Drawing.Size(210, 43);
            this.txtAbilityDesc.MinimumSize = new System.Drawing.Size(210, 43);
            this.txtAbilityDesc.Name = "txtAbilityDesc";
            this.txtAbilityDesc.Size = new System.Drawing.Size(210, 43);
            this.txtAbilityDesc.TabIndex = 131;
            this.txtAbilityDesc.Text = "txtAbilityDesc";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(320, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 132;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(403, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 133;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.chkListAll);
            this.groupBox1.Controls.Add(this.radioBtnFake);
            this.groupBox1.Controls.Add(this.radioBtnReal);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(-8, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 40);
            this.groupBox1.TabIndex = 134;
            this.groupBox1.TabStop = false;
            // 
            // chkListAll
            // 
            this.chkListAll.AutoSize = true;
            this.chkListAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkListAll.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListAll.Location = new System.Drawing.Point(136, 21);
            this.chkListAll.Name = "chkListAll";
            this.chkListAll.Size = new System.Drawing.Size(105, 16);
            this.chkListAll.TabIndex = 136;
            this.chkListAll.Text = "List All Abilities";
            this.chkListAll.UseVisualStyleBackColor = true;
            this.chkListAll.Visible = false;
            this.chkListAll.CheckedChanged += new System.EventHandler(this.chkListAll_CheckedChanged);
            // 
            // radioBtnFake
            // 
            this.radioBtnFake.AutoSize = true;
            this.radioBtnFake.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtnFake.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnFake.Location = new System.Drawing.Point(16, 21);
            this.radioBtnFake.Name = "radioBtnFake";
            this.radioBtnFake.Size = new System.Drawing.Size(105, 16);
            this.radioBtnFake.TabIndex = 135;
            this.radioBtnFake.Text = "Fake Slot Usage";
            this.radioBtnFake.UseVisualStyleBackColor = true;
            this.radioBtnFake.CheckedChanged += new System.EventHandler(this.radioBtnFake_CheckedChanged);
            // 
            // radioBtnReal
            // 
            this.radioBtnReal.AutoSize = true;
            this.radioBtnReal.Checked = true;
            this.radioBtnReal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtnReal.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnReal.Location = new System.Drawing.Point(16, 7);
            this.radioBtnReal.Name = "radioBtnReal";
            this.radioBtnReal.Size = new System.Drawing.Size(103, 16);
            this.radioBtnReal.TabIndex = 134;
            this.radioBtnReal.TabStop = true;
            this.radioBtnReal.Text = "Real Slot Usage";
            this.radioBtnReal.UseVisualStyleBackColor = true;
            this.radioBtnReal.CheckedChanged += new System.EventHandler(this.radioBtnReal_CheckedChanged);
            // 
            // txtTypeName
            // 
            this.txtTypeName.BackColor = System.Drawing.Color.Transparent;
            this.txtTypeName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeName.ForeColor = System.Drawing.Color.White;
            this.txtTypeName.Location = new System.Drawing.Point(12, 33);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(83, 14);
            this.txtTypeName.TabIndex = 135;
            this.txtTypeName.Text = "txtTypeName";
            // 
            // txtTypeLevel
            // 
            this.txtTypeLevel.BackColor = System.Drawing.Color.Transparent;
            this.txtTypeLevel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeLevel.ForeColor = System.Drawing.Color.White;
            this.txtTypeLevel.Location = new System.Drawing.Point(101, 33);
            this.txtTypeLevel.Name = "txtTypeLevel";
            this.txtTypeLevel.Size = new System.Drawing.Size(47, 14);
            this.txtTypeLevel.TabIndex = 136;
            this.txtTypeLevel.Text = "txtTypeLevel";
            this.txtTypeLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCharName
            // 
            this.txtCharName.BackColor = System.Drawing.Color.Transparent;
            this.txtCharName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharName.ForeColor = System.Drawing.Color.White;
            this.txtCharName.Location = new System.Drawing.Point(12, 11);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.Size = new System.Drawing.Size(167, 20);
            this.txtCharName.TabIndex = 137;
            this.txtCharName.Text = "txtCharName";
            // 
            // imgSlot1
            // 
            this.imgSlot1.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot1.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot1.Location = new System.Drawing.Point(169, 35);
            this.imgSlot1.Name = "imgSlot1";
            this.imgSlot1.Size = new System.Drawing.Size(10, 10);
            this.imgSlot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot1.TabIndex = 138;
            this.imgSlot1.TabStop = false;
            // 
            // imgSlot2
            // 
            this.imgSlot2.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot2.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot2.Location = new System.Drawing.Point(180, 35);
            this.imgSlot2.Name = "imgSlot2";
            this.imgSlot2.Size = new System.Drawing.Size(10, 10);
            this.imgSlot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot2.TabIndex = 139;
            this.imgSlot2.TabStop = false;
            // 
            // imgSlot4
            // 
            this.imgSlot4.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot4.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot4.Location = new System.Drawing.Point(202, 35);
            this.imgSlot4.Name = "imgSlot4";
            this.imgSlot4.Size = new System.Drawing.Size(10, 10);
            this.imgSlot4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot4.TabIndex = 141;
            this.imgSlot4.TabStop = false;
            // 
            // imgSlot3
            // 
            this.imgSlot3.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot3.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot3.Location = new System.Drawing.Point(191, 35);
            this.imgSlot3.Name = "imgSlot3";
            this.imgSlot3.Size = new System.Drawing.Size(10, 10);
            this.imgSlot3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot3.TabIndex = 140;
            this.imgSlot3.TabStop = false;
            // 
            // imgSlot8
            // 
            this.imgSlot8.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot8.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot8.Location = new System.Drawing.Point(246, 35);
            this.imgSlot8.Name = "imgSlot8";
            this.imgSlot8.Size = new System.Drawing.Size(10, 10);
            this.imgSlot8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot8.TabIndex = 145;
            this.imgSlot8.TabStop = false;
            // 
            // imgSlot7
            // 
            this.imgSlot7.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot7.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot7.Location = new System.Drawing.Point(235, 35);
            this.imgSlot7.Name = "imgSlot7";
            this.imgSlot7.Size = new System.Drawing.Size(10, 10);
            this.imgSlot7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot7.TabIndex = 144;
            this.imgSlot7.TabStop = false;
            // 
            // imgSlot6
            // 
            this.imgSlot6.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot6.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot6.Location = new System.Drawing.Point(224, 35);
            this.imgSlot6.Name = "imgSlot6";
            this.imgSlot6.Size = new System.Drawing.Size(10, 10);
            this.imgSlot6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot6.TabIndex = 143;
            this.imgSlot6.TabStop = false;
            // 
            // imgSlot5
            // 
            this.imgSlot5.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot5.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot5.Location = new System.Drawing.Point(213, 35);
            this.imgSlot5.Name = "imgSlot5";
            this.imgSlot5.Size = new System.Drawing.Size(10, 10);
            this.imgSlot5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot5.TabIndex = 142;
            this.imgSlot5.TabStop = false;
            // 
            // imgSlot12
            // 
            this.imgSlot12.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot12.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot12.Location = new System.Drawing.Point(290, 35);
            this.imgSlot12.Name = "imgSlot12";
            this.imgSlot12.Size = new System.Drawing.Size(10, 10);
            this.imgSlot12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot12.TabIndex = 149;
            this.imgSlot12.TabStop = false;
            // 
            // imgSlot11
            // 
            this.imgSlot11.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot11.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot11.Location = new System.Drawing.Point(279, 35);
            this.imgSlot11.Name = "imgSlot11";
            this.imgSlot11.Size = new System.Drawing.Size(10, 10);
            this.imgSlot11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot11.TabIndex = 148;
            this.imgSlot11.TabStop = false;
            // 
            // imgSlot10
            // 
            this.imgSlot10.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot10.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot10.Location = new System.Drawing.Point(268, 35);
            this.imgSlot10.Name = "imgSlot10";
            this.imgSlot10.Size = new System.Drawing.Size(10, 10);
            this.imgSlot10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot10.TabIndex = 147;
            this.imgSlot10.TabStop = false;
            // 
            // imgSlot9
            // 
            this.imgSlot9.BackColor = System.Drawing.Color.Transparent;
            this.imgSlot9.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesFree;
            this.imgSlot9.Location = new System.Drawing.Point(257, 35);
            this.imgSlot9.Name = "imgSlot9";
            this.imgSlot9.Size = new System.Drawing.Size(10, 10);
            this.imgSlot9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSlot9.TabIndex = 146;
            this.imgSlot9.TabStop = false;
            // 
            // txtUsedSlots
            // 
            this.txtUsedSlots.AutoSize = true;
            this.txtUsedSlots.BackColor = System.Drawing.Color.Transparent;
            this.txtUsedSlots.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsedSlots.ForeColor = System.Drawing.Color.White;
            this.txtUsedSlots.Location = new System.Drawing.Point(305, 33);
            this.txtUsedSlots.Name = "txtUsedSlots";
            this.txtUsedSlots.Size = new System.Drawing.Size(40, 13);
            this.txtUsedSlots.TabIndex = 150;
            this.txtUsedSlots.Text = "12/12";
            this.txtUsedSlots.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imgAbilityCost
            // 
            this.imgAbilityCost.BackColor = System.Drawing.Color.Transparent;
            this.imgAbilityCost.Image = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilities_cost_4;
            this.imgAbilityCost.Location = new System.Drawing.Point(182, 205);
            this.imgAbilityCost.Name = "imgAbilityCost";
            this.imgAbilityCost.Size = new System.Drawing.Size(43, 10);
            this.imgAbilityCost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgAbilityCost.TabIndex = 151;
            this.imgAbilityCost.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(239, 162);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(42, 12);
            this.btnRemove.TabIndex = 165;
            this.btnRemove.Text = "remove";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_btm;
            this.pictureBox7.Location = new System.Drawing.Point(242, 169);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(40, 10);
            this.pictureBox7.TabIndex = 164;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_top;
            this.pictureBox8.Location = new System.Drawing.Point(242, 160);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(40, 10);
            this.pictureBox8.TabIndex = 163;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_btm_right;
            this.pictureBox9.Location = new System.Drawing.Point(278, 169);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(10, 10);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 162;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_top_right;
            this.pictureBox10.Location = new System.Drawing.Point(278, 160);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(10, 10);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 161;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_btm_left;
            this.pictureBox11.Location = new System.Drawing.Point(233, 169);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(10, 10);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox11.TabIndex = 160;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_top_left;
            this.pictureBox12.Location = new System.Drawing.Point(233, 160);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(10, 10);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox12.TabIndex = 159;
            this.pictureBox12.TabStop = false;
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Location = new System.Drawing.Point(239, 142);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(42, 12);
            this.btnChange.TabIndex = 172;
            this.btnChange.Text = "add";
            this.btnChange.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_btm;
            this.pictureBox13.Location = new System.Drawing.Point(242, 149);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(40, 10);
            this.pictureBox13.TabIndex = 171;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_top;
            this.pictureBox14.Location = new System.Drawing.Point(242, 140);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(40, 10);
            this.pictureBox14.TabIndex = 170;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_btm_right;
            this.pictureBox15.Location = new System.Drawing.Point(278, 149);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(10, 10);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox15.TabIndex = 169;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox16.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_top_right;
            this.pictureBox16.Location = new System.Drawing.Point(278, 140);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(10, 10);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox16.TabIndex = 168;
            this.pictureBox16.TabStop = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox17.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_btm_left;
            this.pictureBox17.Location = new System.Drawing.Point(233, 149);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(10, 10);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox17.TabIndex = 167;
            this.pictureBox17.TabStop = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox18.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_top_left;
            this.pictureBox18.Location = new System.Drawing.Point(233, 140);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(10, 10);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox18.TabIndex = 166;
            this.pictureBox18.TabStop = false;
            // 
            // pspo2seTypeAbilitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(470, 299);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.imgAbilityCost);
            this.Controls.Add(this.txtUsedSlots);
            this.Controls.Add(this.imgSlot12);
            this.Controls.Add(this.imgSlot11);
            this.Controls.Add(this.imgSlot10);
            this.Controls.Add(this.imgSlot9);
            this.Controls.Add(this.imgSlot8);
            this.Controls.Add(this.imgSlot7);
            this.Controls.Add(this.imgSlot6);
            this.Controls.Add(this.imgSlot5);
            this.Controls.Add(this.imgSlot4);
            this.Controls.Add(this.imgSlot3);
            this.Controls.Add(this.imgSlot2);
            this.Controls.Add(this.imgSlot1);
            this.Controls.Add(this.txtCharName);
            this.Controls.Add(this.txtTypeLevel);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtAbilityDesc);
            this.Controls.Add(this.txtAbilityName);
            this.Controls.Add(this.txtAbilityName_jp);
            this.Controls.Add(this.listViewAbilities);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 342);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 342);
            this.Name = "pspo2seTypeAbilitiesForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PSPo2 Type Abilities Editor";
            this.Load += new System.EventHandler(this.pspo2seTypeAbilitiesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlot9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAbilityCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
