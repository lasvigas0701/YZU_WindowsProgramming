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
using System.Drawing.Imaging;

namespace _1113341_11_2
{
    public partial class Form1 : Form
    {
        Image img; //  影像
        Image img2;  // 透明的影像
        Point MousePos;
        float r1, g1, b1, a1, r2, g2, b2, a2;

        public Form1()
        {
            InitializeComponent();
            img2 = Properties.Resources.butterfly;
            DoubleBuffered = true;
            r1 = g1 = b1 = a1 = 1;
            r2 = g2 = b2 = a2 = 0.5f;
            trackBar1.Value = trackBar2.Value = trackBar3.Value = trackBar4.Value = 10;
            trackBar5.Value = trackBar6.Value = trackBar7.Value = trackBar8.Value = 5;
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                // 色彩調整矩陣
                float[][] cmArray1 =
                {
                  new float[] {r1, 0, 0, 0,    0},
                  new float[] {0, g1, 0, 0,    0},
                  new float[] {0, 0, b1, 0,    0},
                  new float[] {0, 0, 0, a1,    0},
                  new float[] {0, 0, 0, 0,     1}
                };
                ColorMatrix cm1 = new ColorMatrix(cmArray1);
                ImageAttributes ia1 = new ImageAttributes();
                ia1.SetColorMatrix(cm1,
                    ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap);
                // 繪出透明的背景影像
                Rectangle rectDest = new Rectangle(0, 0, img.Width, img.Height);
                e.Graphics.DrawImage(img,
                    rectDest,
                    0, 0, img.Width, img.Height,
                    GraphicsUnit.Pixel, ia1);

                // 色彩調整矩陣
                float[][] cmArray2 =
                {
                  new float[] {r2, 0, 0, 0,    0},
                  new float[] {0, g2, 0, 0,    0},
                  new float[] {0, 0, b2, 0,    0},
                  new float[] {0, 0, 0, a2,    0},
                  new float[] {0, 0, 0, 0,     1}
                };
                ColorMatrix cm2 = new ColorMatrix(cmArray2);
                ImageAttributes ia2 = new ImageAttributes();
                ia2.SetColorMatrix(cm2,
                    ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap);
                // 繪出透明的前景影像
                e.Graphics.DrawImage(img2,
                    new Rectangle(MousePos.X - img2.Width / 2, MousePos.Y - img2.Height / 2, img2.Width, img2.Height),
                    0, 0, img2.Width, img2.Height,
                    GraphicsUnit.Pixel, ia2);
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            r1 = (float)trackBar1.Value / 10;
            Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            g1 = (float)trackBar2.Value / 10;
            Invalidate();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            b1 = (float)trackBar3.Value / 10;
            Invalidate();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            a1 = (float)trackBar4.Value / 10;
            Invalidate();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            r2 = (float)trackBar5.Value / 10;
            Invalidate();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            g2 = (float)trackBar6.Value / 10;
            Invalidate();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            b2 = (float)trackBar7.Value / 10;
            Invalidate();
        }
        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            a2 = (float)trackBar8.Value / 10;
            Invalidate();
        }
    }
}
