using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagement
{
    public partial class Form_Account : Form
    {
        public Form_Account()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4R5HK14;Initial Catalog=ContactDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[tblUsers]
           ([FirstName]
           ,[LastName]
           ,[UserName]
           ,[Password])
     VALUES
           ('"+txtFName.Text.Trim()+"','"+txtLName.Text.Trim()+"','"+txtUserName.Text.Trim()+"','"+txtPassword.Text.Trim()+"')",conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Register Successfully","Registered",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
