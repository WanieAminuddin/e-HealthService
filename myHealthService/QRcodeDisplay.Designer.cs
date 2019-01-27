namespace myHealthService
{
    partial class QRcodeDisplay
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
            this.QRgenerate = new System.Windows.Forms.Button();
            this.QRcodeImage = new System.Windows.Forms.PictureBox();
            this.QRcontent = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.QRcodeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // QRgenerate
            // 
            this.QRgenerate.Location = new System.Drawing.Point(12, 199);
            this.QRgenerate.Name = "QRgenerate";
            this.QRgenerate.Size = new System.Drawing.Size(249, 32);
            this.QRgenerate.TabIndex = 1;
            this.QRgenerate.Text = "Generate QR Code";
            this.QRgenerate.UseVisualStyleBackColor = true;
            this.QRgenerate.Click += new System.EventHandler(this.QRgenerate_Click);
            // 
            // QRcodeImage
            // 
            this.QRcodeImage.Location = new System.Drawing.Point(12, 33);
            this.QRcodeImage.Name = "QRcodeImage";
            this.QRcodeImage.Size = new System.Drawing.Size(249, 160);
            this.QRcodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QRcodeImage.TabIndex = 2;
            this.QRcodeImage.TabStop = false;
            // 
            // QRcontent
            // 
            this.QRcontent.Location = new System.Drawing.Point(12, 7);
            this.QRcontent.Name = "QRcontent";
            this.QRcontent.Size = new System.Drawing.Size(249, 20);
            this.QRcontent.TabIndex = 3;
            // 
            // QRcodeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 248);
            this.Controls.Add(this.QRcontent);
            this.Controls.Add(this.QRcodeImage);
            this.Controls.Add(this.QRgenerate);
            this.Name = "QRcodeDisplay";
            this.Text = "QRcodeDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.QRcodeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button QRgenerate;
        private System.Windows.Forms.PictureBox QRcodeImage;
        private System.Windows.Forms.TextBox QRcontent;
    }
}