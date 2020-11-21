namespace PSPo2iSaveEditor
{
    using System;
    using System.Windows.Forms;

    public class saveStructureIndexType
    {
        public string character_file_ext = "";
        public string character_file_name = "";
        public string item_file_ext = "";
        public string item_file_name = "";
        public string inventory_file_ext = "";
        public string inventory_file_name = "";
        public string storage_file_ext = "";
        public string storage_file_name = "";
        public int total_size;
        public int total_size_enc;
        public int header_size;
        public int slots_position;
        public int slot_size;
        public int character_info_size;
        public int type_level_pos;
        public int type_extend_size;
        public int inventory_slots_used_pos;
        public int inventory_slots_pos;
        public int shared_inventory_pos;
        public int shared_inventory_slots;
        public int infinity_mission_pos;
        public int story_info_pos;
        public int max_type_abilities;
        public int character_name_pos2;
        public bool encrypted;

        public void changeSaveSettingsType(pspo2seForm.SaveType type)
        {
            switch (type)
            {
                case pspo2seForm.SaveType.PSP2:
                    this.character_file_ext = "pspo2character";
                    this.character_file_name = "PSPo2 Character File";
                    this.item_file_ext = "pspo2item";
                    this.item_file_name = "PSPo2/i Item File";
                    this.inventory_file_ext = "pspo2inventory";
                    this.inventory_file_name = "PSPo2 Inventory File";
                    this.storage_file_ext = "pspo2storage";
                    this.storage_file_name = "PSPo2 Storage File";
                    this.total_size = 0x42590;
                    this.total_size_enc = 0x425a0;
                    this.header_size = 8;
                    this.slots_position = 8;
                    this.slot_size = 0x5bc0;
                    this.character_info_size = 0xfc;
                    this.type_level_pos = 0x134;
                    this.type_extend_size = 14;
                    this.inventory_slots_used_pos = 440;
                    this.inventory_slots_pos = 0x3fc;
                    this.story_info_pos = 0xcd6;
                    this.shared_inventory_pos = 0x3c690;
                    this.shared_inventory_slots = 0x3e8;
                    this.max_type_abilities = 8;
                    this.character_name_pos2 = 0x3a50;
                    this.infinity_mission_pos = this.total_size;
                    return;

                case pspo2seForm.SaveType.PSP2I:
                    this.character_file_ext = "pspo2icharacter";
                    this.character_file_name = "PSPo2i Character File";
                    this.item_file_ext = "pspo2item";
                    this.item_file_name = "PSPo2/i Item File";
                    this.inventory_file_ext = "pspo2iinventory";
                    this.inventory_file_name = "PSPo2i Inventory File";
                    this.storage_file_ext = "pspo2istorage";
                    this.storage_file_name = "PSPo2i Storage File";
                    this.total_size = 0x49928;
                    this.total_size_enc = 0x49938;
                    this.header_size = 8;
                    this.slots_position = 8;
                    this.slot_size = 0x590c;
                    this.character_info_size = 0xfc;
                    this.type_level_pos = 0x134;
                    this.type_extend_size = 0x10;
                    this.inventory_slots_used_pos = 0x1dc;
                    this.inventory_slots_pos = 0x438;
                    this.story_info_pos = 0xd20;
                    this.shared_inventory_pos = 0x3bef8;
                    this.shared_inventory_slots = 0x7d0;
                    this.max_type_abilities = 12;
                    this.character_name_pos2 = 0x3724;
                    this.infinity_mission_pos = 0x47048;
                    return;
            }
            MessageBox.Show("save type not accepted: changeSaveSettingsType : " + type);
        }
    }
}

