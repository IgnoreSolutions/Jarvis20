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
                ShowConsoleWindow();
                Console.WriteLine("Passed argument '-nogui', resorting to console");
                NoGUI.RunConsoleLoop();
            }
            else
            {
                double osVersion = double.Parse(Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString());
                if (osVersion >= 6.0)
                {
                    if (!args.Contains("-nostyling"))
                        Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else if (osVersion < 6.0)
                {
                    MessageBox.Show("Sorry, Jarvis does not function on Windows XP or lower. Please upgrade to use him!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }
            }
        }
    }
}
