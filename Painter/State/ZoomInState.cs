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
    class ZoomInState : PainterState
    {
        
        public ZoomInState(PainterCanvas canvas) : base(canvas) { }
        public override void DrawSpecific(DrawingContext dc)
        {
            base.DrawSpecific(dc);
            Obj.Draw(dc);
        }

        public MoveableObject Obj { get; set; }
        private double offsetX, offsetY, oldWidth, oldHeight;
        public override void OnEnteringState()
        {
            base.OnEnteringState();
            offsetX = Obj.X;
            offsetY = Obj.Y;
            oldWidth = Obj.Width;
            oldHeight = Obj.Height;
            Obj.Translate(-Obj.X, -Obj.Y);
            double ratio = Math.Min(painterCanvas.ActualWidth / Obj.Width, painterCanvas.ActualHeight / Obj.Height);
            Obj.ZoomIn(Obj.Width * ratio, Obj.Height * ratio);
            Obj.Width *= ratio;
            Obj.Height *= ratio;
        }
        public override void OnLeavingState()
        {
            base.OnLeavingState();
            Obj.Translate(offsetX, offsetY);
            Obj.ZoomIn(oldWidth, oldHeight);
            Obj.Width = oldWidth;
            Obj.Height = oldHeight;
        }
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            painterCanvas.SetState("None");
        }
    }
}
