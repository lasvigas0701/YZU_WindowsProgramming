using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_07_4
{
    public partial class Form1 : Form
    {
        Bitmap bm = new Bitmap(Properties.Resources.Chrysanthemum);
        Boolean small = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            TextureBrush myBrush;
            if (small)
            {
                Rectangle rect = new Rectangle(0, 0, 100, 100);
                myBrush = new TextureBrush(bm, rect);
            }
            else
                myBrush = new TextureBrush(bm);

            e.Graphics.FillEllipse(myBrush, 20, 20, this.ClientSize.Width - 40, this.ClientSize.Height - 100);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            small = true;
            Invalidate();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            small = false;
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
