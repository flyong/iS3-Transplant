using iS3.Core.Client;
using iS3.Core.Client.Service;
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
using System.Windows.Shapes;

namespace iS3.Client.Control
{
    /// <summary>
    /// DataSourceWin.xaml 的交互逻辑
    /// </summary>
    public partial class DataSourceWin : Window
    {
        List<DataSourceType> dataSourceTypes;
        DataSourceInfo _dataSourceInfo;
        public EventHandler<DataSourceInfo> DataSourceInfoEventHandler;
        public DataSourceWin()
        {
            InitializeComponent();
            Loaded += DataSourceWin_Loaded;
        }
        public void SetModel(DataSourceInfo dataSourceInfo)
        {
            _dataSourceInfo = DeepCopy<DataSourceInfo>.CLone(dataSourceInfo);
            Holder.DataContext = _dataSourceInfo;
        }
        private async void DataSourceWin_Loaded(object sender, RoutedEventArgs e)
        {
            dataSourceTypes = await CommonRepo.GetDataSourceTypes();
            sourceTypeCB.ItemsSource = dataSourceTypes;
        }

        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            _dataSourceInfo.DSType = sourceTypeCB.SelectedIndex + 1;
            DataSourceInfo model = await CommonRepo.PostDataSourceInfo(_dataSourceInfo);
            if (DataSourceInfoEventHandler != null)
            {
                DataSourceInfoEventHandler(this, model);
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
