using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_02_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep(262, 500); // C
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Beep(294, 500); // D
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.Beep(330, 500); // E
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Beep(349, 500); // F
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.Beep(392, 500); // G
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.Beep(440, 500); // A
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Console.Beep(493, 500); // B
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Console.Beep(523, 500); // C
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    button1.Focus();
                    button1_Click(this, new EventArgs()); break;
                case Keys.D2:
                    button2.Focus();
                    button2_Click(this, new EventArgs()); break;
                case Keys.D3:
                    button3.Focus();
                    button3_Click(this, new EventArgs()); break;
                case Keys.D4:
                    button4.Focus();
                    button4_Click(this, new EventArgs()); break;
                case Keys.D5:
                    button5.Focus();
                    button5_Click(this, new EventArgs()); break;
                case Keys.D6:
                    button6.Focus();
                    button6_Click(this, new EventArgs()); break;
                case Keys.D7:
                    button7.Focus();
                    button7_Click(this, new EventArgs()); break;
                case Keys.D8:
                    button8.Focus();
                    button8_Click(this, new EventArgs()); break;
                default:
                    MessageBox.Show("Wrong Input!"); break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Visible = !(label2.Visible);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            label1.Text = DateTime.Now.ToString();

        }
    }
}
