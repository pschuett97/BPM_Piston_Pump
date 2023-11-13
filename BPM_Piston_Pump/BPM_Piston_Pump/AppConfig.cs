using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using static System.Windows.Forms.AxHost;
using System.IO.IsolatedStorage;
using static System.Windows.Forms.LinkLabel;

namespace BPM_Piston_Pump
{
    public class AppConfig
    {
        public Dictionary<string, string> param;

        public AppConfig()
        {
            param = new Dictionary<string, string>();
            try
            {
                loadConfig();
            }
            catch (Exception e)
            {
                // if file does not exist, a file with standard values will be created
                if (e.GetType() == typeof(FileNotFoundException))
                {
                    // standard values, hard coded
                    param["v_inflate"] = "3";
                    param["v_deflate"] = "3";
                    param["sample_rate"] = "0.002f";
                    param["values_per_scan"] = "2000";
                    param["values_per_run"] = "250";
                    param["how_many_runs"] = "2000";
                    param["log_file_name"] = "log";
                    param["log_file_path"] = "./";
                    // add new standard values here if needed:
                    // ..
                    saveConfig();
                }
                else
                {
                    throw e;
                }
            }            
        }

        /// <summary>
        /// Save the currend configuration in a csv file
        /// </summary>
        public void saveConfig()
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("./", "config.csv")))
            {
                foreach (KeyValuePair<string, string> entry in param)
                {
                    outputFile.WriteLine(entry.Key+";"+entry.Value.ToString());
                }
            }
        }

        /// <summary>
        /// Load a configuration via a csv file
        /// </summary>
        public void loadConfig()
        { var lines = File.ReadLines("config.csv");
            foreach (var line in lines)
            {
                string key = line.Split(';')[0];
                string val = line.Split(';')[1];
                param[key] = val;
            }
        }
    }
}
