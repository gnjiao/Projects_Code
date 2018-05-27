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
    public partial class UserUpdatePassword : UserControl
    {
        #region 构造函数

        public UserUpdatePassword()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        private void UserUpdatePassword_SizeChanged(object sender, EventArgs e)
        {
            int x = (this.Width - this.gbUpdatePassword.Width) / 2;
            int y = (this.Height - this.gbUpdatePassword.Height) / 2;

            this.gbUpdatePassword.Location = new Point(x, y);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtOrgPassword.Text.Trim() == "")
                {
                    MessageBox.Show("旧密码不能为空，请输入。");
                    this.txtOrgPassword.Focus();
                    return;
                }

                if (this.txtNewPassword.Text.Trim() == "")
                {
                    MessageBox.Show("新密码不能为空，请输入。");
                    this.txtNewPassword.Focus();
                    return;
                }

                if (this.txtOrgPassword.Text != Global.Password)
                {
                    MessageBox.Show("旧密码输入错误");
                    this.txtOrgPassword.Text = "";
                    this.txtOrgPassword.Focus();
                    return;
                }

                if (MessageBox.Show("确定修改密码吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Dictionary<string, string> dictAttribute = new Dictionary<string, string>();

                    dictAttribute.Add("password", this.txtNewPassword.Text);

                    var userID = Global.UserID;

                    if (XmlFile.UpdateXmlNode(Global.UsersConfigPath, userID, dictAttribute))
                    {
                        Global.Password = this.txtNewPassword.Text;
                        this.txtNewPassword.Text = "";
                        this.txtOrgPassword.Text = "";
                        MessageBox.Show("修改成功。");
                    }
                    else
                    {
                        MessageBox.Show("修改失败。");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtNewPassword.Text = "";
            this.txtOrgPassword.Text = "";
        }

        #endregion
    }
}
