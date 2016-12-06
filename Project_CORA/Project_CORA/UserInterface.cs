using System;
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
    public partial class UserInterface : Form
    {
        public bool emergencyStopActive = false;
        public bool requestedReset = false;
        public bool RobotConnected = false;
        static Dynamixel dynamixel;
        static SerialPort2Dynamixel serialPort;

        public UserInterface()
        {
            InitializeComponent();
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
    }
}
