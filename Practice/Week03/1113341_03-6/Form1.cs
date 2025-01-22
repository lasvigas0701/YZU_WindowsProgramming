using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_03_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p1 = new Pen(Color.Black, 10);
            e.Graphics.DrawEllipse(p1, 30, 30, 200, 200);
            Brush b1 = new SolidBrush(Color.Yellow);
            e.Graphics.FillEllipse(b1, 30, 30, 200, 200);
            Brush b2 = new SolidBrush(Color.Black);
            e.Graphics.FillEllipse(b2, 80, 80, 20, 20);
            e.Graphics.FillEllipse(b2, 160, 80, 20, 20);
            Brush b3 = new SolidBrush(Color.Red);
            e.Graphics.FillPie(b3, 70, 70, 120, 120, 0, 180);
        }
    }
}
