using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    public partial class FormImageColor : Form
    {
        #region 属性

        private Color color;
        public Color Color { get { return color; } }

        private bool isFactory = false;

        public bool IsFactory { get { return IsFactory; } }

        #endregion

        #region 构造函数

        public FormImageColor()
        {
            InitializeComponent();
            this.ShowColor();
            this.ckbMonoColor.Checked = true;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 显示颜色
        /// </summary>
        public void ShowColor()
        {
            this.color = Color.FromArgb(this.tbRed.Value, this.tbGreen.Value, this.tbBlue.Value);

            this.pnlColor.BackColor = color;
        }

        /// <summary>
        /// 清空所有绑定的数据
        /// </summary>
        private void ClearAllColorBindings()
        {
            this.tbRed.DataBindings.Clear();
            this.nudRed.DataBindings.Clear();
            this.tbGreen.DataBindings.Clear();
            this.nudGreen.DataBindings.Clear();
            this.tbBlue.DataBindings.Clear();
            this.nudBlue.DataBindings.Clear();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void SetBindSeparateColor(bool isMonoColor)
        {
            if (isMonoColor)
            {
                int ave = (tbRed.Value + tbGreen.Value + tbBlue.Value) / 3;

                this.tbRed.DataBindings.Add(new Binding("Value", this.nudRed, "Value"));
                this.nudRed.DataBindings.Add(new Binding("Value", this.tbGreen, "Value"));

                this.tbGreen.DataBindings.Add(new Binding("Value", this.nudGreen, "Value"));
                this.nudGreen.DataBindings.Add(new Binding("Value", this.tbBlue, "Value"));

                this.tbBlue.DataBindings.Add(new Binding("Value", this.nudBlue, "Value"));
                this.nudBlue.DataBindings.Add(new Binding("Value", this.tbRed, "Value"));

                this.tbRed.Value = ave;
            }
            else
            {
                this.tbRed.DataBindings.Add(new Binding("Value", this.nudRed, "Value"));
                this.nudRed.DataBindings.Add(new Binding("Value", this.tbRed, "Value"));

                this.tbGreen.DataBindings.Add(new Binding("Value", this.nudGreen, "Value"));
                this.nudGreen.DataBindings.Add(new Binding("Value", this.tbGreen, "Value"));

                this.tbBlue.DataBindings.Add(new Binding("Value", this.nudBlue, "Value"));
                this.nudBlue.DataBindings.Add(new Binding("Value", this.tbBlue, "Value"));
            }
        }

        #endregion

        #region 事件

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.isFactory = this.ckbFactoryMode.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ckbMonoColor_CheckedChanged(object sender, EventArgs e)
        {
            this.ClearAllColorBindings();

            if (!this.ckbMonoColor.Checked)
            {
                this.SetBindSeparateColor(false);
            }
            else
            {
                this.SetBindSeparateColor(true);
            }
        }

        private void tbRed_ValueChanged(object sender, EventArgs e)
        {
            this.ShowColor();
        }

        #endregion
    }
}
