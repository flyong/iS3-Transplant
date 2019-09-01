using iS3_DataManager.Interface;
using System;
using System.Text;
using iS3_DataManager.Models;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;

namespace iS3_DataManager.StandardManager
{
    public class Exporter_For_JSON : IDSExporter
    {

        public bool Export(StandardDef dataStandard, string path = null)
        {
            try
            {
                string json = JsonConvert.SerializeObject(dataStandard);
                if (path == null)
                {
                    DirectoryInfo localPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                    path = localPath.Parent.Parent.FullName + "\\Standard\\" + dataStandard.Code + ".json";
                }
                
                

                FileInfo fInfo = new FileInfo(path);
                fInfo.Attributes = FileAttributes.Normal;

                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(json);                
                sw.Flush();
                sw.Close();
                fs.Close();
                // Set the IsReadOnly property.
                fInfo.Attributes = fInfo.Attributes | FileAttributes.ReadOnly | FileAttributes.Hidden;
                return true;
               
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Export(StandardFilter filter)
        {
            
            string json = JsonConvert.SerializeObject(filter);
            return true;
        }

        public bool Export(StageDef domain, string path = null)
        {
            throw new NotImplementedException();
        }

    }
}
