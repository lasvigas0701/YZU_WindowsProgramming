using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_03_3
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        int D = 1; // speed of increment

        public Form1()
        {
            InitializeComponent();
            int x = this.ClientSize.Width / 2; // center
            int y = this.ClientSize.Height / 2;
            rect = new Rectangle(x - 50, y - 50, 100, 100); // rectangle with height = 100 & width = 100
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, rect); // draw rectangle
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (rect.Bottom >= this.ClientSize.Height ||
                rect.Top <= 0 || rect.Left <= 0 || rect.Right >= this.ClientSize.Width)
                // reach the edge
                D = -1;        // Contraction
            else if (rect.Height < 10) //
                D = 1;                 // expansion
            rect.Inflate(D, D);
            Invalidate();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int x = this.ClientSize.Width / 2;
            int y = this.ClientSize.Height / 2;
            rect = new Rectangle(x - 50, y - 50, 100, 100);
        }
    }
}
