using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jarvis20
{
    public partial class SystemSpecs : Form
    {
        public SystemSpecs()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SystemSpecs_Load(object sender, EventArgs e)
        {
            //load in values
            networkTextBox.Focus();
            loadInValues();
        }

        private void loadInValues()
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
            //
            float totalRam_b = float.Parse(totalRam);
            float totalRam_mb = (totalRam_b / 1024f) / 1024f;
            float maxClockSpeedMhz = float.Parse(clockSpeed);
            float maxClockSpeedGhz = maxClockSpeedMhz / 1000f;
            float totalVidRam_b = float.Parse(vidCard_RAM);
            float totalVidRam_mb = (totalVidRam_b / 1024f) / 1024f;
            string mb_gb = string.Format("{1} GB ({0} MB)", totalRam_mb, Math.Round(totalRam_mb / 1024f, 2));
            //
            networkTextBox.Text = network;
            procTextBox.Text = string.Format("{0} @ {1}ghz; {2}-Bit", proc, maxClockSpeedGhz.ToString(), returnArchitecture(arch));
            ramTextBox.Text = mb_gb.ToString();
            videoCardTextBox.Text = string.Format("{0} {1}GB ({2} MB)", vidCard, totalVidRam_mb / 1024f, totalVidRam_mb);
            soundCardTextBox.Text = soundCard;
            moboTextBox.Text = moboIdent;
            cdRomTextBox.Text = cdRom;
            monitorTextBox.Text = monitor;
            //
            procPictureBox.Image = detectCpuManufacturer(proc);
            graphicsPictureBox.Image = detectGpuManufacturer(vidCard);

        }

        private Bitmap detectCpuManufacturer(string toDetect)
        {
            if (toDetect.IndexOf("amd", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return Jarvis20.Properties.Resources.amd_logo;
            }
            else if (toDetect.IndexOf("intel", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return Jarvis20.Properties.Resources.intel_logo;
            }
            return null;
        }

        private Bitmap detectGpuManufacturer(string toDetect)
        {
            if(toDetect.IndexOf("radeon", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return Jarvis20.Properties.Resources.amd_radeon_logo;
            }
            else if (toDetect.IndexOf("nvidia", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return Jarvis20.Properties.Resources.nvidia_logo;
            }
            else if (toDetect.IndexOf("intel", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return Jarvis20.Properties.Resources.intel_graphics;
            }
            return null;
        }

        private string returnArchitecture(string toDetect)
        {
            int bit = int.Parse(toDetect);
            switch(bit)
            {
                case(9):
                    return "AMD64";
                    break;
                case(6):
                    return "IA64";
                    break;
                case(0):
                    return "32";
                    break;
            }

            return null;
        }
        //
    }
}
