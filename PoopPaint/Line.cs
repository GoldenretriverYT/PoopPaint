using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopPaint
{
    public class Line
    {
        public SKPoint p1, p2;

        public Line(SKPoint p1, SKPoint p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public SKPoint[] GetPoints(int quantity)
        {
            var points = new SKPoint[quantity];
            float ydiff = p2.Y - p1.Y, xdiff = p2.X - p1.X;
            double slope = (double)(p2.Y - p1.Y) / (p2.X - p1.X);
            double x, y;

            quantity--;

            for (double i = 0; i < quantity; i++)
            {
                y = slope == 0 ? 0 : ydiff * (i / quantity);
                x = slope == 0 ? xdiff * (i / quantity) : y / slope;
                points[(int)i] = new SKPoint((float)Math.Round(x) + p1.X, (float)Math.Round(y) + p1.Y);
            }

            points[quantity] = p2;
            return points;
        }
    }
}
