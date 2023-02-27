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
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.CodeDom;

namespace PROIECT_BD2
{
    public partial class Client : Form
    {
        public string externalConnection = @"Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PROIECT.mdf;Integrated Security = True; Connect Timeout = 30";
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";
        public Client()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Client VALUES (@ID_client, @Data_subscriere, @Nume, @Prenume, @Tip_client, @Cod_unic_identificare)", con);
            cmd.Parameters.AddWithValue("@ID_Client", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Data_subscriere", DateTime.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Nume", textBox3.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox4.Text);
            cmd.Parameters.AddWithValue("@Tip_client" , textBox5.Text);
            cmd.Parameters.AddWithValue("@Cod_unic_identificare", textBox6.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Introduce successful");

            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Client WHERE ID_Client=@ID_Client", con);
            cmd.Parameters.AddWithValue("@ID_Client", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successful");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Client", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
            MessageBox.Show("Select successful");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            try
            {
            SqlCommand cmd = new SqlCommand("UPDATE Client set Data_subscriere=@Data_subscriere, Nume=@Nume, Prenume=@Prenume, Tip_client=@Tip_client, Cod_unic_identificare=@Cod_unic_identificare where ID_Client = @ID_client", con);
            cmd.Parameters.AddWithValue("@ID_Client", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Data_subscriere", DateTime.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Nume", textBox3.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox4.Text);
            cmd.Parameters.AddWithValue("@Tip_client", textBox5.Text);
            cmd.Parameters.AddWithValue("@Cod_unic_identificare", textBox6.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("UPDATE successful");

            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }


            con.Close();
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
