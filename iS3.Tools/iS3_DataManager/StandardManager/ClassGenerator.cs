using System.Data;
using Newtonsoft.Json;
using iS3_DataManager.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace iS3_DataManager.StandardManager
{
    public class ClassGenerator
    {
        public StandardDef standard;
        public void GenerateClass(StandardDef standardDef)
        {
            try
            {
                this.standard = standardDef;
                foreach (StageDef domain in standardDef.StageContainer)
                {
                    GenerateClass(domain);
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
        
        /// <param name="domain"></param>
        public void GenerateClass(StageDef domain)
        {
            try
            {
                Dictionary<string, string> Types = new DataType().Gettype;
                foreach (DGObjectDef dGObject in domain.DGObjectContainer)
                {

                    string newClass = "using System; \nusing System.ComponentModel.DataAnnotations.Schema;\n";
                    newClass += "using iS3.Core.Model;\n";
                    newClass += "\nnamespace "+"iS3."+standard.Code+".Model\n { \n \t";
                    newClass += "///<summary>///"+(dGObject.LangStr??dGObject.Code)+"///</summary>\n";
                    newClass += "\t[Table(\""+standard.Code+"_" + dGObject.Code + "\")]\n";
                    newClass += "\tpublic class " + dGObject.Code + ":DGObject\n \t{ \n";
                    foreach (PropertyMeta meta in dGObject.PropertyContainer)
                    {
                        newClass += "\t\t/// <summary>\n\t\t///"+meta.LangStr+" \n\t\t///</summary>\n";
                        if (meta.Nullable == false)
                        {
                            if (Types[meta.DataType] != "string")
                            {
                                newClass += "\t\tpublic " + Types[meta.DataType] + "  " + meta.PropertyName + " {get;set;}\n";
                            }
                            else
                            {
                                newClass += "\t\tpublic " + Types[meta.DataType] + " " + meta.PropertyName + " {get;set;}\n";
                            }
                        }
                        else
                        {
                            if (Types[meta.DataType] != "string")
                            {
                                newClass += "\t\tpublic Nullable<" + Types[meta.DataType] + "> " + meta.PropertyName + " {get;set;}\n";
                            }
                            else
                            {
                                newClass += "\t\tpublic " + Types[meta.DataType] + " " + meta.PropertyName + " {get;set;}\n";
                            }
                        }                      

                    }

                    newClass += "\t}\n}";
                    string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\ObjectModels\" + dGObject.Code + ".cs";
                    FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(newClass);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                System.Windows.MessageBox.Show("Gengerated Successfully!");
        }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
}

    }
}
