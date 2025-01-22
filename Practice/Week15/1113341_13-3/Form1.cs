using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;  //File
using System.Collections; //匯入集合函式庫   Stack

namespace _1113341_13_3
{
    public partial class Form1 : Form
    {
        Stack ps = new Stack(); //紀錄復原資訊的堆疊集合
        bool fc = false; //是否來自復原控制鍵的文字改變

        public Form1()
        {
            InitializeComponent();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            textBox1.Clear();
            ps.Clear();
            ps.Push(textBox1.Text);
            復原ToolStripMenuItem.Enabled = false;
        }

        private void 開啟舊檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
            }
            ps.Clear();
            ps.Push(textBox1.Text);
            復原ToolStripMenuItem.Enabled = false;
        }

        private void 儲存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, textBox1.Text, Encoding.Default);
                    openFileDialog1.FileName = saveFileDialog1.FileName;
                }
            }
            else
            {
                File.WriteAllText(openFileDialog1.FileName, textBox1.Text, Encoding.Default);
            }
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text, Encoding.Default);
                openFileDialog1.FileName = saveFileDialog1.FileName;
            }
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 剪下ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void 複製ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void 貼上ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void 全選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void 字型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Font = fontDialog1.Font;
        }

        private void 顏色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                textBox1.ForeColor = colorDialog1.Color;
        }

        private void 復原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ps.Count > 1)
            {
                fc = true;
                while ((ps.Count > 0) && (textBox1.Text == (String)ps.Peek()))
                    ps.Pop();
                textBox1.Text = (String)ps.Peek();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (fc == false)
            {
                ps.Push(textBox1.Text);
            }
            fc = false;
            if (ps.Count > 1)
                復原ToolStripMenuItem.Enabled = true;
            else
                復原ToolStripMenuItem.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ps.Clear();
            textBox1.Text = "";
            ps.Push(textBox1.Text);
            復原ToolStripMenuItem.Enabled = false;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "純文字檔案|*.txt";
            saveFileDialog1.Filter = "純文字檔案|*.txt";
        }
    }
}
