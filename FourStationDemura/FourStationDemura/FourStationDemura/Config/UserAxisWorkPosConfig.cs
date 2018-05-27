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
    public partial class UserAxisWorkPosConfig : UserControl
    {
        #region 属性

        /// <summary>
        /// 运动轴实体
        /// </summary>
        private AxisInfo axisInfo = null;

        /// <summary>
        /// 工位
        /// </summary>
        public int WorkNumber { set; get; }

        /// <summary>
        /// 工作位置
        /// </summary>
        public string WorkPos { set; get; }

        /// <summary>
        /// 绑定的轴名称
        /// </summary>
        public string AxisName { set; get; }

        #endregion

        #region 构造函数

        public UserAxisWorkPosConfig()
        {
            InitializeComponent();
        }

        public UserAxisWorkPosConfig(AxisInfo axisInfo, int workNumber)
        {
            InitializeComponent();

            this.axisInfo = axisInfo;
            this.AxisName = axisInfo.AxisName;
            this.WorkNumber = workNumber;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置工作位置信息
        /// </summary>
        /// <param name="workPosName"></param>
        /// <param name="workPos"></param>
        public void SetWorkPos(string workPos, string workPosName = null)
        {
            if (workPosName != null)
            {
                this.lblWorkPosName.Text = workPosName;
            }

            this.txtWorkPos.Text = workPos;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 获取光标时选中文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWorkPos_Enter(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            txtBox.Tag = true;
            txtBox.SelectAll();
        }

        /// <summary>
        /// 更改控件内容时取消选中文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWorkPos_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (e.Button == MouseButtons.Left && (bool)txtBox.Tag == true)
            {
                txtBox.SelectAll();
            }

            //取消全选标记              
            txtBox.Tag = false;
        }

        /// <summary>
        /// 设置文本框只能输入数字和小数点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWorkPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)46 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        ///  检测文本内容是否为数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWorkPos_Leave(object sender, EventArgs e)
        {
           TextBox txtBox = sender as TextBox;

            try
            {
                var v = Convert.ToDouble(txtBox.Text);
                txtBox.Text = v.ToString();
            }
            catch
            {
                txtBox.Text = "0";
                txtBox.Focus();
            }
        }

        /// <summary>
        /// 获取轴当前位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorkPos_Click(object sender, EventArgs e)
        {
            //脉冲数，需要转换为毫米/度
            int pulseNumber = Global.ControlCard.GetPosition(this.axisInfo,true);

            if (pulseNumber * this.axisInfo.MaxLimit % this.axisInfo.Step == 0)
            {
                this.txtWorkPos.Text = (pulseNumber * this.axisInfo.MaxLimit / this.axisInfo.Step).ToString();
            }
            else
            {
                this.txtWorkPos.Text = (pulseNumber * this.axisInfo.MaxLimit / this.axisInfo.Step).ToString("f2");
            }
        }

        /// <summary>
        /// 位置改变时给全局变量赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWorkPos_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = ((TextBox)sender);

            if (txt.Text == "")
            {
                txt.Text = "0";
            }

            this.WorkPos = txt.Text;
        }

        #endregion


    }
}
