namespace eMAS.Forms.SMS
{
    partial class SMSFormView
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
            this.label7 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.datePickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datePickerToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "To Date:";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(77, 69);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(132, 21);
            this.cboType.TabIndex = 46;
            this.cboType.DropDown += new System.EventHandler(this.cboType_DropDown);
            // 
            // datePickerFromDate
            // 
            this.datePickerFromDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerFromDate.Location = new System.Drawing.Point(77, 43);
            this.datePickerFromDate.Name = "datePickerFromDate";
            this.datePickerFromDate.ShowCheckBox = true;
            this.datePickerFromDate.Size = new System.Drawing.Size(132, 20);
            this.datePickerFromDate.TabIndex = 41;
            this.datePickerFromDate.Value = new System.DateTime(2014, 9, 18, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "From Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(11, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "List of Messages ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 37);
            this.panel1.TabIndex = 12;
            // 
            // datePickerToDate
            // 
            this.datePickerToDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerToDate.Location = new System.Drawing.Point(269, 43);
            this.datePickerToDate.Name = "datePickerToDate";
            this.datePickerToDate.ShowCheckBox = true;
            this.datePickerToDate.Size = new System.Drawing.Size(123, 20);
            this.datePickerToDate.TabIndex = 49;
            this.datePickerToDate.Value = new System.DateTime(2014, 9, 18, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Type:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 35);
            this.panel2.TabIndex = 51;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(281, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(208, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(135, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(67, 23);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // SMSFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 175);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePickerToDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.datePickerFromDate);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "SMSFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMSFormView";
            this.Load += new System.EventHandler(this.SMSFormView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.DateTimePicker datePickerFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker datePickerToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnView;

    }
}