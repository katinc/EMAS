namespace eMAS.Forms.ClaimsLeaveHirePurchase
{
    partial class MedicalClaimsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNHIANumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRelationship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPatientDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDoctorSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridOPDNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDoctorDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSupervisorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSupervisorSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridHealthFacilityType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridHealthFacilityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridServiceCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMedicineCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridApproved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRejected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.paymentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStaffID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridStaffCode,
            this.gridAge,
            this.gridDOB,
            this.gridGender,
            this.gridNHIANumber,
            this.gridDepartment,
            this.gridUnit,
            this.gridStaffID,
            this.gridStaffName,
            this.gridRelationship,
            this.gridPatientName,
            this.gridPatientDOB,
            this.gridDoctorName,
            this.gridDoctorSign,
            this.gridOPDNumber,
            this.gridDiagnosis,
            this.gridDoctorDate,
            this.gridSupervisorName,
            this.gridSupervisorSign,
            this.gridHealthFacilityType,
            this.gridHealthFacilityName,
            this.gridServiceCost,
            this.gridMedicineCost,
            this.gridTotalCost,
            this.gridPaymentDate,
            this.gridEntryDate,
            this.gridReceiptNo,
            this.gridPaid,
            this.gridApproved,
            this.gridRejected,
            this.gridActive,
            this.gridUserID});
            this.grid.Location = new System.Drawing.Point(20, 120);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 21;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(692, 240);
            this.grid.TabIndex = 31;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridStaffCode
            // 
            this.gridStaffCode.HeaderText = "StaffCode";
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.ReadOnly = true;
            this.gridStaffCode.Visible = false;
            // 
            // gridAge
            // 
            this.gridAge.HeaderText = "Age";
            this.gridAge.Name = "gridAge";
            this.gridAge.ReadOnly = true;
            this.gridAge.Visible = false;
            // 
            // gridDOB
            // 
            this.gridDOB.HeaderText = "DOB";
            this.gridDOB.Name = "gridDOB";
            this.gridDOB.ReadOnly = true;
            this.gridDOB.Visible = false;
            // 
            // gridGender
            // 
            this.gridGender.HeaderText = "Sex";
            this.gridGender.Name = "gridGender";
            this.gridGender.ReadOnly = true;
            this.gridGender.Visible = false;
            // 
            // gridNHIANumber
            // 
            this.gridNHIANumber.HeaderText = "NHIANumber";
            this.gridNHIANumber.Name = "gridNHIANumber";
            this.gridNHIANumber.ReadOnly = true;
            this.gridNHIANumber.Visible = false;
            // 
            // gridDepartment
            // 
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            this.gridDepartment.Visible = false;
            // 
            // gridUnit
            // 
            this.gridUnit.HeaderText = "Unit";
            this.gridUnit.Name = "gridUnit";
            this.gridUnit.ReadOnly = true;
            this.gridUnit.Visible = false;
            // 
            // gridStaffID
            // 
            this.gridStaffID.HeaderText = "StaffID";
            this.gridStaffID.Name = "gridStaffID";
            this.gridStaffID.ReadOnly = true;
            this.gridStaffID.Visible = false;
            // 
            // gridStaffName
            // 
            this.gridStaffName.HeaderText = "Staff Name";
            this.gridStaffName.Name = "gridStaffName";
            this.gridStaffName.ReadOnly = true;
            this.gridStaffName.Width = 121;
            // 
            // gridRelationship
            // 
            this.gridRelationship.HeaderText = "Relationship";
            this.gridRelationship.Name = "gridRelationship";
            this.gridRelationship.ReadOnly = true;
            // 
            // gridPatientName
            // 
            this.gridPatientName.HeaderText = "PatientName";
            this.gridPatientName.Name = "gridPatientName";
            this.gridPatientName.ReadOnly = true;
            // 
            // gridPatientDOB
            // 
            this.gridPatientDOB.HeaderText = "PatientDOB";
            this.gridPatientDOB.Name = "gridPatientDOB";
            this.gridPatientDOB.ReadOnly = true;
            // 
            // gridDoctorName
            // 
            this.gridDoctorName.HeaderText = "Doctor Name";
            this.gridDoctorName.Name = "gridDoctorName";
            this.gridDoctorName.ReadOnly = true;
            // 
            // gridDoctorSign
            // 
            this.gridDoctorSign.HeaderText = "Doctor Sign";
            this.gridDoctorSign.Name = "gridDoctorSign";
            this.gridDoctorSign.ReadOnly = true;
            // 
            // gridOPDNumber
            // 
            this.gridOPDNumber.HeaderText = "OPD Number";
            this.gridOPDNumber.Name = "gridOPDNumber";
            this.gridOPDNumber.ReadOnly = true;
            // 
            // gridDiagnosis
            // 
            this.gridDiagnosis.HeaderText = "Diagnosis";
            this.gridDiagnosis.Name = "gridDiagnosis";
            this.gridDiagnosis.ReadOnly = true;
            // 
            // gridDoctorDate
            // 
            this.gridDoctorDate.HeaderText = "Doctor Date";
            this.gridDoctorDate.Name = "gridDoctorDate";
            this.gridDoctorDate.ReadOnly = true;
            // 
            // gridSupervisorName
            // 
            this.gridSupervisorName.HeaderText = "SupervisorName";
            this.gridSupervisorName.Name = "gridSupervisorName";
            this.gridSupervisorName.ReadOnly = true;
            // 
            // gridSupervisorSign
            // 
            this.gridSupervisorSign.HeaderText = "Supervisor Sign";
            this.gridSupervisorSign.Name = "gridSupervisorSign";
            this.gridSupervisorSign.ReadOnly = true;
            // 
            // gridHealthFacilityType
            // 
            this.gridHealthFacilityType.HeaderText = "Health Facility Type";
            this.gridHealthFacilityType.Name = "gridHealthFacilityType";
            this.gridHealthFacilityType.ReadOnly = true;
            this.gridHealthFacilityType.Width = 150;
            // 
            // gridHealthFacilityName
            // 
            this.gridHealthFacilityName.HeaderText = "Health Facility Name";
            this.gridHealthFacilityName.Name = "gridHealthFacilityName";
            this.gridHealthFacilityName.ReadOnly = true;
            this.gridHealthFacilityName.Width = 150;
            // 
            // gridServiceCost
            // 
            this.gridServiceCost.HeaderText = "Service Cost";
            this.gridServiceCost.Name = "gridServiceCost";
            this.gridServiceCost.ReadOnly = true;
            // 
            // gridMedicineCost
            // 
            this.gridMedicineCost.HeaderText = "Medicine Cost";
            this.gridMedicineCost.Name = "gridMedicineCost";
            this.gridMedicineCost.ReadOnly = true;
            // 
            // gridTotalCost
            // 
            this.gridTotalCost.HeaderText = "Total Cost";
            this.gridTotalCost.Name = "gridTotalCost";
            this.gridTotalCost.ReadOnly = true;
            // 
            // gridPaymentDate
            // 
            this.gridPaymentDate.HeaderText = "Payment Date";
            this.gridPaymentDate.Name = "gridPaymentDate";
            this.gridPaymentDate.ReadOnly = true;
            // 
            // gridEntryDate
            // 
            this.gridEntryDate.HeaderText = "Entry Date";
            this.gridEntryDate.Name = "gridEntryDate";
            this.gridEntryDate.ReadOnly = true;
            // 
            // gridReceiptNo
            // 
            this.gridReceiptNo.HeaderText = "Receipt No.";
            this.gridReceiptNo.Name = "gridReceiptNo";
            this.gridReceiptNo.ReadOnly = true;
            // 
            // gridPaid
            // 
            this.gridPaid.HeaderText = "Paid";
            this.gridPaid.Name = "gridPaid";
            this.gridPaid.ReadOnly = true;
            // 
            // gridApproved
            // 
            this.gridApproved.HeaderText = "Approved";
            this.gridApproved.Name = "gridApproved";
            this.gridApproved.ReadOnly = true;
            // 
            // gridRejected
            // 
            this.gridRejected.HeaderText = "Rejected";
            this.gridRejected.Name = "gridRejected";
            this.gridRejected.ReadOnly = true;
            // 
            // gridActive
            // 
            this.gridActive.HeaderText = "Active";
            this.gridActive.Name = "gridActive";
            this.gridActive.ReadOnly = true;
            this.gridActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridUserID
            // 
            this.gridUserID.HeaderText = "UserID";
            this.gridUserID.Name = "gridUserID";
            this.gridUserID.ReadOnly = true;
            this.gridUserID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.removeButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 33);
            this.panel1.TabIndex = 30;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(505, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(586, 5);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(652, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(732, 24);
            this.panel2.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "All Medical Claims";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Payment Date:";
            // 
            // paymentDatePicker
            // 
            this.paymentDatePicker.Checked = false;
            this.paymentDatePicker.CustomFormat = "dd/MM/yyyy";
            this.paymentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.paymentDatePicker.Location = new System.Drawing.Point(359, 83);
            this.paymentDatePicker.MaxDate = new System.DateTime(2015, 2, 19, 0, 0, 0, 0);
            this.paymentDatePicker.Name = "paymentDatePicker";
            this.paymentDatePicker.ShowCheckBox = true;
            this.paymentDatePicker.Size = new System.Drawing.Size(163, 20);
            this.paymentDatePicker.TabIndex = 57;
            this.paymentDatePicker.Value = new System.DateTime(2015, 2, 19, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(529, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(591, 33);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 20);
            this.txtFirstName.TabIndex = 55;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(591, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 31);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(591, 58);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(122, 20);
            this.txtSurname.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Surname : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "StaffID : ";
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(86, 83);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(177, 20);
            this.txtStaffID.TabIndex = 50;
            this.txtStaffID.TextChanged += new System.EventHandler(this.txtStaffID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Unit : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Department :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Grade Category :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Grade : ";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(86, 56);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(177, 21);
            this.cboUnit.TabIndex = 45;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(86, 30);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(177, 21);
            this.cboDepartment.TabIndex = 44;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(359, 57);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(163, 21);
            this.cboGrade.TabIndex = 43;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(359, 30);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(163, 21);
            this.cboGradeCategory.TabIndex = 42;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "StaffCode";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Age";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Sex";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "NHIANumber";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "StaffID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Staff Name";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 121;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Health Facility Type";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Health Facility Name";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Service Cost";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Medicine Cost";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 150;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Total Cost";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Payment Date";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Entry Date";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Receipt No.";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Entry Date";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Receipt No.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // MedicalClaimsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(719, 398);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.paymentDatePicker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStaffID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboUnit);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.cboGrade);
            this.Controls.Add(this.cboGradeCategory);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "MedicalClaimsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medical Claims View";
            this.Load += new System.EventHandler(this.MedicalClaimsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker paymentDatePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStaffID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNHIANumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRelationship;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPatientDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDoctorSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridOPDNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDoctorDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSupervisorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSupervisorSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridHealthFacilityType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridHealthFacilityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridServiceCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMedicineCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridReceiptNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRejected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
        public System.Windows.Forms.Button removeButton;
    }
}