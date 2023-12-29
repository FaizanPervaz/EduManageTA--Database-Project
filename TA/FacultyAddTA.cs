using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA
{
    public partial class FacultyAddTA : Form
    {
        public int user_ID { set; get; }

        public FacultyAddTA()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacultyTAView view = new FacultyTAView();
            view.Visible = true;
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

                    int RoleID = int.Parse(rid.Text);
                    string RoleName = rname.Text;
                    string subject = sub.Text;
                    int Faculty = user_ID;
                    int TA_Demonstrator = int.Parse(ta.Text);

                    // First, insert into Roles table
                    string queryRole = "INSERT INTO Roles(Role_ID, Role_Name, Subject) " +
                                       "VALUES (@RoleID, @RoleName, @Subject)";

                    SqlCommand cmdRole = new SqlCommand(queryRole, con);
                    cmdRole.Parameters.AddWithValue("@RoleID", RoleID);
                    cmdRole.Parameters.AddWithValue("@RoleName", RoleName);
                    cmdRole.Parameters.AddWithValue("@Subject", subject);

                    cmdRole.ExecuteNonQuery();

                    // Then, insert into UserRoles table
                    string queryUserRole = "INSERT INTO UserRoles(TA_ID, Of_Faculty, Role_ID) " +
                                           "VALUES (@TAID, @Faculty, @RoleID)";

                    SqlCommand cmdUserRole = new SqlCommand(queryUserRole, con);
                    cmdUserRole.Parameters.AddWithValue("@TAID", TA_Demonstrator);
                    cmdUserRole.Parameters.AddWithValue("@Faculty", Faculty);
                    cmdUserRole.Parameters.AddWithValue("@RoleID", RoleID);

                    int rowsAffected = cmdUserRole.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New TA assigned to Faculty added successfully.");
                        FacultyTAView view = new FacultyTAView();
                        view.user_ID = user_ID;
                        view.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Insertion failed. Please check your inputs.");
                        FacultyTAView view = new FacultyTAView();
                        view.user_ID = user_ID;
                        view.Visible = true;
                        this.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void offaculty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
