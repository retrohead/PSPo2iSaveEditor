namespace apPatcherApp
{
    using apPatcherApp.Properties;
    using Blue.Windows;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class collectionViewer : Form
    {
        private IContainer components;
        private ColumnHeader columnRomNum;
        private ColumnHeader columnRomNam;
        private ColumnHeader columnRomRgn;
        private GroupBox grpChooseCollection;
        public ListView listViewRoms;
        private ColumnHeader columnRomGrp;
        public ComboBox listCollectionDbs;
        public Button btnAddCollection;
        private TextBox txtFilterName;
        private ComboBox comboFilterGroup;
        private ComboBox comboFilterRegion;
        private ComboBox comboFilterRomNum;
        private CheckBox checkBoxFilterWifi;
        private PictureBox pictureBox3;
        private CheckBox checkBoxFilterAp;
        private CheckBox checkBoxFilterCmp;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private CheckBox checkBoxFilterDsi;
        private PictureBox pictureBox4;
        public GroupBox groupBoxFilters;
        private Timer keyPressTimer;
        private Panel panel1;
        public Label toolStripStatusLabel;
        public ProgressBar toolStripProgressBar;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CheckBox chk_3ds_streetpass;
        private CheckBox chk_3ds_spotpass;
        private CheckBox chk_3ds_multicartplay;
        private CheckBox chk_3ds_onlineplay;
        private CheckBox chk_3ds_downloadplay;
        private ImageList imageList1;
        private CheckBox chk_3ds_slidepad;
        private CheckBox chk_3ds_ninnet;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem rightClickFavorite;
        private ToolStripSeparator toolStripSeparator1;
        private ImageList imageList2;
        public ToolStripMenuItem rightClickDelete;
        public bool refreshNfos;
        private bool loadingFilters;
        private bool timerloadFilters;
        private bool stopRomListing;
        private bool loadingForm;
        private int formWidth;
        private int formHeight;
        private int extraWidth;
        private int extraHeight;
        private StickyWindow stickyWindow;
        public string selectedRom = "";
        public int romSortColumn;

        public collectionViewer()
        {
            base.MinimizeBox = false;
            this.InitializeComponent();
            this.stickyWindow = new StickyWindow(this);
            this.formWidth = base.Width;
            this.formHeight = base.Height;
        }

        private void activateTimeoutKeyedSearch()
        {
            this.keyPressTimer.Enabled = false;
            this.stopRomListing = false;
            this.fillRomList(this.timerloadFilters);
            this.timerloadFilters = false;
        }

        private void addComboFilter(ComboBox filter, string str, string allText)
        {
            if (!this.comboFilterExists(filter, str))
            {
                if (!this.comboFilterExists(filter, allText) && (str != allText))
                {
                    this.addComboFilter(filter, allText, allText);
                }
                filter.Items.Add(str);
                filter.SelectedIndex = 0;
            }
        }

        private void btnAddCollection_Click(object sender, EventArgs e)
        {
            Program.form.organiseForm.formSetup();
            Program.form.organiseForm.ShowDialog(Program.form);
            this.stopRomListing = true;
            this.formSetup();
            this.listCollectionDbs.SelectedIndex = Program.form.collectiondb.activeDb;
        }

        private void chk_3ds_downloadplay_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loadingFilters)
            {
                this.stopRomListing = true;
                this.startKeyPressTimer(false);
            }
        }

        private void chk_3ds_multicartplay_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loadingFilters)
            {
                this.stopRomListing = true;
                this.startKeyPressTimer(false);
            }
        }

        private void chk_3ds_ninnet_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loadingFilters)
            {
                this.stopRomListing = true;
                this.startKeyPressTimer(false);
            }
        }

        private void chk_3ds_onlineplay_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loadingFilters)
            {
                this.stopRomListing = true;
                this.startKeyPressTimer(false);
            }
        }

        private void chk_3ds_slidepad_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loadingFilters)
            {
                this.stopRomListing = true;
                this.startKeyPressTimer(false);
            }
        }

        private void chk_3ds_spotpass_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loadingFilters)
            {
                this.stopRomListing = true;
                this.startKeyPressTimer(false);
            }
        }

        private void chk_3ds_streetpass_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loadingFilters)
            {
                this.stopRomListing = true;
                this.startKeyPressTimer(false);
            }
        }

        private void collectionForm_Shown(object sender, EventArgs e)
        {
            this.loadingForm = true;
            this.formSetup();
            if (Settings.Default.Collection_W != 0)
            {
                base.Width = Settings.Default.Collection_W;
            }
            if (Settings.Default.Collection_H != 0)
            {
                base.Height = Settings.Default.Collection_H;
            }
            if (Settings.Default.Collection_Col1 != 0)
            {
                this.listViewRoms.Columns[0].Width = Settings.Default.Collection_Col1;
            }
            if (Settings.Default.Collection_Col2 != 0)
            {
                this.listViewRoms.Columns[1].Width = Settings.Default.Collection_Col2;
            }
            if (Settings.Default.Collection_Col3 != 0)
            {
                this.listViewRoms.Columns[2].Width = Settings.Default.Collection_Col3;
            }
            if (Settings.Default.Collection_Col4 != 0)
            {
                this.listViewRoms.Columns[3].Width = Settings.Default.Collection_Col4;
            }
            this.loadingForm = false;
        }

        private void collectionViewer_ResizeBegin(object sender, EventArgs e)
        {
            this.resizeForm();
        }

        private void collectionViewer_ResizeEnd(object sender, EventArgs e)
        {
            this.resizeForm();
        }

        private void collectionViewer_SizeChanged(object sender, EventArgs e)
        {
            this.resizeForm();
        }

        private bool comboFilterExists(ComboBox filter, string str)
        {
            bool flag;
            using (IEnumerator enumerator = filter.Items.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        string current = (string) enumerator.Current;
                        if (current.ToString() != str)
                        {
                            continue;
                        }
                        flag = true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
            }
            return flag;
        }

        protected override void Dispose(bool disposing)
        {
            Program.form.collectionBrowserToolStripMenuItem.Enabled = true;
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void fillRomList(bool buildRomFilters)
        {
            webInfo.webInfoClass web;
            int num2;
            bool flag;
            int num3;
            bool flag2;
            bool flag3;
            ListViewItem item;
            collectionDb.collectionDbItemType type;
            webInfo.webInfoItemClass class3;
            bool flag5;
            int num4;
            webInfo.webInfoItemClass[] classArray;
            int num5;
            string[] strArray2;
            int num7;
            long num = 0L;
            if (this.listCollectionDbs.SelectedIndex <= -1)
            {
                goto TR_0005;
            }
            else
            {
                if (buildRomFilters)
                {
                    Program.form.disableMainForm();
                    this.loadingFilters = true;
                    this.comboFilterGroup.Items.Clear();
                    this.comboFilterRegion.Items.Clear();
                    this.comboFilterRomNum.Items.Clear();
                    this.txtFilterName.Text = "Search for a game by name...";
                    this.checkBoxFilterWifi.Checked = false;
                    this.checkBoxFilterWifi.Enabled = false;
                    this.checkBoxFilterAp.Checked = false;
                    this.checkBoxFilterAp.Enabled = false;
                    this.checkBoxFilterCmp.Checked = false;
                    this.checkBoxFilterCmp.Enabled = false;
                    this.checkBoxFilterDsi.Enabled = false;
                    this.checkBoxFilterDsi.Checked = false;
                    this.chk_3ds_downloadplay.Enabled = false;
                    this.chk_3ds_multicartplay.Enabled = false;
                    this.chk_3ds_onlineplay.Enabled = false;
                    this.chk_3ds_spotpass.Enabled = false;
                    this.chk_3ds_streetpass.Enabled = false;
                    this.chk_3ds_slidepad.Enabled = false;
                    this.chk_3ds_ninnet.Enabled = false;
                    this.chk_3ds_downloadplay.Checked = false;
                    this.chk_3ds_multicartplay.Checked = false;
                    this.chk_3ds_onlineplay.Checked = false;
                    this.chk_3ds_spotpass.Checked = false;
                    this.chk_3ds_streetpass.Checked = false;
                    this.chk_3ds_slidepad.Checked = false;
                    this.chk_3ds_ninnet.Checked = false;
                }
                this.listViewRoms.Items.Clear();
                Application.DoEvents();
                this.listViewRoms.SuspendLayout();
                if (this.listCollectionDbs.Items.Count <= 0)
                {
                    goto TR_0005;
                }
                else
                {
                    web = new webInfo.webInfoClass();
                    Program.form.collectiondb.selectDatabase(this.listCollectionDbs.SelectedItem.ToString());
                    num2 = Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].filled / 50;
                    flag = false;
                    num3 = 0;
                }
            }
            goto TR_008E;
        TR_0005:
            if (this.toolStripProgressBar.Maximum == 0)
            {
                this.toolStripProgressBar.Maximum = 1;
            }
            this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum;
            this.toolStripStatusLabel.Text = num + " roms found for your selection";
            this.loadingFilters = false;
            this.stopRomListing = false;
            if (buildRomFilters)
            {
                Program.form.enableMainForm();
            }
            this.listViewRoms.ResumeLayout();
            return;
        TR_0006:
            num3++;
            goto TR_008E;
        TR_001A:
            if (web.item[0] == null)
            {
                if (!flag)
                {
                    MessageBox.Show("A rom was found with missing web information.\n\nYou should re-scan for missing information", "Missing Web Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag = true;
                }
                flag3 = false;
            }
            if (this.checkBoxFilterAp.Checked && (Program.form.patchDb.findPatchInDb(type.crc) == null))
            {
                flag3 = false;
            }
            else if (Program.form.patchDb.findPatchInDb(type.crc) != null)
            {
                this.checkBoxFilterAp.Enabled = true;
            }
            if (this.checkBoxFilterCmp.Checked && !Program.form.hasCheats(type.gameCode))
            {
                flag3 = false;
            }
            else if (Program.form.hasCheats(type.gameCode))
            {
                this.checkBoxFilterCmp.Enabled = true;
            }
            item.ImageIndex = 1;
            if ((web.item[0] != null) && web.item[0].val.StartsWith("3DS"))
            {
                item.ImageIndex = 0;
            }
            if (flag3)
            {
                if (type.favourite)
                {
                    item.ImageIndex += 2;
                }
                this.listViewRoms.Items.Add(item);
                num += 1L;
            }
            goto TR_0006;
        TR_001B:
            num5++;
            goto TR_007C;
        TR_001E:
            if (!flag)
            {
                flag = true;
                MessageBox.Show("Unsupported webInfo '" + class3.key + "' in 'data/web/info/" + web.crcLoaded + "_info.dsapdb'\n\nFile was deleted, please scan for missing web information", "Corrupted Web Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            System.IO.File.Delete("data/web/info/" + web.crcLoaded + "_info.dsapdb");
            bool flag4 = true;
            web.item[0] = null;
            goto TR_001B;
        TR_0045:
            num7++;
        TR_006E:
            while (true)
            {
                if (num7 >= strArray2.Length)
                {
                    if ((num4 == 0) && flag5)
                    {
                        flag3 = false;
                    }
                    break;
                }
                string str = strArray2[num7];
                if (str != "")
                {
                    num4++;
                    string key = str;
                    if (key != null)
                    {
                        int num8;
                        if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000042-2 == null)
                        {
                            Dictionary<string, int> dictionary2 = new Dictionary<string, int>(6);
                            dictionary2.Add("downloadplay", 0);
                            dictionary2.Add("onlineplay", 1);
                            dictionary2.Add("multicartplay", 2);
                            dictionary2.Add("streetpass", 3);
                            dictionary2.Add("pushcontent", 4);
                            dictionary2.Add("slidepad", 5);
                            <PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000042-2 = dictionary2;
                        }
                        if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000042-2.TryGetValue(key, out num8))
                        {
                            switch (num8)
                            {
                                case 0:
                                    this.chk_3ds_downloadplay.Enabled = true;
                                    if (!this.chk_3ds_downloadplay.Checked && (flag5 && !flag2))
                                    {
                                        flag3 = false;
                                    }
                                    else if (this.chk_3ds_downloadplay.Checked)
                                    {
                                        flag3 = true;
                                        flag2 = true;
                                    }
                                    goto TR_0045;

                                case 1:
                                    this.chk_3ds_onlineplay.Enabled = true;
                                    if (!this.chk_3ds_onlineplay.Checked && (flag5 && !flag2))
                                    {
                                        flag3 = false;
                                    }
                                    else if (this.chk_3ds_onlineplay.Checked)
                                    {
                                        flag3 = true;
                                        flag2 = true;
                                    }
                                    goto TR_0045;

                                case 2:
                                    this.chk_3ds_multicartplay.Enabled = true;
                                    if (!this.chk_3ds_multicartplay.Checked && (flag5 && !flag2))
                                    {
                                        flag3 = false;
                                    }
                                    else if (this.chk_3ds_multicartplay.Checked)
                                    {
                                        flag3 = true;
                                        flag2 = true;
                                    }
                                    goto TR_0045;

                                case 3:
                                    this.chk_3ds_streetpass.Enabled = true;
                                    if (!this.chk_3ds_streetpass.Checked && (flag5 && !flag2))
                                    {
                                        flag3 = false;
                                    }
                                    else if (this.chk_3ds_streetpass.Checked)
                                    {
                                        flag3 = true;
                                        flag2 = true;
                                    }
                                    goto TR_0045;

                                case 4:
                                    this.chk_3ds_spotpass.Enabled = true;
                                    if (!this.chk_3ds_spotpass.Checked && (flag5 && !flag2))
                                    {
                                        flag3 = false;
                                    }
                                    else if (this.chk_3ds_spotpass.Checked)
                                    {
                                        flag3 = true;
                                        flag2 = true;
                                    }
                                    goto TR_0045;

                                case 5:
                                    this.chk_3ds_slidepad.Enabled = true;
                                    if (!this.chk_3ds_slidepad.Checked && (flag5 && !flag2))
                                    {
                                        flag3 = false;
                                    }
                                    else if (this.chk_3ds_slidepad.Checked)
                                    {
                                        flag3 = true;
                                        flag2 = true;
                                    }
                                    goto TR_0045;

                                default:
                                    break;
                            }
                        }
                    }
                    MessageBox.Show("unsupported 3DS option: " + str);
                }
                goto TR_0045;
            }
            goto TR_001B;
        TR_007C:
            while (true)
            {
                if (num5 < classArray.Length)
                {
                    class3 = classArray[num5];
                    if (flag4)
                    {
                        goto TR_001A;
                    }
                    else if (class3 == null)
                    {
                        goto TR_001B;
                    }
                    else
                    {
                        string key = class3.key;
                        if (key == null)
                        {
                            goto TR_001E;
                        }
                        else
                        {
                            int num6;
                            if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000042-1 == null)
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
                                <PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000042-1 = dictionary1;
                            }
                            if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x6000042-1.TryGetValue(key, out num6))
                            {
                                switch (num6)
                                {
                                    case 0:
                                        flag4 = true;
                                        goto TR_001B;

                                    case 1:
                                        flag4 = true;
                                        goto TR_001B;

                                    case 2:
                                        if (buildRomFilters)
                                        {
                                            this.addComboFilter(this.comboFilterRomNum, Program.form.organiseForm.romnumToFolder(class3.val), "- All Releases -");
                                            this.addComboFilter(this.comboFilterRomNum, "- Favorite Releases -", "- Favorite Releases -");
                                        }
                                        if ((this.comboFilterRomNum.SelectedIndex > 1) && (this.comboFilterRomNum.SelectedItem.ToString() != Program.form.organiseForm.romnumToFolder(class3.val)))
                                        {
                                            flag3 = false;
                                        }
                                        item.Text = class3.val;
                                        item.Text = Program.form.run.hexAndMathFunction.string_replace("3DS", "", class3.val);
                                        goto TR_001B;

                                    case 3:
                                        if ((this.txtFilterName.Text.Length > 1) && ((Program.form.run.hexAndMathFunction.string_replace(this.txtFilterName.Text.ToLower(), "", class3.val.ToLower()) == class3.val.ToLower()) && (this.txtFilterName.Text != "Search for a game by name...")))
                                        {
                                            flag3 = false;
                                        }
                                        item.SubItems.Add(class3.val);
                                        goto TR_001B;

                                    case 4:
                                        item.SubItems.Add(class3.val);
                                        if (buildRomFilters)
                                        {
                                            this.addComboFilter(this.comboFilterGroup, class3.val, "- All Groups -");
                                        }
                                        if ((this.comboFilterGroup.SelectedIndex > 0) && (this.comboFilterGroup.SelectedItem.ToString() != class3.val))
                                        {
                                            flag3 = false;
                                        }
                                        item.SubItems.Add(type.gameLoc);
                                        item.SubItems.Add(type.crc);
                                        item.SubItems.Add(num3);
                                        goto TR_001B;

                                    case 5:
                                    case 6:
                                    case 7:
                                    case 8:
                                    case 10:
                                    case 11:
                                    case 13:
                                    case 14:
                                    case 0x10:
                                    case 0x11:
                                        goto TR_001B;

                                    case 9:
                                        if (class3.val == "YES")
                                        {
                                            item.SubItems.Add(class3.val);
                                            this.checkBoxFilterWifi.Enabled = true;
                                        }
                                        else
                                        {
                                            if (this.checkBoxFilterWifi.Checked)
                                            {
                                                flag3 = false;
                                            }
                                            item.SubItems.Add("NO");
                                        }
                                        if (class3.val == "NNT")
                                        {
                                            item.SubItems.Add(class3.val);
                                            this.chk_3ds_ninnet.Enabled = true;
                                        }
                                        else
                                        {
                                            if (this.chk_3ds_ninnet.Checked)
                                            {
                                                flag3 = false;
                                            }
                                            item.SubItems.Add("NO");
                                        }
                                        goto TR_001B;

                                    case 12:
                                        if (class3.val == "YES")
                                        {
                                            item.SubItems.Add(class3.val);
                                            this.checkBoxFilterDsi.Enabled = true;
                                        }
                                        else
                                        {
                                            if (this.checkBoxFilterDsi.Checked)
                                            {
                                                flag3 = false;
                                            }
                                            item.SubItems.Add("NO");
                                        }
                                        goto TR_001B;

                                    case 15:
                                        if (buildRomFilters)
                                        {
                                            this.addComboFilter(this.comboFilterRegion, Program.form.organiseForm.romRegionChange(class3.val), "- All Regions -");
                                        }
                                        if ((this.comboFilterRegion.SelectedIndex > 0) && (this.comboFilterRegion.SelectedItem.ToString() != Program.form.organiseForm.romRegionChange(class3.val)))
                                        {
                                            flag3 = false;
                                        }
                                        item.SubItems.Add(Program.form.organiseForm.romRegionChange(class3.val));
                                        goto TR_001B;

                                    case 0x12:
                                    {
                                        string[] strArray = class3.val.Split(new char[] { ',' });
                                        flag5 = false;
                                        if (this.chk_3ds_downloadplay.Checked || (this.chk_3ds_onlineplay.Checked || (this.chk_3ds_multicartplay.Checked || (this.chk_3ds_streetpass.Checked || (this.chk_3ds_slidepad.Checked || this.chk_3ds_spotpass.Checked)))))
                                        {
                                            flag5 = true;
                                        }
                                        num4 = 0;
                                        strArray2 = strArray;
                                        num7 = 0;
                                        goto TR_006E;
                                    }
                                    default:
                                        break;
                                }
                            }
                            goto TR_001E;
                        }
                    }
                }
                else
                {
                    goto TR_001A;
                }
                break;
            }
            goto TR_006E;
        TR_008E:
            while (true)
            {
                if (num3 >= Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].filled)
                {
                    break;
                }
                flag2 = false;
                if (this.stopRomListing)
                {
                    break;
                }
                this.toolStripProgressBar.Value = num3;
                this.toolStripProgressBar.Maximum = Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].filled - 1;
                this.toolStripStatusLabel.Text = !buildRomFilters ? ("Building Rom List " + Program.form.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, this.toolStripProgressBar.Maximum) + "%") : ("Loading Database " + Program.form.run.hexAndMathFunction.getPercentage(this.toolStripProgressBar.Value, this.toolStripProgressBar.Maximum) + "%");
                if (num3 == num2)
                {
                    Application.DoEvents();
                    num2 += Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].filled / 50;
                }
                flag3 = true;
                item = new ListViewItem();
                type = Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].item[num3];
                crcDupes.possibleCrcType type2 = Program.form.crcDb.crcToCleanCrc(type.crc);
                if (type.favourite || (this.comboFilterRomNum.SelectedIndex != 1))
                {
                    item.Tag = num3;
                    if (type2 != null)
                    {
                        web = Program.form.web.parseWebInfo(type2.hash);
                    }
                    else if ((type.web != null) && (type.web.item[0] != null))
                    {
                        web = type.web;
                    }
                    else
                    {
                        web = Program.form.web.parseWebInfo(type.crc);
                        Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].item[num3].web = web;
                    }
                    flag4 = false;
                    if (web.item[0] == null)
                    {
                        goto TR_001A;
                    }
                    else
                    {
                        classArray = web.item;
                        num5 = 0;
                    }
                }
                else
                {
                    flag3 = false;
                    goto TR_0006;
                }
                goto TR_007C;
            }
            goto TR_0005;
        }

        private void filters_Changed(object sender, EventArgs e)
        {
            if (((sender != this.txtFilterName) || ((this.txtFilterName.Text != "") && (this.txtFilterName.Text != "Search for a game by name..."))) && !this.loadingFilters)
            {
                this.stopRomListing = true;
                this.startKeyPressTimer(false);
            }
        }

        private void Form_FormClosing(object sender, FormClosedEventArgs e)
        {
            Program.form.collectionForm = null;
            Settings.Default.Collection_W = base.Width;
            Settings.Default.Collection_H = base.Height;
            Settings.Default.Collection_Col1 = this.listViewRoms.Columns[0].Width;
            Settings.Default.Collection_Col2 = this.listViewRoms.Columns[1].Width;
            Settings.Default.Collection_Col3 = this.listViewRoms.Columns[2].Width;
            Settings.Default.Collection_Col4 = this.listViewRoms.Columns[3].Width;
            Settings.Default.Save();
        }

        public void formSetup()
        {
            Program.form.collectiondb.load();
            this.listCollectionDbs.SelectedIndex = -1;
            this.listCollectionDbs.Items.Clear();
            for (int i = 0; i < Program.form.collectiondb.dbsUsed; i++)
            {
                this.listCollectionDbs.Items.Add(Program.form.collectiondb.db[i].fn);
            }
            string s = Program.form.options.getValue("active_collection_db");
            if (s == "")
            {
                s = "-1";
            }
            Program.form.collectiondb.activeDb = int.Parse(s);
            if (Program.form.collectiondb.activeDb >= Program.form.collectiondb.dbsUsed)
            {
                Program.form.collectiondb.activeDb = Program.form.collectiondb.dbsUsed - 1;
            }
            this.listCollectionDbs.Focus();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(collectionViewer));
            this.listViewRoms = new ListView();
            this.columnRomNum = new ColumnHeader();
            this.columnRomNam = new ColumnHeader();
            this.columnRomRgn = new ColumnHeader();
            this.columnRomGrp = new ColumnHeader();
            this.imageList2 = new ImageList(this.components);
            this.imageList1 = new ImageList(this.components);
            this.grpChooseCollection = new GroupBox();
            this.btnAddCollection = new Button();
            this.listCollectionDbs = new ComboBox();
            this.groupBoxFilters = new GroupBox();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.pictureBox3 = new PictureBox();
            this.checkBoxFilterDsi = new CheckBox();
            this.checkBoxFilterAp = new CheckBox();
            this.pictureBox4 = new PictureBox();
            this.checkBoxFilterWifi = new CheckBox();
            this.pictureBox1 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.checkBoxFilterCmp = new CheckBox();
            this.tabPage2 = new TabPage();
            this.chk_3ds_ninnet = new CheckBox();
            this.chk_3ds_slidepad = new CheckBox();
            this.chk_3ds_streetpass = new CheckBox();
            this.chk_3ds_spotpass = new CheckBox();
            this.chk_3ds_multicartplay = new CheckBox();
            this.chk_3ds_onlineplay = new CheckBox();
            this.chk_3ds_downloadplay = new CheckBox();
            this.comboFilterRomNum = new ComboBox();
            this.txtFilterName = new TextBox();
            this.comboFilterGroup = new ComboBox();
            this.comboFilterRegion = new ComboBox();
            this.keyPressTimer = new Timer(this.components);
            this.panel1 = new Panel();
            this.toolStripStatusLabel = new Label();
            this.toolStripProgressBar = new ProgressBar();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.rightClickFavorite = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.rightClickDelete = new ToolStripMenuItem();
            this.grpChooseCollection.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((ISupportInitialize) this.pictureBox3).BeginInit();
            ((ISupportInitialize) this.pictureBox4).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.listViewRoms.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            ColumnHeader[] values = new ColumnHeader[] { this.columnRomNum, this.columnRomNam, this.columnRomRgn, this.columnRomGrp };
            this.listViewRoms.Columns.AddRange(values);
            this.listViewRoms.Cursor = Cursors.Hand;
            this.listViewRoms.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.listViewRoms.FullRowSelect = true;
            this.listViewRoms.HideSelection = false;
            this.listViewRoms.Location = new Point(8, 0xb1);
            this.listViewRoms.Name = "listViewRoms";
            this.listViewRoms.Size = new Size(380, 0xe8);
            this.listViewRoms.SmallImageList = this.imageList2;
            this.listViewRoms.Sorting = SortOrder.Ascending;
            this.listViewRoms.TabIndex = 0;
            this.listViewRoms.UseCompatibleStateImageBehavior = false;
            this.listViewRoms.View = View.Details;
            this.listViewRoms.ColumnClick += new ColumnClickEventHandler(this.listViewRoms_ColumnClick);
            this.listViewRoms.SelectedIndexChanged += new EventHandler(this.listViewRoms_SelectedIndexChanged);
            this.listViewRoms.MouseClick += new MouseEventHandler(this.listViewRoms_MouseClick);
            this.columnRomNum.Text = "Release #";
            this.columnRomNum.Width = 0x55;
            this.columnRomNam.Text = "Game Name";
            this.columnRomNam.Width = 170;
            this.columnRomRgn.Text = "Region";
            this.columnRomGrp.Text = "Group";
            this.imageList2.ImageStream = (ImageListStreamer) manager.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "n3ds.gif");
            this.imageList2.Images.SetKeyName(1, "ndsrom.gif");
            this.imageList2.Images.SetKeyName(2, "n3ds.gif");
            this.imageList2.Images.SetKeyName(3, "ndsrom.gif");
            this.imageList1.ImageStream = (ImageListStreamer) manager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "n3ds.gif");
            this.imageList1.Images.SetKeyName(1, "ndsrom.gif");
            this.grpChooseCollection.Controls.Add(this.btnAddCollection);
            this.grpChooseCollection.Controls.Add(this.listCollectionDbs);
            this.grpChooseCollection.Location = new Point(5, 7);
            this.grpChooseCollection.Name = "grpChooseCollection";
            this.grpChooseCollection.Size = new Size(380, 0x34);
            this.grpChooseCollection.TabIndex = 2;
            this.grpChooseCollection.TabStop = false;
            this.grpChooseCollection.Text = "Choose a collection";
            this.btnAddCollection.Anchor = AnchorStyles.Right;
            this.btnAddCollection.Cursor = Cursors.Hand;
            this.btnAddCollection.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnAddCollection.Image = Resources.tetris161;
            this.btnAddCollection.Location = new Point(0x123, 0x13);
            this.btnAddCollection.Name = "btnAddCollection";
            this.btnAddCollection.Size = new Size(0x56, 0x17);
            this.btnAddCollection.TabIndex = 3;
            this.btnAddCollection.Text = " Organiser";
            this.btnAddCollection.TextAlign = ContentAlignment.MiddleLeft;
            this.btnAddCollection.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnAddCollection.UseVisualStyleBackColor = true;
            this.btnAddCollection.Click += new EventHandler(this.btnAddCollection_Click);
            this.listCollectionDbs.Cursor = Cursors.Hand;
            this.listCollectionDbs.FormattingEnabled = true;
            this.listCollectionDbs.Location = new Point(10, 20);
            this.listCollectionDbs.Name = "listCollectionDbs";
            this.listCollectionDbs.Size = new Size(0x113, 0x15);
            this.listCollectionDbs.TabIndex = 2;
            this.listCollectionDbs.SelectedIndexChanged += new EventHandler(this.listCollectionDbs_SelectedIndexChanged);
            this.groupBoxFilters.Controls.Add(this.tabControl1);
            this.groupBoxFilters.Controls.Add(this.comboFilterRomNum);
            this.groupBoxFilters.Controls.Add(this.txtFilterName);
            this.groupBoxFilters.Controls.Add(this.comboFilterGroup);
            this.groupBoxFilters.Controls.Add(this.comboFilterRegion);
            this.groupBoxFilters.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBoxFilters.Location = new Point(5, 0x3d);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new Size(380, 0x77);
            this.groupBoxFilters.TabIndex = 4;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters";
            this.tabControl1.Anchor = AnchorStyles.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new Point(160, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0xd8, 0x55);
            this.tabControl1.TabIndex = 0x15;
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Controls.Add(this.checkBoxFilterDsi);
            this.tabPage1.Controls.Add(this.checkBoxFilterAp);
            this.tabPage1.Controls.Add(this.pictureBox4);
            this.tabPage1.Controls.Add(this.checkBoxFilterWifi);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.checkBoxFilterCmp);
            this.tabPage1.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.Location = new Point(4, 0x1b);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0xd0, 0x36);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "NDS";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.pictureBox3.Image = Resources.wifi;
            this.pictureBox3.Location = new Point(0x12, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(0x19, 0x19);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0x10;
            this.pictureBox3.TabStop = false;
            this.checkBoxFilterDsi.AutoSize = true;
            this.checkBoxFilterDsi.Cursor = Cursors.Hand;
            this.checkBoxFilterDsi.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxFilterDsi.Location = new Point(0x30, 30);
            this.checkBoxFilterDsi.Name = "checkBoxFilterDsi";
            this.checkBoxFilterDsi.Size = new Size(0x2a, 0x10);
            this.checkBoxFilterDsi.TabIndex = 20;
            this.checkBoxFilterDsi.Text = "DSi";
            this.checkBoxFilterDsi.UseVisualStyleBackColor = true;
            this.checkBoxFilterDsi.CheckedChanged += new EventHandler(this.filters_Changed);
            this.checkBoxFilterAp.AutoSize = true;
            this.checkBoxFilterAp.Cursor = Cursors.Hand;
            this.checkBoxFilterAp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxFilterAp.Location = new Point(0x81, 6);
            this.checkBoxFilterAp.Name = "checkBoxFilterAp";
            this.checkBoxFilterAp.Size = new Size(0x47, 0x10);
            this.checkBoxFilterAp.TabIndex = 15;
            this.checkBoxFilterAp.Text = "AP Patch";
            this.checkBoxFilterAp.UseVisualStyleBackColor = true;
            this.checkBoxFilterAp.CheckedChanged += new EventHandler(this.filters_Changed);
            this.pictureBox4.Image = Resources.dscompat;
            this.pictureBox4.Location = new Point(6, 0x15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(0x26, 0x19);
            this.pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 0x13;
            this.pictureBox4.TabStop = false;
            this.checkBoxFilterWifi.AutoSize = true;
            this.checkBoxFilterWifi.Cursor = Cursors.Hand;
            this.checkBoxFilterWifi.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxFilterWifi.Location = new Point(0x30, 6);
            this.checkBoxFilterWifi.Name = "checkBoxFilterWifi";
            this.checkBoxFilterWifi.Size = new Size(0x2d, 0x10);
            this.checkBoxFilterWifi.TabIndex = 0x11;
            this.checkBoxFilterWifi.Text = "WiFi";
            this.checkBoxFilterWifi.UseVisualStyleBackColor = true;
            this.checkBoxFilterWifi.CheckedChanged += new EventHandler(this.filters_Changed);
            this.pictureBox1.Image = Resources.cmp_icon;
            this.pictureBox1.Location = new Point(0x6c, 0x1c);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x10, 0x10);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox2.Image = Resources.ap_icon;
            this.pictureBox2.Location = new Point(0x6c, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(0x10, 0x10);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.checkBoxFilterCmp.AutoSize = true;
            this.checkBoxFilterCmp.Cursor = Cursors.Hand;
            this.checkBoxFilterCmp.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBoxFilterCmp.Location = new Point(0x81, 30);
            this.checkBoxFilterCmp.Name = "checkBoxFilterCmp";
            this.checkBoxFilterCmp.Size = new Size(60, 0x10);
            this.checkBoxFilterCmp.TabIndex = 14;
            this.checkBoxFilterCmp.Text = "Cheats";
            this.checkBoxFilterCmp.UseVisualStyleBackColor = true;
            this.checkBoxFilterCmp.CheckedChanged += new EventHandler(this.filters_Changed);
            this.tabPage2.Controls.Add(this.chk_3ds_ninnet);
            this.tabPage2.Controls.Add(this.chk_3ds_slidepad);
            this.tabPage2.Controls.Add(this.chk_3ds_streetpass);
            this.tabPage2.Controls.Add(this.chk_3ds_spotpass);
            this.tabPage2.Controls.Add(this.chk_3ds_multicartplay);
            this.tabPage2.Controls.Add(this.chk_3ds_onlineplay);
            this.tabPage2.Controls.Add(this.chk_3ds_downloadplay);
            this.tabPage2.Font = new Font("Verdana", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new Point(4, 0x1b);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(0xd0, 0x36);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "3DS";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.chk_3ds_ninnet.Cursor = Cursors.Hand;
            this.chk_3ds_ninnet.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chk_3ds_ninnet.Image = Resources.nintendo_network_small;
            this.chk_3ds_ninnet.Location = new Point(0x8e, 0x19);
            this.chk_3ds_ninnet.Name = "chk_3ds_ninnet";
            this.chk_3ds_ninnet.Size = new Size(40, 0x20);
            this.chk_3ds_ninnet.TabIndex = 0x18;
            this.chk_3ds_ninnet.UseVisualStyleBackColor = true;
            this.chk_3ds_ninnet.CheckedChanged += new EventHandler(this.chk_3ds_ninnet_CheckedChanged);
            this.chk_3ds_slidepad.Cursor = Cursors.Hand;
            this.chk_3ds_slidepad.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chk_3ds_slidepad.Image = Resources.slidepad;
            this.chk_3ds_slidepad.Location = new Point(0x60, 0x19);
            this.chk_3ds_slidepad.Name = "chk_3ds_slidepad";
            this.chk_3ds_slidepad.Size = new Size(40, 0x20);
            this.chk_3ds_slidepad.TabIndex = 0x17;
            this.chk_3ds_slidepad.UseVisualStyleBackColor = true;
            this.chk_3ds_slidepad.CheckedChanged += new EventHandler(this.chk_3ds_slidepad_CheckedChanged);
            this.chk_3ds_streetpass.Cursor = Cursors.Hand;
            this.chk_3ds_streetpass.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chk_3ds_streetpass.Image = Resources.streetpass;
            this.chk_3ds_streetpass.Location = new Point(0x60, 0);
            this.chk_3ds_streetpass.Name = "chk_3ds_streetpass";
            this.chk_3ds_streetpass.Size = new Size(40, 0x20);
            this.chk_3ds_streetpass.TabIndex = 0x16;
            this.chk_3ds_streetpass.UseVisualStyleBackColor = true;
            this.chk_3ds_streetpass.CheckedChanged += new EventHandler(this.chk_3ds_streetpass_CheckedChanged);
            this.chk_3ds_spotpass.Cursor = Cursors.Hand;
            this.chk_3ds_spotpass.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chk_3ds_spotpass.Image = Resources.spotpass;
            this.chk_3ds_spotpass.Location = new Point(50, 0x19);
            this.chk_3ds_spotpass.Name = "chk_3ds_spotpass";
            this.chk_3ds_spotpass.Size = new Size(40, 0x20);
            this.chk_3ds_spotpass.TabIndex = 0x15;
            this.chk_3ds_spotpass.UseVisualStyleBackColor = true;
            this.chk_3ds_spotpass.CheckedChanged += new EventHandler(this.chk_3ds_spotpass_CheckedChanged);
            this.chk_3ds_multicartplay.Cursor = Cursors.Hand;
            this.chk_3ds_multicartplay.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chk_3ds_multicartplay.Image = Resources.multicartplay;
            this.chk_3ds_multicartplay.Location = new Point(50, 0);
            this.chk_3ds_multicartplay.Name = "chk_3ds_multicartplay";
            this.chk_3ds_multicartplay.Size = new Size(40, 0x20);
            this.chk_3ds_multicartplay.TabIndex = 20;
            this.chk_3ds_multicartplay.UseVisualStyleBackColor = true;
            this.chk_3ds_multicartplay.CheckedChanged += new EventHandler(this.chk_3ds_multicartplay_CheckedChanged);
            this.chk_3ds_onlineplay.Cursor = Cursors.Hand;
            this.chk_3ds_onlineplay.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chk_3ds_onlineplay.Image = Resources.onlineplay;
            this.chk_3ds_onlineplay.Location = new Point(4, 0x19);
            this.chk_3ds_onlineplay.Name = "chk_3ds_onlineplay";
            this.chk_3ds_onlineplay.Size = new Size(40, 0x20);
            this.chk_3ds_onlineplay.TabIndex = 0x13;
            this.chk_3ds_onlineplay.UseVisualStyleBackColor = true;
            this.chk_3ds_onlineplay.CheckedChanged += new EventHandler(this.chk_3ds_onlineplay_CheckedChanged);
            this.chk_3ds_downloadplay.Cursor = Cursors.Hand;
            this.chk_3ds_downloadplay.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chk_3ds_downloadplay.Image = Resources.downloadplay;
            this.chk_3ds_downloadplay.Location = new Point(4, 0);
            this.chk_3ds_downloadplay.Name = "chk_3ds_downloadplay";
            this.chk_3ds_downloadplay.Size = new Size(40, 0x20);
            this.chk_3ds_downloadplay.TabIndex = 0x12;
            this.chk_3ds_downloadplay.UseVisualStyleBackColor = true;
            this.chk_3ds_downloadplay.CheckedChanged += new EventHandler(this.chk_3ds_downloadplay_CheckedChanged);
            this.comboFilterRomNum.Cursor = Cursors.Hand;
            this.comboFilterRomNum.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.comboFilterRomNum.FormattingEnabled = true;
            this.comboFilterRomNum.Location = new Point(8, 0x19);
            this.comboFilterRomNum.Name = "comboFilterRomNum";
            this.comboFilterRomNum.Size = new Size(0x93, 20);
            this.comboFilterRomNum.Sorted = true;
            this.comboFilterRomNum.TabIndex = 0x12;
            this.comboFilterRomNum.SelectedIndexChanged += new EventHandler(this.filters_Changed);
            this.txtFilterName.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtFilterName.Location = new Point(8, 0x60);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new Size(0x16f, 0x12);
            this.txtFilterName.TabIndex = 0;
            this.txtFilterName.Text = "Search for a game by name...";
            this.txtFilterName.TextChanged += new EventHandler(this.filters_Changed);
            this.txtFilterName.Enter += new EventHandler(this.txtFilterName_Enter);
            this.txtFilterName.Leave += new EventHandler(this.txtFilterName_Leave);
            this.comboFilterGroup.Cursor = Cursors.Hand;
            this.comboFilterGroup.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.comboFilterGroup.FormattingEnabled = true;
            this.comboFilterGroup.Location = new Point(8, 0x47);
            this.comboFilterGroup.Name = "comboFilterGroup";
            this.comboFilterGroup.Size = new Size(0x93, 20);
            this.comboFilterGroup.Sorted = true;
            this.comboFilterGroup.TabIndex = 10;
            this.comboFilterGroup.SelectedIndexChanged += new EventHandler(this.filters_Changed);
            this.comboFilterRegion.Cursor = Cursors.Hand;
            this.comboFilterRegion.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.comboFilterRegion.FormattingEnabled = true;
            this.comboFilterRegion.Location = new Point(8, 0x30);
            this.comboFilterRegion.Name = "comboFilterRegion";
            this.comboFilterRegion.Size = new Size(0x93, 20);
            this.comboFilterRegion.Sorted = true;
            this.comboFilterRegion.TabIndex = 8;
            this.comboFilterRegion.SelectedIndexChanged += new EventHandler(this.filters_Changed);
            this.keyPressTimer.Interval = 0x3e8;
            this.keyPressTimer.Tick += new EventHandler(this.keyPressTimer_Tick);
            this.panel1.BackColor = SystemColors.Control;
            this.panel1.Controls.Add(this.toolStripStatusLabel);
            this.panel1.Controls.Add(this.toolStripProgressBar);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(5, 0x19f);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(380, 0x10);
            this.panel1.TabIndex = 0x5e;
            this.toolStripStatusLabel.Dock = DockStyle.Left;
            this.toolStripStatusLabel.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.toolStripStatusLabel.Location = new Point(0, 0);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.RightToLeft = RightToLeft.No;
            this.toolStripStatusLabel.Size = new Size(0x116, 0x10);
            this.toolStripStatusLabel.TabIndex = 0x5c;
            this.toolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            this.toolStripProgressBar.Dock = DockStyle.Right;
            this.toolStripProgressBar.Location = new Point(0x11c, 0);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new Size(0x60, 0x10);
            this.toolStripProgressBar.TabIndex = 0x5b;
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.rightClickFavorite, this.toolStripSeparator1, this.rightClickDelete };
            this.contextMenuStrip1.Items.AddRange(toolStripItems);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x86, 0x36);
            this.contextMenuStrip1.Text = "Rom Options";
            this.rightClickFavorite.Image = Resources.favorite;
            this.rightClickFavorite.Name = "rightClickFavorite";
            this.rightClickFavorite.Size = new Size(0x98, 0x16);
            this.rightClickFavorite.Text = "Favourite";
            this.rightClickFavorite.Click += new EventHandler(this.rightClickFavorite_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(0x95, 6);
            this.rightClickDelete.Enabled = false;
            this.rightClickDelete.Image = Resources.bin_metal_full;
            this.rightClickDelete.Name = "rightClickDelete";
            this.rightClickDelete.Size = new Size(0x85, 0x16);
            this.rightClickDelete.Text = "Delete Rom";
            this.rightClickDelete.Click += new EventHandler(this.rightClickDelete_Click);
            base.AutoScaleDimensions = new SizeF(7f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            base.ClientSize = new Size(390, 0x1b4);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.grpChooseCollection);
            base.Controls.Add(this.groupBoxFilters);
            base.Controls.Add(this.listViewRoms);
            this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximumSize = new Size(650, 0x2710);
            this.MinimumSize = new Size(0x196, 0x1da);
            base.Name = "collectionViewer";
            base.Padding = new Padding(5, 150, 5, 5);
            this.Text = "DS-Scene Rom Tool: Collection Browser";
            base.FormClosed += new FormClosedEventHandler(this.Form_FormClosing);
            base.Shown += new EventHandler(this.collectionForm_Shown);
            base.ResizeBegin += new EventHandler(this.collectionViewer_ResizeBegin);
            base.ResizeEnd += new EventHandler(this.collectionViewer_ResizeEnd);
            base.SizeChanged += new EventHandler(this.collectionViewer_SizeChanged);
            this.grpChooseCollection.ResumeLayout(false);
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((ISupportInitialize) this.pictureBox3).EndInit();
            ((ISupportInitialize) this.pictureBox4).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void keyPressTimer_Tick(object sender, EventArgs e)
        {
            this.activateTimeoutKeyedSearch();
        }

        private void listCollectionDbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fillRomList(true);
            if (Program.form.collectiondb.activeDb != int.Parse(Program.form.options.getValue("active_collection_db")))
            {
                Program.form.options.save();
                Program.form.options.load();
            }
        }

        private void listViewRoms_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listViewRoms.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            if (e.Column == this.romSortColumn)
            {
                this.listViewRoms.Sorting = (this.listViewRoms.Sorting != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending;
            }
            else
            {
                this.romSortColumn = e.Column;
                this.listViewRoms.Sorting = SortOrder.Ascending;
            }
            this.listViewRoms.Sort();
            this.listViewRoms.ListViewItemSorter = new ListViewItemComparer(e.Column, this.listViewRoms.Sorting);
        }

        private void listViewRoms_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.listViewRoms, new Point(e.X, e.Y));
            }
        }

        private void listViewRoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.listViewRoms.SelectedItems.Count > 0) && ((this.listViewRoms.SelectedItems[0].SubItems.Count > 3) && (this.selectedRom != this.listViewRoms.SelectedItems[0].SubItems[4].Text)))
            {
                this.selectedRom = this.listViewRoms.SelectedItems[0].SubItems[4].Text;
                if (!Program.form.action_browse(this.listViewRoms.SelectedItems[0].SubItems[4].Text, this.listViewRoms.SelectedItems[0].SubItems[5].Text))
                {
                    if (MessageBox.Show("There appears to be some missing roms in the collection.\n\nDo you want to scan and remove all\nmissing entries from the collection?", "Scan & Remove Missing Entries?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    this.fillRomList(true);
                }
                else
                {
                    this.rightClickDelete.Enabled = !Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].item[int.Parse(this.listViewRoms.SelectedItems[0].Tag.ToString())].favourite;
                    this.listViewRoms.Focus();
                }
            }
        }

        private void resizeForm()
        {
            this.extraWidth = Program.form.collectionForm.Width - this.formWidth;
            this.extraHeight = Program.form.collectionForm.Height - this.formHeight;
            this.listViewRoms.Width = 380 + this.extraWidth;
            this.listViewRoms.Height = 0xe8 + this.extraHeight;
            this.listViewRoms.Location = new Point(this.listViewRoms.Location.X, 180);
            this.grpChooseCollection.Width = 380 + this.extraWidth;
            this.groupBoxFilters.Width = 380 + this.extraWidth;
            this.comboFilterRomNum.Width = 0x93 + this.extraWidth;
            this.comboFilterGroup.Width = 0x93 + this.extraWidth;
            this.comboFilterRegion.Width = 0x93 + this.extraWidth;
            this.txtFilterName.Width = 0x16f + this.extraWidth;
            this.listCollectionDbs.Width = 0x113 + this.extraWidth;
            this.toolStripStatusLabel.Width = 0x116 + this.extraWidth;
            if (this.loadingForm && ((base.Location.X - this.extraWidth) >= 0))
            {
                base.Location = new Point(base.Location.X - this.extraWidth, base.Location.Y);
            }
            else if (this.loadingForm && ((base.Location.X - this.extraWidth) < 0))
            {
                base.Location = new Point(0, base.Location.Y);
            }
            Program.form.Location = new Point(base.Location.X + base.Width, base.Location.Y);
        }

        private void rightClickDelete_Click(object sender, EventArgs e)
        {
            string str2;
            string gameLoc = Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].item[int.Parse(this.listViewRoms.SelectedItems[0].Tag.ToString())].gameLoc;
            if (gameLoc.Replace("/", "") != gameLoc)
            {
                str2 = gameLoc.Substring(0, gameLoc.LastIndexOf("/"));
                gameLoc = str2.Substring(str2.LastIndexOf("/") + 1, (str2.Length - str2.LastIndexOf("/")) - 1);
            }
            else
            {
                str2 = gameLoc.Substring(0, gameLoc.LastIndexOf(@"\"));
                gameLoc = str2.Substring(str2.LastIndexOf(@"\") + 1, (str2.Length - str2.LastIndexOf(@"\")) - 1);
            }
            if (MessageBox.Show(gameLoc + "\n\nAre you sure you want to delete this item from the collection?", "Confirm Delete Item", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (string str3 in Directory.GetFiles(str2))
                {
                    System.IO.File.Delete(str3);
                }
                Directory.Delete(str2);
                Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].item[int.Parse(this.listViewRoms.SelectedItems[0].Tag.ToString())].delete = true;
                Program.form.collectiondb.removeMarkedItems();
            }
        }

        private void rightClickFavorite_Click(object sender, EventArgs e)
        {
            if (this.listViewRoms.SelectedItems.Count > 0)
            {
                if (this.listViewRoms.SelectedItems[0].ImageIndex >= 2)
                {
                    Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].item[int.Parse(this.listViewRoms.SelectedItems[0].Tag.ToString())].favourite = false;
                    Program.form.collectiondb.saveDb(this.listCollectionDbs.SelectedIndex);
                    ListViewItem item1 = this.listViewRoms.SelectedItems[0];
                    item1.ImageIndex -= 2;
                }
                else
                {
                    Program.form.collectiondb.db[this.listCollectionDbs.SelectedIndex].item[int.Parse(this.listViewRoms.SelectedItems[0].Tag.ToString())].favourite = true;
                    Program.form.collectiondb.saveDb(this.listCollectionDbs.SelectedIndex);
                    ListViewItem item2 = this.listViewRoms.SelectedItems[0];
                    item2.ImageIndex += 2;
                }
            }
        }

        private void startKeyPressTimer(bool timer)
        {
            timer = this.timerloadFilters;
            if (this.keyPressTimer.Enabled)
            {
                this.keyPressTimer.Enabled = false;
            }
            this.keyPressTimer.Enabled = true;
        }

        private void txtFilterName_Enter(object sender, EventArgs e)
        {
            this.txtFilterName.Text = "";
        }

        private void txtFilterName_Leave(object sender, EventArgs e)
        {
            if (this.txtFilterName.Text == "")
            {
                this.txtFilterName.Text = "Search for a game by name...";
            }
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

