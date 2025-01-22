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

namespace _1113341_08_4
{
    public partial class Form1 : Form
    {
        double xScale = 1; // X 軸縮放倍數
        double yScale = 1; // Y 軸縮放倍數
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(450, 450);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int Cx = this.ClientSize.Width / 2; // 視窗客戶區正中心點
            int Cy = this.ClientSize.Height / 2;//
            int D = 100; // 球本身的半徑
            e.Graphics.ResetTransform(); // 畫布的矩陣 = 單位矩陣
            e.Graphics.DrawEllipse(Pens.Silver, Cx - D, Cy - D, 2 * D, 2 * D); //畫出開始的圓
            e.Graphics.ScaleTransform((float)xScale, (float)yScale, MatrixOrder.Append);  // 乘上 縮放矩陣
            e.Graphics.TranslateTransform(Cx, Cy, MatrixOrder.Append); // 再搬到視窗客戶區正中心點
            e.Graphics.DrawEllipse(Pens.Red, 0 - D, 0 - D, 2 * D, 2 * D); //畫出縮放後的圓
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xScale = xScale - 0.1;
            if (xScale <= 0.1) xScale = 0.1;
            label2.Text = xScale.ToString();
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xScale = xScale + 0.1;
            label2.Text = xScale.ToString();
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yScale = yScale - 0.1;
            if (yScale <= 0.1) yScale = 0.1;
            label4.Text = yScale.ToString();
            Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yScale = yScale + 0.1;
            label4.Text = yScale.ToString();
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
