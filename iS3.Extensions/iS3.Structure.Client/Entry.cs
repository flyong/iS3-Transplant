using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Client;
using iS3.Core.Client.ViewModel;
using iS3.Structure.Client.Control;
using RTM_Tool;
namespace iS3.Structure.Client
{
    public class Entry : Extensions
    {
        public override string domain { get { return "Structure"; } }
        public override string name() { return "Structure Tool"; }
        public override IEnumerable<DGObjectViewConfig> treeItems()
        {

            return dGObjectViewConfigs;
        }
        List<DGObjectViewConfig> dGObjectViewConfigs;
        Dictionary<string, List<MenuBase>> menuDicts;

        public IDGObjectView ShowStructureView()
        {
            return new StructureView();
        }
        public IDGObjectView ShowSELIView()
        {
            return new SELIView();
        }
        public override async Task init()
        {
            dGObjectViewConfigs = new List<DGObjectViewConfig>();
            //dGObjectViewConfigs.Add(new DGObjectViewConfig("CONC", ShowStructureView));
            //dGObjectViewConfigs.Add(new DGObjectViewConfig("SELI", ShowSELIView));

            Globals.mainFrame.viewLoaded += MainFrame_viewLoaded;

        }
        private void MainFrame_viewLoaded(object sender, EventArgs e)
        {
            DrawObjects drawObjects = new DrawObjects();
            try
            {
                drawObjects.DrawMILI();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            Globals.mainFrame.viewLoaded -= MainFrame_viewLoaded;
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
        public override ObjEditorDef objEditorDef(string objType)
        {
            if (objEditorDefDict.ContainsKey(objType))
            {
                return objEditorDefDict[objType];
            }
            else
                return null;
        }
    }
}