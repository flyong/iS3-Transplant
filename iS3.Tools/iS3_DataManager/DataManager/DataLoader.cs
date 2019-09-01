using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3_DataManager.Models;
using Newtonsoft.Json;

namespace iS3_DataManager.DataManager
{
    /// <summary>
    /// load local tmp data/used for Incremental updating加载本地数据，用于比对数据
    /// </summary>
    public class DataLoader
    {
        StandardDef standard;
        DirectoryInfo localPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        string path;
        public DataLoader(StandardDef standard)
        {
            this.standard = standard;
        }
        public List<DataSet> LoadData()
        {
            List<DataSet> dataSets = new List<DataSet>();
            foreach (StageDef stage in standard.StageContainer)
            {
                if (stage.Code != "Monitoring")
                {
                    dataSets.Add(ReadJson(stage));
                }
            }
            return dataSets;
        }
        public DataSet LoadData(string StageName)
        {
            StageDef stage = standard.StageContainer.Find(x => x.Code == StageName);
            if (stage != null)
            {
                return ReadJson(stage);
            }
            else
            {
                return null;
            }
        }
        public List<DataSet> LoadExcel()
        {
            List<DataSet> dataSets = new List<DataSet>();
            foreach (StageDef stage in standard.StageContainer)
            {
                dataSets.Add(ReadJson(stage));
            }
            return dataSets;
        }

        private DataSet ReadJson(StageDef stage)
        {
            path = localPath.Parent.Parent.FullName + "\\Data\\Temp\\Data_" + stage.Code + ".json";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fs, Encoding.UTF8);
            string json = streamReader.ReadToEnd();
            fs.Close();
            streamReader.Close();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(json);
            data.DataSetName = stage.Code;
            return data;
        }
        //if the datatable is null,add titles for these tables为表增添列名，用于基于界面的数据录入
        
    }
}
