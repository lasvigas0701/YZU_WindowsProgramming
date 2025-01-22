using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_14_4
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

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Visible = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            panel1.Left = (Width - panel1.Width) / 2;
            panel1.Top = (Height - panel1.Height) / 2;
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "yzu")
                Application.Exit();
            else
                MessageBox.Show("密碼錯誤!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            randomBG();
        }
    }
}
