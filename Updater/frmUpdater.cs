using System;
using System.IO;
using System.Net;
using System.Drawing;
using C1.C1Zip;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Globalization;

namespace Updater
{
    public partial class frmUpdater : Form
    {
        private WebClient wc;
        private string _ColorString = "#006CBA";
        private int _iDownloadProgressValue;
        private int _iDownloadStatus = -2; //-1=Continue, 0=Cancel, 1=OK
        private bool _bIs64 = IntPtr.Size == 8 ? true : false;

        public frmUpdater()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var sTemp = " is";
            rdoUpdatePreview.Enabled = _bIs64;

            SizeGripStyle = SizeGripStyle.Hide;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            LoadLocalizationXML(MyGlobal.sXmlFilename);

            InitialLabel();

            //Register MessageBoxManager
            var sLangText = MyGlobal.GetLanguageString("&OK", "Global", "Global", "messagebox", "OK", "Text");
            MessageBoxManager.OK = sLangText;
            sLangText = MyGlobal.GetLanguageString("&Cancel", "Global", "Global", "messagebox", "Cancel", "Text");
            MessageBoxManager.Cancel = sLangText;
            sLangText = MyGlobal.GetLanguageString("&Abort", "Global", "Global", "messagebox", "Abort", "Text");
            MessageBoxManager.Abort = sLangText;
            sLangText = MyGlobal.GetLanguageString("&Retry", "Global", "Global", "messagebox", "Retry", "Text");
            MessageBoxManager.Retry = sLangText;
            sLangText = MyGlobal.GetLanguageString("&Ignore", "Global", "Global", "messagebox", "Ignore", "Text");
            MessageBoxManager.Ignore = sLangText;
            sLangText = MyGlobal.GetLanguageString("&Yes", "Global", "Global", "messagebox", "Yes", "Text");
            MessageBoxManager.Yes = sLangText;
            sLangText = MyGlobal.GetLanguageString("&No", "Global", "Global", "messagebox", "No", "Text");
            MessageBoxManager.No = sLangText;
            MessageBoxManager.Register();

            try
            {
                //變更語系
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(MyGlobal.sLocalization);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(MyGlobal.sLocalization);
            }
            catch (Exception)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("english.xml");
            }

            var sNoneExistFileList = CheckFileExist();

            if (sNoneExistFileList != "")
            {
                if (sNoneExistFileList.Length - sNoneExistFileList.Replace("\r\n", "").Length == 2)
                {
                    sTemp = "s are"; //包含換行符號，表示有多個 dll 檔案找不到
                }

                sLangText = "The program can't start because the following file" + sTemp + " missing from your computer.\r\n\r\nTry reinstalling the program to fix this problem.";
                MessageBox.Show(sLangText + "\r\n\r\n" + sNoneExistFileList, @"Updater - System Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }

            picStep1.Image = picUnchecked.Image;
            picStep2.Image = picUnchecked.Image;
            picStep3.Image = picUnchecked.Image;
            picStep4.Image = picUnchecked.Image;

            txtFrom.Tag = Path.GetTempPath() + @"tmpJQUpdate.tmp\";
            lblFrom.Tag = DateTime.Now.ToString("yyyyMMdd") + @"\";
            txtFrom.Text = txtFrom.Tag + "" + lblFrom.Tag;
            txtFrom.ReadOnly = true;
            txtTo.Text = Application.StartupPath + @"\";
            txtTo.ReadOnly = true;
            
            MyGlobal.ApplyLanguageInfo(this, false);

            lblStep2.Tag = lblStep2.Text;
            lblStep3.Tag = lblStep3.Text;

            rdoUpdateProduction.Checked = true;

            CheckJasonQueryExecuted();

            tmrCheck.Enabled = true;
        }

        private static string CheckFileExist()
        {
            var sResult = "";

            if (File.Exists(Application.StartupPath + @"\JasonQuery.exe") == false)
            {
                sResult += "JasonQuery.exe\r\n";
            }
            if (File.Exists(Application.StartupPath + @"\C1.C1Zip.4.5.2.dll") == false)
            {
                sResult += "C1.C1Zip.4.5.2.dll\r\n";
            }
            if (File.Exists(Application.StartupPath + @"\C1.Win.4.5.2.dll") == false)
            {
                sResult += "C1.Win.4.5.2.dll\r\n";
            }
            if (File.Exists(Application.StartupPath + @"\C1.Win.C1Command.4.5.2.dll") == false)
            {
                sResult += "C1.Win.C1Command.4.5.2.dll\r\n";
            }
            if (File.Exists(Application.StartupPath + @"\C1.Win.C1Input.4.5.2.dll") == false)
            {
                sResult += "C1.Win.C1Input.4.5.2.dll\r\n";
            }
            if (File.Exists(Application.StartupPath + @"\C1.Win.C1Themes.4.5.2.dll") == false)
            {
                sResult += "C1.Win.C1Themes.4.5.2.dll\r\n";
            }
            
            return sResult;
        }

        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            CheckJasonQueryExecuted();
        }

