using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _1113341_03_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 3);  // size is 3
            pen1.DashStyle = DashStyle.Dash;
            e.Graphics.DrawLine(pen1, 10, 10, 200, 10);

            pen1.DashStyle = DashStyle.DashDot;
            e.Graphics.DrawLine(pen1, 10, 40, 200, 40);
            
            pen1.DashStyle = DashStyle.DashDotDot;
            e.Graphics.DrawLine(pen1, 10, 70, 200, 70);
            
            pen1.DashStyle = DashStyle.Dot;
            e.Graphics.DrawLine(pen1, 10, 100, 200, 100);
            
            pen1.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(pen1, 10, 130, 200, 130);

            Pen pen2 = new Pen(Color.Black, 10);
            int X = 10;
            int Y = 160;
            pen2.StartCap = LineCap.Flat; 
            pen2.EndCap = LineCap.Flat;
            e.Graphics.DrawLine(pen2, X, Y, X + 200, Y);

            Y = Y + 30;
            pen2.StartCap = LineCap.Square;
            pen2.EndCap = LineCap.Square;
            e.Graphics.DrawLine(pen2, X, Y, X + 200, Y); 
            
            Y = Y + 30;
            pen2.StartCap = LineCap.Round;
            pen2.EndCap = LineCap.Round;
            e.Graphics.DrawLine(pen2, X, Y, X + 200, Y);

            Y = Y + 30;
            pen2.StartCap = LineCap.Triangle;
            pen2.EndCap = LineCap.Triangle;
            e.Graphics.DrawLine(pen2, X, Y, X + 200, Y);

            Y = Y + 30;
            pen2.StartCap = LineCap.SquareAnchor;
            pen2.EndCap = LineCap.SquareAnchor;
            e.Graphics.DrawLine(pen2, X, Y, X + 200, Y);

            Y = Y + 30;
            pen2.StartCap = LineCap.RoundAnchor;
            pen2.EndCap = LineCap.RoundAnchor;
            e.Graphics.DrawLine(pen2, X, Y, X + 200, Y);

            Y = Y + 30;
            pen2.StartCap = LineCap.DiamondAnchor;
            pen2.EndCap = LineCap.DiamondAnchor;
            e.Graphics.DrawLine(pen2, X, Y, X + 200, Y);

            Y = Y + 30;
            pen2.StartCap = LineCap.ArrowAnchor;
            pen2.EndCap = LineCap.ArrowAnchor;
            e.Graphics.DrawLine(pen2, X, Y, X + 200, Y);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(300, 450);
        }
    }
}
