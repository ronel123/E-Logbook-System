using Log_book_System.Classes.Database;
using Log_book_System.Classes.Variable;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DataTable = System.Data.DataTable;
using Global = Log_book_System.Classes.Variable.Global;

namespace Log_book_System
{
    public partial class frmForm137 : Form
    {
       
        private static Settings accountObject = new Settings();

        public frmForm137(int id)
        {
            InitializeComponent();
            Global.frmForm137id = id;
        }

        public void InitForm()
        {
            try
            {
                cmbStatus.SelectedIndex = 0;
                /* Load the specific Account and update the input fields */
                DataTable accountTable = new DataTable();
                accountTable = accountObject.ReadForm137Data(Global.frmForm137id);

                txtFname.Text = accountTable.Rows[0]["first_name"].ToString();
                txtMname.Text = accountTable.Rows[0]["middle_name"].ToString();
                txtLname.Text = accountTable.Rows[0]["last_name"].ToString();
                cmbGradeLevel.Text = accountTable.Rows[0]["gradelevel"].ToString();
                cmbStatus.Text = accountTable.Rows[0]["status"].ToString();
                rtSchool.Text = accountTable.Rows[0]["previous_school"].ToString();
                rtRemarks.Text = accountTable.Rows[0]["outgoing_remarks"].ToString();
            }
            catch { }          
        }

        private void frmForm137_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private bool IsInputFormsEmpty()
        {
            if (txtFname.Text == "" || txtLname.Text == "" || rtSchool.Text == "" || cmbGradeLevel.Text == "")
                return true;
            else return false;
        }

        public void resetField()
        {
            txtLname.Focus();
            txtFname.Text = "";
            txtLname.Text = "";
            txtMname.Text = "";
            rtSchool.Text = "";
            cmbGradeLevel.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(btnSubmit.Text == "Submit")
            {
                if (IsInputFormsEmpty())
                {
                    MessageBox.Show("You cannot proceed when there is an empty fields!", "Empty Fields!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are you sure want to encode this form data to Form 137/SF10?", "Form 137/SF10 - Creating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Settings settings = new Settings();
                        settings.inputDataForm137(txtFname.Text, txtMname.Text, txtLname.Text, cmbGradeLevel.Text, rtSchool.Text, cmbStatus.Text);
                        MessageBox.Show("Data form has been successfully submitted!", "Form 137/SF10 - Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetField();
                    }
                    else
                    {
                        MessageBox.Show("An error occured during submitting of this data, Please try-again thank you.", "Form 137/SF10 - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if(btnSubmit.Text == "Update")
            {
                if (MessageBox.Show("Are you sure want to update this form data to Form 137/SF10?", "Form 137/SF10 - Updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings settings = new Settings();
                    settings.updateDataForm137(txtFname.Text, txtMname.Text, txtLname.Text, cmbGradeLevel.Text, rtSchool.Text, cmbStatus.Text, Global.frmForm137id, rtRemarks.Text);
                    MessageBox.Show("Data form has been successfully updated!", "Form 137/SF10 - Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("An error occured during updating of this data, Please try-again thank you.", "Form 137/SF10 - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmForm137_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmHistoryOfFiles.frmHistoryOfFilesInstance.LoadForm137Data();
                frmHistoryOfFiles.frmHistoryOfFilesInstance.LoadRandomFilesData();
            }
            catch { }          
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this form data to Form 137/SF10?", "Form 137/SF10 - Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmLoginVerification frmLoginVerification = new frmLoginVerification();
                frmLoginVerification.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("An error occured during deleting of this data, Please try-again thank you.", "Form 137/SF10 - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbStatus.SelectedIndex == 0)
            {
                lblRemarks.Visible = false;
                rtRemarks.Visible = false;
            }
            else if(cmbStatus.SelectedIndex == 1)
            {
                lblRemarks.Visible = true;
                rtRemarks.Visible = true;
            }
        }

        private void rtSchool_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }
    }
}
