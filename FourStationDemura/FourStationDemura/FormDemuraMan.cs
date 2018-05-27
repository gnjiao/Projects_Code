using IIXDeMuraApi;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    public partial class FormDemuraMan : Form
    {
        #region 属性

        /// <summary>
        /// socket服务类
        /// </summary>
        private SocketServer socketServer = null;

        /// <summary>
        /// 系统设置窗体
        /// </summary>
        private FormConfig formConfig = null;

        /// <summary>
        /// 自动检测窗体
        /// </summary>
        private FormAutomaticCheck formAutomaticCheck = null;

        /// <summary>
        /// 手动检测窗体
        /// </summary>
        private FormManualCheck formManualCheck = null;

        /// <summary>
        /// 检测紧急停止按钮
        /// </summary>
        private System.Timers.Timer timerEmgStop = null;

        #endregion

        #region 构造函数

        public FormDemuraMan()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法


        /// <summary>
        /// 加载当前项目信息
        /// </summary>
        private bool LoadProduct()
        {
            try
            {
                if (MoveExecute.LoadSettings(Global.ProductName))
                {
                    Log.GetInstance().NormalWrite("加载项目配置文件配置成功。");
                }
                else
                {
                    Log.GetInstance().ErrorWrite("加载项目配置文件配置失败。");

                    return false;
                }

                var currentProductPath = Path.Combine(Application.StartupPath + "\\Product", Global.ProductName);
                var fileName = Global.IsExistFileBySuffixName(currentProductPath, ".bin");

                if (fileName == "")
                {
                    Log.GetInstance().ErrorWrite(string.Format("目录 '{0}' 下没有找到该项目的bin文件,切换项目失败。", currentProductPath));
                    return false;
                }

                ///
                ///设置Recipe
                ///
                var tasks = new List<Task>();
                CmdResultCode cmdRes;
                bool f = false;

                foreach (var iixServer in Global.ListIIXSerevr)
                {
                    if (iixServer.IsEnable == false) continue;

                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        cmdRes = IIXExecute.SetRecipe(iixServer, Path.Combine(currentProductPath, fileName));

                        if (cmdRes != CmdResultCode.Success)
                        {
                            f = false;
                        }
                    }));
                }

                Task.WaitAll(tasks.ToArray());

                if (!f)
                {
                    Log.GetInstance().ErrorWrite(string.Format("设置Recipe失败,请重启软件。"));
                    return false;
                }

                //修改配置文件中当前项目名
                IniFile.IniWriteValue("Product", "ProductName", Global.ProductName, Global.ConfigPath);

                //修改主界面项目名

                return true;
            }
            catch (Exception ex)
            {
                Log.GetInstance().ErrorWrite("系统错误，请查询日志文件检查。");
                Log.WriterExceptionLog(ex.ToString());
                return false;
            }
        }


        /// <summary>
        /// 初始化运动卡
        /// </summary>
        private bool InitControlCard()
        {
            bool f = false;

            try
            {
                Global.ControlCard = new DMC2C80Card();
                Global.ControlCard.CardNo = 0;

                //初始化控制卡
                f = Global.ControlCard.InitCard(true);

                if (!f)
                {
                    //return f;
                }
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            return f;
        }

        /// <summary>
        /// 初始化IO卡
        /// </summary>
        private bool InitIoCard()
        {
            bool f = false;
            try
            {
                Global.IoCard = new IOC0640Card();
                Global.IoCard.CardNo = 0;

                f = Global.IoCard.BoardInit(true);
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            return f;
        }


        StationConfiguration stationConfig = Global.stationConfiguration;
        /// <summary>
        /// 初始化IIX服务端
        /// </summary>
        /// <returns></returns>
        private bool InitIIXServer()
        {
            bool f = false;
            try
            {
                IIXServer iixServer = null;
                CmdResultCode cmdRes = CmdResultCode.Other;

                #region Ted modified 20180522
                foreach (SlaveGroup slaveGroup in stationConfig.SlaveGroups)
                {
                    foreach (Slave slave in slaveGroup.Slaves)
                    {
                        int index = this.dgvServer.Rows.Add();
                        iixServer = new IIXServer();

                        iixServer.DmrSvrApi = new IixDmrSvrApi();
                        iixServer.Ip = slave.ip;
                        iixServer.IsEnable = slave.enable;
                        iixServer.AssociatedPanelPos = slave.description;
                        //iixServer.SvrType = SvrType.Left;

                        this.SetEventHandlers(iixServer);

                        DataGridViewRow row = this.dgvServer.Rows[index];
                        row.Cells["Enable"].Value = slave.enable;
                        row.Cells["ServerIP"].Value = slave.ip;
                        row.Cells["ServerPort"].Value = iixServer.Port;
                        row.Cells["Open"].Value = iixServer.ConnState.ToString();
                        row.Cells["PgPrimary"].Value = iixServer.OutlineState[0].ToString();
                        row.Cells["PgSecondary"].Value = iixServer.OutlineState[1].ToString(); ;
                        row.Cells["Status"].Value = iixServer.ResultState.ToString();
                        row.Cells["LatestResult"].Value = iixServer.LatestResult;

                        Global.ListIIXSerevr.Add(iixServer);
                    }
                }

                //for (int i = 1; i <= 3; i++)
                //{
                //    int index = this.dgvServer.Rows.Add();

                //    iixServer = new IIXServer();

                //    string ip = IniFile.IniReadValue(string.Format("ServerLeft#" + i), "IP", Global.ConfigPath);
                //    bool isEnable = IniFile.IniReadValue(string.Format("ServerLeft#" + i), "IsEnable", Global.ConfigPath) == "1" ? true : false;

                //    iixServer.DmrSvrApi = new IixDmrSvrApi();
                //    iixServer.Ip = ip;
                //    iixServer.IsEnable = isEnable;
                //    iixServer.AssociatedPanelPos = "#" + i;
                //    iixServer.SvrType = SvrType.Left;

                //    this.SetEventHandlers(iixServer);

                //    this.dgvServer.Rows[index].Cells["Enable"].Value = isEnable;
                //    this.dgvServer.Rows[index].Cells["ServerIP"].Value = ip;
                //    this.dgvServer.Rows[index].Cells["ServerPort"].Value = iixServer.Port;
                //    this.dgvServer.Rows[index].Cells["Open"].Value = iixServer.ConnState.ToString();
                //    this.dgvServer.Rows[index].Cells["PgPrimary"].Value = iixServer.OutlineState[0].ToString();
                //    this.dgvServer.Rows[index].Cells["PgSecondary"].Value = iixServer.OutlineState[1].ToString(); ;
                //    this.dgvServer.Rows[index].Cells["Status"].Value = iixServer.ResultState.ToString();
                //    this.dgvServer.Rows[index].Cells["LatestResult"].Value = iixServer.LatestResult;

                //    Global.ListIIXSerevr.Add(iixServer);
                //}

                //for (int i = 1; i <= 3; i++)
                //{
                //    int index = this.dgvServer.Rows.Add();

                //    iixServer = new IIXServer();

                //    string ip = IniFile.IniReadValue(string.Format("ServerRight#" + i), "IP", Global.ConfigPath);
                //    bool isEnable = IniFile.IniReadValue(string.Format("ServerRight#" + i), "IsEnable", Global.ConfigPath) == "1" ? true : false;

                //    iixServer.DmrSvrApi = new IixDmrSvrApi();
                //    iixServer.Ip = ip;
                //    iixServer.IsEnable = isEnable;
                //    iixServer.AssociatedPanelPos = "#" + i;
                //    iixServer.SvrType = SvrType.Right;

                //    this.SetEventHandlers(iixServer);

                //    this.dgvServer.Rows[index].Cells["Enable"].Value = isEnable;
                //    this.dgvServer.Rows[index].Cells["ServerIP"].Value = ip;
                //    this.dgvServer.Rows[index].Cells["ServerPort"].Value = iixServer.Port;
                //    this.dgvServer.Rows[index].Cells["Open"].Value = iixServer.ConnState.ToString();
                //    this.dgvServer.Rows[index].Cells["PgPrimary"].Value = iixServer.OutlineState[0].ToString();
                //    this.dgvServer.Rows[index].Cells["PgSecondary"].Value = iixServer.OutlineState[1].ToString(); ;
                //    this.dgvServer.Rows[index].Cells["Status"].Value = iixServer.ResultState.ToString();
                //    this.dgvServer.Rows[index].Cells["LatestResult"].Value = iixServer.LatestResult;
                //    Global.ListIIXSerevr.Add(iixServer);
                //}

                #endregion

                var tasks = new List<Task>();

                foreach (var _iixServer in Global.ListIIXSerevr)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        //连接
                        cmdRes = IIXExecute.ConnectToSlave(_iixServer);

                        //连接成功后就打开
                        if (cmdRes == CmdResultCode.Success)
                        {
                            Log.WriterActionLog(string.Format("Slave {0}:{1} connected SUCCESS!", _iixServer.Ip, _iixServer.Port));
                            cmdRes = IIXExecute.Open(_iixServer);
                            if (cmdRes == CmdResultCode.Success)
                            {
                                Log.WriterActionLog(string.Format("Slave {0}:{1} open SUCCESS!", _iixServer.Ip, _iixServer.Port));
                            }
                            else
                            {
                                Log.WriterExceptionLog(string.Format("Slave {0}:{1} open FAIL!", _iixServer.Ip, _iixServer.Port));
                            }
                        }
                        else
                        {
                            Log.WriterExceptionLog(string.Format("Slave {0}:{1} connected FAIL!", _iixServer.Ip, _iixServer.Port));
                        }
                    }));
                }

                Task.WaitAll(tasks.ToArray());

                f = true;
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            return f;
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="api"></param>
        private void SetEventHandlers(IIXServer iixServer)
        {
            //SlavePC 管理 Device 初始化完了的报告 
            iixServer.DmrSvrApi.OpenFinished += api_OpenFinished;
            //DeMura 拍摄完了的报告 
            iixServer.DmrSvrApi.CaptureFinished += api_CaptureFinished;
            //Flash保存报告
            iixServer.DmrSvrApi.SaveFinished += api_SaveFinished;
            //Flash 写入完成报告
            iixServer.DmrSvrApi.WriteFinished += api_WriteFinished;
            //补正结果确认处理完了的报告 
            iixServer.DmrSvrApi.CheckFinished += api_CheckFinished;
            //Focus 自动调整完了報告 
            iixServer.DmrSvrApi.FocusFinished += api_FocusFinished;
            //报告Device的检测异常 
            iixServer.DmrSvrApi.AbnormalDetected += api_AbnormalDetected;
            //Flash 擦除完成报告
            iixServer.DmrSvrApi.EraseFinished += api_EraseFinished;
        }

        /// <summary>
        /// 根据权限显示菜单按钮
        /// </summary>
        private void AccessControl()
        {
            try
            {
                if (Global.WorkNumber == "admin")
                {
                    this.tsmAutomaticCheck.Visible = true;
                    this.tsmManualCheck.Visible = true;
                    this.tsmConfig.Visible = true;

                    this.tsmAutomaticCheck_Click(this.tsmAutomaticCheck, null);
                }
                else
                {
                    DataRow[] dr = null;
                    dr = Global.DtUser.Select(string.Format("id ='{0}'", Global.UserID));

                    if (dr.Length > 0)
                    {
                        string[] permissions = dr[0]["permissions"].ToString().Split(',');

                        IList listPermission = (IList)permissions;

                        bool isOpen = false;

                        if (listPermission.Contains("自动检测"))
                        {
                            if (isOpen == false)
                            {
                                this.tsmAutomaticCheck_Click(this.tsmAutomaticCheck, null);
                                isOpen = true;
                            }

                            this.tsmAutomaticCheck.Visible = true;
                        }
                        else
                        {
                            this.tsmAutomaticCheck.Visible = false;
                        }

                        if (listPermission.Contains("手动检测"))
                        {
                            if (isOpen == false)
                            {
                                this.tsmManualCheck_Click(this.tsmManualCheck, null);
                                isOpen = true;
                            }

                            this.tsmManualCheck.Visible = true;
                        }
                        else
                        {
                            this.tsmManualCheck.Visible = false;
                        }

                        if (listPermission.Contains("系统设置"))
                        {
                            if (isOpen == false)
                            {
                                this.tsmConfig_Click(this.tsmConfig, null);
                                isOpen = true;
                            }

                            this.tsmConfig.Visible = true;
                        }
                        else
                        {
                            this.tsmConfig.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }


        #endregion

        #region 事件

        /// <summary>
        /// 删除30天前的日志
        /// </summary>
        public void DeleteLog()
        {
            try
            {
                var logPath = Application.StartupPath + "\\Log";

                DirectoryInfo dirInfo = new DirectoryInfo(logPath);

                foreach (var folder in dirInfo.GetDirectories())
                {
                    try
                    {
                        var date = Convert.ToDateTime(folder.Name);

                        if (DateTime.Now.AddDays(-30) > date)
                        {
                            folder.Delete(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        folder.Delete(true);
                    }  
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// Flash擦除完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void api_EraseFinished(object sender, FinishedSequenceEventArgs e)
        {
            IIXServer iixServer = (IIXServer)sender;
            iixServer.IsEraseFinish = true;

            Log.GetInstance().NormalWrite(string.Format("[{0}]Flash擦除完成", iixServer.Ip));
        }

        /// <summary>
        /// Device的检测异常完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void api_AbnormalDetected(object sender, AbnormalDetectedEventArgs e)
        {
            IIXServer iixServer = (IIXServer)sender;
            iixServer.IsAbnormalDetect = true;

            Log.GetInstance().NormalWrite(string.Format("[{0}]Device的检测异常完成", iixServer.Ip));
        }

        /// <summary>
        /// Focus自动调整完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void api_FocusFinished(object sender, FinishedSequenceEventArgs e)
        {
            IIXServer iixServer = (IIXServer)sender;
            iixServer.IsFocusFinish = true;

            Log.GetInstance().NormalWrite(string.Format("[{0}]Focus自动调整完成", iixServer.Ip));
        }

        /// <summary>
        /// 补正结果确认完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void api_CheckFinished(object sender, FinishedSequenceEventArgs e)
        {
            IIXServer iixServer = (IIXServer)sender;
            iixServer.IsCheckFinish = true;

            Log.GetInstance().NormalWrite(string.Format("[{0}]补正结果确认完成", iixServer.Ip));
        }

        /// <summary>
        /// Flash写入完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void api_WriteFinished(object sender, FinishedSequenceEventArgs e)
        {
            IIXServer iixServer = (IIXServer)sender;
            iixServer.IsWriteFinish = true;

            Log.GetInstance().NormalWrite(string.Format("[{0}]Flash写入完成", iixServer.Ip));
        }

        /// <summary>
        /// Flash保存完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void api_SaveFinished(object sender, SaveFinishedEventArgs e)
        {
            IIXServer iixServer = (IIXServer)sender;
            iixServer.IsSaveFinish = true;

            Log.GetInstance().NormalWrite(string.Format("[{0}]Flash保存完成", iixServer.Ip));
        }

        /// <summary>
        /// DeMura拍摄完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void api_CaptureFinished(object sender, FinishedSequenceEventArgs e)
        {
            IIXServer iixServer = (IIXServer)sender;
            iixServer.IsCaptureFinish = true;

            Log.GetInstance().NormalWrite(string.Format("[{0}]DeMura拍摄完成", iixServer.Ip));
        }

        /// <summary>
        /// 打开服务端完成报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void api_OpenFinished(object sender, EventArgs e)
        {
            IIXServer iixServer = (IIXServer)sender;
            iixServer.IsOpenFinish = true;

            Log.GetInstance().NormalWrite(string.Format("打开[{0}]服务端完成", iixServer.Ip));
        }

        private void FormDemuraMan_Load(object sender, EventArgs e)
        {
            try
            {
                //1.清除log
                this.DeleteLog();

                //2.页面控件样式初始化
                DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                dataGridViewCellStyle1.Font = new Font("宋体", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCellStyle1.BackColor = SystemColors.Window;
                dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
                dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
                dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
                dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;

                DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
                dataGridViewCellStyle2.Font = new Font("宋体", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCellStyle2.BackColor = SystemColors.Window;
                dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
                dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
                dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
                dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;

                this.dgvServer.DefaultCellStyle = dataGridViewCellStyle1;
                this.dgvServer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;

                Global.DgvServer = this.dgvServer;
                Global.RtbFailNumber = this.rtbFailNumber;
                Global.RtbPassNumber = this.rtbPassNumber;

                Global.ConfigPath = Application.StartupPath + "\\config.ini";
                Log.CreateLogInstance(this.rtbLog, 10000);

                //3.配置Socket服务器
                var ip = IniFile.IniReadValue("SocketServer", "IP", Global.ConfigPath);
                var port = Convert.ToInt32(IniFile.IniReadValue("SocketServer", "Port", Global.ConfigPath));
                this.socketServer = new SocketServer(ip, port);
                this.socketServer.Start();
                Global.SocketServer = this.socketServer;

                IniFile.ReadSection("Axis", Global.ConfigPath, Global.DictAxis);
                IniFile.ReadSection("Dept", Global.ConfigPath, Global.DictDept);

                //4.初始化控制卡
                Global.ControlCard = ControlCardFactory.GetIntance(ControlCardType.DMC2C80);
                Global.PatternNumber = Convert.ToInt32(IniFile.IniReadValue("Pattern", "PatternNumber", Global.ConfigPath));

                Global.ProductName = IniFile.IniReadValue("Product", "ProductName", Global.ConfigPath);
                Global.ProductSettingPath = Application.StartupPath + "\\Product\\" + Global.ProductName + "\\Setting.ini";

                Global.CardWaitTime = Convert.ToInt32(IniFile.IniReadValue("WaitTime", "CardWaitTime", Global.ConfigPath));
                Global.IIXWaitTime = Convert.ToInt32(IniFile.IniReadValue("WaitTime", "IIXWaitTime", Global.ConfigPath));
                Global.WriterActionLog = Convert.ToInt32(IniFile.IniReadValue("WriterLog", "ActionLog", Global.ConfigPath)) == 1 ? true : false;

                //5.根据权限显示菜单按钮
                this.AccessControl();

                if (!File.Exists(Global.ProductSettingPath))
                {
                    Log.GetInstance().ErrorWrite(string.Format("项目：'{0}'没有配置文件,路径：'{1}'", Global.ProductName, Global.ProductSettingPath));

                    return;
                }

                //6.初始化运动卡
                if (this.InitControlCard() == false)
                {
                    //return;
                }

                //7.初始化IO卡
                if (this.InitIoCard() == false)
                {
                    //return;
                }

                //8.初始化IIX服务器
                if (this.InitIIXServer() == false)
                {
                    //return;
                }

                //9.根据选择的屏幕尺寸加载对应的设置
                if (this.LoadProduct() == false)
                {
                    //return;
                }

                this.gbProduct.Text = "项目：" + Global.ProductName;
                Global.SwitchProductEvent += Global_SwitchProductEvent;
                Global.IsInit = true;

                //10.Timer，用于侦测急停按钮按下
                this.timerEmgStop = new System.Timers.Timer();
                this.timerEmgStop.Interval = 100;
                this.timerEmgStop.Elapsed += TimerEmgStop_Elapsed;
                this.timerEmgStop.Start();
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                this.rtbLog.AppendText("系统初始化错误，请查看Log日志");
            }
        }

        /// <summary>
        /// 切换项目事件
        /// </summary>
        private void Global_SwitchProductEvent()
        {
            this.gbProduct.Text = "项目：" + Global.ProductName;
        }

        /// <summary>
        /// 检测是否触发了急停按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerEmgStop_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Global.ControlCard.ReadInbit(68) == 1)
            {
                Global.ControlCard.AxisStop(null, AxisStopType.EmgStop, true);
                //亮红灯
                Global.ControlCard.WriteOutbit((ushort)Global.GetIOPortNoByName("红灯"), 1);
                //报警提示
                Global.ControlCard.WriteOutbit((ushort)Global.GetIOPortNoByName("报警"), 1);

                Log.GetInstance().WarningWrite("需点击“复位”后重新开始检测");

                Global.isReset = true;

                if (this.formAutomaticCheck != null)
                {
                    this.formAutomaticCheck.Stop();
                }
            }
        }

        private void tsmConfig_Click(object sender, EventArgs e)
        {
            if (this.formConfig == null)
            {
                this.formConfig = new FormConfig();
                this.formConfig.MdiParent = this;
                this.formConfig.WindowState = FormWindowState.Maximized;
                this.formConfig.Show();
            }
            else
            {
                this.formConfig.Show();
                this.formConfig.BringToFront();
                this.formConfig.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// 切换模式
        /// </summary>
        public bool SwitchingMode(bool IsDeBugMode)
        {
            try
            {
                //停止所有轴
                int iRtn = Global.ControlCard.AxisStop(null, AxisStopType.EmgStop, true);
                //if (iRtn != 0) return false;

                //设置模式
                Global.IsDeBugMode = IsDeBugMode;

                Global.WorkPos = 1;
                Global.ListOLEDPanel.Clear();
                Global.isReset = false;
                Global.isContinue = false;

                return true;
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                return false;
            }
        }

        private void tsmAutomaticCheck_Click(object sender, EventArgs e)
        {
            //如果手动模式打开
            if (this.formManualCheck != null && Global.IsDeBugMode)
            {
                if (MessageBox.Show("确定要切换到自动模式吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.formAutomaticCheck.Start();

                    if (!this.SwitchingMode(false)) return;

                    if (this.formAutomaticCheck == null)
                    {
                        this.formAutomaticCheck = new FormAutomaticCheck();
                        this.formAutomaticCheck.MdiParent = this;
                        this.formAutomaticCheck.WindowState = FormWindowState.Maximized;
                        this.formAutomaticCheck.Show();
                    }
                    else
                    {
                        this.formAutomaticCheck.Show();
                        this.formAutomaticCheck.BringToFront();
                        this.formAutomaticCheck.WindowState = FormWindowState.Maximized;
                    }
                }
            }
            else
            {
                if (this.formAutomaticCheck == null)
                {
                    this.formAutomaticCheck = new FormAutomaticCheck();
                }

                this.formAutomaticCheck.MdiParent = this;
                this.formAutomaticCheck.WindowState = FormWindowState.Maximized;
                this.formAutomaticCheck.Show();
                this.formAutomaticCheck.BringToFront();
            }
        }

        private void tsmManualCheck_Click(object sender, EventArgs e)
        {
            //如果自动模式打开
            if (this.formAutomaticCheck != null && !Global.IsDeBugMode)
            {
                if (MessageBox.Show("确定要切换到手动模式吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.formAutomaticCheck.Stop();

                    if (!this.SwitchingMode(true)) return;

                    if (this.formManualCheck == null)
                    {
                        this.formManualCheck = new FormManualCheck();
                        this.formManualCheck.MdiParent = this;
                        this.formManualCheck.WindowState = FormWindowState.Maximized;
                        this.formManualCheck.Show();
                    }
                    else
                    {
                        this.formManualCheck.Show();
                        this.formManualCheck.BringToFront();
                        this.formManualCheck.WindowState = FormWindowState.Maximized;
                    }
                }
            }
            else
            {
                if (this.formManualCheck == null)
                {
                    this.formManualCheck = new FormManualCheck();
                    this.formManualCheck.MdiParent = this;
                }

                this.formManualCheck.WindowState = FormWindowState.Maximized;
                this.formManualCheck.Show();
                this.formManualCheck.BringToFront();
            }
        }

        /// <summary>
        /// 当窗体大小改变时，修改dgvServer中列的大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDemuraMan_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dgvServer.ColumnCount; i++)
            {
                this.dgvServer.Columns[i].Width = (this.dgvServer.Width - 48) / dgvServer.ColumnCount;
            }
        }

        /// <summary>
        /// 当失败数和通过数改变时，修改直通率的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_TextChanged(object sender, EventArgs e)
        {
            double passNumber = Convert.ToInt32(this.rtbPassNumber.Text);
            double failNumber = Convert.ToInt32(this.rtbFailNumber.Text);

            this.rtbSumNumber.Text = (passNumber + failNumber).ToString();
            
            if ((passNumber * 100) % (passNumber + failNumber) == 0)
            {
                this.rtbSuccessRate.Text = ((passNumber * 100) / (passNumber + failNumber)).ToString();
            }
            else
            {
                this.rtbSuccessRate.Text = ((passNumber * 100) / (passNumber + failNumber)).ToString("f2");
            }
        }

        private void FormDemuraMan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止所有轴
            Global.ControlCard.AxisStop(null, AxisStopType.EmgStop, true);
            Global.ControlCard.CloseCard(true);
            Global.IoCard.BoardClose(true);
            Global.SocketServer.Stop();

            if (this.formAutomaticCheck != null)
            {
                this.formAutomaticCheck.Stop();
            }

            System.Environment.Exit(0);
        }

        #endregion

        private void rtbLog_KeyPress(object sender, KeyPressEventArgs e)
        { 
            
            if (e.KeyChar == (char)Keys.Back)
            {
                RichTextBox rtb = (RichTextBox)sender;
                rtb.Text=rtb.Text.Remove(rtb.SelectionStart, rtb.SelectionLength);
            }
        }

        private void FormDemuraMan_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
