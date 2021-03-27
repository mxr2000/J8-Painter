using Painter.Control;
using Painter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.PainterCommand
{
    class RemoveElementCommand : IPainterCommand
    {
        public void Undo()
        {
            canvas.Objects.Add(obj);
            canvas.SetState("None");
        }
        MoveableObject obj;
        PainterCanvas canvas;
        public RemoveElementCommand(MoveableObject obj, PainterCanvas canvas)
        {
            this.obj = obj;
            this.canvas = canvas;
        }
    }
}
