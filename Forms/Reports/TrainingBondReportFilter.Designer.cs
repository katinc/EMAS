namespace eMAS.Forms.Reports
{
    partial class TrainingBondReportFilter
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
            this.components = new System.ComponentModel.Container();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblGradeCategory = new System.Windows.Forms.Label();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAttendanceMode = new System.Windows.Forms.Label();
            this.cboAttendanceMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboQualification = new System.Windows.Forms.ComboBox();
            this.lblInstitution = new System.Windows.Forms.Label();
            this.cboInstitution = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.staffNoLabel = new System.Windows.Forms.Label();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // txtStaffName
            // 
            this.txtStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffName.Location = new System.Drawing.Point(84, 91);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(323, 22);
            this.txtStaffName.TabIndex = 1;
            this.txtStaffName.Visible = false;
            this.txtStaffName.TextChanged += new System.EventHandler(this.txtStaffName_TextChanged);
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "From:";
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Checked = false;
            this.datePickerFrom.CustomFormat = " dd/MM/yyyy";
            this.datePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerFrom.Location = new System.Drawing.Point(83, 10);
            this.datePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.ShowCheckBox = true;
            this.datePickerFrom.Size = new System.Drawing.Size(193, 22);
            this.datePickerFrom.TabIndex = 35;
            this.datePickerFrom.Value = new System.DateTime(2015, 5, 20, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(497, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "To:";
            // 
            // datePickerTo
            // 
            this.datePickerTo.Checked = false;
            this.datePickerTo.CustomFormat = " dd/MM/yyyy";
            this.datePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerTo.Location = new System.Drawing.Point(533, 7);
            this.datePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.ShowCheckBox = true;
            this.datePickerTo.Size = new System.Drawing.Size(196, 22);
            this.datePickerTo.TabIndex = 33;
            this.datePickerTo.Value = new System.DateTime(2015, 5, 20, 0, 0, 0, 0);
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(533, 160);
            this.cboGrade.Margin = new System.Windows.Forms.Padding(4);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(196, 24);
            this.cboGrade.TabIndex = 30;
            this.cboGrade.Visible = false;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.Location = new System.Drawing.Point(473, 165);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(56, 17);
            this.lblGrade.TabIndex = 29;
            this.lblGrade.Text = "Grade :";
            this.lblGrade.Visible = false;
            // 
            // lblGradeCategory
            // 
            this.lblGradeCategory.AutoSize = true;
            this.lblGradeCategory.Location = new System.Drawing.Point(456, 137);
            this.lblGradeCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGradeCategory.Name = "lblGradeCategory";
            this.lblGradeCategory.Size = new System.Drawing.Size(73, 17);
            this.lblGradeCategory.TabIndex = 28;
            this.lblGradeCategory.Text = "Category :";
            this.lblGradeCategory.Visible = false;
            // 
            // gridStaffCode
            // 
            this.gridStaffCode.HeaderText = "StaffCode";
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.ReadOnly = true;
            this.gridStaffCode.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(533, 130);
            this.cboGradeCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(196, 24);
            this.cboGradeCategory.TabIndex = 27;
            this.cboGradeCategory.Visible = false;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(9, 7);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Training Bond Report";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(250, 371);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 30);
            this.btnOK.TabIndex = 32;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(414, 371);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 30);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(331, 371);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.lblAttendanceMode);
            this.panel2.Controls.Add(this.cboAttendanceMode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboQualification);
            this.panel2.Controls.Add(this.lblInstitution);
            this.panel2.Controls.Add(this.cboInstitution);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.cboStatus);
            this.panel2.Controls.Add(this.txtStaffName);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.datePickerFrom);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.datePickerTo);
            this.panel2.Controls.Add(this.cboGrade);
            this.panel2.Controls.Add(this.lblGrade);
            this.panel2.Controls.Add(this.lblGradeCategory);
            this.panel2.Controls.Add(this.cboGradeCategory);
            this.panel2.Controls.Add(this.cboUnit);
            this.panel2.Controls.Add(this.lblUnit);
            this.panel2.Controls.Add(this.lblDepartment);
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Controls.Add(this.cboZone);
            this.panel2.Controls.Add(this.lblZone);
            this.panel2.Controls.Add(this.txtStaffNo);
            this.panel2.Controls.Add(this.staffNoLabel);
            this.panel2.Controls.Add(this.cmbOption);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.searchGrid);
            this.panel2.Location = new System.Drawing.Point(13, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 335);
            this.panel2.TabIndex = 29;
            // 
            // lblAttendanceMode
            // 
            this.lblAttendanceMode.AutoSize = true;
            this.lblAttendanceMode.BackColor = System.Drawing.Color.Transparent;
            this.lblAttendanceMode.Location = new System.Drawing.Point(403, 226);
            this.lblAttendanceMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttendanceMode.Name = "lblAttendanceMode";
            this.lblAttendanceMode.Size = new System.Drawing.Size(123, 17);
            this.lblAttendanceMode.TabIndex = 48;
            this.lblAttendanceMode.Text = "Attendance Mode:";
            this.lblAttendanceMode.Visible = false;
            // 
            // cboAttendanceMode
            // 
            this.cboAttendanceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAttendanceMode.FormattingEnabled = true;
            this.cboAttendanceMode.Location = new System.Drawing.Point(533, 223);
            this.cboAttendanceMode.Margin = new System.Windows.Forms.Padding(4);
            this.cboAttendanceMode.Name = "cboAttendanceMode";
            this.cboAttendanceMode.Size = new System.Drawing.Size(196, 24);
            this.cboAttendanceMode.TabIndex = 47;
            this.cboAttendanceMode.Visible = false;
            this.cboAttendanceMode.DropDown += new System.EventHandler(this.cboAttendanceMode_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(439, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "Qualification:";
            this.label4.Visible = false;
            // 
            // cboQualification
            // 
            this.cboQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQualification.FormattingEnabled = true;
            this.cboQualification.Location = new System.Drawing.Point(533, 191);
            this.cboQualification.Margin = new System.Windows.Forms.Padding(4);
            this.cboQualification.Name = "cboQualification";
            this.cboQualification.Size = new System.Drawing.Size(196, 24);
            this.cboQualification.TabIndex = 45;
            this.cboQualification.Visible = false;
            this.cboQualification.DropDown += new System.EventHandler(this.cboQualification_DropDown);
            // 
            // lblInstitution
            // 
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.BackColor = System.Drawing.Color.Transparent;
            this.lblInstitution.Location = new System.Drawing.Point(7, 222);
            this.lblInstitution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(72, 17);
            this.lblInstitution.TabIndex = 44;
            this.lblInstitution.Text = "Institution:";
            this.lblInstitution.Visible = false;
            // 
            // cboInstitution
            // 
            this.cboInstitution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstitution.FormattingEnabled = true;
            this.cboInstitution.Location = new System.Drawing.Point(84, 219);
            this.cboInstitution.Margin = new System.Windows.Forms.Padding(4);
            this.cboInstitution.Name = "cboInstitution";
            this.cboInstitution.Size = new System.Drawing.Size(196, 24);
            this.cboInstitution.TabIndex = 43;
            this.cboInstitution.Visible = false;
            this.cboInstitution.DropDown += new System.EventHandler(this.cboInstitution_DropDown);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(27, 193);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 42;
            this.lblStatus.Text = "Status:";
            this.lblStatus.Visible = false;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "All",
            "In Progress",
            "Completed",
            "Defaulted",
            "Aborted"});
            this.cboStatus.Location = new System.Drawing.Point(84, 190);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(89, 24);
            this.cboStatus.TabIndex = 41;
            this.cboStatus.Visible = false;
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(533, 68);
            this.cboUnit.Margin = new System.Windows.Forms.Padding(4);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(196, 24);
            this.cboUnit.TabIndex = 26;
            this.cboUnit.Visible = false;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Location = new System.Drawing.Point(485, 73);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(41, 17);
            this.lblUnit.TabIndex = 25;
            this.lblUnit.Text = "Unit :";
            this.lblUnit.Visible = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(439, 44);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(90, 17);
            this.lblDepartment.TabIndex = 24;
            this.lblDepartment.Text = "Department :";
            this.lblDepartment.Visible = false;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(533, 38);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(196, 24);
            this.cboDepartment.TabIndex = 22;
            this.cboDepartment.Visible = false;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Location = new System.Drawing.Point(533, 100);
            this.cboZone.Margin = new System.Windows.Forms.Padding(4);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(196, 24);
            this.cboZone.TabIndex = 23;
            this.cboZone.Visible = false;
            this.cboZone.DropDown += new System.EventHandler(this.cboZone_DropDown);
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.BackColor = System.Drawing.Color.Transparent;
            this.lblZone.Location = new System.Drawing.Point(477, 106);
            this.lblZone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(49, 17);
            this.lblZone.TabIndex = 21;
            this.lblZone.Text = "Zone :";
            this.lblZone.Visible = false;
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffNo.Location = new System.Drawing.Point(84, 65);
            this.txtStaffNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(129, 22);
            this.txtStaffNo.TabIndex = 1;
            this.txtStaffNo.Visible = false;
            this.txtStaffNo.TextChanged += new System.EventHandler(this.txtStaffNo_TextChanged);
            // 
            // staffNoLabel
            // 
            this.staffNoLabel.AutoSize = true;
            this.staffNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.staffNoLabel.Location = new System.Drawing.Point(15, 69);
            this.staffNoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.staffNoLabel.Name = "staffNoLabel";
            this.staffNoLabel.Size = new System.Drawing.Size(63, 17);
            this.staffNoLabel.TabIndex = 0;
            this.staffNoLabel.Text = "Staff No:";
            this.staffNoLabel.Visible = false;
            // 
            // cmbOption
            // 
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "Individual Employee",
            "All Employees"});
            this.cmbOption.Location = new System.Drawing.Point(84, 37);
            this.cmbOption.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(192, 24);
            this.cmbOption.TabIndex = 2;
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(29, 96);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Option:";
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridStaffNo,
            this.gridStaffCode,
            this.gridName});
            this.searchGrid.Location = new System.Drawing.Point(84, 117);
            this.searchGrid.Margin = new System.Windows.Forms.Padding(4);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(344, 65);
            this.searchGrid.TabIndex = 6;
            this.searchGrid.Visible = false;
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "StaffCode";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // TrainingBondReportFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(760, 405);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel2);
            this.Name = "TrainingBondReportFilter";
            this.Text = "Training Bond Report";
            this.Load += new System.EventHandler(this.ExcuseDutyReportFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblGradeCategory;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.Label staffNoLabel;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboQualification;
        private System.Windows.Forms.Label lblInstitution;
        private System.Windows.Forms.ComboBox cboInstitution;
        private System.Windows.Forms.Label lblAttendanceMode;
        private System.Windows.Forms.ComboBox cboAttendanceMode;

    }
}