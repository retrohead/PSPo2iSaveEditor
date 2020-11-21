// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.weaponDbForm
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using pspo2seSaveEditorProgram.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
  public class weaponDbForm : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private ListView dropListView;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private Panel pnlDropList;
    private PictureBox pictureBox3;
    private PictureBox pictureBox1;
    private PictureBox pictureBox8;
    private PictureBox pictureBox7;
    private PictureBox pictureBox6;
    private PictureBox pictureBox5;
    private ImageList weaponTypesImageList;
    private Label txtWeaponType;
    private PictureBox dropListWeaponType;
    private PictureBox imgDropListWeaponType;
    private PictureBox dropListManufacturer;
    private ImageList manufacturerImageList;
    private PictureBox imgDropListManufacturer;
    private Label txtManufacturer;
    private ImageList rankImageList;
    private Label txtSelectedWeaponType;
    private Label txtSelectedManufacturer;
    private CheckBox chkUnknownWeapons;
    private Button btnClearFilters;
    private Button btnExit;
    private Label txtItemHex;
    private Label txtInventoryLevel;
    private Label txtInventoryACC;
    private Label txtInventoryATK;
    private Label txtInventoryEffect;
    private Label txtInventorySpecial;
    private PictureBox imgInventoryRank;
    private PictureBox imgStar15;
    private PictureBox imgStar14;
    private PictureBox imgStar13;
    private PictureBox imgStar12;
    private PictureBox imgStar11;
    private PictureBox imgStar10;
    private PictureBox imgStar9;
    private PictureBox imgStar8;
    private PictureBox imgStar7;
    private PictureBox imgStar6;
    private PictureBox imgStar5;
    private PictureBox imgStar4;
    private PictureBox imgStar3;
    private PictureBox imgStar2;
    private PictureBox imgStar1;
    private PictureBox imgStar0;
    private PictureBox imgInventoryWeaponManufacturer;
    private Label txtInventoryGrinds;
    private Label txtInventoryName_jp;
    private PictureBox imgInventoryElement;
    private Label txtInventoryPercent;
    private Label txtInventoryQty;
    private PictureBox imgInventoryItemIcon;
    private Label txtInventoryName;
    private Label txtInventoryInfinityItemText;
    private PictureBox imgInventoryInfinityItem;
    private Panel pnlItemDetails;
    private Label txtSelectedHex;
    private Button btnExport;
    private PictureBox imgDropListWeapon;
    private PictureBox dropListWeapon;
    private Label txtWeapon;
    private Label txtSelectedWeapon;
    private Panel pnlDebug;
    private PictureBox picWeapon;
    private pspo2seForm parent;
    private pspo2seForm.itemDb_ItemClass[] dbLink = new pspo2seForm.itemDb_ItemClass[4000];
    private int dbLinkCount;
    private weaponDbForm.dropListType selectedDropList;
    private string hex = "";

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (weaponDbForm));
      this.groupBox1 = new GroupBox();
      this.btnExport = new Button();
      this.chkUnknownWeapons = new CheckBox();
      this.btnClearFilters = new Button();
      this.btnExit = new Button();
      this.weaponTypesImageList = new ImageList(this.components);
      this.pnlDropList = new Panel();
      this.dropListView = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.pictureBox8 = new PictureBox();
      this.pictureBox7 = new PictureBox();
      this.pictureBox6 = new PictureBox();
      this.pictureBox5 = new PictureBox();
      this.pictureBox3 = new PictureBox();
      this.pictureBox1 = new PictureBox();
      this.txtWeaponType = new Label();
      this.dropListWeaponType = new PictureBox();
      this.imgDropListWeaponType = new PictureBox();
      this.dropListManufacturer = new PictureBox();
      this.manufacturerImageList = new ImageList(this.components);
      this.imgDropListManufacturer = new PictureBox();
      this.txtManufacturer = new Label();
      this.rankImageList = new ImageList(this.components);
      this.txtSelectedWeaponType = new Label();
      this.txtSelectedManufacturer = new Label();
      this.txtItemHex = new Label();
      this.txtInventoryLevel = new Label();
      this.txtInventoryACC = new Label();
      this.txtInventoryATK = new Label();
      this.txtInventoryEffect = new Label();
      this.txtInventorySpecial = new Label();
      this.imgInventoryRank = new PictureBox();
      this.imgStar15 = new PictureBox();
      this.imgStar14 = new PictureBox();
      this.imgStar13 = new PictureBox();
      this.imgStar12 = new PictureBox();
      this.imgStar11 = new PictureBox();
      this.imgStar10 = new PictureBox();
      this.imgStar9 = new PictureBox();
      this.imgStar8 = new PictureBox();
      this.imgStar7 = new PictureBox();
      this.imgStar6 = new PictureBox();
      this.imgStar5 = new PictureBox();
      this.imgStar4 = new PictureBox();
      this.imgStar3 = new PictureBox();
      this.imgStar2 = new PictureBox();
      this.imgStar1 = new PictureBox();
      this.imgStar0 = new PictureBox();
      this.imgInventoryWeaponManufacturer = new PictureBox();
      this.txtInventoryGrinds = new Label();
      this.txtInventoryName_jp = new Label();
      this.imgInventoryElement = new PictureBox();
      this.txtInventoryPercent = new Label();
      this.txtInventoryQty = new Label();
      this.imgInventoryItemIcon = new PictureBox();
      this.txtInventoryName = new Label();
      this.txtInventoryInfinityItemText = new Label();
      this.imgInventoryInfinityItem = new PictureBox();
      this.pnlItemDetails = new Panel();
      this.txtSelectedHex = new Label();
      this.imgDropListWeapon = new PictureBox();
      this.dropListWeapon = new PictureBox();
      this.txtWeapon = new Label();
      this.txtSelectedWeapon = new Label();
      this.pnlDebug = new Panel();
      this.picWeapon = new PictureBox();
      this.groupBox1.SuspendLayout();
      this.pnlDropList.SuspendLayout();
      ((ISupportInitialize) this.pictureBox8).BeginInit();
      ((ISupportInitialize) this.pictureBox7).BeginInit();
      ((ISupportInitialize) this.pictureBox6).BeginInit();
      ((ISupportInitialize) this.pictureBox5).BeginInit();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.dropListWeaponType).BeginInit();
      ((ISupportInitialize) this.imgDropListWeaponType).BeginInit();
      ((ISupportInitialize) this.dropListManufacturer).BeginInit();
      ((ISupportInitialize) this.imgDropListManufacturer).BeginInit();
      ((ISupportInitialize) this.imgInventoryRank).BeginInit();
      ((ISupportInitialize) this.imgStar15).BeginInit();
      ((ISupportInitialize) this.imgStar14).BeginInit();
      ((ISupportInitialize) this.imgStar13).BeginInit();
      ((ISupportInitialize) this.imgStar12).BeginInit();
      ((ISupportInitialize) this.imgStar11).BeginInit();
      ((ISupportInitialize) this.imgStar10).BeginInit();
      ((ISupportInitialize) this.imgStar9).BeginInit();
      ((ISupportInitialize) this.imgStar8).BeginInit();
      ((ISupportInitialize) this.imgStar7).BeginInit();
      ((ISupportInitialize) this.imgStar6).BeginInit();
      ((ISupportInitialize) this.imgStar5).BeginInit();
      ((ISupportInitialize) this.imgStar4).BeginInit();
      ((ISupportInitialize) this.imgStar3).BeginInit();
      ((ISupportInitialize) this.imgStar2).BeginInit();
      ((ISupportInitialize) this.imgStar1).BeginInit();
      ((ISupportInitialize) this.imgStar0).BeginInit();
      ((ISupportInitialize) this.imgInventoryWeaponManufacturer).BeginInit();
      ((ISupportInitialize) this.imgInventoryElement).BeginInit();
      ((ISupportInitialize) this.imgInventoryItemIcon).BeginInit();
      ((ISupportInitialize) this.imgInventoryInfinityItem).BeginInit();
      this.pnlItemDetails.SuspendLayout();
      ((ISupportInitialize) this.imgDropListWeapon).BeginInit();
      ((ISupportInitialize) this.dropListWeapon).BeginInit();
      this.pnlDebug.SuspendLayout();
      ((ISupportInitialize) this.picWeapon).BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.btnExport);
      this.groupBox1.Controls.Add((Control) this.chkUnknownWeapons);
      this.groupBox1.Controls.Add((Control) this.btnClearFilters);
      this.groupBox1.Controls.Add((Control) this.btnExit);
      this.groupBox1.Location = new Point(-21, 272);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(512, 46);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.btnExport.Cursor = Cursors.Hand;
      this.btnExport.DialogResult = DialogResult.Cancel;
      this.btnExport.Location = new Point(346, 11);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(75, 23);
      this.btnExport.TabIndex = 3;
      this.btnExport.Text = "export";
      this.btnExport.UseVisualStyleBackColor = true;
      this.btnExport.Click += new EventHandler(this.btnExport_Click);
      this.chkUnknownWeapons.AutoSize = true;
      this.chkUnknownWeapons.Cursor = Cursors.Hand;
      this.chkUnknownWeapons.Location = new Point(106, 14);
      this.chkUnknownWeapons.Name = "chkUnknownWeapons";
      this.chkUnknownWeapons.Size = new Size(140, 17);
      this.chkUnknownWeapons.TabIndex = 2;
      this.chkUnknownWeapons.Text = "List Unknown Weapons";
      this.chkUnknownWeapons.UseVisualStyleBackColor = true;
      this.chkUnknownWeapons.CheckedChanged += new EventHandler(this.chkUnknownWeapons_CheckedChanged);
      this.btnClearFilters.Cursor = Cursors.Hand;
      this.btnClearFilters.Location = new Point(25, 10);
      this.btnClearFilters.Name = "btnClearFilters";
      this.btnClearFilters.Size = new Size(75, 23);
      this.btnClearFilters.TabIndex = 1;
      this.btnClearFilters.Text = "clear filters";
      this.btnClearFilters.UseVisualStyleBackColor = true;
      this.btnClearFilters.Click += new EventHandler(this.btnClearFilters_Click);
      this.btnExit.Cursor = Cursors.Hand;
      this.btnExit.DialogResult = DialogResult.Cancel;
      this.btnExit.Location = new Point(421, 11);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new Size(75, 23);
      this.btnExit.TabIndex = 0;
      this.btnExit.Text = "exit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new EventHandler(this.btnExit_Click);
      this.weaponTypesImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("weaponTypesImageList.ImageStream");
      this.weaponTypesImageList.TransparentColor = Color.Transparent;
      this.weaponTypesImageList.Images.SetKeyName(0, "sword.png");
      this.weaponTypesImageList.Images.SetKeyName(1, "knuckles.png");
      this.weaponTypesImageList.Images.SetKeyName(2, "spear.png");
      this.weaponTypesImageList.Images.SetKeyName(3, "double_saber.png");
      this.weaponTypesImageList.Images.SetKeyName(4, "axe.png");
      this.weaponTypesImageList.Images.SetKeyName(5, "sabers.png");
      this.weaponTypesImageList.Images.SetKeyName(6, "daggers.png");
      this.weaponTypesImageList.Images.SetKeyName(7, "claws.png");
      this.weaponTypesImageList.Images.SetKeyName(8, "saber.png");
      this.weaponTypesImageList.Images.SetKeyName(9, "dagger.png");
      this.weaponTypesImageList.Images.SetKeyName(10, "claw.png");
      this.weaponTypesImageList.Images.SetKeyName(11, "whip.png");
      this.weaponTypesImageList.Images.SetKeyName(12, "slicer.png");
      this.weaponTypesImageList.Images.SetKeyName(13, "rifle.png");
      this.weaponTypesImageList.Images.SetKeyName(14, "shotgun.png");
      this.weaponTypesImageList.Images.SetKeyName(15, "longbow.png");
      this.weaponTypesImageList.Images.SetKeyName(16, "grenade.png");
      this.weaponTypesImageList.Images.SetKeyName(17, "laser.png");
      this.weaponTypesImageList.Images.SetKeyName(18, "handguns.png");
      this.weaponTypesImageList.Images.SetKeyName(19, "handgun.png");
      this.weaponTypesImageList.Images.SetKeyName(20, "crossbow.png");
      this.weaponTypesImageList.Images.SetKeyName(21, "cards.png");
      this.weaponTypesImageList.Images.SetKeyName(22, "machinegun.png");
      this.weaponTypesImageList.Images.SetKeyName(23, "rod.png");
      this.weaponTypesImageList.Images.SetKeyName(24, "wand.png");
      this.weaponTypesImageList.Images.SetKeyName(25, "tmag.png");
      this.weaponTypesImageList.Images.SetKeyName(26, "rmag.png");
      this.weaponTypesImageList.Images.SetKeyName(27, "shield.png");
      this.pnlDropList.BackColor = Color.Transparent;
      this.pnlDropList.Controls.Add((Control) this.dropListView);
      this.pnlDropList.Controls.Add((Control) this.pictureBox8);
      this.pnlDropList.Controls.Add((Control) this.pictureBox7);
      this.pnlDropList.Controls.Add((Control) this.pictureBox6);
      this.pnlDropList.Controls.Add((Control) this.pictureBox5);
      this.pnlDropList.Controls.Add((Control) this.pictureBox3);
      this.pnlDropList.Controls.Add((Control) this.pictureBox1);
      this.pnlDropList.Location = new Point(425, 12);
      this.pnlDropList.Name = "pnlDropList";
      this.pnlDropList.Size = new Size(220, 128);
      this.pnlDropList.TabIndex = 86;
      this.pnlDropList.Visible = false;
      this.dropListView.BackColor = SystemColors.Control;
      this.dropListView.BackgroundImage = (Image) Resources.TypeAbilitiesListBg;
      this.dropListView.BackgroundImageTiled = true;
      this.dropListView.BorderStyle = BorderStyle.None;
      this.dropListView.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader1,
        this.columnHeader2
      });
      this.dropListView.Cursor = Cursors.Hand;
      this.dropListView.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dropListView.ForeColor = Color.White;
      this.dropListView.FullRowSelect = true;
      this.dropListView.HeaderStyle = ColumnHeaderStyle.None;
      this.dropListView.HideSelection = false;
      this.dropListView.LabelWrap = false;
      this.dropListView.Location = new Point(6, 2);
      this.dropListView.MultiSelect = false;
      this.dropListView.Name = "dropListView";
      this.dropListView.Size = new Size(212, 124);
      this.dropListView.SmallImageList = this.weaponTypesImageList;
      this.dropListView.TabIndex = 85;
      this.dropListView.UseCompatibleStateImageBehavior = false;
      this.dropListView.View = View.Details;
      this.dropListView.SelectedIndexChanged += new EventHandler(this.dropListView_SelectedIndexChanged);
      this.dropListView.Click += new EventHandler(this.dropListView_Click);
      this.columnHeader1.Width = 190;
      this.columnHeader2.Width = 0;
      this.pictureBox8.Anchor = AnchorStyles.Right;
      this.pictureBox8.BackgroundImage = (Image) Resources.group_box_right;
      this.pictureBox8.Location = new Point(210, 2);
      this.pictureBox8.Name = "pictureBox8";
      this.pictureBox8.Size = new Size(10, 124);
      this.pictureBox8.TabIndex = 89;
      this.pictureBox8.TabStop = false;
      this.pictureBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox7.BackgroundImage = (Image) Resources.group_box_left;
      this.pictureBox7.Location = new Point(0, 9);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new Size(10, 110);
      this.pictureBox7.TabIndex = 88;
      this.pictureBox7.TabStop = false;
      this.pictureBox6.BackgroundImage = (Image) Resources.group_box_btm;
      this.pictureBox6.Location = new Point(5, 118);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new Size(215, 10);
      this.pictureBox6.TabIndex = 87;
      this.pictureBox6.TabStop = false;
      this.pictureBox5.BackgroundImage = (Image) Resources.group_box_top;
      this.pictureBox5.Location = new Point(5, 0);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(215, 10);
      this.pictureBox5.TabIndex = 86;
      this.pictureBox5.TabStop = false;
      this.pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox3.Image = (Image) Resources.group_box_btm_left;
      this.pictureBox3.Location = new Point(0, 118);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(10, 10);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox3.TabIndex = 2;
      this.pictureBox3.TabStop = false;
      this.pictureBox1.Image = (Image) Resources.group_box_top_left;
      this.pictureBox1.Location = new Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(10, 10);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.txtWeaponType.BackColor = Color.Transparent;
      this.txtWeaponType.Cursor = Cursors.Hand;
      this.txtWeaponType.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtWeaponType.ForeColor = Color.White;
      this.txtWeaponType.Location = new Point(37, 26);
      this.txtWeaponType.Name = "txtWeaponType";
      this.txtWeaponType.Size = new Size(174, 17);
      this.txtWeaponType.TabIndex = 88;
      this.txtWeaponType.Text = "Select Weapon Type";
      this.txtWeaponType.Click += new EventHandler(this.txtWeaponType_Click);
      this.dropListWeaponType.BackColor = Color.Transparent;
      this.dropListWeaponType.Cursor = Cursors.Hand;
      this.dropListWeaponType.Image = (Image) Resources.drop_button;
      this.dropListWeaponType.Location = new Point(208, 20);
      this.dropListWeaponType.Name = "dropListWeaponType";
      this.dropListWeaponType.Size = new Size(18, 26);
      this.dropListWeaponType.SizeMode = PictureBoxSizeMode.AutoSize;
      this.dropListWeaponType.TabIndex = 89;
      this.dropListWeaponType.TabStop = false;
      this.dropListWeaponType.Click += new EventHandler(this.dropListWeaponType_Click);
      this.dropListWeaponType.MouseLeave += new EventHandler(this.dropListButton_MouseOut);
      this.dropListWeaponType.MouseHover += new EventHandler(this.dropListButton_MouseOver);
      this.imgDropListWeaponType.BackColor = Color.Transparent;
      this.imgDropListWeaponType.Cursor = Cursors.Hand;
      this.imgDropListWeaponType.Image = (Image) Resources.weapon_sword;
      this.imgDropListWeaponType.Location = new Point(13, 28);
      this.imgDropListWeaponType.Name = "imgDropListWeaponType";
      this.imgDropListWeaponType.Size = new Size(23, 10);
      this.imgDropListWeaponType.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgDropListWeaponType.TabIndex = 90;
      this.imgDropListWeaponType.TabStop = false;
      this.imgDropListWeaponType.Visible = false;
      this.imgDropListWeaponType.Click += new EventHandler(this.imgDropListWeaponType_Click);
      this.dropListManufacturer.BackColor = Color.Transparent;
      this.dropListManufacturer.Cursor = Cursors.Hand;
      this.dropListManufacturer.Image = (Image) Resources.drop_button;
      this.dropListManufacturer.Location = new Point(208, 48);
      this.dropListManufacturer.Name = "dropListManufacturer";
      this.dropListManufacturer.Size = new Size(18, 26);
      this.dropListManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.dropListManufacturer.TabIndex = 91;
      this.dropListManufacturer.TabStop = false;
      this.dropListManufacturer.Click += new EventHandler(this.dropListManufacturer_Click);
      this.dropListManufacturer.MouseLeave += new EventHandler(this.dropListButton_MouseOut);
      this.dropListManufacturer.MouseHover += new EventHandler(this.dropListButton_MouseOver);
      this.manufacturerImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("manufacturerImageList.ImageStream");
      this.manufacturerImageList.TransparentColor = Color.Transparent;
      this.manufacturerImageList.Images.SetKeyName(0, "manlogo_GRM.png");
      this.manufacturerImageList.Images.SetKeyName(1, "manlogo_Yohmei.gif");
      this.manufacturerImageList.Images.SetKeyName(2, "manlogo_Tenora.png");
      this.manufacturerImageList.Images.SetKeyName(3, "manlogo_Kubara.gif");
      this.imgDropListManufacturer.BackColor = Color.Transparent;
      this.imgDropListManufacturer.Cursor = Cursors.Hand;
      this.imgDropListManufacturer.Image = (Image) Resources.manlogo_GRM;
      this.imgDropListManufacturer.Location = new Point(12, 53);
      this.imgDropListManufacturer.Name = "imgDropListManufacturer";
      this.imgDropListManufacturer.Size = new Size(17, 17);
      this.imgDropListManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgDropListManufacturer.TabIndex = 95;
      this.imgDropListManufacturer.TabStop = false;
      this.imgDropListManufacturer.Visible = false;
      this.imgDropListManufacturer.Click += new EventHandler(this.imgDropListManufacturer_Click);
      this.txtManufacturer.BackColor = Color.Transparent;
      this.txtManufacturer.Cursor = Cursors.Hand;
      this.txtManufacturer.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtManufacturer.ForeColor = Color.White;
      this.txtManufacturer.Location = new Point(37, 53);
      this.txtManufacturer.Name = "txtManufacturer";
      this.txtManufacturer.Size = new Size(174, 17);
      this.txtManufacturer.TabIndex = 94;
      this.txtManufacturer.Text = "Select Manufacturer";
      this.txtManufacturer.Click += new EventHandler(this.txtManufacturer_Click);
      this.rankImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("rankImageList.ImageStream");
      this.rankImageList.TransparentColor = Color.Transparent;
      this.rankImageList.Images.SetKeyName(0, "rank_C.png");
      this.rankImageList.Images.SetKeyName(1, "rank_B.png");
      this.rankImageList.Images.SetKeyName(2, "rank_A.png");
      this.rankImageList.Images.SetKeyName(3, "rank_S.png");
      this.rankImageList.Images.SetKeyName(4, "rank_Unknown.png");
      this.txtSelectedWeaponType.AutoSize = true;
      this.txtSelectedWeaponType.BackColor = Color.White;
      this.txtSelectedWeaponType.Location = new Point(12, 23);
      this.txtSelectedWeaponType.Name = "txtSelectedWeaponType";
      this.txtSelectedWeaponType.Size = new Size(125, 13);
      this.txtSelectedWeaponType.TabIndex = 99;
      this.txtSelectedWeaponType.Text = "txtSelectedWeaponType";
      this.txtSelectedManufacturer.AutoSize = true;
      this.txtSelectedManufacturer.BackColor = Color.White;
      this.txtSelectedManufacturer.Location = new Point(12, 39);
      this.txtSelectedManufacturer.Name = "txtSelectedManufacturer";
      this.txtSelectedManufacturer.Size = new Size(123, 13);
      this.txtSelectedManufacturer.TabIndex = 100;
      this.txtSelectedManufacturer.Text = "txtSelectedManufacturer";
      this.txtItemHex.BackColor = Color.White;
      this.txtItemHex.Location = new Point(11, 63);
      this.txtItemHex.Name = "txtItemHex";
      this.txtItemHex.Size = new Size(150, 48);
      this.txtItemHex.TabIndex = 102;
      this.txtItemHex.Text = "hex";
      this.txtInventoryLevel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInventoryLevel.BackColor = Color.Transparent;
      this.txtInventoryLevel.Location = new Point(173, 98);
      this.txtInventoryLevel.Name = "txtInventoryLevel";
      this.txtInventoryLevel.Size = new Size(99, 12);
      this.txtInventoryLevel.TabIndex = 135;
      this.txtInventoryLevel.Text = "LV100";
      this.txtInventoryLevel.TextAlign = ContentAlignment.TopRight;
      this.txtInventoryACC.AutoSize = true;
      this.txtInventoryACC.BackColor = Color.Transparent;
      this.txtInventoryACC.Location = new Point(8, 98);
      this.txtInventoryACC.Name = "txtInventoryACC";
      this.txtInventoryACC.Size = new Size(41, 13);
      this.txtInventoryACC.TabIndex = 134;
      this.txtInventoryACC.Text = "ACC  ";
      this.txtInventoryATK.AutoSize = true;
      this.txtInventoryATK.BackColor = Color.Transparent;
      this.txtInventoryATK.Location = new Point(11, 83);
      this.txtInventoryATK.Name = "txtInventoryATK";
      this.txtInventoryATK.Size = new Size(38, 13);
      this.txtInventoryATK.TabIndex = 133;
      this.txtInventoryATK.Text = "ATK  ";
      this.txtInventoryEffect.AutoSize = true;
      this.txtInventoryEffect.BackColor = Color.Transparent;
      this.txtInventoryEffect.Location = new Point(11, 178);
      this.txtInventoryEffect.Name = "txtInventoryEffect";
      this.txtInventoryEffect.Size = new Size(38, 13);
      this.txtInventoryEffect.TabIndex = 132;
      this.txtInventoryEffect.Text = "Effect:";
      this.txtInventoryEffect.Visible = false;
      this.txtInventorySpecial.BackColor = Color.Transparent;
      this.txtInventorySpecial.Location = new Point(0, 54);
      this.txtInventorySpecial.Name = "txtInventorySpecial";
      this.txtInventorySpecial.Size = new Size(284, 13);
      this.txtInventorySpecial.TabIndex = 131;
      this.txtInventorySpecial.Text = "Ability  ";
      this.imgInventoryRank.BackColor = Color.Transparent;
      this.imgInventoryRank.Image = (Image) Resources.rank_S;
      this.imgInventoryRank.Location = new Point(4, 3);
      this.imgInventoryRank.Name = "imgInventoryRank";
      this.imgInventoryRank.Size = new Size(10, 10);
      this.imgInventoryRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryRank.TabIndex = 130;
      this.imgInventoryRank.TabStop = false;
      this.imgStar15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar15.BackColor = Color.Transparent;
      this.imgStar15.Image = (Image) Resources.star_s2;
      this.imgStar15.Location = new Point(224, 115);
      this.imgStar15.Name = "imgStar15";
      this.imgStar15.Size = new Size(16, 15);
      this.imgStar15.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar15.TabIndex = 129;
      this.imgStar15.TabStop = false;
      this.imgStar15.Visible = false;
      this.imgStar14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar14.BackColor = Color.Transparent;
      this.imgStar14.Image = (Image) Resources.star_s2;
      this.imgStar14.Location = new Point(209, 115);
      this.imgStar14.Name = "imgStar14";
      this.imgStar14.Size = new Size(16, 15);
      this.imgStar14.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar14.TabIndex = 128;
      this.imgStar14.TabStop = false;
      this.imgStar14.Visible = false;
      this.imgStar13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar13.BackColor = Color.Transparent;
      this.imgStar13.Image = (Image) Resources.star_s2;
      this.imgStar13.Location = new Point(194, 115);
      this.imgStar13.Name = "imgStar13";
      this.imgStar13.Size = new Size(16, 15);
      this.imgStar13.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar13.TabIndex = (int) sbyte.MaxValue;
      this.imgStar13.TabStop = false;
      this.imgStar13.Visible = false;
      this.imgStar12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar12.BackColor = Color.Transparent;
      this.imgStar12.Image = (Image) Resources.star_s2;
      this.imgStar12.Location = new Point(179, 115);
      this.imgStar12.Name = "imgStar12";
      this.imgStar12.Size = new Size(16, 15);
      this.imgStar12.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar12.TabIndex = 126;
      this.imgStar12.TabStop = false;
      this.imgStar12.Visible = false;
      this.imgStar11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar11.BackColor = Color.Transparent;
      this.imgStar11.Image = (Image) Resources.star_S;
      this.imgStar11.Location = new Point(165, 115);
      this.imgStar11.Name = "imgStar11";
      this.imgStar11.Size = new Size(16, 15);
      this.imgStar11.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar11.TabIndex = 125;
      this.imgStar11.TabStop = false;
      this.imgStar11.Visible = false;
      this.imgStar10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar10.BackColor = Color.Transparent;
      this.imgStar10.Image = (Image) Resources.star_S;
      this.imgStar10.Location = new Point(150, 115);
      this.imgStar10.Name = "imgStar10";
      this.imgStar10.Size = new Size(16, 15);
      this.imgStar10.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar10.TabIndex = 124;
      this.imgStar10.TabStop = false;
      this.imgStar10.Visible = false;
      this.imgStar9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar9.BackColor = Color.Transparent;
      this.imgStar9.Image = (Image) Resources.star_S;
      this.imgStar9.Location = new Point(135, 115);
      this.imgStar9.Name = "imgStar9";
      this.imgStar9.Size = new Size(16, 15);
      this.imgStar9.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar9.TabIndex = 123;
      this.imgStar9.TabStop = false;
      this.imgStar9.Visible = false;
      this.imgStar8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar8.BackColor = Color.Transparent;
      this.imgStar8.Image = (Image) Resources.star_A;
      this.imgStar8.Location = new Point(120, 115);
      this.imgStar8.Name = "imgStar8";
      this.imgStar8.Size = new Size(16, 15);
      this.imgStar8.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar8.TabIndex = 122;
      this.imgStar8.TabStop = false;
      this.imgStar8.Visible = false;
      this.imgStar7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar7.BackColor = Color.Transparent;
      this.imgStar7.Image = (Image) Resources.star_A;
      this.imgStar7.Location = new Point(105, 115);
      this.imgStar7.Name = "imgStar7";
      this.imgStar7.Size = new Size(16, 15);
      this.imgStar7.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar7.TabIndex = 121;
      this.imgStar7.TabStop = false;
      this.imgStar7.Visible = false;
      this.imgStar6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar6.BackColor = Color.Transparent;
      this.imgStar6.Image = (Image) Resources.star_A;
      this.imgStar6.Location = new Point(90, 115);
      this.imgStar6.Name = "imgStar6";
      this.imgStar6.Size = new Size(16, 15);
      this.imgStar6.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar6.TabIndex = 120;
      this.imgStar6.TabStop = false;
      this.imgStar6.Visible = false;
      this.imgStar5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar5.BackColor = Color.Transparent;
      this.imgStar5.Image = (Image) Resources.star_B;
      this.imgStar5.Location = new Point(75, 115);
      this.imgStar5.Name = "imgStar5";
      this.imgStar5.Size = new Size(16, 15);
      this.imgStar5.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar5.TabIndex = 119;
      this.imgStar5.TabStop = false;
      this.imgStar5.Visible = false;
      this.imgStar4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar4.BackColor = Color.Transparent;
      this.imgStar4.Image = (Image) Resources.star_B;
      this.imgStar4.Location = new Point(60, 115);
      this.imgStar4.Name = "imgStar4";
      this.imgStar4.Size = new Size(16, 15);
      this.imgStar4.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar4.TabIndex = 118;
      this.imgStar4.TabStop = false;
      this.imgStar4.Visible = false;
      this.imgStar3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar3.BackColor = Color.Transparent;
      this.imgStar3.Image = (Image) Resources.star_B;
      this.imgStar3.Location = new Point(45, 115);
      this.imgStar3.Name = "imgStar3";
      this.imgStar3.Size = new Size(16, 15);
      this.imgStar3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar3.TabIndex = 117;
      this.imgStar3.TabStop = false;
      this.imgStar3.Visible = false;
      this.imgStar2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar2.BackColor = Color.Transparent;
      this.imgStar2.Image = (Image) Resources.star_C;
      this.imgStar2.Location = new Point(30, 115);
      this.imgStar2.Name = "imgStar2";
      this.imgStar2.Size = new Size(16, 15);
      this.imgStar2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar2.TabIndex = 116;
      this.imgStar2.TabStop = false;
      this.imgStar2.Visible = false;
      this.imgStar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar1.BackColor = Color.Transparent;
      this.imgStar1.Image = (Image) Resources.star_C;
      this.imgStar1.Location = new Point(15, 115);
      this.imgStar1.Name = "imgStar1";
      this.imgStar1.Size = new Size(16, 15);
      this.imgStar1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar1.TabIndex = 115;
      this.imgStar1.TabStop = false;
      this.imgStar1.Visible = false;
      this.imgStar0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar0.BackColor = Color.Transparent;
      this.imgStar0.Image = (Image) Resources.star_C;
      this.imgStar0.Location = new Point(0, 115);
      this.imgStar0.Name = "imgStar0";
      this.imgStar0.Size = new Size(16, 15);
      this.imgStar0.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar0.TabIndex = 114;
      this.imgStar0.TabStop = false;
      this.imgStar0.Visible = false;
      this.imgInventoryWeaponManufacturer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.imgInventoryWeaponManufacturer.BackColor = Color.Transparent;
      this.imgInventoryWeaponManufacturer.Image = (Image) Resources.manlogo_GRM;
      this.imgInventoryWeaponManufacturer.Location = new Point((int) byte.MaxValue, 0);
      this.imgInventoryWeaponManufacturer.Name = "imgInventoryWeaponManufacturer";
      this.imgInventoryWeaponManufacturer.Size = new Size(17, 17);
      this.imgInventoryWeaponManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryWeaponManufacturer.TabIndex = 110;
      this.imgInventoryWeaponManufacturer.TabStop = false;
      this.txtInventoryGrinds.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInventoryGrinds.BackColor = Color.Transparent;
      this.txtInventoryGrinds.Location = new Point(12, 148);
      this.txtInventoryGrinds.Name = "txtInventoryGrinds";
      this.txtInventoryGrinds.Size = new Size(94, 18);
      this.txtInventoryGrinds.TabIndex = 109;
      this.txtInventoryGrinds.Text = "(0)";
      this.txtInventoryGrinds.TextAlign = ContentAlignment.MiddleLeft;
      this.txtInventoryGrinds.Visible = false;
      this.txtInventoryName_jp.BackColor = Color.Transparent;
      this.txtInventoryName_jp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInventoryName_jp.Location = new Point(2, 18);
      this.txtInventoryName_jp.Name = "txtInventoryName_jp";
      this.txtInventoryName_jp.Size = new Size(224, 18);
      this.txtInventoryName_jp.TabIndex = 108;
      this.txtInventoryName_jp.Text = "-";
      this.imgInventoryElement.BackColor = Color.Transparent;
      this.imgInventoryElement.Cursor = Cursors.Default;
      this.imgInventoryElement.Image = (Image) Resources.element_neutral;
      this.imgInventoryElement.Location = new Point(14, 133);
      this.imgInventoryElement.Name = "imgInventoryElement";
      this.imgInventoryElement.Size = new Size(12, 12);
      this.imgInventoryElement.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryElement.TabIndex = 105;
      this.imgInventoryElement.TabStop = false;
      this.imgInventoryElement.Visible = false;
      this.txtInventoryPercent.AutoSize = true;
      this.txtInventoryPercent.BackColor = Color.Transparent;
      this.txtInventoryPercent.Location = new Point(26, 132);
      this.txtInventoryPercent.Name = "txtInventoryPercent";
      this.txtInventoryPercent.Size = new Size(21, 13);
      this.txtInventoryPercent.TabIndex = 104;
      this.txtInventoryPercent.Text = "0%";
      this.txtInventoryPercent.Visible = false;
      this.txtInventoryQty.AutoSize = true;
      this.txtInventoryQty.BackColor = Color.Transparent;
      this.txtInventoryQty.Location = new Point(11, 207);
      this.txtInventoryQty.Name = "txtInventoryQty";
      this.txtInventoryQty.Size = new Size(24, 13);
      this.txtInventoryQty.TabIndex = 106;
      this.txtInventoryQty.Text = "0/0";
      this.imgInventoryItemIcon.BackColor = Color.Transparent;
      this.imgInventoryItemIcon.Image = (Image) Resources.armor_icon;
      this.imgInventoryItemIcon.Location = new Point(4, 3);
      this.imgInventoryItemIcon.Name = "imgInventoryItemIcon";
      this.imgInventoryItemIcon.Padding = new Padding(13, 0, 0, 0);
      this.imgInventoryItemIcon.Size = new Size(23, 10);
      this.imgInventoryItemIcon.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryItemIcon.TabIndex = 111;
      this.imgInventoryItemIcon.TabStop = false;
      this.txtInventoryName.BackColor = Color.Transparent;
      this.txtInventoryName.Location = new Point(15, 1);
      this.txtInventoryName.Name = "txtInventoryName";
      this.txtInventoryName.Padding = new Padding(13, 0, 0, 0);
      this.txtInventoryName.Size = new Size(211, 18);
      this.txtInventoryName.TabIndex = 107;
      this.txtInventoryName.Text = "-";
      this.txtInventoryInfinityItemText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInventoryInfinityItemText.AutoSize = true;
      this.txtInventoryInfinityItemText.BackColor = Color.Transparent;
      this.txtInventoryInfinityItemText.Location = new Point(256, 20);
      this.txtInventoryInfinityItemText.Name = "txtInventoryInfinityItemText";
      this.txtInventoryInfinityItemText.Size = new Size(13, 13);
      this.txtInventoryInfinityItemText.TabIndex = 113;
      this.txtInventoryInfinityItemText.Text = "?";
      this.txtInventoryInfinityItemText.Visible = false;
      this.imgInventoryInfinityItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.imgInventoryInfinityItem.BackColor = Color.Transparent;
      this.imgInventoryInfinityItem.Image = (Image) Resources.infinity_item;
      this.imgInventoryInfinityItem.Location = new Point(252, 19);
      this.imgInventoryInfinityItem.Name = "imgInventoryInfinityItem";
      this.imgInventoryInfinityItem.Size = new Size(20, 16);
      this.imgInventoryInfinityItem.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryInfinityItem.TabIndex = 112;
      this.imgInventoryInfinityItem.TabStop = false;
      this.imgInventoryInfinityItem.Visible = false;
      this.pnlItemDetails.BackColor = Color.FromArgb(17, 49, 62);
      this.pnlItemDetails.BackgroundImage = (Image) Resources.nagisa_panel_bg;
      this.pnlItemDetails.Controls.Add((Control) this.txtInventoryLevel);
      this.pnlItemDetails.Controls.Add((Control) this.txtInventoryACC);
      this.pnlItemDetails.Controls.Add((Control) this.txtInventoryATK);
      this.pnlItemDetails.Controls.Add((Control) this.txtInventorySpecial);
      this.pnlItemDetails.Controls.Add((Control) this.imgInventoryRank);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar15);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar14);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar13);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar12);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar11);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar10);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar9);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar8);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar7);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar6);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar5);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar4);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar3);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar2);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar1);
      this.pnlItemDetails.Controls.Add((Control) this.imgStar0);
      this.pnlItemDetails.Controls.Add((Control) this.imgInventoryWeaponManufacturer);
      this.pnlItemDetails.Controls.Add((Control) this.txtInventoryName_jp);
      this.pnlItemDetails.Controls.Add((Control) this.imgInventoryItemIcon);
      this.pnlItemDetails.Controls.Add((Control) this.txtInventoryName);
      this.pnlItemDetails.Controls.Add((Control) this.txtInventoryInfinityItemText);
      this.pnlItemDetails.Controls.Add((Control) this.imgInventoryInfinityItem);
      this.pnlItemDetails.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.pnlItemDetails.ForeColor = Color.White;
      this.pnlItemDetails.Location = new Point(16, 129);
      this.pnlItemDetails.Name = "pnlItemDetails";
      this.pnlItemDetails.Size = new Size(284, 135);
      this.pnlItemDetails.TabIndex = 136;
      this.pnlItemDetails.Visible = false;
      this.txtSelectedHex.BackColor = Color.White;
      this.txtSelectedHex.ForeColor = Color.Black;
      this.txtSelectedHex.Location = new Point(11, 117);
      this.txtSelectedHex.Name = "txtSelectedHex";
      this.txtSelectedHex.Size = new Size(79, 13);
      this.txtSelectedHex.TabIndex = 137;
      this.txtSelectedHex.Text = "txtSelectedHex";
      this.imgDropListWeapon.BackColor = Color.Transparent;
      this.imgDropListWeapon.Cursor = Cursors.Hand;
      this.imgDropListWeapon.Image = (Image) Resources.rank_A;
      this.imgDropListWeapon.Location = new Point(13, 84);
      this.imgDropListWeapon.Name = "imgDropListWeapon";
      this.imgDropListWeapon.Size = new Size(10, 10);
      this.imgDropListWeapon.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgDropListWeapon.TabIndex = 140;
      this.imgDropListWeapon.TabStop = false;
      this.imgDropListWeapon.Visible = false;
      this.imgDropListWeapon.Click += new EventHandler(this.imgDropListWeapon_Click);
      this.dropListWeapon.BackColor = Color.Transparent;
      this.dropListWeapon.Cursor = Cursors.Hand;
      this.dropListWeapon.Image = (Image) Resources.drop_button;
      this.dropListWeapon.Location = new Point(208, 76);
      this.dropListWeapon.Name = "dropListWeapon";
      this.dropListWeapon.Size = new Size(18, 26);
      this.dropListWeapon.SizeMode = PictureBoxSizeMode.AutoSize;
      this.dropListWeapon.TabIndex = 139;
      this.dropListWeapon.TabStop = false;
      this.dropListWeapon.Click += new EventHandler(this.dropListWeapon_Click);
      this.txtWeapon.BackColor = Color.Transparent;
      this.txtWeapon.Cursor = Cursors.Hand;
      this.txtWeapon.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtWeapon.ForeColor = Color.White;
      this.txtWeapon.Location = new Point(37, 82);
      this.txtWeapon.Name = "txtWeapon";
      this.txtWeapon.Size = new Size(174, 17);
      this.txtWeapon.TabIndex = 138;
      this.txtWeapon.Text = "Select Weapon";
      this.txtWeapon.Click += new EventHandler(this.txtWeapon_Click);
      this.txtSelectedWeapon.AutoSize = true;
      this.txtSelectedWeapon.BackColor = Color.White;
      this.txtSelectedWeapon.Location = new Point(12, 7);
      this.txtSelectedWeapon.Name = "txtSelectedWeapon";
      this.txtSelectedWeapon.Size = new Size(101, 13);
      this.txtSelectedWeapon.TabIndex = 141;
      this.txtSelectedWeapon.Text = "txtSelectedWeapon";
      this.pnlDebug.BackColor = Color.Maroon;
      this.pnlDebug.Controls.Add((Control) this.txtSelectedWeaponType);
      this.pnlDebug.Controls.Add((Control) this.txtItemHex);
      this.pnlDebug.Controls.Add((Control) this.txtSelectedWeapon);
      this.pnlDebug.Controls.Add((Control) this.txtInventoryEffect);
      this.pnlDebug.Controls.Add((Control) this.txtSelectedManufacturer);
      this.pnlDebug.Controls.Add((Control) this.txtSelectedHex);
      this.pnlDebug.Controls.Add((Control) this.imgInventoryElement);
      this.pnlDebug.Controls.Add((Control) this.txtInventoryPercent);
      this.pnlDebug.Controls.Add((Control) this.txtInventoryGrinds);
      this.pnlDebug.Controls.Add((Control) this.txtInventoryQty);
      this.pnlDebug.Location = new Point(454, 5);
      this.pnlDebug.Name = "pnlDebug";
      this.pnlDebug.Size = new Size(175, 259);
      this.pnlDebug.TabIndex = 142;
      this.pnlDebug.Visible = false;
      this.picWeapon.BackColor = Color.Transparent;
      this.picWeapon.Location = new Point(309, 133);
      this.picWeapon.Name = "picWeapon";
      this.picWeapon.Size = new Size(160, 120);
      this.picWeapon.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picWeapon.TabIndex = 143;
      this.picWeapon.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) Resources.nagisa;
      this.BackgroundImageLayout = ImageLayout.None;
      this.ClientSize = new Size(480, 311);
      this.Controls.Add((Control) this.pnlDebug);
      this.Controls.Add((Control) this.pnlDropList);
      this.Controls.Add((Control) this.dropListManufacturer);
      this.Controls.Add((Control) this.dropListWeaponType);
      this.Controls.Add((Control) this.dropListWeapon);
      this.Controls.Add((Control) this.picWeapon);
      this.Controls.Add((Control) this.imgDropListManufacturer);
      this.Controls.Add((Control) this.txtManufacturer);
      this.Controls.Add((Control) this.imgDropListWeaponType);
      this.Controls.Add((Control) this.txtWeaponType);
      this.Controls.Add((Control) this.pnlItemDetails);
      this.Controls.Add((Control) this.imgDropListWeapon);
      this.Controls.Add((Control) this.txtWeapon);
      this.Controls.Add((Control) this.groupBox1);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(490, 343);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(490, 343);
      this.Name = nameof (weaponDbForm);
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "PSPo2se Weapon Database";
      this.FormClosing += new FormClosingEventHandler(this.weaponDbForm_FormClosing);
      this.Click += new EventHandler(this.weaponDbForm_Click);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.pnlDropList.ResumeLayout(false);
      this.pnlDropList.PerformLayout();
      ((ISupportInitialize) this.pictureBox8).EndInit();
      ((ISupportInitialize) this.pictureBox7).EndInit();
      ((ISupportInitialize) this.pictureBox6).EndInit();
      ((ISupportInitialize) this.pictureBox5).EndInit();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.dropListWeaponType).EndInit();
      ((ISupportInitialize) this.imgDropListWeaponType).EndInit();
      ((ISupportInitialize) this.dropListManufacturer).EndInit();
      ((ISupportInitialize) this.imgDropListManufacturer).EndInit();
      ((ISupportInitialize) this.imgInventoryRank).EndInit();
      ((ISupportInitialize) this.imgStar15).EndInit();
      ((ISupportInitialize) this.imgStar14).EndInit();
      ((ISupportInitialize) this.imgStar13).EndInit();
      ((ISupportInitialize) this.imgStar12).EndInit();
      ((ISupportInitialize) this.imgStar11).EndInit();
      ((ISupportInitialize) this.imgStar10).EndInit();
      ((ISupportInitialize) this.imgStar9).EndInit();
      ((ISupportInitialize) this.imgStar8).EndInit();
      ((ISupportInitialize) this.imgStar7).EndInit();
      ((ISupportInitialize) this.imgStar6).EndInit();
      ((ISupportInitialize) this.imgStar5).EndInit();
      ((ISupportInitialize) this.imgStar4).EndInit();
      ((ISupportInitialize) this.imgStar3).EndInit();
      ((ISupportInitialize) this.imgStar2).EndInit();
      ((ISupportInitialize) this.imgStar1).EndInit();
      ((ISupportInitialize) this.imgStar0).EndInit();
      ((ISupportInitialize) this.imgInventoryWeaponManufacturer).EndInit();
      ((ISupportInitialize) this.imgInventoryElement).EndInit();
      ((ISupportInitialize) this.imgInventoryItemIcon).EndInit();
      ((ISupportInitialize) this.imgInventoryInfinityItem).EndInit();
      this.pnlItemDetails.ResumeLayout(false);
      this.pnlItemDetails.PerformLayout();
      ((ISupportInitialize) this.imgDropListWeapon).EndInit();
      ((ISupportInitialize) this.dropListWeapon).EndInit();
      this.pnlDebug.ResumeLayout(false);
      this.pnlDebug.PerformLayout();
      ((ISupportInitialize) this.picWeapon).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public string displayCleanHex(string hex)
    {
      string str1 = "";
      for (int index = 0; index < 5; ++index)
        str1 = str1 + hex.Substring(index * 4, 4) + " ";
      string str2 = str1 + "\r\n";
      for (int index = 5; index < 9; ++index)
        str2 = str2 + hex.Substring(index * 4, 4) + " ";
      return str2 + hex.Substring(36, 4);
    }

    public void clearAllFields()
    {
      this.txtWeaponType.Text = "Select Weapon Type";
      this.txtSelectedWeaponType.Text = "";
      this.imgDropListWeaponType.Visible = false;
      this.txtManufacturer.Text = "Select Manufacturer";
      this.txtSelectedManufacturer.Text = "";
      this.imgDropListManufacturer.Visible = false;
      this.txtWeapon.Text = "Select Weapon";
      this.txtSelectedWeapon.Text = "";
      this.imgDropListWeapon.Visible = false;
      this.hex = "0100000000000000000000000000000000000000";
      this.txtItemHex.Text = this.displayCleanHex(this.hex);
      this.pnlItemDetails.Visible = false;
    }

    public int findItemIdInDbLinks(string hex)
    {
      for (int index = 0; index < this.dbLinkCount; ++index)
      {
        if (this.dbLink[index].hex == hex)
          return index;
      }
      return -1;
    }

    private void loadDbWeaponLinks()
    {
      this.dbLinkCount = 0;
      for (int index = 0; index < this.parent.item_db_filled; ++index)
      {
        if (this.parent.item_db.item[index].hex.Substring(6, 2) == "01")
        {
          this.dbLink[this.dbLinkCount] = this.parent.item_db.item[index];
          ++this.dbLinkCount;
        }
      }
    }

    private void loadFirstWeaponInSelection()
    {
      this.txtWeapon.Text = "Select Weapon";
      this.txtSelectedWeapon.Text = "";
      this.imgDropListWeapon.Visible = false;
      this.pnlItemDetails.Visible = false;
      this.picWeapon.Image = (Image) null;
    }

    private void loadSelectedWeaponNamesView()
    {
      if (!(this.txtManufacturer.Text != "") || !(this.txtWeaponType.Text != ""))
        return;
      string text1 = this.txtSelectedWeaponType.Text;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        string str1 = index1.ToString("X2");
        if (this.txtSelectedManufacturer.Text == "" || str1 == this.txtSelectedManufacturer.Text)
        {
          for (int index2 = 0; index2 < 256; ++index2)
          {
            string str2 = index2.ToString("X2");
            string hex = str1 + str2 + text1 + "01";
            int itemIdInDbLinks = this.findItemIdInDbLinks(hex);
            if (itemIdInDbLinks == -1)
            {
              if (this.chkUnknownWeapons.Checked)
                this.dropListView.Items.Add(new ListViewItem("unk_" + hex, 4)
                {
                  SubItems = {
                    hex ?? "",
                    string.Concat((object) itemIdInDbLinks)
                  }
                });
            }
            else
            {
              string text2 = this.dbLink[itemIdInDbLinks].name;
              if (text2 == "")
                text2 = this.dbLink[itemIdInDbLinks].name_jp;
              ListViewItem listViewItem = this.dbLink[itemIdInDbLinks].rarity < 0 ? new ListViewItem(text2, 4) : new ListViewItem(text2, (int) this.parent.getItemRankFromRarity(this.dbLink[itemIdInDbLinks].rarity));
              listViewItem.SubItems.Add(hex ?? "");
              listViewItem.SubItems.Add(string.Concat((object) itemIdInDbLinks));
              this.dropListView.Items.Add(listViewItem);
            }
          }
        }
      }
    }

    public void initForm()
    {
      this.selectedDropList = weaponDbForm.dropListType.none;
      this.enableAllDropListButtons();
      this.clearAllFields();
      this.parent = Program.form;
      this.pnlDropList.Visible = false;
      this.loadDbWeaponLinks();
      if (!Program.form.legitVersion())
        return;
      this.btnExport.Visible = false;
    }

    public weaponDbForm() => this.InitializeComponent();

    private void updateHex(int pos, string add)
    {
      if (pos + add.Length > this.hex.Length)
      {
        int num = (int) MessageBox.Show("Trying to write beyond the end of the hex");
      }
      else
      {
        this.hex = this.hex.Substring(0, pos) + add + this.hex.Substring(pos + add.Length, this.hex.Length - pos - add.Length);
        this.txtItemHex.Text = this.displayCleanHex(this.hex);
      }
    }

    private void disableAllDropListButtons()
    {
      this.dropListWeaponType.Enabled = false;
      this.dropListManufacturer.Enabled = false;
      this.dropListWeapon.Enabled = false;
      this.txtWeaponType.Enabled = false;
      this.txtManufacturer.Enabled = false;
      this.txtWeapon.Enabled = false;
      this.imgDropListWeaponType.Enabled = false;
      this.imgDropListManufacturer.Enabled = false;
      this.imgDropListWeapon.Enabled = false;
      this.btnClearFilters.Enabled = false;
      this.btnExport.Enabled = false;
      this.btnExit.Enabled = false;
      this.chkUnknownWeapons.Enabled = false;
      this.picWeapon.Enabled = false;
    }

    private void enableAllDropListButtons()
    {
      this.dropListWeaponType.Enabled = true;
      this.dropListManufacturer.Enabled = true;
      this.dropListWeapon.Enabled = true;
      this.txtWeaponType.Enabled = true;
      this.txtManufacturer.Enabled = true;
      this.txtWeapon.Enabled = true;
      this.imgDropListWeaponType.Enabled = true;
      this.imgDropListManufacturer.Enabled = true;
      this.imgDropListWeapon.Enabled = true;
      this.btnClearFilters.Enabled = true;
      this.btnExport.Enabled = true;
      this.btnExit.Enabled = true;
      this.chkUnknownWeapons.Enabled = true;
      this.picWeapon.Enabled = true;
    }

    public void dropListButton_MouseOver(object sender, EventArgs e) => ((PictureBox) sender).Image = (Image) Resources.drop_button_over;

    public void dropListButton_MouseOut(object sender, EventArgs e) => ((PictureBox) sender).Image = (Image) Resources.drop_button;

    public void dropListWeaponType_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.weapon_type);

    private void dropListManufacturer_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.manufacturer);

    private void dropListWeapon_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.weapon);

    private void txtWeaponType_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.weapon_type);

    private void imgDropListWeaponType_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.weapon_type);

    private void txtManufacturer_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.manufacturer);

    private void imgDropListManufacturer_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.manufacturer);

    private void txtWeapon_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.weapon);

    private void imgDropListWeapon_Click(object sender, EventArgs e) => this.showDropListView(weaponDbForm.dropListType.weapon);

    private void showDropListView(weaponDbForm.dropListType type)
    {
      Point location = this.pnlDropList.Location;
      this.disableAllDropListButtons();
      this.selectedDropList = type;
      this.dropListView.Items.Clear();
      switch (this.selectedDropList)
      {
        case weaponDbForm.dropListType.weapon_type:
          for (int index = 1; index < 29; ++index)
            this.dropListView.Items.Add(new ListViewItem(this.parent.weaponEnumToName((pspo2seForm.weaponType) index), index - 1)
            {
              SubItems = {
                string.Concat((object) index)
              }
            });
          location.X = 6;
          location.Y = 45;
          this.dropListView.SmallImageList = this.weaponTypesImageList;
          break;
        case weaponDbForm.dropListType.manufacturer:
          for (int imageIndex = 0; imageIndex < 4; ++imageIndex)
            this.dropListView.Items.Add(new ListViewItem(this.parent.enumToName(string.Concat((object) (pspo2seForm.weaponManufacturerType) imageIndex)), imageIndex)
            {
              SubItems = {
                string.Concat((object) imageIndex)
              }
            });
          location.X = 6;
          location.Y = 73;
          this.dropListView.SmallImageList = this.manufacturerImageList;
          break;
        case weaponDbForm.dropListType.weapon:
          if (this.txtWeaponType.Text == "")
          {
            int num = (int) MessageBox.Show("You must select a weapon type first");
            return;
          }
          location.X = 6;
          location.Y = 101;
          this.loadSelectedWeaponNamesView();
          this.dropListView.SmallImageList = this.rankImageList;
          break;
        default:
          this.enableAllDropListButtons();
          return;
      }
      this.pnlDropList.Location = location;
      this.pnlDropList.Visible = true;
    }

    private void closeDropListView()
    {
      this.pnlDropList.Visible = false;
      this.pnlItemDetails.Visible = false;
      Application.DoEvents();
      switch (this.selectedDropList)
      {
        case weaponDbForm.dropListType.weapon_type:
          this.txtWeaponType.Text = this.dropListView.SelectedItems[0].Text;
          this.txtSelectedWeaponType.Text = int.Parse(this.dropListView.SelectedItems[0].SubItems[1].Text).ToString("X2");
          this.imgDropListWeaponType.Image = this.parent.getWeaponImageFromType((pspo2seForm.weaponType) int.Parse(this.dropListView.SelectedItems[0].SubItems[1].Text));
          this.imgDropListWeaponType.Visible = true;
          this.updateHex(2, this.txtSelectedWeaponType.Text);
          this.loadFirstWeaponInSelection();
          this.txtManufacturer.Text = "Select Manufacturer";
          this.txtSelectedManufacturer.Text = "";
          this.imgDropListManufacturer.Visible = false;
          break;
        case weaponDbForm.dropListType.manufacturer:
          this.txtManufacturer.Text = this.dropListView.SelectedItems[0].Text;
          this.txtSelectedManufacturer.Text = int.Parse(this.dropListView.SelectedItems[0].SubItems[1].Text).ToString("X2");
          this.imgDropListManufacturer.Image = this.parent.getWeaponManufacturerImage((pspo2seForm.weaponManufacturerType) int.Parse(this.dropListView.SelectedItems[0].SubItems[1].Text));
          this.imgDropListManufacturer.Visible = true;
          this.updateHex(6, this.txtSelectedManufacturer.Text);
          this.loadFirstWeaponInSelection();
          break;
        case weaponDbForm.dropListType.weapon:
          this.txtWeapon.Text = this.dropListView.SelectedItems[0].Text;
          this.txtSelectedWeapon.Text = this.dropListView.SelectedItems[0].SubItems[2].Text;
          if (this.dbLink[int.Parse(this.txtSelectedWeapon.Text)].rarity < 0)
          {
            this.imgDropListWeapon.Image = (Image) Resources.rank_Unknown;
          }
          else
          {
            switch (this.parent.getItemRankFromRarity(this.dbLink[int.Parse(this.txtSelectedWeapon.Text)].rarity))
            {
              case pspo2seForm.itemRankType.c:
                this.imgDropListWeapon.Image = (Image) Resources.rank_C;
                break;
              case pspo2seForm.itemRankType.b:
                this.imgDropListWeapon.Image = (Image) Resources.rank_B;
                break;
              case pspo2seForm.itemRankType.a:
                this.imgDropListWeapon.Image = (Image) Resources.rank_A;
                break;
              case pspo2seForm.itemRankType.s:
                this.imgDropListWeapon.Image = (Image) Resources.rank_S;
                break;
            }
          }
          this.imgDropListWeapon.Visible = true;
          break;
      }
      this.selectedDropList = weaponDbForm.dropListType.none;
      this.enableAllDropListButtons();
      this.showSelectedWeapon();
    }

    private void dropListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.dropListView.SelectedItems.Count <= 0)
        return;
      this.closeDropListView();
    }

    private void dropListView_Click(object sender, EventArgs e)
    {
      if (this.dropListView.SelectedItems.Count <= 0)
        return;
      this.closeDropListView();
    }

    private void btnClearFilters_Click(object sender, EventArgs e) => this.clearAllFields();

    private void chkUnknownWeapons_CheckedChanged(object sender, EventArgs e) => this.loadFirstWeaponInSelection();

    private pspo2seForm.pageFields getItemDetailsFields() => new pspo2seForm.pageFields()
    {
      img_rank = this.imgInventoryRank,
      img_item = this.imgInventoryItemIcon,
      img_manufaturer = this.imgInventoryWeaponManufacturer,
      img_infinity_item = this.imgInventoryInfinityItem,
      img_element = this.imgInventoryElement,
      img_star_0 = this.imgStar0,
      img_star_1 = this.imgStar1,
      img_star_2 = this.imgStar2,
      img_star_3 = this.imgStar3,
      img_star_4 = this.imgStar4,
      img_star_5 = this.imgStar5,
      img_star_6 = this.imgStar6,
      img_star_7 = this.imgStar7,
      img_star_8 = this.imgStar8,
      img_star_9 = this.imgStar9,
      img_star_10 = this.imgStar10,
      img_star_11 = this.imgStar11,
      img_star_12 = this.imgStar12,
      img_star_13 = this.imgStar13,
      img_star_14 = this.imgStar14,
      img_star_15 = this.imgStar15,
      txt_infinity_item = this.txtInventoryInfinityItemText,
      txt_name = this.txtInventoryName,
      txt_name_jp = this.txtInventoryName_jp,
      grp_details = (GroupBox) null,
      txt_grinds = this.txtInventoryGrinds,
      txt_percent = this.txtInventoryPercent,
      txt_hex = this.txtSelectedHex,
      txt_meseta = (Label) null,
      txt_qty = this.txtInventoryQty,
      txt_special = this.txtInventorySpecial,
      txt_effect = this.txtInventoryEffect,
      txt_atk = this.txtInventoryATK,
      txt_acc = this.txtInventoryACC,
      txt_level = this.txtInventoryLevel,
      btn_delete = (Button) null,
      btn_export_selected = (Button) null,
      btn_import_selected = (Button) null,
      btn_withdraw = (Button) null,
      pnl_details = (Panel) null
    };

    private void showSelectedWeapon()
    {
      pspo2seForm.pageFields itemDetailsFields = this.getItemDetailsFields();
      itemDetailsFields.grp_details = (GroupBox) null;
      itemDetailsFields.pnl_details = this.pnlItemDetails;
      itemDetailsFields.txt_hex = this.txtSelectedHex;
      if (!(this.txtSelectedWeapon.Text != ""))
        return;
      int index = int.Parse(this.txtSelectedWeapon.Text);
      if (index != -1)
      {
        pspo2seForm.itemDb_ItemClass itemDbItemClass = this.dbLink[index];
        pspo2seForm.inventoryItemClass inventoryItemClass = new pspo2seForm.inventoryItemClass();
        inventoryItemClass.hex = this.parent.run.hexAndMathFunction.reversehex(itemDbItemClass.hex, 8);
        inventoryItemClass.style = pspo2seForm.weaponStyleType.Melee;
        switch ((pspo2seForm.weaponType) int.Parse(this.txtSelectedWeaponType.Text, NumberStyles.HexNumber))
        {
          case pspo2seForm.weaponType.longbow:
            inventoryItemClass.style = pspo2seForm.weaponStyleType.Tech;
            break;
          case pspo2seForm.weaponType.card:
            inventoryItemClass.style = pspo2seForm.weaponStyleType.Tech;
            break;
          case pspo2seForm.weaponType.rod:
            inventoryItemClass.style = pspo2seForm.weaponStyleType.Tech;
            break;
          case pspo2seForm.weaponType.wand:
            inventoryItemClass.style = pspo2seForm.weaponStyleType.Tech;
            break;
          case pspo2seForm.weaponType.tmag:
            inventoryItemClass.style = pspo2seForm.weaponStyleType.Tech;
            break;
        }
        inventoryItemClass.hex_reversed = itemDbItemClass.hex;
        inventoryItemClass.type = this.parent.getItemTypeFromHex(inventoryItemClass.hex);
        inventoryItemClass.power = itemDbItemClass.power;
        inventoryItemClass.acc = itemDbItemClass.acc;
        inventoryItemClass.name = itemDbItemClass.name;
        inventoryItemClass.name_jp = itemDbItemClass.name_jp;
        inventoryItemClass.desc = itemDbItemClass.desc;
        inventoryItemClass.desc_jp = itemDbItemClass.desc_jp;
        inventoryItemClass.infinity_item = itemDbItemClass.infinity_item;
        inventoryItemClass.level = itemDbItemClass.level;
        inventoryItemClass.ext_power = itemDbItemClass.ext_power;
        inventoryItemClass.ext_acc = itemDbItemClass.ext_acc;
        inventoryItemClass.ext_level = itemDbItemClass.ext_level;
        inventoryItemClass.special = itemDbItemClass.special;
        if (itemDbItemClass.special == "")
          inventoryItemClass.special = "DB_Error";
        inventoryItemClass.special_level = itemDbItemClass.special_level;
        inventoryItemClass.ext_special_level = itemDbItemClass.ext_special_level;
        inventoryItemClass.rarity = itemDbItemClass.rarity;
        this.parent.displayItemInfo(itemDetailsFields, inventoryItemClass);
        itemDetailsFields.txt_hex.Text = "0x" + inventoryItemClass.hex_reversed;
        itemDetailsFields.txt_name.Text = inventoryItemClass.name;
        itemDetailsFields.txt_name_jp.Text = inventoryItemClass.name_jp;
        this.parent.displayItemImage(itemDetailsFields, inventoryItemClass);
        this.parent.displayItemStars(itemDetailsFields, inventoryItemClass.rarity);
        this.parent.displayItemInfo(itemDetailsFields, inventoryItemClass);
        this.txtSelectedWeaponType.Text = ((int) this.parent.getWeaponTypeFromHex(inventoryItemClass.hex_reversed)).ToString("X2");
        this.txtWeaponType.Text = this.parent.weaponEnumToName(this.parent.getWeaponTypeFromHex(inventoryItemClass.hex_reversed));
        this.imgDropListWeaponType.Image = this.parent.getWeaponImageFromType(this.parent.getWeaponTypeFromHex(inventoryItemClass.hex_reversed));
        this.imgDropListWeaponType.Visible = true;
        string imageFloatInList = this.parent.findImageFloatInList(inventoryItemClass.hex_reversed);
        this.picWeapon.Image = !(imageFloatInList != "") ? (Image) null : (Image) new Bitmap(imageFloatInList);
        this.updateHex(0, inventoryItemClass.hex);
        string str = inventoryItemClass.rarity.ToString("X1");
        if (str.Length < 2)
          str = "0" + str;
        this.updateHex(31, inventoryItemClass.rarity >= 0 ? str.Substring(1, 1) : "0");
      }
      else
        itemDetailsFields.pnl_details.Visible = false;
    }

    private void weaponListView_SelectedIndexChanged(object sender, EventArgs e) => this.showSelectedWeapon();

    private void btnExport_Click(object sender, EventArgs e)
    {
      if (Program.form.legitVersion())
        return;
      pspo2seForm.itemDb_ItemClass itemDbItemClass = this.dbLink[int.Parse(this.txtSelectedWeapon.Text)];
      if (MessageBox.Show("Some items may have additional features which may not be included on the weapon created. This generally gets fixed when you save in game.\n\nAre you sure you want to continue?", "Modified Weapon Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
        return;
      string path = "";
      string ext_options = this.parent.mainSettings.saveStructureIndex.item_file_name + " (*" + this.parent.mainSettings.saveStructureIndex.item_file_ext + ")|*" + this.parent.mainSettings.saveStructureIndex.item_file_ext;
      if (this.parent.mainSettings.saveStructureIndex.item_file_ext == "")
        ext_options = "PSPo2/i Item File (*.pspo2item)|*.pspo2item";
      if (path == "")
        path = this.parent.openSaveDialogue(ext_options, this.txtInventoryName.Text);
      if (path == null)
        return;
      try
      {
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
          using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream))
          {
            for (int index = 0; index < 20; ++index)
            {
              if (index == 15)
                binaryWriter.Write(byte.Parse("FF", NumberStyles.HexNumber));
              else
                binaryWriter.Write(byte.Parse(this.hex.Substring(index * 2, 2), NumberStyles.HexNumber));
            }
            binaryWriter.Close();
          }
          fileStream.Close();
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return;
      }
      int num1 = (int) MessageBox.Show("The item was created successfully.\n\nPlease remember that you should not used modified items online as you may get banned.", "Item created successfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void btnExit_Click(object sender, EventArgs e) => this.Hide();

    private void weaponDbForm_Click(object sender, EventArgs e)
    {
      if (this.selectedDropList == weaponDbForm.dropListType.none)
        return;
      this.pnlDropList.Visible = false;
      this.enableAllDropListButtons();
      this.selectedDropList = weaponDbForm.dropListType.none;
    }

    private void weaponDbForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }

    private enum dropListType
    {
      none,
      weapon_type,
      manufacturer,
      weapon,
    }
  }
}
