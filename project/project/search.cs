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
    public partial class search : Form
    {
        connection conn = new connection();
        public search()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void search_Load(object sender, EventArgs e)
        {

            //combo1
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select cus_ID  from Customer", conn.sqlConnection1);
           SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["cus_ID"]);
            }

            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            conn.sqlConnection1.Open();
          SqlCommand cmd = new SqlCommand("select * from customer where cus_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["cus_name"].ToString();
                 textBox2.Text = dr["cus_code"].ToString();
                textBox5.Text = dr["city"].ToString();
                textBox3.Text = dr["cus_Address"].ToString();
                textBox4.Text = dr["ph_no#"].ToString();
               
                textBox6.Text = dr["e_mail"].ToString();
               




            }

            conn.sqlConnection1.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            this.textBox5.ReadOnly = false;
            this.textBox6.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update customer set cus_name='" + textBox1.Text + "',cus_code='" + textBox2.Text + "',city='" + textBox5.Text + "',cus_address='" + textBox3.Text + "',ph_no#='" + textBox4.Text + "',e_mail='" + textBox6.Text + "' where cus_ID=@cus_ID", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@cus_ID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@cus_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@cus_code", textBox2.Text);
            cmd.Parameters.AddWithValue("@cus_address", textBox3.Text);
            cmd.Parameters.AddWithValue("@ph_no#", textBox4.Text);
            cmd.Parameters.AddWithValue("@city", textBox5.Text);
            cmd.Parameters.AddWithValue("@e_mail", textBox6.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data has been updated");

            conn.sqlConnection1.Close();
        }
    }
}
