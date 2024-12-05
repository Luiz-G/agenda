using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            string id = Guid.NewGuid().ToString();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=true;";
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = String.Format("INSERT INTO Contato (Id, Nome) VALUES ('{0}', '{1}');", id, nome);

            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();

            sql = String.Format("SELECT Nome FROM Contato WHERE Id = '{0}'", id);

            cmd = new SqlCommand(sql, connection);
            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            connection.Close();
        }
    }
}
