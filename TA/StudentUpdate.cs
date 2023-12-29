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
    public partial class StudentUpdate : Form
    {
        public int user_ID { set; get; }

        public StudentUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                int userID = user_ID;
                string username = user.Text;
                string password = pass.Text;
                string email = em.Text;
                float cgpa = float.Parse(gpa.Text); // Convert CGPA to float

                // Update Credentials table if the UserID exists
                string query1 = "UPDATE Credentials SET Username = @Username, Password = @Password WHERE UserID = @UserID";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@UserID", userID);
                cmd1.Parameters.AddWithValue("@Username", username);
                cmd1.Parameters.AddWithValue("@Password", password);
                int rowsAffected1 = cmd1.ExecuteNonQuery();

                // Update Student table if the UserID exists
                string query2 = "UPDATE Student SET Email = @Email, CGPA = @CGPA WHERE UserID = @UserID";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@UserID", userID);
                cmd2.Parameters.AddWithValue("@Email", email);
                cmd2.Parameters.AddWithValue("@CGPA", cgpa);
                int rowsAffected2 = cmd2.ExecuteNonQuery();

                if (rowsAffected1 > 0 || rowsAffected2 > 0)
                {
                    MessageBox.Show("Data has been updated");
                    // Other actions after successful update
                    StudentView form2 = new StudentView();
                    form2.user_ID = user_ID;
                    form2.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("UserID not found, no data updated");
                    // Handle case where UserID does not exist
                    StudentView form3 = new StudentView();
                    form3.user_ID = user_ID;
                    form3.Visible = true;
                    this.Visible = false;
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
            StudentView temp = new StudentView();
            temp.user_ID = user_ID;
            temp.Visible = true;
            this.Visible = false;
        }

        private void userid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
