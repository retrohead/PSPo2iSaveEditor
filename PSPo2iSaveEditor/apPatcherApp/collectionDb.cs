namespace apPatcherApp
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class collectionDb
    {
        public collectionDbType[] db = new collectionDbType[100];
        public int dbsUsed;
        public int activeDb = -1;

        public int addItem(string loc, string crc, string gameId, bool copyNfo = false, bool favourite = false)
        {
            if (this.activeDb < 0)
            {
                MessageBox.Show("No collection database is activated");
                return -1;
            }
            if (this.db[this.activeDb].filled >= 0x61a8)
            {
                return -1;
            }
            for (int i = 0; i < this.db[this.activeDb].filled; i++)
            {
                if ((this.db[this.activeDb].item[i] != null) && (this.db[this.activeDb].item[i].crc == crc))
                {
                    return -2;
                }
            }
            if (this.db[this.activeDb].item[this.db[this.activeDb].filled] == null)
            {
                this.db[this.activeDb].item[this.db[this.activeDb].filled] = new collectionDbItemType();
            }
            this.db[this.activeDb].item[this.db[this.activeDb].filled].gameLoc = loc;
            this.db[this.activeDb].item[this.db[this.activeDb].filled].crc = crc;
            this.db[this.activeDb].item[this.db[this.activeDb].filled].gameCode = gameId;
            this.db[this.activeDb].item[this.db[this.activeDb].filled].delete = false;
            this.db[this.activeDb].item[this.db[this.activeDb].filled].favourite = favourite;
            if (copyNfo && System.IO.File.Exists("data/web/nfo/" + crc + ".nfo"))
            {
                string str = "";
                str = this.db[this.activeDb].item[this.db[this.activeDb].filled].gameLoc.Substring(0, this.db[this.activeDb].item[this.db[this.activeDb].filled].gameLoc.LastIndexOf("."));
                if (System.IO.File.Exists(str + ".nfo"))
                {
                    System.IO.File.Delete(str + ".nfo");
                }
                System.IO.File.Copy("data/web/nfo/" + crc + ".nfo", str + ".nfo");
            }
            collectionDbType type1 = this.db[this.activeDb];
            type1.filled++;
            return 1;
        }

        public int createDatabase(string fn, string root, string type, string romExt, bool n3dsRomNumPrefix)
        {
            if (this.dbsUsed >= 100)
            {
                return -1;
            }
            for (int i = 0; i < this.dbsUsed; i++)
            {
                if (this.db[i].fn == fn)
                {
                    return -2;
                }
            }
            if (this.db[this.dbsUsed] == null)
            {
                this.db[this.dbsUsed] = new collectionDbType();
            }
            this.db[this.dbsUsed].fn = fn;
            this.db[this.dbsUsed].root = root;
            this.db[this.dbsUsed].type = type;
            this.db[this.dbsUsed].romExt = romExt;
            this.db[this.dbsUsed].filled = 0;
            this.db[this.dbsUsed].n3dsRomNumPrefix = n3dsRomNumPrefix;
            this.activeDb = this.dbsUsed;
            this.dbsUsed++;
            return 1;
        }

        public void deleteDatabase(string fn)
        {
            if (!System.IO.File.Exists("data/collections/" + fn + ".dsrcdb"))
            {
                MessageBox.Show("Fatal Error: The database file you attempted to delete was not found\n\ndata/collections/" + fn + ".dsrcdb");
            }
            else
            {
                System.IO.File.Delete("data/collections/" + fn + ".dsrcdb");
                int num = 0;
                for (int i = 0; i < this.dbsUsed; i++)
                {
                    if (this.db[i].fn == fn)
                    {
                        num = 1;
                    }
                    this.db[i] = this.db[i + num];
                }
                this.dbsUsed -= num;
                this.activeDb = -1;
                this.saveIndex();
                MessageBox.Show("The collection database was deleted successfully\n\n" + fn, "Collection Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void deleteItem(int i)
        {
            this.db[this.activeDb].item[i].delete = true;
        }

        public int deleteMissingItems()
        {
            int num = 0;
            for (int i = 0; i < this.db[this.activeDb].filled; i++)
            {
                if ((this.db[this.activeDb].item[i] != null) && (!this.db[this.activeDb].item[i].delete && !System.IO.File.Exists(this.db[this.activeDb].item[i].gameLoc)))
                {
                    this.deleteItem(i);
                    num++;
                }
            }
            return num;
        }

        public bool inCollection(string loc)
        {
            for (int i = 0; i < this.db[this.activeDb].filled; i++)
            {
                if ((this.db[this.activeDb].item[i] != null) && (this.db[this.activeDb].item[i].gameLoc == loc))
                {
                    return true;
                }
            }
            return false;
        }

        public void load()
        {
            int activeDb = this.activeDb;
            this.dbsUsed = 0;
            this.loadIndex();
            int index = 0;
            while (true)
            {
                if (index >= this.dbsUsed)
                {
                    if ((Program.form.collectionForm != null) && Program.form.collectionForm.refreshNfos)
                    {
                        Program.form.collectionForm.refreshNfos = false;
                    }
                    this.activeDb = activeDb;
                    return;
                }
                this.activeDb = index;
                this.db[this.activeDb].filled = 0;
                string path = "data/collections/" + this.db[index].fn + ".dsrcdb";
                if (!System.IO.File.Exists(path))
                {
                    this.activeDb = activeDb;
                    return;
                }
                string sKey = Program.form.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(Program.form.encryptor.createDecryptionReadStream(sKey, fs)))
                {
                    while (true)
                    {
                        string str3 = reader.ReadLine();
                        if (str3 == null)
                        {
                            reader.Close();
                            break;
                        }
                        try
                        {
                            char[] separator = new char[] { '|' };
                            string[] strArray = str3.Split(separator);
                            if (strArray[0] != "")
                            {
                                if ((Program.form.collectionForm == null) || !Program.form.collectionForm.refreshNfos)
                                {
                                    try
                                    {
                                        this.addItem(strArray[0], strArray[1], strArray[2], false, bool.Parse(strArray[3]));
                                    }
                                    catch
                                    {
                                        this.addItem(strArray[0], strArray[1], strArray[2], false, false);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        this.addItem(strArray[0], strArray[1], strArray[2], true, bool.Parse(strArray[3]));
                                    }
                                    catch
                                    {
                                        this.addItem(strArray[0], strArray[1], strArray[2], true, false);
                                    }
                                }
                            }
                        }
                        catch (Exception exception1)
                        {
                            MessageBox.Show(exception1.Message);
                        }
                    }
                    fs.Close();
                    index++;
                    continue;
                }
            }
        }

        private void loadIndex()
        {
            this.dbsUsed = 0;
            string path = "data/collections/collection_index.dsrci";
            if (System.IO.File.Exists(path))
            {
                string sKey = Program.form.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                using (StreamReader reader = new StreamReader(Program.form.encryptor.createDecryptionReadStream(sKey, new FileStream(path, FileMode.Open, FileAccess.Read))))
                {
                    string str3;
                    while ((str3 = reader.ReadLine()) != null)
                    {
                        try
                        {
                            char[] separator = new char[] { '|' };
                            string[] strArray = str3.Split(separator);
                            int num = 0;
                            string[] strArray2 = strArray;
                            int index = 0;
                            while (true)
                            {
                                if (index >= strArray2.Length)
                                {
                                    if (num <= 4)
                                    {
                                        this.createDatabase(strArray[0], strArray[1], strArray[2], strArray[3], true);
                                    }
                                    else
                                    {
                                        this.createDatabase(strArray[0], strArray[1], strArray[2], strArray[3], bool.Parse(strArray[4]));
                                    }
                                    break;
                                }
                                string text1 = strArray2[index];
                                num++;
                                index++;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        public int removeMarkedItems()
        {
            int num = 0;
            for (int i = 0; i < this.db[this.activeDb].filled; i++)
            {
                if ((this.db[this.activeDb].item[i] != null) && this.db[this.activeDb].item[i].delete)
                {
                    num++;
                }
                else
                {
                    this.db[this.activeDb].item[i - num] = this.db[this.activeDb].item[i];
                }
            }
            collectionDbType type1 = this.db[this.activeDb];
            type1.filled -= num;
            this.saveDb(this.activeDb);
            return num;
        }

        public void saveAll()
        {
            this.saveIndex();
            for (int i = 0; i < this.dbsUsed; i++)
            {
                if (this.db[i].filled > 0)
                {
                    this.saveDb(i);
                }
            }
        }

        public void saveDb(int i)
        {
            using (StreamWriter writer = new StreamWriter("data/temp/" + this.db[i].fn + ".txt"))
            {
                int index = 0;
                while (true)
                {
                    if (index >= this.db[i].filled)
                    {
                        writer.Close();
                        string sKey = Program.form.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                        Program.form.encryptor.EncryptFile("data/temp/" + this.db[i].fn + ".txt", "data/collections/" + this.db[i].fn + ".dsrcdb", sKey, GCHandle.Alloc(sKey, GCHandleType.Pinned));
                        System.IO.File.Delete("data/temp/" + this.db[i].fn + ".txt");
                        break;
                    }
                    if ((this.db[i].item[index] != null) && (this.db[i].item[index].gameLoc != ""))
                    {
                        writer.WriteLine(string.Concat(new object[] { this.db[i].item[index].gameLoc, "|", this.db[i].item[index].crc, "|_unused|", this.db[i].item[index].favourite }));
                    }
                    index++;
                }
            }
        }

        public void saveIndex()
        {
            using (StreamWriter writer = new StreamWriter("data/temp/collection_index.txt"))
            {
                int index = 0;
                while (true)
                {
                    if (index >= this.dbsUsed)
                    {
                        writer.Close();
                        break;
                    }
                    if (this.db[index].filled > 0)
                    {
                        writer.WriteLine(string.Concat(new object[] { this.db[index].fn, "|", this.db[index].root, "|", this.db[index].type, "|", this.db[index].romExt, "|", this.db[index].n3dsRomNumPrefix }));
                    }
                    index++;
                }
            }
            string sKey = Program.form.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
            Program.form.encryptor.EncryptFile("data/temp/collection_index.txt", "data/collections/collection_index.dsrci", sKey, GCHandle.Alloc(sKey, GCHandleType.Pinned));
            System.IO.File.Delete("data/temp/collection_index.txt");
        }

        public bool selectDatabase(string fn)
        {
            for (int i = 0; i < this.dbsUsed; i++)
            {
                if (this.db[i].fn == fn)
                {
                    this.activeDb = i;
                    return true;
                }
            }
            return false;
        }

        public class collectionDbItemType
        {
            public string gameLoc = "";
            public string crc = "";
            public string gameCode = "";
            public bool favourite;
            public webInfo.webInfoClass web = new webInfo.webInfoClass();
            public bool delete;
        }

        public class collectionDbType
        {
            public string fn = "";
            public string root = "";
            public string type = "";
            public string romExt = "";
            public int filled;
            public bool n3dsRomNumPrefix = true;
            public collectionDb.collectionDbItemType[] item = new collectionDb.collectionDbItemType[0x61a8];
        }
    }
}

