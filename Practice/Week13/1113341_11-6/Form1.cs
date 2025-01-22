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

namespace _1113341_11_6
{
    public partial class Form1 : Form
    {
        Region r1, r2;
        bool inRegion = false;
        GraphicsPath gp1, gp2;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (inRegion)
                e.Graphics.FillRegion(Brushes.Red, r1); // r1 區域表面  繪出
            else
                e.Graphics.FillRegion(Brushes.Silver, r1); // r1 區域表面  繪出
            
            e.Graphics.DrawPath(Pens.Black, gp1); // 圖形軌跡 繪出
            e.Graphics.DrawPath(Pens.Black, gp2); // 圖形軌跡 繪出
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            generateRegion();
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            generateRegion();
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (r1.IsVisible(e.Location) && (inRegion == false))
            {
                inRegion = true;
                Invalidate();
            }
            else if (!r1.IsVisible(e.Location) && (inRegion == true))
            {
                inRegion = false;
                Invalidate();
            }
        }

        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(360, 360);
            generateRegion();
        }

        void generateRegion()
        {
            int Cx = ClientSize.Width / 2; // 視窗客戶區的中心點
            int Cy = ClientSize.Height / 2;
            gp1 = new GraphicsPath(); // 圖形軌跡
            gp1.AddEllipse(Cx - 50 - 100, Cy - 100, 200, 200);
            gp2 = new GraphicsPath(); // 圖形軌跡
            gp2.AddEllipse(Cx + 50 - 100, Cy - 100, 200, 200);
            r1 = new Region(gp1); // Region 區域表面 物件
            r2 = new Region(gp2); // Region 區域表面 物件

            if (radioButton1.Checked)
                r1.Union(r2);  // r1 = r1 + r2    聯集
            else if (radioButton2.Checked)
                r1.Intersect(r2); // r1 = r1 - r2   交集
            else if (radioButton3.Checked)
                r1.Exclude(r2); // r1 = r1 - r2   排除
            else
                if (radioButton4.Checked)
                r1.Xor(r2);  // r1 = r1 + r2 - (r1 Intersect r2)  互斥   
        }

    }
}
