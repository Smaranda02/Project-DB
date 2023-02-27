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
    public partial class Serviciu : Form
    {
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";
        public Serviciu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Serviciu", con);
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
            SqlCommand cmd = new SqlCommand("INSERT INTO Serviciu VALUES (@Tip_serviciu, @An_infiintare, @Nr_tari_acoperire)", con);
            cmd.Parameters.AddWithValue("@Tip_serviciu", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@An_infiintare", DateTime.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Nr_tari_acoperire", int.Parse(textBox3.Text));
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
            SqlCommand cmd = new SqlCommand("UPDATE Serviciu set An_infiintare=@An_infiintare, Nr_tari_acoperire=@Nr_tari_acoperire where Tip_serviciu=@Tip_serviciu)", con);
            cmd.Parameters.AddWithValue("@Tip_serviciu", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@An_infiintare", DateTime.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Nr_tari_acoperire", int.Parse(textBox3.Text));
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
            SqlCommand cmd = new SqlCommand("DELETE FROM Serviciu WHERE Tip_serviciu=@Tip_serviciu)", con);
            cmd.Parameters.AddWithValue("@Tip_serviciu", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successful");
        }
    }
}
