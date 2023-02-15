using Log_book_System.Classes.Database;
using Log_book_System.Classes.Variable;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        static string profilePicPath = "";
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
                        CopyImageFromPictureboxToDirectory();
                        MessageBox.Show("Your new password has been successfully updated!", "E-Logbook System - Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmDashboard.frmDashboardInstance.pbProfile.Image = frmDashboard.frmDashboardInstance.LoadBitmap();
                        //System logs and actions records.
                        Settings settings = new Settings();
                        settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Change Password", "User's change password", "Success");
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occured during updating of this data, Please try-again thank you.", "E-Logbook System - Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //System logs and actions records.
                        Settings settings = new Settings();
                        settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Change Password", "User's cancel during changing password", "Failed");

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Your user password doesn't match. Please try again.", "E-Logbook System - Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //System logs and actions records.
                    Settings settings = new Settings();
                    settings.systemLogs(Convert.ToInt32(Global.Login_UserID), "Change Password", "User's changing password with not matched password", "Failed");
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

        private void lblChangeProfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files (*.jpg;*.jpeg;.*.png; | *.jpg;*.jpeg;.*.png;)";
                    ofd.FilterIndex = 1;
                    ofd.Multiselect = false;
                    ofd.Title = "Select Image File";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string location = ofd.FileName;
                        profilePicPath = location;
                        pbProfile.Image = Image.FromFile(location);
                        pbProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        //pbProfile.BackgroundImage = Properties.Resources.defaultprofile;
                    }
                }
            } catch
            { MessageBox.Show("Something error, please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }          
        }
        public void CopyImageFromPictureboxToDirectory()
        {
            try
            {
                string fileName = Global.Login_UserID + ".Jpg";
                string sourcePath = profilePicPath;

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath);
                string destFile = System.IO.Path.Combine(Global.PROFILEPICTURES_PATH, fileName);

                // To copy a folder's contents to a new location:
                // Create a new target folder.
                // If the directory already exists, this method does not create a new directory.
                System.IO.Directory.CreateDirectory(Global.PROFILEPICTURES_PATH);

                // To copy a file to another location and
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);

                // To copy all the files in one directory to another directory.
                // Get the files in the source folder. (To recursively iterate through
                // all subfolders under the current directory, see
                // "How to: Iterate Through a Directory Tree.")
                // Note: Check for target path was performed previously
                //       in this code example.
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(Global.PROFILEPICTURES_PATH, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    //MessageBox.Show("Source path does not exists, please browse profile pic", "System Error");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString() +" "+"Invalid Path");
                pbProfile.Image = Properties.Resources.defaultuser;
            }
        }

        private void frmChangeProfile_Load(object sender, EventArgs e)
        {
            pbProfile.Image = LoadBitmap();
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
    }
}
