
using iS3.Core.Client.ViewModel;
using iS3.Core.Model;
using iS3.Monitoring.Model;
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

namespace iS3.Monitoring.Client.Control
{
    /// <summary>
    /// MonPointView.xaml 的交互逻辑
    /// </summary>
    public partial class MonPointView : UserControl, IDGObjectView
    {
        MonPoint monPoint;
        public MonPointView()
        {
            InitializeComponent();
            Loaded += MonPointView_Loaded;
        }

        public UserControl ChartView()
        {
            return this;
        }

        public EngineeringMap SetIt(DGObject model)
        {
            this.monPoint = model as MonPoint;
            return null;
        }

        public Task SetObjContent(DGObject model)
        {
            this.monPoint = model as MonPoint;
            return null;
        }

        private void MonPointView_Loaded(object sender, RoutedEventArgs e)
        {
            List<double> data = new List<double>();
            foreach (MonData md in monPoint.monDatas)
            {
                data.Add(double.Parse( md.Value.ToString()));
            }
            series.ItemsSource = data;
        }
    }
}
