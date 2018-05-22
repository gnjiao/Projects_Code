namespace FourStationDemura
{
    partial class UserAxisWorkPosConfig
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
            this.btnWorkPos = new System.Windows.Forms.Button();
            this.lblWorkPosName = new System.Windows.Forms.Label();
            this.txtWorkPos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnWorkPos
            // 
            this.btnWorkPos.Location = new System.Drawing.Point(207, 0);
            this.btnWorkPos.Name = "btnWorkPos";
            this.btnWorkPos.Size = new System.Drawing.Size(75, 25);
            this.btnWorkPos.TabIndex = 51;
            this.btnWorkPos.Tag = "1";
            this.btnWorkPos.Text = "当前位置";
            this.btnWorkPos.UseVisualStyleBackColor = true;
            this.btnWorkPos.Click += new System.EventHandler(this.btnWorkPos_Click);
            // 
            // lblWorkPosName
            // 
            this.lblWorkPosName.AutoSize = true;
            this.lblWorkPosName.Location = new System.Drawing.Point(12, 5);
            this.lblWorkPosName.Name = "lblWorkPosName";
            this.lblWorkPosName.Size = new System.Drawing.Size(83, 15);
            this.lblWorkPosName.TabIndex = 49;
            this.lblWorkPosName.Text = "工作位置#1";
            this.lblWorkPosName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkPos
            // 
            this.txtWorkPos.Location = new System.Drawing.Point(101, 0);
            this.txtWorkPos.Name = "txtWorkPos";
            this.txtWorkPos.Size = new System.Drawing.Size(100, 25);
            this.txtWorkPos.TabIndex = 50;
            this.txtWorkPos.Text = "0";
            this.txtWorkPos.TextChanged += new System.EventHandler(this.txtWorkPos_TextChanged);
            this.txtWorkPos.Enter += new System.EventHandler(this.txtWorkPos_Enter);
            this.txtWorkPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkPos_KeyPress);
            this.txtWorkPos.MouseLeave += new System.EventHandler(this.txtWorkPos_Leave);
            this.txtWorkPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtWorkPos_MouseUp);
            // 
            // UserAxisWorkPosConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnWorkPos);
            this.Controls.Add(this.lblWorkPosName);
            this.Controls.Add(this.txtWorkPos);
            this.Name = "UserAxisWorkPosConfig";
            this.Size = new System.Drawing.Size(294, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWorkPos;
        private System.Windows.Forms.Label lblWorkPosName;
        private System.Windows.Forms.TextBox txtWorkPos;
    }
}
