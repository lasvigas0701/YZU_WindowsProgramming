using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_08_6
{
    public partial class Form1 : Form
    {
        Point[] pt = new Point[3];
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(550, 450);
            pt[0] = new Point(-7, -40);
            pt[1] = new Point(0, -65);
            pt[2] = new Point(7, -40);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 50, 50, 450, 300);
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 50, 50, 225, 150);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 130, 90, 70, 70);
            e.Graphics.TranslateTransform(165, 125);
            for (int i = 0; i < 12; i++)
            {
                e.Graphics.FillPolygon(new SolidBrush(Color.White), pt);
                e.Graphics.RotateTransform(30);
            }
        }
    }
}
