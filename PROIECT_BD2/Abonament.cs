using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROIECT_BD2
{
    public partial class Abonament : Form
    {
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";

        public Abonament()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Abonament", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
            MessageBox.Show("Select successful");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();


            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Abonament VALUES (@ID_Abonament, @Pret, @Durata_contract, @Tip_abonament)", con);
                cmd.Parameters.AddWithValue("@ID_Abonament", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Pret", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Durata_contract", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Tip_abonament", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Introduce successful");
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }

            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Abonament set Pret=@Pret, Durata_contract=@Durata_contract, Tip_abonament=@Tip_abonament where ID_Abonament=@ID_Abonament)", con);
                cmd.Parameters.AddWithValue("@ID_Abonament", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Pret", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Durata_contract", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Tip_abonament", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("UPDATE successful");
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
            SqlCommand cmd = new SqlCommand("DELETE FROM Abonament WHERE ID_Abonament=@ID_Abonament", con);
            cmd.Parameters.AddWithValue("@ID_Abonament", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successful");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT A.Tip_abonament FROM Abonament A " +
                "JOIN Abonamente_servicii A_S ON A.ID_Abonament = A_S.ID_Abonament " +
                "JOIN Serviciu S ON A_S.Tip_serviciu = S.Tip_serviciu " +
                "WHERE S.An_infiintare >= 1995 AND A.Pret <= 100;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; con.Close();
            MessageBox.Show("Command successful");
        }
    }
}
