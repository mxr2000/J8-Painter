using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Painter.Model
{
    class LineElement : MoveableObject
    {
        private double _x1;

        public double X1
        {
            get { return _x1; }
            set 
            { 
                _x1 = value;
                AdjustSize();
            }
        }
        private double _y1;

        public double Y1
        {
            get { return _y1; }
            set 
            { 
                _y1 = value;
                AdjustSize();
            }
        }

        private double _x2;

        public double X2
        {
            get { return _x2; }
            set 
            { 
                _x2 = value;
                AdjustSize();
            }
        }

        private double _y2;

        public double Y2
        {
            get { return _y2; }
            set 
            { 
                _y2 = value;
                AdjustSize();
            }
        }

        public override void AdjustSize()
        {
            X = Math.Min(X1, X2);
            Y = Math.Min(Y1, Y2);
            Width = Math.Abs(X1 - X2);
            Height = Math.Abs(Y1 - Y2);
        }

        public override void Draw(DrawingContext dc)
        {
            dc.DrawLine(Pen, new System.Windows.Point(X1, Y1), new System.Windows.Point(X2, Y2));
        }

        public override void Translate(double x, double y)
        {
            _x1 += x;
            _x2 += x;
            _y1 += y;
            _y2 += y;
            AdjustSize();
        }
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            _x1 = _x2 = x;
            _y1 = _y2 = y;
            AdjustSize();
        }
        public override void OnMouseMove(double x, double y)
        {
            base.OnMouseMove(x, y);
            _x2 = x;
            _y2 = y;
            AdjustSize();
        }
        public override void OnMouseUp(double x, double y)
        {
            base.OnMouseUp(x, y);
        }

        public override void ZoomIn(double width, double height)
        {
            base.ZoomIn(width, height);
            X2 *= (width / Width);
            Y2 *= (height / Height);
        }
    }
}
