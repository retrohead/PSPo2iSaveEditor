namespace pspo2seSaveEditorProgram
{
    using pspo2seSaveEditorProgram.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

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
        private pspo2seForm.itemDb_ItemClass[] dbLink = new pspo2seForm.itemDb_ItemClass[0xfa0];
        private int dbLinkCount;
        private dropListType selectedDropList;
        private string hex = "";

        public weaponDbForm()
        {
            this.InitializeComponent();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            this.clearAllFields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!Program.form.legitVersion())
            {
                int index = int.Parse(this.txtSelectedWeapon.Text);
                pspo2seForm.itemDb_ItemClass class1 = this.dbLink[index];
                if (MessageBox.Show("Some items may have additional features which may not be included on the weapon created. This generally gets fixed when you save in game.\n\nAre you sure you want to continue?", "Modified Weapon Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    string path = "";
                    string[] strArray = new string[] { this.parent.mainSettings.saveStructureIndex.item_file_name, " (*", this.parent.mainSettings.saveStructureIndex.item_file_ext, ")|*", this.parent.mainSettings.saveStructureIndex.item_file_ext };
                    string str2 = string.Concat(strArray);
                    if (this.parent.mainSettings.saveStructureIndex.item_file_ext == "")
                    {
                        str2 = "PSPo2/i Item File (*.pspo2item)|*.pspo2item";
                    }
                    if (path == "")
                    {
                        path = this.parent.openSaveDialogue(str2, this.txtInventoryName.Text);
                    }
                    if (path == null)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            using (FileStream stream = new FileStream(path, FileMode.Create))
                            {
                                using (BinaryWriter writer = new BinaryWriter(stream))
                                {
                                    int num2 = 0;
                                    while (true)
                                    {
                                        if (num2 >= 20)
                                        {
                                            writer.Close();
                                            break;
                                        }
                                        if (num2 == 15)
                                        {
                                            writer.Write(byte.Parse("FF", NumberStyles.HexNumber));
                                        }
                                        else
                                        {
                                            writer.Write(byte.Parse(this.hex.Substring(num2 * 2, 2), NumberStyles.HexNumber));
                                        }
                                        num2++;
                                    }
                                }
                                stream.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                    MessageBox.Show("The item was created successfully.\n\nPlease remember that you should not used modified items online as you may get banned.", "Item created successfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void chkUnknownWeapons_CheckedChanged(object sender, EventArgs e)
        {
            this.loadFirstWeaponInSelection();
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

        private void closeDropListView()
        {
            this.pnlDropList.Visible = false;
            this.pnlItemDetails.Visible = false;
            Application.DoEvents();
            switch (this.selectedDropList)
            {
                case dropListType.weapon_type:
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

                case dropListType.manufacturer:
                    this.txtManufacturer.Text = this.dropListView.SelectedItems[0].Text;
                    this.txtSelectedManufacturer.Text = int.Parse(this.dropListView.SelectedItems[0].SubItems[1].Text).ToString("X2");
                    this.imgDropListManufacturer.Image = this.parent.getWeaponManufacturerImage((pspo2seForm.weaponManufacturerType) int.Parse(this.dropListView.SelectedItems[0].SubItems[1].Text));
                    this.imgDropListManufacturer.Visible = true;
                    this.updateHex(6, this.txtSelectedManufacturer.Text);
                    this.loadFirstWeaponInSelection();
                    break;

                case dropListType.weapon:
                    this.txtWeapon.Text = this.dropListView.SelectedItems[0].Text;
                    this.txtSelectedWeapon.Text = this.dropListView.SelectedItems[0].SubItems[2].Text;
                    if (this.dbLink[int.Parse(this.txtSelectedWeapon.Text)].rarity < 0)
                    {
                        this.imgDropListWeapon.Image = Resources.rank_Unknown;
                    }
                    else
                    {
                        switch (this.parent.getItemRankFromRarity(this.dbLink[int.Parse(this.txtSelectedWeapon.Text)].rarity))
                        {
                            case pspo2seForm.itemRankType.c:
                                this.imgDropListWeapon.Image = Resources.rank_C;
                                break;

                            case pspo2seForm.itemRankType.b:
                                this.imgDropListWeapon.Image = Resources.rank_B;
                                break;

                            case pspo2seForm.itemRankType.a:
                                this.imgDropListWeapon.Image = Resources.rank_A;
                                break;

                            case pspo2seForm.itemRankType.s:
                                this.imgDropListWeapon.Image = Resources.rank_S;
                                break;

                            default:
                                break;
                        }
                    }
                    this.imgDropListWeapon.Visible = true;
                    break;

                default:
                    break;
            }
            this.selectedDropList = dropListType.none;
            this.enableAllDropListButtons();
            this.showSelectedWeapon();
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

        public string displayCleanHex(string hex)
        {
            string str = "";
            for (int i = 0; i < 5; i++)
            {
                str = str + hex.Substring(i * 4, 4) + " ";
            }
            str = str + "\r\n";
            for (int j = 5; j < 9; j++)
            {
                str = str + hex.Substring(j * 4, 4) + " ";
            }
            return (str + hex.Substring(0x24, 4));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void dropListButton_MouseOut(object sender, EventArgs e)
        {
            ((PictureBox) sender).Image = Resources.drop_button;
        }

        public void dropListButton_MouseOver(object sender, EventArgs e)
        {
            ((PictureBox) sender).Image = Resources.drop_button_over;
        }

        private void dropListManufacturer_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.manufacturer);
        }

        private void dropListView_Click(object sender, EventArgs e)
        {
            if (this.dropListView.SelectedItems.Count > 0)
            {
                this.closeDropListView();
            }
        }

        private void dropListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dropListView.SelectedItems.Count > 0)
            {
                this.closeDropListView();
            }
        }

        private void dropListWeapon_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.weapon);
        }

        public void dropListWeaponType_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.weapon_type);
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

        public int findItemIdInDbLinks(string hex)
        {
            for (int i = 0; i < this.dbLinkCount; i++)
            {
                if (this.dbLink[i].hex == hex)
                {
                    return i;
                }
            }
            return -1;
        }

        private pspo2seForm.pageFields getItemDetailsFields() => 
            new pspo2seForm.pageFields { 
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
                grp_details = null,
                txt_grinds = this.txtInventoryGrinds,
                txt_percent = this.txtInventoryPercent,
                txt_hex = this.txtSelectedHex,
                txt_meseta = null,
                txt_qty = this.txtInventoryQty,
                txt_special = this.txtInventorySpecial,
                txt_effect = this.txtInventoryEffect,
                txt_atk = this.txtInventoryATK,
                txt_acc = this.txtInventoryACC,
                txt_level = this.txtInventoryLevel,
                btn_delete = null,
                btn_export_selected = null,
                btn_import_selected = null,
                btn_withdraw = null,
                pnl_details = null
            };

        private void imgDropListManufacturer_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.manufacturer);
        }

        private void imgDropListWeapon_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.weapon);
        }

        private void imgDropListWeaponType_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.weapon_type);
        }

        public void initForm()
        {
            this.selectedDropList = dropListType.none;
            this.enableAllDropListButtons();
            this.clearAllFields();
            this.parent = Program.form;
            this.pnlDropList.Visible = false;
            this.loadDbWeaponLinks();
            if (Program.form.legitVersion())
            {
                this.btnExport.Visible = false;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(weaponDbForm));
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
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.chkUnknownWeapons);
            this.groupBox1.Controls.Add(this.btnClearFilters);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Location = new Point(-21, 0x110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x200, 0x2e);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.btnExport.Cursor = Cursors.Hand;
            this.btnExport.DialogResult = DialogResult.Cancel;
            this.btnExport.Location = new Point(0x15a, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(0x4b, 0x17);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new EventHandler(this.btnExport_Click);
            this.chkUnknownWeapons.AutoSize = true;
            this.chkUnknownWeapons.Cursor = Cursors.Hand;
            this.chkUnknownWeapons.Location = new Point(0x6a, 14);
            this.chkUnknownWeapons.Name = "chkUnknownWeapons";
            this.chkUnknownWeapons.Size = new Size(140, 0x11);
            this.chkUnknownWeapons.TabIndex = 2;
            this.chkUnknownWeapons.Text = "List Unknown Weapons";
            this.chkUnknownWeapons.UseVisualStyleBackColor = true;
            this.chkUnknownWeapons.CheckedChanged += new EventHandler(this.chkUnknownWeapons_CheckedChanged);
            this.btnClearFilters.Cursor = Cursors.Hand;
            this.btnClearFilters.Location = new Point(0x19, 10);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new Size(0x4b, 0x17);
            this.btnClearFilters.TabIndex = 1;
            this.btnClearFilters.Text = "clear filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new EventHandler(this.btnClearFilters_Click);
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.DialogResult = DialogResult.Cancel;
            this.btnExit.Location = new Point(0x1a5, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.weaponTypesImageList.ImageStream = (ImageListStreamer) manager.GetObject("weaponTypesImageList.ImageStream");
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
            this.weaponTypesImageList.Images.SetKeyName(0x10, "grenade.png");
            this.weaponTypesImageList.Images.SetKeyName(0x11, "laser.png");
            this.weaponTypesImageList.Images.SetKeyName(0x12, "handguns.png");
            this.weaponTypesImageList.Images.SetKeyName(0x13, "handgun.png");
            this.weaponTypesImageList.Images.SetKeyName(20, "crossbow.png");
            this.weaponTypesImageList.Images.SetKeyName(0x15, "cards.png");
            this.weaponTypesImageList.Images.SetKeyName(0x16, "machinegun.png");
            this.weaponTypesImageList.Images.SetKeyName(0x17, "rod.png");
            this.weaponTypesImageList.Images.SetKeyName(0x18, "wand.png");
            this.weaponTypesImageList.Images.SetKeyName(0x19, "tmag.png");
            this.weaponTypesImageList.Images.SetKeyName(0x1a, "rmag.png");
            this.weaponTypesImageList.Images.SetKeyName(0x1b, "shield.png");
            this.pnlDropList.BackColor = Color.Transparent;
            this.pnlDropList.Controls.Add(this.dropListView);
            this.pnlDropList.Controls.Add(this.pictureBox8);
            this.pnlDropList.Controls.Add(this.pictureBox7);
            this.pnlDropList.Controls.Add(this.pictureBox6);
            this.pnlDropList.Controls.Add(this.pictureBox5);
            this.pnlDropList.Controls.Add(this.pictureBox3);
            this.pnlDropList.Controls.Add(this.pictureBox1);
            this.pnlDropList.Location = new Point(0x1a9, 12);
            this.pnlDropList.Name = "pnlDropList";
            this.pnlDropList.Size = new Size(220, 0x80);
            this.pnlDropList.TabIndex = 0x56;
            this.pnlDropList.Visible = false;
            this.dropListView.BackColor = SystemColors.Control;
            this.dropListView.BackgroundImage = Resources.TypeAbilitiesListBg;
            this.dropListView.BackgroundImageTiled = true;
            this.dropListView.BorderStyle = BorderStyle.None;
            ColumnHeader[] values = new ColumnHeader[] { this.columnHeader1, this.columnHeader2 };
            this.dropListView.Columns.AddRange(values);
            this.dropListView.Cursor = Cursors.Hand;
            this.dropListView.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dropListView.ForeColor = Color.White;
            this.dropListView.FullRowSelect = true;
            this.dropListView.HeaderStyle = ColumnHeaderStyle.None;
            this.dropListView.HideSelection = false;
            this.dropListView.LabelWrap = false;
            this.dropListView.Location = new Point(6, 2);
            this.dropListView.MultiSelect = false;
            this.dropListView.Name = "dropListView";
            this.dropListView.Size = new Size(0xd4, 0x7c);
            this.dropListView.SmallImageList = this.weaponTypesImageList;
            this.dropListView.TabIndex = 0x55;
            this.dropListView.UseCompatibleStateImageBehavior = false;
            this.dropListView.View = View.Details;
            this.dropListView.SelectedIndexChanged += new EventHandler(this.dropListView_SelectedIndexChanged);
            this.dropListView.Click += new EventHandler(this.dropListView_Click);
            this.columnHeader1.Width = 190;
            this.columnHeader2.Width = 0;
            this.pictureBox8.Anchor = AnchorStyles.Right;
            this.pictureBox8.BackgroundImage = Resources.group_box_right;
            this.pictureBox8.Location = new Point(210, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new Size(10, 0x7c);
            this.pictureBox8.TabIndex = 0x59;
            this.pictureBox8.TabStop = false;
            this.pictureBox7.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox7.BackgroundImage = Resources.group_box_left;
            this.pictureBox7.Location = new Point(0, 9);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new Size(10, 110);
            this.pictureBox7.TabIndex = 0x58;
            this.pictureBox7.TabStop = false;
            this.pictureBox6.BackgroundImage = Resources.group_box_btm;
            this.pictureBox6.Location = new Point(5, 0x76);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new Size(0xd7, 10);
            this.pictureBox6.TabIndex = 0x57;
            this.pictureBox6.TabStop = false;
            this.pictureBox5.BackgroundImage = Resources.group_box_top;
            this.pictureBox5.Location = new Point(5, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new Size(0xd7, 10);
            this.pictureBox5.TabIndex = 0x56;
            this.pictureBox5.TabStop = false;
            this.pictureBox3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox3.Image = Resources.group_box_btm_left;
            this.pictureBox3.Location = new Point(0, 0x76);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(10, 10);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox1.Image = Resources.group_box_top_left;
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(10, 10);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.txtWeaponType.BackColor = Color.Transparent;
            this.txtWeaponType.Cursor = Cursors.Hand;
            this.txtWeaponType.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtWeaponType.ForeColor = Color.White;
            this.txtWeaponType.Location = new Point(0x25, 0x1a);
            this.txtWeaponType.Name = "txtWeaponType";
            this.txtWeaponType.Size = new Size(0xae, 0x11);
            this.txtWeaponType.TabIndex = 0x58;
            this.txtWeaponType.Text = "Select Weapon Type";
            this.txtWeaponType.Click += new EventHandler(this.txtWeaponType_Click);
            this.dropListWeaponType.BackColor = Color.Transparent;
            this.dropListWeaponType.Cursor = Cursors.Hand;
            this.dropListWeaponType.Image = Resources.drop_button;
            this.dropListWeaponType.Location = new Point(0xd0, 20);
            this.dropListWeaponType.Name = "dropListWeaponType";
            this.dropListWeaponType.Size = new Size(0x12, 0x1a);
            this.dropListWeaponType.SizeMode = PictureBoxSizeMode.AutoSize;
            this.dropListWeaponType.TabIndex = 0x59;
            this.dropListWeaponType.TabStop = false;
            this.dropListWeaponType.Click += new EventHandler(this.dropListWeaponType_Click);
            this.dropListWeaponType.MouseLeave += new EventHandler(this.dropListButton_MouseOut);
            this.dropListWeaponType.MouseHover += new EventHandler(this.dropListButton_MouseOver);
            this.imgDropListWeaponType.BackColor = Color.Transparent;
            this.imgDropListWeaponType.Cursor = Cursors.Hand;
            this.imgDropListWeaponType.Image = Resources.weapon_sword;
            this.imgDropListWeaponType.Location = new Point(13, 0x1c);
            this.imgDropListWeaponType.Name = "imgDropListWeaponType";
            this.imgDropListWeaponType.Size = new Size(0x17, 10);
            this.imgDropListWeaponType.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgDropListWeaponType.TabIndex = 90;
            this.imgDropListWeaponType.TabStop = false;
            this.imgDropListWeaponType.Visible = false;
            this.imgDropListWeaponType.Click += new EventHandler(this.imgDropListWeaponType_Click);
            this.dropListManufacturer.BackColor = Color.Transparent;
            this.dropListManufacturer.Cursor = Cursors.Hand;
            this.dropListManufacturer.Image = Resources.drop_button;
            this.dropListManufacturer.Location = new Point(0xd0, 0x30);
            this.dropListManufacturer.Name = "dropListManufacturer";
            this.dropListManufacturer.Size = new Size(0x12, 0x1a);
            this.dropListManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.dropListManufacturer.TabIndex = 0x5b;
            this.dropListManufacturer.TabStop = false;
            this.dropListManufacturer.Click += new EventHandler(this.dropListManufacturer_Click);
            this.dropListManufacturer.MouseLeave += new EventHandler(this.dropListButton_MouseOut);
            this.dropListManufacturer.MouseHover += new EventHandler(this.dropListButton_MouseOver);
            this.manufacturerImageList.ImageStream = (ImageListStreamer) manager.GetObject("manufacturerImageList.ImageStream");
            this.manufacturerImageList.TransparentColor = Color.Transparent;
            this.manufacturerImageList.Images.SetKeyName(0, "manlogo_GRM.png");
            this.manufacturerImageList.Images.SetKeyName(1, "manlogo_Yohmei.gif");
            this.manufacturerImageList.Images.SetKeyName(2, "manlogo_Tenora.png");
            this.manufacturerImageList.Images.SetKeyName(3, "manlogo_Kubara.gif");
            this.imgDropListManufacturer.BackColor = Color.Transparent;
            this.imgDropListManufacturer.Cursor = Cursors.Hand;
            this.imgDropListManufacturer.Image = Resources.manlogo_GRM;
            this.imgDropListManufacturer.Location = new Point(12, 0x35);
            this.imgDropListManufacturer.Name = "imgDropListManufacturer";
            this.imgDropListManufacturer.Size = new Size(0x11, 0x11);
            this.imgDropListManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgDropListManufacturer.TabIndex = 0x5f;
            this.imgDropListManufacturer.TabStop = false;
            this.imgDropListManufacturer.Visible = false;
            this.imgDropListManufacturer.Click += new EventHandler(this.imgDropListManufacturer_Click);
            this.txtManufacturer.BackColor = Color.Transparent;
            this.txtManufacturer.Cursor = Cursors.Hand;
            this.txtManufacturer.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtManufacturer.ForeColor = Color.White;
            this.txtManufacturer.Location = new Point(0x25, 0x35);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new Size(0xae, 0x11);
            this.txtManufacturer.TabIndex = 0x5e;
            this.txtManufacturer.Text = "Select Manufacturer";
            this.txtManufacturer.Click += new EventHandler(this.txtManufacturer_Click);
            this.rankImageList.ImageStream = (ImageListStreamer) manager.GetObject("rankImageList.ImageStream");
            this.rankImageList.TransparentColor = Color.Transparent;
            this.rankImageList.Images.SetKeyName(0, "rank_C.png");
            this.rankImageList.Images.SetKeyName(1, "rank_B.png");
            this.rankImageList.Images.SetKeyName(2, "rank_A.png");
            this.rankImageList.Images.SetKeyName(3, "rank_S.png");
            this.rankImageList.Images.SetKeyName(4, "rank_Unknown.png");
            this.txtSelectedWeaponType.AutoSize = true;
            this.txtSelectedWeaponType.BackColor = Color.White;
            this.txtSelectedWeaponType.Location = new Point(12, 0x17);
            this.txtSelectedWeaponType.Name = "txtSelectedWeaponType";
            this.txtSelectedWeaponType.Size = new Size(0x7d, 13);
            this.txtSelectedWeaponType.TabIndex = 0x63;
            this.txtSelectedWeaponType.Text = "txtSelectedWeaponType";
            this.txtSelectedManufacturer.AutoSize = true;
            this.txtSelectedManufacturer.BackColor = Color.White;
            this.txtSelectedManufacturer.Location = new Point(12, 0x27);
            this.txtSelectedManufacturer.Name = "txtSelectedManufacturer";
            this.txtSelectedManufacturer.Size = new Size(0x7b, 13);
            this.txtSelectedManufacturer.TabIndex = 100;
            this.txtSelectedManufacturer.Text = "txtSelectedManufacturer";
            this.txtItemHex.BackColor = Color.White;
            this.txtItemHex.Location = new Point(11, 0x3f);
            this.txtItemHex.Name = "txtItemHex";
            this.txtItemHex.Size = new Size(150, 0x30);
            this.txtItemHex.TabIndex = 0x66;
            this.txtItemHex.Text = "hex";
            this.txtInventoryLevel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtInventoryLevel.BackColor = Color.Transparent;
            this.txtInventoryLevel.Location = new Point(0xad, 0x62);
            this.txtInventoryLevel.Name = "txtInventoryLevel";
            this.txtInventoryLevel.Size = new Size(0x63, 12);
            this.txtInventoryLevel.TabIndex = 0x87;
            this.txtInventoryLevel.Text = "LV100";
            this.txtInventoryLevel.TextAlign = ContentAlignment.TopRight;
            this.txtInventoryACC.AutoSize = true;
            this.txtInventoryACC.BackColor = Color.Transparent;
            this.txtInventoryACC.Location = new Point(8, 0x62);
            this.txtInventoryACC.Name = "txtInventoryACC";
            this.txtInventoryACC.Size = new Size(0x29, 13);
            this.txtInventoryACC.TabIndex = 0x86;
            this.txtInventoryACC.Text = "ACC  ";
            this.txtInventoryATK.AutoSize = true;
            this.txtInventoryATK.BackColor = Color.Transparent;
            this.txtInventoryATK.Location = new Point(11, 0x53);
            this.txtInventoryATK.Name = "txtInventoryATK";
            this.txtInventoryATK.Size = new Size(0x26, 13);
            this.txtInventoryATK.TabIndex = 0x85;
            this.txtInventoryATK.Text = "ATK  ";
            this.txtInventoryEffect.AutoSize = true;
            this.txtInventoryEffect.BackColor = Color.Transparent;
            this.txtInventoryEffect.Location = new Point(11, 0xb2);
            this.txtInventoryEffect.Name = "txtInventoryEffect";
            this.txtInventoryEffect.Size = new Size(0x26, 13);
            this.txtInventoryEffect.TabIndex = 0x84;
            this.txtInventoryEffect.Text = "Effect:";
            this.txtInventoryEffect.Visible = false;
            this.txtInventorySpecial.BackColor = Color.Transparent;
            this.txtInventorySpecial.Location = new Point(0, 0x36);
            this.txtInventorySpecial.Name = "txtInventorySpecial";
            this.txtInventorySpecial.Size = new Size(0x11c, 13);
            this.txtInventorySpecial.TabIndex = 0x83;
            this.txtInventorySpecial.Text = "Ability  ";
            this.imgInventoryRank.BackColor = Color.Transparent;
            this.imgInventoryRank.Image = Resources.rank_S;
            this.imgInventoryRank.Location = new Point(4, 3);
            this.imgInventoryRank.Name = "imgInventoryRank";
            this.imgInventoryRank.Size = new Size(10, 10);
            this.imgInventoryRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryRank.TabIndex = 130;
            this.imgInventoryRank.TabStop = false;
            this.imgStar15.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar15.BackColor = Color.Transparent;
            this.imgStar15.Image = Resources.star_s2;
            this.imgStar15.Location = new Point(0xe0, 0x73);
            this.imgStar15.Name = "imgStar15";
            this.imgStar15.Size = new Size(0x10, 15);
            this.imgStar15.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar15.TabIndex = 0x81;
            this.imgStar15.TabStop = false;
            this.imgStar15.Visible = false;
            this.imgStar14.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar14.BackColor = Color.Transparent;
            this.imgStar14.Image = Resources.star_s2;
            this.imgStar14.Location = new Point(0xd1, 0x73);
            this.imgStar14.Name = "imgStar14";
            this.imgStar14.Size = new Size(0x10, 15);
            this.imgStar14.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar14.TabIndex = 0x80;
            this.imgStar14.TabStop = false;
            this.imgStar14.Visible = false;
            this.imgStar13.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar13.BackColor = Color.Transparent;
            this.imgStar13.Image = Resources.star_s2;
            this.imgStar13.Location = new Point(0xc2, 0x73);
            this.imgStar13.Name = "imgStar13";
            this.imgStar13.Size = new Size(0x10, 15);
            this.imgStar13.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar13.TabIndex = 0x7f;
            this.imgStar13.TabStop = false;
            this.imgStar13.Visible = false;
            this.imgStar12.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar12.BackColor = Color.Transparent;
            this.imgStar12.Image = Resources.star_s2;
            this.imgStar12.Location = new Point(0xb3, 0x73);
            this.imgStar12.Name = "imgStar12";
            this.imgStar12.Size = new Size(0x10, 15);
            this.imgStar12.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar12.TabIndex = 0x7e;
            this.imgStar12.TabStop = false;
            this.imgStar12.Visible = false;
            this.imgStar11.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar11.BackColor = Color.Transparent;
            this.imgStar11.Image = Resources.star_S;
            this.imgStar11.Location = new Point(0xa5, 0x73);
            this.imgStar11.Name = "imgStar11";
            this.imgStar11.Size = new Size(0x10, 15);
            this.imgStar11.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar11.TabIndex = 0x7d;
            this.imgStar11.TabStop = false;
            this.imgStar11.Visible = false;
            this.imgStar10.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar10.BackColor = Color.Transparent;
            this.imgStar10.Image = Resources.star_S;
            this.imgStar10.Location = new Point(150, 0x73);
            this.imgStar10.Name = "imgStar10";
            this.imgStar10.Size = new Size(0x10, 15);
            this.imgStar10.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar10.TabIndex = 0x7c;
            this.imgStar10.TabStop = false;
            this.imgStar10.Visible = false;
            this.imgStar9.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar9.BackColor = Color.Transparent;
            this.imgStar9.Image = Resources.star_S;
            this.imgStar9.Location = new Point(0x87, 0x73);
            this.imgStar9.Name = "imgStar9";
            this.imgStar9.Size = new Size(0x10, 15);
            this.imgStar9.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar9.TabIndex = 0x7b;
            this.imgStar9.TabStop = false;
            this.imgStar9.Visible = false;
            this.imgStar8.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar8.BackColor = Color.Transparent;
            this.imgStar8.Image = Resources.star_A;
            this.imgStar8.Location = new Point(120, 0x73);
            this.imgStar8.Name = "imgStar8";
            this.imgStar8.Size = new Size(0x10, 15);
            this.imgStar8.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar8.TabIndex = 0x7a;
            this.imgStar8.TabStop = false;
            this.imgStar8.Visible = false;
            this.imgStar7.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar7.BackColor = Color.Transparent;
            this.imgStar7.Image = Resources.star_A;
            this.imgStar7.Location = new Point(0x69, 0x73);
            this.imgStar7.Name = "imgStar7";
            this.imgStar7.Size = new Size(0x10, 15);
            this.imgStar7.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar7.TabIndex = 0x79;
            this.imgStar7.TabStop = false;
            this.imgStar7.Visible = false;
            this.imgStar6.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar6.BackColor = Color.Transparent;
            this.imgStar6.Image = Resources.star_A;
            this.imgStar6.Location = new Point(90, 0x73);
            this.imgStar6.Name = "imgStar6";
            this.imgStar6.Size = new Size(0x10, 15);
            this.imgStar6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar6.TabIndex = 120;
            this.imgStar6.TabStop = false;
            this.imgStar6.Visible = false;
            this.imgStar5.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar5.BackColor = Color.Transparent;
            this.imgStar5.Image = Resources.star_B;
            this.imgStar5.Location = new Point(0x4b, 0x73);
            this.imgStar5.Name = "imgStar5";
            this.imgStar5.Size = new Size(0x10, 15);
            this.imgStar5.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar5.TabIndex = 0x77;
            this.imgStar5.TabStop = false;
            this.imgStar5.Visible = false;
            this.imgStar4.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar4.BackColor = Color.Transparent;
            this.imgStar4.Image = Resources.star_B;
            this.imgStar4.Location = new Point(60, 0x73);
            this.imgStar4.Name = "imgStar4";
            this.imgStar4.Size = new Size(0x10, 15);
            this.imgStar4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar4.TabIndex = 0x76;
            this.imgStar4.TabStop = false;
            this.imgStar4.Visible = false;
            this.imgStar3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar3.BackColor = Color.Transparent;
            this.imgStar3.Image = Resources.star_B;
            this.imgStar3.Location = new Point(0x2d, 0x73);
            this.imgStar3.Name = "imgStar3";
            this.imgStar3.Size = new Size(0x10, 15);
            this.imgStar3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar3.TabIndex = 0x75;
            this.imgStar3.TabStop = false;
            this.imgStar3.Visible = false;
            this.imgStar2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar2.BackColor = Color.Transparent;
            this.imgStar2.Image = Resources.star_C;
            this.imgStar2.Location = new Point(30, 0x73);
            this.imgStar2.Name = "imgStar2";
            this.imgStar2.Size = new Size(0x10, 15);
            this.imgStar2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar2.TabIndex = 0x74;
            this.imgStar2.TabStop = false;
            this.imgStar2.Visible = false;
            this.imgStar1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar1.BackColor = Color.Transparent;
            this.imgStar1.Image = Resources.star_C;
            this.imgStar1.Location = new Point(15, 0x73);
            this.imgStar1.Name = "imgStar1";
            this.imgStar1.Size = new Size(0x10, 15);
            this.imgStar1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar1.TabIndex = 0x73;
            this.imgStar1.TabStop = false;
            this.imgStar1.Visible = false;
            this.imgStar0.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar0.BackColor = Color.Transparent;
            this.imgStar0.Image = Resources.star_C;
            this.imgStar0.Location = new Point(0, 0x73);
            this.imgStar0.Name = "imgStar0";
            this.imgStar0.Size = new Size(0x10, 15);
            this.imgStar0.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar0.TabIndex = 0x72;
            this.imgStar0.TabStop = false;
            this.imgStar0.Visible = false;
            this.imgInventoryWeaponManufacturer.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.imgInventoryWeaponManufacturer.BackColor = Color.Transparent;
            this.imgInventoryWeaponManufacturer.Image = Resources.manlogo_GRM;
            this.imgInventoryWeaponManufacturer.Location = new Point(0xff, 0);
            this.imgInventoryWeaponManufacturer.Name = "imgInventoryWeaponManufacturer";
            this.imgInventoryWeaponManufacturer.Size = new Size(0x11, 0x11);
            this.imgInventoryWeaponManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryWeaponManufacturer.TabIndex = 110;
            this.imgInventoryWeaponManufacturer.TabStop = false;
            this.txtInventoryGrinds.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtInventoryGrinds.BackColor = Color.Transparent;
            this.txtInventoryGrinds.Location = new Point(12, 0x94);
            this.txtInventoryGrinds.Name = "txtInventoryGrinds";
            this.txtInventoryGrinds.Size = new Size(0x5e, 0x12);
            this.txtInventoryGrinds.TabIndex = 0x6d;
            this.txtInventoryGrinds.Text = "(0)";
            this.txtInventoryGrinds.TextAlign = ContentAlignment.MiddleLeft;
            this.txtInventoryGrinds.Visible = false;
            this.txtInventoryName_jp.BackColor = Color.Transparent;
            this.txtInventoryName_jp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInventoryName_jp.Location = new Point(2, 0x12);
            this.txtInventoryName_jp.Name = "txtInventoryName_jp";
            this.txtInventoryName_jp.Size = new Size(0xe0, 0x12);
            this.txtInventoryName_jp.TabIndex = 0x6c;
            this.txtInventoryName_jp.Text = "-";
            this.imgInventoryElement.BackColor = Color.Transparent;
            this.imgInventoryElement.Cursor = Cursors.Default;
            this.imgInventoryElement.Image = Resources.element_neutral;
            this.imgInventoryElement.Location = new Point(14, 0x85);
            this.imgInventoryElement.Name = "imgInventoryElement";
            this.imgInventoryElement.Size = new Size(12, 12);
            this.imgInventoryElement.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryElement.TabIndex = 0x69;
            this.imgInventoryElement.TabStop = false;
            this.imgInventoryElement.Visible = false;
            this.txtInventoryPercent.AutoSize = true;
            this.txtInventoryPercent.BackColor = Color.Transparent;
            this.txtInventoryPercent.Location = new Point(0x1a, 0x84);
            this.txtInventoryPercent.Name = "txtInventoryPercent";
            this.txtInventoryPercent.Size = new Size(0x15, 13);
            this.txtInventoryPercent.TabIndex = 0x68;
            this.txtInventoryPercent.Text = "0%";
            this.txtInventoryPercent.Visible = false;
            this.txtInventoryQty.AutoSize = true;
            this.txtInventoryQty.BackColor = Color.Transparent;
            this.txtInventoryQty.Location = new Point(11, 0xcf);
            this.txtInventoryQty.Name = "txtInventoryQty";
            this.txtInventoryQty.Size = new Size(0x18, 13);
            this.txtInventoryQty.TabIndex = 0x6a;
            this.txtInventoryQty.Text = "0/0";
            this.imgInventoryItemIcon.BackColor = Color.Transparent;
            this.imgInventoryItemIcon.Image = Resources.armor_icon;
            this.imgInventoryItemIcon.Location = new Point(4, 3);
            this.imgInventoryItemIcon.Name = "imgInventoryItemIcon";
            this.imgInventoryItemIcon.Padding = new Padding(13, 0, 0, 0);
            this.imgInventoryItemIcon.Size = new Size(0x17, 10);
            this.imgInventoryItemIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryItemIcon.TabIndex = 0x6f;
            this.imgInventoryItemIcon.TabStop = false;
            this.txtInventoryName.BackColor = Color.Transparent;
            this.txtInventoryName.Location = new Point(15, 1);
            this.txtInventoryName.Name = "txtInventoryName";
            this.txtInventoryName.Padding = new Padding(13, 0, 0, 0);
            this.txtInventoryName.Size = new Size(0xd3, 0x12);
            this.txtInventoryName.TabIndex = 0x6b;
            this.txtInventoryName.Text = "-";
            this.txtInventoryInfinityItemText.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtInventoryInfinityItemText.AutoSize = true;
            this.txtInventoryInfinityItemText.BackColor = Color.Transparent;
            this.txtInventoryInfinityItemText.Location = new Point(0x100, 20);
            this.txtInventoryInfinityItemText.Name = "txtInventoryInfinityItemText";
            this.txtInventoryInfinityItemText.Size = new Size(13, 13);
            this.txtInventoryInfinityItemText.TabIndex = 0x71;
            this.txtInventoryInfinityItemText.Text = "?";
            this.txtInventoryInfinityItemText.Visible = false;
            this.imgInventoryInfinityItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.imgInventoryInfinityItem.BackColor = Color.Transparent;
            this.imgInventoryInfinityItem.Image = Resources.infinity_item;
            this.imgInventoryInfinityItem.Location = new Point(0xfc, 0x13);
            this.imgInventoryInfinityItem.Name = "imgInventoryInfinityItem";
            this.imgInventoryInfinityItem.Size = new Size(20, 0x10);
            this.imgInventoryInfinityItem.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryInfinityItem.TabIndex = 0x70;
            this.imgInventoryInfinityItem.TabStop = false;
            this.imgInventoryInfinityItem.Visible = false;
            this.pnlItemDetails.BackColor = Color.FromArgb(0x11, 0x31, 0x3e);
            this.pnlItemDetails.BackgroundImage = Resources.nagisa_panel_bg;
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
            this.pnlItemDetails.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.pnlItemDetails.ForeColor = Color.White;
            this.pnlItemDetails.Location = new Point(0x10, 0x81);
            this.pnlItemDetails.Name = "pnlItemDetails";
            this.pnlItemDetails.Size = new Size(0x11c, 0x87);
            this.pnlItemDetails.TabIndex = 0x88;
            this.pnlItemDetails.Visible = false;
            this.txtSelectedHex.BackColor = Color.White;
            this.txtSelectedHex.ForeColor = Color.Black;
            this.txtSelectedHex.Location = new Point(11, 0x75);
            this.txtSelectedHex.Name = "txtSelectedHex";
            this.txtSelectedHex.Size = new Size(0x4f, 13);
            this.txtSelectedHex.TabIndex = 0x89;
            this.txtSelectedHex.Text = "txtSelectedHex";
            this.imgDropListWeapon.BackColor = Color.Transparent;
            this.imgDropListWeapon.Cursor = Cursors.Hand;
            this.imgDropListWeapon.Image = Resources.rank_A;
            this.imgDropListWeapon.Location = new Point(13, 0x54);
            this.imgDropListWeapon.Name = "imgDropListWeapon";
            this.imgDropListWeapon.Size = new Size(10, 10);
            this.imgDropListWeapon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgDropListWeapon.TabIndex = 140;
            this.imgDropListWeapon.TabStop = false;
            this.imgDropListWeapon.Visible = false;
            this.imgDropListWeapon.Click += new EventHandler(this.imgDropListWeapon_Click);
            this.dropListWeapon.BackColor = Color.Transparent;
            this.dropListWeapon.Cursor = Cursors.Hand;
            this.dropListWeapon.Image = Resources.drop_button;
            this.dropListWeapon.Location = new Point(0xd0, 0x4c);
            this.dropListWeapon.Name = "dropListWeapon";
            this.dropListWeapon.Size = new Size(0x12, 0x1a);
            this.dropListWeapon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.dropListWeapon.TabIndex = 0x8b;
            this.dropListWeapon.TabStop = false;
            this.dropListWeapon.Click += new EventHandler(this.dropListWeapon_Click);
            this.txtWeapon.BackColor = Color.Transparent;
            this.txtWeapon.Cursor = Cursors.Hand;
            this.txtWeapon.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtWeapon.ForeColor = Color.White;
            this.txtWeapon.Location = new Point(0x25, 0x52);
            this.txtWeapon.Name = "txtWeapon";
            this.txtWeapon.Size = new Size(0xae, 0x11);
            this.txtWeapon.TabIndex = 0x8a;
            this.txtWeapon.Text = "Select Weapon";
            this.txtWeapon.Click += new EventHandler(this.txtWeapon_Click);
            this.txtSelectedWeapon.AutoSize = true;
            this.txtSelectedWeapon.BackColor = Color.White;
            this.txtSelectedWeapon.Location = new Point(12, 7);
            this.txtSelectedWeapon.Name = "txtSelectedWeapon";
            this.txtSelectedWeapon.Size = new Size(0x65, 13);
            this.txtSelectedWeapon.TabIndex = 0x8d;
            this.txtSelectedWeapon.Text = "txtSelectedWeapon";
            this.pnlDebug.BackColor = Color.Maroon;
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
            this.pnlDebug.Location = new Point(0x1c6, 5);
            this.pnlDebug.Name = "pnlDebug";
            this.pnlDebug.Size = new Size(0xaf, 0x103);
            this.pnlDebug.TabIndex = 0x8e;
            this.pnlDebug.Visible = false;
            this.picWeapon.BackColor = Color.Transparent;
            this.picWeapon.Location = new Point(0x135, 0x85);
            this.picWeapon.Name = "picWeapon";
            this.picWeapon.Size = new Size(160, 120);
            this.picWeapon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.picWeapon.TabIndex = 0x8f;
            this.picWeapon.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Resources.nagisa;
            this.BackgroundImageLayout = ImageLayout.None;
            base.ClientSize = new Size(480, 0x137);
            base.Controls.Add(this.pnlDebug);
            base.Controls.Add(this.pnlDropList);
            base.Controls.Add(this.dropListManufacturer);
            base.Controls.Add(this.dropListWeaponType);
            base.Controls.Add(this.dropListWeapon);
            base.Controls.Add(this.picWeapon);
            base.Controls.Add(this.imgDropListManufacturer);
            base.Controls.Add(this.txtManufacturer);
            base.Controls.Add(this.imgDropListWeaponType);
            base.Controls.Add(this.txtWeaponType);
            base.Controls.Add(this.pnlItemDetails);
            base.Controls.Add(this.imgDropListWeapon);
            base.Controls.Add(this.txtWeapon);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            this.MaximumSize = new Size(490, 0x157);
            base.MinimizeBox = false;
            this.MinimumSize = new Size(490, 0x157);
            base.Name = "weaponDbForm";
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "PSPo2se Weapon Database";
            base.FormClosing += new FormClosingEventHandler(this.weaponDbForm_FormClosing);
            base.Click += new EventHandler(this.weaponDbForm_Click);
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
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void loadDbWeaponLinks()
        {
            this.dbLinkCount = 0;
            for (int i = 0; i < this.parent.item_db_filled; i++)
            {
                if (this.parent.item_db.item[i].hex.Substring(6, 2) == "01")
                {
                    this.dbLink[this.dbLinkCount] = this.parent.item_db.item[i];
                    this.dbLinkCount++;
                }
            }
        }

        private void loadFirstWeaponInSelection()
        {
            this.txtWeapon.Text = "Select Weapon";
            this.txtSelectedWeapon.Text = "";
            this.imgDropListWeapon.Visible = false;
            this.pnlItemDetails.Visible = false;
            this.picWeapon.Image = null;
        }

        private void loadSelectedWeaponNamesView()
        {
            if ((this.txtManufacturer.Text != "") && (this.txtWeaponType.Text != ""))
            {
                string text = this.txtSelectedWeaponType.Text;
                string str2 = "";
                string str3 = "";
                string hex = "";
                for (int i = 0; i < 4; i++)
                {
                    str2 = i.ToString("X2");
                    if ((this.txtSelectedManufacturer.Text == "") || (str2 == this.txtSelectedManufacturer.Text))
                    {
                        for (int j = 0; j < 0x100; j++)
                        {
                            str3 = j.ToString("X2");
                            hex = str2 + str3 + text + "01";
                            int index = this.findItemIdInDbLinks(hex);
                            ListViewItem item = null;
                            if (index == -1)
                            {
                                if (this.chkUnknownWeapons.Checked)
                                {
                                    item = new ListViewItem("unk_" + hex, 4) {
                                        SubItems = { 
                                            hex ?? "",
                                            index
                                        }
                                    };
                                    this.dropListView.Items.Add(item);
                                }
                            }
                            else
                            {
                                string name = this.dbLink[index].name;
                                if (name == "")
                                {
                                    name = this.dbLink[index].name_jp;
                                }
                                item = (this.dbLink[index].rarity < 0) ? new ListViewItem(name, 4) : new ListViewItem(name, (int) this.parent.getItemRankFromRarity(this.dbLink[index].rarity));
                                item.SubItems.Add(hex ?? "");
                                item.SubItems.Add(index);
                                this.dropListView.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        private void showDropListView(dropListType type)
        {
            Point location = this.pnlDropList.Location;
            this.disableAllDropListButtons();
            this.selectedDropList = type;
            this.dropListView.Items.Clear();
            switch (this.selectedDropList)
            {
                case dropListType.weapon_type:
                {
                    int num = 1;
                    while (true)
                    {
                        if (num >= 0x1d)
                        {
                            location.X = 6;
                            location.Y = 0x2d;
                            this.dropListView.SmallImageList = this.weaponTypesImageList;
                            break;
                        }
                        ListViewItem item = new ListViewItem(this.parent.weaponEnumToName((pspo2seForm.weaponType) num), num - 1) {
                            SubItems = { num }
                        };
                        this.dropListView.Items.Add(item);
                        num++;
                    }
                    break;
                }
                case dropListType.manufacturer:
                {
                    int imageIndex = 0;
                    while (true)
                    {
                        if (imageIndex >= 4)
                        {
                            location.X = 6;
                            location.Y = 0x49;
                            this.dropListView.SmallImageList = this.manufacturerImageList;
                            break;
                        }
                        ListViewItem item2 = new ListViewItem(this.parent.enumToName(((pspo2seForm.weaponManufacturerType) imageIndex)), imageIndex) {
                            SubItems = { imageIndex }
                        };
                        this.dropListView.Items.Add(item2);
                        imageIndex++;
                    }
                    break;
                }
                case dropListType.weapon:
                    if (this.txtWeaponType.Text == "")
                    {
                        MessageBox.Show("You must select a weapon type first");
                        return;
                    }
                    location.X = 6;
                    location.Y = 0x65;
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

        private void showSelectedWeapon()
        {
            pspo2seForm.pageFields fields = this.getItemDetailsFields();
            fields.grp_details = null;
            fields.pnl_details = this.pnlItemDetails;
            fields.txt_hex = this.txtSelectedHex;
            if (this.txtSelectedWeapon.Text != "")
            {
                int index = int.Parse(this.txtSelectedWeapon.Text);
                pspo2seForm.itemDb_ItemClass class2 = null;
                if (index != -1)
                {
                    class2 = this.dbLink[index];
                    pspo2seForm.inventoryItemClass item = new pspo2seForm.inventoryItemClass {
                        hex = this.parent.run.hexAndMathFunction.reversehex(class2.hex, 8),
                        style = pspo2seForm.weaponStyleType.Melee
                    };
                    pspo2seForm.weaponType type = (pspo2seForm.weaponType) int.Parse(this.txtSelectedWeaponType.Text, NumberStyles.HexNumber);
                    if (type == pspo2seForm.weaponType.longbow)
                    {
                        item.style = pspo2seForm.weaponStyleType.Tech;
                    }
                    else
                    {
                        switch (type)
                        {
                            case pspo2seForm.weaponType.card:
                                item.style = pspo2seForm.weaponStyleType.Tech;
                                break;

                            case pspo2seForm.weaponType.rod:
                                item.style = pspo2seForm.weaponStyleType.Tech;
                                break;

                            case pspo2seForm.weaponType.wand:
                                item.style = pspo2seForm.weaponStyleType.Tech;
                                break;

                            case pspo2seForm.weaponType.tmag:
                                item.style = pspo2seForm.weaponStyleType.Tech;
                                break;

                            default:
                                break;
                        }
                    }
                    item.hex_reversed = class2.hex;
                    item.type = this.parent.getItemTypeFromHex(item.hex);
                    item.power = class2.power;
                    item.acc = class2.acc;
                    item.name = class2.name;
                    item.name_jp = class2.name_jp;
                    item.desc = class2.desc;
                    item.desc_jp = class2.desc_jp;
                    item.infinity_item = class2.infinity_item;
                    item.level = class2.level;
                    item.ext_power = class2.ext_power;
                    item.ext_acc = class2.ext_acc;
                    item.ext_level = class2.ext_level;
                    item.special = class2.special;
                    if (class2.special == "")
                    {
                        item.special = "DB_Error";
                    }
                    item.special_level = class2.special_level;
                    item.ext_special_level = class2.ext_special_level;
                    item.rarity = class2.rarity;
                    this.parent.displayItemInfo(fields, item);
                    fields.txt_hex.Text = "0x" + item.hex_reversed;
                    fields.txt_name.Text = item.name;
                    fields.txt_name_jp.Text = item.name_jp;
                    this.parent.displayItemImage(fields, item);
                    this.parent.displayItemStars(fields, item.rarity);
                    this.parent.displayItemInfo(fields, item);
                    this.txtSelectedWeaponType.Text = ((int) this.parent.getWeaponTypeFromHex(item.hex_reversed)).ToString("X2");
                    this.txtWeaponType.Text = this.parent.weaponEnumToName(this.parent.getWeaponTypeFromHex(item.hex_reversed));
                    this.imgDropListWeaponType.Image = this.parent.getWeaponImageFromType(this.parent.getWeaponTypeFromHex(item.hex_reversed));
                    this.imgDropListWeaponType.Visible = true;
                    string filename = this.parent.findImageFloatInList(item.hex_reversed);
                    this.picWeapon.Image = (filename == "") ? null : new Bitmap(filename);
                    this.updateHex(0, item.hex);
                    string add = item.rarity.ToString("X1");
                    if (add.Length < 2)
                    {
                        add = "0" + add;
                    }
                    add = (item.rarity >= 0) ? add.Substring(1, 1) : "0";
                    this.updateHex(0x1f, add);
                }
                else
                {
                    fields.pnl_details.Visible = false;
                }
            }
        }

        private void txtManufacturer_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.manufacturer);
        }

        private void txtWeapon_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.weapon);
        }

        private void txtWeaponType_Click(object sender, EventArgs e)
        {
            this.showDropListView(dropListType.weapon_type);
        }

        private void updateHex(int pos, string add)
        {
            if ((pos + add.Length) > this.hex.Length)
            {
                MessageBox.Show("Trying to write beyond the end of the hex");
            }
            else
            {
                string str = this.hex.Substring(0, pos) + add + this.hex.Substring(pos + add.Length, (this.hex.Length - pos) - add.Length);
                this.hex = str;
                this.txtItemHex.Text = this.displayCleanHex(this.hex);
            }
        }

        private void weaponDbForm_Click(object sender, EventArgs e)
        {
            if (this.selectedDropList != dropListType.none)
            {
                this.pnlDropList.Visible = false;
                this.enableAllDropListButtons();
                this.selectedDropList = dropListType.none;
            }
        }

        private void weaponDbForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.Hide();
        }

        private void weaponListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.showSelectedWeapon();
        }

        private enum dropListType
        {
            none,
            weapon_type,
            manufacturer,
            weapon
        }
    }
}

