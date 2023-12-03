using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Updater
{
    static class Program
    {
        private static bool bNewInstance;
        static string sGuid = "{JQUPDATE12-C91D-1231-1688-B2D7E22D1F1D}";

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (var m = new Mutex(false, "Global\\" + sGuid, out bNewInstance))
            {
                if (bNewInstance)
                {
                    if (args.Length > 0)
                    {
                        var sArg = args[0].ToString().Replace("``", " ");
                        var sArgs = sArg.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                        if (sArgs.Length == 2)
                        {
                            MyGlobal.sLocalization = sArgs[0].ToString();
                            MyGlobal.sXmlFilename = sArgs[1].ToString();
                        }
                    }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmUpdater());
                }
                else
                {
                    var current = Process.GetCurrentProcess();
                    foreach (var process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id == current.Id) continue;

                        SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
            }
        }
    }
}
