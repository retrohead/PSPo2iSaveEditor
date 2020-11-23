using pspo2seSaveEditorProgram.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class weaponDbForm : Form
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(weaponDbForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkUnknownWeapons = new System.Windows.Forms.CheckBox();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.weaponTypesImageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlDropList = new System.Windows.Forms.Panel();
            this.dropListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtWeaponType = new System.Windows.Forms.Label();
            this.dropListWeaponType = new System.Windows.Forms.PictureBox();
            this.imgDropListWeaponType = new System.Windows.Forms.PictureBox();
            this.dropListManufacturer = new System.Windows.Forms.PictureBox();
            this.manufacturerImageList = new System.Windows.Forms.ImageList(this.components);
            this.imgDropListManufacturer = new System.Windows.Forms.PictureBox();
            this.txtManufacturer = new System.Windows.Forms.Label();
            this.rankImageList = new System.Windows.Forms.ImageList(this.components);
            this.txtSelectedWeaponType = new System.Windows.Forms.Label();
            this.txtSelectedManufacturer = new System.Windows.Forms.Label();
            this.txtItemHex = new System.Windows.Forms.Label();
            this.txtInventoryLevel = new System.Windows.Forms.Label();
            this.txtInventoryACC = new System.Windows.Forms.Label();
            this.txtInventoryATK = new System.Windows.Forms.Label();
            this.txtInventoryEffect = new System.Windows.Forms.Label();
            this.txtInventorySpecial = new System.Windows.Forms.Label();
            this.imgInventoryRank = new System.Windows.Forms.PictureBox();
            this.imgStar15 = new System.Windows.Forms.PictureBox();
            this.imgStar14 = new System.Windows.Forms.PictureBox();
            this.imgStar13 = new System.Windows.Forms.PictureBox();
            this.imgStar12 = new System.Windows.Forms.PictureBox();
            this.imgStar11 = new System.Windows.Forms.PictureBox();
            this.imgStar10 = new System.Windows.Forms.PictureBox();
            this.imgStar9 = new System.Windows.Forms.PictureBox();
            this.imgStar8 = new System.Windows.Forms.PictureBox();
            this.imgStar7 = new System.Windows.Forms.PictureBox();
            this.imgStar6 = new System.Windows.Forms.PictureBox();
            this.imgStar5 = new System.Windows.Forms.PictureBox();
            this.imgStar4 = new System.Windows.Forms.PictureBox();
            this.imgStar3 = new System.Windows.Forms.PictureBox();
            this.imgStar2 = new System.Windows.Forms.PictureBox();
            this.imgStar1 = new System.Windows.Forms.PictureBox();
            this.imgStar0 = new System.Windows.Forms.PictureBox();
            this.imgInventoryWeaponManufacturer = new System.Windows.Forms.PictureBox();
            this.txtInventoryGrinds = new System.Windows.Forms.Label();
            this.txtInventoryName_jp = new System.Windows.Forms.Label();
            this.imgInventoryElement = new System.Windows.Forms.PictureBox();
            this.txtInventoryPercent = new System.Windows.Forms.Label();
            this.txtInventoryQty = new System.Windows.Forms.Label();
            this.imgInventoryItemIcon = new System.Windows.Forms.PictureBox();
            this.txtInventoryName = new System.Windows.Forms.Label();
            this.txtInventoryInfinityItemText = new System.Windows.Forms.Label();
            this.imgInventoryInfinityItem = new System.Windows.Forms.PictureBox();
            this.pnlItemDetails = new System.Windows.Forms.Panel();
            this.txtSelectedHex = new System.Windows.Forms.Label();
            this.imgDropListWeapon = new System.Windows.Forms.PictureBox();
            this.dropListWeapon = new System.Windows.Forms.PictureBox();
            this.txtWeapon = new System.Windows.Forms.Label();
            this.txtSelectedWeapon = new System.Windows.Forms.Label();
            this.pnlDebug = new System.Windows.Forms.Panel();
            this.picWeapon = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.pnlDropList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropListWeaponType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDropListWeaponType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropListManufacturer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDropListManufacturer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryWeaponManufacturer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryElement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryItemIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryInfinityItem)).BeginInit();
            this.pnlItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDropListWeapon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropListWeapon)).BeginInit();
            this.pnlDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeapon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.chkUnknownWeapons);
            this.groupBox1.Controls.Add(this.btnClearFilters);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Location = new System.Drawing.Point(-21, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExport.Location = new System.Drawing.Point(346, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkUnknownWeapons
            // 
            this.chkUnknownWeapons.AutoSize = true;
            this.chkUnknownWeapons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkUnknownWeapons.Location = new System.Drawing.Point(106, 14);
            this.chkUnknownWeapons.Name = "chkUnknownWeapons";
            this.chkUnknownWeapons.Size = new System.Drawing.Size(140, 17);
            this.chkUnknownWeapons.TabIndex = 2;
            this.chkUnknownWeapons.Text = "List Unknown Weapons";
            this.chkUnknownWeapons.UseVisualStyleBackColor = true;
            this.chkUnknownWeapons.CheckedChanged += new System.EventHandler(this.chkUnknownWeapons_CheckedChanged);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilters.Location = new System.Drawing.Point(25, 10);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilters.TabIndex = 1;
            this.btnClearFilters.Text = "clear filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(421, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // weaponTypesImageList
            // 
            this.weaponTypesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("weaponTypesImageList.ImageStream")));
            this.weaponTypesImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // pnlDropList
            // 
            this.pnlDropList.BackColor = System.Drawing.Color.Transparent;
            this.pnlDropList.Controls.Add(this.dropListView);
            this.pnlDropList.Controls.Add(this.pictureBox8);
            this.pnlDropList.Controls.Add(this.pictureBox7);
            this.pnlDropList.Controls.Add(this.pictureBox6);
            this.pnlDropList.Controls.Add(this.pictureBox5);
            this.pnlDropList.Controls.Add(this.pictureBox3);
            this.pnlDropList.Controls.Add(this.pictureBox1);
            this.pnlDropList.Location = new System.Drawing.Point(425, 12);
            this.pnlDropList.Name = "pnlDropList";
            this.pnlDropList.Size = new System.Drawing.Size(220, 128);
            this.pnlDropList.TabIndex = 86;
            this.pnlDropList.Visible = false;
            // 
            // dropListView
            // 
            this.dropListView.BackColor = System.Drawing.SystemColors.Control;
            this.dropListView.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.TypeAbilitiesListBg;
            this.dropListView.BackgroundImageTiled = true;
            this.dropListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dropListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.dropListView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dropListView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropListView.ForeColor = System.Drawing.Color.White;
            this.dropListView.FullRowSelect = true;
            this.dropListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.dropListView.HideSelection = false;
            this.dropListView.LabelWrap = false;
            this.dropListView.Location = new System.Drawing.Point(6, 2);
            this.dropListView.MultiSelect = false;
            this.dropListView.Name = "dropListView";
            this.dropListView.Size = new System.Drawing.Size(212, 124);
            this.dropListView.SmallImageList = this.weaponTypesImageList;
            this.dropListView.TabIndex = 85;
            this.dropListView.UseCompatibleStateImageBehavior = false;
            this.dropListView.View = System.Windows.Forms.View.Details;
            this.dropListView.SelectedIndexChanged += new System.EventHandler(this.dropListView_SelectedIndexChanged);
            this.dropListView.Click += new System.EventHandler(this.dropListView_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 190;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox8.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_right;
            this.pictureBox8.Location = new System.Drawing.Point(210, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(10, 124);
            this.pictureBox8.TabIndex = 89;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox7.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_left;
            this.pictureBox7.Location = new System.Drawing.Point(0, 9);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(10, 110);
            this.pictureBox7.TabIndex = 88;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_btm;
            this.pictureBox6.Location = new System.Drawing.Point(5, 118);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(215, 10);
            this.pictureBox6.TabIndex = 87;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_top;
            this.pictureBox5.Location = new System.Drawing.Point(5, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(215, 10);
            this.pictureBox5.TabIndex = 86;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_btm_left;
            this.pictureBox3.Location = new System.Drawing.Point(0, 118);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(10, 10);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pspo2seSaveEditorProgram.Properties.Resources.group_box_top_left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtWeaponType
            // 
            this.txtWeaponType.BackColor = System.Drawing.Color.Transparent;
            this.txtWeaponType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtWeaponType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeaponType.ForeColor = System.Drawing.Color.White;
            this.txtWeaponType.Location = new System.Drawing.Point(37, 26);
            this.txtWeaponType.Name = "txtWeaponType";
            this.txtWeaponType.Size = new System.Drawing.Size(174, 17);
            this.txtWeaponType.TabIndex = 88;
            this.txtWeaponType.Text = "Select Weapon Type";
            this.txtWeaponType.Click += new System.EventHandler(this.txtWeaponType_Click);
            // 
            // dropListWeaponType
            // 
            this.dropListWeaponType.BackColor = System.Drawing.Color.Transparent;
            this.dropListWeaponType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dropListWeaponType.Image = global::pspo2seSaveEditorProgram.Properties.Resources.drop_button;
            this.dropListWeaponType.Location = new System.Drawing.Point(208, 20);
            this.dropListWeaponType.Name = "dropListWeaponType";
            this.dropListWeaponType.Size = new System.Drawing.Size(18, 26);
            this.dropListWeaponType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dropListWeaponType.TabIndex = 89;
            this.dropListWeaponType.TabStop = false;
            this.dropListWeaponType.Click += new System.EventHandler(this.dropListWeaponType_Click);
            this.dropListWeaponType.MouseLeave += new System.EventHandler(this.dropListButton_MouseOut);
            this.dropListWeaponType.MouseHover += new System.EventHandler(this.dropListButton_MouseOver);
            // 
            // imgDropListWeaponType
            // 
            this.imgDropListWeaponType.BackColor = System.Drawing.Color.Transparent;
            this.imgDropListWeaponType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgDropListWeaponType.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sword;
            this.imgDropListWeaponType.Location = new System.Drawing.Point(13, 28);
            this.imgDropListWeaponType.Name = "imgDropListWeaponType";
            this.imgDropListWeaponType.Size = new System.Drawing.Size(23, 10);
            this.imgDropListWeaponType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgDropListWeaponType.TabIndex = 90;
            this.imgDropListWeaponType.TabStop = false;
            this.imgDropListWeaponType.Visible = false;
            this.imgDropListWeaponType.Click += new System.EventHandler(this.imgDropListWeaponType_Click);
            // 
            // dropListManufacturer
            // 
            this.dropListManufacturer.BackColor = System.Drawing.Color.Transparent;
            this.dropListManufacturer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dropListManufacturer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.drop_button;
            this.dropListManufacturer.Location = new System.Drawing.Point(208, 48);
            this.dropListManufacturer.Name = "dropListManufacturer";
            this.dropListManufacturer.Size = new System.Drawing.Size(18, 26);
            this.dropListManufacturer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dropListManufacturer.TabIndex = 91;
            this.dropListManufacturer.TabStop = false;
            this.dropListManufacturer.Click += new System.EventHandler(this.dropListManufacturer_Click);
            this.dropListManufacturer.MouseLeave += new System.EventHandler(this.dropListButton_MouseOut);
            this.dropListManufacturer.MouseHover += new System.EventHandler(this.dropListButton_MouseOver);
            // 
            // manufacturerImageList
            // 
            this.manufacturerImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("manufacturerImageList.ImageStream")));
            this.manufacturerImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.manufacturerImageList.Images.SetKeyName(0, "manlogo_GRM.png");
            this.manufacturerImageList.Images.SetKeyName(1, "manlogo_Yohmei.gif");
            this.manufacturerImageList.Images.SetKeyName(2, "manlogo_Tenora.png");
            this.manufacturerImageList.Images.SetKeyName(3, "manlogo_Kubara.gif");
            // 
            // imgDropListManufacturer
            // 
            this.imgDropListManufacturer.BackColor = System.Drawing.Color.Transparent;
            this.imgDropListManufacturer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgDropListManufacturer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.manlogo_GRM;
            this.imgDropListManufacturer.Location = new System.Drawing.Point(12, 53);
            this.imgDropListManufacturer.Name = "imgDropListManufacturer";
            this.imgDropListManufacturer.Size = new System.Drawing.Size(17, 17);
            this.imgDropListManufacturer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgDropListManufacturer.TabIndex = 95;
            this.imgDropListManufacturer.TabStop = false;
            this.imgDropListManufacturer.Visible = false;
            this.imgDropListManufacturer.Click += new System.EventHandler(this.imgDropListManufacturer_Click);
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.BackColor = System.Drawing.Color.Transparent;
            this.txtManufacturer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManufacturer.ForeColor = System.Drawing.Color.White;
            this.txtManufacturer.Location = new System.Drawing.Point(37, 53);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(174, 17);
            this.txtManufacturer.TabIndex = 94;
            this.txtManufacturer.Text = "Select Manufacturer";
            this.txtManufacturer.Click += new System.EventHandler(this.txtManufacturer_Click);
            // 
            // rankImageList
            // 
            this.rankImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("rankImageList.ImageStream")));
            this.rankImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.rankImageList.Images.SetKeyName(0, "rank_C.png");
            this.rankImageList.Images.SetKeyName(1, "rank_B.png");
            this.rankImageList.Images.SetKeyName(2, "rank_A.png");
            this.rankImageList.Images.SetKeyName(3, "rank_S.png");
            this.rankImageList.Images.SetKeyName(4, "rank_Unknown.png");
            // 
            // txtSelectedWeaponType
            // 
            this.txtSelectedWeaponType.AutoSize = true;
            this.txtSelectedWeaponType.BackColor = System.Drawing.Color.White;
            this.txtSelectedWeaponType.Location = new System.Drawing.Point(12, 23);
            this.txtSelectedWeaponType.Name = "txtSelectedWeaponType";
            this.txtSelectedWeaponType.Size = new System.Drawing.Size(125, 13);
            this.txtSelectedWeaponType.TabIndex = 99;
            this.txtSelectedWeaponType.Text = "txtSelectedWeaponType";
            // 
            // txtSelectedManufacturer
            // 
            this.txtSelectedManufacturer.AutoSize = true;
            this.txtSelectedManufacturer.BackColor = System.Drawing.Color.White;
            this.txtSelectedManufacturer.Location = new System.Drawing.Point(12, 39);
            this.txtSelectedManufacturer.Name = "txtSelectedManufacturer";
            this.txtSelectedManufacturer.Size = new System.Drawing.Size(123, 13);
            this.txtSelectedManufacturer.TabIndex = 100;
            this.txtSelectedManufacturer.Text = "txtSelectedManufacturer";
            // 
            // txtItemHex
            // 
            this.txtItemHex.BackColor = System.Drawing.Color.White;
            this.txtItemHex.Location = new System.Drawing.Point(11, 63);
            this.txtItemHex.Name = "txtItemHex";
            this.txtItemHex.Size = new System.Drawing.Size(150, 48);
            this.txtItemHex.TabIndex = 102;
            this.txtItemHex.Text = "hex";
            // 
            // txtInventoryLevel
            // 
            this.txtInventoryLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryLevel.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryLevel.Location = new System.Drawing.Point(173, 98);
            this.txtInventoryLevel.Name = "txtInventoryLevel";
            this.txtInventoryLevel.Size = new System.Drawing.Size(99, 12);
            this.txtInventoryLevel.TabIndex = 135;
            this.txtInventoryLevel.Text = "LV100";
            this.txtInventoryLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInventoryACC
            // 
            this.txtInventoryACC.AutoSize = true;
            this.txtInventoryACC.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryACC.Location = new System.Drawing.Point(8, 98);
            this.txtInventoryACC.Name = "txtInventoryACC";
            this.txtInventoryACC.Size = new System.Drawing.Size(41, 13);
            this.txtInventoryACC.TabIndex = 134;
            this.txtInventoryACC.Text = "ACC  ";
            // 
            // txtInventoryATK
            // 
            this.txtInventoryATK.AutoSize = true;
            this.txtInventoryATK.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryATK.Location = new System.Drawing.Point(11, 83);
            this.txtInventoryATK.Name = "txtInventoryATK";
            this.txtInventoryATK.Size = new System.Drawing.Size(37, 13);
            this.txtInventoryATK.TabIndex = 133;
            this.txtInventoryATK.Text = "ATK  ";
            // 
            // txtInventoryEffect
            // 
            this.txtInventoryEffect.AutoSize = true;
            this.txtInventoryEffect.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryEffect.Location = new System.Drawing.Point(11, 178);
            this.txtInventoryEffect.Name = "txtInventoryEffect";
            this.txtInventoryEffect.Size = new System.Drawing.Size(38, 13);
            this.txtInventoryEffect.TabIndex = 132;
            this.txtInventoryEffect.Text = "Effect:";
            this.txtInventoryEffect.Visible = false;
            // 
            // txtInventorySpecial
            // 
            this.txtInventorySpecial.BackColor = System.Drawing.Color.Transparent;
            this.txtInventorySpecial.Location = new System.Drawing.Point(0, 54);
            this.txtInventorySpecial.Name = "txtInventorySpecial";
            this.txtInventorySpecial.Size = new System.Drawing.Size(284, 13);
            this.txtInventorySpecial.TabIndex = 131;
            this.txtInventorySpecial.Text = "Ability  ";
            // 
            // imgInventoryRank
            // 
            this.imgInventoryRank.BackColor = System.Drawing.Color.Transparent;
            this.imgInventoryRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_S;
            this.imgInventoryRank.Location = new System.Drawing.Point(4, 3);
            this.imgInventoryRank.Name = "imgInventoryRank";
            this.imgInventoryRank.Size = new System.Drawing.Size(10, 10);
            this.imgInventoryRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryRank.TabIndex = 130;
            this.imgInventoryRank.TabStop = false;
            // 
            // imgStar15
            // 
            this.imgStar15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar15.BackColor = System.Drawing.Color.Transparent;
            this.imgStar15.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStar15.Location = new System.Drawing.Point(224, 115);
            this.imgStar15.Name = "imgStar15";
            this.imgStar15.Size = new System.Drawing.Size(16, 15);
            this.imgStar15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar15.TabIndex = 129;
            this.imgStar15.TabStop = false;
            this.imgStar15.Visible = false;
            // 
            // imgStar14
            // 
            this.imgStar14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar14.BackColor = System.Drawing.Color.Transparent;
            this.imgStar14.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStar14.Location = new System.Drawing.Point(209, 115);
            this.imgStar14.Name = "imgStar14";
            this.imgStar14.Size = new System.Drawing.Size(16, 15);
            this.imgStar14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar14.TabIndex = 128;
            this.imgStar14.TabStop = false;
            this.imgStar14.Visible = false;
            // 
            // imgStar13
            // 
            this.imgStar13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar13.BackColor = System.Drawing.Color.Transparent;
            this.imgStar13.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStar13.Location = new System.Drawing.Point(194, 115);
            this.imgStar13.Name = "imgStar13";
            this.imgStar13.Size = new System.Drawing.Size(16, 15);
            this.imgStar13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar13.TabIndex = 127;
            this.imgStar13.TabStop = false;
            this.imgStar13.Visible = false;
            // 
            // imgStar12
            // 
            this.imgStar12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar12.BackColor = System.Drawing.Color.Transparent;
            this.imgStar12.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStar12.Location = new System.Drawing.Point(179, 115);
            this.imgStar12.Name = "imgStar12";
            this.imgStar12.Size = new System.Drawing.Size(16, 15);
            this.imgStar12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar12.TabIndex = 126;
            this.imgStar12.TabStop = false;
            this.imgStar12.Visible = false;
            // 
            // imgStar11
            // 
            this.imgStar11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar11.BackColor = System.Drawing.Color.Transparent;
            this.imgStar11.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStar11.Location = new System.Drawing.Point(165, 115);
            this.imgStar11.Name = "imgStar11";
            this.imgStar11.Size = new System.Drawing.Size(16, 15);
            this.imgStar11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar11.TabIndex = 125;
            this.imgStar11.TabStop = false;
            this.imgStar11.Visible = false;
            // 
            // imgStar10
            // 
            this.imgStar10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar10.BackColor = System.Drawing.Color.Transparent;
            this.imgStar10.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStar10.Location = new System.Drawing.Point(150, 115);
            this.imgStar10.Name = "imgStar10";
            this.imgStar10.Size = new System.Drawing.Size(16, 15);
            this.imgStar10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar10.TabIndex = 124;
            this.imgStar10.TabStop = false;
            this.imgStar10.Visible = false;
            // 
            // imgStar9
            // 
            this.imgStar9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar9.BackColor = System.Drawing.Color.Transparent;
            this.imgStar9.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStar9.Location = new System.Drawing.Point(135, 115);
            this.imgStar9.Name = "imgStar9";
            this.imgStar9.Size = new System.Drawing.Size(16, 15);
            this.imgStar9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar9.TabIndex = 123;
            this.imgStar9.TabStop = false;
            this.imgStar9.Visible = false;
            // 
            // imgStar8
            // 
            this.imgStar8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar8.BackColor = System.Drawing.Color.Transparent;
            this.imgStar8.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStar8.Location = new System.Drawing.Point(120, 115);
            this.imgStar8.Name = "imgStar8";
            this.imgStar8.Size = new System.Drawing.Size(16, 15);
            this.imgStar8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar8.TabIndex = 122;
            this.imgStar8.TabStop = false;
            this.imgStar8.Visible = false;
            // 
            // imgStar7
            // 
            this.imgStar7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar7.BackColor = System.Drawing.Color.Transparent;
            this.imgStar7.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStar7.Location = new System.Drawing.Point(105, 115);
            this.imgStar7.Name = "imgStar7";
            this.imgStar7.Size = new System.Drawing.Size(16, 15);
            this.imgStar7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar7.TabIndex = 121;
            this.imgStar7.TabStop = false;
            this.imgStar7.Visible = false;
            // 
            // imgStar6
            // 
            this.imgStar6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar6.BackColor = System.Drawing.Color.Transparent;
            this.imgStar6.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStar6.Location = new System.Drawing.Point(90, 115);
            this.imgStar6.Name = "imgStar6";
            this.imgStar6.Size = new System.Drawing.Size(16, 15);
            this.imgStar6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar6.TabIndex = 120;
            this.imgStar6.TabStop = false;
            this.imgStar6.Visible = false;
            // 
            // imgStar5
            // 
            this.imgStar5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar5.BackColor = System.Drawing.Color.Transparent;
            this.imgStar5.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStar5.Location = new System.Drawing.Point(75, 115);
            this.imgStar5.Name = "imgStar5";
            this.imgStar5.Size = new System.Drawing.Size(16, 15);
            this.imgStar5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar5.TabIndex = 119;
            this.imgStar5.TabStop = false;
            this.imgStar5.Visible = false;
            // 
            // imgStar4
            // 
            this.imgStar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar4.BackColor = System.Drawing.Color.Transparent;
            this.imgStar4.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStar4.Location = new System.Drawing.Point(60, 115);
            this.imgStar4.Name = "imgStar4";
            this.imgStar4.Size = new System.Drawing.Size(16, 15);
            this.imgStar4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar4.TabIndex = 118;
            this.imgStar4.TabStop = false;
            this.imgStar4.Visible = false;
            // 
            // imgStar3
            // 
            this.imgStar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar3.BackColor = System.Drawing.Color.Transparent;
            this.imgStar3.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStar3.Location = new System.Drawing.Point(45, 115);
            this.imgStar3.Name = "imgStar3";
            this.imgStar3.Size = new System.Drawing.Size(16, 15);
            this.imgStar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar3.TabIndex = 117;
            this.imgStar3.TabStop = false;
            this.imgStar3.Visible = false;
            // 
            // imgStar2
            // 
            this.imgStar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar2.BackColor = System.Drawing.Color.Transparent;
            this.imgStar2.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStar2.Location = new System.Drawing.Point(30, 115);
            this.imgStar2.Name = "imgStar2";
            this.imgStar2.Size = new System.Drawing.Size(16, 15);
            this.imgStar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar2.TabIndex = 116;
            this.imgStar2.TabStop = false;
            this.imgStar2.Visible = false;
            // 
            // imgStar1
            // 
            this.imgStar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar1.BackColor = System.Drawing.Color.Transparent;
            this.imgStar1.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStar1.Location = new System.Drawing.Point(15, 115);
            this.imgStar1.Name = "imgStar1";
            this.imgStar1.Size = new System.Drawing.Size(16, 15);
            this.imgStar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar1.TabIndex = 115;
            this.imgStar1.TabStop = false;
            this.imgStar1.Visible = false;
            // 
            // imgStar0
            // 
            this.imgStar0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar0.BackColor = System.Drawing.Color.Transparent;
            this.imgStar0.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStar0.Location = new System.Drawing.Point(0, 115);
            this.imgStar0.Name = "imgStar0";
            this.imgStar0.Size = new System.Drawing.Size(16, 15);
            this.imgStar0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar0.TabIndex = 114;
            this.imgStar0.TabStop = false;
            this.imgStar0.Visible = false;
            // 
            // imgInventoryWeaponManufacturer
            // 
            this.imgInventoryWeaponManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgInventoryWeaponManufacturer.BackColor = System.Drawing.Color.Transparent;
            this.imgInventoryWeaponManufacturer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.manlogo_GRM;
            this.imgInventoryWeaponManufacturer.Location = new System.Drawing.Point(255, 0);
            this.imgInventoryWeaponManufacturer.Name = "imgInventoryWeaponManufacturer";
            this.imgInventoryWeaponManufacturer.Size = new System.Drawing.Size(17, 17);
            this.imgInventoryWeaponManufacturer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryWeaponManufacturer.TabIndex = 110;
            this.imgInventoryWeaponManufacturer.TabStop = false;
            // 
            // txtInventoryGrinds
            // 
            this.txtInventoryGrinds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryGrinds.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryGrinds.Location = new System.Drawing.Point(12, 148);
            this.txtInventoryGrinds.Name = "txtInventoryGrinds";
            this.txtInventoryGrinds.Size = new System.Drawing.Size(94, 18);
            this.txtInventoryGrinds.TabIndex = 109;
            this.txtInventoryGrinds.Text = "(0)";
            this.txtInventoryGrinds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtInventoryGrinds.Visible = false;
            // 
            // txtInventoryName_jp
            // 
            this.txtInventoryName_jp.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryName_jp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryName_jp.Location = new System.Drawing.Point(2, 18);
            this.txtInventoryName_jp.Name = "txtInventoryName_jp";
            this.txtInventoryName_jp.Size = new System.Drawing.Size(224, 18);
            this.txtInventoryName_jp.TabIndex = 108;
            this.txtInventoryName_jp.Text = "-";
            // 
            // imgInventoryElement
            // 
            this.imgInventoryElement.BackColor = System.Drawing.Color.Transparent;
            this.imgInventoryElement.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgInventoryElement.Image = global::pspo2seSaveEditorProgram.Properties.Resources.element_neutral;
            this.imgInventoryElement.Location = new System.Drawing.Point(14, 133);
            this.imgInventoryElement.Name = "imgInventoryElement";
            this.imgInventoryElement.Size = new System.Drawing.Size(12, 12);
            this.imgInventoryElement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryElement.TabIndex = 105;
            this.imgInventoryElement.TabStop = false;
            this.imgInventoryElement.Visible = false;
            // 
            // txtInventoryPercent
            // 
            this.txtInventoryPercent.AutoSize = true;
            this.txtInventoryPercent.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryPercent.Location = new System.Drawing.Point(26, 132);
            this.txtInventoryPercent.Name = "txtInventoryPercent";
            this.txtInventoryPercent.Size = new System.Drawing.Size(21, 13);
            this.txtInventoryPercent.TabIndex = 104;
            this.txtInventoryPercent.Text = "0%";
            this.txtInventoryPercent.Visible = false;
            // 
            // txtInventoryQty
            // 
            this.txtInventoryQty.AutoSize = true;
            this.txtInventoryQty.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryQty.Location = new System.Drawing.Point(11, 207);
            this.txtInventoryQty.Name = "txtInventoryQty";
            this.txtInventoryQty.Size = new System.Drawing.Size(24, 13);
            this.txtInventoryQty.TabIndex = 106;
            this.txtInventoryQty.Text = "0/0";
            // 
            // imgInventoryItemIcon
            // 
            this.imgInventoryItemIcon.BackColor = System.Drawing.Color.Transparent;
            this.imgInventoryItemIcon.Image = global::pspo2seSaveEditorProgram.Properties.Resources.armor_icon;
            this.imgInventoryItemIcon.Location = new System.Drawing.Point(4, 3);
            this.imgInventoryItemIcon.Name = "imgInventoryItemIcon";
            this.imgInventoryItemIcon.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.imgInventoryItemIcon.Size = new System.Drawing.Size(23, 10);
            this.imgInventoryItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryItemIcon.TabIndex = 111;
            this.imgInventoryItemIcon.TabStop = false;
            // 
            // txtInventoryName
            // 
            this.txtInventoryName.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryName.Location = new System.Drawing.Point(15, 1);
            this.txtInventoryName.Name = "txtInventoryName";
            this.txtInventoryName.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.txtInventoryName.Size = new System.Drawing.Size(211, 18);
            this.txtInventoryName.TabIndex = 107;
            this.txtInventoryName.Text = "-";
            // 
            // txtInventoryInfinityItemText
            // 
            this.txtInventoryInfinityItemText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryInfinityItemText.AutoSize = true;
            this.txtInventoryInfinityItemText.BackColor = System.Drawing.Color.Transparent;
            this.txtInventoryInfinityItemText.Location = new System.Drawing.Point(256, 20);
            this.txtInventoryInfinityItemText.Name = "txtInventoryInfinityItemText";
            this.txtInventoryInfinityItemText.Size = new System.Drawing.Size(13, 13);
            this.txtInventoryInfinityItemText.TabIndex = 113;
            this.txtInventoryInfinityItemText.Text = "?";
            this.txtInventoryInfinityItemText.Visible = false;
            // 
            // imgInventoryInfinityItem
            // 
            this.imgInventoryInfinityItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgInventoryInfinityItem.BackColor = System.Drawing.Color.Transparent;
            this.imgInventoryInfinityItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.infinity_item;
            this.imgInventoryInfinityItem.Location = new System.Drawing.Point(252, 19);
            this.imgInventoryInfinityItem.Name = "imgInventoryInfinityItem";
            this.imgInventoryInfinityItem.Size = new System.Drawing.Size(20, 16);
            this.imgInventoryInfinityItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryInfinityItem.TabIndex = 112;
            this.imgInventoryInfinityItem.TabStop = false;
            this.imgInventoryInfinityItem.Visible = false;
            // 
            // pnlItemDetails
            // 
            this.pnlItemDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(49)))), ((int)(((byte)(62)))));
            this.pnlItemDetails.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.nagisa_panel_bg;
            this.pnlItemDetails.Controls.Add(this.txtInventoryLevel);
            this.pnlItemDetails.Controls.Add(this.txtInventoryACC);
            this.pnlItemDetails.Controls.Add(this.txtInventoryATK);
            this.pnlItemDetails.Controls.Add(this.txtInventorySpecial);
            this.pnlItemDetails.Controls.Add(this.imgInventoryRank);
            this.pnlItemDetails.Controls.Add(this.imgStar15);
            this.pnlItemDetails.Controls.Add(this.imgStar14);
            this.pnlItemDetails.Controls.Add(this.imgStar13);
            this.pnlItemDetails.Controls.Add(this.imgStar12);
            this.pnlItemDetails.Controls.Add(this.imgStar11);
            this.pnlItemDetails.Controls.Add(this.imgStar10);
            this.pnlItemDetails.Controls.Add(this.imgStar9);
            this.pnlItemDetails.Controls.Add(this.imgStar8);
            this.pnlItemDetails.Controls.Add(this.imgStar7);
            this.pnlItemDetails.Controls.Add(this.imgStar6);
            this.pnlItemDetails.Controls.Add(this.imgStar5);
            this.pnlItemDetails.Controls.Add(this.imgStar4);
            this.pnlItemDetails.Controls.Add(this.imgStar3);
            this.pnlItemDetails.Controls.Add(this.imgStar2);
            this.pnlItemDetails.Controls.Add(this.imgStar1);
            this.pnlItemDetails.Controls.Add(this.imgStar0);
            this.pnlItemDetails.Controls.Add(this.imgInventoryWeaponManufacturer);
            this.pnlItemDetails.Controls.Add(this.txtInventoryName_jp);
            this.pnlItemDetails.Controls.Add(this.imgInventoryItemIcon);
            this.pnlItemDetails.Controls.Add(this.txtInventoryName);
            this.pnlItemDetails.Controls.Add(this.txtInventoryInfinityItemText);
            this.pnlItemDetails.Controls.Add(this.imgInventoryInfinityItem);
            this.pnlItemDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlItemDetails.ForeColor = System.Drawing.Color.White;
            this.pnlItemDetails.Location = new System.Drawing.Point(16, 129);
            this.pnlItemDetails.Name = "pnlItemDetails";
            this.pnlItemDetails.Size = new System.Drawing.Size(284, 135);
            this.pnlItemDetails.TabIndex = 136;
            this.pnlItemDetails.Visible = false;
            // 
            // txtSelectedHex
            // 
            this.txtSelectedHex.BackColor = System.Drawing.Color.White;
            this.txtSelectedHex.ForeColor = System.Drawing.Color.Black;
            this.txtSelectedHex.Location = new System.Drawing.Point(11, 117);
            this.txtSelectedHex.Name = "txtSelectedHex";
            this.txtSelectedHex.Size = new System.Drawing.Size(79, 13);
            this.txtSelectedHex.TabIndex = 137;
            this.txtSelectedHex.Text = "txtSelectedHex";
            // 
            // imgDropListWeapon
            // 
            this.imgDropListWeapon.BackColor = System.Drawing.Color.Transparent;
            this.imgDropListWeapon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgDropListWeapon.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_A;
            this.imgDropListWeapon.Location = new System.Drawing.Point(13, 84);
            this.imgDropListWeapon.Name = "imgDropListWeapon";
            this.imgDropListWeapon.Size = new System.Drawing.Size(10, 10);
            this.imgDropListWeapon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgDropListWeapon.TabIndex = 140;
            this.imgDropListWeapon.TabStop = false;
            this.imgDropListWeapon.Visible = false;
            this.imgDropListWeapon.Click += new System.EventHandler(this.imgDropListWeapon_Click);
            // 
            // dropListWeapon
            // 
            this.dropListWeapon.BackColor = System.Drawing.Color.Transparent;
            this.dropListWeapon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dropListWeapon.Image = global::pspo2seSaveEditorProgram.Properties.Resources.drop_button;
            this.dropListWeapon.Location = new System.Drawing.Point(208, 76);
            this.dropListWeapon.Name = "dropListWeapon";
            this.dropListWeapon.Size = new System.Drawing.Size(18, 26);
            this.dropListWeapon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dropListWeapon.TabIndex = 139;
            this.dropListWeapon.TabStop = false;
            this.dropListWeapon.Click += new System.EventHandler(this.dropListWeapon_Click);
            // 
            // txtWeapon
            // 
            this.txtWeapon.BackColor = System.Drawing.Color.Transparent;
            this.txtWeapon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtWeapon.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeapon.ForeColor = System.Drawing.Color.White;
            this.txtWeapon.Location = new System.Drawing.Point(37, 82);
            this.txtWeapon.Name = "txtWeapon";
            this.txtWeapon.Size = new System.Drawing.Size(174, 17);
            this.txtWeapon.TabIndex = 138;
            this.txtWeapon.Text = "Select Weapon";
            this.txtWeapon.Click += new System.EventHandler(this.txtWeapon_Click);
            // 
            // txtSelectedWeapon
            // 
            this.txtSelectedWeapon.AutoSize = true;
            this.txtSelectedWeapon.BackColor = System.Drawing.Color.White;
            this.txtSelectedWeapon.Location = new System.Drawing.Point(12, 7);
            this.txtSelectedWeapon.Name = "txtSelectedWeapon";
            this.txtSelectedWeapon.Size = new System.Drawing.Size(101, 13);
            this.txtSelectedWeapon.TabIndex = 141;
            this.txtSelectedWeapon.Text = "txtSelectedWeapon";
            // 
            // pnlDebug
            // 
            this.pnlDebug.BackColor = System.Drawing.Color.Maroon;
            this.pnlDebug.Controls.Add(this.txtSelectedWeaponType);
            this.pnlDebug.Controls.Add(this.txtItemHex);
            this.pnlDebug.Controls.Add(this.txtSelectedWeapon);
            this.pnlDebug.Controls.Add(this.txtInventoryEffect);
            this.pnlDebug.Controls.Add(this.txtSelectedManufacturer);
            this.pnlDebug.Controls.Add(this.txtSelectedHex);
            this.pnlDebug.Controls.Add(this.imgInventoryElement);
            this.pnlDebug.Controls.Add(this.txtInventoryPercent);
            this.pnlDebug.Controls.Add(this.txtInventoryGrinds);
            this.pnlDebug.Controls.Add(this.txtInventoryQty);
            this.pnlDebug.Location = new System.Drawing.Point(467, 7);
            this.pnlDebug.Name = "pnlDebug";
            this.pnlDebug.Size = new System.Drawing.Size(175, 259);
            this.pnlDebug.TabIndex = 142;
            this.pnlDebug.Visible = false;
            // 
            // picWeapon
            // 
            this.picWeapon.BackColor = System.Drawing.Color.Transparent;
            this.picWeapon.Location = new System.Drawing.Point(309, 133);
            this.picWeapon.Name = "picWeapon";
            this.picWeapon.Size = new System.Drawing.Size(160, 120);
            this.picWeapon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWeapon.TabIndex = 143;
            this.picWeapon.TabStop = false;
            // 
            // weaponDbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::pspo2seSaveEditorProgram.Properties.Resources.nagisa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(470, 300);
            this.Controls.Add(this.pnlDebug);
            this.Controls.Add(this.pnlDropList);
            this.Controls.Add(this.dropListManufacturer);
            this.Controls.Add(this.dropListWeaponType);
            this.Controls.Add(this.dropListWeapon);
            this.Controls.Add(this.picWeapon);
            this.Controls.Add(this.imgDropListManufacturer);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.imgDropListWeaponType);
            this.Controls.Add(this.txtWeaponType);
            this.Controls.Add(this.pnlItemDetails);
            this.Controls.Add(this.imgDropListWeapon);
            this.Controls.Add(this.txtWeapon);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 343);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 343);
            this.Name = "weaponDbForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PSPo2se Weapon Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.weaponDbForm_FormClosing);
            this.Click += new System.EventHandler(this.weaponDbForm_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlDropList.ResumeLayout(false);
            this.pnlDropList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropListWeaponType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDropListWeaponType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropListManufacturer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDropListManufacturer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStar0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryWeaponManufacturer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryElement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryItemIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventoryInfinityItem)).EndInit();
            this.pnlItemDetails.ResumeLayout(false);
            this.pnlItemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDropListWeapon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropListWeapon)).EndInit();
            this.pnlDebug.ResumeLayout(false);
            this.pnlDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeapon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
