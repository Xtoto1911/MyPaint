using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]//для сохранения
                  //класс прямой линии
    public class StraightLine:Figure
    {
        public StraightLine(Pen pen): base(pen) { }//конструктор

        public override void Draw(Graphics gr)//переопределяем метод отрисовки
        {
            gr.DrawLine(new Pen(color, with), points[0], points[^1]);//рисуем линии
        }
    }
}
