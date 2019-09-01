using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public class Extensions
    {
        public virtual async Task init() { }
        public virtual string domain { get; }
        // Summary:
        //     Name, version and provide of the tool
        public virtual string name() { return "Unknown tool"; }
        public virtual string version() { return "Unknown"; }
        public virtual string provider() { return "Unknown provider"; }

        // Summary:
        //     Get treeItems of the tool, called immediately after loaded.
        public virtual IEnumerable<DGObjectViewConfig> treeItems()
        {

            return null;
        }

        public virtual List<MenuBase> menuList(string objType)
        {
            return null;
        }
        public virtual ObjEditorDef objEditorDef(string objType)
        {
            return null;
        }
        public virtual IEnumerable<ObjEditorWin> objEditorWins()
        {
            return null;
        }
        public virtual IEnumerable<ObjsControl> objsControls()
        {
            return null;
        }
    }
}
