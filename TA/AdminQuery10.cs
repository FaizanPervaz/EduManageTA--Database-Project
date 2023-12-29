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
    public partial class AdminQuery10 : Form
    {
        public AdminQuery10()
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
                    string query2 = @"
                        SELECT TD.Name, TD.Email, R.Role_Name, AVG(FE.Rating) AS AverageRating
                        FROM TA_Demonstrator TD
                        JOIN UserRoles UR ON TD.UserID = UR.TA_ID
                        JOIN Roles R ON UR.Role_ID = R.Role_ID
                        JOIN Feedback_Evaluation FE ON TD.UserID = FE.To_TA
                        GROUP BY TD.Name, TD.Email, R.Role_Name;
                    ";

                    SqlCommand cmd = new SqlCommand(query2, con);

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
