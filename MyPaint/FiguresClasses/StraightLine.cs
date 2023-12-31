﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FiguresClasses
{
    [Serializable]
    public class StraightLine:Figure
    {
        public StraightLine(Pen pen): base(pen) { }

        public override void Draw(Graphics gr)
        {
            gr.DrawLine(new Pen(color, with), points[0], points[^1]);
        }
    }
}
