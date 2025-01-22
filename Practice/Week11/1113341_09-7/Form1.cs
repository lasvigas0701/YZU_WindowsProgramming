using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_09_7
{
    public partial class Form1 : Form
    {
        Image img1 = Properties.Resources.apple;
        Image img2 = Properties.Resources.butterfly;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)   // Click at right button
            {
                Graphics g1 = CreateGraphics();
                //g1.DrawImage(img1, e.X - img1.Width / 2, e.Y - img1.Height / 2, img1.Width, img1.Height);
                //g1.DrawImage(img1, e.X + img1.Width/2, e.Y + img1.Height / 2, -img1.Width, -img1.Height); // Draw image in reverse
                //g1.DrawImage(img1, e.X + img1.Width / 2, e.Y - img1.Height / 2, -img1.Width, img1.Height); // 左右翻轉
                g1.DrawImage(img1, e.X - img1.Width / 2, e.Y + img1.Height / 2, img1.Width, -img1.Height); // 上下翻轉
            }
            else
            {
                Graphics g1 = CreateGraphics();
                g1.DrawImage(img2, e.X - img2.Width / 2, e.Y - img2.Height / 2, img2.Width, img2.Height);
            }
        }
    }
}
