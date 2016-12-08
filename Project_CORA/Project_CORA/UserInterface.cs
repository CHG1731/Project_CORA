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

        private int updateInterval = 2;

        Graphics positionPanelGraphics;
        Graphics rotationValueGraphics;
        Pen blackPen = new Pen(Color.Black, 10);
        Pen bluePen = new Pen(Color.Blue, 10);
        Pen redPen = new Pen(Color.Red, 10);
        Pen circlePen = new Pen(Color.Black, 1);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        public UserInterface()
        {
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
            }
            if (ports.Length < 1)
            {
                x.Items.Add("No ports available");
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (serialPort.open(toolStripComboBox1.SelectedItem.ToString()) == false)
            {
                dynamixel.sendTossModeCommand(serialPort);
                serialPort = new SerialPort2Dynamixel();
                dynamixel = new Dynamixel();
            }
        }

        private void PollJoyStick_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeJoyStick x = new InitializeJoyStick();
            x.Run();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
                for (int i = 0; i < button.Length - 100; i++)
                {
                    if (button[i])
                    {
                        buttons += string.Concat(i.ToString(), " ");
                    }
                }
                buttonLabel.Text = "BUTTONS: " + buttons;
                string axispos = String.Concat("X: ", JoyStickState.Xaxis, " Y: ", JoyStickState.Yaxis, " Z: ", JoyStickState.Zaxis, " Zrot: ", JoyStickState.Zrotation);
                axisLabel.Text = axispos;
            }
            if (updateInterval++ == 3)
            {
                updateGUI();
                updateInterval = 0;
            }
        }

        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
        /*
            this.modSelected = modList.SelectedIndex;
            String manual = "", tmp;
            String path = "D:\\Documents\\TI\\Project CORA\\Project_CORA\\Manuals\\" + modList.SelectedItem + "_Manual.txt";
            System.IO.StreamReader manFile = new System.IO.StreamReader(path);
            while ((tmp = manFile.ReadLine()) != null)
            {
                manual += tmp +"\n";
            }
            manFile.Close();
            manualDisplay.Text = manual
            */
        }

        public void updateGUI()
        {
            updateRobotPositon(ServoPositions.baseServo, ServoPositions.midServo, ServoPositions.endServo);
            updateRotationPosition(ServoPositions.rotServo);
        }

        private void updateRobotPositon(int baseValue, int midValue, int endValue)
        {
            float baselength = positionPanelGraphics.DpiX / 2, midlength = positionPanelGraphics.DpiX / 2, endlength = positionPanelGraphics.DpiX / 2;
            double toRadians = Math.PI / 180;
            double baseAngle = ((850 - baseValue) * 0.352) * toRadians;
            double midAngle = ((90 + ((850 - midValue) * 0.352)) * toRadians) - baseAngle;
            double endAngle = ((90 + ((512 - endValue) * 0.352)) * toRadians) + midAngle;

            double baseX = Math.Sin(baseAngle) * baselength, baseY = Math.Cos(baseAngle) * baselength;
            double midX = baseX + Math.Sin(midAngle) * midlength, midY = baseY - Math.Cos(midAngle) * midlength;
            double endX = midX + Math.Sin(endAngle) * endlength, endY = midY + Math.Cos(endAngle) * endlength;

            positionPanelGraphics.Clear(Color.LightGray);
            positionPanelGraphics.DrawLine(blackPen, 0, positionPanelGraphics.DpiY, (float)baseX, positionPanelGraphics.DpiY - (float)baseY);
            positionPanelGraphics.DrawLine(redPen, (float)baseX, positionPanelGraphics.DpiY - (float)baseY, (float)midX, positionPanelGraphics.DpiY - (float)midY);
            positionPanelGraphics.DrawLine(bluePen, (float)midX, positionPanelGraphics.DpiY - (float)midY, (float)endX, positionPanelGraphics.DpiY - (float)endY);
        }

        private void updateRotationPosition(int rotValue)
        {
            int xCor, yCor;
            double a, b;
            rotationValueGraphics.Clear(Color.LightGray);
            Rectangle rectangle = new Rectangle(5, 5, 140, 140);
            Rectangle pointRectangle;
            rotationValueGraphics.DrawEllipse(circlePen, rectangle);

            if(rotValue >=0 && rotValue < 256)
            {
                a = 70 - (rotValue * (70 / 256));
                b = Math.Sqrt(Math.Pow(70, 2) - Math.Pow(a, 2));
                pointRectangle = new Rectangle((int)a , (int)b, 10, 10);
                rotationValueGraphics.FillEllipse(redBrush, pointRectangle);
            }
        }

        public void addMod(String mod)
        {
            modList.Items.Add(mod);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MainProcess x = new MainProcess(this);
        }
    }
}
