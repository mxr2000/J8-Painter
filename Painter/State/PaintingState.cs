using Painter.Control;
using Painter.Model;
using Painter.PainterCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Painter.State
{
    public class PaintingState : PainterState
    {
        public MoveableObject Obj { get; set; }
        public ListBox LbPaintingElement { get; set; }
        public PaintingState(PainterCanvas canvas) : base(canvas) { }
        bool dragging;
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            dragging = true;
            Obj.OnMouseDown(x, y);
        }
        public override void OnMouseMove(double x, double y)
        {
            base.OnMouseMove(x, y);
            if (dragging)
            {
                Obj.OnMouseMove(x, y);
            }
        }
        public override void OnMouseUp(double x, double y)
        {
            base.OnMouseUp(x, y);
            if (dragging)
            {
                Obj.OnMouseUp(x, y);
                SelectedState state = painterCanvas.GetState("Selected") as SelectedState;
                state.Obj = Obj;
                painterCanvas.CommandStack.Push(new AddElementCommand(Obj, painterCanvas));
                painterCanvas.SetState("Selected");
            }
        }
        public override void OnEnteringState()
        {
            base.OnEnteringState();
            dragging = false;
        }
        public override void OnLeavingState()
        {
            base.OnLeavingState();
            LbPaintingElement.SelectedItem = null;
        }
    }
}
