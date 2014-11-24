using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Jarvis20
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Version ver = Assembly.GetEntryAssembly().GetName().Version; //The executable stores a version too, this retrieves it. This is much more accurate
            versionLabel.Text = String.Format("v{0}.{1}", ver.Major, ver.Minor);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form when the ok button is clicked
        }
    }
}
