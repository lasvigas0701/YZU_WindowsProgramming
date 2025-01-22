using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_04_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
                label3.Text = "答對了";
            else
                label3.Text = "答錯了，元智大學於1989年招收第一屆學生";
            if (radioButton7.Checked == true)
                label4.Text = "答對了";
            else
                label4.Text = "答錯了，元智大學位於桃園市";
        }
    }
}
