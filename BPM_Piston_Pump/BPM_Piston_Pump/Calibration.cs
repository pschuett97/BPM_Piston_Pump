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
        BackgroundWorker workerLeakProofTest;
        BackgroundWorker workerCalibrateSpeed;

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
            workerLeakProofTest = new BackgroundWorker();
            workerCalibrateSpeed = new BackgroundWorker();
        }

        private void btnLeakproofTestStart_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            workerLeakProofTest.WorkerReportsProgress = true;

            workerLeakProofTest.DoWork += (s, e) =>
            {
                e.Result = leakProofTest();
            };
            workerLeakProofTest.ProgressChanged += (s, e) =>
            {
                progressBar1.PerformStep();
                // this.progressBar1.Value = e.ProgressPercentage;
            };
            workerLeakProofTest.RunWorkerCompleted += (s, e) =>
            {
                lblLeakprooftestResult.Text = e.Result.ToString();
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            };
            workerLeakProofTest.RunWorkerAsync();
        }


        private string leakProofTest()
        {
            float voltage = 0;
            bool proof = true;
            int cnt = 0;

            // ToDo 

            /* Set under pressure !!  AND ADJUST VALUES!
             * activates port 5 = the port of the membrane pump
             * 
             *  inter.set_digital_output_high(int.Parse(this.config.param["membrane_pump_do_port"]));
             *  while (voltage < 3)
             *  {
             *      cnt++;
             *      if (cnt > 10)
             *      {
             *          inter.set_digital_output_low(int.Parse(this.config.param["membrane_pump_do_port"]));
             *          MessageBox.Show("Error: Pump cannot reach required pressure at all! This could mean that there is a big leak or the air volume is simply too high");
             *          break;
             *      }
             *      wait(500);
             *      voltage = inter.get_analog_input(int.Parse(this.config.param["pressure_sensor_ai_port"]));
             *  }
             *  inter.set_digital_output_low(int.Parse(this.config.param["membrane_pump_do_port"]));
             */

            voltage = inter.get_analog_input(int.Parse(this.config.param["pressure_sensor_ai_port"]));

            for (int i = 1; i < 11; i++)
            {
                workerLeakProofTest.ReportProgress(10 * i);
                //wait(500); // timer damit sich UI nicht ganz vertschüsst
                Thread.Sleep(500);
                float voltage2 = inter.get_analog_input(int.Parse(this.config.param["pressure_sensor_ai_port"]));
                if ((voltage - voltage2) > 0.9) proof = false; // ADJUST VALUE HERE!
            }



            if (proof) return "Result: Good!";
            else return "Result: NOT LEAKPROOF!";
        }

        private void btnCalibrateSpeed_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            workerCalibrateSpeed.WorkerReportsProgress = true;

            workerCalibrateSpeed.DoWork += (s, e) =>
            {
                e.Result = calibrateSpeed((float)numSpeedInflation.Value, (float)numSpeedDeflation.Value);
            };
            workerCalibrateSpeed.ProgressChanged += (s, e) =>
            {
                progressBar1.Value = e.ProgressPercentage;
            };
            workerCalibrateSpeed.RunWorkerCompleted += (s, e) =>
            {
                lblLeakprooftestResult.Text = e.Result.ToString();
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            };
            workerCalibrateSpeed.RunWorkerAsync();

        }

        private float calibrateSpeed(float speedInflation, float speedDeflation)
        {
            float analogOutVoltage = 3;
            bool ready = false;
            int cnt = 0;

            while (!ready)
            {
                if (cnt < 100)
                {
                    inter.set_analog_output(analogOutVoltage);
                    //inter.set_digital_output_high(int.Parse(config.param["piston_pump_ena_do_port"]));
                    inter.set_digital_output_high(1); // ToDo change port
                    inter.set_digital_output_high(2);
                }
                else
                {
                    return -1;
                }
                cnt++;
            }




            return analogOutVoltage;
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
