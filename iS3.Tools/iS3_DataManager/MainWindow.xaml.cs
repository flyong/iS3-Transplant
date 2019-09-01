using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using iS3_DataManager.Models;
using iS3_DataManager.Interface;
using iS3_DataManager.DataManager;
using iS3_DataManager.StandardManager;
using iS3_DataManager.ViewManager;
using System.Data;
using System.Linq;
using System;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.IO;
using System.Reflection;
using iS3.Core.Model;
using System.Diagnostics;
using iS3.Core.Client;
using Excel = Microsoft.Office.Interop.Excel;

namespace iS3_DataManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region common viriables
        private static StandardDef Standard { get; set; }
        DataSet dataSet { get; set; }
        TreeViewData ViewData { get; set; }
        StandardDef GeoStandard { get; set; }
        StandardDef StrStandard { get; set; }
        StandardDef EnvStandard { get; set; }
        StandardDef LYTunnelStandard { get; set; }

        DataTable newdatatable, currenttable;
        List<int> currenttable_IDindex;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            this.Closing += Window_Closing;//register closing event
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("是否要关闭？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                e.Cancel = false;

            }
            else
            {
                e.Cancel = true;
            }

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var Loads = this.Dispatcher.BeginInvoke(new Action(() =>
            {
                Load();
            }));
            SetFullScreen();
            Loads.Completed += new EventHandler(Loads_Completed);

        }

        void SetFullScreen()
        {
            Rect rc = SystemParameters.WorkArea;//get the workArea
            this.Left = 0;//set window position
            this.Top = 0;
            this.Width = rc.Width / 2;
            this.Height = rc.Height;
        }

        void Loads_Completed(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// load Data&Standard
        /// </summary>
        void Load()
        {
            LoadStandard();//generate json file if the standard has changed or json files got lost ;
            LoadTreeView(); //load TreeView &seperated Standard
            newdatatable = null;

        }
        void LoadTreeView()
        {
            StandardLoader loader = new StandardLoader();
            //LYTunnelStandard = loader.GetStandard("LYTunnel");
            LYTunnelTreeview.DataContext = new TreeViewData(LYTunnelStandard);
        }

        void LoadStandard()
        {
            try
            {
                IDSImporter importer = new StandardImport_Exl();
                LYTunnelStandard = importer.Import("LYTunnel");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        /// <summary>
        /// import Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void DataTemplateTreeview_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                TreeNode node = LYTunnelTreeview.SelectedItem as TreeNode;
                if ((node == null) || (node.Level != 2))
                    return;
                StageDef stage = LYTunnelStandard.StageContainer.Find(x => x.Code == node.Parent);
                DGObjectDef dGObject = stage.DGObjectContainer.Find(x => x.Code == node.Code);
                Project _prj = Globals.project;
                Domain _domain = _prj.getDomain(stage.Code);
                DGObjects objs = _domain.DGObjectsList.Where(x => x.definition.Type == dGObject.Code).FirstOrDefault();
                await GetData(objs);

                if (currenttable.Columns.Count == 0)
                {

                    if (dGObject != null)
                    {
                        foreach (PropertyMeta meta in dGObject.PropertyContainer)
                        {
                            currenttable.Columns.Add(meta.LangStr);
                        }
                    }
                }

                DataView view = new DataView(currenttable);
                DataDG.ItemsSource = view;
                DataDG.UpdateLayout();
                ChangeStyle style = new ChangeStyle(currenttable, ref DataDG, LYTunnelStandard);
                style.IDindex = currenttable_IDindex;
                style.Addattachment();
                DataDG.UpdateLayout();
                DataDG.ScrollIntoView(DataDG.Items[0]);
                DataDG.UpdateLayout();

                                                  
                Statelabel.Content = "请查看" + currenttable.TableName + "的所有数据！";
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取云端数据发生意外，读取失败！");
            }

        }

        /// <summary>
        /// save user changes in gridview
        /// </summary>
        private void DataDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                DataTable tmpDT = ((DataView)DataDG.ItemsSource).Table;
                dataSet.Tables.RemoveAt(dataSet.Tables.IndexOf(tmpDT.TableName));
                dataSet.Tables.Add(tmpDT);

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private async void SaveChangeBT_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TreeNode node = LYTunnelTreeview.SelectedItem as TreeNode;
                if ((node == null) || (node.Level != 2))
                    return;
                if (newdatatable == null)
                    return;


                DGObjectDef objectDef = LYTunnelStandard.GetDGObjectDefByName(newdatatable.TableName);
                StageDef _domain = LYTunnelStandard.GetStageDefByName(newdatatable.TableName);
                if ((objectDef == null) || (_domain == null))
                {
                    MessageBox.Show("检查数据标准表！");
                    return;
                }

                var obj = iS3Property.GetInstance(_domain.Code, objectDef.Code);
                Type _type = iS3Property.GetType(_domain.Code, objectDef.Code);
                MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(_type);
                List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { Activator.CreateInstance(_type) }) as List<PropertyDef>;
                Dictionary<string, object> Property2Value = new Dictionary<string, object>();

                foreach (DataRow row in newdatatable.Rows)
                {
                    foreach (PropertyMeta meta in objectDef.PropertyContainer)
                    {

                        Property2Value[meta.PropertyName] = row[meta.LangStr];
                        if (Property2Value[meta.PropertyName].ToString() == "")
                        {
                            Property2Value[meta.PropertyName] = null;
                        }

                    }
                    foreach (PropertyDef def in _propertyDefs)
                    {
                        PropertyInfo info = _type.GetProperty(def.key); //获取指定名称的属性
                        if (Property2Value.ContainsKey(def.key))
                        {
                            var value = Property2Value[def.key];
                            if (!info.PropertyType.IsGenericType)
                            {
                                //非泛型
                                info.SetValue(obj, (value != null) ? Convert.ChangeType(value, info.PropertyType) : null);
                            }
                            else
                            {
                                //泛型Nullable<>
                                Type genericTypeDefinition = info.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                {
                                    info.SetValue(obj, (value != null) ? Convert.ChangeType(value, Nullable.GetUnderlyingType(info.PropertyType)) : null);
                                }
                            }
                        }

                    }
                    DGObject _obj = await RepositoryForClient.Create(obj as DGObject, _domain.Code, objectDef.Code);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            System.Windows.MessageBox.Show("数据已存储至数据库"); //Data has been stored to DataBase!
            DataTemplateTreeview_SelectedItemChanged(this, new RoutedEventArgs());
            newdatatable = null;
        }

        private void EditInExcel_Click(object sender, RoutedEventArgs e)
        {

            //需要实现的功能：根据选择打开指定的Excel，目前的功能：
            try
            {

                TreeNode node = LYTunnelTreeview.SelectedItem as TreeNode;
                if (node != null & node.Level == 2)
                {
                    string excelName = Runtime.dataPath + "\\ProjectData\\LYTunnel.xls";//你的excel文件的位置
                    string sheetName = node.Context;//你的sheet的名字
                    object missing = Type.Missing;
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook book = excel.Workbooks.Open(excelName, missing,
                           missing, missing, missing, missing, missing, missing, missing,
                           missing, missing, missing, missing, missing, missing);
                    Excel.Worksheet sheet = book.Worksheets[sheetName];
                    sheet.Activate();
                    excel.Visible = true;
                    //string path = Runtime.dataPath + "\\ProjectData\\LYTunnel.xls";
                    //ProcessStartInfo psi = new ProcessStartInfo(path);
                    //Process.Start(psi);
                    Statelabel.Content = "请在弹出的Excel模板里录入新的数据";
                }
            }
            catch (Exception ex)
            {
               
            }
        }


        private void Watchnewdata_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TreeNode node = LYTunnelTreeview.SelectedItem as TreeNode;
                if ((node == null) || (node.Level != 2))
                    return;
                DataImporter_Excel dataImporter = new DataImporter_Excel();
                string path = Runtime.dataPath + "\\ProjectData\\LYTunnel.xls";
                DataTable _newdatatable = dataImporter.Import(path, LYTunnelStandard, node.Context);
                if (_newdatatable.Columns.Count == 0)
                {
                    StageDef stage = LYTunnelStandard.StageContainer.Find(x => x.Code == node.Parent);
                    DGObjectDef dGObject = stage.DGObjectContainer.Find(x => x.Code == node.Code);
                    if (dGObject != null)
                    {
                        foreach (PropertyMeta meta in dGObject.PropertyContainer)
                        {
                            _newdatatable.Columns.Add(meta.LangStr);
                        }
                    }
                }
                string[] distinctcols = new string[(_newdatatable.Columns.Count)];
                foreach (DataColumn dataColumn in _newdatatable.Columns)
                {
                    distinctcols[dataColumn.Ordinal] = dataColumn.ColumnName;
                }
                DataView mydataview = new DataView(_newdatatable);
                _newdatatable = mydataview.ToTable(true, distinctcols);//去重复
                datatable_clean(_newdatatable);//去空白行
                Comparetables(currenttable, _newdatatable);
                DataView view = new DataView(_newdatatable);
                DataDG.ItemsSource = view;
                ChangeStyle style = new ChangeStyle(_newdatatable, ref DataDG, LYTunnelStandard);
                style.RefreshStyle();
                DataDG.ScrollIntoView(DataDG.Items[0]);
                DataDG.UpdateLayout();
                Statelabel.Content = "校核结果如上，如无误则点击“上传新数据”按钮";
                newdatatable = _newdatatable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请保存Excel模板文件，并关闭它！");
            }
        }

        private void datatable_clean(DataTable table)
        {
            int countshow = table.Rows.Count;
            for (int i = countshow - 1; i >= 0; i--)
            {
                bool flag = false;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Rows[i][j].ToString() != "")
                        flag = true;
                }
                if (!flag)
                    table.Rows[i].Delete();
            }

            table.AcceptChanges();
        }
        //删除新表与旧表重复内容
        private void Comparetables(DataTable oldtable, DataTable newtable)
        {
            int countnew = newtable.Rows.Count;
            int countold = oldtable.Rows.Count;
            DGObjectDef objectDef = LYTunnelStandard.GetDGObjectDefByName(newtable.TableName);
            for (int i = countnew - 1; i >= 0; i--)
            {

                DataRow dri = newtable.Rows[i];
                for (int j = countold - 1; j >= 0; j--)
                {

                    DataRow drj = oldtable.Rows[j];
                    bool flag = false;
                    foreach (PropertyMeta meta in objectDef.PropertyContainer)
                    {
                        if (meta.LangStr.Contains("关联"))
                            continue;
                        if (!dri[meta.LangStr].Equals(drj[meta.LangStr]))
                            if ((drj[meta.LangStr] != null) && (dri[meta.LangStr].ToString() != ""))
                                flag = true;
                    }
                    if (!flag)
                    {
                        dri.Delete();
                        break;
                    }
                }
            }
            newtable.AcceptChanges();
        }
        public async Task GetData(DGObjects objs)
        {
            List<DGObject> objList = await RepositoryForClient.RetrieveObjs(objs);
            currenttable = ReadFromDgobjects(objList);
        }



        DataTable ReadFromDgobjects(List<DGObject> objList)
        {
            if (objList.Count == 0)
                return null;
            StageDef _domain = LYTunnelStandard.StageContainer.Find(x => x.Code == objList[0].parent.definition.Domain);
            DGObjectDef objectDef = _domain.DGObjectContainer.Find(x => x.Code == objList[0].parent.definition.Type);
            DataTable dt = new DataTable() { TableName = objectDef.LangStr };

            Type _type = iS3Property.GetType(_domain.Code, objectDef.Code);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(_type);
            List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { Activator.CreateInstance(_type) }) as List<PropertyDef>;
            Dictionary<string, object> Property2Value = new Dictionary<string, object>();

            foreach (PropertyMeta meta in objectDef.PropertyContainer)
            {
                dt.Columns.Add(meta.LangStr);
            }

            currenttable_IDindex = new List<int>();
            for (int i = 0; i < objList.Count; i++)
            {
                DGObject _obj = objList[i];
                DataRow dr = dt.NewRow();
                //将obj数据读取出来放进词典中
                try
                {
                    foreach (PropertyDef def in _propertyDefs)
                    {
                        PropertyInfo info = _type.GetProperty(def.key); //获取指定名称的属性

                        Property2Value[def.key] = info.GetValue(_obj, null);
                        if (def.type == typeof(Nullable<DateTime>) && (Property2Value[def.key] != null))
                        {
                            DateTime temp = (DateTime)Property2Value[def.key];
                            Property2Value[def.key] = temp.ToShortDateString();
                        }
                        if ((Property2Value[def.key] != null) && (Property2Value[def.key].ToString() == ""))
                        {
                            Property2Value[def.key] = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                bool flag = true;
                //给row的元素赋值
                foreach (PropertyMeta meta in objectDef.PropertyContainer)
                {
                    if (Property2Value.ContainsKey(meta.PropertyName))
                        dr[meta.LangStr] = Property2Value[meta.PropertyName];

                    if (meta.LangStr.Contains("标段"))

                        if (Runtime.filtercontent != "All")
                            if (Runtime.filtercontent != dr[meta.LangStr].ToString())
                                flag = false;
                }
                if (flag)
                {
                    dt.Rows.Add(dr);
                    currenttable_IDindex.Add((int)Property2Value["ID"]);
                }
            }
            return dt;
        }

    }
}
