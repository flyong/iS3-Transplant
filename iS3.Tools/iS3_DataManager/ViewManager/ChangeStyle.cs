using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using iS3_DataManager.Service;
using iS3_DataManager.Models;


namespace iS3_DataManager.ViewManager
{
    /// <summary>
    /// change dataGrid style by check result
    /// </summary>
    public class MyButton:Button
    {
       public DataFileService _dfs;
    }
    public class ChangeStyle
    {
        DataGrid DataDG;
        DataTable dataTable;
        Models.StandardDef standard;
        SetSelectedItemDelegate selectDelegate;
        public  List<int> IDindex;
        public ChangeStyle(DataTable dataTable, ref DataGrid dataGrid, Models.StandardDef standardDef)
        {
            DataDG = dataGrid;
            this.dataTable = dataTable;
            standard = standardDef;
            selectDelegate = new SetSelectedItemDelegate(SetSelectedItemInBackground);
        }
        private void AddButton(int i, int j)
        {
            if (i < this.DataDG.Items.Count)
            {
                DataRowView drv = DataDG.Items[i] as DataRowView;
                DataGridRow row = GetRow(DataDG, i);
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(j);

                DGObjectDef objectDef = standard.GetDGObjectDefByName(dataTable.TableName);
                DataFileService dfs = new DataFileService(objectDef.Code, IDindex[i]);

                StackPanel _stackpanel = new StackPanel();
                _stackpanel.Orientation = Orientation.Horizontal;

                MyButton _button1 = new MyButton();
                _button1.Content = "下载附件";
                _button1._dfs = dfs;
                _button1.Click += _button1._dfs.Downloadfile;

                MyButton _button2 = new MyButton();
                _button2.Content = "上传附件";
                _button2._dfs = dfs;
                _button2.Click += _button2._dfs.Uploadfile;

                _stackpanel.Children.Add(_button2);
                _stackpanel.Children.Add(_button1);
                cell.Content = _stackpanel;
            }
        }


        public DataGrid Addattachment()
        {
            Models.DGObjectDef dGObject = standard.GetDGObjectDefByName(dataTable.TableName);
            int rowNum = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    
                    int columnNum = 0;
                    foreach (Models.PropertyMeta meta in dGObject.PropertyContainer)
                    {
                        if (meta.LangStr.Contains("关联"))
                        {
                            AddButton(rowNum, columnNum);
                        }
                        columnNum++;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }
                rowNum++;
            }
            return DataDG;
        }
        public DataGrid RefreshStyle()
        {

            Models.DGObjectDef dGObject = standard.GetDGObjectDefByName(dataTable.TableName);
            int rowNum = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    if (rowNum == 0) { rowNum = 1; continue; }
                    int columnNum = 0;
                    foreach (Models.PropertyMeta meta in dGObject.PropertyContainer)
                    {
                        if (meta.RegularExp != null)
                        {
                            var data = row[meta.LangStr].ToString();
                            bool reult1 = (data != "" & data != null);
                            bool result = Regex.IsMatch(row[meta.LangStr].ToString(), meta.RegularExp);
                            if (reult1 & !result)
                            {
                                Check(rowNum, columnNum);
                            }
                            if ((meta.IsKey == true | meta.Nullable == false) & (row[meta.LangStr].ToString() == null | row[meta.LangStr].ToString() == "")) CheckIfEmpty(rowNum, columnNum);
                        }
                        else if ((meta.IsKey == true | meta.Nullable == false) & (row[meta.LangStr].ToString() == null | row[meta.LangStr].ToString() == "")) CheckIfEmpty(rowNum, columnNum);
                        columnNum++;
                    }
                }
                catch (Exception ex)
                {
                    rowNum++;
                    continue;
                }
                rowNum++;
            }
            return DataDG;

        }

        private void Check(int i, int j)
        {
            if (i < this.DataDG.Items.Count)
            {
                DataRowView drv = DataDG.Items[i] as DataRowView;
                DataGridRow row = GetRow(DataDG, i);
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(j);

                cell.Background = new SolidColorBrush(Colors.Red);

            }
        }
        private void CheckIfEmpty(int i, int j)
        {
            if (i < this.DataDG.Items.Count)
            {
                DataRowView drv = DataDG.Items[i] as DataRowView;
                DataGridRow row = GetRow(DataDG, i);
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(j);
                cell.Background = new SolidColorBrush(Colors.Yellow);

            }
        }
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T childContent = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                childContent = v as T;
                if (childContent == null)
                {
                    childContent = GetVisualChild<T>(v);
                }
                if (childContent != null)
                {
                    break;
                }
            }
            return childContent;
        }
        public DataGridRow GetRow(DataGrid datagrid, int columnIndex)
        {
            DataGridRow row = datagrid.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridRow;
            if (row == null)
            {
                datagrid.Dispatcher.Invoke(selectDelegate, datagrid, columnIndex);
                row = datagrid.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridRow;
            }
            return row;
        }
        delegate void SetSelectedItemDelegate(DataGrid datagrid, int columnIndex);
        private void SetSelectedItemInBackground(DataGrid datagrid, int columnIndex)
        {
            datagrid.ScrollIntoView(datagrid.Items[columnIndex]);
            datagrid.UpdateLayout();
            DataGridRow row = datagrid.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridRow;
        }
    }
}
