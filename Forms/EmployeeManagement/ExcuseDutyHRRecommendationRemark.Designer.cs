namespace eMAS.Forms.EmployeeManagement
{
    partial class ExcuseDutyHRRecommendationRemark
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.chkRecommend = new System.Windows.Forms.CheckBox();
            this.chkEligible = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRecommend = new System.Windows.Forms.Button();
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
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 38);
            this.panel3.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HR Recommendation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datePickerStartDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.chkRecommend);
            this.groupBox1.Controls.Add(this.chkEligible);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(526, 173);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remarks";
            // 
            // datePickerStartDate
            // 
            this.datePickerStartDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerStartDate.Location = new System.Drawing.Point(440, 16);
            this.datePickerStartDate.Name = "datePickerStartDate";
            this.datePickerStartDate.ShowCheckBox = true;
            this.datePickerStartDate.Size = new System.Drawing.Size(82, 20);
            this.datePickerStartDate.TabIndex = 105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 104;
            this.label5.Text = "Assessment Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Additional Comment:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(116, 48);
            this.txtComment.Margin = new System.Windows.Forms.Padding(2);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(407, 121);
            this.txtComment.TabIndex = 98;
            // 
            // chkRecommend
            // 
            this.chkRecommend.AutoSize = true;
            this.chkRecommend.Checked = true;
            this.chkRecommend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecommend.Location = new System.Drawing.Point(203, 18);
            this.chkRecommend.Margin = new System.Windows.Forms.Padding(2);
            this.chkRecommend.Name = "chkRecommend";
            this.chkRecommend.Size = new System.Drawing.Size(86, 17);
            this.chkRecommend.TabIndex = 3;
            this.chkRecommend.Text = "Recommend";
            this.chkRecommend.UseVisualStyleBackColor = true;
            this.chkRecommend.CheckedChanged += new System.EventHandler(this.chkRecommend_CheckedChanged);
            // 
            // chkEligible
            // 
            this.chkEligible.AutoSize = true;
            this.chkEligible.Checked = true;
            this.chkEligible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEligible.Location = new System.Drawing.Point(116, 18);
            this.chkEligible.Margin = new System.Windows.Forms.Padding(2);
            this.chkEligible.Name = "chkEligible";
            this.chkEligible.Size = new System.Drawing.Size(59, 17);
            this.chkEligible.TabIndex = 1;
            this.chkEligible.Text = "Eligible";
            this.chkEligible.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Preliminary Decision:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(119, 216);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 24);
            this.btnClear.TabIndex = 48;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRecommend
            // 
            this.btnRecommend.Location = new System.Drawing.Point(342, 216);
            this.btnRecommend.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecommend.Name = "btnRecommend";
            this.btnRecommend.Size = new System.Drawing.Size(92, 24);
            this.btnRecommend.TabIndex = 47;
            this.btnRecommend.Text = "&Recommend";
            this.btnRecommend.UseVisualStyleBackColor = true;
            this.btnRecommend.Click += new System.EventHandler(this.btnRecommend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(459, 216);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 24);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ExcuseDutyHRRecommendationRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 249);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRecommend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ExcuseDutyHRRecommendationRemark";
            this.Text = "Excuse Duty HR Recommendation Remark";
            this.Load += new System.EventHandler(this.ExcuseDutyHRRecommendationRemark_Load);
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
        private System.Windows.Forms.CheckBox chkRecommend;
        private System.Windows.Forms.CheckBox chkEligible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.DateTimePicker datePickerStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRecommend;
        private System.Windows.Forms.Button btnClose;
    }
}