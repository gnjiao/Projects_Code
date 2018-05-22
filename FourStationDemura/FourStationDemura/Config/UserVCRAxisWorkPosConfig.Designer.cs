namespace FourStationDemura
{
    partial class UserVCRAxisWorkPosConfig
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
            this.gbWorkPosName = new System.Windows.Forms.GroupBox();
            this.btnVCRPos = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtZPos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.gbWorkPosName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbWorkPosName
            // 
            this.gbWorkPosName.Controls.Add(this.btnVCRPos);
            this.gbWorkPosName.Controls.Add(this.label8);
            this.gbWorkPosName.Controls.Add(this.txtZPos);
            this.gbWorkPosName.Controls.Add(this.label6);
            this.gbWorkPosName.Controls.Add(this.txtXPos);
            this.gbWorkPosName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbWorkPosName.Location = new System.Drawing.Point(0, 0);
            this.gbWorkPosName.Name = "gbWorkPosName";
            this.gbWorkPosName.Size = new System.Drawing.Size(300, 70);
            this.gbWorkPosName.TabIndex = 1;
            this.gbWorkPosName.TabStop = false;
            this.gbWorkPosName.Text = "工作位置#1";
            // 
            // btnVCRPos
            // 
            this.btnVCRPos.Location = new System.Drawing.Point(215, 28);
            this.btnVCRPos.Name = "btnVCRPos";
            this.btnVCRPos.Size = new System.Drawing.Size(75, 25);
            this.btnVCRPos.TabIndex = 58;
            this.btnVCRPos.Tag = "8,9";
            this.btnVCRPos.Text = "当前位置";
            this.btnVCRPos.UseVisualStyleBackColor = true;
            this.btnVCRPos.Click += new System.EventHandler(this.btnVCRPos_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 42;
            this.label8.Text = "Z";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtZPos
            // 
            this.txtZPos.Location = new System.Drawing.Point(137, 28);
            this.txtZPos.Name = "txtZPos";
            this.txtZPos.Size = new System.Drawing.Size(62, 25);
            this.txtZPos.TabIndex = 43;
            this.txtZPos.Text = "0";
            this.txtZPos.TextChanged += new System.EventHandler(this.txtXPos_TextChanged);
            this.txtZPos.Enter += new System.EventHandler(this.txtWorkPos_Enter);
            this.txtZPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkPos_KeyPress);
            this.txtZPos.MouseLeave += new System.EventHandler(this.txtWorkPos_Leave);
            this.txtZPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtWorkPos_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "X";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtXPos
            // 
            this.txtXPos.Location = new System.Drawing.Point(35, 28);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.Size = new System.Drawing.Size(62, 25);
            this.txtXPos.TabIndex = 42;
            this.txtXPos.Text = "0";
            this.txtXPos.TextChanged += new System.EventHandler(this.txtXPos_TextChanged);
            this.txtXPos.Enter += new System.EventHandler(this.txtWorkPos_Enter);
            this.txtXPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkPos_KeyPress);
            this.txtXPos.MouseLeave += new System.EventHandler(this.txtWorkPos_Leave);
            this.txtXPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtWorkPos_MouseUp);
            // 
            // UserVCRAxisWorkPosConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbWorkPosName);
            this.Name = "UserVCRAxisWorkPosConfig";
            this.Size = new System.Drawing.Size(300, 70);
            this.gbWorkPosName.ResumeLayout(false);
            this.gbWorkPosName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbWorkPosName;
        private System.Windows.Forms.Button btnVCRPos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtZPos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtXPos;
    }
}
