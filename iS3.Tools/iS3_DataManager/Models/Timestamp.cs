using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iS3_DataManager.Models
{
    /// <summary>
    /// This time stamp record the last modifided time of each data table
    /// </summary>
    public class Timestamp
    {
        public Dictionary<string, DateTime> Timestamps;
        
        public static string TimeStamp;
        public Timestamp()
        {
            LoadStamps();
        }
        public void Modify(string TableName,DateTime? time=null)
        {
            try
            {
                DateTime tmpTime = time ?? DateTime.Now;
                Timestamps[TableName] = tmpTime;
                SaveStamps();
            }
            catch (Exception) { }
            
        }
        public DateTime GetTime(string TableName)
        {
            try
            {
                if (Timestamps[TableName] != null)
                    return Timestamps[TableName];
                else
                {
                    return Convert.ToDateTime("2000-01-01 00:00:00"); 
                }
            }
            catch(Exception e)
            {
                return Convert.ToDateTime("2000-01-01 00:00:00");
            }
        }
        public void SaveStamps()
        {
            DirectoryInfo localPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string path = localPath.Parent.Parent.FullName + "\\Timestamp\\Timestamp.json";
            string json = JsonConvert.SerializeObject(Timestamps);
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(json);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// just for initial
        /// </summary>
        /// <param name="standard"></param>
        public void Initail(StandardDef standard)
        {
            try
            {
                Dictionary<string, DateTime> tmpDict = new Dictionary<string, DateTime>();
                foreach (StageDef stage in standard.StageContainer)
                {
                    foreach (DGObjectDef dG in stage.DGObjectContainer)
                    {
                        DateTime time = Convert.ToDateTime("2000-01-01 00:00:00");
                        tmpDict.Add(dG.LangStr, time);
                    }
                }
                Timestamps = tmpDict;
                SaveStamps();
            }
            catch (Exception) { }
        }
        private void LoadStamps()
        {
            DirectoryInfo localPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string path = localPath.Parent.Parent.FullName + "\\Timestamp\\Timestamp.json";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fs, Encoding.UTF8);
            string json = streamReader.ReadToEnd();
            fs.Close();
            streamReader.Close();
            Timestamps = JsonConvert.DeserializeObject<Dictionary<string,DateTime>>(json);
        }
    }
}
