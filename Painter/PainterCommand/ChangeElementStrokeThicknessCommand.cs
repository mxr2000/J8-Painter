using Painter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.PainterCommand
{
    class ChangeElementStrokeThicknessCommand : IPainterCommand
    {
        public double OldThickness { get; set; }
        public MoveableObject Obj { get; set; }
        public void Undo()
        {
            Obj.StrokeThickness = OldThickness;
        }
        public ChangeElementStrokeThicknessCommand(MoveableObject obj, double oldThickness)
        {
            Obj = obj;
            OldThickness = oldThickness;
        }
    }
}
