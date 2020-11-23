using CSEncryptDecrypt;
using FolderZipper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PSPo2i_Save_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region declarations

        public const string appcompanyname = "";
        public const string appname = "PSPo2i Save Editor";
        public const string appver = "1.0.0";
        public string appDataPath = "";
        public objectAnimations objectAnim;

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
        private imageFloatBox imageFloater = new imageFloatBox();
        public bool firstInstall;
        private bool saveOk;
        public int selectInventoryItemAfterLoad = -1;
        public int selectItemAfterLoad = -1;
        public encryptRoutineType encryptor = new encryptRoutineType();
        private int selectedInventoryItem = -1;
        private int selectedStorageItem = -1;
        //public pspo2seEntryForm entryForm = new pspo2seEntryForm();
        //private pspo2seTypeAbilitiesForm abilitiesForm = new pspo2seTypeAbilitiesForm();
        //private weaponDbForm weaponDatabaseForm = new weaponDbForm();
        //private changeLogForm changelogForm = new changeLogForm();
        //private pspo2seInfinityMissionForm infinityMissionForm = new pspo2seInfinityMissionForm();
        //private updateInfoForm updateViewer = new updateInfoForm();

        public pspo2seSettings mainSettings = new pspo2seSettings();
        public bool firstload = true;
        public bool allowDownload = true;
        public byte[] downloadedData = new byte[512000];
        public string downloadedDataName;
        public bool firstboot = true;
        
        public Microsoft.Office.Interop.Excel.Application xlApp;

        private class imageFloatBox
        {
            public Point pnlloc = new Point();
            public Point grploc = new Point();
            public Image picBox = new Image();
            public FileInfo[] imagelist = new FileInfo[1500];
            public int filled = 0;
        }

        public class typeWeaponRankFields
        {
            public Image[] imgWeap = new Image[29];
            public Image[] imgRank = new Image[29];
        }

        public class pageFields
        {
            public Image img_rank;
            public Image img_item;
            public Image img_manufaturer;
            public Image img_infinity_item;
            public Image img_element;
            public Image img_star_0;
            public Image img_star_1;
            public Image img_star_2;
            public Image img_star_3;
            public Image img_star_4;
            public Image img_star_5;
            public Image img_star_6;
            public Image img_star_7;
            public Image img_star_8;
            public Image img_star_9;
            public Image img_star_10;
            public Image img_star_11;
            public Image img_star_12;
            public Image img_star_13;
            public Image img_star_14;
            public Image img_star_15;
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

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }
        #endregion

        #region form fields
        public class formFieldsType : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private double _progress_val;
            public double ProgressValue
            {
                get
                {
                    return _progress_val;
                }
                set
                {
                    _progress_val = value;

                    OnPropertyChanged(new PropertyChangedEventArgs("ProgressValue"));
                }
            }

            private double _progress_queue_val;
            public double ProgressQueueValue
            {
                get
                {
                    return _progress_queue_val;
                }
                set
                {
                    _progress_queue_val = value;

                    OnPropertyChanged(new PropertyChangedEventArgs("ProgressQueueValue"));
                }
            }

            private string _copyright;
            public string Copyright
            {
                get
                {
                    return _copyright;
                }
                set
                {
                    _copyright = value;

                    OnPropertyChanged(new PropertyChangedEventArgs("Copyright"));
                }
            }

            private string _status;
            public string Status
            {
                get
                {
                    return _status;
                }
                set
                {
                    _status = value;

                    OnPropertyChanged(new PropertyChangedEventArgs("Status"));
                }
            }

            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChanged?.Invoke(this, e);
            }
        }
        public formFieldsType formFields = new formFieldsType();

        public void updateProgressLabel(string txt)
        {
            txt = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt);
            txt = txt.Replace(" And ", " and ");
            txt = txt.Replace(" Of ", " of ");
            txt = txt.Replace(" For ", " for ");
            formFields.Status = txt;
            if ((txt != "") & (txt.Trim().ToLower() != "completed"))
            {
                Dispatcher.BeginInvoke(new voidDelegate(() =>
                {
                    panelSmallProgress.Visibility = Visibility.Visible;
                }));
            }
            else if ((txt == "") | (txt.Trim().ToLower() == "completed"))
            {
                Dispatcher.BeginInvoke(new voidDelegate(() =>
                {
                    panelSmallProgress.Visibility = Visibility.Hidden;
                }));
            }
        }
        public void updateProgress(double val, double max)
        {
            double percent = (val / max);
            formFields.ProgressValue = percent * 100;
            if ((formFields.ProgressValue == 100) & ((formFields.ProgressQueueValue == 0) | (formFields.ProgressQueueValue == 100)))
            {
                // hide the queue progress bar
                Dispatcher.BeginInvoke(new voidDelegate(() =>
                {
                    progressGrid.RowDefinitions[2].Height = new GridLength(0);
                    progressGrid.RowDefinitions[3].Height = new GridLength(56);
                    queueProgress.Visibility = Visibility.Collapsed;
                }));
            }
        }
        public void updateProgressQueue(double val, double max)
        {
            double percent = (val / max);
            formFields.ProgressQueueValue = percent * 100;
            // show the queue progress bar
            Dispatcher.BeginInvoke(new voidDelegate(() =>
            {
                progressGrid.RowDefinitions[2].Height = new GridLength(28);
                progressGrid.RowDefinitions[3].Height = new GridLength(28);
                queueProgress.Visibility = Visibility.Visible;
            }));
        }

        public typeSectionFields getTypeSectionFields(TabItem page)
        {
            typeSectionFields typeSectionFields = new typeSectionFields();
            //if (page == this.tabPageHunter)
            //{
            //    typeSectionFields.txtLevel = this.txtHuLevel;
            //    typeSectionFields.txtExp = this.txtHuExp;
            //    typeSectionFields.expBar = this.txtHuExpBar;
            //    typeSectionFields.grpExtend = this.grpHuTypeExtend;
            //}
            //else if (page == this.tabPageRanger)
            //{
            //    typeSectionFields.txtLevel = this.txtRaLevel;
            //    typeSectionFields.txtExp = this.txtRaExp;
            //    typeSectionFields.expBar = this.txtRaExpBar;
            //    typeSectionFields.grpExtend = this.grpRaTypeExtend;
            //}
            //else if (page == this.tabPageForce)
            //{
            //    typeSectionFields.txtLevel = this.txtFoLevel;
            //    typeSectionFields.txtExp = this.txtFoExp;
            //    typeSectionFields.expBar = this.txtFoExpBar;
            //    typeSectionFields.grpExtend = this.grpFoTypeExtend;
            //}
            //else if (page == this.tabPageVanguard)
            //{
            //    typeSectionFields.txtLevel = this.txtVaLevel;
            //    typeSectionFields.txtExp = this.txtVaExp;
            //    typeSectionFields.expBar = this.txtVaExpBar;
            //    typeSectionFields.grpExtend = this.grpVaTypeExtend;
            //}
            return typeSectionFields;
        }

        public pageFields getPageFields(TabItem page, bool inDatabase = false)
        {
            pageFields pageFields = new pageFields();
            //if (page == this.tabPageInventory)
            //{
            //    pageFields.img_rank = this.imgInventoryRank;
            //    pageFields.img_item = this.imgInventoryItemIcon;
            //    pageFields.img_manufaturer = this.imgInventoryWeaponManufacturer;
            //    pageFields.img_infinity_item = this.imgInventoryInfinityItem;
            //    pageFields.img_element = this.imgInventoryElement;
            //    pageFields.img_star_0 = this.imgStar0;
            //    pageFields.img_star_1 = this.imgStar1;
            //    pageFields.img_star_2 = this.imgStar2;
            //    pageFields.img_star_3 = this.imgStar3;
            //    pageFields.img_star_4 = this.imgStar4;
            //    pageFields.img_star_5 = this.imgStar5;
            //    pageFields.img_star_6 = this.imgStar6;
            //    pageFields.img_star_7 = this.imgStar7;
            //    pageFields.img_star_8 = this.imgStar8;
            //    pageFields.img_star_9 = this.imgStar9;
            //    pageFields.img_star_10 = this.imgStar10;
            //    pageFields.img_star_11 = this.imgStar11;
            //    pageFields.img_star_12 = this.imgStar12;
            //    pageFields.img_star_13 = this.imgStar13;
            //    pageFields.img_star_14 = this.imgStar14;
            //    pageFields.img_star_15 = this.imgStar15;
            //    pageFields.txt_infinity_item = this.txtInventoryInfinityItemText;
            //    pageFields.txt_name = this.txtInventoryName;
            //    pageFields.txt_name_jp = this.txtInventoryName_jp;
            //    pageFields.grp_details = this.grpInventoryItemDetails;
            //    pageFields.txt_grinds = this.txtInventoryGrinds;
            //    pageFields.txt_percent = this.txtInventoryPercent;
            //    pageFields.txt_hex = this.txtInventoryHex;
            //    pageFields.txt_meseta = this.txtInventoryMeseta;
            //    pageFields.txt_qty = this.txtInventoryQty;
            //    pageFields.txt_special = this.txtInventorySpecial;
            //    pageFields.txt_effect = this.txtInventoryEffect;
            //    pageFields.txt_atk = this.txtInventoryATK;
            //    pageFields.txt_acc = this.txtInventoryACC;
            //    pageFields.txt_level = this.txtInventoryLevel;
            //    pageFields.btn_delete = this.btnInventoryDelete;
            //    pageFields.btn_export_selected = this.btnInventoryExportSelected;
            //    pageFields.btn_import_selected = this.btnInventoryImportSelected;
            //    pageFields.chk_delete_export = this.chkDeleteExportInventory;
            //    pageFields.btn_withdraw = this.btnInventoryDeposit;
            //    pageFields.pnl_details = (Panel)null;
            //}
            //else if (page == this.tabPageStorage)
            //{
            //    pageFields.img_rank = this.imgStorageRank;
            //    pageFields.img_item = this.imgStorageItemIcon;
            //    pageFields.img_manufaturer = this.imgStorageWeaponManufacturer;
            //    pageFields.img_infinity_item = this.imgStorageInfinityItem;
            //    pageFields.img_element = this.imgStorageElement;
            //    pageFields.img_star_0 = this.imgStorageStar0;
            //    pageFields.img_star_1 = this.imgStorageStar1;
            //    pageFields.img_star_2 = this.imgStorageStar2;
            //    pageFields.img_star_3 = this.imgStorageStar3;
            //    pageFields.img_star_4 = this.imgStorageStar4;
            //    pageFields.img_star_5 = this.imgStorageStar5;
            //    pageFields.img_star_6 = this.imgStorageStar6;
            //    pageFields.img_star_7 = this.imgStorageStar7;
            //    pageFields.img_star_8 = this.imgStorageStar8;
            //    pageFields.img_star_9 = this.imgStorageStar9;
            //    pageFields.img_star_10 = this.imgStorageStar10;
            //    pageFields.img_star_11 = this.imgStorageStar11;
            //    pageFields.img_star_12 = this.imgStorageStar12;
            //    pageFields.img_star_13 = this.imgStorageStar13;
            //    pageFields.img_star_14 = this.imgStorageStar14;
            //    pageFields.img_star_15 = this.imgStorageStar15;
            //    pageFields.txt_infinity_item = this.txtStorageInfinityItemText;
            //    pageFields.txt_name = this.txtStorageName;
            //    pageFields.txt_name_jp = this.txtStorageName_jp;
            //    pageFields.grp_details = this.grpStorageItemDetails;
            //    pageFields.txt_grinds = this.txtStorageGrinds;
            //    pageFields.txt_percent = this.txtStoragePercent;
            //    pageFields.txt_hex = this.txtStorageHex;
            //    pageFields.txt_meseta = this.txtStorageMeseta;
            //    pageFields.txt_qty = this.txtStorageQty;
            //    pageFields.txt_special = this.txtStorageSpecial;
            //    pageFields.txt_effect = this.txtStorageEffect;
            //    pageFields.txt_atk = this.txtStorageATK;
            //    pageFields.txt_acc = this.txtStorageACC;
            //    pageFields.txt_level = this.txtStorageLevel;
            //    pageFields.btn_delete = this.btnStorageDelete;
            //    pageFields.btn_export_selected = this.btnStorageExportSelected;
            //    pageFields.btn_import_selected = this.btnStorageImportSelected;
            //    pageFields.chk_delete_export = this.chkDeleteExportStorage;
            //    pageFields.btn_withdraw = this.btnStorageWithdraw;
            //    pageFields.pnl_details = (Panel)null;
            //}
            //else
            //{
            //    int num = (int)MessageBox.Show("The selected page for getFields was not recognised: " + (object)page);
            //}
            return pageFields;
        }

        public typeWeaponRankFields getTypeWeaponExtendFields(TabItem page)
        {
            typeWeaponRankFields weaponRankFields = new typeWeaponRankFields();
            //if (page == this.tabPageHunter)
            //{
            //    weaponRankFields.imgWeap[1] = this.imgHuSword;
            //    weaponRankFields.imgWeap[2] = this.imgHuKnuckles;
            //    weaponRankFields.imgWeap[3] = this.imgHuSpear;
            //    weaponRankFields.imgWeap[4] = this.imgHuDblSaber;
            //    weaponRankFields.imgWeap[5] = this.imgHuAxe;
            //    weaponRankFields.imgWeap[6] = this.imgHuSabers;
            //    weaponRankFields.imgWeap[7] = this.imgHuDaggers;
            //    weaponRankFields.imgWeap[8] = this.imgHuClaws;
            //    weaponRankFields.imgWeap[9] = this.imgHuSaber;
            //    weaponRankFields.imgWeap[10] = this.imgHuDagger;
            //    weaponRankFields.imgWeap[11] = this.imgHuClaw;
            //    weaponRankFields.imgWeap[12] = this.imgHuWhip;
            //    weaponRankFields.imgWeap[13] = this.imgHuSlicer;
            //    weaponRankFields.imgWeap[14] = this.imgHuRifle;
            //    weaponRankFields.imgWeap[15] = this.imgHuShotgun;
            //    weaponRankFields.imgWeap[16] = this.imgHuLongbow;
            //    weaponRankFields.imgWeap[17] = this.imgHuGrenade;
            //    weaponRankFields.imgWeap[18] = this.imgHuLaser;
            //    weaponRankFields.imgWeap[19] = this.imgHuHandguns;
            //    weaponRankFields.imgWeap[20] = this.imgHuHandgun;
            //    weaponRankFields.imgWeap[21] = this.imgHuCrossbow;
            //    weaponRankFields.imgWeap[22] = this.imgHuCards;
            //    weaponRankFields.imgWeap[23] = this.imgHuMachinegun;
            //    weaponRankFields.imgWeap[27] = this.imgHuRmag;
            //    weaponRankFields.imgWeap[24] = this.imgHuRod;
            //    weaponRankFields.imgWeap[25] = this.imgHuWand;
            //    weaponRankFields.imgWeap[26] = this.imgHuTmag;
            //    weaponRankFields.imgWeap[28] = this.imgHuShield;
            //    weaponRankFields.imgRank[1] = this.imgHuSwordRank;
            //    weaponRankFields.imgRank[2] = this.imgHuKnucklesRank;
            //    weaponRankFields.imgRank[3] = this.imgHuSpearRank;
            //    weaponRankFields.imgRank[4] = this.imgHuDblSaberRank;
            //    weaponRankFields.imgRank[5] = this.imgHuAxeRank;
            //    weaponRankFields.imgRank[6] = this.imgHuSabersRank;
            //    weaponRankFields.imgRank[7] = this.imgHuDaggersRank;
            //    weaponRankFields.imgRank[8] = this.imgHuClawsRank;
            //    weaponRankFields.imgRank[9] = this.imgHuSaberRank;
            //    weaponRankFields.imgRank[10] = this.imgHuDaggerRank;
            //    weaponRankFields.imgRank[11] = this.imgHuClawRank;
            //    weaponRankFields.imgRank[12] = this.imgHuWhipRank;
            //    weaponRankFields.imgRank[13] = this.imgHuSlicerRank;
            //    weaponRankFields.imgRank[14] = this.imgHuRifleRank;
            //    weaponRankFields.imgRank[15] = this.imgHuShotgunRank;
            //    weaponRankFields.imgRank[16] = this.imgHuLongbowRank;
            //    weaponRankFields.imgRank[17] = this.imgHuGrenadeRank;
            //    weaponRankFields.imgRank[18] = this.imgHuLaserRank;
            //    weaponRankFields.imgRank[19] = this.imgHuHandgunsRank;
            //    weaponRankFields.imgRank[20] = this.imgHuHandgunRank;
            //    weaponRankFields.imgRank[21] = this.imgHuCrossbowRank;
            //    weaponRankFields.imgRank[22] = this.imgHuCardsRank;
            //    weaponRankFields.imgRank[23] = this.imgHuMachinegunRank;
            //    weaponRankFields.imgRank[27] = this.imgHuRmagRank;
            //    weaponRankFields.imgRank[24] = this.imgHuRodRank;
            //    weaponRankFields.imgRank[25] = this.imgHuWandRank;
            //    weaponRankFields.imgRank[26] = this.imgHuTmagRank;
            //    weaponRankFields.imgRank[28] = this.imgHuShieldRank;
            //}
            //else if (page == this.tabPageRanger)
            //{
            //    weaponRankFields.imgWeap[1] = this.imgRaSword;
            //    weaponRankFields.imgWeap[2] = this.imgRaKnuckles;
            //    weaponRankFields.imgWeap[3] = this.imgRaSpear;
            //    weaponRankFields.imgWeap[4] = this.imgRaDblSaber;
            //    weaponRankFields.imgWeap[5] = this.imgRaAxe;
            //    weaponRankFields.imgWeap[6] = this.imgRaSabers;
            //    weaponRankFields.imgWeap[7] = this.imgRaDaggers;
            //    weaponRankFields.imgWeap[8] = this.imgRaClaws;
            //    weaponRankFields.imgWeap[9] = this.imgRaSaber;
            //    weaponRankFields.imgWeap[10] = this.imgRaDagger;
            //    weaponRankFields.imgWeap[11] = this.imgRaClaw;
            //    weaponRankFields.imgWeap[12] = this.imgRaWhip;
            //    weaponRankFields.imgWeap[13] = this.imgRaSlicer;
            //    weaponRankFields.imgWeap[14] = this.imgRaRifle;
            //    weaponRankFields.imgWeap[15] = this.imgRaShotgun;
            //    weaponRankFields.imgWeap[16] = this.imgRaLongbow;
            //    weaponRankFields.imgWeap[17] = this.imgRaGrenade;
            //    weaponRankFields.imgWeap[18] = this.imgRaLaser;
            //    weaponRankFields.imgWeap[19] = this.imgRaHandguns;
            //    weaponRankFields.imgWeap[20] = this.imgRaHandgun;
            //    weaponRankFields.imgWeap[21] = this.imgRaCrossbow;
            //    weaponRankFields.imgWeap[22] = this.imgRaCards;
            //    weaponRankFields.imgWeap[23] = this.imgRaMachinegun;
            //    weaponRankFields.imgWeap[27] = this.imgRaRmag;
            //    weaponRankFields.imgWeap[24] = this.imgRaRod;
            //    weaponRankFields.imgWeap[25] = this.imgRaWand;
            //    weaponRankFields.imgWeap[26] = this.imgRaTmag;
            //    weaponRankFields.imgWeap[28] = this.imgRaShield;
            //    weaponRankFields.imgRank[1] = this.imgRaSwordRank;
            //    weaponRankFields.imgRank[2] = this.imgRaKnucklesRank;
            //    weaponRankFields.imgRank[3] = this.imgRaSpearRank;
            //    weaponRankFields.imgRank[4] = this.imgRaDblSaberRank;
            //    weaponRankFields.imgRank[5] = this.imgRaAxeRank;
            //    weaponRankFields.imgRank[6] = this.imgRaSabersRank;
            //    weaponRankFields.imgRank[7] = this.imgRaDaggersRank;
            //    weaponRankFields.imgRank[8] = this.imgRaClawsRank;
            //    weaponRankFields.imgRank[9] = this.imgRaSaberRank;
            //    weaponRankFields.imgRank[10] = this.imgRaDaggerRank;
            //    weaponRankFields.imgRank[11] = this.imgRaClawRank;
            //    weaponRankFields.imgRank[12] = this.imgRaWhipRank;
            //    weaponRankFields.imgRank[13] = this.imgRaSlicerRank;
            //    weaponRankFields.imgRank[14] = this.imgRaRifleRank;
            //    weaponRankFields.imgRank[15] = this.imgRaShotgunRank;
            //    weaponRankFields.imgRank[16] = this.imgRaLongbowRank;
            //    weaponRankFields.imgRank[17] = this.imgRaGrenadeRank;
            //    weaponRankFields.imgRank[18] = this.imgRaLaserRank;
            //    weaponRankFields.imgRank[19] = this.imgRaHandgunsRank;
            //    weaponRankFields.imgRank[20] = this.imgRaHandgunRank;
            //    weaponRankFields.imgRank[21] = this.imgRaCrossbowRank;
            //    weaponRankFields.imgRank[22] = this.imgRaCardsRank;
            //    weaponRankFields.imgRank[23] = this.imgRaMachinegunRank;
            //    weaponRankFields.imgRank[27] = this.imgRaRmagRank;
            //    weaponRankFields.imgRank[24] = this.imgRaRodRank;
            //    weaponRankFields.imgRank[25] = this.imgRaWandRank;
            //    weaponRankFields.imgRank[26] = this.imgRaTmagRank;
            //    weaponRankFields.imgRank[28] = this.imgRaShieldRank;
            //}
            //else if (page == this.tabPageForce)
            //{
            //    weaponRankFields.imgWeap[1] = this.imgFoSword;
            //    weaponRankFields.imgWeap[2] = this.imgFoKnuckles;
            //    weaponRankFields.imgWeap[3] = this.imgFoSpear;
            //    weaponRankFields.imgWeap[4] = this.imgFoDblSaber;
            //    weaponRankFields.imgWeap[5] = this.imgFoAxe;
            //    weaponRankFields.imgWeap[6] = this.imgFoSabers;
            //    weaponRankFields.imgWeap[7] = this.imgFoDaggers;
            //    weaponRankFields.imgWeap[8] = this.imgFoClaws;
            //    weaponRankFields.imgWeap[9] = this.imgFoSaber;
            //    weaponRankFields.imgWeap[10] = this.imgFoDagger;
            //    weaponRankFields.imgWeap[11] = this.imgFoClaw;
            //    weaponRankFields.imgWeap[12] = this.imgFoWhip;
            //    weaponRankFields.imgWeap[13] = this.imgFoSlicer;
            //    weaponRankFields.imgWeap[14] = this.imgFoRifle;
            //    weaponRankFields.imgWeap[15] = this.imgFoShotgun;
            //    weaponRankFields.imgWeap[16] = this.imgFoLongbow;
            //    weaponRankFields.imgWeap[17] = this.imgFoGrenade;
            //    weaponRankFields.imgWeap[18] = this.imgFoLaser;
            //    weaponRankFields.imgWeap[19] = this.imgFoHandguns;
            //    weaponRankFields.imgWeap[20] = this.imgFoHandgun;
            //    weaponRankFields.imgWeap[21] = this.imgFoCrossbow;
            //    weaponRankFields.imgWeap[22] = this.imgFoCards;
            //    weaponRankFields.imgWeap[23] = this.imgFoMachinegun;
            //    weaponRankFields.imgWeap[27] = this.imgFoRmag;
            //    weaponRankFields.imgWeap[24] = this.imgFoRod;
            //    weaponRankFields.imgWeap[25] = this.imgFoWand;
            //    weaponRankFields.imgWeap[26] = this.imgFoTmag;
            //    weaponRankFields.imgWeap[28] = this.imgFoShield;
            //    weaponRankFields.imgRank[1] = this.imgFoSwordRank;
            //    weaponRankFields.imgRank[2] = this.imgFoKnucklesRank;
            //    weaponRankFields.imgRank[3] = this.imgFoSpearRank;
            //    weaponRankFields.imgRank[4] = this.imgFoDblSaberRank;
            //    weaponRankFields.imgRank[5] = this.imgFoAxeRank;
            //    weaponRankFields.imgRank[6] = this.imgFoSabersRank;
            //    weaponRankFields.imgRank[7] = this.imgFoDaggersRank;
            //    weaponRankFields.imgRank[8] = this.imgFoClawsRank;
            //    weaponRankFields.imgRank[9] = this.imgFoSaberRank;
            //    weaponRankFields.imgRank[10] = this.imgFoDaggerRank;
            //    weaponRankFields.imgRank[11] = this.imgFoClawRank;
            //    weaponRankFields.imgRank[12] = this.imgFoWhipRank;
            //    weaponRankFields.imgRank[13] = this.imgFoSlicerRank;
            //    weaponRankFields.imgRank[14] = this.imgFoRifleRank;
            //    weaponRankFields.imgRank[15] = this.imgFoShotgunRank;
            //    weaponRankFields.imgRank[16] = this.imgFoLongbowRank;
            //    weaponRankFields.imgRank[17] = this.imgFoGrenadeRank;
            //    weaponRankFields.imgRank[18] = this.imgFoLaserRank;
            //    weaponRankFields.imgRank[19] = this.imgFoHandgunsRank;
            //    weaponRankFields.imgRank[20] = this.imgFoHandgunRank;
            //    weaponRankFields.imgRank[21] = this.imgFoCrossbowRank;
            //    weaponRankFields.imgRank[22] = this.imgFoCardsRank;
            //    weaponRankFields.imgRank[23] = this.imgFoMachinegunRank;
            //    weaponRankFields.imgRank[27] = this.imgFoRmagRank;
            //    weaponRankFields.imgRank[24] = this.imgFoRodRank;
            //    weaponRankFields.imgRank[25] = this.imgFoWandRank;
            //    weaponRankFields.imgRank[26] = this.imgFoTmagRank;
            //    weaponRankFields.imgRank[28] = this.imgFoShieldRank;
            //}
            //else if (page == this.tabPageVanguard)
            //{
            //    weaponRankFields.imgWeap[1] = this.imgVaSword;
            //    weaponRankFields.imgWeap[2] = this.imgVaKnuckles;
            //    weaponRankFields.imgWeap[3] = this.imgVaSpear;
            //    weaponRankFields.imgWeap[4] = this.imgVaDblSaber;
            //    weaponRankFields.imgWeap[5] = this.imgVaAxe;
            //    weaponRankFields.imgWeap[6] = this.imgVaSabers;
            //    weaponRankFields.imgWeap[7] = this.imgVaDaggers;
            //    weaponRankFields.imgWeap[8] = this.imgVaClaws;
            //    weaponRankFields.imgWeap[9] = this.imgVaSaber;
            //    weaponRankFields.imgWeap[10] = this.imgVaDagger;
            //    weaponRankFields.imgWeap[11] = this.imgVaClaw;
            //    weaponRankFields.imgWeap[12] = this.imgVaWhip;
            //    weaponRankFields.imgWeap[13] = this.imgVaSlicer;
            //    weaponRankFields.imgWeap[14] = this.imgVaRifle;
            //    weaponRankFields.imgWeap[15] = this.imgVaShotgun;
            //    weaponRankFields.imgWeap[16] = this.imgVaLongbow;
            //    weaponRankFields.imgWeap[17] = this.imgVaGrenade;
            //    weaponRankFields.imgWeap[18] = this.imgVaLaser;
            //    weaponRankFields.imgWeap[19] = this.imgVaHandguns;
            //    weaponRankFields.imgWeap[20] = this.imgVaHandgun;
            //    weaponRankFields.imgWeap[21] = this.imgVaCrossbow;
            //    weaponRankFields.imgWeap[22] = this.imgVaCards;
            //    weaponRankFields.imgWeap[23] = this.imgVaMachinegun;
            //    weaponRankFields.imgWeap[27] = this.imgVaRmag;
            //    weaponRankFields.imgWeap[24] = this.imgVaRod;
            //    weaponRankFields.imgWeap[25] = this.imgVaWand;
            //    weaponRankFields.imgWeap[26] = this.imgVaTmag;
            //    weaponRankFields.imgWeap[28] = this.imgVaShield;
            //    weaponRankFields.imgRank[1] = this.imgVaSwordRank;
            //    weaponRankFields.imgRank[2] = this.imgVaKnucklesRank;
            //    weaponRankFields.imgRank[3] = this.imgVaSpearRank;
            //    weaponRankFields.imgRank[4] = this.imgVaDblSaberRank;
            //    weaponRankFields.imgRank[5] = this.imgVaAxeRank;
            //    weaponRankFields.imgRank[6] = this.imgVaSabersRank;
            //    weaponRankFields.imgRank[7] = this.imgVaDaggersRank;
            //    weaponRankFields.imgRank[8] = this.imgVaClawsRank;
            //    weaponRankFields.imgRank[9] = this.imgVaSaberRank;
            //    weaponRankFields.imgRank[10] = this.imgVaDaggerRank;
            //    weaponRankFields.imgRank[11] = this.imgVaClawRank;
            //    weaponRankFields.imgRank[12] = this.imgVaWhipRank;
            //    weaponRankFields.imgRank[13] = this.imgVaSlicerRank;
            //    weaponRankFields.imgRank[14] = this.imgVaRifleRank;
            //    weaponRankFields.imgRank[15] = this.imgVaShotgunRank;
            //    weaponRankFields.imgRank[16] = this.imgVaLongbowRank;
            //    weaponRankFields.imgRank[17] = this.imgVaGrenadeRank;
            //    weaponRankFields.imgRank[18] = this.imgVaLaserRank;
            //    weaponRankFields.imgRank[19] = this.imgVaHandgunsRank;
            //    weaponRankFields.imgRank[20] = this.imgVaHandgunRank;
            //    weaponRankFields.imgRank[21] = this.imgVaCrossbowRank;
            //    weaponRankFields.imgRank[22] = this.imgVaCardsRank;
            //    weaponRankFields.imgRank[23] = this.imgVaMachinegunRank;
            //    weaponRankFields.imgRank[27] = this.imgVaRmagRank;
            //    weaponRankFields.imgRank[24] = this.imgVaRodRank;
            //    weaponRankFields.imgRank[25] = this.imgVaWandRank;
            //    weaponRankFields.imgRank[26] = this.imgVaTmagRank;
            //    weaponRankFields.imgRank[28] = this.imgVaShieldRank;
            //}
            return weaponRankFields;
        }
        #endregion

        public static string getResourceVal(dynamic obj, string name)
        {
            ResourceDictionary res = obj.Resources;
           return res[name].ToString();
        }

        public static void overwriteResource(dynamic obj, string name, string value)
        {
            ResourceDictionary res = obj.Resources;
            res[name] = ColorConverter.ConvertFromString(value);
        }
        public void loadTheme(string themeFile)
        {
            Uri uri = new Uri(@"/PSPo2i Save Editor;component/Resources/Themes/" + themeFile, UriKind.Relative);
            ResourceDictionary rs = (ResourceDictionary)Application.LoadComponent(uri);
            Application.Current.Resources.MergedDictionaries.Add(rs);
        }

        public MainWindow()
        {
            InitializeComponent();
            appDataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appname);
            loadTheme("Theme_00.xaml");
            loadTheme("Theme_Templates.xaml");

            update.checkForUpdates(this, this, new update.completeDelegate(updatesCompleted));
        }

        private void updatesCompleted(bool success)
        {
            panelSmallProgress.Visibility = Visibility.Hidden;
        }

        public delegate void voidDelegate();
        public TabItem get_tabPageType()
        {
            //return this.tabPageInventory;
            return null;
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            action_browse();
        }

        private void action_browse()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\databases");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\temp");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\weapon_images");
                firstInstall = true;
                pspo2Databases.databasesOk = false;
                int num = (int)MessageBox.Show("This is your first time running the application\r\nYou will need to update the databases\r\nbefore you can do anything.\r\n\r\nChoose databases from the top menu to update.", "First time use", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\keys"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\keys");
            if (!this.downloadRequiredFile("FolderZipper.dll", "The application will not start without this file.", 6144L))
            {
                int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            if (!this.downloadRequiredFile("ICSharpCode.SharpZipLib.dll", "The application will not start without this file.", 200704L))
            {
                int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            if (!this.downloadRequiredFile("pspo2se_updater.exe", "The application will not start without this file.", 6144L))
            {
                int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(0);
            }
            this.downloadRequiredFile("SED.exe", "You cannot load encrypted save files without this.", 51712L);
            pspo2Databases.encryptor = this.encryptor;

            if (!this.firstInstall)
            {
                this.action_loadDatabases();
                this.checkAppUpdate(false);
                this.checkDatabaseUpdate(false);
                this.checkImagesUpdate(false);
            }
            this.firstboot = false;
            //this.Text = "PSPo2 Save Editor v3.0 build 1008";
            //this.txtFooterText.Text = "PSPo2 Save Editor v3.0 build 1008 by FunkySkunk 2011-2015";
            //this.btnBrowse.Enabled = true;
            //this.menuStrip.Enabled = true;
        }
        
        public void reloadEverything()
        {

        }


        public void disableForm()
        {
            enableForm(false);
        }

        public void enablePopUp(bool enabled)
        {
            if ((enabled))
            {
                Dispatcher.BeginInvoke(new voidDelegate(() =>
                {
                    panelPopUpEnabled.Visibility = Visibility.Hidden;
                }));
            }
            else
                Dispatcher.BeginInvoke(new voidDelegate(() =>
                {
                    panelPopUpEnabled.Visibility = Visibility.Visible;
                }));
        }
        public void enableForm(bool enabled)
        {
            Dispatcher.BeginInvoke(new voidDelegate(() =>
            {
                if ((popUps.IsOpen() == false))
                    enablePopUp(true);
                if ((enabled))
                    panelEnabled.Visibility = Visibility.Hidden;
                else
                    panelEnabled.Visibility = Visibility.Visible;
            }));
        }
        public delegate void setObjectOpacityDelegate(dynamic o, double opacity);
        public static void setObjectOpacity(dynamic o, double opacity)
        {
            o.Opacity = opacity;
        }
        public delegate void setObjectVisibilityDelegate(dynamic o, Visibility vis);
        public static void setObjectVisibility(dynamic o, Visibility vis)
        {
            o.Visibility = vis;
        }

        private void panelSmallProgress_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
