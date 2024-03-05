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
        FilterButterworth LowPass;
        List<float> datax;
        List<double> data;
        List<double> filtered;
        List<double> peaks;
        List<double> envelop;
        List<double> env_avg;
        List<double> MABPs;
        ScottPlot.Plottable.SignalPlot plt_data;
        ScottPlot.Plottable.SignalPlot plt_filtered;
        ScottPlot.Plottable.SignalPlot plt_peaks;
        ScottPlot.Plottable.SignalPlot plt_envelop;
        ScottPlot.Plottable.SignalPlot plt_lowpass;

        public Analysis(AppConfig config)
        {
            InitializeComponent();
            this.config = config;

            datax = new List<float>();
            data = new List<double>();
            filtered = new List<double>();
            peaks = new List<double>();
            envelop = new List<double>();
            env_avg = new List<double>();
            MABPs = new List<double>();
            HighPass = new FilterButterworth((float)0.5, 500, FilterButterworth.PassType.Highpass, 1);
            LowPass = new FilterButterworth((float)0.05, 500, FilterButterworth.PassType.Lowpass, 1);

            plotData.Plot.XAxis.Label("Time (seconds)");
            plotData.Plot.YAxis.Label("Pressure (mmHg)");
            plotData.Plot.XAxis.Color(Color.White);
            plotData.Plot.YAxis.Color(Color.White);
            plotData.Refresh();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            data.Clear();
            filtered.Clear();
            peaks.Clear();
            envelop.Clear();
            env_avg.Clear();
            MABPs.Clear();
            checkSignal.Checked = false;
            checkHighpass.Checked = false;
            checkPeaks.Checked = false;
            checkEnvelop.Checked = false;
            checkLowpass.Checked = false;
            txtBP.Text = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = config.param["log_file_path"];
            ofd.RestoreDirectory = true;
            ofd.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";

            List<double> hist = new List<double>();
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
                            datax.Add(float.Parse(ln));
                        }
                    }
                    else if (ofd.FileName.Split(".").Last() == "csv")
                    {
                        string ln;
                        while ((ln = file.ReadLine()) != null)
                        {
                            datax.Add(float.Parse(ln.Split(";")[0]));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot read file: " + ofd.FileName);
                        return;
                    }
                    file.Close();
                }
            }

            float[] data_ = config.VoltageToMmHg(datax.ToArray());
            foreach(double el in data_)
            {
                data.Add(el);
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

            // calculate envelop
            double save = 0;
            bool artefact = false;

            for (int i = 0; i < peaks.Count; i++)
            {
                if (peaks[i] < 0)
                {
                    if (artefact)
                    {
                        envelop.Add(peaks[i] * (-1)); // hier kein save addiert weil der Peak sonst überproportional groß ist
                        save = 0;
                        artefact = false;
                    }
                    else
                    {
                        save = peaks[i];
                        envelop.Add(0);
                        artefact = true;
                    }

                }
                else if (peaks[i] > 0)
                {
                    if (!artefact) // ist auch Artefakt
                    {
                        save = -peaks[i];
                        envelop.Add(0);
                        artefact = true;
                    }
                    else
                    {
                        envelop.Add(peaks[i] - save);
                        save = 0;
                        artefact = false;
                    }
                }
                else
                {
                    envelop.Add(0);
                }
            }

            double x0 = 0, x1 = 0, y0 = 0, y1 = 0;
            bool rdy = false;

            for (int i = 0; i < envelop.Count; i++)
            {
                if (envelop[i] > 0 && rdy)
                {
                    x1 = i;
                    y1 = envelop[i];

                    for (int j = 1; j < (x1 - x0); j++)
                    {
                        envelop[i - j] = y0 + (i - j - x0) * (y1 - y0) / (x1 - x0);
                    }
                    x0 = x1;
                    y0 = y1;
                }
                else if (envelop[i] > 0 && !rdy)
                {
                    x0 = i;
                    y0 = envelop[i];
                    rdy = true;
                }
            }


            //MovingAverage avg2 = new MovingAverage();
            //avg2.windowSize = 1000;

            foreach (float env in envelop)
            {
                LowPass.Update(env);
                env_avg.Add(LowPass.Value);
                //avg2.ComputeAverage(env); 
                //env_avg.Add(avg2.Average);
            }
            env_avg.RemoveRange(0, (int)4.5 * 500); // Zeitkorrektur, empirisch erhoben


            // Another peak detection:

            hist.Clear();
            cnt = 0;
            ascending = false;
            double threshold = env_avg.Max() * 0.60;

            foreach (double d in env_avg)
            {
                if (hist.Count < 1000)
                {
                    hist.Add(d);
                }
                else
                {
                    double max = hist.Max();
                    if (max < d && !ascending)
                    {
                        ascending = true;
                    }
                    if (d > max)
                    {
                        max_cnt = 0;
                    }
                    if (max_cnt > 999)
                    {
                        if (max > threshold)
                        {
                            //MABPs.Add(data[cnt - 1000]);
                            MABPs.Add(data[closestPeak(cnt - 1000)]);

                            for (int i = 1; i < cnt; i++)
                            {
                                if (env_avg[cnt - 1000 - i] < 0.601 * max)
                                {
                                    MABPs.Add(data[closestPeak(cnt - 1000 - i)]); // Wert finden, der zum Peak gehört
                                    break;
                                }
                            }
                            for (int i = 1; i < cnt; i++)
                            {
                                if (env_avg[cnt - 1000 + i] < 0.601 * max)
                                {
                                    MABPs.Add(data[closestPeak(cnt - 1000 + i)]);
                                    break;
                                }
                            }
                        }
                        ascending = false;
                        max_cnt = 0;
                    }
                    if (ascending)
                    {
                        max_cnt++;
                    }
                    hist.RemoveAt(0);
                    hist.Add(d);

                }
                cnt++;
            }

            cnt = 1;
            foreach (double d in MABPs)
            {
                txtBP.Text += string.Format("{0:N1}", d);
                if (cnt % 3 == 0) txtBP.Text += "\r\n";
                else txtBP.Text += " - ";
                cnt++;
            }

            checkSignal.Checked = false;
            checkHighpass.Checked = false;
            checkPeaks.Checked = false;
            checkEnvelop.Checked = false;
            checkLowpass.Checked = false;
            checkSignal.Checked = true;
        }

        public int closestPeak (int index)
        {
            int i = index;
            int j = index;

            while (i<peaks.Count)
            {
                if (peaks[i]>0)
                {
                    break;
                }
                i++;
            }
            while (j > 0)
            {
                if (peaks[j] > 0)
                {
                    break;
                }
                j--;
            }

            if ((i - index) < (index - j)) return i;
            else return j;
        }

        #region Checkboxes

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

        private void checkEnvelop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEnvelop.Checked)
            {
                plt_envelop = plotData.Plot.AddSignal(envelop.ToArray(), sampleRate: 500);
            }
            else
            {
                plotData.Plot.Remove(plt_envelop);
            }
            plotData.Refresh();
        }

        private void checkLowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLowpass.Checked)
            {
                plt_lowpass = plotData.Plot.AddSignal(env_avg.ToArray(), sampleRate: 500);
            }
            else
            {
                plotData.Plot.Remove(plt_lowpass);
            }
            plotData.Refresh();
        }
        #endregion

        #region x and y buttons
        private void butXSmall_Click(object sender, EventArgs e)
        {
            AxisLimits limits = plotData.Plot.GetAxisLimits();
            double xMin = limits.XMin;
            double xMax = limits.XMax;
            double yMin = limits.YMin;
            double yMax = limits.YMax;
            double xSpan = limits.XSpan;

            plotData.Plot.SetAxisLimits(xMin + xSpan / 4, xMax - xSpan / 4, yMin, yMax);
            plotData.Refresh();
        }

        private void butYSmall_Click(object sender, EventArgs e)
        {
            AxisLimits limits = plotData.Plot.GetAxisLimits();
            double xMin = limits.XMin;
            double xMax = limits.XMax;
            double yMin = limits.YMin;
            double yMax = limits.YMax;
            double ySpan = limits.YSpan;

            plotData.Plot.SetAxisLimits(xMin, xMax, yMin + ySpan / 4, yMax - ySpan / 4);
            plotData.Refresh();
        }

        private void butYLarge_Click(object sender, EventArgs e)
        {
            AxisLimits limits = plotData.Plot.GetAxisLimits();
            double xMin = limits.XMin;
            double xMax = limits.XMax;
            double yMin = limits.YMin;
            double yMax = limits.YMax;
            double ySpan = limits.YSpan;

            plotData.Plot.SetAxisLimits(xMin, xMax, yMin - ySpan / 4, yMax + ySpan / 4);
            plotData.Refresh();
        }

        private void butXLarge_Click(object sender, EventArgs e)
        {
            AxisLimits limits = plotData.Plot.GetAxisLimits();
            double xMin = limits.XMin;
            double xMax = limits.XMax;
            double yMin = limits.YMin;
            double yMax = limits.YMax;
            double xSpan = limits.XSpan;

            plotData.Plot.SetAxisLimits(xMin - xSpan / 4, xMax + xSpan / 4, yMin, yMax);
            plotData.Refresh();
        }
        #endregion
    }
}
