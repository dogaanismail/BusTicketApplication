using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data;
using System.Xml;
using System.IO;
using System.Net;
using System.Dynamic;
using System.Collections;
namespace WindowsFormsApplication1
{
    public partial class biletal : Form
    {
        public biletal()
        {
            InitializeComponent();
        }


        private string XMLPOST(string PostAddress, string xmlData)
        {
            try
            {
                var res = "";
                byte[] bytes = Encoding.UTF8.GetBytes(xmlData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(PostAddress);

                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = "text/xml";
                request.Timeout = 300000000;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }

               
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format(
                        "POST failed. Received HTTP {0}",
                        response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    Stream responseStream = response.GetResponseStream();
                    using (StreamReader rdr = new StreamReader(responseStream))
                    {
                        res = rdr.ReadToEnd();
                    }
                    return res;
                }
            }
            catch
            {

                return "-1";
            }

        }


        SqlConnection con = new SqlConnection("server=ISOTPC;database=database;trusted_connection=true");
       
        ArrayList kisiler = new ArrayList();
        ArrayList telno = new ArrayList();
        ArrayList biletalanlar = new ArrayList();
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void biletal_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today; //Minimum Tarih
            dateTimePicker1.MaxDate = new DateTime(2016, 9, 1); // Maksimum gidebileceğimiz tarih 1 Eylül 2016
            comboBox1.Text = Class1.deger;
            comboBox2.Text = Class1.deger1;
            dateTimePicker1.Value = Convert.ToDateTime(Class1.tarih);
            kisiler.Clear();

            sdsds();
           
            flowLayoutPanel1.Visible = false;

            panel2.Visible = false;
            panel3.Visible = false;

            //con.Open();
            //SqlCommand cmd2 = new SqlCommand("delete from Seferler where KalkisTarihi < '" + System.DateTime.Today + "'", con);
            //cmd2.ExecuteNonQuery();
            //con.Close();

            
            SqlCommand cmd = new SqlCommand("select * from Seferler where KalkisTerminal='"+Class1.deger+"'and VarisTerminal='"+Class1.deger1+"' and KalkisTarihi='"+Class1.tarih+"'", con);
            DataTable tablo = new DataTable();
            con.Open();
            SqlDataReader oku = cmd.ExecuteReader();
            tablo.Load(oku);
           
   
            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;


            con.Close();

        }


        string sayideger()
        {
            string deger = ""; //boş değer tanımlıyoruz
            Random rnd = new Random(); // rastgele değeri tanımlıyouz
            for (int i = 0; i < 8; i++) //8 haneli rakam-harf üretmek için döngü sağlıyoruz
            {

                int karar = rnd.Next(0, 2); // 0 veya 1
                if (karar == 0) // rastgele üretilen sayı 0 ise sayı üret
                {
                    int sayi = rnd.Next(1, 10);
                    deger += sayi.ToString();
                }
                else // değilse harf üret (65 ile 91 arası ascii kodlar olduğu için rakam değerleri girdik)
                {
                    int x = rnd.Next(65, 91);
                    char harf = Convert.ToChar(x); //ascii kod olarak üretilen sayıyı harfe çevirdik
                    deger += harf; //değere atadık
                }

            }

            return deger;

        }






       private void dinamikMetod(object sender, EventArgs e) //Dinamik Butonun click olayı basılma olayı
        {

            Button b = (Button)sender;

            if (b.BackColor==Color.Gray)
            {
                b.BackColor = Color.Orange;


                kisiler.Add(b.Text);//kisiler kaç tane koltuk seçilmişse ona atanıyor
                    

           
 
                    int sayi = kisiler.Count;
                   
                    label10.Text = kisiler.Count + " tane koltuk seçildi";
                    int var = kisiler.Count;

                    SqlDataAdapter cmd = new SqlDataAdapter("select * from Seferler where SeferID=@sid", con);
                    cmd.SelectCommand.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);

                    DataTable tablo = new DataTable();
                    cmd.Fill(tablo);


                    Int16 biletfiyati = Convert.ToInt16( tablo.Rows[0][8]);
                
                label11.Text = "Toplam Fiyat " + (biletfiyati * var) + " LİRA ";

                
            }


            else if (b.BackColor == Color.Orange)
            {
                b.BackColor = Color.Gray;

                kisiler.Remove(b.Text);

                label10.Text = kisiler.Count + " tane koltuk seçildi";
                int var = kisiler.Count;

                SqlDataAdapter cmd = new SqlDataAdapter("select * from Seferler where SeferID=@sid", con);
                cmd.SelectCommand.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);

                DataTable tablo = new DataTable();
                cmd.Fill(tablo);


                Int16 biletfiyati = Convert.ToInt16(tablo.Rows[0][8]);

