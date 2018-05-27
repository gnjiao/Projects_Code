namespace FourStationDemura
{
    partial class UserPatternConfig
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
            this.cbbPatternNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flpPattern = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.cbbPatternNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(693, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 47);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(848, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 47);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "还原";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbbPatternNumber
            // 
            this.cbbPatternNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPatternNumber.FormattingEnabled = true;
            this.cbbPatternNumber.Location = new System.Drawing.Point(182, 37);
            this.cbbPatternNumber.Name = "cbbPatternNumber";
            this.cbbPatternNumber.Size = new System.Drawing.Size(134, 23);
            this.cbbPatternNumber.TabIndex = 1;
            this.cbbPatternNumber.SelectedIndexChanged += new System.EventHandler(this.cbbPatternNumber_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pattern Number";
            // 
            // flpPattern
            // 
            this.flpPattern.AutoScroll = true;
            this.flpPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPattern.Location = new System.Drawing.Point(0, 0);
            this.flpPattern.Name = "flpPattern";
            this.flpPattern.Size = new System.Drawing.Size(1015, 475);
            this.flpPattern.TabIndex = 1;
            // 
            // UserPatternConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpPattern);
            this.Controls.Add(this.panel1);
            this.Name = "UserPatternConfig";
            this.Size = new System.Drawing.Size(1015, 575);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpPattern;
        private System.Windows.Forms.ComboBox cbbPatternNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
