using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Painter.Model
{
    public class StrokeElement : MoveableObject
    {
        public List<Point> Points { get; set; } = new List<Point>(); 
        public override void AdjustSize()
        {
            var p = Points[Points.Count - 1];
            double memX = X;
            double memY = Y;
            X = Math.Min(X, p.X);
            Y = Math.Min(Y, p.Y);
            
            if(p.X - memX < 0)
            {
                Width = (Width + memX - p.X);
            }
            else
            {
                Width = Math.Max(Width, p.X - memX);
            }
            if(p.Y - memY < 0)
            {
                Height = (Height + memY - p.Y);
            }
            else
            {
                Height = Math.Max(Height, p.Y - memY);
            }
            Console.WriteLine("X = " + X + ", Y = " + Y + ", w = " + (int)Width + " h = " + (int)Height);
        }

        public override void Draw(DrawingContext dc)
        {
            for(int i = 0; i < Points.Count - 1; i++)
            {
                dc.DrawLine(Pen, Points[i], Points[i + 1]);
            }
        }

        public override void Translate(double x, double y)
        {
            X += x;
            Y += y;
            List<Point> list = new List<Point>();
            foreach (var p in Points)
            {
                list.Add(new Point(p.X + x, p.Y + y));
            }
            Points = list;
        }
        public StrokeElement()
        {
            X = Y = Double.MaxValue;
            Width = Height = 0;
        }
        public override void OnMouseMove(double x, double y)
        {
            base.OnMouseMove(x, y);
            var p = new Point(x, y);
            Points.Add(p);
            AdjustSize();
        }
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            X = x;
            Y = y;
        }
        public override void ZoomIn(double width, double height)
        {
            base.ZoomIn(width, height);
            double ratio = width / Width;
            List<Point> list = new List<Point>();
            foreach(var point in Points)
            {
                list.Add(new Point(point.X * ratio, point.Y * ratio));
            }
            Points = list;
        }
    }
}
