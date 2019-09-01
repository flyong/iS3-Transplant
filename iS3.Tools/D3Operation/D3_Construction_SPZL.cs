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
    public class D3_Construction_SPZL : IToolPlugin
    {
        public static bool state = true;
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {
            //初始化三维事件
            U3DViewModel model = Globals.mainFrame.views.Where(x => x.baseType == ViewBaseType.D3).FirstOrDefault() as U3DViewModel;
            SetPointEvent _event = new SetPointEvent(UnityEventType.SetPointEvent);
            _event.Domain = "Construction";
            _event.ObjType = "SPZL";
            _event.state = state;
            state = !state;
            //获取数据
            Project _prj = Globals.project;
            Domain _constructionDoamin2 = _prj.getDomain("Construction");
            DGObjects _gprfDGObjects2 = _constructionDoamin2.DGObjectsList.Where(x => x.definition.Type == "SPZL").FirstOrDefault();
            foreach (DGObject obj in _gprfDGObjects2.objContainer)
            {
                SPZL spzl = JsonConvert.DeserializeObject<SPZL>(JsonConvert.SerializeObject(obj));
                if ((spzl.SPZL_ZHQJ == null) || (spzl.SPZL_ZHQJ.Length == 0)) { continue; }
                _event.TunnelPointList.Add(spzl.SPZL_ZHQJ.Split('-')[0] + "#" + spzl.ID.ToString());
                _event.ImageList.Add("Panel_Video");
            }
            model.ExcuteCommand(JsonConvert.SerializeObject(_event));
            //通知对象组改变事件
            Globals.mainFrame.DGObjectsSelectionChangedListener(this, new DGObjectsSelectionChangedEvent() { newObjs = _gprfDGObjects2 });

            //二维视图改变

            IMainFrame mainFrame = Globals.mainFrame;
            //获取要添加图元的视图view
            IView2D _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
            List<string> dynamiclayerlist = new List<string>() { "SPZL" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "施工进度");
            iS3Legned legeng_SPZL = new iS3Legned()
            {
                legndTitle = "视频资料图例",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){label="视频资料",symbolType=SymbolType.Icon,refPath="videoicon.png"}
                }
            };
            _inputView.holder.setlegend(legeng_SPZL);
            _inputView.holder.setLegendShow(true);

            _inputView = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
            dynamiclayerlist = new List<string>() { "SPZL" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "施工进度");
            legeng_SPZL = new iS3Legned()
            {
                legndTitle = "视频资料图例",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){label="视频资料",symbolType=SymbolType.Icon,refPath="videoicon.png"}
                }
            };
            _inputView.holder.setlegend(legeng_SPZL);
            _inputView.holder.setLegendShow(true);
        }
    }
}
