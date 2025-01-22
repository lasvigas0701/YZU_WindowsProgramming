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

namespace _1113341_10_7
{
    public partial class Form1 : Form
    {
        Image img; //  影像
        Point mousePos; // 滑鼠位置
        int D = 100; // 放大鏡半徑

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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //反鋸齒呈現
                e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height); // 呈現原圖
                Rectangle rectDest = new Rectangle(mousePos.X - D, mousePos.Y - D, 2 * D, 2 * D);
                texBrush.ResetTransform();  // 塗刷的轉換矩陣 = 單位矩陣
                texBrush.TranslateTransform(-mousePos.X, -mousePos.Y); // 塗刷對齊 滑鼠位置
                e.Graphics.FillEllipse(texBrush, rectDest); // 使用影像塗刷 繪出圓形
                e.Graphics.DrawEllipse(Pens.Black, rectDest); // 放大鏡外框
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location; // 記錄 滑鼠位置
            Invalidate(); // 要求更新表單
        }
    }
}
