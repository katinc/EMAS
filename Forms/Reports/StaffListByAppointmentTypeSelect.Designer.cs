namespace eMAS.Forms.Reports
{
    partial class StaffListByAppointmentTypeSelect
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.asAtDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.staffNoRadioButton = new System.Windows.Forms.RadioButton();
            this.nameRadioButton = new System.Windows.Forms.RadioButton();
            this.departmentRadioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAppointmentType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(178, 207);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 24);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(239, 207);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "AsAtDate:";
            this.label3.Visible = false;
            // 
            // asAtDatePicker
            // 
            this.asAtDatePicker.CustomFormat = "dd/MM/yyyy";
            this.asAtDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.asAtDatePicker.Location = new System.Drawing.Point(106, 141);
            this.asAtDatePicker.Name = "asAtDatePicker";
            this.asAtDatePicker.Size = new System.Drawing.Size(129, 20);
            this.asAtDatePicker.TabIndex = 18;
            this.asAtDatePicker.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Unit:";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(368, 38);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(169, 21);
            this.cboUnit.TabIndex = 3;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(368, 12);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(170, 21);
            this.cboDepartment.TabIndex = 2;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(302, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Department:";
            // 
            // staffNoRadioButton
            // 
            this.staffNoRadioButton.AutoSize = true;
            this.staffNoRadioButton.Checked = true;
            this.staffNoRadioButton.Location = new System.Drawing.Point(6, 14);
            this.staffNoRadioButton.Name = "staffNoRadioButton";
            this.staffNoRadioButton.Size = new System.Drawing.Size(67, 17);
            this.staffNoRadioButton.TabIndex = 2;
            this.staffNoRadioButton.TabStop = true;
            this.staffNoRadioButton.Text = "Staff No.";
            this.staffNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // nameRadioButton
            // 
            this.nameRadioButton.AutoSize = true;
            this.nameRadioButton.Location = new System.Drawing.Point(92, 14);
            this.nameRadioButton.Name = "nameRadioButton";
            this.nameRadioButton.Size = new System.Drawing.Size(53, 17);
            this.nameRadioButton.TabIndex = 1;
            this.nameRadioButton.Text = "Name";
            this.nameRadioButton.UseVisualStyleBackColor = true;
            // 
            // departmentRadioButton
            // 
            this.departmentRadioButton.AutoSize = true;
            this.departmentRadioButton.Location = new System.Drawing.Point(170, 14);
            this.departmentRadioButton.Name = "departmentRadioButton";
            this.departmentRadioButton.Size = new System.Drawing.Size(80, 17);
            this.departmentRadioButton.TabIndex = 0;
            this.departmentRadioButton.Text = "Department";
            this.departmentRadioButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Grade:";
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(106, 38);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(172, 21);
            this.cboGrade.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Grade Category:";
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(106, 12);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(172, 21);
            this.cboGradeCategory.TabIndex = 25;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Zone:";
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Location = new System.Drawing.Point(369, 65);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(169, 21);
            this.cboZone.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Appointment Type:";
            // 
            // cboAppointmentType
            // 
            this.cboAppointmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAppointmentType.FormattingEnabled = true;
            this.cboAppointmentType.Location = new System.Drawing.Point(108, 68);
            this.cboAppointmentType.Name = "cboAppointmentType";
            this.cboAppointmentType.Size = new System.Drawing.Size(170, 21);
            this.cboAppointmentType.TabIndex = 21;
            this.cboAppointmentType.DropDown += new System.EventHandler(this.cboAppointmentType_DropDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.staffNoRadioButton);
            this.groupBox1.Controls.Add(this.nameRadioButton);
            this.groupBox1.Controls.Add(this.departmentRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(106, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 40);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order By";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(299, 207);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboGrade);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboGradeCategory);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboZone);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboAppointmentType);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.asAtDatePicker);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboUnit);
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 179);
            this.panel2.TabIndex = 20;
            // 
            // StaffListByAppointmentTypeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(614, 238);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Name = "StaffListByAppointmentTypeSelect";
            this.Text = "StaffListByAppointmentTypeSelect";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker asAtDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton staffNoRadioButton;
        private System.Windows.Forms.RadioButton nameRadioButton;
        private System.Windows.Forms.RadioButton departmentRadioButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboAppointmentType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
    }
}