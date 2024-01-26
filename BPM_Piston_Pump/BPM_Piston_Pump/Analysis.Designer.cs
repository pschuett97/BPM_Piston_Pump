namespace BPM_Piston_Pump
{
    partial class Analysis
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            plotData = new ScottPlot.FormsPlot();
            flowLayoutPanel2 = new FlowLayoutPanel();
            checkSignal = new CheckBox();
            checkHighpass = new CheckBox();
            checkPeaks = new CheckBox();
            checkEnvelop = new CheckBox();
            checkLowpass = new CheckBox();
            txtBP = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            btnGo = new Button();
            butXLarge = new Button();
            butXSmall = new Button();
            butYLarge = new Button();
            butYSmall = new Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(plotData, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(txtBP, 1, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(748, 583);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 1;
            label1.Text = "Analysis";
            // 
            // plotData
            // 
            tableLayoutPanel1.SetColumnSpan(plotData, 2);
            plotData.Dock = DockStyle.Fill;
            plotData.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            plotData.ForeColor = SystemColors.ControlLightLight;
            plotData.Location = new Point(5, 114);
            plotData.Margin = new Padding(5, 4, 5, 4);
            plotData.Name = "plotData";
            plotData.Size = new Size(738, 465);
            plotData.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(checkSignal);
            flowLayoutPanel2.Controls.Add(checkHighpass);
            flowLayoutPanel2.Controls.Add(checkPeaks);
            flowLayoutPanel2.Controls.Add(checkEnvelop);
            flowLayoutPanel2.Controls.Add(checkLowpass);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(377, 43);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(368, 64);
            flowLayoutPanel2.TabIndex = 6;
            // 
            // checkSignal
            // 
            checkSignal.AutoSize = true;
            checkSignal.ForeColor = SystemColors.ControlLightLight;
            checkSignal.Location = new Point(3, 3);
            checkSignal.Name = "checkSignal";
            checkSignal.Size = new Size(58, 19);
            checkSignal.TabIndex = 0;
            checkSignal.Text = "Signal";
            checkSignal.UseVisualStyleBackColor = true;
            checkSignal.CheckedChanged += checkSignal_CheckedChanged;
            // 
            // checkHighpass
            // 
            checkHighpass.AutoSize = true;
            checkHighpass.ForeColor = SystemColors.ControlLightLight;
            checkHighpass.Location = new Point(3, 28);
            checkHighpass.Name = "checkHighpass";
            checkHighpass.Size = new Size(75, 19);
            checkHighpass.TabIndex = 1;
            checkHighpass.Text = "Highpass";
            checkHighpass.UseVisualStyleBackColor = true;
            checkHighpass.CheckedChanged += checkHighpass_CheckedChanged;
            // 
            // checkPeaks
            // 
            checkPeaks.AutoSize = true;
            checkPeaks.ForeColor = SystemColors.ControlLightLight;
            checkPeaks.Location = new Point(84, 3);
            checkPeaks.Name = "checkPeaks";
            checkPeaks.Size = new Size(56, 19);
            checkPeaks.TabIndex = 2;
            checkPeaks.Text = "Peaks";
            checkPeaks.UseVisualStyleBackColor = true;
            checkPeaks.CheckedChanged += checkPeaks_CheckedChanged;
            // 
            // checkEnvelop
            // 
            checkEnvelop.AutoSize = true;
            checkEnvelop.ForeColor = SystemColors.ControlLightLight;
            checkEnvelop.Location = new Point(84, 28);
            checkEnvelop.Name = "checkEnvelop";
            checkEnvelop.Size = new Size(68, 19);
            checkEnvelop.TabIndex = 3;
            checkEnvelop.Text = "Envelop";
            checkEnvelop.UseVisualStyleBackColor = true;
            checkEnvelop.CheckedChanged += checkEnvelop_CheckedChanged;
            // 
            // checkLowpass
            // 
            checkLowpass.AutoSize = true;
            checkLowpass.ForeColor = SystemColors.ControlLightLight;
            checkLowpass.Location = new Point(158, 3);
            checkLowpass.Name = "checkLowpass";
            checkLowpass.Size = new Size(119, 19);
            checkLowpass.TabIndex = 4;
            checkLowpass.Text = "Lowpass/Average";
            checkLowpass.UseVisualStyleBackColor = true;
            checkLowpass.CheckedChanged += checkLowpass_CheckedChanged;
            // 
            // txtBP
            // 
            txtBP.Dock = DockStyle.Left;
            txtBP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBP.Location = new Point(377, 3);
            txtBP.Multiline = true;
            txtBP.Name = "txtBP";
            txtBP.ScrollBars = ScrollBars.Vertical;
            txtBP.Size = new Size(258, 34);
            txtBP.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(btnGo);
            flowLayoutPanel1.Controls.Add(butXLarge);
            flowLayoutPanel1.Controls.Add(butXSmall);
            flowLayoutPanel1.Controls.Add(butYLarge);
            flowLayoutPanel1.Controls.Add(butYSmall);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 43);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(368, 64);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(166, 15);
            label2.TabIndex = 2;
            label2.Text = "Choose data and start analysis";
            // 
            // btnGo
            // 
            btnGo.FlatStyle = FlatStyle.Flat;
            btnGo.ForeColor = SystemColors.ControlLightLight;
            btnGo.Location = new Point(3, 18);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(166, 30);
            btnGo.TabIndex = 3;
            btnGo.Text = "Go";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // butXLarge
            // 
            butXLarge.FlatStyle = FlatStyle.Flat;
            butXLarge.ForeColor = SystemColors.ControlLightLight;
            butXLarge.Location = new Point(175, 3);
            butXLarge.Name = "butXLarge";
            butXLarge.Size = new Size(26, 26);
            butXLarge.TabIndex = 7;
            butXLarge.Text = "x";
            butXLarge.UseVisualStyleBackColor = true;
            butXLarge.Click += butXLarge_Click;
            // 
            // butXSmall
            // 
            butXSmall.FlatStyle = FlatStyle.Flat;
            butXSmall.ForeColor = SystemColors.ControlLightLight;
            butXSmall.Location = new Point(175, 35);
            butXSmall.Name = "butXSmall";
            butXSmall.Size = new Size(26, 26);
            butXSmall.TabIndex = 4;
            butXSmall.Text = "x";
            butXSmall.UseVisualStyleBackColor = true;
            butXSmall.Click += butXSmall_Click;
            // 
            // butYLarge
            // 
            butYLarge.FlatStyle = FlatStyle.Flat;
            butYLarge.ForeColor = SystemColors.ControlLightLight;
            butYLarge.Location = new Point(207, 3);
            butYLarge.Name = "butYLarge";
            butYLarge.Size = new Size(26, 26);
            butYLarge.TabIndex = 6;
            butYLarge.Text = "y";
            butYLarge.UseVisualStyleBackColor = true;
            butYLarge.Click += butYLarge_Click;
            // 
            // butYSmall
            // 
            butYSmall.FlatStyle = FlatStyle.Flat;
            butYSmall.ForeColor = SystemColors.ControlLightLight;
            butYSmall.Location = new Point(207, 35);
            butYSmall.Name = "butYSmall";
            butYSmall.Size = new Size(26, 26);
            butYSmall.TabIndex = 5;
            butYSmall.Text = "y";
            butYSmall.UseVisualStyleBackColor = true;
            butYSmall.Click += butYSmall_Click;
            // 
            // Analysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(748, 583);
            Controls.Add(tableLayoutPanel1);
            Name = "Analysis";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.FormsPlot plotData;
        private Label label1;
        private Label label2;
        private Button btnGo;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox checkSignal;
        private CheckBox checkHighpass;
        private CheckBox checkPeaks;
        private CheckBox checkEnvelop;
        private CheckBox checkLowpass;
        private TextBox txtBP;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button butXSmall;
        private Button butYSmall;
        private Button butYLarge;
        private Button butXLarge;
    }
}