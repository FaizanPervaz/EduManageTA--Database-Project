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
    public partial class AdminUpdate : Form
    {
        public int user_ID { set; get; }

        public AdminUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    int userID = 1; 
                    string username = user.Text;
                    string password = pass.Text;

                    string credentialsQuery = @"UPDATE Credentials 
                                        SET Username = @Username, Password = @Password 
                                        WHERE UserID = @UserID";

                    SqlCommand credentialsCmd = new SqlCommand(credentialsQuery, con);
                    credentialsCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                    credentialsCmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    credentialsCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    int rowsAffected = credentialsCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data has been updated");
                        // Additional actions after successful update
                        AdminForm fa = new AdminForm();
                        fa.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No data updated. Check if the user ID exists.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminView ad = new AdminView();
            ad.Visible = true;
            this.Visible = false;
        }
    }
}
