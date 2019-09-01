using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Client;
using iS3.Core.Client.ViewModel;
using System.Windows;

namespace RTM_Tool
{
    public class Entry : Tools
    {
        public override string domain { get { return "RTM_Tool"; } }
        public override string name() { return "RTM_Tool"; }
        public override async Task init()
        {
            Globals.mainFrame.viewLoaded += MainFrame_projectLoaded;
        }

        //主程序加载完成之后执行
        private void MainFrame_projectLoaded(object sender, EventArgs e)
        {

            iS3Legned legeng_ACHE = new iS3Legned()
            {
                legndTitle = "施工进度图例",
                iS3SymbolList = new List<iS3Symbol>(){
                    new iS3Symbol(){colorName="Yellow",label="初衬",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="GreenYellow",label="二衬",symbolType=SymbolType.Rectangle},
                    new iS3Symbol(){colorName="Khaki",label="仰拱",symbolType=SymbolType.Rectangle},
                     new iS3Symbol(){label="掌子面",symbolType=SymbolType.Icon,refPath="redflag.png" }
                     //new iS3Symbol(){label="图片",symbolType=SymbolType.Icon,refPath="照片.png"}
                }
            };

            IView2D _inputView = (Globals.mainFrame.views.Where(x => x.name == "右幅剖面图").FirstOrDefault()) as IView2D;
            _inputView.holder.setlegend(legeng_ACHE);
            _inputView.holder.setLegendShow(true);
            _inputView = (Globals.mainFrame.views.Where(x => x.name == "左幅剖面图").FirstOrDefault()) as IView2D;
            _inputView.holder.setlegend(legeng_ACHE);
            _inputView.holder.setLegendShow(true);

            try
            {
                DrawObjects drawObjects = new DrawObjects();
                drawObjects.DrawGRPF();

                drawObjects.DrawACHE();
                drawObjects.DrawACHE_EC();
                drawObjects.DrawACHE_YG();
                drawObjects.DrawACHE_ZZM();

                drawObjects.DrawCHAG();
                drawObjects.DrawTPSI();
                drawObjects.RiskIdentification();
                drawObjects.DrawTPZL();
                drawObjects.DrawSPZL();
            }
            catch (Exception ex)
            {

            }
            Globals.mainFrame.viewLoaded -= MainFrame_projectLoaded;
        }
    }
}