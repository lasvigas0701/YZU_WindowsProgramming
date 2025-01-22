using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_hw4
{
    public partial class Form1 : Form
    {
        Point ball = new Point(10, 50);
        Point panel = new Point(10, 270);
        Color color = Color.Red;

        int speed_x = 1;
        int speed_y = 1;
        int seconds = 0;
        int speed = 1;
        bool stop = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ball = new Point(10, 50);
            panel = new Point(10, 270);
            color = Color.Red;
            seconds = 0;
            speed = 1;
            timer1.Start();
            timer2.Start();
            stop = false;
            toolStripStatusLabel1.Text = "0";
            toolStripStatusLabel2.Text = "Playing";
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 0, 50, 200, 220);
            
            Brush brush = new SolidBrush(color);
            e.Graphics.FillEllipse(brush, ball.X, ball.Y, 10, 10);

            Brush brush1 = new SolidBrush(Color.Red);
            e.Graphics.FillRectangle(brush1, panel.X, panel.Y, 40, 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds % 5 == 0) speed++;
            toolStripStatusLabel1.Text = seconds.ToString();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!stop)
            {   
                panel.X = e.X - 20; // the center of the panel is where the mouse exists.
                if (e.X < 20) panel.X = 0;
                if (e.X > 180) panel.X = 160;
                Invalidate();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!stop)
            {
                color = Color.Red;
                Invalidate();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!stop)
            {
                color = Color.Green;
                Invalidate();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!stop)
            {
                color = Color.Blue;
                Invalidate();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ball.X < 0 || ball.X > 190)
            {
                speed_x = -speed_x;
            }
            if (ball.Y < 50)
            {
                speed_y = -speed_y;
            }
            if (ball.Y >= 260 && ball.X + 5 >= panel.X && ball.X + 5 <= panel.X + 40)
            {
                speed_y = -speed_y;
                ball.Y = 270 - 10;
            }
            else if (ball.Y >= 260)
            {
                timer1.Stop();
                timer2.Stop();
                stop = true;
                ball.Y = 270 - 10;
                toolStripStatusLabel2.Text = "Game Over";
            }

            if (!stop)
            {
                ball.X += speed_x * speed;
                ball.Y += speed_y * speed;
            }
            Invalidate();
        }
    }
}
