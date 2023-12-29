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
    public partial class StudentSignup : Form
    {
        public StudentSignup()
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

                int userID = Convert.ToInt32(userid.Text); // Convert UserID to int
                string username = user.Text;
                string password = pass.Text;
                string email = em.Text; 
                float cgpa = float.Parse(gpa.Text); // Convert CGPA to float

                // Insert into Credentials table using parameterized query
                string query1 = "INSERT INTO Credentials(UserID, Username, Password, UserType) VALUES (@UserID, @Username, @Password, 'student')";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@UserID", userID);
                cmd1.Parameters.AddWithValue("@Username", username);
                cmd1.Parameters.AddWithValue("@Password", password);
                cmd1.ExecuteNonQuery();

                // Insert into Student table using parameterized query
                string query2 = "INSERT INTO Student(UserID, Email, CGPA) VALUES (@UserID, @Email, @CGPA)";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@UserID", userID);
                cmd2.Parameters.AddWithValue("@Email", email);
                cmd2.Parameters.AddWithValue("@CGPA", cgpa);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Data has been saved");
                StudentLogin form2 = new StudentLogin();
                form2.Visible = true;
                this.Visible = false;
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
            Form1 temp = new Form1();
            temp.Visible = true;
            this.Visible = false;
        }
    }
}
