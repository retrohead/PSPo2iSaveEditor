using FolderZipper;
using PSPo2i_Save_Editor;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using static PSPo2i_Save_Editor.MainWindow;

public class update
{
    private static MainWindow mainWindow;
    private static BackgroundWorker bgwrk;
    public static dynamic completeFunctionObj;
    public static completeDelegate completeFunctionDelegate;
    private static bool success = false;
    public class updateCSVInfo
    {
        public string fn;
        public string ver;
    }

    public delegate void completeDelegate(bool success);
    public static void checkForUpdates(MainWindow mainWin, dynamic _completeFunctionObj, completeDelegate _completeFunctionDelegate)
    {
        mainWindow = mainWin;
        completeFunctionObj = _completeFunctionObj;
        completeFunctionDelegate = _completeFunctionDelegate;
        success = false;

        if (bgwrk == null)
        {
            bgwrk = new BackgroundWorker();
            bgwrk.DoWork += bgwrk_DoWork;
            bgwrk.RunWorkerCompleted += bgwrk_RunWorkerCompleted;
        }
        mainWindow.enableForm(false);
        mainWindow.panelSmallProgress.Visibility = Visibility.Visible;
        mainWindow.updateProgressLabel("checking for updates");
        bgwrk.RunWorkerAsync();
    }

