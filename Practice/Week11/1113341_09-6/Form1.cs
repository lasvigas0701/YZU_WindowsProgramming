using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_09_6
{
    public partial class Form1 : Form
    {
        Image img;
        Point MousePos = new Point(); //滑鼠位置
        public Form1()
        {
            InitializeComponent();
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
                int Cx = ClientSize.Width / 2; // 視窗客戶區 正中心
                int Cy = ClientSize.Height / 2;
                Point[] pt = new Point[3];  // 三個點座標 定義一個平形四邊形
                pt[0] = new Point(MousePos.X - img.Width / 2, MousePos.Y); // 左上
                pt[1] = new Point(MousePos.X + img.Width / 2, MousePos.Y); // 右上
                pt[2] = new Point(Cx - img.Width / 2, Cy + img.Height / 2); // 左下
                e.Graphics.DrawImage(img, pt); // 呈現圖型
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MousePos = e.Location; // 記錄滑鼠位置
                Invalidate(); // 要求表單重畫
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
