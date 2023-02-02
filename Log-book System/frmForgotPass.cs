using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log_book_System.Classes.Database;
using Log_book_System.Classes.Variable;

namespace Log_book_System
{
    public partial class frmForgotPass : Form
    {
        public frmForgotPass()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        public int code;

        // Calling the Account Class and intantiate it to 'userAccount' object
        Account userAccount = new Account();
        DataTable accTable = new DataTable(); // Intantiate a DataTable as 'accTable'

        private void pbSentEmail_Click(object sender, EventArgs e)
        {
            checkEmailAccount();
        }

        public void checkEmailAccount()
        {
            // Calling the Account Class and intantiate it to 'userAccount' object
            Account userAccount = new Account();
            DataTable accTable = new DataTable(); // Intantiate a DataTable as 'accTable'
            accTable = userAccount.ReadEmailAccount(txtEmailAdd.Text); // store the return value of readAccount method from the Account class
            if (accTable.Rows.Count > 0)
            {
                mail();
            }
            else
            {
                lblSentEmail.Visible = true;
                lblSentEmail.Text = "That email does not exists!";
                lblSentEmail.ForeColor = Color.Red;

                //System logs and actions records.
                Settings settings = new Settings();
                settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Email Address", "User's attempting to forgot password with email " + txtEmailAdd.Text + ", email doesn't exist", "Failed");
            }
        }

