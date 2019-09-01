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

namespace iS3.Client
{
    /// <summary>
    /// DGObjectViewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CommonWindow : Window
    {
        private static CommonWindow instance;
        public static CommonWindow GetInstance(UserControl control)
        {
            if (instance==null)
            {
                instance = new CommonWindow();
                instance.InitializeComponent();
            }
            instance.Content.Children.Clear();
            instance.Content.Children.Add(control);
            return instance;
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
