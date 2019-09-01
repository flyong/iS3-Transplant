using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core;
using iS3.Core.Client;
using iS3.Core.Model;

namespace RTM_Tool
{
    public class RiskIdentification : IToolPlugin
    {
        public string FuncName { get; set; }

        public bool CheckIfUsing { get; set; }

        public event EventHandler ToolFinishedEvent;

        public void Func(string Params)
        {

            //二维视图改变

            IMainFrame mainFrame = Globals.mainFrame;
            Project _prj = Globals.project;
            Domain _constructionDoamin2 = _prj.getDomain("Construction");
            DGObjects _gprfDGObjects2 = _constructionDoamin2.DGObjectsList.Where(x => x.definition.Type == "TFSI").FirstOrDefault();
            Globals.mainFrame.DGObjectsSelectionChangedListener(null, new DGObjectsSelectionChangedEvent()
            {
                newObjs = _gprfDGObjects2
            });

            //获取要添加图元的视图view
            IView2D _inputView = (mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
            List<string> dynamiclayerlist = new List<string>() { "RiskIdfy" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "施工进度");
            iS3Legned legeng_risk = new iS3Legned()
            {
                legndTitle = "风险标识",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){label="风险点",symbolType=SymbolType.Icon,refPath="riskidfy_alert.png"}
                }
            };
            _inputView.holder.setlegend(legeng_risk);
            _inputView.holder.setLegendShow(true);

            _inputView = (mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
            dynamiclayerlist = new List<string>() { "RiskIdfy" };
            _inputView.Opendynamiclayers(dynamiclayerlist, "施工进度");
            legeng_risk = new iS3Legned()
            {
                legndTitle = "风险标识",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){label="风险点",symbolType=SymbolType.Icon,refPath="riskidfy_alert.png"}
                }
            };
            _inputView.holder.setlegend(legeng_risk);
            _inputView.holder.setLegendShow(true);


        }
    }
}
