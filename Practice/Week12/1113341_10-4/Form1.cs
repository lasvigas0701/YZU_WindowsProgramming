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

namespace _1113341_10_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(500, 400);
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            int Cx = ClientSize.Width / 2; // 視窗客戶區的中心點
            int Cy = ClientSize.Height / 2;

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
            gp.AddCurve(pt, 0.6f);

            //心臟左邊的曲線 順時鐘方向 由下往上 定義點的座標
            PointF[] pt2 = new PointF[]{
                          new PointF(x, y+ 7 *D),
                          new PointF(x-4*D, y+3*D),
                          new PointF(x-5*D, y),
                          new PointF(x-3*D, y - 1.5f*D),
                          new PointF(x, y),
                          };
            gp.AddCurve(pt2, 0.6f);

            if (comboBox1.SelectedIndex == 1)  // 單色塗刷
                e.Graphics.FillPath(Brushes.Red, gp); // 填滿形狀區域
            else if (comboBox1.SelectedIndex == 2) // 樣式塗刷一
            {
                HatchBrush myBrush1 = new HatchBrush(HatchStyle.DiagonalCross, Color.Gold, Color.Red);
                e.Graphics.FillPath(myBrush1, gp); //填滿形狀區域
            }

            else if (comboBox1.SelectedIndex == 3) // 樣式塗刷二
            {
                HatchBrush myBrush2 = new HatchBrush(HatchStyle.SolidDiamond, Color.Gold, Color.Red);
                e.Graphics.FillPath(myBrush2, gp); //填滿形狀區域
            }
            else if (comboBox1.SelectedIndex == 4) // 使用圖形塗刷
            {
                Bitmap bm = new Bitmap(Properties.Resources.butterfly);
                TextureBrush myBrush3 = new TextureBrush(bm);  // 圖形塗刷
                e.Graphics.FillPath(myBrush3, gp); //填滿形狀區域
            }
            e.Graphics.DrawPath(Pens.Black, gp); //繪出圖形軌跡

        }
    }
}
