using System;
using iS3_DataManager.Models;
using iS3_DataManager.Interface;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using System.IO;

namespace iS3_DataManager.DataManager
{

    public class TemplateGenerator_Excel :IDataExporter
    {

        string path=Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string fileName;

        StandardDef standard;
        StageDef domain;



        public bool Export(StandardDef standard, string path = null)
        {
            this.standard = standard;
            if (path == null)
            {
            }
            else
            {
                this.path = path;
            }
            bool succeed = Export();
            if (succeed) System.Windows.MessageBox.Show("数据模板已保存至桌面");//The Exl templete generated successfully at Destop!
            else System.Windows.MessageBox.Show("Someting getting wrong during generating,Please try again!");
            return succeed;
        }

        public bool Export(StageDef domain, string path = null)
        {
            this.domain = domain ;
            if (path != null)
            {
                this.path = path;
            }
            bool succeed = Export();
            if (succeed) System.Windows.MessageBox.Show("数据模板已保存至桌面");//The Exl templete generated successfully at Destop!
            else System.Windows.MessageBox.Show("错误，请重新尝试");//Someting getting wrong during generating,Please try again!
            return succeed;
        }

        /// <summary>
        /// export standard to excel for data input
        /// </summary>
        /// <param name="path">the path where excel will generate to</param>
        /// <param name="standard"></param>
        /// <returns></returns>
        bool Export()
        {
            //default file format 'xls'
            IWorkbook workbook = new HSSFWorkbook();
            try
            {
                if (standard == null)
                {
                    fileName = path + "\\"+(domain.Code??domain.LangStr)+".xls";
                    write2Exl(this.domain, workbook);
                }
                else
                {
                    fileName = path + "\\" + (standard.Code??standard.LangStr) + ".xls";
                    foreach (StageDef domain in standard.StageContainer)
                    {
                        write2Exl(domain, workbook);
                    }
                }
        }
            catch (Exception ex)
            {
                return false;
            }
            saveExl(workbook);
            return true;

        }


        bool write2Exl(StageDef domain, IWorkbook workbook)
        {
            foreach (DGObjectDef item in domain.DGObjectContainer)
            {
                HSSFCellStyle cellStyle1 = (HSSFCellStyle)workbook.CreateCellStyle();
                HSSFCellStyle cellStyle2= (HSSFCellStyle)workbook.CreateCellStyle();
                cellStyle1.FillForegroundColor = HSSFColor.SkyBlue.Index;
                cellStyle1.FillPattern = FillPattern.SolidForeground;
                cellStyle1.FillBackgroundColor = HSSFColor.Yellow.Index;
                cellStyle1.FillPattern = FillPattern.SolidForeground;
                cellStyle2 = cellStyle1;

                ISheet sheet = workbook.CreateSheet(item.LangStr??item.Code);
                writeDescription(sheet, item);
                wrtieTitle(sheet, item,cellStyle1,cellStyle2);
            }
            return true;
        }

        void writeDescription(ISheet sheet, DGObjectDef item)
        {
            IRow row0 = sheet.CreateRow(0);
            row0.CreateCell(0).SetCellValue(item.LangStr + "表");
            row0.CreateCell(1).SetCellValue(item.Code);
            row0.CreateCell(2).SetCellValue("请勿修改sheet名");
            row0.CreateCell(4).SetCellValue(item.Desctiption);

            for (int i = 0; i < 20; i++)
            {
                sheet.SetColumnWidth(i, 20 * 175);
            }
        }

        void wrtieTitle(ISheet sheet, DGObjectDef item,HSSFCellStyle s1,HSSFCellStyle s2)
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
