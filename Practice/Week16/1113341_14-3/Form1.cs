﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_14_3
{
    public partial class Form1 : Form
    {
        int img = 0;
        Random r = new Random(DateTime.Now.Second);
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            timer1.Start();
            timer2.Start();
            randomBG();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Application.Exit(); //結束螢幕保護程式
        }

        void randomBG()
        {
            img = r.Next(3);
            switch (img)
            {
                case 0:
                    BackgroundImage = Properties.Resources.Desert;
                    break;
                case 1:
                    BackgroundImage = Properties.Resources.Lighthouse;
                    break;
                case 2:
                    BackgroundImage = Properties.Resources.Tulips;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            randomBG();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            label1.Left -= 5;
            if (label1.Right < 0)
            {
                label1.Left = ClientSize.Width;
                label1.Top = r.Next(Height - label1.Height);
            }
        }
    }
}
