namespace FourStationDemura
{
    partial class UserMove
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.btnGoHome = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbAxis = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrentPosition = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(163, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "移动距离";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "°/mm";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(276, 61);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(1);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(80, 25);
            this.txtDistance.TabIndex = 28;
            this.txtDistance.Text = "0";
            this.txtDistance.Enter += new System.EventHandler(this.txtDistance_Enter);
            this.txtDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistance_KeyPress);
            this.txtDistance.MouseLeave += new System.EventHandler(this.txtDistance_MouseLeave);
            this.txtDistance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtDistance_MouseUp);
            // 
            // btnGoHome
            // 
            this.btnGoHome.Enabled = false;
            this.btnGoHome.Location = new System.Drawing.Point(163, 161);
            this.btnGoHome.Margin = new System.Windows.Forms.Padding(1);
            this.btnGoHome.Name = "btnGoHome";
            this.btnGoHome.Size = new System.Drawing.Size(95, 35);
            this.btnGoHome.TabIndex = 27;
            this.btnGoHome.Text = "回原点";
            this.btnGoHome.UseVisualStyleBackColor = true;
            this.btnGoHome.Click += new System.EventHandler(this.btnGoHome_Click);
            // 
            // btnRight
            // 
            this.btnRight.Enabled = false;
            this.btnRight.Location = new System.Drawing.Point(276, 161);
            this.btnRight.Margin = new System.Windows.Forms.Padding(1);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(95, 35);
            this.btnRight.TabIndex = 26;
            this.btnRight.Text = "轴右移";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Enabled = false;
            this.btnLeft.Location = new System.Drawing.Point(50, 161);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(1);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(95, 35);
            this.btnLeft.TabIndex = 25;
            this.btnLeft.Text = "轴左移";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(163, 214);
            this.btnDown.Margin = new System.Windows.Forms.Padding(1);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(95, 35);
            this.btnDown.TabIndex = 24;
            this.btnDown.Text = "轴下移";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(163, 108);
            this.btnUp.Margin = new System.Windows.Forms.Padding(1);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(95, 35);
            this.btnUp.TabIndex = 23;
            this.btnUp.Text = "轴上移";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "轴";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbAxis
            // 
            this.cbbAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAxis.Enabled = false;
            this.cbbAxis.FormattingEnabled = true;
            this.cbbAxis.Location = new System.Drawing.Point(48, 42);
            this.cbbAxis.Name = "cbbAxis";
            this.cbbAxis.Size = new System.Drawing.Size(105, 23);
            this.cbbAxis.TabIndex = 32;
            this.cbbAxis.SelectedIndexChanged += new System.EventHandler(this.cbbAxis_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(163, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "当前位置";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "°/mm";
            // 
            // txtCurrentPosition
            // 
            this.txtCurrentPosition.Enabled = false;
            this.txtCurrentPosition.Location = new System.Drawing.Point(276, 24);
            this.txtCurrentPosition.Margin = new System.Windows.Forms.Padding(1);
            this.txtCurrentPosition.Name = "txtCurrentPosition";
            this.txtCurrentPosition.Size = new System.Drawing.Size(80, 25);
            this.txtCurrentPosition.TabIndex = 33;
            // 
            // UserMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCurrentPosition);
            this.Controls.Add(this.cbbAxis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.btnGoHome);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Name = "UserMove";
            this.Size = new System.Drawing.Size(427, 268);
            this.Load += new System.EventHandler(this.UserMove_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Button btnGoHome;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbAxis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrentPosition;
    }
}