        private void mail()
        {
            try
            {
                code = rnd.Next(123123, 999999);
                //This will be generate password from Google App password
                const string p = "etlllouzybcjfujn";

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("qas.forgotpass404@gmail.com", "Queueing Advance Solution");

                message.To.Add(new MailAddress(txtEmailAdd.Text));
                message.Subject = "Forgot password";
                //message.Body = "Your verification code is:\n" + code + "\nThank you!";
                message.Body = "<table class=\"body-wrap\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; width: 100%; background-color: #f6f6f6; margin: 0;\" bgcolor=\"#f6f6f6\">\r\n" +
                    "    <tbody>\r\n" +
                    "        <tr style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "            <td style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0;\" valign=\"top\"></td>\r\n" +
                    "            <td class=\"container\" width=\"600\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto;\"\r\n" +
                    "                valign=\"top\">\r\n" +
                    "                <div class=\"content\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; max-width: 600px; display: block; margin: 0 auto; padding: 20px;\">\r\n" +
                    "                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-radius: 3px; background-color: #fff; margin: 0; border: 1px solid #e9e9e9;\"\r\n" +
                    "                        bgcolor=\"#fff\">\r\n" +
                    "                        <tbody>\r\n" +
                    "                            <tr style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                <td class=\"\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 16px; vertical-align: top; color: #fff; font-weight: 500; text-align: center; border-radius: 3px 3px 0 0; background-color: #38414a; margin: 0; padding: 20px;\"\r\n" +
                    "                                    align=\"center\" bgcolor=\"#71b6f9\" valign=\"top\">\r\n" +
                    "                                    <a style=\"font-size:32px; cursor: text; color:#fff;\"> Queueing Advance Solution</a> <br>\r\n" +
                    "                                    <span style=\"margin-top: 5px;display: block;\">Powered by QAS Team</span>\r\n" +
                    "                                </td>\r\n" +
                    "                            </tr>\r\n" +
                    "                            <tr style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                <td class=\"content-wrap\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 20px;\" valign=\"top\">\r\n" +
                    "                                    <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                        <tbody>\r\n" +
                    "                                            <tr style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                                <td class=\"content-block\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">\r\n" +
                    "                                                    The <strong style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                                       Queueing solution</strong> received a request to use " + txtEmailAdd.Text + " as a recovery email for your system Account.\r\n" +
                    "                                                </td>\r\n" +
                    "                                            </tr>\r\n" +
                    "                                            <tr style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                                <td class=\"content-block\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">\r\n" +
                    "                                                    Use this code to finish setting up this recovery email:\r\n" +
                    "                                                </td>\r\n                                            </tr>\r\n" +
                    "                                            <tr style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                                <td class=\"content-block\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">\r\n" +
                    "                                                    <p style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; color: #FFF; text-decoration: none; line-height: 2em; font-weight: bold; text-align: center; cursor: text; display: inline-block; border-radius: 5px; text-transform: capitalize; background-color: #f1556c; margin: 0; border-color: #f1556c; border-style: solid; border-width: 4px 16px;\"> " + code + "\r\n" +
                    "                                                </p>\r\n" +
                    "                                                </td>\r\n" +
                    "                                            </tr>\r\n" +
                    "                                            <tr style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                                <td class=\"content-block\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">\r\n" +
                    "                                                    Thanks for choosing <b>Queueing Advance Solution</b> <br>Administrator.\r\n" +
                    "                                                </td>\r\n" +
                    "                                            </tr>\r\n" +
                    "                                        </tbody>\r\n" +
                    "                                    </table>\r\n" +
                    "                                </td>\r\n" +
                    "                            </tr>\r\n" +
                    "                        </tbody>\r\n" +
                    "                    </table>\r\n" +
                    "                    <div class=\"footer\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; width: 100%; clear: both; color: #999; margin: 0; padding: 20px;\">\r\n                        <table width=\"100%\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                            <tbody>\r\n" +
                    "                                <tr style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\">\r\n" +
                    "                                    <td class=\"aligncenter content-block\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 12px; vertical-align: top; color: #999; text-align: center; margin: 0; padding: 0 0 20px;\" align=\"center\" valign=\"top\"><a href=\"#\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 12px; color: #999; text-decoration: underline; margin: 0;\">Queueing Advance Solution with RFID & SMS Notification</a>\r\n" +
                    "                                    </td>\r\n" +
                    "                                </tr>\r\n" +
                    "                            </tbody>\r\n" +
                    "                        </table>\r\n" +
                    "                    </div>\r\n" +
                    "                </div>\r\n" +
                    "            </td>\r\n" +
                    "            <td style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0;\" valign=\"top\"></td>\r\n" +
                    "        </tr>\r\n" +
                    "    </tbody>\r\n</table>";

                message.IsBodyHtml = true;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("qas.forgotpass404@gmail.com", p);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

                lblSentEmail.Text = "Please check your email address";
                lblSentEmail.Visible = true;
                //MessageBox.Show("Email has been successfully sent to " + txtUsername.Text, "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Enabled = true;
                txtCode.Focus();
                txtEmailAdd.Enabled = false;

                //System logs and actions records.
                Settings settings = new Settings();
                settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Email Address", "User's sent a email with " +txtEmailAdd.Text+" to get verification code", "Success");
            }
            catch 
            {
                // MessageBox.Show(ex.ToString());
                //MessageBox.Show("Email has not successfully sent to " + txtUsername.Text + "\nPlease check your intertet connection.", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblSentEmail.Visible = true;
                lblSentEmail.Text = "Please check your connection";
                lblSentEmail.ForeColor = Color.Red;

                //System logs and actions records.
                Settings settings = new Settings();
                settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Email Address", "User's not successfully sent a email with " + txtEmailAdd.Text + ", connection failed", "Failed");

            }
        }

        private void txtEmailAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                checkEmailAccount();
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (code.ToString() == txtCode.Text)
            {
                txtNewPass.Enabled = true;
                txtPass.Enabled = true;
                txtCode.Enabled = false;
                txtNewPass.Focus();
                pbCheck.Visible = true;
                pbWrong.Visible = false;
            }
            else
            {
                txtNewPass.Enabled = false;
                txtPass.Enabled = false;
                pbCheck.Visible = false;
                pbWrong.Visible = true;
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
                        userAccount.ForgotPassword(txtEmailAdd.Text, txtPass.Text);
                        MessageBox.Show("Your new password has been successfully updated!", "E-Logbook System - Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //System logs and actions records.
                        Settings settings = new Settings();
                        settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Forgot Password", "User's change password", "Success");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occured during updating of this data, Please try-again thank you.", "E-Logbook System - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //System logs and actions records.
                        Settings settings = new Settings();
                        settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Forgot Password", "User's cancel during changing password", "Failed");

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Your user password doesn't match. Please try again.", "E-Logbook System - Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //System logs and actions records.
                    Settings settings = new Settings();
                    settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Forgot Password", "User's changing password with not matched password", "Failed");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtNewPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnChange.PerformClick();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnChange.PerformClick();
            }
        }
    }
}
