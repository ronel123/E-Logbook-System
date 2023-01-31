using Log_book_System.Classes.Database;
using Log_book_System.Classes.Variable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_book_System
{
    public partial class frmLoginVerification : Form
    {
        public frmLoginVerification()
        {
            InitializeComponent();
        }

        private void frmLoginVerification_Load(object sender, EventArgs e)
        {

        }

        public void loginAcc()
        {
            // Calling the Account Class and intantiate it to 'userAccount' object
            Account userAccount = new Account();
            DataTable accTable = new DataTable(); // Intantiate a DataTable as 'accTable'
            accTable = userAccount.ReadAccount(txtUsername.Text); // store the return value of readAccount method from the Account class
            if (accTable.Rows.Count > 0)
            {
                //var userName = accTable.Rows[0]["user_name"];           // var is an object which we're going to store the value of accTable user_name
                var passWord = accTable.Rows[0]["password"];     // var is an object which we're going to store the value of accTable hashed_password

                if (txtPassword.Text.Equals(passWord.ToString()))   // Comparison
                {
                    Settings settings = new Settings();
                    settings.deleteRandomFiles(Global.frmRandomFilesid);

                    settings.deleteForm137Data(Global.frmForm137id);
                    MessageBox.Show("Data form has been successfully deleted!", "E-Logbook System - Powered by: ITech Digital Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You just input a wrong password!", "Account Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("That account does not exists!", "Account Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginAcc();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
                txtUsername.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
                txtPassword.Focus();
            }
        }
    }
}
