using iS3.Core.Client;
using iS3.Core.Client.Service;
using iS3.Core.Client.ViewModel;
using iS3.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// DGObjectsView.xaml 的交互逻辑
    /// </summary>
    public partial class DGObjectsView : UserControl,IView
    {
        public DGObjectsView()
        {
            InitializeComponent();
        }

        public EventHandler<DGObjectsSelectionChangedEvent> DGObjectsSelectionChangedHandler { get; set; }
        public EventHandler<ObjSelectionChangedEvent> ObjSelectionChangedHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string name => throw new NotImplementedException();

        public ViewType type => throw new NotImplementedException();

        public ViewBaseType baseType => throw new NotImplementedException();

        public void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {
            Set(e.newObjs);
        }
        public async Task Set(DGObjects objs)
        {
            List<DGObject> dGObjects = await RepositoryForClient.RetrieveObjs(objs);
            string domain = objs.parent.name;
            string objtype = objs.definition.Type;

            //获取对应属性数据
            iS3Property property = new iS3Property();
            Type objType = iS3Property.GetType(objs.parent.name, objs.definition.Type);
            Type _t = property.GetType();
            MethodInfo mi = _t.GetMethod("Convert").MakeGenericMethod(objType);
            DGObjectsHolder.ItemsSource = mi.Invoke(property, new object[] { dGObjects }) as IEnumerable;
        }
            
        public Task Init()
        {
            return null;
        }

        private void DGObjectsHolder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DGObject obj = DGObjectsHolder.SelectedItem as DGObject;
            SetDGObjectShow(obj);


        }
        public async Task SetDGObjectShow(DGObject _obj)
        {
            DGObject obj = await RepositoryForClient.RetrieveObj(_obj);
            string domainName = _obj.parent.parent.name;
            string objType = _obj.parent.definition.Type;
            Extensions extensions = DllImport.domainExtension[domainName];
            DGObjectViewConfig dw = extensions.treeItems().Where(x => x.objType == objType).FirstOrDefault();
            IDGObjectView view = dw.func();
            await view.SetObjContent(obj);
            CommonWindow.GetInstance(view.ChartView()).Show();
        }

        public void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        {
            
        }

        public void load()
        {
            throw new NotImplementedException();
        }

        public Task initialzeView()
        {
            throw new NotImplementedException();
        }

        public void onClose()
        {
           
        }

        public void highlightObject(DGObject obj, bool on = true)
        {
            throw new NotImplementedException();
        }

        public void highlightObjects(IEnumerable<DGObject> objs, bool on = true)
        {
            throw new NotImplementedException();
        }

        public void highlightObjects(IEnumerable<DGObject> objs, string layerID, bool on = true)
        {
            throw new NotImplementedException();
        }

        public void highlightAll(bool on = true)
        {
            throw new NotImplementedException();
        }

        public int syncObjects()
        {
            throw new NotImplementedException();
        }
    }
}
