using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]
    public class Line: Figure
    {
        public Line(Pen pen): base(pen) { }

        public override void Drow(Graphics gr)
        {
            gr.DrawLines(new Pen(color, with), points.ToArray());
        }
    }
}
