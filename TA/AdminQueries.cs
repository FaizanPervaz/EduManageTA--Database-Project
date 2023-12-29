using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA
{
    public partial class AdminQueries : Form
    {
        public AdminQueries()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AdminQuery1 form1 = new AdminQuery1();
            form1.Visible = true;
            this.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AdminQuery2 form1 = new AdminQuery2();
            form1.Visible = true;
            this.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AdminQuery3 form1 = new AdminQuery3();
            form1.Visible = true;
            this.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AdminQuery4 form1 = new AdminQuery4();
            form1.Visible = true;
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminView ad = new AdminView();
            ad.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminQuery5 ad = new AdminQuery5();
            ad.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminQuery6 ad = new AdminQuery6();
            ad.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminQuery7 ad = new AdminQuery7();
            ad.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminQuery8 ad = new AdminQuery8();
            ad.Visible = true;
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminQuery9 ad = new AdminQuery9();
            ad.Visible = true;
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminQuery10 ad = new AdminQuery10();
            ad.Visible = true;
            this.Visible = false;
        }
    }
}
