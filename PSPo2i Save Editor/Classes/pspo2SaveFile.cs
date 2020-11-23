using System;
using System.Windows;

namespace PSPo2i_Save_Editor
{
    public class pspo2SaveFile
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

            public void changeSaveSettingsType(SaveType type)
            {
                switch (type)
                {
                    case SaveType.PSP2:
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
                    case SaveType.PSP2I:
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
                        MessageBox.Show("save type not accepted: changeSaveSettingsType : " + (object)type);
                        break;
                }
            }
        }

        public enum SaveType
        {
            NONE,
            PSP2,
            PSP2I,
        }

        public enum extendRankType
        {
            none,
            c,
            b,
            a,
            s,
        }

        public class saveSlotType
        {
            public bool used;
            public string name = "";
            public string title = "";
            public string playtime = "";
            public raceTypes race;
            public sexType sex;
            public jobType cur_type;
            public int level;
            public int exp;
            public int exp_next;
            public int exp_percent;
            public long meseta;
            public bool mission_unlock_magashi;
            public bool mission_unlock_ep1;
            public bool mission_unlock_unknown;
            public bool mission_unlock_ep2;
            public bool story_ep_1_complete;
            public bool story_ep_2_complete;
            public bool skip_ep_1_start;
            public bool skip_ep_2_start;
            public string allow_quit_missions;
            public int story_ep_1_act;
            public string story_ep_1_points;
            public string story_ep_1_best_end;
            public string story_ep_2_points;
            public paInfoType pa = new paInfoType();
            public rebirthType rebirth = new rebirthType();
            public jobClass[] job = new jobClass[4];
            public inventoryClass inventory = new inventoryClass();
        }

        public enum raceTypes
        {
            Human,
            Newman,
            Cast,
            Beast,
            Duman,
            None,
        }

        public enum jobType
        {
            Hunter,
            Ranger,
            Force,
            Vanguard,
            None,
        }

        public enum sexType
        {
            Male,
            Female,
            None,
        }

        public class jobClass
        {
            public int level;
            public int exp;
            public int exp_to_next;
            public int exp_next;
            public int scramble_exp;
            public int exp_percent;
            public int extendpoints;
            public int extendpointsused;
            public string attachedAbilities;
            public jobType job;
            public extendRankType[] weapons_extended = new extendRankType[29];
        }

        public class rebirthType
        {
            public int count;
            public int remaining_points;
            public int hp;
            public int pp;
            public int atk;
            public int def;
            public int acc;
            public int eva;
            public int tec;
            public int mnd;
            public int sta;
            public int additionalTypeLevels;
        }

        public class paInfoType
        {
            public int count;
            public inventoryItemClass[] items = new inventoryItemClass[256];
        }

        public class infinityMissionClass : IComparable
        {
            public bool used;
            public int id;
            public string hex;
            public string createdBy;
            public int enemy_1;
            public int enemy_2;
            public int enemy_level;
            public int unk_enemy_level_mod;
            public int boss;
            public int length;
            public int unk_enemy_1_mod;
            public int area;
            public int special;
            public int element;
            public int level;
            public int enemy_table_1;
            public bool unk_enemy_table_1_mod;
            public int unk_table_2_mod;
            public int unk_table_2_unk_mod;
            public int area_1_map;
            public int area_2_map;
            public int area_3_map;
            public int mergePoints;
            public int clearCount_c;
            public int clearCount_b;
            public int clearCount_a;
            public int clearCount_s;
            public int clearCount_inf;

            public int CompareTo(object obj) => obj is infinityMissionClass ? this.hex.CompareTo(((infinityMissionClass)obj).hex) : throw new ArgumentException("Object is not of type infinityMissionClass.");
        }

        public class infinityMissionSlotsClass
        {
            public int itemsUsed;
            public infinityMissionClass[] slot = new infinityMissionClass[100];
        }

        public class saveDataType
        {
            public SaveType type;
            public saveSlotType[] slot = new saveSlotType[8];
            public int size;
            public inventorySharedClass sharedInventory = new inventorySharedClass();
            public infinityMissionSlotsClass infinityMissions = new infinityMissionSlotsClass();
            public long sharedMeseta;

            public void set_type(SaveType new_type) => this.type = new_type;
        }

        public enum saveInfoDataType
        {
            str,
            hex,
        }

        public enum elementType
        {
            Neutral,
            Fire,
            Ice,
            Thunder,
            Earth,
            Light,
            Dark,
            COUNT,
        }

        public enum itemType
        {
            nothing,
            Weapon,
            Armor,
            Green_Item,
            PA_Disk_Melee,
            PA_Disk_Ranged,
            PA_Disk_Technique,
            Infinity_Code,
            Slot_Unit,
            Clothes_human,
            Clothes_android,
            Room_Decoration,
            Trap,
            unknown_5,
            My_Synth_Device,
            Extend_Code,
            free_slot,
        }

        public enum weaponType
        {
            nothing,
            sword,
            knuckle,
            spear,
            double_saber,
            axe,
            sabers,
            daggers,
            claws,
            saber,
            dagger,
            claw,
            whip,
            slicer,
            rifle,
            shotgun,
            longbow,
            grenade,
            laser,
            handguns,
            handgun,
            crossbow,
            card,
            machinegun,
            rod,
            wand,
            tmag,
            rmag,
            shield,
            armor,
        }

        public enum partsTypes
        {
            unknown_0,
            torso,
            legs,
            arms,
            unknown_4,
            unknown_5,
            set,
        }

        public enum clothesTypes
        {
            unknown_0,
            top,
            bottom,
            shoes,
            top_set,
            bottom_set,
            set,
        }

        public enum slotType
        {
            unit,
            mirage,
            suv,
            visual,
        }

        public enum itemRankType
        {
            c,
            b,
            a,
            s,
            unknown,
        }

        public enum itemExtendType
        {
            not_extended,
            extended,
            dlc_not_extended,
            dlc_extended,
            not_extended_cs1,
            not_extended_cs2,
            extended_cs1,
            extended_cs2,
            unknown,
        }

        public enum weaponManufacturerType
        {
            GRM,
            Yohmei,
            Tenora_Works,
            Kubara,
        }

        public enum clothesManufacturerType
        {
            Kubara,
            Roar,
            Cubic,
            Miyab,
        }

        public enum weaponStyleType
        {
            Melee,
            Ranged_long,
            Ranged_short,
            Tech,
        }

        public enum weaponHandType
        {
            both,
            right,
            left,
        }

        public enum greenItemType
        {
            monomate,
            dimate,
            trimate,
            star_atom,
            sol_atom,
            moon_atom,
            doll,
            shiftaride,
            debanride,
            calorie,
            item,
            none,
        }

        public enum abilityType
        {
            None,
            Burn,
            Poison,
            Infection,
            Silence,
            Shock,
            Freeze,
            Sleep,
            Stun,
            Confusion,
            Taunt,
            Incapacitate,
            Drain,
            Damage_reflect,
            HP_affects_pwr,
            AutoDamage,
            AutoDefend,
            AttackUp,
            AttackDown,
            DefenseUp,
            DefenseDown,
            Empow_none,
            Empow_fire,
            Empow_ice,
            Empow_lightning,
            Empow_earth,
            Empow_light,
            Empow_dark,
            Empow_healing,
        }

        public enum itemInfExtendType
        {
            not_extended,
            unknown_1,
            unknown_2,
            unknown_3,
            extended,
            unknown_5,
            unknown_6,
            unknown_7,
            not_extended_special,
            unknown_9,
            unknown_10,
            unknown_11,
            extended_special,
        }

        public enum equippedType
        {
            not_equipped,
            equipped,
            equipped_in_use,
        }

        public class inventoryItemClass : IComparable
        {
            public bool used;
            public int id;
            public itemType type;
            public string name;
            public string name_jp;
            public string desc;
            public string desc_jp;
            public string infinity_item;
            public string hex;
            public string hex_reversed;
            public abilityType ability;
            public string spcl_effect;
            public string spcl_effect_info;
            public itemInfExtendType inf_extended;
            public int grinds;
            public int extended;
            public bool locked;
            public int rarity;
            public elementType element;
            public int pa_level;
            public int percent;
            public weaponStyleType style;
            public weaponHandType hand;
            public clothesManufacturerType clothes_man;
            public int qty;
            public int qty_max;
            public int power_add;
            public int data_id;
            public int equipped_slot;
            public int equipped_now;
            public int power;
            public int acc;
            public string level;
            public int ext_power;
            public int ext_acc;
            public string ext_level;
            public int inf_ext_power;
            public int inf_ext_acc;
            public string inf_ext_level;
            public string special;
            public string special_level;
            public string ext_special_level;

            public int CompareTo(object obj) => obj is inventoryItemClass ? this.hex.CompareTo(((inventoryItemClass)obj).hex) : throw new ArgumentException("Object is not of type inventoryItemClass.");
        }

        public class inventoryClass
        {
            public int itemsUsed;
            public inventoryItemClass[] item = new inventoryItemClass[60];
        }

        public class inventorySharedClass
        {
            public int itemsUsed;
            public inventoryItemClass[] item = new inventoryItemClass[2000];
        }

        public static saveDataType saveData = new saveDataType();
        public static int[] savedata_decimal_array = new int[301352];
        public static int savedata_decimal_array_filled;
        public static int savedata_decimal_array_read_pos;
        public static int chunkPos;


    }
}
