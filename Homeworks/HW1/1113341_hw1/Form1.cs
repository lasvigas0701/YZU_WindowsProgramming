using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_hw1
{
    public partial class Form1 : Form
    {
        int r, g, b;
        Random rd = new Random();
        Rectangle[] recs = new Rectangle[9];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int initx = 0, inity = 0, len = 50;

            for (int i = 0; i < 9; i++)
            {
                r = rd.Next(256); g = rd.Next(256); b = rd.Next(256);
                Brush brush = new SolidBrush(Color.FromArgb(r, g, b));
                recs[i] = new Rectangle(initx + 50 * (i % 3), inity + 50 * (i / 3), len, len);
                e.Graphics.FillRectangle(brush, recs[i]);
                e.Graphics.DrawRectangle(Pens.Black, recs[i]);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            r = rd.Next(256); g = rd.Next(256); b = rd.Next(256);

            Graphics gr = this.CreateGraphics();
            for (int i = 0; i < 9; i++)
            {
                if (recs[i].Contains(e.Location))
                {
                    Brush brush = new SolidBrush(Color.FromArgb(r, g, b));
                    gr.FillRectangle(brush, recs[i]);
                    break;
                }
            }
            gr.DrawRectangles(Pens.Black, recs);
        }
    }
}
