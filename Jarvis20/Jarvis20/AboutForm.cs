using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace Jarvis20
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            if (DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows8 | DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows81)
                WindowBorderColor.WindowBorderColor.InitializeWindows8Theme(this);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Version ver = Assembly.GetEntryAssembly().GetName().Version; //The executable stores a version too, this retrieves it. This is much more accurate
            versionLabel.Text = String.Format("v{0}.{1}", ver.Major, ver.Minor);
            //
            if (DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows7)
            {   
                titleLabel.Text = "Jarvette";
                titleLabel.Location = new Point(titleLabel.Location.X - 5, titleLabel.Location.Y);
            }

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form when the ok button is clicked
        }

        private void iconPictureBox_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SelectVoiceByHints(VoiceGender.Male);
            Random r = new Random();
            r.Next(6);
            int res = r.Next(6);
            string whatToSay = "";
            switch(res)
            {
                case(0):
                    whatToSay = "I came here to kick ass and chew bubble gum, and I'm all out of bubble gum";
                    break;
                case(1):
                    if (DetectOperatingSystem.OSName() == DetectOperatingSystem.OSFriendly.Windows7)
                        whatToSay = "I've got ovaries of steel";
                    else
                        whatToSay = "I've got balls of steel";
                    break;
                case(2):
                    whatToSay = "Hail to the king, baby";
                    break;
                case(3):
                    whatToSay = "My boot, your face: the perfect couple";
                    break;
                case(4):
                    whatToSay = "I'm an equal opportunity ass kicker";
                    break;
                case(5):
                    whatToSay = "You're an inspiration for birth control";
                    break;
                case(6):
                    whatToSay = "Your ass is grass, and I've got the weed whacker";
                    break;
            }
            synth.Speak(whatToSay);
        }
    }
}
