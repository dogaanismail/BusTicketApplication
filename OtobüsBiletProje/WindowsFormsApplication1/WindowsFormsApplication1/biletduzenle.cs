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
    public partial class biletduzenle : Form
    {
        public biletduzenle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=ISOTPC;database=database;trusted_connection=true");
        private void biletdüzenle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Koltuklar where PNRNO='"+ Class1.pnrno+"' ", con);
            DataTable tablo = new DataTable();
            con.Open();
            SqlDataReader oku = cmd.ExecuteReader();
            tablo.Load(oku);
            
                dataGridView1.DataSource = tablo;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                con.Close();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Silme İşlemi Yapılsın mı ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Koltuklar where KoltukID=@kid", con);
                    cmd.Parameters.AddWithValue("@kid", dataGridView1.CurrentRow.Cells[0].Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla Silindi");
                    con.Close();
                    this.Close();
                    Form1 FRM1 = new Form1();
                    FRM1.Show();


                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.ToString());
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            biletduzenle formkapaA = new biletduzenle();
            formkapaA.Close();

            Form1 btt = new Form1();
            btt.Show();
            this.Hide();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            biletduzenle formkapaA = new biletduzenle();
            formkapaA.Close();

            biletbul btt = new biletbul();
            btt.Show();
            this.Hide();

        }

        
    }
}
