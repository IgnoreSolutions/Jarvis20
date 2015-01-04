using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jarvis20.UI
{
    public partial class ProcessRunner : Form
    {
        Process _p { get; set; }

        public ProcessRunner()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }
        public ProcessRunner(Process p)
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            _p = p;
        }
        public ProcessRunner(Process p, string processName)
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            _p = p;
            this.Text = "Running " + processName + "...";
        }

        private void Run()
        {
            Thread.Sleep(3000);
            procOutputLabel.Text = "Ready?";
            if (_p != null)
            {
                try
                {

                    _p.StartInfo.RedirectStandardOutput = true;
                    _p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    _p.StartInfo.UseShellExecute = false;
                    _p.Start();
                    while (!_p.StandardOutput.EndOfStream)
                    {
                        procOutputLabel.Text = _p.StandardOutput.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error ocurred while running the process!\n\nError Message: " + ex.Message, "Jarvis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                procOutputLabel.Text = "Done!";
                Thread.Sleep(2000);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ProcessRunner_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(Run);
            t.Start();
        }
    }
}
