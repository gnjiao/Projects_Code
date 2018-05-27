using IIXDeMuraApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourStationDemura
{
    public enum ConnectionCode
    {
        //连接
        Connect,
        //打开
        Open,
        //
        OpenFin,
        //关闭
        Close,
        //断开
        Disconnect,
    }

    public enum SvrType
    {
        Left = 0,
        Right
    }

    public class IIXServer
    {
        /// <summary>
        /// 关联的屏幕位置
        /// </summary>
        private string associatedPanelPos;

        /// <summary>
        /// IIX服务端
        /// </summary>
        private IDmrSvrApi dmrSvrApi;

        /// <summary>
        /// 服务器类型
        /// </summary>
        private SvrType svrType;

        /// <summary>
        /// 是否启用
        /// </summary>
        private bool isEnable = false;

        /// <summary>
        /// IP
        /// </summary>
        private string ip = "";

        /// <summary>
        /// 端口
        /// </summary>
        private int port = IixApiStaticInfo.DefaultPort;

        /// <summary>
        /// 连接的状态
        /// </summary>
        private ConnectionCode connState = ConnectionCode.Disconnect;

        /// <summary>
        /// PG的状态,0=PG-p;1=PG-s
        /// </summary>
        private OutlineStateCode[] outlineState = { OutlineStateCode.Invalid, OutlineStateCode.Invalid };

        /// <summary>
        /// 返回结果的状态
        /// </summary>
        private DevStatCode resultState = DevStatCode.AllOK;

        /// <summary>
        /// 最后一次返回的结果
        /// </summary>
        private string latestResult = CmdResultCode.NotRunning.ToString();

        /// <summary>
        /// 是否完成打开服务器
        /// </summary>
        private bool isOpenFinish = false;

        /// <summary>
        /// 是否完成DeMura拍摄
        /// </summary>
        private bool isCaptureFinish = false;

        /// <summary>
        /// 是否完成补正结果确认
        /// </summary>
        private bool isCheckFinish = false;

        /// <summary>
        /// 是否完成Flash保存
        /// </summary>
        private bool isSaveFinish = false;

        /// <summary>
        /// 是否完成Flash写入
        /// </summary>
        private bool isWriteFinish = false;

        /// <summary>
        /// 是否完成Flash擦除
        /// </summary>
        private bool isEraseFinish = false;

        /// <summary>
        /// 是否完成Focus自动调整
        /// </summary>
        private bool isFocusFinish = false;

        /// <summary>
        /// 是否完成Device的检测异常
        /// </summary>
        private bool isAbnormalDetect = false;

        /// <summary>
        /// 是否已经点灯成功
        /// </summary>
        private bool isPanelOn = false;

        /// <summary>
        /// IIX服务端
        /// </summary>
        public IDmrSvrApi DmrSvrApi
        {
            get { return dmrSvrApi; }
            set { dmrSvrApi = value; }
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable
        {
            get { return isEnable; }
            set { isEnable = value; }
        }

        /// <summary>
        /// IP
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// 连接的状态
        /// </summary>
        public ConnectionCode ConnState
        {
            get { return connState; }
            set { connState = value; }
        }

        /// <summary>
        /// PG的状态,0=PG-p;1=PG-s
        /// </summary>
        public OutlineStateCode[] OutlineState
        {
            get { return outlineState; }
            set { outlineState = value; }
        }

        /// <summary>
        /// 返回结果的状态
        /// </summary>
        public DevStatCode ResultState
        {
            get { return resultState; }
            set { resultState = value; }
        }

        /// <summary>
        /// 最后一次返回的结果
        /// </summary>
        public string LatestResult
        {
            get { return latestResult; }
            set { latestResult = value; }
        }

        /// <summary>
        /// 服务器类型
        /// </summary>
        public SvrType SvrType
        {
            get { return svrType; }
            set { svrType = value; }
        }

        /// <summary>
        /// 关联的屏幕位置
        /// </summary>
        public string AssociatedPanelPos
        {
            get { return associatedPanelPos; }
            set { associatedPanelPos = value; }
        }

        /// <summary>
        /// 是否完成打开服务器
        /// </summary>
        public bool IsOpenFinish
        {
            get { return isOpenFinish; }
            set { isOpenFinish = value; }
        }

        /// <summary>
        /// 是否完成DeMura拍摄
        /// </summary>
        public bool IsCaptureFinish
        {
            get { return isCaptureFinish; }
            set { isCaptureFinish = value; }
        }

        /// <summary>
        /// 是否完成补正结果确认
        /// </summary>
        public bool IsCheckFinish
        {
            get { return isCheckFinish; }
            set { isCheckFinish = value; }
        }

        /// <summary>
        /// 是否完成Flash保存
        /// </summary>
        public bool IsSaveFinish
        {
            get { return isSaveFinish; }
            set { isSaveFinish = value; }
        }

        /// <summary>
        /// 是否完成Flash写入
        /// </summary>
        public bool IsWriteFinish
        {
            get { return isWriteFinish; }
            set { isWriteFinish = value; }
        }

        /// <summary>
        /// 是否完成Flash擦除
        /// </summary>
        public bool IsEraseFinish
        {
            get { return isEraseFinish; }
            set { isEraseFinish = value; }
        }

        /// <summary>
        /// 是否完成Focus自动调整
        /// </summary>
        public bool IsFocusFinish
        {
            get { return isFocusFinish; }
            set { isFocusFinish = value; }
        }

        /// <summary>
        /// 是否完成Device的检测异常
        /// </summary> 
        public bool IsAbnormalDetect
        {
            get { return isAbnormalDetect; }
            set { isAbnormalDetect = value; }
        }

        /// <summary>
        /// 是否已经点灯成功
        /// </summary>
        public bool IsPanelOn
        {
            get { return isPanelOn; }
            set { isPanelOn = value; }
        }

        /// <summary>
        /// 将pg的状态修改为PanelChk
        /// </summary>
        /// <param name="pg"></param>
        public void SetSequenceStart(PgSelectCode pg)
        {
            int idx = pg.GetArrayIndex();
            this.OutlineState[idx] = OutlineStateCode.PanelChk;
        }

        /// <summary>
        /// 将pg的状态修改为Stable
        /// </summary>
        /// <param name="pg"></param>
        public void SetSequenceEnd(PgSelectCode pg)
        {
            int idx = pg.GetArrayIndex();
            this.OutlineState[idx] = OutlineStateCode.Stable;
        }

        public void SetTableRotation()
        {
            for (int i = 0; i < this.OutlineState.Length; i++)
            {
                if (this.OutlineState[i] == OutlineStateCode.PanelChk)
                {
                    this.OutlineState[i] = OutlineStateCode.Demura;
                }
                else if (this.OutlineState[i] == OutlineStateCode.Demura)
                {
                    this.OutlineState[i] = OutlineStateCode.PanelChk;
                }
            }
        }

        public void SetCloseFinished()
        {
            for (int i = 0; i < this.OutlineState.Length; i++)
            {
                this.OutlineState[i] = OutlineStateCode.Invalid;
            }
        }
    }
}
