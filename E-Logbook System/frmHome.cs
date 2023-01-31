using Log_book_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Settings = Log_book_System.Classes.Database.Settings;

namespace Log_book_System
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private readonly string RANDOMFILE_LIST_COUNTER_STRING = "{0}";
        private readonly string FORM137_LIST_COUNTER_STRING = "{0}";
        private static Settings settings = new Settings();

        private void tmrDateTime_Tick(object sender, EventArgs e)
        {
            //tslDateTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            tslDateTime.Text = DateTime.Now.ToString("MMM. dd, yyyy - " + "dddd" + " hh:mm:ss tt");
            RefreshTotal();
        }

        public void RefreshTotal()
        {
            tslTotalRandomFile.Text = string.Format(RANDOMFILE_LIST_COUNTER_STRING, settings.GetTotalRandomFiles());
            tslTotalForm137.Text = string.Format(FORM137_LIST_COUNTER_STRING, settings.GetTotalForm137());
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            RefreshTotal();
        }
    }
}
