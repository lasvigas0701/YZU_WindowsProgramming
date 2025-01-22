using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_09_2
{
    public partial class Form1 : Form
    {
        Image img; // Image 影像
        Image imgThumbnail; // Image 影像 小圖
        public Form1()
        {
            InitializeComponent();
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
            imgThumbnail = img.GetThumbnailImage(50, (int)(50 * img.Height / img.Width), null, (IntPtr)0);
            Invalidate(); // 要求重畫
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // 儲存影像檔
            {
                String output = saveFileDialog1.FileName;
                imgThumbnail.Save(output);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)  // 呈現 Image 影像
                e.Graphics.DrawImage(img, 10, 100, img.Width, img.Height);

            if (imgThumbnail != null) // 呈現 Image 影像 小圖
                e.Graphics.DrawImage(imgThumbnail, 250, 10, imgThumbnail.Width, imgThumbnail.Height);
        }
    }
}
