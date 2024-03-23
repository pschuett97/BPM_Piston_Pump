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
        private PeriodicTimer timer = null; // timer that runs on a different thread
        private bool running = false;

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
            numTolerance.Value = decimal.Parse(this.config.param["tolerance"]);
            numStepSize.Value = decimal.Parse(this.config.param["step_size"]);
            inter = new BmcmInterface.BmcmInterface("usbad14f");
            workerLeakProofTest = new BackgroundWorker();
            workerCalibrateSpeed = new BackgroundWorker();

            inter.set_digital_output_high(int.Parse(config.param["emergency_valve_do_port"]));
            inter.set_digital_output_low(int.Parse(config.param["piston_pump_ena_do_port"]));
            inter.stop_scan();
        }

        /// <summary>
        /// Start a leak proof test in a new thread and tracks the progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Pumps initial air in the system with the membrane pump, stops it after a while and snapshots one voltage value.
        /// It then waits 5s and collects a second value and compares it.
        /// </summary>
        /// <returns></returns>
        private string leakProofTest()
        {
            float voltage = 0;
            bool proof = true;
            int cnt = 0;

            inter.set_digital_output_high(int.Parse(this.config.param["membrane_pump_do_port"]));
            while (voltage < 3)
            {
                cnt++;
                if (cnt > 10)
                {
                    inter.set_digital_output_low(int.Parse(this.config.param["membrane_pump_do_port"]));
                    MessageBox.Show("Error: Pump cannot reach required pressure at all! This could mean that there is a big leak or the air volume is simply too high");
                    break;
                }
                Thread.Sleep(100);   // wait(500);
                voltage = inter.get_analog_input(int.Parse(this.config.param["pressure_sensor_ai_port"]));
            }
            inter.set_digital_output_low(int.Parse(this.config.param["membrane_pump_do_port"]));


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

        /// <summary>
        /// Starts the speed calibration and tracks its progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalibrateSpeed_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            workerCalibrateSpeed.WorkerReportsProgress = true;

            workerCalibrateSpeed.DoWork += (s, e) =>
            {
                calibrateSpeed();
            };
            workerCalibrateSpeed.ProgressChanged += (s, e) =>
            {
                progressBar1.Value = e.ProgressPercentage;
            };
            workerCalibrateSpeed.RunWorkerCompleted += (s, e) =>
            {
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            };
            workerCalibrateSpeed.RunWorkerAsync();

        }

        /// <summary>
        /// Another initialization step that handels the timer
        /// </summary>
        private void calibrateSpeed()
        {
            running = true;
            inter.set_analog_output(3);  // start analog output voltage = 3V
            inter.set_digital_output_high(int.Parse(this.config.param["piston_pump_dir_do_port"])); // ToDo change ports
            inter.set_digital_output_high(int.Parse(this.config.param["piston_pump_ena_do_port"]));
            inter.start_scan(500, 10000, 1000, 10000);
            timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000));
            RepeatForEver();
            while (running)
            {
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// It pumps up, gathers values every one second and builds the mean. Then the last two values get substracted and compared.
        /// The have to land in an interval of the desired speed with some tolerance.
        /// </summary>
        async void RepeatForEver()
        {
            List<float> data = new List<float>(); // list to store the data
            uint run_id = 0; // counts how many runs there were
            float analogOutVoltage = float.Parse(config.param["v_inflate_ao"]);
            bool success = false;
            int increment = (int)(100 * numStepSize.Value / 3 - 1);

            workerCalibrateSpeed.ReportProgress((int)run_id);

            //inter.set_digital_output_high(int.Parse(config.param["piston_pump_ena_do_port"]));


            while (await timer.WaitForNextTickAsync())
            {
                // get new data
                float[] values;
                values = inter.get_values(run_id);
                run_id++;
                data.Add(values.Average());

                // explore data and control pump
                if (run_id > 1)
                {
                    float last = config.VoltageToMmHg(data.Last());
                    float last2 = config.VoltageToMmHg(data[^2]);

                    if (last - last2 < (float)numSpeedInflation.Value + (float)numTolerance.Value && last - last2 > (float)numSpeedInflation.Value - (float)numTolerance.Value)
                    {
                        config.param["v_inflate_ao"] = analogOutVoltage.ToString();
                        config.param["v_deflate_ao"] = analogOutVoltage.ToString(); // ToDo adjust deflate
                        success = true;
                        break;
                    }
                    else if (last - last2 < (float)numSpeedInflation.Value)
                    {
                        analogOutVoltage += (float)numStepSize.Value;
                    }
                    else
                    {
                        analogOutVoltage -= (float)numStepSize.Value;
                    }
                    inter.set_analog_output(analogOutVoltage);
                }
                workerCalibrateSpeed.ReportProgress((int)run_id * increment);

                if (run_id > 3 / numStepSize.Value)
                {
                    success = false;
                    break;
                }
            }
            inter.set_digital_output_low(int.Parse(this.config.param["piston_pump_ena_do_port"]));
            inter.stop_scan();
            timer.Dispose();
            running = false;
            if (success) MessageBox.Show("SUCCESS: Piston speed is calibrated!");
            else MessageBox.Show("ERROR: Could not calibrate the piston speed! Change settings or adjust setup!");
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
        private void numTolerance_ValueChanged(object sender, EventArgs e)
        {
            config.param["tolerance"] = numTolerance.Value.ToString();
        }

        private void numStepSize_ValueChanged(object sender, EventArgs e)
        {
            config.param["step_size"] = numStepSize.Value.ToString();
        }

        #endregion

        /// <summary>
        /// Saves all configurations that habe been made.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            config.saveConfig();
            MessageBox.Show("Settings Saved!");
        }


    }
}
