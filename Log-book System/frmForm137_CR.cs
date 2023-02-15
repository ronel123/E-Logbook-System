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
    public partial class frmForm137_CR : Form
    {
        public frmForm137_CR()
        {
            InitializeComponent();
        }

        private void frmForm137_CR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (crvForm137.ReportSource != null)
            {
                CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rd.Close();
                rd.Dispose();

                this.crvForm137.ReportSource = null;
                this.crvForm137.Dispose();
                this.crvForm137 = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            else
            {
                //MessageBox.Show("test");
            }
        }
    }
}
