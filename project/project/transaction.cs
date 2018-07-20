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
    public partial class transaction : Form
    {
        connection conn = new connection();
        public transaction()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void transaction_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select cus_ID from customer", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["cus_ID"].ToString());

            }
            conn.sqlConnection1.Close();


            {
                //product id
                conn.sqlConnection1.Open();


                SqlCommand cmdd = new SqlCommand("select P_ID from products", conn.sqlConnection1);
                SqlDataReader drr = cmdd.ExecuteReader();
                while (drr.Read())
                {
                    comboBox2.Items.Add(drr["P_ID"]);

                }

                conn.sqlConnection1.Close();

            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from customer where cus_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["cus_name"].ToString();
                textBox3.Text = dr["cus_code"].ToString();

                textBox5.Text = dr["ph_no#"].ToString();



                conn.sqlConnection1.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from products where P_ID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox4.Text = dr["P_name"].ToString();
                
                textBox6.Text = dr["price"].ToString();
               
            }
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into P_transaction(cus_name,cus_code,ph_no#,P_name,quantity,total_amount)values(@cus_name,@cus_code,@ph_no#,@P_name,@quantity,@total_amount)", conn.sqlConnection1);
           
            cmd.Parameters.AddWithValue("@cus_name", this.textBox2.Text);
            //cmd.Parameters.AddWithValue("@cus_code", this.textBox2.Text);
            cmd.Parameters.AddWithValue("@cus_code", this.textBox3.Text);
            cmd.Parameters.AddWithValue("@ph_no#", this.textBox5.Text);
         // cmd.Parameters.AddWithValue("@cus_ID", this.comboBox1.Text);
         // cmd.Parameters.AddWithValue("@P_ID", this.comboBox2.Text);
            cmd.Parameters.AddWithValue("@P_name", this.textBox4.Text);
            cmd.Parameters.AddWithValue("@quantity", this.textBox1.Text);
            cmd.Parameters.AddWithValue("@total_amount", this.textBox9.Text);
            cmd.Parameters.AddWithValue("@price", this.textBox6.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("transaction done!!");


            conn.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox6.Text);
            textBox9.Text = (a * b).ToString();
        }
    }
}
