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
    public partial class FacultyGiveTask : Form
    {
        public int user_ID { set; get; }

        public FacultyGiveTask()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
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

                    int taskID = int.Parse(tid.Text);  // Convert the text to an integer
                    string taskDescription = desc.Text;  // Directly use the text
                    DateTime deadline = DateTime.Parse(dead.Text);  // Assuming dead is a TextBox containing date in a standard format
                    int facultyID = user_ID;  // Convert the text to an integer
                    int taID = int.Parse(taid.Text);
                    bool status = false;
                    DateTime assignedDate = DateTime.Now;  // Use current date for Assigned_Date

                    string query = "INSERT INTO Tasks (Task_ID, Task_Description, Deadline, Status) " +
                                   "VALUES (@TaskID, @TaskDescription, @Deadline, @Status); " +
                                   "INSERT INTO TaskAssignments (Assignment_ID, Task_ID, TA_ID, Faculty_ID, Assigned_Date) " +
                                   "VALUES (@TaskID, @TaskID, @TAID, @FacultyID, @AssignedDate)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@TaskID", taskID);
                    cmd.Parameters.AddWithValue("@TaskDescription", taskDescription);
                    cmd.Parameters.AddWithValue("@Deadline", deadline);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@TAID", taID);
                    cmd.Parameters.AddWithValue("@FacultyID", facultyID);
                    cmd.Parameters.AddWithValue("@AssignedDate", assignedDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task assigned successfully.");
                        FacultyTAView form1 = new FacultyTAView();
                        form1.user_ID = user_ID;
                        form1.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Assignment failed. Please check your inputs.");
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
            FacultyView facultyView = new FacultyView();
            facultyView.user_ID = user_ID;
            facultyView.Visible = true;
            this.Visible = false;
        }

        private void tid_TextChanged(object sender, EventArgs e)
        {

        }

        private void taid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
