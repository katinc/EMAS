namespace eMAS.Forms.PayRollProcessing
{
    partial class PayrollGeneration
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
            dal.CloseConnection();
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
            this.label2 = new System.Windows.Forms.Label();
            this.attendanceGroupBox = new System.Windows.Forms.GroupBox();
            this.btnPrintAllSlips = new System.Windows.Forms.Button();
            this.btnRemoveSelectedSlips = new System.Windows.Forms.Button();
            this.btnEmployeeBanks = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnPrintSelectedSlips = new System.Windows.Forms.Button();
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.grid1StaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1AttendanceDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewSelectedSlips = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPaymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAttendanceDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridBasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSNNITEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridIncomeTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNetAfterTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAllowances = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNetSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDeductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMedicalClaims = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTakeHome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSSNITNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGradeLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSSNITEmployer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.btnMedicalClaims = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnViewPayroll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeletePayroll = new System.Windows.Forms.Button();
            this.btnOpenPayroll = new System.Windows.Forms.Button();
            this.btnPrintPayroll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClosePayroll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.payRollButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.staffIDTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.periodGroupBox = new System.Windows.Forms.GroupBox();
            this.periodComboBox = new System.Windows.Forms.ComboBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.periodLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
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
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.periodGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Master Payroll Generation";
            // 
            // attendanceGroupBox
            // 
            this.attendanceGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.attendanceGroupBox.Controls.Add(this.btnPrintAllSlips);
            this.attendanceGroupBox.Controls.Add(this.btnRemoveSelectedSlips);
            this.attendanceGroupBox.Controls.Add(this.btnEmployeeBanks);
            this.attendanceGroupBox.Controls.Add(this.button5);
            this.attendanceGroupBox.Controls.Add(this.btnPrintSelectedSlips);
            this.attendanceGroupBox.Controls.Add(this.grid1);
            this.attendanceGroupBox.Controls.Add(this.btnViewSelectedSlips);
            this.attendanceGroupBox.Controls.Add(this.grid);
            this.attendanceGroupBox.Controls.Add(this.button4);
            this.attendanceGroupBox.Controls.Add(this.btnMedicalClaims);
            this.attendanceGroupBox.Controls.Add(this.button1);
            this.attendanceGroupBox.Controls.Add(this.button2);
            this.attendanceGroupBox.Enabled = false;
            this.attendanceGroupBox.Location = new System.Drawing.Point(11, 156);
            this.attendanceGroupBox.Name = "attendanceGroupBox";
            this.attendanceGroupBox.Size = new System.Drawing.Size(1120, 412);
            this.attendanceGroupBox.TabIndex = 12;
            this.attendanceGroupBox.TabStop = false;
            this.attendanceGroupBox.Text = "Staff To Be Put On PayRoll";
            // 
            // btnPrintAllSlips
            // 
            this.btnPrintAllSlips.Location = new System.Drawing.Point(351, 383);
            this.btnPrintAllSlips.Name = "btnPrintAllSlips";
            this.btnPrintAllSlips.Size = new System.Drawing.Size(78, 25);
            this.btnPrintAllSlips.TabIndex = 16;
            this.btnPrintAllSlips.Text = "Print All Slips";
            this.btnPrintAllSlips.UseVisualStyleBackColor = true;
            this.btnPrintAllSlips.Click += new System.EventHandler(this.btnPrintAllSlips_Click);
            // 
            // btnRemoveSelectedSlips
            // 
            this.btnRemoveSelectedSlips.Location = new System.Drawing.Point(6, 383);
            this.btnRemoveSelectedSlips.Name = "btnRemoveSelectedSlips";
            this.btnRemoveSelectedSlips.Size = new System.Drawing.Size(124, 25);
            this.btnRemoveSelectedSlips.TabIndex = 15;
            this.btnRemoveSelectedSlips.Text = "Remove Selected Slips";
            this.btnRemoveSelectedSlips.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedSlips.Click += new System.EventHandler(this.btnRemoveSelectedSlips_Click);
            // 
            // btnEmployeeBanks
            // 
            this.btnEmployeeBanks.Location = new System.Drawing.Point(622, 382);
            this.btnEmployeeBanks.Name = "btnEmployeeBanks";
            this.btnEmployeeBanks.Size = new System.Drawing.Size(93, 25);
            this.btnEmployeeBanks.TabIndex = 14;
            this.btnEmployeeBanks.Text = "Employee Banks";
            this.btnEmployeeBanks.UseVisualStyleBackColor = true;
            this.btnEmployeeBanks.Visible = false;
            this.btnEmployeeBanks.Click += new System.EventHandler(this.btnEmployeeBanks_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(718, 382);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(68, 25);
            this.button5.TabIndex = 13;
            this.button5.Text = "Salary Info";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnSalaryInfo_Click);
            // 
            // btnPrintSelectedSlips
            // 
            this.btnPrintSelectedSlips.Location = new System.Drawing.Point(241, 383);
            this.btnPrintSelectedSlips.Name = "btnPrintSelectedSlips";
            this.btnPrintSelectedSlips.Size = new System.Drawing.Size(107, 25);
            this.btnPrintSelectedSlips.TabIndex = 10;
            this.btnPrintSelectedSlips.Text = "Print Selected Slips";
            this.btnPrintSelectedSlips.UseVisualStyleBackColor = true;
            this.btnPrintSelectedSlips.Click += new System.EventHandler(this.btnPrintSelectedSlips_Click);
            // 
            // grid1
            // 
            this.grid1.AllowUserToAddRows = false;
            this.grid1.AllowUserToDeleteRows = false;
            this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid1StaffNo,
            this.grid1Name,
            this.grid1AttendanceDays});
            this.grid1.Location = new System.Drawing.Point(845, 143);
            this.grid1.Name = "grid1";
            this.grid1.ReadOnly = true;
            this.grid1.Size = new System.Drawing.Size(240, 150);
            this.grid1.TabIndex = 12;
            this.grid1.Visible = false;
            // 
            // grid1StaffNo
            // 
            this.grid1StaffNo.HeaderText = "StaffNo";
            this.grid1StaffNo.Name = "grid1StaffNo";
            this.grid1StaffNo.ReadOnly = true;
            // 
            // grid1Name
            // 
            this.grid1Name.HeaderText = "Name";
            this.grid1Name.Name = "grid1Name";
            this.grid1Name.ReadOnly = true;
            // 
            // grid1AttendanceDays
            // 
            this.grid1AttendanceDays.HeaderText = "Attendance Days";
            this.grid1AttendanceDays.Name = "grid1AttendanceDays";
            this.grid1AttendanceDays.ReadOnly = true;
            // 
            // btnViewSelectedSlips
            // 
            this.btnViewSelectedSlips.Location = new System.Drawing.Point(132, 383);
            this.btnViewSelectedSlips.Name = "btnViewSelectedSlips";
            this.btnViewSelectedSlips.Size = new System.Drawing.Size(107, 25);
            this.btnViewSelectedSlips.TabIndex = 10;
            this.btnViewSelectedSlips.Text = "View Selected Slips";
            this.btnViewSelectedSlips.UseVisualStyleBackColor = true;
            this.btnViewSelectedSlips.Click += new System.EventHandler(this.btnViewSelectedSlips_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridPaymentID,
            this.gridStaffNo,
            this.gridName,
            this.gridAttendanceDays,
            this.gridMonth,
            this.gridYear,
            this.gridBasicSalary,
            this.gridSNNITEmployee,
            this.gridIncomeTax,
            this.gridNetAfterTax,
            this.gridAllowances,
            this.gridNetSalary,
            this.gridDeductions,
            this.gridMedicalClaims,
            this.gridLoan,
            this.gridTakeHome,
            this.gridPaymentMode,
            this.gridDepartment,
            this.gridSSNITNo,
            this.gridGrade,
            this.gridGradeLevel,
            this.gridSSNITEmployer,
            this.gridStatus});
            this.grid.Location = new System.Drawing.Point(4, 18);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1111, 361);
            this.grid.TabIndex = 0;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridPaymentID
            // 
            this.gridPaymentID.HeaderText = "Payment ID";
            this.gridPaymentID.Name = "gridPaymentID";
            this.gridPaymentID.ReadOnly = true;
            this.gridPaymentID.Visible = false;
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffID";
            this.gridStaffNo.HeaderText = "Staff No.";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 250;
            // 
            // gridAttendanceDays
            // 
            this.gridAttendanceDays.DataPropertyName = "Attendance";
            this.gridAttendanceDays.HeaderText = "Attendance Days";
            this.gridAttendanceDays.Name = "gridAttendanceDays";
            this.gridAttendanceDays.ReadOnly = true;
            this.gridAttendanceDays.Width = 120;
            // 
            // gridMonth
            // 
            this.gridMonth.HeaderText = "Month";
            this.gridMonth.Name = "gridMonth";
            this.gridMonth.ReadOnly = true;
            // 
            // gridYear
            // 
            this.gridYear.HeaderText = "Year";
            this.gridYear.Name = "gridYear";
            this.gridYear.ReadOnly = true;
            // 
            // gridBasicSalary
            // 
            this.gridBasicSalary.HeaderText = "Basic Salary";
            this.gridBasicSalary.Name = "gridBasicSalary";
            this.gridBasicSalary.ReadOnly = true;
            // 
            // gridSNNITEmployee
            // 
            this.gridSNNITEmployee.HeaderText = "SSNIT (Employee)";
            this.gridSNNITEmployee.Name = "gridSNNITEmployee";
            this.gridSNNITEmployee.ReadOnly = true;
            // 
            // gridIncomeTax
            // 
            this.gridIncomeTax.HeaderText = "Income Tax";
            this.gridIncomeTax.Name = "gridIncomeTax";
            this.gridIncomeTax.ReadOnly = true;
            // 
            // gridNetAfterTax
            // 
            this.gridNetAfterTax.HeaderText = "Net After Tax";
            this.gridNetAfterTax.Name = "gridNetAfterTax";
            this.gridNetAfterTax.ReadOnly = true;
            // 
            // gridAllowances
            // 
            this.gridAllowances.HeaderText = "Allowances";
            this.gridAllowances.Name = "gridAllowances";
            this.gridAllowances.ReadOnly = true;
            // 
            // gridNetSalary
            // 
            this.gridNetSalary.HeaderText = "Net Salary";
            this.gridNetSalary.Name = "gridNetSalary";
            this.gridNetSalary.ReadOnly = true;
            // 
            // gridDeductions
            // 
            this.gridDeductions.HeaderText = "Deductions";
            this.gridDeductions.Name = "gridDeductions";
            this.gridDeductions.ReadOnly = true;
            // 
            // gridMedicalClaims
            // 
            this.gridMedicalClaims.HeaderText = "Medical Claims";
            this.gridMedicalClaims.Name = "gridMedicalClaims";
            this.gridMedicalClaims.ReadOnly = true;
            // 
            // gridLoan
            // 
            this.gridLoan.HeaderText = "Loans Taken";
            this.gridLoan.Name = "gridLoan";
            this.gridLoan.ReadOnly = true;
            // 
            // gridTakeHome
            // 
            this.gridTakeHome.HeaderText = "Take Home";
            this.gridTakeHome.Name = "gridTakeHome";
            this.gridTakeHome.ReadOnly = true;
            // 
            // gridPaymentMode
            // 
            this.gridPaymentMode.HeaderText = "Payment Mode";
            this.gridPaymentMode.Name = "gridPaymentMode";
            this.gridPaymentMode.ReadOnly = true;
            // 
            // gridDepartment
            // 
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            // 
            // gridSSNITNo
            // 
            this.gridSSNITNo.HeaderText = "SSNIT No";
            this.gridSSNITNo.Name = "gridSSNITNo";
            this.gridSSNITNo.ReadOnly = true;
            // 
            // gridGrade
            // 
            this.gridGrade.HeaderText = "Grade";
            this.gridGrade.Name = "gridGrade";
            this.gridGrade.ReadOnly = true;
            // 
            // gridGradeLevel
            // 
            this.gridGradeLevel.HeaderText = "Grade Level";
            this.gridGradeLevel.Name = "gridGradeLevel";
            this.gridGradeLevel.ReadOnly = true;
            // 
            // gridSSNITEmployer
            // 
            this.gridSSNITEmployer.HeaderText = "SSNIT (Employer)";
            this.gridSSNITEmployer.Name = "gridSSNITEmployer";
            this.gridSSNITEmployer.ReadOnly = true;
            // 
            // gridStatus
            // 
            this.gridStatus.HeaderText = "Status";
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.ReadOnly = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1026, 382);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 25);
            this.button4.TabIndex = 8;
            this.button4.Text = "Loan Payments";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnLoanPayments_Click);
            // 
            // btnMedicalClaims
            // 
            this.btnMedicalClaims.Location = new System.Drawing.Point(789, 382);
            this.btnMedicalClaims.Name = "btnMedicalClaims";
            this.btnMedicalClaims.Size = new System.Drawing.Size(85, 25);
            this.btnMedicalClaims.TabIndex = 7;
            this.btnMedicalClaims.Text = "Medical Claims";
            this.btnMedicalClaims.UseVisualStyleBackColor = true;
            this.btnMedicalClaims.Click += new System.EventHandler(this.btnMedicalClaims_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            // 
            // btnViewPayroll
            // 
            this.btnViewPayroll.Location = new System.Drawing.Point(264, 5);
            this.btnViewPayroll.Name = "btnViewPayroll";
            this.btnViewPayroll.Size = new System.Drawing.Size(85, 25);
            this.btnViewPayroll.TabIndex = 11;
            this.btnViewPayroll.Text = "View Pay Roll";
            this.btnViewPayroll.UseVisualStyleBackColor = true;
            this.btnViewPayroll.Click += new System.EventHandler(this.btnViewPayroll_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 35);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.btnDeletePayroll);
            this.panel2.Controls.Add(this.btnOpenPayroll);
            this.panel2.Controls.Add(this.btnPrintPayroll);
            this.panel2.Controls.Add(this.btnViewPayroll);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnClosePayroll);
            this.panel2.Location = new System.Drawing.Point(1, 570);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 35);
            this.panel2.TabIndex = 14;
            // 
            // btnDeletePayroll
            // 
            this.btnDeletePayroll.Location = new System.Drawing.Point(3, 5);
            this.btnDeletePayroll.Name = "btnDeletePayroll";
            this.btnDeletePayroll.Size = new System.Drawing.Size(91, 25);
            this.btnDeletePayroll.TabIndex = 16;
            this.btnDeletePayroll.Text = "Delete PayRoll";
            this.btnDeletePayroll.UseVisualStyleBackColor = true;
            this.btnDeletePayroll.Click += new System.EventHandler(this.btnDeletePayroll_Click);
            // 
            // btnOpenPayroll
            // 
            this.btnOpenPayroll.Location = new System.Drawing.Point(96, 5);
            this.btnOpenPayroll.Name = "btnOpenPayroll";
            this.btnOpenPayroll.Size = new System.Drawing.Size(83, 25);
            this.btnOpenPayroll.TabIndex = 15;
            this.btnOpenPayroll.Text = "Open PayRoll";
            this.btnOpenPayroll.UseVisualStyleBackColor = true;
            this.btnOpenPayroll.Click += new System.EventHandler(this.btnOpenPayroll_Click);
            // 
            // btnPrintPayroll
            // 
            this.btnPrintPayroll.Location = new System.Drawing.Point(350, 5);
            this.btnPrintPayroll.Name = "btnPrintPayroll";
            this.btnPrintPayroll.Size = new System.Drawing.Size(89, 25);
            this.btnPrintPayroll.TabIndex = 14;
            this.btnPrintPayroll.Text = "Print Pay Roll";
            this.btnPrintPayroll.UseVisualStyleBackColor = true;
            this.btnPrintPayroll.Visible = false;
            this.btnPrintPayroll.Click += new System.EventHandler(this.btnPrintPayroll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1071, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClosePayroll
            // 
            this.btnClosePayroll.Location = new System.Drawing.Point(180, 5);
            this.btnClosePayroll.Name = "btnClosePayroll";
            this.btnClosePayroll.Size = new System.Drawing.Size(83, 25);
            this.btnClosePayroll.TabIndex = 3;
            this.btnClosePayroll.Text = "Close PayRoll";
            this.btnClosePayroll.UseVisualStyleBackColor = true;
            this.btnClosePayroll.Click += new System.EventHandler(this.btnClosePayroll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.payRollButton);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.staffIDTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.periodGroupBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDepartments);
            this.groupBox1.Location = new System.Drawing.Point(10, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1121, 110);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Criteria";
            // 
            // payRollButton
            // 
            this.payRollButton.Location = new System.Drawing.Point(579, 36);
            this.payRollButton.Name = "payRollButton";
            this.payRollButton.Size = new System.Drawing.Size(75, 50);
            this.payRollButton.TabIndex = 27;
            this.payRollButton.Text = "Generate Pay Roll";
            this.payRollButton.UseVisualStyleBackColor = true;
            this.payRollButton.Click += new System.EventHandler(this.payRollButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(898, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 86);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Legend";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Open";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(19, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(19, 18);
            this.panel6.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Open";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Closed";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Lavender;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(120, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(19, 18);
            this.panel5.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(120, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(19, 18);
            this.panel4.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(19, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(19, 18);
            this.panel3.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Bad";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.White;
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(98, 47);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(223, 21);
            this.nameTextBox.TabIndex = 18;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // staffIDTextBox
            // 
            this.staffIDTextBox.BackColor = System.Drawing.Color.White;
            this.staffIDTextBox.Enabled = false;
            this.staffIDTextBox.Location = new System.Drawing.Point(98, 74);
            this.staffIDTextBox.Name = "staffIDTextBox";
            this.staffIDTextBox.ReadOnly = true;
            this.staffIDTextBox.Size = new System.Drawing.Size(223, 21);
            this.staffIDTextBox.TabIndex = 17;
            this.staffIDTextBox.TextChanged += new System.EventHandler(this.staffIDTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "StaffID:";
            // 
            // periodGroupBox
            // 
            this.periodGroupBox.Controls.Add(this.periodComboBox);
            this.periodGroupBox.Controls.Add(this.yearComboBox);
            this.periodGroupBox.Controls.Add(this.yearLabel);
            this.periodGroupBox.Controls.Add(this.periodLabel);
            this.periodGroupBox.Enabled = false;
            this.periodGroupBox.Location = new System.Drawing.Point(347, 14);
            this.periodGroupBox.Name = "periodGroupBox";
            this.periodGroupBox.Size = new System.Drawing.Size(214, 86);
            this.periodGroupBox.TabIndex = 13;
            this.periodGroupBox.TabStop = false;
            this.periodGroupBox.Text = "Period";
            // 
            // periodComboBox
            // 
            this.periodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodComboBox.FormattingEnabled = true;
            this.periodComboBox.Location = new System.Drawing.Point(66, 22);
            this.periodComboBox.Name = "periodComboBox";
            this.periodComboBox.Size = new System.Drawing.Size(121, 21);
            this.periodComboBox.TabIndex = 2;
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(66, 48);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(121, 21);
            this.yearComboBox.TabIndex = 1;
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.BackColor = System.Drawing.Color.Transparent;
            this.yearLabel.Location = new System.Drawing.Point(23, 51);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(33, 13);
            this.yearLabel.TabIndex = 0;
            this.yearLabel.Text = "Year:";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.BackColor = System.Drawing.Color.Transparent;
            this.periodLabel.Location = new System.Drawing.Point(23, 25);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(35, 13);
            this.periodLabel.TabIndex = 0;
            this.periodLabel.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Department:";
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(98, 20);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(223, 21);
            this.cmbDepartments.TabIndex = 14;
            this.cmbDepartments.SelectedIndexChanged += new System.EventHandler(this.cmbDepartments_SelectedIndexChanged);
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
            this.dataGridViewTextBoxColumn2.HeaderText = "Payment ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StaffID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Staff No.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Attendance";
            this.dataGridViewTextBoxColumn5.HeaderText = "Attendance Days";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "StaffID";
            this.dataGridViewTextBoxColumn6.HeaderText = "Basic Salary";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn7.HeaderText = "Start Date";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 250;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Attendance";
            this.dataGridViewTextBoxColumn8.HeaderText = "End Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "SSNIT (Employee)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "SSNIT (Employer";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Income Tax";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Net After Tax";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Net Salary";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Medical Claims";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Take Home";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Loans Taken";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Payment Mode";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Department";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "SSNIT No";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "Grade Level";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "Status";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "Grade Level";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.HeaderText = "Status";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.HeaderText = "Status";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.HeaderText = "SSNIT (Employer";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            // 
            // PayrollGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1133, 605);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.attendanceGroupBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PayrollGeneration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Payroll Generation";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.attendanceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.periodGroupBox.ResumeLayout(false);
            this.periodGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox attendanceGroupBox;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClosePayroll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox periodGroupBox;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnMedicalClaims;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox staffIDTextBox;
        private System.Windows.Forms.Button btnViewSelectedSlips;
        private System.Windows.Forms.Button btnViewPayroll;
        private System.Windows.Forms.Button btnPrintSelectedSlips;
        private System.Windows.Forms.DataGridView grid1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1StaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1AttendanceDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox periodComboBox;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.Button btnEmployeeBanks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSSNITEmployee;
        private System.Windows.Forms.Button btnRemoveSelectedSlips;
        private System.Windows.Forms.Button btnPrintPayroll;
        private System.Windows.Forms.Button payRollButton;
        private System.Windows.Forms.Button btnOpenPayroll;
        private System.Windows.Forms.Button btnDeletePayroll;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPaymentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAttendanceDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridBasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSNNITEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIncomeTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNetAfterTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAllowances;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNetSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDeductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMedicalClaims;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTakeHome;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSSNITNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGradeLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSSNITEmployer;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStatus;
        private System.Windows.Forms.Button btnPrintAllSlips;
    }
}