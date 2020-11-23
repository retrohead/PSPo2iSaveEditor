// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.saveStructureIndexType
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
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
          this.total_size = 271760;
          this.total_size_enc = 271776;
          this.header_size = 8;
          this.slots_position = 8;
          this.slot_size = 23488;
          this.character_info_size = 252;
          this.type_level_pos = 308;
          this.type_extend_size = 14;
          this.inventory_slots_used_pos = 440;
          this.inventory_slots_pos = 1020;
          this.story_info_pos = 3286;
          this.shared_inventory_pos = 247440;
          this.shared_inventory_slots = 1000;
          this.max_type_abilities = 8;
          this.character_name_pos2 = 14928;
          this.infinity_mission_pos = this.total_size;
          break;
        case pspo2seForm.SaveType.PSP2I:
          this.character_file_ext = "pspo2icharacter";
          this.character_file_name = "PSPo2i Character File";
          this.item_file_ext = "pspo2item";
          this.item_file_name = "PSPo2/i Item File";
          this.inventory_file_ext = "pspo2iinventory";
          this.inventory_file_name = "PSPo2i Inventory File";
          this.storage_file_ext = "pspo2istorage";
          this.storage_file_name = "PSPo2i Storage File";
          this.total_size = 301352;
          this.total_size_enc = 301368;
          this.header_size = 8;
          this.slots_position = 8;
          this.slot_size = 22796;
          this.character_info_size = 252;
          this.type_level_pos = 308;
          this.type_extend_size = 16;
          this.inventory_slots_used_pos = 476;
          this.inventory_slots_pos = 1080;
          this.story_info_pos = 3360;
          this.shared_inventory_pos = 245496;
          this.shared_inventory_slots = 2000;
          this.max_type_abilities = 12;
          this.character_name_pos2 = 14116;
          this.infinity_mission_pos = 290888;
          break;
        default:
          int num = (int) MessageBox.Show("save type not accepted: changeSaveSettingsType : " + (object) type);
          break;
      }
    }
  }
}
