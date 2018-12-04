namespace SapperApplication.Forms
{
    partial class PlantInfoForm
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
            this.goToTheFirstPlant = new System.Windows.Forms.Button();
            this.plantPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.plantGroupBox = new System.Windows.Forms.GroupBox();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.CoordinateLabel = new System.Windows.Forms.Label();
            this.PlantTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.plantPictureBox)).BeginInit();
            this.plantGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // goToTheFirstPlant
            // 
            this.goToTheFirstPlant.Location = new System.Drawing.Point(10, 199);
            this.goToTheFirstPlant.Name = "goToTheFirstPlant";
            this.goToTheFirstPlant.Size = new System.Drawing.Size(228, 28);
            this.goToTheFirstPlant.TabIndex = 0;
            this.goToTheFirstPlant.Text = "Go to the first plant";
            this.goToTheFirstPlant.UseVisualStyleBackColor = true;
            this.goToTheFirstPlant.Click += new System.EventHandler(this.goToTheFirstPlant_Click);
            // 
            // plantPictureBox
            // 
            this.plantPictureBox.Location = new System.Drawing.Point(255, 12);
            this.plantPictureBox.Name = "plantPictureBox";
            this.plantPictureBox.Size = new System.Drawing.Size(296, 215);
            this.plantPictureBox.TabIndex = 3;
            this.plantPictureBox.TabStop = false;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(10, 165);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(111, 28);
            this.buttonPrev.TabIndex = 4;
            this.buttonPrev.Text = "Previos";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(127, 165);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(111, 28);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // plantGroupBox
            // 
            this.plantGroupBox.Controls.Add(this.HealthLabel);
            this.plantGroupBox.Controls.Add(this.CoordinateLabel);
            this.plantGroupBox.Controls.Add(this.PlantTypeLabel);
            this.plantGroupBox.Location = new System.Drawing.Point(12, 12);
            this.plantGroupBox.Name = "plantGroupBox";
            this.plantGroupBox.Size = new System.Drawing.Size(226, 140);
            this.plantGroupBox.TabIndex = 6;
            this.plantGroupBox.TabStop = false;
            this.plantGroupBox.Text = "Plant";
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.Location = new System.Drawing.Point(6, 64);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(41, 13);
            this.HealthLabel.TabIndex = 5;
            this.HealthLabel.Text = "Health:";
            // 
            // CoordinateLabel
            // 
            this.CoordinateLabel.AutoSize = true;
            this.CoordinateLabel.Location = new System.Drawing.Point(6, 40);
            this.CoordinateLabel.Name = "CoordinateLabel";
            this.CoordinateLabel.Size = new System.Drawing.Size(95, 13);
            this.CoordinateLabel.TabIndex = 4;
            this.CoordinateLabel.Text = "Coordinate: x -; y -.";
            // 
            // PlantTypeLabel
            // 
            this.PlantTypeLabel.AutoSize = true;
            this.PlantTypeLabel.Location = new System.Drawing.Point(6, 19);
            this.PlantTypeLabel.Name = "PlantTypeLabel";
            this.PlantTypeLabel.Size = new System.Drawing.Size(60, 13);
            this.PlantTypeLabel.TabIndex = 3;
            this.PlantTypeLabel.Text = "Plant type: ";
            // 
            // PlantInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 239);
            this.Controls.Add(this.plantGroupBox);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.plantPictureBox);
            this.Controls.Add(this.goToTheFirstPlant);
            this.Name = "PlantInfoForm";
            this.Text = "Plant Info";
            this.Load += new System.EventHandler(this.PlantInfoForm_Load);
            this.Leave += new System.EventHandler(this.PlantInfoForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.plantPictureBox)).EndInit();
            this.plantGroupBox.ResumeLayout(false);
            this.plantGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button goToTheFirstPlant;
        private System.Windows.Forms.PictureBox plantPictureBox;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.GroupBox plantGroupBox;
        private System.Windows.Forms.Label CoordinateLabel;
        private System.Windows.Forms.Label PlantTypeLabel;
        private System.Windows.Forms.Label HealthLabel;
    }
}