using MyPaint.FiguresClasses;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        private Point firstPoint;//первая отчка
        private Graphics graphics;//для рисования
        private Pen pen;

        private MyRectangle rectangle;//наш прямоугольник
        private Ellipse ellipse;//наш круг
        private Line line;//непрерывная линия
        private StraightLine straightLine;//прямая линия
        private Figure figure;//фигура для сохранения

        private bool isDraw = false;//влаг дл отслеживая рисуем мы или нет
        private bool isSave = true;//флаг для предупреждения о том что не сохранили прогресс 

        private delegate void DelegateCreate();//делигат для создания экземпляра класса
                                               //делигат - это переменная которая хранит ссылку на метод
        private delegate void DelegateDrow(Point firstPoint, Point currPoint);//делигат для отрисовки
        private DelegateCreate createDelig;
        private DelegateDrow drawDelig;

        public Form1()
        {
            InitializeComponent();
            InitSettings();//настройки 
        }

        private void InitSettings()
        {
            graphics = DrowPanel.CreateGraphics();//для рисования на паленили
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//для красоты

            firstPoint = new();//создаем новую точку
            figure = new();//экземпляр класса фигура
            pen = new(Color.Black, 0);//стандартные настройки ручки
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            drawDelig = DrawLine;//в делигат передаем ссылку на метод с отрисовкой линии
            createDelig = CreateLine;// делигат с методом с созданием экземпляра класса

            LabelPx.Text = $"{trackBar1.Value} px";//для отображения размера шрифта
            pen.Width = (float)trackBar1.Value;//берем значение с тракбара
        }

        #region Отрисовка
        private void DrawLine(Point firstPoint, Point currPoint)//метод для отрисовки непрерывной линии
        {
            line.points.Add(firstPoint);//добавляем в лист класса первую и последнюю точки
            line.points.Add(currPoint);
            line.Draw(graphics);//рисуем линию
            if (!isDraw)//если мы отпустили левую кнопку мыши
                figure.figures.Add(line);//добавляем в лист фигур
        }

        private void DrawRectangle(Point old, Point current) => DrowFigure(rectangle, old, current);//отрисовка прямоугольника

        private void DrawEllipse(Point old, Point current) => DrowFigure(ellipse, old, current);//отрисовка круга

        private void DrawStraighLine(Point old, Point current) => DrowFigure(straightLine, old, current);//отрисвока прямой линии

        void DrowFigure(Figure f, Point old, Point current, bool isPoint = false)//метод для отрисовки фигур
        {
            f.points.Add(old);//добавление точки в лист с точками
            if (!isDraw || isPoint)//если мы отпускаем левую кнопку мыши
            {
                f.points.Add(current);//добавляем последнююю точку
                f.Draw(graphics);// рисуем фигуру
                figure.figures.Add(f);//добаялем в список фигур
            }
        }

        private void DrowPanel_MouseDown(object sender, MouseEventArgs e)//обработка события клика на панель
        {
            if (e.Button == MouseButtons.Left)//если мы нажали левой кнопкой мыши
            {
                isDraw = true;//говорим что мы рисуем
                createDelig?.Invoke();//вызываем делигат с методом для создания экземпляра класса фигуры
                firstPoint = e.Location;//позиция нашего клика
                if (createDelig == CreateLine)//если мы рисуем кривую линию
                {
                    var local = new Point(firstPoint.X + (int)pen.Width / 2, firstPoint.Y + (int)pen.Width);//расчет координат
                    DrowFigure(new Ellipse(pen), e.Location, local, true);//рисуем точку в виде элипса
                }
                isSave = drawDelig == null;//меняем флаг на сохранение
            }
        }

        private void DrowPanel_MouseMove(object sender, MouseEventArgs e)//обработка перемещения курсора по панели
        {
            if (e.Button == MouseButtons.Left)//если зажаа левая кнопка мыши
            {
                if (drawDelig == DrawLine)//если мы рисуем кривую линию
                {
                    drawDelig(firstPoint, e.Location);//отрисовываем линию
                    firstPoint = e.Location;//меняем первую точку
                }
                else
                    drawDelig?.Invoke(firstPoint, e.Location);//просто вызываем делигат
            }
        }

        private void DrowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDraw = false;//говорим что больше не рисуем
            drawDelig?.Invoke(firstPoint, e.Location);//вызываем делинат для отрисовки
        }


        #endregion

        #region Создание фигуры
        private void CreateLine() => line = new(pen);//создаем экземпляр класса кривой

        public void CreateRectangle() => rectangle = new(pen);//создаем экземпляр класса прямоугольника

        public void CreateEllipse() => ellipse = new(pen);//создаем экземпляр класса элипса

        public void CreateStraighLine() => straightLine = new(pen);//создаем экземпляр класса прямой линии
        #endregion

        #region Кнопки
        private void SaveBtn_Click(object sender, EventArgs e)//обработка события нажатия на кнопку сохранения
        {
            using (SaveFileDialog sfd = new SaveFileDialog())//диалог сохранения
            {
                sfd.InitialDirectory = "d:\\";//фильтры и все такое
                sfd.Filter = "MyPaint  (*mypaint) | *.mypaint";
                sfd.RestoreDirectory = true;
                sfd.DefaultExt = "mypaint";
                if (sfd.ShowDialog() == DialogResult.OK)//если мы нажали на ок
                {
                    using (Stream stream = sfd.OpenFile())//создаем файл
                    {
                        BinaryFormatter myBin = new BinaryFormatter();
                        myBin.Serialize(stream, figure.figures);//лист с фигурами сериализуем(сохраняем) в бинарный файл
                    }
                }
            }
            isSave = true;//флаг что мы сохранялись
        }
        private void SavePanelAsBitmap(string filePath)
        {
            // Создаем Bitmap с размерами Panel
            Bitmap bmp = new Bitmap(DrowPanel.ClientSize.Width, DrowPanel.ClientSize.Height);

            // Создаем Graphics для объекта Bitmap
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Отрисовываем содержимое Panel на объекте Bitmap
                DrowPanel.DrawToBitmap(bmp, DrowPanel.ClientRectangle);
            }

            // Сохраняем Bitmap в файл
            bmp.Save(filePath, ImageFormat.Png);

            // Освобождаем ресурсы Bitmap
            bmp.Dispose();
        }
        private void SaveImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())//диалог сохранения
            {
                sfd.InitialDirectory = "d:\\";//фильтры и все такое
                sfd.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";//указываем фильтр для BMP и всех файлов
                sfd.RestoreDirectory = true;
                sfd.DefaultExt = "png";//указываем расширение по умолчанию

                if (sfd.ShowDialog() == DialogResult.OK)//если мы нажали на ок
                {
                    DrowPanel.Update();// обновляем нарисованное
                    SavePanelAsBitmap(sfd.FileName);//вызываем функцию сохранения изображения
                }
            }
        }

        private bool CreateMessegeBox(string text, string caption)//метод для вызова месседжбокса
        {
            var messageBox = MessageBox.Show(text,
                                             caption,
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question);//создаем месседжбокс
            if (messageBox == DialogResult.Yes)//если нажали да
                SaveBtn_Click(new object(), new EventArgs());//то вызываем событие кнопки сохранения
            else if (messageBox == DialogResult.Cancel)//нажали отмену
                return false;
            return true;
        }

        private void OpenFile_Click(object sender, EventArgs e)//обработка события нажатия кнопки открытие файла
        {
            if (!isSave)//если мы что-то меняли и не сохранялись
            {
                bool aswer = CreateMessegeBox("Сохранить сохранить текущий хост?",
                                              "Открыть файл");//создаем месседж бокс
                if (!aswer)//если мы отменили
                    return;//
            }
            using (OpenFileDialog openFile = new OpenFileDialog())//вызываем диалоговое окно открытия файла
            {
                openFile.Filter = "(*mypaint) | *mypaint";//фильтр
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)//если мы нажали на ок
                {
                    if (figure.figures.Count != 0)//если в листе есть фигуры
                        figure.figures.Clear();// то мы чистим лист

                    Refresh();//вызываем перерисовку(для каждого объекта на форме событие Paint)
                              //для панели где мы рисуем мы обработали событие на 282 строке

                    using (Stream mystr = openFile.OpenFile())//открываем файл
                    {
                        try//для отлова ошибок
                        {
                            BinaryFormatter myBin = new BinaryFormatter();
                            figure.figures = (List<Figure>)myBin.Deserialize(mystr);//читаеи бинарный файл и записываем в лист фигур
                            figure.Draw(graphics);//перерисовываем
                        }
                        catch//обработка ошибки
                        {
                            MessageBox.Show("Ошибка при открытии файла");
                        }
                    }
                }
            }
            drawDelig = null;//чистим делигат
            isSave = true;//что нечего сохранять
        }

        private void CleanBnt_Click(object sender, EventArgs e)//обработка очистки холста
        {
            if (figure.figures.Count == 0)//если мы ничего не рисовали, то ничего не делаем
                return;
            if (!isSave)//если мы не сохраняли прогрессс, то предлагаем сохранить
            {
                bool answer = CreateMessegeBox("Сохранить перед очисткой?",
                                                "Очистка");
                if (!answer)
                    return;
            }
            figure.figures.Clear();//чистим лист
            Refresh();//перерисовываем
        }

        private void Exit_Click(object sender, EventArgs e)//кнопка выход
        {
            if (!isSave)
            {
                bool answer = CreateMessegeBox("Сохранить перед выходом?",
                                                "Выход");
                if (!answer)
                    return;
            }
            Application.Exit();//закрыаем программу
        }

        private void BackBtn_Click(object sender, EventArgs e)//обработка события нажатия на кнопку назад
        {
            if (figure.figures.Count != 0)//если мы рисовали
            {
                if (figure.figures[^1] is Line)//если последний рисунок линия, то удаляем точку и линию
                    figure.figures.RemoveRange(figure.figures.Count - 2, 2);
                else//если другие фигуры, то удаляем только его 
                    figure.figures.RemoveAt(figure.figures.Count - 1);
            }
            Refresh();//перерисовываем 
        }

        private void ColorBtn_Click(object sender, EventArgs e)//обработка события нажатия на кнопку смены цвета
        {
            var ColorDialog = new ColorDialog();//диалоговое окно выбора цвета

            if (ColorDialog.ShowDialog() == DialogResult.OK)//если нажали на ок
            {
                pen.Color = ColorDialog.Color;//меняем цвет
                ColorBtn.BackColor = ColorDialog.Color;//меняем цвет кнопки
            }
        }

        private void RecBtn_Click(object sender, EventArgs e)//обработки нажатия на кнопки
                                                             // одинаково для всех
                                                             // в делигаты присваиваем ссылки на методы
                                                             // создания объекта и отрисовки
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

        private void trackBar1_Scroll(object sender, EventArgs e)//обработка события перемещения скрола трекбара
        {
            LabelPx.Text = $"{trackBar1.Value} px";//пишем в лейбл значание 
            pen.Width = (float)trackBar1.Value;//передаем в ширину кисти
        }

        private void DrowPanel_Paint(object sender, PaintEventArgs e) => figure.Draw(e.Graphics);//для обработка перерисовки

        private void Form1_Resize(object sender, EventArgs e) => graphics = DrowPanel.CreateGraphics();//обработка события смены размера окна
                                                                                                       //чтобы рисовать можно было на всей площади

    }
}