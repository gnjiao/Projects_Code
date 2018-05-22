namespace FourStationDemura
{
    partial class FormDemuraMan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDemuraMan));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAutomaticCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManualCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbPassNumber = new System.Windows.Forms.RichTextBox();
            this.rtbFailNumber = new System.Windows.Forms.RichTextBox();
            this.rtbSumNumber = new System.Windows.Forms.RichTextBox();
            this.rtbSuccessRate = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvServer = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Open = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PgPrimary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PgSecondary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatestResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.gbProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConfig,
            this.tsmAutomaticCheck,
            this.tsmManualCheck});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1203, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmConfig
            // 
            this.tsmConfig.Name = "tsmConfig";
            this.tsmConfig.Size = new System.Drawing.Size(68, 21);
            this.tsmConfig.Text = "系统设置";
            this.tsmConfig.Visible = false;
            this.tsmConfig.Click += new System.EventHandler(this.tsmConfig_Click);
            // 
            // tsmAutomaticCheck
            // 
            this.tsmAutomaticCheck.Name = "tsmAutomaticCheck";
            this.tsmAutomaticCheck.Size = new System.Drawing.Size(68, 21);
            this.tsmAutomaticCheck.Text = "自动检测";
            this.tsmAutomaticCheck.Visible = false;
            this.tsmAutomaticCheck.Click += new System.EventHandler(this.tsmAutomaticCheck_Click);
            // 
            // tsmManualCheck
            // 
            this.tsmManualCheck.Name = "tsmManualCheck";
            this.tsmManualCheck.Size = new System.Drawing.Size(68, 21);
            this.tsmManualCheck.Text = "手动检测";
            this.tsmManualCheck.Visible = false;
            this.tsmManualCheck.Click += new System.EventHandler(this.tsmManualCheck_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtbLog.Location = new System.Drawing.Point(820, 24);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(2);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(383, 677);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // gbProduct
            // 
            this.gbProduct.Controls.Add(this.label5);
            this.gbProduct.Controls.Add(this.rtbPassNumber);
            this.gbProduct.Controls.Add(this.rtbFailNumber);
            this.gbProduct.Controls.Add(this.rtbSumNumber);
            this.gbProduct.Controls.Add(this.rtbSuccessRate);
            this.gbProduct.Controls.Add(this.label4);
            this.gbProduct.Controls.Add(this.label3);
            this.gbProduct.Controls.Add(this.label2);
            this.gbProduct.Controls.Add(this.label1);
            this.gbProduct.Controls.Add(this.dgvServer);
            this.gbProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProduct.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbProduct.Location = new System.Drawing.Point(0, 24);
            this.gbProduct.Margin = new System.Windows.Forms.Padding(2);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Padding = new System.Windows.Forms.Padding(2);
            this.gbProduct.Size = new System.Drawing.Size(820, 184);
            this.gbProduct.TabIndex = 4;
            this.gbProduct.TabStop = false;
            this.gbProduct.Text = "项目";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(160, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 26);
            this.label5.TabIndex = 18;
            this.label5.Text = "%";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbPassNumber
            // 
            this.rtbPassNumber.ForeColor = System.Drawing.Color.Red;
            this.rtbPassNumber.Location = new System.Drawing.Point(78, 63);
            this.rtbPassNumber.Margin = new System.Windows.Forms.Padding(2);
            this.rtbPassNumber.Name = "rtbPassNumber";
            this.rtbPassNumber.ReadOnly = true;
            this.rtbPassNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbPassNumber.Size = new System.Drawing.Size(80, 27);
            this.rtbPassNumber.TabIndex = 17;
            this.rtbPassNumber.Text = "0";
            this.rtbPassNumber.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // rtbFailNumber
            // 
            this.rtbFailNumber.ForeColor = System.Drawing.Color.Red;
            this.rtbFailNumber.Location = new System.Drawing.Point(78, 99);
            this.rtbFailNumber.Margin = new System.Windows.Forms.Padding(2);
            this.rtbFailNumber.Name = "rtbFailNumber";
            this.rtbFailNumber.ReadOnly = true;
            this.rtbFailNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbFailNumber.Size = new System.Drawing.Size(80, 27);
            this.rtbFailNumber.TabIndex = 16;
            this.rtbFailNumber.Text = "0";
            this.rtbFailNumber.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // rtbSumNumber
            // 
            this.rtbSumNumber.ForeColor = System.Drawing.Color.Red;
            this.rtbSumNumber.Location = new System.Drawing.Point(78, 27);
            this.rtbSumNumber.Margin = new System.Windows.Forms.Padding(2);
            this.rtbSumNumber.Name = "rtbSumNumber";
            this.rtbSumNumber.ReadOnly = true;
            this.rtbSumNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbSumNumber.Size = new System.Drawing.Size(80, 27);
            this.rtbSumNumber.TabIndex = 15;
            this.rtbSumNumber.Text = "0";
            // 
            // rtbSuccessRate
            // 
            this.rtbSuccessRate.ForeColor = System.Drawing.Color.Red;
            this.rtbSuccessRate.Location = new System.Drawing.Point(78, 135);
            this.rtbSuccessRate.Margin = new System.Windows.Forms.Padding(2);
            this.rtbSuccessRate.Name = "rtbSuccessRate";
            this.rtbSuccessRate.ReadOnly = true;
            this.rtbSuccessRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbSuccessRate.Size = new System.Drawing.Size(80, 27);
            this.rtbSuccessRate.TabIndex = 6;
            this.rtbSuccessRate.Text = "0";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(22, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "总数量";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(22, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "成功率";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "失败数";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "成功数";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvServer
            // 
            this.dgvServer.AllowUserToAddRows = false;
            this.dgvServer.AllowUserToDeleteRows = false;
            this.dgvServer.AllowUserToResizeColumns = false;
            this.dgvServer.AllowUserToResizeRows = false;
            this.dgvServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServer.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServer.ColumnHeadersHeight = 30;
            this.dgvServer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvServer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.ServerIP,
            this.ServerPort,
            this.Open,
            this.PgPrimary,
            this.PgSecondary,
            this.Status,
            this.LatestResult});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServer.EnableHeadersVisualStyles = false;
            this.dgvServer.Location = new System.Drawing.Point(184, 18);
            this.dgvServer.Margin = new System.Windows.Forms.Padding(2);
            this.dgvServer.MultiSelect = false;
            this.dgvServer.Name = "dgvServer";
            this.dgvServer.ReadOnly = true;
            this.dgvServer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvServer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvServer.RowTemplate.Height = 27;
            this.dgvServer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServer.Size = new System.Drawing.Size(622, 155);
            this.dgvServer.TabIndex = 6;
            // 
            // Enable
            // 
            this.Enable.DataPropertyName = "Enable";
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.ReadOnly = true;
            this.Enable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Enable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ServerIP
            // 
            this.ServerIP.DataPropertyName = "ServerIP";
            this.ServerIP.HeaderText = "Server IP";
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.ReadOnly = true;
            this.ServerIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ServerPort
            // 
            this.ServerPort.DataPropertyName = "ServerPort";
            this.ServerPort.HeaderText = "Server Port";
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.ReadOnly = true;
            this.ServerPort.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Open
            // 
            this.Open.DataPropertyName = "Open";
            this.Open.HeaderText = "Open";
            this.Open.Name = "Open";
            this.Open.ReadOnly = true;
            this.Open.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PgPrimary
            // 
            this.PgPrimary.DataPropertyName = "PgPrimary";
            this.PgPrimary.HeaderText = "PG-p";
            this.PgPrimary.Name = "PgPrimary";
            this.PgPrimary.ReadOnly = true;
            this.PgPrimary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PgSecondary
            // 
            this.PgSecondary.DataPropertyName = "PgSecondary";
            this.PgSecondary.HeaderText = "PG-s";
            this.PgSecondary.Name = "PgSecondary";
            this.PgSecondary.ReadOnly = true;
            this.PgSecondary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LatestResult
            // 
            this.LatestResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LatestResult.HeaderText = "Latest Result";
            this.LatestResult.Name = "LatestResult";
            this.LatestResult.ReadOnly = true;
            this.LatestResult.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FormDemuraMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 701);
            this.Controls.Add(this.gbProduct);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDemuraMan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "深圳柔宇4工位Demura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDemuraMan_FormClosing);
            this.Load += new System.EventHandler(this.FormDemuraMan_Load);
            this.SizeChanged += new System.EventHandler(this.FormDemuraMan_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAutomaticCheck;
        private System.Windows.Forms.ToolStripMenuItem tsmManualCheck;
        private System.Windows.Forms.ToolStripMenuItem tsmConfig;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox gbProduct;
        private System.Windows.Forms.DataGridView dgvServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Open;
        private System.Windows.Forms.DataGridViewTextBoxColumn PgPrimary;
        private System.Windows.Forms.DataGridViewTextBoxColumn PgSecondary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LatestResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbSuccessRate;
        private System.Windows.Forms.RichTextBox rtbSumNumber;
        private System.Windows.Forms.RichTextBox rtbPassNumber;
        private System.Windows.Forms.RichTextBox rtbFailNumber;
        private System.Windows.Forms.Label label5;
    }
}