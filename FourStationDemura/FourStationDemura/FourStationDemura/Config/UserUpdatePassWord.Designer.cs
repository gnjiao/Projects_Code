namespace FourStationDemura
{
    partial class UserUpdatePassword
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
            this.gbUpdatePassword = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrgPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbUpdatePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUpdatePassword
            // 
            this.gbUpdatePassword.AutoSize = true;
            this.gbUpdatePassword.Controls.Add(this.btnOK);
            this.gbUpdatePassword.Controls.Add(this.btnCancel);
            this.gbUpdatePassword.Controls.Add(this.txtNewPassword);
            this.gbUpdatePassword.Controls.Add(this.label2);
            this.gbUpdatePassword.Controls.Add(this.txtOrgPassword);
            this.gbUpdatePassword.Controls.Add(this.label1);
            this.gbUpdatePassword.Location = new System.Drawing.Point(283, 134);
            this.gbUpdatePassword.Name = "gbUpdatePassword";
            this.gbUpdatePassword.Size = new System.Drawing.Size(449, 307);
            this.gbUpdatePassword.TabIndex = 2;
            this.gbUpdatePassword.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(155, 193);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 40);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(276, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(155, 123);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(211, 25);
            this.txtNewPassword.TabIndex = 9;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "新密码";
            // 
            // txtOrgPassword
            // 
            this.txtOrgPassword.Location = new System.Drawing.Point(155, 74);
            this.txtOrgPassword.Name = "txtOrgPassword";
            this.txtOrgPassword.Size = new System.Drawing.Size(211, 25);
            this.txtOrgPassword.TabIndex = 7;
            this.txtOrgPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "旧密码";
            // 
            // UserUpdatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUpdatePassword);
            this.Name = "UserUpdatePassword";
            this.Size = new System.Drawing.Size(1015, 575);
            this.SizeChanged += new System.EventHandler(this.UserUpdatePassword_SizeChanged);
            this.gbUpdatePassword.ResumeLayout(false);
            this.gbUpdatePassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUpdatePassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrgPassword;
        private System.Windows.Forms.Label label1;
    }
}
