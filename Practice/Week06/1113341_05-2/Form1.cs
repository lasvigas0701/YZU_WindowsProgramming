using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; // for https request

namespace _1113341_05_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            DateTime t = DateTime.Now.AddHours(-0.5); //30 minutes ago
            string strMinute = "";
            if (t.Minute > 50) strMinute = "50";
            else if (t.Minute > 40) strMinute = "40";
            else if (t.Minute > 30) strMinute = "30";
            else if (t.Minute > 20) strMinute = "20";
            else if (t.Minute > 10) strMinute = "10";
            else strMinute = "00";
            string mapURL = String.Format
                ("https://www.cwa.gov.tw/Data/satellite/LCC_IR1_CR_2750/LCC_IR1_CR_2750-{0}-{1}-{2}-{3}-{4}.jpg",
               t.Year,
               t.Month.ToString("00"),
               t.Day.ToString("00"),
               (t.Hour).ToString("00"),
               strMinute);
            pictureBox1.ImageLocation = mapURL;
            pictureBox1.ClientSize = new Size(400, 430);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; 
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize; //實際圖大小

        }
    }
}
