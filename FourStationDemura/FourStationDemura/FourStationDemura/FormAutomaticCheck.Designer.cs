namespace FourStationDemura
{
    partial class FormAutomaticCheck
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutomaticCheck));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbPattern = new System.Windows.Forms.GroupBox();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnContinuousCheck = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnOnColor = new System.Windows.Forms.Button();
            this.btnNextColor = new System.Windows.Forms.Button();
            this.btnSingleCheck = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbCheckPrompt = new System.Windows.Forms.GroupBox();
            this.flpCheckPrompt = new System.Windows.Forms.FlowLayoutPanel();
            this.pbRotaryTable = new System.Windows.Forms.PictureBox();
            this.gbResultPrompt = new System.Windows.Forms.GroupBox();
            this.dgvPanel = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelOnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShootingResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WriteFlashResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReinspectionResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelOffResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FailureReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            this.gbPattern.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbCheckPrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRotaryTable)).BeginInit();
            this.gbResultPrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(205, 171);
            this.btnLog.Margin = new System.Windows.Forms.Padding(1);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(87, 40);
            this.btnLog.TabIndex = 62;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(205, 114);
            this.btnReset.Margin = new System.Windows.Forms.Padding(1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 40);
            this.btnReset.TabIndex = 55;
            this.btnReset.Text = "复位";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gbPattern);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 329);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox4.Size = new System.Drawing.Size(325, 259);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "上下料工位画面检查";
            // 
            // gbPattern
            // 
            this.gbPattern.Controls.Add(this.pnlColor);
            this.gbPattern.Location = new System.Drawing.Point(16, 194);
            this.gbPattern.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbPattern.Name = "gbPattern";
            this.gbPattern.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbPattern.Size = new System.Drawing.Size(289, 53);
            this.gbPattern.TabIndex = 89;
            this.gbPattern.TabStop = false;
            this.gbPattern.Text = "Pattern";
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.White;
            this.pnlColor.Location = new System.Drawing.Point(14, 17);
            this.pnlColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(260, 30);
            this.pnlColor.TabIndex = 55;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.btnContinuousCheck);
            this.groupBox6.Location = new System.Drawing.Point(16, 22);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(289, 80);
            this.groupBox6.TabIndex = 54;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "连续";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(136, 59);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 48;
            this.label14.Text = "↑";
            // 
            // btnContinuousCheck
            // 
            this.btnContinuousCheck.Location = new System.Drawing.Point(109, 15);
            this.btnContinuousCheck.Name = "btnContinuousCheck";
            this.btnContinuousCheck.Size = new System.Drawing.Size(70, 40);
            this.btnContinuousCheck.TabIndex = 47;
            this.btnContinuousCheck.Text = "开始检查";
            this.btnContinuousCheck.UseVisualStyleBackColor = true;
            this.btnContinuousCheck.Click += new System.EventHandler(this.btnContinuousCheck_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.btnOnColor);
            this.groupBox5.Controls.Add(this.btnNextColor);
            this.groupBox5.Controls.Add(this.btnSingleCheck);
            this.groupBox5.Location = new System.Drawing.Point(16, 109);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(289, 80);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "单张";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(14, 58);
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 12);
            this.label17.TabIndex = 55;
            this.label17.Text = "←";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(204, 58);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 12);
            this.label16.TabIndex = 55;
            this.label16.Text = "→";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(109, 58);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 12);
            this.label15.TabIndex = 54;
            this.label15.Text = "↓";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOnColor
            // 
            this.btnOnColor.Enabled = false;
            this.btnOnColor.Location = new System.Drawing.Point(14, 14);
            this.btnOnColor.Name = "btnOnColor";
            this.btnOnColor.Size = new System.Drawing.Size(70, 40);
            this.btnOnColor.TabIndex = 49;
            this.btnOnColor.Text = "上一张";
            this.btnOnColor.UseVisualStyleBackColor = true;
            this.btnOnColor.Click += new System.EventHandler(this.btnOnColor_Click);
            // 
            // btnNextColor
            // 
            this.btnNextColor.Enabled = false;
            this.btnNextColor.Location = new System.Drawing.Point(204, 14);
            this.btnNextColor.Name = "btnNextColor";
            this.btnNextColor.Size = new System.Drawing.Size(70, 40);
            this.btnNextColor.TabIndex = 50;
            this.btnNextColor.Text = "下一张";
            this.btnNextColor.UseVisualStyleBackColor = true;
            this.btnNextColor.Click += new System.EventHandler(this.btnNextColor_Click);
            // 
            // btnSingleCheck
            // 
            this.btnSingleCheck.Location = new System.Drawing.Point(109, 14);
            this.btnSingleCheck.Name = "btnSingleCheck";
            this.btnSingleCheck.Size = new System.Drawing.Size(70, 40);
            this.btnSingleCheck.TabIndex = 48;
            this.btnSingleCheck.Text = "开始检查";
            this.btnSingleCheck.UseVisualStyleBackColor = true;
            this.btnSingleCheck.Click += new System.EventHandler(this.btnSingleCheck_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "No.png");
            this.imgList.Images.SetKeyName(1, "Yes.png");
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnContinue);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(751, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 588);
            this.panel1.TabIndex = 86;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(205, 59);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(1);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(87, 40);
            this.btnContinue.TabIndex = 69;
            this.btnContinue.Text = "继续Demura";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(205, 10);
            this.btnStart.Margin = new System.Windows.Forms.Padding(1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 40);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始Demura";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 588);
            this.panel2.TabIndex = 87;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.gbCheckPrompt);
            this.splitContainer1.Panel1.Controls.Add(this.pbRotaryTable);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.gbResultPrompt);
            this.splitContainer1.Size = new System.Drawing.Size(751, 588);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 93;
            // 
            // gbCheckPrompt
            // 
            this.gbCheckPrompt.Controls.Add(this.flpCheckPrompt);
            this.gbCheckPrompt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbCheckPrompt.Location = new System.Drawing.Point(38, 11);
            this.gbCheckPrompt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbCheckPrompt.Name = "gbCheckPrompt";
            this.gbCheckPrompt.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbCheckPrompt.Size = new System.Drawing.Size(393, 200);
            this.gbCheckPrompt.TabIndex = 87;
            this.gbCheckPrompt.TabStop = false;
            this.gbCheckPrompt.Text = "上下料提示信息";
            // 
            // flpCheckPrompt
            // 
            this.flpCheckPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCheckPrompt.Location = new System.Drawing.Point(2, 16);
            this.flpCheckPrompt.Margin = new System.Windows.Forms.Padding(2, 32, 2, 2);
            this.flpCheckPrompt.Name = "flpCheckPrompt";
            this.flpCheckPrompt.Size = new System.Drawing.Size(389, 182);
            this.flpCheckPrompt.TabIndex = 0;
            // 
            // pbRotaryTable
            // 
            this.pbRotaryTable.Location = new System.Drawing.Point(560, 11);
            this.pbRotaryTable.Margin = new System.Windows.Forms.Padding(1);
            this.pbRotaryTable.Name = "pbRotaryTable";
            this.pbRotaryTable.Size = new System.Drawing.Size(188, 200);
            this.pbRotaryTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRotaryTable.TabIndex = 86;
            this.pbRotaryTable.TabStop = false;
            // 
            // gbResultPrompt
            // 
            this.gbResultPrompt.Controls.Add(this.dgvPanel);
            this.gbResultPrompt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbResultPrompt.Location = new System.Drawing.Point(40, 2);
            this.gbResultPrompt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbResultPrompt.Name = "gbResultPrompt";
            this.gbResultPrompt.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbResultPrompt.Size = new System.Drawing.Size(686, 347);
            this.gbResultPrompt.TabIndex = 88;
            this.gbResultPrompt.TabStop = false;
            this.gbResultPrompt.Text = "Demura提示信息";
            // 
            // dgvPanel
            // 
            this.dgvPanel.AllowUserToAddRows = false;
            this.dgvPanel.AllowUserToDeleteRows = false;
            this.dgvPanel.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPanel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPanel.ColumnHeadersHeight = 30;
            this.dgvPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPanel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.Code,
            this.PanelOnResult,
            this.ShootingResult,
            this.WriteFlashResult,
            this.ReinspectionResult,
            this.PanelOffResult,
            this.FailureReason});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPanel.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPanel.Location = new System.Drawing.Point(78, 19);
            this.dgvPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPanel.MultiSelect = false;
            this.dgvPanel.Name = "dgvPanel";
            this.dgvPanel.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPanel.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPanel.RowTemplate.Height = 27;
            this.dgvPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPanel.Size = new System.Drawing.Size(597, 316);
            this.dgvPanel.TabIndex = 88;
            // 
            // Position
            // 
            this.Position.HeaderText = "位置";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Position.Width = 50;
            // 
            // Code
            // 
            this.Code.HeaderText = "屏幕编码";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PanelOnResult
            // 
            this.PanelOnResult.HeaderText = "点屏结果";
            this.PanelOnResult.Name = "PanelOnResult";
            this.PanelOnResult.ReadOnly = true;
            this.PanelOnResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ShootingResult
            // 
            this.ShootingResult.HeaderText = "拍摄结果";
            this.ShootingResult.Name = "ShootingResult";
            this.ShootingResult.ReadOnly = true;
            this.ShootingResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WriteFlashResult
            // 
            this.WriteFlashResult.HeaderText = "烧入结果";
            this.WriteFlashResult.Name = "WriteFlashResult";
            this.WriteFlashResult.ReadOnly = true;
            this.WriteFlashResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ReinspectionResult
            // 
            this.ReinspectionResult.HeaderText = "复检结果";
            this.ReinspectionResult.Name = "ReinspectionResult";
            this.ReinspectionResult.ReadOnly = true;
            this.ReinspectionResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PanelOffResult
            // 
            this.PanelOffResult.HeaderText = "熄屏结果";
            this.PanelOffResult.Name = "PanelOffResult";
            this.PanelOffResult.ReadOnly = true;
            this.PanelOffResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FailureReason
            // 
            this.FailureReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FailureReason.HeaderText = "NG原因";
            this.FailureReason.Name = "FailureReason";
            this.FailureReason.ReadOnly = true;
            this.FailureReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormAutomaticCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 588);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAutomaticCheck";
            this.ShowIcon = false;
            this.Text = "自动检测";
            this.Load += new System.EventHandler(this.FormAutomaticCheck_Load);
            this.groupBox4.ResumeLayout(false);
            this.gbPattern.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbCheckPrompt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRotaryTable)).EndInit();
            this.gbResultPrompt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnContinuousCheck;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnOnColor;
        private System.Windows.Forms.Button btnNextColor;
        private System.Windows.Forms.Button btnSingleCheck;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbCheckPrompt;
        private System.Windows.Forms.PictureBox pbRotaryTable;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.GroupBox gbPattern;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.DataGridView dgvPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flpCheckPrompt;
        private System.Windows.Forms.GroupBox gbResultPrompt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn PanelOnResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShootingResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn WriteFlashResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReinspectionResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn PanelOffResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn FailureReason;
    }
}