namespace eMAS.Forms
{
    partial class ExcuseDutyRecommendationRemarks
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
            this.chkRecommended = new System.Windows.Forms.CheckBox();
            this.datePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStaffID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRecommend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(731, 46);
            this.panel3.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recommendation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRecommended);
            this.groupBox1.Controls.Add(this.datePickerStartDate);
            this.groupBox1.Controls.Add(this.txtStaffName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStaffID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 202);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remarks";
            // 
            // chkRecommended
            // 
            this.chkRecommended.AutoSize = true;
            this.chkRecommended.Location = new System.Drawing.Point(612, 19);
            this.chkRecommended.Name = "chkRecommended";
            this.chkRecommended.Size = new System.Drawing.Size(109, 21);
            this.chkRecommended.TabIndex = 104;
            this.chkRecommended.Text = "Recommend";
            this.chkRecommended.UseVisualStyleBackColor = true;
            // 
            // datePickerStartDate
            // 
            this.datePickerStartDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerStartDate.Location = new System.Drawing.Point(612, 53);
            this.datePickerStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerStartDate.Name = "datePickerStartDate";
            this.datePickerStartDate.ShowCheckBox = true;
            this.datePickerStartDate.Size = new System.Drawing.Size(109, 22);
            this.datePickerStartDate.TabIndex = 101;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(164, 55);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(369, 22);
            this.txtStaffName.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 17);
            this.label6.TabIndex = 99;
            this.label6.Text = "Supervisor\'s Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(563, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 98;
            this.label5.Text = "Date:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(164, 86);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(557, 104);
            this.txtComment.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 17);
            this.label4.TabIndex = 96;
            this.label4.Text = "Supervisor\'s Comment:";
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(164, 18);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.ReadOnly = true;
            this.txtStaffID.Size = new System.Drawing.Size(182, 22);
            this.txtStaffID.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 94;
            this.label3.Text = "Supervisor\'s ID:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(636, 262);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 30);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRecommend
            // 
            this.btnRecommend.Location = new System.Drawing.Point(493, 262);
            this.btnRecommend.Name = "btnRecommend";
            this.btnRecommend.Size = new System.Drawing.Size(122, 30);
            this.btnRecommend.TabIndex = 44;
            this.btnRecommend.Text = "&Recommend";
            this.btnRecommend.UseVisualStyleBackColor = true;
            this.btnRecommend.Click += new System.EventHandler(this.btnRecommend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(168, 262);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 30);
            this.btnClear.TabIndex = 45;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ExcuseDutyRecommendationRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 299);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRecommend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ExcuseDutyRecommendationRemarks";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recommendation Remarks";
            this.Load += new System.EventHandler(this.ExcuseDutyRecommendationRemarks_Load);
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
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStaffID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker datePickerStartDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRecommend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkRecommended;
    }
}