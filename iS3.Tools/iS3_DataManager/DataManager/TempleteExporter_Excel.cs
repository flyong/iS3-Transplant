using System;
using iS3_DataManager.Models;
using iS3_DataManager.Interface;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Collections.Generic;

namespace iS3_DataManager.DataManager
{
    /// <summary>
    /// generate exl templete for data input
    /// </summary>
     class TempleteExporter_Excel :IDSExporter
    {

        string path=Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string fileName;

        StandardDef standard;
        StageDef domain;


        /// <summary>
        /// export standard to excel for data input
        /// </summary>
        /// <param name="standard"></param>
        /// <param name="path">the path where excel will generate at</param>
        /// <returns></returns>
        public bool Export(StandardDef standard, string path=null)
        {
            this.standard = standard;
            this.path = path ?? this.path;
            try
            {
                foreach (StageDef domain in standard.StageContainer)
                {
                    this.domain = domain;
                    Export();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public bool Export(StageDef domain, string path = null)
        {
            this.domain = domain;
            this.path = path ?? this.path;
            return Export();
        }

        private bool Export()
        {
            try
            {
                IWorkbook workbook = new HSSFWorkbook();
                fileName = path + "\\" + domain.Code + ".xls";
                write2Exl(domain, workbook);
                saveExl(workbook);
            }
            catch (Exception e
            )
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        bool write2Exl(StageDef domain, IWorkbook workbook)
        {
            foreach (DGObjectDef objectDef in domain.DGObjectContainer)
            {
                XSSFCellStyle cellStyle1 = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle cellStyle2 = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFColor color1 = new XSSFColor();
                XSSFColor color2 = new XSSFColor();
                //根据自己需要设置RGB
                byte[] colorRgb1 = { (byte)214, (byte)220, (byte)228 };
                byte[] colorRgb2 = { (byte)221, (byte)235, (byte)247 };
                color1.SetRgb(colorRgb1);
                color2.SetRgb(colorRgb2);
                cellStyle1.FillForegroundColorColor = color1;
                cellStyle1.FillPattern = FillPattern.SolidForeground;
                cellStyle2.FillBackgroundColorColor = color2;
                cellStyle2.FillPattern = FillPattern.SolidForeground;
                string sheetName = objectDef.LangStr ?? objectDef.Code;
                ISheet sheet = workbook.CreateSheet(sheetName);
                writeDescription(sheet, objectDef);
                wrtieTitle(sheet, objectDef,cellStyle1,cellStyle2);
            }
            return true;
        }

        void writeDescription(ISheet sheet, DGObjectDef objectDef)
        {
            IRow row0 = sheet.CreateRow(0);
            row0.CreateCell(0).SetCellValue(objectDef.Code + "表");
            row0.CreateCell(1).SetCellValue(objectDef.LangStr);
            row0.CreateCell(3).SetCellValue("请勿修改sheet名");

            for (int i = 0; i < 20; i++)
            {
                sheet.SetColumnWidth(i, 20 * 150);
            }
        }

        void wrtieTitle(ISheet sheet, DGObjectDef item,XSSFCellStyle s1, XSSFCellStyle s2)
        {
            IRow row1 = sheet.CreateRow(1);
            IRow row2 = sheet.CreateRow(2);
            int i = 0;
            foreach (PropertyMeta property in item.PropertyContainer)
            {
                row1.CreateCell(i).SetCellValue(property.LangStr);
                row1.Cells[i].CellStyle = s1;
                row2.CreateCell(i).SetCellValue(property.DataType);
                row2.Cells[i++].CellStyle = s2;
            }

        }

        void saveExl(IWorkbook workbook)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Close();
        }
    }
}
