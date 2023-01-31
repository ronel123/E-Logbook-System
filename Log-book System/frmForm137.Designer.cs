namespace Log_book_System
{
    partial class frmForm137
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForm137));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtSchool = new System.Windows.Forms.TextBox();
            this.rtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbGradeLevel = new System.Windows.Forms.ComboBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtSchool);
            this.groupBox1.Controls.Add(this.rtRemarks);
            this.groupBox1.Controls.Add(this.lblRemarks);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.cmbGradeLevel);
            this.groupBox1.Controls.Add(this.txtLname);
            this.groupBox1.Controls.Add(this.txtMname);
            this.groupBox1.Controls.Add(this.txtFname);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Form 137/SF10";
            // 
            // rtSchool
            // 
            this.rtSchool.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.rtSchool.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.rtSchool.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.rtSchool.Location = new System.Drawing.Point(39, 186);
            this.rtSchool.Multiline = true;
            this.rtSchool.Name = "rtSchool";
            this.rtSchool.Size = new System.Drawing.Size(317, 86);
            this.rtSchool.TabIndex = 6;
            this.rtSchool.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtSchool_KeyPress_1);
            // 
            // rtRemarks
            // 
            this.rtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.rtRemarks.Location = new System.Drawing.Point(363, 132);
            this.rtRemarks.Multiline = true;
            this.rtRemarks.Name = "rtRemarks";
            this.rtRemarks.Size = new System.Drawing.Size(168, 53);
            this.rtRemarks.TabIndex = 58;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(359, 107);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(84, 20);
            this.lblRemarks.TabIndex = 57;
            this.lblRemarks.Text = "Remarks: *";
            this.lblRemarks.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(378, 242);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(68, 30);
            this.btnDel.TabIndex = 8;
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
            "Incoming",
            "Outgoing"});
            this.cmbStatus.Location = new System.Drawing.Point(218, 130);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(138, 25);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
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
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbGradeLevel
            // 
            this.cmbGradeLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGradeLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGradeLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbGradeLevel.FormattingEnabled = true;
            this.cmbGradeLevel.Items.AddRange(new object[] {
            "Kinder",
            "Grade 1",
            "Grade 2",
            "Grade 3",
            "Grade 4",
            "Grade 5",
            "Grade 6",
            "Grade 7",
            "Grade 8",
            "Grade 9",
            "Grade 10",
            "Grade 11",
            "Grade 12"});
            this.cmbGradeLevel.Location = new System.Drawing.Point(39, 130);
            this.cmbGradeLevel.Name = "cmbGradeLevel";
            this.cmbGradeLevel.Size = new System.Drawing.Size(169, 25);
            this.cmbGradeLevel.TabIndex = 4;
            // 
            // txtLname
            // 
            this.txtLname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLname.Location = new System.Drawing.Point(39, 69);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(169, 23);
            this.txtLname.TabIndex = 1;
            // 
            // txtMname
            // 
            this.txtMname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMname.Location = new System.Drawing.Point(393, 69);
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(138, 23);
            this.txtMname.TabIndex = 3;
            // 
            // txtFname
            // 
            this.txtFname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFname.Location = new System.Drawing.Point(214, 69);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(169, 23);
            this.txtFname.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(214, 107);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status: *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Previous School *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Grade Level: *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lastname: *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(389, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Middlename:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firstname: *";
            // 
            // frmForm137
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 302);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForm137";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Logbook System - Powered by: ITech Digital Solution";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmForm137_FormClosing);
            this.Load += new System.EventHandler(this.frmForm137_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtLname;
        public System.Windows.Forms.TextBox txtMname;
        public System.Windows.Forms.TextBox txtFname;
        public System.Windows.Forms.Button btnSubmit;
        public System.Windows.Forms.Button btnDel;
        public System.Windows.Forms.ComboBox cmbStatus;
        public System.Windows.Forms.Label lblRemarks;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.ComboBox cmbGradeLevel;
        public System.Windows.Forms.TextBox rtSchool;
        public System.Windows.Forms.TextBox rtRemarks;
    }
}