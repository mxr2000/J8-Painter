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
using System.Windows.Shapes;

namespace Painter.Control
{
    /// <summary>
    /// TextInputDialog.xaml 的交互逻辑
    /// </summary>
    public partial class TextInputDialog : Window
    {
        public TextInputDialog()
        {
            InitializeComponent();
            tbInput.Focus();
        }
        public string Text { get; set; } = "undefined";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Text = tbInput.Text;
            this.Close();
        }
    }
}
