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

namespace WindowsFormsApplication1
{
    public partial class seferekle : Form
    {
        public seferekle()
        {
            InitializeComponent();
        }
      
        SqlConnection con = new SqlConnection("server=ISOTPC;database=database;trusted_connection=true");
        
        private void seferekle_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = new DateTime(2016, 9, 1);

            Random rnd2 = new Random();
            int sayi2 = rnd2.Next(0, 10000);
            textBox3.Text = sayi2.ToString();
            textBox3.Enabled = false;
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Otobusler", con);
            DataTable tablo = new DataTable();
            
            SqlDataReader oku = cmd.ExecuteReader();
            tablo.Load(oku);
            comboBox6.DataSource = tablo.DefaultView;
            comboBox6.DisplayMember = "Plaka";
            comboBox6.ValueMember = "otobusID";
           
         
             con.Close();


            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int otobusId = Convert.ToInt32(comboBox6.SelectedValue);
                con.Open();
                SqlDataAdapter cmd2 = new SqlDataAdapter("select * from Otobusler where otobusID='" + otobusId + "'", con);

                DataTable tablo = new DataTable();
                cmd2.Fill(tablo);

                string s = tablo.Rows[0][3].ToString();
                string d = tablo.Rows[0][2].ToString();


                SqlCommand cmd = new SqlCommand("insert into Seferler(seferNo,KalkisTerminal,KalkisTarihi,KalkisSaati,VarisTerminal,OtobusPlaka,OtobusTipi,Fiyat,OtobusId) values ('" + textBox3.Text + "' , '" + comboBox1.SelectedItem.ToString() + "','" + dateTimePicker1.Value.ToShortDateString() + "', '" + comboBox7.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "', '" + d + "', '" + s + "', '" + textBox2.Text + "', '" + comboBox6.SelectedValue + "')", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Kayıt Eklendi");

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }

            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            seferekle kapat = new seferekle();
            kapat.Close();

            Form1 btt = new Form1();
            btt.Show();
            this.Hide();
        }
    }
}
