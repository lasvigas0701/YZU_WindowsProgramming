using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_06_5
{
    public partial class Form1 : Form
    {
        int num1 = 0;
        int num2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // 1 second
            num1 = Convert.ToInt32(textBox1.Text);
            toolStripProgressBar1.Maximum = num1;
            toolStripProgressBar1.Step = 1;
            toolStripStatusLabel1.Text = "0";
            toolStripProgressBar1.Value = 0;
            num2 = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (num2 < num1)
            {
                num2++;
                toolStripProgressBar1.Value++;
                toolStripStatusLabel1.Text = num2.ToString();
            }
            else
            {
                timer1.Stop();
                toolStripStatusLabel1.Text = "Done";
            }
        }
    }
}
