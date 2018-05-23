using IIXDeMuraApi;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    public partial class FormAutomaticCheck : Form
    {
        #region 属性

        /// <summary>
        /// pattern编号
        /// </summary>
        private int patternNumber = 1;

        /// <summary>
        /// 是否有过旋转动作
        /// </summary>
        private bool IsRotate = false;

        /// <summary>
        /// 是否正在旋转(指转盘的动作)
        /// </summary>
        private bool isRotating = false;

        /// <summary>
        /// 是否正在进行Demura检查
        /// </summary>
        private bool isDemuraCheck = false;

        /// <summary>
        /// 是否正在进行Demura复检
        /// </summary>
        private bool isDemuraReinspection = false;

        /// <summary>
        /// 是否正在写入Flash
        /// </summary>
        private bool isWriteFlash = false;

        /// <summary>
        /// 是否正在点灯
        /// </summary>
        private bool isPanelOn = false;

        /// <summary>
        /// 是否正在关灯
        /// </summary>
        private bool isPanelOff = false;

        /// <summary>
        /// 检查主界面是否初始化完成
        /// </summary>
        private System.Timers.Timer timerCheckInit = null;

        /// <summary>
        /// 检测所有屏点灯按钮事件
        /// </summary>
        private System.Timers.Timer timerAllPanelOn = null;

        /// <summary>
        /// 检测所有屏关灯按钮事件
        /// </summary>
        private System.Timers.Timer timerAllPanelOff = null;

        /// <summary>
        /// 检测单个屏点灯/关灯事件
        /// </summary>
        private System.Timers.Timer timerPanelOnOrPanelOff = null;

        /// <summary>
        /// 检测转盘旋转事件
        /// </summary>
        private System.Timers.Timer timerRotate = null;

        /// <summary>
        /// 检测门禁传感器事件
        /// </summary>
        private System.Timers.Timer timeEntranceGuard = null;

        /// <summary>
        /// 检测安全光栅事件
        /// </summary>
        private System.Timers.Timer timeGrating = null;

        /// <summary>
        /// 提示信息窗口
        /// </summary>
        private UserPromptInfo promptInfo = null;

        /// <summary>
        /// 上下料提示信息集合
        /// </summary>
        private List<UserPromptInfo> listCheckPrompt = null;

        /// <summary>
        /// 是否触发了所有屏点灯事件
        /// </summary>
        private bool isAllPanelOnEvent = false;

        /// <summary>
        /// 是否触发了所有屏关灯事件
        /// </summary>
        private bool isAllPanelOffEvent = false;

        /// <summary>
        /// 连续检测的线程
        /// </summary>
        private Thread thCheckColor = null;

        /// <summary>
        /// 线程执行的标记
        /// </summary>
        private bool threadLoop = false;

        /// <summary>
        /// 定时器刷新的时间间隔
        /// </summary>
        private int interval = 1000;

        #endregion

        #region 构造函数

        public FormAutomaticCheck()
        {
            InitializeComponent();

#if DEBUG
            Button btnDebug = new Button();
            btnDebug.Text = "DebugStart";
            btnDebug.Click += BtnDebug_Click;
            btnDebug.Top = this.pbRotaryTable.Top + this.pbRotaryTable.Height + 10;
            btnDebug.Left = this.pbRotaryTable.Left;

            this.splitContainer1.Panel1.Controls.Add(btnDebug);
#endif
        }
        #region Ted add control
#if DEBUG
        private void BtnDebug_Click(object sender, EventArgs e)
        {
            Global.IsInit = true;
            this.isDemuraCheck = false;
            this.isPanelOn = false;
            this.isPanelOff = false;
            this.isDemuraReinspection = false;
            this.isWriteFlash = false;
            this.isRotating = false;
            Global.isContinue = false;
            Global.isReset = false;
        }
#endif
        #endregion

        #endregion

        #region 方法


        #region Ted Modifid 20180521

        /// <summary>
        /// 设置屏幕检测信息颜色，分组显示
        /// </summary>
        //public void SetDgvPanelRowColor()
        //{
        //    for (int index = 0; index < this.dgvPanel.Rows.Count; index++)
        //    {
        //        if (index >= 0 && index < 3)
        //        {
        //            this.dgvPanel.Rows[index].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else if (index >= 3 && index < 6)
        //        {
        //            this.dgvPanel.Rows[index].DefaultCellStyle.BackColor = Color.Lime;
        //        }
        //        else if (index >= 6 && index < 9)
        //        {
        //            this.dgvPanel.Rows[index].DefaultCellStyle.BackColor = Color.Aqua;
        //        }
        //        else if (index >= 9 && index < 12)
        //        {
        //            this.dgvPanel.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
        //        }
        //    }
        //}
        StationConfiguration stationConfiguration = StationConfiguration.GetInstance();
        public void SetDgvPanelRowColor()
        {
            int RowIndex = 0;
            Label[] labels = new Label[stationConfiguration.Stations.Length];

            for (int j = 0; j < stationConfiguration.Stations.Length; j++)
            {
                Station station = stationConfiguration.Stations[j];


                Color backgroundColor = ColorTranslator.FromHtml(station.color);
                for (int i = 0; i < stationConfiguration.PanelCountOfStation; i++)
                {
                    this.dgvPanel.Rows[RowIndex++].DefaultCellStyle.BackColor = backgroundColor;
                }
                labels[j] = new Label();
                labels[j].TextAlign = ContentAlignment.MiddleCenter;
                labels[j].AutoSize = true;
                labels[j].Text = station.name;
                labels[j].BackColor = backgroundColor;
                labels[j].Left = this.dgvPanel.Left - labels[j].Text.Length * 10;

                labels[j].Top = j == 0 ? this.dgvPanel.Top : labels[j - 1].Top + labels[j - 1].Height + 5;
            }
            this.gbResultPrompt.Controls.AddRange(labels);
        }
        #endregion

        #region Ted Modified 20180521
        /// <summary>
        /// 删除屏幕检测信息
        /// </summary>
        //public void DeleteDgvRow()
        //{
        //    try
        //    {
        //        this.dgvPanel.BeginInvoke((MethodInvoker)delegate
        //        {
        //            //当检测的屏有12块后，新加前需要删除最前的3块屏
        //            if (this.dgvPanel.Rows.Count == 12)
        //            {
        //                for (int i = 0; i < 3; i++)
        //                {
        //                    this.dgvPanel.Rows.RemoveAt(0);
        //                }
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.WriterExceptionLog(ex.ToString());
        //    }
        //}
        public void DeleteDgvRow(DataGridView dgv, int startIndex,int totalRemove)
        {
            if (dgv.InvokeRequired)
            {
                this.BeginInvoke(new Action(delegate { DeleteDgvRow(dgv, startIndex, totalRemove); }));
                return;
            }
            
            for (int i = 0; i < totalRemove; i++)
            {
                dgv.Rows.RemoveAt(startIndex);
            }
        }
        #endregion
        /// <summary>
        /// 修改屏幕检测信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="panelOnResult"></param>
        /// <param name="shootingResult"></param>
        /// <param name="writeFlashResult"></param>
        /// <param name="reinspectionResult"></param>
        /// <param name="panelOffResult"></param>
        /// <param name="failureReason"></param>
        public void UpdateDgv(string code, string position, string panelOnResult = null, string shootingResult = null, string writeFlashResult = null, string reinspectionResult = null, string panelOffResult = null, string failureReason = null)
        {
            try
            {
                this.dgvPanel.BeginInvoke((MethodInvoker)delegate
                {
                    DataGridViewRow dr = null;
                    foreach (DataGridViewRow row in this.dgvPanel.Rows)
                    {
                        if (row.Cells["Code"].Value.ToString() == code)
                        {
                            dr = row;
                            break;
                        }

                        dr.Cells["Position"].Value = position;

                        if (panelOnResult != null)
                        {
                            dr.Cells["PanelOnResult"].Value = panelOnResult;

                            //结果等于失败显示红色
                            if (panelOnResult == MoveExecute.Result.Failure.ToString())
                            {
                                dr.Cells["PanelOnResult"].Style.ForeColor = Color.Red;
                            }
                        }

                        if (shootingResult != null)
                        {
                            dr.Cells["ShootingResult"].Value = shootingResult;

                            //结果等于失败显示红色
                            if (shootingResult == MoveExecute.Result.Failure.ToString())
                            {
                                dr.Cells["ShootingResult"].Style.ForeColor = Color.Red;
                            }
                        }

                        if (writeFlashResult != null)
                        {
                            dr.Cells["WriteFlashResult"].Value = writeFlashResult;

                            //结果等于失败显示红色
                            if (writeFlashResult == MoveExecute.Result.Failure.ToString())
                            {
                                dr.Cells["WriteFlashResult"].Style.ForeColor = Color.Red;
                            }
                        }

                        if (reinspectionResult != null)
                        {
                            dr.Cells["ReinspectionResult"].Value = reinspectionResult;

                            //结果等于失败显示红色
                            if (reinspectionResult == MoveExecute.Result.Failure.ToString())
                            {
                                dr.Cells["ReinspectionResult"].Style.ForeColor = Color.Red;
                            }
                        }

                        if (panelOffResult != null)
                        {
                            dr.Cells["PanelOffResult"].Value = panelOffResult;

                            //结果等于失败显示红色
                            if (panelOffResult == MoveExecute.Result.Failure.ToString())
                            {
                                dr.Cells["PanelOffResult"].Style.ForeColor = Color.Red;
                            }
                        }

                        if (failureReason != null)
                        {
                            dr.Cells["FailureReason"].Value = failureReason;

                            dr.Cells["FailureReason"].Style.ForeColor = Color.Red;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 启动定时器
        /// </summary>
        public void Start()
        {
            //this.timerAllPanelOn.Start();
            //this.timerAllPanelOff.Start();
            //this.timerPanelOnOrPanelOff.Start();
            this.timerRotate.Start();
            //this.timeEntranceGuard.Start();  //检测门禁传感器的Timer
            //this.timeGrating.Start();
        }

        /// <summary>
        /// 关闭定时器
        /// </summary>
        public void Stop()
        {
            this.timerAllPanelOn.Stop();
            this.timerAllPanelOff.Stop();
            this.timerPanelOnOrPanelOff.Stop();
            this.timerRotate.Stop();
            this.timeEntranceGuard.Stop();
            this.timeGrating.Stop();

            this.threadLoop = false;
        }

        /// <summary>
        /// 连续检查
        /// </summary>
        public void ContinuousCheckColor()
        {
            try
            {
                while (this.threadLoop)
                {
                    Color color;
                    for (int i = 1; i <= Global.PatternNumber; i++)
                    {
                        //判断Pattern是否启用
                        if (IniFile.IniReadValue("Pattern" + i, "Enabled", Global.ProductSettingPath) == "1")
                        {
                            int R = Convert.ToInt32(IniFile.IniReadValue("Pattern" + i, "R", Global.ProductSettingPath));
                            int G = Convert.ToInt32(IniFile.IniReadValue("Pattern" + i, "G", Global.ProductSettingPath));
                            int B = Convert.ToInt32(IniFile.IniReadValue("Pattern" + i, "B", Global.ProductSettingPath));
                            int sleepTime = Convert.ToInt32(IniFile.IniReadValue("Pattern" + i, "SleepTime", Global.ProductSettingPath));

                            color = Color.FromArgb(R, G, B);


                            //Add 2018/5/21 Set the raster color
                            var tasks = new List<Task>();

                            foreach (var iixServer in Global.ListIIXSerevr)
                            {
                                if (iixServer.IsEnable == false) continue;

                                if (iixServer.SvrType == SvrType.Right)
                                {
                                    tasks.Add(Task.Factory.StartNew(() =>
                                    {
                                        IIXExecute.SetRasterImage(iixServer, PgSelectCode.Primary, color, false);
                                    }));
                                }
                            }

                            Task.WaitAll(tasks.ToArray());
                            //Add 2018/5/21


                            this.Invoke((MethodInvoker)delegate
                            {
                                this.pnlColor.BackColor = color;
                                this.gbPattern.Text = "Pattern" + i;
                            });

                            Thread.Sleep(sleepTime * 1000);
                        }
                        else
                        {
                            Log.GetInstance().NormalWrite("已经是最后一个Pattern了");
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.btnContinuousCheck.Text = "开始检查";
                                this.btnSingleCheck.Enabled = true;
                                this.btnOnColor.Enabled = false;
                                this.btnNextColor.Enabled = false;
                            });

                            this.threadLoop = false;
                            this.thCheckColor.Abort();
                        }
                    }
                }
            }
            catch (ThreadAbortException thEx)
            {

            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 显示上下料提示信息
        /// </summary>
        /// <param name="iixServer"></param>
        /// <param name="isPanelOn"></param>
        public void ShowCkeckImg(IIXServer iixServer, bool isPanelOn)
        {
            Image img;
            string content = "不能上料";

            //IIX服务端可用
            if (iixServer.IsEnable)
            {
                //点灯
                if (isPanelOn)
                {
                    //点灯成功后图片显示不能上料
                    if (iixServer.LatestResult == "Success")
                    {
                        img = this.imgList.Images["No.png"];
                        content = "不能上料";
                    }
                    //可以上料
                    else
                    {
                        img = this.imgList.Images["Yes.png"];
                        content = "可以上料";
                    }
                }
                //关灯/开始Demura后全部显示为可以上料
                else
                {
                    img = this.imgList.Images["Yes.png"];
                    content = "可以上料";
                }
            }
            else
            {
                img = this.imgList.Images["No.png"];
                content = "不能上料";
            }

            UserPromptInfo promptInfo = this.listCheckPrompt.Where(info => info.PanelNumber == iixServer.AssociatedPanelPos).FirstOrDefault();

            if (promptInfo != null)
            {
                promptInfo.SetPromptInfo(img, content);
            }
            else
            {
                MessageBox.Show(string.Format("没有找到屏[{0}]", iixServer.AssociatedPanelPos));
            }
        }

        /// <summary>
        /// 图片转换90度
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Bitmap KiRotate90(Bitmap img)
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 图片转换任意度数
        /// </summary>
        /// <param name="b"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public Bitmap Rotate(Bitmap b, int angle)
        {
            angle = angle % 360;
            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图
            Bitmap image = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(image);
            g.InterpolationMode = InterpolationMode.Bilinear;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换
            g.ResetTransform();
            g.Save();
            g.Dispose();
            return image;
        }

        /// <summary>
        /// 检查转盘是否在工作位置
        /// </summary>
        /// <returns></returns>
        public bool IsRotaryTableWorkPos()
        {
            bool f = false;

            try
            {
                //获取转盘轴
                AxisInfo axisInfo = Global.ListAxis.Where(info => info.AxisName == "转盘").FirstOrDefault();
                //当前位置
                var currPos = Global.ControlCard.GetPosition(axisInfo, false);

                if (currPos * axisInfo.Lead / axisInfo.Step == axisInfo.WorkPos1 ||
                    currPos * axisInfo.Lead / axisInfo.Step == axisInfo.WorkPos2 ||
                    currPos * axisInfo.Lead / axisInfo.Step == axisInfo.WorkPos3 ||
                    currPos * axisInfo.Lead / axisInfo.Step == axisInfo.WorkPos4)
                {
                    f = true;
                }
                else
                {
                    Log.GetInstance().ErrorWrite("转盘不在工作位置，不能做此操作");
                    f = false;
                }

            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                f = false;
            }

            return f;
        }
        /// <summary>
        /// 转盘旋转
        /// </summary>
        public bool Rotating()
        {
            try
            {
                if (Global.ControlCard.ReadInbit(53) == 1)
                {
                    Log.GetInstance().WarningWrite("转盘不能旋转");
                    return false;
                }

                //气缸上
                var fRtn = MoveExecute.SetBaffle(true);

                //气缸移动不到位不处理
                if (!fRtn) return false;

                this.patternNumber = 1;
                this.btnSingleCheck.Enabled = true;
                this.btnOnColor.Enabled = false;
                this.btnNextColor.Enabled = false;
                this.gbPattern.Text = "Pattern";
                this.pnlColor.BackColor = Color.White;

                if (this.btnContinuousCheck.Text == "停止检查")
                {
                    this.btnContinuousCheck.Text = "开始检查";
                    this.threadLoop = false;
                    this.thCheckColor.Abort();
                }

                Log.GetInstance().NormalWrite("转盘开始旋转");

                this.isRotating = true;

                AxisInfo axisInfo = Global.ListAxis.Where(info => info.AxisName == "转盘").FirstOrDefault();

                //目标工位
                string targetWorkPosName = "#1";
                //目标移动后的位置
                double targetWorkPos = 0;
                //当前位置
                double currentWorkPos = 0;

                if (Global.WorkPos == 1)
                {
                    currentWorkPos = axisInfo.WorkPos1;
                    targetWorkPos = axisInfo.WorkPos2;
                    targetWorkPosName = "#2";
                }
                else if (Global.WorkPos == 2)
                {
                    currentWorkPos = axisInfo.WorkPos2;
                    targetWorkPos = axisInfo.WorkPos3;
                    targetWorkPosName = "#3";
                }
                else if (Global.WorkPos == 3)
                {
                    currentWorkPos = axisInfo.WorkPos3;
                    targetWorkPos = axisInfo.WorkPos4;
                    targetWorkPosName = "#4";
                }
                else if (Global.WorkPos == 4)
                {
                    currentWorkPos = axisInfo.WorkPos4;
                    targetWorkPos = axisInfo.WorkPos1;
                    targetWorkPosName = "#1";
                }

                //当前位置
                var currPos = Global.ControlCard.GetPosition(axisInfo, false);

                //目标位置
                axisInfo.Dist = ((int)(targetWorkPos * axisInfo.Step / axisInfo.Lead));

                //如果移动后的位置大于最大位置，则轴的当前位置设置为0
                if (currentWorkPos + targetWorkPos > axisInfo.Lead)
                {
                    axisInfo.CurrentPosition = 0;
                    Global.ControlCard.SetPosition(axisInfo, false);
                }

                axisInfo.PosiMode = 1;
                var f = MoveExecute.Pmove(axisInfo, false);

                if (f && Global.ControlCard.GetPosition(axisInfo, false) == axisInfo.Dist)
                {
                    //亮绿灯
                    Global.ControlCard.WriteOutbit(27, 1);
                    Log.GetInstance().NormalWrite("转盘到达指定位置");
                    this.IsRotate = true;

                    //将dgv中屏幕信息调换位置
                    DataGridViewRow row = null;
                    for (int index = 0; index < 3; index++)
                    {
                        row = this.dgvPanel.Rows[0];
                        this.dgvPanel.Rows.Remove(row);
                        this.dgvPanel.Rows.Add(row);
                    }

                    this.SetDgvPanelRowColor();
                }
                else
                {
                    Global.isReset = true;
                    Log.GetInstance().WarningWrite("转盘移动到指定位置失败，需复位后重新开始检测");
                    return false;
                }
                
                this.BeginInvoke((MethodInvoker)delegate
                {
                    Image img = this.pbRotaryTable.Image;
                    Bitmap bmp = new Bitmap(img);
                    this.pbRotaryTable.Image = Rotate(bmp, -90);
                    this.pbRotaryTable.SizeMode = PictureBoxSizeMode.StretchImage;
                });

                //转盘旋转后重新设置屏幕所在的工作位置
                MoveExecute.SetPanelCurrentWorkPos();

                if (Global.WorkPos == 4)
                {
                    Global.WorkPos = 1;
                }
                else
                {
                    Global.WorkPos++;
                }

                //通知PG拍摄
                MoveExecute.NoticePgShooting(Global.WorkPos);

                //气缸下
                fRtn = MoveExecute.SetBaffle(false);

                //气缸移动不到位不处理
                if (!fRtn)
                {
                    Log.GetInstance().WarningWrite("由于暗室气缸下来失败，可能导致Demura结果不准确");
                }

                var tasks = new List<Task>();

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    this.DemuraCheck(SvrType.Left);
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    this.WriteFlash();
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    this.DemuraCheck(SvrType.Right);
                }));

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                return false;
            }

            this.isRotating = false;

            return true;
        }

        /// <summary>
        /// 自动DemuraCheck
        /// </summary>
        public void DemuraCheck(SvrType svrType)
        {
            try
            {
                string content = "Demura作业中";

                if (svrType == SvrType.Left)
                {
                    this.isDemuraCheck = true;
                    Log.GetInstance().NormalWrite(string.Format("开始Demura作业......"));
                    content = "Demura作业中";
                }
                else
                {
                    this.isDemuraReinspection = true;
                    Log.GetInstance().NormalWrite(string.Format("开始Demura作业复检......"));
                    content = "Demura复检中";
                }

                CmdResultCode cmdRes = CmdResultCode.Other;

                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    if (svrType != iixServer.SvrType) continue;

                    bool f = true;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        //DeMura（Mura补正拍摄・Flash 写入）开始
                        cmdRes = IIXExecute.DeMuraStart(iixServer, iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary);

                        Log.GetInstance().NormalWrite(string.Format("[{0}]等待补正原始图像的拍摄......", iixServer.Ip));
                        int waitTime = 0;
                        while (!iixServer.IsCaptureFinish)
                        {
                            waitTime++;
                            Thread.Sleep(1000);
                            if (waitTime == Global.IIXWaitTime)
                            {
                                Log.GetInstance().WarningWrite(string.Format("[{0}]等待补正原始图像的拍摄超时", iixServer.Ip));
                                cmdRes = CmdResultCode.TimeOut;

                                f = false;
                                break;
                            }
                        }

                        if (f)
                        {
                            Log.GetInstance().NormalWrite(string.Format("[{0}]补正原始图像的拍摄完成", iixServer.Ip));
                        }

                        if (cmdRes == CmdResultCode.Success && f)
                        {
                            //获取DeMura（Mura补正拍摄・Flash 写入）结果
                            cmdRes = IIXExecute.GetDeMuraResult(iixServer, iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary);

                            if (cmdRes == CmdResultCode.Success)
                            {
                                //DeMura Check（补正结果确认）开始
                                cmdRes = IIXExecute.DeMuraCheckStart(iixServer, iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary);

                                Log.GetInstance().NormalWrite(string.Format("[{0}]等待补正结果判定......", iixServer.Ip));

                                waitTime = 0;
                                while (!iixServer.IsCheckFinish)
                                {
                                    waitTime++;
                                    Thread.Sleep(1000);
                                    if (waitTime == Global.IIXWaitTime)
                                    {
                                        Log.GetInstance().WarningWrite(string.Format("[{0}]等待补正结果判定超时", iixServer.Ip));
                                        cmdRes = CmdResultCode.TimeOut;

                                        f = false;
                                        break;
                                    }
                                }

                                if (f)
                                {
                                    Log.GetInstance().NormalWrite(string.Format("[{0}]补正结果判定完成", iixServer.Ip));
                                }

                                if (cmdRes == CmdResultCode.Success && f)
                                {
                                    //获取DeMura Check（补正结果确认）结果
                                    cmdRes = IIXExecute.GetDeMuraCheckResult(iixServer, iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary);

                                    if (cmdRes == CmdResultCode.Success)
                                    {
                                        //Capture（获取拍摄数据）处理开始
                                        cmdRes = IIXExecute.CaptureStart(iixServer, iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary);

                                        if (cmdRes == CmdResultCode.Success)
                                        {
                                            //获取Capture（获取拍摄数据）处理结果
                                            cmdRes = IIXExecute.GetCaptureResult(iixServer, iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary);
                                        }
                                    }
                                }
                            }
                        }

                        if (cmdRes != CmdResultCode.Success || f == false)
                        {
                            Log.GetInstance().ErrorWrite(string.Format("屏幕[{0}]Demura作业失败，Error：{1}", iixServer.AssociatedPanelPos, cmdRes.ToString()));
                        }
                    }));
                }

                Task.WaitAll(tasks.ToArray());

                if (svrType == SvrType.Left)
                {
                    Log.GetInstance().NormalWrite(string.Format("Demura作业结束"));
                }
                else
                {
                    Log.GetInstance().NormalWrite(string.Format("Demura作业复检结束"));
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }

            if (svrType == SvrType.Left)
            {
                this.isDemuraCheck = false;
            }
            else
            {
                this.isDemuraReinspection = false;
            }
        }

        /// <summary>
        /// 点灯
        /// </summary>
        public void PanelOn(IIXServer iixServer = null)
        {
            try
            {
                //如果转盘有过旋转
                if (this.IsRotate)
                {
                    //点灯前需要删除最早的3块屏信息
                    #region Ted Modified 20180521

                    //this.DeleteDgvRow();
                    this.DeleteDgvRow(this.dgvPanel, 0,stationConfiguration.PanelCountOfStation);
                    
                    #endregion
                }

                this.IsRotate = false;

                Log.GetInstance().NormalWrite(string.Format("开始点灯......"));

                this.isPanelOn = true;
                CmdResultCode cmdRes = CmdResultCode.Other;

               //var tasks = new List<Task>();

                foreach (var _iixServer in Global.ListIIXSerevr)
                {
                    if (_iixServer.IsEnable == false) continue;
                    if (iixServer != null && iixServer != _iixServer) continue;

                    if (_iixServer.SvrType == SvrType.Right)
                    {
                        //tasks.Add(Task.Factory.StartNew(() =>
                        //{
                            //查询当前屏幕是否在集合中存在
                            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

                            //如果当前屏幕已经存在，
                            if (panel != null && panel.IsRotate == false)
                            {
                                //没有旋转，则表示人为的在当前工作位置作重复的操作
                                if (panel.IsRotate == false)
                                {
                                    //从dgv中倒序找到对应的屏幕信息并删除
                                    for (int i = this.dgvPanel.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (this.dgvPanel.Rows[i].Cells["Position"].Value.ToString() == _iixServer.AssociatedPanelPos)
                                        {
                                            this.dgvPanel.Rows.RemoveAt(i);
                                            break;
                                        }
                                    }
                                }
                                //有旋转，则表示复检完后没有关灯又点灯，误操作
                                else
                                {
                                    Log.GetInstance().WarningWrite(string.Format("[{0}]屏检测完成，请熄灯完成最后的操作"));
                                    return;
                                }
                            }

                            //VCR扫码
                            string code = "";
                            bool fRtn = MoveExecute.SweepCode(_iixServer, ref code);

                            if (fRtn)
                            {
                                //准备点灯
                                cmdRes = IIXExecute.SequenceStart(_iixServer, PgSelectCode.Primary);

                                if (cmdRes == CmdResultCode.Success)
                                {
                                    //点灯前先吸附屏幕
                                    bool f = MoveExecute.SetVacuum(_iixServer, true);

                                    if (f)
                                    {
                                        //点灯
                                        cmdRes = IIXExecute.PanelOn(_iixServer, PgSelectCode.Primary);

                                        if (cmdRes == CmdResultCode.Success)
                                        {
                                            //点灯后锁住屏幕
                                            MoveExecute.SetPanelLock(_iixServer, true);

                                            //Panel切换状态，从PG check 的处理等待状态进行DeMura处理的准备
                                            cmdRes = IIXExecute.TableRotation(_iixServer);
                                        }

                                        //显示上下料提示信息
                                        this.ShowCkeckImg(_iixServer, true);
                                    }
                                }
                            }

                            //添加到dgv
                            int index = this.dgvPanel.Rows.Add();
                            this.dgvPanel.Rows[index].Cells["Position"].Value = _iixServer.AssociatedPanelPos;
                            this.dgvPanel.Rows[index].Cells["Code"].Value = code;

                            if (cmdRes != CmdResultCode.Success || !fRtn)
                            {
                                this.dgvPanel.Rows[index].Cells["FailureReason"].Value = fRtn == false ? "Sweep code failure" : cmdRes.ToString();
                                this.dgvPanel.Rows[index].Cells["FailureReason"].Style.ForeColor = Color.Red;
                            }
                        //}));
                    }
                }

                //Task.WaitAll(tasks.ToArray());

                this.SetDgvPanelRowColor();

                Log.GetInstance().NormalWrite(string.Format("点灯结束"));
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }

            this.isPanelOn = false;
        }

        /// <summary>
        /// 关灯
        /// </summary>
        public void PanelOff(IIXServer iixServer = null)
        {
            try
            {
                Log.GetInstance().NormalWrite(string.Format("开始关灯......"));

                this.isPanelOff = true;
                CmdResultCode cmdRes = CmdResultCode.Other;

                var tasks = new List<Task>();

                foreach (var _iixServer in Global.ListIIXSerevr)
                {
                    if (_iixServer.IsEnable == false) continue;
                    if (iixServer != null && iixServer != _iixServer) continue;

                    if (_iixServer.SvrType == SvrType.Right)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            //关灯
                            cmdRes = IIXExecute.PanelOff(_iixServer, PgSelectCode.Primary);

                            //显示上下料提示信息
                            this.ShowCkeckImg(_iixServer, false);

                            //关灯后屏幕破真空
                            MoveExecute.SetVacuum(_iixServer, false);

                            //关灯后屏幕解锁
                            MoveExecute.SetPanelLock(_iixServer, false);

                            //查询当前屏幕是否在集合中存在
                            OLEDPanel panel = Global.ListOLEDPanel.Where(info => info.PanelPos == iixServer.AssociatedPanelPos).FirstOrDefault();

                            //如果当前屏幕已经存在
                            if (panel != null)
                            {
                                //没有旋转，则表示人为的在当前工作位置作重复的操作
                                if (panel.IsRotate == false)
                                {
                                    //从dgv中倒序找到对应的屏幕信息并删除
                                    for (int i = this.dgvPanel.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (this.dgvPanel.Rows[i].Cells["Position"].Value.ToString() == _iixServer.AssociatedPanelPos)
                                        {
                                            this.dgvPanel.Rows.RemoveAt(i);
                                            break;
                                        }
                                    }
                                }
                                //有旋转，则表示检测全部完成，修改dgv中相应信息
                                else
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        if (this.dgvPanel.Rows[i].Cells["Position"].Value.ToString() == _iixServer.AssociatedPanelPos)
                                        {
                                            this.dgvPanel.Rows[i].Cells["PanelOffResult"].Value = cmdRes.ToString();

                                            if (cmdRes != CmdResultCode.Success)
                                            {
                                                this.dgvPanel.Rows[i].Cells["FailureReason"].Value = cmdRes.ToString();
                                                this.dgvPanel.Rows[i].Cells["FailureReason"].Style.ForeColor = Color.Red;
                                            }

                                            break;
                                        }
                                    }
                                }
                            }
                        }));
                    }
                }

                Task.WaitAll(tasks.ToArray());

                Log.GetInstance().NormalWrite(string.Format("关灯结束"));
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }

            this.isPanelOff = false;
        }

        /// <summary>
        /// Flash写入
        /// </summary>
        public void WriteFlash()
        {
            try
            {
                this.isWriteFlash = true;
                Log.GetInstance().NormalWrite(string.Format("Flash写入开始......"));

                bool f = true;

                CmdResultCode cmdRes = CmdResultCode.Other;

                var tasks = new List<Task>();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false || iixServer.SvrType == SvrType.Right) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        cmdRes = IIXExecute.EraseFlashMemory(iixServer, iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary);

                        Log.GetInstance().NormalWrite(string.Format("[{0}]等待Flash擦除......", iixServer.Ip));

                        int waitTime = 0;
                        while (!iixServer.IsEraseFinish)
                        {
                            waitTime++;
                            Thread.Sleep(1000);
                            if (waitTime == Global.IIXWaitTime)
                            {
                                Log.GetInstance().WarningWrite(string.Format("[{0}]Flash擦除超时", iixServer.Ip));
                                cmdRes = CmdResultCode.TimeOut;

                                f = false;
                                break;
                            }
                        }

                        if (f)
                        {
                            Log.GetInstance().NormalWrite(string.Format("[{0}]Flash擦除完成", iixServer.Ip));
                        }

                        if (cmdRes == CmdResultCode.Success && f)
                        {
                            cmdRes = IIXExecute.GetFlashMemoryResult(iixServer, iixServer.SvrType == SvrType.Left ? PgSelectCode.Primary : PgSelectCode.Secondary);
                        }

                        Log.GetInstance().NormalWrite(string.Format("[{0}]等待Flash保存......", iixServer.Ip));

                        waitTime = 0;
                        while (!iixServer.IsSaveFinish)
                        {
                            waitTime++;
                            Thread.Sleep(1000);
                            if (waitTime == Global.IIXWaitTime)
                            {
                                Log.GetInstance().WarningWrite(string.Format("[{0}]Flash保存超时", iixServer.Ip));
                                cmdRes = CmdResultCode.TimeOut;

                                f = false;
                                break;
                            }
                        }

                        if (f)
                        {
                            Log.GetInstance().NormalWrite(string.Format("[{0}]Flash保存完成", iixServer.Ip));
                        }

                        Log.GetInstance().NormalWrite(string.Format("[{0}]等待Flash写入......", iixServer.Ip));

                        waitTime = 0;
                        while (!iixServer.IsWriteFinish)
                        {
                            waitTime++;
                            Thread.Sleep(1000);
                            if (waitTime == Global.IIXWaitTime)
                            {
                                Log.GetInstance().WarningWrite(string.Format("[{0}]Flash写入超时", iixServer.Ip));
                                cmdRes = CmdResultCode.TimeOut;

                                f = false;
                                break;
                            }
                        }

                        if (f)
                        {
                            Log.GetInstance().NormalWrite(string.Format("[{0}]Flash写入完成", iixServer.Ip));
                        }

                    }));
                }

                Task.WaitAll(tasks.ToArray());

                Log.GetInstance().NormalWrite(string.Format("Flash写入结束"));
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }

            this.isWriteFlash = false;
        }

        /// <summary>
        /// 判断是否可以工作
        /// </summary>
        /// <returns></returns>
        private bool IsWork()
        {
            bool f = false;

            if (Global.IsInit && this.isDemuraCheck == false && this.isPanelOn == false && this.isPanelOff == false && this.isDemuraReinspection == false && this.isWriteFlash == false && this.isRotating == false && Global.isContinue == false && Global.isReset == false)
            {
                f = true;
            }

            return f;
        }

        /// <summary>
        /// 启动定时器
        /// </summary>
        private void TimerStart()
        {
            this.timerAllPanelOn.Start();
            this.timerAllPanelOff.Start();
            this.timerPanelOnOrPanelOff.Start();
            this.timerRotate.Start();
        }

        /// <summary>
        /// 停止定时器
        /// </summary>
        private void TimerStop()
        {
            this.timerAllPanelOn.Stop();
            this.timerAllPanelOff.Stop();
            this.timerPanelOnOrPanelOff.Stop();
            this.timerRotate.Stop();
        }

        /// <summary>
        /// 遍历所有控件并给控件注册鼠标单击事件
        /// </summary>
        /// <param name="control"></param>
        public void CheckAllControl(Control control)
        {
            foreach (Control item in control.Controls)
            {
                item.MouseClick += Item_MouseClick;
                this.CheckAllControl(item);
            }
        }

        #endregion

        #region 事件


        public bool ss(bool f,int i)
        {
            Thread.Sleep(1000 * i);

            return f;
        }

        public void test()
        {
            #region Ted Modified 20180521

            //for (int i = 0; i < 12; i++)
            //{
            //    int index = this.dgvPanel.Rows.Add();

            //    this.dgvPanel.Rows[index].Cells[0].Value = "1";
            //    this.dgvPanel.Rows[index].Cells[1].Value = "123456";
            //    this.dgvPanel.Rows[index].Cells[2].Value = "成功";
            //    this.dgvPanel.Rows[index].Cells[3].Value = "成功";
            //    this.dgvPanel.Rows[index].Cells[4].Value = "成功";
            //    this.dgvPanel.Rows[index].Cells[5].Value = "成功";
            //    this.dgvPanel.Rows[index].Cells[6].Value = "成功";

            //}

            for (int i = 0; i < stationConfiguration.PanelCountOfStation * stationConfiguration.Stations.Length; i++)
            {

                int index = this.dgvPanel.Rows.Add();

                this.dgvPanel.Rows[index].Cells[0].Value = "1";
                this.dgvPanel.Rows[index].Cells[1].Value = "123456";
                this.dgvPanel.Rows[index].Cells[2].Value = "成功";
                this.dgvPanel.Rows[index].Cells[3].Value = "成功";
                this.dgvPanel.Rows[index].Cells[4].Value = "成功";
                this.dgvPanel.Rows[index].Cells[5].Value = "成功";
                this.dgvPanel.Rows[index].Cells[6].Value = "成功";

                #endregion
            }
                SetDgvPanelRowColor();
            
        }

        private void FormAutomaticCheck_Load(object sender, EventArgs e)
        {
            test();
            this.listCheckPrompt = new List<UserPromptInfo>();

            this.pbRotaryTable.Image = Image.FromFile(Application.StartupPath + "\\Image\\RotaryTable.png");
            this.gbCheckPrompt.Width = 147 * 3 + 24;
            
            #region Ted modified 20180522

            //for (int i = 1; i <= 3; i++)
            for (int i=1;i<=stationConfiguration.PanelCountOfStation;i++)
            {
                this.promptInfo = new UserPromptInfo("#" + i);
                this.promptInfo.SetPromptInfo(this.imgList.Images["No.png"], "不能上料");
                this.flpCheckPrompt.Controls.Add(this.promptInfo);
                this.listCheckPrompt.Add(this.promptInfo);
                this.promptInfo.Margin = new Padding(3, 20, 3, 3);
            }

            //this.gbCheckPrompt.Width = this.promptInfo.Width * 3 + 24;
            this.gbCheckPrompt.Width = (this.promptInfo.Width +8)* stationConfiguration.PanelCountOfStation;
            #endregion

            //初始化检查主界面是否初始化完成
            this.timerCheckInit = new System.Timers.Timer();
            this.timerCheckInit.Elapsed += TimerCheckInit_Elapsed;
            this.timerCheckInit.Interval = 1000;
            this.timerCheckInit.Start();

            //初始化检测所有屏点灯事件
            this.timerAllPanelOn = new System.Timers.Timer();
            this.timerAllPanelOn.Elapsed += TimerAllPanelOn_Elapsed;
            this.timerAllPanelOn.Interval = this.interval;

            //初始化检测所有屏关灯事件
            this.timerAllPanelOff = new System.Timers.Timer();
            this.timerAllPanelOff.Elapsed += TimerAllPanelOff_Elapsed;
            this.timerAllPanelOff.Interval = this.interval;

            //初始化检测单个屏点灯/关灯事件
            this.timerPanelOnOrPanelOff = new System.Timers.Timer();
            this.timerPanelOnOrPanelOff.Elapsed += TimerPanelOnOrPanelOff_Elapsed;
            this.timerPanelOnOrPanelOff.Interval = this.interval;

            //初始化检测转盘旋转事件
            this.timerRotate = new System.Timers.Timer();
            this.timerRotate.Elapsed += TimerRotate_Elapsed;
            this.timerRotate.Interval = this.interval;

            //初始化检测门禁传感器事件
            this.timeEntranceGuard = new System.Timers.Timer();
            this.timeEntranceGuard.Elapsed += TimeEntranceGuard_Elapsed;
            this.timeEntranceGuard.Interval = this.interval;

            //初始化检测安全光栅事件
            this.timeGrating = new System.Timers.Timer();
            this.timeGrating.Elapsed += TimeGrating_Elapsed;
            this.timeGrating.Interval = this.interval;

            //给所有控件注册鼠标单击事件
            foreach (Control item in this.Controls)
            {
                item.MouseClick += Item_MouseClick;
                this.CheckAllControl(item);
            }
        }

        /// <summary>
        /// 初始化检测安全光栅事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeGrating_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Global.IoCard.ReadInBit(2) == 1)
            {
                this.Stop();

                Global.ControlCard.AxisStop(null, AxisStopType.EmgStop, true);

                //报警提示
                Global.ControlCard.WriteOutbit(28, 1);
                //亮红灯
                Global.ControlCard.WriteOutbit(25, 1);

                Log.GetInstance().WarningWrite("需点击“继续Demura”后继续开始检测");

                Global.isContinue = true;
            }
        }

        /// <summary>
        /// 检测门禁传感器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeEntranceGuard_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Global.IoCard.ReadInBit(1) == 1)
            {
                this.Stop();

                Global.ControlCard.AxisStop(null, AxisStopType.EmgStop, true);

                //报警提示
                Global.ControlCard.WriteOutbit(28, 1);
                //亮红灯
                Global.ControlCard.WriteOutbit(25, 1);

                Log.GetInstance().WarningWrite("需点击“继续Demura”后继续开始检测");

                Global.isContinue = true;
            }
        }

        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            ((Control)sender).Focus();
        }

        /// <summary>
        /// 检测转盘旋转事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerRotate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.IsWork())
            {
                if (this.isAllPanelOnEvent && this.isAllPanelOffEvent)
                {
                    this.isAllPanelOnEvent = false;
                    this.isAllPanelOffEvent = false;
                    this.Rotating();
                    Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// 检测单个屏点灯/关灯事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerPanelOnOrPanelOff_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.IsWork())
            {
                IIXServer iixServer = null;
                string associatedPanelPos = "";

                //按钮1
                if (Global.IoCard.ReadInBit(5) == 1)
                {
                    //按钮灯亮
                    Global.ControlCard.WriteOutbit(31, 1);

                    associatedPanelPos = "#1";
                }
                //按钮2
                else if (Global.IoCard.ReadInBit(6) == 1)
                {
                    Global.ControlCard.WriteOutbit(32, 1);

                    associatedPanelPos = "#2";
                }
                //按钮3
                else if (Global.IoCard.ReadInBit(7) == 1)
                {
                    Global.ControlCard.WriteOutbit(59, 1);

                    associatedPanelPos = "#3";
                }

                iixServer = Global.ListIIXSerevr.Where(info => info.SvrType == SvrType.Right && info.AssociatedPanelPos == associatedPanelPos).FirstOrDefault();

                if (iixServer != null)
                {
                    //如果已经点灯，则关灯
                    if (iixServer.IsPanelOn)
                    {
                        this.PanelOff(iixServer);
                    }
                    else
                    {
                        this.PanelOn(iixServer);
                    }

                    Thread.Sleep(500);
                }

                if (associatedPanelPos == "#1")
                {
                    //按钮灯灭
                    Global.ControlCard.WriteOutbit(31, 0);
                }
                else if (associatedPanelPos == "#2")
                {
                    Global.ControlCard.WriteOutbit(32, 0);
                }
                else if (associatedPanelPos == "#3")
                {
                    Global.ControlCard.WriteOutbit(59, 0);
                }
            }
        }

        /// <summary>
        /// 检测所有屏关灯事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerAllPanelOff_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.IsWork())
            {
                //启动按钮2
                if (Global.IoCard.ReadInBit(4) == 1) //侦测IO口，启动按键2是否按下
                {
                    //启动按钮灯亮
                    Global.ControlCard.WriteOutbit(30, 0);

                    this.isAllPanelOffEvent = true;

                    //休眠一秒，看点灯按钮是否触发
                    Thread.Sleep(1000);

                    if (this.isAllPanelOnEvent == false)
                    {
                        this.PanelOff();
                        this.isAllPanelOffEvent = false;

                        Thread.Sleep(500);
                    }
                }
            }
        }

        /// <summary>
        /// 检测所有屏点灯事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerAllPanelOn_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.IsWork())
            {
                //启动按钮1
                if (Global.IoCard.ReadInBit(3) == 1)
                {
                    //启动按钮灯亮
                    Global.ControlCard.WriteOutbit(29, 0);

                    this.isAllPanelOnEvent = true;    //此值为true表明这个键被按下

                    //休眠一秒，看关灯按钮是否触发
                    Thread.Sleep(1000);

                    if (this.isAllPanelOffEvent == false)  //表明熄灯按键没有按下
                    {
                        this.PanelOn();                    //点屏
                        this.isAllPanelOnEvent = false;

                        Thread.Sleep(500);
                    }
                }
            }
        }

        /// <summary>
        /// 检查主界面是否初始化完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerCheckInit_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //初始化完成
            if (Global.IsInit)
            {
                this.timerCheckInit.Stop();

                Global.isReset = true;
                //所有轴到指定工作位置
                this.btnReset_Click(null, null);
                Global.isReset = false;

                this.TimerStart();

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    Image img;

                    if (iixServer.IsEnable && iixServer.SvrType == SvrType.Left)
                    {
                        img = this.imgList.Images["Yes.png"];

                        UserPromptInfo promptInfo = this.listCheckPrompt.Where(info => info.PanelNumber == iixServer.AssociatedPanelPos).FirstOrDefault();
                    }
                }
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string logFilePath = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\ExceptionLog.txt";

            try
            {
                if (!File.Exists(logFilePath))
                {
                    FileStream fs = new FileStream(logFilePath, FileMode.Append, FileAccess.Write);
                    fs.Close();
                }

                System.Diagnostics.Process.Start(logFilePath);
            }
            catch
            {
                MessageBox.Show("请检查路径 （" + logFilePath + ") 是否存在！");
            }
        }

        /// <summary>
        /// 连续检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinuousCheck_Click(object sender, EventArgs e)
        {
            if (!this.IsRotaryTableWorkPos())
            {
                //return;
            }

            if (this.btnContinuousCheck.Text == "开始检查")
            {
                if (!File.Exists(Global.ProductSettingPath))
                {
                    MessageBox.Show(string.Format("当前项目没有配置文件，路径：{0}", Global.ProductSettingPath));
                    return;
                }

                this.patternNumber = 1;

                //初始化连续检查线程
                this.thCheckColor = new Thread(this.ContinuousCheckColor);
                this.thCheckColor.IsBackground = true;
                this.thCheckColor.Start();
                this.threadLoop = true;
                this.btnContinuousCheck.Text = "停止检查";

                this.btnSingleCheck.Enabled = false;
                this.btnOnColor.Enabled = false;
                this.btnNextColor.Enabled = false;
            }
            else
            {
                this.btnContinuousCheck.Text = "开始检查";
                this.threadLoop = false;

                this.btnSingleCheck.Enabled = true;
                this.btnOnColor.Enabled = false;
                this.btnNextColor.Enabled = false;

                this.thCheckColor.Abort();
            }
        }

        /// <summary>
        /// 单张检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSingleCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsRotaryTableWorkPos())
                {
                    //return;
                }

                if (!File.Exists(Global.ProductSettingPath))
                {
                    MessageBox.Show(string.Format("当前项目没有配置文件，路径：{0}", Global.ProductSettingPath));
                    return;
                }

                //判断Pattern是否启用
                if (IniFile.IniReadValue("Pattern" + this.patternNumber, "Enabled", Global.ProductSettingPath) == "1")
                {
                    int R = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "R", Global.ProductSettingPath));
                    int G = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "G", Global.ProductSettingPath));
                    int B = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "B", Global.ProductSettingPath));
                    int sleepTime = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "SleepTime", Global.ProductSettingPath));

                    Color color = Color.FromArgb(R, G, B);

                    this.pnlColor.BackColor = color;
                    this.gbPattern.Text = "Pattern" + this.patternNumber;

                    this.btnSingleCheck.Enabled = false;
                    this.btnOnColor.Enabled = true;
                    this.btnNextColor.Enabled = true;
                }
                else
                {
                    Log.GetInstance().NormalWrite("没有设置Pattern，请去“系统设置中”设置");
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 上一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsRotaryTableWorkPos())
                {
                    //return;
                }

                if (this.patternNumber == 1)
                {
                    Log.GetInstance().NormalWrite("已经是第一个Pattern了");
                    return;
                }

                this.patternNumber--;

                //判断Pattern是否启用
                if (IniFile.IniReadValue("Pattern" + this.patternNumber, "Enabled", Global.ProductSettingPath) == "1")
                {
                    int R = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "R", Global.ProductSettingPath));
                    int G = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "G", Global.ProductSettingPath));
                    int B = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "B", Global.ProductSettingPath));
                    int sleepTime = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "SleepTime", Global.ProductSettingPath));

                    Color color = Color.FromArgb(R, G, B);


                    //Add 2018/5/21 Set the raster color
                    var tasks = new List<Task>();

                    foreach (var iixServer in Global.ListIIXSerevr)
                    {
                        if (iixServer.IsEnable == false) continue;

                        if (iixServer.SvrType == SvrType.Right)
                        {
                            tasks.Add(Task.Factory.StartNew(() =>
                            {
                                IIXExecute.SetRasterImage(iixServer, PgSelectCode.Primary, color, false);
                            }));
                        }
                    }

                    Task.WaitAll(tasks.ToArray());
                    //Add 2018/5/21


                    this.pnlColor.BackColor = color;
                    this.gbPattern.Text = "Pattern" + this.patternNumber;

                    this.btnSingleCheck.Enabled = false;
                    this.btnOnColor.Enabled = true;
                    this.btnNextColor.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsRotaryTableWorkPos())
                {
                    //return;
                }

                if (this.patternNumber == Global.PatternNumber)
                {
                    Log.GetInstance().NormalWrite("已经是最后一个Pattern了");
                    return;
                }

                this.patternNumber++;

                //判断Pattern是否启用
                if (IniFile.IniReadValue("Pattern" + this.patternNumber, "Enabled", Global.ProductSettingPath) == "1")
                {
                    int R = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "R", Global.ProductSettingPath));
                    int G = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "G", Global.ProductSettingPath));
                    int B = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "B", Global.ProductSettingPath));
                    int sleepTime = Convert.ToInt32(IniFile.IniReadValue("Pattern" + this.patternNumber, "SleepTime", Global.ProductSettingPath));

                    Color color = Color.FromArgb(R, G, B);


                    //Add 2018/5/21 Set the raster color
                    var tasks = new List<Task>();

                    foreach (var iixServer in Global.ListIIXSerevr)
                    {
                        if (iixServer.IsEnable == false) continue;

                        if (iixServer.SvrType == SvrType.Right)
                        {
                            tasks.Add(Task.Factory.StartNew(() =>
                            {
                                IIXExecute.SetRasterImage(iixServer, PgSelectCode.Primary, color, false);
                            }));
                        }
                    }

                    Task.WaitAll(tasks.ToArray());
                    //Add 2018/5/21


                    this.pnlColor.BackColor = color;
                    this.gbPattern.Text = "Pattern" + this.patternNumber;

                    this.btnSingleCheck.Enabled = false;
                    this.btnOnColor.Enabled = true;
                    this.btnNextColor.Enabled = true;
                }
                else
                {
                    Log.GetInstance().NormalWrite("已经是最后一个Pattern了");
                    this.patternNumber--;
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 开始Demura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "开始Demura")
            {
                btnStart.Text = "结束Demura";
                this.Start();
            }
            else
            {
                if (MessageBox.Show("确定结束Demura吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    btnStart.Text = "开始Demura";
                    this.Stop();
                }
            }
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                MoveExecute.SetAxisLock(true);

                if (Global.isReset == false)
                {
                    Log.GetInstance().WarningWrite("当前设备正常运行，无需复位");
                    return;
                }

                var f = MoveExecute.AllAxisReset();

                if (f)
                {
                    foreach (var iixServer in Global.ListIIXSerevr)
                    {
                        if (iixServer.IsEnable == false) continue;

                        if (iixServer.SvrType == SvrType.Right)
                        {
                            //显示上下料提示信息
                            this.ShowCkeckImg(iixServer, false);
                        }
                    }

                    this.Start();
                    this.btnStart.Text = "结束Demura";
                }
                else
                {
                    this.Stop();
                    this.btnStart.Text = "开始Demura";
                }

                this.pbRotaryTable.Image = Image.FromFile(Application.StartupPath + "\\Image\\RotaryTable.png");
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 继续Demura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.isContinue == false)
                {
                    Log.GetInstance().WarningWrite("当前设备正常运行，无需继续");
                    return;
                }


                if (this.Rotating())
                {
                    Global.isContinue = false;
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 重写键盘按下事件，铺获方向键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                //向上
                case Keys.Up:
                    this.btnContinuousCheck_Click(null, null);
                    break;
                //向下
                case Keys.Down:
                    this.btnSingleCheck_Click(null, null);
                    break;
                //向右
                case Keys.Right:
                    this.btnNextColor_Click(null, null);
                    break;
                //向左
                case Keys.Left:
                    this.btnOnColor_Click(null, null);
                    break;
                default:
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion
    }
}
