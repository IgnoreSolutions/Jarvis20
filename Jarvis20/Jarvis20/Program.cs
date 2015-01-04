using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

namespace Jarvis20
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Contains("-nogui"))
            {
                NoGUI.ShowConsoleWindow();
                Console.WriteLine("Passed argument '-nogui', resorting to console");
                NoGUI.RunConsoleLoop();
            }
            else
            {
#if !DEBUG
                if(IsJarvisRunning())
                {
                    MessageBox.Show("It appears as though Jarvis is already running! Please close him before continuing.", "Jarvis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }
#endif

                double osVersion = double.Parse(Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString());
                if (osVersion >= 6.0)
                {
                    if (!args.Contains("-nostyling"))
                        Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else if(DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Linux)
                {
                    MessageBox.Show("Sorry, Jarvis does function under Mono/Linux!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }
                else if (osVersion < 6.0)
                {
                    MessageBox.Show("Sorry, Jarvis does not function on Windows XP or lower. Please upgrade to use him!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }
            }
        }

        private static bool IsJarvisRunning()
        {
            Process[] proc = Process.GetProcesses();
            foreach(var i in proc)
            {
                if (i.ProcessName.IndexOf("jarvis", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    if (i.ProcessName.IndexOf("vshost", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        return false;
                    else
                        return true;
                }
            }
            return false;
        }

        public static bool SupportsWEIThroughCP()
        {
            DetectOperatingSystem.OSFriendly os = DetectOperatingSystem.OSName();
            if (os == DetectOperatingSystem.OSFriendly.Windows10 || os == DetectOperatingSystem.OSFriendly.Windows8 || os == DetectOperatingSystem.OSFriendly.Windows81)
                return false;
            else if(os == DetectOperatingSystem.OSFriendly.Windows7 || os == DetectOperatingSystem.OSFriendly.WindowsVista)
                return true;

            return false;
        }

    }
}
