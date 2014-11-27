using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Jarvis20
{
    public partial class ExportLog : Form
    {
        public bool exportSystemSpecs = false;
        public bool exportCurrentUptime = false;
        string exLog = "Log Begins\nTime\t\t\tCPU Usage %\tMem Avail MB\n11/11/2014 8:18:30 AM\t23%\t\t1024\n11/11/2014 8:18:31 AM\t93%\t\t967\n11/11/2014 8:18:32 AM\t0%\t\t934";
        string exLog_Specs = "System Specifications\nNetwork Adapter: WAN Miniport (SSTP)\nProcessor: Pentium(R) Dual-Core CPU E5800 @ 3.20ghz; 64-Bit\nTotal RAM: 3.87 GB (3965.242 MB) \nVideo Card: Intel(R) G41 Express Chipset 1.811153GB (1854.621 MB)\nSound Card: Realtek High Definition Audio\nMotherboard: Lenovo\nCD Rom: HL-DT-ST DVD-RAM GH60N ATA Device\nMonitor: Generic PnP Monitor\nOS: Microsoft Windows 7 Ultimate 64-Bit\n\n";
        string exLog_Uptime = "System Uptime, at the time of export: 0 hrs 11 mins 59 secs\n\n";
        string fileToWriteTo = null;
        MainForm mf;

        public ExportLog(string fileToWriteTo_, MainForm _mf)
        {
            mf = _mf;
            fileToWriteTo = fileToWriteTo_;
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();

        }

        private void ExportLog_Load(object sender, EventArgs e)
        {
            logPreviewTextBox.Text = "Time\t\t\tCPU Usage %\tMem Avail MB\n11/11/2014 8:18:30 AM\t23%\t\t1024\n11/11/2014 8:18:31 AM\t93%\t\t967\n11/11/2014 8:18:32 AM\t0%\t\t934";
        }

        private void exportSystemSpecifications_CheckedChanged(object sender, EventArgs e)
        {
            whatToDisplay();
        }
        
        void whatToDisplay()
        {
            if(exportSystemSpecifications.Checked == true)
            {
                if(exportCurrentSystemUptime.Checked == true)
                {
                    logPreviewTextBox.Text = exLog_Specs + exLog_Uptime + exLog;
                }
                else
                {
                    logPreviewTextBox.Text = exLog_Specs + exLog;
                }
            }
            else if(exportCurrentSystemUptime.Checked == true)
            {
                if(exportSystemSpecifications.Checked == true)
                {
                    logPreviewTextBox.Text = exLog_Specs + exLog_Uptime + exLog;
                }
                else
                {
                    logPreviewTextBox.Text = exLog_Uptime + exLog;
                }
            }
            else
            {
                logPreviewTextBox.Text = exLog;
            }
        }

        private void exportCurrentSystemUptime_CheckedChanged(object sender, EventArgs e)
        {
            whatToDisplay();
        }

        void exportLog(object fileToSave)
        {
            string file = fileToSave.ToString();
            this.UseWaitCursor = true;
            try
            {
                StreamWriter sw = new StreamWriter(file);
                string uptime = null;
                if (exportCurrentSystemUptime.Checked == true)
                    uptime = retrieveCurrentUpTime();

                if (exportSystemSpecifications.Checked == true)
                {
                    SystemSpecifications ss = new SystemSpecifications();
                    sw.WriteLine("System Specifications\n");
                    sw.WriteLine("Network Adapter: {0}", ss.NetworkAdapter);
                    sw.WriteLine("Processor: {0}", ss.Processor);
                    sw.WriteLine("Total RAM: {0}", ss.TotalRAMAvailable);
                    sw.WriteLine("Video Card: {0}", ss.VideoCard);
                    sw.WriteLine("Sound Card: {0}", ss.SoundCard);
                    sw.WriteLine("Motherboard: {0}", ss.Motherboard);
                    sw.WriteLine("CD Rom: {0}", ss.CDRom);
                    sw.WriteLine("Monitor: {0}", ss.Monitor);
                    sw.WriteLine("OS: {0}", ss.OperatingSystem);
                    sw.WriteLine("");
                    sw.WriteLine("");
                }
                if (uptime != null)
                { sw.WriteLine(uptime); sw.WriteLine(""); }

                sw.WriteLine("Time\t\t\tCPU Usage %\tMem Avail MB");
                foreach (ListViewItem lvi in mf.listView1.Items)
                {
                    string date = lvi.Text;
                    string cpu = lvi.SubItems[1].Text;
                    string mem = lvi.SubItems[2].Text;
                    sw.WriteLine(String.Format("{0}\t{1}\t\t{2}", date, cpu, mem));
                }
                sw.Flush();
                MessageBox.Show(string.Format("Log written to {0} successfully!", fileToWriteTo), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        string retrieveCurrentUpTime()
        {
            MainForm mf = new MainForm();
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(mf.perfUptimeCount.NextValue());
            string systemUptimeMessage = string.Format("System Uptime, at the time of export: {0} hrs {1} mins {2} secs\n\n", (int)uptimeSpan.Hours, (int)uptimeSpan.Minutes, (int)uptimeSpan.Seconds);
            return systemUptimeMessage;
        }

        private void enableControls()
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = true; ;
            }
        }

        private void disablecontrols()
        {
            foreach(Control c in this.Controls)
            {
                c.Enabled = false; ;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            try
            {
                Thread t = new Thread(new ParameterizedThreadStart(exportLog));
                t.Start(fileToWriteTo);
                exportLog(fileToWriteTo);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("There was an error trying to write the log to disk: \n{0}", ex.Message), "Error Writing Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.UseWaitCursor = false;
        }
    }
}
