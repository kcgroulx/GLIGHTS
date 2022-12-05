using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;


namespace GLightsV1
{
    public partial class Main : Form
    {
        SerialPort port;  
        DirectBitmap bitmap;
        Color[] color = new Color[30];
        byte[] data = new byte[92];
        bool isGLIGHTSConnected = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshPorts();
            tmrColorMatch.Interval = 50;
            comboBox1.SelectedIndex = 0;
        }

        private Color getAverageColor(DirectBitmap bitmap, int X, int Y, int size, int frequency)
        {
            Color color;
            int I = 0;
            int space = size / frequency;
            int r = 0;
            int g = 0;
            int b = 0;
            for (int y = Y; y < Y + size; y = y + space)
            {
                for (int x = X; x < X + size; x = x + space)
                {
                    color = bitmap.Bitmap.GetPixel(x, y);
                    bitmap.Bitmap.SetPixel(x, y, Color.FromArgb(255, 255, 0));
                    r = r + color.R;
                    g = g + color.G;
                    b = b + color.B;
                    I++;
                }
            }
            r = r / I;
            g = g / I;
            b = b / I;
            return Color.FromArgb(r,g,b);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Off
            if (comboBox1.Text == "Off")
            {
                data[0] = 0;
                data[1] = 255;
                if(port != null)
                {
                    port.Write(data, 0, 2);
                }
            }

            //Color Match
            if (comboBox1.Text == "Color Match")
            {
                tmrColorMatch.Enabled = true;
            }
            else
            {
                tmrColorMatch.Enabled = false;
            }

            //RGB Swirl
            if (comboBox1.Text == "RGB Swirl")
            {
                data[0] = 2;
                data[1] = 255;
                sendData(data, 2);
                tmrPing.Enabled = true;
            }

            //Standing Wave
            if (comboBox1.Text == "Standing Wave")
            {
                data[0] = 3;
                data[1] = 255;
                sendData(data, 2);
                tmrPing.Enabled = true;
            }

            //Custom Color
            if(comboBox1.Text == "Custom Color")
            {
                tmrPing.Enabled = true;
                btnSetColor.Visible = true;
                Color color = Properties.Settings.Default.customColor;
                Properties.Settings.Default.Save();
                data[0] = 5;
                if (color.R == 255)
                    data[1] = 254;
                else
                    data[1] = color.R;
                if (color.G == 255)
                    data[2] = 254;
                else
                    data[2] = color.G;
                if (color.B == 255)
                    data[3] = 254;
                else
                    data[3] = color.B;
                data[4] = 255;
                sendData(data, 4);
            }
            else
            {
                btnSetColor.Visible = false; 
            }
        }

        //Color Match
        private void tmrColorMatch_Tick(object sender, EventArgs e)
        {

            try
            {
                backgroundWorker.RunWorkerAsync();
            }
            catch { }
        }

        private void btnAutoConnect_Click(object sender, EventArgs e)
        {
            if (isGLIGHTSConnected == false)
                autoConnect();
        }

