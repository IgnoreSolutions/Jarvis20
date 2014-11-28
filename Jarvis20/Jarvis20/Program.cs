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
                loop();
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
        #region Voids that don't matter
        static SpeechSynthesizer synth = new SpeechSynthesizer();
        static void loop()
        {
            #region Speech
            // This will greet the user in the default voice
            Version ver = Assembly.GetEntryAssembly().GetName().Version; //The executable stores a version too, this retrieves it. This is much more accurate
            synth.Speak(String.Format("Welcome to Jarvis version {0}.{1}, beta build", ver.Major, ver.Minor));
            #endregion

            Console.ForegroundColor = ConsoleColor.Green;

            #region My performance Counters
            // This will pull the current CPU load in percentage
            PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor time", "_Total");

            // This will pull the current avaible memory in Megabytes
            PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");

            // This tells how long the system has been running. (in seconds)
            PerformanceCounter perfUpTimeCount = new PerformanceCounter("System", "System Up Time");
            perfUpTimeCount.NextValue();
            #endregion

            #region Time Spans!
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUpTimeCount.NextValue());
            string systemUptimeMessage = string.Format("The current amount of time your system has been up is {0} hours, and {1} minutes",
                (int)uptimeSpan.Hours,
                (int)uptimeSpan.Minutes
                );

            // Tells the user what the current system uptimes is!
            Speak(systemUptimeMessage, VoiceGender.Male, 2);

            #endregion


            #region Infinite Loop

            int speechSpeed = 1;

            // Infinite While Loop
            while (true)
            {
                
                int curCpuPercentage = (int)perfCpuCount.NextValue();
                int curMemAvail = (int)perfMemCount.NextValue();

                Console.WriteLine("CPU Usage:       {0}%", curCpuPercentage);
                Console.WriteLine("Mem Available:   {0}MB", curMemAvail);

                //Scroll down to the bottom
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
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Speaks with a selected voice
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voiceGender"></param"
        public static void Speak(string message, VoiceGender voiceGender)
        {
            synth.SelectVoiceByHints(VoiceGender.Male);
            synth.Speak(message);
        }

        /// <summary>
        /// Speaks with a selected voice at a selected voice
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voiceGender"></param"
        public static void Speak(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            Speak(message, voiceGender);
        }

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        //
            #endregion
        #endregion
    }
}
