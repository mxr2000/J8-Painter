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
    public class NoneState : PainterState
    {
        public NoneState(PainterCanvas canvas) : base(canvas) { }
        private double x1, y1, x2, y2;
        bool trap;
        public Pen DashPen { get; set; } = new Pen()
        {
            Brush = new SolidColorBrush(Colors.DarkGray),
            Thickness = 2,
            DashStyle = DashStyles.Dash
        };
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            foreach(var item in painterCanvas.Objects)
            {
                if(item.IsPointInside(x, y))
                {
                    SelectedState state = painterCanvas.GetState("Selected") as SelectedState;
                    state.Obj = item;
                    state.OnMouseDown(x, y);
                    painterCanvas.SetState("Selected");
                    return;
                }
            }
            trap = true;
            x1 = x2 = x;
            y1 = y2 = y;
        }
        public override void OnMouseMove(double x, double y)
        {
            base.OnMouseMove(x, y);
            x2 = x;
            y2 = y;

        }
        public override void OnMouseUp(double x, double y)
        {
            base.OnMouseUp(x, y);
            if (trap)
            {
                x2 = x;
                y2 = y;
                List<MoveableObject> list = new List<MoveableObject>();
                double px1, py1, px2, py2;
                px1 = Math.Min(x1, x2);
                px2 = Math.Max(x1, x2);
                py1 = Math.Min(y1, y2);
                py2 = Math.Max(y1, y2);
                foreach (var obj in painterCanvas.Objects)
                {
                    if (obj.isContained(px1, py1, px2, py2))
                    {
                        list.Add(obj);
                    }
                }
                if (list.Count != 0)
                {
                    MultiSelectedState state = painterCanvas.GetState("MultiSelected") as MultiSelectedState;
                    state.ObjList = list;
                    painterCanvas.SetState("MultiSelected");
                }
            }
            trap = false;
        }

        public override void DrawSpecific(DrawingContext dc)
        {
            base.DrawSpecific(dc);
            if (trap)
            {
                double px1, py1, px2, py2;
                px1 = Math.Min(x1, x2);
                px2 = Math.Max(x1, x2);
                py1 = Math.Min(y1, y2);
                py2 = Math.Max(y1, y2);
                var rect = new System.Windows.Rect(px1, py1, px2 - px1, py2 - py1);
                dc.DrawRectangle(null, DashPen, rect);
            }
        }

        public override void OnLeavingState()
        {
            base.OnLeavingState();
            trap = false;
        }



    }
}
