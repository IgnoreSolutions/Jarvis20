using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Jarvis20
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            double osVersion = double.Parse(Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString());
            if(osVersion >= 6.0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else if(osVersion < 6.0)
            {
                MessageBox.Show("Sorry, Jarvis does not function on Windows XP or lower. Please upgrade to use him!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }
    }
}
