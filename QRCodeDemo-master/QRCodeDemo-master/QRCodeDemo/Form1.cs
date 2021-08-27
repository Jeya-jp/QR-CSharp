using System;
using System.Data.OleDb;
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
            var uri = "https://qr-attadance.000webhostapp.com/index.html?rollno=" + textBox1.Text + "&id=" + textBox2.Text;
            //roll number
            var MyData = QG.CreateQrCode(uri, QRCoder.QRCodeGenerator.ECCLevel.H);

            var code = new QRCoder.QRCode(MyData);
            pictureBox1.Image = code.GetGraphic(100);





        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

          

            string[] array1 = new string[]
               {
                    "JZ4jCj2u4K",
                    "xDSPiEe1IA",
                    "CD1aqhZPzn",
                    "4b1xEjNJkz",
                    "FmIl58LpJA",
                    "5lqRDljdYa",
                     "Mfe5uVZxXP",
                     "bCvPdrQvTg",
                     "SEjmxpVjvd",
                      "CXjwVYx0GM",
                      "DCd3LwQXrH",
                      "LQ245altFR",
                      "mZ0IFDXPsk",
                      "VC3Gz9KxMK",
                      "0DuoIpsLJ3",
                      "CiQQP1dsbF",
                      "UfU6i5ZGgM",
                      "fF4RiQFtGM",
                      "1WSNf2lyMd",
                      "Iewl5b5joy",
                      "L9IDDLH3ir",
                      "AWSn8NjYUH",
                      "SaRwKzLKFd",
                      "NwE1CnUIDX",
                      "HQGIrnl0EH",
                      "Hua3vLFYgK",
                      "NGXqSTKu4C",
                      "liYQLygoXA",
                      "THLdWRVY4g",
                      "iHqYYoz3HH",
                      "mIYN3I30Vs",
                      "ELW0Lh9hpT",
                      "R7o7edj4vB",
                      "jSm2hB1Nea",
                      "gi0j2cgsKg",
                      "3qPGTuDioQ",
                      "huHpx9nvSo",
                      "5DQUCaCO8h",
                      "iBZEhijD5q",
                      "4ulkPIHOSD",
                      "Xusm4xQHZ1",
                      "Oe3DiWLa6w",
                      "MepT2xref9",
                      "NkROn8wy6d",
                      "i23F75u6dM",
                      "0Dyd6zZLKe",
                      "m7EoUgKVw4",
                      "v3zBBB3QGj",
                      "kC0zRW28sG",
                      "HQOiaTv4Ei",
                      "9sLB09fdTU",
                      "MBxf8msjeH",
                      "yNcB3R3gru",
                      "LlmDuYQxp1",
                      "jlLrfXUPfK",
                      "IkMosTvI8W",
                      "OKfF3rQEOJ",
                      "cIC3sZ3bNS",
                      "AedU90jmiw",
                      "xZDug6pcja",
                      "1nD90Unpku",
                      "KqCqE3FQyl",
                      "dFQvmPrgI2",
                      "ZWLJhTc8BN",
                      "Y6Btg5qerC",
                      "fxOwz5ZC3Q",
                      "e0qT38sztt",
                      "AOcaIqXyeN",
                      "PFXeY73cZY",
                       "LLvY8jqCr9",
                       "2wehN6kmSM",
                       "NwJ56kEGcS",
                       "nNpmEA1wtl",
                       "VDIRjbDo8U",
                       "X0DjyIPe43",
                       "0iLrTq8Y9L",
                       "XLLjXpMIe8",
                       "hqoF4l2FZu",
                       "5Hz5BVSWye",
                       "mwZOKJ2lm9",
                       "U8YlmHsd0S",
                       "rZ6dd6FSpn",
                       "oTKXo1ZsJ9",
                       "nUAnM6YnKp",
                       "eVpzZQghEp",
                       "VDylklrNLF",
                       "QGAREgtzxr",
                       "1yXDf9WmcM",
                       "Judr3NaHOe",
                       "iHavouRY0W",
                       "dUrfn34jDa",
                       "eR0mBYm5s3",
                       "uaJjCSRz6J",
                       "J4c4hIEPFs",
                       "7iBLzNZXpN",
                       "trEUK016zF",
                       "KNdRB7oE6n"
               };

            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data source= D:\git testing\get\c# app\QR-CSharp\QRCodeDemo-master\QRCodeDemo-master\onedata.accdb";

            conn.Open();

            DateTime dateTime = DateTime.UtcNow.Date;
            var date = dateTime.ToString("dd");





            int flag=0;
            String s = "SELECT * FROM details";

            OleDbCommand ss = new OleDbCommand(s, conn);
            var r = ss.ExecuteReader();

            while (r.Read())
            {
               
                if(r["today"].ToString() == date.ToString())
                {

                    flag = flag + 1;
                }

            }

            if (flag != 0)
            {
                String show = "SELECT * FROM details";
                OleDbCommand sshow = new OleDbCommand(show, conn);
                var red = sshow.ExecuteReader();
                while (red.Read())
                {

                    textBox2.Text = red["ID"].ToString() + "&zdx=" + date;
                    textBox2.Hide();



                }
            }
            else
            {
                //create



                Random random = new Random();
                int index = random.Next(array1.Length);
                var id = array1[index];

                String my_querry = "INSERT INTO details(ID,today)VALUES('" + id + "','" + date + "')";

                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();
                String show = "SELECT * FROM details";
                OleDbCommand sshow = new OleDbCommand(show, conn);
                var red = sshow.ExecuteReader();
                while (red.Read())
                {

                    textBox2.Text = red["ID"].ToString() +"&zdx=" + date; ;
                    textBox2.Hide();


                }

            }


                conn.Close();
        }
    }
}
