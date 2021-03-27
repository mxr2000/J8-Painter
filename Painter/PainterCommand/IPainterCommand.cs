using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.PainterCommand
{
    public interface IPainterCommand
    {
        void Undo();
    }
}
