using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1113341_01_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // add items to listBox1
            listBox1.Items.AddRange(
                new object[] {
                    "滑鼠",
                    "鍵盤",
                    "網卡",
                    "螢幕",
                    "音效卡",
                    "顯示卡"
                });
        }

        // add item as the last one in listBox1
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
        }

        // add item to listBox1 at the specified index
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") // if no index is specified, add to the last
                listBox1.Items.Insert(listBox1.Items.Count, textBox1.Text);
            else
            {
                int ndx = Convert.ToInt32(textBox2.Text);
                listBox1.Items.Insert(ndx, textBox1.Text);
            }
            textBox1.Clear();
            label1.Text = "目前位置：" + listBox1.SelectedIndex;
        }

        // remove item from listBox1 at the specified index
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int ndx = Convert.ToInt32(textBox2.Text);
                if (ndx < listBox1.Items.Count)
                    listBox1.Items.RemoveAt(ndx);
            }
        }

        // clear all items in listBox1
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        // search for the item in listBox1
        private void button5_Click(object sender, EventArgs e)
        {
            string searchString = textBox1.Text;
            int index = listBox1.FindString(searchString);

            if (index != -1) // if found
                listBox1.SetSelected(index, true);
            else
                MessageBox.Show("目前的ListBox中並沒有要查尋的「" + searchString + "」");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "目前位置：" + listBox1.SelectedIndex;
        }
    }
}
