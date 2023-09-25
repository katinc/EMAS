namespace eMAS.Forms.EmployeeManagement
{
    partial class ExcuseDutyResumptionDetailsForm
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
            this.chkReturned = new System.Windows.Forms.CheckBox();
            this.txtResumptionReason = new System.Windows.Forms.TextBox();
            this.datePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(1, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(444, 38);
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
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excused Duty Resumption";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkReturned);
            this.groupBox1.Controls.Add(this.txtResumptionReason);
            this.groupBox1.Controls.Add(this.datePickerEndDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(401, 138);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            // 
            // chkReturned
            // 
            this.chkReturned.AutoSize = true;
            this.chkReturned.Checked = true;
            this.chkReturned.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReturned.Location = new System.Drawing.Point(330, 26);
            this.chkReturned.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkReturned.Name = "chkReturned";
            this.chkReturned.Size = new System.Drawing.Size(65, 17);
            this.chkReturned.TabIndex = 107;
            this.chkReturned.Text = "Resume";
            this.chkReturned.UseVisualStyleBackColor = true;
            // 
            // txtResumptionReason
            // 
            this.txtResumptionReason.Location = new System.Drawing.Point(130, 52);
            this.txtResumptionReason.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtResumptionReason.Multiline = true;
            this.txtResumptionReason.Name = "txtResumptionReason";
            this.txtResumptionReason.Size = new System.Drawing.Size(267, 82);
            this.txtResumptionReason.TabIndex = 105;
            // 
            // datePickerEndDate
            // 
            this.datePickerEndDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEndDate.Location = new System.Drawing.Point(130, 25);
            this.datePickerEndDate.Name = "datePickerEndDate";
            this.datePickerEndDate.ShowCheckBox = true;
            this.datePickerEndDate.Size = new System.Drawing.Size(116, 20);
            this.datePickerEndDate.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Resumption Reason:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Resumption Date:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(356, 189);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 23);
            this.btnClose.TabIndex = 121;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(140, 189);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(116, 23);
            this.btnResume.TabIndex = 122;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // ExcuseDutyResumptionDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 216);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ExcuseDutyResumptionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resumption Details";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkReturned;
        private System.Windows.Forms.TextBox txtResumptionReason;
        private System.Windows.Forms.DateTimePicker datePickerEndDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnResume;
    }
}