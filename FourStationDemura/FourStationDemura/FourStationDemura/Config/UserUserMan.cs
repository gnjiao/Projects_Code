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
    public partial class UserUserMan : UserControl
    {
        #region 构造函数


        public UserUserMan()
        {
            InitializeComponent();

            this.dgvUser.AllowUserToResizeColumns = false;
            this.dgvUser.AutoGenerateColumns = false;

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

                this.btnSelect_Click(null, null);
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        #endregion

        #region 事件

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dr = Global.DtUser.Select();

                DataView dv = Global.DtUser.DefaultView;

                dv.RowFilter = string.Format("userName<>'admin' and dept like '%{0}%' and userName like '%{1}%'", this.cbbDept.SelectedItem.ToString(), this.txtUser.Text);

                DataTable dt = dv.ToTable();

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataColumn dc = new DataColumn("index", Type.GetType("System.Int32"));
                    dt.Columns.Add(dc);

                    int index = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        index++;
                        row["index"] = index;
                    }
                }

                this.dgvUser.DataSource = dt;
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddUser form = new FormAddUser(true, null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.btnSelect_Click(null, null);

                this.dgvUser.Rows[this.dgvUser.Rows.Count - 1].Selected = true;
            }
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUser.SelectedRows.Count > 0)
                {
                    int index = this.dgvUser.SelectedRows[0].Index;
                    int count = this.dgvUser.Rows.Count;

                    FormAddUser form = new FormAddUser(false, this.dgvUser.SelectedRows[0]);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        this.btnSelect_Click(null, null);

                        if (this.dgvUser.Rows.Count == count)
                        {
                            this.dgvUser.Rows[index].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUser.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("确定要删除此用户吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string id = this.dgvUser.SelectedRows[0].Cells["ID"].Value.ToString();

                        DataRow[] dr = Global.DtUser.Select(string.Format("id = '{0}'", id));

                        foreach (DataRow row in dr)
                        {
                            Global.DtUser.Rows.Remove(row);
                        }

                        if (XmlFile.DeleteXmlNode(Global.UsersConfigPath, id))
                        {
                            this.btnSelect_Click(null, null);
                            MessageBox.Show("删除成功");
                        }
                        else
                        {
                            MessageBox.Show("删除失败");
                        }
                    }
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
