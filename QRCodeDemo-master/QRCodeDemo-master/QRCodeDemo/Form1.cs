using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(textBox1.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            pictureBox1.Image = code.GetGraphic(50);
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int length, i;

            length = 5;
            char[] password = new char[length];
            for (i = 0; i < length; i++)
                password[i] = validChars[random.Next(0, validChars.Length)];
            String str = new string(password);
            for (i = 0; i < length; i++)
                textBox2.Text = str;
          


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
