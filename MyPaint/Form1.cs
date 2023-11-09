using MyPaint.FiguresClasses;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

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

        private bool isDraw = false;
        private bool isSave = true;
        private bool isLine = true;

        private delegate void DelegateCreate();
        private delegate void DelegateDrow(Point firstPoint, Point currPoint);
        private DelegateCreate createDelig;
        private DelegateDrow drawDelig;

        public Form1()
        {
            InitializeComponent();
            InitSettings();

        }

        private void InitSettings()
        {
            graphics = DrowPanel.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            firstPoint = new();
            figure = new();
            pen = new(Color.Black, 0);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            drawDelig = DrawLine;
            createDelig = CreateLine;

            LabelPx.Text = $"{trackBar1.Value} px";
            pen.Width = (float)trackBar1.Value;
        }

        private void DrawLine(Point firstPoint, Point currPoint)
        {
            line.points.Add(firstPoint);
            line.points.Add(currPoint);
            line.Draw(graphics);
            if (!isDraw)
                figure.figures.Add(line);
        }

        private void DrawRectangle(Point old, Point current) =>
            DrowFigure(rectangle, old, current);

        private void DrawEllipse(Point old, Point current) =>
            DrowFigure(ellipse, old, current);

        private void DrawStraighLine(Point old, Point current) =>
            DrowFigure(straightLine, old, current);

        void DrowFigure(Figure f, Point old, Point current, bool isMousDrow = false)
        {
            f.points.Add(old);
            if (!isDraw || isMousDrow)
            {
                f.points.Add(current);
                f.Draw(graphics);
                figure.figures.Add(f);
            }
        }

        private void CreateLine()
        {
            line = new(pen);
            isLine = true;
        }

        public void CreateRectangle()
        {
            rectangle = new(pen);
            isLine = false;
        }

        public void CreateEllipse()
        {
            ellipse = new(pen);
            isLine = false;
        }

        public void CreateStraighLine()
        {
            straightLine = new(pen);
            isLine = false;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "MyPaint  (*png) | *.png";
                dialog.RestoreDirectory = true;
                dialog.DefaultExt = "png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = dialog.OpenFile();
                    if (stream != null)
                    {
                        BinaryFormatter myBin = new BinaryFormatter();
                        myBin.Serialize(stream, figure.figures);
                        stream.Close();
                    }
                }
            }
            isSave = true;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "����� MyPaint  (*png) | *.png";
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (figure.figures.Count != 0)
                        figure.figures.Clear();
                    Refresh();
                    Stream mystr = openFile.OpenFile();
                    if (mystr != null)
                    {
                        try
                        {
                            BinaryFormatter myBin = new BinaryFormatter();
                            figure.figures = (List<Figure>)myBin.Deserialize(mystr);
                            mystr.Close();
                            figure.Draw(graphics);
                        }
                        catch
                        {
                            MessageBox.Show("������ ��� �������� �����");
                        }
                    }
                }
            }
            drawDelig = null;
            isSave = true;
        }

        private void CleanBnt_Click(object sender, EventArgs e)
        {
            figure.figures.Clear();
            Refresh();
            isSave = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            LabelPx.Text = $"{trackBar1.Value} px";
            pen.Width = (float)trackBar1.Value;
        }

        private void DrowPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDraw = true;
                createDelig?.Invoke();
                firstPoint = e.Location;
                if (isLine)
                {
                    var local = new Point(firstPoint.X + (int)pen.Width / 2, firstPoint.Y + (int)pen.Width);
                    DrowFigure(new Ellipse(pen), e.Location, local, true);
                }
                isSave = drawDelig == null;
            }

        }

        private void DrowPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (drawDelig == DrawLine)
                {
                    drawDelig(firstPoint, e.Location);
                    firstPoint = e.Location;
                }
                else
                {
                    drawDelig?.Invoke(firstPoint, e.Location);
                }

            }
        }

        private void DrowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDraw = false;
            drawDelig?.Invoke(firstPoint, e.Location);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (figure.figures.Count != 0)
            {
                if (figure.figures[^1] is Line)
                    figure.figures.RemoveRange(figure.figures.Count - 2, 2);
                else
                    figure.figures.RemoveAt(figure.figures.Count - 1);
            }
            Refresh();
        }

        private void DrowPanel_Paint(object sender, PaintEventArgs e)
        {
            figure.Draw(graphics);
        }

        private void RecBtn_Click(object sender, EventArgs e)
        {
            createDelig = CreateRectangle;
            drawDelig = DrawRectangle;
        }

        private void EllipseBtn_Click(object sender, EventArgs e)
        {
            createDelig = CreateEllipse;
            drawDelig = DrawEllipse;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            createDelig = CreateLine;
            drawDelig = DrawLine;
        }

        private void StraightLineBtn_Click(object sender, EventArgs e)
        {
            createDelig = CreateStraighLine;
            drawDelig = DrawStraighLine;
        }

    }
}