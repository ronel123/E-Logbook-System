using Log_book_System.Classes.Database;
using Log_book_System.Classes.Variable;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Global = Log_book_System.Classes.Variable.Global;

namespace Log_book_System
{
    public partial class frmRandomFiles : Form
    {
        private static Settings accountObject = new Settings();

        public frmRandomFiles(int id)
        {
            InitializeComponent();
            Global.frmRandomFilesid = id;
        }

        public void InitForm()
        {
            try
            {
                cmbStatus.SelectedIndex = 1;
                /* Load the specific Account and update the input fields */
                DataTable accountTable = new DataTable();
                accountTable = accountObject.ReadRandomFiles(Global.frmRandomFilesid);

                txtTypeOfDocs.Text = accountTable.Rows[0]["typeofdocuments"].ToString();
                txtReceivedFrom.Text = accountTable.Rows[0]["receivedby"].ToString();            
                rtRemarks.Text = accountTable.Rows[0]["remarks"].ToString();
                cmbStatus.Text = accountTable.Rows[0]["status"].ToString();
            }
            catch { }
        }

        private bool IsInputFormsEmpty()
        {
            if (txtTypeOfDocs.Text == "" || txtReceivedFrom.Text == "" || rtRemarks.Text == "" || cmbStatus.Text == "")
                return true;
            else return false;
        }

        private void frmRandomFiles_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        public void resetField()
        {
            txtTypeOfDocs.Focus();
            txtReceivedFrom.Text = "";
            txtTypeOfDocs.Text = "";
            rtRemarks.Text = "";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Submit")
            {
                if (IsInputFormsEmpty())
                {
                    MessageBox.Show("You cannot proceed when there is an empty fields!", "Empty Fields!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are you sure want to encode this form data to Random Files?", "Random Files - Creating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Settings settings = new Settings();
                        settings.inputRandomFiles(txtTypeOfDocs.Text, txtReceivedFrom.Text, rtRemarks.Text, cmbStatus.Text);
                        MessageBox.Show("Data form has been successfully submitted!", "Random Files - Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetField();
                    }
                    else
                    {
                        MessageBox.Show("An error occured during submitting of this data, Please try-again thank you.", "Random Files - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (btnSubmit.Text == "Update")
            {
                if (MessageBox.Show("Are you sure want to update this form data to Random Files?", "Random Files - Updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings settings = new Settings();
                    settings.updateRandomFiles(txtTypeOfDocs.Text, txtReceivedFrom.Text, rtRemarks.Text, cmbStatus.Text, Global.frmRandomFilesid);
                    MessageBox.Show("Data form has been successfully updated!", "Random Files - Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("An error occured during updating of this data, Please try-again thank you.", "Form 137/SF10 - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this form data to Random Files?", "Random Files - Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmLoginVerification frmLoginVerification = new frmLoginVerification();
                frmLoginVerification.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("An error occured during deleting of this data, Please try-again thank you.", "Random Files - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRandomFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmHistoryOfFiles.frmHistoryOfFilesInstance.LoadForm137Data();
                frmHistoryOfFiles.frmHistoryOfFilesInstance.LoadRandomFilesData();
            }
            catch { }
        }

        private void rtRemarks_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }
    }
}
