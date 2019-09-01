using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3_DataManager.Models;

namespace iS3_DataManager.DataManager
{
    public class Data2Local
    {
        DirectoryInfo localPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        string path;
        DataSet dataSet;
        public Data2Local(DataSet dataSet)
        {
            this.dataSet = dataSet;
            path = localPath.Parent.Parent.FullName + "\\Data\\Temp\\Data_" + dataSet.DataSetName + ".json";
        }
        public Data2Local(string dataSetName)
        {
            path = localPath.Parent.Parent.FullName + "\\Data\\Temp\\Data_" + dataSetName + ".json";
        }
        public void WriteData2local()
        {
            string json = JsonConvert.SerializeObject(dataSet);
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(json);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public DataSet LoadLocalData(string dataSetName=null)
        {
            path = localPath.Parent.Parent.FullName + "\\Data\\Temp\\Data_" + dataSetName + ".json";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fs, Encoding.UTF8);
            string json = streamReader.ReadToEnd();
            fs.Close();
            streamReader.Close();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(json);
            data.DataSetName = dataSetName??dataSet.DataSetName;
            return data;
        }

    }
}
