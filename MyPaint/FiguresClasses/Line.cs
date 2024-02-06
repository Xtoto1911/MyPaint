using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]//для сохранения
    //класс линии волнистой
    public class Line: Figure
    {
        public Line(Pen pen): base(pen) { }//конструктор

        public override void Draw(Graphics gr)//переопределяем матод
        {
            gr.DrawLines(new Pen(color, with), points.ToArray());//отрисовываем линии
        }
    }
}
