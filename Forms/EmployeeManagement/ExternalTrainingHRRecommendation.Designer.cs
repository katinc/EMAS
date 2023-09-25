namespace eMAS.Forms.EmployeeManagement
{
    partial class ExternalTrainingHRRecommendation
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
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAssessmentDate = new System.Windows.Forms.DateTimePicker();
            this.txtAdditionalComments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkRecommend = new System.Windows.Forms.CheckBox();
            this.cmbPreliminaryDecision = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHRName = new System.Windows.Forms.TextBox();
            this.txtHRID = new System.Windows.Forms.TextBox();
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
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(504, 38);
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
            this.label1.Size = new System.Drawing.Size(235, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "External Training Recommendation View";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 42);
            this.panel1.TabIndex = 119;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(238, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(315, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpAssessmentDate);
            this.groupBox1.Controls.Add(this.txtAdditionalComments);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkRecommend);
            this.groupBox1.Controls.Add(this.cmbPreliminaryDecision);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHRName);
            this.groupBox1.Controls.Add(this.txtHRID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(379, 232);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Assessment Date:";
            // 
            // dtpAssessmentDate
            // 
            this.dtpAssessmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssessmentDate.Location = new System.Drawing.Point(115, 156);
            this.dtpAssessmentDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpAssessmentDate.Name = "dtpAssessmentDate";
            this.dtpAssessmentDate.Size = new System.Drawing.Size(114, 20);
            this.dtpAssessmentDate.TabIndex = 9;
            // 
            // txtAdditionalComments
            // 
            this.txtAdditionalComments.Location = new System.Drawing.Point(115, 93);
            this.txtAdditionalComments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdditionalComments.Multiline = true;
            this.txtAdditionalComments.Name = "txtAdditionalComments";
            this.txtAdditionalComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAdditionalComments.Size = new System.Drawing.Size(248, 58);
            this.txtAdditionalComments.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Additional Comments:";
            // 
            // chkRecommend
            // 
            this.chkRecommend.AutoSize = true;
            this.chkRecommend.Checked = true;
            this.chkRecommend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecommend.Location = new System.Drawing.Point(280, 63);
            this.chkRecommend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkRecommend.Name = "chkRecommend";
            this.chkRecommend.Size = new System.Drawing.Size(86, 17);
            this.chkRecommend.TabIndex = 6;
            this.chkRecommend.Text = "Recommend";
            this.chkRecommend.UseVisualStyleBackColor = true;
            // 
            // cmbPreliminaryDecision
            // 
            this.cmbPreliminaryDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreliminaryDecision.FormattingEnabled = true;
            this.cmbPreliminaryDecision.Items.AddRange(new object[] {
            "Suitable",
            "Not Suitable",
            "Not Decided"});
            this.cmbPreliminaryDecision.Location = new System.Drawing.Point(115, 64);
            this.cmbPreliminaryDecision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPreliminaryDecision.Name = "cmbPreliminaryDecision";
            this.cmbPreliminaryDecision.Size = new System.Drawing.Size(114, 21);
            this.cmbPreliminaryDecision.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Preliminary Decision:";
            // 
            // txtHRName
            // 
            this.txtHRName.Location = new System.Drawing.Point(115, 41);
            this.txtHRName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHRName.Name = "txtHRName";
            this.txtHRName.ReadOnly = true;
            this.txtHRName.Size = new System.Drawing.Size(248, 20);
            this.txtHRName.TabIndex = 3;
            // 
            // txtHRID
            // 
            this.txtHRID.Location = new System.Drawing.Point(115, 18);
            this.txtHRID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHRID.Name = "txtHRID";
            this.txtHRID.Size = new System.Drawing.Size(248, 20);
            this.txtHRID.TabIndex = 2;
            this.txtHRID.TextChanged += new System.EventHandler(this.txtHRID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "HR Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "HR Staff ID:";
            // 
            // ExternalTrainingHRRecommendation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 324);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ExternalTrainingHRRecommendation";
            this.Text = "External Training HR Recommendation";
            this.Load += new System.EventHandler(this.ExternalTrainingHRRecommendation_Load);
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
        private System.Windows.Forms.ComboBox cmbPreliminaryDecision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHRName;
        private System.Windows.Forms.TextBox txtHRID;
        private System.Windows.Forms.CheckBox chkRecommend;
        private System.Windows.Forms.TextBox txtAdditionalComments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAssessmentDate;
    }
}