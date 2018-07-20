using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class products : Form
    {
        connection conn = new connection();
        public products()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Psearch sea = new Psearch();
            sea.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void products_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into products(P_name,quantity,price,P_description)values(@P_name,@quantity,@price,@P_description)", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@P_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            cmd.Parameters.AddWithValue("@P_description", textBox5.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("product is added");

            conn.sqlConnection1.Close();
        }
    }
}