    private static void bgwrk_DoWork(object sender, DoWorkEventArgs e)
    {
        if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data"))
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\databases");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\temp");
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\weapon_images");
            mainWindow.firstInstall = true;
            pspo2Databases.databasesOk = false;
            int num = (int)MessageBox.Show("This is your first time running the application\r\nYou will need to update the databases\r\nbefore you can do anything.\r\n\r\nChoose databases from the top menu to update.", "First time use", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\keys"))
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\keys");
        if (!downloadRequiredFile("FolderZipper.dll", "The application will not start without this file.", 6144L))
        {
            int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButton.OK, MessageBoxImage.Hand);
            Application.Current.MainWindow.Close();
        }
        if (!downloadRequiredFile("ICSharpCode.SharpZipLib.dll", "The application will not start without this file.", 200704L))
        {
            int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButton.OK, MessageBoxImage.Hand);
            Application.Current.MainWindow.Close();
        }
        if (!downloadRequiredFile("pspo2se_updater.exe", "The application will not start without this file.", 6144L))
        {
            int num = (int)MessageBox.Show("The application will now close", "Application Closing", MessageBoxButton.OK, MessageBoxImage.Hand);
            Application.Current.MainWindow.Close();
        }
        downloadRequiredFile("SED.exe", "You cannot load encrypted save files without ", 51712L);
        pspo2Databases.encryptor = mainWindow.encryptor;

        if (!mainWindow.firstInstall)
        {
            pspo2Databases.load(mainWindow);
            checkAppUpdate(false);
            checkDatabaseUpdate(false);
            checkImagesUpdate(false);
        }
    }

    private static void bgwrk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        mainWindow.enableForm(true);
        mainWindow.panelSmallProgress.Visibility = Visibility.Hidden;
        completeFunctionObj.Dispatcher.BeginInvoke(completeFunctionDelegate, success);
    }
    private static bool downloadRequiredFile(string fn, string reason, long byteSize)
    {
        bool flag1 = true;
        bool flag2 = false;
        while (flag1)
        {
            if (!System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\" + fn))
            {
                if (MessageBox.Show(fn + " is a required file which is missing, corrupt or out of date.\n\nDo you want to download it now?\n\n" + reason, "Required File Missing or Corrupt", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + fn, "data/temp\\", fn))
                    {
                        if (System.IO.File.OpenRead("data/temp\\" + fn).Length != byteSize)
                        {
                            MessageBox.Show(fn + " which was downloaded appears to be corrupt, please try again!", "Download Failure", MessageBoxButton.OK, MessageBoxImage.Hand);
                        }
                        else
                        {
                            System.IO.File.Copy("data/temp\\" + fn, fn);
                            MessageBox.Show(fn + " downloaded successfully.", "Download Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            flag1 = false;
                            flag2 = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(fn + " failed to download, please check your internet connection\r\nor the site may be down!", "Download Failure", MessageBoxButton.OK, MessageBoxImage.Hand);
                    }
                    if (flag1 && MessageBox.Show("Do you want to retry the download now?", "Try Again?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        flag1 = false;
                }
                else
                    flag1 = false;
            }
            else if (Directory.GetCurrentDirectory() == Directory.GetCurrentDirectory().Replace("PSPo2 Save Editor\\bin\\Debug", ""))
            {
                FileStream fileStream = System.IO.File.OpenRead(Directory.GetCurrentDirectory() + "\\" + fn);
                long length = fileStream.Length;
                fileStream.Close();
                if (length != byteSize)
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\" + fn);
                }
                else
                {
                    flag1 = false;
                    flag2 = true;
                }
            }
            else
            {
                flag1 = false;
                flag2 = true;
            }
        }
        return flag2;
    }

    private static void checkDatabaseUpdate(bool download)
    {
        if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/databases/version.bin", "data/temp/", "Update Check"))
        {
            if (checkVersionTxt(download) && download)
                pspo2Databases.load(mainWindow);
        }
        else
        {
            MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }

    private static void checkImagesUpdate(bool download)
    {
        string progressTxt = "";
        string str1 = "image_pack_version.bin";
        if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str1, "data/temp/", "Update Check"))
        {
            try
            {
                using (StreamReader streamReader = new StreamReader((Stream)mainWindow.encryptor.createDecryptionReadStream(hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/temp/" + str1, FileMode.Open, FileAccess.Read))))
                {
                    string str2;
                    if ((str2 = streamReader.ReadLine()) != null)
                        progressTxt = str2;
                    streamReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "checkImagesUpdate failed to parse new info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            string str3 = "";
            try
            {
                using (StreamReader streamReader = new StreamReader((Stream)mainWindow.encryptor.createDecryptionReadStream(hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/" + str1, FileMode.Open, FileAccess.Read))))
                {
                    string str2;
                    if ((str2 = streamReader.ReadLine()) != null)
                        str3 = str2;
                    streamReader.Close();
                }
            }
            catch
            {
            }
            if (str3 != progressTxt)
            {
                if (download)
                {
                    switch (MessageBox.Show("There is a new version of the image pack available.\r\nDo you wish to update now?", "New Image Pack Available", MessageBoxButton.YesNo, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.Cancel:
                            break;
                        case MessageBoxResult.Yes:
                            if (!downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + progressTxt, "data/temp/", progressTxt))
                            {
                                //toolStripStatusLabel.Text = "Update Failed";
                                break;
                            }
                            //toolStripStatusLabel.Text = "Unzipping Images";
                            try
                            {
                                Directory.Delete("data/weapon_images/", true);
                            }
                            catch
                            {
                            }
                            ZipUtil.UnZipFiles("data/temp/" + progressTxt, "data/", "", true);
                            //toolStripStatusLabel.Text = "Cleaning Up";
                            System.IO.File.Delete("data/image_pack_version.bin");
                            System.IO.File.Move("data/temp/image_pack_version.bin", "data/image_pack_version.bin");
                            System.IO.File.Delete("data/temp/image_pack_version.bin");
                            //toolStripStatusLabel.Text = "Completed: Image Pack Update";
                            //loadImageFloaterImages();
                            MessageBox.Show("The image pack was updated successfully", "Image Pack Update Completed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            break;
                        case MessageBoxResult.No:
                            break;
                        default:
                            MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("There is a new version of the image pack available.\r\nChoose update from the the images menu to install the latest version", "New Image Pack Available", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                if (!mainWindow.firstboot)
                {
                    MessageBox.Show("The latest version of the image pack is already installed.", "Image pack is up to date", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
        else
        {
           MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Image Pack Update Failure", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }

    private static void checkAppUpdate(bool download)
    {
        string newVersion = "";
        string str1 = "latest_version.bin";
        if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str1, "data/temp/", "Update Check"))
        {
            try
            {
                using (StreamReader streamReader = new StreamReader((Stream)mainWindow.encryptor.createDecryptionReadStream(hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00"), new FileStream("data/temp/" + str1, FileMode.Open, FileAccess.Read))))
                {
                    string str2;
                    if ((str2 = streamReader.ReadLine()) != null)
                        newVersion = str2;
                    streamReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "checkAppUpdate failed to parse new info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if ("3.0 build 1008" != newVersion)
            {
                if (download)
                {
                    //updateViewer.formSetup(newVersion);
                    //switch (updateViewer.ShowDialog((IWin32Window)this))
                    //{
                    //    case MessageBoxResult.Cancel:
                    //        enableForm();
                    //        break;
                    //    case MessageBoxResult.Yes:
                    //        string str2 = !legitVersion() ? "PSPo2 Save Editor" : "PSPo2 Save Viewer";
                    //        if (!downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/" + str2 + " v" + newVersion + ".zip", "data/temp/", str2 + " v" + newVersion + ".zip", str2 + " new.zip"))
                    //        {
                    //            toolStripStatusLabel.Text = "Update Failed";
                    //            enableForm();
                    //            break;
                    //        }
                    //        ZipUtil.UnZipFiles("data/temp/" + str2 + " new.zip", "data/temp/", "", true);
                    //        System.IO.File.Delete("data/" + str1);
                    //        System.IO.File.Move("data/temp/" + str1, "data/" + str1);
                    //        System.IO.File.Delete("data/temp/" + str1);
                    //        Process.Start("pspo2se_updater.exe");
                    //        Application.Current.MainWindow.Close();
                    //        break;
                    //    case MessageBoxResult.No:
                    //        enableForm();
                    //        break;
                    //    default:
                    //        int num = (int)MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                    //        enableForm();
                    //        break;
                    //}
                }
                else
                {
                    int num1 = (int)MessageBox.Show("There is a new version of the application available.\r\nChoose update from the the file menu to install v" + newVersion, "New version available", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                if (!mainWindow.firstboot)
                {
                    int num2 = (int)MessageBox.Show("The latest version (" + newVersion + ") is already installed.", "Application is up to date", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
        else
        {
            MessageBox.Show("Update check failed, please check your internet connection\r\nor the site may be down!", "Update Failure", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }

    private static bool checkVersionTxt(bool download)
    {
        int index1 = 0;
        int index2 = 0;
        //toolStripStatusLabel.Text = "Checking Version";
        updateCSVInfo[] updateCsvInfoArray1 = new updateCSVInfo[20];
        try
        {
            string encryptionKey = hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
            FileStream fs = new FileStream("data/temp/version.bin", FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader((Stream)mainWindow.encryptor.createDecryptionReadStream(encryptionKey, fs)))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    string[] strArray = str.Split('|');
                    updateCsvInfoArray1[index1] = new updateCSVInfo();
                    updateCsvInfoArray1[index1].fn = strArray[0];
                    updateCsvInfoArray1[index1].ver = strArray[1];
                    ++index1;
                    if (index1 >= 20)
                        break;
                }
                streamReader.Close();
                fs.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("checkVersionTxt failed to load new info:\r\n " + ex.Message);
            //toolStripStatusLabel.Text = "Update Failed";
            return false;
        }
        updateCSVInfo[] updateCsvInfoArray2 = new updateCSVInfo[20];
        try
        {
            string encryptionKey = hexAndMathFunctions.convertHexToEncryptionKey("3F0007003C00F2009D005200AF002C00");
            FileStream fs = new FileStream("data/databases/version.bin", FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader((Stream)mainWindow.encryptor.createDecryptionReadStream(encryptionKey, fs)))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    string[] strArray = str.Split('|');
                    updateCsvInfoArray2[index2] = new updateCSVInfo();
                    updateCsvInfoArray2[index2].fn = strArray[0];
                    updateCsvInfoArray2[index2].ver = strArray[1];
                    ++index2;
                    if (index2 >= 20)
                        break;
                }
                streamReader.Close();
                fs.Close();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Substring(0, 19) != "Could not find file")
            {
                int num = (int)MessageBox.Show("checkVersionTxt failed to load cur info [" + (object)index2 + "/" + (object)20 + "]:\r\n " + ex.Message);
                //toolStripStatusLabel.Text = "Update Failed";
                return false;
            }
            for (int index3 = 0; index3 < 20; ++index3)
            {
                updateCsvInfoArray2[index3] = new updateCSVInfo();
                updateCsvInfoArray2[index3].ver = "0";
            }
            index2 = index1;
        }
        if (index1 > index2)
        {
            int num = (int)MessageBox.Show("The application seems to be out of date.\r\nThe latest database files are incompatible with this version\r\n\r\nPlease update the application first");
            //toolStripStatusLabel.Text = "Update Failed";
            return false;
        }
        string text = "";
        bool flag1 = false;
        bool flag2 = false;
        for (int index3 = 0; index3 < 20 && index3 < index1; ++index3)
        {
            if (updateCsvInfoArray2[index3].ver != updateCsvInfoArray1[index3].ver)
            {
                if (!flag2)
                {
                    if (download)
                    {
                        switch (MessageBox.Show("There are new database updates available.\r\nDo you wish to download them now?", "Updates Available", MessageBoxButton.YesNo, MessageBoxImage.Question))
                        {
                            case MessageBoxResult.Cancel:
                                return false;
                            case MessageBoxResult.Yes:
                                flag2 = true;
                                break;
                            case MessageBoxResult.No:
                                return false;
                            default:
                                int num1 = (int)MessageBox.Show("WTF!? Only yes/no buttons should be available!");
                                return false;
                        }
                    }
                    else
                    {
                        int num2 = (int)MessageBox.Show("There are new database updates available.\r\nChoose update from the database menu to install them", "Updates Available", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return false;
                    }
                }
                if (downloadFile("http://files-ds-scene.net/retrohead/pspo2se/releases/databases/" + updateCsvInfoArray1[index3].fn, "data/databases/", updateCsvInfoArray1[index3].fn))
                {
                    text = text + updateCsvInfoArray1[index3].fn + " [Updated to " + updateCsvInfoArray1[index3].ver + "]\r\n";
                    flag1 = true;
                }
                else
                {
                    //toolStripStatusLabel.Text = "Update Failed";
                    return false;
                }
            }
            else
                text = text + updateCsvInfoArray1[index3].fn + " [" + updateCsvInfoArray1[index3].ver + " Already Installed]\r\n";
        }
        if (flag1)
        {
            System.IO.File.Delete("data/databases/version.bin");
            System.IO.File.Move("data/temp/version.bin", "data/databases/version.bin");
        }
        if (!download)
            return true;
        //toolStripStatusLabel.Text = "Update Complete";
        MessageBox.Show(text, "Database Update Results", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        return true;
    }

    public static bool downloadFile(string url, string dirdest, string progressTxt, string saveas = "")
    {
        if (!mainWindow.allowDownload)
        {
            int num = (int)MessageBox.Show("Please wait for the current download to finish", "Download already in progress", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }
        mainWindow.allowDownload = false;
        mainWindow.downloadedData = new byte[512000];
        mainWindow.downloadedDataName = "";
        try
        {
            WebResponse response = WebRequest.Create(url).GetResponse();
            Stream responseStream = response.GetResponseStream();
            int contentLength = (int)response.ContentLength;
            //toolStripProgressBar.Maximum = contentLength;
            //toolStripProgressBar.Value = 0;
            for (int index = 3; index < url.Length; ++index)
            {
                if (url.Substring(url.Length - index, 1) == "/")
                {
                    mainWindow.downloadedDataName = url.Substring(url.Length - index + 1, url.Length - (url.Length - index) - 1);
                    break;
                }
            }
            MemoryStream memoryStream = new MemoryStream();
            byte[] buffer = new byte[1024];
            int count;
            do
            {
                count = responseStream.Read(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    //toolStripProgressBar.Value = toolStripProgressBar.Maximum;
                    //toolStripStatusLabel.Text = "Completed: " + progressTxt + " " + (object)run.hexAndMathFunction.getPercentage(toolStripProgressBar.Value, contentLength) + "%";

                    mainWindow.downloadedData = memoryStream.ToArray();
                    responseStream.Close();
                    memoryStream.Close();
                    break;
                }
                else
                    memoryStream.Write(buffer, 0, count);
            } while (true);
            //toolStripProgressBar.Value += count;
            //toolStripStatusLabel.Text = "Downloading: " + progressTxt + " " + (object)run.hexAndMathFunction.getPercentage(toolStripProgressBar.Value, contentLength) + "%";
            //Application.DoEvents();
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            mainWindow.allowDownload = true;
            return false;
        }
        if (saveas != "")
            mainWindow.downloadedDataName = saveas;
        FileStream fileStream = new FileStream(dirdest + mainWindow.downloadedDataName, FileMode.Create);
        fileStream.Write(mainWindow.downloadedData, 0, mainWindow.downloadedData.Length);
        fileStream.Close();
        mainWindow.allowDownload = true;
        return true;
    }
}