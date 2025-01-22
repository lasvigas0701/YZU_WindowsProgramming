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

namespace _1113341_07_2
{

    public partial class Form1 : Form
    {
        int x, y;
        Color color1, color2;
        Point p1, p2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush lb = new LinearGradientBrush(p1, p2, color1, color2);
            e.Graphics.FillRectangle(lb, 0, 0, x, y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = 180;
            y = 180;
            color1 = Color.White;
            color2 = Color.Red;
            p1 = new Point(0, 0);
            p2 = new Point(x, y);
            Size = new Size(600, 400);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            p1 = new Point(0, 0);
            p2 = new Point(x, y);
            Invalidate();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            p1 = new Point(x, y);
            p2 = new Point(0, 0);
            Invalidate();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            color1 = Color.White;
            Invalidate();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            color1 = Color.Yellow;
            Invalidate();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            color1 = Color.Black;
            Invalidate();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            color2 = Color.Red;
            Invalidate();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            color2 = Color.Green;
            Invalidate();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            color2 = Color.Blue;
            Invalidate();
        }
    }
}
