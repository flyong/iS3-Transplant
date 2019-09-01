using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Client;
using iS3.Core.Client.ViewModel;

namespace iS3.Environment.Client
{
    public class Entry : Extensions
    {
        public override string domain { get { return "Environment"; } }
        public override string name() { return "Environment Tool"; }
        public override IEnumerable<DGObjectViewConfig> treeItems()
        {

            return dGObjectViewConfigs;
        }
        List<DGObjectViewConfig> dGObjectViewConfigs;
        Dictionary<string, List<MenuBase>> menuDicts;

        public override async Task init()
        {
            dGObjectViewConfigs = new List<DGObjectViewConfig>();
            
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