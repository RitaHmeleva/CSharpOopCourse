namespace Minesweeper.Gui.Views
{
    partial class RecordsTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordsTableForm));
            gvRecords = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gvRecords).BeginInit();
            SuspendLayout();
            // 
            // gvRecords
            // 
            gvRecords.AllowUserToAddRows = false;
            gvRecords.AllowUserToDeleteRows = false;
            gvRecords.AllowUserToOrderColumns = true;
            gvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvRecords.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            gvRecords.Dock = DockStyle.Fill;
            gvRecords.Location = new Point(10, 10);
            gvRecords.Name = "gvRecords";
            gvRecords.ReadOnly = true;
            gvRecords.RowHeadersVisible = false;
            gvRecords.RowTemplate.Height = 25;
            gvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvRecords.Size = new Size(526, 329);
            gvRecords.TabIndex = 1;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.DataPropertyName = "Level";
            Column1.HeaderText = "Уровень";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.DataPropertyName = "Time";
            Column2.HeaderText = "Время";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.DataPropertyName = "GamerName";
            Column3.HeaderText = "Игрок";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // RecordsTableForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 349);
            Controls.Add(gvRecords);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RecordsTableForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Сапёр";
            Load += RecordsTableForm_Load;
            ((System.ComponentModel.ISupportInitialize)gvRecords).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView gvRecords;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}