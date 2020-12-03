using pspo2seSaveEditorProgram.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class pspo2seForm : Form
    { 
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


        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pspo2seForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.tabArea = new System.Windows.Forms.TabControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtStoryTrueEnd = new System.Windows.Forms.Label();
            this.txtStoryComplete = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picWeaponSlot01 = new System.Windows.Forms.PictureBox();
            this.picWeaponSlot06 = new System.Windows.Forms.PictureBox();
            this.picWeaponSlot02 = new System.Windows.Forms.PictureBox();
            this.picWeaponSlot05 = new System.Windows.Forms.PictureBox();
            this.picWeaponSlot03 = new System.Windows.Forms.PictureBox();
            this.picWeaponSlot04 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCharacterName = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.Label();
            this.txtLevelExpBar = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtExpNext = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtExp = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.txtRace = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtCurType = new System.Windows.Forms.Label();
            this.txtPlaytime = new System.Windows.Forms.Label();
            this.tabTypeInfo = new System.Windows.Forms.TabPage();
            this.tabControlClasses = new System.Windows.Forms.TabControl();
            this.tabPageHunter = new System.Windows.Forms.TabPage();
            this.btnHuAbilitiesOpen = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.grpHuTypeExtend = new System.Windows.Forms.GroupBox();
            this.imgHuTmagRank = new System.Windows.Forms.PictureBox();
            this.imgHuMachinegunRank = new System.Windows.Forms.PictureBox();
            this.txtHuExpBar = new System.Windows.Forms.Label();
            this.txtHuExp = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.imgHuHandgunsRank = new System.Windows.Forms.PictureBox();
            this.label36 = new System.Windows.Forms.Label();
            this.imgHuShotgunRank = new System.Windows.Forms.PictureBox();
            this.imgHuClawRank = new System.Windows.Forms.PictureBox();
            this.imgHuDaggersRank = new System.Windows.Forms.PictureBox();
            this.imgHuSpearRank = new System.Windows.Forms.PictureBox();
            this.imgHuWandRank = new System.Windows.Forms.PictureBox();
            this.imgHuCardsRank = new System.Windows.Forms.PictureBox();
            this.imgHuLaserRank = new System.Windows.Forms.PictureBox();
            this.imgHuRifleRank = new System.Windows.Forms.PictureBox();
            this.imgHuDaggerRank = new System.Windows.Forms.PictureBox();
            this.imgHuSabersRank = new System.Windows.Forms.PictureBox();
            this.imgHuKnucklesRank = new System.Windows.Forms.PictureBox();
            this.imgHuShieldRank = new System.Windows.Forms.PictureBox();
            this.imgHuRmagRank = new System.Windows.Forms.PictureBox();
            this.imgHuHandgunRank = new System.Windows.Forms.PictureBox();
            this.imgHuLongbowRank = new System.Windows.Forms.PictureBox();
            this.imgHuWhipRank = new System.Windows.Forms.PictureBox();
            this.imgHuClawsRank = new System.Windows.Forms.PictureBox();
            this.imgHuDblSaberRank = new System.Windows.Forms.PictureBox();
            this.imgHuRodRank = new System.Windows.Forms.PictureBox();
            this.imgHuCrossbowRank = new System.Windows.Forms.PictureBox();
            this.imgHuGrenadeRank = new System.Windows.Forms.PictureBox();
            this.imgHuSlicerRank = new System.Windows.Forms.PictureBox();
            this.imgHuSaberRank = new System.Windows.Forms.PictureBox();
            this.imgHuAxeRank = new System.Windows.Forms.PictureBox();
            this.imgHuSwordRank = new System.Windows.Forms.PictureBox();
            this.imgHuRmag = new System.Windows.Forms.PictureBox();
            this.imgHuMachinegun = new System.Windows.Forms.PictureBox();
            this.imgHuCrossbow = new System.Windows.Forms.PictureBox();
            this.imgHuCards = new System.Windows.Forms.PictureBox();
            this.imgHuHandgun = new System.Windows.Forms.PictureBox();
            this.imgHuHandguns = new System.Windows.Forms.PictureBox();
            this.imgHuGrenade = new System.Windows.Forms.PictureBox();
            this.imgHuLaser = new System.Windows.Forms.PictureBox();
            this.imgHuLongbow = new System.Windows.Forms.PictureBox();
            this.imgHuShotgun = new System.Windows.Forms.PictureBox();
            this.imgHuSlicer = new System.Windows.Forms.PictureBox();
            this.imgHuRifle = new System.Windows.Forms.PictureBox();
            this.imgHuWhip = new System.Windows.Forms.PictureBox();
            this.imgHuClaw = new System.Windows.Forms.PictureBox();
            this.imgHuSaber = new System.Windows.Forms.PictureBox();
            this.imgHuDagger = new System.Windows.Forms.PictureBox();
            this.imgHuShield = new System.Windows.Forms.PictureBox();
            this.imgHuTmag = new System.Windows.Forms.PictureBox();
            this.imgHuRod = new System.Windows.Forms.PictureBox();
            this.imgHuWand = new System.Windows.Forms.PictureBox();
            this.imgHuClaws = new System.Windows.Forms.PictureBox();
            this.imgHuDaggers = new System.Windows.Forms.PictureBox();
            this.imgHuAxe = new System.Windows.Forms.PictureBox();
            this.imgHuSabers = new System.Windows.Forms.PictureBox();
            this.imgHuDblSaber = new System.Windows.Forms.PictureBox();
            this.imgHuKnuckles = new System.Windows.Forms.PictureBox();
            this.imgHuSpear = new System.Windows.Forms.PictureBox();
            this.imgHuSword = new System.Windows.Forms.PictureBox();
            this.pictureBox231 = new System.Windows.Forms.PictureBox();
            this.lblHuLevel = new System.Windows.Forms.Label();
            this.txtHuLevel = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.tabPageRanger = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.grpRaTypeExtend = new System.Windows.Forms.GroupBox();
            this.txtRaExp = new System.Windows.Forms.Label();
            this.imgRaTmagRank = new System.Windows.Forms.PictureBox();
            this.imgRaMachinegunRank = new System.Windows.Forms.PictureBox();
            this.txtRaExpBar = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.imgRaHandgunsRank = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.imgRaShotgunRank = new System.Windows.Forms.PictureBox();
            this.imgRaClawRank = new System.Windows.Forms.PictureBox();
            this.imgRaDaggersRank = new System.Windows.Forms.PictureBox();
            this.imgRaSpearRank = new System.Windows.Forms.PictureBox();
            this.imgRaWandRank = new System.Windows.Forms.PictureBox();
            this.imgRaCardsRank = new System.Windows.Forms.PictureBox();
            this.imgRaLaserRank = new System.Windows.Forms.PictureBox();
            this.imgRaRifleRank = new System.Windows.Forms.PictureBox();
            this.imgRaDaggerRank = new System.Windows.Forms.PictureBox();
            this.imgRaSabersRank = new System.Windows.Forms.PictureBox();
            this.imgRaKnucklesRank = new System.Windows.Forms.PictureBox();
            this.imgRaShieldRank = new System.Windows.Forms.PictureBox();
            this.imgRaRmagRank = new System.Windows.Forms.PictureBox();
            this.imgRaHandgunRank = new System.Windows.Forms.PictureBox();
            this.imgRaLongbowRank = new System.Windows.Forms.PictureBox();
            this.imgRaWhipRank = new System.Windows.Forms.PictureBox();
            this.imgRaClawsRank = new System.Windows.Forms.PictureBox();
            this.imgRaDblSaberRank = new System.Windows.Forms.PictureBox();
            this.imgRaRodRank = new System.Windows.Forms.PictureBox();
            this.imgRaCrossbowRank = new System.Windows.Forms.PictureBox();
            this.imgRaGrenadeRank = new System.Windows.Forms.PictureBox();
            this.imgRaSlicerRank = new System.Windows.Forms.PictureBox();
            this.imgRaSaberRank = new System.Windows.Forms.PictureBox();
            this.imgRaAxeRank = new System.Windows.Forms.PictureBox();
            this.imgRaSwordRank = new System.Windows.Forms.PictureBox();
            this.imgRaRmag = new System.Windows.Forms.PictureBox();
            this.imgRaMachinegun = new System.Windows.Forms.PictureBox();
            this.imgRaCrossbow = new System.Windows.Forms.PictureBox();
            this.imgRaCards = new System.Windows.Forms.PictureBox();
            this.imgRaHandgun = new System.Windows.Forms.PictureBox();
            this.imgRaHandguns = new System.Windows.Forms.PictureBox();
            this.imgRaGrenade = new System.Windows.Forms.PictureBox();
            this.imgRaLaser = new System.Windows.Forms.PictureBox();
            this.imgRaLongbow = new System.Windows.Forms.PictureBox();
            this.imgRaShotgun = new System.Windows.Forms.PictureBox();
            this.imgRaSlicer = new System.Windows.Forms.PictureBox();
            this.imgRaRifle = new System.Windows.Forms.PictureBox();
            this.imgRaWhip = new System.Windows.Forms.PictureBox();
            this.imgRaClaw = new System.Windows.Forms.PictureBox();
            this.imgRaSaber = new System.Windows.Forms.PictureBox();
            this.imgRaDagger = new System.Windows.Forms.PictureBox();
            this.imgRaShield = new System.Windows.Forms.PictureBox();
            this.imgRaTmag = new System.Windows.Forms.PictureBox();
            this.imgRaRod = new System.Windows.Forms.PictureBox();
            this.imgRaWand = new System.Windows.Forms.PictureBox();
            this.imgRaClaws = new System.Windows.Forms.PictureBox();
            this.imgRaDaggers = new System.Windows.Forms.PictureBox();
            this.imgRaAxe = new System.Windows.Forms.PictureBox();
            this.imgRaSabers = new System.Windows.Forms.PictureBox();
            this.imgRaDblSaber = new System.Windows.Forms.PictureBox();
            this.imgRaKnuckles = new System.Windows.Forms.PictureBox();
            this.imgRaSpear = new System.Windows.Forms.PictureBox();
            this.imgRaSword = new System.Windows.Forms.PictureBox();
            this.pictureBox174 = new System.Windows.Forms.PictureBox();
            this.lblRaLevel = new System.Windows.Forms.Label();
            this.txtRaLevel = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.btnRaAbilitiesOpen = new System.Windows.Forms.Button();
            this.tabPageForce = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.grpFoTypeExtend = new System.Windows.Forms.GroupBox();
            this.txtFoExp = new System.Windows.Forms.Label();
            this.imgFoTmagRank = new System.Windows.Forms.PictureBox();
            this.imgFoMachinegunRank = new System.Windows.Forms.PictureBox();
            this.txtFoExpBar = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.imgFoHandgunsRank = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.imgFoShotgunRank = new System.Windows.Forms.PictureBox();
            this.imgFoClawRank = new System.Windows.Forms.PictureBox();
            this.imgFoDaggersRank = new System.Windows.Forms.PictureBox();
            this.imgFoSpearRank = new System.Windows.Forms.PictureBox();
            this.imgFoWandRank = new System.Windows.Forms.PictureBox();
            this.imgFoCardsRank = new System.Windows.Forms.PictureBox();
            this.imgFoLaserRank = new System.Windows.Forms.PictureBox();
            this.imgFoRifleRank = new System.Windows.Forms.PictureBox();
            this.imgFoDaggerRank = new System.Windows.Forms.PictureBox();
            this.imgFoSabersRank = new System.Windows.Forms.PictureBox();
            this.imgFoKnucklesRank = new System.Windows.Forms.PictureBox();
            this.imgFoShieldRank = new System.Windows.Forms.PictureBox();
            this.imgFoRmagRank = new System.Windows.Forms.PictureBox();
            this.imgFoHandgunRank = new System.Windows.Forms.PictureBox();
            this.imgFoLongbowRank = new System.Windows.Forms.PictureBox();
            this.imgFoWhipRank = new System.Windows.Forms.PictureBox();
            this.imgFoClawsRank = new System.Windows.Forms.PictureBox();
            this.imgFoDblSaberRank = new System.Windows.Forms.PictureBox();
            this.imgFoRodRank = new System.Windows.Forms.PictureBox();
            this.imgFoCrossbowRank = new System.Windows.Forms.PictureBox();
            this.imgFoGrenadeRank = new System.Windows.Forms.PictureBox();
            this.imgFoSlicerRank = new System.Windows.Forms.PictureBox();
            this.imgFoSaberRank = new System.Windows.Forms.PictureBox();
            this.imgFoAxeRank = new System.Windows.Forms.PictureBox();
            this.imgFoSwordRank = new System.Windows.Forms.PictureBox();
            this.imgFoRmag = new System.Windows.Forms.PictureBox();
            this.imgFoMachinegun = new System.Windows.Forms.PictureBox();
            this.imgFoCrossbow = new System.Windows.Forms.PictureBox();
            this.imgFoCards = new System.Windows.Forms.PictureBox();
            this.imgFoHandgun = new System.Windows.Forms.PictureBox();
            this.imgFoHandguns = new System.Windows.Forms.PictureBox();
            this.imgFoGrenade = new System.Windows.Forms.PictureBox();
            this.imgFoLaser = new System.Windows.Forms.PictureBox();
            this.imgFoLongbow = new System.Windows.Forms.PictureBox();
            this.imgFoShotgun = new System.Windows.Forms.PictureBox();
            this.imgFoSlicer = new System.Windows.Forms.PictureBox();
            this.imgFoRifle = new System.Windows.Forms.PictureBox();
            this.imgFoWhip = new System.Windows.Forms.PictureBox();
            this.imgFoClaw = new System.Windows.Forms.PictureBox();
            this.imgFoSaber = new System.Windows.Forms.PictureBox();
            this.imgFoDagger = new System.Windows.Forms.PictureBox();
            this.imgFoShield = new System.Windows.Forms.PictureBox();
            this.imgFoTmag = new System.Windows.Forms.PictureBox();
            this.imgFoRod = new System.Windows.Forms.PictureBox();
            this.imgFoWand = new System.Windows.Forms.PictureBox();
            this.imgFoClaws = new System.Windows.Forms.PictureBox();
            this.imgFoDaggers = new System.Windows.Forms.PictureBox();
            this.imgFoAxe = new System.Windows.Forms.PictureBox();
            this.imgFoSabers = new System.Windows.Forms.PictureBox();
            this.imgFoDblSaber = new System.Windows.Forms.PictureBox();
            this.imgFoKnuckles = new System.Windows.Forms.PictureBox();
            this.imgFoSpear = new System.Windows.Forms.PictureBox();
            this.imgFoSword = new System.Windows.Forms.PictureBox();
            this.pictureBox117 = new System.Windows.Forms.PictureBox();
            this.lblFoLevel = new System.Windows.Forms.Label();
            this.txtFoLevel = new System.Windows.Forms.Label();
            this.btnFoAbilitiesOpen = new System.Windows.Forms.Button();
            this.tabPageVanguard = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.grpVaTypeExtend = new System.Windows.Forms.GroupBox();
            this.txtVaExp = new System.Windows.Forms.Label();
            this.imgVaTmagRank = new System.Windows.Forms.PictureBox();
            this.imgVaMachinegunRank = new System.Windows.Forms.PictureBox();
            this.txtVaExpBar = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.imgVaHandgunsRank = new System.Windows.Forms.PictureBox();
            this.label29 = new System.Windows.Forms.Label();
            this.imgVaShotgunRank = new System.Windows.Forms.PictureBox();
            this.imgVaClawRank = new System.Windows.Forms.PictureBox();
            this.imgVaDaggersRank = new System.Windows.Forms.PictureBox();
            this.imgVaSpearRank = new System.Windows.Forms.PictureBox();
            this.imgVaWandRank = new System.Windows.Forms.PictureBox();
            this.imgVaCardsRank = new System.Windows.Forms.PictureBox();
            this.imgVaLaserRank = new System.Windows.Forms.PictureBox();
            this.imgVaRifleRank = new System.Windows.Forms.PictureBox();
            this.imgVaDaggerRank = new System.Windows.Forms.PictureBox();
            this.imgVaSabersRank = new System.Windows.Forms.PictureBox();
            this.imgVaKnucklesRank = new System.Windows.Forms.PictureBox();
            this.imgVaShieldRank = new System.Windows.Forms.PictureBox();
            this.imgVaRmagRank = new System.Windows.Forms.PictureBox();
            this.imgVaHandgunRank = new System.Windows.Forms.PictureBox();
            this.imgVaLongbowRank = new System.Windows.Forms.PictureBox();
            this.imgVaWhipRank = new System.Windows.Forms.PictureBox();
            this.imgVaClawsRank = new System.Windows.Forms.PictureBox();
            this.imgVaDblSaberRank = new System.Windows.Forms.PictureBox();
            this.imgVaRodRank = new System.Windows.Forms.PictureBox();
            this.imgVaCrossbowRank = new System.Windows.Forms.PictureBox();
            this.imgVaGrenadeRank = new System.Windows.Forms.PictureBox();
            this.imgVaSlicerRank = new System.Windows.Forms.PictureBox();
            this.imgVaSaberRank = new System.Windows.Forms.PictureBox();
            this.imgVaAxeRank = new System.Windows.Forms.PictureBox();
            this.imgVaSwordRank = new System.Windows.Forms.PictureBox();
            this.imgVaRmag = new System.Windows.Forms.PictureBox();
            this.imgVaMachinegun = new System.Windows.Forms.PictureBox();
            this.imgVaCrossbow = new System.Windows.Forms.PictureBox();
            this.imgVaCards = new System.Windows.Forms.PictureBox();
            this.imgVaHandgun = new System.Windows.Forms.PictureBox();
            this.imgVaHandguns = new System.Windows.Forms.PictureBox();
            this.imgVaGrenade = new System.Windows.Forms.PictureBox();
            this.imgVaLaser = new System.Windows.Forms.PictureBox();
            this.imgVaLongbow = new System.Windows.Forms.PictureBox();
            this.imgVaShotgun = new System.Windows.Forms.PictureBox();
            this.imgVaSlicer = new System.Windows.Forms.PictureBox();
            this.imgVaRifle = new System.Windows.Forms.PictureBox();
            this.imgVaWhip = new System.Windows.Forms.PictureBox();
            this.imgVaClaw = new System.Windows.Forms.PictureBox();
            this.imgVaSaber = new System.Windows.Forms.PictureBox();
            this.imgVaDagger = new System.Windows.Forms.PictureBox();
            this.imgVaShield = new System.Windows.Forms.PictureBox();
            this.imgVaTmag = new System.Windows.Forms.PictureBox();
            this.imgVaRod = new System.Windows.Forms.PictureBox();
            this.imgVaWand = new System.Windows.Forms.PictureBox();
            this.imgVaClaws = new System.Windows.Forms.PictureBox();
            this.imgVaDaggers = new System.Windows.Forms.PictureBox();
            this.imgVaAxe = new System.Windows.Forms.PictureBox();
            this.imgVaSabers = new System.Windows.Forms.PictureBox();
            this.imgVaDblSaber = new System.Windows.Forms.PictureBox();
            this.imgVaKnuckles = new System.Windows.Forms.PictureBox();
            this.imgVaSpear = new System.Windows.Forms.PictureBox();
            this.imgVaSword = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtVaLevel = new System.Windows.Forms.Label();
            this.lblVaLevel = new System.Windows.Forms.Label();
            this.btnVaAbilitiesOpen = new System.Windows.Forms.Button();
            this.tabPageInventory = new System.Windows.Forms.TabPage();
            this.btnInventoryDelete = new System.Windows.Forms.Button();
            this.chkDeleteExportInventory = new System.Windows.Forms.CheckBox();
            this.btnInventoryDeposit = new System.Windows.Forms.Button();
            this.inventoryViewPages = new System.Windows.Forms.TabControl();
            this.tabInventory1 = new System.Windows.Forms.TabPage();
            this.tabInventory2 = new System.Windows.Forms.TabPage();
            this.tabInventory3 = new System.Windows.Forms.TabPage();
            this.tabInventory4 = new System.Windows.Forms.TabPage();
            this.tabInventory5 = new System.Windows.Forms.TabPage();
            this.tabInventory6 = new System.Windows.Forms.TabPage();
            this.btnInventoryImportSelected = new System.Windows.Forms.Button();
            this.btnInventoryExportSelected = new System.Windows.Forms.Button();
            this.btnInventoryImportAll = new System.Windows.Forms.Button();
            this.btnInventoryExportAll = new System.Windows.Forms.Button();
            this.txtInventoryMeseta = new System.Windows.Forms.Label();
            this.lblInventoryMeseta = new System.Windows.Forms.Label();
            this.grpInventoryItemDetails = new System.Windows.Forms.GroupBox();
            this.txtInventoryPercent = new System.Windows.Forms.Label();
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
            this.txtInventoryQty = new System.Windows.Forms.Label();
            this.imgInventoryItemIcon = new System.Windows.Forms.PictureBox();
            this.txtInventoryName = new System.Windows.Forms.Label();
            this.txtInventoryInfinityItemText = new System.Windows.Forms.Label();
            this.imgInventoryInfinityItem = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInventoryHex = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.inventoryView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.weaponWithRankImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPageStorage = new System.Windows.Forms.TabPage();
            this.btnStorageDelete = new System.Windows.Forms.Button();
            this.chkDeleteExportStorage = new System.Windows.Forms.CheckBox();
            this.btnStorageWithdraw = new System.Windows.Forms.Button();
            this.storageViewPages = new System.Windows.Forms.TabControl();
            this.tabStorage1 = new System.Windows.Forms.TabPage();
            this.tabStorage2 = new System.Windows.Forms.TabPage();
            this.tabStorage3 = new System.Windows.Forms.TabPage();
            this.tabStorage4 = new System.Windows.Forms.TabPage();
            this.tabStorage5 = new System.Windows.Forms.TabPage();
            this.tabStorage6 = new System.Windows.Forms.TabPage();
            this.storageView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStorageImportAll = new System.Windows.Forms.Button();
            this.btnStorageExportAll = new System.Windows.Forms.Button();
            this.btnStorageImportSelected = new System.Windows.Forms.Button();
            this.btnStorageExportSelected = new System.Windows.Forms.Button();
            this.txtStorageMeseta = new System.Windows.Forms.Label();
            this.lblStorageMeseta = new System.Windows.Forms.Label();
            this.grpStorageItemDetails = new System.Windows.Forms.GroupBox();
            this.txtStoragePercent = new System.Windows.Forms.Label();
            this.txtStorageLevel = new System.Windows.Forms.Label();
            this.txtStorageACC = new System.Windows.Forms.Label();
            this.txtStorageATK = new System.Windows.Forms.Label();
            this.txtStorageEffect = new System.Windows.Forms.Label();
            this.txtStorageSpecial = new System.Windows.Forms.Label();
            this.imgStorageRank = new System.Windows.Forms.PictureBox();
            this.imgStorageStar15 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar14 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar13 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar12 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar11 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar10 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar9 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar8 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar7 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar6 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar5 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar4 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar3 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar2 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar1 = new System.Windows.Forms.PictureBox();
            this.imgStorageStar0 = new System.Windows.Forms.PictureBox();
            this.imgStorageWeaponManufacturer = new System.Windows.Forms.PictureBox();
            this.txtStorageGrinds = new System.Windows.Forms.Label();
            this.txtStorageName_jp = new System.Windows.Forms.Label();
            this.imgStorageItemIcon = new System.Windows.Forms.PictureBox();
            this.txtStorageName = new System.Windows.Forms.Label();
            this.imgStorageElement = new System.Windows.Forms.PictureBox();
            this.txtStorageQty = new System.Windows.Forms.Label();
            this.txtStorageInfinityItemText = new System.Windows.Forms.Label();
            this.imgStorageInfinityItem = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStorageHex = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tabPageMissions = new System.Windows.Forms.TabPage();
            this.tabControlMissions = new System.Windows.Forms.TabControl();
            this.tabEp1Missions = new System.Windows.Forms.TabPage();
            this.txtAllowQuitMission = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.txtEp1Complete = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtStoryEmiliaPoints = new System.Windows.Forms.Label();
            this.txtMissionTactical = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMissionMagashi = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSkipEp1Start = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMissionEp1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEp2Missions = new System.Windows.Forms.TabPage();
            this.txtEp2Complete = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtStoryNagisaPoints = new System.Windows.Forms.Label();
            this.txtSkipEp2Start = new System.Windows.Forms.Label();
            this.lblSkipEp2Start = new System.Windows.Forms.Label();
            this.txtMissionEp2 = new System.Windows.Forms.Label();
            this.lblMissionEp2 = new System.Windows.Forms.Label();
            this.tabPageInfinityMission = new System.Windows.Forms.TabPage();
            this.btnImportMissions = new System.Windows.Forms.Button();
            this.btnExportMissions = new System.Windows.Forms.Button();
            this.btnModifyInfinityMission = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpInfinityMissionDetails = new System.Windows.Forms.GroupBox();
            this.txtInfEnemyLevel = new System.Windows.Forms.Label();
            this.txtInfNameJp = new System.Windows.Forms.Label();
            this.txtInfNameEn = new System.Windows.Forms.Label();
            this.txtInfMisEnemy2 = new System.Windows.Forms.Label();
            this.txtInfMisBoss = new System.Windows.Forms.Label();
            this.txtInfMisEnemy1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpInfMisSpecial = new System.Windows.Forms.GroupBox();
            this.txtInfMisSpecial = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grpInfMisExtra = new System.Windows.Forms.GroupBox();
            this.txtInfMisSynthPoint = new System.Windows.Forms.Label();
            this.txtInfMisCreatedBy = new System.Windows.Forms.Label();
            this.btnDeleteInfinityMission = new System.Windows.Forms.Button();
            this.btnImportInfinityMission = new System.Windows.Forms.Button();
            this.btnExportInfinityMission = new System.Windows.Forms.Button();
            this.lstInfinityMissions = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtInfinityMissionQty = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.tabPagePA = new System.Windows.Forms.TabPage();
            this.tabPA = new System.Windows.Forms.TabControl();
            this.tabPAMelee = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.txtPAHexMelee = new System.Windows.Forms.Label();
            this.lstPAMelee = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPABullets = new System.Windows.Forms.TabPage();
            this.txtPAHexBullets = new System.Windows.Forms.Label();
            this.lstPABullets = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPATech = new System.Windows.Forms.TabPage();
            this.txtPAHexTech = new System.Windows.Forms.Label();
            this.lstPATechs = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageRebirth = new System.Windows.Forms.TabPage();
            this.chkRebirthNoLevelDrop = new System.Windows.Forms.CheckBox();
            this.chkRebirthSpoof = new System.Windows.Forms.CheckBox();
            this.comboRebirthExtend = new System.Windows.Forms.ComboBox();
            this.btnRebirth = new System.Windows.Forms.Button();
            this.txtRebirthMaxType = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lstRebirthRewards = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label17 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtRebirthCount = new System.Windows.Forms.Label();
            this.txtRebirthPoints = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.grpRebirth = new System.Windows.Forms.GroupBox();
            this.txtRebirthNextSTA = new System.Windows.Forms.Label();
            this.txtRebirthNextPP = new System.Windows.Forms.Label();
            this.txtRebirthNextHP = new System.Windows.Forms.Label();
            this.txtRebirthNextMND = new System.Windows.Forms.Label();
            this.txtRebirthNextTEC = new System.Windows.Forms.Label();
            this.txtRebirthNextEVA = new System.Windows.Forms.Label();
            this.txtRebirthNextACC = new System.Windows.Forms.Label();
            this.txtRebirthNextDEF = new System.Windows.Forms.Label();
            this.txtRebirthNextATK = new System.Windows.Forms.Label();
            this.txtRebirthBpSTA = new System.Windows.Forms.Label();
            this.txtRebirthBpPP = new System.Windows.Forms.Label();
            this.txtRebirthBpHP = new System.Windows.Forms.Label();
            this.txtRebirthBpMND = new System.Windows.Forms.Label();
            this.txtRebirthBpTEC = new System.Windows.Forms.Label();
            this.txtRebirthBpEVA = new System.Windows.Forms.Label();
            this.txtRebirthBpACC = new System.Windows.Forms.Label();
            this.txtRebirthBpDEF = new System.Windows.Forms.Label();
            this.txtRebirthBpATK = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.numRebirthSTA = new System.Windows.Forms.NumericUpDown();
            this.txtRebirthSTA = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.numRebirthPP = new System.Windows.Forms.NumericUpDown();
            this.numRebirthHP = new System.Windows.Forms.NumericUpDown();
            this.txtRebirthPP = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txtRebirthHP = new System.Windows.Forms.Label();
            this.numRebirthMND = new System.Windows.Forms.NumericUpDown();
            this.numRebirthTEC = new System.Windows.Forms.NumericUpDown();
            this.numRebirthEVA = new System.Windows.Forms.NumericUpDown();
            this.numRebirthACC = new System.Windows.Forms.NumericUpDown();
            this.numRebirthDEF = new System.Windows.Forms.NumericUpDown();
            this.numRebirthATK = new System.Windows.Forms.NumericUpDown();
            this.txtRebirthMND = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.txtRebirthTEC = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtRebirthEVA = new System.Windows.Forms.Label();
            this.txtRebirthACC = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtRebirthDEF = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txtRebirthATK = new System.Windows.Forms.Label();
            this.btnUndoAll = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.sexImageList = new System.Windows.Forms.ImageList(this.components);
            this.armourImageList = new System.Windows.Forms.ImageList(this.components);
            this.itemImageList = new System.Windows.Forms.ImageList(this.components);
            this.clothesImageList = new System.Windows.Forms.ImageList(this.components);
            this.decoImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFooterText = new System.Windows.Forms.Label();
            this.lstSaveSlotView = new System.Windows.Forms.ListView();
            this.slotViewHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.slotViewHeader_level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.slotViewHeader_class = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.slotViewHeader_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.slotViewHeader_complete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtFileSize = new System.Windows.Forms.Label();
            this.btnExportCharacter = new System.Windows.Forms.Button();
            this.txtSlotnumloaded = new System.Windows.Forms.Label();
            this.btnImportCharacter = new System.Windows.Forms.Button();
            this.txtFileLoc = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grpImageFloater = new System.Windows.Forms.GroupBox();
            this.imgFloater = new System.Windows.Forms.PictureBox();
            this.panelImageFloater = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageListWeaponElements = new System.Windows.Forms.ImageList(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.imgSave = new System.Windows.Forms.PictureBox();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgGameLogo = new System.Windows.Forms.PictureBox();
            this.tabArea.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot04)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabTypeInfo.SuspendLayout();
            this.tabControlClasses.SuspendLayout();
            this.tabPageHunter.SuspendLayout();
            this.grpHuTypeExtend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuTmagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuMachinegunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuHandgunsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuShotgunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuClawRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDaggersRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSpearRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuWandRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuCardsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuLaserRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRifleRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDaggerRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSabersRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuKnucklesRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuShieldRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRmagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuHandgunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuLongbowRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuWhipRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuClawsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDblSaberRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRodRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuCrossbowRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuGrenadeRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSlicerRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSaberRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuAxeRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSwordRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRmag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuMachinegun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuCrossbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuHandgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuHandguns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuGrenade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuLaser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuLongbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuShotgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSlicer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRifle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuWhip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuClaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSaber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDagger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuShield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuTmag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuWand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuClaws)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDaggers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuAxe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSabers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDblSaber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuKnuckles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSpear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox231)).BeginInit();
            this.tabPageRanger.SuspendLayout();
            this.grpRaTypeExtend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaTmagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaMachinegunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaHandgunsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaShotgunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaClawRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDaggersRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSpearRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaWandRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaCardsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaLaserRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRifleRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDaggerRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSabersRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaKnucklesRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaShieldRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRmagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaHandgunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaLongbowRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaWhipRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaClawsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDblSaberRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRodRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaCrossbowRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaGrenadeRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSlicerRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSaberRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaAxeRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSwordRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRmag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaMachinegun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaCrossbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaHandgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaHandguns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaGrenade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaLaser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaLongbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaShotgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSlicer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRifle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaWhip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaClaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSaber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDagger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaShield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaTmag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaWand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaClaws)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDaggers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaAxe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSabers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDblSaber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaKnuckles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSpear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox174)).BeginInit();
            this.tabPageForce.SuspendLayout();
            this.grpFoTypeExtend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoTmagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoMachinegunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoHandgunsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoShotgunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoClawRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDaggersRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSpearRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoWandRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoCardsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoLaserRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRifleRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDaggerRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSabersRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoKnucklesRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoShieldRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRmagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoHandgunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoLongbowRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoWhipRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoClawsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDblSaberRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRodRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoCrossbowRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoGrenadeRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSlicerRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSaberRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoAxeRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSwordRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRmag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoMachinegun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoCrossbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoHandgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoHandguns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoGrenade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoLaser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoLongbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoShotgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSlicer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRifle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoWhip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoClaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSaber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDagger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoShield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoTmag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoWand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoClaws)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDaggers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoAxe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSabers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDblSaber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoKnuckles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSpear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox117)).BeginInit();
            this.tabPageVanguard.SuspendLayout();
            this.grpVaTypeExtend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaTmagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaMachinegunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaHandgunsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaShotgunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaClawRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDaggersRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSpearRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaWandRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaCardsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaLaserRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRifleRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDaggerRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSabersRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaKnucklesRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaShieldRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRmagRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaHandgunRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaLongbowRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaWhipRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaClawsRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDblSaberRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRodRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaCrossbowRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaGrenadeRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSlicerRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSaberRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaAxeRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSwordRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRmag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaMachinegun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaCrossbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaHandgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaHandguns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaGrenade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaLaser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaLongbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaShotgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSlicer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRifle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaWhip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaClaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSaber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDagger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaShield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaTmag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaWand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaClaws)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDaggers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaAxe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSabers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDblSaber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaKnuckles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSpear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.tabPageInventory.SuspendLayout();
            this.inventoryViewPages.SuspendLayout();
            this.grpInventoryItemDetails.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.tabPageStorage.SuspendLayout();
            this.storageViewPages.SuspendLayout();
            this.grpStorageItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageWeaponManufacturer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageItemIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageElement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageInfinityItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).BeginInit();
            this.tabPABullets.SuspendLayout();
            this.tabPATech.SuspendLayout();
            this.tabPageRebirth.SuspendLayout();
            this.grpRebirth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthSTA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthMND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthTEC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthEVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthACC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthDEF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthATK)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpImageFloater.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFloater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGameLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // tabArea
            // 
            this.tabArea.Controls.Add(this.tabPageInfo);
            this.tabArea.Controls.Add(this.tabTypeInfo);
            this.tabArea.Controls.Add(this.tabPageInventory);
            this.tabArea.Controls.Add(this.tabPageStorage);
            this.tabArea.Controls.Add(this.tabPageMissions);
            this.tabArea.Controls.Add(this.tabPagePA);
            this.tabArea.Controls.Add(this.tabPageRebirth);
            this.tabArea.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabArea.Enabled = false;
            this.tabArea.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabArea.Location = new System.Drawing.Point(4, 233);
            this.tabArea.Name = "tabArea";
            this.tabArea.SelectedIndex = 0;
            this.tabArea.Size = new System.Drawing.Size(637, 249);
            this.tabArea.TabIndex = 18;
            this.tabArea.SelectedIndexChanged += new System.EventHandler(this.tabArea_SelectedIndexChanged);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageInfo.Controls.Add(this.groupBox5);
            this.tabPageInfo.Controls.Add(this.groupBox7);
            this.tabPageInfo.Controls.Add(this.groupBox4);
            this.tabPageInfo.Controls.Add(this.groupBox3);
            this.tabPageInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPageInfo.ForeColor = System.Drawing.Color.Black;
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(629, 223);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "General";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtStoryTrueEnd);
            this.groupBox5.Controls.Add(this.txtStoryComplete);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(258, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(360, 71);
            this.groupBox5.TabIndex = 73;
            this.groupBox5.TabStop = false;
            // 
            // txtStoryTrueEnd
            // 
            this.txtStoryTrueEnd.AutoSize = true;
            this.txtStoryTrueEnd.BackColor = System.Drawing.Color.Transparent;
            this.txtStoryTrueEnd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoryTrueEnd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtStoryTrueEnd.Location = new System.Drawing.Point(15, 41);
            this.txtStoryTrueEnd.Name = "txtStoryTrueEnd";
            this.txtStoryTrueEnd.Size = new System.Drawing.Size(130, 13);
            this.txtStoryTrueEnd.TabIndex = 75;
            this.txtStoryTrueEnd.Text = "True Ending Achieved";
            this.txtStoryTrueEnd.Visible = false;
            // 
            // txtStoryComplete
            // 
            this.txtStoryComplete.AutoSize = true;
            this.txtStoryComplete.BackColor = System.Drawing.Color.Transparent;
            this.txtStoryComplete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoryComplete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtStoryComplete.Location = new System.Drawing.Point(15, 19);
            this.txtStoryComplete.Name = "txtStoryComplete";
            this.txtStoryComplete.Size = new System.Drawing.Size(111, 14);
            this.txtStoryComplete.TabIndex = 73;
            this.txtStoryComplete.Text = "Game Complete";
            this.txtStoryComplete.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.panel1);
            this.groupBox7.Location = new System.Drawing.Point(258, 70);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(109, 75);
            this.groupBox7.TabIndex = 81;
            this.groupBox7.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.picWeaponSlot01);
            this.panel1.Controls.Add(this.picWeaponSlot06);
            this.panel1.Controls.Add(this.picWeaponSlot02);
            this.panel1.Controls.Add(this.picWeaponSlot05);
            this.panel1.Controls.Add(this.picWeaponSlot03);
            this.panel1.Controls.Add(this.picWeaponSlot04);
            this.panel1.Location = new System.Drawing.Point(11, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(89, 41);
            this.panel1.TabIndex = 80;
            // 
            // picWeaponSlot01
            // 
            this.picWeaponSlot01.BackColor = System.Drawing.Color.Black;
            this.picWeaponSlot01.Location = new System.Drawing.Point(7, 7);
            this.picWeaponSlot01.Name = "picWeaponSlot01";
            this.picWeaponSlot01.Size = new System.Drawing.Size(23, 12);
            this.picWeaponSlot01.TabIndex = 74;
            this.picWeaponSlot01.TabStop = false;
            // 
            // picWeaponSlot06
            // 
            this.picWeaponSlot06.BackColor = System.Drawing.Color.Black;
            this.picWeaponSlot06.Location = new System.Drawing.Point(57, 21);
            this.picWeaponSlot06.Name = "picWeaponSlot06";
            this.picWeaponSlot06.Size = new System.Drawing.Size(23, 12);
            this.picWeaponSlot06.TabIndex = 79;
            this.picWeaponSlot06.TabStop = false;
            // 
            // picWeaponSlot02
            // 
            this.picWeaponSlot02.BackColor = System.Drawing.Color.Black;
            this.picWeaponSlot02.Location = new System.Drawing.Point(32, 7);
            this.picWeaponSlot02.Name = "picWeaponSlot02";
            this.picWeaponSlot02.Size = new System.Drawing.Size(23, 12);
            this.picWeaponSlot02.TabIndex = 75;
            this.picWeaponSlot02.TabStop = false;
            // 
            // picWeaponSlot05
            // 
            this.picWeaponSlot05.BackColor = System.Drawing.Color.Black;
            this.picWeaponSlot05.Location = new System.Drawing.Point(32, 21);
            this.picWeaponSlot05.Name = "picWeaponSlot05";
            this.picWeaponSlot05.Size = new System.Drawing.Size(23, 12);
            this.picWeaponSlot05.TabIndex = 78;
            this.picWeaponSlot05.TabStop = false;
            // 
            // picWeaponSlot03
            // 
            this.picWeaponSlot03.BackColor = System.Drawing.Color.Black;
            this.picWeaponSlot03.Location = new System.Drawing.Point(57, 7);
            this.picWeaponSlot03.Name = "picWeaponSlot03";
            this.picWeaponSlot03.Size = new System.Drawing.Size(23, 12);
            this.picWeaponSlot03.TabIndex = 76;
            this.picWeaponSlot03.TabStop = false;
            // 
            // picWeaponSlot04
            // 
            this.picWeaponSlot04.BackColor = System.Drawing.Color.Black;
            this.picWeaponSlot04.Location = new System.Drawing.Point(7, 21);
            this.picWeaponSlot04.Name = "picWeaponSlot04";
            this.picWeaponSlot04.Size = new System.Drawing.Size(23, 12);
            this.picWeaponSlot04.TabIndex = 77;
            this.picWeaponSlot04.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCharacterName);
            this.groupBox4.Controls.Add(this.lblLevel);
            this.groupBox4.Controls.Add(this.txtLevel);
            this.groupBox4.Controls.Add(this.txtLevelExpBar);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(9, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(243, 71);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.BackColor = System.Drawing.Color.Transparent;
            this.txtCharacterName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCharacterName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharacterName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCharacterName.Location = new System.Drawing.Point(14, 17);
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(223, 16);
            this.txtCharacterName.TabIndex = 18;
            this.txtCharacterName.Text = "No Save File Loaded";
            this.txtCharacterName.Click += new System.EventHandler(this.txtCharacterName_Click);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLevel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLevel.Location = new System.Drawing.Point(14, 32);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(40, 14);
            this.lblLevel.TabIndex = 20;
            this.lblLevel.Text = "Level";
            this.lblLevel.Click += new System.EventHandler(this.txtLevel_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.BackColor = System.Drawing.Color.Transparent;
            this.txtLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtLevel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLevel.Location = new System.Drawing.Point(52, 32);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(60, 14);
            this.txtLevel.TabIndex = 21;
            this.txtLevel.Text = "0";
            this.txtLevel.Click += new System.EventHandler(this.txtLevel_Click);
            // 
            // txtLevelExpBar
            // 
            this.txtLevelExpBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(104)))), ((int)(((byte)(184)))));
            this.txtLevelExpBar.Location = new System.Drawing.Point(19, 59);
            this.txtLevelExpBar.Name = "txtLevelExpBar";
            this.txtLevelExpBar.Size = new System.Drawing.Size(0, 4);
            this.txtLevelExpBar.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(18, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(202, 6);
            this.label11.TabIndex = 41;
            // 
            // groupBox3
            // 
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
            this.groupBox3.Location = new System.Drawing.Point(9, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 143);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            // 
            // txtExpNext
            // 
            this.txtExpNext.AutoSize = true;
            this.txtExpNext.BackColor = System.Drawing.Color.Transparent;
            this.txtExpNext.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpNext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtExpNext.Location = new System.Drawing.Point(86, 116);
            this.txtExpNext.Name = "txtExpNext";
            this.txtExpNext.Size = new System.Drawing.Size(12, 13);
            this.txtExpNext.TabIndex = 66;
            this.txtExpNext.Text = "-";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(2, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 14);
            this.label9.TabIndex = 65;
            this.label9.Text = "Exp To Next";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtExp
            // 
            this.txtExp.AutoSize = true;
            this.txtExp.BackColor = System.Drawing.Color.Transparent;
            this.txtExp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtExp.Location = new System.Drawing.Point(86, 102);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(12, 13);
            this.txtExp.TabIndex = 60;
            this.txtExp.Text = "-";
            // 
            // txtSex
            // 
            this.txtSex.AutoSize = true;
            this.txtSex.BackColor = System.Drawing.Color.Transparent;
            this.txtSex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSex.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSex.Location = new System.Drawing.Point(86, 80);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(12, 13);
            this.txtSex.TabIndex = 64;
            this.txtSex.Text = "-";
            this.txtSex.Click += new System.EventHandler(this.txtSex_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(23, 102);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 14);
            this.label21.TabIndex = 59;
            this.label21.Text = "Total Exp";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.BackColor = System.Drawing.Color.Transparent;
            this.lblSex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSex.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSex.Location = new System.Drawing.Point(54, 80);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(29, 13);
            this.lblSex.TabIndex = 63;
            this.lblSex.Text = "Sex";
            this.lblSex.Click += new System.EventHandler(this.txtSex_Click);
            // 
            // txtRace
            // 
            this.txtRace.AutoSize = true;
            this.txtRace.BackColor = System.Drawing.Color.Transparent;
            this.txtRace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtRace.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRace.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRace.Location = new System.Drawing.Point(86, 66);
            this.txtRace.Name = "txtRace";
            this.txtRace.Size = new System.Drawing.Size(12, 13);
            this.txtRace.TabIndex = 62;
            this.txtRace.Text = "-";
            this.txtRace.Click += new System.EventHandler(this.txtClass_Click);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.BackColor = System.Drawing.Color.Transparent;
            this.lblClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClass.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblClass.Location = new System.Drawing.Point(48, 66);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(35, 13);
            this.lblClass.TabIndex = 61;
            this.lblClass.Text = "Race";
            this.lblClass.Click += new System.EventHandler(this.txtClass_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitle.Location = new System.Drawing.Point(53, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(31, 13);
            this.lblTitle.TabIndex = 53;
            this.lblTitle.Text = "Title";
            this.lblTitle.Click += new System.EventHandler(this.txtTitle_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTitle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTitle.Location = new System.Drawing.Point(86, 38);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(12, 13);
            this.txtTitle.TabIndex = 54;
            this.txtTitle.Text = "-";
            this.txtTitle.Click += new System.EventHandler(this.txtTitle_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(21, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Play Time";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblType.Location = new System.Drawing.Point(45, 52);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(38, 13);
            this.lblType.TabIndex = 57;
            this.lblType.Text = "Class";
            this.lblType.Click += new System.EventHandler(this.txtCurType_Click);
            // 
            // txtCurType
            // 
            this.txtCurType.AutoSize = true;
            this.txtCurType.BackColor = System.Drawing.Color.Transparent;
            this.txtCurType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCurType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCurType.Location = new System.Drawing.Point(86, 52);
            this.txtCurType.Name = "txtCurType";
            this.txtCurType.Size = new System.Drawing.Size(12, 13);
            this.txtCurType.TabIndex = 58;
            this.txtCurType.Text = "-";
            this.txtCurType.Click += new System.EventHandler(this.txtCurType_Click);
            // 
            // txtPlaytime
            // 
            this.txtPlaytime.AutoSize = true;
            this.txtPlaytime.BackColor = System.Drawing.Color.Transparent;
            this.txtPlaytime.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaytime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPlaytime.Location = new System.Drawing.Point(86, 15);
            this.txtPlaytime.Name = "txtPlaytime";
            this.txtPlaytime.Size = new System.Drawing.Size(59, 13);
            this.txtPlaytime.TabIndex = 56;
            this.txtPlaytime.Text = "00:00:00";
            // 
            // tabTypeInfo
            // 
            this.tabTypeInfo.Controls.Add(this.tabControlClasses);
            this.tabTypeInfo.Location = new System.Drawing.Point(4, 22);
            this.tabTypeInfo.Name = "tabTypeInfo";
            this.tabTypeInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabTypeInfo.Size = new System.Drawing.Size(629, 223);
            this.tabTypeInfo.TabIndex = 9;
            this.tabTypeInfo.Text = "Type";
            this.tabTypeInfo.UseVisualStyleBackColor = true;
            // 
            // tabControlClasses
            // 
            this.tabControlClasses.Controls.Add(this.tabPageHunter);
            this.tabControlClasses.Controls.Add(this.tabPageRanger);
            this.tabControlClasses.Controls.Add(this.tabPageForce);
            this.tabControlClasses.Controls.Add(this.tabPageVanguard);
            this.tabControlClasses.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlClasses.Location = new System.Drawing.Point(5, 3);
            this.tabControlClasses.Name = "tabControlClasses";
            this.tabControlClasses.SelectedIndex = 0;
            this.tabControlClasses.Size = new System.Drawing.Size(618, 217);
            this.tabControlClasses.TabIndex = 0;
            // 
            // tabPageHunter
            // 
            this.tabPageHunter.Controls.Add(this.btnHuAbilitiesOpen);
            this.tabPageHunter.Controls.Add(this.label20);
            this.tabPageHunter.Controls.Add(this.grpHuTypeExtend);
            this.tabPageHunter.Controls.Add(this.lblHuLevel);
            this.tabPageHunter.Controls.Add(this.txtHuLevel);
            this.tabPageHunter.Controls.Add(this.label39);
            this.tabPageHunter.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.tabPageHunter.Location = new System.Drawing.Point(4, 21);
            this.tabPageHunter.Name = "tabPageHunter";
            this.tabPageHunter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHunter.Size = new System.Drawing.Size(610, 192);
            this.tabPageHunter.TabIndex = 0;
            this.tabPageHunter.Text = "Hunter (0)";
            this.tabPageHunter.UseVisualStyleBackColor = true;
            // 
            // btnHuAbilitiesOpen
            // 
            this.btnHuAbilitiesOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuAbilitiesOpen.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuAbilitiesOpen.Location = new System.Drawing.Point(543, 8);
            this.btnHuAbilitiesOpen.Name = "btnHuAbilitiesOpen";
            this.btnHuAbilitiesOpen.Size = new System.Drawing.Size(61, 21);
            this.btnHuAbilitiesOpen.TabIndex = 134;
            this.btnHuAbilitiesOpen.Text = "Abilities";
            this.btnHuAbilitiesOpen.UseVisualStyleBackColor = true;
            this.btnHuAbilitiesOpen.Click += new System.EventHandler(this.btnHuAbilitiesOpen_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(11, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 16);
            this.label20.TabIndex = 133;
            this.label20.Text = "Hunter";
            // 
            // grpHuTypeExtend
            // 
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
            this.grpHuTypeExtend.Location = new System.Drawing.Point(10, 58);
            this.grpHuTypeExtend.Name = "grpHuTypeExtend";
            this.grpHuTypeExtend.Size = new System.Drawing.Size(304, 119);
            this.grpHuTypeExtend.TabIndex = 132;
            this.grpHuTypeExtend.TabStop = false;
            this.grpHuTypeExtend.Text = "Type Extend 0/0";
            // 
            // imgHuTmagRank
            // 
            this.imgHuTmagRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuTmagRank.Location = new System.Drawing.Point(80, 95);
            this.imgHuTmagRank.Name = "imgHuTmagRank";
            this.imgHuTmagRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuTmagRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuTmagRank.TabIndex = 107;
            this.imgHuTmagRank.TabStop = false;
            // 
            // imgHuMachinegunRank
            // 
            this.imgHuMachinegunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuMachinegunRank.Location = new System.Drawing.Point(80, 83);
            this.imgHuMachinegunRank.Name = "imgHuMachinegunRank";
            this.imgHuMachinegunRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuMachinegunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuMachinegunRank.TabIndex = 106;
            this.imgHuMachinegunRank.TabStop = false;
            // 
            // txtHuExpBar
            // 
            this.txtHuExpBar.BackColor = System.Drawing.Color.Red;
            this.txtHuExpBar.Location = new System.Drawing.Point(195, 23);
            this.txtHuExpBar.Name = "txtHuExpBar";
            this.txtHuExpBar.Size = new System.Drawing.Size(87, 8);
            this.txtHuExpBar.TabIndex = 49;
            // 
            // txtHuExp
            // 
            this.txtHuExp.BackColor = System.Drawing.Color.Transparent;
            this.txtHuExp.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHuExp.Location = new System.Drawing.Point(194, 36);
            this.txtHuExp.Name = "txtHuExp";
            this.txtHuExp.Size = new System.Drawing.Size(102, 69);
            this.txtHuExp.TabIndex = 49;
            this.txtHuExp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(159, 20);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 13);
            this.label34.TabIndex = 48;
            this.label34.Text = "EXP";
            // 
            // imgHuHandgunsRank
            // 
            this.imgHuHandgunsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuHandgunsRank.Location = new System.Drawing.Point(80, 71);
            this.imgHuHandgunsRank.Name = "imgHuHandgunsRank";
            this.imgHuHandgunsRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuHandgunsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuHandgunsRank.TabIndex = 105;
            this.imgHuHandgunsRank.TabStop = false;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Gainsboro;
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Location = new System.Drawing.Point(194, 22);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(102, 10);
            this.label36.TabIndex = 50;
            // 
            // imgHuShotgunRank
            // 
            this.imgHuShotgunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuShotgunRank.Location = new System.Drawing.Point(80, 59);
            this.imgHuShotgunRank.Name = "imgHuShotgunRank";
            this.imgHuShotgunRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuShotgunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuShotgunRank.TabIndex = 104;
            this.imgHuShotgunRank.TabStop = false;
            // 
            // imgHuClawRank
            // 
            this.imgHuClawRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuClawRank.Location = new System.Drawing.Point(80, 47);
            this.imgHuClawRank.Name = "imgHuClawRank";
            this.imgHuClawRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuClawRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuClawRank.TabIndex = 103;
            this.imgHuClawRank.TabStop = false;
            // 
            // imgHuDaggersRank
            // 
            this.imgHuDaggersRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuDaggersRank.Location = new System.Drawing.Point(80, 35);
            this.imgHuDaggersRank.Name = "imgHuDaggersRank";
            this.imgHuDaggersRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuDaggersRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuDaggersRank.TabIndex = 102;
            this.imgHuDaggersRank.TabStop = false;
            // 
            // imgHuSpearRank
            // 
            this.imgHuSpearRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuSpearRank.Location = new System.Drawing.Point(80, 23);
            this.imgHuSpearRank.Name = "imgHuSpearRank";
            this.imgHuSpearRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuSpearRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSpearRank.TabIndex = 101;
            this.imgHuSpearRank.TabStop = false;
            // 
            // imgHuWandRank
            // 
            this.imgHuWandRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuWandRank.Location = new System.Drawing.Point(44, 95);
            this.imgHuWandRank.Name = "imgHuWandRank";
            this.imgHuWandRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuWandRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuWandRank.TabIndex = 100;
            this.imgHuWandRank.TabStop = false;
            // 
            // imgHuCardsRank
            // 
            this.imgHuCardsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuCardsRank.Location = new System.Drawing.Point(44, 83);
            this.imgHuCardsRank.Name = "imgHuCardsRank";
            this.imgHuCardsRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuCardsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuCardsRank.TabIndex = 99;
            this.imgHuCardsRank.TabStop = false;
            // 
            // imgHuLaserRank
            // 
            this.imgHuLaserRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuLaserRank.Location = new System.Drawing.Point(44, 71);
            this.imgHuLaserRank.Name = "imgHuLaserRank";
            this.imgHuLaserRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuLaserRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuLaserRank.TabIndex = 98;
            this.imgHuLaserRank.TabStop = false;
            // 
            // imgHuRifleRank
            // 
            this.imgHuRifleRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuRifleRank.Location = new System.Drawing.Point(44, 59);
            this.imgHuRifleRank.Name = "imgHuRifleRank";
            this.imgHuRifleRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuRifleRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuRifleRank.TabIndex = 97;
            this.imgHuRifleRank.TabStop = false;
            // 
            // imgHuDaggerRank
            // 
            this.imgHuDaggerRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuDaggerRank.Location = new System.Drawing.Point(44, 47);
            this.imgHuDaggerRank.Name = "imgHuDaggerRank";
            this.imgHuDaggerRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuDaggerRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuDaggerRank.TabIndex = 96;
            this.imgHuDaggerRank.TabStop = false;
            // 
            // imgHuSabersRank
            // 
            this.imgHuSabersRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuSabersRank.Location = new System.Drawing.Point(44, 35);
            this.imgHuSabersRank.Name = "imgHuSabersRank";
            this.imgHuSabersRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuSabersRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSabersRank.TabIndex = 95;
            this.imgHuSabersRank.TabStop = false;
            // 
            // imgHuKnucklesRank
            // 
            this.imgHuKnucklesRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuKnucklesRank.Location = new System.Drawing.Point(44, 23);
            this.imgHuKnucklesRank.Name = "imgHuKnucklesRank";
            this.imgHuKnucklesRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuKnucklesRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuKnucklesRank.TabIndex = 94;
            this.imgHuKnucklesRank.TabStop = false;
            // 
            // imgHuShieldRank
            // 
            this.imgHuShieldRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuShieldRank.Location = new System.Drawing.Point(116, 95);
            this.imgHuShieldRank.Name = "imgHuShieldRank";
            this.imgHuShieldRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuShieldRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuShieldRank.TabIndex = 93;
            this.imgHuShieldRank.TabStop = false;
            // 
            // imgHuRmagRank
            // 
            this.imgHuRmagRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuRmagRank.Location = new System.Drawing.Point(116, 83);
            this.imgHuRmagRank.Name = "imgHuRmagRank";
            this.imgHuRmagRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuRmagRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuRmagRank.TabIndex = 92;
            this.imgHuRmagRank.TabStop = false;
            // 
            // imgHuHandgunRank
            // 
            this.imgHuHandgunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuHandgunRank.Location = new System.Drawing.Point(116, 71);
            this.imgHuHandgunRank.Name = "imgHuHandgunRank";
            this.imgHuHandgunRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuHandgunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuHandgunRank.TabIndex = 91;
            this.imgHuHandgunRank.TabStop = false;
            // 
            // imgHuLongbowRank
            // 
            this.imgHuLongbowRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuLongbowRank.Location = new System.Drawing.Point(116, 59);
            this.imgHuLongbowRank.Name = "imgHuLongbowRank";
            this.imgHuLongbowRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuLongbowRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuLongbowRank.TabIndex = 90;
            this.imgHuLongbowRank.TabStop = false;
            // 
            // imgHuWhipRank
            // 
            this.imgHuWhipRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuWhipRank.Location = new System.Drawing.Point(116, 47);
            this.imgHuWhipRank.Name = "imgHuWhipRank";
            this.imgHuWhipRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuWhipRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuWhipRank.TabIndex = 89;
            this.imgHuWhipRank.TabStop = false;
            // 
            // imgHuClawsRank
            // 
            this.imgHuClawsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuClawsRank.Location = new System.Drawing.Point(116, 35);
            this.imgHuClawsRank.Name = "imgHuClawsRank";
            this.imgHuClawsRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuClawsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuClawsRank.TabIndex = 88;
            this.imgHuClawsRank.TabStop = false;
            // 
            // imgHuDblSaberRank
            // 
            this.imgHuDblSaberRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgHuDblSaberRank.Location = new System.Drawing.Point(116, 23);
            this.imgHuDblSaberRank.Name = "imgHuDblSaberRank";
            this.imgHuDblSaberRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuDblSaberRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuDblSaberRank.TabIndex = 87;
            this.imgHuDblSaberRank.TabStop = false;
            // 
            // imgHuRodRank
            // 
            this.imgHuRodRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuRodRank.Location = new System.Drawing.Point(8, 95);
            this.imgHuRodRank.Name = "imgHuRodRank";
            this.imgHuRodRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuRodRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuRodRank.TabIndex = 86;
            this.imgHuRodRank.TabStop = false;
            // 
            // imgHuCrossbowRank
            // 
            this.imgHuCrossbowRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuCrossbowRank.Location = new System.Drawing.Point(8, 83);
            this.imgHuCrossbowRank.Name = "imgHuCrossbowRank";
            this.imgHuCrossbowRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuCrossbowRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuCrossbowRank.TabIndex = 85;
            this.imgHuCrossbowRank.TabStop = false;
            // 
            // imgHuGrenadeRank
            // 
            this.imgHuGrenadeRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuGrenadeRank.Location = new System.Drawing.Point(8, 71);
            this.imgHuGrenadeRank.Name = "imgHuGrenadeRank";
            this.imgHuGrenadeRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuGrenadeRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuGrenadeRank.TabIndex = 84;
            this.imgHuGrenadeRank.TabStop = false;
            // 
            // imgHuSlicerRank
            // 
            this.imgHuSlicerRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuSlicerRank.Location = new System.Drawing.Point(8, 59);
            this.imgHuSlicerRank.Name = "imgHuSlicerRank";
            this.imgHuSlicerRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuSlicerRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSlicerRank.TabIndex = 83;
            this.imgHuSlicerRank.TabStop = false;
            // 
            // imgHuSaberRank
            // 
            this.imgHuSaberRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuSaberRank.Location = new System.Drawing.Point(8, 47);
            this.imgHuSaberRank.Name = "imgHuSaberRank";
            this.imgHuSaberRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuSaberRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSaberRank.TabIndex = 82;
            this.imgHuSaberRank.TabStop = false;
            // 
            // imgHuAxeRank
            // 
            this.imgHuAxeRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuAxeRank.Location = new System.Drawing.Point(8, 35);
            this.imgHuAxeRank.Name = "imgHuAxeRank";
            this.imgHuAxeRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuAxeRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuAxeRank.TabIndex = 81;
            this.imgHuAxeRank.TabStop = false;
            // 
            // imgHuSwordRank
            // 
            this.imgHuSwordRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgHuSwordRank.Location = new System.Drawing.Point(8, 23);
            this.imgHuSwordRank.Name = "imgHuSwordRank";
            this.imgHuSwordRank.Size = new System.Drawing.Size(10, 10);
            this.imgHuSwordRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSwordRank.TabIndex = 80;
            this.imgHuSwordRank.TabStop = false;
            // 
            // imgHuRmag
            // 
            this.imgHuRmag.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rmag;
            this.imgHuRmag.Location = new System.Drawing.Point(127, 83);
            this.imgHuRmag.Name = "imgHuRmag";
            this.imgHuRmag.Size = new System.Drawing.Size(10, 10);
            this.imgHuRmag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuRmag.TabIndex = 79;
            this.imgHuRmag.TabStop = false;
            // 
            // imgHuMachinegun
            // 
            this.imgHuMachinegun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_machinegun;
            this.imgHuMachinegun.Location = new System.Drawing.Point(91, 83);
            this.imgHuMachinegun.Name = "imgHuMachinegun";
            this.imgHuMachinegun.Size = new System.Drawing.Size(10, 10);
            this.imgHuMachinegun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuMachinegun.TabIndex = 78;
            this.imgHuMachinegun.TabStop = false;
            // 
            // imgHuCrossbow
            // 
            this.imgHuCrossbow.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_crossbow;
            this.imgHuCrossbow.Location = new System.Drawing.Point(19, 83);
            this.imgHuCrossbow.Name = "imgHuCrossbow";
            this.imgHuCrossbow.Size = new System.Drawing.Size(10, 10);
            this.imgHuCrossbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuCrossbow.TabIndex = 77;
            this.imgHuCrossbow.TabStop = false;
            // 
            // imgHuCards
            // 
            this.imgHuCards.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_card;
            this.imgHuCards.Location = new System.Drawing.Point(55, 83);
            this.imgHuCards.Name = "imgHuCards";
            this.imgHuCards.Size = new System.Drawing.Size(10, 10);
            this.imgHuCards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuCards.TabIndex = 76;
            this.imgHuCards.TabStop = false;
            // 
            // imgHuHandgun
            // 
            this.imgHuHandgun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_handgun;
            this.imgHuHandgun.Location = new System.Drawing.Point(127, 71);
            this.imgHuHandgun.Name = "imgHuHandgun";
            this.imgHuHandgun.Size = new System.Drawing.Size(10, 10);
            this.imgHuHandgun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuHandgun.TabIndex = 75;
            this.imgHuHandgun.TabStop = false;
            // 
            // imgHuHandguns
            // 
            this.imgHuHandguns.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_handguns;
            this.imgHuHandguns.Location = new System.Drawing.Point(91, 71);
            this.imgHuHandguns.Name = "imgHuHandguns";
            this.imgHuHandguns.Size = new System.Drawing.Size(23, 10);
            this.imgHuHandguns.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuHandguns.TabIndex = 74;
            this.imgHuHandguns.TabStop = false;
            // 
            // imgHuGrenade
            // 
            this.imgHuGrenade.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_grenade;
            this.imgHuGrenade.Location = new System.Drawing.Point(19, 71);
            this.imgHuGrenade.Name = "imgHuGrenade";
            this.imgHuGrenade.Size = new System.Drawing.Size(23, 10);
            this.imgHuGrenade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuGrenade.TabIndex = 73;
            this.imgHuGrenade.TabStop = false;
            // 
            // imgHuLaser
            // 
            this.imgHuLaser.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_laser;
            this.imgHuLaser.Location = new System.Drawing.Point(55, 71);
            this.imgHuLaser.Name = "imgHuLaser";
            this.imgHuLaser.Size = new System.Drawing.Size(23, 10);
            this.imgHuLaser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuLaser.TabIndex = 72;
            this.imgHuLaser.TabStop = false;
            // 
            // imgHuLongbow
            // 
            this.imgHuLongbow.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_longbow;
            this.imgHuLongbow.Location = new System.Drawing.Point(127, 59);
            this.imgHuLongbow.Name = "imgHuLongbow";
            this.imgHuLongbow.Size = new System.Drawing.Size(23, 10);
            this.imgHuLongbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuLongbow.TabIndex = 71;
            this.imgHuLongbow.TabStop = false;
            // 
            // imgHuShotgun
            // 
            this.imgHuShotgun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_shotgun;
            this.imgHuShotgun.Location = new System.Drawing.Point(91, 59);
            this.imgHuShotgun.Name = "imgHuShotgun";
            this.imgHuShotgun.Size = new System.Drawing.Size(23, 10);
            this.imgHuShotgun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuShotgun.TabIndex = 70;
            this.imgHuShotgun.TabStop = false;
            // 
            // imgHuSlicer
            // 
            this.imgHuSlicer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_slicer;
            this.imgHuSlicer.Location = new System.Drawing.Point(19, 59);
            this.imgHuSlicer.Name = "imgHuSlicer";
            this.imgHuSlicer.Size = new System.Drawing.Size(10, 10);
            this.imgHuSlicer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSlicer.TabIndex = 69;
            this.imgHuSlicer.TabStop = false;
            // 
            // imgHuRifle
            // 
            this.imgHuRifle.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rifle;
            this.imgHuRifle.Location = new System.Drawing.Point(55, 59);
            this.imgHuRifle.Name = "imgHuRifle";
            this.imgHuRifle.Size = new System.Drawing.Size(23, 10);
            this.imgHuRifle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuRifle.TabIndex = 68;
            this.imgHuRifle.TabStop = false;
            // 
            // imgHuWhip
            // 
            this.imgHuWhip.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_whip;
            this.imgHuWhip.Location = new System.Drawing.Point(127, 47);
            this.imgHuWhip.Name = "imgHuWhip";
            this.imgHuWhip.Size = new System.Drawing.Size(10, 10);
            this.imgHuWhip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuWhip.TabIndex = 67;
            this.imgHuWhip.TabStop = false;
            // 
            // imgHuClaw
            // 
            this.imgHuClaw.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_claw;
            this.imgHuClaw.Location = new System.Drawing.Point(91, 47);
            this.imgHuClaw.Name = "imgHuClaw";
            this.imgHuClaw.Size = new System.Drawing.Size(10, 10);
            this.imgHuClaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuClaw.TabIndex = 66;
            this.imgHuClaw.TabStop = false;
            // 
            // imgHuSaber
            // 
            this.imgHuSaber.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_saber;
            this.imgHuSaber.Location = new System.Drawing.Point(19, 47);
            this.imgHuSaber.Name = "imgHuSaber";
            this.imgHuSaber.Size = new System.Drawing.Size(10, 10);
            this.imgHuSaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSaber.TabIndex = 65;
            this.imgHuSaber.TabStop = false;
            // 
            // imgHuDagger
            // 
            this.imgHuDagger.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_dagger;
            this.imgHuDagger.Location = new System.Drawing.Point(55, 47);
            this.imgHuDagger.Name = "imgHuDagger";
            this.imgHuDagger.Size = new System.Drawing.Size(10, 10);
            this.imgHuDagger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuDagger.TabIndex = 64;
            this.imgHuDagger.TabStop = false;
            // 
            // imgHuShield
            // 
            this.imgHuShield.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_shield;
            this.imgHuShield.Location = new System.Drawing.Point(127, 95);
            this.imgHuShield.Name = "imgHuShield";
            this.imgHuShield.Size = new System.Drawing.Size(10, 10);
            this.imgHuShield.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuShield.TabIndex = 63;
            this.imgHuShield.TabStop = false;
            // 
            // imgHuTmag
            // 
            this.imgHuTmag.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_tmag;
            this.imgHuTmag.Location = new System.Drawing.Point(91, 95);
            this.imgHuTmag.Name = "imgHuTmag";
            this.imgHuTmag.Size = new System.Drawing.Size(10, 10);
            this.imgHuTmag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuTmag.TabIndex = 62;
            this.imgHuTmag.TabStop = false;
            // 
            // imgHuRod
            // 
            this.imgHuRod.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rod;
            this.imgHuRod.Location = new System.Drawing.Point(19, 95);
            this.imgHuRod.Name = "imgHuRod";
            this.imgHuRod.Size = new System.Drawing.Size(23, 10);
            this.imgHuRod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuRod.TabIndex = 61;
            this.imgHuRod.TabStop = false;
            // 
            // imgHuWand
            // 
            this.imgHuWand.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_wand;
            this.imgHuWand.Location = new System.Drawing.Point(55, 95);
            this.imgHuWand.Name = "imgHuWand";
            this.imgHuWand.Size = new System.Drawing.Size(10, 10);
            this.imgHuWand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuWand.TabIndex = 60;
            this.imgHuWand.TabStop = false;
            // 
            // imgHuClaws
            // 
            this.imgHuClaws.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_claws;
            this.imgHuClaws.Location = new System.Drawing.Point(127, 35);
            this.imgHuClaws.Name = "imgHuClaws";
            this.imgHuClaws.Size = new System.Drawing.Size(23, 10);
            this.imgHuClaws.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuClaws.TabIndex = 59;
            this.imgHuClaws.TabStop = false;
            // 
            // imgHuDaggers
            // 
            this.imgHuDaggers.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_daggers;
            this.imgHuDaggers.Location = new System.Drawing.Point(91, 35);
            this.imgHuDaggers.Name = "imgHuDaggers";
            this.imgHuDaggers.Size = new System.Drawing.Size(23, 10);
            this.imgHuDaggers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuDaggers.TabIndex = 58;
            this.imgHuDaggers.TabStop = false;
            // 
            // imgHuAxe
            // 
            this.imgHuAxe.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_axe;
            this.imgHuAxe.Location = new System.Drawing.Point(19, 35);
            this.imgHuAxe.Name = "imgHuAxe";
            this.imgHuAxe.Size = new System.Drawing.Size(23, 10);
            this.imgHuAxe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuAxe.TabIndex = 57;
            this.imgHuAxe.TabStop = false;
            // 
            // imgHuSabers
            // 
            this.imgHuSabers.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sabers;
            this.imgHuSabers.Location = new System.Drawing.Point(55, 35);
            this.imgHuSabers.Name = "imgHuSabers";
            this.imgHuSabers.Size = new System.Drawing.Size(23, 10);
            this.imgHuSabers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSabers.TabIndex = 56;
            this.imgHuSabers.TabStop = false;
            // 
            // imgHuDblSaber
            // 
            this.imgHuDblSaber.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_double_saber;
            this.imgHuDblSaber.Location = new System.Drawing.Point(127, 23);
            this.imgHuDblSaber.Name = "imgHuDblSaber";
            this.imgHuDblSaber.Size = new System.Drawing.Size(23, 10);
            this.imgHuDblSaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuDblSaber.TabIndex = 55;
            this.imgHuDblSaber.TabStop = false;
            // 
            // imgHuKnuckles
            // 
            this.imgHuKnuckles.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_knuckles;
            this.imgHuKnuckles.Location = new System.Drawing.Point(55, 23);
            this.imgHuKnuckles.Name = "imgHuKnuckles";
            this.imgHuKnuckles.Size = new System.Drawing.Size(23, 10);
            this.imgHuKnuckles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuKnuckles.TabIndex = 54;
            this.imgHuKnuckles.TabStop = false;
            // 
            // imgHuSpear
            // 
            this.imgHuSpear.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_spear;
            this.imgHuSpear.Location = new System.Drawing.Point(91, 23);
            this.imgHuSpear.Name = "imgHuSpear";
            this.imgHuSpear.Size = new System.Drawing.Size(23, 10);
            this.imgHuSpear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSpear.TabIndex = 53;
            this.imgHuSpear.TabStop = false;
            // 
            // imgHuSword
            // 
            this.imgHuSword.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sword;
            this.imgHuSword.Location = new System.Drawing.Point(19, 23);
            this.imgHuSword.Name = "imgHuSword";
            this.imgHuSword.Size = new System.Drawing.Size(23, 10);
            this.imgHuSword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgHuSword.TabIndex = 52;
            this.imgHuSword.TabStop = false;
            // 
            // pictureBox231
            // 
            this.pictureBox231.Image = global::pspo2seSaveEditorProgram.Properties.Resources.type_weapons;
            this.pictureBox231.Location = new System.Drawing.Point(19, 23);
            this.pictureBox231.Name = "pictureBox231";
            this.pictureBox231.Size = new System.Drawing.Size(131, 82);
            this.pictureBox231.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox231.TabIndex = 47;
            this.pictureBox231.TabStop = false;
            // 
            // lblHuLevel
            // 
            this.lblHuLevel.AutoSize = true;
            this.lblHuLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHuLevel.Location = new System.Drawing.Point(12, 32);
            this.lblHuLevel.Name = "lblHuLevel";
            this.lblHuLevel.Size = new System.Drawing.Size(37, 13);
            this.lblHuLevel.TabIndex = 130;
            this.lblHuLevel.Text = "Level";
            this.lblHuLevel.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // txtHuLevel
            // 
            this.txtHuLevel.AutoSize = true;
            this.txtHuLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtHuLevel.Location = new System.Drawing.Point(50, 32);
            this.txtHuLevel.Name = "txtHuLevel";
            this.txtHuLevel.Size = new System.Drawing.Size(14, 13);
            this.txtHuLevel.TabIndex = 131;
            this.txtHuLevel.Text = "0";
            this.txtHuLevel.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label39.Location = new System.Drawing.Point(50, 32);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(14, 13);
            this.label39.TabIndex = 129;
            this.label39.Text = "0";
            this.label39.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // tabPageRanger
            // 
            this.tabPageRanger.Controls.Add(this.label10);
            this.tabPageRanger.Controls.Add(this.grpRaTypeExtend);
            this.tabPageRanger.Controls.Add(this.lblRaLevel);
            this.tabPageRanger.Controls.Add(this.txtRaLevel);
            this.tabPageRanger.Controls.Add(this.label35);
            this.tabPageRanger.Controls.Add(this.btnRaAbilitiesOpen);
            this.tabPageRanger.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.tabPageRanger.Location = new System.Drawing.Point(4, 21);
            this.tabPageRanger.Name = "tabPageRanger";
            this.tabPageRanger.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRanger.Size = new System.Drawing.Size(610, 192);
            this.tabPageRanger.TabIndex = 1;
            this.tabPageRanger.Text = "Ranger (0)";
            this.tabPageRanger.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 134;
            this.label10.Text = "Ranger";
            // 
            // grpRaTypeExtend
            // 
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
            this.grpRaTypeExtend.Location = new System.Drawing.Point(10, 58);
            this.grpRaTypeExtend.Name = "grpRaTypeExtend";
            this.grpRaTypeExtend.Size = new System.Drawing.Size(304, 119);
            this.grpRaTypeExtend.TabIndex = 133;
            this.grpRaTypeExtend.TabStop = false;
            this.grpRaTypeExtend.Text = "Type Extend 0/0";
            // 
            // txtRaExp
            // 
            this.txtRaExp.BackColor = System.Drawing.Color.Transparent;
            this.txtRaExp.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaExp.Location = new System.Drawing.Point(194, 36);
            this.txtRaExp.Name = "txtRaExp";
            this.txtRaExp.Size = new System.Drawing.Size(102, 69);
            this.txtRaExp.TabIndex = 108;
            this.txtRaExp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imgRaTmagRank
            // 
            this.imgRaTmagRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaTmagRank.Location = new System.Drawing.Point(80, 95);
            this.imgRaTmagRank.Name = "imgRaTmagRank";
            this.imgRaTmagRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaTmagRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaTmagRank.TabIndex = 107;
            this.imgRaTmagRank.TabStop = false;
            // 
            // imgRaMachinegunRank
            // 
            this.imgRaMachinegunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaMachinegunRank.Location = new System.Drawing.Point(80, 83);
            this.imgRaMachinegunRank.Name = "imgRaMachinegunRank";
            this.imgRaMachinegunRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaMachinegunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaMachinegunRank.TabIndex = 106;
            this.imgRaMachinegunRank.TabStop = false;
            // 
            // txtRaExpBar
            // 
            this.txtRaExpBar.BackColor = System.Drawing.Color.Red;
            this.txtRaExpBar.Location = new System.Drawing.Point(195, 23);
            this.txtRaExpBar.Name = "txtRaExpBar";
            this.txtRaExpBar.Size = new System.Drawing.Size(87, 8);
            this.txtRaExpBar.TabIndex = 49;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(159, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "EXP";
            // 
            // imgRaHandgunsRank
            // 
            this.imgRaHandgunsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaHandgunsRank.Location = new System.Drawing.Point(80, 71);
            this.imgRaHandgunsRank.Name = "imgRaHandgunsRank";
            this.imgRaHandgunsRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaHandgunsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaHandgunsRank.TabIndex = 105;
            this.imgRaHandgunsRank.TabStop = false;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Gainsboro;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Location = new System.Drawing.Point(194, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(102, 10);
            this.label23.TabIndex = 50;
            // 
            // imgRaShotgunRank
            // 
            this.imgRaShotgunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaShotgunRank.Location = new System.Drawing.Point(80, 59);
            this.imgRaShotgunRank.Name = "imgRaShotgunRank";
            this.imgRaShotgunRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaShotgunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaShotgunRank.TabIndex = 104;
            this.imgRaShotgunRank.TabStop = false;
            // 
            // imgRaClawRank
            // 
            this.imgRaClawRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaClawRank.Location = new System.Drawing.Point(80, 47);
            this.imgRaClawRank.Name = "imgRaClawRank";
            this.imgRaClawRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaClawRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaClawRank.TabIndex = 103;
            this.imgRaClawRank.TabStop = false;
            // 
            // imgRaDaggersRank
            // 
            this.imgRaDaggersRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaDaggersRank.Location = new System.Drawing.Point(80, 35);
            this.imgRaDaggersRank.Name = "imgRaDaggersRank";
            this.imgRaDaggersRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaDaggersRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaDaggersRank.TabIndex = 102;
            this.imgRaDaggersRank.TabStop = false;
            // 
            // imgRaSpearRank
            // 
            this.imgRaSpearRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaSpearRank.Location = new System.Drawing.Point(80, 23);
            this.imgRaSpearRank.Name = "imgRaSpearRank";
            this.imgRaSpearRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaSpearRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSpearRank.TabIndex = 101;
            this.imgRaSpearRank.TabStop = false;
            // 
            // imgRaWandRank
            // 
            this.imgRaWandRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaWandRank.Location = new System.Drawing.Point(44, 95);
            this.imgRaWandRank.Name = "imgRaWandRank";
            this.imgRaWandRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaWandRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaWandRank.TabIndex = 100;
            this.imgRaWandRank.TabStop = false;
            // 
            // imgRaCardsRank
            // 
            this.imgRaCardsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaCardsRank.Location = new System.Drawing.Point(44, 83);
            this.imgRaCardsRank.Name = "imgRaCardsRank";
            this.imgRaCardsRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaCardsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaCardsRank.TabIndex = 99;
            this.imgRaCardsRank.TabStop = false;
            // 
            // imgRaLaserRank
            // 
            this.imgRaLaserRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaLaserRank.Location = new System.Drawing.Point(44, 71);
            this.imgRaLaserRank.Name = "imgRaLaserRank";
            this.imgRaLaserRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaLaserRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaLaserRank.TabIndex = 98;
            this.imgRaLaserRank.TabStop = false;
            // 
            // imgRaRifleRank
            // 
            this.imgRaRifleRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaRifleRank.Location = new System.Drawing.Point(44, 59);
            this.imgRaRifleRank.Name = "imgRaRifleRank";
            this.imgRaRifleRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaRifleRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaRifleRank.TabIndex = 97;
            this.imgRaRifleRank.TabStop = false;
            // 
            // imgRaDaggerRank
            // 
            this.imgRaDaggerRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaDaggerRank.Location = new System.Drawing.Point(44, 47);
            this.imgRaDaggerRank.Name = "imgRaDaggerRank";
            this.imgRaDaggerRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaDaggerRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaDaggerRank.TabIndex = 96;
            this.imgRaDaggerRank.TabStop = false;
            // 
            // imgRaSabersRank
            // 
            this.imgRaSabersRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaSabersRank.Location = new System.Drawing.Point(44, 35);
            this.imgRaSabersRank.Name = "imgRaSabersRank";
            this.imgRaSabersRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaSabersRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSabersRank.TabIndex = 95;
            this.imgRaSabersRank.TabStop = false;
            // 
            // imgRaKnucklesRank
            // 
            this.imgRaKnucklesRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaKnucklesRank.Location = new System.Drawing.Point(44, 23);
            this.imgRaKnucklesRank.Name = "imgRaKnucklesRank";
            this.imgRaKnucklesRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaKnucklesRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaKnucklesRank.TabIndex = 94;
            this.imgRaKnucklesRank.TabStop = false;
            // 
            // imgRaShieldRank
            // 
            this.imgRaShieldRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaShieldRank.Location = new System.Drawing.Point(116, 95);
            this.imgRaShieldRank.Name = "imgRaShieldRank";
            this.imgRaShieldRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaShieldRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaShieldRank.TabIndex = 93;
            this.imgRaShieldRank.TabStop = false;
            // 
            // imgRaRmagRank
            // 
            this.imgRaRmagRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaRmagRank.Location = new System.Drawing.Point(116, 83);
            this.imgRaRmagRank.Name = "imgRaRmagRank";
            this.imgRaRmagRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaRmagRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaRmagRank.TabIndex = 92;
            this.imgRaRmagRank.TabStop = false;
            // 
            // imgRaHandgunRank
            // 
            this.imgRaHandgunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaHandgunRank.Location = new System.Drawing.Point(116, 71);
            this.imgRaHandgunRank.Name = "imgRaHandgunRank";
            this.imgRaHandgunRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaHandgunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaHandgunRank.TabIndex = 91;
            this.imgRaHandgunRank.TabStop = false;
            // 
            // imgRaLongbowRank
            // 
            this.imgRaLongbowRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaLongbowRank.Location = new System.Drawing.Point(116, 59);
            this.imgRaLongbowRank.Name = "imgRaLongbowRank";
            this.imgRaLongbowRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaLongbowRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaLongbowRank.TabIndex = 90;
            this.imgRaLongbowRank.TabStop = false;
            // 
            // imgRaWhipRank
            // 
            this.imgRaWhipRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaWhipRank.Location = new System.Drawing.Point(116, 47);
            this.imgRaWhipRank.Name = "imgRaWhipRank";
            this.imgRaWhipRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaWhipRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaWhipRank.TabIndex = 89;
            this.imgRaWhipRank.TabStop = false;
            // 
            // imgRaClawsRank
            // 
            this.imgRaClawsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaClawsRank.Location = new System.Drawing.Point(116, 35);
            this.imgRaClawsRank.Name = "imgRaClawsRank";
            this.imgRaClawsRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaClawsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaClawsRank.TabIndex = 88;
            this.imgRaClawsRank.TabStop = false;
            // 
            // imgRaDblSaberRank
            // 
            this.imgRaDblSaberRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgRaDblSaberRank.Location = new System.Drawing.Point(116, 23);
            this.imgRaDblSaberRank.Name = "imgRaDblSaberRank";
            this.imgRaDblSaberRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaDblSaberRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaDblSaberRank.TabIndex = 87;
            this.imgRaDblSaberRank.TabStop = false;
            // 
            // imgRaRodRank
            // 
            this.imgRaRodRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaRodRank.Location = new System.Drawing.Point(8, 95);
            this.imgRaRodRank.Name = "imgRaRodRank";
            this.imgRaRodRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaRodRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaRodRank.TabIndex = 86;
            this.imgRaRodRank.TabStop = false;
            // 
            // imgRaCrossbowRank
            // 
            this.imgRaCrossbowRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaCrossbowRank.Location = new System.Drawing.Point(8, 83);
            this.imgRaCrossbowRank.Name = "imgRaCrossbowRank";
            this.imgRaCrossbowRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaCrossbowRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaCrossbowRank.TabIndex = 85;
            this.imgRaCrossbowRank.TabStop = false;
            // 
            // imgRaGrenadeRank
            // 
            this.imgRaGrenadeRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaGrenadeRank.Location = new System.Drawing.Point(8, 71);
            this.imgRaGrenadeRank.Name = "imgRaGrenadeRank";
            this.imgRaGrenadeRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaGrenadeRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaGrenadeRank.TabIndex = 84;
            this.imgRaGrenadeRank.TabStop = false;
            // 
            // imgRaSlicerRank
            // 
            this.imgRaSlicerRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaSlicerRank.Location = new System.Drawing.Point(8, 59);
            this.imgRaSlicerRank.Name = "imgRaSlicerRank";
            this.imgRaSlicerRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaSlicerRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSlicerRank.TabIndex = 83;
            this.imgRaSlicerRank.TabStop = false;
            // 
            // imgRaSaberRank
            // 
            this.imgRaSaberRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaSaberRank.Location = new System.Drawing.Point(8, 47);
            this.imgRaSaberRank.Name = "imgRaSaberRank";
            this.imgRaSaberRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaSaberRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSaberRank.TabIndex = 82;
            this.imgRaSaberRank.TabStop = false;
            // 
            // imgRaAxeRank
            // 
            this.imgRaAxeRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaAxeRank.Location = new System.Drawing.Point(8, 35);
            this.imgRaAxeRank.Name = "imgRaAxeRank";
            this.imgRaAxeRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaAxeRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaAxeRank.TabIndex = 81;
            this.imgRaAxeRank.TabStop = false;
            // 
            // imgRaSwordRank
            // 
            this.imgRaSwordRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgRaSwordRank.Location = new System.Drawing.Point(8, 23);
            this.imgRaSwordRank.Name = "imgRaSwordRank";
            this.imgRaSwordRank.Size = new System.Drawing.Size(10, 10);
            this.imgRaSwordRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSwordRank.TabIndex = 80;
            this.imgRaSwordRank.TabStop = false;
            // 
            // imgRaRmag
            // 
            this.imgRaRmag.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rmag;
            this.imgRaRmag.Location = new System.Drawing.Point(127, 83);
            this.imgRaRmag.Name = "imgRaRmag";
            this.imgRaRmag.Size = new System.Drawing.Size(10, 10);
            this.imgRaRmag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaRmag.TabIndex = 79;
            this.imgRaRmag.TabStop = false;
            // 
            // imgRaMachinegun
            // 
            this.imgRaMachinegun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_machinegun;
            this.imgRaMachinegun.Location = new System.Drawing.Point(91, 83);
            this.imgRaMachinegun.Name = "imgRaMachinegun";
            this.imgRaMachinegun.Size = new System.Drawing.Size(10, 10);
            this.imgRaMachinegun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaMachinegun.TabIndex = 78;
            this.imgRaMachinegun.TabStop = false;
            // 
            // imgRaCrossbow
            // 
            this.imgRaCrossbow.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_crossbow;
            this.imgRaCrossbow.Location = new System.Drawing.Point(19, 83);
            this.imgRaCrossbow.Name = "imgRaCrossbow";
            this.imgRaCrossbow.Size = new System.Drawing.Size(10, 10);
            this.imgRaCrossbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaCrossbow.TabIndex = 77;
            this.imgRaCrossbow.TabStop = false;
            // 
            // imgRaCards
            // 
            this.imgRaCards.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_card;
            this.imgRaCards.Location = new System.Drawing.Point(55, 83);
            this.imgRaCards.Name = "imgRaCards";
            this.imgRaCards.Size = new System.Drawing.Size(10, 10);
            this.imgRaCards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaCards.TabIndex = 76;
            this.imgRaCards.TabStop = false;
            // 
            // imgRaHandgun
            // 
            this.imgRaHandgun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_handgun;
            this.imgRaHandgun.Location = new System.Drawing.Point(127, 71);
            this.imgRaHandgun.Name = "imgRaHandgun";
            this.imgRaHandgun.Size = new System.Drawing.Size(10, 10);
            this.imgRaHandgun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaHandgun.TabIndex = 75;
            this.imgRaHandgun.TabStop = false;
            // 
            // imgRaHandguns
            // 
            this.imgRaHandguns.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_handguns;
            this.imgRaHandguns.Location = new System.Drawing.Point(91, 71);
            this.imgRaHandguns.Name = "imgRaHandguns";
            this.imgRaHandguns.Size = new System.Drawing.Size(23, 10);
            this.imgRaHandguns.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaHandguns.TabIndex = 74;
            this.imgRaHandguns.TabStop = false;
            // 
            // imgRaGrenade
            // 
            this.imgRaGrenade.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_grenade;
            this.imgRaGrenade.Location = new System.Drawing.Point(19, 71);
            this.imgRaGrenade.Name = "imgRaGrenade";
            this.imgRaGrenade.Size = new System.Drawing.Size(23, 10);
            this.imgRaGrenade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaGrenade.TabIndex = 73;
            this.imgRaGrenade.TabStop = false;
            // 
            // imgRaLaser
            // 
            this.imgRaLaser.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_laser;
            this.imgRaLaser.Location = new System.Drawing.Point(55, 71);
            this.imgRaLaser.Name = "imgRaLaser";
            this.imgRaLaser.Size = new System.Drawing.Size(23, 10);
            this.imgRaLaser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaLaser.TabIndex = 72;
            this.imgRaLaser.TabStop = false;
            // 
            // imgRaLongbow
            // 
            this.imgRaLongbow.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_longbow;
            this.imgRaLongbow.Location = new System.Drawing.Point(127, 59);
            this.imgRaLongbow.Name = "imgRaLongbow";
            this.imgRaLongbow.Size = new System.Drawing.Size(23, 10);
            this.imgRaLongbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaLongbow.TabIndex = 71;
            this.imgRaLongbow.TabStop = false;
            // 
            // imgRaShotgun
            // 
            this.imgRaShotgun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_shotgun;
            this.imgRaShotgun.Location = new System.Drawing.Point(91, 59);
            this.imgRaShotgun.Name = "imgRaShotgun";
            this.imgRaShotgun.Size = new System.Drawing.Size(23, 10);
            this.imgRaShotgun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaShotgun.TabIndex = 70;
            this.imgRaShotgun.TabStop = false;
            // 
            // imgRaSlicer
            // 
            this.imgRaSlicer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_slicer;
            this.imgRaSlicer.Location = new System.Drawing.Point(19, 59);
            this.imgRaSlicer.Name = "imgRaSlicer";
            this.imgRaSlicer.Size = new System.Drawing.Size(10, 10);
            this.imgRaSlicer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSlicer.TabIndex = 69;
            this.imgRaSlicer.TabStop = false;
            // 
            // imgRaRifle
            // 
            this.imgRaRifle.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rifle;
            this.imgRaRifle.Location = new System.Drawing.Point(55, 59);
            this.imgRaRifle.Name = "imgRaRifle";
            this.imgRaRifle.Size = new System.Drawing.Size(23, 10);
            this.imgRaRifle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaRifle.TabIndex = 68;
            this.imgRaRifle.TabStop = false;
            // 
            // imgRaWhip
            // 
            this.imgRaWhip.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_whip;
            this.imgRaWhip.Location = new System.Drawing.Point(127, 47);
            this.imgRaWhip.Name = "imgRaWhip";
            this.imgRaWhip.Size = new System.Drawing.Size(10, 10);
            this.imgRaWhip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaWhip.TabIndex = 67;
            this.imgRaWhip.TabStop = false;
            // 
            // imgRaClaw
            // 
            this.imgRaClaw.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_claw;
            this.imgRaClaw.Location = new System.Drawing.Point(91, 47);
            this.imgRaClaw.Name = "imgRaClaw";
            this.imgRaClaw.Size = new System.Drawing.Size(10, 10);
            this.imgRaClaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaClaw.TabIndex = 66;
            this.imgRaClaw.TabStop = false;
            // 
            // imgRaSaber
            // 
            this.imgRaSaber.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_saber;
            this.imgRaSaber.Location = new System.Drawing.Point(19, 47);
            this.imgRaSaber.Name = "imgRaSaber";
            this.imgRaSaber.Size = new System.Drawing.Size(10, 10);
            this.imgRaSaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSaber.TabIndex = 65;
            this.imgRaSaber.TabStop = false;
            // 
            // imgRaDagger
            // 
            this.imgRaDagger.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_dagger;
            this.imgRaDagger.Location = new System.Drawing.Point(55, 47);
            this.imgRaDagger.Name = "imgRaDagger";
            this.imgRaDagger.Size = new System.Drawing.Size(10, 10);
            this.imgRaDagger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaDagger.TabIndex = 64;
            this.imgRaDagger.TabStop = false;
            // 
            // imgRaShield
            // 
            this.imgRaShield.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_shield;
            this.imgRaShield.Location = new System.Drawing.Point(127, 95);
            this.imgRaShield.Name = "imgRaShield";
            this.imgRaShield.Size = new System.Drawing.Size(10, 10);
            this.imgRaShield.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaShield.TabIndex = 63;
            this.imgRaShield.TabStop = false;
            // 
            // imgRaTmag
            // 
            this.imgRaTmag.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_tmag;
            this.imgRaTmag.Location = new System.Drawing.Point(91, 95);
            this.imgRaTmag.Name = "imgRaTmag";
            this.imgRaTmag.Size = new System.Drawing.Size(10, 10);
            this.imgRaTmag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaTmag.TabIndex = 62;
            this.imgRaTmag.TabStop = false;
            // 
            // imgRaRod
            // 
            this.imgRaRod.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rod;
            this.imgRaRod.Location = new System.Drawing.Point(19, 95);
            this.imgRaRod.Name = "imgRaRod";
            this.imgRaRod.Size = new System.Drawing.Size(23, 10);
            this.imgRaRod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaRod.TabIndex = 61;
            this.imgRaRod.TabStop = false;
            // 
            // imgRaWand
            // 
            this.imgRaWand.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_wand;
            this.imgRaWand.Location = new System.Drawing.Point(55, 95);
            this.imgRaWand.Name = "imgRaWand";
            this.imgRaWand.Size = new System.Drawing.Size(10, 10);
            this.imgRaWand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaWand.TabIndex = 60;
            this.imgRaWand.TabStop = false;
            // 
            // imgRaClaws
            // 
            this.imgRaClaws.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_claws;
            this.imgRaClaws.Location = new System.Drawing.Point(127, 35);
            this.imgRaClaws.Name = "imgRaClaws";
            this.imgRaClaws.Size = new System.Drawing.Size(23, 10);
            this.imgRaClaws.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaClaws.TabIndex = 59;
            this.imgRaClaws.TabStop = false;
            // 
            // imgRaDaggers
            // 
            this.imgRaDaggers.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_daggers;
            this.imgRaDaggers.Location = new System.Drawing.Point(91, 35);
            this.imgRaDaggers.Name = "imgRaDaggers";
            this.imgRaDaggers.Size = new System.Drawing.Size(23, 10);
            this.imgRaDaggers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaDaggers.TabIndex = 58;
            this.imgRaDaggers.TabStop = false;
            // 
            // imgRaAxe
            // 
            this.imgRaAxe.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_axe;
            this.imgRaAxe.Location = new System.Drawing.Point(19, 35);
            this.imgRaAxe.Name = "imgRaAxe";
            this.imgRaAxe.Size = new System.Drawing.Size(23, 10);
            this.imgRaAxe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaAxe.TabIndex = 57;
            this.imgRaAxe.TabStop = false;
            // 
            // imgRaSabers
            // 
            this.imgRaSabers.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sabers;
            this.imgRaSabers.Location = new System.Drawing.Point(55, 35);
            this.imgRaSabers.Name = "imgRaSabers";
            this.imgRaSabers.Size = new System.Drawing.Size(23, 10);
            this.imgRaSabers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSabers.TabIndex = 56;
            this.imgRaSabers.TabStop = false;
            // 
            // imgRaDblSaber
            // 
            this.imgRaDblSaber.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_double_saber;
            this.imgRaDblSaber.Location = new System.Drawing.Point(127, 23);
            this.imgRaDblSaber.Name = "imgRaDblSaber";
            this.imgRaDblSaber.Size = new System.Drawing.Size(23, 10);
            this.imgRaDblSaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaDblSaber.TabIndex = 55;
            this.imgRaDblSaber.TabStop = false;
            // 
            // imgRaKnuckles
            // 
            this.imgRaKnuckles.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_knuckles;
            this.imgRaKnuckles.Location = new System.Drawing.Point(55, 23);
            this.imgRaKnuckles.Name = "imgRaKnuckles";
            this.imgRaKnuckles.Size = new System.Drawing.Size(23, 10);
            this.imgRaKnuckles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaKnuckles.TabIndex = 54;
            this.imgRaKnuckles.TabStop = false;
            // 
            // imgRaSpear
            // 
            this.imgRaSpear.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_spear;
            this.imgRaSpear.Location = new System.Drawing.Point(91, 23);
            this.imgRaSpear.Name = "imgRaSpear";
            this.imgRaSpear.Size = new System.Drawing.Size(23, 10);
            this.imgRaSpear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSpear.TabIndex = 53;
            this.imgRaSpear.TabStop = false;
            // 
            // imgRaSword
            // 
            this.imgRaSword.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sword;
            this.imgRaSword.Location = new System.Drawing.Point(19, 23);
            this.imgRaSword.Name = "imgRaSword";
            this.imgRaSword.Size = new System.Drawing.Size(23, 10);
            this.imgRaSword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRaSword.TabIndex = 52;
            this.imgRaSword.TabStop = false;
            // 
            // pictureBox174
            // 
            this.pictureBox174.Image = global::pspo2seSaveEditorProgram.Properties.Resources.type_weapons;
            this.pictureBox174.Location = new System.Drawing.Point(19, 23);
            this.pictureBox174.Name = "pictureBox174";
            this.pictureBox174.Size = new System.Drawing.Size(131, 82);
            this.pictureBox174.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox174.TabIndex = 47;
            this.pictureBox174.TabStop = false;
            // 
            // lblRaLevel
            // 
            this.lblRaLevel.AutoSize = true;
            this.lblRaLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRaLevel.Location = new System.Drawing.Point(12, 32);
            this.lblRaLevel.Name = "lblRaLevel";
            this.lblRaLevel.Size = new System.Drawing.Size(37, 13);
            this.lblRaLevel.TabIndex = 131;
            this.lblRaLevel.Text = "Level";
            this.lblRaLevel.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // txtRaLevel
            // 
            this.txtRaLevel.AutoSize = true;
            this.txtRaLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtRaLevel.Location = new System.Drawing.Point(50, 32);
            this.txtRaLevel.Name = "txtRaLevel";
            this.txtRaLevel.Size = new System.Drawing.Size(14, 13);
            this.txtRaLevel.TabIndex = 132;
            this.txtRaLevel.Text = "0";
            this.txtRaLevel.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label35.Location = new System.Drawing.Point(50, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(14, 13);
            this.label35.TabIndex = 130;
            this.label35.Text = "0";
            this.label35.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // btnRaAbilitiesOpen
            // 
            this.btnRaAbilitiesOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRaAbilitiesOpen.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRaAbilitiesOpen.Location = new System.Drawing.Point(543, 8);
            this.btnRaAbilitiesOpen.Name = "btnRaAbilitiesOpen";
            this.btnRaAbilitiesOpen.Size = new System.Drawing.Size(61, 21);
            this.btnRaAbilitiesOpen.TabIndex = 135;
            this.btnRaAbilitiesOpen.Text = "Abilities";
            this.btnRaAbilitiesOpen.UseVisualStyleBackColor = true;
            this.btnRaAbilitiesOpen.Click += new System.EventHandler(this.btnRaAbilitiesOpen_Click);
            // 
            // tabPageForce
            // 
            this.tabPageForce.Controls.Add(this.label8);
            this.tabPageForce.Controls.Add(this.grpFoTypeExtend);
            this.tabPageForce.Controls.Add(this.lblFoLevel);
            this.tabPageForce.Controls.Add(this.txtFoLevel);
            this.tabPageForce.Controls.Add(this.btnFoAbilitiesOpen);
            this.tabPageForce.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.tabPageForce.Location = new System.Drawing.Point(4, 21);
            this.tabPageForce.Name = "tabPageForce";
            this.tabPageForce.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageForce.Size = new System.Drawing.Size(610, 192);
            this.tabPageForce.TabIndex = 2;
            this.tabPageForce.Text = "Force (0)";
            this.tabPageForce.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 138;
            this.label8.Text = "Force";
            // 
            // grpFoTypeExtend
            // 
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
            this.grpFoTypeExtend.Location = new System.Drawing.Point(10, 58);
            this.grpFoTypeExtend.Name = "grpFoTypeExtend";
            this.grpFoTypeExtend.Size = new System.Drawing.Size(304, 119);
            this.grpFoTypeExtend.TabIndex = 137;
            this.grpFoTypeExtend.TabStop = false;
            this.grpFoTypeExtend.Text = "Type Extend 0/0";
            // 
            // txtFoExp
            // 
            this.txtFoExp.BackColor = System.Drawing.Color.Transparent;
            this.txtFoExp.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoExp.Location = new System.Drawing.Point(194, 36);
            this.txtFoExp.Name = "txtFoExp";
            this.txtFoExp.Size = new System.Drawing.Size(102, 69);
            this.txtFoExp.TabIndex = 109;
            this.txtFoExp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imgFoTmagRank
            // 
            this.imgFoTmagRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoTmagRank.Location = new System.Drawing.Point(80, 95);
            this.imgFoTmagRank.Name = "imgFoTmagRank";
            this.imgFoTmagRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoTmagRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoTmagRank.TabIndex = 107;
            this.imgFoTmagRank.TabStop = false;
            // 
            // imgFoMachinegunRank
            // 
            this.imgFoMachinegunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoMachinegunRank.Location = new System.Drawing.Point(80, 83);
            this.imgFoMachinegunRank.Name = "imgFoMachinegunRank";
            this.imgFoMachinegunRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoMachinegunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoMachinegunRank.TabIndex = 106;
            this.imgFoMachinegunRank.TabStop = false;
            // 
            // txtFoExpBar
            // 
            this.txtFoExpBar.BackColor = System.Drawing.Color.Red;
            this.txtFoExpBar.Location = new System.Drawing.Point(195, 23);
            this.txtFoExpBar.Name = "txtFoExpBar";
            this.txtFoExpBar.Size = new System.Drawing.Size(87, 8);
            this.txtFoExpBar.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(159, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "EXP";
            // 
            // imgFoHandgunsRank
            // 
            this.imgFoHandgunsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoHandgunsRank.Location = new System.Drawing.Point(80, 71);
            this.imgFoHandgunsRank.Name = "imgFoHandgunsRank";
            this.imgFoHandgunsRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoHandgunsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoHandgunsRank.TabIndex = 105;
            this.imgFoHandgunsRank.TabStop = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Gainsboro;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(194, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 10);
            this.label15.TabIndex = 50;
            // 
            // imgFoShotgunRank
            // 
            this.imgFoShotgunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoShotgunRank.Location = new System.Drawing.Point(80, 59);
            this.imgFoShotgunRank.Name = "imgFoShotgunRank";
            this.imgFoShotgunRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoShotgunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoShotgunRank.TabIndex = 104;
            this.imgFoShotgunRank.TabStop = false;
            // 
            // imgFoClawRank
            // 
            this.imgFoClawRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoClawRank.Location = new System.Drawing.Point(80, 47);
            this.imgFoClawRank.Name = "imgFoClawRank";
            this.imgFoClawRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoClawRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoClawRank.TabIndex = 103;
            this.imgFoClawRank.TabStop = false;
            // 
            // imgFoDaggersRank
            // 
            this.imgFoDaggersRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoDaggersRank.Location = new System.Drawing.Point(80, 35);
            this.imgFoDaggersRank.Name = "imgFoDaggersRank";
            this.imgFoDaggersRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoDaggersRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoDaggersRank.TabIndex = 102;
            this.imgFoDaggersRank.TabStop = false;
            // 
            // imgFoSpearRank
            // 
            this.imgFoSpearRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoSpearRank.Location = new System.Drawing.Point(80, 23);
            this.imgFoSpearRank.Name = "imgFoSpearRank";
            this.imgFoSpearRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoSpearRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSpearRank.TabIndex = 101;
            this.imgFoSpearRank.TabStop = false;
            // 
            // imgFoWandRank
            // 
            this.imgFoWandRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoWandRank.Location = new System.Drawing.Point(44, 95);
            this.imgFoWandRank.Name = "imgFoWandRank";
            this.imgFoWandRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoWandRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoWandRank.TabIndex = 100;
            this.imgFoWandRank.TabStop = false;
            // 
            // imgFoCardsRank
            // 
            this.imgFoCardsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoCardsRank.Location = new System.Drawing.Point(44, 83);
            this.imgFoCardsRank.Name = "imgFoCardsRank";
            this.imgFoCardsRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoCardsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoCardsRank.TabIndex = 99;
            this.imgFoCardsRank.TabStop = false;
            // 
            // imgFoLaserRank
            // 
            this.imgFoLaserRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoLaserRank.Location = new System.Drawing.Point(44, 71);
            this.imgFoLaserRank.Name = "imgFoLaserRank";
            this.imgFoLaserRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoLaserRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoLaserRank.TabIndex = 98;
            this.imgFoLaserRank.TabStop = false;
            // 
            // imgFoRifleRank
            // 
            this.imgFoRifleRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoRifleRank.Location = new System.Drawing.Point(44, 59);
            this.imgFoRifleRank.Name = "imgFoRifleRank";
            this.imgFoRifleRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoRifleRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoRifleRank.TabIndex = 97;
            this.imgFoRifleRank.TabStop = false;
            // 
            // imgFoDaggerRank
            // 
            this.imgFoDaggerRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoDaggerRank.Location = new System.Drawing.Point(44, 47);
            this.imgFoDaggerRank.Name = "imgFoDaggerRank";
            this.imgFoDaggerRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoDaggerRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoDaggerRank.TabIndex = 96;
            this.imgFoDaggerRank.TabStop = false;
            // 
            // imgFoSabersRank
            // 
            this.imgFoSabersRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoSabersRank.Location = new System.Drawing.Point(44, 35);
            this.imgFoSabersRank.Name = "imgFoSabersRank";
            this.imgFoSabersRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoSabersRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSabersRank.TabIndex = 95;
            this.imgFoSabersRank.TabStop = false;
            // 
            // imgFoKnucklesRank
            // 
            this.imgFoKnucklesRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoKnucklesRank.Location = new System.Drawing.Point(44, 23);
            this.imgFoKnucklesRank.Name = "imgFoKnucklesRank";
            this.imgFoKnucklesRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoKnucklesRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoKnucklesRank.TabIndex = 94;
            this.imgFoKnucklesRank.TabStop = false;
            // 
            // imgFoShieldRank
            // 
            this.imgFoShieldRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoShieldRank.Location = new System.Drawing.Point(116, 95);
            this.imgFoShieldRank.Name = "imgFoShieldRank";
            this.imgFoShieldRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoShieldRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoShieldRank.TabIndex = 93;
            this.imgFoShieldRank.TabStop = false;
            // 
            // imgFoRmagRank
            // 
            this.imgFoRmagRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoRmagRank.Location = new System.Drawing.Point(116, 83);
            this.imgFoRmagRank.Name = "imgFoRmagRank";
            this.imgFoRmagRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoRmagRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoRmagRank.TabIndex = 92;
            this.imgFoRmagRank.TabStop = false;
            // 
            // imgFoHandgunRank
            // 
            this.imgFoHandgunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoHandgunRank.Location = new System.Drawing.Point(116, 71);
            this.imgFoHandgunRank.Name = "imgFoHandgunRank";
            this.imgFoHandgunRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoHandgunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoHandgunRank.TabIndex = 91;
            this.imgFoHandgunRank.TabStop = false;
            // 
            // imgFoLongbowRank
            // 
            this.imgFoLongbowRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoLongbowRank.Location = new System.Drawing.Point(116, 59);
            this.imgFoLongbowRank.Name = "imgFoLongbowRank";
            this.imgFoLongbowRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoLongbowRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoLongbowRank.TabIndex = 90;
            this.imgFoLongbowRank.TabStop = false;
            // 
            // imgFoWhipRank
            // 
            this.imgFoWhipRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoWhipRank.Location = new System.Drawing.Point(116, 47);
            this.imgFoWhipRank.Name = "imgFoWhipRank";
            this.imgFoWhipRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoWhipRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoWhipRank.TabIndex = 89;
            this.imgFoWhipRank.TabStop = false;
            // 
            // imgFoClawsRank
            // 
            this.imgFoClawsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoClawsRank.Location = new System.Drawing.Point(116, 35);
            this.imgFoClawsRank.Name = "imgFoClawsRank";
            this.imgFoClawsRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoClawsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoClawsRank.TabIndex = 88;
            this.imgFoClawsRank.TabStop = false;
            // 
            // imgFoDblSaberRank
            // 
            this.imgFoDblSaberRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgFoDblSaberRank.Location = new System.Drawing.Point(116, 23);
            this.imgFoDblSaberRank.Name = "imgFoDblSaberRank";
            this.imgFoDblSaberRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoDblSaberRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoDblSaberRank.TabIndex = 87;
            this.imgFoDblSaberRank.TabStop = false;
            // 
            // imgFoRodRank
            // 
            this.imgFoRodRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoRodRank.Location = new System.Drawing.Point(8, 95);
            this.imgFoRodRank.Name = "imgFoRodRank";
            this.imgFoRodRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoRodRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoRodRank.TabIndex = 86;
            this.imgFoRodRank.TabStop = false;
            // 
            // imgFoCrossbowRank
            // 
            this.imgFoCrossbowRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoCrossbowRank.Location = new System.Drawing.Point(8, 83);
            this.imgFoCrossbowRank.Name = "imgFoCrossbowRank";
            this.imgFoCrossbowRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoCrossbowRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoCrossbowRank.TabIndex = 85;
            this.imgFoCrossbowRank.TabStop = false;
            // 
            // imgFoGrenadeRank
            // 
            this.imgFoGrenadeRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoGrenadeRank.Location = new System.Drawing.Point(8, 71);
            this.imgFoGrenadeRank.Name = "imgFoGrenadeRank";
            this.imgFoGrenadeRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoGrenadeRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoGrenadeRank.TabIndex = 84;
            this.imgFoGrenadeRank.TabStop = false;
            // 
            // imgFoSlicerRank
            // 
            this.imgFoSlicerRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoSlicerRank.Location = new System.Drawing.Point(8, 59);
            this.imgFoSlicerRank.Name = "imgFoSlicerRank";
            this.imgFoSlicerRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoSlicerRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSlicerRank.TabIndex = 83;
            this.imgFoSlicerRank.TabStop = false;
            // 
            // imgFoSaberRank
            // 
            this.imgFoSaberRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoSaberRank.Location = new System.Drawing.Point(8, 47);
            this.imgFoSaberRank.Name = "imgFoSaberRank";
            this.imgFoSaberRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoSaberRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSaberRank.TabIndex = 82;
            this.imgFoSaberRank.TabStop = false;
            // 
            // imgFoAxeRank
            // 
            this.imgFoAxeRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoAxeRank.Location = new System.Drawing.Point(8, 35);
            this.imgFoAxeRank.Name = "imgFoAxeRank";
            this.imgFoAxeRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoAxeRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoAxeRank.TabIndex = 81;
            this.imgFoAxeRank.TabStop = false;
            // 
            // imgFoSwordRank
            // 
            this.imgFoSwordRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgFoSwordRank.Location = new System.Drawing.Point(8, 23);
            this.imgFoSwordRank.Name = "imgFoSwordRank";
            this.imgFoSwordRank.Size = new System.Drawing.Size(10, 10);
            this.imgFoSwordRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSwordRank.TabIndex = 80;
            this.imgFoSwordRank.TabStop = false;
            // 
            // imgFoRmag
            // 
            this.imgFoRmag.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rmag;
            this.imgFoRmag.Location = new System.Drawing.Point(127, 83);
            this.imgFoRmag.Name = "imgFoRmag";
            this.imgFoRmag.Size = new System.Drawing.Size(10, 10);
            this.imgFoRmag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoRmag.TabIndex = 79;
            this.imgFoRmag.TabStop = false;
            // 
            // imgFoMachinegun
            // 
            this.imgFoMachinegun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_machinegun;
            this.imgFoMachinegun.Location = new System.Drawing.Point(91, 83);
            this.imgFoMachinegun.Name = "imgFoMachinegun";
            this.imgFoMachinegun.Size = new System.Drawing.Size(10, 10);
            this.imgFoMachinegun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoMachinegun.TabIndex = 78;
            this.imgFoMachinegun.TabStop = false;
            // 
            // imgFoCrossbow
            // 
            this.imgFoCrossbow.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_crossbow;
            this.imgFoCrossbow.Location = new System.Drawing.Point(19, 83);
            this.imgFoCrossbow.Name = "imgFoCrossbow";
            this.imgFoCrossbow.Size = new System.Drawing.Size(10, 10);
            this.imgFoCrossbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoCrossbow.TabIndex = 77;
            this.imgFoCrossbow.TabStop = false;
            // 
            // imgFoCards
            // 
            this.imgFoCards.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_card;
            this.imgFoCards.Location = new System.Drawing.Point(55, 83);
            this.imgFoCards.Name = "imgFoCards";
            this.imgFoCards.Size = new System.Drawing.Size(10, 10);
            this.imgFoCards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoCards.TabIndex = 76;
            this.imgFoCards.TabStop = false;
            // 
            // imgFoHandgun
            // 
            this.imgFoHandgun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_handgun;
            this.imgFoHandgun.Location = new System.Drawing.Point(127, 71);
            this.imgFoHandgun.Name = "imgFoHandgun";
            this.imgFoHandgun.Size = new System.Drawing.Size(10, 10);
            this.imgFoHandgun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoHandgun.TabIndex = 75;
            this.imgFoHandgun.TabStop = false;
            // 
            // imgFoHandguns
            // 
            this.imgFoHandguns.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_handguns;
            this.imgFoHandguns.Location = new System.Drawing.Point(91, 71);
            this.imgFoHandguns.Name = "imgFoHandguns";
            this.imgFoHandguns.Size = new System.Drawing.Size(23, 10);
            this.imgFoHandguns.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoHandguns.TabIndex = 74;
            this.imgFoHandguns.TabStop = false;
            // 
            // imgFoGrenade
            // 
            this.imgFoGrenade.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_grenade;
            this.imgFoGrenade.Location = new System.Drawing.Point(19, 71);
            this.imgFoGrenade.Name = "imgFoGrenade";
            this.imgFoGrenade.Size = new System.Drawing.Size(23, 10);
            this.imgFoGrenade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoGrenade.TabIndex = 73;
            this.imgFoGrenade.TabStop = false;
            // 
            // imgFoLaser
            // 
            this.imgFoLaser.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_laser;
            this.imgFoLaser.Location = new System.Drawing.Point(55, 71);
            this.imgFoLaser.Name = "imgFoLaser";
            this.imgFoLaser.Size = new System.Drawing.Size(23, 10);
            this.imgFoLaser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoLaser.TabIndex = 72;
            this.imgFoLaser.TabStop = false;
            // 
            // imgFoLongbow
            // 
            this.imgFoLongbow.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_longbow;
            this.imgFoLongbow.Location = new System.Drawing.Point(127, 59);
            this.imgFoLongbow.Name = "imgFoLongbow";
            this.imgFoLongbow.Size = new System.Drawing.Size(23, 10);
            this.imgFoLongbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoLongbow.TabIndex = 71;
            this.imgFoLongbow.TabStop = false;
            // 
            // imgFoShotgun
            // 
            this.imgFoShotgun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_shotgun;
            this.imgFoShotgun.Location = new System.Drawing.Point(91, 59);
            this.imgFoShotgun.Name = "imgFoShotgun";
            this.imgFoShotgun.Size = new System.Drawing.Size(23, 10);
            this.imgFoShotgun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoShotgun.TabIndex = 70;
            this.imgFoShotgun.TabStop = false;
            // 
            // imgFoSlicer
            // 
            this.imgFoSlicer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_slicer;
            this.imgFoSlicer.Location = new System.Drawing.Point(19, 59);
            this.imgFoSlicer.Name = "imgFoSlicer";
            this.imgFoSlicer.Size = new System.Drawing.Size(10, 10);
            this.imgFoSlicer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSlicer.TabIndex = 69;
            this.imgFoSlicer.TabStop = false;
            // 
            // imgFoRifle
            // 
            this.imgFoRifle.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rifle;
            this.imgFoRifle.Location = new System.Drawing.Point(55, 59);
            this.imgFoRifle.Name = "imgFoRifle";
            this.imgFoRifle.Size = new System.Drawing.Size(23, 10);
            this.imgFoRifle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoRifle.TabIndex = 68;
            this.imgFoRifle.TabStop = false;
            // 
            // imgFoWhip
            // 
            this.imgFoWhip.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_whip;
            this.imgFoWhip.Location = new System.Drawing.Point(127, 47);
            this.imgFoWhip.Name = "imgFoWhip";
            this.imgFoWhip.Size = new System.Drawing.Size(10, 10);
            this.imgFoWhip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoWhip.TabIndex = 67;
            this.imgFoWhip.TabStop = false;
            // 
            // imgFoClaw
            // 
            this.imgFoClaw.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_claw;
            this.imgFoClaw.Location = new System.Drawing.Point(91, 47);
            this.imgFoClaw.Name = "imgFoClaw";
            this.imgFoClaw.Size = new System.Drawing.Size(10, 10);
            this.imgFoClaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoClaw.TabIndex = 66;
            this.imgFoClaw.TabStop = false;
            // 
            // imgFoSaber
            // 
            this.imgFoSaber.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_saber;
            this.imgFoSaber.Location = new System.Drawing.Point(19, 47);
            this.imgFoSaber.Name = "imgFoSaber";
            this.imgFoSaber.Size = new System.Drawing.Size(10, 10);
            this.imgFoSaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSaber.TabIndex = 65;
            this.imgFoSaber.TabStop = false;
            // 
            // imgFoDagger
            // 
            this.imgFoDagger.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_dagger;
            this.imgFoDagger.Location = new System.Drawing.Point(55, 47);
            this.imgFoDagger.Name = "imgFoDagger";
            this.imgFoDagger.Size = new System.Drawing.Size(10, 10);
            this.imgFoDagger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoDagger.TabIndex = 64;
            this.imgFoDagger.TabStop = false;
            // 
            // imgFoShield
            // 
            this.imgFoShield.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_shield;
            this.imgFoShield.Location = new System.Drawing.Point(127, 95);
            this.imgFoShield.Name = "imgFoShield";
            this.imgFoShield.Size = new System.Drawing.Size(10, 10);
            this.imgFoShield.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoShield.TabIndex = 63;
            this.imgFoShield.TabStop = false;
            // 
            // imgFoTmag
            // 
            this.imgFoTmag.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_tmag;
            this.imgFoTmag.Location = new System.Drawing.Point(91, 95);
            this.imgFoTmag.Name = "imgFoTmag";
            this.imgFoTmag.Size = new System.Drawing.Size(10, 10);
            this.imgFoTmag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoTmag.TabIndex = 62;
            this.imgFoTmag.TabStop = false;
            // 
            // imgFoRod
            // 
            this.imgFoRod.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rod;
            this.imgFoRod.Location = new System.Drawing.Point(19, 95);
            this.imgFoRod.Name = "imgFoRod";
            this.imgFoRod.Size = new System.Drawing.Size(23, 10);
            this.imgFoRod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoRod.TabIndex = 61;
            this.imgFoRod.TabStop = false;
            // 
            // imgFoWand
            // 
            this.imgFoWand.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_wand;
            this.imgFoWand.Location = new System.Drawing.Point(55, 95);
            this.imgFoWand.Name = "imgFoWand";
            this.imgFoWand.Size = new System.Drawing.Size(10, 10);
            this.imgFoWand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoWand.TabIndex = 60;
            this.imgFoWand.TabStop = false;
            // 
            // imgFoClaws
            // 
            this.imgFoClaws.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_claws;
            this.imgFoClaws.Location = new System.Drawing.Point(127, 35);
            this.imgFoClaws.Name = "imgFoClaws";
            this.imgFoClaws.Size = new System.Drawing.Size(23, 10);
            this.imgFoClaws.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoClaws.TabIndex = 59;
            this.imgFoClaws.TabStop = false;
            // 
            // imgFoDaggers
            // 
            this.imgFoDaggers.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_daggers;
            this.imgFoDaggers.Location = new System.Drawing.Point(91, 35);
            this.imgFoDaggers.Name = "imgFoDaggers";
            this.imgFoDaggers.Size = new System.Drawing.Size(23, 10);
            this.imgFoDaggers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoDaggers.TabIndex = 58;
            this.imgFoDaggers.TabStop = false;
            // 
            // imgFoAxe
            // 
            this.imgFoAxe.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_axe;
            this.imgFoAxe.Location = new System.Drawing.Point(19, 35);
            this.imgFoAxe.Name = "imgFoAxe";
            this.imgFoAxe.Size = new System.Drawing.Size(23, 10);
            this.imgFoAxe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoAxe.TabIndex = 57;
            this.imgFoAxe.TabStop = false;
            // 
            // imgFoSabers
            // 
            this.imgFoSabers.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sabers;
            this.imgFoSabers.Location = new System.Drawing.Point(55, 35);
            this.imgFoSabers.Name = "imgFoSabers";
            this.imgFoSabers.Size = new System.Drawing.Size(23, 10);
            this.imgFoSabers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSabers.TabIndex = 56;
            this.imgFoSabers.TabStop = false;
            // 
            // imgFoDblSaber
            // 
            this.imgFoDblSaber.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_double_saber;
            this.imgFoDblSaber.Location = new System.Drawing.Point(127, 23);
            this.imgFoDblSaber.Name = "imgFoDblSaber";
            this.imgFoDblSaber.Size = new System.Drawing.Size(23, 10);
            this.imgFoDblSaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoDblSaber.TabIndex = 55;
            this.imgFoDblSaber.TabStop = false;
            // 
            // imgFoKnuckles
            // 
            this.imgFoKnuckles.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_knuckles;
            this.imgFoKnuckles.Location = new System.Drawing.Point(55, 23);
            this.imgFoKnuckles.Name = "imgFoKnuckles";
            this.imgFoKnuckles.Size = new System.Drawing.Size(23, 10);
            this.imgFoKnuckles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoKnuckles.TabIndex = 54;
            this.imgFoKnuckles.TabStop = false;
            // 
            // imgFoSpear
            // 
            this.imgFoSpear.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_spear;
            this.imgFoSpear.Location = new System.Drawing.Point(91, 23);
            this.imgFoSpear.Name = "imgFoSpear";
            this.imgFoSpear.Size = new System.Drawing.Size(23, 10);
            this.imgFoSpear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSpear.TabIndex = 53;
            this.imgFoSpear.TabStop = false;
            // 
            // imgFoSword
            // 
            this.imgFoSword.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sword;
            this.imgFoSword.Location = new System.Drawing.Point(19, 23);
            this.imgFoSword.Name = "imgFoSword";
            this.imgFoSword.Size = new System.Drawing.Size(23, 10);
            this.imgFoSword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFoSword.TabIndex = 52;
            this.imgFoSword.TabStop = false;
            // 
            // pictureBox117
            // 
            this.pictureBox117.Image = global::pspo2seSaveEditorProgram.Properties.Resources.type_weapons;
            this.pictureBox117.Location = new System.Drawing.Point(19, 23);
            this.pictureBox117.Name = "pictureBox117";
            this.pictureBox117.Size = new System.Drawing.Size(131, 82);
            this.pictureBox117.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox117.TabIndex = 47;
            this.pictureBox117.TabStop = false;
            // 
            // lblFoLevel
            // 
            this.lblFoLevel.AutoSize = true;
            this.lblFoLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFoLevel.Location = new System.Drawing.Point(12, 32);
            this.lblFoLevel.Name = "lblFoLevel";
            this.lblFoLevel.Size = new System.Drawing.Size(37, 13);
            this.lblFoLevel.TabIndex = 136;
            this.lblFoLevel.Text = "Level";
            this.lblFoLevel.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // txtFoLevel
            // 
            this.txtFoLevel.AutoSize = true;
            this.txtFoLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtFoLevel.Location = new System.Drawing.Point(50, 32);
            this.txtFoLevel.Name = "txtFoLevel";
            this.txtFoLevel.Size = new System.Drawing.Size(14, 13);
            this.txtFoLevel.TabIndex = 135;
            this.txtFoLevel.Text = "0";
            this.txtFoLevel.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // btnFoAbilitiesOpen
            // 
            this.btnFoAbilitiesOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoAbilitiesOpen.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoAbilitiesOpen.Location = new System.Drawing.Point(543, 8);
            this.btnFoAbilitiesOpen.Name = "btnFoAbilitiesOpen";
            this.btnFoAbilitiesOpen.Size = new System.Drawing.Size(61, 21);
            this.btnFoAbilitiesOpen.TabIndex = 139;
            this.btnFoAbilitiesOpen.Text = "Abilities";
            this.btnFoAbilitiesOpen.UseVisualStyleBackColor = true;
            this.btnFoAbilitiesOpen.Click += new System.EventHandler(this.btnFoAbilitiesOpen_Click);
            // 
            // tabPageVanguard
            // 
            this.tabPageVanguard.Controls.Add(this.label27);
            this.tabPageVanguard.Controls.Add(this.grpVaTypeExtend);
            this.tabPageVanguard.Controls.Add(this.txtVaLevel);
            this.tabPageVanguard.Controls.Add(this.lblVaLevel);
            this.tabPageVanguard.Controls.Add(this.btnVaAbilitiesOpen);
            this.tabPageVanguard.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.tabPageVanguard.Location = new System.Drawing.Point(4, 21);
            this.tabPageVanguard.Name = "tabPageVanguard";
            this.tabPageVanguard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVanguard.Size = new System.Drawing.Size(610, 192);
            this.tabPageVanguard.TabIndex = 3;
            this.tabPageVanguard.Text = "Vanguard (0)";
            this.tabPageVanguard.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(11, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(78, 16);
            this.label27.TabIndex = 138;
            this.label27.Text = "Vanguard";
            // 
            // grpVaTypeExtend
            // 
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
            this.grpVaTypeExtend.Location = new System.Drawing.Point(10, 58);
            this.grpVaTypeExtend.Name = "grpVaTypeExtend";
            this.grpVaTypeExtend.Size = new System.Drawing.Size(304, 119);
            this.grpVaTypeExtend.TabIndex = 137;
            this.grpVaTypeExtend.TabStop = false;
            this.grpVaTypeExtend.Text = "Type Extend 0/0";
            // 
            // txtVaExp
            // 
            this.txtVaExp.BackColor = System.Drawing.Color.Transparent;
            this.txtVaExp.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.txtVaExp.Location = new System.Drawing.Point(194, 36);
            this.txtVaExp.Name = "txtVaExp";
            this.txtVaExp.Size = new System.Drawing.Size(102, 69);
            this.txtVaExp.TabIndex = 110;
            this.txtVaExp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imgVaTmagRank
            // 
            this.imgVaTmagRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaTmagRank.Location = new System.Drawing.Point(80, 95);
            this.imgVaTmagRank.Name = "imgVaTmagRank";
            this.imgVaTmagRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaTmagRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaTmagRank.TabIndex = 107;
            this.imgVaTmagRank.TabStop = false;
            // 
            // imgVaMachinegunRank
            // 
            this.imgVaMachinegunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaMachinegunRank.Location = new System.Drawing.Point(80, 83);
            this.imgVaMachinegunRank.Name = "imgVaMachinegunRank";
            this.imgVaMachinegunRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaMachinegunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaMachinegunRank.TabIndex = 106;
            this.imgVaMachinegunRank.TabStop = false;
            // 
            // txtVaExpBar
            // 
            this.txtVaExpBar.BackColor = System.Drawing.Color.Red;
            this.txtVaExpBar.Location = new System.Drawing.Point(195, 23);
            this.txtVaExpBar.Name = "txtVaExpBar";
            this.txtVaExpBar.Size = new System.Drawing.Size(87, 8);
            this.txtVaExpBar.TabIndex = 49;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(159, 20);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 13);
            this.label28.TabIndex = 48;
            this.label28.Text = "EXP";
            // 
            // imgVaHandgunsRank
            // 
            this.imgVaHandgunsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaHandgunsRank.Location = new System.Drawing.Point(80, 71);
            this.imgVaHandgunsRank.Name = "imgVaHandgunsRank";
            this.imgVaHandgunsRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaHandgunsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaHandgunsRank.TabIndex = 105;
            this.imgVaHandgunsRank.TabStop = false;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Gainsboro;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Location = new System.Drawing.Point(194, 22);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(102, 10);
            this.label29.TabIndex = 50;
            // 
            // imgVaShotgunRank
            // 
            this.imgVaShotgunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaShotgunRank.Location = new System.Drawing.Point(80, 59);
            this.imgVaShotgunRank.Name = "imgVaShotgunRank";
            this.imgVaShotgunRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaShotgunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaShotgunRank.TabIndex = 104;
            this.imgVaShotgunRank.TabStop = false;
            // 
            // imgVaClawRank
            // 
            this.imgVaClawRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaClawRank.Location = new System.Drawing.Point(80, 47);
            this.imgVaClawRank.Name = "imgVaClawRank";
            this.imgVaClawRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaClawRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaClawRank.TabIndex = 103;
            this.imgVaClawRank.TabStop = false;
            // 
            // imgVaDaggersRank
            // 
            this.imgVaDaggersRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaDaggersRank.Location = new System.Drawing.Point(80, 35);
            this.imgVaDaggersRank.Name = "imgVaDaggersRank";
            this.imgVaDaggersRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaDaggersRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaDaggersRank.TabIndex = 102;
            this.imgVaDaggersRank.TabStop = false;
            // 
            // imgVaSpearRank
            // 
            this.imgVaSpearRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaSpearRank.Location = new System.Drawing.Point(80, 23);
            this.imgVaSpearRank.Name = "imgVaSpearRank";
            this.imgVaSpearRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaSpearRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSpearRank.TabIndex = 101;
            this.imgVaSpearRank.TabStop = false;
            // 
            // imgVaWandRank
            // 
            this.imgVaWandRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaWandRank.Location = new System.Drawing.Point(44, 95);
            this.imgVaWandRank.Name = "imgVaWandRank";
            this.imgVaWandRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaWandRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaWandRank.TabIndex = 100;
            this.imgVaWandRank.TabStop = false;
            // 
            // imgVaCardsRank
            // 
            this.imgVaCardsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaCardsRank.Location = new System.Drawing.Point(44, 83);
            this.imgVaCardsRank.Name = "imgVaCardsRank";
            this.imgVaCardsRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaCardsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaCardsRank.TabIndex = 99;
            this.imgVaCardsRank.TabStop = false;
            // 
            // imgVaLaserRank
            // 
            this.imgVaLaserRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaLaserRank.Location = new System.Drawing.Point(44, 71);
            this.imgVaLaserRank.Name = "imgVaLaserRank";
            this.imgVaLaserRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaLaserRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaLaserRank.TabIndex = 98;
            this.imgVaLaserRank.TabStop = false;
            // 
            // imgVaRifleRank
            // 
            this.imgVaRifleRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaRifleRank.Location = new System.Drawing.Point(44, 59);
            this.imgVaRifleRank.Name = "imgVaRifleRank";
            this.imgVaRifleRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaRifleRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaRifleRank.TabIndex = 97;
            this.imgVaRifleRank.TabStop = false;
            // 
            // imgVaDaggerRank
            // 
            this.imgVaDaggerRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaDaggerRank.Location = new System.Drawing.Point(44, 47);
            this.imgVaDaggerRank.Name = "imgVaDaggerRank";
            this.imgVaDaggerRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaDaggerRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaDaggerRank.TabIndex = 96;
            this.imgVaDaggerRank.TabStop = false;
            // 
            // imgVaSabersRank
            // 
            this.imgVaSabersRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaSabersRank.Location = new System.Drawing.Point(44, 35);
            this.imgVaSabersRank.Name = "imgVaSabersRank";
            this.imgVaSabersRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaSabersRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSabersRank.TabIndex = 95;
            this.imgVaSabersRank.TabStop = false;
            // 
            // imgVaKnucklesRank
            // 
            this.imgVaKnucklesRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaKnucklesRank.Location = new System.Drawing.Point(44, 23);
            this.imgVaKnucklesRank.Name = "imgVaKnucklesRank";
            this.imgVaKnucklesRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaKnucklesRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaKnucklesRank.TabIndex = 94;
            this.imgVaKnucklesRank.TabStop = false;
            // 
            // imgVaShieldRank
            // 
            this.imgVaShieldRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaShieldRank.Location = new System.Drawing.Point(116, 95);
            this.imgVaShieldRank.Name = "imgVaShieldRank";
            this.imgVaShieldRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaShieldRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaShieldRank.TabIndex = 93;
            this.imgVaShieldRank.TabStop = false;
            // 
            // imgVaRmagRank
            // 
            this.imgVaRmagRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaRmagRank.Location = new System.Drawing.Point(116, 83);
            this.imgVaRmagRank.Name = "imgVaRmagRank";
            this.imgVaRmagRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaRmagRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaRmagRank.TabIndex = 92;
            this.imgVaRmagRank.TabStop = false;
            // 
            // imgVaHandgunRank
            // 
            this.imgVaHandgunRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaHandgunRank.Location = new System.Drawing.Point(116, 71);
            this.imgVaHandgunRank.Name = "imgVaHandgunRank";
            this.imgVaHandgunRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaHandgunRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaHandgunRank.TabIndex = 91;
            this.imgVaHandgunRank.TabStop = false;
            // 
            // imgVaLongbowRank
            // 
            this.imgVaLongbowRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaLongbowRank.Location = new System.Drawing.Point(116, 59);
            this.imgVaLongbowRank.Name = "imgVaLongbowRank";
            this.imgVaLongbowRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaLongbowRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaLongbowRank.TabIndex = 90;
            this.imgVaLongbowRank.TabStop = false;
            // 
            // imgVaWhipRank
            // 
            this.imgVaWhipRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaWhipRank.Location = new System.Drawing.Point(116, 47);
            this.imgVaWhipRank.Name = "imgVaWhipRank";
            this.imgVaWhipRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaWhipRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaWhipRank.TabIndex = 89;
            this.imgVaWhipRank.TabStop = false;
            // 
            // imgVaClawsRank
            // 
            this.imgVaClawsRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaClawsRank.Location = new System.Drawing.Point(116, 35);
            this.imgVaClawsRank.Name = "imgVaClawsRank";
            this.imgVaClawsRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaClawsRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaClawsRank.TabIndex = 88;
            this.imgVaClawsRank.TabStop = false;
            // 
            // imgVaDblSaberRank
            // 
            this.imgVaDblSaberRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_B;
            this.imgVaDblSaberRank.Location = new System.Drawing.Point(116, 23);
            this.imgVaDblSaberRank.Name = "imgVaDblSaberRank";
            this.imgVaDblSaberRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaDblSaberRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaDblSaberRank.TabIndex = 87;
            this.imgVaDblSaberRank.TabStop = false;
            // 
            // imgVaRodRank
            // 
            this.imgVaRodRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaRodRank.Location = new System.Drawing.Point(8, 95);
            this.imgVaRodRank.Name = "imgVaRodRank";
            this.imgVaRodRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaRodRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaRodRank.TabIndex = 86;
            this.imgVaRodRank.TabStop = false;
            // 
            // imgVaCrossbowRank
            // 
            this.imgVaCrossbowRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaCrossbowRank.Location = new System.Drawing.Point(8, 83);
            this.imgVaCrossbowRank.Name = "imgVaCrossbowRank";
            this.imgVaCrossbowRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaCrossbowRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaCrossbowRank.TabIndex = 85;
            this.imgVaCrossbowRank.TabStop = false;
            // 
            // imgVaGrenadeRank
            // 
            this.imgVaGrenadeRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaGrenadeRank.Location = new System.Drawing.Point(8, 71);
            this.imgVaGrenadeRank.Name = "imgVaGrenadeRank";
            this.imgVaGrenadeRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaGrenadeRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaGrenadeRank.TabIndex = 84;
            this.imgVaGrenadeRank.TabStop = false;
            // 
            // imgVaSlicerRank
            // 
            this.imgVaSlicerRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaSlicerRank.Location = new System.Drawing.Point(8, 59);
            this.imgVaSlicerRank.Name = "imgVaSlicerRank";
            this.imgVaSlicerRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaSlicerRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSlicerRank.TabIndex = 83;
            this.imgVaSlicerRank.TabStop = false;
            // 
            // imgVaSaberRank
            // 
            this.imgVaSaberRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaSaberRank.Location = new System.Drawing.Point(8, 47);
            this.imgVaSaberRank.Name = "imgVaSaberRank";
            this.imgVaSaberRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaSaberRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSaberRank.TabIndex = 82;
            this.imgVaSaberRank.TabStop = false;
            // 
            // imgVaAxeRank
            // 
            this.imgVaAxeRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaAxeRank.Location = new System.Drawing.Point(8, 35);
            this.imgVaAxeRank.Name = "imgVaAxeRank";
            this.imgVaAxeRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaAxeRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaAxeRank.TabIndex = 81;
            this.imgVaAxeRank.TabStop = false;
            // 
            // imgVaSwordRank
            // 
            this.imgVaSwordRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_C;
            this.imgVaSwordRank.Location = new System.Drawing.Point(8, 23);
            this.imgVaSwordRank.Name = "imgVaSwordRank";
            this.imgVaSwordRank.Size = new System.Drawing.Size(10, 10);
            this.imgVaSwordRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSwordRank.TabIndex = 80;
            this.imgVaSwordRank.TabStop = false;
            // 
            // imgVaRmag
            // 
            this.imgVaRmag.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rmag;
            this.imgVaRmag.Location = new System.Drawing.Point(127, 83);
            this.imgVaRmag.Name = "imgVaRmag";
            this.imgVaRmag.Size = new System.Drawing.Size(10, 10);
            this.imgVaRmag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaRmag.TabIndex = 79;
            this.imgVaRmag.TabStop = false;
            // 
            // imgVaMachinegun
            // 
            this.imgVaMachinegun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_machinegun;
            this.imgVaMachinegun.Location = new System.Drawing.Point(91, 83);
            this.imgVaMachinegun.Name = "imgVaMachinegun";
            this.imgVaMachinegun.Size = new System.Drawing.Size(10, 10);
            this.imgVaMachinegun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaMachinegun.TabIndex = 78;
            this.imgVaMachinegun.TabStop = false;
            // 
            // imgVaCrossbow
            // 
            this.imgVaCrossbow.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_crossbow;
            this.imgVaCrossbow.Location = new System.Drawing.Point(19, 83);
            this.imgVaCrossbow.Name = "imgVaCrossbow";
            this.imgVaCrossbow.Size = new System.Drawing.Size(10, 10);
            this.imgVaCrossbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaCrossbow.TabIndex = 77;
            this.imgVaCrossbow.TabStop = false;
            // 
            // imgVaCards
            // 
            this.imgVaCards.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_card;
            this.imgVaCards.Location = new System.Drawing.Point(55, 83);
            this.imgVaCards.Name = "imgVaCards";
            this.imgVaCards.Size = new System.Drawing.Size(10, 10);
            this.imgVaCards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaCards.TabIndex = 76;
            this.imgVaCards.TabStop = false;
            // 
            // imgVaHandgun
            // 
            this.imgVaHandgun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_handgun;
            this.imgVaHandgun.Location = new System.Drawing.Point(127, 71);
            this.imgVaHandgun.Name = "imgVaHandgun";
            this.imgVaHandgun.Size = new System.Drawing.Size(10, 10);
            this.imgVaHandgun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaHandgun.TabIndex = 75;
            this.imgVaHandgun.TabStop = false;
            // 
            // imgVaHandguns
            // 
            this.imgVaHandguns.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_handguns;
            this.imgVaHandguns.Location = new System.Drawing.Point(91, 71);
            this.imgVaHandguns.Name = "imgVaHandguns";
            this.imgVaHandguns.Size = new System.Drawing.Size(23, 10);
            this.imgVaHandguns.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaHandguns.TabIndex = 74;
            this.imgVaHandguns.TabStop = false;
            // 
            // imgVaGrenade
            // 
            this.imgVaGrenade.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_grenade;
            this.imgVaGrenade.Location = new System.Drawing.Point(19, 71);
            this.imgVaGrenade.Name = "imgVaGrenade";
            this.imgVaGrenade.Size = new System.Drawing.Size(23, 10);
            this.imgVaGrenade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaGrenade.TabIndex = 73;
            this.imgVaGrenade.TabStop = false;
            // 
            // imgVaLaser
            // 
            this.imgVaLaser.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_laser;
            this.imgVaLaser.Location = new System.Drawing.Point(55, 71);
            this.imgVaLaser.Name = "imgVaLaser";
            this.imgVaLaser.Size = new System.Drawing.Size(23, 10);
            this.imgVaLaser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaLaser.TabIndex = 72;
            this.imgVaLaser.TabStop = false;
            // 
            // imgVaLongbow
            // 
            this.imgVaLongbow.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_longbow;
            this.imgVaLongbow.Location = new System.Drawing.Point(127, 59);
            this.imgVaLongbow.Name = "imgVaLongbow";
            this.imgVaLongbow.Size = new System.Drawing.Size(23, 10);
            this.imgVaLongbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaLongbow.TabIndex = 71;
            this.imgVaLongbow.TabStop = false;
            // 
            // imgVaShotgun
            // 
            this.imgVaShotgun.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_shotgun;
            this.imgVaShotgun.Location = new System.Drawing.Point(91, 59);
            this.imgVaShotgun.Name = "imgVaShotgun";
            this.imgVaShotgun.Size = new System.Drawing.Size(23, 10);
            this.imgVaShotgun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaShotgun.TabIndex = 70;
            this.imgVaShotgun.TabStop = false;
            // 
            // imgVaSlicer
            // 
            this.imgVaSlicer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_slicer;
            this.imgVaSlicer.Location = new System.Drawing.Point(19, 59);
            this.imgVaSlicer.Name = "imgVaSlicer";
            this.imgVaSlicer.Size = new System.Drawing.Size(10, 10);
            this.imgVaSlicer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSlicer.TabIndex = 69;
            this.imgVaSlicer.TabStop = false;
            // 
            // imgVaRifle
            // 
            this.imgVaRifle.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rifle;
            this.imgVaRifle.Location = new System.Drawing.Point(55, 59);
            this.imgVaRifle.Name = "imgVaRifle";
            this.imgVaRifle.Size = new System.Drawing.Size(23, 10);
            this.imgVaRifle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaRifle.TabIndex = 68;
            this.imgVaRifle.TabStop = false;
            // 
            // imgVaWhip
            // 
            this.imgVaWhip.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_whip;
            this.imgVaWhip.Location = new System.Drawing.Point(127, 47);
            this.imgVaWhip.Name = "imgVaWhip";
            this.imgVaWhip.Size = new System.Drawing.Size(10, 10);
            this.imgVaWhip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaWhip.TabIndex = 67;
            this.imgVaWhip.TabStop = false;
            // 
            // imgVaClaw
            // 
            this.imgVaClaw.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_claw;
            this.imgVaClaw.Location = new System.Drawing.Point(91, 47);
            this.imgVaClaw.Name = "imgVaClaw";
            this.imgVaClaw.Size = new System.Drawing.Size(10, 10);
            this.imgVaClaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaClaw.TabIndex = 66;
            this.imgVaClaw.TabStop = false;
            // 
            // imgVaSaber
            // 
            this.imgVaSaber.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_saber;
            this.imgVaSaber.Location = new System.Drawing.Point(19, 47);
            this.imgVaSaber.Name = "imgVaSaber";
            this.imgVaSaber.Size = new System.Drawing.Size(10, 10);
            this.imgVaSaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSaber.TabIndex = 65;
            this.imgVaSaber.TabStop = false;
            // 
            // imgVaDagger
            // 
            this.imgVaDagger.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_dagger;
            this.imgVaDagger.Location = new System.Drawing.Point(55, 47);
            this.imgVaDagger.Name = "imgVaDagger";
            this.imgVaDagger.Size = new System.Drawing.Size(10, 10);
            this.imgVaDagger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaDagger.TabIndex = 64;
            this.imgVaDagger.TabStop = false;
            // 
            // imgVaShield
            // 
            this.imgVaShield.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_shield;
            this.imgVaShield.Location = new System.Drawing.Point(127, 95);
            this.imgVaShield.Name = "imgVaShield";
            this.imgVaShield.Size = new System.Drawing.Size(10, 10);
            this.imgVaShield.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaShield.TabIndex = 63;
            this.imgVaShield.TabStop = false;
            // 
            // imgVaTmag
            // 
            this.imgVaTmag.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_tmag;
            this.imgVaTmag.Location = new System.Drawing.Point(91, 95);
            this.imgVaTmag.Name = "imgVaTmag";
            this.imgVaTmag.Size = new System.Drawing.Size(10, 10);
            this.imgVaTmag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaTmag.TabIndex = 62;
            this.imgVaTmag.TabStop = false;
            // 
            // imgVaRod
            // 
            this.imgVaRod.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_rod;
            this.imgVaRod.Location = new System.Drawing.Point(19, 95);
            this.imgVaRod.Name = "imgVaRod";
            this.imgVaRod.Size = new System.Drawing.Size(23, 10);
            this.imgVaRod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaRod.TabIndex = 61;
            this.imgVaRod.TabStop = false;
            // 
            // imgVaWand
            // 
            this.imgVaWand.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_wand;
            this.imgVaWand.Location = new System.Drawing.Point(55, 95);
            this.imgVaWand.Name = "imgVaWand";
            this.imgVaWand.Size = new System.Drawing.Size(10, 10);
            this.imgVaWand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaWand.TabIndex = 60;
            this.imgVaWand.TabStop = false;
            // 
            // imgVaClaws
            // 
            this.imgVaClaws.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_claws;
            this.imgVaClaws.Location = new System.Drawing.Point(127, 35);
            this.imgVaClaws.Name = "imgVaClaws";
            this.imgVaClaws.Size = new System.Drawing.Size(23, 10);
            this.imgVaClaws.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaClaws.TabIndex = 59;
            this.imgVaClaws.TabStop = false;
            // 
            // imgVaDaggers
            // 
            this.imgVaDaggers.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_daggers;
            this.imgVaDaggers.Location = new System.Drawing.Point(91, 35);
            this.imgVaDaggers.Name = "imgVaDaggers";
            this.imgVaDaggers.Size = new System.Drawing.Size(23, 10);
            this.imgVaDaggers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaDaggers.TabIndex = 58;
            this.imgVaDaggers.TabStop = false;
            // 
            // imgVaAxe
            // 
            this.imgVaAxe.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_axe;
            this.imgVaAxe.Location = new System.Drawing.Point(19, 35);
            this.imgVaAxe.Name = "imgVaAxe";
            this.imgVaAxe.Size = new System.Drawing.Size(23, 10);
            this.imgVaAxe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaAxe.TabIndex = 57;
            this.imgVaAxe.TabStop = false;
            // 
            // imgVaSabers
            // 
            this.imgVaSabers.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sabers;
            this.imgVaSabers.Location = new System.Drawing.Point(55, 35);
            this.imgVaSabers.Name = "imgVaSabers";
            this.imgVaSabers.Size = new System.Drawing.Size(23, 10);
            this.imgVaSabers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSabers.TabIndex = 56;
            this.imgVaSabers.TabStop = false;
            // 
            // imgVaDblSaber
            // 
            this.imgVaDblSaber.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_double_saber;
            this.imgVaDblSaber.Location = new System.Drawing.Point(127, 23);
            this.imgVaDblSaber.Name = "imgVaDblSaber";
            this.imgVaDblSaber.Size = new System.Drawing.Size(23, 10);
            this.imgVaDblSaber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaDblSaber.TabIndex = 55;
            this.imgVaDblSaber.TabStop = false;
            // 
            // imgVaKnuckles
            // 
            this.imgVaKnuckles.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_knuckles;
            this.imgVaKnuckles.Location = new System.Drawing.Point(55, 23);
            this.imgVaKnuckles.Name = "imgVaKnuckles";
            this.imgVaKnuckles.Size = new System.Drawing.Size(23, 10);
            this.imgVaKnuckles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaKnuckles.TabIndex = 54;
            this.imgVaKnuckles.TabStop = false;
            // 
            // imgVaSpear
            // 
            this.imgVaSpear.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_spear;
            this.imgVaSpear.Location = new System.Drawing.Point(91, 23);
            this.imgVaSpear.Name = "imgVaSpear";
            this.imgVaSpear.Size = new System.Drawing.Size(23, 10);
            this.imgVaSpear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSpear.TabIndex = 53;
            this.imgVaSpear.TabStop = false;
            // 
            // imgVaSword
            // 
            this.imgVaSword.Image = global::pspo2seSaveEditorProgram.Properties.Resources.weapon_sword;
            this.imgVaSword.Location = new System.Drawing.Point(19, 23);
            this.imgVaSword.Name = "imgVaSword";
            this.imgVaSword.Size = new System.Drawing.Size(23, 10);
            this.imgVaSword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVaSword.TabIndex = 52;
            this.imgVaSword.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::pspo2seSaveEditorProgram.Properties.Resources.type_weapons;
            this.pictureBox5.Location = new System.Drawing.Point(19, 23);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(131, 82);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 47;
            this.pictureBox5.TabStop = false;
            // 
            // txtVaLevel
            // 
            this.txtVaLevel.AutoSize = true;
            this.txtVaLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtVaLevel.Location = new System.Drawing.Point(50, 32);
            this.txtVaLevel.Name = "txtVaLevel";
            this.txtVaLevel.Size = new System.Drawing.Size(14, 13);
            this.txtVaLevel.TabIndex = 136;
            this.txtVaLevel.Text = "0";
            this.txtVaLevel.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // lblVaLevel
            // 
            this.lblVaLevel.AutoSize = true;
            this.lblVaLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVaLevel.Location = new System.Drawing.Point(12, 32);
            this.lblVaLevel.Name = "lblVaLevel";
            this.lblVaLevel.Size = new System.Drawing.Size(37, 13);
            this.lblVaLevel.TabIndex = 135;
            this.lblVaLevel.Text = "Level";
            this.lblVaLevel.Click += new System.EventHandler(this.classLevel_Click);
            // 
            // btnVaAbilitiesOpen
            // 
            this.btnVaAbilitiesOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVaAbilitiesOpen.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVaAbilitiesOpen.Location = new System.Drawing.Point(543, 8);
            this.btnVaAbilitiesOpen.Name = "btnVaAbilitiesOpen";
            this.btnVaAbilitiesOpen.Size = new System.Drawing.Size(61, 21);
            this.btnVaAbilitiesOpen.TabIndex = 139;
            this.btnVaAbilitiesOpen.Text = "Abilities";
            this.btnVaAbilitiesOpen.UseVisualStyleBackColor = true;
            this.btnVaAbilitiesOpen.Click += new System.EventHandler(this.btnVaAbilitiesOpen_Click);
            // 
            // tabPageInventory
            // 
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
            this.tabPageInventory.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPageInventory.Location = new System.Drawing.Point(4, 22);
            this.tabPageInventory.Name = "tabPageInventory";
            this.tabPageInventory.Size = new System.Drawing.Size(629, 223);
            this.tabPageInventory.TabIndex = 6;
            this.tabPageInventory.Text = "Inventory (0/60)";
            this.tabPageInventory.UseVisualStyleBackColor = true;
            // 
            // btnInventoryDelete
            // 
            this.btnInventoryDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryDelete.Enabled = false;
            this.btnInventoryDelete.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryDelete.Location = new System.Drawing.Point(391, 177);
            this.btnInventoryDelete.Name = "btnInventoryDelete";
            this.btnInventoryDelete.Size = new System.Drawing.Size(46, 21);
            this.btnInventoryDelete.TabIndex = 76;
            this.btnInventoryDelete.Text = "delete";
            this.btnInventoryDelete.UseVisualStyleBackColor = true;
            this.btnInventoryDelete.Click += new System.EventHandler(this.btnInventoryDelete_Click);
            // 
            // chkDeleteExportInventory
            // 
            this.chkDeleteExportInventory.AutoSize = true;
            this.chkDeleteExportInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDeleteExportInventory.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteExportInventory.Location = new System.Drawing.Point(497, 206);
            this.chkDeleteExportInventory.Name = "chkDeleteExportInventory";
            this.chkDeleteExportInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDeleteExportInventory.Size = new System.Drawing.Size(125, 14);
            this.chkDeleteExportInventory.TabIndex = 75;
            this.chkDeleteExportInventory.Text = "delete items after export";
            this.chkDeleteExportInventory.UseVisualStyleBackColor = true;
            // 
            // btnInventoryDeposit
            // 
            this.btnInventoryDeposit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryDeposit.Enabled = false;
            this.btnInventoryDeposit.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryDeposit.Location = new System.Drawing.Point(566, 177);
            this.btnInventoryDeposit.Name = "btnInventoryDeposit";
            this.btnInventoryDeposit.Size = new System.Drawing.Size(56, 21);
            this.btnInventoryDeposit.TabIndex = 74;
            this.btnInventoryDeposit.Text = "deposit";
            this.btnInventoryDeposit.UseVisualStyleBackColor = true;
            this.btnInventoryDeposit.Click += new System.EventHandler(this.btnInventoryDeposit_Click);
            // 
            // inventoryViewPages
            // 
            this.inventoryViewPages.Controls.Add(this.tabInventory1);
            this.inventoryViewPages.Controls.Add(this.tabInventory2);
            this.inventoryViewPages.Controls.Add(this.tabInventory3);
            this.inventoryViewPages.Controls.Add(this.tabInventory4);
            this.inventoryViewPages.Controls.Add(this.tabInventory5);
            this.inventoryViewPages.Controls.Add(this.tabInventory6);
            this.inventoryViewPages.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryViewPages.Location = new System.Drawing.Point(5, 12);
            this.inventoryViewPages.Name = "inventoryViewPages";
            this.inventoryViewPages.SelectedIndex = 0;
            this.inventoryViewPages.Size = new System.Drawing.Size(315, 19);
            this.inventoryViewPages.TabIndex = 73;
            this.inventoryViewPages.SelectedIndexChanged += new System.EventHandler(this.inventoryViewPages_SelectedIndexChanged);
            // 
            // tabInventory1
            // 
            this.tabInventory1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInventory1.Location = new System.Drawing.Point(4, 19);
            this.tabInventory1.Name = "tabInventory1";
            this.tabInventory1.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventory1.Size = new System.Drawing.Size(307, 0);
            this.tabInventory1.TabIndex = 0;
            this.tabInventory1.Text = "1";
            this.tabInventory1.UseVisualStyleBackColor = true;
            // 
            // tabInventory2
            // 
            this.tabInventory2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInventory2.Location = new System.Drawing.Point(4, 19);
            this.tabInventory2.Name = "tabInventory2";
            this.tabInventory2.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventory2.Size = new System.Drawing.Size(307, 0);
            this.tabInventory2.TabIndex = 1;
            this.tabInventory2.Text = "2";
            this.tabInventory2.UseVisualStyleBackColor = true;
            // 
            // tabInventory3
            // 
            this.tabInventory3.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInventory3.Location = new System.Drawing.Point(4, 19);
            this.tabInventory3.Name = "tabInventory3";
            this.tabInventory3.Size = new System.Drawing.Size(307, 0);
            this.tabInventory3.TabIndex = 2;
            this.tabInventory3.Text = "3";
            this.tabInventory3.UseVisualStyleBackColor = true;
            // 
            // tabInventory4
            // 
            this.tabInventory4.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInventory4.Location = new System.Drawing.Point(4, 19);
            this.tabInventory4.Name = "tabInventory4";
            this.tabInventory4.Size = new System.Drawing.Size(307, 0);
            this.tabInventory4.TabIndex = 3;
            this.tabInventory4.Text = "4";
            this.tabInventory4.UseVisualStyleBackColor = true;
            // 
            // tabInventory5
            // 
            this.tabInventory5.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInventory5.Location = new System.Drawing.Point(4, 19);
            this.tabInventory5.Name = "tabInventory5";
            this.tabInventory5.Size = new System.Drawing.Size(307, 0);
            this.tabInventory5.TabIndex = 4;
            this.tabInventory5.Text = "5";
            this.tabInventory5.UseVisualStyleBackColor = true;
            // 
            // tabInventory6
            // 
            this.tabInventory6.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInventory6.Location = new System.Drawing.Point(4, 19);
            this.tabInventory6.Name = "tabInventory6";
            this.tabInventory6.Size = new System.Drawing.Size(307, 0);
            this.tabInventory6.TabIndex = 5;
            this.tabInventory6.Text = "Free Slots";
            this.tabInventory6.UseVisualStyleBackColor = true;
            // 
            // btnInventoryImportSelected
            // 
            this.btnInventoryImportSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryImportSelected.Enabled = false;
            this.btnInventoryImportSelected.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryImportSelected.Location = new System.Drawing.Point(437, 177);
            this.btnInventoryImportSelected.Name = "btnInventoryImportSelected";
            this.btnInventoryImportSelected.Size = new System.Drawing.Size(67, 21);
            this.btnInventoryImportSelected.TabIndex = 72;
            this.btnInventoryImportSelected.Text = "import item";
            this.btnInventoryImportSelected.UseVisualStyleBackColor = true;
            this.btnInventoryImportSelected.Click += new System.EventHandler(this.btnInventoryImportSelected_Click);
            // 
            // btnInventoryExportSelected
            // 
            this.btnInventoryExportSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryExportSelected.Enabled = false;
            this.btnInventoryExportSelected.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryExportSelected.Location = new System.Drawing.Point(504, 177);
            this.btnInventoryExportSelected.Name = "btnInventoryExportSelected";
            this.btnInventoryExportSelected.Size = new System.Drawing.Size(62, 21);
            this.btnInventoryExportSelected.TabIndex = 71;
            this.btnInventoryExportSelected.Text = "export item";
            this.btnInventoryExportSelected.UseVisualStyleBackColor = true;
            this.btnInventoryExportSelected.Click += new System.EventHandler(this.btnInventoryExportSelected_Click);
            // 
            // btnInventoryImportAll
            // 
            this.btnInventoryImportAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryImportAll.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryImportAll.Location = new System.Drawing.Point(152, 183);
            this.btnInventoryImportAll.Name = "btnInventoryImportAll";
            this.btnInventoryImportAll.Size = new System.Drawing.Size(82, 21);
            this.btnInventoryImportAll.TabIndex = 50;
            this.btnInventoryImportAll.Text = "import inventory";
            this.btnInventoryImportAll.UseVisualStyleBackColor = true;
            this.btnInventoryImportAll.Click += new System.EventHandler(this.btnInventoryImportAll_Click);
            // 
            // btnInventoryExportAll
            // 
            this.btnInventoryExportAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryExportAll.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryExportAll.Location = new System.Drawing.Point(236, 183);
            this.btnInventoryExportAll.Name = "btnInventoryExportAll";
            this.btnInventoryExportAll.Size = new System.Drawing.Size(82, 21);
            this.btnInventoryExportAll.TabIndex = 49;
            this.btnInventoryExportAll.Text = "export inventory";
            this.btnInventoryExportAll.UseVisualStyleBackColor = true;
            this.btnInventoryExportAll.Click += new System.EventHandler(this.btnInventoryExportAll_Click);
            // 
            // txtInventoryMeseta
            // 
            this.txtInventoryMeseta.AutoSize = true;
            this.txtInventoryMeseta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtInventoryMeseta.Location = new System.Drawing.Point(60, 182);
            this.txtInventoryMeseta.Name = "txtInventoryMeseta";
            this.txtInventoryMeseta.Size = new System.Drawing.Size(14, 13);
            this.txtInventoryMeseta.TabIndex = 27;
            this.txtInventoryMeseta.Text = "0";
            this.txtInventoryMeseta.Click += new System.EventHandler(this.txtInventoryMeseta_Click);
            // 
            // lblInventoryMeseta
            // 
            this.lblInventoryMeseta.AutoSize = true;
            this.lblInventoryMeseta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInventoryMeseta.Location = new System.Drawing.Point(16, 182);
            this.lblInventoryMeseta.Name = "lblInventoryMeseta";
            this.lblInventoryMeseta.Size = new System.Drawing.Size(47, 13);
            this.lblInventoryMeseta.TabIndex = 26;
            this.lblInventoryMeseta.Text = "Meseta";
            this.lblInventoryMeseta.Click += new System.EventHandler(this.txtInventoryMeseta_Click);
            // 
            // grpInventoryItemDetails
            // 
            this.grpInventoryItemDetails.BackColor = System.Drawing.Color.Transparent;
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
            this.grpInventoryItemDetails.Location = new System.Drawing.Point(324, 23);
            this.grpInventoryItemDetails.Name = "grpInventoryItemDetails";
            this.grpInventoryItemDetails.Size = new System.Drawing.Size(297, 154);
            this.grpInventoryItemDetails.TabIndex = 43;
            this.grpInventoryItemDetails.TabStop = false;
            this.grpInventoryItemDetails.Visible = false;
            // 
            // txtInventoryPercent
            // 
            this.txtInventoryPercent.AutoSize = true;
            this.txtInventoryPercent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtInventoryPercent.Location = new System.Drawing.Point(21, 48);
            this.txtInventoryPercent.Name = "txtInventoryPercent";
            this.txtInventoryPercent.Size = new System.Drawing.Size(26, 13);
            this.txtInventoryPercent.TabIndex = 31;
            this.txtInventoryPercent.Text = "0%";
            this.txtInventoryPercent.Click += new System.EventHandler(this.txtInventoryPercent_Click);
            // 
            // txtInventoryLevel
            // 
            this.txtInventoryLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryLevel.Location = new System.Drawing.Point(192, 116);
            this.txtInventoryLevel.Name = "txtInventoryLevel";
            this.txtInventoryLevel.Size = new System.Drawing.Size(99, 12);
            this.txtInventoryLevel.TabIndex = 73;
            this.txtInventoryLevel.Text = "LV100";
            this.txtInventoryLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInventoryACC
            // 
            this.txtInventoryACC.AutoSize = true;
            this.txtInventoryACC.Location = new System.Drawing.Point(12, 116);
            this.txtInventoryACC.Name = "txtInventoryACC";
            this.txtInventoryACC.Size = new System.Drawing.Size(41, 13);
            this.txtInventoryACC.TabIndex = 72;
            this.txtInventoryACC.Text = "ACC  ";
            // 
            // txtInventoryATK
            // 
            this.txtInventoryATK.AutoSize = true;
            this.txtInventoryATK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtInventoryATK.Location = new System.Drawing.Point(15, 101);
            this.txtInventoryATK.Name = "txtInventoryATK";
            this.txtInventoryATK.Size = new System.Drawing.Size(37, 13);
            this.txtInventoryATK.TabIndex = 71;
            this.txtInventoryATK.Text = "ATK  ";
            this.txtInventoryATK.Click += new System.EventHandler(this.txtInventoryATK_Click);
            // 
            // txtInventoryEffect
            // 
            this.txtInventoryEffect.AutoSize = true;
            this.txtInventoryEffect.Location = new System.Drawing.Point(6, 86);
            this.txtInventoryEffect.Name = "txtInventoryEffect";
            this.txtInventoryEffect.Size = new System.Drawing.Size(47, 13);
            this.txtInventoryEffect.TabIndex = 70;
            this.txtInventoryEffect.Text = "Effect  ";
            // 
            // txtInventorySpecial
            // 
            this.txtInventorySpecial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtInventorySpecial.Location = new System.Drawing.Point(3, 71);
            this.txtInventorySpecial.Name = "txtInventorySpecial";
            this.txtInventorySpecial.Size = new System.Drawing.Size(284, 13);
            this.txtInventorySpecial.TabIndex = 69;
            this.txtInventorySpecial.Text = "Ability  ";
            this.txtInventorySpecial.Click += new System.EventHandler(this.txtInventorySpecial_Click);
            // 
            // imgInventoryRank
            // 
            this.imgInventoryRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_S;
            this.imgInventoryRank.Location = new System.Drawing.Point(10, 15);
            this.imgInventoryRank.Name = "imgInventoryRank";
            this.imgInventoryRank.Size = new System.Drawing.Size(10, 10);
            this.imgInventoryRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryRank.TabIndex = 67;
            this.imgInventoryRank.TabStop = false;
            // 
            // imgStar15
            // 
            this.imgStar15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar15.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStar15.Location = new System.Drawing.Point(230, 133);
            this.imgStar15.Name = "imgStar15";
            this.imgStar15.Size = new System.Drawing.Size(16, 15);
            this.imgStar15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar15.TabIndex = 66;
            this.imgStar15.TabStop = false;
            this.imgStar15.Visible = false;
            // 
            // imgStar14
            // 
            this.imgStar14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar14.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStar14.Location = new System.Drawing.Point(215, 133);
            this.imgStar14.Name = "imgStar14";
            this.imgStar14.Size = new System.Drawing.Size(16, 15);
            this.imgStar14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar14.TabIndex = 65;
            this.imgStar14.TabStop = false;
            this.imgStar14.Visible = false;
            // 
            // imgStar13
            // 
            this.imgStar13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar13.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStar13.Location = new System.Drawing.Point(200, 133);
            this.imgStar13.Name = "imgStar13";
            this.imgStar13.Size = new System.Drawing.Size(16, 15);
            this.imgStar13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar13.TabIndex = 64;
            this.imgStar13.TabStop = false;
            this.imgStar13.Visible = false;
            // 
            // imgStar12
            // 
            this.imgStar12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar12.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStar12.Location = new System.Drawing.Point(185, 133);
            this.imgStar12.Name = "imgStar12";
            this.imgStar12.Size = new System.Drawing.Size(16, 15);
            this.imgStar12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar12.TabIndex = 63;
            this.imgStar12.TabStop = false;
            this.imgStar12.Visible = false;
            // 
            // imgStar11
            // 
            this.imgStar11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar11.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStar11.Location = new System.Drawing.Point(171, 133);
            this.imgStar11.Name = "imgStar11";
            this.imgStar11.Size = new System.Drawing.Size(16, 15);
            this.imgStar11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar11.TabIndex = 62;
            this.imgStar11.TabStop = false;
            this.imgStar11.Visible = false;
            // 
            // imgStar10
            // 
            this.imgStar10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar10.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStar10.Location = new System.Drawing.Point(156, 133);
            this.imgStar10.Name = "imgStar10";
            this.imgStar10.Size = new System.Drawing.Size(16, 15);
            this.imgStar10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar10.TabIndex = 61;
            this.imgStar10.TabStop = false;
            this.imgStar10.Visible = false;
            // 
            // imgStar9
            // 
            this.imgStar9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar9.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStar9.Location = new System.Drawing.Point(141, 133);
            this.imgStar9.Name = "imgStar9";
            this.imgStar9.Size = new System.Drawing.Size(16, 15);
            this.imgStar9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar9.TabIndex = 60;
            this.imgStar9.TabStop = false;
            this.imgStar9.Visible = false;
            // 
            // imgStar8
            // 
            this.imgStar8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar8.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStar8.Location = new System.Drawing.Point(126, 133);
            this.imgStar8.Name = "imgStar8";
            this.imgStar8.Size = new System.Drawing.Size(16, 15);
            this.imgStar8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar8.TabIndex = 59;
            this.imgStar8.TabStop = false;
            this.imgStar8.Visible = false;
            // 
            // imgStar7
            // 
            this.imgStar7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar7.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStar7.Location = new System.Drawing.Point(111, 133);
            this.imgStar7.Name = "imgStar7";
            this.imgStar7.Size = new System.Drawing.Size(16, 15);
            this.imgStar7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar7.TabIndex = 58;
            this.imgStar7.TabStop = false;
            this.imgStar7.Visible = false;
            // 
            // imgStar6
            // 
            this.imgStar6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar6.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStar6.Location = new System.Drawing.Point(96, 133);
            this.imgStar6.Name = "imgStar6";
            this.imgStar6.Size = new System.Drawing.Size(16, 15);
            this.imgStar6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar6.TabIndex = 57;
            this.imgStar6.TabStop = false;
            this.imgStar6.Visible = false;
            // 
            // imgStar5
            // 
            this.imgStar5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar5.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStar5.Location = new System.Drawing.Point(81, 133);
            this.imgStar5.Name = "imgStar5";
            this.imgStar5.Size = new System.Drawing.Size(16, 15);
            this.imgStar5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar5.TabIndex = 56;
            this.imgStar5.TabStop = false;
            this.imgStar5.Visible = false;
            // 
            // imgStar4
            // 
            this.imgStar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar4.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStar4.Location = new System.Drawing.Point(66, 133);
            this.imgStar4.Name = "imgStar4";
            this.imgStar4.Size = new System.Drawing.Size(16, 15);
            this.imgStar4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar4.TabIndex = 55;
            this.imgStar4.TabStop = false;
            this.imgStar4.Visible = false;
            // 
            // imgStar3
            // 
            this.imgStar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar3.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStar3.Location = new System.Drawing.Point(51, 133);
            this.imgStar3.Name = "imgStar3";
            this.imgStar3.Size = new System.Drawing.Size(16, 15);
            this.imgStar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar3.TabIndex = 54;
            this.imgStar3.TabStop = false;
            this.imgStar3.Visible = false;
            // 
            // imgStar2
            // 
            this.imgStar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar2.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStar2.Location = new System.Drawing.Point(36, 133);
            this.imgStar2.Name = "imgStar2";
            this.imgStar2.Size = new System.Drawing.Size(16, 15);
            this.imgStar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar2.TabIndex = 53;
            this.imgStar2.TabStop = false;
            this.imgStar2.Visible = false;
            // 
            // imgStar1
            // 
            this.imgStar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar1.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStar1.Location = new System.Drawing.Point(21, 133);
            this.imgStar1.Name = "imgStar1";
            this.imgStar1.Size = new System.Drawing.Size(16, 15);
            this.imgStar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar1.TabIndex = 52;
            this.imgStar1.TabStop = false;
            this.imgStar1.Visible = false;
            // 
            // imgStar0
            // 
            this.imgStar0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStar0.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStar0.Location = new System.Drawing.Point(6, 133);
            this.imgStar0.Name = "imgStar0";
            this.imgStar0.Size = new System.Drawing.Size(16, 15);
            this.imgStar0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStar0.TabIndex = 51;
            this.imgStar0.TabStop = false;
            this.imgStar0.Visible = false;
            // 
            // imgInventoryWeaponManufacturer
            // 
            this.imgInventoryWeaponManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgInventoryWeaponManufacturer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.manlogo_GRM;
            this.imgInventoryWeaponManufacturer.Location = new System.Drawing.Point(273, 12);
            this.imgInventoryWeaponManufacturer.Name = "imgInventoryWeaponManufacturer";
            this.imgInventoryWeaponManufacturer.Size = new System.Drawing.Size(17, 17);
            this.imgInventoryWeaponManufacturer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryWeaponManufacturer.TabIndex = 46;
            this.imgInventoryWeaponManufacturer.TabStop = false;
            // 
            // txtInventoryGrinds
            // 
            this.txtInventoryGrinds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryGrinds.Location = new System.Drawing.Point(81, 48);
            this.txtInventoryGrinds.Name = "txtInventoryGrinds";
            this.txtInventoryGrinds.Size = new System.Drawing.Size(210, 18);
            this.txtInventoryGrinds.TabIndex = 45;
            this.txtInventoryGrinds.Text = "(0)";
            this.txtInventoryGrinds.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInventoryName_jp
            // 
            this.txtInventoryName_jp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtInventoryName_jp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryName_jp.Location = new System.Drawing.Point(8, 30);
            this.txtInventoryName_jp.Name = "txtInventoryName_jp";
            this.txtInventoryName_jp.Size = new System.Drawing.Size(224, 18);
            this.txtInventoryName_jp.TabIndex = 44;
            this.txtInventoryName_jp.Text = "-";
            this.txtInventoryName_jp.Click += new System.EventHandler(this.txtInventoryName_jp_Click);
            // 
            // imgInventoryElement
            // 
            this.imgInventoryElement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgInventoryElement.Image = global::pspo2seSaveEditorProgram.Properties.Resources.element_neutral;
            this.imgInventoryElement.Location = new System.Drawing.Point(9, 49);
            this.imgInventoryElement.Name = "imgInventoryElement";
            this.imgInventoryElement.Size = new System.Drawing.Size(12, 12);
            this.imgInventoryElement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryElement.TabIndex = 41;
            this.imgInventoryElement.TabStop = false;
            this.imgInventoryElement.Click += new System.EventHandler(this.imgInventoryElement_Click);
            // 
            // txtInventoryQty
            // 
            this.txtInventoryQty.AutoSize = true;
            this.txtInventoryQty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtInventoryQty.Location = new System.Drawing.Point(6, 48);
            this.txtInventoryQty.Name = "txtInventoryQty";
            this.txtInventoryQty.Size = new System.Drawing.Size(26, 13);
            this.txtInventoryQty.TabIndex = 42;
            this.txtInventoryQty.Text = "0/0";
            this.txtInventoryQty.Click += new System.EventHandler(this.txtInventoryQty_Click);
            // 
            // imgInventoryItemIcon
            // 
            this.imgInventoryItemIcon.Image = global::pspo2seSaveEditorProgram.Properties.Resources.armor_icon;
            this.imgInventoryItemIcon.Location = new System.Drawing.Point(10, 15);
            this.imgInventoryItemIcon.Name = "imgInventoryItemIcon";
            this.imgInventoryItemIcon.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.imgInventoryItemIcon.Size = new System.Drawing.Size(23, 10);
            this.imgInventoryItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryItemIcon.TabIndex = 47;
            this.imgInventoryItemIcon.TabStop = false;
            // 
            // txtInventoryName
            // 
            this.txtInventoryName.Location = new System.Drawing.Point(21, 13);
            this.txtInventoryName.Name = "txtInventoryName";
            this.txtInventoryName.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.txtInventoryName.Size = new System.Drawing.Size(211, 18);
            this.txtInventoryName.TabIndex = 43;
            this.txtInventoryName.Text = "-";
            // 
            // txtInventoryInfinityItemText
            // 
            this.txtInventoryInfinityItemText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryInfinityItemText.AutoSize = true;
            this.txtInventoryInfinityItemText.Location = new System.Drawing.Point(274, 32);
            this.txtInventoryInfinityItemText.Name = "txtInventoryInfinityItemText";
            this.txtInventoryInfinityItemText.Size = new System.Drawing.Size(13, 13);
            this.txtInventoryInfinityItemText.TabIndex = 50;
            this.txtInventoryInfinityItemText.Text = "?";
            this.txtInventoryInfinityItemText.Visible = false;
            // 
            // imgInventoryInfinityItem
            // 
            this.imgInventoryInfinityItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgInventoryInfinityItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.infinity_item;
            this.imgInventoryInfinityItem.Location = new System.Drawing.Point(270, 31);
            this.imgInventoryInfinityItem.Name = "imgInventoryInfinityItem";
            this.imgInventoryInfinityItem.Size = new System.Drawing.Size(20, 16);
            this.imgInventoryInfinityItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInventoryInfinityItem.TabIndex = 49;
            this.imgInventoryInfinityItem.TabStop = false;
            this.imgInventoryInfinityItem.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(324, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 154);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // txtInventoryHex
            // 
            this.txtInventoryHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtInventoryHex.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryHex.Location = new System.Drawing.Point(323, 177);
            this.txtInventoryHex.Name = "txtInventoryHex";
            this.txtInventoryHex.Size = new System.Drawing.Size(97, 13);
            this.txtInventoryHex.TabIndex = 48;
            this.txtInventoryHex.Text = "0x00000000";
            this.txtInventoryHex.Click += new System.EventHandler(this.txtInventoryHex_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox7.Image = global::pspo2seSaveEditorProgram.Properties.Resources.item_meseta;
            this.pictureBox7.Location = new System.Drawing.Point(6, 184);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(10, 10);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 69;
            this.pictureBox7.TabStop = false;
            // 
            // inventoryView
            // 
            this.inventoryView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.inventoryView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inventoryView.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryView.FullRowSelect = true;
            this.inventoryView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.inventoryView.HideSelection = false;
            this.inventoryView.LabelWrap = false;
            this.inventoryView.Location = new System.Drawing.Point(5, 30);
            this.inventoryView.MultiSelect = false;
            this.inventoryView.Name = "inventoryView";
            this.inventoryView.Size = new System.Drawing.Size(313, 150);
            this.inventoryView.SmallImageList = this.weaponWithRankImageList;
            this.inventoryView.TabIndex = 77;
            this.inventoryView.UseCompatibleStateImageBehavior = false;
            this.inventoryView.View = System.Windows.Forms.View.Details;
            this.inventoryView.SelectedIndexChanged += new System.EventHandler(this.inventoryView_SelectedIndexChanged);
            this.inventoryView.Click += new System.EventHandler(this.inventoryView_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 291;
            // 
            // weaponWithRankImageList
            // 
            this.weaponWithRankImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("weaponWithRankImageList.ImageStream")));
            this.weaponWithRankImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            this.weaponWithRankImageList.Images.SetKeyName(127, "unk_016_longbow.jpg");
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
            this.weaponWithRankImageList.Images.SetKeyName(255, "unk_004_double_saber.jpg");
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
            // 
            // tabPageStorage
            // 
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
            this.tabPageStorage.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPageStorage.Location = new System.Drawing.Point(4, 22);
            this.tabPageStorage.Name = "tabPageStorage";
            this.tabPageStorage.Size = new System.Drawing.Size(629, 223);
            this.tabPageStorage.TabIndex = 5;
            this.tabPageStorage.Text = "Shared (0/0)";
            this.tabPageStorage.UseVisualStyleBackColor = true;
            // 
            // btnStorageDelete
            // 
            this.btnStorageDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStorageDelete.Enabled = false;
            this.btnStorageDelete.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageDelete.Location = new System.Drawing.Point(391, 177);
            this.btnStorageDelete.Name = "btnStorageDelete";
            this.btnStorageDelete.Size = new System.Drawing.Size(46, 21);
            this.btnStorageDelete.TabIndex = 77;
            this.btnStorageDelete.Text = "delete";
            this.btnStorageDelete.UseVisualStyleBackColor = true;
            this.btnStorageDelete.Click += new System.EventHandler(this.btnStorageDelete_Click);
            // 
            // chkDeleteExportStorage
            // 
            this.chkDeleteExportStorage.AutoSize = true;
            this.chkDeleteExportStorage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDeleteExportStorage.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteExportStorage.Location = new System.Drawing.Point(497, 206);
            this.chkDeleteExportStorage.Name = "chkDeleteExportStorage";
            this.chkDeleteExportStorage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDeleteExportStorage.Size = new System.Drawing.Size(125, 14);
            this.chkDeleteExportStorage.TabIndex = 74;
            this.chkDeleteExportStorage.Text = "delete items after export";
            this.chkDeleteExportStorage.UseVisualStyleBackColor = true;
            // 
            // btnStorageWithdraw
            // 
            this.btnStorageWithdraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStorageWithdraw.Enabled = false;
            this.btnStorageWithdraw.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageWithdraw.Location = new System.Drawing.Point(566, 177);
            this.btnStorageWithdraw.Name = "btnStorageWithdraw";
            this.btnStorageWithdraw.Size = new System.Drawing.Size(56, 21);
            this.btnStorageWithdraw.TabIndex = 73;
            this.btnStorageWithdraw.Text = "withdraw";
            this.btnStorageWithdraw.UseVisualStyleBackColor = true;
            this.btnStorageWithdraw.Click += new System.EventHandler(this.btnStorageWithdraw_Click);
            // 
            // storageViewPages
            // 
            this.storageViewPages.Controls.Add(this.tabStorage1);
            this.storageViewPages.Controls.Add(this.tabStorage2);
            this.storageViewPages.Controls.Add(this.tabStorage3);
            this.storageViewPages.Controls.Add(this.tabStorage4);
            this.storageViewPages.Controls.Add(this.tabStorage5);
            this.storageViewPages.Controls.Add(this.tabStorage6);
            this.storageViewPages.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storageViewPages.Location = new System.Drawing.Point(5, 12);
            this.storageViewPages.Name = "storageViewPages";
            this.storageViewPages.SelectedIndex = 0;
            this.storageViewPages.Size = new System.Drawing.Size(315, 19);
            this.storageViewPages.TabIndex = 72;
            this.storageViewPages.SelectedIndexChanged += new System.EventHandler(this.storageViewPages_SelectedIndexChanged);
            // 
            // tabStorage1
            // 
            this.tabStorage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabStorage1.Location = new System.Drawing.Point(4, 19);
            this.tabStorage1.Name = "tabStorage1";
            this.tabStorage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabStorage1.Size = new System.Drawing.Size(307, 0);
            this.tabStorage1.TabIndex = 0;
            this.tabStorage1.Text = "1";
            this.tabStorage1.UseVisualStyleBackColor = true;
            // 
            // tabStorage2
            // 
            this.tabStorage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabStorage2.Location = new System.Drawing.Point(4, 19);
            this.tabStorage2.Name = "tabStorage2";
            this.tabStorage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabStorage2.Size = new System.Drawing.Size(307, 0);
            this.tabStorage2.TabIndex = 1;
            this.tabStorage2.Text = "2";
            this.tabStorage2.UseVisualStyleBackColor = true;
            // 
            // tabStorage3
            // 
            this.tabStorage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabStorage3.Location = new System.Drawing.Point(4, 19);
            this.tabStorage3.Name = "tabStorage3";
            this.tabStorage3.Size = new System.Drawing.Size(307, 0);
            this.tabStorage3.TabIndex = 2;
            this.tabStorage3.Text = "3";
            this.tabStorage3.UseVisualStyleBackColor = true;
            // 
            // tabStorage4
            // 
            this.tabStorage4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabStorage4.Location = new System.Drawing.Point(4, 19);
            this.tabStorage4.Name = "tabStorage4";
            this.tabStorage4.Size = new System.Drawing.Size(307, 0);
            this.tabStorage4.TabIndex = 3;
            this.tabStorage4.Text = "4";
            this.tabStorage4.UseVisualStyleBackColor = true;
            // 
            // tabStorage5
            // 
            this.tabStorage5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabStorage5.Location = new System.Drawing.Point(4, 19);
            this.tabStorage5.Name = "tabStorage5";
            this.tabStorage5.Size = new System.Drawing.Size(307, 0);
            this.tabStorage5.TabIndex = 4;
            this.tabStorage5.Text = "5";
            this.tabStorage5.UseVisualStyleBackColor = true;
            // 
            // tabStorage6
            // 
            this.tabStorage6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabStorage6.Location = new System.Drawing.Point(4, 19);
            this.tabStorage6.Name = "tabStorage6";
            this.tabStorage6.Size = new System.Drawing.Size(307, 0);
            this.tabStorage6.TabIndex = 5;
            this.tabStorage6.Text = "Free Slots";
            this.tabStorage6.UseVisualStyleBackColor = true;
            // 
            // storageView
            // 
            this.storageView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.storageView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.storageView.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storageView.FullRowSelect = true;
            this.storageView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.storageView.HideSelection = false;
            this.storageView.LabelWrap = false;
            this.storageView.Location = new System.Drawing.Point(5, 30);
            this.storageView.MultiSelect = false;
            this.storageView.Name = "storageView";
            this.storageView.Size = new System.Drawing.Size(313, 150);
            this.storageView.SmallImageList = this.weaponWithRankImageList;
            this.storageView.TabIndex = 71;
            this.storageView.UseCompatibleStateImageBehavior = false;
            this.storageView.View = System.Windows.Forms.View.Details;
            this.storageView.SelectedIndexChanged += new System.EventHandler(this.storageView_SelectedIndexChanged);
            this.storageView.Click += new System.EventHandler(this.storageView_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 291;
            // 
            // btnStorageImportAll
            // 
            this.btnStorageImportAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStorageImportAll.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageImportAll.Location = new System.Drawing.Point(152, 183);
            this.btnStorageImportAll.Name = "btnStorageImportAll";
            this.btnStorageImportAll.Size = new System.Drawing.Size(82, 21);
            this.btnStorageImportAll.TabIndex = 70;
            this.btnStorageImportAll.Text = "import storage";
            this.btnStorageImportAll.UseVisualStyleBackColor = true;
            this.btnStorageImportAll.Click += new System.EventHandler(this.btnStorageImportAll_Click);
            // 
            // btnStorageExportAll
            // 
            this.btnStorageExportAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStorageExportAll.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageExportAll.Location = new System.Drawing.Point(236, 183);
            this.btnStorageExportAll.Name = "btnStorageExportAll";
            this.btnStorageExportAll.Size = new System.Drawing.Size(82, 21);
            this.btnStorageExportAll.TabIndex = 69;
            this.btnStorageExportAll.Text = "export storage";
            this.btnStorageExportAll.UseVisualStyleBackColor = true;
            this.btnStorageExportAll.Click += new System.EventHandler(this.btnStorageExportAll_Click);
            // 
            // btnStorageImportSelected
            // 
            this.btnStorageImportSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStorageImportSelected.Enabled = false;
            this.btnStorageImportSelected.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageImportSelected.Location = new System.Drawing.Point(437, 177);
            this.btnStorageImportSelected.Name = "btnStorageImportSelected";
            this.btnStorageImportSelected.Size = new System.Drawing.Size(67, 21);
            this.btnStorageImportSelected.TabIndex = 28;
            this.btnStorageImportSelected.Text = "import item";
            this.btnStorageImportSelected.UseVisualStyleBackColor = true;
            this.btnStorageImportSelected.Click += new System.EventHandler(this.btnStorageImportSelected_Click);
            // 
            // btnStorageExportSelected
            // 
            this.btnStorageExportSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStorageExportSelected.Enabled = false;
            this.btnStorageExportSelected.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageExportSelected.Location = new System.Drawing.Point(504, 177);
            this.btnStorageExportSelected.Name = "btnStorageExportSelected";
            this.btnStorageExportSelected.Size = new System.Drawing.Size(62, 21);
            this.btnStorageExportSelected.TabIndex = 27;
            this.btnStorageExportSelected.Text = "export item";
            this.btnStorageExportSelected.UseVisualStyleBackColor = true;
            this.btnStorageExportSelected.Click += new System.EventHandler(this.btnStorageExportSelected_Click);
            // 
            // txtStorageMeseta
            // 
            this.txtStorageMeseta.AutoSize = true;
            this.txtStorageMeseta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStorageMeseta.Location = new System.Drawing.Point(60, 182);
            this.txtStorageMeseta.Name = "txtStorageMeseta";
            this.txtStorageMeseta.Size = new System.Drawing.Size(14, 13);
            this.txtStorageMeseta.TabIndex = 50;
            this.txtStorageMeseta.Text = "0";
            this.txtStorageMeseta.Click += new System.EventHandler(this.txtStorageMeseta_Click);
            // 
            // lblStorageMeseta
            // 
            this.lblStorageMeseta.AutoSize = true;
            this.lblStorageMeseta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStorageMeseta.Location = new System.Drawing.Point(16, 182);
            this.lblStorageMeseta.Name = "lblStorageMeseta";
            this.lblStorageMeseta.Size = new System.Drawing.Size(47, 13);
            this.lblStorageMeseta.TabIndex = 49;
            this.lblStorageMeseta.Text = "Meseta";
            this.lblStorageMeseta.Click += new System.EventHandler(this.txtStorageMeseta_Click);
            // 
            // grpStorageItemDetails
            // 
            this.grpStorageItemDetails.BackColor = System.Drawing.Color.Transparent;
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
            this.grpStorageItemDetails.Location = new System.Drawing.Point(324, 23);
            this.grpStorageItemDetails.Name = "grpStorageItemDetails";
            this.grpStorageItemDetails.Size = new System.Drawing.Size(297, 154);
            this.grpStorageItemDetails.TabIndex = 52;
            this.grpStorageItemDetails.TabStop = false;
            this.grpStorageItemDetails.Visible = false;
            // 
            // txtStoragePercent
            // 
            this.txtStoragePercent.AutoSize = true;
            this.txtStoragePercent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStoragePercent.Location = new System.Drawing.Point(21, 48);
            this.txtStoragePercent.Name = "txtStoragePercent";
            this.txtStoragePercent.Size = new System.Drawing.Size(26, 13);
            this.txtStoragePercent.TabIndex = 31;
            this.txtStoragePercent.Text = "0%";
            this.txtStoragePercent.Click += new System.EventHandler(this.txtStoragePercent_Click);
            // 
            // txtStorageLevel
            // 
            this.txtStorageLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStorageLevel.Location = new System.Drawing.Point(192, 116);
            this.txtStorageLevel.Name = "txtStorageLevel";
            this.txtStorageLevel.Size = new System.Drawing.Size(99, 17);
            this.txtStorageLevel.TabIndex = 75;
            this.txtStorageLevel.Text = "LV100";
            this.txtStorageLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStorageACC
            // 
            this.txtStorageACC.AutoSize = true;
            this.txtStorageACC.Location = new System.Drawing.Point(12, 116);
            this.txtStorageACC.Name = "txtStorageACC";
            this.txtStorageACC.Size = new System.Drawing.Size(41, 13);
            this.txtStorageACC.TabIndex = 74;
            this.txtStorageACC.Text = "ACC  ";
            // 
            // txtStorageATK
            // 
            this.txtStorageATK.AutoSize = true;
            this.txtStorageATK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStorageATK.Location = new System.Drawing.Point(15, 101);
            this.txtStorageATK.Name = "txtStorageATK";
            this.txtStorageATK.Size = new System.Drawing.Size(37, 13);
            this.txtStorageATK.TabIndex = 73;
            this.txtStorageATK.Text = "ATK  ";
            this.txtStorageATK.Click += new System.EventHandler(this.txtStorageATK_Click);
            // 
            // txtStorageEffect
            // 
            this.txtStorageEffect.AutoSize = true;
            this.txtStorageEffect.Location = new System.Drawing.Point(6, 86);
            this.txtStorageEffect.Name = "txtStorageEffect";
            this.txtStorageEffect.Size = new System.Drawing.Size(47, 13);
            this.txtStorageEffect.TabIndex = 72;
            this.txtStorageEffect.Text = "Effect  ";
            // 
            // txtStorageSpecial
            // 
            this.txtStorageSpecial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStorageSpecial.Location = new System.Drawing.Point(3, 71);
            this.txtStorageSpecial.Name = "txtStorageSpecial";
            this.txtStorageSpecial.Size = new System.Drawing.Size(278, 14);
            this.txtStorageSpecial.TabIndex = 71;
            this.txtStorageSpecial.Text = "Ability  ";
            this.txtStorageSpecial.Click += new System.EventHandler(this.txtStorageSpecial_Click);
            // 
            // imgStorageRank
            // 
            this.imgStorageRank.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_S;
            this.imgStorageRank.Location = new System.Drawing.Point(10, 15);
            this.imgStorageRank.Name = "imgStorageRank";
            this.imgStorageRank.Size = new System.Drawing.Size(10, 10);
            this.imgStorageRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageRank.TabIndex = 67;
            this.imgStorageRank.TabStop = false;
            // 
            // imgStorageStar15
            // 
            this.imgStorageStar15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar15.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStorageStar15.Location = new System.Drawing.Point(230, 133);
            this.imgStorageStar15.Name = "imgStorageStar15";
            this.imgStorageStar15.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar15.TabIndex = 66;
            this.imgStorageStar15.TabStop = false;
            this.imgStorageStar15.Visible = false;
            // 
            // imgStorageStar14
            // 
            this.imgStorageStar14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar14.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStorageStar14.Location = new System.Drawing.Point(215, 133);
            this.imgStorageStar14.Name = "imgStorageStar14";
            this.imgStorageStar14.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar14.TabIndex = 65;
            this.imgStorageStar14.TabStop = false;
            this.imgStorageStar14.Visible = false;
            // 
            // imgStorageStar13
            // 
            this.imgStorageStar13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar13.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStorageStar13.Location = new System.Drawing.Point(200, 133);
            this.imgStorageStar13.Name = "imgStorageStar13";
            this.imgStorageStar13.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar13.TabIndex = 64;
            this.imgStorageStar13.TabStop = false;
            this.imgStorageStar13.Visible = false;
            // 
            // imgStorageStar12
            // 
            this.imgStorageStar12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar12.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.imgStorageStar12.Location = new System.Drawing.Point(185, 133);
            this.imgStorageStar12.Name = "imgStorageStar12";
            this.imgStorageStar12.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar12.TabIndex = 63;
            this.imgStorageStar12.TabStop = false;
            this.imgStorageStar12.Visible = false;
            // 
            // imgStorageStar11
            // 
            this.imgStorageStar11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar11.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStorageStar11.Location = new System.Drawing.Point(171, 133);
            this.imgStorageStar11.Name = "imgStorageStar11";
            this.imgStorageStar11.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar11.TabIndex = 62;
            this.imgStorageStar11.TabStop = false;
            this.imgStorageStar11.Visible = false;
            // 
            // imgStorageStar10
            // 
            this.imgStorageStar10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar10.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStorageStar10.Location = new System.Drawing.Point(156, 133);
            this.imgStorageStar10.Name = "imgStorageStar10";
            this.imgStorageStar10.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar10.TabIndex = 61;
            this.imgStorageStar10.TabStop = false;
            this.imgStorageStar10.Visible = false;
            // 
            // imgStorageStar9
            // 
            this.imgStorageStar9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar9.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.imgStorageStar9.Location = new System.Drawing.Point(141, 133);
            this.imgStorageStar9.Name = "imgStorageStar9";
            this.imgStorageStar9.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar9.TabIndex = 60;
            this.imgStorageStar9.TabStop = false;
            this.imgStorageStar9.Visible = false;
            // 
            // imgStorageStar8
            // 
            this.imgStorageStar8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar8.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStorageStar8.Location = new System.Drawing.Point(126, 133);
            this.imgStorageStar8.Name = "imgStorageStar8";
            this.imgStorageStar8.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar8.TabIndex = 59;
            this.imgStorageStar8.TabStop = false;
            this.imgStorageStar8.Visible = false;
            // 
            // imgStorageStar7
            // 
            this.imgStorageStar7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar7.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStorageStar7.Location = new System.Drawing.Point(111, 133);
            this.imgStorageStar7.Name = "imgStorageStar7";
            this.imgStorageStar7.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar7.TabIndex = 58;
            this.imgStorageStar7.TabStop = false;
            this.imgStorageStar7.Visible = false;
            // 
            // imgStorageStar6
            // 
            this.imgStorageStar6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar6.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.imgStorageStar6.Location = new System.Drawing.Point(96, 133);
            this.imgStorageStar6.Name = "imgStorageStar6";
            this.imgStorageStar6.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar6.TabIndex = 57;
            this.imgStorageStar6.TabStop = false;
            this.imgStorageStar6.Visible = false;
            // 
            // imgStorageStar5
            // 
            this.imgStorageStar5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar5.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStorageStar5.Location = new System.Drawing.Point(81, 133);
            this.imgStorageStar5.Name = "imgStorageStar5";
            this.imgStorageStar5.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar5.TabIndex = 56;
            this.imgStorageStar5.TabStop = false;
            this.imgStorageStar5.Visible = false;
            // 
            // imgStorageStar4
            // 
            this.imgStorageStar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar4.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStorageStar4.Location = new System.Drawing.Point(66, 133);
            this.imgStorageStar4.Name = "imgStorageStar4";
            this.imgStorageStar4.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar4.TabIndex = 55;
            this.imgStorageStar4.TabStop = false;
            this.imgStorageStar4.Visible = false;
            // 
            // imgStorageStar3
            // 
            this.imgStorageStar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar3.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.imgStorageStar3.Location = new System.Drawing.Point(51, 133);
            this.imgStorageStar3.Name = "imgStorageStar3";
            this.imgStorageStar3.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar3.TabIndex = 54;
            this.imgStorageStar3.TabStop = false;
            this.imgStorageStar3.Visible = false;
            // 
            // imgStorageStar2
            // 
            this.imgStorageStar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar2.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStorageStar2.Location = new System.Drawing.Point(36, 133);
            this.imgStorageStar2.Name = "imgStorageStar2";
            this.imgStorageStar2.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar2.TabIndex = 53;
            this.imgStorageStar2.TabStop = false;
            this.imgStorageStar2.Visible = false;
            // 
            // imgStorageStar1
            // 
            this.imgStorageStar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar1.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStorageStar1.Location = new System.Drawing.Point(21, 133);
            this.imgStorageStar1.Name = "imgStorageStar1";
            this.imgStorageStar1.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar1.TabIndex = 52;
            this.imgStorageStar1.TabStop = false;
            this.imgStorageStar1.Visible = false;
            // 
            // imgStorageStar0
            // 
            this.imgStorageStar0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStorageStar0.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.imgStorageStar0.Location = new System.Drawing.Point(6, 133);
            this.imgStorageStar0.Name = "imgStorageStar0";
            this.imgStorageStar0.Size = new System.Drawing.Size(16, 15);
            this.imgStorageStar0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageStar0.TabIndex = 51;
            this.imgStorageStar0.TabStop = false;
            this.imgStorageStar0.Visible = false;
            // 
            // imgStorageWeaponManufacturer
            // 
            this.imgStorageWeaponManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgStorageWeaponManufacturer.Image = global::pspo2seSaveEditorProgram.Properties.Resources.manlogo_GRM;
            this.imgStorageWeaponManufacturer.Location = new System.Drawing.Point(273, 12);
            this.imgStorageWeaponManufacturer.Name = "imgStorageWeaponManufacturer";
            this.imgStorageWeaponManufacturer.Size = new System.Drawing.Size(17, 17);
            this.imgStorageWeaponManufacturer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageWeaponManufacturer.TabIndex = 46;
            this.imgStorageWeaponManufacturer.TabStop = false;
            // 
            // txtStorageGrinds
            // 
            this.txtStorageGrinds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStorageGrinds.Location = new System.Drawing.Point(81, 48);
            this.txtStorageGrinds.Name = "txtStorageGrinds";
            this.txtStorageGrinds.Size = new System.Drawing.Size(210, 18);
            this.txtStorageGrinds.TabIndex = 45;
            this.txtStorageGrinds.Text = "(0)";
            this.txtStorageGrinds.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStorageName_jp
            // 
            this.txtStorageName_jp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStorageName_jp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStorageName_jp.Location = new System.Drawing.Point(8, 30);
            this.txtStorageName_jp.Name = "txtStorageName_jp";
            this.txtStorageName_jp.Size = new System.Drawing.Size(224, 18);
            this.txtStorageName_jp.TabIndex = 44;
            this.txtStorageName_jp.Text = "-";
            this.txtStorageName_jp.Click += new System.EventHandler(this.txtStorageName_jp_Click);
            // 
            // imgStorageItemIcon
            // 
            this.imgStorageItemIcon.Image = global::pspo2seSaveEditorProgram.Properties.Resources.armor_icon;
            this.imgStorageItemIcon.Location = new System.Drawing.Point(10, 15);
            this.imgStorageItemIcon.Name = "imgStorageItemIcon";
            this.imgStorageItemIcon.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.imgStorageItemIcon.Size = new System.Drawing.Size(23, 10);
            this.imgStorageItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageItemIcon.TabIndex = 47;
            this.imgStorageItemIcon.TabStop = false;
            // 
            // txtStorageName
            // 
            this.txtStorageName.Location = new System.Drawing.Point(21, 13);
            this.txtStorageName.Name = "txtStorageName";
            this.txtStorageName.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.txtStorageName.Size = new System.Drawing.Size(211, 18);
            this.txtStorageName.TabIndex = 43;
            this.txtStorageName.Text = "-";
            // 
            // imgStorageElement
            // 
            this.imgStorageElement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgStorageElement.Image = global::pspo2seSaveEditorProgram.Properties.Resources.element_neutral;
            this.imgStorageElement.Location = new System.Drawing.Point(9, 49);
            this.imgStorageElement.Name = "imgStorageElement";
            this.imgStorageElement.Size = new System.Drawing.Size(12, 12);
            this.imgStorageElement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageElement.TabIndex = 41;
            this.imgStorageElement.TabStop = false;
            this.imgStorageElement.Click += new System.EventHandler(this.imgStorageElement_Click);
            // 
            // txtStorageQty
            // 
            this.txtStorageQty.AutoSize = true;
            this.txtStorageQty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStorageQty.Location = new System.Drawing.Point(6, 48);
            this.txtStorageQty.Name = "txtStorageQty";
            this.txtStorageQty.Size = new System.Drawing.Size(26, 13);
            this.txtStorageQty.TabIndex = 42;
            this.txtStorageQty.Text = "0/0";
            this.txtStorageQty.Click += new System.EventHandler(this.txtStorageQty_Click);
            // 
            // txtStorageInfinityItemText
            // 
            this.txtStorageInfinityItemText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStorageInfinityItemText.AutoSize = true;
            this.txtStorageInfinityItemText.Location = new System.Drawing.Point(274, 32);
            this.txtStorageInfinityItemText.Name = "txtStorageInfinityItemText";
            this.txtStorageInfinityItemText.Size = new System.Drawing.Size(13, 13);
            this.txtStorageInfinityItemText.TabIndex = 50;
            this.txtStorageInfinityItemText.Text = "?";
            this.txtStorageInfinityItemText.Visible = false;
            // 
            // imgStorageInfinityItem
            // 
            this.imgStorageInfinityItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgStorageInfinityItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.infinity_item;
            this.imgStorageInfinityItem.Location = new System.Drawing.Point(270, 31);
            this.imgStorageInfinityItem.Name = "imgStorageInfinityItem";
            this.imgStorageInfinityItem.Size = new System.Drawing.Size(20, 16);
            this.imgStorageInfinityItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStorageInfinityItem.TabIndex = 49;
            this.imgStorageInfinityItem.TabStop = false;
            this.imgStorageInfinityItem.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(324, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 154);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // txtStorageHex
            // 
            this.txtStorageHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStorageHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStorageHex.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStorageHex.Location = new System.Drawing.Point(323, 177);
            this.txtStorageHex.Name = "txtStorageHex";
            this.txtStorageHex.Size = new System.Drawing.Size(97, 13);
            this.txtStorageHex.TabIndex = 53;
            this.txtStorageHex.Text = "0x00000000";
            this.txtStorageHex.Click += new System.EventHandler(this.txtStorageHex_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox6.Image = global::pspo2seSaveEditorProgram.Properties.Resources.item_meseta;
            this.pictureBox6.Location = new System.Drawing.Point(6, 184);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(10, 10);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 68;
            this.pictureBox6.TabStop = false;
            // 
            // tabPageMissions
            // 
            this.tabPageMissions.Controls.Add(this.tabControlMissions);
            this.tabPageMissions.Location = new System.Drawing.Point(4, 22);
            this.tabPageMissions.Name = "tabPageMissions";
            this.tabPageMissions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMissions.Size = new System.Drawing.Size(629, 223);
            this.tabPageMissions.TabIndex = 7;
            this.tabPageMissions.Text = "Mission";
            this.tabPageMissions.UseVisualStyleBackColor = true;
            // 
            // tabControlMissions
            // 
            this.tabControlMissions.Controls.Add(this.tabEp1Missions);
            this.tabControlMissions.Controls.Add(this.tabEp2Missions);
            this.tabControlMissions.Controls.Add(this.tabPageInfinityMission);
            this.tabControlMissions.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMissions.Location = new System.Drawing.Point(4, 3);
            this.tabControlMissions.Name = "tabControlMissions";
            this.tabControlMissions.SelectedIndex = 0;
            this.tabControlMissions.Size = new System.Drawing.Size(618, 217);
            this.tabControlMissions.TabIndex = 0;
            // 
            // tabEp1Missions
            // 
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
            this.tabEp1Missions.Location = new System.Drawing.Point(4, 21);
            this.tabEp1Missions.Name = "tabEp1Missions";
            this.tabEp1Missions.Padding = new System.Windows.Forms.Padding(3);
            this.tabEp1Missions.Size = new System.Drawing.Size(610, 192);
            this.tabEp1Missions.TabIndex = 0;
            this.tabEp1Missions.Text = "Episode 1";
            this.tabEp1Missions.UseVisualStyleBackColor = true;
            this.tabEp1Missions.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            // 
            // txtAllowQuitMission
            // 
            this.txtAllowQuitMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtAllowQuitMission.ForeColor = System.Drawing.Color.DarkRed;
            this.txtAllowQuitMission.Location = new System.Drawing.Point(144, 85);
            this.txtAllowQuitMission.Name = "txtAllowQuitMission";
            this.txtAllowQuitMission.Size = new System.Drawing.Size(37, 13);
            this.txtAllowQuitMission.TabIndex = 101;
            this.txtAllowQuitMission.Text = "No";
            this.txtAllowQuitMission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAllowQuitMission.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtAllowQuitMission.Click += new System.EventHandler(this.txtAllowQuitMission_Click);
            // 
            // label47
            // 
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(2, 85);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(143, 13);
            this.label47.TabIndex = 100;
            this.label47.Text = "Allow Quit Mission";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEp1Complete
            // 
            this.txtEp1Complete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtEp1Complete.ForeColor = System.Drawing.Color.DarkRed;
            this.txtEp1Complete.Location = new System.Drawing.Point(144, 70);
            this.txtEp1Complete.Name = "txtEp1Complete";
            this.txtEp1Complete.Size = new System.Drawing.Size(37, 13);
            this.txtEp1Complete.TabIndex = 99;
            this.txtEp1Complete.Text = "No";
            this.txtEp1Complete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtEp1Complete.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtEp1Complete.Click += new System.EventHandler(this.txtEp1Complete_Click);
            // 
            // label44
            // 
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(2, 70);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(143, 13);
            this.label44.TabIndex = 98;
            this.label44.Text = "Episode Complete";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStoryEmiliaPoints
            // 
            this.txtStoryEmiliaPoints.AutoSize = true;
            this.txtStoryEmiliaPoints.BackColor = System.Drawing.Color.Transparent;
            this.txtStoryEmiliaPoints.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStoryEmiliaPoints.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoryEmiliaPoints.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtStoryEmiliaPoints.Location = new System.Drawing.Point(479, 13);
            this.txtStoryEmiliaPoints.Name = "txtStoryEmiliaPoints";
            this.txtStoryEmiliaPoints.Size = new System.Drawing.Size(86, 14);
            this.txtStoryEmiliaPoints.TabIndex = 97;
            this.txtStoryEmiliaPoints.Text = "Emilia Points";
            this.txtStoryEmiliaPoints.Visible = false;
            this.txtStoryEmiliaPoints.Click += new System.EventHandler(this.TxtStoryEmiliaPoints_Click);
            // 
            // txtMissionTactical
            // 
            this.txtMissionTactical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMissionTactical.ForeColor = System.Drawing.Color.DarkRed;
            this.txtMissionTactical.Location = new System.Drawing.Point(173, 172);
            this.txtMissionTactical.Name = "txtMissionTactical";
            this.txtMissionTactical.Size = new System.Drawing.Size(37, 13);
            this.txtMissionTactical.TabIndex = 96;
            this.txtMissionTactical.Text = "No";
            this.txtMissionTactical.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMissionTactical.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtMissionTactical.Click += new System.EventHandler(this.txtMissionUnknown_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Unknown Missions Unlocked  ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMissionMagashi
            // 
            this.txtMissionMagashi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMissionMagashi.ForeColor = System.Drawing.Color.DarkRed;
            this.txtMissionMagashi.Location = new System.Drawing.Point(144, 43);
            this.txtMissionMagashi.Name = "txtMissionMagashi";
            this.txtMissionMagashi.Size = new System.Drawing.Size(37, 13);
            this.txtMissionMagashi.TabIndex = 94;
            this.txtMissionMagashi.Text = "No";
            this.txtMissionMagashi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMissionMagashi.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtMissionMagashi.Click += new System.EventHandler(this.txtMissionMagashi_Click);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(3, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 13);
            this.label13.TabIndex = 93;
            this.label13.Text = "Magashi Plan Unlocked  ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSkipEp1Start
            // 
            this.txtSkipEp1Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSkipEp1Start.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSkipEp1Start.Location = new System.Drawing.Point(144, 13);
            this.txtSkipEp1Start.Name = "txtSkipEp1Start";
            this.txtSkipEp1Start.Size = new System.Drawing.Size(37, 13);
            this.txtSkipEp1Start.TabIndex = 92;
            this.txtSkipEp1Start.Text = "No";
            this.txtSkipEp1Start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSkipEp1Start.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtSkipEp1Start.Click += new System.EventHandler(this.txtSkipEp1Start_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 13);
            this.label12.TabIndex = 91;
            this.label12.Text = "Skip Start Sequence  ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMissionEp1
            // 
            this.txtMissionEp1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMissionEp1.ForeColor = System.Drawing.Color.DarkRed;
            this.txtMissionEp1.Location = new System.Drawing.Point(144, 28);
            this.txtMissionEp1.Name = "txtMissionEp1";
            this.txtMissionEp1.Size = new System.Drawing.Size(37, 13);
            this.txtMissionEp1.TabIndex = 90;
            this.txtMissionEp1.Text = "No";
            this.txtMissionEp1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMissionEp1.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtMissionEp1.Click += new System.EventHandler(this.txtMissionEp1_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "All Missions Unlocked  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabEp2Missions
            // 
            this.tabEp2Missions.Controls.Add(this.txtEp2Complete);
            this.tabEp2Missions.Controls.Add(this.label46);
            this.tabEp2Missions.Controls.Add(this.txtStoryNagisaPoints);
            this.tabEp2Missions.Controls.Add(this.txtSkipEp2Start);
            this.tabEp2Missions.Controls.Add(this.lblSkipEp2Start);
            this.tabEp2Missions.Controls.Add(this.txtMissionEp2);
            this.tabEp2Missions.Controls.Add(this.lblMissionEp2);
            this.tabEp2Missions.Location = new System.Drawing.Point(4, 21);
            this.tabEp2Missions.Name = "tabEp2Missions";
            this.tabEp2Missions.Padding = new System.Windows.Forms.Padding(3);
            this.tabEp2Missions.Size = new System.Drawing.Size(610, 192);
            this.tabEp2Missions.TabIndex = 1;
            this.tabEp2Missions.Text = "Episode 2";
            this.tabEp2Missions.UseVisualStyleBackColor = true;
            // 
            // txtEp2Complete
            // 
            this.txtEp2Complete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtEp2Complete.ForeColor = System.Drawing.Color.DarkRed;
            this.txtEp2Complete.Location = new System.Drawing.Point(144, 62);
            this.txtEp2Complete.Name = "txtEp2Complete";
            this.txtEp2Complete.Size = new System.Drawing.Size(37, 13);
            this.txtEp2Complete.TabIndex = 101;
            this.txtEp2Complete.Text = "No";
            this.txtEp2Complete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtEp2Complete.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtEp2Complete.Click += new System.EventHandler(this.txtEp2Complete_Click);
            // 
            // label46
            // 
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(2, 62);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(143, 13);
            this.label46.TabIndex = 100;
            this.label46.Text = "Episode Complete";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStoryNagisaPoints
            // 
            this.txtStoryNagisaPoints.AutoSize = true;
            this.txtStoryNagisaPoints.BackColor = System.Drawing.Color.Transparent;
            this.txtStoryNagisaPoints.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStoryNagisaPoints.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoryNagisaPoints.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtStoryNagisaPoints.Location = new System.Drawing.Point(472, 13);
            this.txtStoryNagisaPoints.Name = "txtStoryNagisaPoints";
            this.txtStoryNagisaPoints.Size = new System.Drawing.Size(93, 14);
            this.txtStoryNagisaPoints.TabIndex = 91;
            this.txtStoryNagisaPoints.Text = "Nagisa Points";
            this.txtStoryNagisaPoints.Visible = false;
            this.txtStoryNagisaPoints.Click += new System.EventHandler(this.TxtStoryNagisaPoints_Click);
            // 
            // txtSkipEp2Start
            // 
            this.txtSkipEp2Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSkipEp2Start.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSkipEp2Start.Location = new System.Drawing.Point(144, 13);
            this.txtSkipEp2Start.Name = "txtSkipEp2Start";
            this.txtSkipEp2Start.Size = new System.Drawing.Size(37, 13);
            this.txtSkipEp2Start.TabIndex = 90;
            this.txtSkipEp2Start.Text = "No";
            this.txtSkipEp2Start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSkipEp2Start.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtSkipEp2Start.Click += new System.EventHandler(this.txtSkipEp2Start_Click);
            // 
            // lblSkipEp2Start
            // 
            this.lblSkipEp2Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSkipEp2Start.ForeColor = System.Drawing.Color.Black;
            this.lblSkipEp2Start.Location = new System.Drawing.Point(7, 13);
            this.lblSkipEp2Start.Name = "lblSkipEp2Start";
            this.lblSkipEp2Start.Size = new System.Drawing.Size(145, 13);
            this.lblSkipEp2Start.TabIndex = 89;
            this.lblSkipEp2Start.Text = "Skip Start Sequence  ";
            this.lblSkipEp2Start.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMissionEp2
            // 
            this.txtMissionEp2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMissionEp2.ForeColor = System.Drawing.Color.DarkRed;
            this.txtMissionEp2.Location = new System.Drawing.Point(144, 28);
            this.txtMissionEp2.Name = "txtMissionEp2";
            this.txtMissionEp2.Size = new System.Drawing.Size(37, 13);
            this.txtMissionEp2.TabIndex = 88;
            this.txtMissionEp2.Text = "No";
            this.txtMissionEp2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMissionEp2.TextChanged += new System.EventHandler(this.missionStatus_TextChanged);
            this.txtMissionEp2.Click += new System.EventHandler(this.txtMissionEp2_Click);
            // 
            // lblMissionEp2
            // 
            this.lblMissionEp2.ForeColor = System.Drawing.Color.Black;
            this.lblMissionEp2.Location = new System.Drawing.Point(10, 28);
            this.lblMissionEp2.Name = "lblMissionEp2";
            this.lblMissionEp2.Size = new System.Drawing.Size(142, 13);
            this.lblMissionEp2.TabIndex = 87;
            this.lblMissionEp2.Text = "All Missions Unlocked  ";
            this.lblMissionEp2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPageInfinityMission
            // 
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
            this.tabPageInfinityMission.Location = new System.Drawing.Point(4, 21);
            this.tabPageInfinityMission.Name = "tabPageInfinityMission";
            this.tabPageInfinityMission.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfinityMission.Size = new System.Drawing.Size(610, 192);
            this.tabPageInfinityMission.TabIndex = 2;
            this.tabPageInfinityMission.Text = "Infinity Missions";
            this.tabPageInfinityMission.UseVisualStyleBackColor = true;
            // 
            // btnImportMissions
            // 
            this.btnImportMissions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportMissions.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportMissions.Location = new System.Drawing.Point(135, 172);
            this.btnImportMissions.Name = "btnImportMissions";
            this.btnImportMissions.Size = new System.Drawing.Size(82, 21);
            this.btnImportMissions.TabIndex = 100;
            this.btnImportMissions.Text = "import pack";
            this.btnImportMissions.UseVisualStyleBackColor = true;
            this.btnImportMissions.Click += new System.EventHandler(this.btnImportMissions_Click);
            // 
            // btnExportMissions
            // 
            this.btnExportMissions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportMissions.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportMissions.Location = new System.Drawing.Point(219, 172);
            this.btnExportMissions.Name = "btnExportMissions";
            this.btnExportMissions.Size = new System.Drawing.Size(82, 21);
            this.btnExportMissions.TabIndex = 99;
            this.btnExportMissions.Text = "export pack";
            this.btnExportMissions.UseVisualStyleBackColor = true;
            this.btnExportMissions.Click += new System.EventHandler(this.btnExportMissions_Click);
            // 
            // btnModifyInfinityMission
            // 
            this.btnModifyInfinityMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifyInfinityMission.Enabled = false;
            this.btnModifyInfinityMission.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyInfinityMission.Location = new System.Drawing.Point(411, 157);
            this.btnModifyInfinityMission.Name = "btnModifyInfinityMission";
            this.btnModifyInfinityMission.Size = new System.Drawing.Size(46, 21);
            this.btnModifyInfinityMission.TabIndex = 98;
            this.btnModifyInfinityMission.Text = "modify";
            this.btnModifyInfinityMission.UseVisualStyleBackColor = true;
            this.btnModifyInfinityMission.Click += new System.EventHandler(this.btnModifyInfinityMission_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 6F);
            this.tabControl1.Location = new System.Drawing.Point(307, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(302, 151);
            this.tabControl1.TabIndex = 97;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpInfinityMissionDetails);
            this.tabPage1.Location = new System.Drawing.Point(4, 19);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(294, 128);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpInfinityMissionDetails
            // 
            this.grpInfinityMissionDetails.BackColor = System.Drawing.Color.Transparent;
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfEnemyLevel);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfNameJp);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfNameEn);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfMisEnemy2);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfMisBoss);
            this.grpInfinityMissionDetails.Controls.Add(this.txtInfMisEnemy1);
            this.grpInfinityMissionDetails.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grpInfinityMissionDetails.Location = new System.Drawing.Point(0, -6);
            this.grpInfinityMissionDetails.Name = "grpInfinityMissionDetails";
            this.grpInfinityMissionDetails.Size = new System.Drawing.Size(293, 135);
            this.grpInfinityMissionDetails.TabIndex = 74;
            this.grpInfinityMissionDetails.TabStop = false;
            this.grpInfinityMissionDetails.Visible = false;
            // 
            // txtInfEnemyLevel
            // 
            this.txtInfEnemyLevel.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfEnemyLevel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfEnemyLevel.Location = new System.Drawing.Point(4, 110);
            this.txtInfEnemyLevel.Name = "txtInfEnemyLevel";
            this.txtInfEnemyLevel.Size = new System.Drawing.Size(281, 13);
            this.txtInfEnemyLevel.TabIndex = 81;
            this.txtInfEnemyLevel.Text = "Enemy Level";
            // 
            // txtInfNameJp
            // 
            this.txtInfNameJp.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfNameJp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfNameJp.Location = new System.Drawing.Point(6, 34);
            this.txtInfNameJp.Name = "txtInfNameJp";
            this.txtInfNameJp.Size = new System.Drawing.Size(224, 18);
            this.txtInfNameJp.TabIndex = 80;
            this.txtInfNameJp.Text = "-";
            // 
            // txtInfNameEn
            // 
            this.txtInfNameEn.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfNameEn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfNameEn.Location = new System.Drawing.Point(6, 17);
            this.txtInfNameEn.Name = "txtInfNameEn";
            this.txtInfNameEn.Size = new System.Drawing.Size(221, 18);
            this.txtInfNameEn.TabIndex = 79;
            this.txtInfNameEn.Text = "-";
            // 
            // txtInfMisEnemy2
            // 
            this.txtInfMisEnemy2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfMisEnemy2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfMisEnemy2.Location = new System.Drawing.Point(12, 95);
            this.txtInfMisEnemy2.Name = "txtInfMisEnemy2";
            this.txtInfMisEnemy2.Size = new System.Drawing.Size(281, 13);
            this.txtInfMisEnemy2.TabIndex = 78;
            this.txtInfMisEnemy2.Text = "Sub Enemy";
            // 
            // txtInfMisBoss
            // 
            this.txtInfMisBoss.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfMisBoss.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfMisBoss.Location = new System.Drawing.Point(5, 57);
            this.txtInfMisBoss.Name = "txtInfMisBoss";
            this.txtInfMisBoss.Size = new System.Drawing.Size(282, 13);
            this.txtInfMisBoss.TabIndex = 76;
            this.txtInfMisBoss.Text = "Boss";
            // 
            // txtInfMisEnemy1
            // 
            this.txtInfMisEnemy1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfMisEnemy1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfMisEnemy1.Location = new System.Drawing.Point(8, 80);
            this.txtInfMisEnemy1.Name = "txtInfMisEnemy1";
            this.txtInfMisEnemy1.Size = new System.Drawing.Size(284, 13);
            this.txtInfMisEnemy1.TabIndex = 77;
            this.txtInfMisEnemy1.Text = "Main Enemy";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpInfMisSpecial);
            this.tabPage2.Location = new System.Drawing.Point(4, 19);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(294, 128);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpInfMisSpecial
            // 
            this.grpInfMisSpecial.BackColor = System.Drawing.Color.Transparent;
            this.grpInfMisSpecial.Controls.Add(this.txtInfMisSpecial);
            this.grpInfMisSpecial.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grpInfMisSpecial.Location = new System.Drawing.Point(0, -6);
            this.grpInfMisSpecial.Name = "grpInfMisSpecial";
            this.grpInfMisSpecial.Size = new System.Drawing.Size(293, 135);
            this.grpInfMisSpecial.TabIndex = 75;
            this.grpInfMisSpecial.TabStop = false;
            this.grpInfMisSpecial.Visible = false;
            // 
            // txtInfMisSpecial
            // 
            this.txtInfMisSpecial.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfMisSpecial.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.txtInfMisSpecial.Location = new System.Drawing.Point(6, 17);
            this.txtInfMisSpecial.Name = "txtInfMisSpecial";
            this.txtInfMisSpecial.Size = new System.Drawing.Size(281, 13);
            this.txtInfMisSpecial.TabIndex = 76;
            this.txtInfMisSpecial.Text = "Special Effects";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grpInfMisExtra);
            this.tabPage3.Location = new System.Drawing.Point(4, 19);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(294, 128);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grpInfMisExtra
            // 
            this.grpInfMisExtra.BackColor = System.Drawing.Color.Transparent;
            this.grpInfMisExtra.Controls.Add(this.txtInfMisSynthPoint);
            this.grpInfMisExtra.Controls.Add(this.txtInfMisCreatedBy);
            this.grpInfMisExtra.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grpInfMisExtra.Location = new System.Drawing.Point(0, -6);
            this.grpInfMisExtra.Name = "grpInfMisExtra";
            this.grpInfMisExtra.Size = new System.Drawing.Size(293, 135);
            this.grpInfMisExtra.TabIndex = 76;
            this.grpInfMisExtra.TabStop = false;
            this.grpInfMisExtra.Visible = false;
            // 
            // txtInfMisSynthPoint
            // 
            this.txtInfMisSynthPoint.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfMisSynthPoint.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.txtInfMisSynthPoint.Location = new System.Drawing.Point(6, 61);
            this.txtInfMisSynthPoint.Name = "txtInfMisSynthPoint";
            this.txtInfMisSynthPoint.Size = new System.Drawing.Size(281, 13);
            this.txtInfMisSynthPoint.TabIndex = 77;
            this.txtInfMisSynthPoint.Text = "Sythesis Points  ";
            // 
            // txtInfMisCreatedBy
            // 
            this.txtInfMisCreatedBy.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfMisCreatedBy.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.txtInfMisCreatedBy.Location = new System.Drawing.Point(6, 17);
            this.txtInfMisCreatedBy.Name = "txtInfMisCreatedBy";
            this.txtInfMisCreatedBy.Size = new System.Drawing.Size(281, 13);
            this.txtInfMisCreatedBy.TabIndex = 76;
            this.txtInfMisCreatedBy.Text = "Created By  ";
            // 
            // btnDeleteInfinityMission
            // 
            this.btnDeleteInfinityMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteInfinityMission.Enabled = false;
            this.btnDeleteInfinityMission.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInfinityMission.Location = new System.Drawing.Point(457, 157);
            this.btnDeleteInfinityMission.Name = "btnDeleteInfinityMission";
            this.btnDeleteInfinityMission.Size = new System.Drawing.Size(46, 21);
            this.btnDeleteInfinityMission.TabIndex = 96;
            this.btnDeleteInfinityMission.Text = "delete";
            this.btnDeleteInfinityMission.UseVisualStyleBackColor = true;
            this.btnDeleteInfinityMission.Click += new System.EventHandler(this.btnDeleteInfinityMission_Click);
            // 
            // btnImportInfinityMission
            // 
            this.btnImportInfinityMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportInfinityMission.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportInfinityMission.Location = new System.Drawing.Point(503, 157);
            this.btnImportInfinityMission.Name = "btnImportInfinityMission";
            this.btnImportInfinityMission.Size = new System.Drawing.Size(50, 21);
            this.btnImportInfinityMission.TabIndex = 95;
            this.btnImportInfinityMission.Text = "import";
            this.btnImportInfinityMission.UseVisualStyleBackColor = true;
            this.btnImportInfinityMission.Click += new System.EventHandler(this.btnImportInfinityMission_Click);
            // 
            // btnExportInfinityMission
            // 
            this.btnExportInfinityMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportInfinityMission.Enabled = false;
            this.btnExportInfinityMission.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportInfinityMission.Location = new System.Drawing.Point(553, 157);
            this.btnExportInfinityMission.Name = "btnExportInfinityMission";
            this.btnExportInfinityMission.Size = new System.Drawing.Size(52, 21);
            this.btnExportInfinityMission.TabIndex = 94;
            this.btnExportInfinityMission.Text = "export";
            this.btnExportInfinityMission.UseVisualStyleBackColor = true;
            this.btnExportInfinityMission.Click += new System.EventHandler(this.btnExportInfinityMission_Click);
            // 
            // lstInfinityMissions
            // 
            this.lstInfinityMissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11});
            this.lstInfinityMissions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstInfinityMissions.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInfinityMissions.FullRowSelect = true;
            this.lstInfinityMissions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstInfinityMissions.HideSelection = false;
            this.lstInfinityMissions.LabelWrap = false;
            this.lstInfinityMissions.Location = new System.Drawing.Point(3, 3);
            this.lstInfinityMissions.MultiSelect = false;
            this.lstInfinityMissions.Name = "lstInfinityMissions";
            this.lstInfinityMissions.Size = new System.Drawing.Size(298, 167);
            this.lstInfinityMissions.TabIndex = 93;
            this.lstInfinityMissions.UseCompatibleStateImageBehavior = false;
            this.lstInfinityMissions.View = System.Windows.Forms.View.Details;
            this.lstInfinityMissions.SelectedIndexChanged += new System.EventHandler(this.lstInfinityMissions_SelectedIndexChanged);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 220;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 50;
            // 
            // txtInfinityMissionQty
            // 
            this.txtInfinityMissionQty.AutoSize = true;
            this.txtInfinityMissionQty.BackColor = System.Drawing.Color.Transparent;
            this.txtInfinityMissionQty.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfinityMissionQty.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtInfinityMissionQty.Location = new System.Drawing.Point(3, 175);
            this.txtInfinityMissionQty.Name = "txtInfinityMissionQty";
            this.txtInfinityMissionQty.Size = new System.Drawing.Size(44, 14);
            this.txtInfinityMissionQty.TabIndex = 92;
            this.txtInfinityMissionQty.Text = "0/100";
            // 
            // label63
            // 
            this.label63.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label63.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label63.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(311, 157);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(97, 13);
            this.label63.TabIndex = 75;
            this.label63.Text = "0x00000000";
            // 
            // tabPagePA
            // 
            this.tabPagePA.Controls.Add(this.tabPA);
            this.tabPagePA.Location = new System.Drawing.Point(4, 22);
            this.tabPagePA.Name = "tabPagePA";
            this.tabPagePA.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePA.Size = new System.Drawing.Size(629, 223);
            this.tabPagePA.TabIndex = 8;
            this.tabPagePA.Text = "PA List";
            this.tabPagePA.UseVisualStyleBackColor = true;
            // 
            // tabPA
            // 
            this.tabPA.Controls.Add(this.tabPAMelee);
            this.tabPA.Controls.Add(this.tabPABullets);
            this.tabPA.Controls.Add(this.tabPATech);
            this.tabPA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPA.Location = new System.Drawing.Point(5, 3);
            this.tabPA.Name = "tabPA";
            this.tabPA.SelectedIndex = 0;
            this.tabPA.Size = new System.Drawing.Size(618, 217);
            this.tabPA.TabIndex = 1;
            // 
            // tabPAMelee
            // 
            this.tabPAMelee.Controls.Add(this.groupBox6);
            this.tabPAMelee.Controls.Add(this.txtPAHexMelee);
            this.tabPAMelee.Controls.Add(this.lstPAMelee);
            this.tabPAMelee.Location = new System.Drawing.Point(4, 21);
            this.tabPAMelee.Name = "tabPAMelee";
            this.tabPAMelee.Padding = new System.Windows.Forms.Padding(3);
            this.tabPAMelee.Size = new System.Drawing.Size(610, 192);
            this.tabPAMelee.TabIndex = 0;
            this.tabPAMelee.Text = "Melee";
            this.tabPAMelee.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
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
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.groupBox6.Location = new System.Drawing.Point(307, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(297, 154);
            this.groupBox6.TabIndex = 72;
            this.groupBox6.TabStop = false;
            this.groupBox6.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(192, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 12);
            this.label3.TabIndex = 73;
            this.label3.Text = "LV100";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "ACC  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Location = new System.Drawing.Point(15, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = "ATK  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Effect  ";
            // 
            // label16
            // 
            this.label16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label16.Location = new System.Drawing.Point(3, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(284, 13);
            this.label16.TabIndex = 69;
            this.label16.Text = "Ability  ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::pspo2seSaveEditorProgram.Properties.Resources.rank_S;
            this.pictureBox2.Location = new System.Drawing.Point(10, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 67;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.pictureBox3.Location = new System.Drawing.Point(230, 133);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 15);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 66;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox4.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.pictureBox4.Location = new System.Drawing.Point(215, 133);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 15);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 65;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox8.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.pictureBox8.Location = new System.Drawing.Point(200, 133);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(16, 15);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 64;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Visible = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox9.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_s2;
            this.pictureBox9.Location = new System.Drawing.Point(185, 133);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(16, 15);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 63;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Visible = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox10.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.pictureBox10.Location = new System.Drawing.Point(171, 133);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(16, 15);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 62;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Visible = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox11.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.pictureBox11.Location = new System.Drawing.Point(156, 133);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(16, 15);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox11.TabIndex = 61;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Visible = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox12.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_S;
            this.pictureBox12.Location = new System.Drawing.Point(141, 133);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(16, 15);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox12.TabIndex = 60;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Visible = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox13.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.pictureBox13.Location = new System.Drawing.Point(126, 133);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(16, 15);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox13.TabIndex = 59;
            this.pictureBox13.TabStop = false;
            this.pictureBox13.Visible = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox14.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.pictureBox14.Location = new System.Drawing.Point(111, 133);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(16, 15);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox14.TabIndex = 58;
            this.pictureBox14.TabStop = false;
            this.pictureBox14.Visible = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox15.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_A;
            this.pictureBox15.Location = new System.Drawing.Point(96, 133);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(16, 15);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox15.TabIndex = 57;
            this.pictureBox15.TabStop = false;
            this.pictureBox15.Visible = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox16.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.pictureBox16.Location = new System.Drawing.Point(81, 133);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(16, 15);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox16.TabIndex = 56;
            this.pictureBox16.TabStop = false;
            this.pictureBox16.Visible = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox17.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.pictureBox17.Location = new System.Drawing.Point(66, 133);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(16, 15);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox17.TabIndex = 55;
            this.pictureBox17.TabStop = false;
            this.pictureBox17.Visible = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox18.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_B;
            this.pictureBox18.Location = new System.Drawing.Point(51, 133);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(16, 15);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox18.TabIndex = 54;
            this.pictureBox18.TabStop = false;
            this.pictureBox18.Visible = false;
            // 
            // pictureBox19
            // 
            this.pictureBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox19.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.pictureBox19.Location = new System.Drawing.Point(36, 133);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(16, 15);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox19.TabIndex = 53;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Visible = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox20.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.pictureBox20.Location = new System.Drawing.Point(21, 133);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(16, 15);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox20.TabIndex = 52;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Visible = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox21.Image = global::pspo2seSaveEditorProgram.Properties.Resources.star_C;
            this.pictureBox21.Location = new System.Drawing.Point(6, 133);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(16, 15);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox21.TabIndex = 51;
            this.pictureBox21.TabStop = false;
            this.pictureBox21.Visible = false;
            // 
            // pictureBox22
            // 
            this.pictureBox22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox22.Image = global::pspo2seSaveEditorProgram.Properties.Resources.manlogo_GRM;
            this.pictureBox22.Location = new System.Drawing.Point(273, 12);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(17, 17);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox22.TabIndex = 46;
            this.pictureBox22.TabStop = false;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Location = new System.Drawing.Point(81, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(210, 18);
            this.label18.TabIndex = 45;
            this.label18.Text = "(0)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label19
            // 
            this.label19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label19.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(8, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(224, 18);
            this.label19.TabIndex = 44;
            this.label19.Text = "-";
            // 
            // pictureBox23
            // 
            this.pictureBox23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox23.Image = global::pspo2seSaveEditorProgram.Properties.Resources.element_neutral;
            this.pictureBox23.Location = new System.Drawing.Point(9, 49);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(12, 12);
            this.pictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox23.TabIndex = 41;
            this.pictureBox23.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label24.Location = new System.Drawing.Point(21, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 13);
            this.label24.TabIndex = 31;
            this.label24.Text = "0%";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label25.Location = new System.Drawing.Point(6, 48);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(26, 13);
            this.label25.TabIndex = 42;
            this.label25.Text = "0/0";
            // 
            // pictureBox24
            // 
            this.pictureBox24.Image = global::pspo2seSaveEditorProgram.Properties.Resources.armor_icon;
            this.pictureBox24.Location = new System.Drawing.Point(10, 15);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.pictureBox24.Size = new System.Drawing.Size(23, 10);
            this.pictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox24.TabIndex = 47;
            this.pictureBox24.TabStop = false;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(21, 13);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.label26.Size = new System.Drawing.Size(211, 18);
            this.label26.TabIndex = 43;
            this.label26.Text = "-";
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(274, 32);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 13);
            this.label30.TabIndex = 50;
            this.label30.Text = "?";
            this.label30.Visible = false;
            // 
            // pictureBox25
            // 
            this.pictureBox25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox25.Image = global::pspo2seSaveEditorProgram.Properties.Resources.infinity_item;
            this.pictureBox25.Location = new System.Drawing.Point(270, 31);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new System.Drawing.Size(20, 16);
            this.pictureBox25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox25.TabIndex = 49;
            this.pictureBox25.TabStop = false;
            this.pictureBox25.Visible = false;
            // 
            // txtPAHexMelee
            // 
            this.txtPAHexMelee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPAHexMelee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPAHexMelee.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPAHexMelee.Location = new System.Drawing.Point(311, 160);
            this.txtPAHexMelee.Name = "txtPAHexMelee";
            this.txtPAHexMelee.Size = new System.Drawing.Size(97, 13);
            this.txtPAHexMelee.TabIndex = 73;
            this.txtPAHexMelee.Text = "0x00000000";
            // 
            // lstPAMelee
            // 
            this.lstPAMelee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.lstPAMelee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstPAMelee.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPAMelee.FullRowSelect = true;
            this.lstPAMelee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstPAMelee.HideSelection = false;
            this.lstPAMelee.LabelWrap = false;
            this.lstPAMelee.Location = new System.Drawing.Point(3, 3);
            this.lstPAMelee.MultiSelect = false;
            this.lstPAMelee.Name = "lstPAMelee";
            this.lstPAMelee.Size = new System.Drawing.Size(298, 185);
            this.lstPAMelee.SmallImageList = this.paImageList;
            this.lstPAMelee.TabIndex = 71;
            this.lstPAMelee.UseCompatibleStateImageBehavior = false;
            this.lstPAMelee.View = System.Windows.Forms.View.Details;
            this.lstPAMelee.SelectedIndexChanged += new System.EventHandler(this.lstPAMelee_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 220;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 50;
            // 
            // paImageList
            // 
            this.paImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("paImageList.ImageStream")));
            this.paImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // tabPABullets
            // 
            this.tabPABullets.Controls.Add(this.txtPAHexBullets);
            this.tabPABullets.Controls.Add(this.lstPABullets);
            this.tabPABullets.Location = new System.Drawing.Point(4, 21);
            this.tabPABullets.Name = "tabPABullets";
            this.tabPABullets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPABullets.Size = new System.Drawing.Size(610, 192);
            this.tabPABullets.TabIndex = 1;
            this.tabPABullets.Text = "Bullets";
            this.tabPABullets.UseVisualStyleBackColor = true;
            // 
            // txtPAHexBullets
            // 
            this.txtPAHexBullets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPAHexBullets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPAHexBullets.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPAHexBullets.Location = new System.Drawing.Point(311, 160);
            this.txtPAHexBullets.Name = "txtPAHexBullets";
            this.txtPAHexBullets.Size = new System.Drawing.Size(97, 13);
            this.txtPAHexBullets.TabIndex = 74;
            this.txtPAHexBullets.Text = "0x00000000";
            // 
            // lstPABullets
            // 
            this.lstPABullets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lstPABullets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstPABullets.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPABullets.FullRowSelect = true;
            this.lstPABullets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstPABullets.HideSelection = false;
            this.lstPABullets.LabelWrap = false;
            this.lstPABullets.Location = new System.Drawing.Point(3, 3);
            this.lstPABullets.MultiSelect = false;
            this.lstPABullets.Name = "lstPABullets";
            this.lstPABullets.Size = new System.Drawing.Size(298, 185);
            this.lstPABullets.SmallImageList = this.paImageList;
            this.lstPABullets.TabIndex = 72;
            this.lstPABullets.UseCompatibleStateImageBehavior = false;
            this.lstPABullets.View = System.Windows.Forms.View.Details;
            this.lstPABullets.SelectedIndexChanged += new System.EventHandler(this.lstPABullets_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 220;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 50;
            // 
            // tabPATech
            // 
            this.tabPATech.Controls.Add(this.txtPAHexTech);
            this.tabPATech.Controls.Add(this.lstPATechs);
            this.tabPATech.Location = new System.Drawing.Point(4, 21);
            this.tabPATech.Name = "tabPATech";
            this.tabPATech.Size = new System.Drawing.Size(610, 192);
            this.tabPATech.TabIndex = 2;
            this.tabPATech.Text = "Technique";
            this.tabPATech.UseVisualStyleBackColor = true;
            // 
            // txtPAHexTech
            // 
            this.txtPAHexTech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPAHexTech.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPAHexTech.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPAHexTech.Location = new System.Drawing.Point(311, 160);
            this.txtPAHexTech.Name = "txtPAHexTech";
            this.txtPAHexTech.Size = new System.Drawing.Size(97, 13);
            this.txtPAHexTech.TabIndex = 74;
            this.txtPAHexTech.Text = "0x00000000";
            // 
            // lstPATechs
            // 
            this.lstPATechs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.lstPATechs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstPATechs.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPATechs.FullRowSelect = true;
            this.lstPATechs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstPATechs.HideSelection = false;
            this.lstPATechs.LabelWrap = false;
            this.lstPATechs.Location = new System.Drawing.Point(3, 3);
            this.lstPATechs.MultiSelect = false;
            this.lstPATechs.Name = "lstPATechs";
            this.lstPATechs.Size = new System.Drawing.Size(298, 185);
            this.lstPATechs.SmallImageList = this.paImageList;
            this.lstPATechs.TabIndex = 72;
            this.lstPATechs.UseCompatibleStateImageBehavior = false;
            this.lstPATechs.View = System.Windows.Forms.View.Details;
            this.lstPATechs.SelectedIndexChanged += new System.EventHandler(this.lstPATechs_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 220;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 50;
            // 
            // tabPageRebirth
            // 
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
            this.tabPageRebirth.Location = new System.Drawing.Point(4, 22);
            this.tabPageRebirth.Name = "tabPageRebirth";
            this.tabPageRebirth.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRebirth.Size = new System.Drawing.Size(629, 223);
            this.tabPageRebirth.TabIndex = 10;
            this.tabPageRebirth.Text = "Rebirth";
            this.tabPageRebirth.UseVisualStyleBackColor = true;
            // 
            // chkRebirthNoLevelDrop
            // 
            this.chkRebirthNoLevelDrop.AutoSize = true;
            this.chkRebirthNoLevelDrop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRebirthNoLevelDrop.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRebirthNoLevelDrop.Location = new System.Drawing.Point(174, 191);
            this.chkRebirthNoLevelDrop.Name = "chkRebirthNoLevelDrop";
            this.chkRebirthNoLevelDrop.Size = new System.Drawing.Size(170, 16);
            this.chkRebirthNoLevelDrop.TabIndex = 96;
            this.chkRebirthNoLevelDrop.Text = "No Level Drop During Rebirth";
            this.chkRebirthNoLevelDrop.UseVisualStyleBackColor = true;
            // 
            // chkRebirthSpoof
            // 
            this.chkRebirthSpoof.AutoSize = true;
            this.chkRebirthSpoof.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRebirthSpoof.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRebirthSpoof.Location = new System.Drawing.Point(9, 191);
            this.chkRebirthSpoof.Name = "chkRebirthSpoof";
            this.chkRebirthSpoof.Size = new System.Drawing.Size(145, 16);
            this.chkRebirthSpoof.TabIndex = 95;
            this.chkRebirthSpoof.Text = "Spoof Level 200 Rebirth";
            this.chkRebirthSpoof.UseVisualStyleBackColor = true;
            this.chkRebirthSpoof.CheckedChanged += new System.EventHandler(this.chkRebirthSpoof_CheckedChanged);
            // 
            // comboRebirthExtend
            // 
            this.comboRebirthExtend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboRebirthExtend.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRebirthExtend.FormattingEnabled = true;
            this.comboRebirthExtend.Location = new System.Drawing.Point(9, 119);
            this.comboRebirthExtend.Name = "comboRebirthExtend";
            this.comboRebirthExtend.Size = new System.Drawing.Size(294, 20);
            this.comboRebirthExtend.TabIndex = 94;
            // 
            // btnRebirth
            // 
            this.btnRebirth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRebirth.Enabled = false;
            this.btnRebirth.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRebirth.Location = new System.Drawing.Point(305, 118);
            this.btnRebirth.Name = "btnRebirth";
            this.btnRebirth.Size = new System.Drawing.Size(59, 22);
            this.btnRebirth.TabIndex = 86;
            this.btnRebirth.Text = "rebirth";
            this.btnRebirth.UseVisualStyleBackColor = true;
            this.btnRebirth.Click += new System.EventHandler(this.btnRebirth_Click);
            // 
            // txtRebirthMaxType
            // 
            this.txtRebirthMaxType.AutoSize = true;
            this.txtRebirthMaxType.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthMaxType.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthMaxType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthMaxType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthMaxType.Location = new System.Drawing.Point(122, 24);
            this.txtRebirthMaxType.Name = "txtRebirthMaxType";
            this.txtRebirthMaxType.Size = new System.Drawing.Size(12, 13);
            this.txtRebirthMaxType.TabIndex = 92;
            this.txtRebirthMaxType.Text = "-";
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Cursor = System.Windows.Forms.Cursors.Default;
            this.label33.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label33.Location = new System.Drawing.Point(6, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(112, 13);
            this.label33.TabIndex = 93;
            this.label33.Text = "Max Type Level";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstRebirthRewards
            // 
            this.lstRebirthRewards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9});
            this.lstRebirthRewards.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRebirthRewards.FullRowSelect = true;
            this.lstRebirthRewards.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstRebirthRewards.Location = new System.Drawing.Point(9, 63);
            this.lstRebirthRewards.MultiSelect = false;
            this.lstRebirthRewards.Name = "lstRebirthRewards";
            this.lstRebirthRewards.Size = new System.Drawing.Size(355, 54);
            this.lstRebirthRewards.TabIndex = 91;
            this.lstRebirthRewards.UseCompatibleStateImageBehavior = false;
            this.lstRebirthRewards.View = System.Windows.Forms.View.Details;
            this.lstRebirthRewards.SelectedIndexChanged += new System.EventHandler(this.lstRebirthRewards_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 345;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkRed;
            this.label17.Location = new System.Drawing.Point(6, 150);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(373, 30);
            this.label17.TabIndex = 90;
            this.label17.Text = "Note - Bonus points spent on extend codes when rebirthing in game cannot be rever" +
    "sed and are lost forever.";
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Cursor = System.Windows.Forms.Cursors.Default;
            this.label32.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label32.Location = new System.Drawing.Point(6, 47);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(297, 13);
            this.label32.TabIndex = 89;
            this.label32.Text = "Current Rebirth Rewards";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRebirthCount
            // 
            this.txtRebirthCount.AutoSize = true;
            this.txtRebirthCount.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthCount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthCount.Location = new System.Drawing.Point(122, 7);
            this.txtRebirthCount.Name = "txtRebirthCount";
            this.txtRebirthCount.Size = new System.Drawing.Size(12, 13);
            this.txtRebirthCount.TabIndex = 76;
            this.txtRebirthCount.Text = "-";
            // 
            // txtRebirthPoints
            // 
            this.txtRebirthPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRebirthPoints.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthPoints.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthPoints.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthPoints.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthPoints.Location = new System.Drawing.Point(396, 7);
            this.txtRebirthPoints.Name = "txtRebirthPoints";
            this.txtRebirthPoints.Size = new System.Drawing.Size(226, 12);
            this.txtRebirthPoints.TabIndex = 78;
            this.txtRebirthPoints.Text = "-";
            this.txtRebirthPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.Cursor = System.Windows.Forms.Cursors.Default;
            this.label48.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label48.Location = new System.Drawing.Point(6, 7);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(112, 13);
            this.label48.TabIndex = 77;
            this.label48.Text = "Rebirth Count";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpRebirth
            // 
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
            this.grpRebirth.Location = new System.Drawing.Point(396, 16);
            this.grpRebirth.Name = "grpRebirth";
            this.grpRebirth.Size = new System.Drawing.Size(228, 201);
            this.grpRebirth.TabIndex = 75;
            this.grpRebirth.TabStop = false;
            // 
            // txtRebirthNextSTA
            // 
            this.txtRebirthNextSTA.AutoSize = true;
            this.txtRebirthNextSTA.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextSTA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextSTA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextSTA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextSTA.Location = new System.Drawing.Point(187, 180);
            this.txtRebirthNextSTA.Name = "txtRebirthNextSTA";
            this.txtRebirthNextSTA.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextSTA.TabIndex = 108;
            this.txtRebirthNextSTA.Text = "-";
            // 
            // txtRebirthNextPP
            // 
            this.txtRebirthNextPP.AutoSize = true;
            this.txtRebirthNextPP.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextPP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextPP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextPP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextPP.Location = new System.Drawing.Point(187, 47);
            this.txtRebirthNextPP.Name = "txtRebirthNextPP";
            this.txtRebirthNextPP.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextPP.TabIndex = 107;
            this.txtRebirthNextPP.Text = "-";
            // 
            // txtRebirthNextHP
            // 
            this.txtRebirthNextHP.AutoSize = true;
            this.txtRebirthNextHP.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextHP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextHP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextHP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextHP.Location = new System.Drawing.Point(187, 28);
            this.txtRebirthNextHP.Name = "txtRebirthNextHP";
            this.txtRebirthNextHP.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextHP.TabIndex = 106;
            this.txtRebirthNextHP.Text = "-";
            // 
            // txtRebirthNextMND
            // 
            this.txtRebirthNextMND.AutoSize = true;
            this.txtRebirthNextMND.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextMND.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextMND.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextMND.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextMND.Location = new System.Drawing.Point(187, 161);
            this.txtRebirthNextMND.Name = "txtRebirthNextMND";
            this.txtRebirthNextMND.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextMND.TabIndex = 105;
            this.txtRebirthNextMND.Text = "-";
            // 
            // txtRebirthNextTEC
            // 
            this.txtRebirthNextTEC.AutoSize = true;
            this.txtRebirthNextTEC.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextTEC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextTEC.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextTEC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextTEC.Location = new System.Drawing.Point(187, 142);
            this.txtRebirthNextTEC.Name = "txtRebirthNextTEC";
            this.txtRebirthNextTEC.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextTEC.TabIndex = 104;
            this.txtRebirthNextTEC.Text = "-";
            // 
            // txtRebirthNextEVA
            // 
            this.txtRebirthNextEVA.AutoSize = true;
            this.txtRebirthNextEVA.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextEVA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextEVA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextEVA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextEVA.Location = new System.Drawing.Point(187, 123);
            this.txtRebirthNextEVA.Name = "txtRebirthNextEVA";
            this.txtRebirthNextEVA.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextEVA.TabIndex = 101;
            this.txtRebirthNextEVA.Text = "-";
            // 
            // txtRebirthNextACC
            // 
            this.txtRebirthNextACC.AutoSize = true;
            this.txtRebirthNextACC.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextACC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextACC.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextACC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextACC.Location = new System.Drawing.Point(187, 104);
            this.txtRebirthNextACC.Name = "txtRebirthNextACC";
            this.txtRebirthNextACC.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextACC.TabIndex = 103;
            this.txtRebirthNextACC.Text = "-";
            // 
            // txtRebirthNextDEF
            // 
            this.txtRebirthNextDEF.AutoSize = true;
            this.txtRebirthNextDEF.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextDEF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextDEF.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextDEF.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextDEF.Location = new System.Drawing.Point(187, 85);
            this.txtRebirthNextDEF.Name = "txtRebirthNextDEF";
            this.txtRebirthNextDEF.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextDEF.TabIndex = 102;
            this.txtRebirthNextDEF.Text = "-";
            // 
            // txtRebirthNextATK
            // 
            this.txtRebirthNextATK.AutoSize = true;
            this.txtRebirthNextATK.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthNextATK.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthNextATK.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthNextATK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthNextATK.Location = new System.Drawing.Point(187, 66);
            this.txtRebirthNextATK.Name = "txtRebirthNextATK";
            this.txtRebirthNextATK.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthNextATK.TabIndex = 100;
            this.txtRebirthNextATK.Text = "-";
            // 
            // txtRebirthBpSTA
            // 
            this.txtRebirthBpSTA.AutoSize = true;
            this.txtRebirthBpSTA.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpSTA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpSTA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpSTA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpSTA.Location = new System.Drawing.Point(94, 180);
            this.txtRebirthBpSTA.Name = "txtRebirthBpSTA";
            this.txtRebirthBpSTA.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpSTA.TabIndex = 99;
            this.txtRebirthBpSTA.Text = "-";
            // 
            // txtRebirthBpPP
            // 
            this.txtRebirthBpPP.AutoSize = true;
            this.txtRebirthBpPP.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpPP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpPP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpPP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpPP.Location = new System.Drawing.Point(94, 47);
            this.txtRebirthBpPP.Name = "txtRebirthBpPP";
            this.txtRebirthBpPP.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpPP.TabIndex = 98;
            this.txtRebirthBpPP.Text = "-";
            // 
            // txtRebirthBpHP
            // 
            this.txtRebirthBpHP.AutoSize = true;
            this.txtRebirthBpHP.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpHP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpHP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpHP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpHP.Location = new System.Drawing.Point(94, 28);
            this.txtRebirthBpHP.Name = "txtRebirthBpHP";
            this.txtRebirthBpHP.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpHP.TabIndex = 97;
            this.txtRebirthBpHP.Text = "-";
            // 
            // txtRebirthBpMND
            // 
            this.txtRebirthBpMND.AutoSize = true;
            this.txtRebirthBpMND.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpMND.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpMND.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpMND.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpMND.Location = new System.Drawing.Point(94, 161);
            this.txtRebirthBpMND.Name = "txtRebirthBpMND";
            this.txtRebirthBpMND.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpMND.TabIndex = 96;
            this.txtRebirthBpMND.Text = "-";
            // 
            // txtRebirthBpTEC
            // 
            this.txtRebirthBpTEC.AutoSize = true;
            this.txtRebirthBpTEC.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpTEC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpTEC.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpTEC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpTEC.Location = new System.Drawing.Point(94, 142);
            this.txtRebirthBpTEC.Name = "txtRebirthBpTEC";
            this.txtRebirthBpTEC.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpTEC.TabIndex = 95;
            this.txtRebirthBpTEC.Text = "-";
            // 
            // txtRebirthBpEVA
            // 
            this.txtRebirthBpEVA.AutoSize = true;
            this.txtRebirthBpEVA.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpEVA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpEVA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpEVA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpEVA.Location = new System.Drawing.Point(94, 123);
            this.txtRebirthBpEVA.Name = "txtRebirthBpEVA";
            this.txtRebirthBpEVA.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpEVA.TabIndex = 92;
            this.txtRebirthBpEVA.Text = "-";
            // 
            // txtRebirthBpACC
            // 
            this.txtRebirthBpACC.AutoSize = true;
            this.txtRebirthBpACC.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpACC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpACC.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpACC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpACC.Location = new System.Drawing.Point(94, 104);
            this.txtRebirthBpACC.Name = "txtRebirthBpACC";
            this.txtRebirthBpACC.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpACC.TabIndex = 94;
            this.txtRebirthBpACC.Text = "-";
            // 
            // txtRebirthBpDEF
            // 
            this.txtRebirthBpDEF.AutoSize = true;
            this.txtRebirthBpDEF.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpDEF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpDEF.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpDEF.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpDEF.Location = new System.Drawing.Point(94, 85);
            this.txtRebirthBpDEF.Name = "txtRebirthBpDEF";
            this.txtRebirthBpDEF.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpDEF.TabIndex = 93;
            this.txtRebirthBpDEF.Text = "-";
            // 
            // txtRebirthBpATK
            // 
            this.txtRebirthBpATK.AutoSize = true;
            this.txtRebirthBpATK.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthBpATK.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthBpATK.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthBpATK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthBpATK.Location = new System.Drawing.Point(94, 66);
            this.txtRebirthBpATK.Name = "txtRebirthBpATK";
            this.txtRebirthBpATK.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthBpATK.TabIndex = 91;
            this.txtRebirthBpATK.Text = "-";
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Cursor = System.Windows.Forms.Cursors.Default;
            this.label41.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.DimGray;
            this.label41.Location = new System.Drawing.Point(187, 9);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(39, 13);
            this.label41.TabIndex = 90;
            this.label41.Text = "NEXT";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Cursor = System.Windows.Forms.Cursors.Default;
            this.label40.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.DimGray;
            this.label40.Location = new System.Drawing.Point(94, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(48, 13);
            this.label40.TabIndex = 89;
            this.label40.Text = "BP";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Cursor = System.Windows.Forms.Cursors.Default;
            this.label37.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.DimGray;
            this.label37.Location = new System.Drawing.Point(11, 9);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(48, 13);
            this.label37.TabIndex = 88;
            this.label37.Text = "STAT";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numRebirthSTA
            // 
            this.numRebirthSTA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthSTA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthSTA.Location = new System.Drawing.Point(148, 178);
            this.numRebirthSTA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthSTA.Name = "numRebirthSTA";
            this.numRebirthSTA.Size = new System.Drawing.Size(37, 18);
            this.numRebirthSTA.TabIndex = 87;
            this.numRebirthSTA.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // txtRebirthSTA
            // 
            this.txtRebirthSTA.AutoSize = true;
            this.txtRebirthSTA.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthSTA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthSTA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthSTA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthSTA.Location = new System.Drawing.Point(49, 180);
            this.txtRebirthSTA.Name = "txtRebirthSTA";
            this.txtRebirthSTA.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthSTA.TabIndex = 86;
            this.txtRebirthSTA.Text = "-";
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Cursor = System.Windows.Forms.Cursors.Default;
            this.label50.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label50.Location = new System.Drawing.Point(11, 180);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(33, 13);
            this.label50.TabIndex = 85;
            this.label50.Text = "STA";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numRebirthPP
            // 
            this.numRebirthPP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthPP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthPP.Location = new System.Drawing.Point(148, 45);
            this.numRebirthPP.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthPP.Name = "numRebirthPP";
            this.numRebirthPP.Size = new System.Drawing.Size(37, 18);
            this.numRebirthPP.TabIndex = 84;
            this.numRebirthPP.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // numRebirthHP
            // 
            this.numRebirthHP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthHP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthHP.Location = new System.Drawing.Point(148, 26);
            this.numRebirthHP.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthHP.Name = "numRebirthHP";
            this.numRebirthHP.Size = new System.Drawing.Size(37, 18);
            this.numRebirthHP.TabIndex = 83;
            this.numRebirthHP.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // txtRebirthPP
            // 
            this.txtRebirthPP.AutoSize = true;
            this.txtRebirthPP.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthPP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthPP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthPP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthPP.Location = new System.Drawing.Point(49, 47);
            this.txtRebirthPP.Name = "txtRebirthPP";
            this.txtRebirthPP.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthPP.TabIndex = 82;
            this.txtRebirthPP.Text = "-";
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Cursor = System.Windows.Forms.Cursors.Default;
            this.label55.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label55.Location = new System.Drawing.Point(11, 47);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(33, 13);
            this.label55.TabIndex = 81;
            this.label55.Text = "PP";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Cursor = System.Windows.Forms.Cursors.Default;
            this.label56.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label56.Location = new System.Drawing.Point(11, 28);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(33, 13);
            this.label56.TabIndex = 79;
            this.label56.Text = "HP";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRebirthHP
            // 
            this.txtRebirthHP.AutoSize = true;
            this.txtRebirthHP.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthHP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthHP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthHP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthHP.Location = new System.Drawing.Point(49, 28);
            this.txtRebirthHP.Name = "txtRebirthHP";
            this.txtRebirthHP.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthHP.TabIndex = 80;
            this.txtRebirthHP.Text = "-";
            // 
            // numRebirthMND
            // 
            this.numRebirthMND.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthMND.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthMND.Location = new System.Drawing.Point(148, 159);
            this.numRebirthMND.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthMND.Name = "numRebirthMND";
            this.numRebirthMND.Size = new System.Drawing.Size(37, 18);
            this.numRebirthMND.TabIndex = 74;
            this.numRebirthMND.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // numRebirthTEC
            // 
            this.numRebirthTEC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthTEC.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthTEC.Location = new System.Drawing.Point(148, 140);
            this.numRebirthTEC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthTEC.Name = "numRebirthTEC";
            this.numRebirthTEC.Size = new System.Drawing.Size(37, 18);
            this.numRebirthTEC.TabIndex = 73;
            this.numRebirthTEC.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // numRebirthEVA
            // 
            this.numRebirthEVA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthEVA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthEVA.Location = new System.Drawing.Point(148, 121);
            this.numRebirthEVA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthEVA.Name = "numRebirthEVA";
            this.numRebirthEVA.Size = new System.Drawing.Size(37, 18);
            this.numRebirthEVA.TabIndex = 72;
            this.numRebirthEVA.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // numRebirthACC
            // 
            this.numRebirthACC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthACC.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthACC.Location = new System.Drawing.Point(148, 102);
            this.numRebirthACC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthACC.Name = "numRebirthACC";
            this.numRebirthACC.Size = new System.Drawing.Size(37, 18);
            this.numRebirthACC.TabIndex = 71;
            this.numRebirthACC.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // numRebirthDEF
            // 
            this.numRebirthDEF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthDEF.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthDEF.Location = new System.Drawing.Point(148, 83);
            this.numRebirthDEF.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthDEF.Name = "numRebirthDEF";
            this.numRebirthDEF.Size = new System.Drawing.Size(37, 18);
            this.numRebirthDEF.TabIndex = 70;
            this.numRebirthDEF.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // numRebirthATK
            // 
            this.numRebirthATK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numRebirthATK.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebirthATK.Location = new System.Drawing.Point(148, 64);
            this.numRebirthATK.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRebirthATK.Name = "numRebirthATK";
            this.numRebirthATK.Size = new System.Drawing.Size(37, 18);
            this.numRebirthATK.TabIndex = 69;
            this.numRebirthATK.ValueChanged += new System.EventHandler(this.numRebirth_ValueChanged);
            // 
            // txtRebirthMND
            // 
            this.txtRebirthMND.AutoSize = true;
            this.txtRebirthMND.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthMND.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthMND.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthMND.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthMND.Location = new System.Drawing.Point(49, 161);
            this.txtRebirthMND.Name = "txtRebirthMND";
            this.txtRebirthMND.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthMND.TabIndex = 68;
            this.txtRebirthMND.Text = "-";
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Cursor = System.Windows.Forms.Cursors.Default;
            this.label53.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label53.Location = new System.Drawing.Point(11, 161);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(33, 13);
            this.label53.TabIndex = 67;
            this.label53.Text = "MND";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRebirthTEC
            // 
            this.txtRebirthTEC.AutoSize = true;
            this.txtRebirthTEC.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthTEC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthTEC.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthTEC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthTEC.Location = new System.Drawing.Point(49, 142);
            this.txtRebirthTEC.Name = "txtRebirthTEC";
            this.txtRebirthTEC.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthTEC.TabIndex = 66;
            this.txtRebirthTEC.Text = "-";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Cursor = System.Windows.Forms.Cursors.Default;
            this.label38.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label38.Location = new System.Drawing.Point(11, 142);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(33, 13);
            this.label38.TabIndex = 65;
            this.label38.Text = "TEC";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRebirthEVA
            // 
            this.txtRebirthEVA.AutoSize = true;
            this.txtRebirthEVA.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthEVA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthEVA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthEVA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthEVA.Location = new System.Drawing.Point(49, 123);
            this.txtRebirthEVA.Name = "txtRebirthEVA";
            this.txtRebirthEVA.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthEVA.TabIndex = 60;
            this.txtRebirthEVA.Text = "-";
            // 
            // txtRebirthACC
            // 
            this.txtRebirthACC.AutoSize = true;
            this.txtRebirthACC.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthACC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthACC.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthACC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthACC.Location = new System.Drawing.Point(49, 104);
            this.txtRebirthACC.Name = "txtRebirthACC";
            this.txtRebirthACC.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthACC.TabIndex = 64;
            this.txtRebirthACC.Text = "-";
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Cursor = System.Windows.Forms.Cursors.Default;
            this.label42.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label42.Location = new System.Drawing.Point(11, 123);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(33, 13);
            this.label42.TabIndex = 59;
            this.label42.Text = "EVA";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Cursor = System.Windows.Forms.Cursors.Default;
            this.label43.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label43.Location = new System.Drawing.Point(11, 104);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(33, 13);
            this.label43.TabIndex = 63;
            this.label43.Text = "ACC";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRebirthDEF
            // 
            this.txtRebirthDEF.AutoSize = true;
            this.txtRebirthDEF.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthDEF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthDEF.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthDEF.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthDEF.Location = new System.Drawing.Point(49, 85);
            this.txtRebirthDEF.Name = "txtRebirthDEF";
            this.txtRebirthDEF.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthDEF.TabIndex = 62;
            this.txtRebirthDEF.Text = "-";
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Cursor = System.Windows.Forms.Cursors.Default;
            this.label45.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label45.Location = new System.Drawing.Point(11, 85);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(33, 13);
            this.label45.TabIndex = 61;
            this.label45.Text = "DEF";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Cursor = System.Windows.Forms.Cursors.Default;
            this.label49.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label49.Location = new System.Drawing.Point(11, 66);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(33, 13);
            this.label49.TabIndex = 57;
            this.label49.Text = "ATK";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRebirthATK
            // 
            this.txtRebirthATK.AutoSize = true;
            this.txtRebirthATK.BackColor = System.Drawing.Color.Transparent;
            this.txtRebirthATK.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRebirthATK.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebirthATK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRebirthATK.Location = new System.Drawing.Point(49, 66);
            this.txtRebirthATK.Name = "txtRebirthATK";
            this.txtRebirthATK.Size = new System.Drawing.Size(10, 12);
            this.txtRebirthATK.TabIndex = 58;
            this.txtRebirthATK.Text = "-";
            // 
            // btnUndoAll
            // 
            this.btnUndoAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndoAll.Enabled = false;
            this.btnUndoAll.Location = new System.Drawing.Point(128, 488);
            this.btnUndoAll.Name = "btnUndoAll";
            this.btnUndoAll.Size = new System.Drawing.Size(59, 23);
            this.btnUndoAll.TabIndex = 23;
            this.btnUndoAll.Text = "reload";
            this.btnUndoAll.UseVisualStyleBackColor = true;
            this.btnUndoAll.Click += new System.EventHandler(this.btnUndoAll_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Location = new System.Drawing.Point(66, 488);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(60, 23);
            this.btnSaveAs.TabIndex = 24;
            this.btnSaveAs.Text = "save as";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // sexImageList
            // 
            this.sexImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sexImageList.ImageStream")));
            this.sexImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.sexImageList.Images.SetKeyName(0, "male-icon.ico");
            this.sexImageList.Images.SetKeyName(1, "female.png");
            this.sexImageList.Images.SetKeyName(2, "free_slot_2.ico");
            // 
            // armourImageList
            // 
            this.armourImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("armourImageList.ImageStream")));
            this.armourImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // itemImageList
            // 
            this.itemImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("itemImageList.ImageStream")));
            this.itemImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // clothesImageList
            // 
            this.clothesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("clothesImageList.ImageStream")));
            this.clothesImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // decoImageList
            // 
            this.decoImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("decoImageList.ImageStream")));
            this.decoImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.decoImageList.Images.SetKeyName(0, "item_extend.png");
            this.decoImageList.Images.SetKeyName(1, "item_pm.png");
            this.decoImageList.Images.SetKeyName(2, "item_decoration.png");
            this.decoImageList.Images.SetKeyName(3, "free_slot.png");
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databasesToolStripMenuItem,
            this.imagesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(640, 24);
            this.menuStrip.TabIndex = 73;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.updateToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.open1;
            this.openToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.save_icon;
            this.saveToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.check_for_update;
            this.updateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.updateToolStripMenuItem.Text = "Check For Updates";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.exit1;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // databasesToolStripMenuItem
            // 
            this.databasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDatabasesToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.databasesToolStripMenuItem.Name = "databasesToolStripMenuItem";
            this.databasesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.databasesToolStripMenuItem.Text = "Databases";
            // 
            // itemDatabasesToolStripMenuItem
            // 
            this.itemDatabasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weaponDatabaseToolStripMenuItem});
            this.itemDatabasesToolStripMenuItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.database_import;
            this.itemDatabasesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemDatabasesToolStripMenuItem.Name = "itemDatabasesToolStripMenuItem";
            this.itemDatabasesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.itemDatabasesToolStripMenuItem.Text = "Item Databases";
            // 
            // weaponDatabaseToolStripMenuItem
            // 
            this.weaponDatabaseToolStripMenuItem.Name = "weaponDatabaseToolStripMenuItem";
            this.weaponDatabaseToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.weaponDatabaseToolStripMenuItem.Text = "Weapon Database";
            this.weaponDatabaseToolStripMenuItem.Click += new System.EventHandler(this.weaponDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Image = global::pspo2seSaveEditorProgram.Properties.Resources.check_for_update;
            this.checkForUpdatesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1,
            this.checkForUpdatesToolStripMenuItem1});
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.imagesToolStripMenuItem.Text = "Images";
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // checkForUpdatesToolStripMenuItem1
            // 
            this.checkForUpdatesToolStripMenuItem1.Image = global::pspo2seSaveEditorProgram.Properties.Resources.check_for_update;
            this.checkForUpdatesToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkForUpdatesToolStripMenuItem1.Name = "checkForUpdatesToolStripMenuItem1";
            this.checkForUpdatesToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem1.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem1.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.versionInfoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // versionInfoToolStripMenuItem
            // 
            this.versionInfoToolStripMenuItem.Name = "versionInfoToolStripMenuItem";
            this.versionInfoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.versionInfoToolStripMenuItem.Text = "Version Info";
            this.versionInfoToolStripMenuItem.Click += new System.EventHandler(this.versionInfoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 74;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // txtFooterText
            // 
            this.txtFooterText.AutoSize = true;
            this.txtFooterText.BackColor = System.Drawing.Color.Transparent;
            this.txtFooterText.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFooterText.ForeColor = System.Drawing.Color.DarkGray;
            this.txtFooterText.Location = new System.Drawing.Point(0, 600);
            this.txtFooterText.Name = "txtFooterText";
            this.txtFooterText.Size = new System.Drawing.Size(302, 12);
            this.txtFooterText.TabIndex = 75;
            this.txtFooterText.Text = "Phantasy Star Portable 2 Save Editor by FunkySkunk 2014";
            // 
            // lstSaveSlotView
            // 
            this.lstSaveSlotView.BackColor = System.Drawing.SystemColors.Window;
            this.lstSaveSlotView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.slotViewHeader_name,
            this.slotViewHeader_level,
            this.slotViewHeader_class,
            this.slotViewHeader_type,
            this.slotViewHeader_complete});
            this.lstSaveSlotView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstSaveSlotView.Enabled = false;
            this.lstSaveSlotView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSaveSlotView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lstSaveSlotView.FullRowSelect = true;
            this.lstSaveSlotView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSaveSlotView.HideSelection = false;
            this.lstSaveSlotView.LabelWrap = false;
            this.lstSaveSlotView.Location = new System.Drawing.Point(183, 59);
            this.lstSaveSlotView.MultiSelect = false;
            this.lstSaveSlotView.Name = "lstSaveSlotView";
            this.lstSaveSlotView.Size = new System.Drawing.Size(454, 140);
            this.lstSaveSlotView.SmallImageList = this.sexImageList;
            this.lstSaveSlotView.TabIndex = 84;
            this.lstSaveSlotView.UseCompatibleStateImageBehavior = false;
            this.lstSaveSlotView.View = System.Windows.Forms.View.Details;
            this.lstSaveSlotView.SelectedIndexChanged += new System.EventHandler(this.saveSlotView_SelectedIndexChanged);
            // 
            // slotViewHeader_name
            // 
            this.slotViewHeader_name.Width = 125;
            // 
            // slotViewHeader_level
            // 
            this.slotViewHeader_level.Width = 50;
            // 
            // slotViewHeader_class
            // 
            this.slotViewHeader_class.Width = 65;
            // 
            // slotViewHeader_type
            // 
            this.slotViewHeader_type.Width = 70;
            // 
            // slotViewHeader_complete
            // 
            this.slotViewHeader_complete.Width = 140;
            // 
            // txtFileSize
            // 
            this.txtFileSize.BackColor = System.Drawing.Color.Transparent;
            this.txtFileSize.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFileSize.Location = new System.Drawing.Point(29, 146);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.Size = new System.Drawing.Size(143, 13);
            this.txtFileSize.TabIndex = 79;
            this.txtFileSize.Text = "0 bytes";
            this.txtFileSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnExportCharacter
            // 
            this.btnExportCharacter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportCharacter.Enabled = false;
            this.btnExportCharacter.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCharacter.Location = new System.Drawing.Point(280, 200);
            this.btnExportCharacter.Name = "btnExportCharacter";
            this.btnExportCharacter.Size = new System.Drawing.Size(96, 20);
            this.btnExportCharacter.TabIndex = 82;
            this.btnExportCharacter.Text = "export character";
            this.btnExportCharacter.UseVisualStyleBackColor = true;
            this.btnExportCharacter.Click += new System.EventHandler(this.btnExportCharacter_Click);
            // 
            // txtSlotnumloaded
            // 
            this.txtSlotnumloaded.AutoSize = true;
            this.txtSlotnumloaded.BackColor = System.Drawing.SystemColors.Control;
            this.txtSlotnumloaded.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlotnumloaded.ForeColor = System.Drawing.Color.Black;
            this.txtSlotnumloaded.Location = new System.Drawing.Point(530, 200);
            this.txtSlotnumloaded.Name = "txtSlotnumloaded";
            this.txtSlotnumloaded.Size = new System.Drawing.Size(112, 12);
            this.txtSlotnumloaded.TabIndex = 81;
            this.txtSlotnumloaded.Text = "No Save Slot Loaded ";
            this.txtSlotnumloaded.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnImportCharacter
            // 
            this.btnImportCharacter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportCharacter.Enabled = false;
            this.btnImportCharacter.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCharacter.Location = new System.Drawing.Point(182, 200);
            this.btnImportCharacter.Name = "btnImportCharacter";
            this.btnImportCharacter.Size = new System.Drawing.Size(96, 20);
            this.btnImportCharacter.TabIndex = 83;
            this.btnImportCharacter.Text = "import character";
            this.btnImportCharacter.UseVisualStyleBackColor = true;
            this.btnImportCharacter.Click += new System.EventHandler(this.btnImportCharacter_Click);
            // 
            // txtFileLoc
            // 
            this.txtFileLoc.Enabled = false;
            this.txtFileLoc.Location = new System.Drawing.Point(20, 29);
            this.txtFileLoc.Name = "txtFileLoc";
            this.txtFileLoc.Size = new System.Drawing.Size(584, 20);
            this.txtFileLoc.TabIndex = 77;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(610, 29);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 20);
            this.btnBrowse.TabIndex = 76;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // grpImageFloater
            // 
            this.grpImageFloater.BackColor = System.Drawing.SystemColors.Window;
            this.grpImageFloater.Controls.Add(this.imgFloater);
            this.grpImageFloater.Controls.Add(this.panelImageFloater);
            this.grpImageFloater.Location = new System.Drawing.Point(458, 474);
            this.grpImageFloater.Name = "grpImageFloater";
            this.grpImageFloater.Size = new System.Drawing.Size(174, 139);
            this.grpImageFloater.TabIndex = 72;
            this.grpImageFloater.TabStop = false;
            // 
            // imgFloater
            // 
            this.imgFloater.BackColor = System.Drawing.Color.Black;
            this.imgFloater.Location = new System.Drawing.Point(7, 13);
            this.imgFloater.Name = "imgFloater";
            this.imgFloater.Size = new System.Drawing.Size(160, 120);
            this.imgFloater.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFloater.TabIndex = 0;
            this.imgFloater.TabStop = false;
            // 
            // panelImageFloater
            // 
            this.panelImageFloater.Location = new System.Drawing.Point(458, 480);
            this.panelImageFloater.Name = "panelImageFloater";
            this.panelImageFloater.Size = new System.Drawing.Size(174, 133);
            this.panelImageFloater.TabIndex = 72;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(4, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageListWeaponElements
            // 
            this.imageListWeaponElements.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListWeaponElements.ImageStream")));
            this.imageListWeaponElements.TransparentColor = System.Drawing.Color.Transparent;
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
            this.imageListWeaponElements.Images.SetKeyName(127, "016_longbow.png");
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
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // imgSave
            // 
            this.imgSave.Image = global::pspo2seSaveEditorProgram.Properties.Resources.PSP2;
            this.imgSave.InitialImage = global::pspo2seSaveEditorProgram.Properties.Resources.PSP2;
            this.imgSave.Location = new System.Drawing.Point(24, 63);
            this.imgSave.Name = "imgSave";
            this.imgSave.Size = new System.Drawing.Size(144, 80);
            this.imgSave.TabIndex = 78;
            this.imgSave.TabStop = false;
            this.imgSave.Visible = false;
            // 
            // imgLogo
            // 
            this.imgLogo.BackColor = System.Drawing.Color.Transparent;
            this.imgLogo.Image = global::pspo2seSaveEditorProgram.Properties.Resources.icon_10th;
            this.imgLogo.Location = new System.Drawing.Point(3, 547);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(63, 50);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLogo.TabIndex = 4;
            this.imgLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::pspo2seSaveEditorProgram.Properties.Resources.NOICON;
            this.pictureBox1.Location = new System.Drawing.Point(20, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 90);
            this.pictureBox1.TabIndex = 80;
            this.pictureBox1.TabStop = false;
            // 
            // imgGameLogo
            // 
            this.imgGameLogo.BackColor = System.Drawing.Color.Transparent;
            this.imgGameLogo.Image = global::pspo2seSaveEditorProgram.Properties.Resources.PSP2_logo;
            this.imgGameLogo.InitialImage = global::pspo2seSaveEditorProgram.Properties.Resources.PSP2_logo;
            this.imgGameLogo.Location = new System.Drawing.Point(437, 488);
            this.imgGameLogo.Name = "imgGameLogo";
            this.imgGameLogo.Size = new System.Drawing.Size(200, 126);
            this.imgGameLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgGameLogo.TabIndex = 13;
            this.imgGameLogo.TabStop = false;
            // 
            // pspo2seForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(640, 632);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFileSize);
            this.Controls.Add(this.btnExportCharacter);
            this.Controls.Add(this.txtSlotnumloaded);
            this.Controls.Add(this.btnImportCharacter);
            this.Controls.Add(this.txtFileLoc);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.imgSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnUndoAll);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.tabArea);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstSaveSlotView);
            this.Controls.Add(this.txtFooterText);
            this.Controls.Add(this.grpImageFloater);
            this.Controls.Add(this.imgGameLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(660, 675);
            this.MinimumSize = new System.Drawing.Size(660, 675);
            this.Name = "pspo2seForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PSPo2 Save Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pspo2seForm_FormClosing);
            this.tabArea.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeaponSlot04)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.imgHuTmagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuMachinegunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuHandgunsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuShotgunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuClawRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDaggersRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSpearRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuWandRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuCardsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuLaserRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRifleRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDaggerRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSabersRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuKnucklesRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuShieldRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRmagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuHandgunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuLongbowRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuWhipRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuClawsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDblSaberRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRodRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuCrossbowRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuGrenadeRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSlicerRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSaberRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuAxeRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSwordRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRmag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuMachinegun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuCrossbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuHandgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuHandguns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuGrenade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuLaser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuLongbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuShotgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSlicer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRifle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuWhip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuClaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSaber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDagger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuShield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuTmag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuRod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuWand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuClaws)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDaggers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuAxe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSabers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuDblSaber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuKnuckles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSpear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuSword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox231)).EndInit();
            this.tabPageRanger.ResumeLayout(false);
            this.tabPageRanger.PerformLayout();
            this.grpRaTypeExtend.ResumeLayout(false);
            this.grpRaTypeExtend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaTmagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaMachinegunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaHandgunsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaShotgunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaClawRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDaggersRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSpearRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaWandRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaCardsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaLaserRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRifleRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDaggerRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSabersRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaKnucklesRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaShieldRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRmagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaHandgunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaLongbowRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaWhipRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaClawsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDblSaberRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRodRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaCrossbowRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaGrenadeRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSlicerRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSaberRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaAxeRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSwordRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRmag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaMachinegun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaCrossbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaHandgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaHandguns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaGrenade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaLaser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaLongbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaShotgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSlicer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRifle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaWhip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaClaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSaber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDagger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaShield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaTmag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaRod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaWand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaClaws)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDaggers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaAxe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSabers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaDblSaber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaKnuckles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSpear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRaSword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox174)).EndInit();
            this.tabPageForce.ResumeLayout(false);
            this.tabPageForce.PerformLayout();
            this.grpFoTypeExtend.ResumeLayout(false);
            this.grpFoTypeExtend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoTmagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoMachinegunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoHandgunsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoShotgunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoClawRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDaggersRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSpearRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoWandRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoCardsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoLaserRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRifleRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDaggerRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSabersRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoKnucklesRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoShieldRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRmagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoHandgunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoLongbowRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoWhipRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoClawsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDblSaberRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRodRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoCrossbowRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoGrenadeRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSlicerRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSaberRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoAxeRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSwordRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRmag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoMachinegun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoCrossbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoHandgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoHandguns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoGrenade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoLaser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoLongbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoShotgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSlicer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRifle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoWhip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoClaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSaber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDagger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoShield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoTmag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoRod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoWand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoClaws)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDaggers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoAxe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSabers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoDblSaber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoKnuckles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSpear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoSword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox117)).EndInit();
            this.tabPageVanguard.ResumeLayout(false);
            this.tabPageVanguard.PerformLayout();
            this.grpVaTypeExtend.ResumeLayout(false);
            this.grpVaTypeExtend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaTmagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaMachinegunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaHandgunsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaShotgunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaClawRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDaggersRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSpearRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaWandRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaCardsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaLaserRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRifleRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDaggerRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSabersRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaKnucklesRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaShieldRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRmagRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaHandgunRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaLongbowRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaWhipRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaClawsRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDblSaberRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRodRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaCrossbowRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaGrenadeRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSlicerRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSaberRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaAxeRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSwordRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRmag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaMachinegun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaCrossbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaHandgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaHandguns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaGrenade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaLaser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaLongbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaShotgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSlicer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRifle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaWhip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaClaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSaber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDagger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaShield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaTmag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaRod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaWand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaClaws)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDaggers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaAxe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSabers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaDblSaber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaKnuckles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSpear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVaSword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.tabPageInventory.ResumeLayout(false);
            this.tabPageInventory.PerformLayout();
            this.inventoryViewPages.ResumeLayout(false);
            this.grpInventoryItemDetails.ResumeLayout(false);
            this.grpInventoryItemDetails.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.tabPageStorage.ResumeLayout(false);
            this.tabPageStorage.PerformLayout();
            this.storageViewPages.ResumeLayout(false);
            this.grpStorageItemDetails.ResumeLayout(false);
            this.grpStorageItemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageStar0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageWeaponManufacturer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageItemIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageElement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStorageInfinityItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).EndInit();
            this.tabPABullets.ResumeLayout(false);
            this.tabPATech.ResumeLayout(false);
            this.tabPageRebirth.ResumeLayout(false);
            this.tabPageRebirth.PerformLayout();
            this.grpRebirth.ResumeLayout(false);
            this.grpRebirth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthSTA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthMND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthTEC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthEVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthACC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthDEF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebirthATK)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpImageFloater.ResumeLayout(false);
            this.grpImageFloater.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFloater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGameLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
