namespace S3.UI
{
    partial class FacialMorphology
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
            this.ibLeft = new Emgu.CV.UI.ImageBox();
            this.ibFront = new Emgu.CV.UI.ImageBox();
            this.ibRight = new Emgu.CV.UI.ImageBox();
            this.btnLeftImage = new System.Windows.Forms.Button();
            this.btnFrontImage = new System.Windows.Forms.Button();
            this.btnRightImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ibLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibRight)).BeginInit();
            this.SuspendLayout();
            // 
            // ibLeft
            // 
            this.ibLeft.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ibLeft.Location = new System.Drawing.Point(12, 48);
            this.ibLeft.Name = "ibLeft";
            this.ibLeft.Size = new System.Drawing.Size(400, 700);
            this.ibLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ibLeft.TabIndex = 2;
            this.ibLeft.TabStop = false;
            // 
            // ibFront
            // 
            this.ibFront.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ibFront.Location = new System.Drawing.Point(418, 48);
            this.ibFront.Name = "ibFront";
            this.ibFront.Size = new System.Drawing.Size(400, 700);
            this.ibFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ibFront.TabIndex = 3;
            this.ibFront.TabStop = false;
            // 
            // ibRight
            // 
            this.ibRight.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ibRight.Location = new System.Drawing.Point(824, 48);
            this.ibRight.Name = "ibRight";
            this.ibRight.Size = new System.Drawing.Size(400, 700);
            this.ibRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ibRight.TabIndex = 4;
            this.ibRight.TabStop = false;
            // 
            // btnLeftImage
            // 
            this.btnLeftImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftImage.Location = new System.Drawing.Point(12, 12);
            this.btnLeftImage.Name = "btnLeftImage";
            this.btnLeftImage.Size = new System.Drawing.Size(140, 30);
            this.btnLeftImage.TabIndex = 6;
            this.btnLeftImage.Text = "Select a jpg/pos";
            this.btnLeftImage.UseVisualStyleBackColor = true;
            this.btnLeftImage.Click += new System.EventHandler(this.btnLeftImage_Click);
            // 
            // btnFrontImage
            // 
            this.btnFrontImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrontImage.Location = new System.Drawing.Point(418, 12);
            this.btnFrontImage.Name = "btnFrontImage";
            this.btnFrontImage.Size = new System.Drawing.Size(140, 30);
            this.btnFrontImage.TabIndex = 7;
            this.btnFrontImage.Text = "Select a jpg/pos";
            this.btnFrontImage.UseVisualStyleBackColor = true;
            this.btnFrontImage.Click += new System.EventHandler(this.btnFrontImage_Click);
            // 
            // btnRightImage
            // 
            this.btnRightImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightImage.Location = new System.Drawing.Point(824, 12);
            this.btnRightImage.Name = "btnRightImage";
            this.btnRightImage.Size = new System.Drawing.Size(140, 30);
            this.btnRightImage.TabIndex = 8;
            this.btnRightImage.Text = "Select a jpg/pos";
            this.btnRightImage.UseVisualStyleBackColor = true;
            this.btnRightImage.Click += new System.EventHandler(this.btnRightImage_Click);
            // 
            // FacialMorphology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 755);
            this.Controls.Add(this.btnRightImage);
            this.Controls.Add(this.btnFrontImage);
            this.Controls.Add(this.btnLeftImage);
            this.Controls.Add(this.ibRight);
            this.Controls.Add(this.ibFront);
            this.Controls.Add(this.ibLeft);
            this.Name = "FacialMorphology";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facial Morphology";
            ((System.ComponentModel.ISupportInitialize)(this.ibLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibLeft;
        private Emgu.CV.UI.ImageBox ibFront;
        private Emgu.CV.UI.ImageBox ibRight;
        private System.Windows.Forms.Button btnLeftImage;
        private System.Windows.Forms.Button btnFrontImage;
        private System.Windows.Forms.Button btnRightImage;
    }
}