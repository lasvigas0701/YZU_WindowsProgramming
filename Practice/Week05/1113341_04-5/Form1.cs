using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; //DashStyle

namespace _1113341_04_5
{
    public partial class Form1 : Form
    {
        Color bgcolor = Color.White; // background color
        int lineWidth = 1;
        Color lineColor = Color.Red;
        bool lineSolid = true; // true: solid, false: dashed
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = bgcolor;
            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox2.SelectedIndex = 0;
            toolStripComboBox3.SelectedIndex = 0;
            白ToolStripMenuItem.Checked = true;
            灰ToolStripMenuItem.Checked = false;
            銀ToolStripMenuItem.Checked = false;
        }

        private void 白ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bgcolor = Color.White;
            this.BackColor = bgcolor;
            白ToolStripMenuItem.Checked = true;
            灰ToolStripMenuItem.Checked = false;
            銀ToolStripMenuItem.Checked = false;
            Invalidate();
        }

        private void 灰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bgcolor = Color.Gray;
            this.BackColor = bgcolor;
            白ToolStripMenuItem.Checked = false;
            灰ToolStripMenuItem.Checked = true;
            銀ToolStripMenuItem.Checked = false;
            Invalidate();
        }

        private void 銀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bgcolor = Color.Silver;
            this.BackColor = bgcolor;
            白ToolStripMenuItem.Checked = false;
            灰ToolStripMenuItem.Checked = false;
            銀ToolStripMenuItem.Checked = true;
            Invalidate();
        }

        // Line Width
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineWidth = toolStripComboBox1.SelectedIndex + 1;
            Invalidate();
        }

        // Line Color
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox2.SelectedIndex)
            {
                case 0:
                    lineColor = Color.Red;
                    break;
                case 1:
                    lineColor = Color.Green;
                    break;
                case 2:
                    lineColor = Color.Blue;
                    break;
            }
            Invalidate();
        }

        // Line Style
        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox3.SelectedIndex)
            {
                case 0:
                    lineSolid = true;
                    break;
                case 1:
                    lineSolid = false;
                    break;
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p1 = new Pen(lineColor, lineWidth);
            if (lineSolid)
                p1.DashStyle = DashStyle.Solid;
            else
                p1.DashStyle = DashStyle.Dash;

            Graphics g1 = e.Graphics;
            g1.DrawEllipse(p1, 40, 40, 100, 100);
        }
    }
}
