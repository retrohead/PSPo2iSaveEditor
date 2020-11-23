using CSEncryptDecrypt;
using PSPo2i_Save_Editor;
using System;
using System.IO;
using System.Windows;

public class pspo2Databases
{
    private static MainWindow mainWindow;
    public static bool databasesOk = true;
    public static encryptRoutineType dbencryptor = new encryptRoutineType();
    public static encryptRoutineType encryptor
    {
        get => dbencryptor;
        set => dbencryptor = value;
    }
    public static void load(MainWindow mainWin)
    {
        mainWindow = mainWin;
        databasesOk = true;
        itemDatbase.loadItemDatabase();
        if (!pspo2seAbilityDb.loadDatabase())
            databasesOk = false;
        loadExpLevelDatabase();
        loadExpTypeDatabase();
        if (pspo2SaveFile.saveData.type == pspo2SaveFile.SaveType.NONE)
            return;
        mainWindow.reloadEverything();
    }
    #region Items
    public class itemDatbase
    {
        public class itemDb_ItemClass
        {
            public string id;
            public string hex;
            public string name;
            public string name_jp;
            public string desc;
            public string desc_jp;
            public string infinity_item;
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
            public int rarity;
        }
        public static int item_db_filled;
        public static itemDb_ItemClass[] items = new itemDb_ItemClass[4000];
        public static void loadItemDatabase()
        {
            item_db_filled = 0;
            try
            {
                string encryptionKey = hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/items.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(encryptionKey, fs)))
                {
                    string csvLine;
                    while ((csvLine = streamReader.ReadLine()) != null)
                        addItemToDb(csvLine);
                    streamReader.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                databasesOk = false;
                int num = (int)MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Item Database Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        public static void addItemToDb(string csvLine)
        {
            string[] strArray = csvLine.Split('|');
            items[item_db_filled] = new itemDb_ItemClass();
            items[item_db_filled].id = strArray[0];
            items[item_db_filled].hex = strArray[1];
            items[item_db_filled].name = strArray[2];
            items[item_db_filled].name_jp = strArray[3];
            items[item_db_filled].desc = strArray[4];
            items[item_db_filled].desc_jp = strArray[5];
            items[item_db_filled].infinity_item = strArray[6];
            try
            {
                items[item_db_filled].power = int.Parse(strArray[7]);
            }
            catch
            {
                databasesOk = false;
                int num = (int)MessageBox.Show("row 7 [" + (object)item_db_filled + "] incorrect format " + strArray[7]);
            }
            try
            {
                items[item_db_filled].acc = int.Parse(strArray[8]);
            }
            catch
            {
                databasesOk = false;
                int num = (int)MessageBox.Show("row 8 [" + (object)item_db_filled + "] incorrect format " + strArray[8]);
            }
            items[item_db_filled].level = strArray[9];
            try
            {
                items[item_db_filled].ext_power = int.Parse(strArray[10]);
            }
            catch
            {
                databasesOk = false;
                int num = (int)MessageBox.Show("row 10 [" + (object)item_db_filled + "] incorrect format " + strArray[10]);
            }
            try
            {
                items[item_db_filled].ext_acc = int.Parse(strArray[11]);
            }
            catch
            {
                databasesOk = false;
                int num = (int)MessageBox.Show("row 11 [" + (object)item_db_filled + "] incorrect format " + strArray[11]);
            }
            items[item_db_filled].ext_level = strArray[12];
            try
            {
                items[item_db_filled].inf_ext_power = int.Parse(strArray[13]);
            }
            catch
            {
                databasesOk = false;
                int num = (int)MessageBox.Show("row 13 [" + (object)item_db_filled + "] incorrect format " + strArray[13]);
            }
            try
            {
                items[item_db_filled].inf_ext_acc = int.Parse(strArray[14]);
            }
            catch
            {
                databasesOk = false;
                int num = (int)MessageBox.Show("row 14 [" + (object)item_db_filled + "] incorrect format " + strArray[14]);
            }
            items[item_db_filled].inf_ext_level = strArray[15];
            items[item_db_filled].special = strArray[16];
            items[item_db_filled].special_level = strArray[17];
            items[item_db_filled].ext_special_level = strArray[18];
            if (items[item_db_filled].ext_special_level == "")
                items[item_db_filled].ext_special_level = items[item_db_filled].special_level;
            if (items[item_db_filled].ext_special_level == "0")
                items[item_db_filled].ext_special_level = "";
            if (items[item_db_filled].special_level == "0")
                items[item_db_filled].special_level = "";
            try
            {
                items[item_db_filled].rarity = int.Parse(strArray[19]);
            }
            catch
            {
                databasesOk = false;
                int num = (int)MessageBox.Show("row 19 [" + (object)item_db_filled + "] incorrect format " + strArray[19]);
            }
            ++item_db_filled;
        }
    }
    #endregion

