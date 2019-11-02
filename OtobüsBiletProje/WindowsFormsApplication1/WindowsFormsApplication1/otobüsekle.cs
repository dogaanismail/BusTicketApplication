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
    public partial class otobüsekle : Form
    {
        public otobüsekle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=ISOTPC;database=database;trusted_connection=true");
        private void otobüsekle_Load(object sender, EventArgs e)
        {
            Random rnd2 = new Random();
            int sayi2 = rnd2.Next(0, 10000);
            textBox2.Text = sayi2.ToString();
            textBox2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("insert into Otobusler(AracNo,Plaka,OtobusTipi,Sofor,Muavin) values('" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox3.SelectedItem.ToString() + "', '" + textBox4.Text + "','"+textBox1.Text+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt Eklendi");

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
                
               
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
           
                
               


            
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            otobüsekle kapat = new otobüsekle();
            kapat.Close();

            Form1 btt = new Form1();
            btt.Show();
            this.Hide();
        }
    }
}
