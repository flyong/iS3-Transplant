using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Client;
using iS3.Core.Client.ViewModel;
using iS3.Geology.Client.Control;

namespace iS3.Geology.Client
{
    public class Entry : Extensions
    {
        public override string domain { get { return "Geology"; } }
        public override string name() { return "Geology Tool"; }
        public override IEnumerable<DGObjectViewConfig> treeItems()
        {

            return dGObjectViewConfigs;
        }
        List<DGObjectViewConfig> dGObjectViewConfigs;
        Dictionary<string, List<MenuBase>> menuDicts;
        public IDGObjectView ShowBoreholeView()
        {
            return new BoreholeView();
        }
        public override async Task init()
        {
            //
            dGObjectViewConfigs = new List<DGObjectViewConfig>();
            dGObjectViewConfigs.Add(new DGObjectViewConfig("Borehole", ShowBoreholeView));

            //
            menuDicts = new Dictionary<string, List<MenuBase>>();
            menuDicts["Common"] = new List<MenuBase>()
            {
                new MenuBase(){TargetObjType="Borehole",MethodType=OperationType.CreateObjs,Desc="新增钻孔对象组",Tip="新增钻孔对象组"},
            };
            menuDicts["Borehole"] = new List<MenuBase>()
            {
                new MenuBase(){TargetObjType="Borehole",MethodType=OperationType.DeleteObjs,Desc="删除钻孔对象组",Tip="删除钻孔对象组"},
                new MenuBase(){TargetObjType="Borehole",MethodType=OperationType.UpdateObjs,Desc="编辑钻孔对象组",Tip="编辑钻孔对象组"}
            };
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
    }
}
