﻿using ScottPlot.MarkerShapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BPM_Piston_Pump.Measure;

namespace BPM_Piston_Pump
{
    public partial class Measure : Form
    {
        AppConfig config;
        List<Measurement> data;
        List<float> data_period;
        List<float> data_work;
        List<Peaks> maximas;
        List<float> hist;
        List<float> simulation_data;
        List<float> envelop;
        List<float> hist_env;
        List<float> HR;
        int cnt_env = 0, max_cnt_env = 0;
        bool ascending_env = false;
        float threshold = 0;
        int cnt = 0;
        int max_cnt = 0;
        int min_cnt = 0;
        int peak_cnt = 0;
        int start_interator = 1;
        int ticks = 0;
        bool tick_go = false;
        bool ascending = false;
        bool artefact = false;
        bool first = true;
        bool first_env = true;
        bool foundMABP = false;
        float localMax = 0;
        float maximum = 0;
        float save = 0;
        float x0 = 0, x1 = 0, y0 = 0, y1 = 0;
        private PeriodicTimer timer = null; // timer that runs on a different thread
        private PeriodicTimer start_timer = null; // timer that runs on a different thread
        public BmcmInterface.BmcmInterface inter; // connection to the bmcm interface
        public uint run_id = 0; // counts how many runs there were
        public bool dir = true;
        public string triggerTime = "-1";
        public bool triggered = false;

        FilterButterworth HighPass;
        FilterButterworth LowPass;
        MovingAverage avg;

        public readonly struct Measurement
        {
            // is used to store the values of each run with the corresponding time and direction
            public Measurement(float[] values, string time, bool direction)
            {
                Value = values;
                Time = time;
                Direction = direction;
            }

            public float[] Value { get; init; }
            public string Time { get; init; }
            public bool Direction { get; init; }
        }

        // is used to store the peaks such that one can interpolate afterwards.
        public struct Peaks
        {
            public Peaks(float volt, int pos, bool dir)
            {
                Volt = volt;
                Pos = pos;
                Dir = dir;
            }
            public float Volt { get; set; }
            public int Pos { get; set; }
            public bool Dir { get; init; }
        }


        public Measure(AppConfig config)
        {
            InitializeComponent();
            this.config = config;
            rdoNormalMode.Checked = true;
            txtLogName.Text = config.param["log_file_name"];
            numStartPressure.Value = int.Parse(config.param["start_pressure"]);
            numWaitTime.Value = int.Parse(config.param["start_wait_time"]);
            data = new List<Measurement>();
            data_period = new List<float>();
            data_work = new List<float>();
            maximas = new List<Peaks>();
            hist = new List<float>();
            hist_env = new List<float>();
            envelop = new List<float>();
            simulation_data = new List<float>();
            HR = new List<float>();
            inter = new BmcmInterface.BmcmInterface("usbad14f");
            config.InitPressureSensor();
            HighPass = new FilterButterworth((float)0.5, int.Parse(config.param["sample_rate"]), FilterButterworth.PassType.Highpass, 1);
            LowPass = new FilterButterworth((float)0.04, int.Parse(config.param["sample_rate"]), FilterButterworth.PassType.Lowpass, 1);
            avg = new MovingAverage();

            if (int.Parse(config.param["developer"]) == 0)
            {
                checkSimulation.Visible = false;
            }
            inter.set_digital_output_low(int.Parse(config.param["membrane_pump_do_port"]));
            inter.set_digital_output_high(int.Parse(config.param["emergency_valve_do_port"]));
            inter.set_digital_output_low(int.Parse(config.param["piston_pump_ena_do_port"]));
            inter.set_digital_output_high(int.Parse(config.param["test_valve_do_port"]));
        }

        /// <summary>
        /// Not used.
        /// </summary>
        private void rdoNormalMode_CheckedChanged(object sender, EventArgs e)
        {
            //tblLayoutMeasure.Visible = true;
        }

