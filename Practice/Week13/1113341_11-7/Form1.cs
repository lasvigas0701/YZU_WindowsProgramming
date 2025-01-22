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

namespace _1113341_11_7
{
    public partial class Form1 : Form
    {
        int x = 0, y = 0, x2 = 0, y2 = 0, x_d, y_d;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRegion(Brushes.Blue, r1);
            if (inRegion)
                e.Graphics.FillRegion(new SolidBrush(Color.FromArgb(120, 0, 0, 255)), r3);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!inRegion && (r1.IsVisible(e.Location)))
            {
                inRegion = true;
                x_d = e.Location.X - x;
                y_d = e.Location.Y - y;
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (inRegion)
            {
                inRegion = false;
                x = e.Location.X - x_d;
                y = e.Location.Y - y_d;
                GenerateRegion();
                Invalidate();
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (inRegion && (e.Button == MouseButtons.Left))
            {
                x2 = e.Location.X - x_d;
                y2 = e.Location.Y - y_d;
                GenerateRegion2();
                Invalidate();
            }
        }

        Region r1, r2, r3, r4;
        bool inRegion = false;
        public Form1()
        {
            InitializeComponent();
            GenerateRegion();
            ClientSize = new Size(400, 400);
            DoubleBuffered = true;
        }

        void GenerateRegion()
        {
            GraphicsPath gp1 = new GraphicsPath(); // 圖形軌跡
            gp1.AddEllipse(x + 20, y + 20, 100, 100);
            GraphicsPath gp2 = new GraphicsPath(); // 圖形軌跡
            gp2.AddRectangle(new Rectangle(x + 20, y + 100, 100, 100));
            r1 = new Region(gp1); // Region 區域表面 物件
            r2 = new Region(gp2); // Region 區域表面 物件
            r1.Union(r2);
        }

        void GenerateRegion2()
        {
            GraphicsPath gp1 = new GraphicsPath(); // 圖形軌跡
            gp1.AddEllipse(x2 + 20, y2 + 20, 100, 100);
            GraphicsPath gp2 = new GraphicsPath(); // 圖形軌跡
            gp2.AddRectangle(new Rectangle(x2 + 20, y2 + 100, 100, 100));
            r3 = new Region(gp1); // Region 區域表面 物件
            r4 = new Region(gp2); // Region 區域表面 物件
            r3.Union(r4);
        }
    }
}
