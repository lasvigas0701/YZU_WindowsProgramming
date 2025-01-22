using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_02_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseDown at textBox1 (" + 
                e.Location.X.ToString() + " , " + 
                e.Location.Y.ToString() + ")\r\n");
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseUp at textBox1 (" + 
                e.Location.X.ToString() + " , " + 
                e.Location.Y.ToString() + ")\r\n");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseDown at Form1 (" + 
                e.Location.X.ToString() + " , " + 
                e.Location.Y.ToString() + ")\r\n");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseMove at Form1 (" + 
                e.Location.X.ToString() + " , " + 
                e.Location.Y.ToString() + ")\r\n");
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseUp at Form1 (" +
                e.Location.X.ToString() + " , " +
                e.Location.Y.ToString() + ")\r\n");
        }
    }
}
