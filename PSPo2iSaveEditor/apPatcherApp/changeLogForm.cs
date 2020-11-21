namespace apPatcherApp
{
    using apPatcherApp.Properties;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class changeLogForm : Form
    {
        private IContainer components;
        private RichTextBox txtChangelog;
        private Label txtApplicationName;
        private Label txtDatabaseCount;
        private Label txtInstalledDbs;
        private GroupBox groupBox1;
        private Button button1;
        private ListView patchList;
        private ColumnHeader patchListHeader_name;
        private ColumnHeader patchListHeader_crc;
        private ColumnHeader patchListHeader_creator;
        private ColumnHeader patchListHeader_offsets;
        private Label txtMaintained;
        private PictureBox changelogIcon;
        private TabControl tabControl1;
        private TabPage tabPageChangeLog;
        private TabPage tabPageSupported;
        private ImageList imageList1;
        private apPatcherAppForm parent;
        private int curdbitems;
        public int patchSortColumn;

        public changeLogForm()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void formSetup(string type)
        {
            this.parent = Program.form;
            this.showChangeLogInfo(type);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(changeLogForm));
            this.txtApplicationName = new Label();
            this.txtDatabaseCount = new Label();
            this.txtInstalledDbs = new Label();
            this.groupBox1 = new GroupBox();
            this.patchList = new ListView();
            this.patchListHeader_name = new ColumnHeader();
            this.patchListHeader_crc = new ColumnHeader();
            this.patchListHeader_creator = new ColumnHeader();
            this.patchListHeader_offsets = new ColumnHeader();
            this.txtMaintained = new Label();
            this.tabControl1 = new TabControl();
            this.tabPageChangeLog = new TabPage();
            this.txtChangelog = new RichTextBox();
            this.tabPageSupported = new TabPage();
            this.imageList1 = new ImageList(this.components);
            this.changelogIcon = new PictureBox();
            this.button1 = new Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageChangeLog.SuspendLayout();
            this.tabPageSupported.SuspendLayout();
            ((ISupportInitialize) this.changelogIcon).BeginInit();
            base.SuspendLayout();
            this.txtApplicationName.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtApplicationName.ImageAlign = ContentAlignment.MiddleLeft;
            this.txtApplicationName.Location = new Point(0x1b, 8);
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Padding = new Padding(3);
            this.txtApplicationName.Size = new Size(0x1ef, 0x17);
            this.txtApplicationName.TabIndex = 1;
            this.txtApplicationName.Text = "XXXXXXXXXX vX.X build xxxx";
            this.txtDatabaseCount.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtDatabaseCount.Location = new Point(5, 0x10);
            this.txtDatabaseCount.Name = "txtDatabaseCount";
            this.txtDatabaseCount.Size = new Size(0x151, 0x12);
            this.txtDatabaseCount.TabIndex = 3;
            this.txtDatabaseCount.Text = "1 Database Installed ";
            this.txtInstalledDbs.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtInstalledDbs.Location = new Point(5, 0x22);
            this.txtInstalledDbs.Name = "txtInstalledDbs";
            this.txtInstalledDbs.Size = new Size(0x1f3, 0x47);
            this.txtInstalledDbs.TabIndex = 4;
            this.txtInstalledDbs.Text = "Installed Database1";
            this.groupBox1.Controls.Add(this.txtInstalledDbs);
            this.groupBox1.Controls.Add(this.txtDatabaseCount);
            this.groupBox1.Location = new Point(12, 0x22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(510, 0x6f);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.patchList.BackColor = SystemColors.Window;
            ColumnHeader[] values = new ColumnHeader[] { this.patchListHeader_name, this.patchListHeader_crc, this.patchListHeader_creator, this.patchListHeader_offsets };
            this.patchList.Columns.AddRange(values);
            this.patchList.Cursor = Cursors.Hand;
            this.patchList.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.patchList.ForeColor = SystemColors.ControlText;
            this.patchList.FullRowSelect = true;
            this.patchList.HideSelection = false;
            this.patchList.LabelWrap = false;
            this.patchList.Location = new Point(-2, -2);
            this.patchList.MultiSelect = false;
            this.patchList.Name = "patchList";
            this.patchList.Size = new Size(0x1fb, 0xe2);
            this.patchList.TabIndex = 0x55;
            this.patchList.UseCompatibleStateImageBehavior = false;
            this.patchList.View = View.Details;
            this.patchList.ColumnClick += new ColumnClickEventHandler(this.patchList_ColumnClick);
            this.patchListHeader_name.Text = "Game Name";
            this.patchListHeader_name.Width = 250;
            this.patchListHeader_crc.Text = "CRC32";
            this.patchListHeader_crc.Width = 90;
            this.patchListHeader_creator.Text = "Creator";
            this.patchListHeader_creator.Width = 90;
            this.patchListHeader_offsets.Text = "Offsets";
            this.patchListHeader_offsets.Width = 0x37;
            this.txtMaintained.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtMaintained.Location = new Point(12, 400);
            this.txtMaintained.Name = "txtMaintained";
            this.txtMaintained.Size = new Size(0x124, 0x12);
            this.txtMaintained.TabIndex = 6;
            this.txtMaintained.Text = "Maintained by ";
            this.tabControl1.Controls.Add(this.tabPageChangeLog);
            this.tabControl1.Controls.Add(this.tabPageSupported);
            this.tabControl1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new Point(11, 0x95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x1ff, 0xf8);
            this.tabControl1.TabIndex = 0x57;
            this.tabPageChangeLog.Controls.Add(this.txtChangelog);
            this.tabPageChangeLog.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabPageChangeLog.ImageIndex = 0;
            this.tabPageChangeLog.Location = new Point(4, 0x17);
            this.tabPageChangeLog.Name = "tabPageChangeLog";
            this.tabPageChangeLog.Padding = new Padding(3);
            this.tabPageChangeLog.Size = new Size(0x1f7, 0xdd);
            this.tabPageChangeLog.TabIndex = 0;
            this.tabPageChangeLog.Text = "Change Log";
            this.tabPageChangeLog.UseVisualStyleBackColor = true;
            this.txtChangelog.BackColor = Color.White;
            this.txtChangelog.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtChangelog.Location = new Point(-2, -2);
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            this.txtChangelog.Size = new Size(0x1fb, 0xe2);
            this.txtChangelog.TabIndex = 0;
            this.txtChangelog.Text = "";
            this.txtChangelog.WordWrap = false;
            this.tabPageSupported.Controls.Add(this.patchList);
            this.tabPageSupported.ImageIndex = 1;
            this.tabPageSupported.Location = new Point(4, 0x17);
            this.tabPageSupported.Name = "tabPageSupported";
            this.tabPageSupported.Padding = new Padding(3);
            this.tabPageSupported.Size = new Size(0x1f7, 0xdd);
            this.tabPageSupported.TabIndex = 1;
            this.tabPageSupported.Text = "Supported Games";
            this.tabPageSupported.UseVisualStyleBackColor = true;
            this.imageList1.ImageStream = (ImageListStreamer) manager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "changelog.png");
            this.imageList1.Images.SetKeyName(1, "lifebuoy.png");
            this.changelogIcon.Image = Resources.romtool;
            this.changelogIcon.Location = new Point(12, 12);
            this.changelogIcon.Name = "changelogIcon";
            this.changelogIcon.Size = new Size(0x10, 0x10);
            this.changelogIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.changelogIcon.TabIndex = 0x56;
            this.changelogIcon.TabStop = false;
            this.button1.Cursor = Cursors.Hand;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Image = Resources.crossicon;
            this.button1.ImageAlign = ContentAlignment.MiddleLeft;
            this.button1.Location = new Point(0x1c5, 0x18e);
            this.button1.Name = "button1";
            this.button1.Padding = new Padding(3);
            this.button1.Size = new Size(0x45, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.TextAlign = ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            base.ClientSize = new Size(0x217, 0x1b0);
            base.Controls.Add(this.tabControl1);
            base.Controls.Add(this.changelogIcon);
            base.Controls.Add(this.txtMaintained);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.txtApplicationName);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "changeLogForm";
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Change Log Viewer";
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageChangeLog.ResumeLayout(false);
            this.tabPageSupported.ResumeLayout(false);
            ((ISupportInitialize) this.changelogIcon).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void listCMPCheats()
        {
            this.patchList.Items.Clear();
            for (int i = 0; i < Program.form.cmpGamesFilled; i++)
            {
                ListViewItem item = new ListViewItem {
                    Text = Program.form.cmpGames[i].name,
                    SubItems = { 
                        Program.form.cmpGames[i].hash,
                        Program.form.cmpGames[i].gameCode,
                        Program.form.cmpGames[i].region ?? ""
                    }
                };
                this.patchList.Items.Add(item);
            }
        }

        private void listPatches()
        {
            this.patchList.Items.Clear();
            for (int i = 0; i < Program.form.patchDb.db_filled; i++)
            {
                ListViewItem item = new ListViewItem {
                    Text = Program.form.patchDb.patch_db.patch[i].name,
                    SubItems = { 
                        Program.form.patchDb.patch_db.patch[i].hash,
                        Program.form.patchDb.patch_db.patch[i].creator,
                        Program.form.patchDb.patch_db.patch[i].patchlines
                    }
                };
                this.patchList.Items.Add(item);
            }
        }

        private void patchList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.patchList.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            if (e.Column == this.patchSortColumn)
            {
                this.patchList.Sorting = (this.patchList.Sorting != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending;
            }
            else
            {
                this.patchSortColumn = e.Column;
                this.patchList.Sorting = SortOrder.Ascending;
            }
            this.patchList.Sort();
            this.patchList.ListViewItemSorter = new ListViewItemComparer(e.Column, this.patchList.Sorting);
        }

        private void showApplicationInfo()
        {
            this.Text = "Application Version Information";
            this.txtApplicationName.Text = "DS-Scene Rom Tool";
            this.txtApplicationName.Text = this.txtApplicationName.Text + " v1.0 build 1215";
            this.changelogIcon.Image = Resources.romtool;
            this.txtMaintained.Text = "Maintained by www.ds-scene.net";
            if (this.tabControl1.TabPages.Count == 2)
            {
                this.tabControl1.TabPages.Remove(this.tabPageSupported);
            }
            this.tabControl1.SelectedIndex = 0;
            this.txtDatabaseCount.Text = "Application Version Installed";
            this.txtInstalledDbs.Text = "DS-Scene Rom Tool v1.0 build 1215";
        }

        private void showChangeLogInfo(string type)
        {
            string str3;
            string str = "";
            string str2 = "";
            string str6 = type;
            if (str6 != null)
            {
                if (str6 == "app")
                {
                    str2 = "changelog_build_1200.bin";
                    this.showApplicationInfo();
                    str = @"{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\b\f0\fs28 DS-Scene Rom Tool Change Log\par\r\n\fs16 No updates have been installed";
                    goto TR_0011;
                }
                else if (str6 == "cmp")
                {
                    str2 = "databases/changelog_cmp.bin";
                    this.showCMPDatabaseInfo();
                    str = @"{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\b\f0\fs28 CMP Database Change Log\par\r\n\fs16 No updates have been installed";
                    goto TR_0011;
                }
            }
            str2 = "databases/changelog_db.bin";
            this.showDatabaseInfo();
            str = @"{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\b\f0\fs28 AP Patch Database Change Log\par\r\n\fs16 No updates have been installed";
        TR_0011:
            str3 = "";
            try
            {
                FileStream fs = new FileStream("data//" + str2, FileMode.Open, FileAccess.Read);
                string sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                if (type == "cmp")
                {
                    sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F006F003F003F001000000069003F00");
                }
                using (StreamReader reader = new StreamReader(this.parent.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    int num = 0;
                    while (true)
                    {
                        string str5 = reader.ReadLine();
                        if (str5 == null)
                        {
                            reader.Close();
                            break;
                        }
                        str3 = str3 + str5;
                        num++;
                    }
                }
                fs.Close();
            }
            catch (Exception)
            {
                str3 = str3 + @"{\rtf1\ansi\ansicpg1252\deff0\deflang2057{\fonttbl{\f0\fnil\fcharset0 Verdana;}}\r\n" + str;
            }
            this.txtChangelog.Rtf = str3;
        }

        private void showCMPDatabaseInfo()
        {
            this.Text = "CMP Database Version Information";
            this.txtApplicationName.Text = "CMP Database Version Information";
            this.changelogIcon.Image = Resources.cmp_icon;
            this.txtMaintained.Text = "Maintained by CMP";
            this.listCMPCheats();
            if (this.tabControl1.TabPages.Count == 1)
            {
                this.tabControl1.TabPages.Add(this.tabPageSupported);
            }
            this.patchListHeader_creator.Text = "Game Code";
            this.patchListHeader_offsets.Text = "Region";
            this.patchListHeader_crc.Text = "Header CRC";
            this.tabControl1.SelectedIndex = 0;
            this.curdbitems = 0;
            apPatcherAppForm.updateCSVInfo[] infoArray = new apPatcherAppForm.updateCSVInfo[20];
            try
            {
                string sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("3F006F003F003F001000000069003F00");
                FileStream fs = new FileStream("data/databases/version_cmp.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.parent.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    string str2 = "";
                    int num = 0;
                    while (true)
                    {
                        str2 = reader.ReadLine();
                        if (str2 != null)
                        {
                            char[] separator = new char[] { '|' };
                            string[] strArray = str2.Split(separator);
                            infoArray[this.curdbitems] = new apPatcherAppForm.updateCSVInfo();
                            infoArray[this.curdbitems].fn = strArray[0];
                            infoArray[this.curdbitems].ver = strArray[1];
                            if ((infoArray[this.curdbitems].ver != "0") && (infoArray[this.curdbitems].ver != ""))
                            {
                                this.curdbitems++;
                            }
                            if ((num + 1) < 20)
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
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
            this.txtDatabaseCount.Text = this.curdbitems + " Databases Installed";
            this.txtInstalledDbs.Text = "";
            if (this.curdbitems > 0)
            {
                for (int i = 0; i < this.curdbitems; i++)
                {
                    string text = this.txtInstalledDbs.Text;
                    string[] strArray2 = new string[] { text, infoArray[i].fn, " v", infoArray[i].ver, "\r\n" };
                    this.txtInstalledDbs.Text = string.Concat(strArray2);
                }
            }
            object[] objArray = new object[] { this.txtInstalledDbs.Text, "\r\nCMP Database Supports ", Program.form.cmpGamesFilled, " Games" };
            this.txtInstalledDbs.Text = string.Concat(objArray);
        }

        private void showDatabaseInfo()
        {
            this.Text = "AP Database Version Information";
            this.txtApplicationName.Text = "AP Database Version Information";
            this.changelogIcon.Image = Resources.ap_icon;
            this.txtMaintained.Text = "Maintained by RetroGameFan";
            this.listPatches();
            if (this.tabControl1.TabPages.Count == 1)
            {
                this.tabControl1.TabPages.Add(this.tabPageSupported);
            }
            this.patchListHeader_creator.Text = "Creator";
            this.patchListHeader_offsets.Text = "Offsets";
            this.patchListHeader_crc.Text = "Rom CRC32";
            this.tabControl1.SelectedIndex = 0;
            this.curdbitems = 0;
            apPatcherAppForm.updateCSVInfo[] infoArray = new apPatcherAppForm.updateCSVInfo[20];
            try
            {
                string sKey = this.parent.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.parent.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    string str2 = "";
                    while (true)
                    {
                        str2 = reader.ReadLine();
                        if (str2 != null)
                        {
                            char[] separator = new char[] { '|' };
                            string[] strArray = str2.Split(separator);
                            infoArray[this.curdbitems] = new apPatcherAppForm.updateCSVInfo();
                            infoArray[this.curdbitems].fn = strArray[0];
                            infoArray[this.curdbitems].ver = strArray[1];
                            this.curdbitems++;
                            if (this.curdbitems < 20)
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
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
            this.txtDatabaseCount.Text = "Database Version Installed";
            this.txtInstalledDbs.Text = "";
            if (this.curdbitems > 0)
            {
                for (int i = 0; i < this.curdbitems; i++)
                {
                    string text = this.txtInstalledDbs.Text;
                    string[] strArray2 = new string[] { text, infoArray[i].fn, " v", infoArray[i].ver, "\r\n" };
                    this.txtInstalledDbs.Text = string.Concat(strArray2);
                }
            }
            object[] objArray = new object[] { this.txtInstalledDbs.Text, "\r\nAP Database Supports ", Program.form.patchDb.db_filled, " Games" };
            this.txtInstalledDbs.Text = string.Concat(objArray);
        }

        public class ListViewItemComparer : IComparer
        {
            private int col;
            private SortOrder order;

            public ListViewItemComparer()
            {
                this.col = 0;
                this.order = SortOrder.Ascending;
            }

            public ListViewItemComparer(int column, SortOrder order = 1)
            {
                this.col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                int num = -1;
                num = string.Compare(((ListViewItem) x).SubItems[this.col].Text, ((ListViewItem) y).SubItems[this.col].Text);
                if (this.order == SortOrder.Descending)
                {
                    num *= -1;
                }
                return num;
            }
        }
    }
}

