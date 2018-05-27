namespace FourStationDemura
{
    partial class FormManualCheck
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
            this.gbMove = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCheckLock = new System.Windows.Forms.Button();
            this.txtLock = new System.Windows.Forms.TextBox();
            this.btnSweep = new System.Windows.Forms.Button();
            this.btnCloseIo = new System.Windows.Forms.Button();
            this.btnStation_1 = new System.Windows.Forms.Button();
            this.btnOpenIo = new System.Windows.Forms.Button();
            this.btnStation_3 = new System.Windows.Forms.Button();
            this.btnStation_4 = new System.Windows.Forms.Button();
            this.cbbIO = new System.Windows.Forms.ComboBox();
            this.btnStation_2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnFlashWrite = new System.Windows.Forms.Button();
            this.cbbPgSelect = new System.Windows.Forms.ComboBox();
            this.btnSetRaster = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFlashWrite = new System.Windows.Forms.TextBox();
            this.btnGetState = new System.Windows.Forms.Button();
            this.txtSetRaster = new System.Windows.Forms.TextBox();
            this.btnGetRemainingCount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnFlashResult = new System.Windows.Forms.Button();
            this.btnSeqEnd = new System.Windows.Forms.Button();
            this.btnTblRotate = new System.Windows.Forms.Button();
            this.btnSeqStart = new System.Windows.Forms.Button();
            this.btnFlashErase = new System.Windows.Forms.Button();
            this.btnPanelOff = new System.Windows.Forms.Button();
            this.btnCaptureStart = new System.Windows.Forms.Button();
            this.btnPanelOn = new System.Windows.Forms.Button();
            this.btnCaptureResult = new System.Windows.Forms.Button();
            this.btnDeMraCheckResult = new System.Windows.Forms.Button();
            this.btnAlignmentStart = new System.Windows.Forms.Button();
            this.btnDeMuraCheck = new System.Windows.Forms.Button();
            this.btnAlignmentStop = new System.Windows.Forms.Button();
            this.btnDeMuraResult = new System.Windows.Forms.Button();
            this.btnFocusCheckStart = new System.Windows.Forms.Button();
            this.btnDeMuraStart = new System.Windows.Forms.Button();
            this.btnAbortDeMura = new System.Windows.Forms.Button();
            this.userMove1 = new FourStationDemura.UserMove();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.gbMove.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMove
            // 
            this.gbMove.Controls.Add(this.panel2);
            this.gbMove.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMove.Location = new System.Drawing.Point(0, 0);
            this.gbMove.Margin = new System.Windows.Forms.Padding(1);
            this.gbMove.Name = "gbMove";
            this.gbMove.Padding = new System.Windows.Forms.Padding(1);
            this.gbMove.Size = new System.Drawing.Size(1152, 293);
            this.gbMove.TabIndex = 6;
            this.gbMove.TabStop = false;
            this.gbMove.Text = "运动轴控制";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.btnCheckLock);
            this.panel2.Controls.Add(this.txtLock);
            this.panel2.Controls.Add(this.btnSweep);
            this.panel2.Controls.Add(this.userMove1);
            this.panel2.Controls.Add(this.btnCloseIo);
            this.panel2.Controls.Add(this.btnStation_1);
            this.panel2.Controls.Add(this.btnOpenIo);
            this.panel2.Controls.Add(this.btnStation_3);
            this.panel2.Controls.Add(this.btnStation_4);
            this.panel2.Controls.Add(this.cbbIO);
            this.panel2.Controls.Add(this.btnStation_2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 19);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1150, 273);
            this.panel2.TabIndex = 31;
            // 
            // btnCheckLock
            // 
            this.btnCheckLock.Enabled = false;
            this.btnCheckLock.Location = new System.Drawing.Point(972, 151);
            this.btnCheckLock.Margin = new System.Windows.Forms.Padding(1);
            this.btnCheckLock.Name = "btnCheckLock";
            this.btnCheckLock.Size = new System.Drawing.Size(135, 34);
            this.btnCheckLock.TabIndex = 34;
            this.btnCheckLock.Text = "检测转盘防呆";
            this.btnCheckLock.UseVisualStyleBackColor = true;
            this.btnCheckLock.Click += new System.EventHandler(this.btnCheckLock_Click);
            // 
            // txtLock
            // 
            this.txtLock.Enabled = false;
            this.txtLock.Location = new System.Drawing.Point(834, 156);
            this.txtLock.Name = "txtLock";
            this.txtLock.Size = new System.Drawing.Size(135, 25);
            this.txtLock.TabIndex = 33;
            // 
            // btnSweep
            // 
            this.btnSweep.Enabled = false;
            this.btnSweep.Location = new System.Drawing.Point(972, 215);
            this.btnSweep.Margin = new System.Windows.Forms.Padding(1);
            this.btnSweep.Name = "btnSweep";
            this.btnSweep.Size = new System.Drawing.Size(135, 34);
            this.btnSweep.TabIndex = 32;
            this.btnSweep.Text = "扫码";
            this.btnSweep.UseVisualStyleBackColor = true;
            this.btnSweep.Click += new System.EventHandler(this.btnSweep_Click);
            // 
            // btnCloseIo
            // 
            this.btnCloseIo.Enabled = false;
            this.btnCloseIo.Location = new System.Drawing.Point(972, 86);
            this.btnCloseIo.Margin = new System.Windows.Forms.Padding(1);
            this.btnCloseIo.Name = "btnCloseIo";
            this.btnCloseIo.Size = new System.Drawing.Size(135, 34);
            this.btnCloseIo.TabIndex = 29;
            this.btnCloseIo.Text = "关";
            this.btnCloseIo.UseVisualStyleBackColor = true;
            this.btnCloseIo.Click += new System.EventHandler(this.btnCloseIo_Click);
            // 
            // btnStation_1
            // 
            this.btnStation_1.Enabled = false;
            this.btnStation_1.Location = new System.Drawing.Point(500, 24);
            this.btnStation_1.Margin = new System.Windows.Forms.Padding(1);
            this.btnStation_1.Name = "btnStation_1";
            this.btnStation_1.Size = new System.Drawing.Size(150, 34);
            this.btnStation_1.TabIndex = 9;
            this.btnStation_1.Text = "移动到工作位置1";
            this.btnStation_1.UseVisualStyleBackColor = true;
            this.btnStation_1.Click += new System.EventHandler(this.btnStation_1_Click);
            // 
            // btnOpenIo
            // 
            this.btnOpenIo.Enabled = false;
            this.btnOpenIo.Location = new System.Drawing.Point(834, 86);
            this.btnOpenIo.Margin = new System.Windows.Forms.Padding(1);
            this.btnOpenIo.Name = "btnOpenIo";
            this.btnOpenIo.Size = new System.Drawing.Size(135, 34);
            this.btnOpenIo.TabIndex = 28;
            this.btnOpenIo.Text = "开";
            this.btnOpenIo.UseVisualStyleBackColor = true;
            this.btnOpenIo.Click += new System.EventHandler(this.btnOpenIo_Click);
            // 
            // btnStation_3
            // 
            this.btnStation_3.Enabled = false;
            this.btnStation_3.Location = new System.Drawing.Point(500, 151);
            this.btnStation_3.Margin = new System.Windows.Forms.Padding(1);
            this.btnStation_3.Name = "btnStation_3";
            this.btnStation_3.Size = new System.Drawing.Size(150, 34);
            this.btnStation_3.TabIndex = 23;
            this.btnStation_3.Text = "移动到工作位置3";
            this.btnStation_3.UseVisualStyleBackColor = true;
            this.btnStation_3.Click += new System.EventHandler(this.btnStation_3_Click);
            // 
            // btnStation_4
            // 
            this.btnStation_4.Enabled = false;
            this.btnStation_4.Location = new System.Drawing.Point(500, 215);
            this.btnStation_4.Margin = new System.Windows.Forms.Padding(1);
            this.btnStation_4.Name = "btnStation_4";
            this.btnStation_4.Size = new System.Drawing.Size(150, 34);
            this.btnStation_4.TabIndex = 26;
            this.btnStation_4.Text = "移动到工作位置4";
            this.btnStation_4.UseVisualStyleBackColor = true;
            this.btnStation_4.Click += new System.EventHandler(this.btnStation_4_Click);
            // 
            // cbbIO
            // 
            this.cbbIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIO.Enabled = false;
            this.cbbIO.FormattingEnabled = true;
            this.cbbIO.Items.AddRange(new object[] {
            "真空",
            "治具防呆",
            "暗室气缸",
            "轴使能",
            "报警",
            "黄灯",
            "红灯",
            "绿灯",
            "启动按钮1灯",
            "启动按钮2灯",
            "按钮1灯",
            "按钮2灯",
            "按钮3灯"});
            this.cbbIO.Location = new System.Drawing.Point(834, 31);
            this.cbbIO.Name = "cbbIO";
            this.cbbIO.Size = new System.Drawing.Size(273, 23);
            this.cbbIO.TabIndex = 24;
            // 
            // btnStation_2
            // 
            this.btnStation_2.Enabled = false;
            this.btnStation_2.Location = new System.Drawing.Point(500, 86);
            this.btnStation_2.Margin = new System.Windows.Forms.Padding(1);
            this.btnStation_2.Name = "btnStation_2";
            this.btnStation_2.Size = new System.Drawing.Size(150, 34);
            this.btnStation_2.TabIndex = 25;
            this.btnStation_2.Text = "移动到工作位置2";
            this.btnStation_2.UseVisualStyleBackColor = true;
            this.btnStation_2.Click += new System.EventHandler(this.btnStation_2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1152, 447);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IIX控制";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pnlColor);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.btnFlashWrite);
            this.panel1.Controls.Add(this.cbbPgSelect);
            this.panel1.Controls.Add(this.btnSetRaster);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.txtFlashWrite);
            this.panel1.Controls.Add(this.btnGetState);
            this.panel1.Controls.Add(this.txtSetRaster);
            this.panel1.Controls.Add(this.btnGetRemainingCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDisconnect);
            this.panel1.Controls.Add(this.btnFlashResult);
            this.panel1.Controls.Add(this.btnSeqEnd);
            this.panel1.Controls.Add(this.btnTblRotate);
            this.panel1.Controls.Add(this.btnSeqStart);
            this.panel1.Controls.Add(this.btnFlashErase);
            this.panel1.Controls.Add(this.btnPanelOff);
            this.panel1.Controls.Add(this.btnCaptureStart);
            this.panel1.Controls.Add(this.btnPanelOn);
            this.panel1.Controls.Add(this.btnCaptureResult);
            this.panel1.Controls.Add(this.btnDeMraCheckResult);
            this.panel1.Controls.Add(this.btnAlignmentStart);
            this.panel1.Controls.Add(this.btnDeMuraCheck);
            this.panel1.Controls.Add(this.btnAlignmentStop);
            this.panel1.Controls.Add(this.btnDeMuraResult);
            this.panel1.Controls.Add(this.btnFocusCheckStart);
            this.panel1.Controls.Add(this.btnDeMuraStart);
            this.panel1.Controls.Add(this.btnAbortDeMura);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 423);
            this.panel1.TabIndex = 31;
            // 
            // pnlColor
            // 
            this.pnlColor.Location = new System.Drawing.Point(959, 342);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(86, 25);
            this.pnlColor.TabIndex = 80;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(54, 23);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(1);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(150, 40);
            this.btnConnect.TabIndex = 48;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnFlashWrite
            // 
            this.btnFlashWrite.Location = new System.Drawing.Point(1059, 386);
            this.btnFlashWrite.Name = "btnFlashWrite";
            this.btnFlashWrite.Size = new System.Drawing.Size(40, 25);
            this.btnFlashWrite.TabIndex = 79;
            this.btnFlashWrite.Text = "...";
            this.btnFlashWrite.UseVisualStyleBackColor = true;
            this.btnFlashWrite.Click += new System.EventHandler(this.btnFlashWrite_Click);
            // 
            // cbbPgSelect
            // 
            this.cbbPgSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPgSelect.FormattingEnabled = true;
            this.cbbPgSelect.Location = new System.Drawing.Point(353, 26);
            this.cbbPgSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cbbPgSelect.Name = "cbbPgSelect";
            this.cbbPgSelect.Size = new System.Drawing.Size(150, 23);
            this.cbbPgSelect.TabIndex = 49;
            // 
            // btnSetRaster
            // 
            this.btnSetRaster.Location = new System.Drawing.Point(1059, 342);
            this.btnSetRaster.Name = "btnSetRaster";
            this.btnSetRaster.Size = new System.Drawing.Size(40, 25);
            this.btnSetRaster.TabIndex = 78;
            this.btnSetRaster.Text = "...";
            this.btnSetRaster.UseVisualStyleBackColor = true;
            this.btnSetRaster.Click += new System.EventHandler(this.btnSetRaster_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(54, 74);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(150, 40);
            this.btnOpen.TabIndex = 50;
            this.btnOpen.Text = "打开设备";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFlashWrite
            // 
            this.txtFlashWrite.Enabled = false;
            this.txtFlashWrite.Location = new System.Drawing.Point(651, 388);
            this.txtFlashWrite.Name = "txtFlashWrite";
            this.txtFlashWrite.Size = new System.Drawing.Size(402, 25);
            this.txtFlashWrite.TabIndex = 77;
            // 
            // btnGetState
            // 
            this.btnGetState.Location = new System.Drawing.Point(54, 125);
            this.btnGetState.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetState.Name = "btnGetState";
            this.btnGetState.Size = new System.Drawing.Size(150, 40);
            this.btnGetState.TabIndex = 51;
            this.btnGetState.Text = "获取状态";
            this.btnGetState.UseVisualStyleBackColor = true;
            this.btnGetState.Click += new System.EventHandler(this.btnGetState_Click);
            // 
            // txtSetRaster
            // 
            this.txtSetRaster.Enabled = false;
            this.txtSetRaster.Location = new System.Drawing.Point(651, 342);
            this.txtSetRaster.Name = "txtSetRaster";
            this.txtSetRaster.Size = new System.Drawing.Size(298, 25);
            this.txtSetRaster.TabIndex = 76;
            // 
            // btnGetRemainingCount
            // 
            this.btnGetRemainingCount.Location = new System.Drawing.Point(54, 176);
            this.btnGetRemainingCount.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetRemainingCount.Name = "btnGetRemainingCount";
            this.btnGetRemainingCount.Size = new System.Drawing.Size(150, 40);
            this.btnGetRemainingCount.TabIndex = 52;
            this.btnGetRemainingCount.Text = "获取剩余使用次数";
            this.btnGetRemainingCount.UseVisualStyleBackColor = true;
            this.btnGetRemainingCount.Click += new System.EventHandler(this.btnGetRemainingCount_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(549, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 75;
            this.label2.Text = "Flash Write";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(54, 227);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "关闭设备";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 74;
            this.label1.Text = "Set Raster";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(54, 278);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(150, 40);
            this.btnDisconnect.TabIndex = 54;
            this.btnDisconnect.Text = "关闭连接";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnFlashResult
            // 
            this.btnFlashResult.Location = new System.Drawing.Point(948, 23);
            this.btnFlashResult.Margin = new System.Windows.Forms.Padding(4);
            this.btnFlashResult.Name = "btnFlashResult";
            this.btnFlashResult.Size = new System.Drawing.Size(150, 40);
            this.btnFlashResult.TabIndex = 71;
            this.btnFlashResult.Text = "Flash Result";
            this.btnFlashResult.UseVisualStyleBackColor = true;
            this.btnFlashResult.Click += new System.EventHandler(this.btnFlashResult_Click);
            // 
            // btnSeqEnd
            // 
            this.btnSeqEnd.Location = new System.Drawing.Point(353, 125);
            this.btnSeqEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeqEnd.Name = "btnSeqEnd";
            this.btnSeqEnd.Size = new System.Drawing.Size(150, 40);
            this.btnSeqEnd.TabIndex = 56;
            this.btnSeqEnd.Text = "连续指令结束";
            this.btnSeqEnd.UseVisualStyleBackColor = true;
            this.btnSeqEnd.Click += new System.EventHandler(this.btnSeqEnd_Click);
            // 
            // btnTblRotate
            // 
            this.btnTblRotate.Location = new System.Drawing.Point(353, 278);
            this.btnTblRotate.Margin = new System.Windows.Forms.Padding(4);
            this.btnTblRotate.Name = "btnTblRotate";
            this.btnTblRotate.Size = new System.Drawing.Size(150, 40);
            this.btnTblRotate.TabIndex = 69;
            this.btnTblRotate.Text = "转换PG";
            this.btnTblRotate.UseVisualStyleBackColor = true;
            this.btnTblRotate.Click += new System.EventHandler(this.btnTblRotate_Click);
            // 
            // btnSeqStart
            // 
            this.btnSeqStart.Location = new System.Drawing.Point(353, 74);
            this.btnSeqStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeqStart.Name = "btnSeqStart";
            this.btnSeqStart.Size = new System.Drawing.Size(150, 40);
            this.btnSeqStart.TabIndex = 55;
            this.btnSeqStart.Text = "连续指令开始";
            this.btnSeqStart.UseVisualStyleBackColor = true;
            this.btnSeqStart.Click += new System.EventHandler(this.btnSeqStart_Click);
            // 
            // btnFlashErase
            // 
            this.btnFlashErase.Location = new System.Drawing.Point(651, 278);
            this.btnFlashErase.Margin = new System.Windows.Forms.Padding(4);
            this.btnFlashErase.Name = "btnFlashErase";
            this.btnFlashErase.Size = new System.Drawing.Size(150, 40);
            this.btnFlashErase.TabIndex = 72;
            this.btnFlashErase.Text = "Flash Erase";
            this.btnFlashErase.UseVisualStyleBackColor = true;
            this.btnFlashErase.Click += new System.EventHandler(this.btnFlashErase_Click);
            // 
            // btnPanelOff
            // 
            this.btnPanelOff.Location = new System.Drawing.Point(353, 227);
            this.btnPanelOff.Margin = new System.Windows.Forms.Padding(4);
            this.btnPanelOff.Name = "btnPanelOff";
            this.btnPanelOff.Size = new System.Drawing.Size(150, 40);
            this.btnPanelOff.TabIndex = 58;
            this.btnPanelOff.Text = "熄灭屏幕";
            this.btnPanelOff.UseVisualStyleBackColor = true;
            this.btnPanelOff.Click += new System.EventHandler(this.btnPanelOff_Click);
            // 
            // btnCaptureStart
            // 
            this.btnCaptureStart.Location = new System.Drawing.Point(948, 227);
            this.btnCaptureStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnCaptureStart.Name = "btnCaptureStart";
            this.btnCaptureStart.Size = new System.Drawing.Size(150, 40);
            this.btnCaptureStart.TabIndex = 67;
            this.btnCaptureStart.Text = "Capt. Start";
            this.btnCaptureStart.UseVisualStyleBackColor = true;
            this.btnCaptureStart.Click += new System.EventHandler(this.btnCaptureStart_Click);
            // 
            // btnPanelOn
            // 
            this.btnPanelOn.Location = new System.Drawing.Point(353, 176);
            this.btnPanelOn.Margin = new System.Windows.Forms.Padding(4);
            this.btnPanelOn.Name = "btnPanelOn";
            this.btnPanelOn.Size = new System.Drawing.Size(150, 40);
            this.btnPanelOn.TabIndex = 57;
            this.btnPanelOn.Text = "点亮屏幕";
            this.btnPanelOn.UseVisualStyleBackColor = true;
            this.btnPanelOn.Click += new System.EventHandler(this.btnPanelOn_Click);
            // 
            // btnCaptureResult
            // 
            this.btnCaptureResult.Location = new System.Drawing.Point(948, 278);
            this.btnCaptureResult.Margin = new System.Windows.Forms.Padding(4);
            this.btnCaptureResult.Name = "btnCaptureResult";
            this.btnCaptureResult.Size = new System.Drawing.Size(150, 40);
            this.btnCaptureResult.TabIndex = 68;
            this.btnCaptureResult.Text = "Capt Result";
            this.btnCaptureResult.UseVisualStyleBackColor = true;
            this.btnCaptureResult.Click += new System.EventHandler(this.btnCaptureResult_Click);
            // 
            // btnDeMraCheckResult
            // 
            this.btnDeMraCheckResult.Location = new System.Drawing.Point(651, 176);
            this.btnDeMraCheckResult.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeMraCheckResult.Name = "btnDeMraCheckResult";
            this.btnDeMraCheckResult.Size = new System.Drawing.Size(150, 40);
            this.btnDeMraCheckResult.TabIndex = 62;
            this.btnDeMraCheckResult.Text = "Chk Result";
            this.btnDeMraCheckResult.UseVisualStyleBackColor = true;
            this.btnDeMraCheckResult.Click += new System.EventHandler(this.btnDeMraCheckResult_Click);
            // 
            // btnAlignmentStart
            // 
            this.btnAlignmentStart.Location = new System.Drawing.Point(948, 74);
            this.btnAlignmentStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlignmentStart.Name = "btnAlignmentStart";
            this.btnAlignmentStart.Size = new System.Drawing.Size(150, 40);
            this.btnAlignmentStart.TabIndex = 64;
            this.btnAlignmentStart.Text = "Align. Start";
            this.btnAlignmentStart.UseVisualStyleBackColor = true;
            this.btnAlignmentStart.Click += new System.EventHandler(this.btnAlignmentStart_Click);
            // 
            // btnDeMuraCheck
            // 
            this.btnDeMuraCheck.Location = new System.Drawing.Point(651, 125);
            this.btnDeMuraCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeMuraCheck.Name = "btnDeMuraCheck";
            this.btnDeMuraCheck.Size = new System.Drawing.Size(150, 40);
            this.btnDeMuraCheck.TabIndex = 61;
            this.btnDeMuraCheck.Text = "Dmr Check";
            this.btnDeMuraCheck.UseVisualStyleBackColor = true;
            this.btnDeMuraCheck.Click += new System.EventHandler(this.btnDeMuraCheck_Click);
            // 
            // btnAlignmentStop
            // 
            this.btnAlignmentStop.Location = new System.Drawing.Point(948, 125);
            this.btnAlignmentStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlignmentStop.Name = "btnAlignmentStop";
            this.btnAlignmentStop.Size = new System.Drawing.Size(150, 40);
            this.btnAlignmentStop.TabIndex = 65;
            this.btnAlignmentStop.Text = "Align. Stop";
            this.btnAlignmentStop.UseVisualStyleBackColor = true;
            this.btnAlignmentStop.Click += new System.EventHandler(this.btnAlignmentStop_Click);
            // 
            // btnDeMuraResult
            // 
            this.btnDeMuraResult.Location = new System.Drawing.Point(651, 74);
            this.btnDeMuraResult.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeMuraResult.Name = "btnDeMuraResult";
            this.btnDeMuraResult.Size = new System.Drawing.Size(150, 40);
            this.btnDeMuraResult.TabIndex = 60;
            this.btnDeMuraResult.Text = "Dmr Result";
            this.btnDeMuraResult.UseVisualStyleBackColor = true;
            this.btnDeMuraResult.Click += new System.EventHandler(this.btnDeMuraResult_Click);
            // 
            // btnFocusCheckStart
            // 
            this.btnFocusCheckStart.Location = new System.Drawing.Point(948, 176);
            this.btnFocusCheckStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnFocusCheckStart.Name = "btnFocusCheckStart";
            this.btnFocusCheckStart.Size = new System.Drawing.Size(150, 40);
            this.btnFocusCheckStart.TabIndex = 66;
            this.btnFocusCheckStart.Text = "Fcus. Start";
            this.btnFocusCheckStart.UseVisualStyleBackColor = true;
            this.btnFocusCheckStart.Click += new System.EventHandler(this.btnFocusCheckStart_Click);
            // 
            // btnDeMuraStart
            // 
            this.btnDeMuraStart.Location = new System.Drawing.Point(651, 23);
            this.btnDeMuraStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeMuraStart.Name = "btnDeMuraStart";
            this.btnDeMuraStart.Size = new System.Drawing.Size(150, 40);
            this.btnDeMuraStart.TabIndex = 59;
            this.btnDeMuraStart.Text = "Dmr Start";
            this.btnDeMuraStart.UseVisualStyleBackColor = true;
            this.btnDeMuraStart.Click += new System.EventHandler(this.btnDeMuraStart_Click);
            // 
            // btnAbortDeMura
            // 
            this.btnAbortDeMura.Location = new System.Drawing.Point(651, 227);
            this.btnAbortDeMura.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbortDeMura.Name = "btnAbortDeMura";
            this.btnAbortDeMura.Size = new System.Drawing.Size(150, 40);
            this.btnAbortDeMura.TabIndex = 63;
            this.btnAbortDeMura.Text = "Abort Dmr";
            this.btnAbortDeMura.UseVisualStyleBackColor = true;
            this.btnAbortDeMura.Click += new System.EventHandler(this.btnAbortDeMura_Click);
            // 
            // userMove1
            // 
            this.userMove1.BackColor = System.Drawing.SystemColors.Control;
            this.userMove1.Dock = System.Windows.Forms.DockStyle.Left;
            this.userMove1.Location = new System.Drawing.Point(0, 0);
            this.userMove1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userMove1.Name = "userMove1";
            this.userMove1.Size = new System.Drawing.Size(427, 273);
            this.userMove1.TabIndex = 30;
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(834, 222);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(135, 25);
            this.txtCode.TabIndex = 35;
            // 
            // FormManualCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 740);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbMove);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormManualCheck";
            this.ShowIcon = false;
            this.Text = "手动检测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManualCheck_FormClosing);
            this.Load += new System.EventHandler(this.FormManualCheck_Load);
            this.gbMove.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMove;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private UserMove userMove1;
        private System.Windows.Forms.Button btnCloseIo;
        private System.Windows.Forms.Button btnStation_1;
        private System.Windows.Forms.Button btnOpenIo;
        private System.Windows.Forms.Button btnStation_3;
        private System.Windows.Forms.Button btnStation_4;
        private System.Windows.Forms.ComboBox cbbIO;
        private System.Windows.Forms.Button btnStation_2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnFlashWrite;
        private System.Windows.Forms.ComboBox cbbPgSelect;
        private System.Windows.Forms.Button btnSetRaster;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFlashWrite;
        private System.Windows.Forms.Button btnGetState;
        private System.Windows.Forms.TextBox txtSetRaster;
        private System.Windows.Forms.Button btnGetRemainingCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnFlashResult;
        private System.Windows.Forms.Button btnSeqEnd;
        private System.Windows.Forms.Button btnTblRotate;
        private System.Windows.Forms.Button btnSeqStart;
        private System.Windows.Forms.Button btnFlashErase;
        private System.Windows.Forms.Button btnPanelOff;
        private System.Windows.Forms.Button btnCaptureStart;
        private System.Windows.Forms.Button btnPanelOn;
        private System.Windows.Forms.Button btnCaptureResult;
        private System.Windows.Forms.Button btnDeMraCheckResult;
        private System.Windows.Forms.Button btnAlignmentStart;
        private System.Windows.Forms.Button btnDeMuraCheck;
        private System.Windows.Forms.Button btnAlignmentStop;
        private System.Windows.Forms.Button btnDeMuraResult;
        private System.Windows.Forms.Button btnFocusCheckStart;
        private System.Windows.Forms.Button btnDeMuraStart;
        private System.Windows.Forms.Button btnAbortDeMura;
        private System.Windows.Forms.Button btnSweep;
        private System.Windows.Forms.Button btnCheckLock;
        private System.Windows.Forms.TextBox txtLock;
        private System.Windows.Forms.TextBox txtCode;
    }
}