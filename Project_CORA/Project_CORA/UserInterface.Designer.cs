namespace Project_CORA
{
    partial class UserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.manualDisplay = new System.Windows.Forms.RichTextBox();
            this.modList = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Asstatus = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectRobotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.PollJoyStick = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MainProcess = new System.ComponentModel.BackgroundWorker();
            this.robotPositionPanel = new System.Windows.Forms.Panel();
            this.povLabel = new System.Windows.Forms.Label();
            this.buttonLabel = new System.Windows.Forms.Label();
            this.axisLabel = new System.Windows.Forms.Label();
            this.baseRotationPanel = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Asstatus)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1156, 823);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1148, 794);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Camera feed";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.manualDisplay);
            this.tabPage2.Controls.Add(this.modList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1148, 794);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Module selection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // manualDisplay
            // 
            this.manualDisplay.Location = new System.Drawing.Point(254, 6);
            this.manualDisplay.Name = "manualDisplay";
            this.manualDisplay.Size = new System.Drawing.Size(888, 782);
            this.manualDisplay.TabIndex = 1;
            this.manualDisplay.Text = "";
            // 
            // modList
            // 
            this.modList.FormattingEnabled = true;
            this.modList.ItemHeight = 16;
            this.modList.Location = new System.Drawing.Point(6, 6);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(242, 468);
            this.modList.TabIndex = 0;
            this.modList.SelectedIndexChanged += new System.EventHandler(this.modList_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1148, 794);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Macro management";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1148, 794);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Options";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Asstatus
            // 
            this.Asstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Asstatus.Enabled = false;
            this.Asstatus.Location = new System.Drawing.Point(1174, 794);
            this.Asstatus.Maximum = 100;
            this.Asstatus.Minimum = -100;
            this.Asstatus.Name = "Asstatus";
            this.Asstatus.Size = new System.Drawing.Size(224, 56);
            this.Asstatus.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 30);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.connectionToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1410, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(52, 24);
            this.startToolStripMenuItem1.Text = "Start";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectRobotToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.connectionToolStripMenuItem.Text = "Connections";
            // 
            // connectRobotToolStripMenuItem
            // 
            this.connectRobotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.connectRobotToolStripMenuItem.Name = "connectRobotToolStripMenuItem";
            this.connectRobotToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.connectRobotToolStripMenuItem.Text = "Connect Robot";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(1167, 56);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(223, 38);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Current status";
            // 
            // PollJoyStick
            // 
            this.PollJoyStick.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PollJoyStick_DoWork);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainProcess
            // 
            this.MainProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // robotPositionPanel
            // 
            this.robotPositionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.robotPositionPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.robotPositionPanel.Location = new System.Drawing.Point(1174, 97);
            this.robotPositionPanel.Name = "robotPositionPanel";
            this.robotPositionPanel.Size = new System.Drawing.Size(224, 176);
            this.robotPositionPanel.TabIndex = 5;
            // 
            // povLabel
            // 
            this.povLabel.AutoSize = true;
            this.povLabel.Location = new System.Drawing.Point(1186, 774);
            this.povLabel.Name = "povLabel";
            this.povLabel.Size = new System.Drawing.Size(0, 17);
            this.povLabel.TabIndex = 5;
            // 
            // buttonLabel
            // 
            this.buttonLabel.AutoSize = true;
            this.buttonLabel.Location = new System.Drawing.Point(1256, 774);
            this.buttonLabel.Name = "buttonLabel";
            this.buttonLabel.Size = new System.Drawing.Size(0, 17);
            this.buttonLabel.TabIndex = 6;
            // 
            // axisLabel
            // 
            this.axisLabel.AutoSize = true;
            this.axisLabel.Location = new System.Drawing.Point(1186, 757);
            this.axisLabel.Name = "axisLabel";
            this.axisLabel.Size = new System.Drawing.Size(0, 17);
            this.axisLabel.TabIndex = 7;
            // 
            // baseRotationPanel
            // 
            this.baseRotationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baseRotationPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.baseRotationPanel.Location = new System.Drawing.Point(1190, 279);
            this.baseRotationPanel.Name = "baseRotationPanel";
            this.baseRotationPanel.Size = new System.Drawing.Size(200, 182);
            this.baseRotationPanel.TabIndex = 8;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1410, 866);
            this.Controls.Add(this.baseRotationPanel);
            this.Controls.Add(this.robotPositionPanel);
            this.Controls.Add(this.axisLabel);
            this.Controls.Add(this.buttonLabel);
            this.Controls.Add(this.povLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Asstatus);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserInterface";
            this.Text = "CORA";
            this.Load += new System.EventHandler(this.Hoofdscherm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Asstatus)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectRobotToolStripMenuItem;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.ComponentModel.BackgroundWorker PollJoyStick;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox manualDisplay;
        private System.Windows.Forms.ListBox modList;
        private System.ComponentModel.BackgroundWorker MainProcess;
        public System.Windows.Forms.TrackBar Asstatus;
        private System.Windows.Forms.Panel robotPositionPanel;
        private System.Windows.Forms.Label povLabel;
        private System.Windows.Forms.Label buttonLabel;
        private System.Windows.Forms.Label axisLabel;
        private System.Windows.Forms.Panel baseRotationPanel;
    }
}

