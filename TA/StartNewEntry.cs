using System;
using System.Windows.Forms;

namespace TA
{
    public partial class StartNewEntry : Form
    {
        public StartNewEntry()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentSignup form1 = new StudentSignup();
            form1.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FacultySignup form2 = new FacultySignup();
            form2.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TASignup form3 = new TASignup();
            form3.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 temp = new Form1();
            temp.Visible = true;
            this.Visible = false;
        }
    }
}
