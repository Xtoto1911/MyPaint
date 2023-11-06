using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]
    public class Figure
    {
        protected double with;
        protected Color color;

        public List<Figure> figures  = new();
        public List<Point> points  = new();

        public Figure() { }

        public Figure(Pen pen)
        {
            color = pen.Color;
            with = pen.Width;
        }
        /// <summary>
        /// возвращает массив характеристик фигуры
        /// 0 - позиция по x
        /// 1 - позиция по y
        /// 2 - ширина
        /// 3 - высота
        /// </summary>
        /// <returns></returns>
        protected int[] GetSettings()
        {
            int[] settings = new int[4];
            settings[0] = Math.Min(points[0].X, points[^1].X);
            settings[1] = Math.Min(points[0].Y, points[^1].Y);
            settings[2] = Math.Abs(points[^1].X - points[0].X);
            settings[3] = Math.Abs(points[^1].Y - points[0].Y);
            return settings;

        }
        public virtual void Drow(Graphics gr)
        {
            foreach(var figure in figures)
                if(figure != null)
                    figure.Drow(gr);
        }
    }
}
