using iS3.Core.Client;
using iS3.Core.Client.Service;
using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace iS3.Client.Controls
{
    /// <summary>
    /// TreePanel.xaml 的交互逻辑
    /// </summary>
    public partial class TreePanel : UserControl, IView
    {
        #region params
        //资源树绑定数据源
        //实现ObservableCollection接口，列表更新与前台同步
        ObservableCollection<TreeDefinition> _treeDefinitions;

        //TreePanel所属Domain
        string _domain;
        #endregion
        #region IView Inteface
        public EventHandler<DGObjectsSelectionChangedEvent> DGObjectsSelectionChangedHandler { get; set; }
        public EventHandler<ObjSelectionChangedEvent> ObjSelectionChangedHandler { get; set; }

        public string name => throw new NotImplementedException();

        public ViewType type => throw new NotImplementedException();

        public ViewBaseType baseType => throw new NotImplementedException();

        public void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {

        }
        public async Task Init()
        {
            //获取domain对应的资源树
            List<TreeDefinition> treeList = await CommonRepo.GetProjectTree(Globals.project.projectID, _domain);
            _treeDefinitions = new ObservableCollection<TreeDefinition>(treeList);
            DomainTreeView.ItemsSource = _treeDefinitions;
        }

        public void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        {

        }
        #endregion
        public TreePanel(string domain)
        {
            InitializeComponent();
            _domain = domain;
        }

        #region 树形控件事件触发

        //资源树左击事件
        private void DomainTreeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //获取点击树节点绑定的TreeDefinition
                TreeDefinition treeDefinition = DomainTreeView.SelectedItem as TreeDefinition;
                if (treeDefinition == null) return;

                //获取点击对象的DGObjects实例
                DGObjects refObjs = Globals.project.getDomain(treeDefinition.Domain).GetDGObjects(treeDefinition.RefObjID);
                if (refObjs == null) return;
                //根据点击的树，添加对应的Filter（临时）
                refObjs.definition.Filter = treeDefinition.Filter;

                //传递对象组选择事件到上一级
                if (DGObjectsSelectionChangedHandler != null)
                {
                    DGObjectsSelectionChangedHandler(this, new DGObjectsSelectionChangedEvent()
                    {
                        newObjs = refObjs,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 资源树右键事件，
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DomainTreeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem != null)
            {
                //点击了树节点
                treeViewItem.Focus();
                e.Handled = true;
                BindMenu(treeViewItem);
            }
            else
            {
                //点击了空白处
                BindMenu(null);
            }

        }
        //找到点击的TreeViewItem
        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }
        #endregion
        #region 右键菜单
        private void BindMenu(TreeViewItem tv)
        {
            ctmsMenu.Items.Clear();
            if (tv == null)
            {
                //点击空白处，添加Common对应的右键菜单
                DomainTreeView.ContextMenu = ctmsMenu;
                AddMenu("Common");
            }
            else
            {
                //点击树形控件节点，根据对象类型获取对应的右键菜单
                TreeDefinition tree = tv.DataContext as TreeDefinition;
                string ObjType = Globals.project.getDomain(_domain).GetObjectsDefinition(tree.RefObjID).Type;
                AddMenu(ObjType);
            }
        }
        //根据对象组名称添加右键菜单内容
        //MonProject节点：编辑MonProject（Update），删除MonProject(Delete)，新建MonGroup(Create)；
        //Common节点：用于点击空位置显示的右键菜单，新建MonProject组（CreateObjs），新建MonProject（Create）
        private void AddMenu(string key)
        {
            if (DllImport.domainExtension.ContainsKey(_domain))
            {
                Extensions extensions = DllImport.domainExtension[_domain];
                List<MenuBase> list = extensions.menuList(key);
                if (list == null) return;
                foreach (MenuBase menu in list)
                {
                    MenuItem menuItem = new MenuItem() { Header = menu.Desc };   //显示内容
                    menuItem.Tag = key;                            //
                    menuItem.DataContext = menu;
                    menuItem.Click += new RoutedEventHandler(AddDGObject_S);
                    ctmsMenu.Items.Add(menuItem);
                }
            }
        }

        //选择右键菜单，触发相应的事件;
        //--------------
        //既是对象又是对象组，点击Create事件，弹出对应ObjType的属性设置界面，填写保存;
        //将对象保存到对应数据库，将该节点保存到Treedefinition，Objectdefinition直接指向类型记录;
        //保存完毕，返回Tree信息和Objdef信息，更新到界面树，更新到后台对象组列表
        //---------------------
        //单独是对象组，点击CreateObj事件，弹出通用的tree节点属性设置界面，点击保存，将该节点保存到Treedefinition，Objectdefinition新建一条记录；
        //保存完毕，返回Tree信息和ObjDef信息，更新到界面树，更新到后台对象组列表
        public void AddDGObject_S(object sender, RoutedEventArgs e)
        {
            menuItem = sender as MenuItem;
            List<PropertyDef> propertyDefs = new List<PropertyDef>();
            menuBase = ((menuItem.DataContext) as MenuBase);
            if (menuBase.MethodType == OperationType.Create)
            {
                commonPropertyWin = new CommonPropertyWin(_domain, menuBase.TargetObjType);
                commonPropertyWin.Title = ((menuItem.DataContext) as MenuBase).Desc;
                commonPropertyWin.DGObjectHandler += DGObjectListener;
                commonPropertyWin.Show();
            }
            if (menuBase.MethodType == OperationType.CreateObjs)
            {
                dGObjectsPropertyWin = new DGObjectsPropertyWin();
                dGObjectsPropertyWin.domain = _domain;
                dGObjectsPropertyWin.DGObjectsHandler += DGObjectsListener;
                dGObjectsPropertyWin.Show();
            }
        }
        #endregion
        #region 返回事件处理 

        //添加对象组事件处理
        public async void DGObjectsListener(object sender, DGObjects objs)
        {

            dGObjectsPropertyWin.DGObjectsHandler -= DGObjectsListener;
            dGObjectsPropertyWin.Close();
        }
        //添加对象事件处理
        //例如MonProject、MonGroup之类，
        //添加Tree，添加Obj
        //返回tree，返回Obj，更新
        public async void DGObjectListener(object sender, DGObject model)
        {
            if (menuItem.Tag.ToString() == "Common")
            {
                TreeDefinition def = await CommonRepo.AddProjectTree(Globals.project.projectID, _domain, menuBase.TargetObjType, model.ID, 0);
                _treeDefinitions.Add(def);
            }
            else
            {
                TreeDefinition item = DomainTreeView.SelectedItem as TreeDefinition;
                TreeDefinition def = await CommonRepo.AddProjectTree(Globals.project.projectID, _domain, menuBase.TargetObjType, model.ID, item.ID);
                if (item.Chillds == null) item.Chillds = new ObservableCollection<TreeDefinition>();
                item.Chillds.Add(def);
            }
            Domain domain = Globals.project.getDomain(_domain);
            domain.objectsDefinitions = await CommonRepo.GetObjectsDefinition(Globals.project.projectID, domain.name);
            domain.DGObjectsList = new List<DGObjects>();
            foreach (ObjectsDefinition definition in domain.objectsDefinitions)
            {
                domain.DGObjectsList.Add(new DGObjects() { parent = domain, definition = definition, });
            }
            commonPropertyWin.DGObjectHandler -= DGObjectListener;
            commonPropertyWin.Close();
        }

        public void load()
        {
            throw new NotImplementedException();
        }

        public async Task initialzeView()
        {
            //获取domain对应的资源树
            List<TreeDefinition> treeList = await CommonRepo.GetProjectTree(Globals.project.projectID, _domain);
            if (treeList == null) return;
            _treeDefinitions = new ObservableCollection<TreeDefinition>(treeList);
            DomainTreeView.ItemsSource = _treeDefinitions;
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
        #endregion
        List<string> ContextMenuList;
        CommonPropertyWin commonPropertyWin;
        DGObjectsPropertyWin dGObjectsPropertyWin;
        MenuBase menuBase;
        MenuItem menuItem;
    }

}
