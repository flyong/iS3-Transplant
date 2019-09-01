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
using iS3.Core;
using iS3.Core.Client;
using iS3.Core.Client.ViewModel;
using iS3.Core.Model;
using iS3.Unity.Webplayer;

namespace iS3.Structure.Client.Control
{
    /// <summary>
    /// StructureView.xaml 的交互逻辑
    /// </summary>
    public partial class StructureView : UserControl, IDGObjectView
    {
        public StructureView()
        {
            InitializeComponent();
        }

        public UserControl ChartView()
        {
            return this;
        }

        public EngineeringMap SetIt(DGObject model)
        {
            //try
            //{
            //    init();
            //}
            //catch (Exception ex)
            //{

            //}
            return new Core.Model.EngineeringMap()
            {
                LocalTileFileNameStr = "CONC_"+model.ID.ToString()+".unity3d",
            };

        }

        public async Task  SetObjContent(DGObject model)
        {
            bool result= await initAnsy();
        }
        private void init()
        {
            try
            {
                U3DView u3dView = new U3DView(Globals.project, new Core.Model.EngineeringMap()
                {
                    LocalTileFileNameStr = "out1.unity3d",
                });
                layout.Children.Clear();
                layout.Children.Add(u3dView);
                IView view = u3dView.view;
                view.initialzeView();
            }
            catch (Exception ex)
            {

            }
        }
        private async Task<bool> initAnsy()
        {
            try
            {
                U3DView u3dView = new U3DView(Globals.project, new Core.Model.EngineeringMap()
                {
                    LocalTileFileNameStr = "out1.unity3d",
                });
                layout.Children.Clear();
                layout.Children.Add(u3dView);
                IView view = u3dView.view;
                await view.initialzeView();
            }
            catch (Exception ex)
            {

            }

            return true;
        }
    }
}
