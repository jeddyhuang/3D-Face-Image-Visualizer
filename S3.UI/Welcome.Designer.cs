namespace S3.UI
{
    partial class Welcome
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
            this.btnFacialMorphology = new System.Windows.Forms.Button();
            this.btnVTK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFacialMorphology
            // 
            this.btnFacialMorphology.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacialMorphology.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacialMorphology.Location = new System.Drawing.Point(0, 0);
            this.btnFacialMorphology.Margin = new System.Windows.Forms.Padding(5);
            this.btnFacialMorphology.Name = "btnFacialMorphology";
            this.btnFacialMorphology.Size = new System.Drawing.Size(384, 40);
            this.btnFacialMorphology.TabIndex = 4;
            this.btnFacialMorphology.Text = "Facial Morphology";
            this.btnFacialMorphology.UseVisualStyleBackColor = true;
            this.btnFacialMorphology.Click += new System.EventHandler(this.btnFacialMorphology_Click);
            // 
            // btnVTK
            // 
            this.btnVTK.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVTK.Location = new System.Drawing.Point(0, 40);
            this.btnVTK.Margin = new System.Windows.Forms.Padding(5);
            this.btnVTK.Name = "btnVTK";
            this.btnVTK.Size = new System.Drawing.Size(384, 40);
            this.btnVTK.TabIndex = 6;
            this.btnVTK.Text = "C# VTK";
            this.btnVTK.UseVisualStyleBackColor = true;
            this.btnVTK.Click += new System.EventHandler(this.btnVTK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(0, 80);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(384, 40);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 121);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnVTK);
            this.Controls.Add(this.btnFacialMorphology);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Welcome";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rubin Xiao - Thesis Research";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFacialMorphology;
        private System.Windows.Forms.Button btnVTK;
        private System.Windows.Forms.Button btnExit;
    }
}

