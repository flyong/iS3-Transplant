using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Client;
using iS3.Core.Client.ViewModel;
//using iS3.Draw;
using System.Windows;
using iS3.Construction.Client.Wins;
using iS3.Core.Model;

namespace iS3.Construction.Client
{
    public class Entry : Extensions
    {
        public override string domain { get { return "Construction"; } }
        public override string name() { return "Construction Tool"; }
        public override IEnumerable<DGObjectViewConfig> treeItems()
        {

            return dGObjectViewConfigs;
        }
        List<DGObjectViewConfig> dGObjectViewConfigs;
        Dictionary<string, List<MenuBase>> menuDicts;

        public IObjEditorWin getWin_SKTH()
        {
            return new SKTH_Win();
        }
        public IObjsControl getControl_SKTH(List<DGObject> objs)
        {
            return new SKTH_Control(objs);
        }
        public IObjsControl getControl_ACHE(List<DGObject> objs)
        {
            return new ACHE_Control(objs);
        }
        public IObjsControl getControl_ACHE_left(List<DGObject> objs)
        {
            return new ACHE_Control_left(objs);
        }
        public IDGObjectView get_TPZL_Show()
        {
            return new TPZL_Show();
        }
        public IDGObjectView get_SPZL_Show()
        {
            return new SPZL_Show();
        }
        public IDGObjectView get_ZZM_Show()
        {
            return new ZZM_Show();
        }
        public override async Task init()
        {
            dGObjectViewConfigs = new List<DGObjectViewConfig>();
            dGObjectViewConfigs.Add(new DGObjectViewConfig("TPZL", get_TPZL_Show));
            dGObjectViewConfigs.Add(new DGObjectViewConfig("SPZL", get_SPZL_Show));
            dGObjectViewConfigs.Add(new DGObjectViewConfig("ACHE", get_ZZM_Show));

            winList = new List<ObjEditorWin>();
            winList.Add(new ObjEditorWin(getWin_SKTH, "SKTH"));

            //定义对象组显示样式
            objsControlList = new List<ObjsControl>();
           
            objsControlList.Add(new ObjsControl(getControl_ACHE, "ACHE"));
            objsControlList.Add(new ObjsControl(getControl_ACHE_left, "ACHE"));

            //

            Globals.mainFrame.viewLoaded += MainFrame_projectLoaded;
        }

        //主程序加载完成之后执行
        private void MainFrame_projectLoaded(object sender, EventArgs e)
        {
            Globals.mainFrame.viewLoaded -= MainFrame_projectLoaded;
        }
        public override List<MenuBase> menuList(string objType)
        {
            if (menuDicts.ContainsKey(objType))
            {
                return menuDicts[objType];
            }
            else
                return null;
        }
        Dictionary<string, ObjEditorDef> objEditorDefDict;
        //public override ObjEditorDef objEditorDef(string objType)
        //{
        //    if (objEditorDefDict.ContainsKey(objType))
        //    {
        //        return objEditorDefDict[objType];
        //    }
        //    else
        //        return null;
        //}
        List<ObjEditorWin> winList;
        public override IEnumerable<ObjEditorWin> objEditorWins()
        {
            return winList;
        }
        List<ObjsControl> objsControlList;

        //对象组的显示控件
        public override IEnumerable<ObjsControl> objsControls()
        {
            return objsControlList;
        }
    }
}