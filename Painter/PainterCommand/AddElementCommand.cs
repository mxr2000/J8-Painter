using Painter.Control;
using Painter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.PainterCommand
{
    class AddElementCommand : IPainterCommand
    {
        public void Undo()
        {
            canvas.Objects.Remove(obj);
        }
        MoveableObject obj;
        PainterCanvas canvas;
        public AddElementCommand(MoveableObject obj, PainterCanvas canvas)
        {
            this.obj = obj;
            this.canvas = canvas;
        }
    }
}
