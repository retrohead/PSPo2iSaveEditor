namespace apPatcherApp
{
    using apPatcherApp.Properties;
    using dsRomHeaderFunctions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class batchOrganiseForm : Form
    {
        private DateTime processStart = new DateTime();
        private string processEndGuess = "";
        private bool processing;
        private int lastRecordedProgressBar;
        private long lastRecordedProgressBarVal;
        private DateTime lastRecordedProgressDate = new DateTime();
        private string[] filesToProcess = new string[0x61a8];
        public bool cancelled;
        public bool allowCompress = true;
        private IContainer components;
        private CheckBox checkBoxDelete;
        private ComboBox compressionSelect;
        private GroupBox groupBoxRename;
        private RadioButton radioRomScene;
        private RadioButton radioRomNumbers;
        private Button buttonClose;
        private GroupBox stageProgressGrp;
        private GroupBox totalProgressGrp;
        private Label totalProgressGrpLabel;
        private GroupBox groupDirFiles;
        private CheckBox checkBoxSubDirs;
        public TextBox txtFileLocIn;
        private Button btnBrowseIn;
        private TabControl tabsCollections;
        private TabPage tabPageAdd;
        private TabPage tabPage2;
        private Label label2;
        private Label label1;
        public TextBox txtDbName;
        public TextBox txtFileLocOut;
        private Button btnBrowseOut;
        private ComboBox listCollections;
        private TabPage tabPage1;
        private Label txtDelCollectionWarn;
        private Button buttonDeleteCollection;
        private Button btnCreateCollection;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupSingleFile;
        public TextBox txtFileLocIn2;
        private Button btnBrowseSingleIn;
        private Button startBatchBtn;
        private Label label5;
        private ImageList imageList1;
        private RadioButton radioDirFiles;
        private RadioButton radioSingleFile;
        private Button btnApplyChange;
        private Label label4;
        private GroupBox groupRename2;
        private RadioButton radioRomNumbers2;
        private RadioButton radioRomScene2;
        private Label label6;
        public TextBox txtDbName2;
        public TextBox txtFileLocOut2;
        private Button btnBrowseOut2;
        private GroupBox groupBox3;
        private ComboBox listDelCollections;
        private Button btnEdit;
        private RadioButton radioButtonDeleteFiles;
        private RadioButton radioButtonKeepFiles;
        private CheckBox checkBoxIgnoreUnknown;
        private CheckBox checkBoxIgnoreDupes;
        public CheckBox checkBoxDownload;
        public Button cancelBatchBtn;
        public ProgressBar progressBarStage;
        public Label stageProgressGrpLabel;
        private ProgressBar progressBarTotal;
        private TabPage tabPage3;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btnUpdateWeb;
        private Button btnCleanColDb;
        private Label label3;
        private ComboBox listScanCollections;
        private Button btnCleanDir;
        private CheckBox chk3DSprefix;
        private GroupBox groupBox4;
        private ComboBox compressionSelect2;
        private CheckBox chk3DSprefix2;
        private Label label10;

        public batchOrganiseForm()
        {
            base.MaximizeBox = false;
            this.InitializeComponent();
        }

        private void btnBrowseIn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog {
                SelectedPath = (this.txtFileLocIn.Text == "") ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) : this.txtFileLocIn.Text,
                ShowNewFolderButton = false,
                Description = "Select a folder to process"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFileLocIn.Text = dialog.SelectedPath;
                this.resetProgressBars();
            }
        }

        private void btnBrowseOut_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog {
                SelectedPath = (this.txtFileLocOut.Text == "") ? ((this.txtFileLocIn.Text == "") ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) : this.txtFileLocIn.Text) : this.txtFileLocOut.Text,
                ShowNewFolderButton = true,
                Description = "Select a folder to output the processed files to"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.resetProgressBars();
                this.txtFileLocOut.Text = dialog.SelectedPath;
            }
        }

        private void btnBrowseSingleIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Title = "DS-Scene Rom Tool: Open File"
            };
            if (!Program.form.rarInstalled && !Program.form.zipInstalled)
            {
                dialog.Filter = "Nintendo DS/3DS Roms|*.nds;*.3ds";
            }
            else if (Program.form.rarInstalled && Program.form.zipInstalled)
            {
                dialog.Filter = "Nintendo DS/3DS Roms|*.nds;*.3ds;*.zip;*.rar;*.7z";
            }
            else if (Program.form.rarInstalled)
            {
                dialog.Filter = "Nintendo DS/3DS Roms|*.nds;*.3ds;*.rar";
            }
            else if (Program.form.zipInstalled)
            {
                dialog.Filter = "Nintendo DS/3DS Roms|*.nds;*.3ds;*.zip;*.7z";
            }
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFileLocIn2.Text = dialog.FileName;
            }
        }

        private void btnCleanColDb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to scan and remove all\nmissing entries from the collection?", "Scan & Remove Missing Entries?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int num = Program.form.collectiondb.deleteMissingItems();
                if (num == 1)
                {
                    MessageBox.Show("1 entry could not be found and\nwas removed from the collection", "Collection Database Cleansed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show(num + " entries could not be found and\nwere removed from the collection", "Collection Database Cleansed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            Program.form.collectiondb.removeMarkedItems();
        }

        private void btnCleanDir_Click(object sender, EventArgs e)
        {
        }

        private void btnCreateCollection_Click(object sender, EventArgs e)
        {
            if (this.txtFileLocOut.Text == "")
            {
                MessageBox.Show("You must select an output directory", "Output Directory Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.txtDbName.Text == "")
            {
                MessageBox.Show("You must type a name for the collection", "Collection Name Blank", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string type = "numbered";
                if (this.radioRomScene.Checked)
                {
                    type = "scene";
                }
                string path = "";
                path = Path.Combine(this.txtFileLocOut.Text, this.txtDbName.Text);
                if (Program.form.collectiondb.selectDatabase(this.txtDbName.Text))
                {
                    MessageBox.Show("A collection already exists with the name:\n\n" + this.txtDbName.Text + "\n\nAdd items to this collection or choose a different name", "Duplicate Collection Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (Directory.Exists(path))
                {
                    MessageBox.Show("A folder already exists with the name:\n\n" + this.txtDbName.Text + "\n\nYou should choose a different name for a new collection", "Collection Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    switch (Program.form.collectiondb.createDatabase(this.txtDbName.Text, this.txtFileLocOut.Text, type, this.compressionSelect.SelectedIndex.ToString(), this.chk3DSprefix.Checked))
                    {
                        case -2:
                            MessageBox.Show("A collection already exists with the name:\n\n" + this.txtDbName.Text + "\n\nYou should choose a different name for a new collection", "Collection Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;

                        case -1:
                            MessageBox.Show("Failed to create the collection database");
                            return;
                    }
                    Directory.CreateDirectory(path);
                    Program.form.collectiondb.saveAll();
                    this.buildDbCombos();
                    MessageBox.Show("The collection was created successfully.\n\nYou can now start adding roms to it.", "Collection Creation Successfull", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnUpdateWeb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to download and update\nmissing\\corrupt web information in the collection?", "Scan & Remove Missing Entries?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int num = this.webCollectionUpdate();
                if (num == 1)
                {
                    MessageBox.Show("1 entry had it's information updated.\n\nYou should now clean the collection directory", "Collection Web Information Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (num > 0)
                {
                    MessageBox.Show(num + " entries had their information updated.\n\nYou should now clean the collection directory", "Collection Web Information Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show(num + " entries had their information updated.", "Collection Web Information Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void buildDbCombos()
        {
            this.listCollections.SelectedIndex = -1;
            this.listDelCollections.SelectedIndex = -1;
            this.listScanCollections.SelectedIndex = -1;
            this.listCollections.Items.Clear();
            this.listDelCollections.Items.Clear();
            this.listScanCollections.Items.Clear();
            if (Program.form.collectiondb.dbsUsed <= 0)
            {
                this.listCollections.Enabled = false;
                this.listDelCollections.Enabled = false;
                this.listScanCollections.Enabled = false;
                this.tabsCollections.SelectedIndex = 0;
            }
            else
            {
                this.listCollections.Enabled = true;
                this.listDelCollections.Enabled = true;
                this.listScanCollections.Enabled = true;
                this.tabsCollections.SelectedIndex = 1;
                for (int i = 0; i < Program.form.collectiondb.dbsUsed; i++)
                {
                    this.listCollections.Items.Add(Program.form.collectiondb.db[i].fn);
                    this.listDelCollections.Items.Add(Program.form.collectiondb.db[i].fn);
                    this.listScanCollections.Items.Add(Program.form.collectiondb.db[i].fn);
                }
            }
            this.listCollections.SelectedIndex = Program.form.collectiondb.activeDb;
            this.listDelCollections.SelectedIndex = Program.form.collectiondb.activeDb;
            this.listScanCollections.SelectedIndex = Program.form.collectiondb.activeDb;
            this.listCollections_SelectedIndexChanged(this.listCollections, null);
        }

        private void buttonDeleteCollection_Click(object sender, EventArgs e)
        {
            if (Program.form.collectiondb.dbsUsed == 0)
            {
                MessageBox.Show("There are no collections available to delete", "No Collections Exist", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (this.listDelCollections.SelectedIndex < 0)
            {
                MessageBox.Show("You must select which collection you want to delete", "No Collection Selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (MessageBox.Show("Are you sure you want to delete the collection:\n\n" + this.listDelCollections.SelectedItem.ToString(), "Confirm Delete Collection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.radioButtonDeleteFiles.Checked)
                {
                    string path = Path.Combine(Program.form.collectiondb.db[this.listCollections.SelectedIndex].root, Program.form.collectiondb.db[this.listCollections.SelectedIndex].fn);
                    if (MessageBox.Show("All files in and including the directory\n\n" + path + "\n\nwill be deleted.\n\nAre you Sure?", "Confirm Delete Files", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    {
                        return;
                    }
                    if (Directory.Exists(path))
                    {
                        Program.form.cleanFolder(path);
                        int num = 100;
                        while (num > 0)
                        {
                            try
                            {
                                Directory.Delete(path);
                            }
                            catch (Exception exception)
                            {
                                num--;
                                if (num == 0)
                                {
                                    MessageBox.Show(exception.Message);
                                }
                                continue;
                            }
                            break;
                        }
                    }
                }
                Program.form.collectiondb.deleteDatabase(this.listDelCollections.SelectedItem.ToString());
                if (this.radioButtonDeleteFiles.Checked)
                {
                    MessageBox.Show("The collection and all files contained\nwithin it were removed successfully", "Collection Removal Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("The collection was removed successfully", "Collection Removal Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.buildDbCombos();
            }
        }

        private void cancelBatchBtn_Click(object sender, EventArgs e)
        {
            this.cancelBatchBtn.Enabled = false;
            this.cancelled = true;
        }

        private int countValidFilesInSelectedDir()
        {
            string[] strArray;
            int index = 0;
            SearchOption topDirectoryOnly = SearchOption.TopDirectoryOnly;
            if (this.checkBoxSubDirs.Checked)
            {
                topDirectoryOnly = SearchOption.AllDirectories;
            }
            try
            {
                strArray = Directory.GetFiles(this.txtFileLocIn.Text, "*", topDirectoryOnly);
            }
            catch
            {
                return -1;
            }
            foreach (string str in strArray)
            {
                if (index >= 0x61a8)
                {
                    MessageBox.Show("The maximum amount of files (" + 0x61a8 + ") was reached.", "Batch Job Terminated", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if ((Program.form.getFileExtension(str) == "rar") || ((Program.form.getFileExtension(str) == "zip") || ((Program.form.getFileExtension(str) == "7z") || ((Program.form.getFileExtension(str) == "nds") || (Program.form.getFileExtension(str) == "3ds")))))
                {
                    this.filesToProcess[index] = str;
                    index++;
                }
            }
            strArray = null;
            return index;
        }

        private void disableEditCollection()
        {
            this.listDelCollections.Visible = true;
            this.groupRename2.Enabled = false;
            this.txtDbName2.Visible = false;
            this.btnEdit.Visible = false;
            this.btnBrowseOut2.Visible = false;
            this.btnApplyChange.Visible = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void endProcessTimer()
        {
            this.processing = false;
        }

        private string fixWebsiteFileName(string fn, string extn)
        {
            if (fn.Replace('.', '+') == fn)
            {
                return (fn + "." + extn);
            }
            string str = Program.form.getFileExtension(fn);
            fn = fn.Substring(0, fn.Length - str.Length);
            return (fn + extn);
        }

        public void formSetup()
        {
            this.txtFileLocIn.Text = "";
            this.txtFileLocOut.Text = "";
            this.resetProgressBars();
            this.cancelBatchBtn.Visible = false;
            this.cancelled = false;
            if (!Program.form.zipInstalled)
            {
                this.allowCompress = false;
                this.compressionSelect.Enabled = false;
                this.compressionSelect.SelectedIndex = 0;
            }
            else
            {
                this.allowCompress = true;
                this.compressionSelect.Enabled = true;
                this.compressionSelect.SelectedIndex = 0;
            }
            this.buildDbCombos();
        }

        public void increaseTotalProgress()
        {
            this.progressBarTotal.Value++;
            this.totalProgressGrpLabel.Text = "Total Progress (" + Program.form.run.hexAndMathFunction.getPercentage(this.progressBarTotal.Value, this.progressBarTotal.Maximum) + "%)";
            this.stageProgressGrpLabel_TextChanged(null, null);
            Application.DoEvents();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(batchOrganiseForm));
            this.compressionSelect = new ComboBox();
            this.checkBoxDelete = new CheckBox();
            this.groupBoxRename = new GroupBox();
            this.checkBoxIgnoreUnknown = new CheckBox();
            this.checkBoxIgnoreDupes = new CheckBox();
            this.checkBoxDownload = new CheckBox();
            this.radioRomScene = new RadioButton();
            this.radioRomNumbers = new RadioButton();
            this.stageProgressGrp = new GroupBox();
            this.stageProgressGrpLabel = new Label();
            this.progressBarStage = new ProgressBar();
            this.totalProgressGrp = new GroupBox();
            this.totalProgressGrpLabel = new Label();
            this.progressBarTotal = new ProgressBar();
            this.groupDirFiles = new GroupBox();
            this.checkBoxSubDirs = new CheckBox();
            this.txtFileLocIn = new TextBox();
            this.btnBrowseIn = new Button();
            this.radioDirFiles = new RadioButton();
            this.tabsCollections = new TabControl();
            this.tabPage2 = new TabPage();
            this.btnCreateCollection = new Button();
            this.groupBox2 = new GroupBox();
            this.label2 = new Label();
            this.groupBox1 = new GroupBox();
            this.chk3DSprefix = new CheckBox();
            this.label1 = new Label();
            this.txtDbName = new TextBox();
            this.txtFileLocOut = new TextBox();
            this.btnBrowseOut = new Button();
            this.tabPageAdd = new TabPage();
            this.radioSingleFile = new RadioButton();
            this.groupSingleFile = new GroupBox();
            this.txtFileLocIn2 = new TextBox();
            this.btnBrowseSingleIn = new Button();
            this.label5 = new Label();
            this.listCollections = new ComboBox();
            this.startBatchBtn = new Button();
            this.tabPage1 = new TabPage();
            this.groupBox4 = new GroupBox();
            this.compressionSelect2 = new ComboBox();
            this.btnEdit = new Button();
            this.label4 = new Label();
            this.groupRename2 = new GroupBox();
            this.chk3DSprefix2 = new CheckBox();
            this.radioRomNumbers2 = new RadioButton();
            this.radioRomScene2 = new RadioButton();
            this.label6 = new Label();
            this.txtFileLocOut2 = new TextBox();
            this.btnBrowseOut2 = new Button();
            this.groupBox3 = new GroupBox();
            this.radioButtonDeleteFiles = new RadioButton();
            this.radioButtonKeepFiles = new RadioButton();
            this.buttonDeleteCollection = new Button();
            this.txtDelCollectionWarn = new Label();
            this.listDelCollections = new ComboBox();
            this.txtDbName2 = new TextBox();
            this.btnApplyChange = new Button();
            this.tabPage3 = new TabPage();
            this.label9 = new Label();
            this.label8 = new Label();
            this.label7 = new Label();
            this.btnUpdateWeb = new Button();
            this.btnCleanColDb = new Button();
            this.label3 = new Label();
            this.listScanCollections = new ComboBox();
            this.btnCleanDir = new Button();
            this.imageList1 = new ImageList(this.components);
            this.cancelBatchBtn = new Button();
            this.buttonClose = new Button();
            this.label10 = new Label();
            this.groupBoxRename.SuspendLayout();
            this.stageProgressGrp.SuspendLayout();
            this.totalProgressGrp.SuspendLayout();
            this.groupDirFiles.SuspendLayout();
            this.tabsCollections.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageAdd.SuspendLayout();
            this.groupSingleFile.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupRename2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            base.SuspendLayout();
            this.compressionSelect.Cursor = Cursors.Hand;
            this.compressionSelect.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.compressionSelect.FormattingEnabled = true;
            object[] items = new object[] { "No Repack (.nds | .3ds)", "7-Zip (.7z)", "WinZip (.zip)" };
            this.compressionSelect.Items.AddRange(items);
            this.compressionSelect.Location = new Point(6, 20);
            this.compressionSelect.Name = "compressionSelect";
            this.compressionSelect.Size = new Size(0xdd, 20);
            this.compressionSelect.TabIndex = 0x61;
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Cursor = Cursors.Hand;
            this.checkBoxDelete.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxDelete.Location = new Point(20, 0x2d);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new Size(0x79, 0x10);
            this.checkBoxDelete.TabIndex = 0x63;
            this.checkBoxDelete.Text = "Delete original files";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            this.groupBoxRename.Controls.Add(this.checkBoxIgnoreUnknown);
            this.groupBoxRename.Controls.Add(this.checkBoxIgnoreDupes);
            this.groupBoxRename.Controls.Add(this.checkBoxDelete);
            this.groupBoxRename.Controls.Add(this.checkBoxDownload);
            this.groupBoxRename.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBoxRename.Location = new Point(4, 0xaf);
            this.groupBoxRename.Name = "groupBoxRename";
            this.groupBoxRename.Size = new Size(360, 0x45);
            this.groupBoxRename.TabIndex = 0x73;
            this.groupBoxRename.TabStop = false;
            this.groupBoxRename.Text = "Process Options";
            this.checkBoxIgnoreUnknown.AutoSize = true;
            this.checkBoxIgnoreUnknown.Cursor = Cursors.Hand;
            this.checkBoxIgnoreUnknown.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxIgnoreUnknown.Location = new Point(0xe1, 0x2d);
            this.checkBoxIgnoreUnknown.Name = "checkBoxIgnoreUnknown";
            this.checkBoxIgnoreUnknown.Size = new Size(0x69, 0x10);
            this.checkBoxIgnoreUnknown.TabIndex = 0x65;
            this.checkBoxIgnoreUnknown.Text = "Ignore Unknown";
            this.checkBoxIgnoreUnknown.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreDupes.AutoSize = true;
            this.checkBoxIgnoreDupes.Cursor = Cursors.Hand;
            this.checkBoxIgnoreDupes.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxIgnoreDupes.Location = new Point(0xe1, 0x17);
            this.checkBoxIgnoreDupes.Name = "checkBoxIgnoreDupes";
            this.checkBoxIgnoreDupes.Size = new Size(0x72, 0x10);
            this.checkBoxIgnoreDupes.TabIndex = 100;
            this.checkBoxIgnoreDupes.Text = "Ignore Duplicates";
            this.checkBoxIgnoreDupes.UseVisualStyleBackColor = true;
            this.checkBoxDownload.AutoSize = true;
            this.checkBoxDownload.Checked = true;
            this.checkBoxDownload.CheckState = CheckState.Checked;
            this.checkBoxDownload.Cursor = Cursors.Hand;
            this.checkBoxDownload.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxDownload.Location = new Point(20, 0x17);
            this.checkBoxDownload.Name = "checkBoxDownload";
            this.checkBoxDownload.Size = new Size(0xc3, 0x10);
            this.checkBoxDownload.TabIndex = 0x58;
            this.checkBoxDownload.Text = "Download Missing DS-Scene Data";
            this.checkBoxDownload.UseVisualStyleBackColor = true;
            this.radioRomScene.AutoSize = true;
            this.radioRomScene.Cursor = Cursors.Hand;
            this.radioRomScene.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioRomScene.Location = new Point(0x90, 20);
            this.radioRomScene.Name = "radioRomScene";
            this.radioRomScene.Size = new Size(0x5f, 0x10);
            this.radioRomScene.TabIndex = 0x65;
            this.radioRomScene.Text = "Scene System";
            this.radioRomScene.UseVisualStyleBackColor = true;
            this.radioRomScene.CheckedChanged += new EventHandler(this.radioRomScene_CheckedChanged);
            this.radioRomNumbers.AutoSize = true;
            this.radioRomNumbers.Checked = true;
            this.radioRomNumbers.Cursor = Cursors.Hand;
            this.radioRomNumbers.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioRomNumbers.Location = new Point(20, 20);
            this.radioRomNumbers.Name = "radioRomNumbers";
            this.radioRomNumbers.Size = new Size(0x76, 0x10);
            this.radioRomNumbers.TabIndex = 100;
            this.radioRomNumbers.TabStop = true;
            this.radioRomNumbers.Text = "Numbering System";
            this.radioRomNumbers.UseVisualStyleBackColor = true;
            this.radioRomNumbers.CheckedChanged += new EventHandler(this.radioRomNumbers_CheckedChanged);
            this.stageProgressGrp.Controls.Add(this.stageProgressGrpLabel);
            this.stageProgressGrp.Controls.Add(this.progressBarStage);
            this.stageProgressGrp.Location = new Point(3, 0x15a);
            this.stageProgressGrp.Name = "stageProgressGrp";
            this.stageProgressGrp.Size = new Size(0x178, 40);
            this.stageProgressGrp.TabIndex = 0x6f;
            this.stageProgressGrp.TabStop = false;
            this.stageProgressGrpLabel.AutoSize = true;
            this.stageProgressGrpLabel.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.stageProgressGrpLabel.Location = new Point(12, 1);
            this.stageProgressGrpLabel.Name = "stageProgressGrpLabel";
            this.stageProgressGrpLabel.Size = new Size(0x47, 12);
            this.stageProgressGrpLabel.TabIndex = 100;
            this.stageProgressGrpLabel.Text = "File Progress";
            this.stageProgressGrpLabel.TextChanged += new EventHandler(this.stageProgressGrpLabel_TextChanged);
            this.progressBarStage.Location = new Point(7, 0x10);
            this.progressBarStage.Name = "progressBarStage";
            this.progressBarStage.Size = new Size(0x16a, 0x10);
            this.progressBarStage.TabIndex = 0x63;
            this.totalProgressGrp.Controls.Add(this.totalProgressGrpLabel);
            this.totalProgressGrp.Controls.Add(this.progressBarTotal);
            this.totalProgressGrp.Location = new Point(2, 0x182);
            this.totalProgressGrp.Name = "totalProgressGrp";
            this.totalProgressGrp.Size = new Size(0x178, 40);
            this.totalProgressGrp.TabIndex = 110;
            this.totalProgressGrp.TabStop = false;
            this.totalProgressGrpLabel.AutoSize = true;
            this.totalProgressGrpLabel.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.totalProgressGrpLabel.Location = new Point(14, 1);
            this.totalProgressGrpLabel.Name = "totalProgressGrpLabel";
            this.totalProgressGrpLabel.Size = new Size(0x4f, 12);
            this.totalProgressGrpLabel.TabIndex = 100;
            this.totalProgressGrpLabel.Text = "Total Progress";
            this.totalProgressGrpLabel.TextChanged += new EventHandler(this.totalProgressGrpLabel_TextChanged);
            this.progressBarTotal.Location = new Point(7, 0x11);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new Size(0x16a, 0x10);
            this.progressBarTotal.TabIndex = 0x63;
            this.groupDirFiles.Controls.Add(this.checkBoxSubDirs);
            this.groupDirFiles.Controls.Add(this.txtFileLocIn);
            this.groupDirFiles.Controls.Add(this.btnBrowseIn);
            this.groupDirFiles.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupDirFiles.Location = new Point(4, 0x29);
            this.groupDirFiles.Name = "groupDirFiles";
            this.groupDirFiles.Size = new Size(360, 0x42);
            this.groupDirFiles.TabIndex = 0x6d;
            this.groupDirFiles.TabStop = false;
            this.checkBoxSubDirs.AutoSize = true;
            this.checkBoxSubDirs.Checked = true;
            this.checkBoxSubDirs.CheckState = CheckState.Checked;
            this.checkBoxSubDirs.Cursor = Cursors.Hand;
            this.checkBoxSubDirs.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxSubDirs.Location = new Point(10, 0x2e);
            this.checkBoxSubDirs.Name = "checkBoxSubDirs";
            this.checkBoxSubDirs.Size = new Size(130, 0x10);
            this.checkBoxSubDirs.TabIndex = 90;
            this.checkBoxSubDirs.Text = "Scan Sub Directories";
            this.checkBoxSubDirs.UseVisualStyleBackColor = true;
            this.txtFileLocIn.Location = new Point(10, 0x13);
            this.txtFileLocIn.Name = "txtFileLocIn";
            this.txtFileLocIn.ReadOnly = true;
            this.txtFileLocIn.Size = new Size(0x123, 0x15);
            this.txtFileLocIn.TabIndex = 0x5b;
            this.btnBrowseIn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnBrowseIn.Cursor = Cursors.Hand;
            this.btnBrowseIn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseIn.Location = new Point(0x133, 0x13);
            this.btnBrowseIn.Name = "btnBrowseIn";
            this.btnBrowseIn.Size = new Size(0x24, 20);
            this.btnBrowseIn.TabIndex = 90;
            this.btnBrowseIn.Text = "...";
            this.btnBrowseIn.UseVisualStyleBackColor = true;
            this.btnBrowseIn.Click += new EventHandler(this.btnBrowseIn_Click);
            this.radioDirFiles.AutoSize = true;
            this.radioDirFiles.BackColor = Color.White;
            this.radioDirFiles.Checked = true;
            this.radioDirFiles.Cursor = Cursors.Hand;
            this.radioDirFiles.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioDirFiles.Location = new Point(13, 0x29);
            this.radioDirFiles.Name = "radioDirFiles";
            this.radioDirFiles.Size = new Size(0x84, 0x10);
            this.radioDirFiles.TabIndex = 0x5c;
            this.radioDirFiles.TabStop = true;
            this.radioDirFiles.Text = "Add Directory of Files";
            this.radioDirFiles.UseVisualStyleBackColor = false;
            this.tabsCollections.Controls.Add(this.tabPage2);
            this.tabsCollections.Controls.Add(this.tabPageAdd);
            this.tabsCollections.Controls.Add(this.tabPage1);
            this.tabsCollections.Controls.Add(this.tabPage3);
            this.tabsCollections.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabsCollections.ImageList = this.imageList1;
            this.tabsCollections.Location = new Point(3, 6);
            this.tabsCollections.Name = "tabsCollections";
            this.tabsCollections.SelectedIndex = 0;
            this.tabsCollections.Size = new Size(0x17a, 0x133);
            this.tabsCollections.TabIndex = 0x75;
            this.tabsCollections.SelectedIndexChanged += new EventHandler(this.tabsCollections_SelectedIndexChanged);
            this.tabPage2.Controls.Add(this.btnCreateCollection);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtDbName);
            this.tabPage2.Controls.Add(this.txtFileLocOut);
            this.tabPage2.Controls.Add(this.btnBrowseOut);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new Point(4, 0x17);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(370, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "New Collection";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.btnCreateCollection.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnCreateCollection.Cursor = Cursors.Hand;
            this.btnCreateCollection.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnCreateCollection.Image = Resources.Checkicon;
            this.btnCreateCollection.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnCreateCollection.Location = new Point(0xe2, 0xcb);
            this.btnCreateCollection.Name = "btnCreateCollection";
            this.btnCreateCollection.Padding = new Padding(3);
            this.btnCreateCollection.Size = new Size(0x8a, 30);
            this.btnCreateCollection.TabIndex = 0x76;
            this.btnCreateCollection.Text = "Create Collection";
            this.btnCreateCollection.TextAlign = ContentAlignment.MiddleRight;
            this.btnCreateCollection.UseVisualStyleBackColor = true;
            this.btnCreateCollection.Click += new EventHandler(this.btnCreateCollection_Click);
            this.groupBox2.Controls.Add(this.compressionSelect);
            this.groupBox2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox2.Location = new Point(6, 0x99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x165, 0x30);
            this.groupBox2.TabIndex = 0x74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repack Options";
            this.label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(4, 0x24);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3e, 0x17);
            this.label2.TabIndex = 0x60;
            this.label2.Text = "Directory";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            this.groupBox1.Controls.Add(this.chk3DSprefix);
            this.groupBox1.Controls.Add(this.radioRomNumbers);
            this.groupBox1.Controls.Add(this.radioRomScene);
            this.groupBox1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox1.Location = new Point(6, 0x47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x165, 0x4c);
            this.groupBox1.TabIndex = 0x75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rename Options";
            this.chk3DSprefix.AutoSize = true;
            this.chk3DSprefix.Cursor = Cursors.Hand;
            this.chk3DSprefix.Font = new Font("Verdana", 6.75f);
            this.chk3DSprefix.Location = new Point(20, 0x29);
            this.chk3DSprefix.Name = "chk3DSprefix";
            this.chk3DSprefix.Size = new Size(0xe9, 0x1c);
            this.chk3DSprefix.TabIndex = 0x66;
            this.chk3DSprefix.Text = "Append 3DS roms with number prefix.\r\n(recommended when combining with NDS)";
            this.chk3DSprefix.UseVisualStyleBackColor = true;
            this.label1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(-3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x45, 0x17);
            this.label1.TabIndex = 0x5f;
            this.label1.Text = "Name";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            this.txtDbName.Location = new Point(0x48, 12);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new Size(0xef, 0x12);
            this.txtDbName.TabIndex = 0x5e;
            this.txtFileLocOut.Location = new Point(0x48, 0x26);
            this.txtFileLocOut.Name = "txtFileLocOut";
            this.txtFileLocOut.ReadOnly = true;
            this.txtFileLocOut.Size = new Size(0xef, 0x12);
            this.txtFileLocOut.TabIndex = 0x5d;
            this.btnBrowseOut.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnBrowseOut.Cursor = Cursors.Hand;
            this.btnBrowseOut.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseOut.Location = new Point(0x13a, 0x25);
            this.btnBrowseOut.Name = "btnBrowseOut";
            this.btnBrowseOut.Size = new Size(0x24, 20);
            this.btnBrowseOut.TabIndex = 0x5c;
            this.btnBrowseOut.Text = "...";
            this.btnBrowseOut.UseVisualStyleBackColor = true;
            this.btnBrowseOut.Click += new EventHandler(this.btnBrowseOut_Click);
            this.tabPageAdd.Controls.Add(this.radioDirFiles);
            this.tabPageAdd.Controls.Add(this.radioSingleFile);
            this.tabPageAdd.Controls.Add(this.groupSingleFile);
            this.tabPageAdd.Controls.Add(this.groupBoxRename);
            this.tabPageAdd.Controls.Add(this.label5);
            this.tabPageAdd.Controls.Add(this.listCollections);
            this.tabPageAdd.Controls.Add(this.groupDirFiles);
            this.tabPageAdd.Controls.Add(this.startBatchBtn);
            this.tabPageAdd.ImageIndex = 1;
            this.tabPageAdd.Location = new Point(4, 0x17);
            this.tabPageAdd.Name = "tabPageAdd";
            this.tabPageAdd.Padding = new Padding(3);
            this.tabPageAdd.Size = new Size(370, 280);
            this.tabPageAdd.TabIndex = 0;
            this.tabPageAdd.Text = "Add Files";
            this.tabPageAdd.UseVisualStyleBackColor = true;
            this.radioSingleFile.AutoSize = true;
            this.radioSingleFile.BackColor = Color.White;
            this.radioSingleFile.Cursor = Cursors.Hand;
            this.radioSingleFile.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioSingleFile.Location = new Point(12, 0x71);
            this.radioSingleFile.Name = "radioSingleFile";
            this.radioSingleFile.Size = new Size(0x6d, 0x10);
            this.radioSingleFile.TabIndex = 0x5d;
            this.radioSingleFile.TabStop = true;
            this.radioSingleFile.Text = "Add A Single File";
            this.radioSingleFile.UseVisualStyleBackColor = false;
            this.radioSingleFile.CheckedChanged += new EventHandler(this.radioSingleFile_CheckedChanged);
            this.groupSingleFile.Controls.Add(this.txtFileLocIn2);
            this.groupSingleFile.Controls.Add(this.btnBrowseSingleIn);
            this.groupSingleFile.Enabled = false;
            this.groupSingleFile.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupSingleFile.Location = new Point(7, 0x71);
            this.groupSingleFile.Name = "groupSingleFile";
            this.groupSingleFile.Size = new Size(360, 0x38);
            this.groupSingleFile.TabIndex = 110;
            this.groupSingleFile.TabStop = false;
            this.txtFileLocIn2.Location = new Point(10, 0x13);
            this.txtFileLocIn2.Name = "txtFileLocIn2";
            this.txtFileLocIn2.ReadOnly = true;
            this.txtFileLocIn2.Size = new Size(0x123, 0x15);
            this.txtFileLocIn2.TabIndex = 0x5b;
            this.btnBrowseSingleIn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnBrowseSingleIn.Cursor = Cursors.Hand;
            this.btnBrowseSingleIn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseSingleIn.Location = new Point(0x133, 0x13);
            this.btnBrowseSingleIn.Name = "btnBrowseSingleIn";
            this.btnBrowseSingleIn.Size = new Size(0x24, 20);
            this.btnBrowseSingleIn.TabIndex = 90;
            this.btnBrowseSingleIn.Text = "...";
            this.btnBrowseSingleIn.UseVisualStyleBackColor = true;
            this.btnBrowseSingleIn.Click += new EventHandler(this.btnBrowseSingleIn_Click);
            this.label5.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(-4, 10);
            this.label5.Name = "label5";
            this.label5.Size = new Size(70, 0x17);
            this.label5.TabIndex = 0x62;
            this.label5.Text = "Name";
            this.label5.TextAlign = ContentAlignment.MiddleRight;
            this.listCollections.Cursor = Cursors.Hand;
            this.listCollections.FormattingEnabled = true;
            this.listCollections.Location = new Point(0x48, 12);
            this.listCollections.Name = "listCollections";
            this.listCollections.Size = new Size(0xef, 20);
            this.listCollections.TabIndex = 0;
            this.listCollections.SelectedIndexChanged += new EventHandler(this.listCollections_SelectedIndexChanged);
            this.startBatchBtn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.startBatchBtn.Cursor = Cursors.Hand;
            this.startBatchBtn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.startBatchBtn.Image = Resources.Checkicon;
            this.startBatchBtn.ImageAlign = ContentAlignment.MiddleLeft;
            this.startBatchBtn.Location = new Point(0xe2, 0xf6);
            this.startBatchBtn.Name = "startBatchBtn";
            this.startBatchBtn.Padding = new Padding(3);
            this.startBatchBtn.Size = new Size(0x8a, 30);
            this.startBatchBtn.TabIndex = 110;
            this.startBatchBtn.Text = "Add To Collection";
            this.startBatchBtn.TextAlign = ContentAlignment.MiddleRight;
            this.startBatchBtn.UseVisualStyleBackColor = true;
            this.startBatchBtn.Click += new EventHandler(this.startBatchBtn_Click);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.btnEdit);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupRename2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtFileLocOut2);
            this.tabPage1.Controls.Add(this.btnBrowseOut2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.listDelCollections);
            this.tabPage1.Controls.Add(this.txtDbName2);
            this.tabPage1.Controls.Add(this.btnApplyChange);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new Point(4, 0x17);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(370, 280);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Modify";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.groupBox4.Controls.Add(this.compressionSelect2);
            this.groupBox4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox4.Location = new Point(6, 0x80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0x165, 0x30);
            this.groupBox4.TabIndex = 0x7f;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Repack Options";
            this.compressionSelect2.Cursor = Cursors.Hand;
            this.compressionSelect2.Enabled = false;
            this.compressionSelect2.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.compressionSelect2.FormattingEnabled = true;
            object[] objArray2 = new object[] { "No Repack (.nds | .3ds)", "7-Zip (.7z)", "WinZip (.zip)" };
            this.compressionSelect2.Items.AddRange(objArray2);
            this.compressionSelect2.Location = new Point(6, 20);
            this.compressionSelect2.Name = "compressionSelect2";
            this.compressionSelect2.Size = new Size(0xdd, 20);
            this.compressionSelect2.TabIndex = 0x61;
            this.btnEdit.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnEdit.Location = new Point(0x13a, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(0x24, 20);
            this.btnEdit.TabIndex = 0x7e;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.label4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(4, 0x24);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x3e, 0x17);
            this.label4.TabIndex = 0x7a;
            this.label4.Text = "Directory";
            this.label4.TextAlign = ContentAlignment.MiddleRight;
            this.groupRename2.Controls.Add(this.chk3DSprefix2);
            this.groupRename2.Controls.Add(this.radioRomNumbers2);
            this.groupRename2.Controls.Add(this.radioRomScene2);
            this.groupRename2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupRename2.Location = new Point(6, 0x3e);
            this.groupRename2.Name = "groupRename2";
            this.groupRename2.Size = new Size(0x165, 0x40);
            this.groupRename2.TabIndex = 0x7c;
            this.groupRename2.TabStop = false;
            this.groupRename2.Text = "Rename Options";
            this.chk3DSprefix2.AutoSize = true;
            this.chk3DSprefix2.Cursor = Cursors.Hand;
            this.chk3DSprefix2.Enabled = false;
            this.chk3DSprefix2.Font = new Font("Verdana", 6.75f);
            this.chk3DSprefix2.Location = new Point(20, 0x29);
            this.chk3DSprefix2.Name = "chk3DSprefix2";
            this.chk3DSprefix2.Size = new Size(0xd1, 0x10);
            this.chk3DSprefix2.TabIndex = 0x67;
            this.chk3DSprefix2.Text = "Append 3DS roms with number prefix";
            this.chk3DSprefix2.UseVisualStyleBackColor = true;
            this.radioRomNumbers2.AutoSize = true;
            this.radioRomNumbers2.Checked = true;
            this.radioRomNumbers2.Cursor = Cursors.Hand;
            this.radioRomNumbers2.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioRomNumbers2.Location = new Point(20, 20);
            this.radioRomNumbers2.Name = "radioRomNumbers2";
            this.radioRomNumbers2.Size = new Size(0x76, 0x10);
            this.radioRomNumbers2.TabIndex = 100;
            this.radioRomNumbers2.TabStop = true;
            this.radioRomNumbers2.Text = "Numbering System";
            this.radioRomNumbers2.UseVisualStyleBackColor = true;
            this.radioRomScene2.AutoSize = true;
            this.radioRomScene2.Cursor = Cursors.Hand;
            this.radioRomScene2.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioRomScene2.Location = new Point(0x90, 20);
            this.radioRomScene2.Name = "radioRomScene2";
            this.radioRomScene2.Size = new Size(0x5f, 0x10);
            this.radioRomScene2.TabIndex = 0x65;
            this.radioRomScene2.Text = "Scene System";
            this.radioRomScene2.UseVisualStyleBackColor = true;
            this.label6.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.Location = new Point(-3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x45, 0x17);
            this.label6.TabIndex = 0x79;
            this.label6.Text = "Name";
            this.label6.TextAlign = ContentAlignment.MiddleRight;
            this.txtFileLocOut2.Location = new Point(0x48, 0x26);
            this.txtFileLocOut2.Name = "txtFileLocOut2";
            this.txtFileLocOut2.ReadOnly = true;
            this.txtFileLocOut2.Size = new Size(0xef, 0x12);
            this.txtFileLocOut2.TabIndex = 0x77;
            this.btnBrowseOut2.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnBrowseOut2.Cursor = Cursors.Hand;
            this.btnBrowseOut2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseOut2.Location = new Point(0x13a, 0x25);
            this.btnBrowseOut2.Name = "btnBrowseOut2";
            this.btnBrowseOut2.Size = new Size(0x24, 20);
            this.btnBrowseOut2.TabIndex = 0x76;
            this.btnBrowseOut2.Text = "...";
            this.btnBrowseOut2.UseVisualStyleBackColor = true;
            this.groupBox3.Controls.Add(this.radioButtonDeleteFiles);
            this.groupBox3.Controls.Add(this.radioButtonKeepFiles);
            this.groupBox3.Controls.Add(this.buttonDeleteCollection);
            this.groupBox3.Controls.Add(this.txtDelCollectionWarn);
            this.groupBox3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox3.Location = new Point(6, 0xcd);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x165, 0x48);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Delete Collection";
            this.radioButtonDeleteFiles.AutoSize = true;
            this.radioButtonDeleteFiles.Cursor = Cursors.Hand;
            this.radioButtonDeleteFiles.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioButtonDeleteFiles.Location = new Point(0x66, 20);
            this.radioButtonDeleteFiles.Name = "radioButtonDeleteFiles";
            this.radioButtonDeleteFiles.Size = new Size(0x53, 0x10);
            this.radioButtonDeleteFiles.TabIndex = 5;
            this.radioButtonDeleteFiles.Text = "Delete Files";
            this.radioButtonDeleteFiles.UseVisualStyleBackColor = true;
            this.radioButtonKeepFiles.AutoSize = true;
            this.radioButtonKeepFiles.Checked = true;
            this.radioButtonKeepFiles.Cursor = Cursors.Hand;
            this.radioButtonKeepFiles.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.radioButtonKeepFiles.Location = new Point(6, 20);
            this.radioButtonKeepFiles.Name = "radioButtonKeepFiles";
            this.radioButtonKeepFiles.Size = new Size(0x4b, 0x10);
            this.radioButtonKeepFiles.TabIndex = 4;
            this.radioButtonKeepFiles.TabStop = true;
            this.radioButtonKeepFiles.Text = "Keep Files";
            this.radioButtonKeepFiles.UseVisualStyleBackColor = true;
            this.radioButtonKeepFiles.CheckedChanged += new EventHandler(this.radioButtonKeepFiles_CheckedChanged);
            this.buttonDeleteCollection.Cursor = Cursors.Hand;
            this.buttonDeleteCollection.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.buttonDeleteCollection.Image = Resources.bin_metal_full;
            this.buttonDeleteCollection.Location = new Point(0x121, 40);
            this.buttonDeleteCollection.Name = "buttonDeleteCollection";
            this.buttonDeleteCollection.Size = new Size(0x3e, 0x1a);
            this.buttonDeleteCollection.TabIndex = 2;
            this.buttonDeleteCollection.Text = "Delete";
            this.buttonDeleteCollection.TextAlign = ContentAlignment.MiddleLeft;
            this.buttonDeleteCollection.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.buttonDeleteCollection.UseVisualStyleBackColor = true;
            this.buttonDeleteCollection.Click += new EventHandler(this.buttonDeleteCollection_Click);
            this.txtDelCollectionWarn.Font = new Font("Verdana", 6.75f, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.txtDelCollectionWarn.ForeColor = Color.Gray;
            this.txtDelCollectionWarn.Location = new Point(4, 0x21);
            this.txtDelCollectionWarn.Name = "txtDelCollectionWarn";
            this.txtDelCollectionWarn.Size = new Size(0x117, 40);
            this.txtDelCollectionWarn.TabIndex = 3;
            this.txtDelCollectionWarn.Text = "The database will be removed from the application.\nRom files will NOT be deleted.";
            this.txtDelCollectionWarn.TextAlign = ContentAlignment.MiddleLeft;
            this.listDelCollections.Cursor = Cursors.Hand;
            this.listDelCollections.FormattingEnabled = true;
            this.listDelCollections.Location = new Point(0x48, 12);
            this.listDelCollections.Name = "listDelCollections";
            this.listDelCollections.Size = new Size(0xef, 20);
            this.listDelCollections.TabIndex = 1;
            this.listDelCollections.SelectedIndexChanged += new EventHandler(this.listCollections_SelectedIndexChanged);
            this.txtDbName2.Location = new Point(0x48, 12);
            this.txtDbName2.Name = "txtDbName2";
            this.txtDbName2.Size = new Size(0xef, 0x12);
            this.txtDbName2.TabIndex = 120;
            this.txtDbName2.Visible = false;
            this.btnApplyChange.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnApplyChange.Cursor = Cursors.Hand;
            this.btnApplyChange.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnApplyChange.Image = Resources.Checkicon;
            this.btnApplyChange.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnApplyChange.Location = new Point(0xed, 0xb0);
            this.btnApplyChange.Name = "btnApplyChange";
            this.btnApplyChange.Padding = new Padding(3);
            this.btnApplyChange.Size = new Size(0x7f, 30);
            this.btnApplyChange.TabIndex = 0x7d;
            this.btnApplyChange.Text = "Apply Changes";
            this.btnApplyChange.TextAlign = ContentAlignment.MiddleRight;
            this.btnApplyChange.UseVisualStyleBackColor = true;
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.btnUpdateWeb);
            this.tabPage3.Controls.Add(this.btnCleanColDb);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.listScanCollections);
            this.tabPage3.Controls.Add(this.btnCleanDir);
            this.tabPage3.ImageIndex = 3;
            this.tabPage3.Location = new Point(4, 0x17);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new Padding(3);
            this.tabPage3.Size = new Size(370, 280);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Scan";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.label9.ForeColor = Color.DarkGray;
            this.label9.Location = new Point(150, 0x3b);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0xd6, 0x1b);
            this.label9.TabIndex = 0x69;
            this.label9.Text = "Scans and re-organises all files in the collection directory. Database is updated.";
            this.label8.ForeColor = Color.DarkGray;
            this.label8.Location = new Point(150, 0x99);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0xd6, 0x1b);
            this.label8.TabIndex = 0x68;
            this.label8.Text = "Tries to download any missing, new or corrupt DS-Scene information.";
            this.label7.ForeColor = Color.DarkGray;
            this.label7.Location = new Point(150, 0x69);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0xd6, 0x1b);
            this.label7.TabIndex = 0x67;
            this.label7.Text = "Removes any missing files from the database. Files are left untouched.";
            this.btnUpdateWeb.Cursor = Cursors.Hand;
            this.btnUpdateWeb.Image = Resources.favicon;
            this.btnUpdateWeb.Location = new Point(11, 0x99);
            this.btnUpdateWeb.Name = "btnUpdateWeb";
            this.btnUpdateWeb.Padding = new Padding(4, 0, 0, 0);
            this.btnUpdateWeb.Size = new Size(0x87, 0x1b);
            this.btnUpdateWeb.TabIndex = 0x66;
            this.btnUpdateWeb.Text = " Update Information";
            this.btnUpdateWeb.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnUpdateWeb.UseVisualStyleBackColor = true;
            this.btnUpdateWeb.Click += new EventHandler(this.btnUpdateWeb_Click);
            this.btnCleanColDb.Cursor = Cursors.Hand;
            this.btnCleanColDb.Image = Resources.clean_collection;
            this.btnCleanColDb.Location = new Point(11, 0x69);
            this.btnCleanColDb.Name = "btnCleanColDb";
            this.btnCleanColDb.Size = new Size(0x87, 0x1b);
            this.btnCleanColDb.TabIndex = 0x65;
            this.btnCleanColDb.Text = " Clean Database";
            this.btnCleanColDb.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnCleanColDb.UseVisualStyleBackColor = true;
            this.btnCleanColDb.Click += new EventHandler(this.btnCleanColDb_Click);
            this.label3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(-4, 10);
            this.label3.Name = "label3";
            this.label3.Size = new Size(70, 0x17);
            this.label3.TabIndex = 100;
            this.label3.Text = "Name";
            this.label3.TextAlign = ContentAlignment.MiddleRight;
            this.listScanCollections.Cursor = Cursors.Hand;
            this.listScanCollections.FormattingEnabled = true;
            this.listScanCollections.Location = new Point(0x48, 12);
            this.listScanCollections.Name = "listScanCollections";
            this.listScanCollections.Size = new Size(0xef, 20);
            this.listScanCollections.TabIndex = 0x63;
            this.listScanCollections.SelectedIndexChanged += new EventHandler(this.listCollections_SelectedIndexChanged);
            this.btnCleanDir.Cursor = Cursors.Hand;
            this.btnCleanDir.Enabled = false;
            this.btnCleanDir.Image = Resources.clean_dir;
            this.btnCleanDir.Location = new Point(11, 0x3b);
            this.btnCleanDir.Name = "btnCleanDir";
            this.btnCleanDir.Padding = new Padding(4, 0, 0, 0);
            this.btnCleanDir.Size = new Size(0x87, 0x1b);
            this.btnCleanDir.TabIndex = 0;
            this.btnCleanDir.Text = " Rebuild Collection";
            this.btnCleanDir.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnCleanDir.UseVisualStyleBackColor = true;
            this.btnCleanDir.Click += new EventHandler(this.btnCleanDir_Click);
            this.imageList1.ImageStream = (ImageListStreamer) manager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "create.png");
            this.imageList1.Images.SetKeyName(1, "new.png");
            this.imageList1.Images.SetKeyName(2, "wrench_screwdriver.png");
            this.imageList1.Images.SetKeyName(3, "magnifier.png");
            this.cancelBatchBtn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.cancelBatchBtn.Cursor = Cursors.Hand;
            this.cancelBatchBtn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cancelBatchBtn.Image = Resources.crossicon;
            this.cancelBatchBtn.ImageAlign = ContentAlignment.MiddleLeft;
            this.cancelBatchBtn.Location = new Point(0xba, 0x13b);
            this.cancelBatchBtn.Name = "cancelBatchBtn";
            this.cancelBatchBtn.Padding = new Padding(3);
            this.cancelBatchBtn.Size = new Size(0x7d, 30);
            this.cancelBatchBtn.TabIndex = 0x70;
            this.cancelBatchBtn.Text = "Cancel Process";
            this.cancelBatchBtn.TextAlign = ContentAlignment.MiddleRight;
            this.cancelBatchBtn.UseVisualStyleBackColor = true;
            this.cancelBatchBtn.Click += new EventHandler(this.cancelBatchBtn_Click);
            this.buttonClose.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonClose.Cursor = Cursors.Hand;
            this.buttonClose.DialogResult = DialogResult.Cancel;
            this.buttonClose.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.buttonClose.Image = Resources.crossicon;
            this.buttonClose.ImageAlign = ContentAlignment.MiddleLeft;
            this.buttonClose.Location = new Point(0x138, 0x13b);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new Padding(3);
            this.buttonClose.Size = new Size(0x45, 30);
            this.buttonClose.TabIndex = 0x71;
            this.buttonClose.Text = "Close";
            this.buttonClose.TextAlign = ContentAlignment.MiddleRight;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.label10.ForeColor = Color.Maroon;
            this.label10.Location = new Point(0x97, 0x56);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0xd6, 0x13);
            this.label10.TabIndex = 0x6a;
            this.label10.Text = "Will be added later";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x181, 0x1ab);
            base.Controls.Add(this.cancelBatchBtn);
            base.Controls.Add(this.tabsCollections);
            base.Controls.Add(this.buttonClose);
            base.Controls.Add(this.stageProgressGrp);
            base.Controls.Add(this.totalProgressGrp);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "batchOrganiseForm";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Collection Organiser";
            this.groupBoxRename.ResumeLayout(false);
            this.groupBoxRename.PerformLayout();
            this.stageProgressGrp.ResumeLayout(false);
            this.stageProgressGrp.PerformLayout();
            this.totalProgressGrp.ResumeLayout(false);
            this.totalProgressGrp.PerformLayout();
            this.groupDirFiles.ResumeLayout(false);
            this.groupDirFiles.PerformLayout();
            this.tabsCollections.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageAdd.ResumeLayout(false);
            this.tabPageAdd.PerformLayout();
            this.groupSingleFile.ResumeLayout(false);
            this.groupSingleFile.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupRename2.ResumeLayout(false);
            this.groupRename2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void listCollections_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox) sender;
            this.listScanCollections.SelectedIndex = box.SelectedIndex;
            this.listDelCollections.SelectedIndex = box.SelectedIndex;
            this.listCollections.SelectedIndex = box.SelectedIndex;
            this.disableEditCollection();
            if (box != null)
            {
                if (box.SelectedIndex <= -1)
                {
                    this.disableEditCollection();
                }
                else if (!Program.form.collectiondb.selectDatabase(box.SelectedItem.ToString()))
                {
                    MessageBox.Show("There was an error selecting the database", "Database Select Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.btnEdit.Visible = true;
                    this.txtDbName2.Text = Program.form.collectiondb.db[Program.form.collectiondb.activeDb].fn;
                    this.txtFileLocOut2.Text = Program.form.collectiondb.db[Program.form.collectiondb.activeDb].root;
                    if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].type == "numbered")
                    {
                        this.radioRomNumbers2.Checked = true;
                        this.radioRomScene2.Checked = false;
                    }
                    else
                    {
                        this.radioRomNumbers2.Checked = false;
                        this.radioRomScene2.Checked = true;
                    }
                    this.chk3DSprefix2.Checked = Program.form.collectiondb.db[Program.form.collectiondb.activeDb].n3dsRomNumPrefix;
                    this.compressionSelect2.SelectedIndex = int.Parse(Program.form.collectiondb.db[Program.form.collectiondb.activeDb].romExt);
                }
            }
            string s = Program.form.options.getValue("active_collection_db");
            if (s == "")
            {
                s = "-1";
            }
            if ((Program.form.collectiondb.activeDb != -1) && (Program.form.collectiondb.activeDb != int.Parse(s)))
            {
                Program.form.options.save();
                Program.form.options.load();
            }
        }

        private bool organiseProcess(string outputFolder)
        {
            bool flag;
            this.startProcessTimer();
            string path = Path.Combine(outputFolder, "log.txt");
            try
            {
                while (true)
                {
                    if (!System.IO.File.Exists(path))
                    {
                        this.writeBatchLog(outputFolder, "----------------------------------------------------------------------------");
                        this.writeBatchLog(outputFolder, "DS-Scene Rom Tool v1.0 build 1215 Organise Process Log");
                        DateTime now = DateTime.Now;
                        this.writeBatchLog(outputFolder, "Generated " + $"{now:F}");
                        this.writeBatchLog(outputFolder, "----------------------------------------------------------------------------");
                        break;
                    }
                    System.IO.File.Delete(path);
                }
            }
            catch
            {
                MessageBox.Show("The log file could not be created, please check the file is not in use already.\n\n" + path, "Batch Process Halted", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            dsromHeader romHeader = Program.form.romHeader;
            this.stageProgressGrpLabel.Text = "File Progress (Scanning Directories)";
            Application.DoEvents();
            this.filesToProcess = new string[0x61a8];
            int num = 1;
            if (!this.radioSingleFile.Checked)
            {
                num = this.countValidFilesInSelectedDir();
            }
            else
            {
                this.filesToProcess[0] = this.txtFileLocIn2.Text;
            }
            int num2 = 0;
            if (num <= 0)
            {
                this.stageProgressGrpLabel.Text = "File Progress (no files)";
                this.progressBarStage.Value = this.progressBarStage.Maximum;
                this.totalProgressGrpLabel.Text = "Total Progress (failed)";
                this.progressBarTotal.Value = this.progressBarTotal.Maximum;
                Application.DoEvents();
                this.filesToProcess = null;
                this.endProcessTimer();
                Program.form.romHeader = romHeader;
                return false;
            }
            this.progressBarTotal.Maximum = num * 10;
            this.progressBarTotal.Value = 0;
            Application.DoEvents();
            int num3 = 0;
            string[] filesToProcess = this.filesToProcess;
            int index = 0;
            while (true)
            {
                if (index < filesToProcess.Length)
                {
                    string fileName = filesToProcess[index];
                    this.totalProgressGrpLabel.Text = "Total Progress " + Program.form.run.hexAndMathFunction.getPercentage(this.progressBarTotal.Value, this.progressBarTotal.Maximum) + "%";
                    Application.DoEvents();
                    if (!this.cancelled)
                    {
                        if (fileName != null)
                        {
                            long num4 = this.processOrganiseSingleFile(fileName, outputFolder);
                            if (num4 == -1L)
                            {
                                this.filesToProcess = null;
                                Program.form.romHeader = romHeader;
                                flag = false;
                                break;
                            }
                            if (num4 == 1L)
                            {
                                num3++;
                            }
                            num2++;
                            this.progressBarTotal.Value = num2 * 10;
                            Program.form.collectiondb.saveAll();
                            Program.form.crcDb.writeDb();
                        }
                        Application.DoEvents();
                        index++;
                        continue;
                    }
                }
                this.buildDbCombos();
                this.stageProgressGrpLabel.Text = !this.cancelled ? "File Progress (complete)" : "File Progress (cancelled)";
                this.progressBarStage.Value = this.progressBarStage.Maximum;
                this.totalProgressGrpLabel.Text = "Total Progress (completed organise process on " + num3 + " files)";
                if (this.progressBarTotal.Maximum == 0)
                {
                    this.progressBarTotal.Maximum = 1;
                }
                this.progressBarTotal.Value = this.progressBarTotal.Maximum;
                Application.DoEvents();
                this.filesToProcess = null;
                if (num2 == 0)
                {
                    MessageBox.Show("There are no valid files in the folder selected.\n\nValid extensions are .nds, .rar, .zip and .7z\n\nTry scanning sub directories", "Organise Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    string text = "";
                    string caption = "";
                    string str5 = "";
                    if (num3 != 0)
                    {
                        str5 = str5 + num3 + " files were processed successfully\n";
                    }
                    if ((num - num2) != 0)
                    {
                        str5 = str5 + (num - num2) + " files were skipped\n";
                    }
                    if ((num2 - num3) != 0)
                    {
                        str5 = str5 + (num2 - num3) + " files processed with errors\n";
                    }
                    str5 = str5 + "\nFor a more detailed log of this organise job, please see log.txt which was created in the output directory";
                    if (this.cancelled)
                    {
                        text = "The organise process was cancelled\n\n" + str5;
                        caption = "Organise Process Cancelled";
                    }
                    else
                    {
                        text = "The organise process completed\n\n" + str5;
                        caption = "Organise Process Cancelled";
                    }
                    MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                Program.form.romHeader = romHeader;
                return true;
            }
            return flag;
        }

        private long processOrganiseSingleFile(string fileName, string outputFolder)
        {
            long num2;
            string str5;
            string str6;
            string str7;
            romDirType type;
            webInfo.webInfoClass class2;
            string str8;
            bool flag5;
            bool flag6;
            int num4;
            string str13;
            string str14;
            int num5;
            webInfo.webInfoItemClass[] item;
            int num7;
            int num = this.progressBarTotal.Value;
            string arcType = Program.form.getFileExtension(fileName);
            string str2 = fileName;
            bool delete = true;
            bool flag2 = false;
            string str3 = "";
            if (this.allowCompress)
            {
                switch (int.Parse(Program.form.collectiondb.db[Program.form.collectiondb.activeDb].romExt))
                {
                    case 1:
                        str3 = "7z";
                        break;

                    case 2:
                        str3 = "zip";
                        break;

                    default:
                        break;
                }
            }
            string str15 = arcType;
            if (str15 == null)
            {
                goto TR_0004;
            }
            else
            {
                if (str15 == "rar")
                {
                    flag2 = true;
                }
                else if (str15 == "zip")
                {
                    if (str3 != "zip")
                    {
                        flag2 = true;
                    }
                }
                else if (str15 == "7z")
                {
                    if (str3 != "7z")
                    {
                        flag2 = true;
                    }
                }
                else if ((str15 != "nds") && (str15 != "3ds"))
                {
                    goto TR_0004;
                }
                this.increaseTotalProgress();
                bool flag3 = false;
                if (!flag2)
                {
                    if (((arcType == "zip") && (str3 == "zip")) || (((arcType == "7z") && (str3 == "7z")) || ((arcType == "rar") && (str3 == "rar"))))
                    {
                        flag3 = true;
                    }
                }
                else
                {
                    string str4 = "/data/temp/";
                    if (Path.GetDirectoryName(Application.ExecutablePath).Replace('\\', '+') != Path.GetDirectoryName(Application.ExecutablePath))
                    {
                        str4 = str4.Replace('/', '\\');
                    }
                    if (!Program.form.extractRom(fileName, Path.GetDirectoryName(Application.ExecutablePath) + str4, arcType, this.progressBarStage, this.stageProgressGrpLabel))
                    {
                        while ((num + 8) > this.progressBarTotal.Value)
                        {
                            this.increaseTotalProgress();
                        }
                        return (long) (-2);
                    }
                    flag3 = true;
                    fileName = Path.GetDirectoryName(Application.ExecutablePath) + str4 + Program.form.compressor.extracting_file;
                }
                this.increaseTotalProgress();
                if (flag3)
                {
                    Program.form.waitForFreeMemory(this.stageProgressGrpLabel);
                    Program.form.romHeader.romHeader.hash = Program.form.compressedRomCRC(str2, arcType, this.progressBarStage, this.stageProgressGrpLabel, "nds");
                    if (Program.form.romHeader.romHeader.hash == "")
                    {
                        Program.form.romHeader.romHeader.hash = Program.form.compressedRomCRC(str2, arcType, this.progressBarStage, this.stageProgressGrpLabel, "3ds");
                    }
                    Program.form.waitForFreeMemory(this.stageProgressGrpLabel);
                }
                else
                {
                    Program.form.waitForFreeMemory(this.stageProgressGrpLabel);
                    Program.form.romHeader.romHeader.hash = "";
                    if (!Program.form.checkCrc32(fileName, this.progressBarStage, this.stageProgressGrpLabel))
                    {
                        return (long) (-40);
                    }
                    Program.form.waitForFreeMemory(this.stageProgressGrpLabel);
                    Program.form.romHeader.romHeader.hash = Program.form.crchash;
                }
                this.increaseTotalProgress();
                Program.form.romHeader.loadRomHeader(fileName, true);
                bool flag4 = false;
                num2 = 0L;
                this.increaseTotalProgress();
                str5 = Program.form.origFileLocToNewFileName(fileName, false, false, outputFolder);
                str6 = outputFolder;
                str7 = Path.Combine(str6, str5);
                type = new romDirType();
                if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].type == "numbered")
                {
                    type.type = dirStructType.numbered;
                }
                if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].type == "scene")
                {
                    type.type = dirStructType.scene;
                }
                if (flag4)
                {
                    goto TR_0020;
                }
                else
                {
                    Program.form.romHeader.romHeader.cleanCrc = Program.form.crcDb.crcToCleanCrc(Program.form.romHeader.romHeader.hash.ToUpper());
                    if ((Program.form.romHeader.romHeader.cleanCrc == null) || (Program.form.romHeader.romHeader.cleanCrc.hash == ""))
                    {
                        Program.form.romHeader.romHeader.cleanCrc = new crcDupes.possibleCrcType();
                        Program.form.romHeader.romHeader.cleanCrc.hash = Program.form.romHeader.romHeader.hash.ToUpper();
                        Program.form.romHeader.romHeader.cleanCrc.type = crcDupes.romTypes.unknown;
                    }
                    class2 = new webInfo.webInfoClass();
                    if (!Program.form.web.validateWebInfo(Program.form.romHeader.romHeader.cleanCrc.hash))
                    {
                        Program.form.downloadInfoFromWebsite(Program.form.romHeader.romHeader.cleanCrc.type, Program.form.romHeader.romHeader.cleanCrc.hash, this.progressBarStage, this.stageProgressGrpLabel, false, true);
                    }
                    class2 = Program.form.web.parseWebInfo(Program.form.romHeader.romHeader.cleanCrc.hash);
                    str8 = str6;
                    flag5 = false;
                    flag6 = false;
                    if ((class2 == null) || (class2.item[0] == null))
                    {
                        MessageBox.Show("web info not ok");
                        type.type = dirStructType.unknown;
                        str3 = "";
                        goto TR_0042;
                    }
                    else
                    {
                        item = class2.item;
                        num7 = 0;
                    }
                }
            }
            goto TR_006C;
        TR_0004:
            MessageBox.Show("Invalid file found in organise stream: " + fileName, "Organise Job Terminated", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            while ((num + 8) > this.progressBarTotal.Value)
            {
                this.increaseTotalProgress();
            }
            return -1L;
        TR_0007:
            if (((num2 > 0L) || (num2 == -41)) && ((type.type != dirStructType.unknown) && (type.type != dirStructType.dupe)))
            {
                Program.form.collectiondb.addItem(str7, Program.form.romHeader.romHeader.hash, Program.form.romHeader.romHeader.gameCode, true, false);
            }
            return num2;
        TR_0008:
            System.IO.File.Delete(str2);
            goto TR_0007;
        TR_0009:
            num4++;
        TR_0018:
            while (true)
            {
                if (num4 < 100)
                {
                    str14 = num4;
                    if (num4 < 10)
                    {
                        str14 = "0" + str14;
                    }
                    if (System.IO.File.Exists(str13 + "r" + str14))
                    {
                        num5 = 0x3e8;
                        break;
                    }
                }
                goto TR_0008;
            }
            while (true)
            {
                while (true)
                {
                    if (num5 > 0)
                    {
                        try
                        {
                            System.IO.File.Delete(str13 + "r" + str14);
                        }
                        catch (Exception exception)
                        {
                            if (num5 == 1)
                            {
                                MessageBox.Show("Could not delete: " + str13 + "r" + str14 + "\n\n" + exception.Message);
                            }
                            break;
                        }
                        goto TR_0009;
                    }
                    else
                    {
                        goto TR_0009;
                    }
                    break;
                }
                num5--;
            }
        TR_0020:
            this.increaseTotalProgress();
            if (str3 != "")
            {
                str7 = str7.Substring(0, str7.LastIndexOf('.') + 1) + str3;
            }
            this.writeBatchLog(outputFolder, string.Concat(new object[] { "[Processed] [", Program.form.romExportError(num2, str7, true), " ", num2, "] [orig:", str2, "]" }));
            this.increaseTotalProgress();
            if (flag2)
            {
                Program.form.cleanTempFiles();
            }
            if (!this.checkBoxDelete.Checked || (num2 <= 0L))
            {
                goto TR_0007;
            }
            else if (Program.form.getFileExtension(str2) != "rar")
            {
                goto TR_0008;
            }
            else
            {
                str13 = str2.Substring(0, str2.LastIndexOf('.') + 1);
                num4 = 0;
            }
            goto TR_0018;
        TR_0042:
            if (type.type == dirStructType.unknown)
            {
                if (this.checkBoxIgnoreUnknown.Checked)
                {
                    flag5 = true;
                    num2 = -42;
                }
                if (!flag5)
                {
                    str6 = (str8.Replace('\\', '+') == str8) ? (str8.Substring(0, str8.LastIndexOf('/')) + "/_unknown" + str8.Substring(str8.LastIndexOf('/'), str8.Length - str8.LastIndexOf('/'))) : (str8.Substring(0, str8.LastIndexOf('\\')) + @"\_unknown" + str8.Substring(str8.LastIndexOf('\\'), str8.Length - str8.LastIndexOf('\\')));
                }
            }
            else if ((Directory.Exists(str6) || System.IO.File.Exists(Path.Combine(str6, str5))) && !Program.form.collectiondb.inCollection(Path.Combine(str6, str5)))
            {
                if (this.checkBoxIgnoreDupes.Checked)
                {
                    flag5 = true;
                    num2 = -41;
                    if (flag6)
                    {
                        num2 = -43;
                    }
                }
                if (!flag5)
                {
                    type.type = dirStructType.dupe;
                    str6 = (str8.Replace('\\', '+') == str8) ? (str8.Substring(0, str8.LastIndexOf('/')) + "/_duplicates" + str8.Substring(str8.LastIndexOf('/'), str8.Length - str8.LastIndexOf('/'))) : (str8.Substring(0, str8.LastIndexOf('\\')) + @"\_duplicates" + str8.Substring(str8.LastIndexOf('\\'), str8.Length - str8.LastIndexOf('\\')));
                }
            }
            if (!flag5)
            {
                if (!Directory.Exists(str6))
                {
                    Directory.CreateDirectory(str6);
                }
                else if ((type.type == dirStructType.unknown) || (type.type == dirStructType.dupe))
                {
                    int num3 = 1;
                    string path = str6;
                    while (true)
                    {
                        if (!Directory.Exists(path))
                        {
                            str6 = path;
                            Directory.CreateDirectory(str6);
                            break;
                        }
                        object[] objArray = new object[] { str6, "(", num3, ")" };
                        path = string.Concat(objArray);
                        num3++;
                    }
                }
                str7 = Path.Combine(str6, Program.form.longFileName(str5, str6.Length));
                delete = false;
                if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].romExt != "0")
                {
                    delete = true;
                }
                this.increaseTotalProgress();
                if ((((str3 == "") || !str2.EndsWith(str3)) && ((str3 != "") || !str2.EndsWith("nds"))) && ((str3 != "") || !str2.EndsWith("3ds")))
                {
                    num2 = Program.form.doExportRomAction(fileName, str7, apPatcherAppForm.romTrimTypes.none, false, str3, delete, this.progressBarStage, this.stageProgressGrpLabel, true, true);
                }
                else
                {
                    if (str3 != "")
                    {
                        str7 = str7.Substring(0, str7.LastIndexOf('.') + 1) + str3;
                    }
                    System.IO.File.Copy(str2, str7);
                    num2 = !System.IO.File.Exists(str7) ? ((long) (-44)) : 1L;
                }
            }
            goto TR_0020;
        TR_0043:
            num7++;
        TR_006C:
            while (true)
            {
                if (num7 < item.Length)
                {
                    webInfo.webInfoItemClass class3 = item[num7];
                    if (flag6)
                    {
                        goto TR_0042;
                    }
                    else if (class3 != null)
                    {
                        string key = class3.key;
                        if (key != null)
                        {
                            int num8;
                            if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000025-1 == null)
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
                                dictionary1.Add("n3dsopt", 0x11);
                                dictionary1.Add("nfolink", 0x12);
                                <PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000025-1 = dictionary1;
                            }
                            if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000025-1.TryGetValue(key, out num8))
                            {
                                switch (num8)
                                {
                                    case 0:
                                        type.type = dirStructType.unknown;
                                        str8 = str8 + str5.Substring(0, str5.LastIndexOf('.'));
                                        flag6 = true;
                                        goto TR_0043;

                                    case 1:
                                        type.type = dirStructType.unknown;
                                        str8 = str8 + str5.Substring(0, str5.LastIndexOf('.'));
                                        flag6 = true;
                                        goto TR_0043;

                                    case 2:
                                        if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].type == "numbered")
                                        {
                                            if (class3.val == "")
                                            {
                                                type.type = dirStructType.unknown;
                                            }
                                            else
                                            {
                                                string val = class3.val;
                                                if (class3.val.StartsWith("3DS") && !Program.form.collectiondb.db[Program.form.collectiondb.activeDb].n3dsRomNumPrefix)
                                                {
                                                    val = class3.val.Substring(3, class3.val.Length - 3);
                                                }
                                                str6 = str6 + this.romnumToFolder(val);
                                                str6 = (str6.Replace('\\', '+') == str6) ? (str6 + "/") : (str6 + @"\");
                                                if (!Directory.Exists(str6))
                                                {
                                                    Directory.CreateDirectory(str6);
                                                }
                                                str6 = str6 + Program.form.web.replaceIllegalFilenameCharacters(val) + " - ";
                                                str8 = str8 + Program.form.web.replaceIllegalFilenameCharacters(val) + " - ";
                                            }
                                        }
                                        goto TR_0043;

                                    case 3:
                                        if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].type == "numbered")
                                        {
                                            str6 = str6 + Program.form.web.replaceIllegalFilenameCharacters(class3.val) + " ";
                                            str8 = str8 + Program.form.web.replaceIllegalFilenameCharacters(class3.val) + " ";
                                        }
                                        goto TR_0043;

                                    case 4:
                                        if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].type == "numbered")
                                        {
                                            str6 = str6 + "(" + Program.form.web.replaceIllegalFilenameCharacters(class3.val) + ")";
                                            str8 = str8 + "(" + Program.form.web.replaceIllegalFilenameCharacters(class3.val) + ")";
                                        }
                                        goto TR_0043;

                                    case 5:
                                    case 8:
                                    case 9:
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                    case 14:
                                    case 0x10:
                                    case 0x11:
                                    case 0x12:
                                        goto TR_0043;

                                    case 6:
                                    {
                                        string str10 = ((class2.item[0].key != "romnum") || !class2.item[0].val.ToUpper().StartsWith("3DS")) ? this.fixWebsiteFileName(class3.val, "nds") : this.fixWebsiteFileName(class3.val, "3ds");
                                        if (str10 == "")
                                        {
                                            type.type = dirStructType.unknown;
                                        }
                                        else
                                        {
                                            str5 = str10;
                                        }
                                        goto TR_0043;
                                    }
                                    case 7:
                                        if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].type == "scene")
                                        {
                                            if (class3.val == "")
                                            {
                                                MessageBox.Show("web no dir name");
                                                type.type = dirStructType.unknown;
                                            }
                                            else
                                            {
                                                str6 = str6 + Program.form.web.replaceIllegalFilenameCharacters(class3.val);
                                                str8 = str8 + Program.form.web.replaceIllegalFilenameCharacters(class3.val);
                                            }
                                        }
                                        goto TR_0043;

                                    case 15:
                                        class3.val = this.romRegionChange(class3.val);
                                        if (Program.form.collectiondb.db[Program.form.collectiondb.activeDb].type == "numbered")
                                        {
                                            str6 = str6 + "(" + Program.form.web.replaceIllegalFilenameCharacters(class3.val) + ") ";
                                        }
                                        else
                                        {
                                            str6 = (str6.Replace('\\', '+') == str6) ? (str6 + "/") : (str6 + @"\");
                                            str6 = str6 + Program.form.web.replaceIllegalFilenameCharacters(class3.val);
                                            str6 = (str6.Replace('\\', '+') == str6) ? (str6 + "/") : (str6 + @"\");
                                            str6 = Program.form.run.hexAndMathFunction.string_replace(@"\\", @"\", str6);
                                            str6 = Program.form.run.hexAndMathFunction.string_replace("//", "/", str6);
                                            if (!Directory.Exists(str6))
                                            {
                                                Directory.CreateDirectory(str6);
                                            }
                                        }
                                        goto TR_0043;

                                    default:
                                        break;
                                }
                            }
                        }
                        MessageBox.Show("Unsupported webInfo value '" + class3.key + "'\n\nThe data retrieved from the website was corrupt", "Sorry, we messed up :(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        System.IO.File.Delete("data/web/info/" + Program.form.romHeader.romHeader.cleanCrc.hash + "_info.dsapdb");
                        flag6 = true;
                    }
                }
                else
                {
                    goto TR_0042;
                }
                break;
            }
            goto TR_0043;
        }

        private void radioButtonKeepFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonKeepFiles.Checked)
            {
                this.txtDelCollectionWarn.Text = "The database will be removed from the application.\nRom files will NOT be deleted.";
                this.txtDelCollectionWarn.ForeColor = Color.Gray;
            }
            else
            {
                this.txtDelCollectionWarn.Text = "The database will be removed from the application.\nALL FILES WILL BE DELETED.";
                this.txtDelCollectionWarn.ForeColor = Color.Red;
            }
        }

        private void radioRomNumbers_CheckedChanged(object sender, EventArgs e)
        {
            this.chk3DSprefix.Enabled = true;
        }

        private void radioRomScene_CheckedChanged(object sender, EventArgs e)
        {
            this.chk3DSprefix.Enabled = false;
            this.chk3DSprefix.Checked = false;
        }

        private void radioSingleFile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioSingleFile.Checked)
            {
                this.groupSingleFile.Enabled = true;
                this.groupDirFiles.Enabled = false;
                this.txtFileLocIn.Text = "";
            }
            else
            {
                this.groupSingleFile.Enabled = false;
                this.groupDirFiles.Enabled = true;
                this.txtFileLocIn2.Text = "";
            }
        }

        private void resetProgressBars()
        {
            this.stageProgressGrpLabel.Text = "File Progress";
            this.totalProgressGrpLabel.Text = "Total Progress";
            this.progressBarStage.Value = 0;
            this.progressBarTotal.Value = 0;
        }

        public string romnumToFolder(string num)
        {
            if (num.Substring(num.Length - 4, 4) == "XXXX")
            {
                return num;
            }
            int num2 = int.Parse(num.Substring(num.Length - 4, 4));
            string str = num.Substring(0, num.Length - 4);
            int num3 = 0;
            int num4 = 250;
            int num5 = 0x3e8;
            while (true)
            {
                if (num5 > 0)
                {
                    int num6 = (num3 * num4) + 1;
                    if ((num2 < num6) || (num2 >= (num6 + num4)))
                    {
                        num5--;
                        num3++;
                        continue;
                    }
                    str = str + $"{num6:D4}" + "-" + $"{((num6 + num4) - 1):D4}";
                }
                return str;
            }
        }

        public string romRegionChange(string rgn)
        {
            string key = rgn;
            if (key != null)
            {
                int num;
                if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000024-1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(0x11);
                    dictionary1.Add("as", 0);
                    dictionary1.Add("ch", 1);
                    dictionary1.Add("da", 2);
                    dictionary1.Add("eu", 3);
                    dictionary1.Add("fr", 4);
                    dictionary1.Add("gm", 5);
                    dictionary1.Add("nl", 6);
                    dictionary1.Add("it", 7);
                    dictionary1.Add("ja", 8);
                    dictionary1.Add("ks", 9);
                    dictionary1.Add("no", 10);
                    dictionary1.Add("rs", 11);
                    dictionary1.Add("sp", 12);
                    dictionary1.Add("uk", 13);
                    dictionary1.Add("uni", 14);
                    dictionary1.Add("us", 15);
                    dictionary1.Add("enus", 0x10);
                    <PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000024-1 = dictionary1;
                }
                if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000024-1.TryGetValue(key, out num))
                {
                    switch (num)
                    {
                        case 0:
                            return "AUS";

                        case 1:
                            return "CHI";

                        case 2:
                            return "DEN";

                        case 3:
                            return "EUR";

                        case 4:
                            return "FRA";

                        case 5:
                            return "GER";

                        case 6:
                            return "HOL";

                        case 7:
                            return "ITA";

                        case 8:
                            return "JPN";

                        case 9:
                            return "KOR";

                        case 10:
                            return "NOR";

                        case 11:
                            return "RUS";

                        case 12:
                            return "SPA";

                        case 13:
                            return "UK";

                        case 14:
                            return "UNIVERSAL";

                        case 15:
                            return "USA";

                        case 0x10:
                            return "EUSA";

                        default:
                            break;
                    }
                }
            }
            return ("REGION_UNKNOWN_" + rgn);
        }

        private void stageProgressGrpLabel_TextChanged(object sender, EventArgs e)
        {
            if (this.processing)
            {
                this.trimElapsedTimeFromProgress();
                TimeSpan span = DateTime.Now.Subtract(this.processStart);
                this.totalProgressGrpLabel.Text = this.totalProgressGrpLabel.Text + " [Elapsed: ";
                if (span.Days > 0)
                {
                    this.totalProgressGrpLabel.Text = this.totalProgressGrpLabel.Text + span.Days + "d ";
                }
                string[] strArray = new string[] { this.totalProgressGrpLabel.Text, $"{span.Hours:D2}", ":", $"{span.Minutes:D2}", ":", $"{span.Seconds:D2}", "] [Remaining: ", this.processEndGuess, "]" };
                this.totalProgressGrpLabel.Text = string.Concat(strArray);
            }
        }

        private void startBatchBtn_Click(object sender, EventArgs e)
        {
            string path = "";
            if (this.radioDirFiles.Checked && (this.txtFileLocIn.Text == ""))
            {
                MessageBox.Show("You must select an input directory", "Input Directory Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.radioSingleFile.Checked && (this.txtFileLocIn2.Text == ""))
            {
                MessageBox.Show("You must select an input file", "Input File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.listCollections.SelectedIndex < 0)
            {
                if (this.listCollections.Items.Count == 0)
                {
                    MessageBox.Show("There are no collections available, create a new collection", "Collection Not Available", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    MessageBox.Show("You must select a collection or choose to create a new collection", "Collection Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else if (!Program.form.collectiondb.selectDatabase(this.listCollections.SelectedItem.ToString()))
            {
                MessageBox.Show("Failed to select the database:\n\n" + this.listCollections.SelectedItem.ToString(), "Failed To Select Collection Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                path = Path.Combine(Program.form.collectiondb.db[this.listCollections.SelectedIndex].root, Program.form.collectiondb.db[this.listCollections.SelectedIndex].fn);
                if (!Directory.Exists(path))
                {
                    MessageBox.Show("The selected collection is unavailable\n\nThe directory does not exist:\n\n" + path, "Collection Not Available", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    path = (path.Replace('\\', '+') == path) ? (path + "/") : (path + @"\");
                    this.cancelled = false;
                    this.buttonClose.Enabled = false;
                    this.txtFileLocIn.Enabled = false;
                    this.txtFileLocOut.Enabled = false;
                    this.startBatchBtn.Enabled = false;
                    this.cancelBatchBtn.Visible = true;
                    this.cancelBatchBtn.Enabled = true;
                    this.btnBrowseIn.Enabled = false;
                    this.btnBrowseOut.Enabled = false;
                    this.checkBoxSubDirs.Enabled = false;
                    this.compressionSelect.Enabled = false;
                    this.checkBoxDelete.Enabled = false;
                    this.groupBoxRename.Enabled = false;
                    this.tabsCollections.Enabled = false;
                    patchdb.patchdb_PatchClass patchInfo = Program.form.patchInfo;
                    dsromHeader romHeader = Program.form.romHeader;
                    this.resetProgressBars();
                    if (!this.organiseProcess(path))
                    {
                        MessageBox.Show("The batch process failed\nPlease check the log in the output directory for more information", "Batch Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    this.txtFileLocIn.Enabled = true;
                    this.txtFileLocOut.Enabled = true;
                    this.startBatchBtn.Enabled = true;
                    this.cancelBatchBtn.Visible = false;
                    this.btnBrowseIn.Enabled = true;
                    this.btnBrowseOut.Enabled = true;
                    this.checkBoxSubDirs.Enabled = true;
                    this.buttonClose.Enabled = true;
                    this.groupBoxRename.Enabled = true;
                    this.tabsCollections.Enabled = true;
                    if (this.allowCompress)
                    {
                        this.compressionSelect.Enabled = true;
                        this.checkBoxDelete.Enabled = true;
                    }
                    Program.form.patchInfo = patchInfo;
                    Program.form.romHeader = romHeader;
                    if (this.tabsCollections.SelectedIndex == 0)
                    {
                        this.listCollections.Items.Add(this.txtDbName.Text);
                    }
                    this.listCollections.Enabled = true;
                }
            }
        }

        private void startProcessTimer()
        {
            this.processStart = DateTime.Now;
            this.processEndGuess = "calculating...";
            this.processing = true;
        }

        private void tabsCollections_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabsCollections.SelectedIndex)
            {
                case 0:
                    this.listCollections_SelectedIndexChanged(this.listCollections, null);
                    return;

                case 1:
                    this.listCollections_SelectedIndexChanged(this.listCollections, null);
                    return;

                case 2:
                    this.listCollections_SelectedIndexChanged(this.listDelCollections, null);
                    return;

                case 3:
                    this.listCollections_SelectedIndexChanged(this.listScanCollections, null);
                    return;
            }
        }

        private void totalProgressGrpLabel_TextChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(this.processStart);
            if ((this.progressBarTotal.Value > 0) && (span.TotalSeconds > 0.0))
            {
                long lastRecordedProgressBarVal = 0L;
                if (this.lastRecordedProgressBar == this.progressBarTotal.Value)
                {
                    lastRecordedProgressBarVal = this.lastRecordedProgressBarVal;
                }
                else
                {
                    this.lastRecordedProgressDate = now;
                    this.lastRecordedProgressBar = this.progressBarTotal.Value;
                    lastRecordedProgressBarVal = (long) ((this.progressBarTotal.Maximum / this.progressBarTotal.Value) * ((decimal) span.TotalSeconds));
                    this.lastRecordedProgressBarVal = lastRecordedProgressBarVal;
                }
                this.processEndGuess = "";
                now.Subtract(this.lastRecordedProgressDate);
                this.processEndGuess = "";
                int num2 = (int) (lastRecordedProgressBarVal - span.TotalSeconds);
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                if (num2 >= 60)
                {
                    num3 = (int) Math.Floor((decimal) (num2 / 60));
                    num2 -= num3 * 60;
                    if (num3 >= 60)
                    {
                        num4 = (int) Math.Floor((decimal) (num3 / 60));
                        num3 -= num4 * 60;
                        if (num4 >= 0x18)
                        {
                            num5 = (int) Math.Floor((decimal) (num4 / 0x18));
                            num4 -= num5 * 0x18;
                        }
                    }
                }
                if (num5 > 0)
                {
                    this.processEndGuess = this.processEndGuess + num5 + "d ";
                }
                this.processEndGuess = this.processEndGuess + $"{num4:D2}" + ":";
                this.processEndGuess = this.processEndGuess + $"{num3:D2}" + ":";
                this.processEndGuess = this.processEndGuess + $"{num2:D2}";
                if (num2 < 0)
                {
                    this.processEndGuess = "??:??:??";
                }
            }
        }

        private void trimElapsedTimeFromProgress()
        {
            if (Program.form.run.hexAndMathFunction.string_replace(" [Elapsed", "", this.totalProgressGrpLabel.Text) != this.totalProgressGrpLabel.Text)
            {
                this.totalProgressGrpLabel.Text = this.totalProgressGrpLabel.Text.Substring(0, this.totalProgressGrpLabel.Text.LastIndexOf('['));
                this.totalProgressGrpLabel.Text = this.totalProgressGrpLabel.Text.Substring(0, this.totalProgressGrpLabel.Text.LastIndexOf('['));
                this.totalProgressGrpLabel.Text = this.totalProgressGrpLabel.Text.Substring(0, this.totalProgressGrpLabel.Text.Length - 1);
            }
        }

        private int webCollectionUpdate()
        {
            this.cancelled = false;
            this.buttonClose.Enabled = false;
            this.tabsCollections.Enabled = false;
            this.cancelBatchBtn.Visible = true;
            this.cancelBatchBtn.Enabled = true;
            dsromHeader romHeader = Program.form.romHeader;
            this.startProcessTimer();
            this.progressBarTotal.Value = 0;
            this.progressBarTotal.Maximum = Program.form.collectiondb.db[Program.form.collectiondb.activeDb].filled;
            int num = 0;
            bool flag = false;
            for (int i = 0; (i < Program.form.collectiondb.db[Program.form.collectiondb.activeDb].filled) && !this.cancelled; i++)
            {
                this.progressBarTotal.Value++;
                this.totalProgressGrpLabel.Text = "Total Progress " + Program.form.run.hexAndMathFunction.getPercentage(this.progressBarTotal.Value, this.progressBarTotal.Maximum) + "%";
                this.stageProgressGrpLabel_TextChanged(null, null);
                Application.DoEvents();
                if (!Program.form.web.validateWebInfo(Program.form.collectiondb.db[Program.form.collectiondb.activeDb].item[i].crc.ToUpper()))
                {
                    crcDupes.possibleCrcType type = new crcDupes.possibleCrcType();
                    type = Program.form.crcDb.crcToCleanCrc(Program.form.collectiondb.db[Program.form.collectiondb.activeDb].item[i].crc.ToUpper());
                    if ((type == null) || (type.hash == ""))
                    {
                        type = new crcDupes.possibleCrcType {
                            hash = Program.form.collectiondb.db[Program.form.collectiondb.activeDb].item[i].crc.ToUpper(),
                            type = crcDupes.romTypes.unknown
                        };
                    }
                    if (Program.form.downloadInfoFromWebsite(type.type, type.hash, this.progressBarStage, this.stageProgressGrpLabel, false, true))
                    {
                        string str = Program.form.collectiondb.db[Program.form.collectiondb.activeDb].item[i].gameLoc.Substring(0, Program.form.collectiondb.db[Program.form.collectiondb.activeDb].item[i].gameLoc.LastIndexOf("."));
                        if (System.IO.File.Exists(str + ".nfo") && System.IO.File.Exists("data/web/nfo/" + type.hash))
                        {
                            System.IO.File.Delete(str + ".nfo");
                        }
                        if (System.IO.File.Exists("data/web/nfo/" + type.hash))
                        {
                            System.IO.File.Copy("data/web/nfo/" + type.hash + ".nfo", str + ".nfo");
                        }
                        num++;
                        int num3 = 0;
                        while (true)
                        {
                            if (num3 >= 0x186a0)
                            {
                                if (!Program.form.web.validateWebInfo(type.hash.ToUpper()) && !flag)
                                {
                                    MessageBox.Show("Invalid info downloaded, you should clean the collection directory", "Invalid Web Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    flag = true;
                                }
                                break;
                            }
                            this.stageProgressGrpLabel.Text = "Delaying...";
                            Application.DoEvents();
                            num3++;
                        }
                    }
                }
            }
            this.endProcessTimer();
            this.buttonClose.Enabled = true;
            this.tabsCollections.Enabled = true;
            this.cancelBatchBtn.Visible = false;
            this.cancelBatchBtn.Enabled = false;
            Program.form.romHeader = romHeader;
            Program.form.collectionForm.refreshNfos = true;
            Program.form.collectiondb.load();
            return num;
        }

        private void writeBatchLog(string outputFolder, string txt)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(outputFolder, "log.txt"), true))
            {
                writer.WriteLine(txt);
            }
        }

        public enum dirStructType
        {
            unknown,
            dupe,
            numbered,
            scene
        }

        public class romDirType
        {
            public batchOrganiseForm.dirStructType type;
            public string region = "";
        }
    }
}

