using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Painter.Control
{
    public class PainterState
    {
        protected PainterCanvas painterCanvas;
        public PainterState(PainterCanvas canvas)
        {
            painterCanvas = canvas;
        }
        public virtual void OnMouseDown(double x, double y) { }
        public virtual void OnMouseMove(double x, double y) { }
        public virtual void OnMouseUp(double x, double y) { }
        public virtual void DrawSpecific(DrawingContext dc) { }
        public virtual void OnEnteringState() { }
        public virtual void OnLeavingState() { }
    }
}
