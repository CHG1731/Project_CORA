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

        public UserInterface()
        {
            InitializeComponent();
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
            Asstatus.Value = JoyStickState.Zaxis;
        }

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

        private void updateGUI(int servoValue, int midValue, int endValue)
        {
            Graphics graphics = this.robotPositionPanel.CreateGraphics();
            graphics.Clear(Color.LightGray);
            Pen blackPen = new Pen(Color.Black, 10);
            Pen bluePen = new Pen(Color.Blue, 10);
            Pen redPen = new Pen(Color.Red, 10);
            blackPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            bluePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            redPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            float baselength = graphics.DpiX / 2, midlength = graphics.DpiX / 2, endlength = graphics.DpiX / 2;
            double baseAngle = ((850 - servoValue) * 0.352) * (Math.PI / 180);
            double midAngle = ((90 + ((850 - midValue) * 0.352)) * (Math.PI / 180)) - baseAngle;
            double endAngle = ((90 + ((512 - endValue) * 0.352)) * (Math.PI / 180)) + midAngle;
            double baseX = Math.Sin(baseAngle) * baselength, baseY = Math.Cos(baseAngle) * baselength;
            double midX = baseX + Math.Sin(midAngle) * midlength, midY = baseY - Math.Cos(midAngle) * midlength;
            double endX = midX + Math.Sin(endAngle) * endlength, endY = midY + Math.Cos(endAngle) * endlength;
            graphics.DrawLine(blackPen, 0, graphics.DpiY, (float)baseX, graphics.DpiY - (float)baseY);
            graphics.DrawLine(redPen, (float)baseX - 5, graphics.DpiY - (float)baseY, (float)midX, graphics.DpiY - (float)midY);
            graphics.DrawLine(bluePen, (float)midX - 5, graphics.DpiY - (float)midY, (float)endX, graphics.DpiY - (float)endY);

        }

        public void addMod(String mod)
        {
            modList.Items.Add(mod);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MainProcess x = new MainProcess(this);
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            int value = 850, value2 = 850, value3 = 512;
            while (true)
            {
                this.updateGUI(value--, value2, value3--);
                Thread.Sleep(100);
            }
        }
    }
}
