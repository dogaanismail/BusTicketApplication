using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public seferekle sefereklee;
        public otobüsekle otobuseklee;
        public biletbul biletbull;
       

        public Form1()
        {

            InitializeComponent();
            sefereklee = new seferekle();
            otobuseklee = new otobüsekle();
            biletbull = new biletbul();
           
        }

        private void biletAlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = new DateTime(2016, 9, 1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Close();
            Class1.deger = comboBox1.SelectedItem.ToString();
            Class1.deger1 = comboBox2.SelectedItem.ToString();
            Class1.tarih = dateTimePicker1.Value.ToShortDateString();

            biletal bt = new biletal();
            bt.Show();
            this.Hide();
        }

        private void seferEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formkapa = new Form1();
            formkapa.Close();

            seferekle goster = new seferekle();
            goster.Show();
            this.Hide();

          
        }

        private void otobüsEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formkapa = new Form1();
            formkapa.Close();

            otobüsekle btt = new otobüsekle();
            btt.Show();
            this.Hide();
            
        }

        private void biletBulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formkapa = new Form1();
            formkapa.Close();
           
            biletbul btt = new biletbul();
            btt.Show();
            this.Hide();
           
        }

        private void seferDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formkapa = new Form1();
            formkapa.Close();

            seferduzenle btt = new seferduzenle();
            btt.Show();
            this.Hide();
        }

        private void otobüsDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1 formkapa = new Form1();
            formkapa.Close();

           otobusduzenle btt = new otobusduzenle();
            btt.Show();
            this.Hide();

        }

        
    }
}
