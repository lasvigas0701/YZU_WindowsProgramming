using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _1113341_10_3
{
    public partial class Form1 : Form
    {
        string text = "視窗程式設計!";
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(600, 400);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath(); // GraphicsPath物件

            FontFamily family = new FontFamily("標楷體"); //字型
            StringFormat format = StringFormat.GenericDefault; // 預設字體設定

            if (checkBox1.Checked)
                format.FormatFlags = StringFormatFlags.DirectionVertical;　// 垂直
            else
                format.FormatFlags = StringFormatFlags.FitBlackBox; //避免突出，水平
            
            gp.AddString(text,  // 繪出文字字串
                            family,
                            (int)FontStyle.Regular,
                            80,
                            new Point(40, 60),
                            format);

            // 將 gp 內的形狀 繪出
            e.Graphics.DrawPath(Pens.Black, gp); // 繪出GraphicsPath物件
            if (checkBox2.Checked)
                e.Graphics.FillPath(new SolidBrush(Color.Red), gp); //填色
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;
            Invalidate();
        }
    }
}
