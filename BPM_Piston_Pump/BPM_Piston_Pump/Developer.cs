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

namespace BPM_Piston_Pump
{
    public partial class Developer : Form
    {
        public BmcmInterface.BmcmInterface inter;
        public uint run_id = 0;
        public List<float> data = new List<float>();

        public Developer()
        {
            InitializeComponent();
            inter = new BmcmInterface.BmcmInterface("usbad14f");
        }

        private void btnStartADC_Click(object sender, EventArgs e)
        {
            lblADC.Text = inter.get_analog_input(1).ToString();
        }

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

        private void btnDigitalOut1_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut1, 1);
        }

        private void btnDigitalOut2_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut2, 2);
        }

        private void btnDigitalOut3_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut3, 3);
        }

        private void btnDigitalOut4_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut4, 4);
        }

        private void btnDigitalOut5_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut5, 5);
        }

        private void btnDigitalOut6_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut6, 6);
        }

        private void btnDigitalOut7_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut7, 7);
        }

        private void btnDigitalOut8_Click(object sender, EventArgs e)
        {
            toggleDigitalOutput(lblDigitalOut8, 8);
        }

        private void btnDigitalInput1_Click(object sender, EventArgs e)
        {
            lblDigitalInput1.Text = inter.get_digital_input(1).ToString();
        }

        private void btnDigitalInput2_Click(object sender, EventArgs e)
        {
            lblDigitalInput2.Text = inter.get_digital_input(2).ToString();
        }

        private void btnDigitalInput3_Click(object sender, EventArgs e)
        {
            lblDigitalInput3.Text = inter.get_digital_input(3).ToString();
        }

        private void btnDigitalInput4_Click(object sender, EventArgs e)
        {
            lblDigitalInput4.Text = inter.get_digital_input(4).ToString();
        }

        private void btnDigitalInput5_Click(object sender, EventArgs e)
        {
            lblDigitalInput5.Text = inter.get_digital_input(5).ToString();
        }

        private void btnDigitalInput6_Click(object sender, EventArgs e)
        {
            lblDigitalInput6.Text = inter.get_digital_input(6).ToString();
        }

        private void btnDigitalInput7_Click(object sender, EventArgs e)
        {
            lblDigitalInput7.Text = inter.get_digital_input(7).ToString();
        }

        private void btnDigitalInput8_Click(object sender, EventArgs e)
        {
            lblDigitalInput8.Text = inter.get_digital_input(8).ToString();
        }

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

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            // ToDo

            // timer1 is missing

            /*
            
            inter.start_scan();
            timer1.Enabled = true; 
            
            */
        }

        private void btnStopScan_Click(object sender, EventArgs e)
        {
            // ToDo

            // timer1 is missing

            /*
            
            inter.stop_scan();
            timer1.Enabled = false;
            using (var outf = new StreamWriter("data.txt"))
                for (int i = 0; i < data.Count; i++)
                    outf.WriteLine(data[i].ToString());

            */
        }

        /*
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            float[] values;

            values = inter.get_values(run_id);
            run_id++;
            scan_box.Text += values[0].ToString();
            scan_box.Text += "\n";
            data.AddRange(values);
        }   
        
        */
    }
}
