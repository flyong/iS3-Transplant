using System.Windows;
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Construction.Model;
using iS3.Structure.Model;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Reflection;
using System.ComponentModel;
using iS3.Core.Client.Service;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace RTM_Tool
{
    /// <summary>
    /// TunnelFaceinfo.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class LiningPredictionWindow : Window
    {
        public Project _prj { get; set; }
        public IMainFrame mainFrame { get; set; }
        public Domain _currentDoamin { get; set; }
        public DGObjects _getDGObjects { get; set; }
        public List<ACHE> ache_objList { get; set; }
        public List<CHAG> chag_objList { get; set; }
        public List<MILI> mili_objList { get; set; }
        public string design_type;
        public Pile tunnelpile;
        public List<string> rec_type, similar_section;
        public LiningPredictionWindow()
        {
            InitializeComponent();
            Loaded += LiningPredictionWindow_Loaded;
        }
        public List<T> Transfer<T>(List<DGObject> objList) where T: class
        {
            List<T> list = new List<T>();
            foreach (DGObject _obj in objList)
            {
                list.Add(_obj as T);
            }
            return list;
        }
        private void LiningPredictionWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _prj = Globals.project;
            mainFrame = Globals.mainFrame;

            _currentDoamin = _prj.getDomain("Construction");
            _getDGObjects = _currentDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
            //ache_objList = _getDGObjects.objContainer.Cast<ACHE>().ToList();
            ache_objList = Transfer<ACHE>(_getDGObjects.objContainer);
            _getDGObjects = _currentDoamin.DGObjectsList.Where(x => x.definition.Type == "CHAG").FirstOrDefault();
            //chag_objList = _getDGObjects.objContainer.Cast<CHAG>().ToList();
            chag_objList = Transfer<CHAG>(_getDGObjects.objContainer);

            _currentDoamin = _prj.getDomain("Structure");
            _getDGObjects = _currentDoamin.DGObjectsList.Where(x => x.definition.Type == "MILI").FirstOrDefault();
            //mili_objList = _getDGObjects.objContainer.Cast<MILN>().ToList();
            //use this func
            mili_objList = Transfer<MILI>(_getDGObjects.objContainer);

            DateTime latesttime = new DateTime(2000, 1, 1, 0, 0, 0);
            //寻找施工进度最新时间
            foreach (ACHE obj in ache_objList)
            {
                if (null != obj.PROG_DATE)
                {
                    DateTime temp = Convert.ToDateTime(obj.PROG_DATE);
                    if (DateTime.Compare(latesttime, temp) < 0)
                        latesttime = temp;
                }

            }
            //获取掌子面列表
            List<string> tunnelfacelist = new List<string>();
            foreach (ACHE obj in ache_objList)
            {
                if (obj.PROG_DATE == latesttime)
                {
                    string st = obj.PROG_SGJD;
                    Pile judgepile = DrawObjects.getSectionPos(st);
                    if (null != judgepile)
                        tunnelfacelist.Add(st);
                }
            }
            tunnelfacebox.ItemsSource = tunnelfacelist;

        }


        private void PredictLining(object sender, RoutedEventArgs e)
        {
            if (null == tunnelpile)
                return;
            rec_type = new List<string>();
            similar_section = new List<string>();
            foreach (MILI obj in mili_objList)
            {
                Pile t1 = DrawObjects.getSectionPos(obj.MILI_STAR);
                Pile t2 = DrawObjects.getSectionPos(obj.MILI_END);

                if ((obj.MILI_LNTY != design_type) || (t1.tunnelpart != tunnelpile.tunnelpart))
                    continue;

                //判断是否为已施工段
                if ((tunnelpile.sectionnumber == "S1") || (tunnelpile.sectionnumber == "S2"))
                {
                    if (t1.pilepoint > tunnelpile.pilepoint)
                        continue;
                }
                else
                {
                    if (t2.pilepoint < tunnelpile.pilepoint)
                        continue;
                }

                foreach (CHAG obj1 in chag_objList)
                {
                    Pile _tp = DrawObjects.getSectionPos(obj1.CHAG_CHAI);
                    //找已经施工的且相同设计衬砌类型的施工段
                    if ((_tp.startpile >= t1.pilepoint) && (_tp.endpile <= t2.pilepoint) && (_tp.tunnelpart == t1.tunnelpart))
                    {
                        if ((tunnelpile.sectionnumber == "S1") || (tunnelpile.sectionnumber == "S2"))
                        {
                            if (_tp.endpile > tunnelpile.pilepoint)
                                continue;
                        }
                        else
                        {
                            if (_tp.startpile < tunnelpile.pilepoint)
                                continue;
                        }
                        if (!judgeliningtype(obj1.CHAG_PRES))
                            continue;
                        if (!rec_type.Contains(obj1.CHAG_PRES))
                            rec_type.Add(obj1.CHAG_PRES);
                        if (!similar_section.Contains(obj1.CHAG_CHAI))
                            similar_section.Add(obj1.CHAG_CHAI);

                    }
                }
            }

            if (rec_type.Count == 0)
                rec_type.Add("建议采取设计衬砌类型");
            lininglist.ItemsSource = rec_type;

            if (similar_section.Count == 0)
                similar_section.Add("无相似施工段变更记录");
            similarlining.ItemsSource = similar_section;

        }

        public bool judgeliningtype(string st)
        {
            if (!st.StartsWith("S"))
                return false;
            return true;
        }
        private void tuennalfacebox_changed(object sender, SelectionChangedEventArgs e)
        {
            string _facepile = tunnelfacebox.SelectedValue.ToString();
            tunnelpile = DrawObjects.getSectionPos(_facepile);
            tunnelpile.sectionnumber = DrawObjects.getrightSectionnumber(tunnelpile.pilepoint);
            //找到该桩号的设计衬砌类型
            foreach (MILI obj in mili_objList)
            {
                Pile t1 = DrawObjects.getSectionPos(obj.MILI_STAR);
                Pile t2 = DrawObjects.getSectionPos(obj.MILI_END);

                if (t1.tunnelpart != tunnelpile.tunnelpart)
                    continue;
                if ((t1.pilepoint <= tunnelpile.pilepoint) && (t2.pilepoint >= tunnelpile.pilepoint))
                {
                    design_type = obj.MILI_LNTY;
                    break;
                }
            }
            disgntype.Text = design_type;
        }
    }
}