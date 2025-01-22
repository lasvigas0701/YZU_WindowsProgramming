using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_03_7
{
    public partial class Form1 : Form
    {
        Rectangle rec1 = new Rectangle(0, 0, 150, 150);
        Rectangle rec2 = new Rectangle(0, 150, 150, 150);
        Brush b1 = new SolidBrush(Color.Red);
        Brush b2 = new SolidBrush(Color.Blue);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (rec1.Contains(e.Location))
            {
                Graphics g = this.CreateGraphics();
                g.FillRectangle(b1, e.X, e.Y, 3, 3);
            }
            if (rec2.Contains(e.Location))
            {
                Graphics g = this.CreateGraphics();
                g.FillRectangle(b2, e.X, e.Y, 3, 3);
            }

        }
    }
}
