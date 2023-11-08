using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]
    public class Ellipse: Figure
    {
        public Ellipse(Pen pen):base(pen) { }

        public override void Drow(Graphics gr)
        {
            int[] setting = GetSettings();
            System.Drawing.Rectangle r = new(setting[0], setting[1], setting[2], setting[3]);
            gr.DrawEllipse(new Pen(color, with), r);
        }
    }
}
