namespace apPatcherApp
{
    using CSEncryptDecrypt;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class webInfo
    {
        private runFunctionsType run = new runFunctionsType();
        private encryptRoutineType dbencryptor = new encryptRoutineType();
        public webInfoClass info = new webInfoClass();

        public bool downloadRomInfo(string hash, ProgressBar progress, Label status)
        {
            bool flag;
            try
            {
                if (System.IO.File.Exists("data/web/info/" + hash + "_info.dsapdb"))
                {
                    System.IO.File.Delete("data/web/info/" + hash + "_info.dsapdb");
                }
                string url = "http://www.ds-scene.net/romtool.php?version=2&hash=" + hash;
                if (Program.form.downloadFile(url, "data/temp/", "Contacting DS-Scene.net", hash + "_info.raw", progress, status) && System.IO.File.Exists("data/temp/" + hash + "_info.raw"))
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                    this.encryptor.EncryptFile("data/temp/" + hash + "_info.raw", "data/web/info/" + hash + "_info.dsapdb", sKey, GCHandle.Alloc(sKey, GCHandleType.Pinned));
                    System.IO.File.Delete("data/temp/" + hash + "_info.raw");
                    webInfoClass class2 = this.parseWebInfo(hash);
                    if (class2 == null)
                    {
                        System.IO.File.Delete("data/web/info/" + hash + "_info.dsapdb");
                        flag = false;
                    }
                    else if (class2.item[0].key == "error:bad hash")
                    {
                        MessageBox.Show("Bad Hash Detected! " + hash);
                        flag = false;
                    }
                    else if (class2.item[0].key == "error:hash not found")
                    {
                        flag = false;
                    }
                    else
                    {
                        webInfoItemClass[] item = class2.item;
                        int index = 0;
                        while (true)
                        {
                            if (index >= item.Length)
                            {
                                flag = true;
                                break;
                            }
                            webInfoItemClass class3 = item[index];
                            if (class3 != null)
                            {
                                if ((class3.key == "boxart") && (class3.val != ""))
                                {
                                    if (System.IO.File.Exists("data/web/images/" + hash + ".jpg"))
                                    {
                                        System.IO.File.Delete("data/web/images/" + hash + ".jpg");
                                    }
                                    Program.form.downloadFile(class3.val, "data/web/images/", "Downloading Boxart", hash + ".jpg", progress, status);
                                }
                                if ((class3.key == "icon") && (class3.val != ""))
                                {
                                    if (System.IO.File.Exists("data/web/images/" + hash + ".png"))
                                    {
                                        System.IO.File.Delete("data/web/images/" + hash + ".png");
                                    }
                                    Program.form.downloadFile(class3.val, "data/web/images/", "Downloading Icon", hash + ".png", progress, status);
                                }
                                if ((class3.key == "nfolink") && (class3.val != ""))
                                {
                                    if (System.IO.File.Exists("data/web/nfo/" + hash + ".nfo"))
                                    {
                                        System.IO.File.Delete("data/web/nfo/" + hash + ".nfo");
                                    }
                                    Program.form.downloadFile(class3.val, "data/web/nfo/", "Downloading NFO", hash + ".nfo", progress, status);
                                }
                                if ((class3.key == "romrgn") && ((class3.val != "") && !System.IO.File.Exists("data/web/images/flag_" + class3.val + ".gif")))
                                {
                                    Program.form.downloadFile("http://www.ds-scene.net/data/images/icons/flags/" + class3.val + ".gif", "data/web/images/", "Download Flag", "flag_" + class3.val + ".gif", progress, status);
                                }
                            }
                            index++;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error occurred while trying to contact ds-scene.net\n\n" + exception.Message, "DS-Scene.net error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            return flag;
        }

        public webInfoClass parseWebInfo(string hash)
        {
            this.info = new webInfoClass();
            if (System.IO.File.Exists("data/web/info/" + hash + "_info.dsapdb"))
            {
                this.info.crcLoaded = hash;
                string str = "";
                FileStream fs = null;
                try
                {
                    string sKey = this.run.hexAndMathFunction.convertHexToEncryptionKey("790077003F0028003F0050003F003F00");
                    fs = new FileStream("data/web/info/" + hash + "_info.dsapdb", FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(this.encryptor.createDecryptionReadStream(sKey, fs)))
                    {
                        int index = 0;
                        while (true)
                        {
                            str = reader.ReadLine();
                            if (str == null)
                            {
                                reader.Close();
                                fs.Close();
                                break;
                            }
                            try
                            {
                                if (index < 20)
                                {
                                    string[] strArray = str.Split(new char[] { '>' });
                                    if (this.info.item[index] == null)
                                    {
                                        this.info.item[index] = new webInfoItemClass();
                                    }
                                    this.info.item[index].key = strArray[0].Replace("=", "");
                                    this.info.item[index].val = strArray[1];
                                    index++;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    webInfoClass class2;
                    this.info.crcLoaded = hash;
                    if (fs != null)
                    {
                        fs.Close();
                    }
                    while (true)
                    {
                        try
                        {
                            System.IO.File.Delete("data/web/info/" + hash + "_info.dsapdb");
                        }
                        catch
                        {
                            continue;
                        }
                        if (Program.form.organiseForm.checkBoxDownload.Checked && Program.form.organiseForm.cancelBatchBtn.Visible)
                        {
                            MessageBox.Show("re-download because in batch and corrupt file");
                            this.downloadRomInfo(hash, Program.form.organiseForm.progressBarStage, Program.form.organiseForm.stageProgressGrpLabel);
                        }
                        else if (Program.form.options.getValue("auto_info_dl") != "1")
                        {
                            MessageBox.Show(exception.Message + "\n\nPlease re-open the rom and click refresh on the DS-Scene tab\n\nInvalid DS-Scene Web Data", "DS-Scene File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("re-download because auto download and corrupt file");
                            this.downloadRomInfo(hash, Program.form.toolStripProgressBar, Program.form.toolStripStatusLabel);
                        }
                        class2 = null;
                        break;
                    }
                    return class2;
                }
            }
            return this.info;
        }

        public string replaceIllegalFilenameCharacters(string fn)
        {
            fn = Program.form.run.hexAndMathFunction.string_replace(":", " -", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace(";", " -", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace(",", "", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("?", "", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("[", "(", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("]", ")", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("<", "(", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace(">", ")", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("*", "", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("|", "", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("\"", "'", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace(@"\", "_", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("/", "_", fn);
            fn = Program.form.run.hexAndMathFunction.string_replace("+", " ", fn);
            return fn;
        }

        public bool validateWebInfo(string hash)
        {
            webInfoItemClass class3;
            crcDupes.possibleCrcType type = new crcDupes.possibleCrcType();
            type = Program.form.crcDb.crcToCleanCrc(hash.ToUpper());
            if ((type == null) || (type.hash == ""))
            {
                type = new crcDupes.possibleCrcType {
                    hash = hash.ToUpper()
                };
                Program.form.romHeader.romHeader.cleanCrc.type = crcDupes.romTypes.unknown;
            }
            webInfoClass class2 = Program.form.web.parseWebInfo(type.hash);
            if ((class2 == null) || (class2.item[0] == null))
            {
                return false;
            }
            webInfoItemClass[] item = class2.item;
            int index = 0;
            goto TR_0014;
        TR_0005:
            index++;
        TR_0014:
            while (true)
            {
                if (index >= item.Length)
                {
                    return true;
                }
                class3 = item[index];
                if (class3 != null)
                {
                    string key = class3.key;
                    if (key != null)
                    {
                        int num10;
                        if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x60000c1-1 == null)
                        {
                            Dictionary<string, int> dictionary1 = new Dictionary<string, int>(0x13);
                            dictionary1.Add("error:hash not found", 0);
                            dictionary1.Add("error:bad hash", 1);
                            dictionary1.Add("romnum", 2);
                            dictionary1.Add("romnam", 3);
                            dictionary1.Add("romgrp", 4);
                            dictionary1.Add("romsav", 5);
                            dictionary1.Add("romzip", 6);
                            dictionary1.Add("romdir", 7);
                            dictionary1.Add("id", 8);
                            dictionary1.Add("wifi", 9);
                            dictionary1.Add("boxart", 10);
                            dictionary1.Add("dscompat", 11);
                            dictionary1.Add("date", 12);
                            dictionary1.Add("newsdate", 13);
                            dictionary1.Add("romrgn", 14);
                            dictionary1.Add("nfolink", 15);
                            dictionary1.Add("icon", 0x10);
                            dictionary1.Add("n3dsopt", 0x11);
                            dictionary1.Add("romsize", 0x12);
                            <PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x60000c1-1 = dictionary1;
                        }
                        if (<PrivateImplementationDetails>{FB95DB71-1B24-43E3-93B5-75803B835BFA}.$$method0x60000c1-1.TryGetValue(key, out num10))
                        {
                            switch (num10)
                            {
                                case 0:
                                    System.IO.File.Delete("data/web/info/" + Program.form.romHeader.romHeader.cleanCrc.hash + "_info.dsapdb");
                                    return false;

                                case 1:
                                    System.IO.File.Delete("data/web/info/" + Program.form.romHeader.romHeader.cleanCrc.hash + "_info.dsapdb");
                                    return false;

                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                case 11:
                                case 13:
                                case 14:
                                case 15:
                                case 0x10:
                                case 0x11:
                                case 0x12:
                                    goto TR_0005;

                                case 12:
                                {
                                    DateTime utcNow = DateTime.UtcNow;
                                    DateTime time2 = new DateTime(int.Parse(class3.val.Substring(0, 4)), int.Parse(class3.val.Substring(4, 2)), int.Parse(class3.val.Substring(6, 2)), int.Parse(class3.val.Substring(8, 2)), int.Parse(class3.val.Substring(10, 2)), int.Parse(class3.val.Substring(12, 2)));
                                    string[] strArray = new string[] { utcNow.Year.ToString("D2"), utcNow.Month.ToString("D2"), utcNow.Day.ToString("D2"), utcNow.Hour.ToString("D2"), utcNow.Minute.ToString("D2"), utcNow.Second.ToString("D2") };
                                    string[] strArray2 = new string[] { time2.Year.ToString("D2"), time2.Month.ToString("D2"), time2.Day.ToString("D2"), time2.Hour.ToString("D2"), time2.Minute.ToString("D2"), time2.Second.ToString("D2") };
                                    if (long.Parse(string.Concat(strArray)) <= long.Parse(string.Concat(strArray2)))
                                    {
                                        if (time2.Subtract(utcNow).TotalMinutes > 0.0)
                                        {
                                            return true;
                                        }
                                    }
                                    else if (utcNow.Subtract(time2).TotalMinutes > 10080.0)
                                    {
                                        return false;
                                    }
                                    goto TR_0005;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                }
                goto TR_0005;
            }
            MessageBox.Show("Invalid web info: " + class3.key);
            return false;
        }

        public encryptRoutineType encryptor
        {
            get => 
                this.dbencryptor;
            set => 
                this.dbencryptor = value;
        }

        public class runFunctionsType
        {
            public hexAndMathFunctions hexAndMathFunction = new hexAndMathFunctions();
        }

        public class webInfoClass
        {
            public string crcLoaded = "";
            public webInfo.webInfoItemClass[] item = new webInfo.webInfoItemClass[20];
        }

        public class webInfoItemClass
        {
            public string key = "";
            public string val = "";
        }
    }
}