                label11.Text = "Toplam Fiyat " + (biletfiyati * var) + " LİRA ";

            }

        
            
            panel2.Visible = true;
        }

       
        int sd = 0;
        DataTable dt;
        DataRow dr;

        void sdsds()
        {
            dt = new DataTable();

            dt.Columns.Add("KoltukNo");
            dt.Columns.Add("AdSoyad");
            dt.Columns.Add("Telefon");
            dt.Columns.Add("Cinsiyet");
            dt.Columns.Add("PNRno");
        }
        private void button4_Click(object sender, EventArgs e)
        {
          
            if (sd != kisiler.Count)
            {

                if (sd < kisiler.Count)
                {
                    telno.Add(textBox3.Text);
                    biletalanlar.Add(textBox2.Text);
                    dr = dt.NewRow();
                    dr["KoltukNo"] = kisiler[sd].ToString();
                    dr["AdSoyad"] = textBox2.Text;
                    dr["Telefon"] = textBox3.Text;
                    dr["Cinsiyet"] = comboBox4.SelectedItem.ToString();
                    dr["PNRno"] = sayideger();

                    dt.Rows.Add(dr);
                    sd++;
                    MessageBox.Show(sd.ToString() + ". Kayıt Eklendi");
                    textBox2.Text = "";
                    textBox3.Text = "";

               
                }

                 if (sd == kisiler.Count)
                 {
                for (int i = 0; i < kisiler.Count; i++)
                {
                    
                    SqlCommand cmd = new SqlCommand("insert into Koltuklar(SeferID,koltukNo,[Adi Soyadi],[Cep-Telefonu],Cinsiyet,PNRNO) values ('" + dataGridView1.CurrentRow.Cells[0].Value + " ','" + dt.Rows[i][0] + "', '" + dt.Rows[i][1] + "', '" + dt.Rows[i][2] + "', '" + dt.Rows[i][3] + "', '"+dt.Rows[i][4]+"')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("Kayıtlar Eklendi");
                        con.Close();
                 
                       listBox1.Items.Add(telno[i]);
                       con.Open();
                       SqlDataAdapter cmdd = new SqlDataAdapter("select * from Seferler where SeferID=@sid", con);
                       cmdd.SelectCommand.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);

                       DataTable tablo = new DataTable();
                       cmdd.Fill(tablo);


                       string tarih = tablo.Rows[0][3].ToString();
                       string zaman = tablo.Rows[0][4].ToString();
                       string kalkisyeri = tablo.Rows[0][2].ToString();
                       string varisyeri = tablo.Rows[0][5].ToString();
                       string plaka = tablo.Rows[0][6].ToString();

                       String testXml = "<request>";
                       testXml += "<authentication>";
                       testXml += "<username>//telno</username>";
                       testXml += "<password>//şifre</password>";
                       testXml += "</authentication>";
                       testXml += "<order>";
                       testXml += "<sender>i.DOGAN</sender>";
                       testXml += "<message>";
                       testXml += "<text> SAYIN " + biletalanlar[i] + " " + dt.Rows[i][4] + " referansı ile " + tarih + "-" + zaman + " " + kalkisyeri + " -" + varisyeri + " seferinde " + kisiler[i] + " nolu koltuğa bilet aldınız.İyi yolculuklar dileriz.</text>";
                       testXml += "<receipents>";
                       testXml += "<number>" + telno[i] + "</number>";
                       testXml += "</receipents>";
                       testXml += "</message>";
                       testXml += "</order>";
                       testXml += "</request>";

                       this.XMLPOST("http://api.iletimerkezi.com/v1/send-sms", testXml);
                     
                       con.Close();

                   
                
                    foreach (Button item in flowLayoutPanel1.Controls)
                    {
                        if (item.BackColor==Color.Orange)
                        {
                            item.BackColor = Color.Gray;
                            
                        }

                    }

                    panel2.Visible = false;
                }
               

            
            }


            }
            


        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("select * from Seferler where SeferID=@sid", con);
            cmd.SelectCommand.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);

            DataTable tablo = new DataTable();
            cmd.Fill(tablo);
            dataGridView1.DataSource = tablo;


            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            flowLayoutPanel1.Visible = true;
            panel3.Visible = true;

            DataTable tablox = new DataTable();
            cmd = new SqlDataAdapter("select * from Koltuklar Where SeferID=@sid", con);
            cmd.SelectCommand.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);
            cmd.Fill(tablox);

            flowLayoutPanel1.Controls.Clear();

            string s = tablo.Rows[0][7].ToString();
            if (s == "Class")
            {


                for (int c = 4; c <= 46; )
                {
                    Button b = new Button();
                    b.Width = 65;
                    b.Height = 35;
                    b.Margin = new Padding(0, 0, 2, 7);
                    b.Text = c.ToString();

                    c += 4;
                    flowLayoutPanel1.Controls.Add(b);
                }
                for (int k = 3; k <= 45; )
                {
                    Button b = new Button();
                    b.Width = 65;
                    b.Height = 35;
                    b.Margin = new Padding(0, 0, 2, 20);
                    b.Text = k.ToString();

                    flowLayoutPanel1.Controls.Add(b);
                    k += 4;
                }
                for (int i = 2; i <= 44; )
                {
                    Button b = new Button();
                    b.Width = 65;
                    b.Height = 35;
                    b.Margin = new Padding(0, 20, 2, 7);
                    b.Text = i.ToString();
                    flowLayoutPanel1.Controls.Add(b);
                    i += 4;
                }

                for (int i = 1; i <= 43; )
                {
                    Button b = new Button();

                    b.Width = 65;
                    b.Height = 35;
                    b.Margin = new Padding(0, 0, 2, 7);
                    b.Text = i.ToString();
                    flowLayoutPanel1.Controls.Add(b);
                    i += 4;
                }

            }


            if (s == "Suit")
            {

                for (int c = 3; c <= 38; )
                {
                    Button b = new Button();
                    b.Width = 60;
                    b.Height = 40;
                    b.Margin = new Padding(0, 0, 2, 7);
                    b.Text = c.ToString();

                    c += 3;
                    flowLayoutPanel1.Controls.Add(b);


                }



                for (int c = 2; c <= 37; )
                {
                    Button b = new Button();
                    b.Width = 60;
                    b.Height = 40;
                    b.Margin = new Padding(0, 0, 2, 7);
                    b.Text = c.ToString();

                    c += 3;
                    flowLayoutPanel1.Controls.Add(b);
                }


                for (int c = 1; c <= 36; )
                {
                    Button b = new Button();
                    b.Width = 60;
                    b.Height = 40;
                    b.Margin = new Padding(0, 60, 2, 0);
                    b.Text = c.ToString();

                    c += 3;
                    flowLayoutPanel1.Controls.Add(b);
                }


            }




            if (tablox.Rows.Count > 0)
            {

                for (int i = 0; i < tablox.Rows.Count; i++)
                {
                    foreach (Button item in flowLayoutPanel1.Controls)
                    {

                        string koltukNo = item.Text;

                        string f = tablox.Rows[i][2].ToString();
                        string ab = tablox.Rows[i][5].ToString();

                        if (item.BackColor == Color.Pink || item.BackColor == Color.Blue)
                        {
                            continue;
                        }
                        else
                        {
                            if (f == item.Text)
                            {
                                item.Enabled = false;
                                if (ab == "Bayan")
                                    item.BackColor = Color.Pink;

                                else
                                    item.BackColor = Color.Blue;
                            }
                            else
                            {
                                item.BackColor = Color.Gray;
                                item.Enabled = true;


                            }

                        }



                    }
                }
            }
            else
            {
                foreach (Button item in flowLayoutPanel1.Controls)
                {
                    item.BackColor = Color.Gray;
                    item.Enabled = true;


                }
            }
            foreach (Button item in flowLayoutPanel1.Controls)
            {
                item.Click += new EventHandler(dinamikMetod);
            }

            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("select * from Seferler", con);
            DataTable tablo = new DataTable();
            con.Open();
            SqlDataReader oku = cmd.ExecuteReader();
            tablo.Load(oku);
            dataGridView1.DataSource = tablo;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Visible = false;
            panel3.Visible = false;

            kisiler.Clear();

            panel2.Visible = false;
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dt.Clear();
            
            sd = 0;
            kisiler.Clear();
          
            telno.Clear();
            biletalanlar.Clear();
            
            SqlDataAdapter cmd = new SqlDataAdapter("select * from Seferler where SeferID=@sid", con);
            cmd.SelectCommand.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);
            DataTable tablo = new DataTable();
            cmd.Fill(tablo);
           


            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;

            flowLayoutPanel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            flowLayoutPanel1.Visible = false;
            panel3.Visible = false;

            panel2.Visible = false;

            SqlCommand cmd = new SqlCommand("select * from Seferler where KalkisTerminal='" + comboBox1.SelectedItem + "'and VarisTerminal='" + comboBox2.SelectedItem + "' and KalkisTarihi='" + dateTimePicker1.Value.ToShortDateString() + "'", con);
            DataTable tablo = new DataTable();
            con.Open();
            SqlDataReader oku = cmd.ExecuteReader();
            tablo.Load(oku);


            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;


            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            biletal kapat = new biletal();
            kapat.Close();

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();

        }

        
       

       
      
       
    }
}
