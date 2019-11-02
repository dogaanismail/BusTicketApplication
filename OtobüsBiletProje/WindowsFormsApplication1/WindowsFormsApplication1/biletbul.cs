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
    public partial class biletbul : Form
    {
        public biletbul()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Class1.pnrno=textBox1.Text.ToString();
            biletbul tb = new biletbul();
            tb.Close();
            biletduzenle bt = new biletduzenle();
            bt.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            biletbul formkapaA = new biletbul();
            formkapaA.Close();

            Form1 btt = new Form1();
            btt.Show();
            this.Hide();
            
        }
    }
}
