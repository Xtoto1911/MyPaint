using MyPaint.FiguresClasses;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        private Point firstPoint;
        private Graphics graphics;
        private Pen pen;

        private MyRectangle rectangle;
        private Ellipse ellipse;
        private Line line;
        private StraightLine straightLine;
        private Figure figure;

        private bool isDrow = false;

        private delegate void DelegateCreate();
        private delegate void DelegateDrow();
        private DelegateCreate create;
        private DelegateDrow drow;

        public Form1()
        {
            InitializeComponent();

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenFile_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            LabelPx.Text = $"{trackBar1.Value} px";
        }
    }
}