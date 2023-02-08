using Log_book_System.Classes.Database;
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
using DataTable = System.Data.DataTable;
using Point = System.Drawing.Point;

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
        Settings settingsObj = new Settings();
        DataTable dt = new DataTable();
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
            frmSystemLogs myForm = new frmSystemLogs();
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature was not yet added! Wait for the next update.", "Feature not available.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //btnSettings.Enabled = false;
            cmsSettings.Show(btnSettings, new Point(btnSettings.Width - cmsSettings.Width, btnSettings.Height));
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

        private void anyDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnyDocument_CR myForm = new frmAnyDocument_CR();

            try
            {
                dt = settingsObj.GetRandomFilesData();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CrystalReport_AnyDocument crAnyDocuments = new CrystalReport_AnyDocument();
                        crAnyDocuments.SetDataSource(dt);
                        myForm.crvAnyDocument.ReportSource = crAnyDocuments;

                        myForm.crvAnyDocument.Refresh();
                        //myForm.crvAnyDocument.Dispose();
                    }
                    myForm.ShowDialog();
                }
            }
            catch { }
        }

        private void form137ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmForm137_CR myForm = new frmForm137_CR();
            
            try
            {
                dt = settingsObj.GetForm137Data();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CrystalReport_Form137 crAnyDocuments = new CrystalReport_Form137();
                        crAnyDocuments.SetDataSource(dt);
                        myForm.crvForm137.ReportSource = crAnyDocuments;

                        myForm.crvForm137.Refresh();                     
                        //myForm.crvAnyDocument.Dispose();
                    }
                    myForm.ShowDialog();
                }
            }
            catch { }
        }
    }
}
