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
            btnHelp = new Button();
            btnMeasure = new Button();
            btnCalibration = new Button();
            btnDeveloper = new Button();
            pictureBox1 = new PictureBox();
            panelChildForm = new Panel();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panelSideMenu.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelChildForm.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 205F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panelSideMenu, 0, 0);
            tableLayoutPanel1.Controls.Add(panelChildForm, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1029, 630);
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
            panelSideMenu.Size = new Size(205, 630);
            panelSideMenu.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnHelp, 0, 5);
            tableLayoutPanel2.Controls.Add(btnMeasure, 0, 1);
            tableLayoutPanel2.Controls.Add(btnCalibration, 0, 2);
            tableLayoutPanel2.Controls.Add(btnDeveloper, 0, 3);
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.Size = new Size(205, 630);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // btnHelp
            // 
            btnHelp.Cursor = Cursors.Help;
            btnHelp.Dock = DockStyle.Fill;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnHelp.ForeColor = SystemColors.ControlLightLight;
            btnHelp.Location = new Point(3, 569);
            btnHelp.Name = "btnHelp";
            btnHelp.Padding = new Padding(5, 0, 0, 0);
            btnHelp.Size = new Size(199, 58);
            btnHelp.TabIndex = 4;
            btnHelp.Text = "Help";
            btnHelp.TextAlign = ContentAlignment.MiddleLeft;
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            btnHelp.MouseEnter += btnHelp_MouseEnter;
            btnHelp.MouseLeave += btnHelp_MouseLeave;
            // 
            // btnMeasure
            // 
            btnMeasure.Dock = DockStyle.Fill;
            btnMeasure.FlatAppearance.BorderSize = 0;
            btnMeasure.FlatStyle = FlatStyle.Flat;
            btnMeasure.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMeasure.ForeColor = SystemColors.ControlLightLight;
            btnMeasure.Location = new Point(3, 97);
            btnMeasure.Name = "btnMeasure";
            btnMeasure.Padding = new Padding(5, 0, 0, 0);
            btnMeasure.Size = new Size(199, 57);
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
            btnCalibration.Location = new Point(3, 160);
            btnCalibration.Name = "btnCalibration";
            btnCalibration.Padding = new Padding(5, 0, 0, 0);
            btnCalibration.Size = new Size(199, 57);
            btnCalibration.TabIndex = 2;
            btnCalibration.Text = "Calibration";
            btnCalibration.TextAlign = ContentAlignment.MiddleLeft;
            btnCalibration.UseVisualStyleBackColor = true;
            btnCalibration.Click += btnCalibration_Click;
            btnCalibration.MouseEnter += btnCalibration_MouseEnter;
            btnCalibration.MouseLeave += btnCalibration_MouseLeave;
            // 
            // btnDeveloper
            // 
            btnDeveloper.Dock = DockStyle.Fill;
            btnDeveloper.FlatAppearance.BorderSize = 0;
            btnDeveloper.FlatStyle = FlatStyle.Flat;
            btnDeveloper.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeveloper.ForeColor = SystemColors.ControlLightLight;
            btnDeveloper.Location = new Point(3, 223);
            btnDeveloper.Name = "btnDeveloper";
            btnDeveloper.Padding = new Padding(5, 0, 0, 0);
            btnDeveloper.Size = new Size(199, 57);
            btnDeveloper.TabIndex = 3;
            btnDeveloper.Text = "Developer";
            btnDeveloper.TextAlign = ContentAlignment.MiddleLeft;
            btnDeveloper.UseVisualStyleBackColor = true;
            btnDeveloper.Click += btnDeveloper_Click;
            btnDeveloper.MouseEnter += btnDeveloper_MouseEnter;
            btnDeveloper.MouseLeave += btnDeveloper_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 5);
            pictureBox1.Margin = new Padding(10, 5, 10, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panelChildForm
            // 
            panelChildForm.Controls.Add(linkLabel1);
            panelChildForm.Controls.Add(label5);
            panelChildForm.Controls.Add(label4);
            panelChildForm.Controls.Add(label3);
            panelChildForm.Controls.Add(label2);
            panelChildForm.Controls.Add(label1);
            panelChildForm.Dock = DockStyle.Fill;
            panelChildForm.Location = new Point(209, 4);
            panelChildForm.Margin = new Padding(4);
            panelChildForm.Name = "panelChildForm";
            panelChildForm.Size = new Size(816, 622);
            panelChildForm.TabIndex = 1;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(92, 198);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(41, 21);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "here";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(3, 198);
            label5.Name = "label5";
            label5.Size = new Size(94, 21);
            label5.TabIndex = 4;
            label5.Text = "Contact him";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(3, 177);
            label4.Name = "label4";
            label4.Size = new Size(459, 21);
            label4.TabIndex = 3;
            label4.Text = "This was the master project of Pascal Schüttengruber in 2023/24.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(3, 156);
            label3.Name = "label3";
            label3.Size = new Size(57, 21);
            label3.TabIndex = 2;
            label3.Text = "About";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(160, 21);
            label2.TabIndex = 1;
            label2.Text = "ToDo - Write help text";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 0;
            label1.Text = "Help";
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            ClientSize = new Size(1029, 630);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(800, 500);
            Name = "MainUI";
            Text = "Blood Pressure Measurement Device";
            tableLayoutPanel1.ResumeLayout(false);
            panelSideMenu.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelChildForm.ResumeLayout(false);
            panelChildForm.PerformLayout();
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
        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}