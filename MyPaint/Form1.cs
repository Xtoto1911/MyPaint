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

        #region Отрисовка
        private void DrawLine(Point firstPoint, Point currPoint)
        {
            line.points.Add(firstPoint);
            line.points.Add(currPoint);
            line.Draw(graphics);
            if (!isDraw)
                figure.figures.Add(line);
        }

        private void DrawRectangle(Point old, Point current) => DrowFigure(rectangle, old, current);

        private void DrawEllipse(Point old, Point current) => DrowFigure(ellipse, old, current);

        private void DrawStraighLine(Point old, Point current) => DrowFigure(straightLine, old, current);

        void DrowFigure(Figure f, Point old, Point current, bool isPoint = false)
        {
            f.points.Add(old);
            if (!isDraw || isPoint)
            {
                f.points.Add(current);
                f.Draw(graphics);
                figure.figures.Add(f);
            }
        }

        private void DrowPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDraw = true;
                createDelig?.Invoke();
                firstPoint = e.Location;
                if (createDelig == CreateLine)
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
                    drawDelig?.Invoke(firstPoint, e.Location);
            }
        }

        private void DrowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDraw = false;
            drawDelig?.Invoke(firstPoint, e.Location);
        }


        #endregion

        #region Создание фигуры
        private void CreateLine() => line = new(pen);

        public void CreateRectangle() => rectangle = new(pen);

        public void CreateEllipse() => ellipse = new(pen);

        public void CreateStraighLine() => straightLine = new(pen);
        #endregion

        #region Кнопки
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = "d:\\";
                sfd.Filter = "MyPaint  (*png) | *.png";
                sfd.RestoreDirectory = true;
                sfd.DefaultExt = "png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = sfd.OpenFile())
                    {
                        BinaryFormatter myBin = new BinaryFormatter();
                        myBin.Serialize(stream, figure.figures);
                    }
                }
            }
            isSave = true;
        }

        private void OpenPng()
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Файлы MyPaint  (*png) | *.png";
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (figure.figures.Count != 0)
                        figure.figures.Clear();

                    Refresh();

                    using (Stream mystr = openFile.OpenFile())
                    {
                        try
                        {
                            BinaryFormatter myBin = new BinaryFormatter();
                            figure.figures = (List<Figure>)myBin.Deserialize(mystr);
                            figure.Draw(graphics);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка при открытии файла");
                        }
                    }
                }
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (!isSave)
            {
                var messageBox = MessageBox.Show("Есть не сохраненный холст.\nСохранить текущий холст?",
                                                   "Открыть",
                                                   MessageBoxButtons.YesNoCancel,
                                                   MessageBoxIcon.Question);
                if (messageBox == DialogResult.Yes)
                    SaveBtn_Click(sender, e);
                else if (messageBox == DialogResult.Cancel)
                    return;
            }
            OpenPng();
            drawDelig = null;
            isSave = true;
        }

        private void CleanBnt_Click(object sender, EventArgs e)
        {
            if (figure.figures.Count == 0)
                return;
            var messageBox = MessageBox.Show("Очистить?\nВы не сохранили прошлый холст",
                                              "Очистка",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            if (messageBox != DialogResult.Yes)
                return;
            figure.figures.Clear();
            Refresh();
            isSave = false;
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

        private void ColorBtn_Click(object sender, EventArgs e)
        {
            var ColorDialog = new ColorDialog();

            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = ColorDialog.Color;
                ColorBtn.BackColor = ColorDialog.Color;
            }
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
        #endregion

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            LabelPx.Text = $"{trackBar1.Value} px";
            pen.Width = (float)trackBar1.Value;
        }

        private void DrowPanel_Paint(object sender, PaintEventArgs e) => figure.Draw(graphics);

        private void Form1_Resize(object sender, EventArgs e) => graphics = DrowPanel.CreateGraphics();
    }
}