using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_03_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point[] pt1 = new Point[5];
            Point[] pt2 = new Point[5];
            int Cx = this.ClientSize.Width / 2;  // center point is the center of the window
            int Cy = this.ClientSize.Height / 2;
            int D = (int)(Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 2) - 10; // radius
            double Theta1 = -Math.PI / 2.0; // angle
            double Theta2 = -Math.PI / 2.0;
            for (int i = 0; i < 5; i++)
            {
                pt1[i].X = Cx + (int)(D * Math.Cos(Theta1));
                pt1[i].Y = Cy + (int)(D * Math.Sin(Theta1));
                pt2[i].X = Cx + (int)(D * Math.Cos(Theta2));
                pt2[i].Y = Cy + (int)(D * Math.Sin(Theta2));
                Theta1 += Math.PI * 2.0 / 5.0;  // Pentagon
                Theta2 += 2 * Math.PI * 2.0 / 5.0; // Pentagram
            }

            e.Graphics.DrawPolygon(Pens.Black, pt1); // draw pentagon
            e.Graphics.DrawPolygon(Pens.Black, pt2); // draw pentagram
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
