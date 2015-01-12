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
using WindowBorderColor;
using Utility;
using Utility.ModifyRegistry;

namespace Jarvis20
{
    public partial class MainForm : Form
    {
        //Intiial variable declarations
        SpeechSynthesizer synth = new SpeechSynthesizer(); //This speaks
        PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total"); //This monitors CPU load
        PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes"); //This monitors available memory
        public PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time"); //This monitors system up time
        bool paused = false; //Whether or not Jarvis is paused
        bool terminating = false;
        bool appStartup = false;

        public MainForm()
        {
            appStartup = true;
            Font = System.Drawing.SystemFonts.MessageBoxFont; //Sets the form's font to the system's default font
            InitializeComponent(); //Shows the form, and its components
            System.Windows.SystemParameters.StaticPropertyChanged += SystemParameters_StaticPropertyChanged;
            synth.SelectVoiceByHints(VoiceGender.Male);
            perfUptimeCount.NextValue(); //
            perfCpuCount.NextValue();    // Pulls the initial values first, for accuracy
            perfMemCount.NextValue();    //
            //
            Version ver = Assembly.GetEntryAssembly().GetName().Version; //The executable stores a version too, this retrieves it. This is much more accurate
            #region Platform specific code
            if(DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows7)
            {
                this.Text = String.Format("Jarvette {0}.{1}", ver.Major, ver.Minor);
                if(ver.Minor == 0)
                    synth.Speak(String.Format("Welcome to Jarvette version {0} point ohh", ver.Major));
                else
                    synth.Speak(String.Format("Welcome to Jarvette version {0} point {1}", ver.Major, ver.Minor));
            }
            else
            {
                this.Text = String.Format("Jarvis {0}.{1}", ver.Major, ver.Minor); //Changes the window's title text to the current version number.
                if (ver.Minor == 0)
                    synth.Speak(String.Format("Welcome to Jarvis version {0} point ohh", ver.Major));
                else
                    synth.Speak(String.Format("Welcome to Jarvis version {0} point {1}", ver.Major, ver.Minor));
            }
            //
            if (DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows8 | DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows81 | DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows10)
            { Win8Theme(); }
            else
                useWin8CheckBox.Enabled = false;
            //
            #endregion
            appStartup = false;
        }

        private void Win8Theme()
        {
            //WindowBorderColor.WindowBorderColor.InitializeWindows8Theme(this);
            //The theme will be enabled by default on Windows 8, 8.1, and disabled (but available) on Windows 10. So first we need to check
            //if our reg key is null
            ModifyRegistry mr = new ModifyRegistry();
            bool useWin8Theme;
            try
            {
                useWin8Theme = bool.Parse(mr.Read("WIN8THEME"));
                if (useWin8Theme)
                {
                    WindowBorderColor.WindowBorderColor.InitializeWindows8Theme(this);
                    useWin8CheckBox.Checked = true;
                }
                else
                    useWin8CheckBox.Checked = false;
                
            }
            catch //this is ok since this means we just have to create it
            {
                if(DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows8 | DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows81)
                {
                    WindowBorderColor.WindowBorderColor.InitializeWindows8Theme(this);
                    mr.Write("WIN8THEME", true);
                    useWin8CheckBox.Checked = true;
                }
                else if(DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows10)
                {
                    mr.Write("WIN8THEME", false);
                    useWin8CheckBox.Checked = false;
                }
            }
        }

