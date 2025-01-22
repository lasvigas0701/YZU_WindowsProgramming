using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_03_5
{
    public partial class Form1 : Form
    {
        int startAngle = -10;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int Cx = this.ClientSize.Width / 2;
            int Cy = this.ClientSize.Height / 2;
            int D = (int)(Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 2) - 10; //radius
            for (int i = 0; i < 18; i++)
            {
                if (i % 2 == 0) // output when even num
                    e.Graphics.DrawPie(Pens.Black, Cx - D, Cy - D, 2 * D, 2 * D, startAngle + i * 20, 20);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startAngle = startAngle + 1;
            Invalidate();

        }
    }
}
