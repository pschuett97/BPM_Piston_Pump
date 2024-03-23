namespace BPM_Piston_Pump
{
    partial class MainUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            tableLayoutPanel1 = new TableLayoutPanel();
            panelSideMenu = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnMeasure = new Button();
            btnCalibration = new Button();
            pictureBox1 = new PictureBox();
            btnHelp = new Button();
            btnDeveloper = new Button();
            btnAnalysis = new Button();
            panelChildForm = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1 = new Panel();
            checkDeveloper = new CheckBox();
            linkLabel1 = new LinkLabel();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panelSideMenu.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelChildForm.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 159F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panelSideMenu, 0, 0);
            tableLayoutPanel1.Controls.Add(panelChildForm, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = Color.FromArgb(11, 9, 11);
            panelSideMenu.Controls.Add(tableLayoutPanel2);
            panelSideMenu.Dock = DockStyle.Fill;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Margin = new Padding(0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(159, 450);
            panelSideMenu.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnMeasure, 0, 1);
            tableLayoutPanel2.Controls.Add(btnCalibration, 0, 2);
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(btnHelp, 0, 6);
            tableLayoutPanel2.Controls.Add(btnDeveloper, 0, 4);
            tableLayoutPanel2.Controls.Add(btnAnalysis, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(159, 450);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // btnMeasure
            // 
            btnMeasure.Dock = DockStyle.Fill;
            btnMeasure.FlatAppearance.BorderSize = 0;
            btnMeasure.FlatStyle = FlatStyle.Flat;
            btnMeasure.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMeasure.ForeColor = SystemColors.ControlLightLight;
            btnMeasure.Location = new Point(2, 69);
            btnMeasure.Margin = new Padding(2);
            btnMeasure.Name = "btnMeasure";
            btnMeasure.Padding = new Padding(4, 0, 0, 0);
            btnMeasure.Size = new Size(155, 41);
            btnMeasure.TabIndex = 1;
            btnMeasure.Text = "Measure";
            btnMeasure.TextAlign = ContentAlignment.MiddleLeft;
            btnMeasure.UseVisualStyleBackColor = true;
            btnMeasure.Click += btnMeasure_Click;
            btnMeasure.MouseEnter += btnMeasure_MouseEnter;
            btnMeasure.MouseLeave += btnMeasure_MouseLeave;
            // 
            // btnCalibration
            // 
            btnCalibration.Dock = DockStyle.Fill;
            btnCalibration.FlatAppearance.BorderSize = 0;
            btnCalibration.FlatStyle = FlatStyle.Flat;
            btnCalibration.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalibration.ForeColor = SystemColors.ControlLightLight;
            btnCalibration.Location = new Point(2, 114);
            btnCalibration.Margin = new Padding(2);
            btnCalibration.Name = "btnCalibration";
            btnCalibration.Padding = new Padding(4, 0, 0, 0);
            btnCalibration.Size = new Size(155, 41);
            btnCalibration.TabIndex = 2;
            btnCalibration.Text = "Calibration";
            btnCalibration.TextAlign = ContentAlignment.MiddleLeft;
            btnCalibration.UseVisualStyleBackColor = true;
            btnCalibration.Click += btnCalibration_Click;
            btnCalibration.MouseEnter += btnCalibration_MouseEnter;
            btnCalibration.MouseLeave += btnCalibration_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(8, 4);
            pictureBox1.Margin = new Padding(8, 4, 8, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnHelp
            // 
            btnHelp.Cursor = Cursors.Help;
            btnHelp.Dock = DockStyle.Fill;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnHelp.ForeColor = SystemColors.ControlLightLight;
            btnHelp.Location = new Point(2, 406);
            btnHelp.Margin = new Padding(2);
            btnHelp.Name = "btnHelp";
            btnHelp.Padding = new Padding(4, 0, 0, 0);
            btnHelp.Size = new Size(155, 42);
            btnHelp.TabIndex = 4;
            btnHelp.Text = "Help";
            btnHelp.TextAlign = ContentAlignment.MiddleLeft;
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            btnHelp.MouseEnter += btnHelp_MouseEnter;
            btnHelp.MouseLeave += btnHelp_MouseLeave;
            // 
            // btnDeveloper
            // 
            btnDeveloper.Dock = DockStyle.Fill;
            btnDeveloper.FlatAppearance.BorderSize = 0;
            btnDeveloper.FlatStyle = FlatStyle.Flat;
            btnDeveloper.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeveloper.ForeColor = SystemColors.ControlLightLight;
            btnDeveloper.Location = new Point(2, 204);
            btnDeveloper.Margin = new Padding(2);
            btnDeveloper.Name = "btnDeveloper";
            btnDeveloper.Padding = new Padding(4, 0, 0, 0);
            btnDeveloper.Size = new Size(155, 41);
            btnDeveloper.TabIndex = 3;
            btnDeveloper.Text = "Developer";
            btnDeveloper.TextAlign = ContentAlignment.MiddleLeft;
            btnDeveloper.UseVisualStyleBackColor = true;
            btnDeveloper.Click += btnDeveloper_Click;
            btnDeveloper.MouseEnter += btnDeveloper_MouseEnter;
            btnDeveloper.MouseLeave += btnDeveloper_MouseLeave;
            // 
            // btnAnalysis
            // 
            btnAnalysis.Dock = DockStyle.Fill;
            btnAnalysis.FlatAppearance.BorderSize = 0;
            btnAnalysis.FlatStyle = FlatStyle.Flat;
            btnAnalysis.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnalysis.ForeColor = SystemColors.ControlLightLight;
            btnAnalysis.Location = new Point(2, 159);
            btnAnalysis.Margin = new Padding(2);
            btnAnalysis.Name = "btnAnalysis";
            btnAnalysis.Padding = new Padding(4, 0, 0, 0);
            btnAnalysis.Size = new Size(155, 41);
            btnAnalysis.TabIndex = 7;
            btnAnalysis.Text = "Analysis";
            btnAnalysis.TextAlign = ContentAlignment.MiddleLeft;
            btnAnalysis.UseVisualStyleBackColor = true;
            btnAnalysis.Click += btnAnalysis_Click;
            btnAnalysis.MouseEnter += btnAnalysis_MouseEnter;
            btnAnalysis.MouseLeave += btnAnalysis_MouseLeave;
            // 
            // panelChildForm
            // 
            panelChildForm.Controls.Add(panel2);
            panelChildForm.Controls.Add(label2);
            panelChildForm.Dock = DockStyle.Fill;
            panelChildForm.Location = new Point(162, 3);
            panelChildForm.Name = "panelChildForm";
            panelChildForm.Size = new Size(635, 444);
            panelChildForm.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(richTextBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(635, 444);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 371);
            panel3.Name = "panel3";
            panel3.Size = new Size(635, 73);
            panel3.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkDeveloper);
            panel1.Controls.Add(linkLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(635, 73);
            panel1.TabIndex = 9;
            // 
            // checkDeveloper
            // 
            checkDeveloper.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkDeveloper.AutoSize = true;
            checkDeveloper.Checked = true;
            checkDeveloper.CheckState = CheckState.Checked;
            checkDeveloper.ForeColor = SystemColors.ControlLightLight;
            checkDeveloper.Location = new Point(522, 24);
            checkDeveloper.Name = "checkDeveloper";
            checkDeveloper.Size = new Size(79, 19);
            checkDeveloper.TabIndex = 6;
            checkDeveloper.Text = "Developer";
            checkDeveloper.UseVisualStyleBackColor = true;
            checkDeveloper.CheckedChanged += checkDeveloper_CheckedChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(9, 25);
            linkLabel1.Margin = new Padding(2, 0, 2, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(49, 15);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Contact";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(23, 21, 32);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.ForeColor = SystemColors.ControlLightLight;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(635, 444);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(2, 113);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(700, 450);
            Name = "MainUI";
            Text = "Blood Pressure Measurement Device";
            tableLayoutPanel1.ResumeLayout(false);
            panelSideMenu.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelChildForm.ResumeLayout(false);
            panelChildForm.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelSideMenu;
        private Panel panelChildForm;
        private Button btnMeasure;
        private Button btnHelp;
        private Button btnDeveloper;
        private Button btnCalibration;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private CheckBox checkDeveloper;
        private Button btnAnalysis;
        private RichTextBox richTextBox1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}