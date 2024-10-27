namespace Minesweeper.Gui.Views
{
    partial class GamerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamerForm));
            btOK = new Button();
            label1 = new Label();
            tbGamerName = new TextBox();
            SuspendLayout();
            // 
            // btOK
            // 
            btOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btOK.Location = new Point(107, 130);
            btOK.Name = "btOK";
            btOK.Size = new Size(75, 23);
            btOK.TabIndex = 0;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 21);
            label1.Name = "label1";
            label1.Size = new Size(129, 30);
            label1.TabIndex = 2;
            label1.Text = "Вы стали чемпионом.\r\nВведите своё имя.";
            // 
            // tbGamerName
            // 
            tbGamerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbGamerName.Location = new Point(30, 64);
            tbGamerName.Name = "tbGamerName";
            tbGamerName.Size = new Size(225, 23);
            tbGamerName.TabIndex = 3;
            // 
            // GamerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 165);
            ControlBox = false;
            Controls.Add(tbGamerName);
            Controls.Add(label1);
            Controls.Add(btOK);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GamerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Сапёр";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btOK;
        private Label label1;
        private TextBox tbGamerName;
    }
}