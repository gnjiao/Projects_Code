using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    public partial class FormWriteFlashMemory : Form
    {
        #region 属性

        private string filePath = "";
        private bool isUploadFile = false;
        public string FilePath { get { return filePath; } }
        public bool IsUploadFile { get { return isUploadFile; } }

        #endregion

        #region 构造函数

        public FormWriteFlashMemory()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件

        private void btnTransFileSel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select transfer file.";
                dialog.Filter = string.Format("{0} file(.{0})|*.{0}", "bin");
                dialog.Filter += string.Format("|{0} file(.{0})|*.{0}", "*");
                if (dialog.ShowDialog() != DialogResult.OK) return;

                this.txtTransFile.Text = dialog.FileName;
                this.filePath = dialog.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.isUploadFile = this.ckbUploadFile.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}
