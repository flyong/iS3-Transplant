using System;
using System.IO;
using iS3_DataManager.Interface;
using iS3_DataManager.Models;
using Newtonsoft.Json;
using System.Text;
using iS3_DataManager.StandardManager;

namespace iS3_DataManager.StandardManager
{
    public class Importer_For_Json : IDSImporter
    {
        public StandardDef Import(string path)
        {
            path = path ?? (AppDomain.CurrentDomain.BaseDirectory + @"Standard\Geology.json");
            return ReadJson(path);
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public StandardDef ReadJson(string path)
        {
            if (path != null)
            {
                
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fs, Encoding.UTF8);
                string json = streamReader.ReadToEnd();
                fs.Close();
                streamReader.Close();

                StandardDef standard = JsonConvert.DeserializeObject<StandardDef>(json);
                return standard;
            }
            else
            {
                return null;
            }
        }

    }
}
