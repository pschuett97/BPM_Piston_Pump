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
        private PeriodicTimer timer = null; // timer that runs on a different thread
        public BmcmInterface.BmcmInterface inter; // connection to the bmcm interface
        public uint run_id = 0; // counts how many runs there were
        public bool dir = true;
        public float triggerTime = -1;
        public bool triggered = false;

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


        public Measure(AppConfig config)
        {
            InitializeComponent();
            this.config = config;
            rdoNormalMode.Checked = true;
            txtLogName.Text = config.param["log_file_name"];
            numStartPressure.Value = int.Parse(config.param["start_pressure"]);
            data = new List<Measurement>();
            inter = new BmcmInterface.BmcmInterface("usbad14f");
            config.InitPressureSensor();
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


            // Start Measurement
            inter.start_scan(float.Parse(config.param["sample_rate"]), int.Parse(config.param["values_per_scan"]), int.Parse(config.param["values_per_run"]), int.Parse(config.param["how_many_runs"]));
            timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            RepeatForEver();
        }

        /// <summary>
        /// When this method is called, the timer "timer" was started before.
        /// When "timer" elapses, the code in the while loop gets executed.
        /// It reads n values (eg. 1000) and prints just the first one.
        /// The values are getting stored in data.
        /// </summary>
        async void RepeatForEver()
        {
            // float[] values;  // maybe put that here to increase performance
            while (await timer.WaitForNextTickAsync())
            {
                float[] values = inter.get_values(run_id);
                float time = run_id * int.Parse(config.param["values_per_run"]) / int.Parse(config.param["sample_rate"]);
                run_id++;
                if (triggered)
                {
                    triggerTime = time;
                    triggered = false;
                }
                data.Add(new Measurement(values, time, this.dir));
                DataAnalysis();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Visible = false;
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
        }

        private void DataAnalysis()
        {
            // ToDo

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
            btnStop.Visible = false;
            triggered = true;
        }
    }
}
