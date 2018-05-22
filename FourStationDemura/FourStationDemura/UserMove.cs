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
    public partial class UserMove : UserControl
    {
        #region 属性

        /// <summary>
        /// 当前选中的轴实体
        /// </summary>
        public List<AxisInfo> listAxisInfo = new List<AxisInfo>();

        #endregion

        #region 构造函数

        public UserMove()
        {
            InitializeComponent();

            try
            {
                Global.IsAllowMoveEvent += Global_IsAllowMoveEvent;

                //BindingSource bs = new BindingSource();
                //bs.DataSource = Global.DictAxis;

                //this.cbbAxis.DisplayMember = "value";
                //this.cbbAxis.ValueMember = "key";
                //this.cbbAxis.DataSource = bs;

                this.cbbAxis.Items.Add("All");

                foreach (var kvp in Global.DictAxis)
                {
                    this.cbbAxis.Items.Add(kvp.Value);
                }
                this.cbbAxis.SelectedIndex = 0;

                this.isEnabled(Global.IsAllowMove);

                this.txtDistance.Focus();
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置运动按钮的可用状态
        /// </summary>
        /// <param name="f"></param>
        public void isEnabled(bool f)
        {
            this.btnGoHome.Enabled = f;
            this.btnLeft.Enabled = f;
            this.btnRight.Enabled = f;
            this.btnUp.Enabled = f;
            this.btnDown.Enabled = f;
            this.cbbAxis.Enabled = f;
        }

        /// <summary>
        /// 获取当前位置并赋值给文本框
        /// </summary>
        public void GetCurrentPosition(AxisInfo axisInfo)
        {
            //获取当前位置
            this.txtCurrentPosition.Text = (axisInfo.Lead / (axisInfo.Step / Global.ControlCard.GetPosition(axisInfo, true))).ToString("f0");
        }

        /// <summary>
        /// 定长运动
        /// </summary>
        /// <param name="axisinfo">轴实体</param>
        /// <param name="moveType">运动方向</param>
        public void Pmove(AxisInfo axisInfo, string moveType)
        {
            //气缸上
            var fRtn = MoveExecute.SetBaffle(true);
            if (!fRtn) return;

            switch (moveType)
            {
                case "正":
                    {
                        //设置移动距离
                        axisInfo.Dist = Convert.ToInt32(Convert.ToInt32(txtDistance.Text) * axisInfo.Step / axisInfo.Lead);

                        if (Global.ControlCard.GetPosition(axisInfo, true) + axisInfo.Dist > axisInfo.Step)
                        {
                            Log.GetInstance().WarningWrite(string.Format("[{0}]轴移动距离超出了物理正极限，自动移动到极限位置"));

                            this.txtDistance.Text = (axisInfo.Lead / (axisInfo.Step / (axisInfo.Step - Global.ControlCard.GetPosition(axisInfo, true)))).ToString("f0");

                            axisInfo.Dist = Convert.ToInt32(Convert.ToInt32(txtDistance.Text) * axisInfo.Step / axisInfo.Lead);
                        }

                        break;
                    }
                case "负":
                    {
                        //设置移动距离
                        axisInfo.Dist = Convert.ToInt32(Convert.ToInt32(txtDistance.Text) * axisInfo.Step / axisInfo.Lead * -1);

                        if (Global.ControlCard.GetPosition(axisInfo, true) - axisInfo.Dist < 0)
                        {
                            Log.GetInstance().WarningWrite(string.Format("[{0}]轴移动距离超出了物理负极限，自动移动到极限位置"));

                            txtDistance.Text = (axisInfo.Lead / (axisInfo.Step / Global.ControlCard.GetPosition(axisInfo, true))).ToString("f0");

                            axisInfo.Dist = Convert.ToInt32(Convert.ToInt32(txtDistance.Text) * axisInfo.Step / axisInfo.Lead * -1);
                        }

                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            axisInfo.PosiMode = 0;
            MoveExecute.Pmove(axisInfo, true);

            //获取当前位置
            this.txtCurrentPosition.Text = (axisInfo.Lead / (axisInfo.Step / Global.ControlCard.GetPosition(axisInfo, true))).ToString("f0");
        }

        #endregion

        #region 事件

        private void UserMove_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 强行启动运动按钮事件
        /// </summary> 
        private void Global_IsAllowMoveEvent()
        {
            this.isEnabled(Global.IsAllowMove);
        }

        /// <summary>
        /// 轴回原点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoHome_Click(object sender, EventArgs e)
        {
            //气缸上
            var fRtn = MoveExecute.SetBaffle(true);
            if (!fRtn) return;

            var tasks = new List<Task>();

            foreach (var axisInfo in this.listAxisInfo)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    MoveExecute.HomeMove(axisInfo, true);
                }));
            }

            Task.WaitAll(tasks.ToArray());

            if (this.listAxisInfo.Count == 1)

                MoveExecute.HomeMove(this.listAxisInfo[0], true);

            //获取当前位置
            this.GetCurrentPosition(this.listAxisInfo[0]);
        }

        /// <summary>
        /// 轴上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.listAxisInfo.Count != 1) return;

            this.Pmove(this.listAxisInfo[0], "负");
        }

        /// <summary>
        /// 轴左移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (this.listAxisInfo.Count != 1) return;

            this.Pmove(this.listAxisInfo[0], "负");
        }

        /// <summary>
        /// 轴右移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (this.listAxisInfo.Count != 1) return;

            this.Pmove(this.listAxisInfo[0], "正");
        }

        /// <summary>
        /// 轴下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.listAxisInfo.Count != 1) return;

            this.Pmove(this.listAxisInfo[0], "正");
        }

        /// <summary>
        /// 只能输入数字、小数点、负号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)46 && e.KeyChar != (char)45 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtDistance_MouseLeave(object sender, EventArgs e)
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

        private void txtDistance_Enter(object sender, EventArgs e)
        {
            this.txtDistance.Tag = true;
            this.txtDistance.SelectAll();
        }

        private void txtDistance_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (bool)this.txtDistance.Tag == true)
            {
                this.txtDistance.SelectAll();
            }

            //取消全选标记              
            this.txtDistance.Tag = false;
        }

        private void cbbAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            var axisName = this.cbbAxis.SelectedItem.ToString();

            if (axisName == "All")
            {
                this.listAxisInfo = Global.ListAxis;

                this.txtCurrentPosition.Text = null;
            }
            else
            {
                var axisInfo = Global.ListAxis.Where(info => info.AxisName == axisName).FirstOrDefault();

                this.listAxisInfo.Clear();
                this.listAxisInfo.Add(axisInfo);

                //获取当前位置
                this.txtCurrentPosition.Text = (axisInfo.Lead / (axisInfo.Step / Global.ControlCard.GetPosition(axisInfo, true))).ToString("f0");
            }
        }

        #endregion
    }
}
