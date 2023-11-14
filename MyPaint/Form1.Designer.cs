namespace MyPaint
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            File = new ToolStripMenuItem();
            OpenFile = new ToolStripMenuItem();
            CleanBnt = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            StraightLineBtn = new Button();
            Line = new Button();
            EllipseBtn = new Button();
            RecBtn = new Button();
            button1 = new Button();
            BackBtn = new Button();
            ColorBtn = new Button();
            trackBar1 = new TrackBar();
            LabelPx = new Label();
            DrowPanel = new Panel();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { File });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(848, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            File.DropDownItems.AddRange(new ToolStripItem[] { OpenFile, CleanBnt, Exit });
            File.Name = "File";
            File.Size = new Size(48, 20);
            File.Text = "Файл";
            // 
            // OpenFile
            // 
            OpenFile.Name = "OpenFile";
            OpenFile.Size = new Size(126, 22);
            OpenFile.Text = "Открыть";
            OpenFile.Click += OpenFile_Click;
            // 
            // CleanBnt
            // 
            CleanBnt.Name = "CleanBnt";
            CleanBnt.Size = new Size(126, 22);
            CleanBnt.Text = "Очистить";
            CleanBnt.Click += CleanBnt_Click;
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.Size = new Size(126, 22);
            Exit.Text = "Выход";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.BackgroundImageLayout = ImageLayout.None;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(DrowPanel, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(848, 468);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 11;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 17F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 17F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.Controls.Add(StraightLineBtn, 6, 0);
            tableLayoutPanel2.Controls.Add(Line, 5, 0);
            tableLayoutPanel2.Controls.Add(EllipseBtn, 4, 0);
            tableLayoutPanel2.Controls.Add(RecBtn, 3, 0);
            tableLayoutPanel2.Controls.Add(button1, 0, 0);
            tableLayoutPanel2.Controls.Add(BackBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(ColorBtn, 8, 0);
            tableLayoutPanel2.Controls.Add(trackBar1, 9, 0);
            tableLayoutPanel2.Controls.Add(LabelPx, 10, 0);
            tableLayoutPanel2.Dock = DockStyle.Left;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(565, 44);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // StraightLineBtn
            // 
            StraightLineBtn.BackColor = Color.Transparent;
            StraightLineBtn.BackgroundImage = Properties.Resources.png_transparent_line_rectangle_horizontal_line_angle_black_internet_thumbnail;
            StraightLineBtn.BackgroundImageLayout = ImageLayout.Zoom;
            StraightLineBtn.Dock = DockStyle.Fill;
            StraightLineBtn.Location = new Point(260, 3);
            StraightLineBtn.Name = "StraightLineBtn";
            StraightLineBtn.Size = new Size(42, 38);
            StraightLineBtn.TabIndex = 6;
            StraightLineBtn.UseVisualStyleBackColor = false;
            StraightLineBtn.Click += StraightLineBtn_Click;
            // 
            // Line
            // 
            Line.BackColor = Color.Transparent;
            Line.BackgroundImage = Properties.Resources._255eec0f_ecea_477a_904b_afc1c0c06109;
            Line.BackgroundImageLayout = ImageLayout.Zoom;
            Line.Dock = DockStyle.Fill;
            Line.Location = new Point(212, 3);
            Line.Name = "Line";
            Line.Size = new Size(42, 38);
            Line.TabIndex = 5;
            Line.UseVisualStyleBackColor = false;
            Line.Click += Line_Click;
            // 
            // EllipseBtn
            // 
            EllipseBtn.BackColor = Color.Transparent;
            EllipseBtn.BackgroundImage = Properties.Resources.png_transparent_circle_scalable_graphics_circle_cdr_angle_white_thumbnail;
            EllipseBtn.BackgroundImageLayout = ImageLayout.Zoom;
            EllipseBtn.Dock = DockStyle.Fill;
            EllipseBtn.Location = new Point(164, 3);
            EllipseBtn.Name = "EllipseBtn";
            EllipseBtn.Size = new Size(42, 38);
            EllipseBtn.TabIndex = 4;
            EllipseBtn.UseVisualStyleBackColor = false;
            EllipseBtn.Click += EllipseBtn_Click;
            // 
            // RecBtn
            // 
            RecBtn.BackColor = Color.Transparent;
            RecBtn.BackgroundImage = Properties.Resources.png_transparent_black_rectangle_border_miscellaneous_angle_white_thumbnail;
            RecBtn.BackgroundImageLayout = ImageLayout.Zoom;
            RecBtn.Dock = DockStyle.Fill;
            RecBtn.Location = new Point(116, 3);
            RecBtn.Name = "RecBtn";
            RecBtn.Size = new Size(42, 38);
            RecBtn.TabIndex = 2;
            RecBtn.UseVisualStyleBackColor = false;
            RecBtn.Click += RecBtn_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Properties.Resources.png_clipart_computer_icons_user_interface_button_save_button_rectangle_logo_thumbnail;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(51, 3);
            button1.Name = "button1";
            button1.Size = new Size(42, 38);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            button1.Click += SaveBtn_Click;
            // 
            // BackBtn
            // 
            BackBtn.BackgroundImage = (Image)resources.GetObject("BackBtn.BackgroundImage");
            BackBtn.BackgroundImageLayout = ImageLayout.Zoom;
            BackBtn.Dock = DockStyle.Fill;
            BackBtn.Location = new Point(3, 3);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(42, 38);
            BackBtn.TabIndex = 0;
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;
            // 
            // ColorBtn
            // 
            ColorBtn.BackColor = Color.Black;
            ColorBtn.BackgroundImageLayout = ImageLayout.None;
            ColorBtn.Dock = DockStyle.Fill;
            ColorBtn.Location = new Point(325, 3);
            ColorBtn.Name = "ColorBtn";
            ColorBtn.Size = new Size(42, 38);
            ColorBtn.TabIndex = 7;
            ColorBtn.UseVisualStyleBackColor = false;
            ColorBtn.Click += ColorBtn_Click;
            // 
            // trackBar1
            // 
            trackBar1.Dock = DockStyle.Fill;
            trackBar1.Location = new Point(373, 3);
            trackBar1.Maximum = 25;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(144, 38);
            trackBar1.TabIndex = 8;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // LabelPx
            // 
            LabelPx.AutoSize = true;
            LabelPx.Dock = DockStyle.Fill;
            LabelPx.Location = new Point(523, 0);
            LabelPx.Name = "LabelPx";
            LabelPx.Size = new Size(39, 44);
            LabelPx.TabIndex = 9;
            LabelPx.Text = "0 px";
            LabelPx.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DrowPanel
            // 
            DrowPanel.AutoSize = true;
            DrowPanel.BackColor = Color.White;
            DrowPanel.Dock = DockStyle.Fill;
            DrowPanel.Location = new Point(3, 53);
            DrowPanel.Name = "DrowPanel";
            DrowPanel.Size = new Size(842, 412);
            DrowPanel.TabIndex = 1;
            DrowPanel.Paint += DrowPanel_Paint;
            DrowPanel.MouseDown += DrowPanel_MouseDown;
            DrowPanel.MouseMove += DrowPanel_MouseMove;
            DrowPanel.MouseUp += DrowPanel_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 492);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Resize += Form1_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem File;
        private ToolStripMenuItem очиститьToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel DrowPanel;
        private Button BackBtn;
        private Button button1;
        private Button StraightLineBtn;
        private Button Line;
        private Button EllipseBtn;
        private Button RecBtn;
        private Button ColorBtn;
        private TrackBar trackBar1;
        private Label LabelPx;
        private ToolStripMenuItem OpenFile;
        private ToolStripMenuItem Exit;
        private ToolStripMenuItem CleanBnt;
    }
}