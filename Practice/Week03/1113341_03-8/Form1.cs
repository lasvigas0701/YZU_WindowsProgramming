using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_03_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int x, y, r, g, b;
            Random rd = new Random();
            Brush b1;
            Graphics g1 = this.CreateGraphics();
            g1.Clear(Color.White);       //fill with white === reset the window
            for (int i = 0; i < 10; i++)
            {
                x = 10 + rd.Next(260);  //generate a number x that [10+0, 10+260)
                y = 10 + rd.Next(260);
                r = rd.Next(256); //generate a number r that [0, 255]
                g = rd.Next(256);
                b = rd.Next(256);
                b1 = new SolidBrush(Color.FromArgb(r, g, b));
                g1.FillEllipse(b1, x - 5, y - 5, 10, 10);
            }

        }
    }
}
