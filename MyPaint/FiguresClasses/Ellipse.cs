using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]//для сохранения 
    //класс отрисовки круга
    public class Ellipse: Figure //наследуемся от класса фигура
    {
        public Ellipse(Pen pen):base(pen) { }//конструктор 

        public override void Draw(Graphics gr)//переопределяем метод отрисовки
        {
            int[] setting = GetSettings();//массив с найтроками(высотой, шириной и тд)
            System.Drawing.Rectangle r = new(setting[0], setting[1], setting[2], setting[3]);//создаем экземпляр класса прямоугольника
            gr.DrawEllipse(new Pen(color, with), r);//на основе прямоугоника рисуем круг
        }
    }
}
