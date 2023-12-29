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

    public partial class FacultyUpdate : Form
    {
        public int user_ID { set; get; }

        public FacultyUpdate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int USERID = user_ID;
            FacultyView facultyView = new FacultyView();
            facultyView.user_ID = USERID;
            facultyView.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    int userID = user_ID;
                    string username = user.Text;
                    string password = pass.Text;
                    string contact_info = contact.Text;
                    string department = dept.SelectedItem.ToString(); 

                    // Update Credentials table with username and password
                    string credentialsQuery = @"UPDATE Credentials 
                                        SET Username = @Username, Password = @Password 
                                        WHERE UserID = @UserID";

                    SqlCommand credentialsCmd = new SqlCommand(credentialsQuery, con);
                    credentialsCmd.Parameters.AddWithValue("@UserID", userID);
                    credentialsCmd.Parameters.AddWithValue("@Username", username);
                    credentialsCmd.Parameters.AddWithValue("@Password", password);
                    credentialsCmd.ExecuteNonQuery();

                    // Update FacultyMembers table with other details
                    string facultyQuery = @"UPDATE FacultyMembers 
                                    SET Name = @Name, ContactInformation = @ContactInfo, Department = @Department 
                                    WHERE UserID = @UserID";

                    SqlCommand facultyCmd = new SqlCommand(facultyQuery, con);
                    facultyCmd.Parameters.AddWithValue("@UserID", userID);
                    facultyCmd.Parameters.AddWithValue("@Name", username);
                    facultyCmd.Parameters.AddWithValue("@ContactInfo", contact_info);
                    facultyCmd.Parameters.AddWithValue("@Department", department);
                    facultyCmd.ExecuteNonQuery();

                    MessageBox.Show("Data has been updated");
                    // Additional actions after successful update
                    FacultyView fa = new FacultyView();
                    fa.user_ID = userID;
                    fa.Visible = true;
                    this.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void userid_TextChanged(object sender, EventArgs e)
        {

        }

        private void dept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
