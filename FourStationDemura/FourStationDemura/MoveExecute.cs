using IIXDeMuraApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FourStationDemura
{
    /// <summary>
    /// 运动执行类，主要封装一些公用的运动方法
    /// </summary>
    public class MoveExecute
    {
        public enum Result
        {
            Successful,
            Failure
        }

        /// <summary>
        /// 轴回原点
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog"></param>
        /// <returns></returns>
        public static bool HomeMove(AxisInfo axisInfo, bool isShowLog)
        {
            bool f = false;

            try
            {
                if (isShowLog)
                {
                    Log.GetInstance().NormalWrite(string.Format("[{0}]轴开始回原点运动......", axisInfo.AxisName));
                }

                axisInfo.Outmode = 0;
                axisInfo.OrgLogic = 0;
                axisInfo.EzLogic = 0;
                axisInfo.EzMode = 1;
                axisInfo.HomeDir = 1;
                axisInfo.Vel = axisInfo.MaxVel;
                axisInfo.HomeMode = 3;
                axisInfo.EZCount = 1;

                //设置脉冲输出模式
                int iRtn = Global.ControlCard.SetPulseOutmode(axisInfo, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                //设置ORG信号的有效电平
                iRtn = Global.ControlCard.SetConfigHomePinLogic(axisInfo, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                //设置指定轴的EZ信号的有效电平及其作用
                iRtn = Global.ControlCard.SetConfigEzPin(axisInfo, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                //设置回原点模式
                iRtn = Global.ControlCard.SetConfigHomeMode(axisInfo, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                //设置运动模式
                iRtn = Global.ControlCard.SetProFile(axisInfo, ProFileType.T, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                //回原点
                iRtn = Global.ControlCard.HomeMove(axisInfo, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                int waitTime = 0;

                //等待轴停止运动
                while (true)
                {
                    if (waitTime == Global.CardWaitTime)
                    {
                        //报警提示
                        Global.ControlCard.WriteOutbit(28, 1);
                        //亮红灯
                        Global.ControlCard.WriteOutbit(25, 1);

                        Log.GetInstance().WarningWrite(string.Format("[{0}]轴回原点运动超时", axisInfo.AxisName));

                        Log.GetInstance().WarningWrite(string.Format("[{0}]轴强制停止运动，需复位后重新开始检测", axisInfo.AxisName));

                        //停止轴运动
                        Global.ControlCard.AxisStop(axisInfo, AxisStopType.ImdStop, isShowLog);

                        return false;
                    }

                    if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1)
                    {
                        f = true;
                        return true;
                    }

                    waitTime++;
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                return false;
            }
            finally
            {
                if (isShowLog)
                {
                    if (f)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]轴回原点成功，请移动到工作位置1", axisInfo.AxisName));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]轴回原点失败，请重启设备", axisInfo.AxisName));
                    }

                    Log.GetInstance().NormalWrite(string.Format("[{0}]轴回原点运动结束", axisInfo.AxisName));
                }
            }
        }

        /// <summary>
        /// 轴定长运动
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="isShowLog"></param>
        /// <returns></returns>
        public static bool Pmove(AxisInfo axisInfo, bool isShowLog)
        {
            try
            {
                if (isShowLog)
                {
                    Log.GetInstance().NormalWrite(string.Format("[{0}]轴开始定长运动......", axisInfo.AxisName));
                }

                axisInfo.Outmode = 0;
                
                //设置脉冲输出模式
                int iRtn = Global.ControlCard.SetPulseOutmode(axisInfo, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                //设置运动模式
                iRtn = Global.ControlCard.SetProFile(axisInfo, ProFileType.T, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                //定长运动
                iRtn = Global.ControlCard.Pmove(axisInfo, isShowLog);

                if (iRtn != 0)
                {
                    return false;
                }

                int waitTime = 0;

                //检查是否移动到位
                while (true)
                {
                    if (waitTime == Global.CardWaitTime)
                    {
                        //报警提示
                        Global.ControlCard.WriteOutbit(28, 1);
                        //亮红灯
                        Global.ControlCard.WriteOutbit(25, 1);

                        Log.GetInstance().WarningWrite(string.Format("[{0}]轴定长运动超时", axisInfo.AxisName));

                        Log.GetInstance().WarningWrite(string.Format("[{0}]轴强制停止运动，需复位后重新开始检测", axisInfo.AxisName));

                        //停止轴运动
                        Global.ControlCard.AxisStop(axisInfo, AxisStopType.ImdStop, isShowLog);

                        return false;
                    }

                    if (axisInfo.AxisName == "转盘")
                    {
                        //轴停止并且收到运动到位指令
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(24) == 1)
                        {
                            return true;
                        }
                    }
                    else if (axisInfo.AxisName == "VCR-X")
                    {
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(25) == 1)
                        {
                            return true;
                        }
                    }
                    else if (axisInfo.AxisName == "VCR-Z")
                    {
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(26) == 1)
                        {
                            return true;
                        }
                    }
                    else if (axisInfo.AxisName == "检测相机#1")
                    {
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(27) == 1)
                        {
                            return true;
                        }
                    }
                    else if (axisInfo.AxisName == "检测相机#2")
                    {
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(28) == 1)
                        {
                            return true;
                        }
                    }
                    else if (axisInfo.AxisName == "检测相机#3")
                    {
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(29) == 1)
                        {
                            return true;
                        }
                    }
                    else if (axisInfo.AxisName == "复检相机#1")
                    {
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(30) == 1)
                        {
                            return true;
                        }
                    }
                    else if (axisInfo.AxisName == "复检相机#2")
                    {
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(31) == 1)
                        {
                            return true;
                        }
                    }
                    else if (axisInfo.AxisName == "复检相机#3")
                    {
                        if (Global.ControlCard.CheckDone(axisInfo, isShowLog) == 1 && Global.IoCard.ReadInBit(32) == 1)
                        {
                            return true;
                        }
                    }

                    waitTime++;
                    Thread.Sleep(1000);

                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                return false;
            }
            finally
            {
                if (isShowLog)
                {
                    Log.GetInstance().NormalWrite(string.Format("[{0}]轴定长运动结束", axisInfo.AxisName));
                }
            }
        }

        /// <summary>
        /// 设置屏幕当前的工作位置，1#、2#、3#、4#
        /// </summary>
        public static void SetPanelCurrentWorkPos()
        {
            foreach (var panel in Global.ListOLEDPanel)
            {
                panel.IsRotate = true;

                if (panel.PanelWorkPos == "1#")
                {
                    panel.PanelWorkPos = "2#";
                }
                if (panel.PanelWorkPos == "2#")
                {
                    panel.PanelWorkPos = "3#";
                }
                if (panel.PanelWorkPos == "3#")
                {
                    panel.PanelWorkPos = "4#";
                }
                if (panel.PanelWorkPos == "4#")
                {
                    panel.PanelWorkPos = "1#";
                }
            }
        }


        /// <summary>
        /// 设置屏幕真空/破真空，并检测是否成功
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="isVacuum">true = 真空，false = 破真空</param>
        /// <returns></returns>
        public static bool SetVacuum(IIXServer iixServer, bool isVacuum)
        {
            bool f = false;

            try
            {
                int waitTime = 0;

                while (true)
                {
                    if (waitTime == Global.CardWaitTime)
                    {
                        //报警提示
                        Global.ControlCard.WriteOutbit(28, 1);
                        //亮红灯
                        Global.ControlCard.WriteOutbit(25, 1);

                        Log.GetInstance().WarningWrite(string.Format("屏[{0}]{1}超时", iixServer.AssociatedPanelPos, isVacuum == true ? "真空" : "破真空"));

                        Log.GetInstance().WarningWrite(string.Format("请重新{0}，如还不成功，可能是部件损坏，需检查设备", isVacuum == true ? "点灯" : "关灯"));

                        return false;
                    }

                    //当前工位是#1
                    if (Global.WorkPos == 1)
                    {
                        //IIX服务端关联的屏幕#1
                        if (iixServer.AssociatedPanelPos == "#1")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(1, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(4, 1);
                                }
                            }

                            //检测动作完成
                            if (Global.IoCard.ReadInBit(12) == 1)
                            {
                                return true;
                            }
                        }
                        else if (iixServer.AssociatedPanelPos == "#2")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(2, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(5, 1);
                                }
                            }
                            //检测动作完成
                            if (Global.IoCard.ReadInBit(13) == 1)
                            {
                                return true;
                            }
                        }
                        else if (iixServer.AssociatedPanelPos == "#3")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(3, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(6, 1);
                                }
                            }
                            //检测动作完成
                            if (Global.IoCard.ReadInBit(14) == 1)
                            {
                                return true;
                            }
                        }
                    }
                    else if (Global.WorkPos == 2)
                    {
                        //IIX服务端关联的屏幕#1
                        if (iixServer.AssociatedPanelPos == "#1")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(7, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(10, 1);
                                }
                            }
                            //检测动作完成
                            if (Global.IoCard.ReadInBit(15) == 1)
                            {
                                return true;
                            }
                        }
                        else if (iixServer.AssociatedPanelPos == "#2")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(8, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(11, 1);
                                }
                            }
                            //检测动作完成
                            if (Global.IoCard.ReadInBit(16) == 1)
                            {
                                return true;
                            }
                        }
                        else if (iixServer.AssociatedPanelPos == "#3")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(9, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(12, 1);
                                }
                            }

                            //检测动作完成
                            if (Global.IoCard.ReadInBit(17) == 1)
                            {
                                return true;
                            }
                        }
                    }
                    else if (Global.WorkPos == 3)
                    {
                        //IIX服务端关联的屏幕#1
                        if (iixServer.AssociatedPanelPos == "#1")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(13, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(16, 1);
                                }
                            }

                            //检测动作完成
                            while (Global.IoCard.ReadInBit(18) == 1)
                            {
                                return true;
                            }
                        }
                        else if (iixServer.AssociatedPanelPos == "#2")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(14, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(17, 1);
                                }
                            }

                            //检测动作完成
                            if (Global.IoCard.ReadInBit(19) == 1)
                            {
                                return true;
                            }
                        }
                        else if (iixServer.AssociatedPanelPos == "#3")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(15, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(18, 1);
                                }
                            }

                            //检测动作完成
                            if (Global.IoCard.ReadInBit(20) == 1)
                            {
                                return true;
                            }
                        }
                    }
                    else if (Global.WorkPos == 4)
                    {
                        //IIX服务端关联的屏幕#1
                        if (iixServer.AssociatedPanelPos == "#1")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(19, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(22, 1);
                                }
                            }

                            //检测动作完成
                            if (Global.IoCard.ReadInBit(21) == 1)
                            {
                                return true;
                            }
                        }
                        else if (iixServer.AssociatedPanelPos == "#2")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(20, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(23, 1);
                                }
                            }

                            //检测动作完成
                            if (Global.IoCard.ReadInBit(22) == 1)
                            {
                                return true;
                            }
                        }
                        else if (iixServer.AssociatedPanelPos == "#3")
                        {
                            if (waitTime == 0)
                            {
                                //真空
                                if (isVacuum)
                                {
                                    Global.IoCard.WriteOutBit(21, 1);
                                }
                                //破真空
                                else
                                {
                                    Global.IoCard.WriteOutBit(24, 1);
                                }
                            }

                            //检测动作完成
                            if (Global.IoCard.ReadInBit(23) == 1)
                            {
                                return true;
                            }
                        }
                    }

                    waitTime++;
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            //Log.GetInstance().NormalWrite(string.Format("屏[{0}]{1}{2}", iixServer.AssociatedPanelPos, isVacuum == true ? "真空" : "破真空", f == true ? "成功" : "失败"));

            return f;
        }

        /// <summary>
        /// 设置屏幕锁住与否，点灯锁住，关灯解锁
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="isPanelOn"></param>
        /// <returns></returns>
        public static void SetPanelLock(IIXServer iixServer,bool isPanelOn)
        {
            try
            {
                //当前工位是#1
                if (Global.WorkPos == 1)
                {
                    //IIX服务端关联的屏幕#1
                    if (iixServer.AssociatedPanelPos == "#1")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(25, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(25, 0);
                        }
                    }
                    else if (iixServer.AssociatedPanelPos == "#2")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(26, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(26, 0);
                        }
                    }
                    else if (iixServer.AssociatedPanelPos == "#3")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(27, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(27, 0);
                        }
                    }
                }
                else if (Global.WorkPos == 2)
                {
                    //IIX服务端关联的屏幕#1
                    if (iixServer.AssociatedPanelPos == "#1")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(28, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(28, 0);
                        }
                    }
                    else if (iixServer.AssociatedPanelPos == "#2")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(29, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(29, 0);
                        }
                    }
                    else if (iixServer.AssociatedPanelPos == "#3")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(30, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(30, 0);
                        }
                    }
                }
                else if (Global.WorkPos == 3)
                {
                    //IIX服务端关联的屏幕#1
                    if (iixServer.AssociatedPanelPos == "#1")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(31, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(31, 0);
                        }
                    }
                    else if (iixServer.AssociatedPanelPos == "#2")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(32, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(32, 0);
                        }
                    }
                    else if (iixServer.AssociatedPanelPos == "#3")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(59, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(59, 0);
                        }
                    }
                }
                else if (Global.WorkPos == 4)
                {
                    //IIX服务端关联的屏幕#1
                    if (iixServer.AssociatedPanelPos == "#1")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(60, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(60, 0);
                        }
                    }
                    else if (iixServer.AssociatedPanelPos == "#2")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(61, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(61, 0);
                        }
                    }
                    else if (iixServer.AssociatedPanelPos == "#3")
                    {
                        //点灯
                        if (isPanelOn)
                        {
                            Global.ControlCard.WriteOutbit(62, 1);
                        }
                        //关灯
                        else
                        {
                            Global.ControlCard.WriteOutbit(62, 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 设置气缸位置
        /// </summary>
        /// <param name="svrType"></param>
        /// <param name="isUp"></param>
        /// <returns></returns>
        public static bool SetBaffle(SvrType svrType, bool isUp)
        {
            try
            {
                int waitTime = 0;

                //因为要等待IO信号到位，所以需要循坏等待到位信号
                while (true)
                {
                    if (waitTime == Global.CardWaitTime)
                    {
                        Log.GetInstance().WarningWrite(string.Format("{0}气缸{1}超时，可能是部件损坏，需检查设备", svrType == SvrType.Left ? "左边" : "右边", isUp == true ? "上移" : "下移"));

                        //报警提示
                        Global.ControlCard.WriteOutbit(28, 1);
                        //亮红灯
                        Global.ControlCard.WriteOutbit(25, 1);

                        return false;
                    }

                    if (svrType == SvrType.Left)
                    {
                        if (isUp)
                        {
                            //第一次才输出IO信号
                            if (waitTime == 0)
                            {
                                //左边气缸上
                                Global.ControlCard.WriteOutbit(63, 1);
                            }

                            //气缸到位
                            if (Global.ControlCard.ReadInbit(55) == 1)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            //第一次才输出IO信号
                            if (waitTime == 0)
                            {
                                //左边气缸下
                                Global.ControlCard.WriteOutbit(63, 0);
                            }

                            //气缸到位
                            if (Global.ControlCard.ReadInbit(56) == 1)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (isUp)
                        {
                            //第一次才输出IO信号
                            if (waitTime == 0)
                            {
                                //右边气缸上
                                Global.ControlCard.WriteOutbit(64, 1);
                            }

                            //气缸到位
                            if (Global.ControlCard.ReadInbit(57) == 1)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            //第一次才输出IO信号
                            if (waitTime == 0)
                            {
                                //右边气缸下
                                Global.ControlCard.WriteOutbit(64, 0);
                            }

                            //气缸到位
                            if (Global.ControlCard.ReadInbit(58) == 1)
                            {
                                return true;
                            }
                        }
                    }

                    waitTime++;
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 设置气缸位置
        /// </summary>
        /// <param name="isUp"></param>
        public static bool SetBaffle(bool isUp)
        {
            try
            {
                var tasks = new List<Task>();

                bool fLeft = false;
                bool fRight = false;

                //气缸上去
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    fLeft = MoveExecute.SetBaffle(SvrType.Left, isUp);
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    fRight = MoveExecute.SetBaffle(SvrType.Right, isUp);
                }));

                Task.WaitAll(tasks.ToArray());

                if (!fLeft || !fRight)
                {
                    Log.GetInstance().ErrorWrite(string.Format("气缸{0}失败", isUp == true ? "上移" : "下移"));
                    return false;
                }
                else
                {
                    Log.GetInstance().NormalWrite(string.Format("气缸{0}成功", isUp == true ? "上移" : "下移"));
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 所有轴复位
        /// </summary>
        public static bool AllAxisReset()
        {
            bool f = false;

            try
            {
                Log.GetInstance().NormalWrite("轴正在开始复位......");

                var fRtn = MoveExecute.SetBaffle(true);

                //气缸移动不到位不处理
                if (!fRtn)
                {
                    f = false;
                    return false;
                }

                var tasks = new List<Task>();

                foreach (var axisInfo in Global.ListAxis)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        //轴回原点
                        fRtn = MoveExecute.HomeMove(axisInfo, false);

                        if (!fRtn)
                        {
                            f = false;
                        }

                        axisInfo.Dist = Convert.ToInt32(axisInfo.WorkPos1 * axisInfo.Step / axisInfo.Lead);
                        axisInfo.PosiMode = 1;

                        //轴到工作1位置
                        fRtn = MoveExecute.Pmove(axisInfo, false);

                        if (!fRtn || Global.ControlCard.GetPosition(axisInfo, false) != axisInfo.Dist)
                        {
                            f = false;
                        }
                    }));
                }

                Task.WaitAll(tasks.ToArray());

                if (f)
                {
                    Global.isReset = false;
                    //亮黄灯
                    Global.ControlCard.WriteOutbit(26, 1);

                    MoveExecute.NoticePgShooting(Global.WorkPos);

                    return f;
                }
                else
                {
                    //报警提示
                    Global.ControlCard.WriteOutbit(28, 1);
                    //亮红灯
                    Global.ControlCard.WriteOutbit(25, 1);

                    return f;
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                return false;
            }
            finally
            {
                if (f)
                {
                    Log.GetInstance().NormalWrite("轴复位成功，可以开始Demura检测");
                }
                else
                {
                    Log.GetInstance().ErrorWrite("轴复位失败，请重启设备");
                }
                Log.GetInstance().NormalWrite("轴复位结束");
            }
        }

        /// <summary>
        /// 设置轴使能，即加锁，不能手动转动
        /// </summary>
        /// <param name="isLock"></param>
        public static void SetAxisLock(bool isLock)
        {
            try
            {
                //转盘轴
                Global.ControlCard.WriteOutbit(60, isLock == true ? (ushort)1 : (ushort)0);

                //VCR轴
                Global.ControlCard.WriteOutbit(61, isLock == true ? (ushort)1 : (ushort)0);
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 转盘道制定位置后通知PG拍摄
        /// </summary>
        /// <param name="workPos"></param>
        public static void NoticePgShooting(int workPos)
        {
            try
            {
                if (workPos == 1)
                {
                    Global.ControlCard.WriteOutbit(25, 1);
                    Global.ControlCard.WriteOutbit(26, 1);
                    Global.ControlCard.WriteOutbit(27, 1);
                    Global.ControlCard.WriteOutbit(28, 1);
                    Global.ControlCard.WriteOutbit(29, 1);
                    Global.ControlCard.WriteOutbit(30, 1);
                }
                else if (workPos == 2)
                {
                    Global.ControlCard.WriteOutbit(25, 1);
                    Global.ControlCard.WriteOutbit(26, 0);
                    Global.ControlCard.WriteOutbit(27, 1);
                    Global.ControlCard.WriteOutbit(28, 0);
                    Global.ControlCard.WriteOutbit(29, 1);
                    Global.ControlCard.WriteOutbit(30, 0);
                }
                else if (workPos == 3)
                {
                    Global.ControlCard.WriteOutbit(25, 0);
                    Global.ControlCard.WriteOutbit(26, 1);
                    Global.ControlCard.WriteOutbit(27, 0);
                    Global.ControlCard.WriteOutbit(28, 1);
                    Global.ControlCard.WriteOutbit(29, 0);
                    Global.ControlCard.WriteOutbit(30, 1);
                }
                else if (workPos == 4)
                {
                    Global.ControlCard.WriteOutbit(25, 0);
                    Global.ControlCard.WriteOutbit(26, 0);
                    Global.ControlCard.WriteOutbit(27, 0);
                    Global.ControlCard.WriteOutbit(28, 0);
                    Global.ControlCard.WriteOutbit(29, 0);
                    Global.ControlCard.WriteOutbit(30, 0);
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 加载项目配置信息
        /// </summary>
        /// <returns></returns>
        public static bool LoadSettings(string productName)
        {
            try
            {
                if (!System.IO.File.Exists(Global.ProductSettingPath))
                {
                    Log.GetInstance().ErrorWrite(string.Format("项目：'{0}'没有配置文件,路径：'{1}'", productName, Global.ProductSettingPath));
                    return false;
                }

                //初始化时，添加轴信息
                if (Global.ListAxis.Count == 0)
                {
                    AxisInfo axisInfo = null;
                    foreach (var kvp in Global.DictAxis)
                    {
                        axisInfo = new AxisInfo();
                        axisInfo.AxisName = kvp.Value;
                        axisInfo.AxisNumber = (ushort)Convert.ToInt32(kvp.Key);

                        axisInfo.Step = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "Step", Global.ProductSettingPath));
                        axisInfo.Lead = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "Lead", Global.ProductSettingPath));
                        axisInfo.MinVel = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "Speed", Global.ProductSettingPath));
                        axisInfo.MaxLimit = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "MaxLimitmm", Global.ProductSettingPath));
                        axisInfo.WorkPos1 = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "WorkPos1", Global.ProductSettingPath));
                        axisInfo.WorkPos2 = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "WorkPos2", Global.ProductSettingPath));
                        axisInfo.WorkPos3 = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "WorkPos3", Global.ProductSettingPath));
                        axisInfo.WorkPos4 = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "WorkPos4", Global.ProductSettingPath));

                        axisInfo.MaxVel = axisInfo.MinVel * 10;
                        axisInfo.Dec = 10000;
                        axisInfo.Acc = 10000;

                        axisInfo.Vel = axisInfo.MaxVel;
                        axisInfo.Outmode = 0;
                        axisInfo.OrgLogic = 0;
                        axisInfo.EzLogic = 0;
                        axisInfo.EzMode = 1;
                        axisInfo.HomeDir = 1;
                        axisInfo.Vel = 0;
                        axisInfo.HomeMode = 1;
                        axisInfo.EZCount = 1;
                        axisInfo.PosiMode = 0;

                        Global.ListAxis.Add(axisInfo);
                    }
                }
                //切换项目时，修改轴信息
                else
                {
                    foreach (var axisInfo in Global.ListAxis)
                    {
                        axisInfo.Step = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "Step", Global.ProductSettingPath));
                        axisInfo.Lead = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "Lead", Global.ProductSettingPath));
                        axisInfo.MinVel = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "Speed", Global.ProductSettingPath));
                        axisInfo.MaxLimit = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "MaxLimitmm", Global.ProductSettingPath));
                        axisInfo.WorkPos1 = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "WorkPos1", Global.ProductSettingPath));
                        axisInfo.WorkPos2 = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "WorkPos2", Global.ProductSettingPath));
                        axisInfo.WorkPos3 = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "WorkPos3", Global.ProductSettingPath));
                        axisInfo.WorkPos4 = Convert.ToInt32(IniFile.IniReadValue(axisInfo.AxisName, "WorkPos4", Global.ProductSettingPath));

                        axisInfo.MaxVel = axisInfo.MinVel * 10;
                        axisInfo.Dec = 10000;
                        axisInfo.Acc = 10000;

                        axisInfo.Vel = axisInfo.MaxVel;
                        axisInfo.Outmode = 0;
                        axisInfo.OrgLogic = 0;
                        axisInfo.EzLogic = 0;
                        axisInfo.EzMode = 1;
                        axisInfo.HomeDir = 1;
                        axisInfo.Vel = 0;
                        axisInfo.HomeMode = 1;
                        axisInfo.EZCount = 1;
                        axisInfo.PosiMode = 0;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());

                return false;
            }
        }

        /// <summary>
        /// VCR扫码
        /// </summary>
        /// <param name="iixServer"></param>
        /// <returns></returns>
        public static bool SweepCode(IIXServer iixServer, ref string code)
        {
            try
            {
                var tasks = new List<Task>();
                var fX = false;
                var fY = false;

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    
                    var axisInfoX = Global.ListAxis.Where(info => info.AxisName == "VCR-X").FirstOrDefault();
                    axisInfoX.PosiMode = 1;

                    if (iixServer.AssociatedPanelPos == "#1")
                    {
                        axisInfoX.Dist = (int)axisInfoX.WorkPos1;
                    }
                    else if (iixServer.AssociatedPanelPos == "#2")
                    {
                        axisInfoX.Dist = (int)axisInfoX.WorkPos2;

                    }
                    else if (iixServer.AssociatedPanelPos == "#3")
                    {
                        axisInfoX.Dist = (int)axisInfoX.WorkPos3;
                    }

                    fX = MoveExecute.Pmove(axisInfoX, false);

                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var axisInfoZ = Global.ListAxis.Where(info => info.AxisName == "VCR-Z").FirstOrDefault();

                    axisInfoZ.PosiMode = 1;

                    if (iixServer.AssociatedPanelPos == "#1")
                    {
                        axisInfoZ.Dist = (int)axisInfoZ.WorkPos1;
                    }
                    else if (iixServer.AssociatedPanelPos == "#2")
                    {
                        axisInfoZ.Dist = (int)axisInfoZ.WorkPos2;

                    }
                    else if (iixServer.AssociatedPanelPos == "#3")
                    {
                        axisInfoZ.Dist = (int)axisInfoZ.WorkPos3;
                    }

                    fY = MoveExecute.Pmove(axisInfoZ, false);
                }));

                Task.WaitAll(tasks.ToArray());

                if (!fX || !fY)
                {
                    Log.GetInstance().ErrorWrite("VCR移动到指定位置失败");
                    return false;
                }

                //发送扫码指令
                Global.SocketServer.Send("Trigger");
                //休眠500毫秒，等待扫码完成
                Thread.Sleep(500);

                //获取二维码编号
                code = Global.SocketServer.Code;

                Log.GetInstance().NormalWrite(string.Format(""));

                //清空二维码
                Global.SocketServer.Code = "";

                //判断二维码的结果

                var codeResult = MoveExecute.Result.Successful;

                //查询当前屏幕是否在集合中存在
                OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

                //存在则删除
                if (panel != null)
                {
                    //操作检测屏幕集合时加锁，防止线程启动过快导致集合修改的异常
                    lock (Global.ListOLEDPanel)
                    {
                        Global.ListOLEDPanel.Remove(panel);
                    }
                }

                lock (Global.ListOLEDPanel)
                {
                    panel = new OLEDPanel();
                    panel.PanelNumber = code;
                    panel.PanelPos = iixServer.AssociatedPanelPos;
                    panel.DmrSvrApi = iixServer.DmrSvrApi;
                    panel.PanelWorkPos = "工位#1";
                    panel.CmdResWork = codeResult == MoveExecute.Result.Successful ? CmdResultCode.Success : CmdResultCode.Other;
                    panel.IsRotate = false;
                    panel.IsPanelOn = false;

                    //将屏添加到集合中
                    Global.ListOLEDPanel.Add(panel);
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());

                return false;
            }
        }
    }
}
 