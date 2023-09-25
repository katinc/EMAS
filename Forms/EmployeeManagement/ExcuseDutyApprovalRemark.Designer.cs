namespace eMAS.Forms.EmployeeManagement
{
    partial class ExcuseDutyApprovalRemark
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdditionalComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkApprove = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(-1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 38);
            this.panel3.TabIndex = 119;
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
            this.label1.Text = "Excused Duty Approval Remark";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datePickerStartDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAdditionalComment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkApprove);
            this.groupBox1.Location = new System.Drawing.Point(6, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(421, 148);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remarks";
            // 
            // datePickerStartDate
            // 
            this.datePickerStartDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerStartDate.Location = new System.Drawing.Point(334, 23);
            this.datePickerStartDate.Name = "datePickerStartDate";
            this.datePickerStartDate.ShowCheckBox = true;
            this.datePickerStartDate.Size = new System.Drawing.Size(83, 20);
            this.datePickerStartDate.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 102;
            this.label5.Text = "Approval Date:";
            // 
            // txtAdditionalComment
            // 
            this.txtAdditionalComment.Location = new System.Drawing.Point(116, 51);
            this.txtAdditionalComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdditionalComment.Multiline = true;
            this.txtAdditionalComment.Name = "txtAdditionalComment";
            this.txtAdditionalComment.Size = new System.Drawing.Size(302, 93);
            this.txtAdditionalComment.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Additional Comments";
            // 
            // chkApprove
            // 
            this.chkApprove.AutoSize = true;
            this.chkApprove.Location = new System.Drawing.Point(116, 23);
            this.chkApprove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkApprove.Name = "chkApprove";
            this.chkApprove.Size = new System.Drawing.Size(66, 17);
            this.chkApprove.TabIndex = 0;
            this.chkApprove.Text = "Approve";
            this.chkApprove.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(122, 193);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 24);
            this.btnClear.TabIndex = 123;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(208, 193);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(92, 24);
            this.btnApprove.TabIndex = 122;
            this.btnApprove.Text = "&Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(351, 193);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 24);
            this.btnClose.TabIndex = 121;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ExcuseDutyApprovalRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 227);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ExcuseDutyApprovalRemark";
            this.Text = "Excuse Duty Approval Remark";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAdditionalComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkApprove;
        private System.Windows.Forms.DateTimePicker datePickerStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnClose;
    }
}