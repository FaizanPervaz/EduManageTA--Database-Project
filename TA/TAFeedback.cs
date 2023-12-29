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
    public partial class TAFeedback : Form
    {
        public int user_ID { set; get; }

        public TAFeedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fromFacultyID = user_ID; // Assuming 'from' textbox contains the faculty ID
            int toTADemonstratorID = int.Parse(to.Text); // Assuming 'to' textbox contains the TA ID
            string feedbackDescription = desc.Text; // Assuming 'desc' textbox contains the feedback description
            int rating = int.Parse(rate.Text); // Assuming 'rate' textbox contains the rating

            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Insert feedback into Feedback_Evaluation table
                    string query = "INSERT INTO Feedback_Evaluation (From_Faculty, To_TA, Feedback_Description, Rating, Date) " +
                                   "VALUES (@FromFacultyID, @ToTADemonstratorID, @FeedbackDescription, @Rating, GETDATE())";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FromFacultyID", fromFacultyID);
                    cmd.Parameters.AddWithValue("@ToTADemonstratorID", toTADemonstratorID);
                    cmd.Parameters.AddWithValue("@FeedbackDescription", feedbackDescription);
                    cmd.Parameters.AddWithValue("@Rating", rating);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Feedback submitted successfully!");
                        FacultyTAView facultyTAView = new FacultyTAView();
                        facultyTAView.user_ID = user_ID;
                        facultyTAView.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Failed to submit feedback.");
                        FacultyTAView facultyTAView = new FacultyTAView();
                        facultyTAView.user_ID = user_ID;
                        facultyTAView.Visible = true;
                        this.Visible = false;
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
            FacultyTAView f = new FacultyTAView();
            f.user_ID = user_ID;
            f.Visible = true;
            this.Visible = false;
        }

        private void from_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
