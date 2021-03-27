using Painter.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Painter.Model
{
    class TextElement : MoveableObject
    {
        public TextElement(TextInputDialog dialog, double canvasLeft, double canvasTop)
        {
            Dialog = dialog;
            this.canvasLeft = canvasLeft;
            this.canvasTop = canvasTop;
        }
        public string Text { get; set; } = "";
        private string formattedText = "";
        double lastX, lastY;
        double canvasLeft, canvasTop;
        public TextInputDialog Dialog { get; set; }
        public override void AdjustSize()
        {
            double memX = X;
            double memY = Y;
            X = Math.Min(X, lastX);
            Y = Math.Min(Y, lastY);
            Width = Math.Abs(lastX - memX);
            Height = Math.Abs(lastY - memY);
        }

        public override void Draw(DrawingContext dc)
        {
            TransformText();
            FormattedText text = new FormattedText(formattedText, 
                System.Globalization.CultureInfo.CurrentCulture, 
                System.Windows.FlowDirection.LeftToRight, 
                new Typeface("Georgia"), 
                20, 
                Pen.Brush
                );
            dc.DrawText(text, new System.Windows.Point(X, Y));
        }

        public override void Translate(double x, double y)
        {
            X += x;
            Y += y;
        }
        public override void OnMouseDown(double x, double y)
        {
            base.OnMouseDown(x, y);
            X = x;
            Y = y;
            Width = Height = 0;
            lastX = x;
            lastY = y;
            AdjustSize();
        }
        public override void OnMouseMove(double x, double y)
        {
            base.OnMouseMove(x, y);
            lastX = x;
            lastY = y;
            AdjustSize();
        }
        public override void OnMouseUp(double x, double y)
        {
            base.OnMouseUp(x, y);
            Text = GetInputText();
        }

        private void TransformText()
        {
            int countInARow = (int)Width / 20;
            string ret = "";
            int index = 0;
            while(index < Text.Length)
            {
                int count = (index + countInARow > Text.Length) ? Text.Length - index : countInARow;
                string temp = Text.Substring(index, count);
                ret += temp;
                ret += "\n";
                index += countInARow;
            }
            formattedText = ret;
        }

        private string GetInputText()
        {
            Dialog.Left = canvasLeft + X;
            Dialog.Top = canvasTop + Y;
            Dialog.ShowDialog();
            return Dialog.Text;
        }
    }
}
