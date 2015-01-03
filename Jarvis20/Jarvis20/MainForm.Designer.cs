namespace Jarvis20
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.timeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpuHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.uptimeTextBox = new System.Windows.Forms.TextBox();
            this.pauseButton = new System.Windows.Forms.Button();
            this.writeToLogFile = new System.Windows.Forms.Button();
            this.Specs_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.useWin8CheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeHeader,
            this.cpuHeader,
            this.memHeader});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(14, 15);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(632, 205);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // timeHeader
            // 
            this.timeHeader.Text = "Time";
            this.timeHeader.Width = 127;
            // 
            // cpuHeader
            // 
            this.cpuHeader.Text = "CPU Load (In %)";
            this.cpuHeader.Width = 273;
            // 
            // memHeader
            // 
            this.memHeader.Text = "Memory Left (In MB)";
            this.memHeader.Width = 225;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(14, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "UpTime";
            // 
            // uptimeTextBox
            // 
            this.uptimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uptimeTextBox.Location = new System.Drawing.Point(14, 270);
            this.uptimeTextBox.Name = "uptimeTextBox";
            this.uptimeTextBox.ReadOnly = true;
            this.uptimeTextBox.Size = new System.Drawing.Size(141, 20);
            this.uptimeTextBox.TabIndex = 3;
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pauseButton.Location = new System.Drawing.Point(553, 316);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(91, 45);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pause Jarvis";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // writeToLogFile
            // 
            this.writeToLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.writeToLogFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.writeToLogFile.Location = new System.Drawing.Point(553, 247);
            this.writeToLogFile.Name = "writeToLogFile";
            this.writeToLogFile.Size = new System.Drawing.Size(91, 43);
            this.writeToLogFile.TabIndex = 5;
            this.writeToLogFile.Text = "Write to Log";
            this.writeToLogFile.UseVisualStyleBackColor = true;
            this.writeToLogFile.Click += new System.EventHandler(this.writeToLogFile_Click);
            // 
            // Specs_Button
            // 
            this.Specs_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Specs_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Specs_Button.Location = new System.Drawing.Point(14, 316);
            this.Specs_Button.Name = "Specs_Button";
            this.Specs_Button.Size = new System.Drawing.Size(91, 45);
            this.Specs_Button.TabIndex = 6;
            this.Specs_Button.Text = "System Specs";
            this.Specs_Button.UseVisualStyleBackColor = true;
            this.Specs_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(279, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "Jarvis";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Jarvis";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // useWin8CheckBox
            // 
            this.useWin8CheckBox.AutoSize = true;
            this.useWin8CheckBox.Location = new System.Drawing.Point(111, 339);
            this.useWin8CheckBox.Name = "useWin8CheckBox";
            this.useWin8CheckBox.Size = new System.Drawing.Size(137, 17);
            this.useWin8CheckBox.TabIndex = 8;
            this.useWin8CheckBox.Text = "Use Windows 8 Theme";
            this.useWin8CheckBox.UseVisualStyleBackColor = true;
            this.useWin8CheckBox.CheckedChanged += new System.EventHandler(this.useWin8CheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 368);
            this.Controls.Add(this.useWin8CheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Specs_Button);
            this.Controls.Add(this.writeToLogFile);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.uptimeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(672, 406);
            this.Name = "MainForm";
            this.Text = "Jarvis Beta Build v2.75";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader timeHeader;
        private System.Windows.Forms.ColumnHeader cpuHeader;
        private System.Windows.Forms.ColumnHeader memHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uptimeTextBox;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button writeToLogFile;
        private System.Windows.Forms.Button Specs_Button;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox useWin8CheckBox;
    }
}

