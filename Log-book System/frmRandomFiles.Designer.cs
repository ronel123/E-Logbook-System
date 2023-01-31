namespace Log_book_System
{
    partial class frmRandomFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRandomFiles));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtReceivedFrom = new System.Windows.Forms.TextBox();
            this.txtTypeOfDocs = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtRemarks = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtRemarks);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.txtReceivedFrom);
            this.groupBox1.Controls.Add(this.txtTypeOfDocs);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 278);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Any Documents";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(377, 242);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(68, 30);
            this.btnDel.TabIndex = 57;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Completed",
            "Pending"});
            this.cmbStatus.Location = new System.Drawing.Point(39, 242);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(138, 25);
            this.cmbStatus.TabIndex = 55;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.RosyBrown;
            this.label22.Location = new System.Drawing.Point(425, 188);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(123, 51);
            this.label22.TabIndex = 54;
            this.label22.Text = "Legends:\r\n• [*] - required\r\n• [ ] - NOT  required";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(449, 242);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(95, 30);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtReceivedFrom
            // 
            this.txtReceivedFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceivedFrom.Location = new System.Drawing.Point(363, 68);
            this.txtReceivedFrom.Name = "txtReceivedFrom";
            this.txtReceivedFrom.Size = new System.Drawing.Size(169, 23);
            this.txtReceivedFrom.TabIndex = 2;
            // 
            // txtTypeOfDocs
            // 
            this.txtTypeOfDocs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypeOfDocs.Location = new System.Drawing.Point(39, 68);
            this.txtTypeOfDocs.Name = "txtTypeOfDocs";
            this.txtTypeOfDocs.Size = new System.Drawing.Size(317, 23);
            this.txtTypeOfDocs.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(35, 219);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status: *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Remarks *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name of Receiver: *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type Of Document: *";
            // 
            // rtRemarks
            // 
            this.rtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.rtRemarks.Location = new System.Drawing.Point(39, 130);
            this.rtRemarks.Multiline = true;
            this.rtRemarks.Name = "rtRemarks";
            this.rtRemarks.Size = new System.Drawing.Size(317, 86);
            this.rtRemarks.TabIndex = 3;
            this.rtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtRemarks_KeyPress_1);
            // 
            // frmRandomFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 302);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRandomFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Logbook System - Powered by: ITech Digital Solution";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRandomFiles_FormClosing);
            this.Load += new System.EventHandler(this.frmRandomFiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnDel;
        public System.Windows.Forms.ComboBox cmbStatus;
        public System.Windows.Forms.Button btnSubmit;
        public System.Windows.Forms.TextBox txtReceivedFrom;
        public System.Windows.Forms.TextBox txtTypeOfDocs;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.TextBox rtRemarks;
    }
}