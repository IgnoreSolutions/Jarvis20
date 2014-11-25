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
using System.Reflection;

namespace Jarvis20
{
    public partial class MainForm : Form
    {
        //Intiial variable declarations
        SpeechSynthesizer synth = new SpeechSynthesizer(); //This speaks
        PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total"); //This monitors CPU load
        PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes"); //This monitors available memory
        PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time"); //This monitors system up time
        bool paused = false; //Whether or not Jarvis is paused


        public MainForm()
        {
            Font = SystemFonts.MessageBoxFont; //Sets the form's font to the system's default font
            InitializeComponent(); //Shows the form, and its components
            perfUptimeCount.NextValue(); //
            perfCpuCount.NextValue();    // Pulls the initial values first, for accuracy
            perfMemCount.NextValue();    //
            //
            Version ver = Assembly.GetEntryAssembly().GetName().Version; //The executable stores a version too, this retrieves it. This is much more accurate
            this.Text = string.Format("Jarvis {0}.{1} Beta Build", ver.Major, ver.Minor); //Changes the window's title text to the current version number.
            //
            synth.SelectVoiceByHints(VoiceGender.Male);
        }

        // This is the opening Text to speak, and quotes represent what he will say.
        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Version ver = Assembly.GetEntryAssembly().GetName().Version;
            synth.Speak(String.Format("Welcome to Jarvis version {0} point {1}, beta build", ver.Major, ver.Minor));
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
                    lvi.Text = currentDateTime; //.Text is the property indicating the first column
                    lvi.SubItems.Add(String.Format("{0}%", curCpuPercentage.ToString())); //All 'SubItems.Add's following will correspond to the next rows. This is second row
                    lvi.SubItems.Add(String.Format("{0} MB", curMemAvail.ToString())); //Third row
                    listView1.Items.Add(lvi); //Adds the ListViewItem to the ListView
                    //This will set the TextBox's text to however long the system's been up
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

        /// <summary>
        /// The first bit of information being called in.
        /// </summary>
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
            Environment.Exit(0); //Exit the program, '0' is the return code used by the OS to indicate no errors
        }

        private void writeToLogFile_Click(object sender, EventArgs e)
        {
            //Declares the safe file dialog variable, gives it a title, and sets the filter (files to be shown)
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save log as...";
            sfd.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            DialogResult dr = sfd.ShowDialog(); //The user's choice stored into a variable
            switch(dr)
            {
                    //If they choose OK
                case(DialogResult.OK):
                    WriteToLogFile(sfd.FileName);
                    MessageBox.Show(String.Format("File written to {0} successfully!", sfd.FileName), 
                        "Information", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information); //Show a confirmation
                    break;
                case(DialogResult.Cancel):
                    //If they chose cancel, do nothing then
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
            this.UseWaitCursor = true;
            SystemSpecs ss = new SystemSpecs(this);
            ss.Show();
        }

        /// <summary>
        /// Returns a component's information from WMI
        /// </summary>
        /// <param name="hwclass">The hardware to return a certain value for</param>
        /// <param name="syntax">The value to be returned of the hardware</param>
        /// <returns></returns>
        public static string GetComponent(string hwclass, string syntax)
        {
            
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                return mj[syntax].ToString();
            }
            return null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm(); //Declares the AboutForm variable
            af.ShowDialog();              //Shows it as a dialog, meaning the user won't be able to interact with the elements below until this dialog is closed
        }

        //
    }
}
