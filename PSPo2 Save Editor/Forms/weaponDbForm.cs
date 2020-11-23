using pspo2seSaveEditorProgram.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class weaponDbForm : Form
    {
        private PictureBox picWeapon;
        private pspo2seForm parent;
        private pspo2seForm.itemDb_ItemClass[] dbLink = new pspo2seForm.itemDb_ItemClass[4000];
        private int dbLinkCount;
        private weaponDbForm.dropListType selectedDropList;
        private string hex = "";

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
            this.picWeapon.Image = (Image)null;
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
                            ListViewItem listViewItem = this.dbLink[itemIdInDbLinks].rarity < 0 ? new ListViewItem(text2, 4) : new ListViewItem(text2, (int)this.parent.getItemRankFromRarity(this.dbLink[itemIdInDbLinks].rarity));
                            listViewItem.SubItems.Add(hex ?? "");
                            listViewItem.SubItems.Add(string.Concat((object)itemIdInDbLinks));
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
                int num = (int)MessageBox.Show("Trying to write beyond the end of the hex");
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

        public void dropListButton_MouseOver(object sender, EventArgs e) => ((PictureBox)sender).Image = (Image)Resources.drop_button_over;

        public void dropListButton_MouseOut(object sender, EventArgs e) => ((PictureBox)sender).Image = (Image)Resources.drop_button;

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
                        this.dropListView.Items.Add(new ListViewItem(this.parent.weaponEnumToName((pspo2seForm.weaponType)index), index - 1)
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
                        this.dropListView.Items.Add(new ListViewItem(this.parent.enumToName(string.Concat((object)(pspo2seForm.weaponManufacturerType)imageIndex)), imageIndex)
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
                        int num = (int)MessageBox.Show("You must select a weapon type first");
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
                    this.imgDropListWeaponType.Image = this.parent.getWeaponImageFromType((pspo2seForm.weaponType)int.Parse(this.dropListView.SelectedItems[0].SubItems[1].Text));
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
                    this.imgDropListManufacturer.Image = this.parent.getWeaponManufacturerImage((pspo2seForm.weaponManufacturerType)int.Parse(this.dropListView.SelectedItems[0].SubItems[1].Text));
                    this.imgDropListManufacturer.Visible = true;
                    this.updateHex(6, this.txtSelectedManufacturer.Text);
                    this.loadFirstWeaponInSelection();
                    break;
                case weaponDbForm.dropListType.weapon:
                    this.txtWeapon.Text = this.dropListView.SelectedItems[0].Text;
                    this.txtSelectedWeapon.Text = this.dropListView.SelectedItems[0].SubItems[2].Text;
                    if (this.dbLink[int.Parse(this.txtSelectedWeapon.Text)].rarity < 0)
                    {
                        this.imgDropListWeapon.Image = (Image)Resources.rank_Unknown;
                    }
                    else
                    {
                        switch (this.parent.getItemRankFromRarity(this.dbLink[int.Parse(this.txtSelectedWeapon.Text)].rarity))
                        {
                            case pspo2seForm.itemRankType.c:
                                this.imgDropListWeapon.Image = (Image)Resources.rank_C;
                                break;
                            case pspo2seForm.itemRankType.b:
                                this.imgDropListWeapon.Image = (Image)Resources.rank_B;
                                break;
                            case pspo2seForm.itemRankType.a:
                                this.imgDropListWeapon.Image = (Image)Resources.rank_A;
                                break;
                            case pspo2seForm.itemRankType.s:
                                this.imgDropListWeapon.Image = (Image)Resources.rank_S;
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
            grp_details = (GroupBox)null,
            txt_grinds = this.txtInventoryGrinds,
            txt_percent = this.txtInventoryPercent,
            txt_hex = this.txtSelectedHex,
            txt_meseta = (Label)null,
            txt_qty = this.txtInventoryQty,
            txt_special = this.txtInventorySpecial,
            txt_effect = this.txtInventoryEffect,
            txt_atk = this.txtInventoryATK,
            txt_acc = this.txtInventoryACC,
            txt_level = this.txtInventoryLevel,
            btn_delete = (Button)null,
            btn_export_selected = (Button)null,
            btn_import_selected = (Button)null,
            btn_withdraw = (Button)null,
            pnl_details = (Panel)null
        };

        private void showSelectedWeapon()
        {
            pspo2seForm.pageFields itemDetailsFields = this.getItemDetailsFields();
            itemDetailsFields.grp_details = (GroupBox)null;
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
                switch ((pspo2seForm.weaponType)int.Parse(this.txtSelectedWeaponType.Text, NumberStyles.HexNumber))
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
                this.txtSelectedWeaponType.Text = ((int)this.parent.getWeaponTypeFromHex(inventoryItemClass.hex_reversed)).ToString("X2");
                this.txtWeaponType.Text = this.parent.weaponEnumToName(this.parent.getWeaponTypeFromHex(inventoryItemClass.hex_reversed));
                this.imgDropListWeaponType.Image = this.parent.getWeaponImageFromType(this.parent.getWeaponTypeFromHex(inventoryItemClass.hex_reversed));
                this.imgDropListWeaponType.Visible = true;
                string imageFloatInList = this.parent.findImageFloatInList(inventoryItemClass.hex_reversed);
                this.picWeapon.Image = !(imageFloatInList != "") ? (Image)null : (Image)new Bitmap(imageFloatInList);
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
                    using (BinaryWriter binaryWriter = new BinaryWriter((Stream)fileStream))
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
                int num = (int)MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            int num1 = (int)MessageBox.Show("The item was created successfully.\n\nPlease remember that you should not used modified items online as you may get banned.", "Item created successfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
