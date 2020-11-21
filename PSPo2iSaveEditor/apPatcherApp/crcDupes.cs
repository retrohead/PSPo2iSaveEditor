namespace apPatcherApp
{
    using CSEncryptDecrypt;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class crcDupes
    {
        private runFunctionsType run = new runFunctionsType();
        private encryptRoutineType dbencryptor = new encryptRoutineType();
        public crcDbType db = new crcDbType();

        public bool addCRCToDbItem(int i, string thecrc, romTypes type)
        {
            if (this.db.item[i] == null)
            {
                this.db.item[i] = new crcDbItemType();
            }
            if (this.db.item[i].filled >= 50)
            {
                return false;
            }
            for (int j = 0; j < this.db.item[i].filled; j++)
            {
                if (this.db.item[i].possible_crc[j].hash == thecrc)
                {
                    return false;
                }
            }
            if (this.db.item[i].possible_crc[this.db.item[i].filled] == null)
            {
                this.db.item[i].possible_crc[this.db.item[i].filled] = new possibleCrcType();
            }
            this.db.item[i].possible_crc[this.db.item[i].filled].hash = thecrc.ToUpper();
            this.db.item[i].possible_crc[this.db.item[i].filled].type = type;
            crcDbItemType type1 = this.db.item[i];
            type1.filled++;
            return true;
        }

        public int addNewFileCRCToDb(string cleancrc, string newfn, romTypes type, ProgressBar progress, Label status)
        {
            if (!this.db.active)
            {
                return -4;
            }
            if (this.db.filled >= 0x61a8)
            {
                return -2;
            }
            string thecrc = "";
            if (!Program.form.checkCrc32(newfn, progress, status))
            {
                return -5;
            }
            thecrc = Program.form.crchash;
            if ((thecrc == "") || (thecrc.Length != 8))
            {
                return -1;
            }
            int index = 0;
            while (true)
            {
                if (index < this.db.filled)
                {
                    if (this.db.item[index].clean_crc != cleancrc)
                    {
                        int num2 = 0;
                        while (true)
                        {
                            if (num2 >= this.db.item[index].filled)
                            {
                                index++;
                                break;
                            }
                            if (this.db.item[index].possible_crc[num2].hash == cleancrc)
                            {
                                switch (this.db.item[index].possible_crc[num2].type)
                                {
                                    case romTypes.apPatched:
                                        switch (type)
                                        {
                                            case romTypes.clean:
                                                type = romTypes.apPatched;
                                                break;

                                            case romTypes.apPatched:
                                                type = romTypes.apPatched;
                                                break;

                                            case romTypes.trimmed:
                                                type = romTypes.apAndTrim;
                                                break;

                                            case romTypes.apAndTrim:
                                                type = romTypes.apAndTrim;
                                                break;

                                            default:
                                                break;
                                        }
                                        break;

                                    case romTypes.trimmed:
                                        switch (type)
                                        {
                                            case romTypes.clean:
                                                type = romTypes.trimmed;
                                                break;

                                            case romTypes.apPatched:
                                                type = romTypes.apAndTrim;
                                                break;

                                            case romTypes.trimmed:
                                                type = romTypes.trimmed;
                                                break;

                                            case romTypes.apAndTrim:
                                                type = romTypes.apAndTrim;
                                                break;

                                            default:
                                                break;
                                        }
                                        break;

                                    case romTypes.apAndTrim:
                                        type = romTypes.apAndTrim;
                                        break;

                                    default:
                                        break;
                                }
                                return (this.addCRCToDbItem(index, thecrc, type) ? 1 : -3);
                            }
                            num2++;
                        }
                        continue;
                    }
                    if (!this.addCRCToDbItem(index, thecrc, type))
                    {
                        return -3;
                    }
                }
                if (!this.addCRCToDbItem(index, thecrc, type))
                {
                    return -3;
                }
                this.db.item[this.db.filled].clean_crc = cleancrc;
                this.db.filled++;
                return 1;
            }
        }

        public possibleCrcType crcToCleanCrc(string crc)
        {
            possibleCrcType type = new possibleCrcType();
            int index = 0;
            while (index < this.db.filled)
            {
                if (this.db.item[index].clean_crc.ToUpper() == crc.ToUpper())
                {
                    type.hash = crc.ToUpper();
                    type.type = romTypes.clean;
                    return type;
                }
                int num2 = 0;
                while (true)
                {
                    if (num2 >= this.db.item[index].filled)
                    {
                        index++;
                        break;
                    }
                    if (this.db.item[index].possible_crc[num2].hash.ToUpper() == crc.ToUpper())
                    {
                        type.hash = this.db.item[index].clean_crc.ToUpper();
                        type.type = this.db.item[index].possible_crc[num2].type;
                        return type;
                    }
                    num2++;
                }
            }
            return null;
        }

        public bool loadDb()
        {
            string path = "data/databases/crc_dupes.dscrcdb";
            if (System.IO.File.Exists(path))
            {
                this.db.filled = 0;
                string str2 = "";
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                    {
                        while (true)
                        {
                            str2 = reader.ReadLine();
                            if (str2 == null)
                            {
                                reader.Close();
                                fs.Close();
                                break;
                            }
                            try
                            {
                                char[] separator = new char[] { '|' };
                                string[] strArray = str2.Split(separator);
                                int num = 0;
                                foreach (string str4 in strArray)
                                {
                                    if ((num == 0) && (str4.Length == 8))
                                    {
                                        if (this.db.item[this.db.filled] == null)
                                        {
                                            this.db.item[this.db.filled] = new crcDbItemType();
                                        }
                                        this.db.item[this.db.filled].clean_crc = str4.ToUpper();
                                        this.db.item[this.db.filled].filled = 0;
                                        this.db.filled++;
                                    }
                                    else
                                    {
                                        if (num <= 0)
                                        {
                                            break;
                                        }
                                        if (str4.Length != 10)
                                        {
                                            break;
                                        }
                                        string[] strArray2 = str4.Split(new char[] { ',' });
                                        if (this.db.item[this.db.filled - 1].possible_crc[this.db.item[this.db.filled - 1].filled] == null)
                                        {
                                            this.db.item[this.db.filled - 1].possible_crc[this.db.item[this.db.filled - 1].filled] = new possibleCrcType();
                                        }
                                        this.db.item[this.db.filled - 1].possible_crc[this.db.item[this.db.filled - 1].filled].hash = strArray2[0].ToUpper();
                                        this.db.item[this.db.filled - 1].possible_crc[this.db.item[this.db.filled - 1].filled].type = (romTypes) int.Parse(strArray2[1]);
                                        crcDbItemType type1 = this.db.item[this.db.filled - 1];
                                        type1.filled++;
                                    }
                                    num++;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message + "\r\n" + str2 + "\r\nCRC Database is corrupt", "CRC Database Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        public void writeDb()
        {
            string path = "data/temp/crc_dupes.txt";
            string sOutputFilename = "data/databases/crc_dupes.dscrcdb";
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    string str3 = "";
                    int index = 0;
                    while (true)
                    {
                        if (index >= this.db.filled)
                        {
                            writer.Close();
                            string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                            this.encryptor.EncryptFile(path, sOutputFilename, sKey, GCHandle.Alloc(sKey, GCHandleType.Pinned));
                            System.IO.File.Delete(path);
                            break;
                        }
                        str3 = this.db.item[index].clean_crc + "|";
                        int num2 = 0;
                        while (true)
                        {
                            if (num2 >= this.db.item[index].filled)
                            {
                                writer.WriteLine(str3);
                                index++;
                                break;
                            }
                            object obj2 = str3;
                            object[] objArray = new object[] { obj2, this.db.item[index].possible_crc[num2].hash, ",", (int) this.db.item[index].possible_crc[num2].type, "|" };
                            str3 = string.Concat(objArray);
                            num2++;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to write the crc dupes database");
            }
        }

        public encryptRoutineType encryptor
        {
            get => 
                this.dbencryptor;
            set => 
                this.dbencryptor = value;
        }

        public class crcDbItemType
        {
            public int filled;
            public string clean_crc = "";
            public crcDupes.possibleCrcType[] possible_crc = new crcDupes.possibleCrcType[50];
        }

        public class crcDbType
        {
            public int filled;
            public bool active;
            public crcDupes.crcDbItemType[] item = new crcDupes.crcDbItemType[0x61a8];
        }

        public class possibleCrcType
        {
            public string hash = "";
            public crcDupes.romTypes type;
        }

        public enum romTypes
        {
            clean,
            apPatched,
            trimmed,
            apAndTrim,
            unknown
        }

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }
    }
}

