using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_14_6
{
    public partial class Form1 : Form
    {
        Image[] image = new Image[9];
        PictureBox[] pb = new PictureBox[9];
        Random rd = new Random(DateTime.Now.Minute + DateTime.Now.Second);
        // 0 1 2
        // 3 4 5 
        // 6 7 8
        Point[] LegalMove = new Point[] //合法移動的方式 Point(從,到)
           { new Point(0,1), new Point(0,3),
              new Point(1,0), new Point(1,4), new Point(1,2),
              new Point(2,1), new Point(2,5),
              new Point(3,0), new Point(3,4), new Point(3,6),
              new Point(4,1), new Point(4,3), new Point(4,7), new Point(4,5),
              new Point(5,2), new Point(5,4), new Point(5,8),
              new Point(6,3), new Point(6,7),
              new Point(7,4), new Point(7,6), new Point(7,8),
              new Point(8,5), new Point(8,7),
            };
        int Count = 0; //用了幾步
        bool restart = false; //是否重置狀態

        public Form1()
        {
            InitializeComponent();
            image[0] = null;
            image[1] = new Bitmap(Properties.Resources.icon1);
            image[2] = new Bitmap(Properties.Resources.icon2);
            image[3] = new Bitmap(Properties.Resources.icon3);
            image[4] = new Bitmap(Properties.Resources.icon4);
            image[5] = new Bitmap(Properties.Resources.icon5);
            image[6] = new Bitmap(Properties.Resources.icon6);
            image[7] = new Bitmap(Properties.Resources.icon7);
            image[8] = new Bitmap(Properties.Resources.icon8);
            pictureBox10.Image = new Bitmap(Properties.Resources.NumgerPadGoal);

            pb[0] = pictureBox1;
            pb[1] = pictureBox2;
            pb[2] = pictureBox3;
            pb[3] = pictureBox4;
            pb[4] = pictureBox5;
            pb[5] = pictureBox6;
            pb[6] = pictureBox7;
            pb[7] = pictureBox8;
            pb[8] = pictureBox9;

            button1_Click(this, null); //起始

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                pb[i].Tag = (i + 1) % 9; //利用Tag屬性儲存位置資料，照順序排列: 1 2 3 4 5 6 7 8 0
                pb[i].Enabled = true;
            }
            for (int i = 0; i < 9; i++)
                pb[i].Image = image[(int)pb[i].Tag]; //指定點陣圖   

            //亂數重置數字拼盤
            restart = true;
            for (int i = 0; i < 1000; i++)
            {
                pictureBox1_Click(pb[rd.Next(9)], null);
            }
            restart = false;

            Count = 0;
            label3.Text = Count.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox x = (PictureBox)sender;
            int SelectedNo = 0;

            for (int i = 0; i < 9; i++)
            {
                if (pb[i] == x)
                {
                    SelectedNo = i; //點選位置
                    break;
                }
            }

            int EmptyNo = 0;
            for (int i = 0; i < 9; i++)
            {
                if ((int)pb[i].Tag == 0)
                {
                    EmptyNo = i; //空格位置
                    break;
                }
            }

            //移動
            for (int i = 0; i < 24; i++)
            {
                if (LegalMove[i].X == SelectedNo && LegalMove[i].Y == EmptyNo)
                {
                    Count++;
                    label3.Text = Count.ToString();

                    pb[EmptyNo].Tag = pb[SelectedNo].Tag; //對調數字
                    pb[SelectedNo].Tag = 0;
                    pb[EmptyNo].Image = image[(int)pb[EmptyNo].Tag]; //對調圖片
                    pb[SelectedNo].Image = null;
                    break;
                }
            }

            //檢查是否完成
            if (restart == false)
                if ((int)pb[0].Tag == 1 && (int)pb[1].Tag == 2 && (int)pb[2].Tag == 3 &&
                    (int)pb[3].Tag == 4 && (int)pb[4].Tag == 5 && (int)pb[5].Tag == 6 &&
                    (int)pb[6].Tag == 7 && (int)pb[7].Tag == 8 && (int)pb[8].Tag == 0)
                {
                    for (int i = 0; i < 9; i++)
                        pb[i].Enabled = false;
                    MessageBox.Show("恭喜! 完成了!");
                }

        }
    }
}
