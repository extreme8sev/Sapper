namespace SapperApplication.Forms
{
    public partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.GameField = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cursorSelector = new System.Windows.Forms.GroupBox();
            this.cursorType = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SapperScoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.cursorSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameField
            // 
            this.GameField.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GameField.Location = new System.Drawing.Point(12, 53);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(119, 83);
            this.GameField.TabIndex = 1;
            this.GameField.TabStop = false;
            this.GameField.Click += new System.EventHandler(this.GameField_DoubleClick);
            this.GameField.DoubleClick += new System.EventHandler(this.GameField_DoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(133, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add 2 plants";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cursorSelector
            // 
            this.cursorSelector.Controls.Add(this.cursorType);
            this.cursorSelector.Location = new System.Drawing.Point(682, 24);
            this.cursorSelector.Name = "cursorSelector";
            this.cursorSelector.Size = new System.Drawing.Size(200, 180);
            this.cursorSelector.TabIndex = 3;
            this.cursorSelector.TabStop = false;
            this.cursorSelector.Text = "Select your cursor";
            // 
            // cursorType
            // 
            this.cursorType.FormattingEnabled = true;
            this.cursorType.Items.AddRange(new object[] {
            "Cursor",
            "Create bryozoa"});
            this.cursorType.Location = new System.Drawing.Point(9, 19);
            this.cursorType.Name = "cursorType";
            this.cursorType.Size = new System.Drawing.Size(185, 21);
            this.cursorType.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(255, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "Start the game";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SapperScoreLabel
            // 
            this.SapperScoreLabel.AutoSize = true;
            this.SapperScoreLabel.Location = new System.Drawing.Point(384, 13);
            this.SapperScoreLabel.Name = "SapperScoreLabel";
            this.SapperScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.SapperScoreLabel.TabIndex = 5;
            this.SapperScoreLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 277);
            this.Controls.Add(this.SapperScoreLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cursorSelector);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.cursorSelector.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox cursorSelector;
        private System.Windows.Forms.ComboBox cursorType;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label SapperScoreLabel;
    }
}

