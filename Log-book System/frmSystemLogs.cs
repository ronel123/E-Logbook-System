using Log_book_System.Classes.Database;
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
    public partial class frmSystemLogs : Form
    {
        public frmSystemLogs()
        {
            InitializeComponent();
        }

        Settings settingsObj = new Settings();
        DataTable dt = new DataTable();

        private void frmSystemLogs_Load(object sender, EventArgs e)
        {
            LoadSystemLogsData();
            SizeLastColumn(lvSystemLogs);
        }

        public void LoadSystemLogsData()
        {
            try
            {
                lvSystemLogs.Items.Clear();
                lvSystemLogs.SmallImageList = lvSystemLogs.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                dt = settingsObj.GetSystemLogs();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        lvSystemLogs.Items.Add(
                          new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["timestamp"].ToString(),
                            row["name"].ToString(),
                            row["action"].ToString(),
                            row["description"].ToString(),
                            row["status"].ToString() }
                          ));
                        lvSystemLogs.TopItem = lvSystemLogs.Items.Cast<ListViewItem>().LastOrDefault();
                        //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                    }
                }
            }
            catch { }
        }

        private void txtFiltername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSystemLogs.Items.Clear();
                lvSystemLogs.SmallImageList = lvSystemLogs.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                dt = settingsObj.GetSystemLogsDataAndFilter("%" + txtFiltername.Text.ToString() + "%");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        lvSystemLogs.Items.Add(
                          new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["timestamp"].ToString(),
                            row["name"].ToString(),
                            row["action"].ToString(),
                            row["description"].ToString(),
                            row["status"].ToString() }
                          ));
                        lvSystemLogs.TopItem = lvSystemLogs.Items.Cast<ListViewItem>().LastOrDefault();
                        //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                    }
                }
                //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
            }
            catch { }
        }

        private void lvSystemLogs_Resize(object sender, EventArgs e)
        {
            SizeLastColumn((System.Windows.Forms.ListView)sender);
        }

        private void SizeLastColumn(System.Windows.Forms.ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }
    }
}
