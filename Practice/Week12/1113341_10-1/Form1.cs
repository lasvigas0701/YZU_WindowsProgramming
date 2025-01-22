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

namespace _1113341_10_1
{
    public partial class Form1 : Form
    {
        List<Point> startPt = new List<Point>();
        List<Point> endPt = new List<Point>();
        Point pt;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            pt = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            startPt.Add(pt);
            endPt.Add(e.Location);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 1);
            GraphicsPath gp = new GraphicsPath();
            //method 1
            for (int i = 0; i < endPt.Count(); i++)
            {
                gp.AddLine(startPt[i], endPt[i]);
                gp.CloseFigure();
            }
            e.Graphics.DrawPath(Pens.Black, gp);
        }
    }
}
