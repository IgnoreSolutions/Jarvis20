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

namespace Jarvis20
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
        PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");

        public Form1()
        {
            Font = SystemFonts.MessageBoxFont;
            //Font = SystemFonts.GetFontByName("Comic Sans");
            InitializeComponent();
            perfUptimeCount.NextValue();
            perfCpuCount.NextValue();
            perfMemCount.NextValue();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            synth.Speak("Welcome to Jarvis version two point ohh, beta build");

        }

        private void GetCurrentInformation()
        {
            //Item: Time, Subitem 1: Cpu Subitem 2: Mem
            ListViewItem lvi = new ListViewItem();
            string currentDateTime = DateTime.Now.ToString();
            int curCpuPercentage = (int)perfCpuCount.NextValue();
            int curMemAvail = (int)perfMemCount.NextValue();
            lvi.Text = currentDateTime;
            lvi.SubItems.Add(curCpuPercentage.ToString());
            lvi.SubItems.Add(curMemAvail.ToString());

        }


    }
}
