using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using iS3_DataManager.Models;
using System.IO;
using System.Windows;
using System.Threading;

namespace iS3_DataManager.DataManager
{
    public class DataCleaner
    {
        public DataSet dataSet { get; set; }
        public DataTable dataTable { get; set; }
        public StandardDef standardDef { get; set; }
        private DataSet _dataSet;
        private DataTable _dataTable;

        public DataCleaner(DataTable table, StandardDef standard)
        {
            dataTable = table;
            standardDef = standard;
        }
        public DataCleaner(DataSet set, StandardDef standard)
        {
            dataSet = set;
            standardDef = standard;
        }
        public bool Clean()
        {
            try
            {
                _dataSet = dataSet;
                _dataTable = dataTable;
                ThreadStart start = new ThreadStart(Save2Local);//async save data to local
                Thread t = new Thread(start);
                t.Start();

                if (dataSet != null)
                {
                    DataSet tmpDS = new DataSet() { DataSetName=(dataSet.DataSetName) };
                    foreach (DataTable table in dataSet.Tables)
                    {
                        DGObjectDef objectDef = standardDef.GetDGObjectDefByName(table.TableName);
                        DataTable dt = CleanTable(table, objectDef);
                        tmpDS.Tables.Add(dt);
                    }
                    this.dataSet = tmpDS;
                }
                else if (dataTable != null)
                {
                    DGObjectDef objectDef = standardDef.GetDGObjectDefByName(dataTable.TableName);
                    dataTable = CleanTable(dataTable, objectDef);
                }
                return true;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }

        }

        private DataTable CleanTable(DataTable table, DGObjectDef objectDef)
        {
            DataTable tmpTable = DeduplicateTable(table, objectDef);
            tmpTable = RemoveError(tmpTable, objectDef);
            return tmpTable;
        }
        private DataTable DeduplicateTable(DataTable table, DGObjectDef objectDef)
        {
            string[] distinctcols = new string[(table.Columns.Count)];
            foreach (DataColumn dataColumn in table.Columns)
            {
                distinctcols[dataColumn.Ordinal] = dataColumn.ColumnName;
            }
            DataTable DeduplicatedTable = new DataTable() { TableName = table.TableName };
            DataView mydataview = new DataView(table);
            DeduplicatedTable =(DataTable) mydataview.ToTable(true, distinctcols);//去重复
            return DeduplicatedTable;
        }
        private DataTable RemoveEmpty(DataTable table, DGObjectDef objectDef)
        {
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (PropertyMeta meta in objectDef.PropertyContainer)
                    {
                        if ((meta.Nullable == false | meta.IsKey == true) & (row[meta.LangStr].ToString() == null | row[meta.LangStr].ToString() == ""))
                        {
                            row.Delete();//Delete rows which lack of key values;
                        }
                    }
                }
                return table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        private void Save2Local()
        {
            try
            {

                if (_dataSet != null)
                {
                    dataSet.DataSetName = dataSet.DataSetName + DateTime.Now.ToLocalTime().ToString();
                    Data2Local data2Localfile = new Data2Local(dataSet);
                    data2Localfile.WriteData2local();
                }
                else if (_dataTable != null)
                {
                    DataSet dataSet = new DataSet() {DataSetName=( dataTable.TableName + DateTime.Now.ToLocalTime().ToString())};
                    dataSet.Tables.Add(dataTable);
                    Data2Local data2Localfile = new Data2Local(dataSet);
                    data2Localfile.WriteData2local();
                }
                _dataSet = null;
                _dataTable = null;
            }
            catch (Exception)
            {

            }
        }
        private DataTable RemoveError(DataTable dataTable, DGObjectDef objectDef)
        {

            DataTable tmpTable = dataTable;
            foreach (PropertyMeta meta in objectDef.PropertyContainer)
            {
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    DataRow row = dataTable.Rows[j];
                    if ((meta.Nullable == false | meta.IsKey == true) & (row[meta.LangStr].ToString() == null | row[meta.LangStr].ToString() == ""))
                    {
                        tmpTable.Rows.RemoveAt(j);//Delete rows which lack of key values;
                        continue;
                    }

                    if (meta.RegularExp != null)
                    {
                        var data = row[meta.LangStr].ToString();
                        bool reult1 = (data != "" & data != null);
                        bool result = Regex.IsMatch(row[meta.LangStr].ToString(), meta.RegularExp);
                        if (reult1 & !result)
                        {
                            tmpTable.Rows.RemoveAt(j);//delete error imformation
                        }
                    }
                }
                dataTable = tmpTable;
            }
            return tmpTable;
        }
    }
}
