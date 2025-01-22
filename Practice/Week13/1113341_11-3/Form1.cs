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

namespace _1113341_11_3
{
    public partial class Form1 : Form
    {
        Bitmap img, img2;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // 開啟影像檔
            {
                String input = openFileDialog1.FileName;
                img = (Bitmap)Image.FromFile(input); // 產生一個Image物件
                if ((ClientSize.Width < img.Width) || (ClientSize.Height < img.Height))
                    ClientSize = new Size(img.Width, img.Height);
                imgClone();
                Invalidate(); // 要求重畫
            }

        }

        //  Method 2: ColorMatrix  Quicker
        void imgClone()
        {
            int x, y;
            img2 = (Bitmap)img.Clone(); // 重設 img2 的 圖素
            if (radioButton1.Checked == false)
            {
                float r, g, b;
                if (radioButton2.Checked) r = 1;
                else r = 0;
                if (radioButton3.Checked) g = 1;
                else g = 0;
                if (radioButton4.Checked) b = 1;
                else b = 0;

                float[][] cmArray1 =
                {
                  new float[] {r, 0, 0, 0,    0},
                  new float[] {0, g, 0, 0,    0},
                  new float[] {0, 0, b, 0,    0},
                  new float[] {0, 0, 0, 1,    0},
                  new float[] {0, 0, 0, 0,     1}
                };
                ColorMatrix cm1 = new ColorMatrix(cmArray1);
                ImageAttributes ia1 = new ImageAttributes();
                ia1.SetColorMatrix(cm1,
                    ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap);

                Rectangle rectDest = new Rectangle(0, 0, img.Width, img.Height);
                Graphics g2 = Graphics.FromImage(img2);
                g2.DrawImage(img,
                    rectDest,
                    0, 0, img.Width, img.Height,
                    GraphicsUnit.Pixel, ia1);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img2 != null)
            {
                Rectangle rectDest = new Rectangle(0, 0, img2.Width, img2.Height);
                e.Graphics.DrawImage(img2, rectDest);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (img != null)
            {
                imgClone();
                Invalidate();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
