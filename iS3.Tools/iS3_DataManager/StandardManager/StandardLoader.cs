using System;
using iS3_DataManager.Models;
using System.IO;
using iS3_DataManager.Interface;
using iS3_DataManager.DataManager;
using iS3_DataManager.StandardManager;
using System.Collections.Generic;

namespace iS3_DataManager.StandardManager
{
    public class StandardLoader
    {
        string path { get; set; }
        public StandardLoader()
        {
            DirectoryInfo localPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            path = localPath.Parent.Parent.FullName + "\\Standard\\";
        }
        /// <summary>
        /// default return geology standard
        /// </summary>
        /// <returns></returns>
        public StandardDef GetStandard()
        {
            IDSImporter importer = new Importer_For_Json();
            return importer.Import(path + "Geology.json");
        }

        public StandardDef GetStandard(string StandardName)
        {
            IDSImporter importer = new Importer_For_Json();
            return importer.Import(path + StandardName + ".json");
        }
        public StandardDef LoadAllStandard(List<string> standardNameList)
        {
            if (standardNameList.Count < 1)
            {
                standardNameList = new List<string>();
                standardNameList.Add("Geology");
                standardNameList.Add("Structure");
                standardNameList.Add("Environment");
            }
            StandardDef tmpStandard = new StandardDef() { Code = "Standard", Description = "StandardforAll", LangStr = "数据标准" };
            foreach (string standardName in standardNameList)
            {
                foreach (StageDef stage in GetStandard(standardName).StageContainer)
                {
                    tmpStandard.StageContainer.Add(stage);
                }
            }
            return tmpStandard;
        }
    }
}

