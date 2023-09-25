namespace eMAS.Forms.EmployeeManagement
{
    partial class ExternalTrainingJustification
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
            this.chkJustify = new System.Windows.Forms.CheckBox();
            this.dtpJustificationDate = new System.Windows.Forms.DateTimePicker();
            this.txtJustification = new System.Windows.Forms.TextBox();
            this.txtHODName = new System.Windows.Forms.TextBox();
            this.txtHODStaffID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.panel3.Location = new System.Drawing.Point(1, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(387, 38);
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
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "External Training Justification";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 34);
            this.panel1.TabIndex = 119;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(232, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(322, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkJustify);
            this.groupBox1.Controls.Add(this.dtpJustificationDate);
            this.groupBox1.Controls.Add(this.txtJustification);
            this.groupBox1.Controls.Add(this.txtHODName);
            this.groupBox1.Controls.Add(this.txtHODStaffID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(370, 210);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            // 
            // chkJustify
            // 
            this.chkJustify.AutoSize = true;
            this.chkJustify.Checked = true;
            this.chkJustify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJustify.Location = new System.Drawing.Point(306, 154);
            this.chkJustify.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkJustify.Name = "chkJustify";
            this.chkJustify.Size = new System.Drawing.Size(55, 17);
            this.chkJustify.TabIndex = 8;
            this.chkJustify.Text = "Justify";
            this.chkJustify.UseVisualStyleBackColor = true;
            // 
            // dtpJustificationDate
            // 
            this.dtpJustificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJustificationDate.Location = new System.Drawing.Point(103, 154);
            this.dtpJustificationDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpJustificationDate.Name = "dtpJustificationDate";
            this.dtpJustificationDate.Size = new System.Drawing.Size(163, 20);
            this.dtpJustificationDate.TabIndex = 7;
            // 
            // txtJustification
            // 
            this.txtJustification.Location = new System.Drawing.Point(103, 67);
            this.txtJustification.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtJustification.Multiline = true;
            this.txtJustification.Name = "txtJustification";
            this.txtJustification.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJustification.Size = new System.Drawing.Size(257, 82);
            this.txtJustification.TabIndex = 6;
            // 
            // txtHODName
            // 
            this.txtHODName.Location = new System.Drawing.Point(103, 41);
            this.txtHODName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHODName.Name = "txtHODName";
            this.txtHODName.ReadOnly = true;
            this.txtHODName.Size = new System.Drawing.Size(257, 20);
            this.txtHODName.TabIndex = 5;
            // 
            // txtHODStaffID
            // 
            this.txtHODStaffID.Location = new System.Drawing.Point(103, 18);
            this.txtHODStaffID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHODStaffID.Name = "txtHODStaffID";
            this.txtHODStaffID.ReadOnly = true;
            this.txtHODStaffID.Size = new System.Drawing.Size(257, 20);
            this.txtHODStaffID.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Justification Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Justification:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "HOD Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "HOD Staff ID:";
            // 
            // ExternalTrainingJustification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ExternalTrainingJustification";
            this.Text = "External Training Justification";
            this.Load += new System.EventHandler(this.ExternalTrainingJustification_Load);
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
        private System.Windows.Forms.DateTimePicker dtpJustificationDate;
        private System.Windows.Forms.TextBox txtJustification;
        private System.Windows.Forms.TextBox txtHODName;
        private System.Windows.Forms.TextBox txtHODStaffID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkJustify;
    }
}