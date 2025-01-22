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

namespace _1113341_07_3
{
    public partial class Form1 : Form
    {
        Color c;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            c = Color.White;
            Size = new Size(320, 320);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point[] pt = new Point[3];
            pt[0] = new Point(0, 0);
            pt[1] = new Point(150, 150);
            pt[2] = new Point(300, 0);
            PathGradientBrush pb = new PathGradientBrush(pt);
            pb.CenterColor = c;
            Color[] colorArray = new Color[] { Color.Red, Color.Green, Color.Blue };
            pb.SurroundColors = colorArray;
            e.Graphics.FillRectangle(pb, 0, 0, 300, 150);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            c = Color.White;
            Invalidate();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            c = Color.Yellow;
            Invalidate();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            c = Color.Black;
            Invalidate();
        }
    }
}
