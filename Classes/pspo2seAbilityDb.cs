// Decompiled with JetBrains decompiler
// Type: pspo2seSaveEditorProgram.pspo2seAbilityDb
// Assembly: PSPo2 Save Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E91610F-7D39-4E7C-8F4B-E7C65114B315
// Assembly location: C:\Development\PSPo2 Save Editor v3.0 build 1004 pack\PSPo2 Save Editor.exe

using CSEncryptDecrypt;
using System;
using System.IO;
using System.Windows.Forms;

namespace pspo2seSaveEditorProgram
{
  public class pspo2seAbilityDb
  {
    private pspo2seAbilityDb.runFunctionsType run = new pspo2seAbilityDb.runFunctionsType();
    public int ability_db_filled;
    private bool shownCorruptCsv;
    private encryptRoutineType dbencryptor = new encryptRoutineType();
    public pspo2seAbilityDb.abilityDbClass ability_db = new pspo2seAbilityDb.abilityDbClass();

    public encryptRoutineType encryptor
    {
      get => this.dbencryptor;
      set => this.dbencryptor = value;
    }

    public pspo2seAbilityDb.abilityDb_AbilitiyClass findAbilityInDb(string hex)
    {
      pspo2seAbilityDb.abilityDb_AbilitiyClass abilityDbAbilitiyClass = new pspo2seAbilityDb.abilityDb_AbilitiyClass();
      for (int index = 0; index < this.ability_db_filled; ++index)
      {
        if (hex == this.ability_db.ability[index].hex)
          return this.ability_db.ability[index];
      }
      return abilityDbAbilitiyClass;
    }

    public void addAbilityToDb(string csvLine)
    {
      if (this.ability_db_filled >= 257)
      {
        int num1 = (int) MessageBox.Show("Fatal Error! Ability database is too large!");
      }
      string[] strArray = csvLine.Split('|');
      this.ability_db.ability[this.ability_db_filled] = new pspo2seAbilityDb.abilityDb_AbilitiyClass();
      this.ability_db.ability[this.ability_db_filled].hex = strArray[0];
      this.ability_db.ability[this.ability_db_filled].name_jp = strArray[1];
      this.ability_db.ability[this.ability_db_filled].name = strArray[2];
      this.ability_db.ability[this.ability_db_filled].desc = strArray[3];
      try
      {
        this.ability_db.ability[this.ability_db_filled].slots = int.Parse(strArray[4]);
        this.ability_db.ability[this.ability_db_filled].hu_lvl = int.Parse(strArray[5]);
        this.ability_db.ability[this.ability_db_filled].ra_lvl = int.Parse(strArray[6]);
        this.ability_db.ability[this.ability_db_filled].fo_lvl = int.Parse(strArray[7]);
        this.ability_db.ability[this.ability_db_filled].va_lvl = int.Parse(strArray[8]);
        this.ability_db.ability[this.ability_db_filled].slots_inf = int.Parse(strArray[9]);
        this.ability_db.ability[this.ability_db_filled].hu_lvl_inf = int.Parse(strArray[10]);
        this.ability_db.ability[this.ability_db_filled].ra_lvl_inf = int.Parse(strArray[11]);
        this.ability_db.ability[this.ability_db_filled].fo_lvl_inf = int.Parse(strArray[12]);
        this.ability_db.ability[this.ability_db_filled].va_lvl_inf = int.Parse(strArray[13]);
      }
      catch
      {
        if (!this.shownCorruptCsv)
        {
          int num2 = (int) MessageBox.Show("The ability database appears to need updating\r\nPlease update from the database menu\r\n\r\nInvalid format for one of the integers at row " + (object) this.ability_db_filled, "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          this.shownCorruptCsv = true;
        }
      }
      ++this.ability_db_filled;
    }

    public bool loadDatabase()
    {
      this.ability_db_filled = 0;
      try
      {
        string encryptionKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
        FileStream fs = new FileStream("data/databases/abilities.pspo2sedb", FileMode.Open, FileAccess.Read);
        using (StreamReader streamReader = new StreamReader((Stream) this.encryptor.createDecryptionReadStream(encryptionKey, fs)))
        {
          string csvLine;
          while ((csvLine = streamReader.ReadLine()) != null)
            this.addAbilityToDb(csvLine);
          streamReader.Close();
          fs.Close();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message + "\r\n\r\nPlease run a database update from the menu", "Ability Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      return true;
    }

    public class runFunctionsType
    {
      public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
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

    public class abilityDbClass
    {
      public pspo2seAbilityDb.abilityDb_AbilitiyClass[] ability = new pspo2seAbilityDb.abilityDb_AbilitiyClass[257];
    }
  }
}
