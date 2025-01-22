using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_09_3
{
    public partial class Form1 : Form
    {
        Image img; // Image 影像
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // 設定影像縮放模式
            pictureBox1.BorderStyle = BorderStyle.FixedSingle; //設定邊線
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // 開啟影像檔
            {
                String input = openFileDialog1.FileName;
                img = Image.FromFile(input); // 產生一個Image物件
                pictureBox1.Image = img;
                // 呈現 影像 的寬高資訊
                label1.Text = "(" + img.Width.ToString() + ", " + img.Height.ToString() + ")";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            img.RotateFlip(RotateFlipType.Rotate90FlipNone); // 影像旋轉90度
            label1.Text = "(" + img.Width.ToString() + ", " + img.Height.ToString() + ")";
            pictureBox1.Image = img;
            pictureBox1.Refresh(); // pictureBox1 重畫
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // 儲存影像檔
            {
                String output = saveFileDialog1.FileName;
                img.Save(output);
            }
        }
    }
}
