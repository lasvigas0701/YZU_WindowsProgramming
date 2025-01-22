using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_09_1
{
    public partial class Form1 : Form
    {
        Image img;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // 開啟影像檔
            {
                String input = openFileDialog1.FileName;
                img = Image.FromFile(input); // 產生一個Image物件

                // 呈現 影像 的寬高資訊
                label1.Text = "(" + img.Width.ToString() + ", " + img.Height.ToString() + ")";
                Invalidate(); // 要求重畫
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            img.RotateFlip(RotateFlipType.Rotate90FlipNone); // 影像旋轉90度
            label1.Text = "(" + img.Width.ToString() + ", " + img.Height.ToString() + ")";
            Invalidate(); // 要求重畫
        }

        private void button3_Click(object sender, EventArgs e)
        {
            img.RotateFlip(RotateFlipType.RotateNoneFlipX); // 影像水平翻轉
            label1.Text = "(" + img.Width.ToString() + ", " + img.Height.ToString() + ")";
            Invalidate(); // 要求重畫
        }

        private void button4_Click(object sender, EventArgs e)
        {
            img.RotateFlip(RotateFlipType.RotateNoneFlipY); // 影像垂直翻轉
            label1.Text = "(" + img.Width.ToString() + ", " + img.Height.ToString() + ")";
            Invalidate(); // 要求重畫
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // 儲存影像檔
            {
                String output = saveFileDialog1.FileName;
                img.Save(output);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
                e.Graphics.DrawImage(img, 10, 50, img.Width, img.Height);
        }
    }
}
