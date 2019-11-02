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
    public partial class seferduzenle : Form
    {
        public seferduzenle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=ISOTPC;database=database;trusted_connection=true");

        private void seferduzenle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Seferler", con);
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
            seferduzenle formkapaA = new seferduzenle();
            formkapaA.Close();

            Form1 btt = new Form1();
            btt.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Güncelleme İşlemi Yapılsın mı ?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("update Seferler set seferNo='" + dataGridView1.CurrentRow.Cells[1].Value + "',KalkisTerminal='" + dataGridView1.CurrentRow.Cells[2].Value + "',KalkisTarihi='" + dataGridView1.CurrentRow.Cells[3].Value + "',KalkisSaati='" + dataGridView1.CurrentRow.Cells[4].Value + "',VarisTerminal='" + dataGridView1.CurrentRow.Cells[5].Value + "',OtobusPlaka='" + dataGridView1.CurrentRow.Cells[6].Value + "',OtobusTipi='" + dataGridView1.CurrentRow.Cells[7].Value + "',Fiyat='" + dataGridView1.CurrentRow.Cells[8].Value + "',OtobusId='" + dataGridView1.CurrentRow.Cells[9].Value + "' where seferID=@sid", con);
                    cmd.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);

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
            SqlDataAdapter cmd2 = new SqlDataAdapter("select * from Seferler where SeferID=@sid", con);
            cmd2.SelectCommand.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);

            DataTable tablo = new DataTable();
            cmd2.Fill(tablo);
            dataGridView1.DataSource = tablo;


            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;



            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int SeferNo;

            SeferNo = Convert.ToInt16( textBox1.Text);
            try
            {


                SqlCommand cmd = new SqlCommand("select * from Seferler " + "where(seferNo like '%" + SeferNo + "%')", con);
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

                    SqlCommand cmd = new SqlCommand("delete from Seferler where seferID=@sid", con);
                    cmd.Parameters.AddWithValue("@sid", dataGridView1.CurrentRow.Cells[0].Value);

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


            SqlCommand cmd3 = new SqlCommand("SELECT * FROM Seferler", con);
            DataTable tablo = new DataTable();
            con.Open();
            SqlDataReader oku = cmd3.ExecuteReader();
            tablo.Load(oku);

            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;


            con.Close();


        }
    }
}
