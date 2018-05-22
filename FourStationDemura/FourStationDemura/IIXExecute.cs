using IIXDeMuraApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourStationDemura
{
    public class IIXExecute
    {
        /// <summary>
        /// 确立和 SlavePC 的连接 
        /// </summary>
        /// <returns></returns>
        public static CmdResultCode Connection(IIXServer iixServer)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            cmdRes = iixServer.DmrSvrApi.Connect(iixServer.Ip, iixServer.Port);
            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                iixServer.ConnState = ConnectionCode.Connect;
                Log.GetInstance().NormalWrite(string.Format("连接{0}服务端成功", iixServer.Ip));
            }
            else
            {
                iixServer.ConnState = ConnectionCode.Disconnect;
                Log.GetInstance().ErrorWrite(string.Format("连接{0}服务端失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            Global.UpdateDgv(ip: iixServer.Ip, connOpen: iixServer.ConnState.ToString(), latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 打开SlavePC
        /// </summary>
        /// <param name="iixServer"></param>
        /// <returns></returns>
        public static CmdResultCode Open(IIXServer iixServer)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            cmdRes = iixServer.DmrSvrApi.Open();
            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                iixServer.ConnState = ConnectionCode.Connect;
                Log.GetInstance().NormalWrite(string.Format("打开[{0}]服务端成功", iixServer.Ip));
            }
            else
            {
                iixServer.ConnState = ConnectionCode.Disconnect;
                Log.GetInstance().ErrorWrite(string.Format("打开[{0}]服务端失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            Global.UpdateDgv(ip: iixServer.Ip, connOpen: iixServer.ConnState.ToString(), latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 获取SlavePC管理Device的状态
        /// </summary>
        /// <param name="iixServer"></param>
        public static void GetDeviceState(IIXServer iixServer)
        {
            List<DevStatCode> listState = iixServer.DmrSvrApi.GetDeviceStatus();

            if (listState[0].ToString() == "AllOK")
            {
                iixServer.LatestResult = listState[0].ToString();
                Log.GetInstance().NormalWrite(string.Format("获取[{0}]管理Device的状态成功", iixServer.Ip));
            }
            else
            {
                iixServer.LatestResult = listState[0].ToString();
                Log.GetInstance().ErrorWrite(string.Format("获取[{0}]管理Device的状态失败，Error：{1}", iixServer.Ip, iixServer.LatestResult));
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);
        }

        /// <summary>
        /// 获取License剩余次数的请求 
        /// </summary>
        /// <param name="iixServer"></param>
        /// <returns></returns>
        public static int GetRemainingCount(IIXServer iixServer)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            TransferCounterInfo tci = iixServer.DmrSvrApi.GetRemainingCount();
            cmdRes = tci.CmdResult;
            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                Log.GetInstance().NormalWrite(string.Format("获取[{0}]License剩余次数[{1}]成功 ", iixServer.Ip, tci.Count));
            }
            else
            {
                Log.GetInstance().ErrorWrite(string.Format("获取[{0}]License剩余次数失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return tci.Count;
        }

        /// <summary>
        /// 关闭 SlavePC 所管理的 Device 
        /// </summary>
        /// <param name="iixServer"></param>
        /// <returns></returns>
        public static CmdResultCode Close(IIXServer iixServer)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            cmdRes = iixServer.DmrSvrApi.Close();
            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                iixServer.ConnState = ConnectionCode.Close;
                iixServer.SetCloseFinished();
                Log.GetInstance().NormalWrite(string.Format("关闭[{0}]所管理的Device成功", iixServer.Ip));
            }
            else
            {
                Log.GetInstance().ErrorWrite(string.Format("关闭[{0}]所管理的Device失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            Global.UpdateDgv(ip: iixServer.Ip, connOpen: iixServer.ConnState.ToString(), pgPrimary: iixServer.OutlineState[0].ToString(), pgSecondary: iixServer.OutlineState[1].ToString(), latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 切断和 SlavePC 的连接
        /// </summary>
        /// <param name="iixServer"></param>
        /// <returns></returns>
        public static CmdResultCode Disconnect(IIXServer iixServer)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            cmdRes = iixServer.DmrSvrApi.Disconnect();
            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                iixServer.ConnState = ConnectionCode.Disconnect;
                Log.GetInstance().NormalWrite(string.Format("关闭[{0}]服务端成功", iixServer.Ip));
            }
            else
            {
                Log.GetInstance().ErrorWrite(string.Format("关闭[{0}]服务端成功，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            Global.UpdateDgv(ip: iixServer.Ip, connOpen: iixServer.ConnState.ToString(), latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 连续指令开始
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode SequenceStart(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.SequenceStart(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        iixServer.SetSequenceStart(pg);
                        Log.GetInstance().NormalWrite(string.Format("[{0}]连续指令[{1}]开始成功", iixServer.Ip, pg.ToString()));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]连续指令[{1}]开始失败，Error：{1}", iixServer.Ip, pg.ToString(), cmdRes.ToString()));
                    }
                }
                else
                {
                    cmdRes = panel.CmdResWork;
                    Log.GetInstance().ErrorWrite(string.Format("[{0}]连续指令开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }


            Global.UpdateDgv(ip: iixServer.Ip, pgPrimary: OutlineStateCode.PanelChk.ToString(), latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 连续指令结束
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode SequenceEnd(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.SequenceEnd(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        iixServer.SetSequenceEnd(pg);
                        Log.GetInstance().NormalWrite(string.Format("[{0}]连续指令[{1}]结束成功", iixServer.Ip, pg.ToString()));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]连续指令[{1}]结束失败，Error：{2}", iixServer.Ip, pg.ToString(), cmdRes.ToString()));
                    }
                }
                else
                {
                    cmdRes = panel.CmdResWork;
                    Log.GetInstance().ErrorWrite(string.Format("[{0}]连续指令结束失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, pgPrimary: OutlineStateCode.Stable.ToString(), latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 点灯
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode PanelOn(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.PanelOn(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        panel.IsPanelOn = true;
                        iixServer.IsPanelOn = true;
                        Log.GetInstance().NormalWrite(string.Format("屏[{0}]点灯成功", iixServer.AssociatedPanelPos));
                    }
                    else
                    {
                        iixServer.IsPanelOn = false;
                        Log.GetInstance().ErrorWrite(string.Format("屏[{0}]点灯失败，Error：{1}", iixServer.AssociatedPanelPos, cmdRes.ToString()));
                    }
                }
                else
                {
                    cmdRes = panel.CmdResWork;
                    Log.GetInstance().ErrorWrite(string.Format("屏[{0}]点灯失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 关灯
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode PanelOff(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null && panel.IsPanelOn)
            {
                cmdRes = iixServer.DmrSvrApi.PanelOff(pg);
                iixServer.LatestResult = cmdRes.ToString();

                if (cmdRes == CmdResultCode.Success)
                {
                    iixServer.IsPanelOn = false;
                    Log.GetInstance().NormalWrite(string.Format("屏[{0}]关灯成功", iixServer.AssociatedPanelPos));
                }
                else
                {
                    iixServer.IsPanelOn = true;
                    Log.GetInstance().ErrorWrite(string.Format("屏[{0}]关灯失败，Error：{1}", iixServer.AssociatedPanelPos, cmdRes.ToString()));
                }

                //如果上一个工位的检测结果是正确的才继续执行当前工位的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                    //修改当前的工作位置
                    panel.PanelWorkPos = "工位1";
                }
                else
                {
                    cmdRes = panel.CmdResWork;
                    panel.PanelWorkPos = "工位1";
                }

                lock(Global.ListOLEDPanel)
                {
                    //将屏从集合中移除
                    Global.ListOLEDPanel.Remove(panel);
                }

                //当所有流程执行完后关灯时添加成功/失败数
                if (panel.IsRotate)
                {
                    if (cmdRes == CmdResultCode.Success)
                    {
                        Global.PassNumber++;
                    }
                    else
                    {
                        Global.FailNumber++;
                    }
                }
            }

            Global.SetNumber();

            return cmdRes;
        }

        /// <summary>
        /// 转换PG
        /// </summary>
        /// <param name="iixServer"></param>
        /// <returns></returns>
        public static CmdResultCode TableRotation(IIXServer iixServer)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.TableRotation();
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        iixServer.SetTableRotation();
                        Log.GetInstance().NormalWrite(string.Format("[{0}]转换PG成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]转换PG失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }
                }
                else
                {
                    cmdRes = panel.CmdResWork;
                    Log.GetInstance().ErrorWrite(string.Format("[{0}]转换PG失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, pgPrimary: iixServer.OutlineState[0].ToString(), pgSecondary: iixServer.OutlineState[1].ToString(), latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// DeMura（Mura补正拍摄・Flash 写入）开始
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode DeMuraStart(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作 
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.DeMuraStart(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]DeMura（Mura补正拍摄・Flash 写入）开始成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]DeMura（Mura补正拍摄・Flash 写入）开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]DeMura（Mura补正拍摄・Flash 写入）开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 获取DeMura（Mura补正拍摄・Flash 写入）结果
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode GetDeMuraResult(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.GetDeMuraResult(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("获取[{0}]DeMura（Mura补正拍摄・Flash 写入）结果成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("获取[{0}]DeMura（Mura补正拍摄・Flash 写入）结果失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("获取[{0}]DeMura（Mura补正拍摄・Flash 写入）结果失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// DeMura Check（补正结果确认）开始
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode DeMuraCheckStart(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.DeMuraCheckStart(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]DeMura Check（补正结果确认）开始成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]DeMura Check（补正结果确认）开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }                    
                    
                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]DeMura Check（补正结果确认）开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            return cmdRes;
        }

        /// <summary>
        /// 获取DeMura Check（补正结果确认）結果
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode GetDeMuraCheckResult(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.GetDeMuraCheckResult(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("获取[{0}]DeMura Check（补正结果确认）結果成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("获取[{0}]DeMura Check（补正结果确认）結果失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("获取[{0}]DeMura Check（补正结果确认）結果失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 中断DeMura
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode AbortDeMura(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.AbortDeMura(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]中断DeMura成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]中断DeMura失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]中断DeMura失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// Flash Memory全部删除
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode EraseFlashMemory(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.EraseFlashMemory(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]Flash Memory全部删除成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]Flash Memory全部删除失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]Flash Memory全部删除失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 获取Flash Memory的删除或写入处理结果
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode GetFlashMemoryResult(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.GetFlashMemoryResult(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("获取[{0}]Flash Memory的删除或写入处理结果成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("获取[{0}]Flash Memory的删除或写入处理结果失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("获取[{0}]Flash Memory的删除或写入处理结果失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 变更为进行Z轴调整、对位的状态开始
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode AlignmentStart(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.AlignmentStart(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]变更为进行Z轴调整、对位的状态开始成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]变更为进行Z轴调整、对位的状态开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]变更为进行Z轴调整、对位的状态开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// Z轴调整、对位状态结束
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode AlignmentStop(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.AlignmentStop(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]Z轴调整、对位状态结束成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]Z轴调整、对位状态结束失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]Z轴调整、对位状态结束失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// Focus调整开始
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode FocusCheckStart(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.FocusCheckStart(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]Focus调整开始成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]Focus调整开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]Focus调整开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// Capture（获取拍摄数据）处理开始
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode CaptureStart(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.CaptureStart(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]Capture（获取拍摄数据）处理开始成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]Capture（获取拍摄数据）处理开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]Capture（获取拍摄数据）处理开始失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 获取Capture（获取拍摄数据）处理结果
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static CmdResultCode GetCaptureResult(IIXServer iixServer, PgSelectCode pg)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.GetCaptureResult(pg);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("获取[{0}]Capture（获取拍摄数据）处理结果成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("获取[{0}]Capture（获取拍摄数据）处理结果失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("获取[{0}]Capture（获取拍摄数据）处理结果失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 设置Panel显示Raster图像
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <param name="color"></param>
        /// <param name="isFactory"></param>
        /// <returns></returns>
        public static CmdResultCode SetRasterImage(IIXServer iixServer,PgSelectCode pg, Color color, bool isFactory)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.SetRasterImage(pg, color.R, color.G, color.B, isFactory);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("设置[{0}]Panel显示Raster图像成功", iixServer.Ip));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("设置[{0}]Panel显示Raster图像失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("设置[{0}]Panel显示Raster图像失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 向Flash Memory写入文件
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static CmdResultCode WriteFlashMemory(IIXServer iixServer, PgSelectCode pg, string fileName)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            //查询当前屏幕是否在集合中存在
            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (panel != null)
            {
                //如果上一次的检测结果是正确的才继续执行当前的工作
                if (panel.CmdResWork == CmdResultCode.Success)
                {
                    cmdRes = iixServer.DmrSvrApi.WriteFlashMemory(pg, fileName);
                    iixServer.LatestResult = cmdRes.ToString();

                    if (cmdRes == CmdResultCode.Success)
                    {
                        Log.GetInstance().NormalWrite(string.Format("[{0}]向Flash Memory写入文件[{1}]成功", iixServer.Ip, fileName));
                    }
                    else
                    {
                        Log.GetInstance().ErrorWrite(string.Format("[{0}]向Flash Memory写入文件[{1}]失败，Error：{2}", iixServer.Ip, fileName, cmdRes.ToString()));
                    }

                    //修改执行结果
                    panel.CmdResWork = cmdRes;
                }
                else
                {
                    cmdRes = panel.CmdResWork;

                    Log.GetInstance().ErrorWrite(string.Format("[{0}]向Flash Memory写入文件[{1}]失败，Error：{2}", iixServer.Ip, fileName, cmdRes.ToString()));
                }
            }

            Global.UpdateDgv(ip: iixServer.Ip, latestResult: iixServer.LatestResult);

            return cmdRes;
        }

        /// <summary>
        /// 设置Recipe
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="recipeFile"></param>
        /// <returns></returns>
        public static CmdResultCode SetRecipe(IIXServer iixServer, string recipeFile)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            cmdRes = iixServer.DmrSvrApi.SetRecipe(recipeFile);
            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                Log.GetInstance().NormalWrite(string.Format("[{0}]设置Recipe成功", iixServer.Ip));
            }
            else
            {
                Log.GetInstance().ErrorWrite(string.Format("[{0}]设置Recipe失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            return cmdRes;
        }

        /// <summary>
        /// 获取Recipe
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="recipePath"></param>
        /// <returns></returns>
        public static CmdResultCode GetRecipe(IIXServer iixServer, string recipePath)
        {
            TransferFileInfo tfi = iixServer.DmrSvrApi.GetRecipe();

            CmdResultCode cmdRes = (tfi.IsValid) ? CmdResultCode.Success : CmdResultCode.Other;
            if (tfi.IsValid)
            {
                tfi.Save(recipePath);
            }

            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                Log.GetInstance().NormalWrite(string.Format("[{0}]获取Recipe成功", iixServer.Ip));
            }
            else
            {
                Log.GetInstance().ErrorWrite(string.Format("[{0}]获取Recipe失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            return cmdRes;
        }

        /// <summary>
        /// 更新License
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="licenseFile"></param>
        /// <returns></returns>
        public static CmdResultCode UpdateLicense(IIXServer iixServer, string licenseFile)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            cmdRes = iixServer.DmrSvrApi.UpdateLicense(licenseFile);
            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                Log.GetInstance().NormalWrite(string.Format("[{0}]更新License成功", iixServer.Ip));
            }
            else
            {
                Log.GetInstance().ErrorWrite(string.Format("[{0}]更新License失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            return cmdRes;
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static CmdResultCode AdjustPCTime(IIXServer iixServer, DateTimeInfo dateTime)
        {
            CmdResultCode cmdRes = CmdResultCode.Other;

            cmdRes = iixServer.DmrSvrApi.AdjustPCTime(dateTime);
            iixServer.LatestResult = cmdRes.ToString();

            if (cmdRes == CmdResultCode.Success)
            {
                Log.GetInstance().NormalWrite(string.Format("[{0}]修改时间成功", iixServer.Ip));
            }
            else
            {
                Log.GetInstance().ErrorWrite(string.Format("[{0}]修改时间失败，Error：{1}", iixServer.Ip, cmdRes.ToString()));
            }

            return cmdRes;
        }
    }
}
