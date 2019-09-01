using iS3.Client.Controls.LedDigitalControl.MVVMBase;
using iS3.Core.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using iS3.Client.Controls;

namespace iS3.Client
{
    internal class ToolsPanelViewModel
    {
        public ObservableCollection<Tab> Tabs { get; set; } = new ObservableCollection<Tab>();

        public ToolsPanelViewModel()
        {
            
        }
        public void Load(string projectID)
        {
            var doc = new XmlDocument();
            try
            {
                doc.Load(Runtime.dataPath + "//" + projectID + "//Tools.xml");
            }
            catch (Exception ex)
            {

            }

            var xn = doc.SelectSingleNode("Tabs");
            var tabs = xn.ChildNodes;
            foreach (var tabnode in tabs)
            {
                var tabElement = (XmlElement)tabnode;
                var tab = new Tab(tabElement.GetAttribute("Text"));

                foreach (var itemNode in tabElement.ChildNodes)
                {
                    var group = new Group();
                    var itemElement = (XmlElement)itemNode;
                    var item = new Item(itemElement.GetAttribute("Text"));
                    item.ImagePath = AppDomain.CurrentDomain.BaseDirectory + itemElement.GetAttribute("ImagePath");
                    item.DllPath = AppDomain.CurrentDomain.BaseDirectory + itemElement.GetAttribute("DllPath");
                    item.ClassName = itemElement.GetAttribute("ClassName");
                    item.Params= itemElement.GetAttribute("Params");
                    group.Items.Add(item);
                    tab.Groups.Add(group);
                }
                Tabs.Add(tab);
            }
        }
    }

    internal class Tab
    {
        public string Text { get; set; }
        public ObservableCollection<Group> Groups { get; set; } = new ObservableCollection<Group>();

        public Tab(string text)
        {
            Text = text;
        }
    }

    internal class Group
    {
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public string Text { get; set; }
    }

    internal class Item
    {
        public ICommand CustomCommand { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public string DllPath { get; set; }
        public string ClassName { get; set; }
        public string Params { get; set; }

        public Item(string text)
        {
            Text = text;
            CustomCommand = new DelegateCommand(Excuted);

        }
        
        private void Excuted(object obj)
        {
            var item = (Item)obj;
            string[] pathStrings = item.DllPath.Split('\\');
            string[] pathName = pathStrings[pathStrings.Length - 1].Split('.');
            switch (pathName[0])
            {
                case "Local":
                    this.GetType().GetMethod(pathName[pathName.Length - 1])?.Invoke(this, null);
                    break;

                default:
                    Assembly DLL;
                    try
                    {
                        DLL = Assembly.LoadFrom(item.DllPath);
                    }
                    catch (FileNotFoundException exception)
                    {
                        MessageBox.Show("Invalid!");
                        return;
                    }
                    //var tool = (Tools)DLL.CreateInstance(item.ClassName);
                    //foreach (var treeItem in tool.treeItems())
                    //    treeItem.func();
                    IToolPlugin tool = (IToolPlugin)DLL.CreateInstance(item.ClassName);
                    try
                    {
                        tool.Func(item.Params);
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
            }

        }
    }

    public class HierarchicalDataTemplate : System.Windows.HierarchicalDataTemplate
    {
    }
}
