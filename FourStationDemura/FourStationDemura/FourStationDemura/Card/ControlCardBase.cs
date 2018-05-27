using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    /// <summary>
    /// 控制卡功能基类
    /// </summary>
    public class ControlCardBase
    {
        /// <summary>
        /// 控制卡号
        /// </summary>
        public ushort CardNo { set; get; }

        /// <summary>
        /// 拨码开关是否关闭
        /// </summary>
        public bool IsOff { set; get; }

        /// <summary>
        /// 软件版本号
        /// </summary>
        public uint LibVersion { set; get; }

        /// <summary>
        /// 硬件版本号
        /// </summary>
        public uint CardVersion { set; get; }

        /// <summary>
        /// 固件版本号
        /// </summary>
        public ushort mFirmId = 0;

        /// <summary>
        /// 固件版本号
        /// </summary>
        public ushort FirmId
        {
            get { return mFirmId; }
            set { mFirmId = value; }
        }

        /// <summary>
        /// 固件版本号子id
        /// </summary>
        public uint mSubFirmId = 0;

        /// <summary>
        /// 固件版本号子id
        /// </summary>
        public uint SubFirmId
        {
            get { return mSubFirmId; }
            set { mSubFirmId = value; }
        }

        /// <summary>
        /// 轴数
        /// </summary>
        public int AxisCount { set; get; }

        /// <summary>
        /// 初始化控制卡
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>成功与否</returns>
        public virtual bool InitCard(bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 关闭控制卡
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        public virtual void CloseCard(bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 读取控制卡的ID拨码开关
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>控制卡的ID拨码开关标志值</returns>
        public virtual uint GetCardID(bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <param name="versionType">版本号类型</param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        public virtual void GetVersion(VersionType versionType, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 读取卡的总轴数
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>总轴数</returns>
        public virtual int GetTotalAxis(bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置指定轴的脉冲输出模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int SetPulseOutmode(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定轴的脉冲输出模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误码</returns>
        public virtual int GetPulseOutmode(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置指定轴编码器的计数方式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int SetCounterConfig(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定轴编码器的计数方式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int GetCounterConfig(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置速度曲线运动模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="proFileType"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int SetProFile(AxisInfo axisInfo, ProFileType proFileType, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取速度曲线运动模式
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="proFileType"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int GetProFile(AxisInfo axisInfo, ProFileType proFileType, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }


        /// <summary>
        /// 在线改变指定轴的当前运动速度。该函数只适用于单轴运动中的变速
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int ChangeSpeed(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定轴的当前速度
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>指定轴的速度脉冲数</returns>
        public virtual double ReadCurrentSpeed(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定卡的插补速度
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>插补速度</returns>
        public virtual double ReadVectorSpeed(bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 停止轴运动
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="axisStopType"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int AxisStop(AxisInfo axisInfo, AxisStopType axisStopType, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 定长运动
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int Pmove(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定轴的指令脉冲位置
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>指定运动轴的命令脉冲数</returns>
        public virtual int GetPosition(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置指定轴的指令脉冲位置
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int SetPosition(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置软件限位
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int SetConfigSoftlimit(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取软件限位
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int GetConfigSoftlimit(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置ORG信号的有效电平
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int SetConfigHomePinLogic(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置指定轴的EZ信号的有效电平及其作用
        /// </summary>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int SetConfigEzPin(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 设置回原点模式 
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int SetConfigHomeMode(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取回原点模式 
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int GetConfigHomeMode(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 回原点运动 
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>错误代码</returns>
        public virtual int HomeMove(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 检测指定轴的运动状态
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>0运行，1停止</returns>
        public virtual int CheckDone(AxisInfo axisInfo, bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// IO输入
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="bitNo">指定输入口位号</param>
        /// <param name="isShowLog">是否显示日志到UI</param>
        /// <returns>0表示低电平；1表示高电平</returns>
        public virtual int ReadInbit(ushort bitNo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// IO输出
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="bitNo">指定输出口位号（取值范围：1－32）</param>
        /// <param name="on_off">
        /// 拨码开关选择OFF时，输出初始电平为高，当输出口写 0时,
        /// 端口输出低电平；拨码开关选择ON 时，输出初始电平为低，
        /// 当输出口写 0时,端口输 出高电平</param>
        /// <returns>错误代码</returns>
        public virtual int WriteOutbit(ushort bitNo, ushort on_off)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定控制卡的某一位输出口的电平状态 
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="bitNo">指定输出口位号</param>
        /// <returns>0表示低电平；1表示高电平</returns>
        public virtual int ReadOutbit(ushort bitNo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 读取指定控制卡的全部通用输入口的电平状态 
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns>bit0 – bit47位值分别代表第1–48 号输入端口值</returns>
        public virtual int ReadInport()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 读取指定控制卡的全部通用输出口的电平状态 
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns>bit0 – bit31位值分别代表第1 – 32号输出端口值</returns>
        public virtual int ReadOutport()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置控制卡的全部通用输出口的电平状态 
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="port_value">bit0–bit31位值分别代表第1–32 号输出端口值</param>
        /// <returns>错误代码</returns>
        public virtual int WriteOutport(ushort port_value)
        {
            throw new System.NotImplementedException();
        }
    }
}
