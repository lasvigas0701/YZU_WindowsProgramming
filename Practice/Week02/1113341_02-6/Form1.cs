using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_02_6
{
    public partial class Form1 : Form
    {
        string[] announce = { "冰棒買二送一", "鋁箔飲料全面九折", "咖啡好評熱銷中", "便當多種新口味上市" };
        Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Brown };
        int n = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = announce[n]; //set the text of label1
            label1.ForeColor = colors[n]; // set the color of label1
            n++;
            if (n == announce.Length)
                n = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "歡迎光臨!"; //set initial text of label1
            label1.Font = new Font("Arial", 28); //set the font name and font size of label1

        }
    }
}
