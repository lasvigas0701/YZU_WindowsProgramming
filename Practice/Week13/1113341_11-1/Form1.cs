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

namespace _1113341_11_1
{
    public partial class Form1 : Form
    {
        Image img; //  影像
        Point mousePos; // 滑鼠位置
        Pen myPen;
        SolidBrush myBrush;
        int a1;
        int a2;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // 開啟影像檔
            {
                String input = openFileDialog1.FileName;
                img = Image.FromFile(input); // 產生一個Image物件
                if ((ClientSize.Width < img.Width) || (ClientSize.Height < img.Height))
                    ClientSize = new Size(img.Width, img.Height);
                Invalidate(); // 要求重畫
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = 50;
            trackBar2.Value = 50;
            a1 = trackBar1.Value;
            a2 = trackBar2.Value;
            myPen =
             new Pen(Color.FromArgb(a1, 0, 255, 0), 50); // 透明的畫筆
            myBrush =
             new SolidBrush(Color.FromArgb(a2, 0, 0, 255)); // 透明的塗刷
            ClientSize = new Size(400, 400);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height); // 呈現原圖
                GraphicsPath gp = new GraphicsPath(); // GraphicsPath圖形軌跡物件
                PointF[] pt1 = new PointF[5]; //心形右邊的曲線
                PointF[] pt2 = new PointF[5]; //心形左邊的曲線
                GetPointF(mousePos.X, mousePos.Y, 20, pt1, pt2); //計算心形左右邊的曲線
                gp.AddCurve(pt1, 0.6f);  // 心形曲線 的外框
                gp.AddCurve(pt2, 0.6f);
                e.Graphics.FillPath(myBrush, gp); //填滿形狀區域 使用影像塗刷 繪出心形
                e.Graphics.DrawPath(Pens.Black, gp); // 放大鏡外框
                e.Graphics.DrawLine(myPen, 0, 100, img.Width, 100); // 畫出透明的直線
            }
        }

        void GetPointF(int x, int y, int D, PointF[] pt1, PointF[] pt2)
        {
            //心形右邊的曲線 由上往下
            pt1[0] = new PointF(x, y);
            pt1[1] = new PointF(x + 3 * D, y - 1.5f * D);
            pt1[2] = new PointF(x + 5 * D, y);
            pt1[3] = new PointF(x + 4 * D, y + 3 * D);
            pt1[4] = new PointF(x, y + 7 * D);
            //心形左邊的曲線 順時間方向 由下往上 定義點的座標
            pt2[0] = new PointF(x, y + 7 * D);
            pt2[1] = new PointF(x - 4 * D, y + 3 * D);
            pt2[2] = new PointF(x - 5 * D, y);
            pt2[3] = new PointF(x - 3 * D, y - 1.5f * D);
            pt2[4] = new PointF(x, y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location;
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            a1 = trackBar1.Value;
            myPen = new Pen(Color.FromArgb(a1, 0, 255, 0), 40);
            Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            a2 = trackBar2.Value;
            myBrush = new SolidBrush(Color.FromArgb(a2, 0, 0, 255));
            Invalidate();
        }
    }
}
