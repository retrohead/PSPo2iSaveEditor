// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.pspo2seTypeAbilitiesForm
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using pspo2seSaveEditorProgram.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
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
    private pspo2seTypeAbilitiesForm.viewType view;
    private bool allowEdit;
    private bool legitMode = true;
    private pspo2seForm.jobClass[] oldJobInfo = new pspo2seForm.jobClass[4];
    private pspo2seForm.jobClass newJobInfo = new pspo2seForm.jobClass();
    private pspo2seForm.jobType selected_job = pspo2seForm.jobType.None;
    private int parent_max_abilities;
    private string char_name = "";
    private pspo2seAbilityDb parentsAbilityDb;
    private pspo2seTypeAbilitiesForm.abilitySlotsType[] listOfAbilities = new pspo2seTypeAbilitiesForm.abilitySlotsType[257];
    private int listOfAbilitiesSlotCount;
    private pspo2seForm.SaveType save_type;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (pspo2seTypeAbilitiesForm));
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
      this.SuspendLayout();
      this.listViewAbilities.BackgroundImage = (Image) componentResourceManager.GetObject("listViewAbilities.BackgroundImage");
      this.listViewAbilities.BackgroundImageTiled = true;
      this.listViewAbilities.BorderStyle = BorderStyle.None;
      this.listViewAbilities.Columns.AddRange(new ColumnHeader[3]
      {
        this.columnHeader2,
        this.columnHeader11,
        this.columnHeader5
      });
      this.listViewAbilities.Cursor = Cursors.Hand;
      this.listViewAbilities.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listViewAbilities.ForeColor = Color.White;
      this.listViewAbilities.FullRowSelect = true;
      this.listViewAbilities.HeaderStyle = ColumnHeaderStyle.None;
      this.listViewAbilities.HideSelection = false;
      this.listViewAbilities.LabelWrap = false;
      this.listViewAbilities.Location = new Point(10, 56);
      this.listViewAbilities.MultiSelect = false;
      this.listViewAbilities.Name = "listViewAbilities";
      this.listViewAbilities.Size = new Size(215, 121);
      this.listViewAbilities.SmallImageList = this.abilitiesImageList;
      this.listViewAbilities.TabIndex = (int) sbyte.MaxValue;
      this.listViewAbilities.UseCompatibleStateImageBehavior = false;
      this.listViewAbilities.View = View.Details;
      this.listViewAbilities.SelectedIndexChanged += new EventHandler(this.listViewAbilities_SelectedIndexChanged);
      this.listViewAbilities.Click += new EventHandler(this.listViewAbilities_SelectedIndexChanged);
      this.columnHeader2.Width = 30;
      this.columnHeader11.Width = 165;
      this.columnHeader5.Width = 0;
      this.abilitiesImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("abilitiesImageList.ImageStream");
      this.abilitiesImageList.TransparentColor = Color.Transparent;
      this.abilitiesImageList.Images.SetKeyName(0, "TypeAbilitiesUsed.png");
      this.txtAbilityName.AutoSize = true;
      this.txtAbilityName.BackColor = Color.Transparent;
      this.txtAbilityName.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtAbilityName.ForeColor = Color.White;
      this.txtAbilityName.Location = new Point(8, 185);
      this.txtAbilityName.Name = "txtAbilityName";
      this.txtAbilityName.Size = new Size(103, 16);
      this.txtAbilityName.TabIndex = 129;
      this.txtAbilityName.Text = "txtAbilityName";
      this.txtAbilityName_jp.AutoSize = true;
      this.txtAbilityName_jp.BackColor = Color.Transparent;
      this.txtAbilityName_jp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtAbilityName_jp.ForeColor = Color.Teal;
      this.txtAbilityName_jp.Location = new Point(9, 202);
      this.txtAbilityName_jp.Name = "txtAbilityName_jp";
      this.txtAbilityName_jp.Size = new Size(126, 14);
      this.txtAbilityName_jp.TabIndex = 130;
      this.txtAbilityName_jp.Text = "txtAbilityName_jp";
      this.txtAbilityDesc.BackColor = Color.Transparent;
      this.txtAbilityDesc.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtAbilityDesc.ForeColor = Color.White;
      this.txtAbilityDesc.Location = new Point(8, 217);
      this.txtAbilityDesc.MaximumSize = new Size(210, 43);
      this.txtAbilityDesc.MinimumSize = new Size(210, 43);
      this.txtAbilityDesc.Name = "txtAbilityDesc";
      this.txtAbilityDesc.Size = new Size(210, 43);
      this.txtAbilityDesc.TabIndex = 131;
      this.txtAbilityDesc.Text = "txtAbilityDesc";
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.DialogResult = DialogResult.OK;
      this.btnSave.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnSave.Location = new Point(320, 11);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(82, 23);
      this.btnSave.TabIndex = 132;
      this.btnSave.Text = "Save and Exit";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnCancel.Cursor = Cursors.Hand;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnCancel.Location = new Point(403, 11);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(82, 23);
      this.btnCancel.TabIndex = 133;
      this.btnCancel.Text = "Exit";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.groupBox1.BackColor = SystemColors.Control;
      this.groupBox1.Controls.Add((Control) this.chkListAll);
      this.groupBox1.Controls.Add((Control) this.radioBtnFake);
      this.groupBox1.Controls.Add((Control) this.radioBtnReal);
      this.groupBox1.Controls.Add((Control) this.btnCancel);
      this.groupBox1.Controls.Add((Control) this.btnSave);
      this.groupBox1.Location = new Point(-8, 272);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(503, 40);
      this.groupBox1.TabIndex = 134;
      this.groupBox1.TabStop = false;
      this.chkListAll.AutoSize = true;
      this.chkListAll.Cursor = Cursors.Hand;
      this.chkListAll.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkListAll.Location = new Point(136, 21);
      this.chkListAll.Name = "chkListAll";
      this.chkListAll.Size = new Size(105, 16);
      this.chkListAll.TabIndex = 136;
      this.chkListAll.Text = "List All Abilities";
      this.chkListAll.UseVisualStyleBackColor = true;
      this.chkListAll.Visible = false;
      this.chkListAll.CheckedChanged += new EventHandler(this.chkListAll_CheckedChanged);
      this.radioBtnFake.AutoSize = true;
      this.radioBtnFake.Cursor = Cursors.Hand;
      this.radioBtnFake.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.radioBtnFake.Location = new Point(16, 21);
      this.radioBtnFake.Name = "radioBtnFake";
      this.radioBtnFake.Size = new Size(105, 16);
      this.radioBtnFake.TabIndex = 135;
      this.radioBtnFake.Text = "Fake Slot Usage";
      this.radioBtnFake.UseVisualStyleBackColor = true;
      this.radioBtnFake.CheckedChanged += new EventHandler(this.radioBtnFake_CheckedChanged);
      this.radioBtnReal.AutoSize = true;
      this.radioBtnReal.Checked = true;
      this.radioBtnReal.Cursor = Cursors.Hand;
      this.radioBtnReal.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.radioBtnReal.Location = new Point(16, 7);
      this.radioBtnReal.Name = "radioBtnReal";
      this.radioBtnReal.Size = new Size(103, 16);
      this.radioBtnReal.TabIndex = 134;
      this.radioBtnReal.TabStop = true;
      this.radioBtnReal.Text = "Real Slot Usage";
      this.radioBtnReal.UseVisualStyleBackColor = true;
      this.radioBtnReal.CheckedChanged += new EventHandler(this.radioBtnReal_CheckedChanged);
      this.txtTypeName.BackColor = Color.Transparent;
      this.txtTypeName.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtTypeName.ForeColor = Color.White;
      this.txtTypeName.Location = new Point(12, 33);
      this.txtTypeName.Name = "txtTypeName";
      this.txtTypeName.Size = new Size(83, 14);
      this.txtTypeName.TabIndex = 135;
      this.txtTypeName.Text = "txtTypeName";
      this.txtTypeLevel.BackColor = Color.Transparent;
      this.txtTypeLevel.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtTypeLevel.ForeColor = Color.White;
      this.txtTypeLevel.Location = new Point(101, 33);
      this.txtTypeLevel.Name = "txtTypeLevel";
      this.txtTypeLevel.Size = new Size(47, 14);
      this.txtTypeLevel.TabIndex = 136;
      this.txtTypeLevel.Text = "txtTypeLevel";
      this.txtTypeLevel.TextAlign = ContentAlignment.TopRight;
      this.txtCharName.BackColor = Color.Transparent;
      this.txtCharName.Font = new Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtCharName.ForeColor = Color.White;
      this.txtCharName.Location = new Point(12, 11);
      this.txtCharName.Name = "txtCharName";
      this.txtCharName.Size = new Size(167, 20);
      this.txtCharName.TabIndex = 137;
      this.txtCharName.Text = "txtCharName";
      this.imgSlot1.BackColor = Color.Transparent;
      this.imgSlot1.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot1.Location = new Point(169, 35);
      this.imgSlot1.Name = "imgSlot1";
      this.imgSlot1.Size = new Size(10, 10);
      this.imgSlot1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot1.TabIndex = 138;
      this.imgSlot1.TabStop = false;
      this.imgSlot2.BackColor = Color.Transparent;
      this.imgSlot2.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot2.Location = new Point(180, 35);
      this.imgSlot2.Name = "imgSlot2";
      this.imgSlot2.Size = new Size(10, 10);
      this.imgSlot2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot2.TabIndex = 139;
      this.imgSlot2.TabStop = false;
      this.imgSlot4.BackColor = Color.Transparent;
      this.imgSlot4.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot4.Location = new Point(202, 35);
      this.imgSlot4.Name = "imgSlot4";
      this.imgSlot4.Size = new Size(10, 10);
      this.imgSlot4.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot4.TabIndex = 141;
      this.imgSlot4.TabStop = false;
      this.imgSlot3.BackColor = Color.Transparent;
      this.imgSlot3.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot3.Location = new Point(191, 35);
      this.imgSlot3.Name = "imgSlot3";
      this.imgSlot3.Size = new Size(10, 10);
      this.imgSlot3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot3.TabIndex = 140;
      this.imgSlot3.TabStop = false;
      this.imgSlot8.BackColor = Color.Transparent;
      this.imgSlot8.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot8.Location = new Point(246, 35);
      this.imgSlot8.Name = "imgSlot8";
      this.imgSlot8.Size = new Size(10, 10);
      this.imgSlot8.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot8.TabIndex = 145;
      this.imgSlot8.TabStop = false;
      this.imgSlot7.BackColor = Color.Transparent;
      this.imgSlot7.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot7.Location = new Point(235, 35);
      this.imgSlot7.Name = "imgSlot7";
      this.imgSlot7.Size = new Size(10, 10);
      this.imgSlot7.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot7.TabIndex = 144;
      this.imgSlot7.TabStop = false;
      this.imgSlot6.BackColor = Color.Transparent;
      this.imgSlot6.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot6.Location = new Point(224, 35);
      this.imgSlot6.Name = "imgSlot6";
      this.imgSlot6.Size = new Size(10, 10);
      this.imgSlot6.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot6.TabIndex = 143;
      this.imgSlot6.TabStop = false;
      this.imgSlot5.BackColor = Color.Transparent;
      this.imgSlot5.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot5.Location = new Point(213, 35);
      this.imgSlot5.Name = "imgSlot5";
      this.imgSlot5.Size = new Size(10, 10);
      this.imgSlot5.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot5.TabIndex = 142;
      this.imgSlot5.TabStop = false;
      this.imgSlot12.BackColor = Color.Transparent;
      this.imgSlot12.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot12.Location = new Point(290, 35);
      this.imgSlot12.Name = "imgSlot12";
      this.imgSlot12.Size = new Size(10, 10);
      this.imgSlot12.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot12.TabIndex = 149;
      this.imgSlot12.TabStop = false;
      this.imgSlot11.BackColor = Color.Transparent;
      this.imgSlot11.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot11.Location = new Point(279, 35);
      this.imgSlot11.Name = "imgSlot11";
      this.imgSlot11.Size = new Size(10, 10);
      this.imgSlot11.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot11.TabIndex = 148;
      this.imgSlot11.TabStop = false;
      this.imgSlot10.BackColor = Color.Transparent;
      this.imgSlot10.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot10.Location = new Point(268, 35);
      this.imgSlot10.Name = "imgSlot10";
      this.imgSlot10.Size = new Size(10, 10);
      this.imgSlot10.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot10.TabIndex = 147;
      this.imgSlot10.TabStop = false;
      this.imgSlot9.BackColor = Color.Transparent;
      this.imgSlot9.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot9.Location = new Point(257, 35);
      this.imgSlot9.Name = "imgSlot9";
      this.imgSlot9.Size = new Size(10, 10);
      this.imgSlot9.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgSlot9.TabIndex = 146;
      this.imgSlot9.TabStop = false;
      this.txtUsedSlots.AutoSize = true;
      this.txtUsedSlots.BackColor = Color.Transparent;
      this.txtUsedSlots.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtUsedSlots.ForeColor = Color.White;
      this.txtUsedSlots.Location = new Point(305, 33);
      this.txtUsedSlots.Name = "txtUsedSlots";
      this.txtUsedSlots.Size = new Size(40, 13);
      this.txtUsedSlots.TabIndex = 150;
      this.txtUsedSlots.Text = "12/12";
      this.txtUsedSlots.TextAlign = ContentAlignment.TopRight;
      this.imgAbilityCost.BackColor = Color.Transparent;
      this.imgAbilityCost.Image = (Image) Resources.TypeAbilities_cost_4;
      this.imgAbilityCost.Location = new Point(182, 205);
      this.imgAbilityCost.Name = "imgAbilityCost";
      this.imgAbilityCost.Size = new Size(43, 10);
      this.imgAbilityCost.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgAbilityCost.TabIndex = 151;
      this.imgAbilityCost.TabStop = false;
      this.notifyIcon1.Text = "notifyIcon1";
      this.notifyIcon1.Visible = true;
      this.btnRemove.BackColor = Color.FromArgb(8, 48, 64);
      this.btnRemove.Cursor = Cursors.Hand;
      this.btnRemove.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnRemove.ForeColor = Color.White;
      this.btnRemove.Location = new Point(239, 162);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(42, 12);
      this.btnRemove.TabIndex = 165;
      this.btnRemove.Text = "remove";
      this.btnRemove.TextAlign = ContentAlignment.TopCenter;
      this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
      this.pictureBox7.BackColor = Color.Transparent;
      this.pictureBox7.BackgroundImage = (Image) Resources.group_box_btm;
      this.pictureBox7.Location = new Point(242, 169);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new Size(40, 10);
      this.pictureBox7.TabIndex = 164;
      this.pictureBox7.TabStop = false;
      this.pictureBox8.BackColor = Color.Transparent;
      this.pictureBox8.BackgroundImage = (Image) Resources.group_box_top;
      this.pictureBox8.Location = new Point(242, 160);
      this.pictureBox8.Name = "pictureBox8";
      this.pictureBox8.Size = new Size(40, 10);
      this.pictureBox8.TabIndex = 163;
      this.pictureBox8.TabStop = false;
      this.pictureBox9.BackColor = Color.Transparent;
      this.pictureBox9.Image = (Image) Resources.group_box_btm_right;
      this.pictureBox9.Location = new Point(278, 169);
      this.pictureBox9.Name = "pictureBox9";
      this.pictureBox9.Size = new Size(10, 10);
      this.pictureBox9.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox9.TabIndex = 162;
      this.pictureBox9.TabStop = false;
      this.pictureBox10.BackColor = Color.Transparent;
      this.pictureBox10.Image = (Image) Resources.group_box_top_right;
      this.pictureBox10.Location = new Point(278, 160);
      this.pictureBox10.Name = "pictureBox10";
      this.pictureBox10.Size = new Size(10, 10);
      this.pictureBox10.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox10.TabIndex = 161;
      this.pictureBox10.TabStop = false;
      this.pictureBox11.BackColor = Color.Transparent;
      this.pictureBox11.Image = (Image) Resources.group_box_btm_left;
      this.pictureBox11.Location = new Point(233, 169);
      this.pictureBox11.Name = "pictureBox11";
      this.pictureBox11.Size = new Size(10, 10);
      this.pictureBox11.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox11.TabIndex = 160;
      this.pictureBox11.TabStop = false;
      this.pictureBox12.BackColor = Color.Transparent;
      this.pictureBox12.Image = (Image) Resources.group_box_top_left;
      this.pictureBox12.Location = new Point(233, 160);
      this.pictureBox12.Name = "pictureBox12";
      this.pictureBox12.Size = new Size(10, 10);
      this.pictureBox12.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox12.TabIndex = 159;
      this.pictureBox12.TabStop = false;
      this.btnChange.BackColor = Color.FromArgb(8, 48, 64);
      this.btnChange.Cursor = Cursors.Hand;
      this.btnChange.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnChange.ForeColor = Color.White;
      this.btnChange.Location = new Point(239, 142);
      this.btnChange.Name = "btnChange";
      this.btnChange.Size = new Size(42, 12);
      this.btnChange.TabIndex = 172;
      this.btnChange.Text = "add";
      this.btnChange.TextAlign = ContentAlignment.TopCenter;
      this.btnChange.Click += new EventHandler(this.btnChange_Click);
      this.pictureBox13.BackColor = Color.Transparent;
      this.pictureBox13.BackgroundImage = (Image) Resources.group_box_btm;
      this.pictureBox13.Location = new Point(242, 149);
      this.pictureBox13.Name = "pictureBox13";
      this.pictureBox13.Size = new Size(40, 10);
      this.pictureBox13.TabIndex = 171;
      this.pictureBox13.TabStop = false;
      this.pictureBox14.BackColor = Color.Transparent;
      this.pictureBox14.BackgroundImage = (Image) Resources.group_box_top;
      this.pictureBox14.Location = new Point(242, 140);
      this.pictureBox14.Name = "pictureBox14";
      this.pictureBox14.Size = new Size(40, 10);
      this.pictureBox14.TabIndex = 170;
      this.pictureBox14.TabStop = false;
      this.pictureBox15.BackColor = Color.Transparent;
      this.pictureBox15.Image = (Image) Resources.group_box_btm_right;
      this.pictureBox15.Location = new Point(278, 149);
      this.pictureBox15.Name = "pictureBox15";
      this.pictureBox15.Size = new Size(10, 10);
      this.pictureBox15.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox15.TabIndex = 169;
      this.pictureBox15.TabStop = false;
      this.pictureBox16.BackColor = Color.Transparent;
      this.pictureBox16.Image = (Image) Resources.group_box_top_right;
      this.pictureBox16.Location = new Point(278, 140);
      this.pictureBox16.Name = "pictureBox16";
      this.pictureBox16.Size = new Size(10, 10);
      this.pictureBox16.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox16.TabIndex = 168;
      this.pictureBox16.TabStop = false;
      this.pictureBox17.BackColor = Color.Transparent;
      this.pictureBox17.Image = (Image) Resources.group_box_btm_left;
      this.pictureBox17.Location = new Point(233, 149);
      this.pictureBox17.Name = "pictureBox17";
      this.pictureBox17.Size = new Size(10, 10);
      this.pictureBox17.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox17.TabIndex = 167;
      this.pictureBox17.TabStop = false;
      this.pictureBox18.BackColor = Color.Transparent;
      this.pictureBox18.Image = (Image) Resources.group_box_top_left;
      this.pictureBox18.Location = new Point(233, 140);
      this.pictureBox18.Name = "pictureBox18";
      this.pictureBox18.Size = new Size(10, 10);
      this.pictureBox18.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox18.TabIndex = 166;
      this.pictureBox18.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.None;
      this.ClientSize = new Size(480, 310);
      this.Controls.Add((Control) this.btnChange);
      this.Controls.Add((Control) this.pictureBox13);
      this.Controls.Add((Control) this.pictureBox14);
      this.Controls.Add((Control) this.pictureBox15);
      this.Controls.Add((Control) this.pictureBox16);
      this.Controls.Add((Control) this.pictureBox17);
      this.Controls.Add((Control) this.pictureBox18);
      this.Controls.Add((Control) this.btnRemove);
      this.Controls.Add((Control) this.pictureBox7);
      this.Controls.Add((Control) this.pictureBox8);
      this.Controls.Add((Control) this.pictureBox9);
      this.Controls.Add((Control) this.pictureBox10);
      this.Controls.Add((Control) this.pictureBox11);
      this.Controls.Add((Control) this.pictureBox12);
      this.Controls.Add((Control) this.imgAbilityCost);
      this.Controls.Add((Control) this.txtUsedSlots);
      this.Controls.Add((Control) this.imgSlot12);
      this.Controls.Add((Control) this.imgSlot11);
      this.Controls.Add((Control) this.imgSlot10);
      this.Controls.Add((Control) this.imgSlot9);
      this.Controls.Add((Control) this.imgSlot8);
      this.Controls.Add((Control) this.imgSlot7);
      this.Controls.Add((Control) this.imgSlot6);
      this.Controls.Add((Control) this.imgSlot5);
      this.Controls.Add((Control) this.imgSlot4);
      this.Controls.Add((Control) this.imgSlot3);
      this.Controls.Add((Control) this.imgSlot2);
      this.Controls.Add((Control) this.imgSlot1);
      this.Controls.Add((Control) this.txtCharName);
      this.Controls.Add((Control) this.txtTypeLevel);
      this.Controls.Add((Control) this.txtTypeName);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.txtAbilityDesc);
      this.Controls.Add((Control) this.txtAbilityName);
      this.Controls.Add((Control) this.txtAbilityName_jp);
      this.Controls.Add((Control) this.listViewAbilities);
      this.DoubleBuffered = true;
      this.ForeColor = SystemColors.ActiveCaptionText;
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(490, 342);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(490, 342);
      this.Name = nameof (pspo2seTypeAbilitiesForm);
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "PSPo2 Type Abilities Editor";
      this.Load += new EventHandler(this.pspo2seTypeAbilitiesForm_Load);
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
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public pspo2seForm.jobClass[] oldJobs
    {
      get => this.oldJobInfo;
      set => this.oldJobInfo = value;
    }

    public pspo2seForm.jobClass newJob
    {
      get => this.newJobInfo;
      set => this.newJobInfo = value;
    }

    public pspo2seForm.jobType selectedJob
    {
      get => this.selected_job;
      set => this.selected_job = value;
    }

    public int max_abilities
    {
      get => this.parent_max_abilities;
      set => this.parent_max_abilities = value;
    }

    public string character_name
    {
      get => this.char_name;
      set => this.char_name = value;
    }

    public pspo2seAbilityDb abilityDb
    {
      get => this.parentsAbilityDb;
      set => this.parentsAbilityDb = value;
    }

    public pspo2seForm.SaveType saveType
    {
      get => this.save_type;
      set => this.save_type = value;
    }

    public pspo2seTypeAbilitiesForm()
    {
      this.InitializeComponent();
      this.radioBtnReal.Checked = true;
      this.radioBtnFake.Checked = false;
    }

    public void loadCurrentTypeInformation()
    {
      if (this.oldJobs[(int) this.selected_job] == null)
      {
        int num = (int) MessageBox.Show("Current job information was not set");
        this.DialogResult = DialogResult.Cancel;
        this.Dispose();
      }
      else
      {
        this.newJob = this.oldJobs[(int) this.selected_job];
        this.listTypeAbilities();
        this.txtTypeName.Text = this.newJob.job.ToString();
        this.txtTypeLevel.Text = "LV" + (object) this.newJob.level;
      }
    }

    private void resetTypeAbilitySlots()
    {
      this.imgSlot1.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot2.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot3.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot4.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot5.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot6.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot7.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot8.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot9.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot10.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot11.Image = (Image) Resources.TypeAbilitiesFree;
      this.imgSlot12.Image = (Image) Resources.TypeAbilitiesFree;
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

    private void allowedAbilitySlotsLogic()
    {
      this.allowedSlots = 4;
      int num = this.newJob.level;
      if (!this.legitMode)
        num = this.saveType != pspo2seForm.SaveType.PSP2I ? 30 : 31;
      for (int index = 1; index <= num; ++index)
      {
        switch (index)
        {
          case 5:
            this.imgSlot5.Visible = true;
            ++this.allowedSlots;
            break;
          case 10:
            this.imgSlot6.Visible = true;
            ++this.allowedSlots;
            break;
          case 15:
            this.imgSlot7.Visible = true;
            ++this.allowedSlots;
            break;
          case 20:
            this.imgSlot8.Visible = true;
            ++this.allowedSlots;
            break;
          case 31:
            this.imgSlot9.Visible = true;
            this.imgSlot10.Visible = true;
            this.imgSlot11.Visible = true;
            this.imgSlot12.Visible = true;
            this.allowedSlots = 12;
            break;
        }
      }
    }

    private void usedSlotsLogic()
    {
      this.allowEdit = true;
      this.usedSlots = 0;
      if (!this.legitMode)
      {
        this.allowedSlots = this.saveType != pspo2seForm.SaveType.PSP2I ? 8 : 12;
        this.usedSlots = this.allowedSlots;
        for (int index = 0; index < this.listOfAbilitiesSlotCount; ++index)
        {
          if (this.listOfAbilities[index].name == "No Ability")
            --this.usedSlots;
        }
      }
      else
      {
        for (int index = 0; index < this.listViewAbilities.Items.Count; ++index)
        {
          pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = this.abilityDb.findAbilityInDb(this.listViewAbilities.Items[index].SubItems[2].Text);
          if (this.saveType == pspo2seForm.SaveType.PSP2I)
          {
            abilityInDb.slots = abilityInDb.slots_inf;
            abilityInDb.hu_lvl = abilityInDb.hu_lvl_inf;
            abilityInDb.ra_lvl = abilityInDb.ra_lvl_inf;
            abilityInDb.fo_lvl = abilityInDb.fo_lvl_inf;
            abilityInDb.va_lvl = abilityInDb.va_lvl_inf;
          }
          if (abilityInDb.slots > 0)
            this.usedSlots += abilityInDb.slots;
          else if (abilityInDb.name != "No Ability")
          {
            int num = (int) MessageBox.Show("You have an ability equipped with unknown slot costs\r\nYou will be unable to add abilities at the moment\r\nbut you can still remove the unknown ability.\r\n\r\nPlease wait for a future abilities database update\r\nfor full functionality\r\n\r\nThe offending ability is " + abilityInDb.name + " [" + abilityInDb.hex + "]", "Database Info Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.allowEdit = false;
            this.usedSlots = 0;
            break;
          }
        }
      }
      for (int index = 1; index <= this.usedSlots; ++index)
      {
        switch (index)
        {
          case 1:
            this.imgSlot1.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 2:
            this.imgSlot2.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 3:
            this.imgSlot3.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 4:
            this.imgSlot4.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 5:
            this.imgSlot5.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 6:
            this.imgSlot6.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 7:
            this.imgSlot7.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 8:
            this.imgSlot8.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 9:
            this.imgSlot9.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 10:
            this.imgSlot10.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 11:
            this.imgSlot11.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
          case 12:
            this.imgSlot12.Image = (Image) Resources.TypeAbilitiesUsed;
            break;
        }
      }
    }

    private void typeAbilitySlotLogic()
    {
      this.resetTypeAbilitySlots();
      this.allowedAbilitySlotsLogic();
      this.usedSlotsLogic();
      if (!this.allowEdit)
        this.txtUsedSlots.Text = "unk_/" + (object) this.allowedSlots;
      else
        this.txtUsedSlots.Text = this.usedSlots.ToString() + "/" + (object) this.allowedSlots;
    }

    private void listTypeAbilities()
    {
      this.chkListAll.Visible = false;
      this.view = pspo2seTypeAbilitiesForm.viewType.equipped;
      this.btnChange.Text = "add";
      this.btnRemove.Text = "remove";
      this.listViewAbilities.Items.Clear();
      this.listOfAbilitiesSlotCount = 0;
      for (int index = 0; index < this.max_abilities; ++index)
      {
        pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = this.abilityDb.findAbilityInDb(this.newJob.attachedAbilities.Substring(index * 2, 2));
        if (abilityInDb.name == "")
          abilityInDb.name = abilityInDb.name_jp;
        if (abilityInDb.hex != "")
        {
          if (this.saveType == pspo2seForm.SaveType.PSP2I)
            abilityInDb.slots = abilityInDb.slots_inf;
          if (abilityInDb.slots != 0)
          {
            ListViewItem listViewItem = !this.legitMode ? new ListViewItem("1", 0) : new ListViewItem(string.Concat((object) abilityInDb.slots), 0);
            listViewItem.SubItems.Add(abilityInDb.name);
            listViewItem.SubItems.Add(abilityInDb.hex);
            this.listViewAbilities.Items.Add(listViewItem);
          }
          this.listOfAbilities[this.listOfAbilitiesSlotCount] = new pspo2seTypeAbilitiesForm.abilitySlotsType();
          this.listOfAbilities[this.listOfAbilitiesSlotCount].hex = abilityInDb.hex;
          this.listOfAbilities[this.listOfAbilitiesSlotCount].name = abilityInDb.name;
          ++this.listOfAbilitiesSlotCount;
        }
      }
      this.txtAbilityName.Text = this.newJob.attachedAbilities;
      this.txtCharName.Text = this.character_name;
      this.typeAbilitySlotLogic();
      this.showSelectedAbility();
    }

    private void listAvailableTypeAbilities()
    {
      if (Program.form.legitVersion())
        this.chkListAll.Visible = false;
      else
        this.chkListAll.Visible = true;
      this.view = pspo2seTypeAbilitiesForm.viewType.available;
      this.btnChange.Text = "apply";
      this.btnRemove.Text = "cancel";
      this.listViewAbilities.Items.Clear();
      this.listOfAbilitiesSlotCount = 0;
      for (int index = 0; index < this.abilityDb.ability_db_filled; ++index)
      {
        pspo2seAbilityDb.abilityDb_AbilitiyClass abilityDbAbilitiyClass = this.abilityDb.ability_db.ability[index];
        if (this.saveType == pspo2seForm.SaveType.PSP2I)
        {
          abilityDbAbilitiyClass.slots = abilityDbAbilitiyClass.slots_inf;
          abilityDbAbilitiyClass.hu_lvl = abilityDbAbilitiyClass.hu_lvl_inf;
          abilityDbAbilitiyClass.ra_lvl = abilityDbAbilitiyClass.ra_lvl_inf;
          abilityDbAbilitiyClass.fo_lvl = abilityDbAbilitiyClass.fo_lvl_inf;
          abilityDbAbilitiyClass.va_lvl = abilityDbAbilitiyClass.va_lvl_inf;
        }
        if (abilityDbAbilitiyClass.name == "")
          abilityDbAbilitiyClass.name = abilityDbAbilitiyClass.name_jp;
        if (abilityDbAbilitiyClass.hex != "")
        {
          bool flag = false;
          if (abilityDbAbilitiyClass.slots != 0)
          {
            if (!this.canFindAbilityInAttached(abilityDbAbilitiyClass.hex))
            {
              if (!this.chkListAll.Checked)
              {
                if (abilityDbAbilitiyClass.hu_lvl <= this.oldJobs[0].level && abilityDbAbilitiyClass.hu_lvl > 0 || abilityDbAbilitiyClass.ra_lvl <= this.oldJobs[1].level && abilityDbAbilitiyClass.ra_lvl > 0 || (abilityDbAbilitiyClass.fo_lvl <= this.oldJobs[2].level && abilityDbAbilitiyClass.fo_lvl > 0 || abilityDbAbilitiyClass.va_lvl <= this.oldJobs[3].level && abilityDbAbilitiyClass.va_lvl > 0) || abilityDbAbilitiyClass.hu_lvl == 0 && abilityDbAbilitiyClass.ra_lvl == 0 && (abilityDbAbilitiyClass.fo_lvl == 0 && abilityDbAbilitiyClass.va_lvl == 0))
                  flag = true;
              }
              else
                flag = true;
            }
            if (flag)
            {
              ListViewItem listViewItem = !this.legitMode ? new ListViewItem("1", 0) : new ListViewItem(string.Concat((object) abilityDbAbilitiyClass.slots), 0);
              listViewItem.SubItems.Add(abilityDbAbilitiyClass.name);
              listViewItem.SubItems.Add(abilityDbAbilitiyClass.hex);
              this.listViewAbilities.Items.Add(listViewItem);
            }
          }
          this.listOfAbilities[this.listOfAbilitiesSlotCount] = new pspo2seTypeAbilitiesForm.abilitySlotsType();
          this.listOfAbilities[this.listOfAbilitiesSlotCount].hex = abilityDbAbilitiyClass.hex;
          this.listOfAbilities[this.listOfAbilitiesSlotCount].name = abilityDbAbilitiyClass.name;
          this.listOfAbilities[this.listOfAbilitiesSlotCount].valid = flag;
          ++this.listOfAbilitiesSlotCount;
        }
      }
      this.txtAbilityName.Text = this.newJob.attachedAbilities;
      this.txtCharName.Text = this.character_name;
      this.showSelectedAbility();
    }

    public void showSelectedAbility()
    {
      pspo2seAbilityDb.abilityDb_AbilitiyClass abilityDbAbilitiyClass = new pspo2seAbilityDb.abilityDb_AbilitiyClass();
      if (this.listViewAbilities.SelectedItems.Count == 0)
      {
        if (this.listViewAbilities.Items.Count > 0)
        {
          this.listViewAbilities.Items[0].Selected = true;
          abilityDbAbilitiyClass = this.abilityDb.findAbilityInDb(this.listViewAbilities.Items[0].SubItems[2].Text);
        }
      }
      else
        abilityDbAbilitiyClass = this.abilityDb.findAbilityInDb(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
      this.txtAbilityName.Text = abilityDbAbilitiyClass.name;
      this.txtAbilityName_jp.Text = abilityDbAbilitiyClass.name_jp;
      this.txtAbilityDesc.Text = abilityDbAbilitiyClass.desc;
      this.imgAbilityCost.Visible = true;
      switch (abilityDbAbilitiyClass.slots)
      {
        case 1:
          this.imgAbilityCost.Image = (Image) Resources.TypeAbilities_cost_1;
          break;
        case 2:
          this.imgAbilityCost.Image = (Image) Resources.TypeAbilities_cost_2;
          break;
        case 3:
          this.imgAbilityCost.Image = (Image) Resources.TypeAbilities_cost_3;
          break;
        case 4:
          this.imgAbilityCost.Image = (Image) Resources.TypeAbilities_cost_4;
          break;
        default:
          this.imgAbilityCost.Visible = false;
          break;
      }
    }

    private void listViewAbilities_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listViewAbilities.SelectedItems.Count <= 0)
        return;
      this.showSelectedAbility();
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

    private void radioBtnReal_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioBtnReal.Checked)
        return;
      this.legitMode = true;
      this.listTypeAbilities();
      this.typeAbilitySlotLogic();
    }

    private void radioBtnFake_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioBtnFake.Checked)
        return;
      this.legitMode = false;
      this.listTypeAbilities();
      this.typeAbilitySlotLogic();
    }

    private int findAbilityPos(string hex)
    {
      for (int index = 0; index < this.max_abilities; ++index)
      {
        if (this.newJob.attachedAbilities.Substring(index * 2, 2) == hex)
          return index * 2;
      }
      int num = (int) MessageBox.Show("Fatal Error!\r\nThe selected ability " + hex + " was not found in the attached abilities\r\n" + this.newJob.attachedAbilities);
      return 0;
    }

    private bool canFindAbilityInAttached(string hex)
    {
      for (int index = 0; index < this.max_abilities; ++index)
      {
        if (this.newJob.attachedAbilities.Substring(index * 2, 2) == hex)
          return true;
      }
      return false;
    }

    private void removeAbility(string hex)
    {
      int abilityPos = this.findAbilityPos(hex);
      string str1 = this.newJob.attachedAbilities.Substring(0, abilityPos);
      string str2 = this.newJob.attachedAbilities.Substring(abilityPos + 2, this.newJob.attachedAbilities.Length - str1.Length - 2);
      this.newJob.attachedAbilities = str1 + "00" + str2;
      this.listTypeAbilities();
    }

    private void addAbility(string hex)
    {
      int abilityPos = this.findAbilityPos("00");
      string str1 = this.newJob.attachedAbilities.Substring(0, abilityPos);
      string str2 = this.newJob.attachedAbilities.Substring(abilityPos + 2, this.newJob.attachedAbilities.Length - str1.Length - 2);
      this.newJob.attachedAbilities = str1 + hex + str2;
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.view == pspo2seTypeAbilitiesForm.viewType.equipped)
      {
        if (this.listViewAbilities.SelectedItems.Count > 0)
        {
          this.removeAbility(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
        }
        else
        {
          int num = (int) MessageBox.Show("Please select an ability to remove", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      else
        this.listTypeAbilities();
    }

    private void btnChange_Click(object sender, EventArgs e)
    {
      bool flag = false;
      if (this.view == pspo2seTypeAbilitiesForm.viewType.equipped)
      {
        if (!this.allowEdit)
        {
          int num1 = (int) MessageBox.Show("You must remove any unknown abilities first!\r\nPlease wait for a database update for better functionality", "Unknown ability detected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else if (this.usedSlots >= this.allowedSlots)
        {
          if (Program.form.legitVersion())
          {
            int num2 = (int) MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          else if (this.radioBtnFake.Checked)
          {
            int num3 = (int) MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          else
          {
            int num4 = (int) MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one\r\nor you can click to fake the slots", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        else
          this.listAvailableTypeAbilities();
      }
      else
      {
        pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = this.abilityDb.findAbilityInDb(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
        if (this.legitMode)
        {
          if (this.usedSlots + abilityInDb.slots <= this.allowedSlots)
            flag = true;
        }
        else if (this.allowedSlots > this.usedSlots)
          flag = true;
        if (flag)
        {
          this.addAbility(abilityInDb.hex);
          this.listTypeAbilities();
        }
        else
        {
          int num5 = (int) MessageBox.Show("You do not have enough slots for that ability", "Mamimum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
    }

    private void chkListAll_CheckedChanged(object sender, EventArgs e) => this.listAvailableTypeAbilities();

    private enum viewType
    {
      equipped,
      available,
    }

    private class abilitySlotsType
    {
      public bool valid;
      public string hex = "";
      public string name = "";
    }
  }
}
