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

namespace Bank_App
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("add_transaction_info_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Account_No_from", textBox1.Text);
            cmd.Parameters.AddWithValue("@Account_No_to", textBox2.Text);
            cmd.Parameters.AddWithValue("@Amount_Transfer", textBox3.Text);

            // set the balance from 
            SqlCommand cmd2 = new SqlCommand("update_balance_from_SP", con);
            cmd2.CommandType = CommandType.StoredProcedure;

            // set the balance to
            SqlCommand cmd3 = new SqlCommand("update_balance_to_SP", con);
            cmd3.CommandType = CommandType.StoredProcedure;

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                label4.Text = "Successfull Transfer!";

            }
            catch (Exception ex)
            {
                MessageBox.Show("invalid" + ex);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            this.Hide();
            obj.Show();
        }
    }
}
