using iS3.Client.Controls;
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
using System.Collections.ObjectModel;

namespace iS3.Client
{
    /// <summary>
    /// DomainTreeView.xaml 的交互逻辑
    /// </summary>
    public partial class DomainTreeView : UserControl, IView
    {
        public ViewType type { get; }
        public ViewBaseType baseType { get; }
        #region IView Inteface
        //对象组选择触发
        public EventHandler<DGObjectsSelectionChangedEvent> DGObjectsSelectionChangedHandler { get; set; }

        //接收下面每个TreePanel的对象组选择事件，并发送到主框架
        //
        public void DGObjectsSelectionChangedListener(object sender, DGObjectsSelectionChangedEvent e)
        {
            if (DGObjectsSelectionChangedHandler != null)
            {
                DGObjectsSelectionChangedHandler(sender, e);
            }
        }

        //初始化资源树
        //根据domain获取对应的资源树列表
        //每个domain的资源树显示在各自的TabItem
        public async Task Init()
        {
            foreach (Domain domain in Globals.project.domains)
            {
                //新建TreePanel
                TreePanel treePanel = new TreePanel(domain.name);
                treePanel.DGObjectsSelectionChangedHandler += DGObjectsSelectionChangedListener;
                //添加TabItem
                DomainTreeHolder.Items.Add(
                    new TabItem()
                    {
                        Header = domain.name,
                        Content = treePanel
                    });

                //初始化TreePanel
                await (treePanel as IView).Init();
            }
        }

        #endregion

        public DomainTreeView()
        {
            InitializeComponent();
        }

        # region Useless
        //对象选择触发
        //None
        public EventHandler<ObjSelectionChangedEvent> ObjSelectionChangedHandler { get; set; }

        public string name => throw new NotImplementedException();

        public void ObjSelectionChangedListener(object sender, ObjSelectionChangedEvent e)
        {
            throw new NotImplementedException();
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
        #endregion
    }
}
