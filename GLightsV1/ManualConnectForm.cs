using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace GLightsV1
{
    public partial class ManualConnectForm : Form
    {
        SerialPort port; 
        public ManualConnectForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            refreshPorts();
        }


        private void refreshPorts()
        {
            String[] ports = SerialPort.GetPortNames();
            cmbSerialPorts.DataSource = ports;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbSerialPorts.SelectedIndex >= 0)
            {
                Connect(cmbSerialPorts.SelectedItem.ToString());
                MessageBox.Show("Connected to: " + cmbSerialPorts.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a port first");
            }
        }
        private void Connect(string portName)
        {
            port = new SerialPort(portName);
            if (!port.IsOpen)
            {
                try
                {
                    port.StopBits = StopBits.Two;
                    port.BaudRate = 19200;
                    port.Open();
                }
                catch
                {
                }
            }
        }
    }
}
