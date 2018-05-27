using IIXDeMuraApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    public partial class FormManualCheck : Form
    {

        //转盘当前位置
        private double currentWorkPos = 0;

        private System.Timers.Timer timerReset;

        #region 构造函数

        public FormManualCheck()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法

        public void isEnabled(bool f)
        {
            this.btnStation_1.Enabled = f;
            this.btnStation_2.Enabled = f;
            this.btnStation_3.Enabled = f;
            this.btnStation_4.Enabled = f;
            this.cbbIO.Enabled = f;
            this.btnOpenIo.Enabled = f;
            this.btnCloseIo.Enabled = f;
            this.btnSweep.Enabled = f;
            this.txtLock.Enabled = f;
            this.btnCheckLock.Enabled = f;

            this.cbbIO.SelectedIndex = 0;
        }

        /// <summary>
        /// 移动到指定工作位置
        /// </summary>
        /// <param name="axisInfo"></param>
        /// <param name="workNumber"></param>
        public void MoveWorkPos(List<AxisInfo> listAxisInfo, int workNumber)
        {
            //气缸上
            var fRtn = MoveExecute.SetBaffle(true);
            if (!fRtn) return;

            double workPos = 0;

            foreach (var axisInfo in listAxisInfo)
            {
                switch (workNumber)
                {
                    case 1:
                        {
                            workPos = axisInfo.WorkPos1;
                            break;
                        }
                    case 2:
                        {
                            workPos = axisInfo.WorkPos2;
                            break;
                        }
                    case 3:
                        {
                            workPos = axisInfo.WorkPos3;
                            break;
                        }
                    case 4:
                        {
                            workPos = axisInfo.WorkPos4;
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }

                if (axisInfo.AxisName == "转盘")
                {
                    //如果移动后的位置大于最大位置，则轴的当前位置设置为0
                    if (currentWorkPos + workPos > axisInfo.Lead)
                    {
                        axisInfo.CurrentPosition = 0;
                        Global.ControlCard.SetPosition(axisInfo, false);
                    }
                }

                axisInfo.Dist = Convert.ToInt32(workPos * axisInfo.Step / axisInfo.Lead);
                axisInfo.PosiMode = 1;

                MoveExecute.Pmove(axisInfo, true);

                this.userMove1.GetCurrentPosition(axisInfo);

                if (axisInfo.AxisName == "转盘")
                {
                    this.currentWorkPos = Global.ControlCard.GetPosition(axisInfo, true);
                }
            }
        }

        /// <summary>
        /// 上传文件到FTP
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        private string UploadFileByFtp(string filePath, string ip)
        {
            var fileName = Path.GetFileName(filePath);

            try
            {
                Uri ftpUri = new Uri(string.Format("ftp://{0}/{1}", ip, fileName));

                var ftpReq = (FtpWebRequest)WebRequest.Create(ftpUri);
                ftpReq.Credentials = new NetworkCredential("DeMuraFTPUser", "DeMura01FTP23User");
                ftpReq.Method = WebRequestMethods.Ftp.UploadFile;
                ftpReq.KeepAlive = false;
                ftpReq.UseBinary = true;
                ftpReq.UsePassive = false;

                using (Stream reqStrm = ftpReq.GetRequestStream())
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        int readSize = fs.Read(buffer, 0, buffer.Length);
                        if (readSize == 0) break;
                        reqStrm.Write(buffer, 0, readSize);
                    }
                }

                using (FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse())
                {
                    Log.GetInstance().NormalWrite(string.Format("向[{0}]上传文件[{1}]成功", ip, fileName));
                }
            }
            catch (Exception ex)
            {
                Log.GetInstance().WarningWrite(string.Format("向[{0}]上传文件[{1}]失败", ip, fileName));
                Log.WriterExceptionLog(ex.ToString());
                fileName = string.Empty;
            }
            return fileName;
        }

        #endregion

        #region 事件

        private void btnStation_4_Click(object sender, EventArgs e)
        {
            this.MoveWorkPos(this.userMove1.listAxisInfo, 4);

            Global.WorkPos = 4;
        }

        private void btnStation_2_Click(object sender, EventArgs e)
        {
            this.MoveWorkPos(this.userMove1.listAxisInfo, 2);

            Global.WorkPos = 2;
        }

        private void btnStation_3_Click(object sender, EventArgs e)
        {
            this.MoveWorkPos(this.userMove1.listAxisInfo, 3);

            Global.WorkPos = 3;
        }

        private void btnStation_1_Click(object sender, EventArgs e)
        {
            this.MoveWorkPos(this.userMove1.listAxisInfo, 1);

            Global.WorkPos = 1;
        }

        private void FormManualCheck_Load(object sender, EventArgs e)
        {
            this.isEnabled(Global.IsAllowMove);
            Global.IsAllowMoveEvent += Global_IsAllowMoveEvent;

            Color color = Color.FromArgb(128, 128, 128);

            this.txtSetRaster.Text = string.Format("R:{0:D3}, G:{1:D3}, B:{2:D3}", color.R, color.G, color.B);
            this.pnlColor.BackColor = color;

            this.timerReset = new System.Timers.Timer();
            this.timerReset.Elapsed += Timer_Elapsed;
            this.timerReset.Interval = 100;
            this.timerReset.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.timerReset.Stop();
            var f = MoveExecute.AllAxisReset();

            AxisInfo axisInfo = Global.ListAxis.Where(info => info.AxisName == "转盘").FirstOrDefault();
            if (axisInfo != null)
            {
                this.currentWorkPos = axisInfo.WorkPos1;
            }
        }

        private void Global_IsAllowMoveEvent()
        {
            this.isEnabled(Global.IsAllowMove);
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        IIXExecute.Connection(iixServer);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        IIXExecute.Open(iixServer);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 获取SlavePC管理Device的状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetState_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        IIXExecute.GetDeviceState(iixServer);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 获取License剩余次数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetRemainingCount_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        IIXExecute.GetRemainingCount(iixServer);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        IIXExecute.Close(iixServer);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        IIXExecute.Disconnect(iixServer);
                    }));
                }

            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 连续指令开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeqStart_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    if (iixServer.SvrType == SvrType.Right)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            IIXExecute.SequenceStart(iixServer, PgSelectCode.Primary);
                        }));
                    }
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 连续指令结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeqEnd_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    if (iixServer.SvrType == SvrType.Left)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            IIXExecute.SequenceEnd(iixServer, PgSelectCode.Primary);
                        }));
                    }
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 点亮屏幕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanelOn_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    if (iixServer.SvrType == SvrType.Right)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            IIXExecute.PanelOn(iixServer, PgSelectCode.Primary);
                        }));
                    }
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 熄灭屏幕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanelOff_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    if (iixServer.SvrType == SvrType.Right)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            if (IIXExecute.PanelOff(iixServer, PgSelectCode.Primary) == CmdResultCode.Success)
                            {
                                Log.GetInstance().NormalWrite(string.Format("屏幕[{0}]Demura作业成功", iixServer.AssociatedPanelPos));
                            }
                            else
                            {
                                Log.GetInstance().ErrorWrite(string.Format("屏幕[{0}]Demura作业失败", iixServer.AssociatedPanelPos));
                            }
                        }));
                    }
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 转换PG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTblRotate_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.TableRotation(iixServer);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// DeMura（Mura补正拍摄・Flash 写入）开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeMuraStart_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.DeMuraStart(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString()); 
            }
        }

        /// <summary>
        /// 获取DeMura（Mura补正拍摄・Flash 写入）结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeMuraResult_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.GetDeMuraResult(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// DeMura Check（补正结果确认）开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeMuraCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.DeMuraCheckStart(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 获取DeMura Check（补正结果确认）結果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeMraCheckResult_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.GetDeMuraCheckResult(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 中断DeMura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbortDeMura_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.AbortDeMura(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// Flash Memory全部删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlashErase_Click(object sender, EventArgs e)
        {
            try
            {
                var res = MessageBox.Show("你确定要擦除IC里的内容吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res != DialogResult.OK) return;

                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.EraseFlashMemory(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 获取Flash Memory的删除或写入处理结果
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="pg"></param>
        /// <returns></returns>
        private void btnFlashResult_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.GetFlashMemoryResult(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 变更为进行Z轴调整、对位的状态开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlignmentStart_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.AlignmentStart(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// Z轴调整、对位状态结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlignmentStop_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.AlignmentStop(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// Focus调整开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFocusCheckStart_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.FocusCheckStart(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// Capture（获取拍摄数据）处理开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaptureStart_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.CaptureStart(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 获取Capture（获取拍摄数据）处理结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaptureResult_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                        IIXExecute.GetCaptureResult(iixServer, pg);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 设置Panel显示Raster图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetRaster_Click(object sender, EventArgs e)
        {
            try
            {
                FormImageColor formImageColor = new FormImageColor();

                if (formImageColor.ShowDialog() == DialogResult.OK)
                {
                    Color color = formImageColor.Color;
                    this.txtSetRaster.Text = string.Format("R:{0:D3}, G:{1:D3}, B:{2:D3}", color.R, color.G, color.B);
                    this.pnlColor.BackColor = color;

                    var tasks = new List<Task>();

                    foreach (var iixServer in Global.ListIIXSerevr)
                    {
                        if (iixServer.IsEnable == false) continue;

                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                            IIXExecute.SetRasterImage(iixServer, pg, color, formImageColor.IsFactory);
                        }));
                    }

                    Task.WaitAll(tasks.ToArray());
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 向Flash Memory写入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlashWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FormWriteFlashMemory formWriteFlashMemory = new FormWriteFlashMemory();
                if (formWriteFlashMemory.ShowDialog() == DialogResult.OK)
                {
                    string fileName = "";
                    this.txtFlashWrite.Text = formWriteFlashMemory.FilePath;

                    if (formWriteFlashMemory.FilePath == null || formWriteFlashMemory.FilePath == "")
                    {
                        Log.GetInstance().WarningWrite("File name is empty");
                        return;
                    }

                    if (!File.Exists(formWriteFlashMemory.FilePath))
                    {
                        Log.GetInstance().WarningWrite("File does not exist.path:" + formWriteFlashMemory.FilePath);
                        return;
                    }

                    fileName = Path.GetFileName(formWriteFlashMemory.FilePath);

                    var tasks = new List<Task>();

                    foreach (var iixServer in Global.ListIIXSerevr)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            if (formWriteFlashMemory.IsUploadFile)
                            {
                                fileName = UploadFileByFtp(formWriteFlashMemory.FilePath, iixServer.Ip);
                            }

                            if (fileName == "") return;

                            PgSelectCode pg = iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary;
                            IIXExecute.WriteFlashMemory(iixServer, pg, fileName);
                        }));
                    }

                    Task.WaitAll(tasks.ToArray());
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        private void FormManualCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// IO开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenIo_Click(object sender, EventArgs e)
        {
            if (this.cbbIO.SelectedItem.ToString() == "真空")
            {
                var tasks = new List<Task>();

                foreach (var _iixServer in Global.ListIIXSerevr)
                {
                    if (_iixServer.IsEnable == false) continue;

                    if (_iixServer.SvrType == SvrType.Right)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            MoveExecute.SetVacuum(_iixServer, true);
                        }));
                    }
                }
            }
            else if (this.cbbIO.SelectedItem.ToString() == "治具防呆")
            {
                var tasks = new List<Task>();

                foreach (var _iixServer in Global.ListIIXSerevr)
                {
                    if (_iixServer.IsEnable == false) continue;

                    if (_iixServer.SvrType == SvrType.Right)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            MoveExecute.SetPanelLock(_iixServer, true);
                        }));
                    }
                }
            }
            else if (this.cbbIO.SelectedItem.ToString() == "暗室气缸")
            {
                MoveExecute.SetBaffle(true);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "轴使能")
            {
                MoveExecute.SetAxisLock(true);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "报警")
            {
                Global.ControlCard.WriteOutbit(28, 1);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "黄灯")
            {
                Global.ControlCard.WriteOutbit(26, 1);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "红灯")
            {
                Global.ControlCard.WriteOutbit(25, 1);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "绿灯")
            {
                Global.ControlCard.WriteOutbit(27, 1);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "启动按钮1灯")
            {
                Global.ControlCard.WriteOutbit(29, 1);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "启动按钮2灯")
            {
                Global.ControlCard.WriteOutbit(30, 1);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "按钮1灯")
            {
                Global.ControlCard.WriteOutbit(31, 1);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "按钮2灯")
            {
                Global.ControlCard.WriteOutbit(32, 1);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "按钮3灯")
            {
                Global.ControlCard.WriteOutbit(59, 1);
            }
        }

        private void btnCloseIo_Click(object sender, EventArgs e)
        {
            if (this.cbbIO.SelectedItem.ToString() == "真空")
            {
                var tasks = new List<Task>();

                foreach (var _iixServer in Global.ListIIXSerevr)
                {
                    if (_iixServer.IsEnable == false) continue;

                    if (_iixServer.SvrType == SvrType.Right)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            MoveExecute.SetVacuum(_iixServer, false);
                        }));
                    }
                }
            }
            else if (this.cbbIO.SelectedItem.ToString() == "治具防呆")
            {
                var tasks = new List<Task>();

                foreach (var _iixServer in Global.ListIIXSerevr)
                {
                    if (_iixServer.IsEnable == false) continue;

                    if (_iixServer.SvrType == SvrType.Right)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            MoveExecute.SetPanelLock(_iixServer, false);
                        }));
                    }
                }
            }
            else if (this.cbbIO.SelectedItem.ToString() == "暗室气缸")
            {
                MoveExecute.SetBaffle(false);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "轴使能")
            {
                MoveExecute.SetAxisLock(false);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "报警")
            {
                Global.ControlCard.WriteOutbit(28, 0);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "黄灯")
            {
                Global.ControlCard.WriteOutbit(26, 0);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "红灯")
            {
                Global.ControlCard.WriteOutbit(25, 0);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "绿灯")
            {
                Global.ControlCard.WriteOutbit(27, 0);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "启动按钮1灯")
            {
                Global.ControlCard.WriteOutbit(29, 0);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "启动按钮2灯")
            {
                Global.ControlCard.WriteOutbit(30, 0);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "按钮1灯")
            {
                Global.ControlCard.WriteOutbit(31, 0);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "按钮2灯")
            {
                Global.ControlCard.WriteOutbit(32, 0);
            }
            else if (this.cbbIO.SelectedItem.ToString() == "按钮3灯")
            {
                Global.ControlCard.WriteOutbit(59, 0);
            }
        }

        private void btnCheckLock_Click(object sender, EventArgs e)
        {
            this.txtLock.Text = Global.ControlCard.ReadOutbit(53).ToString();
        }

        private void btnSweep_Click(object sender, EventArgs e)
        {
            Global.SocketServer.Send("Trigger");
            Thread.Sleep(500);
            this.txtCode.Text = Global.SocketServer.Code;
        }

        #endregion
    }
}
