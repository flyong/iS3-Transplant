using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Client.Controls.LedDigitalControl.MVVMBase;
namespace iS3.Client.Controls.LedDigitalControl
{
    public class ViewModel:ViewModelBase
    {
        #region Fields
        //单例字段
        private static ViewModel _instance;
        //单例锁
        private static object _syncObj = new object();

        //digitalled显示值
        private string _ledDigitalValue;
        private string _ledDigitalValue1;
        //digital个数
        private int _digitalCount;

        #endregion

        #region Properties

        //单例实例属性
        public static ViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ViewModel();
                        }
                    }
                }
                return _instance;
            }
        }

        public string LedDigitalValue
        {
            get
            {
                return _ledDigitalValue;
            }
            set
            {
                _ledDigitalValue = value;
                RaisePropertyChanged("LedDigitalValue");
            }
        }

        public string LedDigitalValue1
        {
            get
            {
                return _ledDigitalValue1;
            }
            set
            {
                _ledDigitalValue1 = value;
                RaisePropertyChanged("LedDigitalValue1");
            }
        }

        public int DigitalCount
        {
            get { return _digitalCount; }
            set
            {
                _digitalCount = value;
                RaisePropertyChanged("DigitalCount");
            }
        }
        #endregion

        #region Constructors

        private ViewModel()
        {
        }

        #endregion
    }
}
