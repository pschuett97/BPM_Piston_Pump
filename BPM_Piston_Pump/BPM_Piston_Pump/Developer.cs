using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BmcmInterface;
using System.Threading;
using System.Timers;

namespace BPM_Piston_Pump
{
    public partial class Developer : Form
    {
        public BmcmInterface.BmcmInterface inter; // connection to the bmcm interface
        public uint run_id = 0; // counts how many runs there were
        public List<float> data = new List<float>(); // list to store the data
        private PeriodicTimer timer = null; // timer that runs on a different thread
        AppConfig config;

        /// <summary>
        /// Constructor. Also opens the connection to the bmcm interface.
        /// </summary>
        public Developer(AppConfig config)
        {
            InitializeComponent();
            this.config = config;
            inter = new BmcmInterface.BmcmInterface("usbad14f");
        }

        /// <summary>
        /// Destructor. Gets called when closed.
        /// Disposes the timer in every case, to prevent memory leaks.
        /// </summary>
        ~Developer()
        {
            timer.Dispose();
        }

        /// <summary>
        /// Toggles a given digital output port and shows its state in the UI.
        /// </summary>
        /// <param name="lbl">Label in the UI that represents the port | Label | Object of the UI</param>
        /// <param name="nr">Number of the port, value between 1 and 8 </param>
        private void toggleDigitalOutput(Label lbl, int nr)
        {
            if (lbl.Text == "0")
            {
                inter.set_digital_output_high(nr);
                lbl.Text = "1";
            }
            else
            {
                inter.set_digital_output_low(nr);
                lbl.Text = "0";
            }
        }

        #region Click Events Digital Output

        /// <summary>
        /// Starts the ADC just once. Sets the corresponding label with the ADC value.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnStartADC_Click(object sender, EventArgs e)
        {
            lblADC.Text = inter.get_analog_input(1).ToString();
        }

        /// <summary>
        /// When btnDigitalOut1 is clicked, digital output 1 gets toggled.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalOut1_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut1, 1);
        }

        /// <summary>
        /// When btnDigitalOut2 is clicked, digital output 2 gets toggled.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalOut2_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut2, 2);
        }

        /// <summary>
        /// When btnDigitalOut3 is clicked, digital output 3 gets toggled.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalOut3_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut3, 3);
        }

        /// <summary>
        /// When btnDigitalOut4 is clicked, digital output 4 gets toggled.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalOut4_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut4, 4);
        }

        /// <summary>
        /// When btnDigitalOut5 is clicked, digital output 5 gets toggled.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalOut5_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut5, 5);
        }

        /// <summary>
        /// When btnDigitalOut6 is clicked, digital output 6 gets toggled.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalOut6_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut6, 6);
        }

        /// <summary>
        /// When btnDigitalOut7 is clicked, digital output 7 gets toggled.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalOut7_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut7, 7);
        }

        /// <summary>
        /// When btnDigitalOut8 is clicked, digital output 8 gets toggled.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalOut8_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut8, 8);
        }

        #endregion

        #region Click Events Digital Input

        /// <summary>
        ///  When btnDigitalInput1 is clicked, digital input 1 gets read and
        ///  the corresponding label gets set.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalInput1_Click(object sender, EventArgs e)
        {
            lblDigitalInput1.Text = inter.get_digital_input(1).ToString();
        }

        /// <summary>
        ///  When btnDigitalInput2 is clicked, digital input 2 gets read and
        ///  the corresponding label gets set.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalInput2_Click(object sender, EventArgs e)
        {
            lblDigitalInput2.Text = inter.get_digital_input(2).ToString();
        }

        /// <summary>
        ///  When btnDigitalInput3 is clicked, digital input 3 gets read and
        ///  the corresponding label gets set.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalInput3_Click(object sender, EventArgs e)
        {
            lblDigitalInput3.Text = inter.get_digital_input(3).ToString();
        }

        /// <summary>
        ///  When btnDigitalInput4 is clicked, digital input 4 gets read and
        ///  the corresponding label gets set.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalInput4_Click(object sender, EventArgs e)
        {
            lblDigitalInput4.Text = inter.get_digital_input(4).ToString();
        }

        /// <summary>
        ///  When btnDigitalInput5 is clicked, digital input 5 gets read and
        ///  the corresponding label gets set.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalInput5_Click(object sender, EventArgs e)
        {
            lblDigitalInput5.Text = inter.get_digital_input(5).ToString();
        }

        /// <summary>
        ///  When btnDigitalInput6 is clicked, digital input 6 gets read and
        ///  the corresponding label gets set.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalInput6_Click(object sender, EventArgs e)
        {
            lblDigitalInput6.Text = inter.get_digital_input(6).ToString();
        }

        /// <summary>
        ///  When btnDigitalInput7 is clicked, digital input 7 gets read and
        ///  the corresponding label gets set.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalInput7_Click(object sender, EventArgs e)
        {
            lblDigitalInput7.Text = inter.get_digital_input(7).ToString();
        }

        /// <summary>
        ///  When btnDigitalInput8 is clicked, digital input 8 gets read and
        ///  the corresponding label gets set.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDigitalInput8_Click(object sender, EventArgs e)
        {
            lblDigitalInput8.Text = inter.get_digital_input(8).ToString();
        }

        #endregion

        #region Other Click Events

        /// <summary>
        /// Reads the value of the numDACValue UI element und sets the analog output.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private void btnNewDACValue_Click(object sender, EventArgs e)
        {
            float dacValue;

            if (float.TryParse(numDACValue.Text, out dacValue))
            {
                inter.set_analog_output(dacValue);
            }
            else
            {
                // show error message
                Console.WriteLine("Error: Cannot parse new dac_value to float!");
                MessageBox.Show("Error: Cannot parse new dac_value to float!");
            }
        }

        /// <summary>
        /// Starts the scan, initializes the timer and calls the corresponding timer function.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private void btnStartScan_Click(object sender, EventArgs e)
        {
            inter.start_scan(float.Parse(config.param["sample_rate"]), int.Parse(config.param["values_per_scan"]), int.Parse(config.param["values_per_run"]), int.Parse(config.param["how_many_runs"]));
            timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            RepeatForEver();
        }

        /// <summary>
        /// Stops the currently running scan, disposes the timer and saves all collected data.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private void btnStopScan_Click(object sender, EventArgs e)
        {
            inter.stop_scan();
            timer.Dispose();
            using (var outf = new StreamWriter("data.txt"))
                for (int i = 0; i < data.Count; i++)
                    outf.WriteLine(data[i].ToString());
        }

        #endregion

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
                // lblDeveloper.Text = DateTime.Now.ToString("ss.fff");  // debug statement
                float[] values; // maybe change position here to increase performance
                values = inter.get_values(run_id);
                run_id++;
                boxScan.Text += values[0].ToString();
                boxScan.Text += "\n";
                data.AddRange(values);
            }
        }

    }
}
