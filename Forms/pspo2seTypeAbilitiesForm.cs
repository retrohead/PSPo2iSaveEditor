using pspo2seSaveEditorProgram.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
    public partial class pspo2seTypeAbilitiesForm : Form
    {
        private int usedSlots;
        private int allowedSlots;
        private pspo2seTypeAbilitiesForm.viewType view;
        private bool allowEdit;
        private bool legitMode = true;
        private pspo2seForm.jobClass[] oldJobInfo = new pspo2seForm.jobClass[4];
        private pspo2seForm.jobClass newJobInfo = new pspo2seForm.jobClass();
        private pspo2seForm.jobType selected_job = pspo2seForm.jobType.None;
        private int parent_max_abilities;
        private string char_name = "";
        private pspo2seAbilityDb parentsAbilityDb;
        private pspo2seTypeAbilitiesForm.abilitySlotsType[] listOfAbilities = new pspo2seTypeAbilitiesForm.abilitySlotsType[257];
        private int listOfAbilitiesSlotCount;
        private pspo2seForm.SaveType save_type;

        public pspo2seForm.jobClass[] oldJobs
        {
            get => this.oldJobInfo;
            set => this.oldJobInfo = value;
        }

        public pspo2seForm.jobClass newJob
        {
            get => this.newJobInfo;
            set => this.newJobInfo = value;
        }

        public pspo2seForm.jobType selectedJob
        {
            get => this.selected_job;
            set => this.selected_job = value;
        }

        public int max_abilities
        {
            get => this.parent_max_abilities;
            set => this.parent_max_abilities = value;
        }

        public string character_name
        {
            get => this.char_name;
            set => this.char_name = value;
        }

        public pspo2seAbilityDb abilityDb
        {
            get => this.parentsAbilityDb;
            set => this.parentsAbilityDb = value;
        }

        public pspo2seForm.SaveType saveType
        {
            get => this.save_type;
            set => this.save_type = value;
        }

        public pspo2seTypeAbilitiesForm()
        {
            this.InitializeComponent();
            this.radioBtnReal.Checked = true;
            this.radioBtnFake.Checked = false;
        }

        public void loadCurrentTypeInformation()
        {
            if (this.oldJobs[(int)this.selected_job] == null)
            {
                int num = (int)MessageBox.Show("Current job information was not set");
                this.DialogResult = DialogResult.Cancel;
                this.Dispose();
            }
            else
            {
                this.newJob = this.oldJobs[(int)this.selected_job];
                this.listTypeAbilities();
                this.txtTypeName.Text = this.newJob.job.ToString();
                this.txtTypeLevel.Text = "LV" + (object)this.newJob.level;
            }
        }

        private void resetTypeAbilitySlots()
        {
            this.imgSlot1.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot2.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot3.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot4.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot5.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot6.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot7.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot8.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot9.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot10.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot11.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot12.Image = (Image)Resources.TypeAbilitiesFree;
            this.imgSlot1.Visible = true;
            this.imgSlot2.Visible = true;
            this.imgSlot3.Visible = true;
            this.imgSlot4.Visible = true;
            this.imgSlot5.Visible = false;
            this.imgSlot6.Visible = false;
            this.imgSlot7.Visible = false;
            this.imgSlot8.Visible = false;
            this.imgSlot9.Visible = false;
            this.imgSlot10.Visible = false;
            this.imgSlot11.Visible = false;
            this.imgSlot12.Visible = false;
        }

        private void allowedAbilitySlotsLogic()
        {
            this.allowedSlots = 4;
            int num = this.newJob.level;
            if (!this.legitMode)
                num = this.saveType != pspo2seForm.SaveType.PSP2I ? 30 : 31;
            for (int index = 1; index <= num; ++index)
            {
                switch (index)
                {
                    case 5:
                        this.imgSlot5.Visible = true;
                        ++this.allowedSlots;
                        break;
                    case 10:
                        this.imgSlot6.Visible = true;
                        ++this.allowedSlots;
                        break;
                    case 15:
                        this.imgSlot7.Visible = true;
                        ++this.allowedSlots;
                        break;
                    case 20:
                        this.imgSlot8.Visible = true;
                        ++this.allowedSlots;
                        break;
                    case 31:
                        this.imgSlot9.Visible = true;
                        this.imgSlot10.Visible = true;
                        this.imgSlot11.Visible = true;
                        this.imgSlot12.Visible = true;
                        this.allowedSlots = 12;
                        break;
                }
            }
        }

        private void usedSlotsLogic()
        {
            this.allowEdit = true;
            this.usedSlots = 0;
            if (!this.legitMode)
            {
                this.allowedSlots = this.saveType != pspo2seForm.SaveType.PSP2I ? 8 : 12;
                this.usedSlots = this.allowedSlots;
                for (int index = 0; index < this.listOfAbilitiesSlotCount; ++index)
                {
                    if (this.listOfAbilities[index].name == "No Ability")
                        --this.usedSlots;
                }
            }
            else
            {
                for (int index = 0; index < this.listViewAbilities.Items.Count; ++index)
                {
                    pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = this.abilityDb.findAbilityInDb(this.listViewAbilities.Items[index].SubItems[2].Text);
                    if (this.saveType == pspo2seForm.SaveType.PSP2I)
                    {
                        abilityInDb.slots = abilityInDb.slots_inf;
                        abilityInDb.hu_lvl = abilityInDb.hu_lvl_inf;
                        abilityInDb.ra_lvl = abilityInDb.ra_lvl_inf;
                        abilityInDb.fo_lvl = abilityInDb.fo_lvl_inf;
                        abilityInDb.va_lvl = abilityInDb.va_lvl_inf;
                    }
                    if (abilityInDb.slots > 0)
                        this.usedSlots += abilityInDb.slots;
                    else if (abilityInDb.name != "No Ability")
                    {
                        int num = (int)MessageBox.Show("You have an ability equipped with unknown slot costs\r\nYou will be unable to add abilities at the moment\r\nbut you can still remove the unknown ability.\r\n\r\nPlease wait for a future abilities database update\r\nfor full functionality\r\n\r\nThe offending ability is " + abilityInDb.name + " [" + abilityInDb.hex + "]", "Database Info Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.allowEdit = false;
                        this.usedSlots = 0;
                        break;
                    }
                }
            }
            for (int index = 1; index <= this.usedSlots; ++index)
            {
                switch (index)
                {
                    case 1:
                        this.imgSlot1.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 2:
                        this.imgSlot2.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 3:
                        this.imgSlot3.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 4:
                        this.imgSlot4.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 5:
                        this.imgSlot5.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 6:
                        this.imgSlot6.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 7:
                        this.imgSlot7.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 8:
                        this.imgSlot8.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 9:
                        this.imgSlot9.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 10:
                        this.imgSlot10.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 11:
                        this.imgSlot11.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 12:
                        this.imgSlot12.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                }
            }
        }

        private void typeAbilitySlotLogic()
        {
            this.resetTypeAbilitySlots();
            this.allowedAbilitySlotsLogic();
            this.usedSlotsLogic();
            if (!this.allowEdit)
                this.txtUsedSlots.Text = "unk_/" + (object)this.allowedSlots;
            else
                this.txtUsedSlots.Text = this.usedSlots.ToString() + "/" + (object)this.allowedSlots;
        }

        private void listTypeAbilities()
        {
            this.chkListAll.Visible = false;
            this.view = pspo2seTypeAbilitiesForm.viewType.equipped;
            this.btnChange.Text = "add";
            this.btnRemove.Text = "remove";
            this.listViewAbilities.Items.Clear();
            this.listOfAbilitiesSlotCount = 0;
            for (int index = 0; index < this.max_abilities; ++index)
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = this.abilityDb.findAbilityInDb(this.newJob.attachedAbilities.Substring(index * 2, 2));
                if (abilityInDb.name == "")
                    abilityInDb.name = abilityInDb.name_jp;
                if (abilityInDb.hex != "")
                {
                    if (this.saveType == pspo2seForm.SaveType.PSP2I)
                        abilityInDb.slots = abilityInDb.slots_inf;
                    if (abilityInDb.slots != 0)
                    {
                        ListViewItem listViewItem = !this.legitMode ? new ListViewItem("1", 0) : new ListViewItem(string.Concat((object)abilityInDb.slots), 0);
                        listViewItem.SubItems.Add(abilityInDb.name);
                        listViewItem.SubItems.Add(abilityInDb.hex);
                        this.listViewAbilities.Items.Add(listViewItem);
                    }
                    this.listOfAbilities[this.listOfAbilitiesSlotCount] = new pspo2seTypeAbilitiesForm.abilitySlotsType();
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].hex = abilityInDb.hex;
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].name = abilityInDb.name;
                    ++this.listOfAbilitiesSlotCount;
                }
            }
            this.txtAbilityName.Text = this.newJob.attachedAbilities;
            this.txtCharName.Text = this.character_name;
            this.typeAbilitySlotLogic();
            this.showSelectedAbility();
        }

        private void listAvailableTypeAbilities()
        {
            if (Program.form.legitVersion())
                this.chkListAll.Visible = false;
            else
                this.chkListAll.Visible = true;
            this.view = pspo2seTypeAbilitiesForm.viewType.available;
            this.btnChange.Text = "apply";
            this.btnRemove.Text = "cancel";
            this.listViewAbilities.Items.Clear();
            this.listOfAbilitiesSlotCount = 0;
            for (int index = 0; index < this.abilityDb.ability_db_filled; ++index)
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass abilityDbAbilitiyClass = this.abilityDb.ability_db.ability[index];
                if (this.saveType == pspo2seForm.SaveType.PSP2I)
                {
                    abilityDbAbilitiyClass.slots = abilityDbAbilitiyClass.slots_inf;
                    abilityDbAbilitiyClass.hu_lvl = abilityDbAbilitiyClass.hu_lvl_inf;
                    abilityDbAbilitiyClass.ra_lvl = abilityDbAbilitiyClass.ra_lvl_inf;
                    abilityDbAbilitiyClass.fo_lvl = abilityDbAbilitiyClass.fo_lvl_inf;
                    abilityDbAbilitiyClass.va_lvl = abilityDbAbilitiyClass.va_lvl_inf;
                }
                if (abilityDbAbilitiyClass.name == "")
                    abilityDbAbilitiyClass.name = abilityDbAbilitiyClass.name_jp;
                if (abilityDbAbilitiyClass.hex != "")
                {
                    bool flag = false;
                    if (abilityDbAbilitiyClass.slots != 0)
                    {
                        if (!this.canFindAbilityInAttached(abilityDbAbilitiyClass.hex))
                        {
                            if (!this.chkListAll.Checked)
                            {
                                if (abilityDbAbilitiyClass.hu_lvl <= this.oldJobs[0].level && abilityDbAbilitiyClass.hu_lvl > 0 || abilityDbAbilitiyClass.ra_lvl <= this.oldJobs[1].level && abilityDbAbilitiyClass.ra_lvl > 0 || (abilityDbAbilitiyClass.fo_lvl <= this.oldJobs[2].level && abilityDbAbilitiyClass.fo_lvl > 0 || abilityDbAbilitiyClass.va_lvl <= this.oldJobs[3].level && abilityDbAbilitiyClass.va_lvl > 0) || abilityDbAbilitiyClass.hu_lvl == 0 && abilityDbAbilitiyClass.ra_lvl == 0 && (abilityDbAbilitiyClass.fo_lvl == 0 && abilityDbAbilitiyClass.va_lvl == 0))
                                    flag = true;
                            }
                            else
                                flag = true;
                        }
                        if (flag)
                        {
                            ListViewItem listViewItem = !this.legitMode ? new ListViewItem("1", 0) : new ListViewItem(string.Concat((object)abilityDbAbilitiyClass.slots), 0);
                            listViewItem.SubItems.Add(abilityDbAbilitiyClass.name);
                            listViewItem.SubItems.Add(abilityDbAbilitiyClass.hex);
                            this.listViewAbilities.Items.Add(listViewItem);
                        }
                    }
                    this.listOfAbilities[this.listOfAbilitiesSlotCount] = new pspo2seTypeAbilitiesForm.abilitySlotsType();
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].hex = abilityDbAbilitiyClass.hex;
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].name = abilityDbAbilitiyClass.name;
                    this.listOfAbilities[this.listOfAbilitiesSlotCount].valid = flag;
                    ++this.listOfAbilitiesSlotCount;
                }
            }
            this.txtAbilityName.Text = this.newJob.attachedAbilities;
            this.txtCharName.Text = this.character_name;
            this.showSelectedAbility();
        }

        public void showSelectedAbility()
        {
            pspo2seAbilityDb.abilityDb_AbilitiyClass abilityDbAbilitiyClass = new pspo2seAbilityDb.abilityDb_AbilitiyClass();
            if (this.listViewAbilities.SelectedItems.Count == 0)
            {
                if (this.listViewAbilities.Items.Count > 0)
                {
                    this.listViewAbilities.Items[0].Selected = true;
                    abilityDbAbilitiyClass = this.abilityDb.findAbilityInDb(this.listViewAbilities.Items[0].SubItems[2].Text);
                }
            }
            else
                abilityDbAbilitiyClass = this.abilityDb.findAbilityInDb(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
            this.txtAbilityName.Text = abilityDbAbilitiyClass.name;
            this.txtAbilityName_jp.Text = abilityDbAbilitiyClass.name_jp;
            this.txtAbilityDesc.Text = abilityDbAbilitiyClass.desc;
            this.imgAbilityCost.Visible = true;
            switch (abilityDbAbilitiyClass.slots)
            {
                case 1:
                    this.imgAbilityCost.Image = (Image)Resources.TypeAbilities_cost_1;
                    break;
                case 2:
                    this.imgAbilityCost.Image = (Image)Resources.TypeAbilities_cost_2;
                    break;
                case 3:
                    this.imgAbilityCost.Image = (Image)Resources.TypeAbilities_cost_3;
                    break;
                case 4:
                    this.imgAbilityCost.Image = (Image)Resources.TypeAbilities_cost_4;
                    break;
                default:
                    this.imgAbilityCost.Visible = false;
                    break;
            }
        }

        private void listViewAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewAbilities.SelectedItems.Count <= 0)
                return;
            this.showSelectedAbility();
        }

        private void pspo2seTypeAbilitiesForm_Load(object sender, EventArgs e)
        {
            if (Program.form.legitVersion())
            {
                this.radioBtnReal.Visible = false;
                this.radioBtnFake.Visible = false;
            }
            this.loadCurrentTypeInformation();
        }

        private void radioBtnReal_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioBtnReal.Checked)
                return;
            this.legitMode = true;
            this.listTypeAbilities();
            this.typeAbilitySlotLogic();
        }

        private void radioBtnFake_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioBtnFake.Checked)
                return;
            this.legitMode = false;
            this.listTypeAbilities();
            this.typeAbilitySlotLogic();
        }

        private int findAbilityPos(string hex)
        {
            for (int index = 0; index < this.max_abilities; ++index)
            {
                if (this.newJob.attachedAbilities.Substring(index * 2, 2) == hex)
                    return index * 2;
            }
            int num = (int)MessageBox.Show("Fatal Error!\r\nThe selected ability " + hex + " was not found in the attached abilities\r\n" + this.newJob.attachedAbilities);
            return 0;
        }

        private bool canFindAbilityInAttached(string hex)
        {
            for (int index = 0; index < this.max_abilities; ++index)
            {
                if (this.newJob.attachedAbilities.Substring(index * 2, 2) == hex)
                    return true;
            }
            return false;
        }

        private void removeAbility(string hex)
        {
            int abilityPos = this.findAbilityPos(hex);
            string str1 = this.newJob.attachedAbilities.Substring(0, abilityPos);
            string str2 = this.newJob.attachedAbilities.Substring(abilityPos + 2, this.newJob.attachedAbilities.Length - str1.Length - 2);
            this.newJob.attachedAbilities = str1 + "00" + str2;
            this.listTypeAbilities();
        }

        private void addAbility(string hex)
        {
            int abilityPos = this.findAbilityPos("00");
            string str1 = this.newJob.attachedAbilities.Substring(0, abilityPos);
            string str2 = this.newJob.attachedAbilities.Substring(abilityPos + 2, this.newJob.attachedAbilities.Length - str1.Length - 2);
            this.newJob.attachedAbilities = str1 + hex + str2;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.view == pspo2seTypeAbilitiesForm.viewType.equipped)
            {
                if (this.listViewAbilities.SelectedItems.Count > 0)
                {
                    this.removeAbility(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
                }
                else
                {
                    int num = (int)MessageBox.Show("Please select an ability to remove", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                this.listTypeAbilities();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.view == pspo2seTypeAbilitiesForm.viewType.equipped)
            {
                if (!this.allowEdit)
                {
                    int num1 = (int)MessageBox.Show("You must remove any unknown abilities first!\r\nPlease wait for a database update for better functionality", "Unknown ability detected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (this.usedSlots >= this.allowedSlots)
                {
                    if (Program.form.legitVersion())
                    {
                        int num2 = (int)MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (this.radioBtnFake.Checked)
                    {
                        int num3 = (int)MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int num4 = (int)MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one\r\nor you can click to fake the slots", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                    this.listAvailableTypeAbilities();
            }
            else
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = this.abilityDb.findAbilityInDb(this.listViewAbilities.SelectedItems[0].SubItems[2].Text);
                if (this.legitMode)
                {
                    if (this.usedSlots + abilityInDb.slots <= this.allowedSlots)
                        flag = true;
                }
                else if (this.allowedSlots > this.usedSlots)
                    flag = true;
                if (flag)
                {
                    this.addAbility(abilityInDb.hex);
                    this.listTypeAbilities();
                }
                else
                {
                    int num5 = (int)MessageBox.Show("You do not have enough slots for that ability", "Mamimum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void chkListAll_CheckedChanged(object sender, EventArgs e) => this.listAvailableTypeAbilities();

        private enum viewType
        {
            equipped,
            available,
        }

        private class abilitySlotsType
        {
            public bool valid;
            public string hex = "";
            public string name = "";
        }
    }
}
