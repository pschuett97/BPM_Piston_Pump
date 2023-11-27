using System;
using LIBAD4;
using static LIBAD4.LIBAD;

namespace BmcmInterface
{
    public class BmcmInterface
    {
        private int adh; // object of the connection to the interface
        public uint number_runs; // Represents how many number of runs there are in one scan -1

        // state of the digital inputs and outputs
        public bool[] digitalOutputs = { false, false, false, false, false, false, false, false };
        public bool[] digitalInputs = { false, false, false, false, false, false, false, false };

        // store parameter for restarted run
        float sample_rate;
        int values_per_scan;
        int values_per_run;
        int how_many_runs;


        public BmcmInterface(string name)
        {
            // open connection to the interface
            adh = ad_open(name);
            if (adh == -1)
            {
                Console.WriteLine("failed to open {0}: err = {1}", "usb-ad14f", errno);
                return;
            }
            // sets all outputs low preemptively
            this.set_digital_output_low(1);
        }

        /// <summary>
        /// Destructor. Gets called when closed.
        /// </summary>
        ~BmcmInterface()
        {
            int rc;
            int scan_result = 1;
            // stop the current scan
            rc = ad_stop_scan(adh, ref scan_result);
            // close connection
            ad_close(adh);
        }

        /*********************** Operations on single IOs ************************/

        /// <summary>
        /// Sets a digital output port to high
        /// </summary>
        /// <param name="nr">Number of the port, value between 1 and 8</param>
        public void set_digital_output_high(int nr)
        {
            this.digitalOutputs[nr-1] = true;
            uint outs = get_int_from_bool_array(this.digitalOutputs);
            ad_discrete_out(adh, AD_CHA_TYPE_DIGITAL_IO | 0x0002, 0, outs);
        }

        /// <summary>
        /// Sets a digital output port to low
        /// </summary>
        /// <param name="nr">Number of the port, value between 1 and 8</param>
        public void set_digital_output_low(int nr)
        {
            this.digitalOutputs[nr-1] = false;
            uint outs = get_int_from_bool_array(this.digitalOutputs);
            ad_discrete_out(adh, AD_CHA_TYPE_DIGITAL_IO | 0x0002, 0, outs);
        }

        /// <summary>
        /// Sets the analog output port to a certain voltage
        /// </summary>
        /// <param name="value">Voltage to set the port to, float value from 0 to 5.12</param>
        public void set_analog_output(float value)
        {
            int rc;

            rc = ad_analog_out(adh, AD_CHA_TYPE_ANALOG_OUT | 0x0001, 0, value);
            if (rc == 0)
                Console.WriteLine("cha {0,2}: {1,7:##0.000} V", 1, value);
            else
                Console.WriteLine("error: failed to write cha {0}: err = {1}", 1, rc);
        }

        /// <summary>
        /// Reads an analog input
        /// </summary>
        /// <param name="nr">Number of the port, value between 1 and 8</param>
        /// <returns>Voltage of the disired port, float value from -10.24 to 10.24</returns>
        public float get_analog_input(int nr)
        {
            float voltage = 0;
            int rc1;

            rc1 = ad_analog_in(adh, AD_CHA_TYPE_ANALOG_IN | nr, 0, ref voltage);
            if (rc1 == 0)
                return voltage;
            else
                Console.WriteLine("error: failed to read cha {0}: err = {1}", nr, rc1);
                return (-1);
        }

        /// <summary>
        /// Reads the digital inputs and stores them in "digital_inputs"
        /// </summary>
        /// <param name="nr">Number of the port, value between 1 and 8</param>
        /// <returns>Value of the desired digital input | bool</returns>
        public bool get_digital_input(int nr)
        {
            uint digInput = 0;
            int rc2;
            rc2 = ad_discrete_in(adh, AD_CHA_TYPE_DIGITAL_IO | 0x0001, 0, ref digInput);
            if (rc2 == 0)
            {
                digitalInputs = get_bool_array_from_uint(digInput);
                return digitalInputs[nr-1];
            }
            else
            {
                Console.WriteLine("error: failed to read cha {0}: err = {1}", 1, rc2);
                return false;
            }
        }

