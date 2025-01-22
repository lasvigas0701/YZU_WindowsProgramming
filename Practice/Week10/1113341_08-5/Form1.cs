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

namespace _1113341_08_5
{
    public partial class Form1 : Form
    {
        Bitmap bm = new Bitmap(Properties.Resources.butterfly);
        int translateX = 0, translateY = 0, rotate = 0;
        double scale = 1;
        int Cx, Cy;

        public Form1()
        {
            InitializeComponent();
            Cx = this.ClientSize.Width / 2; // 視窗客戶區正中心點
            Cy = this.ClientSize.Height / 2;//
            trackBar1.Value = 50;
            trackBar2.Value = 50;
            trackBar3.Value = 180;
            trackBar4.Value = 10;
            translateX = (int)((double)(trackBar1.Value - 50) / 200 * Cx) - (bm.Width / 2);
            translateY = (int)((double)(trackBar2.Value - 50) / 200 * Cy) - (bm.Height / 2);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ResetTransform(); // 畫布的矩陣 = 單位矩陣
            e.Graphics.TranslateTransform(-bm.Width / 2, -bm.Height / 2, MatrixOrder.Append);
            e.Graphics.RotateTransform(rotate, MatrixOrder.Append);
            e.Graphics.ScaleTransform((float)scale, (float)scale, MatrixOrder.Append);
            e.Graphics.TranslateTransform(Cx + translateX, Cy + translateY, MatrixOrder.Append);
            TextureBrush tb = new TextureBrush(bm);
            e.Graphics.FillRectangle(tb, 0, 0, 100, 100); // 繪出圖形
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            translateX = (int)((double)(trackBar1.Value - 50) / 200 * Cx) - (bm.Width / 2);
            translateY = (int)((double)(trackBar2.Value - 50) / 200 * Cy) - (bm.Height / 2);
            rotate = trackBar3.Value - 180;
            scale = (double)trackBar4.Value / 10;
            Invalidate();
        }

        private void trackBar1_Resize(object sender, EventArgs e)
        {
            Cx = this.ClientSize.Width / 2; // 視窗客戶區正中心點
            Cy = this.ClientSize.Height / 2;//
            Invalidate();
        }

    }
}
