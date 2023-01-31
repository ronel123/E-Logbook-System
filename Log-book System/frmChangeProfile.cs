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
    public partial class frmChangeProfile : Form
    {
        public frmChangeProfile()
        {
            InitializeComponent();
        }

        // Calling the Account Class and intantiate it to 'userAccount' object
        Account userAccount = new Account();
        DataTable accTable = new DataTable(); // Intantiate a DataTable as 'accTable'

        private void txtOldPass_TextChanged(object sender, EventArgs e)
        {
            checkOldPassword();
        }
        public void checkOldPassword()
        {
            accTable = userAccount.CheckPasswordAccount(txtOldPass.Text); // store the return value of readAccount method from the Account class
            if (accTable.Rows.Count > 0)
            {
                pbCheck.Visible = true;
                pbWrong.Visible = false;

                txtOldPass.ReadOnly = true;
                txtNewPass.Enabled = true;
                txtPass.Enabled = true;

                txtNewPass.Focus();                  
            }
            else
            {
                pbCheck.Visible = false;
                pbWrong.Visible = true;
                txtOldPass.ReadOnly = false;
                txtNewPass.Enabled = false;
                txtPass.Enabled = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("You cannot proceed when there is an empty fields!", "Empty Fields!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (txtNewPass.Text.Equals(txtPass.Text))   // Comparison
                {
                    if (MessageBox.Show("Are you sure want to change your user password", "E-Logbook System - Change Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        userAccount.ChangeUserPassword(txtPass.Text);
                        MessageBox.Show("Your new password has been successfully updated!", "E-Logbook System - Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occured during updating of this data, Please try-again thank you.", "E-Logbook System - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Your user password doesn't match. Please try again.", "E-Logbook System - Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnChange.PerformClick();
                txtNewPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnChange.PerformClick();
                txtPass.Focus();
            }
        }
    }
}
