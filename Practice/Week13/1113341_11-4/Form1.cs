using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_11_4
{
    public partial class Form1 : Form
    {
        Bitmap img, imgClone; //  影像
        Bitmap img2, img2Clone;  // 透明的影像
        Point MousePos;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // 開啟影像檔
            {
                String input = openFileDialog1.FileName;
                img = (Bitmap)Image.FromFile(input); // 產生一個Bitmap物件
                if ((ClientSize.Width < img.Width) || (ClientSize.Height < img.Height))
                    ClientSize = new Size(img.Width, img.Height);
                backImageClone();
                Invalidate(); // 要求重畫
            }

        }

        float r1, g1, b1, a1, r2, g2, b2, a2;

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            r2 = (float)trackBar5.Value / 10;
            foreImageClone();
            Invalidate();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            g2 = (float)trackBar6.Value / 10;
            foreImageClone();
            Invalidate();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            b2 = (float)trackBar7.Value / 10;
            foreImageClone();
            Invalidate();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            a2 = (float)trackBar8.Value / 10;
            foreImageClone();
            Invalidate();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            a1 = (float)trackBar4.Value / 10;
            backImageClone();
            Invalidate();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            b1 = (float)trackBar3.Value / 10;
            backImageClone();
            Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            g1 = (float)trackBar2.Value / 10;
            backImageClone();
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            r1 = (float)trackBar1.Value / 10;
            backImageClone();
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                Rectangle rectDest1 = new Rectangle(0, 0, imgClone.Width, imgClone.Height);
                e.Graphics.DrawImage(imgClone, rectDest1);
            }
            Rectangle rectDest2 = new Rectangle(MousePos.X - img2Clone.Width / 2, MousePos.Y - img2Clone.Height / 2, img2Clone.Width, img2Clone.Height);
            e.Graphics.DrawImage(img2Clone, rectDest2);

        }

        public Form1()
        {
            InitializeComponent();
            img2 = Properties.Resources.butterfly;
            DoubleBuffered = true;
            r1 = g1 = b1 = a1 = 1;
            r2 = g2 = b2 = a2 = 0.5f;
            trackBar1.Value = trackBar2.Value = trackBar3.Value = trackBar4.Value = 10;
            trackBar5.Value = trackBar6.Value = trackBar7.Value = trackBar8.Value = 5;
            foreImageClone();
        }

        void backImageClone()
        {
            imgClone = (Bitmap)img.Clone();
            int x, y;
            // 重設 img 的 圖素
            for (x = 0; x < imgClone.Width; x++)
            {
                for (y = 0; y < imgClone.Height; y++)
                {
                    Color pixelColor = imgClone.GetPixel(x, y); // 得到圖素
                    Color newColor = pixelColor;
                    newColor = Color.FromArgb(pixelColor.A * trackBar4.Value / 10, pixelColor.R * trackBar1.Value / 10, pixelColor.G * trackBar2.Value / 10, pixelColor.B * trackBar3.Value / 10);
                    imgClone.SetPixel(x, y, newColor); // 設定圖素
                }
            }
        }

        void foreImageClone()
        {
            img2Clone = (Bitmap)img2.Clone();
            int x1, y1;
            // 重設 img 的 圖素
            for (x1 = 0; x1 < img2Clone.Width; x1++)
            {
                for (y1 = 0; y1 < img2Clone.Height; y1++)
                {
                    Color pixelColor = img2Clone.GetPixel(x1, y1); // 得到圖素
                    Color newColor = pixelColor;
                    newColor = Color.FromArgb(pixelColor.A * trackBar8.Value / 10, pixelColor.R * trackBar5.Value / 10, pixelColor.G * trackBar6.Value / 10, pixelColor.B * trackBar7.Value / 10);
                    img2Clone.SetPixel(x1, y1, newColor); // 設定圖素
                }
            }
        }

    }
}