        private void refreshPorts()
        {
            String[] ports = SerialPort.GetPortNames();
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
                    Properties.Settings.Default.port = port;
                }
                catch
                {
                }
            }
        }

        private void autoConnect()
        {
            data[1] = 255;
            String[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                Connect(ports[i]);
                data[0] = 254;
                port.Write(data, 0, 2);
                data[0] = 0;
                Thread.Sleep(100);
                if(port.BytesToRead > 0)
                {
                    port.Read(data, 0, 1);
                }
                if(data[0] == 254)
                {
                    toolStripStatusLabel2.Text = "GLIGHTS CONNECTED: " + ports[i];
                    toolStripStatusLabel2.BackColor = Color.FromArgb(57, 121, 101);
                    isGLIGHTSConnected = true;
                    return;
                }
                port.Close();
            }
            MessageBox.Show("Unable to Connect to GLights");
        }

        private void sendData(byte[] data, int count)
        {
            if (port == null)
            {
                comboBox1.SelectedIndex = 0; 
                MessageBox.Show("GLIGHTS Disconnected");
                toolStripStatusLabel1.Text = "GLIGHTS DISCONNECTED:";
                toolStripStatusLabel1.BackColor = Color.Silver;
            }
            else
            {
                try
                {
                    port.Write(data, 0, count);
                }
                catch { }
            }
        }

        //Inputs a color and returns the calibrated color
        Color calibrateColor(Color color)
        {
            int r = 0, g = 0, b = 0;
            if (color.R > (Properties.Settings.Default.deadzone + Math.Sqrt(Properties.Settings.Default.deadzone * Properties.Settings.Default.deadzone + 4 * Properties.Settings.Default.deadzoneCurve)) / 2)
                r = (int)(color.R - (Properties.Settings.Default.deadzoneCurve / (color.R - Properties.Settings.Default.deadzone)));
            if (color.G > (Properties.Settings.Default.deadzone + Math.Sqrt(Properties.Settings.Default.deadzone * Properties.Settings.Default.deadzone + 4 * Properties.Settings.Default.deadzoneCurve)) / 2)
                g = (int)(color.G - (Properties.Settings.Default.deadzoneCurve / (color.G - Properties.Settings.Default.deadzone)));
            if (color.B > (Properties.Settings.Default.deadzone + Math.Sqrt(Properties.Settings.Default.deadzone * Properties.Settings.Default.deadzone + 4 * Properties.Settings.Default.deadzoneCurve)) / 2)
                b = (int)(color.B - (Properties.Settings.Default.deadzoneCurve / (color.B - Properties.Settings.Default.deadzone)));
            return Color.FromArgb(r, g, b);
        }

        //Manual Connect: Generates Form 2 (Used for manual selection of comports)
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ManualConnectForm frm2 = new ManualConnectForm();
            frm2.Show();
        }

        //Sends a one byte long packet to ping arduino so it doesn't turn off
        private void tmrPing_Tick(object sender, EventArgs e)
        {
            data[0] = 255;
            sendData(data, 1);
        }

        //Color Match Settings
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ColorMatchSettings form3 = new ColorMatchSettings();
            form3.Show();
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //creates bitmaps of entire screen
            bitmap = new DirectBitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap.Bitmap))
            {
                graphics.CopyFromScreen(25, 0, 0, 0, bitmap.Bitmap.Size);
            }

            if (Properties.Settings.Default.side == "Left")
            {
                //sets color array
                for (int i = 0; i < 8; i++)
                {
                    color[i] = calibrateColor(getAverageColor(bitmap, 0, 945 - (135 * i), 135, 5));
                }
                for (int i = 0; i < 14; i++)
                {
                    color[i + 8] = calibrateColor(getAverageColor(bitmap, 137 * i, Properties.Settings.Default.topHeight, 137, 5));
                }
                for (int i = 0; i < 8; i++)
                {
                    color[i + 22] = calibrateColor(getAverageColor(bitmap, 1785, 135 * i, 135, 5));
                }
            }
            else if (Properties.Settings.Default.side == "Right")
            {
                //sets color array
                for (int i = 0; i < 8; i++)
                {
                    color[i] = calibrateColor(getAverageColor(bitmap, 1785, 945 - (135 * i), 135, 5));
                }
                for (int i = 0; i < 14; i++)
                {
                    color[i + 8] = calibrateColor(getAverageColor(bitmap, 1783 - (137 * i), Properties.Settings.Default.topHeight, 137, 5));
                }
                for (int i = 0; i < 8; i++)
                {
                    color[i + 22] = calibrateColor(getAverageColor(bitmap, 0, 135 * i, 135, 5));
                }
            }
            bitmap.Dispose();
            //Set color data to packet array
            for (int i = 0; i < 30; i++)
            {
                if (color[i].R == 255)
                    data[i + 1] = 254;
                else
                    data[i + 1] = color[i].R;
                if (color[i].G == 255)
                    data[i + 31] = 254;
                else
                    data[i + 31] = color[i].G;
                if (color[i].B == 255)
                    data[i + 61] = 254;
                else
                    data[i + 61] = color[i].B;
            }
            data[0] = 1;
            data[91] = 255;
            sendData(data, 92);
        }
         
        private void btnSetColor_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog.Color;
                Properties.Settings.Default.customColor = color;
                data[0] = 5;
                if (color.R == 255)
                    data[1] = 254;
                else
                    data[1] = color.R;
                if (color.G == 255)
                    data[2] = 254;
                else
                    data[2] = color.G;
                if (color.B == 255)
                    data[3] = 254;
                else
                    data[3] = color.B;
                data[4] = 255;
                sendData(data, 4);
                
            }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.shopglights.com/setup");
        }
    }
}