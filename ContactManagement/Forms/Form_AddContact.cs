using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SLRDbConnector;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagement.Forms
{
    public partial class Form_AddContact : Form
    {
      
        public Form_AddContact()
        {
            InitializeComponent();
          
        }

        private void Form_AddContact_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                insertValues();

            }
        }

        private void insertValues()
        {
            DialogResult dr = MessageBox.Show("Are you sure Want to add this work?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(dr == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4R5HK14;Initial Catalog=ContactDb;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[tblContacts]
           ([ContactFirstName]
           ,[ContactLastName]
           ,[ContactFatherName]
           ,[ContactGender]
           ,[ContactDOB]
           ,[ContactAddress]
           ,[ContactCity]
           ,[ContactCountry]
           ,[ContactOccupation]
           ,[ContactEmail]
           ,[ContactNo1]
           ,[ContactNo2])
     VALUES
           ('"+txtCFirstName.Text.Trim()+"','"+txtCLastName.Text.Trim()+"','"+txtCFatherName.Text.Trim()+"','" +
           cbGender.Text.Trim()+"','"+dtpDOB.Text.Trim()+"','"+txtAddress.Text.Trim()+"','"+txtCity.Text.Trim()+"','" +
           txtCountry.Text.Trim() + "','"+txtOccupation.Text.Trim()+"','"+txtEmail.Text.Trim()+"','"+txtCno1.Text.Trim()+"','"+txtCno2.Text.Trim()+"')",conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Register Successfully", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private bool isFormValid()
        {
            if (txtCFirstName.Text.Trim() == String.Empty || cbGender.Text.Trim() == String.Empty 
                || dtpDOB.Text.Trim() == String.Empty || txtAddress.Text.Trim() == String.Empty
                || txtCity.Text.Trim() == String.Empty || txtCountry.Text.Trim() == String.Empty
                || txtEmail.Text.Trim() == String.Empty || txtCno1.Text.Trim() == String.Empty
                )
            {
                MessageBox.Show("Required Field are Empty", "Please Fill all the fields.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
