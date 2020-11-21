namespace apPatcherApp
{
    using apPatcherApp.Properties;
    using dsRomHeaderFunctions;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class batchPatchForm : Form
    {
        private IContainer components;
        public TextBox txtFileLocOut;
        private Button btnBrowseOut;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        public TextBox txtFileLocIn;
        private Button btnBrowseIn;
        private ProgressBar progressBarTotal;
        private GroupBox totalProgressGrp;
        private GroupBox stageProgressGrp;
        private ProgressBar progressBarStage;
        private Button startBatchBtn;
        private CheckBox checkBoxSubDirs;
        private Label stageProgressGrpLabel;
        private Label totalProgressGrpLabel;
        private Button cancelBatchBtn;
        private Button buttonClose;
        private GroupBox groupBox5;
        private CheckBox checkBoxDelete;
        private ComboBox compressionSelect;
        private GroupBox groupBox4;
        private RadioButton radioAccurateTrim;
        private CheckBox checkBoxTrim;
        private RadioButton radioSafeTrim;
        private GroupBox groupBox1;
        private CheckBox checkBoxApPatch;
        private string[] filesToProcess = new string[0x61a8];
        public bool cancelled;
        public bool allowCompress = true;

        public batchPatchForm()
        {
            base.MaximizeBox = false;
            this.InitializeComponent();
        }

        private bool batchProcess()
        {
            bool flag;
            string path = Path.Combine(this.txtFileLocOut.Text, "log.txt");
            try
            {
                while (true)
                {
                    if (!System.IO.File.Exists(path))
                    {
                        this.writeBatchLog("----------------------------------------------------------------------------");
                        this.writeBatchLog("DS-Scene Rom Tool v1.0 build 1215 Batch Process Log");
                        DateTime now = DateTime.Now;
                        this.writeBatchLog("Generated " + $"{now:F}");
                        this.writeBatchLog("----------------------------------------------------------------------------");
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
            this.stageProgressGrpLabel.Text = "File Progress (Scanning Directories)";
            Application.DoEvents();
            this.filesToProcess = new string[0x61a8];
            int num = this.countValidFilesInSelectedDir();
            int num2 = 0;
            if (num == -1)
            {
                this.stageProgressGrpLabel.Text = "File Progress (no files)";
                this.progressBarStage.Value = this.progressBarStage.Maximum;
                this.totalProgressGrpLabel.Text = "Total Progress (failed)";
                this.progressBarTotal.Value = this.progressBarTotal.Maximum;
                Application.DoEvents();
                this.filesToProcess = null;
                return false;
            }
            this.progressBarTotal.Maximum = num * 8;
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
                            long num4 = this.processBatchSingleFile(fileName);
                            if (num4 == -1L)
                            {
                                this.filesToProcess = null;
                                flag = false;
                                break;
                            }
                            if (num4 == 1L)
                            {
                                num3++;
                            }
                            num2++;
                            this.progressBarTotal.Value = num2 * 8;
                        }
                        Application.DoEvents();
                        index++;
                        continue;
                    }
                }
                Program.form.crcDb.writeDb();
                this.stageProgressGrpLabel.Text = !this.cancelled ? "File Progress (complete)" : "File Progress (cancelled)";
                this.progressBarStage.Value = this.progressBarStage.Maximum;
                this.totalProgressGrpLabel.Text = "Total Progress (completed batch process on " + num3 + " files)";
                if (this.progressBarTotal.Maximum == 0)
                {
                    this.progressBarTotal.Maximum = 1;
                }
                this.progressBarTotal.Value = this.progressBarTotal.Maximum;
                Application.DoEvents();
                this.filesToProcess = null;
                if (num2 == 0)
                {
                    MessageBox.Show("There are no valid files in the folder selected.\n\nValid extensions are .nds, .rar, .zip and .7z\n\nTry scanning sub directories", "Batch Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    str5 = str5 + "\nFor a more detailed log of this batch job, please see log.txt which was created in the output directory";
                    if (this.cancelled)
                    {
                        text = "The batch process was cancelled\n\n" + str5;
                        caption = "Batch Process Cancelled";
                    }
                    else
                    {
                        text = "The batch process completed\n\n" + str5;
                        caption = "Batch Process Cancelled";
                    }
                    MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return true;
            }
            return flag;
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

        private void cancelBatchBtn_Click(object sender, EventArgs e)
        {
            this.cancelBatchBtn.Enabled = false;
            this.cancelled = true;
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
            this.startBatchBtn.Focus();
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
                else if ((Program.form.getFileExtension(str) == "rar") || ((Program.form.getFileExtension(str) == "zip") || ((Program.form.getFileExtension(str) == "7z") || (Program.form.getFileExtension(str) == "nds"))))
                {
                    this.filesToProcess[index] = str;
                    index++;
                }
            }
            strArray = null;
            return index;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void formSetup()
        {
            this.txtFileLocIn.Text = "";
            this.txtFileLocOut.Text = "";
            this.resetProgressBars();
            this.cancelBatchBtn.Visible = false;
            this.cancelled = false;
            if (Program.form.zipInstalled)
            {
                this.allowCompress = true;
                this.compressionSelect.Enabled = true;
                this.compressionSelect.SelectedIndex = 0;
                this.checkBoxDelete.Enabled = false;
            }
            else
            {
                this.allowCompress = false;
                this.compressionSelect.Enabled = false;
                this.compressionSelect.SelectedIndex = 0;
                this.checkBoxDelete.Enabled = false;
                this.checkBoxDelete.Checked = false;
            }
        }

        public void increaseTotalProgress()
        {
            this.progressBarTotal.Value++;
            this.totalProgressGrpLabel.Text = "Total Progress (" + Program.form.run.hexAndMathFunction.getPercentage(this.progressBarTotal.Value, this.progressBarTotal.Maximum) + "%)";
            Application.DoEvents();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(batchPatchForm));
            this.txtFileLocOut = new TextBox();
            this.btnBrowseOut = new Button();
            this.groupBox2 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.checkBoxSubDirs = new CheckBox();
            this.txtFileLocIn = new TextBox();
            this.btnBrowseIn = new Button();
            this.progressBarTotal = new ProgressBar();
            this.totalProgressGrp = new GroupBox();
            this.totalProgressGrpLabel = new Label();
            this.stageProgressGrp = new GroupBox();
            this.stageProgressGrpLabel = new Label();
            this.progressBarStage = new ProgressBar();
            this.startBatchBtn = new Button();
            this.cancelBatchBtn = new Button();
            this.buttonClose = new Button();
            this.groupBox5 = new GroupBox();
            this.checkBoxDelete = new CheckBox();
            this.compressionSelect = new ComboBox();
            this.groupBox4 = new GroupBox();
            this.radioAccurateTrim = new RadioButton();
            this.checkBoxTrim = new CheckBox();
            this.radioSafeTrim = new RadioButton();
            this.groupBox1 = new GroupBox();
            this.checkBoxApPatch = new CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.totalProgressGrp.SuspendLayout();
            this.stageProgressGrp.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.txtFileLocOut.Location = new Point(10, 0x13);
            this.txtFileLocOut.Name = "txtFileLocOut";
            this.txtFileLocOut.ReadOnly = true;
            this.txtFileLocOut.Size = new Size(0x143, 0x15);
            this.txtFileLocOut.TabIndex = 0x5b;
            this.btnBrowseOut.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnBrowseOut.Cursor = Cursors.Hand;
            this.btnBrowseOut.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseOut.Location = new Point(0x14f, 0x13);
            this.btnBrowseOut.Name = "btnBrowseOut";
            this.btnBrowseOut.Size = new Size(0x24, 20);
            this.btnBrowseOut.TabIndex = 90;
            this.btnBrowseOut.Text = "...";
            this.btnBrowseOut.UseVisualStyleBackColor = true;
            this.btnBrowseOut.Click += new EventHandler(this.btnBrowseOut_Click);
            this.groupBox2.Controls.Add(this.txtFileLocOut);
            this.groupBox2.Controls.Add(this.btnBrowseOut);
            this.groupBox2.Location = new Point(10, 0xeb);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x177, 0x31);
            this.groupBox2.TabIndex = 0x61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Directory";
            this.groupBox3.Controls.Add(this.checkBoxSubDirs);
            this.groupBox3.Controls.Add(this.txtFileLocIn);
            this.groupBox3.Controls.Add(this.btnBrowseIn);
            this.groupBox3.Location = new Point(9, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x178, 0x42);
            this.groupBox3.TabIndex = 0x62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input Directory";
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
            this.txtFileLocIn.Size = new Size(0x143, 0x15);
            this.txtFileLocIn.TabIndex = 0x5b;
            this.btnBrowseIn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnBrowseIn.Cursor = Cursors.Hand;
            this.btnBrowseIn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnBrowseIn.Location = new Point(0x150, 0x13);
            this.btnBrowseIn.Name = "btnBrowseIn";
            this.btnBrowseIn.Size = new Size(0x24, 20);
            this.btnBrowseIn.TabIndex = 90;
            this.btnBrowseIn.Text = "...";
            this.btnBrowseIn.UseVisualStyleBackColor = true;
            this.btnBrowseIn.Click += new EventHandler(this.btnBrowseIn_Click);
            this.progressBarTotal.Location = new Point(7, 20);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new Size(0x16a, 0x10);
            this.progressBarTotal.TabIndex = 0x63;
            this.totalProgressGrp.Controls.Add(this.totalProgressGrpLabel);
            this.totalProgressGrp.Controls.Add(this.progressBarTotal);
            this.totalProgressGrp.Location = new Point(8, 390);
            this.totalProgressGrp.Name = "totalProgressGrp";
            this.totalProgressGrp.Size = new Size(0x178, 0x2e);
            this.totalProgressGrp.TabIndex = 100;
            this.totalProgressGrp.TabStop = false;
            this.totalProgressGrpLabel.AutoSize = true;
            this.totalProgressGrpLabel.Location = new Point(14, 1);
            this.totalProgressGrpLabel.Name = "totalProgressGrpLabel";
            this.totalProgressGrpLabel.Size = new Size(0x59, 13);
            this.totalProgressGrpLabel.TabIndex = 100;
            this.totalProgressGrpLabel.Text = "Total Progress";
            this.stageProgressGrp.Controls.Add(this.stageProgressGrpLabel);
            this.stageProgressGrp.Controls.Add(this.progressBarStage);
            this.stageProgressGrp.Location = new Point(9, 0x156);
            this.stageProgressGrp.Name = "stageProgressGrp";
            this.stageProgressGrp.Size = new Size(0x178, 0x2e);
            this.stageProgressGrp.TabIndex = 0x65;
            this.stageProgressGrp.TabStop = false;
            this.stageProgressGrpLabel.AutoSize = true;
            this.stageProgressGrpLabel.Location = new Point(12, 1);
            this.stageProgressGrpLabel.Name = "stageProgressGrpLabel";
            this.stageProgressGrpLabel.Size = new Size(80, 13);
            this.stageProgressGrpLabel.TabIndex = 100;
            this.stageProgressGrpLabel.Text = "File Progress";
            this.progressBarStage.Location = new Point(7, 20);
            this.progressBarStage.Name = "progressBarStage";
            this.progressBarStage.Size = new Size(0x16a, 0x10);
            this.progressBarStage.TabIndex = 0x63;
            this.startBatchBtn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.startBatchBtn.Cursor = Cursors.Hand;
            this.startBatchBtn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.startBatchBtn.Image = Resources.Checkicon;
            this.startBatchBtn.ImageAlign = ContentAlignment.MiddleLeft;
            this.startBatchBtn.Location = new Point(190, 290);
            this.startBatchBtn.Name = "startBatchBtn";
            this.startBatchBtn.Padding = new Padding(3);
            this.startBatchBtn.Size = new Size(0x7d, 30);
            this.startBatchBtn.TabIndex = 0x5c;
            this.startBatchBtn.Text = "Start Batch Job";
            this.startBatchBtn.TextAlign = ContentAlignment.MiddleRight;
            this.startBatchBtn.UseVisualStyleBackColor = true;
            this.startBatchBtn.Click += new EventHandler(this.startBatchBtn_Click);
            this.cancelBatchBtn.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.cancelBatchBtn.Cursor = Cursors.Hand;
            this.cancelBatchBtn.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cancelBatchBtn.Image = Resources.crossicon;
            this.cancelBatchBtn.ImageAlign = ContentAlignment.MiddleLeft;
            this.cancelBatchBtn.Location = new Point(0x3f, 290);
            this.cancelBatchBtn.Name = "cancelBatchBtn";
            this.cancelBatchBtn.Padding = new Padding(3);
            this.cancelBatchBtn.Size = new Size(0x7d, 30);
            this.cancelBatchBtn.TabIndex = 0x66;
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
            this.buttonClose.Location = new Point(0x13a, 290);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new Padding(3);
            this.buttonClose.Size = new Size(0x44, 30);
            this.buttonClose.TabIndex = 0x67;
            this.buttonClose.Text = "Close";
            this.buttonClose.TextAlign = ContentAlignment.MiddleRight;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.groupBox5.Controls.Add(this.checkBoxDelete);
            this.groupBox5.Controls.Add(this.compressionSelect);
            this.groupBox5.Location = new Point(10, 0xa2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x177, 0x43);
            this.groupBox5.TabIndex = 0x6a;
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
            this.groupBox4.Location = new Point(0xbd, 0x54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xc4, 0x48);
            this.groupBox4.TabIndex = 0x69;
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
            this.groupBox1.Location = new Point(9, 0x54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xae, 0x48);
            this.groupBox1.TabIndex = 0x68;
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
            base.AutoScaleDimensions = new SizeF(7f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x188, 0x1b9);
            base.Controls.Add(this.groupBox5);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.buttonClose);
            base.Controls.Add(this.cancelBatchBtn);
            base.Controls.Add(this.startBatchBtn);
            base.Controls.Add(this.stageProgressGrp);
            base.Controls.Add(this.totalProgressGrp);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "batchPatchForm";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "DS-Scene Rom Tool: Patch, Trim and Pack";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.totalProgressGrp.ResumeLayout(false);
            this.totalProgressGrp.PerformLayout();
            this.stageProgressGrp.ResumeLayout(false);
            this.stageProgressGrp.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private long processBatchSingleFile(string fileName)
        {
            int num = this.progressBarTotal.Value;
            string arcType = Program.form.getFileExtension(fileName);
            string str2 = fileName;
            bool flag = false;
            string str7 = arcType;
            if (str7 != null)
            {
                if (str7 == "rar")
                {
                    flag = true;
                }
                else if (str7 == "zip")
                {
                    flag = true;
                }
                else if (str7 == "7z")
                {
                    flag = true;
                }
                else if (str7 != "nds")
                {
                    goto TR_0004;
                }
                this.increaseTotalProgress();
                if (flag)
                {
                    string str3 = "/data/temp/";
                    if (Path.GetDirectoryName(Application.ExecutablePath).Replace('\\', '+') != Path.GetDirectoryName(Application.ExecutablePath))
                    {
                        str3 = str3.Replace('/', '\\');
                    }
                    if (!Program.form.extractRom(fileName, Path.GetDirectoryName(Application.ExecutablePath) + str3, arcType, this.progressBarStage, this.stageProgressGrpLabel))
                    {
                        while ((num + 8) > this.progressBarTotal.Value)
                        {
                            this.increaseTotalProgress();
                        }
                        return (long) (-2);
                    }
                    fileName = Path.GetDirectoryName(Application.ExecutablePath) + str3 + Program.form.compressor.extracting_file;
                }
                this.increaseTotalProgress();
                Program.form.romHeader.loadRomHeader(fileName, true);
                bool flag2 = false;
                long err = 0L;
                bool apPatch = false;
                if (this.checkBoxApPatch.Checked || this.checkBoxTrim.Checked)
                {
                    if (!Program.form.checkCrc32(fileName, this.progressBarStage, this.stageProgressGrpLabel))
                    {
                        flag2 = true;
                        err = -7;
                    }
                    else
                    {
                        Program.form.romHeader.romHeader.hash = Program.form.crchash;
                        Program.form.romHeader.romHeader.cleanCrc = Program.form.crcDb.crcToCleanCrc(Program.form.romHeader.romHeader.hash.ToUpper());
                        if ((Program.form.romHeader.romHeader.cleanCrc == null) || (Program.form.romHeader.romHeader.cleanCrc.hash == ""))
                        {
                            Program.form.romHeader.romHeader.cleanCrc = new crcDupes.possibleCrcType();
                            Program.form.romHeader.romHeader.cleanCrc.hash = Program.form.romHeader.romHeader.hash.ToUpper();
                            Program.form.romHeader.romHeader.cleanCrc.type = crcDupes.romTypes.unknown;
                        }
                        if (this.checkBoxApPatch.Checked)
                        {
                            Program.form.patchInfo = Program.form.patchDb.findPatchInDb(Program.form.romHeader.romHeader.cleanCrc.hash);
                            if (Program.form.patchInfo != null)
                            {
                                apPatch = true;
                            }
                        }
                    }
                }
                Program.form.downloadInfoFromWebsite(Program.form.romHeader.romHeader.cleanCrc.type, Program.form.romHeader.romHeader.cleanCrc.hash, this.progressBarStage, this.stageProgressGrpLabel, false, false);
                this.increaseTotalProgress();
                string compress = "";
                string romOut = Path.Combine(this.txtFileLocOut.Text, Program.form.origFileLocToNewFileName(fileName, this.checkBoxTrim.Checked, apPatch, this.txtFileLocOut.Text)).ToString();
                if (!flag2)
                {
                    if (this.allowCompress)
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
                    apPatcherAppForm.romTrimTypes none = apPatcherAppForm.romTrimTypes.none;
                    if (this.radioSafeTrim.Checked)
                    {
                        none = apPatcherAppForm.romTrimTypes.safe;
                    }
                    if (this.radioAccurateTrim.Checked)
                    {
                        none = apPatcherAppForm.romTrimTypes.accurate;
                    }
                    err = Program.form.doExportRomAction(fileName, romOut, none, apPatch, compress, this.checkBoxDelete.Checked, this.progressBarStage, this.stageProgressGrpLabel, true, false);
                    Application.DoEvents();
                }
                this.increaseTotalProgress();
                if (compress != "")
                {
                    romOut = romOut.Substring(0, romOut.Length - 3) + compress;
                }
                this.writeBatchLog("[Processed] [" + Program.form.romExportError(err, romOut, true) + "] [orig:" + str2 + "]");
                this.increaseTotalProgress();
                if (flag)
                {
                    Program.form.cleanTempFiles();
                }
                return err;
            }
        TR_0004:
            MessageBox.Show("Invalid file found in batch stream: " + fileName, "Batch Job Terminated", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            while ((num + 8) > this.progressBarTotal.Value)
            {
                this.increaseTotalProgress();
            }
            return -1L;
        }

        private void resetProgressBars()
        {
            this.stageProgressGrpLabel.Text = "File Progress";
            this.totalProgressGrpLabel.Text = "Total Progress";
            this.progressBarStage.Value = 0;
            this.progressBarTotal.Value = 0;
        }

        private void startBatchBtn_Click(object sender, EventArgs e)
        {
            if (this.txtFileLocIn.Text == "")
            {
                MessageBox.Show("You must select an input directory", "Input Directory Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.txtFileLocOut.Text == "")
            {
                MessageBox.Show("You must select an output directory", "Output Directory Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.cancelled = false;
                this.buttonClose.Enabled = false;
                this.txtFileLocIn.Enabled = false;
                this.txtFileLocOut.Enabled = false;
                this.startBatchBtn.Enabled = false;
                this.cancelBatchBtn.Visible = true;
                this.checkBoxTrim.Enabled = false;
                this.checkBoxApPatch.Enabled = false;
                this.cancelBatchBtn.Enabled = true;
                this.btnBrowseIn.Enabled = false;
                this.btnBrowseOut.Enabled = false;
                this.checkBoxSubDirs.Enabled = false;
                this.compressionSelect.Enabled = false;
                this.checkBoxDelete.Enabled = false;
                patchdb.patchdb_PatchClass patchInfo = Program.form.patchInfo;
                dsromHeader romHeader = Program.form.romHeader;
                this.resetProgressBars();
                if (!this.batchProcess())
                {
                    MessageBox.Show("The batch process failed\nPlease check the log in the output directory for more information", "Batch Process Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                this.txtFileLocIn.Enabled = true;
                this.txtFileLocOut.Enabled = true;
                this.startBatchBtn.Enabled = true;
                this.checkBoxTrim.Enabled = true;
                this.checkBoxApPatch.Enabled = true;
                this.cancelBatchBtn.Visible = false;
                this.btnBrowseIn.Enabled = true;
                this.btnBrowseOut.Enabled = true;
                this.checkBoxSubDirs.Enabled = true;
                this.buttonClose.Enabled = true;
                if (this.allowCompress)
                {
                    this.compressionSelect.Enabled = true;
                    this.checkBoxDelete.Enabled = true;
                }
                Program.form.patchInfo = patchInfo;
                Program.form.romHeader = romHeader;
            }
        }

        private void writeBatchLog(string txt)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(this.txtFileLocOut.Text, "log.txt"), true))
            {
                writer.WriteLine(txt);
            }
        }
    }
}

