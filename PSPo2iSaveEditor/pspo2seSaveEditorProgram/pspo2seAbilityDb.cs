namespace PSPo2iSaveEditor
{
    using CSEncryptDecrypt;
    using System;
    using System.IO;
    using System.Windows.Forms;

    public class pspo2seAbilityDb
    {
        private runFunctionsType run = new runFunctionsType();
        public int ability_db_filled;
        private bool shownCorruptCsv;
        private encryptRoutineType dbencryptor = new encryptRoutineType();
        public abilityDbClass ability_db = new abilityDbClass();

        public void addAbilityToDb(string csvLine)
        {
            if (this.ability_db_filled >= 0x101)
            {
                MessageBox.Show("Fatal Error! Ability database is too large!");
            }
            string[] strArray = csvLine.Split(new char[] { '|' });
            this.ability_db.ability[this.ability_db_filled] = new abilityDb_AbilitiyClass();
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
                    MessageBox.Show("The ability database appears to need updating\r\nPlease update from the database menu\r\n\r\nInvalid format for one of the integers at row " + this.ability_db_filled, "Corrupt Database", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.shownCorruptCsv = true;
                }
            }
            this.ability_db_filled++;
        }

        public abilityDb_AbilitiyClass findAbilityInDb(string hex)
        {
            abilityDb_AbilitiyClass class2 = new abilityDb_AbilitiyClass();
            for (int i = 0; i < this.ability_db_filled; i++)
            {
                if (hex == this.ability_db.ability[i].hex)
                {
                    return this.ability_db.ability[i];
                }
            }
            return class2;
        }

        public bool loadDatabase()
        {
            this.ability_db_filled = 0;
            try
            {
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
                FileStream fs = new FileStream("data/databases/abilities.pspo2sedb", FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    while (true)
                    {
                        string csvLine = reader.ReadLine();
                        if (csvLine == null)
                        {
                            reader.Close();
                            fs.Close();
                            break;
                        }
                        this.addAbilityToDb(csvLine);
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message + "\r\n\r\nPlease run a database update from the menu", "Ability Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        public encryptRoutineType encryptor
        {
            get => 
                this.dbencryptor;
            set => 
                this.dbencryptor = value;
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
            public pspo2seAbilityDb.abilityDb_AbilitiyClass[] ability = new pspo2seAbilityDb.abilityDb_AbilitiyClass[0x101];
        }

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }
    }
}

