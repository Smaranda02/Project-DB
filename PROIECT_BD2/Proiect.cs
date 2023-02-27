using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROIECT_BD2
{
    public partial class Proiect : Form
    {
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";

        public Proiect()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Proiect WHERE Nr_proiect=@Nr_proiect)", con);
            cmd.Parameters.AddWithValue("@Nr_proiect", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successful");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Proiect", con);
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
            try { 
            SqlCommand cmd = new SqlCommand("INSERT INTO Proiect VALUES (@Nr_proiect, @Nume, @Suma_alocata, @Data_incepere, @Data_finalizare, @Infrastructura_primita)", con);
            cmd.Parameters.AddWithValue("@Nr_proiect", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Nume", textBox2.Text);
            cmd.Parameters.AddWithValue("@Suma_alocata", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Data_incepere", DateTime.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Data_finalizare", DateTime.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Infrastructura_primita", int.Parse(textBox6.Text));
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
            try { 
            SqlCommand cmd = new SqlCommand("UPDATE Proiect set  Nume=@Nume, Suma_alocata=@Suma_alocata, Data_incepere=@Data_incepere, Data_finalizare=@Data_finalizare, Infrastructura_primita=@Infrastructura_primita where Nr_proiect=@Nr_proiect", con);
            cmd.Parameters.AddWithValue("@Nr_proiect", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Nume", textBox2.Text);
            cmd.Parameters.AddWithValue("@Suma_alocata", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Data_incepere", DateTime.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Data_finalizare", DateTime.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Infrastructura_primita", int.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("UPDATE successful");
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }
            con.Close();
        }
    }
}
