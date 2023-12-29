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
    public partial class AdminQuery9 : Form
    {
        public AdminQuery9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminQueries form = new AdminQueries();
            form.Visible = true;
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

                    // Get the input from the textbox
                    string query1 = @"
                        SELECT C.Username, F.Name, F.Department, T.Task_Description, T.Deadline
                        FROM Credentials C
                        JOIN FacultyMembers F ON C.UserID = F.UserID
                        JOIN TaskAssignments TA ON F.UserID = TA.Faculty_ID
                        JOIN Tasks T ON TA.Task_ID = T.Task_ID;
                    ";


                    SqlCommand cmd = new SqlCommand(query1, con);

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
    }
}
