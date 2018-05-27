using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process instance = RunningInstance();
            
            if (instance == null)
            {

                Global.UsersConfigPath = Application.StartupPath + "\\Users.xml";

                //检查用户文件是否存在
                if (!File.Exists(Global.UsersConfigPath))
                {
                    XmlFile.CreateXmlFile(Global.UsersConfigPath);
                }
                else
                {
                    Global.DtUser = XmlFile.XmlToDataTable(Global.UsersConfigPath);

                    if (Global.DtUser == null)
                    {
                        XmlFile.CreateXmlFile(Global.UsersConfigPath);
                    }
                    else
                    {
                        DataRow[] dr = Global.DtUser.Select(string.Format("workNumber = 'admin' and userName = 'admin'"));

                        if (dr.Length == 0)
                        {
                            XmlFile.CreateXmlFile(Global.UsersConfigPath);
                        }
                    }
                }
                
                //1.1 没有实例在运行
                Application.Run(new FormLogIn());
            }
        }

        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }
    }
}
