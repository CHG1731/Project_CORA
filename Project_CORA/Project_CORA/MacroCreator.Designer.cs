namespace Project_CORA
{
    partial class MacroCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroCreator));
            this.baseServoValueBar = new System.Windows.Forms.TrackBar();
            this.midServoValueBar = new System.Windows.Forms.TrackBar();
            this.endServoValueBar = new System.Windows.Forms.TrackBar();
            this.moduleServoValueBar = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.baseServoValueBox = new System.Windows.Forms.TextBox();
            this.midServoValueBox = new System.Windows.Forms.TextBox();
            this.endServoValueBox = new System.Windows.Forms.TextBox();
            this.moduleServoValueBox = new System.Windows.Forms.TextBox();
            this.rotationServoValueBar = new System.Windows.Forms.TrackBar();
            this.addToMacroButton = new System.Windows.Forms.Button();
            this.finalizeMacro = new System.Windows.Forms.Button();
            this.macroNameBox = new System.Windows.Forms.TextBox();
            this.rotationServoValueBox = new System.Windows.Forms.TextBox();
            this.previewBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.switchModuleButton = new System.Windows.Forms.Button();
            this.modList = new System.Windows.Forms.ListBox();
            this.macroList = new System.Windows.Forms.ListBox();
            this.runMacroButton = new System.Windows.Forms.Button();
            this.robotPositionPanel = new System.Windows.Forms.Panel();
            this.baseRotationPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseServoValueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midServoValueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endServoValueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moduleServoValueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationServoValueBar)).BeginInit();
            this.SuspendLayout();
            // 
            // baseServoValueBar
            // 
            this.baseServoValueBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseServoValueBar.Location = new System.Drawing.Point(27, 32);
            this.baseServoValueBar.Maximum = 850;
            this.baseServoValueBar.Minimum = 300;
            this.baseServoValueBar.Name = "baseServoValueBar";
            this.baseServoValueBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.baseServoValueBar.Size = new System.Drawing.Size(1387, 56);
            this.baseServoValueBar.TabIndex = 0;
            this.baseServoValueBar.Value = 850;
            this.baseServoValueBar.Scroll += new System.EventHandler(this.baseServoValueBar_Scroll);
            // 
            // midServoValueBar
            // 
            this.midServoValueBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.midServoValueBar.Location = new System.Drawing.Point(27, 122);
            this.midServoValueBar.Maximum = 810;
            this.midServoValueBar.Name = "midServoValueBar";
            this.midServoValueBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.midServoValueBar.Size = new System.Drawing.Size(1387, 56);
            this.midServoValueBar.TabIndex = 1;
            this.midServoValueBar.Value = 810;
            this.midServoValueBar.Scroll += new System.EventHandler(this.midServoValueBar_Scroll);
            // 
            // endServoValueBar
            // 
            this.endServoValueBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endServoValueBar.Location = new System.Drawing.Point(27, 214);
            this.endServoValueBar.Maximum = 1023;
            this.endServoValueBar.Minimum = 512;
            this.endServoValueBar.Name = "endServoValueBar";
            this.endServoValueBar.Size = new System.Drawing.Size(1387, 56);
            this.endServoValueBar.TabIndex = 2;
            this.endServoValueBar.Value = 512;
            this.endServoValueBar.Scroll += new System.EventHandler(this.endServoValueBar_Scroll);
            // 
            // moduleServoValueBar
            // 
            this.moduleServoValueBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moduleServoValueBar.Location = new System.Drawing.Point(27, 308);
            this.moduleServoValueBar.Maximum = 1023;
            this.moduleServoValueBar.Name = "moduleServoValueBar";
            this.moduleServoValueBar.Size = new System.Drawing.Size(1387, 56);
            this.moduleServoValueBar.TabIndex = 3;
            this.moduleServoValueBar.Value = 512;
            this.moduleServoValueBar.Scroll += new System.EventHandler(this.moduleServoBar_Scroll);
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(27, 501);
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(1387, 56);
            this.trackBar5.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Base Servo.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Middle Servo";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "End Servo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Module Servo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Rotation Servo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 481);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Frame Servo";
            // 
            // baseServoValueBox
            // 
            this.baseServoValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.baseServoValueBox.Location = new System.Drawing.Point(41, 71);
            this.baseServoValueBox.Name = "baseServoValueBox";
            this.baseServoValueBox.Size = new System.Drawing.Size(100, 22);
            this.baseServoValueBox.TabIndex = 12;
            this.baseServoValueBox.TextChanged += new System.EventHandler(this.baseServoValueBox_TextChanged);
            // 
            // midServoValueBox
            // 
            this.midServoValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.midServoValueBox.Location = new System.Drawing.Point(41, 163);
            this.midServoValueBox.Name = "midServoValueBox";
            this.midServoValueBox.Size = new System.Drawing.Size(100, 22);
            this.midServoValueBox.TabIndex = 13;
            this.midServoValueBox.TextChanged += new System.EventHandler(this.midServoValueBox_TextChanged);
            // 
            // endServoValueBox
            // 
            this.endServoValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.endServoValueBox.Location = new System.Drawing.Point(41, 255);
            this.endServoValueBox.Name = "endServoValueBox";
            this.endServoValueBox.Size = new System.Drawing.Size(100, 22);
            this.endServoValueBox.TabIndex = 14;
            this.endServoValueBox.TextChanged += new System.EventHandler(this.endServoValueBox_TextChanged);
            // 
            // moduleServoValueBox
            // 
            this.moduleServoValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.moduleServoValueBox.Location = new System.Drawing.Point(41, 352);
            this.moduleServoValueBox.Name = "moduleServoValueBox";
            this.moduleServoValueBox.Size = new System.Drawing.Size(100, 22);
            this.moduleServoValueBox.TabIndex = 15;
            this.moduleServoValueBox.TextChanged += new System.EventHandler(this.moduleServoValueBox_TextChanged);
            // 
            // rotationServoValueBar
            // 
            this.rotationServoValueBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationServoValueBar.Location = new System.Drawing.Point(27, 405);
            this.rotationServoValueBar.Maximum = 1023;
            this.rotationServoValueBar.Name = "rotationServoValueBar";
            this.rotationServoValueBar.Size = new System.Drawing.Size(1387, 56);
            this.rotationServoValueBar.TabIndex = 17;
            this.rotationServoValueBar.Value = 512;
            this.rotationServoValueBar.Scroll += new System.EventHandler(this.rotationServoValueBar_Scroll);
            // 
            // addToMacroButton
            // 
            this.addToMacroButton.Location = new System.Drawing.Point(41, 617);
            this.addToMacroButton.Name = "addToMacroButton";
            this.addToMacroButton.Size = new System.Drawing.Size(134, 51);
            this.addToMacroButton.TabIndex = 18;
            this.addToMacroButton.Text = "Add and new";
            this.addToMacroButton.UseVisualStyleBackColor = true;
            this.addToMacroButton.Click += new System.EventHandler(this.addToMacroButton_Click);
            // 
            // finalizeMacro
            // 
            this.finalizeMacro.Location = new System.Drawing.Point(188, 617);
            this.finalizeMacro.Name = "finalizeMacro";
            this.finalizeMacro.Size = new System.Drawing.Size(134, 51);
            this.finalizeMacro.TabIndex = 19;
            this.finalizeMacro.Text = "Finalize and store";
            this.finalizeMacro.UseVisualStyleBackColor = true;
            this.finalizeMacro.Click += new System.EventHandler(this.finalizeMacro_Click);
            // 
            // macroNameBox
            // 
            this.macroNameBox.Location = new System.Drawing.Point(41, 560);
            this.macroNameBox.Name = "macroNameBox";
            this.macroNameBox.Size = new System.Drawing.Size(281, 22);
            this.macroNameBox.TabIndex = 20;
            // 
            // rotationServoValueBox
            // 
            this.rotationServoValueBox.Location = new System.Drawing.Point(41, 448);
            this.rotationServoValueBox.Name = "rotationServoValueBox";
            this.rotationServoValueBox.Size = new System.Drawing.Size(100, 22);
            this.rotationServoValueBox.TabIndex = 21;
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(345, 562);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(617, 245);
            this.previewBox.TabIndex = 22;
            this.previewBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 540);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Macro Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(342, 540);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Registered Values:";
            // 
            // switchModuleButton
            // 
            this.switchModuleButton.Location = new System.Drawing.Point(41, 720);
            this.switchModuleButton.Name = "switchModuleButton";
            this.switchModuleButton.Size = new System.Drawing.Size(134, 23);
            this.switchModuleButton.TabIndex = 25;
            this.switchModuleButton.Text = "Switch Module";
            this.switchModuleButton.UseVisualStyleBackColor = true;
            this.switchModuleButton.Click += new System.EventHandler(this.switchModuleButton_Click);
            // 
            // modList
            // 
            this.modList.FormattingEnabled = true;
            this.modList.ItemHeight = 16;
            this.modList.Location = new System.Drawing.Point(345, 560);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(617, 244);
            this.modList.TabIndex = 26;
            this.modList.SelectedIndexChanged += new System.EventHandler(this.modList_SelectedIndexChanged);
            // 
            // macroList
            // 
            this.macroList.FormattingEnabled = true;
            this.macroList.ItemHeight = 16;
            this.macroList.Location = new System.Drawing.Point(345, 560);
            this.macroList.Name = "macroList";
            this.macroList.Size = new System.Drawing.Size(617, 244);
            this.macroList.TabIndex = 27;
            this.macroList.SelectedIndexChanged += new System.EventHandler(this.macroList_SelectedIndexChanged);
            // 
            // runMacroButton
            // 
            this.runMacroButton.Location = new System.Drawing.Point(188, 720);
            this.runMacroButton.Name = "runMacroButton";
            this.runMacroButton.Size = new System.Drawing.Size(134, 23);
            this.runMacroButton.TabIndex = 28;
            this.runMacroButton.Text = "Run Macro";
            this.runMacroButton.UseVisualStyleBackColor = true;
            this.runMacroButton.Click += new System.EventHandler(this.runMacroButton_Click);
            // 
            // robotPositionPanel
            // 
            this.robotPositionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.robotPositionPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.robotPositionPanel.Location = new System.Drawing.Point(993, 560);
            this.robotPositionPanel.Name = "robotPositionPanel";
            this.robotPositionPanel.Size = new System.Drawing.Size(200, 235);
            this.robotPositionPanel.TabIndex = 29;
            // 
            // baseRotationPanel
            // 
            this.baseRotationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baseRotationPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseRotationPanel.Location = new System.Drawing.Point(1214, 560);
            this.baseRotationPanel.Name = "baseRotationPanel";
            this.baseRotationPanel.Size = new System.Drawing.Size(200, 182);
            this.baseRotationPanel.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(990, 540);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Position Preview";
            // 
            // timer1
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MacroCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1462, 816);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.baseRotationPanel);
            this.Controls.Add(this.robotPositionPanel);
            this.Controls.Add(this.runMacroButton);
            this.Controls.Add(this.macroList);
            this.Controls.Add(this.modList);
            this.Controls.Add(this.switchModuleButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.rotationServoValueBox);
            this.Controls.Add(this.macroNameBox);
            this.Controls.Add(this.finalizeMacro);
            this.Controls.Add(this.addToMacroButton);
            this.Controls.Add(this.rotationServoValueBar);
            this.Controls.Add(this.moduleServoValueBox);
            this.Controls.Add(this.endServoValueBox);
            this.Controls.Add(this.midServoValueBox);
            this.Controls.Add(this.baseServoValueBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.moduleServoValueBar);
            this.Controls.Add(this.endServoValueBar);
            this.Controls.Add(this.midServoValueBar);
            this.Controls.Add(this.baseServoValueBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MacroCreator";
            this.Text = "MacroCreator";
            ((System.ComponentModel.ISupportInitialize)(this.baseServoValueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midServoValueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endServoValueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moduleServoValueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationServoValueBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar baseServoValueBar;
        private System.Windows.Forms.TrackBar midServoValueBar;
        private System.Windows.Forms.TrackBar endServoValueBar;
        private System.Windows.Forms.TrackBar moduleServoValueBar;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox baseServoValueBox;
        private System.Windows.Forms.TextBox midServoValueBox;
        private System.Windows.Forms.TextBox endServoValueBox;
        private System.Windows.Forms.TextBox moduleServoValueBox;
        private System.Windows.Forms.TrackBar rotationServoValueBar;
        private System.Windows.Forms.Button addToMacroButton;
        private System.Windows.Forms.Button finalizeMacro;
        private System.Windows.Forms.TextBox macroNameBox;
        private System.Windows.Forms.TextBox rotationServoValueBox;
        private System.Windows.Forms.RichTextBox previewBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button switchModuleButton;
        private System.Windows.Forms.ListBox modList;
        private System.Windows.Forms.ListBox macroList;
        private System.Windows.Forms.Button runMacroButton;
        private System.Windows.Forms.Panel robotPositionPanel;
        private System.Windows.Forms.Panel baseRotationPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer2;
    }
}