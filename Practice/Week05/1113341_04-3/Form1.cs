using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_04_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "你喜歡的水果有\n";
            if (checkBox1.Checked == true)
                label2.Text += "西瓜\n";
            if (checkBox2.Checked == true)
                label2.Text += "蘋果\n";
            if (checkBox3.Checked == true)
                label2.Text += "香蕉\n";
            if (checkBox4.Checked == true)
                label2.Text += "鳳梨\n";
            if (checkBox5.Checked == true)
                label2.Text += "芭樂\n";
            if (checkBox6.Checked == true)
                label2.Text += "草莓\n";
            if (checkBox7.Checked == true)
                label2.Text += "水梨\n";
            if (checkBox8.Checked == true)
                label2.Text += "木瓜\n";
        }
    }
}
