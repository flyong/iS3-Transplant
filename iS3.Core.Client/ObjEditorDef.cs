using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace iS3.Core.Client
{
    public class ObjEditorDef
    {
        public List<string> PropertyNameList;
    }
    public interface IObjEditorWin
    {
        EventHandler<DGObject> DGObjectHandler { get; set; }
    }
    public class ObjEditorWin
    {
        public delegate IObjEditorWin DelegateFunc();
        public DelegateFunc Func;
        public string TargetObjType { get;  }
        public ObjEditorWin(DelegateFunc func,string targetObjType)
        {
            Func = func;
            TargetObjType = targetObjType;
        }
    }

    public interface IObjsControl
    {
    }
    //对象组显示控件
    public class ObjsControl
    {
        public delegate IObjsControl DelegateFunc(List<DGObject> objs);
        public DelegateFunc Func;
        public string TargetObjType { get; }
        public ObjsControl(DelegateFunc func, string targetObjType)
        {
            Func = func;
            TargetObjType = targetObjType;
        }
    }
}
