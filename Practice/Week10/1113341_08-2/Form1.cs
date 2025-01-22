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

namespace _1113341_08_2
{
    public partial class Form1 : Form
    {
        HatchBrush myBrush1 = new HatchBrush(HatchStyle.Cross, Color.Red);
        float theta = 0; // angle
        int i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int Cx = this.ClientSize.Width / 2; // center of the form
            int Cy = this.ClientSize.Height / 2;
            int D = 20;
            int D2 = 100;

            e.Graphics.ResetTransform();
            e.Graphics.FillEllipse(Brushes.Gray, Cx - D, Cy - D, 2 * D, 2 * D); //畫出正中心圓點 
            e.Graphics.DrawEllipse(Pens.Silver, Cx - D2, Cy - D2, 2 * D2, 2 * D2); //畫出軌道

            if (i == 0)
            {
                e.Graphics.DrawLine(Pens.Blue, -2 * Cx, 0, 2 * Cx, 0);
                e.Graphics.DrawLine(Pens.Blue, 0, -2 * Cy, 0, 2 * Cy);
                e.Graphics.FillEllipse(myBrush1, 0 - D, 0 - D, 2 * D, 2 * D); //畫出旋轉的圓點 
            }
            e.Graphics.TranslateTransform(D2, 0, MatrixOrder.Append);  // 先平移到 旋轉的半徑邊緣
            if (i == 1)
            {
                e.Graphics.DrawLine(Pens.Blue, -2 * Cx, 0, 2 * Cx, 0);
                e.Graphics.DrawLine(Pens.Blue, 0, -2 * Cy, 0, 2 * Cy);
                e.Graphics.FillEllipse(myBrush1, 0 - D, 0 - D, 2 * D, 2 * D); //畫出旋轉的圓點 
            }
            e.Graphics.RotateTransform(theta, MatrixOrder.Append);  // 乘上 旋轉矩陣
            if (i == 2)
            {
                e.Graphics.DrawLine(Pens.Blue, -2 * Cx, 0, 2 * Cx, 0);
                e.Graphics.DrawLine(Pens.Blue, 0, -2 * Cy, 0, 2 * Cy);
                e.Graphics.FillEllipse(myBrush1, 0 - D, 0 - D, 2 * D, 2 * D); //畫出旋轉的圓點 
            }
            e.Graphics.TranslateTransform(Cx, Cy, MatrixOrder.Append); // 再位移到軌道上
            if (i == 3)
            {
                e.Graphics.DrawLine(Pens.Blue, -2 * Cx, 0, 2 * Cx, 0);
                e.Graphics.DrawLine(Pens.Blue, 0, -2 * Cy, 0, 2 * Cy);
                e.Graphics.FillEllipse(myBrush1, 0 - D, 0 - D, 2 * D, 2 * D); //畫出旋轉的圓點 
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (i < 3)
                i++;
            else
            {
                i = 0;
                theta = theta + 5; // 旋轉角度 遞增
            }
            Invalidate();
        }
    }
}
