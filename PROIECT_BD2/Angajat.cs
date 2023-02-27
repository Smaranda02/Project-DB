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
    public partial class Angajat : Form
    {
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";

        public Angajat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Angajat ORDER BY Salariu ", con);
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
            try { 
            SqlCommand cmd = new SqlCommand("UPDATE Angajat set Nume=@Nume, Prenume=@Prenume, Salariu=@Salariu, Functie=@Functie, ID_infrastructura=@ID_infrastructura" +
                " where ID_Angajat=@ID_Angajat)", con);
            cmd.Parameters.AddWithValue("@ID_Angajat", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Nume", textBox2.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox3.Text);
            cmd.Parameters.AddWithValue("@Salariu", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Functie", textBox5.Text);
            cmd.Parameters.AddWithValue("@ID_infrastructura", int.Parse(textBox6.Text));
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
            SqlCommand cmd = new SqlCommand("DELETE FROM Angajat WHERE ID_Angajat=@ID_Angajat)", con);
            cmd.Parameters.AddWithValue("@ID_Angajat", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successful");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            try { 
            SqlCommand cmd = new SqlCommand("INSERT INTO Angajat VALUES (@ID_Angajat, @Nume, @Prenume, @Salariu, @Functie, @ID_infrastructura)");
            cmd.Parameters.AddWithValue("@ID_Angajat", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Nume", textBox2.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox3.Text);
            cmd.Parameters.AddWithValue("@Salariu", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Functie", textBox5.Text);
            cmd.Parameters.AddWithValue("@ID_infrastructura", int.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Introduce successful");
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(" SELECT A.ID_infrastructura, COUNT(A.ID_Angajat) Nr_anagajati\r\n" +
                "FROM Angajat A\r\nGROUP BY A.ID_infrastructura\r\nHAVING A.ID_Infrastructura>2;\r\n", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; con.Close();
            MessageBox.Show("Command successful");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Infrastructura_angajati", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; con.Close();
            MessageBox.Show("Command successful");
        }
    }
}

