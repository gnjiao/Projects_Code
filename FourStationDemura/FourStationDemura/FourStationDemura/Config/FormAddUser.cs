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
    public partial class FormAddUser : Form
    {
        #region 属性

        /// <summary>
        /// 是否为添加用户
        /// </summary>
        private bool isAdd = false;

        /// <summary>
        /// 修改用户时选中的用户数据
        /// </summary>
        private DataGridViewRow dgvRow = null;

        #endregion

        #region 构造函数

        public FormAddUser()
        {
            InitializeComponent();
        }

        public FormAddUser(bool isAdd, DataGridViewRow dgvRow)
        {
            InitializeComponent();

            this.isAdd = isAdd;
            this.dgvRow = dgvRow;
        }

        #endregion

        #region 事件

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtWorkNumber.Text.Trim() == "")
                {
                    MessageBox.Show("工号不能为空，请输入。");
                    this.txtWorkNumber.Focus();
                    return;
                }

                if (this.txtWorkNumber.Text.ToLower() == "admin")
                {
                    MessageBox.Show("工号不能为[admin]，请重新输入。");
                    this.txtWorkNumber.Text = "";
                    this.txtWorkNumber.Focus();
                    return;
                }

                if (this.txtName.Text.Trim() == "")
                {
                    MessageBox.Show("姓名不能为空，请输入。");
                    this.txtName.Focus();
                    return;
                }

                if (this.txtName.Text.ToLower() == "admin")
                {
                    MessageBox.Show("姓名不能为[admin]，请重新输入。");
                    this.txtName.Text = "";
                    this.txtName.Focus();
                    return;
                }

                var userName = this.txtName.Text;
                var workNumber = this.txtWorkNumber.Text;
                var dept = this.cbbDept.SelectedIndex != -1 ? this.cbbDept.SelectedItem.ToString() : "";

                if (this.isAdd)
                {
                    DataRow[] row = Global.DtUser.Select(string.Format("workNumber = '{0}'", this.txtWorkNumber.Text));

                    if (row.Length > 0)
                    {
                        MessageBox.Show("此工号已经存在，请重新输入。");
                        this.txtWorkNumber.Text = "";
                        this.txtWorkNumber.Focus();
                        return;
                    }

                    var id = Guid.NewGuid().ToString();

                    DataRow dr = Global.DtUser.NewRow();
                    dr["id"] = id;
                    dr["userName"] = this.txtName.Text;
                    dr["workNumber"] = this.txtWorkNumber.Text;
                    dr["dept"] = this.cbbDept.SelectedItem.ToString();
                    dr["password"] = "123456";
                    dr["permissions"] = "";

                    Global.DtUser.Rows.Add(dr);

                    if (XmlFile.AddXmlNode(Global.UsersConfigPath, dr))
                    {
                        MessageBox.Show("添加成功。");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("添加失败。");
                    }
                }
                else
                {
                    var id = this.dgvRow.Cells["id"].Value.ToString();

                    DataRow[] dr = Global.DtUser.Select(string.Format("id = '{0}'", id));

                    if (dr.Length > 0)
                    {
                        dr[0]["userName"] = this.txtName.Text;
                        dr[0]["workNumber"] = this.txtWorkNumber.Text;
                        dr[0]["dept"] = this.cbbDept.SelectedItem.ToString();
                    }

                    Dictionary<string, string> dictAttribute = new Dictionary<string, string>();

                    dictAttribute.Add("dept", dr[0]["dept"].ToString());
                    dictAttribute.Add("userName", dr[0]["userName"].ToString());

                    var userID = dr[0]["id"].ToString();

                    if (XmlFile.UpdateXmlNode(Global.UsersConfigPath, userID, dictAttribute))
                    {
                        MessageBox.Show("修改成功。");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            try
            {
                if (Global.DictDept.Count > 0)
                {
                    foreach (var kvp in Global.DictDept)
                    {
                        this.cbbDept.Items.Add(kvp.Value);
                    }

                    this.cbbDept.SelectedIndex = 0;
                }
                else
                {
                    this.cbbDept.SelectedIndex = -1;
                }

                if (this.isAdd)
                {
                    this.Text = "添加用户信息";
                    this.txtWorkNumber.Focus();
                }
                else
                {
                    this.Text = "修改用户信息";

                    this.txtName.Focus();
                    this.txtWorkNumber.Text = this.dgvRow.Cells["workNumber"].Value.ToString();
                    this.txtWorkNumber.Enabled = false;
                    this.txtName.Text = this.dgvRow.Cells["userName"].Value.ToString();
                    this.cbbDept.SelectedItem = this.dgvRow.Cells["dept"].ToString();
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        #endregion
    }
}
