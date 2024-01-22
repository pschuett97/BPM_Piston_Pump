using ScottPlot.MarkerShapes;
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
    public partial class Measure : Form
    {
        AppConfig config;
        List<Measurement> data;
        List<float> data_period;
        List<float> data_work;
        List<Peaks> maximas;
        List<double> hist;
        List<float> simulation_data;
        int cnt = 0;
        int max_cnt = 0;
        bool ascending = false;
        private PeriodicTimer timer = null; // timer that runs on a different thread
        public BmcmInterface.BmcmInterface inter; // connection to the bmcm interface
        public uint run_id = 0; // counts how many runs there were
        public bool dir = true;
        public float triggerTime = -1;
        public bool triggered = false;

        FilterButterworth HighPass;
        FilterButterworth LowPass;

        public readonly struct Measurement
        {
            public Measurement(float[] values, float time, bool direction)
            {
                Value = values;
                Time = time;
                Direction = direction;
            }

            public float[] Value { get; init; }
            public float Time { get; init; }
            public bool Direction { get; init; }
        }

        public struct Peaks
        {
            public Peaks(double volt, int pos)
            {
                Volt = volt;
                Pos = pos;
            }
            public double Volt { get; set; }
            public int Pos { get; set; }
        }


        public Measure(AppConfig config)
        {
            InitializeComponent();
            this.config = config;
            rdoNormalMode.Checked = true;
            txtLogName.Text = config.param["log_file_name"];
            numStartPressure.Value = int.Parse(config.param["start_pressure"]);
            data = new List<Measurement>();
            data_period = new List<float>();
            data_work = new List<float>();
            maximas = new List<Peaks>();
            hist = new List<double>();
            simulation_data = new List<float>();
            inter = new BmcmInterface.BmcmInterface("usbad14f");
            config.InitPressureSensor();
            HighPass = new FilterButterworth((float)2.5, int.Parse(config.param["sample_rate"]), FilterButterworth.PassType.Highpass, 10);
        }

        private void rdoNormalMode_CheckedChanged(object sender, EventArgs e)
        {
            //tblLayoutMeasure.Visible = true;
        }

        private void rdoDynamicMode_CheckedChanged(object sender, EventArgs e)
        {
            //tblLayoutMeasure.Visible = false;
        }

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

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStop.Visible = true;
            btnTrigger.Visible = true;



            // ToDo

            // Start Membrane Pump

            // Watch until numStartPressure.Value is reached

            // Stop Membrane Pump

            // Start Piston Pump
            // ToDo
            inter.set_analog_output(float.Parse(config.param["v_inflate_ao"]));
            inter.set_digital_output_high(1); // ToDo change!!
            inter.set_digital_output_high(2);




            // Start Measurement
            inter.start_scan(float.Parse(config.param["sample_rate"]), int.Parse(config.param["values_per_scan"]), int.Parse(config.param["values_per_run"]), int.Parse(config.param["how_many_runs"]));
            timer = new PeriodicTimer(TimeSpan.FromMilliseconds(500));
            // Start new Thread maybe?
            RepeatForEver();
        }

        async void RepeatForEver()
        {
            using (StreamReader file = new StreamReader("data_2.txt"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    simulation_data.Add(float.Parse(ln));
                }
                file.Close();
            }
            while (await timer.WaitForNextTickAsync())
            {
                float[] values;
                if (checkSimulation.Checked)
                {
                    values = simulation_data.GetRange((int)run_id*250, 250).ToArray();
                }
                else
                {
                    values = inter.get_values(run_id);
                }
                
                float time = run_id * int.Parse(config.param["values_per_run"]) / int.Parse(config.param["sample_rate"]);
                run_id++;
                if (triggered)
                {
                    triggerTime = time;
                    triggered = false;
                }
                data.Add(new Measurement(values, time, this.dir));
                data_period.Clear();
                data_period.AddRange(values);
                DataAnalysis();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Visible = false;
            inter.stop_scan();
            timer.Dispose();
            inter.set_digital_output_low(1); // ToDo CHANGE!!
            using (var outf = new StreamWriter(config.param["log_file_path"] + config.param["log_file_name"]))
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
        }

        private void DataAnalysis()
        {

            //MovingAverage avg = new MovingAverage();

            // ToDo
            foreach (float f in data_period)
            {
                HighPass.Update(f);
                //avg.ComputeAverage(HighPass.Value);
                //filtered.Add(avg.Average);
                float d = HighPass.Value;

                // peak detection
                if (cnt > 3000)
                {
                    if (hist.Count < 100)
                    {
                        hist.Add(d);
                    }
                    else
                    {
                        if (hist.Max() < d && !ascending)
                        {
                            ascending = true;
                        }
                        if (d > hist.Max())
                        {
                            max_cnt = 0;
                        }
                        if (max_cnt > 99)
                        {
                            maximas.Add(new Peaks(hist.First(), cnt));
                            max_cnt = 0;
                            ascending = false;

                        }
                        if (ascending)
                        {
                            max_cnt++;
                        }
                        hist.RemoveAt(0);
                        hist.Add(d);
                    }
                }
                cnt++;
            }

            if (cnt>10000) // debug only
            {
                lblMABP.Text = maximas.Last().Pos.ToString();
            }

            // look at the maximas = peaks
            // if the global maximum of the maximas did not change for some time declare this to be the MAP


            // Calculate Blood Preassure Parameters

            // Control Piston Pump

            // Define Pump up and Down

        }

        private void numStartPressure_ValueChanged(object sender, EventArgs e)
        {
            config.param["start_pressure"] = numStartPressure.Value.ToString();
        }

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            btnTrigger.Visible = false;
            triggered = true;
        }
    }
}
