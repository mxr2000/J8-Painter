using Painter.Control;
using Painter.Model;
using Painter.PainterCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Painter.State
{
    public class SelectedState : PainterState
    {
        public ColorPicker ColorPicker { get; set; }
        public Slider StrokeThicknessSlider { get; set; }

        public Pen HighlightPen { get; set; } = new Pen()
        {
            Brush = new SolidColorBrush(Colors.Red),
            Thickness = 2,
            DashStyle = DashStyles.Dash
        };
        public SelectedState(PainterCanvas canvas) : base(canvas) { }
        public MoveableObject Obj { get; set; }
        double lastX, lastY;
        bool dragging;
        public override void DrawSpecific(DrawingContext dc)
        {
            base.DrawSpecific(dc);
            var rect = new System.Windows.Rect(Obj.X, Obj.Y, Obj.Width, Obj.Height);
            dc.DrawRectangle(null, HighlightPen, rect);
        }
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            if (!Obj.IsPointInside(x, y))
            {
                foreach (var item in painterCanvas.Objects)
                {
                    if (item.IsPointInside(x, y))
                    {
                        SaveChangedColor();
                        SaveChangedThickness();  

                        Obj = item;
                        lastX = x;
                        lastY = y;

                        oldX = Obj.X;
                        oldY = Obj.Y;
                        oldColor = (Obj.Pen.Brush as SolidColorBrush).Color;
                        oldThickness = Obj.StrokeThickness;

                        dragging = true;
                        return;
                    }
                }
                painterCanvas.SetState("None");
            }
            else
            {
                dragging = true;
                lastX = x;
                lastY = y;
            }
        }
        public override void OnMouseMove(double x, double y)
        {
            base.OnMouseMove(x, y);
            if (dragging)
            {
                double offsetX = x - lastX;
                double offsetY = y - lastY;
                Obj.Translate(offsetX, offsetY);
                lastX = x;
                lastY = y;
            }
        }
        public override void OnMouseUp(double x, double y)
        {
            base.OnMouseUp(x, y);
            if(dragging)
                painterCanvas.CommandStack.Push(new MoveElementCommand(Obj, Obj.X - oldX, Obj.Y - oldY));
            dragging = false;
        }

        public bool ColorChanged { get; set; }
        public bool ThicknessChanegd{ get; set; }
        double oldX, oldY;
        Color oldColor;
        double oldThickness;
        public override void OnEnteringState()
        {
            base.OnEnteringState();
            ColorPicker.Color = (Obj.Pen.Brush as SolidColorBrush).Color;
            StrokeThicknessSlider.Value = Obj.StrokeThickness;
            dragging = false;

            oldX = Obj.X;
            oldY = Obj.Y;
            oldColor = (Obj.Pen.Brush as SolidColorBrush).Color;
            oldThickness = Obj.StrokeThickness;
        }
        public override void OnLeavingState()
        {
            base.OnLeavingState();
            SaveChangedColor();
            SaveChangedThickness();
        }
        public void SaveChangedColor()
        {
            if (ColorChanged)
            {
                painterCanvas.CommandStack.Push(new ChangeElementColorCommand(Obj, oldColor));
                ColorChanged = false;
            }
        }
        public void SaveChangedThickness()
        {
            if (ThicknessChanegd)
            {
                painterCanvas.CommandStack.Push(new ChangeElementStrokeThicknessCommand(Obj, oldThickness));
                ThicknessChanegd = false;
            }
        }
    }
}
