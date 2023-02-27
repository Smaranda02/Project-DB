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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROIECT_BD2
{
    public partial class Partener : Form
    {
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";
        public Partener()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Partener WHERE Nume=@Nume)", con);
            cmd.Parameters.AddWithValue("@Nume", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successful");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Partener", con);
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
            SqlCommand cmd = new SqlCommand("INSERT INTO Partener VALUES (@Nume, @Durata_contract, @Infrastructura_impartita)", con);
            cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
            cmd.Parameters.AddWithValue("@Durata_contract", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Infrastructura_impartita", int.Parse(textBox3.Text));
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
            SqlCommand cmd = new SqlCommand("UPDATE Partener set  Durata_contract=@Durata_contract, Infrastructura_impartita=@Infrastructura_impartita where Nume=@Nume", con);
            cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
            cmd.Parameters.AddWithValue("@Durata_contarct", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Infrastructura_impartita", textBox3.Text);
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
