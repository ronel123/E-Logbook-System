using Log_book_System.Classes.Variable;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_book_System
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        bool sidebarExpand;
        public static frmDashboard frmDashboardInstance;

        private void pbMenu_Click(object sender, EventArgs e)
        {
            tmrSlideBar.Start();
        }

        private void tmrSlideBar_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                lblName.Visible = false;
                lblRole.Visible = false;
                pbProfile.Visible = false;
                pnlSidebar.Width -= 10;
                if (pnlSidebar.Width == pnlSidebar.MinimumSize.Width)
                {

                    sidebarExpand = false;
                    tmrSlideBar.Stop();
                }
            }
            else
            {
                lblName.Visible = true;
                lblRole.Visible = true;
                pbProfile.Visible = true;
                pnlSidebar.Width += 10;
                if (pnlSidebar.Width == pnlSidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    tmrSlideBar.Stop();
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmHome myForm = new frmHome();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(myForm);

            foreach (Control control in pnlForm.Controls)
            {

                if (control != myForm) { control.Hide(); }
                else { control.Show(); control.Focus(); }

            }
        }

        private void btnRandomFiles_Click(object sender, EventArgs e)
        {
            frmRandomFiles myForm = new frmRandomFiles(0);
            myForm.ShowDialog();
        }

        private void btnForm137_Click(object sender, EventArgs e)
        {
            frmForm137 myForm = new frmForm137(0);
            myForm.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmHistoryOfFiles myForm = new frmHistoryOfFiles();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(myForm);

            foreach (Control control in pnlForm.Controls)
            {

                if (control != myForm) { control.Hide(); }
                else { control.Show(); control.Focus(); }

            }
        }

        private void btnSystemLogs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature was not yet added! Wait for the next update.", "Feature not available.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            btnSystemLogs.Enabled = false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature was not yet added! Wait for the next update.", "Feature not available.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            btnSettings.Enabled = false;
        }
             
        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout myForm = new frmAbout();
            myForm.ShowDialog();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            frmDashboardInstance = this;

            btnHome.PerformClick();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to Logout Your Account?", "Log-book System - Powered by: ITech Digital Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmLogin myForm = new frmLogin();
                myForm.Show();
                this.Hide();
            }
            else { }
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            frmChangeProfile myForm = new frmChangeProfile();
            myForm.ShowDialog();
        }
    }
}
