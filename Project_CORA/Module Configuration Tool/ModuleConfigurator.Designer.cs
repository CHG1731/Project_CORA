namespace Module_Configuration_Tool
{
    partial class ModuleConfigurator
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
            this.moduleDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.moduleNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.moduleListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // moduleDescriptionBox
            // 
            this.moduleDescriptionBox.Location = new System.Drawing.Point(503, 45);
            this.moduleDescriptionBox.Name = "moduleDescriptionBox";
            this.moduleDescriptionBox.Size = new System.Drawing.Size(651, 733);
            this.moduleDescriptionBox.TabIndex = 0;
            this.moduleDescriptionBox.Text = "";
            // 
            // moduleNameBox
            // 
            this.moduleNameBox.Location = new System.Drawing.Point(44, 45);
            this.moduleNameBox.Name = "moduleNameBox";
            this.moduleNameBox.Size = new System.Drawing.Size(419, 22);
            this.moduleNameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Module Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Module Description:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 67);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // moduleListBox
            // 
            this.moduleListBox.FormattingEnabled = true;
            this.moduleListBox.Location = new System.Drawing.Point(47, 209);
            this.moduleListBox.Name = "moduleListBox";
            this.moduleListBox.Size = new System.Drawing.Size(416, 293);
            this.moduleListBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Known modules";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 75);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete Selected";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ModuleConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1166, 790);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.moduleListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moduleNameBox);
            this.Controls.Add(this.moduleDescriptionBox);
            this.Name = "ModuleConfigurator";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox moduleDescriptionBox;
        private System.Windows.Forms.TextBox moduleNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox moduleListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}

