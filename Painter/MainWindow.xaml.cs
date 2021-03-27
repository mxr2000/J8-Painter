using Microsoft.Win32;
using Painter.Control;
using Painter.Model;
using Painter.PainterCommand;
using Painter.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextElement = Painter.Model.TextElement;

namespace Painter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        TextInputDialog dialog = new TextInputDialog();
        public MainWindow()
        {
            InitializeComponent();
            var state = canvas.GetState("Selected") as SelectedState;
            state.ColorPicker = colorPicker;
            state.StrokeThicknessSlider = sliderStroke;
            var paintState = canvas.GetState("Painting") as PaintingState;
            paintState.LbPaintingElement = lbElements;

        }

        private void lbElements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var point = canvas.PointToScreen(new Point(0, 0));
            MoveableObject obj = null;
            dialog.Owner = this;
            switch (lbElements.SelectedIndex)
            {
                case 0: obj = new LineElement(); break;
                case 1: obj = new CircleElement(); break;
                case 2: obj = new EllipseElement(); break;
                case 3: obj = new RectangleElement();break;
                case 4: obj = new StrokeElement(); break;
                case 5: obj = new TextElement(dialog, point.X, point.Y); break;
                case 6: obj = new ImageElement(GetImageFilePath()); break;
                default:obj = new RectangleElement();break;
            }
            canvas.Objects.Add(obj);

            var state = canvas.GetState("Painting") as PaintingState;
            state.Obj = obj;
            canvas.SetState("Painting");

        }

        private void sliderStroke_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(canvas.CurrentState is SelectedState)
            {
                var obj = (canvas.CurrentState as SelectedState).Obj;
                obj.StrokeThickness = e.NewValue;
                canvas.InvalidateVisual();
            }
        }

        private void sliderStroke_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Dick");
            if(canvas.CurrentState is SelectedState)
            {
                (canvas.CurrentState as SelectedState).ThicknessChanegd = true;
            }
        }

        private void ColorPicker_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if(canvas.CurrentState is SelectedState)
            {
                (canvas.CurrentState as SelectedState).ColorChanged = true;
                ((canvas.CurrentState as SelectedState).Obj.Stroke as SolidColorBrush).Color = e.NewValue;
            }
        }

        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            var state = canvas.CurrentState;
            if(state is SelectedState)
            {
                var obj = (state as SelectedState).Obj;
                canvas.CommandStack.Push(new RemoveElementCommand(obj, canvas));
                canvas.Objects.Remove(obj);
                canvas.SetState("None");
                canvas.InvalidateVisual();
            }else if(state is MultiSelectedState)
            {
                foreach(var obj in (state as MultiSelectedState).ObjList)
                {
                    canvas.CommandStack.Push(new RemoveElementCommand(obj, canvas));
                    canvas.Objects.Remove(obj);
                }
                canvas.SetState("None");
                canvas.InvalidateVisual();
            }
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            var stack = canvas.CommandStack;
            if(stack.Count > 0)
            {
                var command = stack.Pop();
                command.Undo();
                canvas.InvalidateVisual();
            }
        }

        private string GetImageFilePath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "图片文件(*.jpg,*.gif,*.bmp)|*.jpg;*.gif;*.bmp";
            if (dialog.ShowDialog().Value)
            {
                return dialog.FileName;
            }
            return "";
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if(canvas.CurrentState is SelectedState)
            {
                (canvas.GetState("ZoomIn") as ZoomInState).Obj = (canvas.CurrentState as SelectedState).Obj;
                canvas.SetState("ZoomIn");
                canvas.InvalidateVisual();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            foreach(Window win in Application.Current.Windows){
                if(win != this)
                {
                    win.Close();
                }
            }
            base.OnClosed(e);
        }
    }


}