        private string CheckJasonQueryExecuted()
        {
            var sList = "";

            try
            {
                sList = (from process in Process.GetProcesses() where process.ProcessName == "JasonQuery" let ss1 = process.MainModule.FileName where Path.GetDirectoryName(ss1) != "" select process).Aggregate("", (current, process) => current + process.MainWindowTitle + "\r\n");
            }
            catch (Exception ex)
            {
                //偵測 JasonQuery 64 bit 執行中，但 Updater.exe 是 32 bit
                sList = "JasonQuery x64 (" + ex.Message + ")\r\n";
            }

            txtList.ReadOnly = false;

            if (!string.IsNullOrEmpty(sList) && sList.Length >= 2)
            {
                sList = sList.Substring(0, sList.Length - 2);
                txtList.Text = sList;
            }
            else
            {
                txtList.Text = "";
            }

            txtList.ReadOnly = true;

            if (string.IsNullOrEmpty(sList))
            {
                picStep1.Image = picChecked.Image;
                lblStep1.ForeColor = ColorTranslator.FromHtml(_ColorString);
            }
            else
            {
                lblStep1.ForeColor = Color.FromArgb(192, 0, 0);
                picStep1.Image = picUnchecked.Image;
                lblStep1.ForeColor = Color.DarkRed;
            }

            return sList;
        }

