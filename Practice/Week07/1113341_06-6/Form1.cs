using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_06_6
{
    public partial class Form1 : Form
    {
        Bitmap bitmap1 = new Bitmap(Properties.Resources.Chrysanthemum);
        Bitmap bitmap2 = new Bitmap(Properties.Resources.Hydrangeas);
        Bitmap bitmap3 = new Bitmap(Properties.Resources.Tulips);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = bitmap1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap1;
            toolStripStatusLabel1.Image = bitmap1;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap2;
            toolStripStatusLabel1.Image = bitmap2;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap3;
            toolStripStatusLabel1.Image = bitmap3;
        }
    }
}
