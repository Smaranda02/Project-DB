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
    public partial class Menu : Form
    {
        public string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smara\\Documents\\PROIECT.mdf;Integrated Security=True;Connect Timeout=30";

        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Height = 28;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Height == 226)
            {
                panel1.Height = 28;
            }
            else
            {
                panel1.Height = 226;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            Infrastructura infrastructura = new Infrastructura();
            infrastructura.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Abonament abonament = new Abonament();
            abonament.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Proiect proiect = new Proiect();
            proiect.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Abonamente_servicii abonamente_servicii = new Abonamente_servicii();
            abonamente_servicii.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Serviciu serviciu = new Serviciu();
            serviciu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Angajat angajat = new Angajat();
            angajat.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Partener partener = new Partener();
            partener.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Subscriptii subscriptii = new Subscriptii();
            subscriptii.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Proiect_Serviciu", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            MessageBox.Show("Select successful");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
