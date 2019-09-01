using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iS3UnityLib.Model.Event
{

    public enum AxisSelect
    {
        X,
        Y,
        Z
    }

    public enum SliceType
    {
        ByNumber,
        Normal, //通过百分比进行切割
        ByLength
    }

    public enum SliceMode
    {
        Disposable, // 一次性切割
        Increase,
        Reduce
    }

    public enum SliceStyle
    {
        NormalPointOneTimeSlice,
        AxisPointOneTimeSlice,
        AxisPercentTimeSlice,
        AxisLengthTimeSlice,
        AxisPercentOneTimeSlice,
        StartEndPercentSlice
    }
    public class SliceObjEvent : UnityEvent
    {
        public UnityEventType MyEventType = UnityEventType.SliceObjEvent;

        public SliceStyle sliceStyle = SliceStyle.AxisPercentTimeSlice;

        public string path = string.Empty; // "a/b/c"

        public bool isWorldUV = true;  //  world/local position

        public AxisSelect axis = AxisSelect.X; //  选择坐标系 X/Y/Z

        public float timeAll = 0.0f;  //切割总时间

        public float percent = 0.0f; //要完成的进度

        //切割类型 
        public SliceType sliceType = SliceType.Normal;

        //按个数增长还是消隐或者一次性切割
        public SliceMode sliceMode = SliceMode.Disposable;

        /*以下为新增内容*/

        public bool isHolistic = false; // 是否包含子物体切割

        public float sliceLength = 0.0f; // 切割长度

        public Vector3 _normal; //切割的法线

        public Vector3 _slicePos; //切割的位置

        //切割后模块
        //默认切割的第一个颜色
        public float c1r;
        public float c1g;
        public float c1b;

        public float alpha1 = 1; //默认切割的第一个颜色的透明度

        //默认切割的第二个颜色
        public float c2r;
        public float c2g;
        public float c2b;
        public float alpha2 = 1; //默认切割的第二个颜色的透明度

        //alpha是否应用原物体
        public bool isUseAlpha = false;

        //起始切割百分比
        public float startPercent = 0.0f;

        public float endPercent = 0.0f;

        public SliceObjEvent(UnityEventType aEventType) : base(aEventType)
        {

        }


        //根据类型重写执行
        public override void UnityAction()
        {
      
        }
    }
}

