using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_13_7
{
    public partial class Form2 : Form
    {
        Form1 Form1_Ref = null;
        public Form2(Form1 temp)
        {
            InitializeComponent();
            Form1_Ref = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int P;
            if (Form1_Ref.RichTextBox1.SelectionLength > 0)
            {//已有目標被搜到時
                P = Form1_Ref.RichTextBox1.Text.IndexOf(textBox1.Text, Form1_Ref.RichTextBox1.SelectionStart + 1);
            }
            else
            {//尚無目標被搜到時
                P = Form1_Ref.RichTextBox1.Text.IndexOf(textBox1.Text, Form1_Ref.RichTextBox1.SelectionStart);
            }

            if (P < 0)
            {//找不到目標時
                MessageBox.Show("未發現搜尋字串！");
            }
            else
            {//找到目標時，選取被找到的目標
                Form1_Ref.RichTextBox1.SelectionStart = P;
                Form1_Ref.RichTextBox1.SelectionLength = textBox1.TextLength;
                Form1_Ref.RichTextBox1.Select();
                Form1_Ref.TopMost = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1_Ref.RichTextBox1.SelectionLength > 0)
                Form1_Ref.RichTextBox1.SelectedText = textBox2.Text;
            Form1_Ref.RichTextBox1.SelectionLength = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int P;
            P = Form1_Ref.RichTextBox1.Text.IndexOf(textBox1.Text);
            if (P < 0)
            {//找不到目標時
                MessageBox.Show("未發現搜尋字串！");
            }
            else
            {//找到目標時，選取被找到的目標
                Form1_Ref.RichTextBox1.SelectionStart = P;
                Form1_Ref.RichTextBox1.SelectionLength = textBox1.TextLength;
                Form1_Ref.RichTextBox1.Select();
                Form1_Ref.TopMost = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
