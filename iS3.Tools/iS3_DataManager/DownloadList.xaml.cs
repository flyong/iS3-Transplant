using System;
using System.Collections.Generic;
using System.Linq;
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
using iS3_DataManager.Service;

namespace iS3_DataManager
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class DownloadList : Window
    {
        public List<Filename> Filelist { get; set; }
        DataFileService _parent;
        public DownloadList(DataFileService parent)
        {
            InitializeComponent();
            Filelist = new List<Filename>();
            _parent = parent;
            foreach (string st in parent.filenames)
            {
                Filename _filename = new Filename();
                _filename.Name = st;
                Filelist.Add(_filename);
            }
            DownloadDG.ItemsSource = Filelist;
            
        }


        private async void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DownloadDG.SelectedCells[0] == null)
                return;
            _parent.filenames = new List<string>();
            foreach (DataGridCellInfo cell_info in DownloadDG.SelectedCells)
            {
                Filename _selecteditem = cell_info.Item as Filename;
                _parent.filenames.Add(_selecteditem.Name);
            }
            await _parent.DownloadfileAsync();

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class Filename
    {
        public string Name { get; set; }
    }
}
