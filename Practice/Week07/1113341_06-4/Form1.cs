using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_06_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Red";
            toolStripButton1.Checked = true;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            textBox1.ForeColor = Color.Red;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Green";
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = true;
            toolStripButton3.Checked = false;
            textBox1.ForeColor = Color.Green;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Blue";
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = true;
            textBox1.ForeColor = Color.Blue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Red";
            toolStripStatusLabel2.Text = "12";
            textBox1.ForeColor = Color.Red;
            textBox1.Font = new Font("Ariel", 12);
            textBox1.Text = "Window Programming\n";
            toolStripComboBox1.SelectedIndex = 0;
            toolStripButton1.Checked = true;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    textBox1.Font = new Font("Ariel", 12);
                    toolStripStatusLabel2.Text = "12";
                    break;
                case 1:
                    textBox1.Font = new Font("Ariel", 14);
                    toolStripStatusLabel2.Text = "14";
                    break;
                case 2:
                    textBox1.Font = new Font("Ariel", 16);
                    toolStripStatusLabel2.Text = "16";
                    break;
                case 3:
                    textBox1.Font = new Font("Ariel", 18);
                    toolStripStatusLabel2.Text = "18";
                    break;
                case 4:
                    textBox1.Font = new Font("Ariel", 20);
                    toolStripStatusLabel2.Text = "20";
                    break;
            }
        }
    }
}
