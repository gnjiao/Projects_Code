namespace FourStationDemura
{
    partial class FormWriteFlashMemory
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbTransFile = new System.Windows.Forms.GroupBox();
            this.btnTransFileSel = new System.Windows.Forms.Button();
            this.txtTransFile = new System.Windows.Forms.TextBox();
            this.ckbUploadFile = new System.Windows.Forms.CheckBox();
            this.gbTransFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(399, 209);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(251, 209);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbTransFile
            // 
            this.gbTransFile.Controls.Add(this.btnTransFileSel);
            this.gbTransFile.Controls.Add(this.txtTransFile);
            this.gbTransFile.Location = new System.Drawing.Point(20, 72);
            this.gbTransFile.Margin = new System.Windows.Forms.Padding(4);
            this.gbTransFile.Name = "gbTransFile";
            this.gbTransFile.Padding = new System.Windows.Forms.Padding(4);
            this.gbTransFile.Size = new System.Drawing.Size(502, 107);
            this.gbTransFile.TabIndex = 11;
            this.gbTransFile.TabStop = false;
            this.gbTransFile.Text = "Select transfre file";
            // 
            // btnTransFileSel
            // 
            this.btnTransFileSel.AutoSize = true;
            this.btnTransFileSel.Location = new System.Drawing.Point(439, 45);
            this.btnTransFileSel.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransFileSel.Name = "btnTransFileSel";
            this.btnTransFileSel.Size = new System.Drawing.Size(41, 27);
            this.btnTransFileSel.TabIndex = 1;
            this.btnTransFileSel.Text = "...";
            this.btnTransFileSel.UseVisualStyleBackColor = true;
            this.btnTransFileSel.Click += new System.EventHandler(this.btnTransFileSel_Click);
            // 
            // txtTransFile
            // 
            this.txtTransFile.Location = new System.Drawing.Point(22, 45);
            this.txtTransFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransFile.Name = "txtTransFile";
            this.txtTransFile.Size = new System.Drawing.Size(409, 25);
            this.txtTransFile.TabIndex = 0;
            // 
            // ckbUploadFile
            // 
            this.ckbUploadFile.AutoSize = true;
            this.ckbUploadFile.Location = new System.Drawing.Point(20, 28);
            this.ckbUploadFile.Margin = new System.Windows.Forms.Padding(4);
            this.ckbUploadFile.Name = "ckbUploadFile";
            this.ckbUploadFile.Size = new System.Drawing.Size(117, 19);
            this.ckbUploadFile.TabIndex = 10;
            this.ckbUploadFile.Text = "Upload File";
            this.ckbUploadFile.UseVisualStyleBackColor = true;
            // 
            // FormWriteFlashMemory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 280);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbTransFile);
            this.Controls.Add(this.ckbUploadFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormWriteFlashMemory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Write Flash Memory";
            this.gbTransFile.ResumeLayout(false);
            this.gbTransFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbTransFile;
        private System.Windows.Forms.Button btnTransFileSel;
        private System.Windows.Forms.TextBox txtTransFile;
        private System.Windows.Forms.CheckBox ckbUploadFile;
    }
}