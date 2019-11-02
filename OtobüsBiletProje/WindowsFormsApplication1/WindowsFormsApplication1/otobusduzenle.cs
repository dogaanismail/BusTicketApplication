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
    public partial class otobusduzenle : Form
    {
        public otobusduzenle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=ISOTPC;database=database;trusted_connection=true");


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            otobusduzenle formkapa = new otobusduzenle();
            formkapa.Close();

           Form1 btt = new Form1();
            btt.Show();
            this.Hide();
        }

        private void otobusduzenle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Otobusler", con);
            DataTable tablo = new DataTable();
            con.Open();
            SqlDataReader oku = cmd.ExecuteReader();
            tablo.Load(oku);

            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Visible = false;
            


            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Güncelleme İşlemi Yapılsın mı ?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("update Otobusler set AracNo='" + dataGridView1.CurrentRow.Cells[1].Value + "',Plaka='" + dataGridView1.CurrentRow.Cells[2].Value + "',OtobusTipi='" + dataGridView1.CurrentRow.Cells[3].Value + "',Sofor='" + dataGridView1.CurrentRow.Cells[4].Value + "',Muavin='" + dataGridView1.CurrentRow.Cells[5].Value + "' where otobusID=@oid", con);
                    cmd.Parameters.AddWithValue("@oid", dataGridView1.CurrentRow.Cells[0].Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla GÜNCELLENDİ");
                    con.Close();

                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString());
                }


            }

            con.Open();
            SqlDataAdapter cmd2 = new SqlDataAdapter("select * from Otobusler where otobusID=@oid", con);
            cmd2.SelectCommand.Parameters.AddWithValue("@oid", dataGridView1.CurrentRow.Cells[0].Value);

            DataTable tablo = new DataTable();
            cmd2.Fill(tablo);
            dataGridView1.DataSource = tablo;


            dataGridView1.Columns[0].Visible = false;
           
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int AracNo;

            AracNo = Convert.ToInt16(textBox1.Text);
            try
            {


                SqlCommand cmd = new SqlCommand("select * from Otobusler " + "where(AracNo like '%" + AracNo + "%')", con);
                DataTable tablo = new DataTable();
                con.Open();
                SqlDataReader oku = cmd.ExecuteReader();
                tablo.Load(oku);

                dataGridView1.DataSource = tablo;



                con.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Silme İşlemi Yapılsın mı ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("delete from Otobusler where otobusID=@oid", con);
                    cmd.Parameters.AddWithValue("@oid", dataGridView1.CurrentRow.Cells[0].Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla SİLİNDİ");
                    con.Close();

                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString());
                }
            }


            SqlCommand cmd3 = new SqlCommand("SELECT * FROM Otobusler", con);
            DataTable tablo = new DataTable();
            con.Open();
            SqlDataReader oku = cmd3.ExecuteReader();
            tablo.Load(oku);

            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Visible = false;



            con.Close();

        }
    }
}
