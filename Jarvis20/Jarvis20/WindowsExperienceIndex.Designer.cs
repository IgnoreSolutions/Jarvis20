namespace Jarvis20
{
    partial class WindowsExperienceIndex
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
            this.overallRating = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.overallRating)).BeginInit();
            this.SuspendLayout();
            // 
            // overallRating
            // 
            this.overallRating.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.overallRating.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.overallRating.Location = new System.Drawing.Point(459, 60);
            this.overallRating.Name = "overallRating";
            this.overallRating.Size = new System.Drawing.Size(128, 128);
            this.overallRating.TabIndex = 0;
            this.overallRating.TabStop = false;
            // 
            // WindowsExperienceIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 342);
            this.Controls.Add(this.overallRating);
            this.Name = "WindowsExperienceIndex";
            this.Text = "WindowsExperienceIndex";
            ((System.ComponentModel.ISupportInitialize)(this.overallRating)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox overallRating;

    }
}