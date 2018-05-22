namespace FourStationDemura
{
    partial class UserPattern
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
            this.gbPattern = new System.Windows.Forms.GroupBox();
            this.label97 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSleepTime = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.gbPattern.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPattern
            // 
            this.gbPattern.Controls.Add(this.pnlColor);
            this.gbPattern.Controls.Add(this.label97);
            this.gbPattern.Controls.Add(this.label4);
            this.gbPattern.Controls.Add(this.label3);
            this.gbPattern.Controls.Add(this.label2);
            this.gbPattern.Controls.Add(this.label1);
            this.gbPattern.Controls.Add(this.txtSleepTime);
            this.gbPattern.Controls.Add(this.txtB);
            this.gbPattern.Controls.Add(this.txtG);
            this.gbPattern.Controls.Add(this.txtR);
            this.gbPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPattern.Location = new System.Drawing.Point(0, 0);
            this.gbPattern.Margin = new System.Windows.Forms.Padding(2);
            this.gbPattern.Name = "gbPattern";
            this.gbPattern.Padding = new System.Windows.Forms.Padding(2);
            this.gbPattern.Size = new System.Drawing.Size(330, 145);
            this.gbPattern.TabIndex = 4;
            this.gbPattern.TabStop = false;
            this.gbPattern.Text = "Pattern";
            this.gbPattern.Paint += new System.Windows.Forms.PaintEventHandler(this.gbPattern_Paint);
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(212, 93);
            this.label97.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(15, 15);
            this.label97.TabIndex = 6;
            this.label97.Text = "S";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "保持时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "B：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "G：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "R：";
            // 
            // txtSleepTime
            // 
            this.txtSleepTime.Location = new System.Drawing.Point(158, 89);
            this.txtSleepTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtSleepTime.Name = "txtSleepTime";
            this.txtSleepTime.Size = new System.Drawing.Size(50, 25);
            this.txtSleepTime.TabIndex = 3;
            this.txtSleepTime.Text = "0";
            this.txtSleepTime.Enter += new System.EventHandler(this.txt_Enter);
            this.txtSleepTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtSleepTime.Leave += new System.EventHandler(this.txt_Leave);
            this.txtSleepTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_MouseUp);
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(261, 41);
            this.txtB.Margin = new System.Windows.Forms.Padding(2);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(50, 25);
            this.txtB.TabIndex = 2;
            this.txtB.Text = "0";
            this.txtB.TextChanged += new System.EventHandler(this.txtR_TextChanged);
            this.txtB.Enter += new System.EventHandler(this.txt_Enter);
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtB.Leave += new System.EventHandler(this.txt_Leave);
            this.txtB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_MouseUp);
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(158, 41);
            this.txtG.Margin = new System.Windows.Forms.Padding(2);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(50, 25);
            this.txtG.TabIndex = 1;
            this.txtG.Text = "0";
            this.txtG.TextChanged += new System.EventHandler(this.txtR_TextChanged);
            this.txtG.Enter += new System.EventHandler(this.txt_Enter);
            this.txtG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtG.Leave += new System.EventHandler(this.txt_Leave);
            this.txtG.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_MouseUp);
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(54, 41);
            this.txtR.Margin = new System.Windows.Forms.Padding(2);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(50, 25);
            this.txtR.TabIndex = 0;
            this.txtR.Text = "0";
            this.txtR.TextChanged += new System.EventHandler(this.txtR_TextChanged);
            this.txtR.Enter += new System.EventHandler(this.txt_Enter);
            this.txtR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtR.Leave += new System.EventHandler(this.txt_Leave);
            this.txtR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_MouseUp);
            // 
            // pnlColor
            // 
            this.pnlColor.Location = new System.Drawing.Point(261, 89);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(50, 25);
            this.pnlColor.TabIndex = 7;
            // 
            // UserPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPattern);
            this.Name = "UserPattern";
            this.Size = new System.Drawing.Size(330, 145);
            this.gbPattern.ResumeLayout(false);
            this.gbPattern.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPattern;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSleepTime;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.Panel pnlColor;
    }
}
