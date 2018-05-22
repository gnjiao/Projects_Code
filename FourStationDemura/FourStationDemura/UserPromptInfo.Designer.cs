namespace FourStationDemura
{
    partial class UserPromptInfo
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
            this.gbPanelNumber = new System.Windows.Forms.GroupBox();
            this.pbPrompt = new System.Windows.Forms.PictureBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.gbPanelNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrompt)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPanelNumber
            // 
            this.gbPanelNumber.Controls.Add(this.lblPrompt);
            this.gbPanelNumber.Controls.Add(this.pbPrompt);
            this.gbPanelNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPanelNumber.Location = new System.Drawing.Point(0, 0);
            this.gbPanelNumber.Name = "gbPanelNumber";
            this.gbPanelNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbPanelNumber.Size = new System.Drawing.Size(131, 178);
            this.gbPanelNumber.TabIndex = 0;
            this.gbPanelNumber.TabStop = false;
            this.gbPanelNumber.Text = "#1";
            // 
            // pbPrompt
            // 
            this.pbPrompt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPrompt.Location = new System.Drawing.Point(3, 21);
            this.pbPrompt.Name = "pbPrompt";
            this.pbPrompt.Size = new System.Drawing.Size(125, 125);
            this.pbPrompt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPrompt.TabIndex = 72;
            this.pbPrompt.TabStop = false;
            // 
            // lblPrompt
            // 
            this.lblPrompt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPrompt.Location = new System.Drawing.Point(3, 152);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(125, 23);
            this.lblPrompt.TabIndex = 73;
            this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserPromptInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPanelNumber);
            this.Name = "UserPromptInfo";
            this.Size = new System.Drawing.Size(131, 178);
            this.gbPanelNumber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrompt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPanelNumber;
        private System.Windows.Forms.PictureBox pbPrompt;
        private System.Windows.Forms.Label lblPrompt;
    }
}
