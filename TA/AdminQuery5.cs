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
    public partial class AdminQuery5 : Form
    {
        public AdminQuery5()
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
                    int count = int.Parse(st.Text);
                    string department = dept.SelectedItem.ToString();

                    string query = @"
                                    SELECT Faculty_ID, COUNT(*) AS TaskCount
                                    FROM TaskAssignments
                                    WHERE Faculty_ID IN (
                                        SELECT UserID 
                                        FROM FacultyMembers 
                                        WHERE Department = @department
                                    )
                                    GROUP BY Faculty_ID
                                    HAVING COUNT(*) > @count;";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Count", count);
                    cmd.Parameters.AddWithValue("@Department", department);

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
