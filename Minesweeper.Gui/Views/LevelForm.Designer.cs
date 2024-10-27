namespace Minesweeper.Gui.Views
{
    partial class LevelForm
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
            label2 = new Label();
            label3 = new Label();
            nmRowsCount = new NumericUpDown();
            nmColumnsCount = new NumericUpDown();
            nmMinesCount = new NumericUpDown();
            btOK = new Button();
            btCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nmRowsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmColumnsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmMinesCount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 44);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Высота (7-500)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 82);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 1;
            label2.Text = "Ширина (7-500)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 122);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 2;
            label3.Text = "Число мин";
            // 
            // nmRowsCount
            // 
            nmRowsCount.Location = new Point(128, 42);
            nmRowsCount.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nmRowsCount.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            nmRowsCount.Name = "nmRowsCount";
            nmRowsCount.Size = new Size(120, 23);
            nmRowsCount.TabIndex = 3;
            nmRowsCount.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // nmColumnsCount
            // 
            nmColumnsCount.Location = new Point(128, 80);
            nmColumnsCount.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nmColumnsCount.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            nmColumnsCount.Name = "nmColumnsCount";
            nmColumnsCount.Size = new Size(120, 23);
            nmColumnsCount.TabIndex = 4;
            nmColumnsCount.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // nmMinesCount
            // 
            nmMinesCount.Location = new Point(128, 120);
            nmMinesCount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nmMinesCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmMinesCount.Name = "nmMinesCount";
            nmMinesCount.Size = new Size(120, 23);
            nmMinesCount.TabIndex = 5;
            nmMinesCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btOK
            // 
            btOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btOK.Location = new Point(30, 242);
            btOK.Name = "btOK";
            btOK.Size = new Size(75, 23);
            btOK.TabIndex = 6;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // btCancel
            // 
            btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btCancel.DialogResult = DialogResult.Cancel;
            btCancel.Location = new Point(165, 242);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(75, 23);
            btCancel.TabIndex = 7;
            btCancel.Text = "Отмена";
            btCancel.UseVisualStyleBackColor = true;
            // 
            // LevelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 292);
            Controls.Add(btCancel);
            Controls.Add(btOK);
            Controls.Add(nmMinesCount);
            Controls.Add(nmColumnsCount);
            Controls.Add(nmRowsCount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LevelForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Специальное поле";
            Load += LevelForm_Load;
            ((System.ComponentModel.ISupportInitialize)nmRowsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmColumnsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmMinesCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown nmRowsCount;
        private NumericUpDown nmColumnsCount;
        private NumericUpDown nmMinesCount;
        private Button btOK;
        private Button btCancel;
    }
}