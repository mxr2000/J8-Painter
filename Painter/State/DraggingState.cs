using Painter.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.State
{
    class DraggingState : PainterState
    {
        public DraggingState(PainterCanvas canvas) : base(canvas) { }
        
    }
}
