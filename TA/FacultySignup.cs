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
    public partial class FacultySignup : Form
    {
        public FacultySignup()
        {
            InitializeComponent();
        }

        private void dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDepartment = dept.SelectedItem.ToString();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dept.Items.AddRange(new string[] { "Computer Science", "Data Science", "Artificial Intelligence" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    int userID = Convert.ToInt32(userid.Text);
                    string username = user.Text;
                    string password = pass.Text;
                    string contact_info = contact.Text;
                    string department = dept.SelectedItem.ToString(); // Get selected department

                    // Insert into Credentials table using parameterized query
                    string query1 = "INSERT INTO Credentials(UserID, Username, Password, UserType) VALUES (@UserID, @Username, @Password, 'faculty')";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@UserID", userID);
                    cmd1.Parameters.AddWithValue("@Username", username);
                    cmd1.Parameters.AddWithValue("@Password", password);
                    cmd1.ExecuteNonQuery();

                    // Insert into FacultyMembers table using parameterized query
                    string query2 = "INSERT INTO FacultyMembers(UserID, Name,ContactInformation, Department) " +
                                    "VALUES (@UserID, @Name, @ContactInfo, @Department)";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@UserID", userID);
                    cmd2.Parameters.AddWithValue("@Name", username);
                    cmd2.Parameters.AddWithValue("@ContactInfo", contact_info);
                    cmd2.Parameters.AddWithValue("@Department", department);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Data has been saved");
                    FacultyLogin form2 = new FacultyLogin();
                    form2.Visible = true;
                    this.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 temp = new Form1();
            temp.Visible = true;
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
