namespace eMAS.Forms.EmployeeManagement
{
    partial class LeaveView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnnualLeave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnnualLeaveYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeaveArrears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnnualLeaveProposedStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnnualLeaveProposedEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnnualLeaveProposedDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGradeCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNumberOfDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStartDate = new CalendarColumn();
            this.gridEndDate = new CalendarColumn();
            this.gridLeaveDate = new CalendarColumn();
            this.gridCurrentLeaveEndDate = new CalendarColumn();
            this.gridStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecommended = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new CalendarColumn();
            this.calendarColumn2 = new CalendarColumn();
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
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboLeaveType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridGender,
            this.gridAge,
            this.gridAnnualLeave,
            this.gridAnnualLeaveYear,
            this.gridLeaveArrears,
            this.gridStaffCode,
            this.gridAnnualLeaveProposedStartDate,
            this.gridAnnualLeaveProposedEndDate,
            this.gridAnnualLeaveProposedDays,
            this.gridStaffID,
            this.gridStaffName,
            this.gridDepartment,
            this.gridUnit,
            this.gridGradeCategory,
            this.gridGrade,
            this.gridType,
            this.gridNumberOfDays,
            this.gridStartDate,
            this.gridEndDate,
            this.gridLeaveDate,
            this.gridCurrentLeaveEndDate,
            this.gridStatus,
            this.gridReason,
            this.gridRecommended,
            this.gridApproved,
            this.gridUserID});
            this.grid.Location = new System.Drawing.Point(40, 277);
            this.grid.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 21;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1762, 709);
            this.grid.TabIndex = 31;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            this.gridID.Width = 50;
            // 
            // gridGender
            // 
            this.gridGender.HeaderText = "Gender";
            this.gridGender.Name = "gridGender";
            this.gridGender.ReadOnly = true;
            this.gridGender.Visible = false;
            this.gridGender.Width = 50;
            // 
            // gridAge
            // 
            this.gridAge.HeaderText = "Age";
            this.gridAge.Name = "gridAge";
            this.gridAge.ReadOnly = true;
            this.gridAge.Visible = false;
            this.gridAge.Width = 50;
            // 
            // gridAnnualLeave
            // 
            this.gridAnnualLeave.HeaderText = "AnnualLeave";
            this.gridAnnualLeave.Name = "gridAnnualLeave";
            this.gridAnnualLeave.ReadOnly = true;
            this.gridAnnualLeave.Visible = false;
            this.gridAnnualLeave.Width = 40;
            // 
            // gridAnnualLeaveYear
            // 
            this.gridAnnualLeaveYear.HeaderText = "AnnualLeaveYear";
            this.gridAnnualLeaveYear.Name = "gridAnnualLeaveYear";
            this.gridAnnualLeaveYear.ReadOnly = true;
            this.gridAnnualLeaveYear.Visible = false;
            // 
            // gridLeaveArrears
            // 
            this.gridLeaveArrears.HeaderText = "LeaveArrears";
            this.gridLeaveArrears.Name = "gridLeaveArrears";
            this.gridLeaveArrears.ReadOnly = true;
            this.gridLeaveArrears.Visible = false;
            this.gridLeaveArrears.Width = 40;
            // 
            // gridStaffCode
            // 
            this.gridStaffCode.HeaderText = "StaffCode";
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.ReadOnly = true;
            this.gridStaffCode.Visible = false;
            this.gridStaffCode.Width = 50;
            // 
            // gridAnnualLeaveProposedStartDate
            // 
            this.gridAnnualLeaveProposedStartDate.HeaderText = "AnnualLeaveProposedStartDate";
            this.gridAnnualLeaveProposedStartDate.Name = "gridAnnualLeaveProposedStartDate";
            this.gridAnnualLeaveProposedStartDate.ReadOnly = true;
            this.gridAnnualLeaveProposedStartDate.Visible = false;
            // 
            // gridAnnualLeaveProposedEndDate
            // 
            this.gridAnnualLeaveProposedEndDate.HeaderText = "AnnualLeaveProposedEndDate";
            this.gridAnnualLeaveProposedEndDate.Name = "gridAnnualLeaveProposedEndDate";
            this.gridAnnualLeaveProposedEndDate.ReadOnly = true;
            this.gridAnnualLeaveProposedEndDate.Visible = false;
            // 
            // gridAnnualLeaveProposedDays
            // 
            this.gridAnnualLeaveProposedDays.HeaderText = "AnnualLeaveProposedDays";
            this.gridAnnualLeaveProposedDays.Name = "gridAnnualLeaveProposedDays";
            this.gridAnnualLeaveProposedDays.ReadOnly = true;
            this.gridAnnualLeaveProposedDays.Visible = false;
            // 
            // gridStaffID
            // 
            this.gridStaffID.HeaderText = "StaffID";
            this.gridStaffID.Name = "gridStaffID";
            this.gridStaffID.ReadOnly = true;
            this.gridStaffID.Width = 70;
            // 
            // gridStaffName
            // 
            this.gridStaffName.FillWeight = 204.4778F;
            this.gridStaffName.HeaderText = "Staff Name";
            this.gridStaffName.Name = "gridStaffName";
            this.gridStaffName.ReadOnly = true;
            // 
            // gridDepartment
            // 
            this.gridDepartment.FillWeight = 252.0374F;
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            // 
            // gridUnit
            // 
            this.gridUnit.FillWeight = 3.999858F;
            this.gridUnit.HeaderText = "Unit";
            this.gridUnit.Name = "gridUnit";
            this.gridUnit.ReadOnly = true;
            // 
            // gridGradeCategory
            // 
            this.gridGradeCategory.FillWeight = 3.999858F;
            this.gridGradeCategory.HeaderText = "GradeCategory";
            this.gridGradeCategory.Name = "gridGradeCategory";
            this.gridGradeCategory.ReadOnly = true;
            // 
            // gridGrade
            // 
            this.gridGrade.FillWeight = 3.999858F;
            this.gridGrade.HeaderText = "Grade";
            this.gridGrade.Name = "gridGrade";
            this.gridGrade.ReadOnly = true;
            // 
            // gridType
            // 
            this.gridType.FillWeight = 3.999858F;
            this.gridType.HeaderText = "Type";
            this.gridType.Name = "gridType";
            this.gridType.ReadOnly = true;
            this.gridType.Width = 80;
            // 
            // gridNumberOfDays
            // 
            this.gridNumberOfDays.FillWeight = 3.999858F;
            this.gridNumberOfDays.HeaderText = "No. of Days";
            this.gridNumberOfDays.Name = "gridNumberOfDays";
            this.gridNumberOfDays.ReadOnly = true;
            this.gridNumberOfDays.Width = 80;
            // 
            // gridStartDate
            // 
            this.gridStartDate.FillWeight = 3.999858F;
            this.gridStartDate.HeaderText = "Start Date";
            this.gridStartDate.Name = "gridStartDate";
            this.gridStartDate.ReadOnly = true;
            this.gridStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridStartDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridStartDate.Width = 70;
            // 
            // gridEndDate
            // 
            this.gridEndDate.FillWeight = 3.999858F;
            this.gridEndDate.HeaderText = "End Date";
            this.gridEndDate.Name = "gridEndDate";
            this.gridEndDate.ReadOnly = true;
            this.gridEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridEndDate.Width = 70;
            // 
            // gridLeaveDate
            // 
            this.gridLeaveDate.FillWeight = 3.999858F;
            this.gridLeaveDate.HeaderText = "LeaveDate";
            this.gridLeaveDate.Name = "gridLeaveDate";
            this.gridLeaveDate.ReadOnly = true;
            this.gridLeaveDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLeaveDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridLeaveDate.Width = 70;
            // 
            // gridCurrentLeaveEndDate
            // 
            this.gridCurrentLeaveEndDate.HeaderText = "CurrentLeaveEndDate";
            this.gridCurrentLeaveEndDate.Name = "gridCurrentLeaveEndDate";
            this.gridCurrentLeaveEndDate.ReadOnly = true;
            this.gridCurrentLeaveEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCurrentLeaveEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridStatus
            // 
            this.gridStatus.FillWeight = 3.999858F;
            this.gridStatus.HeaderText = "Status";
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.ReadOnly = true;
            this.gridStatus.Width = 70;
            // 
            // gridReason
            // 
            this.gridReason.FillWeight = 3.999858F;
            this.gridReason.HeaderText = "Reason";
            this.gridReason.Name = "gridReason";
            this.gridReason.ReadOnly = true;
            this.gridReason.Width = 150;
            // 
            // gridRecommended
            // 
            this.gridRecommended.HeaderText = "Recommended";
            this.gridRecommended.Name = "gridRecommended";
            this.gridRecommended.ReadOnly = true;
            this.gridRecommended.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRecommended.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridApproved
            // 
            this.gridApproved.HeaderText = "Approved";
            this.gridApproved.Name = "gridApproved";
            this.gridApproved.ReadOnly = true;
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
            this.panel1.Location = new System.Drawing.Point(0, 999);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1852, 82);
            this.panel1.TabIndex = 30;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1321, 11);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(175, 51);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(1505, 11);
            this.removeButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(140, 51);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1659, 11);
            this.closeButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(140, 51);
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
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1852, 71);
            this.panel2.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(37, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(280, 29);
            this.label13.TabIndex = 0;
            this.label13.Text = "All Leaves Requested";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "StaffID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Staff Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 146;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Type";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 147;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 146;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.HeaderText = "Start Date";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calendarColumn1.Width = 147;
            // 
            // calendarColumn2
            // 
            this.calendarColumn2.HeaderText = "End Date";
            this.calendarColumn2.Name = "calendarColumn2";
            this.calendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calendarColumn2.Width = 146;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(411, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 29);
            this.label7.TabIndex = 53;
            this.label7.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(555, 210);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(277, 35);
            this.txtFirstName.TabIndex = 52;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1626, 147);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(175, 100);
            this.btnSearch.TabIndex = 51;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(980, 207);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(370, 35);
            this.txtSurname.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(838, 214);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 29);
            this.label6.TabIndex = 49;
            this.label6.Text = "Surname : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 212);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 29);
            this.label5.TabIndex = 48;
            this.label5.Text = "StaffID : ";
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(180, 205);
            this.txtStaffID.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(219, 35);
            this.txtStaffID.TabIndex = 47;
            this.txtStaffID.TextChanged += new System.EventHandler(this.txtStaffID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 29);
            this.label4.TabIndex = 46;
            this.label4.Text = "Unit : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 29);
            this.label3.TabIndex = 45;
            this.label3.Text = "Department :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "Grade Category :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "Grade : ";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(180, 87);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(366, 37);
            this.cboDepartment.TabIndex = 42;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(768, 147);
            this.cboGrade.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(366, 37);
            this.cboGrade.TabIndex = 41;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(768, 87);
            this.cboGradeCategory.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(366, 37);
            this.cboGradeCategory.TabIndex = 40;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectedIndexChanged += new System.EventHandler(this.cboGradeCategory_SelectedIndexChanged);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(180, 147);
            this.cboUnit.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(366, 37);
            this.cboUnit.TabIndex = 54;
            // 
            // cboLeaveType
            // 
            this.cboLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaveType.FormattingEnabled = true;
            this.cboLeaveType.Location = new System.Drawing.Point(1323, 87);
            this.cboLeaveType.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.cboLeaveType.Name = "cboLeaveType";
            this.cboLeaveType.Size = new System.Drawing.Size(277, 37);
            this.cboLeaveType.TabIndex = 55;
            this.cboLeaveType.DropDown += new System.EventHandler(this.cboLeaveType_DropDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1153, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 29);
            this.label8.TabIndex = 56;
            this.label8.Text = "Leave Type:";
            // 
            // LeaveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1834, 1075);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboLeaveType);
            this.Controls.Add(this.cboUnit);
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
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.cboGrade);
            this.Controls.Add(this.cboGradeCategory);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "LeaveView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Requested View";
            this.Load += new System.EventHandler(this.LeaveView_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private CalendarColumn calendarColumn1;
        private CalendarColumn calendarColumn2;
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
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.ComboBox cboLeaveType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnnualLeave;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnnualLeaveYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeaveArrears;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnnualLeaveProposedStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnnualLeaveProposedEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnnualLeaveProposedDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGradeCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNumberOfDays;
        private CalendarColumn gridStartDate;
        private CalendarColumn gridEndDate;
        private CalendarColumn gridLeaveDate;
        private CalendarColumn gridCurrentLeaveEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridReason;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridRecommended;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
        public System.Windows.Forms.Button removeButton;
    }
}