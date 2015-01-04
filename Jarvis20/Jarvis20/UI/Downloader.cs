using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jarvis20.UI
{
    public partial class Downloader : Form
    {
        private string _url { get; set; }
        private string _fileName { get; set; }

        public Downloader(string url, string fileName)
        {
            Font = SystemFonts.MessageBoxFont;
            _url = url;
            _fileName = fileName;
            InitializeComponent();
        }

        private void startDownload()
        {
            Thread t = new Thread(() => {
                WebClient wc = new WebClient();
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(_url), Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + _fileName);
            });
            t.Start();
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                statusLabel.Text = "Download complete!";
                Thread.Sleep(2000);
                this.Close();
            });
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                statusLabel.Text = string.Format("Downloaded {0}kb / {1}kb", (e.BytesReceived * 1024), (e.TotalBytesToReceive * 1024));
                progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
    }
}
