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
    public partial class UserIIXConfig : UserControl
    {
        #region 构造函数

        public UserIIXConfig()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置Recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetRecipePath_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    if (!string.IsNullOrWhiteSpace(this.txtSetRecipeFile.Text))
                    {
                        string fileDir = Path.GetDirectoryName(this.txtSetRecipeFile.Text);
                        if (Directory.Exists(fileDir))
                        {
                            dialog.InitialDirectory = fileDir;
                            dialog.FileName = Path.GetFileName(this.txtSetRecipeFile.Text);
                        }
                    }

                    dialog.Title = "Select recipe file.";
                    dialog.Filter = string.Format("{0} file(*.{0})|*.{0}", "bin");
                    dialog.FileName = Path.GetFileName(this.txtSetRecipeFile.Text);
                    if (dialog.ShowDialog() != DialogResult.OK) return;

                    this.txtSetRecipeFile.Text = dialog.FileName;

                    if (MessageBox.Show("确定设置Recipe吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var tasks = new List<Task>();

                        foreach (var iixServer in Global.ListIIXSerevr)
                        {
                            if (iixServer.IsEnable == false) continue;

                            tasks.Add(Task.Factory.StartNew(() =>
                            {
                                IIXExecute.SetRecipe(iixServer, dialog.FileName);
                            }));
                        }

                        Task.WaitAll(tasks.ToArray());
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
        /// 获取Recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetRecipeFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Save folder of recipe file.";

                    if (!string.IsNullOrWhiteSpace(this.txtGetRecipeFile.Text)
                     && (Directory.Exists(this.txtGetRecipeFile.Text)))
                    {
                        dialog.SelectedPath = this.txtGetRecipeFile.Text;
                    }

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.txtGetRecipeFile.Text = dialog.SelectedPath;

                        var tasks = new List<Task>();

                        foreach (var iixServer in Global.ListIIXSerevr)
                        {
                            if (iixServer.IsEnable == false) continue;

                            tasks.Add(Task.Factory.StartNew(() =>
                            {
                                IIXExecute.GetRecipe(iixServer, dialog.SelectedPath);
                            }));
                        }

                        Task.WaitAll(tasks.ToArray());
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
        /// 修改License
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLicenseFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    if (!string.IsNullOrWhiteSpace(this.txtLicenseFile.Text))
                    {
                        string fileDir = Path.GetDirectoryName(this.txtLicenseFile.Text);
                        if (Directory.Exists(fileDir))
                        {
                            dialog.InitialDirectory = fileDir;
                        }
                        dialog.FileName = Path.GetFileName(this.txtLicenseFile.Text);
                    }
                    dialog.Title = "Select License file.";
                    dialog.Filter = string.Format("key pack file(*.{0})|*.{0}", "keys");
                    dialog.Filter += string.Format("|{0} file(*.{0})|*.{0}", "key");
                    dialog.Filter += "|All file(*.*)|*.*";
                    dialog.FileName = Path.GetFileName(this.txtLicenseFile.Text);
                    if (dialog.ShowDialog() != DialogResult.OK) return;

                    this.txtLicenseFile.Text = dialog.FileName;

                    if (MessageBox.Show("确定更新License吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var tasks = new List<Task>();

                        foreach (var iixServer in Global.ListIIXSerevr)
                        {
                            if (iixServer.IsEnable == false) continue;

                            tasks.Add(Task.Factory.StartNew(() =>
                            {
                                IIXExecute.UpdateLicense(iixServer, dialog.FileName);
                            }));
                        }

                        Task.WaitAll(tasks.ToArray());
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
        /// 调整 slave pc 时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdjustTime_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定调整Slave PC 时间吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var tasks = new List<Task>();
                    this.dtpAdjustTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                    DateTimeInfo dtInfo = new DateTimeInfo(this.dtpAdjustTime.Value);
                    foreach (var iixServer in Global.ListIIXSerevr)
                    {
                        if (iixServer.IsEnable == false) continue;

                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            IIXExecute.AdjustPCTime(iixServer, dtInfo);
                        }));
                    }

                    Task.WaitAll(tasks.ToArray());
                }
            }
            catch (Exception ex)
            {
                Log.GetInstance().ErrorWrite("系统错误，请查询日志文件检查。");
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 控件第一次获取光标时，设置时间值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpAdjustTime_MouseEnter(object sender, EventArgs e)
        {
            if (this.dtpAdjustTime.Text.Trim() == "")
            {
                this.dtpAdjustTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";

                this.dtpAdjustTime.Value = DateTime.Now;
            }
        }

        private void UserIIXConfig_SizeChanged(object sender, EventArgs e)
        {
            int x = (this.Width - this.gbIIXConfig.Width) / 2;
            int y = (this.Height - this.gbIIXConfig.Height) / 2;

            this.gbIIXConfig.Location = new Point(x, y);
        }

        #endregion
    }
}
