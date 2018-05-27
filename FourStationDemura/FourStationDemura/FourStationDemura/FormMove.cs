using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourStationDemura
{
    public partial class FormMove : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public delegate void CloseDelegate();
        public event CloseDelegate CloseEvent;

        public FormMove()
        {
            InitializeComponent();
        }

        private void FormMove_Load(object sender, EventArgs e)
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(width - this.Width, (height - this.Height) / 2);

            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Opacity = 0.9;

            UserMove userMove = new UserMove();
            userMove.Dock = DockStyle.Fill;
            userMove.MouseDown += UserMove_MouseDown;
            this.Controls.Add(userMove);
        }

        private void UserMove_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void FormMove_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color FColor = Color.Red;
            Color TColor = Color.Yellow;
            Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(b, this.ClientRectangle);
        }

        private void FormMove_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.CloseEvent();
        }
    }
}
