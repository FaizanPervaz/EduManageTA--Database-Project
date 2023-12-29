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
    public partial class TASignup : Form
    {
        public TASignup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-25N2OHF\\SQLEXPRESS;Initial Catalog=TA;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                int userID = Convert.ToInt32(userid.Text);
                string username = user.Text;
                string password = pass.Text;
                string email = em.Text;
                string contact_info = contact.Text;
                string qualification = q.Text;
                string avail_From = from.Text; 
                string avail_Till = till.Text; 

                string query1 = "INSERT INTO Credentials(UserID, Username, Password, UserType) VALUES (@UserID, @Username, @Password, 'ta')";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@UserID", userID);
                cmd1.Parameters.AddWithValue("@Username", username);
                cmd1.Parameters.AddWithValue("@Password", password);
                cmd1.ExecuteNonQuery();

                string query2 = "INSERT INTO TA_Demonstrator(UserID, Name, Email, ContactInformation, Qualifications, Availability_Start, Availability_End) " +
                                "VALUES (@UserID, @Name, @Email, @ContactInfo, @Qualification, @AvailFrom, @AvailTill)";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@UserID", userID);
                cmd2.Parameters.AddWithValue("@Name", username); 
                cmd2.Parameters.AddWithValue("@Email", email);
                cmd2.Parameters.AddWithValue("@ContactInfo", contact_info);
                cmd2.Parameters.AddWithValue("@Qualification", qualification);
                cmd2.Parameters.AddWithValue("@AvailFrom", avail_From);
                cmd2.Parameters.AddWithValue("@AvailTill", avail_Till);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Data has been saved");
                TALogin form2 = new TALogin();
                form2.Visible = true;
                this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TASignup_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 tAView = new Form1();
            tAView.Visible = true;
            this.Visible = false;
        }
    }
}