        /// <summary>
        /// Changes the visibility of the labels that are not used when this mode is active.
        /// </summary>
        private void rdoDynamicMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDynamicMode.Checked)
            {
                lblDiastolic.Visible = false;
                lblSystolic.Visible = false;
            }
            else
            {
                lblDiastolic.Visible = true;
                lblSystolic.Visible = true;
            }
        }

        /// <summary>
        /// Declares the directory where the data should be saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = config.param["log_file_path"];
            sfd.RestoreDirectory = true;
            sfd.FileName = txtLogName.Text;
            sfd.DefaultExt = "csv";
            //sfd.Filter = "txt files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                config.param["log_file_path"] = sfd.FileName;
                config.param["log_file_name"] = sfd.FileName.Split('\\').Last();
                txtLogName.Text = config.param["log_file_name"];
                config.saveConfig();
            }
        }

        /// <summary>
        /// Starts the measurement procedure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStop.Visible = true;
            btnTrigger.Visible = true;

            start_timer = new PeriodicTimer(TimeSpan.FromMilliseconds(50));
            StartTimer();
        }

        /// <summary>
        /// Brings the piston in the right start position and then activates the membrane pump.
        /// </summary>
        async void StartTimer()
        {
            bool memb_pump_active = false;
            float mmHg_before = 0;
            float mmHg_after = 0;
            // bring piston to correct position
            // open/close valves            
            if (!checkSimulation.Checked)
            {
                // valevs in neutral position
                inter.set_digital_output_high(int.Parse(config.param["emergency_valve_do_port"]));
                inter.set_digital_output_high(int.Parse(config.param["test_valve_do_port"]));
                // max speed
                inter.set_analog_output((float)4.7); 
                // move in inflation direction 
                inter.set_digital_output_high(int.Parse(config.param["piston_pump_dir_do_port"]));
                inter.set_digital_output_high(int.Parse(config.param["piston_pump_ena_do_port"]));
            }


            while (await start_timer.WaitForNextTickAsync())
            {
                // safety mechanism if pressure sensor is not connected
                if (memb_pump_active)
                {
                    mmHg_after = config.VoltageToMmHg(inter.get_analog_input(int.Parse(config.param["pressure_sensor_ai_port"])));
                    if (mmHg_before >= mmHg_after && ticks > 10)
                    {
                        inter.set_digital_output_low(int.Parse(config.param["membrane_pump_do_port"]));
                        inter.set_digital_output_high(int.Parse(config.param["emergency_valve_do_port"]));
                        inter.set_digital_output_low(int.Parse(config.param["piston_pump_ena_do_port"]));
                        btnStop.Visible = false;
                        btnTrigger.Visible = false;
                        start_timer.Dispose();
                        MessageBox.Show("System is leaky or pressure sensor is not connected");
                        break;
                    }
                }

                // here it should actually state analog input but the input resistance is too high
                // hence an analog input is used too detect if Q is high
                if (inter.get_analog_input(3) > 1)
                {
                    // reaktiviere piston wieder                 
                    inter.set_digital_output_low(int.Parse(config.param["piston_pump_dir_do_port"]));
                    inter.set_digital_output_high(int.Parse(config.param["limit_switch2_do_port"]));
                    tick_go = true;
                    ticks = 0;
                }

                if (ticks > numWaitTime.Value * 20 && !memb_pump_active) // 13s / 50ms = 260 ticks
                {
                    // limit switch
                    inter.set_digital_output_low(int.Parse(config.param["limit_switch2_do_port"]));
                    // Stop motor
                    inter.set_digital_output_low(int.Parse(config.param["piston_pump_ena_do_port"]));
                    // Set valves for measurement
                    inter.set_digital_output_low(int.Parse(config.param["emergency_valve_do_port"]));
                    inter.set_digital_output_high(int.Parse(config.param["test_valve_do_port"]));
                    // Start membrane pump
                    memb_pump_active = true;
                    ticks = 0;
                    inter.set_digital_output_high(int.Parse(config.param["membrane_pump_do_port"]));
                    mmHg_before = config.VoltageToMmHg(inter.get_analog_input(int.Parse(config.param["pressure_sensor_ai_port"])));
                }
                else if (tick_go)
                {
                    ticks++;
                }
                

                if (config.VoltageToMmHg(inter.get_analog_input(int.Parse(config.param["pressure_sensor_ai_port"]))) > (float)numStartPressure.Value || checkSimulation.Checked)
                {
                    // stop timer
                    start_timer.Dispose();
                    // Stop Membrane Pump
                    inter.set_digital_output_low(int.Parse(config.param["membrane_pump_do_port"]));                    
                    // Start Piston Pump
                    inter.set_analog_output(float.Parse(config.param["v_inflate_ao"]));
                    inter.set_digital_output_high(int.Parse(config.param["piston_pump_ena_do_port"]));
                    // Start Measurement
                    inter.start_scan(float.Parse(config.param["sample_rate"]), int.Parse(config.param["values_per_scan"]), int.Parse(config.param["values_per_run"]), int.Parse(config.param["how_many_runs"]));
                    timer = new PeriodicTimer(TimeSpan.FromMilliseconds(500));
                    // Start new Thread maybe?
                    RepeatForEver();
                    break;
                }
            }
        }

        /// <summary>
        /// Main measurement method, where the data is collected.
        /// </summary>
        async void RepeatForEver()
        {
            /*
            using (StreamReader file = new StreamReader("data_2.txt"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    simulation_data.Add(float.Parse(ln));
                }
                file.Close();
            }
            */
            if (checkSimulation.Checked)
            {
                if (File.Exists("probant1.csv"))
                {
                    using (StreamReader file = new StreamReader("probant1.csv"))
                    {
                        string ln;
                        while ((ln = file.ReadLine()) != null)
                        {
                            simulation_data.Add(float.Parse(ln.Split(";")[0]));
                        }
                        file.Close();
                    }
                }
            }
            while (await timer.WaitForNextTickAsync())
            {
                float[] values;
                if (checkSimulation.Checked)
                {
                    try
                    {
                        values = simulation_data.GetRange((int)run_id * 250, 250).ToArray();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message); // wenn simulation fertig ist
                        timer.Dispose();
                        btnStop.Visible = false;
                        btnTrigger.Visible = false;
                        MessageBox.Show("Simulation finished!");
                        break;
                    }
                }
                else
                {
                    values = inter.get_values(run_id);
                }

                //float time = run_id * int.Parse(config.param["values_per_run"]) / int.Parse(config.param["sample_rate"]);
                string time = DateTime.Now.ToLongTimeString();
                run_id++;
                if (triggered)
                {
                    triggerTime = time;
                    triggered = false;
                }
                if (!checkSimulation.Checked) values = config.VoltageToMmHg(values);
                data.Add(new Measurement(values, time, this.dir));
                data_period.Clear();
                data_period.AddRange(values);
                data_work.AddRange(values);
                DataAnalysis();
            }
        }

        /// <summary>
        /// Stops the ongoing measurement and saves the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            inter.set_digital_output_high(int.Parse(config.param["emergency_valve_do_port"]));
            inter.set_digital_output_low(int.Parse(config.param["piston_pump_ena_do_port"]));
            btnStop.Visible = false;
            btnTrigger.Visible = false;
            inter.stop_scan();
            timer.Dispose();
            using (var outf = new StreamWriter(config.param["log_file_path"]))
            {
                outf.WriteLine(triggerTime);
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data[i].Value.Length; j++)
                    {
                        outf.WriteLine(data[i].Value[j].ToString() + ";" + data[i].Time + ";" + data[i].Direction);
                    }
                }
            }
        }

        /// <summary>
        /// Peak detection part.
        /// </summary>
        private void DataAnalysis()
        {
            foreach (float f in data_period)
            {
                if (f < 50 && !checkSimulation.Checked) // Stop everything when the pressure gets too low
                {
                    inter.set_digital_output_high(int.Parse(config.param["emergency_valve_do_port"]));
                    inter.set_digital_output_low(int.Parse(config.param["piston_pump_ena_do_port"]));
                    btnStop.Visible = false;
                    btnTrigger.Visible = false;
                    inter.stop_scan();
                    timer.Dispose();
                    using (var outf = new StreamWriter(config.param["log_file_path"]))
                    {
                        outf.WriteLine(triggerTime.ToString());
                        for (int i = 0; i < data.Count; i++)
                        {
                            for (int j = 0; j < data[i].Value.Length; j++)
                            {
                                outf.WriteLine(data[i].Value[j].ToString() + ";" + data[i].Time + ";" + data[i].Direction);
                            }
                        }
                    }
                    MessageBox.Show("Pressure dropped too low! Have a look at the recoreded signal in the analysis tab. Possible reasons: " +
                        "\r\n The start pressure was too low\r\n No Signal was found\r\n The BP is really low");
                    break;
                }
                HighPass.Update(f);
                //float d = HighPass.Value;
                avg.ComputeAverage(HighPass.Value);
                float d = avg.Average;

                // peak detection and sum the minimum to corresponding maximum
                if (cnt > 3000) // ersten Werte unzulässig wegen Einschwingverhalten des Filters
                {
                    if (hist.Count < 100) hist.Add(d);
                    else
                    {
                        if (d > hist.Max()) max_cnt = 0;
                        if (d < hist.Min()) min_cnt = 0;
                        if (max_cnt > 99)
                        {
                            if (!artefact)
                            {
                                save = hist.First();
                                artefact = true;
                            }
                            else
                            {
                                maximas.Add(new Peaks(hist.First() - save, cnt - 100, dir)); // -100 weil hist.count = 100
                                linearPeakInterpolation();
                                save = 0;
                                artefact = false;
                            }
                            max_cnt = 0;
                            ascending = false;
                        }
                        else if (min_cnt > 99)
                        {
                            if (artefact)
                            {
                                maximas.Add(new Peaks(hist.First() * (-1), cnt - 100, dir));
                                linearPeakInterpolation();
                                save = 0;
                                artefact = false;
                            }
                            else
                            {
                                save = hist.First();
                                artefact = true;
                            }
                            min_cnt = 0;
                            ascending = true;
                        }
                        if (ascending) max_cnt++;
                        else min_cnt++;

                        hist.RemoveAt(0);
                        hist.Add(d);
                    }
                }
                cnt++;
            }
        }

        /// <summary>
        /// When a peak got found:
        /// Calculation of the heart rate.
        /// Interpolation beteen the peaks and simultanously calculation of the envelop.
        /// Peak detection of the envelop and calculation of the BP parameter.
        /// </summary>
        private void linearPeakInterpolation() // with low pass filtering to build envelop
        {
            if (!first)
            {
                x1 = maximas.Last().Pos;
                y1 = maximas.Last().Volt;

                // calculate heart rate
                HR.Add(x1 - x0);
                if (HR.Count > 5)
                {
                    float av = 60 / HR.Average() * int.Parse(config.param["sample_rate"]);
                    lblHR.Text = "HR: " + string.Format("{0:N1}", av);
                    HR.Remove(0);
                }

                for (int i = (int)x0; i < x1; i++)
                {
                    // Interpolation and lowpass filtering to get the envelop
                    LowPass.Update(y0 + (i - x0) * (y1 - y0) / (x1 - x0));
                    envelop.Add(LowPass.Value);
                    float d = LowPass.Value;

                    // peak detection of envelop
                    if (hist_env.Count < 1000) // gather 1000 values
                    {
                        hist_env.Add(d);
                    }
                    else
                    {
                        float max = hist_env.Max();
                        if (max < d && !ascending_env) // no minimum detection hence this
                        {
                            ascending_env = true;
                        }
                        if (d > max)
                        {
                            max_cnt_env = 0;
                        }
                        if (max_cnt_env > 999) // maximum found
                        {
                            if (max > threshold) // maximum needs to be higher than the threshold to be the correct maximum
                            {
                                threshold = max * 0.70f; // adjust threshold

                                int nearest_pos = nearestPeak(cnt_env);
                                lblMABP.Text += " " + string.Format("{0:N0}", (data_work[nearest_pos]) - 4) + " ";

                                // when in normal mode, systole and diastole are calcualted
                                if (rdoNormalMode.Checked)
                                {
                                    foundMABP = true;
                                    localMax = max;

                                    // depending on the direction only one parameter can be calculated by now
                                    // more data necessary for the other parameter
                                    if (dir)
                                    {
                                        for (int n = 1; n < cnt_env; n++)
                                        {
                                            if (envelop[cnt_env - 1000 - n] < 0.501 * localMax)
                                            {
                                                lblSystolic.Text += " " + string.Format("{0:N0}", (data_work[nearestPeak(cnt_env - n)]) + 2) + " ";
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int n = 1; n < cnt_env; n++)
                                        {
                                            if (envelop[cnt_env - 1000 - n] < 0.701 * localMax)
                                            {
                                                lblDiastolic.Text += " " + string.Format("{0:N0}", (data_work[nearestPeak(cnt_env - n)]) - 4) + " ";
                                                break;
                                            }
                                        }
                                    }
                                }
                                else // control pump
                                {
                                    changeDir();
                                }
                            }

                            ascending_env = false;
                            max_cnt_env = 0;
                        }
                        if (ascending_env)
                        {
                            max_cnt_env++;
                        }
                        hist_env.RemoveAt(0);
                        hist_env.Add(d);

                    }
                    cnt_env++;
                }
                if (foundMABP) // calculate the other parameter if possible
                {
                    findBP();
                }
                x0 = x1;
                y0 = y1;
            }
            else // first peak
            {
                first = false;
                x0 = maximas.Last().Pos;
                y0 = maximas.Last().Volt;
                float[] arr = new float[(int)(cnt - 5.4 * int.Parse(config.param["sample_rate"]))]; // time correction, got value erpirically
                Array.Clear(arr, 0, arr.Length);
                envelop.AddRange(arr);
                cnt_env = (int)(cnt - 5.4 * int.Parse(config.param["sample_rate"])); // time correction, got value erpirically
            }
        }

        /// <summary>
        /// If a significant point in the envelop is detected, the corresponding peak has to be found.
        /// This function finds the corresponding peak.
        /// </summary>
        /// <param name="position">Where the point in the envelop is</param>
        /// <returns>The position of the corresponding peak</returns>
        private int nearestPeak(int position)
        {
            int nearest = 100000;
            int nearest_pos = 0;

            foreach (Peaks peak in maximas)
            {
                if (Math.Abs(peak.Pos - position + 1000) < nearest)   // - mal - wird + !!!
                {
                    nearest = Math.Abs(peak.Pos - position + 1000);
                    nearest_pos = peak.Pos;
                }
            }
            return nearest_pos;
        }

        /// <summary>
        /// In normal mode, when MABP is detected, one BP parameter cannot be detected yet, depending on
        /// inflation or deflation cycle. It has to be tried every time, if the parameter can be found.
        /// </summary>
        private void findBP()
        {
            for (int n = start_interator; (cnt_env - 1000 + n) < envelop.Count; n++)
            {
                if (dir)
                {
                    if (envelop[cnt_env - 1000 + n] < 0.701 * localMax)
                    {
                        lblDiastolic.Text += " " + string.Format("{0:N0}", (data_work[nearestPeak(cnt_env + n)]) - 4) + " ";
                        foundMABP = false;
                        changeDir();
                        start_interator = 1;
                        break;
                    }
                }
                else
                {
                    if (envelop[cnt_env - 1000 + n] < 0.501 * localMax)
                    {
                        lblSystolic.Text += " " + string.Format("{0:N0}", (data_work[nearestPeak(cnt_env + n)]) + 2) + " ";
                        foundMABP = false;
                        changeDir();
                        start_interator = 1;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Changes the direction of the piston pump, which means changing from inflation to deflation and vice versa.
        /// </summary>
        private void changeDir()
        {
            if (dir) inter.set_digital_output_high(int.Parse(config.param["piston_pump_dir_do_port"]));
            else inter.set_digital_output_low(int.Parse(config.param["piston_pump_dir_do_port"]));
            dir = !dir;
        }

        private void numStartPressure_ValueChanged(object sender, EventArgs e)
        {
            config.param["start_pressure"] = numStartPressure.Value.ToString();
        }

        /// <summary>
        /// Trigger means, that the data gets a timestamp, when for instance the MRI measurement started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrigger_Click(object sender, EventArgs e)
        {
            btnTrigger.Visible = false;
            triggered = true;
        }

        private void numWaitTime_ValueChanged(object sender, EventArgs e)
        {
            config.param["start_wait_time"] = numWaitTime.Value.ToString();
        }
    }
}
