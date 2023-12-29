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
    public partial class StudentView : Form
    {
        public int user_ID { set; get; }

        public StudentView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInfoShow form1 = new StudentInfoShow();
            form1.user_ID = user_ID;
            form1.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentUpdate form2 = new StudentUpdate();
            form2.user_ID = user_ID;
            form2.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    int UserID = user_ID;
                    con.Open();

                    string queryFaculty = "DELETE FROM Student WHERE UserID = @UserID; DELETE FROM Credentials WHERE UserID = @UserID";
                    SqlCommand cmdFaculty = new SqlCommand(queryFaculty, con);
                    cmdFaculty.Parameters.AddWithValue("@UserID", user_ID);
                    cmdFaculty.ExecuteNonQuery();

                    MessageBox.Show("Student data has been deleted.");
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
