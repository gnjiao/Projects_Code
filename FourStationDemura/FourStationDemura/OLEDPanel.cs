using IIXDeMuraApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourStationDemura
{
    public class OLEDPanel
    {
        /// <summary>
        /// 屏幕编号
        /// </summary>
        private string mPanelNumber;

        /// <summary>
        /// 屏幕编号
        /// </summary>
        public string PanelNumber
        {
            get { return mPanelNumber; }
            set { mPanelNumber = value; }
        }

        /// <summary>
        /// 屏幕是否有旋转动作
        /// </summary>
        private bool mIsRotate = false;

        /// <summary>
        /// 屏幕是否有旋转动作
        /// </summary>
        public bool IsRotate
        {
            get { return mIsRotate; }
            set { mIsRotate = value; }
        }

        /// <summary>
        /// 屏幕是否已经点灯
        /// </summary>
        private bool isPanelOn = false;

        /// <summary>
        /// 屏幕是否已经点灯
        /// </summary>
        public bool IsPanelOn
        {
            get { return isPanelOn; }
            set { isPanelOn = value; }
        }

        /// <summary>
        ///屏幕的位置，一个工位有三块屏 #1、#2、#3
        /// </summary>
        private string mPanelPos;

        /// <summary>
        ///屏幕的位置，一个工位有三块屏 #1、#2、#3
        /// </summary>
        public string PanelPos
        {
            get { return mPanelPos; }
            set { mPanelPos = value; }
        }

        /// <summary>
        /// 屏幕所在的工作位置，分别为#1、#2、#3、#4
        /// </summary>
        private string mPanelWorkPos;

        /// <summary>
        /// 屏幕所在的工作位置，分别为#1、#2、#3、#4
        /// </summary>
        public string PanelWorkPos
        {
            get { return mPanelWorkPos; }
            set { mPanelWorkPos = value; }
        }

        /// <summary>
        /// 屏幕在工作位置执行结果的状态
        /// </summary>
        private CmdResultCode mCmdResWork = CmdResultCode.Other;

        /// <summary>
        /// 屏幕在工作位置执行结果的状态
        /// </summary>
        public CmdResultCode CmdResWork
        {
            get { return mCmdResWork; }
            set { mCmdResWork = value; }
        }

        /// <summary>
        /// 当前工作位置绑定的IIX服务端
        /// </summary>
        private IDmrSvrApi mDmrSvrApi;

        /// <summary>
        /// 当前工作位置绑定的IIX服务端
        /// </summary>
        public IDmrSvrApi DmrSvrApi
        {
            get{ return mDmrSvrApi;}
            set {mDmrSvrApi = value; }
        }
    }
}
