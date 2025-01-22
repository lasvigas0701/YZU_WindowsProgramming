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

namespace _1113341_08_8
{
    public partial class Form1 : Form
    {
        Point[] pt1 = new Point[4];
        Point[] pt2 = new Point[4];
        Point[] pt3 = new Point[4];
        int len;

        void adjustSize()
        {
            len = this.ClientSize.Width > this.ClientSize.Height ? this.ClientSize.Height : this.ClientSize.Width;
            pt1[0] = new Point(0, 10);
            pt1[1] = new Point(10, 0);
            pt1[2] = new Point(0, -len / 6);
            pt1[3] = new Point(-10, 0);
            pt2[0] = new Point(0, 10);
            pt2[1] = new Point(10, 0);
            pt2[2] = new Point(0, -len / 4);
            pt2[3] = new Point(-10, 0);
            pt3[0] = new Point(0, 10);
            pt3[1] = new Point(10, 0);
            pt3[2] = new Point(0, -len / 3);
            pt3[3] = new Point(-10, 0);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(400, 400);
            timer1.Interval = 1000;
            timer1.Start();
            adjustSize();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(this.ClientSize.Width / 2,
                                          this.ClientSize.Height / 2);
            for (int i = 0; i < 60; i++)
            {
                int size = i % 5 == 0 ? 10 : 5;
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), 0 - size / 2, len / 2 - size, size, size);
                e.Graphics.RotateTransform(6);
            }
            DateTime t = DateTime.Now; // 目前的時間
            // 繪出 時針
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            // 旋轉表單畫布 1個小時為30度 要把分鐘轉為小時的小數部分 
            e.Graphics.RotateTransform(((t.Hour % 12) + (t.Minute / 60.0f)) * 30.0f);
            e.Graphics.DrawPolygon(new Pen(Color.Red), pt1);

            // 繪出 分針
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            // 旋轉表單畫布 1分鐘為6度 要把秒數轉為分鐘的小數部分
            e.Graphics.RotateTransform((t.Minute + t.Second / 60.0f) * 6.0f);
            e.Graphics.DrawPolygon(new Pen(Color.Blue), pt2);

            // 繪出 秒針
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            // 旋轉表單畫布 1秒鐘為6度
            e.Graphics.RotateTransform(t.Second * 6.0f);
            e.Graphics.DrawPolygon(new Pen(Color.Black), pt3);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            adjustSize();
            Invalidate();
        }
    }
}
