using System;
using System.Collections;
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
    public partial class FormConfig : Form
    {
        #region 属性

        /// <summary>
        /// 用户控件集合
        /// </summary>
        private List<UserControl> listUserControl = null;

        /// <summary>
        /// 参数设置界面
        /// </summary>
        private UserParameterConfig parConfig = null;

        /// <summary>
        /// 运动设置界面
        /// </summary>
        private UserMoveConfig moveConfig = null;

        /// <summary>
        /// IIX设置界面
        /// </summary>
        private UserIIXConfig iixConfig = null;

        /// <summary>
        /// 修改密码界面
        /// </summary>
        private UserUpdatePassword updatePassword = null;

        /// <summary>
        /// 用户管理界面
        /// </summary>
        private UserUserMan userMan = null;

        /// <summary>
        /// 权限管理界面
        /// </summary>
        private UserPermissionMan perMan = null;

        /// <summary>
        /// 画面设置界面
        /// </summary>
        private UserPatternConfig userColorConfig = null;

        #endregion

        #region 构造函数

        public FormConfig()
        {
            InitializeComponent();

            this.listUserControl = new List<UserControl>();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 显示按钮对应打开的用户控件并讲按钮背景设为蓝色
        /// </summary>
        /// <param name="userControl"></param>
        /// <param name="btn"></param>
        public void ShowUserControl(UserControl userControl, object btn)
        {
            foreach (var userCon in this.listUserControl)
            {
                userCon.Visible = false;
            }

            userControl.Visible = true;


            foreach (Control control in this.flpBtn.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = SystemColors.Control;
                }
            }

            ((Button)btn).BackColor = SystemColors.MenuHighlight;
            ((Button)btn).Focus();
        }

        /// <summary>
        /// 根据权限显示功能按钮
        /// </summary>
        public void ShowBtn()
        {
            bool isOpen = false;

            DataRow[] dr = null;
            dr = Global.DtUser.Select(string.Format("id ='{0}'", Global.UserID));

            if (dr.Length > 0)
            {
                string[] permissions = dr[0]["permissions"].ToString().Split(',');

                IList listPermission = (IList)permissions;

                if (listPermission.Contains("参数设置"))
                {
                    if (isOpen == false)
                    {
                        this.btnParameterConfig_Click(this.btnParameterConfig, null);
                        this.btnParameterConfig.Focus();
                        isOpen = true;
                    }

                    this.btnParameterConfig.Visible = true;
                }
                else
                {
                    this.btnParameterConfig.Visible = false;
                }

                if (listPermission.Contains("画面设置"))
                {
                    if (isOpen == false)
                    {
                        this.btnColorConfig_Click(this.btnColorConfig, null);
                        this.btnColorConfig.Focus();
                        isOpen = true;
                    }

                    this.btnColorConfig.Visible = true;
                }
                else
                {
                    this.btnColorConfig.Visible = false;
                }

                if (listPermission.Contains("运动设置"))
                {
                    if (isOpen == false)
                    {
                        this.btnMoveConfig_Click(this.btnMoveConfig, null);
                        this.btnMoveConfig.Focus();
                        isOpen = true;
                    }

                    this.btnMoveConfig.Visible = true;
                }
                else
                {
                    this.btnMoveConfig.Visible = false;
                }

                if (listPermission.Contains("IIX设置"))
                {
                    if (isOpen == false)
                    {
                        this.btnIIXConfig_Click(this.btnIIXConfig, null);
                        this.btnIIXConfig.Focus();
                        isOpen = true;
                    }

                    this.btnIIXConfig.Visible = true;
                }
                else
                {
                    this.btnIIXConfig.Visible = false;
                }

                if (listPermission.Contains("用户管理"))
                {
                    if (isOpen == false)
                    {
                        this.btnUserMan_Click(this.btnUserMan, null);
                        this.btnUserMan.Focus();
                        isOpen = true;
                    }

                    this.btnUserMan.Visible = true;
                }
                else
                {
                    this.btnUserMan.Visible = false;
                }

                if (listPermission.Contains("权限管理"))
                {
                    if (isOpen == false)
                    {
                        this.btnPermissionConfig_Click(this.btnPermissionConfig, null);
                        this.btnPermissionConfig.Focus();
                        isOpen = true;
                    }

                    this.btnPermissionConfig.Visible = true;
                }
                else
                {
                    this.btnPermissionConfig.Visible = false;
                }

                if (listPermission.Contains("修改密码"))
                {
                    if (isOpen == false)
                    {
                        this.btnUpdatePassword_Click(this.btnUpdatePassword, null);
                        this.btnUpdatePassword.Focus();
                        isOpen = true;
                    }

                    this.btnUpdatePassword.Visible = true;
                }
                else
                {
                    this.btnUpdatePassword.Visible = false;
                }
            }
        }

        #endregion

        #region 事件

        private void btnParameterConfig_Click(object sender, EventArgs e)
        {
            if (this.parConfig == null)
            {
                this.parConfig = new UserParameterConfig();
                this.parConfig.Dock = DockStyle.Fill;
                this.pnlUserControl.Controls.Add(this.parConfig);
                this.listUserControl.Add(this.parConfig);
            }

            this.ShowUserControl(this.parConfig, sender);
        }

        private void btnMoveConfig_Click(object sender, EventArgs e)
        {
            if (this.moveConfig == null)
            {
                this.moveConfig = new UserMoveConfig();
                this.moveConfig.Dock = DockStyle.Fill;
                this.pnlUserControl.Controls.Add(this.moveConfig);
                this.listUserControl.Add(this.moveConfig);
            }

            this.ShowUserControl(this.moveConfig, sender);
        }

        private void btnIIXConfig_Click(object sender, EventArgs e)
        {
            if (this.iixConfig == null)
            {
                this.iixConfig = new UserIIXConfig();
                this.iixConfig.Dock = DockStyle.Fill;
                this.pnlUserControl.Controls.Add(this.iixConfig);
                this.listUserControl.Add(this.iixConfig);
            }

            this.ShowUserControl(this.iixConfig, sender);
        }

        private void btnUserMan_Click(object sender, EventArgs e)
        {
            if (this.userMan == null)
            {
                this.userMan = new UserUserMan();
                this.userMan.Dock = DockStyle.Fill;
                this.pnlUserControl.Controls.Add(this.userMan);
                this.listUserControl.Add(this.userMan);
            }

            this.ShowUserControl(this.userMan, sender);
        }

        private void btnPermissionConfig_Click(object sender, EventArgs e)
        {
            if (this.perMan == null)
            {
                this.perMan = new UserPermissionMan();
                this.perMan.Dock = DockStyle.Fill;
                this.pnlUserControl.Controls.Add(this.perMan);
                this.listUserControl.Add(this.perMan);
            }

            this.ShowUserControl(this.perMan, sender);
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (this.updatePassword == null)
            {
                this.updatePassword = new UserUpdatePassword();
                this.updatePassword.Dock = DockStyle.Fill;
                this.pnlUserControl.Controls.Add(this.updatePassword);
                this.listUserControl.Add(this.updatePassword);
            }

            this.ShowUserControl(this.updatePassword, sender);
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            if (Global.WorkNumber == "admin")
            {
                this.btnParameterConfig.Visible = true;
                this.btnColorConfig.Visible = true;
                this.btnMoveConfig.Visible = true;
                this.btnIIXConfig.Visible = true;
                this.btnUserMan.Visible = true;
                this.btnPermissionConfig.Visible = true;
                this.btnUpdatePassword.Visible = true;

                this.btnParameterConfig_Click(this.btnParameterConfig, null);
                this.btnParameterConfig.Focus();
            }
            else
            {
                this.ShowBtn();
            }
        }

        private void btnColorConfig_Click(object sender, EventArgs e)
        {
            if (this.userColorConfig == null)
            {
                this.userColorConfig = new UserPatternConfig();
                this.userColorConfig.Dock = DockStyle.Fill;
                this.pnlUserControl.Controls.Add(this.userColorConfig);
                this.listUserControl.Add(this.userColorConfig);
            }

            this.ShowUserControl(this.userColorConfig, sender);
        }

        #endregion
    }
}
