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
            SaveBtnImage = new ToolStripMenuItem();
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
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { File });
            menuStrip1.Name = "menuStrip1";
            // 
            // File
            // 
            resources.ApplyResources(File, "File");
            File.DropDownItems.AddRange(new ToolStripItem[] { OpenFile, SaveBtnImage, CleanBnt, Exit });
            File.Name = "File";
            // 
            // OpenFile
            // 
            resources.ApplyResources(OpenFile, "OpenFile");
            OpenFile.Name = "OpenFile";
            OpenFile.Click += OpenFile_Click;
            // 
            // SaveBtnImage
            // 
            resources.ApplyResources(SaveBtnImage, "SaveBtnImage");
            SaveBtnImage.Name = "SaveBtnImage";
            SaveBtnImage.Click += SaveImage_Click;
            // 
            // CleanBnt
            // 
            resources.ApplyResources(CleanBnt, "CleanBnt");
            CleanBnt.Name = "CleanBnt";
            CleanBnt.Click += CleanBnt_Click;
            // 
            // Exit
            // 
            resources.ApplyResources(Exit, "Exit");
            Exit.Name = "Exit";
            Exit.Click += Exit_Click;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(DrowPanel, 0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
            tableLayoutPanel2.Controls.Add(StraightLineBtn, 6, 0);
            tableLayoutPanel2.Controls.Add(Line, 5, 0);
            tableLayoutPanel2.Controls.Add(EllipseBtn, 4, 0);
            tableLayoutPanel2.Controls.Add(RecBtn, 3, 0);
            tableLayoutPanel2.Controls.Add(button1, 0, 0);
            tableLayoutPanel2.Controls.Add(BackBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(ColorBtn, 8, 0);
            tableLayoutPanel2.Controls.Add(trackBar1, 9, 0);
            tableLayoutPanel2.Controls.Add(LabelPx, 10, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // StraightLineBtn
            // 
            resources.ApplyResources(StraightLineBtn, "StraightLineBtn");
            StraightLineBtn.BackColor = Color.Transparent;
            StraightLineBtn.BackgroundImage = Properties.Resources.png_transparent_line_rectangle_horizontal_line_angle_black_internet_thumbnail;
            StraightLineBtn.Name = "StraightLineBtn";
            StraightLineBtn.UseVisualStyleBackColor = false;
            StraightLineBtn.Click += StraightLineBtn_Click;
            // 
            // Line
            // 
            resources.ApplyResources(Line, "Line");
            Line.BackColor = Color.Transparent;
            Line.BackgroundImage = Properties.Resources._255eec0f_ecea_477a_904b_afc1c0c06109;
            Line.Name = "Line";
            Line.UseVisualStyleBackColor = false;
            Line.Click += Line_Click;
            // 
            // EllipseBtn
            // 
            resources.ApplyResources(EllipseBtn, "EllipseBtn");
            EllipseBtn.BackColor = Color.Transparent;
            EllipseBtn.BackgroundImage = Properties.Resources.png_transparent_circle_scalable_graphics_circle_cdr_angle_white_thumbnail;
            EllipseBtn.Name = "EllipseBtn";
            EllipseBtn.UseVisualStyleBackColor = false;
            EllipseBtn.Click += EllipseBtn_Click;
            // 
            // RecBtn
            // 
            resources.ApplyResources(RecBtn, "RecBtn");
            RecBtn.BackColor = Color.Transparent;
            RecBtn.BackgroundImage = Properties.Resources.png_transparent_black_rectangle_border_miscellaneous_angle_white_thumbnail;
            RecBtn.Name = "RecBtn";
            RecBtn.UseVisualStyleBackColor = false;
            RecBtn.Click += RecBtn_Click;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Properties.Resources.png_clipart_computer_icons_user_interface_button_save_button_rectangle_logo_thumbnail;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += SaveBtn_Click;
            // 
            // BackBtn
            // 
            resources.ApplyResources(BackBtn, "BackBtn");
            BackBtn.Name = "BackBtn";
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;
            // 
            // ColorBtn
            // 
            resources.ApplyResources(ColorBtn, "ColorBtn");
            ColorBtn.BackColor = Color.Black;
            ColorBtn.Name = "ColorBtn";
            ColorBtn.UseVisualStyleBackColor = false;
            ColorBtn.Click += ColorBtn_Click;
            // 
            // trackBar1
            // 
            resources.ApplyResources(trackBar1, "trackBar1");
            trackBar1.Maximum = 25;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // LabelPx
            // 
            resources.ApplyResources(LabelPx, "LabelPx");
            LabelPx.Name = "LabelPx";
            // 
            // DrowPanel
            // 
            resources.ApplyResources(DrowPanel, "DrowPanel");
            DrowPanel.BackColor = Color.White;
            DrowPanel.Name = "DrowPanel";
            DrowPanel.Paint += DrowPanel_Paint;
            DrowPanel.MouseDown += DrowPanel_MouseDown;
            DrowPanel.MouseMove += DrowPanel_MouseMove;
            DrowPanel.MouseUp += DrowPanel_MouseUp;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
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
        private ToolStripMenuItem SaveBtnImage;
    }
}