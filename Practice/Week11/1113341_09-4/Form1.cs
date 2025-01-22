using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_09_4
{
    public partial class Form1 : Form
    {
        Image img; // Bitmap 影像
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // 開啟影像檔
            {
                String input = openFileDialog1.FileName;
                img = Image.FromFile(input); // 產生一個Image物件
                Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Rectangle rectDest = new Rectangle(0, 0, img.Width, img.Height);
                    Rectangle rectSrc = new Rectangle(0, 0, img.Width, img.Height);
                    e.Graphics.DrawImage(img, rectDest, rectSrc, GraphicsUnit.Pixel); // 呈現原圖
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    Rectangle rectDest = new Rectangle(0, 0, img.Width * 2, img.Height * 2);
                    e.Graphics.DrawImage(img, rectDest); // 呈現原圖2倍
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Rectangle rectDest = new Rectangle(0, 0, img.Width / 2, img.Height / 2);
                    e.Graphics.DrawImage(img, rectDest); // 呈現原圖1/2倍
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    Rectangle rectDest = new Rectangle(0, 0, img.Width / 2, img.Height / 2);
                    Rectangle rectSrc = new Rectangle(0, 0, img.Width / 2, img.Height / 2);
                    e.Graphics.DrawImage(img, rectDest, rectSrc, GraphicsUnit.Pixel); // 呈現原圖左上角1/4
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    Rectangle rectDest = new Rectangle(0, 0, img.Width / 2, img.Height / 2);
                    Rectangle rectSrc = new Rectangle(img.Width / 2, img.Height / 2, img.Width / 2, img.Height / 2);
                    e.Graphics.DrawImage(img, rectDest, rectSrc, GraphicsUnit.Pixel); // 呈現原圖右下角1/4
                }
                else if (comboBox1.SelectedIndex == 5)
                {
                    Rectangle rectDest = new Rectangle(0, 0, img.Width, img.Height);
                    Rectangle rectSrc = new Rectangle(0, 0, img.Width / 2, img.Height / 2);
                    e.Graphics.DrawImage(img, rectDest, rectSrc, GraphicsUnit.Pixel); // 呈現原圖左上角1/4以兩倍呈現
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;  // 預設選項為原圖;
        }
    }
}
