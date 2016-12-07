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
            int updateslider = JoyStickState.slider/10;
            if(Asstatus.Value+updateslider<100 && Asstatus.Value+updateslider>-100)
            {
                Asstatus.Value += updateslider;
            }
            else
            {
                if(Asstatus.Value < 0)
                {
                    Asstatus.Value = -100;
                }
                else
                {
                    Asstatus.Value = 100;
                }
            }
            povLabel.Text = String.Concat("POV: ",JoyStickState.pov.ToString());
            bool[] button = JoyStickState.buttons;
            }

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
