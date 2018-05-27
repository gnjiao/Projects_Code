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
    public partial class UserVCRAxisWorkPosConfig : UserControl
    {
        #region 属性

        /// <summary>
        /// VCR X轴
        /// </summary>
        private AxisInfo axisInfoX = null;

        /// <summary>
        ///  VCR Z轴
        /// </summary>
        private AxisInfo axisInfoZ = null;

        public string WorkPosX { set; get; }

        public string WorkPosY { set; get; }

        /// <summary>
        /// 工位
        /// </summary>
        public int WorkNumber { set; get; }

        #endregion

        #region 构造函数

        public UserVCRAxisWorkPosConfig()
        {
            InitializeComponent();
        }

        public UserVCRAxisWorkPosConfig(AxisInfo axisInfoX, AxisInfo axisInfoZ,int workNumber)
        {
            InitializeComponent();

            this.axisInfoX = axisInfoX;
            this.axisInfoZ = axisInfoZ;
            this.WorkNumber = workNumber;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置工位位置信息
        /// </summary>
        /// <param name="workPosName"></param>
        /// <param name="workPosX"></param>
        /// <param name="workPosY"></param>
        public void SetWorkPos(string workPosX, string workPosY, string workPosName = null)
        {
            if (workPosName != null)
            {
                this.gbWorkPosName.Text = workPosName;
            }

            this.txtXPos.Text = workPosX;
            this.txtZPos.Text = workPosY;
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

        private void btnVCRPos_Click(object sender, EventArgs e)
        {
            //脉冲数，需要转换为毫米/度
            int pulseNumber = Global.ControlCard.GetPosition(this.axisInfoX,true);

            if (pulseNumber * this.axisInfoX.MaxLimit % this.axisInfoX.Step == 0)
            {
                this.txtXPos.Text = (pulseNumber * this.axisInfoX.MaxLimit / this.axisInfoX.Step).ToString();
            }
            else
            {
                this.txtXPos.Text = (pulseNumber * this.axisInfoX.MaxLimit / this.axisInfoX.Step).ToString("f2");
            }

            pulseNumber = Global.ControlCard.GetPosition(this.axisInfoZ,true);

            if (pulseNumber * this.axisInfoZ.MaxLimit % this.axisInfoZ.Step == 0)
            {
                this.txtXPos.Text = (pulseNumber * this.axisInfoZ.MaxLimit / this.axisInfoZ.Step).ToString();
            }
            else
            {
                this.txtZPos.Text = (pulseNumber * this.axisInfoZ.MaxLimit / this.axisInfoZ.Step).ToString("f2");
            }
        }

        private void txtXPos_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text == "")
            {
                txt.Text = "0";
            }

            if (txt.Name == "txtXPos")
            {
                this.WorkPosX = txt.Text;
            }
            else
            {
                this.WorkPosY = txt.Text;
            }
        }

        #endregion
    }
}
