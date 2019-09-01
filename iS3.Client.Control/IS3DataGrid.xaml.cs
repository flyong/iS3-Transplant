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
using System.ComponentModel;
using System.Globalization;
using System.Collections;

using iS3.Core;
using System.Collections.ObjectModel;
using System.Threading;
using System.Reflection;
using iS3.Core.Client;
using iS3.Core.Model;

namespace iS3.Client.Controls
{
    public class ObjectValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return ObjectHelper.ObjectToString(value, true);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// Interaction logic for IS3DataGrid.xaml
    /// </summary>
    /// 
    public partial class IS3DataGrid : UserControl
    {
        public string domainName;
        public string objTypeName;
        public DGObjects objs;
        public List<DGObject> objList;
        public EventHandler<ObjSelectionChangedEvent> objSelectionChangedTrigger;
        public void SetContent(List<DGObject> _objList)
        {
            this.objList = _objList;
            if ((_objList == null) || ((_objList != null) && (_objList.Count == 0)))
            {
                DGObjectDataGrid.ItemsSource = null;
                return;
            }
            objs = _objList.FirstOrDefault().parent;
            lastObj = objs;
            domainName = objs.parent.name;
            objTypeName = objs.definition.Type;
            AddBtn.Content = "新增" + objs.definition.Name_Chs + "对象";
            DeleteBtn.Content = "删除" + objs.definition.Name_Chs + "对象";

            //获取对应属性数据
            Type objType = ObjectHelper.GetType(domainName, objTypeName);
            Type _t = typeof(ObjectHelper);
            MethodInfo mi = _t.GetMethod("Convert").MakeGenericMethod(objType);
            DGObjectDataGrid.ItemsSource = mi.Invoke(null, new object[] { objList }) as IEnumerable;
        }
        //public void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        //{
        //    if (sender != this)
        //    {

        //    }
        //}
        DGObjects lastObj;
        public async Task GetData(DGObjects objs)
        {
            lastObj = objs;
            domainName = objs.parent.name;
            objTypeName = objs.definition.Type;
            AddBtn.Content = "新增" + objs.definition.Type + "对象";
            DeleteBtn.Content = "删除" + objs.definition.Type + "对象";
            List<DGObject> objList = await RepositoryForClient.RetrieveObjs(objs);

            string domain = objs.parent.name;
            string objtype = objs.definition.Type;

            //获取对应属性数据
            Type objType = ObjectHelper.GetType(objs.parent.name, objs.definition.Type);
            Type _t = typeof(ObjectHelper);
            MethodInfo mi = _t.GetMethod("Convert").MakeGenericMethod(objType);
            DGObjectDataGrid.ItemsSource = mi.Invoke(null, new object[] { objList }) as IEnumerable;

        }

        protected int _maxColWith = 300;
        //protected ObjectValueConverter _objectConverter
        //    = new ObjectValueConverter();

        public IS3DataGrid()
        {
            InitializeComponent();
        }


