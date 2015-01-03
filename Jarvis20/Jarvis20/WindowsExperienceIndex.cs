using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jarvis20
{
    public partial class WindowsExperienceIndex : Form
    {
        public WindowsExperienceIndex()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("In order to run the System Assessment Tool, we will need to download an external utility developed by us. Would you like to do this now?", 
                "Jarvis", 
                MessageBoxButtons.YesNoCancel, 
                MessageBoxIcon.Question);

            if(Environment.Is64BitOperatingSystem)
            {
                //download 64-bit jarvis winsat
                //Remember: exit code of -2 means wrong architecture
                //Exit code of -1 means WinSAT wasn't found or the user didn't allow WinSAT to run which isn't as big of a deal as -2

            }
            else
            {
                //download 32-bit jarvis winsat
            }

            Process p = new Process();
            p.StartInfo.FileName = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Jarvis_WinSAT.exe";
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = "-prepop_formal";
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

#if what
            WriteTempBatch();
            const int ERROR_CANCELLED = 1223;

            ProcessStartInfo info = new ProcessStartInfo(System.IO.Path.Combine(Environment.CurrentDirectory + "temp.bat"));
            info.UseShellExecute = true;
            info.Arguments = System.IO.Path.Combine(Environment.CurrentDirectory + "temp.bat");
            info.Verb = "runas";
            try
            {
                Process.Start(info);
            }
            catch(Win32Exception ex)
            { MessageBox.Show(ex.Message); }
#endif
        }

        private void WriteTempBatch()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(Environment.CurrentDirectory + "temp.bat")))
            {
                sw.WriteLine("@echo off");
                sw.WriteLine("echo \"Running winsat prepop..\"");
                sw.WriteLine("winsat prepop");
                sw.WriteLine("echo \"Running winsat formal..\"");
                sw.WriteLine("winsat formal");
                sw.WriteLine("echo\" Done!\"");
                sw.WriteLine("pause");
                sw.Flush();
                sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cpu = MainForm.GetComponent("Win32_WinSAT", "CPUScore");
            string d3d = MainForm.GetComponent("Win32_WinSAT", "D3DScore");
            string disk = MainForm.GetComponent("Win32_WinSAT", "DiskScore");
            string desktopGraphics = MainForm.GetComponent("Win32_WinSAT", "DiskScore");
            string memory = MainForm.GetComponent("Win32_WinSAT", "MemoryScore");
            string lowest = MainForm.GetComponent("Win32_WinSAT", "WinSPRLevel");

            string yes = string.Format("CPU Score: {0}\nD3D Score: {1}\nDisk Score: {2}\nAero Graphics: {3}\nMemory Score: {4}\nFinal (lowest): {5}",
                cpu, d3d, disk, desktopGraphics, memory, lowest);
            textBox1.Text = yes;
        }
        //
    }
}
