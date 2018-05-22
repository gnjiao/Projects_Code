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
    public partial class FormLogIn : Form
    {
        #region 构造函数

        public FormLogIn()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text == "")
            {
                MessageBox.Show("用户名不能为空，请输入");
                this.txtUserName.Focus();
                return;
            }

            if (this.txtPassword.Text == "")
            {
                MessageBox.Show("密码不能为空，请输入");
                this.txtPassword.Focus();
                return;
            }

            DataRow[] dr = Global.DtUser.Select(string.Format("workNumber='{0}' and password='{1}'", this.txtUserName.Text, this.txtPassword.Text));

            if (dr.Length > 0)
            {
                Global.UserID = dr[0]["id"].ToString();
                Global.WorkNumber = this.txtUserName.Text;
                Global.Password = this.txtPassword.Text;

                this.Hide();
                FormDemuraMan form = new FormDemuraMan();
                form.ShowDialog();
                Application.ExitThread();
            }
            else
            {
                MessageBox.Show("登入失败，请重新输入。");
                this.txtUserName.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogIn_Click(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
