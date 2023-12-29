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

namespace TA
{
    public partial class TALogin : Form
    {
        public TALogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                string username = user.Text;
                string password = pass.Text;

                string query = "SELECT COUNT(*) FROM Credentials WHERE Username = @Username AND Password = @Password AND UserType='ta'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    string UID = "SELECT UserID FROM Credentials WHERE Username = @Username AND Password = @Password AND UserType='ta'";
                    SqlCommand u = new SqlCommand(UID, con);
                    u.Parameters.AddWithValue("@Username", username);
                    u.Parameters.AddWithValue("@Password", password);

                    object result = u.ExecuteScalar();
                    int USERID = result != DBNull.Value ? Convert.ToInt32(result) : 0;  // Safely handling potential null values

                    MessageBox.Show("Login Successful!");
                    TAView form2 = new TAView();
                    form2.user_ID = USERID;
                    form2.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Visible = true;
            this.Visible = false;
        }
    }
}
