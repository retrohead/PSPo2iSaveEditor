// Decompiled with JetBrains decompiler
// Type: PSPo2i_Save_Editor.pspo2seSettings
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

namespace PSPo2i_Save_Editor
{
  public class pspo2seSettings
  {
    public const string APP_VERSION = "3.0 build 1008";
    public const int SAVE_SLOT_QTY = 8;
    public const int BUFFER_SIZE = 301352;
    public const int ITEM_DB_CSV_MAX_ROWS = 4000;
    public const int JOB_TYPE_QTY = 4;
    public const int WEAPON_TYPE_QTY = 28;
    public const int INVENTORY_SLOT_QTY = 60;
    public const int INFINITY_MISSION_SLOT_QTY = 100;
    public const int SHARED_INVENTORY_SLOT_QTY = 2000;
    public const int MAX_PA = 256;
    public const string DATA_FILE_FOLDER = "data/";
    public const int DOWNLOAD_CHUNK_SIZE = 1024;
    public const string APP_URL = "http://files-ds-scene.net/retrohead/pspo2se/";
    public const int ABILITY_DB_SIZE = 257;
    public const int SLOT_TYPE_INFO_POS = 300;
    public const string DB_ENCRYPTION_KEY = "3F0007003C00F2009D005200AF002C00";
    public const string DB_FILE_EXT = ".pspo2sedb";
    public const char DB_COLUMN_SEPERATOR = '|';
    public const string ITEM_DB_FILE = "items";
    public const string ABILITY_DB_FILE = "abilities";
    public const string EXP_LEVEL_DB_FILE = "explevel";
    public const string EXP_TYPE_DB_FILE = "exptype";
    public const string APP_NAME = "PSPo2 Save Editor";
    public const string APP_NAME_LEGIT = "PSPo2 Save Viewer";
    public pspo2SaveFile saveDataFile = new pspo2SaveFile();
  }
}
