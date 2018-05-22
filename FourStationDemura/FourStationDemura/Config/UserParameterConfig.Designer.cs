namespace FourStationDemura
{
    partial class UserParameterConfig
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
            this.gbParameterConfig = new System.Windows.Forms.GroupBox();
            this.cbbProductName = new System.Windows.Forms.ComboBox();
            this.ckbAllowMovement = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbParameterConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbParameterConfig
            // 
            this.gbParameterConfig.AutoSize = true;
            this.gbParameterConfig.Controls.Add(this.cbbProductName);
            this.gbParameterConfig.Controls.Add(this.ckbAllowMovement);
            this.gbParameterConfig.Controls.Add(this.label1);
            this.gbParameterConfig.Location = new System.Drawing.Point(68, 206);
            this.gbParameterConfig.Name = "gbParameterConfig";
            this.gbParameterConfig.Size = new System.Drawing.Size(879, 162);
            this.gbParameterConfig.TabIndex = 32;
            this.gbParameterConfig.TabStop = false;
            // 
            // cbbProductName
            // 
            this.cbbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProductName.FormattingEnabled = true;
            this.cbbProductName.Location = new System.Drawing.Point(231, 70);
            this.cbbProductName.Margin = new System.Windows.Forms.Padding(1);
            this.cbbProductName.Name = "cbbProductName";
            this.cbbProductName.Size = new System.Drawing.Size(201, 23);
            this.cbbProductName.TabIndex = 22;
            this.cbbProductName.SelectedIndexChanged += new System.EventHandler(this.cbbProductName_SelectedIndexChanged);
            // 
            // ckbAllowMovement
            // 
            this.ckbAllowMovement.AutoSize = true;
            this.ckbAllowMovement.Location = new System.Drawing.Point(569, 70);
            this.ckbAllowMovement.Name = "ckbAllowMovement";
            this.ckbAllowMovement.Size = new System.Drawing.Size(149, 19);
            this.ckbAllowMovement.TabIndex = 32;
            this.ckbAllowMovement.Text = "启动运动按钮功能";
            this.ckbAllowMovement.UseVisualStyleBackColor = true;
            this.ckbAllowMovement.CheckedChanged += new System.EventHandler(this.ckbAllowMovement_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "选择项目";
            // 
            // UserParameterConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbParameterConfig);
            this.Name = "UserParameterConfig";
            this.Size = new System.Drawing.Size(1015, 575);
            this.SizeChanged += new System.EventHandler(this.UserParameterConfig_SizeChanged);
            this.gbParameterConfig.ResumeLayout(false);
            this.gbParameterConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParameterConfig;
        private System.Windows.Forms.ComboBox cbbProductName;
        private System.Windows.Forms.CheckBox ckbAllowMovement;
        private System.Windows.Forms.Label label1;
    }
}
