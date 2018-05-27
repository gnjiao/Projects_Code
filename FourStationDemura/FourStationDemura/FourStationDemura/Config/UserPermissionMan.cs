using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace FourStationDemura
{
    public partial class UserPermissionMan : UserControl
    {
        #region 属性

        /// <summary>
        /// 权限信息表
        /// </summary>
        private DataTable dtPermission = null;

        /// <summary>
        /// 选中的用户ID集合
        /// </summary>
        private List<string> listUserID = new List<string>();

        /// <summary>
        /// 选中的权限集合
        /// </summary>
        private List<string> listPermission = new List<string>();

        #endregion

        #region 构造函数

        public UserPermissionMan()
        {
            InitializeComponent();

            try
            {
                this.tvPermission.Nodes.Clear();
                this.tvUser.Nodes.Clear();

                string permissionPath = Application.StartupPath + "\\Permission.xml";
                this.dtPermission = XmlFile.XmlToDataTable(permissionPath);

                TreeNode node = new TreeNode();
                node.Text = "权限";
                node.Checked = false;
                this.tvPermission.Nodes.Add(node);
                this.InitPermissionNode(node, "0");

                node = new TreeNode();
                node.Text = "用户";
                node.Checked = false;
                this.tvUser.Nodes.Add(node);

                this.InitUserNode(node, "");

                TreeNode childNode = null;
                foreach (var kvp in Global.DictDept)
                {
                    childNode = new TreeNode();
                    childNode.Text = kvp.Value;
                    childNode.Checked = false;
                    node.Nodes.Add(childNode);

                    this.InitUserNode(childNode, kvp.Value);
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
        /// 加载用户节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="dept"></param>
        public void InitUserNode(TreeNode node, string dept)
        {
            DataRow[] dr = Global.DtUser.Select(string.Format("dept='{0}'", dept));

            TreeNode childNode = null;

            foreach (var row in dr)
            {
                childNode = new TreeNode();
                childNode.Text = row["userName"].ToString();
                childNode.Tag = row["id"].ToString();
                childNode.Checked = false;

                node.Nodes.Add(childNode);
            }
        }

        /// <summary>
        /// 加载权限节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parentId"></param>
        public void InitPermissionNode(TreeNode node, string parentId)
        {
            DataRow[] dr = this.dtPermission.Select(string.Format("parentId='{0}'", parentId));

            TreeNode childNode = null;

            foreach (var row in dr)
            {
                childNode = new TreeNode();
                childNode.Text = row["permissionName"].ToString();
                childNode.Tag = row["id"].ToString();
                childNode.Checked = false;

                node.Nodes.Add(childNode);

                this.InitPermissionNode(childNode, row["id"].ToString());
            }
        }

        /// <summary>
        /// 循环遍历选中用户授权了的权限名称
        /// </summary>
        /// <param name="node"></param>
        /// <param name="permissions"></param>
        public void CheckedPermission(TreeNode node, string[] permissions)
        {
            try
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    if (childNode.Tag == null)
                    {
                        childNode.Checked = false;
                    }
                    else
                    {
                        if (((IList)permissions).Contains(childNode.Text))
                        {
                            childNode.Checked = true;
                        }
                        else
                        {
                            childNode.Checked = false;
                        }
                    }

                    this.CheckedPermission(childNode, permissions);
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        /// <summary>
        /// 取消节点选中状态之后，取消所有父节点的选中状态
        /// </summary>
        /// <param name="currNode"></param>
        /// <param name="state"></param>
        private void SetParentNodeCheckedState(TreeNode currNode, bool state)
        {
            if (currNode.Parent.Checked != state)
            {
                currNode.Parent.Checked = state;
            }

            if (currNode.Parent.Parent != null)
            {
                this.SetParentNodeCheckedState(currNode.Parent, state);
            }
        }

        /// <summary>
        /// 选中节点之后，选中节点的所有子节点
        /// </summary>
        /// <param name="currNode"></param>
        /// <param name="state"></param>
        private void SetChildNodeCheckedState(TreeNode currNode, bool state)
        {
            if (currNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in currNode.Nodes)
                {
                    if (node.Checked != state)
                    {
                        node.Checked = state;
                    }

                    this.SetChildNodeCheckedState(node, state);
                }
            }
        }

        #endregion

        #region 事件

        private void UserPermissionMan_Load(object sender, EventArgs e)
        {
            this.tvPermission.ExpandAll();
            this.tvUser.ExpandAll();
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            this.tvUser.Width = this.tvPermission.Width = this.Width / 2;
        }

        private void tvUser_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByMouse)
                {
                    if (e.Node.Checked == true)
                    {
                        //选中节点之后，选中该节点所有的子节点
                        this.SetChildNodeCheckedState(e.Node, true);
                    }
                    else if (e.Node.Checked == false)
                    {
                        //取消节点选中状态之后，取消该节点所有子节点选中状态
                        this.SetChildNodeCheckedState(e.Node, false);
                        //如果节点存在父节点，取消父节点的选中状态
                        if (e.Node.Parent != null)
                        {
                            this.SetParentNodeCheckedState(e.Node, false);
                        }
                    }
                }

                if (e.Node.Tag != null)
                {
                    if (e.Node.Checked && !this.listUserID.Contains(e.Node.Tag.ToString()))
                    {
                        this.listUserID.Add(e.Node.Tag.ToString());
                    }
                    else if (!e.Node.Checked)
                    {
                        this.listUserID.Remove(e.Node.Tag.ToString());
                    }
                }

                if (this.listUserID.Count == 1)
                {
                    DataRow[] dr = Global.DtUser.Select(string.Format("id = '{0}'", this.listUserID[0]));

                    string[] permissions = dr[0]["permissions"].ToString().Split(',');

                    foreach (TreeNode node in this.tvPermission.Nodes)
                    {
                        if (node.Tag == null)
                        {
                            node.Checked = false;
                        }
                        else
                        {
                            if (((IList)permissions).Contains(node.Text))
                            {
                                node.Checked = true;
                            }
                            else
                            {
                                node.Checked = false;
                            }
                        }

                        this.CheckedPermission(node, permissions);
                    }
                }
                else
                {
                    foreach (TreeNode node in this.tvPermission.Nodes)
                    {
                        node.Checked = false;
                        //取消节点选中状态之后，取消该节点所有子节点选中状态
                        this.SetChildNodeCheckedState(node, false);
                    }
                }

                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        private void tvPermission_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Checked && !this.listPermission.Contains(e.Node.Text))
                {
                    this.listPermission.Add(e.Node.Text);
                }
                else if (!e.Node.Checked)
                {
                    this.listPermission.Remove(e.Node.Text);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TreeNode node in this.tvUser.Nodes)
                {
                    node.Checked = false;
                    this.SetChildNodeCheckedState(node, false);
                }

                foreach (TreeNode node in this.tvPermission.Nodes)
                {
                    node.Checked = false;
                    this.SetChildNodeCheckedState(node, false);
                }
            }
            catch (Exception ex)
            {
                Log.WriterExceptionLog(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listPermission.Count == 0 || this.listUserID.Count == 0) return;

                string permissions = "";
                int number = 0;

                Dictionary<string, string> dictAttribute = new Dictionary<string, string>();

                foreach (var permission in this.listPermission)
                {
                    permissions += permission + ",";
                }

                dictAttribute.Add("permissions", permissions.Substring(0, permissions.Length - 1));

                foreach (var userID in this.listUserID)
                {
                    if (XmlFile.UpdateXmlNode(Global.UsersConfigPath, userID, dictAttribute))
                    {
                        number++;
                    }
                }

                if (number == this.listUserID.Count)
                {
                    MessageBox.Show("保存成功。");
                }
                else
                {
                    dictAttribute.Clear();

                    dictAttribute.Add("permissions", "");

                    foreach (var userID in this.listUserID)
                    {
                        XmlFile.UpdateXmlNode(Global.UsersConfigPath, userID, dictAttribute);
                    }

                    MessageBox.Show("保存失败。");
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
