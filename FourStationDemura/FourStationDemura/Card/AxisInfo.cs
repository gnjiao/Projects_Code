using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    /// <summary>
    /// 轴实体类
    /// </summary>
    public class AxisInfo
    {
        /// <summary>
        /// 控制卡卡号
        /// </summary>
        private ushort mCardID = 0;

        /// <summary>
        /// 控制卡卡号
        /// </summary>
        public ushort CardID
        {
            get { return mCardID; }
            set { mCardID = value; }
        }

        /// <summary>
        /// 轴编号
        /// </summary>
        private ushort mAxisNumber = 0;

        /// <summary>
        /// 轴编号
        /// </summary>
        public ushort AxisNumber
        {
            get { return mAxisNumber; }
            set { mAxisNumber = value; }
        }

        /// <summary>
        /// 轴别名
        /// </summary>
        private string mAxisName = "";

        /// <summary>
        /// 轴别名
        /// </summary>
        public string AxisName
        {
            get { return mAxisName; }
            set { mAxisName = value; }
        }

        /// <summary>
        /// 脉冲输出方式,取值范围0~6
        /// </summary>
        public ushort mOutmode = 0;

        /// <summary>
        /// 脉冲输出方式,取值范围0~6
        /// </summary>
        public ushort Outmode
        {
            get { return mOutmode; }
            set { mOutmode = value; }
        }

        /// <summary>
        /// 编码器器的计数方式0=非A/B相 (脉冲/方向)，1=1X A/B，2= 2X A/B，3= 4X A/B
        /// </summary>
        public ushort mMode = 0;

        /// <summary>
        /// 编码器器的计数方式0=非A/B相 (脉冲/方向)，1=1X A/B，2= 2X A/B，3= 4X A/B
        /// </summary>
        public ushort Mode
        {
            get { return mMode; }
            set { mMode = value; }
        }

        /// <summary>
        /// 起始速度
        /// </summary>
        public double mMinVel = 0;

        /// <summary>
        /// 起始速度
        /// </summary>
        public double MinVel
        {
            get { return mMinVel; }
            set { mMinVel = value; }
        }

        /// <summary>
        /// 运行速度
        /// </summary>
        public double mMaxVel = 0;

        /// <summary>
        /// 运行速度
        /// </summary>
        public double MaxVel
        {
            get { return mMaxVel; }
            set { mMaxVel = value; }
        }

        /// <summary>
        /// 加速度
        /// </summary>
        public double mAcc = 0;

        /// <summary>
        /// 加速度
        /// </summary>
        public double Acc
        {
            get { return mAcc; }
            set { mAcc = value; }
        }

        /// <summary>
        /// 减速度
        /// </summary>
        public double mDec = 0;

        /// <summary>
        /// 减速度
        /// </summary>
        public double Dec
        {
            get { return mDec; }
            set { mDec = value; }
        }

        /// <summary>
        /// S形曲线运动的轴号和S段比，取值范围0~0.5
        /// </summary>
        public double mS_Para = 0;

        /// <summary>
        /// S形曲线运动的轴号和S段比，取值范围0~0.5
        /// </summary>
        public double S_Para
        {
            get { return mS_Para; }
            set { mS_Para = value; }
        }

        /// <summary>
        /// 当前速度
        /// </summary>
        public double mCurrVel = 0;

        /// <summary>
        /// 当前速度
        /// </summary>
        public double CurrVel
        {
            get { return mCurrVel; }
            set { mCurrVel = value; }
        }

        /// <summary>
        ///（绝对/相对）位移值，单位：脉冲数
        /// </summary>
        private int mDist = 0;

        /// <summary>
        ///（绝对/相对）位移值，单位：脉冲数
        /// </summary>
        public int Dist
        {
            get { return mDist; }
            set { mDist = value; }
        }

        /// <summary>
        /// 位移模式设定：0表示相对位移，1表示绝对位移 
        /// </summary>
        private ushort mPosiMode = 0;

        /// <summary>
        /// 位移模式设定：0表示相对位移，1表示绝对位移 
        /// </summary>
        public ushort PosiMode
        {
            get { return mPosiMode; }
            set { mPosiMode = value; }
        }

        /// <summary>
        /// 绝对位置值 
        /// </summary>
        private int mCurrentPosition = 0;

        /// <summary>
        /// 绝对位置值
        /// </summary>
        public int CurrentPosition
        {
            get { return mCurrentPosition; }
            set { mCurrentPosition = value; }
        }

        /// <summary>
        /// 软限位使能， 0 –禁止； 1 –使能 
        /// </summary>
        public ushort mON_OFF = 0;

        /// <summary>
        /// 软限位使能， 0 –禁止； 1 –使能 
        /// </summary>
        public ushort ON_OFF
        {
            get { return mON_OFF; }
            set { mON_OFF = value; }
        }

        /// <summary>
        /// 比较源选择， 保留， 设置为指令脉冲
        /// </summar
        public ushort mSourceSel = 0;

        /// <summary>
        /// 比较源选择， 保留， 设置为指令脉冲
        /// </summary>
        public ushort SourceSel
        {
            get { return mSourceSel; }
            set { mSourceSel = value; }
        }

        /// <summary>
        /// 限位动作， 0 –急停， 1 –减速停 
        /// </summary>
        public ushort mSLAction = 0;

        /// <summary>
        /// 限位动作， 0 –急停， 1 –减速停 
        /// </summary>
        public ushort SLAction
        {
            get { return mSLAction; }
            set { mSLAction = value; }
        }

        /// <summary>
        /// 负限位值 
        /// </summary>
        public int mNLimit = 0;

        /// <summary>
        /// 负限位值 
        /// </summary>
        public int NLimit
        {
            get { return mNLimit; }
            set { mNLimit = value; }
        }

        /// <summary>
        /// 正限位值 
        /// </summary>
        public int mPLimit = 0;

        /// <summary>
        /// 正限位值 
        /// </summary>
        public int PLimit
        {
            get { return mPLimit; }
            set { mPLimit = value; }
        }

        /// <summary>
        /// 回零方向，  1 正向, 2:负向 
        /// </summary>
        public ushort mHomeDir = 0;

        /// <summary>
        /// 回零方向，  1 正向, 2:负向 
        /// </summary>
        public ushort HomeDir
        {
            get { return mHomeDir; }
            set { mHomeDir = value; }
        }

        /// <summary>
        /// ORG信号的有效电平：0－低电平有效，1－高电平有效
        /// </summary>
        private ushort mOrgLogic = 0;

        /// <summary>
        /// ORG信号的有效电平：0－低电平有效，1－高电平有效
        /// </summary>
        public ushort OrgLogic
        {
            get { return mOrgLogic; }
            set { mOrgLogic = value; }
        }

        /// <summary>
        /// 回零速度 
        /// </summary>
        public double mVel = 0;

        /// <summary>
        /// 回零速度 
        /// </summary>
        public double Vel
        {
            get { return mVel; }
            set { mVel = value; }
        }

        /// <summary>
        /// 回原点的信号模式
        /// </summary>
        public ushort mHomeMode = 0;

        /// <summary>
        /// 回原点的信号模式 0、1、2、10、11
        /// </summary>
        public ushort HomeMode
        {
            get { return mHomeMode; }
            set { mHomeMode = value; }
        }

        /// <summary>
        /// EZ次数 
        /// </summary>
        public ushort mEZCount = 0;

        /// <summary>
        /// EZ次数 
        /// </summary>
        public ushort EZCount
        {
            get { return mEZCount; }
            set { mEZCount = value; }
        }

        /// <summary>
        /// 是否回原点
        /// </summary>
        private bool mIsHome = false;

        /// <summary>
        /// 是否回原点
        /// </summary>
        public bool IsHome
        {
            get { return mIsHome; }
            set { mIsHome = value; }
        }

        /// <summary>
        /// 是否在运动
        /// </summary>
        private bool mIsMove = false;

        /// <summary>
        /// 是否在运动
        /// </summary>
        public bool IsMove
        {
            get { return mIsMove; }
            set { mIsMove = value; }
        }

        /// <summary>
        /// EZ信号逻辑电平：0－低有效，1－高有效
        /// </summary>
        private ushort mEzLogic = 0;

        /// <summary>
        /// EZ信号逻辑电平：0－低有效，1－高有效
        /// </summary>
        public ushort EzLogic
        {
            get { return mEzLogic; }
            set { mEzLogic = value; }
        }

        /// <summary>
        /// EZ信号的工作方式：0－EZ信号无效,1－EZ是计数器复位信号
        ///2－EZ是原点信号，且不复位计数器,3－EZ是原点信号，且复位计数器
        /// </summary>
        private ushort mEzMode = 0;

        /// <summary>
        /// EZ信号的工作方式：0－EZ信号无效,1－EZ是计数器复位信号
        ///2－EZ是原点信号，且不复位计数器,3－EZ是原点信号，且复位计数器
        /// </summary>
        public ushort EzMode
        {
            get { return mEzMode; }
            set { mEzMode = value; }
        }

        /// <summary>
        /// 轴转一圈的总脉冲数
        /// </summary>
        private double mStep = 0;

        /// <summary>
        /// 轴转一圈的总脉冲数
        /// </summary>
        public double Step
        {
            get { return mStep; }
            set { mStep = value; }
        }

        /// <summary>
        /// 轴转一圈的物理距离度/mm
        /// </summary>
        private double mLead = 0;

        /// <summary>
        /// 轴转一圈的物理距离度/mm
        /// </summary>
        public double Lead
        {
            get { return mLead; }
            set { mLead = value; }
        }

        /// <summary>
        /// 物理极限，单位mm或者度
        /// </summary>
        private double mMaxLimit = 0;

        /// <summary>
        /// 物理极限，单位mm或者度
        /// </summary>
        public double MaxLimit
        {
            get { return mMaxLimit; }
            set { mMaxLimit = value; }
        }

        /// <summary>
        /// 工作位置1
        /// </summary>
        private double mWorkPos1 = 0;

        /// <summary>
        /// 工作位置1
        /// </summary>
        public double WorkPos1
        {
            get { return mWorkPos1; }
            set { mWorkPos1 = value; }
        }

        /// <summary>
        /// 工作位置2
        /// </summary>
        private double mWorkPos2 = 0;

        /// <summary>
        /// 工作位置2
        /// </summary>
        public double WorkPos2
        {
            get { return mWorkPos2; }
            set { mWorkPos2 = value; }
        }

        /// <summary>
        /// 工作位置3
        /// </summary>
        private double mWorkPos3 = 0;

        /// <summary>
        /// 工作位置3
        /// </summary>
        public double WorkPos3
        {
            get { return mWorkPos3; }
            set { mWorkPos3 = value; }
        }

        /// <summary>
        /// 工作位置4
        /// </summary>
        private double mWorkPos4 = 0;

        /// <summary>
        /// 工作位置4
        /// </summary>
        public double WorkPos4
        {
            get { return mWorkPos4; }
            set { mWorkPos4 = value; }
        }

        ///// <summary>
        ///// 移动每一mm所发送的脉冲数
        ///// </summary>
        //private int mStepPerMM = 0;

        ///// <summary>
        ///// 移动每一mm所发送的脉冲数
        ///// </summary>
        //public int StepPerMM
        //{
        //    get { return mStepPerMM; }
        //    set { mStepPerMM = value; }
        //}
    }
}
