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

namespace iS3.Unity.EXE
{
    /// <summary>
    /// Document.xaml 的交互逻辑
    /// </summary>
    public partial class Document : Window
    {
        public Document()
        {
            InitializeComponent();
            Loaded += Document_Loaded;
        }

        private void Document_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("管线分类示意图.ppt");
            list.Add("管线数据2017.1.16.xlsx");
            list.Add("翠屏-全段(1)通风口布.dwg");
            list.Add("平面分图（1：200）3.9报警打印.dwg");
            docList.ItemsSource = list;
        }

        private void docList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string tag = btn.Tag.ToString();
            System.Diagnostics.Process.Start(@"E:\0-软件开发（开发存储目录）\3-西安综合管廊\汇报\software\Data\doc\" + tag);

        }
    }
}
