using iS3.Core.Client;
using iS3.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace iS3.Client.Controls
{
    /// <summary>
    /// 通用的对象属性设置窗口
    /// </summary>
    public partial class CommonPropertyWin : Window
    {
        //对象对应的属性列表
        List<PropertyDef> _propertyDefs;
        //属性对应的输入框（先用TextBox，后需要修改成对应的控件类型）
        Dictionary<int, TextBox> TBDict = new Dictionary<int, TextBox>();

        Type _type;


        public EventHandler<DGObject> DGObjectHandler;
        string _domain;
        string _objType;


        ObjEditorDef objEditorDef;
        public CommonPropertyWin(Type type)
        {
            InitializeComponent();
            _type = type;
            Loaded += CommonPropertyWin_Loaded;
        }
        public CommonPropertyWin(string domain, string objType)
        {
            InitializeComponent();
            _domain = domain;
            _objType = objType;
            if (_domain == null)
                return;
            //属性字段是否显示，可输入
            if (DllImport.domainExtension.ContainsKey(_domain))
            {
                //objEditorDef = DllImport.domainExtension[_domain].objEditorDef(_objType);
            }
            _type = iS3Property.GetType(domain, objType);
            Loaded += CommonPropertyWin_Loaded;
        }
        private void CommonPropertyWin_Loaded(object sender, RoutedEventArgs e)
        {
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(_type);
            _propertyDefs = mi.Invoke(new iS3Property(), new object[] { Activator.CreateInstance(_type) }) as List<PropertyDef>;
            PropertyHolder.Children.Clear();
            for (int i = 1; i < PropertyTC.Items.Count; i++)
            {
                PropertyTC.Items.RemoveAt(1);
            }
            foreach (PropertyDef def in _propertyDefs)
            {
                ObjectsDefinition _objdef = Globals.project.domains.FirstOrDefault(x => x.name == _domain).objectsDefinitions.FirstOrDefault(x => x.Type == _objType);
                DGObjectMeta judgeobj = _objdef.Metas.FirstOrDefault(x => x.PropertyName == def.key);
                if (null != judgeobj)
                    AddStackPanel(judgeobj,def);
            }
        }
        public void AddStackPanel(DGObjectMeta _meta,PropertyDef def)
        {            
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            TextBlock keyTB = new TextBlock() { Text = _meta.ChsName };
            keyTB.Width = 150;
            stackPanel.Children.Add(keyTB);
            TextBox valueTB = new TextBox() { Text = def.value };
            TBDict[def.id] = valueTB;
            valueTB.Width = 200;
            stackPanel.Children.Add(valueTB);
            PropertyHolder.Children.Add(stackPanel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<PropertyDef> propertyDefs = new List<PropertyDef>();
            PropertyDef def = JsonConvert.DeserializeObject<PropertyDef>(JsonConvert.SerializeObject((sender as Button).DataContext));

            Type objType = iS3Property.GetType(_domain, def.type.Name);
            if (objType != null)
            {
                iS3Property iS3Property = new iS3Property();
                Type _t = iS3Property.GetType();
                MethodInfo mi = _t.GetMethod("GetProperty").MakeGenericMethod(objType);
                propertyDefs = mi.Invoke(iS3Property, new object[] { Activator.CreateInstance(objType) }) as List<PropertyDef>;
                CommonPropertyWin commonPropertyWin = new CommonPropertyWin(_domain, _objType);
                commonPropertyWin.Title = (sender as MenuItem).Tag.ToString();
                commonPropertyWin.Show();
            }
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var obj = iS3Property.GetInstance(_domain, _objType);
            Type type = iS3Property.GetType(_domain, _objType);
            foreach (PropertyDef def in _propertyDefs)
            {
                PropertyInfo info = type.GetProperty(def.key); //获取指定名称的属性
                if (TBDict.ContainsKey(def.id))
                {
                    string value = TBDict[def.id].Text.ToString();
                    if (!info.PropertyType.IsGenericType)
                    {
                        //非泛型
                        info.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, info.PropertyType), null);
                    }
                    else
                    {
                        //泛型Nullable<>
                        Type genericTypeDefinition = info.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            info.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(info.PropertyType)), null);
                        }
                    }
                }

            }
            DGObject _obj = await RepositoryForClient.Create(obj as DGObject, _domain, _objType);
            if (DGObjectHandler != null)
            {
                DGObjectHandler(this, _obj);
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string resultFile;
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                resultFile = openFileDialog1.FileName;
                OpenCSVFile(resultFile);
                this.Close();
            }

        }
        private async void OpenCSVFile(string filepath)
        {
            string strpath = filepath; //csv文件的路径
            try
            {
                int intColCount = 0;
                bool blnFlag = true;

                string strline;
                string[] aryline;
                StreamReader mysr = new StreamReader(strpath, System.Text.Encoding.Default);
                Dictionary<string, int> Propertyindex = new Dictionary<string, int>();
                while ((strline = mysr.ReadLine()) != null)
                {
                    aryline = strline.Split(new char[] { ',' });
                    intColCount = aryline.Length;

                    //给属性建立索引，可以根据属性名找到对应的列
                    if (blnFlag)
                    {
                        blnFlag = false;
                        for (int i = 0; i < aryline.Length; i++)
                        {
                            Propertyindex[aryline[i]] = i;
                        }
                    }
                    else
                    {
                        var obj = iS3Property.GetInstance(_domain, _objType);
                        Type type = iS3Property.GetType(_domain, _objType);
                        foreach (PropertyDef def in _propertyDefs)
                        {
                            PropertyInfo info = type.GetProperty(def.key); //获取指定名称的属性
                            if (Propertyindex.ContainsKey(def.key))
                            {
                                var value = aryline[Propertyindex[def.key]];
                                if (!info.PropertyType.IsGenericType)
                                {
                                    //非泛型
                                    info.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, info.PropertyType), null);
                                }
                                else
                                {
                                    //泛型Nullable<>
                                    Type genericTypeDefinition = info.PropertyType.GetGenericTypeDefinition();
                                    if (genericTypeDefinition == typeof(Nullable<>))
                                    {
                                        info.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(info.PropertyType)), null);
                                    }
                                }
                            }

                        }
                        DGObject _obj = await RepositoryForClient.Create(obj as DGObject, _domain, _objType);
                        if (DGObjectHandler != null)
                        {
                            DGObjectHandler(this, _obj);
                        }

                    }
                }


            }
            catch (Exception e)
            {


            }
        }
    }
}
