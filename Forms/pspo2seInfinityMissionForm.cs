using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class pspo2seInfinityMissionForm : Form
    {
        public string editedHex = "";
        private int loadedId;
        private bool dontUpdateHex;

        public int id
        {
            get => this.loadedId;
            set => this.loadedId = value;
        }


        private void exportImageLists()
        {
            for (int x = 0; x < imgListMaps.Images.Count; x++)
            {
                System.IO.Directory.CreateDirectory("imgListMaps");
                Image temp = imgListMaps.Images[x];
                temp.Save("imgListMaps/image" + x + ".png");
            }
            for (int x = 0; x < imgListAreaThemes.Images.Count; x++)
            {
                System.IO.Directory.CreateDirectory("imgListAreaThemes");
                Image temp = imgListAreaThemes.Images[x];
                temp.Save("imgListAreaThemes/image" + x + ".png");
            }
            for (int x = 0; x < imgListBoss.Images.Count; x++)
            {
                Directory.CreateDirectory("imgListBoss");
                Image temp = imgListBoss.Images[x];
                temp.Save("imgListBoss/image" + x + ".png");
            }
        }
        public pspo2seInfinityMissionForm()
        {
            this.InitializeComponent();
        }

        private void pspo2seInfinityMissionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Program.form.BringToFront();
        }

        private int areaMapToThemeNum(int map)
        {
            if (map == -1)
                return 20;
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
                    }
                    break;
                case 7:
                    switch (map)
                    {
                        case 0:
                            return 16;
                        case 1:
                            return 16;
                        case 2:
                            return 16;
                        case 3:
                            return 16;
                        case 4:
                            return 16;
                        case 5:
                            return 16;
                        case 6:
                            return 16;
                        case 7:
                            return 16;
                        case 8:
                            return 17;
                        case 9:
                            return 17;
                    }
                    break;
                case 8:
                    return 18;
                case 9:
                    return 19;
            }
            return 20;
        }

        private Image areaMapToThemeImage(int map) => this.imgListAreaThemes.Images[this.areaMapToThemeNum(map)];

        private void fillCombos()
        {
            this.comboArea.Items.Clear();
            for (int index = 1; index < 11; ++index)
                this.comboArea.Items.Add((object)(index.ToString("D2") + ". " + Program.form.intToInfinityArea(index - 1)[1] + " (" + Program.form.intToInfinityArea(index - 1)[0] + ")"));
            this.comboBoss.Items.Clear();
            for (int index = 1; index < 41; ++index)
                this.comboBoss.Items.Add((object)(index.ToString("D2") + ". " + Program.form.intToInfinityBoss(index - 1)[1] + " (" + Program.form.intToInfinityBoss(index - 1)[0] + ")"));
            this.comboEnemyLevel.Items.Clear();
            for (int index = 1; index < 50; ++index)
                this.comboEnemyLevel.Items.Add((object)("Enemy Level +" + (object)index));
            this.comboEnemyLevelMod.Items.Clear();
            for (int index = 0; index < 4; ++index)
                this.comboEnemyLevelMod.Items.Add((object)("Unknown Mod " + (object)index));
            this.comboEnemy1.Items.Clear();
            this.comboEnemy2.Items.Clear();
            for (int index = 1; index < 8; ++index)
            {
                this.comboEnemy1.Items.Add((object)(index.ToString("D2") + ". " + Program.form.intToInfinityEnemy(index - 1)[1] + " (" + Program.form.intToInfinityEnemy(index - 1)[0] + ")"));
                this.comboEnemy2.Items.Add((object)(index.ToString("D2") + ". " + Program.form.intToInfinityEnemy(index - 1)[1] + " (" + Program.form.intToInfinityEnemy(index - 1)[0] + ")"));
            }
            this.comboEnemy1Mod.Items.Clear();
            for (int index = 0; index < 2; ++index)
                this.comboEnemy1Mod.Items.Add((object)("Unknown Mod " + (object)index));
            this.comboEnemyTable1.Items.Clear();
            for (int index = 0; index < 5; ++index)
                this.comboEnemyTable1.Items.Add((object)("Table 01 Set 0" + (object)(index + 1)));
            this.comboEnemyTable2.Items.Clear();
            this.comboEnemyTable2Mod.Items.Clear();
            for (int index = 0; index < 3; ++index)
            {
                this.comboEnemyTable2.Items.Add((object)("Unknown Mod 0" + (object)index));
                this.comboEnemyTable2Mod.Items.Add((object)("Mod 0" + (object)index));
            }
            this.comboMapMod1.Items.Clear();
            this.comboMapMod2.Items.Clear();
            this.comboMapMod3.Items.Clear();
            for (int index = 0; index < 10; ++index)
            {
                this.comboMapMod1.Items.Add((object)("Area 01 Map " + index.ToString("D2")));
                this.comboMapMod2.Items.Add((object)("Area 02 Map " + index.ToString("D2")));
                this.comboMapMod3.Items.Add((object)("Area 03 Map " + index.ToString("D2")));
            }
        }

        private void pspo2seInfinityMissionForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
                return;
            this.dontUpdateHex = true;
            this.fillCombos();
            pspo2seForm.infinityMissionClass infinityMissionClass = Program.form.saveData.infinityMissions.slot[this.id];
            this.grpArea2.Enabled = true;
            this.grpArea3.Enabled = true;
            if (infinityMissionClass.area <= this.comboArea.Items.Count)
                this.comboArea.SelectedIndex = infinityMissionClass.area - 1;
            if (infinityMissionClass.area_1_map < this.comboMapMod1.Items.Count)
                this.comboMapMod1.SelectedIndex = infinityMissionClass.area_1_map;
            if (infinityMissionClass.area_2_map < this.comboMapMod2.Items.Count)
                this.comboMapMod2.SelectedIndex = infinityMissionClass.area_2_map;
            if (infinityMissionClass.area_3_map < this.comboMapMod3.Items.Count)
                this.comboMapMod3.SelectedIndex = infinityMissionClass.area_3_map;
            this.comboBoss.SelectedIndex = infinityMissionClass.boss - 1;
            this.comboLength.SelectedIndex = infinityMissionClass.length - 1;
            this.comboEnemyLevel.SelectedIndex = infinityMissionClass.enemy_level - 1;
            this.comboEnemyLevelMod.SelectedIndex = infinityMissionClass.unk_enemy_level_mod;
            this.comboEnemy1.SelectedIndex = infinityMissionClass.enemy_1;
            this.comboEnemy1Mod.SelectedIndex = infinityMissionClass.unk_enemy_1_mod;
            this.comboEnemy2.SelectedIndex = infinityMissionClass.enemy_2;
            this.comboEnemyTable1.SelectedIndex = infinityMissionClass.enemy_table_1 - 1;
            this.chkEnemyTable1Mod.Checked = infinityMissionClass.unk_enemy_table_1_mod;
            this.comboEnemyTable2.SelectedIndex = infinityMissionClass.unk_table_2_mod;
            this.comboEnemyTable2Mod.SelectedIndex = infinityMissionClass.unk_table_2_unk_mod;
            this.numSynthPoint.Value = (Decimal)infinityMissionClass.mergePoints;
            this.numClearedC.Value = (Decimal)infinityMissionClass.clearCount_c;
            this.numClearedB.Value = (Decimal)infinityMissionClass.clearCount_b;
            this.numClearedA.Value = (Decimal)infinityMissionClass.clearCount_a;
            this.numClearedS.Value = (Decimal)infinityMissionClass.clearCount_s;
            this.numClearedInf.Value = (Decimal)infinityMissionClass.clearCount_inf;
            this.txtCreator.Text = infinityMissionClass.createdBy;
            Application.DoEvents();
            this.dontUpdateHex = false;
            this.updateHex(infinityMissionClass.hex);
        }

        private void updateHex(string newhex, int pos = 0)
        {
            if (this.dontUpdateHex)
                return;
            this.editedHex = pos != 0 ? this.editedHex.Substring(0, pos) + newhex + this.editedHex.Substring(pos + newhex.Length, this.editedHex.Length - (pos + newhex.Length)) : (!(this.editedHex != "") ? newhex : newhex + this.editedHex.Substring(pos + newhex.Length, this.editedHex.Length - (pos + newhex.Length)));
            this.txtHex.Text = Program.form.run.hexAndMathFunction.addCommasToHex(this.editedHex);
            this.txtHex.Text = Program.form.run.hexAndMathFunction.hexCsvToNiceDisplay("\r\n" + this.txtHex.Text, 8);
            this.txtSpecialHex.Text = Program.form.run.hexAndMathFunction.addCommasToHex(this.editedHex.Substring(12, 20));
            this.txtSpecialHex.Text = Program.form.run.hexAndMathFunction.hexCsvToNiceDisplay(this.txtSpecialHex.Text, 5);
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void comboBoss_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoss.SelectedIndex < 0 || this.comboLength.SelectedIndex < 0)
                return;
            string str = (this.comboBoss.SelectedIndex + 64 * (this.comboLength.SelectedIndex + 1) + 1).ToString("X1");
            while (str.Length < 2)
                str = "0" + str;
            this.updateHex(str.Substring(0, 1), 3);
            this.updateHex(str.Substring(1, 1));
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
            }
            this.picBoss.Image = this.imgListBoss.Images[this.comboBoss.SelectedIndex];
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (this.comboMapMod1.SelectedIndex == this.comboMapMod2.SelectedIndex && this.comboLength.SelectedIndex > 0 || this.comboMapMod1.SelectedIndex == this.comboMapMod3.SelectedIndex && this.comboLength.SelectedIndex > 2 || this.comboMapMod1.SelectedIndex == this.comboMapMod3.SelectedIndex && this.comboLength.SelectedIndex > 2)
            {
                int num1 = (int)MessageBox.Show("You cannot use the same area map more than once.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.editedHex.Length < 208)
            {
                int num2 = (int)MessageBox.Show("Error: The hex data is not the correct length");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to overwrite the selected mission?", "Confirm Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
                int pos = Program.form.mainSettings.saveStructureIndex.infinity_mission_pos + 104 * this.id;
                this.Close();
                Program.form.overwriteHexInBuffer(this.editedHex, pos);
                Program.form.reloadEverything();
                Program.form.tabArea.SelectedIndex = 4;
                Program.form.tabControlMissions.SelectedIndex = 2;
                Program.form.lstInfinityMissions.Items[this.id].Selected = true;
                Program.form.lstInfinityMissions.Items[this.id].EnsureVisible();
            }
        }

        private void comboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboArea.SelectedIndex < 0)
                return;
            this.updateHex((this.comboArea.SelectedIndex + 1).ToString("X1"), 1);
            this.comboMapMod1_SelectedIndexChanged(sender, e);
            this.comboMapMod2_SelectedIndexChanged(sender, e);
            this.comboMapMod3_SelectedIndexChanged(sender, e);
        }

        private void comboEnemyLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEnemyLevel.SelectedIndex < 0 || this.comboEnemyLevelMod.SelectedIndex < 0)
                return;
            string newhex = (this.comboEnemyLevel.SelectedIndex + 1 + 64 * this.comboEnemyLevelMod.SelectedIndex).ToString("X1");
            while (newhex.Length < 2)
                newhex = "0" + newhex;
            this.updateHex(newhex, 10);
        }

        private void comboEnemy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEnemy1.SelectedIndex < 0 || this.comboEnemy1Mod.SelectedIndex < 0)
                return;
            this.updateHex((this.comboEnemy1Mod.SelectedIndex + 2 * this.comboEnemy1.SelectedIndex).ToString("X1"), 4);
        }

        private void comboEnemy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEnemy2.SelectedIndex < 0)
                return;
            this.updateHex(this.comboEnemy2.SelectedIndex.ToString("X1"), 7);
        }

        private void txtCreator_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCreator.Text == "")
                return;
            string hexadecimal = Program.form.run.hexAndMathFunction.stringToHexadecimal(this.txtCreator.Text, 64);
            while (hexadecimal.Length < 128)
                hexadecimal += "00";
            this.updateHex(hexadecimal, 32);
        }

        private void comboEnemyTable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEnemyTable1.SelectedIndex < 0)
                return;
            int num = this.comboEnemyTable1.SelectedIndex + 1;
            if (this.chkEnemyTable1Mod.Checked)
                num += 8;
            this.updateHex(num.ToString("X1"), 2);
        }

        private void comboEnemyTable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboEnemyTable2.SelectedIndex < 0)
                return;
            this.updateHex((this.comboEnemyTable2.SelectedIndex + this.comboEnemyTable2Mod.SelectedIndex * 4).ToString("X1"), 5);
        }

        private void comboMapMod1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboMapMod1.SelectedIndex < 0)
                return;
            if (this.comboArea.SelectedIndex != 1 && this.comboArea.SelectedIndex != 8 && this.comboMapMod1.SelectedIndex > 9 || this.comboMapMod1.SelectedIndex > 10)
            {
                int num = (int)MessageBox.Show("This map is known to crash, proceed with caution.", "Known Map Issue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.updateHex(this.comboMapMod1.SelectedIndex.ToString("X1"), 6);
            this.picMap1.Image = this.imgListMaps.Images[this.comboArea.SelectedIndex * 10 + this.comboMapMod1.SelectedIndex];
            this.picArea1.Image = this.areaMapToThemeImage(this.comboMapMod1.SelectedIndex);
        }

        private void comboMapMod2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboMapMod2.SelectedIndex < 0)
                return;
            if (this.comboArea.SelectedIndex != 1 && this.comboArea.SelectedIndex != 8 && this.comboMapMod2.SelectedIndex > 9 || this.comboMapMod2.SelectedIndex > 10)
            {
                int num = (int)MessageBox.Show("This map is known to crash, proceed with caution.", "Known Map Issue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.updateHex(this.comboMapMod2.SelectedIndex.ToString("X1"), 9);
            this.picMap2.Image = this.imgListMaps.Images[this.comboArea.SelectedIndex * 10 + this.comboMapMod2.SelectedIndex];
            this.picArea2.Image = this.areaMapToThemeImage(this.comboMapMod2.SelectedIndex);
        }

        private void comboMapMod3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboMapMod3.SelectedIndex < 0)
                return;
            if (this.comboArea.SelectedIndex != 1 && this.comboArea.SelectedIndex != 8 && this.comboMapMod3.SelectedIndex > 9 || this.comboMapMod3.SelectedIndex > 10)
            {
                int num = (int)MessageBox.Show("This map is known to crash, proceed with caution.", "Known Map Issue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.updateHex(this.comboMapMod3.SelectedIndex.ToString("X1"), 8);
            this.picMap3.Image = this.imgListMaps.Images[this.comboArea.SelectedIndex * 10 + this.comboMapMod3.SelectedIndex];
            this.picArea3.Image = this.areaMapToThemeImage(this.comboMapMod3.SelectedIndex);
        }

        private void numSynthPoint_ValueChanged(object sender, EventArgs e)
        {
            if (this.numSynthPoint.Value < 0M)
                return;
            if (this.numSynthPoint.Value > 9999M)
            {
                this.numSynthPoint.Value = 9999M;
            }
            else
            {
                string str = ((int)this.numSynthPoint.Value + 32768).ToString("X2");
                while (str.Length < 4)
                    str = "0" + str;
                if (str.Length > 4)
                {
                    int num = (int)MessageBox.Show("Error: The hex value is more than 2 bytes");
                }
                else
                {
                    this.updateHex(str.Substring(2, 2), 184);
                    this.updateHex(str.Substring(0, 2), 186);
                }
            }
        }

        private void updateClearedRankInHex(int rank, string str)
        {
            while (str.Length < 4)
                str = "0" + str;
            str = Program.form.run.hexAndMathFunction.reversehex(str, 4);
            this.updateHex(str, 188 + rank * 4);
        }

        private void numClearedC_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedC.Value < 0M)
                return;
            this.updateClearedRankInHex(0, ((int)this.numClearedC.Value).ToString("X2"));
        }

        private void numClearedB_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedB.Value < 0M)
                return;
            this.updateClearedRankInHex(1, ((int)this.numClearedB.Value).ToString("X2"));
        }

        private void numClearedA_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedA.Value < 0M)
                return;
            this.updateClearedRankInHex(2, ((int)this.numClearedA.Value).ToString("X2"));
        }

        private void numClearedS_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedS.Value < 0M)
                return;
            this.updateClearedRankInHex(3, ((int)this.numClearedS.Value).ToString("X2"));
        }

        private void numClearedInf_ValueChanged(object sender, EventArgs e)
        {
            if (this.numClearedInf.Value < 0M)
                return;
            this.updateClearedRankInHex(4, ((int)this.numClearedInf.Value).ToString("X2"));
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

        private void btnEditSpecialHex_Click(object sender, EventArgs e)
        {
            pspo2seForm.infinityMissionClass infinityMissionClass = Program.form.saveData.infinityMissions.slot[this.id];
            Program.form.entryForm.oldVal = this.editedHex.Substring(12, 20);
            Program.form.entryForm.newVal = this.editedHex.Substring(12, 20);
            Program.form.entryForm.description = "special effect hex";
            Program.form.entryForm.maxLen = 20;
            if (Program.form.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = Program.form.entryForm.newVal;
            if (!(newVal != this.editedHex.Substring(12, 20)))
                return;
            if (newVal.Length != 20)
            {
                int num = (int)MessageBox.Show("The hex length must be 10 bytes (20 characters).", "Special Hex Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
                this.updateHex(newVal, 12);
        }

        private void btnModHex_Click(object sender, EventArgs e)
        {
            pspo2seForm.infinityMissionClass infinityMissionClass = Program.form.saveData.infinityMissions.slot[this.id];
            Program.form.entryForm.oldVal = this.editedHex.Substring(12, 20);
            Program.form.entryForm.newVal = this.editedHex.Substring(12, 20);
            Program.form.entryForm.description = "special effect hex mod";
            Program.form.entryForm.maxLen = 20;
            if (Program.form.entryForm.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            string newVal = Program.form.entryForm.newVal;
            if (!(newVal != this.editedHex.Substring(12, 20)))
                return;
            if (newVal.Length != 20)
            {
                int num = (int)MessageBox.Show("The hex length must be 10 bytes (20 characters).", "Special Hex Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
                this.updateHex(newVal, 12);
        }

        private void chkEnemyTable1Mod_CheckedChanged(object sender, EventArgs e) => this.comboEnemyTable1_SelectedIndexChanged(sender, e);
    }
}
