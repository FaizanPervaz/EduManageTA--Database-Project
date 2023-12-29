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
    public partial class FacultyView : Form
    {
        public int user_ID { set; get; }
        public FacultyView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int USERID = user_ID;
            FacultyInfoShow form1 = new FacultyInfoShow();
            form1.user_ID = USERID;
            form1.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int USERID = user_ID;
            FacultyUpdate form2 = new FacultyUpdate();
            form2.user_ID = USERID;
            form2.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FacultyLogin form3 = new FacultyLogin();
            form3.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int USERID = user_ID;
            FacultyTAView form4 = new FacultyTAView();
            form4.user_ID = USERID;
            form4.Visible = true;
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int USERID = user_ID;
            FacultyGiveTask formt = new FacultyGiveTask();
            formt.user_ID = USERID;
            formt.Visible = true;
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    int UserID = user_ID;
                    con.Open();

                    string queryFeedback = "DELETE FROM Feedback_Evaluation WHERE From_Faculty IN (SELECT UserID FROM FacultyMembers WHERE UserID = @UserID)";
                    SqlCommand cmdFeedback = new SqlCommand(queryFeedback, con);
                    cmdFeedback.Parameters.AddWithValue("@UserID", user_ID); 
                    cmdFeedback.ExecuteNonQuery();

                    string queryUserRoles = "DELETE FROM UserRoles WHERE Of_Faculty = @UserID";
                    SqlCommand cmdUserRoles = new SqlCommand(queryUserRoles, con);
                    cmdUserRoles.Parameters.AddWithValue("@UserID", user_ID); 
                    cmdUserRoles.ExecuteNonQuery();

                    string queryTasks = "DELETE FROM TaskAssignments WHERE Faculty_ID = @UserID";
                    SqlCommand cmdTasks = new SqlCommand(queryTasks, con);
                    cmdTasks.Parameters.AddWithValue("@UserID", user_ID); 
                    cmdTasks.ExecuteNonQuery();

                    string queryFaculty = "DELETE FROM FacultyMembers WHERE UserID = @UserID; DELETE FROM Credentials WHERE UserID = @UserID";
                    SqlCommand cmdFaculty = new SqlCommand(queryFaculty, con);
                    cmdFaculty.Parameters.AddWithValue("@UserID", user_ID); 
                    cmdFaculty.ExecuteNonQuery();

                    MessageBox.Show("Faculty data has been deleted.");
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