        private void DGObjectDataGrid_AutoGeneratingColumn(object sender,
            DataGridAutoGeneratingColumnEventArgs e)
        {
            // "Graphics" and "Attributes" are used internally.
            try
            {
                if (e.PropertyName == "Graphics" ||
                    e.PropertyName == "Attributes" ||
                    e.PropertyName == "IsSelected" ||
                    e.PropertyName == "OBJECTID" ||
                    e.PropertyName == "SHAPE" ||
                    e.PropertyName == "Shape" ||
                    e.PropertyName == "SHAPE_Length" ||
                    e.PropertyName == "Shape_Length" ||
                    e.PropertyName == "SHAPE_Area" ||
                    e.PropertyName == "Shape_AreA" ||
                    e.PropertyName == "ID" ||
                    e.PropertyName == "parent" ||
                    e.PropertyName == "name"
                    )
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    DGObjectMeta _meta = objs.definition.Metas.FirstOrDefault(x => x.PropertyName == e.PropertyName);
                    string _name = null;
                    if (null != _meta)
                        _name = _meta.ChsName;
                    if (null != _name)
                        e.Column.Header = _name;
                    else
                        e.Cancel = true;

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



            //DataGridTextColumn tcol = e.Column as DataGridTextColumn;
            //if (tcol == null)
            //    return;

            //// Does the column data type contain the ICollection interface?
            //// If yes, we need the CollectionValueConverter to display data.
            //if (typeof(ICollection).IsAssignableFrom(e.PropertyType))
            //{
            //    Binding binding = tcol.Binding as Binding;
            //    binding.Converter = _objectConverter;
            //}
            //// Is the column data class type other than String?
            //// If yes, we need the ClassValueConverter to display data.
            //else if (e.PropertyType.IsClass && e.PropertyType.Name != "String")
            //{
            //    Binding binding = tcol.Binding as Binding;
            //    binding.Converter = _objectConverter;
            //}
        }

        private void DGObjectDataGrid_AutoGeneratedColumns(object sender,
            EventArgs e)
        {
            if (DGObjectDataGrid.Columns.Count == 0)
                return;

            try
            {
                DataGridColumn col =
                    DGObjectDataGrid.Columns.FirstOrDefault(
                    c => c.Header.ToString() == "ID");
                if (col != null)
                    col.DisplayIndex = 0;

                col = DGObjectDataGrid.Columns.FirstOrDefault(
                    c => c.Header.ToString() == "Name");
                if (col != null)
                    col.DisplayIndex = 1;

                col = DGObjectDataGrid.Columns.FirstOrDefault(
                    c => c.Header.ToString() == "FullName");
                if (col != null)
                    col.DisplayIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (DataGridColumn _iter in DGObjectDataGrid.Columns)
            {
                //_iter.MaxWidth = 300;
            }
        }
        DGObject _lastObj = null;
        protected IView _view;
        public IView view
        {
            get { return _view; }
        }

        private void DGObjectDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGObjectDataGrid.IsKeyboardFocusWithin == false)
                return;
            List<DGObject> addedObjs = new List<DGObject>();
            List<DGObject> removedObjs = new List<DGObject>();
            DGObject selectOne = DGObjectDataGrid.SelectedItem as DGObject;
            addedObjs.Add(selectOne);
            if (_lastObj != null)
            {
                removedObjs.Add(_lastObj);
            }
            if (objSelectionChangedTrigger != null)
            {
                Dictionary<string, List<DGObject>> addedObjsDict = null;
                Dictionary<string, List<DGObject>> removedObjsDict = null;
                if (addedObjs.Count > 0)
                {
                    addedObjsDict = new Dictionary<string, List<DGObject>>();
                    addedObjsDict[selectOne.parent.definition.Name] = addedObjs;
                }
                if (removedObjs.Count > 0)
                {
                    removedObjsDict = new Dictionary<string, List<DGObject>>();
                    removedObjsDict[_lastObj.parent.definition.Name] = removedObjs;
                }
                ObjSelectionChangedEvent args =
                    new ObjSelectionChangedEvent();
                args.addObjs = addedObjsDict;
                args.removeObjs = removedObjsDict;
                objSelectionChangedTrigger(this, args);
            }
            _lastObj = selectOne;
        }

        public void setCoord(string coord)
        {

        }

        private async void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((domainName == null) || (objTypeName==null))
                return;
            //判断是否有自定义的输入界面
            if (DllImport.domainExtension.ContainsKey(domainName))
            {
                Extensions extensions = DllImport.domainExtension[domainName];
                IEnumerable<ObjEditorWin> list = extensions.objEditorWins();
                if (list != null)
                {
                    ObjEditorWin win = list.Where(x => x.TargetObjType == objTypeName).FirstOrDefault();
                    if (win != null)
                    {
                        IObjEditorWin myPropertyWin = win.Func();
                        (myPropertyWin as Window).Title = objTypeName;
                        myPropertyWin.DGObjectHandler += DGObjectAddHandler;
                        (myPropertyWin as Window).Show();
                        return;
                    }
                }
            }
            CommonPropertyWin commonPropertyWin = new CommonPropertyWin(domainName, objTypeName);
            commonPropertyWin.Title = objTypeName;
            commonPropertyWin.DGObjectHandler += DGObjectAddHandler;
            commonPropertyWin.Show();
        }
        public async void DGObjectAddHandler(object sender, DGObject model)
        {
            await GetData(lastObj);
        }
        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DGObject obj = DGObjectDataGrid.SelectedItem as DGObject;
            try
            {
                int result = await RepositoryForClient.Delete(obj, domainName, objTypeName);
                if (result > 0)
                {
                    await GetData(lastObj);
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}