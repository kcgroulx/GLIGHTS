using System;
using System.Windows.Forms;
using System.Threading;

namespace GLightsV1
{
    public partial class ColorMatchSettings : Form
    {
        byte[] data = new byte[4];
        public ColorMatchSettings()
        {
            InitializeComponent();
        }

        private void ColorMatchSettings_Load(object sender, EventArgs e)
        {
            //Sets value of side combo box
            if (Properties.Settings.Default.side == "Left")
                cmbSelectSide.SelectedIndex = 0;
            if (Properties.Settings.Default.side == "Right")
                cmbSelectSide.SelectedIndex = 1;

            //Sets text values
            lblDeadzone.Text = ("Deadzone " + Properties.Settings.Default.deadzone.ToString());
            lblDeadzoneCurve.Text = ("Deadzone Curve " + Properties.Settings.Default.deadzoneCurve.ToString());
            lblSmoothness.Text = ("Smoothness " + Properties.Settings.Default.smoothness.ToString());
            lblTopHeight.Text = ("Top Height " + Properties.Settings.Default.topHeight.ToString());

            //Sets Trackerbar values
            barDeadzone.Value = (int)Properties.Settings.Default.deadzone;
            barDeadzoneCurve.Value = (int)Properties.Settings.Default.deadzoneCurve;
            barSmoothness.Value = Properties.Settings.Default.smoothness;
            barTopHeight.Value = Properties.Settings.Default.topHeight;
        }

        private void cmbSelectSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.side = cmbSelectSide.Text;
            Properties.Settings.Default.Save();
            barDeadzone.Value = (int)Properties.Settings.Default.deadzone;
            barDeadzoneCurve.Value = (int)Properties.Settings.Default.deadzoneCurve;
        }

        private void barDeadzone_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.deadzone = barDeadzone.Value;
            Properties.Settings.Default.Save();
            lblDeadzone.Text = ("Deadzone " + Properties.Settings.Default.deadzone.ToString());
        }

        private void barDeadzoneCurve_Scroll_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.deadzoneCurve = barDeadzoneCurve.Value;
            Properties.Settings.Default.Save();
            lblDeadzoneCurve.Text = ("Deadzone Curve " + Properties.Settings.Default.deadzoneCurve.ToString());
        }

        private void barSmoothness_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.smoothness = barSmoothness.Value;
            Properties.Settings.Default.Save();
            lblSmoothness.Text = ("Smoothness " + Properties.Settings.Default.smoothness.ToString());
            data[0] = 4;
            data[1] = 0;
            data[2] = (byte)(barSmoothness.Maximum - Properties.Settings.Default.smoothness);
            data[3] = 255;
            try
            {
                Properties.Settings.Default.port.Write(data, 0, 4);
            }
            catch { }
            Thread.Sleep(100);
        }
        
        private void barTopHeight_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.topHeight = barTopHeight.Value;
            Properties.Settings.Default.Save();
            lblTopHeight.Text = ("Top Height " + Properties.Settings.Default.topHeight.ToString());
        }

        //
        //Descriptions for settings
        //
        //Side
        private void cmbSelectSide_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Description: Changes LED side depending on how it is mounted on monitor.\nSelect side depending on where microcontroller is relative to you.";
        }
        //Deadzone
        private void barDeadzone_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Description: Deadzone turns off LEDs for darker on-screen colors.\nHigher values increases the mimimum screen brightness to trigger LEDS.";
        }
        //Deadzone Curve
        private void barDeadzoneCurve_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Description: Curves the deadzone into regular colors.\nHigher values smoothes the jump from deadzone to regular colors\nbut decreases color accuracy.";
        }
        //Smoothness
        private void barSmoothness_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Description: Smoothly shifts LEDs from one frame to another \nto give illusion of higher frame rate:\nHigher values will be much smoother but increase the delay.";
        }
        //TopHeight
        private void barTopHeight_Enter(object sender, EventArgs e)
        {
            lblDescription.Text = "Description: The pixel distance to the color matching for the top of the screen.\nHigher values avoid black bars in movies.";
        }
        //Resets to recommened settings
        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            //Deadzone
            Properties.Settings.Default.deadzone = 20;
            barDeadzone.Value = (int)Properties.Settings.Default.deadzone;
            lblDeadzone.Text = "Deadzone " + Properties.Settings.Default.deadzone.ToString();
            //Deadzone curve
            Properties.Settings.Default.deadzoneCurve = 100;
            barDeadzoneCurve.Value = (int)Properties.Settings.Default.deadzoneCurve;
            lblDeadzoneCurve.Text = "Deadzone Curve " + Properties.Settings.Default.deadzoneCurve.ToString();
            //Smoothness
            Properties.Settings.Default.smoothness = 92;
            barSmoothness.Value = Properties.Settings.Default.smoothness;
            lblSmoothness.Text = "Smoothness " + Properties.Settings.Default.smoothness.ToString();
            data[0] = 4;
            data[1] = 0;
            data[2] = (byte)((barSmoothness.Maximum + 2) - Properties.Settings.Default.smoothness);
            data[3] = 255;
            try{
                Properties.Settings.Default.port.Write(data, 0, 4);
            }
            catch { }
            //TopHeight
            Properties.Settings.Default.topHeight = 100;
            barTopHeight.Value = Properties.Settings.Default.topHeight;
            lblTopHeight.Text = "Top Height " + Properties.Settings.Default.topHeight.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
