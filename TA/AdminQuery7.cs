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
    public partial class AdminQuery7 : Form
    {
        public AdminQuery7()
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

                    string query = @"
                                    SELECT FM.Department, COUNT(TA.Task_ID) AS TotalTasks
                                    FROM FacultyMembers FM
                                    JOIN TaskAssignments TA ON FM.UserID = TA.Faculty_ID
                                    GROUP BY FM.Department;
                                ";


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
            AdminQueries form = new AdminQueries();
            form.Visible = true;
            this.Visible = false;
        }
    }
}
