using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPM_Piston_Pump
{
    public partial class Calibration : Form
    {
        AppConfig config; // configuration
        public BmcmInterface.BmcmInterface inter; // connection to the bmcm interface
        public Calibration(AppConfig config)
        {
            InitializeComponent();
            this.config = config;
            numSampleRate.Value = int.Parse(this.config.param["sample_rate"]);
            numVoltLowEnd.Value = decimal.Parse(this.config.param["volt_low_end"]);
            numVoltHighEnd.Value = decimal.Parse(this.config.param["volt_high_end"]);
            numHgLowEnd.Value = decimal.Parse(this.config.param["hg_low_end"]);
            numHgHighEnd.Value = decimal.Parse(this.config.param["hg_high_end"]);
            numSpeedInflation.Value = decimal.Parse(this.config.param["v_inflate"]);
            numSpeedDeflation.Value = decimal.Parse(this.config.param["v_deflate"]);
            inter = new BmcmInterface.BmcmInterface("usbad14f");
        }

        private void btnLeakproofTestStart_Click(object sender, EventArgs e)
        {
            // Stuff with the progress bar

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.PerformStep();

            lblLeakprooftestResult.Text = "Result: Good! " + progressBar1.Value.ToString() + "%";

            if (progressBar1.Value > 99)
            {
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }

            // Conduct Leakproof Test

            // Set under pressure then wait if the pressure decreases
            /*
             * activates port 5 = the port of the membrane pump
             * 
             *  inter.set_digital_output_high(int.Parse(this.config.param["membrane_pump_do_port"]););
             * 
             * 
             * 
             */

        }

        private void btnCalibrateSpeed_Click(object sender, EventArgs e)
        {
            // ToDo
            // Speed Calibration

        }

        #region Value Changed of num selectors

        private void numSampleRate_ValueChanged(object sender, EventArgs e)
        {
            config.param["sample_rate"] = numSampleRate.Value.ToString();
        }

        private void numVoltLowEnd_ValueChanged(object sender, EventArgs e)
        {
            config.param["volt_low_end"] = numVoltLowEnd.Value.ToString();
        }

        private void numVoltHighEnd_ValueChanged(object sender, EventArgs e)
        {
            config.param["volt_high_end"] = numVoltHighEnd.Value.ToString();
        }

        private void numHgLowEnd_ValueChanged(object sender, EventArgs e)
        {
            config.param["hg_low_end"] = numHgLowEnd.Value.ToString();
        }

        private void numHgHighEnd_ValueChanged(object sender, EventArgs e)
        {
            config.param["hg_high_end"] = numHgHighEnd.Value.ToString();
        }

        private void numSpeedDeflation_ValueChanged(object sender, EventArgs e)
        {
            config.param["v_deflation"] = numSpeedDeflation.Value.ToString();
        }

        private void numSpeedInflation_ValueChanged(object sender, EventArgs e)
        {
            config.param["v_inflation"] = numSpeedInflation.Value.ToString();
        }

        #endregion

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            config.saveConfig();
            MessageBox.Show("Settings Saved!");
        }
    }
}
