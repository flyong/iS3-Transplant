using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace iS3.Core.Client.ViewModel
{
    public interface IDGObjectView
    {
        Task SetObjContent(DGObject model);
        EngineeringMap SetIt(DGObject model);
        UserControl ChartView();
    }
}
