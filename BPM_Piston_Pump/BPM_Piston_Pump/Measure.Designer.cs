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
            button1 = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            tblLayoutMeasure.SuspendLayout();
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
            tblLayoutMeasure.Controls.Add(button1, 0, 1);
            tblLayoutMeasure.Controls.Add(label2, 0, 0);
            tblLayoutMeasure.Dock = DockStyle.Fill;
            tblLayoutMeasure.Location = new Point(0, 65);
            tblLayoutMeasure.Name = "tblLayoutMeasure";
            tblLayoutMeasure.RowCount = 2;
            tblLayoutMeasure.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayoutMeasure.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayoutMeasure.Size = new Size(748, 518);
            tblLayoutMeasure.TabIndex = 4;
            tblLayoutMeasure.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(3, 262);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 1;
            label2.Text = "Normal Mode";
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
            tblLayoutMeasure.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private RadioButton rdoNormalMode;
        private RadioButton rdoDynamicMode;
        private Panel panel1;
        private TableLayoutPanel tblLayoutMeasure;
        private Button button1;
        private Label label2;
    }
}