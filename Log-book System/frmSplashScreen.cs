using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_book_System
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void tmrLoading_Tick(object sender, EventArgs e)
        {
            pbLoading.Value = 0;
            for (int i = 0; pbLoading.Value < 100; i++)
            {
                pbLoading.Value = i;
                System.Threading.Thread.Sleep(50);
            }
            tmrLoading.Stop();
            this.Hide();
            frmLogin mainForm = new frmLogin();
            mainForm.ShowDialog();
        }
    
        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
           
        }
    }
}
