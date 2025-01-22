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

namespace _1113341_05_5
{
    public partial class Form1 : Form
    {
        List<Point> Pt = new List<Point>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "點座標檔(*.ptf)|*.ptf";
            saveFileDialog1.Filter = "點座標檔(*.ptf)|*.ptf";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Pt.Add(e.Location);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Pt.Count(); i++)
            {
                e.Graphics.DrawString("(" + Pt[i].X.ToString() + "," + 
                    Pt[i].Y.ToString() + ")", this.Font, 
                    new SolidBrush(Color.Blue), Pt[i].X, Pt[i].Y);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String s = saveFileDialog1.FileName;
                BinaryWriter outFile = new BinaryWriter(File.Open(s, FileMode.Create));
                outFile.Write(Pt.Count());
                for (int i = 0; i < Pt.Count(); i++)
                {
                    outFile.Write(Pt[i].X);
                    outFile.Write(Pt[i].Y);
                }
                outFile.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String s = openFileDialog1.FileName;
                if (!File.Exists(s)) return;  // Check whether the file exists
                BinaryReader inFile = new BinaryReader(File.Open(s, FileMode.Open));
                Pt.Clear();
                int n = inFile.ReadInt32();
                for (int i = 0; i < n; i++)
                    Pt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                Invalidate();
                inFile.Close();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pt.Clear();
            Invalidate();
        }
    }
}
