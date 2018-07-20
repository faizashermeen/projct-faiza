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
    public partial class vendor : Form
    {
        connection conn = new connection();
        public vendor()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            search sea = new search();
            sea.Show();

        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void vendor_Load(object sender, EventArgs e)
        {
            string[] Vcity = { "karachi", "lahore", "islamabad", "peshawer", "quetta" };
            this.comboBox1.Items.AddRange(Vcity);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Customer(cus_name,cus_code,cus_address,ph_no#,city,e_mail)values(@cus_name,@cus_code,@cus_address,@ph_no#,@city,@e_mail)", conn.sqlConnection1);

          
            cmd.Parameters.AddWithValue("@cus_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@cus_code", textBox3.Text);
            cmd.Parameters.AddWithValue("@City", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ph_no#", textBox5.Text);
          
            cmd.Parameters.AddWithValue("@cus_address", textBox4.Text);
            
            cmd.Parameters.AddWithValue("@e_mail", textBox6.Text);


           
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Inserted");
            conn.sqlConnection1.Close();
        }
    }
}
