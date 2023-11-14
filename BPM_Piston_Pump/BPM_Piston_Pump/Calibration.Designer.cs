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
            groupBoxSpeed = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            panel1 = new Panel();
            progressBar1 = new ProgressBar();
            groupBoxPressure = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            button2 = new Button();
            panel3 = new Panel();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            panel4 = new Panel();
            groupBoxSpeed.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel1.SuspendLayout();
            groupBoxPressure.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(110, 25);
            label1.TabIndex = 0;
            label1.Text = "Calibration";
            // 
            // groupBoxSpeed
            // 
            groupBoxSpeed.Controls.Add(tableLayoutPanel1);
            groupBoxSpeed.Dock = DockStyle.Top;
            groupBoxSpeed.ForeColor = SystemColors.ControlLightLight;
            groupBoxSpeed.Location = new Point(3, 0);
            groupBoxSpeed.Margin = new Padding(3, 0, 3, 3);
            groupBoxSpeed.Name = "groupBoxSpeed";
            groupBoxSpeed.Size = new Size(742, 115);
            groupBoxSpeed.TabIndex = 1;
            groupBoxSpeed.TabStop = false;
            groupBoxSpeed.Text = "Pump Speed";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(736, 93);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(numericUpDown1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(362, 40);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(58, 2);
            label2.Name = "label2";
            label2.Size = new Size(58, 17);
            label2.TabIndex = 3;
            label2.Text = "mmHg/s";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(23, 21, 32);
            numericUpDown1.BorderStyle = BorderStyle.None;
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.ForeColor = SystemColors.ControlLightLight;
            numericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown1.Location = new Point(3, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(49, 21);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.TextAlign = HorizontalAlignment.Right;
            numericUpDown1.UpDownAlign = LeftRightAlignment.Left;
            numericUpDown1.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Dock = DockStyle.Bottom;
            button1.FlatAppearance.BorderColor = Color.FromArgb(63, 61, 72);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(3, 49);
            button1.Name = "button1";
            button1.Size = new Size(362, 41);
            button1.TabIndex = 4;
            button1.Text = "Start Calibration";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 3, 3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(748, 46);
            panel1.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 553);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(748, 30);
            progressBar1.TabIndex = 3;
            // 
            // groupBoxPressure
            // 
            groupBoxPressure.Controls.Add(tableLayoutPanel2);
            groupBoxPressure.Dock = DockStyle.Top;
            groupBoxPressure.ForeColor = SystemColors.ControlLightLight;
            groupBoxPressure.Location = new Point(3, 115);
            groupBoxPressure.Name = "groupBoxPressure";
            groupBoxPressure.Size = new Size(742, 138);
            groupBoxPressure.TabIndex = 5;
            groupBoxPressure.TabStop = false;
            groupBoxPressure.Text = "Pressure Sensor";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(button2, 0, 1);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 19);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(736, 116);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Bottom;
            button2.FlatAppearance.BorderColor = Color.FromArgb(63, 61, 72);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(3, 66);
            button2.Name = "button2";
            button2.Size = new Size(362, 47);
            button2.TabIndex = 6;
            button2.Text = "Start Calibration";
            button2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(numericUpDown2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(362, 52);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(72, 2);
            label3.Name = "label3";
            label3.Size = new Size(67, 17);
            label3.TabIndex = 1;
            label3.Text = "samples/s";
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.FromArgb(23, 21, 32);
            numericUpDown2.BorderStyle = BorderStyle.None;
            numericUpDown2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown2.ForeColor = SystemColors.ControlLightLight;
            numericUpDown2.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown2.Location = new Point(3, 3);
            numericUpDown2.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(63, 21);
            numericUpDown2.TabIndex = 0;
            numericUpDown2.TextAlign = HorizontalAlignment.Right;
            numericUpDown2.UpDownAlign = LeftRightAlignment.Left;
            numericUpDown2.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // panel4
            // 
            panel4.Controls.Add(groupBoxPressure);
            panel4.Controls.Add(groupBoxSpeed);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 46);
            panel4.Margin = new Padding(3, 0, 3, 3);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3, 0, 3, 0);
            panel4.Size = new Size(748, 507);
            panel4.TabIndex = 6;
            // 
            // Calibration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(748, 583);
            Controls.Add(panel4);
            Controls.Add(progressBar1);
            Controls.Add(panel1);
            Name = "Calibration";
            Text = "Calibration";
            groupBoxSpeed.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBoxPressure.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBoxSpeed;
        private Panel panel1;
        private ProgressBar progressBar1;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private GroupBox groupBoxPressure;
        private TableLayoutPanel tableLayoutPanel2;
        private NumericUpDown numericUpDown2;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private Button button2;
        private Panel panel4;
    }
}