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
    public partial class UserPattern : UserControl
    {
        #region 构造函数

        public UserPattern()
        {
            InitializeComponent();

            Color color = Color.FromArgb(Convert.ToInt32(this.txtR.Text), Convert.ToInt32(this.txtG.Text), Convert.ToInt32(this.txtB.Text));

            this.pnlColor.BackColor = color;
        }

        #endregion

        #region 方法

        public void SetGbText(string gbText)
        {
            this.gbPattern.Text = gbText;
        }

        public void SetPattern()
        {
            this.txtR.Text = IniFile.IniReadValue(this.gbPattern.Text, "R", Global.ProductSettingPath);
            this.txtG.Text = IniFile.IniReadValue(this.gbPattern.Text, "G", Global.ProductSettingPath);
            this.txtB.Text = IniFile.IniReadValue(this.gbPattern.Text, "B", Global.ProductSettingPath);
            this.txtSleepTime.Text = IniFile.IniReadValue(this.gbPattern.Text, "SleepTime", Global.ProductSettingPath);
        }

        /// <summary>
        /// 将参数保存到文件
        /// </summary>
        public void SavePattern()
        {
            IniFile.IniWriteValue(this.gbPattern.Text, "Enabled", "1", Global.ProductSettingPath);
            IniFile.IniWriteValue(this.gbPattern.Text, "R", this.txtR.Text, Global.ProductSettingPath);
            IniFile.IniWriteValue(this.gbPattern.Text, "G", this.txtG.Text, Global.ProductSettingPath);
            IniFile.IniWriteValue(this.gbPattern.Text, "B", this.txtB.Text, Global.ProductSettingPath);

            if (IniFile.IniReadValue(this.gbPattern.Text, "SleepTime", Global.ProductSettingPath) != "")
            {
                IniFile.IniWriteValue(this.gbPattern.Text, "SleepTime", this.txtSleepTime.Text, Global.ProductSettingPath);
            }
            else
            {
                IniFile.IniWriteValue(this.gbPattern.Text, "SleepTime", this.txtSleepTime.Text + "\r\n", Global.ProductSettingPath);
            }
        }

        public void DeletePattern()
        {
            IniFile.IniWriteValue(this.gbPattern.Text, null, null, Global.ProductSettingPath);
        }

        #endregion

        #region 事件


        /// <summary>
        /// 重绘控件边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gbPattern_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Black, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Black, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Black, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Black, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Black, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Black, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (txtBox.Text == "")
            {
                txtBox.Text = "0";
            }
            else
            {
                txtBox.Text = Convert.ToInt32(txtBox.Text).ToString();

                if (txtBox.Name != "txtSleepTime")
                {
                    if (Convert.ToInt32(txtBox.Text) > 255)
                    {
                        txtBox.Text = "255";
                    }
                }
            }
        }

        private void txt_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (e.Button == MouseButtons.Left && (bool)txtBox.Tag == true)
            {
                txtBox.SelectAll();
            }

            //取消全选标记              
            txtBox.Tag = false;
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            txtBox.Tag = true;
            txtBox.SelectAll();
        }

        /// <summary>
        /// 根据输入的RGB数据生成相应的颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtR_TextChanged(object sender, EventArgs e)
        {
            if (this.txtR.Text == "" || this.txtG.Text == "" || this.txtB.Text == "") return;

            if (Convert.ToInt32(this.txtR.Text) > 255 || Convert.ToInt32(this.txtG.Text) > 255 || Convert.ToInt32(this.txtB.Text) > 255) return;

            Color color = Color.FromArgb(Convert.ToInt32(this.txtR.Text), Convert.ToInt32(this.txtG.Text), Convert.ToInt32(this.txtB.Text));

            this.pnlColor.BackColor = color;
        }

        #endregion
    }
}
