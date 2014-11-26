using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarvis20
{
    public class SystemSpecifications
    {
        public string NetworkAdapter;
        public string Processor;
        public string TotalRAMAvailable;
        public string VideoCard;
        public string SoundCard;
        public string Motherboard;
        public string CDRom;
        public string Monitor;
        public string OperatingSystem;


        public SystemSpecifications()
        {
            string network = MainForm.GetComponent("Win32_NetworkAdapter", "Name");
            string proc = MainForm.GetComponent("Win32_Processor", "Name");
            string clockSpeed = MainForm.GetComponent("Win32_Processor", "MaxClockSpeed");
            string arch = MainForm.GetComponent("Win32_Processor", "Architecture");
            string totalRam = MainForm.GetComponent("Win32_ComputerSystem", "TotalPhysicalMemory");
            string vidCard = MainForm.GetComponent("Win32_VideoController", "Name");
            string vidCard_RAM = MainForm.GetComponent("Win32_VideoController", "AdapterRAM");
            string soundCard = MainForm.GetComponent("Win32_SoundDevice", "Caption");
            string moboIdent = MainForm.GetComponent("Win32_BaseBoard", "Product");
            string cdRom = MainForm.GetComponent("Win32_CDROMDrive", "Name");
            string monitor = MainForm.GetComponent("Win32_DesktopMonitor", "Name");
            Microsoft.VisualBasic.Devices.ComputerInfo ci = new Microsoft.VisualBasic.Devices.ComputerInfo();
            string osVersion = ci.OSFullName;
            bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));
            //
            float totalRam_b = float.Parse(totalRam);
            float totalRam_mb = (totalRam_b / 1024f) / 1024f;
            float maxClockSpeedMhz = float.Parse(clockSpeed);
            float maxClockSpeedGhz = maxClockSpeedMhz / 1000f;
            float totalVidRam_b = float.Parse(vidCard_RAM);
            float totalVidRam_mb = (totalVidRam_b / 1024f) / 1024f;
            string mb_gb = string.Format("{1} GB ({0} MB)", totalRam_mb, Math.Round(totalRam_mb / 1024f, 2));
            //
            string proc_FINAL = string.Format("{0} @ {1}ghz; {2}-Bit", proc, maxClockSpeedGhz.ToString(), SystemSpecs.returnArchitecture(arch));
            string vid_FINAL = string.Format("{0} {1}GB ({2} MB)", vidCard, totalVidRam_mb / 1024f, totalVidRam_mb);
            string OS;
            if (Environment.Is64BitOperatingSystem)
                OS = osVersion + " 64-Bit";
            else
                OS = osVersion + " 32-Bit";
            //
            NetworkAdapter = network;
            Processor = proc_FINAL;
            TotalRAMAvailable = mb_gb;
            VideoCard = vid_FINAL;
            SoundCard = soundCard;
            Motherboard = moboIdent;
            CDRom = cdRom;
            Monitor = monitor;
            OperatingSystem = OS;
        }
    }
}
