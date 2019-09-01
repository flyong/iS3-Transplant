using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.OpenXmlFormats.Wordprocessing;
using System.Windows.Forms;
using NPOI.XWPF.UserModel;
using System.Text.RegularExpressions;
using NPOI;

namespace iS3_DataManager.DataManager
{
    public class DataImporter_Word
    {
        Dictionary<string, string> regularExpression { get; set; }
        public DataImporter_Word()
        {
            regularExpression = new Dictionary<string, string>();
            regularExpression.Add("里程号", @"(起讫里程|预报段里程)(\S{5,18})，");
            regularExpression.Add("里程冠号", @"K\d+");
            regularExpression.Add("起始里程", @"\+\d+\～");
            regularExpression.Add("终止里程", @"(\+\d+\，)|(\+\d+\,)");
            regularExpression.Add("生成时间", @"\d+年\d+月\d+日");
            regularExpression.Add("风化程度", @"(全|弱|强|中等|微)\S(全|强|中等|弱|微)?(?:风化)");
            this.regularExpression = regularExpression;
        }
        public void OpenDoc()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word文件|*.docx;*.doc";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] files = ofd.FileNames;
                foreach (var path in files)
                {
                    //IWorkbook document = null;
                    if (path.IndexOf(".docx") > 0)
                    {
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                        XWPFDocument document = new XWPFDocument(fs);
                        fs.Close();
                        ReadDoc(document);
                    }
                    if (path.IndexOf(".doc") > 0)
                    {
                        //document = new HSSFWorkbook(new FileStream(RenameFile(path), FileMode.Open, FileAccess.Read));
                    }
                }
            }
            else
            {
                return;
            }
        }
        public void ReadDoc(XWPFDocument document)
        {
            
            int index = 0;
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (XWPFParagraph paragraph in document.Paragraphs)
            {
                if (index==0&ExtractMile(paragraph) != null)
                {
                    index = 1;
                }
                
            }
        }
        public string RenameFile(string oldPath)
        {
            try
            {
                string newpath = oldPath + "x";
                File.Move(oldPath, newpath);
                return newpath;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Extra Mile提取里程号
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        public string ExtractMile(XWPFParagraph paragraph)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            Regex regex = new Regex(regularExpression["里程号"]);
            Match match = regex.Match(paragraph.Text);
            if (match.Value.Length != 0)
            {
                return match.Value;
            }
            else
            {
                return null;
            }
            
        }
    }

   
}
