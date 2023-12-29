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
    public partial class TAView : Form
    {
        public TAView()
        {
            InitializeComponent();
        }

        public int user_ID { set; get; }


        private void TAView_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TAInfoShow form1 = new TAInfoShow();
            form1.user_ID = user_ID;
            form1.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TAUpdate form2 = new TAUpdate();
            form2.user_ID = user_ID;
            form2.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Visible = true;
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    int userID = user_ID;

                    string query = "SELECT f.Name AS 'Faculty Name', f.ContactInformation, f.Department, r.Subject " +
                                   "FROM TA_Demonstrator t " +
                                   "INNER JOIN UserRoles ur ON t.UserID = ur.TA_ID " +
                                   "INNER JOIN FacultyMembers f ON ur.Of_Faculty = f.UserID " +
                                   "INNER JOIN Roles r ON ur.Role_ID = r.Role_ID " +
                                   "WHERE t.UserID = @UserID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    var reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    int userID = user_ID;

                    string query = "SELECT f.Name AS 'Faculty Name', fe.Feedback_Description, fe.Rating, fe.Date " +
                                    "FROM Feedback_Evaluation fe " +
                                    "INNER JOIN FacultyMembers f ON fe.From_Faculty = f.UserID " +
                                    "WHERE fe.To_TA = @UserID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    var reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the TA's UserID from the textbox
                    int userID = user_ID;

                    // Query to fetch tasks assigned to the TA
                    string query = "SELECT t.Task_ID, t.Task_Description, t.Deadline, t.Status, fm.Name AS 'Assigned By' " +
                                   "FROM TaskAssignments ta " +
                                   "INNER JOIN Tasks t ON ta.Task_ID = t.Task_ID " +
                                   "INNER JOIN TA_Demonstrator td ON ta.TA_ID = td.UserID " +
                                   "LEFT JOIN FacultyMembers fm ON ta.Faculty_ID = fm.UserID " +
                                   "WHERE td.UserID = @UserID";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    var reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void userID_label_Click(object sender, EventArgs e)
        {
            userID_label.Text = user_ID.ToString();
        }

        private void TAView_Load_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    int UserID = user_ID;
                    con.Open();

                    string queryFeedback = "DELETE FROM Feedback_Evaluation WHERE To_TA = @UserID";
                    SqlCommand cmdFeedback = new SqlCommand(queryFeedback, con);
                    cmdFeedback.Parameters.AddWithValue("@UserID", user_ID);
                    cmdFeedback.ExecuteNonQuery();

                    string queryUserRoles = "DELETE FROM UserRoles WHERE TA_ID = @UserID";
                    SqlCommand cmdUserRoles = new SqlCommand(queryUserRoles, con);
                    cmdUserRoles.Parameters.AddWithValue("@UserID", user_ID);
                    cmdUserRoles.ExecuteNonQuery();

                    string queryTaskAssignments = "DELETE FROM TaskAssignments WHERE TA_ID = @UserID";
                    SqlCommand cmdTaskAssignments = new SqlCommand(queryTaskAssignments, con);
                    cmdTaskAssignments.Parameters.AddWithValue("@UserID", user_ID);
                    cmdTaskAssignments.ExecuteNonQuery();

                    string queryTADemonstrator = "DELETE FROM TA_Demonstrator WHERE UserID = @UserID; DELETE FROM Credentials WHERE UserID = @UserID";
                    SqlCommand cmdTADemonstrator = new SqlCommand(queryTADemonstrator, con);
                    cmdTADemonstrator.Parameters.AddWithValue("@UserID", user_ID);
                    cmdTADemonstrator.ExecuteNonQuery();

                    MessageBox.Show("TA data has been deleted.");
                    Form1 form = new Form1();
                    form.Visible = true;
                    this.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
