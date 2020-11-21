// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.pspo2seForm
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

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
  public class pspo2seForm : Form
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
        this.imageFloater.picBox.Image = (Image) new Bitmap(imageFloatInList);
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
        pageFields.pnl_details = (Panel) null;
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
        pageFields.pnl_details = (Panel) null;
      }
      else
      {
        int num = (int) MessageBox.Show("The selected page for getFields was not recognised: " + (object) page);
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
      int num = (int) MessageBox.Show("Fatal error. Trying to exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return (pspo2seForm.expDb_ItemClass) null;
    }

    public void addExpLevelInfoToDb(string csvLine)
    {
      if (this.exp_db_filled >= 355)
      {
        int num1 = (int) MessageBox.Show("Fatal Error! ExpLevel Database is too large!");
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
        int num2 = (int) MessageBox.Show("The ExpLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
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
        int num = (int) MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Level Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    public pspo2seForm.expDb_ItemClass findExpTypeInfoInDb(int level)
    {
      if (level < this.type_db_filled)
        return this.typeexp_db.level[level];
      int num = (int) MessageBox.Show("Fatal error. Trying to get type exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return (pspo2seForm.expDb_ItemClass) null;
    }

    public pspo2seForm.expDb_ItemClass findRebirthBpInfoInDb(int level)
    {
      if (level - 50 + 200 < this.exp_db_filled)
        return this.exp_db.level[level - 50 + 200];
      int num = (int) MessageBox.Show("Fatal error. Trying to get rebirth info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return (pspo2seForm.expDb_ItemClass) null;
    }

    public void addExpTypeInfoToDb(string csvLine)
    {
      if (this.type_db_filled >= 55)
      {
        int num1 = (int) MessageBox.Show("Fatal Error! ExpTypeLevel Database is too large!");
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
          int num2 = (int) MessageBox.Show("The ExpTypeLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
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
        int num = (int) MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Type Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        int num = (int) MessageBox.Show("This is your first time running the application\r\nYou will need to update the databases\r\nbefore you can do anything.\r\n\r\nChoose databases from the top menu to update.", "First time use", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\keys"))
        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\keys");
      if (!this.downloadRequiredFile("FolderZipper.dll", "The application will not start without this file.", 6144L))
      {
        int num = (int) MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Environment.Exit(0);
      }
      if (!this.downloadRequiredFile("ICSharpCode.SharpZipLib.dll", "The application will not start without this file.", 200704L))
      {
        int num = (int) MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Environment.Exit(0);
      }
      if (!this.downloadRequiredFile("pspo2se_updater.exe", "The application will not start without this file.", 6144L))
      {
        int num = (int) MessageBox.Show("The application will now close", "Application Closing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        int num = (int) MessageBox.Show("The databases must be updated before you can use the application", "Database Updates Required", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
          int num = (int) MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          if (!this.saveBufferDataToFile(0, this.saveData.size, "PSP Decrypted Save Data (*.bin)|*.bin"))
            return;
          int num = (int) MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("There is no data to save", "Save Data Buffer Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
          int num = (int) MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          if (!this.saveBufferDataToFile(0, this.saveData.size, "PSP Decrypted Save Data (*.bin)|*.bin", isSaveFile: true, path: this.txtFileLoc.Text))
            return;
          int num = (int) MessageBox.Show("The data was saved successfully", "Save Data Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      else
      {
        int num1 = (int) MessageBox.Show("There is no data to save", "Save Data Buffer Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void action_launchTypeAbilitiesForm()
    {
      string attachedAbilities = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex].attachedAbilities;
      this.abilitiesForm.oldJobs = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job;
      this.abilitiesForm.newJob = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].job[this.tabControlClasses.SelectedIndex];
      this.abilitiesForm.selectedJob = (pspo2seForm.jobType) this.tabControlClasses.SelectedIndex;
      this.abilitiesForm.max_abilities = this.mainSettings.saveStructureIndex.max_type_abilities;
      this.abilitiesForm.character_name = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].name;
      this.abilitiesForm.abilityDb = this.abilityDb;
      this.abilitiesForm.saveType = this.saveData.type;
      bool flag = false;
      while (!flag)
      {
        if (this.abilitiesForm.ShowDialog((IWin32Window) this) == DialogResult.OK)
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
      int num = (int) MessageBox.Show("The character file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void btnUndoAll_Click(object sender, EventArgs e) => this.loadSaveFile(false);

    private void btnImportCharacter_Click(object sender, EventArgs e)
    {
      if (this.loadFileIntoBuffer(this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index, this.mainSettings.saveStructureIndex.character_file_name + " (*" + this.mainSettings.saveStructureIndex.character_file_ext + ")|*" + this.mainSettings.saveStructureIndex.character_file_ext, pspo2seForm.partFileType.character, false) <= 0)
        return;
      this.reloadEverything();
      int num = (int) MessageBox.Show("The character file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      int num = (int) MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        int num = (int) MessageBox.Show("The item file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num1 = (int) MessageBox.Show("The item file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnStorageExportSelected_Click(object sender, EventArgs e)
    {
      if (this.saveItemDataToFile(this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)].id, 20, this.mainSettings.saveStructureIndex.item_file_name + " (*" + this.mainSettings.saveStructureIndex.item_file_ext + ")|*" + this.mainSettings.saveStructureIndex.item_file_ext, this.storageView.SelectedItems[0].Text, delete: this.chkDeleteExportStorage.Checked))
      {
        if (this.chkDeleteExportStorage.Checked)
          this.reloadEverything();
        int num = (int) MessageBox.Show("The item file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num1 = (int) MessageBox.Show("The item file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      int num = (int) MessageBox.Show("The item was imported successfully.\n\nIf the item was modified, the values may not match the game until the next time you save your progress.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      int num = (int) MessageBox.Show("The item / items were imported successfully.\n\nIf an item was modified, the values may not match the game until the next time you save your progress.\n\nPlease remember that you should not used modified items online as you may get banned.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void btnStorageExportAll_Click(object sender, EventArgs e)
    {
      if (!this.saveBufferDataToFile(this.mainSettings.saveStructureIndex.shared_inventory_pos, this.mainSettings.saveStructureIndex.shared_inventory_slots * 20, this.mainSettings.saveStructureIndex.storage_file_name + " (*" + this.mainSettings.saveStructureIndex.storage_file_ext + ")|*" + this.mainSettings.saveStructureIndex.storage_file_ext))
        return;
      int num = (int) MessageBox.Show("The storage file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void btnInventoryExportAll_Click(object sender, EventArgs e)
    {
      if (!this.saveBufferDataToFile(this.mainSettings.saveStructureIndex.inventory_slots_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index, 2160, this.mainSettings.saveStructureIndex.inventory_file_name + " (*" + this.mainSettings.saveStructureIndex.inventory_file_ext + ")|*" + this.mainSettings.saveStructureIndex.inventory_file_ext, this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed))
        return;
      int num = (int) MessageBox.Show("The inventory file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void btnInventoryImportAll_Click(object sender, EventArgs e)
    {
      if (this.loadFileIntoBuffer(this.mainSettings.saveStructureIndex.inventory_slots_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index, this.mainSettings.saveStructureIndex.inventory_file_name + " (*" + this.mainSettings.saveStructureIndex.inventory_file_ext + ")|*" + this.mainSettings.saveStructureIndex.inventory_file_ext, pspo2seForm.partFileType.inventory, true) <= 0)
        return;
      this.reloadEverything();
      int num = (int) MessageBox.Show("The inventory file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void btnStorageImportAll_Click(object sender, EventArgs e)
    {
      if (this.loadFileIntoBuffer(this.mainSettings.saveStructureIndex.shared_inventory_pos, this.mainSettings.saveStructureIndex.storage_file_name + " (*" + this.mainSettings.saveStructureIndex.storage_file_ext + ")|*" + this.mainSettings.saveStructureIndex.storage_file_ext, pspo2seForm.partFileType.storage, false) <= 0)
        return;
      this.reloadEverything();
      int num = (int) MessageBox.Show("The storage file was imported successfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      int num = (int) MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void txtStorageHex_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(this.txtStorageHex.Text.Substring(2, 8));
      int num = (int) MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) => this.checkDatabaseUpdate(true);

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Environment.Exit(0);

    private void updateToolStripMenuItem_Click(object sender, EventArgs e) => this.checkAppUpdate(true);

    private void versionInfoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string str = !this.legitVersion() ? "PSPo2 Save Editor" : "PSPo2 Save Viewer";
      if (!this.databasesOk)
      {
        int num1 = (int) MessageBox.Show("You are currently running " + str + " v3.0 build 1008\r\n\r\nThe databases are not installed correctly.\r\nPlease update them before you can view more information.", "Version Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this.changelogForm.formSetup();
        int num2 = (int) this.changelogForm.ShowDialog((IWin32Window) this);
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("http://files-ds-scene.net/retrohead/pspo2se/");

    private void checkForUpdatesToolStripMenuItem1_Click(object sender, EventArgs e) => this.checkImagesUpdate(true);

    private void txtStorageMeseta_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      this.entryForm.oldVal = string.Concat((object) this.saveData.sharedMeseta);
      this.entryForm.newVal = string.Concat((object) this.saveData.sharedMeseta);
      this.entryForm.description = "shared meseta";
      this.entryForm.maxLen = 8;
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
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
        int num2 = (int) MessageBox.Show("You must enter a value less than 99,999,999");
      }
    }

    private void btnStorageWithdraw_Click(object sender, EventArgs e)
    {
      if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.itemsUsed >= 60)
      {
        int num1 = (int) MessageBox.Show("The selected characters inventory is full", "Inventory Full", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
          int num2 = (int) MessageBox.Show("There was an error moving the item. Please re-load your save file and try again.", "Item Move Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
    }

    private void btnInventoryDeposit_Click(object sender, EventArgs e)
    {
      if (this.saveData.sharedInventory.itemsUsed >= this.mainSettings.saveStructureIndex.shared_inventory_slots)
      {
        int num1 = (int) MessageBox.Show("The shared storage is full", "Storage Full", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        int id = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)].id;
        if (!this.saveItemDataToFile(id, 20, "", "", Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext, true))
        {
          int num2 = (int) MessageBox.Show("Could not write the temporary file: \n\n" + Directory.GetCurrentDirectory() + "\\data\\temp\\moving." + this.mainSettings.saveStructureIndex.item_file_ext, "Failed to deposit item!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            int num3 = (int) MessageBox.Show("There was an error moving the item. Please re-load your save file and try again.", "Item Move Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
      this.entryForm.oldVal = string.Concat((object) (inventoryItemClass.pa_level + 1));
      this.entryForm.newVal = string.Concat((object) (inventoryItemClass.pa_level + 1));
      this.entryForm.description = "PA disk level";
      this.entryForm.maxLen = 2;
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      string newVal = this.entryForm.newVal;
      if (!(newVal != (inventoryItemClass.pa_level + 1).ToString()))
        return;
      if (int.Parse(newVal) > 30)
      {
        int num1 = (int) MessageBox.Show("You must enter a value lower or equal to 30.");
      }
      else if (int.Parse(newVal) < 1)
      {
        int num2 = (int) MessageBox.Show("You must enter a value greater than 0.");
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
        if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
          return;
        string newVal = this.entryForm.newVal;
        if (!(newVal != inventoryItemClass.qty.ToString()))
          return;
        if (int.Parse(newVal) > inventoryItemClass.qty_max)
        {
          int num1 = (int) MessageBox.Show("You must enter a value lower or equal to the max stack qty for this item.");
        }
        else if (int.Parse(newVal) < 1)
        {
          int num2 = (int) MessageBox.Show("You must enter a value greater than 0.");
        }
        else
        {
          string hex = int.Parse(newVal).ToString("X2");
          while (hex.Length < 4)
            hex = "0" + hex;
          this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 4), inventoryItemClass.id + 4);
          inventoryItemClass.qty = int.Parse(newVal);
          if (page == this.tabPageStorage)
            this.txtStorageQty.Text = inventoryItemClass.qty.ToString() + "/" + (object) inventoryItemClass.qty_max;
          else
            this.txtInventoryQty.Text = inventoryItemClass.qty.ToString() + "/" + (object) inventoryItemClass.qty_max;
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
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      string newVal = this.entryForm.newVal;
      if (!(newVal != inventoryItemClass.percent.ToString()))
        return;
      if (int.Parse(newVal) > 100)
      {
        int num1 = (int) MessageBox.Show("You must enter a value lower or equal to 100.");
      }
      else if (int.Parse(newVal) < 0)
      {
        int num2 = (int) MessageBox.Show("You must enter a value greater or equal to 0.");
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
      this.entryForm.newVal = ((int) inventoryItemClass.element).ToString();
      this.entryForm.description = "element";
      this.entryForm.maxLen = 1;
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      string newVal = this.entryForm.newVal;
      if (!(newVal != ((int) inventoryItemClass.element).ToString()))
        return;
      if (int.Parse(newVal) >= 7)
      {
        int num1 = (int) MessageBox.Show("You must enter a value lower than " + (object) pspo2seForm.elementType.COUNT + ".");
      }
      else if (int.Parse(newVal) < 0)
      {
        int num2 = (int) MessageBox.Show("You must enter a value greater or equal to 0.");
      }
      else
      {
        string hex = int.Parse(newVal).ToString("X1");
        while (hex.Length < 2)
          hex = "0" + hex;
        this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), inventoryItemClass.id + 16);
        inventoryItemClass.element = (pspo2seForm.elementType) int.Parse(newVal);
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
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
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
        int num2 = (int) MessageBox.Show("You must enter a value less than 99,999,999");
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
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      string newVal = this.entryForm.newVal;
      if (!(newVal != inventoryItemClass.power_add.ToString()))
        return;
      if (int.Parse(newVal) > 9999)
      {
        int num1 = (int) MessageBox.Show("You must enter a value lower or equal to 9999.");
      }
      else if (int.Parse(newVal) < 1)
      {
        int num2 = (int) MessageBox.Show("You must enter a value greater than 0.");
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
        int num1 = (int) MessageBox.Show("You are already skipping the starting sequence to Episode 1", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (MessageBox.Show("Are you sure you want to skip the starting sequence to Episode 1?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
          return;
        int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
        this.overwriteHexInBuffer("90AB1E", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 5460 : num2 + 4648);
        this.txtSkipEp1Start.Text = "Yes";
        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].skip_ep_1_start = true;
        int num3 = (int) MessageBox.Show("The Episode 1 start sequence was skipped successfully.\n\nYou will need to play the first mission to progress the story.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtSkipEp2Start_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      if (this.txtSkipEp2Start.Text == "Yes")
      {
        int num1 = (int) MessageBox.Show("You are already skipping the starting sequence to Episode 2", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (MessageBox.Show("Are you sure you want to skip the starting sequence to Episode 2?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
          return;
        this.overwriteHexInBuffer("78AF1E", this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 4684);
        this.txtSkipEp2Start.Text = "Yes";
        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].skip_ep_2_start = true;
        int num2 = (int) MessageBox.Show("The Episode 2 start sequence was skipped successfully.\n\nGo to the Little Wing Office to progress the story further.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtMissionEp1_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      if (this.txtMissionEp1.Text == "Yes")
      {
        int num1 = (int) MessageBox.Show("You have already unlocked all of the Episode 1 Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (MessageBox.Show("Are you sure you want unlock all of the Episode 1 Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
          return;
        int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
        this.overwriteHexInBuffer("204E", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3436 : num2 + 3512);
        this.txtMissionEp1.Text = "Yes";
        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_ep1 = true;
        int num3 = (int) MessageBox.Show("The Episode 1 Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtMissionUnknown_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      if (this.txtMissionTactical.Text == "Yes")
      {
        int num1 = (int) MessageBox.Show("You have already unlocked all of the Unknown Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (MessageBox.Show("Are you sure you want unlock all of the Unknown Missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
          return;
        int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
        this.overwriteHexInBuffer("204E", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3488 : num2 + 3564);
        this.txtMissionTactical.Text = "Yes";
        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_unknown = true;
        int num3 = (int) MessageBox.Show("The Unknown Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtMissionEp2_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      if (this.txtMissionEp2.Text == "Yes")
      {
        int num1 = (int) MessageBox.Show("You have already unlocked all of the Episode 2 Missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
          int num2 = (int) MessageBox.Show("This feature is for Infinity only");
        }
        this.overwriteHexInBuffer("204E", pos);
        this.txtMissionEp2.Text = "Yes";
        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_unknown = true;
        int num3 = (int) MessageBox.Show("The Episode 2 Missions were unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void missionStatus_TextChanged(object sender, EventArgs e)
    {
      if (((Control) sender).Text == "Yes")
        ((Control) sender).ForeColor = Color.DarkGreen;
      else
        ((Control) sender).ForeColor = Color.DarkRed;
    }

    private void txtMissionMagashi_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      if (this.txtMissionMagashi.Text == "Yes")
      {
        int num1 = (int) MessageBox.Show("You have already unlocked Magashi Plan.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (MessageBox.Show("Are you sure you want unlock Magashi Plan?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
          return;
        int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
        this.overwriteHexInBuffer("1F", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 3182 : num2 + 3242);
        this.txtMissionMagashi.Text = "Yes";
        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].mission_unlock_magashi = true;
        int num3 = (int) MessageBox.Show("The Magashi Plan mission was unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtCharacterName_Click(object sender, EventArgs e)
    {
      this.entryForm.oldVal = this.txtCharacterName.Text;
      this.entryForm.newVal = this.txtCharacterName.Text;
      this.entryForm.description = "character name";
      this.entryForm.maxLen = 32;
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
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
      int num = (int) MessageBox.Show("Copied to clipboard", "Clipboard Action", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void txtTitle_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      this.entryForm.oldVal = this.txtTitle.Text;
      this.entryForm.newVal = this.txtTitle.Text;
      this.entryForm.description = "title";
      this.entryForm.maxLen = 25;
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
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
      this.entryForm.newVal = ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type).ToString();
      this.entryForm.description = "type";
      this.entryForm.maxLen = 1;
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      string newVal = this.entryForm.newVal;
      if (!(newVal != ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type).ToString()))
        return;
      string hex = int.Parse(newVal).ToString("X1");
      while (hex.Length < 2)
        hex = "0" + hex;
      this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 130);
      this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type = (pspo2seForm.jobType) int.Parse(newVal);
      this.txtCurType.Text = string.Concat((object) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].cur_type);
      this.lstSaveSlotView.SelectedItems[0].SubItems[3].Text = this.txtCurType.Text;
    }

    private void txtClass_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race.ToString();
      this.entryForm.newVal = ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race).ToString();
      this.entryForm.description = "class";
      this.entryForm.maxLen = 1;
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      string newVal = this.entryForm.newVal;
      if (!(newVal != ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race).ToString()))
        return;
      string hex = int.Parse(newVal).ToString("X1");
      while (hex.Length < 2)
        hex = "0" + hex;
      this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 128);
      this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race = (pspo2seForm.raceTypes) int.Parse(newVal);
      this.txtRace.Text = string.Concat((object) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].race);
      this.lstSaveSlotView.SelectedItems[0].SubItems[2].Text = this.txtRace.Text;
    }

    private void txtSex_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      this.entryForm.oldVal = this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex.ToString();
      this.entryForm.newVal = ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex).ToString();
      this.entryForm.description = "sex";
      this.entryForm.maxLen = 1;
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      string newVal = this.entryForm.newVal;
      if (!(newVal != ((int) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex).ToString()))
        return;
      string hex = int.Parse(newVal).ToString("X1");
      while (hex.Length < 2)
        hex = "0" + hex;
      this.overwriteHexInBuffer(this.run.hexAndMathFunction.reversehex(hex, 2), this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index + 129);
      this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex = (pspo2seForm.sexType) int.Parse(newVal);
      this.txtSex.Text = string.Concat((object) this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].sex);
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
      int* numPtr1 = (int*) null;
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
      if (this.lstSaveSlotView.SelectedItems[0].Index < 0 || ((NumericUpDown) sender).Value > 10M || ((NumericUpDown) sender).Value < 0M)
        return;
      string str = ((Control) sender).Name.Replace("numRebirth", "");
      int* rebirthStatPointer = this.getRebirthStatPointer(str);
      int num1 = *rebirthStatPointer;
      int rebirthValuePtsUsed = this.getRebirthValuePtsUsed(this.lstSaveSlotView.SelectedItems[0].Index, *rebirthStatPointer, str);
      *rebirthStatPointer = (int) ((NumericUpDown) sender).Value;
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
          int num3 = (int) MessageBox.Show("You need " + (object) -this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.remaining_points + " more points to add to this stat.\n\nYou will need to rebirth to gain more BP.", "Not Enough BP", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ((NumericUpDown) sender).Value = (Decimal) (*rebirthStatPointer - 1);
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
          int num = (int) MessageBox.Show("The characters inventory is full, please deposit an item before rebirthing so you can claim the extend codes", "Inventory Full", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
      if (this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].rebirth.count < (int) ushort.MaxValue)
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
      int num3 = (int) MessageBox.Show("The rebirth completed successfully.\n\nIf you selected to claim extend codes, they will be in the characters inventory.", "Rebirth Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void chkRebirthSpoof_CheckedChanged(object sender, EventArgs e) => this.listRebirthRewards(this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].level, this.lstSaveSlotView.SelectedItems[0].Index);

    private void weaponDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.weaponDatabaseForm.initForm();
      this.weaponDatabaseForm.Show((IWin32Window) this);
    }

    private void txtEp1Complete_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      if (this.txtEp1Complete.Text == "Yes")
      {
        int num1 = (int) MessageBox.Show("You have already completed Episode 1.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        int num3 = (int) MessageBox.Show("Episode 1 was completed successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtEp2Complete_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      if (this.txtEp2Complete.Text == "Yes")
      {
        int num1 = (int) MessageBox.Show("You have already completed Episode 2.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        int num3 = (int) MessageBox.Show("Episode 2 was completed successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        this.txtInfMisBoss.Text = "Boss  " + this.intToInfinityBoss(infinityMissionClass.boss - 1)[1] + " (" + this.intToInfinityBoss(infinityMissionClass.boss - 1)[0] + ") [" + (object) infinityMissionClass.length + "]";
        this.txtInfMisEnemy1.Text = "Main Enemy  " + this.intToInfinityEnemy(infinityMissionClass.enemy_1)[1] + " (" + this.intToInfinityEnemy(infinityMissionClass.enemy_1)[0] + ") [" + (object) infinityMissionClass.unk_enemy_1_mod + "]";
        this.txtInfMisEnemy2.Text = "Sub Enemy  " + this.intToInfinityEnemy(infinityMissionClass.enemy_2)[1] + " (" + this.intToInfinityEnemy(infinityMissionClass.enemy_2)[0] + ")";
        this.txtInfEnemyLevel.Text = "Enemy Level  +" + (object) infinityMissionClass.enemy_level + " [" + (object) infinityMissionClass.unk_enemy_level_mod + "]";
        this.txtInfMisSpecial.Text = "Special Effects  " + infinityMissionClass.hex.Substring(12, 20);
        this.txtInfMisCreatedBy.Text = "Created By  " + infinityMissionClass.createdBy;
        this.txtInfMisSynthPoint.Text = "Synthesis Points  " + (object) infinityMissionClass.mergePoints;
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
        int num1 = (int) MessageBox.Show("The mission file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num2 = (int) MessageBox.Show("The mission file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
          int num = (int) MessageBox.Show("You must select a mission from your list to overwrite.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
          int num = (int) MessageBox.Show("You must select a mission from your list to overwrite.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        int num1 = (int) MessageBox.Show("You must select a mission from your list to modify.", "Modify Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.infinityMissionForm.id = int.Parse(this.lstInfinityMissions.SelectedItems[0].Tag.ToString());
        int num2 = (int) this.infinityMissionForm.ShowDialog((IWin32Window) this);
      }
    }

    private void changeItemSpecial(TabPage page)
    {
      if (this.legitVersion())
        return;
      pspo2seForm.inventoryItemClass inventoryItemClass = page != this.tabPageStorage ? this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].inventory.item[int.Parse(this.inventoryView.SelectedItems[0].SubItems[1].Text)] : this.saveData.sharedInventory.item[int.Parse(this.storageView.SelectedItems[0].SubItems[1].Text)];
      this.entryForm.newVal = ((int) inventoryItemClass.ability).ToString();
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
      if (this.entryForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      string newVal = this.entryForm.newVal;
      if (!(newVal != ((int) inventoryItemClass.ability).ToString()))
        return;
      if (int.Parse(newVal) >= 21 || inventoryItemClass.style == pspo2seForm.weaponStyleType.Tech && int.Parse(newVal) >= 8)
      {
        int num1 = (int) MessageBox.Show("You must enter a value lower than " + (object) 8 + " for TEC weapons and " + (object) 10 + " for all others.");
      }
      else if (int.Parse(newVal) < 0)
      {
        int num2 = (int) MessageBox.Show("You must enter a value greater or equal to 0.");
      }
      else
      {
        string hex = int.Parse(newVal).ToString("X1");
        while (hex.Length < 2)
          hex = "0" + hex;
        this.overwriteHexInBuffer(hex, inventoryItemClass.id + 8);
        inventoryItemClass.ability = (pspo2seForm.abilityType) int.Parse(newVal);
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
        int num1 = (int) MessageBox.Show("The mission pack file was exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num2 = (int) MessageBox.Show("The mission pack file failed to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void txtAllowQuitMission_Click(object sender, EventArgs e)
    {
      if (this.legitVersion())
        return;
      if (this.txtAllowQuitMission.Text == "Yes")
      {
        int num1 = (int) MessageBox.Show("You can already quit missions.", "Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (MessageBox.Show("Are you sure you want enable quiting missions?", "Confirm Unlock", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
          return;
        int num2 = this.mainSettings.saveStructureIndex.header_size + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index;
        this.overwriteHexInBuffer("FF", this.saveData.type != pspo2seForm.SaveType.PSP2I ? num2 + 4441 : num2 + 4517);
        this.txtAllowQuitMission.Text = "Yes";
        this.saveData.slot[this.lstSaveSlotView.SelectedItems[0].Index].allow_quit_missions = "FF";
        int num3 = (int) MessageBox.Show("The quit mission function was unlocked successfully.", "Unlock Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void showGameImage()
    {
      switch (this.saveData.type)
      {
        case pspo2seForm.SaveType.PSP2:
          this.imgSave.Image = (Image) Resources.PSP2;
          this.imgGameLogo.Image = (Image) Resources.PSP2_logo;
          this.imgSave.Show();
          break;
        case pspo2seForm.SaveType.PSP2I:
          this.imgSave.Image = (Image) Resources.PSP2i;
          this.imgGameLogo.Image = (Image) Resources.PSP2i_logo;
          this.imgSave.Show();
          break;
        default:
          this.imgGameLogo.Image = (Image) Resources.PSP2_logo;
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
        this.txtSlotnumloaded.Text = "Save Slot #" + (object) (slotnum + 1) + " Loaded";
      else
        this.txtSlotnumloaded.Text = "No Save Slot Loaded";
      this.txtCharacterName.Text = this.saveData.slot[slotnum].name;
      this.txtTitle.Text = this.saveData.slot[slotnum].title;
      this.txtPlaytime.Text = this.saveData.slot[slotnum].playtime;
      this.txtCurType.Text = string.Concat((object) this.saveData.slot[slotnum].cur_type);
      this.txtRace.Text = string.Concat((object) this.saveData.slot[slotnum].race);
      this.txtSex.Text = string.Concat((object) this.saveData.slot[slotnum].sex);
      this.txtLevel.Text = string.Concat((object) this.saveData.slot[slotnum].level);
      this.txtExp.Text = string.Concat((object) this.saveData.slot[slotnum].exp);
      this.txtExpNext.Text = string.Concat((object) this.saveData.slot[slotnum].exp_next);
      this.txtLevelExpBar.Width = this.saveData.slot[slotnum].exp_percent * 2;
      this.txtInventoryMeseta.Text = string.Concat((object) this.saveData.slot[slotnum].meseta);
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
        this.addRebirthReward("Next Rebirth in " + (object) (50 - level) + " Levels.", Color.DarkGray);
        this.btnRebirth.Enabled = false;
        this.comboRebirthExtend.Enabled = false;
      }
      else
      {
        this.btnRebirth.Enabled = true;
        this.comboRebirthExtend.Enabled = true;
        int num1 = 0;
        this.comboRebirthExtend.Items.Add((object) ("Claim " + (object) this.getRebirthNowPointGain(level) + " bonus points and 0 extend codes."));
        for (int index = 0; index < this.saveData.slot[slot].rebirth.remaining_points + this.getRebirthNowPointGain(level); index += 5)
        {
          ++num1;
          if (num1 == 1)
            this.comboRebirthExtend.Items.Add((object) ("Claim " + (object) (this.getRebirthNowPointGain(level) - 5 * num1) + " bonus points and " + (object) num1 + " extend code."));
          else
            this.comboRebirthExtend.Items.Add((object) ("Claim " + (object) (this.getRebirthNowPointGain(level) - 5 * num1) + " bonus points and " + (object) num1 + " extend codes."));
          if (num1 == 10)
            break;
        }
        this.comboRebirthExtend.SelectedIndex = 0;
        this.addRebirthReward("Up to " + (object) num1 + " extend codes.", Color.DarkGreen);
        this.addRebirthReward("Up to " + (object) this.getRebirthNowPointGain(level) + " bonus points.", Color.DarkGreen);
        if (30 + this.saveData.slot[slot].rebirth.additionalTypeLevels >= 50)
          return;
        int num2 = 30 + this.saveData.slot[slot].rebirth.additionalTypeLevels + this.getRebirthNowTypeLevelGain(level);
        if (num2 > 50)
          num2 = 50;
        this.addRebirthReward("Maximum type level " + (object) num2 + ".", Color.DarkGreen);
      }
    }

    private void displayTypePage(int slotnum, pspo2seForm.jobType i)
    {
      bool flag = false;
      if (this.saveData.slot[slotnum].job[(int) i].level >= 30 + this.saveData.slot[slotnum].rebirth.additionalTypeLevels)
        flag = true;
      if (flag)
      {
        this.saveData.slot[slotnum].job[(int) i].exp_to_next = 0;
        this.saveData.slot[slotnum].job[(int) i].exp_next = this.saveData.slot[slotnum].job[(int) i].exp;
        this.saveData.slot[slotnum].job[(int) i].exp_percent = 100;
      }
      else
      {
        pspo2seForm.expDb_ItemClass expDbItemClass = new pspo2seForm.expDb_ItemClass();
        pspo2seForm.expDb_ItemClass expTypeInfoInDb = this.findExpTypeInfoInDb(this.saveData.slot[slotnum].job[(int) i].level);
        if (expTypeInfoInDb == null)
        {
          int num = (int) MessageBox.Show("could not find typeexp for type level " + (object) this.saveData.slot[slotnum].job[(int) i].level);
        }
        this.saveData.slot[slotnum].job[(int) i].exp_to_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next - this.saveData.slot[slotnum].job[(int) i].exp;
        this.saveData.slot[slotnum].job[(int) i].exp_next = expTypeInfoInDb.exp + expTypeInfoInDb.exp_next;
        this.saveData.slot[slotnum].job[(int) i].exp_percent = expTypeInfoInDb.exp_next != 0 ? this.run.hexAndMathFunction.getPercentage(this.saveData.slot[slotnum].job[(int) i].exp - expTypeInfoInDb.exp, expTypeInfoInDb.exp_next) : 100;
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
          int num1 = (int) MessageBox.Show("jobType " + (object) i + " not handled in displayTypePage", "Fatal Error!");
          break;
      }
      string str = page.Name.Replace("tabPage", "");
      pspo2seForm.typeSectionFields typeSectionFields2 = this.getTypeSectionFields(page);
      page.Text = str + " (" + (object) this.saveData.slot[slotnum].job[(int) i].level + ")";
      typeSectionFields2.txtLevel.Text = string.Concat((object) this.saveData.slot[slotnum].job[(int) i].level);
      typeSectionFields2.grpExtend.Text = "Type Extend " + (object) this.saveData.slot[slotnum].job[(int) i].extendpointsused + "/" + (object) this.saveData.slot[slotnum].job[(int) i].extendpoints;
      typeSectionFields2.txtExp.Text = "Next " + (object) this.saveData.slot[slotnum].job[(int) i].exp_to_next;
      typeSectionFields2.expBar.Width = this.saveData.slot[slotnum].job[(int) i].exp_percent;
      this.showTypeWeaponExtendImages(this.saveData.slot[slotnum].job[(int) i], page);
    }

    private void displayTypeInfo(int slotnum)
    {
      for (int index = 0; index < 4; ++index)
        this.displayTypePage(slotnum, (pspo2seForm.jobType) index);
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
            weaponExtendFields.imgRank[index].Image = (Image) Resources.rank_C;
            break;
          case pspo2seForm.extendRankType.b:
            weaponExtendFields.imgWeap[index].Visible = true;
            weaponExtendFields.imgRank[index].Visible = true;
            weaponExtendFields.imgRank[index].Image = (Image) Resources.rank_B;
            break;
          case pspo2seForm.extendRankType.a:
            weaponExtendFields.imgWeap[index].Visible = true;
            weaponExtendFields.imgRank[index].Visible = true;
            weaponExtendFields.imgRank[index].Image = (Image) Resources.rank_A;
            break;
          case pspo2seForm.extendRankType.s:
            weaponExtendFields.imgWeap[index].Visible = true;
            weaponExtendFields.imgRank[index].Visible = true;
            weaponExtendFields.imgRank[index].Image = (Image) Resources.rank_S;
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
        listViewItem1.Tag = (object) this.saveData.infinityMissions.slot[index].id;
        listViewItem1.SubItems.Add("LV" + (object) this.saveData.infinityMissions.slot[index].level);
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
      statTextBox.Text = "+" + (object) num2;
      bpTextBox.Text = string.Concat((object) num1);
      if (statVal >= 10)
        nextTextBox.Text = "max";
      else
        nextTextBox.Text = "+" + (object) num3 + "pt";
      nextTextBox.ForeColor = Color.DarkGreen;
      if (num3 > this.saveData.slot[slot].rebirth.remaining_points || statVal >= 10)
        nextTextBox.ForeColor = Color.DarkRed;
      numBox.Value = (Decimal) statVal;
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
        this.txtRebirthPoints.Text = "BP " + this.saveData.slot[slot].rebirth.remaining_points.ToString() + "/" + (object) num;
        this.txtRebirthMaxType.Text = string.Concat((object) (30 + this.saveData.slot[slot].rebirth.additionalTypeLevels));
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
      ArrayList arrayList = ArrayList.Adapter((IList) this.saveData.slot[slot].pa.items);
      arrayList.Sort();
      this.saveData.slot[slot].pa.items = (pspo2seForm.inventoryItemClass[]) arrayList.ToArray(typeof (pspo2seForm.inventoryItemClass));
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
          listViewItem.Tag = (object) index.ToString();
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
      int num = (int) MessageBox.Show("The character file appears to be incorrect", "File Error");
      return false;
    }

    private void refreshFromBuffer()
    {
      if (this.reloadSaveFile())
        return;
      int num = (int) MessageBox.Show("There was an error reloading the save data from the buffer");
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
        int num = (int) MessageBox.Show("Invalid file detected [" + this.txtFileSize.Text + "]", "File Error");
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
      this.lstSaveSlotView.SelectedItems[0].SubItems[1].Text = "LV" + (object) expLevelInfoInDb.level;
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
        if (this.entryForm.ShowDialog((IWin32Window) this) == DialogResult.OK)
        {
          int newvalue = int.Parse(this.entryForm.newVal);
          if (newvalue > 200)
          {
            int num1 = (int) MessageBox.Show("Level 200+ is not allowed\r\nThat's just stupid right?");
          }
          else if (newvalue < 1)
          {
            int num2 = (int) MessageBox.Show("Level 1 is the lowest");
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
        if (this.entryForm.ShowDialog((IWin32Window) this) == DialogResult.OK)
        {
          int level = int.Parse(this.entryForm.newVal);
          if (level > 30 + this.saveData.slot[index].rebirth.additionalTypeLevels)
          {
            int num1 = (int) MessageBox.Show("You cannot enter a level greater than " + (object) (30 + this.saveData.slot[index].rebirth.additionalTypeLevels) + ".\n\nYou will need to rebirth to increase your max type level.", "Max Level Reached", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          else if (level < 1)
          {
            int num2 = (int) MessageBox.Show("You must enter a level greater than 0.", "Type Level Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (pspo2seForm));
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
      this.SuspendLayout();
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog2.FileName = "openFileDialog2";
      this.openFileDialog3.FileName = "openFileDialog3";
      this.tabArea.Controls.Add((Control) this.tabPageInfo);
      this.tabArea.Controls.Add((Control) this.tabTypeInfo);
      this.tabArea.Controls.Add((Control) this.tabPageInventory);
      this.tabArea.Controls.Add((Control) this.tabPageStorage);
      this.tabArea.Controls.Add((Control) this.tabPageMissions);
      this.tabArea.Controls.Add((Control) this.tabPagePA);
      this.tabArea.Controls.Add((Control) this.tabPageRebirth);
      this.tabArea.Cursor = Cursors.Default;
      this.tabArea.Enabled = false;
      this.tabArea.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tabArea.Location = new Point(4, 233);
      this.tabArea.Name = "tabArea";
      this.tabArea.SelectedIndex = 0;
      this.tabArea.Size = new Size(637, 249);
      this.tabArea.TabIndex = 18;
      this.tabArea.SelectedIndexChanged += new EventHandler(this.tabArea_SelectedIndexChanged);
      this.tabPageInfo.BackColor = SystemColors.Window;
      this.tabPageInfo.BackgroundImageLayout = ImageLayout.Center;
      this.tabPageInfo.Controls.Add((Control) this.groupBox5);
      this.tabPageInfo.Controls.Add((Control) this.groupBox7);
      this.tabPageInfo.Controls.Add((Control) this.groupBox4);
      this.tabPageInfo.Controls.Add((Control) this.groupBox3);
      this.tabPageInfo.Cursor = Cursors.Default;
      this.tabPageInfo.ForeColor = Color.Black;
      this.tabPageInfo.Location = new Point(4, 22);
      this.tabPageInfo.Name = "tabPageInfo";
      this.tabPageInfo.Padding = new Padding(3);
      this.tabPageInfo.Size = new Size(629, 223);
      this.tabPageInfo.TabIndex = 0;
      this.tabPageInfo.Text = "General";
      this.groupBox5.Controls.Add((Control) this.txtStoryTrueEnd);
      this.groupBox5.Controls.Add((Control) this.txtStoryComplete);
      this.groupBox5.ForeColor = Color.White;
      this.groupBox5.Location = new Point(258, 3);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(360, 71);
      this.groupBox5.TabIndex = 73;
      this.groupBox5.TabStop = false;
      this.txtStoryTrueEnd.AutoSize = true;
      this.txtStoryTrueEnd.BackColor = Color.Transparent;
      this.txtStoryTrueEnd.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtStoryTrueEnd.ForeColor = SystemColors.ActiveCaptionText;
      this.txtStoryTrueEnd.Location = new Point(15, 41);
      this.txtStoryTrueEnd.Name = "txtStoryTrueEnd";
      this.txtStoryTrueEnd.Size = new Size(131, 13);
      this.txtStoryTrueEnd.TabIndex = 75;
      this.txtStoryTrueEnd.Text = "True Ending Achieved";
      this.txtStoryTrueEnd.Visible = false;
      this.txtStoryComplete.AutoSize = true;
      this.txtStoryComplete.BackColor = Color.Transparent;
      this.txtStoryComplete.Font = new Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtStoryComplete.ForeColor = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.txtStoryComplete.Location = new Point(15, 19);
      this.txtStoryComplete.Name = "txtStoryComplete";
      this.txtStoryComplete.Size = new Size(111, 14);
      this.txtStoryComplete.TabIndex = 73;
      this.txtStoryComplete.Text = "Game Complete";
      this.txtStoryComplete.Visible = false;
      this.groupBox7.Controls.Add((Control) this.panel1);
      this.groupBox7.Location = new Point(258, 70);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new Size(109, 75);
      this.groupBox7.TabIndex = 81;
      this.groupBox7.TabStop = false;
      this.panel1.BackColor = Color.Black;
      this.panel1.Controls.Add((Control) this.picWeaponSlot01);
      this.panel1.Controls.Add((Control) this.picWeaponSlot06);
      this.panel1.Controls.Add((Control) this.picWeaponSlot02);
      this.panel1.Controls.Add((Control) this.picWeaponSlot05);
      this.panel1.Controls.Add((Control) this.picWeaponSlot03);
      this.panel1.Controls.Add((Control) this.picWeaponSlot04);
      this.panel1.Location = new Point(11, 20);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(89, 41);
      this.panel1.TabIndex = 80;
      this.picWeaponSlot01.BackColor = Color.Black;
      this.picWeaponSlot01.Location = new Point(7, 7);
      this.picWeaponSlot01.Name = "picWeaponSlot01";
      this.picWeaponSlot01.Size = new Size(23, 12);
      this.picWeaponSlot01.TabIndex = 74;
      this.picWeaponSlot01.TabStop = false;
      this.picWeaponSlot06.BackColor = Color.Black;
      this.picWeaponSlot06.Location = new Point(57, 21);
      this.picWeaponSlot06.Name = "picWeaponSlot06";
      this.picWeaponSlot06.Size = new Size(23, 12);
      this.picWeaponSlot06.TabIndex = 79;
      this.picWeaponSlot06.TabStop = false;
      this.picWeaponSlot02.BackColor = Color.Black;
      this.picWeaponSlot02.Location = new Point(32, 7);
      this.picWeaponSlot02.Name = "picWeaponSlot02";
      this.picWeaponSlot02.Size = new Size(23, 12);
      this.picWeaponSlot02.TabIndex = 75;
      this.picWeaponSlot02.TabStop = false;
      this.picWeaponSlot05.BackColor = Color.Black;
      this.picWeaponSlot05.Location = new Point(32, 21);
      this.picWeaponSlot05.Name = "picWeaponSlot05";
      this.picWeaponSlot05.Size = new Size(23, 12);
      this.picWeaponSlot05.TabIndex = 78;
      this.picWeaponSlot05.TabStop = false;
      this.picWeaponSlot03.BackColor = Color.Black;
      this.picWeaponSlot03.Location = new Point(57, 7);
      this.picWeaponSlot03.Name = "picWeaponSlot03";
      this.picWeaponSlot03.Size = new Size(23, 12);
      this.picWeaponSlot03.TabIndex = 76;
      this.picWeaponSlot03.TabStop = false;
      this.picWeaponSlot04.BackColor = Color.Black;
      this.picWeaponSlot04.Location = new Point(7, 21);
      this.picWeaponSlot04.Name = "picWeaponSlot04";
      this.picWeaponSlot04.Size = new Size(23, 12);
      this.picWeaponSlot04.TabIndex = 77;
      this.picWeaponSlot04.TabStop = false;
      this.groupBox4.Controls.Add((Control) this.txtCharacterName);
      this.groupBox4.Controls.Add((Control) this.lblLevel);
      this.groupBox4.Controls.Add((Control) this.txtLevel);
      this.groupBox4.Controls.Add((Control) this.txtLevelExpBar);
      this.groupBox4.Controls.Add((Control) this.label11);
      this.groupBox4.Location = new Point(9, 3);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(243, 71);
      this.groupBox4.TabIndex = 67;
      this.groupBox4.TabStop = false;
      this.txtCharacterName.BackColor = Color.Transparent;
      this.txtCharacterName.Cursor = Cursors.Hand;
      this.txtCharacterName.Font = new Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.txtCharacterName.ForeColor = SystemColors.ActiveCaptionText;
      this.txtCharacterName.Location = new Point(14, 17);
      this.txtCharacterName.Name = "txtCharacterName";
      this.txtCharacterName.Size = new Size(223, 16);
      this.txtCharacterName.TabIndex = 18;
      this.txtCharacterName.Text = "No Save File Loaded";
      this.txtCharacterName.Click += new EventHandler(this.txtCharacterName_Click);
      this.lblLevel.AutoSize = true;
      this.lblLevel.BackColor = Color.Transparent;
      this.lblLevel.Cursor = Cursors.Hand;
      this.lblLevel.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblLevel.ForeColor = SystemColors.ActiveCaptionText;
      this.lblLevel.Location = new Point(14, 32);
      this.lblLevel.Name = "lblLevel";
      this.lblLevel.Size = new Size(40, 14);
      this.lblLevel.TabIndex = 20;
      this.lblLevel.Text = "Level";
      this.lblLevel.Click += new EventHandler(this.txtLevel_Click);
      this.txtLevel.BackColor = Color.Transparent;
      this.txtLevel.Cursor = Cursors.Hand;
      this.txtLevel.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtLevel.ForeColor = SystemColors.ActiveCaptionText;
      this.txtLevel.Location = new Point(52, 32);
      this.txtLevel.Name = "txtLevel";
      this.txtLevel.Size = new Size(60, 14);
      this.txtLevel.TabIndex = 21;
      this.txtLevel.Text = "0";
      this.txtLevel.Click += new EventHandler(this.txtLevel_Click);
      this.txtLevelExpBar.BackColor = Color.FromArgb(187, 104, 184);
      this.txtLevelExpBar.Location = new Point(19, 59);
      this.txtLevelExpBar.Name = "txtLevelExpBar";
      this.txtLevelExpBar.Size = new Size(0, 4);
      this.txtLevelExpBar.TabIndex = 38;
      this.label11.BackColor = SystemColors.Control;
      this.label11.BorderStyle = BorderStyle.FixedSingle;
      this.label11.Location = new Point(18, 58);
      this.label11.Name = "label11";
      this.label11.Size = new Size(202, 6);
      this.label11.TabIndex = 41;
      this.groupBox3.Controls.Add((Control) this.txtExpNext);
      this.groupBox3.Controls.Add((Control) this.label9);
      this.groupBox3.Controls.Add((Control) this.txtExp);
      this.groupBox3.Controls.Add((Control) this.txtSex);
      this.groupBox3.Controls.Add((Control) this.label21);
      this.groupBox3.Controls.Add((Control) this.lblSex);
      this.groupBox3.Controls.Add((Control) this.txtRace);
      this.groupBox3.Controls.Add((Control) this.lblClass);
      this.groupBox3.Controls.Add((Control) this.lblTitle);
      this.groupBox3.Controls.Add((Control) this.txtTitle);
      this.groupBox3.Controls.Add((Control) this.label7);
      this.groupBox3.Controls.Add((Control) this.lblType);
      this.groupBox3.Controls.Add((Control) this.txtCurType);
      this.groupBox3.Controls.Add((Control) this.txtPlaytime);
      this.groupBox3.Location = new Point(9, 70);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(243, 143);
      this.groupBox3.TabIndex = 50;
      this.groupBox3.TabStop = false;
      this.txtExpNext.AutoSize = true;
      this.txtExpNext.BackColor = Color.Transparent;
      this.txtExpNext.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtExpNext.ForeColor = SystemColors.ActiveCaptionText;
      this.txtExpNext.Location = new Point(86, 116);
      this.txtExpNext.Name = "txtExpNext";
      this.txtExpNext.Size = new Size(12, 13);
      this.txtExpNext.TabIndex = 66;
      this.txtExpNext.Text = "-";
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = SystemColors.ActiveCaptionText;
      this.label9.Location = new Point(2, 116);
      this.label9.Name = "label9";
      this.label9.Size = new Size(82, 14);
      this.label9.TabIndex = 65;
      this.label9.Text = "Exp To Next";
      this.label9.TextAlign = ContentAlignment.TopRight;
      this.txtExp.AutoSize = true;
      this.txtExp.BackColor = Color.Transparent;
      this.txtExp.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtExp.ForeColor = SystemColors.ActiveCaptionText;
      this.txtExp.Location = new Point(86, 102);
      this.txtExp.Name = "txtExp";
      this.txtExp.Size = new Size(12, 13);
      this.txtExp.TabIndex = 60;
      this.txtExp.Text = "-";
      this.txtSex.AutoSize = true;
      this.txtSex.BackColor = Color.Transparent;
      this.txtSex.Cursor = Cursors.Hand;
      this.txtSex.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSex.ForeColor = SystemColors.ActiveCaptionText;
      this.txtSex.Location = new Point(86, 80);
      this.txtSex.Name = "txtSex";
      this.txtSex.Size = new Size(12, 13);
      this.txtSex.TabIndex = 64;
      this.txtSex.Text = "-";
      this.txtSex.Click += new EventHandler(this.txtSex_Click);
      this.label21.BackColor = Color.Transparent;
      this.label21.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label21.ForeColor = SystemColors.ActiveCaptionText;
      this.label21.Location = new Point(23, 102);
      this.label21.Name = "label21";
      this.label21.Size = new Size(61, 14);
      this.label21.TabIndex = 59;
      this.label21.Text = "Total Exp";
      this.label21.TextAlign = ContentAlignment.TopRight;
      this.lblSex.AutoSize = true;
      this.lblSex.BackColor = Color.Transparent;
      this.lblSex.Cursor = Cursors.Hand;
      this.lblSex.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblSex.ForeColor = SystemColors.ActiveCaptionText;
      this.lblSex.Location = new Point(54, 80);
      this.lblSex.Name = "lblSex";
      this.lblSex.Size = new Size(29, 13);
      this.lblSex.TabIndex = 63;
      this.lblSex.Text = "Sex";
      this.lblSex.Click += new EventHandler(this.txtSex_Click);
      this.txtRace.AutoSize = true;
      this.txtRace.BackColor = Color.Transparent;
      this.txtRace.Cursor = Cursors.Hand;
      this.txtRace.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRace.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRace.Location = new Point(86, 66);
      this.txtRace.Name = "txtRace";
      this.txtRace.Size = new Size(12, 13);
      this.txtRace.TabIndex = 62;
      this.txtRace.Text = "-";
      this.txtRace.Click += new EventHandler(this.txtClass_Click);
      this.lblClass.AutoSize = true;
      this.lblClass.BackColor = Color.Transparent;
      this.lblClass.Cursor = Cursors.Hand;
      this.lblClass.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblClass.ForeColor = SystemColors.ActiveCaptionText;
      this.lblClass.Location = new Point(48, 66);
      this.lblClass.Name = "lblClass";
      this.lblClass.Size = new Size(35, 13);
      this.lblClass.TabIndex = 61;
      this.lblClass.Text = "Race";
      this.lblClass.Click += new EventHandler(this.txtClass_Click);
      this.lblTitle.AutoSize = true;
      this.lblTitle.BackColor = Color.Transparent;
      this.lblTitle.Cursor = Cursors.Hand;
      this.lblTitle.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTitle.ForeColor = SystemColors.ActiveCaptionText;
      this.lblTitle.Location = new Point(53, 38);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new Size(31, 13);
      this.lblTitle.TabIndex = 53;
      this.lblTitle.Text = "Title";
      this.lblTitle.Click += new EventHandler(this.txtTitle_Click);
      this.txtTitle.AutoSize = true;
      this.txtTitle.BackColor = Color.Transparent;
      this.txtTitle.Cursor = Cursors.Hand;
      this.txtTitle.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtTitle.ForeColor = SystemColors.ActiveCaptionText;
      this.txtTitle.Location = new Point(86, 38);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.Size = new Size(12, 13);
      this.txtTitle.TabIndex = 54;
      this.txtTitle.Text = "-";
      this.txtTitle.Click += new EventHandler(this.txtTitle_Click);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = SystemColors.ActiveCaptionText;
      this.label7.Location = new Point(21, 15);
      this.label7.Name = "label7";
      this.label7.Size = new Size(63, 13);
      this.label7.TabIndex = 55;
      this.label7.Text = "Play Time";
      this.lblType.AutoSize = true;
      this.lblType.BackColor = Color.Transparent;
      this.lblType.Cursor = Cursors.Hand;
      this.lblType.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblType.ForeColor = SystemColors.ActiveCaptionText;
      this.lblType.Location = new Point(45, 52);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(38, 13);
      this.lblType.TabIndex = 57;
      this.lblType.Text = "Class";
      this.lblType.Click += new EventHandler(this.txtCurType_Click);
      this.txtCurType.AutoSize = true;
      this.txtCurType.BackColor = Color.Transparent;
      this.txtCurType.Cursor = Cursors.Hand;
      this.txtCurType.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCurType.ForeColor = SystemColors.ActiveCaptionText;
      this.txtCurType.Location = new Point(86, 52);
      this.txtCurType.Name = "txtCurType";
      this.txtCurType.Size = new Size(12, 13);
      this.txtCurType.TabIndex = 58;
      this.txtCurType.Text = "-";
      this.txtCurType.Click += new EventHandler(this.txtCurType_Click);
      this.txtPlaytime.AutoSize = true;
      this.txtPlaytime.BackColor = Color.Transparent;
      this.txtPlaytime.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPlaytime.ForeColor = SystemColors.ActiveCaptionText;
      this.txtPlaytime.Location = new Point(86, 15);
      this.txtPlaytime.Name = "txtPlaytime";
      this.txtPlaytime.Size = new Size(59, 13);
      this.txtPlaytime.TabIndex = 56;
      this.txtPlaytime.Text = "00:00:00";
      this.tabTypeInfo.Controls.Add((Control) this.tabControlClasses);
      this.tabTypeInfo.Location = new Point(4, 22);
      this.tabTypeInfo.Name = "tabTypeInfo";
      this.tabTypeInfo.Padding = new Padding(3);
      this.tabTypeInfo.Size = new Size(629, 223);
      this.tabTypeInfo.TabIndex = 9;
      this.tabTypeInfo.Text = "Type";
      this.tabTypeInfo.UseVisualStyleBackColor = true;
      this.tabControlClasses.Controls.Add((Control) this.tabPageHunter);
      this.tabControlClasses.Controls.Add((Control) this.tabPageRanger);
      this.tabControlClasses.Controls.Add((Control) this.tabPageForce);
      this.tabControlClasses.Controls.Add((Control) this.tabPageVanguard);
      this.tabControlClasses.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tabControlClasses.Location = new Point(5, 3);
      this.tabControlClasses.Name = "tabControlClasses";
      this.tabControlClasses.SelectedIndex = 0;
      this.tabControlClasses.Size = new Size(618, 217);
      this.tabControlClasses.TabIndex = 0;
      this.tabPageHunter.Controls.Add((Control) this.btnHuAbilitiesOpen);
      this.tabPageHunter.Controls.Add((Control) this.label20);
      this.tabPageHunter.Controls.Add((Control) this.grpHuTypeExtend);
      this.tabPageHunter.Controls.Add((Control) this.lblHuLevel);
      this.tabPageHunter.Controls.Add((Control) this.txtHuLevel);
      this.tabPageHunter.Controls.Add((Control) this.label39);
      this.tabPageHunter.Font = new Font("Verdana", 8.25f);
      this.tabPageHunter.Location = new Point(4, 21);
      this.tabPageHunter.Name = "tabPageHunter";
      this.tabPageHunter.Padding = new Padding(3);
      this.tabPageHunter.Size = new Size(610, 192);
      this.tabPageHunter.TabIndex = 0;
      this.tabPageHunter.Text = "Hunter (0)";
      this.tabPageHunter.UseVisualStyleBackColor = true;
      this.btnHuAbilitiesOpen.Cursor = Cursors.Hand;
      this.btnHuAbilitiesOpen.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnHuAbilitiesOpen.Location = new Point(543, 8);
      this.btnHuAbilitiesOpen.Name = "btnHuAbilitiesOpen";
      this.btnHuAbilitiesOpen.Size = new Size(61, 21);
      this.btnHuAbilitiesOpen.TabIndex = 134;
      this.btnHuAbilitiesOpen.Text = "Abilities";
      this.btnHuAbilitiesOpen.UseVisualStyleBackColor = true;
      this.btnHuAbilitiesOpen.Click += new EventHandler(this.btnHuAbilitiesOpen_Click);
      this.label20.AutoSize = true;
      this.label20.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label20.Location = new Point(11, 13);
      this.label20.Name = "label20";
      this.label20.Size = new Size(58, 16);
      this.label20.TabIndex = 133;
      this.label20.Text = "Hunter";
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuTmagRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuMachinegunRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.txtHuExpBar);
      this.grpHuTypeExtend.Controls.Add((Control) this.txtHuExp);
      this.grpHuTypeExtend.Controls.Add((Control) this.label34);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuHandgunsRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.label36);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuShotgunRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuClawRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuDaggersRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSpearRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuWandRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuCardsRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuLaserRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuRifleRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuDaggerRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSabersRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuKnucklesRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuShieldRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuRmagRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuHandgunRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuLongbowRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuWhipRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuClawsRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuDblSaberRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuRodRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuCrossbowRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuGrenadeRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSlicerRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSaberRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuAxeRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSwordRank);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuRmag);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuMachinegun);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuCrossbow);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuCards);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuHandgun);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuHandguns);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuGrenade);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuLaser);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuLongbow);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuShotgun);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSlicer);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuRifle);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuWhip);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuClaw);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSaber);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuDagger);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuShield);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuTmag);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuRod);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuWand);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuClaws);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuDaggers);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuAxe);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSabers);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuDblSaber);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuKnuckles);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSpear);
      this.grpHuTypeExtend.Controls.Add((Control) this.imgHuSword);
      this.grpHuTypeExtend.Controls.Add((Control) this.pictureBox231);
      this.grpHuTypeExtend.Location = new Point(10, 58);
      this.grpHuTypeExtend.Name = "grpHuTypeExtend";
      this.grpHuTypeExtend.Size = new Size(304, 119);
      this.grpHuTypeExtend.TabIndex = 132;
      this.grpHuTypeExtend.TabStop = false;
      this.grpHuTypeExtend.Text = "Type Extend 0/0";
      this.imgHuTmagRank.Image = (Image) Resources.rank_C;
      this.imgHuTmagRank.Location = new Point(80, 95);
      this.imgHuTmagRank.Name = "imgHuTmagRank";
      this.imgHuTmagRank.Size = new Size(10, 10);
      this.imgHuTmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuTmagRank.TabIndex = 107;
      this.imgHuTmagRank.TabStop = false;
      this.imgHuMachinegunRank.Image = (Image) Resources.rank_C;
      this.imgHuMachinegunRank.Location = new Point(80, 83);
      this.imgHuMachinegunRank.Name = "imgHuMachinegunRank";
      this.imgHuMachinegunRank.Size = new Size(10, 10);
      this.imgHuMachinegunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuMachinegunRank.TabIndex = 106;
      this.imgHuMachinegunRank.TabStop = false;
      this.txtHuExpBar.BackColor = Color.Red;
      this.txtHuExpBar.Location = new Point(195, 23);
      this.txtHuExpBar.Name = "txtHuExpBar";
      this.txtHuExpBar.Size = new Size(87, 8);
      this.txtHuExpBar.TabIndex = 49;
      this.txtHuExp.BackColor = Color.Transparent;
      this.txtHuExp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtHuExp.Location = new Point(194, 36);
      this.txtHuExp.Name = "txtHuExp";
      this.txtHuExp.Size = new Size(102, 69);
      this.txtHuExp.TabIndex = 49;
      this.txtHuExp.TextAlign = ContentAlignment.TopRight;
      this.label34.AutoSize = true;
      this.label34.Location = new Point(159, 20);
      this.label34.Name = "label34";
      this.label34.Size = new Size(29, 13);
      this.label34.TabIndex = 48;
      this.label34.Text = "EXP";
      this.imgHuHandgunsRank.Image = (Image) Resources.rank_C;
      this.imgHuHandgunsRank.Location = new Point(80, 71);
      this.imgHuHandgunsRank.Name = "imgHuHandgunsRank";
      this.imgHuHandgunsRank.Size = new Size(10, 10);
      this.imgHuHandgunsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuHandgunsRank.TabIndex = 105;
      this.imgHuHandgunsRank.TabStop = false;
      this.label36.BackColor = Color.Gainsboro;
      this.label36.BorderStyle = BorderStyle.FixedSingle;
      this.label36.Location = new Point(194, 22);
      this.label36.Name = "label36";
      this.label36.Size = new Size(102, 10);
      this.label36.TabIndex = 50;
      this.imgHuShotgunRank.Image = (Image) Resources.rank_C;
      this.imgHuShotgunRank.Location = new Point(80, 59);
      this.imgHuShotgunRank.Name = "imgHuShotgunRank";
      this.imgHuShotgunRank.Size = new Size(10, 10);
      this.imgHuShotgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuShotgunRank.TabIndex = 104;
      this.imgHuShotgunRank.TabStop = false;
      this.imgHuClawRank.Image = (Image) Resources.rank_C;
      this.imgHuClawRank.Location = new Point(80, 47);
      this.imgHuClawRank.Name = "imgHuClawRank";
      this.imgHuClawRank.Size = new Size(10, 10);
      this.imgHuClawRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuClawRank.TabIndex = 103;
      this.imgHuClawRank.TabStop = false;
      this.imgHuDaggersRank.Image = (Image) Resources.rank_C;
      this.imgHuDaggersRank.Location = new Point(80, 35);
      this.imgHuDaggersRank.Name = "imgHuDaggersRank";
      this.imgHuDaggersRank.Size = new Size(10, 10);
      this.imgHuDaggersRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuDaggersRank.TabIndex = 102;
      this.imgHuDaggersRank.TabStop = false;
      this.imgHuSpearRank.Image = (Image) Resources.rank_C;
      this.imgHuSpearRank.Location = new Point(80, 23);
      this.imgHuSpearRank.Name = "imgHuSpearRank";
      this.imgHuSpearRank.Size = new Size(10, 10);
      this.imgHuSpearRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSpearRank.TabIndex = 101;
      this.imgHuSpearRank.TabStop = false;
      this.imgHuWandRank.Image = (Image) Resources.rank_B;
      this.imgHuWandRank.Location = new Point(44, 95);
      this.imgHuWandRank.Name = "imgHuWandRank";
      this.imgHuWandRank.Size = new Size(10, 10);
      this.imgHuWandRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuWandRank.TabIndex = 100;
      this.imgHuWandRank.TabStop = false;
      this.imgHuCardsRank.Image = (Image) Resources.rank_B;
      this.imgHuCardsRank.Location = new Point(44, 83);
      this.imgHuCardsRank.Name = "imgHuCardsRank";
      this.imgHuCardsRank.Size = new Size(10, 10);
      this.imgHuCardsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuCardsRank.TabIndex = 99;
      this.imgHuCardsRank.TabStop = false;
      this.imgHuLaserRank.Image = (Image) Resources.rank_B;
      this.imgHuLaserRank.Location = new Point(44, 71);
      this.imgHuLaserRank.Name = "imgHuLaserRank";
      this.imgHuLaserRank.Size = new Size(10, 10);
      this.imgHuLaserRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuLaserRank.TabIndex = 98;
      this.imgHuLaserRank.TabStop = false;
      this.imgHuRifleRank.Image = (Image) Resources.rank_B;
      this.imgHuRifleRank.Location = new Point(44, 59);
      this.imgHuRifleRank.Name = "imgHuRifleRank";
      this.imgHuRifleRank.Size = new Size(10, 10);
      this.imgHuRifleRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuRifleRank.TabIndex = 97;
      this.imgHuRifleRank.TabStop = false;
      this.imgHuDaggerRank.Image = (Image) Resources.rank_B;
      this.imgHuDaggerRank.Location = new Point(44, 47);
      this.imgHuDaggerRank.Name = "imgHuDaggerRank";
      this.imgHuDaggerRank.Size = new Size(10, 10);
      this.imgHuDaggerRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuDaggerRank.TabIndex = 96;
      this.imgHuDaggerRank.TabStop = false;
      this.imgHuSabersRank.Image = (Image) Resources.rank_B;
      this.imgHuSabersRank.Location = new Point(44, 35);
      this.imgHuSabersRank.Name = "imgHuSabersRank";
      this.imgHuSabersRank.Size = new Size(10, 10);
      this.imgHuSabersRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSabersRank.TabIndex = 95;
      this.imgHuSabersRank.TabStop = false;
      this.imgHuKnucklesRank.Image = (Image) Resources.rank_B;
      this.imgHuKnucklesRank.Location = new Point(44, 23);
      this.imgHuKnucklesRank.Name = "imgHuKnucklesRank";
      this.imgHuKnucklesRank.Size = new Size(10, 10);
      this.imgHuKnucklesRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuKnucklesRank.TabIndex = 94;
      this.imgHuKnucklesRank.TabStop = false;
      this.imgHuShieldRank.Image = (Image) Resources.rank_B;
      this.imgHuShieldRank.Location = new Point(116, 95);
      this.imgHuShieldRank.Name = "imgHuShieldRank";
      this.imgHuShieldRank.Size = new Size(10, 10);
      this.imgHuShieldRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuShieldRank.TabIndex = 93;
      this.imgHuShieldRank.TabStop = false;
      this.imgHuRmagRank.Image = (Image) Resources.rank_B;
      this.imgHuRmagRank.Location = new Point(116, 83);
      this.imgHuRmagRank.Name = "imgHuRmagRank";
      this.imgHuRmagRank.Size = new Size(10, 10);
      this.imgHuRmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuRmagRank.TabIndex = 92;
      this.imgHuRmagRank.TabStop = false;
      this.imgHuHandgunRank.Image = (Image) Resources.rank_B;
      this.imgHuHandgunRank.Location = new Point(116, 71);
      this.imgHuHandgunRank.Name = "imgHuHandgunRank";
      this.imgHuHandgunRank.Size = new Size(10, 10);
      this.imgHuHandgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuHandgunRank.TabIndex = 91;
      this.imgHuHandgunRank.TabStop = false;
      this.imgHuLongbowRank.Image = (Image) Resources.rank_B;
      this.imgHuLongbowRank.Location = new Point(116, 59);
      this.imgHuLongbowRank.Name = "imgHuLongbowRank";
      this.imgHuLongbowRank.Size = new Size(10, 10);
      this.imgHuLongbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuLongbowRank.TabIndex = 90;
      this.imgHuLongbowRank.TabStop = false;
      this.imgHuWhipRank.Image = (Image) Resources.rank_B;
      this.imgHuWhipRank.Location = new Point(116, 47);
      this.imgHuWhipRank.Name = "imgHuWhipRank";
      this.imgHuWhipRank.Size = new Size(10, 10);
      this.imgHuWhipRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuWhipRank.TabIndex = 89;
      this.imgHuWhipRank.TabStop = false;
      this.imgHuClawsRank.Image = (Image) Resources.rank_B;
      this.imgHuClawsRank.Location = new Point(116, 35);
      this.imgHuClawsRank.Name = "imgHuClawsRank";
      this.imgHuClawsRank.Size = new Size(10, 10);
      this.imgHuClawsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuClawsRank.TabIndex = 88;
      this.imgHuClawsRank.TabStop = false;
      this.imgHuDblSaberRank.Image = (Image) Resources.rank_B;
      this.imgHuDblSaberRank.Location = new Point(116, 23);
      this.imgHuDblSaberRank.Name = "imgHuDblSaberRank";
      this.imgHuDblSaberRank.Size = new Size(10, 10);
      this.imgHuDblSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuDblSaberRank.TabIndex = 87;
      this.imgHuDblSaberRank.TabStop = false;
      this.imgHuRodRank.Image = (Image) Resources.rank_C;
      this.imgHuRodRank.Location = new Point(8, 95);
      this.imgHuRodRank.Name = "imgHuRodRank";
      this.imgHuRodRank.Size = new Size(10, 10);
      this.imgHuRodRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuRodRank.TabIndex = 86;
      this.imgHuRodRank.TabStop = false;
      this.imgHuCrossbowRank.Image = (Image) Resources.rank_C;
      this.imgHuCrossbowRank.Location = new Point(8, 83);
      this.imgHuCrossbowRank.Name = "imgHuCrossbowRank";
      this.imgHuCrossbowRank.Size = new Size(10, 10);
      this.imgHuCrossbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuCrossbowRank.TabIndex = 85;
      this.imgHuCrossbowRank.TabStop = false;
      this.imgHuGrenadeRank.Image = (Image) Resources.rank_C;
      this.imgHuGrenadeRank.Location = new Point(8, 71);
      this.imgHuGrenadeRank.Name = "imgHuGrenadeRank";
      this.imgHuGrenadeRank.Size = new Size(10, 10);
      this.imgHuGrenadeRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuGrenadeRank.TabIndex = 84;
      this.imgHuGrenadeRank.TabStop = false;
      this.imgHuSlicerRank.Image = (Image) Resources.rank_C;
      this.imgHuSlicerRank.Location = new Point(8, 59);
      this.imgHuSlicerRank.Name = "imgHuSlicerRank";
      this.imgHuSlicerRank.Size = new Size(10, 10);
      this.imgHuSlicerRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSlicerRank.TabIndex = 83;
      this.imgHuSlicerRank.TabStop = false;
      this.imgHuSaberRank.Image = (Image) Resources.rank_C;
      this.imgHuSaberRank.Location = new Point(8, 47);
      this.imgHuSaberRank.Name = "imgHuSaberRank";
      this.imgHuSaberRank.Size = new Size(10, 10);
      this.imgHuSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSaberRank.TabIndex = 82;
      this.imgHuSaberRank.TabStop = false;
      this.imgHuAxeRank.Image = (Image) Resources.rank_C;
      this.imgHuAxeRank.Location = new Point(8, 35);
      this.imgHuAxeRank.Name = "imgHuAxeRank";
      this.imgHuAxeRank.Size = new Size(10, 10);
      this.imgHuAxeRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuAxeRank.TabIndex = 81;
      this.imgHuAxeRank.TabStop = false;
      this.imgHuSwordRank.Image = (Image) Resources.rank_C;
      this.imgHuSwordRank.Location = new Point(8, 23);
      this.imgHuSwordRank.Name = "imgHuSwordRank";
      this.imgHuSwordRank.Size = new Size(10, 10);
      this.imgHuSwordRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSwordRank.TabIndex = 80;
      this.imgHuSwordRank.TabStop = false;
      this.imgHuRmag.Image = (Image) Resources.weapon_rmag;
      this.imgHuRmag.Location = new Point((int) sbyte.MaxValue, 83);
      this.imgHuRmag.Name = "imgHuRmag";
      this.imgHuRmag.Size = new Size(10, 10);
      this.imgHuRmag.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuRmag.TabIndex = 79;
      this.imgHuRmag.TabStop = false;
      this.imgHuMachinegun.Image = (Image) Resources.weapon_machinegun;
      this.imgHuMachinegun.Location = new Point(91, 83);
      this.imgHuMachinegun.Name = "imgHuMachinegun";
      this.imgHuMachinegun.Size = new Size(10, 10);
      this.imgHuMachinegun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuMachinegun.TabIndex = 78;
      this.imgHuMachinegun.TabStop = false;
      this.imgHuCrossbow.Image = (Image) Resources.weapon_crossbow;
      this.imgHuCrossbow.Location = new Point(19, 83);
      this.imgHuCrossbow.Name = "imgHuCrossbow";
      this.imgHuCrossbow.Size = new Size(10, 10);
      this.imgHuCrossbow.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuCrossbow.TabIndex = 77;
      this.imgHuCrossbow.TabStop = false;
      this.imgHuCards.Image = (Image) Resources.weapon_card;
      this.imgHuCards.Location = new Point(55, 83);
      this.imgHuCards.Name = "imgHuCards";
      this.imgHuCards.Size = new Size(10, 10);
      this.imgHuCards.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuCards.TabIndex = 76;
      this.imgHuCards.TabStop = false;
      this.imgHuHandgun.Image = (Image) Resources.weapon_handgun;
      this.imgHuHandgun.Location = new Point((int) sbyte.MaxValue, 71);
      this.imgHuHandgun.Name = "imgHuHandgun";
      this.imgHuHandgun.Size = new Size(10, 10);
      this.imgHuHandgun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuHandgun.TabIndex = 75;
      this.imgHuHandgun.TabStop = false;
      this.imgHuHandguns.Image = (Image) Resources.weapon_handguns;
      this.imgHuHandguns.Location = new Point(91, 71);
      this.imgHuHandguns.Name = "imgHuHandguns";
      this.imgHuHandguns.Size = new Size(23, 10);
      this.imgHuHandguns.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuHandguns.TabIndex = 74;
      this.imgHuHandguns.TabStop = false;
      this.imgHuGrenade.Image = (Image) Resources.weapon_grenade;
      this.imgHuGrenade.Location = new Point(19, 71);
      this.imgHuGrenade.Name = "imgHuGrenade";
      this.imgHuGrenade.Size = new Size(23, 10);
      this.imgHuGrenade.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuGrenade.TabIndex = 73;
      this.imgHuGrenade.TabStop = false;
      this.imgHuLaser.Image = (Image) Resources.weapon_laser;
      this.imgHuLaser.Location = new Point(55, 71);
      this.imgHuLaser.Name = "imgHuLaser";
      this.imgHuLaser.Size = new Size(23, 10);
      this.imgHuLaser.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuLaser.TabIndex = 72;
      this.imgHuLaser.TabStop = false;
      this.imgHuLongbow.Image = (Image) Resources.weapon_longbow;
      this.imgHuLongbow.Location = new Point((int) sbyte.MaxValue, 59);
      this.imgHuLongbow.Name = "imgHuLongbow";
      this.imgHuLongbow.Size = new Size(23, 10);
      this.imgHuLongbow.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuLongbow.TabIndex = 71;
      this.imgHuLongbow.TabStop = false;
      this.imgHuShotgun.Image = (Image) Resources.weapon_shotgun;
      this.imgHuShotgun.Location = new Point(91, 59);
      this.imgHuShotgun.Name = "imgHuShotgun";
      this.imgHuShotgun.Size = new Size(23, 10);
      this.imgHuShotgun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuShotgun.TabIndex = 70;
      this.imgHuShotgun.TabStop = false;
      this.imgHuSlicer.Image = (Image) Resources.weapon_slicer;
      this.imgHuSlicer.Location = new Point(19, 59);
      this.imgHuSlicer.Name = "imgHuSlicer";
      this.imgHuSlicer.Size = new Size(10, 10);
      this.imgHuSlicer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSlicer.TabIndex = 69;
      this.imgHuSlicer.TabStop = false;
      this.imgHuRifle.Image = (Image) Resources.weapon_rifle;
      this.imgHuRifle.Location = new Point(55, 59);
      this.imgHuRifle.Name = "imgHuRifle";
      this.imgHuRifle.Size = new Size(23, 10);
      this.imgHuRifle.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuRifle.TabIndex = 68;
      this.imgHuRifle.TabStop = false;
      this.imgHuWhip.Image = (Image) Resources.weapon_whip;
      this.imgHuWhip.Location = new Point((int) sbyte.MaxValue, 47);
      this.imgHuWhip.Name = "imgHuWhip";
      this.imgHuWhip.Size = new Size(10, 10);
      this.imgHuWhip.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuWhip.TabIndex = 67;
      this.imgHuWhip.TabStop = false;
      this.imgHuClaw.Image = (Image) Resources.weapon_claw;
      this.imgHuClaw.Location = new Point(91, 47);
      this.imgHuClaw.Name = "imgHuClaw";
      this.imgHuClaw.Size = new Size(10, 10);
      this.imgHuClaw.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuClaw.TabIndex = 66;
      this.imgHuClaw.TabStop = false;
      this.imgHuSaber.Image = (Image) Resources.weapon_saber;
      this.imgHuSaber.Location = new Point(19, 47);
      this.imgHuSaber.Name = "imgHuSaber";
      this.imgHuSaber.Size = new Size(10, 10);
      this.imgHuSaber.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSaber.TabIndex = 65;
      this.imgHuSaber.TabStop = false;
      this.imgHuDagger.Image = (Image) Resources.weapon_dagger;
      this.imgHuDagger.Location = new Point(55, 47);
      this.imgHuDagger.Name = "imgHuDagger";
      this.imgHuDagger.Size = new Size(10, 10);
      this.imgHuDagger.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuDagger.TabIndex = 64;
      this.imgHuDagger.TabStop = false;
      this.imgHuShield.Image = (Image) Resources.weapon_shield;
      this.imgHuShield.Location = new Point((int) sbyte.MaxValue, 95);
      this.imgHuShield.Name = "imgHuShield";
      this.imgHuShield.Size = new Size(10, 10);
      this.imgHuShield.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuShield.TabIndex = 63;
      this.imgHuShield.TabStop = false;
      this.imgHuTmag.Image = (Image) Resources.weapon_tmag;
      this.imgHuTmag.Location = new Point(91, 95);
      this.imgHuTmag.Name = "imgHuTmag";
      this.imgHuTmag.Size = new Size(10, 10);
      this.imgHuTmag.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuTmag.TabIndex = 62;
      this.imgHuTmag.TabStop = false;
      this.imgHuRod.Image = (Image) Resources.weapon_rod;
      this.imgHuRod.Location = new Point(19, 95);
      this.imgHuRod.Name = "imgHuRod";
      this.imgHuRod.Size = new Size(23, 10);
      this.imgHuRod.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuRod.TabIndex = 61;
      this.imgHuRod.TabStop = false;
      this.imgHuWand.Image = (Image) Resources.weapon_wand;
      this.imgHuWand.Location = new Point(55, 95);
      this.imgHuWand.Name = "imgHuWand";
      this.imgHuWand.Size = new Size(10, 10);
      this.imgHuWand.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuWand.TabIndex = 60;
      this.imgHuWand.TabStop = false;
      this.imgHuClaws.Image = (Image) Resources.weapon_claws;
      this.imgHuClaws.Location = new Point((int) sbyte.MaxValue, 35);
      this.imgHuClaws.Name = "imgHuClaws";
      this.imgHuClaws.Size = new Size(23, 10);
      this.imgHuClaws.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuClaws.TabIndex = 59;
      this.imgHuClaws.TabStop = false;
      this.imgHuDaggers.Image = (Image) Resources.weapon_daggers;
      this.imgHuDaggers.Location = new Point(91, 35);
      this.imgHuDaggers.Name = "imgHuDaggers";
      this.imgHuDaggers.Size = new Size(23, 10);
      this.imgHuDaggers.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuDaggers.TabIndex = 58;
      this.imgHuDaggers.TabStop = false;
      this.imgHuAxe.Image = (Image) Resources.weapon_axe;
      this.imgHuAxe.Location = new Point(19, 35);
      this.imgHuAxe.Name = "imgHuAxe";
      this.imgHuAxe.Size = new Size(23, 10);
      this.imgHuAxe.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuAxe.TabIndex = 57;
      this.imgHuAxe.TabStop = false;
      this.imgHuSabers.Image = (Image) Resources.weapon_sabers;
      this.imgHuSabers.Location = new Point(55, 35);
      this.imgHuSabers.Name = "imgHuSabers";
      this.imgHuSabers.Size = new Size(23, 10);
      this.imgHuSabers.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSabers.TabIndex = 56;
      this.imgHuSabers.TabStop = false;
      this.imgHuDblSaber.Image = (Image) Resources.weapon_double_saber;
      this.imgHuDblSaber.Location = new Point((int) sbyte.MaxValue, 23);
      this.imgHuDblSaber.Name = "imgHuDblSaber";
      this.imgHuDblSaber.Size = new Size(23, 10);
      this.imgHuDblSaber.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuDblSaber.TabIndex = 55;
      this.imgHuDblSaber.TabStop = false;
      this.imgHuKnuckles.Image = (Image) Resources.weapon_knuckles;
      this.imgHuKnuckles.Location = new Point(55, 23);
      this.imgHuKnuckles.Name = "imgHuKnuckles";
      this.imgHuKnuckles.Size = new Size(23, 10);
      this.imgHuKnuckles.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuKnuckles.TabIndex = 54;
      this.imgHuKnuckles.TabStop = false;
      this.imgHuSpear.Image = (Image) Resources.weapon_spear;
      this.imgHuSpear.Location = new Point(91, 23);
      this.imgHuSpear.Name = "imgHuSpear";
      this.imgHuSpear.Size = new Size(23, 10);
      this.imgHuSpear.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSpear.TabIndex = 53;
      this.imgHuSpear.TabStop = false;
      this.imgHuSword.Image = (Image) Resources.weapon_sword;
      this.imgHuSword.Location = new Point(19, 23);
      this.imgHuSword.Name = "imgHuSword";
      this.imgHuSword.Size = new Size(23, 10);
      this.imgHuSword.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgHuSword.TabIndex = 52;
      this.imgHuSword.TabStop = false;
      this.pictureBox231.Image = (Image) Resources.type_weapons;
      this.pictureBox231.Location = new Point(19, 23);
      this.pictureBox231.Name = "pictureBox231";
      this.pictureBox231.Size = new Size(131, 82);
      this.pictureBox231.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox231.TabIndex = 47;
      this.pictureBox231.TabStop = false;
      this.lblHuLevel.AutoSize = true;
      this.lblHuLevel.Cursor = Cursors.Hand;
      this.lblHuLevel.Location = new Point(12, 32);
      this.lblHuLevel.Name = "lblHuLevel";
      this.lblHuLevel.Size = new Size(37, 13);
      this.lblHuLevel.TabIndex = 130;
      this.lblHuLevel.Text = "Level";
      this.lblHuLevel.Click += new EventHandler(this.classLevel_Click);
      this.txtHuLevel.AutoSize = true;
      this.txtHuLevel.Cursor = Cursors.Hand;
      this.txtHuLevel.Location = new Point(50, 32);
      this.txtHuLevel.Name = "txtHuLevel";
      this.txtHuLevel.Size = new Size(14, 13);
      this.txtHuLevel.TabIndex = 131;
      this.txtHuLevel.Text = "0";
      this.txtHuLevel.Click += new EventHandler(this.classLevel_Click);
      this.label39.AutoSize = true;
      this.label39.Cursor = Cursors.Hand;
      this.label39.Location = new Point(50, 32);
      this.label39.Name = "label39";
      this.label39.Size = new Size(14, 13);
      this.label39.TabIndex = 129;
      this.label39.Text = "0";
      this.label39.Click += new EventHandler(this.classLevel_Click);
      this.tabPageRanger.Controls.Add((Control) this.label10);
      this.tabPageRanger.Controls.Add((Control) this.grpRaTypeExtend);
      this.tabPageRanger.Controls.Add((Control) this.lblRaLevel);
      this.tabPageRanger.Controls.Add((Control) this.txtRaLevel);
      this.tabPageRanger.Controls.Add((Control) this.label35);
      this.tabPageRanger.Controls.Add((Control) this.btnRaAbilitiesOpen);
      this.tabPageRanger.Font = new Font("Verdana", 8.25f);
      this.tabPageRanger.Location = new Point(4, 21);
      this.tabPageRanger.Name = "tabPageRanger";
      this.tabPageRanger.Padding = new Padding(3);
      this.tabPageRanger.Size = new Size(610, 192);
      this.tabPageRanger.TabIndex = 1;
      this.tabPageRanger.Text = "Ranger (0)";
      this.tabPageRanger.UseVisualStyleBackColor = true;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.Location = new Point(11, 13);
      this.label10.Name = "label10";
      this.label10.Size = new Size(59, 16);
      this.label10.TabIndex = 134;
      this.label10.Text = "Ranger";
      this.grpRaTypeExtend.Controls.Add((Control) this.txtRaExp);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaTmagRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaMachinegunRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.txtRaExpBar);
      this.grpRaTypeExtend.Controls.Add((Control) this.label22);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaHandgunsRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.label23);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaShotgunRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaClawRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaDaggersRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSpearRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaWandRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaCardsRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaLaserRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaRifleRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaDaggerRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSabersRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaKnucklesRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaShieldRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaRmagRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaHandgunRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaLongbowRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaWhipRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaClawsRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaDblSaberRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaRodRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaCrossbowRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaGrenadeRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSlicerRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSaberRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaAxeRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSwordRank);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaRmag);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaMachinegun);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaCrossbow);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaCards);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaHandgun);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaHandguns);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaGrenade);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaLaser);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaLongbow);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaShotgun);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSlicer);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaRifle);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaWhip);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaClaw);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSaber);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaDagger);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaShield);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaTmag);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaRod);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaWand);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaClaws);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaDaggers);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaAxe);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSabers);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaDblSaber);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaKnuckles);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSpear);
      this.grpRaTypeExtend.Controls.Add((Control) this.imgRaSword);
      this.grpRaTypeExtend.Controls.Add((Control) this.pictureBox174);
      this.grpRaTypeExtend.Location = new Point(10, 58);
      this.grpRaTypeExtend.Name = "grpRaTypeExtend";
      this.grpRaTypeExtend.Size = new Size(304, 119);
      this.grpRaTypeExtend.TabIndex = 133;
      this.grpRaTypeExtend.TabStop = false;
      this.grpRaTypeExtend.Text = "Type Extend 0/0";
      this.txtRaExp.BackColor = Color.Transparent;
      this.txtRaExp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRaExp.Location = new Point(194, 36);
      this.txtRaExp.Name = "txtRaExp";
      this.txtRaExp.Size = new Size(102, 69);
      this.txtRaExp.TabIndex = 108;
      this.txtRaExp.TextAlign = ContentAlignment.TopRight;
      this.imgRaTmagRank.Image = (Image) Resources.rank_C;
      this.imgRaTmagRank.Location = new Point(80, 95);
      this.imgRaTmagRank.Name = "imgRaTmagRank";
      this.imgRaTmagRank.Size = new Size(10, 10);
      this.imgRaTmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaTmagRank.TabIndex = 107;
      this.imgRaTmagRank.TabStop = false;
      this.imgRaMachinegunRank.Image = (Image) Resources.rank_C;
      this.imgRaMachinegunRank.Location = new Point(80, 83);
      this.imgRaMachinegunRank.Name = "imgRaMachinegunRank";
      this.imgRaMachinegunRank.Size = new Size(10, 10);
      this.imgRaMachinegunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaMachinegunRank.TabIndex = 106;
      this.imgRaMachinegunRank.TabStop = false;
      this.txtRaExpBar.BackColor = Color.Red;
      this.txtRaExpBar.Location = new Point(195, 23);
      this.txtRaExpBar.Name = "txtRaExpBar";
      this.txtRaExpBar.Size = new Size(87, 8);
      this.txtRaExpBar.TabIndex = 49;
      this.label22.AutoSize = true;
      this.label22.Location = new Point(159, 20);
      this.label22.Name = "label22";
      this.label22.Size = new Size(29, 13);
      this.label22.TabIndex = 48;
      this.label22.Text = "EXP";
      this.imgRaHandgunsRank.Image = (Image) Resources.rank_C;
      this.imgRaHandgunsRank.Location = new Point(80, 71);
      this.imgRaHandgunsRank.Name = "imgRaHandgunsRank";
      this.imgRaHandgunsRank.Size = new Size(10, 10);
      this.imgRaHandgunsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaHandgunsRank.TabIndex = 105;
      this.imgRaHandgunsRank.TabStop = false;
      this.label23.BackColor = Color.Gainsboro;
      this.label23.BorderStyle = BorderStyle.FixedSingle;
      this.label23.Location = new Point(194, 22);
      this.label23.Name = "label23";
      this.label23.Size = new Size(102, 10);
      this.label23.TabIndex = 50;
      this.imgRaShotgunRank.Image = (Image) Resources.rank_C;
      this.imgRaShotgunRank.Location = new Point(80, 59);
      this.imgRaShotgunRank.Name = "imgRaShotgunRank";
      this.imgRaShotgunRank.Size = new Size(10, 10);
      this.imgRaShotgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaShotgunRank.TabIndex = 104;
      this.imgRaShotgunRank.TabStop = false;
      this.imgRaClawRank.Image = (Image) Resources.rank_C;
      this.imgRaClawRank.Location = new Point(80, 47);
      this.imgRaClawRank.Name = "imgRaClawRank";
      this.imgRaClawRank.Size = new Size(10, 10);
      this.imgRaClawRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaClawRank.TabIndex = 103;
      this.imgRaClawRank.TabStop = false;
      this.imgRaDaggersRank.Image = (Image) Resources.rank_C;
      this.imgRaDaggersRank.Location = new Point(80, 35);
      this.imgRaDaggersRank.Name = "imgRaDaggersRank";
      this.imgRaDaggersRank.Size = new Size(10, 10);
      this.imgRaDaggersRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaDaggersRank.TabIndex = 102;
      this.imgRaDaggersRank.TabStop = false;
      this.imgRaSpearRank.Image = (Image) Resources.rank_C;
      this.imgRaSpearRank.Location = new Point(80, 23);
      this.imgRaSpearRank.Name = "imgRaSpearRank";
      this.imgRaSpearRank.Size = new Size(10, 10);
      this.imgRaSpearRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSpearRank.TabIndex = 101;
      this.imgRaSpearRank.TabStop = false;
      this.imgRaWandRank.Image = (Image) Resources.rank_B;
      this.imgRaWandRank.Location = new Point(44, 95);
      this.imgRaWandRank.Name = "imgRaWandRank";
      this.imgRaWandRank.Size = new Size(10, 10);
      this.imgRaWandRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaWandRank.TabIndex = 100;
      this.imgRaWandRank.TabStop = false;
      this.imgRaCardsRank.Image = (Image) Resources.rank_B;
      this.imgRaCardsRank.Location = new Point(44, 83);
      this.imgRaCardsRank.Name = "imgRaCardsRank";
      this.imgRaCardsRank.Size = new Size(10, 10);
      this.imgRaCardsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaCardsRank.TabIndex = 99;
      this.imgRaCardsRank.TabStop = false;
      this.imgRaLaserRank.Image = (Image) Resources.rank_B;
      this.imgRaLaserRank.Location = new Point(44, 71);
      this.imgRaLaserRank.Name = "imgRaLaserRank";
      this.imgRaLaserRank.Size = new Size(10, 10);
      this.imgRaLaserRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaLaserRank.TabIndex = 98;
      this.imgRaLaserRank.TabStop = false;
      this.imgRaRifleRank.Image = (Image) Resources.rank_B;
      this.imgRaRifleRank.Location = new Point(44, 59);
      this.imgRaRifleRank.Name = "imgRaRifleRank";
      this.imgRaRifleRank.Size = new Size(10, 10);
      this.imgRaRifleRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaRifleRank.TabIndex = 97;
      this.imgRaRifleRank.TabStop = false;
      this.imgRaDaggerRank.Image = (Image) Resources.rank_B;
      this.imgRaDaggerRank.Location = new Point(44, 47);
      this.imgRaDaggerRank.Name = "imgRaDaggerRank";
      this.imgRaDaggerRank.Size = new Size(10, 10);
      this.imgRaDaggerRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaDaggerRank.TabIndex = 96;
      this.imgRaDaggerRank.TabStop = false;
      this.imgRaSabersRank.Image = (Image) Resources.rank_B;
      this.imgRaSabersRank.Location = new Point(44, 35);
      this.imgRaSabersRank.Name = "imgRaSabersRank";
      this.imgRaSabersRank.Size = new Size(10, 10);
      this.imgRaSabersRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSabersRank.TabIndex = 95;
      this.imgRaSabersRank.TabStop = false;
      this.imgRaKnucklesRank.Image = (Image) Resources.rank_B;
      this.imgRaKnucklesRank.Location = new Point(44, 23);
      this.imgRaKnucklesRank.Name = "imgRaKnucklesRank";
      this.imgRaKnucklesRank.Size = new Size(10, 10);
      this.imgRaKnucklesRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaKnucklesRank.TabIndex = 94;
      this.imgRaKnucklesRank.TabStop = false;
      this.imgRaShieldRank.Image = (Image) Resources.rank_B;
      this.imgRaShieldRank.Location = new Point(116, 95);
      this.imgRaShieldRank.Name = "imgRaShieldRank";
      this.imgRaShieldRank.Size = new Size(10, 10);
      this.imgRaShieldRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaShieldRank.TabIndex = 93;
      this.imgRaShieldRank.TabStop = false;
      this.imgRaRmagRank.Image = (Image) Resources.rank_B;
      this.imgRaRmagRank.Location = new Point(116, 83);
      this.imgRaRmagRank.Name = "imgRaRmagRank";
      this.imgRaRmagRank.Size = new Size(10, 10);
      this.imgRaRmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaRmagRank.TabIndex = 92;
      this.imgRaRmagRank.TabStop = false;
      this.imgRaHandgunRank.Image = (Image) Resources.rank_B;
      this.imgRaHandgunRank.Location = new Point(116, 71);
      this.imgRaHandgunRank.Name = "imgRaHandgunRank";
      this.imgRaHandgunRank.Size = new Size(10, 10);
      this.imgRaHandgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaHandgunRank.TabIndex = 91;
      this.imgRaHandgunRank.TabStop = false;
      this.imgRaLongbowRank.Image = (Image) Resources.rank_B;
      this.imgRaLongbowRank.Location = new Point(116, 59);
      this.imgRaLongbowRank.Name = "imgRaLongbowRank";
      this.imgRaLongbowRank.Size = new Size(10, 10);
      this.imgRaLongbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaLongbowRank.TabIndex = 90;
      this.imgRaLongbowRank.TabStop = false;
      this.imgRaWhipRank.Image = (Image) Resources.rank_B;
      this.imgRaWhipRank.Location = new Point(116, 47);
      this.imgRaWhipRank.Name = "imgRaWhipRank";
      this.imgRaWhipRank.Size = new Size(10, 10);
      this.imgRaWhipRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaWhipRank.TabIndex = 89;
      this.imgRaWhipRank.TabStop = false;
      this.imgRaClawsRank.Image = (Image) Resources.rank_B;
      this.imgRaClawsRank.Location = new Point(116, 35);
      this.imgRaClawsRank.Name = "imgRaClawsRank";
      this.imgRaClawsRank.Size = new Size(10, 10);
      this.imgRaClawsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaClawsRank.TabIndex = 88;
      this.imgRaClawsRank.TabStop = false;
      this.imgRaDblSaberRank.Image = (Image) Resources.rank_B;
      this.imgRaDblSaberRank.Location = new Point(116, 23);
      this.imgRaDblSaberRank.Name = "imgRaDblSaberRank";
      this.imgRaDblSaberRank.Size = new Size(10, 10);
      this.imgRaDblSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaDblSaberRank.TabIndex = 87;
      this.imgRaDblSaberRank.TabStop = false;
      this.imgRaRodRank.Image = (Image) Resources.rank_C;
      this.imgRaRodRank.Location = new Point(8, 95);
      this.imgRaRodRank.Name = "imgRaRodRank";
      this.imgRaRodRank.Size = new Size(10, 10);
      this.imgRaRodRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaRodRank.TabIndex = 86;
      this.imgRaRodRank.TabStop = false;
      this.imgRaCrossbowRank.Image = (Image) Resources.rank_C;
      this.imgRaCrossbowRank.Location = new Point(8, 83);
      this.imgRaCrossbowRank.Name = "imgRaCrossbowRank";
      this.imgRaCrossbowRank.Size = new Size(10, 10);
      this.imgRaCrossbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaCrossbowRank.TabIndex = 85;
      this.imgRaCrossbowRank.TabStop = false;
      this.imgRaGrenadeRank.Image = (Image) Resources.rank_C;
      this.imgRaGrenadeRank.Location = new Point(8, 71);
      this.imgRaGrenadeRank.Name = "imgRaGrenadeRank";
      this.imgRaGrenadeRank.Size = new Size(10, 10);
      this.imgRaGrenadeRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaGrenadeRank.TabIndex = 84;
      this.imgRaGrenadeRank.TabStop = false;
      this.imgRaSlicerRank.Image = (Image) Resources.rank_C;
      this.imgRaSlicerRank.Location = new Point(8, 59);
      this.imgRaSlicerRank.Name = "imgRaSlicerRank";
      this.imgRaSlicerRank.Size = new Size(10, 10);
      this.imgRaSlicerRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSlicerRank.TabIndex = 83;
      this.imgRaSlicerRank.TabStop = false;
      this.imgRaSaberRank.Image = (Image) Resources.rank_C;
      this.imgRaSaberRank.Location = new Point(8, 47);
      this.imgRaSaberRank.Name = "imgRaSaberRank";
      this.imgRaSaberRank.Size = new Size(10, 10);
      this.imgRaSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSaberRank.TabIndex = 82;
      this.imgRaSaberRank.TabStop = false;
      this.imgRaAxeRank.Image = (Image) Resources.rank_C;
      this.imgRaAxeRank.Location = new Point(8, 35);
      this.imgRaAxeRank.Name = "imgRaAxeRank";
      this.imgRaAxeRank.Size = new Size(10, 10);
      this.imgRaAxeRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaAxeRank.TabIndex = 81;
      this.imgRaAxeRank.TabStop = false;
      this.imgRaSwordRank.Image = (Image) Resources.rank_C;
      this.imgRaSwordRank.Location = new Point(8, 23);
      this.imgRaSwordRank.Name = "imgRaSwordRank";
      this.imgRaSwordRank.Size = new Size(10, 10);
      this.imgRaSwordRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSwordRank.TabIndex = 80;
      this.imgRaSwordRank.TabStop = false;
      this.imgRaRmag.Image = (Image) Resources.weapon_rmag;
      this.imgRaRmag.Location = new Point((int) sbyte.MaxValue, 83);
      this.imgRaRmag.Name = "imgRaRmag";
      this.imgRaRmag.Size = new Size(10, 10);
      this.imgRaRmag.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaRmag.TabIndex = 79;
      this.imgRaRmag.TabStop = false;
      this.imgRaMachinegun.Image = (Image) Resources.weapon_machinegun;
      this.imgRaMachinegun.Location = new Point(91, 83);
      this.imgRaMachinegun.Name = "imgRaMachinegun";
      this.imgRaMachinegun.Size = new Size(10, 10);
      this.imgRaMachinegun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaMachinegun.TabIndex = 78;
      this.imgRaMachinegun.TabStop = false;
      this.imgRaCrossbow.Image = (Image) Resources.weapon_crossbow;
      this.imgRaCrossbow.Location = new Point(19, 83);
      this.imgRaCrossbow.Name = "imgRaCrossbow";
      this.imgRaCrossbow.Size = new Size(10, 10);
      this.imgRaCrossbow.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaCrossbow.TabIndex = 77;
      this.imgRaCrossbow.TabStop = false;
      this.imgRaCards.Image = (Image) Resources.weapon_card;
      this.imgRaCards.Location = new Point(55, 83);
      this.imgRaCards.Name = "imgRaCards";
      this.imgRaCards.Size = new Size(10, 10);
      this.imgRaCards.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaCards.TabIndex = 76;
      this.imgRaCards.TabStop = false;
      this.imgRaHandgun.Image = (Image) Resources.weapon_handgun;
      this.imgRaHandgun.Location = new Point((int) sbyte.MaxValue, 71);
      this.imgRaHandgun.Name = "imgRaHandgun";
      this.imgRaHandgun.Size = new Size(10, 10);
      this.imgRaHandgun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaHandgun.TabIndex = 75;
      this.imgRaHandgun.TabStop = false;
      this.imgRaHandguns.Image = (Image) Resources.weapon_handguns;
      this.imgRaHandguns.Location = new Point(91, 71);
      this.imgRaHandguns.Name = "imgRaHandguns";
      this.imgRaHandguns.Size = new Size(23, 10);
      this.imgRaHandguns.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaHandguns.TabIndex = 74;
      this.imgRaHandguns.TabStop = false;
      this.imgRaGrenade.Image = (Image) Resources.weapon_grenade;
      this.imgRaGrenade.Location = new Point(19, 71);
      this.imgRaGrenade.Name = "imgRaGrenade";
      this.imgRaGrenade.Size = new Size(23, 10);
      this.imgRaGrenade.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaGrenade.TabIndex = 73;
      this.imgRaGrenade.TabStop = false;
      this.imgRaLaser.Image = (Image) Resources.weapon_laser;
      this.imgRaLaser.Location = new Point(55, 71);
      this.imgRaLaser.Name = "imgRaLaser";
      this.imgRaLaser.Size = new Size(23, 10);
      this.imgRaLaser.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaLaser.TabIndex = 72;
      this.imgRaLaser.TabStop = false;
      this.imgRaLongbow.Image = (Image) Resources.weapon_longbow;
      this.imgRaLongbow.Location = new Point((int) sbyte.MaxValue, 59);
      this.imgRaLongbow.Name = "imgRaLongbow";
      this.imgRaLongbow.Size = new Size(23, 10);
      this.imgRaLongbow.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaLongbow.TabIndex = 71;
      this.imgRaLongbow.TabStop = false;
      this.imgRaShotgun.Image = (Image) Resources.weapon_shotgun;
      this.imgRaShotgun.Location = new Point(91, 59);
      this.imgRaShotgun.Name = "imgRaShotgun";
      this.imgRaShotgun.Size = new Size(23, 10);
      this.imgRaShotgun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaShotgun.TabIndex = 70;
      this.imgRaShotgun.TabStop = false;
      this.imgRaSlicer.Image = (Image) Resources.weapon_slicer;
      this.imgRaSlicer.Location = new Point(19, 59);
      this.imgRaSlicer.Name = "imgRaSlicer";
      this.imgRaSlicer.Size = new Size(10, 10);
      this.imgRaSlicer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSlicer.TabIndex = 69;
      this.imgRaSlicer.TabStop = false;
      this.imgRaRifle.Image = (Image) Resources.weapon_rifle;
      this.imgRaRifle.Location = new Point(55, 59);
      this.imgRaRifle.Name = "imgRaRifle";
      this.imgRaRifle.Size = new Size(23, 10);
      this.imgRaRifle.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaRifle.TabIndex = 68;
      this.imgRaRifle.TabStop = false;
      this.imgRaWhip.Image = (Image) Resources.weapon_whip;
      this.imgRaWhip.Location = new Point((int) sbyte.MaxValue, 47);
      this.imgRaWhip.Name = "imgRaWhip";
      this.imgRaWhip.Size = new Size(10, 10);
      this.imgRaWhip.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaWhip.TabIndex = 67;
      this.imgRaWhip.TabStop = false;
      this.imgRaClaw.Image = (Image) Resources.weapon_claw;
      this.imgRaClaw.Location = new Point(91, 47);
      this.imgRaClaw.Name = "imgRaClaw";
      this.imgRaClaw.Size = new Size(10, 10);
      this.imgRaClaw.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaClaw.TabIndex = 66;
      this.imgRaClaw.TabStop = false;
      this.imgRaSaber.Image = (Image) Resources.weapon_saber;
      this.imgRaSaber.Location = new Point(19, 47);
      this.imgRaSaber.Name = "imgRaSaber";
      this.imgRaSaber.Size = new Size(10, 10);
      this.imgRaSaber.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSaber.TabIndex = 65;
      this.imgRaSaber.TabStop = false;
      this.imgRaDagger.Image = (Image) Resources.weapon_dagger;
      this.imgRaDagger.Location = new Point(55, 47);
      this.imgRaDagger.Name = "imgRaDagger";
      this.imgRaDagger.Size = new Size(10, 10);
      this.imgRaDagger.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaDagger.TabIndex = 64;
      this.imgRaDagger.TabStop = false;
      this.imgRaShield.Image = (Image) Resources.weapon_shield;
      this.imgRaShield.Location = new Point((int) sbyte.MaxValue, 95);
      this.imgRaShield.Name = "imgRaShield";
      this.imgRaShield.Size = new Size(10, 10);
      this.imgRaShield.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaShield.TabIndex = 63;
      this.imgRaShield.TabStop = false;
      this.imgRaTmag.Image = (Image) Resources.weapon_tmag;
      this.imgRaTmag.Location = new Point(91, 95);
      this.imgRaTmag.Name = "imgRaTmag";
      this.imgRaTmag.Size = new Size(10, 10);
      this.imgRaTmag.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaTmag.TabIndex = 62;
      this.imgRaTmag.TabStop = false;
      this.imgRaRod.Image = (Image) Resources.weapon_rod;
      this.imgRaRod.Location = new Point(19, 95);
      this.imgRaRod.Name = "imgRaRod";
      this.imgRaRod.Size = new Size(23, 10);
      this.imgRaRod.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaRod.TabIndex = 61;
      this.imgRaRod.TabStop = false;
      this.imgRaWand.Image = (Image) Resources.weapon_wand;
      this.imgRaWand.Location = new Point(55, 95);
      this.imgRaWand.Name = "imgRaWand";
      this.imgRaWand.Size = new Size(10, 10);
      this.imgRaWand.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaWand.TabIndex = 60;
      this.imgRaWand.TabStop = false;
      this.imgRaClaws.Image = (Image) Resources.weapon_claws;
      this.imgRaClaws.Location = new Point((int) sbyte.MaxValue, 35);
      this.imgRaClaws.Name = "imgRaClaws";
      this.imgRaClaws.Size = new Size(23, 10);
      this.imgRaClaws.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaClaws.TabIndex = 59;
      this.imgRaClaws.TabStop = false;
      this.imgRaDaggers.Image = (Image) Resources.weapon_daggers;
      this.imgRaDaggers.Location = new Point(91, 35);
      this.imgRaDaggers.Name = "imgRaDaggers";
      this.imgRaDaggers.Size = new Size(23, 10);
      this.imgRaDaggers.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaDaggers.TabIndex = 58;
      this.imgRaDaggers.TabStop = false;
      this.imgRaAxe.Image = (Image) Resources.weapon_axe;
      this.imgRaAxe.Location = new Point(19, 35);
      this.imgRaAxe.Name = "imgRaAxe";
      this.imgRaAxe.Size = new Size(23, 10);
      this.imgRaAxe.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaAxe.TabIndex = 57;
      this.imgRaAxe.TabStop = false;
      this.imgRaSabers.Image = (Image) Resources.weapon_sabers;
      this.imgRaSabers.Location = new Point(55, 35);
      this.imgRaSabers.Name = "imgRaSabers";
      this.imgRaSabers.Size = new Size(23, 10);
      this.imgRaSabers.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSabers.TabIndex = 56;
      this.imgRaSabers.TabStop = false;
      this.imgRaDblSaber.Image = (Image) Resources.weapon_double_saber;
      this.imgRaDblSaber.Location = new Point((int) sbyte.MaxValue, 23);
      this.imgRaDblSaber.Name = "imgRaDblSaber";
      this.imgRaDblSaber.Size = new Size(23, 10);
      this.imgRaDblSaber.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaDblSaber.TabIndex = 55;
      this.imgRaDblSaber.TabStop = false;
      this.imgRaKnuckles.Image = (Image) Resources.weapon_knuckles;
      this.imgRaKnuckles.Location = new Point(55, 23);
      this.imgRaKnuckles.Name = "imgRaKnuckles";
      this.imgRaKnuckles.Size = new Size(23, 10);
      this.imgRaKnuckles.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaKnuckles.TabIndex = 54;
      this.imgRaKnuckles.TabStop = false;
      this.imgRaSpear.Image = (Image) Resources.weapon_spear;
      this.imgRaSpear.Location = new Point(91, 23);
      this.imgRaSpear.Name = "imgRaSpear";
      this.imgRaSpear.Size = new Size(23, 10);
      this.imgRaSpear.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSpear.TabIndex = 53;
      this.imgRaSpear.TabStop = false;
      this.imgRaSword.Image = (Image) Resources.weapon_sword;
      this.imgRaSword.Location = new Point(19, 23);
      this.imgRaSword.Name = "imgRaSword";
      this.imgRaSword.Size = new Size(23, 10);
      this.imgRaSword.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgRaSword.TabIndex = 52;
      this.imgRaSword.TabStop = false;
      this.pictureBox174.Image = (Image) Resources.type_weapons;
      this.pictureBox174.Location = new Point(19, 23);
      this.pictureBox174.Name = "pictureBox174";
      this.pictureBox174.Size = new Size(131, 82);
      this.pictureBox174.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox174.TabIndex = 47;
      this.pictureBox174.TabStop = false;
      this.lblRaLevel.AutoSize = true;
      this.lblRaLevel.Cursor = Cursors.Hand;
      this.lblRaLevel.Location = new Point(12, 32);
      this.lblRaLevel.Name = "lblRaLevel";
      this.lblRaLevel.Size = new Size(37, 13);
      this.lblRaLevel.TabIndex = 131;
      this.lblRaLevel.Text = "Level";
      this.lblRaLevel.Click += new EventHandler(this.classLevel_Click);
      this.txtRaLevel.AutoSize = true;
      this.txtRaLevel.Cursor = Cursors.Hand;
      this.txtRaLevel.Location = new Point(50, 32);
      this.txtRaLevel.Name = "txtRaLevel";
      this.txtRaLevel.Size = new Size(14, 13);
      this.txtRaLevel.TabIndex = 132;
      this.txtRaLevel.Text = "0";
      this.txtRaLevel.Click += new EventHandler(this.classLevel_Click);
      this.label35.AutoSize = true;
      this.label35.Cursor = Cursors.Hand;
      this.label35.Location = new Point(50, 32);
      this.label35.Name = "label35";
      this.label35.Size = new Size(14, 13);
      this.label35.TabIndex = 130;
      this.label35.Text = "0";
      this.label35.Click += new EventHandler(this.classLevel_Click);
      this.btnRaAbilitiesOpen.Cursor = Cursors.Hand;
      this.btnRaAbilitiesOpen.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnRaAbilitiesOpen.Location = new Point(543, 8);
      this.btnRaAbilitiesOpen.Name = "btnRaAbilitiesOpen";
      this.btnRaAbilitiesOpen.Size = new Size(61, 21);
      this.btnRaAbilitiesOpen.TabIndex = 135;
      this.btnRaAbilitiesOpen.Text = "Abilities";
      this.btnRaAbilitiesOpen.UseVisualStyleBackColor = true;
      this.btnRaAbilitiesOpen.Click += new EventHandler(this.btnRaAbilitiesOpen_Click);
      this.tabPageForce.Controls.Add((Control) this.label8);
      this.tabPageForce.Controls.Add((Control) this.grpFoTypeExtend);
      this.tabPageForce.Controls.Add((Control) this.lblFoLevel);
      this.tabPageForce.Controls.Add((Control) this.txtFoLevel);
      this.tabPageForce.Controls.Add((Control) this.btnFoAbilitiesOpen);
      this.tabPageForce.Font = new Font("Verdana", 8.25f);
      this.tabPageForce.Location = new Point(4, 21);
      this.tabPageForce.Name = "tabPageForce";
      this.tabPageForce.Padding = new Padding(3);
      this.tabPageForce.Size = new Size(610, 192);
      this.tabPageForce.TabIndex = 2;
      this.tabPageForce.Text = "Force (0)";
      this.tabPageForce.UseVisualStyleBackColor = true;
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.Location = new Point(11, 13);
      this.label8.Name = "label8";
      this.label8.Size = new Size(49, 16);
      this.label8.TabIndex = 138;
      this.label8.Text = "Force";
      this.grpFoTypeExtend.Controls.Add((Control) this.txtFoExp);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoTmagRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoMachinegunRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.txtFoExpBar);
      this.grpFoTypeExtend.Controls.Add((Control) this.label14);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoHandgunsRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.label15);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoShotgunRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoClawRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoDaggersRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSpearRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoWandRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoCardsRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoLaserRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoRifleRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoDaggerRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSabersRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoKnucklesRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoShieldRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoRmagRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoHandgunRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoLongbowRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoWhipRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoClawsRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoDblSaberRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoRodRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoCrossbowRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoGrenadeRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSlicerRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSaberRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoAxeRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSwordRank);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoRmag);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoMachinegun);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoCrossbow);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoCards);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoHandgun);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoHandguns);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoGrenade);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoLaser);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoLongbow);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoShotgun);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSlicer);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoRifle);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoWhip);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoClaw);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSaber);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoDagger);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoShield);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoTmag);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoRod);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoWand);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoClaws);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoDaggers);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoAxe);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSabers);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoDblSaber);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoKnuckles);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSpear);
      this.grpFoTypeExtend.Controls.Add((Control) this.imgFoSword);
      this.grpFoTypeExtend.Controls.Add((Control) this.pictureBox117);
      this.grpFoTypeExtend.Location = new Point(10, 58);
      this.grpFoTypeExtend.Name = "grpFoTypeExtend";
      this.grpFoTypeExtend.Size = new Size(304, 119);
      this.grpFoTypeExtend.TabIndex = 137;
      this.grpFoTypeExtend.TabStop = false;
      this.grpFoTypeExtend.Text = "Type Extend 0/0";
      this.txtFoExp.BackColor = Color.Transparent;
      this.txtFoExp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtFoExp.Location = new Point(194, 36);
      this.txtFoExp.Name = "txtFoExp";
      this.txtFoExp.Size = new Size(102, 69);
      this.txtFoExp.TabIndex = 109;
      this.txtFoExp.TextAlign = ContentAlignment.TopRight;
      this.imgFoTmagRank.Image = (Image) Resources.rank_C;
      this.imgFoTmagRank.Location = new Point(80, 95);
      this.imgFoTmagRank.Name = "imgFoTmagRank";
      this.imgFoTmagRank.Size = new Size(10, 10);
      this.imgFoTmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoTmagRank.TabIndex = 107;
      this.imgFoTmagRank.TabStop = false;
      this.imgFoMachinegunRank.Image = (Image) Resources.rank_C;
      this.imgFoMachinegunRank.Location = new Point(80, 83);
      this.imgFoMachinegunRank.Name = "imgFoMachinegunRank";
      this.imgFoMachinegunRank.Size = new Size(10, 10);
      this.imgFoMachinegunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoMachinegunRank.TabIndex = 106;
      this.imgFoMachinegunRank.TabStop = false;
      this.txtFoExpBar.BackColor = Color.Red;
      this.txtFoExpBar.Location = new Point(195, 23);
      this.txtFoExpBar.Name = "txtFoExpBar";
      this.txtFoExpBar.Size = new Size(87, 8);
      this.txtFoExpBar.TabIndex = 49;
      this.label14.AutoSize = true;
      this.label14.Location = new Point(159, 20);
      this.label14.Name = "label14";
      this.label14.Size = new Size(29, 13);
      this.label14.TabIndex = 48;
      this.label14.Text = "EXP";
      this.imgFoHandgunsRank.Image = (Image) Resources.rank_C;
      this.imgFoHandgunsRank.Location = new Point(80, 71);
      this.imgFoHandgunsRank.Name = "imgFoHandgunsRank";
      this.imgFoHandgunsRank.Size = new Size(10, 10);
      this.imgFoHandgunsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoHandgunsRank.TabIndex = 105;
      this.imgFoHandgunsRank.TabStop = false;
      this.label15.BackColor = Color.Gainsboro;
      this.label15.BorderStyle = BorderStyle.FixedSingle;
      this.label15.Location = new Point(194, 22);
      this.label15.Name = "label15";
      this.label15.Size = new Size(102, 10);
      this.label15.TabIndex = 50;
      this.imgFoShotgunRank.Image = (Image) Resources.rank_C;
      this.imgFoShotgunRank.Location = new Point(80, 59);
      this.imgFoShotgunRank.Name = "imgFoShotgunRank";
      this.imgFoShotgunRank.Size = new Size(10, 10);
      this.imgFoShotgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoShotgunRank.TabIndex = 104;
      this.imgFoShotgunRank.TabStop = false;
      this.imgFoClawRank.Image = (Image) Resources.rank_C;
      this.imgFoClawRank.Location = new Point(80, 47);
      this.imgFoClawRank.Name = "imgFoClawRank";
      this.imgFoClawRank.Size = new Size(10, 10);
      this.imgFoClawRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoClawRank.TabIndex = 103;
      this.imgFoClawRank.TabStop = false;
      this.imgFoDaggersRank.Image = (Image) Resources.rank_C;
      this.imgFoDaggersRank.Location = new Point(80, 35);
      this.imgFoDaggersRank.Name = "imgFoDaggersRank";
      this.imgFoDaggersRank.Size = new Size(10, 10);
      this.imgFoDaggersRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoDaggersRank.TabIndex = 102;
      this.imgFoDaggersRank.TabStop = false;
      this.imgFoSpearRank.Image = (Image) Resources.rank_C;
      this.imgFoSpearRank.Location = new Point(80, 23);
      this.imgFoSpearRank.Name = "imgFoSpearRank";
      this.imgFoSpearRank.Size = new Size(10, 10);
      this.imgFoSpearRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSpearRank.TabIndex = 101;
      this.imgFoSpearRank.TabStop = false;
      this.imgFoWandRank.Image = (Image) Resources.rank_B;
      this.imgFoWandRank.Location = new Point(44, 95);
      this.imgFoWandRank.Name = "imgFoWandRank";
      this.imgFoWandRank.Size = new Size(10, 10);
      this.imgFoWandRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoWandRank.TabIndex = 100;
      this.imgFoWandRank.TabStop = false;
      this.imgFoCardsRank.Image = (Image) Resources.rank_B;
      this.imgFoCardsRank.Location = new Point(44, 83);
      this.imgFoCardsRank.Name = "imgFoCardsRank";
      this.imgFoCardsRank.Size = new Size(10, 10);
      this.imgFoCardsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoCardsRank.TabIndex = 99;
      this.imgFoCardsRank.TabStop = false;
      this.imgFoLaserRank.Image = (Image) Resources.rank_B;
      this.imgFoLaserRank.Location = new Point(44, 71);
      this.imgFoLaserRank.Name = "imgFoLaserRank";
      this.imgFoLaserRank.Size = new Size(10, 10);
      this.imgFoLaserRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoLaserRank.TabIndex = 98;
      this.imgFoLaserRank.TabStop = false;
      this.imgFoRifleRank.Image = (Image) Resources.rank_B;
      this.imgFoRifleRank.Location = new Point(44, 59);
      this.imgFoRifleRank.Name = "imgFoRifleRank";
      this.imgFoRifleRank.Size = new Size(10, 10);
      this.imgFoRifleRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoRifleRank.TabIndex = 97;
      this.imgFoRifleRank.TabStop = false;
      this.imgFoDaggerRank.Image = (Image) Resources.rank_B;
      this.imgFoDaggerRank.Location = new Point(44, 47);
      this.imgFoDaggerRank.Name = "imgFoDaggerRank";
      this.imgFoDaggerRank.Size = new Size(10, 10);
      this.imgFoDaggerRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoDaggerRank.TabIndex = 96;
      this.imgFoDaggerRank.TabStop = false;
      this.imgFoSabersRank.Image = (Image) Resources.rank_B;
      this.imgFoSabersRank.Location = new Point(44, 35);
      this.imgFoSabersRank.Name = "imgFoSabersRank";
      this.imgFoSabersRank.Size = new Size(10, 10);
      this.imgFoSabersRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSabersRank.TabIndex = 95;
      this.imgFoSabersRank.TabStop = false;
      this.imgFoKnucklesRank.Image = (Image) Resources.rank_B;
      this.imgFoKnucklesRank.Location = new Point(44, 23);
      this.imgFoKnucklesRank.Name = "imgFoKnucklesRank";
      this.imgFoKnucklesRank.Size = new Size(10, 10);
      this.imgFoKnucklesRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoKnucklesRank.TabIndex = 94;
      this.imgFoKnucklesRank.TabStop = false;
      this.imgFoShieldRank.Image = (Image) Resources.rank_B;
      this.imgFoShieldRank.Location = new Point(116, 95);
      this.imgFoShieldRank.Name = "imgFoShieldRank";
      this.imgFoShieldRank.Size = new Size(10, 10);
      this.imgFoShieldRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoShieldRank.TabIndex = 93;
      this.imgFoShieldRank.TabStop = false;
      this.imgFoRmagRank.Image = (Image) Resources.rank_B;
      this.imgFoRmagRank.Location = new Point(116, 83);
      this.imgFoRmagRank.Name = "imgFoRmagRank";
      this.imgFoRmagRank.Size = new Size(10, 10);
      this.imgFoRmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoRmagRank.TabIndex = 92;
      this.imgFoRmagRank.TabStop = false;
      this.imgFoHandgunRank.Image = (Image) Resources.rank_B;
      this.imgFoHandgunRank.Location = new Point(116, 71);
      this.imgFoHandgunRank.Name = "imgFoHandgunRank";
      this.imgFoHandgunRank.Size = new Size(10, 10);
      this.imgFoHandgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoHandgunRank.TabIndex = 91;
      this.imgFoHandgunRank.TabStop = false;
      this.imgFoLongbowRank.Image = (Image) Resources.rank_B;
      this.imgFoLongbowRank.Location = new Point(116, 59);
      this.imgFoLongbowRank.Name = "imgFoLongbowRank";
      this.imgFoLongbowRank.Size = new Size(10, 10);
      this.imgFoLongbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoLongbowRank.TabIndex = 90;
      this.imgFoLongbowRank.TabStop = false;
      this.imgFoWhipRank.Image = (Image) Resources.rank_B;
      this.imgFoWhipRank.Location = new Point(116, 47);
      this.imgFoWhipRank.Name = "imgFoWhipRank";
      this.imgFoWhipRank.Size = new Size(10, 10);
      this.imgFoWhipRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoWhipRank.TabIndex = 89;
      this.imgFoWhipRank.TabStop = false;
      this.imgFoClawsRank.Image = (Image) Resources.rank_B;
      this.imgFoClawsRank.Location = new Point(116, 35);
      this.imgFoClawsRank.Name = "imgFoClawsRank";
      this.imgFoClawsRank.Size = new Size(10, 10);
      this.imgFoClawsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoClawsRank.TabIndex = 88;
      this.imgFoClawsRank.TabStop = false;
      this.imgFoDblSaberRank.Image = (Image) Resources.rank_B;
      this.imgFoDblSaberRank.Location = new Point(116, 23);
      this.imgFoDblSaberRank.Name = "imgFoDblSaberRank";
      this.imgFoDblSaberRank.Size = new Size(10, 10);
      this.imgFoDblSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoDblSaberRank.TabIndex = 87;
      this.imgFoDblSaberRank.TabStop = false;
      this.imgFoRodRank.Image = (Image) Resources.rank_C;
      this.imgFoRodRank.Location = new Point(8, 95);
      this.imgFoRodRank.Name = "imgFoRodRank";
      this.imgFoRodRank.Size = new Size(10, 10);
      this.imgFoRodRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoRodRank.TabIndex = 86;
      this.imgFoRodRank.TabStop = false;
      this.imgFoCrossbowRank.Image = (Image) Resources.rank_C;
      this.imgFoCrossbowRank.Location = new Point(8, 83);
      this.imgFoCrossbowRank.Name = "imgFoCrossbowRank";
      this.imgFoCrossbowRank.Size = new Size(10, 10);
      this.imgFoCrossbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoCrossbowRank.TabIndex = 85;
      this.imgFoCrossbowRank.TabStop = false;
      this.imgFoGrenadeRank.Image = (Image) Resources.rank_C;
      this.imgFoGrenadeRank.Location = new Point(8, 71);
      this.imgFoGrenadeRank.Name = "imgFoGrenadeRank";
      this.imgFoGrenadeRank.Size = new Size(10, 10);
      this.imgFoGrenadeRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoGrenadeRank.TabIndex = 84;
      this.imgFoGrenadeRank.TabStop = false;
      this.imgFoSlicerRank.Image = (Image) Resources.rank_C;
      this.imgFoSlicerRank.Location = new Point(8, 59);
      this.imgFoSlicerRank.Name = "imgFoSlicerRank";
      this.imgFoSlicerRank.Size = new Size(10, 10);
      this.imgFoSlicerRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSlicerRank.TabIndex = 83;
      this.imgFoSlicerRank.TabStop = false;
      this.imgFoSaberRank.Image = (Image) Resources.rank_C;
      this.imgFoSaberRank.Location = new Point(8, 47);
      this.imgFoSaberRank.Name = "imgFoSaberRank";
      this.imgFoSaberRank.Size = new Size(10, 10);
      this.imgFoSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSaberRank.TabIndex = 82;
      this.imgFoSaberRank.TabStop = false;
      this.imgFoAxeRank.Image = (Image) Resources.rank_C;
      this.imgFoAxeRank.Location = new Point(8, 35);
      this.imgFoAxeRank.Name = "imgFoAxeRank";
      this.imgFoAxeRank.Size = new Size(10, 10);
      this.imgFoAxeRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoAxeRank.TabIndex = 81;
      this.imgFoAxeRank.TabStop = false;
      this.imgFoSwordRank.Image = (Image) Resources.rank_C;
      this.imgFoSwordRank.Location = new Point(8, 23);
      this.imgFoSwordRank.Name = "imgFoSwordRank";
      this.imgFoSwordRank.Size = new Size(10, 10);
      this.imgFoSwordRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSwordRank.TabIndex = 80;
      this.imgFoSwordRank.TabStop = false;
      this.imgFoRmag.Image = (Image) Resources.weapon_rmag;
      this.imgFoRmag.Location = new Point((int) sbyte.MaxValue, 83);
      this.imgFoRmag.Name = "imgFoRmag";
      this.imgFoRmag.Size = new Size(10, 10);
      this.imgFoRmag.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoRmag.TabIndex = 79;
      this.imgFoRmag.TabStop = false;
      this.imgFoMachinegun.Image = (Image) Resources.weapon_machinegun;
      this.imgFoMachinegun.Location = new Point(91, 83);
      this.imgFoMachinegun.Name = "imgFoMachinegun";
      this.imgFoMachinegun.Size = new Size(10, 10);
      this.imgFoMachinegun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoMachinegun.TabIndex = 78;
      this.imgFoMachinegun.TabStop = false;
      this.imgFoCrossbow.Image = (Image) Resources.weapon_crossbow;
      this.imgFoCrossbow.Location = new Point(19, 83);
      this.imgFoCrossbow.Name = "imgFoCrossbow";
      this.imgFoCrossbow.Size = new Size(10, 10);
      this.imgFoCrossbow.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoCrossbow.TabIndex = 77;
      this.imgFoCrossbow.TabStop = false;
      this.imgFoCards.Image = (Image) Resources.weapon_card;
      this.imgFoCards.Location = new Point(55, 83);
      this.imgFoCards.Name = "imgFoCards";
      this.imgFoCards.Size = new Size(10, 10);
      this.imgFoCards.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoCards.TabIndex = 76;
      this.imgFoCards.TabStop = false;
      this.imgFoHandgun.Image = (Image) Resources.weapon_handgun;
      this.imgFoHandgun.Location = new Point((int) sbyte.MaxValue, 71);
      this.imgFoHandgun.Name = "imgFoHandgun";
      this.imgFoHandgun.Size = new Size(10, 10);
      this.imgFoHandgun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoHandgun.TabIndex = 75;
      this.imgFoHandgun.TabStop = false;
      this.imgFoHandguns.Image = (Image) Resources.weapon_handguns;
      this.imgFoHandguns.Location = new Point(91, 71);
      this.imgFoHandguns.Name = "imgFoHandguns";
      this.imgFoHandguns.Size = new Size(23, 10);
      this.imgFoHandguns.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoHandguns.TabIndex = 74;
      this.imgFoHandguns.TabStop = false;
      this.imgFoGrenade.Image = (Image) Resources.weapon_grenade;
      this.imgFoGrenade.Location = new Point(19, 71);
      this.imgFoGrenade.Name = "imgFoGrenade";
      this.imgFoGrenade.Size = new Size(23, 10);
      this.imgFoGrenade.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoGrenade.TabIndex = 73;
      this.imgFoGrenade.TabStop = false;
      this.imgFoLaser.Image = (Image) Resources.weapon_laser;
      this.imgFoLaser.Location = new Point(55, 71);
      this.imgFoLaser.Name = "imgFoLaser";
      this.imgFoLaser.Size = new Size(23, 10);
      this.imgFoLaser.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoLaser.TabIndex = 72;
      this.imgFoLaser.TabStop = false;
      this.imgFoLongbow.Image = (Image) Resources.weapon_longbow;
      this.imgFoLongbow.Location = new Point((int) sbyte.MaxValue, 59);
      this.imgFoLongbow.Name = "imgFoLongbow";
      this.imgFoLongbow.Size = new Size(23, 10);
      this.imgFoLongbow.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoLongbow.TabIndex = 71;
      this.imgFoLongbow.TabStop = false;
      this.imgFoShotgun.Image = (Image) Resources.weapon_shotgun;
      this.imgFoShotgun.Location = new Point(91, 59);
      this.imgFoShotgun.Name = "imgFoShotgun";
      this.imgFoShotgun.Size = new Size(23, 10);
      this.imgFoShotgun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoShotgun.TabIndex = 70;
      this.imgFoShotgun.TabStop = false;
      this.imgFoSlicer.Image = (Image) Resources.weapon_slicer;
      this.imgFoSlicer.Location = new Point(19, 59);
      this.imgFoSlicer.Name = "imgFoSlicer";
      this.imgFoSlicer.Size = new Size(10, 10);
      this.imgFoSlicer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSlicer.TabIndex = 69;
      this.imgFoSlicer.TabStop = false;
      this.imgFoRifle.Image = (Image) Resources.weapon_rifle;
      this.imgFoRifle.Location = new Point(55, 59);
      this.imgFoRifle.Name = "imgFoRifle";
      this.imgFoRifle.Size = new Size(23, 10);
      this.imgFoRifle.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoRifle.TabIndex = 68;
      this.imgFoRifle.TabStop = false;
      this.imgFoWhip.Image = (Image) Resources.weapon_whip;
      this.imgFoWhip.Location = new Point((int) sbyte.MaxValue, 47);
      this.imgFoWhip.Name = "imgFoWhip";
      this.imgFoWhip.Size = new Size(10, 10);
      this.imgFoWhip.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoWhip.TabIndex = 67;
      this.imgFoWhip.TabStop = false;
      this.imgFoClaw.Image = (Image) Resources.weapon_claw;
      this.imgFoClaw.Location = new Point(91, 47);
      this.imgFoClaw.Name = "imgFoClaw";
      this.imgFoClaw.Size = new Size(10, 10);
      this.imgFoClaw.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoClaw.TabIndex = 66;
      this.imgFoClaw.TabStop = false;
      this.imgFoSaber.Image = (Image) Resources.weapon_saber;
      this.imgFoSaber.Location = new Point(19, 47);
      this.imgFoSaber.Name = "imgFoSaber";
      this.imgFoSaber.Size = new Size(10, 10);
      this.imgFoSaber.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSaber.TabIndex = 65;
      this.imgFoSaber.TabStop = false;
      this.imgFoDagger.Image = (Image) Resources.weapon_dagger;
      this.imgFoDagger.Location = new Point(55, 47);
      this.imgFoDagger.Name = "imgFoDagger";
      this.imgFoDagger.Size = new Size(10, 10);
      this.imgFoDagger.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoDagger.TabIndex = 64;
      this.imgFoDagger.TabStop = false;
      this.imgFoShield.Image = (Image) Resources.weapon_shield;
      this.imgFoShield.Location = new Point((int) sbyte.MaxValue, 95);
      this.imgFoShield.Name = "imgFoShield";
      this.imgFoShield.Size = new Size(10, 10);
      this.imgFoShield.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoShield.TabIndex = 63;
      this.imgFoShield.TabStop = false;
      this.imgFoTmag.Image = (Image) Resources.weapon_tmag;
      this.imgFoTmag.Location = new Point(91, 95);
      this.imgFoTmag.Name = "imgFoTmag";
      this.imgFoTmag.Size = new Size(10, 10);
      this.imgFoTmag.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoTmag.TabIndex = 62;
      this.imgFoTmag.TabStop = false;
      this.imgFoRod.Image = (Image) Resources.weapon_rod;
      this.imgFoRod.Location = new Point(19, 95);
      this.imgFoRod.Name = "imgFoRod";
      this.imgFoRod.Size = new Size(23, 10);
      this.imgFoRod.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoRod.TabIndex = 61;
      this.imgFoRod.TabStop = false;
      this.imgFoWand.Image = (Image) Resources.weapon_wand;
      this.imgFoWand.Location = new Point(55, 95);
      this.imgFoWand.Name = "imgFoWand";
      this.imgFoWand.Size = new Size(10, 10);
      this.imgFoWand.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoWand.TabIndex = 60;
      this.imgFoWand.TabStop = false;
      this.imgFoClaws.Image = (Image) Resources.weapon_claws;
      this.imgFoClaws.Location = new Point((int) sbyte.MaxValue, 35);
      this.imgFoClaws.Name = "imgFoClaws";
      this.imgFoClaws.Size = new Size(23, 10);
      this.imgFoClaws.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoClaws.TabIndex = 59;
      this.imgFoClaws.TabStop = false;
      this.imgFoDaggers.Image = (Image) Resources.weapon_daggers;
      this.imgFoDaggers.Location = new Point(91, 35);
      this.imgFoDaggers.Name = "imgFoDaggers";
      this.imgFoDaggers.Size = new Size(23, 10);
      this.imgFoDaggers.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoDaggers.TabIndex = 58;
      this.imgFoDaggers.TabStop = false;
      this.imgFoAxe.Image = (Image) Resources.weapon_axe;
      this.imgFoAxe.Location = new Point(19, 35);
      this.imgFoAxe.Name = "imgFoAxe";
      this.imgFoAxe.Size = new Size(23, 10);
      this.imgFoAxe.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoAxe.TabIndex = 57;
      this.imgFoAxe.TabStop = false;
      this.imgFoSabers.Image = (Image) Resources.weapon_sabers;
      this.imgFoSabers.Location = new Point(55, 35);
      this.imgFoSabers.Name = "imgFoSabers";
      this.imgFoSabers.Size = new Size(23, 10);
      this.imgFoSabers.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSabers.TabIndex = 56;
      this.imgFoSabers.TabStop = false;
      this.imgFoDblSaber.Image = (Image) Resources.weapon_double_saber;
      this.imgFoDblSaber.Location = new Point((int) sbyte.MaxValue, 23);
      this.imgFoDblSaber.Name = "imgFoDblSaber";
      this.imgFoDblSaber.Size = new Size(23, 10);
      this.imgFoDblSaber.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoDblSaber.TabIndex = 55;
      this.imgFoDblSaber.TabStop = false;
      this.imgFoKnuckles.Image = (Image) Resources.weapon_knuckles;
      this.imgFoKnuckles.Location = new Point(55, 23);
      this.imgFoKnuckles.Name = "imgFoKnuckles";
      this.imgFoKnuckles.Size = new Size(23, 10);
      this.imgFoKnuckles.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoKnuckles.TabIndex = 54;
      this.imgFoKnuckles.TabStop = false;
      this.imgFoSpear.Image = (Image) Resources.weapon_spear;
      this.imgFoSpear.Location = new Point(91, 23);
      this.imgFoSpear.Name = "imgFoSpear";
      this.imgFoSpear.Size = new Size(23, 10);
      this.imgFoSpear.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSpear.TabIndex = 53;
      this.imgFoSpear.TabStop = false;
      this.imgFoSword.Image = (Image) Resources.weapon_sword;
      this.imgFoSword.Location = new Point(19, 23);
      this.imgFoSword.Name = "imgFoSword";
      this.imgFoSword.Size = new Size(23, 10);
      this.imgFoSword.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFoSword.TabIndex = 52;
      this.imgFoSword.TabStop = false;
      this.pictureBox117.Image = (Image) Resources.type_weapons;
      this.pictureBox117.Location = new Point(19, 23);
      this.pictureBox117.Name = "pictureBox117";
      this.pictureBox117.Size = new Size(131, 82);
      this.pictureBox117.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox117.TabIndex = 47;
      this.pictureBox117.TabStop = false;
      this.lblFoLevel.AutoSize = true;
      this.lblFoLevel.Cursor = Cursors.Hand;
      this.lblFoLevel.Location = new Point(12, 32);
      this.lblFoLevel.Name = "lblFoLevel";
      this.lblFoLevel.Size = new Size(37, 13);
      this.lblFoLevel.TabIndex = 136;
      this.lblFoLevel.Text = "Level";
      this.lblFoLevel.Click += new EventHandler(this.classLevel_Click);
      this.txtFoLevel.AutoSize = true;
      this.txtFoLevel.Cursor = Cursors.Hand;
      this.txtFoLevel.Location = new Point(50, 32);
      this.txtFoLevel.Name = "txtFoLevel";
      this.txtFoLevel.Size = new Size(14, 13);
      this.txtFoLevel.TabIndex = 135;
      this.txtFoLevel.Text = "0";
      this.txtFoLevel.Click += new EventHandler(this.classLevel_Click);
      this.btnFoAbilitiesOpen.Cursor = Cursors.Hand;
      this.btnFoAbilitiesOpen.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFoAbilitiesOpen.Location = new Point(543, 8);
      this.btnFoAbilitiesOpen.Name = "btnFoAbilitiesOpen";
      this.btnFoAbilitiesOpen.Size = new Size(61, 21);
      this.btnFoAbilitiesOpen.TabIndex = 139;
      this.btnFoAbilitiesOpen.Text = "Abilities";
      this.btnFoAbilitiesOpen.UseVisualStyleBackColor = true;
      this.btnFoAbilitiesOpen.Click += new EventHandler(this.btnFoAbilitiesOpen_Click);
      this.tabPageVanguard.Controls.Add((Control) this.label27);
      this.tabPageVanguard.Controls.Add((Control) this.grpVaTypeExtend);
      this.tabPageVanguard.Controls.Add((Control) this.txtVaLevel);
      this.tabPageVanguard.Controls.Add((Control) this.lblVaLevel);
      this.tabPageVanguard.Controls.Add((Control) this.btnVaAbilitiesOpen);
      this.tabPageVanguard.Font = new Font("Verdana", 8.25f);
      this.tabPageVanguard.Location = new Point(4, 21);
      this.tabPageVanguard.Name = "tabPageVanguard";
      this.tabPageVanguard.Padding = new Padding(3);
      this.tabPageVanguard.Size = new Size(610, 192);
      this.tabPageVanguard.TabIndex = 3;
      this.tabPageVanguard.Text = "Vanguard (0)";
      this.tabPageVanguard.UseVisualStyleBackColor = true;
      this.label27.AutoSize = true;
      this.label27.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label27.Location = new Point(11, 13);
      this.label27.Name = "label27";
      this.label27.Size = new Size(78, 16);
      this.label27.TabIndex = 138;
      this.label27.Text = "Vanguard";
      this.grpVaTypeExtend.Controls.Add((Control) this.txtVaExp);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaTmagRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaMachinegunRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.txtVaExpBar);
      this.grpVaTypeExtend.Controls.Add((Control) this.label28);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaHandgunsRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.label29);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaShotgunRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaClawRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaDaggersRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSpearRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaWandRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaCardsRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaLaserRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaRifleRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaDaggerRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSabersRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaKnucklesRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaShieldRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaRmagRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaHandgunRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaLongbowRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaWhipRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaClawsRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaDblSaberRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaRodRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaCrossbowRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaGrenadeRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSlicerRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSaberRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaAxeRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSwordRank);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaRmag);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaMachinegun);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaCrossbow);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaCards);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaHandgun);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaHandguns);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaGrenade);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaLaser);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaLongbow);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaShotgun);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSlicer);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaRifle);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaWhip);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaClaw);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSaber);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaDagger);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaShield);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaTmag);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaRod);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaWand);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaClaws);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaDaggers);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaAxe);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSabers);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaDblSaber);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaKnuckles);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSpear);
      this.grpVaTypeExtend.Controls.Add((Control) this.imgVaSword);
      this.grpVaTypeExtend.Controls.Add((Control) this.pictureBox5);
      this.grpVaTypeExtend.Location = new Point(10, 58);
      this.grpVaTypeExtend.Name = "grpVaTypeExtend";
      this.grpVaTypeExtend.Size = new Size(304, 119);
      this.grpVaTypeExtend.TabIndex = 137;
      this.grpVaTypeExtend.TabStop = false;
      this.grpVaTypeExtend.Text = "Type Extend 0/0";
      this.txtVaExp.BackColor = Color.Transparent;
      this.txtVaExp.Font = new Font("Verdana", 6.75f);
      this.txtVaExp.Location = new Point(194, 36);
      this.txtVaExp.Name = "txtVaExp";
      this.txtVaExp.Size = new Size(102, 69);
      this.txtVaExp.TabIndex = 110;
      this.txtVaExp.TextAlign = ContentAlignment.TopRight;
      this.imgVaTmagRank.Image = (Image) Resources.rank_C;
      this.imgVaTmagRank.Location = new Point(80, 95);
      this.imgVaTmagRank.Name = "imgVaTmagRank";
      this.imgVaTmagRank.Size = new Size(10, 10);
      this.imgVaTmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaTmagRank.TabIndex = 107;
      this.imgVaTmagRank.TabStop = false;
      this.imgVaMachinegunRank.Image = (Image) Resources.rank_C;
      this.imgVaMachinegunRank.Location = new Point(80, 83);
      this.imgVaMachinegunRank.Name = "imgVaMachinegunRank";
      this.imgVaMachinegunRank.Size = new Size(10, 10);
      this.imgVaMachinegunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaMachinegunRank.TabIndex = 106;
      this.imgVaMachinegunRank.TabStop = false;
      this.txtVaExpBar.BackColor = Color.Red;
      this.txtVaExpBar.Location = new Point(195, 23);
      this.txtVaExpBar.Name = "txtVaExpBar";
      this.txtVaExpBar.Size = new Size(87, 8);
      this.txtVaExpBar.TabIndex = 49;
      this.label28.AutoSize = true;
      this.label28.Location = new Point(159, 20);
      this.label28.Name = "label28";
      this.label28.Size = new Size(29, 13);
      this.label28.TabIndex = 48;
      this.label28.Text = "EXP";
      this.imgVaHandgunsRank.Image = (Image) Resources.rank_C;
      this.imgVaHandgunsRank.Location = new Point(80, 71);
      this.imgVaHandgunsRank.Name = "imgVaHandgunsRank";
      this.imgVaHandgunsRank.Size = new Size(10, 10);
      this.imgVaHandgunsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaHandgunsRank.TabIndex = 105;
      this.imgVaHandgunsRank.TabStop = false;
      this.label29.BackColor = Color.Gainsboro;
      this.label29.BorderStyle = BorderStyle.FixedSingle;
      this.label29.Location = new Point(194, 22);
      this.label29.Name = "label29";
      this.label29.Size = new Size(102, 10);
      this.label29.TabIndex = 50;
      this.imgVaShotgunRank.Image = (Image) Resources.rank_C;
      this.imgVaShotgunRank.Location = new Point(80, 59);
      this.imgVaShotgunRank.Name = "imgVaShotgunRank";
      this.imgVaShotgunRank.Size = new Size(10, 10);
      this.imgVaShotgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaShotgunRank.TabIndex = 104;
      this.imgVaShotgunRank.TabStop = false;
      this.imgVaClawRank.Image = (Image) Resources.rank_C;
      this.imgVaClawRank.Location = new Point(80, 47);
      this.imgVaClawRank.Name = "imgVaClawRank";
      this.imgVaClawRank.Size = new Size(10, 10);
      this.imgVaClawRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaClawRank.TabIndex = 103;
      this.imgVaClawRank.TabStop = false;
      this.imgVaDaggersRank.Image = (Image) Resources.rank_C;
      this.imgVaDaggersRank.Location = new Point(80, 35);
      this.imgVaDaggersRank.Name = "imgVaDaggersRank";
      this.imgVaDaggersRank.Size = new Size(10, 10);
      this.imgVaDaggersRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaDaggersRank.TabIndex = 102;
      this.imgVaDaggersRank.TabStop = false;
      this.imgVaSpearRank.Image = (Image) Resources.rank_C;
      this.imgVaSpearRank.Location = new Point(80, 23);
      this.imgVaSpearRank.Name = "imgVaSpearRank";
      this.imgVaSpearRank.Size = new Size(10, 10);
      this.imgVaSpearRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSpearRank.TabIndex = 101;
      this.imgVaSpearRank.TabStop = false;
      this.imgVaWandRank.Image = (Image) Resources.rank_B;
      this.imgVaWandRank.Location = new Point(44, 95);
      this.imgVaWandRank.Name = "imgVaWandRank";
      this.imgVaWandRank.Size = new Size(10, 10);
      this.imgVaWandRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaWandRank.TabIndex = 100;
      this.imgVaWandRank.TabStop = false;
      this.imgVaCardsRank.Image = (Image) Resources.rank_B;
      this.imgVaCardsRank.Location = new Point(44, 83);
      this.imgVaCardsRank.Name = "imgVaCardsRank";
      this.imgVaCardsRank.Size = new Size(10, 10);
      this.imgVaCardsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaCardsRank.TabIndex = 99;
      this.imgVaCardsRank.TabStop = false;
      this.imgVaLaserRank.Image = (Image) Resources.rank_B;
      this.imgVaLaserRank.Location = new Point(44, 71);
      this.imgVaLaserRank.Name = "imgVaLaserRank";
      this.imgVaLaserRank.Size = new Size(10, 10);
      this.imgVaLaserRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaLaserRank.TabIndex = 98;
      this.imgVaLaserRank.TabStop = false;
      this.imgVaRifleRank.Image = (Image) Resources.rank_B;
      this.imgVaRifleRank.Location = new Point(44, 59);
      this.imgVaRifleRank.Name = "imgVaRifleRank";
      this.imgVaRifleRank.Size = new Size(10, 10);
      this.imgVaRifleRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaRifleRank.TabIndex = 97;
      this.imgVaRifleRank.TabStop = false;
      this.imgVaDaggerRank.Image = (Image) Resources.rank_B;
      this.imgVaDaggerRank.Location = new Point(44, 47);
      this.imgVaDaggerRank.Name = "imgVaDaggerRank";
      this.imgVaDaggerRank.Size = new Size(10, 10);
      this.imgVaDaggerRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaDaggerRank.TabIndex = 96;
      this.imgVaDaggerRank.TabStop = false;
      this.imgVaSabersRank.Image = (Image) Resources.rank_B;
      this.imgVaSabersRank.Location = new Point(44, 35);
      this.imgVaSabersRank.Name = "imgVaSabersRank";
      this.imgVaSabersRank.Size = new Size(10, 10);
      this.imgVaSabersRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSabersRank.TabIndex = 95;
      this.imgVaSabersRank.TabStop = false;
      this.imgVaKnucklesRank.Image = (Image) Resources.rank_B;
      this.imgVaKnucklesRank.Location = new Point(44, 23);
      this.imgVaKnucklesRank.Name = "imgVaKnucklesRank";
      this.imgVaKnucklesRank.Size = new Size(10, 10);
      this.imgVaKnucklesRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaKnucklesRank.TabIndex = 94;
      this.imgVaKnucklesRank.TabStop = false;
      this.imgVaShieldRank.Image = (Image) Resources.rank_B;
      this.imgVaShieldRank.Location = new Point(116, 95);
      this.imgVaShieldRank.Name = "imgVaShieldRank";
      this.imgVaShieldRank.Size = new Size(10, 10);
      this.imgVaShieldRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaShieldRank.TabIndex = 93;
      this.imgVaShieldRank.TabStop = false;
      this.imgVaRmagRank.Image = (Image) Resources.rank_B;
      this.imgVaRmagRank.Location = new Point(116, 83);
      this.imgVaRmagRank.Name = "imgVaRmagRank";
      this.imgVaRmagRank.Size = new Size(10, 10);
      this.imgVaRmagRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaRmagRank.TabIndex = 92;
      this.imgVaRmagRank.TabStop = false;
      this.imgVaHandgunRank.Image = (Image) Resources.rank_B;
      this.imgVaHandgunRank.Location = new Point(116, 71);
      this.imgVaHandgunRank.Name = "imgVaHandgunRank";
      this.imgVaHandgunRank.Size = new Size(10, 10);
      this.imgVaHandgunRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaHandgunRank.TabIndex = 91;
      this.imgVaHandgunRank.TabStop = false;
      this.imgVaLongbowRank.Image = (Image) Resources.rank_B;
      this.imgVaLongbowRank.Location = new Point(116, 59);
      this.imgVaLongbowRank.Name = "imgVaLongbowRank";
      this.imgVaLongbowRank.Size = new Size(10, 10);
      this.imgVaLongbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaLongbowRank.TabIndex = 90;
      this.imgVaLongbowRank.TabStop = false;
      this.imgVaWhipRank.Image = (Image) Resources.rank_B;
      this.imgVaWhipRank.Location = new Point(116, 47);
      this.imgVaWhipRank.Name = "imgVaWhipRank";
      this.imgVaWhipRank.Size = new Size(10, 10);
      this.imgVaWhipRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaWhipRank.TabIndex = 89;
      this.imgVaWhipRank.TabStop = false;
      this.imgVaClawsRank.Image = (Image) Resources.rank_B;
      this.imgVaClawsRank.Location = new Point(116, 35);
      this.imgVaClawsRank.Name = "imgVaClawsRank";
      this.imgVaClawsRank.Size = new Size(10, 10);
      this.imgVaClawsRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaClawsRank.TabIndex = 88;
      this.imgVaClawsRank.TabStop = false;
      this.imgVaDblSaberRank.Image = (Image) Resources.rank_B;
      this.imgVaDblSaberRank.Location = new Point(116, 23);
      this.imgVaDblSaberRank.Name = "imgVaDblSaberRank";
      this.imgVaDblSaberRank.Size = new Size(10, 10);
      this.imgVaDblSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaDblSaberRank.TabIndex = 87;
      this.imgVaDblSaberRank.TabStop = false;
      this.imgVaRodRank.Image = (Image) Resources.rank_C;
      this.imgVaRodRank.Location = new Point(8, 95);
      this.imgVaRodRank.Name = "imgVaRodRank";
      this.imgVaRodRank.Size = new Size(10, 10);
      this.imgVaRodRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaRodRank.TabIndex = 86;
      this.imgVaRodRank.TabStop = false;
      this.imgVaCrossbowRank.Image = (Image) Resources.rank_C;
      this.imgVaCrossbowRank.Location = new Point(8, 83);
      this.imgVaCrossbowRank.Name = "imgVaCrossbowRank";
      this.imgVaCrossbowRank.Size = new Size(10, 10);
      this.imgVaCrossbowRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaCrossbowRank.TabIndex = 85;
      this.imgVaCrossbowRank.TabStop = false;
      this.imgVaGrenadeRank.Image = (Image) Resources.rank_C;
      this.imgVaGrenadeRank.Location = new Point(8, 71);
      this.imgVaGrenadeRank.Name = "imgVaGrenadeRank";
      this.imgVaGrenadeRank.Size = new Size(10, 10);
      this.imgVaGrenadeRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaGrenadeRank.TabIndex = 84;
      this.imgVaGrenadeRank.TabStop = false;
      this.imgVaSlicerRank.Image = (Image) Resources.rank_C;
      this.imgVaSlicerRank.Location = new Point(8, 59);
      this.imgVaSlicerRank.Name = "imgVaSlicerRank";
      this.imgVaSlicerRank.Size = new Size(10, 10);
      this.imgVaSlicerRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSlicerRank.TabIndex = 83;
      this.imgVaSlicerRank.TabStop = false;
      this.imgVaSaberRank.Image = (Image) Resources.rank_C;
      this.imgVaSaberRank.Location = new Point(8, 47);
      this.imgVaSaberRank.Name = "imgVaSaberRank";
      this.imgVaSaberRank.Size = new Size(10, 10);
      this.imgVaSaberRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSaberRank.TabIndex = 82;
      this.imgVaSaberRank.TabStop = false;
      this.imgVaAxeRank.Image = (Image) Resources.rank_C;
      this.imgVaAxeRank.Location = new Point(8, 35);
      this.imgVaAxeRank.Name = "imgVaAxeRank";
      this.imgVaAxeRank.Size = new Size(10, 10);
      this.imgVaAxeRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaAxeRank.TabIndex = 81;
      this.imgVaAxeRank.TabStop = false;
      this.imgVaSwordRank.Image = (Image) Resources.rank_C;
      this.imgVaSwordRank.Location = new Point(8, 23);
      this.imgVaSwordRank.Name = "imgVaSwordRank";
      this.imgVaSwordRank.Size = new Size(10, 10);
      this.imgVaSwordRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSwordRank.TabIndex = 80;
      this.imgVaSwordRank.TabStop = false;
      this.imgVaRmag.Image = (Image) Resources.weapon_rmag;
      this.imgVaRmag.Location = new Point((int) sbyte.MaxValue, 83);
      this.imgVaRmag.Name = "imgVaRmag";
      this.imgVaRmag.Size = new Size(10, 10);
      this.imgVaRmag.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaRmag.TabIndex = 79;
      this.imgVaRmag.TabStop = false;
      this.imgVaMachinegun.Image = (Image) Resources.weapon_machinegun;
      this.imgVaMachinegun.Location = new Point(91, 83);
      this.imgVaMachinegun.Name = "imgVaMachinegun";
      this.imgVaMachinegun.Size = new Size(10, 10);
      this.imgVaMachinegun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaMachinegun.TabIndex = 78;
      this.imgVaMachinegun.TabStop = false;
      this.imgVaCrossbow.Image = (Image) Resources.weapon_crossbow;
      this.imgVaCrossbow.Location = new Point(19, 83);
      this.imgVaCrossbow.Name = "imgVaCrossbow";
      this.imgVaCrossbow.Size = new Size(10, 10);
      this.imgVaCrossbow.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaCrossbow.TabIndex = 77;
      this.imgVaCrossbow.TabStop = false;
      this.imgVaCards.Image = (Image) Resources.weapon_card;
      this.imgVaCards.Location = new Point(55, 83);
      this.imgVaCards.Name = "imgVaCards";
      this.imgVaCards.Size = new Size(10, 10);
      this.imgVaCards.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaCards.TabIndex = 76;
      this.imgVaCards.TabStop = false;
      this.imgVaHandgun.Image = (Image) Resources.weapon_handgun;
      this.imgVaHandgun.Location = new Point((int) sbyte.MaxValue, 71);
      this.imgVaHandgun.Name = "imgVaHandgun";
      this.imgVaHandgun.Size = new Size(10, 10);
      this.imgVaHandgun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaHandgun.TabIndex = 75;
      this.imgVaHandgun.TabStop = false;
      this.imgVaHandguns.Image = (Image) Resources.weapon_handguns;
      this.imgVaHandguns.Location = new Point(91, 71);
      this.imgVaHandguns.Name = "imgVaHandguns";
      this.imgVaHandguns.Size = new Size(23, 10);
      this.imgVaHandguns.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaHandguns.TabIndex = 74;
      this.imgVaHandguns.TabStop = false;
      this.imgVaGrenade.Image = (Image) Resources.weapon_grenade;
      this.imgVaGrenade.Location = new Point(19, 71);
      this.imgVaGrenade.Name = "imgVaGrenade";
      this.imgVaGrenade.Size = new Size(23, 10);
      this.imgVaGrenade.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaGrenade.TabIndex = 73;
      this.imgVaGrenade.TabStop = false;
      this.imgVaLaser.Image = (Image) Resources.weapon_laser;
      this.imgVaLaser.Location = new Point(55, 71);
      this.imgVaLaser.Name = "imgVaLaser";
      this.imgVaLaser.Size = new Size(23, 10);
      this.imgVaLaser.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaLaser.TabIndex = 72;
      this.imgVaLaser.TabStop = false;
      this.imgVaLongbow.Image = (Image) Resources.weapon_longbow;
      this.imgVaLongbow.Location = new Point((int) sbyte.MaxValue, 59);
      this.imgVaLongbow.Name = "imgVaLongbow";
      this.imgVaLongbow.Size = new Size(23, 10);
      this.imgVaLongbow.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaLongbow.TabIndex = 71;
      this.imgVaLongbow.TabStop = false;
      this.imgVaShotgun.Image = (Image) Resources.weapon_shotgun;
      this.imgVaShotgun.Location = new Point(91, 59);
      this.imgVaShotgun.Name = "imgVaShotgun";
      this.imgVaShotgun.Size = new Size(23, 10);
      this.imgVaShotgun.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaShotgun.TabIndex = 70;
      this.imgVaShotgun.TabStop = false;
      this.imgVaSlicer.Image = (Image) Resources.weapon_slicer;
      this.imgVaSlicer.Location = new Point(19, 59);
      this.imgVaSlicer.Name = "imgVaSlicer";
      this.imgVaSlicer.Size = new Size(10, 10);
      this.imgVaSlicer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSlicer.TabIndex = 69;
      this.imgVaSlicer.TabStop = false;
      this.imgVaRifle.Image = (Image) Resources.weapon_rifle;
      this.imgVaRifle.Location = new Point(55, 59);
      this.imgVaRifle.Name = "imgVaRifle";
      this.imgVaRifle.Size = new Size(23, 10);
      this.imgVaRifle.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaRifle.TabIndex = 68;
      this.imgVaRifle.TabStop = false;
      this.imgVaWhip.Image = (Image) Resources.weapon_whip;
      this.imgVaWhip.Location = new Point((int) sbyte.MaxValue, 47);
      this.imgVaWhip.Name = "imgVaWhip";
      this.imgVaWhip.Size = new Size(10, 10);
      this.imgVaWhip.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaWhip.TabIndex = 67;
      this.imgVaWhip.TabStop = false;
      this.imgVaClaw.Image = (Image) Resources.weapon_claw;
      this.imgVaClaw.Location = new Point(91, 47);
      this.imgVaClaw.Name = "imgVaClaw";
      this.imgVaClaw.Size = new Size(10, 10);
      this.imgVaClaw.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaClaw.TabIndex = 66;
      this.imgVaClaw.TabStop = false;
      this.imgVaSaber.Image = (Image) Resources.weapon_saber;
      this.imgVaSaber.Location = new Point(19, 47);
      this.imgVaSaber.Name = "imgVaSaber";
      this.imgVaSaber.Size = new Size(10, 10);
      this.imgVaSaber.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSaber.TabIndex = 65;
      this.imgVaSaber.TabStop = false;
      this.imgVaDagger.Image = (Image) Resources.weapon_dagger;
      this.imgVaDagger.Location = new Point(55, 47);
      this.imgVaDagger.Name = "imgVaDagger";
      this.imgVaDagger.Size = new Size(10, 10);
      this.imgVaDagger.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaDagger.TabIndex = 64;
      this.imgVaDagger.TabStop = false;
      this.imgVaShield.Image = (Image) Resources.weapon_shield;
      this.imgVaShield.Location = new Point((int) sbyte.MaxValue, 95);
      this.imgVaShield.Name = "imgVaShield";
      this.imgVaShield.Size = new Size(10, 10);
      this.imgVaShield.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaShield.TabIndex = 63;
      this.imgVaShield.TabStop = false;
      this.imgVaTmag.Image = (Image) Resources.weapon_tmag;
      this.imgVaTmag.Location = new Point(91, 95);
      this.imgVaTmag.Name = "imgVaTmag";
      this.imgVaTmag.Size = new Size(10, 10);
      this.imgVaTmag.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaTmag.TabIndex = 62;
      this.imgVaTmag.TabStop = false;
      this.imgVaRod.Image = (Image) Resources.weapon_rod;
      this.imgVaRod.Location = new Point(19, 95);
      this.imgVaRod.Name = "imgVaRod";
      this.imgVaRod.Size = new Size(23, 10);
      this.imgVaRod.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaRod.TabIndex = 61;
      this.imgVaRod.TabStop = false;
      this.imgVaWand.Image = (Image) Resources.weapon_wand;
      this.imgVaWand.Location = new Point(55, 95);
      this.imgVaWand.Name = "imgVaWand";
      this.imgVaWand.Size = new Size(10, 10);
      this.imgVaWand.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaWand.TabIndex = 60;
      this.imgVaWand.TabStop = false;
      this.imgVaClaws.Image = (Image) Resources.weapon_claws;
      this.imgVaClaws.Location = new Point((int) sbyte.MaxValue, 35);
      this.imgVaClaws.Name = "imgVaClaws";
      this.imgVaClaws.Size = new Size(23, 10);
      this.imgVaClaws.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaClaws.TabIndex = 59;
      this.imgVaClaws.TabStop = false;
      this.imgVaDaggers.Image = (Image) Resources.weapon_daggers;
      this.imgVaDaggers.Location = new Point(91, 35);
      this.imgVaDaggers.Name = "imgVaDaggers";
      this.imgVaDaggers.Size = new Size(23, 10);
      this.imgVaDaggers.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaDaggers.TabIndex = 58;
      this.imgVaDaggers.TabStop = false;
      this.imgVaAxe.Image = (Image) Resources.weapon_axe;
      this.imgVaAxe.Location = new Point(19, 35);
      this.imgVaAxe.Name = "imgVaAxe";
      this.imgVaAxe.Size = new Size(23, 10);
      this.imgVaAxe.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaAxe.TabIndex = 57;
      this.imgVaAxe.TabStop = false;
      this.imgVaSabers.Image = (Image) Resources.weapon_sabers;
      this.imgVaSabers.Location = new Point(55, 35);
      this.imgVaSabers.Name = "imgVaSabers";
      this.imgVaSabers.Size = new Size(23, 10);
      this.imgVaSabers.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSabers.TabIndex = 56;
      this.imgVaSabers.TabStop = false;
      this.imgVaDblSaber.Image = (Image) Resources.weapon_double_saber;
      this.imgVaDblSaber.Location = new Point((int) sbyte.MaxValue, 23);
      this.imgVaDblSaber.Name = "imgVaDblSaber";
      this.imgVaDblSaber.Size = new Size(23, 10);
      this.imgVaDblSaber.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaDblSaber.TabIndex = 55;
      this.imgVaDblSaber.TabStop = false;
      this.imgVaKnuckles.Image = (Image) Resources.weapon_knuckles;
      this.imgVaKnuckles.Location = new Point(55, 23);
      this.imgVaKnuckles.Name = "imgVaKnuckles";
      this.imgVaKnuckles.Size = new Size(23, 10);
      this.imgVaKnuckles.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaKnuckles.TabIndex = 54;
      this.imgVaKnuckles.TabStop = false;
      this.imgVaSpear.Image = (Image) Resources.weapon_spear;
      this.imgVaSpear.Location = new Point(91, 23);
      this.imgVaSpear.Name = "imgVaSpear";
      this.imgVaSpear.Size = new Size(23, 10);
      this.imgVaSpear.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSpear.TabIndex = 53;
      this.imgVaSpear.TabStop = false;
      this.imgVaSword.Image = (Image) Resources.weapon_sword;
      this.imgVaSword.Location = new Point(19, 23);
      this.imgVaSword.Name = "imgVaSword";
      this.imgVaSword.Size = new Size(23, 10);
      this.imgVaSword.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgVaSword.TabIndex = 52;
      this.imgVaSword.TabStop = false;
      this.pictureBox5.Image = (Image) Resources.type_weapons;
      this.pictureBox5.Location = new Point(19, 23);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(131, 82);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox5.TabIndex = 47;
      this.pictureBox5.TabStop = false;
      this.txtVaLevel.AutoSize = true;
      this.txtVaLevel.Cursor = Cursors.Hand;
      this.txtVaLevel.Location = new Point(50, 32);
      this.txtVaLevel.Name = "txtVaLevel";
      this.txtVaLevel.Size = new Size(14, 13);
      this.txtVaLevel.TabIndex = 136;
      this.txtVaLevel.Text = "0";
      this.txtVaLevel.Click += new EventHandler(this.classLevel_Click);
      this.lblVaLevel.AutoSize = true;
      this.lblVaLevel.Cursor = Cursors.Hand;
      this.lblVaLevel.Location = new Point(12, 32);
      this.lblVaLevel.Name = "lblVaLevel";
      this.lblVaLevel.Size = new Size(37, 13);
      this.lblVaLevel.TabIndex = 135;
      this.lblVaLevel.Text = "Level";
      this.lblVaLevel.Click += new EventHandler(this.classLevel_Click);
      this.btnVaAbilitiesOpen.Cursor = Cursors.Hand;
      this.btnVaAbilitiesOpen.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnVaAbilitiesOpen.Location = new Point(543, 8);
      this.btnVaAbilitiesOpen.Name = "btnVaAbilitiesOpen";
      this.btnVaAbilitiesOpen.Size = new Size(61, 21);
      this.btnVaAbilitiesOpen.TabIndex = 139;
      this.btnVaAbilitiesOpen.Text = "Abilities";
      this.btnVaAbilitiesOpen.UseVisualStyleBackColor = true;
      this.btnVaAbilitiesOpen.Click += new EventHandler(this.btnVaAbilitiesOpen_Click);
      this.tabPageInventory.Controls.Add((Control) this.btnInventoryDelete);
      this.tabPageInventory.Controls.Add((Control) this.chkDeleteExportInventory);
      this.tabPageInventory.Controls.Add((Control) this.btnInventoryDeposit);
      this.tabPageInventory.Controls.Add((Control) this.inventoryViewPages);
      this.tabPageInventory.Controls.Add((Control) this.btnInventoryImportSelected);
      this.tabPageInventory.Controls.Add((Control) this.btnInventoryExportSelected);
      this.tabPageInventory.Controls.Add((Control) this.btnInventoryImportAll);
      this.tabPageInventory.Controls.Add((Control) this.btnInventoryExportAll);
      this.tabPageInventory.Controls.Add((Control) this.txtInventoryMeseta);
      this.tabPageInventory.Controls.Add((Control) this.lblInventoryMeseta);
      this.tabPageInventory.Controls.Add((Control) this.grpInventoryItemDetails);
      this.tabPageInventory.Controls.Add((Control) this.groupBox2);
      this.tabPageInventory.Controls.Add((Control) this.txtInventoryHex);
      this.tabPageInventory.Controls.Add((Control) this.pictureBox7);
      this.tabPageInventory.Controls.Add((Control) this.inventoryView);
      this.tabPageInventory.Cursor = Cursors.Default;
      this.tabPageInventory.Location = new Point(4, 22);
      this.tabPageInventory.Name = "tabPageInventory";
      this.tabPageInventory.Size = new Size(629, 223);
      this.tabPageInventory.TabIndex = 6;
      this.tabPageInventory.Text = "Inventory (0/60)";
      this.tabPageInventory.UseVisualStyleBackColor = true;
      this.btnInventoryDelete.Cursor = Cursors.Hand;
      this.btnInventoryDelete.Enabled = false;
      this.btnInventoryDelete.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnInventoryDelete.Location = new Point(391, 177);
      this.btnInventoryDelete.Name = "btnInventoryDelete";
      this.btnInventoryDelete.Size = new Size(46, 21);
      this.btnInventoryDelete.TabIndex = 76;
      this.btnInventoryDelete.Text = "delete";
      this.btnInventoryDelete.UseVisualStyleBackColor = true;
      this.btnInventoryDelete.Click += new EventHandler(this.btnInventoryDelete_Click);
      this.chkDeleteExportInventory.AutoSize = true;
      this.chkDeleteExportInventory.Cursor = Cursors.Hand;
      this.chkDeleteExportInventory.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkDeleteExportInventory.Location = new Point(497, 206);
      this.chkDeleteExportInventory.Name = "chkDeleteExportInventory";
      this.chkDeleteExportInventory.RightToLeft = RightToLeft.Yes;
      this.chkDeleteExportInventory.Size = new Size(125, 14);
      this.chkDeleteExportInventory.TabIndex = 75;
      this.chkDeleteExportInventory.Text = "delete items after export";
      this.chkDeleteExportInventory.UseVisualStyleBackColor = true;
      this.btnInventoryDeposit.Cursor = Cursors.Hand;
      this.btnInventoryDeposit.Enabled = false;
      this.btnInventoryDeposit.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnInventoryDeposit.Location = new Point(566, 177);
      this.btnInventoryDeposit.Name = "btnInventoryDeposit";
      this.btnInventoryDeposit.Size = new Size(56, 21);
      this.btnInventoryDeposit.TabIndex = 74;
      this.btnInventoryDeposit.Text = "deposit";
      this.btnInventoryDeposit.UseVisualStyleBackColor = true;
      this.btnInventoryDeposit.Click += new EventHandler(this.btnInventoryDeposit_Click);
      this.inventoryViewPages.Controls.Add((Control) this.tabInventory1);
      this.inventoryViewPages.Controls.Add((Control) this.tabInventory2);
      this.inventoryViewPages.Controls.Add((Control) this.tabInventory3);
      this.inventoryViewPages.Controls.Add((Control) this.tabInventory4);
      this.inventoryViewPages.Controls.Add((Control) this.tabInventory5);
      this.inventoryViewPages.Controls.Add((Control) this.tabInventory6);
      this.inventoryViewPages.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.inventoryViewPages.Location = new Point(5, 12);
      this.inventoryViewPages.Name = "inventoryViewPages";
      this.inventoryViewPages.SelectedIndex = 0;
      this.inventoryViewPages.Size = new Size(315, 19);
      this.inventoryViewPages.TabIndex = 73;
      this.inventoryViewPages.SelectedIndexChanged += new EventHandler(this.inventoryViewPages_SelectedIndexChanged);
      this.tabInventory1.Cursor = Cursors.Default;
      this.tabInventory1.Location = new Point(4, 19);
      this.tabInventory1.Name = "tabInventory1";
      this.tabInventory1.Padding = new Padding(3);
      this.tabInventory1.Size = new Size(307, 0);
      this.tabInventory1.TabIndex = 0;
      this.tabInventory1.Text = "1";
      this.tabInventory1.UseVisualStyleBackColor = true;
      this.tabInventory2.Cursor = Cursors.Default;
      this.tabInventory2.Location = new Point(4, 19);
      this.tabInventory2.Name = "tabInventory2";
      this.tabInventory2.Padding = new Padding(3);
      this.tabInventory2.Size = new Size(307, 0);
      this.tabInventory2.TabIndex = 1;
      this.tabInventory2.Text = "2";
      this.tabInventory2.UseVisualStyleBackColor = true;
      this.tabInventory3.Cursor = Cursors.Default;
      this.tabInventory3.Location = new Point(4, 19);
      this.tabInventory3.Name = "tabInventory3";
      this.tabInventory3.Size = new Size(307, 0);
      this.tabInventory3.TabIndex = 2;
      this.tabInventory3.Text = "3";
      this.tabInventory3.UseVisualStyleBackColor = true;
      this.tabInventory4.Cursor = Cursors.Default;
      this.tabInventory4.Location = new Point(4, 19);
      this.tabInventory4.Name = "tabInventory4";
      this.tabInventory4.Size = new Size(307, 0);
      this.tabInventory4.TabIndex = 3;
      this.tabInventory4.Text = "4";
      this.tabInventory4.UseVisualStyleBackColor = true;
      this.tabInventory5.Cursor = Cursors.Default;
      this.tabInventory5.Location = new Point(4, 19);
      this.tabInventory5.Name = "tabInventory5";
      this.tabInventory5.Size = new Size(307, 0);
      this.tabInventory5.TabIndex = 4;
      this.tabInventory5.Text = "5";
      this.tabInventory5.UseVisualStyleBackColor = true;
      this.tabInventory6.Cursor = Cursors.Default;
      this.tabInventory6.Location = new Point(4, 19);
      this.tabInventory6.Name = "tabInventory6";
      this.tabInventory6.Size = new Size(307, 0);
      this.tabInventory6.TabIndex = 5;
      this.tabInventory6.Text = "Free Slots";
      this.tabInventory6.UseVisualStyleBackColor = true;
      this.btnInventoryImportSelected.Cursor = Cursors.Hand;
      this.btnInventoryImportSelected.Enabled = false;
      this.btnInventoryImportSelected.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnInventoryImportSelected.Location = new Point(437, 177);
      this.btnInventoryImportSelected.Name = "btnInventoryImportSelected";
      this.btnInventoryImportSelected.Size = new Size(67, 21);
      this.btnInventoryImportSelected.TabIndex = 72;
      this.btnInventoryImportSelected.Text = "import item";
      this.btnInventoryImportSelected.UseVisualStyleBackColor = true;
      this.btnInventoryImportSelected.Click += new EventHandler(this.btnInventoryImportSelected_Click);
      this.btnInventoryExportSelected.Cursor = Cursors.Hand;
      this.btnInventoryExportSelected.Enabled = false;
      this.btnInventoryExportSelected.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnInventoryExportSelected.Location = new Point(504, 177);
      this.btnInventoryExportSelected.Name = "btnInventoryExportSelected";
      this.btnInventoryExportSelected.Size = new Size(62, 21);
      this.btnInventoryExportSelected.TabIndex = 71;
      this.btnInventoryExportSelected.Text = "export item";
      this.btnInventoryExportSelected.UseVisualStyleBackColor = true;
      this.btnInventoryExportSelected.Click += new EventHandler(this.btnInventoryExportSelected_Click);
      this.btnInventoryImportAll.Cursor = Cursors.Hand;
      this.btnInventoryImportAll.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnInventoryImportAll.Location = new Point(152, 183);
      this.btnInventoryImportAll.Name = "btnInventoryImportAll";
      this.btnInventoryImportAll.Size = new Size(82, 21);
      this.btnInventoryImportAll.TabIndex = 50;
      this.btnInventoryImportAll.Text = "import inventory";
      this.btnInventoryImportAll.UseVisualStyleBackColor = true;
      this.btnInventoryImportAll.Click += new EventHandler(this.btnInventoryImportAll_Click);
      this.btnInventoryExportAll.Cursor = Cursors.Hand;
      this.btnInventoryExportAll.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnInventoryExportAll.Location = new Point(236, 183);
      this.btnInventoryExportAll.Name = "btnInventoryExportAll";
      this.btnInventoryExportAll.Size = new Size(82, 21);
      this.btnInventoryExportAll.TabIndex = 49;
      this.btnInventoryExportAll.Text = "export inventory";
      this.btnInventoryExportAll.UseVisualStyleBackColor = true;
      this.btnInventoryExportAll.Click += new EventHandler(this.btnInventoryExportAll_Click);
      this.txtInventoryMeseta.AutoSize = true;
      this.txtInventoryMeseta.Cursor = Cursors.Hand;
      this.txtInventoryMeseta.Location = new Point(60, 182);
      this.txtInventoryMeseta.Name = "txtInventoryMeseta";
      this.txtInventoryMeseta.Size = new Size(14, 13);
      this.txtInventoryMeseta.TabIndex = 27;
      this.txtInventoryMeseta.Text = "0";
      this.txtInventoryMeseta.Click += new EventHandler(this.txtInventoryMeseta_Click);
      this.lblInventoryMeseta.AutoSize = true;
      this.lblInventoryMeseta.Cursor = Cursors.Hand;
      this.lblInventoryMeseta.Location = new Point(16, 182);
      this.lblInventoryMeseta.Name = "lblInventoryMeseta";
      this.lblInventoryMeseta.Size = new Size(47, 13);
      this.lblInventoryMeseta.TabIndex = 26;
      this.lblInventoryMeseta.Text = "Meseta";
      this.lblInventoryMeseta.Click += new EventHandler(this.txtInventoryMeseta_Click);
      this.grpInventoryItemDetails.BackColor = Color.Transparent;
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryPercent);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryLevel);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryACC);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryATK);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryEffect);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventorySpecial);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgInventoryRank);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar15);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar14);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar13);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar12);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar11);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar10);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar9);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar8);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar7);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar6);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar5);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar4);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar3);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar2);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar1);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgStar0);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgInventoryWeaponManufacturer);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryGrinds);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryName_jp);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgInventoryElement);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryQty);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgInventoryItemIcon);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryName);
      this.grpInventoryItemDetails.Controls.Add((Control) this.txtInventoryInfinityItemText);
      this.grpInventoryItemDetails.Controls.Add((Control) this.imgInventoryInfinityItem);
      this.grpInventoryItemDetails.Location = new Point(324, 23);
      this.grpInventoryItemDetails.Name = "grpInventoryItemDetails";
      this.grpInventoryItemDetails.Size = new Size(297, 154);
      this.grpInventoryItemDetails.TabIndex = 43;
      this.grpInventoryItemDetails.TabStop = false;
      this.grpInventoryItemDetails.Visible = false;
      this.txtInventoryPercent.AutoSize = true;
      this.txtInventoryPercent.Cursor = Cursors.Hand;
      this.txtInventoryPercent.Location = new Point(21, 48);
      this.txtInventoryPercent.Name = "txtInventoryPercent";
      this.txtInventoryPercent.Size = new Size(26, 13);
      this.txtInventoryPercent.TabIndex = 31;
      this.txtInventoryPercent.Text = "0%";
      this.txtInventoryPercent.Click += new EventHandler(this.txtInventoryPercent_Click);
      this.txtInventoryLevel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInventoryLevel.Location = new Point(192, 116);
      this.txtInventoryLevel.Name = "txtInventoryLevel";
      this.txtInventoryLevel.Size = new Size(99, 12);
      this.txtInventoryLevel.TabIndex = 73;
      this.txtInventoryLevel.Text = "LV100";
      this.txtInventoryLevel.TextAlign = ContentAlignment.TopRight;
      this.txtInventoryACC.AutoSize = true;
      this.txtInventoryACC.Location = new Point(12, 116);
      this.txtInventoryACC.Name = "txtInventoryACC";
      this.txtInventoryACC.Size = new Size(41, 13);
      this.txtInventoryACC.TabIndex = 72;
      this.txtInventoryACC.Text = "ACC  ";
      this.txtInventoryATK.AutoSize = true;
      this.txtInventoryATK.Cursor = Cursors.Hand;
      this.txtInventoryATK.Location = new Point(15, 101);
      this.txtInventoryATK.Name = "txtInventoryATK";
      this.txtInventoryATK.Size = new Size(38, 13);
      this.txtInventoryATK.TabIndex = 71;
      this.txtInventoryATK.Text = "ATK  ";
      this.txtInventoryATK.Click += new EventHandler(this.txtInventoryATK_Click);
      this.txtInventoryEffect.AutoSize = true;
      this.txtInventoryEffect.Location = new Point(6, 86);
      this.txtInventoryEffect.Name = "txtInventoryEffect";
      this.txtInventoryEffect.Size = new Size(47, 13);
      this.txtInventoryEffect.TabIndex = 70;
      this.txtInventoryEffect.Text = "Effect  ";
      this.txtInventorySpecial.Cursor = Cursors.Hand;
      this.txtInventorySpecial.Location = new Point(3, 71);
      this.txtInventorySpecial.Name = "txtInventorySpecial";
      this.txtInventorySpecial.Size = new Size(284, 13);
      this.txtInventorySpecial.TabIndex = 69;
      this.txtInventorySpecial.Text = "Ability  ";
      this.txtInventorySpecial.Click += new EventHandler(this.txtInventorySpecial_Click);
      this.imgInventoryRank.Image = (Image) Resources.rank_S;
      this.imgInventoryRank.Location = new Point(10, 15);
      this.imgInventoryRank.Name = "imgInventoryRank";
      this.imgInventoryRank.Size = new Size(10, 10);
      this.imgInventoryRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryRank.TabIndex = 67;
      this.imgInventoryRank.TabStop = false;
      this.imgStar15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar15.Image = (Image) Resources.star_s2;
      this.imgStar15.Location = new Point(230, 133);
      this.imgStar15.Name = "imgStar15";
      this.imgStar15.Size = new Size(16, 15);
      this.imgStar15.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar15.TabIndex = 66;
      this.imgStar15.TabStop = false;
      this.imgStar15.Visible = false;
      this.imgStar14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar14.Image = (Image) Resources.star_s2;
      this.imgStar14.Location = new Point(215, 133);
      this.imgStar14.Name = "imgStar14";
      this.imgStar14.Size = new Size(16, 15);
      this.imgStar14.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar14.TabIndex = 65;
      this.imgStar14.TabStop = false;
      this.imgStar14.Visible = false;
      this.imgStar13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar13.Image = (Image) Resources.star_s2;
      this.imgStar13.Location = new Point(200, 133);
      this.imgStar13.Name = "imgStar13";
      this.imgStar13.Size = new Size(16, 15);
      this.imgStar13.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar13.TabIndex = 64;
      this.imgStar13.TabStop = false;
      this.imgStar13.Visible = false;
      this.imgStar12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar12.Image = (Image) Resources.star_s2;
      this.imgStar12.Location = new Point(185, 133);
      this.imgStar12.Name = "imgStar12";
      this.imgStar12.Size = new Size(16, 15);
      this.imgStar12.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar12.TabIndex = 63;
      this.imgStar12.TabStop = false;
      this.imgStar12.Visible = false;
      this.imgStar11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar11.Image = (Image) Resources.star_S;
      this.imgStar11.Location = new Point(171, 133);
      this.imgStar11.Name = "imgStar11";
      this.imgStar11.Size = new Size(16, 15);
      this.imgStar11.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar11.TabIndex = 62;
      this.imgStar11.TabStop = false;
      this.imgStar11.Visible = false;
      this.imgStar10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar10.Image = (Image) Resources.star_S;
      this.imgStar10.Location = new Point(156, 133);
      this.imgStar10.Name = "imgStar10";
      this.imgStar10.Size = new Size(16, 15);
      this.imgStar10.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar10.TabIndex = 61;
      this.imgStar10.TabStop = false;
      this.imgStar10.Visible = false;
      this.imgStar9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar9.Image = (Image) Resources.star_S;
      this.imgStar9.Location = new Point(141, 133);
      this.imgStar9.Name = "imgStar9";
      this.imgStar9.Size = new Size(16, 15);
      this.imgStar9.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar9.TabIndex = 60;
      this.imgStar9.TabStop = false;
      this.imgStar9.Visible = false;
      this.imgStar8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar8.Image = (Image) Resources.star_A;
      this.imgStar8.Location = new Point(126, 133);
      this.imgStar8.Name = "imgStar8";
      this.imgStar8.Size = new Size(16, 15);
      this.imgStar8.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar8.TabIndex = 59;
      this.imgStar8.TabStop = false;
      this.imgStar8.Visible = false;
      this.imgStar7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar7.Image = (Image) Resources.star_A;
      this.imgStar7.Location = new Point(111, 133);
      this.imgStar7.Name = "imgStar7";
      this.imgStar7.Size = new Size(16, 15);
      this.imgStar7.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar7.TabIndex = 58;
      this.imgStar7.TabStop = false;
      this.imgStar7.Visible = false;
      this.imgStar6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar6.Image = (Image) Resources.star_A;
      this.imgStar6.Location = new Point(96, 133);
      this.imgStar6.Name = "imgStar6";
      this.imgStar6.Size = new Size(16, 15);
      this.imgStar6.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar6.TabIndex = 57;
      this.imgStar6.TabStop = false;
      this.imgStar6.Visible = false;
      this.imgStar5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar5.Image = (Image) Resources.star_B;
      this.imgStar5.Location = new Point(81, 133);
      this.imgStar5.Name = "imgStar5";
      this.imgStar5.Size = new Size(16, 15);
      this.imgStar5.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar5.TabIndex = 56;
      this.imgStar5.TabStop = false;
      this.imgStar5.Visible = false;
      this.imgStar4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar4.Image = (Image) Resources.star_B;
      this.imgStar4.Location = new Point(66, 133);
      this.imgStar4.Name = "imgStar4";
      this.imgStar4.Size = new Size(16, 15);
      this.imgStar4.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar4.TabIndex = 55;
      this.imgStar4.TabStop = false;
      this.imgStar4.Visible = false;
      this.imgStar3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar3.Image = (Image) Resources.star_B;
      this.imgStar3.Location = new Point(51, 133);
      this.imgStar3.Name = "imgStar3";
      this.imgStar3.Size = new Size(16, 15);
      this.imgStar3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar3.TabIndex = 54;
      this.imgStar3.TabStop = false;
      this.imgStar3.Visible = false;
      this.imgStar2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar2.Image = (Image) Resources.star_C;
      this.imgStar2.Location = new Point(36, 133);
      this.imgStar2.Name = "imgStar2";
      this.imgStar2.Size = new Size(16, 15);
      this.imgStar2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar2.TabIndex = 53;
      this.imgStar2.TabStop = false;
      this.imgStar2.Visible = false;
      this.imgStar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar1.Image = (Image) Resources.star_C;
      this.imgStar1.Location = new Point(21, 133);
      this.imgStar1.Name = "imgStar1";
      this.imgStar1.Size = new Size(16, 15);
      this.imgStar1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar1.TabIndex = 52;
      this.imgStar1.TabStop = false;
      this.imgStar1.Visible = false;
      this.imgStar0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStar0.Image = (Image) Resources.star_C;
      this.imgStar0.Location = new Point(6, 133);
      this.imgStar0.Name = "imgStar0";
      this.imgStar0.Size = new Size(16, 15);
      this.imgStar0.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStar0.TabIndex = 51;
      this.imgStar0.TabStop = false;
      this.imgStar0.Visible = false;
      this.imgInventoryWeaponManufacturer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.imgInventoryWeaponManufacturer.Image = (Image) Resources.manlogo_GRM;
      this.imgInventoryWeaponManufacturer.Location = new Point(273, 12);
      this.imgInventoryWeaponManufacturer.Name = "imgInventoryWeaponManufacturer";
      this.imgInventoryWeaponManufacturer.Size = new Size(17, 17);
      this.imgInventoryWeaponManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryWeaponManufacturer.TabIndex = 46;
      this.imgInventoryWeaponManufacturer.TabStop = false;
      this.txtInventoryGrinds.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInventoryGrinds.Location = new Point(81, 48);
      this.txtInventoryGrinds.Name = "txtInventoryGrinds";
      this.txtInventoryGrinds.Size = new Size(210, 18);
      this.txtInventoryGrinds.TabIndex = 45;
      this.txtInventoryGrinds.Text = "(0)";
      this.txtInventoryGrinds.TextAlign = ContentAlignment.TopRight;
      this.txtInventoryName_jp.Cursor = Cursors.Hand;
      this.txtInventoryName_jp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInventoryName_jp.Location = new Point(8, 30);
      this.txtInventoryName_jp.Name = "txtInventoryName_jp";
      this.txtInventoryName_jp.Size = new Size(224, 18);
      this.txtInventoryName_jp.TabIndex = 44;
      this.txtInventoryName_jp.Text = "-";
      this.txtInventoryName_jp.Click += new EventHandler(this.txtInventoryName_jp_Click);
      this.imgInventoryElement.Cursor = Cursors.Hand;
      this.imgInventoryElement.Image = (Image) Resources.element_neutral;
      this.imgInventoryElement.Location = new Point(9, 49);
      this.imgInventoryElement.Name = "imgInventoryElement";
      this.imgInventoryElement.Size = new Size(12, 12);
      this.imgInventoryElement.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryElement.TabIndex = 41;
      this.imgInventoryElement.TabStop = false;
      this.imgInventoryElement.Click += new EventHandler(this.imgInventoryElement_Click);
      this.txtInventoryQty.AutoSize = true;
      this.txtInventoryQty.Cursor = Cursors.Hand;
      this.txtInventoryQty.Location = new Point(6, 48);
      this.txtInventoryQty.Name = "txtInventoryQty";
      this.txtInventoryQty.Size = new Size(26, 13);
      this.txtInventoryQty.TabIndex = 42;
      this.txtInventoryQty.Text = "0/0";
      this.txtInventoryQty.Click += new EventHandler(this.txtInventoryQty_Click);
      this.imgInventoryItemIcon.Image = (Image) Resources.armor_icon;
      this.imgInventoryItemIcon.Location = new Point(10, 15);
      this.imgInventoryItemIcon.Name = "imgInventoryItemIcon";
      this.imgInventoryItemIcon.Padding = new Padding(13, 0, 0, 0);
      this.imgInventoryItemIcon.Size = new Size(23, 10);
      this.imgInventoryItemIcon.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryItemIcon.TabIndex = 47;
      this.imgInventoryItemIcon.TabStop = false;
      this.txtInventoryName.Location = new Point(21, 13);
      this.txtInventoryName.Name = "txtInventoryName";
      this.txtInventoryName.Padding = new Padding(13, 0, 0, 0);
      this.txtInventoryName.Size = new Size(211, 18);
      this.txtInventoryName.TabIndex = 43;
      this.txtInventoryName.Text = "-";
      this.txtInventoryInfinityItemText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInventoryInfinityItemText.AutoSize = true;
      this.txtInventoryInfinityItemText.Location = new Point(274, 32);
      this.txtInventoryInfinityItemText.Name = "txtInventoryInfinityItemText";
      this.txtInventoryInfinityItemText.Size = new Size(13, 13);
      this.txtInventoryInfinityItemText.TabIndex = 50;
      this.txtInventoryInfinityItemText.Text = "?";
      this.txtInventoryInfinityItemText.Visible = false;
      this.imgInventoryInfinityItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.imgInventoryInfinityItem.Image = (Image) Resources.infinity_item;
      this.imgInventoryInfinityItem.Location = new Point(270, 31);
      this.imgInventoryInfinityItem.Name = "imgInventoryInfinityItem";
      this.imgInventoryInfinityItem.Size = new Size(20, 16);
      this.imgInventoryInfinityItem.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgInventoryInfinityItem.TabIndex = 49;
      this.imgInventoryInfinityItem.TabStop = false;
      this.imgInventoryInfinityItem.Visible = false;
      this.groupBox2.Location = new Point(324, 23);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(297, 154);
      this.groupBox2.TabIndex = 25;
      this.groupBox2.TabStop = false;
      this.txtInventoryHex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInventoryHex.Cursor = Cursors.Hand;
      this.txtInventoryHex.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInventoryHex.Location = new Point(323, 177);
      this.txtInventoryHex.Name = "txtInventoryHex";
      this.txtInventoryHex.Size = new Size(97, 13);
      this.txtInventoryHex.TabIndex = 48;
      this.txtInventoryHex.Text = "0x00000000";
      this.txtInventoryHex.Click += new EventHandler(this.txtInventoryHex_Click);
      this.pictureBox7.Cursor = Cursors.Default;
      this.pictureBox7.Image = (Image) Resources.item_meseta;
      this.pictureBox7.Location = new Point(6, 184);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new Size(10, 10);
      this.pictureBox7.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox7.TabIndex = 69;
      this.pictureBox7.TabStop = false;
      this.inventoryView.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader1
      });
      this.inventoryView.Cursor = Cursors.Hand;
      this.inventoryView.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.inventoryView.FullRowSelect = true;
      this.inventoryView.HeaderStyle = ColumnHeaderStyle.None;
      this.inventoryView.HideSelection = false;
      this.inventoryView.LabelWrap = false;
      this.inventoryView.Location = new Point(5, 30);
      this.inventoryView.MultiSelect = false;
      this.inventoryView.Name = "inventoryView";
      this.inventoryView.Size = new Size(313, 150);
      this.inventoryView.SmallImageList = this.weaponWithRankImageList;
      this.inventoryView.TabIndex = 77;
      this.inventoryView.UseCompatibleStateImageBehavior = false;
      this.inventoryView.View = View.Details;
      this.inventoryView.SelectedIndexChanged += new EventHandler(this.inventoryView_SelectedIndexChanged);
      this.inventoryView.Click += new EventHandler(this.inventoryView_Click);
      this.columnHeader1.Width = 291;
      this.weaponWithRankImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("weaponWithRankImageList.ImageStream");
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
      this.weaponWithRankImageList.Images.SetKeyName(16, "c_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(17, "c_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(18, "c_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(19, "c_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(20, "c_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(21, "c_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(22, "c_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(23, "c_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(24, "c_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(25, "c_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(26, "c_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(27, "c_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(28, "b_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(29, "b_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(30, "b_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(31, "b_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(32, "b_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(33, "b_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(34, "b_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(35, "b_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(36, "b_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(37, "b_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(38, "b_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(39, "b_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(40, "b_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(41, "b_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(42, "b_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(43, "b_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(44, "b_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(45, "b_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(46, "b_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(47, "b_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(48, "b_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(49, "b_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(50, "b_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(51, "b_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(52, "b_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(53, "b_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(54, "b_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(55, "b_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(56, "a_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(57, "a_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(58, "a_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(59, "a_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(60, "a_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(61, "a_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(62, "a_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(63, "a_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(64, "a_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(65, "a_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(66, "a_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(67, "a_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(68, "a_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(69, "a_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(70, "a_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(71, "a_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(72, "a_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(73, "a_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(74, "a_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(75, "a_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(76, "a_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(77, "a_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(78, "a_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(79, "a_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(80, "a_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(81, "a_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(82, "a_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(83, "a_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(84, "s_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(85, "s_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(86, "s_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(87, "s_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(88, "s_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(89, "s_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(90, "s_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(91, "s_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(92, "s_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(93, "s_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(94, "s_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(95, "s_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(96, "s_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(97, "s_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(98, "s_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(99, "s_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(100, "s_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(101, "s_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(102, "s_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(103, "s_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(104, "s_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(105, "s_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(106, "s_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(107, "s_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(108, "s_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(109, "s_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(110, "s_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(111, "s_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(112, "unk_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(113, "unk_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(114, "unk_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(115, "unk_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(116, "unk_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(117, "unk_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(118, "unk_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(119, "unk_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(120, "unk_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(121, "unk_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(122, "unk_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(123, "unk_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(124, "unk_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(125, "unk_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(126, "unk_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName((int) sbyte.MaxValue, "unk_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(128, "unk_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(129, "unk_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(130, "unk_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(131, "unk_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(132, "unk_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(133, "unk_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(134, "unk_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(135, "unk_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(136, "unk_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(137, "unk_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(138, "unk_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(139, "unk_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(140, "c_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(141, "c_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(142, "c_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(143, "c_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(144, "c_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(145, "c_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(146, "c_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(147, "c_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(148, "c_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(149, "c_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(150, "c_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(151, "c_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(152, "c_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(153, "c_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(154, "c_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(155, "c_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(156, "c_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(157, "c_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(158, "c_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(159, "c_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(160, "c_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(161, "c_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(162, "c_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(163, "c_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(164, "c_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(165, "c_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(166, "c_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(167, "c_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(168, "b_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(169, "b_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(170, "b_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(171, "b_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(172, "b_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(173, "b_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(174, "b_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(175, "b_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(176, "b_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(177, "b_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(178, "b_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(179, "b_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(180, "b_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(181, "b_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(182, "b_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(183, "b_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(184, "b_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(185, "b_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(186, "b_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(187, "b_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(188, "b_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(189, "b_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(190, "b_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(191, "b_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(192, "b_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(193, "b_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(194, "b_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(195, "b_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(196, "a_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(197, "a_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(198, "a_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(199, "a_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(200, "a_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(201, "a_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(202, "a_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(203, "a_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(204, "a_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(205, "a_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(206, "a_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(207, "a_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(208, "a_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(209, "a_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(210, "a_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(211, "a_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(212, "a_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(213, "a_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(214, "a_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(215, "a_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(216, "a_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(217, "a_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(218, "a_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(219, "a_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(220, "a_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(221, "a_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(222, "a_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(223, "a_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(224, "s_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(225, "s_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(226, "s_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(227, "s_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(228, "s_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(229, "s_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(230, "s_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(231, "s_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(232, "s_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(233, "s_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(234, "s_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(235, "s_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(236, "s_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(237, "s_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(238, "s_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(239, "s_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(240, "s_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(241, "s_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(242, "s_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(243, "s_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(244, "s_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(245, "s_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(246, "s_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(247, "s_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(248, "s_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(249, "s_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(250, "s_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(251, "s_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(252, "unk_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(253, "unk_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(254, "unk_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName((int) byte.MaxValue, "unk_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(256, "unk_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(257, "unk_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(258, "unk_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(259, "unk_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(260, "unk_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(261, "unk_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(262, "unk_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(263, "unk_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(264, "unk_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(265, "unk_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(266, "unk_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(267, "unk_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(268, "unk_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(269, "unk_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(270, "unk_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(271, "unk_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(272, "unk_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(273, "unk_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(274, "unk_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(275, "unk_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(276, "unk_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(277, "unk_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(278, "unk_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(279, "unk_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(280, "c_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(281, "c_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(282, "c_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(283, "c_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(284, "c_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(285, "c_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(286, "c_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(287, "c_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(288, "c_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(289, "c_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(290, "c_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(291, "c_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(292, "c_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(293, "c_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(294, "c_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(295, "c_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(296, "c_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(297, "c_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(298, "c_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(299, "c_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(300, "c_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(301, "c_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(302, "c_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(303, "c_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(304, "c_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(305, "c_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(306, "c_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(307, "c_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(308, "b_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(309, "b_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(310, "b_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(311, "b_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(312, "b_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(313, "b_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(314, "b_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(315, "b_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(316, "b_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(317, "b_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(318, "b_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(319, "b_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(320, "b_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(321, "b_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(322, "b_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(323, "b_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(324, "b_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(325, "b_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(326, "b_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(327, "b_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(328, "b_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(329, "b_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(330, "b_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(331, "b_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(332, "b_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(333, "b_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(334, "b_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(335, "b_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(336, "a_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(337, "a_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(338, "a_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(339, "a_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(340, "a_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(341, "a_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(342, "a_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(343, "a_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(344, "a_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(345, "a_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(346, "a_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(347, "a_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(348, "a_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(349, "a_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(350, "a_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(351, "a_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(352, "a_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(353, "a_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(354, "a_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(355, "a_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(356, "a_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(357, "a_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(358, "a_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(359, "a_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(360, "a_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(361, "a_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(362, "a_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(363, "a_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(364, "s_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(365, "s_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(366, "s_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(367, "s_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(368, "s_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(369, "s_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(370, "s_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(371, "s_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(372, "s_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(373, "s_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(374, "s_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(375, "s_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(376, "s_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(377, "s_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(378, "s_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(379, "s_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(380, "s_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(381, "s_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(382, "s_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(383, "s_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(384, "s_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(385, "s_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(386, "s_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(387, "s_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(388, "s_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(389, "s_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(390, "s_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(391, "s_028_shield.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(392, "unk_001_sword.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(393, "unk_002_knuckles.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(394, "unk_003_spear.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(395, "unk_004_double_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(396, "unk_005_axe.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(397, "unk_006_sabers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(398, "unk_007_daggers.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(399, "unk_008_claws.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(400, "unk_009_saber.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(401, "unk_010_dagger.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(402, "unk_011_claw.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(403, "unk_012_whip.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(404, "unk_013_slicer.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(405, "unk_014_rifle.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(406, "unk_015_shotgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(407, "unk_016_longbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(408, "unk_017_grenade.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(409, "unk_018_laser.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(410, "unk_019_handguns.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(411, "unk_020_handgun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(412, "unk_021_crossbow.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(413, "unk_022_cards.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(414, "unk_023_machinegun.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(415, "unk_024_rod.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(416, "unk_025_wand.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(417, "unk_026_tmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(418, "unk_027_rmag.jpg");
      this.weaponWithRankImageList.Images.SetKeyName(419, "unk_028_shield.jpg");
      this.tabPageStorage.Controls.Add((Control) this.btnStorageDelete);
      this.tabPageStorage.Controls.Add((Control) this.chkDeleteExportStorage);
      this.tabPageStorage.Controls.Add((Control) this.btnStorageWithdraw);
      this.tabPageStorage.Controls.Add((Control) this.storageViewPages);
      this.tabPageStorage.Controls.Add((Control) this.storageView);
      this.tabPageStorage.Controls.Add((Control) this.btnStorageImportAll);
      this.tabPageStorage.Controls.Add((Control) this.btnStorageExportAll);
      this.tabPageStorage.Controls.Add((Control) this.btnStorageImportSelected);
      this.tabPageStorage.Controls.Add((Control) this.btnStorageExportSelected);
      this.tabPageStorage.Controls.Add((Control) this.txtStorageMeseta);
      this.tabPageStorage.Controls.Add((Control) this.lblStorageMeseta);
      this.tabPageStorage.Controls.Add((Control) this.grpStorageItemDetails);
      this.tabPageStorage.Controls.Add((Control) this.groupBox1);
      this.tabPageStorage.Controls.Add((Control) this.txtStorageHex);
      this.tabPageStorage.Controls.Add((Control) this.pictureBox6);
      this.tabPageStorage.Cursor = Cursors.Default;
      this.tabPageStorage.Location = new Point(4, 22);
      this.tabPageStorage.Name = "tabPageStorage";
      this.tabPageStorage.Size = new Size(629, 223);
      this.tabPageStorage.TabIndex = 5;
      this.tabPageStorage.Text = "Shared (0/0)";
      this.tabPageStorage.UseVisualStyleBackColor = true;
      this.btnStorageDelete.Cursor = Cursors.Hand;
      this.btnStorageDelete.Enabled = false;
      this.btnStorageDelete.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnStorageDelete.Location = new Point(391, 177);
      this.btnStorageDelete.Name = "btnStorageDelete";
      this.btnStorageDelete.Size = new Size(46, 21);
      this.btnStorageDelete.TabIndex = 77;
      this.btnStorageDelete.Text = "delete";
      this.btnStorageDelete.UseVisualStyleBackColor = true;
      this.btnStorageDelete.Click += new EventHandler(this.btnStorageDelete_Click);
      this.chkDeleteExportStorage.AutoSize = true;
      this.chkDeleteExportStorage.Cursor = Cursors.Hand;
      this.chkDeleteExportStorage.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkDeleteExportStorage.Location = new Point(497, 206);
      this.chkDeleteExportStorage.Name = "chkDeleteExportStorage";
      this.chkDeleteExportStorage.RightToLeft = RightToLeft.Yes;
      this.chkDeleteExportStorage.Size = new Size(125, 14);
      this.chkDeleteExportStorage.TabIndex = 74;
      this.chkDeleteExportStorage.Text = "delete items after export";
      this.chkDeleteExportStorage.UseVisualStyleBackColor = true;
      this.btnStorageWithdraw.Cursor = Cursors.Hand;
      this.btnStorageWithdraw.Enabled = false;
      this.btnStorageWithdraw.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnStorageWithdraw.Location = new Point(566, 177);
      this.btnStorageWithdraw.Name = "btnStorageWithdraw";
      this.btnStorageWithdraw.Size = new Size(56, 21);
      this.btnStorageWithdraw.TabIndex = 73;
      this.btnStorageWithdraw.Text = "withdraw";
      this.btnStorageWithdraw.UseVisualStyleBackColor = true;
      this.btnStorageWithdraw.Click += new EventHandler(this.btnStorageWithdraw_Click);
      this.storageViewPages.Controls.Add((Control) this.tabStorage1);
      this.storageViewPages.Controls.Add((Control) this.tabStorage2);
      this.storageViewPages.Controls.Add((Control) this.tabStorage3);
      this.storageViewPages.Controls.Add((Control) this.tabStorage4);
      this.storageViewPages.Controls.Add((Control) this.tabStorage5);
      this.storageViewPages.Controls.Add((Control) this.tabStorage6);
      this.storageViewPages.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.storageViewPages.Location = new Point(5, 12);
      this.storageViewPages.Name = "storageViewPages";
      this.storageViewPages.SelectedIndex = 0;
      this.storageViewPages.Size = new Size(315, 19);
      this.storageViewPages.TabIndex = 72;
      this.storageViewPages.SelectedIndexChanged += new EventHandler(this.storageViewPages_SelectedIndexChanged);
      this.tabStorage1.Cursor = Cursors.Hand;
      this.tabStorage1.Location = new Point(4, 19);
      this.tabStorage1.Name = "tabStorage1";
      this.tabStorage1.Padding = new Padding(3);
      this.tabStorage1.Size = new Size(307, 0);
      this.tabStorage1.TabIndex = 0;
      this.tabStorage1.Text = "1";
      this.tabStorage1.UseVisualStyleBackColor = true;
      this.tabStorage2.Cursor = Cursors.Hand;
      this.tabStorage2.Location = new Point(4, 19);
      this.tabStorage2.Name = "tabStorage2";
      this.tabStorage2.Padding = new Padding(3);
      this.tabStorage2.Size = new Size(307, 0);
      this.tabStorage2.TabIndex = 1;
      this.tabStorage2.Text = "2";
      this.tabStorage2.UseVisualStyleBackColor = true;
      this.tabStorage3.Cursor = Cursors.Hand;
      this.tabStorage3.Location = new Point(4, 19);
      this.tabStorage3.Name = "tabStorage3";
      this.tabStorage3.Size = new Size(307, 0);
      this.tabStorage3.TabIndex = 2;
      this.tabStorage3.Text = "3";
      this.tabStorage3.UseVisualStyleBackColor = true;
      this.tabStorage4.Cursor = Cursors.Hand;
      this.tabStorage4.Location = new Point(4, 19);
      this.tabStorage4.Name = "tabStorage4";
      this.tabStorage4.Size = new Size(307, 0);
      this.tabStorage4.TabIndex = 3;
      this.tabStorage4.Text = "4";
      this.tabStorage4.UseVisualStyleBackColor = true;
      this.tabStorage5.Cursor = Cursors.Hand;
      this.tabStorage5.Location = new Point(4, 19);
      this.tabStorage5.Name = "tabStorage5";
      this.tabStorage5.Size = new Size(307, 0);
      this.tabStorage5.TabIndex = 4;
      this.tabStorage5.Text = "5";
      this.tabStorage5.UseVisualStyleBackColor = true;
      this.tabStorage6.Cursor = Cursors.Hand;
      this.tabStorage6.Location = new Point(4, 19);
      this.tabStorage6.Name = "tabStorage6";
      this.tabStorage6.Size = new Size(307, 0);
      this.tabStorage6.TabIndex = 5;
      this.tabStorage6.Text = "Free Slots";
      this.tabStorage6.UseVisualStyleBackColor = true;
      this.storageView.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader3
      });
      this.storageView.Cursor = Cursors.Hand;
      this.storageView.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.storageView.FullRowSelect = true;
      this.storageView.HeaderStyle = ColumnHeaderStyle.None;
      this.storageView.HideSelection = false;
      this.storageView.LabelWrap = false;
      this.storageView.Location = new Point(5, 30);
      this.storageView.MultiSelect = false;
      this.storageView.Name = "storageView";
      this.storageView.Size = new Size(313, 150);
      this.storageView.SmallImageList = this.weaponWithRankImageList;
      this.storageView.TabIndex = 71;
      this.storageView.UseCompatibleStateImageBehavior = false;
      this.storageView.View = View.Details;
      this.storageView.SelectedIndexChanged += new EventHandler(this.storageView_SelectedIndexChanged);
      this.storageView.Click += new EventHandler(this.storageView_Click);
      this.columnHeader3.Width = 291;
      this.btnStorageImportAll.Cursor = Cursors.Hand;
      this.btnStorageImportAll.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnStorageImportAll.Location = new Point(152, 183);
      this.btnStorageImportAll.Name = "btnStorageImportAll";
      this.btnStorageImportAll.Size = new Size(82, 21);
      this.btnStorageImportAll.TabIndex = 70;
      this.btnStorageImportAll.Text = "import storage";
      this.btnStorageImportAll.UseVisualStyleBackColor = true;
      this.btnStorageImportAll.Click += new EventHandler(this.btnStorageImportAll_Click);
      this.btnStorageExportAll.Cursor = Cursors.Hand;
      this.btnStorageExportAll.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnStorageExportAll.Location = new Point(236, 183);
      this.btnStorageExportAll.Name = "btnStorageExportAll";
      this.btnStorageExportAll.Size = new Size(82, 21);
      this.btnStorageExportAll.TabIndex = 69;
      this.btnStorageExportAll.Text = "export storage";
      this.btnStorageExportAll.UseVisualStyleBackColor = true;
      this.btnStorageExportAll.Click += new EventHandler(this.btnStorageExportAll_Click);
      this.btnStorageImportSelected.Cursor = Cursors.Hand;
      this.btnStorageImportSelected.Enabled = false;
      this.btnStorageImportSelected.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnStorageImportSelected.Location = new Point(437, 177);
      this.btnStorageImportSelected.Name = "btnStorageImportSelected";
      this.btnStorageImportSelected.Size = new Size(67, 21);
      this.btnStorageImportSelected.TabIndex = 28;
      this.btnStorageImportSelected.Text = "import item";
      this.btnStorageImportSelected.UseVisualStyleBackColor = true;
      this.btnStorageImportSelected.Click += new EventHandler(this.btnStorageImportSelected_Click);
      this.btnStorageExportSelected.Cursor = Cursors.Hand;
      this.btnStorageExportSelected.Enabled = false;
      this.btnStorageExportSelected.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnStorageExportSelected.Location = new Point(504, 177);
      this.btnStorageExportSelected.Name = "btnStorageExportSelected";
      this.btnStorageExportSelected.Size = new Size(62, 21);
      this.btnStorageExportSelected.TabIndex = 27;
      this.btnStorageExportSelected.Text = "export item";
      this.btnStorageExportSelected.UseVisualStyleBackColor = true;
      this.btnStorageExportSelected.Click += new EventHandler(this.btnStorageExportSelected_Click);
      this.txtStorageMeseta.AutoSize = true;
      this.txtStorageMeseta.Cursor = Cursors.Hand;
      this.txtStorageMeseta.Location = new Point(60, 182);
      this.txtStorageMeseta.Name = "txtStorageMeseta";
      this.txtStorageMeseta.Size = new Size(14, 13);
      this.txtStorageMeseta.TabIndex = 50;
      this.txtStorageMeseta.Text = "0";
      this.txtStorageMeseta.Click += new EventHandler(this.txtStorageMeseta_Click);
      this.lblStorageMeseta.AutoSize = true;
      this.lblStorageMeseta.Cursor = Cursors.Hand;
      this.lblStorageMeseta.Location = new Point(16, 182);
      this.lblStorageMeseta.Name = "lblStorageMeseta";
      this.lblStorageMeseta.Size = new Size(47, 13);
      this.lblStorageMeseta.TabIndex = 49;
      this.lblStorageMeseta.Text = "Meseta";
      this.lblStorageMeseta.Click += new EventHandler(this.txtStorageMeseta_Click);
      this.grpStorageItemDetails.BackColor = Color.Transparent;
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStoragePercent);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageLevel);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageACC);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageATK);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageEffect);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageSpecial);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageRank);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar15);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar14);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar13);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar12);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar11);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar10);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar9);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar8);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar7);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar6);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar5);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar4);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar3);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar2);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar1);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageStar0);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageWeaponManufacturer);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageGrinds);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageName_jp);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageItemIcon);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageName);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageElement);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageQty);
      this.grpStorageItemDetails.Controls.Add((Control) this.txtStorageInfinityItemText);
      this.grpStorageItemDetails.Controls.Add((Control) this.imgStorageInfinityItem);
      this.grpStorageItemDetails.Location = new Point(324, 23);
      this.grpStorageItemDetails.Name = "grpStorageItemDetails";
      this.grpStorageItemDetails.Size = new Size(297, 154);
      this.grpStorageItemDetails.TabIndex = 52;
      this.grpStorageItemDetails.TabStop = false;
      this.grpStorageItemDetails.Visible = false;
      this.txtStoragePercent.AutoSize = true;
      this.txtStoragePercent.Cursor = Cursors.Hand;
      this.txtStoragePercent.Location = new Point(21, 48);
      this.txtStoragePercent.Name = "txtStoragePercent";
      this.txtStoragePercent.Size = new Size(26, 13);
      this.txtStoragePercent.TabIndex = 31;
      this.txtStoragePercent.Text = "0%";
      this.txtStoragePercent.Click += new EventHandler(this.txtStoragePercent_Click);
      this.txtStorageLevel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtStorageLevel.Location = new Point(192, 116);
      this.txtStorageLevel.Name = "txtStorageLevel";
      this.txtStorageLevel.Size = new Size(99, 17);
      this.txtStorageLevel.TabIndex = 75;
      this.txtStorageLevel.Text = "LV100";
      this.txtStorageLevel.TextAlign = ContentAlignment.TopRight;
      this.txtStorageACC.AutoSize = true;
      this.txtStorageACC.Location = new Point(12, 116);
      this.txtStorageACC.Name = "txtStorageACC";
      this.txtStorageACC.Size = new Size(41, 13);
      this.txtStorageACC.TabIndex = 74;
      this.txtStorageACC.Text = "ACC  ";
      this.txtStorageATK.AutoSize = true;
      this.txtStorageATK.Cursor = Cursors.Hand;
      this.txtStorageATK.Location = new Point(15, 101);
      this.txtStorageATK.Name = "txtStorageATK";
      this.txtStorageATK.Size = new Size(38, 13);
      this.txtStorageATK.TabIndex = 73;
      this.txtStorageATK.Text = "ATK  ";
      this.txtStorageATK.Click += new EventHandler(this.txtStorageATK_Click);
      this.txtStorageEffect.AutoSize = true;
      this.txtStorageEffect.Location = new Point(6, 86);
      this.txtStorageEffect.Name = "txtStorageEffect";
      this.txtStorageEffect.Size = new Size(47, 13);
      this.txtStorageEffect.TabIndex = 72;
      this.txtStorageEffect.Text = "Effect  ";
      this.txtStorageSpecial.Cursor = Cursors.Hand;
      this.txtStorageSpecial.Location = new Point(3, 71);
      this.txtStorageSpecial.Name = "txtStorageSpecial";
      this.txtStorageSpecial.Size = new Size(278, 14);
      this.txtStorageSpecial.TabIndex = 71;
      this.txtStorageSpecial.Text = "Ability  ";
      this.txtStorageSpecial.Click += new EventHandler(this.txtStorageSpecial_Click);
      this.imgStorageRank.Image = (Image) Resources.rank_S;
      this.imgStorageRank.Location = new Point(10, 15);
      this.imgStorageRank.Name = "imgStorageRank";
      this.imgStorageRank.Size = new Size(10, 10);
      this.imgStorageRank.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageRank.TabIndex = 67;
      this.imgStorageRank.TabStop = false;
      this.imgStorageStar15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar15.Image = (Image) Resources.star_s2;
      this.imgStorageStar15.Location = new Point(230, 133);
      this.imgStorageStar15.Name = "imgStorageStar15";
      this.imgStorageStar15.Size = new Size(16, 15);
      this.imgStorageStar15.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar15.TabIndex = 66;
      this.imgStorageStar15.TabStop = false;
      this.imgStorageStar15.Visible = false;
      this.imgStorageStar14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar14.Image = (Image) Resources.star_s2;
      this.imgStorageStar14.Location = new Point(215, 133);
      this.imgStorageStar14.Name = "imgStorageStar14";
      this.imgStorageStar14.Size = new Size(16, 15);
      this.imgStorageStar14.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar14.TabIndex = 65;
      this.imgStorageStar14.TabStop = false;
      this.imgStorageStar14.Visible = false;
      this.imgStorageStar13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar13.Image = (Image) Resources.star_s2;
      this.imgStorageStar13.Location = new Point(200, 133);
      this.imgStorageStar13.Name = "imgStorageStar13";
      this.imgStorageStar13.Size = new Size(16, 15);
      this.imgStorageStar13.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar13.TabIndex = 64;
      this.imgStorageStar13.TabStop = false;
      this.imgStorageStar13.Visible = false;
      this.imgStorageStar12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar12.Image = (Image) Resources.star_s2;
      this.imgStorageStar12.Location = new Point(185, 133);
      this.imgStorageStar12.Name = "imgStorageStar12";
      this.imgStorageStar12.Size = new Size(16, 15);
      this.imgStorageStar12.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar12.TabIndex = 63;
      this.imgStorageStar12.TabStop = false;
      this.imgStorageStar12.Visible = false;
      this.imgStorageStar11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar11.Image = (Image) Resources.star_S;
      this.imgStorageStar11.Location = new Point(171, 133);
      this.imgStorageStar11.Name = "imgStorageStar11";
      this.imgStorageStar11.Size = new Size(16, 15);
      this.imgStorageStar11.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar11.TabIndex = 62;
      this.imgStorageStar11.TabStop = false;
      this.imgStorageStar11.Visible = false;
      this.imgStorageStar10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar10.Image = (Image) Resources.star_S;
      this.imgStorageStar10.Location = new Point(156, 133);
      this.imgStorageStar10.Name = "imgStorageStar10";
      this.imgStorageStar10.Size = new Size(16, 15);
      this.imgStorageStar10.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar10.TabIndex = 61;
      this.imgStorageStar10.TabStop = false;
      this.imgStorageStar10.Visible = false;
      this.imgStorageStar9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar9.Image = (Image) Resources.star_S;
      this.imgStorageStar9.Location = new Point(141, 133);
      this.imgStorageStar9.Name = "imgStorageStar9";
      this.imgStorageStar9.Size = new Size(16, 15);
      this.imgStorageStar9.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar9.TabIndex = 60;
      this.imgStorageStar9.TabStop = false;
      this.imgStorageStar9.Visible = false;
      this.imgStorageStar8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar8.Image = (Image) Resources.star_A;
      this.imgStorageStar8.Location = new Point(126, 133);
      this.imgStorageStar8.Name = "imgStorageStar8";
      this.imgStorageStar8.Size = new Size(16, 15);
      this.imgStorageStar8.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar8.TabIndex = 59;
      this.imgStorageStar8.TabStop = false;
      this.imgStorageStar8.Visible = false;
      this.imgStorageStar7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar7.Image = (Image) Resources.star_A;
      this.imgStorageStar7.Location = new Point(111, 133);
      this.imgStorageStar7.Name = "imgStorageStar7";
      this.imgStorageStar7.Size = new Size(16, 15);
      this.imgStorageStar7.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar7.TabIndex = 58;
      this.imgStorageStar7.TabStop = false;
      this.imgStorageStar7.Visible = false;
      this.imgStorageStar6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar6.Image = (Image) Resources.star_A;
      this.imgStorageStar6.Location = new Point(96, 133);
      this.imgStorageStar6.Name = "imgStorageStar6";
      this.imgStorageStar6.Size = new Size(16, 15);
      this.imgStorageStar6.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar6.TabIndex = 57;
      this.imgStorageStar6.TabStop = false;
      this.imgStorageStar6.Visible = false;
      this.imgStorageStar5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar5.Image = (Image) Resources.star_B;
      this.imgStorageStar5.Location = new Point(81, 133);
      this.imgStorageStar5.Name = "imgStorageStar5";
      this.imgStorageStar5.Size = new Size(16, 15);
      this.imgStorageStar5.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar5.TabIndex = 56;
      this.imgStorageStar5.TabStop = false;
      this.imgStorageStar5.Visible = false;
      this.imgStorageStar4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar4.Image = (Image) Resources.star_B;
      this.imgStorageStar4.Location = new Point(66, 133);
      this.imgStorageStar4.Name = "imgStorageStar4";
      this.imgStorageStar4.Size = new Size(16, 15);
      this.imgStorageStar4.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar4.TabIndex = 55;
      this.imgStorageStar4.TabStop = false;
      this.imgStorageStar4.Visible = false;
      this.imgStorageStar3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar3.Image = (Image) Resources.star_B;
      this.imgStorageStar3.Location = new Point(51, 133);
      this.imgStorageStar3.Name = "imgStorageStar3";
      this.imgStorageStar3.Size = new Size(16, 15);
      this.imgStorageStar3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar3.TabIndex = 54;
      this.imgStorageStar3.TabStop = false;
      this.imgStorageStar3.Visible = false;
      this.imgStorageStar2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar2.Image = (Image) Resources.star_C;
      this.imgStorageStar2.Location = new Point(36, 133);
      this.imgStorageStar2.Name = "imgStorageStar2";
      this.imgStorageStar2.Size = new Size(16, 15);
      this.imgStorageStar2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar2.TabIndex = 53;
      this.imgStorageStar2.TabStop = false;
      this.imgStorageStar2.Visible = false;
      this.imgStorageStar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar1.Image = (Image) Resources.star_C;
      this.imgStorageStar1.Location = new Point(21, 133);
      this.imgStorageStar1.Name = "imgStorageStar1";
      this.imgStorageStar1.Size = new Size(16, 15);
      this.imgStorageStar1.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar1.TabIndex = 52;
      this.imgStorageStar1.TabStop = false;
      this.imgStorageStar1.Visible = false;
      this.imgStorageStar0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.imgStorageStar0.Image = (Image) Resources.star_C;
      this.imgStorageStar0.Location = new Point(6, 133);
      this.imgStorageStar0.Name = "imgStorageStar0";
      this.imgStorageStar0.Size = new Size(16, 15);
      this.imgStorageStar0.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageStar0.TabIndex = 51;
      this.imgStorageStar0.TabStop = false;
      this.imgStorageStar0.Visible = false;
      this.imgStorageWeaponManufacturer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.imgStorageWeaponManufacturer.Image = (Image) Resources.manlogo_GRM;
      this.imgStorageWeaponManufacturer.Location = new Point(273, 12);
      this.imgStorageWeaponManufacturer.Name = "imgStorageWeaponManufacturer";
      this.imgStorageWeaponManufacturer.Size = new Size(17, 17);
      this.imgStorageWeaponManufacturer.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageWeaponManufacturer.TabIndex = 46;
      this.imgStorageWeaponManufacturer.TabStop = false;
      this.txtStorageGrinds.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtStorageGrinds.Location = new Point(81, 48);
      this.txtStorageGrinds.Name = "txtStorageGrinds";
      this.txtStorageGrinds.Size = new Size(210, 18);
      this.txtStorageGrinds.TabIndex = 45;
      this.txtStorageGrinds.Text = "(0)";
      this.txtStorageGrinds.TextAlign = ContentAlignment.TopRight;
      this.txtStorageName_jp.Cursor = Cursors.Hand;
      this.txtStorageName_jp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtStorageName_jp.Location = new Point(8, 30);
      this.txtStorageName_jp.Name = "txtStorageName_jp";
      this.txtStorageName_jp.Size = new Size(224, 18);
      this.txtStorageName_jp.TabIndex = 44;
      this.txtStorageName_jp.Text = "-";
      this.txtStorageName_jp.Click += new EventHandler(this.txtStorageName_jp_Click);
      this.imgStorageItemIcon.Image = (Image) Resources.armor_icon;
      this.imgStorageItemIcon.Location = new Point(10, 15);
      this.imgStorageItemIcon.Name = "imgStorageItemIcon";
      this.imgStorageItemIcon.Padding = new Padding(13, 0, 0, 0);
      this.imgStorageItemIcon.Size = new Size(23, 10);
      this.imgStorageItemIcon.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageItemIcon.TabIndex = 47;
      this.imgStorageItemIcon.TabStop = false;
      this.txtStorageName.Location = new Point(21, 13);
      this.txtStorageName.Name = "txtStorageName";
      this.txtStorageName.Padding = new Padding(13, 0, 0, 0);
      this.txtStorageName.Size = new Size(211, 18);
      this.txtStorageName.TabIndex = 43;
      this.txtStorageName.Text = "-";
      this.imgStorageElement.Cursor = Cursors.Hand;
      this.imgStorageElement.Image = (Image) Resources.element_neutral;
      this.imgStorageElement.Location = new Point(9, 49);
      this.imgStorageElement.Name = "imgStorageElement";
      this.imgStorageElement.Size = new Size(12, 12);
      this.imgStorageElement.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageElement.TabIndex = 41;
      this.imgStorageElement.TabStop = false;
      this.imgStorageElement.Click += new EventHandler(this.imgStorageElement_Click);
      this.txtStorageQty.AutoSize = true;
      this.txtStorageQty.Cursor = Cursors.Hand;
      this.txtStorageQty.Location = new Point(6, 48);
      this.txtStorageQty.Name = "txtStorageQty";
      this.txtStorageQty.Size = new Size(26, 13);
      this.txtStorageQty.TabIndex = 42;
      this.txtStorageQty.Text = "0/0";
      this.txtStorageQty.Click += new EventHandler(this.txtStorageQty_Click);
      this.txtStorageInfinityItemText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtStorageInfinityItemText.AutoSize = true;
      this.txtStorageInfinityItemText.Location = new Point(274, 32);
      this.txtStorageInfinityItemText.Name = "txtStorageInfinityItemText";
      this.txtStorageInfinityItemText.Size = new Size(13, 13);
      this.txtStorageInfinityItemText.TabIndex = 50;
      this.txtStorageInfinityItemText.Text = "?";
      this.txtStorageInfinityItemText.Visible = false;
      this.imgStorageInfinityItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.imgStorageInfinityItem.Image = (Image) Resources.infinity_item;
      this.imgStorageInfinityItem.Location = new Point(270, 31);
      this.imgStorageInfinityItem.Name = "imgStorageInfinityItem";
      this.imgStorageInfinityItem.Size = new Size(20, 16);
      this.imgStorageInfinityItem.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgStorageInfinityItem.TabIndex = 49;
      this.imgStorageInfinityItem.TabStop = false;
      this.imgStorageInfinityItem.Visible = false;
      this.groupBox1.Location = new Point(324, 24);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(297, 154);
      this.groupBox1.TabIndex = 25;
      this.groupBox1.TabStop = false;
      this.txtStorageHex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtStorageHex.Cursor = Cursors.Hand;
      this.txtStorageHex.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtStorageHex.Location = new Point(323, 177);
      this.txtStorageHex.Name = "txtStorageHex";
      this.txtStorageHex.Size = new Size(97, 13);
      this.txtStorageHex.TabIndex = 53;
      this.txtStorageHex.Text = "0x00000000";
      this.txtStorageHex.Click += new EventHandler(this.txtStorageHex_Click);
      this.pictureBox6.Cursor = Cursors.Default;
      this.pictureBox6.Image = (Image) Resources.item_meseta;
      this.pictureBox6.Location = new Point(6, 184);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new Size(10, 10);
      this.pictureBox6.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox6.TabIndex = 68;
      this.pictureBox6.TabStop = false;
      this.tabPageMissions.Controls.Add((Control) this.tabControlMissions);
      this.tabPageMissions.Location = new Point(4, 22);
      this.tabPageMissions.Name = "tabPageMissions";
      this.tabPageMissions.Padding = new Padding(3);
      this.tabPageMissions.Size = new Size(629, 223);
      this.tabPageMissions.TabIndex = 7;
      this.tabPageMissions.Text = "Mission";
      this.tabPageMissions.UseVisualStyleBackColor = true;
      this.tabControlMissions.Controls.Add((Control) this.tabEp1Missions);
      this.tabControlMissions.Controls.Add((Control) this.tabEp2Missions);
      this.tabControlMissions.Controls.Add((Control) this.tabPageInfinityMission);
      this.tabControlMissions.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tabControlMissions.Location = new Point(4, 3);
      this.tabControlMissions.Name = "tabControlMissions";
      this.tabControlMissions.SelectedIndex = 0;
      this.tabControlMissions.Size = new Size(618, 217);
      this.tabControlMissions.TabIndex = 0;
      this.tabEp1Missions.Controls.Add((Control) this.txtAllowQuitMission);
      this.tabEp1Missions.Controls.Add((Control) this.label47);
      this.tabEp1Missions.Controls.Add((Control) this.txtEp1Complete);
      this.tabEp1Missions.Controls.Add((Control) this.label44);
      this.tabEp1Missions.Controls.Add((Control) this.txtStoryEmiliaPoints);
      this.tabEp1Missions.Controls.Add((Control) this.txtMissionTactical);
      this.tabEp1Missions.Controls.Add((Control) this.label2);
      this.tabEp1Missions.Controls.Add((Control) this.txtMissionMagashi);
      this.tabEp1Missions.Controls.Add((Control) this.label13);
      this.tabEp1Missions.Controls.Add((Control) this.txtSkipEp1Start);
      this.tabEp1Missions.Controls.Add((Control) this.label12);
      this.tabEp1Missions.Controls.Add((Control) this.txtMissionEp1);
      this.tabEp1Missions.Controls.Add((Control) this.label1);
      this.tabEp1Missions.Location = new Point(4, 21);
      this.tabEp1Missions.Name = "tabEp1Missions";
      this.tabEp1Missions.Padding = new Padding(3);
      this.tabEp1Missions.Size = new Size(610, 192);
      this.tabEp1Missions.TabIndex = 0;
      this.tabEp1Missions.Text = "Episode 1";
      this.tabEp1Missions.UseVisualStyleBackColor = true;
      this.tabEp1Missions.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtAllowQuitMission.Cursor = Cursors.Hand;
      this.txtAllowQuitMission.ForeColor = Color.DarkRed;
      this.txtAllowQuitMission.Location = new Point(144, 85);
      this.txtAllowQuitMission.Name = "txtAllowQuitMission";
      this.txtAllowQuitMission.Size = new Size(37, 13);
      this.txtAllowQuitMission.TabIndex = 101;
      this.txtAllowQuitMission.Text = "No";
      this.txtAllowQuitMission.TextAlign = ContentAlignment.MiddleLeft;
      this.txtAllowQuitMission.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtAllowQuitMission.Click += new EventHandler(this.txtAllowQuitMission_Click);
      this.label47.ForeColor = Color.Black;
      this.label47.Location = new Point(2, 85);
      this.label47.Name = "label47";
      this.label47.Size = new Size(143, 13);
      this.label47.TabIndex = 100;
      this.label47.Text = "Allow Quit Mission";
      this.label47.TextAlign = ContentAlignment.MiddleRight;
      this.txtEp1Complete.Cursor = Cursors.Hand;
      this.txtEp1Complete.ForeColor = Color.DarkRed;
      this.txtEp1Complete.Location = new Point(144, 70);
      this.txtEp1Complete.Name = "txtEp1Complete";
      this.txtEp1Complete.Size = new Size(37, 13);
      this.txtEp1Complete.TabIndex = 99;
      this.txtEp1Complete.Text = "No";
      this.txtEp1Complete.TextAlign = ContentAlignment.MiddleLeft;
      this.txtEp1Complete.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtEp1Complete.Click += new EventHandler(this.txtEp1Complete_Click);
      this.label44.ForeColor = Color.Black;
      this.label44.Location = new Point(2, 70);
      this.label44.Name = "label44";
      this.label44.Size = new Size(143, 13);
      this.label44.TabIndex = 98;
      this.label44.Text = "Episode Complete";
      this.label44.TextAlign = ContentAlignment.MiddleRight;
      this.txtStoryEmiliaPoints.AutoSize = true;
      this.txtStoryEmiliaPoints.BackColor = Color.Transparent;
      this.txtStoryEmiliaPoints.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtStoryEmiliaPoints.ForeColor = SystemColors.ActiveCaptionText;
      this.txtStoryEmiliaPoints.Location = new Point(479, 13);
      this.txtStoryEmiliaPoints.Name = "txtStoryEmiliaPoints";
      this.txtStoryEmiliaPoints.Size = new Size(86, 14);
      this.txtStoryEmiliaPoints.TabIndex = 97;
      this.txtStoryEmiliaPoints.Text = "Emilia Points";
      this.txtStoryEmiliaPoints.Visible = false;
      this.txtMissionTactical.Cursor = Cursors.Hand;
      this.txtMissionTactical.ForeColor = Color.DarkRed;
      this.txtMissionTactical.Location = new Point(173, 172);
      this.txtMissionTactical.Name = "txtMissionTactical";
      this.txtMissionTactical.Size = new Size(37, 13);
      this.txtMissionTactical.TabIndex = 96;
      this.txtMissionTactical.Text = "No";
      this.txtMissionTactical.TextAlign = ContentAlignment.MiddleLeft;
      this.txtMissionTactical.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtMissionTactical.Click += new EventHandler(this.txtMissionUnknown_Click);
      this.label2.ForeColor = Color.Black;
      this.label2.Location = new Point(5, 172);
      this.label2.Name = "label2";
      this.label2.Size = new Size(176, 13);
      this.label2.TabIndex = 95;
      this.label2.Text = "Unknown Missions Unlocked  ";
      this.label2.TextAlign = ContentAlignment.MiddleRight;
      this.txtMissionMagashi.Cursor = Cursors.Hand;
      this.txtMissionMagashi.ForeColor = Color.DarkRed;
      this.txtMissionMagashi.Location = new Point(144, 43);
      this.txtMissionMagashi.Name = "txtMissionMagashi";
      this.txtMissionMagashi.Size = new Size(37, 13);
      this.txtMissionMagashi.TabIndex = 94;
      this.txtMissionMagashi.Text = "No";
      this.txtMissionMagashi.TextAlign = ContentAlignment.MiddleLeft;
      this.txtMissionMagashi.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtMissionMagashi.Click += new EventHandler(this.txtMissionMagashi_Click);
      this.label13.ForeColor = Color.Black;
      this.label13.Location = new Point(3, 43);
      this.label13.Name = "label13";
      this.label13.Size = new Size(149, 13);
      this.label13.TabIndex = 93;
      this.label13.Text = "Magashi Plan Unlocked  ";
      this.label13.TextAlign = ContentAlignment.MiddleRight;
      this.txtSkipEp1Start.Cursor = Cursors.Hand;
      this.txtSkipEp1Start.ForeColor = Color.DarkRed;
      this.txtSkipEp1Start.Location = new Point(144, 13);
      this.txtSkipEp1Start.Name = "txtSkipEp1Start";
      this.txtSkipEp1Start.Size = new Size(37, 13);
      this.txtSkipEp1Start.TabIndex = 92;
      this.txtSkipEp1Start.Text = "No";
      this.txtSkipEp1Start.TextAlign = ContentAlignment.MiddleLeft;
      this.txtSkipEp1Start.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtSkipEp1Start.Click += new EventHandler(this.txtSkipEp1Start_Click);
      this.label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label12.ForeColor = Color.Black;
      this.label12.Location = new Point(6, 13);
      this.label12.Name = "label12";
      this.label12.Size = new Size(146, 13);
      this.label12.TabIndex = 91;
      this.label12.Text = "Skip Start Sequence  ";
      this.label12.TextAlign = ContentAlignment.MiddleRight;
      this.txtMissionEp1.Cursor = Cursors.Hand;
      this.txtMissionEp1.ForeColor = Color.DarkRed;
      this.txtMissionEp1.Location = new Point(144, 28);
      this.txtMissionEp1.Name = "txtMissionEp1";
      this.txtMissionEp1.Size = new Size(37, 13);
      this.txtMissionEp1.TabIndex = 90;
      this.txtMissionEp1.Text = "No";
      this.txtMissionEp1.TextAlign = ContentAlignment.MiddleLeft;
      this.txtMissionEp1.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtMissionEp1.Click += new EventHandler(this.txtMissionEp1_Click);
      this.label1.ForeColor = Color.Black;
      this.label1.Location = new Point(6, 28);
      this.label1.Name = "label1";
      this.label1.Size = new Size(146, 13);
      this.label1.TabIndex = 89;
      this.label1.Text = "All Missions Unlocked  ";
      this.label1.TextAlign = ContentAlignment.MiddleRight;
      this.tabEp2Missions.Controls.Add((Control) this.txtEp2Complete);
      this.tabEp2Missions.Controls.Add((Control) this.label46);
      this.tabEp2Missions.Controls.Add((Control) this.txtStoryNagisaPoints);
      this.tabEp2Missions.Controls.Add((Control) this.txtSkipEp2Start);
      this.tabEp2Missions.Controls.Add((Control) this.lblSkipEp2Start);
      this.tabEp2Missions.Controls.Add((Control) this.txtMissionEp2);
      this.tabEp2Missions.Controls.Add((Control) this.lblMissionEp2);
      this.tabEp2Missions.Location = new Point(4, 21);
      this.tabEp2Missions.Name = "tabEp2Missions";
      this.tabEp2Missions.Padding = new Padding(3);
      this.tabEp2Missions.Size = new Size(610, 192);
      this.tabEp2Missions.TabIndex = 1;
      this.tabEp2Missions.Text = "Episode 2";
      this.tabEp2Missions.UseVisualStyleBackColor = true;
      this.txtEp2Complete.Cursor = Cursors.Hand;
      this.txtEp2Complete.ForeColor = Color.DarkRed;
      this.txtEp2Complete.Location = new Point(144, 62);
      this.txtEp2Complete.Name = "txtEp2Complete";
      this.txtEp2Complete.Size = new Size(37, 13);
      this.txtEp2Complete.TabIndex = 101;
      this.txtEp2Complete.Text = "No";
      this.txtEp2Complete.TextAlign = ContentAlignment.MiddleLeft;
      this.txtEp2Complete.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtEp2Complete.Click += new EventHandler(this.txtEp2Complete_Click);
      this.label46.ForeColor = Color.Black;
      this.label46.Location = new Point(2, 62);
      this.label46.Name = "label46";
      this.label46.Size = new Size(143, 13);
      this.label46.TabIndex = 100;
      this.label46.Text = "Episode Complete";
      this.label46.TextAlign = ContentAlignment.MiddleRight;
      this.txtStoryNagisaPoints.AutoSize = true;
      this.txtStoryNagisaPoints.BackColor = Color.Transparent;
      this.txtStoryNagisaPoints.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtStoryNagisaPoints.ForeColor = SystemColors.ActiveCaptionText;
      this.txtStoryNagisaPoints.Location = new Point(472, 13);
      this.txtStoryNagisaPoints.Name = "txtStoryNagisaPoints";
      this.txtStoryNagisaPoints.Size = new Size(93, 14);
      this.txtStoryNagisaPoints.TabIndex = 91;
      this.txtStoryNagisaPoints.Text = "Nagisa Points";
      this.txtStoryNagisaPoints.Visible = false;
      this.txtSkipEp2Start.Cursor = Cursors.Hand;
      this.txtSkipEp2Start.ForeColor = Color.DarkRed;
      this.txtSkipEp2Start.Location = new Point(144, 13);
      this.txtSkipEp2Start.Name = "txtSkipEp2Start";
      this.txtSkipEp2Start.Size = new Size(37, 13);
      this.txtSkipEp2Start.TabIndex = 90;
      this.txtSkipEp2Start.Text = "No";
      this.txtSkipEp2Start.TextAlign = ContentAlignment.MiddleLeft;
      this.txtSkipEp2Start.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtSkipEp2Start.Click += new EventHandler(this.txtSkipEp2Start_Click);
      this.lblSkipEp2Start.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblSkipEp2Start.ForeColor = Color.Black;
      this.lblSkipEp2Start.Location = new Point(7, 13);
      this.lblSkipEp2Start.Name = "lblSkipEp2Start";
      this.lblSkipEp2Start.Size = new Size(145, 13);
      this.lblSkipEp2Start.TabIndex = 89;
      this.lblSkipEp2Start.Text = "Skip Start Sequence  ";
      this.lblSkipEp2Start.TextAlign = ContentAlignment.MiddleRight;
      this.txtMissionEp2.Cursor = Cursors.Hand;
      this.txtMissionEp2.ForeColor = Color.DarkRed;
      this.txtMissionEp2.Location = new Point(144, 28);
      this.txtMissionEp2.Name = "txtMissionEp2";
      this.txtMissionEp2.Size = new Size(37, 13);
      this.txtMissionEp2.TabIndex = 88;
      this.txtMissionEp2.Text = "No";
      this.txtMissionEp2.TextAlign = ContentAlignment.MiddleLeft;
      this.txtMissionEp2.TextChanged += new EventHandler(this.missionStatus_TextChanged);
      this.txtMissionEp2.Click += new EventHandler(this.txtMissionEp2_Click);
      this.lblMissionEp2.ForeColor = Color.Black;
      this.lblMissionEp2.Location = new Point(10, 28);
      this.lblMissionEp2.Name = "lblMissionEp2";
      this.lblMissionEp2.Size = new Size(142, 13);
      this.lblMissionEp2.TabIndex = 87;
      this.lblMissionEp2.Text = "All Missions Unlocked  ";
      this.lblMissionEp2.TextAlign = ContentAlignment.MiddleRight;
      this.tabPageInfinityMission.Controls.Add((Control) this.btnImportMissions);
      this.tabPageInfinityMission.Controls.Add((Control) this.btnExportMissions);
      this.tabPageInfinityMission.Controls.Add((Control) this.btnModifyInfinityMission);
      this.tabPageInfinityMission.Controls.Add((Control) this.tabControl1);
      this.tabPageInfinityMission.Controls.Add((Control) this.btnDeleteInfinityMission);
      this.tabPageInfinityMission.Controls.Add((Control) this.btnImportInfinityMission);
      this.tabPageInfinityMission.Controls.Add((Control) this.btnExportInfinityMission);
      this.tabPageInfinityMission.Controls.Add((Control) this.lstInfinityMissions);
      this.tabPageInfinityMission.Controls.Add((Control) this.txtInfinityMissionQty);
      this.tabPageInfinityMission.Controls.Add((Control) this.label63);
      this.tabPageInfinityMission.Location = new Point(4, 21);
      this.tabPageInfinityMission.Name = "tabPageInfinityMission";
      this.tabPageInfinityMission.Padding = new Padding(3);
      this.tabPageInfinityMission.Size = new Size(610, 192);
      this.tabPageInfinityMission.TabIndex = 2;
      this.tabPageInfinityMission.Text = "Infinity Missions";
      this.tabPageInfinityMission.UseVisualStyleBackColor = true;
      this.btnImportMissions.Cursor = Cursors.Hand;
      this.btnImportMissions.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnImportMissions.Location = new Point(135, 172);
      this.btnImportMissions.Name = "btnImportMissions";
      this.btnImportMissions.Size = new Size(82, 21);
      this.btnImportMissions.TabIndex = 100;
      this.btnImportMissions.Text = "import pack";
      this.btnImportMissions.UseVisualStyleBackColor = true;
      this.btnImportMissions.Click += new EventHandler(this.btnImportMissions_Click);
      this.btnExportMissions.Cursor = Cursors.Hand;
      this.btnExportMissions.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnExportMissions.Location = new Point(219, 172);
      this.btnExportMissions.Name = "btnExportMissions";
      this.btnExportMissions.Size = new Size(82, 21);
      this.btnExportMissions.TabIndex = 99;
      this.btnExportMissions.Text = "export pack";
      this.btnExportMissions.UseVisualStyleBackColor = true;
      this.btnExportMissions.Click += new EventHandler(this.btnExportMissions_Click);
      this.btnModifyInfinityMission.Cursor = Cursors.Hand;
      this.btnModifyInfinityMission.Enabled = false;
      this.btnModifyInfinityMission.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnModifyInfinityMission.Location = new Point(411, 157);
      this.btnModifyInfinityMission.Name = "btnModifyInfinityMission";
      this.btnModifyInfinityMission.Size = new Size(46, 21);
      this.btnModifyInfinityMission.TabIndex = 98;
      this.btnModifyInfinityMission.Text = "modify";
      this.btnModifyInfinityMission.UseVisualStyleBackColor = true;
      this.btnModifyInfinityMission.Click += new EventHandler(this.btnModifyInfinityMission_Click);
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Font = new Font("Verdana", 6f);
      this.tabControl1.Location = new Point(307, 3);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(302, 151);
      this.tabControl1.TabIndex = 97;
      this.tabPage1.Controls.Add((Control) this.grpInfinityMissionDetails);
      this.tabPage1.Location = new Point(4, 19);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(294, 128);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "1";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.grpInfinityMissionDetails.BackColor = Color.Transparent;
      this.grpInfinityMissionDetails.Controls.Add((Control) this.txtInfEnemyLevel);
      this.grpInfinityMissionDetails.Controls.Add((Control) this.txtInfNameJp);
      this.grpInfinityMissionDetails.Controls.Add((Control) this.txtInfNameEn);
      this.grpInfinityMissionDetails.Controls.Add((Control) this.txtInfMisEnemy2);
      this.grpInfinityMissionDetails.Controls.Add((Control) this.txtInfMisBoss);
      this.grpInfinityMissionDetails.Controls.Add((Control) this.txtInfMisEnemy1);
      this.grpInfinityMissionDetails.Font = new Font("Verdana", 8.25f);
      this.grpInfinityMissionDetails.Location = new Point(0, -6);
      this.grpInfinityMissionDetails.Name = "grpInfinityMissionDetails";
      this.grpInfinityMissionDetails.Size = new Size(293, 135);
      this.grpInfinityMissionDetails.TabIndex = 74;
      this.grpInfinityMissionDetails.TabStop = false;
      this.grpInfinityMissionDetails.Visible = false;
      this.txtInfEnemyLevel.Cursor = Cursors.Default;
      this.txtInfEnemyLevel.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInfEnemyLevel.Location = new Point(4, 110);
      this.txtInfEnemyLevel.Name = "txtInfEnemyLevel";
      this.txtInfEnemyLevel.Size = new Size(281, 13);
      this.txtInfEnemyLevel.TabIndex = 81;
      this.txtInfEnemyLevel.Text = "Enemy Level";
      this.txtInfNameJp.Cursor = Cursors.Default;
      this.txtInfNameJp.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInfNameJp.Location = new Point(6, 34);
      this.txtInfNameJp.Name = "txtInfNameJp";
      this.txtInfNameJp.Size = new Size(224, 18);
      this.txtInfNameJp.TabIndex = 80;
      this.txtInfNameJp.Text = "-";
      this.txtInfNameEn.Cursor = Cursors.Default;
      this.txtInfNameEn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInfNameEn.Location = new Point(6, 17);
      this.txtInfNameEn.Name = "txtInfNameEn";
      this.txtInfNameEn.Size = new Size(221, 18);
      this.txtInfNameEn.TabIndex = 79;
      this.txtInfNameEn.Text = "-";
      this.txtInfMisEnemy2.Cursor = Cursors.Default;
      this.txtInfMisEnemy2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInfMisEnemy2.Location = new Point(12, 95);
      this.txtInfMisEnemy2.Name = "txtInfMisEnemy2";
      this.txtInfMisEnemy2.Size = new Size(281, 13);
      this.txtInfMisEnemy2.TabIndex = 78;
      this.txtInfMisEnemy2.Text = "Sub Enemy";
      this.txtInfMisBoss.Cursor = Cursors.Default;
      this.txtInfMisBoss.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInfMisBoss.Location = new Point(5, 57);
      this.txtInfMisBoss.Name = "txtInfMisBoss";
      this.txtInfMisBoss.Size = new Size(282, 13);
      this.txtInfMisBoss.TabIndex = 76;
      this.txtInfMisBoss.Text = "Boss";
      this.txtInfMisEnemy1.Cursor = Cursors.Default;
      this.txtInfMisEnemy1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInfMisEnemy1.Location = new Point(8, 80);
      this.txtInfMisEnemy1.Name = "txtInfMisEnemy1";
      this.txtInfMisEnemy1.Size = new Size(284, 13);
      this.txtInfMisEnemy1.TabIndex = 77;
      this.txtInfMisEnemy1.Text = "Main Enemy";
      this.tabPage2.Controls.Add((Control) this.grpInfMisSpecial);
      this.tabPage2.Location = new Point(4, 19);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(294, 128);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "2";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.grpInfMisSpecial.BackColor = Color.Transparent;
      this.grpInfMisSpecial.Controls.Add((Control) this.txtInfMisSpecial);
      this.grpInfMisSpecial.Font = new Font("Verdana", 8.25f);
      this.grpInfMisSpecial.Location = new Point(0, -6);
      this.grpInfMisSpecial.Name = "grpInfMisSpecial";
      this.grpInfMisSpecial.Size = new Size(293, 135);
      this.grpInfMisSpecial.TabIndex = 75;
      this.grpInfMisSpecial.TabStop = false;
      this.grpInfMisSpecial.Visible = false;
      this.txtInfMisSpecial.Cursor = Cursors.Default;
      this.txtInfMisSpecial.Font = new Font("Verdana", 6.75f);
      this.txtInfMisSpecial.Location = new Point(6, 17);
      this.txtInfMisSpecial.Name = "txtInfMisSpecial";
      this.txtInfMisSpecial.Size = new Size(281, 13);
      this.txtInfMisSpecial.TabIndex = 76;
      this.txtInfMisSpecial.Text = "Special Effects";
      this.tabPage3.Controls.Add((Control) this.grpInfMisExtra);
      this.tabPage3.Location = new Point(4, 19);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new Size(294, 128);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "3";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.grpInfMisExtra.BackColor = Color.Transparent;
      this.grpInfMisExtra.Controls.Add((Control) this.txtInfMisSynthPoint);
      this.grpInfMisExtra.Controls.Add((Control) this.txtInfMisCreatedBy);
      this.grpInfMisExtra.Font = new Font("Verdana", 8.25f);
      this.grpInfMisExtra.Location = new Point(0, -6);
      this.grpInfMisExtra.Name = "grpInfMisExtra";
      this.grpInfMisExtra.Size = new Size(293, 135);
      this.grpInfMisExtra.TabIndex = 76;
      this.grpInfMisExtra.TabStop = false;
      this.grpInfMisExtra.Visible = false;
      this.txtInfMisSynthPoint.Cursor = Cursors.Default;
      this.txtInfMisSynthPoint.Font = new Font("Verdana", 6.75f);
      this.txtInfMisSynthPoint.Location = new Point(6, 61);
      this.txtInfMisSynthPoint.Name = "txtInfMisSynthPoint";
      this.txtInfMisSynthPoint.Size = new Size(281, 13);
      this.txtInfMisSynthPoint.TabIndex = 77;
      this.txtInfMisSynthPoint.Text = "Sythesis Points  ";
      this.txtInfMisCreatedBy.Cursor = Cursors.Default;
      this.txtInfMisCreatedBy.Font = new Font("Verdana", 6.75f);
      this.txtInfMisCreatedBy.Location = new Point(6, 17);
      this.txtInfMisCreatedBy.Name = "txtInfMisCreatedBy";
      this.txtInfMisCreatedBy.Size = new Size(281, 13);
      this.txtInfMisCreatedBy.TabIndex = 76;
      this.txtInfMisCreatedBy.Text = "Created By  ";
      this.btnDeleteInfinityMission.Cursor = Cursors.Hand;
      this.btnDeleteInfinityMission.Enabled = false;
      this.btnDeleteInfinityMission.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDeleteInfinityMission.Location = new Point(457, 157);
      this.btnDeleteInfinityMission.Name = "btnDeleteInfinityMission";
      this.btnDeleteInfinityMission.Size = new Size(46, 21);
      this.btnDeleteInfinityMission.TabIndex = 96;
      this.btnDeleteInfinityMission.Text = "delete";
      this.btnDeleteInfinityMission.UseVisualStyleBackColor = true;
      this.btnDeleteInfinityMission.Click += new EventHandler(this.btnDeleteInfinityMission_Click);
      this.btnImportInfinityMission.Cursor = Cursors.Hand;
      this.btnImportInfinityMission.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnImportInfinityMission.Location = new Point(503, 157);
      this.btnImportInfinityMission.Name = "btnImportInfinityMission";
      this.btnImportInfinityMission.Size = new Size(50, 21);
      this.btnImportInfinityMission.TabIndex = 95;
      this.btnImportInfinityMission.Text = "import";
      this.btnImportInfinityMission.UseVisualStyleBackColor = true;
      this.btnImportInfinityMission.Click += new EventHandler(this.btnImportInfinityMission_Click);
      this.btnExportInfinityMission.Cursor = Cursors.Hand;
      this.btnExportInfinityMission.Enabled = false;
      this.btnExportInfinityMission.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnExportInfinityMission.Location = new Point(553, 157);
      this.btnExportInfinityMission.Name = "btnExportInfinityMission";
      this.btnExportInfinityMission.Size = new Size(52, 21);
      this.btnExportInfinityMission.TabIndex = 94;
      this.btnExportInfinityMission.Text = "export";
      this.btnExportInfinityMission.UseVisualStyleBackColor = true;
      this.btnExportInfinityMission.Click += new EventHandler(this.btnExportInfinityMission_Click);
      this.lstInfinityMissions.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader10,
        this.columnHeader11
      });
      this.lstInfinityMissions.Cursor = Cursors.Hand;
      this.lstInfinityMissions.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstInfinityMissions.FullRowSelect = true;
      this.lstInfinityMissions.HeaderStyle = ColumnHeaderStyle.None;
      this.lstInfinityMissions.HideSelection = false;
      this.lstInfinityMissions.LabelWrap = false;
      this.lstInfinityMissions.Location = new Point(3, 3);
      this.lstInfinityMissions.MultiSelect = false;
      this.lstInfinityMissions.Name = "lstInfinityMissions";
      this.lstInfinityMissions.Size = new Size(298, 167);
      this.lstInfinityMissions.TabIndex = 93;
      this.lstInfinityMissions.UseCompatibleStateImageBehavior = false;
      this.lstInfinityMissions.View = View.Details;
      this.lstInfinityMissions.SelectedIndexChanged += new EventHandler(this.lstInfinityMissions_SelectedIndexChanged);
      this.columnHeader10.Width = 220;
      this.columnHeader11.Width = 50;
      this.txtInfinityMissionQty.AutoSize = true;
      this.txtInfinityMissionQty.BackColor = Color.Transparent;
      this.txtInfinityMissionQty.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInfinityMissionQty.ForeColor = SystemColors.ActiveCaptionText;
      this.txtInfinityMissionQty.Location = new Point(3, 175);
      this.txtInfinityMissionQty.Name = "txtInfinityMissionQty";
      this.txtInfinityMissionQty.Size = new Size(44, 14);
      this.txtInfinityMissionQty.TabIndex = 92;
      this.txtInfinityMissionQty.Text = "0/100";
      this.label63.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label63.Cursor = Cursors.Hand;
      this.label63.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label63.Location = new Point(311, 157);
      this.label63.Name = "label63";
      this.label63.Size = new Size(97, 13);
      this.label63.TabIndex = 75;
      this.label63.Text = "0x00000000";
      this.tabPagePA.Controls.Add((Control) this.tabPA);
      this.tabPagePA.Location = new Point(4, 22);
      this.tabPagePA.Name = "tabPagePA";
      this.tabPagePA.Padding = new Padding(3);
      this.tabPagePA.Size = new Size(629, 223);
      this.tabPagePA.TabIndex = 8;
      this.tabPagePA.Text = "PA List";
      this.tabPagePA.UseVisualStyleBackColor = true;
      this.tabPA.Controls.Add((Control) this.tabPAMelee);
      this.tabPA.Controls.Add((Control) this.tabPABullets);
      this.tabPA.Controls.Add((Control) this.tabPATech);
      this.tabPA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tabPA.Location = new Point(5, 3);
      this.tabPA.Name = "tabPA";
      this.tabPA.SelectedIndex = 0;
      this.tabPA.Size = new Size(618, 217);
      this.tabPA.TabIndex = 1;
      this.tabPAMelee.Controls.Add((Control) this.groupBox6);
      this.tabPAMelee.Controls.Add((Control) this.txtPAHexMelee);
      this.tabPAMelee.Controls.Add((Control) this.lstPAMelee);
      this.tabPAMelee.Location = new Point(4, 21);
      this.tabPAMelee.Name = "tabPAMelee";
      this.tabPAMelee.Padding = new Padding(3);
      this.tabPAMelee.Size = new Size(610, 192);
      this.tabPAMelee.TabIndex = 0;
      this.tabPAMelee.Text = "Melee";
      this.tabPAMelee.UseVisualStyleBackColor = true;
      this.groupBox6.BackColor = Color.Transparent;
      this.groupBox6.Controls.Add((Control) this.label3);
      this.groupBox6.Controls.Add((Control) this.label4);
      this.groupBox6.Controls.Add((Control) this.label5);
      this.groupBox6.Controls.Add((Control) this.label6);
      this.groupBox6.Controls.Add((Control) this.label16);
      this.groupBox6.Controls.Add((Control) this.pictureBox2);
      this.groupBox6.Controls.Add((Control) this.pictureBox3);
      this.groupBox6.Controls.Add((Control) this.pictureBox4);
      this.groupBox6.Controls.Add((Control) this.pictureBox8);
      this.groupBox6.Controls.Add((Control) this.pictureBox9);
      this.groupBox6.Controls.Add((Control) this.pictureBox10);
      this.groupBox6.Controls.Add((Control) this.pictureBox11);
      this.groupBox6.Controls.Add((Control) this.pictureBox12);
      this.groupBox6.Controls.Add((Control) this.pictureBox13);
      this.groupBox6.Controls.Add((Control) this.pictureBox14);
      this.groupBox6.Controls.Add((Control) this.pictureBox15);
      this.groupBox6.Controls.Add((Control) this.pictureBox16);
      this.groupBox6.Controls.Add((Control) this.pictureBox17);
      this.groupBox6.Controls.Add((Control) this.pictureBox18);
      this.groupBox6.Controls.Add((Control) this.pictureBox19);
      this.groupBox6.Controls.Add((Control) this.pictureBox20);
      this.groupBox6.Controls.Add((Control) this.pictureBox21);
      this.groupBox6.Controls.Add((Control) this.pictureBox22);
      this.groupBox6.Controls.Add((Control) this.label18);
      this.groupBox6.Controls.Add((Control) this.label19);
      this.groupBox6.Controls.Add((Control) this.pictureBox23);
      this.groupBox6.Controls.Add((Control) this.label24);
      this.groupBox6.Controls.Add((Control) this.label25);
      this.groupBox6.Controls.Add((Control) this.pictureBox24);
      this.groupBox6.Controls.Add((Control) this.label26);
      this.groupBox6.Controls.Add((Control) this.label30);
      this.groupBox6.Controls.Add((Control) this.pictureBox25);
      this.groupBox6.Font = new Font("Verdana", 8.25f);
      this.groupBox6.Location = new Point(307, 6);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(297, 154);
      this.groupBox6.TabIndex = 72;
      this.groupBox6.TabStop = false;
      this.groupBox6.Visible = false;
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label3.Location = new Point(192, 116);
      this.label3.Name = "label3";
      this.label3.Size = new Size(99, 12);
      this.label3.TabIndex = 73;
      this.label3.Text = "LV100";
      this.label3.TextAlign = ContentAlignment.TopRight;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(12, 116);
      this.label4.Name = "label4";
      this.label4.Size = new Size(41, 13);
      this.label4.TabIndex = 72;
      this.label4.Text = "ACC  ";
      this.label5.AutoSize = true;
      this.label5.Cursor = Cursors.Hand;
      this.label5.Location = new Point(15, 101);
      this.label5.Name = "label5";
      this.label5.Size = new Size(38, 13);
      this.label5.TabIndex = 71;
      this.label5.Text = "ATK  ";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(6, 86);
      this.label6.Name = "label6";
      this.label6.Size = new Size(47, 13);
      this.label6.TabIndex = 70;
      this.label6.Text = "Effect  ";
      this.label16.Cursor = Cursors.Hand;
      this.label16.Location = new Point(3, 71);
      this.label16.Name = "label16";
      this.label16.Size = new Size(284, 13);
      this.label16.TabIndex = 69;
      this.label16.Text = "Ability  ";
      this.pictureBox2.Image = (Image) Resources.rank_S;
      this.pictureBox2.Location = new Point(10, 15);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(10, 10);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox2.TabIndex = 67;
      this.pictureBox2.TabStop = false;
      this.pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox3.Image = (Image) Resources.star_s2;
      this.pictureBox3.Location = new Point(230, 133);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(16, 15);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox3.TabIndex = 66;
      this.pictureBox3.TabStop = false;
      this.pictureBox3.Visible = false;
      this.pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox4.Image = (Image) Resources.star_s2;
      this.pictureBox4.Location = new Point(215, 133);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(16, 15);
      this.pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox4.TabIndex = 65;
      this.pictureBox4.TabStop = false;
      this.pictureBox4.Visible = false;
      this.pictureBox8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox8.Image = (Image) Resources.star_s2;
      this.pictureBox8.Location = new Point(200, 133);
      this.pictureBox8.Name = "pictureBox8";
      this.pictureBox8.Size = new Size(16, 15);
      this.pictureBox8.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox8.TabIndex = 64;
      this.pictureBox8.TabStop = false;
      this.pictureBox8.Visible = false;
      this.pictureBox9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox9.Image = (Image) Resources.star_s2;
      this.pictureBox9.Location = new Point(185, 133);
      this.pictureBox9.Name = "pictureBox9";
      this.pictureBox9.Size = new Size(16, 15);
      this.pictureBox9.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox9.TabIndex = 63;
      this.pictureBox9.TabStop = false;
      this.pictureBox9.Visible = false;
      this.pictureBox10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox10.Image = (Image) Resources.star_S;
      this.pictureBox10.Location = new Point(171, 133);
      this.pictureBox10.Name = "pictureBox10";
      this.pictureBox10.Size = new Size(16, 15);
      this.pictureBox10.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox10.TabIndex = 62;
      this.pictureBox10.TabStop = false;
      this.pictureBox10.Visible = false;
      this.pictureBox11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox11.Image = (Image) Resources.star_S;
      this.pictureBox11.Location = new Point(156, 133);
      this.pictureBox11.Name = "pictureBox11";
      this.pictureBox11.Size = new Size(16, 15);
      this.pictureBox11.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox11.TabIndex = 61;
      this.pictureBox11.TabStop = false;
      this.pictureBox11.Visible = false;
      this.pictureBox12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox12.Image = (Image) Resources.star_S;
      this.pictureBox12.Location = new Point(141, 133);
      this.pictureBox12.Name = "pictureBox12";
      this.pictureBox12.Size = new Size(16, 15);
      this.pictureBox12.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox12.TabIndex = 60;
      this.pictureBox12.TabStop = false;
      this.pictureBox12.Visible = false;
      this.pictureBox13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox13.Image = (Image) Resources.star_A;
      this.pictureBox13.Location = new Point(126, 133);
      this.pictureBox13.Name = "pictureBox13";
      this.pictureBox13.Size = new Size(16, 15);
      this.pictureBox13.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox13.TabIndex = 59;
      this.pictureBox13.TabStop = false;
      this.pictureBox13.Visible = false;
      this.pictureBox14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox14.Image = (Image) Resources.star_A;
      this.pictureBox14.Location = new Point(111, 133);
      this.pictureBox14.Name = "pictureBox14";
      this.pictureBox14.Size = new Size(16, 15);
      this.pictureBox14.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox14.TabIndex = 58;
      this.pictureBox14.TabStop = false;
      this.pictureBox14.Visible = false;
      this.pictureBox15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox15.Image = (Image) Resources.star_A;
      this.pictureBox15.Location = new Point(96, 133);
      this.pictureBox15.Name = "pictureBox15";
      this.pictureBox15.Size = new Size(16, 15);
      this.pictureBox15.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox15.TabIndex = 57;
      this.pictureBox15.TabStop = false;
      this.pictureBox15.Visible = false;
      this.pictureBox16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox16.Image = (Image) Resources.star_B;
      this.pictureBox16.Location = new Point(81, 133);
      this.pictureBox16.Name = "pictureBox16";
      this.pictureBox16.Size = new Size(16, 15);
      this.pictureBox16.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox16.TabIndex = 56;
      this.pictureBox16.TabStop = false;
      this.pictureBox16.Visible = false;
      this.pictureBox17.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox17.Image = (Image) Resources.star_B;
      this.pictureBox17.Location = new Point(66, 133);
      this.pictureBox17.Name = "pictureBox17";
      this.pictureBox17.Size = new Size(16, 15);
      this.pictureBox17.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox17.TabIndex = 55;
      this.pictureBox17.TabStop = false;
      this.pictureBox17.Visible = false;
      this.pictureBox18.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox18.Image = (Image) Resources.star_B;
      this.pictureBox18.Location = new Point(51, 133);
      this.pictureBox18.Name = "pictureBox18";
      this.pictureBox18.Size = new Size(16, 15);
      this.pictureBox18.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox18.TabIndex = 54;
      this.pictureBox18.TabStop = false;
      this.pictureBox18.Visible = false;
      this.pictureBox19.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox19.Image = (Image) Resources.star_C;
      this.pictureBox19.Location = new Point(36, 133);
      this.pictureBox19.Name = "pictureBox19";
      this.pictureBox19.Size = new Size(16, 15);
      this.pictureBox19.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox19.TabIndex = 53;
      this.pictureBox19.TabStop = false;
      this.pictureBox19.Visible = false;
      this.pictureBox20.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox20.Image = (Image) Resources.star_C;
      this.pictureBox20.Location = new Point(21, 133);
      this.pictureBox20.Name = "pictureBox20";
      this.pictureBox20.Size = new Size(16, 15);
      this.pictureBox20.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox20.TabIndex = 52;
      this.pictureBox20.TabStop = false;
      this.pictureBox20.Visible = false;
      this.pictureBox21.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.pictureBox21.Image = (Image) Resources.star_C;
      this.pictureBox21.Location = new Point(6, 133);
      this.pictureBox21.Name = "pictureBox21";
      this.pictureBox21.Size = new Size(16, 15);
      this.pictureBox21.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox21.TabIndex = 51;
      this.pictureBox21.TabStop = false;
      this.pictureBox21.Visible = false;
      this.pictureBox22.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pictureBox22.Image = (Image) Resources.manlogo_GRM;
      this.pictureBox22.Location = new Point(273, 12);
      this.pictureBox22.Name = "pictureBox22";
      this.pictureBox22.Size = new Size(17, 17);
      this.pictureBox22.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox22.TabIndex = 46;
      this.pictureBox22.TabStop = false;
      this.label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label18.Location = new Point(81, 48);
      this.label18.Name = "label18";
      this.label18.Size = new Size(210, 18);
      this.label18.TabIndex = 45;
      this.label18.Text = "(0)";
      this.label18.TextAlign = ContentAlignment.TopRight;
      this.label19.Cursor = Cursors.Hand;
      this.label19.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label19.Location = new Point(8, 30);
      this.label19.Name = "label19";
      this.label19.Size = new Size(224, 18);
      this.label19.TabIndex = 44;
      this.label19.Text = "-";
      this.pictureBox23.Cursor = Cursors.Hand;
      this.pictureBox23.Image = (Image) Resources.element_neutral;
      this.pictureBox23.Location = new Point(9, 49);
      this.pictureBox23.Name = "pictureBox23";
      this.pictureBox23.Size = new Size(12, 12);
      this.pictureBox23.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox23.TabIndex = 41;
      this.pictureBox23.TabStop = false;
      this.label24.AutoSize = true;
      this.label24.Cursor = Cursors.Hand;
      this.label24.Location = new Point(21, 48);
      this.label24.Name = "label24";
      this.label24.Size = new Size(26, 13);
      this.label24.TabIndex = 31;
      this.label24.Text = "0%";
      this.label25.AutoSize = true;
      this.label25.Cursor = Cursors.Hand;
      this.label25.Location = new Point(6, 48);
      this.label25.Name = "label25";
      this.label25.Size = new Size(26, 13);
      this.label25.TabIndex = 42;
      this.label25.Text = "0/0";
      this.pictureBox24.Image = (Image) Resources.armor_icon;
      this.pictureBox24.Location = new Point(10, 15);
      this.pictureBox24.Name = "pictureBox24";
      this.pictureBox24.Padding = new Padding(13, 0, 0, 0);
      this.pictureBox24.Size = new Size(23, 10);
      this.pictureBox24.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox24.TabIndex = 47;
      this.pictureBox24.TabStop = false;
      this.label26.Location = new Point(21, 13);
      this.label26.Name = "label26";
      this.label26.Padding = new Padding(13, 0, 0, 0);
      this.label26.Size = new Size(211, 18);
      this.label26.TabIndex = 43;
      this.label26.Text = "-";
      this.label30.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label30.AutoSize = true;
      this.label30.Location = new Point(274, 32);
      this.label30.Name = "label30";
      this.label30.Size = new Size(13, 13);
      this.label30.TabIndex = 50;
      this.label30.Text = "?";
      this.label30.Visible = false;
      this.pictureBox25.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pictureBox25.Image = (Image) Resources.infinity_item;
      this.pictureBox25.Location = new Point(270, 31);
      this.pictureBox25.Name = "pictureBox25";
      this.pictureBox25.Size = new Size(20, 16);
      this.pictureBox25.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox25.TabIndex = 49;
      this.pictureBox25.TabStop = false;
      this.pictureBox25.Visible = false;
      this.txtPAHexMelee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPAHexMelee.Cursor = Cursors.Hand;
      this.txtPAHexMelee.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPAHexMelee.Location = new Point(311, 160);
      this.txtPAHexMelee.Name = "txtPAHexMelee";
      this.txtPAHexMelee.Size = new Size(97, 13);
      this.txtPAHexMelee.TabIndex = 73;
      this.txtPAHexMelee.Text = "0x00000000";
      this.lstPAMelee.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader2,
        this.columnHeader4
      });
      this.lstPAMelee.Cursor = Cursors.Hand;
      this.lstPAMelee.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstPAMelee.FullRowSelect = true;
      this.lstPAMelee.HeaderStyle = ColumnHeaderStyle.None;
      this.lstPAMelee.HideSelection = false;
      this.lstPAMelee.LabelWrap = false;
      this.lstPAMelee.Location = new Point(3, 3);
      this.lstPAMelee.MultiSelect = false;
      this.lstPAMelee.Name = "lstPAMelee";
      this.lstPAMelee.Size = new Size(298, 185);
      this.lstPAMelee.SmallImageList = this.paImageList;
      this.lstPAMelee.TabIndex = 71;
      this.lstPAMelee.UseCompatibleStateImageBehavior = false;
      this.lstPAMelee.View = View.Details;
      this.lstPAMelee.SelectedIndexChanged += new EventHandler(this.lstPAMelee_SelectedIndexChanged);
      this.columnHeader2.Width = 220;
      this.columnHeader4.Width = 50;
      this.paImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("paImageList.ImageStream");
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
      this.paImageList.Images.SetKeyName(16, "grenade.png");
      this.paImageList.Images.SetKeyName(17, "laser.png");
      this.paImageList.Images.SetKeyName(18, "handguns.png");
      this.paImageList.Images.SetKeyName(19, "handgun.png");
      this.paImageList.Images.SetKeyName(20, "crossbow.png");
      this.paImageList.Images.SetKeyName(21, "cards.png");
      this.paImageList.Images.SetKeyName(22, "machinegun.png");
      this.paImageList.Images.SetKeyName(23, "rod.png");
      this.paImageList.Images.SetKeyName(24, "wand.png");
      this.paImageList.Images.SetKeyName(25, "tmag.png");
      this.paImageList.Images.SetKeyName(26, "rmag.png");
      this.paImageList.Images.SetKeyName(27, "shield.png");
      this.paImageList.Images.SetKeyName(28, "element_fire.png");
      this.paImageList.Images.SetKeyName(29, "element_ice.png");
      this.paImageList.Images.SetKeyName(30, "element_thunder.png");
      this.paImageList.Images.SetKeyName(31, "element_earth.png");
      this.paImageList.Images.SetKeyName(32, "element_light.png");
      this.paImageList.Images.SetKeyName(33, "element_dark.png");
      this.tabPABullets.Controls.Add((Control) this.txtPAHexBullets);
      this.tabPABullets.Controls.Add((Control) this.lstPABullets);
      this.tabPABullets.Location = new Point(4, 21);
      this.tabPABullets.Name = "tabPABullets";
      this.tabPABullets.Padding = new Padding(3);
      this.tabPABullets.Size = new Size(610, 192);
      this.tabPABullets.TabIndex = 1;
      this.tabPABullets.Text = "Bullets";
      this.tabPABullets.UseVisualStyleBackColor = true;
      this.txtPAHexBullets.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPAHexBullets.Cursor = Cursors.Hand;
      this.txtPAHexBullets.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPAHexBullets.Location = new Point(311, 160);
      this.txtPAHexBullets.Name = "txtPAHexBullets";
      this.txtPAHexBullets.Size = new Size(97, 13);
      this.txtPAHexBullets.TabIndex = 74;
      this.txtPAHexBullets.Text = "0x00000000";
      this.lstPABullets.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader5,
        this.columnHeader6
      });
      this.lstPABullets.Cursor = Cursors.Hand;
      this.lstPABullets.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstPABullets.FullRowSelect = true;
      this.lstPABullets.HeaderStyle = ColumnHeaderStyle.None;
      this.lstPABullets.HideSelection = false;
      this.lstPABullets.LabelWrap = false;
      this.lstPABullets.Location = new Point(3, 3);
      this.lstPABullets.MultiSelect = false;
      this.lstPABullets.Name = "lstPABullets";
      this.lstPABullets.Size = new Size(298, 185);
      this.lstPABullets.SmallImageList = this.paImageList;
      this.lstPABullets.TabIndex = 72;
      this.lstPABullets.UseCompatibleStateImageBehavior = false;
      this.lstPABullets.View = View.Details;
      this.lstPABullets.SelectedIndexChanged += new EventHandler(this.lstPABullets_SelectedIndexChanged);
      this.columnHeader5.Width = 220;
      this.columnHeader6.Width = 50;
      this.tabPATech.Controls.Add((Control) this.txtPAHexTech);
      this.tabPATech.Controls.Add((Control) this.lstPATechs);
      this.tabPATech.Location = new Point(4, 21);
      this.tabPATech.Name = "tabPATech";
      this.tabPATech.Size = new Size(610, 192);
      this.tabPATech.TabIndex = 2;
      this.tabPATech.Text = "Technique";
      this.tabPATech.UseVisualStyleBackColor = true;
      this.txtPAHexTech.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPAHexTech.Cursor = Cursors.Hand;
      this.txtPAHexTech.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPAHexTech.Location = new Point(311, 160);
      this.txtPAHexTech.Name = "txtPAHexTech";
      this.txtPAHexTech.Size = new Size(97, 13);
      this.txtPAHexTech.TabIndex = 74;
      this.txtPAHexTech.Text = "0x00000000";
      this.lstPATechs.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader7,
        this.columnHeader8
      });
      this.lstPATechs.Cursor = Cursors.Hand;
      this.lstPATechs.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstPATechs.FullRowSelect = true;
      this.lstPATechs.HeaderStyle = ColumnHeaderStyle.None;
      this.lstPATechs.HideSelection = false;
      this.lstPATechs.LabelWrap = false;
      this.lstPATechs.Location = new Point(3, 3);
      this.lstPATechs.MultiSelect = false;
      this.lstPATechs.Name = "lstPATechs";
      this.lstPATechs.Size = new Size(298, 185);
      this.lstPATechs.SmallImageList = this.paImageList;
      this.lstPATechs.TabIndex = 72;
      this.lstPATechs.UseCompatibleStateImageBehavior = false;
      this.lstPATechs.View = View.Details;
      this.lstPATechs.SelectedIndexChanged += new EventHandler(this.lstPATechs_SelectedIndexChanged);
      this.columnHeader7.Width = 220;
      this.columnHeader8.Width = 50;
      this.tabPageRebirth.Controls.Add((Control) this.chkRebirthNoLevelDrop);
      this.tabPageRebirth.Controls.Add((Control) this.chkRebirthSpoof);
      this.tabPageRebirth.Controls.Add((Control) this.comboRebirthExtend);
      this.tabPageRebirth.Controls.Add((Control) this.btnRebirth);
      this.tabPageRebirth.Controls.Add((Control) this.txtRebirthMaxType);
      this.tabPageRebirth.Controls.Add((Control) this.label33);
      this.tabPageRebirth.Controls.Add((Control) this.lstRebirthRewards);
      this.tabPageRebirth.Controls.Add((Control) this.label17);
      this.tabPageRebirth.Controls.Add((Control) this.label32);
      this.tabPageRebirth.Controls.Add((Control) this.txtRebirthCount);
      this.tabPageRebirth.Controls.Add((Control) this.txtRebirthPoints);
      this.tabPageRebirth.Controls.Add((Control) this.label48);
      this.tabPageRebirth.Controls.Add((Control) this.grpRebirth);
      this.tabPageRebirth.Location = new Point(4, 22);
      this.tabPageRebirth.Name = "tabPageRebirth";
      this.tabPageRebirth.Padding = new Padding(3);
      this.tabPageRebirth.Size = new Size(629, 223);
      this.tabPageRebirth.TabIndex = 10;
      this.tabPageRebirth.Text = "Rebirth";
      this.tabPageRebirth.UseVisualStyleBackColor = true;
      this.chkRebirthNoLevelDrop.AutoSize = true;
      this.chkRebirthNoLevelDrop.Cursor = Cursors.Hand;
      this.chkRebirthNoLevelDrop.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkRebirthNoLevelDrop.Location = new Point(174, 191);
      this.chkRebirthNoLevelDrop.Name = "chkRebirthNoLevelDrop";
      this.chkRebirthNoLevelDrop.Size = new Size(170, 16);
      this.chkRebirthNoLevelDrop.TabIndex = 96;
      this.chkRebirthNoLevelDrop.Text = "No Level Drop During Rebirth";
      this.chkRebirthNoLevelDrop.UseVisualStyleBackColor = true;
      this.chkRebirthSpoof.AutoSize = true;
      this.chkRebirthSpoof.Cursor = Cursors.Hand;
      this.chkRebirthSpoof.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkRebirthSpoof.Location = new Point(9, 191);
      this.chkRebirthSpoof.Name = "chkRebirthSpoof";
      this.chkRebirthSpoof.Size = new Size(145, 16);
      this.chkRebirthSpoof.TabIndex = 95;
      this.chkRebirthSpoof.Text = "Spoof Level 200 Rebirth";
      this.chkRebirthSpoof.UseVisualStyleBackColor = true;
      this.chkRebirthSpoof.CheckedChanged += new EventHandler(this.chkRebirthSpoof_CheckedChanged);
      this.comboRebirthExtend.Cursor = Cursors.Hand;
      this.comboRebirthExtend.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.comboRebirthExtend.FormattingEnabled = true;
      this.comboRebirthExtend.Location = new Point(9, 119);
      this.comboRebirthExtend.Name = "comboRebirthExtend";
      this.comboRebirthExtend.Size = new Size(294, 20);
      this.comboRebirthExtend.TabIndex = 94;
      this.btnRebirth.Cursor = Cursors.Hand;
      this.btnRebirth.Enabled = false;
      this.btnRebirth.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnRebirth.Location = new Point(305, 118);
      this.btnRebirth.Name = "btnRebirth";
      this.btnRebirth.Size = new Size(59, 22);
      this.btnRebirth.TabIndex = 86;
      this.btnRebirth.Text = "rebirth";
      this.btnRebirth.UseVisualStyleBackColor = true;
      this.btnRebirth.Click += new EventHandler(this.btnRebirth_Click);
      this.txtRebirthMaxType.AutoSize = true;
      this.txtRebirthMaxType.BackColor = Color.Transparent;
      this.txtRebirthMaxType.Cursor = Cursors.Default;
      this.txtRebirthMaxType.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthMaxType.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthMaxType.Location = new Point(122, 24);
      this.txtRebirthMaxType.Name = "txtRebirthMaxType";
      this.txtRebirthMaxType.Size = new Size(12, 13);
      this.txtRebirthMaxType.TabIndex = 92;
      this.txtRebirthMaxType.Text = "-";
      this.label33.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label33.BackColor = Color.Transparent;
      this.label33.Cursor = Cursors.Default;
      this.label33.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label33.ForeColor = SystemColors.ActiveCaptionText;
      this.label33.Location = new Point(6, 24);
      this.label33.Name = "label33";
      this.label33.Size = new Size(112, 13);
      this.label33.TabIndex = 93;
      this.label33.Text = "Max Type Level";
      this.label33.TextAlign = ContentAlignment.MiddleRight;
      this.lstRebirthRewards.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader9
      });
      this.lstRebirthRewards.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstRebirthRewards.FullRowSelect = true;
      this.lstRebirthRewards.HeaderStyle = ColumnHeaderStyle.None;
      this.lstRebirthRewards.Location = new Point(9, 63);
      this.lstRebirthRewards.MultiSelect = false;
      this.lstRebirthRewards.Name = "lstRebirthRewards";
      this.lstRebirthRewards.Size = new Size(355, 54);
      this.lstRebirthRewards.TabIndex = 91;
      this.lstRebirthRewards.UseCompatibleStateImageBehavior = false;
      this.lstRebirthRewards.View = View.Details;
      this.lstRebirthRewards.SelectedIndexChanged += new EventHandler(this.lstRebirthRewards_SelectedIndexChanged);
      this.columnHeader9.Width = 345;
      this.label17.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label17.ForeColor = Color.DarkRed;
      this.label17.Location = new Point(6, 150);
      this.label17.Name = "label17";
      this.label17.Size = new Size(373, 30);
      this.label17.TabIndex = 90;
      this.label17.Text = "Note - Bonus points spent on extend codes when rebirthing in game cannot be reversed and are lost forever.";
      this.label32.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label32.BackColor = Color.Transparent;
      this.label32.Cursor = Cursors.Default;
      this.label32.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label32.ForeColor = SystemColors.ActiveCaptionText;
      this.label32.Location = new Point(6, 47);
      this.label32.Name = "label32";
      this.label32.Size = new Size(297, 13);
      this.label32.TabIndex = 89;
      this.label32.Text = "Current Rebirth Rewards";
      this.label32.TextAlign = ContentAlignment.MiddleLeft;
      this.txtRebirthCount.AutoSize = true;
      this.txtRebirthCount.BackColor = Color.Transparent;
      this.txtRebirthCount.Cursor = Cursors.Default;
      this.txtRebirthCount.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthCount.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthCount.Location = new Point(122, 7);
      this.txtRebirthCount.Name = "txtRebirthCount";
      this.txtRebirthCount.Size = new Size(12, 13);
      this.txtRebirthCount.TabIndex = 76;
      this.txtRebirthCount.Text = "-";
      this.txtRebirthPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtRebirthPoints.BackColor = Color.Transparent;
      this.txtRebirthPoints.Cursor = Cursors.Default;
      this.txtRebirthPoints.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthPoints.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthPoints.Location = new Point(396, 7);
      this.txtRebirthPoints.Name = "txtRebirthPoints";
      this.txtRebirthPoints.Size = new Size(226, 12);
      this.txtRebirthPoints.TabIndex = 78;
      this.txtRebirthPoints.Text = "-";
      this.txtRebirthPoints.TextAlign = ContentAlignment.MiddleRight;
      this.label48.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label48.BackColor = Color.Transparent;
      this.label48.Cursor = Cursors.Default;
      this.label48.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label48.ForeColor = SystemColors.ActiveCaptionText;
      this.label48.Location = new Point(6, 7);
      this.label48.Name = "label48";
      this.label48.Size = new Size(112, 13);
      this.label48.TabIndex = 77;
      this.label48.Text = "Rebirth Count";
      this.label48.TextAlign = ContentAlignment.MiddleRight;
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextSTA);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextPP);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextHP);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextMND);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextTEC);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextEVA);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextACC);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextDEF);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthNextATK);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpSTA);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpPP);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpHP);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpMND);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpTEC);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpEVA);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpACC);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpDEF);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthBpATK);
      this.grpRebirth.Controls.Add((Control) this.label41);
      this.grpRebirth.Controls.Add((Control) this.label40);
      this.grpRebirth.Controls.Add((Control) this.label37);
      this.grpRebirth.Controls.Add((Control) this.numRebirthSTA);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthSTA);
      this.grpRebirth.Controls.Add((Control) this.label50);
      this.grpRebirth.Controls.Add((Control) this.numRebirthPP);
      this.grpRebirth.Controls.Add((Control) this.numRebirthHP);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthPP);
      this.grpRebirth.Controls.Add((Control) this.label55);
      this.grpRebirth.Controls.Add((Control) this.label56);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthHP);
      this.grpRebirth.Controls.Add((Control) this.numRebirthMND);
      this.grpRebirth.Controls.Add((Control) this.numRebirthTEC);
      this.grpRebirth.Controls.Add((Control) this.numRebirthEVA);
      this.grpRebirth.Controls.Add((Control) this.numRebirthACC);
      this.grpRebirth.Controls.Add((Control) this.numRebirthDEF);
      this.grpRebirth.Controls.Add((Control) this.numRebirthATK);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthMND);
      this.grpRebirth.Controls.Add((Control) this.label53);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthTEC);
      this.grpRebirth.Controls.Add((Control) this.label38);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthEVA);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthACC);
      this.grpRebirth.Controls.Add((Control) this.label42);
      this.grpRebirth.Controls.Add((Control) this.label43);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthDEF);
      this.grpRebirth.Controls.Add((Control) this.label45);
      this.grpRebirth.Controls.Add((Control) this.label49);
      this.grpRebirth.Controls.Add((Control) this.txtRebirthATK);
      this.grpRebirth.Location = new Point(396, 16);
      this.grpRebirth.Name = "grpRebirth";
      this.grpRebirth.Size = new Size(228, 201);
      this.grpRebirth.TabIndex = 75;
      this.grpRebirth.TabStop = false;
      this.txtRebirthNextSTA.AutoSize = true;
      this.txtRebirthNextSTA.BackColor = Color.Transparent;
      this.txtRebirthNextSTA.Cursor = Cursors.Default;
      this.txtRebirthNextSTA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextSTA.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextSTA.Location = new Point(187, 180);
      this.txtRebirthNextSTA.Name = "txtRebirthNextSTA";
      this.txtRebirthNextSTA.Size = new Size(10, 12);
      this.txtRebirthNextSTA.TabIndex = 108;
      this.txtRebirthNextSTA.Text = "-";
      this.txtRebirthNextPP.AutoSize = true;
      this.txtRebirthNextPP.BackColor = Color.Transparent;
      this.txtRebirthNextPP.Cursor = Cursors.Default;
      this.txtRebirthNextPP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextPP.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextPP.Location = new Point(187, 47);
      this.txtRebirthNextPP.Name = "txtRebirthNextPP";
      this.txtRebirthNextPP.Size = new Size(10, 12);
      this.txtRebirthNextPP.TabIndex = 107;
      this.txtRebirthNextPP.Text = "-";
      this.txtRebirthNextHP.AutoSize = true;
      this.txtRebirthNextHP.BackColor = Color.Transparent;
      this.txtRebirthNextHP.Cursor = Cursors.Default;
      this.txtRebirthNextHP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextHP.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextHP.Location = new Point(187, 28);
      this.txtRebirthNextHP.Name = "txtRebirthNextHP";
      this.txtRebirthNextHP.Size = new Size(10, 12);
      this.txtRebirthNextHP.TabIndex = 106;
      this.txtRebirthNextHP.Text = "-";
      this.txtRebirthNextMND.AutoSize = true;
      this.txtRebirthNextMND.BackColor = Color.Transparent;
      this.txtRebirthNextMND.Cursor = Cursors.Default;
      this.txtRebirthNextMND.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextMND.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextMND.Location = new Point(187, 161);
      this.txtRebirthNextMND.Name = "txtRebirthNextMND";
      this.txtRebirthNextMND.Size = new Size(10, 12);
      this.txtRebirthNextMND.TabIndex = 105;
      this.txtRebirthNextMND.Text = "-";
      this.txtRebirthNextTEC.AutoSize = true;
      this.txtRebirthNextTEC.BackColor = Color.Transparent;
      this.txtRebirthNextTEC.Cursor = Cursors.Default;
      this.txtRebirthNextTEC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextTEC.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextTEC.Location = new Point(187, 142);
      this.txtRebirthNextTEC.Name = "txtRebirthNextTEC";
      this.txtRebirthNextTEC.Size = new Size(10, 12);
      this.txtRebirthNextTEC.TabIndex = 104;
      this.txtRebirthNextTEC.Text = "-";
      this.txtRebirthNextEVA.AutoSize = true;
      this.txtRebirthNextEVA.BackColor = Color.Transparent;
      this.txtRebirthNextEVA.Cursor = Cursors.Default;
      this.txtRebirthNextEVA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextEVA.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextEVA.Location = new Point(187, 123);
      this.txtRebirthNextEVA.Name = "txtRebirthNextEVA";
      this.txtRebirthNextEVA.Size = new Size(10, 12);
      this.txtRebirthNextEVA.TabIndex = 101;
      this.txtRebirthNextEVA.Text = "-";
      this.txtRebirthNextACC.AutoSize = true;
      this.txtRebirthNextACC.BackColor = Color.Transparent;
      this.txtRebirthNextACC.Cursor = Cursors.Default;
      this.txtRebirthNextACC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextACC.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextACC.Location = new Point(187, 104);
      this.txtRebirthNextACC.Name = "txtRebirthNextACC";
      this.txtRebirthNextACC.Size = new Size(10, 12);
      this.txtRebirthNextACC.TabIndex = 103;
      this.txtRebirthNextACC.Text = "-";
      this.txtRebirthNextDEF.AutoSize = true;
      this.txtRebirthNextDEF.BackColor = Color.Transparent;
      this.txtRebirthNextDEF.Cursor = Cursors.Default;
      this.txtRebirthNextDEF.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextDEF.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextDEF.Location = new Point(187, 85);
      this.txtRebirthNextDEF.Name = "txtRebirthNextDEF";
      this.txtRebirthNextDEF.Size = new Size(10, 12);
      this.txtRebirthNextDEF.TabIndex = 102;
      this.txtRebirthNextDEF.Text = "-";
      this.txtRebirthNextATK.AutoSize = true;
      this.txtRebirthNextATK.BackColor = Color.Transparent;
      this.txtRebirthNextATK.Cursor = Cursors.Default;
      this.txtRebirthNextATK.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthNextATK.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthNextATK.Location = new Point(187, 66);
      this.txtRebirthNextATK.Name = "txtRebirthNextATK";
      this.txtRebirthNextATK.Size = new Size(10, 12);
      this.txtRebirthNextATK.TabIndex = 100;
      this.txtRebirthNextATK.Text = "-";
      this.txtRebirthBpSTA.AutoSize = true;
      this.txtRebirthBpSTA.BackColor = Color.Transparent;
      this.txtRebirthBpSTA.Cursor = Cursors.Default;
      this.txtRebirthBpSTA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpSTA.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpSTA.Location = new Point(94, 180);
      this.txtRebirthBpSTA.Name = "txtRebirthBpSTA";
      this.txtRebirthBpSTA.Size = new Size(10, 12);
      this.txtRebirthBpSTA.TabIndex = 99;
      this.txtRebirthBpSTA.Text = "-";
      this.txtRebirthBpPP.AutoSize = true;
      this.txtRebirthBpPP.BackColor = Color.Transparent;
      this.txtRebirthBpPP.Cursor = Cursors.Default;
      this.txtRebirthBpPP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpPP.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpPP.Location = new Point(94, 47);
      this.txtRebirthBpPP.Name = "txtRebirthBpPP";
      this.txtRebirthBpPP.Size = new Size(10, 12);
      this.txtRebirthBpPP.TabIndex = 98;
      this.txtRebirthBpPP.Text = "-";
      this.txtRebirthBpHP.AutoSize = true;
      this.txtRebirthBpHP.BackColor = Color.Transparent;
      this.txtRebirthBpHP.Cursor = Cursors.Default;
      this.txtRebirthBpHP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpHP.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpHP.Location = new Point(94, 28);
      this.txtRebirthBpHP.Name = "txtRebirthBpHP";
      this.txtRebirthBpHP.Size = new Size(10, 12);
      this.txtRebirthBpHP.TabIndex = 97;
      this.txtRebirthBpHP.Text = "-";
      this.txtRebirthBpMND.AutoSize = true;
      this.txtRebirthBpMND.BackColor = Color.Transparent;
      this.txtRebirthBpMND.Cursor = Cursors.Default;
      this.txtRebirthBpMND.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpMND.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpMND.Location = new Point(94, 161);
      this.txtRebirthBpMND.Name = "txtRebirthBpMND";
      this.txtRebirthBpMND.Size = new Size(10, 12);
      this.txtRebirthBpMND.TabIndex = 96;
      this.txtRebirthBpMND.Text = "-";
      this.txtRebirthBpTEC.AutoSize = true;
      this.txtRebirthBpTEC.BackColor = Color.Transparent;
      this.txtRebirthBpTEC.Cursor = Cursors.Default;
      this.txtRebirthBpTEC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpTEC.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpTEC.Location = new Point(94, 142);
      this.txtRebirthBpTEC.Name = "txtRebirthBpTEC";
      this.txtRebirthBpTEC.Size = new Size(10, 12);
      this.txtRebirthBpTEC.TabIndex = 95;
      this.txtRebirthBpTEC.Text = "-";
      this.txtRebirthBpEVA.AutoSize = true;
      this.txtRebirthBpEVA.BackColor = Color.Transparent;
      this.txtRebirthBpEVA.Cursor = Cursors.Default;
      this.txtRebirthBpEVA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpEVA.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpEVA.Location = new Point(94, 123);
      this.txtRebirthBpEVA.Name = "txtRebirthBpEVA";
      this.txtRebirthBpEVA.Size = new Size(10, 12);
      this.txtRebirthBpEVA.TabIndex = 92;
      this.txtRebirthBpEVA.Text = "-";
      this.txtRebirthBpACC.AutoSize = true;
      this.txtRebirthBpACC.BackColor = Color.Transparent;
      this.txtRebirthBpACC.Cursor = Cursors.Default;
      this.txtRebirthBpACC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpACC.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpACC.Location = new Point(94, 104);
      this.txtRebirthBpACC.Name = "txtRebirthBpACC";
      this.txtRebirthBpACC.Size = new Size(10, 12);
      this.txtRebirthBpACC.TabIndex = 94;
      this.txtRebirthBpACC.Text = "-";
      this.txtRebirthBpDEF.AutoSize = true;
      this.txtRebirthBpDEF.BackColor = Color.Transparent;
      this.txtRebirthBpDEF.Cursor = Cursors.Default;
      this.txtRebirthBpDEF.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpDEF.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpDEF.Location = new Point(94, 85);
      this.txtRebirthBpDEF.Name = "txtRebirthBpDEF";
      this.txtRebirthBpDEF.Size = new Size(10, 12);
      this.txtRebirthBpDEF.TabIndex = 93;
      this.txtRebirthBpDEF.Text = "-";
      this.txtRebirthBpATK.AutoSize = true;
      this.txtRebirthBpATK.BackColor = Color.Transparent;
      this.txtRebirthBpATK.Cursor = Cursors.Default;
      this.txtRebirthBpATK.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthBpATK.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthBpATK.Location = new Point(94, 66);
      this.txtRebirthBpATK.Name = "txtRebirthBpATK";
      this.txtRebirthBpATK.Size = new Size(10, 12);
      this.txtRebirthBpATK.TabIndex = 91;
      this.txtRebirthBpATK.Text = "-";
      this.label41.BackColor = Color.Transparent;
      this.label41.Cursor = Cursors.Default;
      this.label41.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label41.ForeColor = Color.DimGray;
      this.label41.Location = new Point(187, 9);
      this.label41.Name = "label41";
      this.label41.Size = new Size(39, 13);
      this.label41.TabIndex = 90;
      this.label41.Text = "NEXT";
      this.label41.TextAlign = ContentAlignment.MiddleLeft;
      this.label40.BackColor = Color.Transparent;
      this.label40.Cursor = Cursors.Default;
      this.label40.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label40.ForeColor = Color.DimGray;
      this.label40.Location = new Point(94, 9);
      this.label40.Name = "label40";
      this.label40.Size = new Size(48, 13);
      this.label40.TabIndex = 89;
      this.label40.Text = "BP";
      this.label40.TextAlign = ContentAlignment.MiddleLeft;
      this.label37.BackColor = Color.Transparent;
      this.label37.Cursor = Cursors.Default;
      this.label37.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label37.ForeColor = Color.DimGray;
      this.label37.Location = new Point(11, 9);
      this.label37.Name = "label37";
      this.label37.Size = new Size(48, 13);
      this.label37.TabIndex = 88;
      this.label37.Text = "STAT";
      this.label37.TextAlign = ContentAlignment.MiddleRight;
      this.numRebirthSTA.Cursor = Cursors.Hand;
      this.numRebirthSTA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthSTA.Location = new Point(148, 178);
      this.numRebirthSTA.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthSTA.Name = "numRebirthSTA";
      this.numRebirthSTA.Size = new Size(37, 18);
      this.numRebirthSTA.TabIndex = 87;
      this.numRebirthSTA.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.txtRebirthSTA.AutoSize = true;
      this.txtRebirthSTA.BackColor = Color.Transparent;
      this.txtRebirthSTA.Cursor = Cursors.Default;
      this.txtRebirthSTA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthSTA.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthSTA.Location = new Point(49, 180);
      this.txtRebirthSTA.Name = "txtRebirthSTA";
      this.txtRebirthSTA.Size = new Size(10, 12);
      this.txtRebirthSTA.TabIndex = 86;
      this.txtRebirthSTA.Text = "-";
      this.label50.BackColor = Color.Transparent;
      this.label50.Cursor = Cursors.Default;
      this.label50.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label50.ForeColor = SystemColors.ActiveCaptionText;
      this.label50.Location = new Point(11, 180);
      this.label50.Name = "label50";
      this.label50.Size = new Size(33, 13);
      this.label50.TabIndex = 85;
      this.label50.Text = "STA";
      this.label50.TextAlign = ContentAlignment.MiddleRight;
      this.numRebirthPP.Cursor = Cursors.Hand;
      this.numRebirthPP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthPP.Location = new Point(148, 45);
      this.numRebirthPP.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthPP.Name = "numRebirthPP";
      this.numRebirthPP.Size = new Size(37, 18);
      this.numRebirthPP.TabIndex = 84;
      this.numRebirthPP.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.numRebirthHP.Cursor = Cursors.Hand;
      this.numRebirthHP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthHP.Location = new Point(148, 26);
      this.numRebirthHP.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthHP.Name = "numRebirthHP";
      this.numRebirthHP.Size = new Size(37, 18);
      this.numRebirthHP.TabIndex = 83;
      this.numRebirthHP.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.txtRebirthPP.AutoSize = true;
      this.txtRebirthPP.BackColor = Color.Transparent;
      this.txtRebirthPP.Cursor = Cursors.Default;
      this.txtRebirthPP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthPP.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthPP.Location = new Point(49, 47);
      this.txtRebirthPP.Name = "txtRebirthPP";
      this.txtRebirthPP.Size = new Size(10, 12);
      this.txtRebirthPP.TabIndex = 82;
      this.txtRebirthPP.Text = "-";
      this.label55.BackColor = Color.Transparent;
      this.label55.Cursor = Cursors.Default;
      this.label55.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label55.ForeColor = SystemColors.ActiveCaptionText;
      this.label55.Location = new Point(11, 47);
      this.label55.Name = "label55";
      this.label55.Size = new Size(33, 13);
      this.label55.TabIndex = 81;
      this.label55.Text = "PP";
      this.label55.TextAlign = ContentAlignment.MiddleRight;
      this.label56.BackColor = Color.Transparent;
      this.label56.Cursor = Cursors.Default;
      this.label56.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label56.ForeColor = SystemColors.ActiveCaptionText;
      this.label56.Location = new Point(11, 28);
      this.label56.Name = "label56";
      this.label56.Size = new Size(33, 13);
      this.label56.TabIndex = 79;
      this.label56.Text = "HP";
      this.label56.TextAlign = ContentAlignment.MiddleRight;
      this.txtRebirthHP.AutoSize = true;
      this.txtRebirthHP.BackColor = Color.Transparent;
      this.txtRebirthHP.Cursor = Cursors.Default;
      this.txtRebirthHP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthHP.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthHP.Location = new Point(49, 28);
      this.txtRebirthHP.Name = "txtRebirthHP";
      this.txtRebirthHP.Size = new Size(10, 12);
      this.txtRebirthHP.TabIndex = 80;
      this.txtRebirthHP.Text = "-";
      this.numRebirthMND.Cursor = Cursors.Hand;
      this.numRebirthMND.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthMND.Location = new Point(148, 159);
      this.numRebirthMND.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthMND.Name = "numRebirthMND";
      this.numRebirthMND.Size = new Size(37, 18);
      this.numRebirthMND.TabIndex = 74;
      this.numRebirthMND.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.numRebirthTEC.Cursor = Cursors.Hand;
      this.numRebirthTEC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthTEC.Location = new Point(148, 140);
      this.numRebirthTEC.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthTEC.Name = "numRebirthTEC";
      this.numRebirthTEC.Size = new Size(37, 18);
      this.numRebirthTEC.TabIndex = 73;
      this.numRebirthTEC.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.numRebirthEVA.Cursor = Cursors.Hand;
      this.numRebirthEVA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthEVA.Location = new Point(148, 121);
      this.numRebirthEVA.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthEVA.Name = "numRebirthEVA";
      this.numRebirthEVA.Size = new Size(37, 18);
      this.numRebirthEVA.TabIndex = 72;
      this.numRebirthEVA.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.numRebirthACC.Cursor = Cursors.Hand;
      this.numRebirthACC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthACC.Location = new Point(148, 102);
      this.numRebirthACC.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthACC.Name = "numRebirthACC";
      this.numRebirthACC.Size = new Size(37, 18);
      this.numRebirthACC.TabIndex = 71;
      this.numRebirthACC.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.numRebirthDEF.Cursor = Cursors.Hand;
      this.numRebirthDEF.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthDEF.Location = new Point(148, 83);
      this.numRebirthDEF.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthDEF.Name = "numRebirthDEF";
      this.numRebirthDEF.Size = new Size(37, 18);
      this.numRebirthDEF.TabIndex = 70;
      this.numRebirthDEF.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.numRebirthATK.Cursor = Cursors.Hand;
      this.numRebirthATK.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.numRebirthATK.Location = new Point(148, 64);
      this.numRebirthATK.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numRebirthATK.Name = "numRebirthATK";
      this.numRebirthATK.Size = new Size(37, 18);
      this.numRebirthATK.TabIndex = 69;
      this.numRebirthATK.ValueChanged += new EventHandler(this.numRebirth_ValueChanged);
      this.txtRebirthMND.AutoSize = true;
      this.txtRebirthMND.BackColor = Color.Transparent;
      this.txtRebirthMND.Cursor = Cursors.Default;
      this.txtRebirthMND.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthMND.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthMND.Location = new Point(49, 161);
      this.txtRebirthMND.Name = "txtRebirthMND";
      this.txtRebirthMND.Size = new Size(10, 12);
      this.txtRebirthMND.TabIndex = 68;
      this.txtRebirthMND.Text = "-";
      this.label53.BackColor = Color.Transparent;
      this.label53.Cursor = Cursors.Default;
      this.label53.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label53.ForeColor = SystemColors.ActiveCaptionText;
      this.label53.Location = new Point(11, 161);
      this.label53.Name = "label53";
      this.label53.Size = new Size(33, 13);
      this.label53.TabIndex = 67;
      this.label53.Text = "MND";
      this.label53.TextAlign = ContentAlignment.MiddleRight;
      this.txtRebirthTEC.AutoSize = true;
      this.txtRebirthTEC.BackColor = Color.Transparent;
      this.txtRebirthTEC.Cursor = Cursors.Default;
      this.txtRebirthTEC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthTEC.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthTEC.Location = new Point(49, 142);
      this.txtRebirthTEC.Name = "txtRebirthTEC";
      this.txtRebirthTEC.Size = new Size(10, 12);
      this.txtRebirthTEC.TabIndex = 66;
      this.txtRebirthTEC.Text = "-";
      this.label38.BackColor = Color.Transparent;
      this.label38.Cursor = Cursors.Default;
      this.label38.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label38.ForeColor = SystemColors.ActiveCaptionText;
      this.label38.Location = new Point(11, 142);
      this.label38.Name = "label38";
      this.label38.Size = new Size(33, 13);
      this.label38.TabIndex = 65;
      this.label38.Text = "TEC";
      this.label38.TextAlign = ContentAlignment.MiddleRight;
      this.txtRebirthEVA.AutoSize = true;
      this.txtRebirthEVA.BackColor = Color.Transparent;
      this.txtRebirthEVA.Cursor = Cursors.Default;
      this.txtRebirthEVA.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthEVA.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthEVA.Location = new Point(49, 123);
      this.txtRebirthEVA.Name = "txtRebirthEVA";
      this.txtRebirthEVA.Size = new Size(10, 12);
      this.txtRebirthEVA.TabIndex = 60;
      this.txtRebirthEVA.Text = "-";
      this.txtRebirthACC.AutoSize = true;
      this.txtRebirthACC.BackColor = Color.Transparent;
      this.txtRebirthACC.Cursor = Cursors.Default;
      this.txtRebirthACC.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthACC.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthACC.Location = new Point(49, 104);
      this.txtRebirthACC.Name = "txtRebirthACC";
      this.txtRebirthACC.Size = new Size(10, 12);
      this.txtRebirthACC.TabIndex = 64;
      this.txtRebirthACC.Text = "-";
      this.label42.BackColor = Color.Transparent;
      this.label42.Cursor = Cursors.Default;
      this.label42.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label42.ForeColor = SystemColors.ActiveCaptionText;
      this.label42.Location = new Point(11, 123);
      this.label42.Name = "label42";
      this.label42.Size = new Size(33, 13);
      this.label42.TabIndex = 59;
      this.label42.Text = "EVA";
      this.label42.TextAlign = ContentAlignment.MiddleRight;
      this.label43.BackColor = Color.Transparent;
      this.label43.Cursor = Cursors.Default;
      this.label43.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label43.ForeColor = SystemColors.ActiveCaptionText;
      this.label43.Location = new Point(11, 104);
      this.label43.Name = "label43";
      this.label43.Size = new Size(33, 13);
      this.label43.TabIndex = 63;
      this.label43.Text = "ACC";
      this.label43.TextAlign = ContentAlignment.MiddleRight;
      this.txtRebirthDEF.AutoSize = true;
      this.txtRebirthDEF.BackColor = Color.Transparent;
      this.txtRebirthDEF.Cursor = Cursors.Default;
      this.txtRebirthDEF.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthDEF.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthDEF.Location = new Point(49, 85);
      this.txtRebirthDEF.Name = "txtRebirthDEF";
      this.txtRebirthDEF.Size = new Size(10, 12);
      this.txtRebirthDEF.TabIndex = 62;
      this.txtRebirthDEF.Text = "-";
      this.label45.BackColor = Color.Transparent;
      this.label45.Cursor = Cursors.Default;
      this.label45.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label45.ForeColor = SystemColors.ActiveCaptionText;
      this.label45.Location = new Point(11, 85);
      this.label45.Name = "label45";
      this.label45.Size = new Size(33, 13);
      this.label45.TabIndex = 61;
      this.label45.Text = "DEF";
      this.label45.TextAlign = ContentAlignment.MiddleRight;
      this.label49.BackColor = Color.Transparent;
      this.label49.Cursor = Cursors.Default;
      this.label49.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label49.ForeColor = SystemColors.ActiveCaptionText;
      this.label49.Location = new Point(11, 66);
      this.label49.Name = "label49";
      this.label49.Size = new Size(33, 13);
      this.label49.TabIndex = 57;
      this.label49.Text = "ATK";
      this.label49.TextAlign = ContentAlignment.MiddleRight;
      this.txtRebirthATK.AutoSize = true;
      this.txtRebirthATK.BackColor = Color.Transparent;
      this.txtRebirthATK.Cursor = Cursors.Default;
      this.txtRebirthATK.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRebirthATK.ForeColor = SystemColors.ActiveCaptionText;
      this.txtRebirthATK.Location = new Point(49, 66);
      this.txtRebirthATK.Name = "txtRebirthATK";
      this.txtRebirthATK.Size = new Size(10, 12);
      this.txtRebirthATK.TabIndex = 58;
      this.txtRebirthATK.Text = "-";
      this.btnUndoAll.Cursor = Cursors.Hand;
      this.btnUndoAll.Enabled = false;
      this.btnUndoAll.Location = new Point(128, 488);
      this.btnUndoAll.Name = "btnUndoAll";
      this.btnUndoAll.Size = new Size(59, 23);
      this.btnUndoAll.TabIndex = 23;
      this.btnUndoAll.Text = "reload";
      this.btnUndoAll.UseVisualStyleBackColor = true;
      this.btnUndoAll.Click += new EventHandler(this.btnUndoAll_Click);
      this.btnSaveAs.Cursor = Cursors.Hand;
      this.btnSaveAs.Enabled = false;
      this.btnSaveAs.Location = new Point(66, 488);
      this.btnSaveAs.Name = "btnSaveAs";
      this.btnSaveAs.Size = new Size(60, 23);
      this.btnSaveAs.TabIndex = 24;
      this.btnSaveAs.Text = "save as";
      this.btnSaveAs.UseVisualStyleBackColor = true;
      this.btnSaveAs.Click += new EventHandler(this.btnSaveAs_Click);
      this.sexImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("sexImageList.ImageStream");
      this.sexImageList.TransparentColor = Color.Transparent;
      this.sexImageList.Images.SetKeyName(0, "male-icon.ico");
      this.sexImageList.Images.SetKeyName(1, "female.png");
      this.sexImageList.Images.SetKeyName(2, "free_slot_2.ico");
      this.armourImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("armourImageList.ImageStream");
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
      this.armourImageList.Images.SetKeyName(16, "a_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(17, "a_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(18, "a_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(19, "b_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(20, "b_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(21, "b_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(22, "b_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(23, "c_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(24, "c_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(25, "c_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(26, "c_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(27, "s_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(28, "s_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(29, "s_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(30, "s_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(31, "unk_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(32, "unk_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(33, "unk_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(34, "unk_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(35, "a_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(36, "a_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(37, "a_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(38, "a_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(39, "b_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(40, "b_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(41, "b_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(42, "b_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(43, "c_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(44, "c_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(45, "c_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(46, "c_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(47, "s_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(48, "s_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(49, "s_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(50, "s_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(51, "unk_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(52, "unk_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(53, "unk_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(54, "unk_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(55, "a_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(56, "a_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(57, "a_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(58, "a_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(59, "b_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(60, "b_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(61, "b_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(62, "b_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(63, "c_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(64, "c_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(65, "c_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(66, "c_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(67, "s_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(68, "s_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(69, "s_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(70, "s_004_unit_visual.jpg");
      this.armourImageList.Images.SetKeyName(71, "unk_001_unit.jpg");
      this.armourImageList.Images.SetKeyName(72, "unk_002_unit_mirage.jpg");
      this.armourImageList.Images.SetKeyName(73, "unk_003_unit_suv.jpg");
      this.armourImageList.Images.SetKeyName(74, "unk_004_unit_visual.jpg");
      this.itemImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("itemImageList.ImageStream");
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
      this.itemImageList.Images.SetKeyName(16, "item_08_calorie.png");
      this.itemImageList.Images.SetKeyName(17, "item_09.png");
      this.itemImageList.Images.SetKeyName(18, "item_01_pa_disk.png");
      this.itemImageList.Images.SetKeyName(19, "item_02_trap.png");
      this.itemImageList.Images.SetKeyName(20, "item_03_trap_ex.png");
      this.itemImageList.Images.SetKeyName(21, "item_04_mate.png");
      this.itemImageList.Images.SetKeyName(22, "item_05_sol.png");
      this.itemImageList.Images.SetKeyName(23, "item_06_doll.png");
      this.itemImageList.Images.SetKeyName(24, "item_07_buff.png");
      this.itemImageList.Images.SetKeyName(25, "item_08_calorie.png");
      this.itemImageList.Images.SetKeyName(26, "item_09.png");
      this.clothesImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("clothesImageList.ImageStream");
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
      this.clothesImageList.Images.SetKeyName(16, "parts_01_torso.png");
      this.clothesImageList.Images.SetKeyName(17, "parts_02_legs.png");
      this.clothesImageList.Images.SetKeyName(18, "parts_03_arms.png");
      this.clothesImageList.Images.SetKeyName(19, "parts_04_set.png");
      this.clothesImageList.Images.SetKeyName(20, "clothes_01_top.png");
      this.clothesImageList.Images.SetKeyName(21, "clothes_02_bottom.png");
      this.clothesImageList.Images.SetKeyName(22, "clothes_03_shoes.png");
      this.clothesImageList.Images.SetKeyName(23, "clothes_04_top_set.png");
      this.clothesImageList.Images.SetKeyName(24, "clothes_05_bottom_set.png");
      this.clothesImageList.Images.SetKeyName(25, "clothes_06_set.png");
      this.clothesImageList.Images.SetKeyName(26, "parts_01_torso.png");
      this.clothesImageList.Images.SetKeyName(27, "parts_02_legs.png");
      this.clothesImageList.Images.SetKeyName(28, "parts_03_arms.png");
      this.clothesImageList.Images.SetKeyName(29, "parts_04_set.png");
      this.decoImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("decoImageList.ImageStream");
      this.decoImageList.TransparentColor = Color.Transparent;
      this.decoImageList.Images.SetKeyName(0, "item_extend.png");
      this.decoImageList.Images.SetKeyName(1, "item_pm.png");
      this.decoImageList.Images.SetKeyName(2, "item_decoration.png");
      this.decoImageList.Images.SetKeyName(3, "free_slot.png");
      this.menuStrip.ImageScalingSize = new Size(0, 0);
      this.menuStrip.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.databasesToolStripMenuItem,
        (ToolStripItem) this.imagesToolStripMenuItem,
        (ToolStripItem) this.helpToolStripMenuItem
      });
      this.menuStrip.Location = new Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new Size(650, 24);
      this.menuStrip.TabIndex = 73;
      this.menuStrip.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.openToolStripMenuItem,
        (ToolStripItem) this.saveToolStripMenuItem,
        (ToolStripItem) this.saveAsToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.updateToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      this.openToolStripMenuItem.Image = (Image) Resources.open1;
      this.openToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
      this.openToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new Size(171, 22);
      this.openToolStripMenuItem.Text = "Open";
      this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.saveToolStripMenuItem.Image = (Image) Resources.save_icon;
      this.saveToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new Size(171, 22);
      this.saveToolStripMenuItem.Text = "Save";
      this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new Size(171, 22);
      this.saveAsToolStripMenuItem.Text = "Save As...";
      this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(168, 6);
      this.updateToolStripMenuItem.Image = (Image) Resources.check_for_update;
      this.updateToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
      this.updateToolStripMenuItem.Size = new Size(171, 22);
      this.updateToolStripMenuItem.Text = "Check For Updates";
      this.updateToolStripMenuItem.Click += new EventHandler(this.updateToolStripMenuItem_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(168, 6);
      this.exitToolStripMenuItem.Image = (Image) Resources.exit1;
      this.exitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(171, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.databasesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.itemDatabasesToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.refreshToolStripMenuItem,
        (ToolStripItem) this.checkForUpdatesToolStripMenuItem
      });
      this.databasesToolStripMenuItem.Name = "databasesToolStripMenuItem";
      this.databasesToolStripMenuItem.Size = new Size(72, 20);
      this.databasesToolStripMenuItem.Text = "Databases";
      this.itemDatabasesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.weaponDatabaseToolStripMenuItem
      });
      this.itemDatabasesToolStripMenuItem.Image = (Image) Resources.database_import;
      this.itemDatabasesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.itemDatabasesToolStripMenuItem.Name = "itemDatabasesToolStripMenuItem";
      this.itemDatabasesToolStripMenuItem.Size = new Size(171, 22);
      this.itemDatabasesToolStripMenuItem.Text = "Item Databases";
      this.weaponDatabaseToolStripMenuItem.Name = "weaponDatabaseToolStripMenuItem";
      this.weaponDatabaseToolStripMenuItem.Size = new Size(169, 22);
      this.weaponDatabaseToolStripMenuItem.Text = "Weapon Database";
      this.weaponDatabaseToolStripMenuItem.Click += new EventHandler(this.weaponDatabaseToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(168, 6);
      this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
      this.refreshToolStripMenuItem.Size = new Size(171, 22);
      this.refreshToolStripMenuItem.Text = "Refresh";
      this.refreshToolStripMenuItem.Click += new EventHandler(this.refreshToolStripMenuItem_Click);
      this.checkForUpdatesToolStripMenuItem.Image = (Image) Resources.check_for_update;
      this.checkForUpdatesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
      this.checkForUpdatesToolStripMenuItem.Size = new Size(171, 22);
      this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
      this.checkForUpdatesToolStripMenuItem.Click += new EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
      this.imagesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.refreshToolStripMenuItem1,
        (ToolStripItem) this.checkForUpdatesToolStripMenuItem1
      });
      this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
      this.imagesToolStripMenuItem.Size = new Size(55, 20);
      this.imagesToolStripMenuItem.Text = "Images";
      this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
      this.refreshToolStripMenuItem1.Size = new Size(171, 22);
      this.refreshToolStripMenuItem1.Text = "Refresh";
      this.refreshToolStripMenuItem1.Click += new EventHandler(this.refreshToolStripMenuItem1_Click);
      this.checkForUpdatesToolStripMenuItem1.Image = (Image) Resources.check_for_update;
      this.checkForUpdatesToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
      this.checkForUpdatesToolStripMenuItem1.Name = "checkForUpdatesToolStripMenuItem1";
      this.checkForUpdatesToolStripMenuItem1.Size = new Size(171, 22);
      this.checkForUpdatesToolStripMenuItem1.Text = "Check For Updates";
      this.checkForUpdatesToolStripMenuItem1.Click += new EventHandler(this.checkForUpdatesToolStripMenuItem1_Click);
      this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.aboutToolStripMenuItem,
        (ToolStripItem) this.versionInfoToolStripMenuItem
      });
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(43, 20);
      this.helpToolStripMenuItem.Text = "Help";
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(137, 22);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
      this.versionInfoToolStripMenuItem.Name = "versionInfoToolStripMenuItem";
      this.versionInfoToolStripMenuItem.Size = new Size(137, 22);
      this.versionInfoToolStripMenuItem.Text = "Version Info";
      this.versionInfoToolStripMenuItem.Click += new EventHandler(this.versionInfoToolStripMenuItem_Click);
      this.statusStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolStripProgressBar,
        (ToolStripItem) this.toolStripStatusLabel
      });
      this.statusStrip1.Location = new Point(0, 621);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.RightToLeft = RightToLeft.Yes;
      this.statusStrip1.Size = new Size(650, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 74;
      this.statusStrip1.Text = "statusStrip1";
      this.toolStripProgressBar.Alignment = ToolStripItemAlignment.Right;
      this.toolStripProgressBar.Name = "toolStripProgressBar";
      this.toolStripProgressBar.Size = new Size(100, 16);
      this.toolStripStatusLabel.Name = "toolStripStatusLabel";
      this.toolStripStatusLabel.Size = new Size(0, 17);
      this.txtFooterText.AutoSize = true;
      this.txtFooterText.BackColor = Color.Transparent;
      this.txtFooterText.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtFooterText.ForeColor = Color.DarkGray;
      this.txtFooterText.Location = new Point(0, 600);
      this.txtFooterText.Name = "txtFooterText";
      this.txtFooterText.Size = new Size(302, 12);
      this.txtFooterText.TabIndex = 75;
      this.txtFooterText.Text = "Phantasy Star Portable 2 Save Editor by FunkySkunk 2014";
      this.lstSaveSlotView.BackColor = SystemColors.Window;
      this.lstSaveSlotView.Columns.AddRange(new ColumnHeader[5]
      {
        this.slotViewHeader_name,
        this.slotViewHeader_level,
        this.slotViewHeader_class,
        this.slotViewHeader_type,
        this.slotViewHeader_complete
      });
      this.lstSaveSlotView.Cursor = Cursors.Hand;
      this.lstSaveSlotView.Enabled = false;
      this.lstSaveSlotView.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstSaveSlotView.ForeColor = SystemColors.ActiveCaptionText;
      this.lstSaveSlotView.FullRowSelect = true;
      this.lstSaveSlotView.HeaderStyle = ColumnHeaderStyle.None;
      this.lstSaveSlotView.HideSelection = false;
      this.lstSaveSlotView.LabelWrap = false;
      this.lstSaveSlotView.Location = new Point(183, 59);
      this.lstSaveSlotView.MultiSelect = false;
      this.lstSaveSlotView.Name = "lstSaveSlotView";
      this.lstSaveSlotView.Size = new Size(454, 140);
      this.lstSaveSlotView.SmallImageList = this.sexImageList;
      this.lstSaveSlotView.TabIndex = 84;
      this.lstSaveSlotView.UseCompatibleStateImageBehavior = false;
      this.lstSaveSlotView.View = View.Details;
      this.lstSaveSlotView.SelectedIndexChanged += new EventHandler(this.saveSlotView_SelectedIndexChanged);
      this.slotViewHeader_name.Width = 125;
      this.slotViewHeader_level.Width = 50;
      this.slotViewHeader_class.Width = 65;
      this.slotViewHeader_type.Width = 70;
      this.slotViewHeader_complete.Width = 140;
      this.txtFileSize.BackColor = Color.Transparent;
      this.txtFileSize.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtFileSize.ForeColor = SystemColors.ControlText;
      this.txtFileSize.Location = new Point(29, 146);
      this.txtFileSize.Name = "txtFileSize";
      this.txtFileSize.Size = new Size(143, 13);
      this.txtFileSize.TabIndex = 79;
      this.txtFileSize.Text = "0 bytes";
      this.txtFileSize.TextAlign = ContentAlignment.TopRight;
      this.btnExportCharacter.Cursor = Cursors.Hand;
      this.btnExportCharacter.Enabled = false;
      this.btnExportCharacter.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnExportCharacter.Location = new Point(280, 200);
      this.btnExportCharacter.Name = "btnExportCharacter";
      this.btnExportCharacter.Size = new Size(96, 20);
      this.btnExportCharacter.TabIndex = 82;
      this.btnExportCharacter.Text = "export character";
      this.btnExportCharacter.UseVisualStyleBackColor = true;
      this.btnExportCharacter.Click += new EventHandler(this.btnExportCharacter_Click);
      this.txtSlotnumloaded.AutoSize = true;
      this.txtSlotnumloaded.BackColor = SystemColors.Control;
      this.txtSlotnumloaded.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSlotnumloaded.ForeColor = Color.Black;
      this.txtSlotnumloaded.Location = new Point(530, 200);
      this.txtSlotnumloaded.Name = "txtSlotnumloaded";
      this.txtSlotnumloaded.Size = new Size(112, 12);
      this.txtSlotnumloaded.TabIndex = 81;
      this.txtSlotnumloaded.Text = "No Save Slot Loaded ";
      this.txtSlotnumloaded.TextAlign = ContentAlignment.TopRight;
      this.btnImportCharacter.Cursor = Cursors.Hand;
      this.btnImportCharacter.Enabled = false;
      this.btnImportCharacter.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnImportCharacter.Location = new Point(182, 200);
      this.btnImportCharacter.Name = "btnImportCharacter";
      this.btnImportCharacter.Size = new Size(96, 20);
      this.btnImportCharacter.TabIndex = 83;
      this.btnImportCharacter.Text = "import character";
      this.btnImportCharacter.UseVisualStyleBackColor = true;
      this.btnImportCharacter.Click += new EventHandler(this.btnImportCharacter_Click);
      this.txtFileLoc.Enabled = false;
      this.txtFileLoc.Location = new Point(20, 29);
      this.txtFileLoc.Name = "txtFileLoc";
      this.txtFileLoc.Size = new Size(584, 20);
      this.txtFileLoc.TabIndex = 77;
      this.btnBrowse.Cursor = Cursors.Hand;
      this.btnBrowse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnBrowse.Location = new Point(610, 29);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new Size(27, 20);
      this.btnBrowse.TabIndex = 76;
      this.btnBrowse.Text = "...";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new EventHandler(this.btnBrowse_Click);
      this.grpImageFloater.BackColor = SystemColors.Window;
      this.grpImageFloater.Controls.Add((Control) this.imgFloater);
      this.grpImageFloater.Controls.Add((Control) this.panelImageFloater);
      this.grpImageFloater.Location = new Point(458, 474);
      this.grpImageFloater.Name = "grpImageFloater";
      this.grpImageFloater.Size = new Size(174, 139);
      this.grpImageFloater.TabIndex = 72;
      this.grpImageFloater.TabStop = false;
      this.imgFloater.BackColor = Color.Black;
      this.imgFloater.Location = new Point(7, 13);
      this.imgFloater.Name = "imgFloater";
      this.imgFloater.Size = new Size(160, 120);
      this.imgFloater.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgFloater.TabIndex = 0;
      this.imgFloater.TabStop = false;
      this.panelImageFloater.Location = new Point(458, 480);
      this.panelImageFloater.Name = "panelImageFloater";
      this.panelImageFloater.Size = new Size(174, 133);
      this.panelImageFloater.TabIndex = 72;
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.Enabled = false;
      this.btnSave.Location = new Point(4, 488);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(60, 23);
      this.btnSave.TabIndex = 85;
      this.btnSave.Text = "save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      this.imageListWeaponElements.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageListWeaponElements.ImageStream");
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
      this.imageListWeaponElements.Images.SetKeyName(16, "017_grenade.png");
      this.imageListWeaponElements.Images.SetKeyName(17, "018_laser.png");
      this.imageListWeaponElements.Images.SetKeyName(18, "019_handguns.png");
      this.imageListWeaponElements.Images.SetKeyName(19, "020_handgun.png");
      this.imageListWeaponElements.Images.SetKeyName(20, "021_crossbow.png");
      this.imageListWeaponElements.Images.SetKeyName(21, "022_cards.png");
      this.imageListWeaponElements.Images.SetKeyName(22, "023_machinegun.png");
      this.imageListWeaponElements.Images.SetKeyName(23, "024_rod.png");
      this.imageListWeaponElements.Images.SetKeyName(24, "025_wand.png");
      this.imageListWeaponElements.Images.SetKeyName(25, "026_tmag.png");
      this.imageListWeaponElements.Images.SetKeyName(26, "027_rmag.png");
      this.imageListWeaponElements.Images.SetKeyName(27, "028_shield.png");
      this.imageListWeaponElements.Images.SetKeyName(28, "01_sword.png");
      this.imageListWeaponElements.Images.SetKeyName(29, "02_knuckles.png");
      this.imageListWeaponElements.Images.SetKeyName(30, "03_spear.png");
      this.imageListWeaponElements.Images.SetKeyName(31, "04_double_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(32, "05_axe.png");
      this.imageListWeaponElements.Images.SetKeyName(33, "06_sabers.png");
      this.imageListWeaponElements.Images.SetKeyName(34, "07_daggers.png");
      this.imageListWeaponElements.Images.SetKeyName(35, "08_claws.png");
      this.imageListWeaponElements.Images.SetKeyName(36, "009_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(37, "010_dagger.png");
      this.imageListWeaponElements.Images.SetKeyName(38, "011_claw.png");
      this.imageListWeaponElements.Images.SetKeyName(39, "012_whip.png");
      this.imageListWeaponElements.Images.SetKeyName(40, "013_slicer.png");
      this.imageListWeaponElements.Images.SetKeyName(41, "014_rifle.png");
      this.imageListWeaponElements.Images.SetKeyName(42, "015_shotgun.png");
      this.imageListWeaponElements.Images.SetKeyName(43, "016_longbow.png");
      this.imageListWeaponElements.Images.SetKeyName(44, "017_grenade.png");
      this.imageListWeaponElements.Images.SetKeyName(45, "018_laser.png");
      this.imageListWeaponElements.Images.SetKeyName(46, "019_handguns.png");
      this.imageListWeaponElements.Images.SetKeyName(47, "020_handgun.png");
      this.imageListWeaponElements.Images.SetKeyName(48, "021_crossbow.png");
      this.imageListWeaponElements.Images.SetKeyName(49, "022_cards.png");
      this.imageListWeaponElements.Images.SetKeyName(50, "023_machinegun.png");
      this.imageListWeaponElements.Images.SetKeyName(51, "024_rod.png");
      this.imageListWeaponElements.Images.SetKeyName(52, "025_wand.png");
      this.imageListWeaponElements.Images.SetKeyName(53, "026_tmag.png");
      this.imageListWeaponElements.Images.SetKeyName(54, "027_rmag.png");
      this.imageListWeaponElements.Images.SetKeyName(55, "028_shield.png");
      this.imageListWeaponElements.Images.SetKeyName(56, "01_sword.png");
      this.imageListWeaponElements.Images.SetKeyName(57, "02_knuckles.png");
      this.imageListWeaponElements.Images.SetKeyName(58, "03_spear.png");
      this.imageListWeaponElements.Images.SetKeyName(59, "04_double_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(60, "05_axe.png");
      this.imageListWeaponElements.Images.SetKeyName(61, "06_sabers.png");
      this.imageListWeaponElements.Images.SetKeyName(62, "07_daggers.png");
      this.imageListWeaponElements.Images.SetKeyName(63, "08_claws.png");
      this.imageListWeaponElements.Images.SetKeyName(64, "009_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(65, "010_dagger.png");
      this.imageListWeaponElements.Images.SetKeyName(66, "011_claw.png");
      this.imageListWeaponElements.Images.SetKeyName(67, "012_whip.png");
      this.imageListWeaponElements.Images.SetKeyName(68, "013_slicer.png");
      this.imageListWeaponElements.Images.SetKeyName(69, "014_rifle.png");
      this.imageListWeaponElements.Images.SetKeyName(70, "015_shotgun.png");
      this.imageListWeaponElements.Images.SetKeyName(71, "016_longbow.png");
      this.imageListWeaponElements.Images.SetKeyName(72, "017_grenade.png");
      this.imageListWeaponElements.Images.SetKeyName(73, "018_laser.png");
      this.imageListWeaponElements.Images.SetKeyName(74, "019_handguns.png");
      this.imageListWeaponElements.Images.SetKeyName(75, "020_handgun.png");
      this.imageListWeaponElements.Images.SetKeyName(76, "021_crossbow.png");
      this.imageListWeaponElements.Images.SetKeyName(77, "022_cards.png");
      this.imageListWeaponElements.Images.SetKeyName(78, "023_machinegun.png");
      this.imageListWeaponElements.Images.SetKeyName(79, "024_rod.png");
      this.imageListWeaponElements.Images.SetKeyName(80, "025_wand.png");
      this.imageListWeaponElements.Images.SetKeyName(81, "026_tmag.png");
      this.imageListWeaponElements.Images.SetKeyName(82, "027_rmag.png");
      this.imageListWeaponElements.Images.SetKeyName(83, "028_shield.png");
      this.imageListWeaponElements.Images.SetKeyName(84, "01_sword.png");
      this.imageListWeaponElements.Images.SetKeyName(85, "02_knuckles.png");
      this.imageListWeaponElements.Images.SetKeyName(86, "03_spear.png");
      this.imageListWeaponElements.Images.SetKeyName(87, "04_double_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(88, "05_axe.png");
      this.imageListWeaponElements.Images.SetKeyName(89, "06_sabers.png");
      this.imageListWeaponElements.Images.SetKeyName(90, "07_daggers.png");
      this.imageListWeaponElements.Images.SetKeyName(91, "08_claws.png");
      this.imageListWeaponElements.Images.SetKeyName(92, "009_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(93, "010_dagger.png");
      this.imageListWeaponElements.Images.SetKeyName(94, "011_claw.png");
      this.imageListWeaponElements.Images.SetKeyName(95, "012_whip.png");
      this.imageListWeaponElements.Images.SetKeyName(96, "013_slicer.png");
      this.imageListWeaponElements.Images.SetKeyName(97, "014_rifle.png");
      this.imageListWeaponElements.Images.SetKeyName(98, "015_shotgun.png");
      this.imageListWeaponElements.Images.SetKeyName(99, "016_longbow.png");
      this.imageListWeaponElements.Images.SetKeyName(100, "017_grenade.png");
      this.imageListWeaponElements.Images.SetKeyName(101, "018_laser.png");
      this.imageListWeaponElements.Images.SetKeyName(102, "019_handguns.png");
      this.imageListWeaponElements.Images.SetKeyName(103, "020_handgun.png");
      this.imageListWeaponElements.Images.SetKeyName(104, "021_crossbow.png");
      this.imageListWeaponElements.Images.SetKeyName(105, "022_cards.png");
      this.imageListWeaponElements.Images.SetKeyName(106, "023_machinegun.png");
      this.imageListWeaponElements.Images.SetKeyName(107, "024_rod.png");
      this.imageListWeaponElements.Images.SetKeyName(108, "025_wand.png");
      this.imageListWeaponElements.Images.SetKeyName(109, "026_tmag.png");
      this.imageListWeaponElements.Images.SetKeyName(110, "027_rmag.png");
      this.imageListWeaponElements.Images.SetKeyName(111, "028_shield.png");
      this.imageListWeaponElements.Images.SetKeyName(112, "01_sword.png");
      this.imageListWeaponElements.Images.SetKeyName(113, "02_knuckles.png");
      this.imageListWeaponElements.Images.SetKeyName(114, "03_spear.png");
      this.imageListWeaponElements.Images.SetKeyName(115, "04_double_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(116, "05_axe.png");
      this.imageListWeaponElements.Images.SetKeyName(117, "06_sabers.png");
      this.imageListWeaponElements.Images.SetKeyName(118, "07_daggers.png");
      this.imageListWeaponElements.Images.SetKeyName(119, "08_claws.png");
      this.imageListWeaponElements.Images.SetKeyName(120, "009_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(121, "010_dagger.png");
      this.imageListWeaponElements.Images.SetKeyName(122, "011_claw.png");
      this.imageListWeaponElements.Images.SetKeyName(123, "012_whip.png");
      this.imageListWeaponElements.Images.SetKeyName(124, "013_slicer.png");
      this.imageListWeaponElements.Images.SetKeyName(125, "014_rifle.png");
      this.imageListWeaponElements.Images.SetKeyName(126, "015_shotgun.png");
      this.imageListWeaponElements.Images.SetKeyName((int) sbyte.MaxValue, "016_longbow.png");
      this.imageListWeaponElements.Images.SetKeyName(128, "017_grenade.png");
      this.imageListWeaponElements.Images.SetKeyName(129, "018_laser.png");
      this.imageListWeaponElements.Images.SetKeyName(130, "019_handguns.png");
      this.imageListWeaponElements.Images.SetKeyName(131, "020_handgun.png");
      this.imageListWeaponElements.Images.SetKeyName(132, "021_crossbow.png");
      this.imageListWeaponElements.Images.SetKeyName(133, "022_cards.png");
      this.imageListWeaponElements.Images.SetKeyName(134, "023_machinegun.png");
      this.imageListWeaponElements.Images.SetKeyName(135, "024_rod.png");
      this.imageListWeaponElements.Images.SetKeyName(136, "025_wand.png");
      this.imageListWeaponElements.Images.SetKeyName(137, "026_tmag.png");
      this.imageListWeaponElements.Images.SetKeyName(138, "027_rmag.png");
      this.imageListWeaponElements.Images.SetKeyName(139, "028_shield.png");
      this.imageListWeaponElements.Images.SetKeyName(140, "01_sword.png");
      this.imageListWeaponElements.Images.SetKeyName(141, "02_knuckles.png");
      this.imageListWeaponElements.Images.SetKeyName(142, "03_spear.png");
      this.imageListWeaponElements.Images.SetKeyName(143, "04_double_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(144, "05_axe.png");
      this.imageListWeaponElements.Images.SetKeyName(145, "06_sabers.png");
      this.imageListWeaponElements.Images.SetKeyName(146, "07_daggers.png");
      this.imageListWeaponElements.Images.SetKeyName(147, "08_claws.png");
      this.imageListWeaponElements.Images.SetKeyName(148, "009_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(149, "010_dagger.png");
      this.imageListWeaponElements.Images.SetKeyName(150, "011_claw.png");
      this.imageListWeaponElements.Images.SetKeyName(151, "012_whip.png");
      this.imageListWeaponElements.Images.SetKeyName(152, "013_slicer.png");
      this.imageListWeaponElements.Images.SetKeyName(153, "014_rifle.png");
      this.imageListWeaponElements.Images.SetKeyName(154, "015_shotgun.png");
      this.imageListWeaponElements.Images.SetKeyName(155, "016_longbow.png");
      this.imageListWeaponElements.Images.SetKeyName(156, "017_grenade.png");
      this.imageListWeaponElements.Images.SetKeyName(157, "018_laser.png");
      this.imageListWeaponElements.Images.SetKeyName(158, "019_handguns.png");
      this.imageListWeaponElements.Images.SetKeyName(159, "020_handgun.png");
      this.imageListWeaponElements.Images.SetKeyName(160, "021_crossbow.png");
      this.imageListWeaponElements.Images.SetKeyName(161, "022_cards.png");
      this.imageListWeaponElements.Images.SetKeyName(162, "023_machinegun.png");
      this.imageListWeaponElements.Images.SetKeyName(163, "024_rod.png");
      this.imageListWeaponElements.Images.SetKeyName(164, "025_wand.png");
      this.imageListWeaponElements.Images.SetKeyName(165, "026_tmag.png");
      this.imageListWeaponElements.Images.SetKeyName(166, "027_rmag.png");
      this.imageListWeaponElements.Images.SetKeyName(167, "028_shield.png");
      this.imageListWeaponElements.Images.SetKeyName(168, "01_sword.png");
      this.imageListWeaponElements.Images.SetKeyName(169, "02_knuckles.png");
      this.imageListWeaponElements.Images.SetKeyName(170, "03_spear.png");
      this.imageListWeaponElements.Images.SetKeyName(171, "04_double_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(172, "05_axe.png");
      this.imageListWeaponElements.Images.SetKeyName(173, "06_sabers.png");
      this.imageListWeaponElements.Images.SetKeyName(174, "07_daggers.png");
      this.imageListWeaponElements.Images.SetKeyName(175, "08_claws.png");
      this.imageListWeaponElements.Images.SetKeyName(176, "009_saber.png");
      this.imageListWeaponElements.Images.SetKeyName(177, "010_dagger.png");
      this.imageListWeaponElements.Images.SetKeyName(178, "011_claw.png");
      this.imageListWeaponElements.Images.SetKeyName(179, "012_whip.png");
      this.imageListWeaponElements.Images.SetKeyName(180, "013_slicer.png");
      this.imageListWeaponElements.Images.SetKeyName(181, "014_rifle.png");
      this.imageListWeaponElements.Images.SetKeyName(182, "015_shotgun.png");
      this.imageListWeaponElements.Images.SetKeyName(183, "016_longbow.png");
      this.imageListWeaponElements.Images.SetKeyName(184, "017_grenade.png");
      this.imageListWeaponElements.Images.SetKeyName(185, "018_laser.png");
      this.imageListWeaponElements.Images.SetKeyName(186, "019_handguns.png");
      this.imageListWeaponElements.Images.SetKeyName(187, "020_handgun.png");
      this.imageListWeaponElements.Images.SetKeyName(188, "021_crossbow.png");
      this.imageListWeaponElements.Images.SetKeyName(189, "022_cards.png");
      this.imageListWeaponElements.Images.SetKeyName(190, "023_machinegun.png");
      this.imageListWeaponElements.Images.SetKeyName(191, "024_rod.png");
      this.imageListWeaponElements.Images.SetKeyName(192, "025_wand.png");
      this.imageListWeaponElements.Images.SetKeyName(193, "026_tmag.png");
      this.imageListWeaponElements.Images.SetKeyName(194, "027_rmag.png");
      this.imageListWeaponElements.Images.SetKeyName(195, "028_shield.png");
      this.printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
      this.printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
      this.printPreviewDialog1.ClientSize = new Size(400, 300);
      this.printPreviewDialog1.Enabled = true;
      this.printPreviewDialog1.Icon = (Icon) componentResourceManager.GetObject("printPreviewDialog1.Icon");
      this.printPreviewDialog1.Name = "printPreviewDialog1";
      this.printPreviewDialog1.Visible = false;
      this.imgSave.Image = (Image) Resources.PSP2;
      this.imgSave.InitialImage = (Image) Resources.PSP2;
      this.imgSave.Location = new Point(24, 63);
      this.imgSave.Name = "imgSave";
      this.imgSave.Size = new Size(144, 80);
      this.imgSave.TabIndex = 78;
      this.imgSave.TabStop = false;
      this.imgSave.Visible = false;
      this.imgLogo.BackColor = Color.Transparent;
      this.imgLogo.Image = (Image) Resources.icon_10th;
      this.imgLogo.Location = new Point(3, 547);
      this.imgLogo.Name = "imgLogo";
      this.imgLogo.Size = new Size(63, 50);
      this.imgLogo.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgLogo.TabIndex = 4;
      this.imgLogo.TabStop = false;
      this.pictureBox1.BackColor = Color.Transparent;
      this.pictureBox1.Image = (Image) Resources.NOICON;
      this.pictureBox1.Location = new Point(20, 61);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(160, 90);
      this.pictureBox1.TabIndex = 80;
      this.pictureBox1.TabStop = false;
      this.imgGameLogo.BackColor = Color.Transparent;
      this.imgGameLogo.Image = (Image) Resources.PSP2_logo;
      this.imgGameLogo.InitialImage = (Image) Resources.PSP2_logo;
      this.imgGameLogo.Location = new Point(437, 488);
      this.imgGameLogo.Name = "imgGameLogo";
      this.imgGameLogo.Size = new Size(200, 126);
      this.imgGameLogo.SizeMode = PictureBoxSizeMode.AutoSize;
      this.imgGameLogo.TabIndex = 13;
      this.imgGameLogo.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(650, 643);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.txtFileSize);
      this.Controls.Add((Control) this.btnExportCharacter);
      this.Controls.Add((Control) this.txtSlotnumloaded);
      this.Controls.Add((Control) this.btnImportCharacter);
      this.Controls.Add((Control) this.txtFileLoc);
      this.Controls.Add((Control) this.btnBrowse);
      this.Controls.Add((Control) this.imgSave);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.btnSaveAs);
      this.Controls.Add((Control) this.btnUndoAll);
      this.Controls.Add((Control) this.imgLogo);
      this.Controls.Add((Control) this.tabArea);
      this.Controls.Add((Control) this.menuStrip);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.lstSaveSlotView);
      this.Controls.Add((Control) this.txtFooterText);
      this.Controls.Add((Control) this.grpImageFloater);
      this.Controls.Add((Control) this.imgGameLogo);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip;
      this.MaximizeBox = false;
      this.MaximumSize = new Size(660, 675);
      this.MinimumSize = new Size(660, 675);
      this.Name = nameof (pspo2seForm);
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Text = "PSPo2 Save Editor";
      this.FormClosing += new FormClosingEventHandler(this.pspo2seForm_FormClosing);
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
      this.ResumeLayout(false);
      this.PerformLayout();
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
        int num = (int) MessageBox.Show("[" + debugHelper + "]\r\nhex is " + s + "\r\nint32 is" + (object) int.Parse(s, NumberStyles.HexNumber));
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
        int num = (int) MessageBox.Show("[" + debugHelper + "]\r\nhex is " + s + "\r\nint is" + (object) int.Parse(s, NumberStyles.HexNumber));
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
        inventoryItemClass.ability = (pspo2seForm.abilityType) this.brGetInt(1, pos, br, reload, true);
        string data1 = this.brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
        inventoryItemClass.spcl_effect = this.hexToEffect(data1);
        inventoryItemClass.inf_extended = (pspo2seForm.itemInfExtendType) int.Parse(data1.Substring(1, 1), NumberStyles.HexNumber);
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
      inventoryItemClass.element = (pspo2seForm.elementType) inventoryItemClass.pa_level;
      inventoryItemClass.percent = this.brGetInt(1, pos, br, reload, true);
      inventoryItemClass.style = (pspo2seForm.weaponStyleType) this.brGetInt(1, pos, br, reload, true);
      if (inventoryItemClass.type == pspo2seForm.itemType.Weapon)
        inventoryItemClass.hand = (pspo2seForm.weaponHandType) this.brGetInt(1, pos, br, reload, true);
      else
        inventoryItemClass.clothes_man = (pspo2seForm.clothesManufacturerType) this.brGetInt(1, pos, br, reload, true);
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
          num1 = (int) br.ReadByte();
          if (this.savedata_decimal_array_filled < 301352)
          {
            this.savedata_decimal_array[this.savedata_decimal_array_filled] = num1;
            ++this.savedata_decimal_array_filled;
          }
          else
          {
            int num2 = (int) MessageBox.Show("Buffer is full, trying to load a save file that is not PSPo2?", "Fatal Error!");
          }
        }
        catch (Exception ex)
        {
          int num2 = (int) MessageBox.Show("Failed to read byte, check to see if the end of the file is reached\r\n" + (object) ex, "Fatal Error");
        }
        if (showSaveParseProgress && this.chunkPos >= 1024)
        {
          this.chunkPos = 0;
          this.toolStripStatusLabel.Text = "Parsing Save " + (object) this.run.hexAndMathFunction.getPercentage(this.savedata_decimal_array_filled, this.toolStripProgressBar.Maximum) + "%";
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
          int num2 = (int) MessageBox.Show("trying to read past buffer[" + (object) this.savedata_decimal_array_filled + "] at " + (object) this.savedata_decimal_array_read_pos + " from " + debugHelper);
        }
        if (showSaveParseProgress && this.chunkPos >= 1024)
        {
          this.chunkPos = 0;
          this.toolStripStatusLabel.Text = "Parsing Save " + (object) this.run.hexAndMathFunction.getPercentage(this.savedata_decimal_array_read_pos, this.toolStripProgressBar.Maximum) + "%";
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
        int num1 = (int) MessageBox.Show("trying to overwrite hex " + hex + " over the end of the buffer " + (object) this.savedata_decimal_array_filled);
      }
      string[] strArray = this.run.hexAndMathFunction.addCommasToHex(hex).Split(',');
      int index = pos;
      foreach (string s in strArray)
      {
        if (index > pos + hex.Length)
        {
          int num2 = (int) MessageBox.Show("something went wrong with overwriting hex in the buffer");
          return false;
        }
        this.savedata_decimal_array[index] = (int) byte.Parse(s, NumberStyles.HexNumber);
        ++index;
      }
      return true;
    }

    public void writeToSaveBuffer(int pos, int[] bytearray, int size, int[] bytestoadd)
    {
      if (pos + size > this.savedata_decimal_array_filled)
      {
        int num = (int) MessageBox.Show("Trying to save bytes beyond the loaded buffer", "Fatal Error!");
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
          writer.Write((byte) this.savedata_decimal_array[index]);
      }
      else
      {
        int num = (int) MessageBox.Show("Tried to write a file [" + (object) len + "] larger than the buffer [" + (object) this.savedata_decimal_array_filled + "]", "Fatal Error!");
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
      return saveFileDialog.ShowDialog() == DialogResult.OK ? this.fixFileNameNoExt(saveFileDialog.FileName, ext_options) : (string) null;
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
          using (BinaryWriter writer = new BinaryWriter((Stream) fileStream))
          {
            if (addinteger != 0)
              writer.Write((byte) addinteger);
            this.brWriteFromBuffer(writer, startpos, size);
            writer.Close();
          }
          fileStream.Close();
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
            using (BinaryWriter writer = new BinaryWriter((Stream) fileStream))
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
          int num = (int) MessageBox.Show("The file failed to save. Check it is not read only", "File stream error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                int num1 = (int) MessageBox.Show(fn + " which was downloaded appears to be corrupt, please try again!", "Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              }
              else
              {
                System.IO.File.Copy("data/temp\\" + fn, fn);
                int num2 = (int) MessageBox.Show(fn + " downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                flag1 = false;
                flag2 = true;
              }
            }
            else
            {
              int num3 = (int) MessageBox.Show(fn + " failed to download, please check your internet connection\r\nor the site may be down!", "Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        int num = (int) MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
          using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/temp/" + str1, FileMode.Open, FileAccess.Read))))
          {
            string str2;
            if ((str2 = streamReader.ReadLine()) != null)
              progressTxt = str2;
            streamReader.Close();
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, "checkImagesUpdate failed to parse new info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.toolStripStatusLabel.Text = "Update Failed";
          this.enableMainForm();
          return;
        }
        string str3 = "";
        try
        {
          using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/" + str1, FileMode.Open, FileAccess.Read))))
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
                int num1 = (int) MessageBox.Show("The image pack was updated successfully", "Image Pack Update Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                break;
              case DialogResult.No:
                this.enableMainForm();
                break;
              default:
                int num2 = (int) MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                this.enableMainForm();
                break;
            }
          }
          else
          {
            int num3 = (int) MessageBox.Show("There is a new version of the image pack available.\r\nChoose update from the the images menu to install the latest version", "New Image Pack Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        else
        {
          if (!this.firstboot)
          {
            int num4 = (int) MessageBox.Show("The latest version of the image pack is already installed.", "Image pack is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          this.enableMainForm();
        }
      }
      else
      {
        int num5 = (int) MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Image Pack Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
          using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/temp/" + str1, FileMode.Open, FileAccess.Read))))
          {
            string str2;
            if ((str2 = streamReader.ReadLine()) != null)
              newVersion = str2;
            streamReader.Close();
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, "checkAppUpdate failed to parse new info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.toolStripStatusLabel.Text = "Update Failed";
          this.enableMainForm();
          return;
        }
        if ("3.0 build 1008" != newVersion)
        {
          if (download)
          {
            this.updateViewer.formSetup(newVersion);
            switch (this.updateViewer.ShowDialog((IWin32Window) this))
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
                int num = (int) MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                this.enableMainForm();
                break;
            }
          }
          else
          {
            int num1 = (int) MessageBox.Show("There is a new version of the application available.\r\nChoose update from the the file menu to install v" + newVersion, "New version available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        else
        {
          if (!this.firstboot)
          {
            int num2 = (int) MessageBox.Show("The latest version (" + newVersion + ") is already installed.", "Application is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          this.enableMainForm();
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
        using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
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
        int num = (int) MessageBox.Show("checkVersionTxt failed to load new info:\r\n " + ex.Message);
        this.toolStripStatusLabel.Text = "Update Failed";
        return false;
      }
      Application.DoEvents();
      pspo2seForm.updateCSVInfo[] updateCsvInfoArray2 = new pspo2seForm.updateCSVInfo[20];
      try
      {
        string encryptionKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
        FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
        using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
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
          int num = (int) MessageBox.Show("checkVersionTxt failed to load cur info [" + (object) index2 + "/" + (object) 20 + "]:\r\n " + ex.Message);
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
        int num = (int) MessageBox.Show("The application seems to be out of date.\r\nThe latest database files are incompatible with this version\r\n\r\nPlease update the application first");
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
                  int num1 = (int) MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                  return false;
              }
            }
            else
            {
              int num2 = (int) MessageBox.Show("There are new database updates available.\r\nChoose update from the database menu to install them", "Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      int num3 = (int) MessageBox.Show(text, "Database Update Results", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      return true;
    }

    public bool downloadFile(string url, string dirdest, string progressTxt, string saveas = "")
    {
      if (!this.allowDownload)
      {
        int num = (int) MessageBox.Show("Please wait for the current download to finish", "Download already in progress", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      this.allowDownload = false;
      this.downloadedData = new byte[512000];
      this.downloadedDataName = "";
      try
      {
        WebResponse response = WebRequest.Create(url).GetResponse();
        Stream responseStream = response.GetResponseStream();
        int contentLength = (int) response.ContentLength;
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
              this.toolStripStatusLabel.Text = "Completed: " + progressTxt + " " + (object) this.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, contentLength) + "%";
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
          this.toolStripStatusLabel.Text = "Downloading: " + progressTxt + " " + (object) this.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, contentLength) + "%";
          Application.DoEvents();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
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
              int num1 = (int) MessageBox.Show("Heal type item type not recognised for image: " + hex_reversed.Substring(3, 1));
              return pspo2seForm.greenItemType.none;
          }
        case "3":
          return pspo2seForm.greenItemType.calorie;
        case "4":
          return pspo2seForm.greenItemType.item;
        default:
          int num2 = (int) MessageBox.Show("Green item type not recognised for image: " + hex_reversed.Substring(5, 1));
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
      string name = this.enumToName(string.Concat((object) type));
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
        int num = (int) MessageBox.Show("row 7 [" + (object) this.item_db_filled + "] incorrect format " + strArray[7]);
      }
      try
      {
        this.item_db.item[this.item_db_filled].acc = int.Parse(strArray[8]);
      }
      catch
      {
        this.databasesOk = false;
        int num = (int) MessageBox.Show("row 8 [" + (object) this.item_db_filled + "] incorrect format " + strArray[8]);
      }
      this.item_db.item[this.item_db_filled].level = strArray[9];
      try
      {
        this.item_db.item[this.item_db_filled].ext_power = int.Parse(strArray[10]);
      }
      catch
      {
        this.databasesOk = false;
        int num = (int) MessageBox.Show("row 10 [" + (object) this.item_db_filled + "] incorrect format " + strArray[10]);
      }
      try
      {
        this.item_db.item[this.item_db_filled].ext_acc = int.Parse(strArray[11]);
      }
      catch
      {
        this.databasesOk = false;
        int num = (int) MessageBox.Show("row 11 [" + (object) this.item_db_filled + "] incorrect format " + strArray[11]);
      }
      this.item_db.item[this.item_db_filled].ext_level = strArray[12];
      try
      {
        this.item_db.item[this.item_db_filled].inf_ext_power = int.Parse(strArray[13]);
      }
      catch
      {
        this.databasesOk = false;
        int num = (int) MessageBox.Show("row 13 [" + (object) this.item_db_filled + "] incorrect format " + strArray[13]);
      }
      try
      {
        this.item_db.item[this.item_db_filled].inf_ext_acc = int.Parse(strArray[14]);
      }
      catch
      {
        this.databasesOk = false;
        int num = (int) MessageBox.Show("row 14 [" + (object) this.item_db_filled + "] incorrect format " + strArray[14]);
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
        int num = (int) MessageBox.Show("row 19 [" + (object) this.item_db_filled + "] incorrect format " + strArray[19]);
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
        using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
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
        int num = (int) MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Item Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    public pspo2seForm.itemType getItemTypeFromHex(string hex)
    {
      hex = hex.Substring(0, 2);
      return (pspo2seForm.itemType) int.Parse(hex, NumberStyles.HexNumber);
    }

    public pspo2seForm.weaponType getWeaponTypeFromHex(string hex)
    {
      hex = hex.Substring(4, 2);
      return (pspo2seForm.weaponType) int.Parse(hex, NumberStyles.HexNumber);
    }

    private pspo2seForm.slotType getSlotTypeFromHex(string hex)
    {
      hex = hex.Substring(2, 4);
      hex = this.run.hexAndMathFunction.reversehex(hex, 4);
      int num1 = int.Parse(hex, NumberStyles.HexNumber);
      if (num1 < 256 || num1 > 1138)
      {
        int num2 = (int) MessageBox.Show("Error, slot type integer not supported [" + hex + ":" + (object) num1 + "]");
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
      return (pspo2seForm.weaponManufacturerType) int.Parse(hex, NumberStyles.HexNumber);
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
          return (Image) Resources.manlogo_GRM;
        case pspo2seForm.weaponManufacturerType.Yohmei:
          return (Image) Resources.manlogo_Yohmei;
        case pspo2seForm.weaponManufacturerType.Tenora_Works:
          return (Image) Resources.manlogo_Tenora;
        case pspo2seForm.weaponManufacturerType.Kubara:
          return (Image) Resources.manlogo_Kubara;
        default:
          int num = (int) MessageBox.Show("weapon manufacturer not supported: " + (object) manufacturer);
          return (Image) null;
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
          fields.img_manufaturer.Image = (Image) Resources.manlogo_Kubara;
          break;
        case pspo2seForm.clothesManufacturerType.Roar:
          fields.img_manufaturer.Image = (Image) Resources.manlogo_Roar;
          break;
        case pspo2seForm.clothesManufacturerType.Cubic:
          fields.img_manufaturer.Image = (Image) Resources.manlogo_Cubic;
          break;
        case pspo2seForm.clothesManufacturerType.Miyab:
          fields.img_manufaturer.Image = (Image) Resources.manlogo_Miyab;
          break;
        default:
          int num = (int) MessageBox.Show("clothes manufacturer not supported: " + (object) manufacturer);
          fields.img_manufaturer.Visible = false;
          break;
      }
    }

    public Image getWeaponImageFromType(pspo2seForm.weaponType weapon)
    {
      switch (weapon)
      {
        case pspo2seForm.weaponType.nothing:
          return (Image) null;
        case pspo2seForm.weaponType.sword:
          return (Image) Resources.weapon_sword;
        case pspo2seForm.weaponType.knuckle:
          return (Image) Resources.weapon_knuckles;
        case pspo2seForm.weaponType.spear:
          return (Image) Resources.weapon_spear;
        case pspo2seForm.weaponType.double_saber:
          return (Image) Resources.weapon_double_saber;
        case pspo2seForm.weaponType.axe:
          return (Image) Resources.weapon_axe;
        case pspo2seForm.weaponType.sabers:
          return (Image) Resources.weapon_sabers;
        case pspo2seForm.weaponType.daggers:
          return (Image) Resources.weapon_daggers;
        case pspo2seForm.weaponType.claws:
          return (Image) Resources.weapon_claws;
        case pspo2seForm.weaponType.saber:
          return (Image) Resources.weapon_saber;
        case pspo2seForm.weaponType.dagger:
          return (Image) Resources.weapon_dagger;
        case pspo2seForm.weaponType.claw:
          return (Image) Resources.weapon_claw;
        case pspo2seForm.weaponType.whip:
          return (Image) Resources.weapon_whip;
        case pspo2seForm.weaponType.slicer:
          return (Image) Resources.weapon_slicer;
        case pspo2seForm.weaponType.rifle:
          return (Image) Resources.weapon_rifle;
        case pspo2seForm.weaponType.shotgun:
          return (Image) Resources.weapon_shotgun;
        case pspo2seForm.weaponType.longbow:
          return (Image) Resources.weapon_longbow;
        case pspo2seForm.weaponType.grenade:
          return (Image) Resources.weapon_grenade;
        case pspo2seForm.weaponType.laser:
          return (Image) Resources.weapon_laser;
        case pspo2seForm.weaponType.handguns:
          return (Image) Resources.weapon_handguns;
        case pspo2seForm.weaponType.handgun:
          return (Image) Resources.weapon_handgun;
        case pspo2seForm.weaponType.crossbow:
          return (Image) Resources.weapon_crossbow;
        case pspo2seForm.weaponType.card:
          return (Image) Resources.weapon_card;
        case pspo2seForm.weaponType.machinegun:
          return (Image) Resources.weapon_machinegun;
        case pspo2seForm.weaponType.rod:
          return (Image) Resources.weapon_rod;
        case pspo2seForm.weaponType.wand:
          return (Image) Resources.weapon_wand;
        case pspo2seForm.weaponType.tmag:
          return (Image) Resources.weapon_tmag;
        case pspo2seForm.weaponType.rmag:
          return (Image) Resources.weapon_rmag;
        case pspo2seForm.weaponType.shield:
          return (Image) Resources.weapon_shield;
        case pspo2seForm.weaponType.armor:
          return (Image) Resources.armor_icon;
        default:
          return (Image) null;
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
          pspo2seForm.clothesTypes clothesTypes = (pspo2seForm.clothesTypes) clothes_type;
          switch (clothesTypes)
          {
            case pspo2seForm.clothesTypes.top:
              fields.img_item.Image = (Image) Resources.clothes_top;
              return;
            case pspo2seForm.clothesTypes.bottom:
              fields.img_item.Image = (Image) Resources.clothes_bottom;
              return;
            case pspo2seForm.clothesTypes.shoes:
              fields.img_item.Image = (Image) Resources.clothes_shoes;
              return;
            case pspo2seForm.clothesTypes.top_set:
              fields.img_item.Image = (Image) Resources.clothes_bottom_set;
              return;
            case pspo2seForm.clothesTypes.bottom_set:
              fields.img_item.Image = (Image) Resources.clothes_top_set;
              return;
            case pspo2seForm.clothesTypes.set:
              fields.img_item.Image = (Image) Resources.clothes_set;
              return;
            default:
              int num1 = (int) MessageBox.Show("Unsupported " + (object) item_type + " type: " + (object) clothesTypes);
              fields.img_item.Visible = false;
              return;
          }
        case pspo2seForm.itemType.Clothes_android:
          pspo2seForm.partsTypes partsTypes = (pspo2seForm.partsTypes) clothes_type;
          switch (partsTypes)
          {
            case pspo2seForm.partsTypes.torso:
              fields.img_item.Image = (Image) Resources.parts_torso;
              return;
            case pspo2seForm.partsTypes.legs:
              fields.img_item.Image = (Image) Resources.parts_legs;
              return;
            case pspo2seForm.partsTypes.arms:
              fields.img_item.Image = (Image) Resources.parts_arms;
              return;
            case pspo2seForm.partsTypes.set:
              fields.img_item.Image = (Image) Resources.parts_set;
              return;
            default:
              int num2 = (int) MessageBox.Show("Unsupported " + (object) item_type + " type: " + (object) partsTypes);
              fields.img_item.Visible = false;
              return;
          }
        default:
          int num3 = (int) MessageBox.Show("Tried to get clothes type from a non-clothing item: " + (object) clothes_type);
          break;
      }
    }

    private void displaySlotUnitImage(pspo2seForm.pageFields fields, pspo2seForm.slotType slot)
    {
      fields.img_item.Visible = true;
      switch (slot)
      {
        case pspo2seForm.slotType.unit:
          fields.img_item.Image = (Image) Resources.slot_unit;
          break;
        case pspo2seForm.slotType.mirage:
          fields.img_item.Image = (Image) Resources.slot_mirage;
          break;
        case pspo2seForm.slotType.suv:
          fields.img_item.Image = (Image) Resources.slot_suv;
          break;
        case pspo2seForm.slotType.visual:
          fields.img_item.Image = (Image) Resources.slot_visual;
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
              fields.img_item.Image = (Image) Resources.item_mate;
              return;
            case pspo2seForm.greenItemType.dimate:
              fields.img_item.Image = (Image) Resources.item_mate;
              return;
            case pspo2seForm.greenItemType.trimate:
              fields.img_item.Image = (Image) Resources.item_mate;
              return;
            case pspo2seForm.greenItemType.star_atom:
              fields.img_item.Image = (Image) Resources.item_mate;
              return;
            case pspo2seForm.greenItemType.sol_atom:
              fields.img_item.Image = (Image) Resources.item_sol;
              return;
            case pspo2seForm.greenItemType.moon_atom:
              fields.img_item.Image = (Image) Resources.item_doll;
              return;
            case pspo2seForm.greenItemType.doll:
              fields.img_item.Image = (Image) Resources.item_doll;
              return;
            case pspo2seForm.greenItemType.shiftaride:
              fields.img_item.Image = (Image) Resources.item_buff;
              return;
            case pspo2seForm.greenItemType.debanride:
              fields.img_item.Image = (Image) Resources.item_buff;
              return;
            case pspo2seForm.greenItemType.calorie:
              fields.img_item.Image = (Image) Resources.item_calorie;
              return;
            case pspo2seForm.greenItemType.item:
              fields.img_item.Image = (Image) Resources.item;
              return;
            default:
              int num1 = (int) MessageBox.Show("Green item type not recognised for image: " + (object) this.getGreenItemTypeFromHex(item.hex_reversed));
              return;
          }
        case pspo2seForm.itemType.PA_Disk_Melee:
          fields.img_item.Image = (Image) Resources.item_pa_disk;
          break;
        case pspo2seForm.itemType.PA_Disk_Ranged:
          fields.img_item.Image = (Image) Resources.item_pa_disk;
          break;
        case pspo2seForm.itemType.PA_Disk_Technique:
          fields.img_item.Image = (Image) Resources.item_pa_disk;
          break;
        case pspo2seForm.itemType.Infinity_Code:
          fields.img_item.Image = (Image) Resources.item;
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
          fields.img_item.Image = (Image) Resources.item_decoration;
          break;
        case pspo2seForm.itemType.Trap:
          switch (item.hex_reversed.Substring(5, 1))
          {
            case "1":
              fields.img_item.Image = (Image) Resources.trap;
              return;
            case "2":
              fields.img_item.Image = (Image) Resources.trap_ex;
              return;
            default:
              int num2 = (int) MessageBox.Show("Trap type is wrong for image, is this even a trap?");
              return;
          }
        case pspo2seForm.itemType.My_Synth_Device:
          fields.img_item.Image = (Image) Resources.item_pm;
          break;
        case pspo2seForm.itemType.Extend_Code:
          fields.img_item.Image = (Image) Resources.item_extend;
          break;
        case pspo2seForm.itemType.free_slot:
          break;
        default:
          int num3 = (int) MessageBox.Show("item type not recognised for image: " + (object) item.type);
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
      fields.img_rank.Image = (Image) Resources.rank_Unknown;
      if (rarity >= 0)
      {
        fields.img_star_0.Visible = true;
        fields.img_rank.Image = (Image) Resources.rank_C;
      }
      if (rarity > 0)
        fields.img_star_1.Visible = true;
      if (rarity >= 2)
        fields.img_star_2.Visible = true;
      if (rarity >= 3)
      {
        fields.img_star_3.Visible = true;
        fields.img_rank.Image = (Image) Resources.rank_B;
      }
      if (rarity >= 4)
        fields.img_star_4.Visible = true;
      if (rarity >= 5)
        fields.img_star_5.Visible = true;
      if (rarity >= 6)
      {
        fields.img_star_6.Visible = true;
        fields.img_rank.Image = (Image) Resources.rank_A;
      }
      if (rarity >= 7)
        fields.img_star_7.Visible = true;
      if (rarity >= 8)
        fields.img_star_8.Visible = true;
      if (rarity >= 9)
      {
        fields.img_star_9.Visible = true;
        fields.img_rank.Image = (Image) Resources.rank_S;
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
            int num1 = (int) MessageBox.Show("Extend integer " + (object) extend_integer + " is not recognised for psp2i extend type");
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
            int num2 = (int) MessageBox.Show("Extend integer " + (object) extend_integer + " is not recognised for psp2 extend type");
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
        return (pspo2seForm.abilityType) System.Enum.Parse(typeof (pspo2seForm.abilityType), str, true);
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
          return "unk_" + (object) ability;
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
        int num1 = (int) MessageBox.Show("Unknown infinity extend type: " + (object) item.inf_extended);
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
          fields.txt_grinds.Text = item.style.ToString() + " " + (object) item.extended + " " + fields.txt_grinds.Text;
          break;
        default:
          int num2 = (int) MessageBox.Show("Unhandled extend type: " + (object) item.extended);
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
            fields.txt_atk.Text = "TEC  " + (object) (int) ((Decimal) (item.power + item.ext_power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
            if (weaponTypeFromHex == pspo2seForm.weaponType.longbow)
              fields.txt_acc.Text = "ACC  " + (object) (int) ((Decimal) (item.acc + item.ext_acc) * num3);
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
          fields.txt_atk.Text = "ATK  " + (object) (int) ((Decimal) (item.power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity) + item.ext_power) * num3);
          fields.txt_acc.Text = "ACC  " + (object) (int) ((Decimal) (item.acc + item.ext_acc) * num3);
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
            fields.txt_atk.Text = "TEC  " + (object) (int) ((Decimal) (item.power + item.ext_power + item.inf_ext_power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
            if (weaponTypeFromHex == pspo2seForm.weaponType.longbow)
              fields.txt_acc.Text = "ACC  " + (object) (int) ((Decimal) (item.acc + item.ext_acc + item.inf_ext_acc) * num3);
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
          fields.txt_atk.Text = "ATK  " + (object) (int) ((Decimal) (item.power + item.ext_power + item.inf_ext_power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
          fields.txt_acc.Text = "ACC  " + (object) (int) ((Decimal) (item.acc + item.ext_acc + item.inf_ext_acc) * num3);
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
            fields.txt_atk.Text = "TEC  " + (object) (int) ((Decimal) (item.power + this.grindsToPowIncrease(weaponTypeFromHex, item.grinds, item.rarity)) * num3);
            if (weaponTypeFromHex == pspo2seForm.weaponType.longbow)
              fields.txt_acc.Text = "ACC  " + (object) (int) ((Decimal) item.acc * num3);
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
          fields.txt_atk.Text = "ATK  " + (object) (int) ((Decimal) (item.power + this.grindsToPowIncrease(this.getWeaponTypeFromHex(item.hex_reversed), item.grinds, item.rarity)) * num3);
          fields.txt_acc.Text = "ACC  " + (object) (int) ((Decimal) item.acc * num3);
        }
        fields.txt_level.Text = item.level;
      }
      if (item.power_add > 0 && item.power_add <= 9999 && fields.txt_atk.Text.Replace("DB_Error", "") == fields.txt_atk.Text)
      {
        int num4 = int.Parse(fields.txt_atk.Text.Replace("ATK  ", "").Replace("TEC  ", "")) + item.power_add;
        if (num4 > 9999)
          num4 = 9999;
        if (item.style == pspo2seForm.weaponStyleType.Tech || weaponTypeFromHex == pspo2seForm.weaponType.longbow)
          fields.txt_atk.Text = "TEC  " + (object) num4 + " [+" + (object) item.power_add + "]";
        else
          fields.txt_atk.Text = "ATK  " + (object) num4 + " [+" + (object) item.power_add + "]";
      }
      else if (item.power_add > 9999 && fields.txt_atk.Text.Replace("DB_Error", "") == fields.txt_atk.Text)
      {
        if (item.style == pspo2seForm.weaponStyleType.Tech || weaponTypeFromHex == pspo2seForm.weaponType.longbow)
          fields.txt_atk.Text = "TEC  " + (object) (int) ((Decimal) item.power * num3);
        else
          fields.txt_atk.Text = "ATK  " + (object) (int) ((Decimal) item.power * num3);
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
      string[] infinityEnemy = this.intToInfinityEnemy((int) element);
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
          strArray[0] = "unk_" + (object) i;
          strArray[1] = "unk_" + (object) i;
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
          strArray[0] = "unk_" + (object) i;
          strArray[1] = "unk_" + (object) i;
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
          strArray[0] = "unk_" + (object) i;
          strArray[1] = "unk_" + (object) i;
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
          fields.txt_grinds.Text = "(" + (object) item.grinds + ")";
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
                fields.txt_effect.Text = "Effect  " + item.spcl_effect + " (Kills  " + (object) num + ")";
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
          fields.txt_special.Text = "DEF  " + (object) item.power;
          fields.txt_effect.Text = "EVA  " + (object) item.acc;
          fields.txt_atk.Text = "MND  " + (object) item.ext_power;
          fields.txt_acc.Text = "STA  " + (object) item.ext_acc;
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
          fields.txt_qty.Text = item.qty.ToString() + "/" + (object) item.qty_max;
          fields.txt_grinds.Text = "(" + (object) item.grinds + ")";
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
          fields.txt_grinds.Text = "(+" + (object) item.percent + ")";
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
          fields.txt_qty.Text = item.qty.ToString() + "/" + (object) item.qty_max;
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
          fields.txt_qty.Text = item.qty.ToString() + "/" + (object) item.qty_max;
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
          fields.img_rank.Image = (Image) Resources.free_slot;
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
            fields.txt_qty.Text = "LV" + (object) (item.pa_level + 1) + " (" + this.getSlotPALearntLevel(this.lstSaveSlotView.SelectedItems[0].Index, item.hex) + ")";
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
          int num1 = (int) MessageBox.Show("Type not dealt with in displayItemInfo() " + this.txtInventoryHex.Text);
          fields.txt_qty.Text = item.qty.ToString() + "/" + (object) item.qty_max;
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
          fields.img_element.Image = (Image) Resources.element_neutral;
          break;
        case pspo2seForm.elementType.Fire:
          fields.img_element.Image = (Image) Resources.element_fire;
          break;
        case pspo2seForm.elementType.Ice:
          fields.img_element.Image = (Image) Resources.element_ice;
          break;
        case pspo2seForm.elementType.Thunder:
          fields.img_element.Image = (Image) Resources.element_thunder;
          break;
        case pspo2seForm.elementType.Earth:
          fields.img_element.Image = (Image) Resources.element_earth;
          break;
        case pspo2seForm.elementType.Light:
          fields.img_element.Image = (Image) Resources.element_light;
          break;
        case pspo2seForm.elementType.Dark:
          fields.img_element.Image = (Image) Resources.element_dark;
          break;
        default:
          fields.img_element.Visible = false;
          break;
      }
    }

    private void sortInventory(int slotnum)
    {
      ArrayList arrayList = ArrayList.Adapter((IList) this.saveData.slot[slotnum].inventory.item);
      arrayList.Sort();
      this.saveData.slot[slotnum].inventory.item = (pspo2seForm.inventoryItemClass[]) arrayList.ToArray(typeof (pspo2seForm.inventoryItemClass));
    }

    private void sortStorage()
    {
      ArrayList arrayList = ArrayList.Adapter((IList) this.saveData.sharedInventory.item);
      arrayList.Sort();
      this.saveData.sharedInventory.item = (pspo2seForm.inventoryItemClass[]) arrayList.ToArray(typeof (pspo2seForm.inventoryItemClass));
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
          int num = (int) MessageBox.Show("page: " + (object) page + "not handled in allowShowItem()");
          break;
      }
      return false;
    }

    private void displayInventory(int slotnum, int page)
    {
      this.inventoryView.SelectedItems.Clear();
      this.inventoryView.Items.Clear();
      this.sortInventory(slotnum);
      this.picWeaponSlot01.Image = (Image) null;
      this.picWeaponSlot02.Image = (Image) null;
      this.picWeaponSlot03.Image = (Image) null;
      this.picWeaponSlot04.Image = (Image) null;
      this.picWeaponSlot05.Image = (Image) null;
      this.picWeaponSlot06.Image = (Image) null;
      int index1 = -1;
      for (int index2 = 0; index2 < 60; ++index2)
      {
        pspo2seForm.inventoryItemClass inventoryItemClass1 = new pspo2seForm.inventoryItemClass();
        pspo2seForm.inventoryItemClass inventoryItemClass2 = this.saveData.slot[slotnum].inventory.item[index2];
        if (inventoryItemClass2.type == pspo2seForm.itemType.Weapon && inventoryItemClass2.equipped_slot > 0)
        {
          int index3 = (int) (this.getWeaponTypeFromHex(inventoryItemClass2.hex_reversed) - 1 + (int) inventoryItemClass2.element * 28);
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
      this.tabPageInventory.Text = "Inventory (" + (object) this.saveData.slot[slotnum].inventory.itemsUsed + "/60)";
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
      this.txtStorageMeseta.Text = string.Concat((object) this.saveData.sharedMeseta);
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
              int num2 = (int) MessageBox.Show("unknown extend " + text + " " + inventoryItemClass.hex_reversed);
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
      this.tabPageStorage.Text = "Shared (" + (object) this.saveData.sharedInventory.itemsUsed + "/" + (object) this.mainSettings.saveStructureIndex.shared_inventory_slots + ")";
    }

    private int getImageListNumber(pspo2seForm.inventoryItemClass item)
    {
      int num1 = 1000;
      switch (item.type)
      {
        case pspo2seForm.itemType.Weapon:
          num1 = (int) (this.getWeaponTypeFromHex(item.hex_reversed) - 1 + 28 * (int) this.getItemRankFromRarity(item.rarity));
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
          num1 = (int) this.getItemRankFromRarity(item.rarity);
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
              int num2 = (int) MessageBox.Show("Green item type not recognised for image: " + (object) this.getGreenItemTypeFromHex(item.hex_reversed));
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
          num1 = (int) (this.getSlotTypeFromHex(item.hex_reversed) + 15 + (int) this.getItemRankFromRarity(item.rarity) * 4);
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
          return "hexToEffect invalid save type " + (object) this.saveData.type;
      }
    }

    public FileStream openFileRead(string fileLoc)
    {
      FileStream fileStream = (FileStream) null;
      if (fileLoc.Length <= 0)
        throw new ArgumentException();
      try
      {
        fileStream = new FileStream(fileLoc, FileMode.Open, FileAccess.Read);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Fatal Error!");
      }
      return fileStream;
    }

    private string getGameIdFromSfo(string gameSave)
    {
      FileStream fileStream = this.openFileRead(Path.Combine(Path.GetDirectoryName(gameSave), "PARAM.SFO"));
      BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
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
        int num = (int) MessageBox.Show("SED.exe is missing");
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
            using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream))
            {
              for (int index = 0; index < 16; ++index)
                binaryWriter.Write((byte) (128 + index));
              binaryWriter.Close();
            }
            fileStream.Close();
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Failed to generate the key.\n\nError: " + ex.Message);
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
        int num = (int) MessageBox.Show("SED.exe is missing");
        return false;
      }
      string path = Path.Combine(Path.GetDirectoryName(dest), "PARAM.SFO");
      if (!System.IO.File.Exists(path))
      {
        int num = (int) MessageBox.Show("PARAM.SFO does not exist in that location.\n\nPlease choose the original location of your save file");
        return false;
      }
      string gameIdFromSfo = this.getGameIdFromSfo(dest);
      if (!System.IO.File.Exists("data\\keys\\" + gameIdFromSfo + ".bin"))
      {
        int num = (int) MessageBox.Show("You must place the '" + gameIdFromSfo + ".bin' key file in the data\\keys directory.\n\nSearch for SGKeyDumper to obtain the key for your game.");
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
      if (filelength == (long) this.mainSettings.saveStructureIndex.total_size || filelength == (long) this.mainSettings.saveStructureIndex.total_size_enc)
      {
        this.saveData.set_type(pspo2seForm.SaveType.PSP2);
        if (filelength == (long) this.mainSettings.saveStructureIndex.total_size_enc)
          this.mainSettings.saveStructureIndex.encrypted = true;
        this.txtFileSize.Text = Convert.ToString(this.mainSettings.saveStructureIndex.total_size) + " bytes";
        return true;
      }
      this.mainSettings.saveStructureIndex.changeSaveSettingsType(pspo2seForm.SaveType.PSP2I);
      if (filelength == (long) this.mainSettings.saveStructureIndex.total_size || filelength == (long) this.mainSettings.saveStructureIndex.total_size_enc)
      {
        this.saveData.set_type(pspo2seForm.SaveType.PSP2I);
        if (filelength == (long) this.mainSettings.saveStructureIndex.total_size_enc)
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
        this.savedata_decimal_array[index1] = (int) br.ReadByte();
        ++index1;
      }
      if (type == pspo2seForm.partFileType.inventory)
      {
        for (int index2 = 0; index2 < 8; ++index2)
        {
          int num = (int) br.ReadByte();
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
        int num = (int) MessageBox.Show("nothing to load into");
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
        int num = (int) MessageBox.Show("You do not have enough slots to import the selected items.", "Not Enough Slots", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return -1;
      }
      if (allowMultiSelect && type == pspo2seForm.partFileType.infinity_mission && stringList.Count > 100 - this.saveData.infinityMissions.itemsUsed)
      {
        int num = (int) MessageBox.Show("You do not have enough slots to import the selected items.", "Not Enough Slots", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return -1;
      }
      foreach (string fileLoc in stringList)
      {
        FileStream fileStream = this.openFileRead(fileLoc);
        if (fileStream == null)
          return -1;
        BinaryReader br = new BinaryReader((Stream) fileStream);
        int length = (int) br.BaseStream.Length;
        switch (type)
        {
          case pspo2seForm.partFileType.character:
            if (!this.validate_character_file_length(length))
            {
              int num = (int) MessageBox.Show("File does not appear to be a valid character file");
              fileStream.Close();
              return -1;
            }
            break;
          case pspo2seForm.partFileType.inventory:
            if (length != 2161)
            {
              int num = (int) MessageBox.Show("File does not appear to be a valid inventory file");
              fileStream.Close();
              return -1;
            }
            this.savedata_decimal_array[this.mainSettings.saveStructureIndex.inventory_slots_used_pos + this.mainSettings.saveStructureIndex.slot_size * this.lstSaveSlotView.SelectedItems[0].Index] = (int) br.ReadByte();
            for (int index1 = 0; index1 < 60; ++index1)
            {
              int index2 = startpos + index1 * 36;
              for (int index3 = 0; index3 < 8; ++index3)
              {
                int num = (int) br.ReadByte();
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
              int num = (int) MessageBox.Show("File does not appear to be a valid storage file");
              fileStream.Close();
              return -1;
            }
            break;
          case pspo2seForm.partFileType.item:
            if (length != 20)
            {
              int num = (int) MessageBox.Show("File does not appear to be a valid item file");
              fileStream.Close();
              return -1;
            }
            if (allowMultiSelect)
            {
              startpos = this.getFreeInventoryItemId(this.lstSaveSlotView.SelectedItems[0].Index);
              if (startpos < 0)
              {
                int num = (int) MessageBox.Show("Error: Trying to load an item but there are no available slots");
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
              int num = (int) MessageBox.Show("File does not appear to be a valid infinity mission file");
              fileStream.Close();
              return -1;
            }
            break;
          case pspo2seForm.partFileType.infinity_mission_pack:
            if (length != 10401)
            {
              int num = (int) MessageBox.Show("File does not appear to be a valid infinity mission pack file");
              fileStream.Close();
              return -1;
            }
            break;
          default:
            int num1 = (int) MessageBox.Show("file " + (object) type + " is not supported");
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
        int num2 = (int) MessageBox.Show("Requested position " + (object) pos + " is greater than the predicted item pos" + (object) item_position);
        return 0;
      }
      while (num1 < item_position)
        this.brSkipBytes(1, &num1, br, reload, showSaveParseProgress);
      return num1;
    }

    private unsafe bool parseSaveFile(string fileLoc, bool reload)
    {
      this.chunkPos = 0;
      FileStream fileStream = (FileStream) null;
      BinaryReader br = (BinaryReader) null;
      if (!reload)
      {
        this.initSaveBuffer();
        this.initSlotVars();
        fileStream = this.openFileRead(fileLoc);
        if (fileStream == null)
          return false;
        br = new BinaryReader((Stream) fileStream, Encoding.BigEndianUnicode);
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
            int num = (int) MessageBox.Show("There was an error decrypting the save file.");
            return false;
          }
          fileStream = this.openFileRead("data\\temp\\denc.bin");
          br = new BinaryReader((Stream) fileStream, Encoding.BigEndianUnicode);
        }
        this.saveData.size = (int) br.BaseStream.Length;
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
        int num = (int) MessageBox.Show("Already scanned past the header", "scan error");
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
      this.saveData.slot[slot].pa.items[*filled].level = "LV" + (object) (int.Parse(s, NumberStyles.HexNumber) + 1);
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
      *pos = this.adjustPosition(*pos, br, item_position, reload, "Save Slot " + (object) slot, true);
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
          int num = (int) MessageBox.Show("could not find exp for level " + (object) this.saveData.slot[slot].level);
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
        listViewItem = new ListViewItem(this.saveData.slot[slot].name, (int) this.saveData.slot[slot].sex);
        listViewItem.SubItems.Add("LV" + (object) this.saveData.slot[slot].level);
        listViewItem.SubItems.Add(string.Concat((object) this.saveData.slot[slot].race));
        listViewItem.SubItems.Add(string.Concat((object) this.saveData.slot[slot].cur_type));
        listViewItem.SubItems.Add(this.storyCompleteToText(this.saveData.slot[slot].story_ep_1_complete, this.saveData.slot[slot].story_ep_2_complete) ?? "");
      }
      this.lstSaveSlotView.Items.Add(listViewItem);
      return true;
    }

    private unsafe bool parseCharacterInfo(int slot, BinaryReader br, int* pos, bool reload)
    {
      this.saveData.slot[slot].rebirth = new pspo2seForm.rebirthType();
      int item_position = this.mainSettings.saveStructureIndex.slots_position + this.mainSettings.saveStructureIndex.slot_size * slot;
      *pos = this.adjustPosition(*pos, br, item_position, reload, "Character info " + (object) slot, true);
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
      this.saveData.slot[slot].race = (pspo2seForm.raceTypes) this.brGetInt(1, pos, br, reload, true);
      this.saveData.slot[slot].sex = (pspo2seForm.sexType) this.brGetInt(1, pos, br, reload, true);
      this.saveData.slot[slot].cur_type = (pspo2seForm.jobType) this.brGetInt(1, pos, br, reload, true);
      this.brSkipBytes(101, pos, br, reload, true);
      this.saveData.slot[slot].level = this.brGetInt(2, pos, br, reload, true);
      this.brSkipBytes(6, pos, br, reload, true);
      this.saveData.slot[slot].exp = this.brGetInt32(pos, br, reload, true);
      this.saveData.slot[slot].meseta = (long) this.brGetInt32(pos, br, reload, true);
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
      this.saveData.slot[slot].job[job].job = (pspo2seForm.jobType) job;
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
      *pos = this.adjustPosition(*pos, br, item_position, reload, "parseCharacterTypeLevelInfo slot " + (object) slot, true);
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
      *pos = this.adjustPosition(*pos, br, item_position1, reload, "parseCharacterStoryInfo slot " + (object) slot, true);
      string data1 = this.brGetData(1, br, pos, pspo2seForm.saveInfoDataType.hex, reload, true);
      this.saveData.slot[slot].mission_unlock_magashi = false;
      if (data1 == "1F")
        this.saveData.slot[slot].mission_unlock_magashi = true;
      int item_position2 = this.mainSettings.saveStructureIndex.story_info_pos + this.mainSettings.saveStructureIndex.slot_size * slot;
      *pos = this.adjustPosition(*pos, br, item_position2, reload, "parseCharacterStoryInfo slot " + (object) slot, true);
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
      *pos = this.adjustPosition(*pos, br, item_position1, reload, "parseCharacterTypeExtraInfo slot " + (object) slot, true);
      for (int index = 0; index < 4; ++index)
      {
        int item_position2 = this.mainSettings.saveStructureIndex.type_level_pos + this.mainSettings.saveStructureIndex.slot_size * slot + 16 + index * this.mainSettings.saveStructureIndex.type_extend_size;
        *pos = this.adjustPosition(*pos, br, item_position2, (reload ? 1 : 0) != 0, "parseCharacterTypeExtraInfo slot " + (object) slot + " job " + (object) index, true);
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
        this.saveData.slot[slot].job[index1].weapons_extended[index2] = (pspo2seForm.extendRankType) int.Parse(str.Substring(startIndex, 1));
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
      *pos = this.adjustPosition(*pos, br, item_position, reload, "parseCharacterInventoryCountInfo slot " + (object) slot, true);
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
      *pos = this.adjustPosition(*pos, br, item_position, reload, "parseCharacterInventoryCountInfo slot " + (object) slot, true);
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
      *pos = this.adjustPosition(*pos, br, sharedInventoryPos, reload, nameof (parseCharacterSharedStorageSlotsInfo), true);
      this.saveData.sharedInventory.itemsUsed = 0;
      for (int index = 0; index < this.mainSettings.saveStructureIndex.shared_inventory_slots; ++index)
        this.saveData.sharedInventory.item[index] = this.brGetItem(pos, br, reload);
      this.saveData.sharedMeseta = (long) this.brGetInt32(pos, br, reload, true);
      return true;
    }

    private unsafe bool parseInfinityMissionSlotsInfo(BinaryReader br, int* pos, bool reload)
    {
      if (this.saveData.type == pspo2seForm.SaveType.PSP2)
        return true;
      int infinityMissionPos = this.mainSettings.saveStructureIndex.infinity_mission_pos;
      *pos = this.adjustPosition(*pos, br, infinityMissionPos, reload, nameof (parseInfinityMissionSlotsInfo), true);
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
        int num2 = (int) Math.Floor((double) int.Parse(data.Substring(4, 1), NumberStyles.HexNumber) / 2.0);
        this.saveData.infinityMissions.slot[index1].enemy_1 = num2;
        int num3 = (int) Math.Ceiling((double) int.Parse(data.Substring(4, 1), NumberStyles.HexNumber) / 2.0);
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

      public int CompareTo(object obj) => obj is pspo2seForm.infinityMissionClass ? this.hex.CompareTo(((pspo2seForm.infinityMissionClass) obj).hex) : throw new ArgumentException("Object is not of type infinityMissionClass.");
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

      public int CompareTo(object obj) => obj is pspo2seForm.inventoryItemClass ? this.hex.CompareTo(((pspo2seForm.inventoryItemClass) obj).hex) : throw new ArgumentException("Object is not of type inventoryItemClass.");
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
