using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3_DataManager.Models
{
    public class StandardDef:LangBase
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public List<StageDef> StageContainer { get; set; }
        public StandardDef()
        {
            StageContainer = new List<StageDef>();
        }        

        public DGObjectDef GetDGObjectDefByCode(string Code)
        {
            foreach (var domain in StageContainer)
            {
                foreach (DGObjectDef objectDef in domain.DGObjectContainer)
                    if (objectDef.Code == Code)
                    {
                        return objectDef;
                    }
            }
            return null;
        }
        public DGObjectDef GetDGObjectDefByName(string name)
        {
            foreach (var domain in StageContainer)
            {
                foreach (DGObjectDef objectDef in domain.DGObjectContainer)
                    if (objectDef.LangStr == name)
                    {
                        return objectDef;
                    }
            }
            return null;
        }
        public StageDef GetStageDefByName(string name)
        {
            foreach (var domain in StageContainer)
            {
                foreach (DGObjectDef objectDef in domain.DGObjectContainer)
                    if (objectDef.LangStr == name)
                    {
                        return domain;
                    }
            }
            return null;

        }
    }
}
