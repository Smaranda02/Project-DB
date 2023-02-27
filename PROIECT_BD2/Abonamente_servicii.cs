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
    public partial class Abonamente_servicii : Form
    {
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";
        public Abonamente_servicii()
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Abonamente_servicii", con);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO Abonamente_servicii VALUES (@Tip_serviciu, @ID_abonament, @Serviciu_limitat)", con);
                cmd.Parameters.AddWithValue("@Tip_serviciu", textBox1.Text);
                cmd.Parameters.AddWithValue("@ID_abonament", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Serviciu_limitat", textBox3.Text);
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
                SqlCommand cmd = new SqlCommand("UPDATE Abonamente_servicii set Serviciu_limitat=@Serviciu_limitat WHERE Tip_serviciu=@Tip_serviciu, ID_abonament=@ID_abonament", con);
                cmd.Parameters.AddWithValue("@Tip_serviciu", textBox1.Text);
                cmd.Parameters.AddWithValue("@ID_abonament", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Serviciu_limitat", textBox3.Text);
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
            SqlCommand cmd = new SqlCommand("DELETE FROM  Abonamente_servicii WHERE Tip_serviciu=@Tip_serviciu AND ID_abonament=@ID_abonament", con);
            cmd.Parameters.AddWithValue("@Tip_serviciu", textBox1.Text);
            cmd.Parameters.AddWithValue("@ID_abonament", int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("UPDATE successful");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
