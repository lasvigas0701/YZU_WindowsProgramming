using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_hw7
{
    public partial class Form3 : Form
    {
        private float R = 1, G = 1, B = 1, A = 1;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public float getR()
        {
            return R;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            R = trackBar1.Value / 10f;
            label5.Text = R.ToString();
            G = trackBar2.Value / 10f;
            label6.Text = G.ToString();
            B = trackBar3.Value / 10f;
            label7.Text = B.ToString();
            A = trackBar4.Value / 10f;
            label8.Text = A.ToString();
        }

        public float getG()
        {
            return G;
        }

        public float getB()
        {
            return B;
        }

        public float getA()
        {
            return A;
        }


    }
}
