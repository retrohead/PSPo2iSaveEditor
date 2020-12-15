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
            get => oldJobInfo;
            set => oldJobInfo = value;
        }

        public pspo2seForm.jobClass newJob
        {
            get => newJobInfo;
            set => newJobInfo = value;
        }

        public pspo2seForm.jobType selectedJob
        {
            get => selected_job;
            set => selected_job = value;
        }

        public int max_abilities
        {
            get => parent_max_abilities;
            set => parent_max_abilities = value;
        }

        public string character_name
        {
            get => char_name;
            set => char_name = value;
        }

        public pspo2seAbilityDb abilityDb
        {
            get => parentsAbilityDb;
            set => parentsAbilityDb = value;
        }

        public pspo2seForm.SaveType saveType
        {
            get => save_type;
            set => save_type = value;
        }

        public pspo2seTypeAbilitiesForm()
        {
            InitializeComponent();
            radioBtnReal.Checked = true;
            radioBtnFake.Checked = false;
        }

        public void loadCurrentTypeInformation()
        {
            if (oldJobs[(int)selected_job] == null)
            {
                int num = (int)MessageBox.Show("Current job information was not set");
                DialogResult = DialogResult.Cancel;
                Dispose();
            }
            else
            {
                newJob = oldJobs[(int)selected_job];
                listTypeAbilities();
                txtTypeName.Text = newJob.job.ToString();
                txtTypeLevel.Text = "LV" + (object)newJob.level;
            }
        }

        private void resetTypeAbilitySlots()
        {
            imgSlot1.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot2.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot3.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot4.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot5.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot6.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot7.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot8.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot9.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot10.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot11.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot12.Image = (Image)Resources.TypeAbilitiesFree;
            imgSlot1.Visible = true;
            imgSlot2.Visible = true;
            imgSlot3.Visible = true;
            imgSlot4.Visible = true;
            imgSlot5.Visible = false;
            imgSlot6.Visible = false;
            imgSlot7.Visible = false;
            imgSlot8.Visible = false;
            imgSlot9.Visible = false;
            imgSlot10.Visible = false;
            imgSlot11.Visible = false;
            imgSlot12.Visible = false;
        }

        private void allowedAbilitySlotsLogic()
        {
            allowedSlots = 4;
            int num = newJob.level;
            if (!legitMode)
                num = saveType != pspo2seForm.SaveType.PSP2I ? 30 : 31;
            for (int index = 1; index <= num; ++index)
            {
                switch (index)
                {
                    case 5:
                        imgSlot5.Visible = true;
                        ++allowedSlots;
                        break;
                    case 10:
                        imgSlot6.Visible = true;
                        ++allowedSlots;
                        break;
                    case 15:
                        imgSlot7.Visible = true;
                        ++allowedSlots;
                        break;
                    case 20:
                        imgSlot8.Visible = true;
                        ++allowedSlots;
                        break;
                    case 31:
                        imgSlot9.Visible = true;
                        imgSlot10.Visible = true;
                        imgSlot11.Visible = true;
                        imgSlot12.Visible = true;
                        allowedSlots = 12;
                        break;
                }
            }
        }

        private void usedSlotsLogic()
        {
            allowEdit = true;
            usedSlots = 0;
            if (!legitMode)
            {
                allowedSlots = saveType != pspo2seForm.SaveType.PSP2I ? 8 : 12;
                usedSlots = allowedSlots;
                for (int index = 0; index < listOfAbilitiesSlotCount; ++index)
                {
                    if (listOfAbilities[index].name == "No Ability")
                        --usedSlots;
                }
            }
            else
            {
                for (int index = 0; index < listViewAbilities.Items.Count; ++index)
                {
                    pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = abilityDb.findAbilityInDb(listViewAbilities.Items[index].SubItems[2].Text);
                    if (saveType == pspo2seForm.SaveType.PSP2I)
                    {
                        abilityInDb.slots = abilityInDb.slots_inf;
                        abilityInDb.hu_lvl = abilityInDb.hu_lvl_inf;
                        abilityInDb.ra_lvl = abilityInDb.ra_lvl_inf;
                        abilityInDb.fo_lvl = abilityInDb.fo_lvl_inf;
                        abilityInDb.va_lvl = abilityInDb.va_lvl_inf;
                    }
                    if (abilityInDb.slots > 0)
                        usedSlots += abilityInDb.slots;
                    else if (abilityInDb.name != "No Ability")
                    {
                        int num = (int)MessageBox.Show("You have an ability equipped with unknown slot costs\r\nYou will be unable to add abilities at the moment\r\nbut you can still remove the unknown ability.\r\n\r\nPlease wait for a future abilities database update\r\nfor full functionality\r\n\r\nThe offending ability is " + abilityInDb.name + " [" + abilityInDb.hex + "]", "Database Info Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        allowEdit = false;
                        usedSlots = 0;
                        break;
                    }
                }
            }
            for (int index = 1; index <= usedSlots; ++index)
            {
                switch (index)
                {
                    case 1:
                        imgSlot1.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 2:
                        imgSlot2.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 3:
                        imgSlot3.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 4:
                        imgSlot4.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 5:
                        imgSlot5.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 6:
                        imgSlot6.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 7:
                        imgSlot7.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 8:
                        imgSlot8.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 9:
                        imgSlot9.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 10:
                        imgSlot10.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 11:
                        imgSlot11.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                    case 12:
                        imgSlot12.Image = (Image)Resources.TypeAbilitiesUsed;
                        break;
                }
            }
        }

        private void typeAbilitySlotLogic()
        {
            resetTypeAbilitySlots();
            allowedAbilitySlotsLogic();
            usedSlotsLogic();
            if (!allowEdit)
                txtUsedSlots.Text = "unk_/" + (object)allowedSlots;
            else
                txtUsedSlots.Text = usedSlots.ToString() + "/" + (object)allowedSlots;
        }

        private void listTypeAbilities()
        {
            chkListAll.Visible = false;
            view = pspo2seTypeAbilitiesForm.viewType.equipped;
            btnChange.Text = "add";
            btnRemove.Text = "remove";
            listViewAbilities.Items.Clear();
            listOfAbilitiesSlotCount = 0;
            for (int index = 0; index < max_abilities; ++index)
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = abilityDb.findAbilityInDb(newJob.attachedAbilities.Substring(index * 2, 2));
                if (abilityInDb.name == "")
                    abilityInDb.name = abilityInDb.name_jp;
                if (abilityInDb.hex != "")
                {
                    if (saveType == pspo2seForm.SaveType.PSP2I)
                        abilityInDb.slots = abilityInDb.slots_inf;
                    if (abilityInDb.slots != 0)
                    {
                        ListViewItem listViewItem = !legitMode ? new ListViewItem("1", 0) : new ListViewItem(string.Concat((object)abilityInDb.slots), 0);
                        listViewItem.SubItems.Add(abilityInDb.name);
                        listViewItem.SubItems.Add(abilityInDb.hex);
                        listViewAbilities.Items.Add(listViewItem);
                    }
                    listOfAbilities[listOfAbilitiesSlotCount] = new pspo2seTypeAbilitiesForm.abilitySlotsType();
                    listOfAbilities[listOfAbilitiesSlotCount].hex = abilityInDb.hex;
                    listOfAbilities[listOfAbilitiesSlotCount].name = abilityInDb.name;
                    ++listOfAbilitiesSlotCount;
                }
            }
            txtAbilityName.Text = newJob.attachedAbilities;
            txtCharName.Text = character_name;
            typeAbilitySlotLogic();
            showSelectedAbility();
        }

        private void listAvailableTypeAbilities()
        {
            if (Program.form.legitVersion())
                chkListAll.Visible = false;
            else
                chkListAll.Visible = true;
            view = pspo2seTypeAbilitiesForm.viewType.available;
            btnChange.Text = "apply";
            btnRemove.Text = "cancel";
            listViewAbilities.Items.Clear();
            listOfAbilitiesSlotCount = 0;
            for (int index = 0; index < abilityDb.ability_db_filled; ++index)
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass abilityDbAbilitiyClass = abilityDb.ability_db.ability[index];
                if (saveType == pspo2seForm.SaveType.PSP2I)
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
                        if (!canFindAbilityInAttached(abilityDbAbilitiyClass.hex))
                        {
                            if (!chkListAll.Checked)
                            {
                                if (abilityDbAbilitiyClass.hu_lvl <= oldJobs[0].level && abilityDbAbilitiyClass.hu_lvl > 0 || abilityDbAbilitiyClass.ra_lvl <= oldJobs[1].level && abilityDbAbilitiyClass.ra_lvl > 0 || (abilityDbAbilitiyClass.fo_lvl <= oldJobs[2].level && abilityDbAbilitiyClass.fo_lvl > 0 || abilityDbAbilitiyClass.va_lvl <= oldJobs[3].level && abilityDbAbilitiyClass.va_lvl > 0) || abilityDbAbilitiyClass.hu_lvl == 0 && abilityDbAbilitiyClass.ra_lvl == 0 && (abilityDbAbilitiyClass.fo_lvl == 0 && abilityDbAbilitiyClass.va_lvl == 0))
                                    flag = true;
                            }
                            else
                                flag = true;
                        }
                        if (flag)
                        {
                            ListViewItem listViewItem = !legitMode ? new ListViewItem("1", 0) : new ListViewItem(string.Concat((object)abilityDbAbilitiyClass.slots), 0);
                            listViewItem.SubItems.Add(abilityDbAbilitiyClass.name);
                            listViewItem.SubItems.Add(abilityDbAbilitiyClass.hex);
                            listViewAbilities.Items.Add(listViewItem);
                        }
                    }
                    listOfAbilities[listOfAbilitiesSlotCount] = new pspo2seTypeAbilitiesForm.abilitySlotsType();
                    listOfAbilities[listOfAbilitiesSlotCount].hex = abilityDbAbilitiyClass.hex;
                    listOfAbilities[listOfAbilitiesSlotCount].name = abilityDbAbilitiyClass.name;
                    listOfAbilities[listOfAbilitiesSlotCount].valid = flag;
                    ++listOfAbilitiesSlotCount;
                }
            }
            txtAbilityName.Text = newJob.attachedAbilities;
            txtCharName.Text = character_name;
            showSelectedAbility();
        }

        public void showSelectedAbility()
        {
            pspo2seAbilityDb.abilityDb_AbilitiyClass abilityDbAbilitiyClass = new pspo2seAbilityDb.abilityDb_AbilitiyClass();
            if (listViewAbilities.SelectedItems.Count == 0)
            {
                if (listViewAbilities.Items.Count > 0)
                {
                    listViewAbilities.Items[0].Selected = true;
                    abilityDbAbilitiyClass = abilityDb.findAbilityInDb(listViewAbilities.Items[0].SubItems[2].Text);
                }
            }
            else
                abilityDbAbilitiyClass = abilityDb.findAbilityInDb(listViewAbilities.SelectedItems[0].SubItems[2].Text);
            txtAbilityName.Text = abilityDbAbilitiyClass.name;
            txtAbilityName_jp.Text = abilityDbAbilitiyClass.name_jp;
            txtAbilityDesc.Text = abilityDbAbilitiyClass.desc;
            imgAbilityCost.Visible = true;
            switch (abilityDbAbilitiyClass.slots)
            {
                case 1:
                    imgAbilityCost.Image = (Image)Resources.TypeAbilities_cost_1;
                    break;
                case 2:
                    imgAbilityCost.Image = (Image)Resources.TypeAbilities_cost_2;
                    break;
                case 3:
                    imgAbilityCost.Image = (Image)Resources.TypeAbilities_cost_3;
                    break;
                case 4:
                    imgAbilityCost.Image = (Image)Resources.TypeAbilities_cost_4;
                    break;
                default:
                    imgAbilityCost.Visible = false;
                    break;
            }
        }

        private void listViewAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAbilities.SelectedItems.Count <= 0)
                return;
            showSelectedAbility();
        }

        private void pspo2seTypeAbilitiesForm_Load(object sender, EventArgs e)
        {
            if (Program.form.legitVersion())
            {
                radioBtnReal.Visible = false;
                radioBtnFake.Visible = false;
            }
            loadCurrentTypeInformation();
        }

        private void radioBtnReal_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioBtnReal.Checked)
                return;
            legitMode = true;
            listTypeAbilities();
            typeAbilitySlotLogic();
        }

        private void radioBtnFake_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioBtnFake.Checked)
                return;
            legitMode = false;
            listTypeAbilities();
            typeAbilitySlotLogic();
        }

        private int findAbilityPos(string hex)
        {
            for (int index = 0; index < max_abilities; ++index)
            {
                if (newJob.attachedAbilities.Substring(index * 2, 2) == hex)
                    return index * 2;
            }
            int num = (int)MessageBox.Show("Fatal Error!\r\nThe selected ability " + hex + " was not found in the attached abilities\r\n" + newJob.attachedAbilities);
            return 0;
        }

        private bool canFindAbilityInAttached(string hex)
        {
            for (int index = 0; index < max_abilities; ++index)
            {
                if (newJob.attachedAbilities.Substring(index * 2, 2) == hex)
                    return true;
            }
            return false;
        }

        private void removeAbility(string hex)
        {
            int abilityPos = findAbilityPos(hex);
            string str1 = newJob.attachedAbilities.Substring(0, abilityPos);
            string str2 = newJob.attachedAbilities.Substring(abilityPos + 2, newJob.attachedAbilities.Length - str1.Length - 2);
            newJob.attachedAbilities = str1 + "00" + str2;
            listTypeAbilities();
        }

        private void addAbility(string hex)
        {
            int abilityPos = findAbilityPos("00");
            string str1 = newJob.attachedAbilities.Substring(0, abilityPos);
            string str2 = newJob.attachedAbilities.Substring(abilityPos + 2, newJob.attachedAbilities.Length - str1.Length - 2);
            newJob.attachedAbilities = str1 + hex + str2;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (view == pspo2seTypeAbilitiesForm.viewType.equipped)
            {
                if (listViewAbilities.SelectedItems.Count > 0)
                {
                    removeAbility(listViewAbilities.SelectedItems[0].SubItems[2].Text);
                }
                else
                {
                    int num = (int)MessageBox.Show("Please select an ability to remove", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                listTypeAbilities();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (view == pspo2seTypeAbilitiesForm.viewType.equipped)
            {
                if (!allowEdit)
                {
                    int num1 = (int)MessageBox.Show("You must remove any unknown abilities first!\r\nPlease wait for a database update for better functionality", "Unknown ability detected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (usedSlots >= allowedSlots)
                {
                    if (Program.form.legitVersion())
                    {
                        int num2 = (int)MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (radioBtnFake.Checked)
                    {
                        int num3 = (int)MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int num4 = (int)MessageBox.Show("You have reached the maximum slots\r\nRemove an ability to add a new one\r\nor you can click to fake the slots", "Maximum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                    listAvailableTypeAbilities();
            }
            else
            {
                pspo2seAbilityDb.abilityDb_AbilitiyClass abilityInDb = abilityDb.findAbilityInDb(listViewAbilities.SelectedItems[0].SubItems[2].Text);
                if (legitMode)
                {
                    if (usedSlots + abilityInDb.slots <= allowedSlots)
                        flag = true;
                }
                else if (allowedSlots > usedSlots)
                    flag = true;
                if (flag)
                {
                    addAbility(abilityInDb.hex);
                    listTypeAbilities();
                }
                else
                {
                    int num5 = (int)MessageBox.Show("You do not have enough slots for that ability", "Mamimum Slots Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void chkListAll_CheckedChanged(object sender, EventArgs e) => listAvailableTypeAbilities();

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
