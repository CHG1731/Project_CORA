using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Project_CORA
{
    public partial class UserInterface : Form
    {
        public bool emergencyStopActive = false;
        public bool requestedReset = false;
        public bool RobotConnected = false;
        static Dynamixel dynamixel;
        static SerialPort2Dynamixel serialPort;

        public int modSelected = 0;
        public int modEquiped = 0;

        Graphics positionPanelGraphics;
        Graphics rotationValueGraphics;
        Pen blackPen = new Pen(Color.Black, 7);
        Pen bluePen = new Pen(Color.Blue, 7);
        Pen redPen = new Pen(Color.Red, 7);
        Pen circlePen = new Pen(Color.Black, 2);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        public UserInterface()
        {
            Settings.speedSetting = 10;
            blackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            bluePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            redPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            InitializeComponent();
            positionPanelGraphics = this.robotPositionPanel.CreateGraphics();
            rotationValueGraphics = this.baseRotationPanel.CreateGraphics();
            PollJoyStick.RunWorkerAsync();
            timer1.Start();
            MainProcess.RunWorkerAsync();
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Hoofdscherm_Load(object sender, EventArgs e)
        {
            fetchCom(toolStripComboBox1);
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
            //TODO clean up this code.
            if (JoyStickState.connected)
            {
                int updateslider = JoyStickState.slider / 10;
                if (Asstatus.Value + updateslider < 100 && Asstatus.Value + updateslider > -100)
                {
                    Asstatus.Value += updateslider;
                }
                else
                {
                    if (Asstatus.Value < 0)
                    {
                        Asstatus.Value = -100;
                    }
                    else
                    {
                        Asstatus.Value = 100;
                    }
                }
                povLabel.Text = String.Concat("POV: ", JoyStickState.pov.ToString());
                bool[] button = JoyStickState.buttons;
                string buttons = "";
                if (false)
                {
                    for (int i = 0; i < button.Length - 100; i++)
                    {
                        if (button[i])
                        {
                            buttons += string.Concat(i.ToString(), " ");
                        }
                    }
                }
                buttonLabel.Text = "BUTTONS: " + buttons;
                string axispos = String.Concat("X: ", JoyStickState.Xaxis, " Y: ", JoyStickState.Yaxis, " Z: ", JoyStickState.Zaxis, " Zrot: ", JoyStickState.Zrotation);
                axisLabel.Text = axispos;
            }
                updateGUI();
        }

        /*
         * Function that changes the displayed module manual
         * when a new value is selected on modList.
         */ 
        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.modSelected = modList.SelectedIndex;
            String manual = "", tmp;
            String path = "D:\\Documents\\TI\\Project CORA\\Project_CORA\\Manuals\\" + modList.SelectedItem + "_Manual.txt";
            System.IO.StreamReader manFile = new System.IO.StreamReader(path);
            while ((tmp = manFile.ReadLine()) != null)
            {
                manual += tmp +"\n";
            }
            manFile.Close();
            manualDisplay.Text = manual;
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
        }

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

            positionPanelGraphics.Clear(Color.LightGray);
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
            int xCor, yCor;
            double a = 0, b = 0;
            rotationValueGraphics.Clear(Color.LightGray);
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
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MainProcess x = new MainProcess(this);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServoPositions.COM = toolStripComboBox1.SelectedItem.ToString();
        }

        #region speedsettings
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 5;
        }

        private void speed6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 6;
        }

        private void speed7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 7;
        }

        private void speed8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 8;
        }

        private void speed9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 9;
        }

        private void speed10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.speedSetting = 10;
        }
        #endregion
    }
}
