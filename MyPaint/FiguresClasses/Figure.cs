using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]//для сохраниний
    //Обощенный класс фигура
    public class Figure
    {
        protected float with;//ширина
        protected Color color;//цвет

        public List<Figure> figures  = new();//лист с нарисованными фигурами(мы его сохраняем при загрузке
                                             //мы сюда загружаем объекты и отрисовываем)
        public List<Point> points  = new();//точки нужны для того чтобы узнать первую и последнюю точку

        public Figure() { }//конструктор

        public Figure(Pen pen)//еще конструктор с параметром
        {
            color = pen.Color;//присваиваем цвет
            with = pen.Width;//ширина
        }

        protected int[] GetSettings()//настройки для перерисовки 
        {
            //так как на форме оси координат представлены, что ось Х как обычно слева на право, а
            //ось Y увеличивается сверху вниз
            // плюс отрисовка все фигуры рисуются с левого верхнего угла, чтобы рисовать нужно только 1 точка и высота и ширина
            int[] settings = new int[4];//создаем массив
            settings[0] = Math.Min(points[0].X, points[^1].X);// находим самую левую точку(^ - этот знак для перебора массива с конца)
            settings[1] = Math.Min(points[0].Y, points[^1].Y);// находим самую верхнюю точку
            settings[2] = Math.Abs(points[^1].X - points[0].X);// расчитываем ширину
            settings[3] = Math.Abs(points[^1].Y - points[0].Y);//расчитываем высоту
            return settings;//возвращаем массив
        }

        public virtual void Draw(Graphics gr)//метод для отрисовки всех нарисованных фигур из листа
                                             //virtual указывает что этот метод можно переопределить 
                                             //в классах наследниках
        {
            foreach(var figure in figures)//пробегаем по всему массиву
                if(figure != null)//проверка на null
                    figure.Draw(gr);//вызываем отрисоку для фигуры
        }
    }
}
