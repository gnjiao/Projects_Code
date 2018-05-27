using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    public class DMC2C80Card : ControlCardBase
    {
        /// <summary>
        /// 控制卡错误提示枚举
        /// </summary>
        enum ErrorMsg
        {
            成功 = 0,
            未知错误 = 1,
            参数错误 = 2,
            操作超时 = 3,
            控制卡状态忙 = 4,
            数据传输错误请检查PCI槽位是否松动 = 10,
            控制器返回参数错误 = 20,
            控制器返回当前状态不允许操作 = 22,
            控制器不支持的功能 = 24,
        }

        public DMC2C80Card()
        {

        }

        /// <summary>
        /// 初始化控制卡
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>成功与否</returns>
        public override bool InitCard(bool isShowLog)
        {
            bool f = false;

            int iRtn = Dmc2C80.d2c80_board_init();

            if (iRtn < 1 || iRtn > 7)
            {
                f = false;

                Log.GetInstance().ActionWrite(string.Format("初始化控制卡"), "没有读到控制卡", isShowLog);
            }
            else
            {
                f = true;

                Log.GetInstance().ActionWrite(string.Format("初始化控制卡"), ((ErrorMsg)iRtn).ToString(), isShowLog);
            }

            return f;
        }

        /// <summary>
        /// 关闭控制卡
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        public override void CloseCard(bool isShowLog)
        {
            Dmc2C80.d2c80_board_close();

            Log.GetInstance().ActionWrite(string.Format("关闭控制卡"), ((ErrorMsg)0).ToString(), isShowLog);
        }

        /// <summary>
        /// 读取控制卡的ID拨码开关
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>控制卡的ID拨码开关标志值</returns>
        public override uint GetCardID(bool isShowLog)
        {
            uint iRtn = Dmc2C80.d2c80_get_card_ID(this.CardNo);

            this.IsOff = iRtn == 0 ? true : false;

            Log.GetInstance().ActionWrite(string.Format("读取控制卡的ID拨码开关[{0}]", iRtn == 0 ? "低电平" : "高电平"), ((ErrorMsg)0).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <param name="versionType">版本号类型</param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        public override void GetVersion(VersionType versionType, bool isShowLog)
        {
            int iRtn = 0;

            if (versionType == VersionType.CardVersion)
            {
                this.GetCardVersion(isShowLog);
            }
            else if (versionType == VersionType.LibVersion)
            {
                this.GetLibVersion(isShowLog);
            }
            else if (versionType == VersionType.FirmVersion)
            {
                this.GetCardSoftVersion(isShowLog);
            }
        }

        /// <summary>
        /// 读取软件版本号
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>软件版本号</returns>
        public uint GetLibVersion(bool isShowLog)
        {
            uint iRtn = Dmc2C80.d2c80_get_lib_version();

            this.LibVersion = iRtn;

            Log.GetInstance().ActionWrite(string.Format("读取软件版本号[{0}]", iRtn), ((ErrorMsg)0).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 读取硬件版本号
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>硬件版本号</returns>
        public uint GetCardVersion(bool isShowLog)
        {
            uint iRtn = Dmc2C80.d2c80_get_card_version(this.CardNo);
            this.CardVersion = iRtn;
            Log.GetInstance().ActionWrite(string.Format("读取硬件版本号[{0}]", iRtn), ((ErrorMsg)0).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 读取卡硬件的固件版本号 
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public int GetCardSoftVersion(bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_get_card_soft_version(this.CardNo, ref this.mFirmId, ref this.mSubFirmId);

            Log.GetInstance().ActionWrite(string.Format("读取卡硬件的固件版本号[{0}]子版本号[{1}]", this.mFirmId, this.mSubFirmId), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 读取卡的总轴数
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>轴数</returns>
        public override int GetTotalAxis(bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_get_total_axes(this.CardNo);
            this.AxisCount = iRtn;
            Log.GetInstance().ActionWrite(string.Format("读取控制卡的总轴数[{0}]", iRtn), ((ErrorMsg)0).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置指定轴的脉冲输出模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int SetPulseOutmode(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_set_pulse_outmode(axisInfo.AxisNumber, axisInfo.Outmode);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴的脉冲输出模式[{1}]", axisInfo.AxisName, axisInfo.Outmode), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取指定轴的脉冲输出模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误码</returns>
        public override int GetPulseOutmode(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_get_pulse_outmode(axisInfo.AxisNumber, ref axisInfo.mOutmode);

            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴的脉冲输出模式[{1}]", axisInfo.AxisNumber, axisInfo.Outmode), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置指定轴编码器的计数方式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int SetCounterConfig(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_counter_config(axisInfo.AxisNumber, axisInfo.Mode);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴的编码器计算方式[{1}]", axisInfo.AxisName, axisInfo.Mode), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取指定轴编码器的计数方式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int GetCounterConfig(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_get_counter_config(axisInfo.AxisNumber, ref axisInfo.mMode);

            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴的编码器计算方式[{1}]", axisInfo.AxisName, axisInfo.Mode), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置速度曲线运动模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="proFileType"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int SetProFile(AxisInfo axisInfo, ProFileType proFileType, bool isShowLog)
        {
            int iRtn = 0;
            if (proFileType == ProFileType.T)
            {
                iRtn = this.Set_T_ProFile(axisInfo, isShowLog);
            }
            else if (proFileType == ProFileType.S)
            {
                iRtn = this.Set_S_ProFile(axisInfo, isShowLog);
            }

            return iRtn;
        }

        /// <summary>
        /// 获取速度曲线运动模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="proFileType"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int GetProFile(AxisInfo axisInfo, ProFileType proFileType, bool isShowLog)
        {
            int iRtn = 0;
            if (proFileType == ProFileType.T)
            {
                iRtn = this.Get_T_ProFile(axisInfo, isShowLog);
            }
            else if (proFileType == ProFileType.S)
            {
                iRtn = this.Get_S_ProFile(axisInfo, isShowLog);
            }

            return iRtn;
        }


        /// <summary>
        /// 设置T形速度曲线运动模式 
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public int Set_T_ProFile(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_set_profile(axisInfo.AxisNumber, axisInfo.MinVel, axisInfo.MaxVel, axisInfo.Acc, axisInfo.Dec);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴的起始速度[{1}]、运行速度[{2}]、加速度[{3}]、减速度[{4}]", axisInfo.AxisName, axisInfo.MinVel, axisInfo.MaxVel, axisInfo.Acc, axisInfo.Dec), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取T形速度曲线运动模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public int Get_T_ProFile(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_get_profile(axisInfo.AxisNumber, ref axisInfo.mMinVel, ref axisInfo.mMaxVel, ref axisInfo.mAcc, ref axisInfo.mDec);

            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴的起始速度[{1}]、运行速度[{2}]、加速度[{3}]、减速度[{4}]", axisInfo.AxisName, axisInfo.MinVel, axisInfo.MaxVel, axisInfo.Acc, axisInfo.Dec), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置S形速度曲线运动模式 
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public int Set_S_ProFile(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_set_s_profile(axisInfo.AxisNumber, axisInfo.S_Para);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴的S形曲线运动和S段比为[{1}]", axisInfo.AxisName, axisInfo.S_Para), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取S形速度曲线运动模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public int Get_S_ProFile(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_get_s_profile(axisInfo.AxisNumber, ref axisInfo.mS_Para);

            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴的S形曲线运动和S段比[{1}]", axisInfo.AxisName, axisInfo.S_Para), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 在线改变指定轴的当前运动速度。该函数只适用于单轴运动中的变速
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int ChangeSpeed(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_change_speed(axisInfo.AxisNumber, axisInfo.CurrVel);

            Log.GetInstance().ActionWrite(string.Format("修改[{0}]轴的当前运动速度为[{1}]", axisInfo.AxisName
                , axisInfo.CurrVel), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取指定轴的当前速度
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>指定轴的速度脉冲数</returns>
        public override double ReadCurrentSpeed(AxisInfo axisInfo, bool isShowLog)
        {
            double dRtn = Dmc2C80.d2c80_read_current_speed(axisInfo.AxisNumber);
            axisInfo.CurrVel = dRtn;

            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴的当前速度[{1}] ", axisInfo.AxisNumber, dRtn), ((ErrorMsg)0).ToString(), isShowLog);

            return dRtn;
        }

        /// <summary>
        /// 获取指定卡的插补速度
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>插补速度</returns>
        public override double ReadVectorSpeed(bool isShowLog)
        {
            double dRtn = Dmc2C80.d2c80_read_vector_speed(this.CardNo);

            Log.GetInstance().ActionWrite(string.Format("获取控制卡[{0}]的插补速度[{1}] ", this.CardNo, dRtn), ((ErrorMsg)0).ToString(), isShowLog);

            return dRtn;
        }

        /// <summary>
        /// 停止轴运动
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="axisStopType"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int AxisStop(AxisInfo axisInfo, AxisStopType axisStopType, bool isShowLog)
        {
            int iRtn = 0;
            if (axisStopType == AxisStopType.DecelStop)
            {
                iRtn = this.DecelStop(axisInfo, isShowLog);
            }
            else if (axisStopType == AxisStopType.SimultaneousStop)
            {
                iRtn = this.SimultaneousStop(axisInfo, isShowLog);
            }
            else if (axisStopType == AxisStopType.ImdStop)
            {
                iRtn = this.ImdStop(axisInfo, isShowLog);
            }
            else if (axisStopType == AxisStopType.EmgStop)
            {
                iRtn = this.EmgStop(isShowLog);
            }

            return iRtn;
        }

        /// <summary>
        /// 指定轴减速停止
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误码</returns>
        public int DecelStop(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_decel_stop(axisInfo.AxisNumber, axisInfo.Dec);

            Log.GetInstance().ActionWrite(string.Format("[{0}]轴减速停止", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 指定轴急停
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public int ImdStop(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_imd_stop(axisInfo.AxisNumber);

            Log.GetInstance().ActionWrite(string.Format("[{0}]轴急停", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 同步停止所有轴
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public int SimultaneousStop(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_simultaneous_stop(axisInfo.AxisNumber);

            Log.GetInstance().ActionWrite(string.Format("[{0}]轴同步停止", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 紧急停止所有轴
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public int EmgStop(bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_emg_stop();

            Log.GetInstance().ActionWrite(string.Format("紧急停止所有轴 "), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 定长运动
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int Pmove(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_pmove(axisInfo.AxisNumber, axisInfo.Dist, axisInfo.PosiMode);

            Log.GetInstance().ActionWrite(string.Format("[{0}]轴定长运动距离[{1}]", axisInfo.AxisName, axisInfo.Dist), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取指定轴的指令脉冲位置
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>指定运动轴的命令脉冲数</returns>
        public override int GetPosition(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = Dmc2C80.d2c80_get_position(axisInfo.AxisNumber);
            axisInfo.CurrentPosition = iRtn;

            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴的指令脉冲位置[{1}]", axisInfo.AxisName, iRtn), ((ErrorMsg)0).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置指定轴的指令脉冲位置
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int SetPosition(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_set_position(axisInfo.AxisNumber, axisInfo.CurrentPosition);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴的指令脉冲位置为[{1}]", axisInfo.AxisName, axisInfo.CurrentPosition), ((ErrorMsg)0).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置软件限位
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int SetConfigSoftlimit(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_config_softlimit(axisInfo.AxisNumber, axisInfo.ON_OFF, axisInfo.SourceSel, axisInfo.SLAction, axisInfo.NLimit, axisInfo.PLimit);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴软件限位", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取软件限位
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int GetConfigSoftlimit(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_get_config_softlimit(axisInfo.AxisNumber, ref axisInfo.mON_OFF, ref axisInfo.mSourceSel, ref axisInfo.mSLAction, ref axisInfo.mNLimit, ref axisInfo.mPLimit);

            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴软件限位", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置ORG信号的有效电平
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int SetConfigHomePinLogic(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_config_HOME_PIN_logic(axisInfo.AxisNumber, axisInfo.OrgLogic, 1);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴ORG信号的有效电平", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置指定轴的EZ信号的有效电平及其作用
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int SetConfigEzPin(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_config_EZ_PIN(axisInfo.AxisNumber, axisInfo.EzLogic, axisInfo.EzMode);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴的EZ信号的有效电平及其方式", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 设置回原点模式 
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int SetConfigHomeMode(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_config_home_mode(axisInfo.AxisNumber, axisInfo.HomeDir, axisInfo.Vel, axisInfo.HomeMode, axisInfo.EZCount);

            Log.GetInstance().ActionWrite(string.Format("设置[{0}]轴回原点模式", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 获取回原点模式 
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int GetConfigHomeMode(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_get_config_home_mode(axisInfo.AxisNumber, ref axisInfo.mHomeDir, ref axisInfo.mVel, ref axisInfo.mHomeMode, ref axisInfo.mEZCount);

            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴回原点模式", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 回原点运动 
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public override int HomeMove(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_home_move(axisInfo.AxisNumber);
            axisInfo.IsHome = iRtn == 0 ? true : false;
            Log.GetInstance().ActionWrite(string.Format("[{0}]轴回原点运动", axisInfo.AxisName), ((ErrorMsg)iRtn).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// 检测指定轴的运动状态
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns> 0运行，1停止</returns>
        public override int CheckDone(AxisInfo axisInfo, bool isShowLog)
        {
            int iRtn = (int)Dmc2C80.d2c80_check_done(axisInfo.AxisNumber);

            axisInfo.IsMove = iRtn == 0 ? true : false;
            Log.GetInstance().ActionWrite(string.Format("获取[{0}]轴运动状态{1}", axisInfo.AxisName, iRtn == 0 ? "正在运动" : "停止运动"), ((ErrorMsg)0).ToString(), isShowLog);

            return iRtn;
        }

        /// <summary>
        /// IO输入
        /// </summary>
        /// <param name="bitNo">指定输入口位号</param>
        /// <returns>0表示低电平；1表示高电平</returns>
        public override int ReadInbit(ushort bitNo)
        {
            int iRtn = (int)Dmc2C80.d2c80_read_inbit(this.CardNo, bitNo);

            return iRtn;
        }

        /// <summary>
        /// IO输出
        /// </summary>
        /// <param name="bitNo">指定输出口位号（取值范围：1－32）</param>
        /// <param name="on_off">
        /// 拨码开关选择OFF时，输出初始电平为高，当输出口写 0时,
        /// 端口输出低电平；拨码开关选择ON 时，输出初始电平为低，
        /// 当输出口写 0时,端口输 出高电平</param>
        /// <returns>错误代码</returns>
        public override int WriteOutbit(ushort bitNo, ushort on_off)
        {
            int iRtn = (int)Dmc2C80.d2c80_write_outbit(this.CardNo, bitNo, on_off);

            return iRtn;
        }

        /// <summary>
        /// 获取指定控制卡的某一位输出口的电平状态 
        /// </summary>
        /// <param name="bitNo">指定输出口位号</param>
        /// <returns>0表示低电平；1表示高电平</returns>
        public override int ReadOutbit(ushort bitNo)
        {
            int iRtn = (int)Dmc2C80.d2c80_read_outbit(this.CardNo, bitNo);

            return iRtn;
        }

        /// <summary>
        /// 读取指定控制卡的全部通用输入口的电平状态 
        /// </summary>
        /// <returns>bit0 – bit47位值分别代表第1–48 号输入端口值</returns>
        public override int ReadInport()
        {
            int iRtn = (int)Dmc2C80.d2c80_read_inport(this.CardNo);

            return iRtn;
        }

        /// <summary>
        /// 读取指定控制卡的全部通用输出口的电平状态 
        /// </summary>
        /// <returns>bit0 – bit31位值分别代表第1 – 32号输出端口值</returns>
        public override int ReadOutport()
        {
            int iRtn = (int)Dmc2C80.d2c80_read_outport(this.CardNo);

            return iRtn;
        }

        /// <summary>
        /// 设置控制卡的全部通用输出口的电平状态 
        /// </summary>
        /// <param name="port_value">bit0–bit31位值分别代表第1–32 号输出端口值</param>
        /// <returns>错误代码</returns>
        public override int WriteOutport(ushort port_value)
        {
            int iRtn = (int)Dmc2C80.d2c80_write_outport(this.CardNo, port_value);

            return iRtn;
        }
    }
}
