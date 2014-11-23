namespace Jarvis20
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.timeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpuHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.uptimeTextBox = new System.Windows.Forms.TextBox();
            this.pauseButton = new System.Windows.Forms.Button();
            this.writeToLogFile = new System.Windows.Forms.Button();
            this.CPUTemp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Specs_Button = new System.Windows.Forms.Button();
            this.GpuTemp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.memHeader,
            this.CPUTemp,
            this.GpuTemp});
            this.listView1.Location = new System.Drawing.Point(16, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(771, 331);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // timeHeader
            // 
            this.timeHeader.Text = "Time";
            this.timeHeader.Width = 139;
            // 
            // cpuHeader
            // 
            this.cpuHeader.Text = "CPU Load (In %)";
            this.cpuHeader.Width = 125;
            // 
            // memHeader
            // 
            this.memHeader.Text = "Memory Left (In MB)";
            this.memHeader.Width = 167;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "UpTime";
            // 
            // uptimeTextBox
            // 
            this.uptimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uptimeTextBox.Location = new System.Drawing.Point(12, 372);
            this.uptimeTextBox.Name = "uptimeTextBox";
            this.uptimeTextBox.ReadOnly = true;
            this.uptimeTextBox.Size = new System.Drawing.Size(141, 20);
            this.uptimeTextBox.TabIndex = 3;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(692, 418);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(91, 45);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pause Jarvis";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // writeToLogFile
            // 
            this.writeToLogFile.Location = new System.Drawing.Point(692, 349);
            this.writeToLogFile.Name = "writeToLogFile";
            this.writeToLogFile.Size = new System.Drawing.Size(91, 43);
            this.writeToLogFile.TabIndex = 5;
            this.writeToLogFile.Text = "Write to Log";
            this.writeToLogFile.UseVisualStyleBackColor = true;
            this.writeToLogFile.Click += new System.EventHandler(this.writeToLogFile_Click);
            // 
            // CPUTemp
            // 
            this.CPUTemp.Text = "CPU Tempeture";
            this.CPUTemp.Width = 102;
            // 
            // Specs_Button
            // 
            this.Specs_Button.Location = new System.Drawing.Point(12, 418);
            this.Specs_Button.Name = "Specs_Button";
            this.Specs_Button.Size = new System.Drawing.Size(91, 45);
            this.Specs_Button.TabIndex = 6;
            this.Specs_Button.Text = "System Specs";
            this.Specs_Button.UseVisualStyleBackColor = true;
            this.Specs_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // GpuTemp
            // 
            this.GpuTemp.Text = "GPU Tempeture";
            this.GpuTemp.Width = 103;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 493);
            this.Controls.Add(this.Specs_Button);
            this.Controls.Add(this.writeToLogFile);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.uptimeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Jarvis Beta Build v2.45";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader timeHeader;
        private System.Windows.Forms.ColumnHeader cpuHeader;
        private System.Windows.Forms.ColumnHeader memHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uptimeTextBox;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button writeToLogFile;
        private System.Windows.Forms.ColumnHeader CPUTemp;
        private System.Windows.Forms.Button Specs_Button;
        private System.Windows.Forms.ColumnHeader GpuTemp;
    }
}

