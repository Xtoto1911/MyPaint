using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    public class StraightLine:Figure
    {
        public StraightLine(Pen pen): base(pen) { }

        public override void Drow(Graphics gr)
        {
            gr.DrawLine(new Pen(color, with), points[0], points[^1]);
        }
    }
}
