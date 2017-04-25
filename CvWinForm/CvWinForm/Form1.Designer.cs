namespace CvWinForm
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
            this.components = new System.ComponentModel.Container();
            this.ScreenShotTimer = new System.Windows.Forms.Timer(this.components);
            this.MainTab = new System.Windows.Forms.TabControl();
            this.NormalCam = new System.Windows.Forms.TabPage();
            this.CannyEdgeCam = new System.Windows.Forms.TabPage();
            this.picCanny = new System.Windows.Forms.PictureBox();
            this.picRaw = new System.Windows.Forms.PictureBox();
            this.MainTab.SuspendLayout();
            this.NormalCam.SuspendLayout();
            this.CannyEdgeCam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRaw)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.NormalCam);
            this.MainTab.Controls.Add(this.CannyEdgeCam);
            this.MainTab.Location = new System.Drawing.Point(0, 2);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(654, 440);
            this.MainTab.TabIndex = 0;
            // 
            // NormalCam
            // 
            this.NormalCam.Controls.Add(this.picRaw);
            this.NormalCam.Location = new System.Drawing.Point(4, 22);
            this.NormalCam.Name = "NormalCam";
            this.NormalCam.Padding = new System.Windows.Forms.Padding(3);
            this.NormalCam.Size = new System.Drawing.Size(646, 414);
            this.NormalCam.TabIndex = 0;
            this.NormalCam.Text = "Unfiltered";
            this.NormalCam.UseVisualStyleBackColor = true;
            // 
            // CannyEdgeCam
            // 
            this.CannyEdgeCam.Controls.Add(this.picCanny);
            this.CannyEdgeCam.Location = new System.Drawing.Point(4, 22);
            this.CannyEdgeCam.Name = "CannyEdgeCam";
            this.CannyEdgeCam.Padding = new System.Windows.Forms.Padding(3);
            this.CannyEdgeCam.Size = new System.Drawing.Size(646, 414);
            this.CannyEdgeCam.TabIndex = 1;
            this.CannyEdgeCam.Text = "CannyEdge";
            this.CannyEdgeCam.UseVisualStyleBackColor = true;
            // 
            // picCanny
            // 
            this.picCanny.Location = new System.Drawing.Point(-1, -1);
            this.picCanny.Name = "picCanny";
            this.picCanny.Size = new System.Drawing.Size(651, 419);
            this.picCanny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCanny.TabIndex = 0;
            this.picCanny.TabStop = false;
            // 
            // picRaw
            // 
            this.picRaw.Location = new System.Drawing.Point(-2, -2);
            this.picRaw.Name = "picRaw";
            this.picRaw.Size = new System.Drawing.Size(651, 419);
            this.picRaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRaw.TabIndex = 1;
            this.picRaw.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 438);
            this.Controls.Add(this.MainTab);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainTab.ResumeLayout(false);
            this.NormalCam.ResumeLayout(false);
            this.CannyEdgeCam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRaw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ScreenShotTimer;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage NormalCam;
        private System.Windows.Forms.TabPage CannyEdgeCam;
        private System.Windows.Forms.PictureBox picCanny;
        private System.Windows.Forms.PictureBox picRaw;
    }
}

