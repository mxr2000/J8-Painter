using Painter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Painter.PainterCommand
{
    class ChangeElementColorCommand : IPainterCommand
    {
        public void Undo()
        {
            (obj.Stroke as SolidColorBrush).Color = oldValue;
        }
        MoveableObject obj;
        Color oldValue;
        public ChangeElementColorCommand(MoveableObject obj, Color oldValue)
        {
            this.obj = obj;
            this.oldValue = oldValue;
        }
    }
}
