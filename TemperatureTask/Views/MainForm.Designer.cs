namespace TemperatureTask
{
    partial class MainForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tbTargetTemperature = new TextBox();
            label4 = new Label();
            btRun = new Button();
            cbTargetScale = new ComboBox();
            label2 = new Label();
            cbSourceScale = new ComboBox();
            label3 = new Label();
            tbSourceTemperature = new TextBox();
            label1 = new Label();
            btClose = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tbTargetTemperature, 0, 8);
            tableLayoutPanel1.Controls.Add(label4, 0, 7);
            tableLayoutPanel1.Controls.Add(btRun, 0, 6);
            tableLayoutPanel1.Controls.Add(cbTargetScale, 0, 5);
            tableLayoutPanel1.Controls.Add(label2, 0, 4);
            tableLayoutPanel1.Controls.Add(cbSourceScale, 0, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(tbSourceTemperature, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(btClose, 0, 10);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 11;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(284, 461);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // tbTargetTemperature
            // 
            tbTargetTemperature.Location = new Point(3, 231);
            tbTargetTemperature.Name = "tbTargetTemperature";
            tbTargetTemperature.ReadOnly = true;
            tbTargetTemperature.Size = new Size(149, 23);
            tbTargetTemperature.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 213);
            label4.Margin = new Padding(3, 10, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 17;
            label4.Text = "Результат";
            // 
            // btRun
            // 
            btRun.AutoSize = true;
            btRun.Location = new Point(3, 162);
            btRun.Margin = new Padding(3, 10, 3, 3);
            btRun.Name = "btRun";
            btRun.Size = new Size(114, 38);
            btRun.TabIndex = 16;
            btRun.Text = "Рассчитать";
            btRun.UseVisualStyleBackColor = true;
            btRun.Click += btRun_Click;
            // 
            // cbTargetScale
            // 
            cbTargetScale.Dock = DockStyle.Fill;
            cbTargetScale.FormattingEnabled = true;
            cbTargetScale.Location = new Point(3, 126);
            cbTargetScale.Name = "cbTargetScale";
            cbTargetScale.Size = new Size(278, 23);
            cbTargetScale.TabIndex = 15;
            cbTargetScale.SelectedIndexChanged += cbTargetScale_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 108);
            label2.Margin = new Padding(3, 10, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 14;
            label2.Text = "В";
            // 
            // cbSourceScale
            // 
            cbSourceScale.Dock = DockStyle.Fill;
            cbSourceScale.FormattingEnabled = true;
            cbSourceScale.Location = new Point(3, 72);
            cbSourceScale.Name = "cbSourceScale";
            cbSourceScale.Size = new Size(278, 23);
            cbSourceScale.TabIndex = 13;
            cbSourceScale.SelectedIndexChanged += cbSourceScale_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 54);
            label3.Margin = new Padding(3, 10, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 12;
            label3.Text = "Из";
            // 
            // tbSourceTemperature
            // 
            tbSourceTemperature.Location = new Point(3, 18);
            tbSourceTemperature.Name = "tbSourceTemperature";
            tbSourceTemperature.Size = new Size(149, 23);
            tbSourceTemperature.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 10;
            label1.Text = "Конвертировать";
            // 
            // btClose
            // 
            btClose.Location = new Point(3, 420);
            btClose.Name = "btClose";
            btClose.Size = new Size(150, 38);
            btClose.TabIndex = 19;
            btClose.Text = "Закрыть";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 461);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(100, 350);
            Name = "MainForm";
            Text = "Конвертер температуры";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbTargetTemperature;
        private Label label4;
        private Button btRun;
        private ComboBox cbTargetScale;
        private Label label2;
        private ComboBox cbSourceScale;
        private Label label3;
        private TextBox tbSourceTemperature;
        private Label label1;
        private Button btClose;
    }
}