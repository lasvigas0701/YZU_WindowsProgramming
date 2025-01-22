using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_03_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p1 = new Pen(Color.Blue, 5);
            e.Graphics.DrawEllipse(p1, 30, 30, 200, 200); // left end is x = 30, up end is y = 30
                                                          // horizontal and vertical axis lenth = 200
            Pen p2 = new Pen(Color.Black, 5);
            e.Graphics.DrawEllipse(p2, 80, 80, 20, 20);
            e.Graphics.DrawEllipse(p2, 160, 80, 20, 20);
            Pen p3 = new Pen(Color.Red, 5);
            e.Graphics.DrawArc(p3, 70, 70, 120, 120, 0, 180); // left end is x = 70, up end is y = 70
                                                              // diameter = 120, the angle of arc is 180
        }
    }
}
