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

namespace _1113341_10_8
{
    public partial class Form1 : Form
    {
        Image img; //  影像
        Point mousePos; // 滑鼠位置
        Image imgDouble; // 兩倍影像的點陣圖物件
        TextureBrush texBrush; // 兩倍影像的塗刷
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
                imgDouble = new Bitmap(img.Width * 2, img.Height * 2); // 新增點陣圖物件
                Graphics G = Graphics.FromImage(imgDouble); // 由點陣圖物件產生畫布
                Rectangle rectDest = new Rectangle(0, 0, imgDouble.Width, imgDouble.Height);
                Rectangle rectSrc = new Rectangle(0, 0, img.Width, img.Height);
                G.DrawImage(img, rectDest, rectSrc, GraphicsUnit.Pixel); // 放大兩倍
                texBrush = new TextureBrush(imgDouble);  // 兩倍影像的塗刷
                Invalidate(); // 要求重畫
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height); // 呈現原圖
                texBrush.ResetTransform();  // 塗刷的轉換矩陣 = 單位矩陣
                texBrush.TranslateTransform(-mousePos.X, -mousePos.Y); // 塗刷對齊 滑鼠位置
                GraphicsPath gp = new GraphicsPath(); // GraphicsPath圖形軌跡物件
                PointF[] pt1 = new PointF[5]; //心形右邊的曲線
                PointF[] pt2 = new PointF[5]; //心形左邊的曲線
                GetPointF(mousePos.X - 20, mousePos.Y, 20, pt1, pt2); //計算心形左右邊的曲線
                gp.AddCurve(pt1, 0.6f);  // 心形曲線 的外框
                gp.AddCurve(pt2, 0.6f);
                e.Graphics.FillPath(texBrush, gp); //填滿形狀區域 使用影像塗刷 繪出心形
                e.Graphics.DrawPath(Pens.Black, gp); // 放大鏡外框
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location; // 記錄 滑鼠位置
            Invalidate(); // 要求更新表單
        }
    }
}
