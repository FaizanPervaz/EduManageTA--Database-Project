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
    public partial class AdminQuery3 : Form
    {
        public AdminQuery3()
        {
            InitializeComponent();
        }

        private void AdminQuery3_Load(object sender, EventArgs e)
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

                    string department = dept.SelectedItem.ToString();

                    string query = @"
                                    SELECT Feedback_Description
                                    FROM Feedback_Evaluation
                                    WHERE From_Faculty IN (
                                        SELECT UserID
                                        FROM FacultyMembers
                                        WHERE Department = @department);";



                    SqlCommand cmd = new SqlCommand(query, con);
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
