namespace pspo2seSaveEditorProgram
{
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
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class pspo2seForm : Form
    {
        private const int IMAGE_FLOAT_Y_MOVE = 130;
        private const int IMAGE_FLOAT_SPEED = 3;
        private const int MAX_IMAGES = 0x5dc;
        private const string SUB_DIR = "weapon_images/";
        public const int EXPLEVEL_DB_SIZE = 0x163;
        public const int EXPTYPE_DB_SIZE = 0x37;
        public const int MAX_APP_DOWNLOAD_FILES = 20;
        private int imageFloat_Y_hidden;
        private int imageFloat_Y_visible;
        private string[] IMAGE_FLOAT_FILE_EXT = new string[] { "jpg", "png" };
        private bool imageFloatImageIsOk;
        private bool imageFloatShowing;
        private bool allowImageFloatMove = true;
        private imageFloatBox imageFloater = new imageFloatBox();
        public int exp_db_filled;
        public int type_db_filled;
        private bool shownCorruptExpCsv;
        private bool shownCorruptExpTypeCsv;
        public expDbType exp_db = new expDbType();
        public typeexpDbType typeexp_db = new typeexpDbType();
        private bool firstInstall;
        private bool databasesOk = true;
        private bool saveOk;
        public int selectInventoryItemAfterLoad = -1;
        public int selectItemAfterLoad = -1;
        public encryptRoutineType encryptor = new encryptRoutineType();
        public runFunctionsType run = new runFunctionsType();
        public pspo2seAbilityDb abilityDb = new pspo2seAbilityDb();
        private int selectedInventoryItem = -1;
        private int selectedStorageItem = -1;
        public pspo2seEntryForm entryForm = new pspo2seEntryForm();
        private pspo2seTypeAbilitiesForm abilitiesForm = new pspo2seTypeAbilitiesForm();
        private weaponDbForm weaponDatabaseForm = new weaponDbForm();
        private changeLogForm changelogForm = new changeLogForm();
        private pspo2seInfinityMissionForm infinityMissionForm = new pspo2seInfinityMissionForm();
        private updateInfoForm updateViewer = new updateInfoForm();
        public saveDataType saveData = new saveDataType();
        public pspo2seSettings mainSettings = new pspo2seSettings();
        public bool firstload = true;
        public int[] savedata_decimal_array = new int[0x49928];
        public int savedata_decimal_array_filled;
        public int savedata_decimal_array_read_pos;
        private IContainer components;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private PictureBox imgLogo;
        private PictureBox imgGameLogo;
        private TabPage tabPageInfo;
        private Label txtLevel;
        private Label lblLevel;
        private Label txtCharacterName;
        private TabPage tabPageStorage;
        private Button btnStorageImportSelected;
        private Button btnStorageExportSelected;
        private Button btnUndoAll;
        private Button btnSaveAs;
        private TabPage tabPageInventory;
        private Label txtInventoryMeseta;
        private Label lblInventoryMeseta;
        private Label txtInventoryPercent;
        private PictureBox imgInventoryElement;
        private Label txtInventoryQty;
        private GroupBox grpInventoryItemDetails;
        private Label txtInventoryName_jp;
        private Label txtInventoryName;
        private Label txtInventoryGrinds;
        private PictureBox imgInventoryWeaponManufacturer;
        private PictureBox imgInventoryItemIcon;
        private Label txtInventoryHex;
        private PictureBox imgInventoryInfinityItem;
        private Label txtInventoryInfinityItemText;
        private PictureBox imgStar0;
        private PictureBox imgStar5;
        private PictureBox imgStar4;
        private PictureBox imgStar3;
        private PictureBox imgStar2;
        private PictureBox imgStar1;
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
        private PictureBox imgInventoryRank;
        private Label txtStorageHex;
        private Label txtStorageMeseta;
        private Label lblStorageMeseta;
        private GroupBox grpStorageItemDetails;
        private PictureBox imgStorageRank;
        private PictureBox imgStorageStar15;
        private PictureBox imgStorageStar14;
        private PictureBox imgStorageStar13;
        private PictureBox imgStorageStar12;
        private PictureBox imgStorageStar11;
        private PictureBox imgStorageStar10;
        private PictureBox imgStorageStar9;
        private PictureBox imgStorageStar8;
        private PictureBox imgStorageStar7;
        private PictureBox imgStorageStar6;
        private PictureBox imgStorageStar5;
        private PictureBox imgStorageStar4;
        private PictureBox imgStorageStar3;
        private PictureBox imgStorageStar2;
        private PictureBox imgStorageStar1;
        private PictureBox imgStorageStar0;
        private PictureBox imgStorageWeaponManufacturer;
        private Label txtStorageGrinds;
        private Label txtStorageName_jp;
        private PictureBox imgStorageElement;
        private Label txtStoragePercent;
        private Label txtStorageQty;
        private Label txtStorageInfinityItemText;
        private PictureBox imgStorageInfinityItem;
        private PictureBox imgStorageItemIcon;
        private Label txtStorageName;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private Button btnInventoryImportAll;
        private Button btnInventoryExportAll;
        private ImageList weaponWithRankImageList;
        private GroupBox groupBox2;
        private Button btnInventoryImportSelected;
        private Button btnInventoryExportSelected;
        private ListView storageView;
        private ColumnHeader columnHeader3;
        private Button btnStorageImportAll;
        private Button btnStorageExportAll;
        private GroupBox groupBox1;
        private TabControl storageViewPages;
        private TabPage tabStorage1;
        private TabPage tabStorage2;
        private TabPage tabStorage3;
        private TabPage tabStorage4;
        private TabPage tabStorage5;
        private TabControl inventoryViewPages;
        private TabPage tabInventory1;
        private TabPage tabInventory2;
        private TabPage tabInventory3;
        private TabPage tabInventory4;
        private TabPage tabInventory5;
        private TabPage tabInventory6;
        private TabPage tabStorage6;
        private Label txtInventorySpecial;
        private Label txtInventoryEffect;
        private ImageList armourImageList;
        private ImageList itemImageList;
        private ImageList clothesImageList;
        private ImageList decoImageList;
        private ImageList sexImageList;
        private Label txtLevelExpBar;
        private Label label11;
        private Label txtStorageEffect;
        private Label txtStorageSpecial;
        private Label txtInventoryACC;
        private Label txtInventoryATK;
        private Label txtStorageACC;
        private Label txtStorageATK;
        private Label txtInventoryLevel;
        private Label txtStorageLevel;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem databasesToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripMenuItem imagesToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem versionInfoToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem1;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private GroupBox groupBox3;
        private Label txtExpNext;
        private Label label9;
        private Label txtExp;
        private Label txtSex;
        private Label label21;
        private Label lblSex;
        private Label txtRace;
        private Label lblClass;
        private Label lblTitle;
        private Label txtTitle;
        private Label label7;
        private Label lblType;
        private Label txtCurType;
        private Label txtPlaytime;
        private GroupBox groupBox5;
        private Label txtStoryTrueEnd;
        private Label txtStoryComplete;
        private Label txtFooterText;
        private ListView lstSaveSlotView;
        private ColumnHeader slotViewHeader_name;
        private ColumnHeader slotViewHeader_level;
        private ColumnHeader slotViewHeader_class;
        private ColumnHeader slotViewHeader_type;
        private ColumnHeader slotViewHeader_complete;
        private Label txtFileSize;
        private Button btnExportCharacter;
        private Label txtSlotnumloaded;
        private Button btnImportCharacter;
        private TextBox txtFileLoc;
        private Button btnBrowse;
        private PictureBox imgSave;
        private PictureBox pictureBox1;
        private GroupBox groupBox4;
        private GroupBox grpImageFloater;
        private PictureBox imgFloater;
        private Panel panelImageFloater;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem1;
        private Button btnStorageWithdraw;
        private Button btnInventoryDeposit;
        private CheckBox chkDeleteExportInventory;
        private CheckBox chkDeleteExportStorage;
        private ToolStripMenuItem saveToolStripMenuItem;
        private Button btnSave;
        private Button btnInventoryDelete;
        private Button btnStorageDelete;
        private TabPage tabPageMissions;
        private TabPage tabEp1Missions;
        private Label txtMissionTactical;
        private Label label2;
        private Label txtMissionMagashi;
        private Label label13;
        private Label txtSkipEp1Start;
        private Label label12;
        private Label txtMissionEp1;
        private Label label1;
        private TabPage tabEp2Missions;
        private Label txtSkipEp2Start;
        private Label lblSkipEp2Start;
        private Label txtMissionEp2;
        private Label lblMissionEp2;
        private Label txtStoryEmiliaPoints;
        private Label txtStoryNagisaPoints;
        private TabPage tabPagePA;
        private TabControl tabPA;
        private TabPage tabPAMelee;
        private ListView lstPAMelee;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader4;
        private TabPage tabPABullets;
        private TabPage tabPATech;
        private ImageList paImageList;
        private GroupBox groupBox6;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label16;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private PictureBox pictureBox11;
        private PictureBox pictureBox12;
        private PictureBox pictureBox13;
        private PictureBox pictureBox14;
        private PictureBox pictureBox15;
        private PictureBox pictureBox16;
        private PictureBox pictureBox17;
        private PictureBox pictureBox18;
        private PictureBox pictureBox19;
        private PictureBox pictureBox20;
        private PictureBox pictureBox21;
        private PictureBox pictureBox22;
        private Label label18;
        private Label label19;
        private PictureBox pictureBox23;
        private Label label24;
        private Label label25;
        private PictureBox pictureBox24;
        private Label label26;
        private Label label30;
        private PictureBox pictureBox25;
        private Label txtPAHexMelee;
        private ListView lstPABullets;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ListView lstPATechs;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Label txtPAHexBullets;
        private Label txtPAHexTech;
        private TabPage tabTypeInfo;
        private TabControl tabControlClasses;
        private TabPage tabPageHunter;
        private Button btnHuAbilitiesOpen;
        private Label label20;
        private GroupBox grpHuTypeExtend;
        private PictureBox imgHuTmagRank;
        private PictureBox imgHuMachinegunRank;
        private Label txtHuExpBar;
        private Label txtHuExp;
        private Label label34;
        private PictureBox imgHuHandgunsRank;
        private Label label36;
        private PictureBox imgHuShotgunRank;
        private PictureBox imgHuClawRank;
        private PictureBox imgHuDaggersRank;
        private PictureBox imgHuSpearRank;
        private PictureBox imgHuWandRank;
        private PictureBox imgHuCardsRank;
        private PictureBox imgHuLaserRank;
        private PictureBox imgHuRifleRank;
        private PictureBox imgHuDaggerRank;
        private PictureBox imgHuSabersRank;
        private PictureBox imgHuKnucklesRank;
        private PictureBox imgHuShieldRank;
        private PictureBox imgHuRmagRank;
        private PictureBox imgHuHandgunRank;
        private PictureBox imgHuLongbowRank;
        private PictureBox imgHuWhipRank;
        private PictureBox imgHuClawsRank;
        private PictureBox imgHuDblSaberRank;
        private PictureBox imgHuRodRank;
        private PictureBox imgHuCrossbowRank;
        private PictureBox imgHuGrenadeRank;
        private PictureBox imgHuSlicerRank;
        private PictureBox imgHuSaberRank;
        private PictureBox imgHuAxeRank;
        private PictureBox imgHuSwordRank;
        private PictureBox imgHuRmag;
        private PictureBox imgHuMachinegun;
        private PictureBox imgHuCrossbow;
        private PictureBox imgHuCards;
        private PictureBox imgHuHandgun;
        private PictureBox imgHuHandguns;
        private PictureBox imgHuGrenade;
        private PictureBox imgHuLaser;
        private PictureBox imgHuLongbow;
        private PictureBox imgHuShotgun;
        private PictureBox imgHuSlicer;
        private PictureBox imgHuRifle;
        private PictureBox imgHuWhip;
        private PictureBox imgHuClaw;
        private PictureBox imgHuSaber;
        private PictureBox imgHuDagger;
        private PictureBox imgHuShield;
        private PictureBox imgHuTmag;
        private PictureBox imgHuRod;
        private PictureBox imgHuWand;
        private PictureBox imgHuClaws;
        private PictureBox imgHuDaggers;
        private PictureBox imgHuAxe;
        private PictureBox imgHuSabers;
        private PictureBox imgHuDblSaber;
        private PictureBox imgHuKnuckles;
        private PictureBox imgHuSpear;
        private PictureBox imgHuSword;
        private PictureBox pictureBox231;
        private Label lblHuLevel;
        private Label txtHuLevel;
        private Label label39;
        private TabPage tabPageRanger;
        private Label label10;
        private GroupBox grpRaTypeExtend;
        private Label txtRaExp;
        private PictureBox imgRaTmagRank;
        private PictureBox imgRaMachinegunRank;
        private Label txtRaExpBar;
        private Label label22;
        private PictureBox imgRaHandgunsRank;
        private Label label23;
        private PictureBox imgRaShotgunRank;
        private PictureBox imgRaClawRank;
        private PictureBox imgRaDaggersRank;
        private PictureBox imgRaSpearRank;
        private PictureBox imgRaWandRank;
        private PictureBox imgRaCardsRank;
        private PictureBox imgRaLaserRank;
        private PictureBox imgRaRifleRank;
        private PictureBox imgRaDaggerRank;
        private PictureBox imgRaSabersRank;
        private PictureBox imgRaKnucklesRank;
        private PictureBox imgRaShieldRank;
        private PictureBox imgRaRmagRank;
        private PictureBox imgRaHandgunRank;
        private PictureBox imgRaLongbowRank;
        private PictureBox imgRaWhipRank;
        private PictureBox imgRaClawsRank;
        private PictureBox imgRaDblSaberRank;
        private PictureBox imgRaRodRank;
        private PictureBox imgRaCrossbowRank;
        private PictureBox imgRaGrenadeRank;
        private PictureBox imgRaSlicerRank;
        private PictureBox imgRaSaberRank;
        private PictureBox imgRaAxeRank;
        private PictureBox imgRaSwordRank;
        private PictureBox imgRaRmag;
        private PictureBox imgRaMachinegun;
        private PictureBox imgRaCrossbow;
        private PictureBox imgRaCards;
        private PictureBox imgRaHandgun;
        private PictureBox imgRaHandguns;
        private PictureBox imgRaGrenade;
        private PictureBox imgRaLaser;
        private PictureBox imgRaLongbow;
        private PictureBox imgRaShotgun;
        private PictureBox imgRaSlicer;
        private PictureBox imgRaRifle;
        private PictureBox imgRaWhip;
        private PictureBox imgRaClaw;
        private PictureBox imgRaSaber;
        private PictureBox imgRaDagger;
        private PictureBox imgRaShield;
        private PictureBox imgRaTmag;
        private PictureBox imgRaRod;
        private PictureBox imgRaWand;
        private PictureBox imgRaClaws;
        private PictureBox imgRaDaggers;
        private PictureBox imgRaAxe;
        private PictureBox imgRaSabers;
        private PictureBox imgRaDblSaber;
        private PictureBox imgRaKnuckles;
        private PictureBox imgRaSpear;
        private PictureBox imgRaSword;
        private PictureBox pictureBox174;
        private Label lblRaLevel;
        private Label txtRaLevel;
        private Label label35;
        private Button btnRaAbilitiesOpen;
        private TabPage tabPageForce;
        private Label label8;
        private GroupBox grpFoTypeExtend;
        private Label txtFoExp;
        private PictureBox imgFoTmagRank;
        private PictureBox imgFoMachinegunRank;
        private Label txtFoExpBar;
        private Label label14;
        private PictureBox imgFoHandgunsRank;
        private Label label15;
        private PictureBox imgFoShotgunRank;
        private PictureBox imgFoClawRank;
        private PictureBox imgFoDaggersRank;
        private PictureBox imgFoSpearRank;
        private PictureBox imgFoWandRank;
        private PictureBox imgFoCardsRank;
        private PictureBox imgFoLaserRank;
        private PictureBox imgFoRifleRank;
        private PictureBox imgFoDaggerRank;
        private PictureBox imgFoSabersRank;
        private PictureBox imgFoKnucklesRank;
        private PictureBox imgFoShieldRank;
        private PictureBox imgFoRmagRank;
        private PictureBox imgFoHandgunRank;
        private PictureBox imgFoLongbowRank;
        private PictureBox imgFoWhipRank;
        private PictureBox imgFoClawsRank;
        private PictureBox imgFoDblSaberRank;
        private PictureBox imgFoRodRank;
        private PictureBox imgFoCrossbowRank;
        private PictureBox imgFoGrenadeRank;
        private PictureBox imgFoSlicerRank;
        private PictureBox imgFoSaberRank;
        private PictureBox imgFoAxeRank;
        private PictureBox imgFoSwordRank;
        private PictureBox imgFoRmag;
        private PictureBox imgFoMachinegun;
        private PictureBox imgFoCrossbow;
        private PictureBox imgFoCards;
        private PictureBox imgFoHandgun;
        private PictureBox imgFoHandguns;
        private PictureBox imgFoGrenade;
        private PictureBox imgFoLaser;
        private PictureBox imgFoLongbow;
        private PictureBox imgFoShotgun;
        private PictureBox imgFoSlicer;
        private PictureBox imgFoRifle;
        private PictureBox imgFoWhip;
        private PictureBox imgFoClaw;
        private PictureBox imgFoSaber;
        private PictureBox imgFoDagger;
        private PictureBox imgFoShield;
        private PictureBox imgFoTmag;
        private PictureBox imgFoRod;
        private PictureBox imgFoWand;
        private PictureBox imgFoClaws;
        private PictureBox imgFoDaggers;
        private PictureBox imgFoAxe;
        private PictureBox imgFoSabers;
        private PictureBox imgFoDblSaber;
        private PictureBox imgFoKnuckles;
        private PictureBox imgFoSpear;
        private PictureBox imgFoSword;
        private PictureBox pictureBox117;
        private Label lblFoLevel;
        private Label txtFoLevel;
        private Button btnFoAbilitiesOpen;
        private TabPage tabPageVanguard;
        private Label label27;
        private GroupBox grpVaTypeExtend;
        private Label txtVaExp;
        private PictureBox imgVaTmagRank;
        private PictureBox imgVaMachinegunRank;
        private Label txtVaExpBar;
        private Label label28;
        private PictureBox imgVaHandgunsRank;
        private Label label29;
        private PictureBox imgVaShotgunRank;
        private PictureBox imgVaClawRank;
        private PictureBox imgVaDaggersRank;
        private PictureBox imgVaSpearRank;
        private PictureBox imgVaWandRank;
        private PictureBox imgVaCardsRank;
        private PictureBox imgVaLaserRank;
        private PictureBox imgVaRifleRank;
        private PictureBox imgVaDaggerRank;
        private PictureBox imgVaSabersRank;
        private PictureBox imgVaKnucklesRank;
        private PictureBox imgVaShieldRank;
        private PictureBox imgVaRmagRank;
        private PictureBox imgVaHandgunRank;
        private PictureBox imgVaLongbowRank;
        private PictureBox imgVaWhipRank;
        private PictureBox imgVaClawsRank;
        private PictureBox imgVaDblSaberRank;
        private PictureBox imgVaRodRank;
        private PictureBox imgVaCrossbowRank;
        private PictureBox imgVaGrenadeRank;
        private PictureBox imgVaSlicerRank;
        private PictureBox imgVaSaberRank;
        private PictureBox imgVaAxeRank;
        private PictureBox imgVaSwordRank;
        private PictureBox imgVaRmag;
        private PictureBox imgVaMachinegun;
        private PictureBox imgVaCrossbow;
        private PictureBox imgVaCards;
        private PictureBox imgVaHandgun;
        private PictureBox imgVaHandguns;
        private PictureBox imgVaGrenade;
        private PictureBox imgVaLaser;
        private PictureBox imgVaLongbow;
        private PictureBox imgVaShotgun;
        private PictureBox imgVaSlicer;
        private PictureBox imgVaRifle;
        private PictureBox imgVaWhip;
        private PictureBox imgVaClaw;
        private PictureBox imgVaSaber;
        private PictureBox imgVaDagger;
        private PictureBox imgVaShield;
        private PictureBox imgVaTmag;
        private PictureBox imgVaRod;
        private PictureBox imgVaWand;
        private PictureBox imgVaClaws;
        private PictureBox imgVaDaggers;
        private PictureBox imgVaAxe;
        private PictureBox imgVaSabers;
        private PictureBox imgVaDblSaber;
        private PictureBox imgVaKnuckles;
        private PictureBox imgVaSpear;
        private PictureBox imgVaSword;
        private PictureBox pictureBox5;
        private Label txtVaLevel;
        private Label lblVaLevel;
        private Button btnVaAbilitiesOpen;
        private TabPage tabPageRebirth;
        private Label label17;
        private Label label32;
        private GroupBox grpRebirth;
        private NumericUpDown numRebirthSTA;
        private Label txtRebirthSTA;
        private Label label50;
        private NumericUpDown numRebirthPP;
        private NumericUpDown numRebirthHP;
        private Label txtRebirthPP;
        private Label label55;
        private Label label56;
        private Label txtRebirthHP;
        private NumericUpDown numRebirthMND;
        private NumericUpDown numRebirthTEC;
        private NumericUpDown numRebirthEVA;
        private NumericUpDown numRebirthACC;
        private NumericUpDown numRebirthDEF;
        private NumericUpDown numRebirthATK;
        private Label txtRebirthMND;
        private Label label53;
        private Label txtRebirthTEC;
        private Label label38;
        private Label txtRebirthEVA;
        private Label txtRebirthACC;
        private Label label42;
        private Label label43;
        private Label txtRebirthDEF;
        private Label label45;
        private Label label49;
        private Label txtRebirthATK;
        private Label txtRebirthCount;
        private Label txtRebirthPoints;
        private Label label48;
        private ListView lstRebirthRewards;
        private ColumnHeader columnHeader9;
        private Label txtRebirthMaxType;
        private Label label33;
        private Label txtRebirthNextSTA;
        private Label txtRebirthNextPP;
        private Label txtRebirthNextHP;
        private Label txtRebirthNextMND;
        private Label txtRebirthNextTEC;
        private Label txtRebirthNextEVA;
        private Label txtRebirthNextACC;
        private Label txtRebirthNextDEF;
        private Label txtRebirthNextATK;
        private Label txtRebirthBpSTA;
        private Label txtRebirthBpPP;
        private Label txtRebirthBpHP;
        private Label txtRebirthBpMND;
        private Label txtRebirthBpTEC;
        private Label txtRebirthBpEVA;
        private Label txtRebirthBpACC;
        private Label txtRebirthBpDEF;
        private Label txtRebirthBpATK;
        private Label label41;
        private Label label40;
        private Label label37;
        private CheckBox chkRebirthSpoof;
        private ComboBox comboRebirthExtend;
        private Button btnRebirth;
        private CheckBox chkRebirthNoLevelDrop;
        private ToolStripMenuItem itemDatabasesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem weaponDatabaseToolStripMenuItem;
        private ListView inventoryView;
        private ColumnHeader columnHeader1;
        private ImageList imageListWeaponElements;
        private PictureBox picWeaponSlot01;
        private GroupBox groupBox7;
        private Panel panel1;
        private PictureBox picWeaponSlot06;
        private PictureBox picWeaponSlot02;
        private PictureBox picWeaponSlot05;
        private PictureBox picWeaponSlot03;
        private PictureBox picWeaponSlot04;
        private PrintPreviewDialog printPreviewDialog1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private Label txtEp1Complete;
        private Label label44;
        private Label txtEp2Complete;
        private Label label46;
        private TabPage tabPageInfinityMission;
        private Label txtInfinityMissionQty;
        private GroupBox grpInfinityMissionDetails;
        private Label label63;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private Button btnDeleteInfinityMission;
        private Button btnImportInfinityMission;
        private Button btnExportInfinityMission;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label txtInfNameJp;
        private Label txtInfNameEn;
        private Label txtInfMisEnemy2;
        private Label txtInfMisEnemy1;
        private Label txtInfMisBoss;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox grpInfMisSpecial;
        private Label txtInfMisSpecial;
        private Label txtInfEnemyLevel;
        private Button btnModifyInfinityMission;
        public TabControl tabArea;
        public TabControl tabControlMissions;
        public ListView lstInfinityMissions;
        private GroupBox grpInfMisExtra;
        private Label txtInfMisSynthPoint;
        private Label txtInfMisCreatedBy;
        private Button btnImportMissions;
        private Button btnExportMissions;
        private Label txtAllowQuitMission;
        private Label label47;
        public int chunkPos;
        private bool allowDownload = true;
        private byte[] downloadedData = new byte[0x7d000];
        private string downloadedDataName;
        public bool firstboot = true;
        public itemDbClass item_db = new itemDbClass();
        public int item_db_filled;

        public pspo2seForm()
        {
            this.InitializeComponent();
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\databases");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\temp");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\weapon_images");
                this.firstInstall = true;
                this.databasesOk = false;
                MessageBox.Show("This is your first time running the application\r\nYou will need to update the databases\r\nbefore you can do anything.\r\n\r\nChoose databases from the top menu to update.", "First time use", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\keys"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\keys");
            }
            if (!this.downloadRequiredFile("FolderZipper.dll", "The application will not start without this file.", 0x1800L))
            {
                MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            if (!this.downloadRequiredFile("ICSharpCode.SharpZipLib.dll", "The application will not start without this file.", 0x31000L))
            {
                MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            if (!this.downloadRequiredFile("pspo2se_updater.exe", "The application will not start without this file.", 0x1800L))
            {
                MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
            this.downloadRequiredFile("SED.exe", "You cannot load encrypted save files without this.", 0xca00L);
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
            {
                this.action_setupLegitApp();
            }
            this.btnBrowse.Enabled = true;
            this.menuStrip.Enabled = true;
        }

        public string abilityToJp(abilityType ability)
        {
            switch (ability)
            {
                case abilityType.None:
                    return "";

                case abilityType.Burn:
                    return "(燃焼)";

                case abilityType.Poison:
                    return "(毒)";

                case abilityType.Infection:
                    return "(感染)";

                case abilityType.Silence:
                    return "(沈黙)";

                case abilityType.Shock:
                    return "(感電)";

                case abilityType.Freeze:
                    return "(凍結)";

                case abilityType.Sleep:
                    return "(睡眠)";

                case abilityType.Stun:
                    return "(麻痺)";

                case abilityType.Confusion:
                    return "(混乱)";

                case abilityType.Taunt:
                    return "(魅了)";

                case abilityType.Incapacitate:
                    return "(戦闘不能)";

                case abilityType.Drain:
                    return "(HP吸収)";

                case abilityType.Damage_reflect:
                    return "(ダメージ反射)";

                case abilityType.HP_affects_pwr:
                    return "(憤怒)";

                case abilityType.AutoDamage:
                    return "(自動ダメージ)";

                case abilityType.AutoDefend:
                    return "(自動回復)";

                case abilityType.AttackUp:
                    return "(攻撃法撃↑)";

                case abilityType.AttackDown:
                    return "(攻撃法撃↓)";

                case abilityType.DefenseUp:
                    return "(防御回避精神↑)";

                case abilityType.DefenseDown:
                    return "(防御回避精神↓)";

                case abilityType.Empow_none:
                    return "";

                case abilityType.Empow_fire:
                    return "(炎属性威力↑)";

                case abilityType.Empow_ice:
                    return "(氷属性威力↑)";

                case abilityType.Empow_lightning:
                    return "(雷属性威力↑)";

                case abilityType.Empow_earth:
                    return "(土属性威力↑)";

                case abilityType.Empow_light:
                    return "(光属性威力↑)";

                case abilityType.Empow_dark:
                    return "(闇属性威力↑)";

                case abilityType.Empow_healing:
                    return "(回復力↑)";
            }
            return ("unk_" + ability);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://files-ds-scene.net/retrohead/pspo2se/");
        }

        private void action_browse()
        {
            if (!this.databasesOk)
            {
                MessageBox.Show("The databases must be updated before you can use the application", "Database Updates Required", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.checkDatabaseUpdate(true);
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog {
                    Title = "PSPo2 Save Editor: Open File"
                };
                if (this.legitVersion())
                {
                    dialog.Title = "PSPo2 Save Viewer: Open File";
                }
                dialog.Filter = "All files (*.*)|*.*|PSP Decrypted Save Data (*.bin)|*.bin|PSP Encrypted Save Data (*.bin)|*.bin";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtFileLoc.Text = dialog.FileName;
                    this.tabArea.SelectedTab = this.tabPageInfo;
                    this.disableMainForm();
                    this.saveOk = this.loadSaveFile(false);
                    if (this.saveOk)
                    {
                        this.showGameImage();
                        if (this.lstSaveSlotView.Items.Count > 0)
                        {
                            this.lstSaveSlotView.Items[0].Selected = true;
                            this.enableMainForm();
                        }
                    }
                }
            }
        }

        private void action_launchTypeAbilitiesForm()
        {
            string attachedAbilities = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities;
            this.abilitiesForm.oldJobs = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job;
            this.abilitiesForm.newJob = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex];
            this.abilitiesForm.selectedJob = (jobType) this.tabControlClasses.SelectedIndex;
            this.abilitiesForm.max_abilities = this.mainSettings.saveStructureIndex.max_type_abilities;
            this.abilitiesForm.character_name = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].name;
            this.abilitiesForm.abilityDb = this.abilityDb;
            this.abilitiesForm.saveType = this.saveData.type;
            bool flag = false;
            while (!flag)
            {
                DialogResult result = this.abilitiesForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    jobClass newJob = this.abilitiesForm.newJob;
                    if (newJob.attachedAbilities != attachedAbilities)
                    {
                        int pos = (((this.mainSettings.saveStructureIndex.type_level_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0x10) + (this.tabControlClasses.SelectedIndex * this.mainSettings.saveStructureIndex.type_extend_size)) + 4;
                        this.overwriteHexInBuffer(newJob.attachedAbilities, pos);
                        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities = newJob.attachedAbilities;
                    }
                    flag = true;
                    continue;
                }
                if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities == attachedAbilities)
                {
                    flag = true;
                    continue;
                }
                if (MessageBox.Show("You are about to quit without saving changes\r\nAre you sure?", "Changes were made", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities = attachedAbilities;
                    flag = true;
                }
            }
        }

        private void action_loadDatabases()
        {
            this.databasesOk = true;
            this.loadItemDatabase();
            if (!this.abilityDb.loadDatabase())
            {
                this.databasesOk = false;
            }
            this.loadExpLevelDatabase();
            this.loadExpTypeDatabase();
            if (this.saveData.type != SaveType.NONE)
            {
                this.reloadEverything();
            }
        }

        private void action_save()
        {
            if (!this.saveOk)
            {
                MessageBox.Show("There is no data to save", "Save Data Buffer Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (MessageBox.Show("Are you sure you want to overwrite the loaded save file?", "Confirm Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
            {
                if (this.mainSettings.saveStructureIndex.encrypted)
                {
                    if (this.saveBufferDataToFile(0, this.saveData.size, "PSP Encrypted Save Data (*.bin)|*.bin", 0, true, this.txtFileLoc.Text, ""))
                    {
                        MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (this.saveBufferDataToFile(0, this.saveData.size, "PSP Decrypted Save Data (*.bin)|*.bin", 0, true, this.txtFileLoc.Text, ""))
                {
                    MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void action_saveas()
        {
            if (!this.saveOk)
            {
                MessageBox.Show("There is no data to save", "Save Data Buffer Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.mainSettings.saveStructureIndex.encrypted)
            {
                if (this.saveBufferDataToFile(0, this.saveData.size, "PSP Encrypted Save Data (*.bin)|*.bin", 0, false, null, ""))
                {
                    MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else if (this.saveBufferDataToFile(0, this.saveData.size, "PSP Decrypted Save Data (*.bin)|*.bin", 0, false, null, ""))
            {
                MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
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

        public void addExpLevelInfoToDb(string csvLine)
        {
            if (this.exp_db_filled >= 0x163)
            {
                MessageBox.Show("Fatal Error! ExpLevel Database is too large!");
            }
            string[] strArray = csvLine.Split(new char[] { '|' });
            this.exp_db.level[this.exp_db_filled] = new expDb_ItemClass();
            try
            {
                this.exp_db.level[this.exp_db_filled].level = int.Parse(strArray[0]);
                this.exp_db.level[this.exp_db_filled].exp = int.Parse(strArray[1]);
                this.exp_db.level[this.exp_db_filled].exp_next = int.Parse(strArray[2]);
                this.exp_db_filled++;
            }
            catch
            {
                if (!this.shownCorruptExpCsv)
                {
                    MessageBox.Show("The ExpLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.shownCorruptExpCsv = true;
                    this.databasesOk = false;
                }
            }
        }

        public void addExpTypeInfoToDb(string csvLine)
        {
            if (this.type_db_filled >= 0x37)
            {
                MessageBox.Show("Fatal Error! ExpTypeLevel Database is too large!");
            }
            string[] strArray = csvLine.Split(new char[] { '|' });
            this.typeexp_db.level[this.type_db_filled] = new expDb_ItemClass();
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
                    MessageBox.Show("The ExpTypeLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.shownCorruptExpTypeCsv = true;
                    this.databasesOk = false;
                }
            }
            this.type_db_filled++;
        }

        public void addItemToDb(string csvLine)
        {
            string[] strArray = csvLine.Split(new char[] { '|' });
            this.item_db.item[this.item_db_filled] = new itemDb_ItemClass();
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
                MessageBox.Show(string.Concat(new object[] { "row 7 [", this.item_db_filled, "] incorrect format ", strArray[7] }));
            }
            try
            {
                this.item_db.item[this.item_db_filled].acc = int.Parse(strArray[8]);
            }
            catch
            {
                this.databasesOk = false;
                MessageBox.Show(string.Concat(new object[] { "row 8 [", this.item_db_filled, "] incorrect format ", strArray[8] }));
            }
            this.item_db.item[this.item_db_filled].level = strArray[9];
            try
            {
                this.item_db.item[this.item_db_filled].ext_power = int.Parse(strArray[10]);
            }
            catch
            {
                this.databasesOk = false;
                MessageBox.Show(string.Concat(new object[] { "row 10 [", this.item_db_filled, "] incorrect format ", strArray[10] }));
            }
            try
            {
                this.item_db.item[this.item_db_filled].ext_acc = int.Parse(strArray[11]);
            }
            catch
            {
                this.databasesOk = false;
                MessageBox.Show(string.Concat(new object[] { "row 11 [", this.item_db_filled, "] incorrect format ", strArray[11] }));
            }
            this.item_db.item[this.item_db_filled].ext_level = strArray[12];
            try
            {
                this.item_db.item[this.item_db_filled].inf_ext_power = int.Parse(strArray[13]);
            }
            catch
            {
                this.databasesOk = false;
                MessageBox.Show(string.Concat(new object[] { "row 13 [", this.item_db_filled, "] incorrect format ", strArray[13] }));
            }
            try
            {
                this.item_db.item[this.item_db_filled].inf_ext_acc = int.Parse(strArray[14]);
            }
            catch
            {
                this.databasesOk = false;
                MessageBox.Show(string.Concat(new object[] { "row 14 [", this.item_db_filled, "] incorrect format ", strArray[14] }));
            }
            this.item_db.item[this.item_db_filled].inf_ext_level = strArray[15];
            this.item_db.item[this.item_db_filled].special = strArray[0x10];
            this.item_db.item[this.item_db_filled].special_level = strArray[0x11];
            this.item_db.item[this.item_db_filled].ext_special_level = strArray[0x12];
            if (this.item_db.item[this.item_db_filled].ext_special_level == "")
            {
                this.item_db.item[this.item_db_filled].ext_special_level = this.item_db.item[this.item_db_filled].special_level;
            }
            if (this.item_db.item[this.item_db_filled].ext_special_level == "0")
            {
                this.item_db.item[this.item_db_filled].ext_special_level = "";
            }
            if (this.item_db.item[this.item_db_filled].special_level == "0")
            {
                this.item_db.item[this.item_db_filled].special_level = "";
            }
            try
            {
                this.item_db.item[this.item_db_filled].rarity = int.Parse(strArray[0x13]);
            }
            catch
            {
                this.databasesOk = false;
                MessageBox.Show(string.Concat(new object[] { "row 19 [", this.item_db_filled, "] incorrect format ", strArray[0x13] }));
            }
            this.item_db_filled++;
        }

        private void addRebirthReward(string str, Color col)
        {
            ListViewItem item = new ListViewItem {
                Text = str,
                ForeColor = col
            };
            this.lstRebirthRewards.Items.Add(item);
        }

        private unsafe int adjustPosition(int pos, BinaryReader br, int item_position, bool reload, string err_identifier, bool showSaveParseProgress)
        {
            int num = pos;
            if (pos > item_position)
            {
                MessageBox.Show(string.Concat(new object[] { "Requested position ", pos, " is greater than the predicted item pos", item_position }));
                return 0;
            }
            while (num < item_position)
            {
                this.brSkipBytes(1, &num, br, reload, showSaveParseProgress);
            }
            return num;
        }

        private bool allowShowItem(int page, inventoryItemClass item)
        {
            switch (page)
            {
                case 1:
                    return (item.type == itemType.Weapon);

                case 2:
                    return ((item.type == itemType.Armor) || (item.type == itemType.Slot_Unit));

                case 3:
                    return ((item.type == itemType.Green_Item) || ((item.type == itemType.PA_Disk_Melee) || ((item.type == itemType.PA_Disk_Ranged) || ((item.type == itemType.PA_Disk_Technique) || ((item.type == itemType.Trap) || (item.type == itemType.Infinity_Code))))));

                case 4:
                    return ((item.type == itemType.Clothes_android) || (item.type == itemType.Clothes_human));

                case 5:
                    return ((item.type == itemType.Room_Decoration) || ((item.type == itemType.Extend_Code) || (item.type == itemType.My_Synth_Device)));

                case 6:
                    return ((item.type == itemType.free_slot) || (item.type == itemType.unknown_5));
            }
            MessageBox.Show("page: " + page + "not handled in allowShowItem()");
            return false;
        }

        private unsafe string brGetData(int bytes, BinaryReader br, int* pos, saveInfoDataType return_type, bool reload, bool showSaveParseProgress)
        {
            int num = 0;
            bool flag = true;
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            int num1 = pos[0];
            pos[0] += bytes;
            for (int i = 0; i < bytes; i++)
            {
                num = this.readByteAndSaveInSaveBuffer(br, reload, "GET DATA", showSaveParseProgress);
                if (builder2.Length == 0)
                {
                    builder2.Append(this.run.hexAndMathFunction.decimalByteConvert(num, return_type.ToString()));
                }
                else
                {
                    builder2.Append(this.run.hexAndMathFunction.decimalByteConvert(num, return_type.ToString()) ?? "");
                }
                if (flag)
                {
                    builder.Append(this.run.hexAndMathFunction.decimalByteConvert(num, return_type.ToString()));
                }
                flag = !flag;
            }
            return ((return_type != saveInfoDataType.str) ? builder2.ToString() : builder.ToString());
        }

        public unsafe int brGetInt(int bytes, int* pos, BinaryReader br, bool reload, bool showSaveParseProgress, string debugHelper = "")
        {
            string hex = "";
            hex = this.brGetData(bytes, br, pos, saveInfoDataType.hex, reload, showSaveParseProgress);
            hex = this.run.hexAndMathFunction.reversehex(hex, bytes * 2);
            if (debugHelper != "")
            {
                MessageBox.Show(string.Concat(new object[] { "[", debugHelper, "]\r\nhex is ", hex, "\r\nint is", int.Parse(hex, NumberStyles.HexNumber) }));
            }
            return int.Parse(hex, NumberStyles.HexNumber);
        }

        public unsafe int brGetInt32(int* pos, BinaryReader br, bool reload, bool showSaveParseProgress, string debugHelper = "")
        {
            string hex = "";
            hex = this.brGetData(4, br, pos, saveInfoDataType.hex, reload, showSaveParseProgress);
            hex = this.run.hexAndMathFunction.reversehex(hex, 8);
            if (debugHelper != "")
            {
                MessageBox.Show(string.Concat(new object[] { "[", debugHelper, "]\r\nhex is ", hex, "\r\nint32 is", int.Parse(hex, NumberStyles.HexNumber) }));
            }
            return int.Parse(hex, NumberStyles.HexNumber);
        }

        public unsafe inventoryItemClass brGetItem(int* pos, BinaryReader br, bool reload)
        {
            string str;
            inventoryItemClass class2 = new inventoryItemClass {
                id = pos[0],
                hex = this.brGetData(4, br, pos, saveInfoDataType.hex, reload, true)
            };
            class2.hex_reversed = this.run.hexAndMathFunction.reversehex(class2.hex, 8);
            if ((class2.hex != "00000000") && (class2.hex != "FFFFFFFF"))
            {
                class2.type = this.getItemTypeFromHex(class2.hex);
                class2.used = true;
            }
            else
            {
                class2.type = itemType.free_slot;
                class2.used = false;
            }
            if (class2.type != itemType.Weapon)
            {
                class2.qty = this.brGetInt32(pos, br, reload, true, "");
                class2.qty_max = this.brGetInt32(pos, br, reload, true, "");
                this.brSkipBytes(2, pos, br, reload, true);
                str = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
                class2.grinds = int.Parse(str.Substring(0, 1), NumberStyles.HexNumber);
                class2.extended = int.Parse(str.Substring(1, 1), NumberStyles.HexNumber);
                class2.locked = false;
                if (int.Parse(str.Substring(2, 1), NumberStyles.HexNumber) != 0)
                {
                    class2.locked = true;
                }
                class2.rarity = int.Parse(str.Substring(3, 1), NumberStyles.HexNumber);
            }
            else
            {
                this.brSkipBytes(4, pos, br, reload, true);
                class2.ability = (abilityType) this.brGetInt(1, pos, br, reload, true, "");
                str = this.brGetData(1, br, pos, saveInfoDataType.hex, reload, true);
                class2.spcl_effect = this.hexToEffect(str);
                class2.inf_extended = (itemInfExtendType) int.Parse(str.Substring(1, 1), NumberStyles.HexNumber);
                class2.spcl_effect_info = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
                str = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
                class2.power_add = int.Parse(this.run.hexAndMathFunction.reversehex(str, 4), NumberStyles.HexNumber);
                str = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
                class2.grinds = int.Parse(str.Substring(0, 1), NumberStyles.HexNumber);
                class2.extended = int.Parse(str.Substring(1, 1), NumberStyles.HexNumber);
                class2.locked = false;
                if (int.Parse(str.Substring(2, 1), NumberStyles.HexNumber) != 0)
                {
                    class2.locked = true;
                }
                class2.rarity = int.Parse(str.Substring(3, 1), NumberStyles.HexNumber);
                if (int.Parse(str.Substring(2, 1), NumberStyles.HexNumber) == 15)
                {
                    class2.locked = false;
                    class2.rarity = -1;
                }
            }
            class2.pa_level = this.brGetInt(1, pos, br, reload, true, "");
            class2.element = (elementType) class2.pa_level;
            class2.percent = this.brGetInt(1, pos, br, reload, true, "");
            class2.style = (weaponStyleType) this.brGetInt(1, pos, br, reload, true, "");
            if (class2.type == itemType.Weapon)
            {
                class2.hand = (weaponHandType) this.brGetInt(1, pos, br, reload, true, "");
            }
            else
            {
                class2.clothes_man = (clothesManufacturerType) this.brGetInt(1, pos, br, reload, true, "");
            }
            itemDb_ItemClass class3 = new itemDb_ItemClass();
            class3 = this.findItemInDb(class2.hex_reversed);
            class2.name = class3.name;
            class2.name_jp = class3.name_jp;
            class2.desc = class3.desc;
            class2.desc_jp = class3.desc_jp;
            class2.infinity_item = class3.infinity_item;
            class2.power = class3.power;
            class2.acc = class3.acc;
            class2.level = class3.level;
            class2.ext_power = class3.ext_power;
            class2.ext_acc = class3.ext_acc;
            class2.ext_level = class3.ext_level;
            class2.inf_ext_power = class3.inf_ext_power;
            class2.inf_ext_acc = class3.inf_ext_acc;
            class2.inf_ext_level = class3.inf_ext_level;
            class2.special = class3.special;
            class2.special_level = class3.special_level;
            class2.ext_special_level = class3.ext_special_level;
            return class2;
        }

        public unsafe void brSkipBytes(int bytes, int* pos, BinaryReader br, bool reload, bool showSaveParseProgress)
        {
            this.brGetData(bytes, br, pos, saveInfoDataType.hex, reload, showSaveParseProgress);
        }

        public void brWriteFromBuffer(BinaryWriter writer, int posStart, int len)
        {
            if ((len + posStart) > this.savedata_decimal_array_filled)
            {
                MessageBox.Show(string.Concat(new object[] { "Tried to write a file [", len, "] larger than the buffer [", this.savedata_decimal_array_filled, "]" }), "Fatal Error!");
            }
            else
            {
                for (int i = posStart; i < (posStart + len); i++)
                {
                    writer.Write((byte) this.savedata_decimal_array[i]);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.action_browse();
        }

        private void btnDeleteInfinityMission_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the last mission in the list?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int num = (this.saveData.infinityMissions.itemsUsed * 0x68) + this.mainSettings.saveStructureIndex.infinity_mission_pos;
                this.saveData.infinityMissions.itemsUsed--;
                string hex = this.saveData.infinityMissions.itemsUsed.ToString("X1");
                while (true)
                {
                    if (hex.Length >= 2)
                    {
                        this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.infinity_mission_pos + 0x28a0);
                        hex = "1198040121012040800001020100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                        this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.infinity_mission_pos + (0x68 * this.saveData.infinityMissions.itemsUsed));
                        this.txtInfinityMissionQty.Text = this.saveData.infinityMissions.itemsUsed + "/100";
                        this.lstInfinityMissions.Items[this.lstInfinityMissions.Items.Count - 1].Remove();
                        break;
                    }
                    hex = "0" + hex;
                }
            }
        }

        private void btnExportCharacter_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.character_file_name, " (*", this.mainSettings.saveStructureIndex.character_file_ext, ")|*", this.mainSettings.saveStructureIndex.character_file_ext };
            string str = string.Concat(strArray);
            if (this.saveBufferDataToFile(this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index), this.mainSettings.saveStructureIndex.slot_size, str, 0, false, null, this.lstSaveSlotView.SelectedItems[0].Text))
            {
                MessageBox.Show("The character file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnExportInfinityMission_Click(object sender, EventArgs e)
        {
            int startpos = this.mainSettings.saveStructureIndex.infinity_mission_pos + (int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 0x68);
            if (this.saveBufferDataToFile(startpos, 0x68, "PSPo2i Mission File (*pspo2imission)|*pspo2imission", 0, false, null, this.lstInfinityMissions.SelectedItems[0].Text))
            {
                MessageBox.Show("The mission file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("The mission file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnExportMissions_Click(object sender, EventArgs e)
        {
            int startpos = 0x47048;
            if (this.saveBufferDataToFile(startpos, 0x28a1, "PSPo2i Mission Pack File (*pspo2imissions)|*pspo2imissions", 0, false, null, "Pspo2 Infinity Mission Pack"))
            {
                MessageBox.Show("The mission pack file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("The mission pack file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnFoAbilitiesOpen_Click(object sender, EventArgs e)
        {
            this.action_launchTypeAbilitiesForm();
        }

        private void btnHuAbilitiesOpen_Click(object sender, EventArgs e)
        {
            this.action_launchTypeAbilitiesForm();
        }

        private void btnImportCharacter_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.character_file_name, " (*", this.mainSettings.saveStructureIndex.character_file_ext, ")|*", this.mainSettings.saveStructureIndex.character_file_ext };
            string str = string.Concat(strArray);
            if (this.loadFileIntoBuffer(this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index), str, partFileType.character, false, "") > 0)
            {
                this.reloadEverything();
                MessageBox.Show("The character file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnImportInfinityMission_Click(object sender, EventArgs e)
        {
            int startpos = 0;
            string str = "PSPo2i Mission File (*pspo2imission)|*pspo2imission";
            if (this.saveData.infinityMissions.itemsUsed >= 100)
            {
                if (MessageBox.Show("You do not have any available infinity mission slots.\n\nDo you want to overwrite the selected slot?", "Max Slots Reached", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    if (this.lstInfinityMissions.SelectedItems.Count <= 0)
                    {
                        MessageBox.Show("You must select a mission from your list to overwrite.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        startpos = (int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 0x68) + this.mainSettings.saveStructureIndex.infinity_mission_pos;
                        if (this.loadFileIntoBuffer(startpos, str, partFileType.infinity_mission, false, "") > 0)
                        {
                            this.reloadEverything();
                        }
                    }
                }
            }
            else if (MessageBox.Show("Do you want to import a mission or multiple missions into available slots?", "Confirm Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                if (MessageBox.Show("Do you want to overwrite the selected slot?", "Confirm Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (this.lstInfinityMissions.SelectedItems.Count <= 0)
                    {
                        MessageBox.Show("You must select a mission from your list to overwrite.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        startpos = (int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString()) * 0x68) + this.mainSettings.saveStructureIndex.infinity_mission_pos;
                        if (this.loadFileIntoBuffer(startpos, str, partFileType.infinity_mission, false, "") > 0)
                        {
                            this.reloadEverything();
                        }
                    }
                }
            }
            else
            {
                startpos = (this.saveData.infinityMissions.itemsUsed * 0x68) + this.mainSettings.saveStructureIndex.infinity_mission_pos;
                int num2 = this.loadFileIntoBuffer(startpos, str, partFileType.infinity_mission, true, "");
                if (num2 > 0)
                {
                    this.saveData.infinityMissions.itemsUsed += num2;
                    string hex = this.saveData.infinityMissions.itemsUsed.ToString("X1");
                    while (hex.Length < 2)
                    {
                        hex = "0" + hex;
                    }
                    this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.infinity_mission_pos + 0x28a0);
                    this.reloadEverything();
                }
            }
        }

        private void btnImportMissions_Click(object sender, EventArgs e)
        {
            int startpos = 0;
            string str = "PSPo2i Mission Pack File (*pspo2imissions)|*pspo2imissions";
            if (MessageBox.Show("Are you sure you want to import missions overwriting all of the current missions?", "Confirm Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
            {
                startpos = 0x47048;
                if (this.loadFileIntoBuffer(startpos, str, partFileType.infinity_mission_pack, false, "") > 0)
                {
                    this.reloadEverything();
                }
            }
        }

        private void btnInventoryDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
            {
                int id = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id;
                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed--;
                string hex = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X2");
                this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.inventory_slots_used_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index));
                this.overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
                this.overwriteHexInBuffer("00000000", id - 8);
                this.reloadEverything();
            }
        }

        private void btnInventoryDeposit_Click(object sender, EventArgs e)
        {
            if (this.saveData.sharedInventory.itemsUsed >= this.mainSettings.saveStructureIndex.shared_inventory_slots)
            {
                MessageBox.Show("The shared storage is full", "Storage Full", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int id = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id;
                if (!this.saveItemDataToFile(id, 20, "", "", Directory.GetCurrentDirectory() + @"\data\temp\moving." + this.mainSettings.saveStructureIndex.item_file_ext, true))
                {
                    MessageBox.Show("Could not write the temporary file: \n\n" + Directory.GetCurrentDirectory() + @"\data\temp\moving." + this.mainSettings.saveStructureIndex.item_file_ext, "Failed to deposit item!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
                    this.overwriteHexInBuffer("00000000", id - 8);
                    int index = 0;
                    while (true)
                    {
                        if (index < this.saveData.sharedInventory.itemsUsed)
                        {
                            if (this.saveData.sharedInventory.item[index].used)
                            {
                                index++;
                                continue;
                            }
                            id = this.saveData.sharedInventory.item[index].id;
                        }
                        if (this.loadFileIntoBuffer(id, "", partFileType.item, false, Directory.GetCurrentDirectory() + @"\data\temp\moving." + this.mainSettings.saveStructureIndex.item_file_ext) <= 0)
                        {
                            MessageBox.Show("There was an error moving the item. Please re-load your save file and try again.", "Item Move Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed--;
                        string hex = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X2");
                        this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.inventory_slots_used_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index));
                        this.reloadEverything();
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + @"\data\temp\moving." + this.mainSettings.saveStructureIndex.item_file_ext);
                        this.tabArea.SelectedIndex = 3;
                        this.selectItemAfterLoad = id;
                        this.displaySharedStorage(1);
                        return;
                    }
                }
            }
        }

        private void btnInventoryExportAll_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.inventory_file_name, " (*", this.mainSettings.saveStructureIndex.inventory_file_ext, ")|*", this.mainSettings.saveStructureIndex.inventory_file_ext };
            int startpos = this.mainSettings.saveStructureIndex.inventory_slots_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
            if (this.saveBufferDataToFile(startpos, 0x870, string.Concat(strArray), this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed, false, null, ""))
            {
                MessageBox.Show("The inventory file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnInventoryExportSelected_Click(object sender, EventArgs e)
        {
            int id = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id;
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.item_file_name, " (*", this.mainSettings.saveStructureIndex.item_file_ext, ")|*", this.mainSettings.saveStructureIndex.item_file_ext };
            if (!this.saveItemDataToFile(id, 20, string.Concat(strArray), this.inventoryView.SelectedItems[0].Text, "", this.chkDeleteExportInventory.Checked))
            {
                MessageBox.Show("The item file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (this.chkDeleteExportInventory.Checked)
                {
                    this.overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
                    this.overwriteHexInBuffer("00000000", id - 8);
                    this.reloadEverything();
                }
                MessageBox.Show("The item file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnInventoryImportAll_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.inventory_file_name, " (*", this.mainSettings.saveStructureIndex.inventory_file_ext, ")|*", this.mainSettings.saveStructureIndex.inventory_file_ext };
            int startpos = this.mainSettings.saveStructureIndex.inventory_slots_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
            if (this.loadFileIntoBuffer(startpos, string.Concat(strArray), partFileType.inventory, true, "") > 0)
            {
                this.reloadEverything();
                MessageBox.Show("The inventory file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnInventoryImportSelected_Click(object sender, EventArgs e)
        {
            if (this.inventoryView.SelectedItems.Count > 0)
            {
                int id = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id;
                string[] strArray = new string[] { this.mainSettings.saveStructureIndex.item_file_name, " (*", this.mainSettings.saveStructureIndex.item_file_ext, ")|*", this.mainSettings.saveStructureIndex.item_file_ext };
                if (this.loadFileIntoBuffer(id, string.Concat(strArray), partFileType.item, true, "") > 0)
                {
                    this.reloadEverything();
                    this.tabArea.SelectedIndex = 2;
                    this.displayInventory(this.lstSaveSlotView.SelectedItems[0].Index, 1);
                    MessageBox.Show("The item / items were imported successfully.\n\nIf an item was modified, the values may not match the game until the next time you save your progress.\n\nPlease remember that you should not used modified items online as you may get banned.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnModifyInfinityMission_Click(object sender, EventArgs e)
        {
            if (this.lstInfinityMissions.SelectedItems.Count <= 0)
            {
                MessageBox.Show("You must select a mission from your list to modify.", "Modify Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.infinityMissionForm.id = int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString());
                this.infinityMissionForm.ShowDialog(this);
            }
        }

        private void btnRaAbilitiesOpen_Click(object sender, EventArgs e)
        {
            this.action_launchTypeAbilitiesForm();
        }

        private void btnRebirth_Click(object sender, EventArgs e)
        {
            string hex = "";
            int level = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level;
            if (this.chkRebirthSpoof.Checked)
            {
                level = 200;
            }
            if (level >= 50)
            {
                if (this.comboRebirthExtend.SelectedIndex > 0)
                {
                    if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed >= 60)
                    {
                        MessageBox.Show("The characters inventory is full, please deposit an item before rebirthing so you can claim the extend codes", "Inventory Full", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    string str2 = this.comboRebirthExtend.SelectedIndex.ToString("X4");
                    while (true)
                    {
                        if (str2.Length >= 8)
                        {
                            str2 = this.run.hexAndMathFunction.reversehex(str2, 8);
                            str2 = "0F010000" + str2 + "630000000000000B00000000";
                            this.overwriteHexInBuffer(str2, ((this.mainSettings.saveStructureIndex.inventory_slots_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed * 0x24)) + 4);
                            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed++;
                            hex = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X1");
                            while (true)
                            {
                                if (hex.Length >= 2)
                                {
                                    this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.inventory_slots_used_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index));
                                    break;
                                }
                                hex = "0" + hex;
                            }
                            break;
                        }
                        str2 = "0" + str2;
                    }
                }
                if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.count < 0xffff)
                {
                    hex = (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.count + 1).ToString("X2");
                    while (true)
                    {
                        if (hex.Length >= 4)
                        {
                            hex = this.run.hexAndMathFunction.reversehex(hex, 4);
                            this.overwriteHexInBuffer(hex, (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0x1b6);
                            break;
                        }
                        hex = "0" + hex;
                    }
                }
                int num3 = this.getRebirthNowPointGain(level);
                if (this.comboRebirthExtend.SelectedIndex > 0)
                {
                    num3 -= 5 * this.comboRebirthExtend.SelectedIndex;
                }
                if (num3 > 0x3e7)
                {
                    num3 = 0x3e7;
                }
                hex = (num3 + this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points).ToString("X2");
                while (hex.Length < 4)
                {
                    hex = "0" + hex;
                }
                hex = this.run.hexAndMathFunction.reversehex(hex, 4);
                this.overwriteHexInBuffer(hex, (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 440);
                int num4 = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.additionalTypeLevels + this.getRebirthNowTypeLevelGain(level);
                if (num4 > 20)
                {
                    num4 = 20;
                }
                hex = num4.ToString("X1");
                while (hex.Length < 2)
                {
                    hex = "0" + hex;
                }
                this.overwriteHexInBuffer(hex, (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0x11b);
                if (!this.chkRebirthNoLevelDrop.Checked)
                {
                    this.writeNewLevelData(1);
                }
                this.reloadEverything();
                MessageBox.Show("The rebirth completed successfully.\n\nIf you selected to claim extend codes, they will be in the characters inventory.", "Rebirth Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.action_save();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            this.action_saveas();
        }

        private void btnStorageDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
            {
                int id = this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id;
                this.overwriteHexInBuffer("0000000000000000000000000000000000000000", id);
                this.reloadEverything();
            }
        }

        private void btnStorageExportAll_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.storage_file_name, " (*", this.mainSettings.saveStructureIndex.storage_file_ext, ")|*", this.mainSettings.saveStructureIndex.storage_file_ext };
            string str = string.Concat(strArray);
            if (this.saveBufferDataToFile(this.mainSettings.saveStructureIndex.shared_inventory_pos, this.mainSettings.saveStructureIndex.shared_inventory_slots * 20, str, 0, false, null, ""))
            {
                MessageBox.Show("The storage file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStorageExportSelected_Click(object sender, EventArgs e)
        {
            int id = this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id;
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.item_file_name, " (*", this.mainSettings.saveStructureIndex.item_file_ext, ")|*", this.mainSettings.saveStructureIndex.item_file_ext };
            if (!this.saveItemDataToFile(id, 20, string.Concat(strArray), this.storageView.SelectedItems[0].Text, "", this.chkDeleteExportStorage.Checked))
            {
                MessageBox.Show("The item file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (this.chkDeleteExportStorage.Checked)
                {
                    this.reloadEverything();
                }
                MessageBox.Show("The item file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStorageImportAll_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.storage_file_name, " (*", this.mainSettings.saveStructureIndex.storage_file_ext, ")|*", this.mainSettings.saveStructureIndex.storage_file_ext };
            string str = string.Concat(strArray);
            if (this.loadFileIntoBuffer(this.mainSettings.saveStructureIndex.shared_inventory_pos, str, partFileType.storage, false, "") > 0)
            {
                this.reloadEverything();
                MessageBox.Show("The storage file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStorageImportSelected_Click(object sender, EventArgs e)
        {
            int id = this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id;
            string[] strArray = new string[] { this.mainSettings.saveStructureIndex.item_file_name, " (*", this.mainSettings.saveStructureIndex.item_file_ext, ")|*", this.mainSettings.saveStructureIndex.item_file_ext };
            if (this.loadFileIntoBuffer(id, string.Concat(strArray), partFileType.item, false, "") > 0)
            {
                this.reloadEverything();
                this.tabArea.SelectedIndex = 3;
                this.selectItemAfterLoad = id;
                this.displaySharedStorage(1);
                MessageBox.Show("The item was imported successfully.\n\nIf the item was modified, the values may not match the game until the next time you save your progress.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStorageWithdraw_Click(object sender, EventArgs e)
        {
            if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed >= 60)
            {
                MessageBox.Show("The selected characters inventory is full", "Inventory Full", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int id = this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id;
                this.saveItemDataToFile(id, 20, "", "", Directory.GetCurrentDirectory() + @"\data\temp\moving." + this.mainSettings.saveStructureIndex.item_file_ext, true);
                for (int i = 0; (i < 60) && this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[i].used; i++)
                {
                }
                id = this.getFreeInventoryItemId(this.lstSaveSlotView.SelectedItems[0].Index);
                if (this.loadFileIntoBuffer(id, "", partFileType.item, true, Directory.GetCurrentDirectory() + @"\data\temp\moving." + this.mainSettings.saveStructureIndex.item_file_ext) <= 0)
                {
                    MessageBox.Show("There was an error moving the item. Please re-load your save file and try again.", "Item Move Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.reloadEverything();
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + @"\data\temp\moving." + this.mainSettings.saveStructureIndex.item_file_ext);
                    this.tabArea.SelectedIndex = 2;
                    this.selectInventoryItemAfterLoad = id;
                    this.displayInventory(this.lstSaveSlotView.SelectedItems[0].Index, 1);
                }
            }
        }

        private void btnUndoAll_Click(object sender, EventArgs e)
        {
            this.loadSaveFile(false);
        }

        private void btnVaAbilitiesOpen_Click(object sender, EventArgs e)
        {
            this.action_launchTypeAbilitiesForm();
        }

        private void changeDiskLevel(TabPage page)
        {
            if (!this.legitVersion())
            {
                inventoryItemClass item = null;
                item = !ReferenceEquals(page, this.tabPageStorage) ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
                this.entryForm.oldVal = (item.pa_level + 1);
                this.entryForm.newVal = (item.pa_level + 1);
                this.entryForm.description = "PA disk level";
                this.entryForm.maxLen = 2;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != (item.pa_level + 1).ToString())
                    {
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
                            while (true)
                            {
                                if (hex.Length >= 2)
                                {
                                    hex = this.run.hexAndMathFunction.reversehex(hex, 2);
                                    this.overwriteHexInBuffer(hex, item.id + 0x10);
                                    item.pa_level = int.Parse(newVal) - 1;
                                    pageFields fields = this.getPageFields(page, false);
                                    this.displayItemInfo(fields, item);
                                    break;
                                }
                                hex = "0" + hex;
                            }
                        }
                    }
                }
            }
        }

        private void changeImageFloater(string hex)
        {
            string filename = this.findImageFloatInList(hex);
            if (!this.imageFloatImageIsOk)
            {
                this.closeImageFloater();
            }
            else
            {
                this.imageFloater.picBox.Image = new Bitmap(filename);
                this.openImageFloater();
            }
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

                default:
                    break;
            }
            this.btnInventoryDelete.Enabled = false;
            this.btnInventoryImportSelected.Enabled = false;
            this.btnInventoryExportSelected.Enabled = false;
            this.chkDeleteExportInventory.Enabled = false;
            this.btnInventoryDeposit.Enabled = false;
            this.displayInventory(this.lstSaveSlotView.SelectedItems[0].Index, page);
            Application.DoEvents();
            switch (page)
            {
                case 1:
                    this.openImageFloater();
                    return;

                case 2:
                    this.closeImageFloater();
                    return;

                case 3:
                    this.closeImageFloater();
                    return;

                case 4:
                    this.closeImageFloater();
                    return;

                case 5:
                    this.closeImageFloater();
                    return;

                case 6:
                    this.closeImageFloater();
                    return;
            }
        }

        private void changeItemATK(TabPage page)
        {
            if (!this.legitVersion())
            {
                inventoryItemClass class2 = null;
                class2 = !ReferenceEquals(page, this.tabPageStorage) ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
                this.entryForm.oldVal = class2.power_add.ToString();
                this.entryForm.newVal = class2.power_add.ToString();
                this.entryForm.description = "weapon power mod";
                this.entryForm.maxLen = 4;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != class2.power_add.ToString())
                    {
                        if (int.Parse(newVal) > 0x270f)
                        {
                            MessageBox.Show("You must enter a value lower or equal to 9999.");
                        }
                        else if (int.Parse(newVal) < 1)
                        {
                            MessageBox.Show("You must enter a value greater than 0.");
                        }
                        else
                        {
                            string hex = int.Parse(newVal).ToString("X2");
                            while (true)
                            {
                                if (hex.Length >= 4)
                                {
                                    hex = this.run.hexAndMathFunction.reversehex(hex, 4);
                                    string str3 = "";
                                    int num = 0;
                                    while (true)
                                    {
                                        if (num >= 20)
                                        {
                                            this.overwriteHexInBuffer(hex, class2.id + 12);
                                            string str4 = "";
                                            int num2 = 0;
                                            while (true)
                                            {
                                                if (num2 >= 20)
                                                {
                                                    class2.power_add = int.Parse(newVal);
                                                    this.showSelectedInventoryItem(page);
                                                    break;
                                                }
                                                str4 = str4 + this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[class2.id + num2], "hex");
                                                num2++;
                                            }
                                            break;
                                        }
                                        str3 = str3 + this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[class2.id + num], "hex");
                                        num++;
                                    }
                                    break;
                                }
                                hex = "0" + hex;
                            }
                        }
                    }
                }
            }
        }

        private void changeItemElement(TabPage page)
        {
            if (!this.legitVersion())
            {
                inventoryItemClass class2 = null;
                class2 = !ReferenceEquals(page, this.tabPageStorage) ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
                this.entryForm.oldVal = class2.element.ToString();
                this.entryForm.newVal = ((int) class2.element).ToString();
                this.entryForm.description = "element";
                this.entryForm.maxLen = 1;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != ((int) class2.element).ToString())
                    {
                        if (int.Parse(newVal) >= 7)
                        {
                            MessageBox.Show("You must enter a value lower than " + elementType.COUNT + ".");
                        }
                        else if (int.Parse(newVal) < 0)
                        {
                            MessageBox.Show("You must enter a value greater or equal to 0.");
                        }
                        else
                        {
                            string hex = int.Parse(newVal).ToString("X1");
                            while (true)
                            {
                                if (hex.Length >= 2)
                                {
                                    hex = this.run.hexAndMathFunction.reversehex(hex, 2);
                                    this.overwriteHexInBuffer(hex, class2.id + 0x10);
                                    class2.element = (elementType) int.Parse(newVal);
                                    pageFields fields = this.getPageFields(page, false);
                                    this.displayElementImage(fields, class2.element);
                                    break;
                                }
                                hex = "0" + hex;
                            }
                        }
                    }
                }
            }
        }

        private void changeItemPercentage(TabPage page)
        {
            if (!this.legitVersion())
            {
                inventoryItemClass class2 = null;
                class2 = !ReferenceEquals(page, this.tabPageStorage) ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
                this.entryForm.oldVal = class2.percent.ToString();
                this.entryForm.newVal = class2.percent.ToString();
                this.entryForm.description = "element percentage";
                this.entryForm.maxLen = 3;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != class2.percent.ToString())
                    {
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
                            string hex = int.Parse(newVal).ToString("X1");
                            while (true)
                            {
                                if (hex.Length >= 2)
                                {
                                    hex = this.run.hexAndMathFunction.reversehex(hex, 2);
                                    string str3 = "";
                                    int num = 0;
                                    while (true)
                                    {
                                        if (num >= 20)
                                        {
                                            this.overwriteHexInBuffer(hex, class2.id + 0x11);
                                            string str4 = "";
                                            int num2 = 0;
                                            while (true)
                                            {
                                                if (num2 >= 20)
                                                {
                                                    class2.percent = int.Parse(newVal);
                                                    if (!ReferenceEquals(page, this.tabPageStorage))
                                                    {
                                                        this.txtInventoryPercent.Text = class2.percent + "%";
                                                        break;
                                                    }
                                                    this.txtStoragePercent.Text = class2.percent + "%";
                                                    return;
                                                }
                                                str4 = str4 + this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[class2.id + num2], "hex");
                                                num2++;
                                            }
                                            break;
                                        }
                                        str3 = str3 + this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[class2.id + num], "hex");
                                        num++;
                                    }
                                    break;
                                }
                                hex = "0" + hex;
                            }
                        }
                    }
                }
            }
        }

        private void changeItemQty(TabPage page)
        {
            if (!this.legitVersion())
            {
                inventoryItemClass class2 = null;
                class2 = !ReferenceEquals(page, this.tabPageStorage) ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
                if (class2.qty == 0)
                {
                    this.changeDiskLevel(page);
                }
                else
                {
                    this.entryForm.oldVal = class2.qty.ToString();
                    this.entryForm.newVal = class2.qty.ToString();
                    this.entryForm.description = "item qty";
                    this.entryForm.maxLen = 3;
                    if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                    {
                        string newVal = this.entryForm.newVal;
                        if (newVal != class2.qty.ToString())
                        {
                            if (int.Parse(newVal) > class2.qty_max)
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
                                while (true)
                                {
                                    if (hex.Length >= 4)
                                    {
                                        hex = this.run.hexAndMathFunction.reversehex(hex, 4);
                                        this.overwriteHexInBuffer(hex, class2.id + 4);
                                        class2.qty = int.Parse(newVal);
                                        if (!ReferenceEquals(page, this.tabPageStorage))
                                        {
                                            this.txtInventoryQty.Text = class2.qty + "/" + class2.qty_max;
                                            break;
                                        }
                                        this.txtStorageQty.Text = class2.qty + "/" + class2.qty_max;
                                        return;
                                    }
                                    hex = "0" + hex;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void changeItemSpecial(TabPage page)
        {
            if (!this.legitVersion())
            {
                inventoryItemClass class2 = null;
                class2 = !ReferenceEquals(page, this.tabPageStorage) ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
                this.entryForm.newVal = ((int) class2.ability).ToString();
                if (class2.style == weaponStyleType.Tech)
                {
                    this.entryForm.description = "TEC ability";
                    this.entryForm.oldVal = (class2.ability + abilityType.Empow_none).ToString();
                }
                else
                {
                    this.entryForm.description = "ability";
                    this.entryForm.oldVal = class2.ability.ToString();
                }
                this.entryForm.maxLen = 1;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != ((int) class2.ability).ToString())
                    {
                        if ((int.Parse(newVal) >= 0x15) || ((class2.style == weaponStyleType.Tech) && (int.Parse(newVal) >= 8)))
                        {
                            MessageBox.Show(string.Concat(new object[] { "You must enter a value lower than ", 8, " for TEC weapons and ", (int) 10, " for all others." }));
                        }
                        else if (int.Parse(newVal) < 0)
                        {
                            MessageBox.Show("You must enter a value greater or equal to 0.");
                        }
                        else
                        {
                            string hex = int.Parse(newVal).ToString("X1");
                            while (true)
                            {
                                if (hex.Length >= 2)
                                {
                                    this.overwriteHexInBuffer(hex, class2.id + 8);
                                    class2.ability = (abilityType) int.Parse(newVal);
                                    this.getPageFields(page, false);
                                    this.showSelectedInventoryItem(page);
                                    break;
                                }
                                hex = "0" + hex;
                            }
                        }
                    }
                }
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
            switch (page)
            {
                case 1:
                    this.storageView.SmallImageList = this.weaponWithRankImageList;
                    break;

                case 2:
                    this.storageView.SmallImageList = this.armourImageList;
                    break;

                case 3:
                    this.storageView.SmallImageList = this.itemImageList;
                    break;

                case 4:
                    this.storageView.SmallImageList = this.clothesImageList;
                    break;

                case 5:
                    this.storageView.SmallImageList = this.decoImageList;
                    break;

                case 6:
                    this.storageView.SmallImageList = this.decoImageList;
                    break;

                default:
                    break;
            }
            switch (page)
            {
                case 1:
                    this.openImageFloater();
                    return;

                case 2:
                    this.closeImageFloater();
                    return;

                case 3:
                    this.closeImageFloater();
                    return;

                case 4:
                    this.closeImageFloater();
                    return;

                case 5:
                    this.closeImageFloater();
                    return;

                case 6:
                    this.closeImageFloater();
                    return;
            }
        }

        private void checkAppUpdate(bool download)
        {
            this.disableMainForm();
            string newVersion = "";
            string str2 = "latest_version.bin";
            if (this.legitVersion())
            {
                str2 = "latest_version_viewer.bin";
            }
            string url = "http://files-ds-scene.net/retrohead/pspo2se/releases/" + str2;
            if (!this.downloadFile(url, "data/temp/", "Update Check", ""))
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.enableMainForm();
            }
            else
            {
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                    using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, new FileStream("data/temp/" + str2, FileMode.Open, FileAccess.Read))))
                    {
                        string str5 = reader.ReadLine();
                        if (str5 != null)
                        {
                            newVersion = str5;
                        }
                        reader.Close();
                    }
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message, "checkAppUpdate failed to parse new info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.toolStripStatusLabel.Text = "Update Failed";
                    this.enableMainForm();
                    return;
                }
                if ("3.0 build 1008" == newVersion)
                {
                    if (!this.firstboot)
                    {
                        MessageBox.Show("The latest version (" + newVersion + ") is already installed.", "Application is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.enableMainForm();
                }
                else if (!download)
                {
                    MessageBox.Show("There is a new version of the application available.\r\nChoose update from the the file menu to install v" + newVersion, "New version available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    this.updateViewer.formSetup(newVersion);
                    DialogResult result = this.updateViewer.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                    {
                        this.enableMainForm();
                    }
                    else
                    {
                        switch (result)
                        {
                            case DialogResult.Yes:
                            {
                                string str6 = !this.legitVersion() ? "PSPo2 Save Editor" : "PSPo2 Save Viewer";
                                string[] strArray = new string[] { "http://files-ds-scene.net/retrohead/pspo2se/releases/", str6, " v", newVersion, ".zip" };
                                url = string.Concat(strArray);
                                if (!this.downloadFile(url, "data/temp/", str6 + " v" + newVersion + ".zip", str6 + " new.zip"))
                                {
                                    this.toolStripStatusLabel.Text = "Update Failed";
                                    this.enableMainForm();
                                    break;
                                }
                                ZipUtil.UnZipFiles("data/temp/" + str6 + " new.zip", "data/temp/", "", true);
                                System.IO.File.Delete("data/" + str2);
                                System.IO.File.Move("data/temp/" + str2, "data/" + str2);
                                System.IO.File.Delete("data/temp/" + str2);
                                Process.Start("pspo2se_updater.exe");
                                Environment.Exit(0);
                                return;
                            }
                            case DialogResult.No:
                                this.enableMainForm();
                                return;

                            default:
                                MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                this.enableMainForm();
                                return;
                        }
                    }
                }
            }
        }

        private void checkDatabaseUpdate(bool download)
        {
            this.disableMainForm();
            string url = "http://files-ds-scene.net/retrohead/pspo2se/releases/databases/version.bin";
            if (!this.downloadFile(url, "data/temp/", "Update Check", ""))
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.checkVersionTxt(download) && download)
            {
                this.action_loadDatabases();
            }
            this.enableMainForm();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.checkDatabaseUpdate(true);
        }

        private void checkForUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.checkImagesUpdate(true);
        }

        private void checkImagesUpdate(bool download)
        {
            this.disableMainForm();
            string progressTxt = "";
            string str2 = "image_pack_version.bin";
            string url = "http://files-ds-scene.net/retrohead/pspo2se/releases/" + str2;
            if (!this.downloadFile(url, "data/temp/", "Update Check", ""))
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Image Pack Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                    using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, new FileStream("data/temp/" + str2, FileMode.Open, FileAccess.Read))))
                    {
                        string str5 = reader.ReadLine();
                        if (str5 != null)
                        {
                            progressTxt = str5;
                        }
                        reader.Close();
                    }
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message, "checkImagesUpdate failed to parse new info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.toolStripStatusLabel.Text = "Update Failed";
                    this.enableMainForm();
                    return;
                }
                string str6 = "";
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                    using (StreamReader reader2 = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, new FileStream("data/" + str2, FileMode.Open, FileAccess.Read))))
                    {
                        string str8 = reader2.ReadLine();
                        if (str8 != null)
                        {
                            str6 = str8;
                        }
                        reader2.Close();
                    }
                }
                catch (Exception)
                {
                }
                if (str6 == progressTxt)
                {
                    if (!this.firstboot)
                    {
                        MessageBox.Show("The latest version of the image pack is already installed.", "Image pack is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.enableMainForm();
                }
                else if (!download)
                {
                    MessageBox.Show("There is a new version of the image pack available.\r\nChoose update from the the images menu to install the latest version", "New Image Pack Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    DialogResult result = MessageBox.Show("There is a new version of the image pack available.\r\nDo you wish to update now?", "New Image Pack Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Cancel)
                    {
                        this.enableMainForm();
                    }
                    else
                    {
                        switch (result)
                        {
                            case DialogResult.Yes:
                                url = "http://files-ds-scene.net/retrohead/pspo2se/releases/" + progressTxt;
                                if (!this.downloadFile(url, "data/temp/", progressTxt, ""))
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
                                MessageBox.Show("The image pack was updated successfully", "Image Pack Update Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;

                            case DialogResult.No:
                                this.enableMainForm();
                                return;

                            default:
                                MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                this.enableMainForm();
                                return;
                        }
                    }
                }
            }
        }

        private bool checkVersionTxt(bool download)
        {
            int index = 0;
            int num2 = 0;
            string url = "";
            this.toolStripStatusLabel.Text = "Checking Version";
            Application.DoEvents();
            updateCSVInfo[] infoArray = new updateCSVInfo[20];
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/temp/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    while (true)
                    {
                        string str3 = reader.ReadLine();
                        if (str3 != null)
                        {
                            char[] separator = new char[] { '|' };
                            string[] strArray = str3.Split(separator);
                            infoArray[index] = new updateCSVInfo();
                            infoArray[index].fn = strArray[0];
                            infoArray[index].ver = strArray[1];
                            index++;
                            if (index < 20)
                            {
                                continue;
                            }
                        }
                        reader.Close();
                        fs.Close();
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("checkVersionTxt failed to load new info:\r\n " + exception.Message);
                this.toolStripStatusLabel.Text = "Update Failed";
                return false;
            }
            Application.DoEvents();
            updateCSVInfo[] infoArray2 = new updateCSVInfo[20];
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader reader2 = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    while (true)
                    {
                        string str5 = reader2.ReadLine();
                        if (str5 != null)
                        {
                            char[] separator = new char[] { '|' };
                            string[] strArray2 = str5.Split(separator);
                            infoArray2[num2] = new updateCSVInfo();
                            infoArray2[num2].fn = strArray2[0];
                            infoArray2[num2].ver = strArray2[1];
                            num2++;
                            if (num2 < 20)
                            {
                                continue;
                            }
                        }
                        reader2.Close();
                        fs.Close();
                        break;
                    }
                }
            }
            catch (Exception exception2)
            {
                if (exception2.Message.Substring(0, 0x13) == "Could not find file")
                {
                    int num3 = 0;
                    while (true)
                    {
                        if (num3 >= 20)
                        {
                            num2 = index;
                            break;
                        }
                        infoArray2[num3] = new updateCSVInfo();
                        infoArray2[num3].ver = "0";
                        num3++;
                    }
                }
                else
                {
                    MessageBox.Show(string.Concat(new object[] { "checkVersionTxt failed to load cur info [", num2, "/", (int) 20, "]:\r\n ", exception2.Message }));
                    this.toolStripStatusLabel.Text = "Update Failed";
                    return false;
                }
            }
            Application.DoEvents();
            if (index > num2)
            {
                MessageBox.Show("The application seems to be out of date.\r\nThe latest database files are incompatible with this version\r\n\r\nPlease update the application first");
                this.toolStripStatusLabel.Text = "Update Failed";
                return false;
            }
            string text = "";
            bool flag = false;
            bool flag2 = false;
            for (int i = 0; (i < 20) && (i < index); i++)
            {
                if (infoArray2[i].ver == infoArray[i].ver)
                {
                    string[] strArray4 = new string[] { text, infoArray[i].fn, " [", infoArray[i].ver, " Already Installed]\r\n" };
                    text = string.Concat(strArray4);
                }
                else
                {
                    if (!flag2)
                    {
                        if (!download)
                        {
                            MessageBox.Show("There are new database updates available.\r\nChoose update from the database menu to install them", "Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                        DialogResult result = MessageBox.Show("There are new database updates available.\r\nDo you wish to download them now?", "Updates Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Cancel)
                        {
                            return false;
                        }
                        switch (result)
                        {
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
                    url = "http://files-ds-scene.net/retrohead/pspo2se/releases/databases/" + infoArray[i].fn;
                    if (!this.downloadFile(url, "data/databases/", infoArray[i].fn, ""))
                    {
                        this.toolStripStatusLabel.Text = "Update Failed";
                        return false;
                    }
                    string[] strArray3 = new string[] { text, infoArray[i].fn, " [Updated to ", infoArray[i].ver, "]\r\n" };
                    text = string.Concat(strArray3);
                    flag = true;
                }
            }
            if (flag)
            {
                System.IO.File.Delete("data/databases/version.bin");
                System.IO.File.Move("data/temp/version.bin", "data/databases/version.bin");
            }
            if (download)
            {
                this.toolStripStatusLabel.Text = "Update Complete";
                MessageBox.Show(text, "Database Update Results", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return true;
        }

        private void chkRebirthSpoof_CheckedChanged(object sender, EventArgs e)
        {
            this.listRebirthRewards(this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level, this.lstSaveSlotView.SelectedItems[0].Index);
        }

        private void classLevel_Click(object sender, EventArgs e)
        {
            this.jumpToTypeLevel();
        }

        private void closeImageFloater()
        {
            if (this.imageFloaterOpen())
            {
                this.moveImageFloater();
            }
        }

        private bool decryptSaveFile(string file)
        {
            ProcessStartInfo info = new ProcessStartInfo {
                FileName = "SED.exe"
            };
            if (!System.IO.File.Exists(info.FileName))
            {
                MessageBox.Show("SED.exe is missing");
                return false;
            }
            string str = this.getGameIdFromSfo(file);
            if (!System.IO.File.Exists(@"data\keys\" + str + ".bin"))
            {
                if (MessageBox.Show("You must place the '" + str + ".bin' key file in the data\\keys directory.\n\nDo you want to generate it now?", "Generate Key", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return false;
                }
                try
                {
                    using (FileStream stream = new FileStream(@"data\keys\" + str + ".bin", FileMode.Create))
                    {
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {
                            int num = 0;
                            while (true)
                            {
                                if (num >= 0x10)
                                {
                                    writer.Close();
                                    break;
                                }
                                writer.Write((byte) (0x80 + num));
                                num++;
                            }
                        }
                        stream.Close();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to generate the key.\n\nError: " + exception.Message);
                    return false;
                }
            }
            string[] strArray = new string[] { "-d \"", file, "\" data\\temp\\denc.bin data\\keys\\", str, ".bin" };
            info.Arguments = string.Concat(strArray);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process {
                StartInfo = info
            };
            process.Start();
            process.WaitForExit();
            return true;
        }

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

        private void displayCharacterInfo(int slotnum)
        {
            this.txtSlotnumloaded.Text = (this.saveData.slot[slotnum].name == "") ? "No Save Slot Loaded" : ("Save Slot #" + (slotnum + 1) + " Loaded");
            this.txtCharacterName.Text = this.saveData.slot[slotnum].name;
            this.txtTitle.Text = this.saveData.slot[slotnum].title;
            this.txtPlaytime.Text = this.saveData.slot[slotnum].playtime;
            this.txtCurType.Text = this.saveData.slot[slotnum].cur_type;
            this.txtRace.Text = this.saveData.slot[slotnum].race;
            this.txtSex.Text = this.saveData.slot[slotnum].sex;
            this.txtLevel.Text = this.saveData.slot[slotnum].level;
            this.txtExp.Text = this.saveData.slot[slotnum].exp;
            this.txtExpNext.Text = this.saveData.slot[slotnum].exp_next;
            this.txtLevelExpBar.Width = this.saveData.slot[slotnum].exp_percent * 2;
            this.txtInventoryMeseta.Text = this.saveData.slot[slotnum].meseta;
            this.txtStoryComplete.Text = this.storyCompleteToText(this.saveData.slot[slotnum].story_ep_1_complete, this.saveData.slot[slotnum].story_ep_2_complete);
            this.txtStoryComplete.Visible = true;
            this.txtSkipEp1Start.Text = "No";
            if (this.saveData.slot[slotnum].skip_ep_1_start)
            {
                this.txtSkipEp1Start.Text = "Yes";
            }
            if (this.saveData.type == SaveType.PSP2I)
            {
                this.txtSkipEp2Start.Text = "No";
                if (this.saveData.slot[slotnum].skip_ep_2_start)
                {
                    this.txtSkipEp2Start.Text = "Yes";
                }
            }
            this.txtMissionEp1.Text = "No";
            this.txtMissionTactical.Text = "No";
            this.txtMissionEp2.Text = "No";
            this.txtMissionMagashi.Text = "No";
            this.txtEp1Complete.Text = "No";
            this.txtEp2Complete.Text = "No";
            this.txtAllowQuitMission.Text = "No";
            if (this.saveData.slot[slotnum].mission_unlock_ep1)
            {
                this.txtMissionEp1.Text = "Yes";
            }
            if (this.saveData.slot[slotnum].mission_unlock_unknown)
            {
                this.txtMissionTactical.Text = "Yes";
            }
            if (this.saveData.slot[slotnum].mission_unlock_ep2)
            {
                this.txtMissionEp2.Text = "Yes";
            }
            if (this.saveData.slot[slotnum].mission_unlock_magashi)
            {
                this.txtMissionMagashi.Text = "Yes";
            }
            if (this.saveData.slot[slotnum].story_ep_1_complete)
            {
                this.txtEp1Complete.Text = "Yes";
            }
            if (this.saveData.slot[slotnum].story_ep_2_complete)
            {
                this.txtEp2Complete.Text = "Yes";
            }
            if (this.saveData.slot[slotnum].allow_quit_missions == "FF")
            {
                this.txtAllowQuitMission.Text = "Yes";
            }
            this.txtStoryEmiliaPoints.Visible = true;
            if (this.saveData.slot[slotnum].story_ep_1_points != null)
            {
                this.txtStoryEmiliaPoints.Text = this.run.hexAndMathFunction.hexToInt(this.saveData.slot[slotnum].story_ep_1_points) + " Emilia Points";
            }
            if (this.saveData.slot[slotnum].story_ep_2_points == null)
            {
                this.txtStoryNagisaPoints.Visible = false;
            }
            else
            {
                this.txtStoryNagisaPoints.Text = this.run.hexAndMathFunction.hexToInt(this.saveData.slot[slotnum].story_ep_2_points) + " Nagisa Points";
                this.txtStoryNagisaPoints.Visible = true;
            }
        }

        private void displayClothesImage(pageFields fields, itemType item_type, int clothes_type)
        {
            fields.img_item.Visible = true;
            if (item_type != itemType.Clothes_human)
            {
                if (item_type != itemType.Clothes_android)
                {
                    MessageBox.Show("Tried to get clothes type from a non-clothing item: " + clothes_type);
                }
                else
                {
                    partsTypes types2 = (partsTypes) clothes_type;
                    switch (types2)
                    {
                        case partsTypes.torso:
                            fields.img_item.Image = Resources.parts_torso;
                            return;

                        case partsTypes.legs:
                            fields.img_item.Image = Resources.parts_legs;
                            return;

                        case partsTypes.arms:
                            fields.img_item.Image = Resources.parts_arms;
                            return;

                        case partsTypes.set:
                            fields.img_item.Image = Resources.parts_set;
                            return;
                    }
                    MessageBox.Show(string.Concat(new object[] { "Unsupported ", item_type, " type: ", types2 }));
                    fields.img_item.Visible = false;
                }
            }
            else
            {
                clothesTypes types = (clothesTypes) clothes_type;
                switch (types)
                {
                    case clothesTypes.top:
                        fields.img_item.Image = Resources.clothes_top;
                        return;

                    case clothesTypes.bottom:
                        fields.img_item.Image = Resources.clothes_bottom;
                        return;

                    case clothesTypes.shoes:
                        fields.img_item.Image = Resources.clothes_shoes;
                        return;

                    case clothesTypes.top_set:
                        fields.img_item.Image = Resources.clothes_bottom_set;
                        return;

                    case clothesTypes.bottom_set:
                        fields.img_item.Image = Resources.clothes_top_set;
                        return;

                    case clothesTypes.set:
                        fields.img_item.Image = Resources.clothes_set;
                        return;
                }
                MessageBox.Show(string.Concat(new object[] { "Unsupported ", item_type, " type: ", types }));
                fields.img_item.Visible = false;
            }
        }

        private void displayClothesManufacturerImage(pageFields fields, clothesManufacturerType manufacturer)
        {
            fields.img_manufaturer.Visible = true;
            switch (manufacturer)
            {
                case clothesManufacturerType.Kubara:
                    fields.img_manufaturer.Image = Resources.manlogo_Kubara;
                    return;

                case clothesManufacturerType.Roar:
                    fields.img_manufaturer.Image = Resources.manlogo_Roar;
                    return;

                case clothesManufacturerType.Cubic:
                    fields.img_manufaturer.Image = Resources.manlogo_Cubic;
                    return;

                case clothesManufacturerType.Miyab:
                    fields.img_manufaturer.Image = Resources.manlogo_Miyab;
                    return;
            }
            MessageBox.Show("clothes manufacturer not supported: " + manufacturer);
            fields.img_manufaturer.Visible = false;
        }

        public void displayElementImage(pageFields fields, elementType element)
        {
            fields.img_element.Visible = true;
            switch (element)
            {
                case elementType.Neutral:
                    fields.img_element.Image = Resources.element_neutral;
                    return;

                case elementType.Fire:
                    fields.img_element.Image = Resources.element_fire;
                    return;

                case elementType.Ice:
                    fields.img_element.Image = Resources.element_ice;
                    return;

                case elementType.Thunder:
                    fields.img_element.Image = Resources.element_thunder;
                    return;

                case elementType.Earth:
                    fields.img_element.Image = Resources.element_earth;
                    return;

                case elementType.Light:
                    fields.img_element.Image = Resources.element_light;
                    return;

                case elementType.Dark:
                    fields.img_element.Image = Resources.element_dark;
                    return;
            }
            fields.img_element.Visible = false;
        }

        private void displayInfinityMissions()
        {
            this.lstInfinityMissions.Items.Clear();
            this.txtInfinityMissionQty.Text = this.saveData.infinityMissions.itemsUsed + "/100";
            for (int i = 0; i < this.saveData.infinityMissions.itemsUsed; i++)
            {
                ListViewItem item = new ListViewItem {
                    Text = this.intToInfinityBoss(this.saveData.infinityMissions.slot[i].boss - 1)[1] + " @ " + this.intToInfinityArea(this.saveData.infinityMissions.slot[i].area - 1)[1]
                };
                string text = item.Text;
                string[] strArray = new string[] { text, " (", this.intToInfinityArea(this.saveData.infinityMissions.slot[i].area - 1)[0], "の", this.intToInfinityBoss(this.saveData.infinityMissions.slot[i].boss - 1)[0], ")" };
                item.Text = string.Concat(strArray);
                item.Tag = this.saveData.infinityMissions.slot[i].id;
                item.SubItems.Add("LV" + this.saveData.infinityMissions.slot[i].level);
                this.lstInfinityMissions.Items.Add(item);
            }
        }

        private void displayInventory(int slotnum, int page)
        {
            this.inventoryView.SelectedItems.Clear();
            this.inventoryView.Items.Clear();
            this.sortInventory(slotnum);
            this.picWeaponSlot01.Image = null;
            this.picWeaponSlot02.Image = null;
            this.picWeaponSlot03.Image = null;
            this.picWeaponSlot04.Image = null;
            this.picWeaponSlot05.Image = null;
            this.picWeaponSlot06.Image = null;
            int num = -1;
            for (int i = 0; i < 60; i++)
            {
                inventoryItemClass class2 = new inventoryItemClass();
                class2 = this.saveData.slot[slotnum].inventory.item[i];
                if ((class2.type == itemType.Weapon) && (class2.equipped_slot > 0))
                {
                    int num3 = (int) ((this.getWeaponTypeFromHex(class2.hex_reversed) - 1) + ((weaponType) ((int) (class2.element * ((elementType) 0x1c)))));
                    switch (class2.equipped_slot)
                    {
                        case 1:
                            this.picWeaponSlot01.Image = this.imageListWeaponElements.Images[num3];
                            break;

                        case 2:
                            this.picWeaponSlot02.Image = this.imageListWeaponElements.Images[num3];
                            break;

                        case 3:
                            this.picWeaponSlot03.Image = this.imageListWeaponElements.Images[num3];
                            break;

                        case 4:
                            this.picWeaponSlot04.Image = this.imageListWeaponElements.Images[num3];
                            break;

                        case 5:
                            this.picWeaponSlot05.Image = this.imageListWeaponElements.Images[num3];
                            break;

                        case 6:
                            this.picWeaponSlot06.Image = this.imageListWeaponElements.Images[num3];
                            break;

                        default:
                            break;
                    }
                }
                if (this.allowShowItem(page, class2))
                {
                    string str = "";
                    if (class2.used)
                    {
                        str = ((class2.name != "") || (class2.name_jp == "")) ? ((class2.name != "") ? (class2.name + " (" + class2.name_jp + ")") : ("Unk_" + class2.hex)) : class2.name_jp;
                    }
                    else
                    {
                        str = "---- Free Slot ----";
                        class2.rarity = -1;
                    }
                    ListViewItem item = new ListViewItem {
                        Text = str,
                        ImageIndex = this.getImageListNumber(class2),
                        SubItems = { i }
                    };
                    this.inventoryView.Items.Add(item);
                    if ((this.selectInventoryItemAfterLoad != -1) && (class2.id == this.selectInventoryItemAfterLoad))
                    {
                        num = this.inventoryView.Items.Count - 1;
                    }
                }
            }
            this.tabPageInventory.Text = "Inventory (" + this.saveData.slot[slotnum].inventory.itemsUsed + "/60)";
            if (num != -1)
            {
                this.inventoryView.Items[num].Selected = true;
                this.inventoryView.Items[num].EnsureVisible();
                this.selectInventoryItemAfterLoad = -1;
            }
            else if (this.selectInventoryItemAfterLoad != -1)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (this.saveData.slot[slotnum].inventory.item[j].id == this.selectInventoryItemAfterLoad)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (this.allowShowItem(k + 1, this.saveData.slot[slotnum].inventory.item[j]))
                            {
                                this.tabArea.SelectedIndex = 2;
                                this.inventoryViewPages.SelectedIndex = k;
                                return;
                            }
                        }
                        return;
                    }
                }
            }
        }

        public void displayItemImage(pageFields fields, inventoryItemClass item)
        {
            fields.img_item.Visible = true;
            fields.img_manufaturer.Visible = false;
            fields.img_item.Padding = new Padding(0, 0, 0, 0);
            fields.txt_name.Padding = new Padding(0, 0, 0, 0);
            switch (item.type)
            {
                case itemType.Weapon:
                    this.displayWeaponImage(fields, this.getWeaponTypeFromHex(item.hex_reversed));
                    this.displayWeaponManufacturerImage(fields, this.getWeaponManufacturerFromHex(item.hex_reversed));
                    return;

                case itemType.Armor:
                    this.displayWeaponImage(fields, weaponType.armor);
                    this.displayWeaponManufacturerImage(fields, this.getWeaponManufacturerFromHex(item.hex_reversed));
                    return;

                case itemType.Green_Item:
                    switch (this.getGreenItemTypeFromHex(item.hex_reversed))
                    {
                        case greenItemType.monomate:
                            fields.img_item.Image = Resources.item_mate;
                            return;

                        case greenItemType.dimate:
                            fields.img_item.Image = Resources.item_mate;
                            return;

                        case greenItemType.trimate:
                            fields.img_item.Image = Resources.item_mate;
                            return;

                        case greenItemType.star_atom:
                            fields.img_item.Image = Resources.item_mate;
                            return;

                        case greenItemType.sol_atom:
                            fields.img_item.Image = Resources.item_sol;
                            return;

                        case greenItemType.moon_atom:
                            fields.img_item.Image = Resources.item_doll;
                            return;

                        case greenItemType.doll:
                            fields.img_item.Image = Resources.item_doll;
                            return;

                        case greenItemType.shiftaride:
                            fields.img_item.Image = Resources.item_buff;
                            return;

                        case greenItemType.debanride:
                            fields.img_item.Image = Resources.item_buff;
                            return;

                        case greenItemType.calorie:
                            fields.img_item.Image = Resources.item_calorie;
                            return;

                        case greenItemType.item:
                            fields.img_item.Image = Resources.item;
                            return;
                    }
                    MessageBox.Show("Green item type not recognised for image: " + this.getGreenItemTypeFromHex(item.hex_reversed));
                    return;

                case itemType.PA_Disk_Melee:
                    fields.img_item.Image = Resources.item_pa_disk;
                    return;

                case itemType.PA_Disk_Ranged:
                    fields.img_item.Image = Resources.item_pa_disk;
                    return;

                case itemType.PA_Disk_Technique:
                    fields.img_item.Image = Resources.item_pa_disk;
                    return;

                case itemType.Infinity_Code:
                    fields.img_item.Image = Resources.item;
                    return;

                case itemType.Slot_Unit:
                    this.displaySlotUnitImage(fields, this.getSlotTypeFromHex(item.hex_reversed));
                    this.displayWeaponManufacturerImage(fields, this.getWeaponManufacturerFromHex(item.hex_reversed));
                    return;

                case itemType.Clothes_human:
                    this.displayClothesImage(fields, itemType.Clothes_human, this.getClothesTypeFromHex(item.hex_reversed));
                    this.displayClothesManufacturerImage(fields, item.clothes_man);
                    return;

                case itemType.Clothes_android:
                    this.displayClothesImage(fields, itemType.Clothes_android, this.getClothesTypeFromHex(item.hex_reversed));
                    this.displayClothesManufacturerImage(fields, item.clothes_man);
                    return;

                case itemType.Room_Decoration:
                    fields.img_item.Image = Resources.item_decoration;
                    return;

                case itemType.Trap:
                {
                    string str = item.hex_reversed.Substring(5, 1);
                    if (str != null)
                    {
                        if (str == "1")
                        {
                            fields.img_item.Image = Resources.trap;
                            return;
                        }
                        if (str == "2")
                        {
                            fields.img_item.Image = Resources.trap_ex;
                            return;
                        }
                    }
                    MessageBox.Show("Trap type is wrong for image, is this even a trap?");
                    return;
                }
                case itemType.My_Synth_Device:
                    fields.img_item.Image = Resources.item_pm;
                    return;

                case itemType.Extend_Code:
                    fields.img_item.Image = Resources.item_extend;
                    return;

                case itemType.free_slot:
                    break;

                default:
                    MessageBox.Show("item type not recognised for image: " + item.type);
                    fields.img_item.Visible = false;
                    break;
            }
        }

        public void displayItemInfo(pageFields fields, inventoryItemClass item)
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
            string str = item.infinity_item;
            if (str != null)
            {
                if (str == "0")
                {
                    fields.img_infinity_item.Visible = false;
                    fields.txt_infinity_item.Visible = false;
                }
                else if (str == "1")
                {
                    fields.img_infinity_item.Visible = true;
                    fields.txt_infinity_item.Visible = false;
                }
                else if (str == "?")
                {
                    fields.img_infinity_item.Visible = false;
                    fields.txt_infinity_item.Visible = true;
                }
            }
            fields.txt_level.Text = item.level;
            fields.txt_acc.Padding = new Padding(0, 0, 0, 0);
            fields.txt_special.Padding = new Padding(0, 0, 0, 0);
            fields.txt_effect.Padding = new Padding(0, 0, 0, 0);
            fields.txt_grinds.Size = new Size(210, 0x12);
            fields.txt_grinds.Location = new Point(0x51, 0x30);
            switch (item.type)
            {
                case itemType.Weapon:
                    fields.img_item.Visible = true;
                    fields.img_rank.Visible = true;
                    fields.txt_special.Visible = true;
                    if (item.hand == weaponHandType.both)
                    {
                        fields.txt_name.Padding = new Padding(0x1a, 0, 0, 0);
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
                    fields.txt_percent.Text = item.percent + "%";
                    fields.txt_grinds.Text = "(" + item.grinds + ")";
                    fields.txt_effect.Text = "Effect  None (なし)";
                    fields.txt_special.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_effect.Padding = new Padding(0, 0, 0, 0);
                    fields.txt_acc.Padding = new Padding(0, 0, 0, 0);
                    if (item.spcl_effect != "")
                    {
                        if (item.spcl_effect_info == "0000")
                        {
                            fields.txt_effect.Text = (item.spcl_effect != "Unseals") ? ("Effect  " + item.spcl_effect) : ("Effect  " + item.spcl_effect + " (Kills  0)");
                        }
                        else if ((item.spcl_effect != "Unseals") && (item.spcl_effect != "Unsealed"))
                        {
                            string[] strArray = new string[] { "Effect  ", item.spcl_effect, " (", item.spcl_effect_info, ")" };
                            fields.txt_effect.Text = string.Concat(strArray);
                        }
                        else
                        {
                            int num = int.Parse(this.run.hexAndMathFunction.reversehex(item.spcl_effect_info, 4), NumberStyles.HexNumber);
                            if (num > 0x7d0)
                            {
                                item.spcl_effect = "Unsealed";
                            }
                            object[] objArray = new object[] { "Effect  ", item.spcl_effect, " (Kills  ", num, ")" };
                            fields.txt_effect.Text = string.Concat(objArray);
                        }
                    }
                    this.displayWeaponExtendInfo(fields, item);
                    break;

                case itemType.Armor:
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
                    fields.txt_special.Text = "DEF  " + item.power;
                    fields.txt_effect.Text = "EVA  " + item.acc;
                    fields.txt_atk.Text = "MND  " + item.ext_power;
                    fields.txt_acc.Text = "STA  " + item.ext_acc;
                    fields.txt_special.Padding = new Padding(0x10, 0, 0, 0);
                    fields.txt_effect.Padding = new Padding(12, 0, 0, 0);
                    fields.txt_acc.Padding = new Padding(6, 0, 0, 0);
                    fields.txt_grinds.Text = (item.ext_level == "") ? "no slots" : (item.ext_level + " slots");
                    fields.txt_percent.Text = item.percent + "%";
                    break;

                case itemType.Green_Item:
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
                    fields.txt_qty.Text = item.qty + "/" + item.qty_max;
                    fields.txt_grinds.Text = "(" + item.grinds + ")";
                    break;

                case itemType.Infinity_Code:
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
                    fields.txt_special.Padding = new Padding(0x36, 0, 0, 0);
                    fields.txt_effect.Padding = new Padding(0x33, 0, 0, 0);
                    fields.txt_qty.Text = item.desc + " (" + item.desc_jp + ")";
                    fields.txt_special.Text = "Area  " + item.ext_level;
                    fields.txt_effect.Text = "Boss  " + item.level;
                    fields.txt_grinds.Text = "(+" + item.percent + ")";
                    if (item.special == this.elementToSubEnemyType(item.element))
                    {
                        fields.txt_atk.Text = "Main Enemy  " + this.elementToSubEnemyType(elementType.Neutral);
                        fields.txt_acc.Text = "Sub Enemy  " + this.elementToSubEnemyType(elementType.Fire);
                    }
                    else
                    {
                        fields.txt_atk.Text = "Main Enemy  " + item.special;
                        fields.txt_acc.Text = "Sub Enemy  " + this.elementToSubEnemyType(item.element);
                    }
                    fields.txt_grinds.Size = new Size(50, 0x12);
                    fields.txt_grinds.Location = new Point(0xf1, 0x30);
                    break;

                case itemType.Slot_Unit:
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

                case itemType.Clothes_human:
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

                case itemType.Clothes_android:
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

                case itemType.Room_Decoration:
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

                case itemType.Trap:
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
                    fields.txt_qty.Text = item.qty + "/" + item.qty_max;
                    break;

                case itemType.My_Synth_Device:
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

                case itemType.Extend_Code:
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
                    fields.txt_qty.Text = item.qty + "/" + item.qty_max;
                    break;

                case itemType.free_slot:
                    if (fields.grp_details != null)
                    {
                        fields.grp_details.Visible = false;
                    }
                    if (fields.pnl_details != null)
                    {
                        fields.pnl_details.Visible = false;
                    }
                    fields.txt_qty.Visible = false;
                    fields.txt_atk.Visible = false;
                    fields.txt_acc.Visible = false;
                    fields.txt_percent.Visible = false;
                    fields.txt_grinds.Visible = false;
                    fields.txt_special.Visible = false;
                    fields.txt_effect.Visible = false;
                    fields.txt_level.Text = "";
                    fields.img_element.Visible = false;
                    fields.img_rank.Image = Resources.free_slot;
                    fields.img_item.Visible = false;
                    fields.txt_name_jp.Text = "";
                    break;

                default:
                    if ((item.type != itemType.PA_Disk_Melee) && ((item.type != itemType.PA_Disk_Ranged) && (item.type != itemType.PA_Disk_Technique)))
                    {
                        fields.img_item.Visible = true;
                        fields.img_rank.Visible = true;
                        fields.txt_name.Padding = new Padding(0x1a, 0, 0, 0);
                        fields.img_item.Padding = new Padding(13, 0, 0, 0);
                        fields.txt_qty.Visible = true;
                        this.displayElementImage(fields, item.element);
                        fields.txt_percent.Visible = true;
                        fields.txt_grinds.Visible = true;
                        fields.txt_special.Visible = true;
                        fields.txt_effect.Visible = true;
                        fields.txt_atk.Visible = true;
                        fields.txt_acc.Visible = true;
                        MessageBox.Show("Type not dealt with in displayItemInfo() " + this.txtInventoryHex.Text);
                        fields.txt_qty.Text = item.qty + "/" + item.qty_max;
                    }
                    else
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
                        object[] objArray2 = new object[] { "LV", item.pa_level + 1, " (", this.getSlotPALearntLevel(this.lstSaveSlotView.SelectedItems[0].Index, item.hex), ")" };
                        fields.txt_qty.Text = string.Concat(objArray2);
                    }
                    break;
            }
            Application.DoEvents();
            if (fields.grp_details != null)
            {
                fields.grp_details.ResumeLayout();
                fields.grp_details.Visible = true;
            }
            if (fields.pnl_details != null)
            {
                fields.pnl_details.ResumeLayout();
                fields.pnl_details.Visible = true;
            }
        }

        public void displayItemStars(pageFields fields, int rarity)
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
            fields.img_rank.Image = Resources.rank_Unknown;
            if (rarity >= 0)
            {
                fields.img_star_0.Visible = true;
                fields.img_rank.Image = Resources.rank_C;
            }
            if (rarity > 0)
            {
                fields.img_star_1.Visible = true;
            }
            if (rarity >= 2)
            {
                fields.img_star_2.Visible = true;
            }
            if (rarity >= 3)
            {
                fields.img_star_3.Visible = true;
                fields.img_rank.Image = Resources.rank_B;
            }
            if (rarity >= 4)
            {
                fields.img_star_4.Visible = true;
            }
            if (rarity >= 5)
            {
                fields.img_star_5.Visible = true;
            }
            if (rarity >= 6)
            {
                fields.img_star_6.Visible = true;
                fields.img_rank.Image = Resources.rank_A;
            }
            if (rarity >= 7)
            {
                fields.img_star_7.Visible = true;
            }
            if (rarity >= 8)
            {
                fields.img_star_8.Visible = true;
            }
            if (rarity >= 9)
            {
                fields.img_star_9.Visible = true;
                fields.img_rank.Image = Resources.rank_S;
            }
            if (rarity >= 10)
            {
                fields.img_star_10.Visible = true;
            }
            if (rarity >= 11)
            {
                fields.img_star_11.Visible = true;
            }
            if (rarity >= 12)
            {
                fields.img_star_12.Visible = true;
            }
            if (rarity >= 13)
            {
                fields.img_star_13.Visible = true;
            }
            if (rarity >= 14)
            {
                fields.img_star_14.Visible = true;
            }
            if (rarity >= 15)
            {
                fields.img_star_15.Visible = true;
            }
        }

        private void displayPAList(int slot)
        {
            this.lstPAMelee.Items.Clear();
            this.lstPABullets.Items.Clear();
            this.lstPATechs.Items.Clear();
            ArrayList list = ArrayList.Adapter(this.saveData.slot[slot].pa.items);
            list.Sort();
            this.saveData.slot[slot].pa.items = (inventoryItemClass[]) list.ToArray(typeof(inventoryItemClass));
            for (int i = 0; i < 0x100; i++)
            {
                if (this.saveData.slot[slot].pa.items[i].hex != "")
                {
                    ListViewItem item = new ListViewItem {
                        ImageIndex = int.Parse(this.saveData.slot[slot].pa.items[i].hex.Substring(2, 2), NumberStyles.HexNumber) - 1
                    };
                    if (this.saveData.slot[slot].pa.items[i].hex.Substring(0, 2) == "06")
                    {
                        item.ImageIndex += 0x1c;
                    }
                    itemDb_ItemClass class2 = new itemDb_ItemClass();
                    string hex = this.saveData.slot[slot].pa.items[i].hex_reversed;
                    if (this.saveData.slot[slot].pa.items[i].hex.Substring(0, 2) == "05")
                    {
                        hex = (int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber) - 13).ToString("X1");
                        while (true)
                        {
                            if (hex.Length >= 2)
                            {
                                string str2 = (int.Parse(this.saveData.slot[slot].pa.items[i].hex_reversed.Substring(2, 2), NumberStyles.HexNumber) - 1).ToString("X1");
                                while (true)
                                {
                                    if (str2.Length >= 2)
                                    {
                                        hex = this.saveData.slot[slot].pa.items[i].hex_reversed.Substring(0, 2) + str2 + hex + this.saveData.slot[slot].pa.items[i].hex_reversed.Substring(6, 2);
                                        break;
                                    }
                                    str2 = "0" + str2;
                                }
                                break;
                            }
                            hex = "0" + hex;
                        }
                    }
                    class2 = this.findItemInDb(hex);
                    item.Text = class2.name;
                    if (class2.name == "")
                    {
                        item.Text = class2.name_jp;
                    }
                    item.SubItems.Add(this.saveData.slot[slot].pa.items[i].level);
                    item.Tag = i.ToString();
                    if (this.saveData.slot[slot].pa.items[i].hex.Substring(0, 2) == "04")
                    {
                        this.lstPAMelee.Items.Add(item);
                    }
                    if (this.saveData.slot[slot].pa.items[i].hex.Substring(0, 2) == "05")
                    {
                        this.lstPABullets.Items.Add(item);
                    }
                    if (this.saveData.slot[slot].pa.items[i].hex.Substring(0, 2) == "06")
                    {
                        this.lstPATechs.Items.Add(item);
                    }
                }
            }
        }

        private void displayRebirthInfo(int slot)
        {
            if (this.saveData.type != SaveType.PSP2I)
            {
                this.grpRebirth.Visible = false;
            }
            else
            {
                this.grpRebirth.Visible = true;
                this.txtRebirthCount.Text = this.saveData.slot[slot].rebirth.count.ToString();
                object[] objArray = new object[] { "BP ", this.saveData.slot[slot].rebirth.remaining_points.ToString(), "/", ((((((((this.saveData.slot[slot].rebirth.remaining_points + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.hp, "HP")) + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.pp, "PP")) + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.atk, "ATK")) + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.def, "DEF")) + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.acc, "ACC")) + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.eva, "EVA")) + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.tec, "TEC")) + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.mnd, "MND")) + this.getRebirthValuePtsUsed(slot, this.saveData.slot[slot].rebirth.sta, "STA") };
                this.txtRebirthPoints.Text = string.Concat(objArray);
                this.txtRebirthMaxType.Text = (30 + this.saveData.slot[slot].rebirth.additionalTypeLevels);
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

        private unsafe void displayRebirthStatInfo(int slot, int statVal, string switchFlag, Label statTextBox, Label bpTextBox, NumericUpDown numBox, Label nextTextBox)
        {
            int num;
            int num2;
            int num3;
            this.getRebirthValues(statVal, switchFlag, &num, &num2, &num3);
            statTextBox.Text = "+" + num2;
            bpTextBox.Text = num;
            nextTextBox.Text = (statVal < 10) ? ("+" + num3 + "pt") : "max";
            nextTextBox.ForeColor = Color.DarkGreen;
            if ((num3 > this.saveData.slot[slot].rebirth.remaining_points) || (statVal >= 10))
            {
                nextTextBox.ForeColor = Color.DarkRed;
            }
            numBox.Value = statVal;
        }

        private void displaySharedStorage(int page)
        {
            this.storageView.SelectedItems.Clear();
            this.storageView.Items.Clear();
            this.sortStorage();
            this.saveData.sharedInventory.itemsUsed = 0;
            this.txtStorageMeseta.Text = this.saveData.sharedMeseta;
            int num = 0;
            if (this.mainSettings.saveStructureIndex.shared_inventory_slots == 0x3e8)
            {
                num = 0x3e8;
            }
            int num2 = -1;
            for (int i = 0; i < (this.mainSettings.saveStructureIndex.shared_inventory_slots + num); i++)
            {
                if (this.saveData.sharedInventory.item[i].type != itemType.free_slot)
                {
                    this.saveData.sharedInventory.itemsUsed++;
                }
                inventoryItemClass class2 = this.saveData.sharedInventory.item[i];
                if (this.allowShowItem(page, class2))
                {
                    string text = "";
                    if (class2.type == itemType.free_slot)
                    {
                        text = "---- Free Slot ----";
                    }
                    else
                    {
                        text = ((class2.name != "") || (class2.name_jp == "")) ? ((class2.name != "") ? (class2.name + " (" + class2.name_jp + ")") : ("Unk_" + class2.hex_reversed)) : class2.name_jp;
                        if (this.getWeaponExtendType(class2.extended, class2.style, this.getWeaponTypeFromHex(class2.hex_reversed)) == itemExtendType.unknown)
                        {
                            MessageBox.Show("unknown extend " + text + " " + class2.hex_reversed);
                        }
                    }
                    ListViewItem item = new ListViewItem(text, this.getImageListNumber(class2)) {
                        SubItems = { i }
                    };
                    this.storageView.Items.Add(item);
                    if ((this.selectItemAfterLoad != -1) && (class2.id == this.selectItemAfterLoad))
                    {
                        num2 = this.storageView.Items.Count - 1;
                    }
                }
            }
            if (num2 != -1)
            {
                this.storageView.Items[num2].Selected = true;
                this.storageView.Items[num2].EnsureVisible();
                this.selectItemAfterLoad = -1;
            }
            else if (this.selectItemAfterLoad != -1)
            {
                int num5 = 0;
                if (this.saveData.type == SaveType.PSP2I)
                {
                    num5 += 0x3e8;
                }
                for (int j = 0; j < 0x7d0; j++)
                {
                    if (this.saveData.sharedInventory.item[j].id == this.selectItemAfterLoad)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (this.allowShowItem(k + 1, this.saveData.sharedInventory.item[j]))
                            {
                                this.tabArea.SelectedIndex = 3;
                                this.storageViewPages.SelectedIndex = k;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            object[] objArray = new object[] { "Shared (", this.saveData.sharedInventory.itemsUsed, "/", this.mainSettings.saveStructureIndex.shared_inventory_slots, ")" };
            this.tabPageStorage.Text = string.Concat(objArray);
        }

        private void displaySlotInfo(int slotnum)
        {
            if (this.saveData.type == SaveType.PSP2I)
            {
                bool flag = true;
                foreach (TabPage page in this.tabControlMissions.TabPages)
                {
                    if (ReferenceEquals(page, this.tabEp2Missions))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    this.tabControlMissions.TabPages.Add(this.tabEp2Missions);
                    this.tabControlMissions.TabPages.Add(this.tabPageInfinityMission);
                }
                flag = true;
                foreach (TabPage page2 in this.tabArea.TabPages)
                {
                    if (ReferenceEquals(page2, this.tabPageRebirth))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    this.tabArea.TabPages.Add(this.tabPageRebirth);
                }
            }
            else
            {
                bool flag2 = false;
                foreach (TabPage page3 in this.tabControlMissions.TabPages)
                {
                    if (ReferenceEquals(page3, this.tabEp2Missions))
                    {
                        flag2 = true;
                        break;
                    }
                }
                if (flag2)
                {
                    this.tabControlMissions.TabPages.Remove(this.tabEp2Missions);
                    this.tabControlMissions.TabPages.Remove(this.tabPageInfinityMission);
                }
                flag2 = false;
                foreach (TabPage page4 in this.tabArea.TabPages)
                {
                    if (ReferenceEquals(page4, this.tabPageRebirth))
                    {
                        flag2 = true;
                        break;
                    }
                }
                if (flag2)
                {
                    this.tabArea.TabPages.Remove(this.tabPageRebirth);
                }
            }
            this.displayCharacterInfo(slotnum);
            this.displayRebirthInfo(slotnum);
            this.displayTypeInfo(slotnum);
            this.displayInventory(slotnum, 1);
            this.displaySharedStorage(1);
            this.displayPAList(slotnum);
            this.displayInfinityMissions();
        }

        private void displaySlotUnitImage(pageFields fields, slotType slot)
        {
            fields.img_item.Visible = true;
            switch (slot)
            {
                case slotType.unit:
                    fields.img_item.Image = Resources.slot_unit;
                    return;

                case slotType.mirage:
                    fields.img_item.Image = Resources.slot_mirage;
                    return;

                case slotType.suv:
                    fields.img_item.Image = Resources.slot_suv;
                    return;

                case slotType.visual:
                    fields.img_item.Image = Resources.slot_visual;
                    return;
            }
        }

        private void displayTypeInfo(int slotnum)
        {
            for (int i = 0; i < 4; i++)
            {
                this.displayTypePage(slotnum, (jobType) i);
            }
        }

        private void displayTypePage(int slotnum, jobType i)
        {
            bool flag = false;
            if (this.saveData.slot[slotnum].job[(int) i].level >= (30 + this.saveData.slot[slotnum].rebirth.additionalTypeLevels))
            {
                flag = true;
            }
            if (flag)
            {
                this.saveData.slot[slotnum].job[(int) i].exp_to_next = 0;
                this.saveData.slot[slotnum].job[(int) i].exp_next = this.saveData.slot[slotnum].job[(int) i].exp;
                this.saveData.slot[slotnum].job[(int) i].exp_percent = 100;
            }
            else
            {
                expDb_ItemClass class2 = new expDb_ItemClass();
                class2 = this.findExpTypeInfoInDb(this.saveData.slot[slotnum].job[(int) i].level);
                if (class2 == null)
                {
                    MessageBox.Show("could not find typeexp for type level " + this.saveData.slot[slotnum].job[(int) i].level);
                }
                this.saveData.slot[slotnum].job[(int) i].exp_to_next = (class2.exp + class2.exp_next) - this.saveData.slot[slotnum].job[(int) i].exp;
                this.saveData.slot[slotnum].job[(int) i].exp_next = class2.exp + class2.exp_next;
                this.saveData.slot[slotnum].job[(int) i].exp_percent = (class2.exp_next != 0) ? this.run.hexAndMathFunction.getPercentage(this.saveData.slot[slotnum].job[(int) i].exp - class2.exp, class2.exp_next) : 100;
            }
            typeSectionFields fields = new typeSectionFields();
            TabPage tabPageHunter = new TabPage();
            switch (i)
            {
                case jobType.Hunter:
                    tabPageHunter = this.tabPageHunter;
                    break;

                case jobType.Ranger:
                    tabPageHunter = this.tabPageRanger;
                    break;

                case jobType.Force:
                    tabPageHunter = this.tabPageForce;
                    break;

                case jobType.Vanguard:
                    tabPageHunter = this.tabPageVanguard;
                    break;

                default:
                    MessageBox.Show("jobType " + i + " not handled in displayTypePage", "Fatal Error!");
                    break;
            }
            fields = this.getTypeSectionFields(tabPageHunter);
            object[] objArray = new object[] { tabPageHunter.Name.Replace("tabPage", ""), " (", this.saveData.slot[slotnum].job[(int) i].level, ")" };
            tabPageHunter.Text = string.Concat(objArray);
            fields.txtLevel.Text = this.saveData.slot[slotnum].job[(int) i].level;
            object[] objArray2 = new object[] { "Type Extend ", this.saveData.slot[slotnum].job[(int) i].extendpointsused, "/", this.saveData.slot[slotnum].job[(int) i].extendpoints };
            fields.grpExtend.Text = string.Concat(objArray2);
            fields.txtExp.Text = "Next " + this.saveData.slot[slotnum].job[(int) i].exp_to_next;
            fields.expBar.Width = this.saveData.slot[slotnum].job[(int) i].exp_percent;
            this.showTypeWeaponExtendImages(this.saveData.slot[slotnum].job[(int) i], tabPageHunter);
        }

        private void displayWeaponExtendInfo(pageFields fields, inventoryItemClass item)
        {
            weaponType weapon = this.getWeaponTypeFromHex(item.hex_reversed);
            itemExtendType type2 = this.getWeaponExtendType(item.extended, item.style, weapon);
            string str = "FULL";
            if (item.inf_extended == itemInfExtendType.extended)
            {
                str = "EXT FULL";
            }
            else if (item.inf_extended == itemInfExtendType.not_extended_special)
            {
                str = "FULL";
            }
            else if (item.inf_extended == itemInfExtendType.extended_special)
            {
                str = "EXT FULL";
            }
            else if (item.inf_extended != itemInfExtendType.not_extended)
            {
                MessageBox.Show("Unknown infinity extend type: " + item.inf_extended);
            }
            switch (type2)
            {
                case itemExtendType.not_extended:
                    str = "";
                    break;

                case itemExtendType.extended:
                    fields.txt_grinds.Text = "(" + str + ")";
                    break;

                case itemExtendType.dlc_not_extended:
                    str = "";
                    break;

                case itemExtendType.dlc_extended:
                    fields.txt_grinds.Text = "(" + str + ")";
                    break;

                case itemExtendType.not_extended_cs1:
                    str = "";
                    fields.txt_grinds.Text = "CSI " + fields.txt_grinds.Text;
                    break;

                case itemExtendType.not_extended_cs2:
                    str = "";
                    fields.txt_grinds.Text = "CSII " + fields.txt_grinds.Text;
                    break;

                case itemExtendType.extended_cs1:
                    fields.txt_grinds.Text = "CSI (" + str + ")";
                    break;

                case itemExtendType.extended_cs2:
                    fields.txt_grinds.Text = "CSII (" + str + ")";
                    break;

                case itemExtendType.unknown:
                {
                    object[] objArray = new object[] { item.style, " ", item.extended, " ", fields.txt_grinds.Text };
                    fields.txt_grinds.Text = string.Concat(objArray);
                    break;
                }
                default:
                    MessageBox.Show("Unhandled extend type: " + item.extended);
                    break;
            }
            decimal num = new decimal(1.0);
            if (item.spcl_effect == "Unsealed")
            {
                num = new decimal(1.3);
                item.ext_special_level = "LV5";
                item.special_level = "LV5";
            }
            if (str == "FULL")
            {
                if ((item.style != weaponStyleType.Tech) && (weapon != weaponType.longbow))
                {
                    if ((item.power != 0) && (item.ext_power != 0))
                    {
                        fields.txt_atk.Text = "ATK  " + ((int) (((item.power + this.grindsToPowIncrease(weapon, item.grinds, item.rarity)) + item.ext_power) * num));
                        fields.txt_acc.Text = "ACC  " + ((int) ((item.acc + item.ext_acc) * num));
                    }
                    else
                    {
                        fields.txt_atk.Text = "ATK  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                }
                else
                {
                    if ((item.power == 0) || (item.ext_power == 0))
                    {
                        fields.txt_atk.Text = "TEC  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                    else
                    {
                        fields.txt_atk.Text = "TEC  " + ((int) (((item.power + item.ext_power) + this.grindsToPowIncrease(weapon, item.grinds, item.rarity)) * num));
                        if (weapon == weaponType.longbow)
                        {
                            fields.txt_acc.Text = "ACC  " + ((int) ((item.acc + item.ext_acc) * num));
                        }
                    }
                    if (weapon != weaponType.longbow)
                    {
                        fields.txt_acc.Text = "";
                    }
                }
                fields.txt_level.Text = item.ext_level;
            }
            else if (str == "EXT FULL")
            {
                if ((item.style != weaponStyleType.Tech) && (weapon != weaponType.longbow))
                {
                    if ((item.power != 0) && ((item.ext_power != 0) && (item.inf_ext_power != 0)))
                    {
                        fields.txt_atk.Text = "ATK  " + ((int) ((((item.power + item.ext_power) + item.inf_ext_power) + this.grindsToPowIncrease(weapon, item.grinds, item.rarity)) * num));
                        fields.txt_acc.Text = "ACC  " + ((int) (((item.acc + item.ext_acc) + item.inf_ext_acc) * num));
                    }
                    else
                    {
                        fields.txt_atk.Text = "ATK  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                }
                else
                {
                    if ((item.power == 0) || ((item.ext_power == 0) || (item.inf_ext_power == 0)))
                    {
                        fields.txt_atk.Text = "TEC  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                    else
                    {
                        fields.txt_atk.Text = "TEC  " + ((int) ((((item.power + item.ext_power) + item.inf_ext_power) + this.grindsToPowIncrease(weapon, item.grinds, item.rarity)) * num));
                        if (weapon == weaponType.longbow)
                        {
                            fields.txt_acc.Text = "ACC  " + ((int) (((item.acc + item.ext_acc) + item.inf_ext_acc) * num));
                        }
                    }
                    if (weapon != weaponType.longbow)
                    {
                        fields.txt_acc.Text = "";
                    }
                }
                fields.txt_level.Text = item.inf_ext_level;
            }
            else
            {
                if ((item.style != weaponStyleType.Tech) && (weapon != weaponType.longbow))
                {
                    if (item.power == 0)
                    {
                        fields.txt_atk.Text = "ATK  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                    else
                    {
                        fields.txt_atk.Text = "ATK  " + ((int) ((item.power + this.grindsToPowIncrease(this.getWeaponTypeFromHex(item.hex_reversed), item.grinds, item.rarity)) * num));
                        fields.txt_acc.Text = "ACC  " + ((int) (item.acc * num));
                    }
                }
                else
                {
                    if (item.power == 0)
                    {
                        fields.txt_atk.Text = "TEC  DB_Error";
                        fields.txt_acc.Text = "ACC  DB_Error";
                    }
                    else
                    {
                        fields.txt_atk.Text = "TEC  " + ((int) ((item.power + this.grindsToPowIncrease(weapon, item.grinds, item.rarity)) * num));
                        if (weapon == weaponType.longbow)
                        {
                            fields.txt_acc.Text = "ACC  " + ((int) (item.acc * num));
                        }
                    }
                    if (weapon != weaponType.longbow)
                    {
                        fields.txt_acc.Text = "";
                    }
                }
                fields.txt_level.Text = item.level;
            }
            if ((item.power_add <= 0) || ((item.power_add > 0x270f) || (fields.txt_atk.Text.Replace("DB_Error", "") != fields.txt_atk.Text)))
            {
                if ((item.power_add > 0x270f) && (fields.txt_atk.Text.Replace("DB_Error", "") == fields.txt_atk.Text))
                {
                    fields.txt_atk.Text = ((item.style == weaponStyleType.Tech) || (weapon == weaponType.longbow)) ? ("TEC  " + ((int) (item.power * num))) : ("ATK  " + ((int) (item.power * num)));
                }
            }
            else
            {
                int num2 = int.Parse(fields.txt_atk.Text.Replace("ATK  ", "").Replace("TEC  ", "")) + item.power_add;
                if (num2 > 0x270f)
                {
                    num2 = 0x270f;
                }
                if ((item.style != weaponStyleType.Tech) && (weapon != weaponType.longbow))
                {
                    object[] objArray3 = new object[] { "ATK  ", num2, " [+", item.power_add, "]" };
                    fields.txt_atk.Text = string.Concat(objArray3);
                }
                else
                {
                    object[] objArray2 = new object[] { "TEC  ", num2, " [+", item.power_add, "]" };
                    fields.txt_atk.Text = string.Concat(objArray2);
                }
            }
            if ((item.ability != abilityType.None) && ((item.special != "None") && ((str == "FULL") || (str == "EXT FULL"))))
            {
                item.special = "None (なし)";
            }
            if (item.special == "")
            {
                item.special = "None (なし)";
            }
            if ((item.special != "None (なし)") && ((item.special != "None") && (item.special != null)))
            {
                fields.txt_special.Visible = true;
                if (item.special == "Varies by element")
                {
                    item.special = this.getElementSpecialAsString(item.element);
                }
                if ((str != "FULL") && (str != "EXT FULL"))
                {
                    string[] strArray2 = new string[] { "Ability  ", item.special, " ", item.special_level, " ", this.abilityToJp(this.stringToAbilityEnum(item.special)) };
                    fields.txt_special.Text = string.Concat(strArray2);
                }
                else
                {
                    string[] strArray = new string[] { "Ability  ", item.special, " ", item.ext_special_level, " ", this.abilityToJp(this.stringToAbilityEnum(item.special)), " [Extended]" };
                    fields.txt_special.Text = string.Concat(strArray);
                }
            }
            else if (item.ability == abilityType.None)
            {
                fields.txt_special.Text = "Ability  None (なし)";
            }
            else
            {
                string str3 = item.ability.ToString().Replace("_", " ");
                if (item.style == weaponStyleType.Tech)
                {
                    str3 = (item.ability + abilityType.Empow_none).ToString().Replace("_", " ");
                }
                if ((str != "FULL") && (str != "EXT FULL"))
                {
                    string[] strArray4 = new string[] { "Ability  ", str3.Replace("Empow", "Empow."), " ", item.special_level, " ", this.abilityToJp(this.stringToAbilityEnum(str3)) };
                    fields.txt_special.Text = string.Concat(strArray4);
                }
                else
                {
                    string[] strArray3 = new string[] { "Ability  ", str3.Replace("Empow", "Empow."), " ", item.ext_special_level, " ", this.abilityToJp(this.stringToAbilityEnum(str3)), " [Extended]" };
                    fields.txt_special.Text = string.Concat(strArray3);
                }
            }
        }

        private void displayWeaponImage(pageFields fields, weaponType weapon)
        {
            Image image = this.getWeaponImageFromType(weapon);
            if (image == null)
            {
                fields.img_item.Visible = false;
            }
            else
            {
                fields.img_item.Image = image;
                fields.img_item.Visible = true;
            }
        }

        private void displayWeaponManufacturerImage(pageFields fields, weaponManufacturerType manufacturer)
        {
            fields.img_manufaturer.Visible = true;
            Image image = this.getWeaponManufacturerImage(manufacturer);
            if (image == null)
            {
                fields.img_manufaturer.Visible = false;
            }
            else
            {
                fields.img_manufaturer.Image = image;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool downloadFile(string url, string dirdest, string progressTxt, string saveas = "")
        {
            if (!this.allowDownload)
            {
                MessageBox.Show("Please wait for the current download to finish", "Download already in progress", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.allowDownload = false;
            this.downloadedData = new byte[0x7d000];
            this.downloadedDataName = "";
            try
            {
                WebResponse response = WebRequest.Create(url).GetResponse();
                Stream responseStream = response.GetResponseStream();
                int contentLength = (int) response.ContentLength;
                this.toolStripProgressBar.Maximum = contentLength;
                this.toolStripProgressBar.Value = 0;
                int num2 = 3;
                while (true)
                {
                    if (num2 < url.Length)
                    {
                        if (url.Substring(url.Length - num2, 1) != "/")
                        {
                            num2++;
                            continue;
                        }
                        this.downloadedDataName = url.Substring((url.Length - num2) + 1, (url.Length - (url.Length - num2)) - 1);
                    }
                    MemoryStream stream2 = new MemoryStream();
                    byte[] buffer = new byte[0x400];
                    while (true)
                    {
                        int count = responseStream.Read(buffer, 0, buffer.Length);
                        if (count == 0)
                        {
                            this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum;
                            object[] objArray = new object[] { "Completed: ", progressTxt, " ", this.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, contentLength), "%" };
                            this.toolStripStatusLabel.Text = string.Concat(objArray);
                            Application.DoEvents();
                            this.downloadedData = stream2.ToArray();
                            responseStream.Close();
                            stream2.Close();
                            break;
                        }
                        stream2.Write(buffer, 0, count);
                        if ((this.toolStripProgressBar.Value + count) <= this.toolStripProgressBar.Maximum)
                        {
                            this.toolStripProgressBar.Value += count;
                            object[] objArray2 = new object[] { "Downloading: ", progressTxt, " ", this.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, contentLength), "%" };
                            this.toolStripStatusLabel.Text = string.Concat(objArray2);
                            Application.DoEvents();
                        }
                    }
                    break;
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
                this.allowDownload = true;
                return false;
            }
            if (saveas != "")
            {
                this.downloadedDataName = saveas;
            }
            FileStream stream3 = new FileStream(dirdest + this.downloadedDataName, FileMode.Create);
            stream3.Write(this.downloadedData, 0, this.downloadedData.Length);
            stream3.Close();
            this.allowDownload = true;
            return true;
        }

        private bool downloadRequiredFile(string fn, string reason, long byteSize)
        {
            bool flag = true;
            bool flag2 = false;
            while (flag)
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + @"\" + fn))
                {
                    if (Directory.GetCurrentDirectory() != Directory.GetCurrentDirectory().Replace(@"PSPo2 Save Editor\bin\Debug", ""))
                    {
                        flag = false;
                        flag2 = true;
                        continue;
                    }
                    FileStream stream2 = System.IO.File.OpenRead(Directory.GetCurrentDirectory() + @"\" + fn);
                    long length = stream2.Length;
                    stream2.Close();
                    if (length != byteSize)
                    {
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + @"\" + fn);
                        continue;
                    }
                    flag = false;
                    flag2 = true;
                    continue;
                }
                if (MessageBox.Show(fn + " is a required file which is missing, corrupt or out of date.\n\nDo you want to download it now?\n\n" + reason, "Required File Missing or Corrupt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    flag = false;
                    continue;
                }
                this.disableMainForm();
                string url = "http://files-ds-scene.net/retrohead/pspo2se/releases/" + fn;
                if (!this.downloadFile(url, @"data/temp\", fn, ""))
                {
                    MessageBox.Show(fn + " failed to download, please check your internet connection\r\nor the site may be down!", "Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (System.IO.File.OpenRead(@"data/temp\" + fn).Length != byteSize)
                {
                    MessageBox.Show(fn + " which was downloaded appears to be corrupt, please try again!", "Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    System.IO.File.Copy(@"data/temp\" + fn, fn);
                    MessageBox.Show(fn + " downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag = false;
                    flag2 = true;
                }
                this.enableMainForm();
                if (flag && (MessageBox.Show("Do you want to retry the download now?", "Try Again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                {
                    flag = false;
                }
            }
            return flag2;
        }

        public string elementToSubEnemyType(elementType element)
        {
            string[] strArray = this.intToInfinityEnemy((int) element);
            return (strArray[1] + " (" + strArray[0] + ")");
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

        private bool encryptSaveFile(string file, string dest)
        {
            ProcessStartInfo info = new ProcessStartInfo {
                FileName = "SED.exe"
            };
            if (!System.IO.File.Exists(info.FileName))
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
            string str2 = this.getGameIdFromSfo(dest);
            if (!System.IO.File.Exists(@"data\keys\" + str2 + ".bin"))
            {
                MessageBox.Show("You must place the '" + str2 + ".bin' key file in the data\\keys directory.\n\nSearch for SGKeyDumper to obtain the key for your game.");
                return false;
            }
            string[] strArray = new string[] { "-e \"", file, "\" \"", path, "\" \"", dest, "\" data\\keys\\", str2, ".bin" };
            info.Arguments = string.Concat(strArray);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process {
                StartInfo = info
            };
            process.Start();
            process.WaitForExit();
            return true;
        }

        public string enumToName(string type)
        {
            string str = type.Replace("_", " ");
            return this.run.hexAndMathFunction.stringToProper(str);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public expDb_ItemClass findExpLevelInfoInDb(int level)
        {
            if ((level - 1) < this.exp_db_filled)
            {
                return this.exp_db.level[level - 1];
            }
            MessageBox.Show("Fatal error. Trying to exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return null;
        }

        public expDb_ItemClass findExpTypeInfoInDb(int level)
        {
            if (level < this.type_db_filled)
            {
                return this.typeexp_db.level[level];
            }
            MessageBox.Show("Fatal error. Trying to get type exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return null;
        }

        public string findImageFloatInList(string hex)
        {
            for (int i = 0; i < this.imageFloater.filled; i++)
            {
                if (hex.ToLower() == this.imageFloater.imagelist[i].Name.Substring(0, 8).ToLower())
                {
                    this.imageFloatImageIsOk = true;
                    return this.imageFloater.imagelist[i].FullName;
                }
            }
            this.imageFloatImageIsOk = false;
            return "";
        }

        public itemDb_ItemClass findItemInDb(string hex)
        {
            itemDb_ItemClass class2 = new itemDb_ItemClass();
            for (int i = 0; i < this.item_db_filled; i++)
            {
                if (hex == this.item_db.item[i].hex)
                {
                    return this.item_db.item[i];
                }
            }
            return class2;
        }

        public expDb_ItemClass findRebirthBpInfoInDb(int level)
        {
            if (((level - 50) + 200) < this.exp_db_filled)
            {
                return this.exp_db.level[(level - 50) + 200];
            }
            MessageBox.Show("Fatal error. Trying to get rebirth info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return null;
        }

        private string fixFileNameNoExt(string fn, string ext_options)
        {
            string str = "";
            int startIndex = ext_options.Length - 1;
            while (true)
            {
                if (startIndex >= 0)
                {
                    string str2 = ext_options.Substring(startIndex, 1);
                    if (str2 != "*")
                    {
                        str = str2 + str;
                        startIndex--;
                        continue;
                    }
                }
                if (fn.Substring(fn.Length - str.Length, str.Length).ToLower() != str.ToLower())
                {
                    fn = fn + "." + str;
                }
                return fn;
            }
        }

        private int getClothesTypeFromHex(string hex)
        {
            hex = hex.Substring(4, 2);
            return int.Parse(hex, NumberStyles.HexNumber);
        }

        private string getElementSpecialAsString(elementType element)
        {
            switch (element)
            {
                case elementType.Neutral:
                    return "None";

                case elementType.Fire:
                    return "Burn";

                case elementType.Ice:
                    return "Freeze";

                case elementType.Thunder:
                    return "Shock";

                case elementType.Earth:
                    return "Confusion";

                case elementType.Light:
                    return "Sleep";

                case elementType.Dark:
                    return "Poison";
            }
            return "unknown";
        }

        private int getFreeInventoryItemId(int slot) => 
            (this.saveData.slot[slot].inventory.itemsUsed >= 60) ? -1 : ((((this.saveData.slot[slot].inventory.itemsUsed * 0x24) + 8) + (slot * this.mainSettings.saveStructureIndex.slot_size)) + this.mainSettings.saveStructureIndex.inventory_slots_pos);

        private string getGameIdFromSfo(string gameSave)
        {
            string directoryName = Path.GetDirectoryName(gameSave);
            FileStream input = this.openFileRead(Path.Combine(directoryName, "PARAM.SFO"));
            BinaryReader reader = new BinaryReader(input);
            reader.ReadBytes(0x510);
            byte[] bytes = reader.ReadBytes(9);
            input.Close();
            return Encoding.Default.GetString(bytes);
        }

        public greenItemType getGreenItemTypeFromHex(string hex_reversed)
        {
            string str = hex_reversed.Substring(5, 1);
            if (str != null)
            {
                if (str == "1")
                {
                    string key = hex_reversed.Substring(3, 1);
                    if (key != null)
                    {
                        int num;
                        if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000bd-1 == null)
                        {
                            Dictionary<string, int> dictionary1 = new Dictionary<string, int>(9);
                            dictionary1.Add("0", 0);
                            dictionary1.Add("1", 1);
                            dictionary1.Add("2", 2);
                            dictionary1.Add("3", 3);
                            dictionary1.Add("6", 4);
                            dictionary1.Add("7", 5);
                            dictionary1.Add("9", 6);
                            dictionary1.Add("A", 7);
                            dictionary1.Add("B", 8);
                            <PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000bd-1 = dictionary1;
                        }
                        if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000bd-1.TryGetValue(key, out num))
                        {
                            switch (num)
                            {
                                case 0:
                                    return greenItemType.monomate;

                                case 1:
                                    return greenItemType.dimate;

                                case 2:
                                    return greenItemType.trimate;

                                case 3:
                                    return greenItemType.star_atom;

                                case 4:
                                    return greenItemType.sol_atom;

                                case 5:
                                    return greenItemType.moon_atom;

                                case 6:
                                    return greenItemType.doll;

                                case 7:
                                    return greenItemType.shiftaride;

                                case 8:
                                    return greenItemType.debanride;

                                default:
                                    break;
                            }
                        }
                    }
                    MessageBox.Show("Heal type item type not recognised for image: " + hex_reversed.Substring(3, 1));
                    return greenItemType.none;
                }
                if (str == "3")
                {
                    return greenItemType.calorie;
                }
                if (str == "4")
                {
                    return greenItemType.item;
                }
            }
            MessageBox.Show("Green item type not recognised for image: " + hex_reversed.Substring(5, 1));
            return greenItemType.none;
        }

        private int getImageListNumber(inventoryItemClass item)
        {
            int num = 0x3e8;
            switch (item.type)
            {
                case itemType.Weapon:
                    num = (int) ((this.getWeaponTypeFromHex(item.hex_reversed) - 1) + ((weaponType) ((int) (((itemRankType) 0x1c) * this.getItemRankFromRarity(item.rarity)))));
                    if (item.equipped_now == 1)
                    {
                        num += 280;
                    }
                    else if (item.equipped_slot > 0)
                    {
                        num += 140;
                    }
                    break;

                case itemType.Armor:
                    num = (int) this.getItemRankFromRarity(item.rarity);
                    if (item.equipped_now == 1)
                    {
                        num += 10;
                    }
                    else if (item.equipped_slot > 0)
                    {
                        num += 5;
                    }
                    break;

                case itemType.Green_Item:
                    switch (this.getGreenItemTypeFromHex(item.hex_reversed))
                    {
                        case greenItemType.monomate:
                            num = 3;
                            break;

                        case greenItemType.dimate:
                            num = 3;
                            break;

                        case greenItemType.trimate:
                            num = 3;
                            break;

                        case greenItemType.star_atom:
                            num = 3;
                            break;

                        case greenItemType.sol_atom:
                            num = 4;
                            break;

                        case greenItemType.moon_atom:
                            num = 5;
                            break;

                        case greenItemType.doll:
                            num = 5;
                            break;

                        case greenItemType.shiftaride:
                            num = 6;
                            break;

                        case greenItemType.debanride:
                            num = 6;
                            break;

                        case greenItemType.calorie:
                            num = 7;
                            break;

                        case greenItemType.item:
                            num = 8;
                            break;

                        default:
                            MessageBox.Show("Green item type not recognised for image: " + this.getGreenItemTypeFromHex(item.hex_reversed));
                            break;
                    }
                    if (item.equipped_now == 1)
                    {
                        num += 0x12;
                    }
                    else if (item.equipped_slot > 0)
                    {
                        num += 9;
                    }
                    break;

                case itemType.PA_Disk_Melee:
                    num = 0;
                    break;

                case itemType.PA_Disk_Ranged:
                    num = 0;
                    break;

                case itemType.PA_Disk_Technique:
                    num = 0;
                    break;

                case itemType.Infinity_Code:
                    num = 8;
                    break;

                case itemType.Slot_Unit:
                    num = (int) ((this.getSlotTypeFromHex(item.hex_reversed) + ((slotType) 15)) + ((slotType) ((int) (this.getItemRankFromRarity(item.rarity) * itemRankType.unknown))));
                    if (item.equipped_now == 1)
                    {
                        num += 40;
                    }
                    else if (item.equipped_slot > 0)
                    {
                        num += 20;
                    }
                    break;

                case itemType.Clothes_human:
                    switch (this.getClothesTypeFromHex(item.hex_reversed))
                    {
                        case 1:
                            num = 0;
                            break;

                        case 2:
                            num = 1;
                            break;

                        case 3:
                            num = 2;
                            break;

                        case 4:
                            num = 3;
                            break;

                        case 5:
                            num = 4;
                            break;

                        case 6:
                            num = 5;
                            break;

                        default:
                            break;
                    }
                    if (item.equipped_now == 1)
                    {
                        num += 20;
                    }
                    else if (item.equipped_slot > 0)
                    {
                        num += 10;
                    }
                    break;

                case itemType.Clothes_android:
                    switch (this.getClothesTypeFromHex(item.hex_reversed))
                    {
                        case 1:
                            num = 6;
                            break;

                        case 2:
                            num = 7;
                            break;

                        case 3:
                            num = 8;
                            break;

                        case 6:
                            num = 9;
                            break;

                        default:
                            break;
                    }
                    if (item.equipped_now == 1)
                    {
                        num += 20;
                    }
                    else if (item.equipped_slot > 0)
                    {
                        num += 10;
                    }
                    break;

                case itemType.Room_Decoration:
                    num = 2;
                    break;

                case itemType.Trap:
                    if (item.hex_reversed.Substring(5, 1) == "1")
                    {
                        num = 1;
                    }
                    if (item.hex_reversed.Substring(5, 1) == "2")
                    {
                        num = 2;
                    }
                    break;

                case itemType.My_Synth_Device:
                    num = 1;
                    break;

                case itemType.Extend_Code:
                    num = 0;
                    break;

                case itemType.free_slot:
                    num = 3;
                    break;

                default:
                    break;
            }
            return num;
        }

        public itemRankType getItemRankFromRarity(int rarity)
        {
            itemRankType c = itemRankType.c;
            if (rarity < 0)
            {
                c = itemRankType.unknown;
            }
            if (rarity >= 3)
            {
                c = itemRankType.b;
            }
            if (rarity >= 6)
            {
                c = itemRankType.a;
            }
            if (rarity >= 9)
            {
                c = itemRankType.s;
            }
            return c;
        }

        public itemType getItemTypeFromHex(string hex)
        {
            hex = hex.Substring(0, 2);
            return (itemType) int.Parse(hex, NumberStyles.HexNumber);
        }

        public pageFields getPageFields(TabPage page, bool inDatabase = false)
        {
            pageFields fields = new pageFields();
            if (ReferenceEquals(page, this.tabPageInventory))
            {
                fields.img_rank = this.imgInventoryRank;
                fields.img_item = this.imgInventoryItemIcon;
                fields.img_manufaturer = this.imgInventoryWeaponManufacturer;
                fields.img_infinity_item = this.imgInventoryInfinityItem;
                fields.img_element = this.imgInventoryElement;
                fields.img_star_0 = this.imgStar0;
                fields.img_star_1 = this.imgStar1;
                fields.img_star_2 = this.imgStar2;
                fields.img_star_3 = this.imgStar3;
                fields.img_star_4 = this.imgStar4;
                fields.img_star_5 = this.imgStar5;
                fields.img_star_6 = this.imgStar6;
                fields.img_star_7 = this.imgStar7;
                fields.img_star_8 = this.imgStar8;
                fields.img_star_9 = this.imgStar9;
                fields.img_star_10 = this.imgStar10;
                fields.img_star_11 = this.imgStar11;
                fields.img_star_12 = this.imgStar12;
                fields.img_star_13 = this.imgStar13;
                fields.img_star_14 = this.imgStar14;
                fields.img_star_15 = this.imgStar15;
                fields.txt_infinity_item = this.txtInventoryInfinityItemText;
                fields.txt_name = this.txtInventoryName;
                fields.txt_name_jp = this.txtInventoryName_jp;
                fields.grp_details = this.grpInventoryItemDetails;
                fields.txt_grinds = this.txtInventoryGrinds;
                fields.txt_percent = this.txtInventoryPercent;
                fields.txt_hex = this.txtInventoryHex;
                fields.txt_meseta = this.txtInventoryMeseta;
                fields.txt_qty = this.txtInventoryQty;
                fields.txt_special = this.txtInventorySpecial;
                fields.txt_effect = this.txtInventoryEffect;
                fields.txt_atk = this.txtInventoryATK;
                fields.txt_acc = this.txtInventoryACC;
                fields.txt_level = this.txtInventoryLevel;
                fields.btn_delete = this.btnInventoryDelete;
                fields.btn_export_selected = this.btnInventoryExportSelected;
                fields.btn_import_selected = this.btnInventoryImportSelected;
                fields.chk_delete_export = this.chkDeleteExportInventory;
                fields.btn_withdraw = this.btnInventoryDeposit;
                fields.pnl_details = null;
            }
            else if (!ReferenceEquals(page, this.tabPageStorage))
            {
                MessageBox.Show("The selected page for getFields was not recognised: " + page);
            }
            else
            {
                fields.img_rank = this.imgStorageRank;
                fields.img_item = this.imgStorageItemIcon;
                fields.img_manufaturer = this.imgStorageWeaponManufacturer;
                fields.img_infinity_item = this.imgStorageInfinityItem;
                fields.img_element = this.imgStorageElement;
                fields.img_star_0 = this.imgStorageStar0;
                fields.img_star_1 = this.imgStorageStar1;
                fields.img_star_2 = this.imgStorageStar2;
                fields.img_star_3 = this.imgStorageStar3;
                fields.img_star_4 = this.imgStorageStar4;
                fields.img_star_5 = this.imgStorageStar5;
                fields.img_star_6 = this.imgStorageStar6;
                fields.img_star_7 = this.imgStorageStar7;
                fields.img_star_8 = this.imgStorageStar8;
                fields.img_star_9 = this.imgStorageStar9;
                fields.img_star_10 = this.imgStorageStar10;
                fields.img_star_11 = this.imgStorageStar11;
                fields.img_star_12 = this.imgStorageStar12;
                fields.img_star_13 = this.imgStorageStar13;
                fields.img_star_14 = this.imgStorageStar14;
                fields.img_star_15 = this.imgStorageStar15;
                fields.txt_infinity_item = this.txtStorageInfinityItemText;
                fields.txt_name = this.txtStorageName;
                fields.txt_name_jp = this.txtStorageName_jp;
                fields.grp_details = this.grpStorageItemDetails;
                fields.txt_grinds = this.txtStorageGrinds;
                fields.txt_percent = this.txtStoragePercent;
                fields.txt_hex = this.txtStorageHex;
                fields.txt_meseta = this.txtStorageMeseta;
                fields.txt_qty = this.txtStorageQty;
                fields.txt_special = this.txtStorageSpecial;
                fields.txt_effect = this.txtStorageEffect;
                fields.txt_atk = this.txtStorageATK;
                fields.txt_acc = this.txtStorageACC;
                fields.txt_level = this.txtStorageLevel;
                fields.btn_delete = this.btnStorageDelete;
                fields.btn_export_selected = this.btnStorageExportSelected;
                fields.btn_import_selected = this.btnStorageImportSelected;
                fields.chk_delete_export = this.chkDeleteExportStorage;
                fields.btn_withdraw = this.btnStorageWithdraw;
                fields.pnl_details = null;
            }
            return fields;
        }

        private pageFields getPAPageFields(TabPage tab)
        {
            pageFields fields = new pageFields();
            string name = tab.Name;
            if (name != null)
            {
                if (name == "tabPAMelee")
                {
                    fields.txt_hex = this.txtPAHexMelee;
                }
                else if (name == "tabPABullets")
                {
                    fields.txt_hex = this.txtPAHexBullets;
                }
                else if (name == "tabPATech")
                {
                    fields.txt_hex = this.txtPAHexTech;
                }
            }
            return fields;
        }

        private int getRebirthNowPointGain(int level) => 
            this.findRebirthBpInfoInDb(level).exp;

        private int getRebirthNowTypeLevelGain(int level) => 
            (level >= 50) ? ((level < 200) ? ((level < 170) ? ((level < 140) ? ((level < 100) ? 1 : 5) : 10) : 15) : 20) : 0;

        private unsafe int* getRebirthStatPointer(string nameFlag)
        {
            int* hp = null;
            string key = nameFlag;
            if (key != null)
            {
                int num;
                if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x6000076-1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(9);
                    dictionary1.Add("HP", 0);
                    dictionary1.Add("PP", 1);
                    dictionary1.Add("ATK", 2);
                    dictionary1.Add("DEF", 3);
                    dictionary1.Add("ACC", 4);
                    dictionary1.Add("EVA", 5);
                    dictionary1.Add("TEC", 6);
                    dictionary1.Add("MND", 7);
                    dictionary1.Add("STA", 8);
                    <PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x6000076-1 = dictionary1;
                }
                if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x6000076-1.TryGetValue(key, out num))
                {
                    switch (num)
                    {
                        case 0:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.hp;
                            fixed (int* numRef = null)
                            {
                                break;
                            }
                        }
                        case 1:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.pp;
                            fixed (int* numRef2 = null)
                            {
                                break;
                            }
                        }
                        case 2:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.atk;
                            fixed (int* numRef3 = null)
                            {
                                break;
                            }
                        }
                        case 3:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.def;
                            fixed (int* numRef4 = null)
                            {
                                break;
                            }
                        }
                        case 4:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.acc;
                            fixed (int* numRef5 = null)
                            {
                                break;
                            }
                        }
                        case 5:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.eva;
                            fixed (int* numRef6 = null)
                            {
                                break;
                            }
                        }
                        case 6:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.tec;
                            fixed (int* numRef7 = null)
                            {
                                break;
                            }
                        }
                        case 7:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.mnd;
                            fixed (int* numRef8 = null)
                            {
                                break;
                            }
                        }
                        case 8:
                        {
                            hp = (int*) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.sta;
                            fixed (int* numRef9 = null)
                            {
                                break;
                            }
                        }
                        default:
                            break;
                    }
                }
            }
            return hp;
        }

        private unsafe int getRebirthValuePtsUsed(int slot, int val, string switchFlag)
        {
            int num;
            int num2;
            int num3;
            this.getRebirthValues(val, switchFlag, &num, &num2, &num3);
            return num;
        }

        private unsafe void getRebirthValues(int val, string type, int* points, int* stat, int* next)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            string key = type;
            if (key != null)
            {
                int num5;
                if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x6000097-1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(9);
                    dictionary1.Add("HP", 0);
                    dictionary1.Add("PP", 1);
                    dictionary1.Add("ATK", 2);
                    dictionary1.Add("DEF", 3);
                    dictionary1.Add("ACC", 4);
                    dictionary1.Add("EVA", 5);
                    dictionary1.Add("TEC", 6);
                    dictionary1.Add("MND", 7);
                    dictionary1.Add("STA", 8);
                    <PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x6000097-1 = dictionary1;
                }
                if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x6000097-1.TryGetValue(key, out num5))
                {
                    switch (num5)
                    {
                        case 0:
                            num = 15;
                            num2 = 5;
                            num3 = 50;
                            break;

                        case 1:
                            num = 5;
                            num2 = 5;
                            num3 = 5;
                            break;

                        case 2:
                            num = 20;
                            num2 = 5;
                            num3 = 0x23;
                            break;

                        case 3:
                            num = 8;
                            num2 = 4;
                            num3 = 30;
                            break;

                        case 4:
                            num = 0x19;
                            num2 = 5;
                            num3 = 20;
                            break;

                        case 5:
                            num = 0x19;
                            num2 = 5;
                            num3 = 8;
                            break;

                        case 6:
                            num = 20;
                            num2 = 5;
                            num3 = 50;
                            break;

                        case 7:
                            num = 8;
                            num2 = 4;
                            num3 = 40;
                            break;

                        case 8:
                            num = 2;
                            num2 = 2;
                            num3 = 2;
                            break;

                        default:
                            break;
                    }
                }
            }
            next[0] = num;
            points[0] = 0;
            for (int i = 0; i < val; i++)
            {
                points[0] += next[0];
                stat[0] += num3;
                next[0] += num2;
            }
        }

        public string getSlotPALearntLevel(int slotnum, string hex)
        {
            if (hex.Substring(0, 2) == "05")
            {
                string str = (int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber) + 13).ToString("X1");
                while (true)
                {
                    if (str.Length >= 2)
                    {
                        hex = hex.Substring(0, 2) + str + hex.Substring(4, 4);
                        str = (int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber) + 1).ToString("X1");
                        while (true)
                        {
                            if (str.Length >= 2)
                            {
                                hex = hex.Substring(0, 4) + str + hex.Substring(6, 2);
                                break;
                            }
                            str = "0" + str;
                        }
                        break;
                    }
                    str = "0" + str;
                }
            }
            for (int i = 0; i < 0x100; i++)
            {
                if ((this.saveData.slot[slotnum].pa.items[i] != null) && ((this.saveData.slot[slotnum].pa.items[i].hex != null) && (this.saveData.slot[slotnum].pa.items[i].hex == hex)))
                {
                    return this.saveData.slot[slotnum].pa.items[i].level;
                }
            }
            return "LV0";
        }

        private slotType getSlotTypeFromHex(string hex)
        {
            hex = hex.Substring(2, 4);
            hex = this.run.hexAndMathFunction.reversehex(hex, 4);
            int num = int.Parse(hex, NumberStyles.HexNumber);
            if ((num < 0x100) || (num > 0x472))
            {
                MessageBox.Show(string.Concat(new object[] { "Error, slot type integer not supported [", hex, ":", num, "]" }));
            }
            else
            {
                if (num < 0x405)
                {
                    return slotType.unit;
                }
                if (num < 0x425)
                {
                    return slotType.visual;
                }
                if (num < 0x454)
                {
                    return slotType.suv;
                }
                if (num < 0x466)
                {
                    return slotType.mirage;
                }
                if (num <= 0x472)
                {
                    return slotType.visual;
                }
            }
            return slotType.unit;
        }

        public typeSectionFields getTypeSectionFields(TabPage page)
        {
            typeSectionFields fields = new typeSectionFields();
            if (ReferenceEquals(page, this.tabPageHunter))
            {
                fields.txtLevel = this.txtHuLevel;
                fields.txtExp = this.txtHuExp;
                fields.expBar = this.txtHuExpBar;
                fields.grpExtend = this.grpHuTypeExtend;
            }
            else if (ReferenceEquals(page, this.tabPageRanger))
            {
                fields.txtLevel = this.txtRaLevel;
                fields.txtExp = this.txtRaExp;
                fields.expBar = this.txtRaExpBar;
                fields.grpExtend = this.grpRaTypeExtend;
            }
            else if (ReferenceEquals(page, this.tabPageForce))
            {
                fields.txtLevel = this.txtFoLevel;
                fields.txtExp = this.txtFoExp;
                fields.expBar = this.txtFoExpBar;
                fields.grpExtend = this.grpFoTypeExtend;
            }
            else if (ReferenceEquals(page, this.tabPageVanguard))
            {
                fields.txtLevel = this.txtVaLevel;
                fields.txtExp = this.txtVaExp;
                fields.expBar = this.txtVaExpBar;
                fields.grpExtend = this.grpVaTypeExtend;
            }
            return fields;
        }

        public typeWeaponRankFields getTypeWeaponExtendFields(TabPage page)
        {
            typeWeaponRankFields fields = new typeWeaponRankFields();
            if (ReferenceEquals(page, this.tabPageHunter))
            {
                fields.imgWeap[1] = this.imgHuSword;
                fields.imgWeap[2] = this.imgHuKnuckles;
                fields.imgWeap[3] = this.imgHuSpear;
                fields.imgWeap[4] = this.imgHuDblSaber;
                fields.imgWeap[5] = this.imgHuAxe;
                fields.imgWeap[6] = this.imgHuSabers;
                fields.imgWeap[7] = this.imgHuDaggers;
                fields.imgWeap[8] = this.imgHuClaws;
                fields.imgWeap[9] = this.imgHuSaber;
                fields.imgWeap[10] = this.imgHuDagger;
                fields.imgWeap[11] = this.imgHuClaw;
                fields.imgWeap[12] = this.imgHuWhip;
                fields.imgWeap[13] = this.imgHuSlicer;
                fields.imgWeap[14] = this.imgHuRifle;
                fields.imgWeap[15] = this.imgHuShotgun;
                fields.imgWeap[0x10] = this.imgHuLongbow;
                fields.imgWeap[0x11] = this.imgHuGrenade;
                fields.imgWeap[0x12] = this.imgHuLaser;
                fields.imgWeap[0x13] = this.imgHuHandguns;
                fields.imgWeap[20] = this.imgHuHandgun;
                fields.imgWeap[0x15] = this.imgHuCrossbow;
                fields.imgWeap[0x16] = this.imgHuCards;
                fields.imgWeap[0x17] = this.imgHuMachinegun;
                fields.imgWeap[0x1b] = this.imgHuRmag;
                fields.imgWeap[0x18] = this.imgHuRod;
                fields.imgWeap[0x19] = this.imgHuWand;
                fields.imgWeap[0x1a] = this.imgHuTmag;
                fields.imgWeap[0x1c] = this.imgHuShield;
                fields.imgRank[1] = this.imgHuSwordRank;
                fields.imgRank[2] = this.imgHuKnucklesRank;
                fields.imgRank[3] = this.imgHuSpearRank;
                fields.imgRank[4] = this.imgHuDblSaberRank;
                fields.imgRank[5] = this.imgHuAxeRank;
                fields.imgRank[6] = this.imgHuSabersRank;
                fields.imgRank[7] = this.imgHuDaggersRank;
                fields.imgRank[8] = this.imgHuClawsRank;
                fields.imgRank[9] = this.imgHuSaberRank;
                fields.imgRank[10] = this.imgHuDaggerRank;
                fields.imgRank[11] = this.imgHuClawRank;
                fields.imgRank[12] = this.imgHuWhipRank;
                fields.imgRank[13] = this.imgHuSlicerRank;
                fields.imgRank[14] = this.imgHuRifleRank;
                fields.imgRank[15] = this.imgHuShotgunRank;
                fields.imgRank[0x10] = this.imgHuLongbowRank;
                fields.imgRank[0x11] = this.imgHuGrenadeRank;
                fields.imgRank[0x12] = this.imgHuLaserRank;
                fields.imgRank[0x13] = this.imgHuHandgunsRank;
                fields.imgRank[20] = this.imgHuHandgunRank;
                fields.imgRank[0x15] = this.imgHuCrossbowRank;
                fields.imgRank[0x16] = this.imgHuCardsRank;
                fields.imgRank[0x17] = this.imgHuMachinegunRank;
                fields.imgRank[0x1b] = this.imgHuRmagRank;
                fields.imgRank[0x18] = this.imgHuRodRank;
                fields.imgRank[0x19] = this.imgHuWandRank;
                fields.imgRank[0x1a] = this.imgHuTmagRank;
                fields.imgRank[0x1c] = this.imgHuShieldRank;
            }
            else if (ReferenceEquals(page, this.tabPageRanger))
            {
                fields.imgWeap[1] = this.imgRaSword;
                fields.imgWeap[2] = this.imgRaKnuckles;
                fields.imgWeap[3] = this.imgRaSpear;
                fields.imgWeap[4] = this.imgRaDblSaber;
                fields.imgWeap[5] = this.imgRaAxe;
                fields.imgWeap[6] = this.imgRaSabers;
                fields.imgWeap[7] = this.imgRaDaggers;
                fields.imgWeap[8] = this.imgRaClaws;
                fields.imgWeap[9] = this.imgRaSaber;
                fields.imgWeap[10] = this.imgRaDagger;
                fields.imgWeap[11] = this.imgRaClaw;
                fields.imgWeap[12] = this.imgRaWhip;
                fields.imgWeap[13] = this.imgRaSlicer;
                fields.imgWeap[14] = this.imgRaRifle;
                fields.imgWeap[15] = this.imgRaShotgun;
                fields.imgWeap[0x10] = this.imgRaLongbow;
                fields.imgWeap[0x11] = this.imgRaGrenade;
                fields.imgWeap[0x12] = this.imgRaLaser;
                fields.imgWeap[0x13] = this.imgRaHandguns;
                fields.imgWeap[20] = this.imgRaHandgun;
                fields.imgWeap[0x15] = this.imgRaCrossbow;
                fields.imgWeap[0x16] = this.imgRaCards;
                fields.imgWeap[0x17] = this.imgRaMachinegun;
                fields.imgWeap[0x1b] = this.imgRaRmag;
                fields.imgWeap[0x18] = this.imgRaRod;
                fields.imgWeap[0x19] = this.imgRaWand;
                fields.imgWeap[0x1a] = this.imgRaTmag;
                fields.imgWeap[0x1c] = this.imgRaShield;
                fields.imgRank[1] = this.imgRaSwordRank;
                fields.imgRank[2] = this.imgRaKnucklesRank;
                fields.imgRank[3] = this.imgRaSpearRank;
                fields.imgRank[4] = this.imgRaDblSaberRank;
                fields.imgRank[5] = this.imgRaAxeRank;
                fields.imgRank[6] = this.imgRaSabersRank;
                fields.imgRank[7] = this.imgRaDaggersRank;
                fields.imgRank[8] = this.imgRaClawsRank;
                fields.imgRank[9] = this.imgRaSaberRank;
                fields.imgRank[10] = this.imgRaDaggerRank;
                fields.imgRank[11] = this.imgRaClawRank;
                fields.imgRank[12] = this.imgRaWhipRank;
                fields.imgRank[13] = this.imgRaSlicerRank;
                fields.imgRank[14] = this.imgRaRifleRank;
                fields.imgRank[15] = this.imgRaShotgunRank;
                fields.imgRank[0x10] = this.imgRaLongbowRank;
                fields.imgRank[0x11] = this.imgRaGrenadeRank;
                fields.imgRank[0x12] = this.imgRaLaserRank;
                fields.imgRank[0x13] = this.imgRaHandgunsRank;
                fields.imgRank[20] = this.imgRaHandgunRank;
                fields.imgRank[0x15] = this.imgRaCrossbowRank;
                fields.imgRank[0x16] = this.imgRaCardsRank;
                fields.imgRank[0x17] = this.imgRaMachinegunRank;
                fields.imgRank[0x1b] = this.imgRaRmagRank;
                fields.imgRank[0x18] = this.imgRaRodRank;
                fields.imgRank[0x19] = this.imgRaWandRank;
                fields.imgRank[0x1a] = this.imgRaTmagRank;
                fields.imgRank[0x1c] = this.imgRaShieldRank;
            }
            else if (ReferenceEquals(page, this.tabPageForce))
            {
                fields.imgWeap[1] = this.imgFoSword;
                fields.imgWeap[2] = this.imgFoKnuckles;
                fields.imgWeap[3] = this.imgFoSpear;
                fields.imgWeap[4] = this.imgFoDblSaber;
                fields.imgWeap[5] = this.imgFoAxe;
                fields.imgWeap[6] = this.imgFoSabers;
                fields.imgWeap[7] = this.imgFoDaggers;
                fields.imgWeap[8] = this.imgFoClaws;
                fields.imgWeap[9] = this.imgFoSaber;
                fields.imgWeap[10] = this.imgFoDagger;
                fields.imgWeap[11] = this.imgFoClaw;
                fields.imgWeap[12] = this.imgFoWhip;
                fields.imgWeap[13] = this.imgFoSlicer;
                fields.imgWeap[14] = this.imgFoRifle;
                fields.imgWeap[15] = this.imgFoShotgun;
                fields.imgWeap[0x10] = this.imgFoLongbow;
                fields.imgWeap[0x11] = this.imgFoGrenade;
                fields.imgWeap[0x12] = this.imgFoLaser;
                fields.imgWeap[0x13] = this.imgFoHandguns;
                fields.imgWeap[20] = this.imgFoHandgun;
                fields.imgWeap[0x15] = this.imgFoCrossbow;
                fields.imgWeap[0x16] = this.imgFoCards;
                fields.imgWeap[0x17] = this.imgFoMachinegun;
                fields.imgWeap[0x1b] = this.imgFoRmag;
                fields.imgWeap[0x18] = this.imgFoRod;
                fields.imgWeap[0x19] = this.imgFoWand;
                fields.imgWeap[0x1a] = this.imgFoTmag;
                fields.imgWeap[0x1c] = this.imgFoShield;
                fields.imgRank[1] = this.imgFoSwordRank;
                fields.imgRank[2] = this.imgFoKnucklesRank;
                fields.imgRank[3] = this.imgFoSpearRank;
                fields.imgRank[4] = this.imgFoDblSaberRank;
                fields.imgRank[5] = this.imgFoAxeRank;
                fields.imgRank[6] = this.imgFoSabersRank;
                fields.imgRank[7] = this.imgFoDaggersRank;
                fields.imgRank[8] = this.imgFoClawsRank;
                fields.imgRank[9] = this.imgFoSaberRank;
                fields.imgRank[10] = this.imgFoDaggerRank;
                fields.imgRank[11] = this.imgFoClawRank;
                fields.imgRank[12] = this.imgFoWhipRank;
                fields.imgRank[13] = this.imgFoSlicerRank;
                fields.imgRank[14] = this.imgFoRifleRank;
                fields.imgRank[15] = this.imgFoShotgunRank;
                fields.imgRank[0x10] = this.imgFoLongbowRank;
                fields.imgRank[0x11] = this.imgFoGrenadeRank;
                fields.imgRank[0x12] = this.imgFoLaserRank;
                fields.imgRank[0x13] = this.imgFoHandgunsRank;
                fields.imgRank[20] = this.imgFoHandgunRank;
                fields.imgRank[0x15] = this.imgFoCrossbowRank;
                fields.imgRank[0x16] = this.imgFoCardsRank;
                fields.imgRank[0x17] = this.imgFoMachinegunRank;
                fields.imgRank[0x1b] = this.imgFoRmagRank;
                fields.imgRank[0x18] = this.imgFoRodRank;
                fields.imgRank[0x19] = this.imgFoWandRank;
                fields.imgRank[0x1a] = this.imgFoTmagRank;
                fields.imgRank[0x1c] = this.imgFoShieldRank;
            }
            else if (ReferenceEquals(page, this.tabPageVanguard))
            {
                fields.imgWeap[1] = this.imgVaSword;
                fields.imgWeap[2] = this.imgVaKnuckles;
                fields.imgWeap[3] = this.imgVaSpear;
                fields.imgWeap[4] = this.imgVaDblSaber;
                fields.imgWeap[5] = this.imgVaAxe;
                fields.imgWeap[6] = this.imgVaSabers;
                fields.imgWeap[7] = this.imgVaDaggers;
                fields.imgWeap[8] = this.imgVaClaws;
                fields.imgWeap[9] = this.imgVaSaber;
                fields.imgWeap[10] = this.imgVaDagger;
                fields.imgWeap[11] = this.imgVaClaw;
                fields.imgWeap[12] = this.imgVaWhip;
                fields.imgWeap[13] = this.imgVaSlicer;
                fields.imgWeap[14] = this.imgVaRifle;
                fields.imgWeap[15] = this.imgVaShotgun;
                fields.imgWeap[0x10] = this.imgVaLongbow;
                fields.imgWeap[0x11] = this.imgVaGrenade;
                fields.imgWeap[0x12] = this.imgVaLaser;
                fields.imgWeap[0x13] = this.imgVaHandguns;
                fields.imgWeap[20] = this.imgVaHandgun;
                fields.imgWeap[0x15] = this.imgVaCrossbow;
                fields.imgWeap[0x16] = this.imgVaCards;
                fields.imgWeap[0x17] = this.imgVaMachinegun;
                fields.imgWeap[0x1b] = this.imgVaRmag;
                fields.imgWeap[0x18] = this.imgVaRod;
                fields.imgWeap[0x19] = this.imgVaWand;
                fields.imgWeap[0x1a] = this.imgVaTmag;
                fields.imgWeap[0x1c] = this.imgVaShield;
                fields.imgRank[1] = this.imgVaSwordRank;
                fields.imgRank[2] = this.imgVaKnucklesRank;
                fields.imgRank[3] = this.imgVaSpearRank;
                fields.imgRank[4] = this.imgVaDblSaberRank;
                fields.imgRank[5] = this.imgVaAxeRank;
                fields.imgRank[6] = this.imgVaSabersRank;
                fields.imgRank[7] = this.imgVaDaggersRank;
                fields.imgRank[8] = this.imgVaClawsRank;
                fields.imgRank[9] = this.imgVaSaberRank;
                fields.imgRank[10] = this.imgVaDaggerRank;
                fields.imgRank[11] = this.imgVaClawRank;
                fields.imgRank[12] = this.imgVaWhipRank;
                fields.imgRank[13] = this.imgVaSlicerRank;
                fields.imgRank[14] = this.imgVaRifleRank;
                fields.imgRank[15] = this.imgVaShotgunRank;
                fields.imgRank[0x10] = this.imgVaLongbowRank;
                fields.imgRank[0x11] = this.imgVaGrenadeRank;
                fields.imgRank[0x12] = this.imgVaLaserRank;
                fields.imgRank[0x13] = this.imgVaHandgunsRank;
                fields.imgRank[20] = this.imgVaHandgunRank;
                fields.imgRank[0x15] = this.imgVaCrossbowRank;
                fields.imgRank[0x16] = this.imgVaCardsRank;
                fields.imgRank[0x17] = this.imgVaMachinegunRank;
                fields.imgRank[0x1b] = this.imgVaRmagRank;
                fields.imgRank[0x18] = this.imgVaRodRank;
                fields.imgRank[0x19] = this.imgVaWandRank;
                fields.imgRank[0x1a] = this.imgVaTmagRank;
                fields.imgRank[0x1c] = this.imgVaShieldRank;
            }
            return fields;
        }

        private itemExtendType getWeaponExtendType(int extend_integer, weaponStyleType style, weaponType weapon)
        {
            itemExtendType extended = itemExtendType.not_extended;
            if (this.saveData.type != SaveType.PSP2I)
            {
                switch (extend_integer)
                {
                    case 0:
                        extended = itemExtendType.not_extended;
                        break;

                    case 1:
                        extended = itemExtendType.extended;
                        break;

                    case 2:
                        extended = itemExtendType.dlc_not_extended;
                        break;

                    case 3:
                        extended = itemExtendType.dlc_extended;
                        break;

                    default:
                        MessageBox.Show("Extend integer " + extend_integer + " is not recognised for psp2 extend type");
                        break;
                }
            }
            else
            {
                switch (extend_integer)
                {
                    case 0:
                        extended = itemExtendType.not_extended;
                        if ((weapon != weaponType.rmag) && ((style == weaponStyleType.Ranged_long) || (style == weaponStyleType.Ranged_short)))
                        {
                            extended = itemExtendType.not_extended_cs1;
                        }
                        break;

                    case 1:
                        extended = itemExtendType.extended;
                        if ((weapon != weaponType.rmag) && ((style == weaponStyleType.Ranged_long) || (style == weaponStyleType.Ranged_short)))
                        {
                            extended = itemExtendType.extended_cs1;
                        }
                        break;

                    case 2:
                        extended = itemExtendType.dlc_not_extended;
                        if ((weapon != weaponType.rmag) && ((style == weaponStyleType.Ranged_long) || (style == weaponStyleType.Ranged_short)))
                        {
                            extended = itemExtendType.not_extended_cs1;
                        }
                        break;

                    case 3:
                        extended = itemExtendType.dlc_extended;
                        if ((weapon != weaponType.rmag) && ((style == weaponStyleType.Ranged_long) || (style == weaponStyleType.Ranged_short)))
                        {
                            extended = itemExtendType.extended_cs1;
                        }
                        break;

                    case 4:
                        extended = itemExtendType.not_extended;
                        if ((weapon != weaponType.rmag) && ((style == weaponStyleType.Ranged_long) || (style == weaponStyleType.Ranged_short)))
                        {
                            extended = itemExtendType.not_extended_cs1;
                        }
                        break;

                    case 5:
                        extended = itemExtendType.extended;
                        if ((weapon != weaponType.rmag) && ((style == weaponStyleType.Ranged_long) || (style == weaponStyleType.Ranged_short)))
                        {
                            extended = itemExtendType.extended_cs1;
                        }
                        break;

                    case 6:
                        extended = itemExtendType.dlc_not_extended;
                        if ((style == weaponStyleType.Ranged_short) || (style == weaponStyleType.Ranged_long))
                        {
                            extended = itemExtendType.extended_cs2;
                        }
                        break;

                    case 8:
                        extended = itemExtendType.unknown;
                        if ((style == weaponStyleType.Ranged_short) || (style == weaponStyleType.Ranged_long))
                        {
                            extended = itemExtendType.not_extended_cs2;
                        }
                        break;

                    case 9:
                        if ((style == weaponStyleType.Ranged_short) || (style == weaponStyleType.Ranged_long))
                        {
                            extended = itemExtendType.extended_cs2;
                        }
                        break;

                    case 12:
                        extended = itemExtendType.unknown;
                        if ((style == weaponStyleType.Ranged_short) || (style == weaponStyleType.Ranged_long))
                        {
                            extended = itemExtendType.not_extended_cs2;
                        }
                        break;

                    case 13:
                        extended = itemExtendType.unknown;
                        if ((style == weaponStyleType.Ranged_short) || (style == weaponStyleType.Ranged_long))
                        {
                            extended = itemExtendType.extended_cs2;
                        }
                        break;

                    default:
                        MessageBox.Show("Extend integer " + extend_integer + " is not recognised for psp2i extend type");
                        break;
                }
            }
            return extended;
        }

        public Image getWeaponImageFromType(weaponType weapon)
        {
            switch (weapon)
            {
                case weaponType.nothing:
                    return null;

                case weaponType.sword:
                    return Resources.weapon_sword;

                case weaponType.knuckle:
                    return Resources.weapon_knuckles;

                case weaponType.spear:
                    return Resources.weapon_spear;

                case weaponType.double_saber:
                    return Resources.weapon_double_saber;

                case weaponType.axe:
                    return Resources.weapon_axe;

                case weaponType.sabers:
                    return Resources.weapon_sabers;

                case weaponType.daggers:
                    return Resources.weapon_daggers;

                case weaponType.claws:
                    return Resources.weapon_claws;

                case weaponType.saber:
                    return Resources.weapon_saber;

                case weaponType.dagger:
                    return Resources.weapon_dagger;

                case weaponType.claw:
                    return Resources.weapon_claw;

                case weaponType.whip:
                    return Resources.weapon_whip;

                case weaponType.slicer:
                    return Resources.weapon_slicer;

                case weaponType.rifle:
                    return Resources.weapon_rifle;

                case weaponType.shotgun:
                    return Resources.weapon_shotgun;

                case weaponType.longbow:
                    return Resources.weapon_longbow;

                case weaponType.grenade:
                    return Resources.weapon_grenade;

                case weaponType.laser:
                    return Resources.weapon_laser;

                case weaponType.handguns:
                    return Resources.weapon_handguns;

                case weaponType.handgun:
                    return Resources.weapon_handgun;

                case weaponType.crossbow:
                    return Resources.weapon_crossbow;

                case weaponType.card:
                    return Resources.weapon_card;

                case weaponType.machinegun:
                    return Resources.weapon_machinegun;

                case weaponType.rod:
                    return Resources.weapon_rod;

                case weaponType.wand:
                    return Resources.weapon_wand;

                case weaponType.tmag:
                    return Resources.weapon_tmag;

                case weaponType.rmag:
                    return Resources.weapon_rmag;

                case weaponType.shield:
                    return Resources.weapon_shield;

                case weaponType.armor:
                    return Resources.armor_icon;
            }
            return null;
        }

        public weaponManufacturerType getWeaponManufacturerFromHex(string hex)
        {
            hex = hex.Substring(0, 2);
            return (weaponManufacturerType) int.Parse(hex, NumberStyles.HexNumber);
        }

        public Image getWeaponManufacturerImage(weaponManufacturerType manufacturer)
        {
            switch (manufacturer)
            {
                case weaponManufacturerType.GRM:
                    return Resources.manlogo_GRM;

                case weaponManufacturerType.Yohmei:
                    return Resources.manlogo_Yohmei;

                case weaponManufacturerType.Tenora_Works:
                    return Resources.manlogo_Tenora;

                case weaponManufacturerType.Kubara:
                    return Resources.manlogo_Kubara;
            }
            MessageBox.Show("weapon manufacturer not supported: " + manufacturer);
            return null;
        }

        public weaponType getWeaponTypeFromHex(string hex)
        {
            hex = hex.Substring(4, 2);
            return (weaponType) int.Parse(hex, NumberStyles.HexNumber);
        }

        private int grindsToPowIncrease(weaponType weapon, int grinds, int rarity) => 
            0;

        public string hexToEffect(string hex)
        {
            switch (this.saveData.type)
            {
                case SaveType.PSP2:
                {
                    string key = hex;
                    if (key != null)
                    {
                        int num;
                        if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000e9-1 == null)
                        {
                            Dictionary<string, int> dictionary1 = new Dictionary<string, int>(11);
                            dictionary1.Add("00", 0);
                            dictionary1.Add("10", 1);
                            dictionary1.Add("20", 2);
                            dictionary1.Add("30", 3);
                            dictionary1.Add("40", 4);
                            dictionary1.Add("60", 5);
                            dictionary1.Add("70", 6);
                            dictionary1.Add("80", 7);
                            dictionary1.Add("90", 8);
                            dictionary1.Add("B0", 9);
                            dictionary1.Add("C0", 10);
                            <PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000e9-1 = dictionary1;
                        }
                        if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000e9-1.TryGetValue(key, out num))
                        {
                            switch (num)
                            {
                                case 0:
                                    return "";

                                case 1:
                                    return "Unseals";

                                case 2:
                                    return "ATK increase with kills";

                                case 3:
                                    return "Hearts";

                                case 4:
                                    return "+25 ACC for each equipped in party";

                                case 5:
                                    return "+40% Attribute (Max 60%). Glow during day";

                                case 6:
                                    return "+40% Attribute (Max 60%). Glow during night";

                                case 7:
                                    return "Ability Increase";

                                case 8:
                                    return "Hits one additional target";

                                case 9:
                                    return "Dark Meteor";

                                case 10:
                                    return "Prevent Enemy Attacks";

                                default:
                                    break;
                            }
                        }
                    }
                    return ("unk_" + hex);
                }
                case SaveType.PSP2I:
                {
                    string key = hex;
                    if (key != null)
                    {
                        int num2;
                        if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000e9-2 == null)
                        {
                            Dictionary<string, int> dictionary2 = new Dictionary<string, int>(13);
                            dictionary2.Add("00", 0);
                            dictionary2.Add("08", 1);
                            dictionary2.Add("10", 2);
                            dictionary2.Add("18", 3);
                            dictionary2.Add("1C", 4);
                            dictionary2.Add("20", 5);
                            dictionary2.Add("30", 6);
                            dictionary2.Add("38", 7);
                            dictionary2.Add("40", 8);
                            dictionary2.Add("48", 9);
                            dictionary2.Add("58", 10);
                            dictionary2.Add("60", 11);
                            dictionary2.Add("E0", 12);
                            <PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000e9-2 = dictionary2;
                        }
                        if (<PrivateImplementationDetails>{3E91610F-7D39-4E7C-8F4B-E7C65114B315}.$$method0x60000e9-2.TryGetValue(key, out num2))
                        {
                            switch (num2)
                            {
                                case 0:
                                    return "";

                                case 1:
                                    return "Unseals";

                                case 2:
                                    return "ATK increase with kills";

                                case 3:
                                    return "Hearts";

                                case 4:
                                    return "Hearts";

                                case 5:
                                    return "+25 ACC for each equipped in party";

                                case 6:
                                    return "+40% Attribute (Max 60%). Glow during day";

                                case 7:
                                    return "+40% Attribute (Max 60%). Glow during night";

                                case 8:
                                    return "Ability Increase";

                                case 9:
                                    return "Hits one additional target";

                                case 10:
                                    return "Dark Meteor";

                                case 11:
                                    return "Prevent Enemy Attacks";

                                case 12:
                                    return "+25 ATK/DEF for each equipped in party";

                                default:
                                    break;
                            }
                        }
                    }
                    return ("unk_" + hex);
                }
            }
            return ("hexToEffect invalid save type " + this.saveData.type);
        }

        private bool imageFloaterClosed() => 
            this.imageFloatShowing ? !this.allowImageFloatMove : true;

        private bool imageFloaterOpen() => 
            !this.imageFloatShowing ? !this.allowImageFloatMove : true;

        private void imgInventoryElement_Click(object sender, EventArgs e)
        {
            this.changeItemElement(this.tabPageInventory);
        }

        private void imgStorageElement_Click(object sender, EventArgs e)
        {
            this.changeItemElement(this.tabPageStorage);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(pspo2seForm));
            this.openFileDialog1 = new OpenFileDialog();
            this.openFileDialog2 = new OpenFileDialog();
            this.openFileDialog3 = new OpenFileDialog();
            this.tabArea = new TabControl();
            this.tabPageInfo = new TabPage();
            this.groupBox5 = new GroupBox();
            this.txtStoryTrueEnd = new Label();
            this.txtStoryComplete = new Label();
            this.groupBox7 = new GroupBox();
            this.panel1 = new Panel();
            this.picWeaponSlot01 = new PictureBox();
            this.picWeaponSlot06 = new PictureBox();
            this.picWeaponSlot02 = new PictureBox();
            this.picWeaponSlot05 = new PictureBox();
            this.picWeaponSlot03 = new PictureBox();
            this.picWeaponSlot04 = new PictureBox();
            this.groupBox4 = new GroupBox();
            this.txtCharacterName = new Label();
            this.lblLevel = new Label();
            this.txtLevel = new Label();
            this.txtLevelExpBar = new Label();
            this.label11 = new Label();
            this.groupBox3 = new GroupBox();
            this.txtExpNext = new Label();
            this.label9 = new Label();
            this.txtExp = new Label();
            this.txtSex = new Label();
            this.label21 = new Label();
            this.lblSex = new Label();
            this.txtRace = new Label();
            this.lblClass = new Label();
            this.lblTitle = new Label();
            this.txtTitle = new Label();
            this.label7 = new Label();
            this.lblType = new Label();
            this.txtCurType = new Label();
            this.txtPlaytime = new Label();
            this.tabTypeInfo = new TabPage();
            this.tabControlClasses = new TabControl();
            this.tabPageHunter = new TabPage();
            this.btnHuAbilitiesOpen = new Button();
            this.label20 = new Label();
            this.grpHuTypeExtend = new GroupBox();
            this.imgHuTmagRank = new PictureBox();
            this.imgHuMachinegunRank = new PictureBox();
            this.txtHuExpBar = new Label();
            this.txtHuExp = new Label();
            this.label34 = new Label();
            this.imgHuHandgunsRank = new PictureBox();
            this.label36 = new Label();
            this.imgHuShotgunRank = new PictureBox();
            this.imgHuClawRank = new PictureBox();
            this.imgHuDaggersRank = new PictureBox();
            this.imgHuSpearRank = new PictureBox();
            this.imgHuWandRank = new PictureBox();
            this.imgHuCardsRank = new PictureBox();
            this.imgHuLaserRank = new PictureBox();
            this.imgHuRifleRank = new PictureBox();
            this.imgHuDaggerRank = new PictureBox();
            this.imgHuSabersRank = new PictureBox();
            this.imgHuKnucklesRank = new PictureBox();
            this.imgHuShieldRank = new PictureBox();
            this.imgHuRmagRank = new PictureBox();
            this.imgHuHandgunRank = new PictureBox();
            this.imgHuLongbowRank = new PictureBox();
            this.imgHuWhipRank = new PictureBox();
            this.imgHuClawsRank = new PictureBox();
            this.imgHuDblSaberRank = new PictureBox();
            this.imgHuRodRank = new PictureBox();
            this.imgHuCrossbowRank = new PictureBox();
            this.imgHuGrenadeRank = new PictureBox();
            this.imgHuSlicerRank = new PictureBox();
            this.imgHuSaberRank = new PictureBox();
            this.imgHuAxeRank = new PictureBox();
            this.imgHuSwordRank = new PictureBox();
            this.imgHuRmag = new PictureBox();
            this.imgHuMachinegun = new PictureBox();
            this.imgHuCrossbow = new PictureBox();
            this.imgHuCards = new PictureBox();
            this.imgHuHandgun = new PictureBox();
            this.imgHuHandguns = new PictureBox();
            this.imgHuGrenade = new PictureBox();
            this.imgHuLaser = new PictureBox();
            this.imgHuLongbow = new PictureBox();
            this.imgHuShotgun = new PictureBox();
            this.imgHuSlicer = new PictureBox();
            this.imgHuRifle = new PictureBox();
            this.imgHuWhip = new PictureBox();
            this.imgHuClaw = new PictureBox();
            this.imgHuSaber = new PictureBox();
            this.imgHuDagger = new PictureBox();
            this.imgHuShield = new PictureBox();
            this.imgHuTmag = new PictureBox();
            this.imgHuRod = new PictureBox();
            this.imgHuWand = new PictureBox();
            this.imgHuClaws = new PictureBox();
            this.imgHuDaggers = new PictureBox();
            this.imgHuAxe = new PictureBox();
            this.imgHuSabers = new PictureBox();
            this.imgHuDblSaber = new PictureBox();
            this.imgHuKnuckles = new PictureBox();
            this.imgHuSpear = new PictureBox();
            this.imgHuSword = new PictureBox();
            this.pictureBox231 = new PictureBox();
            this.lblHuLevel = new Label();
            this.txtHuLevel = new Label();
            this.label39 = new Label();
            this.tabPageRanger = new TabPage();
            this.label10 = new Label();
            this.grpRaTypeExtend = new GroupBox();
            this.txtRaExp = new Label();
            this.imgRaTmagRank = new PictureBox();
            this.imgRaMachinegunRank = new PictureBox();
            this.txtRaExpBar = new Label();
            this.label22 = new Label();
            this.imgRaHandgunsRank = new PictureBox();
            this.label23 = new Label();
            this.imgRaShotgunRank = new PictureBox();
            this.imgRaClawRank = new PictureBox();
            this.imgRaDaggersRank = new PictureBox();
            this.imgRaSpearRank = new PictureBox();
            this.imgRaWandRank = new PictureBox();
            this.imgRaCardsRank = new PictureBox();
            this.imgRaLaserRank = new PictureBox();
            this.imgRaRifleRank = new PictureBox();
            this.imgRaDaggerRank = new PictureBox();
            this.imgRaSabersRank = new PictureBox();
            this.imgRaKnucklesRank = new PictureBox();
            this.imgRaShieldRank = new PictureBox();
            this.imgRaRmagRank = new PictureBox();
            this.imgRaHandgunRank = new PictureBox();
            this.imgRaLongbowRank = new PictureBox();
            this.imgRaWhipRank = new PictureBox();
            this.imgRaClawsRank = new PictureBox();
            this.imgRaDblSaberRank = new PictureBox();
            this.imgRaRodRank = new PictureBox();
            this.imgRaCrossbowRank = new PictureBox();
            this.imgRaGrenadeRank = new PictureBox();
            this.imgRaSlicerRank = new PictureBox();
            this.imgRaSaberRank = new PictureBox();
            this.imgRaAxeRank = new PictureBox();
            this.imgRaSwordRank = new PictureBox();
            this.imgRaRmag = new PictureBox();
            this.imgRaMachinegun = new PictureBox();
            this.imgRaCrossbow = new PictureBox();
            this.imgRaCards = new PictureBox();
            this.imgRaHandgun = new PictureBox();
            this.imgRaHandguns = new PictureBox();
            this.imgRaGrenade = new PictureBox();
            this.imgRaLaser = new PictureBox();
            this.imgRaLongbow = new PictureBox();
            this.imgRaShotgun = new PictureBox();
            this.imgRaSlicer = new PictureBox();
            this.imgRaRifle = new PictureBox();
            this.imgRaWhip = new PictureBox();
            this.imgRaClaw = new PictureBox();
            this.imgRaSaber = new PictureBox();
            this.imgRaDagger = new PictureBox();
            this.imgRaShield = new PictureBox();
            this.imgRaTmag = new PictureBox();
            this.imgRaRod = new PictureBox();
            this.imgRaWand = new PictureBox();
            this.imgRaClaws = new PictureBox();
            this.imgRaDaggers = new PictureBox();
            this.imgRaAxe = new PictureBox();
            this.imgRaSabers = new PictureBox();
            this.imgRaDblSaber = new PictureBox();
            this.imgRaKnuckles = new PictureBox();
            this.imgRaSpear = new PictureBox();
            this.imgRaSword = new PictureBox();
            this.pictureBox174 = new PictureBox();
            this.lblRaLevel = new Label();
            this.txtRaLevel = new Label();
            this.label35 = new Label();
            this.btnRaAbilitiesOpen = new Button();
            this.tabPageForce = new TabPage();
            this.label8 = new Label();
            this.grpFoTypeExtend = new GroupBox();
            this.txtFoExp = new Label();
            this.imgFoTmagRank = new PictureBox();
            this.imgFoMachinegunRank = new PictureBox();
            this.txtFoExpBar = new Label();
            this.label14 = new Label();
            this.imgFoHandgunsRank = new PictureBox();
            this.label15 = new Label();
            this.imgFoShotgunRank = new PictureBox();
            this.imgFoClawRank = new PictureBox();
            this.imgFoDaggersRank = new PictureBox();
            this.imgFoSpearRank = new PictureBox();
            this.imgFoWandRank = new PictureBox();
            this.imgFoCardsRank = new PictureBox();
            this.imgFoLaserRank = new PictureBox();
            this.imgFoRifleRank = new PictureBox();
            this.imgFoDaggerRank = new PictureBox();
            this.imgFoSabersRank = new PictureBox();
            this.imgFoKnucklesRank = new PictureBox();
            this.imgFoShieldRank = new PictureBox();
            this.imgFoRmagRank = new PictureBox();
            this.imgFoHandgunRank = new PictureBox();
            this.imgFoLongbowRank = new PictureBox();
            this.imgFoWhipRank = new PictureBox();
            this.imgFoClawsRank = new PictureBox();
            this.imgFoDblSaberRank = new PictureBox();
            this.imgFoRodRank = new PictureBox();
            this.imgFoCrossbowRank = new PictureBox();
            this.imgFoGrenadeRank = new PictureBox();
            this.imgFoSlicerRank = new PictureBox();
            this.imgFoSaberRank = new PictureBox();
            this.imgFoAxeRank = new PictureBox();
            this.imgFoSwordRank = new PictureBox();
            this.imgFoRmag = new PictureBox();
            this.imgFoMachinegun = new PictureBox();
            this.imgFoCrossbow = new PictureBox();
            this.imgFoCards = new PictureBox();
            this.imgFoHandgun = new PictureBox();
            this.imgFoHandguns = new PictureBox();
            this.imgFoGrenade = new PictureBox();
            this.imgFoLaser = new PictureBox();
            this.imgFoLongbow = new PictureBox();
            this.imgFoShotgun = new PictureBox();
            this.imgFoSlicer = new PictureBox();
            this.imgFoRifle = new PictureBox();
            this.imgFoWhip = new PictureBox();
            this.imgFoClaw = new PictureBox();
            this.imgFoSaber = new PictureBox();
            this.imgFoDagger = new PictureBox();
            this.imgFoShield = new PictureBox();
            this.imgFoTmag = new PictureBox();
            this.imgFoRod = new PictureBox();
            this.imgFoWand = new PictureBox();
            this.imgFoClaws = new PictureBox();
            this.imgFoDaggers = new PictureBox();
            this.imgFoAxe = new PictureBox();
            this.imgFoSabers = new PictureBox();
            this.imgFoDblSaber = new PictureBox();
            this.imgFoKnuckles = new PictureBox();
            this.imgFoSpear = new PictureBox();
            this.imgFoSword = new PictureBox();
            this.pictureBox117 = new PictureBox();
            this.lblFoLevel = new Label();
            this.txtFoLevel = new Label();
            this.btnFoAbilitiesOpen = new Button();
            this.tabPageVanguard = new TabPage();
            this.label27 = new Label();
            this.grpVaTypeExtend = new GroupBox();
            this.txtVaExp = new Label();
            this.imgVaTmagRank = new PictureBox();
            this.imgVaMachinegunRank = new PictureBox();
            this.txtVaExpBar = new Label();
            this.label28 = new Label();
            this.imgVaHandgunsRank = new PictureBox();
            this.label29 = new Label();
            this.imgVaShotgunRank = new PictureBox();
            this.imgVaClawRank = new PictureBox();
            this.imgVaDaggersRank = new PictureBox();
            this.imgVaSpearRank = new PictureBox();
            this.imgVaWandRank = new PictureBox();
            this.imgVaCardsRank = new PictureBox();
            this.imgVaLaserRank = new PictureBox();
            this.imgVaRifleRank = new PictureBox();
            this.imgVaDaggerRank = new PictureBox();
            this.imgVaSabersRank = new PictureBox();
            this.imgVaKnucklesRank = new PictureBox();
            this.imgVaShieldRank = new PictureBox();
            this.imgVaRmagRank = new PictureBox();
            this.imgVaHandgunRank = new PictureBox();
            this.imgVaLongbowRank = new PictureBox();
            this.imgVaWhipRank = new PictureBox();
            this.imgVaClawsRank = new PictureBox();
            this.imgVaDblSaberRank = new PictureBox();
            this.imgVaRodRank = new PictureBox();
            this.imgVaCrossbowRank = new PictureBox();
            this.imgVaGrenadeRank = new PictureBox();
            this.imgVaSlicerRank = new PictureBox();
            this.imgVaSaberRank = new PictureBox();
            this.imgVaAxeRank = new PictureBox();
            this.imgVaSwordRank = new PictureBox();
            this.imgVaRmag = new PictureBox();
            this.imgVaMachinegun = new PictureBox();
            this.imgVaCrossbow = new PictureBox();
            this.imgVaCards = new PictureBox();
            this.imgVaHandgun = new PictureBox();
            this.imgVaHandguns = new PictureBox();
            this.imgVaGrenade = new PictureBox();
            this.imgVaLaser = new PictureBox();
            this.imgVaLongbow = new PictureBox();
            this.imgVaShotgun = new PictureBox();
            this.imgVaSlicer = new PictureBox();
            this.imgVaRifle = new PictureBox();
            this.imgVaWhip = new PictureBox();
            this.imgVaClaw = new PictureBox();
            this.imgVaSaber = new PictureBox();
            this.imgVaDagger = new PictureBox();
            this.imgVaShield = new PictureBox();
            this.imgVaTmag = new PictureBox();
            this.imgVaRod = new PictureBox();
            this.imgVaWand = new PictureBox();
            this.imgVaClaws = new PictureBox();
            this.imgVaDaggers = new PictureBox();
            this.imgVaAxe = new PictureBox();
            this.imgVaSabers = new PictureBox();
            this.imgVaDblSaber = new PictureBox();
            this.imgVaKnuckles = new PictureBox();
            this.imgVaSpear = new PictureBox();
            this.imgVaSword = new PictureBox();
            this.pictureBox5 = new PictureBox();
            this.txtVaLevel = new Label();
            this.lblVaLevel = new Label();
            this.btnVaAbilitiesOpen = new Button();
            this.tabPageInventory = new TabPage();
            this.btnInventoryDelete = new Button();
            this.chkDeleteExportInventory = new CheckBox();
            this.btnInventoryDeposit = new Button();
            this.inventoryViewPages = new TabControl();
            this.tabInventory1 = new TabPage();
            this.tabInventory2 = new TabPage();
            this.tabInventory3 = new TabPage();
            this.tabInventory4 = new TabPage();
            this.tabInventory5 = new TabPage();
            this.tabInventory6 = new TabPage();
            this.btnInventoryImportSelected = new Button();
            this.btnInventoryExportSelected = new Button();
            this.btnInventoryImportAll = new Button();
            this.btnInventoryExportAll = new Button();
            this.txtInventoryMeseta = new Label();
            this.lblInventoryMeseta = new Label();
            this.grpInventoryItemDetails = new GroupBox();
            this.txtInventoryPercent = new Label();
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
            this.txtInventoryQty = new Label();
            this.imgInventoryItemIcon = new PictureBox();
            this.txtInventoryName = new Label();
            this.txtInventoryInfinityItemText = new Label();
            this.imgInventoryInfinityItem = new PictureBox();
            this.groupBox2 = new GroupBox();
            this.txtInventoryHex = new Label();
            this.pictureBox7 = new PictureBox();
            this.inventoryView = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.weaponWithRankImageList = new ImageList(this.components);
            this.tabPageStorage = new TabPage();
            this.btnStorageDelete = new Button();
            this.chkDeleteExportStorage = new CheckBox();
            this.btnStorageWithdraw = new Button();
            this.storageViewPages = new TabControl();
            this.tabStorage1 = new TabPage();
            this.tabStorage2 = new TabPage();
            this.tabStorage3 = new TabPage();
            this.tabStorage4 = new TabPage();
            this.tabStorage5 = new TabPage();
            this.tabStorage6 = new TabPage();
            this.storageView = new ListView();
            this.columnHeader3 = new ColumnHeader();
            this.btnStorageImportAll = new Button();
            this.btnStorageExportAll = new Button();
            this.btnStorageImportSelected = new Button();
            this.btnStorageExportSelected = new Button();
            this.txtStorageMeseta = new Label();
            this.lblStorageMeseta = new Label();
            this.grpStorageItemDetails = new GroupBox();
            this.txtStoragePercent = new Label();
            this.txtStorageLevel = new Label();
            this.txtStorageACC = new Label();
            this.txtStorageATK = new Label();
            this.txtStorageEffect = new Label();
            this.txtStorageSpecial = new Label();
            this.imgStorageRank = new PictureBox();
            this.imgStorageStar15 = new PictureBox();
            this.imgStorageStar14 = new PictureBox();
            this.imgStorageStar13 = new PictureBox();
            this.imgStorageStar12 = new PictureBox();
            this.imgStorageStar11 = new PictureBox();
            this.imgStorageStar10 = new PictureBox();
            this.imgStorageStar9 = new PictureBox();
            this.imgStorageStar8 = new PictureBox();
            this.imgStorageStar7 = new PictureBox();
            this.imgStorageStar6 = new PictureBox();
            this.imgStorageStar5 = new PictureBox();
            this.imgStorageStar4 = new PictureBox();
            this.imgStorageStar3 = new PictureBox();
            this.imgStorageStar2 = new PictureBox();
            this.imgStorageStar1 = new PictureBox();
            this.imgStorageStar0 = new PictureBox();
            this.imgStorageWeaponManufacturer = new PictureBox();
            this.txtStorageGrinds = new Label();
            this.txtStorageName_jp = new Label();
            this.imgStorageItemIcon = new PictureBox();
            this.txtStorageName = new Label();
            this.imgStorageElement = new PictureBox();
            this.txtStorageQty = new Label();
            this.txtStorageInfinityItemText = new Label();
            this.imgStorageInfinityItem = new PictureBox();
            this.groupBox1 = new GroupBox();
            this.txtStorageHex = new Label();
            this.pictureBox6 = new PictureBox();
            this.tabPageMissions = new TabPage();
            this.tabControlMissions = new TabControl();
            this.tabEp1Missions = new TabPage();
            this.txtAllowQuitMission = new Label();
            this.label47 = new Label();
            this.txtEp1Complete = new Label();
            this.label44 = new Label();
            this.txtStoryEmiliaPoints = new Label();
            this.txtMissionTactical = new Label();
            this.label2 = new Label();
            this.txtMissionMagashi = new Label();
            this.label13 = new Label();
            this.txtSkipEp1Start = new Label();
            this.label12 = new Label();
            this.txtMissionEp1 = new Label();
            this.label1 = new Label();
            this.tabEp2Missions = new TabPage();
            this.txtEp2Complete = new Label();
            this.label46 = new Label();
            this.txtStoryNagisaPoints = new Label();
            this.txtSkipEp2Start = new Label();
            this.lblSkipEp2Start = new Label();
            this.txtMissionEp2 = new Label();
            this.lblMissionEp2 = new Label();
            this.tabPageInfinityMission = new TabPage();
            this.btnImportMissions = new Button();
            this.btnExportMissions = new Button();
            this.btnModifyInfinityMission = new Button();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.grpInfinityMissionDetails = new GroupBox();
            this.txtInfEnemyLevel = new Label();
            this.txtInfNameJp = new Label();
            this.txtInfNameEn = new Label();
            this.txtInfMisEnemy2 = new Label();
            this.txtInfMisBoss = new Label();
            this.txtInfMisEnemy1 = new Label();
            this.tabPage2 = new TabPage();
            this.grpInfMisSpecial = new GroupBox();
            this.txtInfMisSpecial = new Label();
            this.tabPage3 = new TabPage();
            this.grpInfMisExtra = new GroupBox();
            this.txtInfMisSynthPoint = new Label();
            this.txtInfMisCreatedBy = new Label();
            this.btnDeleteInfinityMission = new Button();
            this.btnImportInfinityMission = new Button();
            this.btnExportInfinityMission = new Button();
            this.lstInfinityMissions = new ListView();
            this.columnHeader10 = new ColumnHeader();
            this.columnHeader11 = new ColumnHeader();
            this.txtInfinityMissionQty = new Label();
            this.label63 = new Label();
            this.tabPagePA = new TabPage();
            this.tabPA = new TabControl();
            this.tabPAMelee = new TabPage();
            this.groupBox6 = new GroupBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label16 = new Label();
            this.pictureBox2 = new PictureBox();
            this.pictureBox3 = new PictureBox();
            this.pictureBox4 = new PictureBox();
            this.pictureBox8 = new PictureBox();
            this.pictureBox9 = new PictureBox();
            this.pictureBox10 = new PictureBox();
            this.pictureBox11 = new PictureBox();
            this.pictureBox12 = new PictureBox();
            this.pictureBox13 = new PictureBox();
            this.pictureBox14 = new PictureBox();
            this.pictureBox15 = new PictureBox();
            this.pictureBox16 = new PictureBox();
            this.pictureBox17 = new PictureBox();
            this.pictureBox18 = new PictureBox();
            this.pictureBox19 = new PictureBox();
            this.pictureBox20 = new PictureBox();
            this.pictureBox21 = new PictureBox();
            this.pictureBox22 = new PictureBox();
            this.label18 = new Label();
            this.label19 = new Label();
            this.pictureBox23 = new PictureBox();
            this.label24 = new Label();
            this.label25 = new Label();
            this.pictureBox24 = new PictureBox();
            this.label26 = new Label();
            this.label30 = new Label();
            this.pictureBox25 = new PictureBox();
            this.txtPAHexMelee = new Label();
            this.lstPAMelee = new ListView();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader4 = new ColumnHeader();
            this.paImageList = new ImageList(this.components);
            this.tabPABullets = new TabPage();
            this.txtPAHexBullets = new Label();
            this.lstPABullets = new ListView();
            this.columnHeader5 = new ColumnHeader();
            this.columnHeader6 = new ColumnHeader();
            this.tabPATech = new TabPage();
            this.txtPAHexTech = new Label();
            this.lstPATechs = new ListView();
            this.columnHeader7 = new ColumnHeader();
            this.columnHeader8 = new ColumnHeader();
            this.tabPageRebirth = new TabPage();
            this.chkRebirthNoLevelDrop = new CheckBox();
            this.chkRebirthSpoof = new CheckBox();
            this.comboRebirthExtend = new ComboBox();
            this.btnRebirth = new Button();
            this.txtRebirthMaxType = new Label();
            this.label33 = new Label();
            this.lstRebirthRewards = new ListView();
            this.columnHeader9 = new ColumnHeader();
            this.label17 = new Label();
            this.label32 = new Label();
            this.txtRebirthCount = new Label();
            this.txtRebirthPoints = new Label();
            this.label48 = new Label();
            this.grpRebirth = new GroupBox();
            this.txtRebirthNextSTA = new Label();
            this.txtRebirthNextPP = new Label();
            this.txtRebirthNextHP = new Label();
            this.txtRebirthNextMND = new Label();
            this.txtRebirthNextTEC = new Label();
            this.txtRebirthNextEVA = new Label();
            this.txtRebirthNextACC = new Label();
            this.txtRebirthNextDEF = new Label();
            this.txtRebirthNextATK = new Label();
            this.txtRebirthBpSTA = new Label();
            this.txtRebirthBpPP = new Label();
            this.txtRebirthBpHP = new Label();
            this.txtRebirthBpMND = new Label();
            this.txtRebirthBpTEC = new Label();
            this.txtRebirthBpEVA = new Label();
            this.txtRebirthBpACC = new Label();
            this.txtRebirthBpDEF = new Label();
            this.txtRebirthBpATK = new Label();
            this.label41 = new Label();
            this.label40 = new Label();
            this.label37 = new Label();
            this.numRebirthSTA = new NumericUpDown();
            this.txtRebirthSTA = new Label();
            this.label50 = new Label();
            this.numRebirthPP = new NumericUpDown();
            this.numRebirthHP = new NumericUpDown();
            this.txtRebirthPP = new Label();
            this.label55 = new Label();
            this.label56 = new Label();
            this.txtRebirthHP = new Label();
            this.numRebirthMND = new NumericUpDown();
            this.numRebirthTEC = new NumericUpDown();
            this.numRebirthEVA = new NumericUpDown();
            this.numRebirthACC = new NumericUpDown();
            this.numRebirthDEF = new NumericUpDown();
            this.numRebirthATK = new NumericUpDown();
            this.txtRebirthMND = new Label();
            this.label53 = new Label();
            this.txtRebirthTEC = new Label();
            this.label38 = new Label();
            this.txtRebirthEVA = new Label();
            this.txtRebirthACC = new Label();
            this.label42 = new Label();
            this.label43 = new Label();
            this.txtRebirthDEF = new Label();
            this.label45 = new Label();
            this.label49 = new Label();
            this.txtRebirthATK = new Label();
            this.btnUndoAll = new Button();
            this.btnSaveAs = new Button();
            this.sexImageList = new ImageList(this.components);
            this.armourImageList = new ImageList(this.components);
            this.itemImageList = new ImageList(this.components);
            this.clothesImageList = new ImageList(this.components);
            this.decoImageList = new ImageList(this.components);
            this.menuStrip = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.openToolStripMenuItem = new ToolStripMenuItem();
            this.saveToolStripMenuItem = new ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.updateToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.databasesToolStripMenuItem = new ToolStripMenuItem();
            this.itemDatabasesToolStripMenuItem = new ToolStripMenuItem();
            this.weaponDatabaseToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.refreshToolStripMenuItem = new ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            this.imagesToolStripMenuItem = new ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem1 = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.aboutToolStripMenuItem = new ToolStripMenuItem();
            this.versionInfoToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip1 = new StatusStrip();
            this.toolStripProgressBar = new ToolStripProgressBar();
            this.toolStripStatusLabel = new ToolStripStatusLabel();
            this.txtFooterText = new Label();
            this.lstSaveSlotView = new ListView();
            this.slotViewHeader_name = new ColumnHeader();
            this.slotViewHeader_level = new ColumnHeader();
            this.slotViewHeader_class = new ColumnHeader();
            this.slotViewHeader_type = new ColumnHeader();
            this.slotViewHeader_complete = new ColumnHeader();
            this.txtFileSize = new Label();
            this.btnExportCharacter = new Button();
            this.txtSlotnumloaded = new Label();
            this.btnImportCharacter = new Button();
            this.txtFileLoc = new TextBox();
            this.btnBrowse = new Button();
            this.grpImageFloater = new GroupBox();
            this.imgFloater = new PictureBox();
            this.panelImageFloater = new Panel();
            this.btnSave = new Button();
            this.imageListWeaponElements = new ImageList(this.components);
            this.printPreviewDialog1 = new PrintPreviewDialog();
            this.imgSave = new PictureBox();
            this.imgLogo = new PictureBox();
            this.pictureBox1 = new PictureBox();
            this.imgGameLogo = new PictureBox();
            this.tabArea.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.picWeaponSlot01).BeginInit();
            ((ISupportInitialize) this.picWeaponSlot06).BeginInit();
            ((ISupportInitialize) this.picWeaponSlot02).BeginInit();
            ((ISupportInitialize) this.picWeaponSlot05).BeginInit();
            ((ISupportInitialize) this.picWeaponSlot03).BeginInit();
            ((ISupportInitialize) this.picWeaponSlot04).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabTypeInfo.SuspendLayout();
            this.tabControlClasses.SuspendLayout();
            this.tabPageHunter.SuspendLayout();
            this.grpHuTypeExtend.SuspendLayout();
            ((ISupportInitialize) this.imgHuTmagRank).BeginInit();
            ((ISupportInitialize) this.imgHuMachinegunRank).BeginInit();
            ((ISupportInitialize) this.imgHuHandgunsRank).BeginInit();
            ((ISupportInitialize) this.imgHuShotgunRank).BeginInit();
            ((ISupportInitialize) this.imgHuClawRank).BeginInit();
            ((ISupportInitialize) this.imgHuDaggersRank).BeginInit();
            ((ISupportInitialize) this.imgHuSpearRank).BeginInit();
            ((ISupportInitialize) this.imgHuWandRank).BeginInit();
            ((ISupportInitialize) this.imgHuCardsRank).BeginInit();
            ((ISupportInitialize) this.imgHuLaserRank).BeginInit();
            ((ISupportInitialize) this.imgHuRifleRank).BeginInit();
            ((ISupportInitialize) this.imgHuDaggerRank).BeginInit();
            ((ISupportInitialize) this.imgHuSabersRank).BeginInit();
            ((ISupportInitialize) this.imgHuKnucklesRank).BeginInit();
            ((ISupportInitialize) this.imgHuShieldRank).BeginInit();
            ((ISupportInitialize) this.imgHuRmagRank).BeginInit();
            ((ISupportInitialize) this.imgHuHandgunRank).BeginInit();
            ((ISupportInitialize) this.imgHuLongbowRank).BeginInit();
            ((ISupportInitialize) this.imgHuWhipRank).BeginInit();
            ((ISupportInitialize) this.imgHuClawsRank).BeginInit();
            ((ISupportInitialize) this.imgHuDblSaberRank).BeginInit();
            ((ISupportInitialize) this.imgHuRodRank).BeginInit();
            ((ISupportInitialize) this.imgHuCrossbowRank).BeginInit();
            ((ISupportInitialize) this.imgHuGrenadeRank).BeginInit();
            ((ISupportInitialize) this.imgHuSlicerRank).BeginInit();
            ((ISupportInitialize) this.imgHuSaberRank).BeginInit();
            ((ISupportInitialize) this.imgHuAxeRank).BeginInit();
            ((ISupportInitialize) this.imgHuSwordRank).BeginInit();
            ((ISupportInitialize) this.imgHuRmag).BeginInit();
            ((ISupportInitialize) this.imgHuMachinegun).BeginInit();
            ((ISupportInitialize) this.imgHuCrossbow).BeginInit();
            ((ISupportInitialize) this.imgHuCards).BeginInit();
            ((ISupportInitialize) this.imgHuHandgun).BeginInit();
            ((ISupportInitialize) this.imgHuHandguns).BeginInit();
            ((ISupportInitialize) this.imgHuGrenade).BeginInit();
            ((ISupportInitialize) this.imgHuLaser).BeginInit();
            ((ISupportInitialize) this.imgHuLongbow).BeginInit();
            ((ISupportInitialize) this.imgHuShotgun).BeginInit();
            ((ISupportInitialize) this.imgHuSlicer).BeginInit();
            ((ISupportInitialize) this.imgHuRifle).BeginInit();
            ((ISupportInitialize) this.imgHuWhip).BeginInit();
            ((ISupportInitialize) this.imgHuClaw).BeginInit();
            ((ISupportInitialize) this.imgHuSaber).BeginInit();
            ((ISupportInitialize) this.imgHuDagger).BeginInit();
            ((ISupportInitialize) this.imgHuShield).BeginInit();
            ((ISupportInitialize) this.imgHuTmag).BeginInit();
            ((ISupportInitialize) this.imgHuRod).BeginInit();
            ((ISupportInitialize) this.imgHuWand).BeginInit();
            ((ISupportInitialize) this.imgHuClaws).BeginInit();
            ((ISupportInitialize) this.imgHuDaggers).BeginInit();
            ((ISupportInitialize) this.imgHuAxe).BeginInit();
            ((ISupportInitialize) this.imgHuSabers).BeginInit();
            ((ISupportInitialize) this.imgHuDblSaber).BeginInit();
            ((ISupportInitialize) this.imgHuKnuckles).BeginInit();
            ((ISupportInitialize) this.imgHuSpear).BeginInit();
            ((ISupportInitialize) this.imgHuSword).BeginInit();
            ((ISupportInitialize) this.pictureBox231).BeginInit();
            this.tabPageRanger.SuspendLayout();
            this.grpRaTypeExtend.SuspendLayout();
            ((ISupportInitialize) this.imgRaTmagRank).BeginInit();
            ((ISupportInitialize) this.imgRaMachinegunRank).BeginInit();
            ((ISupportInitialize) this.imgRaHandgunsRank).BeginInit();
            ((ISupportInitialize) this.imgRaShotgunRank).BeginInit();
            ((ISupportInitialize) this.imgRaClawRank).BeginInit();
            ((ISupportInitialize) this.imgRaDaggersRank).BeginInit();
            ((ISupportInitialize) this.imgRaSpearRank).BeginInit();
            ((ISupportInitialize) this.imgRaWandRank).BeginInit();
            ((ISupportInitialize) this.imgRaCardsRank).BeginInit();
            ((ISupportInitialize) this.imgRaLaserRank).BeginInit();
            ((ISupportInitialize) this.imgRaRifleRank).BeginInit();
            ((ISupportInitialize) this.imgRaDaggerRank).BeginInit();
            ((ISupportInitialize) this.imgRaSabersRank).BeginInit();
            ((ISupportInitialize) this.imgRaKnucklesRank).BeginInit();
            ((ISupportInitialize) this.imgRaShieldRank).BeginInit();
            ((ISupportInitialize) this.imgRaRmagRank).BeginInit();
            ((ISupportInitialize) this.imgRaHandgunRank).BeginInit();
            ((ISupportInitialize) this.imgRaLongbowRank).BeginInit();
            ((ISupportInitialize) this.imgRaWhipRank).BeginInit();
            ((ISupportInitialize) this.imgRaClawsRank).BeginInit();
            ((ISupportInitialize) this.imgRaDblSaberRank).BeginInit();
            ((ISupportInitialize) this.imgRaRodRank).BeginInit();
            ((ISupportInitialize) this.imgRaCrossbowRank).BeginInit();
            ((ISupportInitialize) this.imgRaGrenadeRank).BeginInit();
            ((ISupportInitialize) this.imgRaSlicerRank).BeginInit();
            ((ISupportInitialize) this.imgRaSaberRank).BeginInit();
            ((ISupportInitialize) this.imgRaAxeRank).BeginInit();
            ((ISupportInitialize) this.imgRaSwordRank).BeginInit();
            ((ISupportInitialize) this.imgRaRmag).BeginInit();
            ((ISupportInitialize) this.imgRaMachinegun).BeginInit();
            ((ISupportInitialize) this.imgRaCrossbow).BeginInit();
            ((ISupportInitialize) this.imgRaCards).BeginInit();
            ((ISupportInitialize) this.imgRaHandgun).BeginInit();
            ((ISupportInitialize) this.imgRaHandguns).BeginInit();
            ((ISupportInitialize) this.imgRaGrenade).BeginInit();
            ((ISupportInitialize) this.imgRaLaser).BeginInit();
            ((ISupportInitialize) this.imgRaLongbow).BeginInit();
            ((ISupportInitialize) this.imgRaShotgun).BeginInit();
            ((ISupportInitialize) this.imgRaSlicer).BeginInit();
            ((ISupportInitialize) this.imgRaRifle).BeginInit();
            ((ISupportInitialize) this.imgRaWhip).BeginInit();
            ((ISupportInitialize) this.imgRaClaw).BeginInit();
            ((ISupportInitialize) this.imgRaSaber).BeginInit();
            ((ISupportInitialize) this.imgRaDagger).BeginInit();
            ((ISupportInitialize) this.imgRaShield).BeginInit();
            ((ISupportInitialize) this.imgRaTmag).BeginInit();
            ((ISupportInitialize) this.imgRaRod).BeginInit();
            ((ISupportInitialize) this.imgRaWand).BeginInit();
            ((ISupportInitialize) this.imgRaClaws).BeginInit();
            ((ISupportInitialize) this.imgRaDaggers).BeginInit();
            ((ISupportInitialize) this.imgRaAxe).BeginInit();
            ((ISupportInitialize) this.imgRaSabers).BeginInit();
            ((ISupportInitialize) this.imgRaDblSaber).BeginInit();
            ((ISupportInitialize) this.imgRaKnuckles).BeginInit();
            ((ISupportInitialize) this.imgRaSpear).BeginInit();
            ((ISupportInitialize) this.imgRaSword).BeginInit();
            ((ISupportInitialize) this.pictureBox174).BeginInit();
            this.tabPageForce.SuspendLayout();
            this.grpFoTypeExtend.SuspendLayout();
            ((ISupportInitialize) this.imgFoTmagRank).BeginInit();
            ((ISupportInitialize) this.imgFoMachinegunRank).BeginInit();
            ((ISupportInitialize) this.imgFoHandgunsRank).BeginInit();
            ((ISupportInitialize) this.imgFoShotgunRank).BeginInit();
            ((ISupportInitialize) this.imgFoClawRank).BeginInit();
            ((ISupportInitialize) this.imgFoDaggersRank).BeginInit();
            ((ISupportInitialize) this.imgFoSpearRank).BeginInit();
            ((ISupportInitialize) this.imgFoWandRank).BeginInit();
            ((ISupportInitialize) this.imgFoCardsRank).BeginInit();
            ((ISupportInitialize) this.imgFoLaserRank).BeginInit();
            ((ISupportInitialize) this.imgFoRifleRank).BeginInit();
            ((ISupportInitialize) this.imgFoDaggerRank).BeginInit();
            ((ISupportInitialize) this.imgFoSabersRank).BeginInit();
            ((ISupportInitialize) this.imgFoKnucklesRank).BeginInit();
            ((ISupportInitialize) this.imgFoShieldRank).BeginInit();
            ((ISupportInitialize) this.imgFoRmagRank).BeginInit();
            ((ISupportInitialize) this.imgFoHandgunRank).BeginInit();
            ((ISupportInitialize) this.imgFoLongbowRank).BeginInit();
            ((ISupportInitialize) this.imgFoWhipRank).BeginInit();
            ((ISupportInitialize) this.imgFoClawsRank).BeginInit();
            ((ISupportInitialize) this.imgFoDblSaberRank).BeginInit();
            ((ISupportInitialize) this.imgFoRodRank).BeginInit();
            ((ISupportInitialize) this.imgFoCrossbowRank).BeginInit();
            ((ISupportInitialize) this.imgFoGrenadeRank).BeginInit();
            ((ISupportInitialize) this.imgFoSlicerRank).BeginInit();
            ((ISupportInitialize) this.imgFoSaberRank).BeginInit();
            ((ISupportInitialize) this.imgFoAxeRank).BeginInit();
            ((ISupportInitialize) this.imgFoSwordRank).BeginInit();
            ((ISupportInitialize) this.imgFoRmag).BeginInit();
            ((ISupportInitialize) this.imgFoMachinegun).BeginInit();
            ((ISupportInitialize) this.imgFoCrossbow).BeginInit();
            ((ISupportInitialize) this.imgFoCards).BeginInit();
            ((ISupportInitialize) this.imgFoHandgun).BeginInit();
            ((ISupportInitialize) this.imgFoHandguns).BeginInit();
            ((ISupportInitialize) this.imgFoGrenade).BeginInit();
            ((ISupportInitialize) this.imgFoLaser).BeginInit();
            ((ISupportInitialize) this.imgFoLongbow).BeginInit();
            ((ISupportInitialize) this.imgFoShotgun).BeginInit();
            ((ISupportInitialize) this.imgFoSlicer).BeginInit();
            ((ISupportInitialize) this.imgFoRifle).BeginInit();
            ((ISupportInitialize) this.imgFoWhip).BeginInit();
            ((ISupportInitialize) this.imgFoClaw).BeginInit();
            ((ISupportInitialize) this.imgFoSaber).BeginInit();
            ((ISupportInitialize) this.imgFoDagger).BeginInit();
            ((ISupportInitialize) this.imgFoShield).BeginInit();
            ((ISupportInitialize) this.imgFoTmag).BeginInit();
            ((ISupportInitialize) this.imgFoRod).BeginInit();
            ((ISupportInitialize) this.imgFoWand).BeginInit();
            ((ISupportInitialize) this.imgFoClaws).BeginInit();
            ((ISupportInitialize) this.imgFoDaggers).BeginInit();
            ((ISupportInitialize) this.imgFoAxe).BeginInit();
            ((ISupportInitialize) this.imgFoSabers).BeginInit();
            ((ISupportInitialize) this.imgFoDblSaber).BeginInit();
            ((ISupportInitialize) this.imgFoKnuckles).BeginInit();
            ((ISupportInitialize) this.imgFoSpear).BeginInit();
            ((ISupportInitialize) this.imgFoSword).BeginInit();
            ((ISupportInitialize) this.pictureBox117).BeginInit();
            this.tabPageVanguard.SuspendLayout();
            this.grpVaTypeExtend.SuspendLayout();
            ((ISupportInitialize) this.imgVaTmagRank).BeginInit();
            ((ISupportInitialize) this.imgVaMachinegunRank).BeginInit();
            ((ISupportInitialize) this.imgVaHandgunsRank).BeginInit();
            ((ISupportInitialize) this.imgVaShotgunRank).BeginInit();
            ((ISupportInitialize) this.imgVaClawRank).BeginInit();
            ((ISupportInitialize) this.imgVaDaggersRank).BeginInit();
            ((ISupportInitialize) this.imgVaSpearRank).BeginInit();
            ((ISupportInitialize) this.imgVaWandRank).BeginInit();
            ((ISupportInitialize) this.imgVaCardsRank).BeginInit();
            ((ISupportInitialize) this.imgVaLaserRank).BeginInit();
            ((ISupportInitialize) this.imgVaRifleRank).BeginInit();
            ((ISupportInitialize) this.imgVaDaggerRank).BeginInit();
            ((ISupportInitialize) this.imgVaSabersRank).BeginInit();
            ((ISupportInitialize) this.imgVaKnucklesRank).BeginInit();
            ((ISupportInitialize) this.imgVaShieldRank).BeginInit();
            ((ISupportInitialize) this.imgVaRmagRank).BeginInit();
            ((ISupportInitialize) this.imgVaHandgunRank).BeginInit();
            ((ISupportInitialize) this.imgVaLongbowRank).BeginInit();
            ((ISupportInitialize) this.imgVaWhipRank).BeginInit();
            ((ISupportInitialize) this.imgVaClawsRank).BeginInit();
            ((ISupportInitialize) this.imgVaDblSaberRank).BeginInit();
            ((ISupportInitialize) this.imgVaRodRank).BeginInit();
            ((ISupportInitialize) this.imgVaCrossbowRank).BeginInit();
            ((ISupportInitialize) this.imgVaGrenadeRank).BeginInit();
            ((ISupportInitialize) this.imgVaSlicerRank).BeginInit();
            ((ISupportInitialize) this.imgVaSaberRank).BeginInit();
            ((ISupportInitialize) this.imgVaAxeRank).BeginInit();
            ((ISupportInitialize) this.imgVaSwordRank).BeginInit();
            ((ISupportInitialize) this.imgVaRmag).BeginInit();
            ((ISupportInitialize) this.imgVaMachinegun).BeginInit();
            ((ISupportInitialize) this.imgVaCrossbow).BeginInit();
            ((ISupportInitialize) this.imgVaCards).BeginInit();
            ((ISupportInitialize) this.imgVaHandgun).BeginInit();
            ((ISupportInitialize) this.imgVaHandguns).BeginInit();
            ((ISupportInitialize) this.imgVaGrenade).BeginInit();
            ((ISupportInitialize) this.imgVaLaser).BeginInit();
            ((ISupportInitialize) this.imgVaLongbow).BeginInit();
            ((ISupportInitialize) this.imgVaShotgun).BeginInit();
            ((ISupportInitialize) this.imgVaSlicer).BeginInit();
            ((ISupportInitialize) this.imgVaRifle).BeginInit();
            ((ISupportInitialize) this.imgVaWhip).BeginInit();
            ((ISupportInitialize) this.imgVaClaw).BeginInit();
            ((ISupportInitialize) this.imgVaSaber).BeginInit();
            ((ISupportInitialize) this.imgVaDagger).BeginInit();
            ((ISupportInitialize) this.imgVaShield).BeginInit();
            ((ISupportInitialize) this.imgVaTmag).BeginInit();
            ((ISupportInitialize) this.imgVaRod).BeginInit();
            ((ISupportInitialize) this.imgVaWand).BeginInit();
            ((ISupportInitialize) this.imgVaClaws).BeginInit();
            ((ISupportInitialize) this.imgVaDaggers).BeginInit();
            ((ISupportInitialize) this.imgVaAxe).BeginInit();
            ((ISupportInitialize) this.imgVaSabers).BeginInit();
            ((ISupportInitialize) this.imgVaDblSaber).BeginInit();
            ((ISupportInitialize) this.imgVaKnuckles).BeginInit();
            ((ISupportInitialize) this.imgVaSpear).BeginInit();
            ((ISupportInitialize) this.imgVaSword).BeginInit();
            ((ISupportInitialize) this.pictureBox5).BeginInit();
            this.tabPageInventory.SuspendLayout();
            this.inventoryViewPages.SuspendLayout();
            this.grpInventoryItemDetails.SuspendLayout();
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
            ((ISupportInitialize) this.pictureBox7).BeginInit();
            this.tabPageStorage.SuspendLayout();
            this.storageViewPages.SuspendLayout();
            this.grpStorageItemDetails.SuspendLayout();
            ((ISupportInitialize) this.imgStorageRank).BeginInit();
            ((ISupportInitialize) this.imgStorageStar15).BeginInit();
            ((ISupportInitialize) this.imgStorageStar14).BeginInit();
            ((ISupportInitialize) this.imgStorageStar13).BeginInit();
            ((ISupportInitialize) this.imgStorageStar12).BeginInit();
            ((ISupportInitialize) this.imgStorageStar11).BeginInit();
            ((ISupportInitialize) this.imgStorageStar10).BeginInit();
            ((ISupportInitialize) this.imgStorageStar9).BeginInit();
            ((ISupportInitialize) this.imgStorageStar8).BeginInit();
            ((ISupportInitialize) this.imgStorageStar7).BeginInit();
            ((ISupportInitialize) this.imgStorageStar6).BeginInit();
            ((ISupportInitialize) this.imgStorageStar5).BeginInit();
            ((ISupportInitialize) this.imgStorageStar4).BeginInit();
            ((ISupportInitialize) this.imgStorageStar3).BeginInit();
            ((ISupportInitialize) this.imgStorageStar2).BeginInit();
            ((ISupportInitialize) this.imgStorageStar1).BeginInit();
            ((ISupportInitialize) this.imgStorageStar0).BeginInit();
            ((ISupportInitialize) this.imgStorageWeaponManufacturer).BeginInit();
            ((ISupportInitialize) this.imgStorageItemIcon).BeginInit();
            ((ISupportInitialize) this.imgStorageElement).BeginInit();
            ((ISupportInitialize) this.imgStorageInfinityItem).BeginInit();
            ((ISupportInitialize) this.pictureBox6).BeginInit();
            this.tabPageMissions.SuspendLayout();
            this.tabControlMissions.SuspendLayout();
            this.tabEp1Missions.SuspendLayout();
            this.tabEp2Missions.SuspendLayout();
            this.tabPageInfinityMission.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpInfinityMissionDetails.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpInfMisSpecial.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpInfMisExtra.SuspendLayout();
            this.tabPagePA.SuspendLayout();
            this.tabPA.SuspendLayout();
            this.tabPAMelee.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.pictureBox3).BeginInit();
            ((ISupportInitialize) this.pictureBox4).BeginInit();
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
            ((ISupportInitialize) this.pictureBox19).BeginInit();
            ((ISupportInitialize) this.pictureBox20).BeginInit();
            ((ISupportInitialize) this.pictureBox21).BeginInit();
            ((ISupportInitialize) this.pictureBox22).BeginInit();
            ((ISupportInitialize) this.pictureBox23).BeginInit();
            ((ISupportInitialize) this.pictureBox24).BeginInit();
            ((ISupportInitialize) this.pictureBox25).BeginInit();
            this.tabPABullets.SuspendLayout();
            this.tabPATech.SuspendLayout();
            this.tabPageRebirth.SuspendLayout();
            this.grpRebirth.SuspendLayout();
            this.numRebirthSTA.BeginInit();
            this.numRebirthPP.BeginInit();
            this.numRebirthHP.BeginInit();
            this.numRebirthMND.BeginInit();
            this.numRebirthTEC.BeginInit();
            this.numRebirthEVA.BeginInit();
            this.numRebirthACC.BeginInit();
            this.numRebirthDEF.BeginInit();
            this.numRebirthATK.BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpImageFloater.SuspendLayout();
            ((ISupportInitialize) this.imgFloater).BeginInit();
            ((ISupportInitialize) this.imgSave).BeginInit();
            ((ISupportInitialize) this.imgLogo).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            ((ISupportInitialize) this.imgGameLogo).BeginInit();
            base.SuspendLayout();
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog3.FileName = "openFileDialog3";
            this.tabArea.Controls.Add(this.tabPageInfo);
            this.tabArea.Controls.Add(this.tabTypeInfo);
            this.tabArea.Controls.Add(this.tabPageInventory);
            this.tabArea.Controls.Add(this.tabPageStorage);
            this.tabArea.Controls.Add(this.tabPageMissions);
            this.tabArea.Controls.Add(this.tabPagePA);
            this.tabArea.Controls.Add(this.tabPageRebirth);
            this.tabArea.Cursor = Cursors.Default;
            this.tabArea.Enabled = false;
            this.tabArea.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabArea.Location = new Point(4, 0xe9);
            this.tabArea.Name = "tabArea";
            this.tabArea.SelectedIndex = 0;
            this.tabArea.Size = new Size(0x27d, 0xf9);
            this.tabArea.TabIndex = 0x12;
            this.tabArea.SelectedIndexChanged += new EventHandler(this.tabArea_SelectedIndexChanged);
            this.tabPageInfo.BackColor = SystemColors.Window;
            this.tabPageInfo.BackgroundImageLayout = ImageLayout.Center;
            this.tabPageInfo.Controls.Add(this.groupBox5);
            this.tabPageInfo.Controls.Add(this.groupBox7);
            this.tabPageInfo.Controls.Add(this.groupBox4);
            this.tabPageInfo.Controls.Add(this.groupBox3);
            this.tabPageInfo.Cursor = Cursors.Default;
            this.tabPageInfo.ForeColor = Color.Black;
            this.tabPageInfo.Location = new Point(4, 0x16);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new Padding(3);
            this.tabPageInfo.Size = new Size(0x275, 0xdf);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "General";
            this.groupBox5.Controls.Add(this.txtStoryTrueEnd);
            this.groupBox5.Controls.Add(this.txtStoryComplete);
            this.groupBox5.ForeColor = Color.White;
            this.groupBox5.Location = new Point(0x102, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(360, 0x47);
            this.groupBox5.TabIndex = 0x49;
            this.groupBox5.TabStop = false;
            this.txtStoryTrueEnd.AutoSize = true;
            this.txtStoryTrueEnd.BackColor = Color.Transparent;
            this.txtStoryTrueEnd.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtStoryTrueEnd.ForeColor = SystemColors.ActiveCaptionText;
            this.txtStoryTrueEnd.Location = new Point(15, 0x29);
            this.txtStoryTrueEnd.Name = "txtStoryTrueEnd";
            this.txtStoryTrueEnd.Size = new Size(0x83, 13);
            this.txtStoryTrueEnd.TabIndex = 0x4b;
            this.txtStoryTrueEnd.Text = "True Ending Achieved";
            this.txtStoryTrueEnd.Visible = false;
            this.txtStoryComplete.AutoSize = true;
            this.txtStoryComplete.BackColor = Color.Transparent;
            this.txtStoryComplete.Font = new Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtStoryComplete.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.txtStoryComplete.Location = new Point(15, 0x13);
            this.txtStoryComplete.Name = "txtStoryComplete";
            this.txtStoryComplete.Size = new Size(0x6f, 14);
            this.txtStoryComplete.TabIndex = 0x49;
            this.txtStoryComplete.Text = "Game Complete";
            this.txtStoryComplete.Visible = false;
            this.groupBox7.Controls.Add(this.panel1);
            this.groupBox7.Location = new Point(0x102, 70);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(0x6d, 0x4b);
            this.groupBox7.TabIndex = 0x51;
            this.groupBox7.TabStop = false;
            this.panel1.BackColor = Color.Black;
            this.panel1.Controls.Add(this.picWeaponSlot01);
            this.panel1.Controls.Add(this.picWeaponSlot06);
            this.panel1.Controls.Add(this.picWeaponSlot02);
            this.panel1.Controls.Add(this.picWeaponSlot05);
            this.panel1.Controls.Add(this.picWeaponSlot03);
            this.panel1.Controls.Add(this.picWeaponSlot04);
            this.panel1.Location = new Point(11, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x59, 0x29);
            this.panel1.TabIndex = 80;
            this.picWeaponSlot01.BackColor = Color.Black;
            this.picWeaponSlot01.Location = new Point(7, 7);
            this.picWeaponSlot01.Name = "picWeaponSlot01";
            this.picWeaponSlot01.Size = new Size(0x17, 12);
            this.picWeaponSlot01.TabIndex = 0x4a;
            this.picWeaponSlot01.TabStop = false;
            this.picWeaponSlot06.BackColor = Color.Black;
            this.picWeaponSlot06.Location = new Point(0x39, 0x15);
            this.picWeaponSlot06.Name = "picWeaponSlot06";
            this.picWeaponSlot06.Size = new Size(0x17, 12);
            this.picWeaponSlot06.TabIndex = 0x4f;
            this.picWeaponSlot06.TabStop = false;
            this.picWeaponSlot02.BackColor = Color.Black;
            this.picWeaponSlot02.Location = new Point(0x20, 7);
            this.picWeaponSlot02.Name = "picWeaponSlot02";
            this.picWeaponSlot02.Size = new Size(0x17, 12);
            this.picWeaponSlot02.TabIndex = 0x4b;
            this.picWeaponSlot02.TabStop = false;
            this.picWeaponSlot05.BackColor = Color.Black;
            this.picWeaponSlot05.Location = new Point(0x20, 0x15);
            this.picWeaponSlot05.Name = "picWeaponSlot05";
            this.picWeaponSlot05.Size = new Size(0x17, 12);
            this.picWeaponSlot05.TabIndex = 0x4e;
            this.picWeaponSlot05.TabStop = false;
            this.picWeaponSlot03.BackColor = Color.Black;
            this.picWeaponSlot03.Location = new Point(0x39, 7);
            this.picWeaponSlot03.Name = "picWeaponSlot03";
            this.picWeaponSlot03.Size = new Size(0x17, 12);
            this.picWeaponSlot03.TabIndex = 0x4c;
            this.picWeaponSlot03.TabStop = false;
            this.picWeaponSlot04.BackColor = Color.Black;
            this.picWeaponSlot04.Location = new Point(7, 0x15);
            this.picWeaponSlot04.Name = "picWeaponSlot04";
            this.picWeaponSlot04.Size = new Size(0x17, 12);
            this.picWeaponSlot04.TabIndex = 0x4d;
            this.picWeaponSlot04.TabStop = false;
            this.groupBox4.Controls.Add(this.txtCharacterName);
            this.groupBox4.Controls.Add(this.lblLevel);
            this.groupBox4.Controls.Add(this.txtLevel);
            this.groupBox4.Controls.Add(this.txtLevelExpBar);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new Point(9, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xf3, 0x47);
            this.groupBox4.TabIndex = 0x43;
            this.groupBox4.TabStop = false;
            this.txtCharacterName.BackColor = Color.Transparent;
            this.txtCharacterName.Cursor = Cursors.Hand;
            this.txtCharacterName.Font = new Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtCharacterName.ForeColor = SystemColors.ActiveCaptionText;
            this.txtCharacterName.Location = new Point(14, 0x11);
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new Size(0xdf, 0x10);
            this.txtCharacterName.TabIndex = 0x12;
            this.txtCharacterName.Text = "No Save File Loaded";
            this.txtCharacterName.Click += new EventHandler(this.txtCharacterName_Click);
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = Color.Transparent;
            this.lblLevel.Cursor = Cursors.Hand;
            this.lblLevel.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblLevel.ForeColor = SystemColors.ActiveCaptionText;
            this.lblLevel.Location = new Point(14, 0x20);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new Size(40, 14);
            this.lblLevel.TabIndex = 20;
            this.lblLevel.Text = "Level";
            this.lblLevel.Click += new EventHandler(this.txtLevel_Click);
            this.txtLevel.BackColor = Color.Transparent;
            this.txtLevel.Cursor = Cursors.Hand;
            this.txtLevel.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtLevel.ForeColor = SystemColors.ActiveCaptionText;
            this.txtLevel.Location = new Point(0x34, 0x20);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new Size(60, 14);
            this.txtLevel.TabIndex = 0x15;
            this.txtLevel.Text = "0";
            this.txtLevel.Click += new EventHandler(this.txtLevel_Click);
            this.txtLevelExpBar.BackColor = Color.FromArgb(0xbb, 0x68, 0xb8);
            this.txtLevelExpBar.Location = new Point(0x13, 0x3b);
            this.txtLevelExpBar.Name = "txtLevelExpBar";
            this.txtLevelExpBar.Size = new Size(0, 4);
            this.txtLevelExpBar.TabIndex = 0x26;
            this.label11.BackColor = SystemColors.Control;
            this.label11.BorderStyle = BorderStyle.FixedSingle;
            this.label11.Location = new Point(0x12, 0x3a);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0xca, 6);
            this.label11.TabIndex = 0x29;
            this.groupBox3.Controls.Add(this.txtExpNext);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtExp);
            this.groupBox3.Controls.Add(this.txtSex);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.lblSex);
            this.groupBox3.Controls.Add(this.txtRace);
            this.groupBox3.Controls.Add(this.lblClass);
            this.groupBox3.Controls.Add(this.lblTitle);
            this.groupBox3.Controls.Add(this.txtTitle);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblType);
            this.groupBox3.Controls.Add(this.txtCurType);
            this.groupBox3.Controls.Add(this.txtPlaytime);
            this.groupBox3.Location = new Point(9, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0xf3, 0x8f);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.txtExpNext.AutoSize = true;
            this.txtExpNext.BackColor = Color.Transparent;
            this.txtExpNext.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtExpNext.ForeColor = SystemColors.ActiveCaptionText;
            this.txtExpNext.Location = new Point(0x56, 0x74);
            this.txtExpNext.Name = "txtExpNext";
            this.txtExpNext.Size = new Size(12, 13);
            this.txtExpNext.TabIndex = 0x42;
            this.txtExpNext.Text = "-";
            this.label9.BackColor = Color.Transparent;
            this.label9.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.ForeColor = SystemColors.ActiveCaptionText;
            this.label9.Location = new Point(2, 0x74);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x52, 14);
            this.label9.TabIndex = 0x41;
            this.label9.Text = "Exp To Next";
            this.label9.TextAlign = ContentAlignment.TopRight;
            this.txtExp.AutoSize = true;
            this.txtExp.BackColor = Color.Transparent;
            this.txtExp.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtExp.ForeColor = SystemColors.ActiveCaptionText;
            this.txtExp.Location = new Point(0x56, 0x66);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new Size(12, 13);
            this.txtExp.TabIndex = 60;
            this.txtExp.Text = "-";
            this.txtSex.AutoSize = true;
            this.txtSex.BackColor = Color.Transparent;
            this.txtSex.Cursor = Cursors.Hand;
            this.txtSex.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtSex.ForeColor = SystemColors.ActiveCaptionText;
            this.txtSex.Location = new Point(0x56, 80);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new Size(12, 13);
            this.txtSex.TabIndex = 0x40;
            this.txtSex.Text = "-";
            this.txtSex.Click += new EventHandler(this.txtSex_Click);
            this.label21.BackColor = Color.Transparent;
            this.label21.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label21.ForeColor = SystemColors.ActiveCaptionText;
            this.label21.Location = new Point(0x17, 0x66);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x3d, 14);
            this.label21.TabIndex = 0x3b;
            this.label21.Text = "Total Exp";
            this.label21.TextAlign = ContentAlignment.TopRight;
            this.lblSex.AutoSize = true;
            this.lblSex.BackColor = Color.Transparent;
            this.lblSex.Cursor = Cursors.Hand;
            this.lblSex.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblSex.ForeColor = SystemColors.ActiveCaptionText;
            this.lblSex.Location = new Point(0x36, 80);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new Size(0x1d, 13);
            this.lblSex.TabIndex = 0x3f;
            this.lblSex.Text = "Sex";
            this.lblSex.Click += new EventHandler(this.txtSex_Click);
            this.txtRace.AutoSize = true;
            this.txtRace.BackColor = Color.Transparent;
            this.txtRace.Cursor = Cursors.Hand;
            this.txtRace.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRace.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRace.Location = new Point(0x56, 0x42);
            this.txtRace.Name = "txtRace";
            this.txtRace.Size = new Size(12, 13);
            this.txtRace.TabIndex = 0x3e;
            this.txtRace.Text = "-";
            this.txtRace.Click += new EventHandler(this.txtClass_Click);
            this.lblClass.AutoSize = true;
            this.lblClass.BackColor = Color.Transparent;
            this.lblClass.Cursor = Cursors.Hand;
            this.lblClass.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblClass.ForeColor = SystemColors.ActiveCaptionText;
            this.lblClass.Location = new Point(0x30, 0x42);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new Size(0x23, 13);
            this.lblClass.TabIndex = 0x3d;
            this.lblClass.Text = "Race";
            this.lblClass.Click += new EventHandler(this.txtClass_Click);
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Cursor = Cursors.Hand;
            this.lblTitle.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblTitle.ForeColor = SystemColors.ActiveCaptionText;
            this.lblTitle.Location = new Point(0x35, 0x26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(0x1f, 13);
            this.lblTitle.TabIndex = 0x35;
            this.lblTitle.Text = "Title";
            this.lblTitle.Click += new EventHandler(this.txtTitle_Click);
            this.txtTitle.AutoSize = true;
            this.txtTitle.BackColor = Color.Transparent;
            this.txtTitle.Cursor = Cursors.Hand;
            this.txtTitle.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtTitle.ForeColor = SystemColors.ActiveCaptionText;
            this.txtTitle.Location = new Point(0x56, 0x26);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new Size(12, 13);
            this.txtTitle.TabIndex = 0x36;
            this.txtTitle.Text = "-";
            this.txtTitle.Click += new EventHandler(this.txtTitle_Click);
            this.label7.AutoSize = true;
            this.label7.BackColor = Color.Transparent;
            this.label7.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.ForeColor = SystemColors.ActiveCaptionText;
            this.label7.Location = new Point(0x15, 15);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x3f, 13);
            this.label7.TabIndex = 0x37;
            this.label7.Text = "Play Time";
            this.lblType.AutoSize = true;
            this.lblType.BackColor = Color.Transparent;
            this.lblType.Cursor = Cursors.Hand;
            this.lblType.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblType.ForeColor = SystemColors.ActiveCaptionText;
            this.lblType.Location = new Point(0x2d, 0x34);
            this.lblType.Name = "lblType";
            this.lblType.Size = new Size(0x26, 13);
            this.lblType.TabIndex = 0x39;
            this.lblType.Text = "Class";
            this.lblType.Click += new EventHandler(this.txtCurType_Click);
            this.txtCurType.AutoSize = true;
            this.txtCurType.BackColor = Color.Transparent;
            this.txtCurType.Cursor = Cursors.Hand;
            this.txtCurType.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtCurType.ForeColor = SystemColors.ActiveCaptionText;
            this.txtCurType.Location = new Point(0x56, 0x34);
            this.txtCurType.Name = "txtCurType";
            this.txtCurType.Size = new Size(12, 13);
            this.txtCurType.TabIndex = 0x3a;
            this.txtCurType.Text = "-";
            this.txtCurType.Click += new EventHandler(this.txtCurType_Click);
            this.txtPlaytime.AutoSize = true;
            this.txtPlaytime.BackColor = Color.Transparent;
            this.txtPlaytime.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtPlaytime.ForeColor = SystemColors.ActiveCaptionText;
            this.txtPlaytime.Location = new Point(0x56, 15);
            this.txtPlaytime.Name = "txtPlaytime";
            this.txtPlaytime.Size = new Size(0x3b, 13);
            this.txtPlaytime.TabIndex = 0x38;
            this.txtPlaytime.Text = "00:00:00";
            this.tabTypeInfo.Controls.Add(this.tabControlClasses);
            this.tabTypeInfo.Location = new Point(4, 0x16);
            this.tabTypeInfo.Name = "tabTypeInfo";
            this.tabTypeInfo.Padding = new Padding(3);
            this.tabTypeInfo.Size = new Size(0x275, 0xdf);
            this.tabTypeInfo.TabIndex = 9;
            this.tabTypeInfo.Text = "Type";
            this.tabTypeInfo.UseVisualStyleBackColor = true;
            this.tabControlClasses.Controls.Add(this.tabPageHunter);
            this.tabControlClasses.Controls.Add(this.tabPageRanger);
            this.tabControlClasses.Controls.Add(this.tabPageForce);
            this.tabControlClasses.Controls.Add(this.tabPageVanguard);
            this.tabControlClasses.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabControlClasses.Location = new Point(5, 3);
            this.tabControlClasses.Name = "tabControlClasses";
            this.tabControlClasses.SelectedIndex = 0;
            this.tabControlClasses.Size = new Size(0x26a, 0xd9);
            this.tabControlClasses.TabIndex = 0;
            this.tabPageHunter.Controls.Add(this.btnHuAbilitiesOpen);
            this.tabPageHunter.Controls.Add(this.label20);
            this.tabPageHunter.Controls.Add(this.grpHuTypeExtend);
            this.tabPageHunter.Controls.Add(this.lblHuLevel);
            this.tabPageHunter.Controls.Add(this.txtHuLevel);
            this.tabPageHunter.Controls.Add(this.label39);
            this.tabPageHunter.Font = new Font("Verdana", 8.25f);
            this.tabPageHunter.Location = new Point(4, 0x15);
            this.tabPageHunter.Name = "tabPageHunter";
            this.tabPageHunter.Padding = new Padding(3);
            this.tabPageHunter.Size = new Size(610, 0xc0);
            this.tabPageHunter.TabIndex = 0;
            this.tabPageHunter.Text = "Hunter (0)";
            this.tabPageHunter.UseVisualStyleBackColor = true;
            this.btnHuAbilitiesOpen.Cursor = Cursors.Hand;
            this.btnHuAbilitiesOpen.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnHuAbilitiesOpen.Location = new Point(0x21f, 8);
            this.btnHuAbilitiesOpen.Name = "btnHuAbilitiesOpen";
            this.btnHuAbilitiesOpen.Size = new Size(0x3d, 0x15);
            this.btnHuAbilitiesOpen.TabIndex = 0x86;
            this.btnHuAbilitiesOpen.Text = "Abilities";
            this.btnHuAbilitiesOpen.UseVisualStyleBackColor = true;
            this.btnHuAbilitiesOpen.Click += new EventHandler(this.btnHuAbilitiesOpen_Click);
            this.label20.AutoSize = true;
            this.label20.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label20.Location = new Point(11, 13);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x3a, 0x10);
            this.label20.TabIndex = 0x85;
            this.label20.Text = "Hunter";
            this.grpHuTypeExtend.Controls.Add(this.imgHuTmagRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuMachinegunRank);
            this.grpHuTypeExtend.Controls.Add(this.txtHuExpBar);
            this.grpHuTypeExtend.Controls.Add(this.txtHuExp);
            this.grpHuTypeExtend.Controls.Add(this.label34);
            this.grpHuTypeExtend.Controls.Add(this.imgHuHandgunsRank);
            this.grpHuTypeExtend.Controls.Add(this.label36);
            this.grpHuTypeExtend.Controls.Add(this.imgHuShotgunRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuClawRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuDaggersRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSpearRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuWandRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuCardsRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuLaserRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuRifleRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuDaggerRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSabersRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuKnucklesRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuShieldRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuRmagRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuHandgunRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuLongbowRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuWhipRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuClawsRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuDblSaberRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuRodRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuCrossbowRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuGrenadeRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSlicerRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSaberRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuAxeRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSwordRank);
            this.grpHuTypeExtend.Controls.Add(this.imgHuRmag);
            this.grpHuTypeExtend.Controls.Add(this.imgHuMachinegun);
            this.grpHuTypeExtend.Controls.Add(this.imgHuCrossbow);
            this.grpHuTypeExtend.Controls.Add(this.imgHuCards);
            this.grpHuTypeExtend.Controls.Add(this.imgHuHandgun);
            this.grpHuTypeExtend.Controls.Add(this.imgHuHandguns);
            this.grpHuTypeExtend.Controls.Add(this.imgHuGrenade);
            this.grpHuTypeExtend.Controls.Add(this.imgHuLaser);
            this.grpHuTypeExtend.Controls.Add(this.imgHuLongbow);
            this.grpHuTypeExtend.Controls.Add(this.imgHuShotgun);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSlicer);
            this.grpHuTypeExtend.Controls.Add(this.imgHuRifle);
            this.grpHuTypeExtend.Controls.Add(this.imgHuWhip);
            this.grpHuTypeExtend.Controls.Add(this.imgHuClaw);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSaber);
            this.grpHuTypeExtend.Controls.Add(this.imgHuDagger);
            this.grpHuTypeExtend.Controls.Add(this.imgHuShield);
            this.grpHuTypeExtend.Controls.Add(this.imgHuTmag);
            this.grpHuTypeExtend.Controls.Add(this.imgHuRod);
            this.grpHuTypeExtend.Controls.Add(this.imgHuWand);
            this.grpHuTypeExtend.Controls.Add(this.imgHuClaws);
            this.grpHuTypeExtend.Controls.Add(this.imgHuDaggers);
            this.grpHuTypeExtend.Controls.Add(this.imgHuAxe);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSabers);
            this.grpHuTypeExtend.Controls.Add(this.imgHuDblSaber);
            this.grpHuTypeExtend.Controls.Add(this.imgHuKnuckles);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSpear);
            this.grpHuTypeExtend.Controls.Add(this.imgHuSword);
            this.grpHuTypeExtend.Controls.Add(this.pictureBox231);
            this.grpHuTypeExtend.Location = new Point(10, 0x3a);
            this.grpHuTypeExtend.Name = "grpHuTypeExtend";
            this.grpHuTypeExtend.Size = new Size(0x130, 0x77);
            this.grpHuTypeExtend.TabIndex = 0x84;
            this.grpHuTypeExtend.TabStop = false;
            this.grpHuTypeExtend.Text = "Type Extend 0/0";
            this.imgHuTmagRank.Image = Resources.rank_C;
            this.imgHuTmagRank.Location = new Point(80, 0x5f);
            this.imgHuTmagRank.Name = "imgHuTmagRank";
            this.imgHuTmagRank.Size = new Size(10, 10);
            this.imgHuTmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuTmagRank.TabIndex = 0x6b;
            this.imgHuTmagRank.TabStop = false;
            this.imgHuMachinegunRank.Image = Resources.rank_C;
            this.imgHuMachinegunRank.Location = new Point(80, 0x53);
            this.imgHuMachinegunRank.Name = "imgHuMachinegunRank";
            this.imgHuMachinegunRank.Size = new Size(10, 10);
            this.imgHuMachinegunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuMachinegunRank.TabIndex = 0x6a;
            this.imgHuMachinegunRank.TabStop = false;
            this.txtHuExpBar.BackColor = Color.Red;
            this.txtHuExpBar.Location = new Point(0xc3, 0x17);
            this.txtHuExpBar.Name = "txtHuExpBar";
            this.txtHuExpBar.Size = new Size(0x57, 8);
            this.txtHuExpBar.TabIndex = 0x31;
            this.txtHuExp.BackColor = Color.Transparent;
            this.txtHuExp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtHuExp.Location = new Point(0xc2, 0x24);
            this.txtHuExp.Name = "txtHuExp";
            this.txtHuExp.Size = new Size(0x66, 0x45);
            this.txtHuExp.TabIndex = 0x31;
            this.txtHuExp.TextAlign = ContentAlignment.TopRight;
            this.label34.AutoSize = true;
            this.label34.Location = new Point(0x9f, 20);
            this.label34.Name = "label34";
            this.label34.Size = new Size(0x1d, 13);
            this.label34.TabIndex = 0x30;
            this.label34.Text = "EXP";
            this.imgHuHandgunsRank.Image = Resources.rank_C;
            this.imgHuHandgunsRank.Location = new Point(80, 0x47);
            this.imgHuHandgunsRank.Name = "imgHuHandgunsRank";
            this.imgHuHandgunsRank.Size = new Size(10, 10);
            this.imgHuHandgunsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuHandgunsRank.TabIndex = 0x69;
            this.imgHuHandgunsRank.TabStop = false;
            this.label36.BackColor = Color.Gainsboro;
            this.label36.BorderStyle = BorderStyle.FixedSingle;
            this.label36.Location = new Point(0xc2, 0x16);
            this.label36.Name = "label36";
            this.label36.Size = new Size(0x66, 10);
            this.label36.TabIndex = 50;
            this.imgHuShotgunRank.Image = Resources.rank_C;
            this.imgHuShotgunRank.Location = new Point(80, 0x3b);
            this.imgHuShotgunRank.Name = "imgHuShotgunRank";
            this.imgHuShotgunRank.Size = new Size(10, 10);
            this.imgHuShotgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuShotgunRank.TabIndex = 0x68;
            this.imgHuShotgunRank.TabStop = false;
            this.imgHuClawRank.Image = Resources.rank_C;
            this.imgHuClawRank.Location = new Point(80, 0x2f);
            this.imgHuClawRank.Name = "imgHuClawRank";
            this.imgHuClawRank.Size = new Size(10, 10);
            this.imgHuClawRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuClawRank.TabIndex = 0x67;
            this.imgHuClawRank.TabStop = false;
            this.imgHuDaggersRank.Image = Resources.rank_C;
            this.imgHuDaggersRank.Location = new Point(80, 0x23);
            this.imgHuDaggersRank.Name = "imgHuDaggersRank";
            this.imgHuDaggersRank.Size = new Size(10, 10);
            this.imgHuDaggersRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuDaggersRank.TabIndex = 0x66;
            this.imgHuDaggersRank.TabStop = false;
            this.imgHuSpearRank.Image = Resources.rank_C;
            this.imgHuSpearRank.Location = new Point(80, 0x17);
            this.imgHuSpearRank.Name = "imgHuSpearRank";
            this.imgHuSpearRank.Size = new Size(10, 10);
            this.imgHuSpearRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSpearRank.TabIndex = 0x65;
            this.imgHuSpearRank.TabStop = false;
            this.imgHuWandRank.Image = Resources.rank_B;
            this.imgHuWandRank.Location = new Point(0x2c, 0x5f);
            this.imgHuWandRank.Name = "imgHuWandRank";
            this.imgHuWandRank.Size = new Size(10, 10);
            this.imgHuWandRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuWandRank.TabIndex = 100;
            this.imgHuWandRank.TabStop = false;
            this.imgHuCardsRank.Image = Resources.rank_B;
            this.imgHuCardsRank.Location = new Point(0x2c, 0x53);
            this.imgHuCardsRank.Name = "imgHuCardsRank";
            this.imgHuCardsRank.Size = new Size(10, 10);
            this.imgHuCardsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuCardsRank.TabIndex = 0x63;
            this.imgHuCardsRank.TabStop = false;
            this.imgHuLaserRank.Image = Resources.rank_B;
            this.imgHuLaserRank.Location = new Point(0x2c, 0x47);
            this.imgHuLaserRank.Name = "imgHuLaserRank";
            this.imgHuLaserRank.Size = new Size(10, 10);
            this.imgHuLaserRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuLaserRank.TabIndex = 0x62;
            this.imgHuLaserRank.TabStop = false;
            this.imgHuRifleRank.Image = Resources.rank_B;
            this.imgHuRifleRank.Location = new Point(0x2c, 0x3b);
            this.imgHuRifleRank.Name = "imgHuRifleRank";
            this.imgHuRifleRank.Size = new Size(10, 10);
            this.imgHuRifleRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuRifleRank.TabIndex = 0x61;
            this.imgHuRifleRank.TabStop = false;
            this.imgHuDaggerRank.Image = Resources.rank_B;
            this.imgHuDaggerRank.Location = new Point(0x2c, 0x2f);
            this.imgHuDaggerRank.Name = "imgHuDaggerRank";
            this.imgHuDaggerRank.Size = new Size(10, 10);
            this.imgHuDaggerRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuDaggerRank.TabIndex = 0x60;
            this.imgHuDaggerRank.TabStop = false;
            this.imgHuSabersRank.Image = Resources.rank_B;
            this.imgHuSabersRank.Location = new Point(0x2c, 0x23);
            this.imgHuSabersRank.Name = "imgHuSabersRank";
            this.imgHuSabersRank.Size = new Size(10, 10);
            this.imgHuSabersRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSabersRank.TabIndex = 0x5f;
            this.imgHuSabersRank.TabStop = false;
            this.imgHuKnucklesRank.Image = Resources.rank_B;
            this.imgHuKnucklesRank.Location = new Point(0x2c, 0x17);
            this.imgHuKnucklesRank.Name = "imgHuKnucklesRank";
            this.imgHuKnucklesRank.Size = new Size(10, 10);
            this.imgHuKnucklesRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuKnucklesRank.TabIndex = 0x5e;
            this.imgHuKnucklesRank.TabStop = false;
            this.imgHuShieldRank.Image = Resources.rank_B;
            this.imgHuShieldRank.Location = new Point(0x74, 0x5f);
            this.imgHuShieldRank.Name = "imgHuShieldRank";
            this.imgHuShieldRank.Size = new Size(10, 10);
            this.imgHuShieldRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuShieldRank.TabIndex = 0x5d;
            this.imgHuShieldRank.TabStop = false;
            this.imgHuRmagRank.Image = Resources.rank_B;
            this.imgHuRmagRank.Location = new Point(0x74, 0x53);
            this.imgHuRmagRank.Name = "imgHuRmagRank";
            this.imgHuRmagRank.Size = new Size(10, 10);
            this.imgHuRmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuRmagRank.TabIndex = 0x5c;
            this.imgHuRmagRank.TabStop = false;
            this.imgHuHandgunRank.Image = Resources.rank_B;
            this.imgHuHandgunRank.Location = new Point(0x74, 0x47);
            this.imgHuHandgunRank.Name = "imgHuHandgunRank";
            this.imgHuHandgunRank.Size = new Size(10, 10);
            this.imgHuHandgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuHandgunRank.TabIndex = 0x5b;
            this.imgHuHandgunRank.TabStop = false;
            this.imgHuLongbowRank.Image = Resources.rank_B;
            this.imgHuLongbowRank.Location = new Point(0x74, 0x3b);
            this.imgHuLongbowRank.Name = "imgHuLongbowRank";
            this.imgHuLongbowRank.Size = new Size(10, 10);
            this.imgHuLongbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuLongbowRank.TabIndex = 90;
            this.imgHuLongbowRank.TabStop = false;
            this.imgHuWhipRank.Image = Resources.rank_B;
            this.imgHuWhipRank.Location = new Point(0x74, 0x2f);
            this.imgHuWhipRank.Name = "imgHuWhipRank";
            this.imgHuWhipRank.Size = new Size(10, 10);
            this.imgHuWhipRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuWhipRank.TabIndex = 0x59;
            this.imgHuWhipRank.TabStop = false;
            this.imgHuClawsRank.Image = Resources.rank_B;
            this.imgHuClawsRank.Location = new Point(0x74, 0x23);
            this.imgHuClawsRank.Name = "imgHuClawsRank";
            this.imgHuClawsRank.Size = new Size(10, 10);
            this.imgHuClawsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuClawsRank.TabIndex = 0x58;
            this.imgHuClawsRank.TabStop = false;
            this.imgHuDblSaberRank.Image = Resources.rank_B;
            this.imgHuDblSaberRank.Location = new Point(0x74, 0x17);
            this.imgHuDblSaberRank.Name = "imgHuDblSaberRank";
            this.imgHuDblSaberRank.Size = new Size(10, 10);
            this.imgHuDblSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuDblSaberRank.TabIndex = 0x57;
            this.imgHuDblSaberRank.TabStop = false;
            this.imgHuRodRank.Image = Resources.rank_C;
            this.imgHuRodRank.Location = new Point(8, 0x5f);
            this.imgHuRodRank.Name = "imgHuRodRank";
            this.imgHuRodRank.Size = new Size(10, 10);
            this.imgHuRodRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuRodRank.TabIndex = 0x56;
            this.imgHuRodRank.TabStop = false;
            this.imgHuCrossbowRank.Image = Resources.rank_C;
            this.imgHuCrossbowRank.Location = new Point(8, 0x53);
            this.imgHuCrossbowRank.Name = "imgHuCrossbowRank";
            this.imgHuCrossbowRank.Size = new Size(10, 10);
            this.imgHuCrossbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuCrossbowRank.TabIndex = 0x55;
            this.imgHuCrossbowRank.TabStop = false;
            this.imgHuGrenadeRank.Image = Resources.rank_C;
            this.imgHuGrenadeRank.Location = new Point(8, 0x47);
            this.imgHuGrenadeRank.Name = "imgHuGrenadeRank";
            this.imgHuGrenadeRank.Size = new Size(10, 10);
            this.imgHuGrenadeRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuGrenadeRank.TabIndex = 0x54;
            this.imgHuGrenadeRank.TabStop = false;
            this.imgHuSlicerRank.Image = Resources.rank_C;
            this.imgHuSlicerRank.Location = new Point(8, 0x3b);
            this.imgHuSlicerRank.Name = "imgHuSlicerRank";
            this.imgHuSlicerRank.Size = new Size(10, 10);
            this.imgHuSlicerRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSlicerRank.TabIndex = 0x53;
            this.imgHuSlicerRank.TabStop = false;
            this.imgHuSaberRank.Image = Resources.rank_C;
            this.imgHuSaberRank.Location = new Point(8, 0x2f);
            this.imgHuSaberRank.Name = "imgHuSaberRank";
            this.imgHuSaberRank.Size = new Size(10, 10);
            this.imgHuSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSaberRank.TabIndex = 0x52;
            this.imgHuSaberRank.TabStop = false;
            this.imgHuAxeRank.Image = Resources.rank_C;
            this.imgHuAxeRank.Location = new Point(8, 0x23);
            this.imgHuAxeRank.Name = "imgHuAxeRank";
            this.imgHuAxeRank.Size = new Size(10, 10);
            this.imgHuAxeRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuAxeRank.TabIndex = 0x51;
            this.imgHuAxeRank.TabStop = false;
            this.imgHuSwordRank.Image = Resources.rank_C;
            this.imgHuSwordRank.Location = new Point(8, 0x17);
            this.imgHuSwordRank.Name = "imgHuSwordRank";
            this.imgHuSwordRank.Size = new Size(10, 10);
            this.imgHuSwordRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSwordRank.TabIndex = 80;
            this.imgHuSwordRank.TabStop = false;
            this.imgHuRmag.Image = Resources.weapon_rmag;
            this.imgHuRmag.Location = new Point(0x7f, 0x53);
            this.imgHuRmag.Name = "imgHuRmag";
            this.imgHuRmag.Size = new Size(10, 10);
            this.imgHuRmag.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuRmag.TabIndex = 0x4f;
            this.imgHuRmag.TabStop = false;
            this.imgHuMachinegun.Image = Resources.weapon_machinegun;
            this.imgHuMachinegun.Location = new Point(0x5b, 0x53);
            this.imgHuMachinegun.Name = "imgHuMachinegun";
            this.imgHuMachinegun.Size = new Size(10, 10);
            this.imgHuMachinegun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuMachinegun.TabIndex = 0x4e;
            this.imgHuMachinegun.TabStop = false;
            this.imgHuCrossbow.Image = Resources.weapon_crossbow;
            this.imgHuCrossbow.Location = new Point(0x13, 0x53);
            this.imgHuCrossbow.Name = "imgHuCrossbow";
            this.imgHuCrossbow.Size = new Size(10, 10);
            this.imgHuCrossbow.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuCrossbow.TabIndex = 0x4d;
            this.imgHuCrossbow.TabStop = false;
            this.imgHuCards.Image = Resources.weapon_card;
            this.imgHuCards.Location = new Point(0x37, 0x53);
            this.imgHuCards.Name = "imgHuCards";
            this.imgHuCards.Size = new Size(10, 10);
            this.imgHuCards.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuCards.TabIndex = 0x4c;
            this.imgHuCards.TabStop = false;
            this.imgHuHandgun.Image = Resources.weapon_handgun;
            this.imgHuHandgun.Location = new Point(0x7f, 0x47);
            this.imgHuHandgun.Name = "imgHuHandgun";
            this.imgHuHandgun.Size = new Size(10, 10);
            this.imgHuHandgun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuHandgun.TabIndex = 0x4b;
            this.imgHuHandgun.TabStop = false;
            this.imgHuHandguns.Image = Resources.weapon_handguns;
            this.imgHuHandguns.Location = new Point(0x5b, 0x47);
            this.imgHuHandguns.Name = "imgHuHandguns";
            this.imgHuHandguns.Size = new Size(0x17, 10);
            this.imgHuHandguns.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuHandguns.TabIndex = 0x4a;
            this.imgHuHandguns.TabStop = false;
            this.imgHuGrenade.Image = Resources.weapon_grenade;
            this.imgHuGrenade.Location = new Point(0x13, 0x47);
            this.imgHuGrenade.Name = "imgHuGrenade";
            this.imgHuGrenade.Size = new Size(0x17, 10);
            this.imgHuGrenade.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuGrenade.TabIndex = 0x49;
            this.imgHuGrenade.TabStop = false;
            this.imgHuLaser.Image = Resources.weapon_laser;
            this.imgHuLaser.Location = new Point(0x37, 0x47);
            this.imgHuLaser.Name = "imgHuLaser";
            this.imgHuLaser.Size = new Size(0x17, 10);
            this.imgHuLaser.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuLaser.TabIndex = 0x48;
            this.imgHuLaser.TabStop = false;
            this.imgHuLongbow.Image = Resources.weapon_longbow;
            this.imgHuLongbow.Location = new Point(0x7f, 0x3b);
            this.imgHuLongbow.Name = "imgHuLongbow";
            this.imgHuLongbow.Size = new Size(0x17, 10);
            this.imgHuLongbow.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuLongbow.TabIndex = 0x47;
            this.imgHuLongbow.TabStop = false;
            this.imgHuShotgun.Image = Resources.weapon_shotgun;
            this.imgHuShotgun.Location = new Point(0x5b, 0x3b);
            this.imgHuShotgun.Name = "imgHuShotgun";
            this.imgHuShotgun.Size = new Size(0x17, 10);
            this.imgHuShotgun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuShotgun.TabIndex = 70;
            this.imgHuShotgun.TabStop = false;
            this.imgHuSlicer.Image = Resources.weapon_slicer;
            this.imgHuSlicer.Location = new Point(0x13, 0x3b);
            this.imgHuSlicer.Name = "imgHuSlicer";
            this.imgHuSlicer.Size = new Size(10, 10);
            this.imgHuSlicer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSlicer.TabIndex = 0x45;
            this.imgHuSlicer.TabStop = false;
            this.imgHuRifle.Image = Resources.weapon_rifle;
            this.imgHuRifle.Location = new Point(0x37, 0x3b);
            this.imgHuRifle.Name = "imgHuRifle";
            this.imgHuRifle.Size = new Size(0x17, 10);
            this.imgHuRifle.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuRifle.TabIndex = 0x44;
            this.imgHuRifle.TabStop = false;
            this.imgHuWhip.Image = Resources.weapon_whip;
            this.imgHuWhip.Location = new Point(0x7f, 0x2f);
            this.imgHuWhip.Name = "imgHuWhip";
            this.imgHuWhip.Size = new Size(10, 10);
            this.imgHuWhip.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuWhip.TabIndex = 0x43;
            this.imgHuWhip.TabStop = false;
            this.imgHuClaw.Image = Resources.weapon_claw;
            this.imgHuClaw.Location = new Point(0x5b, 0x2f);
            this.imgHuClaw.Name = "imgHuClaw";
            this.imgHuClaw.Size = new Size(10, 10);
            this.imgHuClaw.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuClaw.TabIndex = 0x42;
            this.imgHuClaw.TabStop = false;
            this.imgHuSaber.Image = Resources.weapon_saber;
            this.imgHuSaber.Location = new Point(0x13, 0x2f);
            this.imgHuSaber.Name = "imgHuSaber";
            this.imgHuSaber.Size = new Size(10, 10);
            this.imgHuSaber.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSaber.TabIndex = 0x41;
            this.imgHuSaber.TabStop = false;
            this.imgHuDagger.Image = Resources.weapon_dagger;
            this.imgHuDagger.Location = new Point(0x37, 0x2f);
            this.imgHuDagger.Name = "imgHuDagger";
            this.imgHuDagger.Size = new Size(10, 10);
            this.imgHuDagger.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuDagger.TabIndex = 0x40;
            this.imgHuDagger.TabStop = false;
            this.imgHuShield.Image = Resources.weapon_shield;
            this.imgHuShield.Location = new Point(0x7f, 0x5f);
            this.imgHuShield.Name = "imgHuShield";
            this.imgHuShield.Size = new Size(10, 10);
            this.imgHuShield.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuShield.TabIndex = 0x3f;
            this.imgHuShield.TabStop = false;
            this.imgHuTmag.Image = Resources.weapon_tmag;
            this.imgHuTmag.Location = new Point(0x5b, 0x5f);
            this.imgHuTmag.Name = "imgHuTmag";
            this.imgHuTmag.Size = new Size(10, 10);
            this.imgHuTmag.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuTmag.TabIndex = 0x3e;
            this.imgHuTmag.TabStop = false;
            this.imgHuRod.Image = Resources.weapon_rod;
            this.imgHuRod.Location = new Point(0x13, 0x5f);
            this.imgHuRod.Name = "imgHuRod";
            this.imgHuRod.Size = new Size(0x17, 10);
            this.imgHuRod.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuRod.TabIndex = 0x3d;
            this.imgHuRod.TabStop = false;
            this.imgHuWand.Image = Resources.weapon_wand;
            this.imgHuWand.Location = new Point(0x37, 0x5f);
            this.imgHuWand.Name = "imgHuWand";
            this.imgHuWand.Size = new Size(10, 10);
            this.imgHuWand.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuWand.TabIndex = 60;
            this.imgHuWand.TabStop = false;
            this.imgHuClaws.Image = Resources.weapon_claws;
            this.imgHuClaws.Location = new Point(0x7f, 0x23);
            this.imgHuClaws.Name = "imgHuClaws";
            this.imgHuClaws.Size = new Size(0x17, 10);
            this.imgHuClaws.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuClaws.TabIndex = 0x3b;
            this.imgHuClaws.TabStop = false;
            this.imgHuDaggers.Image = Resources.weapon_daggers;
            this.imgHuDaggers.Location = new Point(0x5b, 0x23);
            this.imgHuDaggers.Name = "imgHuDaggers";
            this.imgHuDaggers.Size = new Size(0x17, 10);
            this.imgHuDaggers.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuDaggers.TabIndex = 0x3a;
            this.imgHuDaggers.TabStop = false;
            this.imgHuAxe.Image = Resources.weapon_axe;
            this.imgHuAxe.Location = new Point(0x13, 0x23);
            this.imgHuAxe.Name = "imgHuAxe";
            this.imgHuAxe.Size = new Size(0x17, 10);
            this.imgHuAxe.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuAxe.TabIndex = 0x39;
            this.imgHuAxe.TabStop = false;
            this.imgHuSabers.Image = Resources.weapon_sabers;
            this.imgHuSabers.Location = new Point(0x37, 0x23);
            this.imgHuSabers.Name = "imgHuSabers";
            this.imgHuSabers.Size = new Size(0x17, 10);
            this.imgHuSabers.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSabers.TabIndex = 0x38;
            this.imgHuSabers.TabStop = false;
            this.imgHuDblSaber.Image = Resources.weapon_double_saber;
            this.imgHuDblSaber.Location = new Point(0x7f, 0x17);
            this.imgHuDblSaber.Name = "imgHuDblSaber";
            this.imgHuDblSaber.Size = new Size(0x17, 10);
            this.imgHuDblSaber.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuDblSaber.TabIndex = 0x37;
            this.imgHuDblSaber.TabStop = false;
            this.imgHuKnuckles.Image = Resources.weapon_knuckles;
            this.imgHuKnuckles.Location = new Point(0x37, 0x17);
            this.imgHuKnuckles.Name = "imgHuKnuckles";
            this.imgHuKnuckles.Size = new Size(0x17, 10);
            this.imgHuKnuckles.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuKnuckles.TabIndex = 0x36;
            this.imgHuKnuckles.TabStop = false;
            this.imgHuSpear.Image = Resources.weapon_spear;
            this.imgHuSpear.Location = new Point(0x5b, 0x17);
            this.imgHuSpear.Name = "imgHuSpear";
            this.imgHuSpear.Size = new Size(0x17, 10);
            this.imgHuSpear.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSpear.TabIndex = 0x35;
            this.imgHuSpear.TabStop = false;
            this.imgHuSword.Image = Resources.weapon_sword;
            this.imgHuSword.Location = new Point(0x13, 0x17);
            this.imgHuSword.Name = "imgHuSword";
            this.imgHuSword.Size = new Size(0x17, 10);
            this.imgHuSword.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgHuSword.TabIndex = 0x34;
            this.imgHuSword.TabStop = false;
            this.pictureBox231.Image = Resources.type_weapons;
            this.pictureBox231.Location = new Point(0x13, 0x17);
            this.pictureBox231.Name = "pictureBox231";
            this.pictureBox231.Size = new Size(0x83, 0x52);
            this.pictureBox231.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox231.TabIndex = 0x2f;
            this.pictureBox231.TabStop = false;
            this.lblHuLevel.AutoSize = true;
            this.lblHuLevel.Cursor = Cursors.Hand;
            this.lblHuLevel.Location = new Point(12, 0x20);
            this.lblHuLevel.Name = "lblHuLevel";
            this.lblHuLevel.Size = new Size(0x25, 13);
            this.lblHuLevel.TabIndex = 130;
            this.lblHuLevel.Text = "Level";
            this.lblHuLevel.Click += new EventHandler(this.classLevel_Click);
            this.txtHuLevel.AutoSize = true;
            this.txtHuLevel.Cursor = Cursors.Hand;
            this.txtHuLevel.Location = new Point(50, 0x20);
            this.txtHuLevel.Name = "txtHuLevel";
            this.txtHuLevel.Size = new Size(14, 13);
            this.txtHuLevel.TabIndex = 0x83;
            this.txtHuLevel.Text = "0";
            this.txtHuLevel.Click += new EventHandler(this.classLevel_Click);
            this.label39.AutoSize = true;
            this.label39.Cursor = Cursors.Hand;
            this.label39.Location = new Point(50, 0x20);
            this.label39.Name = "label39";
            this.label39.Size = new Size(14, 13);
            this.label39.TabIndex = 0x81;
            this.label39.Text = "0";
            this.label39.Click += new EventHandler(this.classLevel_Click);
            this.tabPageRanger.Controls.Add(this.label10);
            this.tabPageRanger.Controls.Add(this.grpRaTypeExtend);
            this.tabPageRanger.Controls.Add(this.lblRaLevel);
            this.tabPageRanger.Controls.Add(this.txtRaLevel);
            this.tabPageRanger.Controls.Add(this.label35);
            this.tabPageRanger.Controls.Add(this.btnRaAbilitiesOpen);
            this.tabPageRanger.Font = new Font("Verdana", 8.25f);
            this.tabPageRanger.Location = new Point(4, 0x15);
            this.tabPageRanger.Name = "tabPageRanger";
            this.tabPageRanger.Padding = new Padding(3);
            this.tabPageRanger.Size = new Size(610, 0xc0);
            this.tabPageRanger.TabIndex = 1;
            this.tabPageRanger.Text = "Ranger (0)";
            this.tabPageRanger.UseVisualStyleBackColor = true;
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label10.Location = new Point(11, 13);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x3b, 0x10);
            this.label10.TabIndex = 0x86;
            this.label10.Text = "Ranger";
            this.grpRaTypeExtend.Controls.Add(this.txtRaExp);
            this.grpRaTypeExtend.Controls.Add(this.imgRaTmagRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaMachinegunRank);
            this.grpRaTypeExtend.Controls.Add(this.txtRaExpBar);
            this.grpRaTypeExtend.Controls.Add(this.label22);
            this.grpRaTypeExtend.Controls.Add(this.imgRaHandgunsRank);
            this.grpRaTypeExtend.Controls.Add(this.label23);
            this.grpRaTypeExtend.Controls.Add(this.imgRaShotgunRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaClawRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaDaggersRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSpearRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaWandRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaCardsRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaLaserRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaRifleRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaDaggerRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSabersRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaKnucklesRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaShieldRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaRmagRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaHandgunRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaLongbowRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaWhipRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaClawsRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaDblSaberRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaRodRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaCrossbowRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaGrenadeRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSlicerRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSaberRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaAxeRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSwordRank);
            this.grpRaTypeExtend.Controls.Add(this.imgRaRmag);
            this.grpRaTypeExtend.Controls.Add(this.imgRaMachinegun);
            this.grpRaTypeExtend.Controls.Add(this.imgRaCrossbow);
            this.grpRaTypeExtend.Controls.Add(this.imgRaCards);
            this.grpRaTypeExtend.Controls.Add(this.imgRaHandgun);
            this.grpRaTypeExtend.Controls.Add(this.imgRaHandguns);
            this.grpRaTypeExtend.Controls.Add(this.imgRaGrenade);
            this.grpRaTypeExtend.Controls.Add(this.imgRaLaser);
            this.grpRaTypeExtend.Controls.Add(this.imgRaLongbow);
            this.grpRaTypeExtend.Controls.Add(this.imgRaShotgun);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSlicer);
            this.grpRaTypeExtend.Controls.Add(this.imgRaRifle);
            this.grpRaTypeExtend.Controls.Add(this.imgRaWhip);
            this.grpRaTypeExtend.Controls.Add(this.imgRaClaw);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSaber);
            this.grpRaTypeExtend.Controls.Add(this.imgRaDagger);
            this.grpRaTypeExtend.Controls.Add(this.imgRaShield);
            this.grpRaTypeExtend.Controls.Add(this.imgRaTmag);
            this.grpRaTypeExtend.Controls.Add(this.imgRaRod);
            this.grpRaTypeExtend.Controls.Add(this.imgRaWand);
            this.grpRaTypeExtend.Controls.Add(this.imgRaClaws);
            this.grpRaTypeExtend.Controls.Add(this.imgRaDaggers);
            this.grpRaTypeExtend.Controls.Add(this.imgRaAxe);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSabers);
            this.grpRaTypeExtend.Controls.Add(this.imgRaDblSaber);
            this.grpRaTypeExtend.Controls.Add(this.imgRaKnuckles);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSpear);
            this.grpRaTypeExtend.Controls.Add(this.imgRaSword);
            this.grpRaTypeExtend.Controls.Add(this.pictureBox174);
            this.grpRaTypeExtend.Location = new Point(10, 0x3a);
            this.grpRaTypeExtend.Name = "grpRaTypeExtend";
            this.grpRaTypeExtend.Size = new Size(0x130, 0x77);
            this.grpRaTypeExtend.TabIndex = 0x85;
            this.grpRaTypeExtend.TabStop = false;
            this.grpRaTypeExtend.Text = "Type Extend 0/0";
            this.txtRaExp.BackColor = Color.Transparent;
            this.txtRaExp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRaExp.Location = new Point(0xc2, 0x24);
            this.txtRaExp.Name = "txtRaExp";
            this.txtRaExp.Size = new Size(0x66, 0x45);
            this.txtRaExp.TabIndex = 0x6c;
            this.txtRaExp.TextAlign = ContentAlignment.TopRight;
            this.imgRaTmagRank.Image = Resources.rank_C;
            this.imgRaTmagRank.Location = new Point(80, 0x5f);
            this.imgRaTmagRank.Name = "imgRaTmagRank";
            this.imgRaTmagRank.Size = new Size(10, 10);
            this.imgRaTmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaTmagRank.TabIndex = 0x6b;
            this.imgRaTmagRank.TabStop = false;
            this.imgRaMachinegunRank.Image = Resources.rank_C;
            this.imgRaMachinegunRank.Location = new Point(80, 0x53);
            this.imgRaMachinegunRank.Name = "imgRaMachinegunRank";
            this.imgRaMachinegunRank.Size = new Size(10, 10);
            this.imgRaMachinegunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaMachinegunRank.TabIndex = 0x6a;
            this.imgRaMachinegunRank.TabStop = false;
            this.txtRaExpBar.BackColor = Color.Red;
            this.txtRaExpBar.Location = new Point(0xc3, 0x17);
            this.txtRaExpBar.Name = "txtRaExpBar";
            this.txtRaExpBar.Size = new Size(0x57, 8);
            this.txtRaExpBar.TabIndex = 0x31;
            this.label22.AutoSize = true;
            this.label22.Location = new Point(0x9f, 20);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x1d, 13);
            this.label22.TabIndex = 0x30;
            this.label22.Text = "EXP";
            this.imgRaHandgunsRank.Image = Resources.rank_C;
            this.imgRaHandgunsRank.Location = new Point(80, 0x47);
            this.imgRaHandgunsRank.Name = "imgRaHandgunsRank";
            this.imgRaHandgunsRank.Size = new Size(10, 10);
            this.imgRaHandgunsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaHandgunsRank.TabIndex = 0x69;
            this.imgRaHandgunsRank.TabStop = false;
            this.label23.BackColor = Color.Gainsboro;
            this.label23.BorderStyle = BorderStyle.FixedSingle;
            this.label23.Location = new Point(0xc2, 0x16);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x66, 10);
            this.label23.TabIndex = 50;
            this.imgRaShotgunRank.Image = Resources.rank_C;
            this.imgRaShotgunRank.Location = new Point(80, 0x3b);
            this.imgRaShotgunRank.Name = "imgRaShotgunRank";
            this.imgRaShotgunRank.Size = new Size(10, 10);
            this.imgRaShotgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaShotgunRank.TabIndex = 0x68;
            this.imgRaShotgunRank.TabStop = false;
            this.imgRaClawRank.Image = Resources.rank_C;
            this.imgRaClawRank.Location = new Point(80, 0x2f);
            this.imgRaClawRank.Name = "imgRaClawRank";
            this.imgRaClawRank.Size = new Size(10, 10);
            this.imgRaClawRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaClawRank.TabIndex = 0x67;
            this.imgRaClawRank.TabStop = false;
            this.imgRaDaggersRank.Image = Resources.rank_C;
            this.imgRaDaggersRank.Location = new Point(80, 0x23);
            this.imgRaDaggersRank.Name = "imgRaDaggersRank";
            this.imgRaDaggersRank.Size = new Size(10, 10);
            this.imgRaDaggersRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaDaggersRank.TabIndex = 0x66;
            this.imgRaDaggersRank.TabStop = false;
            this.imgRaSpearRank.Image = Resources.rank_C;
            this.imgRaSpearRank.Location = new Point(80, 0x17);
            this.imgRaSpearRank.Name = "imgRaSpearRank";
            this.imgRaSpearRank.Size = new Size(10, 10);
            this.imgRaSpearRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSpearRank.TabIndex = 0x65;
            this.imgRaSpearRank.TabStop = false;
            this.imgRaWandRank.Image = Resources.rank_B;
            this.imgRaWandRank.Location = new Point(0x2c, 0x5f);
            this.imgRaWandRank.Name = "imgRaWandRank";
            this.imgRaWandRank.Size = new Size(10, 10);
            this.imgRaWandRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaWandRank.TabIndex = 100;
            this.imgRaWandRank.TabStop = false;
            this.imgRaCardsRank.Image = Resources.rank_B;
            this.imgRaCardsRank.Location = new Point(0x2c, 0x53);
            this.imgRaCardsRank.Name = "imgRaCardsRank";
            this.imgRaCardsRank.Size = new Size(10, 10);
            this.imgRaCardsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaCardsRank.TabIndex = 0x63;
            this.imgRaCardsRank.TabStop = false;
            this.imgRaLaserRank.Image = Resources.rank_B;
            this.imgRaLaserRank.Location = new Point(0x2c, 0x47);
            this.imgRaLaserRank.Name = "imgRaLaserRank";
            this.imgRaLaserRank.Size = new Size(10, 10);
            this.imgRaLaserRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaLaserRank.TabIndex = 0x62;
            this.imgRaLaserRank.TabStop = false;
            this.imgRaRifleRank.Image = Resources.rank_B;
            this.imgRaRifleRank.Location = new Point(0x2c, 0x3b);
            this.imgRaRifleRank.Name = "imgRaRifleRank";
            this.imgRaRifleRank.Size = new Size(10, 10);
            this.imgRaRifleRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaRifleRank.TabIndex = 0x61;
            this.imgRaRifleRank.TabStop = false;
            this.imgRaDaggerRank.Image = Resources.rank_B;
            this.imgRaDaggerRank.Location = new Point(0x2c, 0x2f);
            this.imgRaDaggerRank.Name = "imgRaDaggerRank";
            this.imgRaDaggerRank.Size = new Size(10, 10);
            this.imgRaDaggerRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaDaggerRank.TabIndex = 0x60;
            this.imgRaDaggerRank.TabStop = false;
            this.imgRaSabersRank.Image = Resources.rank_B;
            this.imgRaSabersRank.Location = new Point(0x2c, 0x23);
            this.imgRaSabersRank.Name = "imgRaSabersRank";
            this.imgRaSabersRank.Size = new Size(10, 10);
            this.imgRaSabersRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSabersRank.TabIndex = 0x5f;
            this.imgRaSabersRank.TabStop = false;
            this.imgRaKnucklesRank.Image = Resources.rank_B;
            this.imgRaKnucklesRank.Location = new Point(0x2c, 0x17);
            this.imgRaKnucklesRank.Name = "imgRaKnucklesRank";
            this.imgRaKnucklesRank.Size = new Size(10, 10);
            this.imgRaKnucklesRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaKnucklesRank.TabIndex = 0x5e;
            this.imgRaKnucklesRank.TabStop = false;
            this.imgRaShieldRank.Image = Resources.rank_B;
            this.imgRaShieldRank.Location = new Point(0x74, 0x5f);
            this.imgRaShieldRank.Name = "imgRaShieldRank";
            this.imgRaShieldRank.Size = new Size(10, 10);
            this.imgRaShieldRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaShieldRank.TabIndex = 0x5d;
            this.imgRaShieldRank.TabStop = false;
            this.imgRaRmagRank.Image = Resources.rank_B;
            this.imgRaRmagRank.Location = new Point(0x74, 0x53);
            this.imgRaRmagRank.Name = "imgRaRmagRank";
            this.imgRaRmagRank.Size = new Size(10, 10);
            this.imgRaRmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaRmagRank.TabIndex = 0x5c;
            this.imgRaRmagRank.TabStop = false;
            this.imgRaHandgunRank.Image = Resources.rank_B;
            this.imgRaHandgunRank.Location = new Point(0x74, 0x47);
            this.imgRaHandgunRank.Name = "imgRaHandgunRank";
            this.imgRaHandgunRank.Size = new Size(10, 10);
            this.imgRaHandgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaHandgunRank.TabIndex = 0x5b;
            this.imgRaHandgunRank.TabStop = false;
            this.imgRaLongbowRank.Image = Resources.rank_B;
            this.imgRaLongbowRank.Location = new Point(0x74, 0x3b);
            this.imgRaLongbowRank.Name = "imgRaLongbowRank";
            this.imgRaLongbowRank.Size = new Size(10, 10);
            this.imgRaLongbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaLongbowRank.TabIndex = 90;
            this.imgRaLongbowRank.TabStop = false;
            this.imgRaWhipRank.Image = Resources.rank_B;
            this.imgRaWhipRank.Location = new Point(0x74, 0x2f);
            this.imgRaWhipRank.Name = "imgRaWhipRank";
            this.imgRaWhipRank.Size = new Size(10, 10);
            this.imgRaWhipRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaWhipRank.TabIndex = 0x59;
            this.imgRaWhipRank.TabStop = false;
            this.imgRaClawsRank.Image = Resources.rank_B;
            this.imgRaClawsRank.Location = new Point(0x74, 0x23);
            this.imgRaClawsRank.Name = "imgRaClawsRank";
            this.imgRaClawsRank.Size = new Size(10, 10);
            this.imgRaClawsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaClawsRank.TabIndex = 0x58;
            this.imgRaClawsRank.TabStop = false;
            this.imgRaDblSaberRank.Image = Resources.rank_B;
            this.imgRaDblSaberRank.Location = new Point(0x74, 0x17);
            this.imgRaDblSaberRank.Name = "imgRaDblSaberRank";
            this.imgRaDblSaberRank.Size = new Size(10, 10);
            this.imgRaDblSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaDblSaberRank.TabIndex = 0x57;
            this.imgRaDblSaberRank.TabStop = false;
            this.imgRaRodRank.Image = Resources.rank_C;
            this.imgRaRodRank.Location = new Point(8, 0x5f);
            this.imgRaRodRank.Name = "imgRaRodRank";
            this.imgRaRodRank.Size = new Size(10, 10);
            this.imgRaRodRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaRodRank.TabIndex = 0x56;
            this.imgRaRodRank.TabStop = false;
            this.imgRaCrossbowRank.Image = Resources.rank_C;
            this.imgRaCrossbowRank.Location = new Point(8, 0x53);
            this.imgRaCrossbowRank.Name = "imgRaCrossbowRank";
            this.imgRaCrossbowRank.Size = new Size(10, 10);
            this.imgRaCrossbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaCrossbowRank.TabIndex = 0x55;
            this.imgRaCrossbowRank.TabStop = false;
            this.imgRaGrenadeRank.Image = Resources.rank_C;
            this.imgRaGrenadeRank.Location = new Point(8, 0x47);
            this.imgRaGrenadeRank.Name = "imgRaGrenadeRank";
            this.imgRaGrenadeRank.Size = new Size(10, 10);
            this.imgRaGrenadeRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaGrenadeRank.TabIndex = 0x54;
            this.imgRaGrenadeRank.TabStop = false;
            this.imgRaSlicerRank.Image = Resources.rank_C;
            this.imgRaSlicerRank.Location = new Point(8, 0x3b);
            this.imgRaSlicerRank.Name = "imgRaSlicerRank";
            this.imgRaSlicerRank.Size = new Size(10, 10);
            this.imgRaSlicerRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSlicerRank.TabIndex = 0x53;
            this.imgRaSlicerRank.TabStop = false;
            this.imgRaSaberRank.Image = Resources.rank_C;
            this.imgRaSaberRank.Location = new Point(8, 0x2f);
            this.imgRaSaberRank.Name = "imgRaSaberRank";
            this.imgRaSaberRank.Size = new Size(10, 10);
            this.imgRaSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSaberRank.TabIndex = 0x52;
            this.imgRaSaberRank.TabStop = false;
            this.imgRaAxeRank.Image = Resources.rank_C;
            this.imgRaAxeRank.Location = new Point(8, 0x23);
            this.imgRaAxeRank.Name = "imgRaAxeRank";
            this.imgRaAxeRank.Size = new Size(10, 10);
            this.imgRaAxeRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaAxeRank.TabIndex = 0x51;
            this.imgRaAxeRank.TabStop = false;
            this.imgRaSwordRank.Image = Resources.rank_C;
            this.imgRaSwordRank.Location = new Point(8, 0x17);
            this.imgRaSwordRank.Name = "imgRaSwordRank";
            this.imgRaSwordRank.Size = new Size(10, 10);
            this.imgRaSwordRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSwordRank.TabIndex = 80;
            this.imgRaSwordRank.TabStop = false;
            this.imgRaRmag.Image = Resources.weapon_rmag;
            this.imgRaRmag.Location = new Point(0x7f, 0x53);
            this.imgRaRmag.Name = "imgRaRmag";
            this.imgRaRmag.Size = new Size(10, 10);
            this.imgRaRmag.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaRmag.TabIndex = 0x4f;
            this.imgRaRmag.TabStop = false;
            this.imgRaMachinegun.Image = Resources.weapon_machinegun;
            this.imgRaMachinegun.Location = new Point(0x5b, 0x53);
            this.imgRaMachinegun.Name = "imgRaMachinegun";
            this.imgRaMachinegun.Size = new Size(10, 10);
            this.imgRaMachinegun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaMachinegun.TabIndex = 0x4e;
            this.imgRaMachinegun.TabStop = false;
            this.imgRaCrossbow.Image = Resources.weapon_crossbow;
            this.imgRaCrossbow.Location = new Point(0x13, 0x53);
            this.imgRaCrossbow.Name = "imgRaCrossbow";
            this.imgRaCrossbow.Size = new Size(10, 10);
            this.imgRaCrossbow.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaCrossbow.TabIndex = 0x4d;
            this.imgRaCrossbow.TabStop = false;
            this.imgRaCards.Image = Resources.weapon_card;
            this.imgRaCards.Location = new Point(0x37, 0x53);
            this.imgRaCards.Name = "imgRaCards";
            this.imgRaCards.Size = new Size(10, 10);
            this.imgRaCards.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaCards.TabIndex = 0x4c;
            this.imgRaCards.TabStop = false;
            this.imgRaHandgun.Image = Resources.weapon_handgun;
            this.imgRaHandgun.Location = new Point(0x7f, 0x47);
            this.imgRaHandgun.Name = "imgRaHandgun";
            this.imgRaHandgun.Size = new Size(10, 10);
            this.imgRaHandgun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaHandgun.TabIndex = 0x4b;
            this.imgRaHandgun.TabStop = false;
            this.imgRaHandguns.Image = Resources.weapon_handguns;
            this.imgRaHandguns.Location = new Point(0x5b, 0x47);
            this.imgRaHandguns.Name = "imgRaHandguns";
            this.imgRaHandguns.Size = new Size(0x17, 10);
            this.imgRaHandguns.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaHandguns.TabIndex = 0x4a;
            this.imgRaHandguns.TabStop = false;
            this.imgRaGrenade.Image = Resources.weapon_grenade;
            this.imgRaGrenade.Location = new Point(0x13, 0x47);
            this.imgRaGrenade.Name = "imgRaGrenade";
            this.imgRaGrenade.Size = new Size(0x17, 10);
            this.imgRaGrenade.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaGrenade.TabIndex = 0x49;
            this.imgRaGrenade.TabStop = false;
            this.imgRaLaser.Image = Resources.weapon_laser;
            this.imgRaLaser.Location = new Point(0x37, 0x47);
            this.imgRaLaser.Name = "imgRaLaser";
            this.imgRaLaser.Size = new Size(0x17, 10);
            this.imgRaLaser.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaLaser.TabIndex = 0x48;
            this.imgRaLaser.TabStop = false;
            this.imgRaLongbow.Image = Resources.weapon_longbow;
            this.imgRaLongbow.Location = new Point(0x7f, 0x3b);
            this.imgRaLongbow.Name = "imgRaLongbow";
            this.imgRaLongbow.Size = new Size(0x17, 10);
            this.imgRaLongbow.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaLongbow.TabIndex = 0x47;
            this.imgRaLongbow.TabStop = false;
            this.imgRaShotgun.Image = Resources.weapon_shotgun;
            this.imgRaShotgun.Location = new Point(0x5b, 0x3b);
            this.imgRaShotgun.Name = "imgRaShotgun";
            this.imgRaShotgun.Size = new Size(0x17, 10);
            this.imgRaShotgun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaShotgun.TabIndex = 70;
            this.imgRaShotgun.TabStop = false;
            this.imgRaSlicer.Image = Resources.weapon_slicer;
            this.imgRaSlicer.Location = new Point(0x13, 0x3b);
            this.imgRaSlicer.Name = "imgRaSlicer";
            this.imgRaSlicer.Size = new Size(10, 10);
            this.imgRaSlicer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSlicer.TabIndex = 0x45;
            this.imgRaSlicer.TabStop = false;
            this.imgRaRifle.Image = Resources.weapon_rifle;
            this.imgRaRifle.Location = new Point(0x37, 0x3b);
            this.imgRaRifle.Name = "imgRaRifle";
            this.imgRaRifle.Size = new Size(0x17, 10);
            this.imgRaRifle.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaRifle.TabIndex = 0x44;
            this.imgRaRifle.TabStop = false;
            this.imgRaWhip.Image = Resources.weapon_whip;
            this.imgRaWhip.Location = new Point(0x7f, 0x2f);
            this.imgRaWhip.Name = "imgRaWhip";
            this.imgRaWhip.Size = new Size(10, 10);
            this.imgRaWhip.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaWhip.TabIndex = 0x43;
            this.imgRaWhip.TabStop = false;
            this.imgRaClaw.Image = Resources.weapon_claw;
            this.imgRaClaw.Location = new Point(0x5b, 0x2f);
            this.imgRaClaw.Name = "imgRaClaw";
            this.imgRaClaw.Size = new Size(10, 10);
            this.imgRaClaw.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaClaw.TabIndex = 0x42;
            this.imgRaClaw.TabStop = false;
            this.imgRaSaber.Image = Resources.weapon_saber;
            this.imgRaSaber.Location = new Point(0x13, 0x2f);
            this.imgRaSaber.Name = "imgRaSaber";
            this.imgRaSaber.Size = new Size(10, 10);
            this.imgRaSaber.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSaber.TabIndex = 0x41;
            this.imgRaSaber.TabStop = false;
            this.imgRaDagger.Image = Resources.weapon_dagger;
            this.imgRaDagger.Location = new Point(0x37, 0x2f);
            this.imgRaDagger.Name = "imgRaDagger";
            this.imgRaDagger.Size = new Size(10, 10);
            this.imgRaDagger.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaDagger.TabIndex = 0x40;
            this.imgRaDagger.TabStop = false;
            this.imgRaShield.Image = Resources.weapon_shield;
            this.imgRaShield.Location = new Point(0x7f, 0x5f);
            this.imgRaShield.Name = "imgRaShield";
            this.imgRaShield.Size = new Size(10, 10);
            this.imgRaShield.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaShield.TabIndex = 0x3f;
            this.imgRaShield.TabStop = false;
            this.imgRaTmag.Image = Resources.weapon_tmag;
            this.imgRaTmag.Location = new Point(0x5b, 0x5f);
            this.imgRaTmag.Name = "imgRaTmag";
            this.imgRaTmag.Size = new Size(10, 10);
            this.imgRaTmag.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaTmag.TabIndex = 0x3e;
            this.imgRaTmag.TabStop = false;
            this.imgRaRod.Image = Resources.weapon_rod;
            this.imgRaRod.Location = new Point(0x13, 0x5f);
            this.imgRaRod.Name = "imgRaRod";
            this.imgRaRod.Size = new Size(0x17, 10);
            this.imgRaRod.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaRod.TabIndex = 0x3d;
            this.imgRaRod.TabStop = false;
            this.imgRaWand.Image = Resources.weapon_wand;
            this.imgRaWand.Location = new Point(0x37, 0x5f);
            this.imgRaWand.Name = "imgRaWand";
            this.imgRaWand.Size = new Size(10, 10);
            this.imgRaWand.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaWand.TabIndex = 60;
            this.imgRaWand.TabStop = false;
            this.imgRaClaws.Image = Resources.weapon_claws;
            this.imgRaClaws.Location = new Point(0x7f, 0x23);
            this.imgRaClaws.Name = "imgRaClaws";
            this.imgRaClaws.Size = new Size(0x17, 10);
            this.imgRaClaws.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaClaws.TabIndex = 0x3b;
            this.imgRaClaws.TabStop = false;
            this.imgRaDaggers.Image = Resources.weapon_daggers;
            this.imgRaDaggers.Location = new Point(0x5b, 0x23);
            this.imgRaDaggers.Name = "imgRaDaggers";
            this.imgRaDaggers.Size = new Size(0x17, 10);
            this.imgRaDaggers.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaDaggers.TabIndex = 0x3a;
            this.imgRaDaggers.TabStop = false;
            this.imgRaAxe.Image = Resources.weapon_axe;
            this.imgRaAxe.Location = new Point(0x13, 0x23);
            this.imgRaAxe.Name = "imgRaAxe";
            this.imgRaAxe.Size = new Size(0x17, 10);
            this.imgRaAxe.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaAxe.TabIndex = 0x39;
            this.imgRaAxe.TabStop = false;
            this.imgRaSabers.Image = Resources.weapon_sabers;
            this.imgRaSabers.Location = new Point(0x37, 0x23);
            this.imgRaSabers.Name = "imgRaSabers";
            this.imgRaSabers.Size = new Size(0x17, 10);
            this.imgRaSabers.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSabers.TabIndex = 0x38;
            this.imgRaSabers.TabStop = false;
            this.imgRaDblSaber.Image = Resources.weapon_double_saber;
            this.imgRaDblSaber.Location = new Point(0x7f, 0x17);
            this.imgRaDblSaber.Name = "imgRaDblSaber";
            this.imgRaDblSaber.Size = new Size(0x17, 10);
            this.imgRaDblSaber.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaDblSaber.TabIndex = 0x37;
            this.imgRaDblSaber.TabStop = false;
            this.imgRaKnuckles.Image = Resources.weapon_knuckles;
            this.imgRaKnuckles.Location = new Point(0x37, 0x17);
            this.imgRaKnuckles.Name = "imgRaKnuckles";
            this.imgRaKnuckles.Size = new Size(0x17, 10);
            this.imgRaKnuckles.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaKnuckles.TabIndex = 0x36;
            this.imgRaKnuckles.TabStop = false;
            this.imgRaSpear.Image = Resources.weapon_spear;
            this.imgRaSpear.Location = new Point(0x5b, 0x17);
            this.imgRaSpear.Name = "imgRaSpear";
            this.imgRaSpear.Size = new Size(0x17, 10);
            this.imgRaSpear.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSpear.TabIndex = 0x35;
            this.imgRaSpear.TabStop = false;
            this.imgRaSword.Image = Resources.weapon_sword;
            this.imgRaSword.Location = new Point(0x13, 0x17);
            this.imgRaSword.Name = "imgRaSword";
            this.imgRaSword.Size = new Size(0x17, 10);
            this.imgRaSword.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgRaSword.TabIndex = 0x34;
            this.imgRaSword.TabStop = false;
            this.pictureBox174.Image = Resources.type_weapons;
            this.pictureBox174.Location = new Point(0x13, 0x17);
            this.pictureBox174.Name = "pictureBox174";
            this.pictureBox174.Size = new Size(0x83, 0x52);
            this.pictureBox174.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox174.TabIndex = 0x2f;
            this.pictureBox174.TabStop = false;
            this.lblRaLevel.AutoSize = true;
            this.lblRaLevel.Cursor = Cursors.Hand;
            this.lblRaLevel.Location = new Point(12, 0x20);
            this.lblRaLevel.Name = "lblRaLevel";
            this.lblRaLevel.Size = new Size(0x25, 13);
            this.lblRaLevel.TabIndex = 0x83;
            this.lblRaLevel.Text = "Level";
            this.lblRaLevel.Click += new EventHandler(this.classLevel_Click);
            this.txtRaLevel.AutoSize = true;
            this.txtRaLevel.Cursor = Cursors.Hand;
            this.txtRaLevel.Location = new Point(50, 0x20);
            this.txtRaLevel.Name = "txtRaLevel";
            this.txtRaLevel.Size = new Size(14, 13);
            this.txtRaLevel.TabIndex = 0x84;
            this.txtRaLevel.Text = "0";
            this.txtRaLevel.Click += new EventHandler(this.classLevel_Click);
            this.label35.AutoSize = true;
            this.label35.Cursor = Cursors.Hand;
            this.label35.Location = new Point(50, 0x20);
            this.label35.Name = "label35";
            this.label35.Size = new Size(14, 13);
            this.label35.TabIndex = 130;
            this.label35.Text = "0";
            this.label35.Click += new EventHandler(this.classLevel_Click);
            this.btnRaAbilitiesOpen.Cursor = Cursors.Hand;
            this.btnRaAbilitiesOpen.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnRaAbilitiesOpen.Location = new Point(0x21f, 8);
            this.btnRaAbilitiesOpen.Name = "btnRaAbilitiesOpen";
            this.btnRaAbilitiesOpen.Size = new Size(0x3d, 0x15);
            this.btnRaAbilitiesOpen.TabIndex = 0x87;
            this.btnRaAbilitiesOpen.Text = "Abilities";
            this.btnRaAbilitiesOpen.UseVisualStyleBackColor = true;
            this.btnRaAbilitiesOpen.Click += new EventHandler(this.btnRaAbilitiesOpen_Click);
            this.tabPageForce.Controls.Add(this.label8);
            this.tabPageForce.Controls.Add(this.grpFoTypeExtend);
            this.tabPageForce.Controls.Add(this.lblFoLevel);
            this.tabPageForce.Controls.Add(this.txtFoLevel);
            this.tabPageForce.Controls.Add(this.btnFoAbilitiesOpen);
            this.tabPageForce.Font = new Font("Verdana", 8.25f);
            this.tabPageForce.Location = new Point(4, 0x15);
            this.tabPageForce.Name = "tabPageForce";
            this.tabPageForce.Padding = new Padding(3);
            this.tabPageForce.Size = new Size(610, 0xc0);
            this.tabPageForce.TabIndex = 2;
            this.tabPageForce.Text = "Force (0)";
            this.tabPageForce.UseVisualStyleBackColor = true;
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label8.Location = new Point(11, 13);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x31, 0x10);
            this.label8.TabIndex = 0x8a;
            this.label8.Text = "Force";
            this.grpFoTypeExtend.Controls.Add(this.txtFoExp);
            this.grpFoTypeExtend.Controls.Add(this.imgFoTmagRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoMachinegunRank);
            this.grpFoTypeExtend.Controls.Add(this.txtFoExpBar);
            this.grpFoTypeExtend.Controls.Add(this.label14);
            this.grpFoTypeExtend.Controls.Add(this.imgFoHandgunsRank);
            this.grpFoTypeExtend.Controls.Add(this.label15);
            this.grpFoTypeExtend.Controls.Add(this.imgFoShotgunRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoClawRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoDaggersRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSpearRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoWandRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoCardsRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoLaserRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoRifleRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoDaggerRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSabersRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoKnucklesRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoShieldRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoRmagRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoHandgunRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoLongbowRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoWhipRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoClawsRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoDblSaberRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoRodRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoCrossbowRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoGrenadeRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSlicerRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSaberRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoAxeRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSwordRank);
            this.grpFoTypeExtend.Controls.Add(this.imgFoRmag);
            this.grpFoTypeExtend.Controls.Add(this.imgFoMachinegun);
            this.grpFoTypeExtend.Controls.Add(this.imgFoCrossbow);
            this.grpFoTypeExtend.Controls.Add(this.imgFoCards);
            this.grpFoTypeExtend.Controls.Add(this.imgFoHandgun);
            this.grpFoTypeExtend.Controls.Add(this.imgFoHandguns);
            this.grpFoTypeExtend.Controls.Add(this.imgFoGrenade);
            this.grpFoTypeExtend.Controls.Add(this.imgFoLaser);
            this.grpFoTypeExtend.Controls.Add(this.imgFoLongbow);
            this.grpFoTypeExtend.Controls.Add(this.imgFoShotgun);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSlicer);
            this.grpFoTypeExtend.Controls.Add(this.imgFoRifle);
            this.grpFoTypeExtend.Controls.Add(this.imgFoWhip);
            this.grpFoTypeExtend.Controls.Add(this.imgFoClaw);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSaber);
            this.grpFoTypeExtend.Controls.Add(this.imgFoDagger);
            this.grpFoTypeExtend.Controls.Add(this.imgFoShield);
            this.grpFoTypeExtend.Controls.Add(this.imgFoTmag);
            this.grpFoTypeExtend.Controls.Add(this.imgFoRod);
            this.grpFoTypeExtend.Controls.Add(this.imgFoWand);
            this.grpFoTypeExtend.Controls.Add(this.imgFoClaws);
            this.grpFoTypeExtend.Controls.Add(this.imgFoDaggers);
            this.grpFoTypeExtend.Controls.Add(this.imgFoAxe);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSabers);
            this.grpFoTypeExtend.Controls.Add(this.imgFoDblSaber);
            this.grpFoTypeExtend.Controls.Add(this.imgFoKnuckles);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSpear);
            this.grpFoTypeExtend.Controls.Add(this.imgFoSword);
            this.grpFoTypeExtend.Controls.Add(this.pictureBox117);
            this.grpFoTypeExtend.Location = new Point(10, 0x3a);
            this.grpFoTypeExtend.Name = "grpFoTypeExtend";
            this.grpFoTypeExtend.Size = new Size(0x130, 0x77);
            this.grpFoTypeExtend.TabIndex = 0x89;
            this.grpFoTypeExtend.TabStop = false;
            this.grpFoTypeExtend.Text = "Type Extend 0/0";
            this.txtFoExp.BackColor = Color.Transparent;
            this.txtFoExp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtFoExp.Location = new Point(0xc2, 0x24);
            this.txtFoExp.Name = "txtFoExp";
            this.txtFoExp.Size = new Size(0x66, 0x45);
            this.txtFoExp.TabIndex = 0x6d;
            this.txtFoExp.TextAlign = ContentAlignment.TopRight;
            this.imgFoTmagRank.Image = Resources.rank_C;
            this.imgFoTmagRank.Location = new Point(80, 0x5f);
            this.imgFoTmagRank.Name = "imgFoTmagRank";
            this.imgFoTmagRank.Size = new Size(10, 10);
            this.imgFoTmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoTmagRank.TabIndex = 0x6b;
            this.imgFoTmagRank.TabStop = false;
            this.imgFoMachinegunRank.Image = Resources.rank_C;
            this.imgFoMachinegunRank.Location = new Point(80, 0x53);
            this.imgFoMachinegunRank.Name = "imgFoMachinegunRank";
            this.imgFoMachinegunRank.Size = new Size(10, 10);
            this.imgFoMachinegunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoMachinegunRank.TabIndex = 0x6a;
            this.imgFoMachinegunRank.TabStop = false;
            this.txtFoExpBar.BackColor = Color.Red;
            this.txtFoExpBar.Location = new Point(0xc3, 0x17);
            this.txtFoExpBar.Name = "txtFoExpBar";
            this.txtFoExpBar.Size = new Size(0x57, 8);
            this.txtFoExpBar.TabIndex = 0x31;
            this.label14.AutoSize = true;
            this.label14.Location = new Point(0x9f, 20);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x1d, 13);
            this.label14.TabIndex = 0x30;
            this.label14.Text = "EXP";
            this.imgFoHandgunsRank.Image = Resources.rank_C;
            this.imgFoHandgunsRank.Location = new Point(80, 0x47);
            this.imgFoHandgunsRank.Name = "imgFoHandgunsRank";
            this.imgFoHandgunsRank.Size = new Size(10, 10);
            this.imgFoHandgunsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoHandgunsRank.TabIndex = 0x69;
            this.imgFoHandgunsRank.TabStop = false;
            this.label15.BackColor = Color.Gainsboro;
            this.label15.BorderStyle = BorderStyle.FixedSingle;
            this.label15.Location = new Point(0xc2, 0x16);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x66, 10);
            this.label15.TabIndex = 50;
            this.imgFoShotgunRank.Image = Resources.rank_C;
            this.imgFoShotgunRank.Location = new Point(80, 0x3b);
            this.imgFoShotgunRank.Name = "imgFoShotgunRank";
            this.imgFoShotgunRank.Size = new Size(10, 10);
            this.imgFoShotgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoShotgunRank.TabIndex = 0x68;
            this.imgFoShotgunRank.TabStop = false;
            this.imgFoClawRank.Image = Resources.rank_C;
            this.imgFoClawRank.Location = new Point(80, 0x2f);
            this.imgFoClawRank.Name = "imgFoClawRank";
            this.imgFoClawRank.Size = new Size(10, 10);
            this.imgFoClawRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoClawRank.TabIndex = 0x67;
            this.imgFoClawRank.TabStop = false;
            this.imgFoDaggersRank.Image = Resources.rank_C;
            this.imgFoDaggersRank.Location = new Point(80, 0x23);
            this.imgFoDaggersRank.Name = "imgFoDaggersRank";
            this.imgFoDaggersRank.Size = new Size(10, 10);
            this.imgFoDaggersRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoDaggersRank.TabIndex = 0x66;
            this.imgFoDaggersRank.TabStop = false;
            this.imgFoSpearRank.Image = Resources.rank_C;
            this.imgFoSpearRank.Location = new Point(80, 0x17);
            this.imgFoSpearRank.Name = "imgFoSpearRank";
            this.imgFoSpearRank.Size = new Size(10, 10);
            this.imgFoSpearRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSpearRank.TabIndex = 0x65;
            this.imgFoSpearRank.TabStop = false;
            this.imgFoWandRank.Image = Resources.rank_B;
            this.imgFoWandRank.Location = new Point(0x2c, 0x5f);
            this.imgFoWandRank.Name = "imgFoWandRank";
            this.imgFoWandRank.Size = new Size(10, 10);
            this.imgFoWandRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoWandRank.TabIndex = 100;
            this.imgFoWandRank.TabStop = false;
            this.imgFoCardsRank.Image = Resources.rank_B;
            this.imgFoCardsRank.Location = new Point(0x2c, 0x53);
            this.imgFoCardsRank.Name = "imgFoCardsRank";
            this.imgFoCardsRank.Size = new Size(10, 10);
            this.imgFoCardsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoCardsRank.TabIndex = 0x63;
            this.imgFoCardsRank.TabStop = false;
            this.imgFoLaserRank.Image = Resources.rank_B;
            this.imgFoLaserRank.Location = new Point(0x2c, 0x47);
            this.imgFoLaserRank.Name = "imgFoLaserRank";
            this.imgFoLaserRank.Size = new Size(10, 10);
            this.imgFoLaserRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoLaserRank.TabIndex = 0x62;
            this.imgFoLaserRank.TabStop = false;
            this.imgFoRifleRank.Image = Resources.rank_B;
            this.imgFoRifleRank.Location = new Point(0x2c, 0x3b);
            this.imgFoRifleRank.Name = "imgFoRifleRank";
            this.imgFoRifleRank.Size = new Size(10, 10);
            this.imgFoRifleRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoRifleRank.TabIndex = 0x61;
            this.imgFoRifleRank.TabStop = false;
            this.imgFoDaggerRank.Image = Resources.rank_B;
            this.imgFoDaggerRank.Location = new Point(0x2c, 0x2f);
            this.imgFoDaggerRank.Name = "imgFoDaggerRank";
            this.imgFoDaggerRank.Size = new Size(10, 10);
            this.imgFoDaggerRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoDaggerRank.TabIndex = 0x60;
            this.imgFoDaggerRank.TabStop = false;
            this.imgFoSabersRank.Image = Resources.rank_B;
            this.imgFoSabersRank.Location = new Point(0x2c, 0x23);
            this.imgFoSabersRank.Name = "imgFoSabersRank";
            this.imgFoSabersRank.Size = new Size(10, 10);
            this.imgFoSabersRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSabersRank.TabIndex = 0x5f;
            this.imgFoSabersRank.TabStop = false;
            this.imgFoKnucklesRank.Image = Resources.rank_B;
            this.imgFoKnucklesRank.Location = new Point(0x2c, 0x17);
            this.imgFoKnucklesRank.Name = "imgFoKnucklesRank";
            this.imgFoKnucklesRank.Size = new Size(10, 10);
            this.imgFoKnucklesRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoKnucklesRank.TabIndex = 0x5e;
            this.imgFoKnucklesRank.TabStop = false;
            this.imgFoShieldRank.Image = Resources.rank_B;
            this.imgFoShieldRank.Location = new Point(0x74, 0x5f);
            this.imgFoShieldRank.Name = "imgFoShieldRank";
            this.imgFoShieldRank.Size = new Size(10, 10);
            this.imgFoShieldRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoShieldRank.TabIndex = 0x5d;
            this.imgFoShieldRank.TabStop = false;
            this.imgFoRmagRank.Image = Resources.rank_B;
            this.imgFoRmagRank.Location = new Point(0x74, 0x53);
            this.imgFoRmagRank.Name = "imgFoRmagRank";
            this.imgFoRmagRank.Size = new Size(10, 10);
            this.imgFoRmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoRmagRank.TabIndex = 0x5c;
            this.imgFoRmagRank.TabStop = false;
            this.imgFoHandgunRank.Image = Resources.rank_B;
            this.imgFoHandgunRank.Location = new Point(0x74, 0x47);
            this.imgFoHandgunRank.Name = "imgFoHandgunRank";
            this.imgFoHandgunRank.Size = new Size(10, 10);
            this.imgFoHandgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoHandgunRank.TabIndex = 0x5b;
            this.imgFoHandgunRank.TabStop = false;
            this.imgFoLongbowRank.Image = Resources.rank_B;
            this.imgFoLongbowRank.Location = new Point(0x74, 0x3b);
            this.imgFoLongbowRank.Name = "imgFoLongbowRank";
            this.imgFoLongbowRank.Size = new Size(10, 10);
            this.imgFoLongbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoLongbowRank.TabIndex = 90;
            this.imgFoLongbowRank.TabStop = false;
            this.imgFoWhipRank.Image = Resources.rank_B;
            this.imgFoWhipRank.Location = new Point(0x74, 0x2f);
            this.imgFoWhipRank.Name = "imgFoWhipRank";
            this.imgFoWhipRank.Size = new Size(10, 10);
            this.imgFoWhipRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoWhipRank.TabIndex = 0x59;
            this.imgFoWhipRank.TabStop = false;
            this.imgFoClawsRank.Image = Resources.rank_B;
            this.imgFoClawsRank.Location = new Point(0x74, 0x23);
            this.imgFoClawsRank.Name = "imgFoClawsRank";
            this.imgFoClawsRank.Size = new Size(10, 10);
            this.imgFoClawsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoClawsRank.TabIndex = 0x58;
            this.imgFoClawsRank.TabStop = false;
            this.imgFoDblSaberRank.Image = Resources.rank_B;
            this.imgFoDblSaberRank.Location = new Point(0x74, 0x17);
            this.imgFoDblSaberRank.Name = "imgFoDblSaberRank";
            this.imgFoDblSaberRank.Size = new Size(10, 10);
            this.imgFoDblSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoDblSaberRank.TabIndex = 0x57;
            this.imgFoDblSaberRank.TabStop = false;
            this.imgFoRodRank.Image = Resources.rank_C;
            this.imgFoRodRank.Location = new Point(8, 0x5f);
            this.imgFoRodRank.Name = "imgFoRodRank";
            this.imgFoRodRank.Size = new Size(10, 10);
            this.imgFoRodRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoRodRank.TabIndex = 0x56;
            this.imgFoRodRank.TabStop = false;
            this.imgFoCrossbowRank.Image = Resources.rank_C;
            this.imgFoCrossbowRank.Location = new Point(8, 0x53);
            this.imgFoCrossbowRank.Name = "imgFoCrossbowRank";
            this.imgFoCrossbowRank.Size = new Size(10, 10);
            this.imgFoCrossbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoCrossbowRank.TabIndex = 0x55;
            this.imgFoCrossbowRank.TabStop = false;
            this.imgFoGrenadeRank.Image = Resources.rank_C;
            this.imgFoGrenadeRank.Location = new Point(8, 0x47);
            this.imgFoGrenadeRank.Name = "imgFoGrenadeRank";
            this.imgFoGrenadeRank.Size = new Size(10, 10);
            this.imgFoGrenadeRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoGrenadeRank.TabIndex = 0x54;
            this.imgFoGrenadeRank.TabStop = false;
            this.imgFoSlicerRank.Image = Resources.rank_C;
            this.imgFoSlicerRank.Location = new Point(8, 0x3b);
            this.imgFoSlicerRank.Name = "imgFoSlicerRank";
            this.imgFoSlicerRank.Size = new Size(10, 10);
            this.imgFoSlicerRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSlicerRank.TabIndex = 0x53;
            this.imgFoSlicerRank.TabStop = false;
            this.imgFoSaberRank.Image = Resources.rank_C;
            this.imgFoSaberRank.Location = new Point(8, 0x2f);
            this.imgFoSaberRank.Name = "imgFoSaberRank";
            this.imgFoSaberRank.Size = new Size(10, 10);
            this.imgFoSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSaberRank.TabIndex = 0x52;
            this.imgFoSaberRank.TabStop = false;
            this.imgFoAxeRank.Image = Resources.rank_C;
            this.imgFoAxeRank.Location = new Point(8, 0x23);
            this.imgFoAxeRank.Name = "imgFoAxeRank";
            this.imgFoAxeRank.Size = new Size(10, 10);
            this.imgFoAxeRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoAxeRank.TabIndex = 0x51;
            this.imgFoAxeRank.TabStop = false;
            this.imgFoSwordRank.Image = Resources.rank_C;
            this.imgFoSwordRank.Location = new Point(8, 0x17);
            this.imgFoSwordRank.Name = "imgFoSwordRank";
            this.imgFoSwordRank.Size = new Size(10, 10);
            this.imgFoSwordRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSwordRank.TabIndex = 80;
            this.imgFoSwordRank.TabStop = false;
            this.imgFoRmag.Image = Resources.weapon_rmag;
            this.imgFoRmag.Location = new Point(0x7f, 0x53);
            this.imgFoRmag.Name = "imgFoRmag";
            this.imgFoRmag.Size = new Size(10, 10);
            this.imgFoRmag.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoRmag.TabIndex = 0x4f;
            this.imgFoRmag.TabStop = false;
            this.imgFoMachinegun.Image = Resources.weapon_machinegun;
            this.imgFoMachinegun.Location = new Point(0x5b, 0x53);
            this.imgFoMachinegun.Name = "imgFoMachinegun";
            this.imgFoMachinegun.Size = new Size(10, 10);
            this.imgFoMachinegun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoMachinegun.TabIndex = 0x4e;
            this.imgFoMachinegun.TabStop = false;
            this.imgFoCrossbow.Image = Resources.weapon_crossbow;
            this.imgFoCrossbow.Location = new Point(0x13, 0x53);
            this.imgFoCrossbow.Name = "imgFoCrossbow";
            this.imgFoCrossbow.Size = new Size(10, 10);
            this.imgFoCrossbow.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoCrossbow.TabIndex = 0x4d;
            this.imgFoCrossbow.TabStop = false;
            this.imgFoCards.Image = Resources.weapon_card;
            this.imgFoCards.Location = new Point(0x37, 0x53);
            this.imgFoCards.Name = "imgFoCards";
            this.imgFoCards.Size = new Size(10, 10);
            this.imgFoCards.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoCards.TabIndex = 0x4c;
            this.imgFoCards.TabStop = false;
            this.imgFoHandgun.Image = Resources.weapon_handgun;
            this.imgFoHandgun.Location = new Point(0x7f, 0x47);
            this.imgFoHandgun.Name = "imgFoHandgun";
            this.imgFoHandgun.Size = new Size(10, 10);
            this.imgFoHandgun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoHandgun.TabIndex = 0x4b;
            this.imgFoHandgun.TabStop = false;
            this.imgFoHandguns.Image = Resources.weapon_handguns;
            this.imgFoHandguns.Location = new Point(0x5b, 0x47);
            this.imgFoHandguns.Name = "imgFoHandguns";
            this.imgFoHandguns.Size = new Size(0x17, 10);
            this.imgFoHandguns.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoHandguns.TabIndex = 0x4a;
            this.imgFoHandguns.TabStop = false;
            this.imgFoGrenade.Image = Resources.weapon_grenade;
            this.imgFoGrenade.Location = new Point(0x13, 0x47);
            this.imgFoGrenade.Name = "imgFoGrenade";
            this.imgFoGrenade.Size = new Size(0x17, 10);
            this.imgFoGrenade.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoGrenade.TabIndex = 0x49;
            this.imgFoGrenade.TabStop = false;
            this.imgFoLaser.Image = Resources.weapon_laser;
            this.imgFoLaser.Location = new Point(0x37, 0x47);
            this.imgFoLaser.Name = "imgFoLaser";
            this.imgFoLaser.Size = new Size(0x17, 10);
            this.imgFoLaser.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoLaser.TabIndex = 0x48;
            this.imgFoLaser.TabStop = false;
            this.imgFoLongbow.Image = Resources.weapon_longbow;
            this.imgFoLongbow.Location = new Point(0x7f, 0x3b);
            this.imgFoLongbow.Name = "imgFoLongbow";
            this.imgFoLongbow.Size = new Size(0x17, 10);
            this.imgFoLongbow.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoLongbow.TabIndex = 0x47;
            this.imgFoLongbow.TabStop = false;
            this.imgFoShotgun.Image = Resources.weapon_shotgun;
            this.imgFoShotgun.Location = new Point(0x5b, 0x3b);
            this.imgFoShotgun.Name = "imgFoShotgun";
            this.imgFoShotgun.Size = new Size(0x17, 10);
            this.imgFoShotgun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoShotgun.TabIndex = 70;
            this.imgFoShotgun.TabStop = false;
            this.imgFoSlicer.Image = Resources.weapon_slicer;
            this.imgFoSlicer.Location = new Point(0x13, 0x3b);
            this.imgFoSlicer.Name = "imgFoSlicer";
            this.imgFoSlicer.Size = new Size(10, 10);
            this.imgFoSlicer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSlicer.TabIndex = 0x45;
            this.imgFoSlicer.TabStop = false;
            this.imgFoRifle.Image = Resources.weapon_rifle;
            this.imgFoRifle.Location = new Point(0x37, 0x3b);
            this.imgFoRifle.Name = "imgFoRifle";
            this.imgFoRifle.Size = new Size(0x17, 10);
            this.imgFoRifle.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoRifle.TabIndex = 0x44;
            this.imgFoRifle.TabStop = false;
            this.imgFoWhip.Image = Resources.weapon_whip;
            this.imgFoWhip.Location = new Point(0x7f, 0x2f);
            this.imgFoWhip.Name = "imgFoWhip";
            this.imgFoWhip.Size = new Size(10, 10);
            this.imgFoWhip.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoWhip.TabIndex = 0x43;
            this.imgFoWhip.TabStop = false;
            this.imgFoClaw.Image = Resources.weapon_claw;
            this.imgFoClaw.Location = new Point(0x5b, 0x2f);
            this.imgFoClaw.Name = "imgFoClaw";
            this.imgFoClaw.Size = new Size(10, 10);
            this.imgFoClaw.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoClaw.TabIndex = 0x42;
            this.imgFoClaw.TabStop = false;
            this.imgFoSaber.Image = Resources.weapon_saber;
            this.imgFoSaber.Location = new Point(0x13, 0x2f);
            this.imgFoSaber.Name = "imgFoSaber";
            this.imgFoSaber.Size = new Size(10, 10);
            this.imgFoSaber.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSaber.TabIndex = 0x41;
            this.imgFoSaber.TabStop = false;
            this.imgFoDagger.Image = Resources.weapon_dagger;
            this.imgFoDagger.Location = new Point(0x37, 0x2f);
            this.imgFoDagger.Name = "imgFoDagger";
            this.imgFoDagger.Size = new Size(10, 10);
            this.imgFoDagger.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoDagger.TabIndex = 0x40;
            this.imgFoDagger.TabStop = false;
            this.imgFoShield.Image = Resources.weapon_shield;
            this.imgFoShield.Location = new Point(0x7f, 0x5f);
            this.imgFoShield.Name = "imgFoShield";
            this.imgFoShield.Size = new Size(10, 10);
            this.imgFoShield.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoShield.TabIndex = 0x3f;
            this.imgFoShield.TabStop = false;
            this.imgFoTmag.Image = Resources.weapon_tmag;
            this.imgFoTmag.Location = new Point(0x5b, 0x5f);
            this.imgFoTmag.Name = "imgFoTmag";
            this.imgFoTmag.Size = new Size(10, 10);
            this.imgFoTmag.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoTmag.TabIndex = 0x3e;
            this.imgFoTmag.TabStop = false;
            this.imgFoRod.Image = Resources.weapon_rod;
            this.imgFoRod.Location = new Point(0x13, 0x5f);
            this.imgFoRod.Name = "imgFoRod";
            this.imgFoRod.Size = new Size(0x17, 10);
            this.imgFoRod.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoRod.TabIndex = 0x3d;
            this.imgFoRod.TabStop = false;
            this.imgFoWand.Image = Resources.weapon_wand;
            this.imgFoWand.Location = new Point(0x37, 0x5f);
            this.imgFoWand.Name = "imgFoWand";
            this.imgFoWand.Size = new Size(10, 10);
            this.imgFoWand.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoWand.TabIndex = 60;
            this.imgFoWand.TabStop = false;
            this.imgFoClaws.Image = Resources.weapon_claws;
            this.imgFoClaws.Location = new Point(0x7f, 0x23);
            this.imgFoClaws.Name = "imgFoClaws";
            this.imgFoClaws.Size = new Size(0x17, 10);
            this.imgFoClaws.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoClaws.TabIndex = 0x3b;
            this.imgFoClaws.TabStop = false;
            this.imgFoDaggers.Image = Resources.weapon_daggers;
            this.imgFoDaggers.Location = new Point(0x5b, 0x23);
            this.imgFoDaggers.Name = "imgFoDaggers";
            this.imgFoDaggers.Size = new Size(0x17, 10);
            this.imgFoDaggers.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoDaggers.TabIndex = 0x3a;
            this.imgFoDaggers.TabStop = false;
            this.imgFoAxe.Image = Resources.weapon_axe;
            this.imgFoAxe.Location = new Point(0x13, 0x23);
            this.imgFoAxe.Name = "imgFoAxe";
            this.imgFoAxe.Size = new Size(0x17, 10);
            this.imgFoAxe.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoAxe.TabIndex = 0x39;
            this.imgFoAxe.TabStop = false;
            this.imgFoSabers.Image = Resources.weapon_sabers;
            this.imgFoSabers.Location = new Point(0x37, 0x23);
            this.imgFoSabers.Name = "imgFoSabers";
            this.imgFoSabers.Size = new Size(0x17, 10);
            this.imgFoSabers.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSabers.TabIndex = 0x38;
            this.imgFoSabers.TabStop = false;
            this.imgFoDblSaber.Image = Resources.weapon_double_saber;
            this.imgFoDblSaber.Location = new Point(0x7f, 0x17);
            this.imgFoDblSaber.Name = "imgFoDblSaber";
            this.imgFoDblSaber.Size = new Size(0x17, 10);
            this.imgFoDblSaber.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoDblSaber.TabIndex = 0x37;
            this.imgFoDblSaber.TabStop = false;
            this.imgFoKnuckles.Image = Resources.weapon_knuckles;
            this.imgFoKnuckles.Location = new Point(0x37, 0x17);
            this.imgFoKnuckles.Name = "imgFoKnuckles";
            this.imgFoKnuckles.Size = new Size(0x17, 10);
            this.imgFoKnuckles.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoKnuckles.TabIndex = 0x36;
            this.imgFoKnuckles.TabStop = false;
            this.imgFoSpear.Image = Resources.weapon_spear;
            this.imgFoSpear.Location = new Point(0x5b, 0x17);
            this.imgFoSpear.Name = "imgFoSpear";
            this.imgFoSpear.Size = new Size(0x17, 10);
            this.imgFoSpear.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSpear.TabIndex = 0x35;
            this.imgFoSpear.TabStop = false;
            this.imgFoSword.Image = Resources.weapon_sword;
            this.imgFoSword.Location = new Point(0x13, 0x17);
            this.imgFoSword.Name = "imgFoSword";
            this.imgFoSword.Size = new Size(0x17, 10);
            this.imgFoSword.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFoSword.TabIndex = 0x34;
            this.imgFoSword.TabStop = false;
            this.pictureBox117.Image = Resources.type_weapons;
            this.pictureBox117.Location = new Point(0x13, 0x17);
            this.pictureBox117.Name = "pictureBox117";
            this.pictureBox117.Size = new Size(0x83, 0x52);
            this.pictureBox117.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox117.TabIndex = 0x2f;
            this.pictureBox117.TabStop = false;
            this.lblFoLevel.AutoSize = true;
            this.lblFoLevel.Cursor = Cursors.Hand;
            this.lblFoLevel.Location = new Point(12, 0x20);
            this.lblFoLevel.Name = "lblFoLevel";
            this.lblFoLevel.Size = new Size(0x25, 13);
            this.lblFoLevel.TabIndex = 0x88;
            this.lblFoLevel.Text = "Level";
            this.lblFoLevel.Click += new EventHandler(this.classLevel_Click);
            this.txtFoLevel.AutoSize = true;
            this.txtFoLevel.Cursor = Cursors.Hand;
            this.txtFoLevel.Location = new Point(50, 0x20);
            this.txtFoLevel.Name = "txtFoLevel";
            this.txtFoLevel.Size = new Size(14, 13);
            this.txtFoLevel.TabIndex = 0x87;
            this.txtFoLevel.Text = "0";
            this.txtFoLevel.Click += new EventHandler(this.classLevel_Click);
            this.btnFoAbilitiesOpen.Cursor = Cursors.Hand;
            this.btnFoAbilitiesOpen.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnFoAbilitiesOpen.Location = new Point(0x21f, 8);
            this.btnFoAbilitiesOpen.Name = "btnFoAbilitiesOpen";
            this.btnFoAbilitiesOpen.Size = new Size(0x3d, 0x15);
            this.btnFoAbilitiesOpen.TabIndex = 0x8b;
            this.btnFoAbilitiesOpen.Text = "Abilities";
            this.btnFoAbilitiesOpen.UseVisualStyleBackColor = true;
            this.btnFoAbilitiesOpen.Click += new EventHandler(this.btnFoAbilitiesOpen_Click);
            this.tabPageVanguard.Controls.Add(this.label27);
            this.tabPageVanguard.Controls.Add(this.grpVaTypeExtend);
            this.tabPageVanguard.Controls.Add(this.txtVaLevel);
            this.tabPageVanguard.Controls.Add(this.lblVaLevel);
            this.tabPageVanguard.Controls.Add(this.btnVaAbilitiesOpen);
            this.tabPageVanguard.Font = new Font("Verdana", 8.25f);
            this.tabPageVanguard.Location = new Point(4, 0x15);
            this.tabPageVanguard.Name = "tabPageVanguard";
            this.tabPageVanguard.Padding = new Padding(3);
            this.tabPageVanguard.Size = new Size(610, 0xc0);
            this.tabPageVanguard.TabIndex = 3;
            this.tabPageVanguard.Text = "Vanguard (0)";
            this.tabPageVanguard.UseVisualStyleBackColor = true;
            this.label27.AutoSize = true;
            this.label27.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label27.Location = new Point(11, 13);
            this.label27.Name = "label27";
            this.label27.Size = new Size(0x4e, 0x10);
            this.label27.TabIndex = 0x8a;
            this.label27.Text = "Vanguard";
            this.grpVaTypeExtend.Controls.Add(this.txtVaExp);
            this.grpVaTypeExtend.Controls.Add(this.imgVaTmagRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaMachinegunRank);
            this.grpVaTypeExtend.Controls.Add(this.txtVaExpBar);
            this.grpVaTypeExtend.Controls.Add(this.label28);
            this.grpVaTypeExtend.Controls.Add(this.imgVaHandgunsRank);
            this.grpVaTypeExtend.Controls.Add(this.label29);
            this.grpVaTypeExtend.Controls.Add(this.imgVaShotgunRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaClawRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaDaggersRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSpearRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaWandRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaCardsRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaLaserRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaRifleRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaDaggerRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSabersRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaKnucklesRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaShieldRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaRmagRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaHandgunRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaLongbowRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaWhipRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaClawsRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaDblSaberRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaRodRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaCrossbowRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaGrenadeRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSlicerRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSaberRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaAxeRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSwordRank);
            this.grpVaTypeExtend.Controls.Add(this.imgVaRmag);
            this.grpVaTypeExtend.Controls.Add(this.imgVaMachinegun);
            this.grpVaTypeExtend.Controls.Add(this.imgVaCrossbow);
            this.grpVaTypeExtend.Controls.Add(this.imgVaCards);
            this.grpVaTypeExtend.Controls.Add(this.imgVaHandgun);
            this.grpVaTypeExtend.Controls.Add(this.imgVaHandguns);
            this.grpVaTypeExtend.Controls.Add(this.imgVaGrenade);
            this.grpVaTypeExtend.Controls.Add(this.imgVaLaser);
            this.grpVaTypeExtend.Controls.Add(this.imgVaLongbow);
            this.grpVaTypeExtend.Controls.Add(this.imgVaShotgun);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSlicer);
            this.grpVaTypeExtend.Controls.Add(this.imgVaRifle);
            this.grpVaTypeExtend.Controls.Add(this.imgVaWhip);
            this.grpVaTypeExtend.Controls.Add(this.imgVaClaw);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSaber);
            this.grpVaTypeExtend.Controls.Add(this.imgVaDagger);
            this.grpVaTypeExtend.Controls.Add(this.imgVaShield);
            this.grpVaTypeExtend.Controls.Add(this.imgVaTmag);
            this.grpVaTypeExtend.Controls.Add(this.imgVaRod);
            this.grpVaTypeExtend.Controls.Add(this.imgVaWand);
            this.grpVaTypeExtend.Controls.Add(this.imgVaClaws);
            this.grpVaTypeExtend.Controls.Add(this.imgVaDaggers);
            this.grpVaTypeExtend.Controls.Add(this.imgVaAxe);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSabers);
            this.grpVaTypeExtend.Controls.Add(this.imgVaDblSaber);
            this.grpVaTypeExtend.Controls.Add(this.imgVaKnuckles);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSpear);
            this.grpVaTypeExtend.Controls.Add(this.imgVaSword);
            this.grpVaTypeExtend.Controls.Add(this.pictureBox5);
            this.grpVaTypeExtend.Location = new Point(10, 0x3a);
            this.grpVaTypeExtend.Name = "grpVaTypeExtend";
            this.grpVaTypeExtend.Size = new Size(0x130, 0x77);
            this.grpVaTypeExtend.TabIndex = 0x89;
            this.grpVaTypeExtend.TabStop = false;
            this.grpVaTypeExtend.Text = "Type Extend 0/0";
            this.txtVaExp.BackColor = Color.Transparent;
            this.txtVaExp.Font = new Font("Verdana", 6.75f);
            this.txtVaExp.Location = new Point(0xc2, 0x24);
            this.txtVaExp.Name = "txtVaExp";
            this.txtVaExp.Size = new Size(0x66, 0x45);
            this.txtVaExp.TabIndex = 110;
            this.txtVaExp.TextAlign = ContentAlignment.TopRight;
            this.imgVaTmagRank.Image = Resources.rank_C;
            this.imgVaTmagRank.Location = new Point(80, 0x5f);
            this.imgVaTmagRank.Name = "imgVaTmagRank";
            this.imgVaTmagRank.Size = new Size(10, 10);
            this.imgVaTmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaTmagRank.TabIndex = 0x6b;
            this.imgVaTmagRank.TabStop = false;
            this.imgVaMachinegunRank.Image = Resources.rank_C;
            this.imgVaMachinegunRank.Location = new Point(80, 0x53);
            this.imgVaMachinegunRank.Name = "imgVaMachinegunRank";
            this.imgVaMachinegunRank.Size = new Size(10, 10);
            this.imgVaMachinegunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaMachinegunRank.TabIndex = 0x6a;
            this.imgVaMachinegunRank.TabStop = false;
            this.txtVaExpBar.BackColor = Color.Red;
            this.txtVaExpBar.Location = new Point(0xc3, 0x17);
            this.txtVaExpBar.Name = "txtVaExpBar";
            this.txtVaExpBar.Size = new Size(0x57, 8);
            this.txtVaExpBar.TabIndex = 0x31;
            this.label28.AutoSize = true;
            this.label28.Location = new Point(0x9f, 20);
            this.label28.Name = "label28";
            this.label28.Size = new Size(0x1d, 13);
            this.label28.TabIndex = 0x30;
            this.label28.Text = "EXP";
            this.imgVaHandgunsRank.Image = Resources.rank_C;
            this.imgVaHandgunsRank.Location = new Point(80, 0x47);
            this.imgVaHandgunsRank.Name = "imgVaHandgunsRank";
            this.imgVaHandgunsRank.Size = new Size(10, 10);
            this.imgVaHandgunsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaHandgunsRank.TabIndex = 0x69;
            this.imgVaHandgunsRank.TabStop = false;
            this.label29.BackColor = Color.Gainsboro;
            this.label29.BorderStyle = BorderStyle.FixedSingle;
            this.label29.Location = new Point(0xc2, 0x16);
            this.label29.Name = "label29";
            this.label29.Size = new Size(0x66, 10);
            this.label29.TabIndex = 50;
            this.imgVaShotgunRank.Image = Resources.rank_C;
            this.imgVaShotgunRank.Location = new Point(80, 0x3b);
            this.imgVaShotgunRank.Name = "imgVaShotgunRank";
            this.imgVaShotgunRank.Size = new Size(10, 10);
            this.imgVaShotgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaShotgunRank.TabIndex = 0x68;
            this.imgVaShotgunRank.TabStop = false;
            this.imgVaClawRank.Image = Resources.rank_C;
            this.imgVaClawRank.Location = new Point(80, 0x2f);
            this.imgVaClawRank.Name = "imgVaClawRank";
            this.imgVaClawRank.Size = new Size(10, 10);
            this.imgVaClawRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaClawRank.TabIndex = 0x67;
            this.imgVaClawRank.TabStop = false;
            this.imgVaDaggersRank.Image = Resources.rank_C;
            this.imgVaDaggersRank.Location = new Point(80, 0x23);
            this.imgVaDaggersRank.Name = "imgVaDaggersRank";
            this.imgVaDaggersRank.Size = new Size(10, 10);
            this.imgVaDaggersRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaDaggersRank.TabIndex = 0x66;
            this.imgVaDaggersRank.TabStop = false;
            this.imgVaSpearRank.Image = Resources.rank_C;
            this.imgVaSpearRank.Location = new Point(80, 0x17);
            this.imgVaSpearRank.Name = "imgVaSpearRank";
            this.imgVaSpearRank.Size = new Size(10, 10);
            this.imgVaSpearRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSpearRank.TabIndex = 0x65;
            this.imgVaSpearRank.TabStop = false;
            this.imgVaWandRank.Image = Resources.rank_B;
            this.imgVaWandRank.Location = new Point(0x2c, 0x5f);
            this.imgVaWandRank.Name = "imgVaWandRank";
            this.imgVaWandRank.Size = new Size(10, 10);
            this.imgVaWandRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaWandRank.TabIndex = 100;
            this.imgVaWandRank.TabStop = false;
            this.imgVaCardsRank.Image = Resources.rank_B;
            this.imgVaCardsRank.Location = new Point(0x2c, 0x53);
            this.imgVaCardsRank.Name = "imgVaCardsRank";
            this.imgVaCardsRank.Size = new Size(10, 10);
            this.imgVaCardsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaCardsRank.TabIndex = 0x63;
            this.imgVaCardsRank.TabStop = false;
            this.imgVaLaserRank.Image = Resources.rank_B;
            this.imgVaLaserRank.Location = new Point(0x2c, 0x47);
            this.imgVaLaserRank.Name = "imgVaLaserRank";
            this.imgVaLaserRank.Size = new Size(10, 10);
            this.imgVaLaserRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaLaserRank.TabIndex = 0x62;
            this.imgVaLaserRank.TabStop = false;
            this.imgVaRifleRank.Image = Resources.rank_B;
            this.imgVaRifleRank.Location = new Point(0x2c, 0x3b);
            this.imgVaRifleRank.Name = "imgVaRifleRank";
            this.imgVaRifleRank.Size = new Size(10, 10);
            this.imgVaRifleRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaRifleRank.TabIndex = 0x61;
            this.imgVaRifleRank.TabStop = false;
            this.imgVaDaggerRank.Image = Resources.rank_B;
            this.imgVaDaggerRank.Location = new Point(0x2c, 0x2f);
            this.imgVaDaggerRank.Name = "imgVaDaggerRank";
            this.imgVaDaggerRank.Size = new Size(10, 10);
            this.imgVaDaggerRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaDaggerRank.TabIndex = 0x60;
            this.imgVaDaggerRank.TabStop = false;
            this.imgVaSabersRank.Image = Resources.rank_B;
            this.imgVaSabersRank.Location = new Point(0x2c, 0x23);
            this.imgVaSabersRank.Name = "imgVaSabersRank";
            this.imgVaSabersRank.Size = new Size(10, 10);
            this.imgVaSabersRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSabersRank.TabIndex = 0x5f;
            this.imgVaSabersRank.TabStop = false;
            this.imgVaKnucklesRank.Image = Resources.rank_B;
            this.imgVaKnucklesRank.Location = new Point(0x2c, 0x17);
            this.imgVaKnucklesRank.Name = "imgVaKnucklesRank";
            this.imgVaKnucklesRank.Size = new Size(10, 10);
            this.imgVaKnucklesRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaKnucklesRank.TabIndex = 0x5e;
            this.imgVaKnucklesRank.TabStop = false;
            this.imgVaShieldRank.Image = Resources.rank_B;
            this.imgVaShieldRank.Location = new Point(0x74, 0x5f);
            this.imgVaShieldRank.Name = "imgVaShieldRank";
            this.imgVaShieldRank.Size = new Size(10, 10);
            this.imgVaShieldRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaShieldRank.TabIndex = 0x5d;
            this.imgVaShieldRank.TabStop = false;
            this.imgVaRmagRank.Image = Resources.rank_B;
            this.imgVaRmagRank.Location = new Point(0x74, 0x53);
            this.imgVaRmagRank.Name = "imgVaRmagRank";
            this.imgVaRmagRank.Size = new Size(10, 10);
            this.imgVaRmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaRmagRank.TabIndex = 0x5c;
            this.imgVaRmagRank.TabStop = false;
            this.imgVaHandgunRank.Image = Resources.rank_B;
            this.imgVaHandgunRank.Location = new Point(0x74, 0x47);
            this.imgVaHandgunRank.Name = "imgVaHandgunRank";
            this.imgVaHandgunRank.Size = new Size(10, 10);
            this.imgVaHandgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaHandgunRank.TabIndex = 0x5b;
            this.imgVaHandgunRank.TabStop = false;
            this.imgVaLongbowRank.Image = Resources.rank_B;
            this.imgVaLongbowRank.Location = new Point(0x74, 0x3b);
            this.imgVaLongbowRank.Name = "imgVaLongbowRank";
            this.imgVaLongbowRank.Size = new Size(10, 10);
            this.imgVaLongbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaLongbowRank.TabIndex = 90;
            this.imgVaLongbowRank.TabStop = false;
            this.imgVaWhipRank.Image = Resources.rank_B;
            this.imgVaWhipRank.Location = new Point(0x74, 0x2f);
            this.imgVaWhipRank.Name = "imgVaWhipRank";
            this.imgVaWhipRank.Size = new Size(10, 10);
            this.imgVaWhipRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaWhipRank.TabIndex = 0x59;
            this.imgVaWhipRank.TabStop = false;
            this.imgVaClawsRank.Image = Resources.rank_B;
            this.imgVaClawsRank.Location = new Point(0x74, 0x23);
            this.imgVaClawsRank.Name = "imgVaClawsRank";
            this.imgVaClawsRank.Size = new Size(10, 10);
            this.imgVaClawsRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaClawsRank.TabIndex = 0x58;
            this.imgVaClawsRank.TabStop = false;
            this.imgVaDblSaberRank.Image = Resources.rank_B;
            this.imgVaDblSaberRank.Location = new Point(0x74, 0x17);
            this.imgVaDblSaberRank.Name = "imgVaDblSaberRank";
            this.imgVaDblSaberRank.Size = new Size(10, 10);
            this.imgVaDblSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaDblSaberRank.TabIndex = 0x57;
            this.imgVaDblSaberRank.TabStop = false;
            this.imgVaRodRank.Image = Resources.rank_C;
            this.imgVaRodRank.Location = new Point(8, 0x5f);
            this.imgVaRodRank.Name = "imgVaRodRank";
            this.imgVaRodRank.Size = new Size(10, 10);
            this.imgVaRodRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaRodRank.TabIndex = 0x56;
            this.imgVaRodRank.TabStop = false;
            this.imgVaCrossbowRank.Image = Resources.rank_C;
            this.imgVaCrossbowRank.Location = new Point(8, 0x53);
            this.imgVaCrossbowRank.Name = "imgVaCrossbowRank";
            this.imgVaCrossbowRank.Size = new Size(10, 10);
            this.imgVaCrossbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaCrossbowRank.TabIndex = 0x55;
            this.imgVaCrossbowRank.TabStop = false;
            this.imgVaGrenadeRank.Image = Resources.rank_C;
            this.imgVaGrenadeRank.Location = new Point(8, 0x47);
            this.imgVaGrenadeRank.Name = "imgVaGrenadeRank";
            this.imgVaGrenadeRank.Size = new Size(10, 10);
            this.imgVaGrenadeRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaGrenadeRank.TabIndex = 0x54;
            this.imgVaGrenadeRank.TabStop = false;
            this.imgVaSlicerRank.Image = Resources.rank_C;
            this.imgVaSlicerRank.Location = new Point(8, 0x3b);
            this.imgVaSlicerRank.Name = "imgVaSlicerRank";
            this.imgVaSlicerRank.Size = new Size(10, 10);
            this.imgVaSlicerRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSlicerRank.TabIndex = 0x53;
            this.imgVaSlicerRank.TabStop = false;
            this.imgVaSaberRank.Image = Resources.rank_C;
            this.imgVaSaberRank.Location = new Point(8, 0x2f);
            this.imgVaSaberRank.Name = "imgVaSaberRank";
            this.imgVaSaberRank.Size = new Size(10, 10);
            this.imgVaSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSaberRank.TabIndex = 0x52;
            this.imgVaSaberRank.TabStop = false;
            this.imgVaAxeRank.Image = Resources.rank_C;
            this.imgVaAxeRank.Location = new Point(8, 0x23);
            this.imgVaAxeRank.Name = "imgVaAxeRank";
            this.imgVaAxeRank.Size = new Size(10, 10);
            this.imgVaAxeRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaAxeRank.TabIndex = 0x51;
            this.imgVaAxeRank.TabStop = false;
            this.imgVaSwordRank.Image = Resources.rank_C;
            this.imgVaSwordRank.Location = new Point(8, 0x17);
            this.imgVaSwordRank.Name = "imgVaSwordRank";
            this.imgVaSwordRank.Size = new Size(10, 10);
            this.imgVaSwordRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSwordRank.TabIndex = 80;
            this.imgVaSwordRank.TabStop = false;
            this.imgVaRmag.Image = Resources.weapon_rmag;
            this.imgVaRmag.Location = new Point(0x7f, 0x53);
            this.imgVaRmag.Name = "imgVaRmag";
            this.imgVaRmag.Size = new Size(10, 10);
            this.imgVaRmag.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaRmag.TabIndex = 0x4f;
            this.imgVaRmag.TabStop = false;
            this.imgVaMachinegun.Image = Resources.weapon_machinegun;
            this.imgVaMachinegun.Location = new Point(0x5b, 0x53);
            this.imgVaMachinegun.Name = "imgVaMachinegun";
            this.imgVaMachinegun.Size = new Size(10, 10);
            this.imgVaMachinegun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaMachinegun.TabIndex = 0x4e;
            this.imgVaMachinegun.TabStop = false;
            this.imgVaCrossbow.Image = Resources.weapon_crossbow;
            this.imgVaCrossbow.Location = new Point(0x13, 0x53);
            this.imgVaCrossbow.Name = "imgVaCrossbow";
            this.imgVaCrossbow.Size = new Size(10, 10);
            this.imgVaCrossbow.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaCrossbow.TabIndex = 0x4d;
            this.imgVaCrossbow.TabStop = false;
            this.imgVaCards.Image = Resources.weapon_card;
            this.imgVaCards.Location = new Point(0x37, 0x53);
            this.imgVaCards.Name = "imgVaCards";
            this.imgVaCards.Size = new Size(10, 10);
            this.imgVaCards.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaCards.TabIndex = 0x4c;
            this.imgVaCards.TabStop = false;
            this.imgVaHandgun.Image = Resources.weapon_handgun;
            this.imgVaHandgun.Location = new Point(0x7f, 0x47);
            this.imgVaHandgun.Name = "imgVaHandgun";
            this.imgVaHandgun.Size = new Size(10, 10);
            this.imgVaHandgun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaHandgun.TabIndex = 0x4b;
            this.imgVaHandgun.TabStop = false;
            this.imgVaHandguns.Image = Resources.weapon_handguns;
            this.imgVaHandguns.Location = new Point(0x5b, 0x47);
            this.imgVaHandguns.Name = "imgVaHandguns";
            this.imgVaHandguns.Size = new Size(0x17, 10);
            this.imgVaHandguns.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaHandguns.TabIndex = 0x4a;
            this.imgVaHandguns.TabStop = false;
            this.imgVaGrenade.Image = Resources.weapon_grenade;
            this.imgVaGrenade.Location = new Point(0x13, 0x47);
            this.imgVaGrenade.Name = "imgVaGrenade";
            this.imgVaGrenade.Size = new Size(0x17, 10);
            this.imgVaGrenade.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaGrenade.TabIndex = 0x49;
            this.imgVaGrenade.TabStop = false;
            this.imgVaLaser.Image = Resources.weapon_laser;
            this.imgVaLaser.Location = new Point(0x37, 0x47);
            this.imgVaLaser.Name = "imgVaLaser";
            this.imgVaLaser.Size = new Size(0x17, 10);
            this.imgVaLaser.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaLaser.TabIndex = 0x48;
            this.imgVaLaser.TabStop = false;
            this.imgVaLongbow.Image = Resources.weapon_longbow;
            this.imgVaLongbow.Location = new Point(0x7f, 0x3b);
            this.imgVaLongbow.Name = "imgVaLongbow";
            this.imgVaLongbow.Size = new Size(0x17, 10);
            this.imgVaLongbow.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaLongbow.TabIndex = 0x47;
            this.imgVaLongbow.TabStop = false;
            this.imgVaShotgun.Image = Resources.weapon_shotgun;
            this.imgVaShotgun.Location = new Point(0x5b, 0x3b);
            this.imgVaShotgun.Name = "imgVaShotgun";
            this.imgVaShotgun.Size = new Size(0x17, 10);
            this.imgVaShotgun.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaShotgun.TabIndex = 70;
            this.imgVaShotgun.TabStop = false;
            this.imgVaSlicer.Image = Resources.weapon_slicer;
            this.imgVaSlicer.Location = new Point(0x13, 0x3b);
            this.imgVaSlicer.Name = "imgVaSlicer";
            this.imgVaSlicer.Size = new Size(10, 10);
            this.imgVaSlicer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSlicer.TabIndex = 0x45;
            this.imgVaSlicer.TabStop = false;
            this.imgVaRifle.Image = Resources.weapon_rifle;
            this.imgVaRifle.Location = new Point(0x37, 0x3b);
            this.imgVaRifle.Name = "imgVaRifle";
            this.imgVaRifle.Size = new Size(0x17, 10);
            this.imgVaRifle.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaRifle.TabIndex = 0x44;
            this.imgVaRifle.TabStop = false;
            this.imgVaWhip.Image = Resources.weapon_whip;
            this.imgVaWhip.Location = new Point(0x7f, 0x2f);
            this.imgVaWhip.Name = "imgVaWhip";
            this.imgVaWhip.Size = new Size(10, 10);
            this.imgVaWhip.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaWhip.TabIndex = 0x43;
            this.imgVaWhip.TabStop = false;
            this.imgVaClaw.Image = Resources.weapon_claw;
            this.imgVaClaw.Location = new Point(0x5b, 0x2f);
            this.imgVaClaw.Name = "imgVaClaw";
            this.imgVaClaw.Size = new Size(10, 10);
            this.imgVaClaw.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaClaw.TabIndex = 0x42;
            this.imgVaClaw.TabStop = false;
            this.imgVaSaber.Image = Resources.weapon_saber;
            this.imgVaSaber.Location = new Point(0x13, 0x2f);
            this.imgVaSaber.Name = "imgVaSaber";
            this.imgVaSaber.Size = new Size(10, 10);
            this.imgVaSaber.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSaber.TabIndex = 0x41;
            this.imgVaSaber.TabStop = false;
            this.imgVaDagger.Image = Resources.weapon_dagger;
            this.imgVaDagger.Location = new Point(0x37, 0x2f);
            this.imgVaDagger.Name = "imgVaDagger";
            this.imgVaDagger.Size = new Size(10, 10);
            this.imgVaDagger.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaDagger.TabIndex = 0x40;
            this.imgVaDagger.TabStop = false;
            this.imgVaShield.Image = Resources.weapon_shield;
            this.imgVaShield.Location = new Point(0x7f, 0x5f);
            this.imgVaShield.Name = "imgVaShield";
            this.imgVaShield.Size = new Size(10, 10);
            this.imgVaShield.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaShield.TabIndex = 0x3f;
            this.imgVaShield.TabStop = false;
            this.imgVaTmag.Image = Resources.weapon_tmag;
            this.imgVaTmag.Location = new Point(0x5b, 0x5f);
            this.imgVaTmag.Name = "imgVaTmag";
            this.imgVaTmag.Size = new Size(10, 10);
            this.imgVaTmag.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaTmag.TabIndex = 0x3e;
            this.imgVaTmag.TabStop = false;
            this.imgVaRod.Image = Resources.weapon_rod;
            this.imgVaRod.Location = new Point(0x13, 0x5f);
            this.imgVaRod.Name = "imgVaRod";
            this.imgVaRod.Size = new Size(0x17, 10);
            this.imgVaRod.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaRod.TabIndex = 0x3d;
            this.imgVaRod.TabStop = false;
            this.imgVaWand.Image = Resources.weapon_wand;
            this.imgVaWand.Location = new Point(0x37, 0x5f);
            this.imgVaWand.Name = "imgVaWand";
            this.imgVaWand.Size = new Size(10, 10);
            this.imgVaWand.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaWand.TabIndex = 60;
            this.imgVaWand.TabStop = false;
            this.imgVaClaws.Image = Resources.weapon_claws;
            this.imgVaClaws.Location = new Point(0x7f, 0x23);
            this.imgVaClaws.Name = "imgVaClaws";
            this.imgVaClaws.Size = new Size(0x17, 10);
            this.imgVaClaws.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaClaws.TabIndex = 0x3b;
            this.imgVaClaws.TabStop = false;
            this.imgVaDaggers.Image = Resources.weapon_daggers;
            this.imgVaDaggers.Location = new Point(0x5b, 0x23);
            this.imgVaDaggers.Name = "imgVaDaggers";
            this.imgVaDaggers.Size = new Size(0x17, 10);
            this.imgVaDaggers.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaDaggers.TabIndex = 0x3a;
            this.imgVaDaggers.TabStop = false;
            this.imgVaAxe.Image = Resources.weapon_axe;
            this.imgVaAxe.Location = new Point(0x13, 0x23);
            this.imgVaAxe.Name = "imgVaAxe";
            this.imgVaAxe.Size = new Size(0x17, 10);
            this.imgVaAxe.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaAxe.TabIndex = 0x39;
            this.imgVaAxe.TabStop = false;
            this.imgVaSabers.Image = Resources.weapon_sabers;
            this.imgVaSabers.Location = new Point(0x37, 0x23);
            this.imgVaSabers.Name = "imgVaSabers";
            this.imgVaSabers.Size = new Size(0x17, 10);
            this.imgVaSabers.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSabers.TabIndex = 0x38;
            this.imgVaSabers.TabStop = false;
            this.imgVaDblSaber.Image = Resources.weapon_double_saber;
            this.imgVaDblSaber.Location = new Point(0x7f, 0x17);
            this.imgVaDblSaber.Name = "imgVaDblSaber";
            this.imgVaDblSaber.Size = new Size(0x17, 10);
            this.imgVaDblSaber.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaDblSaber.TabIndex = 0x37;
            this.imgVaDblSaber.TabStop = false;
            this.imgVaKnuckles.Image = Resources.weapon_knuckles;
            this.imgVaKnuckles.Location = new Point(0x37, 0x17);
            this.imgVaKnuckles.Name = "imgVaKnuckles";
            this.imgVaKnuckles.Size = new Size(0x17, 10);
            this.imgVaKnuckles.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaKnuckles.TabIndex = 0x36;
            this.imgVaKnuckles.TabStop = false;
            this.imgVaSpear.Image = Resources.weapon_spear;
            this.imgVaSpear.Location = new Point(0x5b, 0x17);
            this.imgVaSpear.Name = "imgVaSpear";
            this.imgVaSpear.Size = new Size(0x17, 10);
            this.imgVaSpear.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSpear.TabIndex = 0x35;
            this.imgVaSpear.TabStop = false;
            this.imgVaSword.Image = Resources.weapon_sword;
            this.imgVaSword.Location = new Point(0x13, 0x17);
            this.imgVaSword.Name = "imgVaSword";
            this.imgVaSword.Size = new Size(0x17, 10);
            this.imgVaSword.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgVaSword.TabIndex = 0x34;
            this.imgVaSword.TabStop = false;
            this.pictureBox5.Image = Resources.type_weapons;
            this.pictureBox5.Location = new Point(0x13, 0x17);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new Size(0x83, 0x52);
            this.pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 0x2f;
            this.pictureBox5.TabStop = false;
            this.txtVaLevel.AutoSize = true;
            this.txtVaLevel.Cursor = Cursors.Hand;
            this.txtVaLevel.Location = new Point(50, 0x20);
            this.txtVaLevel.Name = "txtVaLevel";
            this.txtVaLevel.Size = new Size(14, 13);
            this.txtVaLevel.TabIndex = 0x88;
            this.txtVaLevel.Text = "0";
            this.txtVaLevel.Click += new EventHandler(this.classLevel_Click);
            this.lblVaLevel.AutoSize = true;
            this.lblVaLevel.Cursor = Cursors.Hand;
            this.lblVaLevel.Location = new Point(12, 0x20);
            this.lblVaLevel.Name = "lblVaLevel";
            this.lblVaLevel.Size = new Size(0x25, 13);
            this.lblVaLevel.TabIndex = 0x87;
            this.lblVaLevel.Text = "Level";
            this.lblVaLevel.Click += new EventHandler(this.classLevel_Click);
            this.btnVaAbilitiesOpen.Cursor = Cursors.Hand;
            this.btnVaAbilitiesOpen.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnVaAbilitiesOpen.Location = new Point(0x21f, 8);
            this.btnVaAbilitiesOpen.Name = "btnVaAbilitiesOpen";
            this.btnVaAbilitiesOpen.Size = new Size(0x3d, 0x15);
            this.btnVaAbilitiesOpen.TabIndex = 0x8b;
            this.btnVaAbilitiesOpen.Text = "Abilities";
            this.btnVaAbilitiesOpen.UseVisualStyleBackColor = true;
            this.btnVaAbilitiesOpen.Click += new EventHandler(this.btnVaAbilitiesOpen_Click);
            this.tabPageInventory.Controls.Add(this.btnInventoryDelete);
            this.tabPageInventory.Controls.Add(this.chkDeleteExportInventory);
            this.tabPageInventory.Controls.Add(this.btnInventoryDeposit);
            this.tabPageInventory.Controls.Add(this.inventoryViewPages);
            this.tabPageInventory.Controls.Add(this.btnInventoryImportSelected);
            this.tabPageInventory.Controls.Add(this.btnInventoryExportSelected);
            this.tabPageInventory.Controls.Add(this.btnInventoryImportAll);
            this.tabPageInventory.Controls.Add(this.btnInventoryExportAll);
            this.tabPageInventory.Controls.Add(this.txtInventoryMeseta);
            this.tabPageInventory.Controls.Add(this.lblInventoryMeseta);
            this.tabPageInventory.Controls.Add(this.grpInventoryItemDetails);
            this.tabPageInventory.Controls.Add(this.groupBox2);
            this.tabPageInventory.Controls.Add(this.txtInventoryHex);
            this.tabPageInventory.Controls.Add(this.pictureBox7);
            this.tabPageInventory.Controls.Add(this.inventoryView);
            this.tabPageInventory.Cursor = Cursors.Default;
            this.tabPageInventory.Location = new Point(4, 0x16);
            this.tabPageInventory.Name = "tabPageInventory";
            this.tabPageInventory.Size = new Size(0x275, 0xdf);
            this.tabPageInventory.TabIndex = 6;
            this.tabPageInventory.Text = "Inventory (0/60)";
            this.tabPageInventory.UseVisualStyleBackColor = true;
            this.btnInventoryDelete.Cursor = Cursors.Hand;
            this.btnInventoryDelete.Enabled = false;
            this.btnInventoryDelete.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnInventoryDelete.Location = new Point(0x187, 0xb1);
            this.btnInventoryDelete.Name = "btnInventoryDelete";
            this.btnInventoryDelete.Size = new Size(0x2e, 0x15);
            this.btnInventoryDelete.TabIndex = 0x4c;
            this.btnInventoryDelete.Text = "delete";
            this.btnInventoryDelete.UseVisualStyleBackColor = true;
            this.btnInventoryDelete.Click += new EventHandler(this.btnInventoryDelete_Click);
            this.chkDeleteExportInventory.AutoSize = true;
            this.chkDeleteExportInventory.Cursor = Cursors.Hand;
            this.chkDeleteExportInventory.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chkDeleteExportInventory.Location = new Point(0x1f1, 0xce);
            this.chkDeleteExportInventory.Name = "chkDeleteExportInventory";
            this.chkDeleteExportInventory.RightToLeft = RightToLeft.Yes;
            this.chkDeleteExportInventory.Size = new Size(0x7d, 14);
            this.chkDeleteExportInventory.TabIndex = 0x4b;
            this.chkDeleteExportInventory.Text = "delete items after export";
            this.chkDeleteExportInventory.UseVisualStyleBackColor = true;
            this.btnInventoryDeposit.Cursor = Cursors.Hand;
            this.btnInventoryDeposit.Enabled = false;
            this.btnInventoryDeposit.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnInventoryDeposit.Location = new Point(0x236, 0xb1);
            this.btnInventoryDeposit.Name = "btnInventoryDeposit";
            this.btnInventoryDeposit.Size = new Size(0x38, 0x15);
            this.btnInventoryDeposit.TabIndex = 0x4a;
            this.btnInventoryDeposit.Text = "deposit";
            this.btnInventoryDeposit.UseVisualStyleBackColor = true;
            this.btnInventoryDeposit.Click += new EventHandler(this.btnInventoryDeposit_Click);
            this.inventoryViewPages.Controls.Add(this.tabInventory1);
            this.inventoryViewPages.Controls.Add(this.tabInventory2);
            this.inventoryViewPages.Controls.Add(this.tabInventory3);
            this.inventoryViewPages.Controls.Add(this.tabInventory4);
            this.inventoryViewPages.Controls.Add(this.tabInventory5);
            this.inventoryViewPages.Controls.Add(this.tabInventory6);
            this.inventoryViewPages.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.inventoryViewPages.Location = new Point(5, 12);
            this.inventoryViewPages.Name = "inventoryViewPages";
            this.inventoryViewPages.SelectedIndex = 0;
            this.inventoryViewPages.Size = new Size(0x13b, 0x13);
            this.inventoryViewPages.TabIndex = 0x49;
            this.inventoryViewPages.SelectedIndexChanged += new EventHandler(this.inventoryViewPages_SelectedIndexChanged);
            this.tabInventory1.Cursor = Cursors.Default;
            this.tabInventory1.Location = new Point(4, 0x13);
            this.tabInventory1.Name = "tabInventory1";
            this.tabInventory1.Padding = new Padding(3);
            this.tabInventory1.Size = new Size(0x133, 0);
            this.tabInventory1.TabIndex = 0;
            this.tabInventory1.Text = "1";
            this.tabInventory1.UseVisualStyleBackColor = true;
            this.tabInventory2.Cursor = Cursors.Default;
            this.tabInventory2.Location = new Point(4, 0x13);
            this.tabInventory2.Name = "tabInventory2";
            this.tabInventory2.Padding = new Padding(3);
            this.tabInventory2.Size = new Size(0x133, 0);
            this.tabInventory2.TabIndex = 1;
            this.tabInventory2.Text = "2";
            this.tabInventory2.UseVisualStyleBackColor = true;
            this.tabInventory3.Cursor = Cursors.Default;
            this.tabInventory3.Location = new Point(4, 0x13);
            this.tabInventory3.Name = "tabInventory3";
            this.tabInventory3.Size = new Size(0x133, 0);
            this.tabInventory3.TabIndex = 2;
            this.tabInventory3.Text = "3";
            this.tabInventory3.UseVisualStyleBackColor = true;
            this.tabInventory4.Cursor = Cursors.Default;
            this.tabInventory4.Location = new Point(4, 0x13);
            this.tabInventory4.Name = "tabInventory4";
            this.tabInventory4.Size = new Size(0x133, 0);
            this.tabInventory4.TabIndex = 3;
            this.tabInventory4.Text = "4";
            this.tabInventory4.UseVisualStyleBackColor = true;
            this.tabInventory5.Cursor = Cursors.Default;
            this.tabInventory5.Location = new Point(4, 0x13);
            this.tabInventory5.Name = "tabInventory5";
            this.tabInventory5.Size = new Size(0x133, 0);
            this.tabInventory5.TabIndex = 4;
            this.tabInventory5.Text = "5";
            this.tabInventory5.UseVisualStyleBackColor = true;
            this.tabInventory6.Cursor = Cursors.Default;
            this.tabInventory6.Location = new Point(4, 0x13);
            this.tabInventory6.Name = "tabInventory6";
            this.tabInventory6.Size = new Size(0x133, 0);
            this.tabInventory6.TabIndex = 5;
            this.tabInventory6.Text = "Free Slots";
            this.tabInventory6.UseVisualStyleBackColor = true;
            this.btnInventoryImportSelected.Cursor = Cursors.Hand;
            this.btnInventoryImportSelected.Enabled = false;
            this.btnInventoryImportSelected.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnInventoryImportSelected.Location = new Point(0x1b5, 0xb1);
            this.btnInventoryImportSelected.Name = "btnInventoryImportSelected";
            this.btnInventoryImportSelected.Size = new Size(0x43, 0x15);
            this.btnInventoryImportSelected.TabIndex = 0x48;
            this.btnInventoryImportSelected.Text = "import item";
            this.btnInventoryImportSelected.UseVisualStyleBackColor = true;
            this.btnInventoryImportSelected.Click += new EventHandler(this.btnInventoryImportSelected_Click);
            this.btnInventoryExportSelected.Cursor = Cursors.Hand;
            this.btnInventoryExportSelected.Enabled = false;
            this.btnInventoryExportSelected.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnInventoryExportSelected.Location = new Point(0x1f8, 0xb1);
            this.btnInventoryExportSelected.Name = "btnInventoryExportSelected";
            this.btnInventoryExportSelected.Size = new Size(0x3e, 0x15);
            this.btnInventoryExportSelected.TabIndex = 0x47;
            this.btnInventoryExportSelected.Text = "export item";
            this.btnInventoryExportSelected.UseVisualStyleBackColor = true;
            this.btnInventoryExportSelected.Click += new EventHandler(this.btnInventoryExportSelected_Click);
            this.btnInventoryImportAll.Cursor = Cursors.Hand;
            this.btnInventoryImportAll.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnInventoryImportAll.Location = new Point(0x98, 0xb7);
            this.btnInventoryImportAll.Name = "btnInventoryImportAll";
            this.btnInventoryImportAll.Size = new Size(0x52, 0x15);
            this.btnInventoryImportAll.TabIndex = 50;
            this.btnInventoryImportAll.Text = "import inventory";
            this.btnInventoryImportAll.UseVisualStyleBackColor = true;
            this.btnInventoryImportAll.Click += new EventHandler(this.btnInventoryImportAll_Click);
            this.btnInventoryExportAll.Cursor = Cursors.Hand;
            this.btnInventoryExportAll.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnInventoryExportAll.Location = new Point(0xec, 0xb7);
            this.btnInventoryExportAll.Name = "btnInventoryExportAll";
            this.btnInventoryExportAll.Size = new Size(0x52, 0x15);
            this.btnInventoryExportAll.TabIndex = 0x31;
            this.btnInventoryExportAll.Text = "export inventory";
            this.btnInventoryExportAll.UseVisualStyleBackColor = true;
            this.btnInventoryExportAll.Click += new EventHandler(this.btnInventoryExportAll_Click);
            this.txtInventoryMeseta.AutoSize = true;
            this.txtInventoryMeseta.Cursor = Cursors.Hand;
            this.txtInventoryMeseta.Location = new Point(60, 0xb6);
            this.txtInventoryMeseta.Name = "txtInventoryMeseta";
            this.txtInventoryMeseta.Size = new Size(14, 13);
            this.txtInventoryMeseta.TabIndex = 0x1b;
            this.txtInventoryMeseta.Text = "0";
            this.txtInventoryMeseta.Click += new EventHandler(this.txtInventoryMeseta_Click);
            this.lblInventoryMeseta.AutoSize = true;
            this.lblInventoryMeseta.Cursor = Cursors.Hand;
            this.lblInventoryMeseta.Location = new Point(0x10, 0xb6);
            this.lblInventoryMeseta.Name = "lblInventoryMeseta";
            this.lblInventoryMeseta.Size = new Size(0x2f, 13);
            this.lblInventoryMeseta.TabIndex = 0x1a;
            this.lblInventoryMeseta.Text = "Meseta";
            this.lblInventoryMeseta.Click += new EventHandler(this.txtInventoryMeseta_Click);
            this.grpInventoryItemDetails.BackColor = Color.Transparent;
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryPercent);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryLevel);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryACC);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryATK);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryEffect);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventorySpecial);
            this.grpInventoryItemDetails.Controls.Add(this.imgInventoryRank);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar15);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar14);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar13);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar12);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar11);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar10);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar9);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar8);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar7);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar6);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar5);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar4);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar3);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar2);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar1);
            this.grpInventoryItemDetails.Controls.Add(this.imgStar0);
            this.grpInventoryItemDetails.Controls.Add(this.imgInventoryWeaponManufacturer);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryGrinds);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryName_jp);
            this.grpInventoryItemDetails.Controls.Add(this.imgInventoryElement);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryQty);
            this.grpInventoryItemDetails.Controls.Add(this.imgInventoryItemIcon);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryName);
            this.grpInventoryItemDetails.Controls.Add(this.txtInventoryInfinityItemText);
            this.grpInventoryItemDetails.Controls.Add(this.imgInventoryInfinityItem);
            this.grpInventoryItemDetails.Location = new Point(0x144, 0x17);
            this.grpInventoryItemDetails.Name = "grpInventoryItemDetails";
            this.grpInventoryItemDetails.Size = new Size(0x129, 0x9a);
            this.grpInventoryItemDetails.TabIndex = 0x2b;
            this.grpInventoryItemDetails.TabStop = false;
            this.grpInventoryItemDetails.Visible = false;
            this.txtInventoryPercent.AutoSize = true;
            this.txtInventoryPercent.Cursor = Cursors.Hand;
            this.txtInventoryPercent.Location = new Point(0x15, 0x30);
            this.txtInventoryPercent.Name = "txtInventoryPercent";
            this.txtInventoryPercent.Size = new Size(0x1a, 13);
            this.txtInventoryPercent.TabIndex = 0x1f;
            this.txtInventoryPercent.Text = "0%";
            this.txtInventoryPercent.Click += new EventHandler(this.txtInventoryPercent_Click);
            this.txtInventoryLevel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtInventoryLevel.Location = new Point(0xc0, 0x74);
            this.txtInventoryLevel.Name = "txtInventoryLevel";
            this.txtInventoryLevel.Size = new Size(0x63, 12);
            this.txtInventoryLevel.TabIndex = 0x49;
            this.txtInventoryLevel.Text = "LV100";
            this.txtInventoryLevel.TextAlign = ContentAlignment.TopRight;
            this.txtInventoryACC.AutoSize = true;
            this.txtInventoryACC.Location = new Point(12, 0x74);
            this.txtInventoryACC.Name = "txtInventoryACC";
            this.txtInventoryACC.Size = new Size(0x29, 13);
            this.txtInventoryACC.TabIndex = 0x48;
            this.txtInventoryACC.Text = "ACC  ";
            this.txtInventoryATK.AutoSize = true;
            this.txtInventoryATK.Cursor = Cursors.Hand;
            this.txtInventoryATK.Location = new Point(15, 0x65);
            this.txtInventoryATK.Name = "txtInventoryATK";
            this.txtInventoryATK.Size = new Size(0x26, 13);
            this.txtInventoryATK.TabIndex = 0x47;
            this.txtInventoryATK.Text = "ATK  ";
            this.txtInventoryATK.Click += new EventHandler(this.txtInventoryATK_Click);
            this.txtInventoryEffect.AutoSize = true;
            this.txtInventoryEffect.Location = new Point(6, 0x56);
            this.txtInventoryEffect.Name = "txtInventoryEffect";
            this.txtInventoryEffect.Size = new Size(0x2f, 13);
            this.txtInventoryEffect.TabIndex = 70;
            this.txtInventoryEffect.Text = "Effect  ";
            this.txtInventorySpecial.Cursor = Cursors.Hand;
            this.txtInventorySpecial.Location = new Point(3, 0x47);
            this.txtInventorySpecial.Name = "txtInventorySpecial";
            this.txtInventorySpecial.Size = new Size(0x11c, 13);
            this.txtInventorySpecial.TabIndex = 0x45;
            this.txtInventorySpecial.Text = "Ability  ";
            this.txtInventorySpecial.Click += new EventHandler(this.txtInventorySpecial_Click);
            this.imgInventoryRank.Image = Resources.rank_S;
            this.imgInventoryRank.Location = new Point(10, 15);
            this.imgInventoryRank.Name = "imgInventoryRank";
            this.imgInventoryRank.Size = new Size(10, 10);
            this.imgInventoryRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryRank.TabIndex = 0x43;
            this.imgInventoryRank.TabStop = false;
            this.imgStar15.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar15.Image = Resources.star_s2;
            this.imgStar15.Location = new Point(230, 0x85);
            this.imgStar15.Name = "imgStar15";
            this.imgStar15.Size = new Size(0x10, 15);
            this.imgStar15.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar15.TabIndex = 0x42;
            this.imgStar15.TabStop = false;
            this.imgStar15.Visible = false;
            this.imgStar14.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar14.Image = Resources.star_s2;
            this.imgStar14.Location = new Point(0xd7, 0x85);
            this.imgStar14.Name = "imgStar14";
            this.imgStar14.Size = new Size(0x10, 15);
            this.imgStar14.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar14.TabIndex = 0x41;
            this.imgStar14.TabStop = false;
            this.imgStar14.Visible = false;
            this.imgStar13.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar13.Image = Resources.star_s2;
            this.imgStar13.Location = new Point(200, 0x85);
            this.imgStar13.Name = "imgStar13";
            this.imgStar13.Size = new Size(0x10, 15);
            this.imgStar13.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar13.TabIndex = 0x40;
            this.imgStar13.TabStop = false;
            this.imgStar13.Visible = false;
            this.imgStar12.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar12.Image = Resources.star_s2;
            this.imgStar12.Location = new Point(0xb9, 0x85);
            this.imgStar12.Name = "imgStar12";
            this.imgStar12.Size = new Size(0x10, 15);
            this.imgStar12.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar12.TabIndex = 0x3f;
            this.imgStar12.TabStop = false;
            this.imgStar12.Visible = false;
            this.imgStar11.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar11.Image = Resources.star_S;
            this.imgStar11.Location = new Point(0xab, 0x85);
            this.imgStar11.Name = "imgStar11";
            this.imgStar11.Size = new Size(0x10, 15);
            this.imgStar11.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar11.TabIndex = 0x3e;
            this.imgStar11.TabStop = false;
            this.imgStar11.Visible = false;
            this.imgStar10.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar10.Image = Resources.star_S;
            this.imgStar10.Location = new Point(0x9c, 0x85);
            this.imgStar10.Name = "imgStar10";
            this.imgStar10.Size = new Size(0x10, 15);
            this.imgStar10.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar10.TabIndex = 0x3d;
            this.imgStar10.TabStop = false;
            this.imgStar10.Visible = false;
            this.imgStar9.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar9.Image = Resources.star_S;
            this.imgStar9.Location = new Point(0x8d, 0x85);
            this.imgStar9.Name = "imgStar9";
            this.imgStar9.Size = new Size(0x10, 15);
            this.imgStar9.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar9.TabIndex = 60;
            this.imgStar9.TabStop = false;
            this.imgStar9.Visible = false;
            this.imgStar8.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar8.Image = Resources.star_A;
            this.imgStar8.Location = new Point(0x7e, 0x85);
            this.imgStar8.Name = "imgStar8";
            this.imgStar8.Size = new Size(0x10, 15);
            this.imgStar8.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar8.TabIndex = 0x3b;
            this.imgStar8.TabStop = false;
            this.imgStar8.Visible = false;
            this.imgStar7.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar7.Image = Resources.star_A;
            this.imgStar7.Location = new Point(0x6f, 0x85);
            this.imgStar7.Name = "imgStar7";
            this.imgStar7.Size = new Size(0x10, 15);
            this.imgStar7.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar7.TabIndex = 0x3a;
            this.imgStar7.TabStop = false;
            this.imgStar7.Visible = false;
            this.imgStar6.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar6.Image = Resources.star_A;
            this.imgStar6.Location = new Point(0x60, 0x85);
            this.imgStar6.Name = "imgStar6";
            this.imgStar6.Size = new Size(0x10, 15);
            this.imgStar6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar6.TabIndex = 0x39;
            this.imgStar6.TabStop = false;
            this.imgStar6.Visible = false;
            this.imgStar5.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar5.Image = Resources.star_B;
            this.imgStar5.Location = new Point(0x51, 0x85);
            this.imgStar5.Name = "imgStar5";
            this.imgStar5.Size = new Size(0x10, 15);
            this.imgStar5.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar5.TabIndex = 0x38;
            this.imgStar5.TabStop = false;
            this.imgStar5.Visible = false;
            this.imgStar4.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar4.Image = Resources.star_B;
            this.imgStar4.Location = new Point(0x42, 0x85);
            this.imgStar4.Name = "imgStar4";
            this.imgStar4.Size = new Size(0x10, 15);
            this.imgStar4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar4.TabIndex = 0x37;
            this.imgStar4.TabStop = false;
            this.imgStar4.Visible = false;
            this.imgStar3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar3.Image = Resources.star_B;
            this.imgStar3.Location = new Point(0x33, 0x85);
            this.imgStar3.Name = "imgStar3";
            this.imgStar3.Size = new Size(0x10, 15);
            this.imgStar3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar3.TabIndex = 0x36;
            this.imgStar3.TabStop = false;
            this.imgStar3.Visible = false;
            this.imgStar2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar2.Image = Resources.star_C;
            this.imgStar2.Location = new Point(0x24, 0x85);
            this.imgStar2.Name = "imgStar2";
            this.imgStar2.Size = new Size(0x10, 15);
            this.imgStar2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar2.TabIndex = 0x35;
            this.imgStar2.TabStop = false;
            this.imgStar2.Visible = false;
            this.imgStar1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar1.Image = Resources.star_C;
            this.imgStar1.Location = new Point(0x15, 0x85);
            this.imgStar1.Name = "imgStar1";
            this.imgStar1.Size = new Size(0x10, 15);
            this.imgStar1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar1.TabIndex = 0x34;
            this.imgStar1.TabStop = false;
            this.imgStar1.Visible = false;
            this.imgStar0.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStar0.Image = Resources.star_C;
            this.imgStar0.Location = new Point(6, 0x85);
            this.imgStar0.Name = "imgStar0";
            this.imgStar0.Size = new Size(0x10, 15);
            this.imgStar0.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStar0.TabIndex = 0x33;
            this.imgStar0.TabStop = false;
            this.imgStar0.Visible = false;
            this.imgInventoryWeaponManufacturer.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.imgInventoryWeaponManufacturer.Image = Resources.manlogo_GRM;
            this.imgInventoryWeaponManufacturer.Location = new Point(0x111, 12);
            this.imgInventoryWeaponManufacturer.Name = "imgInventoryWeaponManufacturer";
            this.imgInventoryWeaponManufacturer.Size = new Size(0x11, 0x11);
            this.imgInventoryWeaponManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryWeaponManufacturer.TabIndex = 0x2e;
            this.imgInventoryWeaponManufacturer.TabStop = false;
            this.txtInventoryGrinds.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtInventoryGrinds.Location = new Point(0x51, 0x30);
            this.txtInventoryGrinds.Name = "txtInventoryGrinds";
            this.txtInventoryGrinds.Size = new Size(210, 0x12);
            this.txtInventoryGrinds.TabIndex = 0x2d;
            this.txtInventoryGrinds.Text = "(0)";
            this.txtInventoryGrinds.TextAlign = ContentAlignment.TopRight;
            this.txtInventoryName_jp.Cursor = Cursors.Hand;
            this.txtInventoryName_jp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInventoryName_jp.Location = new Point(8, 30);
            this.txtInventoryName_jp.Name = "txtInventoryName_jp";
            this.txtInventoryName_jp.Size = new Size(0xe0, 0x12);
            this.txtInventoryName_jp.TabIndex = 0x2c;
            this.txtInventoryName_jp.Text = "-";
            this.txtInventoryName_jp.Click += new EventHandler(this.txtInventoryName_jp_Click);
            this.imgInventoryElement.Cursor = Cursors.Hand;
            this.imgInventoryElement.Image = Resources.element_neutral;
            this.imgInventoryElement.Location = new Point(9, 0x31);
            this.imgInventoryElement.Name = "imgInventoryElement";
            this.imgInventoryElement.Size = new Size(12, 12);
            this.imgInventoryElement.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryElement.TabIndex = 0x29;
            this.imgInventoryElement.TabStop = false;
            this.imgInventoryElement.Click += new EventHandler(this.imgInventoryElement_Click);
            this.txtInventoryQty.AutoSize = true;
            this.txtInventoryQty.Cursor = Cursors.Hand;
            this.txtInventoryQty.Location = new Point(6, 0x30);
            this.txtInventoryQty.Name = "txtInventoryQty";
            this.txtInventoryQty.Size = new Size(0x1a, 13);
            this.txtInventoryQty.TabIndex = 0x2a;
            this.txtInventoryQty.Text = "0/0";
            this.txtInventoryQty.Click += new EventHandler(this.txtInventoryQty_Click);
            this.imgInventoryItemIcon.Image = Resources.armor_icon;
            this.imgInventoryItemIcon.Location = new Point(10, 15);
            this.imgInventoryItemIcon.Name = "imgInventoryItemIcon";
            this.imgInventoryItemIcon.Padding = new Padding(13, 0, 0, 0);
            this.imgInventoryItemIcon.Size = new Size(0x17, 10);
            this.imgInventoryItemIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryItemIcon.TabIndex = 0x2f;
            this.imgInventoryItemIcon.TabStop = false;
            this.txtInventoryName.Location = new Point(0x15, 13);
            this.txtInventoryName.Name = "txtInventoryName";
            this.txtInventoryName.Padding = new Padding(13, 0, 0, 0);
            this.txtInventoryName.Size = new Size(0xd3, 0x12);
            this.txtInventoryName.TabIndex = 0x2b;
            this.txtInventoryName.Text = "-";
            this.txtInventoryInfinityItemText.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtInventoryInfinityItemText.AutoSize = true;
            this.txtInventoryInfinityItemText.Location = new Point(0x112, 0x20);
            this.txtInventoryInfinityItemText.Name = "txtInventoryInfinityItemText";
            this.txtInventoryInfinityItemText.Size = new Size(13, 13);
            this.txtInventoryInfinityItemText.TabIndex = 50;
            this.txtInventoryInfinityItemText.Text = "?";
            this.txtInventoryInfinityItemText.Visible = false;
            this.imgInventoryInfinityItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.imgInventoryInfinityItem.Image = Resources.infinity_item;
            this.imgInventoryInfinityItem.Location = new Point(270, 0x1f);
            this.imgInventoryInfinityItem.Name = "imgInventoryInfinityItem";
            this.imgInventoryInfinityItem.Size = new Size(20, 0x10);
            this.imgInventoryInfinityItem.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgInventoryInfinityItem.TabIndex = 0x31;
            this.imgInventoryInfinityItem.TabStop = false;
            this.imgInventoryInfinityItem.Visible = false;
            this.groupBox2.Location = new Point(0x144, 0x17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x129, 0x9a);
            this.groupBox2.TabIndex = 0x19;
            this.groupBox2.TabStop = false;
            this.txtInventoryHex.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtInventoryHex.Cursor = Cursors.Hand;
            this.txtInventoryHex.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInventoryHex.Location = new Point(0x143, 0xb1);
            this.txtInventoryHex.Name = "txtInventoryHex";
            this.txtInventoryHex.Size = new Size(0x61, 13);
            this.txtInventoryHex.TabIndex = 0x30;
            this.txtInventoryHex.Text = "0x00000000";
            this.txtInventoryHex.Click += new EventHandler(this.txtInventoryHex_Click);
            this.pictureBox7.Cursor = Cursors.Default;
            this.pictureBox7.Image = Resources.item_meseta;
            this.pictureBox7.Location = new Point(6, 0xb8);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new Size(10, 10);
            this.pictureBox7.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 0x45;
            this.pictureBox7.TabStop = false;
            ColumnHeader[] values = new ColumnHeader[] { this.columnHeader1 };
            this.inventoryView.Columns.AddRange(values);
            this.inventoryView.Cursor = Cursors.Hand;
            this.inventoryView.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.inventoryView.FullRowSelect = true;
            this.inventoryView.HeaderStyle = ColumnHeaderStyle.None;
            this.inventoryView.HideSelection = false;
            this.inventoryView.LabelWrap = false;
            this.inventoryView.Location = new Point(5, 30);
            this.inventoryView.MultiSelect = false;
            this.inventoryView.Name = "inventoryView";
            this.inventoryView.Size = new Size(0x139, 150);
            this.inventoryView.SmallImageList = this.weaponWithRankImageList;
            this.inventoryView.TabIndex = 0x4d;
            this.inventoryView.UseCompatibleStateImageBehavior = false;
            this.inventoryView.View = View.Details;
            this.inventoryView.SelectedIndexChanged += new EventHandler(this.inventoryView_SelectedIndexChanged);
            this.inventoryView.Click += new EventHandler(this.inventoryView_Click);
            this.columnHeader1.Width = 0x123;
            this.weaponWithRankImageList.ImageStream = (ImageListStreamer) manager.GetObject("weaponWithRankImageList.ImageStream");
            this.weaponWithRankImageList.TransparentColor = Color.Transparent;
            this.weaponWithRankImageList.Images.SetKeyName(0, "c_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(1, "c_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(2, "c_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(3, "c_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(4, "c_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(5, "c_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(6, "c_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(7, "c_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(8, "c_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(9, "c_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(10, "c_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(11, "c_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(12, "c_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(13, "c_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(14, "c_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(15, "c_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x10, "c_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x11, "c_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x12, "c_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x13, "c_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(20, "c_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x15, "c_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x16, "c_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x17, "c_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x18, "c_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x19, "c_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1a, "c_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1b, "c_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1c, "b_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1d, "b_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(30, "b_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1f, "b_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x20, "b_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x21, "b_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x22, "b_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x23, "b_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x24, "b_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x25, "b_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x26, "b_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x27, "b_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(40, "b_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x29, "b_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x2a, "b_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x2b, "b_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x2c, "b_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x2d, "b_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x2e, "b_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x2f, "b_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x30, "b_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x31, "b_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(50, "b_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x33, "b_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x34, "b_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x35, "b_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x36, "b_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x37, "b_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x38, "a_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x39, "a_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x3a, "a_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x3b, "a_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(60, "a_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x3d, "a_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x3e, "a_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x3f, "a_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x40, "a_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x41, "a_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x42, "a_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x43, "a_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x44, "a_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x45, "a_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(70, "a_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x47, "a_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x48, "a_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x49, "a_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x4a, "a_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x4b, "a_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x4c, "a_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x4d, "a_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x4e, "a_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x4f, "a_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(80, "a_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x51, "a_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x52, "a_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x53, "a_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x54, "s_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x55, "s_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x56, "s_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x57, "s_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x58, "s_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x59, "s_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(90, "s_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x5b, "s_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x5c, "s_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x5d, "s_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x5e, "s_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x5f, "s_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x60, "s_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x61, "s_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x62, "s_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x63, "s_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(100, "s_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x65, "s_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x66, "s_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x67, "s_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x68, "s_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x69, "s_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x6a, "s_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x6b, "s_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x6c, "s_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x6d, "s_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(110, "s_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x6f, "s_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x70, "unk_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x71, "unk_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x72, "unk_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x73, "unk_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x74, "unk_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x75, "unk_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x76, "unk_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x77, "unk_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(120, "unk_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x79, "unk_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x7a, "unk_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x7b, "unk_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x7c, "unk_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x7d, "unk_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x7e, "unk_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x7f, "unk_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x80, "unk_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x81, "unk_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(130, "unk_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x83, "unk_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x84, "unk_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x85, "unk_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x86, "unk_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x87, "unk_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x88, "unk_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x89, "unk_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x8a, "unk_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x8b, "unk_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(140, "c_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x8d, "c_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x8e, "c_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x8f, "c_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x90, "c_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x91, "c_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x92, "c_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x93, "c_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x94, "c_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x95, "c_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(150, "c_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x97, "c_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x98, "c_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x99, "c_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x9a, "c_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x9b, "c_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x9c, "c_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x9d, "c_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x9e, "c_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x9f, "c_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(160, "c_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa1, "c_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa2, "c_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa3, "c_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa4, "c_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa5, "c_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa6, "c_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa7, "c_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa8, "b_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xa9, "b_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(170, "b_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xab, "b_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xac, "b_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xad, "b_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xae, "b_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xaf, "b_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb0, "b_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb1, "b_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb2, "b_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb3, "b_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(180, "b_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb5, "b_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb6, "b_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb7, "b_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb8, "b_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xb9, "b_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xba, "b_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xbb, "b_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xbc, "b_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xbd, "b_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(190, "b_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xbf, "b_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc0, "b_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc1, "b_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc2, "b_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc3, "b_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc4, "a_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc5, "a_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc6, "a_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc7, "a_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(200, "a_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xc9, "a_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xca, "a_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xcb, "a_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xcc, "a_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xcd, "a_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xce, "a_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xcf, "a_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd0, "a_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd1, "a_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(210, "a_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd3, "a_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd4, "a_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd5, "a_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd6, "a_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd7, "a_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd8, "a_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xd9, "a_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xda, "a_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xdb, "a_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(220, "a_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xdd, "a_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xde, "a_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xdf, "a_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe0, "s_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe1, "s_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe2, "s_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe3, "s_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe4, "s_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe5, "s_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(230, "s_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe7, "s_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe8, "s_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xe9, "s_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xea, "s_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xeb, "s_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xec, "s_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xed, "s_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xee, "s_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xef, "s_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(240, "s_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf1, "s_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf2, "s_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf3, "s_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf4, "s_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf5, "s_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf6, "s_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf7, "s_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf8, "s_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xf9, "s_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(250, "s_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xfb, "s_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xfc, "unk_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xfd, "unk_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xfe, "unk_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0xff, "unk_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x100, "unk_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x101, "unk_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x102, "unk_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x103, "unk_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(260, "unk_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x105, "unk_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x106, "unk_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x107, "unk_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x108, "unk_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x109, "unk_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x10a, "unk_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x10b, "unk_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x10c, "unk_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x10d, "unk_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(270, "unk_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x10f, "unk_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x110, "unk_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x111, "unk_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x112, "unk_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x113, "unk_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x114, "unk_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x115, "unk_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x116, "unk_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x117, "unk_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(280, "c_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x119, "c_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x11a, "c_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x11b, "c_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x11c, "c_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x11d, "c_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x11e, "c_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x11f, "c_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x120, "c_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x121, "c_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(290, "c_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x123, "c_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x124, "c_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x125, "c_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x126, "c_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x127, "c_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x128, "c_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x129, "c_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x12a, "c_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x12b, "c_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(300, "c_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x12d, "c_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x12e, "c_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x12f, "c_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x130, "c_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x131, "c_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x132, "c_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x133, "c_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x134, "b_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x135, "b_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(310, "b_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x137, "b_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x138, "b_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x139, "b_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x13a, "b_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x13b, "b_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x13c, "b_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x13d, "b_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x13e, "b_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x13f, "b_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(320, "b_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x141, "b_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x142, "b_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x143, "b_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x144, "b_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x145, "b_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x146, "b_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x147, "b_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x148, "b_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x149, "b_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(330, "b_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x14b, "b_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x14c, "b_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x14d, "b_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x14e, "b_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x14f, "b_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x150, "a_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x151, "a_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x152, "a_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x153, "a_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(340, "a_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x155, "a_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x156, "a_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x157, "a_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x158, "a_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x159, "a_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x15a, "a_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x15b, "a_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x15c, "a_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x15d, "a_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(350, "a_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x15f, "a_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x160, "a_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x161, "a_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x162, "a_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x163, "a_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x164, "a_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x165, "a_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x166, "a_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x167, "a_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(360, "a_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x169, "a_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x16a, "a_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x16b, "a_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x16c, "s_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x16d, "s_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x16e, "s_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x16f, "s_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x170, "s_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x171, "s_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(370, "s_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x173, "s_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x174, "s_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x175, "s_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x176, "s_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x177, "s_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x178, "s_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x179, "s_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x17a, "s_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x17b, "s_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(380, "s_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x17d, "s_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x17e, "s_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x17f, "s_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x180, "s_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x181, "s_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x182, "s_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x183, "s_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x184, "s_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x185, "s_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(390, "s_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x187, "s_028_shield.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x188, "unk_001_sword.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x189, "unk_002_knuckles.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x18a, "unk_003_spear.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x18b, "unk_004_double_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x18c, "unk_005_axe.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x18d, "unk_006_sabers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x18e, "unk_007_daggers.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x18f, "unk_008_claws.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(400, "unk_009_saber.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x191, "unk_010_dagger.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x192, "unk_011_claw.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x193, "unk_012_whip.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x194, "unk_013_slicer.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x195, "unk_014_rifle.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x196, "unk_015_shotgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x197, "unk_016_longbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x198, "unk_017_grenade.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x199, "unk_018_laser.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(410, "unk_019_handguns.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x19b, "unk_020_handgun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x19c, "unk_021_crossbow.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x19d, "unk_022_cards.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x19e, "unk_023_machinegun.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x19f, "unk_024_rod.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1a0, "unk_025_wand.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1a1, "unk_026_tmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1a2, "unk_027_rmag.jpg");
            this.weaponWithRankImageList.Images.SetKeyName(0x1a3, "unk_028_shield.jpg");
            this.tabPageStorage.Controls.Add(this.btnStorageDelete);
            this.tabPageStorage.Controls.Add(this.chkDeleteExportStorage);
            this.tabPageStorage.Controls.Add(this.btnStorageWithdraw);
            this.tabPageStorage.Controls.Add(this.storageViewPages);
            this.tabPageStorage.Controls.Add(this.storageView);
            this.tabPageStorage.Controls.Add(this.btnStorageImportAll);
            this.tabPageStorage.Controls.Add(this.btnStorageExportAll);
            this.tabPageStorage.Controls.Add(this.btnStorageImportSelected);
            this.tabPageStorage.Controls.Add(this.btnStorageExportSelected);
            this.tabPageStorage.Controls.Add(this.txtStorageMeseta);
            this.tabPageStorage.Controls.Add(this.lblStorageMeseta);
            this.tabPageStorage.Controls.Add(this.grpStorageItemDetails);
            this.tabPageStorage.Controls.Add(this.groupBox1);
            this.tabPageStorage.Controls.Add(this.txtStorageHex);
            this.tabPageStorage.Controls.Add(this.pictureBox6);
            this.tabPageStorage.Cursor = Cursors.Default;
            this.tabPageStorage.Location = new Point(4, 0x16);
            this.tabPageStorage.Name = "tabPageStorage";
            this.tabPageStorage.Size = new Size(0x275, 0xdf);
            this.tabPageStorage.TabIndex = 5;
            this.tabPageStorage.Text = "Shared (0/0)";
            this.tabPageStorage.UseVisualStyleBackColor = true;
            this.btnStorageDelete.Cursor = Cursors.Hand;
            this.btnStorageDelete.Enabled = false;
            this.btnStorageDelete.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnStorageDelete.Location = new Point(0x187, 0xb1);
            this.btnStorageDelete.Name = "btnStorageDelete";
            this.btnStorageDelete.Size = new Size(0x2e, 0x15);
            this.btnStorageDelete.TabIndex = 0x4d;
            this.btnStorageDelete.Text = "delete";
            this.btnStorageDelete.UseVisualStyleBackColor = true;
            this.btnStorageDelete.Click += new EventHandler(this.btnStorageDelete_Click);
            this.chkDeleteExportStorage.AutoSize = true;
            this.chkDeleteExportStorage.Cursor = Cursors.Hand;
            this.chkDeleteExportStorage.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chkDeleteExportStorage.Location = new Point(0x1f1, 0xce);
            this.chkDeleteExportStorage.Name = "chkDeleteExportStorage";
            this.chkDeleteExportStorage.RightToLeft = RightToLeft.Yes;
            this.chkDeleteExportStorage.Size = new Size(0x7d, 14);
            this.chkDeleteExportStorage.TabIndex = 0x4a;
            this.chkDeleteExportStorage.Text = "delete items after export";
            this.chkDeleteExportStorage.UseVisualStyleBackColor = true;
            this.btnStorageWithdraw.Cursor = Cursors.Hand;
            this.btnStorageWithdraw.Enabled = false;
            this.btnStorageWithdraw.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnStorageWithdraw.Location = new Point(0x236, 0xb1);
            this.btnStorageWithdraw.Name = "btnStorageWithdraw";
            this.btnStorageWithdraw.Size = new Size(0x38, 0x15);
            this.btnStorageWithdraw.TabIndex = 0x49;
            this.btnStorageWithdraw.Text = "withdraw";
            this.btnStorageWithdraw.UseVisualStyleBackColor = true;
            this.btnStorageWithdraw.Click += new EventHandler(this.btnStorageWithdraw_Click);
            this.storageViewPages.Controls.Add(this.tabStorage1);
            this.storageViewPages.Controls.Add(this.tabStorage2);
            this.storageViewPages.Controls.Add(this.tabStorage3);
            this.storageViewPages.Controls.Add(this.tabStorage4);
            this.storageViewPages.Controls.Add(this.tabStorage5);
            this.storageViewPages.Controls.Add(this.tabStorage6);
            this.storageViewPages.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.storageViewPages.Location = new Point(5, 12);
            this.storageViewPages.Name = "storageViewPages";
            this.storageViewPages.SelectedIndex = 0;
            this.storageViewPages.Size = new Size(0x13b, 0x13);
            this.storageViewPages.TabIndex = 0x48;
            this.storageViewPages.SelectedIndexChanged += new EventHandler(this.storageViewPages_SelectedIndexChanged);
            this.tabStorage1.Cursor = Cursors.Hand;
            this.tabStorage1.Location = new Point(4, 0x13);
            this.tabStorage1.Name = "tabStorage1";
            this.tabStorage1.Padding = new Padding(3);
            this.tabStorage1.Size = new Size(0x133, 0);
            this.tabStorage1.TabIndex = 0;
            this.tabStorage1.Text = "1";
            this.tabStorage1.UseVisualStyleBackColor = true;
            this.tabStorage2.Cursor = Cursors.Hand;
            this.tabStorage2.Location = new Point(4, 0x13);
            this.tabStorage2.Name = "tabStorage2";
            this.tabStorage2.Padding = new Padding(3);
            this.tabStorage2.Size = new Size(0x133, 0);
            this.tabStorage2.TabIndex = 1;
            this.tabStorage2.Text = "2";
            this.tabStorage2.UseVisualStyleBackColor = true;
            this.tabStorage3.Cursor = Cursors.Hand;
            this.tabStorage3.Location = new Point(4, 0x13);
            this.tabStorage3.Name = "tabStorage3";
            this.tabStorage3.Size = new Size(0x133, 0);
            this.tabStorage3.TabIndex = 2;
            this.tabStorage3.Text = "3";
            this.tabStorage3.UseVisualStyleBackColor = true;
            this.tabStorage4.Cursor = Cursors.Hand;
            this.tabStorage4.Location = new Point(4, 0x13);
            this.tabStorage4.Name = "tabStorage4";
            this.tabStorage4.Size = new Size(0x133, 0);
            this.tabStorage4.TabIndex = 3;
            this.tabStorage4.Text = "4";
            this.tabStorage4.UseVisualStyleBackColor = true;
            this.tabStorage5.Cursor = Cursors.Hand;
            this.tabStorage5.Location = new Point(4, 0x13);
            this.tabStorage5.Name = "tabStorage5";
            this.tabStorage5.Size = new Size(0x133, 0);
            this.tabStorage5.TabIndex = 4;
            this.tabStorage5.Text = "5";
            this.tabStorage5.UseVisualStyleBackColor = true;
            this.tabStorage6.Cursor = Cursors.Hand;
            this.tabStorage6.Location = new Point(4, 0x13);
            this.tabStorage6.Name = "tabStorage6";
            this.tabStorage6.Size = new Size(0x133, 0);
            this.tabStorage6.TabIndex = 5;
            this.tabStorage6.Text = "Free Slots";
            this.tabStorage6.UseVisualStyleBackColor = true;
            ColumnHeader[] headerArray2 = new ColumnHeader[] { this.columnHeader3 };
            this.storageView.Columns.AddRange(headerArray2);
            this.storageView.Cursor = Cursors.Hand;
            this.storageView.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.storageView.FullRowSelect = true;
            this.storageView.HeaderStyle = ColumnHeaderStyle.None;
            this.storageView.HideSelection = false;
            this.storageView.LabelWrap = false;
            this.storageView.Location = new Point(5, 30);
            this.storageView.MultiSelect = false;
            this.storageView.Name = "storageView";
            this.storageView.Size = new Size(0x139, 150);
            this.storageView.SmallImageList = this.weaponWithRankImageList;
            this.storageView.TabIndex = 0x47;
            this.storageView.UseCompatibleStateImageBehavior = false;
            this.storageView.View = View.Details;
            this.storageView.SelectedIndexChanged += new EventHandler(this.storageView_SelectedIndexChanged);
            this.storageView.Click += new EventHandler(this.storageView_Click);
            this.columnHeader3.Width = 0x123;
            this.btnStorageImportAll.Cursor = Cursors.Hand;
            this.btnStorageImportAll.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnStorageImportAll.Location = new Point(0x98, 0xb7);
            this.btnStorageImportAll.Name = "btnStorageImportAll";
            this.btnStorageImportAll.Size = new Size(0x52, 0x15);
            this.btnStorageImportAll.TabIndex = 70;
            this.btnStorageImportAll.Text = "import storage";
            this.btnStorageImportAll.UseVisualStyleBackColor = true;
            this.btnStorageImportAll.Click += new EventHandler(this.btnStorageImportAll_Click);
            this.btnStorageExportAll.Cursor = Cursors.Hand;
            this.btnStorageExportAll.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnStorageExportAll.Location = new Point(0xec, 0xb7);
            this.btnStorageExportAll.Name = "btnStorageExportAll";
            this.btnStorageExportAll.Size = new Size(0x52, 0x15);
            this.btnStorageExportAll.TabIndex = 0x45;
            this.btnStorageExportAll.Text = "export storage";
            this.btnStorageExportAll.UseVisualStyleBackColor = true;
            this.btnStorageExportAll.Click += new EventHandler(this.btnStorageExportAll_Click);
            this.btnStorageImportSelected.Cursor = Cursors.Hand;
            this.btnStorageImportSelected.Enabled = false;
            this.btnStorageImportSelected.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnStorageImportSelected.Location = new Point(0x1b5, 0xb1);
            this.btnStorageImportSelected.Name = "btnStorageImportSelected";
            this.btnStorageImportSelected.Size = new Size(0x43, 0x15);
            this.btnStorageImportSelected.TabIndex = 0x1c;
            this.btnStorageImportSelected.Text = "import item";
            this.btnStorageImportSelected.UseVisualStyleBackColor = true;
            this.btnStorageImportSelected.Click += new EventHandler(this.btnStorageImportSelected_Click);
            this.btnStorageExportSelected.Cursor = Cursors.Hand;
            this.btnStorageExportSelected.Enabled = false;
            this.btnStorageExportSelected.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnStorageExportSelected.Location = new Point(0x1f8, 0xb1);
            this.btnStorageExportSelected.Name = "btnStorageExportSelected";
            this.btnStorageExportSelected.Size = new Size(0x3e, 0x15);
            this.btnStorageExportSelected.TabIndex = 0x1b;
            this.btnStorageExportSelected.Text = "export item";
            this.btnStorageExportSelected.UseVisualStyleBackColor = true;
            this.btnStorageExportSelected.Click += new EventHandler(this.btnStorageExportSelected_Click);
            this.txtStorageMeseta.AutoSize = true;
            this.txtStorageMeseta.Cursor = Cursors.Hand;
            this.txtStorageMeseta.Location = new Point(60, 0xb6);
            this.txtStorageMeseta.Name = "txtStorageMeseta";
            this.txtStorageMeseta.Size = new Size(14, 13);
            this.txtStorageMeseta.TabIndex = 50;
            this.txtStorageMeseta.Text = "0";
            this.txtStorageMeseta.Click += new EventHandler(this.txtStorageMeseta_Click);
            this.lblStorageMeseta.AutoSize = true;
            this.lblStorageMeseta.Cursor = Cursors.Hand;
            this.lblStorageMeseta.Location = new Point(0x10, 0xb6);
            this.lblStorageMeseta.Name = "lblStorageMeseta";
            this.lblStorageMeseta.Size = new Size(0x2f, 13);
            this.lblStorageMeseta.TabIndex = 0x31;
            this.lblStorageMeseta.Text = "Meseta";
            this.lblStorageMeseta.Click += new EventHandler(this.txtStorageMeseta_Click);
            this.grpStorageItemDetails.BackColor = Color.Transparent;
            this.grpStorageItemDetails.Controls.Add(this.txtStoragePercent);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageLevel);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageACC);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageATK);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageEffect);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageSpecial);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageRank);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar15);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar14);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar13);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar12);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar11);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar10);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar9);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar8);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar7);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar6);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar5);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar4);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar3);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar2);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar1);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageStar0);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageWeaponManufacturer);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageGrinds);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageName_jp);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageItemIcon);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageName);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageElement);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageQty);
            this.grpStorageItemDetails.Controls.Add(this.txtStorageInfinityItemText);
            this.grpStorageItemDetails.Controls.Add(this.imgStorageInfinityItem);
            this.grpStorageItemDetails.Location = new Point(0x144, 0x17);
            this.grpStorageItemDetails.Name = "grpStorageItemDetails";
            this.grpStorageItemDetails.Size = new Size(0x129, 0x9a);
            this.grpStorageItemDetails.TabIndex = 0x34;
            this.grpStorageItemDetails.TabStop = false;
            this.grpStorageItemDetails.Visible = false;
            this.txtStoragePercent.AutoSize = true;
            this.txtStoragePercent.Cursor = Cursors.Hand;
            this.txtStoragePercent.Location = new Point(0x15, 0x30);
            this.txtStoragePercent.Name = "txtStoragePercent";
            this.txtStoragePercent.Size = new Size(0x1a, 13);
            this.txtStoragePercent.TabIndex = 0x1f;
            this.txtStoragePercent.Text = "0%";
            this.txtStoragePercent.Click += new EventHandler(this.txtStoragePercent_Click);
            this.txtStorageLevel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtStorageLevel.Location = new Point(0xc0, 0x74);
            this.txtStorageLevel.Name = "txtStorageLevel";
            this.txtStorageLevel.Size = new Size(0x63, 0x11);
            this.txtStorageLevel.TabIndex = 0x4b;
            this.txtStorageLevel.Text = "LV100";
            this.txtStorageLevel.TextAlign = ContentAlignment.TopRight;
            this.txtStorageACC.AutoSize = true;
            this.txtStorageACC.Location = new Point(12, 0x74);
            this.txtStorageACC.Name = "txtStorageACC";
            this.txtStorageACC.Size = new Size(0x29, 13);
            this.txtStorageACC.TabIndex = 0x4a;
            this.txtStorageACC.Text = "ACC  ";
            this.txtStorageATK.AutoSize = true;
            this.txtStorageATK.Cursor = Cursors.Hand;
            this.txtStorageATK.Location = new Point(15, 0x65);
            this.txtStorageATK.Name = "txtStorageATK";
            this.txtStorageATK.Size = new Size(0x26, 13);
            this.txtStorageATK.TabIndex = 0x49;
            this.txtStorageATK.Text = "ATK  ";
            this.txtStorageATK.Click += new EventHandler(this.txtStorageATK_Click);
            this.txtStorageEffect.AutoSize = true;
            this.txtStorageEffect.Location = new Point(6, 0x56);
            this.txtStorageEffect.Name = "txtStorageEffect";
            this.txtStorageEffect.Size = new Size(0x2f, 13);
            this.txtStorageEffect.TabIndex = 0x48;
            this.txtStorageEffect.Text = "Effect  ";
            this.txtStorageSpecial.Cursor = Cursors.Hand;
            this.txtStorageSpecial.Location = new Point(3, 0x47);
            this.txtStorageSpecial.Name = "txtStorageSpecial";
            this.txtStorageSpecial.Size = new Size(0x116, 14);
            this.txtStorageSpecial.TabIndex = 0x47;
            this.txtStorageSpecial.Text = "Ability  ";
            this.txtStorageSpecial.Click += new EventHandler(this.txtStorageSpecial_Click);
            this.imgStorageRank.Image = Resources.rank_S;
            this.imgStorageRank.Location = new Point(10, 15);
            this.imgStorageRank.Name = "imgStorageRank";
            this.imgStorageRank.Size = new Size(10, 10);
            this.imgStorageRank.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageRank.TabIndex = 0x43;
            this.imgStorageRank.TabStop = false;
            this.imgStorageStar15.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar15.Image = Resources.star_s2;
            this.imgStorageStar15.Location = new Point(230, 0x85);
            this.imgStorageStar15.Name = "imgStorageStar15";
            this.imgStorageStar15.Size = new Size(0x10, 15);
            this.imgStorageStar15.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar15.TabIndex = 0x42;
            this.imgStorageStar15.TabStop = false;
            this.imgStorageStar15.Visible = false;
            this.imgStorageStar14.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar14.Image = Resources.star_s2;
            this.imgStorageStar14.Location = new Point(0xd7, 0x85);
            this.imgStorageStar14.Name = "imgStorageStar14";
            this.imgStorageStar14.Size = new Size(0x10, 15);
            this.imgStorageStar14.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar14.TabIndex = 0x41;
            this.imgStorageStar14.TabStop = false;
            this.imgStorageStar14.Visible = false;
            this.imgStorageStar13.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar13.Image = Resources.star_s2;
            this.imgStorageStar13.Location = new Point(200, 0x85);
            this.imgStorageStar13.Name = "imgStorageStar13";
            this.imgStorageStar13.Size = new Size(0x10, 15);
            this.imgStorageStar13.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar13.TabIndex = 0x40;
            this.imgStorageStar13.TabStop = false;
            this.imgStorageStar13.Visible = false;
            this.imgStorageStar12.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar12.Image = Resources.star_s2;
            this.imgStorageStar12.Location = new Point(0xb9, 0x85);
            this.imgStorageStar12.Name = "imgStorageStar12";
            this.imgStorageStar12.Size = new Size(0x10, 15);
            this.imgStorageStar12.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar12.TabIndex = 0x3f;
            this.imgStorageStar12.TabStop = false;
            this.imgStorageStar12.Visible = false;
            this.imgStorageStar11.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar11.Image = Resources.star_S;
            this.imgStorageStar11.Location = new Point(0xab, 0x85);
            this.imgStorageStar11.Name = "imgStorageStar11";
            this.imgStorageStar11.Size = new Size(0x10, 15);
            this.imgStorageStar11.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar11.TabIndex = 0x3e;
            this.imgStorageStar11.TabStop = false;
            this.imgStorageStar11.Visible = false;
            this.imgStorageStar10.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar10.Image = Resources.star_S;
            this.imgStorageStar10.Location = new Point(0x9c, 0x85);
            this.imgStorageStar10.Name = "imgStorageStar10";
            this.imgStorageStar10.Size = new Size(0x10, 15);
            this.imgStorageStar10.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar10.TabIndex = 0x3d;
            this.imgStorageStar10.TabStop = false;
            this.imgStorageStar10.Visible = false;
            this.imgStorageStar9.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar9.Image = Resources.star_S;
            this.imgStorageStar9.Location = new Point(0x8d, 0x85);
            this.imgStorageStar9.Name = "imgStorageStar9";
            this.imgStorageStar9.Size = new Size(0x10, 15);
            this.imgStorageStar9.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar9.TabIndex = 60;
            this.imgStorageStar9.TabStop = false;
            this.imgStorageStar9.Visible = false;
            this.imgStorageStar8.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar8.Image = Resources.star_A;
            this.imgStorageStar8.Location = new Point(0x7e, 0x85);
            this.imgStorageStar8.Name = "imgStorageStar8";
            this.imgStorageStar8.Size = new Size(0x10, 15);
            this.imgStorageStar8.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar8.TabIndex = 0x3b;
            this.imgStorageStar8.TabStop = false;
            this.imgStorageStar8.Visible = false;
            this.imgStorageStar7.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar7.Image = Resources.star_A;
            this.imgStorageStar7.Location = new Point(0x6f, 0x85);
            this.imgStorageStar7.Name = "imgStorageStar7";
            this.imgStorageStar7.Size = new Size(0x10, 15);
            this.imgStorageStar7.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar7.TabIndex = 0x3a;
            this.imgStorageStar7.TabStop = false;
            this.imgStorageStar7.Visible = false;
            this.imgStorageStar6.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar6.Image = Resources.star_A;
            this.imgStorageStar6.Location = new Point(0x60, 0x85);
            this.imgStorageStar6.Name = "imgStorageStar6";
            this.imgStorageStar6.Size = new Size(0x10, 15);
            this.imgStorageStar6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar6.TabIndex = 0x39;
            this.imgStorageStar6.TabStop = false;
            this.imgStorageStar6.Visible = false;
            this.imgStorageStar5.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar5.Image = Resources.star_B;
            this.imgStorageStar5.Location = new Point(0x51, 0x85);
            this.imgStorageStar5.Name = "imgStorageStar5";
            this.imgStorageStar5.Size = new Size(0x10, 15);
            this.imgStorageStar5.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar5.TabIndex = 0x38;
            this.imgStorageStar5.TabStop = false;
            this.imgStorageStar5.Visible = false;
            this.imgStorageStar4.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar4.Image = Resources.star_B;
            this.imgStorageStar4.Location = new Point(0x42, 0x85);
            this.imgStorageStar4.Name = "imgStorageStar4";
            this.imgStorageStar4.Size = new Size(0x10, 15);
            this.imgStorageStar4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar4.TabIndex = 0x37;
            this.imgStorageStar4.TabStop = false;
            this.imgStorageStar4.Visible = false;
            this.imgStorageStar3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar3.Image = Resources.star_B;
            this.imgStorageStar3.Location = new Point(0x33, 0x85);
            this.imgStorageStar3.Name = "imgStorageStar3";
            this.imgStorageStar3.Size = new Size(0x10, 15);
            this.imgStorageStar3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar3.TabIndex = 0x36;
            this.imgStorageStar3.TabStop = false;
            this.imgStorageStar3.Visible = false;
            this.imgStorageStar2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar2.Image = Resources.star_C;
            this.imgStorageStar2.Location = new Point(0x24, 0x85);
            this.imgStorageStar2.Name = "imgStorageStar2";
            this.imgStorageStar2.Size = new Size(0x10, 15);
            this.imgStorageStar2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar2.TabIndex = 0x35;
            this.imgStorageStar2.TabStop = false;
            this.imgStorageStar2.Visible = false;
            this.imgStorageStar1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar1.Image = Resources.star_C;
            this.imgStorageStar1.Location = new Point(0x15, 0x85);
            this.imgStorageStar1.Name = "imgStorageStar1";
            this.imgStorageStar1.Size = new Size(0x10, 15);
            this.imgStorageStar1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar1.TabIndex = 0x34;
            this.imgStorageStar1.TabStop = false;
            this.imgStorageStar1.Visible = false;
            this.imgStorageStar0.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.imgStorageStar0.Image = Resources.star_C;
            this.imgStorageStar0.Location = new Point(6, 0x85);
            this.imgStorageStar0.Name = "imgStorageStar0";
            this.imgStorageStar0.Size = new Size(0x10, 15);
            this.imgStorageStar0.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageStar0.TabIndex = 0x33;
            this.imgStorageStar0.TabStop = false;
            this.imgStorageStar0.Visible = false;
            this.imgStorageWeaponManufacturer.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.imgStorageWeaponManufacturer.Image = Resources.manlogo_GRM;
            this.imgStorageWeaponManufacturer.Location = new Point(0x111, 12);
            this.imgStorageWeaponManufacturer.Name = "imgStorageWeaponManufacturer";
            this.imgStorageWeaponManufacturer.Size = new Size(0x11, 0x11);
            this.imgStorageWeaponManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageWeaponManufacturer.TabIndex = 0x2e;
            this.imgStorageWeaponManufacturer.TabStop = false;
            this.txtStorageGrinds.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtStorageGrinds.Location = new Point(0x51, 0x30);
            this.txtStorageGrinds.Name = "txtStorageGrinds";
            this.txtStorageGrinds.Size = new Size(210, 0x12);
            this.txtStorageGrinds.TabIndex = 0x2d;
            this.txtStorageGrinds.Text = "(0)";
            this.txtStorageGrinds.TextAlign = ContentAlignment.TopRight;
            this.txtStorageName_jp.Cursor = Cursors.Hand;
            this.txtStorageName_jp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtStorageName_jp.Location = new Point(8, 30);
            this.txtStorageName_jp.Name = "txtStorageName_jp";
            this.txtStorageName_jp.Size = new Size(0xe0, 0x12);
            this.txtStorageName_jp.TabIndex = 0x2c;
            this.txtStorageName_jp.Text = "-";
            this.txtStorageName_jp.Click += new EventHandler(this.txtStorageName_jp_Click);
            this.imgStorageItemIcon.Image = Resources.armor_icon;
            this.imgStorageItemIcon.Location = new Point(10, 15);
            this.imgStorageItemIcon.Name = "imgStorageItemIcon";
            this.imgStorageItemIcon.Padding = new Padding(13, 0, 0, 0);
            this.imgStorageItemIcon.Size = new Size(0x17, 10);
            this.imgStorageItemIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageItemIcon.TabIndex = 0x2f;
            this.imgStorageItemIcon.TabStop = false;
            this.txtStorageName.Location = new Point(0x15, 13);
            this.txtStorageName.Name = "txtStorageName";
            this.txtStorageName.Padding = new Padding(13, 0, 0, 0);
            this.txtStorageName.Size = new Size(0xd3, 0x12);
            this.txtStorageName.TabIndex = 0x2b;
            this.txtStorageName.Text = "-";
            this.imgStorageElement.Cursor = Cursors.Hand;
            this.imgStorageElement.Image = Resources.element_neutral;
            this.imgStorageElement.Location = new Point(9, 0x31);
            this.imgStorageElement.Name = "imgStorageElement";
            this.imgStorageElement.Size = new Size(12, 12);
            this.imgStorageElement.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageElement.TabIndex = 0x29;
            this.imgStorageElement.TabStop = false;
            this.imgStorageElement.Click += new EventHandler(this.imgStorageElement_Click);
            this.txtStorageQty.AutoSize = true;
            this.txtStorageQty.Cursor = Cursors.Hand;
            this.txtStorageQty.Location = new Point(6, 0x30);
            this.txtStorageQty.Name = "txtStorageQty";
            this.txtStorageQty.Size = new Size(0x1a, 13);
            this.txtStorageQty.TabIndex = 0x2a;
            this.txtStorageQty.Text = "0/0";
            this.txtStorageQty.Click += new EventHandler(this.txtStorageQty_Click);
            this.txtStorageInfinityItemText.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtStorageInfinityItemText.AutoSize = true;
            this.txtStorageInfinityItemText.Location = new Point(0x112, 0x20);
            this.txtStorageInfinityItemText.Name = "txtStorageInfinityItemText";
            this.txtStorageInfinityItemText.Size = new Size(13, 13);
            this.txtStorageInfinityItemText.TabIndex = 50;
            this.txtStorageInfinityItemText.Text = "?";
            this.txtStorageInfinityItemText.Visible = false;
            this.imgStorageInfinityItem.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.imgStorageInfinityItem.Image = Resources.infinity_item;
            this.imgStorageInfinityItem.Location = new Point(270, 0x1f);
            this.imgStorageInfinityItem.Name = "imgStorageInfinityItem";
            this.imgStorageInfinityItem.Size = new Size(20, 0x10);
            this.imgStorageInfinityItem.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgStorageInfinityItem.TabIndex = 0x31;
            this.imgStorageInfinityItem.TabStop = false;
            this.imgStorageInfinityItem.Visible = false;
            this.groupBox1.Location = new Point(0x144, 0x18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x129, 0x9a);
            this.groupBox1.TabIndex = 0x19;
            this.groupBox1.TabStop = false;
            this.txtStorageHex.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtStorageHex.Cursor = Cursors.Hand;
            this.txtStorageHex.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtStorageHex.Location = new Point(0x143, 0xb1);
            this.txtStorageHex.Name = "txtStorageHex";
            this.txtStorageHex.Size = new Size(0x61, 13);
            this.txtStorageHex.TabIndex = 0x35;
            this.txtStorageHex.Text = "0x00000000";
            this.txtStorageHex.Click += new EventHandler(this.txtStorageHex_Click);
            this.pictureBox6.Cursor = Cursors.Default;
            this.pictureBox6.Image = Resources.item_meseta;
            this.pictureBox6.Location = new Point(6, 0xb8);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new Size(10, 10);
            this.pictureBox6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 0x44;
            this.pictureBox6.TabStop = false;
            this.tabPageMissions.Controls.Add(this.tabControlMissions);
            this.tabPageMissions.Location = new Point(4, 0x16);
            this.tabPageMissions.Name = "tabPageMissions";
            this.tabPageMissions.Padding = new Padding(3);
            this.tabPageMissions.Size = new Size(0x275, 0xdf);
            this.tabPageMissions.TabIndex = 7;
            this.tabPageMissions.Text = "Mission";
            this.tabPageMissions.UseVisualStyleBackColor = true;
            this.tabControlMissions.Controls.Add(this.tabEp1Missions);
            this.tabControlMissions.Controls.Add(this.tabEp2Missions);
            this.tabControlMissions.Controls.Add(this.tabPageInfinityMission);
            this.tabControlMissions.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabControlMissions.Location = new Point(4, 3);
            this.tabControlMissions.Name = "tabControlMissions";
            this.tabControlMissions.SelectedIndex = 0;
            this.tabControlMissions.Size = new Size(0x26a, 0xd9);
            this.tabControlMissions.TabIndex = 0;
            this.tabEp1Missions.Controls.Add(this.txtAllowQuitMission);
            this.tabEp1Missions.Controls.Add(this.label47);
            this.tabEp1Missions.Controls.Add(this.txtEp1Complete);
            this.tabEp1Missions.Controls.Add(this.label44);
            this.tabEp1Missions.Controls.Add(this.txtStoryEmiliaPoints);
            this.tabEp1Missions.Controls.Add(this.txtMissionTactical);
            this.tabEp1Missions.Controls.Add(this.label2);
            this.tabEp1Missions.Controls.Add(this.txtMissionMagashi);
            this.tabEp1Missions.Controls.Add(this.label13);
            this.tabEp1Missions.Controls.Add(this.txtSkipEp1Start);
            this.tabEp1Missions.Controls.Add(this.label12);
            this.tabEp1Missions.Controls.Add(this.txtMissionEp1);
            this.tabEp1Missions.Controls.Add(this.label1);
            this.tabEp1Missions.Location = new Point(4, 0x15);
            this.tabEp1Missions.Name = "tabEp1Missions";
            this.tabEp1Missions.Padding = new Padding(3);
            this.tabEp1Missions.Size = new Size(610, 0xc0);
            this.tabEp1Missions.TabIndex = 0;
            this.tabEp1Missions.Text = "Episode 1";
            this.tabEp1Missions.UseVisualStyleBackColor = true;
            this.tabEp1Missions.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtAllowQuitMission.Cursor = Cursors.Hand;
            this.txtAllowQuitMission.ForeColor = Color.DarkRed;
            this.txtAllowQuitMission.Location = new Point(0x90, 0x55);
            this.txtAllowQuitMission.Name = "txtAllowQuitMission";
            this.txtAllowQuitMission.Size = new Size(0x25, 13);
            this.txtAllowQuitMission.TabIndex = 0x65;
            this.txtAllowQuitMission.Text = "No";
            this.txtAllowQuitMission.TextAlign = ContentAlignment.MiddleLeft;
            this.txtAllowQuitMission.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtAllowQuitMission.Click += new EventHandler(this.txtAllowQuitMission_Click);
            this.label47.ForeColor = Color.Black;
            this.label47.Location = new Point(2, 0x55);
            this.label47.Name = "label47";
            this.label47.Size = new Size(0x8f, 13);
            this.label47.TabIndex = 100;
            this.label47.Text = "Allow Quit Mission";
            this.label47.TextAlign = ContentAlignment.MiddleRight;
            this.txtEp1Complete.Cursor = Cursors.Hand;
            this.txtEp1Complete.ForeColor = Color.DarkRed;
            this.txtEp1Complete.Location = new Point(0x90, 70);
            this.txtEp1Complete.Name = "txtEp1Complete";
            this.txtEp1Complete.Size = new Size(0x25, 13);
            this.txtEp1Complete.TabIndex = 0x63;
            this.txtEp1Complete.Text = "No";
            this.txtEp1Complete.TextAlign = ContentAlignment.MiddleLeft;
            this.txtEp1Complete.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtEp1Complete.Click += new EventHandler(this.txtEp1Complete_Click);
            this.label44.ForeColor = Color.Black;
            this.label44.Location = new Point(2, 70);
            this.label44.Name = "label44";
            this.label44.Size = new Size(0x8f, 13);
            this.label44.TabIndex = 0x62;
            this.label44.Text = "Episode Complete";
            this.label44.TextAlign = ContentAlignment.MiddleRight;
            this.txtStoryEmiliaPoints.AutoSize = true;
            this.txtStoryEmiliaPoints.BackColor = Color.Transparent;
            this.txtStoryEmiliaPoints.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtStoryEmiliaPoints.ForeColor = SystemColors.ActiveCaptionText;
            this.txtStoryEmiliaPoints.Location = new Point(0x1df, 13);
            this.txtStoryEmiliaPoints.Name = "txtStoryEmiliaPoints";
            this.txtStoryEmiliaPoints.Size = new Size(0x56, 14);
            this.txtStoryEmiliaPoints.TabIndex = 0x61;
            this.txtStoryEmiliaPoints.Text = "Emilia Points";
            this.txtStoryEmiliaPoints.Visible = false;
            this.txtMissionTactical.Cursor = Cursors.Hand;
            this.txtMissionTactical.ForeColor = Color.DarkRed;
            this.txtMissionTactical.Location = new Point(0xad, 0xac);
            this.txtMissionTactical.Name = "txtMissionTactical";
            this.txtMissionTactical.Size = new Size(0x25, 13);
            this.txtMissionTactical.TabIndex = 0x60;
            this.txtMissionTactical.Text = "No";
            this.txtMissionTactical.TextAlign = ContentAlignment.MiddleLeft;
            this.txtMissionTactical.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtMissionTactical.Click += new EventHandler(this.txtMissionUnknown_Click);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(5, 0xac);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xb0, 13);
            this.label2.TabIndex = 0x5f;
            this.label2.Text = "Unknown Missions Unlocked  ";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            this.txtMissionMagashi.Cursor = Cursors.Hand;
            this.txtMissionMagashi.ForeColor = Color.DarkRed;
            this.txtMissionMagashi.Location = new Point(0x90, 0x2b);
            this.txtMissionMagashi.Name = "txtMissionMagashi";
            this.txtMissionMagashi.Size = new Size(0x25, 13);
            this.txtMissionMagashi.TabIndex = 0x5e;
            this.txtMissionMagashi.Text = "No";
            this.txtMissionMagashi.TextAlign = ContentAlignment.MiddleLeft;
            this.txtMissionMagashi.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtMissionMagashi.Click += new EventHandler(this.txtMissionMagashi_Click);
            this.label13.ForeColor = Color.Black;
            this.label13.Location = new Point(3, 0x2b);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x95, 13);
            this.label13.TabIndex = 0x5d;
            this.label13.Text = "Magashi Plan Unlocked  ";
            this.label13.TextAlign = ContentAlignment.MiddleRight;
            this.txtSkipEp1Start.Cursor = Cursors.Hand;
            this.txtSkipEp1Start.ForeColor = Color.DarkRed;
            this.txtSkipEp1Start.Location = new Point(0x90, 13);
            this.txtSkipEp1Start.Name = "txtSkipEp1Start";
            this.txtSkipEp1Start.Size = new Size(0x25, 13);
            this.txtSkipEp1Start.TabIndex = 0x5c;
            this.txtSkipEp1Start.Text = "No";
            this.txtSkipEp1Start.TextAlign = ContentAlignment.MiddleLeft;
            this.txtSkipEp1Start.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtSkipEp1Start.Click += new EventHandler(this.txtSkipEp1Start_Click);
            this.label12.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label12.ForeColor = Color.Black;
            this.label12.Location = new Point(6, 13);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x92, 13);
            this.label12.TabIndex = 0x5b;
            this.label12.Text = "Skip Start Sequence  ";
            this.label12.TextAlign = ContentAlignment.MiddleRight;
            this.txtMissionEp1.Cursor = Cursors.Hand;
            this.txtMissionEp1.ForeColor = Color.DarkRed;
            this.txtMissionEp1.Location = new Point(0x90, 0x1c);
            this.txtMissionEp1.Name = "txtMissionEp1";
            this.txtMissionEp1.Size = new Size(0x25, 13);
            this.txtMissionEp1.TabIndex = 90;
            this.txtMissionEp1.Text = "No";
            this.txtMissionEp1.TextAlign = ContentAlignment.MiddleLeft;
            this.txtMissionEp1.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtMissionEp1.Click += new EventHandler(this.txtMissionEp1_Click);
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(6, 0x1c);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x92, 13);
            this.label1.TabIndex = 0x59;
            this.label1.Text = "All Missions Unlocked  ";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            this.tabEp2Missions.Controls.Add(this.txtEp2Complete);
            this.tabEp2Missions.Controls.Add(this.label46);
            this.tabEp2Missions.Controls.Add(this.txtStoryNagisaPoints);
            this.tabEp2Missions.Controls.Add(this.txtSkipEp2Start);
            this.tabEp2Missions.Controls.Add(this.lblSkipEp2Start);
            this.tabEp2Missions.Controls.Add(this.txtMissionEp2);
            this.tabEp2Missions.Controls.Add(this.lblMissionEp2);
            this.tabEp2Missions.Location = new Point(4, 0x15);
            this.tabEp2Missions.Name = "tabEp2Missions";
            this.tabEp2Missions.Padding = new Padding(3);
            this.tabEp2Missions.Size = new Size(610, 0xc0);
            this.tabEp2Missions.TabIndex = 1;
            this.tabEp2Missions.Text = "Episode 2";
            this.tabEp2Missions.UseVisualStyleBackColor = true;
            this.txtEp2Complete.Cursor = Cursors.Hand;
            this.txtEp2Complete.ForeColor = Color.DarkRed;
            this.txtEp2Complete.Location = new Point(0x90, 0x3e);
            this.txtEp2Complete.Name = "txtEp2Complete";
            this.txtEp2Complete.Size = new Size(0x25, 13);
            this.txtEp2Complete.TabIndex = 0x65;
            this.txtEp2Complete.Text = "No";
            this.txtEp2Complete.TextAlign = ContentAlignment.MiddleLeft;
            this.txtEp2Complete.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtEp2Complete.Click += new EventHandler(this.txtEp2Complete_Click);
            this.label46.ForeColor = Color.Black;
            this.label46.Location = new Point(2, 0x3e);
            this.label46.Name = "label46";
            this.label46.Size = new Size(0x8f, 13);
            this.label46.TabIndex = 100;
            this.label46.Text = "Episode Complete";
            this.label46.TextAlign = ContentAlignment.MiddleRight;
            this.txtStoryNagisaPoints.AutoSize = true;
            this.txtStoryNagisaPoints.BackColor = Color.Transparent;
            this.txtStoryNagisaPoints.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtStoryNagisaPoints.ForeColor = SystemColors.ActiveCaptionText;
            this.txtStoryNagisaPoints.Location = new Point(0x1d8, 13);
            this.txtStoryNagisaPoints.Name = "txtStoryNagisaPoints";
            this.txtStoryNagisaPoints.Size = new Size(0x5d, 14);
            this.txtStoryNagisaPoints.TabIndex = 0x5b;
            this.txtStoryNagisaPoints.Text = "Nagisa Points";
            this.txtStoryNagisaPoints.Visible = false;
            this.txtSkipEp2Start.Cursor = Cursors.Hand;
            this.txtSkipEp2Start.ForeColor = Color.DarkRed;
            this.txtSkipEp2Start.Location = new Point(0x90, 13);
            this.txtSkipEp2Start.Name = "txtSkipEp2Start";
            this.txtSkipEp2Start.Size = new Size(0x25, 13);
            this.txtSkipEp2Start.TabIndex = 90;
            this.txtSkipEp2Start.Text = "No";
            this.txtSkipEp2Start.TextAlign = ContentAlignment.MiddleLeft;
            this.txtSkipEp2Start.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtSkipEp2Start.Click += new EventHandler(this.txtSkipEp2Start_Click);
            this.lblSkipEp2Start.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.lblSkipEp2Start.ForeColor = Color.Black;
            this.lblSkipEp2Start.Location = new Point(7, 13);
            this.lblSkipEp2Start.Name = "lblSkipEp2Start";
            this.lblSkipEp2Start.Size = new Size(0x91, 13);
            this.lblSkipEp2Start.TabIndex = 0x59;
            this.lblSkipEp2Start.Text = "Skip Start Sequence  ";
            this.lblSkipEp2Start.TextAlign = ContentAlignment.MiddleRight;
            this.txtMissionEp2.Cursor = Cursors.Hand;
            this.txtMissionEp2.ForeColor = Color.DarkRed;
            this.txtMissionEp2.Location = new Point(0x90, 0x1c);
            this.txtMissionEp2.Name = "txtMissionEp2";
            this.txtMissionEp2.Size = new Size(0x25, 13);
            this.txtMissionEp2.TabIndex = 0x58;
            this.txtMissionEp2.Text = "No";
            this.txtMissionEp2.TextAlign = ContentAlignment.MiddleLeft;
            this.txtMissionEp2.TextChanged += new EventHandler(this.missionStatus_TextChanged);
            this.txtMissionEp2.Click += new EventHandler(this.txtMissionEp2_Click);
            this.lblMissionEp2.ForeColor = Color.Black;
            this.lblMissionEp2.Location = new Point(10, 0x1c);
            this.lblMissionEp2.Name = "lblMissionEp2";
            this.lblMissionEp2.Size = new Size(0x8e, 13);
            this.lblMissionEp2.TabIndex = 0x57;
            this.lblMissionEp2.Text = "All Missions Unlocked  ";
            this.lblMissionEp2.TextAlign = ContentAlignment.MiddleRight;
            this.tabPageInfinityMission.Controls.Add(this.btnImportMissions);
            this.tabPageInfinityMission.Controls.Add(this.btnExportMissions);
            this.tabPageInfinityMission.Controls.Add(this.btnModifyInfinityMission);
            this.tabPageInfinityMission.Controls.Add(this.tabControl1);
            this.tabPageInfinityMission.Controls.Add(this.btnDeleteInfinityMission);
            this.tabPageInfinityMission.Controls.Add(this.btnImportInfinityMission);
            this.tabPageInfinityMission.Controls.Add(this.btnExportInfinityMission);
            this.tabPageInfinityMission.Controls.Add(this.lstInfinityMissions);
            this.tabPageInfinityMission.Controls.Add(this.txtInfinityMissionQty);
            this.tabPageInfinityMission.Controls.Add(this.label63);
            this.tabPageInfinityMission.Location = new Point(4, 0x15);
            this.tabPageInfinityMission.Name = "tabPageInfinityMission";
            this.tabPageInfinityMission.Padding = new Padding(3);
            this.tabPageInfinityMission.Size = new Size(610, 0xc0);
            this.tabPageInfinityMission.TabIndex = 2;
            this.tabPageInfinityMission.Text = "Infinity Missions";
            this.tabPageInfinityMission.UseVisualStyleBackColor = true;
            this.btnImportMissions.Cursor = Cursors.Hand;
            this.btnImportMissions.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnImportMissions.Location = new Point(0x87, 0xac);
            this.btnImportMissions.Name = "btnImportMissions";
            this.btnImportMissions.Size = new Size(0x52, 0x15);
            this.btnImportMissions.TabIndex = 100;
            this.btnImportMissions.Text = "import pack";
            this.btnImportMissions.UseVisualStyleBackColor = true;
            this.btnImportMissions.Click += new EventHandler(this.btnImportMissions_Click);
            this.btnExportMissions.Cursor = Cursors.Hand;
            this.btnExportMissions.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnExportMissions.Location = new Point(0xdb, 0xac);
            this.btnExportMissions.Name = "btnExportMissions";
            this.btnExportMissions.Size = new Size(0x52, 0x15);
            this.btnExportMissions.TabIndex = 0x63;
            this.btnExportMissions.Text = "export pack";
            this.btnExportMissions.UseVisualStyleBackColor = true;
            this.btnExportMissions.Click += new EventHandler(this.btnExportMissions_Click);
            this.btnModifyInfinityMission.Cursor = Cursors.Hand;
            this.btnModifyInfinityMission.Enabled = false;
            this.btnModifyInfinityMission.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnModifyInfinityMission.Location = new Point(0x19b, 0x9d);
            this.btnModifyInfinityMission.Name = "btnModifyInfinityMission";
            this.btnModifyInfinityMission.Size = new Size(0x2e, 0x15);
            this.btnModifyInfinityMission.TabIndex = 0x62;
            this.btnModifyInfinityMission.Text = "modify";
            this.btnModifyInfinityMission.UseVisualStyleBackColor = true;
            this.btnModifyInfinityMission.Click += new EventHandler(this.btnModifyInfinityMission_Click);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new Font("Verdana", 6f);
            this.tabControl1.Location = new Point(0x133, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x12e, 0x97);
            this.tabControl1.TabIndex = 0x61;
            this.tabPage1.Controls.Add(this.grpInfinityMissionDetails);
            this.tabPage1.Location = new Point(4, 0x13);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0x126, 0x80);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.grpInfinityMissionDetails.BackColor = Color.Transparent;
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfEnemyLevel);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfNameJp);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfNameEn);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfMisEnemy2);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfMisBoss);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfMisEnemy1);
            this.grpInfinityMissionDetails.Font = new Font("Verdana", 8.25f);
            this.grpInfinityMissionDetails.Location = new Point(0, -6);
            this.grpInfinityMissionDetails.Name = "grpInfinityMissionDetails";
            this.grpInfinityMissionDetails.Size = new Size(0x125, 0x87);
            this.grpInfinityMissionDetails.TabIndex = 0x4a;
            this.grpInfinityMissionDetails.TabStop = false;
            this.grpInfinityMissionDetails.Visible = false;
            this.txtInfEnemyLevel.Cursor = Cursors.Default;
            this.txtInfEnemyLevel.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInfEnemyLevel.Location = new Point(4, 110);
            this.txtInfEnemyLevel.Name = "txtInfEnemyLevel";
            this.txtInfEnemyLevel.Size = new Size(0x119, 13);
            this.txtInfEnemyLevel.TabIndex = 0x51;
            this.txtInfEnemyLevel.Text = "Enemy Level";
            this.txtInfNameJp.Cursor = Cursors.Default;
            this.txtInfNameJp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInfNameJp.Location = new Point(6, 0x22);
            this.txtInfNameJp.Name = "txtInfNameJp";
            this.txtInfNameJp.Size = new Size(0xe0, 0x12);
            this.txtInfNameJp.TabIndex = 80;
            this.txtInfNameJp.Text = "-";
            this.txtInfNameEn.Cursor = Cursors.Default;
            this.txtInfNameEn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInfNameEn.Location = new Point(6, 0x11);
            this.txtInfNameEn.Name = "txtInfNameEn";
            this.txtInfNameEn.Size = new Size(0xdd, 0x12);
            this.txtInfNameEn.TabIndex = 0x4f;
            this.txtInfNameEn.Text = "-";
            this.txtInfMisEnemy2.Cursor = Cursors.Default;
            this.txtInfMisEnemy2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInfMisEnemy2.Location = new Point(12, 0x5f);
            this.txtInfMisEnemy2.Name = "txtInfMisEnemy2";
            this.txtInfMisEnemy2.Size = new Size(0x119, 13);
            this.txtInfMisEnemy2.TabIndex = 0x4e;
            this.txtInfMisEnemy2.Text = "Sub Enemy";
            this.txtInfMisBoss.Cursor = Cursors.Default;
            this.txtInfMisBoss.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInfMisBoss.Location = new Point(5, 0x39);
            this.txtInfMisBoss.Name = "txtInfMisBoss";
            this.txtInfMisBoss.Size = new Size(0x11a, 13);
            this.txtInfMisBoss.TabIndex = 0x4c;
            this.txtInfMisBoss.Text = "Boss";
            this.txtInfMisEnemy1.Cursor = Cursors.Default;
            this.txtInfMisEnemy1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInfMisEnemy1.Location = new Point(8, 80);
            this.txtInfMisEnemy1.Name = "txtInfMisEnemy1";
            this.txtInfMisEnemy1.Size = new Size(0x11c, 13);
            this.txtInfMisEnemy1.TabIndex = 0x4d;
            this.txtInfMisEnemy1.Text = "Main Enemy";
            this.tabPage2.Controls.Add(this.grpInfMisSpecial);
            this.tabPage2.Location = new Point(4, 0x13);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(0x126, 0x80);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.grpInfMisSpecial.BackColor = Color.Transparent;
            this.grpInfMisSpecial.Controls.Add(this.txtInfMisSpecial);
            this.grpInfMisSpecial.Font = new Font("Verdana", 8.25f);
            this.grpInfMisSpecial.Location = new Point(0, -6);
            this.grpInfMisSpecial.Name = "grpInfMisSpecial";
            this.grpInfMisSpecial.Size = new Size(0x125, 0x87);
            this.grpInfMisSpecial.TabIndex = 0x4b;
            this.grpInfMisSpecial.TabStop = false;
            this.grpInfMisSpecial.Visible = false;
            this.txtInfMisSpecial.Cursor = Cursors.Default;
            this.txtInfMisSpecial.Font = new Font("Verdana", 6.75f);
            this.txtInfMisSpecial.Location = new Point(6, 0x11);
            this.txtInfMisSpecial.Name = "txtInfMisSpecial";
            this.txtInfMisSpecial.Size = new Size(0x119, 13);
            this.txtInfMisSpecial.TabIndex = 0x4c;
            this.txtInfMisSpecial.Text = "Special Effects";
            this.tabPage3.Controls.Add(this.grpInfMisExtra);
            this.tabPage3.Location = new Point(4, 0x13);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new Size(0x126, 0x80);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.grpInfMisExtra.BackColor = Color.Transparent;
            this.grpInfMisExtra.Controls.Add(this.txtInfMisSynthPoint);
            this.grpInfMisExtra.Controls.Add(this.txtInfMisCreatedBy);
            this.grpInfMisExtra.Font = new Font("Verdana", 8.25f);
            this.grpInfMisExtra.Location = new Point(0, -6);
            this.grpInfMisExtra.Name = "grpInfMisExtra";
            this.grpInfMisExtra.Size = new Size(0x125, 0x87);
            this.grpInfMisExtra.TabIndex = 0x4c;
            this.grpInfMisExtra.TabStop = false;
            this.grpInfMisExtra.Visible = false;
            this.txtInfMisSynthPoint.Cursor = Cursors.Default;
            this.txtInfMisSynthPoint.Font = new Font("Verdana", 6.75f);
            this.txtInfMisSynthPoint.Location = new Point(6, 0x3d);
            this.txtInfMisSynthPoint.Name = "txtInfMisSynthPoint";
            this.txtInfMisSynthPoint.Size = new Size(0x119, 13);
            this.txtInfMisSynthPoint.TabIndex = 0x4d;
            this.txtInfMisSynthPoint.Text = "Sythesis Points  ";
            this.txtInfMisCreatedBy.Cursor = Cursors.Default;
            this.txtInfMisCreatedBy.Font = new Font("Verdana", 6.75f);
            this.txtInfMisCreatedBy.Location = new Point(6, 0x11);
            this.txtInfMisCreatedBy.Name = "txtInfMisCreatedBy";
            this.txtInfMisCreatedBy.Size = new Size(0x119, 13);
            this.txtInfMisCreatedBy.TabIndex = 0x4c;
            this.txtInfMisCreatedBy.Text = "Created By  ";
            this.btnDeleteInfinityMission.Cursor = Cursors.Hand;
            this.btnDeleteInfinityMission.Enabled = false;
            this.btnDeleteInfinityMission.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnDeleteInfinityMission.Location = new Point(0x1c9, 0x9d);
            this.btnDeleteInfinityMission.Name = "btnDeleteInfinityMission";
            this.btnDeleteInfinityMission.Size = new Size(0x2e, 0x15);
            this.btnDeleteInfinityMission.TabIndex = 0x60;
            this.btnDeleteInfinityMission.Text = "delete";
            this.btnDeleteInfinityMission.UseVisualStyleBackColor = true;
            this.btnDeleteInfinityMission.Click += new EventHandler(this.btnDeleteInfinityMission_Click);
            this.btnImportInfinityMission.Cursor = Cursors.Hand;
            this.btnImportInfinityMission.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnImportInfinityMission.Location = new Point(0x1f7, 0x9d);
            this.btnImportInfinityMission.Name = "btnImportInfinityMission";
            this.btnImportInfinityMission.Size = new Size(50, 0x15);
            this.btnImportInfinityMission.TabIndex = 0x5f;
            this.btnImportInfinityMission.Text = "import";
            this.btnImportInfinityMission.UseVisualStyleBackColor = true;
            this.btnImportInfinityMission.Click += new EventHandler(this.btnImportInfinityMission_Click);
            this.btnExportInfinityMission.Cursor = Cursors.Hand;
            this.btnExportInfinityMission.Enabled = false;
            this.btnExportInfinityMission.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnExportInfinityMission.Location = new Point(0x229, 0x9d);
            this.btnExportInfinityMission.Name = "btnExportInfinityMission";
            this.btnExportInfinityMission.Size = new Size(0x34, 0x15);
            this.btnExportInfinityMission.TabIndex = 0x5e;
            this.btnExportInfinityMission.Text = "export";
            this.btnExportInfinityMission.UseVisualStyleBackColor = true;
            this.btnExportInfinityMission.Click += new EventHandler(this.btnExportInfinityMission_Click);
            ColumnHeader[] headerArray3 = new ColumnHeader[] { this.columnHeader10, this.columnHeader11 };
            this.lstInfinityMissions.Columns.AddRange(headerArray3);
            this.lstInfinityMissions.Cursor = Cursors.Hand;
            this.lstInfinityMissions.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lstInfinityMissions.FullRowSelect = true;
            this.lstInfinityMissions.HeaderStyle = ColumnHeaderStyle.None;
            this.lstInfinityMissions.HideSelection = false;
            this.lstInfinityMissions.LabelWrap = false;
            this.lstInfinityMissions.Location = new Point(3, 3);
            this.lstInfinityMissions.MultiSelect = false;
            this.lstInfinityMissions.Name = "lstInfinityMissions";
            this.lstInfinityMissions.Size = new Size(0x12a, 0xa7);
            this.lstInfinityMissions.TabIndex = 0x5d;
            this.lstInfinityMissions.UseCompatibleStateImageBehavior = false;
            this.lstInfinityMissions.View = View.Details;
            this.lstInfinityMissions.SelectedIndexChanged += new EventHandler(this.lstInfinityMissions_SelectedIndexChanged);
            this.columnHeader10.Width = 220;
            this.columnHeader11.Width = 50;
            this.txtInfinityMissionQty.AutoSize = true;
            this.txtInfinityMissionQty.BackColor = Color.Transparent;
            this.txtInfinityMissionQty.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInfinityMissionQty.ForeColor = SystemColors.ActiveCaptionText;
            this.txtInfinityMissionQty.Location = new Point(3, 0xaf);
            this.txtInfinityMissionQty.Name = "txtInfinityMissionQty";
            this.txtInfinityMissionQty.Size = new Size(0x2c, 14);
            this.txtInfinityMissionQty.TabIndex = 0x5c;
            this.txtInfinityMissionQty.Text = "0/100";
            this.label63.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label63.Cursor = Cursors.Hand;
            this.label63.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label63.Location = new Point(0x137, 0x9d);
            this.label63.Name = "label63";
            this.label63.Size = new Size(0x61, 13);
            this.label63.TabIndex = 0x4b;
            this.label63.Text = "0x00000000";
            this.tabPagePA.Controls.Add(this.tabPA);
            this.tabPagePA.Location = new Point(4, 0x16);
            this.tabPagePA.Name = "tabPagePA";
            this.tabPagePA.Padding = new Padding(3);
            this.tabPagePA.Size = new Size(0x275, 0xdf);
            this.tabPagePA.TabIndex = 8;
            this.tabPagePA.Text = "PA List";
            this.tabPagePA.UseVisualStyleBackColor = true;
            this.tabPA.Controls.Add(this.tabPAMelee);
            this.tabPA.Controls.Add(this.tabPABullets);
            this.tabPA.Controls.Add(this.tabPATech);
            this.tabPA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabPA.Location = new Point(5, 3);
            this.tabPA.Name = "tabPA";
            this.tabPA.SelectedIndex = 0;
            this.tabPA.Size = new Size(0x26a, 0xd9);
            this.tabPA.TabIndex = 1;
            this.tabPAMelee.Controls.Add(this.groupBox6);
            this.tabPAMelee.Controls.Add(this.txtPAHexMelee);
            this.tabPAMelee.Controls.Add(this.lstPAMelee);
            this.tabPAMelee.Location = new Point(4, 0x15);
            this.tabPAMelee.Name = "tabPAMelee";
            this.tabPAMelee.Padding = new Padding(3);
            this.tabPAMelee.Size = new Size(610, 0xc0);
            this.tabPAMelee.TabIndex = 0;
            this.tabPAMelee.Text = "Melee";
            this.tabPAMelee.UseVisualStyleBackColor = true;
            this.groupBox6.BackColor = Color.Transparent;
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.pictureBox2);
            this.groupBox6.Controls.Add(this.pictureBox3);
            this.groupBox6.Controls.Add(this.pictureBox4);
            this.groupBox6.Controls.Add(this.pictureBox8);
            this.groupBox6.Controls.Add(this.pictureBox9);
            this.groupBox6.Controls.Add(this.pictureBox10);
            this.groupBox6.Controls.Add(this.pictureBox11);
            this.groupBox6.Controls.Add(this.pictureBox12);
            this.groupBox6.Controls.Add(this.pictureBox13);
            this.groupBox6.Controls.Add(this.pictureBox14);
            this.groupBox6.Controls.Add(this.pictureBox15);
            this.groupBox6.Controls.Add(this.pictureBox16);
            this.groupBox6.Controls.Add(this.pictureBox17);
            this.groupBox6.Controls.Add(this.pictureBox18);
            this.groupBox6.Controls.Add(this.pictureBox19);
            this.groupBox6.Controls.Add(this.pictureBox20);
            this.groupBox6.Controls.Add(this.pictureBox21);
            this.groupBox6.Controls.Add(this.pictureBox22);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.pictureBox23);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.pictureBox24);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.pictureBox25);
            this.groupBox6.Font = new Font("Verdana", 8.25f);
            this.groupBox6.Location = new Point(0x133, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x129, 0x9a);
            this.groupBox6.TabIndex = 0x48;
            this.groupBox6.TabStop = false;
            this.groupBox6.Visible = false;
            this.label3.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label3.Location = new Point(0xc0, 0x74);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x63, 12);
            this.label3.TabIndex = 0x49;
            this.label3.Text = "LV100";
            this.label3.TextAlign = ContentAlignment.TopRight;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 0x74);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x29, 13);
            this.label4.TabIndex = 0x48;
            this.label4.Text = "ACC  ";
            this.label5.AutoSize = true;
            this.label5.Cursor = Cursors.Hand;
            this.label5.Location = new Point(15, 0x65);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x26, 13);
            this.label5.TabIndex = 0x47;
            this.label5.Text = "ATK  ";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(6, 0x56);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x2f, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Effect  ";
            this.label16.Cursor = Cursors.Hand;
            this.label16.Location = new Point(3, 0x47);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x11c, 13);
            this.label16.TabIndex = 0x45;
            this.label16.Text = "Ability  ";
            this.pictureBox2.Image = Resources.rank_S;
            this.pictureBox2.Location = new Point(10, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(10, 10);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0x43;
            this.pictureBox2.TabStop = false;
            this.pictureBox3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox3.Image = Resources.star_s2;
            this.pictureBox3.Location = new Point(230, 0x85);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(0x10, 15);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 0x42;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox4.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox4.Image = Resources.star_s2;
            this.pictureBox4.Location = new Point(0xd7, 0x85);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(0x10, 15);
            this.pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 0x41;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            this.pictureBox8.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox8.Image = Resources.star_s2;
            this.pictureBox8.Location = new Point(200, 0x85);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new Size(0x10, 15);
            this.pictureBox8.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 0x40;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Visible = false;
            this.pictureBox9.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox9.Image = Resources.star_s2;
            this.pictureBox9.Location = new Point(0xb9, 0x85);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new Size(0x10, 15);
            this.pictureBox9.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 0x3f;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Visible = false;
            this.pictureBox10.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox10.Image = Resources.star_S;
            this.pictureBox10.Location = new Point(0xab, 0x85);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new Size(0x10, 15);
            this.pictureBox10.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 0x3e;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Visible = false;
            this.pictureBox11.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox11.Image = Resources.star_S;
            this.pictureBox11.Location = new Point(0x9c, 0x85);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new Size(0x10, 15);
            this.pictureBox11.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox11.TabIndex = 0x3d;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Visible = false;
            this.pictureBox12.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox12.Image = Resources.star_S;
            this.pictureBox12.Location = new Point(0x8d, 0x85);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new Size(0x10, 15);
            this.pictureBox12.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox12.TabIndex = 60;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Visible = false;
            this.pictureBox13.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox13.Image = Resources.star_A;
            this.pictureBox13.Location = new Point(0x7e, 0x85);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new Size(0x10, 15);
            this.pictureBox13.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox13.TabIndex = 0x3b;
            this.pictureBox13.TabStop = false;
            this.pictureBox13.Visible = false;
            this.pictureBox14.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox14.Image = Resources.star_A;
            this.pictureBox14.Location = new Point(0x6f, 0x85);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new Size(0x10, 15);
            this.pictureBox14.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox14.TabIndex = 0x3a;
            this.pictureBox14.TabStop = false;
            this.pictureBox14.Visible = false;
            this.pictureBox15.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox15.Image = Resources.star_A;
            this.pictureBox15.Location = new Point(0x60, 0x85);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new Size(0x10, 15);
            this.pictureBox15.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox15.TabIndex = 0x39;
            this.pictureBox15.TabStop = false;
            this.pictureBox15.Visible = false;
            this.pictureBox16.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox16.Image = Resources.star_B;
            this.pictureBox16.Location = new Point(0x51, 0x85);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new Size(0x10, 15);
            this.pictureBox16.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox16.TabIndex = 0x38;
            this.pictureBox16.TabStop = false;
            this.pictureBox16.Visible = false;
            this.pictureBox17.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox17.Image = Resources.star_B;
            this.pictureBox17.Location = new Point(0x42, 0x85);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new Size(0x10, 15);
            this.pictureBox17.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox17.TabIndex = 0x37;
            this.pictureBox17.TabStop = false;
            this.pictureBox17.Visible = false;
            this.pictureBox18.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox18.Image = Resources.star_B;
            this.pictureBox18.Location = new Point(0x33, 0x85);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new Size(0x10, 15);
            this.pictureBox18.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox18.TabIndex = 0x36;
            this.pictureBox18.TabStop = false;
            this.pictureBox18.Visible = false;
            this.pictureBox19.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox19.Image = Resources.star_C;
            this.pictureBox19.Location = new Point(0x24, 0x85);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new Size(0x10, 15);
            this.pictureBox19.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox19.TabIndex = 0x35;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Visible = false;
            this.pictureBox20.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox20.Image = Resources.star_C;
            this.pictureBox20.Location = new Point(0x15, 0x85);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new Size(0x10, 15);
            this.pictureBox20.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox20.TabIndex = 0x34;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Visible = false;
            this.pictureBox21.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.pictureBox21.Image = Resources.star_C;
            this.pictureBox21.Location = new Point(6, 0x85);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new Size(0x10, 15);
            this.pictureBox21.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox21.TabIndex = 0x33;
            this.pictureBox21.TabStop = false;
            this.pictureBox21.Visible = false;
            this.pictureBox22.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.pictureBox22.Image = Resources.manlogo_GRM;
            this.pictureBox22.Location = new Point(0x111, 12);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new Size(0x11, 0x11);
            this.pictureBox22.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox22.TabIndex = 0x2e;
            this.pictureBox22.TabStop = false;
            this.label18.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label18.Location = new Point(0x51, 0x30);
            this.label18.Name = "label18";
            this.label18.Size = new Size(210, 0x12);
            this.label18.TabIndex = 0x2d;
            this.label18.Text = "(0)";
            this.label18.TextAlign = ContentAlignment.TopRight;
            this.label19.Cursor = Cursors.Hand;
            this.label19.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label19.Location = new Point(8, 30);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0xe0, 0x12);
            this.label19.TabIndex = 0x2c;
            this.label19.Text = "-";
            this.pictureBox23.Cursor = Cursors.Hand;
            this.pictureBox23.Image = Resources.element_neutral;
            this.pictureBox23.Location = new Point(9, 0x31);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new Size(12, 12);
            this.pictureBox23.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox23.TabIndex = 0x29;
            this.pictureBox23.TabStop = false;
            this.label24.AutoSize = true;
            this.label24.Cursor = Cursors.Hand;
            this.label24.Location = new Point(0x15, 0x30);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x1a, 13);
            this.label24.TabIndex = 0x1f;
            this.label24.Text = "0%";
            this.label25.AutoSize = true;
            this.label25.Cursor = Cursors.Hand;
            this.label25.Location = new Point(6, 0x30);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x1a, 13);
            this.label25.TabIndex = 0x2a;
            this.label25.Text = "0/0";
            this.pictureBox24.Image = Resources.armor_icon;
            this.pictureBox24.Location = new Point(10, 15);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Padding = new Padding(13, 0, 0, 0);
            this.pictureBox24.Size = new Size(0x17, 10);
            this.pictureBox24.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox24.TabIndex = 0x2f;
            this.pictureBox24.TabStop = false;
            this.label26.Location = new Point(0x15, 13);
            this.label26.Name = "label26";
            this.label26.Padding = new Padding(13, 0, 0, 0);
            this.label26.Size = new Size(0xd3, 0x12);
            this.label26.TabIndex = 0x2b;
            this.label26.Text = "-";
            this.label30.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.Location = new Point(0x112, 0x20);
            this.label30.Name = "label30";
            this.label30.Size = new Size(13, 13);
            this.label30.TabIndex = 50;
            this.label30.Text = "?";
            this.label30.Visible = false;
            this.pictureBox25.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.pictureBox25.Image = Resources.infinity_item;
            this.pictureBox25.Location = new Point(270, 0x1f);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new Size(20, 0x10);
            this.pictureBox25.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox25.TabIndex = 0x31;
            this.pictureBox25.TabStop = false;
            this.pictureBox25.Visible = false;
            this.txtPAHexMelee.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtPAHexMelee.Cursor = Cursors.Hand;
            this.txtPAHexMelee.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtPAHexMelee.Location = new Point(0x137, 160);
            this.txtPAHexMelee.Name = "txtPAHexMelee";
            this.txtPAHexMelee.Size = new Size(0x61, 13);
            this.txtPAHexMelee.TabIndex = 0x49;
            this.txtPAHexMelee.Text = "0x00000000";
            ColumnHeader[] headerArray4 = new ColumnHeader[] { this.columnHeader2, this.columnHeader4 };
            this.lstPAMelee.Columns.AddRange(headerArray4);
            this.lstPAMelee.Cursor = Cursors.Hand;
            this.lstPAMelee.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lstPAMelee.FullRowSelect = true;
            this.lstPAMelee.HeaderStyle = ColumnHeaderStyle.None;
            this.lstPAMelee.HideSelection = false;
            this.lstPAMelee.LabelWrap = false;
            this.lstPAMelee.Location = new Point(3, 3);
            this.lstPAMelee.MultiSelect = false;
            this.lstPAMelee.Name = "lstPAMelee";
            this.lstPAMelee.Size = new Size(0x12a, 0xb9);
            this.lstPAMelee.SmallImageList = this.paImageList;
            this.lstPAMelee.TabIndex = 0x47;
            this.lstPAMelee.UseCompatibleStateImageBehavior = false;
            this.lstPAMelee.View = View.Details;
            this.lstPAMelee.SelectedIndexChanged += new EventHandler(this.lstPAMelee_SelectedIndexChanged);
            this.columnHeader2.Width = 220;
            this.columnHeader4.Width = 50;
            this.paImageList.ImageStream = (ImageListStreamer) manager.GetObject("paImageList.ImageStream");
            this.paImageList.TransparentColor = Color.Transparent;
            this.paImageList.Images.SetKeyName(0, "sword.png");
            this.paImageList.Images.SetKeyName(1, "knuckles.png");
            this.paImageList.Images.SetKeyName(2, "spear.png");
            this.paImageList.Images.SetKeyName(3, "double_saber.png");
            this.paImageList.Images.SetKeyName(4, "axe.png");
            this.paImageList.Images.SetKeyName(5, "sabers.png");
            this.paImageList.Images.SetKeyName(6, "daggers.png");
            this.paImageList.Images.SetKeyName(7, "claws.png");
            this.paImageList.Images.SetKeyName(8, "saber.png");
            this.paImageList.Images.SetKeyName(9, "dagger.png");
            this.paImageList.Images.SetKeyName(10, "claw.png");
            this.paImageList.Images.SetKeyName(11, "whip.png");
            this.paImageList.Images.SetKeyName(12, "slicer.png");
            this.paImageList.Images.SetKeyName(13, "rifle.png");
            this.paImageList.Images.SetKeyName(14, "shotgun.png");
            this.paImageList.Images.SetKeyName(15, "longbow.png");
            this.paImageList.Images.SetKeyName(0x10, "grenade.png");
            this.paImageList.Images.SetKeyName(0x11, "laser.png");
            this.paImageList.Images.SetKeyName(0x12, "handguns.png");
            this.paImageList.Images.SetKeyName(0x13, "handgun.png");
            this.paImageList.Images.SetKeyName(20, "crossbow.png");
            this.paImageList.Images.SetKeyName(0x15, "cards.png");
            this.paImageList.Images.SetKeyName(0x16, "machinegun.png");
            this.paImageList.Images.SetKeyName(0x17, "rod.png");
            this.paImageList.Images.SetKeyName(0x18, "wand.png");
            this.paImageList.Images.SetKeyName(0x19, "tmag.png");
            this.paImageList.Images.SetKeyName(0x1a, "rmag.png");
            this.paImageList.Images.SetKeyName(0x1b, "shield.png");
            this.paImageList.Images.SetKeyName(0x1c, "element_fire.png");
            this.paImageList.Images.SetKeyName(0x1d, "element_ice.png");
            this.paImageList.Images.SetKeyName(30, "element_thunder.png");
            this.paImageList.Images.SetKeyName(0x1f, "element_earth.png");
            this.paImageList.Images.SetKeyName(0x20, "element_light.png");
            this.paImageList.Images.SetKeyName(0x21, "element_dark.png");
            this.tabPABullets.Controls.Add(this.txtPAHexBullets);
            this.tabPABullets.Controls.Add(this.lstPABullets);
            this.tabPABullets.Location = new Point(4, 0x15);
            this.tabPABullets.Name = "tabPABullets";
            this.tabPABullets.Padding = new Padding(3);
            this.tabPABullets.Size = new Size(610, 0xc0);
            this.tabPABullets.TabIndex = 1;
            this.tabPABullets.Text = "Bullets";
            this.tabPABullets.UseVisualStyleBackColor = true;
            this.txtPAHexBullets.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtPAHexBullets.Cursor = Cursors.Hand;
            this.txtPAHexBullets.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtPAHexBullets.Location = new Point(0x137, 160);
            this.txtPAHexBullets.Name = "txtPAHexBullets";
            this.txtPAHexBullets.Size = new Size(0x61, 13);
            this.txtPAHexBullets.TabIndex = 0x4a;
            this.txtPAHexBullets.Text = "0x00000000";
            ColumnHeader[] headerArray5 = new ColumnHeader[] { this.columnHeader5, this.columnHeader6 };
            this.lstPABullets.Columns.AddRange(headerArray5);
            this.lstPABullets.Cursor = Cursors.Hand;
            this.lstPABullets.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lstPABullets.FullRowSelect = true;
            this.lstPABullets.HeaderStyle = ColumnHeaderStyle.None;
            this.lstPABullets.HideSelection = false;
            this.lstPABullets.LabelWrap = false;
            this.lstPABullets.Location = new Point(3, 3);
            this.lstPABullets.MultiSelect = false;
            this.lstPABullets.Name = "lstPABullets";
            this.lstPABullets.Size = new Size(0x12a, 0xb9);
            this.lstPABullets.SmallImageList = this.paImageList;
            this.lstPABullets.TabIndex = 0x48;
            this.lstPABullets.UseCompatibleStateImageBehavior = false;
            this.lstPABullets.View = View.Details;
            this.lstPABullets.SelectedIndexChanged += new EventHandler(this.lstPABullets_SelectedIndexChanged);
            this.columnHeader5.Width = 220;
            this.columnHeader6.Width = 50;
            this.tabPATech.Controls.Add(this.txtPAHexTech);
            this.tabPATech.Controls.Add(this.lstPATechs);
            this.tabPATech.Location = new Point(4, 0x15);
            this.tabPATech.Name = "tabPATech";
            this.tabPATech.Size = new Size(610, 0xc0);
            this.tabPATech.TabIndex = 2;
            this.tabPATech.Text = "Technique";
            this.tabPATech.UseVisualStyleBackColor = true;
            this.txtPAHexTech.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtPAHexTech.Cursor = Cursors.Hand;
            this.txtPAHexTech.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtPAHexTech.Location = new Point(0x137, 160);
            this.txtPAHexTech.Name = "txtPAHexTech";
            this.txtPAHexTech.Size = new Size(0x61, 13);
            this.txtPAHexTech.TabIndex = 0x4a;
            this.txtPAHexTech.Text = "0x00000000";
            ColumnHeader[] headerArray6 = new ColumnHeader[] { this.columnHeader7, this.columnHeader8 };
            this.lstPATechs.Columns.AddRange(headerArray6);
            this.lstPATechs.Cursor = Cursors.Hand;
            this.lstPATechs.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lstPATechs.FullRowSelect = true;
            this.lstPATechs.HeaderStyle = ColumnHeaderStyle.None;
            this.lstPATechs.HideSelection = false;
            this.lstPATechs.LabelWrap = false;
            this.lstPATechs.Location = new Point(3, 3);
            this.lstPATechs.MultiSelect = false;
            this.lstPATechs.Name = "lstPATechs";
            this.lstPATechs.Size = new Size(0x12a, 0xb9);
            this.lstPATechs.SmallImageList = this.paImageList;
            this.lstPATechs.TabIndex = 0x48;
            this.lstPATechs.UseCompatibleStateImageBehavior = false;
            this.lstPATechs.View = View.Details;
            this.lstPATechs.SelectedIndexChanged += new EventHandler(this.lstPATechs_SelectedIndexChanged);
            this.columnHeader7.Width = 220;
            this.columnHeader8.Width = 50;
            this.tabPageRebirth.Controls.Add(this.chkRebirthNoLevelDrop);
            this.tabPageRebirth.Controls.Add(this.chkRebirthSpoof);
            this.tabPageRebirth.Controls.Add(this.comboRebirthExtend);
            this.tabPageRebirth.Controls.Add(this.btnRebirth);
            this.tabPageRebirth.Controls.Add(this.txtRebirthMaxType);
            this.tabPageRebirth.Controls.Add(this.label33);
            this.tabPageRebirth.Controls.Add(this.lstRebirthRewards);
            this.tabPageRebirth.Controls.Add(this.label17);
            this.tabPageRebirth.Controls.Add(this.label32);
            this.tabPageRebirth.Controls.Add(this.txtRebirthCount);
            this.tabPageRebirth.Controls.Add(this.txtRebirthPoints);
            this.tabPageRebirth.Controls.Add(this.label48);
            this.tabPageRebirth.Controls.Add(this.grpRebirth);
            this.tabPageRebirth.Location = new Point(4, 0x16);
            this.tabPageRebirth.Name = "tabPageRebirth";
            this.tabPageRebirth.Padding = new Padding(3);
            this.tabPageRebirth.Size = new Size(0x275, 0xdf);
            this.tabPageRebirth.TabIndex = 10;
            this.tabPageRebirth.Text = "Rebirth";
            this.tabPageRebirth.UseVisualStyleBackColor = true;
            this.chkRebirthNoLevelDrop.AutoSize = true;
            this.chkRebirthNoLevelDrop.Cursor = Cursors.Hand;
            this.chkRebirthNoLevelDrop.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chkRebirthNoLevelDrop.Location = new Point(0xae, 0xbf);
            this.chkRebirthNoLevelDrop.Name = "chkRebirthNoLevelDrop";
            this.chkRebirthNoLevelDrop.Size = new Size(170, 0x10);
            this.chkRebirthNoLevelDrop.TabIndex = 0x60;
            this.chkRebirthNoLevelDrop.Text = "No Level Drop During Rebirth";
            this.chkRebirthNoLevelDrop.UseVisualStyleBackColor = true;
            this.chkRebirthSpoof.AutoSize = true;
            this.chkRebirthSpoof.Cursor = Cursors.Hand;
            this.chkRebirthSpoof.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chkRebirthSpoof.Location = new Point(9, 0xbf);
            this.chkRebirthSpoof.Name = "chkRebirthSpoof";
            this.chkRebirthSpoof.Size = new Size(0x91, 0x10);
            this.chkRebirthSpoof.TabIndex = 0x5f;
            this.chkRebirthSpoof.Text = "Spoof Level 200 Rebirth";
            this.chkRebirthSpoof.UseVisualStyleBackColor = true;
            this.chkRebirthSpoof.CheckedChanged += new EventHandler(this.chkRebirthSpoof_CheckedChanged);
            this.comboRebirthExtend.Cursor = Cursors.Hand;
            this.comboRebirthExtend.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.comboRebirthExtend.FormattingEnabled = true;
            this.comboRebirthExtend.Location = new Point(9, 0x77);
            this.comboRebirthExtend.Name = "comboRebirthExtend";
            this.comboRebirthExtend.Size = new Size(0x126, 20);
            this.comboRebirthExtend.TabIndex = 0x5e;
            this.btnRebirth.Cursor = Cursors.Hand;
            this.btnRebirth.Enabled = false;
            this.btnRebirth.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnRebirth.Location = new Point(0x131, 0x76);
            this.btnRebirth.Name = "btnRebirth";
            this.btnRebirth.Size = new Size(0x3b, 0x16);
            this.btnRebirth.TabIndex = 0x56;
            this.btnRebirth.Text = "rebirth";
            this.btnRebirth.UseVisualStyleBackColor = true;
            this.btnRebirth.Click += new EventHandler(this.btnRebirth_Click);
            this.txtRebirthMaxType.AutoSize = true;
            this.txtRebirthMaxType.BackColor = Color.Transparent;
            this.txtRebirthMaxType.Cursor = Cursors.Default;
            this.txtRebirthMaxType.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthMaxType.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthMaxType.Location = new Point(0x7a, 0x18);
            this.txtRebirthMaxType.Name = "txtRebirthMaxType";
            this.txtRebirthMaxType.Size = new Size(12, 13);
            this.txtRebirthMaxType.TabIndex = 0x5c;
            this.txtRebirthMaxType.Text = "-";
            this.label33.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label33.BackColor = Color.Transparent;
            this.label33.Cursor = Cursors.Default;
            this.label33.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label33.ForeColor = SystemColors.ActiveCaptionText;
            this.label33.Location = new Point(6, 0x18);
            this.label33.Name = "label33";
            this.label33.Size = new Size(0x70, 13);
            this.label33.TabIndex = 0x5d;
            this.label33.Text = "Max Type Level";
            this.label33.TextAlign = ContentAlignment.MiddleRight;
            ColumnHeader[] headerArray7 = new ColumnHeader[] { this.columnHeader9 };
            this.lstRebirthRewards.Columns.AddRange(headerArray7);
            this.lstRebirthRewards.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lstRebirthRewards.FullRowSelect = true;
            this.lstRebirthRewards.HeaderStyle = ColumnHeaderStyle.None;
            this.lstRebirthRewards.Location = new Point(9, 0x3f);
            this.lstRebirthRewards.MultiSelect = false;
            this.lstRebirthRewards.Name = "lstRebirthRewards";
            this.lstRebirthRewards.Size = new Size(0x163, 0x36);
            this.lstRebirthRewards.TabIndex = 0x5b;
            this.lstRebirthRewards.UseCompatibleStateImageBehavior = false;
            this.lstRebirthRewards.View = View.Details;
            this.lstRebirthRewards.SelectedIndexChanged += new EventHandler(this.lstRebirthRewards_SelectedIndexChanged);
            this.columnHeader9.Width = 0x159;
            this.label17.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label17.ForeColor = Color.DarkRed;
            this.label17.Location = new Point(6, 150);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x175, 30);
            this.label17.TabIndex = 90;
            this.label17.Text = "Note - Bonus points spent on extend codes when rebirthing in game cannot be reversed and are lost forever.";
            this.label32.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label32.BackColor = Color.Transparent;
            this.label32.Cursor = Cursors.Default;
            this.label32.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label32.ForeColor = SystemColors.ActiveCaptionText;
            this.label32.Location = new Point(6, 0x2f);
            this.label32.Name = "label32";
            this.label32.Size = new Size(0x129, 13);
            this.label32.TabIndex = 0x59;
            this.label32.Text = "Current Rebirth Rewards";
            this.label32.TextAlign = ContentAlignment.MiddleLeft;
            this.txtRebirthCount.AutoSize = true;
            this.txtRebirthCount.BackColor = Color.Transparent;
            this.txtRebirthCount.Cursor = Cursors.Default;
            this.txtRebirthCount.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthCount.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthCount.Location = new Point(0x7a, 7);
            this.txtRebirthCount.Name = "txtRebirthCount";
            this.txtRebirthCount.Size = new Size(12, 13);
            this.txtRebirthCount.TabIndex = 0x4c;
            this.txtRebirthCount.Text = "-";
            this.txtRebirthPoints.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txtRebirthPoints.BackColor = Color.Transparent;
            this.txtRebirthPoints.Cursor = Cursors.Default;
            this.txtRebirthPoints.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthPoints.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthPoints.Location = new Point(0x18c, 7);
            this.txtRebirthPoints.Name = "txtRebirthPoints";
            this.txtRebirthPoints.Size = new Size(0xe2, 12);
            this.txtRebirthPoints.TabIndex = 0x4e;
            this.txtRebirthPoints.Text = "-";
            this.txtRebirthPoints.TextAlign = ContentAlignment.MiddleRight;
            this.label48.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label48.BackColor = Color.Transparent;
            this.label48.Cursor = Cursors.Default;
            this.label48.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label48.ForeColor = SystemColors.ActiveCaptionText;
            this.label48.Location = new Point(6, 7);
            this.label48.Name = "label48";
            this.label48.Size = new Size(0x70, 13);
            this.label48.TabIndex = 0x4d;
            this.label48.Text = "Rebirth Count";
            this.label48.TextAlign = ContentAlignment.MiddleRight;
            this.grpRebirth.Controls.Add(this.txtRebirthNextSTA);
            this.grpRebirth.Controls.Add(this.txtRebirthNextPP);
            this.grpRebirth.Controls.Add(this.txtRebirthNextHP);
            this.grpRebirth.Controls.Add(this.txtRebirthNextMND);
            this.grpRebirth.Controls.Add(this.txtRebirthNextTEC);
            this.grpRebirth.Controls.Add(this.txtRebirthNextEVA);
            this.grpRebirth.Controls.Add(this.txtRebirthNextACC);
            this.grpRebirth.Controls.Add(this.txtRebirthNextDEF);
            this.grpRebirth.Controls.Add(this.txtRebirthNextATK);
            this.grpRebirth.Controls.Add(this.txtRebirthBpSTA);
            this.grpRebirth.Controls.Add(this.txtRebirthBpPP);
            this.grpRebirth.Controls.Add(this.txtRebirthBpHP);
            this.grpRebirth.Controls.Add(this.txtRebirthBpMND);
            this.grpRebirth.Controls.Add(this.txtRebirthBpTEC);
            this.grpRebirth.Controls.Add(this.txtRebirthBpEVA);
            this.grpRebirth.Controls.Add(this.txtRebirthBpACC);
            this.grpRebirth.Controls.Add(this.txtRebirthBpDEF);
            this.grpRebirth.Controls.Add(this.txtRebirthBpATK);
            this.grpRebirth.Controls.Add(this.label41);
            this.grpRebirth.Controls.Add(this.label40);
            this.grpRebirth.Controls.Add(this.label37);
            this.grpRebirth.Controls.Add(this.numRebirthSTA);
            this.grpRebirth.Controls.Add(this.txtRebirthSTA);
            this.grpRebirth.Controls.Add(this.label50);
            this.grpRebirth.Controls.Add(this.numRebirthPP);
            this.grpRebirth.Controls.Add(this.numRebirthHP);
            this.grpRebirth.Controls.Add(this.txtRebirthPP);
            this.grpRebirth.Controls.Add(this.label55);
            this.grpRebirth.Controls.Add(this.label56);
            this.grpRebirth.Controls.Add(this.txtRebirthHP);
            this.grpRebirth.Controls.Add(this.numRebirthMND);
            this.grpRebirth.Controls.Add(this.numRebirthTEC);
            this.grpRebirth.Controls.Add(this.numRebirthEVA);
            this.grpRebirth.Controls.Add(this.numRebirthACC);
            this.grpRebirth.Controls.Add(this.numRebirthDEF);
            this.grpRebirth.Controls.Add(this.numRebirthATK);
            this.grpRebirth.Controls.Add(this.txtRebirthMND);
            this.grpRebirth.Controls.Add(this.label53);
            this.grpRebirth.Controls.Add(this.txtRebirthTEC);
            this.grpRebirth.Controls.Add(this.label38);
            this.grpRebirth.Controls.Add(this.txtRebirthEVA);
            this.grpRebirth.Controls.Add(this.txtRebirthACC);
            this.grpRebirth.Controls.Add(this.label42);
            this.grpRebirth.Controls.Add(this.label43);
            this.grpRebirth.Controls.Add(this.txtRebirthDEF);
            this.grpRebirth.Controls.Add(this.label45);
            this.grpRebirth.Controls.Add(this.label49);
            this.grpRebirth.Controls.Add(this.txtRebirthATK);
            this.grpRebirth.Location = new Point(0x18c, 0x10);
            this.grpRebirth.Name = "grpRebirth";
            this.grpRebirth.Size = new Size(0xe4, 0xc9);
            this.grpRebirth.TabIndex = 0x4b;
            this.grpRebirth.TabStop = false;
            this.txtRebirthNextSTA.AutoSize = true;
            this.txtRebirthNextSTA.BackColor = Color.Transparent;
            this.txtRebirthNextSTA.Cursor = Cursors.Default;
            this.txtRebirthNextSTA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextSTA.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextSTA.Location = new Point(0xbb, 180);
            this.txtRebirthNextSTA.Name = "txtRebirthNextSTA";
            this.txtRebirthNextSTA.Size = new Size(10, 12);
            this.txtRebirthNextSTA.TabIndex = 0x6c;
            this.txtRebirthNextSTA.Text = "-";
            this.txtRebirthNextPP.AutoSize = true;
            this.txtRebirthNextPP.BackColor = Color.Transparent;
            this.txtRebirthNextPP.Cursor = Cursors.Default;
            this.txtRebirthNextPP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextPP.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextPP.Location = new Point(0xbb, 0x2f);
            this.txtRebirthNextPP.Name = "txtRebirthNextPP";
            this.txtRebirthNextPP.Size = new Size(10, 12);
            this.txtRebirthNextPP.TabIndex = 0x6b;
            this.txtRebirthNextPP.Text = "-";
            this.txtRebirthNextHP.AutoSize = true;
            this.txtRebirthNextHP.BackColor = Color.Transparent;
            this.txtRebirthNextHP.Cursor = Cursors.Default;
            this.txtRebirthNextHP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextHP.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextHP.Location = new Point(0xbb, 0x1c);
            this.txtRebirthNextHP.Name = "txtRebirthNextHP";
            this.txtRebirthNextHP.Size = new Size(10, 12);
            this.txtRebirthNextHP.TabIndex = 0x6a;
            this.txtRebirthNextHP.Text = "-";
            this.txtRebirthNextMND.AutoSize = true;
            this.txtRebirthNextMND.BackColor = Color.Transparent;
            this.txtRebirthNextMND.Cursor = Cursors.Default;
            this.txtRebirthNextMND.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextMND.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextMND.Location = new Point(0xbb, 0xa1);
            this.txtRebirthNextMND.Name = "txtRebirthNextMND";
            this.txtRebirthNextMND.Size = new Size(10, 12);
            this.txtRebirthNextMND.TabIndex = 0x69;
            this.txtRebirthNextMND.Text = "-";
            this.txtRebirthNextTEC.AutoSize = true;
            this.txtRebirthNextTEC.BackColor = Color.Transparent;
            this.txtRebirthNextTEC.Cursor = Cursors.Default;
            this.txtRebirthNextTEC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextTEC.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextTEC.Location = new Point(0xbb, 0x8e);
            this.txtRebirthNextTEC.Name = "txtRebirthNextTEC";
            this.txtRebirthNextTEC.Size = new Size(10, 12);
            this.txtRebirthNextTEC.TabIndex = 0x68;
            this.txtRebirthNextTEC.Text = "-";
            this.txtRebirthNextEVA.AutoSize = true;
            this.txtRebirthNextEVA.BackColor = Color.Transparent;
            this.txtRebirthNextEVA.Cursor = Cursors.Default;
            this.txtRebirthNextEVA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextEVA.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextEVA.Location = new Point(0xbb, 0x7b);
            this.txtRebirthNextEVA.Name = "txtRebirthNextEVA";
            this.txtRebirthNextEVA.Size = new Size(10, 12);
            this.txtRebirthNextEVA.TabIndex = 0x65;
            this.txtRebirthNextEVA.Text = "-";
            this.txtRebirthNextACC.AutoSize = true;
            this.txtRebirthNextACC.BackColor = Color.Transparent;
            this.txtRebirthNextACC.Cursor = Cursors.Default;
            this.txtRebirthNextACC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextACC.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextACC.Location = new Point(0xbb, 0x68);
            this.txtRebirthNextACC.Name = "txtRebirthNextACC";
            this.txtRebirthNextACC.Size = new Size(10, 12);
            this.txtRebirthNextACC.TabIndex = 0x67;
            this.txtRebirthNextACC.Text = "-";
            this.txtRebirthNextDEF.AutoSize = true;
            this.txtRebirthNextDEF.BackColor = Color.Transparent;
            this.txtRebirthNextDEF.Cursor = Cursors.Default;
            this.txtRebirthNextDEF.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextDEF.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextDEF.Location = new Point(0xbb, 0x55);
            this.txtRebirthNextDEF.Name = "txtRebirthNextDEF";
            this.txtRebirthNextDEF.Size = new Size(10, 12);
            this.txtRebirthNextDEF.TabIndex = 0x66;
            this.txtRebirthNextDEF.Text = "-";
            this.txtRebirthNextATK.AutoSize = true;
            this.txtRebirthNextATK.BackColor = Color.Transparent;
            this.txtRebirthNextATK.Cursor = Cursors.Default;
            this.txtRebirthNextATK.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthNextATK.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthNextATK.Location = new Point(0xbb, 0x42);
            this.txtRebirthNextATK.Name = "txtRebirthNextATK";
            this.txtRebirthNextATK.Size = new Size(10, 12);
            this.txtRebirthNextATK.TabIndex = 100;
            this.txtRebirthNextATK.Text = "-";
            this.txtRebirthBpSTA.AutoSize = true;
            this.txtRebirthBpSTA.BackColor = Color.Transparent;
            this.txtRebirthBpSTA.Cursor = Cursors.Default;
            this.txtRebirthBpSTA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpSTA.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpSTA.Location = new Point(0x5e, 180);
            this.txtRebirthBpSTA.Name = "txtRebirthBpSTA";
            this.txtRebirthBpSTA.Size = new Size(10, 12);
            this.txtRebirthBpSTA.TabIndex = 0x63;
            this.txtRebirthBpSTA.Text = "-";
            this.txtRebirthBpPP.AutoSize = true;
            this.txtRebirthBpPP.BackColor = Color.Transparent;
            this.txtRebirthBpPP.Cursor = Cursors.Default;
            this.txtRebirthBpPP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpPP.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpPP.Location = new Point(0x5e, 0x2f);
            this.txtRebirthBpPP.Name = "txtRebirthBpPP";
            this.txtRebirthBpPP.Size = new Size(10, 12);
            this.txtRebirthBpPP.TabIndex = 0x62;
            this.txtRebirthBpPP.Text = "-";
            this.txtRebirthBpHP.AutoSize = true;
            this.txtRebirthBpHP.BackColor = Color.Transparent;
            this.txtRebirthBpHP.Cursor = Cursors.Default;
            this.txtRebirthBpHP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpHP.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpHP.Location = new Point(0x5e, 0x1c);
            this.txtRebirthBpHP.Name = "txtRebirthBpHP";
            this.txtRebirthBpHP.Size = new Size(10, 12);
            this.txtRebirthBpHP.TabIndex = 0x61;
            this.txtRebirthBpHP.Text = "-";
            this.txtRebirthBpMND.AutoSize = true;
            this.txtRebirthBpMND.BackColor = Color.Transparent;
            this.txtRebirthBpMND.Cursor = Cursors.Default;
            this.txtRebirthBpMND.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpMND.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpMND.Location = new Point(0x5e, 0xa1);
            this.txtRebirthBpMND.Name = "txtRebirthBpMND";
            this.txtRebirthBpMND.Size = new Size(10, 12);
            this.txtRebirthBpMND.TabIndex = 0x60;
            this.txtRebirthBpMND.Text = "-";
            this.txtRebirthBpTEC.AutoSize = true;
            this.txtRebirthBpTEC.BackColor = Color.Transparent;
            this.txtRebirthBpTEC.Cursor = Cursors.Default;
            this.txtRebirthBpTEC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpTEC.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpTEC.Location = new Point(0x5e, 0x8e);
            this.txtRebirthBpTEC.Name = "txtRebirthBpTEC";
            this.txtRebirthBpTEC.Size = new Size(10, 12);
            this.txtRebirthBpTEC.TabIndex = 0x5f;
            this.txtRebirthBpTEC.Text = "-";
            this.txtRebirthBpEVA.AutoSize = true;
            this.txtRebirthBpEVA.BackColor = Color.Transparent;
            this.txtRebirthBpEVA.Cursor = Cursors.Default;
            this.txtRebirthBpEVA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpEVA.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpEVA.Location = new Point(0x5e, 0x7b);
            this.txtRebirthBpEVA.Name = "txtRebirthBpEVA";
            this.txtRebirthBpEVA.Size = new Size(10, 12);
            this.txtRebirthBpEVA.TabIndex = 0x5c;
            this.txtRebirthBpEVA.Text = "-";
            this.txtRebirthBpACC.AutoSize = true;
            this.txtRebirthBpACC.BackColor = Color.Transparent;
            this.txtRebirthBpACC.Cursor = Cursors.Default;
            this.txtRebirthBpACC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpACC.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpACC.Location = new Point(0x5e, 0x68);
            this.txtRebirthBpACC.Name = "txtRebirthBpACC";
            this.txtRebirthBpACC.Size = new Size(10, 12);
            this.txtRebirthBpACC.TabIndex = 0x5e;
            this.txtRebirthBpACC.Text = "-";
            this.txtRebirthBpDEF.AutoSize = true;
            this.txtRebirthBpDEF.BackColor = Color.Transparent;
            this.txtRebirthBpDEF.Cursor = Cursors.Default;
            this.txtRebirthBpDEF.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpDEF.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpDEF.Location = new Point(0x5e, 0x55);
            this.txtRebirthBpDEF.Name = "txtRebirthBpDEF";
            this.txtRebirthBpDEF.Size = new Size(10, 12);
            this.txtRebirthBpDEF.TabIndex = 0x5d;
            this.txtRebirthBpDEF.Text = "-";
            this.txtRebirthBpATK.AutoSize = true;
            this.txtRebirthBpATK.BackColor = Color.Transparent;
            this.txtRebirthBpATK.Cursor = Cursors.Default;
            this.txtRebirthBpATK.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthBpATK.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthBpATK.Location = new Point(0x5e, 0x42);
            this.txtRebirthBpATK.Name = "txtRebirthBpATK";
            this.txtRebirthBpATK.Size = new Size(10, 12);
            this.txtRebirthBpATK.TabIndex = 0x5b;
            this.txtRebirthBpATK.Text = "-";
            this.label41.BackColor = Color.Transparent;
            this.label41.Cursor = Cursors.Default;
            this.label41.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label41.ForeColor = Color.DimGray;
            this.label41.Location = new Point(0xbb, 9);
            this.label41.Name = "label41";
            this.label41.Size = new Size(0x27, 13);
            this.label41.TabIndex = 90;
            this.label41.Text = "NEXT";
            this.label41.TextAlign = ContentAlignment.MiddleLeft;
            this.label40.BackColor = Color.Transparent;
            this.label40.Cursor = Cursors.Default;
            this.label40.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label40.ForeColor = Color.DimGray;
            this.label40.Location = new Point(0x5e, 9);
            this.label40.Name = "label40";
            this.label40.Size = new Size(0x30, 13);
            this.label40.TabIndex = 0x59;
            this.label40.Text = "BP";
            this.label40.TextAlign = ContentAlignment.MiddleLeft;
            this.label37.BackColor = Color.Transparent;
            this.label37.Cursor = Cursors.Default;
            this.label37.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label37.ForeColor = Color.DimGray;
            this.label37.Location = new Point(11, 9);
            this.label37.Name = "label37";
            this.label37.Size = new Size(0x30, 13);
            this.label37.TabIndex = 0x58;
            this.label37.Text = "STAT";
            this.label37.TextAlign = ContentAlignment.MiddleRight;
            this.numRebirthSTA.Cursor = Cursors.Hand;
            this.numRebirthSTA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthSTA.Location = new Point(0x94, 0xb2);
            this.numRebirthSTA.Maximum = new decimal(new int[] { 10 });
            this.numRebirthSTA.Name = "numRebirthSTA";
            this.numRebirthSTA.Size = new Size(0x25, 0x12);
            this.numRebirthSTA.TabIndex = 0x57;
            this.numRebirthSTA.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.txtRebirthSTA.AutoSize = true;
            this.txtRebirthSTA.BackColor = Color.Transparent;
            this.txtRebirthSTA.Cursor = Cursors.Default;
            this.txtRebirthSTA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthSTA.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthSTA.Location = new Point(0x31, 180);
            this.txtRebirthSTA.Name = "txtRebirthSTA";
            this.txtRebirthSTA.Size = new Size(10, 12);
            this.txtRebirthSTA.TabIndex = 0x56;
            this.txtRebirthSTA.Text = "-";
            this.label50.BackColor = Color.Transparent;
            this.label50.Cursor = Cursors.Default;
            this.label50.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label50.ForeColor = SystemColors.ActiveCaptionText;
            this.label50.Location = new Point(11, 180);
            this.label50.Name = "label50";
            this.label50.Size = new Size(0x21, 13);
            this.label50.TabIndex = 0x55;
            this.label50.Text = "STA";
            this.label50.TextAlign = ContentAlignment.MiddleRight;
            this.numRebirthPP.Cursor = Cursors.Hand;
            this.numRebirthPP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthPP.Location = new Point(0x94, 0x2d);
            this.numRebirthPP.Maximum = new decimal(new int[] { 10 });
            this.numRebirthPP.Name = "numRebirthPP";
            this.numRebirthPP.Size = new Size(0x25, 0x12);
            this.numRebirthPP.TabIndex = 0x54;
            this.numRebirthPP.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.numRebirthHP.Cursor = Cursors.Hand;
            this.numRebirthHP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthHP.Location = new Point(0x94, 0x1a);
            this.numRebirthHP.Maximum = new decimal(new int[] { 10 });
            this.numRebirthHP.Name = "numRebirthHP";
            this.numRebirthHP.Size = new Size(0x25, 0x12);
            this.numRebirthHP.TabIndex = 0x53;
            this.numRebirthHP.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.txtRebirthPP.AutoSize = true;
            this.txtRebirthPP.BackColor = Color.Transparent;
            this.txtRebirthPP.Cursor = Cursors.Default;
            this.txtRebirthPP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthPP.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthPP.Location = new Point(0x31, 0x2f);
            this.txtRebirthPP.Name = "txtRebirthPP";
            this.txtRebirthPP.Size = new Size(10, 12);
            this.txtRebirthPP.TabIndex = 0x52;
            this.txtRebirthPP.Text = "-";
            this.label55.BackColor = Color.Transparent;
            this.label55.Cursor = Cursors.Default;
            this.label55.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label55.ForeColor = SystemColors.ActiveCaptionText;
            this.label55.Location = new Point(11, 0x2f);
            this.label55.Name = "label55";
            this.label55.Size = new Size(0x21, 13);
            this.label55.TabIndex = 0x51;
            this.label55.Text = "PP";
            this.label55.TextAlign = ContentAlignment.MiddleRight;
            this.label56.BackColor = Color.Transparent;
            this.label56.Cursor = Cursors.Default;
            this.label56.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label56.ForeColor = SystemColors.ActiveCaptionText;
            this.label56.Location = new Point(11, 0x1c);
            this.label56.Name = "label56";
            this.label56.Size = new Size(0x21, 13);
            this.label56.TabIndex = 0x4f;
            this.label56.Text = "HP";
            this.label56.TextAlign = ContentAlignment.MiddleRight;
            this.txtRebirthHP.AutoSize = true;
            this.txtRebirthHP.BackColor = Color.Transparent;
            this.txtRebirthHP.Cursor = Cursors.Default;
            this.txtRebirthHP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthHP.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthHP.Location = new Point(0x31, 0x1c);
            this.txtRebirthHP.Name = "txtRebirthHP";
            this.txtRebirthHP.Size = new Size(10, 12);
            this.txtRebirthHP.TabIndex = 80;
            this.txtRebirthHP.Text = "-";
            this.numRebirthMND.Cursor = Cursors.Hand;
            this.numRebirthMND.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthMND.Location = new Point(0x94, 0x9f);
            this.numRebirthMND.Maximum = new decimal(new int[] { 10 });
            this.numRebirthMND.Name = "numRebirthMND";
            this.numRebirthMND.Size = new Size(0x25, 0x12);
            this.numRebirthMND.TabIndex = 0x4a;
            this.numRebirthMND.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.numRebirthTEC.Cursor = Cursors.Hand;
            this.numRebirthTEC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthTEC.Location = new Point(0x94, 140);
            this.numRebirthTEC.Maximum = new decimal(new int[] { 10 });
            this.numRebirthTEC.Name = "numRebirthTEC";
            this.numRebirthTEC.Size = new Size(0x25, 0x12);
            this.numRebirthTEC.TabIndex = 0x49;
            this.numRebirthTEC.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.numRebirthEVA.Cursor = Cursors.Hand;
            this.numRebirthEVA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthEVA.Location = new Point(0x94, 0x79);
            this.numRebirthEVA.Maximum = new decimal(new int[] { 10 });
            this.numRebirthEVA.Name = "numRebirthEVA";
            this.numRebirthEVA.Size = new Size(0x25, 0x12);
            this.numRebirthEVA.TabIndex = 0x48;
            this.numRebirthEVA.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.numRebirthACC.Cursor = Cursors.Hand;
            this.numRebirthACC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthACC.Location = new Point(0x94, 0x66);
            this.numRebirthACC.Maximum = new decimal(new int[] { 10 });
            this.numRebirthACC.Name = "numRebirthACC";
            this.numRebirthACC.Size = new Size(0x25, 0x12);
            this.numRebirthACC.TabIndex = 0x47;
            this.numRebirthACC.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.numRebirthDEF.Cursor = Cursors.Hand;
            this.numRebirthDEF.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthDEF.Location = new Point(0x94, 0x53);
            this.numRebirthDEF.Maximum = new decimal(new int[] { 10 });
            this.numRebirthDEF.Name = "numRebirthDEF";
            this.numRebirthDEF.Size = new Size(0x25, 0x12);
            this.numRebirthDEF.TabIndex = 70;
            this.numRebirthDEF.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.numRebirthATK.Cursor = Cursors.Hand;
            this.numRebirthATK.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.numRebirthATK.Location = new Point(0x94, 0x40);
            this.numRebirthATK.Maximum = new decimal(new int[] { 10 });
            this.numRebirthATK.Name = "numRebirthATK";
            this.numRebirthATK.Size = new Size(0x25, 0x12);
            this.numRebirthATK.TabIndex = 0x45;
            this.numRebirthATK.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
            this.txtRebirthMND.AutoSize = true;
            this.txtRebirthMND.BackColor = Color.Transparent;
            this.txtRebirthMND.Cursor = Cursors.Default;
            this.txtRebirthMND.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthMND.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthMND.Location = new Point(0x31, 0xa1);
            this.txtRebirthMND.Name = "txtRebirthMND";
            this.txtRebirthMND.Size = new Size(10, 12);
            this.txtRebirthMND.TabIndex = 0x44;
            this.txtRebirthMND.Text = "-";
            this.label53.BackColor = Color.Transparent;
            this.label53.Cursor = Cursors.Default;
            this.label53.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label53.ForeColor = SystemColors.ActiveCaptionText;
            this.label53.Location = new Point(11, 0xa1);
            this.label53.Name = "label53";
            this.label53.Size = new Size(0x21, 13);
            this.label53.TabIndex = 0x43;
            this.label53.Text = "MND";
            this.label53.TextAlign = ContentAlignment.MiddleRight;
            this.txtRebirthTEC.AutoSize = true;
            this.txtRebirthTEC.BackColor = Color.Transparent;
            this.txtRebirthTEC.Cursor = Cursors.Default;
            this.txtRebirthTEC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthTEC.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthTEC.Location = new Point(0x31, 0x8e);
            this.txtRebirthTEC.Name = "txtRebirthTEC";
            this.txtRebirthTEC.Size = new Size(10, 12);
            this.txtRebirthTEC.TabIndex = 0x42;
            this.txtRebirthTEC.Text = "-";
            this.label38.BackColor = Color.Transparent;
            this.label38.Cursor = Cursors.Default;
            this.label38.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label38.ForeColor = SystemColors.ActiveCaptionText;
            this.label38.Location = new Point(11, 0x8e);
            this.label38.Name = "label38";
            this.label38.Size = new Size(0x21, 13);
            this.label38.TabIndex = 0x41;
            this.label38.Text = "TEC";
            this.label38.TextAlign = ContentAlignment.MiddleRight;
            this.txtRebirthEVA.AutoSize = true;
            this.txtRebirthEVA.BackColor = Color.Transparent;
            this.txtRebirthEVA.Cursor = Cursors.Default;
            this.txtRebirthEVA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthEVA.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthEVA.Location = new Point(0x31, 0x7b);
            this.txtRebirthEVA.Name = "txtRebirthEVA";
            this.txtRebirthEVA.Size = new Size(10, 12);
            this.txtRebirthEVA.TabIndex = 60;
            this.txtRebirthEVA.Text = "-";
            this.txtRebirthACC.AutoSize = true;
            this.txtRebirthACC.BackColor = Color.Transparent;
            this.txtRebirthACC.Cursor = Cursors.Default;
            this.txtRebirthACC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthACC.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthACC.Location = new Point(0x31, 0x68);
            this.txtRebirthACC.Name = "txtRebirthACC";
            this.txtRebirthACC.Size = new Size(10, 12);
            this.txtRebirthACC.TabIndex = 0x40;
            this.txtRebirthACC.Text = "-";
            this.label42.BackColor = Color.Transparent;
            this.label42.Cursor = Cursors.Default;
            this.label42.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label42.ForeColor = SystemColors.ActiveCaptionText;
            this.label42.Location = new Point(11, 0x7b);
            this.label42.Name = "label42";
            this.label42.Size = new Size(0x21, 13);
            this.label42.TabIndex = 0x3b;
            this.label42.Text = "EVA";
            this.label42.TextAlign = ContentAlignment.MiddleRight;
            this.label43.BackColor = Color.Transparent;
            this.label43.Cursor = Cursors.Default;
            this.label43.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label43.ForeColor = SystemColors.ActiveCaptionText;
            this.label43.Location = new Point(11, 0x68);
            this.label43.Name = "label43";
            this.label43.Size = new Size(0x21, 13);
            this.label43.TabIndex = 0x3f;
            this.label43.Text = "ACC";
            this.label43.TextAlign = ContentAlignment.MiddleRight;
            this.txtRebirthDEF.AutoSize = true;
            this.txtRebirthDEF.BackColor = Color.Transparent;
            this.txtRebirthDEF.Cursor = Cursors.Default;
            this.txtRebirthDEF.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthDEF.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthDEF.Location = new Point(0x31, 0x55);
            this.txtRebirthDEF.Name = "txtRebirthDEF";
            this.txtRebirthDEF.Size = new Size(10, 12);
            this.txtRebirthDEF.TabIndex = 0x3e;
            this.txtRebirthDEF.Text = "-";
            this.label45.BackColor = Color.Transparent;
            this.label45.Cursor = Cursors.Default;
            this.label45.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label45.ForeColor = SystemColors.ActiveCaptionText;
            this.label45.Location = new Point(11, 0x55);
            this.label45.Name = "label45";
            this.label45.Size = new Size(0x21, 13);
            this.label45.TabIndex = 0x3d;
            this.label45.Text = "DEF";
            this.label45.TextAlign = ContentAlignment.MiddleRight;
            this.label49.BackColor = Color.Transparent;
            this.label49.Cursor = Cursors.Default;
            this.label49.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label49.ForeColor = SystemColors.ActiveCaptionText;
            this.label49.Location = new Point(11, 0x42);
            this.label49.Name = "label49";
            this.label49.Size = new Size(0x21, 13);
            this.label49.TabIndex = 0x39;
            this.label49.Text = "ATK";
            this.label49.TextAlign = ContentAlignment.MiddleRight;
            this.txtRebirthATK.AutoSize = true;
            this.txtRebirthATK.BackColor = Color.Transparent;
            this.txtRebirthATK.Cursor = Cursors.Default;
            this.txtRebirthATK.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtRebirthATK.ForeColor = SystemColors.ActiveCaptionText;
            this.txtRebirthATK.Location = new Point(0x31, 0x42);
            this.txtRebirthATK.Name = "txtRebirthATK";
            this.txtRebirthATK.Size = new Size(10, 12);
            this.txtRebirthATK.TabIndex = 0x3a;
            this.txtRebirthATK.Text = "-";
            this.btnUndoAll.Cursor = Cursors.Hand;
            this.btnUndoAll.Enabled = false;
            this.btnUndoAll.Location = new Point(0x80, 0x1e8);
            this.btnUndoAll.Name = "btnUndoAll";
            this.btnUndoAll.Size = new Size(0x3b, 0x17);
            this.btnUndoAll.TabIndex = 0x17;
            this.btnUndoAll.Text = "reload";
            this.btnUndoAll.UseVisualStyleBackColor = true;
            this.btnUndoAll.Click += new EventHandler(this.btnUndoAll_Click);
            this.btnSaveAs.Cursor = Cursors.Hand;
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Location = new Point(0x42, 0x1e8);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new Size(60, 0x17);
            this.btnSaveAs.TabIndex = 0x18;
            this.btnSaveAs.Text = "save as";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new EventHandler(this.btnSaveAs_Click);
            this.sexImageList.ImageStream = (ImageListStreamer) manager.GetObject("sexImageList.ImageStream");
            this.sexImageList.TransparentColor = Color.Transparent;
            this.sexImageList.Images.SetKeyName(0, "male-icon.ico");
            this.sexImageList.Images.SetKeyName(1, "female.png");
            this.sexImageList.Images.SetKeyName(2, "free_slot_2.ico");
            this.armourImageList.ImageStream = (ImageListStreamer) manager.GetObject("armourImageList.ImageStream");
            this.armourImageList.TransparentColor = Color.Transparent;
            this.armourImageList.Images.SetKeyName(0, "001_c_armour.jpg");
            this.armourImageList.Images.SetKeyName(1, "002_b_armour.jpg");
            this.armourImageList.Images.SetKeyName(2, "003_a_armour.jpg");
            this.armourImageList.Images.SetKeyName(3, "004_s_armour.jpg");
            this.armourImageList.Images.SetKeyName(4, "005_unk_armour.jpg");
            this.armourImageList.Images.SetKeyName(5, "001_c_armour.jpg");
            this.armourImageList.Images.SetKeyName(6, "002_b_armour.jpg");
            this.armourImageList.Images.SetKeyName(7, "003_a_armour.jpg");
            this.armourImageList.Images.SetKeyName(8, "004_s_armour.jpg");
            this.armourImageList.Images.SetKeyName(9, "005_unk_armour.jpg");
            this.armourImageList.Images.SetKeyName(10, "001_c_armour.jpg");
            this.armourImageList.Images.SetKeyName(11, "002_b_armour.jpg");
            this.armourImageList.Images.SetKeyName(12, "003_a_armour.jpg");
            this.armourImageList.Images.SetKeyName(13, "004_s_armour.jpg");
            this.armourImageList.Images.SetKeyName(14, "005_unk_armour.jpg");
            this.armourImageList.Images.SetKeyName(15, "a_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x10, "a_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x11, "a_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x12, "a_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x13, "b_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(20, "b_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x15, "b_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x16, "b_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x17, "c_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x18, "c_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x19, "c_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x1a, "c_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x1b, "s_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x1c, "s_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x1d, "s_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(30, "s_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x1f, "unk_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x20, "unk_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x21, "unk_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x22, "unk_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x23, "a_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x24, "a_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x25, "a_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x26, "a_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x27, "b_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(40, "b_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x29, "b_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x2a, "b_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x2b, "c_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x2c, "c_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x2d, "c_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x2e, "c_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x2f, "s_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x30, "s_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x31, "s_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(50, "s_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x33, "unk_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x34, "unk_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x35, "unk_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x36, "unk_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x37, "a_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x38, "a_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x39, "a_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x3a, "a_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x3b, "b_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(60, "b_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x3d, "b_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x3e, "b_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x3f, "c_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x40, "c_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x41, "c_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x42, "c_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x43, "s_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x44, "s_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x45, "s_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(70, "s_004_unit_visual.jpg");
            this.armourImageList.Images.SetKeyName(0x47, "unk_001_unit.jpg");
            this.armourImageList.Images.SetKeyName(0x48, "unk_002_unit_mirage.jpg");
            this.armourImageList.Images.SetKeyName(0x49, "unk_003_unit_suv.jpg");
            this.armourImageList.Images.SetKeyName(0x4a, "unk_004_unit_visual.jpg");
            this.itemImageList.ImageStream = (ImageListStreamer) manager.GetObject("itemImageList.ImageStream");
            this.itemImageList.TransparentColor = Color.Transparent;
            this.itemImageList.Images.SetKeyName(0, "item_01_pa_disk.png");
            this.itemImageList.Images.SetKeyName(1, "item_02_trap.png");
            this.itemImageList.Images.SetKeyName(2, "item_03_trap_ex.png");
            this.itemImageList.Images.SetKeyName(3, "item_04_mate.png");
            this.itemImageList.Images.SetKeyName(4, "item_05_sol.png");
            this.itemImageList.Images.SetKeyName(5, "item_06_doll.png");
            this.itemImageList.Images.SetKeyName(6, "item_07_buff.png");
            this.itemImageList.Images.SetKeyName(7, "item_08_calorie.png");
            this.itemImageList.Images.SetKeyName(8, "item_09.png");
            this.itemImageList.Images.SetKeyName(9, "item_01_pa_disk.png");
            this.itemImageList.Images.SetKeyName(10, "item_02_trap.png");
            this.itemImageList.Images.SetKeyName(11, "item_03_trap_ex.png");
            this.itemImageList.Images.SetKeyName(12, "item_04_mate.png");
            this.itemImageList.Images.SetKeyName(13, "item_05_sol.png");
            this.itemImageList.Images.SetKeyName(14, "item_06_doll.png");
            this.itemImageList.Images.SetKeyName(15, "item_07_buff.png");
            this.itemImageList.Images.SetKeyName(0x10, "item_08_calorie.png");
            this.itemImageList.Images.SetKeyName(0x11, "item_09.png");
            this.itemImageList.Images.SetKeyName(0x12, "item_01_pa_disk.png");
            this.itemImageList.Images.SetKeyName(0x13, "item_02_trap.png");
            this.itemImageList.Images.SetKeyName(20, "item_03_trap_ex.png");
            this.itemImageList.Images.SetKeyName(0x15, "item_04_mate.png");
            this.itemImageList.Images.SetKeyName(0x16, "item_05_sol.png");
            this.itemImageList.Images.SetKeyName(0x17, "item_06_doll.png");
            this.itemImageList.Images.SetKeyName(0x18, "item_07_buff.png");
            this.itemImageList.Images.SetKeyName(0x19, "item_08_calorie.png");
            this.itemImageList.Images.SetKeyName(0x1a, "item_09.png");
            this.clothesImageList.ImageStream = (ImageListStreamer) manager.GetObject("clothesImageList.ImageStream");
            this.clothesImageList.TransparentColor = Color.Transparent;
            this.clothesImageList.Images.SetKeyName(0, "clothes_01_top.png");
            this.clothesImageList.Images.SetKeyName(1, "clothes_02_bottom.png");
            this.clothesImageList.Images.SetKeyName(2, "clothes_03_shoes.png");
            this.clothesImageList.Images.SetKeyName(3, "clothes_04_top_set.png");
            this.clothesImageList.Images.SetKeyName(4, "clothes_05_bottom_set.png");
            this.clothesImageList.Images.SetKeyName(5, "clothes_06_set.png");
            this.clothesImageList.Images.SetKeyName(6, "parts_01_torso.png");
            this.clothesImageList.Images.SetKeyName(7, "parts_02_legs.png");
            this.clothesImageList.Images.SetKeyName(8, "parts_03_arms.png");
            this.clothesImageList.Images.SetKeyName(9, "parts_04_set.png");
            this.clothesImageList.Images.SetKeyName(10, "clothes_01_top.png");
            this.clothesImageList.Images.SetKeyName(11, "clothes_02_bottom.png");
            this.clothesImageList.Images.SetKeyName(12, "clothes_03_shoes.png");
            this.clothesImageList.Images.SetKeyName(13, "clothes_04_top_set.png");
            this.clothesImageList.Images.SetKeyName(14, "clothes_05_bottom_set.png");
            this.clothesImageList.Images.SetKeyName(15, "clothes_06_set.png");
            this.clothesImageList.Images.SetKeyName(0x10, "parts_01_torso.png");
            this.clothesImageList.Images.SetKeyName(0x11, "parts_02_legs.png");
            this.clothesImageList.Images.SetKeyName(0x12, "parts_03_arms.png");
            this.clothesImageList.Images.SetKeyName(0x13, "parts_04_set.png");
            this.clothesImageList.Images.SetKeyName(20, "clothes_01_top.png");
            this.clothesImageList.Images.SetKeyName(0x15, "clothes_02_bottom.png");
            this.clothesImageList.Images.SetKeyName(0x16, "clothes_03_shoes.png");
            this.clothesImageList.Images.SetKeyName(0x17, "clothes_04_top_set.png");
            this.clothesImageList.Images.SetKeyName(0x18, "clothes_05_bottom_set.png");
            this.clothesImageList.Images.SetKeyName(0x19, "clothes_06_set.png");
            this.clothesImageList.Images.SetKeyName(0x1a, "parts_01_torso.png");
            this.clothesImageList.Images.SetKeyName(0x1b, "parts_02_legs.png");
            this.clothesImageList.Images.SetKeyName(0x1c, "parts_03_arms.png");
            this.clothesImageList.Images.SetKeyName(0x1d, "parts_04_set.png");
            this.decoImageList.ImageStream = (ImageListStreamer) manager.GetObject("decoImageList.ImageStream");
            this.decoImageList.TransparentColor = Color.Transparent;
            this.decoImageList.Images.SetKeyName(0, "item_extend.png");
            this.decoImageList.Images.SetKeyName(1, "item_pm.png");
            this.decoImageList.Images.SetKeyName(2, "item_decoration.png");
            this.decoImageList.Images.SetKeyName(3, "free_slot.png");
            this.menuStrip.ImageScalingSize = new Size(0, 0);
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.fileToolStripMenuItem, this.databasesToolStripMenuItem, this.imagesToolStripMenuItem, this.helpToolStripMenuItem };
            this.menuStrip.Items.AddRange(toolStripItems);
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(650, 0x18);
            this.menuStrip.TabIndex = 0x49;
            this.menuStrip.Text = "menuStrip1";
            ToolStripItem[] itemArray2 = new ToolStripItem[] { this.openToolStripMenuItem, this.saveToolStripMenuItem, this.saveAsToolStripMenuItem, this.toolStripSeparator2, this.updateToolStripMenuItem, this.toolStripSeparator3, this.exitToolStripMenuItem };
            this.fileToolStripMenuItem.DropDownItems.AddRange(itemArray2);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(0x25, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.openToolStripMenuItem.Image = Resources.open1;
            this.openToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            this.openToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
            this.saveToolStripMenuItem.Image = Resources.save_icon;
            this.saveToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(0xa8, 6);
            this.updateToolStripMenuItem.Image = Resources.check_for_update;
            this.updateToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.updateToolStripMenuItem.Text = "Check For Updates";
            this.updateToolStripMenuItem.Click += new EventHandler(this.updateToolStripMenuItem_Click);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(0xa8, 6);
            this.exitToolStripMenuItem.Image = Resources.exit1;
            this.exitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            ToolStripItem[] itemArray3 = new ToolStripItem[] { this.itemDatabasesToolStripMenuItem, this.toolStripSeparator1, this.refreshToolStripMenuItem, this.checkForUpdatesToolStripMenuItem };
            this.databasesToolStripMenuItem.DropDownItems.AddRange(itemArray3);
            this.databasesToolStripMenuItem.Name = "databasesToolStripMenuItem";
            this.databasesToolStripMenuItem.Size = new Size(0x48, 20);
            this.databasesToolStripMenuItem.Text = "Databases";
            ToolStripItem[] itemArray4 = new ToolStripItem[] { this.weaponDatabaseToolStripMenuItem };
            this.itemDatabasesToolStripMenuItem.DropDownItems.AddRange(itemArray4);
            this.itemDatabasesToolStripMenuItem.Image = Resources.database_import;
            this.itemDatabasesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            this.itemDatabasesToolStripMenuItem.Name = "itemDatabasesToolStripMenuItem";
            this.itemDatabasesToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.itemDatabasesToolStripMenuItem.Text = "Item Databases";
            this.weaponDatabaseToolStripMenuItem.Name = "weaponDatabaseToolStripMenuItem";
            this.weaponDatabaseToolStripMenuItem.Size = new Size(0xa9, 0x16);
            this.weaponDatabaseToolStripMenuItem.Text = "Weapon Database";
            this.weaponDatabaseToolStripMenuItem.Click += new EventHandler(this.weaponDatabaseToolStripMenuItem_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(0xa8, 6);
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new EventHandler(this.refreshToolStripMenuItem_Click);
            this.checkForUpdatesToolStripMenuItem.Image = Resources.check_for_update;
            this.checkForUpdatesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            ToolStripItem[] itemArray5 = new ToolStripItem[] { this.refreshToolStripMenuItem1, this.checkForUpdatesToolStripMenuItem1 };
            this.imagesToolStripMenuItem.DropDownItems.AddRange(itemArray5);
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new Size(0x37, 20);
            this.imagesToolStripMenuItem.Text = "Images";
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new Size(0xab, 0x16);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new EventHandler(this.refreshToolStripMenuItem1_Click);
            this.checkForUpdatesToolStripMenuItem1.Image = Resources.check_for_update;
            this.checkForUpdatesToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            this.checkForUpdatesToolStripMenuItem1.Name = "checkForUpdatesToolStripMenuItem1";
            this.checkForUpdatesToolStripMenuItem1.Size = new Size(0xab, 0x16);
            this.checkForUpdatesToolStripMenuItem1.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem1.Click += new EventHandler(this.checkForUpdatesToolStripMenuItem1_Click);
            ToolStripItem[] itemArray6 = new ToolStripItem[] { this.aboutToolStripMenuItem, this.versionInfoToolStripMenuItem };
            this.helpToolStripMenuItem.DropDownItems.AddRange(itemArray6);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new Size(0x2b, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new Size(0x89, 0x16);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
            this.versionInfoToolStripMenuItem.Name = "versionInfoToolStripMenuItem";
            this.versionInfoToolStripMenuItem.Size = new Size(0x89, 0x16);
            this.versionInfoToolStripMenuItem.Text = "Version Info";
            this.versionInfoToolStripMenuItem.Click += new EventHandler(this.versionInfoToolStripMenuItem_Click);
            ToolStripItem[] itemArray7 = new ToolStripItem[] { this.toolStripProgressBar, this.toolStripStatusLabel };
            this.statusStrip1.Items.AddRange(itemArray7);
            this.statusStrip1.Location = new Point(0, 0x26d);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = RightToLeft.Yes;
            this.statusStrip1.Size = new Size(650, 0x16);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0x4a;
            this.statusStrip1.Text = "statusStrip1";
            this.toolStripProgressBar.Alignment = ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new Size(100, 0x10);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new Size(0, 0x11);
            this.txtFooterText.AutoSize = true;
            this.txtFooterText.BackColor = Color.Transparent;
            this.txtFooterText.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtFooterText.ForeColor = Color.DarkGray;
            this.txtFooterText.Location = new Point(0, 600);
            this.txtFooterText.Name = "txtFooterText";
            this.txtFooterText.Size = new Size(0x12e, 12);
            this.txtFooterText.TabIndex = 0x4b;
            this.txtFooterText.Text = "Phantasy Star Portable 2 Save Editor by FunkySkunk 2014";
            this.lstSaveSlotView.BackColor = SystemColors.Window;
            ColumnHeader[] headerArray8 = new ColumnHeader[] { this.slotViewHeader_name, this.slotViewHeader_level, this.slotViewHeader_class, this.slotViewHeader_type, this.slotViewHeader_complete };
            this.lstSaveSlotView.Columns.AddRange(headerArray8);
            this.lstSaveSlotView.Cursor = Cursors.Hand;
            this.lstSaveSlotView.Enabled = false;
            this.lstSaveSlotView.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lstSaveSlotView.ForeColor = SystemColors.ActiveCaptionText;
            this.lstSaveSlotView.FullRowSelect = true;
            this.lstSaveSlotView.HeaderStyle = ColumnHeaderStyle.None;
            this.lstSaveSlotView.HideSelection = false;
            this.lstSaveSlotView.LabelWrap = false;
            this.lstSaveSlotView.Location = new Point(0xb7, 0x3b);
            this.lstSaveSlotView.MultiSelect = false;
            this.lstSaveSlotView.Name = "lstSaveSlotView";
            this.lstSaveSlotView.Size = new Size(0x1c6, 140);
            this.lstSaveSlotView.SmallImageList = this.sexImageList;
            this.lstSaveSlotView.TabIndex = 0x54;
            this.lstSaveSlotView.UseCompatibleStateImageBehavior = false;
            this.lstSaveSlotView.View = View.Details;
            this.lstSaveSlotView.SelectedIndexChanged += new EventHandler(this.saveSlotView_SelectedIndexChanged);
            this.slotViewHeader_name.Width = 0x7d;
            this.slotViewHeader_level.Width = 50;
            this.slotViewHeader_class.Width = 0x41;
            this.slotViewHeader_type.Width = 70;
            this.slotViewHeader_complete.Width = 140;
            this.txtFileSize.BackColor = Color.Transparent;
            this.txtFileSize.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtFileSize.ForeColor = SystemColors.ControlText;
            this.txtFileSize.Location = new Point(0x1d, 0x92);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.Size = new Size(0x8f, 13);
            this.txtFileSize.TabIndex = 0x4f;
            this.txtFileSize.Text = "0 bytes";
            this.txtFileSize.TextAlign = ContentAlignment.TopRight;
            this.btnExportCharacter.Cursor = Cursors.Hand;
            this.btnExportCharacter.Enabled = false;
            this.btnExportCharacter.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnExportCharacter.Location = new Point(280, 200);
            this.btnExportCharacter.Name = "btnExportCharacter";
            this.btnExportCharacter.Size = new Size(0x60, 20);
            this.btnExportCharacter.TabIndex = 0x52;
            this.btnExportCharacter.Text = "export character";
            this.btnExportCharacter.UseVisualStyleBackColor = true;
            this.btnExportCharacter.Click += new EventHandler(this.btnExportCharacter_Click);
            this.txtSlotnumloaded.AutoSize = true;
            this.txtSlotnumloaded.BackColor = SystemColors.Control;
            this.txtSlotnumloaded.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtSlotnumloaded.ForeColor = Color.Black;
            this.txtSlotnumloaded.Location = new Point(530, 200);
            this.txtSlotnumloaded.Name = "txtSlotnumloaded";
            this.txtSlotnumloaded.Size = new Size(0x70, 12);
            this.txtSlotnumloaded.TabIndex = 0x51;
            this.txtSlotnumloaded.Text = "No Save Slot Loaded ";
            this.txtSlotnumloaded.TextAlign = ContentAlignment.TopRight;
            this.btnImportCharacter.Cursor = Cursors.Hand;
            this.btnImportCharacter.Enabled = false;
            this.btnImportCharacter.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnImportCharacter.Location = new Point(0xb6, 200);
            this.btnImportCharacter.Name = "btnImportCharacter";
            this.btnImportCharacter.Size = new Size(0x60, 20);
            this.btnImportCharacter.TabIndex = 0x53;
            this.btnImportCharacter.Text = "import character";
            this.btnImportCharacter.UseVisualStyleBackColor = true;
            this.btnImportCharacter.Click += new EventHandler(this.btnImportCharacter_Click);
            this.txtFileLoc.Enabled = false;
            this.txtFileLoc.Location = new Point(20, 0x1d);
            this.txtFileLoc.Name = "txtFileLoc";
            this.txtFileLoc.Size = new Size(0x248, 20);
            this.txtFileLoc.TabIndex = 0x4d;
            this.btnBrowse.Cursor = Cursors.Hand;
            this.btnBrowse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowse.Location = new Point(610, 0x1d);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new Size(0x1b, 20);
            this.btnBrowse.TabIndex = 0x4c;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new EventHandler(this.btnBrowse_Click);
            this.grpImageFloater.BackColor = SystemColors.Window;
            this.grpImageFloater.Controls.Add(this.imgFloater);
            this.grpImageFloater.Controls.Add(this.panelImageFloater);
            this.grpImageFloater.Location = new Point(0x1ca, 0x1da);
            this.grpImageFloater.Name = "grpImageFloater";
            this.grpImageFloater.Size = new Size(0xae, 0x8b);
            this.grpImageFloater.TabIndex = 0x48;
            this.grpImageFloater.TabStop = false;
            this.imgFloater.BackColor = Color.Black;
            this.imgFloater.Location = new Point(7, 13);
            this.imgFloater.Name = "imgFloater";
            this.imgFloater.Size = new Size(160, 120);
            this.imgFloater.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgFloater.TabIndex = 0;
            this.imgFloater.TabStop = false;
            this.panelImageFloater.Location = new Point(0x1ca, 480);
            this.panelImageFloater.Name = "panelImageFloater";
            this.panelImageFloater.Size = new Size(0xae, 0x85);
            this.panelImageFloater.TabIndex = 0x48;
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new Point(4, 0x1e8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(60, 0x17);
            this.btnSave.TabIndex = 0x55;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.imageListWeaponElements.ImageStream = (ImageListStreamer) manager.GetObject("imageListWeaponElements.ImageStream");
            this.imageListWeaponElements.TransparentColor = Color.Transparent;
            this.imageListWeaponElements.Images.SetKeyName(0, "01_sword.png");
            this.imageListWeaponElements.Images.SetKeyName(1, "02_knuckles.png");
            this.imageListWeaponElements.Images.SetKeyName(2, "03_spear.png");
            this.imageListWeaponElements.Images.SetKeyName(3, "04_double_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(4, "05_axe.png");
            this.imageListWeaponElements.Images.SetKeyName(5, "06_sabers.png");
            this.imageListWeaponElements.Images.SetKeyName(6, "07_daggers.png");
            this.imageListWeaponElements.Images.SetKeyName(7, "08_claws.png");
            this.imageListWeaponElements.Images.SetKeyName(8, "009_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(9, "010_dagger.png");
            this.imageListWeaponElements.Images.SetKeyName(10, "011_claw.png");
            this.imageListWeaponElements.Images.SetKeyName(11, "012_whip.png");
            this.imageListWeaponElements.Images.SetKeyName(12, "013_slicer.png");
            this.imageListWeaponElements.Images.SetKeyName(13, "014_rifle.png");
            this.imageListWeaponElements.Images.SetKeyName(14, "015_shotgun.png");
            this.imageListWeaponElements.Images.SetKeyName(15, "016_longbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x10, "017_grenade.png");
            this.imageListWeaponElements.Images.SetKeyName(0x11, "018_laser.png");
            this.imageListWeaponElements.Images.SetKeyName(0x12, "019_handguns.png");
            this.imageListWeaponElements.Images.SetKeyName(0x13, "020_handgun.png");
            this.imageListWeaponElements.Images.SetKeyName(20, "021_crossbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x15, "022_cards.png");
            this.imageListWeaponElements.Images.SetKeyName(0x16, "023_machinegun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x17, "024_rod.png");
            this.imageListWeaponElements.Images.SetKeyName(0x18, "025_wand.png");
            this.imageListWeaponElements.Images.SetKeyName(0x19, "026_tmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x1a, "027_rmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x1b, "028_shield.png");
            this.imageListWeaponElements.Images.SetKeyName(0x1c, "01_sword.png");
            this.imageListWeaponElements.Images.SetKeyName(0x1d, "02_knuckles.png");
            this.imageListWeaponElements.Images.SetKeyName(30, "03_spear.png");
            this.imageListWeaponElements.Images.SetKeyName(0x1f, "04_double_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x20, "05_axe.png");
            this.imageListWeaponElements.Images.SetKeyName(0x21, "06_sabers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x22, "07_daggers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x23, "08_claws.png");
            this.imageListWeaponElements.Images.SetKeyName(0x24, "009_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x25, "010_dagger.png");
            this.imageListWeaponElements.Images.SetKeyName(0x26, "011_claw.png");
            this.imageListWeaponElements.Images.SetKeyName(0x27, "012_whip.png");
            this.imageListWeaponElements.Images.SetKeyName(40, "013_slicer.png");
            this.imageListWeaponElements.Images.SetKeyName(0x29, "014_rifle.png");
            this.imageListWeaponElements.Images.SetKeyName(0x2a, "015_shotgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x2b, "016_longbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x2c, "017_grenade.png");
            this.imageListWeaponElements.Images.SetKeyName(0x2d, "018_laser.png");
            this.imageListWeaponElements.Images.SetKeyName(0x2e, "019_handguns.png");
            this.imageListWeaponElements.Images.SetKeyName(0x2f, "020_handgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x30, "021_crossbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x31, "022_cards.png");
            this.imageListWeaponElements.Images.SetKeyName(50, "023_machinegun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x33, "024_rod.png");
            this.imageListWeaponElements.Images.SetKeyName(0x34, "025_wand.png");
            this.imageListWeaponElements.Images.SetKeyName(0x35, "026_tmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x36, "027_rmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x37, "028_shield.png");
            this.imageListWeaponElements.Images.SetKeyName(0x38, "01_sword.png");
            this.imageListWeaponElements.Images.SetKeyName(0x39, "02_knuckles.png");
            this.imageListWeaponElements.Images.SetKeyName(0x3a, "03_spear.png");
            this.imageListWeaponElements.Images.SetKeyName(0x3b, "04_double_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(60, "05_axe.png");
            this.imageListWeaponElements.Images.SetKeyName(0x3d, "06_sabers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x3e, "07_daggers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x3f, "08_claws.png");
            this.imageListWeaponElements.Images.SetKeyName(0x40, "009_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x41, "010_dagger.png");
            this.imageListWeaponElements.Images.SetKeyName(0x42, "011_claw.png");
            this.imageListWeaponElements.Images.SetKeyName(0x43, "012_whip.png");
            this.imageListWeaponElements.Images.SetKeyName(0x44, "013_slicer.png");
            this.imageListWeaponElements.Images.SetKeyName(0x45, "014_rifle.png");
            this.imageListWeaponElements.Images.SetKeyName(70, "015_shotgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x47, "016_longbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x48, "017_grenade.png");
            this.imageListWeaponElements.Images.SetKeyName(0x49, "018_laser.png");
            this.imageListWeaponElements.Images.SetKeyName(0x4a, "019_handguns.png");
            this.imageListWeaponElements.Images.SetKeyName(0x4b, "020_handgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x4c, "021_crossbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x4d, "022_cards.png");
            this.imageListWeaponElements.Images.SetKeyName(0x4e, "023_machinegun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x4f, "024_rod.png");
            this.imageListWeaponElements.Images.SetKeyName(80, "025_wand.png");
            this.imageListWeaponElements.Images.SetKeyName(0x51, "026_tmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x52, "027_rmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x53, "028_shield.png");
            this.imageListWeaponElements.Images.SetKeyName(0x54, "01_sword.png");
            this.imageListWeaponElements.Images.SetKeyName(0x55, "02_knuckles.png");
            this.imageListWeaponElements.Images.SetKeyName(0x56, "03_spear.png");
            this.imageListWeaponElements.Images.SetKeyName(0x57, "04_double_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x58, "05_axe.png");
            this.imageListWeaponElements.Images.SetKeyName(0x59, "06_sabers.png");
            this.imageListWeaponElements.Images.SetKeyName(90, "07_daggers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x5b, "08_claws.png");
            this.imageListWeaponElements.Images.SetKeyName(0x5c, "009_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x5d, "010_dagger.png");
            this.imageListWeaponElements.Images.SetKeyName(0x5e, "011_claw.png");
            this.imageListWeaponElements.Images.SetKeyName(0x5f, "012_whip.png");
            this.imageListWeaponElements.Images.SetKeyName(0x60, "013_slicer.png");
            this.imageListWeaponElements.Images.SetKeyName(0x61, "014_rifle.png");
            this.imageListWeaponElements.Images.SetKeyName(0x62, "015_shotgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x63, "016_longbow.png");
            this.imageListWeaponElements.Images.SetKeyName(100, "017_grenade.png");
            this.imageListWeaponElements.Images.SetKeyName(0x65, "018_laser.png");
            this.imageListWeaponElements.Images.SetKeyName(0x66, "019_handguns.png");
            this.imageListWeaponElements.Images.SetKeyName(0x67, "020_handgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x68, "021_crossbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x69, "022_cards.png");
            this.imageListWeaponElements.Images.SetKeyName(0x6a, "023_machinegun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x6b, "024_rod.png");
            this.imageListWeaponElements.Images.SetKeyName(0x6c, "025_wand.png");
            this.imageListWeaponElements.Images.SetKeyName(0x6d, "026_tmag.png");
            this.imageListWeaponElements.Images.SetKeyName(110, "027_rmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x6f, "028_shield.png");
            this.imageListWeaponElements.Images.SetKeyName(0x70, "01_sword.png");
            this.imageListWeaponElements.Images.SetKeyName(0x71, "02_knuckles.png");
            this.imageListWeaponElements.Images.SetKeyName(0x72, "03_spear.png");
            this.imageListWeaponElements.Images.SetKeyName(0x73, "04_double_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x74, "05_axe.png");
            this.imageListWeaponElements.Images.SetKeyName(0x75, "06_sabers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x76, "07_daggers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x77, "08_claws.png");
            this.imageListWeaponElements.Images.SetKeyName(120, "009_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x79, "010_dagger.png");
            this.imageListWeaponElements.Images.SetKeyName(0x7a, "011_claw.png");
            this.imageListWeaponElements.Images.SetKeyName(0x7b, "012_whip.png");
            this.imageListWeaponElements.Images.SetKeyName(0x7c, "013_slicer.png");
            this.imageListWeaponElements.Images.SetKeyName(0x7d, "014_rifle.png");
            this.imageListWeaponElements.Images.SetKeyName(0x7e, "015_shotgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x7f, "016_longbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x80, "017_grenade.png");
            this.imageListWeaponElements.Images.SetKeyName(0x81, "018_laser.png");
            this.imageListWeaponElements.Images.SetKeyName(130, "019_handguns.png");
            this.imageListWeaponElements.Images.SetKeyName(0x83, "020_handgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x84, "021_crossbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x85, "022_cards.png");
            this.imageListWeaponElements.Images.SetKeyName(0x86, "023_machinegun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x87, "024_rod.png");
            this.imageListWeaponElements.Images.SetKeyName(0x88, "025_wand.png");
            this.imageListWeaponElements.Images.SetKeyName(0x89, "026_tmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x8a, "027_rmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0x8b, "028_shield.png");
            this.imageListWeaponElements.Images.SetKeyName(140, "01_sword.png");
            this.imageListWeaponElements.Images.SetKeyName(0x8d, "02_knuckles.png");
            this.imageListWeaponElements.Images.SetKeyName(0x8e, "03_spear.png");
            this.imageListWeaponElements.Images.SetKeyName(0x8f, "04_double_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x90, "05_axe.png");
            this.imageListWeaponElements.Images.SetKeyName(0x91, "06_sabers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x92, "07_daggers.png");
            this.imageListWeaponElements.Images.SetKeyName(0x93, "08_claws.png");
            this.imageListWeaponElements.Images.SetKeyName(0x94, "009_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0x95, "010_dagger.png");
            this.imageListWeaponElements.Images.SetKeyName(150, "011_claw.png");
            this.imageListWeaponElements.Images.SetKeyName(0x97, "012_whip.png");
            this.imageListWeaponElements.Images.SetKeyName(0x98, "013_slicer.png");
            this.imageListWeaponElements.Images.SetKeyName(0x99, "014_rifle.png");
            this.imageListWeaponElements.Images.SetKeyName(0x9a, "015_shotgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0x9b, "016_longbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0x9c, "017_grenade.png");
            this.imageListWeaponElements.Images.SetKeyName(0x9d, "018_laser.png");
            this.imageListWeaponElements.Images.SetKeyName(0x9e, "019_handguns.png");
            this.imageListWeaponElements.Images.SetKeyName(0x9f, "020_handgun.png");
            this.imageListWeaponElements.Images.SetKeyName(160, "021_crossbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa1, "022_cards.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa2, "023_machinegun.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa3, "024_rod.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa4, "025_wand.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa5, "026_tmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa6, "027_rmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa7, "028_shield.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa8, "01_sword.png");
            this.imageListWeaponElements.Images.SetKeyName(0xa9, "02_knuckles.png");
            this.imageListWeaponElements.Images.SetKeyName(170, "03_spear.png");
            this.imageListWeaponElements.Images.SetKeyName(0xab, "04_double_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0xac, "05_axe.png");
            this.imageListWeaponElements.Images.SetKeyName(0xad, "06_sabers.png");
            this.imageListWeaponElements.Images.SetKeyName(0xae, "07_daggers.png");
            this.imageListWeaponElements.Images.SetKeyName(0xaf, "08_claws.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb0, "009_saber.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb1, "010_dagger.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb2, "011_claw.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb3, "012_whip.png");
            this.imageListWeaponElements.Images.SetKeyName(180, "013_slicer.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb5, "014_rifle.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb6, "015_shotgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb7, "016_longbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb8, "017_grenade.png");
            this.imageListWeaponElements.Images.SetKeyName(0xb9, "018_laser.png");
            this.imageListWeaponElements.Images.SetKeyName(0xba, "019_handguns.png");
            this.imageListWeaponElements.Images.SetKeyName(0xbb, "020_handgun.png");
            this.imageListWeaponElements.Images.SetKeyName(0xbc, "021_crossbow.png");
            this.imageListWeaponElements.Images.SetKeyName(0xbd, "022_cards.png");
            this.imageListWeaponElements.Images.SetKeyName(190, "023_machinegun.png");
            this.imageListWeaponElements.Images.SetKeyName(0xbf, "024_rod.png");
            this.imageListWeaponElements.Images.SetKeyName(0xc0, "025_wand.png");
            this.imageListWeaponElements.Images.SetKeyName(0xc1, "026_tmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0xc2, "027_rmag.png");
            this.imageListWeaponElements.Images.SetKeyName(0xc3, "028_shield.png");
            this.printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            this.printPreviewDialog1.ClientSize = new Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = (Icon) manager.GetObject("printPreviewDialog1.Icon");
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.imgSave.Image = Resources.PSP2;
            this.imgSave.InitialImage = Resources.PSP2;
            this.imgSave.Location = new Point(0x18, 0x3f);
            this.imgSave.Name = "imgSave";
            this.imgSave.Size = new Size(0x90, 80);
            this.imgSave.TabIndex = 0x4e;
            this.imgSave.TabStop = false;
            this.imgSave.Visible = false;
            this.imgLogo.BackColor = Color.Transparent;
            this.imgLogo.Image = Resources.icon_10th;
            this.imgLogo.Location = new Point(3, 0x223);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new Size(0x3f, 50);
            this.imgLogo.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgLogo.TabIndex = 4;
            this.imgLogo.TabStop = false;
            this.pictureBox1.BackColor = Color.Transparent;
            this.pictureBox1.Image = Resources.NOICON;
            this.pictureBox1.Location = new Point(20, 0x3d);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(160, 90);
            this.pictureBox1.TabIndex = 80;
            this.pictureBox1.TabStop = false;
            this.imgGameLogo.BackColor = Color.Transparent;
            this.imgGameLogo.Image = Resources.PSP2_logo;
            this.imgGameLogo.InitialImage = Resources.PSP2_logo;
            this.imgGameLogo.Location = new Point(0x1b5, 0x1e8);
            this.imgGameLogo.Name = "imgGameLogo";
            this.imgGameLogo.Size = new Size(200, 0x7e);
            this.imgGameLogo.SizeMode = PictureBoxSizeMode.AutoSize;
            this.imgGameLogo.TabIndex = 13;
            this.imgGameLogo.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(650, 0x283);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.txtFileSize);
            base.Controls.Add(this.btnExportCharacter);
            base.Controls.Add(this.txtSlotnumloaded);
            base.Controls.Add(this.btnImportCharacter);
            base.Controls.Add(this.txtFileLoc);
            base.Controls.Add(this.btnBrowse);
            base.Controls.Add(this.imgSave);
            base.Controls.Add(this.statusStrip1);
            base.Controls.Add(this.btnSaveAs);
            base.Controls.Add(this.btnUndoAll);
            base.Controls.Add(this.imgLogo);
            base.Controls.Add(this.tabArea);
            base.Controls.Add(this.menuStrip);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.lstSaveSlotView);
            base.Controls.Add(this.txtFooterText);
            base.Controls.Add(this.grpImageFloater);
            base.Controls.Add(this.imgGameLogo);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MainMenuStrip = this.menuStrip;
            base.MaximizeBox = false;
            this.MaximumSize = new Size(660, 0x2a3);
            this.MinimumSize = new Size(660, 0x2a3);
            base.Name = "pspo2seForm";
            base.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "PSPo2 Save Editor";
            base.FormClosing += new FormClosingEventHandler(this.pspo2seForm_FormClosing);
            this.tabArea.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.picWeaponSlot01).EndInit();
            ((ISupportInitialize) this.picWeaponSlot06).EndInit();
            ((ISupportInitialize) this.picWeaponSlot02).EndInit();
            ((ISupportInitialize) this.picWeaponSlot05).EndInit();
            ((ISupportInitialize) this.picWeaponSlot03).EndInit();
            ((ISupportInitialize) this.picWeaponSlot04).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabTypeInfo.ResumeLayout(false);
            this.tabControlClasses.ResumeLayout(false);
            this.tabPageHunter.ResumeLayout(false);
            this.tabPageHunter.PerformLayout();
            this.grpHuTypeExtend.ResumeLayout(false);
            this.grpHuTypeExtend.PerformLayout();
            ((ISupportInitialize) this.imgHuTmagRank).EndInit();
            ((ISupportInitialize) this.imgHuMachinegunRank).EndInit();
            ((ISupportInitialize) this.imgHuHandgunsRank).EndInit();
            ((ISupportInitialize) this.imgHuShotgunRank).EndInit();
            ((ISupportInitialize) this.imgHuClawRank).EndInit();
            ((ISupportInitialize) this.imgHuDaggersRank).EndInit();
            ((ISupportInitialize) this.imgHuSpearRank).EndInit();
            ((ISupportInitialize) this.imgHuWandRank).EndInit();
            ((ISupportInitialize) this.imgHuCardsRank).EndInit();
            ((ISupportInitialize) this.imgHuLaserRank).EndInit();
            ((ISupportInitialize) this.imgHuRifleRank).EndInit();
            ((ISupportInitialize) this.imgHuDaggerRank).EndInit();
            ((ISupportInitialize) this.imgHuSabersRank).EndInit();
            ((ISupportInitialize) this.imgHuKnucklesRank).EndInit();
            ((ISupportInitialize) this.imgHuShieldRank).EndInit();
            ((ISupportInitialize) this.imgHuRmagRank).EndInit();
            ((ISupportInitialize) this.imgHuHandgunRank).EndInit();
            ((ISupportInitialize) this.imgHuLongbowRank).EndInit();
            ((ISupportInitialize) this.imgHuWhipRank).EndInit();
            ((ISupportInitialize) this.imgHuClawsRank).EndInit();
            ((ISupportInitialize) this.imgHuDblSaberRank).EndInit();
            ((ISupportInitialize) this.imgHuRodRank).EndInit();
            ((ISupportInitialize) this.imgHuCrossbowRank).EndInit();
            ((ISupportInitialize) this.imgHuGrenadeRank).EndInit();
            ((ISupportInitialize) this.imgHuSlicerRank).EndInit();
            ((ISupportInitialize) this.imgHuSaberRank).EndInit();
            ((ISupportInitialize) this.imgHuAxeRank).EndInit();
            ((ISupportInitialize) this.imgHuSwordRank).EndInit();
            ((ISupportInitialize) this.imgHuRmag).EndInit();
            ((ISupportInitialize) this.imgHuMachinegun).EndInit();
            ((ISupportInitialize) this.imgHuCrossbow).EndInit();
            ((ISupportInitialize) this.imgHuCards).EndInit();
            ((ISupportInitialize) this.imgHuHandgun).EndInit();
            ((ISupportInitialize) this.imgHuHandguns).EndInit();
            ((ISupportInitialize) this.imgHuGrenade).EndInit();
            ((ISupportInitialize) this.imgHuLaser).EndInit();
            ((ISupportInitialize) this.imgHuLongbow).EndInit();
            ((ISupportInitialize) this.imgHuShotgun).EndInit();
            ((ISupportInitialize) this.imgHuSlicer).EndInit();
            ((ISupportInitialize) this.imgHuRifle).EndInit();
            ((ISupportInitialize) this.imgHuWhip).EndInit();
            ((ISupportInitialize) this.imgHuClaw).EndInit();
            ((ISupportInitialize) this.imgHuSaber).EndInit();
            ((ISupportInitialize) this.imgHuDagger).EndInit();
            ((ISupportInitialize) this.imgHuShield).EndInit();
            ((ISupportInitialize) this.imgHuTmag).EndInit();
            ((ISupportInitialize) this.imgHuRod).EndInit();
            ((ISupportInitialize) this.imgHuWand).EndInit();
            ((ISupportInitialize) this.imgHuClaws).EndInit();
            ((ISupportInitialize) this.imgHuDaggers).EndInit();
            ((ISupportInitialize) this.imgHuAxe).EndInit();
            ((ISupportInitialize) this.imgHuSabers).EndInit();
            ((ISupportInitialize) this.imgHuDblSaber).EndInit();
            ((ISupportInitialize) this.imgHuKnuckles).EndInit();
            ((ISupportInitialize) this.imgHuSpear).EndInit();
            ((ISupportInitialize) this.imgHuSword).EndInit();
            ((ISupportInitialize) this.pictureBox231).EndInit();
            this.tabPageRanger.ResumeLayout(false);
            this.tabPageRanger.PerformLayout();
            this.grpRaTypeExtend.ResumeLayout(false);
            this.grpRaTypeExtend.PerformLayout();
            ((ISupportInitialize) this.imgRaTmagRank).EndInit();
            ((ISupportInitialize) this.imgRaMachinegunRank).EndInit();
            ((ISupportInitialize) this.imgRaHandgunsRank).EndInit();
            ((ISupportInitialize) this.imgRaShotgunRank).EndInit();
            ((ISupportInitialize) this.imgRaClawRank).EndInit();
            ((ISupportInitialize) this.imgRaDaggersRank).EndInit();
            ((ISupportInitialize) this.imgRaSpearRank).EndInit();
            ((ISupportInitialize) this.imgRaWandRank).EndInit();
            ((ISupportInitialize) this.imgRaCardsRank).EndInit();
            ((ISupportInitialize) this.imgRaLaserRank).EndInit();
            ((ISupportInitialize) this.imgRaRifleRank).EndInit();
            ((ISupportInitialize) this.imgRaDaggerRank).EndInit();
            ((ISupportInitialize) this.imgRaSabersRank).EndInit();
            ((ISupportInitialize) this.imgRaKnucklesRank).EndInit();
            ((ISupportInitialize) this.imgRaShieldRank).EndInit();
            ((ISupportInitialize) this.imgRaRmagRank).EndInit();
            ((ISupportInitialize) this.imgRaHandgunRank).EndInit();
            ((ISupportInitialize) this.imgRaLongbowRank).EndInit();
            ((ISupportInitialize) this.imgRaWhipRank).EndInit();
            ((ISupportInitialize) this.imgRaClawsRank).EndInit();
            ((ISupportInitialize) this.imgRaDblSaberRank).EndInit();
            ((ISupportInitialize) this.imgRaRodRank).EndInit();
            ((ISupportInitialize) this.imgRaCrossbowRank).EndInit();
            ((ISupportInitialize) this.imgRaGrenadeRank).EndInit();
            ((ISupportInitialize) this.imgRaSlicerRank).EndInit();
            ((ISupportInitialize) this.imgRaSaberRank).EndInit();
            ((ISupportInitialize) this.imgRaAxeRank).EndInit();
            ((ISupportInitialize) this.imgRaSwordRank).EndInit();
            ((ISupportInitialize) this.imgRaRmag).EndInit();
            ((ISupportInitialize) this.imgRaMachinegun).EndInit();
            ((ISupportInitialize) this.imgRaCrossbow).EndInit();
            ((ISupportInitialize) this.imgRaCards).EndInit();
            ((ISupportInitialize) this.imgRaHandgun).EndInit();
            ((ISupportInitialize) this.imgRaHandguns).EndInit();
            ((ISupportInitialize) this.imgRaGrenade).EndInit();
            ((ISupportInitialize) this.imgRaLaser).EndInit();
            ((ISupportInitialize) this.imgRaLongbow).EndInit();
            ((ISupportInitialize) this.imgRaShotgun).EndInit();
            ((ISupportInitialize) this.imgRaSlicer).EndInit();
            ((ISupportInitialize) this.imgRaRifle).EndInit();
            ((ISupportInitialize) this.imgRaWhip).EndInit();
            ((ISupportInitialize) this.imgRaClaw).EndInit();
            ((ISupportInitialize) this.imgRaSaber).EndInit();
            ((ISupportInitialize) this.imgRaDagger).EndInit();
            ((ISupportInitialize) this.imgRaShield).EndInit();
            ((ISupportInitialize) this.imgRaTmag).EndInit();
            ((ISupportInitialize) this.imgRaRod).EndInit();
            ((ISupportInitialize) this.imgRaWand).EndInit();
            ((ISupportInitialize) this.imgRaClaws).EndInit();
            ((ISupportInitialize) this.imgRaDaggers).EndInit();
            ((ISupportInitialize) this.imgRaAxe).EndInit();
            ((ISupportInitialize) this.imgRaSabers).EndInit();
            ((ISupportInitialize) this.imgRaDblSaber).EndInit();
            ((ISupportInitialize) this.imgRaKnuckles).EndInit();
            ((ISupportInitialize) this.imgRaSpear).EndInit();
            ((ISupportInitialize) this.imgRaSword).EndInit();
            ((ISupportInitialize) this.pictureBox174).EndInit();
            this.tabPageForce.ResumeLayout(false);
            this.tabPageForce.PerformLayout();
            this.grpFoTypeExtend.ResumeLayout(false);
            this.grpFoTypeExtend.PerformLayout();
            ((ISupportInitialize) this.imgFoTmagRank).EndInit();
            ((ISupportInitialize) this.imgFoMachinegunRank).EndInit();
            ((ISupportInitialize) this.imgFoHandgunsRank).EndInit();
            ((ISupportInitialize) this.imgFoShotgunRank).EndInit();
            ((ISupportInitialize) this.imgFoClawRank).EndInit();
            ((ISupportInitialize) this.imgFoDaggersRank).EndInit();
            ((ISupportInitialize) this.imgFoSpearRank).EndInit();
            ((ISupportInitialize) this.imgFoWandRank).EndInit();
            ((ISupportInitialize) this.imgFoCardsRank).EndInit();
            ((ISupportInitialize) this.imgFoLaserRank).EndInit();
            ((ISupportInitialize) this.imgFoRifleRank).EndInit();
            ((ISupportInitialize) this.imgFoDaggerRank).EndInit();
            ((ISupportInitialize) this.imgFoSabersRank).EndInit();
            ((ISupportInitialize) this.imgFoKnucklesRank).EndInit();
            ((ISupportInitialize) this.imgFoShieldRank).EndInit();
            ((ISupportInitialize) this.imgFoRmagRank).EndInit();
            ((ISupportInitialize) this.imgFoHandgunRank).EndInit();
            ((ISupportInitialize) this.imgFoLongbowRank).EndInit();
            ((ISupportInitialize) this.imgFoWhipRank).EndInit();
            ((ISupportInitialize) this.imgFoClawsRank).EndInit();
            ((ISupportInitialize) this.imgFoDblSaberRank).EndInit();
            ((ISupportInitialize) this.imgFoRodRank).EndInit();
            ((ISupportInitialize) this.imgFoCrossbowRank).EndInit();
            ((ISupportInitialize) this.imgFoGrenadeRank).EndInit();
            ((ISupportInitialize) this.imgFoSlicerRank).EndInit();
            ((ISupportInitialize) this.imgFoSaberRank).EndInit();
            ((ISupportInitialize) this.imgFoAxeRank).EndInit();
            ((ISupportInitialize) this.imgFoSwordRank).EndInit();
            ((ISupportInitialize) this.imgFoRmag).EndInit();
            ((ISupportInitialize) this.imgFoMachinegun).EndInit();
            ((ISupportInitialize) this.imgFoCrossbow).EndInit();
            ((ISupportInitialize) this.imgFoCards).EndInit();
            ((ISupportInitialize) this.imgFoHandgun).EndInit();
            ((ISupportInitialize) this.imgFoHandguns).EndInit();
            ((ISupportInitialize) this.imgFoGrenade).EndInit();
            ((ISupportInitialize) this.imgFoLaser).EndInit();
            ((ISupportInitialize) this.imgFoLongbow).EndInit();
            ((ISupportInitialize) this.imgFoShotgun).EndInit();
            ((ISupportInitialize) this.imgFoSlicer).EndInit();
            ((ISupportInitialize) this.imgFoRifle).EndInit();
            ((ISupportInitialize) this.imgFoWhip).EndInit();
            ((ISupportInitialize) this.imgFoClaw).EndInit();
            ((ISupportInitialize) this.imgFoSaber).EndInit();
            ((ISupportInitialize) this.imgFoDagger).EndInit();
            ((ISupportInitialize) this.imgFoShield).EndInit();
            ((ISupportInitialize) this.imgFoTmag).EndInit();
            ((ISupportInitialize) this.imgFoRod).EndInit();
            ((ISupportInitialize) this.imgFoWand).EndInit();
            ((ISupportInitialize) this.imgFoClaws).EndInit();
            ((ISupportInitialize) this.imgFoDaggers).EndInit();
            ((ISupportInitialize) this.imgFoAxe).EndInit();
            ((ISupportInitialize) this.imgFoSabers).EndInit();
            ((ISupportInitialize) this.imgFoDblSaber).EndInit();
            ((ISupportInitialize) this.imgFoKnuckles).EndInit();
            ((ISupportInitialize) this.imgFoSpear).EndInit();
            ((ISupportInitialize) this.imgFoSword).EndInit();
            ((ISupportInitialize) this.pictureBox117).EndInit();
            this.tabPageVanguard.ResumeLayout(false);
            this.tabPageVanguard.PerformLayout();
            this.grpVaTypeExtend.ResumeLayout(false);
            this.grpVaTypeExtend.PerformLayout();
            ((ISupportInitialize) this.imgVaTmagRank).EndInit();
            ((ISupportInitialize) this.imgVaMachinegunRank).EndInit();
            ((ISupportInitialize) this.imgVaHandgunsRank).EndInit();
            ((ISupportInitialize) this.imgVaShotgunRank).EndInit();
            ((ISupportInitialize) this.imgVaClawRank).EndInit();
            ((ISupportInitialize) this.imgVaDaggersRank).EndInit();
            ((ISupportInitialize) this.imgVaSpearRank).EndInit();
            ((ISupportInitialize) this.imgVaWandRank).EndInit();
            ((ISupportInitialize) this.imgVaCardsRank).EndInit();
            ((ISupportInitialize) this.imgVaLaserRank).EndInit();
            ((ISupportInitialize) this.imgVaRifleRank).EndInit();
            ((ISupportInitialize) this.imgVaDaggerRank).EndInit();
            ((ISupportInitialize) this.imgVaSabersRank).EndInit();
            ((ISupportInitialize) this.imgVaKnucklesRank).EndInit();
            ((ISupportInitialize) this.imgVaShieldRank).EndInit();
            ((ISupportInitialize) this.imgVaRmagRank).EndInit();
            ((ISupportInitialize) this.imgVaHandgunRank).EndInit();
            ((ISupportInitialize) this.imgVaLongbowRank).EndInit();
            ((ISupportInitialize) this.imgVaWhipRank).EndInit();
            ((ISupportInitialize) this.imgVaClawsRank).EndInit();
            ((ISupportInitialize) this.imgVaDblSaberRank).EndInit();
            ((ISupportInitialize) this.imgVaRodRank).EndInit();
            ((ISupportInitialize) this.imgVaCrossbowRank).EndInit();
            ((ISupportInitialize) this.imgVaGrenadeRank).EndInit();
            ((ISupportInitialize) this.imgVaSlicerRank).EndInit();
            ((ISupportInitialize) this.imgVaSaberRank).EndInit();
            ((ISupportInitialize) this.imgVaAxeRank).EndInit();
            ((ISupportInitialize) this.imgVaSwordRank).EndInit();
            ((ISupportInitialize) this.imgVaRmag).EndInit();
            ((ISupportInitialize) this.imgVaMachinegun).EndInit();
            ((ISupportInitialize) this.imgVaCrossbow).EndInit();
            ((ISupportInitialize) this.imgVaCards).EndInit();
            ((ISupportInitialize) this.imgVaHandgun).EndInit();
            ((ISupportInitialize) this.imgVaHandguns).EndInit();
            ((ISupportInitialize) this.imgVaGrenade).EndInit();
            ((ISupportInitialize) this.imgVaLaser).EndInit();
            ((ISupportInitialize) this.imgVaLongbow).EndInit();
            ((ISupportInitialize) this.imgVaShotgun).EndInit();
            ((ISupportInitialize) this.imgVaSlicer).EndInit();
            ((ISupportInitialize) this.imgVaRifle).EndInit();
            ((ISupportInitialize) this.imgVaWhip).EndInit();
            ((ISupportInitialize) this.imgVaClaw).EndInit();
            ((ISupportInitialize) this.imgVaSaber).EndInit();
            ((ISupportInitialize) this.imgVaDagger).EndInit();
            ((ISupportInitialize) this.imgVaShield).EndInit();
            ((ISupportInitialize) this.imgVaTmag).EndInit();
            ((ISupportInitialize) this.imgVaRod).EndInit();
            ((ISupportInitialize) this.imgVaWand).EndInit();
            ((ISupportInitialize) this.imgVaClaws).EndInit();
            ((ISupportInitialize) this.imgVaDaggers).EndInit();
            ((ISupportInitialize) this.imgVaAxe).EndInit();
            ((ISupportInitialize) this.imgVaSabers).EndInit();
            ((ISupportInitialize) this.imgVaDblSaber).EndInit();
            ((ISupportInitialize) this.imgVaKnuckles).EndInit();
            ((ISupportInitialize) this.imgVaSpear).EndInit();
            ((ISupportInitialize) this.imgVaSword).EndInit();
            ((ISupportInitialize) this.pictureBox5).EndInit();
            this.tabPageInventory.ResumeLayout(false);
            this.tabPageInventory.PerformLayout();
            this.inventoryViewPages.ResumeLayout(false);
            this.grpInventoryItemDetails.ResumeLayout(false);
            this.grpInventoryItemDetails.PerformLayout();
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
            ((ISupportInitialize) this.pictureBox7).EndInit();
            this.tabPageStorage.ResumeLayout(false);
            this.tabPageStorage.PerformLayout();
            this.storageViewPages.ResumeLayout(false);
            this.grpStorageItemDetails.ResumeLayout(false);
            this.grpStorageItemDetails.PerformLayout();
            ((ISupportInitialize) this.imgStorageRank).EndInit();
            ((ISupportInitialize) this.imgStorageStar15).EndInit();
            ((ISupportInitialize) this.imgStorageStar14).EndInit();
            ((ISupportInitialize) this.imgStorageStar13).EndInit();
            ((ISupportInitialize) this.imgStorageStar12).EndInit();
            ((ISupportInitialize) this.imgStorageStar11).EndInit();
            ((ISupportInitialize) this.imgStorageStar10).EndInit();
            ((ISupportInitialize) this.imgStorageStar9).EndInit();
            ((ISupportInitialize) this.imgStorageStar8).EndInit();
            ((ISupportInitialize) this.imgStorageStar7).EndInit();
            ((ISupportInitialize) this.imgStorageStar6).EndInit();
            ((ISupportInitialize) this.imgStorageStar5).EndInit();
            ((ISupportInitialize) this.imgStorageStar4).EndInit();
            ((ISupportInitialize) this.imgStorageStar3).EndInit();
            ((ISupportInitialize) this.imgStorageStar2).EndInit();
            ((ISupportInitialize) this.imgStorageStar1).EndInit();
            ((ISupportInitialize) this.imgStorageStar0).EndInit();
            ((ISupportInitialize) this.imgStorageWeaponManufacturer).EndInit();
            ((ISupportInitialize) this.imgStorageItemIcon).EndInit();
            ((ISupportInitialize) this.imgStorageElement).EndInit();
            ((ISupportInitialize) this.imgStorageInfinityItem).EndInit();
            ((ISupportInitialize) this.pictureBox6).EndInit();
            this.tabPageMissions.ResumeLayout(false);
            this.tabControlMissions.ResumeLayout(false);
            this.tabEp1Missions.ResumeLayout(false);
            this.tabEp1Missions.PerformLayout();
            this.tabEp2Missions.ResumeLayout(false);
            this.tabEp2Missions.PerformLayout();
            this.tabPageInfinityMission.ResumeLayout(false);
            this.tabPageInfinityMission.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpInfinityMissionDetails.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grpInfMisSpecial.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.grpInfMisExtra.ResumeLayout(false);
            this.tabPagePA.ResumeLayout(false);
            this.tabPA.ResumeLayout(false);
            this.tabPAMelee.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.pictureBox3).EndInit();
            ((ISupportInitialize) this.pictureBox4).EndInit();
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
            ((ISupportInitialize) this.pictureBox19).EndInit();
            ((ISupportInitialize) this.pictureBox20).EndInit();
            ((ISupportInitialize) this.pictureBox21).EndInit();
            ((ISupportInitialize) this.pictureBox22).EndInit();
            ((ISupportInitialize) this.pictureBox23).EndInit();
            ((ISupportInitialize) this.pictureBox24).EndInit();
            ((ISupportInitialize) this.pictureBox25).EndInit();
            this.tabPABullets.ResumeLayout(false);
            this.tabPATech.ResumeLayout(false);
            this.tabPageRebirth.ResumeLayout(false);
            this.tabPageRebirth.PerformLayout();
            this.grpRebirth.ResumeLayout(false);
            this.grpRebirth.PerformLayout();
            this.numRebirthSTA.EndInit();
            this.numRebirthPP.EndInit();
            this.numRebirthHP.EndInit();
            this.numRebirthMND.EndInit();
            this.numRebirthTEC.EndInit();
            this.numRebirthEVA.EndInit();
            this.numRebirthACC.EndInit();
            this.numRebirthDEF.EndInit();
            this.numRebirthATK.EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpImageFloater.ResumeLayout(false);
            this.grpImageFloater.PerformLayout();
            ((ISupportInitialize) this.imgFloater).EndInit();
            ((ISupportInitialize) this.imgSave).EndInit();
            ((ISupportInitialize) this.imgLogo).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            ((ISupportInitialize) this.imgGameLogo).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
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

        private void initSaveBuffer()
        {
            this.savedata_decimal_array_filled = 0;
            this.savedata_decimal_array_read_pos = 0;
            this.saveData = new saveDataType();
        }

        private void initSlotVars()
        {
            int index = 0;
            while (index < 8)
            {
                this.saveData.slot[index] = new saveSlotType();
                this.saveData.slot[index].used = false;
                this.saveData.slot[index].name = "";
                this.saveData.slot[index].title = "-";
                this.saveData.slot[index].playtime = "00:00:00";
                this.saveData.slot[index].race = raceTypes.None;
                this.saveData.slot[index].sex = sexType.None;
                this.saveData.slot[index].cur_type = jobType.None;
                this.saveData.slot[index].level = 0;
                this.saveData.slot[index].exp = 0;
                this.saveData.slot[index].meseta = 0L;
                this.saveData.slot[index].allow_quit_missions = "";
                this.saveData.slot[index].story_ep_1_complete = false;
                this.saveData.slot[index].story_ep_1_points = "0000";
                this.saveData.slot[index].story_ep_1_best_end = "0000";
                int num2 = 0;
                while (true)
                {
                    if (num2 >= 4)
                    {
                        this.saveData.slot[index].inventory = new inventoryClass();
                        this.saveData.slot[index].inventory.itemsUsed = 0;
                        int num3 = 0;
                        while (true)
                        {
                            if (num3 >= 60)
                            {
                                index++;
                                break;
                            }
                            this.saveData.slot[index].inventory.item[num3] = new inventoryItemClass();
                            this.saveData.slot[index].inventory.item[num3].used = false;
                            this.saveData.slot[index].inventory.item[num3].type = itemType.free_slot;
                            this.saveData.slot[index].inventory.item[num3].hex = "";
                            this.saveData.slot[index].inventory.item[num3].element = elementType.Neutral;
                            this.saveData.slot[index].inventory.item[num3].percent = 0;
                            this.saveData.slot[index].inventory.item[num3].qty = 0;
                            this.saveData.slot[index].inventory.item[num3].qty_max = 0;
                            num3++;
                        }
                        break;
                    }
                    this.saveData.slot[index].job[num2] = new jobClass();
                    this.saveData.slot[index].job[num2].level = 0;
                    this.saveData.slot[index].job[num2].exp = 0;
                    this.saveData.slot[index].job[num2].extendpoints = 0;
                    this.saveData.slot[index].job[num2].extendpointsused = 0;
                    num2++;
                }
            }
            this.saveData.infinityMissions.itemsUsed = 0;
            for (int i = 0; i < 100; i++)
            {
                this.saveData.infinityMissions.slot[i] = new infinityMissionClass();
            }
            for (int j = 0; j < 0x7d0; j++)
            {
                this.saveData.sharedInventory.item[j] = new inventoryItemClass();
                this.saveData.sharedInventory.item[j].used = false;
                this.saveData.sharedInventory.item[j].type = itemType.free_slot;
                this.saveData.sharedInventory.item[j].hex = "";
                this.saveData.sharedInventory.item[j].element = elementType.Neutral;
                this.saveData.sharedInventory.item[j].percent = 0;
                this.saveData.sharedInventory.item[j].qty = 0;
                this.saveData.sharedInventory.item[j].qty_max = 0;
            }
            this.saveData.sharedMeseta = 0L;
        }

        public string intTo2digitString(int num, int minlen)
        {
            string str = num.ToString();
            while (str.Length < minlen)
            {
                str = "0" + str;
            }
            return str;
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
                    strArray[0] = "unk_" + i;
                    strArray[1] = "unk_" + i;
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

                case 0x10:
                    strArray[0] = "邪神";
                    strArray[1] = "Dulk Fakis Final";
                    break;

                case 0x11:
                    strArray[0] = "暗黒蛇";
                    strArray[1] = "Dark Falz";
                    break;

                case 0x12:
                    strArray[0] = "暗黒神";
                    strArray[1] = "Dark Falz Final";
                    break;

                case 0x13:
                    strArray[0] = "電脳中枢";
                    strArray[1] = "Mother Brain";
                    break;

                case 20:
                    strArray[0] = "侵略者";
                    strArray[1] = "Orga Spiritus";
                    break;

                case 0x15:
                    strArray[0] = "太陽神";
                    strArray[1] = "Orga Angelus";
                    break;

                case 0x16:
                    strArray[0] = "堕天";
                    strArray[1] = "Orga Anastatis";
                    break;

                case 0x17:
                    strArray[0] = "地母神";
                    strArray[1] = "Dol Vaveer";
                    break;

                case 0x18:
                    strArray[0] = "邪龍";
                    strArray[1] = "Orga Dyran";
                    break;

                case 0x19:
                    strArray[0] = "刃獣";
                    strArray[1] = "Dilla Bravace";
                    break;

                case 0x1a:
                    strArray[0] = "殻獣";
                    strArray[1] = "Giel Zohg";
                    break;

                case 0x1b:
                    strArray[0] = "甲殻兵器";
                    strArray[1] = "Volna Gravka";
                    break;

                case 0x1c:
                    strArray[0] = "覚醒者";
                    strArray[1] = "Olga Flow";
                    break;

                case 0x1d:
                    strArray[0] = "英雄";
                    strArray[1] = "Olga Flow Final";
                    break;

                case 30:
                    strArray[0] = "破壊神";
                    strArray[1] = "Dark Falz Dios";
                    break;

                case 0x1f:
                    strArray[0] = "神獣";
                    strArray[1] = "Yaorozu";
                    break;

                case 0x20:
                    strArray[0] = "三兄弟";
                    strArray[1] = "Vol Bros";
                    break;

                case 0x21:
                    strArray[0] = "破壊者";
                    strArray[1] = "Seed-Helga";
                    break;

                case 0x22:
                    strArray[0] = "機動兵器";
                    strArray[1] = "Vivienne";
                    break;

                case 0x23:
                    strArray[0] = "野生児";
                    strArray[1] = "Kasch Tribesman";
                    break;

                case 0x24:
                    strArray[0] = "太陽王";
                    strArray[1] = "Shizuru";
                    break;

                case 0x25:
                    strArray[0] = "戦闘狂";
                    strArray[1] = "Renvolt Magashi";
                    break;

                case 0x26:
                    strArray[0] = "神兵";
                    strArray[1] = "Heavens Mother";
                    break;

                case 0x27:
                    strArray[0] = "転生者";
                    strArray[1] = "Nagisa";
                    break;

                default:
                    strArray[0] = "unk_" + i;
                    strArray[1] = "unk_" + i;
                    break;
            }
            return strArray;
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
                    strArray[0] = "unk_" + i;
                    strArray[1] = "unk_" + i;
                    break;
            }
            return strArray;
        }

        private void inventoryView_Click(object sender, EventArgs e)
        {
            this.inventoryViewChanged();
        }

        private void inventoryView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.inventoryViewChanged();
        }

        private void inventoryViewChanged()
        {
            if (this.inventoryView.SelectedItems.Count <= 0)
            {
                this.grpInventoryItemDetails.Visible = false;
                this.imageFloatImageIsOk = false;
                this.txtInventoryHex.Text = "0x00000000";
            }
            else
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
        }

        private void inventoryViewPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.changeInventoryPage(this.inventoryViewPages.SelectedIndex + 1);
        }

        private void jumpToLevel()
        {
            if (!this.legitVersion())
            {
                this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level.ToString();
                this.entryForm.newVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level.ToString();
                this.entryForm.description = "character level";
                this.entryForm.maxLen = 3;
                bool flag = false;
                while (!flag)
                {
                    DialogResult result = this.entryForm.ShowDialog(this);
                    if (result != DialogResult.OK)
                    {
                        flag = true;
                        continue;
                    }
                    int newvalue = int.Parse(this.entryForm.newVal);
                    if (newvalue > 200)
                    {
                        MessageBox.Show("Level 200+ is not allowed\r\nThat's just stupid right?");
                        continue;
                    }
                    if (newvalue < 1)
                    {
                        MessageBox.Show("Level 1 is the lowest");
                        continue;
                    }
                    if (newvalue != this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level)
                    {
                        this.writeNewLevelData(newvalue);
                    }
                    flag = true;
                }
            }
        }

        private void jumpToTypeLevel()
        {
            if (!this.legitVersion())
            {
                int index = this.lstSaveSlotView.SelectedItems[0].Index;
                int selectedIndex = this.tabControlClasses.SelectedIndex;
                this.entryForm.oldVal = this.saveData.slot[index].job[selectedIndex].level.ToString();
                this.entryForm.newVal = this.saveData.slot[index].job[selectedIndex].level.ToString();
                this.entryForm.description = "character type level";
                this.entryForm.maxLen = 2;
                bool flag = false;
                while (!flag)
                {
                    DialogResult result = this.entryForm.ShowDialog(this);
                    if (result != DialogResult.OK)
                    {
                        flag = true;
                        continue;
                    }
                    int level = int.Parse(this.entryForm.newVal);
                    if (level > (30 + this.saveData.slot[index].rebirth.additionalTypeLevels))
                    {
                        MessageBox.Show("You cannot enter a level greater than " + (30 + this.saveData.slot[index].rebirth.additionalTypeLevels) + ".\n\nYou will need to rebirth to increase your max type level.", "Max Level Reached", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        continue;
                    }
                    if (level < 1)
                    {
                        MessageBox.Show("You must enter a level greater than 0.", "Type Level Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        continue;
                    }
                    if (level != this.saveData.slot[index].job[selectedIndex].level)
                    {
                        int pos = 0;
                        expDb_ItemClass class2 = this.findExpTypeInfoInDb(level);
                        pos = (this.mainSettings.saveStructureIndex.type_level_pos + (this.mainSettings.saveStructureIndex.slot_size * index)) + (4 * selectedIndex);
                        string hex = class2.level.ToString("X2");
                        this.overwriteHexInBuffer(hex, pos);
                        pos += 2;
                        int exp = class2.exp;
                        if (exp < 0x10000)
                        {
                            this.overwriteHexInBuffer("00", pos);
                            this.saveData.slot[index].job[selectedIndex].scramble_exp = 0;
                        }
                        else
                        {
                            exp -= 0x10000;
                            this.overwriteHexInBuffer("01", pos);
                            this.saveData.slot[index].job[selectedIndex].scramble_exp = 1;
                        }
                        pos++;
                        hex = exp.ToString("X4");
                        this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 4), pos);
                        pos = ((this.mainSettings.saveStructureIndex.type_level_pos + (this.mainSettings.saveStructureIndex.slot_size * index)) + 0x10) + (selectedIndex * this.mainSettings.saveStructureIndex.type_extend_size);
                        hex = class2.extend_points.ToString("X4");
                        this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 4), pos);
                        this.saveData.slot[index].job[selectedIndex].level = level;
                        this.saveData.slot[index].job[selectedIndex].exp = class2.exp;
                        this.saveData.slot[index].job[selectedIndex].extendpoints = class2.extend_points;
                        this.saveData.slot[index].job[selectedIndex].exp_to_next = (class2.exp + class2.exp_next) - this.saveData.slot[index].job[selectedIndex].exp;
                        this.saveData.slot[index].job[selectedIndex].exp_next = class2.exp + class2.exp_next;
                        this.saveData.slot[index].job[selectedIndex].exp_percent = (class2.exp_next != 0) ? this.run.hexAndMathFunction.getPercentage(this.saveData.slot[index].job[selectedIndex].exp - class2.exp, class2.exp_next) : 100;
                        this.displayTypeInfo(index);
                    }
                    flag = true;
                }
            }
        }

        public bool legitVersion() => 
            false;

        private void listRebirthRewards(int level, int slot)
        {
            if (this.chkRebirthSpoof.Checked)
            {
                level = 200;
            }
            this.comboRebirthExtend.Items.Clear();
            this.lstRebirthRewards.Items.Clear();
            if (level < 50)
            {
                this.addRebirthReward("Rebirth Not Available.", Color.DarkGray);
                this.addRebirthReward("Next Rebirth in " + (50 - level) + " Levels.", Color.DarkGray);
                this.btnRebirth.Enabled = false;
                this.comboRebirthExtend.Enabled = false;
            }
            else
            {
                this.btnRebirth.Enabled = true;
                this.comboRebirthExtend.Enabled = true;
                int num = 0;
                this.comboRebirthExtend.Items.Add("Claim " + this.getRebirthNowPointGain(level) + " bonus points and 0 extend codes.");
                for (int i = 0; i < (this.saveData.slot[slot].rebirth.remaining_points + this.getRebirthNowPointGain(level)); i += 5)
                {
                    num++;
                    if (num == 1)
                    {
                        object[] objArray = new object[] { "Claim ", this.getRebirthNowPointGain(level) - (5 * num), " bonus points and ", num, " extend code." };
                        this.comboRebirthExtend.Items.Add(string.Concat(objArray));
                    }
                    else
                    {
                        object[] objArray2 = new object[] { "Claim ", this.getRebirthNowPointGain(level) - (5 * num), " bonus points and ", num, " extend codes." };
                        this.comboRebirthExtend.Items.Add(string.Concat(objArray2));
                    }
                    if (num == 10)
                    {
                        break;
                    }
                }
                this.comboRebirthExtend.SelectedIndex = 0;
                this.addRebirthReward("Up to " + num + " extend codes.", Color.DarkGreen);
                this.addRebirthReward("Up to " + this.getRebirthNowPointGain(level) + " bonus points.", Color.DarkGreen);
                if ((30 + this.saveData.slot[slot].rebirth.additionalTypeLevels) < 50)
                {
                    int num3 = (30 + this.saveData.slot[slot].rebirth.additionalTypeLevels) + this.getRebirthNowTypeLevelGain(level);
                    if (num3 > 50)
                    {
                        num3 = 50;
                    }
                    this.addRebirthReward("Maximum type level " + num3 + ".", Color.DarkGreen);
                }
            }
        }

        public void loadExpLevelDatabase()
        {
            this.exp_db_filled = 0;
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/explevel.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    while (true)
                    {
                        string csvLine = reader.ReadLine();
                        if (csvLine == null)
                        {
                            reader.Close();
                            fs.Close();
                            break;
                        }
                        this.addExpLevelInfoToDb(csvLine);
                    }
                }
            }
            catch (Exception exception)
            {
                this.databasesOk = false;
                MessageBox.Show(exception.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Level Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadExpTypeDatabase()
        {
            this.type_db_filled = 0;
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/exptype.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    while (true)
                    {
                        string csvLine = reader.ReadLine();
                        if (csvLine == null)
                        {
                            reader.Close();
                            fs.Close();
                            break;
                        }
                        this.addExpTypeInfoToDb(csvLine);
                    }
                }
            }
            catch (Exception exception)
            {
                this.databasesOk = false;
                MessageBox.Show(exception.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Type Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private int loadFileIntoBuffer(int startpos, string ext_options, partFileType type, bool allowMultiSelect, string fn = "")
        {
            int num6;
            List<string> list = new List<string>();
            if (this.savedata_decimal_array_filled == 0)
            {
                MessageBox.Show("nothing to load into");
                return -1;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult none = DialogResult.None;
            if (fn != "")
            {
                none = DialogResult.OK;
                list.Add(fn);
            }
            else
            {
                dialog.Title = "PSPo2 Save Editor: Open File";
                if (this.legitVersion())
                {
                    dialog.Title = "PSPo2 Save Viewer: Open File";
                }
                dialog.Filter = ext_options;
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                dialog.Multiselect = false;
                if (allowMultiSelect)
                {
                    dialog.Multiselect = true;
                }
                none = dialog.ShowDialog();
            }
            if (none != DialogResult.OK)
            {
                return -1;
            }
            if (fn == "")
            {
                for (int i = 0; i < dialog.FileNames.Length; i++)
                {
                    list.Add(dialog.FileNames[i]);
                }
            }
            if ((type != partFileType.infinity_mission) && (allowMultiSelect && (list.Count > (60 - this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed))))
            {
                MessageBox.Show("You do not have enough slots to import the selected items.", "Not Enough Slots", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            if (allowMultiSelect && ((type == partFileType.infinity_mission) && (list.Count > (100 - this.saveData.infinityMissions.itemsUsed))))
            {
                MessageBox.Show("You do not have enough slots to import the selected items.", "Not Enough Slots", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return -1;
            }
            using (List<string>.Enumerator enumerator = list.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        string current = enumerator.Current;
                        FileStream input = this.openFileRead(current);
                        if (input != null)
                        {
                            BinaryReader br = new BinaryReader(input);
                            int length = (int) br.BaseStream.Length;
                            switch (type)
                            {
                                case partFileType.character:
                                    if (this.validate_character_file_length(length))
                                    {
                                        break;
                                    }
                                    MessageBox.Show("File does not appear to be a valid character file");
                                    input.Close();
                                    return -1;

                                case partFileType.inventory:
                                    if (length != 0x871)
                                    {
                                        MessageBox.Show("File does not appear to be a valid inventory file");
                                        input.Close();
                                        num6 = -1;
                                    }
                                    else
                                    {
                                        this.savedata_decimal_array[this.mainSettings.saveStructureIndex.inventory_slots_used_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)] = br.ReadByte();
                                        int index = 0;
                                        int num2 = 0;
                                        while (true)
                                        {
                                            if (num2 >= 60)
                                            {
                                                input.Close();
                                                num6 = 1;
                                                break;
                                            }
                                            index = startpos + (num2 * 0x24);
                                            int num5 = 0;
                                            while (true)
                                            {
                                                if (num5 >= 8)
                                                {
                                                    this.loadObjectIntoBuffer(br, index + (num2 * 0x24), 20, partFileType.inventory);
                                                    num2++;
                                                    break;
                                                }
                                                br.ReadByte();
                                                this.savedata_decimal_array[index] = 0;
                                                index++;
                                                num5++;
                                            }
                                        }
                                    }
                                    return num6;

                                case partFileType.storage:
                                    if (length == (this.mainSettings.saveStructureIndex.shared_inventory_slots * 20))
                                    {
                                        break;
                                    }
                                    MessageBox.Show("File does not appear to be a valid storage file");
                                    input.Close();
                                    return -1;

                                case partFileType.item:
                                    if (length == 20)
                                    {
                                        if (allowMultiSelect)
                                        {
                                            startpos = this.getFreeInventoryItemId(this.lstSaveSlotView.SelectedItems[0].Index);
                                            if (startpos >= 0)
                                            {
                                                this.selectInventoryItemAfterLoad = startpos;
                                                this.overwriteHexInBuffer("0000000000000000", startpos + 20);
                                                this.overwriteHexInBuffer("00000000", startpos - 8);
                                                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed++;
                                                string hex = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed.ToString("X1");
                                                while (true)
                                                {
                                                    if (hex.Length >= 2)
                                                    {
                                                        this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.inventory_slots_used_pos + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index));
                                                        break;
                                                    }
                                                    hex = "0" + hex;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Error: Trying to load an item but there are no available slots");
                                                return -1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("File does not appear to be a valid item file");
                                        input.Close();
                                        return -1;
                                    }
                                    break;

                                case partFileType.infinity_mission:
                                    if (length == 0x68)
                                    {
                                        break;
                                    }
                                    MessageBox.Show("File does not appear to be a valid infinity mission file");
                                    input.Close();
                                    return -1;

                                case partFileType.infinity_mission_pack:
                                    if (length == 0x28a1)
                                    {
                                        break;
                                    }
                                    MessageBox.Show("File does not appear to be a valid infinity mission pack file");
                                    input.Close();
                                    return -1;

                                default:
                                    MessageBox.Show("file " + type + " is not supported");
                                    input.Close();
                                    return -1;
                            }
                            this.loadObjectIntoBuffer(br, startpos, length, type);
                            input.Close();
                            if ((type == partFileType.infinity_mission) && allowMultiSelect)
                            {
                                startpos += 0x68;
                            }
                            continue;
                        }
                        else
                        {
                            num6 = -1;
                        }
                    }
                    else
                    {
                        return list.Count;
                    }
                    break;
                }
            }
            return num6;
        }

        private void loadImageFloaterImages()
        {
            string path = "data/weapon_images/";
            this.imageFloater.filled = 0;
            DirectoryInfo info = new DirectoryInfo(path);
            string[] strArray = this.IMAGE_FLOAT_FILE_EXT;
            int index = 0;
            while (index < strArray.Length)
            {
                FileInfo[] files = info.GetFiles("*." + strArray[index]);
                int num2 = 0;
                while (true)
                {
                    if (num2 >= files.Length)
                    {
                        index++;
                        break;
                    }
                    this.imageFloater.imagelist[this.imageFloater.filled] = files[num2];
                    this.imageFloater.filled++;
                    num2++;
                }
            }
        }

        public void loadItemDatabase()
        {
            this.item_db_filled = 0;
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/items.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    while (true)
                    {
                        string csvLine = reader.ReadLine();
                        if (csvLine == null)
                        {
                            reader.Close();
                            fs.Close();
                            break;
                        }
                        this.addItemToDb(csvLine);
                    }
                }
            }
            catch (Exception exception)
            {
                this.databasesOk = false;
                MessageBox.Show(exception.Message + "\r\n\r\nPlease run a database update from the menu", "Item Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool loadObjectIntoBuffer(BinaryReader br, int startpos, int len, partFileType type)
        {
            int index = startpos;
            for (int i = 0; i < len; i++)
            {
                this.savedata_decimal_array[index] = br.ReadByte();
                index++;
            }
            if (type == partFileType.inventory)
            {
                for (int j = 0; j < 8; j++)
                {
                    br.ReadByte();
                    this.savedata_decimal_array[index] = 0;
                    index++;
                }
            }
            return true;
        }

        private bool loadSaveFile(bool reload)
        {
            this.disableMainForm();
            this.lstSaveSlotView.Items.Clear();
            if (this.parseSaveFile(this.txtFileLoc.Text, reload))
            {
                this.tabArea.Enabled = true;
                this.lstSaveSlotView.Enabled = true;
                this.showGameImage();
                if (this.lstSaveSlotView.Items.Count > 0)
                {
                    this.lstSaveSlotView.Items[0].Selected = true;
                }
                this.enableMainForm();
                return true;
            }
            this.tabArea.SelectedTab = this.tabPageInfo;
            this.tabArea.SelectedIndex = 0;
            this.inventoryViewPages.SelectedIndex = 0;
            this.storageViewPages.SelectedIndex = 0;
            this.tabArea.Enabled = false;
            this.lstSaveSlotView.Enabled = false;
            this.showGameImage();
            MessageBox.Show("Invalid file detected [" + this.txtFileSize.Text + "]", "File Error");
            this.enableMainForm();
            return false;
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
                infinityMissionClass class2 = this.saveData.infinityMissions.slot[int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString())];
                this.txtInfNameEn.Text = this.intToInfinityBoss(class2.boss - 1)[1] + " @ " + this.intToInfinityArea(class2.area - 1)[1];
                this.txtInfNameJp.Text = this.intToInfinityArea(class2.area - 1)[0] + "の" + this.intToInfinityBoss(class2.boss - 1)[0];
                string[] strArray = new string[] { "Area  ", this.intToInfinityArea(class2.area - 1)[1], " (", this.intToInfinityArea(class2.area - 1)[0], ")" };
                this.txtInfMisSpecial.Text = string.Concat(strArray);
                object[] objArray = new object[] { "Boss  ", this.intToInfinityBoss(class2.boss - 1)[1], " (", this.intToInfinityBoss(class2.boss - 1)[0], ") [", class2.length, "]" };
                this.txtInfMisBoss.Text = string.Concat(objArray);
                object[] objArray2 = new object[] { "Main Enemy  ", this.intToInfinityEnemy(class2.enemy_1)[1], " (", this.intToInfinityEnemy(class2.enemy_1)[0], ") [", class2.unk_enemy_1_mod, "]" };
                this.txtInfMisEnemy1.Text = string.Concat(objArray2);
                string[] strArray2 = new string[] { "Sub Enemy  ", this.intToInfinityEnemy(class2.enemy_2)[1], " (", this.intToInfinityEnemy(class2.enemy_2)[0], ")" };
                this.txtInfMisEnemy2.Text = string.Concat(strArray2);
                object[] objArray3 = new object[] { "Enemy Level  +", class2.enemy_level, " [", class2.unk_enemy_level_mod, "]" };
                this.txtInfEnemyLevel.Text = string.Concat(objArray3);
                this.txtInfMisSpecial.Text = "Special Effects  " + class2.hex.Substring(12, 20);
                this.txtInfMisCreatedBy.Text = "Created By  " + class2.createdBy;
                this.txtInfMisSynthPoint.Text = "Synthesis Points  " + class2.mergePoints;
                this.grpInfinityMissionDetails.Visible = true;
                this.grpInfMisExtra.Visible = true;
                this.grpInfMisSpecial.Visible = true;
                this.btnExportInfinityMission.Enabled = true;
                this.btnDeleteInfinityMission.Enabled = true;
                this.btnModifyInfinityMission.Enabled = true;
            }
        }

        private void lstPA_SelectedIndexChanged(TabPage tab, int paPositionID)
        {
            this.getPAPageFields(tab).txt_hex.Text = "0x" + this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].pa.items[paPositionID].hex_reversed;
        }

        private void lstPABullets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstPABullets.SelectedItems.Count > 0)
            {
                this.lstPA_SelectedIndexChanged(this.tabPABullets, int.Parse(this.lstPABullets.SelectedItems[0].Tag.ToString()));
            }
        }

        private void lstPAMelee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstPAMelee.SelectedItems.Count > 0)
            {
                this.lstPA_SelectedIndexChanged(this.tabPAMelee, int.Parse(this.lstPAMelee.SelectedItems[0].Tag.ToString()));
            }
        }

        private void lstPATechs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstPATechs.SelectedItems.Count > 0)
            {
                this.lstPA_SelectedIndexChanged(this.tabPATech, int.Parse(this.lstPATechs.SelectedItems[0].Tag.ToString()));
            }
        }

        private void lstRebirthRewards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstRebirthRewards.Items.Count > 0)
            {
                this.lstRebirthRewards.SelectedItems.Clear();
            }
        }

        private unsafe void makeImageFloaterHidden()
        {
            Application.DoEvents();
            while (this.imageFloater.pnlloc.Y > this.imageFloat_Y_hidden)
            {
                Point* pointPtr1 = &this.imageFloater.pnlloc;
                pointPtr1.Y -= 3;
                if (this.imageFloater.pnlloc.Y < this.imageFloat_Y_hidden)
                {
                    this.imageFloater.pnlloc.Y = this.imageFloat_Y_hidden;
                }
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

        private unsafe void makeImageFloaterVisible()
        {
            Application.DoEvents();
            while (this.imageFloater.pnlloc.Y < this.imageFloat_Y_visible)
            {
                Point* pointPtr1 = &this.imageFloater.pnlloc;
                pointPtr1.Y += 3;
                if (this.imageFloater.pnlloc.Y > this.imageFloat_Y_visible)
                {
                    this.imageFloater.pnlloc.Y = this.imageFloat_Y_visible;
                }
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

        private void missionStatus_TextChanged(object sender, EventArgs e)
        {
            if (((Label) sender).Text == "Yes")
            {
                ((Label) sender).ForeColor = Color.DarkGreen;
            }
            else
            {
                ((Label) sender).ForeColor = Color.DarkRed;
            }
        }

        private void moveImageFloater()
        {
            this.allowImageFloatMove = false;
            this.tabArea.Enabled = false;
            if (this.imageFloatShowing)
            {
                this.makeImageFloaterHidden();
            }
            else
            {
                this.makeImageFloaterVisible();
            }
        }

        private unsafe void numRebirth_ValueChanged(object sender, EventArgs e)
        {
            if ((this.lstSaveSlotView.SelectedItems[0].Index >= 0) && ((((NumericUpDown) sender).Value <= 10M) && (((NumericUpDown) sender).Value >= 0M)))
            {
                string nameFlag = ((NumericUpDown) sender).Name.Replace("numRebirth", "");
                int num = 0;
                int* numPtr = this.getRebirthStatPointer(nameFlag);
                int num1 = numPtr[0];
                num = this.getRebirthValuePtsUsed(this.lstSaveSlotView.SelectedItems[0].Index, numPtr[0], nameFlag);
                numPtr[0] = (int) ((NumericUpDown) sender).Value;
                num = this.getRebirthValuePtsUsed(this.lstSaveSlotView.SelectedItems[0].Index, numPtr[0], nameFlag) - num;
                if (num < 0)
                {
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points += -num;
                    this.updateRebirthBufferVals(this.lstSaveSlotView.SelectedItems[0].Index);
                }
                else
                {
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points -= num;
                    if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points >= 0)
                    {
                        this.updateRebirthBufferVals(this.lstSaveSlotView.SelectedItems[0].Index);
                    }
                    else
                    {
                        MessageBox.Show("You need " + -this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points + " more points to add to this stat.\n\nYou will need to rebirth to gain more BP.", "Not Enough BP", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        ((NumericUpDown) sender).Value = numPtr[0] - 1;
                    }
                }
                this.displayRebirthInfo(this.lstSaveSlotView.SelectedItems[0].Index);
            }
        }

        public FileStream openFileRead(string fileLoc)
        {
            FileStream stream = null;
            if (fileLoc.Length <= 0)
            {
                throw new ArgumentException();
            }
            try
            {
                stream = new FileStream(fileLoc, FileMode.Open, FileAccess.Read);
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Fatal Error!");
            }
            return stream;
        }

        private void openImageFloater()
        {
            if ((this.imageFloaterClosed() && (this.imageFloatImageIsOk && (ReferenceEquals(this.tabArea.SelectedTab, this.tabPageInventory) || ReferenceEquals(this.tabArea.SelectedTab, this.tabPageStorage)))) && ((this.inventoryViewPages.SelectedIndex == 0) || (this.storageViewPages.SelectedIndex == 0)))
            {
                this.moveImageFloater();
            }
        }

        public string openSaveDialogue(string ext_options, string fileName = "")
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Title = "PSPo2 Save Editor: Save File"
            };
            if (fileName != "")
            {
                dialog.FileName = fileName;
            }
            if (this.legitVersion())
            {
                dialog.Title = "PSPo2 Save Viewer: Save File";
            }
            dialog.Filter = ext_options;
            dialog.RestoreDirectory = true;
            return ((dialog.ShowDialog() != DialogResult.OK) ? null : this.fixFileNameNoExt(dialog.FileName, ext_options));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.action_browse();
        }

        public bool overwriteHexInBuffer(string hex, int pos)
        {
            if (((hex.Length / 2) + pos) > this.savedata_decimal_array_filled)
            {
                MessageBox.Show(string.Concat(new object[] { "trying to overwrite hex ", hex, " over the end of the buffer ", this.savedata_decimal_array_filled }));
            }
            int index = pos;
            foreach (string str2 in this.run.hexAndMathFunction.addCommasToHex(hex).Split(new char[] { ',' }))
            {
                if (index > (pos + hex.Length))
                {
                    MessageBox.Show("something went wrong with overwriting hex in the buffer");
                    return false;
                }
                this.savedata_decimal_array[index] = byte.Parse(str2, NumberStyles.HexNumber);
                index++;
            }
            return true;
        }

        private unsafe bool parseCharacterInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            this.saveData.slot[slot].rebirth = new rebirthType();
            int num = this.mainSettings.saveStructureIndex.slots_position + (this.mainSettings.saveStructureIndex.slot_size * slot);
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "Character info " + slot, true);
            this.saveData.slot[slot].used = true;
            this.saveData.slot[slot].name = "";
            for (int i = 0; i < 0x20; i++)
            {
                string s = this.run.hexAndMathFunction.reversehex(this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true), 4);
                uint num3 = uint.Parse(s, NumberStyles.HexNumber);
                saveSlotType type1 = this.saveData.slot[slot];
                type1.name = type1.name + Encoding.UTF32.GetString(BitConverter.GetBytes(num3));
            }
            if (this.saveData.slot[slot].name.Substring(0, 10) == "イーサン・ウェーバー")
            {
                this.saveData.slot[slot].name = "---- Free Slot ----";
                this.saveData.slot[slot].used = false;
                return true;
            }
            this.saveData.slot[slot].title = "";
            for (int j = 0; j < 0x20; j++)
            {
                string s = this.run.hexAndMathFunction.reversehex(this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true), 4);
                uint num5 = uint.Parse(s, NumberStyles.HexNumber);
                saveSlotType type2 = this.saveData.slot[slot];
                type2.title = type2.title + Encoding.UTF32.GetString(BitConverter.GetBytes(num5));
            }
            this.saveData.slot[slot].race = (raceTypes) this.brGetInt(1, pos, br, reload, true, "");
            this.saveData.slot[slot].sex = (sexType) this.brGetInt(1, pos, br, reload, true, "");
            this.saveData.slot[slot].cur_type = (jobType) this.brGetInt(1, pos, br, reload, true, "");
            this.brSkipBytes(0x65, pos, br, reload, true);
            this.saveData.slot[slot].level = this.brGetInt(2, pos, br, reload, true, "");
            this.brSkipBytes(6, pos, br, reload, true);
            this.saveData.slot[slot].exp = this.brGetInt32(pos, br, reload, true, "");
            this.saveData.slot[slot].meseta = this.brGetInt32(pos, br, reload, true, "");
            int num6 = this.brGetInt(4, pos, br, reload, true, "");
            int num7 = num6 / 0xe10;
            num6 -= num7 * 0xe10;
            int num8 = num6 / 60;
            num6 -= num8 * 60;
            string[] strArray = new string[] { this.intTo2digitString(num7, 2), ":", this.intTo2digitString(num8, 2), ":", this.intTo2digitString(num6, 2) };
            this.saveData.slot[slot].playtime = string.Concat(strArray);
            this.brSkipBytes(0x1f, pos, br, reload, true);
            this.saveData.slot[slot].rebirth.additionalTypeLevels = this.brGetInt(1, pos, br, reload, true, "");
            return true;
        }

        private unsafe bool parseCharacterInventoryCountInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            int num = this.mainSettings.saveStructureIndex.inventory_slots_used_pos + (this.mainSettings.saveStructureIndex.slot_size * slot);
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "parseCharacterInventoryCountInfo slot " + slot, true);
            this.saveData.slot[slot].inventory.itemsUsed = this.brGetInt(1, pos, br, reload, true, "");
            return true;
        }

        private unsafe bool parseCharacterInventorySlotsInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            int num = this.mainSettings.saveStructureIndex.inventory_slots_pos + (this.mainSettings.saveStructureIndex.slot_size * slot);
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "parseCharacterInventoryCountInfo slot " + slot, true);
            for (int i = 0; i < 60; i++)
            {
                string str = this.brGetData(8, br, pos, saveInfoDataType.hex, reload, true);
                string s = str.Substring(8, 2);
                string str3 = str.Substring(2, 2);
                string str4 = str.Substring(0, 2);
                this.saveData.slot[slot].inventory.item[i] = this.brGetItem(pos, br, reload);
                this.saveData.slot[slot].inventory.item[i].data_id = int.Parse(s, NumberStyles.HexNumber);
                this.saveData.slot[slot].inventory.item[i].equipped_now = int.Parse(str4, NumberStyles.HexNumber);
                this.saveData.slot[slot].inventory.item[i].equipped_slot = (int.Parse(str3) == 0) ? 0 : this.run.hexAndMathFunction.hex2binary(str3).Length;
                if (i < this.saveData.slot[slot].inventory.itemsUsed)
                {
                    this.brSkipBytes(8, pos, br, reload, true);
                }
                else
                {
                    this.saveData.slot[slot].inventory.item[i].hex = "FFFFFFFF";
                    this.saveData.slot[slot].inventory.item[i].hex_reversed = "FFFFFFFF";
                    this.saveData.slot[slot].inventory.item[i].type = itemType.free_slot;
                    this.saveData.slot[slot].inventory.item[i].used = false;
                    this.brSkipBytes(8, pos, br, reload, true);
                }
            }
            return true;
        }

        private unsafe bool parseCharacterItemPaletteInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            this.brSkipBytes(0x18, pos, br, reload, true);
            return true;
        }

        private unsafe void parseCharacterPADiskLearnt(int slot, BinaryReader br, int* pos, bool reload, int* filled)
        {
            string s = this.brGetData(4, br, pos, saveInfoDataType.hex, reload, true);
            if (s != "00000000")
            {
                this.saveData.slot[slot].pa.items[filled[0]] = new inventoryItemClass();
                this.saveData.slot[slot].pa.items[filled[0]].hex = s.Substring(0, 6) + "00";
                this.saveData.slot[slot].pa.items[filled[0]].hex_reversed = this.run.hexAndMathFunction.reversehex(this.saveData.slot[slot].pa.items[filled[0]].hex, 8);
                s = s.Substring(6, 2);
                this.saveData.slot[slot].pa.items[filled[0]].level = "LV" + (int.Parse(s, NumberStyles.HexNumber) + 1);
                this.saveData.slot[slot].pa.items[filled[0]].id = filled[0];
                filled[0]++;
            }
        }

        private unsafe bool parseCharacterPADisksLearnt(int slot, BinaryReader br, int* pos, bool reload)
        {
            int filled = 0;
            for (int i = 0; i < 0x100; i++)
            {
                this.saveData.slot[slot].pa.items[i] = new inventoryItemClass();
                this.saveData.slot[slot].pa.items[i].hex = "";
                this.saveData.slot[slot].pa.items[i].hex_reversed = "";
            }
            for (int j = 0; j < 0x88; j++)
            {
                this.parseCharacterPADiskLearnt(slot, br, pos, reload, &filled);
            }
            if (this.saveData.type == SaveType.PSP2I)
            {
                for (int k = 0; k < 6; k++)
                {
                    this.parseCharacterPADiskLearnt(slot, br, pos, reload, &filled);
                }
            }
            return true;
        }

        private unsafe bool parseCharacterPADisksLearntCount(int slot, BinaryReader br, int* pos, bool reload)
        {
            this.saveData.slot[slot].pa.count = this.brGetInt(1, pos, br, reload, true, "");
            this.brSkipBytes(10, pos, br, reload, true);
            return true;
        }

        private unsafe bool parseCharacterRebirthInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            string hex = "";
            if (this.saveData.type == SaveType.PSP2)
            {
                this.brSkipBytes(2, pos, br, reload, true);
                return true;
            }
            for (int i = 0; i < 12; i++)
            {
                hex = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
                hex = this.run.hexAndMathFunction.reversehex(hex, 4);
                int num2 = i;
                switch (num2)
                {
                    case 0:
                        this.saveData.slot[slot].rebirth.count = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 1:
                        this.saveData.slot[slot].rebirth.remaining_points = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 2:
                        this.saveData.slot[slot].rebirth.atk = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 3:
                        this.saveData.slot[slot].rebirth.def = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 4:
                        this.saveData.slot[slot].rebirth.acc = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 5:
                        this.saveData.slot[slot].rebirth.eva = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 6:
                        this.saveData.slot[slot].rebirth.sta = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 8:
                        this.saveData.slot[slot].rebirth.tec = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 9:
                        this.saveData.slot[slot].rebirth.mnd = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 10:
                        this.saveData.slot[slot].rebirth.hp = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    case 11:
                        this.saveData.slot[slot].rebirth.pp = int.Parse(hex, NumberStyles.HexNumber);
                        break;

                    default:
                        break;
                }
            }
            return true;
        }

        private unsafe bool parseCharacterSharedStorageSlotsInfo(BinaryReader br, int* pos, bool reload)
        {
            int num = this.mainSettings.saveStructureIndex.shared_inventory_pos;
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "parseCharacterSharedStorageSlotsInfo", true);
            this.saveData.sharedInventory.itemsUsed = 0;
            for (int i = 0; i < this.mainSettings.saveStructureIndex.shared_inventory_slots; i++)
            {
                this.saveData.sharedInventory.item[i] = this.brGetItem(pos, br, reload);
            }
            this.saveData.sharedMeseta = this.brGetInt32(pos, br, reload, true, "");
            return true;
        }

        private unsafe bool parseCharacterStoryInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            string str = "";
            int num = (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * slot)) + 0xc6e;
            if (this.saveData.type == SaveType.PSP2I)
            {
                num = (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * slot)) + 0xcaa;
            }
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "parseCharacterStoryInfo slot " + slot, true);
            str = this.brGetData(1, br, pos, saveInfoDataType.hex, reload, true);
            this.saveData.slot[slot].mission_unlock_magashi = false;
            if (str == "1F")
            {
                this.saveData.slot[slot].mission_unlock_magashi = true;
            }
            num = this.mainSettings.saveStructureIndex.story_info_pos + (this.mainSettings.saveStructureIndex.slot_size * slot);
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "parseCharacterStoryInfo slot " + slot, true);
            if (this.saveData.type == SaveType.PSP2I)
            {
                this.saveData.slot[slot].story_ep_2_points = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
            }
            this.brSkipBytes(0x9e, pos, br, reload, true);
            this.saveData.slot[slot].mission_unlock_ep1 = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true) == "204E";
            this.brSkipBytes(0x22, pos, br, reload, true);
            this.saveData.slot[slot].story_ep_1_points = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
            this.brSkipBytes(14, pos, br, reload, true);
            this.saveData.slot[slot].mission_unlock_unknown = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true) == "204E";
            this.brSkipBytes(50, pos, br, reload, true);
            this.saveData.slot[slot].story_ep_1_act = this.run.hexAndMathFunction.hexToInt(this.brGetData(1, br, pos, saveInfoDataType.hex, reload, true));
            this.brSkipBytes(7, pos, br, reload, true);
            if (this.saveData.type != SaveType.PSP2I)
            {
                this.brSkipBytes(0x37d, pos, br, reload, true);
            }
            else
            {
                this.saveData.slot[slot].mission_unlock_ep2 = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true) == "204E";
                this.brSkipBytes(0x37b, pos, br, reload, true);
            }
            this.saveData.slot[slot].allow_quit_missions = this.brGetData(1, br, pos, saveInfoDataType.hex, reload, true);
            this.brSkipBytes(4, pos, br, reload, true);
            this.brSkipBytes(0x20, pos, br, reload, true);
            this.brSkipBytes(10, pos, br, reload, true);
            this.brSkipBytes(0x20, pos, br, reload, true);
            if (this.saveData.type == SaveType.PSP2I)
            {
                this.brSkipBytes(0x34, pos, br, reload, true);
            }
            else
            {
                this.brSkipBytes(940, pos, br, reload, true);
            }
            str = this.brGetData(3, br, pos, saveInfoDataType.hex, reload, true);
            this.saveData.slot[slot].skip_ep_1_start = false;
            if (str == "90AB1E")
            {
                this.saveData.slot[slot].skip_ep_1_start = true;
            }
            if (this.saveData.type != SaveType.PSP2I)
            {
                this.brSkipBytes(0x4532, pos, br, reload, true);
            }
            else
            {
                this.brSkipBytes(0x21, pos, br, reload, true);
                str = this.brGetData(3, br, pos, saveInfoDataType.hex, reload, true);
                this.saveData.slot[slot].skip_ep_2_start = false;
                if (str == "78AF1E")
                {
                    this.saveData.slot[slot].skip_ep_2_start = true;
                }
                this.brSkipBytes(0x452e, pos, br, reload, true);
            }
            str = this.brGetData(1, br, pos, saveInfoDataType.hex, reload, true);
            int num2 = 0;
            try
            {
                num2 = int.Parse(str.Substring(1, 1));
            }
            catch
            {
            }
            this.saveData.slot[slot].story_ep_1_complete = false;
            this.saveData.slot[slot].story_ep_2_complete = false;
            if ((num2 == 1) || (num2 == 3))
            {
                this.saveData.slot[slot].story_ep_1_complete = true;
            }
            if ((num2 == 2) || (num2 == 3))
            {
                this.saveData.slot[slot].story_ep_2_complete = true;
            }
            return true;
        }

        private unsafe bool parseCharacterTypeExtraInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            string hex = "";
            int num = (this.mainSettings.saveStructureIndex.type_level_pos + (this.mainSettings.saveStructureIndex.slot_size * slot)) + 0x10;
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "parseCharacterTypeExtraInfo slot " + slot, true);
            for (int i = 0; i < 4; i++)
            {
                num = ((this.mainSettings.saveStructureIndex.type_level_pos + (this.mainSettings.saveStructureIndex.slot_size * slot)) + 0x10) + (i * this.mainSettings.saveStructureIndex.type_extend_size);
                pos[0] = this.adjustPosition(pos[0], br, num, reload, string.Concat(new object[] { "parseCharacterTypeExtraInfo slot ", slot, " job ", i }), true);
                this.saveData.slot[slot].job[i].extendpoints = this.brGetInt(2, pos, br, reload, true, "");
                this.saveData.slot[slot].job[i].extendpointsused = this.brGetInt(2, pos, br, reload, true, "");
                this.saveData.slot[slot].job[i].attachedAbilities = this.brGetData(10, br, pos, saveInfoDataType.hex, reload, true);
                if (this.saveData.type == SaveType.PSP2I)
                {
                    jobClass class1 = this.saveData.slot[slot].job[i];
                    class1.attachedAbilities = class1.attachedAbilities + this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
                }
            }
            hex = this.brGetData(0x3a, br, pos, saveInfoDataType.hex, reload, true);
            hex = this.run.hexAndMathFunction.halfByteSwap(hex);
            int index = 0;
            int num4 = 0;
            for (int j = 0; (j < hex.Length) && (index < 4); j++)
            {
                this.saveData.slot[slot].job[index].weapons_extended[num4] = (extendRankType) int.Parse(hex.Substring(j, 1));
                if ((num4 + 1) > 0x1c)
                {
                    num4 = 0;
                    index++;
                }
            }
            return true;
        }

        private unsafe bool parseCharacterTypeLevelInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            int num = this.mainSettings.saveStructureIndex.type_level_pos + (this.mainSettings.saveStructureIndex.slot_size * slot);
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "parseCharacterTypeLevelInfo slot " + slot, true);
            this.parseTypeInfo(slot, 0, pos, br, reload);
            this.parseTypeInfo(slot, 1, pos, br, reload);
            this.parseTypeInfo(slot, 2, pos, br, reload);
            this.parseTypeInfo(slot, 3, pos, br, reload);
            return true;
        }

        private unsafe bool parseHeaderInfo(BinaryReader br, int* pos, bool reload)
        {
            if (pos[0] > 0)
            {
                MessageBox.Show("Already scanned past the header", "scan error");
                return false;
            }
            this.brSkipBytes(this.mainSettings.saveStructureIndex.header_size, pos, br, reload, true);
            return true;
        }

        private unsafe bool parseInfinityMissionSlotsInfo(BinaryReader br, int* pos, bool reload)
        {
            if (this.saveData.type != SaveType.PSP2)
            {
                int num = this.mainSettings.saveStructureIndex.infinity_mission_pos;
                pos[0] = this.adjustPosition(pos[0], br, num, reload, "parseInfinityMissionSlotsInfo", true);
                this.saveData.infinityMissions.itemsUsed = 0;
                int index = 0;
                while (index < 100)
                {
                    this.saveData.infinityMissions.slot[index] = new infinityMissionClass();
                    string str = this.brGetData(0x68, br, pos, saveInfoDataType.hex, reload, true);
                    string s = "";
                    this.saveData.infinityMissions.slot[index].hex = str;
                    this.saveData.infinityMissions.slot[index].id = index;
                    this.saveData.infinityMissions.slot[index].area = int.Parse(str.Substring(1, 1), NumberStyles.HexNumber);
                    int num3 = int.Parse(str.Substring(3, 1) + str.Substring(0, 1), NumberStyles.HexNumber);
                    this.saveData.infinityMissions.slot[index].length = 0;
                    while (true)
                    {
                        if (num3 < 0x40)
                        {
                            this.saveData.infinityMissions.slot[index].boss = num3;
                            this.saveData.infinityMissions.slot[index].enemy_2 = int.Parse(str.Substring(7, 1), NumberStyles.HexNumber);
                            this.saveData.infinityMissions.slot[index].enemy_table_1 = int.Parse(str.Substring(2, 1), NumberStyles.HexNumber);
                            this.saveData.infinityMissions.slot[index].unk_enemy_table_1_mod = false;
                            if (this.saveData.infinityMissions.slot[index].enemy_table_1 >= 8)
                            {
                                infinityMissionClass class2 = this.saveData.infinityMissions.slot[index];
                                class2.enemy_table_1 -= 8;
                                this.saveData.infinityMissions.slot[index].unk_enemy_table_1_mod = true;
                            }
                            this.saveData.infinityMissions.slot[index].unk_table_2_mod = int.Parse(str.Substring(5, 1), NumberStyles.HexNumber);
                            this.saveData.infinityMissions.slot[index].unk_table_2_unk_mod = 0;
                            while (true)
                            {
                                if (this.saveData.infinityMissions.slot[index].unk_table_2_mod < 4)
                                {
                                    this.saveData.infinityMissions.slot[index].area_1_map = int.Parse(str.Substring(6, 1), NumberStyles.HexNumber);
                                    this.saveData.infinityMissions.slot[index].area_2_map = int.Parse(str.Substring(9, 1), NumberStyles.HexNumber);
                                    this.saveData.infinityMissions.slot[index].area_3_map = int.Parse(str.Substring(8, 1), NumberStyles.HexNumber);
                                    this.saveData.infinityMissions.slot[index].enemy_level = int.Parse(str.Substring(10, 2), NumberStyles.HexNumber);
                                    this.saveData.infinityMissions.slot[index].unk_enemy_level_mod = 0;
                                    while (true)
                                    {
                                        if (this.saveData.infinityMissions.slot[index].enemy_level < 0x40)
                                        {
                                            this.saveData.infinityMissions.slot[index].enemy_1 = (int) Math.Floor((double) (((double) int.Parse(str.Substring(4, 1), NumberStyles.HexNumber)) / 2.0));
                                            this.saveData.infinityMissions.slot[index].unk_enemy_1_mod = ((int) Math.Ceiling((double) (((double) int.Parse(str.Substring(4, 1), NumberStyles.HexNumber)) / 2.0))) - this.saveData.infinityMissions.slot[index].enemy_1;
                                            this.saveData.infinityMissions.slot[index].createdBy = "";
                                            int num4 = 0;
                                            while (true)
                                            {
                                                if (num4 >= 0x20)
                                                {
                                                    this.saveData.infinityMissions.slot[index].mergePoints = int.Parse(str.Substring(0xb8, 2), NumberStyles.HexNumber);
                                                    if (int.Parse(str.Substring(0xba, 2), NumberStyles.HexNumber) >= 0x80)
                                                    {
                                                        infinityMissionClass class8 = this.saveData.infinityMissions.slot[index];
                                                        class8.mergePoints += (int.Parse(str.Substring(0xba, 2), NumberStyles.HexNumber) - 0x80) * 0x100;
                                                    }
                                                    else if (int.Parse(str.Substring(0xba, 2), NumberStyles.HexNumber) < 0x80)
                                                    {
                                                        infinityMissionClass class9 = this.saveData.infinityMissions.slot[index];
                                                        class9.mergePoints += int.Parse(str.Substring(0xbb, 1), NumberStyles.HexNumber) * 0x100;
                                                    }
                                                    this.saveData.infinityMissions.slot[index].clearCount_c = int.Parse(this.run.hexAndMathFunction.reversehex(str.Substring(0xbc, 4), 4), NumberStyles.HexNumber);
                                                    this.saveData.infinityMissions.slot[index].clearCount_b = int.Parse(this.run.hexAndMathFunction.reversehex(str.Substring(0xc0, 4), 4), NumberStyles.HexNumber);
                                                    this.saveData.infinityMissions.slot[index].clearCount_a = int.Parse(this.run.hexAndMathFunction.reversehex(str.Substring(0xc4, 4), 4), NumberStyles.HexNumber);
                                                    this.saveData.infinityMissions.slot[index].clearCount_s = int.Parse(this.run.hexAndMathFunction.reversehex(str.Substring(200, 4), 4), NumberStyles.HexNumber);
                                                    this.saveData.infinityMissions.slot[index].clearCount_inf = int.Parse(this.run.hexAndMathFunction.reversehex(str.Substring(0xcc, 4), 4), NumberStyles.HexNumber);
                                                    this.saveData.infinityMissions.slot[index].level = this.saveData.infinityMissions.slot[index].enemy_table_1 + (this.saveData.infinityMissions.slot[index].enemy_level / 10);
                                                    if (this.saveData.infinityMissions.slot[index].unk_enemy_table_1_mod)
                                                    {
                                                        infinityMissionClass class10 = this.saveData.infinityMissions.slot[index];
                                                        class10.level++;
                                                    }
                                                    if (this.saveData.infinityMissions.slot[index].length > 2)
                                                    {
                                                        infinityMissionClass class11 = this.saveData.infinityMissions.slot[index];
                                                        class11.level += 10;
                                                    }
                                                    index++;
                                                    break;
                                                }
                                                s = this.run.hexAndMathFunction.reversehex(str.Substring((num4 * 4) + 0x20, 4), 4);
                                                uint num5 = uint.Parse(s, NumberStyles.HexNumber);
                                                infinityMissionClass class7 = this.saveData.infinityMissions.slot[index];
                                                class7.createdBy = class7.createdBy + Encoding.UTF32.GetString(BitConverter.GetBytes(num5));
                                                num4++;
                                            }
                                            break;
                                        }
                                        infinityMissionClass class5 = this.saveData.infinityMissions.slot[index];
                                        class5.enemy_level -= 0x40;
                                        infinityMissionClass class6 = this.saveData.infinityMissions.slot[index];
                                        class6.unk_enemy_level_mod++;
                                    }
                                    break;
                                }
                                infinityMissionClass class3 = this.saveData.infinityMissions.slot[index];
                                class3.unk_table_2_mod -= 4;
                                infinityMissionClass class4 = this.saveData.infinityMissions.slot[index];
                                class4.unk_table_2_unk_mod++;
                            }
                            break;
                        }
                        infinityMissionClass class1 = this.saveData.infinityMissions.slot[index];
                        class1.length++;
                        num3 -= 0x40;
                    }
                }
                this.saveData.infinityMissions.itemsUsed = int.Parse(this.brGetData(1, br, pos, saveInfoDataType.hex, reload, true), NumberStyles.HexNumber);
            }
            return true;
        }

        private unsafe bool parseSaveFile(string fileLoc, bool reload)
        {
            this.chunkPos = 0;
            FileStream input = null;
            BinaryReader br = null;
            if (reload)
            {
                this.initSlotVars();
                this.savedata_decimal_array_read_pos = 0;
                this.saveData.size = this.savedata_decimal_array_filled;
            }
            else
            {
                this.initSaveBuffer();
                this.initSlotVars();
                input = this.openFileRead(fileLoc);
                if (input == null)
                {
                    return false;
                }
                br = new BinaryReader(input, Encoding.BigEndianUnicode);
                if (!this.validate_filelength(br.BaseStream.Length))
                {
                    input.Close();
                    return false;
                }
                if (this.mainSettings.saveStructureIndex.encrypted)
                {
                    input.Close();
                    if (System.IO.File.Exists(@"data\temp\denc.bin"))
                    {
                        System.IO.File.Delete(@"data\temp\denc.bin");
                    }
                    if (!this.decryptSaveFile(fileLoc))
                    {
                        MessageBox.Show("There was an error decrypting the save file.");
                        return false;
                    }
                    input = this.openFileRead(@"data\temp\denc.bin");
                    br = new BinaryReader(input, Encoding.BigEndianUnicode);
                }
                this.saveData.size = (int) br.BaseStream.Length;
            }
            this.toolStripStatusLabel.Text = "Parsing Save 0%";
            this.toolStripProgressBar.Maximum = this.saveData.size;
            this.toolStripProgressBar.Value = 0;
            int pos = 0;
            this.parseHeaderInfo(br, &pos, reload);
            for (int i = 0; i < 8; i++)
            {
                if (!this.parseSlotInfo(i, br, &pos, reload))
                {
                    if (input != null)
                    {
                        input.Close();
                    }
                    return false;
                }
            }
            if (!this.parseCharacterSharedStorageSlotsInfo(br, &pos, reload))
            {
                if (input != null)
                {
                    input.Close();
                }
                return false;
            }
            if (!this.parseInfinityMissionSlotsInfo(br, &pos, reload))
            {
                if (input != null)
                {
                    input.Close();
                }
                return false;
            }
            pos = this.adjustPosition(pos, br, this.mainSettings.saveStructureIndex.total_size, reload, "end of file", true);
            if (input != null)
            {
                input.Close();
            }
            this.toolStripStatusLabel.Text = "Save File Loaded";
            this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum;
            return true;
        }

        private unsafe bool parseSlotInfo(int slot, BinaryReader br, int* pos, bool reload)
        {
            int num = this.mainSettings.saveStructureIndex.slots_position + (this.mainSettings.saveStructureIndex.slot_size * slot);
            pos[0] = this.adjustPosition(pos[0], br, num, reload, "Save Slot " + slot, true);
            if (!this.parseCharacterInfo(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterTypeLevelInfo(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterTypeExtraInfo(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterRebirthInfo(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterInventoryCountInfo(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterPADisksLearntCount(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterItemPaletteInfo(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterPADisksLearnt(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterInventorySlotsInfo(slot, br, pos, reload))
            {
                return false;
            }
            if (!this.parseCharacterStoryInfo(slot, br, pos, reload))
            {
                return false;
            }
            if ((this.saveData.slot[slot].level == 0) || (this.saveData.slot[slot].level > 200))
            {
                this.saveData.slot[slot].level = 1;
            }
            if (this.saveData.slot[slot].level == 200)
            {
                this.saveData.slot[slot].exp_next = 0;
                this.saveData.slot[slot].exp_percent = 100;
            }
            else
            {
                expDb_ItemClass class2 = new expDb_ItemClass();
                class2 = this.findExpLevelInfoInDb(this.saveData.slot[slot].level);
                if (class2 == null)
                {
                    MessageBox.Show("could not find exp for level " + this.saveData.slot[slot].level);
                }
                this.saveData.slot[slot].exp_next = (class2.exp + class2.exp_next) - this.saveData.slot[slot].exp;
                this.saveData.slot[slot].exp_percent = this.run.hexAndMathFunction.getPercentage(this.saveData.slot[slot].exp - class2.exp, class2.exp_next);
            }
            ListViewItem item = null;
            if (this.saveData.slot[slot].name == "---- Free Slot ----")
            {
                item = new ListViewItem(this.saveData.slot[slot].name, 2);
            }
            else
            {
                item = new ListViewItem(this.saveData.slot[slot].name, (int) this.saveData.slot[slot].sex) {
                    SubItems = { 
                        "LV" + this.saveData.slot[slot].level,
                        this.saveData.slot[slot].race,
                        this.saveData.slot[slot].cur_type,
                        this.storyCompleteToText(this.saveData.slot[slot].story_ep_1_complete, this.saveData.slot[slot].story_ep_2_complete) ?? ""
                    }
                };
            }
            this.lstSaveSlotView.Items.Add(item);
            return true;
        }

        private unsafe void parseTypeInfo(int slot, int job, int* pos, BinaryReader br, bool reload)
        {
            this.saveData.slot[slot].job[job].job = (jobType) job;
            this.saveData.slot[slot].job[job].level = this.brGetInt(1, pos, br, reload, true, "");
            this.saveData.slot[slot].job[job].scramble_exp = this.brGetInt(1, pos, br, reload, true, "");
            if (this.saveData.slot[slot].job[job].scramble_exp != 1)
            {
                this.saveData.slot[slot].job[job].exp = this.brGetInt(2, pos, br, reload, true, "");
            }
            else
            {
                string hex = this.brGetData(2, br, pos, saveInfoDataType.hex, reload, true);
                hex = this.run.hexAndMathFunction.reversehex(hex, 4);
                this.saveData.slot[slot].job[job].exp = int.Parse(hex, NumberStyles.HexNumber) + 0x10000;
            }
        }

        private void pspo2seForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        public int readByteAndSaveInSaveBuffer(BinaryReader br, bool reload, string debugHelper, bool showSaveParseProgress)
        {
            this.chunkPos++;
            int num = 0;
            if (reload)
            {
                try
                {
                    num = this.savedata_decimal_array[this.savedata_decimal_array_read_pos];
                    this.savedata_decimal_array_read_pos++;
                }
                catch
                {
                    MessageBox.Show(string.Concat(new object[] { "trying to read past buffer[", this.savedata_decimal_array_filled, "] at ", this.savedata_decimal_array_read_pos, " from ", debugHelper }));
                }
                if (showSaveParseProgress && (this.chunkPos >= 0x400))
                {
                    this.chunkPos = 0;
                    this.toolStripStatusLabel.Text = "Parsing Save " + this.run.hexAndMathFunction.getPercentage(this.savedata_decimal_array_read_pos, this.toolStripProgressBar.Maximum) + "%";
                    this.toolStripProgressBar.Value = this.savedata_decimal_array_read_pos;
                    Application.DoEvents();
                }
            }
            else
            {
                try
                {
                    num = br.ReadByte();
                    if (this.savedata_decimal_array_filled >= 0x49928)
                    {
                        MessageBox.Show("Buffer is full, trying to load a save file that is not PSPo2?", "Fatal Error!");
                    }
                    else
                    {
                        this.savedata_decimal_array[this.savedata_decimal_array_filled] = num;
                        this.savedata_decimal_array_filled++;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to read byte, check to see if the end of the file is reached\r\n" + exception, "Fatal Error");
                }
                if (showSaveParseProgress && (this.chunkPos >= 0x400))
                {
                    this.chunkPos = 0;
                    this.toolStripStatusLabel.Text = "Parsing Save " + this.run.hexAndMathFunction.getPercentage(this.savedata_decimal_array_filled, this.toolStripProgressBar.Maximum) + "%";
                    this.toolStripProgressBar.Value = this.savedata_decimal_array_filled;
                    Application.DoEvents();
                }
            }
            return num;
        }

        private void refreshFromBuffer()
        {
            if (!this.reloadSaveFile())
            {
                MessageBox.Show("There was an error reloading the save data from the buffer");
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.action_loadDatabases();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.loadImageFloaterImages();
        }

        public void reloadEverything()
        {
            int index = this.lstSaveSlotView.SelectedItems[0].Index;
            this.loadSaveFile(true);
            this.lstSaveSlotView.Items[index].Selected = true;
        }

        private bool reloadSaveFile() => 
            this.loadSaveFile(false);

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.action_saveas();
        }

        private bool saveBufferDataToFile(int startpos, int size, string ext_options, int addinteger = 0, bool isSaveFile = false, string path = null, string fileNameDefault = "")
        {
            if (path == null)
            {
                path = this.openSaveDialogue(ext_options, fileNameDefault);
            }
            if (path == null)
            {
                return false;
            }
            string dest = path;
            try
            {
                if (this.mainSettings.saveStructureIndex.encrypted && isSaveFile)
                {
                    path = @"data\temp\denc.bin";
                }
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        if (addinteger != 0)
                        {
                            writer.Write((byte) addinteger);
                        }
                        this.brWriteFromBuffer(writer, startpos, size);
                        writer.Close();
                    }
                    stream.Close();
                }
            }
            catch
            {
                MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return (!this.mainSettings.saveStructureIndex.encrypted || (!isSaveFile || this.encryptSaveFile(path, dest)));
        }

        private bool saveItemDataToFile(int startpos, int size, string ext_options, string itemName, string fn = "", bool delete = false)
        {
            if (fn == "")
            {
                fn = this.openSaveDialogue(ext_options, itemName);
            }
            if (fn != null)
            {
                try
                {
                    using (FileStream stream = new FileStream(fn, FileMode.Create))
                    {
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {
                            int num = 0;
                            while (true)
                            {
                                if (num >= size)
                                {
                                    writer.Close();
                                    break;
                                }
                                if (num != 15)
                                {
                                    this.brWriteFromBuffer(writer, startpos + num, 1);
                                }
                                else
                                {
                                    string s = this.run.hexAndMathFunction.decimalByteConvert(this.savedata_decimal_array[startpos + num], "hex");
                                    s = (s.Length >= 2) ? ("0" + s.Substring(1, 1)) : ("0" + s);
                                    writer.Write(byte.Parse(s, NumberStyles.HexNumber));
                                }
                                if (delete)
                                {
                                    this.savedata_decimal_array[startpos + num] = 0;
                                }
                                num++;
                            }
                        }
                        stream.Close();
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

        private void saveSlotView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstSaveSlotView.SelectedItems.Count > 0)
            {
                this.displaySlotInfo(this.lstSaveSlotView.SelectedItems[0].Index);
                if (this.tabArea.SelectedIndex == 2)
                {
                    this.inventoryViewPages.SelectedIndex = 0;
                    Application.DoEvents();
                }
                if (this.tabArea.SelectedIndex == 3)
                {
                    this.storageViewPages.SelectedIndex = 0;
                    Application.DoEvents();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.action_save();
        }

        private void showButtons(pageFields fields, itemType type)
        {
            if (type == itemType.free_slot)
            {
                fields.btn_delete.Enabled = false;
                fields.btn_export_selected.Enabled = false;
                fields.chk_delete_export.Enabled = false;
                fields.btn_withdraw.Enabled = false;
                fields.btn_import_selected.Enabled = true;
                fields.txt_hex.Text = "0xFFFFFFFF";
            }
            else if (type == itemType.nothing)
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

        private void showGameImage()
        {
            switch (this.saveData.type)
            {
                case SaveType.PSP2:
                    this.imgSave.Image = Resources.PSP2;
                    this.imgGameLogo.Image = Resources.PSP2_logo;
                    this.imgSave.Show();
                    return;

                case SaveType.PSP2I:
                    this.imgSave.Image = Resources.PSP2i;
                    this.imgGameLogo.Image = Resources.PSP2i_logo;
                    this.imgSave.Show();
                    return;
            }
            this.imgGameLogo.Image = Resources.PSP2_logo;
            this.imgSave.Hide();
        }

        public void showSelectedInventoryItem(TabPage page)
        {
            pageFields fields = this.getPageFields(page, false);
            inventoryItemClass item = null;
            bool flag = false;
            if (!ReferenceEquals(page, this.tabPageStorage))
            {
                if (this.inventoryView.SelectedItems.Count <= 0)
                {
                    item = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[0];
                }
                else
                {
                    item = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)];
                    flag = true;
                }
            }
            else if (this.storageView.SelectedItems.Count <= 0)
            {
                item = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[0];
            }
            else
            {
                item = this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
                item.qty_max = 0x3e7;
                flag = true;
            }
            if (!item.used)
            {
                item.name = "---- Free Slot ----";
                item.rarity = -1;
                item.type = itemType.free_slot;
            }
            fields.txt_hex.Text = "0x" + item.hex_reversed;
            fields.txt_name.Text = item.name;
            fields.txt_name_jp.Text = item.name_jp;
            this.showButtons(fields, item.type);
            this.displayItemImage(fields, item);
            this.displayItemStars(fields, item.rarity);
            this.displayItemInfo(fields, item);
            if (flag)
            {
                this.changeImageFloater(item.hex_reversed);
            }
        }

        private void showTypeWeaponExtendImages(jobClass type, TabPage page)
        {
            typeWeaponRankFields fields = this.getTypeWeaponExtendFields(page);
            for (int i = 1; i <= 0x1c; i++)
            {
                extendRankType type2 = type.weapons_extended[i];
                switch (type2)
                {
                    case extendRankType.none:
                        fields.imgWeap[i].Visible = false;
                        fields.imgRank[i].Visible = false;
                        break;

                    case extendRankType.c:
                        fields.imgWeap[i].Visible = true;
                        fields.imgRank[i].Visible = true;
                        fields.imgRank[i].Image = Resources.rank_C;
                        break;

                    case extendRankType.b:
                        fields.imgWeap[i].Visible = true;
                        fields.imgRank[i].Visible = true;
                        fields.imgRank[i].Image = Resources.rank_B;
                        break;

                    case extendRankType.a:
                        fields.imgWeap[i].Visible = true;
                        fields.imgRank[i].Visible = true;
                        fields.imgRank[i].Image = Resources.rank_A;
                        break;

                    case extendRankType.s:
                        fields.imgWeap[i].Visible = true;
                        fields.imgRank[i].Visible = true;
                        fields.imgRank[i].Image = Resources.rank_S;
                        break;

                    default:
                        break;
                }
            }
        }

        private void sortInventory(int slotnum)
        {
            ArrayList list = ArrayList.Adapter(this.saveData.slot[slotnum].inventory.item);
            list.Sort();
            this.saveData.slot[slotnum].inventory.item = (inventoryItemClass[]) list.ToArray(typeof(inventoryItemClass));
        }

        private void sortStorage()
        {
            ArrayList list = ArrayList.Adapter(this.saveData.sharedInventory.item);
            list.Sort();
            this.saveData.sharedInventory.item = (inventoryItemClass[]) list.ToArray(typeof(inventoryItemClass));
        }

        private void storageView_Click(object sender, EventArgs e)
        {
            this.storageViewChanged();
        }

        private void storageView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.storageViewChanged();
        }

        private void storageViewChanged()
        {
            if (this.storageView.SelectedItems.Count <= 0)
            {
                this.grpStorageItemDetails.Visible = false;
                this.imageFloatImageIsOk = false;
                this.txtStorageHex.Text = "0x00000000";
            }
            else
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
        }

        private void storageViewPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.changeStoragePage(this.storageViewPages.SelectedIndex + 1);
        }

        private string storyCompleteToText(bool ep1_complete, bool ep2_complete) => 
            !ep1_complete ? (!ep2_complete ? "" : "Ep 2 Complete") : ((this.saveData.type != SaveType.PSP2) ? (!ep2_complete ? "Ep 1 Complete" : "Game Complete") : "Game Complete");

        public abilityType stringToAbilityEnum(string str)
        {
            if ((str == "") || (str == null))
            {
                return abilityType.None;
            }
            str = str.Replace(" ", "_");
            str = str.Replace("Empow.", "Empow");
            if (str == "HP_affects_pwr.")
            {
                str = "HP_affects_pwr";
            }
            try
            {
                return (abilityType) System.Enum.Parse(typeof(abilityType), str, true);
            }
            catch
            {
                return abilityType.None;
            }
        }

        private void tabArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabArea.SelectedIndex)
            {
                case 2:
                    this.inventoryViewPages.SelectedIndex = 0;
                    if (this.inventoryView.SelectedItems.Count <= 0)
                    {
                        this.makeImageFloaterHidden();
                        return;
                    }
                    this.changeImageFloater(this.txtInventoryHex.Text.Substring(2, 8));
                    return;

                case 3:
                    this.storageViewPages.SelectedIndex = 0;
                    if (this.storageView.SelectedItems.Count <= 0)
                    {
                        this.makeImageFloaterHidden();
                        return;
                    }
                    this.changeImageFloater(this.txtStorageHex.Text.Substring(2, 8));
                    return;
            }
            this.closeImageFloater();
        }

        private void txtAllowQuitMission_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtAllowQuitMission.Text == "Yes")
                {
                    MessageBox.Show("You can already quit missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want enable quiting missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                    pos = (this.saveData.type != SaveType.PSP2I) ? (pos + 0x1159) : (pos + 0x11a5);
                    this.overwriteHexInBuffer("FF", pos);
                    this.txtAllowQuitMission.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].allow_quit_missions = "FF";
                    MessageBox.Show("The quit mission function was unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtCharacterName_Click(object sender, EventArgs e)
        {
            this.entryForm.oldVal = this.txtCharacterName.Text;
            this.entryForm.newVal = this.txtCharacterName.Text;
            this.entryForm.description = "character name";
            this.entryForm.maxLen = 0x20;
            if (this.entryForm.ShowDialog(this) == DialogResult.OK)
            {
                string newVal = this.entryForm.newVal;
                if (newVal != this.txtCharacterName.Text)
                {
                    string hex = this.run.hexAndMathFunction.stringToHexadecimal(newVal, 0x40);
                    this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index));
                    this.overwriteHexInBuffer(hex, this.mainSettings.saveStructureIndex.character_name_pos2 + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index));
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].name = newVal;
                    this.lstSaveSlotView.SelectedItems[0].Text = newVal;
                    this.txtCharacterName.Text = newVal;
                }
            }
        }

        private void txtClass_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race.ToString();
                this.entryForm.newVal = ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race).ToString();
                this.entryForm.description = "class";
                this.entryForm.maxLen = 1;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race).ToString())
                    {
                        string hex = int.Parse(newVal).ToString("X1");
                        while (true)
                        {
                            if (hex.Length >= 2)
                            {
                                hex = this.run.hexAndMathFunction.reversehex(hex, 2);
                                this.overwriteHexInBuffer(hex, (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0x80);
                                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race = (raceTypes) int.Parse(newVal);
                                this.txtRace.Text = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race;
                                this.lstSaveSlotView.SelectedItems[0].SubItems[2].Text = this.txtRace.Text;
                                break;
                            }
                            hex = "0" + hex;
                        }
                    }
                }
            }
        }

        private void txtCurType_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type.ToString();
                this.entryForm.newVal = ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type).ToString();
                this.entryForm.description = "type";
                this.entryForm.maxLen = 1;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type).ToString())
                    {
                        string hex = int.Parse(newVal).ToString("X1");
                        while (true)
                        {
                            if (hex.Length >= 2)
                            {
                                hex = this.run.hexAndMathFunction.reversehex(hex, 2);
                                this.overwriteHexInBuffer(hex, (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 130);
                                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type = (jobType) int.Parse(newVal);
                                this.txtCurType.Text = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type;
                                this.lstSaveSlotView.SelectedItems[0].SubItems[3].Text = this.txtCurType.Text;
                                break;
                            }
                            hex = "0" + hex;
                        }
                    }
                }
            }
        }

        private void txtEp1Complete_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtEp1Complete.Text == "Yes")
                {
                    MessageBox.Show("You have already completed Episode 1.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want set Episode 1 to complete?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                    pos = (this.saveData.type != SaveType.PSP2I) ? (pos + 0x5a89) : (pos + 0x577d);
                    if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].story_ep_2_complete)
                    {
                        this.overwriteHexInBuffer("03", pos);
                    }
                    else
                    {
                        this.overwriteHexInBuffer("01", pos);
                    }
                    this.txtEp1Complete.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].story_ep_1_complete = true;
                    this.reloadEverything();
                    MessageBox.Show("Episode 1 was completed successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtEp2Complete_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtEp2Complete.Text == "Yes")
                {
                    MessageBox.Show("You have already completed Episode 2.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want set Episode 2 to complete?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                    pos = (this.saveData.type != SaveType.PSP2I) ? (pos + 0x5a89) : (pos + 0x577d);
                    if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].story_ep_1_complete)
                    {
                        this.overwriteHexInBuffer("03", pos);
                    }
                    else
                    {
                        this.overwriteHexInBuffer("02", pos);
                    }
                    this.txtEp2Complete.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].story_ep_2_complete = true;
                    this.reloadEverything();
                    MessageBox.Show("Episode 2 was completed successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtInventoryATK_Click(object sender, EventArgs e)
        {
            this.changeItemATK(this.tabPageInventory);
        }

        private void txtInventoryHex_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtInventoryHex.Text.Substring(2, 8));
            MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtInventoryMeseta_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                this.entryForm.oldVal = this.txtInventoryMeseta.Text;
                this.entryForm.newVal = this.txtInventoryMeseta.Text;
                this.entryForm.description = "characters meseta";
                this.entryForm.maxLen = 8;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    long num = long.Parse(this.entryForm.newVal);
                    if (num != this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].meseta)
                    {
                        string hex = num.ToString("X4");
                        while (hex.Length < 8)
                        {
                            hex = "0" + hex;
                        }
                        this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 8), (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0xf4);
                        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].meseta = num;
                        this.txtInventoryMeseta.Text = num.ToString();
                    }
                    else if (num > 0x5f5e0ffL)
                    {
                        MessageBox.Show("You must enter a value less than 99,999,999");
                    }
                }
            }
        }

        private void txtInventoryName_jp_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtInventoryName_jp.Text);
            MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtInventoryPercent_Click(object sender, EventArgs e)
        {
            this.changeItemPercentage(this.tabPageInventory);
        }

        private void txtInventoryQty_Click(object sender, EventArgs e)
        {
            this.changeItemQty(this.tabPageInventory);
        }

        private void txtInventorySpecial_Click(object sender, EventArgs e)
        {
            this.changeItemSpecial(this.tabPageInventory);
        }

        private void txtLevel_Click(object sender, EventArgs e)
        {
            this.jumpToLevel();
        }

        private void txtMissionEp1_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtMissionEp1.Text == "Yes")
                {
                    MessageBox.Show("You have already unlocked all of the Episode 1 Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want unlock all of the Episode 1 Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                    pos = (this.saveData.type != SaveType.PSP2I) ? (pos + 0xd6c) : (pos + 0xdb8);
                    this.overwriteHexInBuffer("204E", pos);
                    this.txtMissionEp1.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_ep1 = true;
                    MessageBox.Show("The Episode 1 Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtMissionEp2_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtMissionEp2.Text == "Yes")
                {
                    MessageBox.Show("You have already unlocked all of the Episode 2 Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want unlock all of the Episode 2 Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                    if (this.saveData.type == SaveType.PSP2I)
                    {
                        pos += 0xe28;
                    }
                    else
                    {
                        MessageBox.Show("This feature is for Infinity only");
                    }
                    this.overwriteHexInBuffer("204E", pos);
                    this.txtMissionEp2.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_unknown = true;
                    MessageBox.Show("The Episode 2 Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtMissionMagashi_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtMissionMagashi.Text == "Yes")
                {
                    MessageBox.Show("You have already unlocked Magashi Plan.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want unlock Magashi Plan?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                    pos = (this.saveData.type != SaveType.PSP2I) ? (pos + 0xc6e) : (pos + 0xcaa);
                    this.overwriteHexInBuffer("1F", pos);
                    this.txtMissionMagashi.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_magashi = true;
                    MessageBox.Show("The Magashi Plan mission was unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtMissionUnknown_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtMissionTactical.Text == "Yes")
                {
                    MessageBox.Show("You have already unlocked all of the Unknown Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want unlock all of the Unknown Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                    pos = (this.saveData.type != SaveType.PSP2I) ? (pos + 0xda0) : (pos + 0xdec);
                    this.overwriteHexInBuffer("204E", pos);
                    this.txtMissionTactical.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_unknown = true;
                    MessageBox.Show("The Unknown Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtSex_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex.ToString();
                this.entryForm.newVal = ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex).ToString();
                this.entryForm.description = "sex";
                this.entryForm.maxLen = 1;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex).ToString())
                    {
                        string hex = int.Parse(newVal).ToString("X1");
                        while (true)
                        {
                            if (hex.Length >= 2)
                            {
                                hex = this.run.hexAndMathFunction.reversehex(hex, 2);
                                this.overwriteHexInBuffer(hex, (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0x81);
                                this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex = (sexType) int.Parse(newVal);
                                this.txtSex.Text = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex;
                                break;
                            }
                            hex = "0" + hex;
                        }
                    }
                }
            }
        }

        private void txtSkipEp1Start_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtSkipEp1Start.Text == "Yes")
                {
                    MessageBox.Show("You are already skipping the starting sequence to Episode 1", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want to skip the starting sequence to Episode 1?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index);
                    pos = (this.saveData.type != SaveType.PSP2I) ? (pos + 0x1554) : (pos + 0x1228);
                    this.overwriteHexInBuffer("90AB1E", pos);
                    this.txtSkipEp1Start.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].skip_ep_1_start = true;
                    MessageBox.Show("The Episode 1 start sequence was skipped successfully.\n\nYou will need to play the first mission to progress the story.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtSkipEp2Start_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                if (this.txtSkipEp2Start.Text == "Yes")
                {
                    MessageBox.Show("You are already skipping the starting sequence to Episode 2", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("Are you sure you want to skip the starting sequence to Episode 2?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
                {
                    int pos = (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0x124c;
                    this.overwriteHexInBuffer("78AF1E", pos);
                    this.txtSkipEp2Start.Text = "Yes";
                    this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].skip_ep_2_start = true;
                    MessageBox.Show("The Episode 2 start sequence was skipped successfully.\n\nGo to the Little Wing Office to progress the story further.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtStorageATK_Click(object sender, EventArgs e)
        {
            this.changeItemATK(this.tabPageStorage);
        }

        private void txtStorageHex_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtStorageHex.Text.Substring(2, 8));
            MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtStorageMeseta_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                this.entryForm.oldVal = this.saveData.sharedMeseta;
                this.entryForm.newVal = this.saveData.sharedMeseta;
                this.entryForm.description = "shared meseta";
                this.entryForm.maxLen = 8;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    long num = long.Parse(this.entryForm.newVal);
                    if ((num != this.saveData.sharedMeseta) && (num <= 0x5f5e0ffL))
                    {
                        string hex = num.ToString("X4");
                        while (hex.Length < 8)
                        {
                            hex = "0" + hex;
                        }
                        int pos = this.mainSettings.saveStructureIndex.shared_inventory_pos + (this.mainSettings.saveStructureIndex.shared_inventory_slots * 20);
                        this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 8), pos);
                        this.saveData.sharedMeseta = num;
                        this.txtStorageMeseta.Text = num.ToString();
                    }
                    else if (num > 0x5f5e0ffL)
                    {
                        MessageBox.Show("You must enter a value less than 99,999,999");
                    }
                }
            }
        }

        private void txtStorageName_jp_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtStorageName_jp.Text);
            MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtStoragePercent_Click(object sender, EventArgs e)
        {
            this.changeItemPercentage(this.tabPageStorage);
        }

        private void txtStorageQty_Click(object sender, EventArgs e)
        {
            this.changeItemQty(this.tabPageStorage);
        }

        private void txtStorageSpecial_Click(object sender, EventArgs e)
        {
            this.changeItemSpecial(this.tabPageStorage);
        }

        private void txtTitle_Click(object sender, EventArgs e)
        {
            if (!this.legitVersion())
            {
                this.entryForm.oldVal = this.txtTitle.Text;
                this.entryForm.newVal = this.txtTitle.Text;
                this.entryForm.description = "title";
                this.entryForm.maxLen = 0x19;
                if (this.entryForm.ShowDialog(this) == DialogResult.OK)
                {
                    string newVal = this.entryForm.newVal;
                    if (newVal != this.txtTitle.Text)
                    {
                        string hex = this.run.hexAndMathFunction.stringToHexadecimal(newVal, 0x40);
                        this.overwriteHexInBuffer(hex, (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0x40);
                        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].title = newVal;
                        this.txtTitle.Text = newVal;
                    }
                }
            }
        }

        private void updateRebirthBufferVals(int slot)
        {
            int num = (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * slot)) + 0x1b6;
            string hex = "";
            for (int i = 0; i < 12; i++)
            {
                hex = "";
                int num3 = i;
                switch (num3)
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

                    default:
                        break;
                }
                if (hex != "")
                {
                    while (true)
                    {
                        if (hex.Length >= 4)
                        {
                            hex = this.run.hexAndMathFunction.reversehex(hex, 4);
                            this.overwriteHexInBuffer(hex, num + (i * 2));
                            break;
                        }
                        hex = "0" + hex;
                    }
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.checkAppUpdate(true);
        }

        private bool validate_character_file_length(int length)
        {
            if (this.mainSettings.saveStructureIndex.slot_size == length)
            {
                return true;
            }
            MessageBox.Show("The character file appears to be incorrect", "File Error");
            return false;
        }

        private bool validate_filelength(long filelength)
        {
            this.mainSettings.saveStructureIndex.changeSaveSettingsType(SaveType.PSP2);
            this.mainSettings.saveStructureIndex.encrypted = false;
            if ((filelength == this.mainSettings.saveStructureIndex.total_size) || (filelength == this.mainSettings.saveStructureIndex.total_size_enc))
            {
                this.saveData.set_type(SaveType.PSP2);
                if (filelength == this.mainSettings.saveStructureIndex.total_size_enc)
                {
                    this.mainSettings.saveStructureIndex.encrypted = true;
                }
                this.txtFileSize.Text = Convert.ToString(this.mainSettings.saveStructureIndex.total_size) + " bytes";
                return true;
            }
            this.mainSettings.saveStructureIndex.changeSaveSettingsType(SaveType.PSP2I);
            if ((filelength != this.mainSettings.saveStructureIndex.total_size) && (filelength != this.mainSettings.saveStructureIndex.total_size_enc))
            {
                this.saveData.set_type(SaveType.NONE);
                this.txtFileSize.Text = "0 bytes";
                this.displaySlotInfo(0);
                this.showGameImage();
                this.txtFileSize.Text = Convert.ToString(filelength) + " bytes";
                return false;
            }
            this.saveData.set_type(SaveType.PSP2I);
            if (filelength == this.mainSettings.saveStructureIndex.total_size_enc)
            {
                this.mainSettings.saveStructureIndex.encrypted = true;
            }
            this.txtFileSize.Text = Convert.ToString(this.mainSettings.saveStructureIndex.total_size) + " bytes";
            return true;
        }

        private void versionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = !this.legitVersion() ? "PSPo2 Save Editor" : "PSPo2 Save Viewer";
            if (!this.databasesOk)
            {
                MessageBox.Show("You are currently running " + str + " v3.0 build 1008\r\n\r\nThe databases are not installed correctly.\r\nPlease update them before you can view more information.", "Version Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.changelogForm.formSetup();
                this.changelogForm.ShowDialog(this);
            }
        }

        private void weaponDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.weaponDatabaseForm.initForm();
            this.weaponDatabaseForm.Show(this);
        }

        public string weaponEnumToName(weaponType type)
        {
            string str = this.enumToName(type);
            return ((str.Substring(str.Length - 1, 1) != "s") ? (str + "s") : ("Twin " + str));
        }

        public void writeNewLevelData(int newvalue)
        {
            expDb_ItemClass class2 = this.findExpLevelInfoInDb(newvalue);
            string hex = class2.level.ToString("X2");
            this.overwriteHexInBuffer(hex, (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 0xe8);
            hex = class2.exp.ToString("X4");
            while (hex.Length < 8)
            {
                hex = "0" + hex;
            }
            this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 8), (this.mainSettings.saveStructureIndex.header_size + (this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index)) + 240);
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level = class2.level;
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].exp = class2.exp;
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].exp_next = class2.exp_next;
            this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].exp_percent = 0;
            this.lstSaveSlotView.SelectedItems[0].SubItems[1].Text = "LV" + class2.level;
            this.displaySlotInfo(this.lstSaveSlotView.SelectedItems[0].Index);
        }

        public void writeToSaveBuffer(int pos, int[] bytearray, int size, int[] bytestoadd)
        {
            if ((pos + size) > this.savedata_decimal_array_filled)
            {
                MessageBox.Show("Trying to save bytes beyond the loaded buffer", "Fatal Error!");
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    bytearray[pos] = bytestoadd[i];
                }
            }
        }

        public saveDataType get_saveDataInfo =>
            this.saveData;

        public TabPage get_tabPageType =>
            this.tabPageInventory;

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
            Empow_healing
        }

        public enum clothesManufacturerType
        {
            Kubara,
            Roar,
            Cubic,
            Miyab
        }

        public enum clothesTypes
        {
            unknown_0,
            top,
            bottom,
            shoes,
            top_set,
            bottom_set,
            set
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
            COUNT
        }

        public enum equippedType
        {
            not_equipped,
            equipped,
            equipped_in_use
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
            public pspo2seForm.expDb_ItemClass[] level = new pspo2seForm.expDb_ItemClass[0x163];
        }

        public enum extendRankType
        {
            none,
            c,
            b,
            a,
            s
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
            none
        }

        private class imageFloatBox
        {
            public Point pnlloc = new Point();
            public Point grploc = new Point();
            public PictureBox picBox = new PictureBox();
            public FileInfo[] imagelist = new FileInfo[0x5dc];
            public int filled;
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

            public int CompareTo(object obj)
            {
                if (!(obj is pspo2seForm.infinityMissionClass))
                {
                    throw new ArgumentException("Object is not of type infinityMissionClass.");
                }
                pspo2seForm.infinityMissionClass class2 = (pspo2seForm.infinityMissionClass) obj;
                return this.hex.CompareTo(class2.hex);
            }
        }

        public class infinityMissionSlotsClass
        {
            public int itemsUsed;
            public pspo2seForm.infinityMissionClass[] slot = new pspo2seForm.infinityMissionClass[100];
        }

        public class inventoryClass
        {
            public int itemsUsed;
            public pspo2seForm.inventoryItemClass[] item = new pspo2seForm.inventoryItemClass[60];
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

            public int CompareTo(object obj)
            {
                if (!(obj is pspo2seForm.inventoryItemClass))
                {
                    throw new ArgumentException("Object is not of type inventoryItemClass.");
                }
                pspo2seForm.inventoryItemClass class2 = (pspo2seForm.inventoryItemClass) obj;
                return this.hex.CompareTo(class2.hex);
            }
        }

        public class inventorySharedClass
        {
            public int itemsUsed;
            public pspo2seForm.inventoryItemClass[] item = new pspo2seForm.inventoryItemClass[0x7d0];
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
            public pspo2seForm.itemDb_ItemClass[] item = new pspo2seForm.itemDb_ItemClass[0xfa0];
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
            unknown
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
            extended_special
        }

        public enum itemRankType
        {
            c,
            b,
            a,
            s,
            unknown
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
            free_slot
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
            public pspo2seForm.extendRankType[] weapons_extended = new pspo2seForm.extendRankType[0x1d];
        }

        public enum jobType
        {
            Hunter,
            Ranger,
            Force,
            Vanguard,
            None
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

        public class paInfoType
        {
            public int count;
            public pspo2seForm.inventoryItemClass[] items = new pspo2seForm.inventoryItemClass[0x100];
        }

        public enum partFileType
        {
            character,
            inventory,
            storage,
            item,
            infinity_mission,
            infinity_mission_pack
        }

        public enum partsTypes
        {
            unknown_0,
            torso,
            legs,
            arms,
            unknown_4,
            unknown_5,
            set
        }

        public enum raceTypes
        {
            Human,
            Newman,
            Cast,
            Beast,
            Duman,
            None
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

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }

        public class saveDataType
        {
            public pspo2seForm.SaveType type;
            public pspo2seForm.saveSlotType[] slot = new pspo2seForm.saveSlotType[8];
            public int size;
            public pspo2seForm.inventorySharedClass sharedInventory = new pspo2seForm.inventorySharedClass();
            public pspo2seForm.infinityMissionSlotsClass infinityMissions = new pspo2seForm.infinityMissionSlotsClass();
            public long sharedMeseta;

            public void set_type(pspo2seForm.SaveType new_type)
            {
                this.type = new_type;
            }
        }

        public enum saveInfoDataType
        {
            str,
            hex
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

        public enum SaveType
        {
            NONE,
            PSP2,
            PSP2I
        }

        public enum sexType
        {
            Male,
            Female,
            None
        }

        public enum slotType
        {
            unit,
            mirage,
            suv,
            visual
        }

        public class typeexpDbType
        {
            public pspo2seForm.expDb_ItemClass[] level = new pspo2seForm.expDb_ItemClass[0x37];
        }

        public class typeSectionFields
        {
            public Label txtLevel;
            public Label txtExp;
            public Label expBar;
            public GroupBox grpExtend;
        }

        public class typeWeaponRankFields
        {
            public PictureBox[] imgWeap = new PictureBox[0x1d];
            public PictureBox[] imgRank = new PictureBox[0x1d];
        }

        public class updateCSVInfo
        {
            public string fn;
            public string ver;
        }

        public enum weaponHandType
        {
            both,
            right,
            left
        }

        public enum weaponManufacturerType
        {
            GRM,
            Yohmei,
            Tenora_Works,
            Kubara
        }

        public enum weaponStyleType
        {
            Melee,
            Ranged_long,
            Ranged_short,
            Tech
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
            armor
        }
    }
}

