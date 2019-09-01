using iS3.Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using iS3.Unity.EXE;
using Newtonsoft.Json;
using iS3UnityLib.Model.Event;
using iS3.Core.Model;
using iS3.Construction.Model;

namespace D3Operation
{
    //视频资料
    public class D3_Structure_MILI : IToolPlugin
    {
        public static bool state = true;
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {

            //获取数据
            Project _prj = Globals.project;
            Domain _constructionDoamin2 = _prj.getDomain("Structure");
            DGObjects _gprfDGObjects2 = _constructionDoamin2.DGObjectsList.Where(x => x.definition.Type == "MILI").FirstOrDefault();

            //通知对象组改变事件
            Globals.mainFrame.DGObjectsSelectionChangedListener(this, new DGObjectsSelectionChangedEvent() { newObjs = _gprfDGObjects2 });

            //二维视图改变

            IMainFrame mainFrame = Globals.mainFrame;
            //获取要添加图元的视图view
            IView2D _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
            List<string> dynamiclayerlist = new List<string>() { "MILI" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "衬砌结构");
            iS3Legned legeng_SPZL = new iS3Legned()
            {
                legndTitle = "衬砌设计类型图例",
                iS3SymbolList = new List<iS3Symbol>()
                {
                    new iS3Symbol(){colorName="Purple",label="三级",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="Cyan",label="四级",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="Red",label="五级",symbolType=SymbolType.Rectangle}
                }
            };
            _inputView.holder.setlegend(legeng_SPZL);
            _inputView.holder.setLegendShow(true);

           _inputView = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
             dynamiclayerlist = new List<string>() { "MILI" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "衬砌结构");
             legeng_SPZL = new iS3Legned()
            {
                legndTitle = "衬砌设计类型图例",
                iS3SymbolList = new List<iS3Symbol>()
                {
                    new iS3Symbol(){colorName="Purple",label="三级",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="Cyan",label="四级",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="Red",label="五级",symbolType=SymbolType.Rectangle}
                }
            };
            _inputView.holder.setlegend(legeng_SPZL);
            _inputView.holder.setLegendShow(true);
        }
       
    }
}
