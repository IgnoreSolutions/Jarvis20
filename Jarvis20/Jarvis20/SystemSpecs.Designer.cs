namespace Jarvis20
{
    partial class SystemSpecs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSpecs));
            this.label1 = new System.Windows.Forms.Label();
            this.graphicsPictureBox = new System.Windows.Forms.PictureBox();
            this.procPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ramTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cdRomTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.networkTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.monitorTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.moboTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.soundCardTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.videoCardTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.procTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.osTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graphicsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "+";
            // 
            // graphicsPictureBox
            // 
            this.graphicsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.graphicsPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphicsPictureBox.Location = new System.Drawing.Point(384, 46);
            this.graphicsPictureBox.Name = "graphicsPictureBox";
            this.graphicsPictureBox.Size = new System.Drawing.Size(128, 128);
            this.graphicsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.graphicsPictureBox.TabIndex = 1;
            this.graphicsPictureBox.TabStop = false;
            this.toolTipHandler.SetToolTip(this.graphicsPictureBox, "Graphics Card Manufacturer");
            // 
            // procPictureBox
            // 
            this.procPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.procPictureBox.Location = new System.Drawing.Point(69, 46);
            this.procPictureBox.Name = "procPictureBox";
            this.procPictureBox.Size = new System.Drawing.Size(128, 128);
            this.procPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.procPictureBox.TabIndex = 0;
            this.procPictureBox.TabStop = false;
            this.toolTipHandler.SetToolTip(this.procPictureBox, "Processor Manufacturer");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.osTextBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ramTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cdRomTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.networkTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.monitorTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.moboTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.soundCardTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.videoCardTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.procTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(69, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 281);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Specifications";
            // 
            // ramTextBox
            // 
            this.ramTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ramTextBox.Location = new System.Drawing.Point(102, 83);
            this.ramTextBox.Name = "ramTextBox";
            this.ramTextBox.ReadOnly = true;
            this.ramTextBox.Size = new System.Drawing.Size(335, 20);
            this.ramTextBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Total RAM:";
            // 
            // cdRomTextBox
            // 
            this.cdRomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cdRomTextBox.Location = new System.Drawing.Point(102, 187);
            this.cdRomTextBox.Name = "cdRomTextBox";
            this.cdRomTextBox.ReadOnly = true;
            this.cdRomTextBox.Size = new System.Drawing.Size(335, 20);
            this.cdRomTextBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "CD Rom:";
            // 
            // networkTextBox
            // 
            this.networkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.networkTextBox.Location = new System.Drawing.Point(102, 31);
            this.networkTextBox.Name = "networkTextBox";
            this.networkTextBox.ReadOnly = true;
            this.networkTextBox.Size = new System.Drawing.Size(335, 20);
            this.networkTextBox.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Network Adapter:";
            // 
            // monitorTextBox
            // 
            this.monitorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.monitorTextBox.Location = new System.Drawing.Point(102, 215);
            this.monitorTextBox.Name = "monitorTextBox";
            this.monitorTextBox.ReadOnly = true;
            this.monitorTextBox.Size = new System.Drawing.Size(335, 20);
            this.monitorTextBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Monitor:";
            // 
            // moboTextBox
            // 
            this.moboTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.moboTextBox.Location = new System.Drawing.Point(102, 161);
            this.moboTextBox.Name = "moboTextBox";
            this.moboTextBox.ReadOnly = true;
            this.moboTextBox.Size = new System.Drawing.Size(335, 20);
            this.moboTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Motherboard:";
            // 
            // soundCardTextBox
            // 
            this.soundCardTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.soundCardTextBox.Location = new System.Drawing.Point(102, 135);
            this.soundCardTextBox.Name = "soundCardTextBox";
            this.soundCardTextBox.ReadOnly = true;
            this.soundCardTextBox.Size = new System.Drawing.Size(335, 20);
            this.soundCardTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sound Card:";
            // 
            // videoCardTextBox
            // 
            this.videoCardTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.videoCardTextBox.Location = new System.Drawing.Point(102, 109);
            this.videoCardTextBox.Name = "videoCardTextBox";
            this.videoCardTextBox.ReadOnly = true;
            this.videoCardTextBox.Size = new System.Drawing.Size(335, 20);
            this.videoCardTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Video Card:";
            // 
            // procTextBox
            // 
            this.procTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.procTextBox.Location = new System.Drawing.Point(102, 57);
            this.procTextBox.Name = "procTextBox";
            this.procTextBox.ReadOnly = true;
            this.procTextBox.Size = new System.Drawing.Size(335, 20);
            this.procTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Processor:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(417, 501);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(95, 49);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // osTextBox
            // 
            this.osTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.osTextBox.Location = new System.Drawing.Point(102, 243);
            this.osTextBox.Name = "osTextBox";
            this.osTextBox.ReadOnly = true;
            this.osTextBox.Size = new System.Drawing.Size(335, 20);
            this.osTextBox.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(70, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "OS:";
            // 
            // SystemSpecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 562);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphicsPictureBox);
            this.Controls.Add(this.procPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(613, 600);
            this.Name = "SystemSpecs";
            this.Text = "System Specifications";
            this.Load += new System.EventHandler(this.SystemSpecs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graphicsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox procPictureBox;
        private System.Windows.Forms.PictureBox graphicsPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTipHandler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox procTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cdRomTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox networkTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox monitorTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox moboTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox soundCardTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox videoCardTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ramTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox osTextBox;
        private System.Windows.Forms.Label label10;
    }
}