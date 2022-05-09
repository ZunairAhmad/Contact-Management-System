using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ContactManagement.Forms
{
    public partial class Form_Dashboard : Form
    {
        int panelWidth;
        bool Hidden;

        public Form_Dashboard()
        {
            InitializeComponent();
            timerTime.Start();
            panelWidth = panelLeft.Width;
            Hidden = false;
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 55)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblTime.Text = dt.ToString("HH:MM:ss");
        }

        private void addControls(UserControl uc)
        {
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            UserControls.UC_Contacts uc = new UserControls.UC_Contacts();
            addControls(uc);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UserControls.UC_Dashboard ud = new UserControls.UC_Dashboard();
            addControls(ud);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           UserControls.UC_Delete udel = new UserControls.UC_Delete();
            addControls(udel);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UserControls.UC_Edit ue = new UserControls.UC_Edit();
            addControls(ue);
        }
    }
}
