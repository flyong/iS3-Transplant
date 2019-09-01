using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3_DataManager.Interface;
using iS3_DataManager.Models;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using iS3.Core.Client;

namespace iS3_DataManager.StandardManager
{
    public class StandardImport_Exl : IDSImporter
    {
        StandardDef standardDef { get; set; }

        public StandardDef Import(string StandardName)
        {
            try
            {
               // DirectoryInfo localPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                string path = Runtime.dataPath  + "\\Standard\\" + StandardName + ".xlsx";
                return ReadExl(ReadWorkbook(path));
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Please close the excel");
                return null;
            }
        }

        private StandardDef ReadExl(IWorkbook workbook)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + @"Standard\";
            //DataStandardDef standardDef = new StandardLoader().getStandard(path);

            ISheet sheet = workbook.GetSheetAt(0);
            for (int i = 1; i <=sheet.LastRowNum; i++)
            {

                IRow row = sheet.GetRow(i);
                Row2Object(row);
            }
            //IDSExporter exporter = new Exporter_For_JSON();
            //exporter.Export(this.standardDef);
            workbook.Close();
            return this.standardDef;

        }

        IWorkbook ReadWorkbook(string path)
        {
            try
            {
                this.standardDef = new StandardDef { Code = Path.GetFileNameWithoutExtension(path) };
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                if (path.IndexOf(".xlsx") > 0) // for excel version over 2007
                    return new XSSFWorkbook(fs);
                else if (path.IndexOf(".xls") > 0) //for excel version 97-03
                    return new HSSFWorkbook(fs);
            }
            catch (Exception e)
            {

                //System.Windows.MessageBox.Show(e.Message);
                return null;
                throw e;
            }
            return null;
        }
        private void Row2Object(IRow row)
        {

            //try
            //{
            string domainName = row.GetCell(0).ToString();
            string domainDes = row.GetCell(1)?.ToString();
            string domainlangStr = row.GetCell(2)?.ToString();
            string objectName = row.GetCell(3)?.ToString();
            string objDescrip = row.GetCell(4)?.ToString();
            string objLangStr = row.GetCell(5)?.ToString();
            string propertyName = row.GetCell(6).ToString();
            bool IsKey = row.GetCell(7)?.ToString() == null ? false : row.GetCell(7).ToString() == "TRUE";
            string dataType = row.GetCell(8)?.ToString().Replace(" ", "");
            bool Nullable = row.GetCell(9)?.ToString() == null ? true : row.GetCell(9).ToString() != "FALSE";
            string unit = row.GetCell(10)?.ToString();
            string regularExp = row.GetCell(11)?.ToString();
            string proLanStr = row.GetCell(12)?.ToString();
            string proDes = row.GetCell(13)?.ToString();


            StageDef domain;
            DGObjectDef objectDef;
            PropertyMeta property = new PropertyMeta
            {
                PropertyName = propertyName,
                IsKey = IsKey,
                Nullable = Nullable,
                DataType = dataType,
                Unit = unit,
                Description = proDes,
                RegularExp = regularExp,
                LangStr = proLanStr
            };

            if (this.standardDef.StageContainer.Exists(x => x.Code == domainName))
            {
                domain = this.standardDef.StageContainer.Find(x => x.Code == domainName);

                if (domain.DGObjectContainer.Exists(x => x.Code == objectName))
                {
                    objectDef = domain.DGObjectContainer.Find(x => x.Code == objectName);
                    if (!objectDef.PropertyContainer.Exists(x => x.PropertyName == property.PropertyName))
                        objectDef.PropertyContainer.Add(property);
                }
                else
                {
                    objectDef = new DGObjectDef
                    {
                        Code = objectName,
                        Desctiption = objDescrip,
                        LangStr = objLangStr
                    };
                    objectDef.PropertyContainer.Add(property);
                    domain.DGObjectContainer.Add(objectDef);
                }
            }
            else
            {
                domain = new StageDef
                {
                    Code = domainName,
                    Desciption = domainDes,
                    LangStr = domainlangStr
                };
                objectDef = new DGObjectDef
                {
                    Code = objectName,
                    Desctiption = objDescrip,
                    LangStr = objLangStr
                };
                objectDef.PropertyContainer.Add(property);
                domain.DGObjectContainer.Add(objectDef);
                this.standardDef.StageContainer.Add(domain);
            }
            //}
            //catch (Exception e)
            //{
            //    //throw e;
            //    System.Windows.MessageBox.Show(e.Message);
            //}
        }
    }
}
