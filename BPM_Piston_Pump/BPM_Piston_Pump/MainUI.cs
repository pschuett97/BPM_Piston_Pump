using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace BPM_Piston_Pump
{
    public partial class MainUI : Form
    {
        AppConfig config;
        private Form activeForm = null;

        public MainUI()
        {
            InitializeComponent();
            config = new AppConfig();

            // show the developer button if developer is enabled
            if (int.Parse(config.param["developer"]) == 1)
                checkDeveloper.Checked = true;
            else
                checkDeveloper.Checked = false;

            // load the help.rtf file in the richTextBox container
            if (File.Exists("help.rtf"))
            {
                try
                {
                    richTextBox1.LoadFile("help.rtf");
                }
                catch (IOException)
                {
                    richTextBox1.Text = "Please close help.rtf file";
                }
            }
            else
            {
                richTextBox1.Text = "Cannot find help.rtf file!";
            }

            //config.loadConfig();
            //btnHelp.Text = config.param["log_file_name"].ToString();
        }

        /// <summary>
        /// Closes the old form and opens a new one.
        /// </summary>
        /// <param name="childForm"></param>
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            openChildForm(new Measure(config));
        }

        private void btnCalibration_Click(object sender, EventArgs e)
        {
            openChildForm(new Calibration(config));
        }

        private void btnDeveloper_Click(object sender, EventArgs e)
        {
            openChildForm(new Developer(config));
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
        }

        #region Button Hover Effect
        private void btnMeasure_MouseEnter(object sender, EventArgs e)
        {
            btnMeasure.BackColor = ColorTranslator.FromHtml("#1B171B");
        }

        private void btnMeasure_MouseLeave(object sender, EventArgs e)
        {
            btnMeasure.BackColor = ColorTranslator.FromHtml("#0B070B");
        }

        private void btnCalibration_MouseEnter(object sender, EventArgs e)
        {
            btnCalibration.BackColor = ColorTranslator.FromHtml("#1B171B");
        }

        private void btnCalibration_MouseLeave(object sender, EventArgs e)
        {
            btnCalibration.BackColor = ColorTranslator.FromHtml("#0B070B");
        }

        private void btnDeveloper_MouseEnter(object sender, EventArgs e)
        {
            btnDeveloper.BackColor = ColorTranslator.FromHtml("#1B171B");
        }

        private void btnDeveloper_MouseLeave(object sender, EventArgs e)
        {
            btnDeveloper.BackColor = ColorTranslator.FromHtml("#0B070B");
        }

        private void btnHelp_MouseEnter(object sender, EventArgs e)
        {
            btnHelp.BackColor = ColorTranslator.FromHtml("#1B171B");
        }

        private void btnHelp_MouseLeave(object sender, EventArgs e)
        {
            btnHelp.BackColor = ColorTranslator.FromHtml("#0B070B");
        }

        private void btnAnalysis_MouseEnter(object sender, EventArgs e)
        {
            btnAnalysis.BackColor = ColorTranslator.FromHtml("#1B171B");
        }

        private void btnAnalysis_MouseLeave(object sender, EventArgs e)
        {
            btnAnalysis.BackColor = ColorTranslator.FromHtml("#0B070B");
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start(new ProcessStartInfo("mailto:p.schuettengruber@outlook.com") { UseShellExecute = true });
        }

        /// <summary>
        /// Activate or deactivate the developer button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkDeveloper_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDeveloper.Checked)
            {
                btnDeveloper.Visible = true;
                config.param["developer"] = "1";
            }

            else
            {
                btnDeveloper.Visible = false;
                config.param["developer"] = "0";
            }

        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            openChildForm(new Analysis(config));
        }
    }
}