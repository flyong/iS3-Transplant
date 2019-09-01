using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace iS3.Client.Controls.Converts
{
    public class StringToImageConvert : IValueConverter
    {
        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path;
            bool hasChild = (bool)value;
            if (hasChild)
            {
                path = "pack://application:,,,/iS3.Client;component/Images/Docu.png";
            }
            else
            {
                path = "pack://application:,,,/iS3.Client;component/Images/File.png";
            }
          
            if (!string.IsNullOrEmpty(path))
            {
                return new BitmapImage(new Uri(path, UriKind.Absolute));
            }
            else
            {
                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        #endregion

    }
}
