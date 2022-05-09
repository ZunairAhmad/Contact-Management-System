using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLRDbConnector;
using System.Data.SqlClient;
using System.Windows.Forms;
using ContactManagement.Forms;

namespace ContactManagement
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        DbConnector db;
        public Form1()
        {
            InitializeComponent();
            // db = new DbConnector();
             conn = new SqlConnection("Data Source=DESKTOP-4R5HK14;Initial Catalog=ContactDb;Integrated Security=True");
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4R5HK14;Initial Catalog=ContactDb;Integrated Security=True");
            string query = "Select * from tblUsers where UserName = '" + txtUserName.Text.Trim()+"'and Password = '" + txtPassword.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query,conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (isFormValid())
            {
                if (dt.Rows.Count == 1)
                {
                    Form_Dashboard fd = new Form_Dashboard();
                    this.Hide();
                    fd.Show();
                    
                }
                else
                {
                    MessageBox.Show("Username or Password is Incorrect \n", "Incorrect Details", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);


                    
                }

            }
        }

        private bool isFormValid()
        {
            if(txtUserName.Text.ToString().Trim() == String.Empty || txtPassword.Text.ToString().Trim().Trim() == String.Empty)
            {
                MessageBox.Show("Required Field are Empty", "Please Fill all the fields.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Form_Account fa = new Form_Account();
            this.Hide();
            fa.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


//private bool checkingLogin()
//{
//    DataTable dt = new DataTable();
//    string query = "Select * from tblUsers where UserName = '" + txtUserName.Text.Trim() + "'and Password = '" + txtPassword.Text.Trim() + "'";
//    if (dt.Rows.Count == 1)
//    {
//        Form_Dashboard fd = new Form_Dashboard();
//        this.Hide();
//        fd.Show();
//        return true;
//    }
//    else
//    {
//        MessageBox.Show("Username or Password is Incorrect \n", "Incorrect Details", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);


//        return false;
//    }
//}