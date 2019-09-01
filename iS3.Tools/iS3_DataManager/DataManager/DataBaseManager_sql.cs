using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3_DataManager.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iS3_DataManager.Interface;

namespace iS3_DataManager.DataManager
{
    public class DataBaseManager_SQL : IDataBaseManager
    {
        
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\GitHub\Respositories\iS3_DataManager\iS3_DataManager\Data\GeologyDB.mdf;Integrated Security=True;Connect Timeout=30";

        public bool CreatTable(DataStandardDef standardDef)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            foreach (DomainDef domain in standardDef.DomainContainer)
            {
                foreach (DGObjectDef item in domain.DGObjectContainer)
                {
                    string sql_create = "CREATE TABLE " + item.Code+"(";                    
                }
            }
            return false;
        }
        public void Data2DB(DataSet ds, DataStandardDef standardDef)
        {
            try
            {
                string domainName = ds.DataSetName;
                DomainDef domain = standardDef.DomainContainer.Find(x => x.LangStr == domainName);

                if (domain != null)
                {
                    
                    foreach (DataTable table in ds.Tables)
                    {
                        DGObjectDef objectDef = domain.DGObjectContainer.Find(x => x.LangStr == table.TableName);
                        Insert(objectDef, table);
                    }
                    System.Windows.MessageBox.Show("数据导入成功");
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }

        public DataSet DB2Data()
        {
            return null;
        }


        public bool Insert( DGObjectDef objectDef, DataTable table)
        {
            try
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    string sql = "INSERT INTO " + objectDef.Code;
                    string column = "s(";
                    string value = " VALUES(";
                    foreach (PropertyMeta meta in objectDef.PropertyContainer)
                    {
                        string dataCell = table.Rows[i][meta.PropertyName].ToString();
                        if (dataCell != null)
                        {
                            column += meta.PropertyName + ",";
                            value += "'" + dataCell + "',";
                        }
                    }
                    column = column.TrimEnd(',') + ")  ";
                    value = value.TrimEnd(',') + ") ";
                    sql += column + value;
                    //db.Boreholes.SqlQuery(sql);
                    //db.Database.ExecuteSqlCommand(sql);
                    ////ExecuteSqlCommand(sql);
                    //db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }

        }

        /// <summary>
        /// link2Default DataBase   
        /// </summary>
        /// <returns></returns>
        private void LinkDB()
        {
            try
            {
                SqlConnection connection = new SqlConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();
                System.Windows.MessageBox.Show(connection.State.ToString());
                connection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }

        void Insert(DataTable table, SqlConnection connection)
        {

            //var q = from c in connection select; 
        }




    }

}
