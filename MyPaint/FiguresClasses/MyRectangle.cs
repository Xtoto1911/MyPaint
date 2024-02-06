using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]//для сохранении
    //класс для отрисовки прямоугольника
    public class MyRectangle:Figure
    {
        public MyRectangle(Pen pen) : base(pen) { }//конструктор

        public override void Draw(Graphics gr)//переопределяем метод
        {
            int[] setting = GetSettings();//массив с настройками 
            System.Drawing.Rectangle r = new(setting[0], setting[1], setting[2], setting[3]);// создаем экземпляр класса прямоугольника
            gr.DrawRectangle(new Pen(color,with), r);//отрисовываем прямоугольник
        }
    }
}
