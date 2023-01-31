using Log_book_System.Classes.Database;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Log_book_System
{
    public partial class frmHistoryOfFiles : Form
    {
        public frmHistoryOfFiles()
        {
            InitializeComponent();
        }

        Settings settingsObj = new Settings();
        DataTable dt = new DataTable();
        public static frmHistoryOfFiles frmHistoryOfFilesInstance;

        private void frmHistoryOfFiles_Load(object sender, EventArgs e)
        {
            frmHistoryOfFilesInstance = this;
           
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("randomfile_tbl", "Random Documents");
            comboSource.Add("form137file_tbl", "Form 137/SF10");
            cmbStoreData.DataSource = new BindingSource(comboSource, null);
            cmbStoreData.DisplayMember = "Value";
            cmbStoreData.ValueMember = "Key";
            cmbStoreData.SelectedIndex = 1;
            LoadRandomFilesData();
        }

        private void cmbStoreData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbStoreData.SelectedValue.Equals("randomfile_tbl"))
            {
                LoadRandomFilesData();
                lvRandomFiles.Visible = true;
                lvForm137.Visible = false;
                txtFiltername.Text = "";
            }
            else if(cmbStoreData.SelectedValue.Equals("form137file_tbl"))
            {
                LoadForm137Data();
                lvForm137.Visible = true;
                lvRandomFiles.Visible = false;
                txtFiltername.Text = "";
            }
        }

        public void LoadForm137Data()
        {
            try
            {
                lvForm137.Items.Clear();
                lvForm137.SmallImageList = lvForm137.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                dt = settingsObj.GetForm137Data();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        lvForm137.Items.Add(
                          new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["created"].ToString(),
                            row["name"].ToString(),
                            row["gradelevel"].ToString(),
                            row["previous_school"].ToString(),
                            row["status"].ToString() }
                          ));
                        lvForm137.TopItem = lvForm137.Items.Cast<ListViewItem>().LastOrDefault();
                        //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                    }
                }
            }
            catch { }       
        }

        public void LoadRandomFilesData()
        {
            try
            {
                lvRandomFiles.Items.Clear();
                lvRandomFiles.SmallImageList = lvRandomFiles.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                dt = settingsObj.GetRandomFilesData();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        lvRandomFiles.Items.Add(
                          new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["created"].ToString(),
                            row["typeofdocuments"].ToString(),
                            row["receivedby"].ToString(),
                            row["remarks"].ToString(),
                            row["status"].ToString() }
                          ));
                        lvRandomFiles.TopItem = lvRandomFiles.Items.Cast<ListViewItem>().LastOrDefault();
                        //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                    }
                }
            }
            catch { }         
        }

        private void lvForm137_DoubleClick(object sender, EventArgs e)
        {
            if (lvForm137.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvForm137.SelectedItems[0];
                //MessageBox.Show(selected.Text);
                frmForm137 frmForm137 = new frmForm137(Convert.ToInt32(selected.Text));
                //frmForm137.txtFname.ReadOnly = true;
                //frmForm137.txtMname.ReadOnly = true;
                //frmForm137.txtLname.ReadOnly = true;
                //frmForm137.cmbGradeLevel.Enabled = false;
                //frmForm137.rtSchool.ReadOnly = true;
                frmForm137.btnSubmit.Text = "Update";
                frmForm137.btnDel.Visible = true;
                frmForm137.cmbStatus.Focus();
                frmForm137.lblStatus.ForeColor = Color.Red;
                frmForm137.lblRemarks.ForeColor = Color.Red;
                frmForm137.ShowDialog();
            }
        }

        private void lvRandomFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvRandomFiles.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvRandomFiles.SelectedItems[0];
                //MessageBox.Show(selected.Text);
                frmRandomFiles frmRandomFiles = new frmRandomFiles(Convert.ToInt32(selected.Text));
                //frmRandomFiles.txtReceivedFrom.ReadOnly = true;
                //frmRandomFiles.txtTypeOfDocs.ReadOnly = true;
                //frmRandomFiles.rtRemarks.ReadOnly = true;
                frmRandomFiles.btnSubmit.Text = "Update";
                frmRandomFiles.btnDel.Visible = true;
                frmRandomFiles.cmbStatus.Focus();
                frmRandomFiles.lblStatus.ForeColor = Color.Red;
                frmRandomFiles.ShowDialog();
            }
        }

        private void txtFiltername_TextChanged(object sender, EventArgs e)
        {
            if (cmbStoreData.SelectedValue.Equals("randomfile_tbl"))
            {
                try
                {
                    lvRandomFiles.Items.Clear();
                    lvRandomFiles.SmallImageList = lvRandomFiles.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                    dt = settingsObj.GetRandomFileDataAndFilter("%" + txtFiltername.Text.ToString() + "%");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lvRandomFiles.Items.Add(
                              new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["created"].ToString(),
                            row["typeofdocuments"].ToString(),
                            row["receivedby"].ToString(),
                            row["remarks"].ToString(),
                            row["status"].ToString() }
                              ));
                            lvRandomFiles.TopItem = lvRandomFiles.Items.Cast<ListViewItem>().LastOrDefault();
                            //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                        }
                    }
                    //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                }
                catch { }
            }
            else if (cmbStoreData.SelectedValue.Equals("form137file_tbl"))
            {
                try
                {
                    lvForm137.Items.Clear();
                    lvForm137.SmallImageList = lvForm137.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                    dt = settingsObj.GetForm137DataAndFilter("%" + txtFiltername.Text.ToString() + "%");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lvForm137.Items.Add(
                              new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["created"].ToString(),
                            row["name"].ToString(),
                            row["gradelevel"].ToString(),
                            row["previous_school"].ToString(),
                            row["status"].ToString() }
                              ));
                            lvForm137.TopItem = lvForm137.Items.Cast<ListViewItem>().LastOrDefault();
                            //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                        }
                    }
                    //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                }
                catch { }
            }
            
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (cmbStoreData.SelectedValue.Equals("randomfile_tbl"))
            {
                try
                {
                    lvRandomFiles.Items.Clear();
                    lvRandomFiles.SmallImageList = lvRandomFiles.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                    dt = settingsObj.GetRandomFileDataBasedOnDate(dtpFromDate.Text.ToString(), dtpToDate.Text.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lvRandomFiles.Items.Add(
                              new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["created"].ToString(),
                            row["typeofdocuments"].ToString(),
                            row["receivedby"].ToString(),
                            row["remarks"].ToString(),
                            row["status"].ToString() }
                              ));
                            lvRandomFiles.TopItem = lvRandomFiles.Items.Cast<ListViewItem>().LastOrDefault();
                            //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                        }
                    }
                    //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                }
                catch { }
            }
            else if (cmbStoreData.SelectedValue.Equals("form137file_tbl"))
            {
                try
                {
                    lvForm137.Items.Clear();
                    lvForm137.SmallImageList = lvForm137.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                    dt = settingsObj.GetForm137DataBasedOnDate(dtpFromDate.Text.ToString(), dtpToDate.Text.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lvForm137.Items.Add(
                              new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["created"].ToString(),
                            row["name"].ToString(),
                            row["gradelevel"].ToString(),
                            row["previous_school"].ToString(),
                            row["status"].ToString() }
                              ));
                            lvForm137.TopItem = lvForm137.Items.Cast<ListViewItem>().LastOrDefault();
                            //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                        }
                    }
                    //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                }
                catch { }
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (cmbStoreData.SelectedValue.Equals("randomfile_tbl"))
            {
                try
                {
                    lvRandomFiles.Items.Clear();
                    lvRandomFiles.SmallImageList = lvRandomFiles.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                    dt = settingsObj.GetRandomFileDataBasedOnDate(dtpFromDate.Text.ToString(), dtpToDate.Text.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lvRandomFiles.Items.Add(
                              new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["created"].ToString(),
                            row["typeofdocuments"].ToString(),
                            row["receivedby"].ToString(),
                            row["remarks"].ToString(),
                            row["status"].ToString() }
                              ));
                            lvRandomFiles.TopItem = lvRandomFiles.Items.Cast<ListViewItem>().LastOrDefault();
                            //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                        }
                    }
                    //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                }
                catch { }
            }
            else if (cmbStoreData.SelectedValue.Equals("form137file_tbl"))
            {
                try
                {
                    lvForm137.Items.Clear();
                    lvForm137.SmallImageList = lvForm137.View == System.Windows.Forms.View.SmallIcon ? imgList : null;
                    dt = settingsObj.GetForm137DataBasedOnDate(dtpFromDate.Text.ToString(), dtpToDate.Text.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            lvForm137.Items.Add(
                              new ListViewItem(new String[] {
                            row["id"].ToString(),
                            row["created"].ToString(),
                            row["name"].ToString(),
                            row["gradelevel"].ToString(),
                            row["previous_school"].ToString(),
                            row["status"].ToString() }
                              ));
                            lvForm137.TopItem = lvForm137.Items.Cast<ListViewItem>().LastOrDefault();
                            //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                        }
                    }
                    //lblCountLogs.Text = "Total of queue history: " + lvHistory.Items.Count.ToString();
                }
                catch { }
            }
        }

        private void bttnExportToExcel_Click(object sender, EventArgs e)
        {
            if (cmbStoreData.SelectedValue.Equals("randomfile_tbl"))
            {
                using (SaveFileDialog saveFileDiag = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                {
                    if (saveFileDiag.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook excelWorkBooks = excelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                        Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.ActiveSheet;


                        //excelApp.Cells.HorizontalAlignment = HorizontalAlignment.Center;
                        excelApp.Visible = false;
                        excelSheet.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        for (int x = 1; x <= lvRandomFiles.Columns.Count; x++)
                        {
                            var newWidth = Math.Min(50, lvRandomFiles.Columns[x - 1].Width / 4);
                            excelSheet.Columns[x].ColumnWidth = newWidth;
                            excelSheet.Cells[1, x] = lvRandomFiles.Columns[x - 1].Text;
                            excelSheet.Cells[1, x].Font.Bold = true;
                        }
                        int i = 2; // We're going to insert the data starts on Row 2 because we already insert Columns Text in Row 1
                        foreach (ListViewItem item in lvRandomFiles.Items)
                        {
                            for (int x = 1; x <= item.SubItems.Count; x++)
                            {
                                excelSheet.Cells[i, x] = item.SubItems[x - 1].Text;
                            }
                            i++;
                        }
                        excelWorkBooks.SaveAs(saveFileDiag.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                        excelApp.Quit();
                        if (File.Exists(saveFileDiag.FileName)) MessageBox.Show("Random Files filtered has been successfuly exported to excel.", "Export as Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("An error occured during exportation as Excel, Please try again.", "Export as Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else if (cmbStoreData.SelectedValue.Equals("form137file_tbl"))
            {
                using (SaveFileDialog saveFileDiag = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                {
                    if (saveFileDiag.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook excelWorkBooks = excelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                        Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.ActiveSheet;


                        //excelApp.Cells.HorizontalAlignment = HorizontalAlignment.Center;
                        excelApp.Visible = false;
                        excelSheet.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        for (int x = 1; x <= lvForm137.Columns.Count; x++)
                        {
                            var newWidth = Math.Min(50, lvForm137.Columns[x - 1].Width / 4);
                            excelSheet.Columns[x].ColumnWidth = newWidth;
                            excelSheet.Cells[1, x] = lvForm137.Columns[x - 1].Text;
                            excelSheet.Cells[1, x].Font.Bold = true;
                        }
                        int i = 2; // We're going to insert the data starts on Row 2 because we already insert Columns Text in Row 1
                        foreach (ListViewItem item in lvForm137.Items)
                        {
                            for (int x = 1; x <= item.SubItems.Count; x++)
                            {
                                excelSheet.Cells[i, x] = item.SubItems[x - 1].Text;
                            }
                            i++;
                        }
                        excelWorkBooks.SaveAs(saveFileDiag.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                        excelApp.Quit();
                        if (File.Exists(saveFileDiag.FileName)) MessageBox.Show("Form 137/SF10 has been successfuly exported to excel.", "Export as Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("An error occured during exportation as Excel, Please try again.", "Export as Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbStoreData.SelectedValue.Equals("randomfile_tbl"))
            {
                LoadRandomFilesData();
                lvRandomFiles.Visible = true;
                lvForm137.Visible = false;
                txtFiltername.Text = "";
            }
            else if (cmbStoreData.SelectedValue.Equals("form137file_tbl"))
            {
                LoadForm137Data();
                lvForm137.Visible = true;
                lvRandomFiles.Visible = false;
                txtFiltername.Text = "";
            }
        }
    }
}
