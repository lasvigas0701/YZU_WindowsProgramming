using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_hw2
{
    public partial class Form1 : Form
    {
        Rectangle[] recs = new Rectangle[9];
        bool winner = false; // determine if there is a winner
        int[] drawn = new int[9] {0,0,0,0,0,0,0,0,0}; // 0: not drawn, 1: O, -1: X
        int count = 0; // count the number of drawn squares
        int tmp = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int len = 60; // length of the square
            for (int i = 0; i < 9; i++)
            {
                // "2" is the start x-coordinate, "30" is the start y-coordinate 
                recs[i] = new Rectangle(2 + 60 * (i % 3), 30 + 60 * (i / 3), len, len);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 3), recs[i]);
            }
            label1.Text = " ";
        }

        private void computerDraw()
        {
            Graphics g = this.CreateGraphics();
            while (true)
                    {
                        Random rd = new Random();
                        int r = rd.Next(9);
                        if (drawn[r] == 0)
                        {
                            count++;
                            g.DrawLine(new Pen(Color.Blue, 3), recs[r].X + 10, recs[r].Y + 10, recs[r].X + 50, recs[r].Y + 50); // draw "\" line
                            g.DrawLine(new Pen(Color.Blue, 3), recs[r].X + 50, recs[r].Y + 10, recs[r].X + 10, recs[r].Y + 50); // draw "/" line
                            drawn[r] = -1;
                            checkWin(-1);
                            break;
                        }
                    }
        }

        private void checkWin(int p)
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 3; i ++)
            {
                // check the horizontal line, i.e. 0, 1, 2; 3, 4, 5; 6, 7, 8
                if (drawn[i * 3] != 0 && drawn[i * 3] == drawn[i * 3 + 1] && drawn[i * 3 + 1] == drawn[i * 3 + 2])
                {
                    g.DrawLine(new Pen(Color.Red, 3), recs[i * 3].X + 10, recs[i * 3].Y + 30, recs[i * 3 + 2].X + 50, recs[i * 3 + 2].Y + 30);
                    if (p == 1)
                        label1.Text = "You win!";
                    else
                        label1.Text = "You lose!";
                    winner = true;
                    break;
                }

                // check the vertical line, i.e. 0, 3, 6; 1, 4, 7; 2, 5, 8
                if (drawn[i] != 0 && drawn[i] == drawn[i + 3] && drawn[i + 3] == drawn[i + 6])
                {
                    g.DrawLine(new Pen(Color.Red, 3), recs[i].X + 30, recs[i].Y + 10, recs[i + 6].X + 30, recs[i + 6].Y + 50);
                    if (p == 1)
                        label1.Text = "You win!";
                    else
                        label1.Text = "You lose!";
                    winner = true;
                    break;
                }
            }
            // check the diagonal "\"
            if (drawn[0] != 0 && drawn[0] == drawn[4] && drawn[4] == drawn[8])
            {
                g.DrawLine(new Pen(Color.Red, 3), recs[0].X + 30, recs[0].Y + 30, recs[8].X + 30, recs[8].Y + 30);
                if (p == 1)
                    label1.Text = "You win!";
                else
                    label1.Text = "You lose!";
                winner = true;
            }
            // check the diagonal "/"
            if (drawn[2] != 0 && drawn[2] == drawn[4] && drawn[4] == drawn[6])
            {
                g.DrawLine(new Pen(Color.Red, 3), recs[2].X + 30, recs[2].Y + 30, recs[6].X + 30, recs[6].Y + 30);
                if (p == 1)
                    label1.Text = "You win!";
                else
                    label1.Text = "You lose!";
                winner = true;
            }
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 9; i++)
            {
                if (recs[i].Contains(e.Location) && drawn[i] == 0 && !winner)
                {
                    count++;
                    g.DrawEllipse(new Pen(Color.Blue, 3), recs[i].X + 10, recs[i].Y + 10, 40, 40);
                    drawn[i] = 1;
                    checkWin(1);
                    if (!winner && count != 9) computerDraw(); // computer draw
                }
            }
            if (!winner && count == 9) // if no winner and all squares are drawn
            {
                label1.Text = "Draw!";
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {

            winner = false; // determine if there is a winner
            drawn = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 0: not drawn, 1: O, -1: X
            count = 0; // count the number of drawn squares
            Invalidate();
        }
    }
}
