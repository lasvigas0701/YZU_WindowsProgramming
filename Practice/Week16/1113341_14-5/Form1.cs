using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_14_5
{
    public partial class Form1 : Form
    {
        Bitmap bg0 = new Bitmap(Properties.Resources.icon0);
        Bitmap bg1 = new Bitmap(Properties.Resources.icon1);
        Bitmap bg2 = new Bitmap(Properties.Resources.icon2);
        Bitmap bg3 = new Bitmap(Properties.Resources.icon3);
        Bitmap bg4 = new Bitmap(Properties.Resources.icon4);
        Bitmap bg5 = new Bitmap(Properties.Resources.icon5);
        Bitmap bg6 = new Bitmap(Properties.Resources.icon6);
        Bitmap bg7 = new Bitmap(Properties.Resources.icon7);
        Bitmap bg8 = new Bitmap(Properties.Resources.icon8);
        Bitmap bg9 = new Bitmap(Properties.Resources.icon9);
        Bitmap bg10 = new Bitmap(Properties.Resources.icon10);

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            TimeRefresh();
        }

        private void TimeRefresh() //更新時間數字
        {
            DateTime t = DateTime.Now; // 目前的時間
            pictureBox1.Image = selectBitmap(t.Hour / 10);
            pictureBox2.Image = selectBitmap(t.Hour % 10);
            pictureBox4.Image = selectBitmap(t.Minute / 10);
            pictureBox5.Image = selectBitmap(t.Minute % 10);
            pictureBox7.Image = selectBitmap(t.Second / 10);
            pictureBox8.Image = selectBitmap(t.Second % 10);
        }

        private Bitmap selectBitmap(int n)
        {
            //回傳相對應點陣圖
            switch (n)
            {
                case 1: return bg1;
                case 2: return bg2;
                case 3: return bg3;
                case 4: return bg4;
                case 5: return bg5;
                case 6: return bg6;
                case 7: return bg7;
                case 8: return bg8;
                case 9: return bg9;
            }
            return bg0; // when n==0
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeRefresh();
        }
    }
}
