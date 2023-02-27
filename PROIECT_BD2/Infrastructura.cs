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
    public partial class Infrastructura : Form
    {
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";

        public Infrastructura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Infrastructura", con);
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
            SqlCommand cmd = new SqlCommand("INSERT INTO Client VALUES (@ID_Infrastructura, @Nume, @Serviciu_ascociat, @Costuri_totale)", con);
            cmd.Parameters.AddWithValue("@ID_Infrastructura", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Nume", textBox2.Text);
            cmd.Parameters.AddWithValue("@Serviciu_asociat", textBox3.Text);
            cmd.Parameters.AddWithValue("@Costuri_totale", int.Parse(textBox4.Text));
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
            SqlCommand cmd = new SqlCommand("UPDATE Infrastructura set  Nume=@Nume, Serviciu_ascociat=@Serviciu_ascociat, Costuri_totale=@Costuri_totale where ID_Infrastructura=@ID_Infrastructura)", con);
            cmd.Parameters.AddWithValue("@ID_Infrastructura", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Nume", textBox2.Text);
            cmd.Parameters.AddWithValue("@Serviciu_asociat", textBox3.Text);
            cmd.Parameters.AddWithValue("@Costuri_totale", int.Parse(textBox4.Text));
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
            SqlCommand cmd = new SqlCommand("DELETE FROM Infrastructura WHERE ID_Infrastructura=@ID_Infrastructura)", con);
            cmd.Parameters.AddWithValue("@ID_Infrastructura", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successful");
        }

   
    }
}
