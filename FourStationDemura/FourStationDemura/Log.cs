using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FourStationDemura
{
    public class Log
    {
        private static Log log;
        private static RichTextBox rtbLog;
        private static int maxLines;
        private static Queue<QueueInfo> messageQueue = new Queue<QueueInfo>();
        private static Thread logWriteThread = null;
        private static bool threadLoop = true;
        private static int threadInterval = 1;
        private static object queueLock = new object();
        private static object objException = new object();
        private static object objAction = new object();

        /// <summary>
        /// 一般日志提示颜色，黑色
        /// </summary>
        public Color NormalColor = Color.Black;

        /// <summary>
        /// 错误日志提示颜色，红色
        /// </summary>
		public Color ErrorColor = Color.Red;

        /// <summary>
        /// 警告日志提示颜色，蓝色
        /// </summary>
		public Color WarningColor = Color.Blue;

        public static int MaxLines
        {
            get { return maxLines; }
            private set { maxLines = value; }
        }

        public static RichTextBox RtbLog
        {
            get { return rtbLog; }
            set { rtbLog = value; }
        }

        private struct QueueInfo
        {
            public string message;
            public Color color;
            public QueueInfo(string msg, Color col)
            {
                message = msg;
                color = col;
            }
        }

        /// <summary> 构造函数 </summary>
        /// <param name="rtbLog"> 显示日志的容器</param>
        /// <param name="maxLen"> 最大行数 </param>
        private Log(RichTextBox rtbLog, int maxLen)
        {
            RtbLog = rtbLog;
            MaxLines = maxLen;
            IntPtr dmy = rtbLog.Handle;
        }

        /// <summary>创建日志模块</summary>
        /// <param name="rtbLog"> 显示错误的容器 </param>
        /// <param name="maxLen"> 最大行数 </param>
        public static void CreateLogInstance(RichTextBox rtbLog, int maxLen)
        {
            if (log == null)
            {
                log = new Log(rtbLog, maxLen);
                ThreadStart();
            }
        }

        /// <summary>返回日志对象 </summary>
        /// <returns> </returns>
        public static Log GetInstance()
        {
            return log;
        }

        /// <summary>
        /// 线程开始
        /// </summary>
        public static void ThreadStart()
        {
            logWriteThread = new Thread(LogThread);
            logWriteThread.IsBackground = true;
            threadLoop = true;
            logWriteThread.Start();
        }

        /// <summary>
        /// 线程结束
        /// </summary>
        public static void Close()
        {
            threadLoop = false;
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        public static void Clear()
        {
            RtbLog.Clear();
        }

        /// <summary> 将日志添加到队列 </summary>
        /// <param name="msg"> 日志内容 </param>
        /// <param name="col"> 显示颜色 </param>
        /// <remarks>  </remarks>
        public virtual void WriteLine(string msg, Color col)
        {

            msg = DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss.fff] \r\n") + msg;
            lock (queueLock)
            {
                messageQueue.Enqueue(new QueueInfo(msg, col));
            }
        }

        /// <summary> 写入日志 </summary>
        /// <param name="msg">  </param>
        /// <param name="conCol"> </param>
        public virtual void WriteLine(string msg, ConsoleColor conCol)
        {
            WriteLine(msg, ConvertToDrawingColor(conCol));
        }

        /// <summary> 一般日志 </summary>
        /// <param name="message">  </param>
        public virtual void NormalWrite(object message)
        {
            WriteLine(message.ToString(), NormalColor);
        }

        /// <summary> 警告日志</summary>
        /// <param name="message">  </param>
        public void WarningWrite(object message)
        {
            WriteLine("警告：" + message.ToString(), WarningColor);
        }

        /// <summary> 错误日志</summary>
        /// <param name="message">  </param>
        public void ErrorWrite(object message)
        {
            WriteLine("错误：" + message.ToString(), ErrorColor);
        }

        /// <summary>
        /// 动作日志
        /// </summary>
        /// <param name="actionName">动作名称</param>
        /// <param name="msg">提示</param>
        /// <param name="isShowLog">是否显示到UI</param>
        public void ActionWrite(string actionName, string msg, bool isShowLog)
        {
            if (msg == "成功")
            {
                msg = string.Format("{0}成功", actionName);
            }
            else
            {
                msg = string.Format("{0}失败，错误原因：{1}", actionName, msg);
            }

            if (isShowLog)
            {
                if (msg == "成功")
                {
                    this.NormalWrite(msg);
                }
                else
                {
                    this.ErrorWrite(msg);
                }
            }

            WriterActionLog(msg);
        }

        /// <summary> 异常日志 </summary>
        /// <param name="exp"> 表示例外 </param>
        public void ExceptionWrite(Exception exp)
        {
            if (exp == null) return;

            StringBuilder msg = new StringBuilder();
            msg.AppendLine("系统异常：");
            Exception ex = exp;
            while (ex != null)
            {
                msg.AppendLine("[Exception]:" + ex.GetType().FullName);

                if (!string.IsNullOrWhiteSpace(ex.Message)) msg.AppendLine("[Message]:" + ex.Message);
                if (!string.IsNullOrWhiteSpace(ex.Source)) msg.AppendLine("[Source ]:" + ex.Source);
                if (ex.TargetSite != null) msg.AppendLine("[Method ]:" + ex.TargetSite.ToString());
                if (!string.IsNullOrWhiteSpace(ex.StackTrace)) msg.AppendLine("[Stack  ]:" + Environment.NewLine + ex.StackTrace);

                var socketExcep = ex as SocketException;
                if (socketExcep != null)
                {
                    msg.AppendLine(string.Format("__[SocketErrorCode]: {0} ({1})", socketExcep.ErrorCode, (SocketError)socketExcep.ErrorCode));
                }
                ex = ex.InnerException;
                if (ex != null) msg.AppendLine("------------------------------------------------------");
            }
            msg.Append("======================================================");

            WriteLine(msg.ToString(), ErrorColor);
        }

        /// <summary>
        /// 启用线程写日志
        /// </summary>
		private static void LogThread()
        {
            try
            {
                while (threadLoop)
                {
                    List<QueueInfo> infoList = new List<QueueInfo>();
                    lock (queueLock)
                    {
                        while (messageQueue.Count > 0)
                        {
                            infoList.Add(messageQueue.Dequeue());
                        }
                    }
                    if (infoList.Count != 0)
                    {
                        WriteLog(infoList);
                        infoList.Clear();
                    }
                    Thread.Sleep(threadInterval);
                }
            }
            catch (ThreadAbortException ex)
            {

            }
            catch (ObjectDisposedException ex)
            {

            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary> 真实写日志 </summary>
        /// <param name="infoList">  </param>
        private static void WriteLog(List<QueueInfo> infoList)
        {
            if (RtbLog == null) return;

            RtbLog.Invoke((MethodInvoker)delegate
            {
                foreach (var item in infoList)
                {
                    RtbLog.Select(RtbLog.Text.Length, 0);
                    RtbLog.SelectionColor = item.color;
                    RtbLog.AppendText(item.message);
                    RtbLog.SelectionLength = item.message.Length;
                    RtbLog.AppendText(Environment.NewLine);

                    //写入到动作日志
                    WriterActionLog(item.message);
                }
                // 最大行数制限
                RemoveLimitMessage();

                RtbLog.Select(RtbLog.Text.Length, 0);
                RtbLog.ScrollToCaret();
                RtbLog.Refresh();
            });
        }

        /// <summary>
        /// 删除超过最大行数部分日志
        /// </summary>
        private static void RemoveLimitMessage()
        {
            if (RtbLog.InvokeRequired)
            {
                RtbLog.Invoke(new Action(RemoveLimitMessage));
                return;
            }

            int rmLen = RtbLog.Lines.Length - MaxLines;
            if (rmLen <= 0) return;

            int rmIdx = RtbLog.GetFirstCharIndexFromLine(rmLen);
            RtbLog.Select(0, rmIdx);

            bool readOnly = RtbLog.ReadOnly;
            RtbLog.ReadOnly = false;
            RtbLog.SelectedText = "";
            RtbLog.ReadOnly = readOnly;
        }

        /// <summary> 转换颜色 </summary>
        /// <param name="conCol"></param>
        /// <returns></returns>
        private Color ConvertToDrawingColor(ConsoleColor conCol)
        {
            if (conCol == ConsoleColor.Cyan) conCol = ConsoleColor.DarkCyan;
            if (conCol == ConsoleColor.Gray) conCol = ConsoleColor.DarkGray;

            switch (conCol)
            {
                case ConsoleColor.Black: return Color.Black;
                case ConsoleColor.Blue: return Color.Blue;
                case ConsoleColor.Cyan: return Color.Cyan;
                case ConsoleColor.DarkBlue: return ColorTranslator.FromHtml("#000080");
                case ConsoleColor.DarkCyan: return ColorTranslator.FromHtml("#008080");
                case ConsoleColor.DarkGray: return ColorTranslator.FromHtml("#808080");
                case ConsoleColor.DarkGreen: return ColorTranslator.FromHtml("#008000");
                case ConsoleColor.DarkMagenta: return ColorTranslator.FromHtml("#800080");
                case ConsoleColor.DarkRed: return ColorTranslator.FromHtml("#800000");
                case ConsoleColor.DarkYellow: return ColorTranslator.FromHtml("#808000");
                case ConsoleColor.Gray: return ColorTranslator.FromHtml("#C0C0C0");
                case ConsoleColor.Green: return ColorTranslator.FromHtml("#00FF00");
                case ConsoleColor.Magenta: return Color.Magenta;
                case ConsoleColor.Red: return Color.Red;
                case ConsoleColor.White: return Color.White;
                case ConsoleColor.Yellow: return Color.Yellow;
                default:
                    break;
            }
            return Color.Black;
        }

        /// <summary>
        /// 将系统错误写入到日志文件
        /// </summary>
        /// <param name="msg"></param>
        public static void WriterExceptionLog(string msg)
        {
            lock(objException)
            {
                Log.CreateLog();

                string logFilePath = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\ExceptionLog.txt";

                FileStream fs = new FileStream(logFilePath, FileMode.Append, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(msg);
                sw.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 将操作动作写入到操作日志
        /// </summary>
        /// <param name="msg"></param>
        public static void WriterActionLog(string msg)
        {
            lock (objAction)
            {
                Log.CreateLog();

                if (Global.WriterActionLog)
                {
                    string logFilePath = Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\ActionLog.txt";

                    FileStream fs = new FileStream(logFilePath, FileMode.Append, FileAccess.Write);

                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(msg);
                    sw.Close();
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 创建日志文件夹
        /// </summary>
        public static void CreateLog()
        {
            var logPath = Application.StartupPath + "\\Log";

            //创建Log文件夹
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            //创建当前的log文件夹
            if (!Directory.Exists(Path.Combine(logPath, DateTime.Now.ToString("yyyy-MM-dd"))))
            {
                Directory.CreateDirectory(Path.Combine(logPath, DateTime.Now.ToString("yyyy-MM-dd")));
            }
        }
    }
}
