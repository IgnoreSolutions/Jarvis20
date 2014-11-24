using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Management;

namespace Jarvis20
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
        PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
        bool paused = false;


        public Form1()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            perfUptimeCount.NextValue();
            perfCpuCount.NextValue();
            perfMemCount.NextValue();
        }

        // This is the opening Text to speak, and quotes represent what he will say.
        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            synth.Speak("Welcome to Jarvis version two point seven five, beta build");
            GetCurrentInformation();
            Thread thrd = new Thread(loop);
            thrd.Start();
        }
       
        private void loop()
        {
            while(true)
            {
                if (!paused)
                {
                    //Temperature temp = new Temperature();
                    
                    ListViewItem lvi = new ListViewItem();
                    string currentDateTime = DateTime.Now.ToString();
                    int curCpuPercentage = (int)perfCpuCount.NextValue();
                    int curMemAvail = (int)perfMemCount.NextValue();
                    lvi.Text = currentDateTime;
                    lvi.SubItems.Add(String.Format("{0}%", curCpuPercentage.ToString()));
                    lvi.SubItems.Add(String.Format("{0} MB", curMemAvail.ToString()));
                    //lvi.SubItems.Add(GetCpuTemp().ToString()) CPU Temp
                    //lvi.SubItems.Add(); // GPU Temp

                    listView1.Items.Add(lvi);
                    //This will show the textbox, how long the system has been up.
                    TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());
                    string systemUptimeMessage = string.Format("{0} hrs {1} mins {2} secs", (int)uptimeSpan.Hours, (int)uptimeSpan.Minutes, (int)uptimeSpan.Seconds);
                    uptimeTextBox.Text = systemUptimeMessage;
                    //Scroll down to the bottom
                    listView1.Items[listView1.Items.Count - 1].EnsureVisible();
                    //

                    //For when stuff is astronomically large like Mike's dong
                    if (curCpuPercentage > 80)
                    {
                        if (curCpuPercentage == 100)
                        {
                            string cpuLoadVocalMessage = String.Format("WARNING: Your CPU is at 100%", curCpuPercentage);
                            Speak(cpuLoadVocalMessage, VoiceGender.Male, 1);
                        }
                        else
                        {
                            string cpuLoadVocalMessage = String.Format("WARNING: CPU Usage is at 80% or higher!", curCpuPercentage);
                            Speak(cpuLoadVocalMessage, VoiceGender.Male, 3);
                        }
                    }
                    if (curMemAvail < 512)
                    {
                        string memLoadVocalMessage = "You currently have less than a half a gig of RAM available!";
                        Speak(memLoadVocalMessage, VoiceGender.Male);
                    }
                    //

                    Thread.Sleep(1000);
                }
            }
        }

        private void Speak(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            Speak(message, voiceGender);
        }
        private void Speak(string message, VoiceGender voiceGender)
        {
            synth.SelectVoiceByHints(voiceGender);
            synth.Speak(message);
        }

        private void GetCurrentInformation()
        {
            //Item: Time, Subitem 1: Cpu Subitem 2: Mem
            ListViewItem lvi = new ListViewItem();
            string currentDateTime = DateTime.Now.ToString();
            int curCpuPercentage = (int)perfCpuCount.NextValue();
            int curMemAvail = (int)perfMemCount.NextValue();
            lvi.Text = currentDateTime;
            lvi.SubItems.Add(String.Format("{0}%", curCpuPercentage.ToString()));
            lvi.SubItems.Add(String.Format("{0} MB", curMemAvail.ToString()));
            listView1.Items.Add(lvi);
            //This will show the textbox, how long the system has been up.
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());
            string systemUptimeMessage = string.Format("{0} hrs {1} mins", (int)uptimeSpan.Hours, (int)uptimeSpan.Minutes);
            uptimeTextBox.Text = systemUptimeMessage;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if(paused) //paused, so we need to unpause it!
            {
                paused = false;
                pauseButton.Text = "Pause Jarvis";
                ListViewItem lvi = new ListViewItem();
                string currentDateTime = DateTime.Now.ToString();
                lvi.Text = currentDateTime;
                lvi.SubItems.Add("RESUMED");
                lvi.SubItems.Add("RESUMED");
                listView1.Items.Add(lvi);
            }
            else if(paused == false) //unpaused, so we need to pause it
            {
                paused = true;
                pauseButton.Text = "Resume Jarvis";
                ListViewItem lvi = new ListViewItem();
                string currentDateTime = DateTime.Now.ToString();
                lvi.Text = currentDateTime;
                lvi.SubItems.Add("PAUSED");
                lvi.SubItems.Add("PAUSED");
                listView1.Items.Add(lvi);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void writeToLogFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save log as...";
            sfd.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            DialogResult dr = sfd.ShowDialog();
            switch(dr)
            {
                case(DialogResult.OK):
                    WriteToLogFile(sfd.FileName);
                    MessageBox.Show(String.Format("File written to {0} successfully!", sfd.FileName), 
                        "Information", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    break;
                case(DialogResult.Cancel):

                    break;
            }
        }

        
        // Log file Commands
        private void WriteToLogFile(string fileToSave)
        {
            StreamWriter sw = new StreamWriter(fileToSave);
            try
            {
                sw.WriteLine("Time\t\t\tCPU Usage %\tMem Avail MB");
                foreach (ListViewItem lvi in listView1.Items)
                {
                    string date = lvi.Text;
                    string cpu = lvi.SubItems[1].Text;
                    string mem = lvi.SubItems[2].Text;
                    sw.WriteLine(String.Format("{0}\t{1}\t\t{2}", date, cpu, mem));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while writing to file:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sw.Flush();

        }

        // This tells the computer to look for HardWare Specs
        private void button1_Click(object sender, EventArgs e)
        {
            string proc = GetComponet("Win32_Processor", "Name");
            string videoCard = GetComponet("Win32_VideoController", "Name");
            string soundCard = GetComponet("Win32_SoundDevice", "Caption");
            string moboIdent = GetComponet("Win32_BaseBoard", "Product");
            string deskMonitor = GetComponet("Win32_DesktopMonitor", "Name");
            string network = GetComponet("Win32_NetworkAdapter", "Name");
            string cdRom = GetComponet("Win32_CDROMDrive", "Name");


            MessageBox.Show(string.Format("Processor: {0}\nVideo Card: {1}\nSound Card: {2}\nOn Board Graphics: {3}\nMonitor: {4}\nNetwork Adapter: {5}\nCD Rom: {6}",
            proc, videoCard, soundCard, moboIdent, deskMonitor, network, cdRom ),
                "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hwclass"></param>
        /// <param name="syntax"></param>
        /// <returns></returns>
        private static string GetComponet(string hwclass, string syntax)
        {
            
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                //Console.WriteLine(Convert.ToString(mj[syntax]));
                return mj[syntax].ToString();
            }
            return null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Jarvis is a monitoring Program. He tells you your CPU Load, and how much Memory you have left. He also tells you when your CPU Load has reached 80% or Higher! Whenever you reach the maxium state of 100% CPU Load, he also notifys you letting you know that your CPU is at 100% load. Thanks for using Jarvis!  (:", "About Jarvis",
                MessageBoxButtons.OK, MessageBoxIcon.Question)
                == DialogResult.OK);
        }

        //
    }
}
