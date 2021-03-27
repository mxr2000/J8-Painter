using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Painter.Model
{
    public abstract class MoveableObject
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Brush Stroke
        {
            get { return Pen.Brush; }
            set { 
                Pen.Brush = value;
            }
        }

        public double StrokeThickness
        {
            get { return Pen.Thickness; }
            set { 
                Pen.Thickness = value;
            }
        }

        public Pen Pen { get; set; } = new Pen() { Brush = new SolidColorBrush(Colors.Black), Thickness = 2};

        public bool IsPointInside(double x, double y)
        {
            return X < x && X + Width > x && Y < y && Y + Height > y;
        }
        public bool isContained(double x1, double y1, double x2, double y2)
        {
            return X > x1 && X + Width < x2 && Y > y1 && Y + Height < y2;
        }

        public abstract void AdjustSize();
        public abstract void Translate(double x, double y);
        public abstract void Draw(DrawingContext dc);
        public virtual void OnMouseMove(double x, double y) { }
        public virtual void OnMouseUp(double x, double y) { }
        public virtual void OnMouseDown(double x, double y) { }
        public virtual void ZoomIn(double width, double height) { }
    }
}
