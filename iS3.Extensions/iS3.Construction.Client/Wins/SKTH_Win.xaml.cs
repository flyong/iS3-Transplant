using iS3.Core.Client;
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

namespace iS3.Construction.Client.Wins
{
    /// <summary>
    /// SKTH_Win.xaml 的交互逻辑
    /// </summary>
    public partial class SKTH_Win : Window,IObjEditorWin
    {
        public SKTH_Win()
        {
            InitializeComponent();
        }

        public EventHandler<DGObject> DGObjectHandler
        {
            get; set;
        }
    }
}
