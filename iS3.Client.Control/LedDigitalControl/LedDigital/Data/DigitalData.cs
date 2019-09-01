using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Data
{
    public class DigitalData
    {
        #region Fields

        private Path topSegment;
        private Path upLeftSegment;
        private Path upRightSegment;
        private Path middleSegment;
        private Path downLeftSegment;
        private Path downRightSegment;
        private Path bottomSegment;

        private Path dotSegment;
        private Path colonUpSegment;
        private Path colonDownSegment;

        #endregion

        #region Properties

        public Path TopSegment
        {
            get
            {
                return topSegment;
            }

            set
            {
                topSegment = value;
            }
        }

        public Path UpLeftSegment
        {
            get
            {
                return upLeftSegment;
            }

            set
            {
                upLeftSegment = value;
            }
        }

        public Path UpRightSegment
        {
            get
            {
                return upRightSegment;
            }

            set
            {
                upRightSegment = value;
            }
        }

        public Path MiddleSegment
        {
            get
            {
                return middleSegment;
            }

            set
            {
                middleSegment = value;
            }
        }

        public Path DownLeftSegment
        {
            get
            {
                return downLeftSegment;
            }

            set
            {
                downLeftSegment = value;
            }
        }

        public Path DownRightSegment
        {
            get
            {
                return downRightSegment;
            }

            set
            {
                downRightSegment = value;
            }
        }

        public Path BottomSegment
        {
            get
            {
                return bottomSegment;
            }

            set
            {
                bottomSegment = value;
            }
        }

        public Path DotSegment
        {
            get
            {
                return dotSegment;
            }

            set
            {
                dotSegment = value;
            }
        }

        public Path UpColonSegment
        {
            get
            {
                return colonUpSegment;
            }

            set
            {
                colonUpSegment = value;
            }
        }

        public Path DownColonSegment
        {
            get
            {
                return colonDownSegment;
            }

            set
            {
                colonDownSegment = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 设置segment的状态
        /// </summary>
        /// <param name="top"></param>
        /// <param name="upRight"></param>
        /// <param name="downRight"></param>
        /// <param name="bottom"></param>
        /// <param name="downLeft"></param>
        /// <param name="upLeft"></param>
        /// <param name="middle"></param>
        /// <param name="dot"></param>
        /// <param name="colon"></param>
        private void LightDigitalSegments(bool top, bool upRight, bool downRight, bool bottom,
            bool downLeft, bool upLeft, bool middle, bool dot, bool colon)
        {
            double ON = 1;
            double OFF = 0.05;

            TopSegment.Opacity = top ? ON : OFF;
            UpRightSegment.Opacity = upRight ? ON : OFF;
            DownRightSegment.Opacity = downRight ? ON : OFF;
            BottomSegment.Opacity = bottom ? ON : OFF;
            DownLeftSegment.Opacity = downLeft ? ON : OFF;
            UpLeftSegment.Opacity = upLeft ? ON : OFF;
            MiddleSegment.Opacity = middle ? ON : OFF;
            DotSegment.Opacity = dot ? ON : OFF;
            UpColonSegment.Opacity = DownColonSegment.Opacity = colon ? ON : OFF;           
        }

        /// <summary>
        /// 根据输入字符显示相应的字符
        /// </summary>
        /// <param name="digital"></param>
        public void DisplayDigital(string digital)
        {
            switch (digital)
            {
                case null:
                case " ":
                    LightDigitalSegments(false, false, false, false, false, false, false, false, false);
                    break;
                case "0":
                    LightDigitalSegments(true, true, true, true, true, true, false, false, false);
                    break;
                case "1":
                    LightDigitalSegments(false, true, true, false, false, false, false, false, false);
                    break;
                case "2":
                    LightDigitalSegments(true, true, false, true, true, false, true, false, false);
                    break;
                case "3":
                    LightDigitalSegments(true, true, true, true, false, false, true, false, false);
                    break;
                case "4":
                    LightDigitalSegments(false, true, true, false, false, true, true, false, false);
                    break;
                case "5":
                    LightDigitalSegments(true, false, true, true, false, true, true, false, false);
                    break;
                case "6":
                    LightDigitalSegments(true, false, true, true, true, true, true, false, false);
                    break;
                case "7":
                    LightDigitalSegments(true, true, true, false, false, false, false, false, false);
                    break;
                case "8":
                    LightDigitalSegments(true, true, true, true, true, true, true, false, false);
                    break;
                case "9":
                    LightDigitalSegments(true, true, true, true, false, true, true, false, false);
                    break;
                case "0.":
                    LightDigitalSegments(true, true, true, true, true, true, false, true, false);
                    break;
                case "1.":
                    LightDigitalSegments(false, true, true, false, false, false, false, true, false);
                    break;
                case "2.":
                    LightDigitalSegments(true, true, false, true, true, false, true, true, false);
                    break;
                case "3.":
                    LightDigitalSegments(true, true, true, true, false, false, true, true, false);
                    break;
                case "4.":
                    LightDigitalSegments(false, true, true, false, false, true, true, true, false);
                    break;
                case "5.":
                    LightDigitalSegments(true, false, true, true, false, true, true, true, false);
                    break;
                case "6.":
                    LightDigitalSegments(true, false, true, true, true, true, true, true, false);
                    break;
                case "7.":
                    LightDigitalSegments(true, true, true, false, false, false, false, true, false);
                    break;
                case "8.":
                    LightDigitalSegments(true, true, true, true, true, true, true, true, false);
                    break;
                case "9.":
                    LightDigitalSegments(true, true, true, true, false, true, true, true, false);
                    break;
                case ":":
                case "：":
                    LightDigitalSegments(false, false, false, false, false, false, false, false, true);
                    break;
                case "-":
                    LightDigitalSegments(false, false, false, false, false, false, true, false, false);
                    break;
                default:
                    throw new Exception("输入字符错误！");
            }
        }

        #endregion
    }
}
