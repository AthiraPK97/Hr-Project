using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tempory_punching
{
    public partial class Form1 : Form
    {
        ServiceReference1.WebService1SoapClient objservice = new ServiceReference1.WebService1SoapClient();
        public Form1()
         {

                InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Get_EmployeeDetails(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.login(textBox1.Text,textBox2.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                textBox3.Text = dt.Rows[0]["log_user"].ToString();

            }
            else
            {
                label4.Text="invalid username or password";
            }
            Console.ReadLine();
        }

    }

    
}
