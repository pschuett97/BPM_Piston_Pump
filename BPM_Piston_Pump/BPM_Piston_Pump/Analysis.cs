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
        FilterButterworth HighPass; // filters
        FilterButterworth LowPass;
        List<float> datax; // data at different stages of the analysis
        List<double> data;
        List<double> filtered;
        List<double> peaks;
        List<double> envelop;
        List<double> env_avg;
        List<double> HR; // to calculate the mean heart rate
        ScottPlot.Plottable.SignalPlot plt_data; // plot of the different stages
        ScottPlot.Plottable.SignalPlot plt_filtered;
        ScottPlot.Plottable.SignalPlot plt_peaks;
        ScottPlot.Plottable.SignalPlot plt_envelop;
        ScottPlot.Plottable.SignalPlot plt_lowpass;

        public BmcmInterface.BmcmInterface inter; // connection to the bmcm interface

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
            HR = new List<double>();

            // init filters
            HighPass = new FilterButterworth((float)0.5, int.Parse(config.param["sample_rate"]), FilterButterworth.PassType.Highpass, 1);
            LowPass = new FilterButterworth((float)0.04, int.Parse(config.param["sample_rate"]), FilterButterworth.PassType.Lowpass, 1);

            // init plot
            plotData.Plot.XAxis.Label("Time (seconds)");
            plotData.Plot.YAxis.Label("Pressure (mmHg)");
            plotData.Plot.XAxis.Color(Color.White);
            plotData.Plot.YAxis.Color(Color.White);
            plotData.Refresh();

            // safety feature 
            inter = new BmcmInterface.BmcmInterface("usbad14f");
            inter.set_digital_output_high(int.Parse(config.param["emergency_valve_do_port"]));
            inter.set_digital_output_low(int.Parse(config.param["piston_pump_ena_do_port"]));
            inter.stop_scan();
        }

        /// <summary>
        /// Starts the data analysis procedure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            // reset all data
            data.Clear();
            datax.Clear();
            filtered.Clear();
            peaks.Clear();
            envelop.Clear();
            env_avg.Clear();
            checkSignal.Checked = false;
            checkHighpass.Checked = false;
            checkPeaks.Checked = false;
            checkEnvelop.Checked = false;
            checkLowpass.Checked = false;
            lblMABP.Text = "MABP: ";
            lblBP.Text = "BP: ";

            List<double> hist = new List<double>();
            int cnt = 0;
            int hr_cnt = 0;
            int max_cnt = 0;
            int min_cnt = 0;
            bool ascending = false;
            MovingAverage avg = new MovingAverage();
            bool txt = false;
            bool dir = false;

            // choose a file that contains data to be analysed
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = config.param["log_file_path"];
            ofd.RestoreDirectory = true;
            ofd.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = "Filename: " + ofd.FileName.Split("\\").Last();
                using (StreamReader file = new StreamReader(ofd.FileName))
                {
                    if (ofd.FileName.Split(".").Last() == "txt")
                    {
                        string ln;
                        while ((ln = file.ReadLine()) != null)
                        {
                            datax.Add(float.Parse(ln));
                        }
                        txt = true;
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

            // if the data needs to be converted from volt to mmHg
            float[] data_ = null;
            if (txt)
            {
                data_ = this.VoltageToMmHg(datax.ToArray());
            }
            else
            {
                data_ = datax.ToArray();
            }

            foreach (double el in data_)
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
                if (cnt > 3000) // wait for the transient response of the highpass filter
                {
                    if (hist.Count < (int.Parse(config.param["sample_rate"]) / 6.25)) // always looks at 100 samples at a time
                    {
                        hist.Add(d);
                    }
                    else
                    {
                        if (d > hist.Max()) // new max found
                        {
                            max_cnt = 0;
                        }
                        if (d < hist.Min()) // new min found
                        {
                            min_cnt = 0;
                        }
                        if (max_cnt > (int.Parse(config.param["sample_rate"]) / 6.25 - 1)) // last 100 values no change in maximum
                        {
                            peaks.Add(hist.First()); // declare peak                  
                            ascending = false; // now look for minimum
                            max_cnt = 0;
                            HR.Add(cnt - hr_cnt); // for Heart Rate calculation (drop the first value)
                            hr_cnt = cnt;
                        }
                        else if (min_cnt > (int.Parse(config.param["sample_rate"]) / 6.25 - 1)) // last 100 value no change in minimum
                        {
                            peaks.Add(hist.First()); // declare minumum
                            min_cnt = 0;
                            ascending = true; // now look for maximum
                        }
                        else
                        {
                            peaks.Add(0); // not a peak --> set to zero
                        }

                        if (ascending) // if one looks for a maximum
                        {
                            max_cnt++;
                        }
                        else // if one looks for a minimum
                        {
                            min_cnt++;
                        }
                        hist.RemoveAt(0); // keep hist at a length of 100
                        hist.Add(d);
                    }
                }
                else
                {
                    peaks.Add(0); // set first 3000 to zero (transient response)
                }
                cnt++;
            }

            // calculate envelop
            // add minimum to maximum
            // also eliminiation of artefacts when changing directions
            double save = 0;
            bool artefact = false;

            for (int i = 0; i < peaks.Count; i++)
            {
                if (peaks[i] < 0)
                {
                    if (artefact)
                    {
                        envelop.Add(peaks[i] * (-1)); // save not added here because peak would a overproportionally high
                        save = 0;
                        artefact = false;
                    }
                    else
                    {
                        save = peaks[i]; // artefact detected
                        envelop.Add(0); // set minimum to zero
                        artefact = true;
                    }

                }
                else if (peaks[i] > 0)
                {
                    if (!artefact) // sematic wrong here, is also artefact!
                    {
                        save = -peaks[i]; // artefact detected
                        envelop.Add(0); // set minimum to zero
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

            // calculate envelop by linear interpolation of each peak to peak maximum

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

            // lowpass filtering the envelop to get good local maxima

            //MovingAverage avg2 = new MovingAverage();
            //avg2.windowSize = 1000;
            foreach (float env in envelop)
            {
                LowPass.Update(env);
                env_avg.Add(LowPass.Value);
                //avg2.ComputeAverage(env); 
                //env_avg.Add(avg2.Average);
            }
            env_avg.RemoveRange(0, (int)(5.3 * int.Parse(config.param["sample_rate"]))); // time correction, got value erpirically


            // Another peak detection over the smooth envelop:
            hist.Clear();
            cnt = 0;
            ascending = false;
            double threshold = env_avg.Max() * 0.60; // detected peak needs to be over certain threshold to be a maximum

            foreach (double d in env_avg)
            {
                if (hist.Count < 3000) // gather 3000 values
                {
                    hist.Add(d);
                }
                else
                {
                    double max = hist.Max();
                    if (max < d && !ascending) // no minimum detection hence this
                    {
                        ascending = true;
                    }
                    if (d > max) // new highest value found
                    {
                        max_cnt = 0;
                    }
                    if (max_cnt > 2999)
                    {
                        if (max > threshold) // detected peak needs to be over certain threshold to be a maximum
                        {
                            lblMABP.Text += string.Format("{0:N0}", (data[closestPeak(cnt - 3000)]) - 4) + "  ";

                            // Systole and Diastole only correct when starting with reducing pressure
                            if (!dir)
                            {
                                for (int i = 1; i < cnt - 3000; i++)
                                {
                                    if (env_avg[cnt - 3000 - i] < 0.501 * max)
                                    {
                                        lblBP.Text += string.Format("{0:N0}", (data[closestPeak(cnt - 3000 - i)] + 2)) + " ";
                                        break;
                                    }
                                }
                                for (int i = 1; i < env_avg.Count - cnt - 3000; i++)
                                {
                                    if (env_avg[cnt - 3000 + i] < 0.701 * max)
                                    {
                                        lblBP.Text += string.Format("{0:N0}", (data[closestPeak(cnt - 3000 + i)] - 4)) + " | ";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 1; i < env_avg.Count - cnt - 3000; i++)
                                {
                                    if (env_avg[cnt - 3000 + i] < 0.501 * max)
                                    {
                                        lblBP.Text += string.Format("{0:N0}", (data[closestPeak(cnt - 3000 + i)] + 2)) + " ";
                                        break;
                                    }
                                }
                                for (int i = 1; i < cnt - 3000; i++)
                                {
                                    if (env_avg[cnt - 3000 - i] < 0.701 * max)
                                    {
                                        lblBP.Text += string.Format("{0:N0}", (data[closestPeak(cnt - 3000 - i)] - 4)) + " | ";
                                        break;
                                    }
                                }

                            }
                            dir = !dir;
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

            // calculate HR
            HR.RemoveAt(0);
            double av = 60 / HR.Average() * int.Parse(config.param["sample_rate"]);
            lblHR.Text = "HR: " + string.Format("{0:N1}", av);

            // to display the signal properly
            checkSignal.Checked = false;
            checkHighpass.Checked = false;
            checkPeaks.Checked = false;
            checkEnvelop.Checked = false;
            checkLowpass.Checked = false;
            checkSignal.Checked = true;
        }

        /// <summary>
        /// Finds the peak that is closest to the given index.
        /// </summary>
        /// <param name="index">Index of a point of interest.</param>
        /// <returns>Index of the closest peak.</returns>
        public int closestPeak(int index)
        {
            int i = index;
            int j = index;

            while (i < peaks.Count)
            {
                if (peaks[i] > 0)
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

        /// <summary>
        /// Calculates the mmHg value of a given range of voltages.
        /// </summary>
        /// <param name="voltage">Voltages from the pressure sensor</param>
        /// <returns>Corresponding mmHg values.</returns>
        private float[] VoltageToMmHg(float[] voltage)
        {
            float k = (float)((numHg2.Value - numHg1.Value) / (numV2.Value - numV1.Value));
            float d = (float)numHg2.Value - k * (float)numV2.Value;
            float[] mmHg = new float[voltage.Length];
            for (int i = 0; i < voltage.Length; i++)
            {
                mmHg[i] = k * voltage[i] + d;
            }
            return mmHg;
        }

        // plotting the selected data in the graph
        #region Checkboxes

        private void checkSignal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSignal.Checked)
            {
                plt_data = plotData.Plot.AddSignal(data.ToArray(), sampleRate: int.Parse(config.param["sample_rate"]));
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
                plt_filtered = plotData.Plot.AddSignal(filtered.ToArray(), sampleRate: int.Parse(config.param["sample_rate"]));
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
                plt_peaks = plotData.Plot.AddSignal(peaks.ToArray(), sampleRate: int.Parse(config.param["sample_rate"]));
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
                plt_envelop = plotData.Plot.AddSignal(envelop.ToArray(), sampleRate: int.Parse(config.param["sample_rate"]));
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
                plt_lowpass = plotData.Plot.AddSignal(env_avg.ToArray(), sampleRate: int.Parse(config.param["sample_rate"]));
            }
            else
            {
                plotData.Plot.Remove(plt_lowpass);
            }
            plotData.Refresh();
        }
        #endregion

        // make the graph scaleable in x and y direction
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
