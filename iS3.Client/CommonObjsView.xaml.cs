using iS3.Client.Controls;
using iS3.Core.Client;
using iS3.Core.Client.ViewModel;
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

namespace iS3.Client
{
    /// <summary>
    /// CommonObjsView.xaml 的交互逻辑
    /// </summary>
    public partial class CommonObjsView : UserControl, IViewHolder
    {
        public string domainName;
        public string objTypeName;
        public ObjsViewGeneral ObjsViewGeneral;
        public int viewholderindex;
        public CommonObjsView()
        {
            InitializeComponent();
            ObjsViewGeneral = new ObjsViewGeneral();
            ViewHolder.Children.Add(ObjsViewGeneral);
            viewholderindex = 0;
        }
        #region Interface
        public EventHandler<DGObjectsSelectionChangedEvent> DGObjectsSelectionChangedHandler;
        public EventHandler<ObjSelectionChangedEvent> ObjectSelectionChangedHandler;
        public IView view => throw new NotImplementedException();
        public void settitle(string st) { }
        public iS3Legned legend { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void setruler(List<string> m1, List<string> m2, List<string> sc, string rulername)
        {

        }
        public void setCoord(string coord)
        {

        }
        public void setruler(double x, double y)
        {

        }
        #endregion
        public async void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {
            try
            {
                if (sender != this)
                {
                    List<DGObject> objList = await GetData(e.newObjs);
                    ShowDGObjectsView(objList);
                }
            }
            catch (Exception ex)
            {

            }
        }

        DGObjects lastObj;

        //获取点击对象组对应的对象列表
        //
        public async Task<List<DGObject>> GetData(DGObjects objs)
        {
            lastObj = objs;
            domainName = objs.parent.name;
            objTypeName = objs.definition.Type;
            List<DGObject> objList = await RepositoryForClient.RetrieveObjs(objs);
            return objList;

        }

        public void ShowDGObjectsView(List<DGObject> objList)
        {
            try
            {
                //对象组自定义控件
                Extensions extensions = DllImport.domainExtension[domainName];
                IEnumerable<ObjsControl> list = extensions.objsControls();
                if (list != null)
                {
                    List<ObjsControl> control = list.Where(x => x.TargetObjType == objTypeName).ToList();

                    if ((control.Count != 0) && (control[viewholderindex] != null))
                    {
                        ObjsViewGeneral.other.Children.Clear();
                        ObjsViewGeneral.other.Children.Add(control[viewholderindex].Func(objList) as UserControl);
                        ObjsViewGeneral.other.Visibility = Visibility.Visible;
                        ObjsViewGeneral.MyIS3DataGrid.Visibility = Visibility.Collapsed;
                        return;
                    }
                }
                ObjsViewGeneral.other.Visibility = Visibility.Collapsed;
                ObjsViewGeneral.MyIS3DataGrid.Visibility = Visibility.Visible;
                {
                    ViewHolder.Children.Clear();
                    ObjsViewGeneral.MyIS3DataGrid.SetContent(objList);
                    //DGObjectsSelectionChangedHandler += iS3DataGrid.DGObjectsSelectionChangedListener;
                    //对象列表查看

                    ViewHolder.Children.Add(ObjsViewGeneral);
                }
            }
            catch (Exception ex)
            {

            }

        }
        public void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        {
            if (ObjectSelectionChangedHandler != null)
            {
                ObjectSelectionChangedHandler(sender, e);
            }
        }

        public void setLegendShow(bool state)
        {
            throw new NotImplementedException();
        }

        public void addLegend(iS3Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public void removeLegend(string labelName)
        {
            throw new NotImplementedException();
        }

        public void clearLegend()
        {
            throw new NotImplementedException();
        }

        public void setlegend(iS3Legned legend)
        {
            throw new NotImplementedException();
        }
    }
}
