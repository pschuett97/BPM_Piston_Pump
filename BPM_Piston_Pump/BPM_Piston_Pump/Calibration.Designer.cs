namespace BPM_Piston_Pump
{
    partial class Calibration
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
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblADC = new Label();
            numSampleRate = new NumericUpDown();
            numVoltLowEnd = new NumericUpDown();
            numVoltHighEnd = new NumericUpDown();
            numHgLowEnd = new NumericUpDown();
            numHgHighEnd = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnADC = new Button();
            groupBox2 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            numStepSize = new NumericUpDown();
            label10 = new Label();
            numTolerance = new NumericUpDown();
            numSpeedInflation = new NumericUpDown();
            label6 = new Label();
            label12 = new Label();
            btnCalibrateSpeed = new Button();
            panel2 = new Panel();
            btnSaveSettings = new Button();
            lblLeakprooftestResult = new Label();
            progressBar1 = new ProgressBar();
            btnLeakproofTestStart = new Button();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSampleRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVoltLowEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVoltHighEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHgLowEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHgHighEnd).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStepSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTolerance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSpeedInflation).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(5, 5);
            label1.Margin = new Padding(5, 5, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 25);
            label1.TabIndex = 0;
            label1.Text = "Calibration";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 2);
            tableLayoutPanel1.Controls.Add(panel2, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23F));
            tableLayoutPanel1.Size = new Size(748, 583);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(3, 43);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(742, 209);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pressure Snesor";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(lblADC, 3, 0);
            tableLayoutPanel2.Controls.Add(numSampleRate, 0, 0);
            tableLayoutPanel2.Controls.Add(numVoltLowEnd, 0, 1);
            tableLayoutPanel2.Controls.Add(numVoltHighEnd, 0, 2);
            tableLayoutPanel2.Controls.Add(numHgLowEnd, 2, 1);
            tableLayoutPanel2.Controls.Add(numHgHighEnd, 2, 2);
            tableLayoutPanel2.Controls.Add(label3, 1, 0);
            tableLayoutPanel2.Controls.Add(label4, 1, 1);
            tableLayoutPanel2.Controls.Add(label5, 1, 2);
            tableLayoutPanel2.Controls.Add(label7, 3, 1);
            tableLayoutPanel2.Controls.Add(label8, 3, 2);
            tableLayoutPanel2.Controls.Add(btnADC, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 23);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(736, 183);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // lblADC
            // 
            lblADC.AutoSize = true;
            lblADC.Location = new Point(303, 2);
            lblADC.Margin = new Padding(3, 2, 3, 0);
            lblADC.Name = "lblADC";
            lblADC.Size = new Size(52, 20);
            lblADC.TabIndex = 14;
            lblADC.Text = "Value: ";
            // 
            // numSampleRate
            // 
            numSampleRate.BackColor = Color.FromArgb(23, 21, 32);
            numSampleRate.BorderStyle = BorderStyle.None;
            numSampleRate.Dock = DockStyle.Right;
            numSampleRate.ForeColor = SystemColors.ControlLightLight;
            numSampleRate.Location = new Point(4, 3);
            numSampleRate.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numSampleRate.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numSampleRate.Name = "numSampleRate";
            numSampleRate.Size = new Size(83, 23);
            numSampleRate.TabIndex = 0;
            numSampleRate.TextAlign = HorizontalAlignment.Right;
            numSampleRate.UpDownAlign = LeftRightAlignment.Left;
            numSampleRate.Value = new decimal(new int[] { 500, 0, 0, 0 });
            numSampleRate.ValueChanged += numSampleRate_ValueChanged;
            // 
            // numVoltLowEnd
            // 
            numVoltLowEnd.BackColor = Color.FromArgb(23, 21, 32);
            numVoltLowEnd.BorderStyle = BorderStyle.None;
            numVoltLowEnd.DecimalPlaces = 4;
            numVoltLowEnd.Dock = DockStyle.Right;
            numVoltLowEnd.ForeColor = SystemColors.ControlLightLight;
            numVoltLowEnd.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numVoltLowEnd.Location = new Point(4, 64);
            numVoltLowEnd.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numVoltLowEnd.Name = "numVoltLowEnd";
            numVoltLowEnd.Size = new Size(83, 23);
            numVoltLowEnd.TabIndex = 1;
            numVoltLowEnd.TextAlign = HorizontalAlignment.Right;
            numVoltLowEnd.UpDownAlign = LeftRightAlignment.Left;
            numVoltLowEnd.Value = new decimal(new int[] { 5, 0, 0, 131072 });
            numVoltLowEnd.ValueChanged += numVoltLowEnd_ValueChanged;
            // 
            // numVoltHighEnd
            // 
            numVoltHighEnd.BackColor = Color.FromArgb(23, 21, 32);
            numVoltHighEnd.BorderStyle = BorderStyle.None;
            numVoltHighEnd.DecimalPlaces = 4;
            numVoltHighEnd.Dock = DockStyle.Right;
            numVoltHighEnd.ForeColor = SystemColors.ControlLightLight;
            numVoltHighEnd.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numVoltHighEnd.Location = new Point(4, 125);
            numVoltHighEnd.Maximum = new decimal(new int[] { 11, 0, 0, 0 });
            numVoltHighEnd.Name = "numVoltHighEnd";
            numVoltHighEnd.Size = new Size(83, 23);
            numVoltHighEnd.TabIndex = 2;
            numVoltHighEnd.TextAlign = HorizontalAlignment.Right;
            numVoltHighEnd.UpDownAlign = LeftRightAlignment.Left;
            numVoltHighEnd.Value = new decimal(new int[] { 94, 0, 0, 65536 });
            numVoltHighEnd.ValueChanged += numVoltHighEnd_ValueChanged;
            // 
            // numHgLowEnd
            // 
            numHgLowEnd.Anchor = AnchorStyles.Top;
            numHgLowEnd.BackColor = Color.FromArgb(23, 21, 32);
            numHgLowEnd.BorderStyle = BorderStyle.None;
            numHgLowEnd.DecimalPlaces = 2;
            numHgLowEnd.ForeColor = SystemColors.ControlLightLight;
            numHgLowEnd.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numHgLowEnd.Location = new Point(235, 64);
            numHgLowEnd.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numHgLowEnd.Name = "numHgLowEnd";
            numHgLowEnd.Size = new Size(59, 23);
            numHgLowEnd.TabIndex = 4;
            numHgLowEnd.TextAlign = HorizontalAlignment.Right;
            numHgLowEnd.UpDownAlign = LeftRightAlignment.Left;
            numHgLowEnd.ValueChanged += numHgLowEnd_ValueChanged;
            // 
            // numHgHighEnd
            // 
            numHgHighEnd.Anchor = AnchorStyles.Top;
            numHgHighEnd.BackColor = Color.FromArgb(23, 21, 32);
            numHgHighEnd.BorderStyle = BorderStyle.None;
            numHgHighEnd.DecimalPlaces = 1;
            numHgHighEnd.ForeColor = SystemColors.ControlLightLight;
            numHgHighEnd.Location = new Point(235, 125);
            numHgHighEnd.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numHgHighEnd.Name = "numHgHighEnd";
            numHgHighEnd.Size = new Size(59, 23);
            numHgHighEnd.TabIndex = 5;
            numHgHighEnd.TextAlign = HorizontalAlignment.Right;
            numHgHighEnd.UpDownAlign = LeftRightAlignment.Left;
            numHgHighEnd.Value = new decimal(new int[] { 300, 0, 0, 0 });
            numHgHighEnd.ValueChanged += numHgHighEnd_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(93, 2);
            label3.Margin = new Padding(3, 2, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 59);
            label3.TabIndex = 6;
            label3.Text = "samples/s";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(93, 63);
            label4.Margin = new Padding(3, 2, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(134, 59);
            label4.TabIndex = 7;
            label4.Text = "volt correspond to";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(93, 124);
            label5.Margin = new Padding(3, 2, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(134, 59);
            label5.TabIndex = 8;
            label5.Text = "volt correspond to";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(303, 63);
            label7.Margin = new Padding(3, 2, 3, 0);
            label7.Name = "label7";
            label7.Size = new Size(55, 20);
            label7.TabIndex = 10;
            label7.Text = "mmHg";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(303, 124);
            label8.Margin = new Padding(3, 2, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(55, 20);
            label8.TabIndex = 11;
            label8.Text = "mmHg";
            // 
            // btnADC
            // 
            btnADC.FlatAppearance.BorderColor = Color.FromArgb(63, 61, 72);
            btnADC.FlatStyle = FlatStyle.Flat;
            btnADC.Location = new Point(233, 3);
            btnADC.Name = "btnADC";
            btnADC.Size = new Size(59, 31);
            btnADC.TabIndex = 13;
            btnADC.Text = "ADC";
            btnADC.UseVisualStyleBackColor = true;
            btnADC.Click += btnADC_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel3);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ControlLightLight;
            groupBox2.Location = new Point(3, 258);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(742, 186);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pump Speed Calibration";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 5;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(numStepSize, 0, 1);
            tableLayoutPanel3.Controls.Add(label10, 3, 0);
            tableLayoutPanel3.Controls.Add(numTolerance, 2, 0);
            tableLayoutPanel3.Controls.Add(numSpeedInflation, 0, 0);
            tableLayoutPanel3.Controls.Add(label6, 1, 0);
            tableLayoutPanel3.Controls.Add(label12, 1, 1);
            tableLayoutPanel3.Controls.Add(btnCalibrateSpeed, 2, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 23);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(736, 160);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // numStepSize
            // 
            numStepSize.BackColor = Color.FromArgb(23, 21, 32);
            numStepSize.BorderStyle = BorderStyle.None;
            numStepSize.DecimalPlaces = 1;
            numStepSize.Dock = DockStyle.Right;
            numStepSize.ForeColor = SystemColors.ControlLightLight;
            numStepSize.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numStepSize.Location = new Point(4, 83);
            numStepSize.Maximum = new decimal(new int[] { 5, 0, 0, 65536 });
            numStepSize.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            numStepSize.Name = "numStepSize";
            numStepSize.Size = new Size(83, 23);
            numStepSize.TabIndex = 14;
            numStepSize.TextAlign = HorizontalAlignment.Right;
            numStepSize.UpDownAlign = LeftRightAlignment.Left;
            numStepSize.Value = new decimal(new int[] { 2, 0, 0, 65536 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(303, 2);
            label10.Margin = new Padding(3, 2, 3, 0);
            label10.Name = "label10";
            label10.Size = new Size(81, 40);
            label10.TabIndex = 11;
            label10.Text = "[mmHg/s] tolerance";
            // 
            // numTolerance
            // 
            numTolerance.BackColor = Color.FromArgb(23, 21, 32);
            numTolerance.BorderStyle = BorderStyle.None;
            numTolerance.DecimalPlaces = 1;
            numTolerance.Dock = DockStyle.Right;
            numTolerance.ForeColor = SystemColors.ControlLightLight;
            numTolerance.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numTolerance.Location = new Point(238, 3);
            numTolerance.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numTolerance.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numTolerance.Name = "numTolerance";
            numTolerance.Size = new Size(59, 23);
            numTolerance.TabIndex = 7;
            numTolerance.TextAlign = HorizontalAlignment.Right;
            numTolerance.UpDownAlign = LeftRightAlignment.Left;
            numTolerance.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            numTolerance.ValueChanged += numTolerance_ValueChanged;
            // 
            // numSpeedInflation
            // 
            numSpeedInflation.BackColor = Color.FromArgb(23, 21, 32);
            numSpeedInflation.BorderStyle = BorderStyle.None;
            numSpeedInflation.DecimalPlaces = 1;
            numSpeedInflation.Dock = DockStyle.Right;
            numSpeedInflation.ForeColor = SystemColors.ControlLightLight;
            numSpeedInflation.Location = new Point(4, 3);
            numSpeedInflation.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numSpeedInflation.Name = "numSpeedInflation";
            numSpeedInflation.Size = new Size(83, 23);
            numSpeedInflation.TabIndex = 3;
            numSpeedInflation.TextAlign = HorizontalAlignment.Right;
            numSpeedInflation.UpDownAlign = LeftRightAlignment.Left;
            numSpeedInflation.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numSpeedInflation.ValueChanged += numSpeedInflation_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(93, 2);
            label6.Margin = new Padding(3, 2, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(125, 40);
            label6.TabIndex = 5;
            label6.Text = "[mmHg/s] target velocity";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(93, 82);
            label12.Margin = new Padding(3, 2, 3, 0);
            label12.Name = "label12";
            label12.Size = new Size(89, 20);
            label12.TabIndex = 13;
            label12.Text = "[V] step size";
            // 
            // btnCalibrateSpeed
            // 
            tableLayoutPanel3.SetColumnSpan(btnCalibrateSpeed, 2);
            btnCalibrateSpeed.FlatAppearance.BorderColor = Color.FromArgb(63, 61, 72);
            btnCalibrateSpeed.FlatStyle = FlatStyle.Flat;
            btnCalibrateSpeed.Location = new Point(233, 83);
            btnCalibrateSpeed.Name = "btnCalibrateSpeed";
            btnCalibrateSpeed.Size = new Size(151, 41);
            btnCalibrateSpeed.TabIndex = 0;
            btnCalibrateSpeed.Text = "Calibrate";
            btnCalibrateSpeed.UseVisualStyleBackColor = true;
            btnCalibrateSpeed.Click += btnCalibrateSpeed_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSaveSettings);
            panel2.Controls.Add(lblLeakprooftestResult);
            panel2.Controls.Add(progressBar1);
            panel2.Controls.Add(btnLeakproofTestStart);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 450);
            panel2.Name = "panel2";
            panel2.Size = new Size(742, 130);
            panel2.TabIndex = 2;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Dock = DockStyle.Right;
            btnSaveSettings.FlatAppearance.BorderColor = Color.FromArgb(63, 61, 72);
            btnSaveSettings.FlatStyle = FlatStyle.Flat;
            btnSaveSettings.ForeColor = SystemColors.ControlLightLight;
            btnSaveSettings.Location = new Point(626, 0);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(116, 107);
            btnSaveSettings.TabIndex = 4;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // lblLeakprooftestResult
            // 
            lblLeakprooftestResult.AutoSize = true;
            lblLeakprooftestResult.ForeColor = SystemColors.ControlLightLight;
            lblLeakprooftestResult.Location = new Point(9, 23);
            lblLeakprooftestResult.Name = "lblLeakprooftestResult";
            lblLeakprooftestResult.Size = new Size(42, 15);
            lblLeakprooftestResult.TabIndex = 3;
            lblLeakprooftestResult.Text = "Result:";
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 107);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(742, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 2;
            progressBar1.Visible = false;
            // 
            // btnLeakproofTestStart
            // 
            btnLeakproofTestStart.FlatAppearance.BorderColor = Color.FromArgb(63, 61, 72);
            btnLeakproofTestStart.FlatStyle = FlatStyle.Flat;
            btnLeakproofTestStart.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnLeakproofTestStart.ForeColor = SystemColors.ControlLightLight;
            btnLeakproofTestStart.Location = new Point(149, 0);
            btnLeakproofTestStart.Name = "btnLeakproofTestStart";
            btnLeakproofTestStart.Size = new Size(133, 25);
            btnLeakproofTestStart.TabIndex = 1;
            btnLeakproofTestStart.Text = "Start";
            btnLeakproofTestStart.UseVisualStyleBackColor = true;
            btnLeakproofTestStart.Click += btnLeakproofTestStart_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(9, 2);
            label2.Name = "label2";
            label2.Size = new Size(141, 21);
            label2.TabIndex = 0;
            label2.Text = "Leakproofness Test";
            // 
            // Calibration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(748, 583);
            Controls.Add(tableLayoutPanel1);
            Name = "Calibration";
            Text = "Calibration";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSampleRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVoltLowEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVoltHighEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHgLowEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHgHighEnd).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStepSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTolerance).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSpeedInflation).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel2;
        private Label label2;
        private Button btnLeakproofTestStart;
        private ProgressBar progressBar1;
        private TableLayoutPanel tableLayoutPanel2;
        private NumericUpDown numSampleRate;
        private NumericUpDown numVoltLowEnd;
        private NumericUpDown numVoltHighEnd;
        private NumericUpDown numHgLowEnd;
        private NumericUpDown numHgHighEnd;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel3;
        private NumericUpDown numSpeedInflation;
        private Label label6;
        private Button btnCalibrateSpeed;
        private Label lblLeakprooftestResult;
        private Button btnSaveSettings;
        private Label label12;
        private Label label10;
        private NumericUpDown numTolerance;
        private Label lblADC;
        private Button btnADC;
        private NumericUpDown numStepSize;
    }
}