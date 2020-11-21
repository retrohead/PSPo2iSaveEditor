namespace apPatcherApp
{
    using apPatcherApp.Properties;
    using Blue.Windows;
    using CSEncryptDecrypt;
    using dsRomHeaderFunctions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class apPatcherAppForm : Form
    {
        private const uint WM_KEYDOWN = 0x100;
        public const int MAX_APP_DOWNLOAD_FILES = 20;
        private byte[] trimbuffer = new byte[0x400];
        private OpenFileDialog fdlg = new OpenFileDialog();
        private Crc32 crc32 = new Crc32();
        public crcDupes crcDb = new crcDupes();
        public bool rarInstalled = true;
        public bool zipInstalled = true;
        public compressedArchiveOperator compressor = new compressedArchiveOperator();
        public runFunctionsType run = new runFunctionsType();
        public Bitmap webBoxart;
        public Bitmap webRegionFlag;
        public encryptRoutineType encryptor = new encryptRoutineType();
        public dsromHeader romHeader = new dsromHeader();
        public patchdb patchDb = new patchdb();
        public collectionDb collectiondb = new collectionDb();
        public patchdb.patchdb_PatchClass patchInfo = new patchdb.patchdb_PatchClass();
        private updateInfoForm updateViewer = new updateInfoForm();
        private changeLogForm changelogForm = new changeLogForm();
        private batchPatchForm batchForm = new batchPatchForm();
        public emulatorConfig emulatorConfigForm = new emulatorConfig();
        public collectionViewer collectionForm;
        public batchOrganiseForm organiseForm = new batchOrganiseForm();
        public webInfo web = new webInfo();
        public optionsInfo options = new optionsInfo();
        public bool databasesOk = true;
        public bool firstload = true;
        public bool firstInstall;
        public bool firstboot = true;
        public string crchash = string.Empty;
        private apPatcherNfoViewer nfoform;
        public cmpGameListItem[] cmpGames = new cmpGameListItem[0x61a8];
        public int cmpGamesFilled;
        public cmpCheckFileType[] cmpCheckFile = new cmpCheckFileType[4];
        private bool allowDownload = true;
        private byte[] downloadedData = new byte[0x7d000];
        private string downloadedDataName;
        private IContainer components;
        public TextBox txtFileLoc;
        private Button btnBrowse;
        private Label txtFooterText;
        private Label appUrlFooter;
        private Label dbGamesText;
        private PictureBox romIcon;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem databaseToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label label8;
        private Label label6;
        private Label txtHdrTitle;
        private TextBox cardSizeText;
        private TextBox gameCodeText;
        private TextBox gameTitleText;
        private TabControl tabControlMain;
        private TabPage tabRomInfo;
        private TabPage tabApPatch;
        private GroupBox apPatchInfoGrp;
        private TabControl tabControlLang;
        private TabPage tabLangJpn;
        private TabPage tabLangEng;
        private TabPage tabLangFre;
        private TabPage tabLangGer;
        private TabPage tabLangIta;
        private TabPage tabLangSpa;
        private RichTextBox name_jpnText;
        private RichTextBox name_freText;
        private RichTextBox name_gerText;
        private RichTextBox name_itaText;
        private RichTextBox name_spaText;
        private TextBox crc32Text;
        private Label label1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button buttonSaveIcon;
        private PictureBox romIcon2;
        private Label patchNameText;
        private TextBox fileSizeText;
        private Label label2;
        private ToolStripMenuItem homeToolStripMenuItem;
        private TextBox makerNameText;
        private TextBox makerCodeText;
        private Label label4;
        private TabPage tabExport;
        private Button buttonApply;
        private ToolStripMenuItem changeLogToolStripMenuItem;
        private Label patchCreatorText;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private TabPage tabWebInfo;
        private GroupBox groupBox2;
        private TextBox webInfo_arc;
        private PictureBox romIcon3;
        private Label label12;
        private PictureBox webInfo_Boxart;
        private TextBox webInfo_save;
        private TextBox webInfo_number;
        private Label label11;
        private Label label5;
        private TextBox webInfo_grp;
        private Label label7;
        private Label label10;
        private TextBox webInfo_name;
        private Label label9;
        private Label label13;
        private TextBox webInfo_dir;
        private Button buttonRomInfo;
        private PictureBox webInfo_wifi;
        private PictureBox webInfo_dscompat;
        private PictureBox webInfo_rgn;
        private Label webInfo_newsdate;
        private Label label16;
        private Label label15;
        private Label webInfo_date;
        private Button buttonForumLink;
        private TextBox webInfo_id;
        private RichTextBox patchInfoText;
        private Label label14;
        private ToolStripMenuItem dSSceneContentToolStripMenuItem;
        public ToolStripMenuItem disableWebContentToolStripMenuItem;
        public ToolStripMenuItem disableWebAlertContentToolStripMenuItem;
        public ToolStripMenuItem autoDownloadToolStripMenuItem;
        private RichTextBox name_engText;
        private ToolStripMenuItem batchProcessToolStripMenuItem;
        public ProgressBar toolStripProgressBar;
        private ToolStripMenuItem patchingToolStripMenuItem;
        private ToolStripMenuItem aPDatabaseToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem1;
        private ToolStripMenuItem versionInfoToolStripMenuItem1;
        private ToolStripMenuItem cMPDatabaseToolStripMenuItem1;
        private ToolStripMenuItem installToMediaToolStripMenuItem;
        private ToolStripMenuItem uSRCHEATToolStripMenuItem;
        private ToolStripMenuItem edgeCMPToolStripMenuItem;
        private ToolStripMenuItem cycloDSCMPToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripMenuItem versionInfoToolStripMenuItem;
        private ToolStripMenuItem updateAlertsToolStripMenuItem1;
        public ToolStripMenuItem cycloDSToolStripMenuItem;
        public ToolStripMenuItem eDGEToolStripMenuItem;
        public ToolStripMenuItem uSRcheatToolStripMenuItem1;
        private Button btnImportAP;
        private Button btnExportAP;
        private ImageList imageList1;
        public Label toolStripStatusLabel;
        public ToolStripMenuItem rememberDSSceneInfoToolStripMenuItem;
        private Label romTypeTxt;
        private Button cmpDbSupportBtn;
        private ToolStripMenuItem updateAlertsToolStripMenuItem;
        public ToolStripMenuItem enableUpdateAlertsToolStripMenuItem;
        private GroupBox iconEditorGroup;
        private CheckBox picPal_3;
        private CheckBox picPal_2;
        private CheckBox picPal_1;
        private CheckBox picPal_0;
        private CheckBox picPal_15;
        private CheckBox picPal_14;
        private CheckBox picPal_13;
        private CheckBox picPal_12;
        private CheckBox picPal_7;
        private CheckBox picPal_6;
        private CheckBox picPal_5;
        private CheckBox picPal_4;
        private CheckBox picPal_11;
        private CheckBox picPal_10;
        private CheckBox picPal_9;
        private CheckBox picPal_8;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem applicationUpdatesToolStripMenuItem;
        private ToolStripMenuItem checkForUpdateToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        public ToolStripMenuItem disableCheckOnStartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private GroupBox groupBox5;
        private CheckBox checkBoxDelete;
        private ComboBox compressionSelect;
        private GroupBox groupBox4;
        private RadioButton radioAccurateTrim;
        private CheckBox checkBoxTrim;
        private RadioButton radioSafeTrim;
        private GroupBox groupBox1;
        private CheckBox checkBoxApPatch;
        private ToolStripMenuItem tesToolStripMenuItem;
        private ToolStripMenuItem romCollectionsToolStripMenuItem;
        private Panel panel1;
        public ToolStripMenuItem collectionBrowserToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem1;
        public ToolStripMenuItem autoOpenBrowserToolStripMenuItem;
        private ToolStripMenuItem autoLaunchEmulatorToolStripMenuItem;
        private ToolStripMenuItem emulatorLocationsToolStripMenuItem;
        private Button launchEmulator;
        private PictureBox pic3DSCard;
        private PictureBox picDSCard;
        private PictureBox n3dsopt_2;
        private PictureBox n3dsopt_4;
        private PictureBox n3dsopt_1;
        private PictureBox n3dsopt_3;
        private PictureBox n3dsopt_0;
        private Button btnNFO;
        private ToolStripMenuItem nFOViewerToolStripMenuItem;
        private PictureBox n3dsopt_5;
        private Button btnHeaderRefresh;
        private PictureBox picNinNetwork;

        public apPatcherAppForm()
        {
            this.InitializeComponent();
            StickyWindow.RegisterExternalReferenceForm(this);
            base.MaximizeBox = false;
            if (System.IO.File.Exists("c:/Windows/Fonts/meiryo.ttc"))
            {
                this.changeAllFonts("Meiryo UI");
            }
            this.deleteOldUpdater();
            this.createAppFolders();
            this.cleanTempFiles();
            this.setupOptionsDisplay();
            Application.DoEvents();
            this.firstboot = false;
            this.patchInfo = null;
            this.Text = "DS-Scene Rom Tool v1.0 build 1215";
            this.txtFooterText.Text = "DS-Scene Rom Tool v1.0 build 1215";
            this.btnBrowse.Enabled = true;
            this.initRomInfoFields();
            this.disableTabs();
            this.romHeader.initMakers();
            this.romHeader.initCountries();
        }

        public bool action_browse(string fn = "", string crctodo = "")
        {
            bool flag = false;
            this.disableMainForm();
            try
            {
                this.fdlg = new OpenFileDialog();
                this.fdlg.Title = "DS-Scene Rom Tool: Open File";
                if (!this.rarInstalled && !this.zipInstalled)
                {
                    this.fdlg.Filter = "Nintendo DS/3DS Roms|*.nds;*.3ds";
                }
                else if (this.rarInstalled && this.zipInstalled)
                {
                    this.fdlg.Filter = "Nintendo DS/3DS Roms|*.nds;*.3ds;*.zip;*.rar;*.7z";
                }
                else if (this.rarInstalled)
                {
                    this.fdlg.Filter = "Nintendo DS/3DS Roms|*.nds;*.3ds;*.rar";
                }
                else if (this.zipInstalled)
                {
                    this.fdlg.Filter = "Nintendo DS/3DS Roms|*.nds;*.3ds;*.zip;*.7z";
                }
                this.fdlg.FilterIndex = 1;
                this.fdlg.RestoreDirectory = true;
                DialogResult cancel = DialogResult.Cancel;
                if (fn == "")
                {
                    cancel = this.fdlg.ShowDialog();
                }
                else
                {
                    cancel = DialogResult.OK;
                    this.fdlg.FileName = fn;
                }
                if (cancel == DialogResult.OK)
                {
                    if (this.doRomFileActions(crctodo))
                    {
                        if (this.romHeader.romHeader.loaded)
                        {
                            this.displayRomHeaderInfo();
                            this.toolStripProgressBar.Maximum = 1;
                            this.toolStripProgressBar.Value = 1;
                            this.toolStripStatusLabel.Text = "Rom Loaded";
                            flag = true;
                        }
                        else
                        {
                            this.txtFileLoc.Text = "";
                            this.initRomInfoFields();
                            this.disableTabs();
                            this.toolStripProgressBar.Maximum = 1;
                            this.toolStripProgressBar.Value = 1;
                            this.toolStripStatusLabel.Text = "Failed";
                            this.tabExport.Enabled = false;
                            this.apPatchSupported(false, crcDupes.romTypes.unknown, null);
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        this.enableMainForm();
                        return false;
                    }
                }
                if (this.txtFileLoc.Text != "")
                {
                    this.enableTabs();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong opening the file!\n\n" + exception.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtFileLoc.Text = "";
                this.initRomInfoFields();
                this.disableTabs();
                this.toolStripProgressBar.Maximum = 1;
                this.toolStripProgressBar.Value = 1;
                this.toolStripStatusLabel.Text = "Failed";
                this.tabExport.Enabled = false;
                this.apPatchSupported(false, crcDupes.romTypes.unknown, null);
                Application.DoEvents();
                this.cmpCheatsFound(false);
            }
            this.fdlg = null;
            this.enableMainForm();
            return flag;
        }

        private void action_exportRom()
        {
            if (!this.checkBoxApPatch.Checked || (this.patchInfo != null))
            {
                string romOut = this.openSaveDialogue();
                while (true)
                {
                    if (romOut != this.txtFileLoc.Text)
                    {
                        if (romOut != null)
                        {
                            if (!this.txtFileLoc.Text.ToLower().EndsWith(".nds") && !this.txtFileLoc.Text.ToLower().EndsWith(".3ds"))
                            {
                                string str2 = "/data/temp/";
                                if (Path.GetDirectoryName(Application.ExecutablePath).Replace('\\', '+') != Path.GetDirectoryName(Application.ExecutablePath))
                                {
                                    str2 = str2.Replace('/', '\\');
                                }
                                string arcType = Program.form.getFileExtension(this.txtFileLoc.Text);
                                if (!this.extractRom(this.txtFileLoc.Text, Path.GetDirectoryName(Application.ExecutablePath) + str2, arcType, this.toolStripProgressBar, this.toolStripStatusLabel))
                                {
                                    MessageBox.Show("There was a problem extracting the selected archive.\nIs it a valid archive and does it contain a .nds or .3ds file?", "File Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return;
                                }
                                this.txtFileLoc.Text = this.compressor.outFile + this.compressor.extracting_file;
                            }
                            string compress = "";
                            if (this.compressionSelect.Enabled)
                            {
                                switch (this.compressionSelect.SelectedIndex)
                                {
                                    case 1:
                                        compress = "7z";
                                        break;

                                    case 2:
                                        compress = "zip";
                                        break;

                                    default:
                                        break;
                                }
                            }
                            this.disableMainForm();
                            romTrimTypes none = romTrimTypes.none;
                            if (this.radioSafeTrim.Checked)
                            {
                                none = romTrimTypes.safe;
                            }
                            if (this.radioAccurateTrim.Checked)
                            {
                                none = romTrimTypes.accurate;
                            }
                            long err = this.doExportRomAction(this.txtFileLoc.Text, romOut, none, this.checkBoxApPatch.Checked, compress, this.checkBoxDelete.Checked, this.toolStripProgressBar, this.toolStripStatusLabel, false, false);
                            this.crcDb.writeDb();
                            if (err > 0L)
                            {
                                MessageBox.Show("The rom was exported successfully", "Rom Export Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show(this.romExportError(err, "", false), "Rom Export Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            this.enableMainForm();
                        }
                        break;
                    }
                    MessageBox.Show("You must select a different location to the source file", "Original File Selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    romOut = this.openSaveDialogue();
                }
            }
        }

        private void action_loadDatabase()
        {
            this.databasesOk = true;
            if (this.patchDb.loadDatabase())
            {
                this.dbGamesText.Text = "Database supports " + this.patchDb.db_filled + " games";
            }
            else
            {
                this.databasesOk = false;
                this.dbGamesText.Text = "No database found";
            }
        }

        public void addGameToCMPList(cmpGameListItem item)
        {
            if (this.cmpGamesFilled >= 0x61a8)
            {
                MessageBox.Show("Fatal Error! The cmpGameList is full!");
            }
            else if ((item.region == "") || ((item.name == "") || ((item.hash == "") || (item.gameCode == ""))))
            {
                MessageBox.Show("Not supported " + this.cmpGamesFilled);
            }
            else
            {
                this.cmpGames[this.cmpGamesFilled] = item;
                this.cmpGamesFilled++;
            }
        }

        private void apPatcherApp_DragDrop(object sender, DragEventArgs e)
        {
            string[] data = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            if (data.Length > 1)
            {
                MessageBox.Show("You can only drop one file at a time, the first file will be loaded.\n\nPlease use the batch process menu for multiple files", "Multiple Files Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            string[] strArray2 = data;
            int index = 0;
            if (index < strArray2.Length)
            {
                string fn = strArray2[index];
                this.action_browse(fn, "");
            }
        }

        private void apPatcherApp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void apPatcherApp_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            base.DragEnter += new DragEventHandler(this.apPatcherApp_DragEnter);
            base.DragDrop += new DragEventHandler(this.apPatcherApp_DragDrop);
        }

        private void apPatcherAppForm_Shown(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("updater_v0.2.exe"))
            {
                if (MessageBox.Show("The required sub application could not be found:\r\nupdater_v0.2.exe\r\n\r\nThe application will not start if this file is missing.\n\nDo you want to try an automatic installation now via the web?", "Missing Sub-Application", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    this.downloadUpdater();
                }
                else
                {
                    Environment.Exit(0);
                }
                if (!System.IO.File.Exists("updater_v0.2.exe"))
                {
                    MessageBox.Show("Failed to download updater");
                    Environment.Exit(0);
                }
            }
            if (!System.IO.File.Exists("7z.dll"))
            {
                if (MessageBox.Show("The 7z.dll is missing, you will not be able to open\ncompressed roms in .zip or .7z archives.\n\nDo you want to try an automatic installation now via the web?", "Missing Driver", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    this.downloadZipDriver();
                }
                else
                {
                    this.zipInstalled = false;
                }
            }
            if (!System.IO.File.Exists("unrar.dll"))
            {
                if (MessageBox.Show("The unrar.dll is missing, you will not be able to open\ncompressed roms in .rar archives.\n\nDo you want to try an automatic installation now via the web?", "Missing Driver", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    this.downloadRarDriver();
                }
                else
                {
                    this.rarInstalled = false;
                }
            }
            if (this.rarInstalled && this.zipInstalled)
            {
                this.compressionSelect.SelectedIndex = 0;
            }
            else
            {
                this.compressionSelect.Enabled = false;
                this.checkBoxDelete.Enabled = false;
                this.checkBoxDelete.Checked = false;
            }
            if (!this.firstInstall)
            {
                this.loadCMPVersionTxt();
                this.action_loadDatabase();
                Application.DoEvents();
                this.collectiondb.load();
                this.crcDb.loadDb();
                this.options.load();
                if (this.options.getValue("disable_crc_db") != "1")
                {
                    this.crcDb.db.active = true;
                }
                if (this.options.getValue("disable_update") != "1")
                {
                    this.checkAppUpdate(false);
                }
                if (this.options.getValue("ap_update_check") != "0")
                {
                    this.checkDatabaseUpdate(false);
                }
                if (this.options.getValue("cmp_usrcheat_update_check") != "0")
                {
                    this.checkCMPDatabaseUpdate(false, cmpDownloadType.USRcheat);
                }
                if (this.options.getValue("cmp_edgecheat_update_check") == "1")
                {
                    this.checkCMPDatabaseUpdate(false, cmpDownloadType.EDGE);
                }
                if (this.options.getValue("cmp_cyclocheat_update_check") == "1")
                {
                    this.checkCMPDatabaseUpdate(false, cmpDownloadType.CycloDS);
                }
                if (Program.form.options.getValue("auto_open_collections") == "1")
                {
                    this.collectionBrowserToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void apPatchSupported(bool supported, crcDupes.romTypes type, patchdb.patchdb_PatchClass patch = null)
        {
            if (!supported || (patch == null))
            {
                this.apPatchInfoGrp.Text = "AP Patch Info";
                this.patchNameText.Text = "Not supported";
                this.patchInfoText.Text = "Not supported";
                this.patchCreatorText.Text = "";
                this.tabApPatch.ImageIndex = 2;
                this.apPatchInfoGrp.Enabled = false;
                this.patchNameText.Enabled = false;
                this.patchCreatorText.Enabled = false;
                this.btnImportAP.Enabled = true;
                this.btnExportAP.Enabled = false;
                this.checkBoxApPatch.Enabled = false;
                this.checkBoxApPatch.Checked = false;
            }
            else
            {
                this.apPatchInfoGrp.Text = "AP Patch Info (" + patch.patchlines + " offsets)";
                this.patchNameText.Text = patch.name;
                this.patchCreatorText.Text = "Patch created by " + patch.creator;
                this.patchInfoText.Text = "";
                for (int i = 0; i < patch.patchlines; i++)
                {
                    this.patchInfoText.Text = this.patchInfoText.Text + patch.patchline[i].orig_str + "\n";
                }
                this.tabApPatch.ImageIndex = 3;
                this.apPatchInfoGrp.Enabled = true;
                this.patchNameText.Enabled = true;
                this.patchCreatorText.Enabled = true;
                this.btnImportAP.Enabled = false;
                this.btnExportAP.Enabled = true;
                if ((type != crcDupes.romTypes.apPatched) && (type != crcDupes.romTypes.apAndTrim))
                {
                    this.checkBoxApPatch.Enabled = true;
                    this.checkBoxApPatch.Checked = true;
                }
                else
                {
                    this.checkBoxApPatch.Enabled = false;
                    this.checkBoxApPatch.Checked = false;
                }
            }
        }

        private void appUrlFooter_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.ds-scene.net");
        }

        private void autoDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        private void autoOpenBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (Program.form.autoOpenBrowserToolStripMenuItem.Checked && ("1" != Program.form.options.getValue("auto_open_collections")))
            {
                flag = true;
            }
            else if (!Program.form.autoOpenBrowserToolStripMenuItem.Checked && ("0" != Program.form.options.getValue("auto_open_collections")))
            {
                flag = true;
            }
            if (flag && (e != null))
            {
                Program.form.options.save();
                Program.form.options.load();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.action_browse("", "");
        }

        private void btnExportAP_Click(object sender, EventArgs e)
        {
            if (this.patchInfo == null)
            {
                MessageBox.Show("The is no AP Patch file loaded to export", "No AP Patch File Loaded", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    Title = "DS-Scene Rom Tool: Save AP Patch File",
                    Filter = "DS-Scene Rom Tool Encrypted AP Patch File|*.dsapf|DS-Scene Rom Tool Raw AP Patch File|*.txt|Open Patch Raw AP Patch File|*.txt",
                    FilterIndex = 1
                };
                string outPutFolder = "";
                outPutFolder = (this.txtFileLoc.Text.Replace('/', '+') == this.txtFileLoc.Text) ? this.txtFileLoc.Text.Substring(0, this.txtFileLoc.Text.LastIndexOf('\\') + 1) : this.txtFileLoc.Text.Substring(0, this.txtFileLoc.Text.LastIndexOf('/') + 1);
                string newExt = "";
                newExt = (dialog.FilterIndex != 1) ? "txt" : "dsapf";
                dialog.FileName = this.origFileLocToNewFileName(this.changeFileExt(this.txtFileLoc.Text, newExt), this.checkBoxTrim.Checked, this.checkBoxApPatch.Checked, outPutFolder);
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fn = this.fixFileNameNoExt(dialog.FileName, "*." + newExt);
                    fn = this.changeFileExt(fn, newExt);
                    string path = "data/temp/ap_export.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            if (dialog.FilterIndex == 3)
                            {
                                writer.WriteLine(this.patchInfo.name + " [" + this.patchInfo.hash + "]");
                            }
                            else
                            {
                                writer.WriteLine(this.patchInfo.name + " [" + this.patchInfo.hash + "] " + this.patchInfo.creator);
                            }
                            int index = 0;
                            index = 0;
                            while (true)
                            {
                                if (index >= this.patchInfo.patchlines)
                                {
                                    writer.Close();
                                    if (newExt == "dsapf")
                                    {
                                        string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                                        this.encryptor.EncryptFile(path, fn, sKey, GCHandle.Alloc(sKey, GCHandleType.Pinned));
                                        System.IO.File.Delete(path);
                                    }
                                    else
                                    {
                                        if (System.IO.File.Exists(fn))
                                        {
                                            System.IO.File.Delete(fn);
                                        }
                                        System.IO.File.Move(path, fn);
                                    }
                                    MessageBox.Show("The patch was exported successfully and can be found at:\n\n" + fn, "AP Patch Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    break;
                                }
                                writer.WriteLine(this.patchInfo.patchline[index].orig_str);
                                index++;
                            }
                        }
                    }
                    catch (Exception exception1)
                    {
                        MessageBox.Show(exception1.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void btnHeaderRefresh_Click(object sender, EventArgs e)
        {
            string[] strArray = new string[] { "data/header_cache/", this.romHeader.romHeader.hash.Substring(0, 1), "/", this.romHeader.romHeader.hash, ".dsrhd" };
            if (System.IO.File.Exists(string.Concat(strArray)))
            {
                System.IO.File.Delete("data/header_cache/" + this.romHeader.romHeader.hash.Substring(0, 1) + "/" + this.romHeader.romHeader.hash + ".dsrhd");
            }
            this.action_browse(this.txtFileLoc.Text, "");
        }

        private void btnImportAP_Click(object sender, EventArgs e)
        {
            if (this.patchInfo != null)
            {
                MessageBox.Show("There is already an AP Patch for this rom loaded", "AP Patch File Already Loaded", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.fdlg = new OpenFileDialog();
                this.fdlg.Title = "DS-Scene Rom Tool: Open AP Patch File";
                this.fdlg.Filter = "DS-Scene Rom Tool AP Patch File|*.dsapf;*.txt";
                this.fdlg.FilterIndex = 1;
                this.fdlg.RestoreDirectory = true;
                if (this.fdlg.ShowDialog() == DialogResult.OK)
                {
                    patchdb.patchdb_PatchClass class2 = null;
                    try
                    {
                        FileStream stream = new FileStream(this.fdlg.FileName, FileMode.Open, FileAccess.Read);
                        if (this.getFileExtension(this.fdlg.FileName) != "dsapf")
                        {
                            using (StreamReader reader2 = new StreamReader(stream))
                            {
                                while (true)
                                {
                                    string str6 = reader2.ReadLine();
                                    if (str6 == null)
                                    {
                                        reader2.Close();
                                        break;
                                    }
                                    try
                                    {
                                        char[] separator = new char[] { '[' };
                                        string[] strArray2 = str6.Split(separator);
                                        string name = strArray2[0];
                                        string str8 = strArray2[1];
                                        char[] chArray4 = new char[] { ']' };
                                        strArray2 = str8.Split(chArray4);
                                        if (strArray2[0].Length == 8)
                                        {
                                            class2 = this.patchDb.readPatchFromStream(reader2, name, strArray2[0], strArray2[1]);
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        else
                        {
                            string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                            using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, stream)))
                            {
                                while (true)
                                {
                                    string str3 = reader.ReadLine();
                                    if (str3 == null)
                                    {
                                        reader.Close();
                                        break;
                                    }
                                    try
                                    {
                                        char[] separator = new char[] { '[' };
                                        string[] strArray = str3.Split(separator);
                                        string name = strArray[0];
                                        string str5 = strArray[1];
                                        char[] chArray2 = new char[] { ']' };
                                        strArray = str5.Split(chArray2);
                                        if (strArray[0].Length == 8)
                                        {
                                            class2 = this.patchDb.readPatchFromStream(reader, name, strArray[0], strArray[1]);
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        stream.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("The selected file does not appear to be valid\n\n" + exception.Message, "AP Patch File Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    if (class2 != null)
                    {
                        if ((class2.hash.ToUpper() == this.romHeader.romHeader.hash.ToUpper()) || (class2.hash.ToUpper() == this.romHeader.romHeader.cleanCrc.hash.ToUpper()))
                        {
                            this.patchInfo = class2;
                            this.apPatchSupported(true, this.romHeader.romHeader.cleanCrc.type, this.patchInfo);
                        }
                        else
                        {
                            MessageBox.Show("The selected file does not appear to be valid for this rom,\nplease check the CRC32 is correct.\n\nThe file you attempteded to load is:\n" + class2.name + "\nBy " + class2.creator + "\nCRC32: " + class2.hash, "AP Patch File Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
            }
        }

        private void btnNFO_Click(object sender, EventArgs e)
        {
            if (this.nfoform != null)
            {
                this.nfoform.Dispose();
            }
            this.nfoform = new apPatcherNfoViewer();
            this.nfoform.hash = this.romHeader.romHeader.hash;
            Point location = new Point();
            location = Program.form.Location;
            this.nfoform.Show();
            this.nfoform.Location = location;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            this.action_exportRom();
        }

        private void buttonForumLink_Click(object sender, EventArgs e)
        {
            if (this.webInfo_id.Text != "")
            {
                try
                {
                    Process.Start("http://www.ds-scene.net/?s=viewtopic&nid=" + this.webInfo_id.Text);
                }
                catch
                {
                    MessageBox.Show("The url could not be opened, please try again", "URL open error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void buttonRomInfo_Click(object sender, EventArgs e)
        {
            crcDupes.possibleCrcType type = this.crcDb.crcToCleanCrc(this.romHeader.romHeader.hash.ToUpper());
            if ((type == null) || (type.hash == ""))
            {
                type = new crcDupes.possibleCrcType {
                    hash = this.romHeader.romHeader.hash.ToUpper(),
                    type = crcDupes.romTypes.unknown
                };
            }
            this.downloadInfoFromWebsite(type.type, type.hash, this.toolStripProgressBar, this.toolStripStatusLabel, true, true);
        }

        private void buttonSaveIcon_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Title = "Nintendo DS Icon",
                Filter = "(Nintendo DS Icon *.png)|*.png",
                RestoreDirectory = true,
                FileName = "icon.png"
            };
            int num = 0;
            while (true)
            {
                if (num < (this.txtFileLoc.Text.Length - 1))
                {
                    string str = this.txtFileLoc.Text.Substring((this.txtFileLoc.Text.Length - num) - 1, 1);
                    if (str != @"\")
                    {
                        num++;
                        continue;
                    }
                    dialog.FileName = this.txtFileLoc.Text.Substring(this.txtFileLoc.Text.Length - num, this.txtFileLoc.Text.Length - (this.txtFileLoc.Text.Length - num));
                    if ((dialog.FileName.Substring(dialog.FileName.Length - 4, 4) == ".nds") || (dialog.FileName.Substring(dialog.FileName.Length - 4, 4) == ".3ds"))
                    {
                        dialog.FileName = dialog.FileName.Substring(0, dialog.FileName.Length - 4) + ".png";
                        for (int i = 0; i < 0x10; i++)
                        {
                            if (this.getPalCheckBox(i).Checked)
                            {
                                dialog.FileName = dialog.FileName.Substring(0, dialog.FileName.Length - 4) + "_trans.png";
                                break;
                            }
                        }
                    }
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = this.fixFileNameNoExt(dialog.FileName, "*.png");
                    this.romIcon.Image.Save(filename, ImageFormat.Png);
                }
                return;
            }
        }

        public void changeAllFonts(string font)
        {
            Font font2 = new Font(font, 8f);
            this.name_jpnText.Font = font2;
            this.name_engText.Font = font2;
            this.name_freText.Font = font2;
            this.name_gerText.Font = font2;
            this.name_itaText.Font = font2;
            this.name_spaText.Font = font2;
            this.gameTitleText.Font = font2;
            this.gameCodeText.Font = font2;
            this.cardSizeText.Font = font2;
            this.fileSizeText.Font = font2;
            this.crc32Text.Font = font2;
            this.makerCodeText.Font = font2;
            this.makerNameText.Font = font2;
        }

        private string changeFileExt(string fn, string newExt)
        {
            int num = 0;
            num = 0;
            while ((num < (fn.Length - 1)) && (fn.Substring((fn.Length - num) - 1, 1) != "."))
            {
                num++;
            }
            if (num < fn.Length)
            {
                fn = fn.Substring(0, fn.Length - num) + newExt;
            }
            return fn;
        }

        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "DS-Scene Rom Tool";
            if (!this.databasesOk)
            {
                MessageBox.Show("You are currently running " + str + " v1.0 build 1215\r\n\r\nThe databases are not installed correctly.\r\nPlease update them before you can view more information.", "Version Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.changelogForm.formSetup("app");
                this.changelogForm.ShowDialog(this);
            }
        }

        private void checkAppUpdate(bool download)
        {
            this.disableMainForm();
            string newVersion = "";
            string str2 = "latest_version_build_1200.bin";
            string url = "http://files-ds-scene.net/romtool/releases/" + str2;
            if (!this.downloadFile(url, "data/temp/", "Update Check", "", null, null))
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.enableMainForm();
                return;
            }
            else
            {
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
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
            }
            if ("1.0 build 1215" == newVersion)
            {
                if (!this.firstboot && download)
                {
                    MessageBox.Show("The latest version (" + newVersion + ") is already installed.", "Application is up to date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.enableMainForm();
            }
            else
            {
                this.updateViewer.formSetup("app", newVersion);
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
                            string str6 = "DS-Scene Rom Tool";
                            try
                            {
                                string[] strArray = new string[] { "http://files-ds-scene.net/romtool/download.php?f=releases/", str6, " v", newVersion, ".rar" };
                                url = string.Concat(strArray);
                                if (!this.downloadFile(url, "data/temp/", str6 + " v" + newVersion + ".rar", str6 + " v" + newVersion + ".rar", null, null))
                                {
                                    this.toolStripStatusLabel.Text = "Update Failed";
                                    this.enableMainForm();
                                    MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    break;
                                }
                            }
                            catch (Exception exception6)
                            {
                                MessageBox.Show(exception6.Message);
                            }
                            try
                            {
                                this.compressor.outFile = "data/temp/";
                                string[] strArray2 = new string[] { "data/temp/", str6, " v", newVersion, ".rar" };
                                if (this.compressor.extractRar(string.Concat(strArray2), this.toolStripProgressBar, this.toolStripStatusLabel, false))
                                {
                                    goto TR_000C;
                                }
                                else
                                {
                                    this.toolStripStatusLabel.Text = "Update Failed";
                                    this.enableMainForm();
                                    MessageBox.Show("Update extraction failed, please check you have the unrar.dll installed", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                            }
                            catch (Exception exception3)
                            {
                                MessageBox.Show("extract error " + exception3.Message);
                                goto TR_000C;
                            }
                            break;
                        }
                        case DialogResult.No:
                            this.enableMainForm();
                            break;

                        default:
                            MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                            this.enableMainForm();
                            return;
                    }
                    return;
                }
            }
            return;
        TR_000C:
            try
            {
                System.IO.File.Delete("data/" + str2);
                System.IO.File.Move("data/temp/" + str2, "data/" + str2);
                System.IO.File.Delete("data/temp/" + str2);
            }
            catch (Exception exception4)
            {
                MessageBox.Show(str2 + " move error" + exception4.Message);
            }
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo {
                    FileName = "updater_v0.2.exe",
                    UseShellExecute = true
                };
                Process.Start(startInfo);
                Environment.Exit(0);
            }
            catch (Exception exception5)
            {
                MessageBox.Show("could not start updater" + exception5.Message);
            }
        }

        private void checkBoxTrans_CheckedChanged(object sender, EventArgs e)
        {
            this.buttonSaveIcon.Focus();
            this.romHeader.CreateIcon();
            this.romIcon.Image = this.romHeader.romHeader.icon.gfx;
            this.romIcon2.Image = this.romHeader.romHeader.icon.gfx;
            if (this.romHeader.romHeader.website_knows_it)
            {
                this.romIcon3.Image = this.romHeader.romHeader.icon.gfx;
            }
        }

        private void checkBoxTrim_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxTrim.Checked)
            {
                this.radioSafeTrim.Enabled = true;
                this.radioAccurateTrim.Enabled = true;
                this.radioSafeTrim.Checked = true;
                this.radioAccurateTrim.Checked = false;
            }
            else
            {
                this.radioSafeTrim.Enabled = false;
                this.radioAccurateTrim.Enabled = false;
                this.radioSafeTrim.Checked = false;
                this.radioAccurateTrim.Checked = false;
            }
        }

        private void checkCMPDatabaseUpdate(bool download, cmpDownloadType type = 0)
        {
            this.disableMainForm();
            string url = "http://files-ds-scene.net/romtool/releases/cmp/version_cmp.bin";
            if (!this.downloadFile(url, "data/temp/", "Update Check", "", null, null))
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.checkCMPVersionTxt(download, type) && download)
            {
                this.action_loadDatabase();
            }
            this.enableMainForm();
        }

        private bool checkCMPVersionTxt(bool download, cmpDownloadType type)
        {
            int index = 0;
            int num2 = 0;
            string url = "";
            this.toolStripStatusLabel.Text = "Checking CMP Version";
            Application.DoEvents();
            updateCSVInfo[] infoArray = new updateCSVInfo[20];
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F006F003F003F001000000069003F00");
                FileStream fs = new FileStream("data/temp/version_cmp.bin", FileMode.Open, FileAccess.Read);
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
                MessageBox.Show("checkCMPVersionTxt failed to load new info:\r\n " + exception.Message);
                this.toolStripStatusLabel.Text = "CMP Update Failed";
                return false;
            }
            Application.DoEvents();
            updateCSVInfo[] infoArray2 = new updateCSVInfo[20];
            if (System.IO.File.Exists("data/databases/version_cmp.bin"))
            {
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F006F003F003F001000000069003F00");
                    FileStream fs = new FileStream("data/databases/version_cmp.bin", FileMode.Open, FileAccess.Read);
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
                    if (exception2.Message.Substring(0, 14) != "Could not find")
                    {
                        MessageBox.Show(string.Concat(new object[] { "checkCMPVersionTxt failed to load cur info [", num2, "/", (int) 20, "]:\r\n ", exception2.Message }));
                        this.toolStripStatusLabel.Text = "Update Failed";
                        return false;
                    }
                }
            }
            else
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
            Application.DoEvents();
            if (index > num2)
            {
                MessageBox.Show("The application seems to be out of date.\r\nThe latest CMP Database version file is incompatible with this version\r\n\r\nPlease update the application first");
                this.toolStripStatusLabel.Text = "Update Failed";
                return false;
            }
            string text = "";
            bool flag = false;
            bool flag2 = false;
            cmpDownloadType none = cmpDownloadType.none;
            int num4 = 0;
            while (true)
            {
                if (num4 < 20)
                {
                    this.cmpCheckFile[num4].update_available = false;
                    if (num4 < index)
                    {
                        if (infoArray2[num4].ver != infoArray[num4].ver)
                        {
                            this.cmpCheckFile[num4].update_available = true;
                        }
                        num4++;
                        continue;
                    }
                }
                int num5 = 0;
                while (true)
                {
                    if ((num5 < 20) && (num5 < index))
                    {
                        if (infoArray2[num5].ver == infoArray[num5].ver)
                        {
                            string[] strArray5 = new string[] { text, infoArray[num5].fn, " [", infoArray[num5].ver, " Already Installed]\r\n" };
                            text = string.Concat(strArray5);
                        }
                        else
                        {
                            if (!flag2 && (download || ((num5 + 1) == type)))
                            {
                                this.updateViewer.formSetup("cmp", infoArray[num5].ver);
                                DialogResult result = this.updateViewer.ShowDialog(this);
                                if (result == DialogResult.Cancel)
                                {
                                    return false;
                                }
                                switch (result)
                                {
                                    case DialogResult.Yes:
                                        none = this.updateViewer.cmptype;
                                        if (none == cmpDownloadType.none)
                                        {
                                            return false;
                                        }
                                        flag2 = true;
                                        break;

                                    case DialogResult.No:
                                        return false;

                                    default:
                                        MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                        return false;
                                }
                            }
                            if ((num5 + 1) != none)
                            {
                                string[] strArray4 = new string[] { text, infoArray[num5].fn, " [Available for update ", infoArray[num5].ver, "]\r\n" };
                                text = string.Concat(strArray4);
                            }
                            else
                            {
                                url = "http://files-ds-scene.net/romtool/download.php?f=releases/cmp/" + infoArray[num5].fn;
                                if (!this.downloadFile(url, "data/databases/", infoArray[num5].fn, "", null, null))
                                {
                                    this.toolStripStatusLabel.Text = "CMP Update Failed";
                                    return false;
                                }
                                string[] strArray3 = new string[] { text, infoArray[num5].fn, " [Updated to ", infoArray[num5].ver, "]\r\n" };
                                text = string.Concat(strArray3);
                                infoArray2[num5].fn = infoArray[num5].fn;
                                infoArray2[num5].ver = infoArray[num5].ver;
                                flag = true;
                            }
                        }
                        num5++;
                        continue;
                    }
                    if (!flag)
                    {
                        goto TR_0008;
                    }
                    else
                    {
                        try
                        {
                            bool flag3 = true;
                            string str7 = "";
                            string ver = "";
                            int num6 = 0;
                            int num7 = 0;
                            while (true)
                            {
                                if ((num7 >= 20) || (num7 >= index))
                                {
                                    if (num6 == index)
                                    {
                                        flag3 = false;
                                    }
                                    if (flag3 && !this.downloadCMPGameList())
                                    {
                                        MessageBox.Show("Failed to download the CMP Database game list you will,\nbe unable to view the list of supported games.\n\nPlease check your internet connection or the site may be down", "CMP Game List Download Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    }
                                    using (StreamWriter writer = new StreamWriter("data/temp/version_cmp.txt"))
                                    {
                                        writer.Write(str7);
                                    }
                                    break;
                                }
                                if ((infoArray2[num7].ver != "0") && (infoArray2[num7].ver != ""))
                                {
                                    if ((ver != "") && (ver == infoArray2[num7].ver))
                                    {
                                        num6++;
                                    }
                                    else
                                    {
                                        flag3 = true;
                                    }
                                    ver = infoArray2[num7].ver;
                                }
                                string[] strArray6 = new string[] { str7, infoArray2[num7].fn, "|", infoArray2[num7].ver, "\r\n" };
                                str7 = string.Concat(strArray6);
                                num7++;
                            }
                        }
                        catch (Exception exception6)
                        {
                            MessageBox.Show(exception6.Message + " \nFailed to create the CMP Database version file, the application may report updates that are not available", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    break;
                }
                break;
            }
            try
            {
                if (System.IO.File.Exists("data/temp/version_cmp.txt"))
                {
                    System.IO.File.Delete("data/databases/version_cmp.bin");
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F006F003F003F001000000069003F00");
                    this.encryptor.EncryptFile("data/temp/version_cmp.txt", "data/databases/version_cmp.bin", sKey, GCHandle.Alloc(sKey, GCHandleType.Pinned));
                    System.IO.File.Delete("data/temp/version_cmp.txt");
                    this.loadCMPVersionTxt();
                }
            }
            catch (Exception exception7)
            {
                MessageBox.Show(exception7.Message + " \nFailed to move the CMP Database version file, the application may report updates that are not available", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        TR_0008:
            if (download || flag)
            {
                this.toolStripStatusLabel.Text = "CMP Update Complete";
                MessageBox.Show(text, "CMP Database Update Results", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return true;
        }

        public bool checkCrc32(string file, ProgressBar progress, Label status)
        {
            bool flag = true;
            try
            {
                this.crchash = string.Empty;
                System.IO.File.SetAttributes(file, FileAttributes.Normal);
                using (FileStream stream = System.IO.File.Open(file, FileMode.Open))
                {
                    progress.Maximum = 4;
                    progress.Value = 1;
                    status.Text = "CRC32 Check " + this.origFileLocToNewFileName(file, false, false, "");
                    Application.DoEvents();
                    progress.Value = 0;
                    byte[] buffer = this.crc32.ComputeHash(stream);
                    int index = 0;
                    while (true)
                    {
                        if (index >= buffer.Length)
                        {
                            stream.Close();
                            break;
                        }
                        byte num = buffer[index];
                        this.crchash = this.crchash + num.ToString("x2").ToUpper();
                        progress.Value++;
                        object[] objArray = new object[] { "CRC32 Check ", this.origFileLocToNewFileName(file, false, false, ""), " ", this.run.hexAndMathFunction.getPercentage(progress.Value, progress.Maximum), "%" };
                        status.Text = string.Concat(objArray);
                        Application.DoEvents();
                        index++;
                    }
                }
            }
            catch (Exception)
            {
                flag = false;
            }
            progress.Value = 4;
            status.Text = "CRC32 Check " + this.origFileLocToNewFileName(file, false, false, "") + " 100%";
            Application.DoEvents();
            return flag;
        }

        private void checkDatabaseUpdate(bool download)
        {
            this.disableMainForm();
            string url = "http://files-ds-scene.net/romtool/releases/databases/version.bin";
            if (!this.downloadFile(url, "data/temp/", "Update Check", "", null, null))
            {
                MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.checkVersionTxt(download) && download)
            {
                this.action_loadDatabase();
            }
            this.enableMainForm();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.checkDatabaseUpdate(true);
        }

        private void checkForUpdatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.checkCMPDatabaseUpdate(true, cmpDownloadType.none);
        }

        private void checkForUpdateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.checkAppUpdate(true);
        }

        private bool checkVersionTxt(bool download)
        {
            int index = 0;
            int num2 = 0;
            string url = "";
            this.toolStripStatusLabel.Text = "Checking AP Version";
            Application.DoEvents();
            updateCSVInfo[] infoArray = new updateCSVInfo[20];
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
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
                this.toolStripStatusLabel.Text = "AP Update Failed";
                return false;
            }
            Application.DoEvents();
            updateCSVInfo[] infoArray2 = new updateCSVInfo[20];
            if (!System.IO.File.Exists("data/databases/version.bin") || (!System.IO.File.Exists("data/databases/offsets.dsapdb") || !this.databasesOk))
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
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
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
                    if (exception2.Message.Substring(0, 14) != "Could not find")
                    {
                        MessageBox.Show(string.Concat(new object[] { "checkVersionTxt failed to load cur info [", num2, "/", (int) 20, "]:\r\n ", exception2.Message }));
                        this.toolStripStatusLabel.Text = "AP Update Failed";
                        return false;
                    }
                }
            }
            Application.DoEvents();
            if (index > num2)
            {
                MessageBox.Show("The application seems to be out of date.\r\nThe latest AP Database version file is incompatible with this version\r\n\r\nPlease update the application first");
                this.toolStripStatusLabel.Text = "AP Update Failed";
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
                        this.updateViewer.formSetup("db", infoArray[i].ver);
                        DialogResult result = this.updateViewer.ShowDialog(this);
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
                    url = "http://files-ds-scene.net/romtool/download.php?f=releases/databases/" + infoArray[i].fn;
                    if (!this.downloadFile(url, "data/databases/", infoArray[i].fn, "", null, null))
                    {
                        this.toolStripStatusLabel.Text = "AP Update Failed";
                        return false;
                    }
                    string[] strArray3 = new string[] { text, infoArray[i].fn, " [Updated to ", infoArray[i].ver, "]\r\n" };
                    text = string.Concat(strArray3);
                    flag = true;
                }
            }
            if (flag)
            {
                try
                {
                    System.IO.File.Delete("data/databases/version.bin");
                    System.IO.File.Move("data/temp/version.bin", "data/databases/version.bin");
                }
                catch
                {
                    MessageBox.Show("Failed to move update the AP Database version, the application may report updates that are not available", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (download || flag)
            {
                this.toolStripStatusLabel.Text = "AP Update Complete";
                MessageBox.Show(text, "AP Database Update Results", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return true;
        }

        public void cleanFolder(string folder)
        {
            int num = 0x3e8;
            while (true)
            {
                while (true)
                {
                    if (num > 0)
                    {
                        try
                        {
                            DirectoryInfo info = new DirectoryInfo(folder);
                            DirectoryInfo[] directories = info.GetDirectories();
                            int index = 0;
                            while (true)
                            {
                                if (index >= directories.Length)
                                {
                                    foreach (FileInfo info3 in info.GetFiles())
                                    {
                                        System.IO.File.SetAttributes(info3.FullName, FileAttributes.Normal);
                                        info3.Delete();
                                    }
                                    break;
                                }
                                DirectoryInfo info2 = directories[index];
                                Directory.Delete(info2.FullName, true);
                                index++;
                            }
                        }
                        catch (Exception exception)
                        {
                            if (num == 1)
                            {
                                MessageBox.Show(exception.Message);
                            }
                            break;
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                    break;
                }
                num--;
            }
        }

        public void cleanTempFiles()
        {
            this.cleanFolder("data/temp/");
        }

        private void clearRomWebInfo()
        {
            this.displayWebRomType(crcDupes.romTypes.unknown);
            this.romHeader.romHeader.website_knows_it = false;
            this.webInfo_number.Text = "";
            this.webInfo_name.Text = "";
            this.webInfo_grp.Text = "";
            this.webInfo_save.Text = "";
            this.webInfo_arc.Text = "";
            this.webInfo_dir.Text = "";
            this.webInfo_newsdate.Text = "unknown";
            this.webInfo_date.Text = "never";
            this.webInfo_id.Text = "";
            this.romIcon3.Image = Resources._0000;
            this.webInfo_Boxart.Image = Resources._00001;
            this.webInfo_wifi.Visible = false;
            this.webInfo_dscompat.Visible = false;
            this.buttonForumLink.Enabled = false;
            this.webInfo_rgn.Image = null;
            this.hideAll3DSoptions();
            this.btnNFO.Enabled = false;
        }

        private void cmpCheatsFound(bool found)
        {
            if (found)
            {
                this.cmpDbSupportBtn.Image = Resources.Checkicon;
            }
            else
            {
                this.cmpDbSupportBtn.Image = Resources.crossicon;
            }
        }

        private void cmpDbSupportBtn_Click(object sender, EventArgs e)
        {
            this.databaseToolStripMenuItem.Select();
            this.databaseToolStripMenuItem.ShowDropDown();
            this.cMPDatabaseToolStripMenuItem1.Select();
            this.cMPDatabaseToolStripMenuItem1.ShowDropDown();
            this.installToMediaToolStripMenuItem.Select();
            this.installToMediaToolStripMenuItem.ShowDropDown();
        }

        private unsafe void collectionBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.collectionForm == null)
            {
                Program.form.collectionForm = new collectionViewer();
                this.collectionBrowserToolStripMenuItem.Enabled = false;
                this.collectionForm.StartPosition = FormStartPosition.Manual;
                Point location = new Point();
                location = Program.form.Location;
                Point* pointPtr1 = &location;
                pointPtr1.X -= 0x196;
                this.collectionForm.Location = location;
                this.collectionForm.Show(this);
            }
        }

        public string compressedRomCRC(string path_src, string arcType, ProgressBar progress, Label status, string ext)
        {
            int num = 0;
            if (arcType == "rar")
            {
                if (System.IO.File.Exists(path_src.Substring(0, path_src.Length - 3) + "r01"))
                {
                    num = 2;
                }
                if (System.IO.File.Exists(path_src.Substring(0, path_src.Length - 3) + "r001"))
                {
                    num = 3;
                }
                if (num > 0)
                {
                    string path = path_src;
                    int num2 = 0;
                    while (System.IO.File.Exists(path))
                    {
                        path_src = path;
                        num2++;
                        string str2 = num2.ToString();
                        if (((num == 2) || (num == 3)) && (num2 < 10))
                        {
                            str2 = "0" + str2;
                        }
                        if ((num == 3) && (num2 < 100))
                        {
                            str2 = "0" + str2;
                        }
                        path = path.Substring(0, path.LastIndexOf(".")) + ".r" + str2;
                    }
                }
            }
            this.compressor.crc_of_extracting_file = "";
            this.compressor.findFirstExtInArchive(ext, path_src, arcType, progress, status);
            return this.compressor.crc_of_extracting_file;
        }

        private void compressionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.compressionSelect.SelectedIndex == 0)
            {
                this.checkBoxDelete.Enabled = false;
                this.checkBoxDelete.Checked = false;
            }
            else
            {
                this.checkBoxDelete.Enabled = true;
                this.checkBoxDelete.Checked = true;
            }
            this.buttonApply.Focus();
        }

        public void copyBytes(BinaryReader br, BinaryWriter writer, long bytes, int chunk, long pos, long endPos, ProgressBar progress, Label status, string romOut)
        {
            long num = bytes / ((long) chunk);
            while ((num * chunk) > bytes)
            {
                num -= 1L;
            }
            for (int i = 0; i < num; i++)
            {
                pos += chunk;
                byte[] buffer = br.ReadBytes(chunk);
                long num3 = this.run.hexAndMathFunction.bytesToMbit(pos);
                if (num3 != progress.Value)
                {
                    progress.Value = (int) (pos / endPos);
                    object[] objArray = new object[] { "Saving ", this.origFileLocToNewFileName(romOut, false, false, ""), " ", this.run.hexAndMathFunction.getPercentage(progress.Value, progress.Maximum), "%" };
                    status.Text = string.Concat(objArray);
                    Application.DoEvents();
                }
                writer.Write(buffer);
                buffer = null;
            }
            if ((num * chunk) < bytes)
            {
                pos += bytes - (num * chunk);
                byte[] buffer = br.ReadBytes((int) (bytes - (num * chunk)));
                if (this.run.hexAndMathFunction.bytesToMbit(pos) != progress.Value)
                {
                    progress.Value = (int) (pos / endPos);
                    object[] objArray2 = new object[] { "Saving ", this.origFileLocToNewFileName(romOut, false, false, ""), " ", this.run.hexAndMathFunction.getPercentage(progress.Value, progress.Maximum), "%" };
                    status.Text = string.Concat(objArray2);
                    Application.DoEvents();
                }
                writer.Write(buffer);
                buffer = null;
            }
        }

        public void createAppFolders()
        {
            if (!this.createLinuxFolders() && !this.createWindowsFolders())
            {
                MessageBox.Show("There was a problem creating the folder structure\nThe application may fail to function correctly in this environment", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool createLinuxFolders()
        {
            bool flag;
            try
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data");
                    Program.form.firstInstall = true;
                    this.databasesOk = false;
                    MessageBox.Show("This is your first time running the application\r\nYou will need to update the database\r\nbefore you can do anything.\r\n\r\nChoose database from the top menu to update.", "First time use", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/databases"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/databases");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/collections"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/collections");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/temp"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/temp");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/header_cache"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/header_cache");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/web"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/web");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/web/info"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/web/info");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/web/images"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/web/images");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "/data/web/nfo"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data/web/nfo");
                }
                flag = true;
            }
            catch
            {
                return false;
            }
            return flag;
        }

        private bool createWindowsFolders()
        {
            bool flag;
            try
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data");
                    this.firstInstall = true;
                    this.databasesOk = false;
                    MessageBox.Show("This is your first time running the application\r\nYou will need to update the database\r\nbefore you can do anything.\r\n\r\nChoose database from the top menu to update.", "First time use", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\databases"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\databases");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\collections"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\collections");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\temp"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\temp");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\web"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\web");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\header_cache"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\header_cache");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\web\info"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\web\info");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\web\images"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\web\images");
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\web\nfo"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\web\nfo");
                }
                flag = true;
            }
            catch
            {
                return false;
            }
            return flag;
        }

        private void cycloDSCMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.installCMP(cmpDownloadType.CycloDS);
        }

        private void cycloDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        private void deleteOldUpdater()
        {
            if (System.IO.File.Exists("updater.exe"))
            {
                try
                {
                    System.IO.File.Delete("updater.exe");
                }
                catch
                {
                }
            }
        }

        private void disableCheckOnStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        public void disableMainForm()
        {
            this.menuStrip1.Enabled = false;
            this.openToolStripMenuItem.Enabled = false;
            this.btnBrowse.Enabled = false;
            this.batchProcessToolStripMenuItem.Enabled = false;
            this.disableTabs();
            if (this.collectionForm != null)
            {
                this.collectionForm.listCollectionDbs.Enabled = false;
                this.collectionForm.btnAddCollection.Enabled = false;
                this.collectionForm.listViewRoms.Enabled = false;
                this.collectionForm.groupBoxFilters.Enabled = false;
            }
        }

        public void disableTabs()
        {
            this.buttonSaveIcon.Enabled = false;
            this.buttonApply.Enabled = false;
            this.checkBoxTrim.Enabled = false;
            this.tabControlMain.Enabled = false;
        }

        private void disableWebAlertContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        private void disableWebContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        private void displayRomHeaderInfo()
        {
            try
            {
                if (this.romHeader.romHeader.is3DS)
                {
                    this.displayRomHeaderInfo_3DS();
                }
                else
                {
                    if (this.tabControlLang.TabPages.Count == 1)
                    {
                        this.tabLangJpn.Text = "Japanese";
                        this.tabControlLang.TabPages.Add(this.tabLangEng);
                        this.tabControlLang.TabPages.Add(this.tabLangFre);
                        this.tabControlLang.TabPages.Add(this.tabLangGer);
                        this.tabControlLang.TabPages.Add(this.tabLangIta);
                        this.tabControlLang.TabPages.Add(this.tabLangSpa);
                    }
                    this.txtHdrTitle.Text = "Game title";
                    this.drawIconPalette();
                    this.romHeader.CreateIcon();
                    this.romIcon.Image = this.romHeader.romHeader.icon.gfx;
                    this.romIcon2.Image = this.romHeader.romHeader.icon.gfx;
                    if (this.romHeader.romHeader.website_knows_it)
                    {
                        this.romIcon3.Image = this.romHeader.romHeader.icon.gfx;
                    }
                    this.name_jpnText.Text = this.run.hexAndMathFunction.hexToUTF32String(this.romHeader.romHeader.title[0]);
                    this.name_engText.Text = this.run.hexAndMathFunction.hexToUTF32String(this.romHeader.romHeader.title[1]);
                    this.name_freText.Text = this.run.hexAndMathFunction.hexToUTF32String(this.romHeader.romHeader.title[2]);
                    this.name_gerText.Text = this.run.hexAndMathFunction.hexToUTF32String(this.romHeader.romHeader.title[3]);
                    this.name_itaText.Text = this.run.hexAndMathFunction.hexToUTF32String(this.romHeader.romHeader.title[4]);
                    this.name_spaText.Text = this.run.hexAndMathFunction.hexToUTF32String(this.romHeader.romHeader.title[5]);
                    this.gameTitleText.Text = this.run.hexAndMathFunction.hexToString(this.romHeader.romHeader.gameTitle);
                    string gameCode = this.romHeader.romHeader.gameCode;
                    gameCode = this.romHeader.countryNameFromCode(gameCode.Substring(gameCode.Length - 1, 1));
                    if (this.romHeader.romHeader.isDsi)
                    {
                        this.gameCodeText.Text = "TWL-";
                        this.gameCodeText.Text = this.gameCodeText.Text + this.romHeader.romHeader.gameCode;
                        this.gameCodeText.Text = this.gameCodeText.Text + "-" + gameCode;
                    }
                    else
                    {
                        this.gameCodeText.Text = "NTR-";
                        this.gameCodeText.Text = this.gameCodeText.Text + this.romHeader.romHeader.gameCode;
                        this.gameCodeText.Text = this.gameCodeText.Text + "-" + gameCode;
                    }
                    int num = 20 + this.romHeader.romHeader.cardSize;
                    int num2 = 0;
                    int num3 = 0;
                    while (true)
                    {
                        if (num3 >= num)
                        {
                            object[] objArray = new object[] { 1 << (this.romHeader.romHeader.cardSize & 0x1f), "Mb (", this.run.hexAndMathFunction.mbitToBytes((long) (1 << (this.romHeader.romHeader.cardSize & 0x1f))), " bytes)" };
                            this.cardSizeText.Text = string.Concat(objArray);
                            object[] objArray2 = new object[] { this.run.hexAndMathFunction.bytesToMbit((long) this.romHeader.romHeader.fileSize), "Mb (", this.romHeader.romHeader.fileSize, " bytes)" };
                            this.fileSizeText.Text = string.Concat(objArray2);
                            this.crc32Text.Text = this.romHeader.romHeader.hash.ToUpper();
                            this.makerCodeText.Text = this.romHeader.romHeader.makerCode;
                            this.makerNameText.Text = this.romHeader.makerNameFromCode(this.makerCodeText.Text);
                            this.iconEditorGroup.Enabled = true;
                            this.buttonSaveIcon.Enabled = true;
                            this.enableTabs();
                            break;
                        }
                        num2 *= 2;
                        num3++;
                    }
                }
            }
            catch (Exception)
            {
                this.enableTabs();
                string[] strArray = new string[] { "data/header_cache/", this.romHeader.romHeader.hash.ToUpper().Substring(0, 1), "/", this.romHeader.romHeader.hash.ToUpper(), ".dsrhd" };
                string path = string.Concat(strArray);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                if (MessageBox.Show("The rom header or header cache appears to be corrupt, try reloading the rom.\n\nIf this message continues, your rom may be corrupt.\n\nWould you like to try reloading it now?", "Rom Header Corrupt", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    this.action_browse(this.txtFileLoc.Text, this.romHeader.romHeader.hash.ToUpper());
                }
            }
        }

        private void displayRomHeaderInfo_3DS()
        {
            if (this.tabControlLang.TabPages.Count > 1)
            {
                this.tabLangJpn.Text = "Plain Region Information";
                this.tabControlLang.TabPages.Remove(this.tabLangEng);
                this.tabControlLang.TabPages.Remove(this.tabLangFre);
                this.tabControlLang.TabPages.Remove(this.tabLangGer);
                this.tabControlLang.TabPages.Remove(this.tabLangIta);
                this.tabControlLang.TabPages.Remove(this.tabLangSpa);
            }
            this.txtHdrTitle.Text = "Partition Id";
            this.gameCodeText.Text = this.romHeader.romHeader.gameCode;
            this.crc32Text.Text = this.romHeader.romHeader.hash.ToUpper();
            this.makerCodeText.Text = this.romHeader.romHeader.makerCode;
            this.makerNameText.Text = this.romHeader.makerNameFromCode(this.makerCodeText.Text);
            this.gameTitleText.Text = this.run.hexAndMathFunction.reversehex(this.romHeader.romHeader.gameTitle, this.romHeader.romHeader.gameTitle.Length);
            object[] objArray = new object[] { this.run.hexAndMathFunction.bytesToGbit(this.romHeader.romHeader.fileSize_3ds), "Gb (", this.romHeader.romHeader.fileSize_3ds, " bytes)" };
            this.fileSizeText.Text = string.Concat(objArray);
            object[] objArray2 = new object[] { this.run.hexAndMathFunction.bytesToGbit(this.romHeader.romHeader.cardSize_3ds), "Gb (", this.romHeader.romHeader.cardSize_3ds, " bytes)" };
            this.cardSizeText.Text = string.Concat(objArray2);
            this.name_jpnText.Text = this.run.hexAndMathFunction.hexToString(this.romHeader.romHeader.title[0]);
            this.iconEditorGroup.Enabled = false;
            this.buttonSaveIcon.Enabled = false;
            this.enableTabs();
        }

        private void displayRomWebInfo(crcDupes.romTypes type, string hash)
        {
            webInfo.webInfoItemClass[] item;
            int num2;
            this.hideAll3DSoptions();
            this.romHeader.romHeader.website_knows_it = false;
            if (this.options.getValue("disable_web") == "1")
            {
                return;
            }
            webInfo.webInfoClass class2 = new webInfo.webInfoClass();
            class2 = this.web.parseWebInfo(hash);
            if (class2.item[0] == null)
            {
                goto TR_0008;
            }
            else
            {
                item = class2.item;
                num2 = 0;
            }
            goto TR_0042;
        TR_0008:
            if ((class2.item[0] != null) && ((class2.item[0].key != "error:hash not found") && (class2.item[0].key != "error:bad hash")))
            {
                this.displayWebRomType(type);
                this.romHeader.romHeader.website_knows_it = true;
                return;
            }
            this.clearRomWebInfo();
            if (this.options.getValue("disable_webalert") != "1")
            {
                if (class2.item[0] == null)
                {
                    MessageBox.Show("No additional information was found for this rom, try using the ds-scene.net tab to get the information", "No Information Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MessageBox.Show("No information was downloaded for this rom (" + class2.item[0].key + "), try refreshing on the ds-scene.net tab to update the information", "No Information Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return;
        TR_0009:
            num2++;
        TR_0042:
            while (true)
            {
                if (num2 < item.Length)
                {
                    webInfo.webInfoItemClass class3 = item[num2];
                    if (class3 != null)
                    {
                        string key = class3.key;
                        if (key != null)
                        {
                            int num3;
                            if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x600010e-1 == null)
                            {
                                Dictionary<string, int> dictionary1 = new Dictionary<string, int>(0x13);
                                dictionary1.Add("error:hash not found", 0);
                                dictionary1.Add("error:bad hash", 1);
                                dictionary1.Add("romnum", 2);
                                dictionary1.Add("romnam", 3);
                                dictionary1.Add("romgrp", 4);
                                dictionary1.Add("romsav", 5);
                                dictionary1.Add("romzip", 6);
                                dictionary1.Add("romdir", 7);
                                dictionary1.Add("id", 8);
                                dictionary1.Add("wifi", 9);
                                dictionary1.Add("boxart", 10);
                                dictionary1.Add("icon", 11);
                                dictionary1.Add("dscompat", 12);
                                dictionary1.Add("date", 13);
                                dictionary1.Add("newsdate", 14);
                                dictionary1.Add("romrgn", 15);
                                dictionary1.Add("romsize", 0x10);
                                dictionary1.Add("nfolink", 0x11);
                                dictionary1.Add("n3dsopt", 0x12);
                                <PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x600010e-1 = dictionary1;
                            }
                            if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x600010e-1.TryGetValue(key, out num3))
                            {
                                switch (num3)
                                {
                                    case 0:
                                    case 1:
                                    case 0x10:
                                        goto TR_0009;

                                    case 2:
                                        this.romIcon3.Image = this.romIcon.Image;
                                        this.webInfo_number.Text = class3.val;
                                        if (!class3.val.ToUpper().StartsWith("3DS"))
                                        {
                                            this.pic3DSCard.Visible = false;
                                            this.picDSCard.Visible = true;
                                        }
                                        else
                                        {
                                            this.romIcon.Image = Resources._0000;
                                            this.romIcon2.Image = Resources._0000;
                                            this.pic3DSCard.Visible = true;
                                            this.picDSCard.Visible = false;
                                        }
                                        goto TR_0009;

                                    case 3:
                                        this.webInfo_name.Text = class3.val;
                                        goto TR_0009;

                                    case 4:
                                        this.webInfo_grp.Text = class3.val;
                                        goto TR_0009;

                                    case 5:
                                        this.webInfo_save.Text = class3.val;
                                        goto TR_0009;

                                    case 6:
                                        this.webInfo_arc.Text = class3.val;
                                        goto TR_0009;

                                    case 7:
                                        this.webInfo_dir.Text = class3.val;
                                        goto TR_0009;

                                    case 8:
                                        this.webInfo_id.Text = class3.val;
                                        this.buttonForumLink.Enabled = true;
                                        goto TR_0009;

                                    case 9:
                                        this.webInfo_wifi.Visible = class3.val == "YES";
                                        this.picNinNetwork.Visible = class3.val == "NNT";
                                        goto TR_0009;

                                    case 10:
                                        if (System.IO.File.Exists("data/web/images/" + hash + ".jpg"))
                                        {
                                            using (FileStream stream = new FileStream("data/web/images/" + hash + ".jpg", FileMode.Open))
                                            {
                                                this.webBoxart = new Bitmap(stream);
                                                stream.Close();
                                            }
                                            this.webInfo_Boxart.Image = this.webBoxart;
                                        }
                                        goto TR_0009;

                                    case 11:
                                        if (System.IO.File.Exists("data/web/images/" + hash + ".png"))
                                        {
                                            using (FileStream stream2 = new FileStream("data/web/images/" + hash + ".png", FileMode.Open))
                                            {
                                                this.romHeader.romHeader.icon.gfx = new Bitmap(stream2);
                                                stream2.Close();
                                            }
                                            this.romIcon3.Image = this.romHeader.romHeader.icon.gfx;
                                        }
                                        goto TR_0009;

                                    case 12:
                                        this.webInfo_dscompat.Visible = class3.val == "YES";
                                        goto TR_0009;

                                    case 13:
                                        this.webInfo_date.Text = (class3.val == "") ? "never" : this.run.hexAndMathFunction.dateStringFormatFromUTC(class3.val);
                                        goto TR_0009;

                                    case 14:
                                        this.webInfo_newsdate.Text = (class3.val == "") ? "unknown" : this.run.hexAndMathFunction.dateStringFormatFromUTC(class3.val);
                                        goto TR_0009;

                                    case 15:
                                        if (System.IO.File.Exists("data/web/images/flag_" + class3.val + ".gif"))
                                        {
                                            using (FileStream stream3 = new FileStream("data/web/images/flag_" + class3.val + ".gif", FileMode.Open))
                                            {
                                                this.webRegionFlag = new Bitmap(stream3);
                                                stream3.Close();
                                            }
                                            this.webInfo_rgn.Image = this.webRegionFlag;
                                        }
                                        goto TR_0009;

                                    case 0x11:
                                        if (class3.val != "")
                                        {
                                            this.btnNFO.Enabled = true;
                                        }
                                        goto TR_0009;

                                    case 0x12:
                                    {
                                        int num = 0;
                                        foreach (string str in class3.val.Split(new char[] { ',' }))
                                        {
                                            if (str != "")
                                            {
                                                this.show3DSopt(str, num);
                                                num++;
                                            }
                                        }
                                        goto TR_0009;
                                    }
                                    default:
                                        break;
                                }
                            }
                        }
                        MessageBox.Show("unsupported webInfo value '" + class3.key + "'");
                    }
                }
                else
                {
                    goto TR_0008;
                }
                break;
            }
            goto TR_0009;
        }

        private void displayWebRomType(crcDupes.romTypes type)
        {
            switch (type)
            {
                case crcDupes.romTypes.clean:
                    this.romTypeTxt.BackColor = Color.LightGreen;
                    this.romTypeTxt.ForeColor = Color.DarkGreen;
                    this.romTypeTxt.Text = "Validated Rom";
                    return;

                case crcDupes.romTypes.apPatched:
                    this.romTypeTxt.BackColor = Color.NavajoWhite;
                    this.romTypeTxt.ForeColor = Color.Chocolate;
                    this.romTypeTxt.Text = "AP Patched";
                    return;

                case crcDupes.romTypes.trimmed:
                    this.romTypeTxt.BackColor = Color.NavajoWhite;
                    this.romTypeTxt.ForeColor = Color.Chocolate;
                    this.romTypeTxt.Text = "Trimmed";
                    return;

                case crcDupes.romTypes.apAndTrim:
                    this.romTypeTxt.BackColor = Color.NavajoWhite;
                    this.romTypeTxt.ForeColor = Color.Chocolate;
                    this.romTypeTxt.Text = "Trimmed + AP Patched";
                    return;

                case crcDupes.romTypes.unknown:
                    this.romTypeTxt.BackColor = Color.LightGray;
                    this.romTypeTxt.ForeColor = Color.DimGray;
                    this.romTypeTxt.Text = "Not Recognised";
                    return;
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

        public long doExportRomAction(string romIn, string romOut, romTrimTypes trim, bool apPatch, string compress, bool delete, ProgressBar progress, Label status, bool isBatch, bool isOrganise)
        {
            long num = 1L;
            long endPos = this.getRomTrimPosition(romIn, progress, status, trim);
            if (isBatch && !isOrganise)
            {
                this.batchForm.increaseTotalProgress();
            }
            if (isBatch && isOrganise)
            {
                this.organiseForm.increaseTotalProgress();
            }
            if (endPos == -1L)
            {
                num = -1L;
            }
            else
            {
                num = this.saveRom(romIn, romOut, apPatch, progress, status, endPos);
                for (int i = 0; i < 0xc350; i++)
                {
                    Application.DoEvents();
                }
            }
            if (isBatch && !isOrganise)
            {
                this.batchForm.increaseTotalProgress();
            }
            if (isBatch && isOrganise)
            {
                this.organiseForm.increaseTotalProgress();
            }
            if (this.compressor.stringToSevenZipFormat(compress) != KnownSevenZipFormat.Arj)
            {
                romIn = romOut;
                romOut = romOut.Substring(0, romOut.Length - 3) + compress;
                if (!this.compressor.PackSingle(romOut, romIn, compress, progress, status, delete))
                {
                    num = -9;
                }
                for (int i = 0; i < 0xc350; i++)
                {
                    Application.DoEvents();
                }
            }
            status.Text = "Rom Export Complete";
            if (isBatch && !isOrganise)
            {
                this.batchForm.increaseTotalProgress();
            }
            if (isBatch && isOrganise)
            {
                this.organiseForm.increaseTotalProgress();
            }
            return num;
        }

        private bool doRomFileActions(string crctodo = "")
        {
            string arcType = "";
            bool flag = false;
            this.patchInfo = null;
            this.disableTabs();
            this.txtFileLoc.Text = "";
            this.cleanTempFiles();
            this.apPatchSupported(false, crcDupes.romTypes.unknown, null);
            this.tabExport.Enabled = false;
            this.btnHeaderRefresh.Enabled = false;
            this.initRomInfoFields();
            this.cmpCheatsFound(false);
            if (!System.IO.File.Exists(this.fdlg.FileName))
            {
                MessageBox.Show("Sorry, the file you have selected could not be found\n\n" + this.fdlg.FileName, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            arcType = this.getFileExtension(this.fdlg.FileName).ToLower();
            string str3 = arcType;
            if (str3 != null)
            {
                if (str3 == "zip")
                {
                    flag = true;
                    goto TR_0023;
                }
                else if (str3 == "rar")
                {
                    flag = true;
                    goto TR_0023;
                }
                else if (str3 == "7z")
                {
                    flag = true;
                    goto TR_0023;
                }
                else if (str3 == "nds")
                {
                    flag = false;
                    goto TR_0023;
                }
                else if (str3 == "3ds")
                {
                    flag = false;
                    goto TR_0023;
                }
            }
            arcType = "";
        TR_0023:
            if (arcType == "")
            {
                MessageBox.Show("Sorry, the file you have selected is incompatible with this application", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.cmpCheatsFound(false);
                return false;
            }
            bool flag2 = false;
            if (flag)
            {
                crctodo = Program.form.compressedRomCRC(this.fdlg.FileName, this.fdlg.FileName.Substring(this.fdlg.FileName.LastIndexOf(".") + 1, this.fdlg.FileName.Length - (this.fdlg.FileName.LastIndexOf(".") + 1)), this.toolStripProgressBar, this.toolStripStatusLabel, "nds");
                if (crctodo == "")
                {
                    crctodo = Program.form.compressedRomCRC(this.fdlg.FileName, this.fdlg.FileName.Substring(this.fdlg.FileName.LastIndexOf(".") + 1, this.fdlg.FileName.Length - (this.fdlg.FileName.LastIndexOf(".") + 1)), this.toolStripProgressBar, this.toolStripStatusLabel, "3ds");
                }
                if ((crctodo != "") && this.romHeader.loadHeaderCacheFile(crctodo))
                {
                    flag2 = true;
                }
            }
            if (flag && !flag2)
            {
                string str2 = "/data/temp/";
                if (Path.GetDirectoryName(Application.ExecutablePath).Replace('\\', '+') != Path.GetDirectoryName(Application.ExecutablePath))
                {
                    str2 = str2.Replace('/', '\\');
                }
                if (!this.extractRom(this.fdlg.FileName, Path.GetDirectoryName(Application.ExecutablePath) + str2, arcType, this.toolStripProgressBar, this.toolStripStatusLabel))
                {
                    MessageBox.Show("There was a problem extracting the selected archive.\nIs it a valid archive and does it contain a .nds or .3ds file?", "File Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.apPatchSupported(false, crcDupes.romTypes.unknown, null);
                    this.tabExport.Enabled = false;
                    this.initRomInfoFields();
                    this.disableTabs();
                    this.cmpCheatsFound(false);
                    return false;
                }
                this.txtFileLoc.Text = this.compressor.outFile + this.compressor.extracting_file;
                this.fdlg.FileName = this.txtFileLoc.Text;
            }
            Application.DoEvents();
            this.romHeader.romHeader.hash = "";
            if (crctodo != "")
            {
                this.crchash = crctodo;
            }
            else if (!this.checkCrc32(this.fdlg.FileName, this.toolStripProgressBar, this.toolStripStatusLabel))
            {
                MessageBox.Show("Failed to get CRC32 of the file, check if the file is open already or is read only", "CRC32 Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.apPatchSupported(false, crcDupes.romTypes.unknown, null);
                this.tabExport.Enabled = false;
                this.initRomInfoFields();
                this.disableTabs();
                this.cmpCheatsFound(false);
                return false;
            }
            this.romHeader.romHeader.hash = this.crchash;
            this.toolStripProgressBar.Maximum = 1;
            this.toolStripProgressBar.Value = 0;
            this.toolStripStatusLabel.Text = "Header Parse";
            Application.DoEvents();
            this.romHeader.loadRomHeader(this.fdlg.FileName, false);
            this.toolStripProgressBar.Value = 0;
            this.toolStripStatusLabel.Text = "Header Parsed";
            Application.DoEvents();
            if (!this.romHeader.romHeader.loaded)
            {
                this.apPatchSupported(false, crcDupes.romTypes.unknown, null);
                this.tabExport.Enabled = false;
                this.initRomInfoFields();
                this.disableTabs();
                this.cmpCheatsFound(false);
                return false;
            }
            this.romHeader.romHeader.cleanCrc = this.crcDb.crcToCleanCrc(this.romHeader.romHeader.hash.ToUpper());
            if ((this.romHeader.romHeader.cleanCrc == null) || (this.romHeader.romHeader.cleanCrc.hash == ""))
            {
                this.romHeader.romHeader.cleanCrc = new crcDupes.possibleCrcType();
                this.romHeader.romHeader.cleanCrc.hash = this.romHeader.romHeader.hash.ToUpper();
                this.romHeader.romHeader.cleanCrc.type = crcDupes.romTypes.unknown;
            }
            this.downloadInfoFromWebsite(this.romHeader.romHeader.cleanCrc.type, this.romHeader.romHeader.cleanCrc.hash, this.toolStripProgressBar, this.toolStripStatusLabel, true, false);
            Application.DoEvents();
            this.patchInfo = this.patchDb.findPatchInDb(this.romHeader.romHeader.cleanCrc.hash);
            if (this.patchInfo != null)
            {
                this.apPatchSupported(true, this.romHeader.romHeader.cleanCrc.type, this.patchInfo);
                this.tabExport.Enabled = true;
            }
            else
            {
                this.tabExport.Enabled = true;
                this.apPatchSupported(false, this.romHeader.romHeader.cleanCrc.type, null);
            }
            this.cmpCheatsFound(this.hasCheats(this.romHeader.romHeader.gameCode));
            this.txtFileLoc.Text = this.fdlg.FileName;
            if (flag2)
            {
                this.btnHeaderRefresh.Enabled = true;
            }
            return true;
        }

        private bool downloadCMPGameList()
        {
            string url = "http://files-ds-scene.net/romtool/releases/cmp/cmpGameList.bin";
            return this.downloadFile(url, "data/databases/", "CMP Game List", "", null, null);
        }

        public bool downloadFile(string url, string dirdest, string progressTxt, string saveas = "", ProgressBar progress = null, Label status = null)
        {
            if (progress == null)
            {
                progress = this.toolStripProgressBar;
            }
            if (status == null)
            {
                status = this.toolStripStatusLabel;
            }
            if (!this.allowDownload)
            {
                MessageBox.Show("Please wait for the current download to finish", "Download already in progress", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.disableMainForm();
            this.allowDownload = false;
            this.downloadedData = new byte[0x4e2000];
            this.downloadedDataName = "";
            try
            {
                WebResponse response = WebRequest.Create(url).GetResponse();
                Stream responseStream = response.GetResponseStream();
                int contentLength = (int) response.ContentLength;
                if ((contentLength == -1) && (url.Substring(0, "http://www.ds-scene.net/romtool.php?version=2&hash=".Length) == "http://www.ds-scene.net/romtool.php?version=2&hash="))
                {
                    contentLength = 10;
                }
                progress.Maximum = contentLength;
                progress.Value = 0;
                int num2 = 3;
                while (true)
                {
                    if (num2 < url.Length)
                    {
                        if ((url.Substring(url.Length - num2, 1) != "/") && (url.Substring(url.Length - num2, 1) != @"\"))
                        {
                            num2++;
                            continue;
                        }
                        this.downloadedDataName = url.Substring((url.Length - num2) + 1, (url.Length - (url.Length - num2)) - 1);
                    }
                    MemoryStream stream2 = new MemoryStream();
                    byte[] buffer = new byte[0x200];
                    while (true)
                    {
                        int count = responseStream.Read(buffer, 0, buffer.Length);
                        if (count == 0)
                        {
                            progress.Value = progress.Maximum;
                            object[] objArray = new object[] { "Completed: ", progressTxt, " ", this.run.hexAndMathFunction.getPercentage(progress.Value, contentLength), "%" };
                            status.Text = string.Concat(objArray);
                            Application.DoEvents();
                            this.downloadedData = stream2.ToArray();
                            responseStream.Close();
                            stream2.Close();
                            this.enableMainForm();
                            break;
                        }
                        stream2.Write(buffer, 0, count);
                        if ((progress.Value + count) <= progress.Maximum)
                        {
                            progress.Value = ((progress.Value + count) <= progress.Maximum) ? (progress.Value + count) : progress.Maximum;
                            object[] objArray2 = new object[] { "Downloading: ", progressTxt, " ", this.run.hexAndMathFunction.getPercentage(progress.Value, contentLength), "%" };
                            status.Text = string.Concat(objArray2);
                            Application.DoEvents();
                        }
                    }
                    break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Could not download " + url + "\n\n" + exception.Message);
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

        public bool downloadInfoFromWebsite(crcDupes.romTypes type, string hash, ProgressBar progress, Label status, bool display, bool fromTheButton = false)
        {
            bool flag = false;
            bool flag2 = !this.web.validateWebInfo(hash);
            if (fromTheButton && (this.romHeader.romHeader.website_knows_it && !flag2))
            {
                bool flag3;
                webInfo.webInfoItemClass[] item = this.web.info.item;
                int index = 0;
                while (true)
                {
                    if (index < item.Length)
                    {
                        TimeSpan span;
                        webInfo.webInfoItemClass class2 = item[index];
                        if ((class2 == null) || (class2.key != "date"))
                        {
                            index++;
                            continue;
                        }
                        DateTime utcNow = DateTime.UtcNow;
                        DateTime time2 = new DateTime(int.Parse(class2.val.Substring(0, 4)), int.Parse(class2.val.Substring(4, 2)), int.Parse(class2.val.Substring(6, 2)), int.Parse(class2.val.Substring(8, 2)), int.Parse(class2.val.Substring(10, 2)), int.Parse(class2.val.Substring(12, 2)));
                        string[] strArray = new string[] { utcNow.Year.ToString("D2"), utcNow.Month.ToString("D2"), utcNow.Day.ToString("D2"), utcNow.Hour.ToString("D2"), utcNow.Minute.ToString("D2"), utcNow.Second.ToString("D2") };
                        string[] strArray2 = new string[] { time2.Year.ToString("D2"), time2.Month.ToString("D2"), time2.Day.ToString("D2"), time2.Hour.ToString("D2"), time2.Minute.ToString("D2"), time2.Second.ToString("D2") };
                        if (long.Parse(string.Concat(strArray)) <= long.Parse(string.Concat(strArray2)))
                        {
                            span = time2.Subtract(utcNow);
                            if (span.TotalMilliseconds > 0.0)
                            {
                                MessageBox.Show("You must wait between refreshes\n\nPlease wait " + ((int) (span.TotalMilliseconds / 1000.0)) + " seconds longer", "Please Wait", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                flag3 = false;
                                break;
                            }
                        }
                        else
                        {
                            span = utcNow.Subtract(time2);
                            if (span.TotalMilliseconds < 60000.0)
                            {
                                MessageBox.Show(string.Concat(new object[] { "You must wait ", (int) 60, " seconds between refreshes\n\nPlease wait ", (int) (60.0 - (span.TotalMilliseconds / 1000.0)), " seconds longer" }), "Please Wait", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                flag3 = false;
                                break;
                            }
                        }
                    }
                    goto TR_0011;
                }
                return flag3;
            }
        TR_0011:
            if ((!flag2 || !fromTheButton) && System.IO.File.Exists("data/web/info/" + hash + "_info.dsapdb"))
            {
                if (type == crcDupes.romTypes.unknown)
                {
                    type = crcDupes.romTypes.clean;
                }
                if (display)
                {
                    this.displayRomWebInfo(type, hash);
                }
            }
            else if ((this.options.getValue("auto_info_dl") != "1") && !fromTheButton)
            {
                if (display)
                {
                    this.displayRomWebInfo(crcDupes.romTypes.unknown, hash);
                    if (!fromTheButton && (this.options.getValue("disable_webalert") != "1"))
                    {
                        MessageBox.Show("No information was found on ds-scene.net for this rom", "No Information Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            else if (this.web.downloadRomInfo(hash, progress, status))
            {
                flag = true;
                if (type == crcDupes.romTypes.unknown)
                {
                    type = crcDupes.romTypes.clean;
                }
                if (display)
                {
                    this.displayRomWebInfo(type, hash);
                }
            }
            webInfo.webInfoClass class3 = new webInfo.webInfoClass();
            class3 = this.web.parseWebInfo(hash);
            this.romHeader.romHeader.website_knows_it = (class3 != null) && ((class3.item[0] != null) && ((class3.item[0].key != "error:hash not found") && (class3.item[0].key != "error:bad hash")));
            return flag;
        }

        public void downloadRarDriver()
        {
            if (!this.downloadFile("http://files-ds-scene.net/romtool/releases/unrar.dll", "", "unrar.dll", "", null, null))
            {
                MessageBox.Show("The unrar.dll driver failed to install, please try again later", "Driver Installation Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                MessageBox.Show("The unrar.dll driver was installed successfully", "Driver Installation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.rarInstalled = true;
            }
        }

        public void downloadUpdater()
        {
            if (this.downloadFile("http://files-ds-scene.net/romtool/releases/updaters/updater_v0.2.exe", "", "updater_v0.2.exe", "", null, null))
            {
                MessageBox.Show("The sub-application updater_v0.2.exe was installed successfully", "Sub-Application Installation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.rarInstalled = true;
            }
            else
            {
                MessageBox.Show("The sub-application updater_v0.2.exe failed to install,\nplease try again later.\n\nThe application will now exit", "Sub-Application Installation Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }
        }

        public void downloadZipDriver()
        {
            if (!this.downloadFile("http://files-ds-scene.net/romtool/releases/7z.dll", "", "7z.dll", "", null, null))
            {
                MessageBox.Show("The 7z.dll driver failed to install, please try again later", "Driver Installation Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                MessageBox.Show("The 7z.dll driver was installed successfully", "Driver Installation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.zipInstalled = true;
            }
        }

        private void drawIconPalette()
        {
            for (int i = 0; i < 0x10; i++)
            {
                Color color = new Color();
                int num2 = int.Parse(this.run.hexAndMathFunction.reversehex(this.romHeader.romHeader.icon.pal[i], 4), NumberStyles.HexNumber);
                color = Color.FromArgb((num2 % 0x20) * 8, ((num2 / 0x20) % 0x20) * 8, ((num2 / 0x400) % 0x20) * 8);
                this.getPalCheckBox(i).BackColor = color;
                this.getPalCheckBox(i).Checked = false;
            }
        }

        private void edgeCMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.installCMP(cmpDownloadType.EDGE);
        }

        private void eDGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        private void emulatorLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.emulatorConfigForm.ShowDialog();
        }

        public void enableCMPInstall(cmpDownloadType type, string ver)
        {
            switch (type)
            {
                case cmpDownloadType.USRcheat:
                    this.uSRCHEATToolStripMenuItem.Enabled = true;
                    this.uSRCHEATToolStripMenuItem.Text = "USRcheat [" + ver + "]";
                    return;

                case cmpDownloadType.EDGE:
                    this.edgeCMPToolStripMenuItem.Enabled = true;
                    this.edgeCMPToolStripMenuItem.Text = "EDGE [" + ver + "]";
                    return;

                case cmpDownloadType.CycloDS:
                    this.cycloDSCMPToolStripMenuItem.Enabled = true;
                    this.cycloDSCMPToolStripMenuItem.Text = "CycloDS [" + ver + "]";
                    return;
            }
        }

        public void enableMainForm()
        {
            this.menuStrip1.Enabled = true;
            this.openToolStripMenuItem.Enabled = true;
            this.btnBrowse.Enabled = true;
            this.batchProcessToolStripMenuItem.Enabled = true;
            if (this.txtFileLoc.Text != "")
            {
                this.enableTabs();
            }
            if (this.collectionForm != null)
            {
                this.collectionForm.listCollectionDbs.Enabled = true;
                this.collectionForm.btnAddCollection.Enabled = true;
                this.collectionForm.listViewRoms.Enabled = true;
                this.collectionForm.groupBoxFilters.Enabled = true;
            }
        }

        public void enableTabs()
        {
            this.buttonApply.Enabled = true;
            this.checkBoxTrim.Enabled = true;
            this.tabControlMain.Enabled = true;
        }

        private void enableUpdateAlertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        private void exitApplication()
        {
            if (this.collectionForm != null)
            {
                Settings.Default.Collection_W = this.collectionForm.Width;
                Settings.Default.Collection_H = this.collectionForm.Height;
                Settings.Default.Collection_Col1 = this.collectionForm.listViewRoms.Columns[0].Width;
                Settings.Default.Collection_Col2 = this.collectionForm.listViewRoms.Columns[1].Width;
                Settings.Default.Collection_Col3 = this.collectionForm.listViewRoms.Columns[2].Width;
                Settings.Default.Collection_Col4 = this.collectionForm.listViewRoms.Columns[3].Width;
                Settings.Default.Save();
            }
            this.cleanTempFiles();
            Environment.Exit(0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.exitApplication();
        }

        public bool extractRom(string path_src, string path_dest, string arcType, ProgressBar progress, Label status)
        {
            int num = this.compressor.findFirstExtInArchive("nds", path_src, arcType, progress, status);
            if (num != -1)
            {
                this.compressor.outFile = path_dest;
                return this.compressor.extract(path_src, (uint) num, arcType, progress, status);
            }
            num = this.compressor.findFirstExtInArchive("3ds", path_src, arcType, progress, status);
            if (num == -1)
            {
                return false;
            }
            this.compressor.outFile = path_dest;
            return this.compressor.extract(path_src, (uint) num, arcType, progress, status);
        }

        private string fixFileExistsName(string fn, int count)
        {
            int startIndex = fn.LastIndexOf('.');
            string str = fn.Substring(startIndex, fn.Length - startIndex);
            if (count > 1)
            {
                startIndex = fn.LastIndexOf('(');
            }
            object[] objArray = new object[] { fn.Substring(0, startIndex), "(", count, ")", str };
            return string.Concat(objArray);
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

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.exitApplication();
        }

        private Image get3DSoptImage(string type)
        {
            string key = type;
            if (key != null)
            {
                int num;
                if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x60000fe-1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(7);
                    dictionary1.Add("downloadplay", 0);
                    dictionary1.Add("onlineplay", 1);
                    dictionary1.Add("multicartplay", 2);
                    dictionary1.Add("pushcontent", 3);
                    dictionary1.Add("streetpass", 4);
                    dictionary1.Add("slidepad", 5);
                    dictionary1.Add("", 6);
                    <PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x60000fe-1 = dictionary1;
                }
                if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x60000fe-1.TryGetValue(key, out num))
                {
                    switch (num)
                    {
                        case 0:
                            return Resources.downloadplay;

                        case 1:
                            return Resources.onlineplay;

                        case 2:
                            return Resources.multicartplay;

                        case 3:
                            return Resources.spotpass;

                        case 4:
                            return Resources.streetpass;

                        case 5:
                            return Resources.slidepad;

                        case 6:
                            goto TR_0000;

                        default:
                            break;
                    }
                }
            }
            MessageBox.Show("Unsupported 3DS option for web data '" + type + "'.");
        TR_0000:
            return null;
        }

        private long getAccurateTrimPosition(string romIn, ProgressBar progress, Label status, bool trim)
        {
            long num = this.romHeader.romHeader.accurate_trim_size;
            if (!trim)
            {
                num = (this.romHeader.romHeader.fileSize == -1) ? this.romHeader.romHeader.fileSize_3ds : ((long) this.romHeader.romHeader.fileSize);
            }
            return num;
        }

        public string getFileExtension(string fn)
        {
            string str = "";
            int length = 0;
            while (true)
            {
                if (length < fn.Length)
                {
                    if (fn.Substring((fn.Length - 1) - length, 1) != ".")
                    {
                        length++;
                        continue;
                    }
                    str = fn.Substring(fn.Length - length, length);
                }
                return str;
            }
        }

        public CheckBox getPalCheckBox(int i)
        {
            switch (i)
            {
                case 0:
                    return this.picPal_0;

                case 1:
                    return this.picPal_1;

                case 2:
                    return this.picPal_2;

                case 3:
                    return this.picPal_3;

                case 4:
                    return this.picPal_4;

                case 5:
                    return this.picPal_5;

                case 6:
                    return this.picPal_6;

                case 7:
                    return this.picPal_7;

                case 8:
                    return this.picPal_8;

                case 9:
                    return this.picPal_9;

                case 10:
                    return this.picPal_10;

                case 11:
                    return this.picPal_11;

                case 12:
                    return this.picPal_12;

                case 13:
                    return this.picPal_13;

                case 14:
                    return this.picPal_14;

                case 15:
                    return this.picPal_15;
            }
            MessageBox.Show("Tried to read larger than a palette size");
            return null;
        }

        private long getRomTrimPosition(string romIn, ProgressBar progress, Label status, romTrimTypes trim) => 
            (trim != romTrimTypes.safe) ? ((trim == romTrimTypes.none) ? this.getAccurateTrimPosition(romIn, progress, status, false) : this.getAccurateTrimPosition(romIn, progress, status, true)) : this.getSafeTrimPosition(romIn, progress, status, true);

        private long getSafeTrimPosition(string romIn, ProgressBar progress, Label status, bool trim)
        {
            long num6;
            long length = -1L;
            try
            {
                FileStream input = System.IO.File.Open(romIn, FileMode.Open);
                using (BinaryReader reader = new BinaryReader(input))
                {
                    length = reader.BaseStream.Length;
                    if (trim)
                    {
                        long num2 = this.run.hexAndMathFunction.bytesToMbit(reader.BaseStream.Length);
                        progress.Maximum = 100;
                        progress.Value = 0;
                        status.Text = "Calculating Trim " + this.origFileLocToNewFileName(romIn, false, false, "") + " 0%";
                        Application.DoEvents();
                        int count = 0x400;
                        long length = reader.BaseStream.Length;
                        while (true)
                        {
                            if (length <= -count)
                            {
                                break;
                            }
                            if (length < count)
                            {
                                length = count;
                            }
                            reader.BaseStream.Position = length - count;
                            this.trimbuffer = reader.ReadBytes(count);
                            if ((num2 - this.run.hexAndMathFunction.bytesToMbit(length)) != this.toolStripProgressBar.Value)
                            {
                                progress.Value = (int) ((num2 - this.run.hexAndMathFunction.bytesToMbit(length)) / num2);
                                object[] objArray = new object[] { "Calculating Trim ", this.origFileLocToNewFileName(romIn, false, false, ""), " ", (int) ((num2 - this.run.hexAndMathFunction.bytesToMbit(length)) / num2), "%" };
                                status.Text = string.Concat(objArray);
                                Application.DoEvents();
                            }
                            int index = 0;
                            string str = "";
                            index = count - 1;
                            while (true)
                            {
                                if (index >= 0)
                                {
                                    str = this.trimbuffer[index].ToString("X2");
                                    if ((str == "FF") || (str == "00"))
                                    {
                                        length -= 1L;
                                        index--;
                                        continue;
                                    }
                                }
                                if ((str == "FF") || (str == "00"))
                                {
                                    length -= count;
                                }
                                else
                                {
                                    break;
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        input.Close();
                        return length;
                    }
                    status.Text = "Calculating Trim " + this.origFileLocToNewFileName(romIn, false, false, "") + " Done";
                    progress.Value = 100;
                    this.trimbuffer = null;
                    input.Close();
                    return length;
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
                num6 = -1L;
            }
            return num6;
        }

        public bool hasCheats(string code)
        {
            bool flag = false;
            if (this.cmpGamesFilled <= 0)
            {
                flag = false;
            }
            else
            {
                for (int i = 0; i < this.cmpGamesFilled; i++)
                {
                    if (this.cmpGames[i].gameCode == code)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        private void hideAll3DSoptions()
        {
            this.n3dsopt_0.Visible = false;
            this.n3dsopt_1.Visible = false;
            this.n3dsopt_2.Visible = false;
            this.n3dsopt_3.Visible = false;
            this.n3dsopt_4.Visible = false;
            this.n3dsopt_5.Visible = false;
            this.picNinNetwork.Visible = false;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://files-ds-scene.net/romtool/");
            }
            catch
            {
                MessageBox.Show("The url could not be opened, please try again", "URL open error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(apPatcherAppForm));
            this.txtFileLoc = new TextBox();
            this.btnBrowse = new Button();
            this.txtFooterText = new Label();
            this.appUrlFooter = new Label();
            this.dbGamesText = new Label();
            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.openToolStripMenuItem = new ToolStripMenuItem();
            this.batchProcessToolStripMenuItem = new ToolStripMenuItem();
            this.patchingToolStripMenuItem = new ToolStripMenuItem();
            this.nFOViewerToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.databaseToolStripMenuItem = new ToolStripMenuItem();
            this.aPDatabaseToolStripMenuItem = new ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem1 = new ToolStripMenuItem();
            this.updateAlertsToolStripMenuItem = new ToolStripMenuItem();
            this.enableUpdateAlertsToolStripMenuItem = new ToolStripMenuItem();
            this.versionInfoToolStripMenuItem1 = new ToolStripMenuItem();
            this.cMPDatabaseToolStripMenuItem1 = new ToolStripMenuItem();
            this.installToMediaToolStripMenuItem = new ToolStripMenuItem();
            this.cycloDSCMPToolStripMenuItem = new ToolStripMenuItem();
            this.edgeCMPToolStripMenuItem = new ToolStripMenuItem();
            this.uSRCHEATToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            this.updateAlertsToolStripMenuItem1 = new ToolStripMenuItem();
            this.cycloDSToolStripMenuItem = new ToolStripMenuItem();
            this.eDGEToolStripMenuItem = new ToolStripMenuItem();
            this.uSRcheatToolStripMenuItem1 = new ToolStripMenuItem();
            this.versionInfoToolStripMenuItem = new ToolStripMenuItem();
            this.romCollectionsToolStripMenuItem = new ToolStripMenuItem();
            this.collectionBrowserToolStripMenuItem = new ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new ToolStripMenuItem();
            this.autoOpenBrowserToolStripMenuItem = new ToolStripMenuItem();
            this.autoLaunchEmulatorToolStripMenuItem = new ToolStripMenuItem();
            this.optionsToolStripMenuItem = new ToolStripMenuItem();
            this.emulatorLocationsToolStripMenuItem = new ToolStripMenuItem();
            this.applicationUpdatesToolStripMenuItem = new ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem1 = new ToolStripMenuItem();
            this.toolStripSeparator4 = new ToolStripSeparator();
            this.disableCheckOnStartToolStripMenuItem = new ToolStripMenuItem();
            this.dSSceneContentToolStripMenuItem = new ToolStripMenuItem();
            this.disableWebContentToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.autoDownloadToolStripMenuItem = new ToolStripMenuItem();
            this.disableWebAlertContentToolStripMenuItem = new ToolStripMenuItem();
            this.rememberDSSceneInfoToolStripMenuItem = new ToolStripMenuItem();
            this.aboutToolStripMenuItem = new ToolStripMenuItem();
            this.homeToolStripMenuItem = new ToolStripMenuItem();
            this.changeLogToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.txtHdrTitle = new Label();
            this.label6 = new Label();
            this.label8 = new Label();
            this.gameTitleText = new TextBox();
            this.gameCodeText = new TextBox();
            this.cardSizeText = new TextBox();
            this.tabControlMain = new TabControl();
            this.tabWebInfo = new TabPage();
            this.groupBox2 = new GroupBox();
            this.picNinNetwork = new PictureBox();
            this.n3dsopt_5 = new PictureBox();
            this.btnNFO = new Button();
            this.n3dsopt_2 = new PictureBox();
            this.n3dsopt_4 = new PictureBox();
            this.n3dsopt_1 = new PictureBox();
            this.n3dsopt_3 = new PictureBox();
            this.n3dsopt_0 = new PictureBox();
            this.launchEmulator = new Button();
            this.cmpDbSupportBtn = new Button();
            this.romTypeTxt = new Label();
            this.webInfo_id = new TextBox();
            this.buttonForumLink = new Button();
            this.label16 = new Label();
            this.label15 = new Label();
            this.webInfo_date = new Label();
            this.webInfo_newsdate = new Label();
            this.webInfo_wifi = new PictureBox();
            this.buttonRomInfo = new Button();
            this.label13 = new Label();
            this.webInfo_dir = new TextBox();
            this.webInfo_arc = new TextBox();
            this.romIcon3 = new PictureBox();
            this.label12 = new Label();
            this.webInfo_Boxart = new PictureBox();
            this.webInfo_save = new TextBox();
            this.webInfo_number = new TextBox();
            this.label11 = new Label();
            this.label5 = new Label();
            this.webInfo_grp = new TextBox();
            this.label7 = new Label();
            this.label10 = new Label();
            this.webInfo_name = new TextBox();
            this.label9 = new Label();
            this.webInfo_rgn = new PictureBox();
            this.picDSCard = new PictureBox();
            this.pic3DSCard = new PictureBox();
            this.webInfo_dscompat = new PictureBox();
            this.tabRomInfo = new TabPage();
            this.btnHeaderRefresh = new Button();
            this.iconEditorGroup = new GroupBox();
            this.picPal_15 = new CheckBox();
            this.picPal_14 = new CheckBox();
            this.picPal_13 = new CheckBox();
            this.picPal_12 = new CheckBox();
            this.picPal_7 = new CheckBox();
            this.picPal_6 = new CheckBox();
            this.picPal_5 = new CheckBox();
            this.picPal_4 = new CheckBox();
            this.picPal_11 = new CheckBox();
            this.picPal_10 = new CheckBox();
            this.picPal_9 = new CheckBox();
            this.picPal_8 = new CheckBox();
            this.picPal_3 = new CheckBox();
            this.picPal_2 = new CheckBox();
            this.picPal_1 = new CheckBox();
            this.picPal_0 = new CheckBox();
            this.makerNameText = new TextBox();
            this.makerCodeText = new TextBox();
            this.label4 = new Label();
            this.fileSizeText = new TextBox();
            this.label2 = new Label();
            this.crc32Text = new TextBox();
            this.label1 = new Label();
            this.tabControlLang = new TabControl();
            this.tabLangJpn = new TabPage();
            this.name_jpnText = new RichTextBox();
            this.tabLangEng = new TabPage();
            this.name_engText = new RichTextBox();
            this.tabLangFre = new TabPage();
            this.name_freText = new RichTextBox();
            this.tabLangGer = new TabPage();
            this.name_gerText = new RichTextBox();
            this.tabLangIta = new TabPage();
            this.name_itaText = new RichTextBox();
            this.tabLangSpa = new TabPage();
            this.name_spaText = new RichTextBox();
            this.buttonSaveIcon = new Button();
            this.romIcon = new PictureBox();
            this.tabApPatch = new TabPage();
            this.btnImportAP = new Button();
            this.btnExportAP = new Button();
            this.label14 = new Label();
            this.patchCreatorText = new Label();
            this.patchNameText = new Label();
            this.apPatchInfoGrp = new GroupBox();
            this.patchInfoText = new RichTextBox();
            this.romIcon2 = new PictureBox();
            this.tabExport = new TabPage();
            this.groupBox5 = new GroupBox();
            this.checkBoxDelete = new CheckBox();
            this.compressionSelect = new ComboBox();
            this.groupBox4 = new GroupBox();
            this.radioAccurateTrim = new RadioButton();
            this.checkBoxTrim = new CheckBox();
            this.radioSafeTrim = new RadioButton();
            this.groupBox1 = new GroupBox();
            this.checkBoxApPatch = new CheckBox();
            this.buttonApply = new Button();
            this.imageList1 = new ImageList(this.components);
            this.toolStripProgressBar = new ProgressBar();
            this.toolStripStatusLabel = new Label();
            this.tesToolStripMenuItem = new ToolStripMenuItem();
            this.panel1 = new Panel();
            this.menuStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabWebInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.picNinNetwork).BeginInit();
            ((ISupportInitialize) this.n3dsopt_5).BeginInit();
            ((ISupportInitialize) this.n3dsopt_2).BeginInit();
            ((ISupportInitialize) this.n3dsopt_4).BeginInit();
            ((ISupportInitialize) this.n3dsopt_1).BeginInit();
            ((ISupportInitialize) this.n3dsopt_3).BeginInit();
            ((ISupportInitialize) this.n3dsopt_0).BeginInit();
            ((ISupportInitialize) this.webInfo_wifi).BeginInit();
            ((ISupportInitialize) this.romIcon3).BeginInit();
            ((ISupportInitialize) this.webInfo_Boxart).BeginInit();
            ((ISupportInitialize) this.webInfo_rgn).BeginInit();
            ((ISupportInitialize) this.picDSCard).BeginInit();
            ((ISupportInitialize) this.pic3DSCard).BeginInit();
            ((ISupportInitialize) this.webInfo_dscompat).BeginInit();
            this.tabRomInfo.SuspendLayout();
            this.iconEditorGroup.SuspendLayout();
            this.tabControlLang.SuspendLayout();
            this.tabLangJpn.SuspendLayout();
            this.tabLangEng.SuspendLayout();
            this.tabLangFre.SuspendLayout();
            this.tabLangGer.SuspendLayout();
            this.tabLangIta.SuspendLayout();
            this.tabLangSpa.SuspendLayout();
            ((ISupportInitialize) this.romIcon).BeginInit();
            this.tabApPatch.SuspendLayout();
            this.apPatchInfoGrp.SuspendLayout();
            ((ISupportInitialize) this.romIcon2).BeginInit();
            this.tabExport.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.txtFileLoc.Location = new Point(14, 0x1f);
            this.txtFileLoc.Name = "txtFileLoc";
            this.txtFileLoc.ReadOnly = true;
            this.txtFileLoc.Size = new Size(0x150, 0x15);
            this.txtFileLoc.TabIndex = 0x4f;
            this.btnBrowse.Cursor = Cursors.Hand;
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowse.Location = new Point(0x161, 0x1f);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new Size(0x1f, 20);
            this.btnBrowse.TabIndex = 0x4e;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new EventHandler(this.btnBrowse_Click);
            this.txtFooterText.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.txtFooterText.AutoSize = true;
            this.txtFooterText.BackColor = Color.Transparent;
            this.txtFooterText.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtFooterText.ForeColor = SystemColors.ControlText;
            this.txtFooterText.Location = new Point(3, 400);
            this.txtFooterText.Name = "txtFooterText";
            this.txtFooterText.Size = new Size(0x4c, 12);
            this.txtFooterText.TabIndex = 0x51;
            this.txtFooterText.Text = "appNameHere";
            this.appUrlFooter.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.appUrlFooter.AutoSize = true;
            this.appUrlFooter.BackColor = Color.Transparent;
            this.appUrlFooter.Cursor = Cursors.Hand;
            this.appUrlFooter.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.appUrlFooter.ForeColor = SystemColors.ControlText;
            this.appUrlFooter.Location = new Point(0x11f, 400);
            this.appUrlFooter.Name = "appUrlFooter";
            this.appUrlFooter.Size = new Size(0x5f, 12);
            this.appUrlFooter.TabIndex = 0x52;
            this.appUrlFooter.Text = "www.ds-scene.net";
            this.appUrlFooter.Click += new EventHandler(this.appUrlFooter_Click);
            this.dbGamesText.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.dbGamesText.AutoSize = true;
            this.dbGamesText.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dbGamesText.Location = new Point(8, 0x126);
            this.dbGamesText.Name = "dbGamesText";
            this.dbGamesText.Size = new Size(0x76, 12);
            this.dbGamesText.TabIndex = 0x54;
            this.dbGamesText.Text = "supporting 100 games";
            this.menuStrip1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.fileToolStripMenuItem, this.databaseToolStripMenuItem, this.optionsToolStripMenuItem, this.aboutToolStripMenuItem };
            this.menuStrip1.Items.AddRange(toolStripItems);
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new Size(390, 0x18);
            this.menuStrip1.TabIndex = 0x58;
            this.menuStrip1.Text = "menuStrip1";
            ToolStripItem[] itemArray2 = new ToolStripItem[] { this.openToolStripMenuItem, this.batchProcessToolStripMenuItem, this.nFOViewerToolStripMenuItem, this.exitToolStripMenuItem };
            this.fileToolStripMenuItem.DropDownItems.AddRange(itemArray2);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(0x26, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.openToolStripMenuItem.Image = Resources.open1;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.openToolStripMenuItem.Text = "Open File...";
            this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
            ToolStripItem[] itemArray3 = new ToolStripItem[] { this.patchingToolStripMenuItem };
            this.batchProcessToolStripMenuItem.DropDownItems.AddRange(itemArray3);
            this.batchProcessToolStripMenuItem.Image = Resources.batch_process;
            this.batchProcessToolStripMenuItem.Name = "batchProcessToolStripMenuItem";
            this.batchProcessToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.batchProcessToolStripMenuItem.Text = "Batch Process";
            this.patchingToolStripMenuItem.Image = Resources.patch_trim_pack;
            this.patchingToolStripMenuItem.Name = "patchingToolStripMenuItem";
            this.patchingToolStripMenuItem.Size = new Size(0xc3, 0x16);
            this.patchingToolStripMenuItem.Text = "Patch, Trim and Pack";
            this.patchingToolStripMenuItem.Click += new EventHandler(this.patchingToolStripMenuItem_Click);
            this.nFOViewerToolStripMenuItem.Image = (Image) manager.GetObject("nFOViewerToolStripMenuItem.Image");
            this.nFOViewerToolStripMenuItem.Name = "nFOViewerToolStripMenuItem";
            this.nFOViewerToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.nFOViewerToolStripMenuItem.Text = "NFO Viewer";
            this.nFOViewerToolStripMenuItem.Click += new EventHandler(this.nFOViewerToolStripMenuItem_Click);
            this.exitToolStripMenuItem.Image = Resources.exit1;
            this.exitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            ToolStripItem[] itemArray4 = new ToolStripItem[] { this.aPDatabaseToolStripMenuItem, this.cMPDatabaseToolStripMenuItem1, this.romCollectionsToolStripMenuItem };
            this.databaseToolStripMenuItem.DropDownItems.AddRange(itemArray4);
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new Size(0x4f, 20);
            this.databaseToolStripMenuItem.Text = "Databases";
            ToolStripItem[] itemArray5 = new ToolStripItem[] { this.checkForUpdatesToolStripMenuItem1, this.updateAlertsToolStripMenuItem, this.versionInfoToolStripMenuItem1 };
            this.aPDatabaseToolStripMenuItem.DropDownItems.AddRange(itemArray5);
            this.aPDatabaseToolStripMenuItem.Image = Resources.ap_icon;
            this.aPDatabaseToolStripMenuItem.Name = "aPDatabaseToolStripMenuItem";
            this.aPDatabaseToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.aPDatabaseToolStripMenuItem.Text = "AP Database";
            this.checkForUpdatesToolStripMenuItem1.Image = Resources.check_for_update;
            this.checkForUpdatesToolStripMenuItem1.Name = "checkForUpdatesToolStripMenuItem1";
            this.checkForUpdatesToolStripMenuItem1.Size = new Size(0xae, 0x16);
            this.checkForUpdatesToolStripMenuItem1.Text = "Check for Update";
            this.checkForUpdatesToolStripMenuItem1.Click += new EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            ToolStripItem[] itemArray6 = new ToolStripItem[] { this.enableUpdateAlertsToolStripMenuItem };
            this.updateAlertsToolStripMenuItem.DropDownItems.AddRange(itemArray6);
            this.updateAlertsToolStripMenuItem.Image = Resources.gear_exclamation;
            this.updateAlertsToolStripMenuItem.Name = "updateAlertsToolStripMenuItem";
            this.updateAlertsToolStripMenuItem.Size = new Size(0xae, 0x16);
            this.updateAlertsToolStripMenuItem.Text = "Update Alerts";
            this.enableUpdateAlertsToolStripMenuItem.CheckOnClick = true;
            this.enableUpdateAlertsToolStripMenuItem.Name = "enableUpdateAlertsToolStripMenuItem";
            this.enableUpdateAlertsToolStripMenuItem.Size = new Size(0xc1, 0x16);
            this.enableUpdateAlertsToolStripMenuItem.Text = "Enable Update Alerts";
            this.enableUpdateAlertsToolStripMenuItem.Click += new EventHandler(this.enableUpdateAlertsToolStripMenuItem_Click);
            this.versionInfoToolStripMenuItem1.Image = Resources.version_info;
            this.versionInfoToolStripMenuItem1.Name = "versionInfoToolStripMenuItem1";
            this.versionInfoToolStripMenuItem1.Size = new Size(0xae, 0x16);
            this.versionInfoToolStripMenuItem1.Text = "Version Info";
            this.versionInfoToolStripMenuItem1.Click += new EventHandler(this.versionInfoToolStripMenuItem1_Click);
            ToolStripItem[] itemArray7 = new ToolStripItem[] { this.installToMediaToolStripMenuItem, this.toolStripSeparator2, this.checkForUpdatesToolStripMenuItem, this.updateAlertsToolStripMenuItem1, this.versionInfoToolStripMenuItem };
            this.cMPDatabaseToolStripMenuItem1.DropDownItems.AddRange(itemArray7);
            this.cMPDatabaseToolStripMenuItem1.Image = Resources.cmp_icon;
            this.cMPDatabaseToolStripMenuItem1.Name = "cMPDatabaseToolStripMenuItem1";
            this.cMPDatabaseToolStripMenuItem1.Size = new Size(0xa6, 0x16);
            this.cMPDatabaseToolStripMenuItem1.Text = "CMP Database";
            ToolStripItem[] itemArray8 = new ToolStripItem[] { this.cycloDSCMPToolStripMenuItem, this.edgeCMPToolStripMenuItem, this.uSRCHEATToolStripMenuItem };
            this.installToMediaToolStripMenuItem.DropDownItems.AddRange(itemArray8);
            this.installToMediaToolStripMenuItem.Image = Resources.install_to_media;
            this.installToMediaToolStripMenuItem.Name = "installToMediaToolStripMenuItem";
            this.installToMediaToolStripMenuItem.Size = new Size(180, 0x16);
            this.installToMediaToolStripMenuItem.Text = "Install to Media";
            this.cycloDSCMPToolStripMenuItem.Enabled = false;
            this.cycloDSCMPToolStripMenuItem.Image = Resources.cyclo;
            this.cycloDSCMPToolStripMenuItem.Name = "cycloDSCMPToolStripMenuItem";
            this.cycloDSCMPToolStripMenuItem.Size = new Size(0xd0, 0x16);
            this.cycloDSCMPToolStripMenuItem.Text = "CycloDS [unavailable]";
            this.cycloDSCMPToolStripMenuItem.Click += new EventHandler(this.cycloDSCMPToolStripMenuItem_Click);
            this.edgeCMPToolStripMenuItem.Enabled = false;
            this.edgeCMPToolStripMenuItem.Image = Resources.edge1;
            this.edgeCMPToolStripMenuItem.Name = "edgeCMPToolStripMenuItem";
            this.edgeCMPToolStripMenuItem.Size = new Size(0xd0, 0x16);
            this.edgeCMPToolStripMenuItem.Text = "EDGE [unavailable]";
            this.edgeCMPToolStripMenuItem.Click += new EventHandler(this.edgeCMPToolStripMenuItem_Click);
            this.uSRCHEATToolStripMenuItem.Enabled = false;
            this.uSRCHEATToolStripMenuItem.Image = Resources.r41;
            this.uSRCHEATToolStripMenuItem.Name = "uSRCHEATToolStripMenuItem";
            this.uSRCHEATToolStripMenuItem.Size = new Size(0xd0, 0x16);
            this.uSRCHEATToolStripMenuItem.Text = "USRcheat [unavailable]";
            this.uSRCHEATToolStripMenuItem.Click += new EventHandler(this.uSRCHEATToolStripMenuItem_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(0xb1, 6);
            this.checkForUpdatesToolStripMenuItem.Image = Resources.check_for_update;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new Size(180, 0x16);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new EventHandler(this.checkForUpdatesToolStripMenuItem_Click_1);
            ToolStripItem[] itemArray9 = new ToolStripItem[] { this.cycloDSToolStripMenuItem, this.eDGEToolStripMenuItem, this.uSRcheatToolStripMenuItem1 };
            this.updateAlertsToolStripMenuItem1.DropDownItems.AddRange(itemArray9);
            this.updateAlertsToolStripMenuItem1.Image = Resources.gear_exclamation;
            this.updateAlertsToolStripMenuItem1.Name = "updateAlertsToolStripMenuItem1";
            this.updateAlertsToolStripMenuItem1.Size = new Size(180, 0x16);
            this.updateAlertsToolStripMenuItem1.Text = "Update Alerts";
            this.cycloDSToolStripMenuItem.CheckOnClick = true;
            this.cycloDSToolStripMenuItem.Name = "cycloDSToolStripMenuItem";
            this.cycloDSToolStripMenuItem.Size = new Size(0x81, 0x16);
            this.cycloDSToolStripMenuItem.Text = "CycloDS";
            this.cycloDSToolStripMenuItem.Click += new EventHandler(this.cycloDSToolStripMenuItem_Click);
            this.eDGEToolStripMenuItem.CheckOnClick = true;
            this.eDGEToolStripMenuItem.Name = "eDGEToolStripMenuItem";
            this.eDGEToolStripMenuItem.Size = new Size(0x81, 0x16);
            this.eDGEToolStripMenuItem.Text = "EDGE";
            this.eDGEToolStripMenuItem.Click += new EventHandler(this.eDGEToolStripMenuItem_Click);
            this.uSRcheatToolStripMenuItem1.CheckOnClick = true;
            this.uSRcheatToolStripMenuItem1.Name = "uSRcheatToolStripMenuItem1";
            this.uSRcheatToolStripMenuItem1.Size = new Size(0x81, 0x16);
            this.uSRcheatToolStripMenuItem1.Text = "USRcheat";
            this.uSRcheatToolStripMenuItem1.Click += new EventHandler(this.uSRcheatToolStripMenuItem1_Click);
            this.versionInfoToolStripMenuItem.Image = Resources.version_info;
            this.versionInfoToolStripMenuItem.Name = "versionInfoToolStripMenuItem";
            this.versionInfoToolStripMenuItem.Size = new Size(180, 0x16);
            this.versionInfoToolStripMenuItem.Text = "Version Info";
            this.versionInfoToolStripMenuItem.Click += new EventHandler(this.versionInfoToolStripMenuItem_Click_1);
            ToolStripItem[] itemArray10 = new ToolStripItem[] { this.collectionBrowserToolStripMenuItem, this.optionsToolStripMenuItem1 };
            this.romCollectionsToolStripMenuItem.DropDownItems.AddRange(itemArray10);
            this.romCollectionsToolStripMenuItem.Image = Resources.tetris161;
            this.romCollectionsToolStripMenuItem.Name = "romCollectionsToolStripMenuItem";
            this.romCollectionsToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.romCollectionsToolStripMenuItem.Text = "Rom Collections";
            this.collectionBrowserToolStripMenuItem.Image = Resources.eye_red;
            this.collectionBrowserToolStripMenuItem.Name = "collectionBrowserToolStripMenuItem";
            this.collectionBrowserToolStripMenuItem.Size = new Size(0x79, 0x16);
            this.collectionBrowserToolStripMenuItem.Text = "Browser";
            this.collectionBrowserToolStripMenuItem.Click += new EventHandler(this.collectionBrowserToolStripMenuItem_Click);
            ToolStripItem[] itemArray11 = new ToolStripItem[] { this.autoOpenBrowserToolStripMenuItem, this.autoLaunchEmulatorToolStripMenuItem };
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(itemArray11);
            this.optionsToolStripMenuItem1.Image = Resources.wrench_screwdriver;
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new Size(0x79, 0x16);
            this.optionsToolStripMenuItem1.Text = "Options";
            this.autoOpenBrowserToolStripMenuItem.CheckOnClick = true;
            this.autoOpenBrowserToolStripMenuItem.Name = "autoOpenBrowserToolStripMenuItem";
            this.autoOpenBrowserToolStripMenuItem.Size = new Size(0xf4, 0x16);
            this.autoOpenBrowserToolStripMenuItem.Text = "Open Browser on Start";
            this.autoOpenBrowserToolStripMenuItem.Click += new EventHandler(this.autoOpenBrowserToolStripMenuItem_Click);
            this.autoLaunchEmulatorToolStripMenuItem.CheckOnClick = true;
            this.autoLaunchEmulatorToolStripMenuItem.Enabled = false;
            this.autoLaunchEmulatorToolStripMenuItem.Name = "autoLaunchEmulatorToolStripMenuItem";
            this.autoLaunchEmulatorToolStripMenuItem.Size = new Size(0xf4, 0x16);
            this.autoLaunchEmulatorToolStripMenuItem.Text = "Auto Launch Default Emulator";
            ToolStripItem[] itemArray12 = new ToolStripItem[] { this.emulatorLocationsToolStripMenuItem, this.applicationUpdatesToolStripMenuItem, this.dSSceneContentToolStripMenuItem };
            this.optionsToolStripMenuItem.DropDownItems.AddRange(itemArray12);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new Size(0x3e, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.emulatorLocationsToolStripMenuItem.Image = Resources.application_block;
            this.emulatorLocationsToolStripMenuItem.Name = "emulatorLocationsToolStripMenuItem";
            this.emulatorLocationsToolStripMenuItem.Size = new Size(0xba, 0x16);
            this.emulatorLocationsToolStripMenuItem.Text = "Emulator Config";
            this.emulatorLocationsToolStripMenuItem.Click += new EventHandler(this.emulatorLocationsToolStripMenuItem_Click);
            ToolStripItem[] itemArray13 = new ToolStripItem[] { this.checkForUpdateToolStripMenuItem1, this.toolStripSeparator4, this.disableCheckOnStartToolStripMenuItem };
            this.applicationUpdatesToolStripMenuItem.DropDownItems.AddRange(itemArray13);
            this.applicationUpdatesToolStripMenuItem.Image = Resources.romtool;
            this.applicationUpdatesToolStripMenuItem.Name = "applicationUpdatesToolStripMenuItem";
            this.applicationUpdatesToolStripMenuItem.Size = new Size(0xba, 0x16);
            this.applicationUpdatesToolStripMenuItem.Text = "Application Updates";
            this.checkForUpdateToolStripMenuItem1.Image = Resources.check_for_update;
            this.checkForUpdateToolStripMenuItem1.Name = "checkForUpdateToolStripMenuItem1";
            this.checkForUpdateToolStripMenuItem1.Size = new Size(0xce, 0x16);
            this.checkForUpdateToolStripMenuItem1.Text = "Check For Update";
            this.checkForUpdateToolStripMenuItem1.Click += new EventHandler(this.checkForUpdateToolStripMenuItem1_Click);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new Size(0xcb, 6);
            this.disableCheckOnStartToolStripMenuItem.CheckOnClick = true;
            this.disableCheckOnStartToolStripMenuItem.Name = "disableCheckOnStartToolStripMenuItem";
            this.disableCheckOnStartToolStripMenuItem.Size = new Size(0xce, 0x16);
            this.disableCheckOnStartToolStripMenuItem.Text = "Disable Check on Start";
            this.disableCheckOnStartToolStripMenuItem.Click += new EventHandler(this.disableCheckOnStartToolStripMenuItem_Click);
            ToolStripItem[] itemArray14 = new ToolStripItem[] { this.disableWebContentToolStripMenuItem, this.toolStripSeparator1, this.autoDownloadToolStripMenuItem, this.disableWebAlertContentToolStripMenuItem, this.rememberDSSceneInfoToolStripMenuItem };
            this.dSSceneContentToolStripMenuItem.DropDownItems.AddRange(itemArray14);
            this.dSSceneContentToolStripMenuItem.Image = Resources.favicon;
            this.dSSceneContentToolStripMenuItem.Name = "dSSceneContentToolStripMenuItem";
            this.dSSceneContentToolStripMenuItem.Size = new Size(0xba, 0x16);
            this.dSSceneContentToolStripMenuItem.Text = "DS-Scene Content";
            this.disableWebContentToolStripMenuItem.CheckOnClick = true;
            this.disableWebContentToolStripMenuItem.Name = "disableWebContentToolStripMenuItem";
            this.disableWebContentToolStripMenuItem.Size = new Size(0xc7, 0x16);
            this.disableWebContentToolStripMenuItem.Text = "Disable All";
            this.disableWebContentToolStripMenuItem.Click += new EventHandler(this.disableWebContentToolStripMenuItem_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(0xc4, 6);
            this.autoDownloadToolStripMenuItem.CheckOnClick = true;
            this.autoDownloadToolStripMenuItem.Name = "autoDownloadToolStripMenuItem";
            this.autoDownloadToolStripMenuItem.Size = new Size(0xc7, 0x16);
            this.autoDownloadToolStripMenuItem.Text = "Auto Download";
            this.autoDownloadToolStripMenuItem.Click += new EventHandler(this.autoDownloadToolStripMenuItem_Click);
            this.disableWebAlertContentToolStripMenuItem.CheckOnClick = true;
            this.disableWebAlertContentToolStripMenuItem.Name = "disableWebAlertContentToolStripMenuItem";
            this.disableWebAlertContentToolStripMenuItem.Size = new Size(0xc7, 0x16);
            this.disableWebAlertContentToolStripMenuItem.Text = "Disable Alerts";
            this.disableWebAlertContentToolStripMenuItem.Click += new EventHandler(this.disableWebAlertContentToolStripMenuItem_Click);
            this.rememberDSSceneInfoToolStripMenuItem.CheckOnClick = true;
            this.rememberDSSceneInfoToolStripMenuItem.Name = "rememberDSSceneInfoToolStripMenuItem";
            this.rememberDSSceneInfoToolStripMenuItem.Size = new Size(0xc7, 0x16);
            this.rememberDSSceneInfoToolStripMenuItem.Text = "Log Edited Rom CRCs";
            this.rememberDSSceneInfoToolStripMenuItem.Click += new EventHandler(this.rememberDSSceneInfoToolStripMenuItem_Click);
            ToolStripItem[] itemArray15 = new ToolStripItem[] { this.homeToolStripMenuItem, this.changeLogToolStripMenuItem };
            this.aboutToolStripMenuItem.DropDownItems.AddRange(itemArray15);
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new Size(0x34, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.homeToolStripMenuItem.Image = Resources.home1;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new Size(0x90, 0x16);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new EventHandler(this.homeToolStripMenuItem_Click);
            this.changeLogToolStripMenuItem.Image = Resources.version_info;
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new Size(0x90, 0x16);
            this.changeLogToolStripMenuItem.Text = "Version Info";
            this.changeLogToolStripMenuItem.Click += new EventHandler(this.changeLogToolStripMenuItem_Click);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(0x95, 6);
            this.txtHdrTitle.AutoSize = true;
            this.txtHdrTitle.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtHdrTitle.Location = new Point(0x13, 0x41);
            this.txtHdrTitle.Name = "txtHdrTitle";
            this.txtHdrTitle.Size = new Size(0x42, 13);
            this.txtHdrTitle.TabIndex = 3;
            this.txtHdrTitle.Text = "Game title";
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.Location = new Point(10, 0x58);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x4c, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Game serial";
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.Location = new Point(0x18, 0x6f);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x3d, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Card size";
            this.gameTitleText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.gameTitleText.Location = new Point(0x5b, 0x3d);
            this.gameTitleText.Name = "gameTitleText";
            this.gameTitleText.ReadOnly = true;
            this.gameTitleText.Size = new Size(0xcd, 20);
            this.gameTitleText.TabIndex = 9;
            this.gameCodeText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.gameCodeText.Location = new Point(0x5b, 0x54);
            this.gameCodeText.Name = "gameCodeText";
            this.gameCodeText.ReadOnly = true;
            this.gameCodeText.Size = new Size(0x72, 20);
            this.gameCodeText.TabIndex = 10;
            this.cardSizeText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cardSizeText.Location = new Point(0x5b, 0x6b);
            this.cardSizeText.Name = "cardSizeText";
            this.cardSizeText.ReadOnly = true;
            this.cardSizeText.Size = new Size(0xcd, 20);
            this.cardSizeText.TabIndex = 11;
            this.tabControlMain.Controls.Add(this.tabWebInfo);
            this.tabControlMain.Controls.Add(this.tabRomInfo);
            this.tabControlMain.Controls.Add(this.tabApPatch);
            this.tabControlMain.Controls.Add(this.tabExport);
            this.tabControlMain.Cursor = Cursors.Default;
            this.tabControlMain.ImageList = this.imageList1;
            this.tabControlMain.Location = new Point(4, 0x3a);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new Size(0x17f, 340);
            this.tabControlMain.TabIndex = 90;
            this.tabControlMain.GotFocus += new EventHandler(this.tabPage_Focus);
            this.tabWebInfo.Controls.Add(this.groupBox2);
            this.tabWebInfo.ImageIndex = 1;
            this.tabWebInfo.Location = new Point(4, 0x17);
            this.tabWebInfo.Name = "tabWebInfo";
            this.tabWebInfo.Padding = new Padding(4);
            this.tabWebInfo.Size = new Size(0x177, 0x139);
            this.tabWebInfo.TabIndex = 3;
            this.tabWebInfo.Text = "DS-Scene";
            this.tabWebInfo.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.picNinNetwork);
            this.groupBox2.Controls.Add(this.n3dsopt_5);
            this.groupBox2.Controls.Add(this.btnNFO);
            this.groupBox2.Controls.Add(this.n3dsopt_2);
            this.groupBox2.Controls.Add(this.n3dsopt_4);
            this.groupBox2.Controls.Add(this.n3dsopt_1);
            this.groupBox2.Controls.Add(this.n3dsopt_3);
            this.groupBox2.Controls.Add(this.n3dsopt_0);
            this.groupBox2.Controls.Add(this.launchEmulator);
            this.groupBox2.Controls.Add(this.cmpDbSupportBtn);
            this.groupBox2.Controls.Add(this.romTypeTxt);
            this.groupBox2.Controls.Add(this.webInfo_id);
            this.groupBox2.Controls.Add(this.buttonForumLink);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.webInfo_date);
            this.groupBox2.Controls.Add(this.webInfo_newsdate);
            this.groupBox2.Controls.Add(this.webInfo_wifi);
            this.groupBox2.Controls.Add(this.buttonRomInfo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.webInfo_dir);
            this.groupBox2.Controls.Add(this.webInfo_arc);
            this.groupBox2.Controls.Add(this.romIcon3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.webInfo_Boxart);
            this.groupBox2.Controls.Add(this.webInfo_save);
            this.groupBox2.Controls.Add(this.webInfo_number);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.webInfo_grp);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.webInfo_name);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.webInfo_rgn);
            this.groupBox2.Controls.Add(this.picDSCard);
            this.groupBox2.Controls.Add(this.pic3DSCard);
            this.groupBox2.Controls.Add(this.webInfo_dscompat);
            this.groupBox2.Location = new Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x16b, 0x131);
            this.groupBox2.TabIndex = 0x5d;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DS-Scene.net Info";
            this.picNinNetwork.Image = (Image) manager.GetObject("picNinNetwork.Image");
            this.picNinNetwork.Location = new Point(0xb9, 0x4f);
            this.picNinNetwork.Name = "picNinNetwork";
            this.picNinNetwork.Size = new Size(20, 20);
            this.picNinNetwork.TabIndex = 140;
            this.picNinNetwork.TabStop = false;
            this.picNinNetwork.Visible = false;
            this.n3dsopt_5.Location = new Point(0xa4, 0x3a);
            this.n3dsopt_5.Name = "n3dsopt_5";
            this.n3dsopt_5.Size = new Size(20, 20);
            this.n3dsopt_5.TabIndex = 0x8b;
            this.n3dsopt_5.TabStop = false;
            this.n3dsopt_5.Visible = false;
            this.btnNFO.Cursor = Cursors.Hand;
            this.btnNFO.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnNFO.Image = Resources.nfo_tiny;
            this.btnNFO.Location = new Point(0xff, 0xf7);
            this.btnNFO.Name = "btnNFO";
            this.btnNFO.Size = new Size(0x63, 30);
            this.btnNFO.TabIndex = 0x8a;
            this.btnNFO.Text = " View NFO File";
            this.btnNFO.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnNFO.UseVisualStyleBackColor = true;
            this.btnNFO.Click += new EventHandler(this.btnNFO_Click);
            this.n3dsopt_2.Location = new Point(0xb9, 0x3a);
            this.n3dsopt_2.Name = "n3dsopt_2";
            this.n3dsopt_2.Size = new Size(20, 20);
            this.n3dsopt_2.TabIndex = 0x89;
            this.n3dsopt_2.TabStop = false;
            this.n3dsopt_2.Visible = false;
            this.n3dsopt_4.Location = new Point(0xa4, 0x25);
            this.n3dsopt_4.Name = "n3dsopt_4";
            this.n3dsopt_4.Size = new Size(20, 20);
            this.n3dsopt_4.TabIndex = 0x88;
            this.n3dsopt_4.TabStop = false;
            this.n3dsopt_4.Visible = false;
            this.n3dsopt_1.Location = new Point(0xb9, 0x25);
            this.n3dsopt_1.Name = "n3dsopt_1";
            this.n3dsopt_1.Size = new Size(20, 20);
            this.n3dsopt_1.TabIndex = 0x87;
            this.n3dsopt_1.TabStop = false;
            this.n3dsopt_1.Visible = false;
            this.n3dsopt_3.Location = new Point(0xa4, 0x10);
            this.n3dsopt_3.Name = "n3dsopt_3";
            this.n3dsopt_3.Size = new Size(20, 20);
            this.n3dsopt_3.TabIndex = 0x86;
            this.n3dsopt_3.TabStop = false;
            this.n3dsopt_3.Visible = false;
            this.n3dsopt_0.Location = new Point(0xb9, 0x10);
            this.n3dsopt_0.Name = "n3dsopt_0";
            this.n3dsopt_0.Size = new Size(20, 20);
            this.n3dsopt_0.TabIndex = 0x85;
            this.n3dsopt_0.TabStop = false;
            this.n3dsopt_0.Visible = false;
            this.launchEmulator.Cursor = Cursors.Hand;
            this.launchEmulator.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.launchEmulator.Image = Resources.application_block;
            this.launchEmulator.Location = new Point(0xd1, 0x5e);
            this.launchEmulator.Name = "launchEmulator";
            this.launchEmulator.Size = new Size(150, 30);
            this.launchEmulator.TabIndex = 130;
            this.launchEmulator.Text = " Launch With Emulator";
            this.launchEmulator.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.launchEmulator.UseVisualStyleBackColor = true;
            this.launchEmulator.Click += new EventHandler(this.launchEmulator_Click);
            this.cmpDbSupportBtn.BackgroundImageLayout = ImageLayout.Center;
            this.cmpDbSupportBtn.Cursor = Cursors.Hand;
            this.cmpDbSupportBtn.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cmpDbSupportBtn.Image = Resources.crossicon;
            this.cmpDbSupportBtn.ImageAlign = ContentAlignment.MiddleLeft;
            this.cmpDbSupportBtn.Location = new Point(0xd1, 0x7c);
            this.cmpDbSupportBtn.Name = "cmpDbSupportBtn";
            this.cmpDbSupportBtn.Padding = new Padding(3, 0, 3, 0);
            this.cmpDbSupportBtn.Size = new Size(0x66, 30);
            this.cmpDbSupportBtn.TabIndex = 0x7f;
            this.cmpDbSupportBtn.Text = "CMP Support";
            this.cmpDbSupportBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.cmpDbSupportBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.cmpDbSupportBtn.UseVisualStyleBackColor = true;
            this.cmpDbSupportBtn.Click += new EventHandler(this.cmpDbSupportBtn_Click);
            this.romTypeTxt.BackColor = Color.LightGray;
            this.romTypeTxt.BorderStyle = BorderStyle.FixedSingle;
            this.romTypeTxt.Font = new Font("Verdana", 6.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.romTypeTxt.ForeColor = Color.DimGray;
            this.romTypeTxt.Location = new Point(210, 0x4a);
            this.romTypeTxt.Name = "romTypeTxt";
            this.romTypeTxt.Size = new Size(0x94, 0x10);
            this.romTypeTxt.TabIndex = 120;
            this.romTypeTxt.Text = "Not Loaded";
            this.romTypeTxt.TextAlign = ContentAlignment.TopCenter;
            this.webInfo_id.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.webInfo_id.Location = new Point(170, 0x9f);
            this.webInfo_id.Name = "webInfo_id";
            this.webInfo_id.ReadOnly = true;
            this.webInfo_id.Size = new Size(0x2d, 0x12);
            this.webInfo_id.TabIndex = 0x77;
            this.webInfo_id.Visible = false;
            this.buttonForumLink.BackgroundImageLayout = ImageLayout.Center;
            this.buttonForumLink.Cursor = Cursors.Hand;
            this.buttonForumLink.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.buttonForumLink.Image = Resources.internet_group_chat;
            this.buttonForumLink.Location = new Point(0x137, 0x7c);
            this.buttonForumLink.Name = "buttonForumLink";
            this.buttonForumLink.Size = new Size(0x18, 30);
            this.buttonForumLink.TabIndex = 0x76;
            this.buttonForumLink.UseVisualStyleBackColor = true;
            this.buttonForumLink.Click += new EventHandler(this.buttonForumLink_Click);
            this.label16.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label16.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label16.ForeColor = SystemColors.ControlDarkDark;
            this.label16.Location = new Point(0xcd, 12);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x99, 13);
            this.label16.TabIndex = 0x75;
            this.label16.Text = "DS-Scene Post Created On";
            this.label16.TextAlign = ContentAlignment.TopRight;
            this.label15.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label15.Font = new Font("Verdana", 6.75f, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.label15.ForeColor = SystemColors.ButtonShadow;
            this.label15.Location = new Point(0xd1, 0x26);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x95, 13);
            this.label15.TabIndex = 0x74;
            this.label15.Text = "Last Updated Info From Web";
            this.label15.TextAlign = ContentAlignment.TopRight;
            this.webInfo_date.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.webInfo_date.Font = new Font("Verdana", 6.75f, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.webInfo_date.ForeColor = SystemColors.ButtonShadow;
            this.webInfo_date.Location = new Point(0xd1, 0x34);
            this.webInfo_date.Name = "webInfo_date";
            this.webInfo_date.Size = new Size(0x95, 13);
            this.webInfo_date.TabIndex = 0x73;
            this.webInfo_date.Text = "never";
            this.webInfo_date.TextAlign = ContentAlignment.TopRight;
            this.webInfo_newsdate.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.webInfo_newsdate.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.webInfo_newsdate.ForeColor = SystemColors.ControlDarkDark;
            this.webInfo_newsdate.Location = new Point(0xd1, 0x19);
            this.webInfo_newsdate.Name = "webInfo_newsdate";
            this.webInfo_newsdate.Size = new Size(0x95, 13);
            this.webInfo_newsdate.TabIndex = 0x72;
            this.webInfo_newsdate.Text = "unknown";
            this.webInfo_newsdate.TextAlign = ContentAlignment.TopRight;
            this.webInfo_wifi.Image = Resources.wifi;
            this.webInfo_wifi.Location = new Point(160, 0x10);
            this.webInfo_wifi.Name = "webInfo_wifi";
            this.webInfo_wifi.Size = new Size(40, 40);
            this.webInfo_wifi.SizeMode = PictureBoxSizeMode.AutoSize;
            this.webInfo_wifi.TabIndex = 0x6f;
            this.webInfo_wifi.TabStop = false;
            this.webInfo_wifi.Visible = false;
            this.buttonRomInfo.BackColor = Color.Transparent;
            this.buttonRomInfo.BackgroundImageLayout = ImageLayout.Center;
            this.buttonRomInfo.Cursor = Cursors.Hand;
            this.buttonRomInfo.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.buttonRomInfo.Image = Resources.refresh_static;
            this.buttonRomInfo.Location = new Point(0x14f, 0x7c);
            this.buttonRomInfo.Name = "buttonRomInfo";
            this.buttonRomInfo.Size = new Size(0x18, 30);
            this.buttonRomInfo.TabIndex = 110;
            this.buttonRomInfo.UseVisualStyleBackColor = false;
            this.buttonRomInfo.Click += new EventHandler(this.buttonRomInfo_Click);
            this.label13.AutoSize = true;
            this.label13.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label13.Location = new Point(0x29, 0x11a);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x38, 12);
            this.label13.TabIndex = 0x6c;
            this.label13.Text = "Directory:";
            this.webInfo_dir.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.webInfo_dir.Location = new Point(0x63, 0x117);
            this.webInfo_dir.Name = "webInfo_dir";
            this.webInfo_dir.ReadOnly = true;
            this.webInfo_dir.Size = new Size(0xff, 0x12);
            this.webInfo_dir.TabIndex = 0x6d;
            this.webInfo_arc.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.webInfo_arc.Location = new Point(0x63, 0x103);
            this.webInfo_arc.Name = "webInfo_arc";
            this.webInfo_arc.ReadOnly = true;
            this.webInfo_arc.Size = new Size(100, 0x12);
            this.webInfo_arc.TabIndex = 0x6b;
            this.romIcon3.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.romIcon3.Image = Resources._0000;
            this.romIcon3.Location = new Point(0xa5, 0x6d);
            this.romIcon3.Name = "romIcon3";
            this.romIcon3.Size = new Size(0x20, 0x20);
            this.romIcon3.TabIndex = 0x5e;
            this.romIcon3.TabStop = false;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x11, 0x105);
            this.label12.Name = "label12";
            this.label12.Size = new Size(80, 12);
            this.label12.TabIndex = 0x6a;
            this.label12.Text = "Archive Name:";
            this.webInfo_Boxart.Image = Resources._00001;
            this.webInfo_Boxart.Location = new Point(6, 0x10);
            this.webInfo_Boxart.Name = "webInfo_Boxart";
            this.webInfo_Boxart.Size = new Size(150, 0x89);
            this.webInfo_Boxart.TabIndex = 0;
            this.webInfo_Boxart.TabStop = false;
            this.webInfo_save.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.webInfo_save.Location = new Point(0x63, 0xef);
            this.webInfo_save.Name = "webInfo_save";
            this.webInfo_save.ReadOnly = true;
            this.webInfo_save.Size = new Size(100, 0x12);
            this.webInfo_save.TabIndex = 0x69;
            this.webInfo_number.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.webInfo_number.Location = new Point(0x63, 0x9f);
            this.webInfo_number.Name = "webInfo_number";
            this.webInfo_number.ReadOnly = true;
            this.webInfo_number.Size = new Size(0x45, 0x12);
            this.webInfo_number.TabIndex = 0x62;
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label11.Location = new Point(0x23, 0xf2);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x3e, 12);
            this.label11.TabIndex = 0x68;
            this.label11.Text = "Save Type:";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(6, 0xa1);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x5b, 12);
            this.label5.TabIndex = 0x5f;
            this.label5.Text = "Release Number:";
            this.webInfo_grp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.webInfo_grp.Location = new Point(0x63, 0xdb);
            this.webInfo_grp.Name = "webInfo_grp";
            this.webInfo_grp.ReadOnly = true;
            this.webInfo_grp.Size = new Size(150, 0x12);
            this.webInfo_grp.TabIndex = 0x67;
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.Location = new Point(6, 0xb5);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x5b, 12);
            this.label7.TabIndex = 0x60;
            this.label7.Text = "Game Full Name:";
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label10.Location = new Point(15, 0xdd);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x52, 12);
            this.label10.TabIndex = 0x66;
            this.label10.Text = "Release Group:";
            this.webInfo_name.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.webInfo_name.Location = new Point(0x63, 0xb3);
            this.webInfo_name.Name = "webInfo_name";
            this.webInfo_name.ReadOnly = true;
            this.webInfo_name.Size = new Size(0xff, 0x12);
            this.webInfo_name.TabIndex = 0x63;
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.Location = new Point(0x16, 0xc9);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x4b, 12);
            this.label9.TabIndex = 100;
            this.label9.Text = "Game Region:";
            this.webInfo_rgn.Location = new Point(0x63, 0xc6);
            this.webInfo_rgn.MaximumSize = new Size(30, 20);
            this.webInfo_rgn.Name = "webInfo_rgn";
            this.webInfo_rgn.Size = new Size(30, 20);
            this.webInfo_rgn.SizeMode = PictureBoxSizeMode.CenterImage;
            this.webInfo_rgn.TabIndex = 0x71;
            this.webInfo_rgn.TabStop = false;
            this.picDSCard.Image = Resources.dscard;
            this.picDSCard.Location = new Point(0x9e, 0x65);
            this.picDSCard.Name = "picDSCard";
            this.picDSCard.Size = new Size(0x2e, 0x34);
            this.picDSCard.SizeMode = PictureBoxSizeMode.AutoSize;
            this.picDSCard.TabIndex = 0x84;
            this.picDSCard.TabStop = false;
            this.pic3DSCard.Image = Resources._3dscard;
            this.pic3DSCard.Location = new Point(0x9e, 0x65);
            this.pic3DSCard.Name = "pic3DSCard";
            this.pic3DSCard.Size = new Size(50, 0x31);
            this.pic3DSCard.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pic3DSCard.TabIndex = 0x83;
            this.pic3DSCard.TabStop = false;
            this.pic3DSCard.Visible = false;
            this.webInfo_dscompat.Image = Resources.dscompat;
            this.webInfo_dscompat.Location = new Point(160, 0x43);
            this.webInfo_dscompat.Name = "webInfo_dscompat";
            this.webInfo_dscompat.Size = new Size(40, 40);
            this.webInfo_dscompat.SizeMode = PictureBoxSizeMode.AutoSize;
            this.webInfo_dscompat.TabIndex = 0x70;
            this.webInfo_dscompat.TabStop = false;
            this.webInfo_dscompat.Visible = false;
            this.tabRomInfo.Controls.Add(this.btnHeaderRefresh);
            this.tabRomInfo.Controls.Add(this.iconEditorGroup);
            this.tabRomInfo.Controls.Add(this.makerNameText);
            this.tabRomInfo.Controls.Add(this.makerCodeText);
            this.tabRomInfo.Controls.Add(this.label4);
            this.tabRomInfo.Controls.Add(this.fileSizeText);
            this.tabRomInfo.Controls.Add(this.label2);
            this.tabRomInfo.Controls.Add(this.crc32Text);
            this.tabRomInfo.Controls.Add(this.label1);
            this.tabRomInfo.Controls.Add(this.tabControlLang);
            this.tabRomInfo.Controls.Add(this.txtHdrTitle);
            this.tabRomInfo.Controls.Add(this.cardSizeText);
            this.tabRomInfo.Controls.Add(this.gameCodeText);
            this.tabRomInfo.Controls.Add(this.gameTitleText);
            this.tabRomInfo.Controls.Add(this.label6);
            this.tabRomInfo.Controls.Add(this.label8);
            this.tabRomInfo.Controls.Add(this.buttonSaveIcon);
            this.tabRomInfo.Controls.Add(this.romIcon);
            this.tabRomInfo.ImageIndex = 0;
            this.tabRomInfo.Location = new Point(4, 0x17);
            this.tabRomInfo.Name = "tabRomInfo";
            this.tabRomInfo.Padding = new Padding(4);
            this.tabRomInfo.Size = new Size(0x177, 0x139);
            this.tabRomInfo.TabIndex = 0;
            this.tabRomInfo.Text = "Rom Info";
            this.tabRomInfo.UseVisualStyleBackColor = true;
            this.btnHeaderRefresh.BackColor = Color.Transparent;
            this.btnHeaderRefresh.BackgroundImageLayout = ImageLayout.Center;
            this.btnHeaderRefresh.Cursor = Cursors.Hand;
            this.btnHeaderRefresh.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnHeaderRefresh.Image = Resources.refresh_static;
            this.btnHeaderRefresh.Location = new Point(0x14e, 0xa6);
            this.btnHeaderRefresh.Name = "btnHeaderRefresh";
            this.btnHeaderRefresh.Size = new Size(0x18, 30);
            this.btnHeaderRefresh.TabIndex = 0x6f;
            this.btnHeaderRefresh.UseVisualStyleBackColor = false;
            this.btnHeaderRefresh.Click += new EventHandler(this.btnHeaderRefresh_Click);
            this.iconEditorGroup.Controls.Add(this.picPal_15);
            this.iconEditorGroup.Controls.Add(this.picPal_14);
            this.iconEditorGroup.Controls.Add(this.picPal_13);
            this.iconEditorGroup.Controls.Add(this.picPal_12);
            this.iconEditorGroup.Controls.Add(this.picPal_7);
            this.iconEditorGroup.Controls.Add(this.picPal_6);
            this.iconEditorGroup.Controls.Add(this.picPal_5);
            this.iconEditorGroup.Controls.Add(this.picPal_4);
            this.iconEditorGroup.Controls.Add(this.picPal_11);
            this.iconEditorGroup.Controls.Add(this.picPal_10);
            this.iconEditorGroup.Controls.Add(this.picPal_9);
            this.iconEditorGroup.Controls.Add(this.picPal_8);
            this.iconEditorGroup.Controls.Add(this.picPal_3);
            this.iconEditorGroup.Controls.Add(this.picPal_2);
            this.iconEditorGroup.Controls.Add(this.picPal_1);
            this.iconEditorGroup.Controls.Add(this.picPal_0);
            this.iconEditorGroup.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.iconEditorGroup.Location = new Point(0x5b, 5);
            this.iconEditorGroup.Name = "iconEditorGroup";
            this.iconEditorGroup.Size = new Size(0x98, 0x34);
            this.iconEditorGroup.TabIndex = 0x5e;
            this.iconEditorGroup.TabStop = false;
            this.iconEditorGroup.Text = "Icon Transparencies";
            this.picPal_15.Appearance = Appearance.Button;
            this.picPal_15.AutoSize = true;
            this.picPal_15.BackColor = Color.WhiteSmoke;
            this.picPal_15.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_15.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_15.Cursor = Cursors.Hand;
            this.picPal_15.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_15.Location = new Point(0x80, 30);
            this.picPal_15.MaximumSize = new Size(0x10, 0x10);
            this.picPal_15.MinimumSize = new Size(0x10, 0x10);
            this.picPal_15.Name = "picPal_15";
            this.picPal_15.Size = new Size(0x10, 0x10);
            this.picPal_15.TabIndex = 15;
            this.picPal_15.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_15.UseVisualStyleBackColor = false;
            this.picPal_15.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_14.Appearance = Appearance.Button;
            this.picPal_14.AutoSize = true;
            this.picPal_14.BackColor = Color.WhiteSmoke;
            this.picPal_14.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_14.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_14.Cursor = Cursors.Hand;
            this.picPal_14.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_14.Location = new Point(0x6f, 30);
            this.picPal_14.MaximumSize = new Size(0x10, 0x10);
            this.picPal_14.MinimumSize = new Size(0x10, 0x10);
            this.picPal_14.Name = "picPal_14";
            this.picPal_14.Size = new Size(0x10, 0x10);
            this.picPal_14.TabIndex = 14;
            this.picPal_14.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_14.UseVisualStyleBackColor = false;
            this.picPal_14.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_13.Appearance = Appearance.Button;
            this.picPal_13.AutoSize = true;
            this.picPal_13.BackColor = Color.WhiteSmoke;
            this.picPal_13.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_13.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_13.Cursor = Cursors.Hand;
            this.picPal_13.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_13.Location = new Point(0x5e, 30);
            this.picPal_13.MaximumSize = new Size(0x10, 0x10);
            this.picPal_13.MinimumSize = new Size(0x10, 0x10);
            this.picPal_13.Name = "picPal_13";
            this.picPal_13.Size = new Size(0x10, 0x10);
            this.picPal_13.TabIndex = 13;
            this.picPal_13.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_13.UseVisualStyleBackColor = false;
            this.picPal_13.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_12.Appearance = Appearance.Button;
            this.picPal_12.AutoSize = true;
            this.picPal_12.BackColor = Color.WhiteSmoke;
            this.picPal_12.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_12.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_12.Cursor = Cursors.Hand;
            this.picPal_12.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_12.Location = new Point(0x4d, 30);
            this.picPal_12.MaximumSize = new Size(0x10, 0x10);
            this.picPal_12.MinimumSize = new Size(0x10, 0x10);
            this.picPal_12.Name = "picPal_12";
            this.picPal_12.Size = new Size(0x10, 0x10);
            this.picPal_12.TabIndex = 12;
            this.picPal_12.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_12.UseVisualStyleBackColor = false;
            this.picPal_12.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_7.Appearance = Appearance.Button;
            this.picPal_7.AutoSize = true;
            this.picPal_7.BackColor = Color.WhiteSmoke;
            this.picPal_7.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_7.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_7.Cursor = Cursors.Hand;
            this.picPal_7.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_7.Location = new Point(0x80, 13);
            this.picPal_7.MaximumSize = new Size(0x10, 0x10);
            this.picPal_7.MinimumSize = new Size(0x10, 0x10);
            this.picPal_7.Name = "picPal_7";
            this.picPal_7.Size = new Size(0x10, 0x10);
            this.picPal_7.TabIndex = 11;
            this.picPal_7.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_7.UseVisualStyleBackColor = false;
            this.picPal_7.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_6.Appearance = Appearance.Button;
            this.picPal_6.AutoSize = true;
            this.picPal_6.BackColor = Color.WhiteSmoke;
            this.picPal_6.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_6.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_6.Cursor = Cursors.Hand;
            this.picPal_6.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_6.Location = new Point(0x6f, 13);
            this.picPal_6.MaximumSize = new Size(0x10, 0x10);
            this.picPal_6.MinimumSize = new Size(0x10, 0x10);
            this.picPal_6.Name = "picPal_6";
            this.picPal_6.Size = new Size(0x10, 0x10);
            this.picPal_6.TabIndex = 10;
            this.picPal_6.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_6.UseVisualStyleBackColor = false;
            this.picPal_6.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_5.Appearance = Appearance.Button;
            this.picPal_5.AutoSize = true;
            this.picPal_5.BackColor = Color.WhiteSmoke;
            this.picPal_5.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_5.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_5.Cursor = Cursors.Hand;
            this.picPal_5.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_5.Location = new Point(0x5e, 13);
            this.picPal_5.MaximumSize = new Size(0x10, 0x10);
            this.picPal_5.MinimumSize = new Size(0x10, 0x10);
            this.picPal_5.Name = "picPal_5";
            this.picPal_5.Size = new Size(0x10, 0x10);
            this.picPal_5.TabIndex = 9;
            this.picPal_5.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_5.UseVisualStyleBackColor = false;
            this.picPal_5.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_4.Appearance = Appearance.Button;
            this.picPal_4.AutoSize = true;
            this.picPal_4.BackColor = Color.WhiteSmoke;
            this.picPal_4.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_4.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_4.Cursor = Cursors.Hand;
            this.picPal_4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_4.Location = new Point(0x4d, 13);
            this.picPal_4.MaximumSize = new Size(0x10, 0x10);
            this.picPal_4.MinimumSize = new Size(0x10, 0x10);
            this.picPal_4.Name = "picPal_4";
            this.picPal_4.Size = new Size(0x10, 0x10);
            this.picPal_4.TabIndex = 8;
            this.picPal_4.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_4.UseVisualStyleBackColor = false;
            this.picPal_4.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_11.Appearance = Appearance.Button;
            this.picPal_11.AutoSize = true;
            this.picPal_11.BackColor = Color.WhiteSmoke;
            this.picPal_11.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_11.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_11.Cursor = Cursors.Hand;
            this.picPal_11.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_11.Location = new Point(60, 30);
            this.picPal_11.MaximumSize = new Size(0x10, 0x10);
            this.picPal_11.MinimumSize = new Size(0x10, 0x10);
            this.picPal_11.Name = "picPal_11";
            this.picPal_11.Size = new Size(0x10, 0x10);
            this.picPal_11.TabIndex = 7;
            this.picPal_11.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_11.UseVisualStyleBackColor = false;
            this.picPal_11.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_10.Appearance = Appearance.Button;
            this.picPal_10.AutoSize = true;
            this.picPal_10.BackColor = Color.WhiteSmoke;
            this.picPal_10.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_10.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_10.Cursor = Cursors.Hand;
            this.picPal_10.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_10.Location = new Point(0x2b, 30);
            this.picPal_10.MaximumSize = new Size(0x10, 0x10);
            this.picPal_10.MinimumSize = new Size(0x10, 0x10);
            this.picPal_10.Name = "picPal_10";
            this.picPal_10.Size = new Size(0x10, 0x10);
            this.picPal_10.TabIndex = 6;
            this.picPal_10.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_10.UseVisualStyleBackColor = false;
            this.picPal_10.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_9.Appearance = Appearance.Button;
            this.picPal_9.AutoSize = true;
            this.picPal_9.BackColor = Color.WhiteSmoke;
            this.picPal_9.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_9.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_9.Cursor = Cursors.Hand;
            this.picPal_9.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_9.Location = new Point(0x19, 30);
            this.picPal_9.MaximumSize = new Size(0x10, 0x10);
            this.picPal_9.MinimumSize = new Size(0x10, 0x10);
            this.picPal_9.Name = "picPal_9";
            this.picPal_9.Size = new Size(0x10, 0x10);
            this.picPal_9.TabIndex = 5;
            this.picPal_9.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_9.UseVisualStyleBackColor = false;
            this.picPal_9.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_8.Appearance = Appearance.Button;
            this.picPal_8.AutoSize = true;
            this.picPal_8.BackColor = Color.WhiteSmoke;
            this.picPal_8.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_8.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_8.Cursor = Cursors.Hand;
            this.picPal_8.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_8.Location = new Point(7, 30);
            this.picPal_8.MaximumSize = new Size(0x10, 0x10);
            this.picPal_8.MinimumSize = new Size(0x10, 0x10);
            this.picPal_8.Name = "picPal_8";
            this.picPal_8.Size = new Size(0x10, 0x10);
            this.picPal_8.TabIndex = 4;
            this.picPal_8.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_8.UseVisualStyleBackColor = false;
            this.picPal_8.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_3.Appearance = Appearance.Button;
            this.picPal_3.AutoSize = true;
            this.picPal_3.BackColor = Color.WhiteSmoke;
            this.picPal_3.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_3.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_3.Cursor = Cursors.Hand;
            this.picPal_3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_3.Location = new Point(60, 13);
            this.picPal_3.MaximumSize = new Size(0x10, 0x10);
            this.picPal_3.MinimumSize = new Size(0x10, 0x10);
            this.picPal_3.Name = "picPal_3";
            this.picPal_3.Size = new Size(0x10, 0x10);
            this.picPal_3.TabIndex = 3;
            this.picPal_3.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_3.UseVisualStyleBackColor = false;
            this.picPal_3.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_2.Appearance = Appearance.Button;
            this.picPal_2.AutoSize = true;
            this.picPal_2.BackColor = Color.WhiteSmoke;
            this.picPal_2.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_2.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_2.Cursor = Cursors.Hand;
            this.picPal_2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_2.Location = new Point(0x2b, 13);
            this.picPal_2.MaximumSize = new Size(0x10, 0x10);
            this.picPal_2.MinimumSize = new Size(0x10, 0x10);
            this.picPal_2.Name = "picPal_2";
            this.picPal_2.Size = new Size(0x10, 0x10);
            this.picPal_2.TabIndex = 2;
            this.picPal_2.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_2.UseVisualStyleBackColor = false;
            this.picPal_2.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_1.Appearance = Appearance.Button;
            this.picPal_1.AutoSize = true;
            this.picPal_1.BackColor = Color.WhiteSmoke;
            this.picPal_1.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_1.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_1.Cursor = Cursors.Hand;
            this.picPal_1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_1.Location = new Point(0x19, 13);
            this.picPal_1.MaximumSize = new Size(0x10, 0x10);
            this.picPal_1.MinimumSize = new Size(0x10, 0x10);
            this.picPal_1.Name = "picPal_1";
            this.picPal_1.Size = new Size(0x10, 0x10);
            this.picPal_1.TabIndex = 1;
            this.picPal_1.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_1.UseVisualStyleBackColor = false;
            this.picPal_1.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.picPal_0.Appearance = Appearance.Button;
            this.picPal_0.AutoSize = true;
            this.picPal_0.BackColor = Color.WhiteSmoke;
            this.picPal_0.BackgroundImageLayout = ImageLayout.Stretch;
            this.picPal_0.CheckAlign = ContentAlignment.MiddleCenter;
            this.picPal_0.Cursor = Cursors.Hand;
            this.picPal_0.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.picPal_0.Location = new Point(7, 13);
            this.picPal_0.MaximumSize = new Size(0x10, 0x10);
            this.picPal_0.MinimumSize = new Size(0x10, 0x10);
            this.picPal_0.Name = "picPal_0";
            this.picPal_0.Size = new Size(0x10, 0x10);
            this.picPal_0.TabIndex = 0;
            this.picPal_0.TextAlign = ContentAlignment.MiddleCenter;
            this.picPal_0.UseVisualStyleBackColor = false;
            this.picPal_0.CheckedChanged += new EventHandler(this.checkBoxTrans_CheckedChanged);
            this.makerNameText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.makerNameText.Location = new Point(0x7a, 0xb0);
            this.makerNameText.Name = "makerNameText";
            this.makerNameText.ReadOnly = true;
            this.makerNameText.Size = new Size(0xab, 20);
            this.makerNameText.TabIndex = 0x5d;
            this.makerCodeText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.makerCodeText.Location = new Point(0x5b, 0xb0);
            this.makerCodeText.Name = "makerCodeText";
            this.makerCodeText.ReadOnly = true;
            this.makerCodeText.Size = new Size(0x1c, 20);
            this.makerCodeText.TabIndex = 0x5c;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x2b, 180);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2a, 13);
            this.label4.TabIndex = 0x5b;
            this.label4.Text = "Maker";
            this.fileSizeText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.fileSizeText.Location = new Point(0x5b, 130);
            this.fileSizeText.Name = "fileSizeText";
            this.fileSizeText.ReadOnly = true;
            this.fileSizeText.Size = new Size(0xcd, 20);
            this.fileSizeText.TabIndex = 90;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x21, 0x86);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x34, 13);
            this.label2.TabIndex = 0x59;
            this.label2.Text = "File size";
            this.crc32Text.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.crc32Text.Location = new Point(0x5b, 0x99);
            this.crc32Text.Name = "crc32Text";
            this.crc32Text.ReadOnly = true;
            this.crc32Text.Size = new Size(0x72, 20);
            this.crc32Text.TabIndex = 0x10;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x26, 0x9d);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2f, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "CRC32";
            this.tabControlLang.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.tabControlLang.Controls.Add(this.tabLangJpn);
            this.tabControlLang.Controls.Add(this.tabLangEng);
            this.tabControlLang.Controls.Add(this.tabLangFre);
            this.tabControlLang.Controls.Add(this.tabLangGer);
            this.tabControlLang.Controls.Add(this.tabLangIta);
            this.tabControlLang.Controls.Add(this.tabLangSpa);
            this.tabControlLang.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabControlLang.Location = new Point(0x11, 0xcd);
            this.tabControlLang.Name = "tabControlLang";
            this.tabControlLang.SelectedIndex = 0;
            this.tabControlLang.Size = new Size(0x155, 100);
            this.tabControlLang.TabIndex = 14;
            this.tabLangJpn.Controls.Add(this.name_jpnText);
            this.tabLangJpn.Location = new Point(4, 0x15);
            this.tabLangJpn.Name = "tabLangJpn";
            this.tabLangJpn.Padding = new Padding(3);
            this.tabLangJpn.Size = new Size(0x14d, 0x4b);
            this.tabLangJpn.TabIndex = 0;
            this.tabLangJpn.Text = "Japanese";
            this.tabLangJpn.UseVisualStyleBackColor = true;
            this.name_jpnText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.name_jpnText.Location = new Point(2, 3);
            this.name_jpnText.Name = "name_jpnText";
            this.name_jpnText.ReadOnly = true;
            this.name_jpnText.Size = new Size(0x148, 0x45);
            this.name_jpnText.TabIndex = 14;
            this.name_jpnText.Text = "";
            this.tabLangEng.Controls.Add(this.name_engText);
            this.tabLangEng.Location = new Point(4, 0x15);
            this.tabLangEng.Name = "tabLangEng";
            this.tabLangEng.Padding = new Padding(3);
            this.tabLangEng.Size = new Size(0x14d, 0x4b);
            this.tabLangEng.TabIndex = 1;
            this.tabLangEng.Text = "English";
            this.tabLangEng.UseVisualStyleBackColor = true;
            this.name_engText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.name_engText.Location = new Point(2, 3);
            this.name_engText.Name = "name_engText";
            this.name_engText.ReadOnly = true;
            this.name_engText.Size = new Size(0x148, 0x45);
            this.name_engText.TabIndex = 15;
            this.name_engText.Text = "";
            this.tabLangFre.Controls.Add(this.name_freText);
            this.tabLangFre.Location = new Point(4, 0x15);
            this.tabLangFre.Name = "tabLangFre";
            this.tabLangFre.Size = new Size(0x14d, 0x4b);
            this.tabLangFre.TabIndex = 2;
            this.tabLangFre.Text = "French";
            this.tabLangFre.UseVisualStyleBackColor = true;
            this.name_freText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.name_freText.Location = new Point(2, 3);
            this.name_freText.Name = "name_freText";
            this.name_freText.ReadOnly = true;
            this.name_freText.Size = new Size(0x148, 0x45);
            this.name_freText.TabIndex = 14;
            this.name_freText.Text = "";
            this.tabLangGer.Controls.Add(this.name_gerText);
            this.tabLangGer.Location = new Point(4, 0x15);
            this.tabLangGer.Name = "tabLangGer";
            this.tabLangGer.Size = new Size(0x14d, 0x4b);
            this.tabLangGer.TabIndex = 3;
            this.tabLangGer.Text = "German";
            this.tabLangGer.UseVisualStyleBackColor = true;
            this.name_gerText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.name_gerText.Location = new Point(2, 3);
            this.name_gerText.Name = "name_gerText";
            this.name_gerText.ReadOnly = true;
            this.name_gerText.Size = new Size(0x148, 0x45);
            this.name_gerText.TabIndex = 14;
            this.name_gerText.Text = "";
            this.tabLangIta.Controls.Add(this.name_itaText);
            this.tabLangIta.Location = new Point(4, 0x15);
            this.tabLangIta.Name = "tabLangIta";
            this.tabLangIta.Size = new Size(0x14d, 0x4b);
            this.tabLangIta.TabIndex = 4;
            this.tabLangIta.Text = "Italian";
            this.tabLangIta.UseVisualStyleBackColor = true;
            this.name_itaText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.name_itaText.Location = new Point(2, 3);
            this.name_itaText.Name = "name_itaText";
            this.name_itaText.ReadOnly = true;
            this.name_itaText.Size = new Size(0x148, 0x45);
            this.name_itaText.TabIndex = 14;
            this.name_itaText.Text = "";
            this.tabLangSpa.Controls.Add(this.name_spaText);
            this.tabLangSpa.Location = new Point(4, 0x15);
            this.tabLangSpa.Name = "tabLangSpa";
            this.tabLangSpa.Size = new Size(0x14d, 0x4b);
            this.tabLangSpa.TabIndex = 5;
            this.tabLangSpa.Text = "Spanish";
            this.tabLangSpa.UseVisualStyleBackColor = true;
            this.name_spaText.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.name_spaText.Location = new Point(2, 3);
            this.name_spaText.Name = "name_spaText";
            this.name_spaText.ReadOnly = true;
            this.name_spaText.Size = new Size(0x148, 0x45);
            this.name_spaText.TabIndex = 14;
            this.name_spaText.Text = "";
            this.buttonSaveIcon.BackgroundImageLayout = ImageLayout.Center;
            this.buttonSaveIcon.Cursor = Cursors.Hand;
            this.buttonSaveIcon.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.buttonSaveIcon.Image = Resources.save_icon;
            this.buttonSaveIcon.ImageAlign = ContentAlignment.MiddleLeft;
            this.buttonSaveIcon.Location = new Point(0xf7, 0x13);
            this.buttonSaveIcon.Name = "buttonSaveIcon";
            this.buttonSaveIcon.Padding = new Padding(3, 0, 3, 0);
            this.buttonSaveIcon.Size = new Size(0x59, 30);
            this.buttonSaveIcon.TabIndex = 0x11;
            this.buttonSaveIcon.Text = " Save Icon";
            this.buttonSaveIcon.TextAlign = ContentAlignment.MiddleLeft;
            this.buttonSaveIcon.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.buttonSaveIcon.UseVisualStyleBackColor = true;
            this.buttonSaveIcon.Click += new EventHandler(this.buttonSaveIcon_Click);
            this.romIcon.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.romIcon.Image = Resources._0000;
            this.romIcon.Location = new Point(0x2d, 0x12);
            this.romIcon.Name = "romIcon";
            this.romIcon.Size = new Size(0x20, 0x20);
            this.romIcon.TabIndex = 1;
            this.romIcon.TabStop = false;
            this.tabApPatch.Controls.Add(this.btnImportAP);
            this.tabApPatch.Controls.Add(this.btnExportAP);
            this.tabApPatch.Controls.Add(this.label14);
            this.tabApPatch.Controls.Add(this.patchCreatorText);
            this.tabApPatch.Controls.Add(this.patchNameText);
            this.tabApPatch.Controls.Add(this.dbGamesText);
            this.tabApPatch.Controls.Add(this.apPatchInfoGrp);
            this.tabApPatch.Controls.Add(this.romIcon2);
            this.tabApPatch.ImageIndex = 2;
            this.tabApPatch.Location = new Point(4, 0x17);
            this.tabApPatch.Name = "tabApPatch";
            this.tabApPatch.Padding = new Padding(4);
            this.tabApPatch.Size = new Size(0x177, 0x139);
            this.tabApPatch.TabIndex = 1;
            this.tabApPatch.Text = "AP Patch";
            this.tabApPatch.UseVisualStyleBackColor = true;
            this.btnImportAP.BackgroundImageLayout = ImageLayout.Center;
            this.btnImportAP.Cursor = Cursors.Hand;
            this.btnImportAP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnImportAP.Image = Resources.database_import;
            this.btnImportAP.Location = new Point(320, 0x19);
            this.btnImportAP.Name = "btnImportAP";
            this.btnImportAP.Size = new Size(0x18, 30);
            this.btnImportAP.TabIndex = 0x60;
            this.btnImportAP.Tag = "Import AP Patch";
            this.btnImportAP.UseVisualStyleBackColor = true;
            this.btnImportAP.Click += new EventHandler(this.btnImportAP_Click);
            this.btnExportAP.BackgroundImageLayout = ImageLayout.Center;
            this.btnExportAP.Cursor = Cursors.Hand;
            this.btnExportAP.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnExportAP.Image = Resources.database_export;
            this.btnExportAP.Location = new Point(0x158, 0x19);
            this.btnExportAP.Name = "btnExportAP";
            this.btnExportAP.Size = new Size(0x18, 30);
            this.btnExportAP.TabIndex = 0x5f;
            this.btnExportAP.Tag = "Export AP Patch";
            this.btnExportAP.UseVisualStyleBackColor = true;
            this.btnExportAP.Click += new EventHandler(this.btnExportAP_Click);
            this.label14.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.label14.AutoSize = true;
            this.label14.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label14.Location = new Point(0xe1, 0x126);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x98, 12);
            this.label14.TabIndex = 0x5d;
            this.label14.Text = "Maintained by RetroGameFan";
            this.patchCreatorText.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.patchCreatorText.Location = new Point(0x2f, 0x19);
            this.patchCreatorText.Name = "patchCreatorText";
            this.patchCreatorText.Size = new Size(0xe0, 13);
            this.patchCreatorText.TabIndex = 0x5b;
            this.patchNameText.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.patchNameText.Location = new Point(0x2f, 11);
            this.patchNameText.Name = "patchNameText";
            this.patchNameText.Size = new Size(0xe0, 13);
            this.patchNameText.TabIndex = 0x54;
            this.patchNameText.Text = "No File Loaded";
            this.apPatchInfoGrp.Controls.Add(this.patchInfoText);
            this.apPatchInfoGrp.Location = new Point(6, 0x31);
            this.apPatchInfoGrp.Name = "apPatchInfoGrp";
            this.apPatchInfoGrp.Size = new Size(0x16b, 0xf4);
            this.apPatchInfoGrp.TabIndex = 0x59;
            this.apPatchInfoGrp.TabStop = false;
            this.apPatchInfoGrp.Text = "AP Patch Info";
            this.patchInfoText.Location = new Point(9, 0x11);
            this.patchInfoText.Name = "patchInfoText";
            this.patchInfoText.ReadOnly = true;
            this.patchInfoText.Size = new Size(0x15b, 0xda);
            this.patchInfoText.TabIndex = 0x54;
            this.patchInfoText.Text = "No File Loaded";
            this.patchInfoText.WordWrap = false;
            this.romIcon2.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.romIcon2.Image = Resources._0000;
            this.romIcon2.Location = new Point(8, 12);
            this.romIcon2.Name = "romIcon2";
            this.romIcon2.Size = new Size(0x20, 0x20);
            this.romIcon2.TabIndex = 90;
            this.romIcon2.TabStop = false;
            this.tabExport.Controls.Add(this.groupBox5);
            this.tabExport.Controls.Add(this.groupBox4);
            this.tabExport.Controls.Add(this.groupBox1);
            this.tabExport.Controls.Add(this.buttonApply);
            this.tabExport.ImageIndex = 4;
            this.tabExport.Location = new Point(4, 0x17);
            this.tabExport.Name = "tabExport";
            this.tabExport.Padding = new Padding(4);
            this.tabExport.Size = new Size(0x177, 0x139);
            this.tabExport.TabIndex = 2;
            this.tabExport.Text = "Export";
            this.tabExport.UseVisualStyleBackColor = true;
            this.groupBox5.Controls.Add(this.checkBoxDelete);
            this.groupBox5.Controls.Add(this.compressionSelect);
            this.groupBox5.Location = new Point(4, 0x55);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x16f, 0x43);
            this.groupBox5.TabIndex = 0x6d;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Repack Options";
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Cursor = Cursors.Hand;
            this.checkBoxDelete.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxDelete.Location = new Point(12, 0x2c);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new Size(0x90, 0x10);
            this.checkBoxDelete.TabIndex = 0x63;
            this.checkBoxDelete.Text = "Delete files after repack";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            this.compressionSelect.Cursor = Cursors.Hand;
            this.compressionSelect.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.compressionSelect.FormattingEnabled = true;
            object[] items = new object[] { "No Repack (.nds | .3ds)", "7-Zip (.7z)", "WinZip (.zip)" };
            this.compressionSelect.Items.AddRange(items);
            this.compressionSelect.Location = new Point(12, 20);
            this.compressionSelect.Name = "compressionSelect";
            this.compressionSelect.Size = new Size(0x99, 20);
            this.compressionSelect.TabIndex = 0x61;
            this.compressionSelect.SelectedIndexChanged += new EventHandler(this.compressionSelect_SelectedIndexChanged);
            this.groupBox4.Controls.Add(this.radioAccurateTrim);
            this.groupBox4.Controls.Add(this.checkBoxTrim);
            this.groupBox4.Controls.Add(this.radioSafeTrim);
            this.groupBox4.Location = new Point(0xaf, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xc4, 0x48);
            this.groupBox4.TabIndex = 0x6c;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trim Options";
            this.radioAccurateTrim.AutoSize = true;
            this.radioAccurateTrim.Cursor = Cursors.Hand;
            this.radioAccurateTrim.Enabled = false;
            this.radioAccurateTrim.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioAccurateTrim.Location = new Point(0x5d, 0x2a);
            this.radioAccurateTrim.Name = "radioAccurateTrim";
            this.radioAccurateTrim.Size = new Size(0x5f, 0x10);
            this.radioAccurateTrim.TabIndex = 0x65;
            this.radioAccurateTrim.Text = "Accurate Trim";
            this.radioAccurateTrim.UseVisualStyleBackColor = true;
            this.checkBoxTrim.AutoSize = true;
            this.checkBoxTrim.Cursor = Cursors.Hand;
            this.checkBoxTrim.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxTrim.Location = new Point(12, 20);
            this.checkBoxTrim.Name = "checkBoxTrim";
            this.checkBoxTrim.Size = new Size(0x5c, 0x10);
            this.checkBoxTrim.TabIndex = 0x58;
            this.checkBoxTrim.Text = "Trim Garbage";
            this.checkBoxTrim.UseVisualStyleBackColor = true;
            this.checkBoxTrim.CheckedChanged += new EventHandler(this.checkBoxTrim_CheckedChanged);
            this.radioSafeTrim.AutoSize = true;
            this.radioSafeTrim.Cursor = Cursors.Hand;
            this.radioSafeTrim.Enabled = false;
            this.radioSafeTrim.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioSafeTrim.Location = new Point(12, 0x2a);
            this.radioSafeTrim.Name = "radioSafeTrim";
            this.radioSafeTrim.Size = new Size(0x47, 0x10);
            this.radioSafeTrim.TabIndex = 100;
            this.radioSafeTrim.Text = "Safe Trim";
            this.radioSafeTrim.UseVisualStyleBackColor = true;
            this.groupBox1.Controls.Add(this.checkBoxApPatch);
            this.groupBox1.Location = new Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xa6, 0x48);
            this.groupBox1.TabIndex = 0x6b;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patch Options";
            this.checkBoxApPatch.AutoSize = true;
            this.checkBoxApPatch.Cursor = Cursors.Hand;
            this.checkBoxApPatch.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxApPatch.Location = new Point(0x12, 20);
            this.checkBoxApPatch.Name = "checkBoxApPatch";
            this.checkBoxApPatch.Size = new Size(0x67, 0x10);
            this.checkBoxApPatch.TabIndex = 0x59;
            this.checkBoxApPatch.Text = "Apply AP Patch";
            this.checkBoxApPatch.UseVisualStyleBackColor = true;
            this.buttonApply.BackgroundImageLayout = ImageLayout.Center;
            this.buttonApply.Cursor = Cursors.Hand;
            this.buttonApply.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.buttonApply.Image = Resources.save_icon;
            this.buttonApply.ImageAlign = ContentAlignment.MiddleLeft;
            this.buttonApply.Location = new Point(3, 0x9e);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Padding = new Padding(3, 0, 3, 0);
            this.buttonApply.Size = new Size(0x68, 30);
            this.buttonApply.TabIndex = 0x5c;
            this.buttonApply.Text = " Export Rom";
            this.buttonApply.TextAlign = ContentAlignment.MiddleLeft;
            this.buttonApply.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new EventHandler(this.buttonApply_Click);
            this.imageList1.ImageStream = (ImageListStreamer) manager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "rominfo.png");
            this.imageList1.Images.SetKeyName(1, "favicon.gif");
            this.imageList1.Images.SetKeyName(2, "cross-icon.png");
            this.imageList1.Images.SetKeyName(3, "Check-icon.png");
            this.imageList1.Images.SetKeyName(4, "extract_archive.png");
            this.toolStripProgressBar.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.toolStripProgressBar.Location = new Point(0x125, 2);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new Size(0x6d, 0x10);
            this.toolStripProgressBar.TabIndex = 0x5b;
            this.toolStripStatusLabel.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.toolStripStatusLabel.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.toolStripStatusLabel.Location = new Point(0x16, 3);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.RightToLeft = RightToLeft.No;
            this.toolStripStatusLabel.Size = new Size(0x10b, 13);
            this.toolStripStatusLabel.TabIndex = 0x5c;
            this.toolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            this.tesToolStripMenuItem.Name = "tesToolStripMenuItem";
            this.tesToolStripMenuItem.Size = new Size(0x24, 20);
            this.tesToolStripMenuItem.Text = "tes";
            this.panel1.BackColor = SystemColors.Control;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.toolStripStatusLabel);
            this.panel1.Controls.Add(this.toolStripProgressBar);
            this.panel1.Location = new Point(-17, 0x19f);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x19f, 0x25);
            this.panel1.TabIndex = 0x5d;
            base.AutoScaleDimensions = new SizeF(7f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            base.ClientSize = new Size(390, 0x1b4);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.tabControlMain);
            base.Controls.Add(this.appUrlFooter);
            base.Controls.Add(this.txtFooterText);
            base.Controls.Add(this.txtFileLoc);
            base.Controls.Add(this.btnBrowse);
            base.Controls.Add(this.menuStrip1);
            this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new Size(0x196, 0x1da);
            this.MinimumSize = new Size(0x196, 0x1da);
            base.Name = "apPatcherAppForm";
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Form1";
            base.FormClosing += new FormClosingEventHandler(this.Form_FormClosing);
            base.Load += new EventHandler(this.apPatcherApp_Load);
            base.Shown += new EventHandler(this.apPatcherAppForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabWebInfo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize) this.picNinNetwork).EndInit();
            ((ISupportInitialize) this.n3dsopt_5).EndInit();
            ((ISupportInitialize) this.n3dsopt_2).EndInit();
            ((ISupportInitialize) this.n3dsopt_4).EndInit();
            ((ISupportInitialize) this.n3dsopt_1).EndInit();
            ((ISupportInitialize) this.n3dsopt_3).EndInit();
            ((ISupportInitialize) this.n3dsopt_0).EndInit();
            ((ISupportInitialize) this.webInfo_wifi).EndInit();
            ((ISupportInitialize) this.romIcon3).EndInit();
            ((ISupportInitialize) this.webInfo_Boxart).EndInit();
            ((ISupportInitialize) this.webInfo_rgn).EndInit();
            ((ISupportInitialize) this.picDSCard).EndInit();
            ((ISupportInitialize) this.pic3DSCard).EndInit();
            ((ISupportInitialize) this.webInfo_dscompat).EndInit();
            this.tabRomInfo.ResumeLayout(false);
            this.tabRomInfo.PerformLayout();
            this.iconEditorGroup.ResumeLayout(false);
            this.iconEditorGroup.PerformLayout();
            this.tabControlLang.ResumeLayout(false);
            this.tabLangJpn.ResumeLayout(false);
            this.tabLangEng.ResumeLayout(false);
            this.tabLangFre.ResumeLayout(false);
            this.tabLangGer.ResumeLayout(false);
            this.tabLangIta.ResumeLayout(false);
            this.tabLangSpa.ResumeLayout(false);
            ((ISupportInitialize) this.romIcon).EndInit();
            this.tabApPatch.ResumeLayout(false);
            this.tabApPatch.PerformLayout();
            this.apPatchInfoGrp.ResumeLayout(false);
            ((ISupportInitialize) this.romIcon2).EndInit();
            this.tabExport.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void initRomInfoFields()
        {
            this.tabControlLang.Text = "";
            this.name_engText.Text = "";
            this.name_freText.Text = "";
            this.name_gerText.Text = "";
            this.name_itaText.Text = "";
            this.name_spaText.Text = "";
            this.gameTitleText.Text = "";
            this.gameCodeText.Text = "";
            this.cardSizeText.Text = "";
            this.fileSizeText.Text = "";
            this.makerCodeText.Text = "";
            this.makerNameText.Text = "";
            this.crc32Text.Text = "";
            this.romIcon.Image = Resources._0000;
            this.romIcon2.Image = Resources._0000;
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlLang.SelectedIndex = 1;
            this.clearRomWebInfo();
            for (int i = 0; i < 0x10; i++)
            {
                this.getPalCheckBox(i).BackColor = Color.WhiteSmoke;
                this.getPalCheckBox(i).Checked = false;
            }
        }

        private void installCMP(cmpDownloadType type)
        {
            if (type == cmpDownloadType.none)
            {
                MessageBox.Show("Error! Incorrect type sent to function");
            }
            else if (!this.cmpCheckFile[((int) type) - 1].installed)
            {
                MessageBox.Show("Error! No CMP Database is installed for " + type);
            }
            else
            {
                try
                {
                    string path = "";
                    FolderBrowserDialog dialog = new FolderBrowserDialog {
                        ShowNewFolderButton = true,
                        Description = "Select a folder to install the CMP Database to. Please make sure you install the correct file to your card in the correct location. If you need more help, please visit our homepage for more information"
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        path = dialog.SelectedPath;
                        string archiveName = "data/databases/" + this.cmpCheckFile[((int) type) - 1].fn;
                        this.compressor.outFile = "data/temp/";
                        this.compressor.extractRar(archiveName, this.toolStripProgressBar, this.toolStripStatusLabel, false);
                        string sourceFileName = "data/temp/" + this.compressor.extracting_file;
                        path = (path + "/" + this.compressor.extracting_file).Replace('\\', '/');
                        if (System.IO.File.Exists(path))
                        {
                            try
                            {
                                System.IO.File.Delete(path);
                            }
                            catch
                            {
                                MessageBox.Show("There was an error sending the CMP Database\nto the selected destination:\n\n " + path, "Error Transferring CMP Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                        System.IO.File.Move(sourceFileName, path);
                        MessageBox.Show("The CMP Database was installed successfully to:\n\n " + path, "CMP Database Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an error sending the CMP Database\nto the selected destination:\n\n " + type, "Error Transferring CMP Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void launchEmulator_Click(object sender, EventArgs e)
        {
            this.launchRomInEmulator(this.txtFileLoc.Text);
        }

        private void launchRomInEmulator(string fn)
        {
            string path = this.options.getValue("emu_default");
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("The emulator could not be found.\nPlease check the emulator configuration in options", "Emulator Not Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!System.IO.File.Exists(fn))
            {
                MessageBox.Show("The rom file could not be found at\n\n" + fn + "\n\nHave you have loaded a rom?", "Rom File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.disableMainForm();
                Process process = null;
                string str2 = "";
                if (this.txtFileLoc.Text.Replace('\\', '+') != this.txtFileLoc.Text)
                {
                    str2 = this.txtFileLoc.Text.Substring(0, this.txtFileLoc.Text.LastIndexOf('\\') + 1);
                }
                else if (this.txtFileLoc.Text.Replace('\\', '+') != this.txtFileLoc.Text)
                {
                    str2 = this.txtFileLoc.Text.Substring(0, this.txtFileLoc.Text.LastIndexOf('/') + 1);
                }
                if (this.options.getValue("emu_default") == this.options.getValue("emu_2"))
                {
                    if ((this.options.getValue("endrypts") == "") && !System.IO.File.Exists(this.options.getValue("endrypts")))
                    {
                        MessageBox.Show("The eNDryptS location is not set or was not found.\n\nPlease check the emulator options\n\nNO$GBA uses decrypted roms and you can check your rom using eNDrypts", "eNDrypts not Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        System.IO.File.Copy(this.options.getValue("endrypts"), str2 + "endrypts.exe");
                        ProcessStartInfo info = new ProcessStartInfo {
                            WorkingDirectory = str2,
                            FileName = str2 + "endrypts.exe"
                        };
                        process = Process.Start(info);
                        SetForegroundWindow(process.MainWindowHandle);
                        Application.DoEvents();
                        SendKeys.Send("{1}");
                        process.WaitForExit();
                        System.IO.File.Delete(str2 + "endrypts.exe");
                    }
                }
                ProcessStartInfo startInfo = new ProcessStartInfo {
                    WorkingDirectory = str2,
                    FileName = path,
                    Arguments = "\"" + fn + "\""
                };
                Process.Start(startInfo).WaitForExit();
                this.enableMainForm();
            }
        }

        private void loadCMPVersionTxt()
        {
            int index = 0;
            while (true)
            {
                if (index >= 4)
                {
                    try
                    {
                        string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F006F003F003F001000000069003F00");
                        FileStream fs = new FileStream("data/databases/version_cmp.bin", FileMode.Open, FileAccess.Read);
                        updateCSVInfo[] infoArray = new updateCSVInfo[20];
                        index = 0;
                        using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                        {
                            while (true)
                            {
                                string str2 = reader.ReadLine();
                                if (str2 != null)
                                {
                                    char[] separator = new char[] { '|' };
                                    string[] strArray = str2.Split(separator);
                                    infoArray[index] = new updateCSVInfo();
                                    infoArray[index].fn = strArray[0];
                                    infoArray[index].ver = strArray[1];
                                    if ((infoArray[index].ver != "0") && (infoArray[index].ver != ""))
                                    {
                                        this.cmpCheckFile[index].installed = true;
                                        this.cmpCheckFile[index].fn = infoArray[index].fn;
                                        this.cmpCheckFile[index].ver = infoArray[index].ver;
                                    }
                                    if (this.cmpCheckFile[index].installed)
                                    {
                                        this.enableCMPInstall((cmpDownloadType) (index + 1), infoArray[index].ver);
                                    }
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
                    catch (Exception)
                    {
                    }
                    break;
                }
                this.cmpCheckFile[index] = new cmpCheckFileType();
                this.cmpCheckFile[index].installed = false;
                this.cmpCheckFile[index].update_available = false;
                index++;
            }
            this.parseCmpGameList();
        }

        public string longFileName(string fn, int dirlen)
        {
            string str = fn;
            if (fn.Length > (0xf8 - dirlen))
            {
                int length = 0;
                int startIndex = fn.Length - 1;
                while (true)
                {
                    if ((startIndex < 0) || (fn.Substring(startIndex, 1) == "."))
                    {
                        length++;
                        str = fn.Substring(0, (0xf8 - length) - dirlen) + fn.Substring(fn.Length - length, length);
                        break;
                    }
                    length++;
                    startIndex--;
                }
            }
            return str;
        }

        private void nFOViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.nfoform != null)
            {
                this.nfoform.Dispose();
            }
            this.nfoform = new apPatcherNfoViewer();
            this.nfoform.hash = "";
            Point location = new Point();
            location = Program.form.Location;
            this.nfoform.Show();
            this.nfoform.Location = location;
        }

        private string openSaveDialogue()
        {
            string fn = null;
            SaveFileDialog dialog = new SaveFileDialog {
                Title = "Nintendo DS Rom"
            };
            string newExt = "";
            switch (this.compressionSelect.SelectedIndex)
            {
                case 1:
                    newExt = "7z";
                    break;

                case 2:
                    newExt = "zip";
                    break;

                default:
                    newExt = !this.romHeader.romHeader.is3DS ? "nds" : "3ds";
                    break;
            }
            dialog.Filter = !this.romHeader.romHeader.is3DS ? ("(Nintendo DS Rom *." + newExt + ")|*." + newExt) : ("(Nintendo 3DS Rom *." + newExt + ")|*." + newExt);
            string outPutFolder = "";
            outPutFolder = (this.txtFileLoc.Text.Replace('/', '+') == this.txtFileLoc.Text) ? this.txtFileLoc.Text.Substring(0, this.txtFileLoc.Text.LastIndexOf('\\') + 1) : this.txtFileLoc.Text.Substring(0, this.txtFileLoc.Text.LastIndexOf('/') + 1);
            dialog.FileName = this.origFileLocToNewFileName(this.changeFileExt(this.txtFileLoc.Text, newExt), this.checkBoxTrim.Checked, this.checkBoxApPatch.Checked, outPutFolder);
            dialog.InitialDirectory = outPutFolder;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fn = this.fixFileNameNoExt(dialog.FileName, "*." + newExt);
                fn = !this.romHeader.romHeader.is3DS ? this.changeFileExt(fn, "nds") : this.changeFileExt(fn, "3ds");
            }
            return fn;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.action_browse("", "");
        }

        public string origFileLocToNewFileName(string origfn, bool trim, bool apPatch, string outPutFolder)
        {
            string str = "";
            int num = 0;
            while (true)
            {
                if (num < (origfn.Length - 1))
                {
                    string str2 = origfn.Substring((origfn.Length - num) - 1, 1);
                    if ((str2 != @"\") && (str2 != "/"))
                    {
                        num++;
                        continue;
                    }
                    str = origfn.Substring(origfn.Length - num, origfn.Length - (origfn.Length - num));
                    if ((str.Substring(str.Length - 4, 4) == ".nds") || (str.Substring(str.Length - 4, 4) == ".3ds"))
                    {
                        string str3 = "";
                        if (apPatch)
                        {
                            str3 = str3 + "_apfix";
                        }
                        if (trim)
                        {
                            str3 = str3 + "_trimmed";
                        }
                        str3 = (str.Substring(str.Length - 4, 4) != ".nds") ? (str3 + ".3ds") : (str3 + ".nds");
                        str = str.Substring(0, str.Length - 4) + str3;
                    }
                }
                for (int i = 1; System.IO.File.Exists(Path.Combine(outPutFolder, str)); i++)
                {
                    str = this.fixFileExistsName(str, i);
                }
                return str;
            }
        }

        public bool parseCmpGameList()
        {
            if (!System.IO.File.Exists("data/databases/cmpGameList.bin"))
            {
                return false;
            }
            this.cmpGamesFilled = 0;
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F006F003F003F001000000069003F00");
                using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, new FileStream("data/databases/cmpGameList.bin", FileMode.Open, FileAccess.Read))))
                {
                    string str2;
                    bool flag = false;
                    while ((str2 = reader.ReadLine()) != null)
                    {
                        if (flag)
                        {
                            cmpGameListItem item = new cmpGameListItem();
                            try
                            {
                                string[] strArray = str2.Split(new char[] { '{' });
                                item.name = strArray[0];
                                item.hash = strArray[1];
                                string[] strArray2 = item.hash.Split(new char[] { ' ' });
                                item.gameCode = strArray2[0];
                                item.hash = strArray2[1].Substring(0, strArray2[1].Length - 1);
                                item.region = item.name.Split(new char[] { '(' })[1];
                                strArray2 = item.region.Split(new char[] { ')' });
                                item.region = this.regionChange(strArray2[0]);
                                this.addGameToCMPList(item);
                            }
                            catch
                            {
                            }
                        }
                        if (str2.Substring(0, 5) == "-----")
                        {
                            flag = true;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to parse the cmpGamelist file.\nPlease try a CMP Database update");
                return false;
            }
            return true;
        }

        private void patchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.databasesOk)
            {
                this.batchForm.formSetup();
                this.batchForm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("The database must be updated before you can use the application", "Database Update Required", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.checkDatabaseUpdate(true);
                this.patchInfo = null;
            }
        }

        private unsafe long patchRomBytes(long offset, long endPos, BinaryReader br, BinaryWriter writer, ProgressBar progress, Label status, string romOut)
        {
            int num = 0;
            int num2 = 0;
            if (this.patchInfo == null)
            {
                return (long) (-2);
            }
            int index = 0;
            while (index < this.patchInfo.patchlines)
            {
                num2 = int.Parse(this.patchInfo.patchline[index].offset, NumberStyles.HexNumber);
                if (num2 < offset)
                {
                    return (long) (-10);
                }
                this.copyBytes(br, writer, (long) (num2 - ((int) offset)), 0x400, (long) ((int) offset), endPos, progress, status, romOut);
                offset = num2;
                string str = this.romHeader.readHex(br, &offset, this.patchInfo.patchline[index].find.Length / 2);
                num = (int) this.run.hexAndMathFunction.bytesToMbit(offset);
                progress.Value = num;
                object[] objArray = new object[] { "Saving ", this.origFileLocToNewFileName(romOut, false, false, ""), " ", this.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, this.toolStripProgressBar.Maximum), "%" };
                status.Text = string.Concat(objArray);
                Application.DoEvents();
                if (str != this.patchInfo.patchline[index].find)
                {
                    return ((str != this.patchInfo.patchline[index].replace) ? ((long) (-12)) : ((long) (-13)));
                }
                if (this.patchInfo.patchline[index].find.Length != this.patchInfo.patchline[index].replace.Length)
                {
                    return (long) (-11);
                }
                int num4 = 0;
                while (true)
                {
                    if (num4 >= (this.patchInfo.patchline[index].replace.Length / 2))
                    {
                        index++;
                        break;
                    }
                    num = (int) this.run.hexAndMathFunction.bytesToMbit(offset + num4);
                    progress.Value = num;
                    object[] objArray2 = new object[] { "Saving ", this.origFileLocToNewFileName(romOut, false, false, ""), " ", this.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, this.toolStripProgressBar.Maximum), "%" };
                    status.Text = string.Concat(objArray2);
                    Application.DoEvents();
                    string s = this.patchInfo.patchline[index].replace.Substring(num4 * 2, 2);
                    writer.Write((byte) int.Parse(s, NumberStyles.HexNumber));
                    num4++;
                }
            }
            return offset;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        public string regionChange(string region)
        {
            string key = region;
            if (key != null)
            {
                int num;
                if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x600013a-1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(13);
                    dictionary1.Add("A", 0);
                    dictionary1.Add("C", 1);
                    dictionary1.Add("D", 2);
                    dictionary1.Add("E", 3);
                    dictionary1.Add("F", 4);
                    dictionary1.Add("H", 5);
                    dictionary1.Add("I", 6);
                    dictionary1.Add("J", 7);
                    dictionary1.Add("K", 8);
                    dictionary1.Add("N", 9);
                    dictionary1.Add("R", 10);
                    dictionary1.Add("S", 11);
                    dictionary1.Add("U", 12);
                    <PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x600013a-1 = dictionary1;
                }
                if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x600013a-1.TryGetValue(key, out num))
                {
                    switch (num)
                    {
                        case 0:
                            return "AUS";

                        case 1:
                            return "CHI";

                        case 2:
                            return "GER";

                        case 3:
                            return "EUR";

                        case 4:
                            return "FRA";

                        case 5:
                            return "HOL";

                        case 6:
                            return "ITA";

                        case 7:
                            return "JPN";

                        case 8:
                            return "KOR";

                        case 9:
                            return "NOR";

                        case 10:
                            return "RUS";

                        case 11:
                            return "SPA";

                        case 12:
                            return "USA";

                        default:
                            break;
                    }
                }
            }
            return ("unknown_" + region);
        }

        private void rememberDSSceneInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        public string romExportError(long err, string destfn, bool batch)
        {
            if (!batch)
            {
                long num2 = err;
                if ((num2 <= 1L) && (num2 >= -13))
                {
                    switch (((int) (num2 - -13)))
                    {
                        case 0:
                            return "This rom appears to be AP Patched already";

                        case 4:
                            return "Archive creation failed";

                        case 5:
                            return "AP Patch not supported, otherwise ok";

                        case 6:
                            return "Failed to get CRC32 of the file";

                        case 7:
                            return "Ap Patch appeared to be incorrect";

                        case 8:
                            return "The rom appears to have been altered";

                        case 9:
                            return "The rom appears to have been patched already";

                        case 10:
                            return "Rom Save Failure";

                        case 11:
                            return "AP Patch failed";

                        case 12:
                            return "Trim Failed";

                        case 14:
                            return "Success";

                        default:
                            break;
                    }
                }
                return ("unknown error code: " + err);
            }
            long num = err;
            if (num <= -40)
            {
                if (num < -44)
                {
                    goto TR_0000;
                }
                else
                {
                    switch (((int) (num - -44)))
                    {
                        case 0:
                            return "Failed to copy original file to new location";

                        case 1:
                            return "CRC Not Found on DS-Scene";

                        case 2:
                            return "Skipped Unknown";

                        case 3:
                            return "Skipped Duplicate";

                        case 4:
                            return "CRC32 Failed";

                        default:
                            break;
                    }
                }
            }
            if ((num <= 1L) && (num >= -13))
            {
                switch (((int) (num - -13)))
                {
                    case 0:
                        return ("This rom appears to be AP Patched already] [Output may be corrupt: " + destfn);

                    case 4:
                        return ("Archive creation failed] [Output may be corrupt: " + destfn);

                    case 5:
                        return "AP Patch not supported, otherwise ok";

                    case 6:
                        return "Failed to get CRC32 of the file";

                    case 7:
                        return ("Ap Patch appeared to be incorrect] [Output may be corrupt: " + destfn);

                    case 8:
                        return ("The rom appears to have been altered] [Output may be corrupt: " + destfn);

                    case 9:
                        return ("The rom appears to have been patched already] [Output may be corrupt: " + destfn);

                    case 10:
                        return ("Rom Save Failure] [Output may be corrupt: " + destfn);

                    case 11:
                        return ("AP Patch failed] [Output may be corrupt: " + destfn);

                    case 12:
                        return ("Trim Failed] [Output may be corrupt: " + destfn);

                    case 14:
                        return ("Success] [Output: " + destfn);

                    default:
                        break;
                }
            }
        TR_0000:
            return ("unknown error code: " + err);
        }

        private long saveRom(string romIn, string romOut, bool apPatch, ProgressBar progress, Label status, long endPos)
        {
            int num = 1;
            bool flag = false;
            try
            {
                FileStream input = System.IO.File.Open(romIn, FileMode.Open);
                FileStream output = System.IO.File.Open(romOut, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(output);
                using (BinaryReader reader = new BinaryReader(input))
                {
                    if (endPos < reader.BaseStream.Length)
                    {
                        flag = true;
                    }
                    this.run.hexAndMathFunction.bytesToMbit(endPos);
                    progress.Maximum = 100;
                    status.Text = "Saving " + this.origFileLocToNewFileName(romOut, false, false, "") + " 0%";
                    progress.Value = 0;
                    long pos = 0L;
                    if (!apPatch)
                    {
                        status.Text = "Saving " + this.origFileLocToNewFileName(romOut, false, false, "");
                        int chunk = (endPos <= 0x9c4000L) ? ((int) endPos) : 0x9c4000;
                        this.copyBytes(reader, writer, endPos, chunk, pos, endPos, progress, status, romOut);
                    }
                    else
                    {
                        pos = this.patchRomBytes(pos, endPos, reader, writer, progress, status, romOut);
                        if (pos >= 0L)
                        {
                            this.copyBytes(reader, writer, endPos - pos, 0x400, pos, endPos, progress, status, romOut);
                        }
                        else
                        {
                            input.Close();
                            output.Close();
                            return pos;
                        }
                    }
                }
                input.Close();
                output.Close();
            }
            catch (Exception)
            {
                num = -3;
            }
            if (num == 1)
            {
                crcDupes.romTypes clean = crcDupes.romTypes.clean;
                if (apPatch)
                {
                    clean = crcDupes.romTypes.apPatched;
                    if (flag)
                    {
                        clean = crcDupes.romTypes.apAndTrim;
                    }
                }
                else if (flag)
                {
                    clean = crcDupes.romTypes.trimmed;
                    if (apPatch)
                    {
                        clean = crcDupes.romTypes.apAndTrim;
                    }
                }
                if (this.romHeader.romHeader.website_knows_it && (this.options.getValue("disable_crc_db") != "1"))
                {
                    int num7 = this.crcDb.addNewFileCRCToDb(this.romHeader.romHeader.hash, romOut, clean, progress, status);
                }
            }
            return (long) num;
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public void setupOptionsDisplay()
        {
            this.enableUpdateAlertsToolStripMenuItem.Checked = this.options.getValue("ap_update_check") != "0";
            this.uSRcheatToolStripMenuItem1.Checked = this.options.getValue("cmp_usrcheat_update_check") != "0";
            this.eDGEToolStripMenuItem.Checked = this.options.getValue("cmp_edgecheat_update_check") == "1";
            this.cycloDSToolStripMenuItem.Checked = this.options.getValue("cmp_cyclocheat_update_check") == "1";
            this.disableCheckOnStartToolStripMenuItem.Checked = this.options.getValue("disable_update") == "1";
            this.autoOpenBrowserToolStripMenuItem.Checked = this.options.getValue("auto_open_collections") != "0";
            if (this.options.getValue("disable_crc_db") == "1")
            {
                this.rememberDSSceneInfoToolStripMenuItem.Checked = false;
                this.crcDb.db.active = false;
            }
            else
            {
                this.rememberDSSceneInfoToolStripMenuItem.Checked = true;
                this.crcDb.db.active = true;
                this.crcDb.loadDb();
            }
            if (this.options.getValue("disable_web") == "1")
            {
                this.disableWebContentToolStripMenuItem.Checked = true;
                this.disableWebAlertContentToolStripMenuItem.Checked = true;
                this.disableWebAlertContentToolStripMenuItem.Enabled = false;
                this.autoDownloadToolStripMenuItem.Checked = false;
                this.autoDownloadToolStripMenuItem.Enabled = false;
                this.rememberDSSceneInfoToolStripMenuItem.Enabled = false;
                this.rememberDSSceneInfoToolStripMenuItem.Checked = false;
                this.tabControlMain.TabPages.Remove(this.tabWebInfo);
            }
            else
            {
                this.rememberDSSceneInfoToolStripMenuItem.Enabled = true;
                this.disableWebAlertContentToolStripMenuItem.Enabled = true;
                this.autoDownloadToolStripMenuItem.Enabled = true;
                this.disableWebContentToolStripMenuItem.Checked = false;
                if (!ReferenceEquals(this.tabControlMain.TabPages[0], this.tabWebInfo))
                {
                    this.tabControlMain.TabPages.Insert(0, this.tabWebInfo);
                }
                this.disableWebAlertContentToolStripMenuItem.Checked = this.options.getValue("disable_webalert") == "1";
                if (this.options.getValue("auto_info_dl") == "1")
                {
                    this.autoDownloadToolStripMenuItem.Checked = true;
                }
                else
                {
                    this.autoDownloadToolStripMenuItem.Checked = false;
                }
            }
        }

        private void show3DSopt(string optionType, int n3dsopt_used)
        {
            switch (n3dsopt_used)
            {
                case 0:
                    this.n3dsopt_0.Visible = true;
                    this.n3dsopt_0.Image = this.get3DSoptImage(optionType);
                    return;

                case 1:
                    this.n3dsopt_1.Visible = true;
                    this.n3dsopt_1.Image = this.get3DSoptImage(optionType);
                    return;

                case 2:
                    this.n3dsopt_2.Visible = true;
                    this.n3dsopt_2.Image = this.get3DSoptImage(optionType);
                    return;

                case 3:
                    this.n3dsopt_3.Visible = true;
                    this.n3dsopt_3.Image = this.get3DSoptImage(optionType);
                    return;

                case 4:
                    this.n3dsopt_4.Visible = true;
                    this.n3dsopt_4.Image = this.get3DSoptImage(optionType);
                    return;

                case 5:
                    this.n3dsopt_5.Visible = true;
                    this.n3dsopt_5.Image = this.get3DSoptImage(optionType);
                    return;
            }
        }

        private void tabPage_Focus(object sender, EventArgs e)
        {
            this.btnBrowse.Focus();
        }

        private void uSRCHEATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.installCMP(cmpDownloadType.USRcheat);
        }

        private void uSRcheatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.options.save();
            this.options.load();
            this.setupOptionsDisplay();
        }

        private void versionInfoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.changelogForm.formSetup("cmp");
            this.changelogForm.ShowDialog(this);
        }

        private void versionInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string str = "DS-Scene Rom Tool";
            if (!this.databasesOk)
            {
                MessageBox.Show("You are currently running " + str + " v1.0 build 1215\r\n\r\nThe databases are not installed correctly.\r\nPlease update them before you can view more information.", "Version Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.changelogForm.formSetup("db");
                this.changelogForm.ShowDialog(this);
            }
        }

        public void waitForFreeMemory(Label status)
        {
            for (Process process = Process.GetCurrentProcess(); process.WorkingSet64 > 0x61a8000L; process = Process.GetCurrentProcess())
            {
                status.Text = "Traffic Jam! Waiting for free memory [using " + $"{((int) (process.WorkingSet64 / 0x400L)):n0}" + "kb]";
                Application.DoEvents();
            }
        }

        public class cmpCheckFileType
        {
            public bool installed;
            public bool update_available;
            public string fn = "";
            public string ver = "";
        }

        public enum cmpDownloadType
        {
            none,
            USRcheat,
            EDGE,
            CycloDS
        }

        public class cmpGameListItem
        {
            public string name = "";
            public string region = "";
            public string gameCode = "";
            public string hash = "";
        }

        public enum romTrimTypes
        {
            none,
            safe,
            accurate
        }

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }

        public class updateCSVInfo
        {
            public string fn;
            public string ver;
        }
    }
}

