namespace FourStationDemura
{
    partial class UserPermissionMan
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tvUser = new System.Windows.Forms.TreeView();
            this.tvPermission = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 118);
            this.panel1.TabIndex = 0;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(687, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 47);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(842, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 47);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tvUser
            // 
            this.tvUser.CheckBoxes = true;
            this.tvUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvUser.Location = new System.Drawing.Point(0, 0);
            this.tvUser.Name = "tvUser";
            this.tvUser.Size = new System.Drawing.Size(507, 457);
            this.tvUser.TabIndex = 1;
            this.tvUser.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvUser_AfterCheck);
            // 
            // tvPermission
            // 
            this.tvPermission.CheckBoxes = true;
            this.tvPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermission.Location = new System.Drawing.Point(507, 0);
            this.tvPermission.Name = "tvPermission";
            this.tvPermission.Size = new System.Drawing.Size(508, 457);
            this.tvPermission.TabIndex = 2;
            this.tvPermission.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermission_AfterCheck);
            // 
            // UserPermissionMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvPermission);
            this.Controls.Add(this.tvUser);
            this.Controls.Add(this.panel1);
            this.Name = "UserPermissionMan";
            this.Size = new System.Drawing.Size(1015, 575);
            this.Load += new System.EventHandler(this.UserPermissionMan_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvUser;
        private System.Windows.Forms.TreeView tvPermission;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
