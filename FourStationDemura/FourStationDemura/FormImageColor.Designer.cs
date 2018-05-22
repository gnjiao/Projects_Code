namespace FourStationDemura
{
    partial class FormImageColor
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
            this.ckbFactoryMode = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbSelectColor = new System.Windows.Forms.GroupBox();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.nudBlue = new System.Windows.Forms.NumericUpDown();
            this.nudGreen = new System.Windows.Forms.NumericUpDown();
            this.nudRed = new System.Windows.Forms.NumericUpDown();
            this.tbBlue = new System.Windows.Forms.TrackBar();
            this.lblBlue = new System.Windows.Forms.Label();
            this.tbGreen = new System.Windows.Forms.TrackBar();
            this.lblGreen = new System.Windows.Forms.Label();
            this.tbRed = new System.Windows.Forms.TrackBar();
            this.lblRed = new System.Windows.Forms.Label();
            this.ckbMonoColor = new System.Windows.Forms.CheckBox();
            this.gbSelectColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).BeginInit();
            this.SuspendLayout();
            // 
            // ckbFactoryMode
            // 
            this.ckbFactoryMode.AutoSize = true;
            this.ckbFactoryMode.Location = new System.Drawing.Point(259, 269);
            this.ckbFactoryMode.Margin = new System.Windows.Forms.Padding(4);
            this.ckbFactoryMode.Name = "ckbFactoryMode";
            this.ckbFactoryMode.Size = new System.Drawing.Size(125, 19);
            this.ckbFactoryMode.TabIndex = 9;
            this.ckbFactoryMode.Text = "Factory Mode";
            this.ckbFactoryMode.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(292, 339);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(184, 339);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbSelectColor
            // 
            this.gbSelectColor.Controls.Add(this.pnlColor);
            this.gbSelectColor.Controls.Add(this.nudBlue);
            this.gbSelectColor.Controls.Add(this.nudGreen);
            this.gbSelectColor.Controls.Add(this.nudRed);
            this.gbSelectColor.Controls.Add(this.tbBlue);
            this.gbSelectColor.Controls.Add(this.lblBlue);
            this.gbSelectColor.Controls.Add(this.tbGreen);
            this.gbSelectColor.Controls.Add(this.lblGreen);
            this.gbSelectColor.Controls.Add(this.tbRed);
            this.gbSelectColor.Controls.Add(this.lblRed);
            this.gbSelectColor.Location = new System.Drawing.Point(45, 51);
            this.gbSelectColor.Margin = new System.Windows.Forms.Padding(4);
            this.gbSelectColor.Name = "gbSelectColor";
            this.gbSelectColor.Padding = new System.Windows.Forms.Padding(4);
            this.gbSelectColor.Size = new System.Drawing.Size(347, 193);
            this.gbSelectColor.TabIndex = 8;
            this.gbSelectColor.TabStop = false;
            this.gbSelectColor.Text = "Select Color";
            // 
            // pnlColor
            // 
            this.pnlColor.Location = new System.Drawing.Point(11, 153);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(328, 25);
            this.pnlColor.TabIndex = 9;
            // 
            // nudBlue
            // 
            this.nudBlue.Location = new System.Drawing.Point(256, 115);
            this.nudBlue.Margin = new System.Windows.Forms.Padding(4);
            this.nudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudBlue.Name = "nudBlue";
            this.nudBlue.Size = new System.Drawing.Size(83, 25);
            this.nudBlue.TabIndex = 8;
            this.nudBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBlue.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudBlue.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // nudGreen
            // 
            this.nudGreen.Location = new System.Drawing.Point(256, 72);
            this.nudGreen.Margin = new System.Windows.Forms.Padding(4);
            this.nudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudGreen.Name = "nudGreen";
            this.nudGreen.Size = new System.Drawing.Size(83, 25);
            this.nudGreen.TabIndex = 5;
            this.nudGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGreen.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudGreen.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // nudRed
            // 
            this.nudRed.Location = new System.Drawing.Point(256, 30);
            this.nudRed.Margin = new System.Windows.Forms.Padding(4);
            this.nudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRed.Name = "nudRed";
            this.nudRed.Size = new System.Drawing.Size(83, 25);
            this.nudRed.TabIndex = 2;
            this.nudRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRed.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudRed.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // tbBlue
            // 
            this.tbBlue.LargeChange = 30;
            this.tbBlue.Location = new System.Drawing.Point(58, 108);
            this.tbBlue.Margin = new System.Windows.Forms.Padding(4);
            this.tbBlue.Maximum = 255;
            this.tbBlue.Name = "tbBlue";
            this.tbBlue.Size = new System.Drawing.Size(191, 56);
            this.tbBlue.TabIndex = 7;
            this.tbBlue.TickFrequency = 50;
            this.tbBlue.Value = 128;
            this.tbBlue.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Location = new System.Drawing.Point(8, 118);
            this.lblBlue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(39, 15);
            this.lblBlue.TabIndex = 6;
            this.lblBlue.Text = "Blue";
            // 
            // tbGreen
            // 
            this.tbGreen.LargeChange = 30;
            this.tbGreen.Location = new System.Drawing.Point(58, 65);
            this.tbGreen.Margin = new System.Windows.Forms.Padding(4);
            this.tbGreen.Maximum = 255;
            this.tbGreen.Name = "tbGreen";
            this.tbGreen.Size = new System.Drawing.Size(191, 56);
            this.tbGreen.TabIndex = 4;
            this.tbGreen.TickFrequency = 50;
            this.tbGreen.Value = 128;
            this.tbGreen.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Location = new System.Drawing.Point(8, 75);
            this.lblGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(47, 15);
            this.lblGreen.TabIndex = 3;
            this.lblGreen.Text = "Green";
            // 
            // tbRed
            // 
            this.tbRed.LargeChange = 30;
            this.tbRed.Location = new System.Drawing.Point(58, 22);
            this.tbRed.Margin = new System.Windows.Forms.Padding(4);
            this.tbRed.Maximum = 255;
            this.tbRed.Name = "tbRed";
            this.tbRed.Size = new System.Drawing.Size(191, 56);
            this.tbRed.TabIndex = 1;
            this.tbRed.TickFrequency = 50;
            this.tbRed.Value = 128;
            this.tbRed.ValueChanged += new System.EventHandler(this.tbRed_ValueChanged);
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(8, 32);
            this.lblRed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(31, 15);
            this.lblRed.TabIndex = 0;
            this.lblRed.Text = "Red";
            // 
            // ckbMonoColor
            // 
            this.ckbMonoColor.AutoSize = true;
            this.ckbMonoColor.Location = new System.Drawing.Point(56, 269);
            this.ckbMonoColor.Margin = new System.Windows.Forms.Padding(4);
            this.ckbMonoColor.Name = "ckbMonoColor";
            this.ckbMonoColor.Size = new System.Drawing.Size(109, 19);
            this.ckbMonoColor.TabIndex = 9;
            this.ckbMonoColor.Text = "Mono Color";
            this.ckbMonoColor.UseVisualStyleBackColor = true;
            this.ckbMonoColor.CheckedChanged += new System.EventHandler(this.ckbMonoColor_CheckedChanged);
            // 
            // FormImageColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 408);
            this.Controls.Add(this.ckbFactoryMode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckbMonoColor);
            this.Controls.Add(this.gbSelectColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormImageColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置 Panel 显示 图像";
            this.gbSelectColor.ResumeLayout(false);
            this.gbSelectColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbFactoryMode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbSelectColor;
        private System.Windows.Forms.NumericUpDown nudBlue;
        private System.Windows.Forms.NumericUpDown nudGreen;
        private System.Windows.Forms.NumericUpDown nudRed;
        private System.Windows.Forms.TrackBar tbBlue;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.TrackBar tbGreen;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.TrackBar tbRed;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.CheckBox ckbMonoColor;
        private System.Windows.Forms.Panel pnlColor;
    }
}