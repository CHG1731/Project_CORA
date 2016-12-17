﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CORA
{
    public partial class MacroCreator : Form
    {
        MacroLib macroLib;
        List<int[]> newMacro = new List<int[]>();
        int counter = 1;

        public MacroCreator(MacroLib m, ListBox l, ListBox b)
        {
            this.macroLib = m;
            InitializeComponent();
            this.modList.Visible = false;
            this.macroList.Visible = false;
            this.previewBox.Text = "Command nr.\tBase\tMiddle\tEnd\tModule\tRotation\tFrame\n";
            this.baseServoValueBox.Text = this.baseServoValueBar.Value.ToString();
            this.midServoValueBox.Text = this.midServoValueBar.Value.ToString();
            this.endServoValueBox.Text = this.endServoValueBar.Value.ToString();
            this.moduleServoValueBox.Text = this.moduleServoValueBar.Value.ToString();
            this.rotationServoValueBox.Text = this.rotationServoValueBar.Value.ToString();
            for (int i = 0; i < l.Items.Count; i++)
            {
                l.SelectedIndex = i;
                this.modList.Items.Add(l.SelectedItem);
            }
            for (int i = 0; i < b.Items.Count; i++)
            {
                b.SelectedIndex = i;
                this.macroList.Items.Add(b.SelectedItem);
            }
        }

        #region all the code handling the value changes
        private void baseServoValueBar_Scroll(object sender, EventArgs e)
        {
            this.baseServoValueBox.Text = this.baseServoValueBar.Value.ToString();
        }

        private void baseServoValueBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Int32.Parse(baseServoValueBox.Text);
                if(value >= baseServoValueBar.Minimum && value <= baseServoValueBar.Maximum)
                {
                    baseServoValueBar.Value = value;
                }
            }
            catch(Exception pfff) { }
        }

        private void midServoValueBar_Scroll(object sender, EventArgs e)
        {
            this.midServoValueBox.Text = this.midServoValueBar.Value.ToString();
        }

        private void midServoValueBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Int32.Parse(midServoValueBox.Text);
                if (value >= midServoValueBar.Minimum && value <= midServoValueBar.Maximum)
                {
                    midServoValueBar.Value = value;
                }
            }
            catch (Exception pfff) { }
        }

        private void endServoValueBar_Scroll(object sender, EventArgs e)
        {
            this.endServoValueBox.Text = this.endServoValueBar.Value.ToString();
        }

        private void endServoValueBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Int32.Parse(endServoValueBox.Text);
                if (value >= endServoValueBar.Minimum && value <= endServoValueBar.Maximum)
                {
                    endServoValueBar.Value = value;
                }
            }
            catch (Exception pfff) { }
        }

        private void moduleServoBar_Scroll(object sender, EventArgs e)
        {
            this.moduleServoValueBox.Text = this.moduleServoValueBar.Value.ToString();
        }

        private void moduleServoValueBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Int32.Parse(moduleServoValueBox.Text);
                if (value >= moduleServoValueBar.Minimum && value <= moduleServoValueBar.Maximum)
                {
                    moduleServoValueBar.Value = value;
                }
            }
            catch (Exception pfff) { }
        }

        private void rotationServoValueBar_Scroll(object sender, EventArgs e)
        {
            this.rotationServoValueBox.Text = this.rotationServoValueBar.Value.ToString();
        }

        private void rotationServoValueBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Int32.Parse(rotationServoValueBox.Text);
                if (value >= rotationServoValueBar.Minimum && value <= rotationServoValueBar.Maximum)
                {
                    rotationServoValueBar.Value = value;
                }
            }
            catch (Exception pfff) { }
        }
        #endregion

        private void addToMacroButton_Click(object sender, EventArgs e)
        {
            int[] newCommand = new int[] {baseServoValueBar.Value, midServoValueBar.Value, endServoValueBar.Value, moduleServoValueBar.Value,
                rotationServoValueBar.Value, 0,0};
            newMacro.Add(newCommand);
            previewBox.Text += counter++ + "\t\t";
            for(int i = 0; i<newCommand.Length - 1; i++)
            {
                previewBox.Text += newCommand[i] + "\t";
            }
            previewBox.Text += "\n";
        }

        private void finalizeMacro_Click(object sender, EventArgs e)
        {
            if (macroNameBox.TextLength > 2)
            {
                macroLib.macroStorage.Add(newMacro);
                macroLib.macroNames[macroLib.macroStorage.Count - 1] = macroNameBox.Text;
                this.Close();
            }
        }

        private void switchModuleButton_Click(object sender, EventArgs e)
        {
            if (this.modList.Items.Count > 0)
            {
                this.modList.Visible = true;
                this.Refresh();
            }
        }

        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            newMacro.Add(new int[] { modList.SelectedIndex,2000,2000,2000,2000,2000,2000,});
            previewBox.Text += counter++ + "\t\tSwitch to module: " + (string)modList.SelectedItem + "\n";
            this.modList.Visible = false;
            this.Refresh();
        }

        private void macroList_SelectedIndexChanged(object sender, EventArgs e)
        {
            newMacro.Add(new int[] { 2000, 2000, macroList.SelectedIndex, 2000, 2000, 2000, 2000, });
            previewBox.Text += counter++ + "\t\tRun macro: " + (string)macroList.SelectedItem + "\n";
            this.macroList.Visible = false;
            this.Refresh();
        }

        private void runMacroButton_Click(object sender, EventArgs e)
        {
            if (macroList.Items.Count > 0)
            {
                this.macroList.Visible = true;
                this.Refresh();
            }
        }
    }
}