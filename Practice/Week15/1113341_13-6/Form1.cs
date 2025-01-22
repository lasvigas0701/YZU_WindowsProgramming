using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace _1113341_13_6
{
    public partial class Form1 : Form
    {
        Stack ps = new Stack(); //紀錄復原資訊的堆疊集合
        public Form1()
        {
            InitializeComponent();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            richTextBox1.Clear();
            ps.Clear();
            ps.Push(richTextBox1.Rtf);
            復原ToolStripMenuItem.Enabled = false;
        }

        private void 開啟舊檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog1.FileName) == ".txt")
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.LoadFile(openFileDialog1.FileName);
                ps.Clear();
                ps.Push(richTextBox1.Rtf);
                復原ToolStripMenuItem.Enabled = false;
            }
        }

        private void 儲存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                    openFileDialog1.FileName = saveFileDialog1.FileName;
                }
            }
            else
            {
                richTextBox1.SaveFile(openFileDialog1.FileName);
            }
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                openFileDialog1.FileName = saveFileDialog1.FileName;
            }
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = "";
            ps.Clear();
            ps.Push(richTextBox1.Rtf); //先放空字串入Stack
            復原ToolStripMenuItem.Enabled = false;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "RTF檔案(*.rtf); 純文字檔案(*.txt)|*.rtf;*.txt";
            saveFileDialog1.Filter = "RTF檔案|*.rtf";
        }

        private void 剪下ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 複製ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 貼上ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 全選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void 復原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ps.Count > 1)
            {
                while ((ps.Count > 0) && (richTextBox1.Rtf == (String)ps.Peek()))
                    ps.Pop();
                //暫時取消richTextBox1_TextChanged，以免復原的動作又被存入Stack
                richTextBox1.TextChanged -= new System.EventHandler(richTextBox1_TextChanged);
                richTextBox1.Rtf = (String)ps.Peek(); //復原
                                                      //加回 richTextBox1_TextChanged
                richTextBox1.TextChanged += new System.EventHandler(richTextBox1_TextChanged);
            }
            if (ps.Count == 1) //Stack內是一開始存的空字串
                復原ToolStripMenuItem.Enabled = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            ps.Push(richTextBox1.Rtf); //變動存入Stack
            if (ps.Count > 1)
                復原ToolStripMenuItem.Enabled = true;
            else
                復原ToolStripMenuItem.Enabled = false;
        }

        private void 字型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void 顏色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog1.Color;
        }
    }
}
