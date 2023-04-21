using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EXAMEN_DEL_2_PARCIAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string query = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();
                int result = (int)command.ExecuteScalar();
                connection.Close();
                if (result > 0)
                {
                    MessageBox.Show("Inicio de sesión exitoso.");
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                }
            }
        }
    }
}