        void SystemParameters_StaticPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string prop = e.PropertyName;
            if(e.PropertyName == "WindowGlassBrush")
            {
                WindowBorderColor.WindowBorderColor.InitializeWindows8Theme(this);
            }
        }
        public override void Refresh()
        {
            base.Refresh();
            if (DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows8 || DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows81)
                WindowBorderColor.WindowBorderColor.InitializeWindows8Theme(this);
        }
        // This is the opening Text to speak, and quotes represent what he will say.
        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            GetCurrentInformation();
            Thread thrd = new Thread(loop);
            thrd.IsBackground = true;
            thrd.Start();
        }
       
        private void loop()
        {
            int memWarningLevel = 0;
            int cpuWarningLevel = 0;

            while (true)
            {
                if (terminating == false)
                {
                    if (!paused)
                    {
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
                                if (cpuWarningLevel > 9)
                                    cpuWarningLevel = 0;
                                if (cpuWarningLevel == 0)
                                {
                                    string cpuLoadVocalMessage = String.Format("WARNING: Your CPU is at 100%", curCpuPercentage);

                                    if (this.Visible == false)
                                    {
                                        notifyIcon.BalloonTipText = "Warning! CPU Usage is at 100%!";
                                        notifyIcon.ShowBalloonTip(1000);
                                    }
                                    Speak(cpuLoadVocalMessage, VoiceGender.Male, 1);
                                }
                                cpuWarningLevel++;
                            }
                            else
                            {
                                if (cpuWarningLevel > 9)
                                    cpuWarningLevel = 0;
                                if (cpuWarningLevel == 0)
                                {
                                    string cpuLoadVocalMessage = String.Format("WARNING: CPU Usage is at 80% or higher!", curCpuPercentage);
                                    if (this.Visible == false)
                                    {
                                        notifyIcon.BalloonTipText = String.Format("Warning! CPU Usage is at {0}%!", curCpuPercentage);
                                        notifyIcon.ShowBalloonTip(1000);
                                    }
                                    Speak(cpuLoadVocalMessage, VoiceGender.Male, 3);
                                }
                                cpuWarningLevel++;
                            }
                        }
                        if (curMemAvail < 512)
                        {
                            if (memWarningLevel > 9)
                                memWarningLevel = 0;
                            if (memWarningLevel == 0)
                            {
                                string memLoadVocalMessage = "You currently have less than a half a gig of RAM available!";
                                if (this.Visible == false)
                                {
                                    notifyIcon.BalloonTipText = String.Format("Warning! You currently have {0}mb of RAM available!", curMemAvail);
                                    notifyIcon.ShowBalloonTip(1000);
                                }
                                Speak(memLoadVocalMessage, VoiceGender.Male);
                            }
                            memWarningLevel++;
                        }
                        Thread.Sleep(1000);
                    }
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
            if (terminating == false)
            {
                DialogResult dr = MessageBox.Show("Would you like to minimize Jarvis to the system tray? Answering no will close the program.",
                    "Question",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case (DialogResult.Yes):
                        e.Cancel = true;
                        notifyIcon.Visible = true;
                        this.Hide();
                        notifyIcon.BalloonTipText = "Jarvis is still running\nDouble click the system tray icon to bring him back.";
                        notifyIcon.ShowBalloonTip(1200);
                        break;
                    case (DialogResult.No):
                        notifyIcon.Visible = false;
                        terminating = true;
                        Application.Exit();
                        break;
                    case (DialogResult.Cancel):
                        e.Cancel = true;
                        break;
                }
            }
        }

        public static bool Win8ThemeEnabled
        {
            get
            {
                try
                {
                    return bool.Parse(new ModifyRegistry().Read("WIN8THEME"));
                }
                catch { return false; }
            }
        }

        private void writeToLogFile_Click(object sender, EventArgs e)
        {
            //Declares the safe file dialog variable, gives it a title, and sets the filter (files to be shown)
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save log as...";
            string now = DateTime.Now.ToString();
            string strip = now.Replace(":", "-");
            string strip2 = strip.Replace("/", "-");
            sfd.FileName = string.Format("Jarvis Log {0}.txt", strip2);
            sfd.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            DialogResult dr = sfd.ShowDialog(); //The user's choice stored into a variable
            switch(dr)
            {
                    //If they choose OK
                case(DialogResult.OK):
                    ExportLog el = new ExportLog(sfd.FileName, this);
                    el.ShowDialog();
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
            this.Cursor = Cursors.WaitCursor;
            Specs_Button.Enabled = false;
            Specs_Button.Text = "Loading specs..";
            SystemSpecsForm ss = new SystemSpecsForm(this);
            ss.Show();
            this.Cursor = Cursors.Default;
            Specs_Button.Enabled = true;
            Specs_Button.Text = "System Specs";
        }

        /// <summary>
        /// Returns a component's information from WMI
        /// </summary>
        /// <param name="hwclass">The hardware to return a certain value for</param>
        /// <param name="syntax">The value to be returned of the hardware</param>
        /// <returns></returns>
        public static string GetComponent(string hwclass, string syntax)
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
                foreach (ManagementObject mj in mos.Get())
                {
                    return mj[syntax].ToString();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR: Error while trying to retrieve {0} for {1}\n\tException: {2}", syntax, hwclass, ex.Message);
            }
            return "NULL";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm(); //Declares the AboutForm variable
            af.ShowDialog();                //Shows it as a dialog, meaning the user won't be able to interact with the elements below until this dialog is closed
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == false)
            { 
                this.Visible = true; 
                notifyIcon.Visible = false; 
            }
        }

        private void useWin8CheckBox_CheckedChanged(object sender, EventArgs e)
        {
                bool useWin8Theme = bool.Parse(new ModifyRegistry().Read("WIN8THEME"));
                if (useWin8Theme)
                {
                    useWin8CheckBox.Checked = false;
                    new ModifyRegistry().Write("WIN8THEME", false);
                    if(!appStartup)
                        MessageBox.Show("Theme changes will take effect on next application start.", "Jarvis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    useWin8CheckBox.Checked = true;
                    new ModifyRegistry().Write("WIN8THEME", true);
                    try
                    {
                        WindowBorderColor.WindowBorderColor.InitializeWindows8Theme(this);
                    }
                    catch
                    { }
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
#if DEBUG
            WindowsExperienceIndex wei = new WindowsExperienceIndex();
            wei.ShowDialog();
#endif
        }
        //
    }
}
