using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Painter.Model
{
    class CircleElement : MoveableObject
    {
        public double Radius { get; set; }
        double lastX, lastY;
        public override void AdjustSize()
        {
            double memX = X;
            double memY = Y;
            X = Math.Min(X, lastX);
            Y = Math.Min(Y, lastY);
            Width = Math.Abs(lastX - memX);
            Height = Math.Abs(lastY - memY);
            Radius = Math.Min(Width, Height) / 2;
            Width = Height = 2 * Radius;
        }

        public override void Draw(DrawingContext dc)
        {
            dc.DrawEllipse(null, Pen, new System.Windows.Point(X + Radius, Y + Radius), Radius, Radius);
        }

        public override void Translate(double x, double y)
        {
            X += x;
            Y += y;
        }
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            X = x;
            Y = y;
            Width = Height = 0;
            lastX = x;
            lastY = y;
            AdjustSize();
        }
        public override void OnMouseMove(double x, double y)
        {
            base.OnMouseMove(x, y);
            lastX = x;
            lastY = y;
            AdjustSize();
        }
        public override void ZoomIn(double width, double height)
        {
            base.ZoomIn(width, height);
            Radius = Math.Min(Width, Height) / 2;
        }
    }
}
