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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectRobotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSchemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calmMetallicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteAndBlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superFancyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.PollJoyStick = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MainProcess = new System.ComponentModel.BackgroundWorker();
            this.robotPositionPanel = new System.Windows.Forms.Panel();
            this.povLabel = new System.Windows.Forms.Label();
            this.buttonLabel = new System.Windows.Forms.Label();
            this.axisLabel = new System.Windows.Forms.Label();
            this.baseRotationPanel = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.Button();
            this.positionPanelLabel = new System.Windows.Forms.Label();
            this.rotationPanelLabel = new System.Windows.Forms.Label();
            this.frameLabelPosition = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.runQueueButton = new System.Windows.Forms.Button();
            this.deleteMacroButton = new System.Windows.Forms.Button();
            this.macroDescription = new System.Windows.Forms.RichTextBox();
            this.createMacroButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.macroProgressBar = new System.Windows.Forms.ProgressBar();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.macroQueue = new System.Windows.Forms.ListBox();
            this.macroList = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.equipButton = new System.Windows.Forms.Button();
            this.manualDisplay = new System.Windows.Forms.RichTextBox();
            this.modList = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.speedSettingSlider = new System.Windows.Forms.TrackBar();
            this.axisPositionBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.moduleTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedSettingSlider)).BeginInit();
            this.SuspendLayout();
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
            this.quitToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1377, 28);
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
            this.connectRobotToolStripMenuItem,
            this.connectToolStripMenuItem});
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
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorSchemeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // colorSchemeToolStripMenuItem
            // 
            this.colorSchemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calmMetallicToolStripMenuItem,
            this.matrixToolStripMenuItem,
            this.whiteAndBlandToolStripMenuItem,
            this.superFancyToolStripMenuItem,
            this.kinkyToolStripMenuItem});
            this.colorSchemeToolStripMenuItem.Name = "colorSchemeToolStripMenuItem";
            this.colorSchemeToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.colorSchemeToolStripMenuItem.Text = "Color Scheme";
            // 
            // calmMetallicToolStripMenuItem
            // 
            this.calmMetallicToolStripMenuItem.Name = "calmMetallicToolStripMenuItem";
            this.calmMetallicToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.calmMetallicToolStripMenuItem.Text = "Calm Metallic";
            this.calmMetallicToolStripMenuItem.Click += new System.EventHandler(this.calmMetallicToolStripMenuItem_Click);
            // 
            // matrixToolStripMenuItem
            // 
            this.matrixToolStripMenuItem.Name = "matrixToolStripMenuItem";
            this.matrixToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.matrixToolStripMenuItem.Text = "Matrix";
            this.matrixToolStripMenuItem.Click += new System.EventHandler(this.matrixToolStripMenuItem_Click);
            // 
            // whiteAndBlandToolStripMenuItem
            // 
            this.whiteAndBlandToolStripMenuItem.Name = "whiteAndBlandToolStripMenuItem";
            this.whiteAndBlandToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.whiteAndBlandToolStripMenuItem.Text = "White and bland";
            this.whiteAndBlandToolStripMenuItem.Click += new System.EventHandler(this.whiteAndBlandToolStripMenuItem_Click);
            // 
            // superFancyToolStripMenuItem
            // 
            this.superFancyToolStripMenuItem.Name = "superFancyToolStripMenuItem";
            this.superFancyToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.superFancyToolStripMenuItem.Text = "Super Fancy";
            this.superFancyToolStripMenuItem.Click += new System.EventHandler(this.superFancyToolStripMenuItem_Click);
            // 
            // kinkyToolStripMenuItem
            // 
            this.kinkyToolStripMenuItem.Name = "kinkyToolStripMenuItem";
            this.kinkyToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.kinkyToolStripMenuItem.Text = "Kinky";
            this.kinkyToolStripMenuItem.Click += new System.EventHandler(this.kinkyToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(1134, 56);
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
            this.robotPositionPanel.Location = new System.Drawing.Point(1157, 118);
            this.robotPositionPanel.Name = "robotPositionPanel";
            this.robotPositionPanel.Size = new System.Drawing.Size(200, 235);
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
            this.baseRotationPanel.Location = new System.Drawing.Point(1157, 376);
            this.baseRotationPanel.Name = "baseRotationPanel";
            this.baseRotationPanel.Size = new System.Drawing.Size(200, 182);
            this.baseRotationPanel.TabIndex = 8;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(1203, 732);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // positionPanelLabel
            // 
            this.positionPanelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.positionPanelLabel.AutoSize = true;
            this.positionPanelLabel.Location = new System.Drawing.Point(1142, 95);
            this.positionPanelLabel.Name = "positionPanelLabel";
            this.positionPanelLabel.Size = new System.Drawing.Size(136, 17);
            this.positionPanelLabel.TabIndex = 10;
            this.positionPanelLabel.Text = "Current arm position";
            // 
            // rotationPanelLabel
            // 
            this.rotationPanelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationPanelLabel.AutoSize = true;
            this.rotationPanelLabel.Location = new System.Drawing.Point(1142, 356);
            this.rotationPanelLabel.Name = "rotationPanelLabel";
            this.rotationPanelLabel.Size = new System.Drawing.Size(171, 17);
            this.rotationPanelLabel.TabIndex = 11;
            this.rotationPanelLabel.Text = "Current rotational position";
            // 
            // frameLabelPosition
            // 
            this.frameLabelPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.frameLabelPosition.AutoSize = true;
            this.frameLabelPosition.Location = new System.Drawing.Point(1134, 683);
            this.frameLabelPosition.Name = "frameLabelPosition";
            this.frameLabelPosition.Size = new System.Drawing.Size(148, 17);
            this.frameLabelPosition.TabIndex = 12;
            this.frameLabelPosition.Text = "Current frame position";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DimGray;
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.runQueueButton);
            this.tabPage3.Controls.Add(this.deleteMacroButton);
            this.tabPage3.Controls.Add(this.macroDescription);
            this.tabPage3.Controls.Add(this.createMacroButton);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.macroProgressBar);
            this.tabPage3.Controls.Add(this.removeButton);
            this.tabPage3.Controls.Add(this.addButton);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.macroQueue);
            this.tabPage3.Controls.Add(this.macroList);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1116, 753);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Macro management";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Macro Description";
            // 
            // runQueueButton
            // 
            this.runQueueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.runQueueButton.Location = new System.Drawing.Point(575, 627);
            this.runQueueButton.Name = "runQueueButton";
            this.runQueueButton.Size = new System.Drawing.Size(487, 23);
            this.runQueueButton.TabIndex = 11;
            this.runQueueButton.Text = "Run Queue";
            this.runQueueButton.UseVisualStyleBackColor = true;
            this.runQueueButton.Click += new System.EventHandler(this.runQueueButton_Click);
            // 
            // deleteMacroButton
            // 
            this.deleteMacroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteMacroButton.Location = new System.Drawing.Point(835, 656);
            this.deleteMacroButton.Name = "deleteMacroButton";
            this.deleteMacroButton.Size = new System.Drawing.Size(227, 23);
            this.deleteMacroButton.TabIndex = 10;
            this.deleteMacroButton.Text = "Delete Macro";
            this.deleteMacroButton.UseVisualStyleBackColor = true;
            // 
            // macroDescription
            // 
            this.macroDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroDescription.Location = new System.Drawing.Point(575, 31);
            this.macroDescription.Name = "macroDescription";
            this.macroDescription.Size = new System.Drawing.Size(521, 580);
            this.macroDescription.TabIndex = 9;
            this.macroDescription.Text = "";
            // 
            // createMacroButton
            // 
            this.createMacroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createMacroButton.Location = new System.Drawing.Point(575, 656);
            this.createMacroButton.Name = "createMacroButton";
            this.createMacroButton.Size = new System.Drawing.Size(227, 23);
            this.createMacroButton.TabIndex = 8;
            this.createMacroButton.Text = "Create Macro";
            this.createMacroButton.UseVisualStyleBackColor = true;
            this.createMacroButton.Click += new System.EventHandler(this.createMacroButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 701);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Macro progress";
            // 
            // macroProgressBar
            // 
            this.macroProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.macroProgressBar.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.macroProgressBar.Location = new System.Drawing.Point(6, 724);
            this.macroProgressBar.Name = "macroProgressBar";
            this.macroProgressBar.Size = new System.Drawing.Size(1104, 23);
            this.macroProgressBar.TabIndex = 6;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(284, 656);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(257, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(10, 656);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(257, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Macro\'s queued";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Macro\'s known";
            // 
            // macroQueue
            // 
            this.macroQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.macroQueue.FormattingEnabled = true;
            this.macroQueue.ItemHeight = 16;
            this.macroQueue.Location = new System.Drawing.Point(284, 31);
            this.macroQueue.Name = "macroQueue";
            this.macroQueue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.macroQueue.Size = new System.Drawing.Size(257, 580);
            this.macroQueue.TabIndex = 1;
            // 
            // macroList
            // 
            this.macroList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.macroList.FormattingEnabled = true;
            this.macroList.ItemHeight = 16;
            this.macroList.Location = new System.Drawing.Point(10, 31);
            this.macroList.Name = "macroList";
            this.macroList.Size = new System.Drawing.Size(257, 580);
            this.macroList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DimGray;
            this.tabPage2.Controls.Add(this.equipButton);
            this.tabPage2.Controls.Add(this.manualDisplay);
            this.tabPage2.Controls.Add(this.modList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1116, 753);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Module selection";
            // 
            // equipButton
            // 
            this.equipButton.Location = new System.Drawing.Point(85, 492);
            this.equipButton.Name = "equipButton";
            this.equipButton.Size = new System.Drawing.Size(75, 23);
            this.equipButton.TabIndex = 2;
            this.equipButton.Text = "Equip";
            this.equipButton.UseVisualStyleBackColor = true;
            this.equipButton.Click += new System.EventHandler(this.equipButton_Click);
            // 
            // manualDisplay
            // 
            this.manualDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manualDisplay.Location = new System.Drawing.Point(254, 6);
            this.manualDisplay.Name = "manualDisplay";
            this.manualDisplay.Size = new System.Drawing.Size(822, 702);
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
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1116, 753);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Camera feed";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(4, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1124, 782);
            this.tabControl1.TabIndex = 0;
            // 
            // speedSettingSlider
            // 
            this.speedSettingSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.speedSettingSlider.Location = new System.Drawing.Point(1141, 589);
            this.speedSettingSlider.Maximum = 6;
            this.speedSettingSlider.Name = "speedSettingSlider";
            this.speedSettingSlider.Size = new System.Drawing.Size(220, 56);
            this.speedSettingSlider.TabIndex = 13;
            this.speedSettingSlider.Value = 3;
            this.speedSettingSlider.Scroll += new System.EventHandler(this.speedSettingSlider_Scroll);
            // 
            // axisPositionBar
            // 
            this.axisPositionBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.axisPositionBar.Location = new System.Drawing.Point(1141, 703);
            this.axisPositionBar.Name = "axisPositionBar";
            this.axisPositionBar.Size = new System.Drawing.Size(216, 23);
            this.axisPositionBar.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1142, 569);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Speed Setting";
            // 
            // moduleTextBox
            // 
            this.moduleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moduleTextBox.Location = new System.Drawing.Point(1145, 777);
            this.moduleTextBox.Name = "moduleTextBox";
            this.moduleTextBox.Size = new System.Drawing.Size(216, 22);
            this.moduleTextBox.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1142, 755);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Current Module";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1377, 823);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.moduleTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.axisPositionBar);
            this.Controls.Add(this.speedSettingSlider);
            this.Controls.Add(this.frameLabelPosition);
            this.Controls.Add(this.rotationPanelLabel);
            this.Controls.Add(this.positionPanelLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.baseRotationPanel);
            this.Controls.Add(this.robotPositionPanel);
            this.Controls.Add(this.axisLabel);
            this.Controls.Add(this.buttonLabel);
            this.Controls.Add(this.povLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserInterface";
            this.Text = "CORA";
            this.Load += new System.EventHandler(this.Hoofdscherm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedSettingSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.ComponentModel.BackgroundWorker MainProcess;
        private System.Windows.Forms.Panel robotPositionPanel;
        private System.Windows.Forms.Label povLabel;
        private System.Windows.Forms.Label buttonLabel;
        private System.Windows.Forms.Label axisLabel;
        private System.Windows.Forms.Panel baseRotationPanel;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label positionPanelLabel;
        private System.Windows.Forms.Label rotationPanelLabel;
        private System.Windows.Forms.Label frameLabelPosition;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button equipButton;
        private System.Windows.Forms.RichTextBox manualDisplay;
        private System.Windows.Forms.ListBox modList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorSchemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calmMetallicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteAndBlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superFancyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinkyToolStripMenuItem;
        private System.Windows.Forms.ListBox macroQueue;
        private System.Windows.Forms.ListBox macroList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button createMacroButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar macroProgressBar;
        private System.Windows.Forms.RichTextBox macroDescription;
        private System.Windows.Forms.Button runQueueButton;
        private System.Windows.Forms.Button deleteMacroButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar speedSettingSlider;
        private System.Windows.Forms.ProgressBar axisPositionBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox moduleTextBox;
        private System.Windows.Forms.Label label6;
    }
}

