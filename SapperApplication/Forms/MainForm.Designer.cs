namespace SapperApplication.Forms
{
    public partial class MainForm
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
            this.testButton = new System.Windows.Forms.Button();
            this.gameFieldPictureBox = new System.Windows.Forms.PictureBox();
            this.addPlantsButton = new System.Windows.Forms.Button();
            this.cursorSelectorGroupBox = new System.Windows.Forms.GroupBox();
            this.cursorType = new System.Windows.Forms.ComboBox();
            this.startTheGameButton = new System.Windows.Forms.Button();
            this.SapperScoreLabel = new System.Windows.Forms.Label();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainToolboxFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.innerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.rightToolboxFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PlantInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameFieldPictureBox)).BeginInit();
            this.cursorSelectorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.mainToolboxFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.innerSplitContainer)).BeginInit();
            this.innerSplitContainer.Panel1.SuspendLayout();
            this.innerSplitContainer.Panel2.SuspendLayout();
            this.innerSplitContainer.SuspendLayout();
            this.rightToolboxFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(107, 3);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(116, 34);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "ReDraw";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // gameFieldPictureBox
            // 
            this.gameFieldPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gameFieldPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameFieldPictureBox.Location = new System.Drawing.Point(0, 0);
            this.gameFieldPictureBox.Name = "gameFieldPictureBox";
            this.gameFieldPictureBox.Size = new System.Drawing.Size(923, 485);
            this.gameFieldPictureBox.TabIndex = 1;
            this.gameFieldPictureBox.TabStop = false;
            this.gameFieldPictureBox.Click += new System.EventHandler(this.gameFieldPictureBox_Click);
            this.gameFieldPictureBox.DoubleClick += new System.EventHandler(this.gameFieldPictureBox_DoubleClick);
            // 
            // addPlantsButton
            // 
            this.addPlantsButton.Location = new System.Drawing.Point(229, 3);
            this.addPlantsButton.Name = "addPlantsButton";
            this.addPlantsButton.Size = new System.Drawing.Size(116, 34);
            this.addPlantsButton.TabIndex = 2;
            this.addPlantsButton.Text = "Add 2 plants";
            this.addPlantsButton.UseVisualStyleBackColor = true;
            this.addPlantsButton.Click += new System.EventHandler(this.addPlantsButton_Click);
            // 
            // cursorSelectorGroupBox
            // 
            this.cursorSelectorGroupBox.Controls.Add(this.cursorType);
            this.cursorSelectorGroupBox.Location = new System.Drawing.Point(3, 3);
            this.cursorSelectorGroupBox.Name = "cursorSelectorGroupBox";
            this.cursorSelectorGroupBox.Size = new System.Drawing.Size(200, 45);
            this.cursorSelectorGroupBox.TabIndex = 3;
            this.cursorSelectorGroupBox.TabStop = false;
            this.cursorSelectorGroupBox.Text = "Select your cursor";
            // 
            // cursorType
            // 
            this.cursorType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cursorType.FormattingEnabled = true;
            this.cursorType.Items.AddRange(new object[] {
            "Cursor",
            "Create bryozoa"});
            this.cursorType.Location = new System.Drawing.Point(3, 16);
            this.cursorType.Name = "cursorType";
            this.cursorType.Size = new System.Drawing.Size(194, 21);
            this.cursorType.TabIndex = 1;
            // 
            // startTheGameButton
            // 
            this.startTheGameButton.Location = new System.Drawing.Point(351, 3);
            this.startTheGameButton.Name = "startTheGameButton";
            this.startTheGameButton.Size = new System.Drawing.Size(112, 34);
            this.startTheGameButton.TabIndex = 4;
            this.startTheGameButton.Text = "Start the game";
            this.startTheGameButton.UseVisualStyleBackColor = true;
            this.startTheGameButton.Click += new System.EventHandler(this.startTheGameButton_Click);
            // 
            // SapperScoreLabel
            // 
            this.SapperScoreLabel.AutoSize = true;
            this.SapperScoreLabel.Location = new System.Drawing.Point(510, 11);
            this.SapperScoreLabel.Margin = new System.Windows.Forms.Padding(3, 11, 3, 0);
            this.SapperScoreLabel.Name = "SapperScoreLabel";
            this.SapperScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.SapperScoreLabel.TabIndex = 5;
            this.SapperScoreLabel.Text = "label1";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.mainToolboxFlowPanel);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.innerSplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(1134, 527);
            this.mainSplitContainer.SplitterDistance = 38;
            this.mainSplitContainer.TabIndex = 6;
            // 
            // mainToolboxFlowPanel
            // 
            this.mainToolboxFlowPanel.AutoSize = true;
            this.mainToolboxFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainToolboxFlowPanel.Controls.Add(this.PlantInfo);
            this.mainToolboxFlowPanel.Controls.Add(this.testButton);
            this.mainToolboxFlowPanel.Controls.Add(this.addPlantsButton);
            this.mainToolboxFlowPanel.Controls.Add(this.startTheGameButton);
            this.mainToolboxFlowPanel.Controls.Add(this.InfoLabel);
            this.mainToolboxFlowPanel.Controls.Add(this.SapperScoreLabel);
            this.mainToolboxFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolboxFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.mainToolboxFlowPanel.Name = "mainToolboxFlowPanel";
            this.mainToolboxFlowPanel.Size = new System.Drawing.Size(1134, 38);
            this.mainToolboxFlowPanel.TabIndex = 0;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(469, 11);
            this.InfoLabel.Margin = new System.Windows.Forms.Padding(3, 11, 3, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(35, 13);
            this.InfoLabel.TabIndex = 7;
            this.InfoLabel.Text = "label1";
            // 
            // innerSplitContainer
            // 
            this.innerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.innerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.innerSplitContainer.Name = "innerSplitContainer";
            // 
            // innerSplitContainer.Panel1
            // 
            this.innerSplitContainer.Panel1.Controls.Add(this.gameFieldPictureBox);
            // 
            // innerSplitContainer.Panel2
            // 
            this.innerSplitContainer.Panel2.Controls.Add(this.rightToolboxFlowPanel);
            this.innerSplitContainer.Size = new System.Drawing.Size(1134, 485);
            this.innerSplitContainer.SplitterDistance = 923;
            this.innerSplitContainer.TabIndex = 7;
            // 
            // rightToolboxFlowPanel
            // 
            this.rightToolboxFlowPanel.Controls.Add(this.cursorSelectorGroupBox);
            this.rightToolboxFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightToolboxFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.rightToolboxFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.rightToolboxFlowPanel.Name = "rightToolboxFlowPanel";
            this.rightToolboxFlowPanel.Size = new System.Drawing.Size(207, 485);
            this.rightToolboxFlowPanel.TabIndex = 0;
            // 
            // PlantInfo
            // 
            this.PlantInfo.Location = new System.Drawing.Point(3, 3);
            this.PlantInfo.Name = "PlantInfo";
            this.PlantInfo.Size = new System.Drawing.Size(98, 32);
            this.PlantInfo.TabIndex = 8;
            this.PlantInfo.Text = "Open plant info";
            this.PlantInfo.UseVisualStyleBackColor = true;
            this.PlantInfo.Click += new System.EventHandler(this.PlantInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 527);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "MainForm";
            this.Text = "The Game Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameFieldPictureBox)).EndInit();
            this.cursorSelectorGroupBox.ResumeLayout(false);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.mainToolboxFlowPanel.ResumeLayout(false);
            this.mainToolboxFlowPanel.PerformLayout();
            this.innerSplitContainer.Panel1.ResumeLayout(false);
            this.innerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.innerSplitContainer)).EndInit();
            this.innerSplitContainer.ResumeLayout(false);
            this.rightToolboxFlowPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.PictureBox gameFieldPictureBox;
        private System.Windows.Forms.Button addPlantsButton;
        private System.Windows.Forms.GroupBox cursorSelectorGroupBox;
        private System.Windows.Forms.ComboBox cursorType;
        private System.Windows.Forms.Button startTheGameButton;
        private System.Windows.Forms.Label SapperScoreLabel;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.FlowLayoutPanel mainToolboxFlowPanel;
        private System.Windows.Forms.SplitContainer innerSplitContainer;
        private System.Windows.Forms.FlowLayoutPanel rightToolboxFlowPanel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button PlantInfo;
    }
}

