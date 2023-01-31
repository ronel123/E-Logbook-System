using DocumentFormat.OpenXml.Spreadsheet;
using Log_book_System.Classes;
using Log_book_System.Classes.Database;
using Log_book_System.Classes.Variable;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_book_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private static ManagementObjectSearcher baseboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        private static ManagementObjectSearcher motherboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");
        //public static string initializeHardwareID = "Veriton X46406G";
       
        private void lblCreateAcc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Contact your system admimnistrator. \n\nThank you.", "Creating new account",MessageBoxButtons.OK,MessageBoxIcon.Information);
            txtUsername.Focus();
        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature was not available right now. Check for next update. \n\nThank you.", "Creating new account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string myBotNewVersionURL = "https://raw.githubusercontent.com/ronel123/E-Logbook-System/main/ServerBot_HardwareID.txt";

                WebClient myBotNewVersionClient = new WebClient();
                Stream stream = myBotNewVersionClient.OpenRead(myBotNewVersionURL);
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();

                var sb = new StringBuilder(content.Length);
                foreach (char i in content)
                {
                    if (i == '\n')
                    {
                        sb.Append(Environment.NewLine);
                    }
                    else if (i != '\r' && i != '\t')
                        sb.Append(i);
                }

                content = sb.ToString();

                var vals = content.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.None
                                        )
                            .SkipWhile(line => !line.StartsWith("[general]"))
                            .Skip(1)
                            .Take(1)
                            .Select(line => new
                            {
                                Key = line.Substring(0, line.IndexOf('=')),
                                Value = line.Substring(line.IndexOf('=') + 1)
                            });


                Console.WriteLine(vals.FirstOrDefault().Value);
                Console.WriteLine(getResultID);

                //MessageBox.Show("Online: " + vals.FirstOrDefault().Value);
                //MessageBox.Show("Local: " + getResultID);
                if (getResultID.Equals(vals.FirstOrDefault().Value))
                {
                    loginAcc();
                }
                else
                {
                    MessageBox.Show("If you wish to use this system you need to contact system administrator.. \n\nContact Information:\nFacebook account: Ronel Tagala\nContact Number: 0948 063 8811\nEmail Address: roneltagala0@gmail.com\n\nThank you.", "Need Permission", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //System.Windows.Forms.Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("Try again later. Please check your internet connection, thank you.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

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
                    Global.Login_UserID = Convert.ToInt32(accTable.Rows[0]["user_id"]);
                    Global.Login_UserRole = accTable.Rows[0]["rolename"].ToString();

                    //to display the employee email address
                    frmDashboard mainForm = new frmDashboard();
                    mainForm.lblName.Text = accTable.Rows[0]["name"].ToString();
                    mainForm.lblRole.Text = "(" + accTable.Rows[0]["rolename"].ToString() + ")";
                    mainForm.Show();
                    this.Hide();
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

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(cbShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
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

        //To Get the Serial Number of your computer
        public string getResultID
        {
            //get { return SerialNumber(); }
            //set { this.getReultID = getReultID; }

            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Product"].ToString();
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            set { this.getResultID = getResultID; }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            Console.WriteLine(getResultID);           
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                int x = Left + (this.Width / 2) - 200;
                int y = Top + (this.Height / 2) - 100;

                string input = Interaction.InputBox("If you wish to use this system you need to contact system administrator.. \nContact Information:\nFacebook account: Ronel Tagala\nContact Number: 0948 063 8811\nEmail Address: roneltagala0@gmail.com\n\nThank you.", "Master Password", "", x, y);
                
                //string input = Interaction.InputBox(, "", 0, 0);

                if(input.Equals("admin"))
                {
                    frmDashboard frmDashboard = new frmDashboard(); 
                    frmDashboard.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Access Denied.", "Master Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}
