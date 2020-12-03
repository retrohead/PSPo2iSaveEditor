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
            imageFloater.filled = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (string str in IMAGE_FLOAT_FILE_EXT)
            {
                foreach (FileInfo file in directoryInfo.GetFiles("*." + str))
                {
                    imageFloater.imagelist[imageFloater.filled] = file;
                    ++imageFloater.filled;
                }
            }
        }

        private void initImageFloater()
        {
            imageFloat_Y_visible = panelImageFloater.Location.Y;
            imageFloat_Y_hidden = panelImageFloater.Location.Y - 130;
            imageFloater.pnlloc.X = panelImageFloater.Location.X;
            imageFloater.pnlloc.Y = imageFloat_Y_hidden;
            imageFloater.grploc.X = grpImageFloater.Location.X;
            imageFloater.grploc.Y = imageFloat_Y_hidden - 6;
            panelImageFloater.Location = imageFloater.pnlloc;
            grpImageFloater.Location = imageFloater.grploc;
            imageFloater.picBox = imgFloater;
            loadImageFloaterImages();
        }

        private void makeImageFloaterHidden()
        {
            Application.DoEvents();
            while (imageFloater.pnlloc.Y > imageFloat_Y_hidden)
            {
                imageFloater.pnlloc.Y -= 3;
                if (imageFloater.pnlloc.Y < imageFloat_Y_hidden)
                    imageFloater.pnlloc.Y = imageFloat_Y_hidden;
                imageFloater.grploc.Y = imageFloater.pnlloc.Y - 6;
                panelImageFloater.Location = imageFloater.pnlloc;
                grpImageFloater.Location = imageFloater.grploc;
                Application.DoEvents();
            }
            imageFloatShowing = false;
            allowImageFloatMove = true;
            inventoryViewPages.Enabled = true;
            storageViewPages.Enabled = true;
            tabArea.Enabled = true;
        }

        private void makeImageFloaterVisible()
        {
            Application.DoEvents();
            while (imageFloater.pnlloc.Y < imageFloat_Y_visible)
            {
                imageFloater.pnlloc.Y += 3;
                if (imageFloater.pnlloc.Y > imageFloat_Y_visible)
                    imageFloater.pnlloc.Y = imageFloat_Y_visible;
                imageFloater.grploc.Y = imageFloater.pnlloc.Y - 6;
                panelImageFloater.Location = imageFloater.pnlloc;
                grpImageFloater.Location = imageFloater.grploc;
                Application.DoEvents();
            }
            imageFloatShowing = true;
            allowImageFloatMove = true;
            inventoryViewPages.Enabled = true;
            storageViewPages.Enabled = true;
            tabArea.Enabled = true;
        }

        private void moveImageFloater()
        {
            allowImageFloatMove = false;
            tabArea.Enabled = false;
            if (imageFloatShowing)
                makeImageFloaterHidden();
            else
                makeImageFloaterVisible();
        }

        private void openImageFloater()
        {
            if (!imageFloaterClosed() || !imageFloatImageIsOk || tabArea.SelectedTab != tabPageInventory && tabArea.SelectedTab != tabPageStorage || inventoryViewPages.SelectedIndex != 0 && storageViewPages.SelectedIndex != 0)
                return;
            moveImageFloater();
        }

        private void closeImageFloater()
        {
            if (!imageFloaterOpen())
                return;
            moveImageFloater();
        }

        private bool imageFloaterOpen() => imageFloatShowing || !allowImageFloatMove;

        private bool imageFloaterClosed() => !imageFloatShowing || !allowImageFloatMove;

        public string findImageFloatInList(string hex)
        {
            for (int index = 0; index < imageFloater.filled; ++index)
            {
                if (hex.ToLower() == imageFloater.imagelist[index].Name.Substring(0, 8).ToLower())
                {
                    imageFloatImageIsOk = true;
                    return imageFloater.imagelist[index].FullName;
                }
            }
            imageFloatImageIsOk = false;
            return "";
        }

        private void changeImageFloater(string hex)
        {
            string imageFloatInList = findImageFloatInList(hex);
            if (imageFloatImageIsOk)
            {
                imageFloater.picBox.Image = (Image)new Bitmap(imageFloatInList);
                openImageFloater();
            }
            else
                closeImageFloater();
        }

        public pspo2seForm.typeSectionFields getTypeSectionFields(TabPage page)
        {
            pspo2seForm.typeSectionFields typeSectionFields = new pspo2seForm.typeSectionFields();
            if (page == tabPageHunter)
            {
                typeSectionFields.txtLevel = txtHuLevel;
                typeSectionFields.txtExp = txtHuExp;
                typeSectionFields.expBar = txtHuExpBar;
                typeSectionFields.grpExtend = grpHuTypeExtend;
            }
            else if (page == tabPageRanger)
            {
                typeSectionFields.txtLevel = txtRaLevel;
                typeSectionFields.txtExp = txtRaExp;
                typeSectionFields.expBar = txtRaExpBar;
                typeSectionFields.grpExtend = grpRaTypeExtend;
            }
            else if (page == tabPageForce)
            {
                typeSectionFields.txtLevel = txtFoLevel;
                typeSectionFields.txtExp = txtFoExp;
                typeSectionFields.expBar = txtFoExpBar;
                typeSectionFields.grpExtend = grpFoTypeExtend;
            }
            else if (page == tabPageVanguard)
            {
                typeSectionFields.txtLevel = txtVaLevel;
                typeSectionFields.txtExp = txtVaExp;
                typeSectionFields.expBar = txtVaExpBar;
                typeSectionFields.grpExtend = grpVaTypeExtend;
            }
            return typeSectionFields;
        }

        public pspo2seForm.pageFields getPageFields(TabPage page, bool inDatabase = false)
        {
            pspo2seForm.pageFields pageFields = new pspo2seForm.pageFields();
            if (page == tabPageInventory)
            {
                pageFields.img_rank = imgInventoryRank;
                pageFields.img_item = imgInventoryItemIcon;
                pageFields.img_manufaturer = imgInventoryWeaponManufacturer;
                pageFields.img_infinity_item = imgInventoryInfinityItem;
                pageFields.img_element = imgInventoryElement;
                pageFields.img_star_0 = imgStar0;
                pageFields.img_star_1 = imgStar1;
                pageFields.img_star_2 = imgStar2;
                pageFields.img_star_3 = imgStar3;
                pageFields.img_star_4 = imgStar4;
                pageFields.img_star_5 = imgStar5;
                pageFields.img_star_6 = imgStar6;
                pageFields.img_star_7 = imgStar7;
                pageFields.img_star_8 = imgStar8;
                pageFields.img_star_9 = imgStar9;
                pageFields.img_star_10 = imgStar10;
                pageFields.img_star_11 = imgStar11;
                pageFields.img_star_12 = imgStar12;
                pageFields.img_star_13 = imgStar13;
                pageFields.img_star_14 = imgStar14;
                pageFields.img_star_15 = imgStar15;
                pageFields.txt_infinity_item = txtInventoryInfinityItemText;
                pageFields.txt_name = txtInventoryName;
                pageFields.txt_name_jp = txtInventoryName_jp;
                pageFields.grp_details = grpInventoryItemDetails;
                pageFields.txt_grinds = txtInventoryGrinds;
                pageFields.txt_percent = txtInventoryPercent;
                pageFields.txt_hex = txtInventoryHex;
                pageFields.txt_meseta = txtInventoryMeseta;
                pageFields.txt_qty = txtInventoryQty;
                pageFields.txt_special = txtInventorySpecial;
                pageFields.txt_effect = txtInventoryEffect;
                pageFields.txt_atk = txtInventoryATK;
                pageFields.txt_acc = txtInventoryACC;
                pageFields.txt_level = txtInventoryLevel;
                pageFields.btn_delete = btnInventoryDelete;
                pageFields.btn_export_selected = btnInventoryExportSelected;
                pageFields.btn_import_selected = btnInventoryImportSelected;
                pageFields.chk_delete_export = chkDeleteExportInventory;
                pageFields.btn_withdraw = btnInventoryDeposit;
                pageFields.pnl_details = (Panel)null;
            }
            else if (page == tabPageStorage)
            {
                pageFields.img_rank = imgStorageRank;
                pageFields.img_item = imgStorageItemIcon;
                pageFields.img_manufaturer = imgStorageWeaponManufacturer;
                pageFields.img_infinity_item = imgStorageInfinityItem;
                pageFields.img_element = imgStorageElement;
                pageFields.img_star_0 = imgStorageStar0;
                pageFields.img_star_1 = imgStorageStar1;
                pageFields.img_star_2 = imgStorageStar2;
                pageFields.img_star_3 = imgStorageStar3;
                pageFields.img_star_4 = imgStorageStar4;
                pageFields.img_star_5 = imgStorageStar5;
                pageFields.img_star_6 = imgStorageStar6;
                pageFields.img_star_7 = imgStorageStar7;
                pageFields.img_star_8 = imgStorageStar8;
                pageFields.img_star_9 = imgStorageStar9;
                pageFields.img_star_10 = imgStorageStar10;
                pageFields.img_star_11 = imgStorageStar11;
                pageFields.img_star_12 = imgStorageStar12;
                pageFields.img_star_13 = imgStorageStar13;
                pageFields.img_star_14 = imgStorageStar14;
                pageFields.img_star_15 = imgStorageStar15;
                pageFields.txt_infinity_item = txtStorageInfinityItemText;
                pageFields.txt_name = txtStorageName;
                pageFields.txt_name_jp = txtStorageName_jp;
                pageFields.grp_details = grpStorageItemDetails;
                pageFields.txt_grinds = txtStorageGrinds;
                pageFields.txt_percent = txtStoragePercent;
                pageFields.txt_hex = txtStorageHex;
                pageFields.txt_meseta = txtStorageMeseta;
                pageFields.txt_qty = txtStorageQty;
                pageFields.txt_special = txtStorageSpecial;
                pageFields.txt_effect = txtStorageEffect;
                pageFields.txt_atk = txtStorageATK;
                pageFields.txt_acc = txtStorageACC;
                pageFields.txt_level = txtStorageLevel;
                pageFields.btn_delete = btnStorageDelete;
                pageFields.btn_export_selected = btnStorageExportSelected;
                pageFields.btn_import_selected = btnStorageImportSelected;
                pageFields.chk_delete_export = chkDeleteExportStorage;
                pageFields.btn_withdraw = btnStorageWithdraw;
                pageFields.pnl_details = (Panel)null;
            }
            else
            {
                MessageBox.Show("The selected page for getFields was not recognised: " + (object)page);
            }
            return pageFields;
        }

        public pspo2seForm.typeWeaponRankFields getTypeWeaponExtendFields(TabPage page)
        {
            pspo2seForm.typeWeaponRankFields weaponRankFields = new pspo2seForm.typeWeaponRankFields();
            if (page == tabPageHunter)
            {
                weaponRankFields.imgWeap[1] = imgHuSword;
                weaponRankFields.imgWeap[2] = imgHuKnuckles;
                weaponRankFields.imgWeap[3] = imgHuSpear;
                weaponRankFields.imgWeap[4] = imgHuDblSaber;
                weaponRankFields.imgWeap[5] = imgHuAxe;
                weaponRankFields.imgWeap[6] = imgHuSabers;
                weaponRankFields.imgWeap[7] = imgHuDaggers;
                weaponRankFields.imgWeap[8] = imgHuClaws;
                weaponRankFields.imgWeap[9] = imgHuSaber;
                weaponRankFields.imgWeap[10] = imgHuDagger;
                weaponRankFields.imgWeap[11] = imgHuClaw;
                weaponRankFields.imgWeap[12] = imgHuWhip;
                weaponRankFields.imgWeap[13] = imgHuSlicer;
                weaponRankFields.imgWeap[14] = imgHuRifle;
                weaponRankFields.imgWeap[15] = imgHuShotgun;
                weaponRankFields.imgWeap[16] = imgHuLongbow;
                weaponRankFields.imgWeap[17] = imgHuGrenade;
                weaponRankFields.imgWeap[18] = imgHuLaser;
                weaponRankFields.imgWeap[19] = imgHuHandguns;
                weaponRankFields.imgWeap[20] = imgHuHandgun;
                weaponRankFields.imgWeap[21] = imgHuCrossbow;
                weaponRankFields.imgWeap[22] = imgHuCards;
                weaponRankFields.imgWeap[23] = imgHuMachinegun;
                weaponRankFields.imgWeap[27] = imgHuRmag;
                weaponRankFields.imgWeap[24] = imgHuRod;
                weaponRankFields.imgWeap[25] = imgHuWand;
                weaponRankFields.imgWeap[26] = imgHuTmag;
                weaponRankFields.imgWeap[28] = imgHuShield;
                weaponRankFields.imgRank[1] = imgHuSwordRank;
                weaponRankFields.imgRank[2] = imgHuKnucklesRank;
                weaponRankFields.imgRank[3] = imgHuSpearRank;
                weaponRankFields.imgRank[4] = imgHuDblSaberRank;
                weaponRankFields.imgRank[5] = imgHuAxeRank;
                weaponRankFields.imgRank[6] = imgHuSabersRank;
                weaponRankFields.imgRank[7] = imgHuDaggersRank;
                weaponRankFields.imgRank[8] = imgHuClawsRank;
                weaponRankFields.imgRank[9] = imgHuSaberRank;
                weaponRankFields.imgRank[10] = imgHuDaggerRank;
                weaponRankFields.imgRank[11] = imgHuClawRank;
                weaponRankFields.imgRank[12] = imgHuWhipRank;
                weaponRankFields.imgRank[13] = imgHuSlicerRank;
                weaponRankFields.imgRank[14] = imgHuRifleRank;
                weaponRankFields.imgRank[15] = imgHuShotgunRank;
                weaponRankFields.imgRank[16] = imgHuLongbowRank;
                weaponRankFields.imgRank[17] = imgHuGrenadeRank;
                weaponRankFields.imgRank[18] = imgHuLaserRank;
                weaponRankFields.imgRank[19] = imgHuHandgunsRank;
                weaponRankFields.imgRank[20] = imgHuHandgunRank;
                weaponRankFields.imgRank[21] = imgHuCrossbowRank;
                weaponRankFields.imgRank[22] = imgHuCardsRank;
                weaponRankFields.imgRank[23] = imgHuMachinegunRank;
                weaponRankFields.imgRank[27] = imgHuRmagRank;
                weaponRankFields.imgRank[24] = imgHuRodRank;
                weaponRankFields.imgRank[25] = imgHuWandRank;
                weaponRankFields.imgRank[26] = imgHuTmagRank;
                weaponRankFields.imgRank[28] = imgHuShieldRank;
            }
            else if (page == tabPageRanger)
            {
                weaponRankFields.imgWeap[1] = imgRaSword;
                weaponRankFields.imgWeap[2] = imgRaKnuckles;
                weaponRankFields.imgWeap[3] = imgRaSpear;
                weaponRankFields.imgWeap[4] = imgRaDblSaber;
                weaponRankFields.imgWeap[5] = imgRaAxe;
                weaponRankFields.imgWeap[6] = imgRaSabers;
                weaponRankFields.imgWeap[7] = imgRaDaggers;
                weaponRankFields.imgWeap[8] = imgRaClaws;
                weaponRankFields.imgWeap[9] = imgRaSaber;
                weaponRankFields.imgWeap[10] = imgRaDagger;
                weaponRankFields.imgWeap[11] = imgRaClaw;
                weaponRankFields.imgWeap[12] = imgRaWhip;
                weaponRankFields.imgWeap[13] = imgRaSlicer;
                weaponRankFields.imgWeap[14] = imgRaRifle;
                weaponRankFields.imgWeap[15] = imgRaShotgun;
                weaponRankFields.imgWeap[16] = imgRaLongbow;
                weaponRankFields.imgWeap[17] = imgRaGrenade;
                weaponRankFields.imgWeap[18] = imgRaLaser;
                weaponRankFields.imgWeap[19] = imgRaHandguns;
                weaponRankFields.imgWeap[20] = imgRaHandgun;
                weaponRankFields.imgWeap[21] = imgRaCrossbow;
                weaponRankFields.imgWeap[22] = imgRaCards;
                weaponRankFields.imgWeap[23] = imgRaMachinegun;
                weaponRankFields.imgWeap[27] = imgRaRmag;
                weaponRankFields.imgWeap[24] = imgRaRod;
                weaponRankFields.imgWeap[25] = imgRaWand;
                weaponRankFields.imgWeap[26] = imgRaTmag;
                weaponRankFields.imgWeap[28] = imgRaShield;
                weaponRankFields.imgRank[1] = imgRaSwordRank;
                weaponRankFields.imgRank[2] = imgRaKnucklesRank;
                weaponRankFields.imgRank[3] = imgRaSpearRank;
                weaponRankFields.imgRank[4] = imgRaDblSaberRank;
                weaponRankFields.imgRank[5] = imgRaAxeRank;
                weaponRankFields.imgRank[6] = imgRaSabersRank;
                weaponRankFields.imgRank[7] = imgRaDaggersRank;
                weaponRankFields.imgRank[8] = imgRaClawsRank;
                weaponRankFields.imgRank[9] = imgRaSaberRank;
                weaponRankFields.imgRank[10] = imgRaDaggerRank;
                weaponRankFields.imgRank[11] = imgRaClawRank;
                weaponRankFields.imgRank[12] = imgRaWhipRank;
                weaponRankFields.imgRank[13] = imgRaSlicerRank;
                weaponRankFields.imgRank[14] = imgRaRifleRank;
                weaponRankFields.imgRank[15] = imgRaShotgunRank;
                weaponRankFields.imgRank[16] = imgRaLongbowRank;
                weaponRankFields.imgRank[17] = imgRaGrenadeRank;
                weaponRankFields.imgRank[18] = imgRaLaserRank;
                weaponRankFields.imgRank[19] = imgRaHandgunsRank;
                weaponRankFields.imgRank[20] = imgRaHandgunRank;
                weaponRankFields.imgRank[21] = imgRaCrossbowRank;
                weaponRankFields.imgRank[22] = imgRaCardsRank;
                weaponRankFields.imgRank[23] = imgRaMachinegunRank;
                weaponRankFields.imgRank[27] = imgRaRmagRank;
                weaponRankFields.imgRank[24] = imgRaRodRank;
                weaponRankFields.imgRank[25] = imgRaWandRank;
                weaponRankFields.imgRank[26] = imgRaTmagRank;
                weaponRankFields.imgRank[28] = imgRaShieldRank;
            }
            else if (page == tabPageForce)
            {
                weaponRankFields.imgWeap[1] = imgFoSword;
                weaponRankFields.imgWeap[2] = imgFoKnuckles;
                weaponRankFields.imgWeap[3] = imgFoSpear;
                weaponRankFields.imgWeap[4] = imgFoDblSaber;
                weaponRankFields.imgWeap[5] = imgFoAxe;
                weaponRankFields.imgWeap[6] = imgFoSabers;
                weaponRankFields.imgWeap[7] = imgFoDaggers;
                weaponRankFields.imgWeap[8] = imgFoClaws;
                weaponRankFields.imgWeap[9] = imgFoSaber;
                weaponRankFields.imgWeap[10] = imgFoDagger;
                weaponRankFields.imgWeap[11] = imgFoClaw;
                weaponRankFields.imgWeap[12] = imgFoWhip;
                weaponRankFields.imgWeap[13] = imgFoSlicer;
                weaponRankFields.imgWeap[14] = imgFoRifle;
                weaponRankFields.imgWeap[15] = imgFoShotgun;
                weaponRankFields.imgWeap[16] = imgFoLongbow;
                weaponRankFields.imgWeap[17] = imgFoGrenade;
                weaponRankFields.imgWeap[18] = imgFoLaser;
                weaponRankFields.imgWeap[19] = imgFoHandguns;
                weaponRankFields.imgWeap[20] = imgFoHandgun;
                weaponRankFields.imgWeap[21] = imgFoCrossbow;
                weaponRankFields.imgWeap[22] = imgFoCards;
                weaponRankFields.imgWeap[23] = imgFoMachinegun;
                weaponRankFields.imgWeap[27] = imgFoRmag;
                weaponRankFields.imgWeap[24] = imgFoRod;
                weaponRankFields.imgWeap[25] = imgFoWand;
                weaponRankFields.imgWeap[26] = imgFoTmag;
                weaponRankFields.imgWeap[28] = imgFoShield;
                weaponRankFields.imgRank[1] = imgFoSwordRank;
                weaponRankFields.imgRank[2] = imgFoKnucklesRank;
                weaponRankFields.imgRank[3] = imgFoSpearRank;
                weaponRankFields.imgRank[4] = imgFoDblSaberRank;
                weaponRankFields.imgRank[5] = imgFoAxeRank;
                weaponRankFields.imgRank[6] = imgFoSabersRank;
                weaponRankFields.imgRank[7] = imgFoDaggersRank;
                weaponRankFields.imgRank[8] = imgFoClawsRank;
                weaponRankFields.imgRank[9] = imgFoSaberRank;
                weaponRankFields.imgRank[10] = imgFoDaggerRank;
                weaponRankFields.imgRank[11] = imgFoClawRank;
                weaponRankFields.imgRank[12] = imgFoWhipRank;
                weaponRankFields.imgRank[13] = imgFoSlicerRank;
                weaponRankFields.imgRank[14] = imgFoRifleRank;
                weaponRankFields.imgRank[15] = imgFoShotgunRank;
                weaponRankFields.imgRank[16] = imgFoLongbowRank;
                weaponRankFields.imgRank[17] = imgFoGrenadeRank;
                weaponRankFields.imgRank[18] = imgFoLaserRank;
                weaponRankFields.imgRank[19] = imgFoHandgunsRank;
                weaponRankFields.imgRank[20] = imgFoHandgunRank;
                weaponRankFields.imgRank[21] = imgFoCrossbowRank;
                weaponRankFields.imgRank[22] = imgFoCardsRank;
                weaponRankFields.imgRank[23] = imgFoMachinegunRank;
                weaponRankFields.imgRank[27] = imgFoRmagRank;
                weaponRankFields.imgRank[24] = imgFoRodRank;
                weaponRankFields.imgRank[25] = imgFoWandRank;
                weaponRankFields.imgRank[26] = imgFoTmagRank;
                weaponRankFields.imgRank[28] = imgFoShieldRank;
            }
            else if (page == tabPageVanguard)
            {
                weaponRankFields.imgWeap[1] = imgVaSword;
                weaponRankFields.imgWeap[2] = imgVaKnuckles;
                weaponRankFields.imgWeap[3] = imgVaSpear;
                weaponRankFields.imgWeap[4] = imgVaDblSaber;
                weaponRankFields.imgWeap[5] = imgVaAxe;
                weaponRankFields.imgWeap[6] = imgVaSabers;
                weaponRankFields.imgWeap[7] = imgVaDaggers;
                weaponRankFields.imgWeap[8] = imgVaClaws;
                weaponRankFields.imgWeap[9] = imgVaSaber;
                weaponRankFields.imgWeap[10] = imgVaDagger;
                weaponRankFields.imgWeap[11] = imgVaClaw;
                weaponRankFields.imgWeap[12] = imgVaWhip;
                weaponRankFields.imgWeap[13] = imgVaSlicer;
                weaponRankFields.imgWeap[14] = imgVaRifle;
                weaponRankFields.imgWeap[15] = imgVaShotgun;
                weaponRankFields.imgWeap[16] = imgVaLongbow;
                weaponRankFields.imgWeap[17] = imgVaGrenade;
                weaponRankFields.imgWeap[18] = imgVaLaser;
                weaponRankFields.imgWeap[19] = imgVaHandguns;
                weaponRankFields.imgWeap[20] = imgVaHandgun;
                weaponRankFields.imgWeap[21] = imgVaCrossbow;
                weaponRankFields.imgWeap[22] = imgVaCards;
                weaponRankFields.imgWeap[23] = imgVaMachinegun;
                weaponRankFields.imgWeap[27] = imgVaRmag;
                weaponRankFields.imgWeap[24] = imgVaRod;
                weaponRankFields.imgWeap[25] = imgVaWand;
                weaponRankFields.imgWeap[26] = imgVaTmag;
                weaponRankFields.imgWeap[28] = imgVaShield;
                weaponRankFields.imgRank[1] = imgVaSwordRank;
                weaponRankFields.imgRank[2] = imgVaKnucklesRank;
                weaponRankFields.imgRank[3] = imgVaSpearRank;
                weaponRankFields.imgRank[4] = imgVaDblSaberRank;
                weaponRankFields.imgRank[5] = imgVaAxeRank;
                weaponRankFields.imgRank[6] = imgVaSabersRank;
                weaponRankFields.imgRank[7] = imgVaDaggersRank;
                weaponRankFields.imgRank[8] = imgVaClawsRank;
                weaponRankFields.imgRank[9] = imgVaSaberRank;
                weaponRankFields.imgRank[10] = imgVaDaggerRank;
                weaponRankFields.imgRank[11] = imgVaClawRank;
                weaponRankFields.imgRank[12] = imgVaWhipRank;
                weaponRankFields.imgRank[13] = imgVaSlicerRank;
                weaponRankFields.imgRank[14] = imgVaRifleRank;
                weaponRankFields.imgRank[15] = imgVaShotgunRank;
                weaponRankFields.imgRank[16] = imgVaLongbowRank;
                weaponRankFields.imgRank[17] = imgVaGrenadeRank;
                weaponRankFields.imgRank[18] = imgVaLaserRank;
                weaponRankFields.imgRank[19] = imgVaHandgunsRank;
                weaponRankFields.imgRank[20] = imgVaHandgunRank;
                weaponRankFields.imgRank[21] = imgVaCrossbowRank;
                weaponRankFields.imgRank[22] = imgVaCardsRank;
                weaponRankFields.imgRank[23] = imgVaMachinegunRank;
                weaponRankFields.imgRank[27] = imgVaRmagRank;
                weaponRankFields.imgRank[24] = imgVaRodRank;
                weaponRankFields.imgRank[25] = imgVaWandRank;
                weaponRankFields.imgRank[26] = imgVaTmagRank;
                weaponRankFields.imgRank[28] = imgVaShieldRank;
            }
            return weaponRankFields;
        }

        public pspo2seForm.expDb_ItemClass findExpLevelInfoInDb(int level)
        {
            if (level - 1 < exp_db_filled)
                return exp_db.level[level - 1];
            MessageBox.Show("Fatal error. Trying to exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return (pspo2seForm.expDb_ItemClass)null;
        }

        public void addExpLevelInfoToDb(string csvLine)
        {
            if (exp_db_filled >= 355)
            {
                MessageBox.Show("Fatal Error! ExpLevel Database is too large!");
            }
            string[] strArray = csvLine.Split('|');
            exp_db.level[exp_db_filled] = new pspo2seForm.expDb_ItemClass();
            try
            {
                exp_db.level[exp_db_filled].level = int.Parse(strArray[0]);
                exp_db.level[exp_db_filled].exp = int.Parse(strArray[1]);
                exp_db.level[exp_db_filled].exp_next = int.Parse(strArray[2]);
                ++exp_db_filled;
            }
            catch
            {
                if (shownCorruptExpCsv)
                    return;
                MessageBox.Show("The ExpLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                shownCorruptExpCsv = true;
                databasesOk = false;
            }
        }

        public void loadExpLevelDatabase()
        {
            exp_db_filled = 0;
            try
            {
                string encryptionKey = run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/explevel.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string csvLine;
                    while ((csvLine = streamReader.ReadLine()) != null)
                        addExpLevelInfoToDb(csvLine);
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                databasesOk = false;
                MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Level Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public pspo2seForm.expDb_ItemClass findExpTypeInfoInDb(int level)
        {
            if (level < type_db_filled)
                return typeexp_db.level[level];
            MessageBox.Show("Fatal error. Trying to get type exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return (pspo2seForm.expDb_ItemClass)null;
        }

        public pspo2seForm.expDb_ItemClass findRebirthBpInfoInDb(int level)
        {
            if (level - 50 + 200 < exp_db_filled)
                return exp_db.level[level - 50 + 200];
            MessageBox.Show("Fatal error. Trying to get rebirth info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return (pspo2seForm.expDb_ItemClass)null;
        }

        public void addExpTypeInfoToDb(string csvLine)
        {
            if (type_db_filled >= 55)
            {
                MessageBox.Show("Fatal Error! ExpTypeLevel Database is too large!");
            }
            string[] strArray = csvLine.Split('|');
            typeexp_db.level[type_db_filled] = new pspo2seForm.expDb_ItemClass();
            try
            {
                typeexp_db.level[type_db_filled].level = int.Parse(strArray[0]);
                typeexp_db.level[type_db_filled].exp = int.Parse(strArray[1]);
                typeexp_db.level[type_db_filled].exp_next = int.Parse(strArray[2]);
                typeexp_db.level[type_db_filled].extend_points = int.Parse(strArray[3]);
            }
            catch
            {
                if (!shownCorruptExpTypeCsv)
                {
                    MessageBox.Show("The ExpTypeLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    shownCorruptExpTypeCsv = true;
                    databasesOk = false;
                }
            }
            ++type_db_filled;
        }

        public void loadExpTypeDatabase()
        {
            type_db_filled = 0;
            try
            {
                string encryptionKey = run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/exptype.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string csvLine;
                    while ((csvLine = streamReader.ReadLine()) != null)
                        addExpTypeInfoToDb(csvLine);
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                databasesOk = false;
                MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Type Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public pspo2seForm.saveDataType get_saveDataInfo => saveData;

        public TabPage get_tabPageType => tabPageInventory;

        public void disableMainForm()
        {
            lstSaveSlotView.Enabled = false;
            tabArea.Enabled = false;
            btnSave.Enabled = false;
            btnSaveAs.Enabled = false;
            btnUndoAll.Enabled = false;
            btnImportCharacter.Enabled = false;
            btnExportCharacter.Enabled = false;
            btnBrowse.Enabled = false;
            menuStrip.Enabled = false;
            tabArea.SelectedTab = tabPageInfo;
            btnInventoryDelete.Enabled = false;
            btnInventoryExportSelected.Enabled = false;
            btnInventoryDeposit.Enabled = false;
            btnStorageDelete.Enabled = false;
            btnStorageExportSelected.Enabled = false;
            btnStorageWithdraw.Enabled = false;
            chkDeleteExportInventory.Enabled = false;
            chkDeleteExportStorage.Enabled = false;
        }

        public void enableMainForm()
        {
            if (txtFileLoc.Text != "")
            {
                lstSaveSlotView.Enabled = true;
                tabArea.Enabled = true;
                btnSave.Enabled = true;
                btnSaveAs.Enabled = true;
                btnUndoAll.Enabled = true;
                btnImportCharacter.Enabled = true;
                btnExportCharacter.Enabled = true;
                inventoryViewPages.SelectedIndex = 0;
                storageViewPages.SelectedIndex = 0;
            }
            btnBrowse.Enabled = true;
            menuStrip.Enabled = true;
        }

        public bool legitVersion() => false;

        private void exportImageLists()
        {
            for (int x = 0; x < decoImageList.Images.Count; x++)
            {
                Directory.CreateDirectory("decoImageList");
                Image temp = decoImageList.Images[x];
                temp.Save("decoImageList/image" + x + ".png");
            }
            for (int x = 0; x < weaponWithRankImageList.Images.Count; x++)
            {
                Directory.CreateDirectory("WeaponWithRank");
                Image temp = weaponWithRankImageList.Images[x];
                temp.Save("WeaponWithRank/image" + x + ".png");
            }
            for (int x = 0; x < imageListWeaponElements.Images.Count; x++)
            {
                Directory.CreateDirectory("WeaponElements");
                Image temp = imageListWeaponElements.Images[x];
                temp.Save("WeaponElements/image" + x + ".png");
            }
            for (int x = 0; x < armourImageList.Images.Count; x++)
            {
                Directory.CreateDirectory("armourImageList");
                Image temp = armourImageList.Images[x];
                temp.Save("armourImageList/image" + x + ".png");
            }
            for (int x = 0; x < itemImageList.Images.Count; x++)
            {
                Directory.CreateDirectory("itemImageList");
                Image temp = itemImageList.Images[x];
                temp.Save("itemImageList/image" + x + ".png");
            }
            for (int x = 0; x < clothesImageList.Images.Count; x++)
            {
                Directory.CreateDirectory("clothesImageList");
                Image temp = clothesImageList.Images[x];
                temp.Save("clothesImageList/image" + x + ".png");
            }
            for (int x = 0; x < paImageList.Images.Count; x++)
            {
                Directory.CreateDirectory("paImageList");
                Image temp = paImageList.Images[x];
                temp.Save("paImageList/image" + x + ".png");
            }
        }
        public pspo2seForm()
        {
            InitializeComponent();
            exportImageLists();
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\databases");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\temp");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\weapon_images");
                firstInstall = true;
                databasesOk = false;
                MessageBox.Show("This is your first time running the application\r\nYou will need to update the databases\r\nbefore you can do anything.\r\n\r\nChoose databases from the top menu to update.", "First time use", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\keys"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\keys");
            if (!downloadRequiredFile("FolderZipper.dll", "The application will not start without this file.", 6144L))
            {
                MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            if (!downloadRequiredFile("ICSharpCode.SharpZipLib.dll", "The application will not start without this file.", 200704L))
            {
                MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            if (!downloadRequiredFile("pspo2se_updater.exe", "The application will not start without this file.", 6144L))
            {
                MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            downloadRequiredFile("SED.exe", "You cannot load encrypted save files without ", 51712L);
            abilityDb.encryptor = encryptor;
            initImageFloater();
            if (!firstInstall)
            {
                action_loadDatabases();
                Application.DoEvents();
                checkAppUpdate(false);
                checkDatabaseUpdate(false);
                checkImagesUpdate(false);
            }
            firstboot = false;
            Text = "PSPo2 Save Editor v3.0 build 1008";
            txtFooterText.Text = "PSPo2 Save Editor v3.0 build 1008 by FunkySkunk 2011-" + DateTime.Now.Year;
            if (legitVersion())
                action_setupLegitApp();
            btnBrowse.Enabled = true;
            menuStrip.Enabled = true;
        }

        private void action_loadDatabases()
        {
            databasesOk = true;
            loadItemDatabase();
            if (!abilityDb.loadDatabase())
                databasesOk = false;
            loadExpLevelDatabase();
            loadExpTypeDatabase();
            if (saveData.type == pspo2seForm.SaveType.NONE)
                return;
            reloadEverything();
        }

        private void action_setupLegitApp()
        {
            Text = "PSPo2 Save Viewer v3.0 build 1008";
            btnExportCharacter.Visible = false;
            btnImportCharacter.Visible = false;
            btnInventoryDelete.Visible = false;
            btnInventoryExportAll.Visible = false;
            btnInventoryImportAll.Visible = false;
            btnInventoryExportSelected.Visible = false;
            btnInventoryDeposit.Visible = true;
            btnInventoryImportSelected.Visible = false;
            btnStorageDelete.Visible = false;
            btnStorageExportAll.Visible = false;
            btnStorageImportAll.Visible = false;
            btnStorageExportSelected.Visible = false;
            btnStorageImportSelected.Visible = false;
            btnStorageWithdraw.Visible = true;
            chkDeleteExportInventory.Visible = false;
            chkDeleteExportStorage.Visible = false;
            inventoryViewPages.TabPages.Remove(tabInventory6);
            storageViewPages.TabPages.Remove(tabStorage6);
            txtFooterText.Text = "PSPo2 Save Viewer v3.0 build 1008 by FunkySkunk 2011";
            chkRebirthSpoof.Visible = false;
            chkRebirthSpoof.Checked = false;
            chkRebirthNoLevelDrop.Visible = false;
            chkRebirthNoLevelDrop.Checked = false;
            txtLevel.Cursor = Cursors.Default;
            lblLevel.Cursor = Cursors.Default;
            txtTitle.Cursor = Cursors.Default;
            lblTitle.Cursor = Cursors.Default;
            txtCurType.Cursor = Cursors.Default;
            lblType.Cursor = Cursors.Default;
            txtRace.Cursor = Cursors.Default;
            lblClass.Cursor = Cursors.Default;
            txtSex.Cursor = Cursors.Default;
            lblSex.Cursor = Cursors.Default;
            txtHuLevel.Cursor = Cursors.Default;
            txtRaLevel.Cursor = Cursors.Default;
            txtFoLevel.Cursor = Cursors.Default;
            txtVaLevel.Cursor = Cursors.Default;
            lblHuLevel.Cursor = Cursors.Default;
            lblRaLevel.Cursor = Cursors.Default;
            lblFoLevel.Cursor = Cursors.Default;
            lblVaLevel.Cursor = Cursors.Default;
            txtInventoryMeseta.Cursor = Cursors.Default;
            lblInventoryMeseta.Cursor = Cursors.Default;
            txtInventoryQty.Cursor = Cursors.Default;
            imgInventoryElement.Cursor = Cursors.Default;
            txtInventoryPercent.Cursor = Cursors.Default;
            txtInventorySpecial.Cursor = Cursors.Default;
            txtInventoryATK.Cursor = Cursors.Default;
            txtStorageMeseta.Cursor = Cursors.Default;
            lblStorageMeseta.Cursor = Cursors.Default;
            txtStorageQty.Cursor = Cursors.Default;
            imgStorageElement.Cursor = Cursors.Default;
            txtStoragePercent.Cursor = Cursors.Default;
            txtStorageSpecial.Cursor = Cursors.Default;
            txtStorageATK.Cursor = Cursors.Default;
            txtSkipEp1Start.Cursor = Cursors.Default;
            txtMissionEp1.Cursor = Cursors.Default;
            txtMissionMagashi.Cursor = Cursors.Default;
            txtMissionTactical.Cursor = Cursors.Default;
            txtEp1Complete.Cursor = Cursors.Default;
            txtSkipEp2Start.Cursor = Cursors.Default;
            txtMissionEp2.Cursor = Cursors.Default;
            txtEp2Complete.Cursor = Cursors.Default;
            btnImportInfinityMission.Visible = false;
            btnExportInfinityMission.Visible = false;
            btnDeleteInfinityMission.Visible = false;
            btnModifyInfinityMission.Visible = false;
        }

        private void action_browse()
        {
            if (!databasesOk)
            {
                MessageBox.Show("The databases must be updated before you can use the application", "Database Updates Required", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                checkDatabaseUpdate(true);
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "PSPo2 Save Editor: Open File";
                if (legitVersion())
                    openFileDialog.Title = "PSPo2 Save Viewer: Open File";
                openFileDialog.Filter = "All files (*.*)|*.*|PSP Decrypted Save Data (*.bin)|*.bin|PSP Encrypted Save Data (*.bin)|*.bin";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                txtFileLoc.Text = openFileDialog.FileName;
                tabArea.SelectedTab = tabPageInfo;
                disableMainForm();
                saveOk = loadSaveFile(false);
                if (!saveOk)
                    return;
                showGameImage();
                if (lstSaveSlotView.Items.Count <= 0)
                    return;
                lstSaveSlotView.Items[0].Selected = true;
                enableMainForm();
            }
        }

        private void action_saveas()
        {
            if (saveOk)
            {
                if (mainSettings.saveStructureIndex.encrypted)
                {
                    if (!saveBufferDataToFile(0, saveData.size, "PSP Encrypted Save Data (*.bin)|*.bin"))
                        return;
                    MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (!saveBufferDataToFile(0, saveData.size, "PSP Decrypted Save Data (*.bin)|*.bin"))
                        return;
                    MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("There is no data to save", "Save Data Buffer Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void action_save()
        {
            if (saveOk)
            {
                if (MessageBox.Show("Are you sure you want to overwrite the loaded save file?", "Confirm Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                if (mainSettings.saveStructureIndex.encrypted)
                {
                    if (!saveBufferDataToFile(0, saveData.size, "PSP Encrypted Save Data (*.bin)|*.bin", isSaveFile: true, path: txtFileLoc.Text))
                        return;
                    MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (!saveBufferDataToFile(0, saveData.size, "PSP Decrypted Save Data (*.bin)|*.bin", isSaveFile: true, path: txtFileLoc.Text))
                        return;
                    MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("There is no data to save", "Save Data Buffer Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void action_launchTypeAbilitiesForm()
        {
            string attachedAbilities = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].job[tabControlClasses.SelectedIndex].attachedAbilities;
            abilitiesForm.oldJobs = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].job;
            abilitiesForm.newJob = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].job[tabControlClasses.SelectedIndex];
            abilitiesForm.selectedJob = (pspo2seForm.jobType)tabControlClasses.SelectedIndex;
            abilitiesForm.max_abilities = mainSettings.saveStructureIndex.max_type_abilities;
            abilitiesForm.character_name = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].name;
            abilitiesForm.abilityDb = abilityDb;
            abilitiesForm.saveType = saveData.type;
            bool flag = false;
            while (!flag)
            {
                if (abilitiesForm.ShowDialog((IWin32Window)this) == DialogResult.OK)
                {
                    pspo2seForm.jobClass newJob = abilitiesForm.newJob;
                    if (newJob.attachedAbilities != attachedAbilities)
                    {
                        int pos = mainSettings.saveStructureIndex.type_level_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 16 + tabControlClasses.SelectedIndex * mainSettings.saveStructureIndex.type_extend_size + 4;
                        overwriteHexInBuffer(newJob.attachedAbilities, pos);
                        saveData.slot[lstSaveSlotView.SelectedItems[0].Index].job[tabControlClasses.SelectedIndex].attachedAbilities = newJob.attachedAbilities;
                    }
                    flag = true;
                }
                else if (saveData.slot[lstSaveSlotView.SelectedItems[0].Index].job[tabControlClasses.SelectedIndex].attachedAbilities != attachedAbilities)
                {
                    if (MessageBox.Show("You are about to quit without saving changes\r\nAre you sure?", "Changes were made", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveData.slot[lstSaveSlotView.SelectedItems[0].Index].job[tabControlClasses.SelectedIndex].attachedAbilities = attachedAbilities;
                        flag = true;
                    }
                }
                else
                    flag = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e) => action_browse();

        private void btnExportCharacter_Click(object sender, EventArgs e)
        {
            if (!saveBufferDataToFile(mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index, mainSettings.saveStructureIndex.slot_size, mainSettings.saveStructureIndex.character_file_name + " (*" + mainSettings.saveStructureIndex.character_file_ext + ")|*" + mainSettings.saveStructureIndex.character_file_ext, fileNameDefault: lstSaveSlotView.SelectedItems[0].Text))
                return;
            MessageBox.Show("The character file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnUndoAll_Click(object sender, EventArgs e) => loadSaveFile(false);

        private void btnImportCharacter_Click(object sender, EventArgs e)
        {
            if (loadFileIntoBuffer(mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index, mainSettings.saveStructureIndex.character_file_name + " (*" + mainSettings.saveStructureIndex.character_file_ext + ")|*" + mainSettings.saveStructureIndex.character_file_ext, pspo2seForm.partFileType.character, false) <= 0)
                return;
            reloadEverything();
            MessageBox.Show("The character file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnSaveAs_Click(object sender, EventArgs e) => action_saveas();

        private void tabArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabArea.SelectedIndex)
            {
                case 2:
                    inventoryViewPages.SelectedIndex = 0;
                    if (inventoryView.SelectedItems.Count <= 0)
                    {
                        makeImageFloaterHidden();
                        break;
                    }
                    changeImageFloater(txtInventoryHex.Text.Substring(2, 8));
                    break;
                case 3:
                    storageViewPages.SelectedIndex = 0;
                    if (storageView.SelectedItems.Count <= 0)
                    {
                        makeImageFloaterHidden();
                        break;
                    }
                    changeImageFloater(txtStorageHex.Text.Substring(2, 8));
                    break;
                default:
                    closeImageFloater();
                    break;
            }
        }

        private void storageViewPages_SelectedIndexChanged(object sender, EventArgs e) => changeStoragePage(storageViewPages.SelectedIndex + 1);

        private void storageViewChanged()
        {
            if (storageView.SelectedItems.Count > 0)
            {
                selectedStorageItem = storageView.SelectedItems[0].Index;
                if (selectedStorageItem != -1)
                {
                    showSelectedInventoryItem(tabPageStorage);
                }
                else
                {
                    grpStorageItemDetails.Visible = false;
                    imageFloatImageIsOk = false;
                    txtStorageHex.Text = "0x00000000";
                    changeImageFloater(txtStorageHex.Text);
                }
            }
            else
            {
                grpStorageItemDetails.Visible = false;
                imageFloatImageIsOk = false;
                txtStorageHex.Text = "0x00000000";
            }
        }

        private void storageView_SelectedIndexChanged(object sender, EventArgs e) => storageViewChanged();

        private void storageView_Click(object sender, EventArgs e) => storageViewChanged();

        private void inventoryViewPages_SelectedIndexChanged(object sender, EventArgs e) => changeInventoryPage(inventoryViewPages.SelectedIndex + 1);

        private void inventoryViewChanged()
        {
            if (inventoryView.SelectedItems.Count > 0)
            {
                selectedInventoryItem = inventoryView.SelectedItems[0].Index;
                if (selectedInventoryItem != -1)
                {
                    showSelectedInventoryItem(tabPageInventory);
                }
                else
                {
                    grpInventoryItemDetails.Visible = false;
                    imageFloatImageIsOk = false;
                    txtInventoryHex.Text = "0x00000000";
                    changeImageFloater(txtInventoryHex.Text);
                }
            }
            else
            {
                grpInventoryItemDetails.Visible = false;
                imageFloatImageIsOk = false;
                txtInventoryHex.Text = "0x00000000";
            }
        }

        private void inventoryView_Click(object sender, EventArgs e) => inventoryViewChanged();

        private void inventoryView_SelectedIndexChanged(object sender, EventArgs e) => inventoryViewChanged();

        private void txtInventoryName_jp_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtInventoryName_jp.Text);
            MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInventoryExportSelected_Click(object sender, EventArgs e)
        {
            int id = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)].id;
            string ext_options = mainSettings.saveStructureIndex.item_file_name + " (*" + mainSettings.saveStructureIndex.item_file_ext + ")|*" + mainSettings.saveStructureIndex.item_file_ext;
            if (saveItemDataToFile(id, 20, ext_options, inventoryView.SelectedItems[0].Text, delete: chkDeleteExportInventory.Checked))
            {
                if (chkDeleteExportInventory.Checked)
                {
                    overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
                    overwriteHexInBuffer("00000000", id - 8);
                    reloadEverything();
                }
                MessageBox.Show("The item file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("The item file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStorageExportSelected_Click(object sender, EventArgs e)
        {
            if (saveItemDataToFile(saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)].id, 20, mainSettings.saveStructureIndex.item_file_name + " (*" + mainSettings.saveStructureIndex.item_file_ext + ")|*" + mainSettings.saveStructureIndex.item_file_ext, storageView.SelectedItems[0].Text, delete: chkDeleteExportStorage.Checked))
            {
                if (chkDeleteExportStorage.Checked)
                    reloadEverything();
                MessageBox.Show("The item file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("The item file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStorageImportSelected_Click(object sender, EventArgs e)
        {
            int id = saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)].id;
            string ext_options = mainSettings.saveStructureIndex.item_file_name + " (*" + mainSettings.saveStructureIndex.item_file_ext + ")|*" + mainSettings.saveStructureIndex.item_file_ext;
            if (loadFileIntoBuffer(id, ext_options, pspo2seForm.partFileType.item, false) <= 0)
                return;
            reloadEverything();
            tabArea.SelectedIndex = 3;
            selectItemAfterLoad = id;
            displaySharedStorage(1);
            MessageBox.Show("The item was imported successfully.\n\nIf the item was modified, the values may not match the game until the next time you save your progress.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInventoryImportSelected_Click(object sender, EventArgs e)
        {
            if (inventoryView.SelectedItems.Count <= 0)
                return;
            if (loadFileIntoBuffer(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)].id, mainSettings.saveStructureIndex.item_file_name + " (*" + mainSettings.saveStructureIndex.item_file_ext + ")|*" + mainSettings.saveStructureIndex.item_file_ext, pspo2seForm.partFileType.item, true) <= 0)
                return;
            reloadEverything();
            tabArea.SelectedIndex = 2;
            displayInventory(lstSaveSlotView.SelectedItems[0].Index, 1);
            MessageBox.Show("The item / items were imported successfully.\n\nIf an item was modified, the values may not match the game until the next time you save your progress.\n\nPlease remember that you should not used modified items online as you may get banned.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnStorageExportAll_Click(object sender, EventArgs e)
        {
            if (!saveBufferDataToFile(mainSettings.saveStructureIndex.shared_inventory_pos, mainSettings.saveStructureIndex.shared_inventory_slots * 20, mainSettings.saveStructureIndex.storage_file_name + " (*" + mainSettings.saveStructureIndex.storage_file_ext + ")|*" + mainSettings.saveStructureIndex.storage_file_ext))
                return;
            MessageBox.Show("The storage file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInventoryExportAll_Click(object sender, EventArgs e)
        {
            if (!saveBufferDataToFile(mainSettings.saveStructureIndex.inventory_slots_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index, 2160, mainSettings.saveStructureIndex.inventory_file_name + " (*" + mainSettings.saveStructureIndex.inventory_file_ext + ")|*" + mainSettings.saveStructureIndex.inventory_file_ext, saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed))
                return;
            MessageBox.Show("The inventory file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnInventoryImportAll_Click(object sender, EventArgs e)
        {
            if (loadFileIntoBuffer(mainSettings.saveStructureIndex.inventory_slots_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index, mainSettings.saveStructureIndex.inventory_file_name + " (*" + mainSettings.saveStructureIndex.inventory_file_ext + ")|*" + mainSettings.saveStructureIndex.inventory_file_ext, pspo2seForm.partFileType.inventory, true) <= 0)
                return;
            reloadEverything();
            MessageBox.Show("The inventory file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnStorageImportAll_Click(object sender, EventArgs e)
        {
            if (loadFileIntoBuffer(mainSettings.saveStructureIndex.shared_inventory_pos, mainSettings.saveStructureIndex.storage_file_name + " (*" + mainSettings.saveStructureIndex.storage_file_ext + ")|*" + mainSettings.saveStructureIndex.storage_file_ext, pspo2seForm.partFileType.storage, false) <= 0)
                return;
            reloadEverything();
            MessageBox.Show("The storage file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnHuAbilitiesOpen_Click(object sender, EventArgs e) => action_launchTypeAbilitiesForm();

        private void btnRaAbilitiesOpen_Click(object sender, EventArgs e) => action_launchTypeAbilitiesForm();

        private void btnFoAbilitiesOpen_Click(object sender, EventArgs e) => action_launchTypeAbilitiesForm();

        private void btnVaAbilitiesOpen_Click(object sender, EventArgs e) => action_launchTypeAbilitiesForm();

        private void saveSlotView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSaveSlotView.SelectedItems.Count <= 0)
                return;
            displaySlotInfo(lstSaveSlotView.SelectedItems[0].Index);
            if (tabArea.SelectedIndex == 2)
            {
                inventoryViewPages.SelectedIndex = 0;
                Application.DoEvents();
            }
            if (tabArea.SelectedIndex != 3)
                return;
            storageViewPages.SelectedIndex = 0;
            Application.DoEvents();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) => action_browse();

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => action_saveas();

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) => action_loadDatabases();

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e) => loadImageFloaterImages();

        private void txtInventoryHex_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtInventoryHex.Text.Substring(2, 8));
            MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtStorageHex_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtStorageHex.Text.Substring(2, 8));
            MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) => checkDatabaseUpdate(true);

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void updateToolStripMenuItem_Click(object sender, EventArgs e) => checkAppUpdate(true);

        private void versionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = !legitVersion() ? "PSPo2 Save Editor" : "PSPo2 Save Viewer";
            if (!databasesOk)
            {
                MessageBox.Show("You are currently running " + str + " v3.0 build 1008\r\n\r\nThe databases are not installed correctly.\r\nPlease update them before you can view more information.", "Version Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                changelogForm.formSetup();
                int num2 = (int)changelogForm.ShowDialog((IWin32Window)this);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("http://files-ds-scene.net/retrohead/pspo2se/");

        private void checkForUpdatesToolStripMenuItem1_Click(object sender, EventArgs e) => checkImagesUpdate(true);

        private void txtStorageMeseta_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            entryForm.oldVal = string.Concat((object)saveData.sharedMeseta);
            entryForm.newVal = string.Concat((object)saveData.sharedMeseta);
            entryForm.description = "shared meseta";
            entryForm.maxLen = 8;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            long num1 = long.Parse(entryForm.newVal);
            if (num1 != saveData.sharedMeseta && num1 <= 99999999L)
            {
                string hex = num1.ToString("X4");
                while (hex.Length < 8)
                    hex = "0" + hex;
                int pos = mainSettings.saveStructureIndex.shared_inventory_pos + mainSettings.saveStructureIndex.shared_inventory_slots * 20;
                overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 8), pos);
                saveData.sharedMeseta = num1;
                txtStorageMeseta.Text = num1.ToString();
            }
            else
            {
                if (num1 <= 99999999L)
                    return;
                MessageBox.Show("You must enter a value less than or equal to 99,999,999");
            }
        }

        private void btnStorageWithdraw_Click(object sender, EventArgs e)
        {
            if (saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed >= 60)
            {
                MessageBox.Show("The selected characters inventory is full", "Inventory Full", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                saveItemDataToFile(saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)].id, 20, "", "", Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + mainSettings.saveStructureIndex.item_file_ext, true);
                int index = 0;
                while (index < 60 && saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[index].used)
                    ++index;
                int freeInventoryItemId = getFreeInventoryItemId(lstSaveSlotView.SelectedItems[0].Index);
                if (loadFileIntoBuffer(freeInventoryItemId, "", pspo2seForm.partFileType.item, true, Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + mainSettings.saveStructureIndex.item_file_ext) > 0)
                {
                    reloadEverything();
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + mainSettings.saveStructureIndex.item_file_ext);
                    tabArea.SelectedIndex = 2;
                    selectInventoryItemAfterLoad = freeInventoryItemId;
                    displayInventory(lstSaveSlotView.SelectedItems[0].Index, 1);
                }
                else
                {
                    MessageBox.Show("There was an error moving the item. Please re-load your save file and try again.", "Item Move Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btnInventoryDeposit_Click(object sender, EventArgs e)
        {
            if (saveData.sharedInventory.itemsUsed >= mainSettings.saveStructureIndex.shared_inventory_slots)
            {
                MessageBox.Show("The shared storage is full", "Storage Full", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int id = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)].id;
                if (!saveItemDataToFile(id, 20, "", "", Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + mainSettings.saveStructureIndex.item_file_ext, true))
                {
                    MessageBox.Show("Could not write the temporary file: \n\n" + Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + mainSettings.saveStructureIndex.item_file_ext, "Failed to deposit item!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
                    overwriteHexInBuffer("00000000", id - 8);
                    for (int index = 0; index < saveData.sharedInventory.itemsUsed; ++index)
                    {
                        if (!saveData.sharedInventory.item[index].used)
                        {
                            id = saveData.sharedInventory.item[index].id;
                            break;
                        }
                    }
                    if (loadFileIntoBuffer(id, "", pspo2seForm.partFileType.item, false, Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + mainSettings.saveStructureIndex.item_file_ext) > 0)
                    {
                        --saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed;
                        overwriteHexInBuffer(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X2"), mainSettings.saveStructureIndex.inventory_slots_used_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index);
                        reloadEverything();
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + mainSettings.saveStructureIndex.item_file_ext);
                        tabArea.SelectedIndex = 3;
                        selectItemAfterLoad = id;
                        displaySharedStorage(1);
                    }
                    else
                    {
                        MessageBox.Show("There was an error moving the item. Please re-load your save file and try again.", "Item Move Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void txtStorageQty_Click(object sender, EventArgs e) => changeItemQty(tabPageStorage);

        private void txtInventoryQty_Click(object sender, EventArgs e) => changeItemQty(tabPageInventory);

        private void changeDiskLevel(TabPage page)
        {
            if (legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != tabPageStorage ? saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)] : saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)];
            entryForm.oldVal = string.Concat((object)(inventoryItemClass.pa_level + 1));
            entryForm.newVal = string.Concat((object)(inventoryItemClass.pa_level + 1));
            entryForm.description = "PA disk level";
            entryForm.maxLen = 2;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != (inventoryItemClass.pa_level + 1).ToString()))
                return;
            if (int.Parse(newVal) > 30)
            {
                MessageBox.Show("You must enter a value lower or equal to 30.");
            }
            else if (int.Parse(newVal) < 1)
            {
                MessageBox.Show("You must enter a value greater than 0.");
            }
            else
            {
                string hex = (int.Parse(newVal) - 1).ToString("X1");
                while (hex.Length < 2)
                    hex = "0" + hex;
                overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 2), inventoryItemClass.id + 16);
                inventoryItemClass.pa_level = int.Parse(newVal) - 1;
                displayItemInfo(getPageFields(page), inventoryItemClass);
            }
        }

        private void changeItemQty(TabPage page)
        {
            if (legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != tabPageStorage ? saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)] : saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)];
            if (inventoryItemClass.qty == 0)
            {
                changeDiskLevel(page);
            }
            else
            {
                entryForm.oldVal = inventoryItemClass.qty.ToString();
                entryForm.newVal = inventoryItemClass.qty.ToString();
                entryForm.description = "item qty";
                entryForm.maxLen = 3;
                if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                    return;
                string newVal = entryForm.newVal;
                if (!(newVal != inventoryItemClass.qty.ToString()))
                    return;
                if (int.Parse(newVal) > inventoryItemClass.qty_max)
                {
                    MessageBox.Show("You must enter a value lower or equal to the max stack qty for this item.");
                }
                else if (int.Parse(newVal) < 1)
                {
                    MessageBox.Show("You must enter a value greater than 0.");
                }
                else
                {
                    string hex = int.Parse(newVal).ToString("X2");
                    while (hex.Length < 4)
                        hex = "0" + hex;
                    overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 4), inventoryItemClass.id + 4);
                    inventoryItemClass.qty = int.Parse(newVal);
                    if (page == tabPageStorage)
                        txtStorageQty.Text = inventoryItemClass.qty.ToString() + "/" + (object)inventoryItemClass.qty_max;
                    else
                        txtInventoryQty.Text = inventoryItemClass.qty.ToString() + "/" + (object)inventoryItemClass.qty_max;
                }
            }
        }

        private void txtInventoryPercent_Click(object sender, EventArgs e) => changeItemPercentage(tabPageInventory);

        private void txtStoragePercent_Click(object sender, EventArgs e) => changeItemPercentage(tabPageStorage);

        private void changeItemPercentage(TabPage page)
        {
            if (legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != tabPageStorage ? saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)] : saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)];
            entryForm.oldVal = inventoryItemClass.percent.ToString();
            entryForm.newVal = inventoryItemClass.percent.ToString();
            entryForm.description = "element percentage";
            entryForm.maxLen = 3;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != inventoryItemClass.percent.ToString()))
                return;
            if (int.Parse(newVal) > 100)
            {
                MessageBox.Show("You must enter a value lower or equal to 100.");
            }
            else if (int.Parse(newVal) < 0)
            {
                MessageBox.Show("You must enter a value greater or equal to 0.");
            }
            else
            {
                string hex1 = int.Parse(newVal).ToString("X1");
                while (hex1.Length < 2)
                    hex1 = "0" + hex1;
                string hex2 = run.hexAndMathFunction.reversehex(hex1, 2);
                string str1 = "";
                for (int index = 0; index < 20; ++index)
                    str1 += run.hexAndMathFunction.decimalByteConvert(savedata_decimal_array[inventoryItemClass.id + index], "hex");
                overwriteHexInBuffer(hex2, inventoryItemClass.id + 17);
                string str2 = "";
                for (int index = 0; index < 20; ++index)
                    str2 += run.hexAndMathFunction.decimalByteConvert(savedata_decimal_array[inventoryItemClass.id + index], "hex");
                inventoryItemClass.percent = int.Parse(newVal);
                if (page == tabPageStorage)
                    txtStoragePercent.Text = inventoryItemClass.percent.ToString() + "%";
                else
                    txtInventoryPercent.Text = inventoryItemClass.percent.ToString() + "%";
            }
        }

        private void imgStorageElement_Click(object sender, EventArgs e) => changeItemElement(tabPageStorage);

        private void imgInventoryElement_Click(object sender, EventArgs e) => changeItemElement(tabPageInventory);

        private void changeItemElement(TabPage page)
        {
            if (legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != tabPageStorage ? saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)] : saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)];
            entryForm.oldVal = inventoryItemClass.element.ToString();
            entryForm.newVal = ((int)inventoryItemClass.element).ToString();
            entryForm.description = "element";
            entryForm.maxLen = 1;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != ((int)inventoryItemClass.element).ToString()))
                return;
            if (int.Parse(newVal) >= 7)
            {
                MessageBox.Show("You must enter a value lower than " + (object)pspo2seForm.elementType.COUNT + ".");
            }
            else if (int.Parse(newVal) < 0)
            {
                MessageBox.Show("You must enter a value greater or equal to 0.");
            }
            else
            {
                string hex = int.Parse(newVal).ToString("X1");
                while (hex.Length < 2)
                    hex = "0" + hex;
                overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 2), inventoryItemClass.id + 16);
                inventoryItemClass.element = (pspo2seForm.elementType)int.Parse(newVal);
                displayElementImage(getPageFields(page), inventoryItemClass.element);
            }
        }

        private void txtInventoryMeseta_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            entryForm.oldVal = txtInventoryMeseta.Text;
            entryForm.newVal = txtInventoryMeseta.Text;
            entryForm.description = "characters meseta";
            entryForm.maxLen = 8;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            long num1 = long.Parse(entryForm.newVal);
            if (num1 != saveData.slot[lstSaveSlotView.SelectedItems[0].Index].meseta)
            {
                string hex = num1.ToString("X4");
                while (hex.Length < 8)
                    hex = "0" + hex;
                overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 8), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 244);
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].meseta = num1;
                txtInventoryMeseta.Text = num1.ToString();
            }
            else
            {
                if (num1 <= 99999999L)
                    return;
                MessageBox.Show("You must enter a value less than or equal to 99,999,999");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => action_save();

        private void btnSave_Click(object sender, EventArgs e) => action_save();

        private void btnInventoryDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            int id = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)].id;
            --saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed;
            overwriteHexInBuffer(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X2"), mainSettings.saveStructureIndex.inventory_slots_used_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index);
            overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
            overwriteHexInBuffer("00000000", id - 8);
            reloadEverything();
        }

        private void btnStorageDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            overwriteHexInBuffer("0000000000000000000000000000000000000000", saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)].id);
            reloadEverything();
        }

        private void pspo2seForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = false;

        private void changeItemATK(TabPage page)
        {
            if (legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != tabPageStorage ? saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)] : saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)];
            entryForm.oldVal = inventoryItemClass.power_add.ToString();
            entryForm.newVal = inventoryItemClass.power_add.ToString();
            entryForm.description = "weapon power mod";
            entryForm.maxLen = 4;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != inventoryItemClass.power_add.ToString()))
                return;
            if (int.Parse(newVal) > 9999)
            {
                MessageBox.Show("You must enter a value lower or equal to 9999.");
            }
            else if (int.Parse(newVal) < 1)
            {
                MessageBox.Show("You must enter a value greater than 0.");
            }
            else
            {
                string hex1 = int.Parse(newVal).ToString("X2");
                while (hex1.Length < 4)
                    hex1 = "0" + hex1;
                string hex2 = run.hexAndMathFunction.reversehex(hex1, 4);
                string str1 = "";
                for (int index = 0; index < 20; ++index)
                    str1 += run.hexAndMathFunction.decimalByteConvert(savedata_decimal_array[inventoryItemClass.id + index], "hex");
                overwriteHexInBuffer(hex2, inventoryItemClass.id + 12);
                string str2 = "";
                for (int index = 0; index < 20; ++index)
                    str2 += run.hexAndMathFunction.decimalByteConvert(savedata_decimal_array[inventoryItemClass.id + index], "hex");
                inventoryItemClass.power_add = int.Parse(newVal);
                showSelectedInventoryItem(page);
            }
        }

        private void txtStorageATK_Click(object sender, EventArgs e) => changeItemATK(tabPageStorage);

        private void txtInventoryATK_Click(object sender, EventArgs e) => changeItemATK(tabPageInventory);

        private void txtSkipEp1Start_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            if (txtSkipEp1Start.Text == "Yes")
            {
                MessageBox.Show("You are already skipping the starting sequence to Episode 1", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to skip the starting sequence to Episode 1?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;
                overwriteHexInBuffer("90AB1E", saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 5460 : num2 + 4648);
                txtSkipEp1Start.Text = "Yes";
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].skip_ep_1_start = true;
                MessageBox.Show("The Episode 1 start sequence was skipped successfully.\n\nYou will need to play the first mission to progress the story.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtSkipEp2Start_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            if (txtSkipEp2Start.Text == "Yes")
            {
                MessageBox.Show("You are already skipping the starting sequence to Episode 2", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to skip the starting sequence to Episode 2?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                overwriteHexInBuffer("78AF1E", mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 4684);
                txtSkipEp2Start.Text = "Yes";
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].skip_ep_2_start = true;
                MessageBox.Show("The Episode 2 start sequence was skipped successfully.\n\nGo to the Little Wing Office to progress the story further.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtMissionEp1_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            if (txtMissionEp1.Text == "Yes")
            {
                MessageBox.Show("You have already unlocked all of the Episode 1 Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want unlock all of the Episode 1 Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;
                overwriteHexInBuffer("204E", saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3436 : num2 + 3512);
                txtMissionEp1.Text = "Yes";
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].mission_unlock_ep1 = true;
                MessageBox.Show("The Episode 1 Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtMissionUnknown_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            if (txtMissionTactical.Text == "Yes")
            {
                MessageBox.Show("You have already unlocked all of the Unknown Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want unlock all of the Unknown Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;
                overwriteHexInBuffer("204E", saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3488 : num2 + 3564);
                txtMissionTactical.Text = "Yes";
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].mission_unlock_unknown = true;
                MessageBox.Show("The Unknown Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtMissionEp2_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            if (txtMissionEp2.Text == "Yes")
            {
                MessageBox.Show("You have already unlocked all of the Episode 2 Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want unlock all of the Episode 2 Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                if (saveData.type == pspo2seForm.SaveType.PSP2I)
                {
                    int pos = mainSettings.saveStructureIndex.story_info_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;
                    pos = pos + 272;
                    overwriteHexInBuffer("204E", pos);
                    txtMissionEp2.Text = "Yes";
                    saveData.slot[lstSaveSlotView.SelectedItems[0].Index].mission_unlock_ep2 = true;
                    MessageBox.Show("The Episode 2 Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                   MessageBox.Show("This feature is for Infinity only");
                }
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
            if (legitVersion())
                return;
            if (txtMissionMagashi.Text == "Yes")
            {
                MessageBox.Show("You have already unlocked Magashi Plan.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want unlock Magashi Plan?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;
                overwriteHexInBuffer("1F", saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3182 : num2 + 3242);
                txtMissionMagashi.Text = "Yes";
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].mission_unlock_magashi = true;
                MessageBox.Show("The Magashi Plan mission was unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtCharacterName_Click(object sender, EventArgs e)
        {
            entryForm.oldVal = txtCharacterName.Text;
            entryForm.newVal = txtCharacterName.Text;
            entryForm.description = "character name";
            entryForm.maxLen = 32;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != txtCharacterName.Text))
                return;
            string hexadecimal = run.hexAndMathFunction.stringToHexadecimal(newVal, 64);
            overwriteHexInBuffer(hexadecimal, mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index);
            overwriteHexInBuffer(hexadecimal, mainSettings.saveStructureIndex.character_name_pos2 + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index);
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].name = newVal;
            lstSaveSlotView.SelectedItems[0].Text = newVal;
            txtCharacterName.Text = newVal;
        }

        private void txtLevel_Click(object sender, EventArgs e) => jumpToLevel();

        private void txtStorageName_jp_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtStorageName_jp.Text);
            MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtTitle_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            entryForm.oldVal = txtTitle.Text;
            entryForm.newVal = txtTitle.Text;
            entryForm.description = "title";
            entryForm.maxLen = 25;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != txtTitle.Text))
                return;
            overwriteHexInBuffer(run.hexAndMathFunction.stringToHexadecimal(newVal, 64), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 64);
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].title = newVal;
            txtTitle.Text = newVal;
        }

        private void txtCurType_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            entryForm.oldVal = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].cur_type.ToString();
            entryForm.newVal = ((int)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].cur_type).ToString();
            entryForm.description = "type";
            entryForm.maxLen = 1;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != ((int)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].cur_type).ToString()))
                return;
            string hex = int.Parse(newVal).ToString("X1");
            while (hex.Length < 2)
                hex = "0" + hex;
            overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 2), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 130);
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].cur_type = (pspo2seForm.jobType)int.Parse(newVal);
            txtCurType.Text = string.Concat((object)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].cur_type);
            lstSaveSlotView.SelectedItems[0].SubItems[3].Text = txtCurType.Text;
        }

        private void txtClass_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            entryForm.oldVal = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].race.ToString();
            entryForm.newVal = ((int)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].race).ToString();
            entryForm.description = "class";
            entryForm.maxLen = 1;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != ((int)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].race).ToString()))
                return;
            string hex = int.Parse(newVal).ToString("X1");
            while (hex.Length < 2)
                hex = "0" + hex;
            overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 2), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 128);
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].race = (pspo2seForm.raceTypes)int.Parse(newVal);
            txtRace.Text = string.Concat((object)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].race);
            lstSaveSlotView.SelectedItems[0].SubItems[2].Text = txtRace.Text;
        }

        private void txtSex_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            entryForm.oldVal = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].sex.ToString();
            entryForm.newVal = ((int)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].sex).ToString();
            entryForm.description = "sex";
            entryForm.maxLen = 1;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != ((int)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].sex).ToString()))
                return;
            string hex = int.Parse(newVal).ToString("X1");
            while (hex.Length < 2)
                hex = "0" + hex;
            overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 2), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 129);
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].sex = (pspo2seForm.sexType)int.Parse(newVal);
            txtSex.Text = string.Concat((object)saveData.slot[lstSaveSlotView.SelectedItems[0].Index].sex);
        }

        private void lstPAMelee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPAMelee.SelectedItems.Count <= 0)
                return;
            lstPA_SelectedIndexChanged(tabPAMelee, int.Parse(lstPAMelee.SelectedItems[0].Tag.ToString()));
        }

        private void lstPABullets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPABullets.SelectedItems.Count <= 0)
                return;
            lstPA_SelectedIndexChanged(tabPABullets, int.Parse(lstPABullets.SelectedItems[0].Tag.ToString()));
        }

        private void lstPATechs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPATechs.SelectedItems.Count <= 0)
                return;
            lstPA_SelectedIndexChanged(tabPATech, int.Parse(lstPATechs.SelectedItems[0].Tag.ToString()));
        }

        private pspo2seForm.pageFields getPAPageFields(TabPage tab)
        {
            pspo2seForm.pageFields pageFields = new pspo2seForm.pageFields();
            switch (tab.Name)
            {
                case "tabPAMelee":
                    pageFields.txt_hex = txtPAHexMelee;
                    break;
                case "tabPABullets":
                    pageFields.txt_hex = txtPAHexBullets;
                    break;
                case "tabPATech":
                    pageFields.txt_hex = txtPAHexTech;
                    break;
            }
            return pageFields;
        }

        private void lstPA_SelectedIndexChanged(TabPage tab, int paPositionID) => getPAPageFields(tab).txt_hex.Text = "0x" + saveData.slot[lstSaveSlotView.SelectedItems[0].Index].pa.items[paPositionID].hex_reversed;

        private unsafe int* getRebirthStatPointer(string nameFlag)
        {
            int* numPtr1 = (int*)null;
            switch (nameFlag)
            {
                case "HP":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.hp)
                        numPtr1 = numPtr2;
                    break;
                case "PP":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.pp)
                        numPtr1 = numPtr2;
                    break;
                case "ATK":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.atk)
                        numPtr1 = numPtr2;
                    break;
                case "DEF":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.def)
                        numPtr1 = numPtr2;
                    break;
                case "ACC":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.acc)
                        numPtr1 = numPtr2;
                    break;
                case "EVA":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.eva)
                        numPtr1 = numPtr2;
                    break;
                case "TEC":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.tec)
                        numPtr1 = numPtr2;
                    break;
                case "MND":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.mnd)
                        numPtr1 = numPtr2;
                    break;
                case "STA":
                    fixed (int* numPtr2 = &saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.sta)
                        numPtr1 = numPtr2;
                    break;
            }
            return numPtr1;
        }

        private unsafe void numRebirth_ValueChanged(object sender, EventArgs e)
        {
            if (lstSaveSlotView.SelectedItems[0].Index < 0 || ((NumericUpDown)sender).Value > 10M || ((NumericUpDown)sender).Value < 0M)
                return;
            string str = ((Control)sender).Name.Replace("numRebirth", "");
            int* rebirthStatPointer = getRebirthStatPointer(str);
            int num1 = *rebirthStatPointer;
            int rebirthValuePtsUsed = getRebirthValuePtsUsed(lstSaveSlotView.SelectedItems[0].Index, *rebirthStatPointer, str);
            *rebirthStatPointer = (int)((NumericUpDown)sender).Value;
            int num2 = getRebirthValuePtsUsed(lstSaveSlotView.SelectedItems[0].Index, *rebirthStatPointer, str) - rebirthValuePtsUsed;
            if (num2 < 0)
            {
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points += -num2;
                updateRebirthBufferVals(lstSaveSlotView.SelectedItems[0].Index);
            }
            else
            {
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points -= num2;
                if (saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points < 0)
                {
                    MessageBox.Show("You need " + (object)-saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points + " more points to add to this stat.\n\nYou will need to rebirth to gain more BP.", "Not Enough BP", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ((NumericUpDown)sender).Value = (Decimal)(*rebirthStatPointer - 1);
                }
                else
                    updateRebirthBufferVals(lstSaveSlotView.SelectedItems[0].Index);
            }
            displayRebirthInfo(lstSaveSlotView.SelectedItems[0].Index);
        }

        private void classLevel_Click(object sender, EventArgs e) => jumpToTypeLevel();

        private void lstRebirthRewards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRebirthRewards.Items.Count <= 0)
                return;
            lstRebirthRewards.SelectedItems.Clear();
        }

        private void btnRebirth_Click(object sender, EventArgs e)
        {
            int level = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].level;
            if (chkRebirthSpoof.Checked)
                level = 200;
            if (level < 50)
                return;
            if (comboRebirthExtend.SelectedIndex > 0)
            {
                if (saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed >= 60)
                {
                    MessageBox.Show("The characters inventory is full, please deposit an item before rebirthing so you can claim the extend codes", "Inventory Full", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                string hex1 = comboRebirthExtend.SelectedIndex.ToString("X4");
                while (hex1.Length < 8)
                    hex1 = "0" + hex1;
                overwriteHexInBuffer("0F010000" + run.hexAndMathFunction.reversehex(hex1, 8) + "630000000000000B00000000", mainSettings.saveStructureIndex.inventory_slots_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed * 36 + 4);
                ++saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed;
                string hex2 = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X1");
                while (hex2.Length < 2)
                    hex2 = "0" + hex2;
                overwriteHexInBuffer(hex2, mainSettings.saveStructureIndex.inventory_slots_used_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index);
            }
            if (saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.count < (int)ushort.MaxValue)
            {
                string hex = (saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.count + 1).ToString("X2");
                while (hex.Length < 4)
                    hex = "0" + hex;
                overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 4), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 438);
            }
            int num1 = getRebirthNowPointGain(level);
            if (comboRebirthExtend.SelectedIndex > 0)
                num1 -= 5 * comboRebirthExtend.SelectedIndex;
            if (num1 > 999)
                num1 = 999;
            string hex3 = (num1 + saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points).ToString("X2");
            while (hex3.Length < 4)
                hex3 = "0" + hex3;
            overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex3, 4), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 440);
            int num2 = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].rebirth.additionalTypeLevels + getRebirthNowTypeLevelGain(level);
            if (num2 > 20)
                num2 = 20;
            string hex4 = num2.ToString("X1");
            while (hex4.Length < 2)
                hex4 = "0" + hex4;
            overwriteHexInBuffer(hex4, mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 283);
            if (!chkRebirthNoLevelDrop.Checked)
                writeNewLevelData(1);
            reloadEverything();
            MessageBox.Show("The rebirth completed successfully.\n\nIf you selected to claim extend codes, they will be in the characters inventory.", "Rebirth Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void chkRebirthSpoof_CheckedChanged(object sender, EventArgs e) => listRebirthRewards(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].level, lstSaveSlotView.SelectedItems[0].Index);

        private void weaponDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weaponDatabaseForm.initForm();
            weaponDatabaseForm.Show((IWin32Window)this);
        }

        private void txtEp1Complete_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            if (txtEp1Complete.Text == "Yes")
            {
                MessageBox.Show("You have already completed Episode 1.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want set Episode 1 to complete?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;
                int pos = saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 23177 : num2 + 22397;
                if (saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_2_complete)
                    overwriteHexInBuffer("03", pos);
                else
                    overwriteHexInBuffer("01", pos);
                txtEp1Complete.Text = "Yes";
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_1_complete = true;
                reloadEverything();
                MessageBox.Show("Episode 1 was completed successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtEp2Complete_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            if (txtEp2Complete.Text == "Yes")
            {
                MessageBox.Show("You have already completed Episode 2.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want set Episode 2 to complete?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;
                int pos = saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 23177 : num2 + 22397;
                if (saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_1_complete)
                    overwriteHexInBuffer("03", pos);
                else
                    overwriteHexInBuffer("02", pos);
                txtEp2Complete.Text = "Yes";
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_2_complete = true;
                reloadEverything();
                MessageBox.Show("Episode 2 was completed successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void lstInfinityMissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInfinityMissions.SelectedItems.Count <= 0)
            {
                grpInfinityMissionDetails.Visible = false;
                grpInfMisExtra.Visible = false;
                grpInfMisSpecial.Visible = false;
                btnExportInfinityMission.Enabled = false;
                btnDeleteInfinityMission.Enabled = false;
                btnModifyInfinityMission.Enabled = false;
            }
            else
            {
                pspo2seForm.infinityMissionClass infinityMissionClass = saveData.infinityMissions.slot[int.Parse(lstInfinityMissions.SelectedItems[0].Tag.ToString())];
                txtInfNameEn.Text = intToInfinityBoss(infinityMissionClass.boss - 1)[1] + " @ " + intToInfinityArea(infinityMissionClass.area - 1)[1];
                txtInfNameJp.Text = intToInfinityArea(infinityMissionClass.area - 1)[0] + "の" + intToInfinityBoss(infinityMissionClass.boss - 1)[0];
                txtInfMisSpecial.Text = "Area  " + intToInfinityArea(infinityMissionClass.area - 1)[1] + " (" + intToInfinityArea(infinityMissionClass.area - 1)[0] + ")";
                txtInfMisBoss.Text = "Boss  " + intToInfinityBoss(infinityMissionClass.boss - 1)[1] + " (" + intToInfinityBoss(infinityMissionClass.boss - 1)[0] + ") [" + (object)infinityMissionClass.length + "]";
                txtInfMisEnemy1.Text = "Main Enemy  " + intToInfinityEnemy(infinityMissionClass.enemy_1)[1] + " (" + intToInfinityEnemy(infinityMissionClass.enemy_1)[0] + ") [" + (object)infinityMissionClass.unk_enemy_1_mod + "]";
                txtInfMisEnemy2.Text = "Sub Enemy  " + intToInfinityEnemy(infinityMissionClass.enemy_2)[1] + " (" + intToInfinityEnemy(infinityMissionClass.enemy_2)[0] + ")";
                txtInfEnemyLevel.Text = "Enemy Level  +" + (object)infinityMissionClass.enemy_level + " [" + (object)infinityMissionClass.unk_enemy_level_mod + "]";
                txtInfMisSpecial.Text = "Special Effects  " + infinityMissionClass.hex.Substring(12, 20);
                txtInfMisCreatedBy.Text = "Created By  " + infinityMissionClass.createdBy;
                txtInfMisSynthPoint.Text = "Synthesis Points  " + (object)infinityMissionClass.mergePoints;
                grpInfinityMissionDetails.Visible = true;
                grpInfMisExtra.Visible = true;
                grpInfMisSpecial.Visible = true;
                btnExportInfinityMission.Enabled = true;
                btnDeleteInfinityMission.Enabled = true;
                btnModifyInfinityMission.Enabled = true;
            }
        }

        private void btnExportInfinityMission_Click(object sender, EventArgs e)
        {
            if (saveBufferDataToFile(mainSettings.saveStructureIndex.infinity_mission_pos + int.Parse(lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 104, 104, "PSPo2i Mission File (*pspo2imission)|*pspo2imission", fileNameDefault: lstInfinityMissions.SelectedItems[0].Text))
            {
                MessageBox.Show("The mission file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("The mission file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnImportInfinityMission_Click(object sender, EventArgs e)
        {
            string ext_options = "PSPo2i Mission File (*pspo2imission)|*pspo2imission";
            if (saveData.infinityMissions.itemsUsed >= 100)
            {
                if (MessageBox.Show("You do not have any available infinity mission slots.\n\nDo you want to overwrite the selected slot?", "Max Slots Reached", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                if (lstInfinityMissions.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("You must select a mission from your list to overwrite.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (loadFileIntoBuffer(int.Parse(lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 104 + mainSettings.saveStructureIndex.infinity_mission_pos, ext_options, pspo2seForm.partFileType.infinity_mission, false) <= 0)
                        return;
                    reloadEverything();
                }
            }
            else if (MessageBox.Show("Do you want to import a mission or multiple missions into available slots?", "Confirm Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int num = loadFileIntoBuffer(saveData.infinityMissions.itemsUsed * 104 + mainSettings.saveStructureIndex.infinity_mission_pos, ext_options, pspo2seForm.partFileType.infinity_mission, true);
                if (num <= 0)
                    return;
                saveData.infinityMissions.itemsUsed += num;
                string hex = saveData.infinityMissions.itemsUsed.ToString("X1");
                while (hex.Length < 2)
                    hex = "0" + hex;
                overwriteHexInBuffer(hex, mainSettings.saveStructureIndex.infinity_mission_pos + 10400);
                reloadEverything();
            }
            else
            {
                if (MessageBox.Show("Do you want to overwrite the selected slot?", "Confirm Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                if (lstInfinityMissions.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("You must select a mission from your list to overwrite.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (loadFileIntoBuffer(int.Parse(lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 104 + mainSettings.saveStructureIndex.infinity_mission_pos, ext_options, pspo2seForm.partFileType.infinity_mission, false) <= 0)
                        return;
                    reloadEverything();
                }
            }
        }

        private void btnDeleteInfinityMission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the last mission in the list?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            int num = saveData.infinityMissions.itemsUsed * 104 + mainSettings.saveStructureIndex.infinity_mission_pos;
            --saveData.infinityMissions.itemsUsed;
            string hex = saveData.infinityMissions.itemsUsed.ToString("X1");
            while (hex.Length < 2)
                hex = "0" + hex;
            overwriteHexInBuffer(hex, mainSettings.saveStructureIndex.infinity_mission_pos + 10400);
            overwriteHexInBuffer("1198040121012040800001020100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", mainSettings.saveStructureIndex.infinity_mission_pos + 104 * saveData.infinityMissions.itemsUsed);
            txtInfinityMissionQty.Text = saveData.infinityMissions.itemsUsed.ToString() + "/100";
            lstInfinityMissions.Items[lstInfinityMissions.Items.Count - 1].Remove();
        }

        private void btnModifyInfinityMission_Click(object sender, EventArgs e)
        {
            if (lstInfinityMissions.SelectedItems.Count <= 0)
            {
                MessageBox.Show("You must select a mission from your list to modify.", "Modify Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                infinityMissionForm.id = int.Parse(lstInfinityMissions.SelectedItems[0].Tag.ToString());
                int num2 = (int)infinityMissionForm.ShowDialog((IWin32Window)this);
            }
        }

        private void changeItemSpecial(TabPage page)
        {
            if (legitVersion())
                return;
            pspo2seForm.inventoryItemClass inventoryItemClass = page != tabPageStorage ? saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)] : saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)];
            entryForm.newVal = ((int)inventoryItemClass.ability).ToString();
            if (inventoryItemClass.style == pspo2seForm.weaponStyleType.Tech)
            {
                entryForm.description = "TEC ability";
                entryForm.oldVal = (inventoryItemClass.ability + 21).ToString();
            }
            else
            {
                entryForm.description = "ability";
                entryForm.oldVal = inventoryItemClass.ability.ToString();
            }
            entryForm.maxLen = 1;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = entryForm.newVal;
            if (!(newVal != ((int)inventoryItemClass.ability).ToString()))
                return;
            if (int.Parse(newVal) >= 21 || inventoryItemClass.style == pspo2seForm.weaponStyleType.Tech && int.Parse(newVal) >= 8)
            {
                MessageBox.Show("You must enter a value lower than " + (object)8 + " for TEC weapons and " + (object)10 + " for all others.");
            }
            else if (int.Parse(newVal) < 0)
            {
                MessageBox.Show("You must enter a value greater or equal to 0.");
            }
            else
            {
                string hex = int.Parse(newVal).ToString("X1");
                while (hex.Length < 2)
                    hex = "0" + hex;
                overwriteHexInBuffer(hex, inventoryItemClass.id + 8);
                inventoryItemClass.ability = (pspo2seForm.abilityType)int.Parse(newVal);
                getPageFields(page);
                showSelectedInventoryItem(page);
            }
        }

        private void txtInventorySpecial_Click(object sender, EventArgs e) => changeItemSpecial(tabPageInventory);

        private void txtStorageSpecial_Click(object sender, EventArgs e) => changeItemSpecial(tabPageStorage);

        private void btnImportMissions_Click(object sender, EventArgs e)
        {
            string ext_options = "PSPo2i Mission Pack File (*pspo2imissions)|*pspo2imissions";
            if (MessageBox.Show("Are you sure you want to import missions overwriting all of the current missions?", "Confirm Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel || loadFileIntoBuffer(290888, ext_options, pspo2seForm.partFileType.infinity_mission_pack, false) <= 0)
                return;
            reloadEverything();
        }

        private void btnExportMissions_Click(object sender, EventArgs e)
        {
            if (saveBufferDataToFile(290888, 10401, "PSPo2i Mission Pack File (*pspo2imissions)|*pspo2imissions", fileNameDefault: "Pspo2 Infinity Mission Pack"))
            {
                MessageBox.Show("The mission pack file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("The mission pack file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtAllowQuitMission_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            if (txtAllowQuitMission.Text == "Yes")
            {
                MessageBox.Show("You can already quit missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want enable quiting missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int num2 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;
                overwriteHexInBuffer("FF", saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 4441 : num2 + 4517);
                txtAllowQuitMission.Text = "Yes";
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].allow_quit_missions = "FF";
                MessageBox.Show("The quit mission function was unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void showGameImage()
        {
            switch (saveData.type)
            {
                case pspo2seForm.SaveType.PSP2:
                    imgSave.Image = (Image)Resources.PSP2;
                    imgGameLogo.Image = (Image)Resources.PSP2_logo;
                    imgSave.Show();
                    break;
                case pspo2seForm.SaveType.PSP2I:
                    imgSave.Image = (Image)Resources.PSP2i;
                    imgGameLogo.Image = (Image)Resources.PSP2i_logo;
                    imgSave.Show();
                    break;
                default:
                    imgGameLogo.Image = (Image)Resources.PSP2_logo;
                    imgSave.Hide();
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
                if (saveData.slot[slotnum].pa.items[index] != null && saveData.slot[slotnum].pa.items[index].hex != null && saveData.slot[slotnum].pa.items[index].hex == hex)
                    return saveData.slot[slotnum].pa.items[index].level;
            }
            return "LV0";
        }

        private string storyCompleteToText(bool ep1_complete, bool ep2_complete) => ep1_complete ? (saveData.type == pspo2seForm.SaveType.PSP2 || ep2_complete ? "Game Complete" : "Ep 1 Complete") : (ep2_complete ? "Ep 2 Complete" : "");

        private void displayCharacterInfo(int slotnum)
        {
            if (saveData.slot[slotnum].name != "")
                txtSlotnumloaded.Text = "Save Slot #" + (object)(slotnum + 1) + " Loaded";
            else
                txtSlotnumloaded.Text = "No Save Slot Loaded";
            txtCharacterName.Text = saveData.slot[slotnum].name;
            txtTitle.Text = saveData.slot[slotnum].title;
            txtPlaytime.Text = saveData.slot[slotnum].playtime;
            txtCurType.Text = string.Concat((object)saveData.slot[slotnum].cur_type);
            txtRace.Text = string.Concat((object)saveData.slot[slotnum].race);
            txtSex.Text = string.Concat((object)saveData.slot[slotnum].sex);
            txtLevel.Text = string.Concat((object)saveData.slot[slotnum].level);
            txtExp.Text = string.Concat((object)saveData.slot[slotnum].exp);
            txtExpNext.Text = string.Concat((object)saveData.slot[slotnum].exp_next);
            txtLevelExpBar.Width = saveData.slot[slotnum].exp_percent * 2;
            txtInventoryMeseta.Text = string.Concat((object)saveData.slot[slotnum].meseta);
            txtStoryComplete.Text = storyCompleteToText(saveData.slot[slotnum].story_ep_1_complete, saveData.slot[slotnum].story_ep_2_complete);
            txtStoryComplete.Visible = true;
            txtSkipEp1Start.Text = "No";
            if (saveData.slot[slotnum].skip_ep_1_start)
                txtSkipEp1Start.Text = "Yes";
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                txtSkipEp2Start.Text = "No";
                if (saveData.slot[slotnum].skip_ep_2_start)
                    txtSkipEp2Start.Text = "Yes";
            }
            txtMissionEp1.Text = "No";
            txtMissionTactical.Text = "No";
            txtMissionEp2.Text = "No";
            txtMissionMagashi.Text = "No";
            txtEp1Complete.Text = "No";
            txtEp2Complete.Text = "No";
            txtAllowQuitMission.Text = "No";
            if (saveData.slot[slotnum].mission_unlock_ep1)
                txtMissionEp1.Text = "Yes";
            if (saveData.slot[slotnum].mission_unlock_unknown)
                txtMissionTactical.Text = "Yes";
            if (saveData.slot[slotnum].mission_unlock_ep2)
                txtMissionEp2.Text = "Yes";
            if (saveData.slot[slotnum].mission_unlock_magashi)
                txtMissionMagashi.Text = "Yes";
            if (saveData.slot[slotnum].story_ep_1_complete)
                txtEp1Complete.Text = "Yes";
            if (saveData.slot[slotnum].story_ep_2_complete)
                txtEp2Complete.Text = "Yes";
            if (saveData.slot[slotnum].allow_quit_missions == "FF")
                txtAllowQuitMission.Text = "Yes";
            txtStoryEmiliaPoints.Visible = true;
            if (saveData.slot[slotnum].story_ep_1_points != null)
                txtStoryEmiliaPoints.Text = run.hexAndMathFunction.hexToInt(saveData.slot[slotnum].story_ep_1_points).ToString() + " Emilia Points";
            if (saveData.slot[slotnum].story_ep_2_points != null)
            {
                txtStoryNagisaPoints.Text = run.hexAndMathFunction.hexToInt(saveData.slot[slotnum].story_ep_2_points).ToString() + " Nagisa Points";
                txtStoryNagisaPoints.Visible = true;
            }
            else
                txtStoryNagisaPoints.Visible = false;
        }

        private int getRebirthNowPointGain(int level) => findRebirthBpInfoInDb(level).exp;

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

        private void addRebirthReward(string str, Color col) => lstRebirthRewards.Items.Add(new ListViewItem()
        {
            Text = str,
            ForeColor = col
        });

        private void listRebirthRewards(int level, int slot)
        {
            if (chkRebirthSpoof.Checked)
                level = 200;
            comboRebirthExtend.Items.Clear();
            lstRebirthRewards.Items.Clear();
            if (level < 50)
            {
                addRebirthReward("Rebirth Not Available.", Color.DarkGray);
                addRebirthReward("Next Rebirth in " + (object)(50 - level) + " Levels.", Color.DarkGray);
                btnRebirth.Enabled = false;
                comboRebirthExtend.Enabled = false;
            }
            else
            {
                btnRebirth.Enabled = true;
                comboRebirthExtend.Enabled = true;
                int num1 = 0;
                comboRebirthExtend.Items.Add((object)("Claim " + (object)getRebirthNowPointGain(level) + " bonus points and 0 extend codes."));
                for (int index = 0; index < saveData.slot[slot].rebirth.remaining_points + getRebirthNowPointGain(level); index += 5)
                {
                    ++num1;
                    if (num1 == 1)
                        comboRebirthExtend.Items.Add((object)("Claim " + (object)(getRebirthNowPointGain(level) - 5 * num1) + " bonus points and " + (object)num1 + " extend code."));
                    else
                        comboRebirthExtend.Items.Add((object)("Claim " + (object)(getRebirthNowPointGain(level) - 5 * num1) + " bonus points and " + (object)num1 + " extend codes."));
                    if (num1 == 10)
                        break;
                }
                comboRebirthExtend.SelectedIndex = 0;
                addRebirthReward("Up to " + (object)num1 + " extend codes.", Color.DarkGreen);
                addRebirthReward("Up to " + (object)getRebirthNowPointGain(level) + " bonus points.", Color.DarkGreen);
                if (30 + saveData.slot[slot].rebirth.additionalTypeLevels >= 50)
                    return;
                int num2 = 30 + saveData.slot[slot].rebirth.additionalTypeLevels + getRebirthNowTypeLevelGain(level);
                if (num2 > 50)
                    num2 = 50;
                addRebirthReward("Maximum type level " + (object)num2 + ".", Color.DarkGreen);
            }
        }

        private void displayTypePage(int slotnum, pspo2seForm.jobType i)
        {
            bool flag = false;
            if (saveData.slot[slotnum].job[(int)i].level >= 30 + saveData.slot[slotnum].rebirth.additionalTypeLevels)
                flag = true;
            if (flag)
            {
                saveData.slot[slotnum].job[(int)i].exp_to_next = 0;
                saveData.slot[slotnum].job[(int)i].exp_next = saveData.slot[slotnum].job[(int)i].exp;
                saveData.slot[slotnum].job[(int)i].exp_percent = 100;
            }
            else
            {
                pspo2seForm.expDb_ItemClass expDbItemClass = new pspo2seForm.expDb_ItemClass();
                pspo2seForm.expDb_ItemClass expTypeInfoInDb = findExpTypeInfoInDb(saveData.slot[slotnum].job[(int)i].level);
                if (expTypeInfoInDb == null)
                {
                    MessageBox.Show("could not find typeexp for type level " + (object)saveData.slot[slotnum].job[(int)i].level);
                }
                saveData.slot[slotnum].job[(int)i].exp_to_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next - saveData.slot[slotnum].job[(int)i].exp;
                saveData.slot[slotnum].job[(int)i].exp_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next;
                saveData.slot[slotnum].job[(int)i].exp_percent = expTypeInfoInDb.exp_next != 0 ? run.hexAndMathFunction.getPercentage(saveData.slot[slotnum].job[(int)i].exp - expTypeInfoInDb.exp, expTypeInfoInDb.exp_next) : 100;
            }
            pspo2seForm.typeSectionFields typeSectionFields1 = new pspo2seForm.typeSectionFields();
            TabPage page = new TabPage();
            switch (i)
            {
                case pspo2seForm.jobType.Hunter:
                    page = tabPageHunter;
                    break;
                case pspo2seForm.jobType.Ranger:
                    page = tabPageRanger;
                    break;
                case pspo2seForm.jobType.Force:
                    page = tabPageForce;
                    break;
                case pspo2seForm.jobType.Vanguard:
                    page = tabPageVanguard;
                    break;
                default:
                    MessageBox.Show("jobType " + (object)i + " not handled in displayTypePage", "Fatal Error!");
                    break;
            }
            string str = page.Name.Replace("tabPage", "");
            pspo2seForm.typeSectionFields typeSectionFields2 = getTypeSectionFields(page);
            page.Text = str + " (" + (object)saveData.slot[slotnum].job[(int)i].level + ")";
            typeSectionFields2.txtLevel.Text = string.Concat((object)saveData.slot[slotnum].job[(int)i].level);
            typeSectionFields2.grpExtend.Text = "Type Extend " + (object)saveData.slot[slotnum].job[(int)i].extendpointsused + "/" + (object)saveData.slot[slotnum].job[(int)i].extendpoints;
            typeSectionFields2.txtExp.Text = "Next " + (object)saveData.slot[slotnum].job[(int)i].exp_to_next;
            typeSectionFields2.expBar.Width = saveData.slot[slotnum].job[(int)i].exp_percent;
            showTypeWeaponExtendImages(saveData.slot[slotnum].job[(int)i], page);
        }

        private void displayTypeInfo(int slotnum)
        {
            for (int index = 0; index < 4; ++index)
                displayTypePage(slotnum, (pspo2seForm.jobType)index);
        }

        private void showTypeWeaponExtendImages(pspo2seForm.jobClass type, TabPage page)
        {
            pspo2seForm.typeWeaponRankFields weaponExtendFields = getTypeWeaponExtendFields(page);
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
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                bool flag1 = true;
                foreach (TabPage tabPage in tabControlMissions.TabPages)
                {
                    if (tabPage == tabEp2Missions)
                    {
                        flag1 = false;
                        break;
                    }
                }
                if (flag1)
                {
                    tabControlMissions.TabPages.Add(tabEp2Missions);
                    tabControlMissions.TabPages.Add(tabPageInfinityMission);
                }
                bool flag2 = true;
                foreach (TabPage tabPage in tabArea.TabPages)
                {
                    if (tabPage == tabPageRebirth)
                    {
                        flag2 = false;
                        break;
                    }
                }
                if (flag2)
                    tabArea.TabPages.Add(tabPageRebirth);
            }
            else
            {
                bool flag1 = false;
                foreach (TabPage tabPage in tabControlMissions.TabPages)
                {
                    if (tabPage == tabEp2Missions)
                    {
                        flag1 = true;
                        break;
                    }
                }
                if (flag1)
                {
                    tabControlMissions.TabPages.Remove(tabEp2Missions);
                    tabControlMissions.TabPages.Remove(tabPageInfinityMission);
                }
                bool flag2 = false;
                foreach (TabPage tabPage in tabArea.TabPages)
                {
                    if (tabPage == tabPageRebirth)
                    {
                        flag2 = true;
                        break;
                    }
                }
                if (flag2)
                    tabArea.TabPages.Remove(tabPageRebirth);
            }
            displayCharacterInfo(slotnum);
            displayRebirthInfo(slotnum);
            displayTypeInfo(slotnum);
            displayInventory(slotnum, 1);
            displaySharedStorage(1);
            displayPAList(slotnum);
            displayInfinityMissions();
        }

        private void displayInfinityMissions()
        {
            lstInfinityMissions.Items.Clear();
            txtInfinityMissionQty.Text = saveData.infinityMissions.itemsUsed.ToString() + "/100";
            for (int index = 0; index < saveData.infinityMissions.itemsUsed; ++index)
            {
                ListViewItem listViewItem1 = new ListViewItem();
                listViewItem1.Text = intToInfinityBoss(saveData.infinityMissions.slot[index].boss - 1)[1] + " @ " + intToInfinityArea(saveData.infinityMissions.slot[index].area - 1)[1];
                ListViewItem listViewItem2 = listViewItem1;
                listViewItem2.Text = listViewItem2.Text + " (" + intToInfinityArea(saveData.infinityMissions.slot[index].area - 1)[0] + "の" + intToInfinityBoss(saveData.infinityMissions.slot[index].boss - 1)[0] + ")";
                listViewItem1.Tag = (object)saveData.infinityMissions.slot[index].id;
                listViewItem1.SubItems.Add("LV" + (object)saveData.infinityMissions.slot[index].level);
                lstInfinityMissions.Items.Add(listViewItem1);
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
            getRebirthValues(statVal, switchFlag, &num1, &num2, &num3);
            statTextBox.Text = "+" + (object)num2;
            bpTextBox.Text = string.Concat((object)num1);
            if (statVal >= 10)
                nextTextBox.Text = "max";
            else
                nextTextBox.Text = "+" + (object)num3 + "pt";
            nextTextBox.ForeColor = Color.DarkGreen;
            if (num3 > saveData.slot[slot].rebirth.remaining_points || statVal >= 10)
                nextTextBox.ForeColor = Color.DarkRed;
            numBox.Value = (Decimal)statVal;
        }

        private unsafe int getRebirthValuePtsUsed(int slot, int val, string switchFlag)
        {
            int num1;
            int num2;
            int num3;
            getRebirthValues(val, switchFlag, &num1, &num2, &num3);
            return num1;
        }

        private void displayRebirthInfo(int slot)
        {
            if (saveData.type != pspo2seForm.SaveType.PSP2I)
            {
                grpRebirth.Visible = false;
            }
            else
            {
                grpRebirth.Visible = true;
                int num = saveData.slot[slot].rebirth.remaining_points + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.hp, "HP") + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.pp, "PP") + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.atk, "ATK") + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.def, "DEF") + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.acc, "ACC") + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.eva, "EVA") + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.tec, "TEC") + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.mnd, "MND") + getRebirthValuePtsUsed(slot, saveData.slot[slot].rebirth.sta, "STA");
                txtRebirthCount.Text = saveData.slot[slot].rebirth.count.ToString();
                txtRebirthPoints.Text = "BP " + saveData.slot[slot].rebirth.remaining_points.ToString() + "/" + (object)num;
                txtRebirthMaxType.Text = string.Concat((object)(30 + saveData.slot[slot].rebirth.additionalTypeLevels));
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.hp, "HP", txtRebirthHP, txtRebirthBpHP, numRebirthHP, txtRebirthNextHP);
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.pp, "PP", txtRebirthPP, txtRebirthBpPP, numRebirthPP, txtRebirthNextPP);
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.atk, "ATK", txtRebirthATK, txtRebirthBpATK, numRebirthATK, txtRebirthNextATK);
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.def, "DEF", txtRebirthDEF, txtRebirthBpDEF, numRebirthDEF, txtRebirthNextDEF);
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.acc, "ACC", txtRebirthACC, txtRebirthBpACC, numRebirthACC, txtRebirthNextACC);
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.eva, "EVA", txtRebirthEVA, txtRebirthBpEVA, numRebirthEVA, txtRebirthNextEVA);
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.tec, "TEC", txtRebirthTEC, txtRebirthBpTEC, numRebirthTEC, txtRebirthNextTEC);
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.mnd, "MND", txtRebirthMND, txtRebirthBpMND, numRebirthMND, txtRebirthNextMND);
                displayRebirthStatInfo(slot, saveData.slot[slot].rebirth.sta, "STA", txtRebirthSTA, txtRebirthBpSTA, numRebirthSTA, txtRebirthNextSTA);
                listRebirthRewards(saveData.slot[slot].level, slot);
            }
        }

        private void displayPAList(int slot)
        {
            lstPAMelee.Items.Clear();
            lstPABullets.Items.Clear();
            lstPATechs.Items.Clear();
            ArrayList arrayList = ArrayList.Adapter((IList)saveData.slot[slot].pa.items);
            arrayList.Sort();
            saveData.slot[slot].pa.items = (pspo2seForm.inventoryItemClass[])arrayList.ToArray(typeof(pspo2seForm.inventoryItemClass));
            for (int index = 0; index < 256; ++index)
            {
                if (!(saveData.slot[slot].pa.items[index].hex == ""))
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.ImageIndex = int.Parse(saveData.slot[slot].pa.items[index].hex.Substring(2, 2), NumberStyles.HexNumber) - 1;
                    if (saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "06")
                        listViewItem.ImageIndex += 28;
                    pspo2seForm.itemDb_ItemClass itemDbItemClass = new pspo2seForm.itemDb_ItemClass();
                    string hex = saveData.slot[slot].pa.items[index].hex_reversed;
                    if (saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "05")
                    {
                        int num = int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                        num -= 13;
                        string str1 = num.ToString("X1");
                        while (str1.Length < 2)
                            str1 = "0" + str1;
                        num = int.Parse(saveData.slot[slot].pa.items[index].hex_reversed.Substring(2, 2), NumberStyles.HexNumber) - 1;
                        string str2 = num.ToString("X1");
                        while (str2.Length < 2)
                            str2 = "0" + str2;
                        hex = saveData.slot[slot].pa.items[index].hex_reversed.Substring(0, 2) + str2 + str1 + saveData.slot[slot].pa.items[index].hex_reversed.Substring(6, 2);
                    }
                    pspo2seForm.itemDb_ItemClass itemInDb = findItemInDb(hex);
                    listViewItem.Text = itemInDb.name;
                    if (itemInDb.name == "")
                        listViewItem.Text = itemInDb.name_jp;
                    listViewItem.SubItems.Add(saveData.slot[slot].pa.items[index].level);
                    listViewItem.Tag = (object)index.ToString();
                    if (saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "04")
                        lstPAMelee.Items.Add(listViewItem);
                    if (saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "05")
                        lstPABullets.Items.Add(listViewItem);
                    if (saveData.slot[slot].pa.items[index].hex.Substring(0, 2) == "06")
                        lstPATechs.Items.Add(listViewItem);
                }
            }
        }

        private void updateRebirthBufferVals(int slot)
        {
            int num = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * slot + 438;
            for (int index = 0; index < 12; ++index)
            {
                string hex = "";
                switch (index)
                {
                    case 0:
                        hex = saveData.slot[slot].rebirth.count.ToString("X2");
                        break;
                    case 1:
                        hex = saveData.slot[slot].rebirth.remaining_points.ToString("X2");
                        break;
                    case 2:
                        hex = saveData.slot[slot].rebirth.atk.ToString("X2");
                        break;
                    case 3:
                        hex = saveData.slot[slot].rebirth.def.ToString("X2");
                        break;
                    case 4:
                        hex = saveData.slot[slot].rebirth.acc.ToString("X2");
                        break;
                    case 5:
                        hex = saveData.slot[slot].rebirth.eva.ToString("X2");
                        break;
                    case 6:
                        hex = saveData.slot[slot].rebirth.sta.ToString("X2");
                        break;
                    case 8:
                        hex = saveData.slot[slot].rebirth.tec.ToString("X2");
                        break;
                    case 9:
                        hex = saveData.slot[slot].rebirth.mnd.ToString("X2");
                        break;
                    case 10:
                        hex = saveData.slot[slot].rebirth.hp.ToString("X2");
                        break;
                    case 11:
                        hex = saveData.slot[slot].rebirth.pp.ToString("X2");
                        break;
                }
                if (hex != "")
                {
                    while (hex.Length < 4)
                        hex = "0" + hex;
                    overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 4), num + index * 2);
                }
            }
        }

        private void initSaveBuffer()
        {
            savedata_decimal_array_filled = 0;
            savedata_decimal_array_read_pos = 0;
            saveData = new pspo2seForm.saveDataType();
        }

        private void initSlotVars()
        {
            for (int index1 = 0; index1 < 8; ++index1)
            {
                saveData.slot[index1] = new pspo2seForm.saveSlotType();
                saveData.slot[index1].used = false;
                saveData.slot[index1].name = "";
                saveData.slot[index1].title = "-";
                saveData.slot[index1].playtime = "00:00:00";
                saveData.slot[index1].race = pspo2seForm.raceTypes.None;
                saveData.slot[index1].sex = pspo2seForm.sexType.None;
                saveData.slot[index1].cur_type = pspo2seForm.jobType.None;
                saveData.slot[index1].level = 0;
                saveData.slot[index1].exp = 0;
                saveData.slot[index1].meseta = 0L;
                saveData.slot[index1].allow_quit_missions = "";
                saveData.slot[index1].story_ep_1_complete = false;
                saveData.slot[index1].story_ep_1_points = "0000";
                saveData.slot[index1].story_ep_1_best_end = "0000";
                for (int index2 = 0; index2 < 4; ++index2)
                {
                    saveData.slot[index1].job[index2] = new pspo2seForm.jobClass();
                    saveData.slot[index1].job[index2].level = 0;
                    saveData.slot[index1].job[index2].exp = 0;
                    saveData.slot[index1].job[index2].extendpoints = 0;
                    saveData.slot[index1].job[index2].extendpointsused = 0;
                }
                saveData.slot[index1].inventory = new pspo2seForm.inventoryClass();
                saveData.slot[index1].inventory.itemsUsed = 0;
                for (int index2 = 0; index2 < 60; ++index2)
                {
                    saveData.slot[index1].inventory.item[index2] = new pspo2seForm.inventoryItemClass();
                    saveData.slot[index1].inventory.item[index2].used = false;
                    saveData.slot[index1].inventory.item[index2].type = pspo2seForm.itemType.free_slot;
                    saveData.slot[index1].inventory.item[index2].hex = "";
                    saveData.slot[index1].inventory.item[index2].element = pspo2seForm.elementType.Neutral;
                    saveData.slot[index1].inventory.item[index2].percent = 0;
                    saveData.slot[index1].inventory.item[index2].qty = 0;
                    saveData.slot[index1].inventory.item[index2].qty_max = 0;
                }
            }
            saveData.infinityMissions.itemsUsed = 0;
            for (int index = 0; index < 100; ++index)
                saveData.infinityMissions.slot[index] = new pspo2seForm.infinityMissionClass();
            for (int index = 0; index < 2000; ++index)
            {
                saveData.sharedInventory.item[index] = new pspo2seForm.inventoryItemClass();
                saveData.sharedInventory.item[index].used = false;
                saveData.sharedInventory.item[index].type = pspo2seForm.itemType.free_slot;
                saveData.sharedInventory.item[index].hex = "";
                saveData.sharedInventory.item[index].element = pspo2seForm.elementType.Neutral;
                saveData.sharedInventory.item[index].percent = 0;
                saveData.sharedInventory.item[index].qty = 0;
                saveData.sharedInventory.item[index].qty_max = 0;
            }
            saveData.sharedMeseta = 0L;
        }

        private bool validate_character_file_length(int length)
        {
            if (mainSettings.saveStructureIndex.slot_size == length)
                return true;
            MessageBox.Show("The character file appears to be incorrect", "File Error");
            return false;
        }

        private void refreshFromBuffer()
        {
            if (reloadSaveFile())
                return;
            MessageBox.Show("There was an error reloading the save data from the buffer");
        }

        public void reloadEverything()
        {
            int index = lstSaveSlotView.SelectedItems[0].Index;
            loadSaveFile(true);
            lstSaveSlotView.Items[index].Selected = true;
        }

        private bool reloadSaveFile() => loadSaveFile(false);

        private bool loadSaveFile(bool reload)
        {
            disableMainForm();
            lstSaveSlotView.Items.Clear();
            if (!parseSaveFile(txtFileLoc.Text, reload))
            {
                tabArea.SelectedTab = tabPageInfo;
                tabArea.SelectedIndex = 0;
                inventoryViewPages.SelectedIndex = 0;
                storageViewPages.SelectedIndex = 0;
                tabArea.Enabled = false;
                lstSaveSlotView.Enabled = false;
                showGameImage();
                MessageBox.Show("Invalid file detected [" + txtFileSize.Text + "]", "File Error");
                enableMainForm();
                return false;
            }
            tabArea.Enabled = true;
            lstSaveSlotView.Enabled = true;
            showGameImage();
            if (lstSaveSlotView.Items.Count > 0)
                lstSaveSlotView.Items[0].Selected = true;
            enableMainForm();
            return true;
        }

        public void writeNewLevelData(int newvalue)
        {
            pspo2seForm.expDb_ItemClass expLevelInfoInDb = findExpLevelInfoInDb(newvalue);
            overwriteHexInBuffer(expLevelInfoInDb.level.ToString("X2"), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 232);
            string hex = expLevelInfoInDb.exp.ToString("X4");
            while (hex.Length < 8)
                hex = "0" + hex;
            overwriteHexInBuffer(run.hexAndMathFunction.reversehex(hex, 8), mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index + 240);
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].level = expLevelInfoInDb.level;
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].exp = expLevelInfoInDb.exp;
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].exp_next = expLevelInfoInDb.exp_next;
            saveData.slot[lstSaveSlotView.SelectedItems[0].Index].exp_percent = 0;
            lstSaveSlotView.SelectedItems[0].SubItems[1].Text = "LV" + (object)expLevelInfoInDb.level;
            displaySlotInfo(lstSaveSlotView.SelectedItems[0].Index);
        }

        private void jumpToLevel()
        {
            if (legitVersion())
                return;
            entryForm.oldVal = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].level.ToString();
            entryForm.newVal = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].level.ToString();
            entryForm.description = "character level";
            entryForm.maxLen = 3;
            bool flag = false;
            while (!flag)
            {
                if (entryForm.ShowDialog((IWin32Window)this) == DialogResult.OK)
                {
                    int newvalue = int.Parse(entryForm.newVal);
                    if (newvalue > 200)
                    {
                        MessageBox.Show("Level 200+ is not allowed\r\nThat's just stupid right?");
                    }
                    else if (newvalue < 1)
                    {
                        MessageBox.Show("Level 1 is the lowest");
                    }
                    else
                    {
                        if (newvalue != saveData.slot[lstSaveSlotView.SelectedItems[0].Index].level)
                            writeNewLevelData(newvalue);
                        flag = true;
                    }
                }
                else
                    flag = true;
            }
        }

        private void jumpToTypeLevel()
        {
            if (legitVersion())
                return;
            int index = lstSaveSlotView.SelectedItems[0].Index;
            int selectedIndex = tabControlClasses.SelectedIndex;
            entryForm.oldVal = saveData.slot[index].job[selectedIndex].level.ToString();
            entryForm.newVal = saveData.slot[index].job[selectedIndex].level.ToString();
            entryForm.description = "character type level";
            entryForm.maxLen = 2;
            bool flag = false;
            while (!flag)
            {
                if (entryForm.ShowDialog((IWin32Window)this) == DialogResult.OK)
                {
                    int level = int.Parse(entryForm.newVal);
                    if (level > 30 + saveData.slot[index].rebirth.additionalTypeLevels)
                    {
                        MessageBox.Show("You cannot enter a level greater than " + (object)(30 + saveData.slot[index].rebirth.additionalTypeLevels) + ".\n\nYou will need to rebirth to increase your max type level.", "Max Level Reached", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (level < 1)
                    {
                        MessageBox.Show("You must enter a level greater than 0.", "Type Level Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        if (level != saveData.slot[index].job[selectedIndex].level)
                        {
                            pspo2seForm.expDb_ItemClass expTypeInfoInDb = findExpTypeInfoInDb(level);
                            int pos1 = mainSettings.saveStructureIndex.type_level_pos + mainSettings.saveStructureIndex.slot_size * index + 4 * selectedIndex;
                            overwriteHexInBuffer(expTypeInfoInDb.level.ToString("X2"), pos1);
                            int pos2 = pos1 + 2;
                            int exp = expTypeInfoInDb.exp;
                            if (exp >= 65536)
                            {
                                exp -= 65536;
                                overwriteHexInBuffer("01", pos2);
                                saveData.slot[index].job[selectedIndex].scramble_exp = 1;
                            }
                            else
                            {
                                overwriteHexInBuffer("00", pos2);
                                saveData.slot[index].job[selectedIndex].scramble_exp = 0;
                            }
                            int pos3 = pos2 + 1;
                            overwriteHexInBuffer(run.hexAndMathFunction.reversehex(exp.ToString("X4"), 4), pos3);
                            int pos4 = mainSettings.saveStructureIndex.type_level_pos + mainSettings.saveStructureIndex.slot_size * index + 16 + selectedIndex * mainSettings.saveStructureIndex.type_extend_size;
                            overwriteHexInBuffer(run.hexAndMathFunction.reversehex(expTypeInfoInDb.extend_points.ToString("X4"), 4), pos4);
                            saveData.slot[index].job[selectedIndex].level = level;
                            saveData.slot[index].job[selectedIndex].exp = expTypeInfoInDb.exp;
                            saveData.slot[index].job[selectedIndex].extendpoints = expTypeInfoInDb.extend_points;
                            saveData.slot[index].job[selectedIndex].exp_to_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next - saveData.slot[index].job[selectedIndex].exp;
                            saveData.slot[index].job[selectedIndex].exp_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next;
                            saveData.slot[index].job[selectedIndex].exp_percent = expTypeInfoInDb.exp_next != 0 ? run.hexAndMathFunction.getPercentage(saveData.slot[index].job[selectedIndex].exp - expTypeInfoInDb.exp, expTypeInfoInDb.exp_next) : 100;
                            displayTypeInfo(index);
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
                int byte_decimal = readByteAndSaveInSaveBuffer(br, reload, "GET DATA", showSaveParseProgress);
                if (stringBuilder2.Length == 0)
                    stringBuilder2.Append(run.hexAndMathFunction.decimalByteConvert(byte_decimal, return_type.ToString()));
                else
                    stringBuilder2.Append(run.hexAndMathFunction.decimalByteConvert(byte_decimal, return_type.ToString()) ?? "");
                if (flag)
                    stringBuilder1.Append(run.hexAndMathFunction.decimalByteConvert(byte_decimal, return_type.ToString()));
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
            string s = run.hexAndMathFunction.reversehex(brGetData(4, br, pos, pspo2seForm.saveInfoDataType.hex, reload, showSaveParseProgress), 8);
            if (debugHelper != "")
            {
                MessageBox.Show("[" + debugHelper + "]\r\nhex is " + s + "\r\nint32 is" + (object)int.Parse(s, NumberStyles.HexNumber));
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
            string s = run.hexAndMathFunction.reversehex(brGetData(bytes, br, pos, pspo2seForm.saveInfoDataType.hex, reload, showSaveParseProgress), bytes * 2);
            if (debugHelper != "")
            {
                MessageBox.Show("[" + debugHelper + "]\r\nhex is " + s + "\r\nint is" + (object)int.Parse(s, NumberStyles.HexNumber));
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
            brGetData(bytes, br, pos, pspo2seForm.saveInfoDataType.hex, reload, showSaveParseProgress);
        }

        public unsafe pspo2seForm.inventoryItemClass brGetItem(
          int* pos,
          BinaryReader br,
          bool reload)
        {
            pspo2seForm.inventoryItemClass inventoryItemClass = new pspo2seForm.inventoryItemClass()
            {
                id = *pos,
                hex = brGetData(4, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true)
            };
            inventoryItemClass.hex_reversed = run.hexAndMathFunction.reversehex(inventoryItemClass.hex, 8);
            if (inventoryItemClass.hex == "00000000" || inventoryItemClass.hex == "FFFFFFFF")
            {
                inventoryItemClass.type = pspo2seForm.itemType.free_slot;
                inventoryItemClass.used = false;
            }
            else
            {
                inventoryItemClass.type = getItemTypeFromHex(inventoryItemClass.hex);
                inventoryItemClass.used = true;
            }
            if (inventoryItemClass.type == pspo2seForm.itemType.Weapon)
            {
                brSkipBytes(4, pos, br, reload, true);
                inventoryItemClass.ability = (pspo2seForm.abilityType)brGetInt(1, pos, br, reload, true);
                string data1 = brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                inventoryItemClass.spcl_effect = hexToEffect(data1);
                inventoryItemClass.inf_extended = (pspo2seForm.itemInfExtendType)int.Parse(data1.Substring(1, 1), NumberStyles.HexNumber);
                inventoryItemClass.spcl_effect_info = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                string data2 = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                inventoryItemClass.power_add = int.Parse(run.hexAndMathFunction.reversehex(data2, 4), NumberStyles.HexNumber);
                string data3 = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
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
                inventoryItemClass.qty = brGetInt32(pos, br, reload, true);
                inventoryItemClass.qty_max = brGetInt32(pos, br, reload, true);
                brSkipBytes(2, pos, br, reload, true);
                string data = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                inventoryItemClass.grinds = int.Parse(data.Substring(0, 1), NumberStyles.HexNumber);
                inventoryItemClass.extended = int.Parse(data.Substring(1, 1), NumberStyles.HexNumber);
                inventoryItemClass.locked = false;
                if (int.Parse(data.Substring(2, 1), NumberStyles.HexNumber) != 0)
                    inventoryItemClass.locked = true;
                inventoryItemClass.rarity = int.Parse(data.Substring(3, 1), NumberStyles.HexNumber);
            }
            inventoryItemClass.pa_level = brGetInt(1, pos, br, reload, true);
            inventoryItemClass.element = (pspo2seForm.elementType)inventoryItemClass.pa_level;
            inventoryItemClass.percent = brGetInt(1, pos, br, reload, true);
            inventoryItemClass.style = (pspo2seForm.weaponStyleType)brGetInt(1, pos, br, reload, true);
            if (inventoryItemClass.type == pspo2seForm.itemType.Weapon)
                inventoryItemClass.hand = (pspo2seForm.weaponHandType)brGetInt(1, pos, br, reload, true);
            else
                inventoryItemClass.clothes_man = (pspo2seForm.clothesManufacturerType)brGetInt(1, pos, br, reload, true);
            pspo2seForm.itemDb_ItemClass itemDbItemClass = new pspo2seForm.itemDb_ItemClass();
            pspo2seForm.itemDb_ItemClass itemInDb = findItemInDb(inventoryItemClass.hex_reversed);
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
            ++chunkPos;
            int num1 = 0;
            if (!reload)
            {
                try
                {
                    num1 = (int)br.ReadByte();
                    if (savedata_decimal_array_filled < 301352)
                    {
                        savedata_decimal_array[savedata_decimal_array_filled] = num1;
                        ++savedata_decimal_array_filled;
                    }
                    else
                    {
                        MessageBox.Show("Buffer is full, trying to load a save file that is not PSPo2?", "Fatal Error!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to read byte, check to see if the end of the file is reached\r\n" + (object)ex, "Fatal Error");
                }
                if (showSaveParseProgress && chunkPos >= 1024)
                {
                    chunkPos = 0;
                    toolStripStatusLabel.Text = "Parsing Save " + (object)run.hexAndMathFunction.getPercentage(savedata_decimal_array_filled, toolStripProgressBar.Maximum) + "%";
                    toolStripProgressBar.Value = savedata_decimal_array_filled;
                    Application.DoEvents();
                }
            }
            else
            {
                try
                {
                    num1 = savedata_decimal_array[savedata_decimal_array_read_pos];
                    ++savedata_decimal_array_read_pos;
                }
                catch
                {
                    MessageBox.Show("trying to read past buffer[" + (object)savedata_decimal_array_filled + "] at " + (object)savedata_decimal_array_read_pos + " from " + debugHelper);
                }
                if (showSaveParseProgress && chunkPos >= 1024)
                {
                    chunkPos = 0;
                    toolStripStatusLabel.Text = "Parsing Save " + (object)run.hexAndMathFunction.getPercentage(savedata_decimal_array_read_pos, toolStripProgressBar.Maximum) + "%";
                    toolStripProgressBar.Value = savedata_decimal_array_read_pos;
                    Application.DoEvents();
                }
            }
            return num1;
        }

        public bool overwriteHexInBuffer(string hex, int pos)
        {
            if (hex.Length / 2 + pos > savedata_decimal_array_filled)
            {
                MessageBox.Show("trying to overwrite hex " + hex + " over the end of the buffer " + (object)savedata_decimal_array_filled);
            }
            string[] strArray = run.hexAndMathFunction.addCommasToHex(hex).Split(',');
            int index = pos;
            foreach (string s in strArray)
            {
                if (index > pos + hex.Length)
                {
                    MessageBox.Show("something went wrong with overwriting hex in the buffer");
                    return false;
                }
                savedata_decimal_array[index] = (int)byte.Parse(s, NumberStyles.HexNumber);
                ++index;
            }
            return true;
        }

        public void writeToSaveBuffer(int pos, int[] bytearray, int size, int[] bytestoadd)
        {
            if (pos + size > savedata_decimal_array_filled)
            {
                MessageBox.Show("Trying to save bytes beyond the loaded buffer", "Fatal Error!");
            }
            else
            {
                for (int index = 0; index < size; ++index)
                    bytearray[pos] = bytestoadd[index];
            }
        }

        public void brWriteFromBuffer(BinaryWriter writer, int posStart, int len)
        {
            if (len + posStart <= savedata_decimal_array_filled)
            {
                for (int index = posStart; index < posStart + len; ++index)
                    writer.Write((byte)savedata_decimal_array[index]);
            }
            else
            {
                MessageBox.Show("Tried to write a file [" + (object)len + "] larger than the buffer [" + (object)savedata_decimal_array_filled + "]", "Fatal Error!");
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
            if (legitVersion())
                saveFileDialog.Title = "PSPo2 Save Viewer: Save File";
            saveFileDialog.Filter = ext_options;
            saveFileDialog.RestoreDirectory = true;
            return saveFileDialog.ShowDialog() == DialogResult.OK ? fixFileNameNoExt(saveFileDialog.FileName, ext_options) : (string)null;
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
                path = openSaveDialogue(ext_options, fileNameDefault);
            if (path == null)
                return false;
            string dest = path;
            try
            {
                if (mainSettings.saveStructureIndex.encrypted && isSaveFile)
                    path = "data\\temp\\denc.bin";
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter((Stream)fileStream))
                    {
                        if (addinteger != 0)
                            writer.Write((byte)addinteger);
                        brWriteFromBuffer(writer, startpos, size);
                        writer.Close();
                    }
                    fileStream.Close();
                }
            }
            catch
            {
                MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return !mainSettings.saveStructureIndex.encrypted || !isSaveFile || encryptSaveFile(path, dest);
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
                fn = openSaveDialogue(ext_options, itemName);
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
                                    string str = run.hexAndMathFunction.decimalByteConvert(savedata_decimal_array[startpos + index], "hex");
                                    string s = str.Length >= 2 ? "0" + str.Substring(1, 1) : "0" + str;
                                    writer.Write(byte.Parse(s, NumberStyles.HexNumber));
                                }
                                else
                                    brWriteFromBuffer(writer, startpos + index, 1);
                                if (delete)
                                    savedata_decimal_array[startpos + index] = 0;
                            }
                            writer.Close();
                        }
                        fileStream.Close();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                        disableMainForm();
                        if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + fn, "data/temp\\", fn))
                        {
                            if (System.IO.File.OpenRead("data/temp\\" + fn).Length != byteSize)
                            {
                                MessageBox.Show(fn + " which was downloaded appears to be corrupt, please try again!", "Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            else
                            {
                                System.IO.File.Copy("data/temp\\" + fn, fn);
                                MessageBox.Show(fn + " downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                flag1 = false;
                                flag2 = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(fn + " failed to download, please check your internet connection\r\nor the site may be down!", "Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        enableMainForm();
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
            disableMainForm();
            if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/databases/version.bin", "data/temp/", "Update Check"))
            {
                if (checkVersionTxt(download) && download)
                    action_loadDatabases();
            }
            else
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            enableMainForm();
        }

        private void checkImagesUpdate(bool download)
        {
            disableMainForm();
            string progressTxt = "";
            string str1 = "image_pack_version.bin";
            if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str1, "data/temp/", "Update Check"))
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/temp/" + str1, FileMode.Open, FileAccess.Read))))
                    {
                        string str2;
                        if ((str2 = streamReader.ReadLine()) != null)
                            progressTxt = str2;
                        streamReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "checkImagesUpdate failed to parse new info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    toolStripStatusLabel.Text = "Update Failed";
                    enableMainForm();
                    return;
                }
                string str3 = "";
                try
                {
                    using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/" + str1, FileMode.Open, FileAccess.Read))))
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
                                enableMainForm();
                                break;
                            case DialogResult.Yes:
                                if (!downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + progressTxt, "data/temp/", progressTxt))
                                {
                                    toolStripStatusLabel.Text = "Update Failed";
                                    break;
                                }
                                toolStripStatusLabel.Text = "Unzipping Images";
                                try
                                {
                                    Directory.Delete("data/weapon_images/", true);
                                }
                                catch
                                {
                                }
                                ZipUtil.UnZipFiles("data/temp/" + progressTxt, "data/", "", true);
                                toolStripStatusLabel.Text = "Cleaning Up";
                                System.IO.File.Delete("data/image_pack_version.bin");
                                System.IO.File.Move("data/temp/image_pack_version.bin", "data/image_pack_version.bin");
                                System.IO.File.Delete("data/temp/image_pack_version.bin");
                                toolStripStatusLabel.Text = "Completed: Image Pack Update";
                                loadImageFloaterImages();
                                enableMainForm();
                                MessageBox.Show("The image pack was updated successfully", "Image Pack Update Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                break;
                            case DialogResult.No:
                                enableMainForm();
                                break;
                            default:
                                MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                enableMainForm();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is a new version of the image pack available.\r\nChoose update from the the images menu to install the latest version", "New Image Pack Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    if (!firstboot)
                    {
                        MessageBox.Show("The latest version of the image pack is already installed.", "Image pack is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    enableMainForm();
                }
            }
            else
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Image Pack Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void checkAppUpdate(bool download)
        {
            disableMainForm();
            string newVersion = "";
            string str1 = "latest_version.bin";
            if (legitVersion())
                str1 = "latest_version_viewer.bin";
            if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str1, "data/temp/", "Update Check"))
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/temp/" + str1, FileMode.Open, FileAccess.Read))))
                    {
                        string str2;
                        if ((str2 = streamReader.ReadLine()) != null)
                            newVersion = str2;
                        streamReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "checkAppUpdate failed to parse new info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    toolStripStatusLabel.Text = "Update Failed";
                    enableMainForm();
                    return;
                }
                if ("3.0 build 1008" != newVersion)
                {
                    if (download)
                    {
                        updateViewer.formSetup(newVersion);
                        switch (updateViewer.ShowDialog((IWin32Window)this))
                        {
                            case DialogResult.Cancel:
                                enableMainForm();
                                break;
                            case DialogResult.Yes:
                                string str2 = !legitVersion() ? "PSPo2 Save Editor" : "PSPo2 Save Viewer";
                                if (!downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str2 + " v" + newVersion + ".zip", "data/temp/", str2 + " v" + newVersion + ".zip", str2 + " new.zip"))
                                {
                                    toolStripStatusLabel.Text = "Update Failed";
                                    enableMainForm();
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
                                enableMainForm();
                                break;
                            default:
                                MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                enableMainForm();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is a new version of the application available.\r\nChoose update from the the file menu to install v" + newVersion, "New version available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    if (!firstboot)
                    {
                        MessageBox.Show("The latest version (" + newVersion + ") is already installed.", "Application is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    enableMainForm();
                }
            }
            else
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                enableMainForm();
            }
        }

        private bool checkVersionTxt(bool download)
        {
            int index1 = 0;
            int index2 = 0;
            toolStripStatusLabel.Text = "Checking Version";
            Application.DoEvents();
            pspo2seForm.updateCSVInfo[] updateCsvInfoArray1 = new pspo2seForm.updateCSVInfo[20];
            try
            {
                string encryptionKey = run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/temp/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(encryptionKey, fs)))
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
                MessageBox.Show("checkVersionTxt failed to load new info:\r\n " + ex.Message);
                toolStripStatusLabel.Text = "Update Failed";
                return false;
            }
            Application.DoEvents();
            pspo2seForm.updateCSVInfo[] updateCsvInfoArray2 = new pspo2seForm.updateCSVInfo[20];
            try
            {
                string encryptionKey = run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(encryptionKey, fs)))
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
                    MessageBox.Show("checkVersionTxt failed to load cur info [" + (object)index2 + "/" + (object)20 + "]:\r\n " + ex.Message);
                    toolStripStatusLabel.Text = "Update Failed";
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
                MessageBox.Show("The application seems to be out of date.\r\nThe latest database files are incompatible with this version\r\n\r\nPlease update the application first");
                toolStripStatusLabel.Text = "Update Failed";
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
                                    MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                    return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There are new database updates available.\r\nChoose update from the database menu to install them", "Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                    }
                    if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/databases/" + updateCsvInfoArray1[index3].fn, "data/databases/", updateCsvInfoArray1[index3].fn))
                    {
                        text = text + updateCsvInfoArray1[index3].fn + " [Updated to " + updateCsvInfoArray1[index3].ver + "]\r\n";
                        flag1 = true;
                    }
                    else
                    {
                        toolStripStatusLabel.Text = "Update Failed";
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
            toolStripStatusLabel.Text = "Update Complete";
            MessageBox.Show(text, "Database Update Results", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return true;
        }

        public bool downloadFile(string url, string dirdest, string progressTxt, string saveas = "")
        {
            if (!allowDownload)
            {
                MessageBox.Show("Please wait for the current download to finish", "Download already in progress", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            allowDownload = false;
            downloadedData = new byte[512000];
            downloadedDataName = "";
            try
            {
                WebResponse response = WebRequest.Create(url).GetResponse();
                Stream responseStream = response.GetResponseStream();
                int contentLength = (int)response.ContentLength;
                toolStripProgressBar.Maximum = contentLength;
                toolStripProgressBar.Value = 0;
                for (int index = 3; index < url.Length; ++index)
                {
                    if (url.Substring(url.Length - index, 1) == "/")
                    {
                        downloadedDataName = url.Substring(url.Length - index + 1, url.Length - (url.Length - index) - 1);
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
                            toolStripProgressBar.Value = toolStripProgressBar.Maximum;
                            toolStripStatusLabel.Text = "Completed: " + progressTxt + " " + (object)run.hexAndMathFunction.getPercentage(toolStripProgressBar.Value, contentLength) + "%";
                            Application.DoEvents();
                            downloadedData = memoryStream.ToArray();
                            responseStream.Close();
                            memoryStream.Close();
                            goto label_14;
                        }
                        else
                            memoryStream.Write(buffer, 0, count);
                    }
                    while (toolStripProgressBar.Value + count > toolStripProgressBar.Maximum);
                    toolStripProgressBar.Value += count;
                    toolStripStatusLabel.Text = "Downloading: " + progressTxt + " " + (object)run.hexAndMathFunction.getPercentage(toolStripProgressBar.Value, contentLength) + "%";
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                allowDownload = true;
                return false;
            }
        label_14:
            if (saveas != "")
                downloadedDataName = saveas;
            FileStream fileStream = new FileStream(dirdest + downloadedDataName, FileMode.Create);
            fileStream.Write(downloadedData, 0, downloadedData.Length);
            fileStream.Close();
            allowDownload = true;
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
                            MessageBox.Show("Heal type item type not recognised for image: " + hex_reversed.Substring(3, 1));
                            return pspo2seForm.greenItemType.none;
                    }
                case "3":
                    return pspo2seForm.greenItemType.calorie;
                case "4":
                    return pspo2seForm.greenItemType.item;
                default:
                    MessageBox.Show("Green item type not recognised for image: " + hex_reversed.Substring(5, 1));
                    return pspo2seForm.greenItemType.none;
            }
        }

        public pspo2seForm.itemDb_ItemClass findItemInDb(string hex)
        {
            pspo2seForm.itemDb_ItemClass itemDbItemClass = new pspo2seForm.itemDb_ItemClass();
            for (int index = 0; index < item_db_filled; ++index)
            {
                if (hex == item_db.item[index].hex)
                    return item_db.item[index];
            }
            return itemDbItemClass;
        }

        public string weaponEnumToName(pspo2seForm.weaponType type)
        {
            string name = enumToName(string.Concat((object)type));
            return !(name.Substring(name.Length - 1, 1) == "s") ? name + "s" : "Twin " + name;
        }

        public string enumToName(string type) => run.hexAndMathFunction.stringToProper(type.Replace("_", " "));

        public void addItemToDb(string csvLine)
        {
            string[] strArray = csvLine.Split('|');
            item_db.item[item_db_filled] = new pspo2seForm.itemDb_ItemClass();
            item_db.item[item_db_filled].id = strArray[0];
            item_db.item[item_db_filled].hex = strArray[1];
            item_db.item[item_db_filled].name = strArray[2];
            item_db.item[item_db_filled].name_jp = strArray[3];
            item_db.item[item_db_filled].desc = strArray[4];
            item_db.item[item_db_filled].desc_jp = strArray[5];
            item_db.item[item_db_filled].infinity_item = strArray[6];
            try
            {
                item_db.item[item_db_filled].power = int.Parse(strArray[7]);
            }
            catch
            {
                databasesOk = false;
                MessageBox.Show("row 7 [" + (object)item_db_filled + "] incorrect format " + strArray[7]);
            }
            try
            {
                item_db.item[item_db_filled].acc = int.Parse(strArray[8]);
            }
            catch
            {
                databasesOk = false;
                MessageBox.Show("row 8 [" + (object)item_db_filled + "] incorrect format " + strArray[8]);
            }
            item_db.item[item_db_filled].level = strArray[9];
            try
            {
                item_db.item[item_db_filled].ext_power = int.Parse(strArray[10]);
            }
            catch
            {
                databasesOk = false;
                MessageBox.Show("row 10 [" + (object)item_db_filled + "] incorrect format " + strArray[10]);
            }
            try
            {
                item_db.item[item_db_filled].ext_acc = int.Parse(strArray[11]);
            }
            catch
            {
                databasesOk = false;
                MessageBox.Show("row 11 [" + (object)item_db_filled + "] incorrect format " + strArray[11]);
            }
            item_db.item[item_db_filled].ext_level = strArray[12];
            try
            {
                item_db.item[item_db_filled].inf_ext_power = int.Parse(strArray[13]);
            }
            catch
            {
                databasesOk = false;
                MessageBox.Show("row 13 [" + (object)item_db_filled + "] incorrect format " + strArray[13]);
            }
            try
            {
                item_db.item[item_db_filled].inf_ext_acc = int.Parse(strArray[14]);
            }
            catch
            {
                databasesOk = false;
                MessageBox.Show("row 14 [" + (object)item_db_filled + "] incorrect format " + strArray[14]);
            }
            item_db.item[item_db_filled].inf_ext_level = strArray[15];
            item_db.item[item_db_filled].special = strArray[16];
            item_db.item[item_db_filled].special_level = strArray[17];
            item_db.item[item_db_filled].ext_special_level = strArray[18];
            if (item_db.item[item_db_filled].ext_special_level == "")
                item_db.item[item_db_filled].ext_special_level = item_db.item[item_db_filled].special_level;
            if (item_db.item[item_db_filled].ext_special_level == "0")
                item_db.item[item_db_filled].ext_special_level = "";
            if (item_db.item[item_db_filled].special_level == "0")
                item_db.item[item_db_filled].special_level = "";
            try
            {
                item_db.item[item_db_filled].rarity = int.Parse(strArray[19]);
            }
            catch
            {
                databasesOk = false;
                MessageBox.Show("row 19 [" + (object)item_db_filled + "] incorrect format " + strArray[19]);
            }
            ++item_db_filled;
        }

        public void loadItemDatabase()
        {
            item_db_filled = 0;
            try
            {
                string encryptionKey = run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/items.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string csvLine;
                    while ((csvLine = streamReader.ReadLine()) != null)
                        addItemToDb(csvLine);
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                databasesOk = false;
                MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Item Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            hex = run.hexAndMathFunction.reversehex(hex, 4);
            int num1 = int.Parse(hex, NumberStyles.HexNumber);
            if (num1 < 256 || num1 > 1138)
            {
                MessageBox.Show("Error, slot type integer not supported [" + hex + ":" + (object)num1 + "]");
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
                    MessageBox.Show("weapon manufacturer not supported: " + (object)manufacturer);
                    return (Image)null;
            }
        }

        private void displayWeaponManufacturerImage(
          pspo2seForm.pageFields fields,
          pspo2seForm.weaponManufacturerType manufacturer)
        {
            fields.img_manufaturer.Visible = true;
            Image manufacturerImage = getWeaponManufacturerImage(manufacturer);
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
                    MessageBox.Show("clothes manufacturer not supported: " + (object)manufacturer);
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
            Image weaponImageFromType = getWeaponImageFromType(weapon);
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
                            MessageBox.Show("Unsupported " + (object)item_type + " type: " + (object)clothesTypes);
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
                            MessageBox.Show("Unsupported " + (object)item_type + " type: " + (object)partsTypes);
                            fields.img_item.Visible = false;
                            return;
                    }
                default:
                    MessageBox.Show("Tried to get clothes type from a non-clothing item: " + (object)clothes_type);
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
                    displayWeaponImage(fields, getWeaponTypeFromHex(item.hex_reversed));
                    displayWeaponManufacturerImage(fields, getWeaponManufacturerFromHex(item.hex_reversed));
                    break;
                case pspo2seForm.itemType.Armor:
                    displayWeaponImage(fields, pspo2seForm.weaponType.armor);
                    displayWeaponManufacturerImage(fields, getWeaponManufacturerFromHex(item.hex_reversed));
                    break;
                case pspo2seForm.itemType.Green_Item:
                    switch (getGreenItemTypeFromHex(item.hex_reversed))
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
                            MessageBox.Show("Green item type not recognised for image: " + (object)getGreenItemTypeFromHex(item.hex_reversed));
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
                    displaySlotUnitImage(fields, getSlotTypeFromHex(item.hex_reversed));
                    displayWeaponManufacturerImage(fields, getWeaponManufacturerFromHex(item.hex_reversed));
                    break;
                case pspo2seForm.itemType.Clothes_human:
                    displayClothesImage(fields, pspo2seForm.itemType.Clothes_human, getClothesTypeFromHex(item.hex_reversed));
                    displayClothesManufacturerImage(fields, item.clothes_man);
                    break;
                case pspo2seForm.itemType.Clothes_android:
                    displayClothesImage(fields, pspo2seForm.itemType.Clothes_android, getClothesTypeFromHex(item.hex_reversed));
                    displayClothesManufacturerImage(fields, item.clothes_man);
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
                            MessageBox.Show("Trap type is wrong for image, is this even a trap?");
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
                    MessageBox.Show("item type not recognised for image: " + (object)item.type);
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
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
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
                        MessageBox.Show("Extend integer " + (object)extend_integer + " is not recognised for psp2i extend type");
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
                        MessageBox.Show("Extend integer " + (object)extend_integer + " is not recognised for psp2 extend type");
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
            pspo2seForm.pageFields pageFields = getPageFields(page);
            bool flag = false;
            pspo2seForm.inventoryItemClass inventoryItemClass;
            if (page == tabPageStorage)
            {
                if (storageView.SelectedItems.Count > 0)
                {
                    inventoryItemClass = saveData.sharedInventory.item[int.Parse(storageView.SelectedItems[0].SubItems[1].Text)];
                    inventoryItemClass.qty_max = 999;
                    flag = true;
                }
                else
                    inventoryItemClass = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[0];
            }
            else if (inventoryView.SelectedItems.Count > 0)
            {
                inventoryItemClass = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(inventoryView.SelectedItems[0].SubItems[1].Text)];
                flag = true;
            }
            else
                inventoryItemClass = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.item[0];
            if (!inventoryItemClass.used)
            {
                inventoryItemClass.name = "---- Free Slot ----";
                inventoryItemClass.rarity = -1;
                inventoryItemClass.type = pspo2seForm.itemType.free_slot;
            }
            pageFields.txt_hex.Text = "0x" + inventoryItemClass.hex_reversed;
            pageFields.txt_name.Text = inventoryItemClass.name;
            pageFields.txt_name_jp.Text = inventoryItemClass.name_jp;
            showButtons(pageFields, inventoryItemClass.type);
            displayItemImage(pageFields, inventoryItemClass);
            displayItemStars(pageFields, inventoryItemClass.rarity);
            displayItemInfo(pageFields, inventoryItemClass);
            if (!flag)
                return;
            changeImageFloater(inventoryItemClass.hex_reversed);
        }

        private void displayWeaponExtendInfo(
          pspo2seForm.pageFields fields,
          pspo2seForm.inventoryItemClass item)
        {
            pspo2seForm.weaponType weaponTypeFromHex = getWeaponTypeFromHex(item.hex_reversed);
            pspo2seForm.itemExtendType weaponExtendType = getWeaponExtendType(item.extended, item.style, weaponTypeFromHex);
            string str1 = "FULL";
            if (item.inf_extended == pspo2seForm.itemInfExtendType.extended)
                str1 = "EXT FULL";
            else if (item.inf_extended == pspo2seForm.itemInfExtendType.not_extended_special)
                str1 = "FULL";
            else if (item.inf_extended == pspo2seForm.itemInfExtendType.extended_special)
                str1 = "EXT FULL";
            else if (item.inf_extended != pspo2seForm.itemInfExtendType.not_extended)
            {
                MessageBox.Show("Unknown infinity extend type: " + (object)item.inf_extended);
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
                    MessageBox.Show("Unhandled extend type: " + (object)item.extended);
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
                        fields.txt_atk.Text = "TEC  " + (object)(int)((Decimal)(item.power + item.ext_power + grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
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
                    fields.txt_atk.Text = "ATK  " + (object)(int)((Decimal)(item.power + grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity) + item.ext_power) * num3);
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
                        fields.txt_atk.Text = "TEC  " + (object)(int)((Decimal)(item.power + item.ext_power + item.inf_ext_power + grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
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
                    fields.txt_atk.Text = "ATK  " + (object)(int)((Decimal)(item.power + item.ext_power + item.inf_ext_power + grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
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
                        fields.txt_atk.Text = "TEC  " + (object)(int)((Decimal)(item.power + grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
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
                    fields.txt_atk.Text = "ATK  " + (object)(int)((Decimal)(item.power + grindsToPowIncrease(getWeaponTypeFromHex(item.hex_reversed), item.grinds, item.rarity)) * num3);
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
                    item.special = getElementSpecialAsString(item.element);
                if (str1 == "FULL" || str1 == "EXT FULL")
                    fields.txt_special.Text = "Ability  " + item.special + " " + item.ext_special_level + " " + abilityToJp(stringToAbilityEnum(item.special)) + " [Extended]";
                else
                    fields.txt_special.Text = "Ability  " + item.special + " " + item.special_level + " " + abilityToJp(stringToAbilityEnum(item.special));
            }
            else if (item.ability != pspo2seForm.abilityType.None)
            {
                string str2 = item.ability.ToString().Replace("_", " ");
                if (item.style == pspo2seForm.weaponStyleType.Tech)
                    str2 = (item.ability + 21).ToString().Replace("_", " ");
                if (str1 == "FULL" || str1 == "EXT FULL")
                    fields.txt_special.Text = "Ability  " + str2.Replace("Empow", "Empow.") + " " + item.ext_special_level + " " + abilityToJp(stringToAbilityEnum(str2)) + " [Extended]";
                else
                    fields.txt_special.Text = "Ability  " + str2.Replace("Empow", "Empow.") + " " + item.special_level + " " + abilityToJp(stringToAbilityEnum(str2));
            }
            else
                fields.txt_special.Text = "Ability  None (なし)";
        }

        private int grindsToPowIncrease(pspo2seForm.weaponType weapon, int grinds, int rarity) => 0;

        public string elementToSubEnemyType(pspo2seForm.elementType element)
        {
            string[] infinityEnemy = intToInfinityEnemy((int)element);
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
                    displayElementImage(fields, item.element);
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
                                int num = int.Parse(run.hexAndMathFunction.reversehex(item.spcl_effect_info, 4), NumberStyles.HexNumber);
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
                    displayWeaponExtendInfo(fields, item);
                    break;
                case pspo2seForm.itemType.Armor:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = true;
                    fields.txt_name.Padding = new Padding(13, 0, 0, 0);
                    fields.img_item.Padding = new Padding(13, 0, 0, 0);
                    fields.txt_qty.Visible = false;
                    fields.txt_atk.Visible = true;
                    fields.txt_acc.Visible = true;
                    displayElementImage(fields, item.element);
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
                    if (item.special == elementToSubEnemyType(item.element))
                    {
                        fields.txt_atk.Text = "Main Enemy  " + elementToSubEnemyType(pspo2seForm.elementType.Neutral);
                        fields.txt_acc.Text = "Sub Enemy  " + elementToSubEnemyType(pspo2seForm.elementType.Fire);
                    }
                    else
                    {
                        fields.txt_atk.Text = "Main Enemy  " + item.special;
                        fields.txt_acc.Text = "Sub Enemy  " + elementToSubEnemyType(item.element);
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
                        fields.txt_qty.Text = "LV" + (object)(item.pa_level + 1) + " (" + getSlotPALearntLevel(lstSaveSlotView.SelectedItems[0].Index, item.hex) + ")";
                        break;
                    }
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = true;
                    fields.txt_name.Padding = new Padding(26, 0, 0, 0);
                    fields.img_item.Padding = new Padding(13, 0, 0, 0);
                    fields.txt_qty.Visible = true;
                    displayElementImage(fields, item.element);
                    fields.txt_percent.Visible = true;
                    fields.txt_grinds.Visible = true;
                    fields.txt_special.Visible = true;
                    fields.txt_effect.Visible = true;
                    fields.txt_atk.Visible = true;
                    fields.txt_acc.Visible = true;
                    MessageBox.Show("Type not dealt with in displayItemInfo() " + txtInventoryHex.Text);
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
            ArrayList arrayList = ArrayList.Adapter((IList)saveData.slot[slotnum].inventory.item);
            arrayList.Sort();
            saveData.slot[slotnum].inventory.item = (pspo2seForm.inventoryItemClass[])arrayList.ToArray(typeof(pspo2seForm.inventoryItemClass));
        }

        private void sortStorage()
        {
            ArrayList arrayList = ArrayList.Adapter((IList)saveData.sharedInventory.item);
            arrayList.Sort();
            saveData.sharedInventory.item = (pspo2seForm.inventoryItemClass[])arrayList.ToArray(typeof(pspo2seForm.inventoryItemClass));
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
                    MessageBox.Show("page: " + (object)page + "not handled in allowShowItem()");
                    break;
            }
            return false;
        }

        private void displayInventory(int slotnum, int page)
        {
            inventoryView.SelectedItems.Clear();
            inventoryView.Items.Clear();
            sortInventory(slotnum);
            picWeaponSlot01.Image = (Image)null;
            picWeaponSlot02.Image = (Image)null;
            picWeaponSlot03.Image = (Image)null;
            picWeaponSlot04.Image = (Image)null;
            picWeaponSlot05.Image = (Image)null;
            picWeaponSlot06.Image = (Image)null;
            int index1 = -1;
            for (int index2 = 0; index2 < 60; ++index2)
            {
                pspo2seForm.inventoryItemClass inventoryItemClass1 = new pspo2seForm.inventoryItemClass();
                pspo2seForm.inventoryItemClass inventoryItemClass2 = saveData.slot[slotnum].inventory.item[index2];
                if (inventoryItemClass2.type == pspo2seForm.itemType.Weapon && inventoryItemClass2.equipped_slot > 0)
                {
                    int index3 = (int)(getWeaponTypeFromHex(inventoryItemClass2.hex_reversed) - 1 + (int)inventoryItemClass2.element * 28);
                    switch (inventoryItemClass2.equipped_slot)
                    {
                        case 1:
                            picWeaponSlot01.Image = imageListWeaponElements.Images[index3];
                            break;
                        case 2:
                            picWeaponSlot02.Image = imageListWeaponElements.Images[index3];
                            break;
                        case 3:
                            picWeaponSlot03.Image = imageListWeaponElements.Images[index3];
                            break;
                        case 4:
                            picWeaponSlot04.Image = imageListWeaponElements.Images[index3];
                            break;
                        case 5:
                            picWeaponSlot05.Image = imageListWeaponElements.Images[index3];
                            break;
                        case 6:
                            picWeaponSlot06.Image = imageListWeaponElements.Images[index3];
                            break;
                    }
                }
                if (allowShowItem(page, inventoryItemClass2))
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
                    inventoryView.Items.Add(new ListViewItem()
                    {
                        Text = str,
                        ImageIndex = getImageListNumber(inventoryItemClass2),
                        SubItems = {
              string.Concat((object) index2)
            }
                    });
                    if (selectInventoryItemAfterLoad != -1 && inventoryItemClass2.id == selectInventoryItemAfterLoad)
                        index1 = inventoryView.Items.Count - 1;
                }
            }
            tabPageInventory.Text = "Inventory (" + (object)saveData.slot[slotnum].inventory.itemsUsed + "/60)";
            if (index1 != -1)
            {
                inventoryView.Items[index1].Selected = true;
                inventoryView.Items[index1].EnsureVisible();
                selectInventoryItemAfterLoad = -1;
            }
            else
            {
                if (selectInventoryItemAfterLoad == -1)
                    return;
                for (int index2 = 0; index2 < 60; ++index2)
                {
                    if (saveData.slot[slotnum].inventory.item[index2].id == selectInventoryItemAfterLoad)
                    {
                        for (int index3 = 0; index3 < 5; ++index3)
                        {
                            if (allowShowItem(index3 + 1, saveData.slot[slotnum].inventory.item[index2]))
                            {
                                tabArea.SelectedIndex = 2;
                                inventoryViewPages.SelectedIndex = index3;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private int getFreeInventoryItemId(int slot) => saveData.slot[slot].inventory.itemsUsed < 60 ? saveData.slot[slot].inventory.itemsUsed * 36 + 8 + slot * mainSettings.saveStructureIndex.slot_size + mainSettings.saveStructureIndex.inventory_slots_pos : -1;

        private void displaySharedStorage(int page)
        {
            storageView.SelectedItems.Clear();
            storageView.Items.Clear();
            sortStorage();
            saveData.sharedInventory.itemsUsed = 0;
            txtStorageMeseta.Text = string.Concat((object)saveData.sharedMeseta);
            int index1 = -1;
            for (int index2 = 0; index2 < mainSettings.saveStructureIndex.shared_inventory_slots; ++index2)
            {
                if (saveData.sharedInventory.item[index2].type != pspo2seForm.itemType.free_slot)
                    ++saveData.sharedInventory.itemsUsed;
                pspo2seForm.inventoryItemClass inventoryItemClass = saveData.sharedInventory.item[index2];
                if (allowShowItem(page, inventoryItemClass))
                {
                    string text;
                    if (inventoryItemClass.type != pspo2seForm.itemType.free_slot)
                    {
                        text = !(inventoryItemClass.name == "") || !(inventoryItemClass.name_jp != "") ? (!(inventoryItemClass.name == "") ? inventoryItemClass.name + " (" + inventoryItemClass.name_jp + ")" : "Unk_" + inventoryItemClass.hex_reversed) : inventoryItemClass.name_jp;
                        if (getWeaponExtendType(inventoryItemClass.extended, inventoryItemClass.style, getWeaponTypeFromHex(inventoryItemClass.hex_reversed)) == pspo2seForm.itemExtendType.unknown)
                        {
                            MessageBox.Show("unknown extend " + text + " " + inventoryItemClass.hex_reversed);
                        }
                    }
                    else
                        text = "---- Free Slot ----";
                    int imageListNumber = getImageListNumber(inventoryItemClass);
                    storageView.Items.Add(new ListViewItem(text, imageListNumber)
                    {
                        SubItems = {
              string.Concat((object) index2)
            }
                    });
                    if (selectItemAfterLoad != -1 && inventoryItemClass.id == selectItemAfterLoad)
                        index1 = storageView.Items.Count - 1;
                }
            }
            if (index1 != -1)
            {
                storageView.Items[index1].Selected = true;
                storageView.Items[index1].EnsureVisible();
                selectItemAfterLoad = -1;
            }
            else if (selectItemAfterLoad != -1)
            {
                for (int index2 = 0; index2 < mainSettings.saveStructureIndex.shared_inventory_slots; ++index2)
                {
                    if (saveData.sharedInventory.item[index2].id == selectItemAfterLoad)
                    {
                        for (int index3 = 0; index3 < 5; ++index3)
                        {
                            if (allowShowItem(index3 + 1, saveData.sharedInventory.item[index2]))
                            {
                                tabArea.SelectedIndex = 3;
                                storageViewPages.SelectedIndex = index3;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            tabPageStorage.Text = "Shared (" + (object)saveData.sharedInventory.itemsUsed + "/" + (object)mainSettings.saveStructureIndex.shared_inventory_slots + ")";
        }

        private int getImageListNumber(pspo2seForm.inventoryItemClass item)
        {
            int num1 = 1000;
            switch (item.type)
            {
                case pspo2seForm.itemType.Weapon:
                    num1 = (int)(getWeaponTypeFromHex(item.hex_reversed) - 1 + 28 * (int)getItemRankFromRarity(item.rarity));
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
                    num1 = (int)getItemRankFromRarity(item.rarity);
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
                    switch (getGreenItemTypeFromHex(item.hex_reversed))
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
                            MessageBox.Show("Green item type not recognised for image: " + (object)getGreenItemTypeFromHex(item.hex_reversed));
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
                    num1 = (int)(getSlotTypeFromHex(item.hex_reversed) + 15 + (int)getItemRankFromRarity(item.rarity) * 4);
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
                    switch (getClothesTypeFromHex(item.hex_reversed))
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
                    switch (getClothesTypeFromHex(item.hex_reversed))
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
                    inventoryView.SmallImageList = weaponWithRankImageList;
                    break;
                case 2:
                    inventoryView.SmallImageList = armourImageList;
                    break;
                case 3:
                    inventoryView.SmallImageList = itemImageList;
                    break;
                case 4:
                    inventoryView.SmallImageList = clothesImageList;
                    break;
                case 5:
                    inventoryView.SmallImageList = decoImageList;
                    break;
                case 6:
                    inventoryView.SmallImageList = decoImageList;
                    break;
            }
            btnInventoryDelete.Enabled = false;
            btnInventoryImportSelected.Enabled = false;
            btnInventoryExportSelected.Enabled = false;
            chkDeleteExportInventory.Enabled = false;
            btnInventoryDeposit.Enabled = false;
            displayInventory(lstSaveSlotView.SelectedItems[0].Index, page);
            Application.DoEvents();
            switch (page - 1)
            {
                case 0:
                    openImageFloater();
                    break;
                case 1:
                    closeImageFloater();
                    break;
                case 2:
                    closeImageFloater();
                    break;
                case 3:
                    closeImageFloater();
                    break;
                case 4:
                    closeImageFloater();
                    break;
                case 5:
                    closeImageFloater();
                    break;
            }
        }

        private void changeStoragePage(int page)
        {
            btnStorageDelete.Enabled = false;
            btnStorageImportSelected.Enabled = false;
            btnStorageExportSelected.Enabled = false;
            chkDeleteExportStorage.Enabled = false;
            btnStorageWithdraw.Enabled = false;
            displaySharedStorage(page);
            switch (page - 1)
            {
                case 0:
                    storageView.SmallImageList = weaponWithRankImageList;
                    break;
                case 1:
                    storageView.SmallImageList = armourImageList;
                    break;
                case 2:
                    storageView.SmallImageList = itemImageList;
                    break;
                case 3:
                    storageView.SmallImageList = clothesImageList;
                    break;
                case 4:
                    storageView.SmallImageList = decoImageList;
                    break;
                case 5:
                    storageView.SmallImageList = decoImageList;
                    break;
            }
            switch (page - 1)
            {
                case 0:
                    openImageFloater();
                    break;
                case 1:
                    closeImageFloater();
                    break;
                case 2:
                    closeImageFloater();
                    break;
                case 3:
                    closeImageFloater();
                    break;
                case 4:
                    closeImageFloater();
                    break;
                case 5:
                    closeImageFloater();
                    break;
            }
        }

        public string hexToEffect(string hex)
        {
            switch (saveData.type)
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
                    return "hexToEffect invalid save type " + (object)saveData.type;
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
                MessageBox.Show(ex.Message, "Fatal Error!");
            }
            return fileStream;
        }

        private string getGameIdFromSfo(string gameSave)
        {
            FileStream fileStream = openFileRead(Path.Combine(Path.GetDirectoryName(gameSave), "PARAM.SFO"));
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
                MessageBox.Show("SED.exe is missing");
                return false;
            }
            string gameIdFromSfo = getGameIdFromSfo(file);
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
                    MessageBox.Show("Failed to generate the key.\n\nError: " + ex.Message);
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
                MessageBox.Show("SED.exe is missing");
                return false;
            }
            string path = Path.Combine(Path.GetDirectoryName(dest), "PARAM.SFO");
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("PARAM.SFO does not exist in that location.\n\nPlease choose the original location of your save file");
                return false;
            }
            string gameIdFromSfo = getGameIdFromSfo(dest);
            if (!System.IO.File.Exists("data\\keys\\" + gameIdFromSfo + ".bin"))
            {
                MessageBox.Show("You must place the '" + gameIdFromSfo + ".bin' key file in the data\\keys directory.\n\nSearch for SGKeyDumper to obtain the key for your game.");
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
            mainSettings.saveStructureIndex.changeSaveSettingsType(pspo2seForm.SaveType.PSP2);
            mainSettings.saveStructureIndex.encrypted = false;
            if (filelength == (long)mainSettings.saveStructureIndex.total_size || filelength == (long)mainSettings.saveStructureIndex.total_size_enc)
            {
                saveData.set_type(pspo2seForm.SaveType.PSP2);
                if (filelength == (long)mainSettings.saveStructureIndex.total_size_enc)
                    mainSettings.saveStructureIndex.encrypted = true;
                txtFileSize.Text = Convert.ToString(mainSettings.saveStructureIndex.total_size) + " bytes";
                return true;
            }
            mainSettings.saveStructureIndex.changeSaveSettingsType(pspo2seForm.SaveType.PSP2I);
            if (filelength == (long)mainSettings.saveStructureIndex.total_size || filelength == (long)mainSettings.saveStructureIndex.total_size_enc)
            {
                saveData.set_type(pspo2seForm.SaveType.PSP2I);
                if (filelength == (long)mainSettings.saveStructureIndex.total_size_enc)
                    mainSettings.saveStructureIndex.encrypted = true;
                txtFileSize.Text = Convert.ToString(mainSettings.saveStructureIndex.total_size) + " bytes";
                return true;
            }
            saveData.set_type(pspo2seForm.SaveType.NONE);
            txtFileSize.Text = "0 bytes";
            displaySlotInfo(0);
            showGameImage();
            txtFileSize.Text = Convert.ToString(filelength) + " bytes";
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
                savedata_decimal_array[index1] = (int)br.ReadByte();
                ++index1;
            }
            if (type == pspo2seForm.partFileType.inventory)
            {
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    int num = (int)br.ReadByte();
                    savedata_decimal_array[index1] = 0;
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
            if (savedata_decimal_array_filled == 0)
            {
                MessageBox.Show("nothing to load into");
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
                if (legitVersion())
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
            if (type != pspo2seForm.partFileType.infinity_mission && allowMultiSelect && stringList.Count > 60 - saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed)
            {
                MessageBox.Show("You do not have enough slots to import the selected items.", "Not Enough Slots", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            if (allowMultiSelect && type == pspo2seForm.partFileType.infinity_mission && stringList.Count > 100 - saveData.infinityMissions.itemsUsed)
            {
                MessageBox.Show("You do not have enough slots to import the selected items.", "Not Enough Slots", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            foreach (string fileLoc in stringList)
            {
                FileStream fileStream = openFileRead(fileLoc);
                if (fileStream == null)
                    return -1;
                BinaryReader br = new BinaryReader((Stream)fileStream);
                int length = (int)br.BaseStream.Length;
                switch (type)
                {
                    case pspo2seForm.partFileType.character:
                        if (!validate_character_file_length(length))
                        {
                            MessageBox.Show("File does not appear to be a valid character file");
                            fileStream.Close();
                            return -1;
                        }
                        break;
                    case pspo2seForm.partFileType.inventory:
                        if (length != 2161)
                        {
                            MessageBox.Show("File does not appear to be a valid inventory file");
                            fileStream.Close();
                            return -1;
                        }
                        savedata_decimal_array[mainSettings.saveStructureIndex.inventory_slots_used_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index] = (int)br.ReadByte();
                        for (int index1 = 0; index1 < 60; ++index1)
                        {
                            int index2 = startpos + index1 * 36;
                            for (int index3 = 0; index3 < 8; ++index3)
                            {
                                int num = (int)br.ReadByte();
                                savedata_decimal_array[index2] = 0;
                                ++index2;
                            }
                            loadObjectIntoBuffer(br, index2, 20, pspo2seForm.partFileType.inventory);
                        }
                        fileStream.Close();
                        return 1;
                    case pspo2seForm.partFileType.storage:
                        if (length != mainSettings.saveStructureIndex.shared_inventory_slots * 20)
                        {
                            MessageBox.Show("File does not appear to be a valid storage file");
                            fileStream.Close();
                            return -1;
                        }
                        break;
                    case pspo2seForm.partFileType.item:
                        if (length != 20)
                        {
                            MessageBox.Show("File does not appear to be a valid item file");
                            fileStream.Close();
                            return -1;
                        }
                        if (allowMultiSelect)
                        {
                            startpos = getFreeInventoryItemId(lstSaveSlotView.SelectedItems[0].Index);
                            if (startpos < 0)
                            {
                                MessageBox.Show("Error: Trying to load an item but there are no available slots");
                                return -1;
                            }
                            selectInventoryItemAfterLoad = startpos;
                            overwriteHexInBuffer("0000000000000000", startpos + 20);
                            overwriteHexInBuffer("00000000", startpos - 8);
                            ++saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed;
                            string hex = saveData.slot[lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X1");
                            while (hex.Length < 2)
                                hex = "0" + hex;
                            overwriteHexInBuffer(hex, mainSettings.saveStructureIndex.inventory_slots_used_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index);
                            break;
                        }
                        break;
                    case pspo2seForm.partFileType.infinity_mission:
                        if (length != 104)
                        {
                            MessageBox.Show("File does not appear to be a valid infinity mission file");
                            fileStream.Close();
                            return -1;
                        }
                        break;
                    case pspo2seForm.partFileType.infinity_mission_pack:
                        if (length != 10401)
                        {
                            MessageBox.Show("File does not appear to be a valid infinity mission pack file");
                            fileStream.Close();
                            return -1;
                        }
                        break;
                    default:
                        MessageBox.Show("file " + (object)type + " is not supported");
                        fileStream.Close();
                        return -1;
                }
                loadObjectIntoBuffer(br, startpos, length, type);
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
                MessageBox.Show("Requested position " + (object)pos + " is greater than the predicted item pos" + (object)item_position);
                return 0;
            }
            while (num1 < item_position)
                brSkipBytes(1, &num1, br, reload, showSaveParseProgress);
            return num1;
        }

        private unsafe bool parseSaveFile(string fileLoc, bool reload)
        {
            chunkPos = 0;
            FileStream fileStream = (FileStream)null;
            BinaryReader br = (BinaryReader)null;
            if (!reload)
            {
                initSaveBuffer();
                initSlotVars();
                fileStream = openFileRead(fileLoc);
                if (fileStream == null)
                    return false;
                br = new BinaryReader((Stream)fileStream, Encoding.BigEndianUnicode);
                if (!validate_filelength(br.BaseStream.Length))
                {
                    fileStream.Close();
                    return false;
                }
                if (mainSettings.saveStructureIndex.encrypted)
                {
                    fileStream.Close();
                    if (System.IO.File.Exists("data\\temp\\denc.bin"))
                        System.IO.File.Delete("data\\temp\\denc.bin");
                    if (!decryptSaveFile(fileLoc))
                    {
                        MessageBox.Show("There was an error decrypting the save file.");
                        return false;
                    }
                    fileStream = openFileRead("data\\temp\\denc.bin");
                    br = new BinaryReader((Stream)fileStream, Encoding.BigEndianUnicode);
                }
                saveData.size = (int)br.BaseStream.Length;
            }
            else
            {
                initSlotVars();
                savedata_decimal_array_read_pos = 0;
                saveData.size = savedata_decimal_array_filled;
            }
            toolStripStatusLabel.Text = "Parsing Save 0%";
            toolStripProgressBar.Maximum = saveData.size;
            toolStripProgressBar.Value = 0;
            int pos = 0;
            parseHeaderInfo(br, &pos, reload);
            for (int slot = 0; slot < 8; ++slot)
            {
                if (!parseSlotInfo(slot, br, &pos, reload))
                {
                    fileStream?.Close();
                    return false;
                }
            }
            if (!parseCharacterSharedStorageSlotsInfo(br, &pos, reload))
            {
                fileStream?.Close();
                return false;
            }
            if (!parseInfinityMissionSlotsInfo(br, &pos, reload))
            {
                fileStream?.Close();
                return false;
            }
            int totalSize = mainSettings.saveStructureIndex.total_size;
            pos = adjustPosition(pos, br, totalSize, reload, "end of file", true);
            fileStream?.Close();
            toolStripStatusLabel.Text = "Save File Loaded";
            toolStripProgressBar.Value = toolStripProgressBar.Maximum;
            return true;
        }

        private unsafe bool parseHeaderInfo(BinaryReader br, int* pos, bool reload)
        {
            if (*pos > 0)
            {
                MessageBox.Show("Already scanned past the header", "scan error");
                return false;
            }
            brSkipBytes(mainSettings.saveStructureIndex.header_size, pos, br, reload, true);
            return true;
        }

        private unsafe bool parseCharacterItemPaletteInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            brSkipBytes(24, pos, br, reload, true);
            return true;
        }

        private unsafe bool parseCharacterPADisksLearntCount(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            saveData.slot[slot].pa.count = brGetInt(1, pos, br, reload, true);
            brSkipBytes(10, pos, br, reload, true);
            return true;
        }

        private unsafe void parseCharacterPADiskLearnt(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload,
          int* filled)
        {
            string data = brGetData(4, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            if (!(data != "00000000"))
                return;
            saveData.slot[slot].pa.items[*filled] = new pspo2seForm.inventoryItemClass();
            saveData.slot[slot].pa.items[*filled].hex = data.Substring(0, 6) + "00";
            saveData.slot[slot].pa.items[*filled].hex_reversed = run.hexAndMathFunction.reversehex(saveData.slot[slot].pa.items[*filled].hex, 8);
            string s = data.Substring(6, 2);
            saveData.slot[slot].pa.items[*filled].level = "LV" + (object)(int.Parse(s, NumberStyles.HexNumber) + 1);
            saveData.slot[slot].pa.items[*filled].id = *filled;
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
                saveData.slot[slot].pa.items[index] = new pspo2seForm.inventoryItemClass();
                saveData.slot[slot].pa.items[index].hex = "";
                saveData.slot[slot].pa.items[index].hex_reversed = "";
            }
            for (int index = 0; index < 136; ++index)
                parseCharacterPADiskLearnt(slot, br, pos, reload, &num);
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                for (int index = 0; index < 6; ++index)
                    parseCharacterPADiskLearnt(slot, br, pos, reload, &num);
            }
            return true;
        }

        private unsafe bool parseSlotInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            int item_position = mainSettings.saveStructureIndex.slots_position + mainSettings.saveStructureIndex.slot_size * slot;
            *pos = adjustPosition(*pos, br, item_position, reload, "Save Slot " + (object)slot, true);
            if (!parseCharacterInfo(slot, br, pos, reload) || !parseCharacterTypeLevelInfo(slot, br, pos, reload) || (!parseCharacterTypeExtraInfo(slot, br, pos, reload) || !parseCharacterRebirthInfo(slot, br, pos, reload)) || (!parseCharacterInventoryCountInfo(slot, br, pos, reload) || !parseCharacterPADisksLearntCount(slot, br, pos, reload) || (!parseCharacterItemPaletteInfo(slot, br, pos, reload) || !parseCharacterPADisksLearnt(slot, br, pos, reload))) || (!parseCharacterInventorySlotsInfo(slot, br, pos, reload) || !parseCharacterStoryInfo(slot, br, pos, reload)))
                return false;
            if (saveData.slot[slot].level == 0 || saveData.slot[slot].level > 200)
                saveData.slot[slot].level = 1;
            if (saveData.slot[slot].level == 200)
            {
                saveData.slot[slot].exp_next = 0;
                saveData.slot[slot].exp_percent = 100;
            }
            else
            {
                pspo2seForm.expDb_ItemClass expDbItemClass = new pspo2seForm.expDb_ItemClass();
                pspo2seForm.expDb_ItemClass expLevelInfoInDb = findExpLevelInfoInDb(saveData.slot[slot].level);
                if (expLevelInfoInDb == null)
                {
                    MessageBox.Show("could not find exp for level " + (object)saveData.slot[slot].level);
                }
                saveData.slot[slot].exp_next = expLevelInfoInDb.exp + expLevelInfoInDb.exp_next - saveData.slot[slot].exp;
                saveData.slot[slot].exp_percent = run.hexAndMathFunction.getPercentage(saveData.slot[slot].exp - expLevelInfoInDb.exp, expLevelInfoInDb.exp_next);
            }
            ListViewItem listViewItem;
            if (saveData.slot[slot].name == "---- Free Slot ----")
            {
                listViewItem = new ListViewItem(saveData.slot[slot].name, 2);
            }
            else
            {
                listViewItem = new ListViewItem(saveData.slot[slot].name, (int)saveData.slot[slot].sex);
                listViewItem.SubItems.Add("LV" + (object)saveData.slot[slot].level);
                listViewItem.SubItems.Add(string.Concat((object)saveData.slot[slot].race));
                listViewItem.SubItems.Add(string.Concat((object)saveData.slot[slot].cur_type));
                listViewItem.SubItems.Add(storyCompleteToText(saveData.slot[slot].story_ep_1_complete, saveData.slot[slot].story_ep_2_complete) ?? "");
            }
            lstSaveSlotView.Items.Add(listViewItem);
            return true;
        }

        private unsafe bool parseCharacterInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            saveData.slot[slot].rebirth = new pspo2seForm.rebirthType();
            int item_position = mainSettings.saveStructureIndex.slots_position + mainSettings.saveStructureIndex.slot_size * slot;
            *pos = adjustPosition(*pos, br, item_position, reload, "Character info " + (object)slot, true);
            saveData.slot[slot].used = true;
            saveData.slot[slot].name = "";
            for (int index = 0; index < 32; ++index)
            {
                uint num = uint.Parse(run.hexAndMathFunction.reversehex(brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), 4), NumberStyles.HexNumber);
                saveData.slot[slot].name += Encoding.UTF32.GetString(BitConverter.GetBytes(num));
            }
            if (saveData.slot[slot].name.Substring(0, 10) == "イーサン・ウェーバー")
            {
                saveData.slot[slot].name = "---- Free Slot ----";
                saveData.slot[slot].used = false;
                return true;
            }
            saveData.slot[slot].title = "";
            for (int index = 0; index < 32; ++index)
            {
                uint num = uint.Parse(run.hexAndMathFunction.reversehex(brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), 4), NumberStyles.HexNumber);
                saveData.slot[slot].title += Encoding.UTF32.GetString(BitConverter.GetBytes(num));
            }
            saveData.slot[slot].race = (pspo2seForm.raceTypes)brGetInt(1, pos, br, reload, true);
            saveData.slot[slot].sex = (pspo2seForm.sexType)brGetInt(1, pos, br, reload, true);
            saveData.slot[slot].cur_type = (pspo2seForm.jobType)brGetInt(1, pos, br, reload, true);
            brSkipBytes(101, pos, br, reload, true);
            saveData.slot[slot].level = brGetInt(2, pos, br, reload, true);
            brSkipBytes(6, pos, br, reload, true);
            saveData.slot[slot].exp = brGetInt32(pos, br, reload, true);
            saveData.slot[slot].meseta = (long)brGetInt32(pos, br, reload, true);
            int num1 = brGetInt(4, pos, br, reload, true);
            int num2 = num1 / 3600;
            int num3 = num1 - num2 * 3600;
            int num4 = num3 / 60;
            int num5 = num3 - num4 * 60;
            saveData.slot[slot].playtime = intTo2digitString(num2, 2) + ":" + intTo2digitString(num4, 2) + ":" + intTo2digitString(num5, 2);
            brSkipBytes(31, pos, br, reload, true);
            saveData.slot[slot].rebirth.additionalTypeLevels = brGetInt(1, pos, br, reload, true);
            return true;
        }

        private unsafe void parseTypeInfo(int slot, int job, int* pos, BinaryReader br, bool reload)
        {
            saveData.slot[slot].job[job].job = (pspo2seForm.jobType)job;
            saveData.slot[slot].job[job].level = brGetInt(1, pos, br, reload, true);
            saveData.slot[slot].job[job].scramble_exp = brGetInt(1, pos, br, reload, true);
            if (saveData.slot[slot].job[job].scramble_exp == 1)
            {
                string s = run.hexAndMathFunction.reversehex(brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), 4);
                saveData.slot[slot].job[job].exp = int.Parse(s, NumberStyles.HexNumber) + 65536;
            }
            else
                saveData.slot[slot].job[job].exp = brGetInt(2, pos, br, reload, true);
        }

        private unsafe bool parseCharacterTypeLevelInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int item_position = mainSettings.saveStructureIndex.type_level_pos + mainSettings.saveStructureIndex.slot_size * slot;
            *pos = adjustPosition(*pos, br, item_position, reload, "parseCharacterTypeLevelInfo slot " + (object)slot, true);
            parseTypeInfo(slot, 0, pos, br, reload);
            parseTypeInfo(slot, 1, pos, br, reload);
            parseTypeInfo(slot, 2, pos, br, reload);
            parseTypeInfo(slot, 3, pos, br, reload);
            return true;
        }

        private unsafe bool parseCharacterRebirthInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            if (saveData.type == pspo2seForm.SaveType.PSP2)
            {
                brSkipBytes(2, pos, br, reload, true);
                return true;
            }
            for (int index = 0; index < 12; ++index)
            {
                string s = run.hexAndMathFunction.reversehex(brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), 4);
                switch (index)
                {
                    case 0:
                        saveData.slot[slot].rebirth.count = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 1:
                        saveData.slot[slot].rebirth.remaining_points = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 2:
                        saveData.slot[slot].rebirth.atk = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 3:
                        saveData.slot[slot].rebirth.def = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 4:
                        saveData.slot[slot].rebirth.acc = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 5:
                        saveData.slot[slot].rebirth.eva = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 6:
                        saveData.slot[slot].rebirth.sta = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 8:
                        saveData.slot[slot].rebirth.tec = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 9:
                        saveData.slot[slot].rebirth.mnd = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 10:
                        saveData.slot[slot].rebirth.hp = int.Parse(s, NumberStyles.HexNumber);
                        break;
                    case 11:
                        saveData.slot[slot].rebirth.pp = int.Parse(s, NumberStyles.HexNumber);
                        break;
                }
            }
            return true;
        }

        private unsafe bool parseCharacterStoryInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            int item_position1 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * slot + 3182;
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
                item_position1 = mainSettings.saveStructureIndex.header_size + mainSettings.saveStructureIndex.slot_size * slot + 3242;
            *pos = adjustPosition(*pos, br, item_position1, reload, "parseCharacterStoryInfo slot " + (object)slot, true);
            string data1 = brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            saveData.slot[slot].mission_unlock_magashi = false;
            if (data1 == "1F")
                saveData.slot[slot].mission_unlock_magashi = true;
            int item_position2 = mainSettings.saveStructureIndex.story_info_pos + mainSettings.saveStructureIndex.slot_size * slot;
            *pos = adjustPosition(*pos, br, item_position2, reload, "parseCharacterStoryInfo slot " + (object)slot, true);
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
                saveData.slot[slot].story_ep_2_points = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            brSkipBytes(158, pos, br, reload, true);
            saveData.slot[slot].mission_unlock_ep1 = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true) == "204E";
            brSkipBytes(34, pos, br, reload, true);
            saveData.slot[slot].story_ep_1_points = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            brSkipBytes(14, pos, br, reload, true);
            saveData.slot[slot].mission_unlock_unknown = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true) == "204E";
            brSkipBytes(50, pos, br, reload, true);
            saveData.slot[slot].story_ep_1_act = run.hexAndMathFunction.hexToInt(brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true));
            brSkipBytes(7, pos, br, reload, true);
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                saveData.slot[slot].mission_unlock_ep2 = brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true) == "204E";
                brSkipBytes(891, pos, br, reload, true);
            }
            else
                brSkipBytes(893, pos, br, reload, true);
            saveData.slot[slot].allow_quit_missions = brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            brSkipBytes(4, pos, br, reload, true);
            brSkipBytes(32, pos, br, reload, true);
            brSkipBytes(10, pos, br, reload, true);
            brSkipBytes(32, pos, br, reload, true);
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
                brSkipBytes(52, pos, br, reload, true);
            else
                brSkipBytes(940, pos, br, reload, true);
            string data2 = brGetData(3, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            saveData.slot[slot].skip_ep_1_start = false;
            if (data2 == "90AB1E")
                saveData.slot[slot].skip_ep_1_start = true;
            if (saveData.type == pspo2seForm.SaveType.PSP2I)
            {
                brSkipBytes(33, pos, br, reload, true);
                string data3 = brGetData(3, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                saveData.slot[slot].skip_ep_2_start = false;
                if (data3 == "78AF1E")
                    saveData.slot[slot].skip_ep_2_start = true;
                brSkipBytes(17710, pos, br, reload, true);
            }
            else
                brSkipBytes(17714, pos, br, reload, true);
            string data4 = brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            int num = 0;
            try
            {
                num = int.Parse(data4.Substring(1, 1));
            }
            catch
            {
            }
            saveData.slot[slot].story_ep_1_complete = false;
            saveData.slot[slot].story_ep_2_complete = false;
            if (num == 1 || num == 3)
                saveData.slot[slot].story_ep_1_complete = true;
            if (num == 2 || num == 3)
                saveData.slot[slot].story_ep_2_complete = true;
            return true;
        }

        private unsafe bool parseCharacterTypeExtraInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int item_position1 = mainSettings.saveStructureIndex.type_level_pos + mainSettings.saveStructureIndex.slot_size * slot + 16;
            *pos = adjustPosition(*pos, br, item_position1, reload, "parseCharacterTypeExtraInfo slot " + (object)slot, true);
            for (int index = 0; index < 4; ++index)
            {
                int item_position2 = mainSettings.saveStructureIndex.type_level_pos + mainSettings.saveStructureIndex.slot_size * slot + 16 + index * mainSettings.saveStructureIndex.type_extend_size;
                *pos = adjustPosition(*pos, br, item_position2, (reload ? 1 : 0) != 0, "parseCharacterTypeExtraInfo slot " + (object)slot + " job " + (object)index, true);
                saveData.slot[slot].job[index].extendpoints = brGetInt(2, pos, br, reload, true);
                saveData.slot[slot].job[index].extendpointsused = brGetInt(2, pos, br, reload, true);
                saveData.slot[slot].job[index].attachedAbilities = brGetData(10, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                if (saveData.type == pspo2seForm.SaveType.PSP2I)
                    saveData.slot[slot].job[index].attachedAbilities += brGetData(2, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
            }
            string str = run.hexAndMathFunction.halfByteSwap(brGetData(58, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true));
            int index1 = 0;
            int index2 = 0;
            for (int startIndex = 0; startIndex < str.Length && index1 < 4; ++startIndex)
            {
                saveData.slot[slot].job[index1].weapons_extended[index2] = (pspo2seForm.extendRankType)int.Parse(str.Substring(startIndex, 1));
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
            int item_position = mainSettings.saveStructureIndex.inventory_slots_used_pos + mainSettings.saveStructureIndex.slot_size * slot;
            *pos = adjustPosition(*pos, br, item_position, reload, "parseCharacterInventoryCountInfo slot " + (object)slot, true);
            saveData.slot[slot].inventory.itemsUsed = brGetInt(1, pos, br, reload, true);
            return true;
        }

        private unsafe bool parseCharacterInventorySlotsInfo(
          int slot,
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int item_position = mainSettings.saveStructureIndex.inventory_slots_pos + mainSettings.saveStructureIndex.slot_size * slot;
            *pos = adjustPosition(*pos, br, item_position, reload, "parseCharacterInventoryCountInfo slot " + (object)slot, true);
            for (int index = 0; index < 60; ++index)
            {
                string data = brGetData(8, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                string s1 = data.Substring(8, 2);
                string str = data.Substring(2, 2);
                string s2 = data.Substring(0, 2);
                saveData.slot[slot].inventory.item[index] = brGetItem(pos, br, reload);
                saveData.slot[slot].inventory.item[index].data_id = int.Parse(s1, NumberStyles.HexNumber);
                saveData.slot[slot].inventory.item[index].equipped_now = int.Parse(s2, NumberStyles.HexNumber);
                saveData.slot[slot].inventory.item[index].equipped_slot = int.Parse(str) == 0 ? 0 : run.hexAndMathFunction.hex2binary(str).Length;
                if (index >= saveData.slot[slot].inventory.itemsUsed)
                {
                    saveData.slot[slot].inventory.item[index].hex = "FFFFFFFF";
                    saveData.slot[slot].inventory.item[index].hex_reversed = "FFFFFFFF";
                    saveData.slot[slot].inventory.item[index].type = pspo2seForm.itemType.free_slot;
                    saveData.slot[slot].inventory.item[index].used = false;
                    brSkipBytes(8, pos, br, reload, true);
                }
                else
                    brSkipBytes(8, pos, br, reload, true);
            }
            return true;
        }

        private unsafe bool parseCharacterSharedStorageSlotsInfo(
          BinaryReader br,
          int* pos,
          bool reload)
        {
            int sharedInventoryPos = mainSettings.saveStructureIndex.shared_inventory_pos;
            *pos = adjustPosition(*pos, br, sharedInventoryPos, reload, nameof(parseCharacterSharedStorageSlotsInfo), true);
            saveData.sharedInventory.itemsUsed = 0;
            for (int index = 0; index < mainSettings.saveStructureIndex.shared_inventory_slots; ++index)
                saveData.sharedInventory.item[index] = brGetItem(pos, br, reload);
            saveData.sharedMeseta = (long)brGetInt32(pos, br, reload, true);
            return true;
        }

        private unsafe bool parseInfinityMissionSlotsInfo(BinaryReader br, int* pos, bool reload)
        {
            if (saveData.type == pspo2seForm.SaveType.PSP2)
                return true;
            int infinityMissionPos = mainSettings.saveStructureIndex.infinity_mission_pos;
            *pos = adjustPosition(*pos, br, infinityMissionPos, reload, nameof(parseInfinityMissionSlotsInfo), true);
            saveData.infinityMissions.itemsUsed = 0;
            for (int index1 = 0; index1 < 100; ++index1)
            {
                saveData.infinityMissions.slot[index1] = new pspo2seForm.infinityMissionClass();
                string data = brGetData(104, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
                saveData.infinityMissions.slot[index1].hex = data;
                saveData.infinityMissions.slot[index1].id = index1;
                saveData.infinityMissions.slot[index1].area = int.Parse(data.Substring(1, 1), NumberStyles.HexNumber);
                int num1 = int.Parse(data.Substring(3, 1) + data.Substring(0, 1), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].length = 0;
                for (; num1 >= 64; num1 -= 64)
                    ++saveData.infinityMissions.slot[index1].length;
                saveData.infinityMissions.slot[index1].boss = num1;
                saveData.infinityMissions.slot[index1].enemy_2 = int.Parse(data.Substring(7, 1), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].enemy_table_1 = int.Parse(data.Substring(2, 1), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].unk_enemy_table_1_mod = false;
                if (saveData.infinityMissions.slot[index1].enemy_table_1 >= 8)
                {
                    saveData.infinityMissions.slot[index1].enemy_table_1 -= 8;
                    saveData.infinityMissions.slot[index1].unk_enemy_table_1_mod = true;
                }
                saveData.infinityMissions.slot[index1].unk_table_2_mod = int.Parse(data.Substring(5, 1), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].unk_table_2_unk_mod = 0;
                while (saveData.infinityMissions.slot[index1].unk_table_2_mod >= 4)
                {
                    saveData.infinityMissions.slot[index1].unk_table_2_mod -= 4;
                    ++saveData.infinityMissions.slot[index1].unk_table_2_unk_mod;
                }
                saveData.infinityMissions.slot[index1].area_1_map = int.Parse(data.Substring(6, 1), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].area_2_map = int.Parse(data.Substring(9, 1), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].area_3_map = int.Parse(data.Substring(8, 1), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].enemy_level = int.Parse(data.Substring(10, 2), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].unk_enemy_level_mod = 0;
                while (saveData.infinityMissions.slot[index1].enemy_level >= 64)
                {
                    saveData.infinityMissions.slot[index1].enemy_level -= 64;
                    ++saveData.infinityMissions.slot[index1].unk_enemy_level_mod;
                }
                int num2 = (int)Math.Floor((double)int.Parse(data.Substring(4, 1), NumberStyles.HexNumber) / 2.0);
                saveData.infinityMissions.slot[index1].enemy_1 = num2;
                int num3 = (int)Math.Ceiling((double)int.Parse(data.Substring(4, 1), NumberStyles.HexNumber) / 2.0);
                saveData.infinityMissions.slot[index1].unk_enemy_1_mod = num3 - saveData.infinityMissions.slot[index1].enemy_1;
                saveData.infinityMissions.slot[index1].createdBy = "";
                for (int index2 = 0; index2 < 32; ++index2)
                {
                    uint num4 = uint.Parse(run.hexAndMathFunction.reversehex(data.Substring(index2 * 4 + 32, 4), 4), NumberStyles.HexNumber);
                    saveData.infinityMissions.slot[index1].createdBy += Encoding.UTF32.GetString(BitConverter.GetBytes(num4));
                }
                saveData.infinityMissions.slot[index1].mergePoints = int.Parse(data.Substring(184, 2), NumberStyles.HexNumber);
                if (int.Parse(data.Substring(186, 2), NumberStyles.HexNumber) >= 128)
                    saveData.infinityMissions.slot[index1].mergePoints += (int.Parse(data.Substring(186, 2), NumberStyles.HexNumber) - 128) * 256;
                else if (int.Parse(data.Substring(186, 2), NumberStyles.HexNumber) < 128)
                    saveData.infinityMissions.slot[index1].mergePoints += int.Parse(data.Substring(187, 1), NumberStyles.HexNumber) * 256;
                saveData.infinityMissions.slot[index1].clearCount_c = int.Parse(run.hexAndMathFunction.reversehex(data.Substring(188, 4), 4), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].clearCount_b = int.Parse(run.hexAndMathFunction.reversehex(data.Substring(192, 4), 4), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].clearCount_a = int.Parse(run.hexAndMathFunction.reversehex(data.Substring(196, 4), 4), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].clearCount_s = int.Parse(run.hexAndMathFunction.reversehex(data.Substring(200, 4), 4), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].clearCount_inf = int.Parse(run.hexAndMathFunction.reversehex(data.Substring(204, 4), 4), NumberStyles.HexNumber);
                saveData.infinityMissions.slot[index1].level = saveData.infinityMissions.slot[index1].enemy_table_1 + saveData.infinityMissions.slot[index1].enemy_level / 10;
                if (saveData.infinityMissions.slot[index1].unk_enemy_table_1_mod)
                    ++saveData.infinityMissions.slot[index1].level;
                if (saveData.infinityMissions.slot[index1].length > 2)
                    saveData.infinityMissions.slot[index1].level += 10;
            }
            saveData.infinityMissions.itemsUsed = int.Parse(brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true), NumberStyles.HexNumber);
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

            public int CompareTo(object obj) => obj is pspo2seForm.infinityMissionClass ? hex.CompareTo(((pspo2seForm.infinityMissionClass)obj).hex) : throw new ArgumentException("Object is not of type infinityMissionClass.");
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

            public void set_type(pspo2seForm.SaveType new_type) => type = new_type;
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

            public int CompareTo(object obj) => obj is pspo2seForm.inventoryItemClass ? hex.CompareTo(((pspo2seForm.inventoryItemClass)obj).hex) : throw new ArgumentException("Object is not of type inventoryItemClass.");
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

        private void TxtStoryNagisaPoints_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            entryForm.oldVal = run.hexAndMathFunction.hexToInt(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_2_points).ToString();
            entryForm.newVal = run.hexAndMathFunction.hexToInt(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_2_points).ToString();
            entryForm.description = "emilia points";
            entryForm.maxLen = 4;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            long num1 = long.Parse(entryForm.newVal);
            if (num1 != saveData.sharedMeseta && num1 <= 65535L)
            {
                string hex = num1.ToString("X2");
                while (hex.Length < 4)
                    hex = "0" + hex;
                hex = run.hexAndMathFunction.reversehex(hex, 4);
                int pos = mainSettings.saveStructureIndex.story_info_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;

                overwriteHexInBuffer(hex, pos);
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_2_points = hex;
                txtStoryNagisaPoints.Text = run.hexAndMathFunction.hexToInt(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_2_points).ToString() + " Nagisa Points";

            }
            else
            {
                if (num1 <= 65535L)
                    return;
                MessageBox.Show("You must enter a value less than or equal to 65,535");
            }
        }

        private void TxtStoryEmiliaPoints_Click(object sender, EventArgs e)
        {
            if (legitVersion())
                return;
            entryForm.oldVal = run.hexAndMathFunction.hexToInt(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_1_points).ToString();
            entryForm.newVal = run.hexAndMathFunction.hexToInt(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_1_points).ToString();
            entryForm.description = "emilia points";
            entryForm.maxLen = 4;
            if (entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            long num1 = long.Parse(entryForm.newVal);
            if (num1 != saveData.sharedMeseta && num1 <= 65535L)
            {
                string hex = num1.ToString("X2");
                while (hex.Length < 4)
                    hex = "0" + hex;
                hex = run.hexAndMathFunction.reversehex(hex, 4);
                int pos = mainSettings.saveStructureIndex.story_info_pos + mainSettings.saveStructureIndex.slot_size * lstSaveSlotView.SelectedItems[0].Index;

                overwriteHexInBuffer(hex, saveData.type != SaveType.PSP2I ? pos + 194 : pos + 196);
                saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_1_points = hex;
                txtStoryEmiliaPoints.Text = run.hexAndMathFunction.hexToInt(saveData.slot[lstSaveSlotView.SelectedItems[0].Index].story_ep_1_points).ToString() + " Emilia Points";
            }
            else
            {
                if (num1 <= 65535L)
                    return;
                MessageBox.Show("You must enter a value less than or equal to 65,535");
            }
        }
    }
}
