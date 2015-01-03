namespace Jarvis20
{
    partial class ExportLog
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
            this.exportSystemSpecifications = new System.Windows.Forms.CheckBox();
            this.exportCurrentSystemUptime = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logPreviewTextBox = new System.Windows.Forms.RichTextBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportSystemSpecifications
            // 
            this.exportSystemSpecifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportSystemSpecifications.AutoSize = true;
            this.exportSystemSpecifications.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exportSystemSpecifications.Location = new System.Drawing.Point(12, 341);
            this.exportSystemSpecifications.Name = "exportSystemSpecifications";
            this.exportSystemSpecifications.Size = new System.Drawing.Size(168, 18);
            this.exportSystemSpecifications.TabIndex = 0;
            this.exportSystemSpecifications.Text = "Export System Specifications";
            this.exportSystemSpecifications.UseVisualStyleBackColor = true;
            this.exportSystemSpecifications.CheckedChanged += new System.EventHandler(this.exportSystemSpecifications_CheckedChanged);
            // 
            // exportCurrentSystemUptime
            // 
            this.exportCurrentSystemUptime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportCurrentSystemUptime.AutoSize = true;
            this.exportCurrentSystemUptime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exportCurrentSystemUptime.Location = new System.Drawing.Point(12, 364);
            this.exportCurrentSystemUptime.Name = "exportCurrentSystemUptime";
            this.exportCurrentSystemUptime.Size = new System.Drawing.Size(179, 18);
            this.exportCurrentSystemUptime.TabIndex = 1;
            this.exportCurrentSystemUptime.Text = "Export Current System Up-Time";
            this.exportCurrentSystemUptime.UseVisualStyleBackColor = true;
            this.exportCurrentSystemUptime.CheckedChanged += new System.EventHandler(this.exportCurrentSystemUptime_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logPreviewTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 293);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log Preview";
            // 
            // logPreviewTextBox
            // 
            this.logPreviewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPreviewTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logPreviewTextBox.Location = new System.Drawing.Point(3, 16);
            this.logPreviewTextBox.Name = "logPreviewTextBox";
            this.logPreviewTextBox.Size = new System.Drawing.Size(451, 274);
            this.logPreviewTextBox.TabIndex = 0;
            this.logPreviewTextBox.Text = "";
            this.logPreviewTextBox.ZoomFactor = 1.2F;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exportButton.Location = new System.Drawing.Point(289, 359);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(370, 359);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "*Values shown in preview are EXAMPLE values";
            // 
            // ExportLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 392);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exportCurrentSystemUptime);
            this.Controls.Add(this.exportSystemSpecifications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Export Options";
            this.Load += new System.EventHandler(this.ExportLog_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox exportSystemSpecifications;
        private System.Windows.Forms.CheckBox exportCurrentSystemUptime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RichTextBox logPreviewTextBox;
        private System.Windows.Forms.Label label1;
    }
}