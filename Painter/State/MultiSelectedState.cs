using Painter.Control;
using Painter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Painter.State
{
    class MultiSelectedState : PainterState
    {
        public MultiSelectedState(PainterCanvas canvas) : base(canvas) { }
        public List<MoveableObject> ObjList { get; set; }
        private double x1, y1, x2, y2;
        private double lastX, lastY;
        bool dragging;
        public Pen HighlightPen { get; set; } = new Pen
        {
            Brush = new SolidColorBrush(Colors.Green),
            Thickness = 2,
            DashStyle = DashStyles.Dash
        };
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            if(x > x1 && x < x2 && y > y1 && y < y2)
            {
                lastX = x;
                lastY = y;
                dragging = true;
            }
            else
            {
                var state = painterCanvas.GetState("None");
                state.OnMouseDown(x, y);
                painterCanvas.SetState("None");
            }
        }
        public override void OnMouseMove(double x, double y)
        {
            base.OnMouseMove(x, y);
            if (dragging)
            {
                double offsetX = x - lastX;
                double offsetY = y - lastY;
                foreach(var item in ObjList)
                {
                    item.Translate(offsetX, offsetY);
                    
                }
                x1 += offsetX;
                x2 += offsetX;
                y1 += offsetY;
                y2 += offsetY;
                lastX = x;
                lastY = y;
            }
        }
        public override void OnMouseUp(double x, double y)
        {
            base.OnMouseUp(x, y);
            dragging = false;
        }
        public override void OnEnteringState()
        {
            base.OnEnteringState();
            x1 = y1 = Double.MaxValue;
            x2 = y2 = 0;
            foreach(var item in ObjList)
            {
                x1 = Math.Min(x1, item.X);
                y1 = Math.Min(y1, item.Y);
                x2 = Math.Max(x2, item.X + item.Width);
                y2 = Math.Max(y2, item.Y + item.Height);
            }
        }
        public override void DrawSpecific(DrawingContext dc)
        {
            base.DrawSpecific(dc);
            var rect = new System.Windows.Rect(x1, y1, x2 - x1, y2 - y1);
            dc.DrawRectangle(null, HighlightPen, rect);
        }
    }
}
