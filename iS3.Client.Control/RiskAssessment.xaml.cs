using System.Windows;
using System.Windows.Controls;
using iS3.Core.Client;
using iS3.Core.Model;
using iS3.Client;
using System.Collections.Generic;
using System;
using iS3.Draw;
using System.Reflection;
using System.Windows.Data;
using System.ComponentModel;

namespace iS3.Client.Controls
{
    /// <summary>
    /// RiskAssessment.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class RiskAssessment : Window
    {
        public RiskAssessment()
        {
            InitializeComponent();
            Loaded += RiskAssessment_Loaded;

            //g1.SetBinding(TextBox.TextProperty, new Binding("value1")
            //{
            //    RelativeSource=new RelativeSource(RelativeSourceMode.FindAncestor,typeof(Window),1)
            //});


        }

        private void RiskAssessment_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public decimal risk_position;
        public decimal totalresult;


        private decimal getvalue1()
        {

            decimal res = 0;
            Dictionary<decimal, List<decimal>> value1dic = new Dictionary<decimal, List<decimal>>();
            value1dic[1] = new List<decimal> { 7880 };
            value1dic[2] = new List<decimal> { 12900 };
            value1dic[3] = new List<decimal> { 3451, 3200 };
            value1dic[5] = new List<decimal> { 10820 };
            foreach (KeyValuePair<decimal, List<decimal>> kvp in value1dic)
            {
                bool flag = false;
                foreach (decimal j in kvp.Value)
                {
                    if ((risk_position >= j - 40) && (risk_position <= j + 40))
                    {
                        flag = true;
                        res = kvp.Key;
                        break;
                    }
                }
                if (flag)
                    break;
            }
            return res;
        }
        private decimal getvalue2()
        {
            string domain = "Geology";
            string objType_name = "AGEO";
            Pile ageo_mileage;
            DGObjects objs = Globals.project.objsDefIndex[objType_name];

            Type objType = iS3Property.GetType(domain, objType_name);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(objType);



            foreach (DGObject ageo in objs.objContainer)
            {
                List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { ageo }) as List<PropertyDef>;
                string t = _propertyDefs.Find(s => s.key.Equals("AGEO_DSRG")).value;

                if ((t == null) || (t == ""))
                    continue;
                string t1 = "";
                if (t.Contains("左"))
                    t1 = t.Split('左')[0];
                if (t.Contains("右"))
                    t1 = t.Split('右')[0];
                try
                {
                    ageo_mileage = DrawObjects.getSectionPos(t1);

                    bool pos_flag = false;
                    if (ageo_mileage.piletype == Piletype.point)
                    {
                        if ((risk_position >= ageo_mileage.pilepoint - 40) && (risk_position <= ageo_mileage.pilepoint + 40))
                            pos_flag = true;
                    }
                    else
                    {
                        if ((risk_position >= ageo_mileage.startpile) && (risk_position <= ageo_mileage.endpile))
                            pos_flag = true;
                    }

                    if (pos_flag == true)
                    {
                        string st1, st2;
                        st1 = _propertyDefs.Find(s => s.key.Equals("AGEO_TYPE")).value;
                        st2 = _propertyDefs.Find(s => s.key.Equals("AGEO_LAWD")).value;
                        if ((st2 == null) || (st1 == null))
                            continue;
                        if ((st1 == "溶洞") || (st1 == "岩溶漏斗"))
                        {
                            decimal dis = Convert.ToDecimal(st2);
                            if (dis < 8)
                            {
                                return 3;
                            }
                            else
                            {
                                if (dis < 24)
                                {
                                    return 2;
                                }
                                else
                                {
                                    return 1;
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }
            return 0;
        }
        private decimal getvalue3()
        {
            string domain = "Geology";
            string objType_name = "AGEO";
            DGObjects objs = Globals.project.objsDefIndex[objType_name];

            Type objType = iS3Property.GetType(domain, objType_name);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(objType);



            foreach (DGObject ageo in objs.objContainer)
            {
                List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { ageo }) as List<PropertyDef>;
                string t = _propertyDefs.Find(s => s.key.Equals("AGEO_DSRG")).value;

                if ((t == null) || (t == ""))
                    continue;
                string t1 = "";
                if (t.Contains("左"))
                    t1 = t.Split('左')[0];
                if (t.Contains("右"))
                    t1 = t.Split('右')[0];
                Pile ageo_mileage;
                ageo_mileage = DrawObjects.getSectionPos(t1);
                bool pos_flag = false;
                if (ageo_mileage.piletype == Piletype.point)
                {
                    if ((risk_position >= ageo_mileage.pilepoint - 40) && (risk_position <= ageo_mileage.pilepoint + 40))
                        pos_flag = true;
                }
                else
                {
                    if ((risk_position >= ageo_mileage.startpile) && (risk_position <= ageo_mileage.endpile))
                        pos_flag = true;
                }

                if (pos_flag == true)
                {
                    string st1, st2;
                    st1 = _propertyDefs.Find(s => s.key.Equals("AGEO_TYPE")).value;
                    //st2 = _propertyDefs.Find(s => s.key.Equals("AGEO_FILL")).value;
                    st2 = null;
                    if ((st2 == null) || (st1 == null))
                        continue;
                    if ((st1 == "溶洞") || (st1 == "岩溶漏斗"))
                    {
                        if (st2 == "全填充")
                        {
                            return 3;
                        }
                        else
                        {
                            if (st2 == "半填充")
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }

                }
            }
            return 0;
        }

        private decimal getvalue4()
        {
            string domain = "Environment";
            string objType_name = "SWSO";
            DGObjects objs = Globals.project.objsDefIndex[objType_name];

            Type objType = iS3Property.GetType(domain, objType_name);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(objType);

            foreach (DGObject ageo in objs.objContainer)
            {
                List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { ageo }) as List<PropertyDef>;
                string t = _propertyDefs.Find(s => s.key.Equals("SWSO_NAME")).value;
                if (t != null)
                    return 3;
            }
            return 0;
        }

        private decimal getvalue5()
        {
            string domain = "Construction";
            string objType_name = "SKTH";
            DGObjects objs = Globals.project.objsDefIndex[objType_name];

            Type objType = iS3Property.GetType(domain, objType_name);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(objType);

            foreach (DGObject ageo in objs.objContainer)
            {
                List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { ageo }) as List<PropertyDef>;
                string t1 = _propertyDefs.Find(s => s.key.Equals("SKTH_CHAI")).value;

                Pile ageo_mileage;
                if ((t1 == null) || (t1 == ""))
                    continue;
                ageo_mileage = DrawObjects.getSectionPos(t1);
                bool pos_flag = false;
                if (ageo_mileage.piletype == Piletype.point)
                {
                    if ((risk_position >= ageo_mileage.pilepoint - 40) && (risk_position <= ageo_mileage.pilepoint + 40))
                        pos_flag = true;
                }
                else
                {
                    if ((risk_position >= ageo_mileage.startpile) && (risk_position <= ageo_mileage.endpile))
                        pos_flag = true;
                }

                if (pos_flag == true)
                {
                    string st1;
                    st1 = _propertyDefs.Find(s => s.key.Equals("SKTH_WATE")).value;

                    if (st1 == null)
                        continue;
                    if (st1.Contains("潮湿"))
                    {
                        return 1;
                    }
                    else
                    {
                        if (st1.Contains("稍湿"))
                        {
                            return 2;
                        }
                        else
                            if (st1.Contains("出水"))
                            return 3;
                    }
                }
            }
            return 0;
        }
        private decimal getvalue6()
        {
            string domain = "Construction";
            string objType_name = "ASP";
            DGObjects objs = Globals.project.objsDefIndex[objType_name];

            Type objType = iS3Property.GetType(domain, objType_name);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(objType);

            foreach (DGObject ageo in objs.objContainer)
            {
                List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { ageo }) as List<PropertyDef>;
                string t1 = _propertyDefs.Find(s => s.key.Equals("ASP_INTE")).value;
                if ((t1 == null) || (t1 == ""))
                    continue;
                Pile ageo_mileage;
                ageo_mileage = DrawObjects.getSectionPos(t1);

                bool pos_flag = false;
                if (ageo_mileage.piletype == Piletype.point)
                {
                    if ((risk_position >= ageo_mileage.pilepoint - 40) && (risk_position <= ageo_mileage.pilepoint + 40))
                        pos_flag = true;
                }
                else
                {
                    if ((risk_position >= ageo_mileage.startpile) && (risk_position <= ageo_mileage.endpile))
                        pos_flag = true;
                }

                if (pos_flag == true)
                {
                    string st1;
                    st1 = _propertyDefs.Find(s => s.key.Equals("ASP_SUPP")).value;

                    if (st1 == null)
                        continue;
                    if (st1.Contains("无"))
                    {
                        return 3;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }
        private decimal getvalue7()
        {
            string domain = "Construction";
            string objType_name = "SCHE";
            DGObjects objs = Globals.project.objsDefIndex[objType_name];

            Type objType = iS3Property.GetType(domain, objType_name);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(objType);
            Pile ageo_mileage;

            foreach (DGObject ageo in objs.objContainer)
            {
                List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { ageo }) as List<PropertyDef>;

                string st1, st2;
                st1 = _propertyDefs.Find(s => s.key.Equals("PROG_CCJD")).value;
                st2 = _propertyDefs.Find(s => s.key.Equals("PROG_ECJD")).value;
                if ((st1 == null) || (st2 == null))
                    continue;

                ageo_mileage = DrawObjects.getSectionPos(st1);
                decimal v1 = ageo_mileage.pilepoint;
                ageo_mileage = DrawObjects.getSectionPos(st2);
                decimal v2 = ageo_mileage.pilepoint;

                if (Math.Abs(v1 - v2) > 120)
                    return 2;

            }
            return 0;
        }
        private decimal getvalue8()
        {
            string domain = "Construction";
            string objType_name = "SKTH";
            DGObjects objs = Globals.project.objsDefIndex[objType_name];

            Type objType = iS3Property.GetType(domain, objType_name);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(objType);

            foreach (DGObject ageo in objs.objContainer)
            {
                List<PropertyDef> _propertyDefs = mi.Invoke(new iS3Property(), new object[] { ageo }) as List<PropertyDef>;
                string t1 = _propertyDefs.Find(s => s.key.Equals("SKTH_CHAI")).value;

                Pile ageo_mileage;
                if ((t1 == null) || (t1 == ""))
                    continue;
                ageo_mileage = DrawObjects.getSectionPos(t1);
                bool pos_flag = false;
                if (ageo_mileage.piletype == Piletype.point)
                {
                    if ((risk_position >= ageo_mileage.pilepoint - 40) && (risk_position <= ageo_mileage.pilepoint + 40))
                        pos_flag = true;
                }
                else
                {
                    if ((risk_position >= ageo_mileage.startpile) && (risk_position <= ageo_mileage.endpile))
                        pos_flag = true;
                }

                if (pos_flag == true)
                {
                    string st1;
                    st1 = _propertyDefs.Find(s => s.key.Equals("SKTH_WATG")).value;

                    if (st1 == null)
                        continue;
                    if (st1.Contains("淋雨状"))
                    {
                        return 3;
                    }
                    else
                    {
                        if (st1.Contains("大股"))
                        {
                            return 5;
                        }
                    }
                }
            }
            return 0;
        }
        private decimal getvalue9()
        {
            string domain = "Construction";
            string objType_name = "GPRF";
            DGObjects objs = Globals.project.objsDefIndex[objType_name];

            Type objType = iS3Property.GetType(domain, objType_name);
            MethodInfo mi = typeof(iS3Property).GetMethod("GetProperty").MakeGenericMethod(objType);

            foreach (DGObject ageo in objs.objContainer)
            {


            }
            return 0;
        }

        private decimal getvalue10()
        {
            return 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index1 = sect1.SelectedIndex;
            if (index1 == 0)
            { mileage.Text = "K4+020"; }
            else if (index1 == 1)
            { mileage.Text = "K4+715"; }
            else if (index1 == 2)
            { mileage.Text = "K0+180"; }
            else if (index1 == 3)
            { mileage.Text = "YK10+820"; }
            string t1 = mileage.Text;
            Pile ageo_mileage;
            ageo_mileage = DrawObjects.getSectionPos(t1);
            risk_position = ageo_mileage.pilepoint;
            g1.Content = getvalue1().ToString();
            g2.Content = getvalue2().ToString();
            g3.Content = getvalue3().ToString();
            g4.Content = getvalue4().ToString();
            g5.Content = getvalue5().ToString();
            g6.Content = getvalue6().ToString();
            g7.Content = getvalue7().ToString();
            g8.Content = getvalue8().ToString();
            g9.Content = getvalue9().ToString();
            g10.Content = getvalue10().ToString();

        }


        private void start(object sender, RoutedEventArgs e)

        {
            totalresult = getvalue1() + getvalue2() + getvalue3() + getvalue4() + getvalue5() + getvalue6() + getvalue7() + getvalue8() + getvalue9() + getvalue10();
            if (totalresult > 22)
            {
                grade.Content = "极高风险（IV级）";
                advice.Content = "建议加强注浆,及时施做超前预报";
            }
            else if (totalresult < 8)
            {
                grade.Content = "低度风险（I级）";
                advice.Content = "设计施工方案合理";
            }
            else grade.Content = "中度风险（II级）"; advice.Content = "设计施工方案基本合理";

        }




    }
}