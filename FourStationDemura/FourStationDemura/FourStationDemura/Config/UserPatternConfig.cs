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
    public partial class UserPatternConfig : UserControl
    {
        #region 属性

        /// <summary>
        /// 添加的Pattern集合
        /// </summary>
        private List<UserPattern> listPattern = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数，这里做Load处理，之所以不用Load事件，是因为当窗体隐藏后再打开又会进入Load事件
        /// </summary>
        public UserPatternConfig()
        {
            InitializeComponent();

            try
            {
                this.listPattern = new List<UserPattern>();
                this.Init();

                for (int i = 0; i <= Global.PatternNumber; i++)
                {
                    this.cbbPatternNumber.Items.Add(i);
                }

                if (this.listPattern.Count == 0)
                {
                    if (Global.PatternNumber >= 6)
                    {
                        this.cbbPatternNumber.SelectedItem = 6;
                    }
                    else if (Global.PatternNumber > 0)
                    {
                        this.cbbPatternNumber.SelectedItem = Global.PatternNumber;
                    }
                }
                else
                {
                    this.cbbPatternNumber.SelectedItem = this.listPattern.Count;
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化Pattern
        /// </summary>
        public void Init()
        {
            try
            {
                UserPattern usserPattern = null;

                for (int i = 1; i <= Global.PatternNumber; i++)
                {
                    //判断Pattern是否启用
                    if (IniFile.IniReadValue("Pattern" + i, "Enabled", Global.ProductSettingPath) == "1")
                    {
                        usserPattern = new UserPattern();
                        usserPattern.SetGbText("Pattern" + i);
                        usserPattern.SetPattern();
                        this.listPattern.Add(usserPattern);
                        this.flpPattern.Controls.Add(usserPattern);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        #endregion

        #region 事件

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bool f = false;

            try
            {
                this.listPattern.Clear();
                this.flpPattern.Controls.Clear();
                this.Init();

                if (this.listPattern.Count == 0)
                {
                    if (Global.PatternNumber >= 6)
                    {
                        this.cbbPatternNumber.SelectedItem = 6;
                    }
                    else if (Global.PatternNumber > 0)
                    {
                        this.cbbPatternNumber.SelectedItem = Global.PatternNumber;
                    }
                }
                else
                {
                    this.cbbPatternNumber.SelectedItem = this.listPattern.Count;
                }

                f = true;
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            if (f)
            {
                MessageBox.Show("还原成功。");
            }
            else
            {
                MessageBox.Show("还原失败。");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool f = false;
            try
            {
                foreach (Control control in this.flpPattern.Controls)
                {
                    if (control is UserPattern)
                    {
                        ((UserPattern)control).SavePattern();
                    }
                }

                for (int i = this.listPattern.Count + 1; i <= Global.PatternNumber; i++)
                {
                    IniFile.IniWriteValue("Pattern" + i, "Enabled", "0", Global.ProductSettingPath);
                    IniFile.IniWriteValue("Pattern" + i, "R", "0", Global.ProductSettingPath);
                    IniFile.IniWriteValue("Pattern" + i, "G", "0", Global.ProductSettingPath);
                    IniFile.IniWriteValue("Pattern" + i, "B", "0", Global.ProductSettingPath);

                    if (IniFile.IniReadValue("Pattern" + i, "SleepTime", Global.ProductSettingPath) != "")
                    {
                        IniFile.IniWriteValue("Pattern" + i, "SleepTime", "0", Global.ProductSettingPath);
                    }
                    else
                    {
                        IniFile.IniWriteValue("Pattern" + i, "SleepTime", "0\r\n", Global.ProductSettingPath);
                    }
                }

                f = true;
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            if (f)
            {
                MessageBox.Show("保存成功。");
            }
            else
            {
                MessageBox.Show("保存失败。");
            }
        }

        private void cbbPatternNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int patternNumber = Convert.ToInt32(this.cbbPatternNumber.SelectedItem);

            //此时需要减少Pattern
            if (this.listPattern.Count > patternNumber)
            {
                for (int i = this.listPattern.Count - 1; i >= 0; i--)
                {
                    if ((i + 1) > patternNumber)
                    {
                        //从界面上移除
                        if (this.flpPattern.Contains(this.listPattern[i]))
                        {
                            this.flpPattern.Controls.Remove(this.listPattern[i]);
                        }

                        //从集合中移除
                        if (this.listPattern.Contains(this.listPattern[i]))
                        {
                            this.listPattern.Remove(this.listPattern[i]);
                        }
                    }
                }
            }
            ////此时需要添加Pattern
            else
            {
                UserPattern usserPattern = null;

                int index = patternNumber - this.listPattern.Count;

                for (int i = 0; i < index; i++)
                {
                    usserPattern = new UserPattern();
                    usserPattern.SetGbText("Pattern" + (this.listPattern.Count + 1));
                    this.listPattern.Add(usserPattern);
                    this.flpPattern.Controls.Add(usserPattern);
                }
            }
        }

        #endregion
    }
}
