using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IIXDeMuraApi;

namespace FourStationDemura
{
    public partial class UserParameterConfig : UserControl
    {
        #region 属性

        /// <summary>
        /// 最近一次项目名
        /// </summary>
        private string lastProductName = null;

        /// <summary>
        /// 项目路径
        /// </summary>
        private string productPath = null;

        #endregion

        #region 构造函数

        public UserParameterConfig()
        {
            InitializeComponent();
            this.productPath = Application.StartupPath + "\\Product";

            this.InitProductList();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化项目列表
        /// </summary>
        private void InitProductList()
        {
            try
            {
                if (!Directory.Exists(this.productPath))
                {
                    Directory.CreateDirectory(this.productPath);
                }

                DirectoryInfo folder = new DirectoryInfo(this.productPath);

                if (folder.GetDirectories().Length == 0)
                {
                    return;
                }

                foreach (var dir in folder.GetDirectories())
                {
                    this.cbbProductName.Items.Add(dir.Name);
                }

                if (this.cbbProductName.Items.Contains(Global.ProductName))
                {
                    this.cbbProductName.SelectedItem = Global.ProductName;
                }
                else
                {
                    if (this.cbbProductName.Items.Count > 0)
                    {
                        this.cbbProductName.SelectedIndex = 0;
                        IniFile.IniWriteValue("Product", "ProductName", this.cbbProductName.SelectedItem.ToString(), Global.ConfigPath);
                    }
                }

                if (this.cbbProductName.SelectedItem != null)
                {
                    this.lastProductName = this.cbbProductName.SelectedItem.ToString();

                }
                else
                {
                    this.lastProductName = null;
                }
            }
            catch (Exception ex)
            {
                Log.GetInstance().ErrorWrite("系统错误，请查询日志文件检查。");
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 加载当前项目信息
        /// </summary>
        private bool LoadProduct()
        {
            try
            {
                var productName = this.cbbProductName.SelectedItem.ToString();

                if (MoveExecute.LoadSettings(productName))
                {
                    Log.GetInstance().NormalWrite("重新加载项目配置文件配置成功。");
                }
                else
                {
                    Log.GetInstance().ErrorWrite("重新加载项目配置文件配置失败。");
                    this.lastProductName = null;
                    this.cbbProductName.SelectedIndex = -1;
                    return false;
                }

                var currentProductPath = Path.Combine(this.productPath, productName);
                var fileName = Global.IsExistFileBySuffixName(currentProductPath, ".bin");

                if (fileName == "")
                {
                    Log.GetInstance().ErrorWrite(string.Format("目录 '{0}' 下没有找到该项目的bin文件,切换项目失败。", currentProductPath));
                    this.lastProductName = null; ;
                    this.cbbProductName.SelectedIndex = -1;
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
                    Log.GetInstance().ErrorWrite(string.Format("切换项目失败,原因：设置Recipe失败。"));
                    this.lastProductName = null;
                    this.cbbProductName.SelectedIndex = -1;
                    return false;
                }

                //修改配置文件中当前项目名
                IniFile.IniWriteValue("Product", "ProductName", productName, Global.ConfigPath);
                this.lastProductName = productName;

                return true;
            }
            catch (Exception ex)
            {
                Log.GetInstance().ErrorWrite("系统错误，请查询日志文件检查。");
                Log.WriterExceptionLog(ex.ToString());

                return false;
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 切换项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbbProductName.SelectedItem == null) return;

                if (this.cbbProductName.SelectedItem.ToString() != Global.ProductName)
                {
                    var productName = this.cbbProductName.SelectedItem.ToString();

                    if (this.lastProductName == productName)
                    {
                        return;
                    }

                    if (MessageBox.Show("你确定要更换项目？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (this.LoadProduct())
                        {
                            Global.ProductName = productName;
                        }
                        else
                        {
                            Global.ProductName = "";
                        }

                        Global.SwitchProduct();
                    }
                    else
                    {
                        this.cbbProductName.SelectedItem = this.lastProductName;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GetInstance().ErrorWrite("系统错误，请查询日志文件检查。");
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 启动运动按钮选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbAllowMovement_CheckedChanged(object sender, EventArgs e)
        {
            Global.IsAllowMove = this.ckbAllowMovement.Checked;
            Global.AllowMove();
        }

        private void UserParameterConfig_SizeChanged(object sender, EventArgs e)
        {
            int x = (this.Width - this.gbParameterConfig.Width) / 2;
            int y = (this.Height - this.gbParameterConfig.Height) / 2;

            this.gbParameterConfig.Location = new Point(x, y);
        }

        #endregion
    }
}
