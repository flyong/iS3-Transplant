using System.Windows;
using iS3.Core.Client;
using iS3.Core.Model;
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
using iS3.Construction.Model;
using iS3.Structure.Model;

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
        public List<MILN> miln_objList { get; set; }
        public string design_type;
        public Pile tunnelpile;
        public List<string> rec_type, similar_section;
        public LiningPredictionWindow()
        {
            InitializeComponent();
            Loaded += LiningPredictionWindow_Loaded;
        }

        private void LiningPredictionWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _prj = Globals.project;
            mainFrame = Globals.mainFrame;

            _currentDoamin = _prj.getDomain("Construction");
            _getDGObjects = _currentDoamin.DGObjectsList.Where(x => x.definition.Type == "ACHE").FirstOrDefault();
            ache_objList = _getDGObjects.objContainer.Cast<ACHE>().ToList();
            _getDGObjects = _currentDoamin.DGObjectsList.Where(x => x.definition.Type == "CHAG").FirstOrDefault();
            chag_objList = _getDGObjects.objContainer.Cast<CHAG>().ToList();

            _currentDoamin = _prj.getDomain("Structure");
            _getDGObjects = _currentDoamin.DGObjectsList.Where(x => x.definition.Type == "MILN").FirstOrDefault();
            miln_objList = _getDGObjects.objContainer.Cast<MILN>().ToList();

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
            foreach (MILN obj in miln_objList)
            {
                Pile t1 = DrawObjects.getSectionPos(obj.MILN_STAR);
                Pile t2 = DrawObjects.getSectionPos(obj.MILN_END);
                if (obj.MILN_LNTY != design_type)
                    continue;

                //判断是否为已施工段
                if ((tunnelpile.sectionnumber == "S1") || (tunnelpile.sectionnumber == "S2"))
                {
                    if (t2.pilepoint > tunnelpile.pilepoint)
                        continue;
                }
                else
                {
                    if (t1.endpile < tunnelpile.pilepoint)
                        continue;
                }

                foreach (CHAG obj1 in chag_objList)
                {
                    Pile _tp = DrawObjects.getSectionPos(obj1.CHAG_CHAI);
                    //找已经施工的且相同设计衬砌类型的施工段
                    if ((_tp.startpile >= t1.pilepoint) || (_tp.endpile <= t2.pilepoint))
                    {
                        if (!rec_type.Contains(obj1.CHAG_PRES))
                            rec_type.Add(obj1.CHAG_PRES);
                        if (!similar_section.Contains(obj1.CHAG_CHAI))
                            similar_section.Add(obj1.CHAG_CHAI);

                    }
                }
                lininglist.Items.Clear();
                lininglist.ItemsSource = rec_type;

                similarlining.Items.Clear();
                similarlining.ItemsSource = similar_section;

            }

        }

        private void tuennalfacebox_changed(object sender, SelectionChangedEventArgs e)
        {
            string _facepile = tunnelfacebox.SelectedValue.ToString();
            tunnelpile = DrawObjects.getSectionPos(_facepile);
            tunnelpile.sectionnumber = DrawObjects.getrightSectionnumber(tunnelpile.pilepoint);
            //找到该桩号的设计衬砌类型
            foreach (MILN obj in miln_objList)
            {
                Pile t1 = DrawObjects.getSectionPos(obj.MILN_STAR);
                Pile t2 = DrawObjects.getSectionPos(obj.MILN_END);

                if (t1.tunnelpart != tunnelpile.tunnelpart)
                    continue;
                if ((t1.pilepoint <= tunnelpile.pilepoint) && (t2.pilepoint >= tunnelpile.pilepoint))
                {
                    design_type = obj.MILN_LNTY;
                    break;
                }
            }
            disgntype.Text = design_type;
        }
    }
}