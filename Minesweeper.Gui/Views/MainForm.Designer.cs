namespace Minesweeper.Gui.Views;

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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        menuStrip1 = new MenuStrip();
        miGame = new ToolStripMenuItem();
        miNewGame = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        toolStripMenuItem2 = new ToolStripSeparator();
        miRecords = new ToolStripMenuItem();
        toolStripMenuItem3 = new ToolStripSeparator();
        miExit = new ToolStripMenuItem();
        miAbout = new ToolStripMenuItem();
        buttonImageList = new ImageList(components);
        imageListMedium = new ImageList(components);
        imageListSmall = new ImageList(components);
        pnGame = new TableLayoutPanel();
        faceButton = new Button();
        lbTime = new Label();
        lbMinesCount = new Label();
        pbTimer = new PictureBox();
        pbMine = new PictureBox();
        pnField = new Panel();
        pbField = new PictureBox();
        tmGame = new System.Windows.Forms.Timer(components);
        menuStrip1.SuspendLayout();
        pnGame.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbTimer).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbMine).BeginInit();
        pnField.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbField).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { miGame, miAbout });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(8, 3, 0, 3);
        menuStrip1.Size = new Size(1126, 25);
        menuStrip1.TabIndex = 1;
        menuStrip1.Text = "menuStrip1";
        // 
        // miGame
        // 
        miGame.DropDownItems.AddRange(new ToolStripItem[] { miNewGame, toolStripMenuItem1, toolStripMenuItem2, miRecords, toolStripMenuItem3, miExit });
        miGame.Name = "miGame";
        miGame.Size = new Size(46, 19);
        miGame.Text = "Игра";
        // 
        // miNewGame
        // 
        miNewGame.Name = "miNewGame";
        miNewGame.ShortcutKeys = Keys.F2;
        miNewGame.Size = new Size(184, 22);
        miNewGame.Text = "Новая игра";
        miNewGame.Click += miNewGame_Click;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(181, 6);
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new Size(181, 6);
        // 
        // miRecords
        // 
        miRecords.Name = "miRecords";
        miRecords.Size = new Size(184, 22);
        miRecords.Text = "Таблица рекордов...";
        miRecords.Click += miRecords_Click;
        // 
        // toolStripMenuItem3
        // 
        toolStripMenuItem3.Name = "toolStripMenuItem3";
        toolStripMenuItem3.Size = new Size(181, 6);
        // 
        // miExit
        // 
        miExit.Name = "miExit";
        miExit.Size = new Size(184, 22);
        miExit.Text = "Выход";
        miExit.Click += miExit_Click;
        // 
        // miAbout
        // 
        miAbout.Name = "miAbout";
        miAbout.Size = new Size(94, 19);
        miAbout.Text = "О программе";
        miAbout.Click += miAbout_Click;
        // 
        // buttonImageList
        // 
        buttonImageList.ColorDepth = ColorDepth.Depth32Bit;
        buttonImageList.ImageStream = (ImageListStreamer)resources.GetObject("buttonImageList.ImageStream");
        buttonImageList.TransparentColor = Color.Transparent;
        buttonImageList.Images.SetKeyName(0, "slightly_smiling_face_48.png");
        buttonImageList.Images.SetKeyName(1, "neutral_face_48.png");
        buttonImageList.Images.SetKeyName(2, "open_mouth_48.png");
        buttonImageList.Images.SetKeyName(3, "slightly_frowning_face_48.png");
        buttonImageList.Images.SetKeyName(4, "sunglasses_48.png");
        buttonImageList.Images.SetKeyName(5, "stopwatch.png");
        buttonImageList.Images.SetKeyName(6, "Mine48.png");
        // 
        // imageListMedium
        // 
        imageListMedium.ColorDepth = ColorDepth.Depth24Bit;
        imageListMedium.ImageStream = (ImageListStreamer)resources.GetObject("imageListMedium.ImageStream");
        imageListMedium.TransparentColor = Color.Transparent;
        imageListMedium.Images.SetKeyName(0, "0.png");
        imageListMedium.Images.SetKeyName(1, "1.png");
        imageListMedium.Images.SetKeyName(2, "2.png");
        imageListMedium.Images.SetKeyName(3, "3.png");
        imageListMedium.Images.SetKeyName(4, "4.png");
        imageListMedium.Images.SetKeyName(5, "5.png");
        imageListMedium.Images.SetKeyName(6, "6.png");
        imageListMedium.Images.SetKeyName(7, "7.png");
        imageListMedium.Images.SetKeyName(8, "8.png");
        imageListMedium.Images.SetKeyName(9, "boom.png");
        imageListMedium.Images.SetKeyName(10, "closed.png");
        imageListMedium.Images.SetKeyName(11, "closed_focus.png");
        imageListMedium.Images.SetKeyName(12, "flag.png");
        imageListMedium.Images.SetKeyName(13, "mine.png");
        imageListMedium.Images.SetKeyName(14, "mistake.png");
        // 
        // imageListSmall
        // 
        imageListSmall.ColorDepth = ColorDepth.Depth8Bit;
        imageListSmall.ImageStream = (ImageListStreamer)resources.GetObject("imageListSmall.ImageStream");
        imageListSmall.TransparentColor = Color.Transparent;
        imageListSmall.Images.SetKeyName(0, "0.png");
        imageListSmall.Images.SetKeyName(1, "1.png");
        imageListSmall.Images.SetKeyName(2, "2.png");
        imageListSmall.Images.SetKeyName(3, "3.png");
        imageListSmall.Images.SetKeyName(4, "4.png");
        imageListSmall.Images.SetKeyName(5, "5.png");
        imageListSmall.Images.SetKeyName(6, "6.png");
        imageListSmall.Images.SetKeyName(7, "7.png");
        imageListSmall.Images.SetKeyName(8, "8.png");
        imageListSmall.Images.SetKeyName(9, "boom.png");
        imageListSmall.Images.SetKeyName(10, "closed.png");
        imageListSmall.Images.SetKeyName(11, "closed_focus.png");
        imageListSmall.Images.SetKeyName(12, "flag.png");
        imageListSmall.Images.SetKeyName(13, "mine.png");
        imageListSmall.Images.SetKeyName(14, "mistake.png");
        // 
        // pnGame
        // 
        pnGame.AutoSize = true;
        pnGame.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        pnGame.BackColor = Color.SteelBlue;
        pnGame.ColumnCount = 7;
        pnGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        pnGame.ColumnStyles.Add(new ColumnStyle());
        pnGame.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        pnGame.ColumnStyles.Add(new ColumnStyle());
        pnGame.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        pnGame.ColumnStyles.Add(new ColumnStyle());
        pnGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        pnGame.Controls.Add(faceButton, 3, 0);
        pnGame.Controls.Add(lbTime, 2, 0);
        pnGame.Controls.Add(lbMinesCount, 4, 0);
        pnGame.Controls.Add(pbTimer, 1, 0);
        pnGame.Controls.Add(pbMine, 5, 0);
        pnGame.Controls.Add(pnField, 0, 1);
        pnGame.Location = new Point(0, 25);
        pnGame.Margin = new Padding(0);
        pnGame.Name = "pnGame";
        pnGame.Padding = new Padding(10);
        pnGame.RowCount = 2;
        pnGame.RowStyles.Add(new RowStyle());
        pnGame.RowStyles.Add(new RowStyle());
        pnGame.Size = new Size(966, 383);
        pnGame.TabIndex = 2;
        // 
        // faceButton
        // 
        faceButton.BackColor = Color.SteelBlue;
        faceButton.BackgroundImageLayout = ImageLayout.Center;
        faceButton.ImageIndex = 3;
        faceButton.ImageList = buttonImageList;
        faceButton.Location = new Point(457, 10);
        faceButton.Margin = new Padding(0);
        faceButton.Name = "faceButton";
        faceButton.Size = new Size(52, 52);
        faceButton.TabIndex = 0;
        faceButton.UseVisualStyleBackColor = false;
        faceButton.Click += faceButton_Click;
        // 
        // lbTime
        // 
        lbTime.AutoSize = true;
        lbTime.Dock = DockStyle.Fill;
        lbTime.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
        lbTime.Location = new Point(381, 10);
        lbTime.Margin = new Padding(4, 0, 4, 0);
        lbTime.Name = "lbTime";
        lbTime.Size = new Size(72, 52);
        lbTime.TabIndex = 1;
        lbTime.Text = "100";
        lbTime.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lbMinesCount
        // 
        lbMinesCount.AutoSize = true;
        lbMinesCount.Dock = DockStyle.Fill;
        lbMinesCount.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
        lbMinesCount.Location = new Point(513, 10);
        lbMinesCount.Margin = new Padding(4, 0, 4, 0);
        lbMinesCount.Name = "lbMinesCount";
        lbMinesCount.Size = new Size(72, 52);
        lbMinesCount.TabIndex = 2;
        lbMinesCount.Text = "100";
        lbMinesCount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // pbTimer
        // 
        pbTimer.Image = Properties.Resources.stopwatch;
        pbTimer.Location = new Point(325, 10);
        pbTimer.Margin = new Padding(0);
        pbTimer.Name = "pbTimer";
        pbTimer.Size = new Size(52, 52);
        pbTimer.SizeMode = PictureBoxSizeMode.Zoom;
        pbTimer.TabIndex = 3;
        pbTimer.TabStop = false;
        // 
        // pbMine
        // 
        pbMine.Image = Properties.Resources.Mine48;
        pbMine.Location = new Point(589, 10);
        pbMine.Margin = new Padding(0);
        pbMine.Name = "pbMine";
        pbMine.Size = new Size(52, 52);
        pbMine.SizeMode = PictureBoxSizeMode.Zoom;
        pbMine.TabIndex = 4;
        pbMine.TabStop = false;
        // 
        // pnField
        // 
        pnField.AutoScroll = true;
        pnGame.SetColumnSpan(pnField, 7);
        pnField.Controls.Add(pbField);
        pnField.Location = new Point(10, 72);
        pnField.Margin = new Padding(0, 10, 0, 0);
        pnField.Name = "pnField";
        pnField.Size = new Size(945, 301);
        pnField.TabIndex = 5;
        // 
        // pbField
        // 
        pbField.BorderStyle = BorderStyle.Fixed3D;
        pbField.Location = new Point(-2, -2);
        pbField.Margin = new Padding(0);
        pbField.Name = "pbField";
        pbField.Size = new Size(192, 185);
        pbField.TabIndex = 0;
        pbField.TabStop = false;
        pbField.MouseClick += pbField_MouseClick;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(9F, 21F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = Color.SteelBlue;
        ClientSize = new Size(1126, 472);
        Controls.Add(pnGame);
        Controls.Add(menuStrip1);
        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = menuStrip1;
        Margin = new Padding(4);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Сапёр";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        pnGame.ResumeLayout(false);
        pnGame.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pbTimer).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbMine).EndInit();
        pnField.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pbField).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem выйтиToolStripMenuItem;
    private ToolStripMenuItem miGame;
    private ToolStripMenuItem miNewGame;
    private ToolStripMenuItem miAbout;
    private ImageList imageListMedium;
    private ToolStripSeparator toolStripMenuItem1;
    private ImageList imageListSmall;
    private ImageList buttonImageList;
    private TableLayoutPanel pnGame;
    private Button faceButton;
    private Label lbTime;
    private Label lbMinesCount;
    private PictureBox pbTimer;
    private PictureBox pbMine;
    private Panel pnField;
    private ToolStripSeparator toolStripMenuItem2;
    private ToolStripMenuItem miRecords;
    private ToolStripSeparator toolStripMenuItem3;
    private ToolStripMenuItem miExit;
    private PictureBox pbField;
    private System.Windows.Forms.Timer tmGame;
}