using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _1113341_07_7
{
    public partial class Form1 : Form
    {
        Bitmap bm = new Bitmap(Properties.Resources.butterfly);
        float theta = 0; // 旋轉角度

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int Cx = this.ClientSize.Width / 2;
            int Cy = this.ClientSize.Height / 2;
            e.Graphics.ResetTransform(); // identity matrix
            e.Graphics.TranslateTransform(-bm.Width / 2, -bm.Height / 2, MatrixOrder.Append); // move to the center of the image
            e.Graphics.RotateTransform(theta, MatrixOrder.Append);
            // multiply the current matrix by a rotation matrix
            e.Graphics.TranslateTransform(Cx, Cy, MatrixOrder.Append);
            // move to the center of the form
            TextureBrush tb = new TextureBrush(bm);
            e.Graphics.FillRectangle(tb, 0, 0, 100, 100);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            theta = theta + 2;  // 旋轉角度 遞增
            Invalidate();
        }
    }
}
