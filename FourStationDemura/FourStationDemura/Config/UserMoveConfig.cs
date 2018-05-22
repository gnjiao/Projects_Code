using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    public partial class UserMoveConfig : UserControl
    {
        #region 属性

        /// <summary>
        /// 运动控制窗体
        /// </summary>
        private FormMove formMove = null;

        /// <summary>
        /// VCR轴工作位置设置窗体
        /// </summary>
        private UserVCRAxisWorkPosConfig vcrAxisWorkPosConfig = null;

        //普通轴工作位置设置窗体
        private UserAxisWorkPosConfig axisWorkPosConfig = null;

        #endregion

        #region 构造函数

        public UserMoveConfig()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化各轴的工作位置
        /// </summary>
        public void InitWorkPos()
        {
            try
            {
                int x = 18;
                int y = 15;

                #region 初始化VCR轴工作位置信息

                var axisInfoX = Global.ListAxis.Where(info => info.AxisName == "VCR-X").FirstOrDefault();
                var axisInfoZ = Global.ListAxis.Where(info => info.AxisName == "VCR-Z").FirstOrDefault();

                for (int i = 1; i <= 3; i++)
                {
                    string workPosX = IniFile.IniReadValue("VCR-X", string.Format("WorkPos" + i), Global.ProductSettingPath);
                    string workPosZ = IniFile.IniReadValue("VCR-Z", string.Format("WorkPos" + i), Global.ProductSettingPath);

                    this.vcrAxisWorkPosConfig = new UserVCRAxisWorkPosConfig(axisInfoX, axisInfoZ, i);
                    this.vcrAxisWorkPosConfig.SetWorkPos(workPosX, workPosZ, "工作位置#" + i);
                    this.vcrAxisWorkPosConfig.Location = new Point(x, y);

                    this.pnlVCR.Controls.Add(this.vcrAxisWorkPosConfig);

                    x += this.vcrAxisWorkPosConfig.Width + 5;
                }

                #endregion

                #region 初始化转盘轴工作位置信息

                x = 111;
                y = 12;

                var axisInfo = Global.ListAxis.Where(info => info.AxisName == "转盘").FirstOrDefault();

                for (int i = 1; i <= 4; i++)
                {
                    string workPos = IniFile.IniReadValue("转盘", string.Format("WorkPos" + i), Global.ProductSettingPath);

                    this.axisWorkPosConfig = new UserAxisWorkPosConfig(axisInfo, i);
                    this.axisWorkPosConfig.SetWorkPos(workPos, "工作位置#" + i);
                    this.axisWorkPosConfig.Location = new Point(x, y);

                    this.pnlDial.Controls.Add(this.axisWorkPosConfig);

                    if (i % 2 != 0)
                    {
                        x += this.axisWorkPosConfig.Width + 137;
                    }
                    else
                    {
                        x = 111;
                        y += this.axisWorkPosConfig.Height + 26;
                    }
                }

                #endregion

                #region 初始化检测相机轴工作位置信息

                x = 111;
                y = 15;

                for (int i = 1; i <= 3; i++)
                {
                    axisInfo = Global.ListAxis.Where(info => info.AxisName == "检测相机#" + i).FirstOrDefault();
                    string workPos = IniFile.IniReadValue(string.Format("检测相机#" + i), "WorkPos1", Global.ProductSettingPath);

                    this.axisWorkPosConfig = new UserAxisWorkPosConfig(axisInfo, 1);
                    this.axisWorkPosConfig.SetWorkPos(workPos, "检测相机#" + i);
                    this.axisWorkPosConfig.Location = new Point(x, y);

                    this.pnlCamera.Controls.Add(this.axisWorkPosConfig);

                    y += this.axisWorkPosConfig.Height + 20;
                }

                #endregion

                #region 初始化复检相机轴工作位置信息

                x = 111 + this.axisWorkPosConfig.Width + 137;
                y = 15;

                for (int i = 1; i <= 3; i++)
                {
                    axisInfo = Global.ListAxis.Where(info => info.AxisName == "复检相机#" + i).FirstOrDefault();
                    string workPos = IniFile.IniReadValue(string.Format("复检相机#" + i), "WorkPos1", Global.ProductSettingPath);

                    this.axisWorkPosConfig = new UserAxisWorkPosConfig(axisInfo, 1);
                    this.axisWorkPosConfig.SetWorkPos(workPos, "复检相机#" + i);
                    this.axisWorkPosConfig.Location = new Point(x, y);

                    this.pnlCamera.Controls.Add(this.axisWorkPosConfig);

                    y += this.axisWorkPosConfig.Height + 20;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 打开/关闭运动控制面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenMove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnOpenMove.Text == "打开控制面板")
                {
                    this.btnOpenMove.Text = "关闭控制面板";

                    if (this.formMove == null)
                    {
                        this.formMove = new FormMove();
                        this.formMove.BringToFront();
                        this.formMove.CloseEvent += FormMove_MyClose;
                        this.formMove.Show();
                    }
                    else
                    {
                        this.formMove.Show();
                        this.formMove.BringToFront();
                    }
                }
                else
                {
                    this.btnOpenMove.Text = "打开控制面板";
                    this.formMove.Close();
                    this.formMove = null;
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 控制面板关闭事件
        /// </summary>
        private void FormMove_MyClose()
        {
            this.btnOpenMove.Text = "打开控制面板";
            this.formMove.Close();
            this.formMove = null;
        }

        private void UserMoveConfig_Load(object sender, EventArgs e)
        {
            this.InitWorkPos();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                AxisInfo axis = Global.ListAxis.Where(info => info.AxisName == "转盘").FirstOrDefault();

                foreach (Control control in this.pnlDial.Controls)
                {

                    if (control is UserAxisWorkPosConfig)
                    {
                        this.axisWorkPosConfig = ((UserAxisWorkPosConfig)control);

                        //修改配置文件中的值
                        IniFile.IniWriteValue("转盘", "WorkPos" + this.axisWorkPosConfig.WorkNumber, this.axisWorkPosConfig.WorkPos, Global.ProductSettingPath);

                        //修改缓存中的值
                        if (this.axisWorkPosConfig.WorkNumber == 1)
                        {
                            axis.WorkPos1 = Convert.ToDouble(this.axisWorkPosConfig.WorkPos);
                        }
                        else if (this.axisWorkPosConfig.WorkNumber == 2)
                        {
                            axis.WorkPos2 = Convert.ToDouble(this.axisWorkPosConfig.WorkPos);
                        }
                        else if (this.axisWorkPosConfig.WorkNumber == 3)
                        {
                            axis.WorkPos3 = Convert.ToDouble(this.axisWorkPosConfig.WorkPos);
                        }
                        else if (this.axisWorkPosConfig.WorkNumber == 4)
                        {
                            axis.WorkPos4 = Convert.ToDouble(this.axisWorkPosConfig.WorkPos);
                        }
                    }
                }

                foreach (Control control in this.pnlCamera.Controls)
                {
                    if (control is UserAxisWorkPosConfig)
                    {
                        this.axisWorkPosConfig = ((UserAxisWorkPosConfig)control);
                        IniFile.IniWriteValue(this.axisWorkPosConfig.AxisName, "WorkPos1", this.axisWorkPosConfig.WorkPos, Global.ProductSettingPath);

                        axis = Global.ListAxis.Where(info => info.AxisName == this.axisWorkPosConfig.AxisName).FirstOrDefault();
                        axis.WorkPos1 = Convert.ToDouble(this.axisWorkPosConfig.WorkPos);
                    }
                }

                var axisX = Global.ListAxis.Where(info => info.AxisName == "VCR-X").FirstOrDefault();
                var axisY = Global.ListAxis.Where(info => info.AxisName == "VCR-Z").FirstOrDefault();

                foreach (Control control in this.pnlVCR.Controls)
                {
                    if (control is UserVCRAxisWorkPosConfig)
                    {
                        this.vcrAxisWorkPosConfig = ((UserVCRAxisWorkPosConfig)control);

                        IniFile.IniWriteValue("VCR-X", "WorkPos" + this.vcrAxisWorkPosConfig.WorkNumber, this.vcrAxisWorkPosConfig.WorkPosX, Global.ProductSettingPath);
                        IniFile.IniWriteValue("VCR-Z", "WorkPos" + this.vcrAxisWorkPosConfig.WorkNumber, this.vcrAxisWorkPosConfig.WorkPosY, Global.ProductSettingPath);

                        if (this.vcrAxisWorkPosConfig.WorkNumber == 1)
                        {
                            axisX.WorkPos1 = Convert.ToDouble(this.vcrAxisWorkPosConfig.WorkPosX);
                            axisY.WorkPos1 = Convert.ToDouble(this.vcrAxisWorkPosConfig.WorkPosY);
                        }
                        else if (this.vcrAxisWorkPosConfig.WorkNumber == 2)
                        {
                            axisX.WorkPos2 = Convert.ToDouble(this.vcrAxisWorkPosConfig.WorkPosX);
                            axisY.WorkPos2 = Convert.ToDouble(this.vcrAxisWorkPosConfig.WorkPosY);
                        }
                        else if (this.vcrAxisWorkPosConfig.WorkNumber == 3)
                        {
                            axisX.WorkPos3 = Convert.ToDouble(this.vcrAxisWorkPosConfig.WorkPosX);
                            axisY.WorkPos3 = Convert.ToDouble(this.vcrAxisWorkPosConfig.WorkPosY);
                        }
                    }
                }

                MessageBox.Show("保存成功。");
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                MessageBox.Show("保存失败。");
            }
        }

        /// <summary>
        /// 取消，这里做还原处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in this.pnlDial.Controls)
                {
                    if (control is UserAxisWorkPosConfig)
                    {
                        this.axisWorkPosConfig = ((UserAxisWorkPosConfig)control);
                        var workPos = IniFile.IniReadValue("转盘", string.Format("WorkPos" + this.axisWorkPosConfig.WorkNumber), Global.ProductSettingPath);

                        this.axisWorkPosConfig.SetWorkPos(workPos: workPos);

                    }
                }

                foreach (Control control in this.pnlCamera.Controls)
                {
                    if (control is UserAxisWorkPosConfig)
                    {
                        this.axisWorkPosConfig = ((UserAxisWorkPosConfig)control);
                        var workPos = IniFile.IniReadValue(this.axisWorkPosConfig.AxisName, string.Format("WorkPos" + this.axisWorkPosConfig.WorkNumber), Global.ProductSettingPath);

                        this.axisWorkPosConfig.SetWorkPos(workPos: workPos);
                    }
                }

                foreach (Control control in this.pnlVCR.Controls)
                {
                    if (control is UserVCRAxisWorkPosConfig)
                    {
                        this.vcrAxisWorkPosConfig = ((UserVCRAxisWorkPosConfig)control);
                        var workPosX = IniFile.IniReadValue("VCR-X", string.Format("WorkPos" + this.axisWorkPosConfig.WorkNumber), Global.ProductSettingPath);
                        var workPosY = IniFile.IniReadValue("VCR-Z", string.Format("WorkPos" + this.axisWorkPosConfig.WorkNumber), Global.ProductSettingPath);

                        this.vcrAxisWorkPosConfig.SetWorkPos(workPosX: workPosX, workPosY: workPosY);
                    }
                }

                MessageBox.Show("取消成功。");
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
                MessageBox.Show("取消失败。");
            }
        }

        #endregion

    }
}
