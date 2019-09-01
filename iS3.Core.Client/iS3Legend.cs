using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace iS3.Core.Client
{
    public class iS3Legned
    {
        //图例名称---例如施工进度图例
        public string legndTitle { get; set; }
        //标注列表
        public List<iS3Symbol> iS3SymbolList { get; set; }
        public iS3Legned()
        {
            legndTitle = "图例";
            iS3SymbolList = new List<iS3Symbol>();
        }
    }
    public class iS3Symbol
    {
        //标注颜色  
        //颜色枚举类-转字符串：Enum.GetName( typeof (Color), color);//推荐    using System.Windows.Media; 
        //字符串转颜色枚举类：(Color)Enum.Parse( typeof (Color), colorString);   
        public string colorName { get; set; }
        //标注类型
        public SymbolType symbolType { get; set; }
        //标注文字
        public string label { get; set; }

        //Icon类型的，图片来源；Images目录下
        public string refPath { get; set; }
    }
    public enum SymbolType
    {
        Rectangle,
        Circle,
        Triangle,
        Icon
    }
}
