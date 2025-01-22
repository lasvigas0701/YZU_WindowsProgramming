using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace _1113341_hw6
{
    public partial class Form1 : Form
    {
        Random rd = new Random();
        Image bowl = Properties.Resources.Bowl;
        List<Image> fruit = new List<Image>(new Image[] { Properties.Resources.Banana, Properties.Resources.StawBerry, Properties.Resources.Tomato });
        List<Image> background = new List<Image>(new Image[] { Properties.Resources.Hydrangeas, Properties.Resources.Penguins, Properties.Resources.Tulips });
        Point[] fruitPt = new Point[] { new Point(200, 0), new Point(300, -100), new Point(168, -200) };
        Point bowlPt = new Point(256, 402);
        int[] initialX = new int[] { 0, -100, -200 };
        int t, bg, score;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(512, 500);
            Point bowlPt = new Point(256, 402);
            bg = 0;
            score = 0;
            t = 120;
            timer1.Start();
            timer2.Start();
            timer3.Start();
            label1.Text = "Remaining Time: " + t.ToString() + " Seconds";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float[][] cmArray =
            {
                new float[] {1, 0, 0, 0, 0}, //R
                new float[] {0, 1, 0, 0, 0}, //G
                new float[] {0, 0, 1, 0, 0}, //B
                new float[] {0, 0, 0, 0.5f, 0}, //A
                new float[] {0, 0, 0, 0, 1} 
            };
            ColorMatrix cm = new ColorMatrix(cmArray);
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            e.Graphics.DrawImage(background[bg], new Rectangle(0, 20, background[bg].Width / 2, background[bg].Height / 2), 0, 0, background[bg].Width, background[bg].Height, GraphicsUnit.Pixel, ia);
            e.Graphics.DrawImage(bowl, new Rectangle(bowlPt.X, bowlPt.Y, bowl.Width, bowl.Height), 0, 0, bowl.Width, bowl.Height, GraphicsUnit.Pixel);
            for (int i = 0; i < 3; i++)
            {
                e.Graphics.DrawImage(fruit[i], new Rectangle(fruitPt[i].X, fruitPt[i].Y, fruit[i].Width, fruit[i].Height), 0, 0, fruit[i].Width, fruit[i].Height, GraphicsUnit.Pixel);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            bowlPt.X = e.X - 35; // 70/2 is the half of the bowl width
            if (bowlPt.X < 0)
                bowlPt.X = 0;
            else if (bowlPt.X > 512 - 70) // 512 is the width of the form
                bowlPt.X = 512 - 70;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t--;
            label1.Text = "Remaining Time: " + t.ToString() + " Seconds";
            if (t == 0)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = "Score: " + score.ToString();
            for (int i = 0; i < 3; i++)
            {
                if (fruitPt[i].Y > 370)
                {
                    if (fruitPt[i].X >= bowlPt.X && fruitPt[i].X <= bowlPt.X + 70)
                        score++;
                    
                    fruitPt[i] = new Point(rd.Next(0, 400), initialX[i]);
                }
                else
                    fruitPt[i].Y += 2;
            }
            Graphics g = CreateGraphics();
            g.DrawImage(bowl, new Rectangle(bowlPt.X, bowlPt.Y, bowl.Width, bowl.Height), 0, 0, bowl.Width, bowl.Height, GraphicsUnit.Pixel);
            Invalidate();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            bg = (bg + 1) % 3;
            Invalidate(); 
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            Form1_Load(sender, e);
        }
    }
}
