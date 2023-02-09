using CrystalDecisions.CrystalReports.Engine;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
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
    public partial class frmAnyDocument_CR : Form
    {
        public frmAnyDocument_CR()
        {
            InitializeComponent();
        }


        private void frmAnyDocument_CR_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (crvAnyDocument.ReportSource != null)
            //{
            //    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //    rd.Close();
            //    rd.Dispose();

            //    this.crvAnyDocument.ReportSource = null;
            //    this.crvAnyDocument.Dispose();
            //    this.crvAnyDocument = null;

            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //    GC.Collect();
            //}
            //else
            //{
            //    //MessageBox.Show("test");
            //}
        }
    }
}
