using iS3.Core.Client;
using iS3.Core.Model;
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

namespace iS3.Construction.Client.Wins
{
    /// <summary>
    /// SKTH_Control.xaml 的交互逻辑
    /// </summary>
    public partial class TPZL_Control : UserControl, IObjsControl
    {
        public TPZL_Control(List<DGObject> objs)
        {
            InitializeComponent();
            Loaded += TPZL_Control_Loaded;
        }

        private void TPZL_Control_Loaded(object sender, RoutedEventArgs e)
        {
            lstvImage.ItemsSource = ImageInfo.getList();
        }
    }
    public class ImageInfo
    {
        public string FileName { get; set; }
        public string ImgName { get; set; }
        public static List<ImageInfo> getList()
        {
            List<ImageInfo> result = new List<ImageInfo>();
            result.Add(new ImageInfo() { FileName = @"D:\8-svn\0-LY\TS_YN_Client\Output\images\地形.png", ImgName = "地形.png" });
            result.Add(new ImageInfo() { FileName = @"D:\8-svn\0-LY\TS_YN_Client\Output\images\地形.png", ImgName = "地形.png" });
            result.Add(new ImageInfo() { FileName = @"D:\8-svn\0-LY\TS_YN_Client\Output\images\地形.png", ImgName = "地形.png" });
            return result;
        }
    }
}
