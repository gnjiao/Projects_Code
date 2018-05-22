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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnLog.Location = new System.Drawing.Point(273, 214);
            this.btnLog.Margin = new System.Windows.Forms.Padding(1);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(116, 50);
            this.btnLog.TabIndex = 62;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(273, 142);
            this.btnReset.Margin = new System.Windows.Forms.Padding(1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 50);
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
            this.groupBox4.Location = new System.Drawing.Point(0, 411);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox4.Size = new System.Drawing.Size(433, 324);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "上下料工位画面检查";
            // 
            // gbPattern
            // 
            this.gbPattern.Controls.Add(this.pnlColor);
            this.gbPattern.Location = new System.Drawing.Point(21, 243);
            this.gbPattern.Name = "gbPattern";
            this.gbPattern.Size = new System.Drawing.Size(385, 66);
            this.gbPattern.TabIndex = 89;
            this.gbPattern.TabStop = false;
            this.gbPattern.Text = "Pattern";
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.White;
            this.pnlColor.Location = new System.Drawing.Point(19, 21);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(346, 37);
            this.pnlColor.TabIndex = 55;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.btnContinuousCheck);
            this.groupBox6.Location = new System.Drawing.Point(21, 28);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(385, 100);
            this.groupBox6.TabIndex = 54;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "连续";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(181, 74);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 15);
            this.label14.TabIndex = 48;
            this.label14.Text = "↑";
            // 
            // btnContinuousCheck
            // 
            this.btnContinuousCheck.Location = new System.Drawing.Point(145, 19);
            this.btnContinuousCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnContinuousCheck.Name = "btnContinuousCheck";
            this.btnContinuousCheck.Size = new System.Drawing.Size(93, 50);
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
            this.groupBox5.Location = new System.Drawing.Point(21, 136);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(385, 100);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "单张";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(19, 72);
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 15);
            this.label17.TabIndex = 55;
            this.label17.Text = "←";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(272, 72);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 15);
            this.label16.TabIndex = 55;
            this.label16.Text = "→";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(145, 73);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 15);
            this.label15.TabIndex = 54;
            this.label15.Text = "↓";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOnColor
            // 
            this.btnOnColor.Enabled = false;
            this.btnOnColor.Location = new System.Drawing.Point(19, 18);
            this.btnOnColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnOnColor.Name = "btnOnColor";
            this.btnOnColor.Size = new System.Drawing.Size(93, 50);
            this.btnOnColor.TabIndex = 49;
            this.btnOnColor.Text = "上一张";
            this.btnOnColor.UseVisualStyleBackColor = true;
            this.btnOnColor.Click += new System.EventHandler(this.btnOnColor_Click);
            // 
            // btnNextColor
            // 
            this.btnNextColor.Enabled = false;
            this.btnNextColor.Location = new System.Drawing.Point(272, 18);
            this.btnNextColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextColor.Name = "btnNextColor";
            this.btnNextColor.Size = new System.Drawing.Size(93, 50);
            this.btnNextColor.TabIndex = 50;
            this.btnNextColor.Text = "下一张";
            this.btnNextColor.UseVisualStyleBackColor = true;
            this.btnNextColor.Click += new System.EventHandler(this.btnNextColor_Click);
            // 
            // btnSingleCheck
            // 
            this.btnSingleCheck.Location = new System.Drawing.Point(145, 18);
            this.btnSingleCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnSingleCheck.Name = "btnSingleCheck";
            this.btnSingleCheck.Size = new System.Drawing.Size(93, 50);
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
            this.panel1.Location = new System.Drawing.Point(1002, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 735);
            this.panel1.TabIndex = 86;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(273, 74);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(1);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(116, 50);
            this.btnContinue.TabIndex = 69;
            this.btnContinue.Text = "继续Demura";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(273, 12);
            this.btnStart.Margin = new System.Windows.Forms.Padding(1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 50);
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
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 735);
            this.panel2.TabIndex = 87;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(1002, 735);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 93;
            // 
            // gbCheckPrompt
            // 
            this.gbCheckPrompt.Controls.Add(this.flpCheckPrompt);
            this.gbCheckPrompt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbCheckPrompt.Location = new System.Drawing.Point(50, 14);
            this.gbCheckPrompt.Name = "gbCheckPrompt";
            this.gbCheckPrompt.Size = new System.Drawing.Size(418, 250);
            this.gbCheckPrompt.TabIndex = 87;
            this.gbCheckPrompt.TabStop = false;
            this.gbCheckPrompt.Text = "上下料提示信息";
            // 
            // flpCheckPrompt
            // 
            this.flpCheckPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCheckPrompt.Location = new System.Drawing.Point(3, 21);
            this.flpCheckPrompt.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.flpCheckPrompt.Name = "flpCheckPrompt";
            this.flpCheckPrompt.Size = new System.Drawing.Size(412, 226);
            this.flpCheckPrompt.TabIndex = 0;
            // 
            // pbRotaryTable
            // 
            this.pbRotaryTable.Location = new System.Drawing.Point(703, 14);
            this.pbRotaryTable.Margin = new System.Windows.Forms.Padding(1);
            this.pbRotaryTable.Name = "pbRotaryTable";
            this.pbRotaryTable.Size = new System.Drawing.Size(250, 250);
            this.pbRotaryTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRotaryTable.TabIndex = 86;
            this.pbRotaryTable.TabStop = false;
            // 
            // gbResultPrompt
            // 
            this.gbResultPrompt.Controls.Add(this.dgvPanel);
            this.gbResultPrompt.Controls.Add(this.label4);
            this.gbResultPrompt.Controls.Add(this.label1);
            this.gbResultPrompt.Controls.Add(this.label3);
            this.gbResultPrompt.Controls.Add(this.label2);
            this.gbResultPrompt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbResultPrompt.Location = new System.Drawing.Point(53, 3);
            this.gbResultPrompt.Name = "gbResultPrompt";
            this.gbResultPrompt.Size = new System.Drawing.Size(915, 434);
            this.gbResultPrompt.TabIndex = 88;
            this.gbResultPrompt.TabStop = false;
            this.gbResultPrompt.Text = "Demura提示信息";
            // 
            // dgvPanel
            // 
            this.dgvPanel.AllowUserToAddRows = false;
            this.dgvPanel.AllowUserToDeleteRows = false;
            this.dgvPanel.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPanel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPanel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPanel.Location = new System.Drawing.Point(104, 24);
            this.dgvPanel.MultiSelect = false;
            this.dgvPanel.Name = "dgvPanel";
            this.dgvPanel.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPanel.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPanel.RowTemplate.Height = 27;
            this.dgvPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPanel.Size = new System.Drawing.Size(796, 395);
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
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Aqua;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 30);
            this.label4.TabIndex = 96;
            this.label4.Text = "Station2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 30);
            this.label1.TabIndex = 93;
            this.label1.Text = "Station1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Lime;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(18, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 30);
            this.label3.TabIndex = 95;
            this.label3.Text = "Station3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(18, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 30);
            this.label2.TabIndex = 94;
            this.label2.Text = "Station4";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormAutomaticCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 735);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
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