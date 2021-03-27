using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Painter.Control
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        public static DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker),
            new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
        public static DependencyProperty RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
        public static DependencyProperty BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
        public static DependencyProperty GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Color oldColor = (Color)e.OldValue;

            ColorPicker picker = (ColorPicker)sender;
            picker.Red = newColor.R;
            picker.Blue = newColor.B;
            picker.Green = newColor.G;

            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldColor, newColor);
            args.RoutedEvent = ColorChangedEvent;
            picker.RaiseEvent(args);
        }

        public static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker picker = (ColorPicker)sender;
            Color color = picker.Color;

            if(e.Property == RedProperty)
            {
                color.R = (byte)e.NewValue;
            }else if (e.Property == BlueProperty)
            {
                color.B = (byte)e.NewValue;
            }else if (e.Property == GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }
            picker.Color = color;

        }

        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

            
    }
}
