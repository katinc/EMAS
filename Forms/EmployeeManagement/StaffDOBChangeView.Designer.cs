﻿namespace eMAS.Forms.EmployeeManagement
{
    partial class StaffDOBChangeView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateEntry = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDOBTo = new CalendarColumn();
            this.gridDate = new CalendarColumn();
            this.gridSpecialty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEmploymentDate = new CalendarColumn();
            this.gridDOBFrom = new CalendarColumn();
            this.gridReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGradeCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridApprovedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridApprovedUserStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridApprovedDate = new CalendarColumn();
            this.gridApprovedTime = new CalendarTimeColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDOBTo = new System.Windows.Forms.DateTimePicker();
            this.dateDOBFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "ApprovedTime";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(286, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(368, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(449, 5);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Cancel";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Visible = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(515, 5);
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
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 33);
            this.panel2.TabIndex = 109;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "All Staff DOB Changes";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "ApprovedUserStaffID";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 132;
            this.label3.Text = "Unit : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 131;
            this.label8.Text = "Department :";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "StaffID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Staff Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "GradeCategory";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "GradeCategory";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "ApprovedUser";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "ApprovedDate";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(277, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 130;
            this.label9.Text = "Grade Category :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(322, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 129;
            this.label10.Text = "Grade : ";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(81, 137);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(187, 21);
            this.cboUnit.TabIndex = 128;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(81, 111);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(187, 21);
            this.cboDepartment.TabIndex = 127;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 124;
            this.label7.Text = "First Name:";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Termintation Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(367, 59);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(197, 20);
            this.txtFirstName.TabIndex = 123;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(576, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 61);
            this.btnSearch.TabIndex = 122;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateEntry
            // 
            this.dateEntry.Checked = false;
            this.dateEntry.CustomFormat = "dd/MM/yyyy";
            this.dateEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEntry.Location = new System.Drawing.Point(367, 35);
            this.dateEntry.Name = "dateEntry";
            this.dateEntry.ShowCheckBox = true;
            this.dateEntry.Size = new System.Drawing.Size(197, 20);
            this.dateEntry.TabIndex = 119;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 121;
            this.label1.Text = "DOB:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 118;
            this.label6.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "Staff ID:";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Surname:";
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(367, 84);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(197, 20);
            this.staffIDtxt.TabIndex = 115;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(367, 108);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(197, 21);
            this.cboGradeCategory.TabIndex = 125;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
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
            this.gridGender,
            this.gridAge,
            this.gridStaffID,
            this.gridStaffName,
            this.gridDOBTo,
            this.gridDate,
            this.gridSpecialty,
            this.gridEmploymentDate,
            this.gridDOBFrom,
            this.gridReason,
            this.gridDepartment,
            this.gridUnit,
            this.gridGradeCategory,
            this.gridGrade,
            this.gridApproved,
            this.gridApprovedUser,
            this.gridApprovedUserStaffID,
            this.gridApprovedDate,
            this.gridApprovedTime,
            this.gridUserID});
            this.grid.Location = new System.Drawing.Point(5, 162);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 21;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(661, 252);
            this.grid.TabIndex = 111;
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
            // gridGender
            // 
            this.gridGender.HeaderText = "Gender";
            this.gridGender.Name = "gridGender";
            this.gridGender.ReadOnly = true;
            this.gridGender.Visible = false;
            // 
            // gridAge
            // 
            this.gridAge.HeaderText = "Age";
            this.gridAge.Name = "gridAge";
            this.gridAge.ReadOnly = true;
            this.gridAge.Visible = false;
            // 
            // gridStaffID
            // 
            this.gridStaffID.HeaderText = "StaffID";
            this.gridStaffID.Name = "gridStaffID";
            this.gridStaffID.ReadOnly = true;
            // 
            // gridStaffName
            // 
            this.gridStaffName.HeaderText = "Staff Name";
            this.gridStaffName.Name = "gridStaffName";
            this.gridStaffName.ReadOnly = true;
            this.gridStaffName.Width = 150;
            // 
            // gridDOBTo
            // 
            this.gridDOBTo.HeaderText = "New DOB";
            this.gridDOBTo.Name = "gridDOBTo";
            this.gridDOBTo.ReadOnly = true;
            this.gridDOBTo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDOBTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridDate
            // 
            this.gridDate.HeaderText = "Date";
            this.gridDate.Name = "gridDate";
            this.gridDate.ReadOnly = true;
            this.gridDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridSpecialty
            // 
            this.gridSpecialty.HeaderText = "Specialty";
            this.gridSpecialty.Name = "gridSpecialty";
            this.gridSpecialty.ReadOnly = true;
            this.gridSpecialty.Visible = false;
            // 
            // gridEmploymentDate
            // 
            this.gridEmploymentDate.HeaderText = "EmploymentDate";
            this.gridEmploymentDate.Name = "gridEmploymentDate";
            this.gridEmploymentDate.ReadOnly = true;
            this.gridEmploymentDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEmploymentDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridEmploymentDate.Visible = false;
            // 
            // gridDOBFrom
            // 
            this.gridDOBFrom.HeaderText = "DOB";
            this.gridDOBFrom.Name = "gridDOBFrom";
            this.gridDOBFrom.ReadOnly = true;
            this.gridDOBFrom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDOBFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridReason
            // 
            this.gridReason.HeaderText = "Reason";
            this.gridReason.Name = "gridReason";
            this.gridReason.ReadOnly = true;
            // 
            // gridDepartment
            // 
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            // 
            // gridUnit
            // 
            this.gridUnit.HeaderText = "Unit";
            this.gridUnit.Name = "gridUnit";
            this.gridUnit.ReadOnly = true;
            // 
            // gridGradeCategory
            // 
            this.gridGradeCategory.HeaderText = "GradeCategory";
            this.gridGradeCategory.Name = "gridGradeCategory";
            this.gridGradeCategory.ReadOnly = true;
            // 
            // gridGrade
            // 
            this.gridGrade.HeaderText = "Grade";
            this.gridGrade.Name = "gridGrade";
            this.gridGrade.ReadOnly = true;
            // 
            // gridApproved
            // 
            this.gridApproved.HeaderText = "Approved";
            this.gridApproved.Name = "gridApproved";
            this.gridApproved.ReadOnly = true;
            this.gridApproved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridApproved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridApprovedUser
            // 
            this.gridApprovedUser.HeaderText = "ApprovedUser";
            this.gridApprovedUser.Name = "gridApprovedUser";
            this.gridApprovedUser.ReadOnly = true;
            // 
            // gridApprovedUserStaffID
            // 
            this.gridApprovedUserStaffID.HeaderText = "ApprovedUserStaffID";
            this.gridApprovedUserStaffID.Name = "gridApprovedUserStaffID";
            this.gridApprovedUserStaffID.ReadOnly = true;
            // 
            // gridApprovedDate
            // 
            this.gridApprovedDate.HeaderText = "ApprovedDate";
            this.gridApprovedDate.Name = "gridApprovedDate";
            this.gridApprovedDate.ReadOnly = true;
            this.gridApprovedDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridApprovedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridApprovedTime
            // 
            this.gridApprovedTime.HeaderText = "ApprovedTime";
            this.gridApprovedTime.Name = "gridApprovedTime";
            this.gridApprovedTime.ReadOnly = true;
            this.gridApprovedTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridApprovedTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.removeButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 33);
            this.panel1.TabIndex = 110;
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(367, 135);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(197, 21);
            this.cboGrade.TabIndex = 126;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(81, 63);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(186, 20);
            this.txtSurname.TabIndex = 114;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Type";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 113;
            this.label2.Text = "New DOB:";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Employee Notified";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Department";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Employer Notified";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Reason";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "SeparationType";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dateDOBTo
            // 
            this.dateDOBTo.Checked = false;
            this.dateDOBTo.CustomFormat = "dd/MM/yyyy";
            this.dateDOBTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDOBTo.Location = new System.Drawing.Point(81, 40);
            this.dateDOBTo.Name = "dateDOBTo";
            this.dateDOBTo.ShowCheckBox = true;
            this.dateDOBTo.Size = new System.Drawing.Size(186, 20);
            this.dateDOBTo.TabIndex = 120;
            // 
            // dateDOBFrom
            // 
            this.dateDOBFrom.Checked = false;
            this.dateDOBFrom.CustomFormat = "dd/MM/yyyy";
            this.dateDOBFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDOBFrom.Location = new System.Drawing.Point(81, 87);
            this.dateDOBFrom.Name = "dateDOBFrom";
            this.dateDOBFrom.ShowCheckBox = true;
            this.dateDOBFrom.Size = new System.Drawing.Size(186, 20);
            this.dateDOBFrom.TabIndex = 133;
            // 
            // StaffDOBChangeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 454);
            this.Controls.Add(this.dateDOBFrom);
            this.Controls.Add(this.dateDOBTo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboUnit);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateEntry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.staffIDtxt);
            this.Controls.Add(this.cboGradeCategory);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboGrade);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "StaffDOBChangeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff DOB Change View";
            this.Load += new System.EventHandler(this.StaffDOBChangeView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DateTimePicker dateDOBFrom;
        private System.Windows.Forms.DateTimePicker dateDOBTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffName;
        private CalendarColumn gridDOBTo;
        private CalendarColumn gridDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSpecialty;
        private CalendarColumn gridEmploymentDate;
        private CalendarColumn gridDOBFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGradeCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrade;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridApprovedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridApprovedUserStaffID;
        private CalendarColumn gridApprovedDate;
        private CalendarTimeColumn gridApprovedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
        public System.Windows.Forms.Button btnDelete;
    }
}