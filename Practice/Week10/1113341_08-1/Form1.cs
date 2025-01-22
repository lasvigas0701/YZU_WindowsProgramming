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

namespace _1113341_08_1
{
    public partial class Form1 : Form
    {
        HatchBrush myBrush1 = new HatchBrush(HatchStyle.Cross, Color.Red);
        float theta = 0; // rotation angle
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int Cx = this.ClientSize.Width / 2; // the center of the form
            int Cy = this.ClientSize.Height / 2;//
            int D = 20; // radius of the circle
            int D2 = 100; // radius of the orbit

            e.Graphics.ResetTransform();
            e.Graphics.FillEllipse(Brushes.Gray, Cx - D, Cy - D, 2 * D, 2 * D); // draw the sun
            e.Graphics.DrawEllipse(Pens.Silver, Cx - D2, Cy - D2, 2 * D2, 2 * D2); // draw the orbit
            e.Graphics.TranslateTransform(D2, 0, MatrixOrder.Append);  // move to the orbit
            e.Graphics.RotateTransform(theta, MatrixOrder.Append);
            e.Graphics.TranslateTransform(Cx, Cy, MatrixOrder.Append); // move to the center of the form
            e.Graphics.FillEllipse(myBrush1, 0 - D, 0 - D, 2 * D, 2 * D); // draw        

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            theta = theta + 1;  // 旋轉角度 遞增
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            timer1.Start();
        }
    }
}
