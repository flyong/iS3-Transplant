using iS3.Core.Client.ViewModel;
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
using iS3.Core.Model;

namespace iS3.Construction.Client
{
    /// <summary>
    /// TPZL_Show.xaml 的交互逻辑
    /// </summary>
    public partial class TPZL_Show : UserControl, IDGObjectView
    {
        public TPZL_Show()
        {
            InitializeComponent();
        }

        public UserControl ChartView()
        {
            return this;
        }

        public EngineeringMap SetIt(DGObject model)
        {
            return null;
        }

        public Task SetObjContent(DGObject model)
        {
            return null;
        }
    }
}
