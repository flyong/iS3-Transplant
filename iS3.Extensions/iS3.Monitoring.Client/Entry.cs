using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Client;
using iS3.Core.Client.ViewModel;
//using iS3.Monitoring.Client.Control;

namespace iS3.Monitoring.Client
{
    public class Entry : Extensions
    {
        public override string domain { get { return "Monitoring"; } }
        public override string name() { return "Monitoring Tool"; }
        public override IEnumerable<DGObjectViewConfig> treeItems()
        {

            return dGObjectViewConfigs;
        }
        List<DGObjectViewConfig> dGObjectViewConfigs;
        Dictionary<string, List<MenuBase>> menuDicts;

        //public IDGObjectView ShowBoreholeView()
        //{
        //    return new MonPointView();
        //}
        public override async Task init()
        {
            dGObjectViewConfigs = new List<DGObjectViewConfig>();
            //dGObjectViewConfigs.Add(new DGObjectViewConfig("MonPoint", ShowBoreholeView));
            //
            menuDicts = new Dictionary<string, List<MenuBase>>();
            menuDicts["Common"] = new List<MenuBase>()
            {
                new MenuBase(){TargetObjType="MonProject",MethodType=OperationType.Create,Desc="新增监测项目",Tip="新增监测项目"},
                new MenuBase(){TargetObjType="MonProject",MethodType=OperationType.CreateObjs,Desc="新增监测项目组",Tip="新增监测项目组"},
            };
            menuDicts["MonGroup"] = new List<MenuBase>()
            {
                new MenuBase(){TargetObjType="MonGroup",MethodType=OperationType.Delete,Desc="删除监测测组",Tip="删除监测测组"},
                new MenuBase(){TargetObjType="MonGroup",MethodType=OperationType.Update,Desc="编辑监测测组",Tip="编辑监测测组"},
            };
            menuDicts["MonProject"] = new List<MenuBase>()
            {
                new MenuBase(){TargetObjType="MonProject",MethodType=OperationType.Delete,Desc="删除监测项目",Tip="删除监测项目"},
                new MenuBase(){TargetObjType="MonProject",MethodType=OperationType.Update,Desc="编辑监测项目",Tip="编辑监测项目"},
                new MenuBase(){TargetObjType="MonGroup",MethodType=OperationType.Create,Desc="新增监测测组",Tip="新增监测测组"},
            };
            //
            objEditorDefDict = new Dictionary<string, ObjEditorDef>();
            objEditorDefDict["MonPoint"] = new ObjEditorDef()
            {
                PropertyNameList = new List<string>() { "Name", "MonPointType", "XCoordinate", "YCoordinate", "ZCoordinate", "SensorName", "IniValue", "STime", "Remark" }
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
    }
}