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
    public partial class TAUpdate : Form
    {
        public int user_ID { set; get; }

        public TAUpdate()
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

                int userID = user_ID; // Convert UserID to int
                string username = user.Text;
                string password = pass.Text;
                string name = user.Text;
                string email = em.Text;
                string contactInfo = contact.Text;
                string qualifications = q.Text;
                string availabilityStart = from.Text;
                string availabilityEnd = till.Text;

                // Update Credentials table with username and password
                string credentialsQuery = @"UPDATE Credentials 
                                    SET Username = @Username, Password = @Password 
                                    WHERE UserID = @UserID";

                SqlCommand credentialsCmd = new SqlCommand(credentialsQuery, con);
                credentialsCmd.Parameters.AddWithValue("@UserID", userID);
                credentialsCmd.Parameters.AddWithValue("@Username", username);
                credentialsCmd.Parameters.AddWithValue("@Password", password);
                credentialsCmd.ExecuteNonQuery();

                // Update TA_Demonstrator table with other details
                string taQuery = @"UPDATE TA_Demonstrator 
                           SET Name = @Name, Email = @Email, 
                               ContactInformation = @ContactInfo, 
                               Qualifications = @Qualifications, 
                               Availability_Start = @AvailStart, 
                               Availability_End = @AvailEnd 
                           WHERE UserID = @UserID";

                SqlCommand taCmd = new SqlCommand(taQuery, con);
                taCmd.Parameters.AddWithValue("@UserID", userID);
                taCmd.Parameters.AddWithValue("@Name", name);
                taCmd.Parameters.AddWithValue("@Email", email);
                taCmd.Parameters.AddWithValue("@ContactInfo", contactInfo);
                taCmd.Parameters.AddWithValue("@Qualifications", qualifications);
                taCmd.Parameters.AddWithValue("@AvailStart", availabilityStart);
                taCmd.Parameters.AddWithValue("@AvailEnd", availabilityEnd);
                taCmd.ExecuteNonQuery();

                MessageBox.Show("Data has been updated");
                TAView tAView = new TAView();
                tAView.Visible = true;
                this.Visible = false;
            }
            catch (Exception ex)
            {
                // Handle case where UserID does not exist
                TAView form3 = new TAView();
                form3.user_ID = user_ID;
                form3.Visible = true;
                this.Visible = false;
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TAView form2 = new TAView();
            form2.user_ID = user_ID;
            form2.Visible = true;
            this.Visible = false;
        }

        private void TAUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
