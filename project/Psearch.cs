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
    public partial class Psearch : Form
    {
        connection conn = new connection();
        public Psearch()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Psearch_Load(object sender, EventArgs e)
        {


            //combo1
            conn.sqlConnection1.Open();
           SqlCommand cmd = new SqlCommand("select P_ID  from products", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["P_ID"]);
            }
            conn.sqlConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from products where P_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["P_name"].ToString();
                // textBox2.Text = dr["vcode"].ToString();
                textBox3.Text = dr["quantity"].ToString();
                textBox4.Text = dr["price"].ToString();
                textBox5.Text = dr["P_description"].ToString();
           }
            conn.sqlConnection1.Close();
        }
    }
}
