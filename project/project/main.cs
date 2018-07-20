using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            vendor ven = new vendor();
            ven.Show();

        }

        private void label9_Click(object sender, EventArgs e)
        {
            products pro = new products();
            pro.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            transaction trans = new transaction();
            trans.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            }

        private void label4_Click(object sender, EventArgs e)
        {
        }

       
    }
}
