namespace Log_book_System
{
    partial class frmForm137_CR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForm137_CR));
            this.crvForm137 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport_Form1371 = new Log_book_System.CrystalReport_Form137();
            this.SuspendLayout();
            // 
            // crvForm137
            // 
            this.crvForm137.ActiveViewIndex = 0;
            this.crvForm137.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvForm137.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvForm137.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvForm137.Location = new System.Drawing.Point(0, 0);
            this.crvForm137.Name = "crvForm137";
            this.crvForm137.ReportSource = this.CrystalReport_Form1371;
            this.crvForm137.Size = new System.Drawing.Size(927, 600);
            this.crvForm137.TabIndex = 0;
            this.crvForm137.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmForm137_CR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 600);
            this.Controls.Add(this.crvForm137);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(943, 639);
            this.Name = "frmForm137_CR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrystalReport_AnyDocument1 [Log_book_System.CrystalReport_AnyDocument]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmForm137_CR_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalReport_Form137 CrystalReport_Form1371;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvForm137;
    }
}