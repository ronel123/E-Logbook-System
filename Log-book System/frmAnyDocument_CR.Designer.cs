namespace Log_book_System
{
    partial class frmAnyDocument_CR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnyDocument_CR));
            this.crvAnyDocument = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport_AnyDocument1 = new Log_book_System.CrystalReport_AnyDocument();
            this.SuspendLayout();
            // 
            // crvAnyDocument
            // 
            this.crvAnyDocument.ActiveViewIndex = 0;
            this.crvAnyDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvAnyDocument.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvAnyDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvAnyDocument.Location = new System.Drawing.Point(0, 0);
            this.crvAnyDocument.Name = "crvAnyDocument";
            this.crvAnyDocument.ReportSource = this.CrystalReport_AnyDocument1;
            this.crvAnyDocument.Size = new System.Drawing.Size(927, 600);
            this.crvAnyDocument.TabIndex = 0;
            this.crvAnyDocument.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmAnyDocument_CR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 600);
            this.Controls.Add(this.crvAnyDocument);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(943, 639);
            this.Name = "frmAnyDocument_CR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Logbook System - Powered by: ITech Digital Solution";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAnyDocument_CR_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvAnyDocument;
        private CrystalReport_AnyDocument CrystalReport_AnyDocument1;
    }
}