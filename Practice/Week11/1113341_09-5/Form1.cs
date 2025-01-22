using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_09_5
{
    public partial class Form1 : Form
    {
        Image img;
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
                ClientSize = new Size(img.Width * 2, img.Height * 2 + 50);
                // + 50 預留選單的高度
                Invalidate(); // 要求重畫
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int Cx = this.ClientSize.Width / 2; // 視窗客戶區 正中心
            int Cy = this.ClientSize.Height / 2;
            if (img != null)
            {
                e.Graphics.DrawImage(img, Cx, Cy, img.Width, img.Height);
                e.Graphics.DrawImage(img, Cx, Cy, -img.Width, img.Height);
                e.Graphics.DrawImage(img, Cx, Cy, img.Width, -img.Height);
                e.Graphics.DrawImage(img, Cx, Cy, -img.Width, -img.Height);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
