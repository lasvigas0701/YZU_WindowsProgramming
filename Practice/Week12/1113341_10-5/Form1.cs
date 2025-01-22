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

namespace _1113341_10_5
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Red, 5);
        SolidBrush sb = new SolidBrush(Color.Red);
        GraphicsPath gp1 = new GraphicsPath();
        GraphicsPath gp2 = new GraphicsPath();
        bool fill_1, fill_2;
        public Form1()
        {
            InitializeComponent();
            start();
        }

        void start()
        {
            int Cx = ClientSize.Width / 2;
            int Cy = ClientSize.Height / 3;

            int D = 20;    // 每格 寬
            int x = Cx;    // 心臟的起始點
            int y = Cy - 2 * D;

            //心臟右邊的曲線 由上往下
            PointF[] pt = new PointF[]{
                          new PointF(x, y),
                          new PointF(x+3*D, y - 1.5f*D),
                          new PointF(x+5*D, y),
                          new PointF(x+4*D, y+3*D),
                          new PointF(x, y+ 7 *D),
                          };
            gp1.Reset();
            gp1.AddCurve(pt, 0.6f);

            //心臟左邊的曲線 順時間方向 由下往上 定義點的座標
            PointF[] pt2 = new PointF[]{
                          new PointF(x, y+ 7 *D),
                          new PointF(x-4*D, y+3*D),
                          new PointF(x-5*D, y),
                          new PointF(x-3*D, y - 1.5f*D),
                          new PointF(x, y),
                          };
            gp1.AddCurve(pt2, 0.6f);
            int D2 = 15;
            gp2.Reset(); //結束形狀
            gp2.AddEllipse(Cx - 4 * D2, Cy * 2 + 2 * D2, D2 * 5, D2 * 2);
            gp2.AddEllipse(Cx - D2, Cy * 2 + 2 * D2, D2 * 5, D2 * 2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(myPen, gp1); // 繪製心形 曲線
            e.Graphics.DrawPath(myPen, gp2);
            if (fill_1)
                e.Graphics.FillPath(sb, gp1);
            if (fill_2)
                e.Graphics.FillPath(sb, gp2);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // 滑鼠游標在 gp1 的形狀區域內 而且 未填滿
            if (gp1.IsVisible(e.Location) && !fill_1)
            {
                fill_1 = true;
                Invalidate();  // 要求表單重畫
            }
            // 滑鼠游標不在 gp1 的形狀區域內 而且 已填滿
            else if (!gp1.IsVisible(e.Location) && fill_1)
            {
                fill_1 = false; // 不要填滿
                Invalidate();// 要求表單重畫
            }
            // 滑鼠游標在 gp2 的形狀區域內 而且 未填滿
            if (gp2.IsVisible(e.Location) && !fill_2)
            {
                fill_2 = true;
                Invalidate();  // 要求表單重畫
            }
            // 滑鼠游標不在 gp2 的形狀區域內 而且  已填滿
            else if (!gp2.IsVisible(e.Location) && fill_2)
            {
                fill_2 = false; // 不要填滿
                Invalidate();// 要求表單重畫
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
            start();
        }
    }
}
