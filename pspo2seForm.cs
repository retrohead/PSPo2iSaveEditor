using CSEncryptDecrypt;
using FolderZipper;
using pspo2seSaveEditorProgram.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class pspo2seForm : Form
    {
        private const int IMAGE_FLOAT_Y_MOVE = 130;
        private const int IMAGE_FLOAT_SPEED = 3;
        private const int MAX_IMAGES = 1500;
        private const string SUB_DIR = "weapon_images/";
        public const int EXPLEVEL_DB_SIZE = 355;
        public const int EXPTYPE_DB_SIZE = 55;
        public const int MAX_APP_DOWNLOAD_FILES = 20;
        private int imageFloat_Y_hidden;
        private int imageFloat_Y_visible;
        private string[] IMAGE_FLOAT_FILE_EXT = new string[2]
        {
      "jpg",
      "png"
        };
        private bool imageFloatImageIsOk;
        private bool imageFloatShowing;
        private bool allowImageFloatMove = true;
        private pspo2seForm.imageFloatBox imageFloater = new pspo2seForm.imageFloatBox();
        public int exp_db_filled;
        public int type_db_filled;
        private bool shownCorruptExpCsv;
        private bool shownCorruptExpTypeCsv;
        public pspo2seForm.expDbType exp_db = new pspo2seForm.expDbType();
        public pspo2seForm.typeexpDbType typeexp_db = new pspo2seForm.typeexpDbType();
        private bool firstInstall;
        private bool databasesOk = true;
        private bool saveOk;
        public int selectInventoryItemAfterLoad = -1;
        public int selectItemAfterLoad = -1;
        public encryptRoutineType encryptor = new encryptRoutineType();
        public pspo2seForm.runFunctionsType run = new pspo2seForm.runFunctionsType();
        public pspo2seAbilityDb abilityDb = new pspo2seAbilityDb();
        private int selectedInventoryItem = -1;
        private int selectedStorageItem = -1;
        public pspo2seEntryForm entryForm = new pspo2seEntryForm();
        private pspo2seTypeAbilitiesForm abilitiesForm = new pspo2seTypeAbilitiesForm();
        private weaponDbForm weaponDatabaseForm = new weaponDbForm();
        private changeLogForm changelogForm = new changeLogForm();
        private pspo2seInfinityMissionForm infinityMissionForm = new pspo2seInfinityMissionForm();
        private updateInfoForm updateViewer = new updateInfoForm();
        public pspo2seForm.saveDataType saveData = new pspo2seForm.saveDataType();
        public pspo2seSettings mainSettings = new pspo2seSettings();
        public bool firstload = true;
        public int[] savedata_decimal_array = new int[301352];
        public int savedata_decimal_array_filled;
        public int savedata_decimal_array_read_pos;
        public int chunkPos;
        private bool allowDownload = true;
        private byte[] downloadedData = new byte[512000];
        private string downloadedDataName;
        public bool firstboot = true;
        public pspo2seForm.itemDbClass item_db = new pspo2seForm.itemDbClass();
        public int item_db_filled;

        private void loadImageFloaterImages()
        {
            string path = "data/weapon_images/";
            this.imageFloater.filled = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (string str in this.IMAGE_FLOAT_FILE_EXT)
            {
                foreach (FileInfo file in directoryInfo.GetFiles("*." + str))
                {
                    this.imageFloater.imagelist[this.imageFloater.filled] = file;
                    ++this.imageFloater.filled;
                }
            }
        }

        private void initImageFloater()
        {
            this.imageFloat_Y_visible = this.panelImageFloater.Location.Y;
            this.imageFloat_Y_hidden = this.panelImageFloater.Location.Y - 130;
            this.imageFloater.pnlloc.X = this.panelImageFloater.Location.X;
            this.imageFloater.pnlloc.Y = this.imageFloat_Y_hidden;
            this.imageFloater.grploc.X = this.grpImageFloater.Location.X;
            this.imageFloater.grploc.Y = this.imageFloat_Y_hidden - 6;
            this.panelImageFloater.Location = this.imageFloater.pnlloc;
            this.grpImageFloater.Location = this.imageFloater.grploc;
            this.imageFloater.picBox = this.imgFloater;
            this.loadImageFloaterImages();
        }

        private void makeImageFloaterHidden()
        {
            Application.DoEvents();
            while (this.imageFloater.pnlloc.Y > this.imageFloat_Y_hidden)
            {
                this.imageFloater.pnlloc.Y -= 3;
                if (this.imageFloater.pnlloc.Y < this.imageFloat_Y_hidden)
                    this.imageFloater.pnlloc.Y = this.imageFloat_Y_hidden;
                this.imageFloater.grploc.Y = this.imageFloater.pnlloc.Y - 6;
                this.panelImageFloater.Location = this.imageFloater.pnlloc;
                this.grpImageFloater.Location = this.imageFloater.grploc;
                Application.DoEvents();
            }
            this.imageFloatShowing = false;
            this.allowImageFloatMove = true;
            this.inventoryViewPages.Enabled = true;
            this.storageViewPages.Enabled = true;
            this.tabArea.Enabled = true;
        }

        private void makeImageFloaterVisible()
        {
            Application.DoEvents();
            while (this.imageFloater.pnlloc.Y < this.imageFloat_Y_visible)
            {
                this.imageFloater.pnlloc.Y += 3;
                if (this.imageFloater.pnlloc.Y > this.imageFloat_Y_visible)
                    this.imageFloater.pnlloc.Y = this.imageFloat_Y_visible;
                this.imageFloater.grploc.Y = this.imageFloater.pnlloc.Y - 6;
                this.panelImageFloater.Location = this.imageFloater.pnlloc;
                this.grpImageFloater.Location = this.imageFloater.grploc;
                Application.DoEvents();
            }
            this.imageFloatShowing = true;
            this.allowImageFloatMove = true;
            this.inventoryViewPages.Enabled = true;
            this.storageViewPages.Enabled = true;
            this.tabArea.Enabled = true;
        }

        private void moveImageFloater()
        {
            this.allowImageFloatMove = false;
            this.tabArea.Enabled = false;
            if (this.imageFloatShowing)
                this.makeImageFloaterHidden();
            else
                this.makeImageFloaterVisible();
        }

        private void openImageFloater()
        {
            if (!this.imageFloaterClosed() || !this.imageFloatImageIsOk || this.tabArea.SelectedTab != this.tabPageInventory && this.tabArea.SelectedTab != this.tabPageStorage || this.inventoryViewPages.SelectedIndex != 0 && this.storageViewPages.SelectedIndex != 0)
                return;
            this.moveImageFloater();
        }

        private void closeImageFloater()
        {
            if (!this.imageFloaterOpen())
                return;
            this.moveImageFloater();
        }

        private bool imageFloaterOpen() => this.imageFloatShowing || !this.allowImageFloatMove;

        private bool imageFloaterClosed() => !this.imageFloatShowing || !this.allowImageFloatMove;

        public string findImageFloatInList(string hex)
        {
            for (int index = 0; index < this.imageFloater.filled; ++index)
            {
                if (hex.ToLower() == this.imageFloater.imagelist[index].Name.Substring(0, 8).ToLower())
                {
                    this.imageFloatImageIsOk = true;
                    return this.imageFloater.imagelist[index].FullName;
                }
            }
            this.imageFloatImageIsOk = false;
            return "";
        }

        private void changeImageFloater(string hex)
        {
            string imageFloatInList = this.findImageFloatInList(hex);
            if (this.imageFloatImageIsOk)
            {
                this.imageFloater.picBox.Image = (Image)new Bitmap(imageFloatInList);
                this.openImageFloater();
            }
            else
                this.closeImageFloater();
        }

        public pspo2seForm.typeSectionFields getTypeSectionFields(TabPage page)
        {
            pspo2seForm.typeSectionFields typeSectionFields = new pspo2seForm.typeSectionFields();
            if (page == this.tabPageHunter)
            {
                typeSectionFields.txtLevel = this.txtHuLevel;
                typeSectionFields.txtExp = this.txtHuExp;
                typeSectionFields.expBar = this.txtHuExpBar;
                typeSectionFields.grpExtend = this.grpHuTypeExtend;
            }
            else if (page == this.tabPageRanger)
            {
                typeSectionFields.txtLevel = this.txtRaLevel;
                typeSectionFields.txtExp = this.txtRaExp;
                typeSectionFields.expBar = this.txtRaExpBar;
                typeSectionFields.grpExtend = this.grpRaTypeExtend;
            }
            else if (page == this.tabPageForce)
            {
                typeSectionFields.txtLevel = this.txtFoLevel;
                typeSectionFields.txtExp = this.txtFoExp;
                typeSectionFields.expBar = this.txtFoExpBar;
                typeSectionFields.grpExtend = this.grpFoTypeExtend;
            }
            else if (page == this.tabPageVanguard)
            {
                typeSectionFields.txtLevel = this.txtVaLevel;
                typeSectionFields.txtExp = this.txtVaExp;
                typeSectionFields.expBar = this.txtVaExpBar;
                typeSectionFields.grpExtend = this.grpVaTypeExtend;
            }
            return typeSectionFields;
        }

        public pspo2seForm.pageFields getPageFields(TabPage page, bool inDatabase = false)
        {
            pspo2seForm.pageFields pageFields = new pspo2seForm.pageFields();
            if (page == this.tabPageInventory)
            {
                pageFields.img_rank = this.imgInventoryRank;
                pageFields.img_item = this.imgInventoryItemIcon;
                pageFields.img_manufaturer = this.imgInventoryWeaponManufacturer;
                pageFields.img_infinity_item = this.imgInventoryInfinityItem;
                pageFields.img_element = this.imgInventoryElement;
                pageFields.img_star_0 = this.imgStar0;
                pageFields.img_star_1 = this.imgStar1;
                pageFields.img_star_2 = this.imgStar2;
                pageFields.img_star_3 = this.imgStar3;
                pageFields.img_star_4 = this.imgStar4;
                pageFields.img_star_5 = this.imgStar5;
                pageFields.img_star_6 = this.imgStar6;
                pageFields.img_star_7 = this.imgStar7;
                pageFields.img_star_8 = this.imgStar8;
                pageFields.img_star_9 = this.imgStar9;
                pageFields.img_star_10 = this.imgStar10;
                pageFields.img_star_11 = this.imgStar11;
                pageFields.img_star_12 = this.imgStar12;
                pageFields.img_star_13 = this.imgStar13;
                pageFields.img_star_14 = this.imgStar14;
                pageFields.img_star_15 = this.imgStar15;
                pageFields.txt_infinity_item = this.txtInventoryInfinityItemText;
                pageFields.txt_name = this.txtInventoryName;
                pageFields.txt_name_jp = this.txtInventoryName_jp;
                pageFields.grp_details = this.grpInventoryItemDetails;
                pageFields.txt_grinds = this.txtInventoryGrinds;
                pageFields.txt_percent = this.txtInventoryPercent;
                pageFields.txt_hex = this.txtInventoryHex;
                pageFields.txt_meseta = this.txtInventoryMeseta;
                pageFields.txt_qty = this.txtInventoryQty;
                pageFields.txt_special = this.txtInventorySpecial;
                pageFields.txt_effect = this.txtInventoryEffect;
                pageFields.txt_atk = this.txtInventoryATK;
                pageFields.txt_acc = this.txtInventoryACC;
                pageFields.txt_level = this.txtInventoryLevel;
                pageFields.btn_delete = this.btnInventoryDelete;
                pageFields.btn_export_selected = this.btnInventoryExportSelected;
                pageFields.btn_import_selected = this.btnInventoryImportSelected;
                pageFields.chk_delete_export = this.chkDeleteExportInventory;
                pageFields.btn_withdraw = this.btnInventoryDeposit;
                pageFields.pnl_details = (Panel)null;
            }
            else if (page == this.tabPageStorage)
            {
                pageFields.img_rank = this.imgStorageRank;
                pageFields.img_item = this.imgStorageItemIcon;
                pageFields.img_manufaturer = this.imgStorageWeaponManufacturer;
                pageFields.img_infinity_item = this.imgStorageInfinityItem;
                pageFields.img_element = this.imgStorageElement;
                pageFields.img_star_0 = this.imgStorageStar0;
                pageFields.img_star_1 = this.imgStorageStar1;
                pageFields.img_star_2 = this.imgStorageStar2;
                pageFields.img_star_3 = this.imgStorageStar3;
                pageFields.img_star_4 = this.imgStorageStar4;
                pageFields.img_star_5 = this.imgStorageStar5;
                pageFields.img_star_6 = this.imgStorageStar6;
                pageFields.img_star_7 = this.imgStorageStar7;
                pageFields.img_star_8 = this.imgStorageStar8;
                pageFields.img_star_9 = this.imgStorageStar9;
                pageFields.img_star_10 = this.imgStorageStar10;
                pageFields.img_star_11 = this.imgStorageStar11;
                pageFields.img_star_12 = this.imgStorageStar12;
                pageFields.img_star_13 = this.imgStorageStar13;
                pageFields.img_star_14 = this.imgStorageStar14;
                pageFields.img_star_15 = this.imgStorageStar15;
                pageFields.txt_infinity_item = this.txtStorageInfinityItemText;
                pageFields.txt_name = this.txtStorageName;
                pageFields.txt_name_jp = this.txtStorageName_jp;
                pageFields.grp_details = this.grpStorageItemDetails;
                pageFields.txt_grinds = this.txtStorageGrinds;
                pageFields.txt_percent = this.txtStoragePercent;
                pageFields.txt_hex = this.txtStorageHex;
                pageFields.txt_meseta = this.txtStorageMeseta;
                pageFields.txt_qty = this.txtStorageQty;
                pageFields.txt_special = this.txtStorageSpecial;
                pageFields.txt_effect = this.txtStorageEffect;
                pageFields.txt_atk = this.txtStorageATK;
                pageFields.txt_acc = this.txtStorageACC;
                pageFields.txt_level = this.txtStorageLevel;
                pageFields.btn_delete = this.btnStorageDelete;
                pageFields.btn_export_selected = this.btnStorageExportSelected;
                pageFields.btn_import_selected = this.btnStorageImportSelected;
                pageFields.chk_delete_export = this.chkDeleteExportStorage;
                pageFields.btn_withdraw = this.btnStorageWithdraw;
                pageFields.pnl_details = (Panel)null;
            }
            else
            {
                int num = (int)MessageBox.Show("The selected page for getFields was not recognised: " + (object)page);
            }
            return pageFields;
        }

        public pspo2seForm.typeWeaponRankFields getTypeWeaponExtendFields(TabPage page)
        {
            pspo2seForm.typeWeaponRankFields weaponRankFields = new pspo2seForm.typeWeaponRankFields();
            if (page == this.tabPageHunter)
            {
                weaponRankFields.imgWeap[1] = this.imgHuSword;
                weaponRankFields.imgWeap[2] = this.imgHuKnuckles;
                weaponRankFields.imgWeap[3] = this.imgHuSpear;
                weaponRankFields.imgWeap[4] = this.imgHuDblSaber;
                weaponRankFields.imgWeap[5] = this.imgHuAxe;
                weaponRankFields.imgWeap[6] = this.imgHuSabers;
                weaponRankFields.imgWeap[7] = this.imgHuDaggers;
                weaponRankFields.imgWeap[8] = this.imgHuClaws;
                weaponRankFields.imgWeap[9] = this.imgHuSaber;
                weaponRankFields.imgWeap[10] = this.imgHuDagger;
                weaponRankFields.imgWeap[11] = this.imgHuClaw;
                weaponRankFields.imgWeap[12] = this.imgHuWhip;
                weaponRankFields.imgWeap[13] = this.imgHuSlicer;
                weaponRankFields.imgWeap[14] = this.imgHuRifle;
                weaponRankFields.imgWeap[15] = this.imgHuShotgun;
                weaponRankFields.imgWeap[16] = this.imgHuLongbow;
                weaponRankFields.imgWeap[17] = this.imgHuGrenade;
                weaponRankFields.imgWeap[18] = this.imgHuLaser;
                weaponRankFields.imgWeap[19] = this.imgHuHandguns;
                weaponRankFields.imgWeap[20] = this.imgHuHandgun;
                weaponRankFields.imgWeap[21] = this.imgHuCrossbow;
                weaponRankFields.imgWeap[22] = this.imgHuCards;
                weaponRankFields.imgWeap[23] = this.imgHuMachinegun;
                weaponRankFields.imgWeap[27] = this.imgHuRmag;
                weaponRankFields.imgWeap[24] = this.imgHuRod;
                weaponRankFields.imgWeap[25] = this.imgHuWand;
                weaponRankFields.imgWeap[26] = this.imgHuTmag;
                weaponRankFields.imgWeap[28] = this.imgHuShield;
                weaponRankFields.imgRank[1] = this.imgHuSwordRank;
                weaponRankFields.imgRank[2] = this.imgHuKnucklesRank;
                weaponRankFields.imgRank[3] = this.imgHuSpearRank;
                weaponRankFields.imgRank[4] = this.imgHuDblSaberRank;
                weaponRankFields.imgRank[5] = this.imgHuAxeRank;
                weaponRankFields.imgRank[6] = this.imgHuSabersRank;
                weaponRankFields.imgRank[7] = this.imgHuDaggersRank;
                weaponRankFields.imgRank[8] = this.imgHuClawsRank;
                weaponRankFields.imgRank[9] = this.imgHuSaberRank;
                weaponRankFields.imgRank[10] = this.imgHuDaggerRank;
                weaponRankFields.imgRank[11] = this.imgHuClawRank;
                weaponRankFields.imgRank[12] = this.imgHuWhipRank;
                weaponRankFields.imgRank[13] = this.imgHuSlicerRank;
                weaponRankFields.imgRank[14] = this.imgHuRifleRank;
                weaponRankFields.imgRank[15] = this.imgHuShotgunRank;
                weaponRankFields.imgRank[16] = this.imgHuLongbowRank;
                weaponRankFields.imgRank[17] = this.imgHuGrenadeRank;
                weaponRankFields.imgRank[18] = this.imgHuLaserRank;
                weaponRankFields.imgRank[19] = this.imgHuHandgunsRank;
                weaponRankFields.imgRank[20] = this.imgHuHandgunRank;
                weaponRankFields.imgRank[21] = this.imgHuCrossbowRank;
                weaponRankFields.imgRank[22] = this.imgHuCardsRank;
                weaponRankFields.imgRank[23] = this.imgHuMachinegunRank;
                weaponRankFields.imgRank[27] = this.imgHuRmagRank;
                weaponRankFields.imgRank[24] = this.imgHuRodRank;
                weaponRankFields.imgRank[25] = this.imgHuWandRank;
                weaponRankFields.imgRank[26] = this.imgHuTmagRank;
                weaponRankFields.imgRank[28] = this.imgHuShieldRank;
            }
            else if (page == this.tabPageRanger)
            {
                weaponRankFields.imgWeap[1] = this.imgRaSword;
                weaponRankFields.imgWeap[2] = this.imgRaKnuckles;
                weaponRankFields.imgWeap[3] = this.imgRaSpear;
                weaponRankFields.imgWeap[4] = this.imgRaDblSaber;
                weaponRankFields.imgWeap[5] = this.imgRaAxe;
                weaponRankFields.imgWeap[6] = this.imgRaSabers;
                weaponRankFields.imgWeap[7] = this.imgRaDaggers;
                weaponRankFields.imgWeap[8] = this.imgRaClaws;
                weaponRankFields.imgWeap[9] = this.imgRaSaber;
                weaponRankFields.imgWeap[10] = this.imgRaDagger;
                weaponRankFields.imgWeap[11] = this.imgRaClaw;
                weaponRankFields.imgWeap[12] = this.imgRaWhip;
                weaponRankFields.imgWeap[13] = this.imgRaSlicer;
                weaponRankFields.imgWeap[14] = this.imgRaRifle;
                weaponRankFields.imgWeap[15] = this.imgRaShotgun;
                weaponRankFields.imgWeap[16] = this.imgRaLongbow;
                weaponRankFields.imgWeap[17] = this.imgRaGrenade;
                weaponRankFields.imgWeap[18] = this.imgRaLaser;
                weaponRankFields.imgWeap[19] = this.imgRaHandguns;
                weaponRankFields.imgWeap[20] = this.imgRaHandgun;
                weaponRankFields.imgWeap[21] = this.imgRaCrossbow;
                weaponRankFields.imgWeap[22] = this.imgRaCards;
                weaponRankFields.imgWeap[23] = this.imgRaMachinegun;
                weaponRankFields.imgWeap[27] = this.imgRaRmag;
                weaponRankFields.imgWeap[24] = this.imgRaRod;
                weaponRankFields.imgWeap[25] = this.imgRaWand;
                weaponRankFields.imgWeap[26] = this.imgRaTmag;
                weaponRankFields.imgWeap[28] = this.imgRaShield;
                weaponRankFields.imgRank[1] = this.imgRaSwordRank;
                weaponRankFields.imgRank[2] = this.imgRaKnucklesRank;
                weaponRankFields.imgRank[3] = this.imgRaSpearRank;
                weaponRankFields.imgRank[4] = this.imgRaDblSaberRank;
                weaponRankFields.imgRank[5] = this.imgRaAxeRank;
                weaponRankFields.imgRank[6] = this.imgRaSabersRank;
                weaponRankFields.imgRank[7] = this.imgRaDaggersRank;
                weaponRankFields.imgRank[8] = this.imgRaClawsRank;
                weaponRankFields.imgRank[9] = this.imgRaSaberRank;
                weaponRankFields.imgRank[10] = this.imgRaDaggerRank;
                weaponRankFields.imgRank[11] = this.imgRaClawRank;
                weaponRankFields.imgRank[12] = this.imgRaWhipRank;
                weaponRankFields.imgRank[13] = this.imgRaSlicerRank;
                weaponRankFields.imgRank[14] = this.imgRaRifleRank;
                weaponRankFields.imgRank[15] = this.imgRaShotgunRank;
                weaponRankFields.imgRank[16] = this.imgRaLongbowRank;
                weaponRankFields.imgRank[17] = this.imgRaGrenadeRank;
                weaponRankFields.imgRank[18] = this.imgRaLaserRank;
                weaponRankFields.imgRank[19] = this.imgRaHandgunsRank;
                weaponRankFields.imgRank[20] = this.imgRaHandgunRank;
                weaponRankFields.imgRank[21] = this.imgRaCrossbowRank;
                weaponRankFields.imgRank[22] = this.imgRaCardsRank;
                weaponRankFields.imgRank[23] = this.imgRaMachinegunRank;
                weaponRankFields.imgRank[27] = this.imgRaRmagRank;
                weaponRankFields.imgRank[24] = this.imgRaRodRank;
                weaponRankFields.imgRank[25] = this.imgRaWandRank;
                weaponRankFields.imgRank[26] = this.imgRaTmagRank;
                weaponRankFields.imgRank[28] = this.imgRaShieldRank;
            }
            else if (page == this.tabPageForce)
            {
                weaponRankFields.imgWeap[1] = this.imgFoSword;
                weaponRankFields.imgWeap[2] = this.imgFoKnuckles;
                weaponRankFields.imgWeap[3] = this.imgFoSpear;
                weaponRankFields.imgWeap[4] = this.imgFoDblSaber;
                weaponRankFields.imgWeap[5] = this.imgFoAxe;
                weaponRankFields.imgWeap[6] = this.imgFoSabers;
                weaponRankFields.imgWeap[7] = this.imgFoDaggers;
                weaponRankFields.imgWeap[8] = this.imgFoClaws;
                weaponRankFields.imgWeap[9] = this.imgFoSaber;
                weaponRankFields.imgWeap[10] = this.imgFoDagger;
                weaponRankFields.imgWeap[11] = this.imgFoClaw;
                weaponRankFields.imgWeap[12] = this.imgFoWhip;
                weaponRankFields.imgWeap[13] = this.imgFoSlicer;
                weaponRankFields.imgWeap[14] = this.imgFoRifle;
                weaponRankFields.imgWeap[15] = this.imgFoShotgun;
                weaponRankFields.imgWeap[16] = this.imgFoLongbow;
                weaponRankFields.imgWeap[17] = this.imgFoGrenade;
                weaponRankFields.imgWeap[18] = this.imgFoLaser;
                weaponRankFields.imgWeap[19] = this.imgFoHandguns;
                weaponRankFields.imgWeap[20] = this.imgFoHandgun;
                weaponRankFields.imgWeap[21] = this.imgFoCrossbow;
                weaponRankFields.imgWeap[22] = this.imgFoCards;
                weaponRankFields.imgWeap[23] = this.imgFoMachinegun;
                weaponRankFields.imgWeap[27] = this.imgFoRmag;
                weaponRankFields.imgWeap[24] = this.imgFoRod;
                weaponRankFields.imgWeap[25] = this.imgFoWand;
                weaponRankFields.imgWeap[26] = this.imgFoTmag;
                weaponRankFields.imgWeap[28] = this.imgFoShield;
                weaponRankFields.imgRank[1] = this.imgFoSwordRank;
                weaponRankFields.imgRank[2] = this.imgFoKnucklesRank;
                weaponRankFields.imgRank[3] = this.imgFoSpearRank;
                weaponRankFields.imgRank[4] = this.imgFoDblSaberRank;
                weaponRankFields.imgRank[5] = this.imgFoAxeRank;
                weaponRankFields.imgRank[6] = this.imgFoSabersRank;
                weaponRankFields.imgRank[7] = this.imgFoDaggersRank;
                weaponRankFields.imgRank[8] = this.imgFoClawsRank;
                weaponRankFields.imgRank[9] = this.imgFoSaberRank;
                weaponRankFields.imgRank[10] = this.imgFoDaggerRank;
                weaponRankFields.imgRank[11] = this.imgFoClawRank;
                weaponRankFields.imgRank[12] = this.imgFoWhipRank;
                weaponRankFields.imgRank[13] = this.imgFoSlicerRank;
                weaponRankFields.imgRank[14] = this.imgFoRifleRank;
                weaponRankFields.imgRank[15] = this.imgFoShotgunRank;
                weaponRankFields.imgRank[16] = this.imgFoLongbowRank;
                weaponRankFields.imgRank[17] = this.imgFoGrenadeRank;
                weaponRankFields.imgRank[18] = this.imgFoLaserRank;
                weaponRankFields.imgRank[19] = this.imgFoHandgunsRank;
                weaponRankFields.imgRank[20] = this.imgFoHandgunRank;
                weaponRankFields.imgRank[21] = this.imgFoCrossbowRank;
                weaponRankFields.imgRank[22] = this.imgFoCardsRank;
                weaponRankFields.imgRank[23] = this.imgFoMachinegunRank;
                weaponRankFields.imgRank[27] = this.imgFoRmagRank;
                weaponRankFields.imgRank[24] = this.imgFoRodRank;
                weaponRankFields.imgRank[25] = this.imgFoWandRank;
                weaponRankFields.imgRank[26] = this.imgFoTmagRank;
                weaponRankFields.imgRank[28] = this.imgFoShieldRank;
            }
            else if (page == this.tabPageVanguard)
            {
                weaponRankFields.imgWeap[1] = this.imgVaSword;
                weaponRankFields.imgWeap[2] = this.imgVaKnuckles;
                weaponRankFields.imgWeap[3] = this.imgVaSpear;
                weaponRankFields.imgWeap[4] = this.imgVaDblSaber;
                weaponRankFields.imgWeap[5] = this.imgVaAxe;
                weaponRankFields.imgWeap[6] = this.imgVaSabers;
                weaponRankFields.imgWeap[7] = this.imgVaDaggers;
                weaponRankFields.imgWeap[8] = this.imgVaClaws;
                weaponRankFields.imgWeap[9] = this.imgVaSaber;
                weaponRankFields.imgWeap[10] = this.imgVaDagger;
                weaponRankFields.imgWeap[11] = this.imgVaClaw;
                weaponRankFields.imgWeap[12] = this.imgVaWhip;
                weaponRankFields.imgWeap[13] = this.imgVaSlicer;
                weaponRankFields.imgWeap[14] = this.imgVaRifle;
                weaponRankFields.imgWeap[15] = this.imgVaShotgun;
                weaponRankFields.imgWeap[16] = this.imgVaLongbow;
                weaponRankFields.imgWeap[17] = this.imgVaGrenade;
                weaponRankFields.imgWeap[18] = this.imgVaLaser;
                weaponRankFields.imgWeap[19] = this.imgVaHandguns;
                weaponRankFields.imgWeap[20] = this.imgVaHandgun;
                weaponRankFields.imgWeap[21] = this.imgVaCrossbow;
                weaponRankFields.imgWeap[22] = this.imgVaCards;
                weaponRankFields.imgWeap[23] = this.imgVaMachinegun;
                weaponRankFields.imgWeap[27] = this.imgVaRmag;
                weaponRankFields.imgWeap[24] = this.imgVaRod;
                weaponRankFields.imgWeap[25] = this.imgVaWand;
                weaponRankFields.imgWeap[26] = this.imgVaTmag;
                weaponRankFields.imgWeap[28] = this.imgVaShield;
                weaponRankFields.imgRank[1] = this.imgVaSwordRank;
                weaponRankFields.imgRank[2] = this.imgVaKnucklesRank;
                weaponRankFields.imgRank[3] = this.imgVaSpearRank;
                weaponRankFields.imgRank[4] = this.imgVaDblSaberRank;
                weaponRankFields.imgRank[5] = this.imgVaAxeRank;
                weaponRankFields.imgRank[6] = this.imgVaSabersRank;
                weaponRankFields.imgRank[7] = this.imgVaDaggersRank;
                weaponRankFields.imgRank[8] = this.imgVaClawsRank;
                weaponRankFields.imgRank[9] = this.imgVaSaberRank;
                weaponRankFields.imgRank[10] = this.imgVaDaggerRank;
                weaponRankFields.imgRank[11] = this.imgVaClawRank;
                weaponRankFields.imgRank[12] = this.imgVaWhipRank;
                weaponRankFields.imgRank[13] = this.imgVaSlicerRank;
                weaponRankFields.imgRank[14] = this.imgVaRifleRank;
                weaponRankFields.imgRank[15] = this.imgVaShotgunRank;
                weaponRankFields.imgRank[16] = this.imgVaLongbowRank;
                weaponRankFields.imgRank[17] = this.imgVaGrenadeRank;
                weaponRankFields.imgRank[18] = this.imgVaLaserRank;
                weaponRankFields.imgRank[19] = this.imgVaHandgunsRank;
                weaponRankFields.imgRank[20] = this.imgVaHandgunRank;
                weaponRankFields.imgRank[21] = this.imgVaCrossbowRank;
                weaponRankFields.imgRank[22] = this.imgVaCardsRank;
                weaponRankFields.imgRank[23] = this.imgVaMachinegunRank;
                weaponRankFields.imgRank[27] = this.imgVaRmagRank;
                weaponRankFields.imgRank[24] = this.imgVaRodRank;
                weaponRankFields.imgRank[25] = this.imgVaWandRank;
                weaponRankFields.imgRank[26] = this.imgVaTmagRank;
                weaponRankFields.imgRank[28] = this.imgVaShieldRank;
            }
            return weaponRankFields;
        }

        public pspo2seForm.expDb_ItemClass findExpLevelInfoInDb(int level)
        {
            if (level - 1 < this.exp_db_filled)
                return this.exp_db.level[level - 1];
            int num = (int)MessageBox.Show("Fatal error. Trying to exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return (pspo2seForm.expDb_ItemClass)null;
        }

        public void addExpLevelInfoToDb(string csvLine)
        {
            if (this.exp_db_filled >= 355)
            {
                int num1 = (int)MessageBox.Show("Fatal Error! ExpLevel Database is too large!");
            }
            string[] strArray = csvLine.Split('|');
            this.exp_db.level[this.exp_db_filled] = new pspo2seForm.expDb_ItemClass();
            try
            {
                this.exp_db.level[this.exp_db_filled].level = int.Parse(strArray[0]);
                this.exp_db.level[this.exp_db_filled].exp = int.Parse(strArray[1]);
                this.exp_db.level[this.exp_db_filled].exp_next = int.Parse(strArray[2]);
                ++this.exp_db_filled;
            }
            catch
            {
                if (this.shownCorruptExpCsv)
                    return;
                int num2 = (int)MessageBox.Show("The ExpLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.shownCorruptExpCsv = true;
                this.databasesOk = false;
            }
        }

        public void loadExpLevelDatabase()
        {
            this.exp_db_filled = 0;
            try
            {
                string encryptionKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/explevel.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string csvLine;
                    while ((csvLine = streamReader.ReadLine()) != null)
                        this.addExpLevelInfoToDb(csvLine);
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Level Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public pspo2seForm.expDb_ItemClass findExpTypeInfoInDb(int level)
        {
            if (level < this.type_db_filled)
                return this.typeexp_db.level[level];
            int num = (int)MessageBox.Show("Fatal error. Trying to get type exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return (pspo2seForm.expDb_ItemClass)null;
        }

        public pspo2seForm.expDb_ItemClass findRebirthBpInfoInDb(int level)
        {
            if (level - 50 + 200 < this.exp_db_filled)
                return this.exp_db.level[level - 50 + 200];
            int num = (int)MessageBox.Show("Fatal error. Trying to get rebirth info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return (pspo2seForm.expDb_ItemClass)null;
        }

        public void addExpTypeInfoToDb(string csvLine)
        {
            if (this.type_db_filled >= 55)
            {
                int num1 = (int)MessageBox.Show("Fatal Error! ExpTypeLevel Database is too large!");
            }
            string[] strArray = csvLine.Split('|');
            this.typeexp_db.level[this.type_db_filled] = new pspo2seForm.expDb_ItemClass();
            try
            {
                this.typeexp_db.level[this.type_db_filled].level = int.Parse(strArray[0]);
                this.typeexp_db.level[this.type_db_filled].exp = int.Parse(strArray[1]);
                this.typeexp_db.level[this.type_db_filled].exp_next = int.Parse(strArray[2]);
                this.typeexp_db.level[this.type_db_filled].extend_points = int.Parse(strArray[3]);
            }
            catch
            {
                if (!this.shownCorruptExpTypeCsv)
                {
                    int num2 = (int)MessageBox.Show("The ExpTypeLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.shownCorruptExpTypeCsv = true;
                    this.databasesOk = false;
                }
            }
            ++this.type_db_filled;
        }

        public void loadExpTypeDatabase()
        {
            this.type_db_filled = 0;
            try
            {
                string encryptionKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/exptype.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string csvLine;
                    while ((csvLine = streamReader.ReadLine()) != null)
                        this.addExpTypeInfoToDb(csvLine);
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Type Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public pspo2seForm.saveDataType get_saveDataInfo => this.saveData;

        public TabPage get_tabPageType => this.tabPageInventory;

        public void disableMainForm()
        {
            this.lstSaveSlotView.Enabled = false;
            this.tabArea.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnSaveAs.Enabled = false;
            this.btnUndoAll.Enabled = false;
            this.btnImportCharacter.Enabled = false;
            this.btnExportCharacter.Enabled = false;
            this.btnBrowse.Enabled = false;
            this.menuStrip.Enabled = false;
            this.tabArea.SelectedTab = this.tabPageInfo;
            this.btnInventoryDelete.Enabled = false;
            this.btnInventoryExportSelected.Enabled = false;
            this.btnInventoryDeposit.Enabled = false;
            this.btnStorageDelete.Enabled = false;
            this.btnStorageExportSelected.Enabled = false;
            this.btnStorageWithdraw.Enabled = false;
            this.chkDeleteExportInventory.Enabled = false;
            this.chkDeleteExportStorage.Enabled = false;
        }

        public void enableMainForm()
        {
            if (this.txtFileLoc.Text != "")
            {
                this.lstSaveSlotView.Enabled = true;
                this.tabArea.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnSaveAs.Enabled = true;
                this.btnUndoAll.Enabled = true;
                this.btnImportCharacter.Enabled = true;
                this.btnExportCharacter.Enabled = true;
                this.inventoryViewPages.SelectedIndex = 0;
                this.storageViewPages.SelectedIndex = 0;
            }
            this.btnBrowse.Enabled = true;
            this.menuStrip.Enabled = true;
        }

        public bool legitVersion() => false;

        public pspo2seForm()
        {
            this.InitializeComponent();

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\databases");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\temp");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\weapon_images");
                this.firstInstall = true;
                this.databasesOk = false;
                int num = (int)MessageBox.Show("This is your first time running the application\r\nYou will need to update the databases\r\nbefore you can do anything.\r\n\r\nChoose databases from the top menu to update.", "First time use", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\keys"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\keys");
            if (!this.downloadRequiredFile("FolderZipper.dll", "The application will not start without this file.", 6144L))
            {
                int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            if (!this.downloadRequiredFile("ICSharpCode.SharpZipLib.dll", "The application will not start without this file.", 200704L))
            {
                int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            if (!this.downloadRequiredFile("pspo2se_updater.exe", "The application will not start without this file.", 6144L))
            {
                int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            this.downloadRequiredFile("SED.exe", "You cannot load encrypted save files without this.", 51712L);
            this.abilityDb.encryptor = this.encryptor;
            this.initImageFloater();
            if (!this.firstInstall)
            {
                this.action_loadDatabases();
                Application.DoEvents();
                this.checkAppUpdate(false);
                this.checkDatabaseUpdate(false);
                this.checkImagesUpdate(false);
            }
            this.firstboot = false;
            this.Text = "PSPo2 Save Editor v3.0 build 1008";
            this.txtFooterText.Text = "PSPo2 Save Editor v3.0 build 1008 by FunkySkunk 2011-2015";
            if (this.legitVersion())
                this.action_setupLegitApp();
            this.btnBrowse.Enabled = true;
            this.menuStrip.Enabled = true;
        }

        private void action_loadDatabases()
        {
            this.databasesOk = true;
            this.loadItemDatabase();
            if (!this.abilityDb.loadDatabase())
                this.databasesOk = false;
            this.loadExpLevelDatabase();
            this.loadExpTypeDatabase();
            if (this.saveData.type == pspo2seForm.SaveType.NONE)
                return;
            this.reloadEverything();
        }

        private void action_setupLegitApp()
        {
            this.Text = "PSPo2 Save Viewer v3.0 build 1008";
            this.btnExportCharacter.Visible = false;
            this.btnImportCharacter.Visible = false;
            this.btnInventoryDelete.Visible = false;
            this.btnInventoryExportAll.Visible = false;
            this.btnInventoryImportAll.Visible = false;
            this.btnInventoryExportSelected.Visible = false;
            this.btnInventoryDeposit.Visible = true;
            this.btnInventoryImportSelected.Visible = false;
            this.btnStorageDelete.Visible = false;
            this.btnStorageExportAll.Visible = false;
            this.btnStorageImportAll.Visible = false;
            this.btnStorageExportSelected.Visible = false;
            this.btnStorageImportSelected.Visible = false;
            this.btnStorageWithdraw.Visible = true;
            this.chkDeleteExportInventory.Visible = false;
            this.chkDeleteExportStorage.Visible = false;
            this.inventoryViewPages.TabPages.Remove(this.tabInventory6);
            this.storageViewPages.TabPages.Remove(this.tabStorage6);
            this.txtFooterText.Text = "PSPo2 Save Viewer v3.0 build 1008 by FunkySkunk 2011";
            this.chkRebirthSpoof.Visible = false;
            this.chkRebirthSpoof.Checked = false;
            this.chkRebirthNoLevelDrop.Visible = false;
            this.chkRebirthNoLevelDrop.Checked = false;
            this.txtLevel.Cursor = Cursors.Default;
            this.lblLevel.Cursor = Cursors.Default;
            this.txtTitle.Cursor = Cursors.Default;
            this.lblTitle.Cursor = Cursors.Default;
            this.txtCurType.Cursor = Cursors.Default;
            this.lblType.Cursor = Cursors.Default;
            this.txtRace.Cursor = Cursors.Default;
            this.lblClass.Cursor = Cursors.Default;
            this.txtSex.Cursor = Cursors.Default;
            this.lblSex.Cursor = Cursors.Default;
            this.txtHuLevel.Cursor = Cursors.Default;
            this.txtRaLevel.Cursor = Cursors.Default;
            this.txtFoLevel.Cursor = Cursors.Default;
            this.txtVaLevel.Cursor = Cursors.Default;
            this.lblHuLevel.Cursor = Cursors.Default;
            this.lblRaLevel.Cursor = Cursors.Default;
            this.lblFoLevel.Cursor = Cursors.Default;
            this.lblVaLevel.Cursor = Cursors.Default;
            this.txtInventoryMeseta.Cursor = Cursors.Default;
            this.lblInventoryMeseta.Cursor = Cursors.Default;
            this.txtInventoryQty.Cursor = Cursors.Default;
            this.imgInventoryElement.Cursor = Cursors.Default;
            this.txtInventoryPercent.Cursor = Cursors.Default;
            this.txtInventorySpecial.Cursor = Cursors.Default;
            this.txtInventoryATK.Cursor = Cursors.Default;
            this.txtStorageMeseta.Cursor = Cursors.Default;
            this.lblStorageMeseta.Cursor = Cursors.Default;
            this.txtStorageQty.Cursor = Cursors.Default;
            this.imgStorageElement.Cursor = Cursors.Default;
            this.txtStoragePercent.Cursor = Cursors.Default;
            this.txtStorageSpecial.Cursor = Cursors.Default;
            this.txtStorageATK.Cursor = Cursors.Default;
            this.txtSkipEp1Start.Cursor = Cursors.Default;
            this.txtMissionEp1.Cursor = Cursors.Default;
            this.txtMissionMagashi.Cursor = Cursors.Default;
            this.txtMissionTactical.Cursor = Cursors.Default;
            this.txtEp1Complete.Cursor = Cursors.Default;
            this.txtSkipEp2Start.Cursor = Cursors.Default;
            this.txtMissionEp2.Cursor = Cursors.Default;
            this.txtEp2Complete.Cursor = Cursors.Default;
            this.btnImportInfinityMission.Visible = false;
            this.btnExportInfinityMission.Visible = false;
            this.btnDeleteInfinityMission.Visible = false;
            this.btnModifyInfinityMission.Visible = false;
        }

        private void action_browse()
        {
            if (!this.databasesOk)
            {
                int num = (int)MessageBox.Show("The databases must be updated before you can use the application", "Database Updates Required", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.checkDatabaseUpdate(true);
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "PSPo2 Save Editor: Open File";
                if (this.legitVersion())
                    openFileDialog.Title = "PSPo2 Save Viewer: Open File";
                openFileDialog.Filter = "All files (*.*)|*.*|PSP Decrypted Save Data (*.bin)|*.bin|PSP Encrypted Save Data (*.bin)|*.bin";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                this.txtFileLoc.Text = openFileDialog.FileName;
                this.tabArea.SelectedTab = this.tabPageInfo;
                this.disableMainForm();
                this.saveOk = this.loadSaveFile(false);
                if (!this.saveOk)
                    return;
                this.showGameImage();
                if (this.lstSaveSlotView.Items.Count <= 0)
                    return;
                this.lstSaveSlotView.Items[0].Selected = true;
                this.enableMainForm();
            }
        }

        private void action_saveas()
        {
            if (this.saveOk)
            {
                if (this.mainSettings.saveStructureIndex.encrypted)
                {
                    if (!this.saveBufferDataToFile(0, this.saveData.size, "PSP Encrypted Save Data (*.bin)|*.bin"))
                        return;
                    int num = (int)MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (!this.saveBufferDataToFile(0, this.saveData.size, "PSP Decrypted Save Data (*.bin)|*.bin"))
                        return;
                    int num = (int)MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                int num1 = (int)MessageBox.Show("There is no data to save", "Save Data Buffer Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void action_save()
        {
            if (this.saveOk)
            {
                if (MessageBox.Show("Are you sure you want to overwrite the loaded save file?", "Confirm Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                if (this.mainSettings.saveStructureIndex.encrypted)
                {
                    if (!this.saveBufferDataToFile(0, this.saveData.size, "PSP Encrypted Save Data (*.bin)|*.bin", isSaveFile: true, path: this.txtFileLoc.Text))
                        return;
                    int num = (int)MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (!this.saveBufferDataToFile(0, this.saveData.size, "PSP Decrypted Save Data (*.bin)|*.bin", isSaveFile: true, path: this.txtFileLoc.Text))
                        return;
                    int num = (int)MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                int num1 = (int)MessageBox.Show("There is no data to save", "Save Data Buffer Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void action_launchTypeAbilitiesForm()
        {
            string attachedAbilities = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities;
            this.abilitiesForm.oldJobs = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job;
            this.abilitiesForm.newJob = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex];
            this.abilitiesForm.selectedJob = (pspo2seForm.jobType)this.tabControlClasses.SelectedIndex;
            this.abilitiesForm.max_abilities = this.mainSettings.saveStructureIndex.max_type_abilities;
            this.abilitiesForm.character_name = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].name;
            this.abilitiesForm.abilityDb = this.abilityDb;
            this.abilitiesForm.saveType = this.saveData.type;
            bool flag = false;
            while (!flag)
            {
                if (this.abilitiesForm.ShowDialog((IWin32Window)this) == DialogResult.OK)
                {
                    pspo2seForm.jobClass newJob = this.abilitiesForm.newJob;
                    if (newJob.attachedAbilities != attachedAbilities)
                    {
                        int pos = this.mainSettings.saveStructureIndex.type_level_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 16 + this.tabControlClasses.SelectedIndex * this.mainSettings.saveStructureIndex.type_extend_size + 4;
                        this.overwriteHexInBuffer(newJob.attachedAbilities, pos);
                        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities = newJob.attachedAbilities;
                    }
                    flag = true;
                }
                else if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities != attachedAbilities)
                {
                    if (MessageBox.Show("You are about to quit without saving changes\r\nAre you sure?", "Changes were made", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities = attachedAbilities;
                        flag = true;
                    }
                }
                else
                    flag = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e) => this.action_browse();

        private void btnExportCharacter_Click(object sender, EventArgs e)
        {
            if (!this.saveBufferDataToFile(this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index, this.mainSettings.saveStructureIndex.slot_size, this.mainSettings.saveStructureIndex.character_file_name + " (*" + this.mainSettings.saveStructureIndex.character_file_ext + ")|*" + this.mainSettings.saveStructureIndex.character_file_ext, fileNameDefault: this.lstSaveSlotView.SelectedItems[0].Text))
                return;
            int num = (int)MessageBox.Show("The character file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnUndoAll_Click(object sender, EventArgs e) => this.loadSaveFile(false);

        private void btnImportCharacter_Click(object sender, EventArgs e)
        {
            if (this.loadFileIntoBuffer(this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index, this.mainSettings.saveStructureIndex.character_file_name + " (*" + this.mainSettings.saveStructureIndex.character_file_ext + ")|*" + this.mainSettings.saveStructureIndex.character_file_ext, pspo2seForm.partFileType.character, false) <= 0)
                return;
            this.reloadEverything();
            int num = (int)MessageBox.Show("The character file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnSaveAs_Click(object sender, EventArgs e) => this.action_saveas();

        private void tabArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabArea.SelectedIndex)
            {
                case 2:
                    this.inventoryViewPages.SelectedIndex = 0;
                    if (this.inventoryView.SelectedItems.Count <= 0)
                    {
                        this.makeImageFloaterHidden();
                        break;
                    }
                    this.changeImageFloater(this.txtInventoryHex.Text.Substring(2, 8));
                    break;
                case 3:
                    this.storageViewPages.SelectedIndex = 0;
                    if (this.storageView.SelectedItems.Count <= 0)
                    {
                        this.makeImageFloaterHidden();
                        break;
                    }
                    this.changeImageFloater(this.txtStorageHex.Text.Substring(2, 8));
                    break;
                default:
                    this.closeImageFloater();
                    break;
            }
        }

        private void storageViewPages_SelectedIndexChanged(object sender, EventArgs e) => this.changeStoragePage(this.storageViewPages.SelectedIndex + 1);

        private void storageViewChanged()
        {
            if (this.storageView.SelectedItems.Count > 0)
            {
                this.selectedStorageItem = this.storageView.SelectedItems[0].Index;
                if (this.selectedStorageItem != -1)
                {
                    this.showSelectedInventoryItem(this.tabPageStorage);
                }
                else
                {
                    this.grpStorageItemDetails.Visible = false;
                    this.imageFloatImageIsOk = false;
                    this.txtStorageHex.Text = "0x00000000";
                    this.changeImageFloater(this.txtStorageHex.Text);
                }
            }
            else
            {
                this.grpStorageItemDetails.Visible = false;
                this.imageFloatImageIsOk = false;
                this.txtStorageHex.Text = "0x00000000";
            }
        }

        private void storageView_SelectedIndexChanged(object sender, EventArgs e) => this.storageViewChanged();

        private void storageView_Click(object sender, EventArgs e) => this.storageViewChanged();

        private void inventoryViewPages_SelectedIndexChanged(object sender, EventArgs e) => this.changeInventoryPage(this.inventoryViewPages.SelectedIndex + 1);

        private void inventoryViewChanged()
        {
            if (this.inventoryView.SelectedItems.Count > 0)
            {
                this.selectedInventoryItem = this.inventoryView.SelectedItems[0].Index;
                if (this.selectedInventoryItem != -1)
                {
                    this.showSelectedInventoryItem(this.tabPageInventory);
                }
                else
                {
                    this.grpInventoryItemDetails.Visible = false;
                    this.imageFloatImageIsOk = false;
                    this.txtInventoryHex.Text = "0x00000000";
                    this.changeImageFloater(this.txtInventoryHex.Text);
                }
            }
            else
            {
                this.grpInventoryItemDetails.Visible = false;
                this.imageFloatImageIsOk = false;
                this.txtInventoryHex.Text = "0x00000000";
            }
        }

        private void inventoryView_Click(object sender, EventArgs e) => this.inventoryViewChanged();

        private void inventoryView_SelectedIndexChanged(object sender, EventArgs e) => this.inventoryViewChanged();

        private void txtInventoryName_jp_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtInventoryName_jp.Text);
            int num = (int)MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInventoryExportSelected_Click(object sender, EventArgs e)
        {
            int id = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id;
            string ext_options = this.mainSettings.saveStructureIndex.item_file_name + " (*" + this.mainSettings.saveStructureIndex.item_file_ext + ")|*" + this.mainSettings.saveStructureIndex.item_file_ext;
            if (this.saveItemDataToFile(id, 20, ext_options, this.inventoryView.SelectedItems[0].Text, delete: this.chkDeleteExportInventory.Checked))
            {
                if (this.chkDeleteExportInventory.Checked)
                {
                    this.overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
                    this.overwriteHexInBuffer("00000000", id - 8);
                    this.reloadEverything();
                }
                int num = (int)MessageBox.Show("The item file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num1 = (int)MessageBox.Show("The item file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStorageExportSelected_Click(object sender, EventArgs e)
        {
            if (this.saveItemDataToFile(this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id, 20, this.mainSettings.saveStructureIndex.item_file_name + " (*" + this.mainSettings.saveStructureIndex.item_file_ext + ")|*" + this.mainSettings.saveStructureIndex.item_file_ext, this.storageView.SelectedItems[0].Text, delete: this.chkDeleteExportStorage.Checked))
            {
                if (this.chkDeleteExportStorage.Checked)
                    this.reloadEverything();
                int num = (int)MessageBox.Show("The item file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num1 = (int)MessageBox.Show("The item file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStorageImportSelected_Click(object sender, EventArgs e)
        {
            int id = this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id;
            string ext_options = this.mainSettings.saveStructureIndex.item_file_name + " (*" + this.mainSettings.saveStructureIndex.item_file_ext + ")|*" + this.mainSettings.saveStructureIndex.item_file_ext;
            if (this.loadFileIntoBuffer(id, ext_options, pspo2seForm.partFileType.item, false) <= 0)
                return;
            this.reloadEverything();
            this.tabArea.SelectedIndex = 3;
            this.selectItemAfterLoad = id;
            this.displaySharedStorage(1);
            int num = (int)MessageBox.Show("The item was imported successfully.\n\nIf the item was modified, the values may not match the game until the next time you save your progress.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInventoryImportSelected_Click(object sender, EventArgs e)
        {
            if (this.inventoryView.SelectedItems.Count <= 0)
                return;
            if (this.loadFileIntoBuffer(this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id, this.mainSettings.saveStructureIndex.item_file_name + " (*" + this.mainSettings.saveStructureIndex.item_file_ext + ")|*" + this.mainSettings.saveStructureIndex.item_file_ext, pspo2seForm.partFileType.item, true) <= 0)
                return;
            this.reloadEverything();
            this.tabArea.SelectedIndex = 2;
            this.displayInventory(this.lstSaveSlotView.SelectedItems[0].Index, 1);
            int num = (int)MessageBox.Show("The item / items were imported successfully.\n\nIf an item was modified, the values may not match the game until the next time you save your progress.\n\nPlease remember that you should not used modified items online as you may get banned.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnStorageExportAll_Click(object sender, EventArgs e)
        {
            if (!this.saveBufferDataToFile(this.mainSettings.saveStructureIndex.shared_inventory_pos, this.mainSettings.saveStructureIndex.shared_inventory_slots * 20, this.mainSettings.saveStructureIndex.storage_file_name + " (*" + this.mainSettings.saveStructureIndex.storage_file_ext + ")|*" + this.mainSettings.saveStructureIndex.storage_file_ext))
                return;
            int num = (int)MessageBox.Show("The storage file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInventoryExportAll_Click(object sender, EventArgs e)
        {
            if (!this.saveBufferDataToFile(this.mainSettings.saveStructureIndex.inventory_slots_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index, 2160, this.mainSettings.saveStructureIndex.inventory_file_name + " (*" + this.mainSettings.saveStructureIndex.inventory_file_ext + ")|*" + this.mainSettings.saveStructureIndex.inventory_file_ext, this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed))
                return;
            int num = (int)MessageBox.Show("The inventory file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInventoryImportAll_Click(object sender, EventArgs e)
        {
            if (this.loadFileIntoBuffer(this.mainSettings.saveStructureIndex.inventory_slots_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index, this.mainSettings.saveStructureIndex.inventory_file_name + " (*" + this.mainSettings.saveStructureIndex.inventory_file_ext + ")|*" + this.mainSettings.saveStructureIndex.inventory_file_ext, pspo2seForm.partFileType.inventory, true) <= 0)
                return;
            this.reloadEverything();
            int num = (int)MessageBox.Show("The inventory file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnStorageImportAll_Click(object sender, EventArgs e)
        {
            if (this.loadFileIntoBuffer(this.mainSettings.saveStructureIndex.shared_inventory_pos, this.mainSettings.saveStructureIndex.storage_file_name + " (*" + this.mainSettings.saveStructureIndex.storage_file_ext + ")|*" + this.mainSettings.saveStructureIndex.storage_file_ext, pspo2seForm.partFileType.storage, false) <= 0)
                return;
            this.reloadEverything();
            int num = (int)MessageBox.Show("The storage file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnHuAbilitiesOpen_Click(object sender, EventArgs e) => this.action_launchTypeAbilitiesForm();

        private void btnRaAbilitiesOpen_Click(object sender, EventArgs e) => this.action_launchTypeAbilitiesForm();

        private void btnFoAbilitiesOpen_Click(object sender, EventArgs e) => this.action_launchTypeAbilitiesForm();

        private void btnVaAbilitiesOpen_Click(object sender, EventArgs e) => this.action_launchTypeAbilitiesForm();

        private void saveSlotView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstSaveSlotView.SelectedItems.Count <= 0)
                return;
            this.displaySlotInfo(this.lstSaveSlotView.SelectedItems[0].Index);
            if (this.tabArea.SelectedIndex == 2)
            {
                this.inventoryViewPages.SelectedIndex = 0;
                Application.DoEvents();
            }
            if (this.tabArea.SelectedIndex != 3)
                return;
            this.storageViewPages.SelectedIndex = 0;
            Application.DoEvents();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) => this.action_browse();

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => this.action_saveas();

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) => this.action_loadDatabases();

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e) => this.loadImageFloaterImages();

        private void txtInventoryHex_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtInventoryHex.Text.Substring(2, 8));
            int num = (int)MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtStorageHex_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtStorageHex.Text.Substring(2, 8));
            int num = (int)MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) => this.checkDatabaseUpdate(true);

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void updateToolStripMenuItem_Click(object sender, EventArgs e) => this.checkAppUpdate(true);

        private void versionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = !this.legitVersion() ? "PSPo2 Save Editor" : "PSPo2 Save Viewer";
            if (!this.databasesOk)
            {
                int num1 = (int)MessageBox.Show("You are currently running " + str + " v3.0 build 1008\r\n\r\nThe databases are not installed correctly.\r\nPlease update them before you can view more information.", "Version Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.changelogForm.formSetup();
                int num2 = (int)this.changelogForm.ShowDialog((IWin32Window)this);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("http://files-ds-scene.net/retrohead/pspo2se/");

        private void checkForUpdatesToolStripMenuItem1_Click(object sender, EventArgs e) => this.checkImagesUpdate(true);

        private void txtStorageMeseta_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            this.entryForm.oldVal = string.Concat((object)this.saveData.sharedMeseta);
            this.entryForm.newVal = string.Concat((object)this.saveData.sharedMeseta);
            this.entryForm.description = "shared meseta";
            this.entryForm.maxLen = 8;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            long num1 = long.Parse(this.entryForm.newVal);
            if (num1 != this.saveData.sharedMeseta && num1 <= 99999999L)
            {
                string hex = num1.ToString("X4");
                while (hex.Length < 8)
                    hex = "0" + hex;
                int pos = this.mainSettings.saveStructureIndex.shared_inventory_pos + this.mainSettings.saveStructureIndex.shared_inventory_slots * 20;
                this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 8), pos);
                this.saveData.sharedMeseta = num1;
                this.txtStorageMeseta.Text = num1.ToString();
            }
            else
            {
                if (num1 <= 99999999L)
                    return;
                int num2 = (int)MessageBox.Show("You must enter a value less than 99,999,999");
            }
        }

        private void btnStorageWithdraw_Click(object sender, EventArgs e)
        {
            if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed >= 60)
            {
                int num1 = (int)MessageBox.Show("The selected characters inventory is full", "Inventory Full", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.saveItemDataToFile(this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id, 20, "", "", Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext, true);
                int index = 0;
                while (index < 60 && this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[index].used)
                    ++index;
                int freeInventoryItemId = this.getFreeInventoryItemId(this.lstSaveSlotView.SelectedItems[0].Index);
                if (this.loadFileIntoBuffer(freeInventoryItemId, "", pspo2seForm.partFileType.item, true, Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext) > 0)
                {
                    this.reloadEverything();
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext);
                    this.tabArea.SelectedIndex = 2;
                    this.selectInventoryItemAfterLoad = freeInventoryItemId;
                    this.displayInventory(this.lstSaveSlotView.SelectedItems[0].Index, 1);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("There was an error moving the item. Please re-load your save file and try again.", "Item Move Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btnInventoryDeposit_Click(object sender, EventArgs e)
        {
            if (this.saveData.sharedInventory.itemsUsed >= this.mainSettings.saveStructureIndex.shared_inventory_slots)
            {
                int num1 = (int)MessageBox.Show("The shared storage is full", "Storage Full", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int id = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id;
                if (!this.saveItemDataToFile(id, 20, "", "", Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext, true))
                {
                    int num2 = (int)MessageBox.Show("Could not write the temporary file: \n\n" + Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext, "Failed to deposit item!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
                    this.overwriteHexInBuffer("00000000", id - 8);
                    for (int index = 0; index < this.saveData.sharedInventory.itemsUsed; ++index)
                    {
                        if (!this.saveData.sharedInventory.item[index].used)
                        {
                            id = this.saveData.sharedInventory.item[index].id;
                            break;
                        }
                    }
                    if (this.loadFileIntoBuffer(id, "", pspo2seForm.partFileType.item, false, Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext) > 0)
                    {
                        --this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed;
                        this.overwriteHexInBuffer(this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X2"), this.mainSettings.saveStructureIndex.inventory_slots_used_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                        this.reloadEverything();
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext);
                        this.tabArea.SelectedIndex = 3;
                        this.selectItemAfterLoad = id;
                        this.displaySharedStorage(1);
                    }
                    else
                    {
                        int num3 = (int)MessageBox.Show("There was an error moving the item. Please re-load your save file and try again.", "Item Move Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void txtStorageQty_Click(object sender, EventArgs e) => this.changeItemQty(this.tabPageStorage);

        private void txtInventoryQty_Click(object sender, EventArgs e) => this.changeItemQty(this.tabPageInventory);

        private void changeDiskLevel(TabPage page)
        {
            if (this.legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != this.tabPageStorage ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
            this.entryForm.oldVal = string.Concat((object)(inventoryItemClass.pa_level + 1));
            this.entryForm.newVal = string.Concat((object)(inventoryItemClass.pa_level + 1));
            this.entryForm.description = "PA disk level";
            this.entryForm.maxLen = 2;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != (inventoryItemClass.pa_level + 1).ToString()))
                return;
            if (int.Parse(newVal) > 30)
            {
                int num1 = (int)MessageBox.Show("You must enter a value lower or equal to 30.");
            }
            else if (int.Parse(newVal) < 1)
            {
                int num2 = (int)MessageBox.Show("You must enter a value greater than 0.");
            }
            else
            {
                string hex = (int.Parse(newVal) - 1).ToString("X1");
                while (hex.Length < 2)
                    hex = "0" + hex;
                this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), inventoryItemClass.id + 16);
                inventoryItemClass.pa_level = int.Parse(newVal) - 1;
                this.displayItemInfo(this.getPageFields(page), inventoryItemClass);
            }
        }

        private void changeItemQty(TabPage page)
        {
            if (this.legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != this.tabPageStorage ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
            if (inventoryItemClass.qty == 0)
            {
                this.changeDiskLevel(page);
            }
            else
            {
                this.entryForm.oldVal = inventoryItemClass.qty.ToString();
                this.entryForm.newVal = inventoryItemClass.qty.ToString();
                this.entryForm.description = "item qty";
                this.entryForm.maxLen = 3;
                if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                    return;
                string newVal = this.entryForm.newVal;
                if (!(newVal != inventoryItemClass.qty.ToString()))
                    return;
                if (int.Parse(newVal) > inventoryItemClass.qty_max)
                {
                    int num1 = (int)MessageBox.Show("You must enter a value lower or equal to the max stack qty for this item.");
                }
                else if (int.Parse(newVal) < 1)
                {
                    int num2 = (int)MessageBox.Show("You must enter a value greater than 0.");
                }
                else
                {
                    string hex = int.Parse(newVal).ToString("X2");
                    while (hex.Length < 4)
                        hex = "0" + hex;
                    this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 4), inventoryItemClass.id + 4);
                    inventoryItemClass.qty = int.Parse(newVal);
                    if (page == this.tabPageStorage)
                        this.txtStorageQty.Text = inventoryItemClass.qty.ToString() + "/" + (object)inventoryItemClass.qty_max;
                    else
                        this.txtInventoryQty.Text = inventoryItemClass.qty.ToString() + "/" + (object)inventoryItemClass.qty_max;
                }
            }
        }

        private void txtInventoryPercent_Click(object sender, EventArgs e) => this.changeItemPercentage(this.tabPageInventory);

        private void txtStoragePercent_Click(object sender, EventArgs e) => this.changeItemPercentage(this.tabPageStorage);

        private void changeItemPercentage(TabPage page)
        {
            if (this.legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != this.tabPageStorage ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
            this.entryForm.oldVal = inventoryItemClass.percent.ToString();
            this.entryForm.newVal = inventoryItemClass.percent.ToString();
            this.entryForm.description = "element percentage";
            this.entryForm.maxLen = 3;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != inventoryItemClass.percent.ToString()))
                return;
            if (int.Parse(newVal) > 100)
            {
                int num1 = (int)MessageBox.Show("You must enter a value lower or equal to 100.");
            }
            else if (int.Parse(newVal) < 0)
            {
                int num2 = (int)MessageBox.Show("You must enter a value greater or equal to 0.");
            }
            else
            {
                string hex1 = int.Parse(newVal).ToString("X1");
                while (hex1.Length < 2)
                    hex1 = "0" + hex1;
                string hex2 = this.run.hexAndMathFunction.reversehex(hex1, 2);
                string str1 = "";
                for (int index = 0; index < 20; ++index)
                    str1 += this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[inventoryItemClass.id + index], "hex");
                this.overwriteHexInBuffer(hex2, inventoryItemClass.id + 17);
                string str2 = "";
                for (int index = 0; index < 20; ++index)
                    str2 += this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[inventoryItemClass.id + index], "hex");
                inventoryItemClass.percent = int.Parse(newVal);
                if (page == this.tabPageStorage)
                    this.txtStoragePercent.Text = inventoryItemClass.percent.ToString() + "%";
                else
                    this.txtInventoryPercent.Text = inventoryItemClass.percent.ToString() + "%";
            }
        }

        private void imgStorageElement_Click(object sender, EventArgs e) => this.changeItemElement(this.tabPageStorage);

        private void imgInventoryElement_Click(object sender, EventArgs e) => this.changeItemElement(this.tabPageInventory);

        private void changeItemElement(TabPage page)
        {
            if (this.legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != this.tabPageStorage ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
            this.entryForm.oldVal = inventoryItemClass.element.ToString();
            this.entryForm.newVal = ((int)inventoryItemClass.element).ToString();
            this.entryForm.description = "element";
            this.entryForm.maxLen = 1;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != ((int)inventoryItemClass.element).ToString()))
                return;
            if (int.Parse(newVal) >= 7)
            {
                int num1 = (int)MessageBox.Show("You must enter a value lower than " + (object)pspo2seForm.elementType.COUNT + ".");
            }
            else if (int.Parse(newVal) < 0)
            {
                int num2 = (int)MessageBox.Show("You must enter a value greater or equal to 0.");
            }
            else
            {
                string hex = int.Parse(newVal).ToString("X1");
                while (hex.Length < 2)
                    hex = "0" + hex;
                this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), inventoryItemClass.id + 16);
                inventoryItemClass.element = (pspo2seForm.elementType)int.Parse(newVal);
                this.displayElementImage(this.getPageFields(page), inventoryItemClass.element);
            }
        }

        private void txtInventoryMeseta_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            this.entryForm.oldVal = this.txtInventoryMeseta.Text;
            this.entryForm.newVal = this.txtInventoryMeseta.Text;
            this.entryForm.description = "characters meseta";
            this.entryForm.maxLen = 8;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            long num1 = long.Parse(this.entryForm.newVal);
            if (num1 != this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].meseta)
            {
                string hex = num1.ToString("X4");
                while (hex.Length < 8)
                    hex = "0" + hex;
                this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 8), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 244);
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].meseta = num1;
                this.txtInventoryMeseta.Text = num1.ToString();
            }
            else
            {
                if (num1 <= 99999999L)
                    return;
                int num2 = (int)MessageBox.Show("You must enter a value less than 99,999,999");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => this.action_save();

        private void btnSave_Click(object sender, EventArgs e) => this.action_save();

        private void btnInventoryDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            int id = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id;
            --this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed;
            this.overwriteHexInBuffer(this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X2"), this.mainSettings.saveStructureIndex.inventory_slots_used_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
            this.overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
            this.overwriteHexInBuffer("00000000", id - 8);
            this.reloadEverything();
        }

        private void btnStorageDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            this.overwriteHexInBuffer("0000000000000000000000000000000000000000", this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id);
            this.reloadEverything();
        }

        private void pspo2seForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = false;

        private void changeItemATK(TabPage page)
        {
            if (this.legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != this.tabPageStorage ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
            this.entryForm.oldVal = inventoryItemClass.power_add.ToString();
            this.entryForm.newVal = inventoryItemClass.power_add.ToString();
            this.entryForm.description = "weapon power mod";
            this.entryForm.maxLen = 4;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != inventoryItemClass.power_add.ToString()))
                return;
            if (int.Parse(newVal) > 9999)
            {
                int num1 = (int)MessageBox.Show("You must enter a value lower or equal to 9999.");
            }
            else if (int.Parse(newVal) < 1)
            {
                int num2 = (int)MessageBox.Show("You must enter a value greater than 0.");
            }
            else
            {
                string hex1 = int.Parse(newVal).ToString("X2");
                while (hex1.Length < 4)
                    hex1 = "0" + hex1;
                string hex2 = this.run.hexAndMathFunction.reversehex(hex1, 4);
                string str1 = "";
                for (int index = 0; index < 20; ++index)
                    str1 += this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[inventoryItemClass.id + index], "hex");
                this.overwriteHexInBuffer(hex2, inventoryItemClass.id + 12);
                string str2 = "";
                for (int index = 0; index < 20; ++index)
                    str2 += this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[inventoryItemClass.id + index], "hex");
                inventoryItemClass.power_add = int.Parse(newVal);
                this.showSelectedInventoryItem(page);
            }
        }

        private void txtStorageATK_Click(object sender, EventArgs e) => this.changeItemATK(this.tabPageStorage);

        private void txtInventoryATK_Click(object sender, EventArgs e) => this.changeItemATK(this.tabPageInventory);

        private void txtSkipEp1Start_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtSkipEp1Start.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You are already skipping the starting sequence to Episode 1", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to skip the starting sequence to Episode 1?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
                this.overwriteHexInBuffer("90AB1E", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 5460 : num2 + 4648);
                this.txtSkipEp1Start.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].skip_ep_1_start = true;
                int num3 = (int)MessageBox.Show("The Episode 1 start sequence was skipped successfully.\n\nYou will need to play the first mission to progress the story.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtSkipEp2Start_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtSkipEp2Start.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You are already skipping the starting sequence to Episode 2", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to skip the starting sequence to Episode 2?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                this.overwriteHexInBuffer("78AF1E", this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 4684);
                this.txtSkipEp2Start.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].skip_ep_2_start = true;
                int num2 = (int)MessageBox.Show("The Episode 2 start sequence was skipped successfully.\n\nGo to the Little Wing Office to progress the story further.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtMissionEp1_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtMissionEp1.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You have already unlocked all of the Episode 1 Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want unlock all of the Episode 1 Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
                this.overwriteHexInBuffer("204E", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3436 : num2 + 3512);
                this.txtMissionEp1.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_ep1 = true;
                int num3 = (int)MessageBox.Show("The Episode 1 Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtMissionUnknown_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtMissionTactical.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You have already unlocked all of the Unknown Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want unlock all of the Unknown Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
                this.overwriteHexInBuffer("204E", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3488 : num2 + 3564);
                this.txtMissionTactical.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_unknown = true;
                int num3 = (int)MessageBox.Show("The Unknown Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtMissionEp2_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtMissionEp2.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You have already unlocked all of the Episode 2 Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want unlock all of the Episode 2 Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int pos = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
                if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
                {
                    pos += 3624;
                }
                else
                {
                    int num2 = (int)MessageBox.Show("This feature is for Infinity only");
                }
                this.overwriteHexInBuffer("204E", pos);
                this.txtMissionEp2.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_unknown = true;
                int num3 = (int)MessageBox.Show("The Episode 2 Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void missionStatus_TextChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Text == "Yes")
                ((Control)sender).ForeColor = Color.DarkGreen;
            else
                ((Control)sender).ForeColor = Color.DarkRed;
        }

        private void txtMissionMagashi_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtMissionMagashi.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You have already unlocked Magashi Plan.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want unlock Magashi Plan?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
                this.overwriteHexInBuffer("1F", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3182 : num2 + 3242);
                this.txtMissionMagashi.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_magashi = true;
                int num3 = (int)MessageBox.Show("The Magashi Plan mission was unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtCharacterName_Click(object sender, EventArgs e)
        {
            this.entryForm.oldVal = this.txtCharacterName.Text;
            this.entryForm.newVal = this.txtCharacterName.Text;
            this.entryForm.description = "character name";
            this.entryForm.maxLen = 32;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != this.txtCharacterName.Text))
                return;
            string hexadecimal = this.run.hexAndMathFunction.stringToHexadecimal(newVal, 64);
            this.overwriteHexInBuffer(hexadecimal, this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
            this.overwriteHexInBuffer(hexadecimal, this.mainSettings.saveStructureIndex.character_name_pos2 + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].name = newVal;
            this.lstSaveSlotView.SelectedItems[0].Text = newVal;
            this.txtCharacterName.Text = newVal;
        }

        private void txtLevel_Click(object sender, EventArgs e) => this.jumpToLevel();

        private void txtStorageName_jp_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtStorageName_jp.Text);
            int num = (int)MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtTitle_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            this.entryForm.oldVal = this.txtTitle.Text;
            this.entryForm.newVal = this.txtTitle.Text;
            this.entryForm.description = "title";
            this.entryForm.maxLen = 25;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != this.txtTitle.Text))
                return;
            this.overwriteHexInBuffer(this.run.hexAndMathFunction.stringToHexadecimal(newVal, 64), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 64);
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].title = newVal;
            this.txtTitle.Text = newVal;
        }

        private void txtCurType_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type.ToString();
            this.entryForm.newVal = ((int)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type).ToString();
            this.entryForm.description = "type";
            this.entryForm.maxLen = 1;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != ((int)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type).ToString()))
                return;
            string hex = int.Parse(newVal).ToString("X1");
            while (hex.Length < 2)
                hex = "0" + hex;
            this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 130);
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type = (pspo2seForm.jobType)int.Parse(newVal);
            this.txtCurType.Text = string.Concat((object)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type);
            this.lstSaveSlotView.SelectedItems[0].SubItems[3].Text = this.txtCurType.Text;
        }

        private void txtClass_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race.ToString();
            this.entryForm.newVal = ((int)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race).ToString();
            this.entryForm.description = "class";
            this.entryForm.maxLen = 1;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != ((int)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race).ToString()))
                return;
            string hex = int.Parse(newVal).ToString("X1");
            while (hex.Length < 2)
                hex = "0" + hex;
            this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 128);
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race = (pspo2seForm.raceTypes)int.Parse(newVal);
            this.txtRace.Text = string.Concat((object)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race);
            this.lstSaveSlotView.SelectedItems[0].SubItems[2].Text = this.txtRace.Text;
        }

        private void txtSex_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex.ToString();
            this.entryForm.newVal = ((int)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex).ToString();
            this.entryForm.description = "sex";
            this.entryForm.maxLen = 1;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != ((int)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex).ToString()))
                return;
            string hex = int.Parse(newVal).ToString("X1");
            while (hex.Length < 2)
                hex = "0" + hex;
            this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 129);
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex = (pspo2seForm.sexType)int.Parse(newVal);
            this.txtSex.Text = string.Concat((object)this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex);
        }

        private void lstPAMelee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstPAMelee.SelectedItems.Count <= 0)
                return;
            this.lstPA_SelectedIndexChanged(this.tabPAMelee, int.Parse(this.lstPAMelee.SelectedItems[0].Tag.ToString()));
        }

        private void lstPABullets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstPABullets.SelectedItems.Count <= 0)
                return;
            this.lstPA_SelectedIndexChanged(this.tabPABullets, int.Parse(this.lstPABullets.SelectedItems[0].Tag.ToString()));
        }

        private void lstPATechs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstPATechs.SelectedItems.Count <= 0)
                return;
            this.lstPA_SelectedIndexChanged(this.tabPATech, int.Parse(this.lstPATechs.SelectedItems[0].Tag.ToString()));
        }

        private pspo2seForm.pageFields getPAPageFields(TabPage tab)
        {
            pspo2seForm.pageFields pageFields = new pspo2seForm.pageFields();
            switch (tab.Name)
            {
                case "tabPAMelee":
                    pageFields.txt_hex = this.txtPAHexMelee;
                    break;
                case "tabPABullets":
                    pageFields.txt_hex = this.txtPAHexBullets;
                    break;
                case "tabPATech":
                    pageFields.txt_hex = this.txtPAHexTech;
                    break;
            }
            return pageFields;
        }

        private void lstPA_SelectedIndexChanged(TabPage tab, int paPositionID) => this.getPAPageFields(tab).txt_hex.Text = "0x" + this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].pa.items[paPositionID].hex_reversed;

        private unsafe int* getRebirthStatPointer(string nameFlag)
        {
            int* numPtr1 = (int*)null;
            switch (nameFlag)
            {
                case "HP":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.hp)
                        numPtr1 = numPtr2;
                    break;
                case "PP":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.pp)
                        numPtr1 = numPtr2;
                    break;
                case "ATK":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.atk)
                        numPtr1 = numPtr2;
                    break;
                case "DEF":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.def)
                        numPtr1 = numPtr2;
                    break;
                case "ACC":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.acc)
                        numPtr1 = numPtr2;
                    break;
                case "EVA":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.eva)
                        numPtr1 = numPtr2;
                    break;
                case "TEC":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.tec)
                        numPtr1 = numPtr2;
                    break;
                case "MND":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.mnd)
                        numPtr1 = numPtr2;
                    break;
                case "STA":
                    fixed (int* numPtr2 = &this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.sta)
                        numPtr1 = numPtr2;
                    break;
            }
            return numPtr1;
        }

        private unsafe void numRebirth_ValueChanged(object sender, EventArgs e)
        {
            if (this.lstSaveSlotView.SelectedItems[0].Index < 0 || ((NumericUpDown)sender).Value > 10M || ((NumericUpDown)sender).Value < 0M)
                return;
            string str = ((Control)sender).Name.Replace("numRebirth", "");
            int* rebirthStatPointer = this.getRebirthStatPointer(str);
            int num1 = *rebirthStatPointer;
            int rebirthValuePtsUsed = this.getRebirthValuePtsUsed(this.lstSaveSlotView.SelectedItems[0].Index, *rebirthStatPointer, str);
            *rebirthStatPointer = (int)((NumericUpDown)sender).Value;
            int num2 = this.getRebirthValuePtsUsed(this.lstSaveSlotView.SelectedItems[0].Index, *rebirthStatPointer, str) - rebirthValuePtsUsed;
            if (num2 < 0)
            {
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points += -num2;
                this.updateRebirthBufferVals(this.lstSaveSlotView.SelectedItems[0].Index);
            }
            else
            {
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points -= num2;
                if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points < 0)
                {
                    int num3 = (int)MessageBox.Show("You need " + (object)-this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points + " more points to add to this stat.\n\nYou will need to rebirth to gain more BP.", "Not Enough BP", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ((NumericUpDown)sender).Value = (Decimal)(*rebirthStatPointer - 1);
                }
                else
                    this.updateRebirthBufferVals(this.lstSaveSlotView.SelectedItems[0].Index);
            }
            this.displayRebirthInfo(this.lstSaveSlotView.SelectedItems[0].Index);
        }

        private void classLevel_Click(object sender, EventArgs e) => this.jumpToTypeLevel();

        private void lstRebirthRewards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstRebirthRewards.Items.Count <= 0)
                return;
            this.lstRebirthRewards.SelectedItems.Clear();
        }

        private void btnRebirth_Click(object sender, EventArgs e)
        {
            int level = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level;
            if (this.chkRebirthSpoof.Checked)
                level = 200;
            if (level < 50)
                return;
            if (this.comboRebirthExtend.SelectedIndex > 0)
            {
                if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed >= 60)
                {
                    int num = (int)MessageBox.Show("The characters inventory is full, please deposit an item before rebirthing so you can claim the extend codes", "Inventory Full", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                string hex1 = this.comboRebirthExtend.SelectedIndex.ToString("X4");
                while (hex1.Length < 8)
                    hex1 = "0" + hex1;
                this.overwriteHexInBuffer("0F010000" + this.run.hexAndMathFunction.reversehex(hex1, 8) + "630000000000000B00000000", this.mainSettings.saveStructureIndex.inventory_slots_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed * 36 + 4);
                ++this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed;
                string hex2 = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X1");
                while (hex2.Length < 2)
                    hex2 = "0" + hex2;
                this.overwriteHexInBuffer(hex2, this.mainSettings.saveStructureIndex.inventory_slots_used_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
            }
            if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.count < (int)ushort.MaxValue)
            {
                string hex = (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.count + 1).ToString("X2");
                while (hex.Length < 4)
                    hex = "0" + hex;
                this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 4), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 438);
            }
            int num1 = this.getRebirthNowPointGain(level);
            if (this.comboRebirthExtend.SelectedIndex > 0)
                num1 -= 5 * this.comboRebirthExtend.SelectedIndex;
            if (num1 > 999)
                num1 = 999;
            string hex3 = (num1 + this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points).ToString("X2");
            while (hex3.Length < 4)
                hex3 = "0" + hex3;
            this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex3, 4), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 440);
            int num2 = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.additionalTypeLevels + this.getRebirthNowTypeLevelGain(level);
            if (num2 > 20)
                num2 = 20;
            string hex4 = num2.ToString("X1");
            while (hex4.Length < 2)
                hex4 = "0" + hex4;
            this.overwriteHexInBuffer(hex4, this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 283);
            if (!this.chkRebirthNoLevelDrop.Checked)
                this.writeNewLevelData(1);
            this.reloadEverything();
            int num3 = (int)MessageBox.Show("The rebirth completed successfully.\n\nIf you selected to claim extend codes, they will be in the characters inventory.", "Rebirth Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void chkRebirthSpoof_CheckedChanged(object sender, EventArgs e) => this.listRebirthRewards(this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level, this.lstSaveSlotView.SelectedItems[0].Index);

        private void weaponDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.weaponDatabaseForm.initForm();
            this.weaponDatabaseForm.Show((IWin32Window)this);
        }

        private void txtEp1Complete_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtEp1Complete.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You have already completed Episode 1.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want set Episode 1 to complete?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
                int pos = this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 23177 : num2 + 22397;
                if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].story_ep_2_complete)
                    this.overwriteHexInBuffer("03", pos);
                else
                    this.overwriteHexInBuffer("01", pos);
                this.txtEp1Complete.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].story_ep_1_complete = true;
                this.reloadEverything();
                int num3 = (int)MessageBox.Show("Episode 1 was completed successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtEp2Complete_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtEp2Complete.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You have already completed Episode 2.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want set Episode 2 to complete?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
                int pos = this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 23177 : num2 + 22397;
                if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].story_ep_1_complete)
                    this.overwriteHexInBuffer("03", pos);
                else
                    this.overwriteHexInBuffer("02", pos);
                this.txtEp2Complete.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].story_ep_2_complete = true;
                this.reloadEverything();
                int num3 = (int)MessageBox.Show("Episode 2 was completed successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void lstInfinityMissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstInfinityMissions.SelectedItems.Count <= 0)
            {
                this.grpInfinityMissionDetails.Visible = false;
                this.grpInfMisExtra.Visible = false;
                this.grpInfMisSpecial.Visible = false;
                this.btnExportInfinityMission.Enabled = false;
                this.btnDeleteInfinityMission.Enabled = false;
                this.btnModifyInfinityMission.Enabled = false;
            }
            else
            {
                pspo2seForm.infinityMissionClass infinityMissionClass = this.saveData.infinityMissions.slot[int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString())];
                this.txtInfNameEn.Text = this.intToInfinityBoss(infinityMissionClass.boss - 1)[1] + " @ " + this.intToInfinityArea(infinityMissionClass.area - 1)[1];
                this.txtInfNameJp.Text = this.intToInfinityArea(infinityMissionClass.area - 1)[0] + "の" + this.intToInfinityBoss(infinityMissionClass.boss - 1)[0];
                this.txtInfMisSpecial.Text = "Area  " + this.intToInfinityArea(infinityMissionClass.area - 1)[1] + " (" + this.intToInfinityArea(infinityMissionClass.area - 1)[0] + ")";
                this.txtInfMisBoss.Text = "Boss  " + this.intToInfinityBoss(infinityMissionClass.boss - 1)[1] + " (" + this.intToInfinityBoss(infinityMissionClass.boss - 1)[0] + ") [" + (object)infinityMissionClass.length + "]";
                this.txtInfMisEnemy1.Text = "Main Enemy  " + this.intToInfinityEnemy(infinityMissionClass.enemy_1)[1] + " (" + this.intToInfinityEnemy(infinityMissionClass.enemy_1)[0] + ") [" + (object)infinityMissionClass.unk_enemy_1_mod + "]";
                this.txtInfMisEnemy2.Text = "Sub Enemy  " + this.intToInfinityEnemy(infinityMissionClass.enemy_2)[1] + " (" + this.intToInfinityEnemy(infinityMissionClass.enemy_2)[0] + ")";
                this.txtInfEnemyLevel.Text = "Enemy Level  +" + (object)infinityMissionClass.enemy_level + " [" + (object)infinityMissionClass.unk_enemy_level_mod + "]";
                this.txtInfMisSpecial.Text = "Special Effects  " + infinityMissionClass.hex.Substring(12, 20);
                this.txtInfMisCreatedBy.Text = "Created By  " + infinityMissionClass.createdBy;
                this.txtInfMisSynthPoint.Text = "Synthesis Points  " + (object)infinityMissionClass.mergePoints;
                this.grpInfinityMissionDetails.Visible = true;
                this.grpInfMisExtra.Visible = true;
                this.grpInfMisSpecial.Visible = true;
                this.btnExportInfinityMission.Enabled = true;
                this.btnDeleteInfinityMission.Enabled = true;
                this.btnModifyInfinityMission.Enabled = true;
            }
        }

        private void btnExportInfinityMission_Click(object sender, EventArgs e)
        {
            if (this.saveBufferDataToFile(this.mainSettings.saveStructureIndex.infinity_mission_pos + int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 104, 104, "PSPo2i Mission File (*pspo2imission)|*pspo2imission", fileNameDefault: this.lstInfinityMissions.SelectedItems[0].Text))
            {
                int num1 = (int)MessageBox.Show("The mission file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num2 = (int)MessageBox.Show("The mission file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnImportInfinityMission_Click(object sender, EventArgs e)
        {
            string ext_options = "PSPo2i Mission File (*pspo2imission)|*pspo2imission";
            if (this.saveData.infinityMissions.itemsUsed >= 100)
            {
                if (MessageBox.Show("You do not have any available infinity mission slots.\n\nDo you want to overwrite the selected slot?", "Max Slots Reached", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                if (this.lstInfinityMissions.SelectedItems.Count <= 0)
                {
                    int num = (int)MessageBox.Show("You must select a mission from your list to overwrite.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (this.loadFileIntoBuffer(int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 104 + this.mainSettings.saveStructureIndex.infinity_mission_pos, ext_options, pspo2seForm.partFileType.infinity_mission, false) <= 0)
                        return;
                    this.reloadEverything();
                }
            }
            else if (MessageBox.Show("Do you want to import a mission or multiple missions into available slots?", "Confirm Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int num = this.loadFileIntoBuffer(this.saveData.infinityMissions.itemsUsed * 104 + this.mainSettings.saveStructureIndex.infinity_mission_pos, ext_options, pspo2seForm.partFileType.infinity_mission, true);
                if (num <= 0)
                    return;
                this.saveData.infinityMissions.itemsUsed += num;
                string hex = this.saveData.infinityMissions.itemsUsed.ToString("X1");
                while (hex.Length < 2)
                    hex = "0" + hex;
                this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.infinity_mission_pos + 10400);
                this.reloadEverything();
            }
            else
            {
                if (MessageBox.Show("Do you want to overwrite the selected slot?", "Confirm Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                if (this.lstInfinityMissions.SelectedItems.Count <= 0)
                {
                    int num = (int)MessageBox.Show("You must select a mission from your list to overwrite.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (this.loadFileIntoBuffer(int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 104 + this.mainSettings.saveStructureIndex.infinity_mission_pos, ext_options, pspo2seForm.partFileType.infinity_mission, false) <= 0)
                        return;
                    this.reloadEverything();
                }
            }
        }

        private void btnDeleteInfinityMission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the last mission in the list?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            int num = this.saveData.infinityMissions.itemsUsed * 104 + this.mainSettings.saveStructureIndex.infinity_mission_pos;
            --this.saveData.infinityMissions.itemsUsed;
            string hex = this.saveData.infinityMissions.itemsUsed.ToString("X1");
            while (hex.Length < 2)
                hex = "0" + hex;
            this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.infinity_mission_pos + 10400);
            this.overwriteHexInBuffer("1198040121012040800001020100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", this.mainSettings.saveStructureIndex.infinity_mission_pos + 104 * this.saveData.infinityMissions.itemsUsed);
            this.txtInfinityMissionQty.Text = this.saveData.infinityMissions.itemsUsed.ToString() + "/100";
            this.lstInfinityMissions.Items[this.lstInfinityMissions.Items.Count - 1].Remove();
        }

        private void btnModifyInfinityMission_Click(object sender, EventArgs e)
        {
            if (this.lstInfinityMissions.SelectedItems.Count <= 0)
            {
                int num1 = (int)MessageBox.Show("You must select a mission from your list to modify.", "Modify Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.infinityMissionForm.id = int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString());
                int num2 = (int)this.infinityMissionForm.ShowDialog((IWin32Window)this);
            }
        }

        private void changeItemSpecial(TabPage page)
        {
            if (this.legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != this.tabPageStorage ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
            this.entryForm.newVal = ((int)inventoryItemClass.ability).ToString();
            if (inventoryItemClass.style == pspo2seForm.weaponStyleType.Tech)
            {
                this.entryForm.description = "TEC ability";
                this.entryForm.oldVal = (inventoryItemClass.ability + 21).ToString();
            }
            else
            {
                this.entryForm.description = "ability";
                this.entryForm.oldVal = inventoryItemClass.ability.ToString();
            }
            this.entryForm.maxLen = 1;
            if (this.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = this.entryForm.newVal;
            if (!(newVal != ((int)inventoryItemClass.ability).ToString()))
                return;
            if (int.Parse(newVal) >= 21 || inventoryItemClass.style == pspo2seForm.weaponStyleType.Tech && int.Parse(newVal) >= 8)
            {
                int num1 = (int)MessageBox.Show("You must enter a value lower than " + (object)8 + " for TEC weapons and " + (object)10 + " for all others.");
            }
            else if (int.Parse(newVal) < 0)
            {
                int num2 = (int)MessageBox.Show("You must enter a value greater or equal to 0.");
            }
            else
            {
                string hex = int.Parse(newVal).ToString("X1");
                while (hex.Length < 2)
                    hex = "0" + hex;
                this.overwriteHexInBuffer(hex, inventoryItemClass.id + 8);
                inventoryItemClass.ability = (pspo2seForm.abilityType)int.Parse(newVal);
                this.getPageFields(page);
                this.showSelectedInventoryItem(page);
            }
        }

        private void txtInventorySpecial_Click(object sender, EventArgs e) => this.changeItemSpecial(this.tabPageInventory);

        private void txtStorageSpecial_Click(object sender, EventArgs e) => this.changeItemSpecial(this.tabPageStorage);

        private void btnImportMissions_Click(object sender, EventArgs e)
        {
            string ext_options = "PSPo2i Mission Pack File (*pspo2imissions)|*pspo2imissions";
            if (MessageBox.Show("Are you sure you want to import missions overwriting all of the current missions?", "Confirm Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel || this.loadFileIntoBuffer(290888, ext_options, pspo2seForm.partFileType.infinity_mission_pack, false) <= 0)
                return;
            this.reloadEverything();
        }

        private void btnExportMissions_Click(object sender, EventArgs e)
        {
            if (this.saveBufferDataToFile(290888, 10401, "PSPo2i Mission Pack File (*pspo2imissions)|*pspo2imissions", fileNameDefault: "Pspo2 Infinity Mission Pack"))
            {
                int num1 = (int)MessageBox.Show("The mission pack file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num2 = (int)MessageBox.Show("The mission pack file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtAllowQuitMission_Click(object sender, EventArgs e)
        {
            if (this.legitVersion())
                return;
            if (this.txtAllowQuitMission.Text == "Yes")
            {
                int num1 = (int)MessageBox.Show("You can already quit missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want enable quiting missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
                this.overwriteHexInBuffer("FF", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 4441 : num2 + 4517);
                this.txtAllowQuitMission.Text = "Yes";
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].allow_quit_missions = "FF";
                int num3 = (int)MessageBox.Show("The quit mission function was unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void showGameImage()
        {
            switch (this.saveData.type)
            {
                case pspo2seForm.SaveType.PSP2:
                    this.imgSave.Image = (Image)Resources.PSP2;
                    this.imgGameLogo.Image = (Image)Resources.PSP2_logo;
                    this.imgSave.Show();
                    break;
                case pspo2seForm.SaveType.PSP2I:
                    this.imgSave.Image = (Image)Resources.PSP2i;
                    this.imgGameLogo.Image = (Image)Resources.PSP2i_logo;
                    this.imgSave.Show();
                    break;
                default:
                    this.imgGameLogo.Image = (Image)Resources.PSP2_logo;
                    this.imgSave.Hide();
                    break;
            }
        }

        public string getSlotPALearntLevel(int slotnum, string hex)
        {
            if (hex.Substring(0, 2) == "05")
            {
                string str1 = (int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber) + 13).ToString("X1");
                while (str1.Length < 2)
                    str1 = "0" + str1;
                hex = hex.Substring(0, 2) + str1 + hex.Substring(4, 4);
                string str2 = (int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber) + 1).ToString("X1");
                while (str2.Length < 2)
                    str2 = "0" + str2;
                hex = hex.Substring(0, 4) + str2 + hex.Substring(6, 2);
            }
            for (int index = 0; index < 256; ++index)
            {
                if (this.saveData.slot[slotnum].pa.items[index] != null && this.saveData.slot[slotnum].pa.items[index].hex != null && this.saveData.slot[slotnum].pa.items[index].hex == hex)
                    return this.saveData.slot[slotnum].pa.items[index].level;
            }
            return "LV0";
        }

        private string storyCompleteToText(bool ep1_complete, bool ep2_complete) => ep1_complete ? (this.saveData.type == pspo2seForm.SaveType.PSP2 || ep2_complete ? "Game Complete" : "Ep 1 Complete") : (ep2_complete ? "Ep 2 Complete" : "");

        private void displayCharacterInfo(int slotnum)
        {
            if (this.saveData.slot[slotnum].name != "")
                this.txtSlotnumloaded.Text = "Save Slot #" + (object)(slotnum + 1) + " Loaded";
            else
                this.txtSlotnumloaded.Text = "No Save Slot Loaded";
            this.txtCharacterName.Text = this.saveData.slot[slotnum].name;
            this.txtTitle.Text = this.saveData.slot[slotnum].title;
            this.txtPlaytime.Text = this.saveData.slot[slotnum].playtime;
            this.txtCurType.Text = string.Concat((object)this.saveData.slot[slotnum].cur_type);
            this.txtRace.Text = string.Concat((object)this.saveData.slot[slotnum].race);
            this.txtSex.Text = string.Concat((object)this.saveData.slot[slotnum].sex);
            this.txtLevel.Text = string.Concat((object)this.saveData.slot[slotnum].level);
            this.txtExp.Text = string.Concat((object)this.saveData.slot[slotnum].exp);
            this.txtExpNext.Text = string.Concat((object)this.saveData.slot[slotnum].exp_next);
            this.txtLevelExpBar.Width = this.saveData.slot[slotnum].exp_percent * 2;
            this.txtInventoryMeseta.Text = string.Concat((object)this.saveData.slot[slotnum].meseta);
            this.txtStoryComplete.Text = this.storyCompleteToText(this.saveData.slot[slotnum].story_ep_1_complete, this.saveData.slot[slotnum].story_ep_2_complete);
            this.txtStoryComplete.Visible = true;
            this.txtSkipEp1Start.Text = "No";
            if (this.saveData.slot[slotnum].skip_ep_1_start)
                this.txtSkipEp1Start.Text = "Yes";
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                this.txtSkipEp2Start.Text = "No";
                if (this.saveData.slot[slotnum].skip_ep_2_start)
                    this.txtSkipEp2Start.Text = "Yes";
            }
            this.txtMissionEp1.Text = "No";
            this.txtMissionTactical.Text = "No";
            this.txtMissionEp2.Text = "No";
            this.txtMissionMagashi.Text = "No";
            this.txtEp1Complete.Text = "No";
            this.txtEp2Complete.Text = "No";
            this.txtAllowQuitMission.Text = "No";
            if (this.saveData.slot[slotnum].mission_unlock_ep1)
                this.txtMissionEp1.Text = "Yes";
            if (this.saveData.slot[slotnum].mission_unlock_unknown)
                this.txtMissionTactical.Text = "Yes";
            if (this.saveData.slot[slotnum].mission_unlock_ep2)
                this.txtMissionEp2.Text = "Yes";
            if (this.saveData.slot[slotnum].mission_unlock_magashi)
                this.txtMissionMagashi.Text = "Yes";
            if (this.saveData.slot[slotnum].story_ep_1_complete)
                this.txtEp1Complete.Text = "Yes";
            if (this.saveData.slot[slotnum].story_ep_2_complete)
                this.txtEp2Complete.Text = "Yes";
            if (this.saveData.slot[slotnum].allow_quit_missions == "FF")
                this.txtAllowQuitMission.Text = "Yes";
            this.txtStoryEmiliaPoints.Visible = true;
            if (this.saveData.slot[slotnum].story_ep_1_points != null)
                this.txtStoryEmiliaPoints.Text = this.run.hexAndMathFunction.hexToInt(this.saveData.slot[slotnum].story_ep_1_points).ToString() + " Emilia Points";
            if (this.saveData.slot[slotnum].story_ep_2_points != null)
            {
                this.txtStoryNagisaPoints.Text = this.run.hexAndMathFunction.hexToInt(this.saveData.slot[slotnum].story_ep_2_points).ToString() + " Nagisa Points";
                this.txtStoryNagisaPoints.Visible = true;
            }
            else
                this.txtStoryNagisaPoints.Visible = false;
        }

        private int getRebirthNowPointGain(int level) => this.findRebirthBpInfoInDb(level).exp;

        private int getRebirthNowTypeLevelGain(int level)
        {
            if (level < 50)
                return 0;
            if (level >= 200)
                return 20;
            if (level >= 170)
                return 15;
            if (level >= 140)
                return 10;
            return level >= 100 ? 5 : 1;
        }

        private void addRebirthReward(string str, Color col) => this.lstRebirthRewards.Items.Add(new ListViewItem()
        {
            Text = str,
            ForeColor = col
        });

        private void listRebirthRewards(int level, int slot)
        {
            if (this.chkRebirthSpoof.Checked)
                level = 200;
            this.comboRebirthExtend.Items.Clear();
            this.lstRebirthRewards.Items.Clear();
            if (level < 50)
            {
                this.addRebirthReward("Rebirth Not Available.", Color.DarkGray);
                this.addRebirthReward("Next Rebirth in " + (object)(50 - level) + " Levels.", Color.DarkGray);
                this.btnRebirth.Enabled = false;
                this.comboRebirthExtend.Enabled = false;
            }
            else
            {
                this.btnRebirth.Enabled = true;
                this.comboRebirthExtend.Enabled = true;
                int num1 = 0;
                this.comboRebirthExtend.Items.Add((object)("Claim " + (object)this.getRebirthNowPointGain(level) + " bonus points and 0 extend codes."));
                for (int index = 0; index < this.saveData.slot[slot].rebirth.remaining_points + this.getRebirthNowPointGain(level); index += 5)
                {
                    ++num1;
                    if (num1 == 1)
                        this.comboRebirthExtend.Items.Add((object)("Claim " + (object)(this.getRebirthNowPointGain(level) - 5 * num1) + " bonus points and " + (object)num1 + " extend code."));
                    else
                        this.comboRebirthExtend.Items.Add((object)("Claim " + (object)(this.getRebirthNowPointGain(level) - 5 * num1) + " bonus points and " + (object)num1 + " extend codes."));
                    if (num1 == 10)
                        break;
                }
                this.comboRebirthExtend.SelectedIndex = 0;
                this.addRebirthReward("Up to " + (object)num1 + " extend codes.", Color.DarkGreen);
                this.addRebirthReward("Up to " + (object)this.getRebirthNowPointGain(level) + " bonus points.", Color.DarkGreen);
                if (30 + this.saveData.slot[slot].rebirth.additionalTypeLevels >= 50)
                    return;
                int num2 = 30 + this.saveData.slot[slot].rebirth.additionalTypeLevels + this.getRebirthNowTypeLevelGain(level);
                if (num2 > 50)
                    num2 = 50;
                this.addRebirthReward("Maximum type level " + (object)num2 + ".", Color.DarkGreen);
            }
        }

        private void displayTypePage(int slotnum, pspo2seForm.jobType i)
        {
            bool flag = false;
            if (this.saveData.slot[slotnum].job[(int)i].level >= 30 + this.saveData.slot[slotnum].rebirth.additionalTypeLevels)
                flag = true;
            if (flag)
            {
                this.saveData.slot[slotnum].job[(int)i].exp_to_next = 0;
                this.saveData.slot[slotnum].job[(int)i].exp_next = this.saveData.slot[slotnum].job[(int)i].exp;
                this.saveData.slot[slotnum].job[(int)i].exp_percent = 100;
            }
            else
            {
                pspo2seForm.expDb_ItemClass expDbItemClass = new pspo2seForm.expDb_ItemClass();
                pspo2seForm.expDb_ItemClass expTypeInfoInDb = this.findExpTypeInfoInDb(this.saveData.slot[slotnum].job[(int)i].level);
                if (expTypeInfoInDb == null)
                {
                    int num = (int)MessageBox.Show("could not find typeexp for type level " + (object)this.saveData.slot[slotnum].job[(int)i].level);
                }
                this.saveData.slot[slotnum].job[(int)i].exp_to_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next - this.saveData.slot[slotnum].job[(int)i].exp;
                this.saveData.slot[slotnum].job[(int)i].exp_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next;
                this.saveData.slot[slotnum].job[(int)i].exp_percent = expTypeInfoInDb.exp_next != 0 ? this.run.hexAndMathFunction.getPercentage(this.saveData.slot[slotnum].job[(int)i].exp - expTypeInfoInDb.exp, expTypeInfoInDb.exp_next) : 100;
            }
            pspo2seForm.typeSectionFields typeSectionFields1 = new pspo2seForm.typeSectionFields();
            TabPage page = new TabPage();
            switch (i)
            {
                case pspo2seForm.jobType.Hunter:
                    page = this.tabPageHunter;
                    break;
                case pspo2seForm.jobType.Ranger:
                    page = this.tabPageRanger;
                    break;
                case pspo2seForm.jobType.Force:
                    page = this.tabPageForce;
                    break;
                case pspo2seForm.jobType.Vanguard:
                    page = this.tabPageVanguard;
                    break;
                default:
                    int num1 = (int)MessageBox.Show("jobType " + (object)i + " not handled in displayTypePage", "Fatal Error!");
                    break;
            }
            string str = page.Name.Replace("tabPage", "");
            pspo2seForm.typeSectionFields typeSectionFields2 = this.getTypeSectionFields(page);
            page.Text = str + " (" + (object)this.saveData.slot[slotnum].job[(int)i].level + ")";
            typeSectionFields2.txtLevel.Text = string.Concat((object)this.saveData.slot[slotnum].job[(int)i].level);
            typeSectionFields2.grpExtend.Text = "Type Extend " + (object)this.saveData.slot[slotnum].job[(int)i].extendpointsused + "/" + (object)this.saveData.slot[slotnum].job[(int)i].extendpoints;
            typeSectionFields2.txtExp.Text = "Next " + (object)this.saveData.slot[slotnum].job[(int)i].exp_to_next;
            typeSectionFields2.expBar.Width = this.saveData.slot[slotnum].job[(int)i].exp_percent;
            this.showTypeWeaponExtendImages(this.saveData.slot[slotnum].job[(int)i], page);
        }

        private void displayTypeInfo(int slotnum)
        {
            for (int index = 0; index < 4; ++index)
                this.displayTypePage(slotnum, (pspo2seForm.jobType)index);
        }

        private void showTypeWeaponExtendImages(pspo2seForm.jobClass type, TabPage page)
        {
            pspo2seForm.typeWeaponRankFields weaponExtendFields = this.getTypeWeaponExtendFields(page);
            for (int index = 1; index <= 28; ++index)
            {
                switch (type.weapons_extended[index])
                {
                    case pspo2seForm.extendRankType.none:
                        weaponExtendFields.imgWeap[index].Visible = false;
                        weaponExtendFields.imgRank[index].Visible = false;
                        break;
                    case pspo2seForm.extendRankType.c:
                        weaponExtendFields.imgWeap[index].Visible = true;
                        weaponExtendFields.imgRank[index].Visible = true;
                        weaponExtendFields.imgRank[index].Image = (Image)Resources.rank_C;
                        break;
                    case pspo2seForm.extendRankType.b:
                        weaponExtendFields.imgWeap[index].Visible = true;
                        weaponExtendFields.imgRank[index].Visible = true;
                        weaponExtendFields.imgRank[index].Image = (Image)Resources.rank_B;
                        break;
                    case pspo2seForm.extendRankType.a:
                        weaponExtendFields.imgWeap[index].Visible = true;
                        weaponExtendFields.imgRank[index].Visible = true;
                        weaponExtendFields.imgRank[index].Image = (Image)Resources.rank_A;
                        break;
                    case pspo2seForm.extendRankType.s:
                        weaponExtendFields.imgWeap[index].Visible = true;
                        weaponExtendFields.imgRank[index].Visible = true;
                        weaponExtendFields.imgRank[index].Image = (Image)Resources.rank_S;
                        break;
                }
            }
        }

        private void displaySlotInfo(int slotnum)
        {
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                bool flag1 = true;
                foreach (TabPage tabPage in this.tabControlMissions.TabPages)
                {
                    if (tabPage == this.tabEp2Missions)
                    {
                        flag1 = false;
                        break;
                    }
                }
                if (flag1)
                {
                    this.tabControlMissions.TabPages.Add(this.tabEp2Missions);
                    this.tabControlMissions.TabPages.Add(this.tabPageInfinityMission);
                }
                bool flag2 = true;
                foreach (TabPage tabPage in this.tabArea.TabPages)
                {
                    if (tabPage == this.tabPageRebirth)
                    {
                        flag2 = false;
                        break;
                    }
                }
                if (flag2)
                    this.tabArea.TabPages.Add(this.tabPageRebirth);
            }
            else
            {
                bool flag1 = false;
                foreach (TabPage tabPage in this.tabControlMissions.TabPages)
                {
                    if (tabPage == this.tabEp2Missions)
                    {
                        flag1 = true;
                        break;
                    }
                }
                if (flag1)
                {
                    this.tabControlMissions.TabPages.Remove(this.tabEp2Missions);
                    this.tabControlMissions.TabPages.Remove(this.tabPageInfinityMission);
                }
                bool flag2 = false;
                foreach (TabPage tabPage in this.tabArea.TabPages)
                {
                    if (tabPage == this.tabPageRebirth)
                    {
                        flag2 = true;
                        break;
                    }
                }
                if (flag2)
                    this.tabArea.TabPages.Remove(this.tabPageRebirth);
            }
            this.displayCharacterInfo(slotnum);
            this.displayRebirthInfo(slotnum);
            this.displayTypeInfo(slotnum);
            this.displayInventory(slotnum, 1);
            this.displaySharedStorage(1);
            this.displayPAList(slotnum);
            this.displayInfinityMissions();
        }

        private void displayInfinityMissions()
        {
            this.lstInfinityMissions.Items.Clear();
            this.txtInfinityMissionQty.Text = this.saveData.infinityMissions.itemsUsed.ToString() + "/100";
            for (int index = 0; index < this.saveData.infinityMissions.itemsUsed; ++index)
            {
                ListViewItem listViewItem1 = new ListViewItem();
                listViewItem1.Text = this.intToInfinityBoss(this.saveData.infinityMissions.slot[index].boss - 1)[1] + " @ " + this.intToInfinityArea(this.saveData.infinityMissions.slot[index].area - 1)[1];
                ListViewItem listViewItem2 = listViewItem1;
                listViewItem2.Text = listViewItem2.Text + " (" + this.intToInfinityArea(this.saveData.infinityMissions.slot[index].area - 1)[0] + "の" + this.intToInfinityBoss(this.saveData.infinityMissions.slot[index].boss - 1)[0] + ")";
                listViewItem1.Tag = (object)this.saveData.infinityMissions.slot[index].id;
                listViewItem1.SubItems.Add("LV" + (object)this.saveData.infinityMissions.slot[index].level);
                this.lstInfinityMissions.Items.Add(listViewItem1);
            }
        }

        private unsafe void getRebirthValues(int val, string type, int* points, int* stat, int* next)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            switch (type)
            {
                case "HP":
                    num1 = 15;
                    num2 = 5;
                    num3 = 50;
                    break;
                case "PP":
                    num1 = 5;
                    num2 = 5;
                    num3 = 5;
                    break;
                case "ATK":
                    num1 = 20;
                    num2 = 5;
                    num3 = 35;
                    break;
                case "DEF":
                    num1 = 8;
                    num2 = 4;
                    num3 = 30;
                    break;
                case "ACC":
                    num1 = 25;
                    num2 = 5;
                    num3 = 20;
                    break;
                case "EVA":
                    num1 = 25;
                    num2 = 5;
                    num3 = 8;
                    break;
                case "TEC":
                    num1 = 20;
                    num2 = 5;
                    num3 = 50;
                    break;
                case "MND":
                    num1 = 8;
                    num2 = 4;
                    num3 = 40;
                    break;
                case "STA":
                    num1 = 2;
                    num2 = 2;
                    num3 = 2;
                    break;
            }
            *next = num1;
            *points = 0;
            for (int index = 0; index < val; ++index)
            {
                int* numPtr1 = points;
                int num4 = *numPtr1 + *next;
                *numPtr1 = num4;
                int* numPtr2 = stat;
                int num5 = *numPtr2 + num3;
                *numPtr2 = num5;
                int* numPtr3 = next;
                int num6 = *numPtr3 + num2;
                *numPtr3 = num6;
            }
        }

        private unsafe void displayRebirthStatInfo(
          int slot,
          int statVal,
          string switchFlag,
          Label statTextBox,
          Label bpTextBox,
          NumericUpDown numBox,
          Label nextTextBox)
        {
            int num1;
            int num2;
            int num3;
            this.getRebirthValues(statVal, switchFlag, &num1, &num2, &num3);
            statTextBox.Text = "+" + (object)num2;
            bpTextBox.Text = string.Concat((object)num1);
            if (statVal >= 10)
                nextTextBox.Text = "max";
            else
                nextTextBox.Text = "+" + (object)num3 + "pt";
            nextTextBox.ForeColor = Color.DarkGreen;
            if (num3 > this.saveData.slot[slot].rebirth.remaining_points || statVal >= 10)
                nextTextBox.ForeColor = Color.DarkRed;
            numBox.Value = (Decimal)statVal;
        }

        private unsafe int getRebirthValuePtsUsed(int slot, int val, string switchFlag)
        {
            int num1;
            int num2;
            int num3;
            this.getRebirthValues(val, switchFlag, &num1, &num2, &num3);
            return num1;
        }

        private void displayRebirthInfo(int slot)
        {
            if (this.saveData.type != pspo2seForm.SaveType.PSP2I)
            {
                this.grpRebirth.Visible = false;
            }
            else
            {
                this.grpRebirth.Visible = true;
                int num = this.saveData.slot[slot].rebirth.remaining_points + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.hp, "HP") + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.pp, "PP") + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.atk, "ATK") + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.def, "DEF") + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.acc, "ACC") + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.eva, "EVA") + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.tec, "TEC") + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.mnd, "MND") + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.sta, "STA");
                this.txtRebirthCount.Text = this.saveData.slot[slot].rebirth.count.ToString();
                this.txtRebirthPoints.Text = "BP " + this.saveData.slot[slot].rebirth.remaining_points.ToString() + "/" + (object)num;
                this.txtRebirthMaxType.Text = string.Concat((object)(30 + this.saveData.slot[slot].rebirth.additionalTypeLevels));
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.hp, "HP", this.txtRebirthHP, this.txtRebirthBpHP, this.numRebirthHP, this.txtRebirthNextHP);
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.pp, "PP", this.txtRebirthPP, this.txtRebirthBpPP, this.numRebirthPP, this.txtRebirthNextPP);
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.atk, "ATK", this.txtRebirthATK, this.txtRebirthBpATK, this.numRebirthATK, this.txtRebirthNextATK);
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.def, "DEF", this.txtRebirthDEF, this.txtRebirthBpDEF, this.numRebirthDEF, this.txtRebirthNextDEF);
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.acc, "ACC", this.txtRebirthACC, this.txtRebirthBpACC, this.numRebirthACC, this.txtRebirthNextACC);
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.eva, "EVA", this.txtRebirthEVA, this.txtRebirthBpEVA, this.numRebirthEVA, this.txtRebirthNextEVA);
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.tec, "TEC", this.txtRebirthTEC, this.txtRebirthBpTEC, this.numRebirthTEC, this.txtRebirthNextTEC);
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.mnd, "MND", this.txtRebirthMND, this.txtRebirthBpMND, this.numRebirthMND, this.txtRebirthNextMND);
                this.displayRebirthStatInfo(slot, this.saveData.slot[slot].rebirth.sta, "STA", this.txtRebirthSTA, this.txtRebirthBpSTA, this.numRebirthSTA, this.txtRebirthNextSTA);
                this.listRebirthRewards(this.saveData.slot[slot].level, slot);
            }
        }

        private void displayPAList(int slot)
        {
            this.lstPAMelee.Items.Clear();
            this.lstPABullets.Items.Clear();
            this.lstPATechs.Items.Clear();
            ArrayList arrayList = ArrayList.Adapter((IList)this.saveData.slot[slot].pa.items);
            arrayList.Sort();
            this.saveData.slot[slot].pa.items = (pspo2seForm.inventoryItemClass[])arrayList.ToArray(typeof(pspo2seForm.inventoryItemClass));
            for (int index = 0; index < 256; ++index)
            {
                if (!(this.saveData.slot[slot].pa.items[index].hex == ""))
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.ImageIndex = int.Parse(this.saveData.slot[slot].pa.items[index].hex.Substring(2, 2), NumberStyles.HexNumber) - 1;
                    if (this.saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "06")
                        listViewItem.ImageIndex += 28;
                    pspo2seForm.itemDb_ItemClass itemDbItemClass = new pspo2seForm.itemDb_ItemClass();
                    string hex = this.saveData.slot[slot].pa.items[index].hex_reversed;
                    if (this.saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "05")
                    {
                        int num = int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                        num -= 13;
                        string str1 = num.ToString("X1");
                        while (str1.Length < 2)
                            str1 = "0" + str1;
                        num = int.Parse(this.saveData.slot[slot].pa.items[index].hex_reversed.Substring(2, 2), NumberStyles.HexNumber) - 1;
                        string str2 = num.ToString("X1");
                        while (str2.Length < 2)
                            str2 = "0" + str2;
                        hex = this.saveData.slot[slot].pa.items[index].hex_reversed.Substring(0, 2) + str2 + str1 + this.saveData.slot[slot].pa.items[index].hex_reversed.Substring(6, 2);
                    }
                    pspo2seForm.itemDb_ItemClass itemInDb = this.findItemInDb(hex);
                    listViewItem.Text = itemInDb.name;
                    if (itemInDb.name == "")
                        listViewItem.Text = itemInDb.name_jp;
                    listViewItem.SubItems.Add(this.saveData.slot[slot].pa.items[index].level);
                    listViewItem.Tag = (object)index.ToString();
                    if (this.saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "04")
                        this.lstPAMelee.Items.Add(listViewItem);
                    if (this.saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "05")
                        this.lstPABullets.Items.Add(listViewItem);
                    if (this.saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "06")
                        this.lstPATechs.Items.Add(listViewItem);
                }
            }
        }

        private void updateRebirthBufferVals(int slot)
        {
            int num = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * slot + 438;
            for (int index = 0; index < 12; ++index)
            {
                string hex = "";
                switch (index)
                {
                    case 0:
                        hex = this.saveData.slot[slot].rebirth.count.ToString("X2");
                        break;
                    case 1:
                        hex = this.saveData.slot[slot].rebirth.remaining_points.ToString("X2");
                        break;
                    case 2:
                        hex = this.saveData.slot[slot].rebirth.atk.ToString("X2");
                        break;
                    case 3:
                        hex = this.saveData.slot[slot].rebirth.def.ToString("X2");
                        break;
                    case 4:
                        hex = this.saveData.slot[slot].rebirth.acc.ToString("X2");
                        break;
                    case 5:
                        hex = this.saveData.slot[slot].rebirth.eva.ToString("X2");
                        break;
                    case 6:
                        hex = this.saveData.slot[slot].rebirth.sta.ToString("X2");
                        break;
                    case 8:
                        hex = this.saveData.slot[slot].rebirth.tec.ToString("X2");
                        break;
                    case 9:
                        hex = this.saveData.slot[slot].rebirth.mnd.ToString("X2");
                        break;
                    case 10:
                        hex = this.saveData.slot[slot].rebirth.hp.ToString("X2");
                        break;
                    case 11:
                        hex = this.saveData.slot[slot].rebirth.pp.ToString("X2");
                        break;
                }
                if (hex != "")
                {
                    while (hex.Length < 4)
                        hex = "0" + hex;
                    this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 4), num + index * 2);
                }
            }
        }

        private void initSaveBuffer()
        {
            this.savedata_decimal_array_filled = 0;
            this.savedata_decimal_array_read_pos = 0;
            this.saveData = new pspo2seForm.saveDataType();
        }

        private void initSlotVars()
        {
            for (int index1 = 0; index1 < 8; ++index1)
            {
                this.saveData.slot[index1] = new pspo2seForm.saveSlotType();
                this.saveData.slot[index1].used = false;
                this.saveData.slot[index1].name = "";
                this.saveData.slot[index1].title = "-";
                this.saveData.slot[index1].playtime = "00:00:00";
                this.saveData.slot[index1].race = pspo2seForm.raceTypes.None;
                this.saveData.slot[index1].sex = pspo2seForm.sexType.None;
                this.saveData.slot[index1].cur_type = pspo2seForm.jobType.None;
                this.saveData.slot[index1].level = 0;
                this.saveData.slot[index1].exp = 0;
                this.saveData.slot[index1].meseta = 0L;
                this.saveData.slot[index1].allow_quit_missions = "";
                this.saveData.slot[index1].story_ep_1_complete = false;
                this.saveData.slot[index1].story_ep_1_points = "0000";
                this.saveData.slot[index1].story_ep_1_best_end = "0000";
                for (int index2 = 0; index2 < 4; ++index2)
                {
                    this.saveData.slot[index1].job[index2] = new pspo2seForm.jobClass();
                    this.saveData.slot[index1].job[index2].level = 0;
                    this.saveData.slot[index1].job[index2].exp = 0;
                    this.saveData.slot[index1].job[index2].extendpoints = 0;
                    this.saveData.slot[index1].job[index2].extendpointsused = 0;
                }
                this.saveData.slot[index1].inventory = new pspo2seForm.inventoryClass();
                this.saveData.slot[index1].inventory.itemsUsed = 0;
                for (int index2 = 0; index2 < 60; ++index2)
                {
                    this.saveData.slot[index1].inventory.item[index2] = new pspo2seForm.inventoryItemClass();
                    this.saveData.slot[index1].inventory.item[index2].used = false;
                    this.saveData.slot[index1].inventory.item[index2].type = pspo2seForm.itemType.free_slot;
                    this.saveData.slot[index1].inventory.item[index2].hex = "";
                    this.saveData.slot[index1].inventory.item[index2].element = pspo2seForm.elementType.Neutral;
                    this.saveData.slot[index1].inventory.item[index2].percent = 0;
                    this.saveData.slot[index1].inventory.item[index2].qty = 0;
                    this.saveData.slot[index1].inventory.item[index2].qty_max = 0;
                }
            }
            this.saveData.infinityMissions.itemsUsed = 0;
            for (int index = 0; index < 100; ++index)
                this.saveData.infinityMissions.slot[index] = new pspo2seForm.infinityMissionClass();
            for (int index = 0; index < 2000; ++index)
            {
                this.saveData.sharedInventory.item[index] = new pspo2seForm.inventoryItemClass();
                this.saveData.sharedInventory.item[index].used = false;
                this.saveData.sharedInventory.item[index].type = pspo2seForm.itemType.free_slot;
                this.saveData.sharedInventory.item[index].hex = "";
                this.saveData.sharedInventory.item[index].element = pspo2seForm.elementType.Neutral;
                this.saveData.sharedInventory.item[index].percent = 0;
                this.saveData.sharedInventory.item[index].qty = 0;
                this.saveData.sharedInventory.item[index].qty_max = 0;
            }
            this.saveData.sharedMeseta = 0L;
        }

        private bool validate_character_file_length(int length)
        {
            if (this.mainSettings.saveStructureIndex.slot_size == length)
                return true;
            int num = (int)MessageBox.Show("The character file appears to be incorrect", "File Error");
            return false;
        }

        private void refreshFromBuffer()
        {
            if (this.reloadSaveFile())
                return;
            int num = (int)MessageBox.Show("There was an error reloading the save data from the buffer");
        }

        public void reloadEverything()
        {
            int index = this.lstSaveSlotView.SelectedItems[0].Index;
            this.loadSaveFile(true);
            this.lstSaveSlotView.Items[index].Selected = true;
        }

        private bool reloadSaveFile() => this.loadSaveFile(false);

        private bool loadSaveFile(bool reload)
        {
            this.disableMainForm();
            this.lstSaveSlotView.Items.Clear();
            if (!this.parseSaveFile(this.txtFileLoc.Text, reload))
            {
                this.tabArea.SelectedTab = this.tabPageInfo;
                this.tabArea.SelectedIndex = 0;
                this.inventoryViewPages.SelectedIndex = 0;
                this.storageViewPages.SelectedIndex = 0;
                this.tabArea.Enabled = false;
                this.lstSaveSlotView.Enabled = false;
                this.showGameImage();
                int num = (int)MessageBox.Show("Invalid file detected [" + this.txtFileSize.Text + "]", "File Error");
                this.enableMainForm();
                return false;
            }
            this.tabArea.Enabled = true;
            this.lstSaveSlotView.Enabled = true;
            this.showGameImage();
            if (this.lstSaveSlotView.Items.Count > 0)
                this.lstSaveSlotView.Items[0].Selected = true;
            this.enableMainForm();
            return true;
        }

        public void writeNewLevelData(int newvalue)
        {
            pspo2seForm.expDb_ItemClass expLevelInfoInDb = this.findExpLevelInfoInDb(newvalue);
            this.overwriteHexInBuffer(expLevelInfoInDb.level.ToString("X2"), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 232);
            string hex = expLevelInfoInDb.exp.ToString("X4");
            while (hex.Length < 8)
                hex = "0" + hex;
            this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 8), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 240);
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level = expLevelInfoInDb.level;
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].exp = expLevelInfoInDb.exp;
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].exp_next = expLevelInfoInDb.exp_next;
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].exp_percent = 0;
            this.lstSaveSlotView.SelectedItems[0].SubItems[1].Text = "LV" + (object)expLevelInfoInDb.level;
            this.displaySlotInfo(this.lstSaveSlotView.SelectedItems[0].Index);
        }

        private void jumpToLevel()
        {
            if (this.legitVersion())
                return;
            this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level.ToString();
            this.entryForm.newVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level.ToString();
            this.entryForm.description = "character level";
            this.entryForm.maxLen = 3;
            bool flag = false;
            while (!flag)
            {
                if (this.entryForm.ShowDialog((IWin32Window)this) == DialogResult.OK)
                {
                    int newvalue = int.Parse(this.entryForm.newVal);
                    if (newvalue > 200)
                    {
                        int num1 = (int)MessageBox.Show("Level 200+ is not allowed\r\nThat's just stupid right?");
                    }
                    else if (newvalue < 1)
                    {
                        int num2 = (int)MessageBox.Show("Level 1 is the lowest");
                    }
                    else
                    {
                        if (newvalue != this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level)
                            this.writeNewLevelData(newvalue);
                        flag = true;
                    }
                }
                else
                    flag = true;
            }
        }

        private void jumpToTypeLevel()
        {
            if (this.legitVersion())
                return;
            int index = this.lstSaveSlotView.SelectedItems[0].Index;
            int selectedIndex = this.tabControlClasses.SelectedIndex;
            this.entryForm.oldVal = this.saveData.slot[index].job[selectedIndex].level.ToString();
            this.entryForm.newVal = this.saveData.slot[index].job[selectedIndex].level.ToString();
            this.entryForm.description = "character type level";
            this.entryForm.maxLen = 2;
            bool flag = false;
            while (!flag)
            {
                if (this.entryForm.ShowDialog((IWin32Window)this) == DialogResult.OK)
                {
                    int level = int.Parse(this.entryForm.newVal);
                    if (level > 30 + this.saveData.slot[index].rebirth.additionalTypeLevels)
                    {
                        int num1 = (int)MessageBox.Show("You cannot enter a level greater than " + (object)(30 + this.saveData.slot[index].rebirth.additionalTypeLevels) + ".\n\nYou will need to rebirth to increase your max type level.", "Max Level Reached", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (level < 1)
                    {
                        int num2 = (int)MessageBox.Show("You must enter a level greater than 0.", "Type Level Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        if (level != this.saveData.slot[index].job[selectedIndex].level)
                        {
                            pspo2seForm.expDb_ItemClass expTypeInfoInDb = this.findExpTypeInfoInDb(level);
                            int pos1 = this.mainSettings.saveStructureIndex.type_level_pos + this.mainSettings.saveStructureIndex.slot_size * index + 4 * selectedIndex;
                            this.overwriteHexInBuffer(expTypeInfoInDb.level.ToString("X2"), pos1);
                            int pos2 = pos1 + 2;
                            int exp = expTypeInfoInDb.exp;
                            if (exp >= 65536)
                            {
                                exp -= 65536;
                                this.overwriteHexInBuffer("01", pos2);
                                this.saveData.slot[index].job[selectedIndex].scramble_exp = 1;
                            }
                            else
                            {
                                this.overwriteHexInBuffer("00", pos2);
                                this.saveData.slot[index].job[selectedIndex].scramble_exp = 0;
                            }
                            int pos3 = pos2 + 1;
                            this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(exp.ToString("X4"), 4), pos3);
                            int pos4 = this.mainSettings.saveStructureIndex.type_level_pos + this.mainSettings.saveStructureIndex.slot_size * index + 16 + selectedIndex * this.mainSettings.saveStructureIndex.type_extend_size;
                            this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(expTypeInfoInDb.extend_points.ToString("X4"), 4), pos4);
                            this.saveData.slot[index].job[selectedIndex].level = level;
                            this.saveData.slot[index].job[selectedIndex].exp = expTypeInfoInDb.exp;
                            this.saveData.slot[index].job[selectedIndex].extendpoints = expTypeInfoInDb.extend_points;
                            this.saveData.slot[index].job[selectedIndex].exp_to_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next - this.saveData.slot[index].job[selectedIndex].exp;
                            this.saveData.slot[index].job[selectedIndex].exp_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next;
                            this.saveData.slot[index].job[selectedIndex].exp_percent = expTypeInfoInDb.exp_next != 0 ? this.run.hexAndMathFunction.getPercentage(this.saveData.slot[index].job[selectedIndex].exp - expTypeInfoInDb.exp, expTypeInfoInDb.exp_next) : 100;
                            this.displayTypeInfo(index);
                        }
                        flag = true;
                    }
                }
                else
                    flag = true;
            }
        }

        private unsafe string brGetData(
          int bytes,
          BinaryReader br,
          int* pos,
          pspo2seForm.saveInfoDataType return_type,
          bool reload,
          bool showSaveParseProgress)
        {
            bool flag = true;
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            int num1 = *pos;
            int* numPtr = pos;
            int num2 = *numPtr + bytes;
            *numPtr = num2;
            for (int index = 0; index < bytes; ++index)
            {
                int byte_decimal = this.readByteAndSaveInSaveBuffer(br, reload, "GET DATA", showSaveParseProgress);
                if (stringBuilder2.Length == 0)
                    stringBuilder2.Append(this.run.hexAndMathFunction.decimalByteConvert(byte_decimal, return_type.ToString()));
                else
                    stringBuilder2.Append(this.run.hexAndMathFunction.decimalByteConvert(byte_decimal, return_type.ToString()) ?? "");
                if (flag)
                    stringBuilder1.Append(this.run.hexAndMathFunction.decimalByteConvert(byte_decimal, return_type.ToString()));
                flag = !flag;
            }
            return return_type == pspo2seForm.saveInfoDataType.str ? stringBuilder1.ToString() : stringBuilder2.ToString();
        }

        public string intTo2digitString(int num, int minlen)
        {
            string str = num.ToString();
            while (str.Length < minlen)
                str = "0" + str;
            return str;
        }

        public unsafe int brGetInt32(
          int* pos,
          BinaryReader br,
          bool reload,
          bool showSaveParseProgress,
          string debugHelper = "")
        {
            string s = this.run.hexAndMathFunction.reversehex(this.brGetData(4, br, pos, pspo2seForm.saveInfoDataType.hex, reload, showSaveParseProgress), 8);
            if (debugHelper != "")
            {
                int num = (int)MessageBox.Show("[" + debugHelper + "]\r\nhex is " + s + "\r\nint32 is" + (object)int.Parse(s, NumberStyles.HexNumber));
            }
            return int.Parse(s, NumberStyles.HexNumber);
        }

        public unsafe int brGetInt(
          int bytes,
          int* pos,
          BinaryReader br,
          bool reload,
          bool showSaveParseProgress,
          string debugHelper = "")
        {
            string s = this.run.hexAndMathFunction.reversehex(this.brGetData(bytes, br, pos, pspo2seForm.saveInfoDataType.hex, reload, showSaveParseProgress), bytes * 2);
            if (debugHelper != "")
            {
                int num = (int)MessageBox.Show("[" + debugHelper + "]\r\nhex is " + s + "\r\nint is" + (object)int.Parse(s, NumberStyles.HexNumber));
            }
            return int.Parse(s, NumberStyles.HexNumber);
        }

        public unsafe void brSkipBytes(
          int bytes,
          int* pos,
          BinaryReader br,
          bool reload,
          bool showSaveParseProgress)
        {
            this.brGetData(bytes, br, pos, pspo2seForm.saveInfoDataType.hex, reload, showSaveParseProgress);
        }

        public unsafe pspo2seForm.inventoryItemClass brGetItem(
          int* pos,
          BinaryReader br,
          bool reload)
        {
            pspo2seForm.inventoryItemClass inventoryItemClass = new pspo2seForm.inventoryItemClass()
            {
                id = *pos,
                hex = this.brGetData(4, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true)
            };
            inventoryItemClass.hex_reversed = this.run.hexAndMathFunction.reversehex(inventoryItemClass.hex, 8);
            if (inventoryItemClass.hex == "00000000" || inventoryItemClass.hex == "FFFFFFFF")
            {
                inventoryItemClass.type = pspo2seForm.itemType.free_slot;
                inventoryItemClass.used = false;
            }
            else
            {
                inventoryItemClass.type = this.getItemTypeFromHex(inventoryItemClass.hex);
                inventoryItemClass.used = true;
            }
            if (inventoryItemClass.type == pspo2seForm.itemType.Weapon)
            {
                this.brSkipBytes(4, pos, br, reload, true);
                inventoryItemClass.ability = (pspo2seForm.abilityType)this.brGetInt(1, pos, br, reload, true);
                string data1 = this.brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                inventoryItemClass.spcl_effect = this.hexToEffect(data1);
                inventoryItemClass.inf_extended = (pspo2seForm.itemInfExtendType)int.Parse(data1.Substring(1, 1), NumberStyles.HexNumber);
                inventoryItemClass.spcl_effect_info = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                string data2 = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                inventoryItemClass.power_add = int.Parse(this.run.hexAndMathFunction.reversehex(data2, 4), NumberStyles.HexNumber);
                string data3 = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                inventoryItemClass.grinds = int.Parse(data3.Substring(0, 1), NumberStyles.HexNumber);
                inventoryItemClass.extended = int.Parse(data3.Substring(1, 1), NumberStyles.HexNumber);
                inventoryItemClass.locked = false;
                if (int.Parse(data3.Substring(2, 1), NumberStyles.HexNumber) != 0)
                    inventoryItemClass.locked = true;
                inventoryItemClass.rarity = int.Parse(data3.Substring(3, 1), NumberStyles.HexNumber);
                if (int.Parse(data3.Substring(2, 1), NumberStyles.HexNumber) == 15)
                {
                    inventoryItemClass.locked = false;
                    inventoryItemClass.rarity = -1;
                }
            }
            else
            {
                inventoryItemClass.qty = this.brGetInt32(pos, br, reload, true);
                inventoryItemClass.qty_max = this.brGetInt32(pos, br, reload, true);
                this.brSkipBytes(2, pos, br, reload, true);
                string data = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                inventoryItemClass.grinds = int.Parse(data.Substring(0, 1), NumberStyles.HexNumber);
                inventoryItemClass.extended = int.Parse(data.Substring(1, 1), NumberStyles.HexNumber);
                inventoryItemClass.locked = false;
                if (int.Parse(data.Substring(2, 1), NumberStyles.HexNumber) != 0)
                    inventoryItemClass.locked = true;
                inventoryItemClass.rarity = int.Parse(data.Substring(3, 1), NumberStyles.HexNumber);
            }
            inventoryItemClass.pa_level = this.brGetInt(1, pos, br, reload, true);
            inventoryItemClass.element = (pspo2seForm.elementType)inventoryItemClass.pa_level;
            inventoryItemClass.percent = this.brGetInt(1, pos, br, reload, true);
            inventoryItemClass.style = (pspo2seForm.weaponStyleType)this.brGetInt(1, pos, br, reload, true);
            if (inventoryItemClass.type == pspo2seForm.itemType.Weapon)
                inventoryItemClass.hand = (pspo2seForm.weaponHandType)this.brGetInt(1, pos, br, reload, true);
            else
                inventoryItemClass.clothes_man = (pspo2seForm.clothesManufacturerType)this.brGetInt(1, pos, br, reload, true);
            pspo2seForm.itemDb_ItemClass itemDbItemClass = new pspo2seForm.itemDb_ItemClass();
            pspo2seForm.itemDb_ItemClass itemInDb = this.findItemInDb(inventoryItemClass.hex_reversed);
            inventoryItemClass.name = itemInDb.name;
            inventoryItemClass.name_jp = itemInDb.name_jp;
            inventoryItemClass.desc = itemInDb.desc;
            inventoryItemClass.desc_jp = itemInDb.desc_jp;
            inventoryItemClass.infinity_item = itemInDb.infinity_item;
            inventoryItemClass.power = itemInDb.power;
            inventoryItemClass.acc = itemInDb.acc;
            inventoryItemClass.level = itemInDb.level;
            inventoryItemClass.ext_power = itemInDb.ext_power;
            inventoryItemClass.ext_acc = itemInDb.ext_acc;
            inventoryItemClass.ext_level = itemInDb.ext_level;
            inventoryItemClass.inf_ext_power = itemInDb.inf_ext_power;
            inventoryItemClass.inf_ext_acc = itemInDb.inf_ext_acc;
            inventoryItemClass.inf_ext_level = itemInDb.inf_ext_level;
            inventoryItemClass.special = itemInDb.special;
            inventoryItemClass.special_level = itemInDb.special_level;
            inventoryItemClass.ext_special_level = itemInDb.ext_special_level;
            return inventoryItemClass;
        }

        public int readByteAndSaveInSaveBuffer(
          BinaryReader br,
          bool reload,
          string debugHelper,
          bool showSaveParseProgress)
        {
            ++this.chunkPos;
            int num1 = 0;
            if (!reload)
            {
                try
                {
                    num1 = (int)br.ReadByte();
                    if (this.savedata_decimal_array_filled < 301352)
                    {
                        this.savedata_decimal_array[this.savedata_decimal_array_filled] = num1;
                        ++this.savedata_decimal_array_filled;
                    }
                    else
                    {
                        int num2 = (int)MessageBox.Show("Buffer is full, trying to load a save file that is not PSPo2?", "Fatal Error!");
                    }
                }
                catch (Exception ex)
                {
                    int num2 = (int)MessageBox.Show("Failed to read byte, check to see if the end of the file is reached\r\n" + (object)ex, "Fatal Error");
                }
                if (showSaveParseProgress && this.chunkPos >= 1024)
                {
                    this.chunkPos = 0;
                    this.toolStripStatusLabel.Text = "Parsing Save " + (object)this.run.hexAndMathFunction.getPercentage(this.savedata_decimal_array_filled, this.toolStripProgressBar.Maximum) + "%";
                    this.toolStripProgressBar.Value = this.savedata_decimal_array_filled;
                    Application.DoEvents();
                }
            }
            else
            {
                try
                {
                    num1 = this.savedata_decimal_array[this.savedata_decimal_array_read_pos];
                    ++this.savedata_decimal_array_read_pos;
                }
                catch
                {
                    int num2 = (int)MessageBox.Show("trying to read past buffer[" + (object)this.savedata_decimal_array_filled + "] at " + (object)this.savedata_decimal_array_read_pos + " from " + debugHelper);
                }
                if (showSaveParseProgress && this.chunkPos >= 1024)
                {
                    this.chunkPos = 0;
                    this.toolStripStatusLabel.Text = "Parsing Save " + (object)this.run.hexAndMathFunction.getPercentage(this.savedata_decimal_array_read_pos, this.toolStripProgressBar.Maximum) + "%";
                    this.toolStripProgressBar.Value = this.savedata_decimal_array_read_pos;
                    Application.DoEvents();
                }
            }
            return num1;
        }

        public bool overwriteHexInBuffer(string hex, int pos)
        {
            if (hex.Length / 2 + pos > this.savedata_decimal_array_filled)
            {
                int num1 = (int)MessageBox.Show("trying to overwrite hex " + hex + " over the end of the buffer " + (object)this.savedata_decimal_array_filled);
            }
            string[] strArray = this.run.hexAndMathFunction.addCommasToHex(hex).Split(',');
            int index = pos;
            foreach (string s in strArray)
            {
                if (index > pos + hex.Length)
                {
                    int num2 = (int)MessageBox.Show("something went wrong with overwriting hex in the buffer");
                    return false;
                }
                this.savedata_decimal_array[index] = (int)byte.Parse(s, NumberStyles.HexNumber);
                ++index;
            }
            return true;
        }

        public void writeToSaveBuffer(int pos, int[] bytearray, int size, int[] bytestoadd)
        {
            if (pos + size > this.savedata_decimal_array_filled)
            {
                int num = (int)MessageBox.Show("Trying to save bytes beyond the loaded buffer", "Fatal Error!");
            }
            else
            {
                for (int index = 0; index < size; ++index)
                    bytearray[pos] = bytestoadd[index];
            }
        }

        public void brWriteFromBuffer(BinaryWriter writer, int posStart, int len)
        {
            if (len + posStart <= this.savedata_decimal_array_filled)
            {
                for (int index = posStart; index < posStart + len; ++index)
                    writer.Write((byte)this.savedata_decimal_array[index]);
            }
            else
            {
                int num = (int)MessageBox.Show("Tried to write a file [" + (object)len + "] larger than the buffer [" + (object)this.savedata_decimal_array_filled + "]", "Fatal Error!");
            }
        }

        private string fixFileNameNoExt(string fn, string ext_options)
        {
            string str1 = "";
            for (int startIndex = ext_options.Length - 1; startIndex >= 0; --startIndex)
            {
                string str2 = ext_options.Substring(startIndex, 1);
                if (!(str2 == "*"))
                    str1 = str2 + str1;
                else
                    break;
            }
            if (fn.Substring(fn.Length - str1.Length, str1.Length).ToLower() != str1.ToLower())
                fn = fn + "." + str1;
            return fn;
        }

        public string openSaveDialogue(string ext_options, string fileName = "")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "PSPo2 Save Editor: Save File";
            if (fileName != "")
                saveFileDialog.FileName = fileName;
            if (this.legitVersion())
                saveFileDialog.Title = "PSPo2 Save Viewer: Save File";
            saveFileDialog.Filter = ext_options;
            saveFileDialog.RestoreDirectory = true;
            return saveFileDialog.ShowDialog() == DialogResult.OK ? this.fixFileNameNoExt(saveFileDialog.FileName, ext_options) : (string)null;
        }

        private bool saveBufferDataToFile(
          int startpos,
          int size,
          string ext_options,
          int addinteger = 0,
          bool isSaveFile = false,
          string path = null,
          string fileNameDefault = "")
        {
            if (path == null)
                path = this.openSaveDialogue(ext_options, fileNameDefault);
            if (path == null)
                return false;
            string dest = path;
            try
            {
                if (this.mainSettings.saveStructureIndex.encrypted && isSaveFile)
                    path = "data\\temp\\denc.bin";
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter((Stream)fileStream))
                    {
                        if (addinteger != 0)
                            writer.Write((byte)addinteger);
                        this.brWriteFromBuffer(writer, startpos, size);
                        writer.Close();
                    }
                    fileStream.Close();
                }
            }
            catch
            {
                int num = (int)MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return !this.mainSettings.saveStructureIndex.encrypted || !isSaveFile || this.encryptSaveFile(path, dest);
        }

        private bool saveItemDataToFile(
          int startpos,
          int size,
          string ext_options,
          string itemName,
          string fn = "",
          bool delete = false)
        {
            if (fn == "")
                fn = this.openSaveDialogue(ext_options, itemName);
            if (fn != null)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(fn, FileMode.Create))
                    {
                        using (BinaryWriter writer = new BinaryWriter((Stream)fileStream))
                        {
                            for (int index = 0; index < size; ++index)
                            {
                                if (index == 15)
                                {
                                    string str = this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[startpos + index], "hex");
                                    string s = str.Length >= 2 ? "0" + str.Substring(1, 1) : "0" + str;
                                    writer.Write(byte.Parse(s, NumberStyles.HexNumber));
                                }
                                else
                                    this.brWriteFromBuffer(writer, startpos + index, 1);
                                if (delete)
                                    this.savedata_decimal_array[startpos + index] = 0;
                            }
                            writer.Close();
                        }
                        fileStream.Close();
                        return true;
                    }
                }
                catch
                {
                    int num = (int)MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            return false;
        }

        private bool downloadRequiredFile(string fn, string reason, long byteSize)
        {
            bool flag1 = true;
            bool flag2 = false;
            while (flag1)
            {
                if (!System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\" + fn))
                {
                    if (MessageBox.Show(fn + " is a required file which is missing, corrupt or out of date.\n\nDo you want to download it now?\n\n" + reason, "Required File Missing or Corrupt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.disableMainForm();
                        if (this.downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + fn, "data/temp\\", fn))
                        {
                            if (System.IO.File.OpenRead("data/temp\\" + fn).Length != byteSize)
                            {
                                int num1 = (int)MessageBox.Show(fn + " which was downloaded appears to be corrupt, please try again!", "Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            else
                            {
                                System.IO.File.Copy("data/temp\\" + fn, fn);
                                int num2 = (int)MessageBox.Show(fn + " downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                flag1 = false;
                                flag2 = true;
                            }
                        }
                        else
                        {
                            int num3 = (int)MessageBox.Show(fn + " failed to download, please check your internet connection\r\nor the site may be down!", "Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        this.enableMainForm();
                        if (flag1 && MessageBox.Show("Do you want to retry the download now?", "Try Again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            flag1 = false;
                    }
                    else
                        flag1 = false;
                }
                else if (Directory.GetCurrentDirectory() == Directory.GetCurrentDirectory().Replace("PSPo2 Save Editor\\bin\\Debug", ""))
                {
                    FileStream fileStream = System.IO.File.OpenRead(Directory.GetCurrentDirectory() + "\\" + fn);
                    long length = fileStream.Length;
                    fileStream.Close();
                    if (length != byteSize)
                    {
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\" + fn);
                    }
                    else
                    {
                        flag1 = false;
                        flag2 = true;
                    }
                }
                else
                {
                    flag1 = false;
                    flag2 = true;
                }
            }
            return flag2;
        }

        private void checkDatabaseUpdate(bool download)
        {
            this.disableMainForm();
            if (this.downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/databases/version.bin", "data/temp/", "Update Check"))
            {
                if (this.checkVersionTxt(download) && download)
                    this.action_loadDatabases();
            }
            else
            {
                int num = (int)MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.enableMainForm();
        }

        private void checkImagesUpdate(bool download)
        {
            this.disableMainForm();
            string progressTxt = "";
            string str1 = "image_pack_version.bin";
            if (this.downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str1, "data/temp/", "Update Check"))
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader((Stream)this.encryptor.createDecryptionReadStream(this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/temp/" + str1, FileMode.Open, FileAccess.Read))))
                    {
                        string str2;
                        if ((str2 = streamReader.ReadLine()) != null)
                            progressTxt = str2;
                        streamReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show(ex.Message, "checkImagesUpdate failed to parse new info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.toolStripStatusLabel.Text = "Update Failed";
                    this.enableMainForm();
                    return;
                }
                string str3 = "";
                try
                {
                    using (StreamReader streamReader = new StreamReader((Stream)this.encryptor.createDecryptionReadStream(this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/" + str1, FileMode.Open, FileAccess.Read))))
                    {
                        string str2;
                        if ((str2 = streamReader.ReadLine()) != null)
                            str3 = str2;
                        streamReader.Close();
                    }
                }
                catch (Exception ex)
                {
                }
                if (str3 != progressTxt)
                {
                    if (download)
                    {
                        switch (MessageBox.Show("There is a new version of the image pack available.\r\nDo you wish to update now?", "New Image Pack Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            case DialogResult.Cancel:
                                this.enableMainForm();
                                break;
                            case DialogResult.Yes:
                                if (!this.downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + progressTxt, "data/temp/", progressTxt))
                                {
                                    this.toolStripStatusLabel.Text = "Update Failed";
                                    break;
                                }
                                this.toolStripStatusLabel.Text = "Unzipping Images";
                                try
                                {
                                    Directory.Delete("data/weapon_images/", true);
                                }
                                catch
                                {
                                }
                                ZipUtil.UnZipFiles("data/temp/" + progressTxt, "data/", "", true);
                                this.toolStripStatusLabel.Text = "Cleaning Up";
                                System.IO.File.Delete("data/image_pack_version.bin");
                                System.IO.File.Move("data/temp/image_pack_version.bin", "data/image_pack_version.bin");
                                System.IO.File.Delete("data/temp/image_pack_version.bin");
                                this.toolStripStatusLabel.Text = "Completed: Image Pack Update";
                                this.loadImageFloaterImages();
                                this.enableMainForm();
                                int num1 = (int)MessageBox.Show("The image pack was updated successfully", "Image Pack Update Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                break;
                            case DialogResult.No:
                                this.enableMainForm();
                                break;
                            default:
                                int num2 = (int)MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                this.enableMainForm();
                                break;
                        }
                    }
                    else
                    {
                        int num3 = (int)MessageBox.Show("There is a new version of the image pack available.\r\nChoose update from the the images menu to install the latest version", "New Image Pack Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    if (!this.firstboot)
                    {
                        int num4 = (int)MessageBox.Show("The latest version of the image pack is already installed.", "Image pack is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.enableMainForm();
                }
            }
            else
            {
                int num5 = (int)MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Image Pack Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void checkAppUpdate(bool download)
        {
            this.disableMainForm();
            string newVersion = "";
            string str1 = "latest_version.bin";
            if (this.legitVersion())
                str1 = "latest_version_viewer.bin";
            if (this.downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str1, "data/temp/", "Update Check"))
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader((Stream)this.encryptor.createDecryptionReadStream(this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/temp/" + str1, FileMode.Open, FileAccess.Read))))
                    {
                        string str2;
                        if ((str2 = streamReader.ReadLine()) != null)
                            newVersion = str2;
                        streamReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show(ex.Message, "checkAppUpdate failed to parse new info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.toolStripStatusLabel.Text = "Update Failed";
                    this.enableMainForm();
                    return;
                }
                if ("3.0 build 1008" != newVersion)
                {
                    if (download)
                    {
                        this.updateViewer.formSetup(newVersion);
                        switch (this.updateViewer.ShowDialog((IWin32Window)this))
                        {
                            case DialogResult.Cancel:
                                this.enableMainForm();
                                break;
                            case DialogResult.Yes:
                                string str2 = !this.legitVersion() ? "PSPo2 Save Editor" : "PSPo2 Save Viewer";
                                if (!this.downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str2 + " v" + newVersion + ".zip", "data/temp/", str2 + " v" + newVersion + ".zip", str2 + " new.zip"))
                                {
                                    this.toolStripStatusLabel.Text = "Update Failed";
                                    this.enableMainForm();
                                    break;
                                }
                                ZipUtil.UnZipFiles("data/temp/" + str2 + " new.zip", "data/temp/", "", true);
                                System.IO.File.Delete("data/" + str1);
                                System.IO.File.Move("data/temp/" + str1, "data/" + str1);
                                System.IO.File.Delete("data/temp/" + str1);
                                Process.Start("pspo2se_updater.exe");
                                Environment.Exit(0);
                                break;
                            case DialogResult.No:
                                this.enableMainForm();
                                break;
                            default:
                                int num = (int)MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                this.enableMainForm();
                                break;
                        }
                    }
                    else
                    {
                        int num1 = (int)MessageBox.Show("There is a new version of the application available.\r\nChoose update from the the file menu to install v" + newVersion, "New version available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    if (!this.firstboot)
                    {
                        int num2 = (int)MessageBox.Show("The latest version (" + newVersion + ") is already installed.", "Application is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.enableMainForm();
                }
            }
            else
            {
                int num = (int)MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.enableMainForm();
            }
        }

        private bool checkVersionTxt(bool download)
        {
            int index1 = 0;
            int index2 = 0;
            this.toolStripStatusLabel.Text = "Checking Version";
            Application.DoEvents();
            pspo2seForm.updateCSVInfo[] updateCsvInfoArray1 = new pspo2seForm.updateCSVInfo[20];
            try
            {
                string encryptionKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/temp/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string str;
                    while ((str = streamReader.ReadLine()) != null)
                    {
                        string[] strArray = str.Split('|');
                        updateCsvInfoArray1[index1] = new pspo2seForm.updateCSVInfo();
                        updateCsvInfoArray1[index1].fn = strArray[0];
                        updateCsvInfoArray1[index1].ver = strArray[1];
                        ++index1;
                        if (index1 >= 20)
                            break;
                    }
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("checkVersionTxt failed to load new info:\r\n " + ex.Message);
                this.toolStripStatusLabel.Text = "Update Failed";
                return false;
            }
            Application.DoEvents();
            pspo2seForm.updateCSVInfo[] updateCsvInfoArray2 = new pspo2seForm.updateCSVInfo[20];
            try
            {
                string encryptionKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string str;
                    while ((str = streamReader.ReadLine()) != null)
                    {
                        string[] strArray = str.Split('|');
                        updateCsvInfoArray2[index2] = new pspo2seForm.updateCSVInfo();
                        updateCsvInfoArray2[index2].fn = strArray[0];
                        updateCsvInfoArray2[index2].ver = strArray[1];
                        ++index2;
                        if (index2 >= 20)
                            break;
                    }
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Substring(0, 19) != "Could not find file")
                {
                    int num = (int)MessageBox.Show("checkVersionTxt failed to load cur info [" + (object)index2 + "/" + (object)20 + "]:\r\n " + ex.Message);
                    this.toolStripStatusLabel.Text = "Update Failed";
                    return false;
                }
                for (int index3 = 0; index3 < 20; ++index3)
                {
                    updateCsvInfoArray2[index3] = new pspo2seForm.updateCSVInfo();
                    updateCsvInfoArray2[index3].ver = "0";
                }
                index2 = index1;
            }
            Application.DoEvents();
            if (index1 > index2)
            {
                int num = (int)MessageBox.Show("The application seems to be out of date.\r\nThe latest database files are incompatible with this version\r\n\r\nPlease update the application first");
                this.toolStripStatusLabel.Text = "Update Failed";
                return false;
            }
            string text = "";
            bool flag1 = false;
            bool flag2 = false;
            for (int index3 = 0; index3 < 20 && index3 < index1; ++index3)
            {
                if (updateCsvInfoArray2[index3].ver != updateCsvInfoArray1[index3].ver)
                {
                    if (!flag2)
                    {
                        if (download)
                        {
                            switch (MessageBox.Show("There are new database updates available.\r\nDo you wish to download them now?", "Updates Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                case DialogResult.Cancel:
                                    return false;
                                case DialogResult.Yes:
                                    flag2 = true;
                                    break;
                                case DialogResult.No:
                                    return false;
                                default:
                                    int num1 = (int)MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                    return false;
                            }
                        }
                        else
                        {
                            int num2 = (int)MessageBox.Show("There are new database updates available.\r\nChoose update from the database menu to install them", "Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                    }
                    if (this.downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/databases/" + updateCsvInfoArray1[index3].fn, "data/databases/", updateCsvInfoArray1[index3].fn))
                    {
                        text = text + updateCsvInfoArray1[index3].fn + " [Updated to " + updateCsvInfoArray1[index3].ver + "]\r\n";
                        flag1 = true;
                    }
                    else
                    {
                        this.toolStripStatusLabel.Text = "Update Failed";
                        return false;
                    }
                }
                else
                    text = text + updateCsvInfoArray1[index3].fn + " [" + updateCsvInfoArray1[index3].ver + " Already Installed]\r\n";
            }
            if (flag1)
            {
                System.IO.File.Delete("data/databases/version.bin");
                System.IO.File.Move("data/temp/version.bin", "data/databases/version.bin");
            }
            if (!download)
                return true;
            this.toolStripStatusLabel.Text = "Update Complete";
            int num3 = (int)MessageBox.Show(text, "Database Update Results", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return true;
        }

        public bool downloadFile(string url, string dirdest, string progressTxt, string saveas = "")
        {
            if (!this.allowDownload)
            {
                int num = (int)MessageBox.Show("Please wait for the current download to finish", "Download already in progress", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.allowDownload = false;
            this.downloadedData = new byte[512000];
            this.downloadedDataName = "";
            try
            {
                WebResponse response = WebRequest.Create(url).GetResponse();
                Stream responseStream = response.GetResponseStream();
                int contentLength = (int)response.ContentLength;
                this.toolStripProgressBar.Maximum = contentLength;
                this.toolStripProgressBar.Value = 0;
                for (int index = 3; index < url.Length; ++index)
                {
                    if (url.Substring(url.Length - index, 1) == "/")
                    {
                        this.downloadedDataName = url.Substring(url.Length - index + 1, url.Length - (url.Length - index) - 1);
                        break;
                    }
                }
                MemoryStream memoryStream = new MemoryStream();
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int count;
                    do
                    {
                        count = responseStream.Read(buffer, 0, buffer.Length);
                        if (count == 0)
                        {
                            this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum;
                            this.toolStripStatusLabel.Text = "Completed: " + progressTxt + " " + (object)this.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, contentLength) + "%";
                            Application.DoEvents();
                            this.downloadedData = memoryStream.ToArray();
                            responseStream.Close();
                            memoryStream.Close();
                            goto label_14;
                        }
                        else
                            memoryStream.Write(buffer, 0, count);
                    }
                    while (this.toolStripProgressBar.Value + count > this.toolStripProgressBar.Maximum);
                    this.toolStripProgressBar.Value += count;
                    this.toolStripStatusLabel.Text = "Downloading: " + progressTxt + " " + (object)this.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, contentLength) + "%";
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                this.allowDownload = true;
                return false;
            }
        label_14:
            if (saveas != "")
                this.downloadedDataName = saveas;
            FileStream fileStream = new FileStream(dirdest + this.downloadedDataName, FileMode.Create);
            fileStream.Write(this.downloadedData, 0, this.downloadedData.Length);
            fileStream.Close();
            this.allowDownload = true;
            return true;
        }

        public pspo2seForm.greenItemType getGreenItemTypeFromHex(string hex_reversed)
        {
            switch (hex_reversed.Substring(5, 1))
            {
                case "1":
                    switch (hex_reversed.Substring(3, 1))
                    {
                        case "0":
                            return pspo2seForm.greenItemType.monomate;
                        case "1":
                            return pspo2seForm.greenItemType.dimate;
                        case "2":
                            return pspo2seForm.greenItemType.trimate;
                        case "3":
                            return pspo2seForm.greenItemType.star_atom;
                        case "6":
                            return pspo2seForm.greenItemType.sol_atom;
                        case "7":
                            return pspo2seForm.greenItemType.moon_atom;
                        case "9":
                            return pspo2seForm.greenItemType.doll;
                        case "A":
                            return pspo2seForm.greenItemType.shiftaride;
                        case "B":
                            return pspo2seForm.greenItemType.debanride;
                        default:
                            int num1 = (int)MessageBox.Show("Heal type item type not recognised for image: " + hex_reversed.Substring(3, 1));
                            return pspo2seForm.greenItemType.none;
                    }
                case "3":
                    return pspo2seForm.greenItemType.calorie;
                case "4":
                    return pspo2seForm.greenItemType.item;
                default:
                    int num2 = (int)MessageBox.Show("Green item type not recognised for image: " + hex_reversed.Substring(5, 1));
                    return pspo2seForm.greenItemType.none;
            }
        }

        public pspo2seForm.itemDb_ItemClass findItemInDb(string hex)
        {
            pspo2seForm.itemDb_ItemClass itemDbItemClass = new pspo2seForm.itemDb_ItemClass();
            for (int index = 0; index < this.item_db_filled; ++index)
            {
                if (hex == this.item_db.item[index].hex)
                    return this.item_db.item[index];
            }
            return itemDbItemClass;
        }

        public string weaponEnumToName(pspo2seForm.weaponType type)
        {
            string name = this.enumToName(string.Concat((object)type));
            return !(name.Substring(name.Length - 1, 1) == "s") ? name + "s" : "Twin " + name;
        }

        public string enumToName(string type) => this.run.hexAndMathFunction.stringToProper(type.Replace("_", " "));

        public void addItemToDb(string csvLine)
        {
            string[] strArray = csvLine.Split('|');
            this.item_db.item[this.item_db_filled] = new pspo2seForm.itemDb_ItemClass();
            this.item_db.item[this.item_db_filled].id = strArray[0];
            this.item_db.item[this.item_db_filled].hex = strArray[1];
            this.item_db.item[this.item_db_filled].name = strArray[2];
            this.item_db.item[this.item_db_filled].name_jp = strArray[3];
            this.item_db.item[this.item_db_filled].desc = strArray[4];
            this.item_db.item[this.item_db_filled].desc_jp = strArray[5];
            this.item_db.item[this.item_db_filled].infinity_item = strArray[6];
            try
            {
                this.item_db.item[this.item_db_filled].power = int.Parse(strArray[7]);
            }
            catch
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show("row 7 [" + (object)this.item_db_filled + "] incorrect format " + strArray[7]);
            }
            try
            {
                this.item_db.item[this.item_db_filled].acc = int.Parse(strArray[8]);
            }
            catch
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show("row 8 [" + (object)this.item_db_filled + "] incorrect format " + strArray[8]);
            }
            this.item_db.item[this.item_db_filled].level = strArray[9];
            try
            {
                this.item_db.item[this.item_db_filled].ext_power = int.Parse(strArray[10]);
            }
            catch
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show("row 10 [" + (object)this.item_db_filled + "] incorrect format " + strArray[10]);
            }
            try
            {
                this.item_db.item[this.item_db_filled].ext_acc = int.Parse(strArray[11]);
            }
            catch
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show("row 11 [" + (object)this.item_db_filled + "] incorrect format " + strArray[11]);
            }
            this.item_db.item[this.item_db_filled].ext_level = strArray[12];
            try
            {
                this.item_db.item[this.item_db_filled].inf_ext_power = int.Parse(strArray[13]);
            }
            catch
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show("row 13 [" + (object)this.item_db_filled + "] incorrect format " + strArray[13]);
            }
            try
            {
                this.item_db.item[this.item_db_filled].inf_ext_acc = int.Parse(strArray[14]);
            }
            catch
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show("row 14 [" + (object)this.item_db_filled + "] incorrect format " + strArray[14]);
            }
            this.item_db.item[this.item_db_filled].inf_ext_level = strArray[15];
            this.item_db.item[this.item_db_filled].special = strArray[16];
            this.item_db.item[this.item_db_filled].special_level = strArray[17];
            this.item_db.item[this.item_db_filled].ext_special_level = strArray[18];
            if (this.item_db.item[this.item_db_filled].ext_special_level == "")
                this.item_db.item[this.item_db_filled].ext_special_level = this.item_db.item[this.item_db_filled].special_level;
            if (this.item_db.item[this.item_db_filled].ext_special_level == "0")
                this.item_db.item[this.item_db_filled].ext_special_level = "";
            if (this.item_db.item[this.item_db_filled].special_level == "0")
                this.item_db.item[this.item_db_filled].special_level = "";
            try
            {
                this.item_db.item[this.item_db_filled].rarity = int.Parse(strArray[19]);
            }
            catch
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show("row 19 [" + (object)this.item_db_filled + "] incorrect format " + strArray[19]);
            }
            ++this.item_db_filled;
        }

        public void loadItemDatabase()
        {
            this.item_db_filled = 0;
            try
            {
                string encryptionKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/items.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string csvLine;
                    while ((csvLine = streamReader.ReadLine()) != null)
                        this.addItemToDb(csvLine);
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                this.databasesOk = false;
                int num = (int)MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Item Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public pspo2seForm.itemType getItemTypeFromHex(string hex)
        {
            hex = hex.Substring(0, 2);
            return (pspo2seForm.itemType)int.Parse(hex, NumberStyles.HexNumber);
        }

        public pspo2seForm.weaponType getWeaponTypeFromHex(string hex)
        {
            hex = hex.Substring(4, 2);
            return (pspo2seForm.weaponType)int.Parse(hex, NumberStyles.HexNumber);
        }

        private pspo2seForm.slotType getSlotTypeFromHex(string hex)
        {
            hex = hex.Substring(2, 4);
            hex = this.run.hexAndMathFunction.reversehex(hex, 4);
            int num1 = int.Parse(hex, NumberStyles.HexNumber);
            if (num1 < 256 || num1 > 1138)
            {
                int num2 = (int)MessageBox.Show("Error, slot type integer not supported [" + hex + ":" + (object)num1 + "]");
            }
            else
            {
                if (num1 < 1029)
                    return pspo2seForm.slotType.unit;
                if (num1 < 1061)
                    return pspo2seForm.slotType.visual;
                if (num1 < 1108)
                    return pspo2seForm.slotType.suv;
                if (num1 < 1126)
                    return pspo2seForm.slotType.mirage;
                if (num1 <= 1138)
                    return pspo2seForm.slotType.visual;
            }
            return pspo2seForm.slotType.unit;
        }

        public pspo2seForm.weaponManufacturerType getWeaponManufacturerFromHex(string hex)
        {
            hex = hex.Substring(0, 2);
            return (pspo2seForm.weaponManufacturerType)int.Parse(hex, NumberStyles.HexNumber);
        }

        private int getClothesTypeFromHex(string hex)
        {
            hex = hex.Substring(4, 2);
            return int.Parse(hex, NumberStyles.HexNumber);
        }

        public Image getWeaponManufacturerImage(pspo2seForm.weaponManufacturerType manufacturer)
        {
            switch (manufacturer)
            {
                case pspo2seForm.weaponManufacturerType.GRM:
                    return (Image)Resources.manlogo_GRM;
                case pspo2seForm.weaponManufacturerType.Yohmei:
                    return (Image)Resources.manlogo_Yohmei;
                case pspo2seForm.weaponManufacturerType.Tenora_Works:
                    return (Image)Resources.manlogo_Tenora;
                case pspo2seForm.weaponManufacturerType.Kubara:
                    return (Image)Resources.manlogo_Kubara;
                default:
                    int num = (int)MessageBox.Show("weapon manufacturer not supported: " + (object)manufacturer);
                    return (Image)null;
            }
        }

        private void displayWeaponManufacturerImage(
          pspo2seForm.pageFields fields,
          pspo2seForm.weaponManufacturerType manufacturer)
        {
            fields.img_manufaturer.Visible = true;
            Image manufacturerImage = this.getWeaponManufacturerImage(manufacturer);
            if (manufacturerImage == null)
                fields.img_manufaturer.Visible = false;
            else
                fields.img_manufaturer.Image = manufacturerImage;
        }

        private void displayClothesManufacturerImage(
          pspo2seForm.pageFields fields,
          pspo2seForm.clothesManufacturerType manufacturer)
        {
            fields.img_manufaturer.Visible = true;
            switch (manufacturer)
            {
                case pspo2seForm.clothesManufacturerType.Kubara:
                    fields.img_manufaturer.Image = (Image)Resources.manlogo_Kubara;
                    break;
                case pspo2seForm.clothesManufacturerType.Roar:
                    fields.img_manufaturer.Image = (Image)Resources.manlogo_Roar;
                    break;
                case pspo2seForm.clothesManufacturerType.Cubic:
                    fields.img_manufaturer.Image = (Image)Resources.manlogo_Cubic;
                    break;
                case pspo2seForm.clothesManufacturerType.Miyab:
                    fields.img_manufaturer.Image = (Image)Resources.manlogo_Miyab;
                    break;
                default:
                    int num = (int)MessageBox.Show("clothes manufacturer not supported: " + (object)manufacturer);
                    fields.img_manufaturer.Visible = false;
                    break;
            }
        }

        public Image getWeaponImageFromType(pspo2seForm.weaponType weapon)
        {
            switch (weapon)
            {
                case pspo2seForm.weaponType.nothing:
                    return (Image)null;
                case pspo2seForm.weaponType.sword:
                    return (Image)Resources.weapon_sword;
                case pspo2seForm.weaponType.knuckle:
                    return (Image)Resources.weapon_knuckles;
                case pspo2seForm.weaponType.spear:
                    return (Image)Resources.weapon_spear;
                case pspo2seForm.weaponType.double_saber:
                    return (Image)Resources.weapon_double_saber;
                case pspo2seForm.weaponType.axe:
                    return (Image)Resources.weapon_axe;
                case pspo2seForm.weaponType.sabers:
                    return (Image)Resources.weapon_sabers;
                case pspo2seForm.weaponType.daggers:
                    return (Image)Resources.weapon_daggers;
                case pspo2seForm.weaponType.claws:
                    return (Image)Resources.weapon_claws;
                case pspo2seForm.weaponType.saber:
                    return (Image)Resources.weapon_saber;
                case pspo2seForm.weaponType.dagger:
                    return (Image)Resources.weapon_dagger;
                case pspo2seForm.weaponType.claw:
                    return (Image)Resources.weapon_claw;
                case pspo2seForm.weaponType.whip:
                    return (Image)Resources.weapon_whip;
                case pspo2seForm.weaponType.slicer:
                    return (Image)Resources.weapon_slicer;
                case pspo2seForm.weaponType.rifle:
                    return (Image)Resources.weapon_rifle;
                case pspo2seForm.weaponType.shotgun:
                    return (Image)Resources.weapon_shotgun;
                case pspo2seForm.weaponType.longbow:
                    return (Image)Resources.weapon_longbow;
                case pspo2seForm.weaponType.grenade:
                    return (Image)Resources.weapon_grenade;
                case pspo2seForm.weaponType.laser:
                    return (Image)Resources.weapon_laser;
                case pspo2seForm.weaponType.handguns:
                    return (Image)Resources.weapon_handguns;
                case pspo2seForm.weaponType.handgun:
                    return (Image)Resources.weapon_handgun;
                case pspo2seForm.weaponType.crossbow:
                    return (Image)Resources.weapon_crossbow;
                case pspo2seForm.weaponType.card:
                    return (Image)Resources.weapon_card;
                case pspo2seForm.weaponType.machinegun:
                    return (Image)Resources.weapon_machinegun;
                case pspo2seForm.weaponType.rod:
                    return (Image)Resources.weapon_rod;
                case pspo2seForm.weaponType.wand:
                    return (Image)Resources.weapon_wand;
                case pspo2seForm.weaponType.tmag:
                    return (Image)Resources.weapon_tmag;
                case pspo2seForm.weaponType.rmag:
                    return (Image)Resources.weapon_rmag;
                case pspo2seForm.weaponType.shield:
                    return (Image)Resources.weapon_shield;
                case pspo2seForm.weaponType.armor:
                    return (Image)Resources.armor_icon;
                default:
                    return (Image)null;
            }
        }

        private void displayWeaponImage(pspo2seForm.pageFields fields, pspo2seForm.weaponType weapon)
        {
            Image weaponImageFromType = this.getWeaponImageFromType(weapon);
            if (weaponImageFromType == null)
            {
                fields.img_item.Visible = false;
            }
            else
            {
                fields.img_item.Image = weaponImageFromType;
                fields.img_item.Visible = true;
            }
        }

        private void displayClothesImage(
          pspo2seForm.pageFields fields,
          pspo2seForm.itemType item_type,
          int clothes_type)
        {
            fields.img_item.Visible = true;
            switch (item_type)
            {
                case pspo2seForm.itemType.Clothes_human:
                    pspo2seForm.clothesTypes clothesTypes = (pspo2seForm.clothesTypes)clothes_type;
                    switch (clothesTypes)
                    {
                        case pspo2seForm.clothesTypes.top:
                            fields.img_item.Image = (Image)Resources.clothes_top;
                            return;
                        case pspo2seForm.clothesTypes.bottom:
                            fields.img_item.Image = (Image)Resources.clothes_bottom;
                            return;
                        case pspo2seForm.clothesTypes.shoes:
                            fields.img_item.Image = (Image)Resources.clothes_shoes;
                            return;
                        case pspo2seForm.clothesTypes.top_set:
                            fields.img_item.Image = (Image)Resources.clothes_bottom_set;
                            return;
                        case pspo2seForm.clothesTypes.bottom_set:
                            fields.img_item.Image = (Image)Resources.clothes_top_set;
                            return;
                        case pspo2seForm.clothesTypes.set:
                            fields.img_item.Image = (Image)Resources.clothes_set;
                            return;
                        default:
                            int num1 = (int)MessageBox.Show("Unsupported " + (object)item_type + " type: " + (object)clothesTypes);
                            fields.img_item.Visible = false;
                            return;
                    }
                case pspo2seForm.itemType.Clothes_android:
                    pspo2seForm.partsTypes partsTypes = (pspo2seForm.partsTypes)clothes_type;
                    switch (partsTypes)
                    {
                        case pspo2seForm.partsTypes.torso:
                            fields.img_item.Image = (Image)Resources.parts_torso;
                            return;
                        case pspo2seForm.partsTypes.legs:
                            fields.img_item.Image = (Image)Resources.parts_legs;
                            return;
                        case pspo2seForm.partsTypes.arms:
                            fields.img_item.Image = (Image)Resources.parts_arms;
                            return;
                        case pspo2seForm.partsTypes.set:
                            fields.img_item.Image = (Image)Resources.parts_set;
                            return;
                        default:
                            int num2 = (int)MessageBox.Show("Unsupported " + (object)item_type + " type: " + (object)partsTypes);
                            fields.img_item.Visible = false;
                            return;
                    }
                default:
                    int num3 = (int)MessageBox.Show("Tried to get clothes type from a non-clothing item: " + (object)clothes_type);
                    break;
            }
        }

        private void displaySlotUnitImage(pspo2seForm.pageFields fields, pspo2seForm.slotType slot)
        {
            fields.img_item.Visible = true;
            switch (slot)
            {
                case pspo2seForm.slotType.unit:
                    fields.img_item.Image = (Image)Resources.slot_unit;
                    break;
                case pspo2seForm.slotType.mirage:
                    fields.img_item.Image = (Image)Resources.slot_mirage;
                    break;
                case pspo2seForm.slotType.suv:
                    fields.img_item.Image = (Image)Resources.slot_suv;
                    break;
                case pspo2seForm.slotType.visual:
                    fields.img_item.Image = (Image)Resources.slot_visual;
                    break;
            }
        }

        public void displayItemImage(pspo2seForm.pageFields fields, pspo2seForm.inventoryItemClass item)
        {
            fields.img_item.Visible = true;
            fields.img_manufaturer.Visible = false;
            fields.img_item.Padding = new Padding(0, 0, 0, 0);
            fields.txt_name.Padding = new Padding(0, 0, 0, 0);
            switch (item.type)
            {
                case pspo2seForm.itemType.Weapon:
                    this.displayWeaponImage(fields, this.getWeaponTypeFromHex(item.hex_reversed));
                    this.displayWeaponManufacturerImage(fields, this.getWeaponManufacturerFromHex(item.hex_reversed));
                    break;
                case pspo2seForm.itemType.Armor:
                    this.displayWeaponImage(fields, pspo2seForm.weaponType.armor);
                    this.displayWeaponManufacturerImage(fields, this.getWeaponManufacturerFromHex(item.hex_reversed));
                    break;
                case pspo2seForm.itemType.Green_Item:
                    switch (this.getGreenItemTypeFromHex(item.hex_reversed))
                    {
                        case pspo2seForm.greenItemType.monomate:
                            fields.img_item.Image = (Image)Resources.item_mate;
                            return;
                        case pspo2seForm.greenItemType.dimate:
                            fields.img_item.Image = (Image)Resources.item_mate;
                            return;
                        case pspo2seForm.greenItemType.trimate:
                            fields.img_item.Image = (Image)Resources.item_mate;
                            return;
                        case pspo2seForm.greenItemType.star_atom:
                            fields.img_item.Image = (Image)Resources.item_mate;
                            return;
                        case pspo2seForm.greenItemType.sol_atom:
                            fields.img_item.Image = (Image)Resources.item_sol;
                            return;
                        case pspo2seForm.greenItemType.moon_atom:
                            fields.img_item.Image = (Image)Resources.item_doll;
                            return;
                        case pspo2seForm.greenItemType.doll:
                            fields.img_item.Image = (Image)Resources.item_doll;
                            return;
                        case pspo2seForm.greenItemType.shiftaride:
                            fields.img_item.Image = (Image)Resources.item_buff;
                            return;
                        case pspo2seForm.greenItemType.debanride:
                            fields.img_item.Image = (Image)Resources.item_buff;
                            return;
                        case pspo2seForm.greenItemType.calorie:
                            fields.img_item.Image = (Image)Resources.item_calorie;
                            return;
                        case pspo2seForm.greenItemType.item:
                            fields.img_item.Image = (Image)Resources.item;
                            return;
                        default:
                            int num1 = (int)MessageBox.Show("Green item type not recognised for image: " + (object)this.getGreenItemTypeFromHex(item.hex_reversed));
                            return;
                    }
                case pspo2seForm.itemType.PA_Disk_Melee:
                    fields.img_item.Image = (Image)Resources.item_pa_disk;
                    break;
                case pspo2seForm.itemType.PA_Disk_Ranged:
                    fields.img_item.Image = (Image)Resources.item_pa_disk;
                    break;
                case pspo2seForm.itemType.PA_Disk_Technique:
                    fields.img_item.Image = (Image)Resources.item_pa_disk;
                    break;
                case pspo2seForm.itemType.Infinity_Code:
                    fields.img_item.Image = (Image)Resources.item;
                    break;
                case pspo2seForm.itemType.Slot_Unit:
                    this.displaySlotUnitImage(fields, this.getSlotTypeFromHex(item.hex_reversed));
                    this.displayWeaponManufacturerImage(fields, this.getWeaponManufacturerFromHex(item.hex_reversed));
                    break;
                case pspo2seForm.itemType.Clothes_human:
                    this.displayClothesImage(fields, pspo2seForm.itemType.Clothes_human, this.getClothesTypeFromHex(item.hex_reversed));
                    this.displayClothesManufacturerImage(fields, item.clothes_man);
                    break;
                case pspo2seForm.itemType.Clothes_android:
                    this.displayClothesImage(fields, pspo2seForm.itemType.Clothes_android, this.getClothesTypeFromHex(item.hex_reversed));
                    this.displayClothesManufacturerImage(fields, item.clothes_man);
                    break;
                case pspo2seForm.itemType.Room_Decoration:
                    fields.img_item.Image = (Image)Resources.item_decoration;
                    break;
                case pspo2seForm.itemType.Trap:
                    switch (item.hex_reversed.Substring(5, 1))
                    {
                        case "1":
                            fields.img_item.Image = (Image)Resources.trap;
                            return;
                        case "2":
                            fields.img_item.Image = (Image)Resources.trap_ex;
                            return;
                        default:
                            int num2 = (int)MessageBox.Show("Trap type is wrong for image, is this even a trap?");
                            return;
                    }
                case pspo2seForm.itemType.My_Synth_Device:
                    fields.img_item.Image = (Image)Resources.item_pm;
                    break;
                case pspo2seForm.itemType.Extend_Code:
                    fields.img_item.Image = (Image)Resources.item_extend;
                    break;
                case pspo2seForm.itemType.free_slot:
                    break;
                default:
                    int num3 = (int)MessageBox.Show("item type not recognised for image: " + (object)item.type);
                    fields.img_item.Visible = false;
                    break;
            }
        }

        private void showButtons(pspo2seForm.pageFields fields, pspo2seForm.itemType type)
        {
            if (type == pspo2seForm.itemType.free_slot)
            {
                fields.btn_delete.Enabled = false;
                fields.btn_export_selected.Enabled = false;
                fields.chk_delete_export.Enabled = false;
                fields.btn_withdraw.Enabled = false;
                fields.btn_import_selected.Enabled = true;
                fields.txt_hex.Text = "0xFFFFFFFF";
            }
            else if (type == pspo2seForm.itemType.nothing)
            {
                fields.btn_delete.Enabled = false;
                fields.btn_export_selected.Enabled = false;
                fields.chk_delete_export.Enabled = false;
                fields.btn_withdraw.Enabled = false;
                fields.btn_import_selected.Enabled = false;
            }
            else
            {
                fields.btn_delete.Enabled = true;
                fields.btn_export_selected.Enabled = true;
                fields.chk_delete_export.Enabled = true;
                fields.btn_withdraw.Enabled = true;
                fields.btn_import_selected.Enabled = false;
            }
        }

        public void displayItemStars(pspo2seForm.pageFields fields, int rarity)
        {
            fields.img_star_0.Visible = false;
            fields.img_star_1.Visible = false;
            fields.img_star_2.Visible = false;
            fields.img_star_3.Visible = false;
            fields.img_star_4.Visible = false;
            fields.img_star_5.Visible = false;
            fields.img_star_6.Visible = false;
            fields.img_star_7.Visible = false;
            fields.img_star_8.Visible = false;
            fields.img_star_9.Visible = false;
            fields.img_star_10.Visible = false;
            fields.img_star_11.Visible = false;
            fields.img_star_12.Visible = false;
            fields.img_star_13.Visible = false;
            fields.img_star_14.Visible = false;
            fields.img_star_15.Visible = false;
            fields.img_rank.Image = (Image)Resources.rank_Unknown;
            if (rarity >= 0)
            {
                fields.img_star_0.Visible = true;
                fields.img_rank.Image = (Image)Resources.rank_C;
            }
            if (rarity > 0)
                fields.img_star_1.Visible = true;
            if (rarity >= 2)
                fields.img_star_2.Visible = true;
            if (rarity >= 3)
            {
                fields.img_star_3.Visible = true;
                fields.img_rank.Image = (Image)Resources.rank_B;
            }
            if (rarity >= 4)
                fields.img_star_4.Visible = true;
            if (rarity >= 5)
                fields.img_star_5.Visible = true;
            if (rarity >= 6)
            {
                fields.img_star_6.Visible = true;
                fields.img_rank.Image = (Image)Resources.rank_A;
            }
            if (rarity >= 7)
                fields.img_star_7.Visible = true;
            if (rarity >= 8)
                fields.img_star_8.Visible = true;
            if (rarity >= 9)
            {
                fields.img_star_9.Visible = true;
                fields.img_rank.Image = (Image)Resources.rank_S;
            }
            if (rarity >= 10)
                fields.img_star_10.Visible = true;
            if (rarity >= 11)
                fields.img_star_11.Visible = true;
            if (rarity >= 12)
                fields.img_star_12.Visible = true;
            if (rarity >= 13)
                fields.img_star_13.Visible = true;
            if (rarity >= 14)
                fields.img_star_14.Visible = true;
            if (rarity < 15)
                return;
            fields.img_star_15.Visible = true;
        }

        public pspo2seForm.itemRankType getItemRankFromRarity(int rarity)
        {
            pspo2seForm.itemRankType itemRankType = pspo2seForm.itemRankType.c;
            if (rarity < 0)
                itemRankType = pspo2seForm.itemRankType.unknown;
            if (rarity >= 3)
                itemRankType = pspo2seForm.itemRankType.b;
            if (rarity >= 6)
                itemRankType = pspo2seForm.itemRankType.a;
            if (rarity >= 9)
                itemRankType = pspo2seForm.itemRankType.s;
            return itemRankType;
        }

        private pspo2seForm.itemExtendType getWeaponExtendType(
          int extend_integer,
          pspo2seForm.weaponStyleType style,
          pspo2seForm.weaponType weapon)
        {
            pspo2seForm.itemExtendType itemExtendType = pspo2seForm.itemExtendType.not_extended;
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                switch (extend_integer)
                {
                    case 0:
                        itemExtendType = pspo2seForm.itemExtendType.not_extended;
                        if (weapon != pspo2seForm.weaponType.rmag && (style == pspo2seForm.weaponStyleType.Ranged_long || style == pspo2seForm.weaponStyleType.Ranged_short))
                        {
                            itemExtendType = pspo2seForm.itemExtendType.not_extended_cs1;
                            break;
                        }
                        break;
                    case 1:
                        itemExtendType = pspo2seForm.itemExtendType.extended;
                        if (weapon != pspo2seForm.weaponType.rmag && (style == pspo2seForm.weaponStyleType.Ranged_long || style == pspo2seForm.weaponStyleType.Ranged_short))
                        {
                            itemExtendType = pspo2seForm.itemExtendType.extended_cs1;
                            break;
                        }
                        break;
                    case 2:
                        itemExtendType = pspo2seForm.itemExtendType.dlc_not_extended;
                        if (weapon != pspo2seForm.weaponType.rmag && (style == pspo2seForm.weaponStyleType.Ranged_long || style == pspo2seForm.weaponStyleType.Ranged_short))
                        {
                            itemExtendType = pspo2seForm.itemExtendType.not_extended_cs1;
                            break;
                        }
                        break;
                    case 3:
                        itemExtendType = pspo2seForm.itemExtendType.dlc_extended;
                        if (weapon != pspo2seForm.weaponType.rmag && (style == pspo2seForm.weaponStyleType.Ranged_long || style == pspo2seForm.weaponStyleType.Ranged_short))
                        {
                            itemExtendType = pspo2seForm.itemExtendType.extended_cs1;
                            break;
                        }
                        break;
                    case 4:
                        itemExtendType = pspo2seForm.itemExtendType.not_extended;
                        if (weapon != pspo2seForm.weaponType.rmag && (style == pspo2seForm.weaponStyleType.Ranged_long || style == pspo2seForm.weaponStyleType.Ranged_short))
                        {
                            itemExtendType = pspo2seForm.itemExtendType.not_extended_cs1;
                            break;
                        }
                        break;
                    case 5:
                        itemExtendType = pspo2seForm.itemExtendType.extended;
                        if (weapon != pspo2seForm.weaponType.rmag && (style == pspo2seForm.weaponStyleType.Ranged_long || style == pspo2seForm.weaponStyleType.Ranged_short))
                        {
                            itemExtendType = pspo2seForm.itemExtendType.extended_cs1;
                            break;
                        }
                        break;
                    case 6:
                        itemExtendType = pspo2seForm.itemExtendType.dlc_not_extended;
                        if (style == pspo2seForm.weaponStyleType.Ranged_short || style == pspo2seForm.weaponStyleType.Ranged_long)
                        {
                            itemExtendType = pspo2seForm.itemExtendType.extended_cs2;
                            break;
                        }
                        break;
                    case 8:
                        itemExtendType = pspo2seForm.itemExtendType.unknown;
                        if (style == pspo2seForm.weaponStyleType.Ranged_short || style == pspo2seForm.weaponStyleType.Ranged_long)
                        {
                            itemExtendType = pspo2seForm.itemExtendType.not_extended_cs2;
                            break;
                        }
                        break;
                    case 9:
                        if (style == pspo2seForm.weaponStyleType.Ranged_short || style == pspo2seForm.weaponStyleType.Ranged_long)
                        {
                            itemExtendType = pspo2seForm.itemExtendType.extended_cs2;
                            break;
                        }
                        break;
                    case 12:
                        itemExtendType = pspo2seForm.itemExtendType.unknown;
                        if (style == pspo2seForm.weaponStyleType.Ranged_short || style == pspo2seForm.weaponStyleType.Ranged_long)
                        {
                            itemExtendType = pspo2seForm.itemExtendType.not_extended_cs2;
                            break;
                        }
                        break;
                    case 13:
                        itemExtendType = pspo2seForm.itemExtendType.unknown;
                        if (style == pspo2seForm.weaponStyleType.Ranged_short || style == pspo2seForm.weaponStyleType.Ranged_long)
                        {
                            itemExtendType = pspo2seForm.itemExtendType.extended_cs2;
                            break;
                        }
                        break;
                    default:
                        int num1 = (int)MessageBox.Show("Extend integer " + (object)extend_integer + " is not recognised for psp2i extend type");
                        break;
                }
            }
            else
            {
                switch (extend_integer)
                {
                    case 0:
                        itemExtendType = pspo2seForm.itemExtendType.not_extended;
                        break;
                    case 1:
                        itemExtendType = pspo2seForm.itemExtendType.extended;
                        break;
                    case 2:
                        itemExtendType = pspo2seForm.itemExtendType.dlc_not_extended;
                        break;
                    case 3:
                        itemExtendType = pspo2seForm.itemExtendType.dlc_extended;
                        break;
                    default:
                        int num2 = (int)MessageBox.Show("Extend integer " + (object)extend_integer + " is not recognised for psp2 extend type");
                        break;
                }
            }
            return itemExtendType;
        }

        private string getElementSpecialAsString(pspo2seForm.elementType element)
        {
            switch (element)
            {
                case pspo2seForm.elementType.Neutral:
                    return "None";
                case pspo2seForm.elementType.Fire:
                    return "Burn";
                case pspo2seForm.elementType.Ice:
                    return "Freeze";
                case pspo2seForm.elementType.Thunder:
                    return "Shock";
                case pspo2seForm.elementType.Earth:
                    return "Confusion";
                case pspo2seForm.elementType.Light:
                    return "Sleep";
                case pspo2seForm.elementType.Dark:
                    return "Poison";
                default:
                    return "unknown";
            }
        }

        public pspo2seForm.abilityType stringToAbilityEnum(string str)
        {
            if (!(str != "") || str == null)
                return pspo2seForm.abilityType.None;
            str = str.Replace(" ", "_");
            str = str.Replace("Empow.", "Empow");
            if (str == "HP_affects_pwr.")
                str = "HP_affects_pwr";
            try
            {
                return (pspo2seForm.abilityType)System.Enum.Parse(typeof(pspo2seForm.abilityType), str, true);
            }
            catch
            {
                return pspo2seForm.abilityType.None;
            }
        }

        public string abilityToJp(pspo2seForm.abilityType ability)
        {
            switch (ability)
            {
                case pspo2seForm.abilityType.None:
                    return "";
                case pspo2seForm.abilityType.Burn:
                    return "(燃焼)";
                case pspo2seForm.abilityType.Poison:
                    return "(毒)";
                case pspo2seForm.abilityType.Infection:
                    return "(感染)";
                case pspo2seForm.abilityType.Silence:
                    return "(沈黙)";
                case pspo2seForm.abilityType.Shock:
                    return "(感電)";
                case pspo2seForm.abilityType.Freeze:
                    return "(凍結)";
                case pspo2seForm.abilityType.Sleep:
                    return "(睡眠)";
                case pspo2seForm.abilityType.Stun:
                    return "(麻痺)";
                case pspo2seForm.abilityType.Confusion:
                    return "(混乱)";
                case pspo2seForm.abilityType.Taunt:
                    return "(魅了)";
                case pspo2seForm.abilityType.Incapacitate:
                    return "(戦闘不能)";
                case pspo2seForm.abilityType.Drain:
                    return "(HP吸収)";
                case pspo2seForm.abilityType.Damage_reflect:
                    return "(ダメージ反射)";
                case pspo2seForm.abilityType.HP_affects_pwr:
                    return "(憤怒)";
                case pspo2seForm.abilityType.AutoDamage:
                    return "(自動ダメージ)";
                case pspo2seForm.abilityType.AutoDefend:
                    return "(自動回復)";
                case pspo2seForm.abilityType.AttackUp:
                    return "(攻撃法撃↑)";
                case pspo2seForm.abilityType.AttackDown:
                    return "(攻撃法撃↓)";
                case pspo2seForm.abilityType.DefenseUp:
                    return "(防御回避精神↑)";
                case pspo2seForm.abilityType.DefenseDown:
                    return "(防御回避精神↓)";
                case pspo2seForm.abilityType.Empow_none:
                    return "";
                case pspo2seForm.abilityType.Empow_fire:
                    return "(炎属性威力↑)";
                case pspo2seForm.abilityType.Empow_ice:
                    return "(氷属性威力↑)";
                case pspo2seForm.abilityType.Empow_lightning:
                    return "(雷属性威力↑)";
                case pspo2seForm.abilityType.Empow_earth:
                    return "(土属性威力↑)";
                case pspo2seForm.abilityType.Empow_light:
                    return "(光属性威力↑)";
                case pspo2seForm.abilityType.Empow_dark:
                    return "(闇属性威力↑)";
                case pspo2seForm.abilityType.Empow_healing:
                    return "(回復力↑)";
                default:
                    return "unk_" + (object)ability;
            }
        }

        public void showSelectedInventoryItem(TabPage page)
        {
            pspo2seForm.pageFields pageFields = this.getPageFields(page);
            bool flag = false;
            pspo2seForm.inventoryItemClass inventoryItemClass;
            if (page == this.tabPageStorage)
            {
                if (this.storageView.SelectedItems.Count > 0)
                {
                    inventoryItemClass = this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
                    inventoryItemClass.qty_max = 999;
                    flag = true;
                }
                else
                    inventoryItemClass = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[0];
            }
            else if (this.inventoryView.SelectedItems.Count > 0)
            {
                inventoryItemClass = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)];
                flag = true;
            }
            else
                inventoryItemClass = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[0];
            if (!inventoryItemClass.used)
            {
                inventoryItemClass.name = "---- Free Slot ----";
                inventoryItemClass.rarity = -1;
                inventoryItemClass.type = pspo2seForm.itemType.free_slot;
            }
            pageFields.txt_hex.Text = "0x" + inventoryItemClass.hex_reversed;
            pageFields.txt_name.Text = inventoryItemClass.name;
            pageFields.txt_name_jp.Text = inventoryItemClass.name_jp;
            this.showButtons(pageFields, inventoryItemClass.type);
            this.displayItemImage(pageFields, inventoryItemClass);
            this.displayItemStars(pageFields, inventoryItemClass.rarity);
            this.displayItemInfo(pageFields, inventoryItemClass);
            if (!flag)
                return;
            this.changeImageFloater(inventoryItemClass.hex_reversed);
        }

        private void displayWeaponExtendInfo(
          pspo2seForm.pageFields fields,
          pspo2seForm.inventoryItemClass item)
        {
            pspo2seForm.weaponType weaponTypeFromHex = this.getWeaponTypeFromHex(item.hex_reversed);
            pspo2seForm.itemExtendType weaponExtendType = this.getWeaponExtendType(item.extended, item.style, weaponTypeFromHex);
            string str1 = "FULL";
            if (item.inf_extended == pspo2seForm.itemInfExtendType.extended)
                str1 = "EXT FULL";
            else if (item.inf_extended == pspo2seForm.itemInfExtendType.not_extended_special)
                str1 = "FULL";
            else if (item.inf_extended == pspo2seForm.itemInfExtendType.extended_special)
                str1 = "EXT FULL";
            else if (item.inf_extended != pspo2seForm.itemInfExtendType.not_extended)
            {
                int num1 = (int)MessageBox.Show("Unknown infinity extend type: " + (object)item.inf_extended);
            }
            switch (weaponExtendType)
            {
                case pspo2seForm.itemExtendType.not_extended:
                    str1 = "";
                    break;
                case pspo2seForm.itemExtendType.extended:
                    fields.txt_grinds.Text = "(" + str1 + ")";
                    break;
                case pspo2seForm.itemExtendType.dlc_not_extended:
                    str1 = "";
                    break;
                case pspo2seForm.itemExtendType.dlc_extended:
                    fields.txt_grinds.Text = "(" + str1 + ")";
                    break;
                case pspo2seForm.itemExtendType.not_extended_cs1:
                    str1 = "";
                    fields.txt_grinds.Text = "CSI " + fields.txt_grinds.Text;
                    break;
                case pspo2seForm.itemExtendType.not_extended_cs2:
                    str1 = "";
                    fields.txt_grinds.Text = "CSII " + fields.txt_grinds.Text;
                    break;
                case pspo2seForm.itemExtendType.extended_cs1:
                    fields.txt_grinds.Text = "CSI (" + str1 + ")";
                    break;
                case pspo2seForm.itemExtendType.extended_cs2:
                    fields.txt_grinds.Text = "CSII (" + str1 + ")";
                    break;
                case pspo2seForm.itemExtendType.unknown:
                    fields.txt_grinds.Text = item.style.ToString() + " " + (object)item.extended + " " + fields.txt_grinds.Text;
                    break;
                default:
                    int num2 = (int)MessageBox.Show("Unhandled extend type: " + (object)item.extended);
                    break;
            }
            Decimal num3 = new Decimal(1.0);
            if (item.spcl_effect == "Unsealed")
            {
                num3 = new Decimal(1.3);
                item.ext_special_level = "LV5";
                item.special_level = "LV5";
            }
            if (str1 == "FULL")
            {
                if (item.style == pspo2seForm.weaponStyleType.Tech || weaponTypeFromHex == pspo2seForm.weaponType.longbow)
                {
                    if (item.power == 0 || item.ext_power == 0)
                    {
                        fields.txt_atk.Text = "TEC  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                    else
                    {
                        fields.txt_atk.Text = "TEC  " + (object)(int)((Decimal)(item.power + item.ext_power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
                        if (weaponTypeFromHex == pspo2seForm.weaponType.longbow)
                            fields.txt_acc.Text = "ACC  " + (object)(int)((Decimal)(item.acc + item.ext_acc) * num3);
                    }
                    if (weaponTypeFromHex != pspo2seForm.weaponType.longbow)
                        fields.txt_acc.Text = "";
                }
                else if (item.power == 0 || item.ext_power == 0)
                {
                    fields.txt_atk.Text = "ATK  DB_Error";
                    fields.txt_acc.Text = "ACC  DB_Error";
                }
                else
                {
                    fields.txt_atk.Text = "ATK  " + (object)(int)((Decimal)(item.power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity) + item.ext_power) * num3);
                    fields.txt_acc.Text = "ACC  " + (object)(int)((Decimal)(item.acc + item.ext_acc) * num3);
                }
                fields.txt_level.Text = item.ext_level;
            }
            else if (str1 == "EXT FULL")
            {
                if (item.style == pspo2seForm.weaponStyleType.Tech || weaponTypeFromHex == pspo2seForm.weaponType.longbow)
                {
                    if (item.power == 0 || item.ext_power == 0 || item.inf_ext_power == 0)
                    {
                        fields.txt_atk.Text = "TEC  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                    else
                    {
                        fields.txt_atk.Text = "TEC  " + (object)(int)((Decimal)(item.power + item.ext_power + item.inf_ext_power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
                        if (weaponTypeFromHex == pspo2seForm.weaponType.longbow)
                            fields.txt_acc.Text = "ACC  " + (object)(int)((Decimal)(item.acc + item.ext_acc + item.inf_ext_acc) * num3);
                    }
                    if (weaponTypeFromHex != pspo2seForm.weaponType.longbow)
                        fields.txt_acc.Text = "";
                }
                else if (item.power == 0 || item.ext_power == 0 || item.inf_ext_power == 0)
                {
                    fields.txt_atk.Text = "ATK  DB_Error";
                    fields.txt_acc.Text = "ACC  DB_Error";
                }
                else
                {
                    fields.txt_atk.Text = "ATK  " + (object)(int)((Decimal)(item.power + item.ext_power + item.inf_ext_power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
                    fields.txt_acc.Text = "ACC  " + (object)(int)((Decimal)(item.acc + item.ext_acc + item.inf_ext_acc) * num3);
                }
                fields.txt_level.Text = item.inf_ext_level;
            }
            else
            {
                if (item.style == pspo2seForm.weaponStyleType.Tech || weaponTypeFromHex == pspo2seForm.weaponType.longbow)
                {
                    if (item.power == 0)
                    {
                        fields.txt_atk.Text = "TEC  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                    else
                    {
                        fields.txt_atk.Text = "TEC  " + (object)(int)((Decimal)(item.power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
                        if (weaponTypeFromHex == pspo2seForm.weaponType.longbow)
                            fields.txt_acc.Text = "ACC  " + (object)(int)((Decimal)item.acc * num3);
                    }
                    if (weaponTypeFromHex != pspo2seForm.weaponType.longbow)
                        fields.txt_acc.Text = "";
                }
                else if (item.power == 0)
                {
                    fields.txt_atk.Text = "ATK  DB_Error";
                    fields.txt_acc.Text = "ACC  DB_Error";
                }
                else
                {
                    fields.txt_atk.Text = "ATK  " + (object)(int)((Decimal)(item.power + this.grindsToPowIncrease(this.getWeaponTypeFromHex(item.hex_reversed), item.grinds, item.rarity)) * num3);
                    fields.txt_acc.Text = "ACC  " + (object)(int)((Decimal)item.acc * num3);
                }
                fields.txt_level.Text = item.level;
            }
            if (item.power_add > 0 && item.power_add <= 9999 && fields.txt_atk.Text.Replace("DB_Error", "") == fields.txt_atk.Text)
            {
                int num4 = int.Parse(fields.txt_atk.Text.Replace("ATK  ", "").Replace("TEC  ", "")) + item.power_add;
                if (num4 > 9999)
                    num4 = 9999;
                if (item.style == pspo2seForm.weaponStyleType.Tech || weaponTypeFromHex == pspo2seForm.weaponType.longbow)
                    fields.txt_atk.Text = "TEC  " + (object)num4 + " [+" + (object)item.power_add + "]";
                else
                    fields.txt_atk.Text = "ATK  " + (object)num4 + " [+" + (object)item.power_add + "]";
            }
            else if (item.power_add > 9999 && fields.txt_atk.Text.Replace("DB_Error", "") == fields.txt_atk.Text)
            {
                if (item.style == pspo2seForm.weaponStyleType.Tech || weaponTypeFromHex == pspo2seForm.weaponType.longbow)
                    fields.txt_atk.Text = "TEC  " + (object)(int)((Decimal)item.power * num3);
                else
                    fields.txt_atk.Text = "ATK  " + (object)(int)((Decimal)item.power * num3);
            }
            if (item.ability != pspo2seForm.abilityType.None && item.special != "None" && (str1 == "FULL" || str1 == "EXT FULL"))
                item.special = "None (なし)";
            if (item.special == "")
                item.special = "None (なし)";
            if (item.special != "None (なし)" && item.special != "None" && item.special != null)
            {
                fields.txt_special.Visible = true;
                if (item.special == "Varies by element")
                    item.special = this.getElementSpecialAsString(item.element);
                if (str1 == "FULL" || str1 == "EXT FULL")
                    fields.txt_special.Text = "Ability  " + item.special + " " + item.ext_special_level + " " + this.abilityToJp(this.stringToAbilityEnum(item.special)) + " [Extended]";
                else
                    fields.txt_special.Text = "Ability  " + item.special + " " + item.special_level + " " + this.abilityToJp(this.stringToAbilityEnum(item.special));
            }
            else if (item.ability != pspo2seForm.abilityType.None)
            {
                string str2 = item.ability.ToString().Replace("_", " ");
                if (item.style == pspo2seForm.weaponStyleType.Tech)
                    str2 = (item.ability + 21).ToString().Replace("_", " ");
                if (str1 == "FULL" || str1 == "EXT FULL")
                    fields.txt_special.Text = "Ability  " + str2.Replace("Empow", "Empow.") + " " + item.ext_special_level + " " + this.abilityToJp(this.stringToAbilityEnum(str2)) + " [Extended]";
                else
                    fields.txt_special.Text = "Ability  " + str2.Replace("Empow", "Empow.") + " " + item.special_level + " " + this.abilityToJp(this.stringToAbilityEnum(str2));
            }
            else
                fields.txt_special.Text = "Ability  None (なし)";
        }

        private int grindsToPowIncrease(pspo2seForm.weaponType weapon, int grinds, int rarity) => 0;

        public string elementToSubEnemyType(pspo2seForm.elementType element)
        {
            string[] infinityEnemy = this.intToInfinityEnemy((int)element);
            return infinityEnemy[1] + " (" + infinityEnemy[0] + ")";
        }

        public string[] intToInfinityEnemy(int i)
        {
            string[] strArray = new string[2];
            switch (i)
            {
                case 0:
                    strArray[0] = "パルム系";
                    strArray[1] = "Planet Parum System";
                    break;
                case 1:
                    strArray[0] = "ニューデイズ系";
                    strArray[1] = "Planet Neudaiz System";
                    break;
                case 2:
                    strArray[0] = "モトゥブ系";
                    strArray[1] = "Planet Moatoob System";
                    break;
                case 3:
                    strArray[0] = "ＳＥＥＤ系";
                    strArray[1] = "SEED System";
                    break;
                case 4:
                    strArray[0] = "マシナリー系";
                    strArray[1] = "Machinery System";
                    break;
                case 5:
                    strArray[0] = "スタティリア系";
                    strArray[1] = "Stateria System";
                    break;
                case 6:
                    strArray[0] = "人型系";
                    strArray[1] = "Humanoid System";
                    break;
                default:
                    strArray[0] = "unk_" + (object)i;
                    strArray[1] = "unk_" + (object)i;
                    break;
            }
            return strArray;
        }

        public string[] intToInfinityArea(int i)
        {
            string[] strArray = new string[2];
            switch (i)
            {
                case 0:
                    strArray[0] = "新緑";
                    strArray[1] = "Fresh Verdure";
                    break;
                case 1:
                    strArray[0] = "白銀";
                    strArray[1] = "The Snowfield";
                    break;
                case 2:
                    strArray[0] = "密林";
                    strArray[1] = "The Jungle";
                    break;
                case 3:
                    strArray[0] = "繚乱";
                    strArray[1] = "Profusion";
                    break;
                case 4:
                    strArray[0] = "漆黒";
                    strArray[1] = "Pitch Black";
                    break;
                case 5:
                    strArray[0] = "幻想";
                    strArray[1] = "Illusions";
                    break;
                case 6:
                    strArray[0] = "秘境";
                    strArray[1] = "Uncharted Region";
                    break;
                case 7:
                    strArray[0] = "覚醒";
                    strArray[1] = "The Awakened";
                    break;
                case 8:
                    strArray[0] = "常夏";
                    strArray[1] = "Eternal Summer";
                    break;
                case 9:
                    strArray[0] = "創生";
                    strArray[1] = "The Genesis";
                    break;
                default:
                    strArray[0] = "unk_" + (object)i;
                    strArray[1] = "unk_" + (object)i;
                    break;
            }
            return strArray;
        }

        public string[] intToInfinityBoss(int i)
        {
            string[] strArray = new string[2];
            switch (i)
            {
                case 0:
                    strArray[0] = "巨獣";
                    strArray[1] = "De Ragan";
                    break;
                case 1:
                    strArray[0] = "翼獣";
                    strArray[1] = "Zoal Goug";
                    break;
                case 2:
                    strArray[0] = "震角獣";
                    strArray[1] = "Bil De Golus";
                    break;
                case 3:
                    strArray[0] = "守護獣";
                    strArray[1] = "De Ragnus";
                    break;
                case 4:
                    strArray[0] = "聖獣";
                    strArray[1] = "Alterazgohg";
                    break;
                case 5:
                    strArray[0] = "炎帝龍";
                    strArray[1] = "Dragon";
                    break;
                case 6:
                    strArray[0] = "凶飛獣";
                    strArray[1] = "Onmagoug";
                    break;
                case 7:
                    strArray[0] = "凶砂獣";
                    strArray[1] = "Dimmagolus";
                    break;
                case 8:
                    strArray[0] = "双生獣";
                    strArray[1] = "Faz'ntar Seg'ntar";
                    break;
                case 9:
                    strArray[0] = "六眼獣";
                    strArray[1] = "Azn'gom Gijn'gom";
                    break;
                case 10:
                    strArray[0] = "蛇獣";
                    strArray[1] = "De Rol Le";
                    break;
                case 11:
                    strArray[0] = "機械兵器";
                    strArray[1] = "Adahna Degahna";
                    break;
                case 12:
                    strArray[0] = "破壊兵器";
                    strArray[1] = "Magas Maggahna";
                    break;
                case 13:
                    strArray[0] = "多脚兵器";
                    strArray[1] = "Reol Badia";
                    break;
                case 14:
                    strArray[0] = "重装兵器";
                    strArray[1] = "Duga Dunga";
                    break;
                case 15:
                    strArray[0] = "真闇";
                    strArray[1] = "Dulk Fakis";
                    break;
                case 16:
                    strArray[0] = "邪神";
                    strArray[1] = "Dulk Fakis Final";
                    break;
                case 17:
                    strArray[0] = "暗黒蛇";
                    strArray[1] = "Dark Falz";
                    break;
                case 18:
                    strArray[0] = "暗黒神";
                    strArray[1] = "Dark Falz Final";
                    break;
                case 19:
                    strArray[0] = "電脳中枢";
                    strArray[1] = "Mother Brain";
                    break;
                case 20:
                    strArray[0] = "侵略者";
                    strArray[1] = "Orga Spiritus";
                    break;
                case 21:
                    strArray[0] = "太陽神";
                    strArray[1] = "Orga Angelus";
                    break;
                case 22:
                    strArray[0] = "堕天";
                    strArray[1] = "Orga Anastatis";
                    break;
                case 23:
                    strArray[0] = "地母神";
                    strArray[1] = "Dol Vaveer";
                    break;
                case 24:
                    strArray[0] = "邪龍";
                    strArray[1] = "Orga Dyran";
                    break;
                case 25:
                    strArray[0] = "刃獣";
                    strArray[1] = "Dilla Bravace";
                    break;
                case 26:
                    strArray[0] = "殻獣";
                    strArray[1] = "Giel Zohg";
                    break;
                case 27:
                    strArray[0] = "甲殻兵器";
                    strArray[1] = "Volna Gravka";
                    break;
                case 28:
                    strArray[0] = "覚醒者";
                    strArray[1] = "Olga Flow";
                    break;
                case 29:
                    strArray[0] = "英雄";
                    strArray[1] = "Olga Flow Final";
                    break;
                case 30:
                    strArray[0] = "破壊神";
                    strArray[1] = "Dark Falz Dios";
                    break;
                case 31:
                    strArray[0] = "神獣";
                    strArray[1] = "Yaorozu";
                    break;
                case 32:
                    strArray[0] = "三兄弟";
                    strArray[1] = "Vol Bros";
                    break;
                case 33:
                    strArray[0] = "破壊者";
                    strArray[1] = "Seed-Helga";
                    break;
                case 34:
                    strArray[0] = "機動兵器";
                    strArray[1] = "Vivienne";
                    break;
                case 35:
                    strArray[0] = "野生児";
                    strArray[1] = "Kasch Tribesman";
                    break;
                case 36:
                    strArray[0] = "太陽王";
                    strArray[1] = "Shizuru";
                    break;
                case 37:
                    strArray[0] = "戦闘狂";
                    strArray[1] = "Renvolt Magashi";
                    break;
                case 38:
                    strArray[0] = "神兵";
                    strArray[1] = "Heavens Mother";
                    break;
                case 39:
                    strArray[0] = "転生者";
                    strArray[1] = "Nagisa";
                    break;
                default:
                    strArray[0] = "unk_" + (object)i;
                    strArray[1] = "unk_" + (object)i;
                    break;
            }
            return strArray;
        }

        public void displayItemInfo(pspo2seForm.pageFields fields, pspo2seForm.inventoryItemClass item)
        {
            if (fields.grp_details != null)
            {
                fields.grp_details.Visible = false;
                Application.DoEvents();
                fields.grp_details.SuspendLayout();
            }
            if (fields.pnl_details != null)
            {
                fields.pnl_details.Visible = false;
                Application.DoEvents();
                fields.pnl_details.SuspendLayout();
            }
            switch (item.infinity_item)
            {
                case "0":
                    fields.img_infinity_item.Visible = false;
                    fields.txt_infinity_item.Visible = false;
                    break;
                case "1":
                    fields.img_infinity_item.Visible = true;
                    fields.txt_infinity_item.Visible = false;
                    break;
                case "?":
                    fields.img_infinity_item.Visible = false;
                    fields.txt_infinity_item.Visible = true;
                    break;
            }
            fields.txt_level.Text = item.level;
            fields.txt_acc.Padding = new Padding(0, 0, 0, 0);
            fields.txt_special.Padding = new Padding(0, 0, 0, 0);
            fields.txt_effect.Padding = new Padding(0, 0, 0, 0);
            fields.txt_grinds.Size = new Size(210, 18);
            fields.txt_grinds.Location = new Point(81, 48);
            switch (item.type)
            {
                case pspo2seForm.itemType.Weapon:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = true;
                    fields.txt_special.Visible = true;
                    if (item.hand == pspo2seForm.weaponHandType.both)
                    {
                        fields.txt_name.Padding = new Padding(26, 0, 0, 0);
                        fields.img_item.Padding = new Padding(13, 0, 0, 0);
                    }
                    else
                    {
                        fields.txt_name.Padding = new Padding(13, 0, 0, 0);
                        fields.img_item.Padding = new Padding(13, 0, 0, 0);
                    }
                    fields.txt_qty.Visible = false;
                    this.displayElementImage(fields, item.element);
                    fields.img_element.Visible = true;
                    fields.txt_percent.Visible = true;
                    fields.txt_grinds.Visible = true;
                    fields.txt_effect.Visible = true;
                    fields.txt_atk.Visible = true;
                    fields.txt_acc.Visible = true;
                    fields.txt_percent.Text = item.percent.ToString() + "%";
                    fields.txt_grinds.Text = "(" + (object)item.grinds + ")";
                    fields.txt_effect.Text = "Effect  None (なし)";
                    fields.txt_special.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_effect.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_acc.Padding = new Padding(0, 0, 0, 0);
                    if (item.spcl_effect != "")
                    {
                        if (item.spcl_effect_info != "0000")
                        {
                            if (item.spcl_effect == "Unseals" || item.spcl_effect == "Unsealed")
                            {
                                int num = int.Parse(this.run.hexAndMathFunction.reversehex(item.spcl_effect_info, 4), NumberStyles.HexNumber);
                                if (num > 2000)
                                    item.spcl_effect = "Unsealed";
                                fields.txt_effect.Text = "Effect  " + item.spcl_effect + " (Kills  " + (object)num + ")";
                            }
                            else
                                fields.txt_effect.Text = "Effect  " + item.spcl_effect + " (" + item.spcl_effect_info + ")";
                        }
                        else if (item.spcl_effect == "Unseals")
                            fields.txt_effect.Text = "Effect  " + item.spcl_effect + " (Kills  0)";
                        else
                            fields.txt_effect.Text = "Effect  " + item.spcl_effect;
                    }
                    this.displayWeaponExtendInfo(fields, item);
                    break;
                case pspo2seForm.itemType.Armor:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = true;
                    fields.txt_name.Padding = new Padding(13, 0, 0, 0);
                    fields.img_item.Padding = new Padding(13, 0, 0, 0);
                    fields.txt_qty.Visible = false;
                    fields.txt_atk.Visible = true;
                    fields.txt_acc.Visible = true;
                    this.displayElementImage(fields, item.element);
                    fields.img_element.Visible = true;
                    fields.txt_percent.Visible = true;
                    fields.txt_grinds.Visible = true;
                    fields.txt_special.Visible = true;
                    fields.txt_effect.Visible = true;
                    fields.txt_level.Text = item.level;
                    fields.txt_special.Text = "DEF  " + (object)item.power;
                    fields.txt_effect.Text = "EVA  " + (object)item.acc;
                    fields.txt_atk.Text = "MND  " + (object)item.ext_power;
                    fields.txt_acc.Text = "STA  " + (object)item.ext_acc;
                    fields.txt_special.Padding = new Padding(16, 0, 0, 0);
                    fields.txt_effect.Padding = new Padding(12, 0, 0, 0);
                    fields.txt_acc.Padding = new Padding(6, 0, 0, 0);
                    if (item.ext_level != "")
                        fields.txt_grinds.Text = item.ext_level + " slots";
                    else
                        fields.txt_grinds.Text = "no slots";
                    fields.txt_percent.Text = item.percent.ToString() + "%";
                    break;
                case pspo2seForm.itemType.Green_Item:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = false;
                    fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                    fields.img_item.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_qty.Visible = true;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    fields.txt_qty.Text = item.qty.ToString() + "/" + (object)item.qty_max;
                    fields.txt_grinds.Text = "(" + (object)item.grinds + ")";
                    break;
                case pspo2seForm.itemType.Infinity_Code:
                    Application.DoEvents();
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = false;
                    fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                    fields.img_item.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_qty.Visible = true;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = true;
                    fields.txt_special.Visible = true;
                    fields.txt_effect.Visible = true;
                    fields.txt_atk.Visible = true;
                    fields.txt_acc.Visible = true;
                    fields.txt_level.Visible = false;
                    fields.txt_acc.Padding = new Padding(6, 0, 0, 0);
                    fields.txt_special.Padding = new Padding(54, 0, 0, 0);
                    fields.txt_effect.Padding = new Padding(51, 0, 0, 0);
                    fields.txt_qty.Text = item.desc + " (" + item.desc_jp + ")";
                    fields.txt_special.Text = "Area  " + item.ext_level;
                    fields.txt_effect.Text = "Boss  " + item.level;
                    fields.txt_grinds.Text = "(+" + (object)item.percent + ")";
                    if (item.special == this.elementToSubEnemyType(item.element))
                    {
                        fields.txt_atk.Text = "Main Enemy  " + this.elementToSubEnemyType(pspo2seForm.elementType.Neutral);
                        fields.txt_acc.Text = "Sub Enemy  " + this.elementToSubEnemyType(pspo2seForm.elementType.Fire);
                    }
                    else
                    {
                        fields.txt_atk.Text = "Main Enemy  " + item.special;
                        fields.txt_acc.Text = "Sub Enemy  " + this.elementToSubEnemyType(item.element);
                    }
                    fields.txt_grinds.Size = new Size(50, 18);
                    fields.txt_grinds.Location = new Point(241, 48);
                    break;
                case pspo2seForm.itemType.Slot_Unit:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = true;
                    fields.txt_name.Padding = new Padding(14, 0, 0, 0);
                    fields.img_item.Padding = new Padding(14, 0, 0, 0);
                    fields.txt_qty.Visible = false;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    break;
                case pspo2seForm.itemType.Clothes_human:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = false;
                    fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                    fields.img_item.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_qty.Visible = false;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    break;
                case pspo2seForm.itemType.Clothes_android:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = false;
                    fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                    fields.img_item.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_qty.Visible = false;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    break;
                case pspo2seForm.itemType.Room_Decoration:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = false;
                    fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                    fields.img_item.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_qty.Visible = false;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    break;
                case pspo2seForm.itemType.Trap:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = false;
                    fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                    fields.img_item.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_qty.Visible = true;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    fields.txt_qty.Text = item.qty.ToString() + "/" + (object)item.qty_max;
                    break;
                case pspo2seForm.itemType.My_Synth_Device:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = false;
                    fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                    fields.img_item.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_qty.Visible = false;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    break;
                case pspo2seForm.itemType.Extend_Code:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = false;
                    fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                    fields.img_item.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_qty.Visible = true;
                    fields.img_element.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    fields.txt_qty.Text = item.qty.ToString() + "/" + (object)item.qty_max;
                    break;
                case pspo2seForm.itemType.free_slot:
                    if (fields.grp_details != null)
                        fields.grp_details.Visible = false;
                    if (fields.pnl_details != null)
                        fields.pnl_details.Visible = false;
                    fields.txt_qty.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_level.Text = "";
                    fields.img_element.Visible = false;
                    fields.img_rank.Image = (Image)Resources.free_slot;
                    fields.img_item.Visible = false;
                    fields.txt_name_jp.Text = "";
                    break;
                default:
                    if (item.type == pspo2seForm.itemType.PA_Disk_Melee || item.type == pspo2seForm.itemType.PA_Disk_Ranged || item.type == pspo2seForm.itemType.PA_Disk_Technique)
                    {
                        fields.img_item.Visible = true;
                        fields.img_rank.Visible = false;
                        fields.txt_name.Padding = new Padding(0, 0, 0, 0);
                        fields.img_item.Padding = new Padding(0, 0, 0, 0);
                        fields.txt_qty.Visible = true;
                        fields.img_element.Visible = false;
                        fields.txt_percent.Visible = false;
                        fields.txt_grinds.Visible = false;
                        fields.txt_special.Visible = false;
                        fields.txt_effect.Visible = false;
                        fields.txt_atk.Visible = false;
                        fields.txt_acc.Visible = false;
                        fields.txt_qty.Text = "LV" + (object)(item.pa_level + 1) + " (" + this.getSlotPALearntLevel(this.lstSaveSlotView.SelectedItems[0].Index, item.hex) + ")";
                        break;
                    }
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = true;
                    fields.txt_name.Padding = new Padding(26, 0, 0, 0);
                    fields.img_item.Padding = new Padding(13, 0, 0, 0);
                    fields.txt_qty.Visible = true;
                    this.displayElementImage(fields, item.element);
                    fields.txt_percent.Visible = true;
                    fields.txt_grinds.Visible = true;
                    fields.txt_special.Visible = true;
                    fields.txt_effect.Visible = true;
                    fields.txt_atk.Visible = true;
                    fields.txt_acc.Visible = true;
                    int num1 = (int)MessageBox.Show("Type not dealt with in displayItemInfo() " + this.txtInventoryHex.Text);
                    fields.txt_qty.Text = item.qty.ToString() + "/" + (object)item.qty_max;
                    break;
            }
            Application.DoEvents();
            if (fields.grp_details != null)
            {
                fields.grp_details.ResumeLayout();
                fields.grp_details.Visible = true;
            }
            if (fields.pnl_details == null)
                return;
            fields.pnl_details.ResumeLayout();
            fields.pnl_details.Visible = true;
        }

        public void displayElementImage(pspo2seForm.pageFields fields, pspo2seForm.elementType element)
        {
            fields.img_element.Visible = true;
            switch (element)
            {
                case pspo2seForm.elementType.Neutral:
                    fields.img_element.Image = (Image)Resources.element_neutral;
                    break;
                case pspo2seForm.elementType.Fire:
                    fields.img_element.Image = (Image)Resources.element_fire;
                    break;
                case pspo2seForm.elementType.Ice:
                    fields.img_element.Image = (Image)Resources.element_ice;
                    break;
                case pspo2seForm.elementType.Thunder:
                    fields.img_element.Image = (Image)Resources.element_thunder;
                    break;
                case pspo2seForm.elementType.Earth:
                    fields.img_element.Image = (Image)Resources.element_earth;
                    break;
                case pspo2seForm.elementType.Light:
                    fields.img_element.Image = (Image)Resources.element_light;
                    break;
                case pspo2seForm.elementType.Dark:
                    fields.img_element.Image = (Image)Resources.element_dark;
                    break;
                default:
                    fields.img_element.Visible = false;
                    break;
            }
        }

        private void sortInventory(int slotnum)
        {
            ArrayList arrayList = ArrayList.Adapter((IList)this.saveData.slot[slotnum].inventory.item);
            arrayList.Sort();
            this.saveData.slot[slotnum].inventory.item = (pspo2seForm.inventoryItemClass[])arrayList.ToArray(typeof(pspo2seForm.inventoryItemClass));
        }

        private void sortStorage()
        {
            ArrayList arrayList = ArrayList.Adapter((IList)this.saveData.sharedInventory.item);
            arrayList.Sort();
            this.saveData.sharedInventory.item = (pspo2seForm.inventoryItemClass[])arrayList.ToArray(typeof(pspo2seForm.inventoryItemClass));
        }

        private bool allowShowItem(int page, pspo2seForm.inventoryItemClass item)
        {
            switch (page)
            {
                case 1:
                    if (item.type == pspo2seForm.itemType.Weapon)
                        return true;
                    break;
                case 2:
                    if (item.type == pspo2seForm.itemType.Armor || item.type == pspo2seForm.itemType.Slot_Unit)
                        return true;
                    break;
                case 3:
                    if (item.type == pspo2seForm.itemType.Green_Item || item.type == pspo2seForm.itemType.PA_Disk_Melee || (item.type == pspo2seForm.itemType.PA_Disk_Ranged || item.type == pspo2seForm.itemType.PA_Disk_Technique) || (item.type == pspo2seForm.itemType.Trap || item.type == pspo2seForm.itemType.Infinity_Code))
                        return true;
                    break;
                case 4:
                    if (item.type == pspo2seForm.itemType.Clothes_android || item.type == pspo2seForm.itemType.Clothes_human)
                        return true;
                    break;
                case 5:
                    if (item.type == pspo2seForm.itemType.Room_Decoration || item.type == pspo2seForm.itemType.Extend_Code || item.type == pspo2seForm.itemType.My_Synth_Device)
                        return true;
                    break;
                case 6:
                    if (item.type == pspo2seForm.itemType.free_slot || item.type == pspo2seForm.itemType.unknown_5)
                        return true;
                    break;
                default:
                    int num = (int)MessageBox.Show("page: " + (object)page + "not handled in allowShowItem()");
                    break;
            }
            return false;
        }

        private void displayInventory(int slotnum, int page)
        {
            this.inventoryView.SelectedItems.Clear();
            this.inventoryView.Items.Clear();
            this.sortInventory(slotnum);
            this.picWeaponSlot01.Image = (Image)null;
            this.picWeaponSlot02.Image = (Image)null;
            this.picWeaponSlot03.Image = (Image)null;
            this.picWeaponSlot04.Image = (Image)null;
            this.picWeaponSlot05.Image = (Image)null;
            this.picWeaponSlot06.Image = (Image)null;
            int index1 = -1;
            for (int index2 = 0; index2 < 60; ++index2)
            {
                pspo2seForm.inventoryItemClass inventoryItemClass1 = new pspo2seForm.inventoryItemClass();
                pspo2seForm.inventoryItemClass inventoryItemClass2 = this.saveData.slot[slotnum].inventory.item[index2];
                if (inventoryItemClass2.type == pspo2seForm.itemType.Weapon && inventoryItemClass2.equipped_slot > 0)
                {
                    int index3 = (int)(this.getWeaponTypeFromHex(inventoryItemClass2.hex_reversed) - 1 + (int)inventoryItemClass2.element * 28);
                    switch (inventoryItemClass2.equipped_slot)
                    {
                        case 1:
                            this.picWeaponSlot01.Image = this.imageListWeaponElements.Images[index3];
                            break;
                        case 2:
                            this.picWeaponSlot02.Image = this.imageListWeaponElements.Images[index3];
                            break;
                        case 3:
                            this.picWeaponSlot03.Image = this.imageListWeaponElements.Images[index3];
                            break;
                        case 4:
                            this.picWeaponSlot04.Image = this.imageListWeaponElements.Images[index3];
                            break;
                        case 5:
                            this.picWeaponSlot05.Image = this.imageListWeaponElements.Images[index3];
                            break;
                        case 6:
                            this.picWeaponSlot06.Image = this.imageListWeaponElements.Images[index3];
                            break;
                    }
                }
                if (this.allowShowItem(page, inventoryItemClass2))
                {
                    string str;
                    if (inventoryItemClass2.used)
                    {
                        str = !(inventoryItemClass2.name == "") || !(inventoryItemClass2.name_jp != "") ? (!(inventoryItemClass2.name == "") ? inventoryItemClass2.name + " (" + inventoryItemClass2.name_jp + ")" : "Unk_" + inventoryItemClass2.hex) : inventoryItemClass2.name_jp;
                    }
                    else
                    {
                        str = "---- Free Slot ----";
                        inventoryItemClass2.rarity = -1;
                    }
                    this.inventoryView.Items.Add(new ListViewItem()
                    {
                        Text = str,
                        ImageIndex = this.getImageListNumber(inventoryItemClass2),
                        SubItems = {
              string.Concat((object) index2)
            }
                    });
                    if (this.selectInventoryItemAfterLoad != -1 && inventoryItemClass2.id == this.selectInventoryItemAfterLoad)
                        index1 = this.inventoryView.Items.Count - 1;
                }
            }
            this.tabPageInventory.Text = "Inventory (" + (object)this.saveData.slot[slotnum].inventory.itemsUsed + "/60)";
            if (index1 != -1)
            {
                this.inventoryView.Items[index1].Selected = true;
                this.inventoryView.Items[index1].EnsureVisible();
                this.selectInventoryItemAfterLoad = -1;
            }
            else
            {
                if (this.selectInventoryItemAfterLoad == -1)
                    return;
                for (int index2 = 0; index2 < 60; ++index2)
                {
                    if (this.saveData.slot[slotnum].inventory.item[index2].id == this.selectInventoryItemAfterLoad)
                    {
                        for (int index3 = 0; index3 < 5; ++index3)
                        {
                            if (this.allowShowItem(index3 + 1, this.saveData.slot[slotnum].inventory.item[index2]))
                            {
                                this.tabArea.SelectedIndex = 2;
                                this.inventoryViewPages.SelectedIndex = index3;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private int getFreeInventoryItemId(int slot) => this.saveData.slot[slot].inventory.itemsUsed < 60 ? this.saveData.slot[slot].inventory.itemsUsed * 36 + 8 + slot * this.mainSettings.saveStructureIndex.slot_size + this.mainSettings.saveStructureIndex.inventory_slots_pos : -1;

        private void displaySharedStorage(int page)
        {
            this.storageView.SelectedItems.Clear();
            this.storageView.Items.Clear();
            this.sortStorage();
            this.saveData.sharedInventory.itemsUsed = 0;
            this.txtStorageMeseta.Text = string.Concat((object)this.saveData.sharedMeseta);
            int num1 = 0;
            if (this.mainSettings.saveStructureIndex.shared_inventory_slots == 1000)
                num1 = 1000;
            int index1 = -1;
            for (int index2 = 0; index2 < this.mainSettings.saveStructureIndex.shared_inventory_slots + num1; ++index2)
            {
                if (this.saveData.sharedInventory.item[index2].type != pspo2seForm.itemType.free_slot)
                    ++this.saveData.sharedInventory.itemsUsed;
                pspo2seForm.inventoryItemClass inventoryItemClass = this.saveData.sharedInventory.item[index2];
                if (this.allowShowItem(page, inventoryItemClass))
                {
                    string text;
                    if (inventoryItemClass.type != pspo2seForm.itemType.free_slot)
                    {
                        text = !(inventoryItemClass.name == "") || !(inventoryItemClass.name_jp != "") ? (!(inventoryItemClass.name == "") ? inventoryItemClass.name + " (" + inventoryItemClass.name_jp + ")" : "Unk_" + inventoryItemClass.hex_reversed) : inventoryItemClass.name_jp;
                        if (this.getWeaponExtendType(inventoryItemClass.extended, inventoryItemClass.style, this.getWeaponTypeFromHex(inventoryItemClass.hex_reversed)) == pspo2seForm.itemExtendType.unknown)
                        {
                            int num2 = (int)MessageBox.Show("unknown extend " + text + " " + inventoryItemClass.hex_reversed);
                        }
                    }
                    else
                        text = "---- Free Slot ----";
                    int imageListNumber = this.getImageListNumber(inventoryItemClass);
                    this.storageView.Items.Add(new ListViewItem(text, imageListNumber)
                    {
                        SubItems = {
              string.Concat((object) index2)
            }
                    });
                    if (this.selectItemAfterLoad != -1 && inventoryItemClass.id == this.selectItemAfterLoad)
                        index1 = this.storageView.Items.Count - 1;
                }
            }
            if (index1 != -1)
            {
                this.storageView.Items[index1].Selected = true;
                this.storageView.Items[index1].EnsureVisible();
                this.selectItemAfterLoad = -1;
            }
            else if (this.selectItemAfterLoad != -1)
            {
                int num2 = 0;
                if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
                {
                    int num3 = num2 + 1000;
                }
                for (int index2 = 0; index2 < 2000; ++index2)
                {
                    if (this.saveData.sharedInventory.item[index2].id == this.selectItemAfterLoad)
                    {
                        for (int index3 = 0; index3 < 5; ++index3)
                        {
                            if (this.allowShowItem(index3 + 1, this.saveData.sharedInventory.item[index2]))
                            {
                                this.tabArea.SelectedIndex = 3;
                                this.storageViewPages.SelectedIndex = index3;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            this.tabPageStorage.Text = "Shared (" + (object)this.saveData.sharedInventory.itemsUsed + "/" + (object)this.mainSettings.saveStructureIndex.shared_inventory_slots + ")";
        }

        private int getImageListNumber(pspo2seForm.inventoryItemClass item)
        {
            int num1 = 1000;
            switch (item.type)
            {
                case pspo2seForm.itemType.Weapon:
                    num1 = (int)(this.getWeaponTypeFromHex(item.hex_reversed) - 1 + 28 * (int)this.getItemRankFromRarity(item.rarity));
                    if (item.equipped_now == 1)
                    {
                        num1 += 280;
                        break;
                    }
                    if (item.equipped_slot > 0)
                    {
                        num1 += 140;
                        break;
                    }
                    break;
                case pspo2seForm.itemType.Armor:
                    num1 = (int)this.getItemRankFromRarity(item.rarity);
                    if (item.equipped_now == 1)
                    {
                        num1 += 10;
                        break;
                    }
                    if (item.equipped_slot > 0)
                    {
                        num1 += 5;
                        break;
                    }
                    break;
                case pspo2seForm.itemType.Green_Item:
                    switch (this.getGreenItemTypeFromHex(item.hex_reversed))
                    {
                        case pspo2seForm.greenItemType.monomate:
                            num1 = 3;
                            break;
                        case pspo2seForm.greenItemType.dimate:
                            num1 = 3;
                            break;
                        case pspo2seForm.greenItemType.trimate:
                            num1 = 3;
                            break;
                        case pspo2seForm.greenItemType.star_atom:
                            num1 = 3;
                            break;
                        case pspo2seForm.greenItemType.sol_atom:
                            num1 = 4;
                            break;
                        case pspo2seForm.greenItemType.moon_atom:
                            num1 = 5;
                            break;
                        case pspo2seForm.greenItemType.doll:
                            num1 = 5;
                            break;
                        case pspo2seForm.greenItemType.shiftaride:
                            num1 = 6;
                            break;
                        case pspo2seForm.greenItemType.debanride:
                            num1 = 6;
                            break;
                        case pspo2seForm.greenItemType.calorie:
                            num1 = 7;
                            break;
                        case pspo2seForm.greenItemType.item:
                            num1 = 8;
                            break;
                        default:
                            int num2 = (int)MessageBox.Show("Green item type not recognised for image: " + (object)this.getGreenItemTypeFromHex(item.hex_reversed));
                            break;
                    }
                    if (item.equipped_now == 1)
                    {
                        num1 += 18;
                        break;
                    }
                    if (item.equipped_slot > 0)
                    {
                        num1 += 9;
                        break;
                    }
                    break;
                case pspo2seForm.itemType.PA_Disk_Melee:
                    num1 = 0;
                    break;
                case pspo2seForm.itemType.PA_Disk_Ranged:
                    num1 = 0;
                    break;
                case pspo2seForm.itemType.PA_Disk_Technique:
                    num1 = 0;
                    break;
                case pspo2seForm.itemType.Infinity_Code:
                    num1 = 8;
                    break;
                case pspo2seForm.itemType.Slot_Unit:
                    num1 = (int)(this.getSlotTypeFromHex(item.hex_reversed) + 15 + (int)this.getItemRankFromRarity(item.rarity) * 4);
                    if (item.equipped_now == 1)
                    {
                        num1 += 40;
                        break;
                    }
                    if (item.equipped_slot > 0)
                    {
                        num1 += 20;
                        break;
                    }
                    break;
                case pspo2seForm.itemType.Clothes_human:
                    switch (this.getClothesTypeFromHex(item.hex_reversed))
                    {
                        case 1:
                            num1 = 0;
                            break;
                        case 2:
                            num1 = 1;
                            break;
                        case 3:
                            num1 = 2;
                            break;
                        case 4:
                            num1 = 3;
                            break;
                        case 5:
                            num1 = 4;
                            break;
                        case 6:
                            num1 = 5;
                            break;
                    }
                    if (item.equipped_now == 1)
                    {
                        num1 += 20;
                        break;
                    }
                    if (item.equipped_slot > 0)
                    {
                        num1 += 10;
                        break;
                    }
                    break;
                case pspo2seForm.itemType.Clothes_android:
                    switch (this.getClothesTypeFromHex(item.hex_reversed))
                    {
                        case 1:
                            num1 = 6;
                            break;
                        case 2:
                            num1 = 7;
                            break;
                        case 3:
                            num1 = 8;
                            break;
                        case 6:
                            num1 = 9;
                            break;
                    }
                    if (item.equipped_now == 1)
                    {
                        num1 += 20;
                        break;
                    }
                    if (item.equipped_slot > 0)
                    {
                        num1 += 10;
                        break;
                    }
                    break;
                case pspo2seForm.itemType.Room_Decoration:
                    num1 = 2;
                    break;
                case pspo2seForm.itemType.Trap:
                    if (item.hex_reversed.Substring(5, 1) == "1")
                        num1 = 1;
                    if (item.hex_reversed.Substring(5, 1) == "2")
                    {
                        num1 = 2;
                        break;
                    }
                    break;
                case pspo2seForm.itemType.My_Synth_Device:
                    num1 = 1;
                    break;
                case pspo2seForm.itemType.Extend_Code:
                    num1 = 0;
                    break;
                case pspo2seForm.itemType.free_slot:
                    num1 = 3;
                    break;
            }
            return num1;
        }

        private void changeInventoryPage(int page)
        {
            switch (page)
            {
                case 1:
                    this.inventoryView.SmallImageList = this.weaponWithRankImageList;
                    break;
                case 2:
                    this.inventoryView.SmallImageList = this.armourImageList;
                    break;
                case 3:
                    this.inventoryView.SmallImageList = this.itemImageList;
                    break;
                case 4:
                    this.inventoryView.SmallImageList = this.clothesImageList;
                    break;
                case 5:
                    this.inventoryView.SmallImageList = this.decoImageList;
                    break;
                case 6:
                    this.inventoryView.SmallImageList = this.decoImageList;
                    break;
            }
            this.btnInventoryDelete.Enabled = false;
            this.btnInventoryImportSelected.Enabled = false;
            this.btnInventoryExportSelected.Enabled = false;
            this.chkDeleteExportInventory.Enabled = false;
            this.btnInventoryDeposit.Enabled = false;
            this.displayInventory(this.lstSaveSlotView.SelectedItems[0].Index, page);
            Application.DoEvents();
            switch (page - 1)
            {
                case 0:
                    this.openImageFloater();
                    break;
                case 1:
                    this.closeImageFloater();
                    break;
                case 2:
                    this.closeImageFloater();
                    break;
                case 3:
                    this.closeImageFloater();
                    break;
                case 4:
                    this.closeImageFloater();
                    break;
                case 5:
                    this.closeImageFloater();
                    break;
            }
        }

        private void changeStoragePage(int page)
        {
            this.btnStorageDelete.Enabled = false;
            this.btnStorageImportSelected.Enabled = false;
            this.btnStorageExportSelected.Enabled = false;
            this.chkDeleteExportStorage.Enabled = false;
            this.btnStorageWithdraw.Enabled = false;
            this.displaySharedStorage(page);
            switch (page - 1)
            {
                case 0:
                    this.storageView.SmallImageList = this.weaponWithRankImageList;
                    break;
                case 1:
                    this.storageView.SmallImageList = this.armourImageList;
                    break;
                case 2:
                    this.storageView.SmallImageList = this.itemImageList;
                    break;
                case 3:
                    this.storageView.SmallImageList = this.clothesImageList;
                    break;
                case 4:
                    this.storageView.SmallImageList = this.decoImageList;
                    break;
                case 5:
                    this.storageView.SmallImageList = this.decoImageList;
                    break;
            }
            switch (page - 1)
            {
                case 0:
                    this.openImageFloater();
                    break;
                case 1:
                    this.closeImageFloater();
                    break;
                case 2:
                    this.closeImageFloater();
                    break;
                case 3:
                    this.closeImageFloater();
                    break;
                case 4:
                    this.closeImageFloater();
                    break;
                case 5:
                    this.closeImageFloater();
                    break;
            }
        }

        public string hexToEffect(string hex)
        {
            switch (this.saveData.type)
            {
                case pspo2seForm.SaveType.PSP2:
                    switch (hex)
                    {
                        case "00":
                            return "";
                        case "10":
                            return "Unseals";
                        case "20":
                            return "ATK increase with kills";
                        case "30":
                            return "Hearts";
                        case "40":
                            return "+25 ACC for each equipped in party";
                        case "60":
                            return "+40% Attribute (Max 60%). Glow during day";
                        case "70":
                            return "+40% Attribute (Max 60%). Glow during night";
                        case "80":
                            return "Ability Increase";
                        case "90":
                            return "Hits one additional target";
                        case "B0":
                            return "Dark Meteor";
                        case "C0":
                            return "Prevent Enemy Attacks";
                        default:
                            return "unk_" + hex;
                    }
                case pspo2seForm.SaveType.PSP2I:
                    switch (hex)
                    {
                        case "00":
                            return "";
                        case "08":
                            return "Unseals";
                        case "10":
                            return "ATK increase with kills";
                        case "18":
                            return "Hearts";
                        case "1C":
                            return "Hearts";
                        case "20":
                            return "+25 ACC for each equipped in party";
                        case "30":
                            return "+40% Attribute (Max 60%). Glow during day";
                        case "38":
                            return "+40% Attribute (Max 60%). Glow during night";
                        case "40":
                            return "Ability Increase";
                        case "48":
                            return "Hits one additional target";
                        case "58":
                            return "Dark Meteor";
                        case "60":
                            return "Prevent Enemy Attacks";
                        case "E0":
                            return "+25 ATK/DEF for each equipped in party";
                        default:
                            return "unk_" + hex;
                    }
                default:
                    return "hexToEffect invalid save type " + (object)this.saveData.type;
            }
        }

        public FileStream openFileRead(string fileLoc)
        {
            FileStream fileStream = (FileStream)null;
            if (fileLoc.Length <= 0)
                throw new ArgumentException();
            try
            {
                fileStream = new FileStream(fileLoc, FileMode.Open, FileAccess.Read);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Fatal Error!");
            }
            return fileStream;
        }

        private string getGameIdFromSfo(string gameSave)
        {
            FileStream fileStream = this.openFileRead(Path.Combine(Path.GetDirectoryName(gameSave), "PARAM.SFO"));
            BinaryReader binaryReader = new BinaryReader((Stream)fileStream);
            binaryReader.ReadBytes(1296);
            byte[] bytes = binaryReader.ReadBytes(9);
            fileStream.Close();
            return Encoding.Default.GetString(bytes);
        }

        private bool decryptSaveFile(string file)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "SED.exe";
            if (!System.IO.File.Exists(processStartInfo.FileName))
            {
                int num = (int)MessageBox.Show("SED.exe is missing");
                return false;
            }
            string gameIdFromSfo = this.getGameIdFromSfo(file);
            if (!System.IO.File.Exists("data\\keys\\" + gameIdFromSfo + ".bin"))
            {
                if (MessageBox.Show("You must place the '" + gameIdFromSfo + ".bin' key file in the data\\keys directory.\n\nDo you want to generate it now?", "Generate Key", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return false;
                try
                {
                    using (FileStream fileStream = new FileStream("data\\keys\\" + gameIdFromSfo + ".bin", FileMode.Create))
                    {
                        using (BinaryWriter binaryWriter = new BinaryWriter((Stream)fileStream))
                        {
                            for (int index = 0; index < 16; ++index)
                                binaryWriter.Write((byte)(128 + index));
                            binaryWriter.Close();
                        }
                        fileStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show("Failed to generate the key.\n\nError: " + ex.Message);
                    return false;
                }
            }
            processStartInfo.Arguments = "-d \"" + file + "\" data\\temp\\denc.bin data\\keys\\" + gameIdFromSfo + ".bin";
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            return true;
        }

        private bool encryptSaveFile(string file, string dest)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "SED.exe";
            if (!System.IO.File.Exists(processStartInfo.FileName))
            {
                int num = (int)MessageBox.Show("SED.exe is missing");
                return false;
            }
            string path = Path.Combine(Path.GetDirectoryName(dest), "PARAM.SFO");
            if (!System.IO.File.Exists(path))
            {
                int num = (int)MessageBox.Show("PARAM.SFO does not exist in that location.\n\nPlease choose the original location of your save file");
                return false;
            }
            string gameIdFromSfo = this.getGameIdFromSfo(dest);
            if (!System.IO.File.Exists("data\\keys\\" + gameIdFromSfo + ".bin"))
            {
                int num = (int)MessageBox.Show("You must place the '" + gameIdFromSfo + ".bin' key file in the data\\keys directory.\n\nSearch for SGKeyDumper to obtain the key for your game.");
                return false;
            }
            processStartInfo.Arguments = "-e \"" + file + "\" \"" + path + "\" \"" + dest + "\" data\\keys\\" + gameIdFromSfo + ".bin";
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            return true;
        }

        private bool validate_filelength(long filelength)
        {
            this.mainSettings.saveStructureIndex.changeSaveSettingsType(pspo2seForm.SaveType.PSP2);
            this.mainSettings.saveStructureIndex.encrypted = false;
            if (filelength == (long)this.mainSettings.saveStructureIndex.total_size || filelength == (long)this.mainSettings.saveStructureIndex.total_size_enc)
            {
                this.saveData.set_type(pspo2seForm.SaveType.PSP2);
                if (filelength == (long)this.mainSettings.saveStructureIndex.total_size_enc)
                    this.mainSettings.saveStructureIndex.encrypted = true;
                this.txtFileSize.Text = Convert.ToString(this.mainSettings.saveStructureIndex.total_size) + " bytes";
                return true;
            }
            this.mainSettings.saveStructureIndex.changeSaveSettingsType(pspo2seForm.SaveType.PSP2I);
            if (filelength == (long)this.mainSettings.saveStructureIndex.total_size || filelength == (long)this.mainSettings.saveStructureIndex.total_size_enc)
            {
                this.saveData.set_type(pspo2seForm.SaveType.PSP2I);
                if (filelength == (long)this.mainSettings.saveStructureIndex.total_size_enc)
                    this.mainSettings.saveStructureIndex.encrypted = true;
                this.txtFileSize.Text = Convert.ToString(this.mainSettings.saveStructureIndex.total_size) + " bytes";
                return true;
            }
            this.saveData.set_type(pspo2seForm.SaveType.NONE);
            this.txtFileSize.Text = "0 bytes";
            this.displaySlotInfo(0);
            this.showGameImage();
            this.txtFileSize.Text = Convert.ToString(filelength) + " bytes";
            return false;
        }

        private bool loadObjectIntoBuffer(
          BinaryReader br,
          int startpos,
          int len,
          pspo2seForm.partFileType type)
        {
            int index1 = startpos;
            for (int index2 = 0; index2 < len; ++index2)
            {
                this.savedata_decimal_array[index1] = (int)br.ReadByte();
                ++index1;
            }
            if (type == pspo2seForm.partFileType.inventory)
            {
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    int num = (int)br.ReadByte();
                    this.savedata_decimal_array[index1] = 0;
                    ++index1;
                }
            }
            return true;
        }

        private int loadFileIntoBuffer(
          int startpos,
          string ext_options,
          pspo2seForm.partFileType type,
          bool allowMultiSelect,
          string fn = "")
        {
            List<string> stringList = new List<string>();
            if (this.savedata_decimal_array_filled == 0)
            {
                int num = (int)MessageBox.Show("nothing to load into");
                return -1;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult;
            if (fn != "")
            {
                dialogResult = DialogResult.OK;
                stringList.Add(fn);
            }
            else
            {
                openFileDialog.Title = "PSPo2 Save Editor: Open File";
                if (this.legitVersion())
                    openFileDialog.Title = "PSPo2 Save Viewer: Open File";
                openFileDialog.Filter = ext_options;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;
                if (allowMultiSelect)
                    openFileDialog.Multiselect = true;
                dialogResult = openFileDialog.ShowDialog();
            }
            if (dialogResult != DialogResult.OK)
                return -1;
            if (fn == "")
            {
                for (int index = 0; index < openFileDialog.FileNames.Length; ++index)
                    stringList.Add(openFileDialog.FileNames[index]);
            }
            if (type != pspo2seForm.partFileType.infinity_mission && allowMultiSelect && stringList.Count > 60 - this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed)
            {
                int num = (int)MessageBox.Show("You do not have enough slots to import the selected items.", "Not Enough Slots", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            if (allowMultiSelect && type == pspo2seForm.partFileType.infinity_mission && stringList.Count > 100 - this.saveData.infinityMissions.itemsUsed)
            {
                int num = (int)MessageBox.Show("You do not have enough slots to import the selected items.", "Not Enough Slots", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            foreach (string fileLoc in stringList)
            {
                FileStream fileStream = this.openFileRead(fileLoc);
                if (fileStream == null)
                    return -1;
                BinaryReader br = new BinaryReader((Stream)fileStream);
                int length = (int)br.BaseStream.Length;
                switch (type)
                {
                    case pspo2seForm.partFileType.character:
                        if (!this.validate_character_file_length(length))
                        {
                            int num = (int)MessageBox.Show("File does not appear to be a valid character file");
                            fileStream.Close();
                            return -1;
                        }
                        break;
                    case pspo2seForm.partFileType.inventory:
                        if (length != 2161)
                        {
                            int num = (int)MessageBox.Show("File does not appear to be a valid inventory file");
                            fileStream.Close();
                            return -1;
                        }
                        this.savedata_decimal_array[this.mainSettings.saveStructureIndex.inventory_slots_used_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index] = (int)br.ReadByte();
                        for (int index1 = 0; index1 < 60; ++index1)
                        {
                            int index2 = startpos + index1 * 36;
                            for (int index3 = 0; index3 < 8; ++index3)
                            {
                                int num = (int)br.ReadByte();
                                this.savedata_decimal_array[index2] = 0;
                                ++index2;
                            }
                            this.loadObjectIntoBuffer(br, index2 + index1 * 36, 20, pspo2seForm.partFileType.inventory);
                        }
                        fileStream.Close();
                        return 1;
                    case pspo2seForm.partFileType.storage:
                        if (length != this.mainSettings.saveStructureIndex.shared_inventory_slots * 20)
                        {
                            int num = (int)MessageBox.Show("File does not appear to be a valid storage file");
                            fileStream.Close();
                            return -1;
                        }
                        break;
                    case pspo2seForm.partFileType.item:
                        if (length != 20)
                        {
                            int num = (int)MessageBox.Show("File does not appear to be a valid item file");
                            fileStream.Close();
                            return -1;
                        }
                        if (allowMultiSelect)
                        {
                            startpos = this.getFreeInventoryItemId(this.lstSaveSlotView.SelectedItems[0].Index);
                            if (startpos < 0)
                            {
                                int num = (int)MessageBox.Show("Error: Trying to load an item but there are no available slots");
                                return -1;
                            }
                            this.selectInventoryItemAfterLoad = startpos;
                            this.overwriteHexInBuffer("0000000000000000", startpos + 20);
                            this.overwriteHexInBuffer("00000000", startpos - 8);
                            ++this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed;
                            string hex = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X1");
                            while (hex.Length < 2)
                                hex = "0" + hex;
                            this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.inventory_slots_used_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                            break;
                        }
                        break;
                    case pspo2seForm.partFileType.infinity_mission:
                        if (length != 104)
                        {
                            int num = (int)MessageBox.Show("File does not appear to be a valid infinity mission file");
                            fileStream.Close();
                            return -1;
                        }
                        break;
                    case pspo2seForm.partFileType.infinity_mission_pack:
                        if (length != 10401)
                        {
                            int num = (int)MessageBox.Show("File does not appear to be a valid infinity mission pack file");
                            fileStream.Close();
                            return -1;
                        }
                        break;
                    default:
                        int num1 = (int)MessageBox.Show("file " + (object)type + " is not supported");
                        fileStream.Close();
                        return -1;
                }
                this.loadObjectIntoBuffer(br, startpos, length, type);
                fileStream.Close();
                if (type == pspo2seForm.partFileType.infinity_mission && allowMultiSelect)
                    startpos += 104;
            }
            return stringList.Count;
        }

        private unsafe int adjustPosition(
          int pos,
          BinaryReader br,
          int item_position,
          bool reload,
          string err_identifier,
          bool showSaveParseProgress)
        {
            int num1 = pos;
            if (pos > item_position)
            {
                int num2 = (int)MessageBox.Show("Requested position " + (object)pos + " is greater than the predicted item pos" + (object)item_position);
                return 0;
            }
            while (num1 < item_position)
                this.brSkipBytes(1, &num1, br, reload, showSaveParseProgress);
            return num1;
        }

        private unsafe bool parseSaveFile(string fileLoc, bool reload)
        {
            this.chunkPos = 0;
            FileStream fileStream = (FileStream)null;
            BinaryReader br = (BinaryReader)null;
            if (!reload)
            {
                this.initSaveBuffer();
                this.initSlotVars();
                fileStream = this.openFileRead(fileLoc);
                if (fileStream == null)
                    return false;
                br = new BinaryReader((Stream)fileStream, Encoding.BigEndianUnicode);
                if (!this.validate_filelength(br.BaseStream.Length))
                {
                    fileStream.Close();
                    return false;
                }
                if (this.mainSettings.saveStructureIndex.encrypted)
                {
                    fileStream.Close();
                    if (System.IO.File.Exists("data\\temp\\denc.bin"))
                        System.IO.File.Delete("data\\temp\\denc.bin");
                    if (!this.decryptSaveFile(fileLoc))
                    {
                        int num = (int)MessageBox.Show("There was an error decrypting the save file.");
                        return false;
                    }
                    fileStream = this.openFileRead("data\\temp\\denc.bin");
                    br = new BinaryReader((Stream)fileStream, Encoding.BigEndianUnicode);
                }
                this.saveData.size = (int)br.BaseStream.Length;
            }
            else
            {
                this.initSlotVars();
                this.savedata_decimal_array_read_pos = 0;
                this.saveData.size = this.savedata_decimal_array_filled;
            }
            this.toolStripStatusLabel.Text = "Parsing Save 0%";
            this.toolStripProgressBar.Maximum = this.saveData.size;
            this.toolStripProgressBar.Value = 0;
            int pos = 0;
            this.parseHeaderInfo(br, &pos, reload);
            for (int slot = 0; slot < 8; ++slot)
            {
                if (!this.parseSlotInfo(slot, br, &pos, reload))
                {
                    fileStream?.Close();
                    return false;
                }
            }
            if (!this.parseCharacterSharedStorageSlotsInfo(br, &pos, reload))
            {
                fileStream?.Close();
                return false;
            }
            if (!this.parseInfinityMissionSlotsInfo(br, &pos, reload))
            {
                fileStream?.Close();
                return false;
            }
            int totalSize = this.mainSettings.saveStructureIndex.total_size;
            pos = this.adjustPosition(pos, br, totalSize, reload, "end of file", true);
            fileStream?.Close();
            this.toolStripStatusLabel.Text = "Save File Loaded";
            this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum;
            return true;
        }

        private unsafe bool parseHeaderInfo(BinaryReader br, int* pos, bool reload)
        {
            if (*pos > 0)
            {
                int num = (int)MessageBox.Show("Already scanned past the header", "scan error");
                return false;
            }
            this.brSkipBytes(this.mainSettings.saveStructureIndex.header_size, pos, br, reload, true);
            return true;
        }

        private unsafe bool parseCharacterItemPaletteInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            this.brSkipBytes(24, pos, br, reload, true);
            return true;
        }

        private unsafe bool parseCharacterPADisksLearntCount(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            this.saveData.slot[slot].pa.count = this.brGetInt(1, pos, br, reload, true);
            this.brSkipBytes(10, pos, br, reload, true);
            return true;
        }

        private unsafe void parseCharacterPADiskLearnt(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload,
          int* filled)
        {
            string data = this.brGetData(4, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            if (!(data != "00000000"))
                return;
            this.saveData.slot[slot].pa.items[*filled] = new pspo2seForm.inventoryItemClass();
            this.saveData.slot[slot].pa.items[*filled].hex = data.Substring(0, 6) + "00";
            this.saveData.slot[slot].pa.items[*filled].hex_reversed = this.run.hexAndMathFunction.reversehex(this.saveData.slot[slot].pa.items[*filled].hex, 8);
            string s = data.Substring(6, 2);
            this.saveData.slot[slot].pa.items[*filled].level = "LV" + (object)(int.Parse(s, NumberStyles.HexNumber) + 1);
            this.saveData.slot[slot].pa.items[*filled].id = *filled;
            int* numPtr = filled;
            int num = *numPtr + 1;
            *numPtr = num;
        }

        private unsafe bool parseCharacterPADisksLearnt(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int num = 0;
            for (int index = 0; index < 256; ++index)
            {
                this.saveData.slot[slot].pa.items[index] = new pspo2seForm.inventoryItemClass();
                this.saveData.slot[slot].pa.items[index].hex = "";
                this.saveData.slot[slot].pa.items[index].hex_reversed = "";
            }
            for (int index = 0; index < 136; ++index)
                this.parseCharacterPADiskLearnt(slot, br, pos, reload, &num);
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                for (int index = 0; index < 6; ++index)
                    this.parseCharacterPADiskLearnt(slot, br, pos, reload, &num);
            }
            return true;
        }

        private unsafe bool parseSlotInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            int item_position = this.mainSettings.saveStructureIndex.slots_position + this.mainSettings.saveStructureIndex.slot_size * slot;
            *pos = this.adjustPosition(*pos, br, item_position, reload, "Save Slot " + (object)slot, true);
            if (!this.parseCharacterInfo(slot, br, pos, reload) || !this.parseCharacterTypeLevelInfo(slot, br, pos, reload) || (!this.parseCharacterTypeExtraInfo(slot, br, pos, reload) || !this.parseCharacterRebirthInfo(slot, br, pos, reload)) || (!this.parseCharacterInventoryCountInfo(slot, br, pos, reload) || !this.parseCharacterPADisksLearntCount(slot, br, pos, reload) || (!this.parseCharacterItemPaletteInfo(slot, br, pos, reload) || !this.parseCharacterPADisksLearnt(slot, br, pos, reload))) || (!this.parseCharacterInventorySlotsInfo(slot, br, pos, reload) || !this.parseCharacterStoryInfo(slot, br, pos, reload)))
                return false;
            if (this.saveData.slot[slot].level == 0 || this.saveData.slot[slot].level > 200)
                this.saveData.slot[slot].level = 1;
            if (this.saveData.slot[slot].level == 200)
            {
                this.saveData.slot[slot].exp_next = 0;
                this.saveData.slot[slot].exp_percent = 100;
            }
            else
            {
                pspo2seForm.expDb_ItemClass expDbItemClass = new pspo2seForm.expDb_ItemClass();
                pspo2seForm.expDb_ItemClass expLevelInfoInDb = this.findExpLevelInfoInDb(this.saveData.slot[slot].level);
                if (expLevelInfoInDb == null)
                {
                    int num = (int)MessageBox.Show("could not find exp for level " + (object)this.saveData.slot[slot].level);
                }
                this.saveData.slot[slot].exp_next = expLevelInfoInDb.exp + expLevelInfoInDb.exp_next - this.saveData.slot[slot].exp;
                this.saveData.slot[slot].exp_percent = this.run.hexAndMathFunction.getPercentage(this.saveData.slot[slot].exp - expLevelInfoInDb.exp, expLevelInfoInDb.exp_next);
            }
            ListViewItem listViewItem;
            if (this.saveData.slot[slot].name == "---- Free Slot ----")
            {
                listViewItem = new ListViewItem(this.saveData.slot[slot].name, 2);
            }
            else
            {
                listViewItem = new ListViewItem(this.saveData.slot[slot].name, (int)this.saveData.slot[slot].sex);
                listViewItem.SubItems.Add("LV" + (object)this.saveData.slot[slot].level);
                listViewItem.SubItems.Add(string.Concat((object)this.saveData.slot[slot].race));
                listViewItem.SubItems.Add(string.Concat((object)this.saveData.slot[slot].cur_type));
                listViewItem.SubItems.Add(this.storyCompleteToText(this.saveData.slot[slot].story_ep_1_complete, this.saveData.slot[slot].story_ep_2_complete) ?? "");
            }
            this.lstSaveSlotView.Items.Add(listViewItem);
            return true;
        }

        private unsafe bool parseCharacterInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            this.saveData.slot[slot].rebirth = new pspo2seForm.rebirthType();
            int item_position = this.mainSettings.saveStructureIndex.slots_position + this.mainSettings.saveStructureIndex.slot_size * slot;
            *pos = this.adjustPosition(*pos, br, item_position, reload, "Character info " + (object)slot, true);
            this.saveData.slot[slot].used = true;
            this.saveData.slot[slot].name = "";
            for (int index = 0; index < 32; ++index)
            {
                uint num = uint.Parse(this.run.hexAndMathFunction.reversehex(this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), 4), NumberStyles.HexNumber);
                this.saveData.slot[slot].name += Encoding.UTF32.GetString(BitConverter.GetBytes(num));
            }
            if (this.saveData.slot[slot].name.Substring(0, 10) == "イーサン・ウェーバー")
            {
                this.saveData.slot[slot].name = "---- Free Slot ----";
                this.saveData.slot[slot].used = false;
                return true;
            }
            this.saveData.slot[slot].title = "";
            for (int index = 0; index < 32; ++index)
            {
                uint num = uint.Parse(this.run.hexAndMathFunction.reversehex(this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), 4), NumberStyles.HexNumber);
                this.saveData.slot[slot].title += Encoding.UTF32.GetString(BitConverter.GetBytes(num));
            }
            this.saveData.slot[slot].race = (pspo2seForm.raceTypes)this.brGetInt(1, pos, br, reload, true);
            this.saveData.slot[slot].sex = (pspo2seForm.sexType)this.brGetInt(1, pos, br, reload, true);
            this.saveData.slot[slot].cur_type = (pspo2seForm.jobType)this.brGetInt(1, pos, br, reload, true);
            this.brSkipBytes(101, pos, br, reload, true);
            this.saveData.slot[slot].level = this.brGetInt(2, pos, br, reload, true);
            this.brSkipBytes(6, pos, br, reload, true);
            this.saveData.slot[slot].exp = this.brGetInt32(pos, br, reload, true);
            this.saveData.slot[slot].meseta = (long)this.brGetInt32(pos, br, reload, true);
            int num1 = this.brGetInt(4, pos, br, reload, true);
            int num2 = num1 / 3600;
            int num3 = num1 - num2 * 3600;
            int num4 = num3 / 60;
            int num5 = num3 - num4 * 60;
            this.saveData.slot[slot].playtime = this.intTo2digitString(num2, 2) + ":" + this.intTo2digitString(num4, 2) + ":" + this.intTo2digitString(num5, 2);
            this.brSkipBytes(31, pos, br, reload, true);
            this.saveData.slot[slot].rebirth.additionalTypeLevels = this.brGetInt(1, pos, br, reload, true);
            return true;
        }

        private unsafe void parseTypeInfo(int slot, int job, int* pos, BinaryReader br, bool reload)
        {
            this.saveData.slot[slot].job[job].job = (pspo2seForm.jobType)job;
            this.saveData.slot[slot].job[job].level = this.brGetInt(1, pos, br, reload, true);
            this.saveData.slot[slot].job[job].scramble_exp = this.brGetInt(1, pos, br, reload, true);
            if (this.saveData.slot[slot].job[job].scramble_exp == 1)
            {
                string s = this.run.hexAndMathFunction.reversehex(this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), 4);
                this.saveData.slot[slot].job[job].exp = int.Parse(s, NumberStyles.HexNumber) + 65536;
            }
            else
                this.saveData.slot[slot].job[job].exp = this.brGetInt(2, pos, br, reload, true);
        }

        private unsafe bool parseCharacterTypeLevelInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int item_position = this.mainSettings.saveStructureIndex.type_level_pos + this.mainSettings.saveStructureIndex.slot_size * slot;
            *pos = this.adjustPosition(*pos, br, item_position, reload, "parseCharacterTypeLevelInfo slot " + (object)slot, true);
            this.parseTypeInfo(slot, 0, pos, br, reload);
            this.parseTypeInfo(slot, 1, pos, br, reload);
            this.parseTypeInfo(slot, 2, pos, br, reload);
            this.parseTypeInfo(slot, 3, pos, br, reload);
            return true;
        }

        private unsafe bool parseCharacterRebirthInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            if (this.saveData.type == pspo2seForm.SaveType.PSP2)
            {
                this.brSkipBytes(2, pos, br, reload, true);
                return true;
            }
            for (int index = 0; index < 12; ++index)
            {
                string s = this.run.hexAndMathFunction.reversehex(this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), 4);
                switch (index)
                {
                    case 0:
                        this.saveData.slot[slot].rebirth.count = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 1:
                        this.saveData.slot[slot].rebirth.remaining_points = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 2:
                        this.saveData.slot[slot].rebirth.atk = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 3:
                        this.saveData.slot[slot].rebirth.def = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 4:
                        this.saveData.slot[slot].rebirth.acc = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 5:
                        this.saveData.slot[slot].rebirth.eva = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 6:
                        this.saveData.slot[slot].rebirth.sta = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 8:
                        this.saveData.slot[slot].rebirth.tec = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 9:
                        this.saveData.slot[slot].rebirth.mnd = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 10:
                        this.saveData.slot[slot].rebirth.hp = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 11:
                        this.saveData.slot[slot].rebirth.pp = int.Parse(s, NumberStyles.HexNumber);
                        break;
                }
            }
            return true;
        }

        private unsafe bool parseCharacterStoryInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            int item_position1 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * slot + 3182;
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
                item_position1 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * slot + 3242;
            *pos = this.adjustPosition(*pos, br, item_position1, reload, "parseCharacterStoryInfo slot " + (object)slot, true);
            string data1 = this.brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            this.saveData.slot[slot].mission_unlock_magashi = false;
            if (data1 == "1F")
                this.saveData.slot[slot].mission_unlock_magashi = true;
            int item_position2 = this.mainSettings.saveStructureIndex.story_info_pos + this.mainSettings.saveStructureIndex.slot_size * slot;
            *pos = this.adjustPosition(*pos, br, item_position2, reload, "parseCharacterStoryInfo slot " + (object)slot, true);
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
                this.saveData.slot[slot].story_ep_2_points = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            this.brSkipBytes(158, pos, br, reload, true);
            this.saveData.slot[slot].mission_unlock_ep1 = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true) == "204E";
            this.brSkipBytes(34, pos, br, reload, true);
            this.saveData.slot[slot].story_ep_1_points = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            this.brSkipBytes(14, pos, br, reload, true);
            this.saveData.slot[slot].mission_unlock_unknown = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true) == "204E";
            this.brSkipBytes(50, pos, br, reload, true);
            this.saveData.slot[slot].story_ep_1_act = this.run.hexAndMathFunction.hexToInt(this.brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true));
            this.brSkipBytes(7, pos, br, reload, true);
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                this.saveData.slot[slot].mission_unlock_ep2 = this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true) == "204E";
                this.brSkipBytes(891, pos, br, reload, true);
            }
            else
                this.brSkipBytes(893, pos, br, reload, true);
            this.saveData.slot[slot].allow_quit_missions = this.brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            this.brSkipBytes(4, pos, br, reload, true);
            this.brSkipBytes(32, pos, br, reload, true);
            this.brSkipBytes(10, pos, br, reload, true);
            this.brSkipBytes(32, pos, br, reload, true);
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
                this.brSkipBytes(52, pos, br, reload, true);
            else
                this.brSkipBytes(940, pos, br, reload, true);
            string data2 = this.brGetData(3, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            this.saveData.slot[slot].skip_ep_1_start = false;
            if (data2 == "90AB1E")
                this.saveData.slot[slot].skip_ep_1_start = true;
            if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                this.brSkipBytes(33, pos, br, reload, true);
                string data3 = this.brGetData(3, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                this.saveData.slot[slot].skip_ep_2_start = false;
                if (data3 == "78AF1E")
                    this.saveData.slot[slot].skip_ep_2_start = true;
                this.brSkipBytes(17710, pos, br, reload, true);
            }
            else
                this.brSkipBytes(17714, pos, br, reload, true);
            string data4 = this.brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            int num = 0;
            try
            {
                num = int.Parse(data4.Substring(1, 1));
            }
            catch
            {
            }
            this.saveData.slot[slot].story_ep_1_complete = false;
            this.saveData.slot[slot].story_ep_2_complete = false;
            if (num == 1 || num == 3)
                this.saveData.slot[slot].story_ep_1_complete = true;
            if (num == 2 || num == 3)
                this.saveData.slot[slot].story_ep_2_complete = true;
            return true;
        }

        private unsafe bool parseCharacterTypeExtraInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int item_position1 = this.mainSettings.saveStructureIndex.type_level_pos + this.mainSettings.saveStructureIndex.slot_size * slot + 16;
            *pos = this.adjustPosition(*pos, br, item_position1, reload, "parseCharacterTypeExtraInfo slot " + (object)slot, true);
            for (int index = 0; index < 4; ++index)
            {
                int item_position2 = this.mainSettings.saveStructureIndex.type_level_pos + this.mainSettings.saveStructureIndex.slot_size * slot + 16 + index * this.mainSettings.saveStructureIndex.type_extend_size;
                *pos = this.adjustPosition(*pos, br, item_position2, (reload ? 1 : 0) != 0, "parseCharacterTypeExtraInfo slot " + (object)slot + " job " + (object)index, true);
                this.saveData.slot[slot].job[index].extendpoints = this.brGetInt(2, pos, br, reload, true);
                this.saveData.slot[slot].job[index].extendpointsused = this.brGetInt(2, pos, br, reload, true);
                this.saveData.slot[slot].job[index].attachedAbilities = this.brGetData(10, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                if (this.saveData.type == pspo2seForm.SaveType.PSP2I)
                    this.saveData.slot[slot].job[index].attachedAbilities += this.brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            }
            string str = this.run.hexAndMathFunction.halfByteSwap(this.brGetData(58, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true));
            int index1 = 0;
            int index2 = 0;
            for (int startIndex = 0; startIndex < str.Length && index1 < 4; ++startIndex)
            {
                this.saveData.slot[slot].job[index1].weapons_extended[index2] = (pspo2seForm.extendRankType)int.Parse(str.Substring(startIndex, 1));
                ++index2;
                if (index2 > 28)
                {
                    index2 = 0;
                    ++index1;
                }
            }
            return true;
        }

        private unsafe bool parseCharacterInventoryCountInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int item_position = this.mainSettings.saveStructureIndex.inventory_slots_used_pos + this.mainSettings.saveStructureIndex.slot_size * slot;
            *pos = this.adjustPosition(*pos, br, item_position, reload, "parseCharacterInventoryCountInfo slot " + (object)slot, true);
            this.saveData.slot[slot].inventory.itemsUsed = this.brGetInt(1, pos, br, reload, true);
            return true;
        }

        private unsafe bool parseCharacterInventorySlotsInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int item_position = this.mainSettings.saveStructureIndex.inventory_slots_pos + this.mainSettings.saveStructureIndex.slot_size * slot;
            *pos = this.adjustPosition(*pos, br, item_position, reload, "parseCharacterInventoryCountInfo slot " + (object)slot, true);
            for (int index = 0; index < 60; ++index)
            {
                string data = this.brGetData(8, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                string s1 = data.Substring(8, 2);
                string str = data.Substring(2, 2);
                string s2 = data.Substring(0, 2);
                this.saveData.slot[slot].inventory.item[index] = this.brGetItem(pos, br, reload);
                this.saveData.slot[slot].inventory.item[index].data_id = int.Parse(s1, NumberStyles.HexNumber);
                this.saveData.slot[slot].inventory.item[index].equipped_now = int.Parse(s2, NumberStyles.HexNumber);
                this.saveData.slot[slot].inventory.item[index].equipped_slot = int.Parse(str) == 0 ? 0 : this.run.hexAndMathFunction.hex2binary(str).Length;
                if (index >= this.saveData.slot[slot].inventory.itemsUsed)
                {
                    this.saveData.slot[slot].inventory.item[index].hex = "FFFFFFFF";
                    this.saveData.slot[slot].inventory.item[index].hex_reversed = "FFFFFFFF";
                    this.saveData.slot[slot].inventory.item[index].type = pspo2seForm.itemType.free_slot;
                    this.saveData.slot[slot].inventory.item[index].used = false;
                    this.brSkipBytes(8, pos, br, reload, true);
                }
                else
                    this.brSkipBytes(8, pos, br, reload, true);
            }
            return true;
        }

        private unsafe bool parseCharacterSharedStorageSlotsInfo(
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int sharedInventoryPos = this.mainSettings.saveStructureIndex.shared_inventory_pos;
            *pos = this.adjustPosition(*pos, br, sharedInventoryPos, reload, nameof(parseCharacterSharedStorageSlotsInfo), true);
            this.saveData.sharedInventory.itemsUsed = 0;
            for (int index = 0; index < this.mainSettings.saveStructureIndex.shared_inventory_slots; ++index)
                this.saveData.sharedInventory.item[index] = this.brGetItem(pos, br, reload);
            this.saveData.sharedMeseta = (long)this.brGetInt32(pos, br, reload, true);
            return true;
        }

        private unsafe bool parseInfinityMissionSlotsInfo(BinaryReader br, int* pos, bool reload)
        {
            if (this.saveData.type == pspo2seForm.SaveType.PSP2)
                return true;
            int infinityMissionPos = this.mainSettings.saveStructureIndex.infinity_mission_pos;
            *pos = this.adjustPosition(*pos, br, infinityMissionPos, reload, nameof(parseInfinityMissionSlotsInfo), true);
            this.saveData.infinityMissions.itemsUsed = 0;
            for (int index1 = 0; index1 < 100; ++index1)
            {
                this.saveData.infinityMissions.slot[index1] = new pspo2seForm.infinityMissionClass();
                string data = this.brGetData(104, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                this.saveData.infinityMissions.slot[index1].hex = data;
                this.saveData.infinityMissions.slot[index1].id = index1;
                this.saveData.infinityMissions.slot[index1].area = int.Parse(data.Substring(1, 1), NumberStyles.HexNumber);
                int num1 = int.Parse(data.Substring(3, 1) + data.Substring(0, 1), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].length = 0;
                for (; num1 >= 64; num1 -= 64)
                    ++this.saveData.infinityMissions.slot[index1].length;
                this.saveData.infinityMissions.slot[index1].boss = num1;
                this.saveData.infinityMissions.slot[index1].enemy_2 = int.Parse(data.Substring(7, 1), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].enemy_table_1 = int.Parse(data.Substring(2, 1), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].unk_enemy_table_1_mod = false;
                if (this.saveData.infinityMissions.slot[index1].enemy_table_1 >= 8)
                {
                    this.saveData.infinityMissions.slot[index1].enemy_table_1 -= 8;
                    this.saveData.infinityMissions.slot[index1].unk_enemy_table_1_mod = true;
                }
                this.saveData.infinityMissions.slot[index1].unk_table_2_mod = int.Parse(data.Substring(5, 1), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].unk_table_2_unk_mod = 0;
                while (this.saveData.infinityMissions.slot[index1].unk_table_2_mod >= 4)
                {
                    this.saveData.infinityMissions.slot[index1].unk_table_2_mod -= 4;
                    ++this.saveData.infinityMissions.slot[index1].unk_table_2_unk_mod;
                }
                this.saveData.infinityMissions.slot[index1].area_1_map = int.Parse(data.Substring(6, 1), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].area_2_map = int.Parse(data.Substring(9, 1), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].area_3_map = int.Parse(data.Substring(8, 1), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].enemy_level = int.Parse(data.Substring(10, 2), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].unk_enemy_level_mod = 0;
                while (this.saveData.infinityMissions.slot[index1].enemy_level >= 64)
                {
                    this.saveData.infinityMissions.slot[index1].enemy_level -= 64;
                    ++this.saveData.infinityMissions.slot[index1].unk_enemy_level_mod;
                }
                int num2 = (int)Math.Floor((double)int.Parse(data.Substring(4, 1), NumberStyles.HexNumber) / 2.0);
                this.saveData.infinityMissions.slot[index1].enemy_1 = num2;
                int num3 = (int)Math.Ceiling((double)int.Parse(data.Substring(4, 1), NumberStyles.HexNumber) / 2.0);
                this.saveData.infinityMissions.slot[index1].unk_enemy_1_mod = num3 - this.saveData.infinityMissions.slot[index1].enemy_1;
                this.saveData.infinityMissions.slot[index1].createdBy = "";
                for (int index2 = 0; index2 < 32; ++index2)
                {
                    uint num4 = uint.Parse(this.run.hexAndMathFunction.reversehex(data.Substring(index2 * 4 + 32, 4), 4), NumberStyles.HexNumber);
                    this.saveData.infinityMissions.slot[index1].createdBy += Encoding.UTF32.GetString(BitConverter.GetBytes(num4));
                }
                this.saveData.infinityMissions.slot[index1].mergePoints = int.Parse(data.Substring(184, 2), NumberStyles.HexNumber);
                if (int.Parse(data.Substring(186, 2), NumberStyles.HexNumber) >= 128)
                    this.saveData.infinityMissions.slot[index1].mergePoints += (int.Parse(data.Substring(186, 2), NumberStyles.HexNumber) - 128) * 256;
                else if (int.Parse(data.Substring(186, 2), NumberStyles.HexNumber) < 128)
                    this.saveData.infinityMissions.slot[index1].mergePoints += int.Parse(data.Substring(187, 1), NumberStyles.HexNumber) * 256;
                this.saveData.infinityMissions.slot[index1].clearCount_c = int.Parse(this.run.hexAndMathFunction.reversehex(data.Substring(188, 4), 4), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].clearCount_b = int.Parse(this.run.hexAndMathFunction.reversehex(data.Substring(192, 4), 4), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].clearCount_a = int.Parse(this.run.hexAndMathFunction.reversehex(data.Substring(196, 4), 4), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].clearCount_s = int.Parse(this.run.hexAndMathFunction.reversehex(data.Substring(200, 4), 4), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].clearCount_inf = int.Parse(this.run.hexAndMathFunction.reversehex(data.Substring(204, 4), 4), NumberStyles.HexNumber);
                this.saveData.infinityMissions.slot[index1].level = this.saveData.infinityMissions.slot[index1].enemy_table_1 + this.saveData.infinityMissions.slot[index1].enemy_level / 10;
                if (this.saveData.infinityMissions.slot[index1].unk_enemy_table_1_mod)
                    ++this.saveData.infinityMissions.slot[index1].level;
                if (this.saveData.infinityMissions.slot[index1].length > 2)
                    this.saveData.infinityMissions.slot[index1].level += 10;
            }
            this.saveData.infinityMissions.itemsUsed = int.Parse(this.brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), NumberStyles.HexNumber);
            return true;
        }

        private class imageFloatBox
        {
            public Point pnlloc = new Point();
            public Point grploc = new Point();
            public PictureBox picBox = new PictureBox();
            public FileInfo[] imagelist = new FileInfo[1500];
            public int filled;
        }

        public class typeWeaponRankFields
        {
            public PictureBox[] imgWeap = new PictureBox[29];
            public PictureBox[] imgRank = new PictureBox[29];
        }

        public class pageFields
        {
            public PictureBox img_rank;
            public PictureBox img_item;
            public PictureBox img_manufaturer;
            public PictureBox img_infinity_item;
            public PictureBox img_element;
            public PictureBox img_star_0;
            public PictureBox img_star_1;
            public PictureBox img_star_2;
            public PictureBox img_star_3;
            public PictureBox img_star_4;
            public PictureBox img_star_5;
            public PictureBox img_star_6;
            public PictureBox img_star_7;
            public PictureBox img_star_8;
            public PictureBox img_star_9;
            public PictureBox img_star_10;
            public PictureBox img_star_11;
            public PictureBox img_star_12;
            public PictureBox img_star_13;
            public PictureBox img_star_14;
            public PictureBox img_star_15;
            public Label txt_infinity_item;
            public Label txt_name;
            public Label txt_name_jp;
            public Label txt_grinds;
            public Label txt_percent;
            public Label txt_qty;
            public Label txt_hex;
            public Label txt_meseta;
            public Label txt_special;
            public Label txt_effect;
            public Label txt_atk;
            public Label txt_acc;
            public Label txt_level;
            public Button btn_delete;
            public Button btn_export_selected;
            public Button btn_import_selected;
            public CheckBox chk_delete_export;
            public Button btn_withdraw;
            public GroupBox grp_details;
            public Panel pnl_details;
        }

        public class typeSectionFields
        {
            public Label txtLevel;
            public Label txtExp;
            public Label expBar;
            public GroupBox grpExtend;
        }

        public class expDb_ItemClass
        {
            public int level;
            public int exp;
            public int exp_next;
            public int extend_points;
        }

        public class expDbType
        {
            public pspo2seForm.expDb_ItemClass[] level = new pspo2seForm.expDb_ItemClass[355];
        }

        public class typeexpDbType
        {
            public pspo2seForm.expDb_ItemClass[] level = new pspo2seForm.expDb_ItemClass[55];
        }

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }

        public enum SaveType
        {
            NONE,
            PSP2,
            PSP2I,
        }

        public enum extendRankType
        {
            none,
            c,
            b,
            a,
            s,
        }

        public class saveSlotType
        {
            public bool used;
            public string name = "";
            public string title = "";
            public string playtime = "";
            public pspo2seForm.raceTypes race;
            public pspo2seForm.sexType sex;
            public pspo2seForm.jobType cur_type;
            public int level;
            public int exp;
            public int exp_next;
            public int exp_percent;
            public long meseta;
            public bool mission_unlock_magashi;
            public bool mission_unlock_ep1;
            public bool mission_unlock_unknown;
            public bool mission_unlock_ep2;
            public bool story_ep_1_complete;
            public bool story_ep_2_complete;
            public bool skip_ep_1_start;
            public bool skip_ep_2_start;
            public string allow_quit_missions;
            public int story_ep_1_act;
            public string story_ep_1_points;
            public string story_ep_1_best_end;
            public string story_ep_2_points;
            public pspo2seForm.paInfoType pa = new pspo2seForm.paInfoType();
            public pspo2seForm.rebirthType rebirth = new pspo2seForm.rebirthType();
            public pspo2seForm.jobClass[] job = new pspo2seForm.jobClass[4];
            public pspo2seForm.inventoryClass inventory = new pspo2seForm.inventoryClass();
        }

        public enum raceTypes
        {
            Human,
            Newman,
            Cast,
            Beast,
            Duman,
            None,
        }

        public enum jobType
        {
            Hunter,
            Ranger,
            Force,
            Vanguard,
            None,
        }

        public enum sexType
        {
            Male,
            Female,
            None,
        }

        public class jobClass
        {
            public int level;
            public int exp;
            public int exp_to_next;
            public int exp_next;
            public int scramble_exp;
            public int exp_percent;
            public int extendpoints;
            public int extendpointsused;
            public string attachedAbilities;
            public pspo2seForm.jobType job;
            public pspo2seForm.extendRankType[] weapons_extended = new pspo2seForm.extendRankType[29];
        }

        public class rebirthType
        {
            public int count;
            public int remaining_points;
            public int hp;
            public int pp;
            public int atk;
            public int def;
            public int acc;
            public int eva;
            public int tec;
            public int mnd;
            public int sta;
            public int additionalTypeLevels;
        }

        public class paInfoType
        {
            public int count;
            public pspo2seForm.inventoryItemClass[] items = new pspo2seForm.inventoryItemClass[256];
        }

        public class infinityMissionClass : IComparable
        {
            public bool used;
            public int id;
            public string hex;
            public string createdBy;
            public int enemy_1;
            public int enemy_2;
            public int enemy_level;
            public int unk_enemy_level_mod;
            public int boss;
            public int length;
            public int unk_enemy_1_mod;
            public int area;
            public int special;
            public int element;
            public int level;
            public int enemy_table_1;
            public bool unk_enemy_table_1_mod;
            public int unk_table_2_mod;
            public int unk_table_2_unk_mod;
            public int area_1_map;
            public int area_2_map;
            public int area_3_map;
            public int mergePoints;
            public int clearCount_c;
            public int clearCount_b;
            public int clearCount_a;
            public int clearCount_s;
            public int clearCount_inf;

            public int CompareTo(object obj) => obj is pspo2seForm.infinityMissionClass ? this.hex.CompareTo(((pspo2seForm.infinityMissionClass)obj).hex) : throw new ArgumentException("Object is not of type infinityMissionClass.");
        }

        public class infinityMissionSlotsClass
        {
            public int itemsUsed;
            public pspo2seForm.infinityMissionClass[] slot = new pspo2seForm.infinityMissionClass[100];
        }

        public class saveDataType
        {
            public pspo2seForm.SaveType type;
            public pspo2seForm.saveSlotType[] slot = new pspo2seForm.saveSlotType[8];
            public int size;
            public pspo2seForm.inventorySharedClass sharedInventory = new pspo2seForm.inventorySharedClass();
            public pspo2seForm.infinityMissionSlotsClass infinityMissions = new pspo2seForm.infinityMissionSlotsClass();
            public long sharedMeseta;

            public void set_type(pspo2seForm.SaveType new_type) => this.type = new_type;
        }

        public enum saveInfoDataType
        {
            str,
            hex,
        }

        public class updateCSVInfo
        {
            public string fn;
            public string ver;
        }

        public enum elementType
        {
            Neutral,
            Fire,
            Ice,
            Thunder,
            Earth,
            Light,
            Dark,
            COUNT,
        }

        public enum itemType
        {
            nothing,
            Weapon,
            Armor,
            Green_Item,
            PA_Disk_Melee,
            PA_Disk_Ranged,
            PA_Disk_Technique,
            Infinity_Code,
            Slot_Unit,
            Clothes_human,
            Clothes_android,
            Room_Decoration,
            Trap,
            unknown_5,
            My_Synth_Device,
            Extend_Code,
            free_slot,
        }

        public enum weaponType
        {
            nothing,
            sword,
            knuckle,
            spear,
            double_saber,
            axe,
            sabers,
            daggers,
            claws,
            saber,
            dagger,
            claw,
            whip,
            slicer,
            rifle,
            shotgun,
            longbow,
            grenade,
            laser,
            handguns,
            handgun,
            crossbow,
            card,
            machinegun,
            rod,
            wand,
            tmag,
            rmag,
            shield,
            armor,
        }

        public enum partsTypes
        {
            unknown_0,
            torso,
            legs,
            arms,
            unknown_4,
            unknown_5,
            set,
        }

        public enum clothesTypes
        {
            unknown_0,
            top,
            bottom,
            shoes,
            top_set,
            bottom_set,
            set,
        }

        public enum slotType
        {
            unit,
            mirage,
            suv,
            visual,
        }

        public enum itemRankType
        {
            c,
            b,
            a,
            s,
            unknown,
        }

        public enum itemExtendType
        {
            not_extended,
            extended,
            dlc_not_extended,
            dlc_extended,
            not_extended_cs1,
            not_extended_cs2,
            extended_cs1,
            extended_cs2,
            unknown,
        }

        public enum weaponManufacturerType
        {
            GRM,
            Yohmei,
            Tenora_Works,
            Kubara,
        }

        public enum clothesManufacturerType
        {
            Kubara,
            Roar,
            Cubic,
            Miyab,
        }

        public enum weaponStyleType
        {
            Melee,
            Ranged_long,
            Ranged_short,
            Tech,
        }

        public enum weaponHandType
        {
            both,
            right,
            left,
        }

        public enum greenItemType
        {
            monomate,
            dimate,
            trimate,
            star_atom,
            sol_atom,
            moon_atom,
            doll,
            shiftaride,
            debanride,
            calorie,
            item,
            none,
        }

        public class itemDb_ItemClass
        {
            public string id;
            public string hex;
            public string name;
            public string name_jp;
            public string desc;
            public string desc_jp;
            public string infinity_item;
            public int power;
            public int acc;
            public string level;
            public int ext_power;
            public int ext_acc;
            public string ext_level;
            public int inf_ext_power;
            public int inf_ext_acc;
            public string inf_ext_level;
            public string special;
            public string special_level;
            public string ext_special_level;
            public int rarity;
        }

        public class itemDbClass
        {
            public pspo2seForm.itemDb_ItemClass[] item = new pspo2seForm.itemDb_ItemClass[4000];
        }

        public enum abilityType
        {
            None,
            Burn,
            Poison,
            Infection,
            Silence,
            Shock,
            Freeze,
            Sleep,
            Stun,
            Confusion,
            Taunt,
            Incapacitate,
            Drain,
            Damage_reflect,
            HP_affects_pwr,
            AutoDamage,
            AutoDefend,
            AttackUp,
            AttackDown,
            DefenseUp,
            DefenseDown,
            Empow_none,
            Empow_fire,
            Empow_ice,
            Empow_lightning,
            Empow_earth,
            Empow_light,
            Empow_dark,
            Empow_healing,
        }

        public enum itemInfExtendType
        {
            not_extended,
            unknown_1,
            unknown_2,
            unknown_3,
            extended,
            unknown_5,
            unknown_6,
            unknown_7,
            not_extended_special,
            unknown_9,
            unknown_10,
            unknown_11,
            extended_special,
        }

        public enum equippedType
        {
            not_equipped,
            equipped,
            equipped_in_use,
        }

        public class inventoryItemClass : IComparable
        {
            public bool used;
            public int id;
            public pspo2seForm.itemType type;
            public string name;
            public string name_jp;
            public string desc;
            public string desc_jp;
            public string infinity_item;
            public string hex;
            public string hex_reversed;
            public pspo2seForm.abilityType ability;
            public string spcl_effect;
            public string spcl_effect_info;
            public pspo2seForm.itemInfExtendType inf_extended;
            public int grinds;
            public int extended;
            public bool locked;
            public int rarity;
            public pspo2seForm.elementType element;
            public int pa_level;
            public int percent;
            public pspo2seForm.weaponStyleType style;
            public pspo2seForm.weaponHandType hand;
            public pspo2seForm.clothesManufacturerType clothes_man;
            public int qty;
            public int qty_max;
            public int power_add;
            public int data_id;
            public int equipped_slot;
            public int equipped_now;
            public int power;
            public int acc;
            public string level;
            public int ext_power;
            public int ext_acc;
            public string ext_level;
            public int inf_ext_power;
            public int inf_ext_acc;
            public string inf_ext_level;
            public string special;
            public string special_level;
            public string ext_special_level;

            public int CompareTo(object obj) => obj is pspo2seForm.inventoryItemClass ? this.hex.CompareTo(((pspo2seForm.inventoryItemClass)obj).hex) : throw new ArgumentException("Object is not of type inventoryItemClass.");
        }

        public class inventoryClass
        {
            public int itemsUsed;
            public pspo2seForm.inventoryItemClass[] item = new pspo2seForm.inventoryItemClass[60];
        }

        public class inventorySharedClass
        {
            public int itemsUsed;
            public pspo2seForm.inventoryItemClass[] item = new pspo2seForm.inventoryItemClass[2000];
        }

        public enum partFileType
        {
            character,
            inventory,
            storage,
            item,
            infinity_mission,
            infinity_mission_pack,
        }
    }
}