        private static void LoadLocalizationXML(string sXmlFilename)
        {
            var sXmlFullFilename = Application.StartupPath + @"\localization\" + sXmlFilename;

            if (File.Exists(sXmlFullFilename))
            {
                MyGlobal.dtLocalization = MyGlobal.XmlToDataTable(sXmlFullFilename);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFile();
        }

        private void UpdateFile()
        {
            var bError = false;
            var sLangText = "";

            if (!string.IsNullOrEmpty(CheckJasonQueryExecuted()))
            {
                var sMsg = MyGlobal.GetLanguageString("Automatically close all executing JasonQuery?", "form", Name, "msg", "CloseJQAutomatically", "Text") + "\r\n\r\n";
                sMsg += MyGlobal.GetLanguageString("Please confirm whether you need to save or execute the \"Commit/Rollback\" command before pressing the \"Yes\" button!", "form", Name, "msg", "CloseJQAutomatically2", "Text");

                if (MessageBox.Show(sMsg, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    var processCollection = Process.GetProcesses();

                    foreach (Process p in processCollection)
                    {
                        if (p.ProcessName == "JasonQuery")
                        {
                            p.Kill();
                        }
                    }

                    txtList.Text = "";
                    picStep1.Image = picChecked.Image;
                    lblStep1.ForeColor = ColorTranslator.FromHtml(_ColorString);
                }
            }

            Cursor = Cursors.WaitCursor;
            tmrCheck.Enabled = false;

            const string sURL = "https://jasonquery.000webhostapp.com/JasonQuery/";
            var sRemoteFilename = "JasonQuery" + (_bIs64 ? "64" : "86") + ".zip";

            if (rdoUpdatePreview.Checked)
            {
                sRemoteFilename = "JasonQuery64Test.zip";
            }

            var sTargetFilename = "JasonQuery.zip";
            var sTargetFolder = txtFrom.Text;
            var sUpdaterExeHasNewVersion = "";

            MyGlobal.CheckAndCreateDirectory(sTargetFolder);

            _iDownloadProgressValue = 0;
            _iDownloadStatus = -1;
            btnCancel.Enabled = true;
            btnUpdateProduction.Enabled = false;
            btnUpdatePreview.Enabled = false;
            btnClose.Enabled = false;
            ControlBox = false;
            chkLaunchJQ.Enabled = false;

            wc = new WebClient();

            lblStep2.ForeColor = ColorTranslator.FromHtml(_ColorString);

            using (wc)
            {
                wc.DownloadFileCompleted += wc_Completed;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;

                wc.DownloadFileAsync(new Uri(sURL + sRemoteFilename), sTargetFolder + sTargetFilename);
            }

            while (true)
            {
                Application.DoEvents();
                pbDownloadStatus.Value = _iDownloadProgressValue;

                if (_iDownloadStatus != -1)
                {
                    break;
                }
            }

            Cursor = Cursors.Default;

            if (_iDownloadStatus == 0)
            {
                btnCancel.Click -= delegate
                {
                    wc.CancelAsync();
                };

                pbDownloadStatus.Value = 0;
                btnCancel.Enabled = false;
                tmrCheck.Enabled = true;

                try
                {
                    if (File.Exists(sTargetFolder + sTargetFilename))
                    {
                        //取消下載，刪除檔案
                        File.Delete(sTargetFolder + sTargetFilename);
                    }
                }
                catch (Exception)
                {
                    //
                }
            }
            else
            {
                btnCancel.Enabled = false;

                var fi = new FileInfo(sTargetFolder + sTargetFilename);

                if (fi.Length.Equals(0))
                {
                    bError = true;
                }
                else
                {
                    picStep2.Image = picChecked.Image;
                    lblStep2.ForeColor = ColorTranslator.FromHtml(_ColorString);

                    //下載OK：解壓縮並更新檔案
                    var zip = new C1ZipFile();
                    zip.Open(sTargetFolder + sTargetFilename); //如果此處出現「C1.C1Zip.ZipFileException: 'Central dir not found.'」的錯誤，非常大的可能是，壓成 7z 格式了！C1Zip 只能處理 zip 格式！
                                                               //int cnt = zip.Entries.Count;

                    foreach (var ze in zip.Entries)
                    {
                        //get source and destination file names
                        var src = ze.FileName;
                        var dst = sTargetFolder + @"\" + ze.FileName;

                        //create destination subdirectory if necessary
                        var dstFolder = Path.GetDirectoryName(dst);

                        if (!Directory.Exists(dstFolder))
                        {
                            try
                            {
                                Directory.CreateDirectory(dstFolder);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }

                        // extract the entry
                        try
                        {
                            zip.Entries.Extract(src, dst);
                        }
                        catch (Exception ex)
                        {
                            sLangText = MyGlobal.GetLanguageString("An error has occurred.", "Global", "Global", "msg", "AnErrorHasOccurred", "Text");
                            MessageBox.Show(sLangText + "\r\n\r\n" + ex.Message, @"JasonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            bError = true;
                        }
                    }

                    if (bError == false)
                    {
                        picStep3.Image = picChecked.Image;
                        lblStep3.ForeColor = ColorTranslator.FromHtml(_ColorString);

                        var sSourceFolder = sTargetFolder + @"JasonQuery x" + (_bIs64 ? "64" : "86") + @"\";
                        sTargetFolder = txtTo.Text;

                        var uFile = Directory.GetFiles(sSourceFolder);

                        //複製檔案
                        foreach (var filename in uFile)
                        {
                            var fInfo = new FileInfo(filename);

                            if (!File.Exists(sTargetFolder + Path.GetFileName(filename)))
                            {
                                try
                                {
                                    File.Copy(filename, sTargetFolder + Path.GetFileName(filename));
                                }
                                catch (Exception ex)
                                {
                                    sLangText = MyGlobal.GetLanguageString("An error has occurred.", "Global", "Global", "msg", "AnErrorHasOccurred", "Text");
                                    MessageBox.Show(sLangText + "\r\n\r\n" + Path.GetFileName(filename) + "\r\n\r\n" + ex.Message, @"JasonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    bError = true;
                                }
                            }
                            else
                            {
                                var fInfo2 = new FileInfo(sTargetFolder + Path.GetFileName(filename));

                                if (fInfo.LastWriteTime.ToString("yyyy/mm/dd HH:nn:ss") == fInfo2.LastWriteTime.ToString("yyyy/mm/dd HH:nn:ss")
                                    && fInfo.Length == fInfo2.Length)
                                {
                                    //檔案時間、大小一樣，不處理
                                }
                                else
                                {
                                    if (fInfo.Name == "Updater.exe")
                                    {
                                        //Updater.exe 有新版本
                                        sUpdaterExeHasNewVersion = "@copy \"" + filename + "\" \"" + sTargetFolder + Path.GetFileName(filename) + "\"\r\n";
                                    }
                                    else
                                    {
                                        try
                                        {
                                            File.Copy(filename, sTargetFolder + Path.GetFileName(filename), true);
                                        }
                                        catch (Exception ex)
                                        {
                                            sLangText = MyGlobal.GetLanguageString("An error has occurred.", "Global", "Global", "msg", "AnErrorHasOccurred", "Text");
                                            MessageBox.Show(sLangText + "\r\n\r\n" + Path.GetFileName(filename) + "\r\n\r\n" + ex.Message, @"JasonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                            bError = true;
                                        }
                                    }
                                }
                            }

                            Application.DoEvents();
                        }

                        sSourceFolder += @"localization\";
                        sTargetFolder += @"localization\";

                        if (!Directory.Exists(sTargetFolder))
                        {
                            try
                            {
                                Directory.CreateDirectory(sTargetFolder);
                            }
                            catch (Exception)
                            {
                                //
                            }
                        }

                        uFile = Directory.GetFiles(sSourceFolder);

                        foreach (var filename in uFile)
                        {
                            var fInfo = new FileInfo(filename);

                            if (!File.Exists(sTargetFolder + Path.GetFileName(filename)))
                            {
                                try
                                {
                                    File.Copy(filename, sTargetFolder + Path.GetFileName(filename));
                                }
                                catch (Exception ex)
                                {
                                    sLangText = MyGlobal.GetLanguageString("An error has occurred.", "Global", "Global", "msg", "AnErrorHasOccurred", "Text");
                                    MessageBox.Show(sLangText + "\r\n\r\n" + Path.GetFileName(filename) + "\r\n\r\n" + ex.Message, @"JasonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    bError = true;
                                }
                            }
                            else
                            {
                                var fInfo2 = new FileInfo(sTargetFolder + Path.GetFileName(filename));

                                if (fInfo.LastWriteTime.ToString("yyyy/mm/dd HH:nn:ss") == fInfo2.LastWriteTime.ToString("yyyy/mm/dd HH:nn:ss")
                                    && fInfo.Length == fInfo2.Length)
                                {
                                    //檔案時間、大小一樣，不處理
                                }
                                else
                                {
                                    try
                                    {
                                        File.Copy(filename, sTargetFolder + Path.GetFileName(filename), true);
                                    }
                                    catch (Exception ex)
                                    {
                                        sLangText = MyGlobal.GetLanguageString("An error has occurred.", "Global", "Global", "msg", "AnErrorHasOccurred", "Text");
                                        MessageBox.Show(sLangText + "\r\n\r\n" + Path.GetFileName(filename) + "\r\n\r\n" + ex.Message, @"JasonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        bError = true;
                                    }
                                }
                            }

                            Application.DoEvents();
                        }

                        if (bError == false)
                        {
                            picStep4.Image = picChecked.Image;
                            lblStep4.ForeColor = ColorTranslator.FromHtml(_ColorString);
                            sLangText = MyGlobal.GetLanguageString("Update completed!", "form", Name, "msg", "UpdateCompleted", "Text") + "\r\n\r\n";

                            if (chkLaunchJQ.Checked)
                            {
                                sLangText += MyGlobal.GetLanguageString("Press OK to close the program and automatically launch JasonQuery.", "form", Name, "msg", "PressOKAndLaunchJasonQuery", "Text");
                            }
                            else
                            {
                                sLangText += MyGlobal.GetLanguageString("Press OK to close the program.", "form", Name, "msg", "PressOK", "Text");
                            }

                            MessageBox.Show(sLangText, @"Updater", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ProcessStartInfo exeInfo;

                            if (chkLaunchJQ.Checked)
                            {
                                exeInfo = new ProcessStartInfo(Application.StartupPath + @"\JasonQuery.exe")
                                {
                                    WorkingDirectory = Application.StartupPath + @"\",
                                    CreateNoWindow = true,
                                    UseShellExecute = false
                                };

                                Process.Start(exeInfo);
                            }

                            //產生批次檔：更新 Updater.exe 並刪除暫存檔案

                            var sBatchContent = "@echo off\r\n@ping localhost -n 5 -w 1000 > nul\r\n"
                                                + sUpdaterExeHasNewVersion
                                                + "@cd \"" + txtFrom.Tag + "\"\r\n"
                                                + "@del " + lblFrom.Tag + "*.* /s /q\r\n"
                                                + "@rd \"" + lblFrom.Tag + "JasonQuery x64\\localization\"\r\n"
                                                + "@rd \"" + lblFrom.Tag + "JasonQuery x64\"\r\n"
                                                + "@rd " + lblFrom.Tag.ToString().Replace("\\", "") + "\r\n"
                                                + "@del *.bat /q";

                            MyGlobal.WriteContentToFile(sBatchContent, txtFrom.Tag + "update.bat", FileMode.CreateNew);

                            exeInfo = new ProcessStartInfo("cmd.exe", "/c \"" + txtFrom.Tag + "update.bat\"")
                            {
                                WorkingDirectory = txtFrom.Text,
                                CreateNoWindow = true,
                                UseShellExecute = false
                            };

                            Process.Start(exeInfo);

                            Close();
                        }
                    }
                }
            }

            Cursor = Cursors.Default;

            if (!bError) return;

            _iDownloadStatus = -2;
            btnCancel.Enabled = false;
            btnUpdateProduction.Enabled = true;
            btnClose.Enabled = true;
            ControlBox = true;
            chkLaunchJQ.Enabled = true;

            sLangText = MyGlobal.GetLanguageString("Update failed!", "form", Name, "msg", "UpdateFailed", "Text") + "\r\n\r\n" + MyGlobal.GetLanguageString("Please try again or update manually by yourself!", "form", Name, "msg", "FailedTryAgain", "Text") + "\r\n\r\n";
            var sTemp0 = MyGlobal.GetLanguageString("How to manually update JasonQuery to the latest version:", "form", "frmCheckForUpdates", "msg", "HowToUpdate0", "Text") + "\r\n";
            var sTemp1 = MyGlobal.GetLanguageString("1. Download the latest JasonQuery.7z", "form", "frmCheckForUpdates", "msg", "HowToUpdate1", "Text") + "\r\n";
            var sTemp2 = MyGlobal.GetLanguageString("2. Close all open JasonQuery", "form", "frmCheckForUpdates", "msg", "HowToUpdate2", "Text") + "\r\n";
            var sTemp3 = MyGlobal.GetLanguageString("3. Unzip \"JasonQuery x64\" or \"JasonQuery x86\" to the folder where JasonQuery is currently located (overwrite all, JasonQuery.7z does not include JasonQuery.db)", "form", "frmCheckForUpdates", "msg", "HowToUpdate3", "Text") + "\r\n";
            var sTemp4 = MyGlobal.GetLanguageString("4. Run JasonQuery", "form", "frmCheckForUpdates", "msg", "HowToUpdate4", "Text");

            MessageBox.Show(sLangText + sTemp0 + sTemp1 + sTemp2 + sTemp3 + sTemp4, @"Updater", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _iDownloadProgressValue = e.ProgressPercentage;

            if (_iDownloadStatus == 0)
            {
                wc.CancelAsync();
            }
        }

        private void wc_Completed(object sender, AsyncCompletedEventArgs e)
        {
            _iDownloadStatus = e.Cancelled ? 0 : 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _iDownloadStatus = 0;
            btnUpdateProduction.Enabled = true;
            btnClose.Enabled = true;
            ControlBox = true;
            chkLaunchJQ.Enabled = true;

            InitialLabel();
        }

        private void InitialLabel()
        {
            lblStep1.ForeColor = Color.Black;
            lblStep2.ForeColor = Color.Black;
            lblStep3.ForeColor = Color.Black;
            lblStep4.ForeColor = Color.Black;
        }

        private void frmUpdater_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxManager.Unregister();
        }

        private void rdoUpdateProduction_CheckedChanged(object sender, EventArgs e)
        {
            btnUpdateProduction.Enabled = rdoUpdateProduction.Checked;
            btnUpdatePreview.Enabled = !rdoUpdateProduction.Checked;

            if (rdoUpdateProduction.Checked)
            {
                lblStep2.Text = lblStep2.Tag.ToString().Replace("JasonQuery.zip", "JasonQuery" + (_bIs64 ? "64" : "86") + ".zip");
                lblStep3.Text = lblStep3.Tag.ToString().Replace("JasonQuery.zip", "JasonQuery" + (_bIs64 ? "64" : "86") + ".zip");
                GetRichText(txtStep2, lblStep2.Tag.ToString(), "JasonQuery" + (_bIs64 ? "64" : "86") + ".zip");
                GetRichText(txtStep3, lblStep3.Tag.ToString(), "JasonQuery" + (_bIs64 ? "64" : "86") + ".zip");
            }
        }

        private void rdoUpdatePreview_CheckedChanged(object sender, EventArgs e)
        {
            btnUpdateProduction.Enabled = !rdoUpdatePreview.Checked;
            btnUpdatePreview.Enabled = rdoUpdatePreview.Checked;

            if (rdoUpdatePreview.Checked)
            {
                lblStep2.Text = lblStep2.Tag.ToString().Replace("JasonQuery.zip", "JasonQuery64Test.zip");
                lblStep3.Text = lblStep3.Tag.ToString().Replace("JasonQuery.zip", "JasonQuery64Test.zip");

                GetRichText(txtStep2, lblStep2.Tag.ToString(), "JasonQuery64Test.zip");
                GetRichText(txtStep3, lblStep3.Tag.ToString(), "JasonQuery64Test.zip");
            }
        }

        private void GetRichText(RichTextBox txtInfo, string sText1, string sText2 = "")
        {
            var font = new Font("微軟正黑體", 9);
            txtInfo.Text = "";

            var parts = sText1.Split(new[] { "JasonQuery.zip" }, StringSplitOptions.None);

            txtInfo.AppendText(parts[0].Trim() + " ", Color.Black, font);

            if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
            {
                txtInfo.AppendText(sText2.Trim(), Color.Blue, font);
                txtInfo.AppendText(" " + parts[1].Trim(), Color.Black, font);
            }

            txtInfo.Refresh();
        }

        private void btnUpdatePreview_Click(object sender, EventArgs e)
        {
            UpdateFile();
        }
    }

    public static class RichTextBoxColorExtensions
    {
        public static void AppendText(this RichTextBox rtb, string text, Color color, Font font, bool isNewLine = false)
        {
            rtb.SuspendLayout();
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor = color;
            rtb.SelectionFont = font;
            rtb.AppendText(isNewLine ? $"{text}{ Environment.NewLine}" : text);
            rtb.SelectionColor = rtb.ForeColor;
            rtb.ScrollToCaret();
            rtb.ResumeLayout();
        }
    }
}