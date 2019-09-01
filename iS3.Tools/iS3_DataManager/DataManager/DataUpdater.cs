using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using iS3_DataManager.Models;
using System.IO;
using System.Threading;

namespace iS3_DataManager.DataManager
{

    public class DataUpdater
    {
        public DataSet oldDataset;
        public DataSet updatedDataSet;
        string localPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        string path;
        StageDef stage;

        //主要功能是实现数据的比对、数据文件的备份、新的数据模板的生成
        //manin function is to compare data and select the new data
        public DataSet UpdateData(StageDef stage)
        {

            TableComparator comparator = new TableComparator(null, null, null);
            return null;
        }
        public DataSet UpdateDataSet(DataSet oldSet, DataSet newDataSet, StageDef stage)
        {
            this.stage = stage;
            path = localPath + @"\Data\Template\" + stage.Code + ".xls";
            BackupExcel(path);
            RebuildTemplate();

            DataSet addedDataSet = new DataSet() { DataSetName = oldSet.DataSetName };
            int count = newDataSet.Tables.Count;
            if (count > 5)
            {
                foreach (DataTable newTable in newDataSet.Tables)
                {
                    if (newTable.Rows.Count < 1)
                    {
                        continue;
                    }
                    DataTable oldTable = oldSet.Tables[newTable.TableName];
                    DGObjectDef dG = stage.DGObjectContainer.Find(x => (x.LangStr == newTable.TableName || x.Code == newTable.TableName));
                    TableComparator comparator = new TableComparator(oldTable, newTable, dG);
                    comparator.Compare();
                    DataTable UpdatedTable = comparator.updatedTable;
                    updatedDataSet = newDataSet.Clone();
                    updatedDataSet.Tables.Remove(UpdatedTable.TableName);
                    updatedDataSet.Tables.Add(UpdatedTable);

                    foreach(DataRow row in UpdatedTable.Rows)
                    {
                        oldTable.ImportRow(row);
                    }
                    oldSet.Tables.Remove(oldTable.TableName);
                    oldSet.Tables.Add(oldTable);
                }
            }

            return oldSet;
        }
        private void CombineOld_Added()
        {

        }

        private void BackupExcel(string path)
        {
            try
            {
                string newPath = localPath + @"\Data\Backup\" + Path.GetFileName(path);
                File.Move(path, newPath);
            }
            catch (Exception e)
            {
                try
                {
                    string newPath = localPath + @"\Data\Backup\" + Path.GetFileNameWithoutExtension(path) + DateTime.Now.Second.ToString() + ".xls";
                    File.Move(path, newPath);
                }
                catch (Exception ex) { }

            }
        }
        private void RebuildTemplate()
        {
            TemplateGenerator_Excel templateGenerator = new TemplateGenerator_Excel();
            templateGenerator.Export(stage, localPath + @"\Data\Template");
        }

    }
    class TableComparator
    {
        DataTable oldTable;
        DataTable newTable;
        public DataTable updatedTable;
        DGObjectDef dG;
        public TableComparator(DataTable oldTable, DataTable newTable, DGObjectDef dG)
        {
            this.oldTable = oldTable;
            this.newTable = newTable;
            this.dG = dG;
        }
        public void Compare()
        {
            DeduplicateTable(ref oldTable);
            DeduplicateTable(ref newTable);
            CompareDataTable();

        }
        private void DeduplicateTable(ref DataTable table)
        {
            string[] distinctcols = new string[(table.Columns.Count)];
            foreach (DataColumn dataColumn in table.Columns)
            {
                distinctcols[dataColumn.Ordinal] = dataColumn.ColumnName;
            }
            DataTable DeduplicatedTable = new DataTable() { TableName = table.TableName };
            DataView mydataview = new DataView(table);
            DeduplicatedTable = mydataview.ToTable(true, distinctcols);//去重复
            table = DeduplicatedTable;
            DeduplicatedTable.Dispose();
        }
        private void CompareDataTable()
        {
            string primaryKey = dG.PropertyContainer[0].LangStr;

            oldTable.AcceptChanges();
            newTable.AcceptChanges();

            updatedTable = newTable.Copy();

            DataColumn oldColumn = oldTable.Columns[primaryKey];
            DataColumn newColumn = newTable.Columns[primaryKey]; //设置主键 
            oldTable.PrimaryKey = new DataColumn[1] { oldColumn };
            newTable.PrimaryKey = new DataColumn[1] { newColumn };

            string primaryValue;
            string where;
            int rowNum = 0;
            foreach (DataRow newRow in newTable.Rows)
            {
                primaryValue = newRow[primaryKey].ToString();
                where = primaryKey + " = '" + primaryValue + "'"; //在旧表中查找和主键相同的行,search same rows in old table 
                DataRow[] sameRows = oldTable.Select(where);
                if (sameRows.Length != 0)
                {
                    foreach (DataRow row in sameRows)
                    {
                        int index = 0;
                        for (int i = 0; i < newRow.ItemArray.Length; i++)
                        {
                            if (newRow.ItemArray.GetValue(i).ToString().Equals(row.ItemArray.GetValue(i).ToString()) == true)
                            {
                                index++;
                            }
                        }
                        if (index == newRow.ItemArray.Length)
                        {

                            updatedTable.Rows.RemoveAt(rowNum);
                            break;
                        }
                    }
                    rowNum++;
                }
            }

        }
    }
}
