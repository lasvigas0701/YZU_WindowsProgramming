using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_07_5
{
    public partial class Form1 : Form
    {
        Bitmap image;
        TextureBrush textureBrush;
        Pen myPen;
        int x, y;　// record the last point of the line
        Graphics G;

        public Form1()
        {
            InitializeComponent();
            image = new Bitmap(Properties.Resources.Hydrangeas);
            textureBrush = new TextureBrush(image);
            myPen = new Pen(textureBrush, 40);
            ClientSize = new Size(image.Width, image.Height);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                G = CreateGraphics();
                G.DrawLine(myPen, x, y, e.X, e.Y);　// write to buffer

                x = e.X; // the ending point is the starting point of the next line
                y = e.Y;
            }
        }
    }
}
