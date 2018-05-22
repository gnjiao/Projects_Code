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
    public partial class UserPromptInfo : UserControl
    {
        #region 属性

        /// <summary>
        /// 屏幕编号
        /// </summary>
        public string PanelNumber { get; set; }

        #endregion

        #region 构造函数

        public UserPromptInfo()
        {
            InitializeComponent();
        }

        public UserPromptInfo(string panelNumber)
        {
            InitializeComponent();

            this.gbPanelNumber.Text = panelNumber;
            this.PanelNumber = panelNumber;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置提示信息
        /// </summary>
        /// <param name="img"></param>
        /// <param name="promptInfo"></param>
        public void SetPromptInfo(Image img = null, string content = null)
        {
            if (img != null)
            {
                this.pbPrompt.Image = img;
            }

            if (content != null)
            {
                this.lblPrompt.Text = content;
            }
        }

        #endregion
    }
}
