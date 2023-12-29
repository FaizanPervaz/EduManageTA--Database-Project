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
    public partial class FacultyTAView : Form
    {
        public int user_ID { set; get; }

        public FacultyTAView()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    int userID = user_ID;

                    string query = "SELECT s.Name AS 'TA Name', f.Name AS 'Faculty Name', rl.Role_ID, rl.Subject " +
                                   "FROM UserRoles ur " +
                                   "INNER JOIN TA_Demonstrator s ON ur.TA_ID = s.UserID " +
                                   "INNER JOIN FacultyMembers f ON ur.Of_Faculty = f.UserID " +
                                   "INNER JOIN Roles rl ON ur.Role_ID = rl.Role_ID " +
                                   "WHERE ur.Of_Faculty = @UserID";


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

        private void button2_Click(object sender, EventArgs e)
        {
            FacultyAddTA formt = new FacultyAddTA();
            formt.user_ID = user_ID;
            formt.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FacultyView form1 = new FacultyView();
            form1.user_ID = user_ID;
            form1.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TAFeedback tAFeedback = new TAFeedback();
            tAFeedback.user_ID = user_ID;
            tAFeedback.Visible = true;
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

                    int userID = user_ID;

                    string query = "SELECT fe.Feedback_ID, fm.Name AS 'Faculty Teacher Name', td.Name AS 'Given to Which TA', " +
                                   "fe.Feedback_Description, fe.Rating, fe.Date " +
                                   "FROM Feedback_Evaluation fe " +
                                   "INNER JOIN FacultyMembers fm ON fe.From_Faculty = fm.UserID " +
                                   "INNER JOIN TA_Demonstrator td ON fe.To_TA = td.UserID " +
                                   "WHERE fe.From_Faculty = @UserID";

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

                    int userID = user_ID;

                    // Query to fetch tasks assigned to the TA
                    string query = "SELECT t.Task_ID, t.Task_Description, t.Deadline, t.Status, td.Name AS 'Assigned To' " +
                                   "FROM TaskAssignments ta " +
                                   "INNER JOIN Tasks t ON ta.Task_ID = t.Task_ID " +
                                   "INNER JOIN TA_Demonstrator td ON ta.TA_ID = td.UserID " +
                                   "WHERE ta.Faculty_ID = @UserID";



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

        private void userid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