    #region EXP database
    public class expDb_ItemClass
    {
        public int level;
        public int exp;
        public int exp_next;
        public int extend_points;
    }

    public class expDbType
    {
        public expDb_ItemClass[] level = new expDb_ItemClass[355];
    }
    public static int exp_db_filled;
    private static bool shownCorruptExpCsv;
    public static expDbType exp_db = new expDbType();
    public static expDb_ItemClass findExpLevelInfoInDb(int level)
    {
        if (level - 1 < exp_db_filled)
            return exp_db.level[level - 1];
        int num = (int)MessageBox.Show("Fatal error. Trying to exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Hand);
        return (expDb_ItemClass)null;
    }
    public static void addExpLevelInfoToDb(string csvLine)
    {
        if (exp_db_filled >= 355)
        {
            int num1 = (int)MessageBox.Show("Fatal Error! ExpLevel Database is too large!");
        }
        string[] strArray = csvLine.Split('|');
        exp_db.level[exp_db_filled] = new expDb_ItemClass();
        try
        {
            exp_db.level[exp_db_filled].level = int.Parse(strArray[0]);
            exp_db.level[exp_db_filled].exp = int.Parse(strArray[1]);
            exp_db.level[exp_db_filled].exp_next = int.Parse(strArray[2]);
            ++exp_db_filled;
        }
        catch
        {
            if (shownCorruptExpCsv)
                return;
            int num2 = (int)MessageBox.Show("The ExpLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButton.OK, MessageBoxImage.Hand);
            shownCorruptExpCsv = true;
            databasesOk = false;
        }
    }

    public static void loadExpLevelDatabase()
    {
        exp_db_filled = 0;
        try
        {
            string encryptionKey = hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
            FileStream fs = new FileStream("data/databases/explevel.pspo2sedb", FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(encryptionKey, fs)))
            {
                string csvLine;
                while ((csvLine = streamReader.ReadLine()) != null)
                    addExpLevelInfoToDb(csvLine);
                streamReader.Close();
                fs.Close();
            }
        }
        catch (Exception ex)
        {
            databasesOk = false;
            int num = (int)MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Level Database Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }

    public static expDb_ItemClass findExpTypeInfoInDb(int level)
    {
        if (level < type_db_filled)
            return typeexp_db.level[level];
        int num = (int)MessageBox.Show("Fatal error. Trying to get type exp info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Hand);
        return (expDb_ItemClass)null;
    }

    public static expDb_ItemClass findRebirthBpInfoInDb(int level)
    {
        if (level - 50 + 200 < exp_db_filled)
            return exp_db.level[level - 50 + 200];
        int num = (int)MessageBox.Show("Fatal error. Trying to get rebirth info not in the database.\n\nPlease update your databases from the menu.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Hand);
        return (expDb_ItemClass)null;
    }

    #endregion
    #region Type EXP database

        public class typeexpDbType
        {
            public expDb_ItemClass[] level = new expDb_ItemClass[55];
        }
    public static int type_db_filled;
    private static bool shownCorruptExpTypeCsv;
    public static typeexpDbType typeexp_db = new typeexpDbType();

    public static void addExpTypeInfoToDb(string csvLine)
    {
        if (type_db_filled >= 55)
        {
            int num1 = (int)MessageBox.Show("Fatal Error! ExpTypeLevel Database is too large!");
        }
        string[] strArray = csvLine.Split('|');
        typeexp_db.level[type_db_filled] = new expDb_ItemClass();
        try
        {
            typeexp_db.level[type_db_filled].level = int.Parse(strArray[0]);
            typeexp_db.level[type_db_filled].exp = int.Parse(strArray[1]);
            typeexp_db.level[type_db_filled].exp_next = int.Parse(strArray[2]);
            typeexp_db.level[type_db_filled].extend_points = int.Parse(strArray[3]);
        }
        catch
        {
            if (!shownCorruptExpTypeCsv)
            {
                int num2 = (int)MessageBox.Show("The ExpTypeLevel Database appears to need updating\r\nPlease update from the database menu", "Corrupt Database", MessageBoxButton.OK, MessageBoxImage.Hand);
                shownCorruptExpTypeCsv = true;
                databasesOk = false;
            }
        }
        ++type_db_filled;
    }

    public static void loadExpTypeDatabase()
    {
        type_db_filled = 0;
        try
        {
            string encryptionKey = hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
            FileStream fs = new FileStream("data/databases/exptype.pspo2sedb", FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader((Stream)encryptor.createDecryptionReadStream(encryptionKey, fs)))
            {
                string csvLine;
                while ((csvLine = streamReader.ReadLine()) != null)
                    addExpTypeInfoToDb(csvLine);
                streamReader.Close();
                fs.Close();
            }
        }
        catch (Exception ex)
        {
            databasesOk = false;
            int num = (int)MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Exp Type Database Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
    #endregion
    #region Abilities
  public class pspo2seAbilityDb
  {
    public static int ability_db_filled;
    private static  bool shownCorruptCsv;

    public static abilityDb_AbilitiyClass findAbilityInDb(string hex)
    {
      for (int index = 0; index < ability_db_filled; ++index)
      {
        if (hex == ability[index].hex)
          return ability[index];
      }
      return null;
    }

    public static void addAbilityToDb(string csvLine)
    {
      if (ability_db_filled >= 257)
      {
        int num1 = (int) MessageBox.Show("Fatal Error! Ability database is too large!");
      }
      string[] strArray = csvLine.Split('|');
      ability[ability_db_filled] = new pspo2seAbilityDb.abilityDb_AbilitiyClass();
      ability[ability_db_filled].hex = strArray[0];
      ability[ability_db_filled].name_jp = strArray[1];
      ability[ability_db_filled].name = strArray[2];
      ability[ability_db_filled].desc = strArray[3];
      try
      {
        ability[ability_db_filled].slots = int.Parse(strArray[4]);
        ability[ability_db_filled].hu_lvl = int.Parse(strArray[5]);
        ability[ability_db_filled].ra_lvl = int.Parse(strArray[6]);
        ability[ability_db_filled].fo_lvl = int.Parse(strArray[7]);
        ability[ability_db_filled].va_lvl = int.Parse(strArray[8]);
        ability[ability_db_filled].slots_inf = int.Parse(strArray[9]);
        ability[ability_db_filled].hu_lvl_inf = int.Parse(strArray[10]);
        ability[ability_db_filled].ra_lvl_inf = int.Parse(strArray[11]);
        ability[ability_db_filled].fo_lvl_inf = int.Parse(strArray[12]);
        ability[ability_db_filled].va_lvl_inf = int.Parse(strArray[13]);
      }
      catch
      {
        if (!shownCorruptCsv)
        {
          int num2 = (int) MessageBox.Show("The ability database appears to need updating\r\nPlease update from the database menu\r\n\r\nInvalid format for one of the integers at row " + ability_db_filled, "Corrupt Database", MessageBoxButton.OK, MessageBoxImage.Hand);
          shownCorruptCsv = true;
        }
      }
      ++ability_db_filled;
    }

    public static bool loadDatabase()
    {
      ability_db_filled = 0;
      try
      {
        string encryptionKey = hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
        FileStream fs = new FileStream("data/databases/abilities.pspo2sedb", FileMode.Open, FileAccess.Read);
        using (StreamReader streamReader = new StreamReader((Stream) encryptor.createDecryptionReadStream(encryptionKey, fs)))
        {
          string csvLine;
          while ((csvLine = streamReader.ReadLine()) != null)
            addAbilityToDb(csvLine);
          streamReader.Close();
          fs.Close();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Ability Database Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        return false;
      }
      return true;
    }

    public class abilityDb_AbilitiyClass
    {
      public string hex;
      public string name_jp;
      public string name;
      public string desc;
      public int slots;
      public int hu_lvl;
      public int ra_lvl;
      public int fo_lvl;
      public int va_lvl;
      public int slots_inf;
      public int hu_lvl_inf;
      public int ra_lvl_inf;
      public int fo_lvl_inf;
      public int va_lvl_inf;
    }

      public static abilityDb_AbilitiyClass[] ability = new abilityDb_AbilitiyClass[257];
  }
#endregion
}
