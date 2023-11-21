namespace BPM_Piston_Pump
{
    partial class Measure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            rdoNormalMode = new RadioButton();
            rdoDynamicMode = new RadioButton();
            panel1 = new Panel();
            tblLayoutMeasure = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            txtLogName = new TextBox();
            btnSaveLog = new Button();
            panel2 = new Panel();
            label2 = new Label();
            numStartPressure = new NumericUpDown();
            label4 = new Label();
            panel3 = new Panel();
            btnStop = new Button();
            btnStart = new Button();
            panelResult = new Panel();
            lblHR = new Label();
            lblMABP = new Label();
            lblDiastolic = new Label();
            lblSystolic = new Label();
            btnTrigger = new Button();
            panel1.SuspendLayout();
            tblLayoutMeasure.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStartPressure).BeginInit();
            panel3.SuspendLayout();
            panelResult.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "Measure";
            // 
            // rdoNormalMode
            // 
            rdoNormalMode.AutoSize = true;
            rdoNormalMode.ForeColor = SystemColors.ControlLightLight;
            rdoNormalMode.Location = new Point(12, 37);
            rdoNormalMode.Name = "rdoNormalMode";
            rdoNormalMode.Size = new Size(99, 19);
            rdoNormalMode.TabIndex = 1;
            rdoNormalMode.TabStop = true;
            rdoNormalMode.Text = "Normal Mode";
            rdoNormalMode.UseVisualStyleBackColor = true;
            rdoNormalMode.CheckedChanged += rdoNormalMode_CheckedChanged;
            // 
            // rdoDynamicMode
            // 
            rdoDynamicMode.AutoSize = true;
            rdoDynamicMode.ForeColor = SystemColors.ControlLightLight;
            rdoDynamicMode.Location = new Point(117, 37);
            rdoDynamicMode.Name = "rdoDynamicMode";
            rdoDynamicMode.Size = new Size(106, 19);
            rdoDynamicMode.TabIndex = 2;
            rdoDynamicMode.TabStop = true;
            rdoDynamicMode.Text = "Dynamic Mode";
            rdoDynamicMode.UseVisualStyleBackColor = true;
            rdoDynamicMode.CheckedChanged += rdoDynamicMode_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(rdoDynamicMode);
            panel1.Controls.Add(rdoNormalMode);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(748, 65);
            panel1.TabIndex = 3;
            // 
            // tblLayoutMeasure
            // 
            tblLayoutMeasure.ColumnCount = 2;
            tblLayoutMeasure.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLayoutMeasure.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLayoutMeasure.Controls.Add(flowLayoutPanel1, 1, 0);
            tblLayoutMeasure.Controls.Add(panel2, 0, 0);
            tblLayoutMeasure.Controls.Add(panel3, 0, 1);
            tblLayoutMeasure.Controls.Add(panelResult, 1, 1);
            tblLayoutMeasure.Dock = DockStyle.Fill;
            tblLayoutMeasure.Location = new Point(0, 65);
            tblLayoutMeasure.Name = "tblLayoutMeasure";
            tblLayoutMeasure.RowCount = 2;
            tblLayoutMeasure.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayoutMeasure.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayoutMeasure.Size = new Size(748, 518);
            tblLayoutMeasure.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(txtLogName);
            flowLayoutPanel1.Controls.Add(btnSaveLog);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(377, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(368, 253);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(148, 15);
            label3.TabIndex = 3;
            label3.Text = "Log file name and location";
            // 
            // txtLogName
            // 
            txtLogName.BackColor = Color.FromArgb(23, 21, 32);
            txtLogName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLogName.ForeColor = SystemColors.ControlLightLight;
            txtLogName.Location = new Point(3, 18);
            txtLogName.Name = "txtLogName";
            txtLogName.Size = new Size(100, 29);
            txtLogName.TabIndex = 4;
            txtLogName.Text = "log.txt";
            // 
            // btnSaveLog
            // 
            btnSaveLog.FlatStyle = FlatStyle.Flat;
            btnSaveLog.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveLog.ForeColor = SystemColors.ControlLightLight;
            btnSaveLog.Location = new Point(3, 53);
            btnSaveLog.Name = "btnSaveLog";
            btnSaveLog.Size = new Size(99, 27);
            btnSaveLog.TabIndex = 5;
            btnSaveLog.Text = "Save";
            btnSaveLog.UseVisualStyleBackColor = true;
            btnSaveLog.Click += btnSaveLog_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(numStartPressure);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(368, 253);
            panel2.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(5, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 0;
            label2.Text = "Start Pressure";
            // 
            // numStartPressure
            // 
            numStartPressure.BackColor = Color.FromArgb(23, 21, 32);
            numStartPressure.BorderStyle = BorderStyle.None;
            numStartPressure.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numStartPressure.ForeColor = SystemColors.ControlLightLight;
            numStartPressure.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numStartPressure.Location = new Point(9, 18);
            numStartPressure.Maximum = new decimal(new int[] { 220, 0, 0, 0 });
            numStartPressure.Name = "numStartPressure";
            numStartPressure.Size = new Size(78, 25);
            numStartPressure.TabIndex = 1;
            numStartPressure.TextAlign = HorizontalAlignment.Right;
            numStartPressure.UpDownAlign = LeftRightAlignment.Left;
            numStartPressure.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numStartPressure.ValueChanged += numStartPressure_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(93, 15);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 7, 0, 0);
            label4.Size = new Size(45, 22);
            label4.TabIndex = 2;
            label4.Text = "mmHg";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnTrigger);
            panel3.Controls.Add(btnStop);
            panel3.Controls.Add(btnStart);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 262);
            panel3.Name = "panel3";
            panel3.Size = new Size(368, 253);
            panel3.TabIndex = 8;
            panel3.Visible = false;
            // 
            // btnStop
            // 
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.ForeColor = SystemColors.ControlLightLight;
            btnStop.Location = new Point(86, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 25);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Visible = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.ForeColor = SystemColors.ControlLightLight;
            btnStart.Location = new Point(5, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 25);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // panelResult
            // 
            panelResult.Controls.Add(lblHR);
            panelResult.Controls.Add(lblMABP);
            panelResult.Controls.Add(lblDiastolic);
            panelResult.Controls.Add(lblSystolic);
            panelResult.Dock = DockStyle.Fill;
            panelResult.Location = new Point(377, 262);
            panelResult.Name = "panelResult";
            panelResult.Size = new Size(368, 253);
            panelResult.TabIndex = 9;
            // 
            // lblHR
            // 
            lblHR.AutoSize = true;
            lblHR.ForeColor = SystemColors.ControlLightLight;
            lblHR.Location = new Point(0, 52);
            lblHR.Name = "lblHR";
            lblHR.Size = new Size(26, 15);
            lblHR.TabIndex = 3;
            lblHR.Text = "HR:";
            // 
            // lblMABP
            // 
            lblMABP.AutoSize = true;
            lblMABP.ForeColor = SystemColors.ControlLightLight;
            lblMABP.Location = new Point(0, 37);
            lblMABP.Name = "lblMABP";
            lblMABP.Size = new Size(43, 15);
            lblMABP.TabIndex = 2;
            lblMABP.Text = "MABP:";
            // 
            // lblDiastolic
            // 
            lblDiastolic.AutoSize = true;
            lblDiastolic.ForeColor = SystemColors.ControlLightLight;
            lblDiastolic.Location = new Point(0, 22);
            lblDiastolic.Name = "lblDiastolic";
            lblDiastolic.Size = new Size(58, 15);
            lblDiastolic.TabIndex = 1;
            lblDiastolic.Text = "Diastolic: ";
            // 
            // lblSystolic
            // 
            lblSystolic.AutoSize = true;
            lblSystolic.ForeColor = SystemColors.ControlLightLight;
            lblSystolic.Location = new Point(0, 7);
            lblSystolic.Name = "lblSystolic";
            lblSystolic.Size = new Size(53, 15);
            lblSystolic.TabIndex = 0;
            lblSystolic.Text = "Systolic: ";
            // 
            // btnTrigger
            // 
            btnTrigger.FlatStyle = FlatStyle.Flat;
            btnTrigger.ForeColor = SystemColors.ControlLightLight;
            btnTrigger.Location = new Point(5, 34);
            btnTrigger.Name = "btnTrigger";
            btnTrigger.Size = new Size(75, 25);
            btnTrigger.TabIndex = 2;
            btnTrigger.Text = "Trigger";
            btnTrigger.UseVisualStyleBackColor = true;
            btnTrigger.Click += btnTrigger_Click;
            // 
            // Measure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(748, 583);
            Controls.Add(tblLayoutMeasure);
            Controls.Add(panel1);
            Name = "Measure";
            Text = "Measure";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tblLayoutMeasure.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStartPressure).EndInit();
            panel3.ResumeLayout(false);
            panelResult.ResumeLayout(false);
            panelResult.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private RadioButton rdoNormalMode;
        private RadioButton rdoDynamicMode;
        private Panel panel1;
        private TableLayoutPanel tblLayoutMeasure;
        private Button btnStart;
        private Label label3;
        private TextBox txtLogName;
        private Button btnSaveLog;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private NumericUpDown numStartPressure;
        private Label label4;
        private Panel panel2;
        private Panel panel3;
        private Button btnStop;
        private Panel panelResult;
        private Label lblSystolic;
        private Label lblDiastolic;
        private Label lblHR;
        private Label lblMABP;
        private Button btnTrigger;
    }
}