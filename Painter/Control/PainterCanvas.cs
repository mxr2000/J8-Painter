using Painter.Model;
using Painter.PainterCommand;
using Painter.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Painter.Control
{
    public class PainterCanvas : Canvas, INotifyPropertyChanged
    {
        public PainterCanvas() : base()
        {
            states.Add("None", new NoneState(this));
            states.Add("Selected", new SelectedState(this));
            states.Add("Painting", new PaintingState(this));
            states.Add("MultiSelected", new MultiSelectedState(this));
            states.Add("ZoomIn", new ZoomInState(this));
            //LineElement line = new LineElement()
            //{
            //    X1 = 0,
            //    Y1 = 0,
            //    X2 = 100,
            //    Y2 = 100
            //};
            //RectangleElement rect = new RectangleElement()
            //{
            //    X = 200,
            //    Y = 200,
            //    Width = 100,
            //    Height = 100
            //};
            //EllipseElement ellipse = new EllipseElement()
            //{
            //    X = 300,
            //    Y = 300,
            //    Width = 100,
            //    Height = 50
            //};

            //StrokeElement stroke = new StrokeElement();
            //Objects.Add(line);
            //Objects.Add(rect);
            //Objects.Add(ellipse);
            //Objects.Add(stroke);
            CurrentState = states["None"];
        }
        public List<MoveableObject> Objects { get; set; } = new List<MoveableObject>();
        public Stack<IPainterCommand> CommandStack { get; private set; } = new Stack<IPainterCommand>();
       
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            foreach(var obj in Objects)
            {
                obj.Draw(dc);
            }
            CurrentState.DrawSpecific(dc);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            var pos = e.GetPosition(this);
            CurrentState.OnMouseDown(pos.X, pos.Y);
            InvalidateVisual();
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var pos = e.GetPosition(this);
            CurrentState.OnMouseMove(pos.X, pos.Y);
            InvalidateVisual();
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            var pos = e.GetPosition(this);
            CurrentState.OnMouseUp(pos.X, pos.Y);
            InvalidateVisual();
        }

        private MoveableObject GetSelectedObject(int x, int y)
        {
            foreach(var obj in Objects)
            {
                if(obj.IsPointInside(x, y))
                {
                    return obj;
                }
            }
            return null;
        }

        public PainterState CurrentState { get; set; }
        protected Dictionary<string, PainterState> states = new Dictionary<string, PainterState>();
        public void SetState(string stateName)
        {
            CurrentState.OnLeavingState();
            CurrentState = states[stateName];
            CurrentState.OnEnteringState();
        }
        public PainterState GetState(string name)
        {
            return states[name];
        }


        
        

    }
}
