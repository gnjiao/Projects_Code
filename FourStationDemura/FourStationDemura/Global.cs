using IIXDeMuraApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    /// <summary>
    /// 保存一些常用的全部变量，减少参数的传递
    /// </summary>
    public class Global
    {
        /// <summary>
        /// 屏检测通过数
        /// </summary>
        public static int PassNumber{ get; set; }

        /// <summary>
        /// 屏检测失败数
        /// </summary>
        public static int FailNumber { get; set; }

        /// <summary>
        /// 登入用户ID
        /// </summary>
        public static string UserID { get; set; }

        /// <summary>
        /// 工号，这里指登入用户名
        /// </summary>
        public static string WorkNumber { get; set; }

        /// <summary>
        /// 登入密码
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// 系统配置文件路径
        /// </summary>
        public static string ConfigPath { get; set; }

        /// <summary>
        /// 项目配置文件的路径
        /// </summary>
        public static string ProductSettingPath { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public static string ProductName { get; set; }

        /// <summary>
        /// 用户配置文件路径
        /// </summary>
        public static string UsersConfigPath { get; set; }

        /// <summary>
        /// 是否允许强制启动运动按钮
        /// </summary>
        public static bool IsAllowMove { get; set; }

        /// <summary>
        /// 控制卡
        /// </summary>
        public static ControlCardBase ControlCard { get; set; }

        /// <summary>
        /// IO卡
        /// </summary>
        public static IoCardBase IoCard { get; set; }

        /// <summary>
        /// Socket服务类对象
        /// </summary>
        public static SocketServer SocketServer { get; set; }

        /// <summary>
        /// 用户表
        /// </summary>
        public static DataTable DtUser { get; set; }

        /// <summary>
        /// Pattern数
        /// </summary>
        public static int PatternNumber { get; set; }

        /// <summary>
        /// 控制卡动作超时时间
        /// </summary>
        public static int CardWaitTime { get; set; }

        /// <summary>
        /// 是否记录动作日志
        /// </summary>
        public static bool WriterActionLog { get; set; }

        /// <summary>
        /// 是否需要复位
        /// </summary>
        public static bool isReset { get; set; }

        /// <summary>
        /// 是否可以继续
        /// </summary>
        public static bool isContinue { get; set; }

        /// <summary>
        /// IIX动作超时时间
        /// </summary>
        public static int IIXWaitTime { get; set; }

        /// <summary>
        /// 运动轴列表
        /// </summary>
        private static Dictionary<string, string> mDictAxis = new Dictionary<string, string>();

        /// <summary>
        /// 运动轴列表
        /// </summary>
        public static Dictionary<string, string> DictAxis
        {
            get { return mDictAxis; }
            set { mDictAxis = value; }
        }

        /// <summary>
        /// 运动轴实体集合
        /// </summary>
        private static List<AxisInfo> mListAxis = new List<AxisInfo>();

        /// <summary>
        /// 运动轴实体集合
        /// </summary>
        public static List<AxisInfo> ListAxis
        {
            get { return mListAxis; }
            set { mListAxis = value; }
        }

        /// <summary>
        /// IIX服务端集合
        /// </summary>
        private static List<IIXServer> mListIIXSerevr = new List<IIXServer>();

        /// <summary>
        /// IIX服务端集合
        /// </summary>
        public static List<IIXServer> ListIIXSerevr
        {
            get { return mListIIXSerevr; }
            set { mListIIXSerevr = value; }
        }

        /// <summary>
        /// 部门列表
        /// </summary>
        private static Dictionary<string, string> mDictDept = new Dictionary<string, string>();

        /// <summary>
        /// 部门列表
        /// </summary>
        public static Dictionary<string, string> DictDept
        {
            get { return mDictDept; }
            set { mDictDept = value; }
        }

        /// <summary>
        /// 正在检测的屏幕集合
        /// </summar
        private static List<OLEDPanel> mListOLEDPanel = new List<OLEDPanel>();

        /// <summary>
        /// 正在检测的屏幕集合
        /// </summary>
        public static List<OLEDPanel> ListOLEDPanel
        {
            get { return mListOLEDPanel; }
            set { mListOLEDPanel = value; }
        }

        /// <summary>
        /// 是否为手动模式
        /// </summary>
        public static bool IsDeBugMode { get; set; }

        /// <summary>
        /// 是否初始化完成
        /// </summary>
        public static bool IsInit { get; set; }

        /// <summary>
        /// 当前转盘工作的位置
        /// </summary>
        private static int mWorkPos = 1;

        /// <summary>
        /// 当前转盘的工作位置
        /// </summary>
        public static int WorkPos
        {
            get { return mWorkPos; }
            set { mWorkPos = value; }
        }

        /// <summary>
        /// 主窗体dgv控件
        /// </summary>
        public static DataGridView DgvServer { get; set; }

        /// <summary>
        /// 主窗体屏检测通过数量显示控件
        /// </summary>
        public static RichTextBox RtbPassNumber { get; set; }

        /// <summary>
        /// 主窗体屏检测失败数量显示控件
        /// </summary>
        public static RichTextBox RtbFailNumber { get; set; }

        /// <summary>
        /// 设置委托，启动运动按钮选中状态
        /// </summary>
        public delegate void IsAllowMoveDlegate();

        /// <summary>
        /// 注册事件，启动运动按钮选中状态改变事件
        /// </summary>
        public static event IsAllowMoveDlegate IsAllowMoveEvent;

        /// <summary>
        /// 设置委托，切换项目
        /// </summary>
        public delegate void SwitchProductDlegate();

        /// <summary>
        /// 注册事件，切换项目
        /// </summary>
        public static event SwitchProductDlegate SwitchProductEvent;

        /// <summary>
        /// 运动按钮选中状态改变事件
        /// </summary>
        public static void AllowMove()
        {
            if (IsAllowMoveEvent != null)
            {
                IsAllowMoveEvent();
            }
        }

        /// <summary>
        /// 切换项目事件
        /// </summary>
        public static void SwitchProduct()
        {
            if (SwitchProductEvent != null)
            {
                SwitchProductEvent();
            }
        }

        /// <summary>
        /// 修改主界面dgv的值
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="connOpen"></param>
        /// <param name="pgPrimary"></param>
        /// <param name="pgSecondary"></param>
        /// <param name="resultState"></param>
        /// <param name="latestResult"></param>
        public static void UpdateDgv(string ip, string connOpen = null, string pgPrimary = null, string pgSecondary = null, string resultState = null, string latestResult = null)
        {
            DgvServer.BeginInvoke((MethodInvoker)delegate
            {
                DataGridViewRow dr = null;
                foreach (DataGridViewRow row in DgvServer.Rows)
                {
                    if (row.Cells["ServerIP"].Value.ToString() == ip)
                    {
                        dr = row;
                        break;
                    }
                }

                if (connOpen != null)
                {
                    dr.Cells["Open"].Value = connOpen;
                }
                if (pgPrimary != null)
                {
                    dr.Cells["PgPrimary"].Value = pgPrimary;
                }
                if (pgSecondary != null)
                {
                    dr.Cells["PgSecondary"].Value = pgSecondary;
                }
                if (resultState != null)
                {
                    dr.Cells["Status"].Value = resultState;
                }
                if (latestResult != null)
                {
                    if (latestResult != CmdResultCode.Success.ToString())
                    {
                        dr.Cells["LatestResult"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dr.Cells["LatestResult"].Style.ForeColor = new Color();
                    }

                    dr.Cells["LatestResult"].Value = latestResult;
                }
            });
        }

        /// <summary>
        /// 给检测屏幕通过或失败数量赋值
        /// </summary>
        public static void SetNumber()
        {
            RtbPassNumber.BeginInvoke((MethodInvoker)delegate
            {
                RtbPassNumber.Text = PassNumber.ToString();
            });

            RtbFailNumber.BeginInvoke((MethodInvoker)delegate
            {
                RtbFailNumber.Text = FailNumber.ToString();
            });
        }

        /// <summary>
        /// 指定路径下是否存在指定后缀名的文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="suffixName">后缀</param>
        /// <returns>文件名</returns>
        public static string IsExistFileBySuffixName(string path, string suffixName)
        {
            string fileName = "";
            DirectoryInfo dir = new DirectoryInfo(path);
            
            foreach (var file in dir.GetFiles())
            {
                if (Path.GetExtension(file.FullName) == suffixName)
                {
                    fileName = file.Name;
                    break;
                }
            }

            return fileName;
        }
    }
}
