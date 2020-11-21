namespace PSPo2iSaveEditor
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class pspo2seInfinityMissionForm : Form
    {
        private IContainer components;
        private TextBox txtHex;
        private GroupBox groupBox1;
        private ComboBox comboArea;
        private ComboBox comboLength;
        private GroupBox groupBox2;
        private ComboBox comboEnemyLevelMod;
        private ComboBox comboEnemyLevel;
        private GroupBox groupBox3;
        private ComboBox comboEnemy1Mod;
        private ComboBox comboEnemy1;
        private GroupBox groupBox4;
        private ComboBox comboEnemy2;
        private GroupBox groupBox5;
        private ComboBox comboBoss;
        private Button btnCancel;
        private Button btnApply;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private TextBox txtCreator;
        private GroupBox groupBox8;
        private Label label1;
        private ComboBox comboMapMod1;
        private ComboBox comboEnemyTable2;
        private ComboBox comboEnemyTable1;
        private GroupBox groupBox9;
        private Label label7;
        private NumericUpDown numClearedInf;
        private Label label5;
        private NumericUpDown numClearedS;
        private Label label6;
        private NumericUpDown numClearedA;
        private Label label4;
        private NumericUpDown numClearedB;
        private Label label3;
        private NumericUpDown numClearedC;
        private Label label2;
        private NumericUpDown numSynthPoint;
        private ComboBox comboMapMod3;
        private ComboBox comboMapMod2;
        private PictureBox picMap1;
        private GroupBox grpArea1;
        private PictureBox picArea1;
        private GroupBox grpArea2;
        private PictureBox picArea2;
        private PictureBox picMap2;
        private GroupBox grpArea3;
        private PictureBox picArea3;
        private PictureBox picMap3;
        private PictureBox picBoss;
        private ImageList imgListMaps;
        private ImageList imgListAreaThemes;
        private ImageList imgListBoss;
        private Button btnModHex;
        private Button btnEditSpecialHex;
        private TextBox txtSpecialHex;
        private GroupBox groupBox10;
        private CheckBox chkEnemyTable1Mod;
        private ComboBox comboEnemyTable2Mod;
        public string editedHex = "";
        private int loadedId;
        private bool dontUpdateHex;

        public pspo2seInfinityMissionForm()
        {
            this.InitializeComponent();
        }

        private Image areaMapToThemeImage(int map)
        {
            int num = this.areaMapToThemeNum(map);
            return this.imgListAreaThemes.Images[num];
        }

        private int areaMapToThemeNum(int map)
        {
            if (map != -1)
            {
                switch (this.comboArea.SelectedIndex)
                {
                    case 0:
                        switch (map)
                        {
                            case 0:
                                return 0;

                            case 1:
                                return 0;

                            case 2:
                                return 1;

                            case 3:
                                return 1;

                            case 4:
                                return 1;

                            case 5:
                                return 1;

                            case 6:
                                return 0;

                            case 7:
                                return 0;

                            case 8:
                                return 0;

                            case 9:
                                return 0;

                            default:
                                break;
                        }
                        break;

                    case 1:
                        return 2;

                    case 2:
                        return 3;

                    case 3:
                        switch (map)
                        {
                            case 0:
                                return 4;

                            case 1:
                                return 4;

                            case 2:
                                return 4;

                            case 3:
                                return 4;

                            case 4:
                                return 5;

                            case 5:
                                return 5;

                            case 6:
                                return 5;

                            case 7:
                                return 5;

                            case 8:
                                return 5;

                            case 9:
                                return 5;

                            default:
                                break;
                        }
                        break;

                    case 4:
                        switch (map)
                        {
                            case 0:
                                return 6;

                            case 1:
                                return 6;

                            case 2:
                                return 6;

                            case 3:
                                return 7;

                            case 4:
                                return 7;

                            case 5:
                                return 7;

                            case 6:
                                return 8;

                            case 7:
                                return 8;

                            case 8:
                                return 8;

                            case 9:
                                return 8;

                            default:
                                break;
                        }
                        break;

                    case 5:
                        switch (map)
                        {
                            case 0:
                                return 9;

                            case 1:
                                return 9;

                            case 2:
                                return 9;

                            case 3:
                                return 9;

                            case 4:
                                return 10;

                            case 5:
                                return 10;

                            case 6:
                                return 11;

                            case 7:
                                return 11;

                            case 8:
                                return 12;

                            case 9:
                                return 12;

                            default:
                                break;
                        }
                        break;

                    case 6:
                        switch (map)
                        {
                            case 0:
                                return 13;

                            case 1:
                                return 13;

                            case 2:
                                return 13;

                            case 3:
                                return 13;

                            case 4:
                                return 14;

                            case 5:
                                return 14;

                            case 6:
                                return 14;

                            case 7:
                                return 15;

                            case 8:
                                return 15;

                            case 9:
                                return 15;

                            default:
                                break;
                        }
                        break;

                    case 7:
                        switch (map)
                        {
                            case 0:
                                return 0x10;

                            case 1:
                                return 0x10;

                            case 2:
                                return 0x10;

                            case 3:
                                return 0x10;

                            case 4:
                                return 0x10;

                            case 5:
                                return 0x10;

                            case 6:
                                return 0x10;

                            case 7:
                                return 0x10;

                            case 8:
                                return 0x11;

                            case 9:
                                return 0x11;

                            default:
                                break;
                        }
                        break;

                    case 8:
                        return 0x12;

                    case 9:
                        return 0x13;

                    default:
                        break;
                }
            }
            return 20;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if ((((this.comboMapMod1.SelectedIndex == this.comboMapMod2.SelectedIndex) && (this.comboLength.SelectedIndex > 0)) || ((this.comboMapMod1.SelectedIndex == this.comboMapMod3.SelectedIndex) && (this.comboLength.SelectedIndex > 2))) || ((this.comboMapMod1.SelectedIndex == this.comboMapMod3.SelectedIndex) && (this.comboLength.SelectedIndex > 2)))
            {
                MessageBox.Show("You cannot use the same area map more than once.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.editedHex.Length < 0xd0)
            {
                MessageBox.Show("Error: The hex data is not the correct length");
            }
            else if (MessageBox.Show("Are you sure you want to overwrite the selected mission?", "Confirm Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
            {
                int pos = Program.form.mainSettings.saveStructureIndex.infinity_mission_pos + (0x68 * this.id);
                base.Close();
                Program.form.overwriteHexInBuffer(this.editedHex, pos);
                Program.form.reloadEverything();
                Program.form.tabArea.SelectedIndex = 4;
                Program.form.tabControlMissions.SelectedIndex = 2;
                Program.form.lstInfinityMissions.Items[this.id].Selected = true;
                Program.form.lstInfinityMissions.Items[this.id].EnsureVisible();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnEditSpecialHex_Click(object sender, EventArgs e)
        {
            pspo2seForm.infinityMissionClass class1 = Program.form.saveData.infinityMissions.slot[this.id];
            Program.form.entryForm.oldVal = this.editedHex.Substring(12, 20);
            Program.form.entryForm.newVal = this.editedHex.Substring(12, 20);
            Program.form.entryForm.description = "special effect hex";
            Program.form.entryForm.maxLen = 20;
            if (Program.form.entryForm.ShowDialog(this) == DialogResult.OK)
            {
                string newVal = Program.form.entryForm.newVal;
                if (newVal != this.editedHex.Substring(12, 20))
                {
                    if (newVal.Length != 20)
                    {
                        MessageBox.Show("The hex length must be 10 bytes (20 characters).", "Special Hex Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        this.updateHex(newVal, 12);
                    }
                }
            }
        }

        private void btnModHex_Click(object sender, EventArgs e)
        {
            pspo2seForm.infinityMissionClass class1 = Program.form.saveData.infinityMissions.slot[this.id];
            Program.form.entryForm.oldVal = this.editedHex.Substring(12, 20);
            Program.form.entryForm.newVal = this.editedHex.Substring(12, 20);
            Program.form.entryForm.description = "special effect hex mod";
            Program.form.entryForm.maxLen = 20;
            if (Program.form.entryForm.ShowDialog(this) == DialogResult.OK)
            {
                string newVal = Program.form.entryForm.newVal;
                if (newVal != this.editedHex.Substring(12, 20))
                {
                    if (newVal.Length != 20)
                    {
                        MessageBox.Show("The hex length must be 10 bytes (20 characters).", "Special Hex Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        this.updateHex(newVal, 12);
                    }
                }
            }
        }

        private void chkEnemyTable1Mod_CheckedChanged(object sender, EventArgs e)
        {
            this.comboEnemyTable1_SelectedIndexChanged(sender, e);
        }

        private void comboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboArea.SelectedIndex >= 0)
            {
                string newhex = (this.comboArea.SelectedIndex + 1).ToString("X1");
                this.updateHex(newhex, 1);
                this.comboMapMod1_SelectedIndexChanged(sender, e);
                this.comboMapMod2_SelectedIndexChanged(sender, e);
                this.comboMapMod3_SelectedIndexChanged(sender, e);
            }
        }

        private void comboBoss_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.comboBoss.SelectedIndex >= 0) && (this.comboLength.SelectedIndex >= 0))
            {
                string str = ((this.comboBoss.SelectedIndex + (0x40 * (this.comboLength.SelectedIndex + 1))) + 1).ToString("X1");
                while (str.Length < 2)
                {
                    str = "0" + str;
                }
                this.updateHex(str.Substring(0, 1), 3);
                this.updateHex(str.Substring(1, 1), 0);
                switch (this.comboLength.SelectedIndex)
                {
                    case 0:
                        this.grpArea2.Enabled = false;
                        this.grpArea3.Enabled = false;
                        break;

                    case 1:
                        this.grpArea2.Enabled = true;
                        this.grpArea3.Enabled = false;
                        break;

                    case 2:
                        this.grpArea2.Enabled = true;
                        this.grpArea3.Enabled = true;
                        break;

                    default:
                        break;
                }
                this.picBoss.Image = this.imgListBoss.Images[this.comboBoss.SelectedIndex];
            }
        }

        private void comboEnemy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.comboEnemy1.SelectedIndex >= 0) && (this.comboEnemy1Mod.SelectedIndex >= 0))
            {
                string newhex = (this.comboEnemy1Mod.SelectedIndex + (2 * this.comboEnemy1.SelectedIndex)).ToString("X1");
                this.updateHex(newhex, 4);
            }
        }

        private void comboEnemy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEnemy2.SelectedIndex >= 0)
            {
                string newhex = this.comboEnemy2.SelectedIndex.ToString("X1");
                this.updateHex(newhex, 7);
            }
        }

        private void comboEnemyLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.comboEnemyLevel.SelectedIndex >= 0) && (this.comboEnemyLevelMod.SelectedIndex >= 0))
            {
                string newhex = ((this.comboEnemyLevel.SelectedIndex + 1) + (0x40 * this.comboEnemyLevelMod.SelectedIndex)).ToString("X1");
                while (newhex.Length < 2)
                {
                    newhex = "0" + newhex;
                }
                this.updateHex(newhex, 10);
            }
        }

        private void comboEnemyTable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEnemyTable1.SelectedIndex >= 0)
            {
                int num = this.comboEnemyTable1.SelectedIndex + 1;
                if (this.chkEnemyTable1Mod.Checked)
                {
                    num += 8;
                }
                string newhex = num.ToString("X1");
                this.updateHex(newhex, 2);
            }
        }

        private void comboEnemyTable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEnemyTable2.SelectedIndex >= 0)
            {
                string newhex = (this.comboEnemyTable2.SelectedIndex + (this.comboEnemyTable2Mod.SelectedIndex * 4)).ToString("X1");
                this.updateHex(newhex, 5);
            }
        }

        private void comboMapMod1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboMapMod1.SelectedIndex >= 0)
            {
                if (((this.comboArea.SelectedIndex != 1) && ((this.comboArea.SelectedIndex != 8) && (this.comboMapMod1.SelectedIndex > 9))) || (this.comboMapMod1.SelectedIndex > 10))
                {
                    MessageBox.Show("This map is known to crash, proceed with caution.", "Known Map Issue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                string newhex = this.comboMapMod1.SelectedIndex.ToString("X1");
                this.updateHex(newhex, 6);
                this.picMap1.Image = this.imgListMaps.Images[(this.comboArea.SelectedIndex * 10) + this.comboMapMod1.SelectedIndex];
                this.picArea1.Image = this.areaMapToThemeImage(this.comboMapMod1.SelectedIndex);
            }
        }

        private void comboMapMod2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboMapMod2.SelectedIndex >= 0)
            {
                if (((this.comboArea.SelectedIndex != 1) && ((this.comboArea.SelectedIndex != 8) && (this.comboMapMod2.SelectedIndex > 9))) || (this.comboMapMod2.SelectedIndex > 10))
                {
                    MessageBox.Show("This map is known to crash, proceed with caution.", "Known Map Issue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                string newhex = this.comboMapMod2.SelectedIndex.ToString("X1");
                this.updateHex(newhex, 9);
                this.picMap2.Image = this.imgListMaps.Images[(this.comboArea.SelectedIndex * 10) + this.comboMapMod2.SelectedIndex];
                this.picArea2.Image = this.areaMapToThemeImage(this.comboMapMod2.SelectedIndex);
            }
        }

        private void comboMapMod3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboMapMod3.SelectedIndex >= 0)
            {
                if (((this.comboArea.SelectedIndex != 1) && ((this.comboArea.SelectedIndex != 8) && (this.comboMapMod3.SelectedIndex > 9))) || (this.comboMapMod3.SelectedIndex > 10))
                {
                    MessageBox.Show("This map is known to crash, proceed with caution.", "Known Map Issue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                string newhex = this.comboMapMod3.SelectedIndex.ToString("X1");
                this.updateHex(newhex, 8);
                this.picMap3.Image = this.imgListMaps.Images[(this.comboArea.SelectedIndex * 10) + this.comboMapMod3.SelectedIndex];
                this.picArea3.Image = this.areaMapToThemeImage(this.comboMapMod3.SelectedIndex);
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

        private void fillCombos()
        {
            this.comboArea.Items.Clear();
            for (int i = 1; i < 11; i++)
            {
                string[] strArray = new string[] { i.ToString("D2"), ". ", Program.form.intToInfinityArea(i - 1)[1], " (", Program.form.intToInfinityArea(i - 1)[0], ")" };
                this.comboArea.Items.Add(string.Concat(strArray));
            }
            this.comboBoss.Items.Clear();
            for (int j = 1; j < 0x29; j++)
            {
                string[] strArray2 = new string[] { j.ToString("D2"), ". ", Program.form.intToInfinityBoss(j - 1)[1], " (", Program.form.intToInfinityBoss(j - 1)[0], ")" };
                this.comboBoss.Items.Add(string.Concat(strArray2));
            }
            this.comboEnemyLevel.Items.Clear();
            for (int k = 1; k < 50; k++)
            {
                this.comboEnemyLevel.Items.Add("Enemy Level +" + k);
            }
            this.comboEnemyLevelMod.Items.Clear();
            for (int m = 0; m < 4; m++)
            {
                this.comboEnemyLevelMod.Items.Add("Unknown Mod " + m);
            }
            this.comboEnemy1.Items.Clear();
            this.comboEnemy2.Items.Clear();
            for (int n = 1; n < 8; n++)
            {
                string[] strArray3 = new string[] { n.ToString("D2"), ". ", Program.form.intToInfinityEnemy(n - 1)[1], " (", Program.form.intToInfinityEnemy(n - 1)[0], ")" };
                this.comboEnemy1.Items.Add(string.Concat(strArray3));
                string[] strArray4 = new string[] { n.ToString("D2"), ". ", Program.form.intToInfinityEnemy(n - 1)[1], " (", Program.form.intToInfinityEnemy(n - 1)[0], ")" };
                this.comboEnemy2.Items.Add(string.Concat(strArray4));
            }
            this.comboEnemy1Mod.Items.Clear();
            for (int num6 = 0; num6 < 2; num6++)
            {
                this.comboEnemy1Mod.Items.Add("Unknown Mod " + num6);
            }
            this.comboEnemyTable1.Items.Clear();
            for (int num7 = 0; num7 < 5; num7++)
            {
                this.comboEnemyTable1.Items.Add("Table 01 Set 0" + (num7 + 1));
            }
            this.comboEnemyTable2.Items.Clear();
            this.comboEnemyTable2Mod.Items.Clear();
            for (int num8 = 0; num8 < 3; num8++)
            {
                this.comboEnemyTable2.Items.Add("Unknown Mod 0" + num8);
                this.comboEnemyTable2Mod.Items.Add("Mod 0" + num8);
            }
            this.comboMapMod1.Items.Clear();
            this.comboMapMod2.Items.Clear();
            this.comboMapMod3.Items.Clear();
            for (int num9 = 0; num9 < 10; num9++)
            {
                this.comboMapMod1.Items.Add("Area 01 Map " + num9.ToString("D2"));
                this.comboMapMod2.Items.Add("Area 02 Map " + num9.ToString("D2"));
                this.comboMapMod3.Items.Add("Area 03 Map " + num9.ToString("D2"));
            }
        }

        private void grpArea2_EnabledChanged(object sender, EventArgs e)
        {
            if (this.grpArea2.Enabled)
            {
                this.comboMapMod2_SelectedIndexChanged(sender, e);
            }
            else
            {
                this.picArea2.Image = this.areaMapToThemeImage(-1);
                this.picMap2.Image = this.imgListMaps.Images[100];
            }
        }

        private void grpArea3_EnabledChanged(object sender, EventArgs e)
        {
            if (this.grpArea3.Enabled)
            {
                this.comboMapMod3_SelectedIndexChanged(sender, e);
            }
            else
            {
                this.picArea3.Image = this.areaMapToThemeImage(-1);
                this.picMap3.Image = this.imgListMaps.Images[100];
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(pspo2seInfinityMissionForm));
            this.txtHex = new TextBox();
            this.groupBox1 = new GroupBox();
            this.comboLength = new ComboBox();
            this.comboArea = new ComboBox();
            this.comboMapMod3 = new ComboBox();
            this.comboMapMod2 = new ComboBox();
            this.comboMapMod1 = new ComboBox();
            this.groupBox2 = new GroupBox();
            this.comboEnemyLevelMod = new ComboBox();
            this.comboEnemyLevel = new ComboBox();
            this.groupBox3 = new GroupBox();
            this.comboEnemy1Mod = new ComboBox();
            this.comboEnemy1 = new ComboBox();
            this.groupBox4 = new GroupBox();
            this.comboEnemy2 = new ComboBox();
            this.groupBox5 = new GroupBox();
            this.picBoss = new PictureBox();
            this.comboBoss = new ComboBox();
            this.btnCancel = new Button();
            this.btnApply = new Button();
            this.groupBox6 = new GroupBox();
            this.btnModHex = new Button();
            this.btnEditSpecialHex = new Button();
            this.txtSpecialHex = new TextBox();
            this.groupBox7 = new GroupBox();
            this.txtCreator = new TextBox();
            this.groupBox8 = new GroupBox();
            this.chkEnemyTable1Mod = new CheckBox();
            this.label1 = new Label();
            this.comboEnemyTable2 = new ComboBox();
            this.comboEnemyTable1 = new ComboBox();
            this.groupBox9 = new GroupBox();
            this.label7 = new Label();
            this.numClearedInf = new NumericUpDown();
            this.label5 = new Label();
            this.numClearedS = new NumericUpDown();
            this.label6 = new Label();
            this.numClearedA = new NumericUpDown();
            this.label4 = new Label();
            this.numClearedB = new NumericUpDown();
            this.label3 = new Label();
            this.numClearedC = new NumericUpDown();
            this.label2 = new Label();
            this.numSynthPoint = new NumericUpDown();
            this.picMap1 = new PictureBox();
            this.grpArea1 = new GroupBox();
            this.picArea1 = new PictureBox();
            this.grpArea2 = new GroupBox();
            this.picArea2 = new PictureBox();
            this.picMap2 = new PictureBox();
            this.grpArea3 = new GroupBox();
            this.picArea3 = new PictureBox();
            this.picMap3 = new PictureBox();
            this.imgListMaps = new ImageList(this.components);
            this.imgListAreaThemes = new ImageList(this.components);
            this.imgListBoss = new ImageList(this.components);
            this.groupBox10 = new GroupBox();
            this.comboEnemyTable2Mod = new ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((ISupportInitialize) this.picBoss).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.numClearedInf.BeginInit();
            this.numClearedS.BeginInit();
            this.numClearedA.BeginInit();
            this.numClearedB.BeginInit();
            this.numClearedC.BeginInit();
            this.numSynthPoint.BeginInit();
            ((ISupportInitialize) this.picMap1).BeginInit();
            this.grpArea1.SuspendLayout();
            ((ISupportInitialize) this.picArea1).BeginInit();
            this.grpArea2.SuspendLayout();
            ((ISupportInitialize) this.picArea2).BeginInit();
            ((ISupportInitialize) this.picMap2).BeginInit();
            this.grpArea3.SuspendLayout();
            ((ISupportInitialize) this.picArea3).BeginInit();
            ((ISupportInitialize) this.picMap3).BeginInit();
            this.groupBox10.SuspendLayout();
            base.SuspendLayout();
            this.txtHex.BackColor = SystemColors.Window;
            this.txtHex.Enabled = false;
            this.txtHex.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtHex.ForeColor = SystemColors.WindowText;
            this.txtHex.Location = new Point(15, 0x13);
            this.txtHex.Margin = new Padding(3, 4, 3, 4);
            this.txtHex.Multiline = true;
            this.txtHex.Name = "txtHex";
            this.txtHex.ReadOnly = true;
            this.txtHex.Size = new Size(0xed, 0x62);
            this.txtHex.TabIndex = 0;
            this.txtHex.TextAlign = HorizontalAlignment.Center;
            this.groupBox1.Controls.Add(this.comboLength);
            this.groupBox1.Controls.Add(this.comboArea);
            this.groupBox1.Location = new Point(14, 12);
            this.groupBox1.Margin = new Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(3, 4, 3, 4);
            this.groupBox1.Size = new Size(0x10f, 0x54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            this.comboLength.Cursor = Cursors.Hand;
            this.comboLength.FormattingEnabled = true;
            object[] items = new object[] { "1 Area (Hack)", "2 Areas", "3 Areas" };
            this.comboLength.Items.AddRange(items);
            this.comboLength.Location = new Point(14, 0x2e);
            this.comboLength.Margin = new Padding(3, 4, 3, 4);
            this.comboLength.Name = "comboLength";
            this.comboLength.Size = new Size(0xed, 0x15);
            this.comboLength.TabIndex = 1;
            this.comboLength.SelectedIndexChanged += new EventHandler(this.comboBoss_SelectedIndexChanged);
            this.comboArea.Cursor = Cursors.Hand;
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new Point(14, 20);
            this.comboArea.Margin = new Padding(3, 4, 3, 4);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new Size(0xed, 0x15);
            this.comboArea.TabIndex = 0;
            this.comboArea.SelectedIndexChanged += new EventHandler(this.comboArea_SelectedIndexChanged);
            this.comboMapMod3.Cursor = Cursors.Hand;
            this.comboMapMod3.FormattingEnabled = true;
            object[] objArray2 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboMapMod3.Items.AddRange(objArray2);
            this.comboMapMod3.Location = new Point(14, 0x79);
            this.comboMapMod3.Margin = new Padding(3, 4, 3, 4);
            this.comboMapMod3.Name = "comboMapMod3";
            this.comboMapMod3.Size = new Size(0xed, 0x15);
            this.comboMapMod3.TabIndex = 10;
            this.comboMapMod3.SelectedIndexChanged += new EventHandler(this.comboMapMod3_SelectedIndexChanged);
            this.comboMapMod2.Cursor = Cursors.Hand;
            this.comboMapMod2.FormattingEnabled = true;
            object[] objArray3 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboMapMod2.Items.AddRange(objArray3);
            this.comboMapMod2.Location = new Point(14, 0x79);
            this.comboMapMod2.Margin = new Padding(3, 4, 3, 4);
            this.comboMapMod2.Name = "comboMapMod2";
            this.comboMapMod2.Size = new Size(0xed, 0x15);
            this.comboMapMod2.TabIndex = 9;
            this.comboMapMod2.SelectedIndexChanged += new EventHandler(this.comboMapMod2_SelectedIndexChanged);
            this.comboMapMod1.Cursor = Cursors.Hand;
            this.comboMapMod1.FormattingEnabled = true;
            object[] objArray4 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboMapMod1.Items.AddRange(objArray4);
            this.comboMapMod1.Location = new Point(14, 0x79);
            this.comboMapMod1.Margin = new Padding(3, 4, 3, 4);
            this.comboMapMod1.Name = "comboMapMod1";
            this.comboMapMod1.Size = new Size(0xed, 0x15);
            this.comboMapMod1.TabIndex = 6;
            this.comboMapMod1.SelectedIndexChanged += new EventHandler(this.comboMapMod1_SelectedIndexChanged);
            this.groupBox2.Controls.Add(this.comboEnemyLevelMod);
            this.groupBox2.Controls.Add(this.comboEnemyLevel);
            this.groupBox2.Location = new Point(300, 12);
            this.groupBox2.Margin = new Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new Padding(3, 4, 3, 4);
            this.groupBox2.Size = new Size(0x10f, 0x54);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enemy Level";
            this.comboEnemyLevelMod.Cursor = Cursors.Hand;
            this.comboEnemyLevelMod.FormattingEnabled = true;
            object[] objArray5 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboEnemyLevelMod.Items.AddRange(objArray5);
            this.comboEnemyLevelMod.Location = new Point(14, 0x2e);
            this.comboEnemyLevelMod.Margin = new Padding(3, 4, 3, 4);
            this.comboEnemyLevelMod.Name = "comboEnemyLevelMod";
            this.comboEnemyLevelMod.Size = new Size(0xed, 0x15);
            this.comboEnemyLevelMod.TabIndex = 3;
            this.comboEnemyLevelMod.SelectedIndexChanged += new EventHandler(this.comboEnemyLevel_SelectedIndexChanged);
            this.comboEnemyLevel.Cursor = Cursors.Hand;
            this.comboEnemyLevel.FormattingEnabled = true;
            object[] objArray6 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboEnemyLevel.Items.AddRange(objArray6);
            this.comboEnemyLevel.Location = new Point(14, 20);
            this.comboEnemyLevel.Margin = new Padding(3, 4, 3, 4);
            this.comboEnemyLevel.Name = "comboEnemyLevel";
            this.comboEnemyLevel.Size = new Size(0xed, 0x15);
            this.comboEnemyLevel.TabIndex = 2;
            this.comboEnemyLevel.SelectedIndexChanged += new EventHandler(this.comboEnemyLevel_SelectedIndexChanged);
            this.groupBox3.Controls.Add(this.comboEnemy1Mod);
            this.groupBox3.Controls.Add(this.comboEnemy1);
            this.groupBox3.Location = new Point(300, 0x106);
            this.groupBox3.Margin = new Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new Padding(3, 4, 3, 4);
            this.groupBox3.Size = new Size(0x10f, 0x52);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Primary Enemy";
            this.comboEnemy1Mod.Cursor = Cursors.Hand;
            this.comboEnemy1Mod.FormattingEnabled = true;
            object[] objArray7 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboEnemy1Mod.Items.AddRange(objArray7);
            this.comboEnemy1Mod.Location = new Point(14, 0x30);
            this.comboEnemy1Mod.Margin = new Padding(3, 4, 3, 4);
            this.comboEnemy1Mod.Name = "comboEnemy1Mod";
            this.comboEnemy1Mod.Size = new Size(0xed, 0x15);
            this.comboEnemy1Mod.TabIndex = 3;
            this.comboEnemy1Mod.SelectedIndexChanged += new EventHandler(this.comboEnemy1_SelectedIndexChanged);
            this.comboEnemy1.Cursor = Cursors.Hand;
            this.comboEnemy1.FormattingEnabled = true;
            object[] objArray8 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboEnemy1.Items.AddRange(objArray8);
            this.comboEnemy1.Location = new Point(14, 0x15);
            this.comboEnemy1.Margin = new Padding(3, 4, 3, 4);
            this.comboEnemy1.Name = "comboEnemy1";
            this.comboEnemy1.Size = new Size(0xed, 0x15);
            this.comboEnemy1.TabIndex = 2;
            this.comboEnemy1.SelectedIndexChanged += new EventHandler(this.comboEnemy1_SelectedIndexChanged);
            this.groupBox4.Controls.Add(this.comboEnemy2);
            this.groupBox4.Location = new Point(300, 0x15d);
            this.groupBox4.Margin = new Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new Padding(3, 4, 3, 4);
            this.groupBox4.Size = new Size(0x10f, 0x38);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Secondary Enemy";
            this.comboEnemy2.Cursor = Cursors.Hand;
            this.comboEnemy2.FormattingEnabled = true;
            object[] objArray9 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboEnemy2.Items.AddRange(objArray9);
            this.comboEnemy2.Location = new Point(14, 0x15);
            this.comboEnemy2.Margin = new Padding(3, 4, 3, 4);
            this.comboEnemy2.Name = "comboEnemy2";
            this.comboEnemy2.Size = new Size(0xed, 0x15);
            this.comboEnemy2.TabIndex = 2;
            this.comboEnemy2.SelectedIndexChanged += new EventHandler(this.comboEnemy2_SelectedIndexChanged);
            this.groupBox5.Controls.Add(this.picBoss);
            this.groupBox5.Controls.Add(this.comboBoss);
            this.groupBox5.Location = new Point(300, 0x66);
            this.groupBox5.Margin = new Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new Padding(3, 4, 3, 4);
            this.groupBox5.Size = new Size(0x10f, 0x98);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Boss";
            this.picBoss.Location = new Point(14, 0x13);
            this.picBoss.Margin = new Padding(3, 4, 3, 4);
            this.picBoss.Name = "picBoss";
            this.picBoss.Size = new Size(0x81, 0x60);
            this.picBoss.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picBoss.TabIndex = 15;
            this.picBoss.TabStop = false;
            this.comboBoss.Cursor = Cursors.Hand;
            this.comboBoss.FormattingEnabled = true;
            object[] objArray10 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboBoss.Items.AddRange(objArray10);
            this.comboBoss.Location = new Point(14, 0x79);
            this.comboBoss.Margin = new Padding(3, 4, 3, 4);
            this.comboBoss.Name = "comboBoss";
            this.comboBoss.Size = new Size(0xed, 0x15);
            this.comboBoss.TabIndex = 2;
            this.comboBoss.SelectedIndexChanged += new EventHandler(this.comboBoss_SelectedIndexChanged);
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Location = new Point(0x309, 0x229);
            this.btnCancel.Margin = new Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x57, 0x1b);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnApply.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnApply.Cursor = Cursors.Hand;
            this.btnApply.Location = new Point(0x2ac, 0x229);
            this.btnApply.Margin = new Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new Size(0x57, 0x1b);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new EventHandler(this.btnApply_Click);
            this.groupBox6.Controls.Add(this.btnModHex);
            this.groupBox6.Controls.Add(this.btnEditSpecialHex);
            this.groupBox6.Controls.Add(this.txtSpecialHex);
            this.groupBox6.Location = new Point(0x24b, 0x112);
            this.groupBox6.Margin = new Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new Padding(3, 4, 3, 4);
            this.groupBox6.Size = new Size(0x10f, 0x67);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Special Hex Data";
            this.btnModHex.Cursor = Cursors.Hand;
            this.btnModHex.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnModHex.Location = new Point(0x67, 0x43);
            this.btnModHex.Name = "btnModHex";
            this.btnModHex.Size = new Size(0x4b, 0x17);
            this.btnModHex.TabIndex = 2;
            this.btnModHex.Text = "use mod";
            this.btnModHex.UseVisualStyleBackColor = true;
            this.btnModHex.Click += new EventHandler(this.btnModHex_Click);
            this.btnEditSpecialHex.Cursor = Cursors.Hand;
            this.btnEditSpecialHex.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnEditSpecialHex.Location = new Point(0xb2, 0x43);
            this.btnEditSpecialHex.Name = "btnEditSpecialHex";
            this.btnEditSpecialHex.Size = new Size(0x4b, 0x17);
            this.btnEditSpecialHex.TabIndex = 1;
            this.btnEditSpecialHex.Text = "edit hex";
            this.btnEditSpecialHex.UseVisualStyleBackColor = true;
            this.btnEditSpecialHex.Click += new EventHandler(this.btnEditSpecialHex_Click);
            this.txtSpecialHex.BackColor = SystemColors.Window;
            this.txtSpecialHex.Enabled = false;
            this.txtSpecialHex.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtSpecialHex.ForeColor = SystemColors.WindowText;
            this.txtSpecialHex.Location = new Point(15, 0x17);
            this.txtSpecialHex.Margin = new Padding(3, 4, 3, 4);
            this.txtSpecialHex.Multiline = true;
            this.txtSpecialHex.Name = "txtSpecialHex";
            this.txtSpecialHex.ReadOnly = true;
            this.txtSpecialHex.Size = new Size(0xed, 0x26);
            this.txtSpecialHex.TabIndex = 0;
            this.txtSpecialHex.TextAlign = HorizontalAlignment.Center;
            this.groupBox7.Controls.Add(this.txtCreator);
            this.groupBox7.Location = new Point(0x24b, 0xd5);
            this.groupBox7.Margin = new Padding(3, 4, 3, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new Padding(3, 4, 3, 4);
            this.groupBox7.Size = new Size(0x10f, 0x38);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Mission Created By";
            this.txtCreator.Location = new Point(14, 0x13);
            this.txtCreator.Margin = new Padding(3, 4, 3, 4);
            this.txtCreator.MaxLength = 0x20;
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new Size(0xed, 0x15);
            this.txtCreator.TabIndex = 0;
            this.txtCreator.TextChanged += new EventHandler(this.txtCreator_TextChanged);
            this.groupBox8.Controls.Add(this.comboEnemyTable2Mod);
            this.groupBox8.Controls.Add(this.chkEnemyTable1Mod);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.comboEnemyTable2);
            this.groupBox8.Controls.Add(this.comboEnemyTable1);
            this.groupBox8.Location = new Point(300, 410);
            this.groupBox8.Margin = new Padding(3, 4, 3, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new Padding(3, 4, 3, 4);
            this.groupBox8.Size = new Size(0x10f, 0xa4);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Enemy Table Modifiers";
            this.chkEnemyTable1Mod.AutoSize = true;
            this.chkEnemyTable1Mod.Cursor = Cursors.Hand;
            this.chkEnemyTable1Mod.Location = new Point(0xa1, 0x21);
            this.chkEnemyTable1Mod.Name = "chkEnemyTable1Mod";
            this.chkEnemyTable1Mod.Size = new Size(0x66, 0x11);
            this.chkEnemyTable1Mod.TabIndex = 8;
            this.chkEnemyTable1Mod.Text = "Table 01 Mod";
            this.chkEnemyTable1Mod.UseVisualStyleBackColor = true;
            this.chkEnemyTable1Mod.CheckedChanged += new EventHandler(this.chkEnemyTable1Mod_CheckedChanged);
            this.label1.ForeColor = Color.DarkRed;
            this.label1.Location = new Point(14, 0x56);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xee, 0x47);
            this.label1.TabIndex = 7;
            this.label1.Text = "** WARNING **\r\n\r\nSpecific values are unknown and some selections may cause the game to crash or behave unexpectedly.";
            this.comboEnemyTable2.Cursor = Cursors.Hand;
            this.comboEnemyTable2.FormattingEnabled = true;
            object[] objArray11 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboEnemyTable2.Items.AddRange(objArray11);
            this.comboEnemyTable2.Location = new Point(14, 0x39);
            this.comboEnemyTable2.Margin = new Padding(3, 4, 3, 4);
            this.comboEnemyTable2.Name = "comboEnemyTable2";
            this.comboEnemyTable2.Size = new Size(140, 0x15);
            this.comboEnemyTable2.TabIndex = 5;
            this.comboEnemyTable2.SelectedIndexChanged += new EventHandler(this.comboEnemyTable2_SelectedIndexChanged);
            this.comboEnemyTable1.Cursor = Cursors.Hand;
            this.comboEnemyTable1.FormattingEnabled = true;
            object[] objArray12 = new object[] { "1 Star (Hack)", "2 Stars", "3 Stars" };
            this.comboEnemyTable1.Items.AddRange(objArray12);
            this.comboEnemyTable1.Location = new Point(14, 30);
            this.comboEnemyTable1.Margin = new Padding(3, 4, 3, 4);
            this.comboEnemyTable1.Name = "comboEnemyTable1";
            this.comboEnemyTable1.Size = new Size(140, 0x15);
            this.comboEnemyTable1.TabIndex = 4;
            this.comboEnemyTable1.SelectedIndexChanged += new EventHandler(this.comboEnemyTable1_SelectedIndexChanged);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.numClearedInf);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.numClearedS);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.numClearedA);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.numClearedB);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.numClearedC);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.numSynthPoint);
            this.groupBox9.Location = new Point(0x24b, 12);
            this.groupBox9.Margin = new Padding(3, 4, 3, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new Padding(3, 4, 3, 4);
            this.groupBox9.Size = new Size(0x10f, 0xc2);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Cleared Mission Data";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(30, 0xa7);
            this.label7.Name = "label7";
            this.label7.Size = new Size(100, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "∞ Rank Cleared";
            this.numClearedInf.Cursor = Cursors.Hand;
            this.numClearedInf.Location = new Point(0x8d, 0xa5);
            this.numClearedInf.Margin = new Padding(3, 4, 3, 4);
            this.numClearedInf.Maximum = new decimal(new int[] { 0xffff });
            this.numClearedInf.Name = "numClearedInf";
            this.numClearedInf.Size = new Size(0x6f, 0x15);
            this.numClearedInf.TabIndex = 10;
            this.numClearedInf.ValueChanged += new EventHandler(this.numClearedInf_ValueChanged);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x1d, 0x8d);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x61, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "S Rank Cleared";
            this.numClearedS.Cursor = Cursors.Hand;
            this.numClearedS.Location = new Point(0x8d, 0x8b);
            this.numClearedS.Margin = new Padding(3, 4, 3, 4);
            this.numClearedS.Maximum = new decimal(new int[] { 0xffff });
            this.numClearedS.Name = "numClearedS";
            this.numClearedS.Size = new Size(0x6f, 0x15);
            this.numClearedS.TabIndex = 8;
            this.numClearedS.ValueChanged += new EventHandler(this.numClearedS_ValueChanged);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x1d, 0x73);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x61, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "A Rank Cleared";
            this.numClearedA.Cursor = Cursors.Hand;
            this.numClearedA.Location = new Point(0x8d, 0x71);
            this.numClearedA.Margin = new Padding(3, 4, 3, 4);
            this.numClearedA.Maximum = new decimal(new int[] { 0xffff });
            this.numClearedA.Name = "numClearedA";
            this.numClearedA.Size = new Size(0x6f, 0x15);
            this.numClearedA.TabIndex = 6;
            this.numClearedA.ValueChanged += new EventHandler(this.numClearedA_ValueChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1d, 0x59);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "B Rank Cleared";
            this.numClearedB.Cursor = Cursors.Hand;
            this.numClearedB.Location = new Point(0x8d, 0x57);
            this.numClearedB.Margin = new Padding(3, 4, 3, 4);
            this.numClearedB.Maximum = new decimal(new int[] { 0xffff });
            this.numClearedB.Name = "numClearedB";
            this.numClearedB.Size = new Size(0x6f, 0x15);
            this.numClearedB.TabIndex = 4;
            this.numClearedB.ValueChanged += new EventHandler(this.numClearedB_ValueChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x1d, 0x3f);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "C Rank Cleared";
            this.numClearedC.Cursor = Cursors.Hand;
            this.numClearedC.Location = new Point(0x8d, 0x3d);
            this.numClearedC.Margin = new Padding(3, 4, 3, 4);
            this.numClearedC.Maximum = new decimal(new int[] { 0xffff });
            this.numClearedC.Name = "numClearedC";
            this.numClearedC.Size = new Size(0x6f, 0x15);
            this.numClearedC.TabIndex = 2;
            this.numClearedC.ValueChanged += new EventHandler(this.numClearedC_ValueChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x1b, 0x1c);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Synthesis Points";
            this.numSynthPoint.Cursor = Cursors.Hand;
            this.numSynthPoint.Location = new Point(0x8d, 0x1a);
            this.numSynthPoint.Margin = new Padding(3, 4, 3, 4);
            this.numSynthPoint.Maximum = new decimal(new int[] { 0xf423f });
            this.numSynthPoint.Name = "numSynthPoint";
            this.numSynthPoint.Size = new Size(0x6f, 0x15);
            this.numSynthPoint.TabIndex = 0;
            this.numSynthPoint.ValueChanged += new EventHandler(this.numSynthPoint_ValueChanged);
            this.picMap1.Location = new Point(0x67, 0x13);
            this.picMap1.Margin = new Padding(3, 4, 3, 4);
            this.picMap1.Name = "picMap1";
            this.picMap1.Size = new Size(0x95, 0x60);
            this.picMap1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picMap1.TabIndex = 13;
            this.picMap1.TabStop = false;
            this.grpArea1.Controls.Add(this.picArea1);
            this.grpArea1.Controls.Add(this.picMap1);
            this.grpArea1.Controls.Add(this.comboMapMod1);
            this.grpArea1.Location = new Point(14, 0x66);
            this.grpArea1.Margin = new Padding(3, 4, 3, 4);
            this.grpArea1.Name = "grpArea1";
            this.grpArea1.Padding = new Padding(3, 4, 3, 4);
            this.grpArea1.Size = new Size(0x10f, 0x98);
            this.grpArea1.TabIndex = 14;
            this.grpArea1.TabStop = false;
            this.grpArea1.Text = "Area Map #1";
            this.picArea1.Location = new Point(14, 0x13);
            this.picArea1.Margin = new Padding(3, 4, 3, 4);
            this.picArea1.Name = "picArea1";
            this.picArea1.Size = new Size(0x52, 0x35);
            this.picArea1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picArea1.TabIndex = 14;
            this.picArea1.TabStop = false;
            this.grpArea2.Controls.Add(this.picArea2);
            this.grpArea2.Controls.Add(this.comboMapMod2);
            this.grpArea2.Controls.Add(this.picMap2);
            this.grpArea2.Location = new Point(14, 0x106);
            this.grpArea2.Margin = new Padding(3, 4, 3, 4);
            this.grpArea2.Name = "grpArea2";
            this.grpArea2.Padding = new Padding(3, 4, 3, 4);
            this.grpArea2.Size = new Size(0x10f, 0x98);
            this.grpArea2.TabIndex = 15;
            this.grpArea2.TabStop = false;
            this.grpArea2.Text = "Area Map #2";
            this.grpArea2.EnabledChanged += new EventHandler(this.grpArea2_EnabledChanged);
            this.picArea2.Location = new Point(14, 0x13);
            this.picArea2.Margin = new Padding(3, 4, 3, 4);
            this.picArea2.Name = "picArea2";
            this.picArea2.Size = new Size(0x52, 0x35);
            this.picArea2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picArea2.TabIndex = 14;
            this.picArea2.TabStop = false;
            this.picMap2.Location = new Point(0x67, 0x13);
            this.picMap2.Margin = new Padding(3, 4, 3, 4);
            this.picMap2.Name = "picMap2";
            this.picMap2.Size = new Size(0x95, 0x60);
            this.picMap2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picMap2.TabIndex = 13;
            this.picMap2.TabStop = false;
            this.grpArea3.Controls.Add(this.comboMapMod3);
            this.grpArea3.Controls.Add(this.picArea3);
            this.grpArea3.Controls.Add(this.picMap3);
            this.grpArea3.Location = new Point(14, 0x1a5);
            this.grpArea3.Margin = new Padding(3, 4, 3, 4);
            this.grpArea3.Name = "grpArea3";
            this.grpArea3.Padding = new Padding(3, 4, 3, 4);
            this.grpArea3.Size = new Size(0x10f, 0x98);
            this.grpArea3.TabIndex = 0x10;
            this.grpArea3.TabStop = false;
            this.grpArea3.Text = "Area Map #3";
            this.grpArea3.EnabledChanged += new EventHandler(this.grpArea3_EnabledChanged);
            this.picArea3.Location = new Point(14, 0x13);
            this.picArea3.Margin = new Padding(3, 4, 3, 4);
            this.picArea3.Name = "picArea3";
            this.picArea3.Size = new Size(0x52, 0x35);
            this.picArea3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picArea3.TabIndex = 14;
            this.picArea3.TabStop = false;
            this.picMap3.Enabled = false;
            this.picMap3.Location = new Point(0x67, 0x13);
            this.picMap3.Margin = new Padding(3, 4, 3, 4);
            this.picMap3.Name = "picMap3";
            this.picMap3.Size = new Size(0x95, 0x60);
            this.picMap3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picMap3.TabIndex = 13;
            this.picMap3.TabStop = false;
            this.imgListMaps.ImageStream = (ImageListStreamer) manager.GetObject("imgListMaps.ImageStream");
            this.imgListMaps.TransparentColor = Color.Transparent;
            this.imgListMaps.Images.SetKeyName(0, "area_0_0.png");
            this.imgListMaps.Images.SetKeyName(1, "area_0_1.png");
            this.imgListMaps.Images.SetKeyName(2, "area_0_2.png");
            this.imgListMaps.Images.SetKeyName(3, "area_0_3.png");
            this.imgListMaps.Images.SetKeyName(4, "area_0_4.png");
            this.imgListMaps.Images.SetKeyName(5, "area_0_5.png");
            this.imgListMaps.Images.SetKeyName(6, "area_0_6.png");
            this.imgListMaps.Images.SetKeyName(7, "area_0_7.png");
            this.imgListMaps.Images.SetKeyName(8, "area_0_8.png");
            this.imgListMaps.Images.SetKeyName(9, "area_0_9.png");
            this.imgListMaps.Images.SetKeyName(10, "area_1_0.png");
            this.imgListMaps.Images.SetKeyName(11, "area_1_1.png");
            this.imgListMaps.Images.SetKeyName(12, "area_1_2.png");
            this.imgListMaps.Images.SetKeyName(13, "area_1_3.png");
            this.imgListMaps.Images.SetKeyName(14, "area_1_4.png");
            this.imgListMaps.Images.SetKeyName(15, "area_1_5.png");
            this.imgListMaps.Images.SetKeyName(0x10, "area_1_6.png");
            this.imgListMaps.Images.SetKeyName(0x11, "area_1_7.png");
            this.imgListMaps.Images.SetKeyName(0x12, "area_1_8.png");
            this.imgListMaps.Images.SetKeyName(0x13, "area_1_9.png");
            this.imgListMaps.Images.SetKeyName(20, "area_2_0.png");
            this.imgListMaps.Images.SetKeyName(0x15, "area_2_1.png");
            this.imgListMaps.Images.SetKeyName(0x16, "area_2_2.png");
            this.imgListMaps.Images.SetKeyName(0x17, "area_2_3.png");
            this.imgListMaps.Images.SetKeyName(0x18, "area_2_4.png");
            this.imgListMaps.Images.SetKeyName(0x19, "area_2_5.png");
            this.imgListMaps.Images.SetKeyName(0x1a, "area_2_6.png");
            this.imgListMaps.Images.SetKeyName(0x1b, "area_2_7.png");
            this.imgListMaps.Images.SetKeyName(0x1c, "area_2_8.png");
            this.imgListMaps.Images.SetKeyName(0x1d, "area_2_9.png");
            this.imgListMaps.Images.SetKeyName(30, "area_3_0.png");
            this.imgListMaps.Images.SetKeyName(0x1f, "area_3_1.png");
            this.imgListMaps.Images.SetKeyName(0x20, "area_3_2.png");
            this.imgListMaps.Images.SetKeyName(0x21, "area_3_3.png");
            this.imgListMaps.Images.SetKeyName(0x22, "area_3_4.png");
            this.imgListMaps.Images.SetKeyName(0x23, "area_3_5.png");
            this.imgListMaps.Images.SetKeyName(0x24, "area_3_6.png");
            this.imgListMaps.Images.SetKeyName(0x25, "area_3_7.png");
            this.imgListMaps.Images.SetKeyName(0x26, "area_3_8.png");
            this.imgListMaps.Images.SetKeyName(0x27, "area_3_9.png");
            this.imgListMaps.Images.SetKeyName(40, "area_4_0.png");
            this.imgListMaps.Images.SetKeyName(0x29, "area_4_1.png");
            this.imgListMaps.Images.SetKeyName(0x2a, "area_4_2.png");
            this.imgListMaps.Images.SetKeyName(0x2b, "area_4_3.png");
            this.imgListMaps.Images.SetKeyName(0x2c, "area_4_4.png");
            this.imgListMaps.Images.SetKeyName(0x2d, "area_4_5.png");
            this.imgListMaps.Images.SetKeyName(0x2e, "area_4_6.png");
            this.imgListMaps.Images.SetKeyName(0x2f, "area_4_7.png");
            this.imgListMaps.Images.SetKeyName(0x30, "area_4_8.png");
            this.imgListMaps.Images.SetKeyName(0x31, "area_4_9.png");
            this.imgListMaps.Images.SetKeyName(50, "area_5_0.png");
            this.imgListMaps.Images.SetKeyName(0x33, "area_5_1.png");
            this.imgListMaps.Images.SetKeyName(0x34, "area_5_2.png");
            this.imgListMaps.Images.SetKeyName(0x35, "area_5_3.png");
            this.imgListMaps.Images.SetKeyName(0x36, "area_5_4.png");
            this.imgListMaps.Images.SetKeyName(0x37, "area_5_5.png");
            this.imgListMaps.Images.SetKeyName(0x38, "area_5_6.png");
            this.imgListMaps.Images.SetKeyName(0x39, "area_5_7.png");
            this.imgListMaps.Images.SetKeyName(0x3a, "area_5_8.png");
            this.imgListMaps.Images.SetKeyName(0x3b, "area_5_9.png");
            this.imgListMaps.Images.SetKeyName(60, "area_6_0.png");
            this.imgListMaps.Images.SetKeyName(0x3d, "area_6_1.png");
            this.imgListMaps.Images.SetKeyName(0x3e, "area_6_2.png");
            this.imgListMaps.Images.SetKeyName(0x3f, "area_6_3.png");
            this.imgListMaps.Images.SetKeyName(0x40, "area_6_4.png");
            this.imgListMaps.Images.SetKeyName(0x41, "area_6_5.png");
            this.imgListMaps.Images.SetKeyName(0x42, "area_6_6.png");
            this.imgListMaps.Images.SetKeyName(0x43, "area_6_7.png");
            this.imgListMaps.Images.SetKeyName(0x44, "area_6_8.png");
            this.imgListMaps.Images.SetKeyName(0x45, "area_6_9.png");
            this.imgListMaps.Images.SetKeyName(70, "area_7_0.png");
            this.imgListMaps.Images.SetKeyName(0x47, "area_7_1.png");
            this.imgListMaps.Images.SetKeyName(0x48, "area_7_2.png");
            this.imgListMaps.Images.SetKeyName(0x49, "area_7_3.png");
            this.imgListMaps.Images.SetKeyName(0x4a, "area_7_4.png");
            this.imgListMaps.Images.SetKeyName(0x4b, "area_7_5.png");
            this.imgListMaps.Images.SetKeyName(0x4c, "area_7_6.png");
            this.imgListMaps.Images.SetKeyName(0x4d, "area_7_7.png");
            this.imgListMaps.Images.SetKeyName(0x4e, "area_7_8.png");
            this.imgListMaps.Images.SetKeyName(0x4f, "area_7_9.png");
            this.imgListMaps.Images.SetKeyName(80, "area_8_0.png");
            this.imgListMaps.Images.SetKeyName(0x51, "area_8_1.png");
            this.imgListMaps.Images.SetKeyName(0x52, "area_8_2.png");
            this.imgListMaps.Images.SetKeyName(0x53, "area_8_3.png");
            this.imgListMaps.Images.SetKeyName(0x54, "area_8_4.png");
            this.imgListMaps.Images.SetKeyName(0x55, "area_8_5.png");
            this.imgListMaps.Images.SetKeyName(0x56, "area_8_6.png");
            this.imgListMaps.Images.SetKeyName(0x57, "area_8_7.png");
            this.imgListMaps.Images.SetKeyName(0x58, "area_8_8.png");
            this.imgListMaps.Images.SetKeyName(0x59, "area_8_9.png");
            this.imgListMaps.Images.SetKeyName(90, "area_9_0.png");
            this.imgListMaps.Images.SetKeyName(0x5b, "area_9_1.png");
            this.imgListMaps.Images.SetKeyName(0x5c, "area_9_2.png");
            this.imgListMaps.Images.SetKeyName(0x5d, "area_9_3.png");
            this.imgListMaps.Images.SetKeyName(0x5e, "area_9_4.png");
            this.imgListMaps.Images.SetKeyName(0x5f, "area_9_5.png");
            this.imgListMaps.Images.SetKeyName(0x60, "area_9_6.png");
            this.imgListMaps.Images.SetKeyName(0x61, "area_9_7.png");
            this.imgListMaps.Images.SetKeyName(0x62, "area_9_8.png");
            this.imgListMaps.Images.SetKeyName(0x63, "area_9_9.png");
            this.imgListMaps.Images.SetKeyName(100, "no_map.png");
            this.imgListAreaThemes.ImageStream = (ImageListStreamer) manager.GetObject("imgListAreaThemes.ImageStream");
            this.imgListAreaThemes.TransparentColor = Color.Transparent;
            this.imgListAreaThemes.Images.SetKeyName(0, "theme_0.png");
            this.imgListAreaThemes.Images.SetKeyName(1, "theme_1.png");
            this.imgListAreaThemes.Images.SetKeyName(2, "theme_2.png");
            this.imgListAreaThemes.Images.SetKeyName(3, "theme_3.png");
            this.imgListAreaThemes.Images.SetKeyName(4, "theme_4.png");
            this.imgListAreaThemes.Images.SetKeyName(5, "theme_5.png");
            this.imgListAreaThemes.Images.SetKeyName(6, "theme_6.png");
            this.imgListAreaThemes.Images.SetKeyName(7, "theme_7.png");
            this.imgListAreaThemes.Images.SetKeyName(8, "theme_8.png");
            this.imgListAreaThemes.Images.SetKeyName(9, "theme_9.png");
            this.imgListAreaThemes.Images.SetKeyName(10, "theme_10.png");
            this.imgListAreaThemes.Images.SetKeyName(11, "theme_11.png");
            this.imgListAreaThemes.Images.SetKeyName(12, "theme_12.png");
            this.imgListAreaThemes.Images.SetKeyName(13, "theme_13.png");
            this.imgListAreaThemes.Images.SetKeyName(14, "theme_14.png");
            this.imgListAreaThemes.Images.SetKeyName(15, "theme_15.png");
            this.imgListAreaThemes.Images.SetKeyName(0x10, "theme_16.png");
            this.imgListAreaThemes.Images.SetKeyName(0x11, "theme_17.png");
            this.imgListAreaThemes.Images.SetKeyName(0x12, "theme_18.png");
            this.imgListAreaThemes.Images.SetKeyName(0x13, "theme_19.png");
            this.imgListAreaThemes.Images.SetKeyName(20, "theme_20.png");
            this.imgListBoss.ImageStream = (ImageListStreamer) manager.GetObject("imgListBoss.ImageStream");
            this.imgListBoss.TransparentColor = Color.Transparent;
            this.imgListBoss.Images.SetKeyName(0, "boss_00.jpg");
            this.imgListBoss.Images.SetKeyName(1, "boss_01.jpg");
            this.imgListBoss.Images.SetKeyName(2, "boss_02.jpg");
            this.imgListBoss.Images.SetKeyName(3, "boss_03.jpg");
            this.imgListBoss.Images.SetKeyName(4, "boss_04.jpg");
            this.imgListBoss.Images.SetKeyName(5, "boss_05.jpg");
            this.imgListBoss.Images.SetKeyName(6, "boss_06.jpg");
            this.imgListBoss.Images.SetKeyName(7, "boss_07.jpg");
            this.imgListBoss.Images.SetKeyName(8, "boss_08.jpg");
            this.imgListBoss.Images.SetKeyName(9, "boss_09.jpg");
            this.imgListBoss.Images.SetKeyName(10, "boss_10.jpg");
            this.imgListBoss.Images.SetKeyName(11, "boss_11.jpg");
            this.imgListBoss.Images.SetKeyName(12, "boss_12.jpg");
            this.imgListBoss.Images.SetKeyName(13, "boss_13.jpg");
            this.imgListBoss.Images.SetKeyName(14, "boss_14.jpg");
            this.imgListBoss.Images.SetKeyName(15, "boss_15.jpg");
            this.imgListBoss.Images.SetKeyName(0x10, "boss_16.jpg");
            this.imgListBoss.Images.SetKeyName(0x11, "boss_17.jpg");
            this.imgListBoss.Images.SetKeyName(0x12, "boss_18.jpg");
            this.imgListBoss.Images.SetKeyName(0x13, "boss_19.jpg");
            this.imgListBoss.Images.SetKeyName(20, "boss_20.jpg");
            this.imgListBoss.Images.SetKeyName(0x15, "boss_21.jpg");
            this.imgListBoss.Images.SetKeyName(0x16, "boss_22.jpg");
            this.imgListBoss.Images.SetKeyName(0x17, "boss_23.jpg");
            this.imgListBoss.Images.SetKeyName(0x18, "boss_24.jpg");
            this.imgListBoss.Images.SetKeyName(0x19, "boss_25.jpg");
            this.imgListBoss.Images.SetKeyName(0x1a, "boss_26.jpg");
            this.imgListBoss.Images.SetKeyName(0x1b, "boss_27.jpg");
            this.imgListBoss.Images.SetKeyName(0x1c, "boss_28.jpg");
            this.imgListBoss.Images.SetKeyName(0x1d, "boss_29.jpg");
            this.imgListBoss.Images.SetKeyName(30, "boss_30.jpg");
            this.imgListBoss.Images.SetKeyName(0x1f, "boss_31.jpg");
            this.imgListBoss.Images.SetKeyName(0x20, "boss_32.jpg");
            this.imgListBoss.Images.SetKeyName(0x21, "boss_33.jpg");
            this.imgListBoss.Images.SetKeyName(0x22, "boss_34.jpg");
            this.imgListBoss.Images.SetKeyName(0x23, "boss_35.jpg");
            this.imgListBoss.Images.SetKeyName(0x24, "boss_36.jpg");
            this.imgListBoss.Images.SetKeyName(0x25, "boss_37.jpg");
            this.imgListBoss.Images.SetKeyName(0x26, "boss_38.jpg");
            this.imgListBoss.Images.SetKeyName(0x27, "boss_39.jpg");
            this.groupBox10.Controls.Add(this.txtHex);
            this.groupBox10.Location = new Point(0x24b, 410);
            this.groupBox10.Margin = new Padding(3, 4, 3, 4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new Padding(3, 4, 3, 4);
            this.groupBox10.Size = new Size(0x10f, 0x83);
            this.groupBox10.TabIndex = 12;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Hex";
            this.comboEnemyTable2Mod.Cursor = Cursors.Hand;
            this.comboEnemyTable2Mod.FormattingEnabled = true;
            object[] objArray13 = new object[] { "Mod 00", "Mod 01", "Mod 02" };
            this.comboEnemyTable2Mod.Items.AddRange(objArray13);
            this.comboEnemyTable2Mod.Location = new Point(160, 0x39);
            this.comboEnemyTable2Mod.Margin = new Padding(3, 4, 3, 4);
            this.comboEnemyTable2Mod.Name = "comboEnemyTable2Mod";
            this.comboEnemyTable2Mod.Size = new Size(0x69, 0x15);
            this.comboEnemyTable2Mod.TabIndex = 9;
            this.comboEnemyTable2Mod.SelectedIndexChanged += new EventHandler(this.comboEnemyTable2_SelectedIndexChanged);
            base.AutoScaleDimensions = new SizeF(7f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x36f, 0x24f);
            base.Controls.Add(this.groupBox10);
            base.Controls.Add(this.groupBox7);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.grpArea3);
            base.Controls.Add(this.grpArea2);
            base.Controls.Add(this.grpArea1);
            base.Controls.Add(this.groupBox9);
            base.Controls.Add(this.groupBox8);
            base.Controls.Add(this.groupBox6);
            base.Controls.Add(this.btnApply);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.groupBox5);
            this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Margin = new Padding(3, 4, 3, 4);
            this.MaximumSize = new Size(0x379, 0x26f);
            this.MinimumSize = new Size(0x379, 0x26f);
            base.Name = "pspo2seInfinityMissionForm";
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Infinity Mission Editor";
            base.FormClosing += new FormClosingEventHandler(this.pspo2seInfinityMissionForm_FormClosing);
            base.VisibleChanged += new EventHandler(this.pspo2seInfinityMissionForm_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((ISupportInitialize) this.picBoss).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.numClearedInf.EndInit();
            this.numClearedS.EndInit();
            this.numClearedA.EndInit();
            this.numClearedB.EndInit();
            this.numClearedC.EndInit();
            this.numSynthPoint.EndInit();
            ((ISupportInitialize) this.picMap1).EndInit();
            this.grpArea1.ResumeLayout(false);
            ((ISupportInitialize) this.picArea1).EndInit();
            this.grpArea2.ResumeLayout(false);
            ((ISupportInitialize) this.picArea2).EndInit();
            ((ISupportInitialize) this.picMap2).EndInit();
            this.grpArea3.ResumeLayout(false);
            ((ISupportInitialize) this.picArea3).EndInit();
            ((ISupportInitialize) this.picMap3).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            base.ResumeLayout(false);
        }

        private void numClearedA_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedA.Value >= 0M)
            {
                this.updateClearedRankInHex(2, ((int) this.numClearedA.Value).ToString("X2"));
            }
        }

        private void numClearedB_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedB.Value >= 0M)
            {
                this.updateClearedRankInHex(1, ((int) this.numClearedB.Value).ToString("X2"));
            }
        }

        private void numClearedC_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedC.Value >= 0M)
            {
                this.updateClearedRankInHex(0, ((int) this.numClearedC.Value).ToString("X2"));
            }
        }

        private void numClearedInf_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedInf.Value >= 0M)
            {
                this.updateClearedRankInHex(4, ((int) this.numClearedInf.Value).ToString("X2"));
            }
        }

        private void numClearedS_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedS.Value >= 0M)
            {
                this.updateClearedRankInHex(3, ((int) this.numClearedS.Value).ToString("X2"));
            }
        }

        private void numSynthPoint_ValueChanged(object sender, EventArgs e)
        {
            if (this.numSynthPoint.Value >= 0M)
            {
                if (this.numSynthPoint.Value > 9999M)
                {
                    this.numSynthPoint.Value = 9999M;
                }
                else
                {
                    string str = (((int) this.numSynthPoint.Value) + 0x8000).ToString("X2");
                    while (str.Length < 4)
                    {
                        str = "0" + str;
                    }
                    if (str.Length > 4)
                    {
                        MessageBox.Show("Error: The hex value is more than 2 bytes");
                    }
                    else
                    {
                        this.updateHex(str.Substring(2, 2), 0xb8);
                        this.updateHex(str.Substring(0, 2), 0xba);
                    }
                }
            }
        }

        private void pspo2seInfinityMissionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.Hide();
            Program.form.BringToFront();
        }

        private void pspo2seInfinityMissionForm_VisibleChanged(object sender, EventArgs e)
        {
            if (base.Visible)
            {
                this.dontUpdateHex = true;
                this.fillCombos();
                pspo2seForm.infinityMissionClass class2 = Program.form.saveData.infinityMissions.slot[this.id];
                this.grpArea2.Enabled = true;
                this.grpArea3.Enabled = true;
                if (class2.area <= this.comboArea.Items.Count)
                {
                    this.comboArea.SelectedIndex = class2.area - 1;
                }
                if (class2.area_1_map < this.comboMapMod1.Items.Count)
                {
                    this.comboMapMod1.SelectedIndex = class2.area_1_map;
                }
                if (class2.area_2_map < this.comboMapMod2.Items.Count)
                {
                    this.comboMapMod2.SelectedIndex = class2.area_2_map;
                }
                if (class2.area_3_map < this.comboMapMod3.Items.Count)
                {
                    this.comboMapMod3.SelectedIndex = class2.area_3_map;
                }
                this.comboBoss.SelectedIndex = class2.boss - 1;
                this.comboLength.SelectedIndex = class2.length - 1;
                this.comboEnemyLevel.SelectedIndex = class2.enemy_level - 1;
                this.comboEnemyLevelMod.SelectedIndex = class2.unk_enemy_level_mod;
                this.comboEnemy1.SelectedIndex = class2.enemy_1;
                this.comboEnemy1Mod.SelectedIndex = class2.unk_enemy_1_mod;
                this.comboEnemy2.SelectedIndex = class2.enemy_2;
                this.comboEnemyTable1.SelectedIndex = class2.enemy_table_1 - 1;
                this.chkEnemyTable1Mod.Checked = class2.unk_enemy_table_1_mod;
                this.comboEnemyTable2.SelectedIndex = class2.unk_table_2_mod;
                this.comboEnemyTable2Mod.SelectedIndex = class2.unk_table_2_unk_mod;
                this.numSynthPoint.Value = class2.mergePoints;
                this.numClearedC.Value = class2.clearCount_c;
                this.numClearedB.Value = class2.clearCount_b;
                this.numClearedA.Value = class2.clearCount_a;
                this.numClearedS.Value = class2.clearCount_s;
                this.numClearedInf.Value = class2.clearCount_inf;
                this.txtCreator.Text = class2.createdBy;
                Application.DoEvents();
                this.dontUpdateHex = false;
                this.updateHex(class2.hex, 0);
            }
        }

        private void txtCreator_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCreator.Text != "")
            {
                string newhex = Program.form.run.hexAndMathFunction.stringToHexadecimal(this.txtCreator.Text, 0x40);
                while (newhex.Length < 0x80)
                {
                    newhex = newhex + "00";
                }
                this.updateHex(newhex, 0x20);
            }
        }

        private void updateClearedRankInHex(int rank, string str)
        {
            while (str.Length < 4)
            {
                str = "0" + str;
            }
            str = Program.form.run.hexAndMathFunction.reversehex(str, 4);
            this.updateHex(str, 0xbc + (rank * 4));
        }

        private void updateHex(string newhex, int pos = 0)
        {
            if (!this.dontUpdateHex)
            {
                this.editedHex = (pos != 0) ? (this.editedHex.Substring(0, pos) + newhex + this.editedHex.Substring(pos + newhex.Length, this.editedHex.Length - (pos + newhex.Length))) : ((this.editedHex == "") ? newhex : (newhex + this.editedHex.Substring(pos + newhex.Length, this.editedHex.Length - (pos + newhex.Length))));
                this.txtHex.Text = Program.form.run.hexAndMathFunction.addCommasToHex(this.editedHex);
                this.txtHex.Text = Program.form.run.hexAndMathFunction.hexCsvToNiceDisplay("\r\n" + this.txtHex.Text, 8);
                this.txtSpecialHex.Text = Program.form.run.hexAndMathFunction.addCommasToHex(this.editedHex.Substring(12, 20));
                this.txtSpecialHex.Text = Program.form.run.hexAndMathFunction.hexCsvToNiceDisplay(this.txtSpecialHex.Text, 5);
            }
        }

        public int id
        {
            get => 
                this.loadedId;
            set => 
                this.loadedId = value;
        }
    }
}

