using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_10_6
{
    public partial class Form1 : Form
    {
        Image img;
        Point mousePos; // 滑鼠位置
        int D = 100; // 放大鏡半徑
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height); // 呈現原圖
                Rectangle rectDest = new Rectangle(mousePos.X - D, mousePos.Y - D, 2 * D, 2 * D); //目標區域放大兩倍
                Rectangle rectSRC = new Rectangle(mousePos.X - D / 2, mousePos.Y - D / 2, D, D);
                e.Graphics.DrawImage(img, rectDest, rectSRC, GraphicsUnit.Pixel); // 呈現原圖 放大區域
                e.Graphics.DrawRectangle(Pens.Black, rectDest); // 放大鏡外框
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location; // 記錄 滑鼠位置
            Invalidate(); // 要求更新表單
        }
    }
}
