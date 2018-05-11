﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    public class Oval : Shape
    {
        public Oval(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void draw()
        {
            Console.WriteLine("Oval({0}, {1}, {2}, {3})", x1, y1, x2, y2);
        }
    }
}
