using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_book_System
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void llblRonel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.llblRonel.Links[llblRonel.Links.IndexOf(e.Link)].Visited = true;

            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.facebook.com/tagalaronel15/");
            Process.Start(sInfo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
