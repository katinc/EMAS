namespace eMAS.Forms.EmployeeManagement
{
    partial class ExternalTrainingCEOApproval
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpApprovalDate = new System.Windows.Forms.DateTimePicker();
            this.txtAdditionalComments = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtCEOID = new System.Windows.Forms.TextBox();
            this.chkApprove = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(415, 38);
            this.panel3.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "External Training CEO Approval";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(2, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 33);
            this.panel1.TabIndex = 119;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(276, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(348, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpApprovalDate);
            this.groupBox1.Controls.Add(this.txtAdditionalComments);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStaffName);
            this.groupBox1.Controls.Add(this.txtCEOID);
            this.groupBox1.Controls.Add(this.chkApprove);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(398, 247);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Approval Date:";
            // 
            // dtpApprovalDate
            // 
            this.dtpApprovalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpApprovalDate.Location = new System.Drawing.Point(122, 158);
            this.dtpApprovalDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpApprovalDate.Name = "dtpApprovalDate";
            this.dtpApprovalDate.Size = new System.Drawing.Size(151, 20);
            this.dtpApprovalDate.TabIndex = 7;
            // 
            // txtAdditionalComments
            // 
            this.txtAdditionalComments.Location = new System.Drawing.Point(122, 85);
            this.txtAdditionalComments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdditionalComments.Multiline = true;
            this.txtAdditionalComments.Name = "txtAdditionalComments";
            this.txtAdditionalComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAdditionalComments.Size = new System.Drawing.Size(252, 68);
            this.txtAdditionalComments.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Additional Comments";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(122, 41);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(252, 20);
            this.txtStaffName.TabIndex = 4;
            // 
            // txtCEOID
            // 
            this.txtCEOID.Location = new System.Drawing.Point(122, 18);
            this.txtCEOID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCEOID.Name = "txtCEOID";
            this.txtCEOID.Size = new System.Drawing.Size(252, 20);
            this.txtCEOID.TabIndex = 3;
            this.txtCEOID.TextChanged += new System.EventHandler(this.txtCEOID_TextChanged);
            // 
            // chkApprove
            // 
            this.chkApprove.AutoSize = true;
            this.chkApprove.Location = new System.Drawing.Point(122, 63);
            this.chkApprove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkApprove.Name = "chkApprove";
            this.chkApprove.Size = new System.Drawing.Size(66, 17);
            this.chkApprove.TabIndex = 2;
            this.chkApprove.Text = "Approve";
            this.chkApprove.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "CEO Staff Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CEO Staff ID:";
            // 
            // ExternalTrainingCEOApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 332);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ExternalTrainingCEOApproval";
            this.Text = "External Training CEO Approval";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpApprovalDate;
        private System.Windows.Forms.TextBox txtAdditionalComments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtCEOID;
        private System.Windows.Forms.CheckBox chkApprove;
    }
}