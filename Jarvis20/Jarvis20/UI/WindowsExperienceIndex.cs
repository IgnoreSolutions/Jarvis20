using Jarvis_WinSAT;
using Jarvis20.UI;
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
        private const string Jarvis_WinSATx64 = "https://github.com/MikeSantiagoInc/Jarvis20/releases/download/v0.1-jarsat/Jarvis_WinSAT-x64.exe";
        private const string Jarvis_WinSATx86 = "https://github.com/MikeSantiagoInc/Jarvis20/releases/download/v0.1-jarsat/Jarvis_WinSAT-x86.exe";
        private WinSATObject w;

        public WindowsExperienceIndex()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            //checks if winsat has to be run or not
            w = new WinSATObject();
            if(w.CPUScore == (decimal)0.0 || w.CPUScore == 0)
            {
                RunWinSATTool();
            }
            else
            {
                Label[] lbls = new Label[] { cpuScoreLabel, ramScoreLabel, d3dScoreLabel, desktopGraphicsLabel, diskScoreLabel };
                cpuScoreLabel.Text = w.CPUScore.ToString();
                ramScoreLabel.Text = w.MemoryScore.ToString();
                d3dScoreLabel.Text = w.D3DScore.ToString();
                desktopGraphicsLabel.Text = w.GraphicsScore.ToString();
                diskScoreLabel.Text = w.DiskScore.ToString();
                foreach(var i in lbls)
                {
                    if (i.Text == w.WinSPRLevel.ToString())
                        i.Font = new Font(i.Font.Name, i.Font.Size, FontStyle.Underline);
                }
            }
        }
        private void LoadEvents()
        {
            w = new WinSATObject();
            if (w.CPUScore == (decimal)0.0 || w.CPUScore == 0)
            {
                MessageBox.Show("WinSAT cannot generate a score on this system", "Jarvis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                Label[] lbls = new Label[] { cpuScoreLabel, ramScoreLabel, d3dScoreLabel, desktopGraphicsLabel, diskScoreLabel };
                cpuScoreLabel.Text = w.CPUScore.ToString();
                ramScoreLabel.Text = w.MemoryScore.ToString();
                d3dScoreLabel.Text = w.D3DScore.ToString();
                desktopGraphicsLabel.Text = w.GraphicsScore.ToString();
                diskScoreLabel.Text = w.DiskScore.ToString();
                foreach (var i in lbls)
                {
                    if (i.Text == w.WinSPRLevel.ToString())
                        i.Font = new Font(i.Font.Name, i.Font.Size, FontStyle.Underline);
                }
            }
        }
        private void RunWinSATTool()
        {
            bool run = false;
            if (File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Jarvis_WinSAT.exe"))
                run = true;
            if (!File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Jarvis_WinSAT.exe"))
            {
                DialogResult dr = MessageBox.Show("In order to run the System Assessment Tool, we will need to download an external utility developed by us. Would you like to do this now?",
                    "Jarvis",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (Environment.Is64BitOperatingSystem)
                    {
                        //download 64-bit jarvis winsat
                        //Remember: exit code of -2 means wrong architecture
                        //Exit code of -1 means WinSAT wasn't found or the user didn't allow WinSAT to run which isn't as big of a deal as -2
                        if (!File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Jarvis_WinSAT.exe"))
                        {
                            Downloader d = new Downloader(Jarvis_WinSATx64, "Jarvis_WinSAT.exe");
                            d.ShowDialog();
                            run = true;
                        }
                    }
                    else
                    {
                        if (!File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Jarvis_WinSAT.exe"))
                        {
                            Downloader d = new Downloader(Jarvis_WinSATx86, Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Jarvis_WinSAT.exe");
                            d.ShowDialog();
                            run = true;
                        }
                    }
                }
                else if (dr == DialogResult.No)
                    run = false;
            }
            if (run)
            {
                Process p = new Process();
                p.StartInfo.FileName = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Jarvis_WinSAT.exe";
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.Verb = "runas";
                p.StartInfo.Arguments = "-prepop_formal";
                try
                {
                    ProcessRunner pr = new ProcessRunner(p, "Windows Performance Assessment Test");
                    DialogResult ddr = pr.ShowDialog();
                    switch (ddr)
                    {
                        case (DialogResult.OK):
                            LoadEvents();
                            break;
                        case (DialogResult.Abort):
                            MessageBox.Show("The operation was aborted!", "Jarvis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            //textBox1.Text = yes;
        }

        private void overallRating_Paint(object sender, PaintEventArgs e)
        {
            using (Font f = new Font("Segoe UI", 34))
            {
                e.Graphics.DrawString(w.WinSPRLevel.ToString(), f, Brushes.White, new Point((overallRating.Size.Width/2)/2/2, (overallRating.Size.Height/2)/2/2));
            }
        }

        private void reRunButton_Click(object sender, EventArgs e)
        {
            RunWinSATTool();
        }
        //
    }
}
