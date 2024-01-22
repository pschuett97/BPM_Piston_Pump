using ScottPlot;
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
    public partial class Analysis : Form
    {
        AppConfig config; // configuration
        FilterButterworth HighPass;
        List<double> data;
        List<double> filtered;
        List<double> peaks;
        ScottPlot.Plottable.SignalPlot plt_data;
        ScottPlot.Plottable.SignalPlot plt_filtered;
        ScottPlot.Plottable.SignalPlot plt_peaks;
        double[] x;
        double[] hist;
        double current_max;

        public Analysis(AppConfig config)
        {
            InitializeComponent();
            this.config = config;

            data = new List<double>();
            filtered = new List<double>();
            peaks = new List<double>();
            HighPass = new FilterButterworth((float)0.5, 500, FilterButterworth.PassType.Highpass, 1);

            plotData.Plot.XAxis.Label("Time (seconds)");
            plotData.Plot.YAxis.Label("Voltage (V)");
            plotData.Plot.XAxis.Color(Color.White);
            plotData.Plot.YAxis.Color(Color.White);
            plotData.Refresh();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            data.Clear();
            filtered.Clear();
            peaks.Clear();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = config.param["log_file_path"];
            ofd.RestoreDirectory = true;
            ofd.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";

            List<double> hist = new List<double>();
            current_max = 0;
            int cnt = 0;
            int max_cnt = 0;
            int min_cnt = 0;
            bool ascending = false;
            List<double> maximas = new List<double>();
            MovingAverage avg = new MovingAverage();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader file = new StreamReader(ofd.FileName))
                {
                    if (ofd.FileName.Split(".").Last() == "txt")
                    {
                        string ln;
                        while ((ln = file.ReadLine()) != null)
                        {
                            data.Add(float.Parse(ln));
                        }
                    }                    
                    else if (ofd.FileName.Split(".").Last() == "csv")
                    {
                        string ln;
                        while ((ln = file.ReadLine()) != null)
                        {
                            data.Add(float.Parse(ln.Split(";")[0]));
                        }
                    }                    
                    else
                    {
                        MessageBox.Show("Cannot read file: " +  ofd.FileName);
                        return;
                    }
                    file.Close();
                }
            }

            // highpass and moving average
            foreach (float f in data)
            {
                HighPass.Update(f);
                avg.ComputeAverage(HighPass.Value); //
                filtered.Add(avg.Average);  //
                //filtered.Add(HighPass.Value);
            }

            // peak detection
            foreach (double d in filtered)
            {
                if (cnt > 3000)
                {
                    if (hist.Count < 100)
                    {
                        hist.Add(d);
                    }
                    else
                    {
                        /*
                        if (hist.Max() < d && !ascending) // obsolete - nur bei maximum only detection
                        {
                            ascending = true;
                        }
                        */
                        if (d > hist.Max())
                        {
                            max_cnt = 0;
                        }
                        if (d < hist.Min())
                        {
                            min_cnt = 0;
                        }
                        if (max_cnt > 99)
                        {
                            peaks.Add(hist.First());
                            //peaks.Add(1);                                
                            ascending = false;
                            max_cnt = 0;
                        }
                        else if (min_cnt > 99)
                        {
                            peaks.Add(hist.First());
                            min_cnt = 0;
                            ascending = true;
                        }
                        else
                        {
                            peaks.Add(0);
                        }

                        if (ascending)
                        {
                            max_cnt++;
                        }
                        else
                        {
                            min_cnt++;
                        }
                        hist.RemoveAt(0);
                        hist.Add(d);
                    }
                }
                else
                {
                    peaks.Add(0);
                }
                cnt++;
            }

            checkSignal.Checked = false;
            checkHighpass.Checked = false;           
            checkPeaks.Checked = false;
            checkSignal.Checked = true;
        }

        private void checkSignal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSignal.Checked)
            {
                plt_data = plotData.Plot.AddSignal(data.ToArray(), sampleRate: 500);
            }
            else
            {
                plotData.Plot.Remove(plt_data);
            }
            plotData.Refresh();
        }

        private void checkHighpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHighpass.Checked)
            {
                plt_filtered = plotData.Plot.AddSignal(filtered.ToArray(), sampleRate: 500);
            }
            else
            {
                plotData.Plot.Remove(plt_filtered);
            }
            plotData.Refresh();
        }

        private void checkPeaks_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPeaks.Checked)
            {
                plt_peaks = plotData.Plot.AddSignal(peaks.ToArray(), sampleRate: 500);
            }
            else
            {
                plotData.Plot.Remove(plt_peaks);
            }
            plotData.Refresh();
        }
    }
}
