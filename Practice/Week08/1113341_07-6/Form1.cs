using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_07_6
{
    public partial class Form1 : Form
    {
        Bitmap bm = new Bitmap(Properties.Resources.butterfly);
        Point pos = new Point(); // position of the image
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(pos.X, pos.Y);
            TextureBrush tb = new TextureBrush(bm);
            e.Graphics.FillRectangle(tb, 0, 0, 100, 100);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                pos = new Point(pos.X, pos.Y - 10);
            else if (e.KeyData == Keys.Down)
                pos = new Point(pos.X, pos.Y + 10);
            else if (e.KeyData == Keys.Left)
                pos = new Point(pos.X - 10, pos.Y);
            else if (e.KeyData == Keys.Right)
                pos = new Point(pos.X + 10, pos.Y);
            Invalidate();

        }
    }
}
