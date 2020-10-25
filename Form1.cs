using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginFormWinFormApplication
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-G78QN4D;Initial Catalog=userLogin;Integrated Security=True");
            string query = "select * from logins where username = '" + textBox1.Text.Trim()+"'and password = '"+textBox2.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count == 1)
            {
                formLoggedIn objfrmLoggedIn = new formLoggedIn();
                this.Hide();
                objfrmLoggedIn.Show();

            }
            else
            {
                MessageBox.Show("Please check your username and password");
            }
        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
