using Painter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.PainterCommand
{
    class MoveElementCommand : IPainterCommand
    {
        public void Undo()
        {
            obj.Translate(-offsetX, -offsetY);
        }
        MoveableObject obj;
        double offsetX, offsetY;
        public MoveElementCommand(MoveableObject obj, double offsetX, double offsetY)
        {
            this.obj = obj;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }
    }
}
