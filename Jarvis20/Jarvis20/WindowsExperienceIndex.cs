using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
