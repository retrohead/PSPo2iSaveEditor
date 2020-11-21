namespace apPatcherApp
{
    using CSEncryptDecrypt;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class optionsInfo
    {
        private runFunctionsType run = new runFunctionsType();
        private optionsInfoClass info = new optionsInfoClass();
        private encryptRoutineType dbencryptor = new encryptRoutineType();

        public string getValue(string key)
        {
            if (this.info.item[0] == null)
            {
                this.load();
            }
            foreach (optionsInfoItemClass class2 in this.info.item)
            {
                if ((class2 != null) && (class2.key == key))
                {
                    return class2.val;
                }
            }
            return "";
        }

        public void load()
        {
            if (this.info.item[0] != null)
            {
                this.info.item[0] = null;
            }
            else
            {
                this.info = new optionsInfoClass();
            }
            if (System.IO.File.Exists("data/options.bin"))
            {
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                    FileStream fs = new FileStream("data/options.bin", FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                    {
                        int index = 0;
                        while (true)
                        {
                            string str2 = reader.ReadLine();
                            if (str2 == null)
                            {
                                reader.Close();
                                fs.Close();
                                break;
                            }
                            try
                            {
                                if (index < 20)
                                {
                                    string[] strArray = str2.Split(new char[] { '=' });
                                    this.info.item[index] = new optionsInfoItemClass();
                                    this.info.item[index].key = strArray[0];
                                    this.info.item[index].val = strArray[1];
                                    index++;
                                }
                            }
                            catch (Exception exception1)
                            {
                                MessageBox.Show(exception1.Message);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error reading options", "Options Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void save()
        {
            string str = "";
            str = !Program.form.disableCheckOnStartToolStripMenuItem.Checked ? (str + "disable_update=0\r\n") : (str + "disable_update=1\r\n");
            str = !Program.form.disableWebContentToolStripMenuItem.Checked ? (str + "disable_web=0\r\n") : (str + "disable_web=1\r\n");
            str = !Program.form.disableWebAlertContentToolStripMenuItem.Checked ? (str + "disable_webalert=0\r\n") : (str + "disable_webalert=1\r\n");
            str = !Program.form.autoDownloadToolStripMenuItem.Checked ? (str + "auto_info_dl=0\r\n") : (str + "auto_info_dl=1\r\n");
            str = !Program.form.enableUpdateAlertsToolStripMenuItem.Checked ? (str + "ap_update_check=0\r\n") : (str + "ap_update_check=1\r\n");
            str = !Program.form.uSRcheatToolStripMenuItem1.Checked ? (str + "cmp_usrcheat_update_check=0\r\n") : (str + "cmp_usrcheat_update_check=1\r\n");
            str = !Program.form.eDGEToolStripMenuItem.Checked ? (str + "cmp_edgecheat_update_check=0\r\n") : (str + "cmp_edgecheat_update_check=1\r\n");
            str = !Program.form.cycloDSToolStripMenuItem.Checked ? (str + "cmp_cyclocheat_update_check=0\r\n") : (str + "cmp_cyclocheat_update_check=1\r\n");
            str = !Program.form.rememberDSSceneInfoToolStripMenuItem.Checked ? (str + "disable_crc_db=1\r\n") : (str + "disable_crc_db=0\r\n");
            str = str + "active_collection_db=" + Program.form.collectiondb.activeDb.ToString() + "\r\n";
            str = Program.form.autoOpenBrowserToolStripMenuItem.Checked ? (str + "auto_open_collections=1\r\n") : (str + "auto_open_collections=0\r\n");
            if ((Program.form.emulatorConfigForm == null) || ((Program.form.emulatorConfigForm.txtFileLocEmu0.Text == "") && ((Program.form.emulatorConfigForm.txtFileLocEmu1.Text == "") && ((Program.form.emulatorConfigForm.txtFileLocEmu2.Text == "") && (Program.form.emulatorConfigForm.txtFileLocEndrypts.Text == "")))))
            {
                str = ((((str + "emu_0=" + Program.form.options.getValue("emu_0") + "\r\n") + "emu_1=" + Program.form.options.getValue("emu_1") + "\r\n") + "emu_2=" + Program.form.options.getValue("emu_2") + "\r\n") + "emu_default=" + Program.form.options.getValue("emu_default") + "\r\n") + "endrypts=" + Program.form.options.getValue("endrypts") + "\r\n";
            }
            else
            {
                str = ((str + "emu_0=" + Program.form.emulatorConfigForm.txtFileLocEmu0.Text + "\r\n") + "emu_1=" + Program.form.emulatorConfigForm.txtFileLocEmu1.Text + "\r\n") + "emu_2=" + Program.form.emulatorConfigForm.txtFileLocEmu2.Text + "\r\n";
                if (Program.form.emulatorConfigForm.radioDefault_0.Checked)
                {
                    str = str + "emu_default=" + Program.form.emulatorConfigForm.txtFileLocEmu0.Text + "\r\n";
                }
                else if (Program.form.emulatorConfigForm.radioDefault_1.Checked)
                {
                    str = str + "emu_default=" + Program.form.emulatorConfigForm.txtFileLocEmu1.Text + "\r\n";
                }
                else if (Program.form.emulatorConfigForm.radioDefault_2.Checked)
                {
                    str = str + "emu_default=" + Program.form.emulatorConfigForm.txtFileLocEmu2.Text + "\r\n";
                }
                str = str + "endrypts=" + Program.form.emulatorConfigForm.txtFileLocEndrypts.Text + "\r\n";
            }
            using (StreamWriter writer = new StreamWriter("data/temp/options.txt"))
            {
                writer.Write(str);
            }
            if (System.IO.File.Exists("data/temp/options.txt"))
            {
                System.IO.File.Delete("data/options.bin");
                string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                this.encryptor.EncryptFile("data/temp/options.txt", "data/options.bin", sKey, GCHandle.Alloc(sKey, GCHandleType.Pinned));
                System.IO.File.Delete("data/temp/options.txt");
            }
        }

        public encryptRoutineType encryptor
        {
            get => 
                this.dbencryptor;
            set => 
                this.dbencryptor = value;
        }

        public class optionsInfoClass
        {
            public optionsInfo.optionsInfoItemClass[] item = new optionsInfo.optionsInfoItemClass[30];
        }

        public class optionsInfoItemClass
        {
            public string key = "";
            public string val = "";
        }

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }
    }
}

