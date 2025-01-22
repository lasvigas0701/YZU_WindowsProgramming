using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_11_5
{
    public partial class Form1 : Form
    {
        Bitmap img, img2; //  影像
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img2 != null)
            {
                Rectangle rectDest = new Rectangle(0, 0, img2.Width, img2.Height);
                e.Graphics.DrawImage(img2, rectDest);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (img2 != null)
            {
                if (e.Button == MouseButtons.Left) // 滑鼠的左鍵
                {
                    if ((e.X < img2.Width) && (e.Y < img2.Height) && (e.X > 0) && (e.Y > 0))
                    {
                        img2.SetPixel(e.X, e.Y, Color.Red);
                        Invalidate();
                    }
                }
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // 開啟影像檔
            {
                String input = openFileDialog1.FileName;
                img = (Bitmap)Image.FromFile(input); // 產生一個Image物件
                if ((ClientSize.Width < img.Width) || (ClientSize.Height < img.Height))
                    ClientSize = new Size(img.Width, img.Height);
                img2 = (Bitmap)img.Clone();
                Invalidate(); // 要求重畫
            }

        }
    }
}
