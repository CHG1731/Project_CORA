﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace Project_CORA
{
    public partial class UserInterface : Form
    {
        public bool requestedReset = false;
        public bool RobotConnected = false;
        public bool runMacro;
        public List<List<int[]>> macrosToRun = new List<List<int[]>>();

        public int modSelected = 0;
        public int modEquiped = 0;

        WebCam webcam;
        Graphics positionPanelGraphics;
        Graphics rotationValueGraphics;
        Pen blackPen = new Pen(Color.Black, 7);
        Pen bluePen = new Pen(Color.Blue, 7);
        Pen redPen = new Pen(Color.Red, 7);
        Pen circlePen = new Pen(Color.Black, 2);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        public MacroLib macroLib = new MacroLib();
        public ModuleLib moduleLib = new ModuleLib();

        public UserInterface()
        {
            deserializeMacros();
            this.FormClosing += UserInterface_FormClosing;
            Settings.speedSetting = 20;
            Settings.colorPositionPanes = Color.LightGray;
            blackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            bluePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            redPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            InitializeComponent();
            deserializeModules();
            positionPanelGraphics = this.robotPositionPanel.CreateGraphics();
            rotationValueGraphics = this.baseRotationPanel.CreateGraphics();
            timer1.Start();
            MainProcess.RunWorkerAsync();
            setMacroList();
        }

        private void UserInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MacroLib));
            System.IO.StreamWriter writer = new System.IO.StreamWriter("MacroLib.xml");
            serializer.Serialize(writer, macroLib);
            writer.Close();
        }

        private void deserializeMacros()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MacroLib));
                FileStream stream = new FileStream("MacroLib.xml", FileMode.Open);
                macroLib = (MacroLib)
                    serializer.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException f){}
        }

        private void deserializeModules()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ModuleLib));
                FileStream stream = new FileStream("ModuleLib.xml", FileMode.Open);
                moduleLib = (ModuleLib)
                    serializer.Deserialize(stream);
                stream.Close();
                for (int i = 0; i < moduleLib.nameList.Count; i++)
                {
                    modList.Items.Add(moduleLib.nameList.ElementAt(i));
                }
            }
            catch (FileNotFoundException f){}
        }

        private void Hoofdscherm_Load(object sender, EventArgs e)
        {
            fetchCom(toolStripComboBox1);
            PollJoyStick.RunWorkerAsync();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
            webcam.Start();
        }

        private void fetchCom(ToolStripComboBox x)
        {
            String[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (String port in ports)
            {
                x.Items.Add(port);
                x.SelectedIndex = 0;
            }
            if (ports.Length < 1)
            {
                x.Items.Add("No ports available");
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
        }

        private void PollJoyStick_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeJoyStick x = new InitializeJoyStick();
            x.Run();
        }

        /*
         * Timer that calls the updateGUI method at set intervals.
         * This way the GUI updates itself withiut needing to be controlled
         * by the main process.
         */ 
        private void timer1_Tick(object sender, EventArgs e)
        {
            updateGUI();
        }

        /*
         * Function that changes the displayed module manual
         * when a new value is selected on modList.
         */ 
        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.modSelected = modList.SelectedIndex;
            manualDisplay.Text = moduleLib.descriptionList.ElementAt(modList.SelectedIndex);
        }

        //Adds the name of the given mod to the list of mudules.
        public void addMod(String mod)
        {
            modList.Items.Add(mod);
        }

        //Sets the requestedReset flag when button is pressed.
        private void resetButton_Click(object sender, EventArgs e)
        {
            this.requestedReset = true;
        }

        //Sets the modEquiped flag with the index value of the selected mod from modList.
        private void equipButton_Click(object sender, EventArgs e)
        {
            this.modEquiped = modList.SelectedIndex;
            this.moduleTextBox.Text = (String)modList.SelectedItem;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MainProcess x = new MainProcess(this);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServoPositions.COM = toolStripComboBox1.SelectedItem.ToString();
        }

        /*
         * Function calls all methods needed to update the graphical elements
         * of the interface and provides them with their respective
         * arguments.
         */
        public void updateGUI()
        {
            updateRobotPositon(ServoPositions.baseServo, ServoPositions.midServo, ServoPositions.endServo);
            updateRotationPosition(ServoPositions.rotServo);
            this.macroProgressBar.Value = (int)Settings.percentage;
            this.framePositionBar.Value = ServoPositions.frameServo;
            if(macroLib.macroStorage.Count != this.macroList.Items.Count)
            {
                macroList.Items.Clear();
                for(int i = 0; i < macroLib.macroStorage.Count; i++)
                {
                    macroList.Items.Add(macroLib.macroNames[i]);
                }
            }
        }

        #region methods called by updateGUI
        /*
         * Function calculates and displays the positions of the graphical elements
         * that represent the current configuration of the robot arm
         * based on the positional values of the joints.
         */
        private void updateRobotPositon(int baseValue, int midValue, int endValue)
        {
            float baselength = positionPanelGraphics.DpiX / 2, midlength = positionPanelGraphics.DpiX / 2, endlength = positionPanelGraphics.DpiX / 2;
            double toRadians = Math.PI / 180;
            double baseAngle = ((850 - baseValue) * 0.352) * toRadians;
            double midAngle = ((90 + ((810 - midValue) * 0.352)) * toRadians) - baseAngle;
            double endAngle = ((90 + ((512 - endValue) * 0.352)) * toRadians) - midAngle;

            double baseX = Math.Sin(baseAngle) * baselength + 10, baseY = Math.Cos(baseAngle) * baselength;
            double midX = baseX + Math.Sin(midAngle) * midlength, midY = baseY - Math.Cos(midAngle) * midlength;
            double endX = midX - Math.Sin(endAngle) * endlength, endY = midY - Math.Cos(endAngle) * endlength;
            float yLength = positionPanelGraphics.DpiY + 40;

            positionPanelGraphics.Clear(Settings.colorPositionPanes);
            positionPanelGraphics.DrawLine(blackPen, 10, yLength, (float)baseX, yLength - (float)baseY);
            positionPanelGraphics.DrawLine(redPen, (float)baseX, yLength - (float)baseY, (float)midX, yLength - (float)midY);
            positionPanelGraphics.DrawLine(bluePen, (float)midX, yLength - (float)midY, (float)endX, yLength - (float)endY);
            positionPanelGraphics.DrawLine(circlePen, 0, yLength, 30, yLength);
            positionPanelGraphics.DrawLine(circlePen, 30, yLength, 30, yLength + 60);
        }

        /*
         * Function calculates and draws the graphical elements representing the
         * current configuration of the rotation of the arm.
         */ 
        private void updateRotationPosition(int rotValue)
        {
            double a = 0, b = 0;
            rotationValueGraphics.Clear(Settings.colorPositionPanes);
            Rectangle rectangle = new Rectangle(5, 5, 140, 140);
            Rectangle pointRectangle;
            rotationValueGraphics.DrawEllipse(circlePen, rectangle);

            if(rotValue >=0 && rotValue < 260)
            {
                a = 70 + (rotValue * 0.27);
                b = 70 + Math.Sqrt(Math.Pow(70, 2) - Math.Pow(rotValue * 0.27, 2));
            }
            else if (rotValue >= 260 && rotValue < 513)
            {
                rotValue = 512 - rotValue;
                a = 70 + (rotValue * 0.27);
                b = 70 - Math.Sqrt(Math.Pow(70, 2) - Math.Pow(rotValue * 0.27, 2));
            }
            else if (rotValue >= 513 && rotValue < 768)
            {
                rotValue = rotValue - 512;
                a = 70 - (rotValue * 0.27);
                b = 70 - Math.Sqrt(Math.Pow(70, 2) - Math.Pow(rotValue * 0.27, 2));
            }
            else if (rotValue >= 768 && rotValue < 1024)
            {
                rotValue = 1023 - rotValue;
                a = 70 - (rotValue * 0.27);
                b = 70 + Math.Sqrt(Math.Pow(70, 2) - Math.Pow(rotValue * 0.27, 2));
            }
            pointRectangle = new Rectangle((int)a, (int)b, 10, 10);
            rotationValueGraphics.FillEllipse(redBrush, pointRectangle);
        }

        #endregion

        #region code for macro management
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.macroQueue.Items.Add(this.macroList.SelectedItem);
            }
            catch(ArgumentNullException bleh) {}
        }

        private void runQueueButton_Click(object sender, EventArgs e)
        {
            int listIndex;
            if (macrosToRun.Count > 0) { macrosToRun.Clear(); }
            for(int i = 0; i < macroQueue.Items.Count; i++)
            {
                macroQueue.SelectedIndex = i;
                listIndex = macroList.FindStringExact((String)macroQueue.SelectedItem);
                macrosToRun.Add(macroLib.macroStorage.ElementAt(listIndex));
            }
            this.runMacro = true;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            this.macroQueue.Items.Remove(macroQueue.SelectedItem);
        }
        #endregion

        #region color settings
        private void calmMetallicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            Settings.colorPositionPanes = Color.LightGray;
        }

        private void matrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.menuStrip1.BackColor = Color.DarkGreen;
            Settings.colorPositionPanes = Color.White;
        }

        private void whiteAndBlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.menuStrip1.BackColor = Color.DarkBlue;
            Settings.colorPositionPanes = Color.SkyBlue;
        }

        private void superFancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.HotPink;
            this.menuStrip1.BackColor = Color.Purple;
            Settings.colorPositionPanes = Color.Pink;
        }

        private void kinkyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkRed;
            this.menuStrip1.BackColor = Color.DarkGoldenrod;
            Settings.colorPositionPanes = Color.Plum;
        }
        #endregion

        private void speedSettingSlider_Scroll(object sender, EventArgs e)
        {
            switch (this.speedSettingSlider.Value)
            {
                case 0:
                    Settings.speedSetting = 40;
                    break;
                case 1:
                    Settings.speedSetting = 35;
                    break;
                case 2:
                    Settings.speedSetting = 30;
                    break;
                case 3:
                    Settings.speedSetting = 20;
                    break;
                case 4:
                    Settings.speedSetting = 10;
                    break;
                case 5:
                    Settings.speedSetting = 7;
                    break;
                case 6:
                    Settings.speedSetting = 5;
                    break;
            }
        }

        private void setMacroList()
        {
            for(int i = 0; i < macroLib.macroStorage.Count; i++)
            {
                this.macroList.Items.Add(macroLib.macroNames[i]);
            }
        }

        private void createMacroButton_Click(object sender, EventArgs e)
        {
            MacroCreator macroCreator = new MacroCreator(macroLib, modList, macroList);
            macroCreator.Show();
        }

        private void deleteMacroButton_Click(object sender, EventArgs e)
        {
            macroLib.macroStorage.RemoveAt(macroList.SelectedIndex);
            for(int i = macroList.SelectedIndex; i < macroLib.macroNames.Length - 1; i++)
            {
                macroLib.macroNames[i] = macroLib.macroNames[i + 1];
            }
        }
    }
}
