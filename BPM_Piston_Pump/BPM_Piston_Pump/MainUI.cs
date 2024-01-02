using System.Configuration;
using System.Diagnostics;

namespace BPM_Piston_Pump
{
    public partial class MainUI : Form
    {
        AppConfig config;
        public MainUI()
        {
            InitializeComponent();
            config = new AppConfig();
            if (int.Parse(config.param["developer"]) == 1)
                checkDeveloper.Checked = true;
            else
                checkDeveloper.Checked = false;


            //config.loadConfig();
            //btnHelp.Text = config.param["log_file_name"].ToString();
        }

        private Form activeForm = null;
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

        private void checkDeveloper_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDeveloper.Checked)
                btnDeveloper.Visible = true;
            else
                btnDeveloper.Visible = false;
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            openChildForm(new Analysis(config));
        }


    }
}