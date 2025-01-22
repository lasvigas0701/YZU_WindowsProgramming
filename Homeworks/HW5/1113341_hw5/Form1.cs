using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_hw5
{
    public partial class Form1 : Form
    {
        Rectangle[] box = new Rectangle[17]; // 16 boxes
        int[] fruitType = new int[16]; // record what fruit is in each box, 0 for empty
        bool needCheck = false;
        Image back = Properties.Resources._8_0;
        int prev, now, match = 0, time = -1;
        bool playing = true;
        bool[] isBack = new bool[16];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int length = 50;
            for (int i = 0; i < 16; i++)
            {
                box[i] = new Rectangle(2 + (i % 4) * length, 30 + (i / 4) * length, length, length);
                e.Graphics.DrawImage(back, box[i].X + 2, box[i].Y + 2, 48, 48);
            }
            for (int i = 0; i < 5; i++)
            {
                e.Graphics.DrawLine(Pens.Black, 2 + i * length, 30, 2 + i * length, 230);
                e.Graphics.DrawLine(Pens.Black, 2, 30 + i * length, 202, 30 + i * length);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            for (int i = 0; i < 16; i++)
            {
                fruitType[i] = 0;
                isBack[i] = true;
            }

            Graphics g = this.CreateGraphics();
            for (int first = 1; first < 17; first++)
            {
                int rd = new Random().Next(16);
                if (fruitType[rd] == 0)
                {
                    Image fruit = Properties.Resources.ResourceManager.GetObject("_8_" + (first % 8 + 1).ToString()) as Image;
                    fruitType[rd] = first % 8 + 1;
                    //g.DrawImage(fruit, box[rd].X + 2, box[rd].Y + 2, 48, 48);
                }
                else
                {
                    first--;
                }
            }
            Invalidate();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playing = true;
            time = -1;
            match = 0;
            Form1_Load(sender, e);
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(playing)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (box[i].Contains(e.Location) && isBack[i])
                    {
                        Graphics g = this.CreateGraphics();
                        g.DrawImage(Properties.Resources.ResourceManager.GetObject("_8_" + fruitType[i].ToString()) as Image, box[i].X + 2, box[i].Y + 2, 48, 48);
                        if (!needCheck)
                        {
                            isBack[i] = false;
                            prev = i;
                        }
                        else
                        {
                            if (fruitType[prev] == fruitType[i] && prev != i) //match
                            {
                                match++;
                                isBack[i] = false;
                            }
                            else if (prev != i)
                            {
                                isBack[prev] = true;
                                isBack[i] = true;
                                playing = false;
                                timer2.Start();
                                now = i;
                            }
                            else needCheck = !needCheck;
                        }
                        needCheck = !needCheck;
                        break;
                    }    
                }
                if (match == 8)
                {
                    timer1.Stop();
                    playing = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label1.Text = time.ToString() + " Second(s)";
        }

        private void timer2_Tick(object sender, EventArgs e)
        { 
            playing = true;
            timer2.Stop();
            Graphics g = this.CreateGraphics();
            g.DrawImage(back, box[prev].X + 2, box[prev].Y + 2, 48, 48);
            g.DrawImage(back, box[now].X + 2, box[now].Y + 2, 48, 48);
        }

    }
}
