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
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Global = Log_book_System.Classes.Variable.Global;
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
                pnlSidebar.Width -= 10;
                pnlProfile.Visible = false;
                if (pnlSidebar.Width == pnlSidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    tmrSlideBar.Stop();
                }
            }
            else
            {               
                pnlSidebar.Width += 10;
                if (pnlSidebar.Width == pnlSidebar.MaximumSize.Width)
                {
                    pnlProfile.Visible = true;
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
            MessageBox.Show("Notice: \nYour data has been automatically save to the local folder. If you want to check the file, go to application directory folder..\n\nThank you.. ", "Back-up Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmDashboardInstance = this;
            pbProfile.Image = LoadBitmap();
            btnHome.PerformClick();
        }
        public Bitmap LoadBitmap()
        {
            string tempStr = string.Format("{0}{1}.jpg", Global.PROFILEPICTURES_PATH, Global.Login_UserID);
            if (File.Exists(tempStr))
            {
                // open file in read only mode
                using (FileStream stream = new FileStream(tempStr, FileMode.Open, FileAccess.Read))
                // get a binary reader for the file stream
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // copy the content of the file into a memory stream
                    var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                    // make a new Bitmap object the owner of the MemoryStream
                    return new Bitmap(memoryStream);
                }
            }
            else
            {
                //MessageBox.Show("Error Loading File.", "Empty Profile!", MessageBoxButtons.OK);
                pbProfile.Image = Properties.Resources.defaultuser;
                return null;
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to Logout Your Account?", "Log-book System - Powered by: ITech Digital Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    frmHistoryOfFiles.frmHistoryOfFilesInstance.savedataAutomaticallyToCsvFile();
                }
                catch
                {
                    MessageBox.Show("Notice: \nYour data was not changed or check to the history. But your last data will be automatically saved. If you want to check the file, go to application directory folder..\n\nThank you.. ", "Back-up Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                frmLogin myForm = new frmLogin();
                myForm.Show();
                this.Hide();
            }
            else { }
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmHistoryOfFiles.frmHistoryOfFilesInstance.savedataAutomaticallyToCsvFile();
            }
            catch
            {
                MessageBox.Show("Notice: \nYour data was not changed or check to the history. But your last data will be automatically saved. If you want to check the file, go to application directory folder..\n\nThank you.. ", "Back-up Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
