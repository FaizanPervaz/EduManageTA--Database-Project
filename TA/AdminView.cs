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
    public partial class AdminView : Form
    {
        public int user_ID { set; get; }

        public AdminView()
        {
            InitializeComponent();
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
                    string query = "SELECT c.Username,s.Email,s.CGPA " +
                           "FROM Credentials c " +
                           "INNER JOIN Student s ON c.UserID = s.UserID ";

                    SqlCommand cmd = new SqlCommand(query, con);

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

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    string query = "SELECT c.Username, c.Password, c.UserType " +
                                    "FROM Credentials c";

                    SqlCommand cmd = new SqlCommand(query, con);

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

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    string query = "SELECT c.Username,s.Email,s.ContactInformation,s.Qualifications,s.Availability_Start,s.Availability_End " +
                           "FROM Credentials c " +
                           "INNER JOIN TA_Demonstrator s ON c.UserID = s.UserID ";

                    SqlCommand cmd = new SqlCommand(query, con);

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

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    string query = "SELECT c.Username, s.ContactInformation, s.Department " +
                           "FROM Credentials c " +
                           "INNER JOIN FacultyMembers s ON c.UserID = s.UserID";

                    SqlCommand cmd = new SqlCommand(query, con);

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
            Form1 temp = new Form1();
            temp.Visible = true;
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    string query = "SELECT fe.Feedback_ID, fm.Name AS 'Faculty Teacher Name', td.Name AS 'Given to Which TA', " +
                                   "fe.Feedback_Description, fe.Rating, fe.Date " +
                                   "FROM Feedback_Evaluation fe " +
                                   "INNER JOIN FacultyMembers fm ON fe.From_Faculty = fm.UserID " +
                                   "INNER JOIN TA_Demonstrator td ON fe.To_TA = td.UserID";

                    SqlCommand cmd = new SqlCommand(query, con);

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

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    string query = "SELECT *" +
                                   "FROM Logtable";

                    SqlCommand cmd = new SqlCommand(query, con);

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

        private void button8_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Get the input from the textbox
                    string query = "SELECT ta.Task_ID, ta.Assignment_ID, ta.Faculty_ID,                         t.Task_Description, t.Deadline, ta.Assigned_Date, t.Status " +
                                    "FROM Tasks t " +
                                    "INNER JOIN TaskAssignments ta ON t.Task_ID = ta.Task_ID";


                    SqlCommand cmd = new SqlCommand(query, con);

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

        private void button9_Click(object sender, EventArgs e)
        {
            AdminUpdate temp = new AdminUpdate();   
            temp.user_ID = user_ID;
            temp.Visible = true;
            this.Visible = false;
        }

        

        private void button14_Click(object sender, EventArgs e)
        {
            AdminQueries ad = new AdminQueries();
            ad.Visible = true;
            this.Visible = false;
        }
    }
}