        /// <summary>
        /// Function that converts a bool array into an uint.
        /// An integer value is required to control the IO channel.
        /// But the state of the IO channel is stored in an array of boolean values for ease of use.
        /// </summary>
        /// <param name="boolArray">Array of 8 booleans that represent a port | bool[]</param>
        /// <returns>Unsigned integer value that represents the state of the port | uint</returns>
        public uint get_int_from_bool_array(bool[] boolArray)
        {
            uint intFromBool = 0b0;

            foreach (bool b in boolArray.Reverse())
            {
                intFromBool = (intFromBool << 1);
                if (b)
                {
                    intFromBool += 1;
                }
            }
            return intFromBool;
        }

        /// <summary>
        /// Function that converts a uint into a bool array.
        /// When reading an IO port one gets an integer value.
        /// But the state of the port gets stored in a bool array for the ease of use.
        /// </summary>
        /// <param name="value">Unsigned integer value that represents the state of a port | uint</param>
        /// <returns>Array of bools to store the state of the port | bool[]</returns>
        public bool[] get_bool_array_from_uint(uint value)
        {
            int cnt = 0;
            bool[] boolArray = { false, false, false, false, false, false, false, false };
            string binaryValue = Convert.ToString(value, 2);
            foreach (char c in binaryValue.Reverse())
            {
                if (c == '1')
                {
                    boolArray[cnt] = true;
                }
                cnt++;
            }
            return boolArray;
        }

        /*********************** Section for scans ************************/

        /// <summary>
        /// Stops the ongoing scan.
        /// </summary>
        public void stop_scan()
        {
            int scan_result = 1;
            int rc;

            rc = ad_stop_scan(adh, ref scan_result);
            if (rc != 0)
            {
                // error handeling
            }
        }

        /// <summary>
        /// Starts a scan. Beware of the presets (hard coded values)
        /// </summary>
        public void start_scan(float sample_rate, int values_per_scan, int values_per_run, int how_many_runs)
        {
            int rc;
            ad_scan_cha_desc[] chav = new ad_scan_cha_desc[1];
            ad_scan_desc sd = new ad_scan_desc();

            this.sample_rate = sample_rate;
            this.values_per_scan = values_per_scan;
            this.values_per_run = values_per_run;            
            this.how_many_runs = how_many_runs;

            chav[0].cha = AD_CHA_TYPE_ANALOG_IN | 1; // Selecting the channel
            chav[0].store = AD_STORE_DISCRETE;       // average, min, max, rms sind möglich
            chav[0].ratio = 1;                       // at ratio = 5 and average - 5 values will be averaged
            chav[0].trg_mode = AD_TRG_NONE;          // No trigger means, storing immendiatly

            sd.sample_rate = 1/sample_rate; // 500Hz sampling, max 20kHz
            sd.prehist = 0;
            sd.posthist = Convert.ToUInt64(values_per_scan);      // how many values per scan
            sd.ticks_per_run = Convert.ToUInt32(values_per_run);  // how many values per run

            number_runs = Convert.ToUInt32(how_many_runs) / sd.ticks_per_run -1;


            rc = ad_start_scan(adh, ref sd, 1, chav);
            if (rc != 0)
            {
                // error handeling
            }
        }

        /// <summary>
        /// Get the values a run during a scan.
        /// </summary>
        /// <param name="run_id">Number that represents the run. Usually used as counter to know when to restart</param>
        /// <returns>Values of the run | float[]</returns>
        public float[] get_values(uint run_id)
        {
            float[] result = new float[values_per_run]; 
            int rc;
            int scan_result=1;
            ad_scan_state state = new ad_scan_state();

            rc = ad_get_next_run_f(adh, ref state, ref run_id, ref result);
            if (rc != 0)
            {
                /* error handling ... */
                MessageBox.Show("Error: !");
            }

            // When reaching a certain number of runs, the scan has to be restarted
            if (run_id % number_runs == 0 & run_id!=0)
            {
                rc = ad_stop_scan(adh, ref scan_result);
                start_scan(sample_rate, values_per_scan, values_per_run, how_many_runs);
            }

            return result;
        }

    }
}
